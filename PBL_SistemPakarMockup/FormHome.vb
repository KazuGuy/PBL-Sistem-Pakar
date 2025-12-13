Public Class FormHome


    Private Sub FormHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tampilkan nama user ke Label3
        LabelNama.Text = "User :" & LoggedUserNama
        LabelProdi.Text = "Prodi :" & LoggedUserProdi
        Me.IsMdiContainer = True
    End Sub
    Private Sub LoadChildForm(child As Form)

        PanelContent.Controls.Clear()
        PanelContent.Visible = True

        child.TopLevel = False
        child.FormBorderStyle = FormBorderStyle.None
        child.Dock = DockStyle.Fill

        PanelContent.Controls.Add(child)
        child.Show()
    End Sub


    Private Sub ButtonMulai_Click(sender As Object, e As EventArgs) Handles ButtonMulai.Click
        LoadChildForm(New FormQuiz())
        'Me.Close() 'niatnya mau ditutup biar ga numpuk formnya
    End Sub

    Private Sub ButtonUlasan_Click(sender As Object, e As EventArgs) Handles ButtonUlasan.Click
        LoadChildForm(New UlasanPage())
    End Sub

    Private Sub ButtonRiwayat_Click(sender As Object, e As EventArgs) Handles ButtonRiwayat.Click
        LoadChildForm(New RiwayatPage())
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles ButtonLogout.Click
        ClearSession()
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub PanelContent_Paint(sender As Object, e As PaintEventArgs) Handles PanelContent.Paint

    End Sub
End Class
