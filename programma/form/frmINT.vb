Imports System.Collections.ObjectModel
Imports System.Net
Imports System.IO

Public Class frmINT
    Public procI As Process
    Dim mioHandle As IntPtr, altroHandle As IntPtr, PuntaFinestra As IntPtr
    Dim NomeApplicazione As String
    Private blnStaLeggendo As Boolean = False
    Private blnInPausa As Boolean = False
    Private NumParte As Integer = 0
    Private blnPiuParti As Boolean = False

    Private Processo() As String
    Dim BorderWidth As Integer = (Me.Width - Me.ClientSize.Width) / 2
    Dim TitlebarHeight As Integer = Me.Height - Me.ClientSize.Height - 2 * BorderWidth
    Dim blnChiuso As Boolean = False
    Private Const WM_SYSCOMMAND As Integer = 274
    Private Const SC_MAXIMIZE As Integer = 61488
    Private Const SC_RESTORE As Integer = &HF120

    Declare Auto Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Public Shared GetProcesses()() As Process

    Dim img_id As Short
    Dim Url1 As String
    Const URL As String = "https://sites.google.com/site/leggixme/"
    Const titolo As String = "Internet "
    Dim modificato As Boolean
    Const SW_SHOW As Short = 1
    Dim range As mshtml.IHTMLTxtRange
    Dim ElencoPreferiti As String = ""


    Private Sub frmINT_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'frmLeggiXme.Show()
    End Sub

    Private Sub frmINT_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        ChiudiFinestra()
        procI.CloseMainWindow()
        procI.Kill()
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

    Private Sub frmINT_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If blnEffettoLavagna = True Then
            RTB.ForeColor = ColoreSfondo
            RTB.BackColor = Color.Black
        Else
            RTB.ForeColor = Color.Black
            RTB.BackColor = ColoreSfondo
        End If

        'SistemaVoce()
    End Sub

    Private Sub frmINT_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        mioHandle = GetForegroundWindow
        'Voice = New SpeechSynthesizer
        If NumVoci > 0 Then
            CreaMenuVoci(MenuVoci)
            For ii As Integer = 0 To MenuVoci.Items.Count - 1
                If MenuVoci.Items(ii).ToString = NomeCorto(intParlante) Then
                    MenuVoci.Items(ii).Select()
                    cmdVoce.Image = ScegliBandiera(ii)
                    lbLingua.Text = AssegnaVoce(ii)
                End If
            Next
        Else
            MenuVoci.Items.Add("Nessuna Voce")
        End If
        Ridimensiona()
        'ckTesto.Checked = True
        RTB.Font = FontPredefinito
        Dim f As Integer = 0
        Dim u As String = ""
        Dim i As Integer = 0
        For i = 1 To 2
            StatusBar1.Items.Add(New System.Windows.Forms.ToolStripStatusLabel())
        Next i

        With StatusBar1.Items
            .Item(1).DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
            .Item(1).Width = 100
            .Item(2).DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.ImageAndText
        End With
        ChDrive(My.Application.Info.DirectoryPath)
        ChDir(My.Application.Info.DirectoryPath)
        'WB.Navigate(New System.Uri(My.Application.Info.DirectoryPath & "\inizio.htm"))
        CmbURL.Items.Clear()
        cbUrl.Items.Clear()

        GoTo Trap

        ElencoPreferiti = PercorsoOrtografici & "\url.elc"
        If Dir(ElencoPreferiti) = "" Then
            ElencoPreferiti = ""
            CmbURL.Items.Add(URL)
            cbUrl.Items.Add(URL)
            'MsgBox("ATTENZIONE: L'elenco dei preferiti non può essere salvato", MsgBoxStyle.Critical)
            'Exit Sub
            GoTo trap
        End If

        f = FreeFile()
        On Error GoTo Trap
        If ElencoPreferiti <> "" Then
            FileOpen(f, ElencoPreferiti, OpenMode.Input)
            While Not EOF(f)
                Input(f, u)
                If Trim(u) <> "" Then
                    CmbURL.Items.Add(Trim(u))
                    cbUrl.Items.Add(Trim(u))
                End If
            End While
            FileClose(f)
        End If
        RTB.BackColor = ColoreSfondo
