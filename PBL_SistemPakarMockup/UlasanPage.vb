Imports Microsoft.Data.SqlClient
Imports System.Drawing

Public Class UlasanPage
    Inherits Form

    Private PanelCard As Panel
    Private lblTitle As Label
    Private TxtUlasan As TextBox
    Private lblUlasanTitle As Label
    Private btnSimpan As Button
    Private dgvUlasan As DataGridView

    Private ratingSelected As Integer = 0
    Private starLabels As New List(Of Label)
    Private editId As Integer = -1

    Public Sub New()
        InitializeUI()
        LoadUlasan()
    End Sub
    ' ===================== Initialize UI =====================
    Private Sub InitializeUI()
        Me.Controls.Clear()
        starLabels.Clear()
        ratingSelected = 0
        editId = -1

        ' Panel Card
        PanelCard = New Panel()
        PanelCard.Size = New Size(500, 500)
        PanelCard.Location = New Point(50, 20)
        PanelCard.BackColor = Color.LightGray
        PanelCard.BorderStyle = BorderStyle.FixedSingle
        PanelCard.Padding = New Padding(20)
        Me.Controls.Add(PanelCard)

        ' Judul
        lblTitle = New Label()
        lblTitle.Text = "Ulasan Pengguna"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(PanelCard.Padding.Left, PanelCard.Padding.Top)
        PanelCard.Controls.Add(lblTitle)

        ' Bintang interaktif
        CreateStars()

        ' Label Ulasan
        lblUlasanTitle = New Label()
        lblUlasanTitle.Text = "Tulis Ulasan Anda:"
        lblUlasanTitle.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblUlasanTitle.AutoSize = True
        lblUlasanTitle.Location = New Point(PanelCard.Padding.Left, lblTitle.Bottom + 80)
        PanelCard.Controls.Add(lblUlasanTitle)

        ' TextBox Ulasan
        TxtUlasan = New TextBox()
        TxtUlasan.Multiline = True
        TxtUlasan.Size = New Size(PanelCard.Width - PanelCard.Padding.Left - PanelCard.Padding.Right, 200)
        TxtUlasan.Location = New Point(PanelCard.Padding.Left, lblUlasanTitle.Bottom + 10)
        PanelCard.Controls.Add(TxtUlasan)

        ' Tombol Simpan
        btnSimpan = New Button()
        btnSimpan.Text = "Simpan Ulasan"
        btnSimpan.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnSimpan.Size = New Size(150, 40)
        btnSimpan.Location = New Point(PanelCard.Padding.Left, TxtUlasan.Bottom + 20)
        AddHandler btnSimpan.Click, AddressOf BtnSimpan_Click
        PanelCard.Controls.Add(btnSimpan)

        ' DataGridView
        dgvUlasan = New DataGridView()
        dgvUlasan.Size = New Size(PanelCard.Width, 200)
        dgvUlasan.Location = New Point(PanelCard.Left, PanelCard.Bottom + 20)
        dgvUlasan.ReadOnly = True
        dgvUlasan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvUlasan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        AddHandler dgvUlasan.CellClick, AddressOf dgvUlasan_CellClick
        Me.Controls.Add(dgvUlasan)
    End Sub

    ' ===================== Bintang =====================
    Private Sub CreateStars()
        Dim StarX As Integer = 20
        For i As Integer = 1 To 5
            Dim star As New Label()
            star.Text = "★"
            star.Font = New Font("Segoe UI", 24)
            star.ForeColor = Color.Gray
            star.Tag = i
            star.Cursor = Cursors.Hand
            star.Location = New Point(StarX, lblTitle.Bottom + 20)
            AddHandler star.Click, AddressOf Star_Click
            PanelCard.Controls.Add(star)
            starLabels.Add(star)
            StarX += star.Width + 10
        Next
    End Sub

    Private Sub Star_Click(sender As Object, e As EventArgs)
        Dim clickedStar As Label = CType(sender, Label)
        ratingSelected = CInt(clickedStar.Tag)
        HighlightStars(ratingSelected)
    End Sub

    Private Sub HighlightStars(count As Integer)
        For Each star In starLabels
            Dim starNum As Integer = CInt(star.Tag)
            star.ForeColor = If(starNum <= count, Color.Gold, Color.Gray)
        Next
    End Sub

    Private Function GetRatingFromStars() As Integer
        Return ratingSelected
    End Function

    ' ===================== CRUD =====================
    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs)
        Dim isi As String = TxtUlasan.Text.Trim()
        Dim rating As Integer = GetRatingFromStars()

        If isi = "" Then
            MessageBox.Show("Ulasan tidak boleh kosong.")
            Return
        End If

        Try
            Using conn As New SqlConnection(DbConnect.ConnectionString)
                conn.Open()
                Dim sql As String
                If editId = -1 Then
                    sql = "INSERT INTO ulasan (nim, isiUlasan, rating) VALUES (@nim, @isi, @rating)"
                Else
                    sql = "UPDATE ulasan SET isiUlasan=@isi, rating=@rating WHERE idUlasan=@id"
                End If
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nim", SessionUser.LoggedUserNIM)
                    cmd.Parameters.AddWithValue("@isi", isi)
                    cmd.Parameters.AddWithValue("@rating", rating)
                    If editId <> -1 Then cmd.Parameters.AddWithValue("@id", editId)
                    cmd.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Ulasan berhasil disimpan!")
            TxtUlasan.Clear()
            ratingSelected = 0
            HighlightStars(0)
            editId = -1

            LoadUlasan()
        Catch ex As Exception
            MessageBox.Show("Gagal menyimpan ulasan: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadUlasan()
        Try
            Using conn As New SqlConnection(DbConnect.ConnectionString)
                conn.Open()
                Dim sql As String = "SELECT idUlasan, isiUlasan, rating, tanggal FROM ulasan WHERE nim=@nim ORDER BY tanggal DESC"
                Using cmd As New SqlCommand(sql, conn)
                    cmd.Parameters.AddWithValue("@nim", SessionUser.LoggedUserNIM)
                    Dim dt As New DataTable()
                    Dim da As New SqlDataAdapter(cmd)
                    da.Fill(dt)
                    dgvUlasan.DataSource = dt
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Gagal memuat ulasan: " & ex.Message)
        End Try
    End Sub

    Private Sub dgvUlasan_CellClick(sender As Object, e As DataGridViewCellEventArgs)
        If e.RowIndex >= 0 Then
            Dim row = dgvUlasan.Rows(e.RowIndex)
            editId = CInt(row.Cells("idUlasan").Value)
            TxtUlasan.Text = row.Cells("isiUlasan").Value.ToString()
            ratingSelected = CInt(row.Cells("rating").Value)
            HighlightStars(ratingSelected)
        End If
    End Sub

    ' ===================== Delete =====================
    Public Sub DeleteSelected()
        If dgvUlasan.SelectedRows.Count = 0 Then Return
        Dim id As Integer = CInt(dgvUlasan.SelectedRows(0).Cells("idUlasan").Value)

        If MessageBox.Show("Hapus ulasan ini?", "Konfirmasi", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                Using conn As New SqlConnection(DbConnect.ConnectionString)
                    conn.Open()
                    Using cmd As New SqlCommand("DELETE FROM ulasan WHERE idUlasan=@id", conn)
                        cmd.Parameters.AddWithValue("@id", id)
                        cmd.ExecuteNonQuery()
                    End Using
                End Using
                LoadUlasan()
            Catch ex As Exception
                MessageBox.Show("Gagal menghapus ulasan: " & ex.Message)
            End Try
        End If
    End Sub
End Class
