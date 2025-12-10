Public Class UlasanPage


    Private PanelCard As Panel
    Private lblTitle As Label
    Private TxtUlasan As TextBox
    Private lblUlasanTitle As Label
    Private btnSimpan As Button


    Private Sub UlasanPage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PanelCard = New Panel()
        lblTitle = New Label()
        TxtUlasan = New TextBox()
        lblUlasanTitle = New Label()

        With PanelCard
            .Size = New Size(500, 500)
            .Location = New Point(50, 50)
            .BackColor = Color.LightGray
            .BorderStyle = BorderStyle.FixedSingle
            .Padding = New Padding(20)
            Me.Controls.Add(PanelCard)
        End With

        With lblTitle
            .Text = "Ulasan Pengguna"
            .Font = New Font("Segoe UI", 16, FontStyle.Bold)
            .AutoSize = True
            .Location = New Point(PanelCard.Padding.Left, PanelCard.Padding.Top)
            PanelCard.Controls.Add(lblTitle)
            PanelCard.Padding = New Padding(PanelCard.Padding.Left, PanelCard.Padding.Top + lblTitle.Height + 10, PanelCard.Padding.Right, PanelCard.Padding.Bottom)
        End With

        Dim StarX As Integer = 20
        For i As Integer = 1 To 5
            Dim star As New Label()
            star.Text = "★"
            star.Font = New Font("Segoe UI", 24)
            star.ForeColor = Color.Gold
            star.Location = New Point(StarX, lblTitle.Bottom + 20)

            PanelCard.Controls.Add(star)
            StarX += star.Width + 10
        Next
        With lblUlasanTitle
            .Text = "Tulis Ulasan Anda:"
            .Font = New Font("Segoe UI", 12, FontStyle.Bold)
            .AutoSize = True
            .Location = New Point(PanelCard.Padding.Left, lblTitle.Bottom + 80)
            PanelCard.Controls.Add(lblUlasanTitle)
        End With
        With TxtUlasan
            .Multiline = True
            .Size = New Size(PanelCard.Width - PanelCard.Padding.Left - PanelCard.Padding.Right, 200)
            .Location = New Point(PanelCard.Padding.Left, lblUlasanTitle.Bottom + 10)
            PanelCard.Controls.Add(TxtUlasan)
        End With

        btnSimpan = New Button()
        btnSimpan.Text = "Simpan Ulasan"
        btnSimpan.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnSimpan.Size = New Size(150, 40)
    End Sub
End Class