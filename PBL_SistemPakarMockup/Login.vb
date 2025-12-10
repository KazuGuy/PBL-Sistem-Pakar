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
            Using conn As SqlConnection = Connection()

                Dim cmd As New SqlCommand("
                    SELECT id_user, nim, nama, prodi 
                    FROM [user]
                    WHERE nim = @nim AND password = @pass
                ", conn)

                cmd.Parameters.AddWithValue("@nim", TextBox1.Text.Trim())
                cmd.Parameters.AddWithValue("@pass", TextBox2.Text.Trim())

                Dim rd As SqlDataReader = cmd.ExecuteReader()

                If rd.Read() Then

                    ' ====== SIMPAN DATA USER KE SESSION ======
                    LoggedUserID = rd("id_user")
                    LoggedUserNIM = rd("nim").ToString()
                    LoggedUserNama = rd("nama").ToString()
                    LoggedUserProdi = rd("prodi").ToString()

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

End Class
