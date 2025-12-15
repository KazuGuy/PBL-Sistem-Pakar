Imports Microsoft.Data.SqlClient

Public Class Login

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ' ====== VALIDASI INPUT ======
        If TextBox1.Text.Trim = "" Then
            MsgBox("NIM tidak boleh kosong!", MsgBoxStyle.Exclamation)
            Return
        End If

        If TextBox2.Text.Trim = "" Then
            MsgBox("Password tidak boleh kosong!", MsgBoxStyle.Exclamation)
            Return
        End If

        Try
            Using conn As SqlConnection = DbConnect.Connection
                ' --- TAMBAHKAN BARIS INI (PENTING!) ---
                conn.Open()


                Dim cmd As New SqlCommand("SELECT idUser, nim, nama, prodi FROM [user] WHERE nim = @nim AND password = @pass", conn)

                cmd.Parameters.AddWithValue("@nim", TextBox1.Text.Trim())
                cmd.Parameters.AddWithValue("@pass", TextBox2.Text.Trim())

                Dim rd As SqlDataReader = cmd.ExecuteReader()

                If rd.Read() Then

                    ' ====== SIMPAN DATA USER KE SESSION ======
                    SessionUser.LoggedUserID = rd("idUser")
                    SessionUser.LoggedUserNIM = rd("nim").ToString()
                    SessionUser.LoggedUserNama = rd("nama").ToString()
                    SessionUser.LoggedUserProdi = rd("prodi").ToString()

                    rd.Close()

                    MsgBox("Login berhasil!", MsgBoxStyle.Information, "Sukses")

                    ' ====== BUKA FORM HOME ======
                    Dim mainForm As New FormHome()
                    mainForm.Show()
                    Me.Hide()

                Else
                    MsgBox("NIM atau Password salah!", MsgBoxStyle.Exclamation, "Peringatan")
                End If

            End Using

        Catch ex As Exception
            MsgBox("Error saat login: " & ex.Message)
        End Try

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Hide()

        Dim registerForm As New Register()
        registerForm.ShowDialog()

        'Pas Register udah ditutup, Login muncul lagi
        ' Kita bersihin dulu text-nya biar rasanya kayak Login BARU
        TextBox1.Clear() ' atau txtUsername.Clear()
        TextBox2.Clear() ' atau txtPassword.Clear()

        ' Munculkan lagi
        Me.Show()


        'Me.Close() 'tutup formnya
    End Sub

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Dim lupaForm As New LupaPassword
        lupaForm.ShowDialog()
        Close()
    End Sub

End Class
