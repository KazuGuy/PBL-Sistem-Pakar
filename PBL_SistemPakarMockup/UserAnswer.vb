
Public Module UserAnswer

    Public Answers() As Integer = New Integer(Questions.QuestionList.Count - 1) {}
    Public Sub Reset()
        For i As Integer = 0 To Answers.Length - 1
            Answers(i) = 0
        Next
    End Sub
End Module
