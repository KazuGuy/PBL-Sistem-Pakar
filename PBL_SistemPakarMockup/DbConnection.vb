Imports Microsoft.Data.SqlClient

Module DbConnect

    Private ReadOnly ConnectionString As String =
        "Data Source=(LocalDB)\MSSQLLocalDB;" &
        "AttachDbFilename=C:\\PBL_Database\Database1.mdf;" &
        "Integrated Security=True;" &
        "Connect Timeout=30;" &
        "MultipleActiveResultSets=True;"

    Private _conn As SqlConnection

    Public ReadOnly Property Connection As SqlConnection
        Get
            If _conn Is Nothing Then
                _conn = New SqlConnection(ConnectionString)
            End If

            If _conn.State = ConnectionState.Closed OrElse
               _conn.State = ConnectionState.Broken Then
                _conn.Open()
            End If

            Return _conn
        End Get
    End Property

    Public Function GetPertanyaanList() As List(Of String)
        Dim list As New List(Of String)

        Try
            Using conn As New SqlConnection(ConnectionString)
                conn.Open()

                Using cmd As New SqlCommand(
                "SELECT teks_pertanyaan FROM pertanyaan ORDER BY id_pertanyaan", conn)

                    Using rd = cmd.ExecuteReader()
                        While rd.Read()
                            list.Add(rd.GetString(0))
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            MsgBox("Error mengambil pertanyaan: " & ex.Message)
        End Try

        Return list
    End Function
End Module