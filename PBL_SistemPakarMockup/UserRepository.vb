Imports Microsoft.Data.SqlClient
Module UserRepository
    Public Function Login(nim As String, password As String) As Boolean
        Using conn As SqlConnection = DbConnect.Connection()
            conn.Open()
            Dim query As String = "SELECT COUNT(1) FROM Users WHERE NIM = @NIM AND Password = @Password"
            Using cmd As SqlCommand = New SqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@NIM", nim)
                cmd.Parameters.AddWithValue("@Password", password)
                Dim count As Integer = Convert.ToInt32(cmd.ExecuteScalar())
                Return count = 1
            End Using
        End Using
    End Function
End Module
