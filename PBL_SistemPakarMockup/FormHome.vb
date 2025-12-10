Public Class FormHome


    Private Sub FormHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tampilkan nama user ke Label3
        LabelNama.Text = "User :" & LoggedUserNama
        LabelProdi.Text = "Prodi :" & LoggedUserProdi
        Me.IsMdiContainer = True
    End Sub
    Private Sub LoadChildForm(child As Form)
        ' Tutup child sebelumnya (opsional)
        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next

        child.MdiParent = Me
        child.FormBorderStyle = FormBorderStyle.None
        child.Dock = DockStyle.Fill
        child.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadChildForm(New FormQuiz())
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        LoadChildForm(New UlasanPage())
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        LoadChildForm(New RiwayatPage())
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub
End Class
