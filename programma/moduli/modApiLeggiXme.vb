
Option Strict Off
Option Explicit On
Imports System.Text.RegularExpressions
Imports System.Globalization

Module modApiLeggiXme

    Public xCalc, xxCalc As Integer, yCalc, yyCalc As Integer

    Structure RECT
        Public Left As Integer
        Public Top As Integer
        Public Right As Integer
        Public Bottom As Integer
    End Structure

    Declare Function SetWindowPos Lib "user32.dll" (ByVal hWnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer
    Declare Function MoveWindow Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal X As Int32, ByVal Y As Int32, _
           ByVal nWidth As Int32, ByVal nHeight As Int32, ByVal bRepaint As Boolean) As Boolean
    Declare Function GetWindowRect Lib "user32" Alias "GetWindowRect" (ByVal hwnd As Integer, ByRef lpRect As RECT) As Integer
    Declare Function FindWindowByCaption Lib "user32" (ByVal id As Integer, ByVal strNome As String) As IntPtr

    Public Const SWP_ASYNCWINDOWPOS As Integer = &H4000
    Public Const SWP_DEFERERASE As Integer = &H2000
    Public Const SWP_DRAWFRAME As Integer = SWP_FRAMECHANGED
    Public Const SWP_FRAMECHANGED As Integer = &H20
    Public Const SWP_HIDEWINDOW As Integer = &H80
    Public Const SWP_NOACTIVATE As Integer = &H10
    Public Const SWP_NOCOPYBITS As Integer = &H100
    Public Const SWP_NOMOVE As Integer = &H2
    Public Const SWP_NOOWNERZORDER As Integer = &H200
    Public Const SWP_NOREDRAW As Integer = &H8
    Public Const SWP_NOREPOSITION As Integer = SWP_NOOWNERZORDER
    Public Const SWP_NOSENDCHANGING As Integer = &H400
    Public Const SWP_NOSIZE As Integer = &H1
    Public Const SWP_NOZORDER As Integer = &H4
    Public Const SWP_SHOWWINDOW As Integer = &H40

    Public Const WM_COPY As Integer = &H301

    Public Const FLAGS As Boolean = SWP_NOMOVE Or SWP_NOSIZE

    Public Const HWND_TOP As Short = 0
    Public Const HWND_BOTTOM As Short = 1
    Public Const HWND_TOPMOST As Short = -1
    Public Const HWND_NOTOPMOST As Short = -2

    Public blnTrasparente As Boolean
    Public blnCeFW35 As Boolean = False
    Public blnMP3 As Boolean = False
    Public ProcID As Integer

    Public Const SC_CLOSE As Integer = &HF060

    Public Appunti(0) As String
    Public NAppunti As Integer = 0

    ' Modulo varie
    Public blnHoAperto As Boolean = False
    Public blnManuale As Boolean = False
    Public blnSito As Boolean = False
    Public FileDaAprire As String = ""

    Public blnLens As Boolean = False

    Structure POINTAPI
        Dim x As Integer
        Dim y As Integer
    End Structure

    Structure TMSG
        Dim hWnd As Integer
        Dim message As Integer
        Dim wParam As Integer
        Dim lParam As Integer
        Dim time As Integer
        Dim pt As POINTAPI
    End Structure

    'Modulo Trasparente
    Private Declare Function SetLayeredWindowAttributes Lib "user32" (ByVal hWnd As Integer, ByVal crKey As Integer, ByVal bAlpha As Byte, ByVal dwFlags As Integer) As Integer
    Private Declare Function UpdateLayeredWindow Lib "user32" (ByVal hWnd As Integer, ByVal hdcDst As Integer, ByRef pptDst As Object, ByRef psize As Object, ByVal hdcSrc As Integer, ByRef pptSrc As Object, ByRef crKey As Integer, ByVal pblend As Integer, ByVal dwFlags As Integer) As Integer
    Private Declare Function GetWindowLong Lib "user32" Alias "GetWindowLongA" (ByVal hWnd As Integer, ByVal nIndex As Integer) As Integer
    Private Declare Function SetWindowLong Lib "user32" Alias "SetWindowLongA" (ByVal hWnd As Integer, ByVal nIndex As Integer, ByVal dwNewLong As Integer) As Integer

    Private Const GWL_EXSTYLE As Short = (-20)
    Private Const LWA_COLORKEY As Integer = &H1
    Private Const LWA_ALPHA As Integer = &H2
    Private Const ULW_COLORKEY As Integer = &H1
    Private Const ULW_ALPHA As Integer = &H2
    Private Const ULW_OPAQUE As Integer = &H4
    Private Const WS_EX_LAYERED As Integer = &H80000

    Public TopoAttivo As Boolean = False
    Public SchermoAttivoP As Boolean = False
    Public SchermoAttivoW As Boolean = False
    Public SchermoAttivoI As Boolean = False
    Public InizioImmagine As Point, FineImmagine As Point, MisuraImmagine As Size

    Public Percorso As String = My.Application.Info.DirectoryPath
    Public CartellaTemp As String = Environment.GetEnvironmentVariable("temp") & "\" 'Percorso & "\" 
    Public FileTemporaneo As String = CartellaTemp & "LxMtemp.rtf"
    Public FilePerMappa As String = CartellaTemp & "MapTemp.txt"

    Public blnBiancoeNero As Boolean = False

    Public blnAggTesto As Boolean = False

    Public blnInternet As Boolean = False

    Public Sub LeggiSincrono(ByVal t As String)
        Sincrono(t)
    End Sub

    Public Function eUnaParola(ByVal t As String, ByVal inizio As Integer, ByVal lunghezza As Integer) As Boolean

        Dim pre As Boolean = False, seg As Boolean = False

        Try
            If inizio = 0 Then
                Return False
                Exit Function
            End If
            If inizio = 1 Then
                pre = True
            Else
                If InStr(Spazi, Mid(t, inizio - 1, 1)) <> 0 Then
                    pre = True
                End If
            End If

            If inizio + lunghezza = Len(t) Then
                seg = True
            Else
                If InStr(Spazi, Mid(t, inizio + lunghezza, 1)) <> 0 Then
                    seg = True
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Return pre And seg

    End Function

    Public Function FiltroNumeri(ByVal t As String) As String

        Dim s As String() = Regex.Split(t, "\ ")
        Dim w As String = "", ww As String = ""
        Dim nm As Double = 0
        Dim i As Integer = 0, p1 As Integer = 1, p2 As Integer = 0
        Dim LP As String = (Lingua(intParlante))
        If LP <> Inglese And LP <> IngleseUS Then LP = Italiano
        Dim nfi As NumberFormatInfo = New CultureInfo(LP, False).NumberFormat
        Dim l As Integer = 0

        For Each w In s
            Do
                l = Len(w)
                If l < 2 Then Exit Do
                If EAlfaNum(Mid(w, 1, 1)) = False Then
                    w = Mid(w, 2)
                Else
                    Exit Do
                End If
            Loop

            Do
                l = Len(w)
                If l < 2 Then Exit Do
                If EAlfaNum(Mid(w, l, 1)) = False Then
                    w = Mid(w, 1, l - 1)
                Else
                    Exit Do
                End If
            Loop

            If IsNumeric(w) Then
                ww = w
                If Lingua(intParlante) = Inglese Or Lingua(intParlante) = IngleseUS Then
                    ww = ww.Replace(",", "")
                Else
                    ww = ww.Replace(".", "")
                    ww = ww.Replace(",", ".")
                End If
                nm = Val(ww)
                i = InStrRev(ww, ".") : If i > 0 Then i = Len(ww) - i
                nfi.NumberDecimalDigits = i
                If i > 0 Or nm > 2099 Then
                    ww = nm.ToString("N", nfi)
                End If
                p2 = InStr(p1, t, w)
                t = Mid(t, 1, p2 - 1) & ww & Mid(t, p2 + Len(w))
                p1 = p2 + Len(ww)
            End If
        Next

        Return t

    End Function

    Private Function EAlfaNum(ByVal strInputText As String) As Boolean
        If Regex.IsMatch(strInputText, "^[a-zA-Z0-9]+$") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function FiltroLineetta(ByVal t As String) As String
        Dim tt As String, i As Integer, l As Integer, a As String
        tt = t
        l = 1
        Do
            i = InStr(l, tt, "- ")
            If i = 0 Then Exit Do
            If i <> 1 Then
                a = Mid(tt, i - 1, 1)
                If (a >= "A" And a <= "Z") Or (a >= "a" And a <= "z") Then
                    tt = Mid(tt, 1, i - 1) & Mid(tt, i + 2)
                End If
            End If
            l = i + 2
        Loop
        tt = tt.Replace("a. C.", "a.C.")
        tt = tt.Replace("d. C.", "d.C.")
        Return tt
    End Function

    Public Function filtrata(ByVal t As String) As String

        Dim tt As String, i As Integer, l As Integer
        Dim aCapo As Boolean = False

        tt = t
        l = Len(tt)

        For i = l To 1 Step -1
            aCapo = (Mid(t, i, 1) = Chr(13))
            If aCapo Then
                If i > 1 Then
                    If InStr(".!?", Mid(t, i - 1, 1)) = 0 Then
                        tt = Mid(tt, 1, i - 1) & " " & Mid(tt, i + 2)
                    End If
                    If Mid(t, i - 1, 1) = "-" Or Mid(t, i - 1, 1) = Chr(173) Then
                        tt = Mid(tt, 1, i - 2) & Mid(tt, i + 1)
                    End If
                Else
                    tt = Mid(tt, i + 2)
                End If
                If i > 2 Then
                    If Mid(t, i - 2, 1) = "- " Then
                        tt = Mid(tt, 1, i - 3) & Mid(tt, i + 1)
                    End If
                End If
            End If
        Next i
        tt = tt.Replace(ChrW(64257) & " ", "fi")
        tt = tt.Replace(ChrW(64257), "fi")
        tt = tt.Replace("fn", "fin")
        tt = tt.Replace("fl", "fil")

        Return tt

    End Function

    Public Function filtrata2(ByVal t As String) As String

        Dim ss() As String
        Dim l As Integer = 0, i As Integer = 0
        Dim testo As String = ""

        ss = Regex.Split(t, "\n+")

        For Each st As String In ss
            st = Trim(st)
            l = Len(st)
            If st <> "" Then
                If InStr(".!?", Mid(st, l, 1)) <> 0 Then
                    st += vbCrLf
                ElseIf InStr(st, "-") = l Then
                    st = Mid(st, 1, l - 1)
                Else
                    st += " "
                End If
                testo += st
            End If
        Next
        Return testo

    End Function

    Private Declare Function FindExecutable Lib "shell32.dll" Alias "FindExecutableA" (ByVal lpFile As String, ByVal lpDirectory As String, ByVal lpResult As String) As Integer
    ' Return the path to the program associated with this extension.

    Public Function TrovaProgrammaAssociato(ByVal extension As String) As String
        Dim temp_title As String = ""
        Dim temp_path As String = ""
        Dim fnum As Short
        Dim result As String
        Dim pos As Short
        ' Get a temporary file name with this extension.
        GetTempFile(extension, temp_path, temp_title)

        ' Make the file.
        fnum = FreeFile()
        FileOpen(fnum, temp_path & temp_title, OpenMode.Output)
        FileClose(fnum)

        ' Get the associated executable.
        result = Space(1024)
        FindExecutable(temp_title, temp_path, result)
        pos = InStr(result, Chr(0))
        result = Mid(result, 1, pos - 1)
        pos = result.LastIndexOf("\")
        Kill(temp_path & temp_title)

        Return Mid(result, pos + 2)

    End Function


    Public Function ProgrammaAssociato(ByVal extension As String) As String
        Dim temp_title As String = ""
        Dim temp_path As String = ""
        Dim fnum As Short
        Dim result As String
        Dim pos As Short

        GetTempFile(extension, temp_path, temp_title)
        fnum = FreeFile()
        FileOpen(fnum, temp_path & temp_title, OpenMode.Output)
        FileClose(fnum)
        result = Space(1024)
        FindExecutable(temp_title, temp_path, result)
        Kill(temp_path & temp_title)
        pos = InStr(result, Chr(0))
        Return Mid(result, 1, pos - 1)
        pos = result.LastIndexOf("\")
    End Function

    Private Sub GetTempFile(ByVal extension As String, ByRef temp_path As String, ByRef temp_title As String)
        Dim i As Short

        If Mid(extension, 1, 1) <> "." Then extension = "." & extension

        temp_path = Environ("TEMP")
        If Mid(temp_path, Len(temp_path) - 1, 1) <> "\" Then temp_path = temp_path & "\"

        i = 0
        Do
            temp_title = "tmp" & CStr(i) & extension
            If Len(Dir(temp_path & temp_title)) = 0 Then Exit Do
            i = i + 1
        Loop
    End Sub

    Public Declare Function InternetGetConnectedState Lib "wininet.dll" (ByRef Description As Integer, ByVal ReservedValue As Integer) As Boolean

    Public Function ConnessioneInternet() As Boolean
        Return IsConnectionAvailable()
    End Function

    Private Function IsConnectionAvailable() As Boolean
        'Call url
        Dim url As New System.Uri("https://www.google.com/")
        'Request for request
        Dim req As System.Net.WebRequest
        req = System.Net.WebRequest.Create(url)
        Dim resp As System.Net.WebResponse
        Try
            resp = req.GetResponse()
            resp.Close()
            req = Nothing
            Return True
        Catch ex As Exception
            req = Nothing
            Return False
        End Try
    End Function

    Public Function InternetConnesso() As Boolean
        If My.Computer.Network.IsAvailable Then

            Try
                If My.Computer.Network.Ping("www.Google.com") Then
                    Return True
                Else
                    Return False
                End If
            Catch

            End Try

        Else
            Return False
        End If
    End Function

    Public Function NomeFinestraPrimoPiano() As String
        Dim tmp As IntPtr = Nothing
        tmp = GetForegroundWindow
        Dim strProg As String = UCase(GetWT(tmp))
        Return strProg
    End Function

    Public Function GetWT(ByVal hWnd As IntPtr) As String

        Dim pid As Integer = 0
        GetWindowThreadProcessId(hWnd, pid)
        If pid = 0 Then
            GetWT = ""
            Exit Function
        End If

        Dim proc As Process = Process.GetProcessById(pid)
        If proc Is Nothing Then
            GetWT = ""
            Exit Function
        End If
        Dim txtProcessName As String = proc.ProcessName
        GetWT = UCase(txtProcessName)

    End Function

    Public Sub CancellaImpostazioni()
        DeleteSetting(Programma)
    End Sub

    Public Function SeparaParole(ByVal s As String) As String() '
        Return Regex.Split(s, "\W+")
    End Function

    Public Function CartellaLeggiXme() As String
        Return CartellaDocumenti() & "\LeggiXme"
    End Function

    Public Function CartellaDocumenti() As String
        Return System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    End Function

    Public Function TrovaCartellaPDF() As String
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim cartella As String = Mid(Percorso, 1, i) & "PDF"
        If IO.Directory.Exists(cartella) = False Then
            cartella = CartellaLeggiXme() & "\PDF"
            If IO.Directory.Exists(cartella) = False Then
                cartella = CartellaLeggiXme() & "\PDF"
                CreaCartella(cartella)
            End If
        End If
        Return cartella
    End Function

    Public Function TrovaCartellaDOC() As String
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim cartella As String = Mid(Percorso, 1, i) & "DOC"
        If IO.Directory.Exists(cartella) = False Then
            cartella = CartellaLeggiXme() & "\DOC"
            If IO.Directory.Exists(cartella) = False Then
                cartella = CartellaLeggiXme() & "\DOC"
                CreaCartella(cartella)
            End If
        End If
        Return cartella
    End Function

    Public Function CreaCartella(ByVal cartella As String) As Boolean
        If (Not System.IO.Directory.Exists(cartella)) Then
            Dim i As System.IO.DirectoryInfo = System.IO.Directory.CreateDirectory(cartella)
            Return True
        Else
            Return False
        End If
    End Function

    Public Function ext(ByVal nf As String) As String
        Dim i As Integer = nf.LastIndexOf(".")
        If i < 1 Then
            Return ""
            Exit Function
        End If
        Dim esten As String = Mid(nf, i + 1)

        Return esten

    End Function

    Public Function MettiUnoSpazio(ByVal t As String) As String
        t = t.Replace(" .", ".")
        t = t.Replace(" ?", "?")
        t = t.Replace(" !", "!")
        t = t.Replace(" ,", ",")
        t = t.Replace(" ;", ";")
        t = t.Replace(" :", ":")
        t = t.Replace(".", ". ")
        t = t.Replace("?", "? ")
        t = t.Replace("!", "! ")
        t = t.Replace(",", ", ")
        t = t.Replace(";", "; ")
        t = t.Replace(":", ": ")

        t = t.Replace("   ", " ")
        t = t.Replace("  ", " ")
        Return t
    End Function

    Public Function MettiDoppiSpazi(ByVal t As String) As String
        t = MettiUnoSpazio(t)
        t = t.Replace(" ", "  ")
        Return t
    End Function

    Public Sub ImpostaInterlinea(ByVal RTB As RichTextBox)

        RTB.SuspendLayout()
        Dim inz As Integer = RTB.SelectionStart
        Dim lng As Integer = RTB.SelectionLength
        Dim i As Integer = 0
        Select Case interlinea
            Case 2 : i = CInt(RTB.Font.Size / 2)
            Case 3 : i = CInt(RTB.Font.Size)
            Case Else
        End Select
        RTB.SelectAll()
        RTB.SelectionCharOffset = i
        RTB.SelectionStart = inz
        RTB.SelectionLength = lng
        RTB.ResumeLayout()
    End Sub


    Public Function Ripulisci(p As String) As String

        Return p.Trim(Chr(32), Chr(10), Chr(13), CChar("\"), CChar("/"), CChar(";"), CChar(","))

    End Function

    Public Const Freccia As String = "--->"

End Module