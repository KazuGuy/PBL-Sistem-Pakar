Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class QuestionControl
    Inherits UserControl

    Private lblTitle As Label
    Private pnlDivider As Panel
    Private lblQuestion As Label

    Private pnlContainer As Panel
    Private flowDescriptions As FlowLayoutPanel
    Private flowButtons As FlowLayoutPanel

    Private scaleButtons As New List(Of RadioButton)

    Public Sub New()
        Me.BackColor = Color.Transparent
        Me.Width = 820
        Me.Height = 260

        BuildContainer()
        BuildTitle()
        BuildDivider()
        BuildQuestionText()
        BuildScale()
    End Sub

    ' ============================================================
    ' 1. CONTAINER
    ' ============================================================
    Private Sub BuildContainer()
        pnlContainer = New Panel()
        pnlContainer.BackColor = Color.White
        pnlContainer.BorderStyle = BorderStyle.FixedSingle
        pnlContainer.Location = New Point(0, 0)
        pnlContainer.Size = New Size(800, 240)
        pnlContainer.Padding = New Padding(20)

        Me.Controls.Add(pnlContainer)
    End Sub

    ' ============================================================
    ' 2. TITLE
    ' ============================================================
    Private Sub BuildTitle()
        lblTitle = New Label()
        lblTitle.Text = "Pertanyaan"
        lblTitle.Font = New Font("Segoe UI Semibold", 16, FontStyle.Bold)
        lblTitle.AutoSize = True
        lblTitle.Location = New Point(10, 10)
        lblTitle.ForeColor = Color.FromArgb(40, 40, 40)

        pnlContainer.Controls.Add(lblTitle)
    End Sub

    ' ============================================================
    ' 3. DIVIDER
    ' ============================================================
    Private Sub BuildDivider()
        pnlDivider = New Panel()
        pnlDivider.Width = 740
        pnlDivider.Height = 2
        pnlDivider.BackColor = Color.FromArgb(220, 220, 220)
        pnlDivider.Location = New Point(10, 50)
        pnlContainer.Controls.Add(pnlDivider)
    End Sub

    ' ============================================================
    ' 4. QUESTION TEXT
    ' ============================================================
    Private Sub BuildQuestionText()
        lblQuestion = New Label()
        lblQuestion.Text = "Teks pertanyaan muncul di sini."
        lblQuestion.Font = New Font("Segoe UI", 12)
        lblQuestion.AutoSize = False
        lblQuestion.Size = New Size(740, 60)
        lblQuestion.Location = New Point(10, 65)
        lblQuestion.ForeColor = Color.Black

        pnlContainer.Controls.Add(lblQuestion)
    End Sub

    ' ============================================================
    ' 5. SKALA NILAI
    ' ============================================================
    Private Sub BuildScale()

        ' FlowPanel untuk deskripsi skala
        flowDescriptions = New FlowLayoutPanel()
        flowDescriptions.Location = New Point(10, 135)
        flowDescriptions.Size = New Size(760, 25)
        flowDescriptions.FlowDirection = FlowDirection.LeftToRight
        flowDescriptions.WrapContents = False

        pnlContainer.Controls.Add(flowDescriptions)

        Dim descriptions As String() =
            {"Sangat Tidak Setuju", "Tidak Setuju", "Netral", "Setuju", "Sangat Setuju"}

        For Each desc As String In descriptions
            Dim lbl As New Label()
            lbl.Text = desc
            lbl.Font = New Font("Segoe UI", 9, FontStyle.Italic)
            lbl.ForeColor = Color.Gray
            lbl.TextAlign = ContentAlignment.MiddleCenter
            lbl.Size = New Size(140, 20)
            lbl.Margin = New Padding(5, 0, 5, 0)
            flowDescriptions.Controls.Add(lbl)
        Next

        ' FlowPanel untuk tombol radio
        flowButtons = New FlowLayoutPanel()
        flowButtons.Location = New Point(10, 160)
        flowButtons.Size = New Size(760, 70)
        flowButtons.FlowDirection = FlowDirection.LeftToRight
        flowButtons.WrapContents = False

        pnlContainer.Controls.Add(flowButtons)

        For i As Integer = 1 To 5
            Dim rb As New RadioButton()

            rb.Text = i.ToString()
            rb.Appearance = Appearance.Button
            rb.TextAlign = ContentAlignment.MiddleCenter
            rb.Font = New Font("Segoe UI", 14, FontStyle.Bold)
            rb.Size = New Size(70, 60)

            rb.FlatStyle = FlatStyle.Flat
            rb.FlatAppearance.BorderSize = 2
            rb.FlatAppearance.BorderColor = Color.Gray
            rb.BackColor = Color.WhiteSmoke

            rb.Margin = New Padding(30, 5, 30, 5)

            AddHandler rb.MouseEnter, AddressOf ScaleHover
            AddHandler rb.MouseLeave, AddressOf ScaleLeave
            AddHandler rb.CheckedChanged, AddressOf ScaleChecked

            scaleButtons.Add(rb)
            flowButtons.Controls.Add(rb)
        Next

    End Sub

    ' ============================================================
    ' 6. EFFECTS
    ' ============================================================
    Private Sub ScaleChecked(sender As Object, e As EventArgs)
        For Each rb As RadioButton In scaleButtons
            rb.BackColor = Color.WhiteSmoke
            rb.FlatAppearance.BorderColor = Color.Gray
        Next

        Dim btn As RadioButton = CType(sender, RadioButton)

        If btn.Checked Then
            btn.BackColor = Color.FromArgb(180, 215, 255)
            btn.FlatAppearance.BorderColor = Color.RoyalBlue
        End If
    End Sub

    Private Sub ScaleHover(sender As Object, e As EventArgs)
        Dim rb As RadioButton = CType(sender, RadioButton)
        If Not rb.Checked Then rb.BackColor = Color.FromArgb(235, 242, 255)
    End Sub

    Private Sub ScaleLeave(sender As Object, e As EventArgs)
        Dim rb As RadioButton = CType(sender, RadioButton)
        If Not rb.Checked Then rb.BackColor = Color.WhiteSmoke
    End Sub

    ' ============================================================
    ' 7. PUBLIC PROPERTIES
    ' ============================================================
    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property QuestionTitle As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property

    <Browsable(False)>
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Property QuestionText As String
        Get
            Return lblQuestion.Text
        End Get
        Set(value As String)
            lblQuestion.Text = value
        End Set
    End Property

    ' ============================================================
    ' 8. GET SCORE
    ' ============================================================
    Public ReadOnly Property SelectedScore As Integer
        Get
            For Each rb As RadioButton In scaleButtons
                If rb.Checked Then Return Integer.Parse(rb.Text)
            Next
            Return 0
        End Get
    End Property

    ' ============================================================
    ' 9. RESET SCORE
    ' ============================================================
    Public Sub ResetSelection()
        For Each rb As RadioButton In scaleButtons
            rb.Checked = False
            rb.BackColor = Color.WhiteSmoke
            rb.FlatAppearance.BorderColor = Color.Gray
        Next
    End Sub

    ' ============================================================
    ' 10. RESTORE SCORE (BACK BUTTON)
    ' ============================================================
    Public Sub SetScore(score As Integer)
        If score < 1 OrElse score > 5 Then Exit Sub

        ResetSelection()

        Dim rb As RadioButton = scaleButtons(score - 1)
        rb.Checked = True

        rb.BackColor = Color.FromArgb(180, 215, 255)
        rb.FlatAppearance.BorderColor = Color.RoyalBlue
    End Sub

End Class
