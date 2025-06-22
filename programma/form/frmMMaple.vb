Imports System.Text.RegularExpressions

Public Class frmMMaple
    Dim ColEv0 As Color = Color.LightGreen 'Color.FromArgb(0, 255, 255)
    Dim ColEv1 As Color = Color.Aqua 'Color.FromArgb(0, 255, 255)
    Dim ColEv2 As Color = Color.Pink 'Color.FromArgb(255, 0, 255)
    Dim ColEv3 As Color = Color.Yellow 'Color.FromArgb(255, 255, 0)
    Dim ColEv4 As Color = Color.Silver 'Color.FromArgb(255, 255, 0)
    Dim ColEv5 As Color = Color.Orange 'Color.FromArgb(255, 255, 0)
    Dim FilePerMappa As String = Environment.GetEnvironmentVariable("temp") & "\MapTemp.txt"
    Dim ColoreSfondo As Color = Color.White
    Dim procMM As Process
    'Dim tmpRTF As String = ""
    Dim Origine As String = "", Relazione As String = "", Destinazione() As String
    Dim qd As Integer = 0
    Dim FattoreZoom As Single = 0

    Private Declare Function FindExecutable Lib "shell32.dll" Alias "FindExecutableA" (ByVal lpFile As String, ByVal lpDirectory As String, ByVal lpResult As String) As Integer
    ' Return the path to the program associated with this extension.

    Public Sub GetTempFile(ByVal extension As String, ByRef temp_path As String, ByRef temp_title As String)
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

    Public Function CartellaDocumenti() As String
        Return System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    End Function
    Private Sub frmMMaple_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Me.Hide()
        frmLeggiConMe.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RTB.Font = FontPredefinito
        RTB.BackColor = ColoreSfondo
        'Public CartellaTemp As String = Environment.GetEnvironmentVariable("temp") & "\"
    End Sub

    Public Percorso As String = My.Application.Info.DirectoryPath

    Function MindMaple() As String
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim fil As String = Mid(Percorso, 1, i - 1)
        'i = InStrRev(fil, "\") - 1
        fil = Mid(Percorso, 1, i) & "\MindMaple1\MindMaple1.exe"
        If IO.File.Exists(fil) = False Then
            'fil = TrovaProgrammaAssociato("emm")
            fil = GetApplication(".emm")
        End If
        Return fil
    End Function

    Sub CreaLaMappa()
        If IO.File.Exists(FilePerMappa) Then
            Kill(FilePerMappa)
        End If
        Dim TxM As String = ""

        If RTB.Text = "" Then
            MsgBox("Non c'è testo per fare una mappa", MsgBoxStyle.Critical)
        Else
            If RTB.SelectedText <> "" Then
                TxM = RTB.SelectedText
            Else
                TxM = RTB.Text
            End If
            Dim ss() As String
            ss = Regex.Split(TxM, "\n+")

            TxM = ""
            For Each st As String In ss
                st = st.Replace(Freccia, Chr(9))
                st = Ripulisci(st)
                If st <> "" Then
                    TxM &= st & Chr(10)
                End If
            Next

            Dim objWriter As New System.IO.StreamWriter(FilePerMappa)
            objWriter.Write(TxM)
            objWriter.Close()
            objWriter = Nothing
            Dim nf As String = Chr(34) & FilePerMappa & Chr(34)
            If procMM IsNot Nothing Then
                Try
                    procMM.Kill()
                Catch ex As Exception
                End Try
            End If
            Dim prg As String = MindMaple()
            Try
                procMM = Process.Start(prg, nf)
                'proc = Process.Start(prg)
            Catch ex As Exception
                MsgBox(prg & " " & nf)
            End Try

        End If

    End Sub

    Sub CreaLaMappa2()

        Dim beg As Integer = 0
        Dim lon As Integer = RTB.TextLength

        If IO.File.Exists(FilePerMappa) Then
            Kill(FilePerMappa)
        End If
        Dim TxM As String = ""

        If RTB.Text = "" Then
            MsgBox("Non c'è testo per fare una mappa", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If RTB.SelectedText <> "" Then
            beg = RTB.SelectionStart
            lon = RTB.SelectionLength
        End If

        TxM = TestoEvidenziato2(beg, lon)

        ' ***************************
        If TxM <> "" Then
            RTB.Text = ""
            RTB.SelectionBackColor = ColoreSfondo
            RTB.Text = TxM
        End If

        btnControlla.Enabled = True

        Exit Sub

    End Sub

    Private Function TestoEvidenziato2(ByVal b As Integer, ByVal l As Integer) As String
        Dim tempo As String = "", titolo As String = ""
        Dim i As Integer = 0
        Dim E As Integer = -1
        Dim c As Color = ColoreSfondo
        Dim blnTitolo As Boolean = False, blnFatto As Boolean = False

        For i = b To l - 1
            RTB.SelectionStart = i
            RTB.SelectionLength = 1
            c = RTB.SelectionBackColor
            'Me.Text += c.ToString + ColEv1.ToString
            If c = ColEv0 Then
                If blnFatto = True Then
                    MsgBox("Può esserci solo un nodo centrale", MsgBoxStyle.Critical)
                    Return ""
                    Exit Function
                End If
                If E <> 0 Then
                    blnTitolo = True
                    E = 0
                End If
                titolo += RTB.SelectedText
            ElseIf c = ColEv1 Then
                If blnTitolo = True Then
                    blnTitolo = False
                    blnFatto = True
                    titolo = Ripulisci(titolo)
                    tempo = titolo + vbCrLf + vbCrLf + tempo 'Chr(10)
                End If
                If E <> 1 Then
                    If tempo <> "" Then
                        tempo = Ripulisci(tempo) & vbCrLf + Chr(9) 'Chr(10)
                    End If
                    E = 1
                End If
                tempo += RTB.SelectedText
            ElseIf c = ColEv2 Then
                If blnTitolo = True Then
                    blnTitolo = False
                    blnFatto = True
                    tempo = titolo + vbCrLf + vbCrLf + tempo 'Chr(10)
                End If
                If E <> 2 Then
                    If tempo <> "" Then
                        'tempo += Chr(10) + Chr(9)
                        tempo = Ripulisci(tempo) & vbCrLf + Chr(9) + Chr(9)
                    End If
                    E = 2
                End If
                tempo = tempo & RTB.SelectedText
            ElseIf c = ColEv3 Then
                If blnTitolo = True Then
                    blnTitolo = False
                    blnFatto = True
                    tempo = titolo + vbCrLf + vbCrLf + tempo 'Chr(10)
                End If
                If E <> 3 Then
                    If tempo <> "" Then
                        'tempo += Chr(10) + Chr(9) + Chr(9)
                        tempo = Ripulisci(tempo) & vbCrLf + Chr(9) + Chr(9) + Chr(9)
                    End If
                    E = 3
                End If
                tempo = tempo & RTB.SelectedText
            ElseIf c = ColEv4 Then
                If blnTitolo = True Then
                    blnTitolo = False
                    blnFatto = True
                    tempo = titolo + vbCrLf + vbCrLf + tempo 'Chr(10)
                End If
                If E <> 4 Then
                    If tempo <> "" Then
                        'tempo += Chr(10) + Chr(9) + Chr(9) + Chr(9)
                        tempo = Ripulisci(tempo) & vbCrLf + Chr(9) + Chr(9) + Chr(9) + Chr(9)
                    End If
                    E = 4
                End If
                tempo = tempo & RTB.SelectedText
            ElseIf c = ColEv5 Then
                If blnTitolo = True Then
                    blnTitolo = False
                    blnFatto = True
                    tempo = titolo + vbCrLf + vbCrLf + tempo 'Chr(10)
                End If
                If E <> 5 Then
                    If tempo <> "" Then
                        'tempo += Chr(10) + Chr(9) + Chr(9) + Chr(9)
                        tempo = Ripulisci(tempo) & vbCrLf + Chr(9) + Chr(9) + Chr(9) + Chr(9) + Chr(9)
                    End If
                    E = 5
                End If
                tempo = tempo & RTB.SelectedText
            Else
                E = -1
            End If
        Next
        tempo = Ripulisci(tempo)
        tempo = tempo.Replace(Chr(9), Freccia)
        RTB.SelectionLength = 0
        Return tempo
    End Function

    Sub EvidenziaCancella()
        RTB.SelectionBackColor = ColoreSfondo
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub Evidenzia0()
        SistemaSelezione(RTB)
        RTB.SelectionBackColor = ColEv0
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub Evidenzia1()
        SistemaSelezione(RTB)
        RTB.SelectionBackColor = ColEv1
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub Evidenzia2()
        SistemaSelezione(RTB)
        RTB.SelectionBackColor = ColEv2
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub Evidenzia3()
        SistemaSelezione(RTB)
        RTB.SelectionBackColor = ColEv3
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub Evidenzia4()
        SistemaSelezione(RTB)
        RTB.SelectionBackColor = ColEv4
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub Evidenzia5()
        SistemaSelezione(RTB)
        RTB.SelectionBackColor = ColEv5
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub Evidenzia(f As Integer)
        If RTB.SelectionStart > 1 Then
            SistemaSelezione(RTB)
        End If
        Select Case f
            Case 0 : RTB.SelectionBackColor = ColEv0
            Case 1 : RTB.SelectionBackColor = ColEv1
            Case 2 : RTB.SelectionBackColor = ColEv2
            Case 3 : RTB.SelectionBackColor = ColEv3
            Case 4 : RTB.SelectionBackColor = ColEv4
            Case 5 : RTB.SelectionBackColor = ColEv5
        End Select
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub DisEvidenziaTutto()
        RTB.SelectAll()
        RTB.SelectionBackColor = ColoreSfondo
        RTB.SelectionLength = 0
        qd = 0
    End Sub

    Private Sub btnF0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF0.Click
        Evidenzia0()
    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        Evidenzia1()
    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        Evidenzia2()
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        Evidenzia3()
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        Evidenzia4()
    End Sub

    Private Sub btnAnnullaMappa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnullaMappa.Click
        If RTB1.Text <> "" Then
            RTB.Rtf = RTB1.Rtf
        End If
        'RTB1.Clear()
        'If tmpRTF <> "" Then
        'RTB.Rtf = tmpRTF
        'End If
        'tmpRTF = ""
    End Sub

    Private Sub btnM1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnM1.Click
        'tmpRTF = RTB.Rtf
        RTB1.Rtf = RTB.Rtf
         CreaLaMappa2()
    End Sub

    Private Sub btnM2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnM2.Click
        CreaLaMappa()
    End Sub

    Private Sub RTB_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RTB.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        If KeyCode = Keys.F1 Then
            Evidenzia0()
        End If
        If KeyCode = Keys.F2 Then
            Evidenzia1()
        End If
        If KeyCode = Keys.F3 Then
            Evidenzia2()
        End If
        If KeyCode = Keys.F4 Then
            Evidenzia3()
        End If
        If KeyCode = Keys.F5 Then
            Evidenzia4()
        End If
        If KeyCode = Keys.F6 Then
            Evidenzia5()
        End If
        If KeyCode = Keys.Tab Then

            RTB.Focus()
            Dim i As Integer = RTB.SelectionStart - 1
            RTB.Text = RTB.Text.Replace(Chr(9), "")
            RTB.SelectionStart = i
            If e.Modifiers = Keys.Shift Then
                CancellaFreccia()
            Else
                AggiungiFreccia()
            End If
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        frmLeggiConMe.Show()
        Me.Hide()
    End Sub

    Sub fnAnnulla()
        If RTB.CanUndo Then
            RTB.Undo()
        End If
    End Sub

    Sub fnRipristina()
        If RTB.CanRedo Then
            RTB.Redo()
        End If
    End Sub

    Sub fnTaglia()
        If RTB.SelectedText <> "" Then
            RTB.Cut()
        End If
    End Sub

    Sub fnCopia()
        RTB.Copy()
    End Sub

    Sub fnIncolla()
        If My.Computer.Clipboard.ContainsText Or My.Computer.Clipboard.ContainsImage Then
            RTB.Paste()
        End If
    End Sub

    Private Sub Annulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annulla.Click
        fnAnnulla()
    End Sub

    Private Sub Ripristina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ripristina.Click
        fnRipristina()
    End Sub

    Private Sub Taglia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Taglia.Click
        fnTaglia()
    End Sub

    Private Sub Copia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copia.Click
        fnCopia()
    End Sub

    Private Sub Incolla_Tutto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Incolla_Tutto.Click
        fnIncolla()
    End Sub
   
    Private Sub btnSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        SalvaDocumento()
    End Sub

    Private Sub SalvaDocumento()

        Dim saveRTB As New SaveFileDialog()
        saveRTB.Filter = "RTF files (*.rtf)|*.rtf|txt files (*.txt)|*.txt"
        saveRTB.FilterIndex = 1
        saveRTB.InitialDirectory = TrovaCartellaDOC()
        saveRTB.RestoreDirectory = True
        'saveRTB.FileName = IO.Path.GetFileNameWithoutExtension(NomeDocumento)

        If saveRTB.ShowDialog() = DialogResult.OK Then
            Dim nf As String = saveRTB.FileName
            Try
                If IO.Path.GetExtension(nf) = ".rtf" Then
                    RTB.SaveFile(nf, RichTextBoxStreamType.RichText)
                Else
                    RTB.SaveFile(nf, RichTextBoxStreamType.PlainText)
                End If
                Dim i As Integer = InStrRev(nf, "\")
                'NomeDocumento = IO.Path.GetFileName(nf)
                'Me.Text = "LeggiXme_SP - " & NomeDocumento
            Catch ex As Exception
                MsgBox("Errore nel salvataggio del file", MsgBoxStyle.Critical)
            End Try
        End If

    End Sub

    Private Sub btnLeggi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeggi.Click
        Leggi()
    End Sub

    Sub Leggi()
        FermaVoce()
        If RTB.Text = "" Then
            SenzaEco("Non c'è nulla da leggere")
            Exit Sub
        End If
        Dim t As String = ""
        zeppa = RTB.SelectionStart
        inizio = RTB.SelectionStart
        lungh = RTB.SelectionLength
        If RTB.SelectedText <> "" Then
            t = RTB.SelectedText
        Else
            t = Mid(RTB.Text, zeppa + 1, Len(RTB.Text) - zeppa)
        End If
        If t <> "" Then
            ConEco(RTB, t)
            If lungh <> 0 Then
                RTB.SelectionStart = inizio
                RTB.SelectionLength = lungh
            End If
        End If
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        FermaVoce()
    End Sub

    Private Sub btnFermatutto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FermaVoce()
    End Sub

    Private Sub btnLeggiTutto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Leggi()
    End Sub

    Private Sub ToolStripCheckBox1_Click(sender As Object, e As EventArgs) Handles btnControlla.Click
        If RTB1.Visible = True Then
            RTB1.Visible = False
            RTB.Width = Me.Width - 10
        Else
            RTB.Width = Me.Width / 2 - 4
            RTB1.Visible = True
            RTB1.Left = Me.Width / 2 - 4
            RTB1.Width = Me.Width / 2 - 10
        End If

    End Sub

    Private Sub btnZoomPiu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnZoomPiu.Click
        If RTB.ZoomFactor < 5 Then
            RTB.ZoomFactor = CSng(RTB.ZoomFactor + 0.1)
            FattoreZoom = RTB.ZoomFactor
            RTB1.ZoomFactor = FattoreZoom
        End If
    End Sub

    Private Sub btnZoomMeno_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnZoomMeno.Click
        If RTB.ZoomFactor > 0.2 Then
            RTB.ZoomFactor = CSng(RTB.ZoomFactor - 0.1)
            FattoreZoom = RTB.ZoomFactor
            RTB1.ZoomFactor = FattoreZoom
        End If
    End Sub

    Private Sub btnZoomVia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnZoomVia.Click
        RTB.ZoomFactor = 1
        FattoreZoom = 1
        RTB1.ZoomFactor = FattoreZoom
    End Sub

    Private Sub btnF10_Click(sender As Object, e As EventArgs) Handles btnF10.Click
        EvidenziaCancella()
    End Sub

    Private Sub btnF5_Click(sender As Object, e As EventArgs) Handles btnF5.Click
        Evidenzia5()
    End Sub

    Private Sub btnCancella_Click(sender As Object, e As EventArgs) Handles btnCancella.Click
        CancellaFreccia()
    End Sub

    Sub CancellaFreccia()
        RTB.Focus()
        SendKeys.SendWait("{HOME}")
        RTB.SelectionLength = 4
        If RTB.SelectedText = Freccia Then RTB.SelectedText = "" Else RTB.SelectionLength = 0
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        AggiungiFreccia()
    End Sub

    Sub AggiungiFreccia()
        RTB.Focus()
        SendKeys.SendWait("{HOME}")
        Dim i As Integer = RTB.SelectionStart
        RTB.SelectionLength = 0
        RTB.SelectedText = Freccia
        RTB.SelectionStart = i + 4
        RTB.Focus()
    End Sub

    Private Sub RTB_TextChanged(sender As Object, e As EventArgs) Handles RTB.TextChanged

    End Sub

    Private Sub AutoVerbMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AutoVerbMenu.Opening

    End Sub

    Sub SwapLinesSu()
        Dim NumLinea As Integer = RTB.GetLineFromCharIndex(RTB.SelectionStart)
        Dim riga() As String = RTB.Lines
        If NumLinea < RTB.Lines.Count - 1 Then

            'MsgBox(RTB.Lines(NumLinea))
            Dim tp As String = riga(NumLinea)
            riga(NumLinea) = riga(NumLinea + 1)
            riga(NumLinea + 1) = tp
            RTB.Lines = riga
            Dim testo As String = RTB.Lines(NumLinea + 1)
            RTB.SelectionStart = InStr(RTB.Text, testo) '+ 1
            RTB.SelectionLength = 0
        End If
    End Sub

    Sub SwapLinesGiu()
        Dim NumLinea As Integer = RTB.GetLineFromCharIndex(RTB.SelectionStart)
        Dim riga() As String = RTB.Lines
        If NumLinea > 0 Then

            'MsgBox(RTB.Lines(NumLinea))
            Dim tp As String = riga(NumLinea)
            riga(NumLinea) = riga(NumLinea - 1)
            riga(NumLinea - 1) = tp
            RTB.Lines = riga
            Dim testo As String = RTB.Lines(NumLinea - 1)
            RTB.SelectionStart = InStr(RTB.Text, testo) '+ 1
            RTB.SelectionLength = 0
        End If
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click
        SwapLinesSu()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        SwapLinesGiu()
    End Sub

    Private Sub ScambiaLineeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScambiaLineeToolStripMenuItem.Click
        SwapLinesSu()
    End Sub

    Private Sub ScambiaLineeSuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ScambiaLineeSuToolStripMenuItem.Click
        SwapLinesGiu()
    End Sub

    Sub ApriMM()

        Dim apriRTB As New OpenFileDialog()
        apriRTB.Filter = "file RTF|*.rtf"
        apriRTB.FilterIndex = 1
        apriRTB.InitialDirectory = TrovaCartellaDOC()
        apriRTB.RestoreDirectory = True

        If apriRTB.ShowDialog() = DialogResult.OK Then
            Try
                If InStr(LCase(apriRTB.FileName), ".rtf") > 0 Then
                    RTB.LoadFile(apriRTB.FileName, RichTextBoxStreamType.RichText)
                ElseIf InStr(LCase(apriRTB.FileName), ".docx") > 0 Then
                    RTB.Text = ExtractText(apriRTB.FileName)
                Else
                    RTB.LoadFile(apriRTB.FileName, RichTextBoxStreamType.PlainText)
                End If
            Catch er As Exception
                MsgBox("Errore nell'apertura di " & apriRTB.FileName, MsgBoxStyle.Critical)
            End Try
        End If
    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs) Handles ToolStripButton4.Click
        ApriMM()
    End Sub
End Class
