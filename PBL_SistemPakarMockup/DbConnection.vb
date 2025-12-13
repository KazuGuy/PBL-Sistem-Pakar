Imports Microsoft.Data.SqlClient

Module DbConnect

    ' --- BAGIAN INI SUDAH DIPERBAIKI ---
    ' Sekarang dia ngambil alamat dari Settings, bukan nulis manual lagi.
    ' Jadi dia bakal otomatis ngikut ke DbUtama.mdf
    Public ReadOnly Property ConnectionString As String
        Get
            Return My.Settings.Database1ConnectionString
        End Get
    End Property

    'Private _conn As SqlConnection

    Public ReadOnly Property Connection As SqlConnection
        Get
            Return New SqlConnection(ConnectionString)
        End Get
    End Property


    ' Fungsi ambil pertanyaan (Aku rapihin dikit query-nya)
    Public Function GetPertanyaanList() As List(Of String)
        Dim list As New List(Of String)

        Try
            ' Menggunakan Using biar koneksi otomatis tertutup rapi setelah selesai
            Using conn As New SqlConnection(ConnectionString)
                conn.Open()

                ' Pastikan nama tabel di sini sesuai database kamu (pertanyaan / tb_pertanyaan)
                Dim query As String = "SELECT pertanyaan FROM pertanyaan ORDER BY kodeGejala"

                Using cmd As New SqlCommand(query, conn)
                    Using rd = cmd.ExecuteReader()
                        While rd.Read()
                            ' Cek dulu datanya null atau nggak biar gak crash
                            If Not rd.IsDBNull(0) Then
                                list.Add(rd.GetString(0))
                            End If
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            ' Biar gak ganggu flow, kita catat aja errornya di debug console
            Debug.WriteLine("Error mengambil pertanyaan: " & ex.Message)
        End Try

        Return list
    End Function

    ' --- FUNGSI HITUNG DIAGNOSA (FULL CF + 6 OUTPUT) ---
    Public Function HitungDiagnosa(userScores As List(Of Integer)) As Dictionary(Of String, String)
        Dim hasil As New Dictionary(Of String, String)

        ' Default value biar gak error
        hasil("Judul") = "Tidak Teridentifikasi"
        hasil("Deskripsi") = "Data tidak cukup."
        hasil("Skor_T1") = "0"
        hasil("Skor_T2") = "0"
        hasil("Skor_T3") = "0"
        hasil("Skor_P4") = "0" ' Irisan T1-T2
        hasil("Skor_P5") = "0" ' Irisan T2-T3
        hasil("Skor_P6") = "0" ' Irisan T1-T3

        Try
            Using conn As New SqlConnection(ConnectionString)
                conn.Open()

                ' 1. SIAPKAN VARIABEL CF
                ' Kita pakai Dictionary buat nyimpen nilai CF kombinasi tiap topik
                Dim cfTotal As New Dictionary(Of String, Double)
                cfTotal.Add("T1", 0)
                cfTotal.Add("T2", 0)
                cfTotal.Add("T3", 0)

                ' 2. AMBIL ATURAN DARI DB & HITUNG CF (FORWARD CHAINING)
                ' Data Driven: Kita cek semua fakta (jawaban user), baru simpulkan.
                Dim query As String = "SELECT kodeRule, kodeGejala, bobot FROM rule_detail"

                Using cmd As New SqlCommand(query, conn)
                    Using rd = cmd.ExecuteReader()
                        While rd.Read()
                            Dim topik = rd("kodeRule").ToString()     ' T1 / T2 / T3
                            Dim kGejala = rd("kodeGejala").ToString() ' G01...
                            Dim cfPakar = Convert.ToDouble(rd("bobot"))

                            ' Ambil jawaban user untuk gejala ini
                            ' G01 -> index 0
                            Dim idx = Integer.Parse(kGejala.Substring(1)) - 1

                            If idx >= 0 AndAlso idx < userScores.Count Then
                                ' A. NORMALISASI JAWABAN USER (1-5 jadi 0.0 - 1.0)
                                ' 1=0.0, 2=0.25, 3=0.5, 4=0.75, 5=1.0
                                Dim userInput As Integer = userScores(idx)
                                Dim cfUser As Double = (userInput - 1) / 10.0

                                ' B. HITUNG CF GEJALA (CF User * CF Pakar)
                                Dim cfGejala As Double = cfUser * cfPakar

                                ' C. HITUNG CF COMBINE (RUMUS UTAMA)
                                ' CF_Baru = CF_Lama + CF_Gejala * (1 - CF_Lama)
                                Dim cfLama As Double = cfTotal(topik)
                                Dim cfBaru As Double = cfLama + (cfGejala * (1 - cfLama))

                                ' Simpan nilai baru
                                cfTotal(topik) = cfBaru
                            End If
                        End While
                    End Using
                End Using

                ' 3. KONVERSI KE PERSEN & HITUNG IRISAN (6 OUTPUT)
                ' Nilai CF kan 0.0 - 1.0, kita kali 100 biar jadi persen
                Dim valT1 As Double = Math.Round(cfTotal("T1") * 100, 2)
                Dim valT2 As Double = Math.Round(cfTotal("T2") * 100, 2)
                Dim valT3 As Double = Math.Round(cfTotal("T3") * 100, 2)

                ' Hitung Irisan (Rata-rata dari dua topik pembentuknya)
                Dim valP4 As Double = Math.Round((valT1 + valT2) / 2, 2) ' T1 + T2
                Dim valP5 As Double = Math.Round((valT2 + valT3) / 2, 2) ' T2 + T3
                Dim valP6 As Double = Math.Round((valT1 + valT3) / 2, 2) ' T1 + T3

                ' Masukkan ke Dictionary Hasil biar bisa ditampilkan di FormResult
                hasil("Skor_T1") = valT1.ToString()
                hasil("Skor_T2") = valT2.ToString()
                hasil("Skor_T3") = valT3.ToString()
                hasil("Skor_P4") = valP4.ToString()
                hasil("Skor_P5") = valP5.ToString()
                hasil("Skor_P6") = valP6.ToString()

                ' 4. LOGIKA PENENTUAN JUARA (DECISION MAKING)
                Dim ambang As Double = 50.0 ' Batas minimal dibilang "Minat"
                Dim idPemenang As String = ""

                ' --- PRIORITAS 1: IRISAN (Jika dua-duanya tinggi) ---
                If valT1 >= ambang AndAlso valT3 >= ambang Then
                    idPemenang = "P6" ' Game Dev
                ElseIf valT1 >= ambang AndAlso valT2 >= ambang Then
                    idPemenang = "P4" ' Techno-Network
                ElseIf valT2 >= ambang AndAlso valT3 >= ambang Then
                    idPemenang = "P5" ' Net-Media

                    ' --- PRIORITAS 2: MURNI (Salah satu tinggi) ---
                Else
                    If valT1 >= valT2 AndAlso valT1 >= valT3 Then
                        idPemenang = "P1" ' Informatika Murni
                    ElseIf valT2 >= valT1 AndAlso valT2 >= valT3 Then
                        idPemenang = "P2" ' Jaringan Murni
                    Else
                        idPemenang = "P3" ' Multimedia Murni
                    End If
                End If

                ' 5. AMBIL DATA PROFIL PEMENANG DARI DB
                Dim qProfil As String = "SELECT namaProfil, deskripsi, solusi FROM profil_lulusan WHERE idProfil = @id"
                Using cmdP As New SqlCommand(qProfil, conn)
                    cmdP.Parameters.AddWithValue("@id", idPemenang)
                    Using rdP = cmdP.ExecuteReader()
                        If rdP.Read() Then
                            hasil("Judul") = rdP("namaProfil").ToString()
                            hasil("Deskripsi") = rdP("deskripsi").ToString() & vbCrLf & vbCrLf &
                                                 "Saran: " & rdP("solusi").ToString()
                        End If
                    End Using
                End Using

            End Using
        Catch ex As Exception
            hasil("Judul") = "Error Sistem"
            hasil("Deskripsi") = ex.Message
        End Try

        Return hasil
    End Function

