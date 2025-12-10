Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class QuestionControl
    Inherits UserControl

    Private lblTitle As Label
    Private pnlDivider As Panel
    Private lblQuestion As Label

    Private flowScale As FlowLayoutPanel
    Private scaleButtons As New List(Of RadioButton)

    Public Sub New()

        Me.BackColor = Color.White
        Me.Width = 820
        Me.Height = 260

        BuildTitle()
        BuildDivider()
        BuildQuestionLabel()
        BuildScaleButtons()
    End Sub

    Private Sub BuildTitle()
        lblTitle = New Label()
        lblTitle.Text = "Pertanyaan"
        lblTitle.Font = New Font("Segoe UI", 16, FontStyle.Bold)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(20, 10)
        lblTitle.ForeColor = Color.Black

        Me.Controls.Add(lblTitle)
    End Sub

    Private Sub BuildDivider()
        pnlDivider = New Panel()
        pnlDivider.Width = 760
        pnlDivider.Height = 2
        pnlDivider.BackColor = Color.LightGray
        pnlDivider.Location = New Point(20, 50)

        Me.Controls.Add(pnlDivider)
    End Sub

    Private Sub BuildQuestionLabel()
        lblQuestion = New Label()
        lblQuestion.Text = "Teks pertanyaan muncul di sini..."
        lblQuestion.Font = New Font("Segoe UI", 12)
        lblQuestion.AutoSize = False
        lblQuestion.Size = New Size(760, 60)
        lblQuestion.Location = New Point(20, 70)
        lblQuestion.ForeColor = Color.Black

        Me.Controls.Add(lblQuestion)
    End Sub

    Private Sub BuildScaleButtons()

        flowScale = New FlowLayoutPanel()
        flowScale.Location = New Point(20, 140)
        flowScale.Size = New Size(760, 75)
        flowScale.FlowDirection = FlowDirection.LeftToRight
        flowScale.WrapContents = False

        Me.Controls.Add(flowScale)

        For i As Integer = 1 To 5
            Dim rb As New RadioButton()

            rb.Text = i.ToString()
            rb.Appearance = Appearance.Button
            rb.TextAlign = ContentAlignment.MiddleCenter
            rb.Font = New Font("Segoe UI", 14, FontStyle.Bold)

            rb.Size = New Size(65, 65)
            rb.FlatStyle = FlatStyle.Flat
            rb.FlatAppearance.BorderSize = 2
            rb.FlatAppearance.BorderColor = Color.Gray

            rb.BackColor = Color.White
            rb.Margin = New Padding(10)

            AddHandler rb.MouseEnter, AddressOf ScaleHover
            AddHandler rb.MouseLeave, AddressOf ScaleLeave
            AddHandler rb.CheckedChanged, AddressOf ScaleChecked

            scaleButtons.Add(rb)
            flowScale.Controls.Add(rb)
        Next

    End Sub
    Private Sub ScaleChecked(sender As Object, e As EventArgs)
        For Each rb In scaleButtons
            rb.BackColor = Color.White
            rb.FlatAppearance.BorderColor = Color.Gray
        Next

        Dim btn As RadioButton = CType(sender, RadioButton)
        If btn.Checked Then
            btn.BackColor = Color.LightSkyBlue
            btn.FlatAppearance.BorderColor = Color.DeepSkyBlue
        End If
    End Sub

    Private Sub ScaleHover(sender As Object, e As EventArgs)
        Dim rb As RadioButton = CType(sender, RadioButton)
        If Not rb.Checked Then rb.BackColor = Color.AliceBlue
    End Sub

    Private Sub ScaleLeave(sender As Object, e As EventArgs)
        Dim rb As RadioButton = CType(sender, RadioButton)
        If Not rb.Checked Then rb.BackColor = Color.White
    End Sub


    ' ================================================================
    ' 6. PUBLIC PROPERTIES
    ' ================================================================
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property QuestionTitle As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property

    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property QuestionText As String
        Get
            Return lblQuestion.Text
        End Get
        Set(value As String)
            lblQuestion.Text = value
        End Set
    End Property


    ' ================================================================
    ' 7. NILAI YANG DIPILIH
    ' ================================================================
    Public ReadOnly Property SelectedScore As Integer
        Get
            For Each rb In scaleButtons
                If rb.Checked Then
                    Return CInt(rb.Text)
                End If
            Next
            Return 0
        End Get
    End Property


    ' ================================================================
    ' 8. RESET & SET SCORE
    ' ================================================================
    Public Sub ResetSelection()
        For Each rb In scaleButtons
            rb.Checked = False
            rb.BackColor = Color.White
        Next
    End Sub


    Public Sub SetScore(score As Integer)
        If score < 1 Or score > 5 Then Exit Sub

        ' Reset dulu
        For Each rb In scaleButtons
            rb.Checked = False
            rb.BackColor = Color.White
            rb.FlatAppearance.BorderColor = Color.Gray
        Next

        Dim index As Integer = score - 1
        Dim selected As RadioButton = scaleButtons(index)

        selected.Checked = True
        selected.BackColor = Color.LightSkyBlue
        selected.FlatAppearance.BorderColor = Color.DeepSkyBlue
    End Sub

End Class