Trap:
        If CmbURL.Items.Count = 0 Then CmbURL.Items.Add(URL)
        Url1 = CmbURL.Items(0)
        If DaTradurre <> "" Then
            CmbURL.Text = DaTradurre
            Vai()
            DaTradurre = ""
        End If
        'CmbURL.Text = Url1
        'Timer1.Enabled = True
        'Schermo.Show()
        DisAttivaSchermo()

        'pnComandi.Width = AmpiezzaPannelloPDF
        'pnPDF.Width = Me.Width - AmpiezzaPannelloPDF
        'Timer2.Enabled = True

        If blnEffettoLavagna = True Then
            RTB.ForeColor = ColoreSfondo
            RTB.BackColor = Color.Black
        End If

        'pnComandi.Width = AmpiezzaPannelloPDF
        'RidimensionaPDF(altroHandle)

    End Sub

    Private Sub frmINT_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize

        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Me.WindowState = FormWindowState.Maximized
        pnPDF.Width = Me.Width - 276
        RTB.Height = Me.Height - RTB.Top - 60
        'Ridimensiona()
        Exit Sub
        Schermo.Location = pnPDF.Location
        If SchermoAttivoI = True Then
            AttivaSchermo()
        Else
            DisAttivaSchermo()
        End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '
        Timer1.Enabled = False
        'RidimensionaPDF(altroHandle)
        Exit Sub

        Me.WindowState = FormWindowState.Maximized

        WB.Navigate("inizio.htm")
        Schermo.Show()
        DisAttivaSchermo()
    End Sub

    Private Sub cmdLeggi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeggiVerde.Click
        Dim tmp As String
        tmp = RecuperaTestoSelezione() ' Clipboard.GetText
        'tmp = filtrata(tmp)
        RTB.Text = tmp
        Leggi()
    End Sub

    Private Sub Leggi()

        If RTB.Text = "" Then Exit Sub
        blnStaLeggendo = True
        zeppa = RTB.SelectionStart
        'cmdLeggiBlu.Enabled = False
        'cmdLeggiVerde.Enabled = False
        blnInPausa = False
        blnStaLeggendo = True

        Dim t As String = ""
        zeppa = RTB.SelectionStart

        If RTB.SelectionLength > 0 Then
            t = RTB.SelectedText
        Else
            t = Mid(RTB.Text, zeppa + 1)
        End If

        ConEco(RTB, t)


    End Sub

    Sub Aprifile(ByVal nf As String)

        On Error Resume Next

        If procI.Handle <> Nothing Then
            procI.CloseMainWindow()
            procI.Kill()
            procI = Nothing
        End If

        LeggiProcessiAttivi()
        procI = Process.Start("naviga.exe", nf)

        Dim P As String = procI.ProcessName

        If Array.IndexOf(Processo, P) < 0 Then
            blnChiuso = True
            Threading.Thread.Sleep(1500)
            altroHandle = procI.MainWindowHandle
            SetParent(procI.MainWindowHandle, Me.pnPDF.Handle)
            SendMessage(procI.MainWindowHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
            Timer2.Enabled = True
        Else
            procI.CloseMainWindow()
            procI.Kill()
            procI = Nothing
            MsgBox("ATTENZIONE!" & vbCrLf & " DEVI CHIUDERE IL PROGRAMMA " & P)
        End If

    End Sub

    Private Sub CaricaFile()

        ckFoto.Checked = False

        Dim openFileDialog1 As New OpenFileDialog()
        openFileDialog1.InitialDirectory = ""
        openFileDialog1.Filter = "file di Internet (*.htm;*.html)|*.htm;*.html"
        openFileDialog1.FilterIndex = 2
        openFileDialog1.RestoreDirectory = True

        If openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            Dim nf As String = openFileDialog1.FileName
            'Aprifile(nf)
            WB.Navigate(nf)
        End If

    End Sub

    Private Sub cmdImposta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImposta.Click
        CaricaFile()
    End Sub

    Private Sub EvidenziaParola(ByVal Pos As Integer, ByVal Length As Integer)

        Try
            RTB.SelectionStart = Pos + zeppa
            RTB.SelectionLength = Length
            RTB.ScrollToCaret()
        Catch e As Exception
            MsgBox("Non riesco ad evidenziare le parole.")
        End Try

    End Sub

    Sub FermaLettura()
        FermaVoce()
        RTB.SelectionLength = 0
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        blnStaLeggendo = False
        blnPiuParti = False
        FermaLettura()
    End Sub

    Private Sub cmdLeggiTesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Leggi()
    End Sub

    Private Sub btnTorna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTorna.Click
        TornaHome()
    End Sub

    Sub TornaHome()
        ckFoto.Checked = False
        Schermo.Hide()
        If frmTRAD.Visible = True Then
            frmTRAD.Close()
        End If
        frmLeggiConMe.lblVelocita.Text = Velocita.ToString
        frmLeggiConMe.Show()
        frmLeggiConMe.RTB.Focus()
        'Me.Close()
        Me.Hide()
        Try
            frmTRAD.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnIncolla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncolla.Click
        If SchermoAttivoI = True Then
            Schermo.Visible = False
            AcquisisciImmagine(InizioImmagine, MisuraImmagine)
            Schermo.Visible = True
            frmLeggiConMe.RTB.Paste()
            My.Computer.Audio.Play(My.Resources.clic, AudioPlayMode.WaitToComplete)
        Else
            RTB.Text = RecuperaTestoSelezione() ' Clipboard.GetText

            If RTB.Text = "" Then Exit Sub
            If RTB.SelectionLength > 0 Then
                frmLeggiConMe.RTB.SelectedText = RTB.SelectedText
            Else
                frmLeggiConMe.RTB.SelectedText = RTB.Text
            End If
            My.Computer.Audio.Play(My.Resources.splash, AudioPlayMode.WaitToComplete)
        End If
        'frmLeggiConMe.RTB.AppendText(System.Environment.NewLine)
        Schermo.Sel.Width = 0
        Schermo.Sel.Height = 0
    End Sub

    Private Sub AcquisisciImmagine(ByVal i As Point, ByVal m As Size)

        Dim bmp As New Bitmap(m.Width, m.Height)
        Dim gfx As Graphics = System.Drawing.Graphics.FromImage(bmp)
        gfx.CopyFromScreen(i.X, i.Y, 0, 0, m, CopyPixelOperation.MergeCopy)
        gfx.Dispose()
        Clipboard.SetImage(bmp)

    End Sub

    Private Sub Topo_MouseDown()
        InizioImmagine = Cursor.Position
    End Sub

    Private Sub Topo_MouseUp()
        FineImmagine = Cursor.Position
    End Sub

    Private Sub ckFoto_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckFoto.CheckedChanged
        Sleep(200)
        TopoAttivo = ckFoto.Checked
        If TopoAttivo = True Then
            ckTesto.Checked = False
            AttivaSchermo()
        Else
            ckTesto.Checked = True
            DisAttivaSchermo()
        End If
    End Sub

    Private Sub AttivaSchermo()
        SchermoAttivoI = True
        Schermo.Show()
        Schermo.Location = pnPDF.Location
        Schermo.Width = pnPDF.Width - 20
        Schermo.Height = pnPDF.Height - 10
    End Sub

    Private Sub DisAttivaSchermo()
        SchermoAttivoI = False
        Schermo.Location = pnPDF.Location
        Schermo.Width = pnPDF.Width
        Schermo.Height = 1 ' TitlebarHeight * 2 + 5
    End Sub

    Sub NascondiSchermo()
        SchermoAttivoI = False
        Schermo.Hide()
    End Sub

    Private Sub pnPDF_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles pnPDF.Resize
        If SchermoAttivoI = True Then
            Schermo.Location = pnPDF.Location
            Schermo.Size = pnPDF.Size
        End If
    End Sub

    Private Sub ckTesto_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ckTesto.CheckedChanged
        ckFoto.Checked = Not (ckTesto.Checked)
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
            LeggiMessaggi("incolla il testo selezionato nel riquadro qui sotto e lo legge.")
        End If
    End Sub

    Private Sub cmdLeggiTesto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("nel riquadro qui sotto, legge il testo o la selezione, se c'è.")
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

        PausaLettura()

    End Sub

    Private Sub cmdImposta_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdImposta.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("apri documento.")
        End If
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Timer2.Enabled = False
        Dim tmp As IntPtr = Nothing
        tmp = GetForegroundWindow
        If tmp = mioHandle Then
            Timer2.Interval = 500
            Timer2.Enabled = True
            Exit Sub
        End If

        If tmp <> altroHandle And tmp <> Nothing And tmp <> 0 Then
            altroHandle = tmp
            SetParent(altroHandle, Me.pnPDF.Handle)
            SendMessage(altroHandle, WM_SYSCOMMAND, SC_MAXIMIZE, 0)
        End If
    End Sub

    Private Sub ChiudiFinestra()
        SendMessage(altroHandle, WM_SYSCOMMAND, SC_CLOSE, 0)
    End Sub


    Private Sub CmbURL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles CmbURL.KeyPress
        Dim KeyAscii As Short = Asc(e.KeyChar)
        Dim s As Object
        Dim s1 As String

        If KeyAscii = 13 Then
            s = CmbURL.Text
            If s = "" Then GoTo EventExitSub
            s1 = Mid(s, 1, 6)
            If (s1 <> "http:/") And (s1 <> "file:/") And (s1 <> "ftp://") And (s1 <> "https:/") Then
                CmbURL.Text = "http://" & CmbURL.Text
            End If
            WB.Navigate(New System.Uri((CmbURL.Text)))
        End If


EventExitSub:
        e.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            e.Handled = True
        End If
    End Sub

    Sub AggiungiIndirizzo()

        If Trim(CmbURL.Text) <> "" Then
            CmbURL.Items.Add(CmbURL.Text)
            modificato = True
        End If
    End Sub

    Private Sub Aggiorna()
        On Error Resume Next
        WB.Refresh()
    End Sub

    Private Sub cmdAggiungi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdAggiungi.Click
        cbUrl.Items.Add(Trim(txtUrl.Text))
        cbUrl.SelectedIndex = cbUrl.Items.Count - 1
    End Sub

    Private Sub Avanti()
        On Error Resume Next
        WB.GoForward()
        CmbURL.Text = WB.Url.ToString()
    End Sub

    Private Sub cmdElimina_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdElimina.Click
        If cbUrl.SelectedIndex > -1 Then cbUrl.Items.RemoveAt((cbUrl.SelectedIndex))
        txtUrl.Text = ""
        cmdElimina.Enabled = False
        cmdAggiungi.Enabled = False
        cmdNaviga.Enabled = False
    End Sub

    Private Sub cmdFatto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdFatto.Click
        ChiudiPreferiti()
    End Sub

    Sub ChiudiPreferiti()

        frIndirizzi.Visible = False
        If ElencoPreferiti = "" Then Exit Sub

        Dim f As Integer
        Dim u As String
        Dim k As Short
        CmbURL.Items.Clear()
        For k = 0 To cbUrl.Items.Count - 1
            CmbURL.Items.Add(cbUrl.Items(k))
        Next k
        txtUrl.Text = ""
        f = FreeFile()
        On Error GoTo Trap
        FileOpen(f, ElencoPreferiti, OpenMode.Output)
        For k = 0 To cbUrl.Items.Count - 1
            PrintLine(f, cbUrl.Items(k))
        Next
        FileClose(f)

        Exit Sub

Trap:
        frIndirizzi.Visible = False
        MsgBox("Impossibile salvare l'elenco degli indirizzi", MsgBoxStyle.Critical)
        FileClose(f)
    End Sub

    Private Sub Home()
        Url1 = URL
        CmbURL.Text = Url1
        'WB.Navigate(New System.Uri(Url1))
        WB.Navigate(New System.Uri(My.Application.Info.DirectoryPath & "\inizio.htm"))

    End Sub

    Private Sub cmdHP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdHP.Click
        Dim tmp As String

        If cbUrl.SelectedIndex > 0 Then
            tmp = cbUrl.SelectedItem
            cbUrl.Items.RemoveAt(cbUrl.SelectedIndex)
            cbUrl.Items.Insert(0, tmp)
        End If
    End Sub

    Private Sub Indietro()
        On Error Resume Next
        WB.GoBack()
        CmbURL.Text = WB.Url.ToString()
    End Sub

    Private Sub cmdModifica_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdNaviga.Click
        Naviga()
    End Sub

    Sub Naviga()
        If cbUrl.SelectedIndex > -1 Then
            CmbURL.Text = cbUrl.SelectedItem
            On Error Resume Next
            WB.Navigate(New System.Uri((CmbURL.Text)))
            ChiudiPreferiti()
        End If
    End Sub

    Private Sub Ferma()
        On Error Resume Next
        WB.Stop()
    End Sub

    Private Sub cmdVai_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdVai.Click
        Vai()
    End Sub

    Sub Vai()
        On Error Resume Next
        WB.Navigate(New System.Uri((CmbURL.Text)))
    End Sub
    Private Sub ToolStripButton6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsPreferiti.Click
        GestionePreferiti()
    End Sub

    Private Sub tsIndietro_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsIndietro.Click
        Indietro()
    End Sub

    Private Sub tsAvanti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAvanti.Click
        Avanti()
    End Sub

    Private Sub tsTermina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTermina.Click
        Ferma()
    End Sub

    Private Sub tsRicarica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsRicarica.Click
        Aggiorna()
    End Sub

    Private Sub tsHome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsHome.Click
        Home()
    End Sub

    Sub GestionePreferiti()

        If frIndirizzi.Visible = True Then
            frIndirizzi.Visible = False
            Exit Sub
        End If

        cmdElimina.Enabled = False
        cmdNaviga.Enabled = False
        cmdHP.Enabled = False
        frIndirizzi.Visible = True

        txtUrl.Text = CmbURL.Text
    End Sub


    Private Sub txtUrl_TextChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txtUrl.TextChanged
        If txtUrl.Text <> "" Then
            cmdAggiungi.Enabled = True
        Else
            cmdElimina.Enabled = False
            cmdAggiungi.Enabled = False
            cmdNaviga.Enabled = False
        End If
    End Sub

    Private Sub WB_Navigated(ByVal sender As Object, ByVal e As System.Windows.Forms.WebBrowserNavigatedEventArgs) Handles WB.Navigated
        CmbURL.Text = WB.Url.ToString
    End Sub

    Private Sub WB_Navigating(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.WebBrowserNavigatingEventArgs) Handles WB.Navigating
        Dim URL As String = eventArgs.Url.ToString()
        Dim TargetFrameName As String = eventArgs.TargetFrameName
        Dim Cancel As String = eventArgs.Cancel

        Dim strURL As String
        strURL = CmbURL.Text

        Dim bFound As Boolean
        Dim i As Short

        Timer1.Enabled = True

        For i = 0 To CmbURL.Items.Count - 1
            If CmbURL.Items(i) = strURL Then
                bFound = True
                Exit For
            End If
        Next i

        If Not bFound Then
            CmbURL.Items.Add(strURL)
        End If

        CmbURL.Text = strURL

    End Sub

    Private Sub WB_NewWindow(ByVal eventSender As System.Object, ByVal eventArgs As System.ComponentModel.CancelEventArgs) Handles WB.NewWindow
        'Dim Cancel As Boolean = eventArgs.Cancel
        NuovaFinestra()
        'eventArgs.Cancel = True
        'MsgBox("Non permesse nuove finestre!")
    End Sub

    Sub NuovaFinestra()

        Dim ppDisp As WebBrowser
        Dim frm As frmINT
        frm = New frmINT
        ppDisp = frm.WB
        frm.WindowState = System.Windows.Forms.FormWindowState.Normal
        frm.Width = Me.Width * 0.9
        frm.Height = Me.Height * 0.9
        System.Windows.Forms.Application.DoEvents()
        'frm.Close() 'Show()

    End Sub

    Private Sub WB_DocumentTitleChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles WB.DocumentTitleChanged
        Dim Text_Renamed As String = CType(eventSender, WebBrowser).DocumentTitle
        On Error Resume Next
        With StatusBar1.Items
            .Item(1).Text = Text_Renamed
            Me.Text = Text_Renamed & " - INTERNET"
        End With
        Me.Text = Text_Renamed & " - " & titolo
    End Sub

    Sub Esci()

        If ElencoPreferiti = "" Then Exit Sub

        Dim k As Integer
        Dim f As Integer
        If modificato = True Then
            f = FreeFile()
            On Error GoTo Trap
            FileOpen(f, ElencoPreferiti, OpenMode.Output)
            For k = 0 To cbUrl.Items.Count - 1
                If Trim(cbUrl.Items(k)) <> "" Then PrintLine(f, Trim(cbUrl.Items(k)))
            Next
            FileClose(f)
        End If

        End
        Exit Sub

Trap:
        FileClose(f)
        MsgBox("Impossibile salvare l'elenco dei Preferiti", MsgBoxStyle.Critical)

        End
    End Sub

    Sub Salva()
        On Error Resume Next
        WB.Focus()
        WB.ShowSaveAsDialog()
    End Sub

    Sub Stampa()
        WB.Print()
    End Sub

    Sub SalvaImmagini()

        Dim fbd As New FolderBrowserDialog
        fbd.ShowDialog()
        Dim PathText As String = fbd.SelectedPath
        If PathText = "" Then Exit Sub
        Dim oDoc As HtmlDocument = WB.Document
        Dim oImage As Image
        Dim i As Integer
        For i = 0 To oDoc.Images.Count - 1
            oImage = GetWebImage(oDoc.Images(i).GetAttribute("src"))
            If Not IsNothing(oImage) Then
                Dim ofile() As String = Split(oDoc.Images(i).GetAttribute("src"), "/")
                oImage.Save(PathText & "\Immagine_" & i & ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg)
            End If
            Application.DoEvents()
            oImage = Nothing
        Next
    End Sub

    Public Shared Function GetWebImage(ByVal ImageURL As String) As Image
        Dim objImage As MemoryStream
        Dim objwebClient As WebClient
        Dim sURL As String = Trim(ImageURL)
        Dim oImage As Image
        Try
            If Not sURL.ToLower().StartsWith("http://") _
            Then sURL = "http://" & sURL
            objwebClient = New WebClient
            objImage = New  _
            MemoryStream(objwebClient.DownloadData(sURL))
            oImage = System.Drawing.Image.FromStream(objImage)
            Return oImage
        Catch ex As Exception
            'Return something, an error or no image as default
            Return Nothing
        End Try
    End Function

    Private Sub tsImmagini_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsImmagini.Click
        Me.Cursor = Cursors.WaitCursor
        SalvaImmagini()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub tsTesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsTesto.Click

        Dim SalvaTesto As New SaveFileDialog()
        SalvaTesto.Filter = "File di testo (*.txt)|*.txt"
        SalvaTesto.FilterIndex = 1
        SalvaTesto.RestoreDirectory = True

        If SalvaTesto.ShowDialog() = DialogResult.OK Then
            Dim f As Integer = FreeFile()
            Dim r As Boolean = False
            Dim sErrore As String = ""
            r = SaveTextToFile(RecuperaTestoTutto, SalvaTesto.FileName, sErrore)
            If r = False Then
                MsgBox("Errore nel salvataggio del file: " & sErrore)
            End If
        End If

    End Sub

    Private Sub cbUrl_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbUrl.DoubleClick
        Naviga()
    End Sub

    Private Sub cbUrl_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbUrl.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi(cbUrl.SelectedItem)
        End If
    End Sub

    Private Sub cbUrl_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbUrl.SelectedIndexChanged
        If cbUrl.SelectedIndex = -1 Then Exit Sub
        txtUrl.Text = cbUrl.SelectedItem
        cmdElimina.Enabled = True
        cmdNaviga.Enabled = True
        cmdAggiungi.Enabled = True
        cmdHP.Enabled = True
    End Sub

    Private Sub tsIndietro_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tsIndietro.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("indietro.")
        End If
    End Sub

    Private Sub tsImmagini_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tsImmagini.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("salva tutte le immagini.")
        End If
    End Sub

    Private Sub tsTesto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tsTesto.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("salva tutto il testo.")
        End If
    End Sub

    Function RecuperaTestoSelezione() As String
        Dim a As mshtml.IHTMLDocument2 = WB.Document.DomDocument
        Dim s As mshtml.IHTMLSelectionObject2 = a.selection
        RecuperaTestoSelezione = ""
        If s IsNot Nothing Then
            Try
                range = s.createrange
                If range IsNot Nothing Then
                    RecuperaTestoSelezione = range.text
                End If
            Catch ex As Exception
                RecuperaTestoSelezione = CopiaTesto()
            End Try
        End If

    End Function

    Function CopiaTesto() As String
        Dim tmp As String = ""
        WB.Focus()
        Sleep(50)
        SendKeys.SendWait("^(c)")
        Sleep(20)
        Try
            tmp = Clipboard.GetText
        Catch ex As Exception
        End Try
        If tmp <> "" Then tmp = filtrata(tmp)
        Return tmp
    End Function

    Function RecuperaTestoTutto() As String
        'Return WB.Document.Body.OuterText
        Return WB.Document.Body.OuterHtml
    End Function

    Private Sub tsAvanti_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tsAvanti.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("avanti.")
        End If
    End Sub

    Private Sub tsTermina_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tsTermina.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("termina.")
        End If
    End Sub

    Private Sub tsRicarica_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tsRicarica.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("aggiorna pagina.")
        End If
    End Sub

    Private Sub tsHome_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tsHome.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("pagina iniziale.")
        End If
    End Sub

    Private Sub RTB_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If blnStaLeggendo = True Then FermaLettura()
    End Sub

    Private Sub RTB_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If blnStaLeggendo = True Then FermaLettura()
    End Sub

    Private Sub tsPreferiti_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tsPreferiti.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("preferiti.")
        End If
    End Sub

    Private Enum Exec
        OLECMDID_OPTICAL_ZOOM = 63
    End Enum

    Private Enum ExecOpt
        OLECMDEXECOPT_DODEFAULT = 0
        OLECMDEXECOPT_PROMPTUSER = 1
        OLECMDEXECOPT_DONTPROMPTUSER = 2
        OLECMDEXECOPT_SHOWHELP = 3
    End Enum

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            Dim Res As Object = Nothing
            Dim MyWeb As Object
            MyWeb = Me.WB.ActiveXInstance
            MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, ExecOpt.OLECMDEXECOPT_DONTPROMPTUSER, 150, IntPtr.Zero)
        Catch ex As Exception
            MsgBox("Error:" & ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            Dim Res As Object = Nothing
            Dim MyWeb As Object
            MyWeb = Me.WB.ActiveXInstance
            MyWeb.ExecWB(Exec.OLECMDID_OPTICAL_ZOOM, ExecOpt.OLECMDEXECOPT_DONTPROMPTUSER, 100, IntPtr.Zero)
        Catch ex As Exception
            MsgBox("Error:" & ex.Message)
        End Try
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
        lbLingua.Text = AssegnaVoce(item)
    End Sub

    Public Sub Sceglivoce(item As String)
        intParlante = Sceltavoce(item, MenuVoci, cmdVoce)
        cmdVoce.Image = ScegliBandiera(intParlante)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        WB.Focus()
        Threading.Thread.Sleep(200)
        SendKeys.SendWait("^{+}")
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        WB.Focus()
        Threading.Thread.Sleep(200)
        SendKeys.SendWait("^{-}")
    End Sub

End Class