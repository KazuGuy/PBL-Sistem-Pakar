Imports Microsoft.Data.SqlClient

Public Class LupaPassword
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.Trim = "" Then
            MsgBox("NIM tidak boleh kosong!", MsgBoxStyle.Exclamation)
            Return
        End If
        If TextBox2.Text.Trim = "" Then
            MsgBox("Password asli tidak boleh kosong!", MsgBoxStyle.Exclamation)
            Return
        End If
        If TextBox3.Text.Trim = "" Then
            MsgBox("Password baru tidak boleh kosong!", MsgBoxStyle.Exclamation)
            Return
        End If
        If TextBox4.Text.Trim = "" Then
            MsgBox("Konfirmasi password baru tidak boleh kosong!", MsgBoxStyle.Exclamation)
            Return
        End If
        Try
            ' ----------------------------
            ' 1. CEK APAKAH NIM TERDAFTAR
            ' ----------------------------
            Dim conn = Connection
            Dim checkCmd As New SqlCommand(
                "SELECT password FROM [user] WHERE nim = @nim", conn)

            checkCmd.Parameters.AddWithValue("@nim", TextBox1.Text.Trim())

            Dim dbPassword As Object = checkCmd.ExecuteScalar()

            If dbPassword Is Nothing Then
                MsgBox("NIM tidak ditemukan!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' ----------------------------
            ' 2. VALIDASI PASSWORD LAMA
            ' ----------------------------
            If dbPassword.ToString() <> TextBox2.Text.Trim() Then
                MsgBox("Password lama salah!", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            ' ----------------------------
            ' 3. UPDATE PASSWORD BARU
            ' ----------------------------
            Dim updateCmd As New SqlCommand(
                "UPDATE [user] SET password = @newpass WHERE nim = @nim", conn)

            updateCmd.Parameters.AddWithValue("@newpass", TextBox3.Text.Trim())
            updateCmd.Parameters.AddWithValue("@nim", TextBox1.Text.Trim())

            updateCmd.ExecuteNonQuery()

            MsgBox("Password berhasil diperbarui!", MsgBoxStyle.Information)

            ' Kembali ke Login
            Dim loginForm As New Login()
            loginForm.Show()
            Me.Close()

        Catch ex As Exception
            MsgBox("Terjadi error: " & ex.Message, MsgBoxStyle.Critical)
        End Try

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class