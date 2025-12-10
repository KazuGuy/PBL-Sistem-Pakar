Imports Microsoft.Data.SqlClient

Module DbConnect

    Private ReadOnly ConnectionString As String =
        "Data Source=(LocalDB)\MSSQLLocalDB;" & "AttachDbFilename=C:\Users\Sheva\source\repos\PBL_SistemPakarMockup\PBL_SistemPakarMockup\My Project\Database1.mdf;" & "Integrated Security=True;" & "Connect Timeout=30;" & "MultipleActiveResultSets=True;"    ' biar lebih stabil

    Private _connection As SqlConnection

    Public ReadOnly Property Connection As SqlConnection
        Get
            If _connection Is Nothing Then
                _connection = New SqlConnection(ConnectionString)
            End If

            If _connection.State = ConnectionState.Closed OrElse
               _connection.State = ConnectionState.Broken Then

                _connection.Open()
            End If

            Return _connection
        End Get
    End Property

End Module
