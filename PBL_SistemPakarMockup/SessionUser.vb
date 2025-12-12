Module SessionUser
    Public LoggedUserID As Integer = -1
    Public LoggedUserNIM As String = ""
    Public LoggedUserNama As String = ""
    Public LoggedUserProdi As String = ""

    Public Sub ClearSession()
        LoggedUserID = 0
        LoggedUserNIM = ""
        LoggedUserNama = ""
        LoggedUserProdi = ""
    End Sub
End Module
