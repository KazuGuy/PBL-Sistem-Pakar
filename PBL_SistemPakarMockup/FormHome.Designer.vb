<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        MenuStrip1 = New MenuStrip()
        MenuToolStripMenuItem = New ToolStripMenuItem()
        RiwayatToolStripMenuItem = New ToolStripMenuItem()
        UlasanToolStripMenuItem = New ToolStripMenuItem()
        HelpToolStripMenuItem = New ToolStripMenuItem()
        AboutToolStripMenuItem = New ToolStripMenuItem()
        NotifyIcon1 = New NotifyIcon(components)
        Label1 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        Button2 = New Button()
        Button4 = New Button()
        Button3 = New Button()
        LabelNama = New Label()
        LabelProdi = New Label()
        MenuStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.ImageScalingSize = New Size(24, 24)
        MenuStrip1.Items.AddRange(New ToolStripItem() {MenuToolStripMenuItem, RiwayatToolStripMenuItem, UlasanToolStripMenuItem, HelpToolStripMenuItem, AboutToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.RenderMode = ToolStripRenderMode.Professional
        MenuStrip1.Size = New Size(1264, 33)
        MenuStrip1.TabIndex = 0
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' MenuToolStripMenuItem
        ' 
        MenuToolStripMenuItem.Name = "MenuToolStripMenuItem"
        MenuToolStripMenuItem.Size = New Size(73, 29)
        MenuToolStripMenuItem.Text = "Menu"
        ' 
        ' RiwayatToolStripMenuItem
        ' 
        RiwayatToolStripMenuItem.Name = "RiwayatToolStripMenuItem"
        RiwayatToolStripMenuItem.Size = New Size(89, 29)
        RiwayatToolStripMenuItem.Text = "Riwayat"
        ' 
        ' UlasanToolStripMenuItem
        ' 
        UlasanToolStripMenuItem.Name = "UlasanToolStripMenuItem"
        UlasanToolStripMenuItem.Size = New Size(80, 29)
        UlasanToolStripMenuItem.Text = "Ulasan"
        ' 
        ' HelpToolStripMenuItem
        ' 
        HelpToolStripMenuItem.Name = "HelpToolStripMenuItem"
        HelpToolStripMenuItem.Size = New Size(65, 29)
        HelpToolStripMenuItem.Text = "Help"
        ' 
        ' AboutToolStripMenuItem
        ' 
        AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        AboutToolStripMenuItem.Size = New Size(78, 29)
        AboutToolStripMenuItem.Text = "About"
        ' 
        ' NotifyIcon1
        ' 
        NotifyIcon1.Text = "NotifyIcon1"
        NotifyIcon1.Visible = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(384, 97)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 25)
        Label1.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 24.0F)
        Label2.Location = New Point(458, 167)
        Label2.Name = "Label2"
        Label2.Size = New Size(375, 65)
        Label2.TabIndex = 2
        Label2.Text = "Selamat Datang "
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(556, 276)
        Button1.Name = "Button1"
        Button1.Size = New Size(167, 46)
        Button1.TabIndex = 3
        Button1.Text = "Mulai"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(556, 391)
        Button2.Name = "Button2"
        Button2.Size = New Size(167, 46)
        Button2.TabIndex = 4
        Button2.Text = "Ulasan"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button4
        ' 
        Button4.Location = New Point(556, 613)
        Button4.Name = "Button4"
        Button4.Size = New Size(167, 46)
        Button4.TabIndex = 6
        Button4.Text = "Logout"
        Button4.UseVisualStyleBackColor = True
        ' 
        ' Button3
        ' 
        Button3.Location = New Point(556, 509)
        Button3.Name = "Button3"
        Button3.Size = New Size(167, 46)
        Button3.TabIndex = 5
        Button3.Text = "Riwayat"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' LabelNama
        ' 
        LabelNama.AutoSize = True
        LabelNama.BackColor = Color.Transparent
        LabelNama.Font = New Font("Segoe UI", 12.0F)
        LabelNama.Location = New Point(34, 44)
        LabelNama.Name = "LabelNama"
        LabelNama.Size = New Size(80, 32)
        LabelNama.TabIndex = 7
        LabelNama.Text = "User  :"
        ' 
        ' LabelProdi
        ' 
        LabelProdi.AutoSize = True
        LabelProdi.Font = New Font("Segoe UI", 12.0F)
        LabelProdi.Location = New Point(34, 97)
        LabelProdi.Name = "LabelProdi"
        LabelProdi.Size = New Size(81, 32)
        LabelProdi.TabIndex = 8
        LabelProdi.Text = "Prodi :"
        ' 
        ' FormHome
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1264, 726)
        Controls.Add(LabelProdi)
        Controls.Add(LabelNama)
        Controls.Add(Button4)
        Controls.Add(Button3)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(MenuStrip1)
        MainMenuStrip = MenuStrip1
        Name = "FormHome"
        Text = "Form1"
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
    Friend WithEvents NotifyIcon1 As NotifyIcon
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents LabelNama As Label
    Friend WithEvents LabelProdi As Label

End Class
