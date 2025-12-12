Public Class FormQuiz
    Inherits Form

    Private pertanyaanList As List(Of String)
    Private currentIndex As Integer = 0
    Private totalQuestions As Integer = 0
    Private userAnswers As New List(Of Integer)

    Private lblProgress As Label
    Private qCtrl As QuestionControl
    Private btnBack As Button
    Private btnNext As Button

    Public Sub New()
        Me.AutoScaleMode = AutoScaleMode.None
        Me.FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        Me.BackColor = Color.WhiteSmoke
        InitializeComponent()
        SetupQuizUI()
    End Sub

    Private Sub FormQuiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPertanyaan()
    End Sub

    ' =========================================================
    ' LOAD PERTANYAAN DARI DB
    ' =========================================================
    Private Sub LoadPertanyaan()
        pertanyaanList = GetPertanyaanList()

        If pertanyaanList.Count = 0 Then
            MessageBox.Show("Tidak ada pertanyaan di database!", "Error")
            Me.Close()
            Return
        End If

        totalQuestions = pertanyaanList.Count
        LoadQuestion()
    End Sub

    ' =========================================================
    ' SETUP UI
    ' =========================================================
    Private Sub SetupQuizUI()

        lblProgress = New Label()
        lblProgress.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        lblProgress.AutoSize = True
        lblProgress.Location = New Point(30, 20)
        Me.Controls.Add(lblProgress)

        ' Pastikan QuestionControl mengisi area tengah
        qCtrl = New QuestionControl()
        qCtrl.Location = New Point(30, 70)
        qCtrl.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        qCtrl.Width = Me.Width - 60
        Me.Controls.Add(qCtrl)

        btnBack = New Button()
        btnBack.Text = "< Back"
        btnBack.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnBack.Size = New Size(120, 40)
        btnBack.Location = New Point(Me.Width - 300, Me.Height - 80)
        btnBack.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        btnBack.Enabled = False
        AddHandler btnBack.Click, AddressOf BtnBack_Click
        Me.Controls.Add(btnBack)

        btnNext = New Button()
        btnNext.Text = "Next >"
        btnNext.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnNext.Size = New Size(120, 40)
        btnNext.Location = New Point(Me.Width - 160, Me.Height - 80)
        btnNext.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        AddHandler btnNext.Click, AddressOf BtnNext_Click
        Me.Controls.Add(btnNext)

    End Sub

    ' =========================================================
    ' LOAD QUESTION UI
    ' =========================================================
    Private Sub LoadQuestion()

        lblProgress.Text = $"Pertanyaan {currentIndex + 1} / {totalQuestions}"

        qCtrl.QuestionTitle = $"Pertanyaan {currentIndex + 1}"
        qCtrl.QuestionText = pertanyaanList(currentIndex)
        qCtrl.ResetSelection()

        ' restore jawaban sebelumnya
        If currentIndex < userAnswers.Count Then
            qCtrl.SetScore(userAnswers(currentIndex))
        End If

        btnBack.Enabled = (currentIndex > 0)
        btnNext.Text = If(currentIndex = totalQuestions - 1, "Finish", "Next >")
    End Sub

    ' =========================================================
    ' NEXT BUTTON
    ' =========================================================
    Private Sub BtnNext_Click(sender As Object, e As EventArgs)
        Dim score = qCtrl.SelectedScore

        If score = 0 Then
            MessageBox.Show("Silakan pilih nilai terlebih dahulu.", "Peringatan")
            Return
        End If

        ' simpan nilai
        If currentIndex < userAnswers.Count Then
            userAnswers(currentIndex) = score
        Else
            userAnswers.Add(score)
        End If

        If currentIndex = totalQuestions - 1 Then
            Dim fr As New FormResult(userAnswers)
            fr.MdiParent = Me.MdiParent
            fr.Show()
            Me.Hide()
            Return
        End If

        currentIndex += 1
        LoadQuestion()
    End Sub

    ' =========================================================
    ' BACK BUTTON
    ' =========================================================
    Private Sub BtnBack_Click(sender As Object, e As EventArgs)
        If currentIndex = 0 Then Return
        currentIndex -= 1
        LoadQuestion()
    End Sub

End Class
