Public Class FormResult
    Private Sub FormResult_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private userScores As List(Of Integer)

    Public Sub New(scores As List(Of Integer))
        InitializeComponent()
        userScores = scores
    End Sub
End Class