Public Class FormQuiz

    Private currentIndex As Integer = 0
    Private totalQuestions As Integer = Questions.QuestionList.Count
    Private userAnswers As New List(Of Integer)

    ' UI Components
    Private lblProgress As Label
    Private qCtrl As QuestionControl
    Private btnBack As Button
    Private btnNext As Button

    Public Sub New()
        InitializeComponent()
        SetupQuizUI()
        LoadQuestion()
    End Sub


    Private Sub SetupQuizUI()

        Me.BackColor = Color.WhiteSmoke
        Me.StartPosition = FormStartPosition.CenterScreen


        lblProgress = New Label()
        lblProgress.Font = New Font("Segoe UI", 12, FontStyle.Bold)
        lblProgress.AutoSize = True
        lblProgress.Location = New Point(30, 20)
        Me.Controls.Add(lblProgress)

        qCtrl = New QuestionControl()
        qCtrl.Location = New Point(30, 60)
        Me.Controls.Add(qCtrl)


        btnBack = New Button()
        btnBack.Text = "Back"
        btnBack.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnBack.Size = New Size(120, 40)
        btnBack.Location = New Point(520, 350)
        btnBack.Enabled = False
        AddHandler btnBack.Click, AddressOf BtnBack_Click
        Me.Controls.Add(btnBack)


        btnNext = New Button()
        btnNext.Text = "Next >"
        btnNext.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        btnNext.Size = New Size(120, 40)
        btnNext.Location = New Point(650, 350)
        AddHandler btnNext.Click, AddressOf BtnNext_Click
        Me.Controls.Add(btnNext)

    End Sub


    Private Sub LoadQuestion()

        lblProgress.Text = $"Pertanyaan {currentIndex + 1} / {totalQuestions}"

        qCtrl.QuestionTitle = $"Pertanyaan {currentIndex + 1}"
        qCtrl.QuestionText = Questions.QuestionList(currentIndex)
        qCtrl.ResetSelection()

        ' Jika user sudah menjawab sebelumnya
        If currentIndex < userAnswers.Count Then
            qCtrl.SetScore(userAnswers(currentIndex))
        End If

        ' Atur tombol
        btnBack.Enabled = (currentIndex > 0)
        btnNext.Text = If(currentIndex = totalQuestions - 1, "Finish", "Next >")

    End Sub


    Private Sub BtnNext_Click(sender As Object, e As EventArgs)

        Dim score = qCtrl.SelectedScore

        If score = 0 Then
            MessageBox.Show("Silakan pilih nilai dulu.", "Peringatan")
            Return
        End If

        ' Simpan jawaban
        If currentIndex < userAnswers.Count Then
            userAnswers(currentIndex) = score
        Else
            userAnswers.Add(score)
        End If

        ' FINISH → buka FormResult
        If currentIndex = totalQuestions - 1 Then
            Dim resultForm As New FormResult(userAnswers)
            resultForm.Show()
            Me.Hide()
            Return
        End If

        currentIndex += 1
        LoadQuestion()

    End Sub

    Private Sub BtnBack_Click(sender As Object, e As EventArgs)

        If currentIndex = 0 Then Return

        currentIndex -= 1
        LoadQuestion()

    End Sub

    Private Sub FormQuiz_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