End Module




'Imports Microsoft.Data.SqlClient

'Module DbConnect

'    Private ReadOnly ConnectionString As String =
'        "Data Source=(LocalDB)\MSSQLLocalDB;" &
'        "AttachDbFilename=C:\\PBL_Database\Database1.mdf;" &
'        "Integrated Security=True;" &
'        "Connect Timeout=30;" &
'        "MultipleActiveResultSets=True;"

'    Private _conn As SqlConnection

'    Public ReadOnly Property Connection As SqlConnection
'        Get
'            If _conn Is Nothing Then
'                _conn = New SqlConnection(ConnectionString)
'            End If

'            If _conn.State = ConnectionState.Closed OrElse
'               _conn.State = ConnectionState.Broken Then
'                _conn.Open()
'            End If

'            Return _conn
'        End Get
'    End Property

'Public ReadOnly Property Connection As SqlConnection
'    Get
'        ' Cek kalau koneksi belum dibuat, kita bikin baru
'        If _conn Is Nothing Then
'            _conn = New SqlConnection(ConnectionString)
'        End If

'        ' Kalau koneksinya lagi nutup/rusak, kita buka pintunya
'        If _conn.State = ConnectionState.Closed OrElse _conn.State = ConnectionState.Broken Then
'            _conn.Open()
'        End If

