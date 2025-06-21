Imports System.IO
Module modPROCESSOR


    Public Const MOD_ALT As Integer = &H1 'Alt key  
    Public Const MOD_CONTROL As Integer = &H2
    Public Const MOD_SHIFT As Integer = &H4
    Public Const MOD_WIN As Integer = &H8
    Public Const WM_HOTKEY As Integer = &H312
    Public Declare Function RegisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer, ByVal fsModifiers As Integer, ByVal vk As Integer) As Integer
    Public Declare Function UnregisterHotKey Lib "user32" (ByVal hwnd As IntPtr, ByVal id As Integer) As Integer


    Public Declare Function SetActiveWindow Lib "User32" (ByVal hwnd As IntPtr) As Integer
    Public Declare Function SetForegroundWindow Lib "User32" (ByVal hwnd As IntPtr) As Integer
    Public Declare Function GetActiveWindow Lib "User32" () As System.IntPtr
    Public Declare Function BringWindowToTop Lib "User32" (ByVal hwnd As IntPtr) As System.IntPtr
    Public Declare Function GetForegroundWindow Lib "User32" () As System.IntPtr
    Public Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Integer)
    Public Declare Function GetWindowThreadProcessId Lib "user32.dll" (ByVal hwnd As IntPtr, ByRef lpdwProcessID As Integer) As Integer

    Public bln64bit As Boolean = getOSArchitectureLegacy()

    Public Function getOSArchitectureLegacy() As Integer

        Dim pa As String = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")
        Return IIf((String.IsNullOrEmpty(pa) Or String.Compare(pa, 0, "x86", 0, 3, True) = 0), 32, 64)

    End Function

    Public Function SaveTextToFile(ByVal strData As String, _
     ByVal FullPath As String, _
       Optional ByVal ErrInfo As String = "") As Boolean

        Dim Contents As String = ""
        Dim bAns As Boolean = False
        Dim objReader As StreamWriter
        Try
            objReader = New StreamWriter(FullPath)
            objReader.Write(strData)
            objReader.Close()
            bAns = True
        Catch Ex As Exception
            ErrInfo = Ex.Message
        End Try
        Return bAns
    End Function

    Public Function USB() As Boolean
        Dim d As String = System.AppDomain.CurrentDomain.BaseDirectory()

        Dim myd As DriveInfo
        Try
            For Each myd In DriveInfo.GetDrives
                If Asc(myd.Name) = Asc(d) Then
                    If myd.DriveType.ToString = "Removable" Then
                        Return True
                    End If
                End If
            Next
            Return False
        Catch ex As Exception
            Return True
        End Try

    End Function

End Module
