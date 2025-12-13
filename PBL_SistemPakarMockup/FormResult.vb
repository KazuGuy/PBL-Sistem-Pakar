Imports Microsoft.Data.SqlClient ' <--- 1. INI WAJIB ADA BIAR KENAL SQL

Public Class FormResult

    Private userScores As List(Of Integer)

    ' Constructor menerima skor dari Quiz
    Public Sub New(scores As List(Of Integer))
        InitializeComponent()
        userScores = scores
    End Sub

    Private Sub FormResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' 1. Panggil fungsi hitung
        Dim hasil = DbConnect.HitungDiagnosa(userScores)

        ' 2. Tampilkan Judul & Deskripsi Utama
        lblHasil.Text = hasil("Judul")
        lblDeskripsi.Text = hasil("Deskripsi")

        ' 3. Tampilkan 6 Persentase Rinci
        lblSkorT1.Text = "Software & Data Engineering: " & hasil("Skor_T1") & "%"
        lblSkorT2.Text = "Network & Infrastructure Engineering: " & hasil("Skor_T2") & "%"
        lblSkorT3.Text = "Digital Creative & Multimedia: " & hasil("Skor_T3") & "%"

        lblSkorP4.Text = "Cloud Computing & DevOps (Techno-Network): " & hasil("Skor_P4") & "%"
        lblSkorP5.Text = "Broadcasting & Streaming Technology (Net-Media): " & hasil("Skor_P5") & "%"
        lblSkorP6.Text = "Interactive Media & Game Development (Techno-Media): " & hasil("Skor_P6") & "%"

        ' 4. Update ProgressBar
        ' (Pastikan ProgressBar pbT1 s/d pbP6 sudah ditarik di Designer ya!)
        If pbT1 IsNot Nothing Then pbT1.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_T1"))))
        If pbT2 IsNot Nothing Then pbT2.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_T2"))))
        If pbT3 IsNot Nothing Then pbT3.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_T3"))))
        If pbP4 IsNot Nothing Then pbP4.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_P4"))))
        If pbP5 IsNot Nothing Then pbP5.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_P5"))))
        If pbP6 IsNot Nothing Then pbP6.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_P6"))))

        ' 5. SIMPAN KE DATABASE OTOMATIS
        Dim valT1 = Convert.ToDouble(hasil("Skor_T1"))
        Dim valT2 = Convert.ToDouble(hasil("Skor_T2"))
        Dim valT3 = Convert.ToDouble(hasil("Skor_T3"))

        SimpanKeRiwayat(hasil("Judul"), valT1, valT2, valT3)
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        ' JANGAN BIKIN NEW FORM, Cukup tutup form ini.
        ' Nanti form induknya akan menangani navigasi.
        Me.Close()
    End Sub

    ' --- PROSEDUR SIMPAN KE DATABASE ---
    Private Sub SimpanKeRiwayat(judul As String, nilaiT1 As Double, nilaiT2 As Double, nilaiT3 As Double)
        Try
            ' Cek kalau user belum login
            If ModuleSession.LoginNIM = "" Then
                ' ModuleSession.LoginNIM = "TEST001" ' Uncomment buat testing
                Return
            End If

            ' 2. PERBAIKAN: Langsung panggil SqlConnection (tanpa SqlClient.)
            Using conn As New SqlConnection(DbConnect.ConnectionString)
                conn.Open()
                Dim query As String = "INSERT INTO riwayat (nim, tanggal, hasil, nilai_T1, nilai_T2, nilai_T3) " &
                                      "VALUES (@nim, @tgl, @hasil, @nT1, @nT2, @nT3)"

                ' 3. PERBAIKAN: Langsung panggil SqlCommand (tanpa SqlClient.)
                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nim", ModuleSession.LoginNIM)
                    cmd.Parameters.AddWithValue("@tgl", DateTime.Now)
                    cmd.Parameters.AddWithValue("@hasil", judul)
                    cmd.Parameters.AddWithValue("@nT1", nilaiT1)
                    cmd.Parameters.AddWithValue("@nT2", nilaiT2)
                    cmd.Parameters.AddWithValue("@nT3", nilaiT3)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan riwayat: " & ex.Message)
        End Try
    End Sub

    Private Sub lblSkorP6_Click(sender As Object, e As EventArgs) Handles lblSkorP6.Click
        ' Kosong gpp
    End Sub

End Class





'Public Class FormResult

'    Private userScores As List(Of Integer)

