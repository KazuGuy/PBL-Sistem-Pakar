Imports Microsoft.Data.SqlClient
Public Class Register
    Private Sub Register_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.Add("Informatika")
        ComboBox1.Items.Add("TMJ")
        ComboBox1.Items.Add("TMD")
        ComboBox1.SelectedIndex = -1
    End Sub
    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text.Trim = "" Then
            MsgBox("Username tidak boleh kosong!", MsgBoxStyle.Exclamation, "Peringatan")
            Return
        End If
        If TextBox3.Text.Trim = "" Then
            MsgBox("Password tidak boleh kosong!", MsgBoxStyle.Exclamation, "Peringatan")
            Return
        End If
        If TextBox3.Text <> TextBox4.Text Then
            MsgBox("Konfirmasi password tidak sesuai!", MsgBoxStyle.Exclamation, "Peringatan")
            Return
        End If
        If TextBox2.Text.Trim = "" Then
            MsgBox("NIM Tidak Boleh Kosong!", MsgBoxStyle.Exclamation, "Peringatan")
            Return
        End If
        If ComboBox1.SelectedIndex = -1 Then
            MsgBox("Silakan pilih Prodi!", MsgBoxStyle.Exclamation, "Peringatan")
            Return
        End If

        Try
            Dim conn As SqlConnection = Connection
            Dim checkNimCmd As New SqlCommand("SELECT COUNT(*) FROM [user] WHERE nim = @nim", conn)
            checkNimCmd.Parameters.AddWithValue("@nim", TextBox2.Text.Trim())
            Dim nimExists As Integer = Convert.ToInt32(checkNimCmd.ExecuteScalar())
            If nimExists > 0 Then
                MsgBox("NIM sudah terdaftar!", MsgBoxStyle.Exclamation, "Peringatan")
                Return
            End If

            Dim insertCmd As New SqlCommand("INSERT INTO [user] (nama, nim, prodi,password) VALUES (@nama, @nim,@prodi,@password)", conn)
            insertCmd.Parameters.AddWithValue("@nama", TextBox1.Text.Trim())
            insertCmd.Parameters.AddWithValue("@prodi", ComboBox1.Text.Trim())
            insertCmd.Parameters.AddWithValue("@nim", TextBox2.Text.Trim())
            insertCmd.Parameters.AddWithValue("@password", TextBox3.Text.Trim())
            insertCmd.ExecuteNonQuery()
            MsgBox("Registrasi berhasil!", MsgBoxStyle.Information, "Sukses")
            Dim loginForm As New Login()
            loginForm.Show()
            Me.Hide()

        Catch ex As Exception
            MsgBox("Error saat registrasi: " & ex.Message)
        End Try


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Hide()
    End Sub


End Class
