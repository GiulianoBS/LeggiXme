Imports System.Collections.ObjectModel

Public Class frmPDF
    Dim proc As Process
    Dim mioHandle As IntPtr, altroHandle As IntPtr, PuntaFinestra As IntPtr, handleCasella As IntPtr
    Dim NomeApplicazione As String
    'Private WithEvents Voice As SpeechSynthesizer
    Dim voce As Integer = 0
    Private blnStoLeggendo As Boolean = False
    Private blnInPausa As Boolean = False
    Private NumParte As Integer = 0
    Private blnPiuParti As Boolean = False
    Private NomeProgrammaPDF As String = ""
    Dim nf As String = ""
    Dim blnSalvato As Boolean = False
    Dim FileSalvato As String = ""
    Dim documentiPDF As String = ""

    Private blnInRTB As Boolean = False

    Private Processo() As String
    Dim BorderWidth As Integer = (Me.Width - Me.ClientSize.Width) / 2
    Dim TitlebarHeight As Integer = Me.Height - Me.ClientSize.Height - 2 * BorderWidth
    Dim blnChiuso As Boolean = False
    Private Const WM_SYSCOMMAND As Integer = 274
    Private Const SC_MAXIMIZE As Integer = 61488
    Private Const SC_RESTORE As Integer = &HF120
    Public blnTimerPDF As Boolean = False
    Declare Auto Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Dim FileSprotetto As String = ""
    Dim blnSenzaProtezioni As Boolean = True

    Dim MioZoom As Double = 1

    Public Shared GetProcesses()() As Process

    Private Sub EseguiPDF()
        On Error Resume Next
        If proc.Handle = Nothing Then
            proc = Process.Start(Percorso & "\Manuale_LeggiXme.pdf")
            Threading.Thread.Sleep(500)
            altroHandle = proc.MainWindowHandle
            SetParent(proc.MainWindowHandle, Me.pnPDF.Handle)
            SendMessage(proc.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
        End If
    End Sub

    Private Sub frmPDF_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmLeggiConMe.AggiornaVoce()
        frmLeggiConMe.Show()
    End Sub

    Private Sub FormPDF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        ChiudiFinestra()
        proc.CloseMainWindow()
        proc.Kill()
        Schermo.Hide()

    End Sub

    Private Sub LeggiProcessiAttivi()
        If blnChiuso Then Exit Sub

        Dim procList() As Process = Process.GetProcesses()
        Dim i As Integer = 0
        ReDim Processo(0)
        For Each p As Process In procList ' i + 1
            ReDim Preserve Processo(i)
            Processo(i) = p.ProcessName
            i = i + 1
        Next
    End Sub

    Private Sub frmPDF_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        ImpostaCarattere(RTB)
        LavagnaRTB(RTB)
    End Sub

    Private Sub frmPDF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If NumVoci > 0 Then
            CreaMenuVoci(MenuVoci)
            'For i As Integer = 0 To MenuVoci.Items.Count - 1
            'If MenuVoci.Items(i).ToString = NomeCorto(intParlante) Then
            'MenuVoci.Items(i).Select()
            'cmdVoce.Image = ScegliBandiera(i)
            'lbLingua.Text = AssegnaVoce(i)
            'End If
            'Next
            MenuVoci.Items(intParlante).Select()
            cmdVoce.Image = ScegliBandiera(intParlante)
            lbLingua.Text = AssegnaVoce(intParlante)
        Else
            MenuVoci.Items.Add("Nessuna Voce")
        End If

        mioHandle = GetForegroundWindow
        'btnOCR.Visible = True
        If CePDFViewer() = False Then
            'btnOCR.Visible = False
        End If
        'Voice = New SpeechSynthesizer
        RTB.Font = FontPredefinito
        RTB.ZoomFactor = MioZoom
        RTB.Refresh()
        'If blnVoce = True Then SistemaVoce()
        Ridimensiona()
        If AmpiezzaPannelloPDF = -1 Then
            AmpiezzaPannelloPDF = pnComandi.Width
        Else
            pnComandi.Width = AmpiezzaPannelloPDF
        End If
        ckTesto.Checked = True
        LavagnaRTB(RTB)

        documentiPDF = TrovaCartellaPDF()

        RTB.BackColor = ColoreSfondo

        trVelocita.Value = Velocita
        'SistemaCaratteri()
        Timer1.Enabled = True

    End Sub

    Private Sub frmPDF_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Me.WindowState = FormWindowState.Maximized

        'MsgBox(Me.Width & vbCrLf & pnPDF.Width & vbCrLf & AmpiezzaPannelloPDF)
        If AmpiezzaPannelloPDF = -1 Then AmpiezzaPannelloPDF = 250

        pnPDF.Width = Me.Width - AmpiezzaPannelloPDF - 20
        RTB.Height = Me.Height - RTB.Top - 60

        Exit Sub
        Schermo.Location = pnPDF.Location
        If SchermoAttivoP = True Then
            AttivaSchermo()
        Else
            DisAttivaSchermo()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '
        Timer1.Enabled = False
        Me.WindowState = FormWindowState.Maximized

        If blnManuale = False Then
            CaricaFile()
        Else
            'Aprifile(Percorso & "\Manuale_LeggiXme.pdf")
        End If
        Schermo.Show()
        DisAttivaSchermo()

    End Sub

    Private Sub btnOpzioniVisualizzazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpzioniVisualizzazione.Click
        'If RTB.Text = "" Then Exit Sub
        'Leggi()
        pnAllarga.Top = 0

        AmpiezzaPannelloPDF = pnComandi.Width
        pnAllarga.Visible = True
    End Sub

    Private Sub cmdLeggiVerde_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeggiVerde.Click
        CopiaTesto()
        Leggi()
    End Sub

    Private Sub CopiaTesto()
        Dim tmp As String
        SetForegroundWindow(altroHandle)
        Threading.Thread.Sleep(50)
        SendKeys.SendWait("^(c)")
        Threading.Thread.Sleep(20)

        tmp = Clipboard.GetText
        tmp = filtrata(tmp)
        tmp = tmp.Replace("É", "È")
        RTB.Text = tmp
        RTB.SelectionStart = 0
        RTB.SelectionLength = 0
        ImpostaInterlinea(RTB)
        If spaziatura = 2 Then
            Dim t As String = RTB.Text
            RTB.Text = MettiDoppiSpazi(t)
        End If
    End Sub

    Sub Leggi()

        Dim t As String = RTB.Text
        If t = "" Then Exit Sub

        blnInPausa = False

        t = RTB.Text
        zeppa = 0
        ConEco(RTB, t)

    End Sub

    Sub Aprifile(ByVal nf As String)

        Dim i As Integer = nf.LastIndexOf(".")
        Dim esten As String = Mid(nf, i + 1)
        Dim a As String = TrovaProgrammaAssociato(esten)

        If a = "" Then
            MsgBox("NESSUN PROGRAMMA E' ASSOCIATO A QUESTO TIPO DI FILE", MsgBoxStyle.Critical)
            Exit Sub
        End If

        NomeApplicazione = UCase(Mid(a, 1, a.LastIndexOf(".")))

        On Error Resume Next
        If proc IsNot Nothing Then
            proc.Kill()
            proc.CloseMainWindow()
            proc.Close()
            proc = Nothing
        End If
        LeggiProcessiAttivi()
        proc = Process.Start(nf)
        Dim P As String = proc.ProcessName

        ChiudiProc(proc.ProcessName)

        proc = Process.Start(nf)
        Threading.Thread.Sleep(1500)
        altroHandle = proc.MainWindowHandle
        Timer2.Enabled = True

    End Sub

    Sub ChiudiProc(ByVal Proc As String)

        Dim m As String = ""

        Dim procList() As Process = Process.GetProcesses()
        Dim i As Integer = 0
        ReDim Processo(0)
        For Each p As Process In procList ' i + 1
            If p.ProcessName = Proc Then
                m = m + p.ProcessName + vbCrLf
                p.CloseMainWindow()
                Try
                    p.Kill()
                Catch ex As Exception
                End Try
            End If
        Next

    End Sub

    Sub AprifilePDF(ByVal nf As String)

        If CePDFViewer() = False Then
            Aprifile(nf)
            Exit Sub
        End If

        Dim volte As Integer = 0
        On Error Resume Next
        If proc IsNot Nothing Then
            proc.Kill()
            proc.CloseMainWindow()
            proc.Close()
            proc = Nothing
        End If
        On Error GoTo 0

        Dim processo As String = PDFXCviewer()

        nf = Chr(34) & nf & Chr(34)

        proc = Process.Start(processo, nf)
        ChiudiProc(proc.ProcessName)
        blnChiuso = True

DaQui:
        proc = Process.Start(processo, nf)
        Do
            volte += 1
            Threading.Thread.Sleep(3000)
            altroHandle = proc.MainWindowHandle
            If volte > 4 Then Exit Do
        Loop Until altroHandle <> 0

        If altroHandle = 0 Then
            Exit Sub
        Else
            Timer3.Enabled = True
        End If

    End Sub

    Dim PrimaVolta As Boolean = True

    Private Sub CaricaFile(Optional ByVal fil As String = "")

        btnEstrai.Visible = True
        tmrPDF.Enabled = False
        ckFoto.Checked = False
        nf = ""
        If FileDaAprire = "" Then
            Dim openFileDialog1 As New OpenFileDialog()
            If PrimaVolta = True Then
                openFileDialog1.InitialDirectory = documentiPDF
                PrimaVolta = False
            Else
                openFileDialog1.InitialDirectory = ""
            End If
            openFileDialog1.Filter = "file PDF (*.PDF)|*.pdf"
            openFileDialog1.FilterIndex = 2
            openFileDialog1.RestoreDirectory = True

            If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                nf = openFileDialog1.FileName
                FileDaAprire = nf
            End If
        Else
            nf = FileDaAprire
        End If

        If nf <> "" Then

            blnSenzaProtezioni = modPdfManipulation2.SenzaProtezioni(nf)
            If blnSenzaProtezioni = False Then
                SenzaEco("Attenzione, documento protetto! Vuoi proseguire?")
                Dim res As Integer = MsgBox("ATTENZIONE! Questo documento è protetto." & vbCrLf & "Vuoi comunque leggerlo, anche se non potrai usare il testo selezionato?", MsgBoxStyle.Critical Or MsgBoxStyle.YesNo)
                If res = vbNo Then Exit Sub
            End If

            btnSproteggi.Visible = Not blnSenzaProtezioni
            btnEstrai.Visible = blnSenzaProtezioni
            btnIncolla.Visible = blnSenzaProtezioni

            If blnSenzaProtezioni = False Then
                ApriSprotetto()
            Else
                If CePDFViewer() = True Then
                    AprifilePDF(nf)
                Else
                    Aprifile(nf)
                End If
            End If
        End If

    End Sub

    Private Sub cmdApri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApri.Click
        FileDaAprire = ""
        CaricaFile()
    End Sub

    Sub FermaLettura()
        blnPiuParti = False
        Try
            FermaVoce()
            blnStoLeggendo = False
            blnInPausa = False
        Catch e As Exception
            MsgBox(e.Message)
        End Try

        RTB.SelectionLength = 0
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        blnStoLeggendo = False
        FermaLettura()
    End Sub

    Private Sub btnTorna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTorna.Click
        TornaHome()
    End Sub

    Sub TornaHome()
        tmrPDF.Enabled = False
        FermaLettura()
        ckFoto.Checked = False
        frmLeggiConMe.lblVelocita.Text = Velocita.ToString
        frmLeggiConMe.Show()
        Me.Hide()
        Schermo.Hide()
        frmLeggiConMe.RTB.Focus()
    End Sub

    Private Sub btnIncolla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncolla.Click

        If blnSenzaProtezioni = False Then Exit Sub

        If SchermoAttivoP = True Then
            Schermo.Visible = False
            Dim ok As Boolean = AcquisisciImmagine(InizioImmagine, MisuraImmagine)
            Schermo.Visible = True
            If ok = True Then
                frmLeggiConMe.RTB.Paste()
                My.Computer.Audio.Play(My.Resources.clic, AudioPlayMode.WaitToComplete)
            Else
                My.Computer.Audio.Play(My.Resources.bong, AudioPlayMode.Background)
                MsgBox("Devi trascinare il mouse per selezionare" & vbCrLf & "il rettangolo che vuoi salvare come immagine", MsgBoxStyle.Exclamation)
            End If
        Else
            CopiaTesto()
            If RTB.Text = "" Then Exit Sub
            If RTB.SelectionLength > 0 Then
                frmLeggiConMe.RTB.SelectedText = RTB.SelectedText
            Else
                frmLeggiConMe.RTB.SelectedText = RTB.Text
            End If
            My.Computer.Audio.Play(My.Resources.splash, AudioPlayMode.WaitToComplete)
        End If
        frmLeggiConMe.RTB.AppendText(System.Environment.NewLine)
        Schermo.Sel.Width = 0
        Schermo.Sel.Height = 0
    End Sub

    Private Sub btnCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If RTB.Text = "" Then Exit Sub
        If RTB.SelectionLength > 0 Then
            Clipboard.SetText(RTB.SelectedText)
        Else
            Clipboard.SetText(RTB.Text)
        End If

    End Sub

    Private Function AcquisisciImmagine(ByVal i As Point, ByVal m As Size) As Boolean
        Try
            m.Width = m.Width * Risoluzione / 100
            m.Height = m.Height * Risoluzione / 100
            Dim bmp As New Bitmap(m.Width, m.Height)
            Dim gfx As Graphics = System.Drawing.Graphics.FromImage(bmp)
            gfx.CopyFromScreen(i.X * Risoluzione / 100, i.Y * Risoluzione / 100, 0, 0, m, CopyPixelOperation.MergeCopy)
            'gfx.CopyFromScreen(i.X, i.Y, 0, 0, m, CopyPixelOperation.MergeCopy)
            gfx.Dispose()
            Clipboard.SetImage(bmp)
            RidimensionaInClipboard()
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub Topo_MouseDown()
        InizioImmagine = Cursor.Position
    End Sub

    Private Sub Topo_MouseUp()
        FineImmagine = Cursor.Position
    End Sub

    Private Sub AttivaSchermo()
        SchermoAttivoP = True
        Schermo.Show()
        Schermo.Location = pnPDF.Location
        'Schermo.Size = pnPDF.Size
        Schermo.Width = pnPDF.Width - 20
        Schermo.Height = pnPDF.Height - 10
    End Sub

    Private Sub DisAttivaSchermo()
        SchermoAttivoP = False
        Schermo.Location = pnPDF.Location
        Schermo.Width = pnPDF.Width
        Schermo.Height = TitlebarHeight * 2 + 5
    End Sub

    Sub NascondiSchermo()
        SchermoAttivoP = False
        Schermo.Hide()
    End Sub

    Private Sub pnPDF_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnPDF.Resize
        If SchermoAttivoP = True Then
            Schermo.Location = pnPDF.Location
            Schermo.Size = pnPDF.Size
        Else
            Schermo.Width = pnPDF.Width
        End If
    End Sub

    Private Sub Ridimensiona()
        Dim nsize As Size = Me.Size
        nsize.Height = My.Computer.Screen.WorkingArea.Height + BorderWidth * 2 'TitlebarHeight
        Me.MaximumSize = nsize
        Me.WindowState = FormWindowState.Normal
    End Sub

    Private Sub ckFoto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ckFoto.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("modalità seleziona immagine.")
        End If
    End Sub

    Private Sub ckFoto_Click(sender As Object, e As EventArgs) Handles ckFoto.Click
        ckTesto.Checked = False
        ckFoto.Checked = True
        Threading.Thread.Sleep(200)
        TopoAttivo = ckFoto.Checked
        AttivaSchermo()
    End Sub

    Private Sub ckTesto_Click(sender As Object, e As EventArgs) Handles ckTesto.Click
        DisAttivaSchermo()
        ckFoto.Checked = False
        ckTesto.Checked = True
    End Sub

    Private Sub ckTesto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ckTesto.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("modalità seleziona testo.")
        End If
    End Sub

    Private Sub btnIncolla_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnIncolla.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("incolla nel documento l'immagine selezionata o il testo.")
        End If
    End Sub

    Private Sub btnTorna_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTorna.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("torna alla schermata principale.")
        End If
    End Sub

    Private Sub cmdLeggi_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdLeggiVerde.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("incolla il testo selezionato nel riquadro qui sotto.")
        End If
    End Sub

    Private Sub cmdLeggiTesto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnOpzioniVisualizzazione.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("opzioni di visualizzazione.")
        End If
    End Sub

    Private Sub cmdStop_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdStop.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("ferma la lettura.")
        End If
    End Sub

    Private Sub cmdPausa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPausa.Click
        PausaLettura()
    End Sub

    Private Sub cmdPausa_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdPausa.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("mette in pausa la lettura.")
        End If
    End Sub

    Sub PausaLettura()

        Try
            If blnInPausa = False Then
                blnInPausa = True
                Pausa()
            Else
                blnInPausa = False
                Riprendi()
            End If
        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Sub

    Private Sub cmdImposta_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdApri.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("apri documento.")
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

        Dim tmp As IntPtr = GetForegroundWindow
        Dim strProg As String = UCase(GetWT(tmp))
        blnTimerPDF = False
        Dim res As Integer

        If Mid(strProg, 1, 5) = Mid(NomeApplicazione, 1, 5) Then
            Timer2.Enabled = False
            Me.TopMost = True
            Me.TopMost = False
        Else
            Exit Sub
        End If

        NomeProgrammaPDF = Mid(strProg, 1, 5)

        res = SetParent(tmp, Me.pnPDF.Handle)
        SendMessage(tmp, WM_SYSCOMMAND, SC_MAXIMIZE, 0)

        If LarghezzaPDF(tmp) > (pnPDF.Width + 10) Then
            RidimensionaPDF(tmp)
        End If

        If res = 0 Then
            Timer2.Interval = 1000
        Else
            Timer2.Enabled = False
            altroHandle = tmp
            Me.TopMost = True
            Me.TopMost = False
        End If

    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        'Dim tmp As IntPtr = altroHandle
        blnTimerPDF = False
        altroHandle = proc.MainWindowHandle
        If altroHandle = 0 Then
            altroHandle = proc.Handle
        End If
        Dim res As Integer

        res = SetParent(altroHandle, Me.pnPDF.Handle)

        SendMessage(altroHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)

        If LarghezzaPDF(altroHandle) > (pnPDF.Width + 10) Then
            RidimensionaPDF(altroHandle)
        End If
        '
        If res <> 0 Then
            Timer3.Enabled = False
            'altroHandle = tmp
            'Me.TopMost = True
            Me.TopMost = False
        End If
    End Sub

    Sub RidimensionaPDF(ByVal tmp As IntPtr)
        SendMessage(tmp, WM_SYSCOMMAND, SC_RESTORE, 0)
        MoveWindow(tmp, pnPDF.Left, pnPDF.Top, pnPDF.Width + 8, pnPDF.Height + 10, True)
        SetWindowPos(tmp, HWND_TOP, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOREPOSITION Or SWP_NOSIZE Or SWP_NOSENDCHANGING)
        'blnTimerPDF = True
    End Sub

    Private Function LarghezzaPDF(ByVal PdfHandle As Integer) As Integer

        Dim PDF As RECT
        GetWindowRect(PdfHandle, PDF)
        Return PDF.Right

    End Function

    Private Sub ChiudiFinestra()
        SendMessage(altroHandle, WM_SYSCOMMAND, SC_CLOSE, 0)
    End Sub
    Private Sub RTB_BorderStyleChanged(sender As Object, e As EventArgs) Handles RTB.BorderStyleChanged
        If RTB.BorderStyle = BorderStyle.Fixed3D Then
            'Voice_SpeakCompleted()
        End If
    End Sub

    Private Sub RTB_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RTB.MouseDown
        If blnStoLeggendo = True Then FermaLettura()
    End Sub

    Private Sub RTB_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RTB.MouseUp
        blnInRTB = True
    End Sub

    Private Sub RTB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RTB.TextChanged
        If blnStoLeggendo = True Then FermaLettura()
    End Sub

    Private Sub frmPDF_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.VisibleChanged
        If Me.Visible = True Then
            If blnManuale = True Then
                blnManuale = False
                Aprifile(Percorso & "\Manuale_LeggiXme.pdf")
                Schermo.Show()
                DisAttivaSchermo()
            End If
        End If
    End Sub

    Private Sub btnSproteggi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSproteggi.Click
        ChiudiProc(proc.ProcessName)
        Try
            ApriSprotetto()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ApriSprotetto()
        FileSprotetto = modPdfManipulation2.RemoveRestrictions(FileDaAprire, True)
        If FileSprotetto <> "" Then
            AprifilePDF(FileSprotetto)
            blnSenzaProtezioni = True
            btnSproteggi.Visible = False
            btnEstrai.Visible = False
        End If
        'MsgBox(ok & FileDaAprire)
        'FileDaAprire = ""
        'frmImgPdf.ShowDialog()
        'If FileDaAprire <> "" Then
        'CaricaFile()
        'AprifilePDF(FileDaAprire)
        'End If
    End Sub

    Private Sub RisistemaPDF()
        MoveWindow(altroHandle, pnPDF.Left, pnPDF.Top, pnPDF.Width + 8, pnPDF.Height + 10, True)
        SetWindowPos(altroHandle, HWND_BOTTOM, 0, 0, 0, 0, SWP_NOMOVE Or SWP_NOREPOSITION Or SWP_NOSIZE Or SWP_NOSENDCHANGING)
    End Sub

    Private Sub tmrPDF_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPDF.Tick
        RisistemaPDF()
    End Sub

    Private Sub txPagg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txPagg.KeyPress
        If InStr("1234567890 " & Chr(8), e.KeyChar) = 0 Then e.KeyChar = ""
    End Sub

    Private Sub btnEstrai_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEstrai.Click
        pnEstraiPDF.Top = 0
        txPagg.Text = ""
        pnEstraiPDF.Visible = True
        btnSalvaApri.Visible = False
        FileSalvato = ""
        lblFile.Text = ""
        txPagg.Focus()
    End Sub

    Private Sub btnAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnulla.Click
        FileSalvato = ""
        btnSalvaApri.Visible = False
        pnEstraiPDF.Visible = False
    End Sub

    Function SproteggiPDF(ByVal SourceFile As String) As Boolean

        If SourceFile = "" Then
            Return False
            Exit Function
        End If
        Return modPdfManipulation2.RemoveRestrictions(SourceFile, True)

    End Function

    Public Function EstraiPaginePDF(ByVal SourceFile As String, ByVal np As String) As String

        If SourceFile = "" Then
            Return ""
            Exit Function
        End If

        Dim pageCount As Integer = 0
        Dim q As Integer = -1, l As Integer = 0
        Dim pagg() As Integer

        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Try
            reader = New iTextSharp.text.pdf.PdfReader(SourceFile)
            pageCount = reader.NumberOfPages
            reader.Close()
        Catch ex As Exception
        End Try

        If np = "" Then
            Return ""
            Exit Function
        End If

        Dim pgg() As String = np.Split(" "c)
        If pgg.Count = 0 Then
            Return ""
        End If
        For l = 0 To UBound(pgg) '- 1
            If Trim(pgg(l)) <> "" Then
                q += 1
                ReDim Preserve pagg(q)
                pagg(q) = CInt(pgg(l))
                If pagg(q) > pageCount Then
                    MsgBox(pgg(l) & ": numero di pagina fuori misura", MsgBoxStyle.Critical)
                    Return ""
                    Exit Function
                End If
            End If
        Next

        Dim ext As String = IO.Path.GetExtension(SourceFile)

        l = Len(SourceFile)
        Dim aggiunta As String = "_pagg_" & pagg(0).ToString & "-" & pagg(q).ToString
        If pagg(0) = pagg(q) Then
            aggiunta = "_pag_" & pagg(0).ToString
        End If

        Dim fn As String = IO.Path.GetFileName(SourceFile)


        Dim OutPutFile As String = documentiPDF & "\" & Mid(fn, 1, l - 4) & aggiunta & ".pdf"
        Dim fil As String = IO.Path.GetFileName(OutPutFile)

        If Dir(OutPutFile) <> "" Then
            Dim res As Integer = MsgBox("ATTENZIONE!" & vbCrLf & "Il file " & UCase(fil) & " esiste già." & vbCrLf & "Vuoi sovrascriverlo?", MsgBoxStyle.Critical Or MsgBoxStyle.YesNo)
            If res = vbNo Then
                Return ""
                Exit Function
            End If
        End If

        modPdfManipulation2.ExtractPdfPage(SourceFile, pagg, OutPutFile)

        Return OutPutFile

    End Function

    Private Sub btnSalvaApri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvaApri.Click
        'Dim f As String = EstraiPaginePDF(nf, Trim(txPagg.Text))
        pnEstraiPDF.Visible = False
        If FileSalvato <> "" Then
            'tmrPDF.Enabled = False
            blnSalvato = True
            If CePDFViewer() = True Then
                AprifilePDF(FileSalvato)
            Else
                Aprifile(FileSalvato)
            End If
            FileSalvato = ""
            btnSalvaApri.Visible = False
        End If
    End Sub

    Private Sub btnSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        FileSalvato = EstraiPaginePDF(nf, Trim(txPagg.Text))
        If FileSalvato <> "" Then
            btnSalvaApri.Visible = True
            lblFile.Text = Mid(FileSalvato, FileSalvato.LastIndexOf("\") + 2)
        End If
        'pnEstraiPDF.Visible = False
    End Sub

    Private Sub btnEstrai_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnEstrai.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("estrai pagine dal libro.")
        End If

    End Sub

    Private Sub btnSalva_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSalva.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("salva le pagine.")
        End If

    End Sub

    Private Sub btnSalvaApri_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSalvaApri.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("apri le pagine salvate.")
        End If

    End Sub

    Private Sub btnAnnulla_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAnnulla.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("chiudi.")
        End If
    End Sub

    Private Sub btnAllarga_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllarga.Click
        If pnComandi.Width < pnPDF.Width Then
            pnComandi.Width += 10
            pnPDF.Width -= 10
            RidimensionaPDF(altroHandle)
        End If
    End Sub

    Private Sub btnStringi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStringi.Click
        If pnComandi.Width > 250 Then
            pnComandi.Width -= 10
            pnPDF.Width += 10
            RidimensionaPDF(altroHandle)
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChiudiAllarga.Click
        pnAllarga.Visible = False
        AmpiezzaPannelloPDF = pnComandi.Width
    End Sub


    Private Sub btnZoomPiu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomPiu.Click
        If RTB.ZoomFactor < 5 Then
            RTB.ZoomFactor = CSng(RTB.ZoomFactor + 0.1)
            MioZoom = RTB.ZoomFactor
        End If
    End Sub

    Private Sub btnZoomMeno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomMeno.Click
        If RTB.ZoomFactor > 0.2 Then
            RTB.ZoomFactor = CSng(RTB.ZoomFactor - 0.1)
            MioZoom = RTB.ZoomFactor
        End If
    End Sub

    Private Sub btnZoomVia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomVia.Click
        RTB.ZoomFactor = 1
    End Sub

    Private Sub btnZoomPiu_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZoomPiu.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("aumenta lo zoom.")
        End If
    End Sub

    Private Sub btnZoomMeno_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZoomMeno.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("diminuisci lo zoom.")
        End If
    End Sub

    Private Sub btnZoomVia_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZoomVia.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("visualizzazione normale.")
        End If
    End Sub

    Private Sub btnAllarga_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAllarga.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("allarga il pannello.")
        End If
    End Sub

    Private Sub btnStringi_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnStringi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("restringi il pannello.")
        End If
    End Sub

    Private Sub btnChiudiAllarga_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnChiudiAllarga.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("finito.")
        End If
    End Sub

    Private Sub Label4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi(Label4.Text)
        End If
    End Sub

    Private Sub trVelocita_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trVelocita.Scroll
        Velocita = trVelocita.Value
        RegolaVelocita()
    End Sub

    Private Sub btnSproteggi_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSproteggi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("Lavora su una copia accessibile.")
        End If
    End Sub

    Private Sub cmdVoce_Click(sender As Object, e As EventArgs) Handles cmdVoce.Click
        MenuVoci.Show()
        MenuVoci.Left = cmdVoce.Left
        MenuVoci.Top = cmdVoce.Top + AltezzaCaption() + cmdVoce.Height
        MenuVoci.Left = cmdVoce.Left + pnComandi.Left
    End Sub

    Private Sub MenuVoci_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuVoci.ItemClicked
        Dim item As String = e.ClickedItem.ToString
        If item = "ANNULLA" Then Exit Sub
        Sceglivoce(item)
    End Sub

    Public Sub Sceglivoce(item As String)
        intParlante = Sceltavoce(item, MenuVoci, cmdVoce)
        cmdVoce.Image = ScegliBandiera(intParlante)
        lbLingua.Text = AssegnaVoce(intParlante)
    End Sub

End Class