'    ' Constructor menerima skor dari Quiz
'    Public Sub New(scores As List(Of Integer))
'        InitializeComponent()
'        userScores = scores
'    End Sub

'    Private Sub FormResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load
'        ' 1. Panggil fungsi hitung
'        Dim hasil = DbConnect.HitungDiagnosa(userScores)

'        ' 2. Tampilkan Judul & Deskripsi Utama
'        lblHasil.Text = hasil("Judul")
'        lblDeskripsi.Text = hasil("Deskripsi")

'        ' 3. Tampilkan 6 Persentase Rinci
'        ' Pastikan kamu udah bikin label-label ini di Designer ya!
'        lblSkorT1.Text = "Software & Data Engineering: " & hasil("Skor_T1") & "%"
'        lblSkorT2.Text = "Network & Infrastructure Engineering: " & hasil("Skor_T2") & "%"
'        lblSkorT3.Text = "Digital Creative & Multimedia: " & hasil("Skor_T3") & "%"

'        lblSkorP4.Text = "ICloud Computing & DevOps (Techno-Network): " & hasil("Skor_P4") & "%"
'        lblSkorP5.Text = "Broadcasting & Streaming Technology (Net-Media): " & hasil("Skor_P5") & "%"
'        lblSkorP6.Text = "Interactive Media & Game Development (Techno-Media): " & hasil("Skor_P6") & "%"

'        ' Update ProgressBar
'        pbT1.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_T1"))))
'        pbT2.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_T2"))))
'        pbT3.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_T3"))))
'        pbP4.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_P4"))))
'        pbP5.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_P5"))))
'        pbP6.Value = CInt(Math.Round(Convert.ToDouble(hasil("Skor_P6"))))

'        ' 5. SIMPAN KE DATABASE OTOMATIS
'        ' Kita ambil nilai double-nya buat disimpan ke DB
'        Dim valT1 = Convert.ToDouble(hasil("Skor_T1"))
'        Dim valT2 = Convert.ToDouble(hasil("Skor_T2"))
'        Dim valT3 = Convert.ToDouble(hasil("Skor_T3"))

'        SimpanKeRiwayat(hasil("Judul"), valT1, valT2, valT3)
'    End Sub

'    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
'        Dim Home As New FormHome()
'        Home.Show()
'        'Me.Close()
'    End Sub

'    ' --- PROSEDUR SIMPAN KE DATABASE ---
'    Private Sub SimpanKeRiwayat(judul As String, nilaiT1 As Double, nilaiT2 As Double, nilaiT3 As Double)
'        Try
'            ' Cek kalau user belum login (Misal pas testing doang)
'            If ModuleSession.LoginNIM = "" Then
'                ' Kalau mau testing tanpa login, uncomment baris bawah ini:
'                ' ModuleSession.LoginNIM = "TEST001" 
'                Return ' Gak usah simpan kalau gak ada NIM
'            End If

'            Using conn As New SqlClient.SqlConnection(DbConnect.ConnectionString)
'                conn.Open()
'                Dim query As String = "INSERT INTO riwayat (nim, tanggal, hasil, nilai_T1, nilai_T2, nilai_T3) " &
'                                      "VALUES (@nim, @tgl, @hasil, @nT1, @nT2, @nT3)"

'                Using cmd As New SqlClient.SqlCommand(query, conn)
'                    cmd.Parameters.AddWithValue("@nim", ModuleSession.LoginNIM)
'                    cmd.Parameters.AddWithValue("@tgl", DateTime.Now) ' Tanggal & Jam sekarang
'                    cmd.Parameters.AddWithValue("@hasil", judul)      ' Misal: Dominan Multimedia
'                    cmd.Parameters.AddWithValue("@nT1", nilaiT1)      ' Skor Informatika
'                    cmd.Parameters.AddWithValue("@nT2", nilaiT2)      ' Skor Jaringan
'                    cmd.Parameters.AddWithValue("@nT3", nilaiT3)      ' Skor Multimedia

'                    cmd.ExecuteNonQuery()
'                End Using
'            End Using
'            ' Debug.WriteLine("Data Berhasil Disimpan!") 

'        Catch ex As Exception
'            MessageBox.Show("Gagal menyimpan riwayat: " & ex.Message)
'        End Try
'    End Sub

'    Private Sub lblSkorP6_Click(sender As Object, e As EventArgs) Handles lblSkorP6.Click

'    End Sub
'End Class