Imports System.Drawing.Printing
Imports Microsoft.Data.SqlClient
Public Class RiwayatPage
    Private Sub RiwayatPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadRiwayat()
    End Sub
    Private Sub PrintRiwayat()
        Dim pd As New PrintDocument()
        AddHandler pd.PrintPage, AddressOf Me.PrintPageHandler
        Dim Pdi As New PrintPreviewDialog()
        Pdi.Document = pd
        Pdi.ShowDialog()
    End Sub
    Private Sub PrintPageHandler(sender As Object, e As PrintPageEventArgs)
        Dim font As New Font("Segoe UI", 16)
        Dim y As Integer = 20

        ' Looping semua row di DataGridView
        For Each row As DataGridViewRow In dgvRiwayat.Rows
            Dim line As String = String.Format("{0} | {1} | {2} | {3} | {4}",
                                               row.Cells("Tanggal").Value & Environment.NewLine,
                                               row.Cells("Hasil Diagnosa").Value & Environment.NewLine,
                                               row.Cells("Software & Data").Value & Environment.NewLine,
                                               row.Cells("Network").Value & Environment.NewLine,
                                               row.Cells("Creative").Value)
            e.Graphics.DrawString(line, font, Brushes.Black, 20, y)
            y += 20
        Next
    End Sub
    Private Sub LoadRiwayat()
        Try
            dgvRiwayat.DataSource = Nothing
            dgvRiwayat.Rows.Clear()

            If String.IsNullOrWhiteSpace(SessionUser.LoggedUserNIM) Then
                MessageBox.Show("Silakan login terlebih dahulu.")
                Return
            End If

            Using conn As New SqlConnection(DbConnect.ConnectionString)
                conn.Open()

                Dim query As String =
                    "SELECT 
                        tanggal AS [Tanggal],
                        hasil AS [Hasil Diagnosa],
                        nilai_T1 AS [Software & Data],
                        nilai_T2 AS [Network],
                        nilai_T3 AS [Creative]
                     FROM riwayat
                     WHERE nim = @nim
                     ORDER BY tanggal DESC"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nim", SessionUser.LoggedUserNIM)

                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)

                    dgvRiwayat.DataSource = dt
                End Using
            End Using


            dgvRiwayat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            dgvRiwayat.ReadOnly = True
            dgvRiwayat.AllowUserToAddRows = False
            dgvRiwayat.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Catch ex As Exception
            MessageBox.Show("Gagal memuat riwayat: " & ex.Message)
        End Try
    End Sub
    Private Sub LoadRiwayatFiltered()
        Try
            Using conn As New SqlConnection(DbConnect.ConnectionString)
                conn.Open()

                Dim query As String =
                "SELECT tanggal AS [Tanggal], hasil AS [Hasil Diagnosa], 
                        nilai_T1 AS [Software & Data], nilai_T2 AS [Network], nilai_T3 AS [Creative]
                 FROM riwayat
                 WHERE nim = @nim AND CAST(tanggal AS DATE) = @tanggal 
                 ORDER BY tanggal DESC"

                Using cmd As New SqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@nim", SessionUser.LoggedUserNIM)
                    cmd.Parameters.AddWithValue("@tanggal", DateTimePicker1.Value.Date)



                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    dgvRiwayat.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal load riwayat: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Close()
    End Sub

    Private Sub dgvRiwayat_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvRiwayat.CellContentClick

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadRiwayatFiltered()
        PrintRiwayat()
    End Sub
End Class