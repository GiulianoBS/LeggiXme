Module modWinH
    Public Declare Sub keybd_event Lib "user32" (ByVal bVk As Byte, ByVal bScan As Byte, ByVal dwFlags As Integer, ByVal dwExtraInfo As Integer)
    Public Const KEYEVENTF_KEYDOWN As Byte = &H0
    Public Const KEYEVENTF_KEYUP As Byte = &H2
    Public blnWinH As Boolean = False

    ' Attiva la dettatura con Windows 10 e 11

    Public Sub WinH()
        blnWinH = Not blnWinH

        keybd_event(Keys.LWin, 0, KEYEVENTF_KEYDOWN, 0)
        keybd_event(Keys.H, 0, KEYEVENTF_KEYDOWN, 0)

        keybd_event(Keys.LWin, 0, KEYEVENTF_KEYUP, 0)
        keybd_event(Keys.H, 0, KEYEVENTF_KEYUP, 0)
    End Sub

    Public Function win1011() As Boolean
        Dim a As String = My.Computer.Info.OSFullName
        If InStr(a, "Windows 10") > 0 Or InStr(a, "Windows 11") > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Module
