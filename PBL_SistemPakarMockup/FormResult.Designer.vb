<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormResult
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormResult))
        lblHasil = New Label()
        lblDeskripsi = New Label()
        lblSkorT1 = New Label()
        lblSkorT2 = New Label()
        lblSkorT3 = New Label()
        lblSkorP4 = New Label()
        lblSkorP5 = New Label()
        lblSkorP6 = New Label()
        btnHome = New Button()
        pbT1 = New ProgressBar()
        pbT2 = New ProgressBar()
        pbT3 = New ProgressBar()
        pbP4 = New ProgressBar()
        pbP5 = New ProgressBar()
        pbP6 = New ProgressBar()
        btnPrintPreview = New Button()
        SqlCommand1 = New Microsoft.Data.SqlClient.SqlCommand()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        PrintDocument1 = New Printing.PrintDocument()
        SuspendLayout()
        ' 
        ' lblHasil
        ' 
        lblHasil.AutoSize = True
        lblHasil.Font = New Font("Segoe UI Black", 13.8461533F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        lblHasil.Location = New Point(25, 36)
        lblHasil.Name = "lblHasil"
        lblHasil.Size = New Size(105, 38)
        lblHasil.TabIndex = 0
        lblHasil.Text = "Label1"
        ' 
        ' lblDeskripsi
        ' 
        lblDeskripsi.AutoSize = True
        lblDeskripsi.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblDeskripsi.Location = New Point(36, 134)
        lblDeskripsi.Name = "lblDeskripsi"
        lblDeskripsi.Size = New Size(63, 25)
        lblDeskripsi.TabIndex = 1
        lblDeskripsi.Text = "Label2"
        ' 
        ' lblSkorT1
        ' 
        lblSkorT1.AutoSize = True
        lblSkorT1.Font = New Font("Segoe UI", 11.0769234F)
        lblSkorT1.Location = New Point(49, 236)
        lblSkorT1.Name = "lblSkorT1"
        lblSkorT1.Size = New Size(81, 31)
        lblSkorT1.TabIndex = 2
        lblSkorT1.Text = "Label3"
        ' 
        ' lblSkorT2
        ' 
        lblSkorT2.AutoSize = True
        lblSkorT2.Font = New Font("Segoe UI", 11.0769234F)
        lblSkorT2.Location = New Point(371, 236)
        lblSkorT2.Name = "lblSkorT2"
        lblSkorT2.Size = New Size(81, 31)
        lblSkorT2.TabIndex = 3
        lblSkorT2.Text = "Label4"
        ' 
        ' lblSkorT3
        ' 
        lblSkorT3.AutoSize = True
        lblSkorT3.Font = New Font("Segoe UI", 11.0769234F)
        lblSkorT3.Location = New Point(49, 509)
        lblSkorT3.Name = "lblSkorT3"
        lblSkorT3.Size = New Size(81, 31)
        lblSkorT3.TabIndex = 4
        lblSkorT3.Text = "Label5"
        ' 
        ' lblSkorP4
        ' 
        lblSkorP4.AutoSize = True
        lblSkorP4.Font = New Font("Segoe UI", 11.0769234F)
        lblSkorP4.Location = New Point(49, 384)
        lblSkorP4.Name = "lblSkorP4"
        lblSkorP4.Size = New Size(81, 31)
        lblSkorP4.TabIndex = 5
        lblSkorP4.Text = "Label6"
        ' 
        ' lblSkorP5
        ' 
        lblSkorP5.AutoSize = True
        lblSkorP5.Font = New Font("Segoe UI", 11.0769234F)
        lblSkorP5.Location = New Point(371, 384)
        lblSkorP5.Name = "lblSkorP5"
        lblSkorP5.Size = New Size(81, 31)
        lblSkorP5.TabIndex = 6
        lblSkorP5.Text = "Label7"
        ' 
        ' lblSkorP6
        ' 
        lblSkorP6.AutoSize = True
        lblSkorP6.Font = New Font("Segoe UI", 11.0769234F)
        lblSkorP6.Location = New Point(371, 509)
        lblSkorP6.Name = "lblSkorP6"
        lblSkorP6.Size = New Size(81, 31)
        lblSkorP6.TabIndex = 7
        lblSkorP6.Text = "Label8"
        ' 
        ' btnHome
        ' 
        btnHome.Location = New Point(762, 562)
        btnHome.Name = "btnHome"
        btnHome.Size = New Size(151, 51)
        btnHome.TabIndex = 8
        btnHome.Text = "Go to Home Page"
        btnHome.UseVisualStyleBackColor = True
        ' 
        ' pbT1
        ' 
        pbT1.Location = New Point(49, 302)
        pbT1.Name = "pbT1"
        pbT1.Size = New Size(170, 31)
        pbT1.TabIndex = 9
        ' 
        ' pbT2
        ' 
        pbT2.Location = New Point(371, 302)
        pbT2.Name = "pbT2"
        pbT2.Size = New Size(170, 31)
        pbT2.TabIndex = 10
        ' 
        ' pbT3
        ' 
        pbT3.Location = New Point(49, 582)
        pbT3.Name = "pbT3"
        pbT3.Size = New Size(170, 31)
        pbT3.TabIndex = 11
        ' 
        ' pbP4
        ' 
        pbP4.Location = New Point(49, 451)
        pbP4.Name = "pbP4"
        pbP4.Size = New Size(170, 31)
        pbP4.TabIndex = 12
        ' 
        ' pbP5
        ' 
        pbP5.Location = New Point(371, 451)
        pbP5.Name = "pbP5"
        pbP5.Size = New Size(170, 31)
        pbP5.TabIndex = 13
        ' 
        ' pbP6
        ' 
        pbP6.Location = New Point(371, 582)
        pbP6.Name = "pbP6"
        pbP6.Size = New Size(170, 31)
        pbP6.TabIndex = 14
        ' 
        ' btnPrintPreview
        ' 
        btnPrintPreview.Location = New Point(1010, 562)
        btnPrintPreview.Name = "btnPrintPreview"
        btnPrintPreview.Size = New Size(151, 51)
        btnPrintPreview.TabIndex = 15
        btnPrintPreview.Text = "Print Docs"
        btnPrintPreview.UseVisualStyleBackColor = True
        ' 
        ' SqlCommand1
        ' 
        SqlCommand1.CommandTimeout = 30
        SqlCommand1.EnableOptimizedParameterBinding = False
        ' 
        ' PrintPreviewDialog1
        ' 
        PrintPreviewDialog1.AutoScrollMargin = New Size(0, 0)
        PrintPreviewDialog1.AutoScrollMinSize = New Size(0, 0)
        PrintPreviewDialog1.ClientSize = New Size(400, 300)
        PrintPreviewDialog1.Enabled = True
        PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), Icon)
        PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        PrintPreviewDialog1.Visible = False
        ' 
        ' FormResult
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1294, 873)
        Controls.Add(btnPrintPreview)
        Controls.Add(pbP6)
        Controls.Add(pbP5)
        Controls.Add(pbP4)
        Controls.Add(pbT3)
        Controls.Add(pbT2)
        Controls.Add(pbT1)
        Controls.Add(btnHome)
        Controls.Add(lblSkorP6)
        Controls.Add(lblSkorP5)
        Controls.Add(lblSkorP4)
        Controls.Add(lblSkorT3)
        Controls.Add(lblSkorT2)
        Controls.Add(lblSkorT1)
        Controls.Add(lblDeskripsi)
        Controls.Add(lblHasil)
        Name = "FormResult"
        Text = "FormResult"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblHasil As Label
    Friend WithEvents lblDeskripsi As Label
    Friend WithEvents lblSkorT1 As Label
    Friend WithEvents lblSkorT2 As Label
    Friend WithEvents lblSkorT3 As Label
    Friend WithEvents lblSkorP4 As Label
    Friend WithEvents lblSkorP5 As Label
    Friend WithEvents lblSkorP6 As Label
    Friend WithEvents btnHome As Button
    Friend WithEvents pbT1 As ProgressBar
    Friend WithEvents pbT2 As ProgressBar
    Friend WithEvents pbT3 As ProgressBar
    Friend WithEvents pbP4 As ProgressBar
    Friend WithEvents pbP5 As ProgressBar
    Friend WithEvents pbP6 As ProgressBar
    Friend WithEvents btnPrintPreview As Button
    Friend WithEvents SqlCommand1 As Microsoft.Data.SqlClient.SqlCommand
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
End Class