'        Return _conn
'    End Get
'End Property


'    Public Function GetPertanyaanList() As List(Of String)
'        Dim list As New List(Of String)

'        Try
'            Using conn As New SqlConnection(ConnectionString)
'                conn.Open()

'                Using cmd As New SqlCommand(
'                "SELECT teks_pertanyaan FROM pertanyaan ORDER BY id_pertanyaan", conn)

'                    Using rd = cmd.ExecuteReader()
'                        While rd.Read()
'                            list.Add(rd.GetString(0))
'                        End While
'                    End Using
'                End Using
'            End Using

'        Catch ex As Exception
'            MsgBox("Error mengambil pertanyaan: " & ex.Message)
'        End Try

'        Return list
'    End Function

' --- FUNGSI MENGHITUNG DIAGNOSA ---
' Ini akan mencocokkan jawaban user dengan tabel Rule & Rule_Detail
'Public Function HitungDiagnosa(userScores As List(Of Integer)) As Dictionary(Of String, String)
'    Dim hasil As New Dictionary(Of String, String)
'    hasil("Judul") = "Tidak Teridentifikasi"
'    hasil("Deskripsi") = "Belum ada rule yang cocok."

'    Try
'        Using conn As New SqlConnection(ConnectionString)
'            conn.Open()

'            ' 1. Ambil semua aturan main (Rule Detail) digabung sama Nama Profil (Rule)
'            ' Kita pakai LEFT JOIN biar semua data keambil
'            Dim query As String = "SELECT r.kodeRule, r.hasilDiagnosa, r.solusi, rd.kodeGejala " &
'                                  "FROM rule r " &
'                                  "JOIN rule_detail rd ON r.kodeRule = rd.kodeRule"

'            Using cmd As New SqlCommand(query, conn)
'                Using rd = cmd.ExecuteReader()

'                    ' Variabel buat nyatet skor sementara tiap profesi
'                    ' Format: (KodeRule -> TotalSkor)
'                    Dim skorPerRule As New Dictionary(Of String, Integer)
'                    Dim namaPerRule As New Dictionary(Of String, String)
'                    Dim solusiPerRule As New Dictionary(Of String, String)

'                    While rd.Read()
'                        Dim kRule = rd("kodeRule").ToString()
'                        Dim kGejala = rd("kodeGejala").ToString() ' Misal: G01, G02
'                        Dim nama = rd("hasilDiagnosa").ToString()
'                        Dim solusi = If(rd.IsDBNull(2), "", rd.GetString(2))

'                        ' --- LOGIKA PERHITUNGAN ---
'                        ' Kita ambil angka buntut dari G01, G02... buat jadi index list
'                        ' G01 -> index 0, G02 -> index 1
'                        Dim indexGejala As Integer = Integer.Parse(kGejala.Substring(1)) - 1

'                        ' Pastikan index valid (userScores punya 30 data, index 0-29)
'                        If indexGejala >= 0 AndAlso indexGejala < userScores.Count Then
'                            Dim nilaiUser = userScores(indexGejala)

'                            ' Kalau Rule ini baru ketemu, catat dulu
'                            If Not skorPerRule.ContainsKey(kRule) Then
'                                skorPerRule.Add(kRule, 0)
'                                namaPerRule.Add(kRule, nama)
'                                solusiPerRule.Add(kRule, solusi)
'                            End If

'                            ' Tambahkan nilai user ke total skor rule ini
'                            skorPerRule(kRule) += nilaiUser
'                        End If
'                    End While

'                    ' 2. CARI SKOR TERTINGGI (PEMENANGNYA)
'                    Dim maxSkor As Integer = -1
'                    Dim pemenang As String = ""

'                    For Each pair In skorPerRule
'                        If pair.Value > maxSkor Then
'                            maxSkor = pair.Value
'                            pemenang = pair.Key
'                        End If
'                    Next

'                    ' 3. KEMBALIKAN HASILNYA
'                    If pemenang <> "" Then
'                        hasil("Judul") = namaPerRule(pemenang)
'                        hasil("Deskripsi") = solusiPerRule(pemenang)
'                    End If

'                End Using
'            End Using
'        End Using
'    Catch ex As Exception
'        hasil("Judul") = "Error"
'        hasil("Deskripsi") = ex.Message
'    End Try

'    Return hasil
'End Function

'End Module