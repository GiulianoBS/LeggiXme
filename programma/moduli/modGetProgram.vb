Imports Microsoft.Win32
Imports System.IO

Module basGetApplication

    Public Function GetApplication(ByVal FileExtension As String) As String
        '
        ' Return registered application based on the filename extension
        '
        Dim strProgramName As String
        Dim strEXEFilename As String
        Dim regkey_HKEY_CLASSES_ROOT As RegistryKey ' HKEY_CLASSES_ROOT
        Dim regkey_ProgID As RegistryKey
        Dim regkey_OpenCommand As RegistryKey
        Dim intIndex As Integer

        Try
            ' Add starting dot to extension
            If FileExtension.StartsWith(".") = False Then
                FileExtension = "." & FileExtension
            End If
            ' Get Programmatic Identifier for this extension
            Try
                regkey_HKEY_CLASSES_ROOT = Registry.ClassesRoot
                regkey_ProgID = regkey_HKEY_CLASSES_ROOT.OpenSubKey(FileExtension)
                strProgramName = regkey_ProgID.GetValue(Nothing).ToString
                regkey_ProgID.Close()
            Catch
                ' Nothing found
                Return ""
            End Try
            ' Get  application associated with the file extension
            Try
                regkey_OpenCommand = regkey_HKEY_CLASSES_ROOT.OpenSubKey(strProgramName & "\shell\open\command")
                strEXEFilename = regkey_OpenCommand.GetValue(Nothing).ToString
                regkey_OpenCommand.Close()
            Catch
                ' No default application is registered
                Return ""
            End Try
            intIndex = strEXEFilename.IndexOf(" %1")
            If intIndex > 0 Then
                ' Replace %1 placeholder with ParamFileName
                strEXEFilename = strEXEFilename.Substring(0, intIndex)
                'ShellAppName = strEXEFilename
            Else
                ' No %1 placeholder found, append ParamFileName
                'ShellAppName = strEXEFilename
            End If
            Return Mid(strEXEFilename, 1, Len(strEXEFilename) - 5)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Public Function MindMaple() As String
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim fil As String = Mid(Percorso, 1, i - 1)
        'i = InStrRev(fil, "\") - 1
        fil = Mid(Percorso, 1, i) & "\MindMaple1\MindMaple1.exe"
        If IO.File.Exists(fil) = False Then
            fil = GetApplication(".emm")
        End If
        Return fil
    End Function

    Public Function Cmap() As String
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim fil As String = Mid(Percorso, 1, i - 1)
        'i = InStrRev(fil, "\") - 1
        fil = Mid(Percorso, 1, i) & "\CmapToolsPortable\CmapToolsPortable.exe"
        If IO.File.Exists(fil) = False Then
            fil = GetApplication(".cmap")
        End If
        Return fil
    End Function

    Public blnLettore As Boolean = False

    Public Function CeLettorePDF() As Boolean

        If CePDFViewer() = True Then
            Return True
            Exit Function
        End If
        Dim np As String = ""
        Try
            np = ProgrammaAssociato("pdf")
        Catch ex As Exception
            Return False
        End Try
        If np = "" Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function CePDFViewer() As Boolean
        Dim p As String = PDFXCviewer()
        If p <> "" Then
            Return IO.File.Exists(p)
        Else
            Return False
        End If
    End Function

    Public Function ChromeInstallato2() As Boolean
        Dim Everest_Registry As Microsoft.Win32.RegistryKey = My.Computer.Registry.CurrentUser.OpenSubKey("Software\Google\Chrome")
        If Everest_Registry Is Nothing Then
            Return False
        Else
            Return True
        End If
    End Function

    Public Function ChromeInstallato() As String
        If IO.File.Exists(System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86) & "\Google\Chrome\Application\chrome.exe") = True Then 'And IO.File.Exists("C:\Program Files\Google\Chrome\Application\chrome.exe") Then
            Return "C:\Program Files (x86)\Google\Chrome\Application\chrome.exe"
        ElseIf IO.File.Exists("C:\Program Files\Google\Chrome\Application\chrome.exe") = True Then
            Return "C:\Program Files\Google\Chrome\Application\chrome.exe"
        Else
            Return ""
        End If
    End Function

    Public Function Chrome() As String
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim Chro As String = Mid(Percorso, 1, i) & "GoogleChromePortable\GoogleChromePortable.exe"
        If IO.File.Exists(Chro) = False Then Chro = ""
        Return Chro
    End Function

    Public Function ChromeAttivo() As Boolean
        Dim Processo As String

        Dim procList() As Process = Process.GetProcesses()
        For Each p As Process In procList ' i + 1
            Processo = p.ProcessName
            If LCase(Processo) = "chrome" Then
                Return True
            End If
        Next
        Return False
    End Function

    Public Function PDFXCviewer() As String
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim PDFV As String = Mid(Percorso, 1, i) & "PDFXEdit\PDFXEdit.exe"
        If IO.File.Exists(PDFV) = False Then
            PDFV = Mid(Percorso, 1, i) & "PDFXCview\PDFXCview.exe"
        End If
        If IO.File.Exists(PDFV) = False Then
            PDFV = ""
        End If
        Return PDFV
    End Function

End Module

