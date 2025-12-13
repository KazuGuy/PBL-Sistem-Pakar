<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormHome
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        MenuStrip1 = New MenuStrip()
        MenuToolStripMenuItem = New ToolStripMenuItem()
        RiwayatToolStripMenuItem = New ToolStripMenuItem()
        UlasanToolStripMenuItem = New ToolStripMenuItem()
        HelpToolStripMenuItem = New ToolStripMenuItem()
        AboutToolStripMenuItem = New ToolStripMenuItem()
        LabelNama = New Label()
        LabelProdi = New Label()
        LabelWelcome = New Label()
        ButtonMulai = New Button()
        ButtonUlasan = New Button()
        ButtonRiwayat = New Button()
        ButtonLogout = New Button()
        PanelContent = New Panel()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {MenuToolStripMenuItem, RiwayatToolStripMenuItem, UlasanToolStripMenuItem, HelpToolStripMenuItem, AboutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(1264, 29)
        MenuStrip1.TabIndex = 0
        ' 
        ' MenuToolStripMenuItem
        ' 
        MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        MenuToolStripMenuItem.Size = New Size(64, 26)
        MenuToolStripMenuItem.Text = "Menu"
        ' 
        ' RiwayatToolStripMenuItem
        ' 
        RiwayatToolStripMenuItem.Name = "RiwayatToolStripMenuItem"
        RiwayatToolStripMenuItem.Size = New Size(79, 26)
        RiwayatToolStripMenuItem.Text = "Riwayat"
        ' 
        ' UlasanToolStripMenuItem
        ' 
        UlasanToolStripMenuItem.Name = "UlasanToolStripMenuItem"
        UlasanToolStripMenuItem.Size = New Size(71, 26)
        UlasanToolStripMenuItem.Text = "Ulasan"
        ' 
        ' HelpToolStripMenuItem
        ' 
        HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        HelpToolStripMenuItem.Size = New Size(56, 26)
        HelpToolStripMenuItem.Text = "Help"
        ' 
        ' AboutToolStripMenuItem
        ' 
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        AboutToolStripMenuItem.Size = New Size(66, 26)
        AboutToolStripMenuItem.Text = "About"
        ' 
        ' LabelNama
        ' 
        LabelNama.AutoSize = True
        LabelNama.Font = New Font("Segoe UI", 12F)
        LabelNama.Location = New Point(20, 50)
        LabelNama.Name = "LabelNama"
        LabelNama.Size = New Size(68, 30)
        LabelNama.TabIndex = 7
        LabelNama.Text = "User :"
        ' 
        ' LabelProdi
        ' 
        LabelProdi.AutoSize = True
        LabelProdi.Font = New Font("Segoe UI", 12F)
        LabelProdi.Location = New Point(20, 90)
        LabelProdi.Name = "LabelProdi"
        LabelProdi.Size = New Size(75, 30)
        LabelProdi.TabIndex = 6
        LabelProdi.Text = "Prodi :"
        ' 
        ' LabelWelcome
        ' 
        LabelWelcome.AutoSize = True
        LabelWelcome.Font = New Font("Segoe UI", 28F, FontStyle.Bold)
        LabelWelcome.Location = New Point(380, 130)
        LabelWelcome.Name = "LabelWelcome"
        LabelWelcome.Size = New Size(410, 68)
        LabelWelcome.TabIndex = 5
        LabelWelcome.Text = "Selamat Datang"
        ' 
        ' ButtonMulai
        ' 
        ButtonMulai.Location = New Point(530, 260)
        ButtonMulai.Name = "ButtonMulai"
        ButtonMulai.Size = New Size(200, 45)
        ButtonMulai.TabIndex = 4
        ButtonMulai.Text = "Mulai"
        ' 
        ' ButtonUlasan
        ' 
        ButtonUlasan.Location = New Point(530, 330)
        ButtonUlasan.Name = "ButtonUlasan"
        ButtonUlasan.Size = New Size(200, 45)
        ButtonUlasan.TabIndex = 3
        ButtonUlasan.Text = "Ulasan"
        ' 
        ' ButtonRiwayat
        ' 
        ButtonRiwayat.Location = New Point(530, 400)
        ButtonRiwayat.Name = "ButtonRiwayat"
        ButtonRiwayat.Size = New Size(200, 45)
        ButtonRiwayat.TabIndex = 2
        ButtonRiwayat.Text = "Riwayat"
        ' 
        ' ButtonLogout
        ' 
        ButtonLogout.Location = New Point(530, 470)
        ButtonLogout.Name = "ButtonLogout"
        ButtonLogout.Size = New Size(200, 45)
        ButtonLogout.TabIndex = 1
        ButtonLogout.Text = "Logout"
        ' 
        ' PanelContent
        ' 
        PanelContent.BackColor = Color.WhiteSmoke
        PanelContent.Dock = DockStyle.Fill
        PanelContent.Location = New Point(0, 29)
        PanelContent.Name = "PanelContent"
        PanelContent.Size = New Size(1264, 697)
        PanelContent.TabIndex = 0
        PanelContent.Visible = False
        ' 
        ' FormHome
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1264, 726)
        Controls.Add(PanelContent)
        Controls.Add(ButtonLogout)
        Controls.Add(ButtonRiwayat)
        Controls.Add(ButtonUlasan)
        Controls.Add(ButtonMulai)
        Controls.Add(LabelWelcome)
        Controls.Add(LabelProdi)
        Controls.Add(LabelNama)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "FormHome"
        Text = "Home"
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents MenuToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents RiwayatToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents UlasanToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents HelpToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As ToolStripMenuItem

    Friend WithEvents LabelNama As Label
    Friend WithEvents LabelProdi As Label
    Friend WithEvents LabelWelcome As Label

    Friend WithEvents ButtonMulai As Button
    Friend WithEvents ButtonUlasan As Button
    Friend WithEvents ButtonRiwayat As Button
    Friend WithEvents ButtonLogout As Button

    Friend WithEvents PanelContent As Panel

End Class
