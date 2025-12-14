<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LupaPassword
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LupaPassword))
        Label1 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Label4 = New Label()
        TextBox1 = New TextBox()
        TextBox2 = New TextBox()
        TextBox3 = New TextBox()
        Button1 = New Button()
        Button2 = New Button()
        PictureBox1 = New PictureBox()
        Label5 = New Label()
        TextBox4 = New TextBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 12F)
        Label1.Location = New Point(493, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(169, 32)
        Label1.TabIndex = 0
        Label1.Text = "Lupa Password"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(377, 110)
        Label3.Name = "Label3"
        Label3.Size = New Size(100, 25)
        Label3.TabIndex = 9
        Label3.Text = "NIM          :"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(377, 208)
        Label2.Name = "Label2"
        Label2.Size = New Size(101, 25)
        Label2.TabIndex = 10
        Label2.Text = "Password  :"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Location = New Point(377, 296)
        Label4.Name = "Label4"
        Label4.Size = New Size(136, 25)
        Label4.TabIndex = 11
        Label4.Text = "Password Baru :"
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(539, 110)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(240, 31)
        TextBox1.TabIndex = 12
        ' 
        ' TextBox2
        ' 
        TextBox2.Location = New Point(539, 208)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(240, 31)
        TextBox2.TabIndex = 13
        ' 
        ' TextBox3
        ' 
        TextBox3.Location = New Point(539, 293)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(240, 31)
        TextBox3.TabIndex = 14
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(439, 480)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 34)
        Button1.TabIndex = 15
        Button1.Text = "Update"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.Location = New Point(641, 480)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 34)
        Button2.TabIndex = 16
        Button2.Text = "Login"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(-1, -6)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(355, 554)
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox1.TabIndex = 17
        PictureBox1.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Location = New Point(377, 384)
        Label5.Name = "Label5"
        Label5.Size = New Size(151, 25)
        Label5.TabIndex = 18
        Label5.Text = "Ulangi Password :"
        ' 
        ' TextBox4
        ' 
        TextBox4.Location = New Point(539, 384)
        TextBox4.Name = "TextBox4"
        TextBox4.Size = New Size(240, 31)
        TextBox4.TabIndex = 19
        ' 
        ' LupaPassword
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(800, 548)
        Controls.Add(TextBox4)
        Controls.Add(Label5)
        Controls.Add(PictureBox1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(TextBox3)
        Controls.Add(TextBox2)
        Controls.Add(TextBox1)
        Controls.Add(Label4)
        Controls.Add(Label2)
        Controls.Add(Label3)
        Controls.Add(Label1)
        Name = "LupaPassword"
        Text = "LupaPassword"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox3 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox4 As TextBox
End Class
