<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RiwayatPage
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RiwayatPage))
        Label1 = New Label()
        dgvRiwayat = New DataGridView()
        Button1 = New Button()
        PrintPreviewDialog1 = New PrintPreviewDialog()
        PrintDocument1 = New Printing.PrintDocument()
        Button2 = New Button()
        DateTimePicker1 = New DateTimePicker()
        CType(dgvRiwayat, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 14.0F)
        Label1.Location = New Point(539, 44)
        Label1.Name = "Label1"
        Label1.Size = New Size(177, 38)
        Label1.TabIndex = 0
        Label1.Text = "Riwayat Data"
        ' 
        ' dgvRiwayat
        ' 
        dgvRiwayat.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvRiwayat.Location = New Point(179, 111)
        dgvRiwayat.Name = "dgvRiwayat"
        dgvRiwayat.RowHeadersWidth = 62
        dgvRiwayat.Size = New Size(842, 435)
        dgvRiwayat.TabIndex = 1
        ' 
        ' Button1
        ' 
        Button1.Location = New Point(320, 572)
        Button1.Name = "Button1"
        Button1.Size = New Size(197, 34)
        Button1.TabIndex = 2
        Button1.Text = "Kembali ke Home"
        Button1.UseVisualStyleBackColor = True
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
        ' Button2
        ' 
        Button2.Location = New Point(654, 572)
        Button2.Name = "Button2"
        Button2.Size = New Size(197, 34)
        Button2.TabIndex = 3
        Button2.Text = "Print Hasil Riwayat"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' DateTimePicker1
        ' 
        DateTimePicker1.Location = New Point(179, 51)
        DateTimePicker1.Name = "DateTimePicker1"
        DateTimePicker1.Size = New Size(300, 31)
        DateTimePicker1.TabIndex = 4
        ' 
        ' RiwayatPage
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1206, 645)
        Controls.Add(DateTimePicker1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        Controls.Add(dgvRiwayat)
        Controls.Add(Label1)
        Name = "RiwayatPage"
        Text = "RiwayatPage"
        CType(dgvRiwayat, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents dgvRiwayat As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents Button2 As Button
    Friend WithEvents DateTimePicker1 As DateTimePicker
End Class
