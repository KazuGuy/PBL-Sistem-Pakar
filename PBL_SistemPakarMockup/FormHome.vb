Public Class FormHome
    Inherits Form
    Private currentChild As Form = Nothing
    ' =========================
    ' FORM LOAD
    ' =========================
    Private Sub FormHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Info user
        LabelNama.Text = "User :   " & LoggedUserNama
        LabelProdi.Text = "Prodi :   " & LoggedUserProdi
        LabelWelcome.Visible = True
        PanelContent.Visible = False


        ' DPI aman (opsi 1)
        Me.AutoScaleMode = AutoScaleMode.None

        ' MDI setup
        Me.IsMdiContainer = True

        ' Ubah background MDI jadi putih
        For Each ctrl As Control In Me.Controls
            If TypeOf ctrl Is MdiClient Then
                ctrl.BackColor = Color.White
                Exit For
            End If
        Next
    End Sub


    Private Sub FormHome_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CenterWelcomeLabel()
    End Sub

    Private Sub FormHome_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        CenterWelcomeLabel()
    End Sub


    Private Sub CenterWelcomeLabel()
        If LabelWelcome Is Nothing OrElse Not LabelWelcome.Visible Then Exit Sub

        LabelWelcome.AutoSize = False
        LabelWelcome.Width = Me.ClientSize.Width
        LabelWelcome.Height = 60

        LabelWelcome.Left = 0
        LabelWelcome.Top =
    (Me.ClientSize.Height \ 2) - LabelWelcome.Height - 100


        LabelWelcome.TextAlign = ContentAlignment.MiddleCenter
    End Sub


    Public Sub LoadChildForm(child As Form)
        ' Tutup child sebelumnya jika ada
        If currentChild IsNot Nothing Then
            RemoveHandler currentChild.FormClosed, AddressOf ChildFormClosed
            currentChild.Close()
        End If

        currentChild = child
        AddHandler currentChild.FormClosed, AddressOf ChildFormClosed

        ' Hide welcome
        LabelWelcome.Visible = False
        PanelContent.Controls.Clear()
        PanelContent.Visible = True

        ' Set child properties agar tampil di panel
        child.TopLevel = False
        child.FormBorderStyle = FormBorderStyle.None
        child.Dock = DockStyle.Fill

        PanelContent.Controls.Add(child)
        child.Show()
    End Sub
    Private Sub ChildFormClosed(sender As Object, e As FormClosedEventArgs)
        currentChild = Nothing
        ' Tampilkan kembali welcome
        LabelWelcome.Visible = True
        PanelContent.Visible = False
    End Sub
    ' =========================
    ' BUTTON EVENTS
    ' =========================
    Private Sub ButtonMulai_Click(sender As Object, e As EventArgs) Handles ButtonMulai.Click
        LoadChildForm(New FormQuiz())
    End Sub

    Private Sub ButtonUlasan_Click(sender As Object, e As EventArgs) Handles ButtonUlasan.Click
        LoadChildForm(New UlasanPage())
    End Sub

    Private Sub ButtonRiwayat_Click(sender As Object, e As EventArgs) Handles ButtonRiwayat.Click
        LoadChildForm(New RiwayatPage())
    End Sub

    Private Sub ButtonLogout_Click(sender As Object, e As EventArgs) Handles ButtonLogout.Click
        ClearSession()

        For Each frm As Form In Me.MdiChildren
            frm.Close()
        Next

        Dim loginForm As New Login()
        loginForm.Show()
        Me.Close()
    End Sub

End Class
