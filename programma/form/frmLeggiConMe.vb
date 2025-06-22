Imports Microsoft.Win32
Imports System.Text.RegularExpressions
Imports System.Reflection

Public Class frmLeggiConMe

    Dim altezza As Integer = AltezzaCaption() + 25
    Dim AltezzaToolbar As Integer = 0
    Dim ColoreEvidenziato As Color = Color.FromArgb(0, 255, 255)
    Dim ColoreEvidenziato2 As Color = Color.FromArgb(0, 254, 255)
    Dim Rosso As Color = Color.FromArgb(255, 0, 0)
    Dim Rosso2 As Color = Color.FromArgb(254, 0, 0)
    Dim tmpRTF As String = ""
    Dim ColoreMenu As Color
    Dim ColEv0 As Color = Color.LightGreen 'Color.FromArgb(0, 255, 255)
    Dim ColEv1 As Color = Color.Aqua 'Color.FromArgb(0, 255, 255)
    Dim ColEv2 As Color = Color.Pink 'Color.FromArgb(255, 0, 255)
    Dim ColEv3 As Color = Color.Yellow 'Color.FromArgb(255, 255, 0)
    Dim ColEv4 As Color = Color.Silver 'Color.FromArgb(255, 255, 0)

    Dim Intestazione As String = ""
    Dim blnSalvato As Boolean = True
    Dim blnTempSalvato As Boolean = True
    Dim blnFinestraAperta As Boolean = False

    Dim MisuraFontPredefinito As Single = 0
    Dim NomeFontPredefinito As String = ""

    Dim NomeDocumento As String = "Documento.rtf"

    Dim blnInstallato As Boolean = True
    Dim blnAggiornaVelocità As Boolean = False

    Dim blnStoSalvando As Boolean = False

    Dim blnDaRipristinare As Boolean = False
    Dim blnLeggereParola As Boolean = False
    Dim blnLeggiFrase As Boolean = False
    Dim UnaParola As String = ""

    Private Sub LaData()
        Me.Text = Date.Today
        'MsgBox(Date.Today > "12/12/2011")
    End Sub

    Private Sub frmLeggiConMe_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        If ChiediSalva() = True Then
            e.Cancel = True
            Exit Sub
        End If

        DeRegistraTasti()
        SalvaImpostazioni()

        If IO.File.Exists(CartellaTemp & "testo.txt") Then
            Kill(CartellaTemp & "testo.txt")
        End If
        If IO.File.Exists(CartellaTemp & "errori.txt") Then
            Kill(CartellaTemp & "errori.txt")
        End If
        If IO.File.Exists(FileTemporaneo) Then
            Kill(FileTemporaneo)
        End If

        Kill(CartellaTemp & "__*.pdf")
        TogliLexicon(Lexicon)
        frmPDF.Close()
        ChiudiVoce()
        If blnWinH = True Then
            WinH()
        End If
    End Sub

    Private Sub frmLeggiConMe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        lblVelocita.Text = Velocita
    End Sub

    Private Sub frmLeggiConMe_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        If KeyCode = Keys.F11 And tbRiassunto.Visible = True Then
            EvidenziaPerRiassunto()
        End If

    End Sub

    Private Sub frmLeggiXme_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        RTB.AllowDrop = True

        NascondiMenu()
        AltezzaToolbar = tbFile.Height
        RTB.Top = tbMenu.Height
        ColoreMenu = tbMenu.BackColor
        Try
            VoceSP.InitVoce()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        If blnVoce = False Then
            btnMP3.Enabled = False
        End If
        If NomeVocePrincipale <> "" Then
            CreamenuVoci(MenuVoci)
        End If

        Init()
        If PercorsoOrtografici = "" Then
            'SplashScreen1.Visible = False
            Me.TopMost = True
            MsgBox("Non trovo i dizionari ortografici", MsgBoxStyle.Critical)
            btnCorrettore.Enabled = False
        End If

        'If ConnessioneInternet() = True Then
        If InternetConnesso() = True Then
            blnInternet = True
            If ChromeInstallato() = "" Then
                btnMicrofono.Visible = False
            Else
                If win1011() = True Then
                    btnMicrofono.ToolTipText = "Attiva la dettatura con Windows"
                End If
            End If
            If ChromeInstallato() = "" Then
                btnLens.Visible = False
            Else
                btnLens.Visible = True
            End If
            TraduttoreToolStripMenuItem.Enabled = True
        Else
            btnWiki.Visible = False
            Wikipedia.Visible = False
            btnMicrofono.Visible = False
            mTraduci.Visible = False
            ckTradLat.Visible = False
            btnImmGoogle.Visible = False
            btnLens.Visible = False
            TraduttoreToolStripMenuItem.Enabled = False
        End If
        If Capture2text() = "" Then
            ckOCR.Visible = False
        End If
        '<<<<<<<<<<<<<<< da cambiare >>>>>>>>>>>>>>
        'blnHoAperto = True
        '<<<<<<<<<<<<<<< da cambiare >>>>>>>>>>>>>>

        Dim tmp As String = NomeVocePrincipale
        LeggiImpostazioni()
        If NomeVocePrincipale = "" Then NomeVocePrincipale = tmp

        Dim index As Integer = -1
        Try
            index = Array.IndexOf(NomeVoce, NomeVocePrincipale)
        Catch ex As Exception
        End Try

        NascondiTraduttore()
        CreaPercorsoClipart()

        FontPredefinito = RTB.Font
        rbSel.Checked = True
        MaxSuggerimenti = 10
        C10.Checked = True

        'RegistraTasti()
        CaratteriSpeciali()
        AdattaRTB()

        Clipboard.Clear()
        tmrSalva.Enabled = False

        RTB.BackColor = ColoreSfondo
        lbErrate.BackColor = ColoreSfondo
        lbSuggerimenti.BackColor = ColoreSfondo

        If MindMaple() = "" Then
            btnMappe.Visible = False
        End If

        If Cmap() = "" Then
            btnCmap.Visible = False
        End If

        If IO.File.Exists(Percorso & "\ai-hai.exe") = False Then
            btnAcca.Visible = False
        End If

        If CeLettorePDF() = False Then
            btnPDF.Enabled = False
            MsgBox("Non trovo programmi per aprire i file PDF", MsgBoxStyle.Critical)
        End If

        'tmrAvvio.Enabled = True
        'MsgBox(FileTemporaneo)
    End Sub

    Sub RecuperaTemporaneo()
        'MsgBox(FileTemporaneo)
        RTB.LoadFile(FileTemporaneo)
    End Sub

    Dim blnMenuVisibile As Boolean = True

    Sub NascondiMenu()

        If blnMenuVisibile = False Then Exit Sub

        tbVisualizza.Visible = False
        tbCorrettore.Visible = False
        tbAudio.Visible = False
        tbFile.Visible = False
        tbCerca.Visible = False
        tbRiassunto.Visible = False
        tbModifica.Visible = False
        'tbMappe.Visible = False
        panErrori.Visible = False
        RTB.Top -= AltezzaToolbar ' + 2
        RTB.Height += AltezzaToolbar '* 2
        AdattaRTB()

        btnFile.BackColor = ColoreMenu 'SystemColors.ActiveCaption
        btnModifica.BackColor = ColoreMenu 'SystemColors.ActiveCaption
        btnAudio.BackColor = ColoreMenu 'SystemColors.ActiveCaption
        btnVisualizza.BackColor = ColoreMenu 'SystemColors.ActiveCaption
        btnCorrettore.BackColor = ColoreMenu 'SystemColors.ActiveCaption
        btnRiassunto.BackColor = ColoreMenu 'SystemColors.ActiveCaption
        btnMappe.BackColor = ColoreMenu 'SystemColors.ActiveCaption
        btnTrova.BackColor = ColoreMenu 'SystemColors.ActiveCaption
        blnMenuVisibile = False

    End Sub

    Sub MostraMenu()

        'RTB.Top = AltezzaToolbar * 2 + 2
        RTB.Top += AltezzaToolbar
        RTB.Height -= AltezzaToolbar ' * 2

        AdattaRTB()
        blnMenuVisibile = True
    End Sub

    Private Sub AdattaRTB()
        If panErrori.Visible = True Then
            RTB.Width = Me.Width - panErrori.Width - 7
        Else
            RTB.Width = Me.Width - 20
        End If
        RTB.Height = Me.Height - RTB.Top - altezza
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        FermaVoce()
    End Sub

    Private Sub btnLeggi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLeggi.Click
        Leggi()
    End Sub

    Private Sub btnAudio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAudio.Click
        SelezionaPulsante(btnAudio, tbAudio)
    End Sub

    Private Sub btnFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFile.Click
        SelezionaPulsante(btnFile, tbFile)
    End Sub

    Sub AssegnaLaVoce(ByVal nv As Integer)
        Try
            ScegliLingua(intParlante)
            btnLingua.Image = ScegliBandiera(intParlante)
            lbLingua.Text = AssegnaVoce(intParlante)
            ToolStripLabel12.Text = lbLingua.Text
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub btnMeno_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMeno.Click
        Dim i As Integer = 0
        DiminuisciVelocita()
        lblVelocita.Text = Velocita
        If blnStoLeggendo = True Then
            i = RTB.SelectionStart
            blnAggiornaVelocità = True
            FermaVoce()
            RTB.SelectionStart = i
            RTB.SelectedText = ""
            RTB.Focus()
            Leggi()
        End If
    End Sub

    Private Sub btnPiu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPiu.Click
        Dim bln As Boolean = blnStoLeggendo
        FermaVoce()
        AumentaVelocita()
        lblVelocita.Text = Velocita
        If bln = True Then

            blnAggiornaVelocità = True
            Leggi()
        End If
    End Sub

    Private Sub btnModifica_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnModifica.Click
        SelezionaPulsante(btnModifica, tbModifica)
    End Sub

    Private Sub FiltroPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles FiltroPDF.Click
        ControlloColore(FiltroPDF)
    End Sub

    Private Sub btnTrova_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTrova.Click
        SelezionaPulsante(btnTrova, tbCerca)
    End Sub

    Private Sub frmLeggiConMe_Resize(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then
            RegistraTasti()
            blnFinestraAperta = False
            'MessaggioTasti.Show()
        Else
            If blnFinestraAperta = False Then
                DeRegistraTasti()
            End If
            blnFinestraAperta = True
            'GC.GetTotalMemory(True)
        End If
        AdattaRTB()
    End Sub

    Private Sub btnCorrettore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCorrettore.Click
        If tbCorrettore.Visible = False Then ScegliLingua(intParlante)
        SelezionaPulsante(btnCorrettore, tbCorrettore)
    End Sub

    Sub ControlloColore(ByVal c As ToolStripButton)
        c.Checked = Not c.Checked
        If c.Checked Then
            c.ForeColor = Color.Red
        Else
            c.ForeColor = Color.Black
        End If

    End Sub

    Private Sub ckLeggeParola_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ckLeggeParola.Click
        ckLeggeFrase.Checked = False
    End Sub

    Private Sub ckLeggeFrase_Click(ByVal sender As Object, ByVal e As EventArgs) Handles ckLeggeFrase.Click
        ckLeggeParola.Checked = False
    End Sub

    Private Sub rbSel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbSel.Click
        rbCanc.Checked = False
        rbSel.Checked = True
        blnSelez = True
        btnCancellaEvidenziazione.ToolTipText = "Conserva la Selezione"
    End Sub

    Private Sub rbCanc_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbCanc.Click
        rbSel.Checked = False
        rbCanc.Checked = True
        blnSelez = False
        btnCancellaEvidenziazione.ToolTipText = "Cancella la Selezione"
    End Sub

    Private Sub btnVisualizza_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnVisualizza.Click
        SelezionaPulsante(btnVisualizza, tbVisualizza)
    End Sub

    Sub SelezionaPulsante(ByVal p As ToolStripButton, ByVal t As ToolStrip)
        DisattivaLens()
        If t.Visible = False Then
            NascondiMenu()
            t.Visible = True
            MostraMenu()
            p.BackColor = Color.AntiqueWhite
        Else
            NascondiMenu()
        End If
    End Sub

    Sub Leggi()
        FermaVoce()
        If blnFinestraAperta = False Then ' Or frmLettore.Visible = True Then
            CopiaTesto()
        End If
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

    Private Sub CopiaTesto()
        Dim tmp As String = "", strProg As String = ""
        Dim altrohandle As Int32 = GetForegroundWindow
        'SetForegroundWindow(altroHandle)
        strProg = GetWT(altrohandle)
        SetForegroundWindow(altrohandle)

        ' AppActivate(strProg)
        Threading.Thread.Sleep(100)
        SendKeys.SendWait("^(c)")
        Threading.Thread.Sleep(100)

        If Clipboard.ContainsText = False Then
            SetForegroundWindow(altrohandle)
            Threading.Thread.Sleep(200)
            SendKeys.SendWait("^(c)")
        End If

        Try
            If Clipboard.ContainsText = True Then
                tmp = Clipboard.GetText
                Dim a As String = TrovaProgrammaAssociato("pdf")
                If strProg = UCase(Mid(a, 1, a.LastIndexOf("."))) Or strProg = "ACRORD32" Or strProg = "PDFXCVIEW" Or strProg = "PDFREADER" Or strProg = "NITRO" Or strProg = "SUMATRAPDF" Or FiltroPDF.Checked = True Then tmp = filtrata(tmp)
                If strProg = "WINWORD" Then tmp = tmp.Replace(Chr(172), "")
                tmp = tmp.Replace("É", "È")

                If tmp <> "" Then
                    RTB.Text = tmp
                    NAppunti += 1
                    ReDim Preserve Appunti(NAppunti)
                    Appunti(NAppunti) = tmp
                End If
            Else
                'Me.Text = strProg
            End If
        Catch ex As Exception

        End Try
        RTB.Text = tmp
    End Sub

    Private Sub btnRiassunto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRiassunto.Click
        SelezionaPulsante(btnRiassunto, tbRiassunto)
    End Sub

    Private Sub btnLingua_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLingua.Click
        MenuVoci.Show()
        MenuVoci.Left = Me.Left
        MenuVoci.Top = Me.Top + AltezzaToolbar
    End Sub

    Sub MenuVoci_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles MenuVoci.ItemClicked

        Dim item As String = e.ClickedItem.ToString
        If item = "ANNULLA" Then Exit Sub

        Dim indice As Integer = -1
        For i As Integer = 0 To MenuVoci.Items.Count - 1
            If MenuVoci.Items(i).ToString.Contains(item) Then
                indice = i
            End If
        Next

        Try
            intParlante = indice
            AssegnaLaVoce(intParlante)
        Catch
            Parlante = NomeVocePrincipale
        End Try

    End Sub

    Private Sub Maiuscolo_Minuscolo()

        Dim MisuraFont As Single = RTB.Font.Size
        If MisuraFont < 8 Then MisuraFont = MisuraPredefinitaFont
        Dim MioFont As Font

        If rbMaiu.Checked = True Then
            MioFont = CreateFont(Percorso & "\cdw_maiuscolo.ttf", FontStyle.Regular, MisuraFont, RTB.Font.Unit)
        ElseIf rbSmall.Checked = True Then
            MioFont = CreateFont(Percorso & "\figuralsmallcapsplain-regular.ttf", FontStyle.Regular, MisuraFont, RTB.Font.Unit)
        ElseIf rbBN.Checked = True Then
            MioFont = CreateFont(Percorso & "\BiancoeneroBook.ttf", FontStyle.Regular, MisuraFont, RTB.Font.Unit)
        ElseIf rbOD.Checked = True Then
            MioFont = CreateFont(Percorso & "\OpenDyslexic-Regular.ttf", FontStyle.Regular, MisuraFont, RTB.Font.Unit)
        Else
            MioFont = FontPredefinito
        End If
        Try
            RTB.Font = MioFont
        Catch ex As Exception
            RTB.Font = FontPredefinito
        End Try
        ImpostaInterlinea(RTB)
    End Sub

    Sub SelIntelinea(ByVal il As Integer)
        interlinea = il
        rbInterl1.Checked = True
        rbInterl15.Checked = True
        rbInterl2.Checked = True
        Select Case il
            Case 1 : rbInterl1.Checked = False
            Case 2 : rbInterl15.Checked = False
            Case 3 : rbInterl2.Checked = False
        End Select
        ControlloColore(rbInterl1)
        ControlloColore(rbInterl15)
        ControlloColore(rbInterl2)
        ImpostaInterlinea(RTB)
    End Sub

    Private Sub rbIntrl1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbInterl1.Click
        SelIntelinea(1)
    End Sub

    Private Sub rbInterl15_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbInterl15.Click
        SelIntelinea(2)
    End Sub

    Private Sub rbInterl2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbInterl2.Click
        SelIntelinea(3)
    End Sub

    Private Sub rbMin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbMin.Click
        rbMin.Checked = True
        rbMaiu.Checked = False
        rbSmall.Checked = False
        rbBN.Checked = False
        rbOD.Checked = False
        Maiuscolo_Minuscolo()
    End Sub

    Private Sub rbMaiu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbMaiu.Click
        rbMaiu.Checked = True
        rbMin.Checked = False
        rbSmall.Checked = False
        rbBN.Checked = False
        rbOD.Checked = False
        Maiuscolo_Minuscolo()
    End Sub

    Private Sub rbSmall_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbSmall.Click
        rbSmall.Checked = True
        rbMaiu.Checked = False
        rbMin.Checked = False
        rbBN.Checked = False
        rbOD.Checked = False
        Maiuscolo_Minuscolo()
    End Sub

    Private Sub rbBN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBN.Click
        rbBN.Checked = True
        rbSmall.Checked = False
        rbMaiu.Checked = False
        rbMin.Checked = False
        rbOD.Checked = False
        Maiuscolo_Minuscolo()
    End Sub

    Private Sub rbOD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbOD.Click
        rbBN.Checked = False
        rbSmall.Checked = False
        rbMaiu.Checked = False
        rbMin.Checked = False
        rbOD.Checked = True
        Maiuscolo_Minuscolo()
    End Sub

    Private Function ChiediSalva() As Boolean
        If blnHoAperto = False Then
            Return False
            Exit Function
        End If
        If blnSalvato = False Then
            Dim res As Integer = MsgBox("Vuoi salvare il tuo documento?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
            If res = vbCancel Then
                Return True
                Exit Function
            End If
            If res = vbYes Then
                SalvaDocumento()
            End If
        End If
        Return False
    End Function

    Sub ApriDocumento()

        If ChiediSalva() = True Then Exit Sub

        Dim apriRTB As New OpenFileDialog()
        apriRTB.Filter = "file RTF, TXT o DOCX|*.rtf;*.txt;*.docx"
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
                Dim nf As String = apriRTB.FileName
                Dim i As Integer = InStrRev(nf, "\")
                nf = Mid(nf, i + 1)
                Me.Text = "LeggiXme_SP - " & nf
                NomeDocumento = nf
            Catch er As Exception
                MsgBox("Errore nell'apertura di " & apriRTB.FileName, MsgBoxStyle.Critical)
            End Try
        End If
        ' Maiuscolo_Minuscolo()
    End Sub

    Private Sub SalvaDocumento()

        Dim saveRTB As New SaveFileDialog()
        saveRTB.Filter = "RTF files (*.rtf)|*.rtf|txt files (*.txt)|*.txt"
        saveRTB.FilterIndex = 1
        saveRTB.InitialDirectory = TrovaCartellaDOC()
        saveRTB.RestoreDirectory = True
        saveRTB.FileName = IO.Path.GetFileNameWithoutExtension(NomeDocumento)

        If saveRTB.ShowDialog() = DialogResult.OK Then
            Dim nf As String = saveRTB.FileName
            Try
                If IO.Path.GetExtension(nf) = ".rtf" Then
                    RTB.SaveFile(nf, RichTextBoxStreamType.RichText)
                Else
                    RTB.SaveFile(nf, RichTextBoxStreamType.PlainText)
                End If
                Dim i As Integer = InStrRev(nf, "\")
                NomeDocumento = IO.Path.GetFileName(nf)
                Me.Text = "LeggiXme_SP - " & NomeDocumento
                blnSalvato = True
            Catch ex As Exception
                MsgBox("Errore nel salvataggio del file", MsgBoxStyle.Critical)
            End Try
        End If

    End Sub

    Private Sub AggiungiImmagine()
        Dim apriRTB As New OpenFileDialog()
        apriRTB.Filter = "File di immagine|*.jpg;*.gif;*.png;*.tif;*.bmp"
        apriRTB.FilterIndex = 1
        apriRTB.RestoreDirectory = True

        If apriRTB.ShowDialog() = DialogResult.OK Then
            Dim img As Image = Image.FromFile(apriRTB.FileName)
            Try
                Clipboard.SetImage(img)
                RidimensionaImmagineInClipboard()
                RTB.Paste()
            Catch er As Exception
            End Try
        End If
    End Sub

    Private Sub AggiungiClipArt()
        Dim apriImg As New OpenFileDialog()
        apriImg.Filter = "File di immagine|*.jpg;*.gif;*.png;*.tif;*.bmp"
        apriImg.FilterIndex = 1
        apriImg.InitialDirectory = PercorsoClipart

        If apriImg.ShowDialog() = DialogResult.OK Then
            Dim img As Image = Image.FromFile(apriImg.FileName)
            Try
                Clipboard.SetImage(img)
                RidimensionaImmagineInClipboard(120)
                RTB.Paste()
            Catch er As Exception
            End Try
        End If
    End Sub

    Private Sub btnImmagine_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImmagine.Click
        InserisciClipart()
    End Sub

    Private Sub btnImg_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImg.Click
        AggiungiImmagine()
    End Sub

    Private Sub btnNuovo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNuovo.Click
        If ChiediSalva() = True Then Exit Sub
        RTB.Text = ""
        blnSalvato = True
    End Sub

    Private Sub btnApri_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnApri.Click
        ApriDocumento()
    End Sub

    Private Sub btnSalva_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSalva.Click
        SalvaDocumento()
    End Sub

    Private Sub btnAnteprimaDiStampa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnteprimaDiStampa.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub btnImpostaPagina_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnImpostaPagina.Click
        PageSetupDialog1.ShowDialog()
    End Sub

    Private checkPrint As Integer

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Print the content of the RichTextBox. Store the last character printed.
        checkPrint = RTB.Print(checkPrint, RTB.TextLength, e)
        ' Look for more pages
        If checkPrint < RTB.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If

    End Sub

    Private Sub btnStampa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStampa.Click
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.PrinterSettings = PrintDialog1.PrinterSettings
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub btnCaratterePredefinito_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCaratterePredefinito.Click
        ScegliFontPredefinito()
    End Sub

    Private Sub ScegliFontPredefinito()
        Dim fontRTB As New FontDialog
        Dim MioStile As FontStyle
        blnBiancoeNero = False
        Try
            MioStile = RTB.SelectionFont.Style
        Catch ex As Exception
            MioStile = FontStyle.Regular
        End Try
        fontRTB.Font = RTB.SelectionFont
        Try
            If fontRTB.ShowDialog() = DialogResult.OK Then
                Dim MioFont As New Font(fontRTB.Font, fontRTB.Font.Style)
                RTB.Font = MioFont
                RTB.SelectionFont = MioFont
                MisuraFontPredefinito = RTB.Font.Size
                NomeFontPredefinito = RTB.Font.Name
                FontPredefinito = MioFont
            End If
        Catch ex As Exception
            Dim MioFont As New Font("Verdana", 16, System.Drawing.FontStyle.Regular)
            'MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub BiancoNero()
        Dim MisuraFont As Single = RTB.Font.Size
        Dim MioFont As Font
        Try
            MioFont = CreateFont(Percorso & "\BiancoeneroBook.ttf", FontStyle.Regular, MisuraFont, RTB.Font.Unit)
            RTB.Font = MioFont
            blnBiancoeNero = True
            ImpostaInterlinea(RTB)
        Catch ex As Exception
            blnBiancoeNero = False
        End Try
    End Sub

    Private Sub btnAnnulla_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnnulla.Click
        If RTB.CanUndo Then
            RTB.Undo()
        End If
    End Sub

    Private Sub btnRipristina_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRipristina.Click
        If RTB.CanRedo Then
            RTB.Redo()
        End If
    End Sub

    Private Sub RTB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles RTB.DoubleClick
        Dim misura As Size
        If RTB.SelectionType = 2 Then
            Dim selDa As Integer = RTB.SelectionStart
            Dim selLun As Integer = RTB.SelectionLength
            'RTB.Copy()
            RTB.Focus()
            Clipboard.Clear()
            Dim volte As Integer = 0
            Do
                volte += 1
                Me.Text = volte
                'Threading.Thread.Sleep(100)
                'SendKeys.SendWait("^(c)")
                'Threading.Thread.Sleep(100)
                RTB.Copy()
                Try
                    If Clipboard.ContainsImage Then
                        Exit Do
                    End If
                Catch ex As Exception

                End Try
            Loop

            RTB.Select(selDa, 1)

            If Clipboard.ContainsImage Then
                misura = Clipboard.GetImage.Size
            Else
                MsgBox("Non c'è")
                Exit Sub
            End If
            'frmImmagini.ShowDialog()
            'Dim proc As Process
            'Dim prg As String = My.Application.Info.DirectoryPath & "\Disegna.exe"
            'Try
            'proc = Process.Start(prg, "7")
            'proc.WaitForExit()
            'Catch ex As Exception
            'MsgBox(ex.Message)
            'End Try

            'Me.Hide()
            frmDisegna.ShowDialog()

            If Clipboard.ContainsImage Then
                RTB.SelectionStart = selDa
                RTB.SelectionLength = selLun
                Dim n As Integer = RTB.SelectionStart
                RidimensionaImmagineInClipboard(misura.Width)
                RTB.Paste()
                RTB.Select(n, 1)
            End If
        End If
    End Sub


    Private Sub RTB_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles RTB.KeyPress

        If m_bSpeaking = True Or m_bPaused = True Then
            FermaVoce()
        Else
            Dim KeyAscii As Integer = Asc(e.KeyChar)

            Dim c As Integer = KeyAscii

            If ckLeggeParola.Checked = True Then
                blnLeggereParola = False
                If InStr(SpaziFine, Chr(c)) <> 0 Then
                    blnLeggereParola = FormaParola()
                End If
            End If
            If ckLeggeFrase.Checked = True Then
                If c = Asc(".") Or c = Asc("!") Or c = Asc("?") Then
                    blnLeggiFrase = True
                End If
            End If
            e.KeyChar = Chr(KeyAscii)
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub RTB_KeyUp(ByVal sender As Object, ByVal e As KeyEventArgs) Handles RTB.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        Dim PosStart As Integer = RTB.SelectionStart

        If blnLeggereParola = True Then
            RTB.SelectionStart = PosStart '+ Len(UnaParola) ' + 1
            SenzaEco(UnaParola)
            'PosAttuale = RTB.SelectionStart
            blnLeggereParola = False
            'If blnInserisciImmagine = False Then UnaParola = ""
        End If

        If blnLeggiFrase = True Then
            blnLeggiFrase = False
            'RTB.SelectionStart = start
            LeggiLaFrase()
        End If
        If KeyCode = Keys.F11 And tbRiassunto.Visible = True Then
            EvidenziaPerRiassunto()
        End If
        If KeyCode = Keys.F7 Then
            If VoceStaParlando() = True Then
                FermaVoce()
            Else
                RTB.SelectionStart = 1
                RTB.SelectionLength = 0
                Leggi()
            End If
        ElseIf KeyCode = Keys.F8 Then
            If VoceStaParlando() = True Then
                FermaVoce()
            Else
                Leggi()
            End If
        End If
    End Sub

    Sub LeggiLaFrase()
        Dim fine As Integer = RTB.SelectionStart
        If fine < 5 Then Exit Sub
        Dim inizio As Integer = InStrRev(RTB.Text, ".", fine - 1)
        Dim i As Integer = InStrRev(RTB.Text, "?", fine - 1)
        If i > inizio Then inizio = i
        i = InStrRev(RTB.Text, "!", fine - 1)
        If i > inizio Then inizio = i
        If inizio = 0 Then inizio = 1
        If inizio > fine - 2 Then Exit Sub
        SenzaEco(Mid(RTB.Text, inizio, fine - inizio + 1))
    End Sub

    Private Sub RTB_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RTB.DragDrop
        Dim img As Image
        Try
            img = Image.FromFile(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString)
            Clipboard.SetImage(img)
            RidimensionaImmagineInClipboard()
            RTB.Paste()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub RTB_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RTB.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    Private Sub RTB_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RTB.MouseWheel
        If RTB.SelectionType = 2 Then
            If e.Delta > 0 Then
                RidimensionaImmagine(RTB, 1)
            ElseIf e.Delta < 0 Then
                RidimensionaImmagine(RTB, -1)
            End If
        End If
    End Sub

    Private Sub RTB_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles RTB.TextChanged
        blnSalvato = False
        ' blnTempSalvato = False
    End Sub

    Function FormaParola() As Boolean
        Dim tmp As String = ""
        Dim t As String = ""
        Dim a As String = ""
        Dim l As Integer = 0
        On Error GoTo Trap

        t = Mid(RTB.Text, 1, RTB.SelectionStart)

        If Len(t) = 0 Then Exit Function

        For l = Len(t) To 1 Step -1
            a = Mid(t, l, 1)
            If InStr(spaziInizio, a) <> 0 Then Exit For
            tmp = a & tmp
        Next l
        UnaParola = tmp
        If UnaParola <> "" Then
            Return True
        Else
            Return False
        End If

        Exit Function

Trap:
        MsgBox(Err.Description)
        Err.Clear()

    End Function

    Private Sub rbLavagna_Click(ByVal sender As Object, ByVal e As EventArgs) Handles rbLavagna.Click
        ControlloColore(rbLavagna)
        blnEffettoLavagna = Not blnEffettoLavagna
        LavagnaRTB(RTB)
    End Sub

    Private Sub btnMP3_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnMP3.Click
        blnMP3 = True
        Dim t As String = RTB.SelectedText
        If Len(t) < 2 Then
            t = RTB.Text.Replace(" i ", " ì ")
            t = t.Replace(" I ", " ì ")
        End If
        SalvaWave(Me, t)
    End Sub

    Private Sub btnCarattere_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCarattere.Click
        Dim fontRTB As New FontDialog
        Dim MioStile As FontStyle
        Try
            MioStile = RTB.SelectionFont.Style
        Catch ex As Exception
            MioStile = FontStyle.Regular
        End Try
        fontRTB.Font = RTB.SelectionFont
        Try
            If fontRTB.ShowDialog() = DialogResult.OK Then
                Dim MioFont As New Font(fontRTB.Font, fontRTB.Font.Style)
                RTB.SelectionFont = MioFont
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnColore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnColore.Click
        Dim colorRTB As New ColorDialog
        If colorRTB.ShowDialog() = DialogResult.OK Then
            Dim MioColore As Color = colorRTB.Color
            RTB.SelectionColor = MioColore
        End If
    End Sub

    Private Sub ImpostaIlFont(ByVal stile As Integer)

        Dim textStyle As New FontStyle
        Select Case stile
            Case 1 : textStyle = FontStyle.Bold
            Case 2 : textStyle = FontStyle.Italic
            Case 3 : textStyle = FontStyle.Bold Or FontStyle.Italic
            Case 4 : textStyle = FontStyle.Underline
            Case 5 : textStyle = FontStyle.Bold Or FontStyle.Underline
            Case 6 : textStyle = FontStyle.Italic Or FontStyle.Underline
            Case 7 : textStyle = FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline
        End Select

        Dim bfont As New Font(RTB.Font, textStyle)

        RTB.SelectionFont = New Font(RTB.SelectionFont, textStyle)

    End Sub

    Private Sub btnBold_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBold.Click
        On Error Resume Next
        Dim Grassetto As Integer = 0
        If RTB.SelectionFont.Bold = True Then Grassetto = 1
        Dim Corsivo As Integer = 0
        If RTB.SelectionFont.Italic = True Then Corsivo = 2
        Dim Sottolineato As Integer = 0
        If RTB.SelectionFont.Underline = True Then Sottolineato = 4

        If Grassetto = 0 Then
            Grassetto = 1
        Else
            Grassetto = 0
        End If

        Dim stile As Integer = Grassetto + Corsivo + Sottolineato

        ImpostaIlFont(stile)
    End Sub

    Private Sub btnCorsivo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCorsivo.Click
        On Error Resume Next
        Dim Grassetto As Integer = 0
        If RTB.SelectionFont.Bold = True Then Grassetto = 1
        Dim Corsivo As Integer = 0
        If RTB.SelectionFont.Italic = True Then Corsivo = 2
        Dim Sottolineato As Integer = 0
        If RTB.SelectionFont.Underline = True Then Sottolineato = 4

        If Corsivo = 0 Then
            Corsivo = 2
        Else
            Corsivo = 0
        End If

        Dim stile As Integer = Grassetto + Corsivo + Sottolineato

        ImpostaIlFont(stile)
    End Sub

    Private Sub btnSottolineato_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSottolineato.Click
        On Error Resume Next
        Dim Grassetto As Integer = 0
        If RTB.SelectionFont.Bold = True Then Grassetto = 1
        Dim Corsivo As Integer = 0
        If RTB.SelectionFont.Italic = True Then Corsivo = 2
        Dim Sottolineato As Integer = 0
        If RTB.SelectionFont.Underline = True Then Sottolineato = 4

        If Sottolineato = 0 Then
            Sottolineato = 4
        Else
            Sottolineato = 0
        End If

        Dim stile As Integer = Grassetto + Corsivo + Sottolineato

        ImpostaIlFont(stile)
    End Sub

    Private Sub btnEvidenziatore_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEvidenziatore.Click
  
        RTB.SelectionBackColor = Color.Yellow
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Private Sub btnASinistra_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnASinistra.Click
        RTB.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub btnCentra_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCentra.Click
        RTB.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub btnADestra_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnADestra.Click
        RTB.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Sub fnTaglia()
        If RTB.SelectedText <> "" Then
            RTB.Cut()
        End If
    End Sub

    Sub fnCopia()
        RTB.Copy()
        If RTB.SelectionType = 2 Then
            SendKeys.SendWait("^(c)")
        End If

        'RTB.Focus()
        'SendKeys.SendWait("^(c)")
    End Sub

    Sub fnIncolla()
        If My.Computer.Clipboard.ContainsText Or My.Computer.Clipboard.ContainsImage Then
            RTB.Paste()
            RTB.SelectionLength = 0
            Maiuscolo_Minuscolo()
        End If
    End Sub

    Private Sub btnTaglia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTaglia.Click
        fnTaglia()
    End Sub

    Private Sub btnCopia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCopia.Click
        fnCopia()
    End Sub

    Private Sub btnIncolla_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIncolla.Click
        fnIncolla()
    End Sub

    Dim blnTrovaNuovo As Boolean = True

    Private Sub btnTrovaParola_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTrovaParola.Click
        If blnTrovaNuovo = True Then
            lblOccorrenze.Text = TrovaLaParola().ToString
        End If
        TrovaParola()

    End Sub

    Private Sub TrovaParola()
        Static Dim ps As Integer
        Dim p As Integer
        If blnTrovaNuovo = True Then ps = 1
        blnTrovaNuovo = False
        p = RTB.Find(txtTrova.Text, ps, Len(RTB.Text), RichTextBoxFinds.None)
        If p = -1 Then
            MsgBox("Fine della ricerca", MsgBoxStyle.Information)
            ps = 1
        Else
            ps = p + 1
        End If
    End Sub

    Private Function TrovaLaParola() As Integer
        Dim ps As Integer
        Dim p As Integer
        Dim n As Integer = 0
        Do
            p = RTB.Find(txtTrova.Text, ps, Len(RTB.Text), RichTextBoxFinds.None)
            If p = -1 Then
                Return n
                ps = 1
            Else
                n += 1
                ps = p + 1
            End If
        Loop

    End Function

    Private Sub btnContaParole_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnContaParole.Click
        lblNumParole.Text = ContaParole().ToString
    End Sub

    Function ContaParole() As Integer
        If RTB.Text = "" Then
            Return 0
        Else
            Dim chArr() As Char = {Chr(10), Chr(13)}
            Dim t As String = Trim(RTB.Text)
            t = t.TrimStart(chArr)
            t = t.TrimEnd(chArr)
            Return UBound(Regex.Split(t, "\W+")) + 1
        End If

    End Function


#Region "Ortografia"

    Dim blnMostaErrori As Boolean = False
    Dim NumErrori As Integer = 0
    Const MassSuggerimenti As Integer = 100
    Const MaxErrori As Integer = 200
    Dim lemma(MaxErrori) As String
    Dim errata(MaxErrori) As String
    Dim NumSuggerimenti(MaxErrori) As Integer
    Dim Suggerimenti(MaxErrori, MassSuggerimenti) As String

    Sub IgnoraTutto()
        RTB.SelectAll()
        Dim U As New Underline(Me.RTB)
        U.SelectionUnderlineStyle = Underline.UnderlineStyle.None
        RTB.SelectionStart = 1
        RTB.SelectionLength = 0
    End Sub

    Sub MettiOnda()

        Dim U As New Underline(Me.RTB)
        'MsgBox(U.SelectionUnderlineStyle & vbCrLf & U.SelectionUnderlineColor)

        Try
            If RTB.SelectionFont.Underline = False Then
                U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave
                U.SelectionUnderlineColor = Underline.UnderlineColor.Red
                'MsgBox("1" & U.SelectionUnderlineColor.ToString)
            Else
                U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave
                U.SelectionUnderlineColor = Underline.UnderlineColor.Magenta
                'MsgBox("2" & U.SelectionUnderlineColor.ToString)
            End If
        Catch ex As Exception
        End Try

        U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave

    End Sub

    Sub TogliOnda()

        Dim U As New Underline(Me.RTB)
        If U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave Then
            If U.SelectionUnderlineColor = Underline.UnderlineColor.Red Then
                'U.SelectionUnderlineColor = Underline.UnderlineColor.White 'Underline.UnderlineColor.Black
                U.SelectionUnderlineStyle = Underline.UnderlineStyle.None
                'U.SelectionUnderlineColor = Underline.UnderlineColor.White
            Else
                U.SelectionUnderlineStyle = Underline.UnderlineStyle.Normal
                U.SelectionUnderlineColor = Underline.UnderlineColor.Black
            End If

        End If

    End Sub

    Private Sub btnTrovaErrori_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTrovaErrori.Click
        If RTB.TextLength = 0 Then Exit Sub
        If panErrori.Visible = True Then
            blnMostaErrori = False
            panErrori.Visible = False
            IgnoraTutto()
        End If
        AdattaRTB()
        SegnaErrori()
    End Sub

    Private Sub btnCorreggiErrori_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCorreggiErrori.Click
        If RTB.TextLength = 0 Then Exit Sub
        CorreggiErrori()
    End Sub

    Private Sub CorreggiErrori()
        IgnoraTutto()
        blnMostaErrori = True
        panErrori.Top = RTB.Top
        panErrori.Visible = True
        AdattaRTB()
        lblTrovati.Text = "ATTENDERE..."
        Me.Refresh()
        Ortografia()
    End Sub

    Sub SegnaErrori()
        Dim p As Integer = 0
        Me.Cursor = Cursors.WaitCursor

        TrovaErrori()
        If blnInterrompi = True Then
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Dim k As Integer
        For k = 1 To NumErrori
            Try
                RTB.Find(errata(k), p, Len(RTB.Text), RichTextBoxFinds.WholeWord)
                MettiOnda()
                p = RTB.SelectionStart + RTB.SelectionLength
            Catch ex As Exception
                'MsgBox(k & errata(k))
            End Try
        Next
        RTB.SelectionStart = 0
        RTB.SelectionLength = 0
        Me.Cursor = Cursors.Default

    End Sub

    Dim blnInterrompi As Boolean = False


    Sub TrovaErrori()
        Dim i As Integer = 0, k As Integer = 0, h As Integer = 0
        Dim ProcID As Integer = 0
        Dim parola As String = ""

        Try
            My.Computer.FileSystem.DeleteFile(CartellaTemp & "testo.txt")
            My.Computer.FileSystem.DeleteFile(CartellaTemp & "errori.txt")
        Catch ex As Exception

        End Try

        If Lingua(intParlante) = Francese Then
            My.Computer.FileSystem.WriteAllText(CartellaTemp & "testo.txt", RTB.Text, False, System.Text.Encoding.UTF8)
        Else
            My.Computer.FileSystem.WriteAllText(CartellaTemp & "testo.txt", RTB.Text, False, System.Text.Encoding.GetEncoding(28605))
        End If

        comando = FormaComando()
        ProcID = Shell(comando, AppWinStyle.Hide, Wait:=True)

        Dim f As Integer = FreeFile()
        Dim lett As String = CartellaTemp & "errori.txt"
        blnInterrompi = False
        NumErrori = 0

        If Lingua(intParlante) = Francese Then
            Dim sr As IO.StreamReader = IO.File.OpenText(lett)

            While sr.Peek <> -1
                parola = sr.ReadLine()
                If parola <> "" Then
                    If Asc(parola) = 38 And Mid(parola, 3, 2) <> "ï " Then
                        'MsgBox(parola)
                        NumErrori = NumErrori + 1
                        If NumErrori > MaxErrori Then
                            MsgBox("In questo testo vi sono più di " & MaxErrori & " errori: sarebbe follia correggerlo.", MsgBoxStyle.Critical)
                            blnInterrompi = True
                            FileClose(f)
                            Me.Cursor = Cursors.AppStarting
                            Exit Sub
                        End If
                        lemma(NumErrori) = Mid(parola, 3)
                        i = InStr(lemma(NumErrori), " ") - 1
                        errata(NumErrori) = Mid(lemma(NumErrori), 1, i)

                        Select Case LCase(errata(NumErrori))
                            Case "qu", "jusqu", "l"  ' , "dell", "nell", "sull", "bell", "quell", "quest"
                                errata(NumErrori) = ""
                                lemma(NumErrori) = ""
                        End Select
                    End If
                End If
            End While
            sr.Close()
        Else
            'Dim lett As String = "errori.txt"
            FileOpen(f, lett, OpenMode.Input)
            While Not EOF(f)
                parola = LineInput(f)
                If parola <> "" Then
                    If Asc(parola) = 38 Then
                        NumErrori = NumErrori + 1
                        If NumErrori > MaxErrori Then
                            MsgBox("In questo testo vi sono più di " & MaxErrori & " errori: sarebbe follia correggerlo.", MsgBoxStyle.Critical)
                            blnInterrompi = True
                            FileClose(f)
                            Me.Cursor = Cursors.AppStarting
                            Exit Sub
                        End If
                        lemma(NumErrori) = Mid(parola, 3)
                        i = InStr(lemma(NumErrori), " ") - 1
                        errata(NumErrori) = Mid(lemma(NumErrori), 1, i)
                        Select Case LCase(errata(NumErrori))
                            Case "all", "coll", "dall", "dell", "nell", "sull", "bell", "quell", "quest"
                                errata(NumErrori) = ""
                                lemma(NumErrori) = ""
                        End Select
                    End If
                End If
            End While
            FileClose(f)
        End If

        Dim quanti As Integer = NumErrori
        If lemma(NumErrori) = "" Then quanti = NumErrori - 1
        For k = NumErrori - 1 To 1 Step -1
            If lemma(k) = "" Then
                For h = k To NumErrori - 1
                    lemma(h) = lemma(h + 1)
                    errata(h) = errata(h + 1)
                Next
                quanti = quanti - 1
                lemma(NumErrori) = ""
                errata(NumErrori) = ""
            End If
        Next

        NumErrori = quanti

        If NumLemmiUtente > 0 Then
            RiduciErroriConDizUtente()
        End If
    End Sub

    Sub RiduciErroriConDizUtente()
        Dim k As Integer = 0, h As Integer = 0
        For k = NumErrori To 1 Step -1
            If CeLaParola(errata(k)) Then
                errata(h) = ""
                lemma(h) = ""
                NumErrori -= 1
                For h = k To NumErrori
                    errata(h) = errata(h + 1)
                    lemma(h) = lemma(h + 1)
                Next
            End If
        Next
    End Sub

    Sub Ortografia()

        Dim k As Integer = 0, h As Integer = 0, ps As Integer = 0
        Dim inizio As Integer = 0, fine As Integer = 0
        Dim Primo As Integer = 0
        Me.Cursor = Cursors.WaitCursor

        TrovaErrori()
        ' aggiungere possibile riduzione da diz utente
        If blnInterrompi = True Then
            lblTrovati.Text = "ERRORI TROVATI 0"
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        lbErrate.Items.Clear()
        lbSuggerimenti.Items.Clear()
        lbPos.Items.Clear()

        If NumErrori < 0 Then NumErrori = 0

        Dim i As Integer = 0
        Dim DaTogliere As Integer = 0
        For k = 1 To NumErrori
            Try
                i = RTB.Find(errata(k), ps, Len(RTB.Text), RichTextBoxFinds.WholeWord)
                If i = -1 Then
                    DaTogliere += 1
                    errata(k) = ""
                    lemma(k) = ""
                Else
                    ps = i
                    lbErrate.Items.Add(errata(k))
                    lbPos.Items.Add(ps)
                End If
            Catch ex As Exception
                MsgBox(ex.Message) ' & " - " & ps & " - " & errata(k))
            End Try
        Next

        If DaTogliere = NumErrori Then
            lblTrovati.Text = "ERRORI TROVATI 0"
            NumErrori = 0
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        For k = 1 To NumErrori
            Do
                If errata(k) = "" Then
                    For i = k To NumErrori - 1
                        errata(i) = errata(i + 1)
                        lemma(i) = lemma(i + 1)
                    Next
                End If
            Loop Until errata(k) <> "" Or k = NumErrori
        Next

        NumErrori -= DaTogliere

        For k = 1 To NumErrori
            NumSuggerimenti(k) = 0
            For h = 1 To MassSuggerimenti 'MaxSuggerimenti
                Suggerimenti(k, h) = ""
            Next h
        Next k

        lblTrovati.Text = "ERRORI TROVATI " & NumErrori

        '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        ' aggiunge i suggerimenti da Diz utente in testa
        If NumLemmiUtente > 0 Then
            For k = 1 To NumErrori
                CercaCorrezione(errata(k))
                If NumParCorrette > 0 Then
                    NumSuggerimenti(k) = NumParCorrette
                    For h = 1 To NumParCorrette
                        Suggerimenti(k, h) = ParCorretta(h)
                    Next
                End If
            Next
        End If
        ' il blocco sopra va inserito sotto, con ricerca di suggerimenti se i suggerimenti sono 0
        ' ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        i = 0

        For k = 1 To NumErrori
            inizio = InStr(1, lemma(k), " ") + 1
            fine = InStr(inizio, lemma(k), " ")
            Primo = NumSuggerimenti(k) + 1
            NumSuggerimenti(k) += CInt(Mid(lemma(k), inizio, fine - inizio))
            inizio = InStr(lemma(k), ":") + 2
            For h = Primo To NumSuggerimenti(k) - 1
                fine = InStr(inizio, lemma(k), ",")
                Suggerimenti(k, h) = Mid(lemma(k), inizio, fine - inizio)
                If Lingua(intParlante) = Francese Then
                    Suggerimenti(k, h) = Suggerimenti(k, h).Replace("Ãª", "ê")
                    Suggerimenti(k, h) = Suggerimenti(k, h).Replace("Ã¢", "â")
                    Suggerimenti(k, h) = Suggerimenti(k, h).Replace("Ã´", "ô")
                    Suggerimenti(k, h) = Suggerimenti(k, h).Replace("Ã©", "é")
                    Suggerimenti(k, h) = Suggerimenti(k, h).Replace("Ã¨", "è")
                End If
                inizio = fine + 2
            Next h
            Try
                Suggerimenti(k, h) = Mid(lemma(k), inizio)
            Catch ex As Exception
            End Try
        Next k
        If lbErrate.Items.Count > 0 Then
            lbErrate.SelectedIndex = 0
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Sub SelezionaErrata(ByVal indice As Integer)

        Try
            Dim k As Integer = 0
            Dim DaCercare As String = lbErrate.Items.Item(indice).ToString
            Dim ps As Integer = CInt(lbPos.Items.Item(indice))
            Dim p As Integer = RTB.Find(DaCercare, ps, Len(RTB.Text), RichTextBoxFinds.WholeWord)
            Dim intTp As Integer = lbSuggerimenti.SelectedIndex
            If p = -1 Then
                TogliErrata()
            Else
                lbSuggerimenti.Items.Clear()
                Dim QuantiSuggerimenti As Integer = NumSuggerimenti(indice + 1)
                If QuantiSuggerimenti > MaxSuggerimenti Then QuantiSuggerimenti = MaxSuggerimenti
                For k = 1 To QuantiSuggerimenti
                    lbSuggerimenti.Items.Add(Suggerimenti(indice + 1, k))
                Next
                lbSuggerimenti.SelectedIndex = intTp
            End If
        Catch ex As Exception

        End Try
        RTB.Focus()

    End Sub

    Sub CorreggiParola()

        TogliOnda()
        If lbSuggerimenti.Items.Count = 0 Then Exit Sub
        On Error Resume Next
        SelezionaErrata(lbErrate.SelectedIndex)
        RTB.SelectedText = lbSuggerimenti.Items.Item(lbSuggerimenti.SelectedIndex).ToString
        RTB.SelectionBackColor = ColoreSfondo  'Color.White

        TogliErrata()

    End Sub

    Sub TogliErrata()

        If NumErrori = 0 Then Exit Sub

        Dim k, h As Integer
        For k = lbErrate.SelectedIndex + 1 To lbErrate.Items.Count - 1
            NumSuggerimenti(k) = NumSuggerimenti(k + 1)
            For h = 1 To NumSuggerimenti(k)
                Suggerimenti(k, h) = Suggerimenti(k + 1, h)
            Next
        Next
        On Error Resume Next
        lbErrate.Items.RemoveAt(lbErrate.SelectedIndex)
        lbPos.Items.RemoveAt(lbErrate.SelectedIndex)
        lbSuggerimenti.Items.Clear()
        lbErrate.SelectedIndex = 0
        SelezionaErrata(lbErrate.SelectedIndex)
        NumErrori -= 1
        lblTrovati.Text = "ERRORI TROVATI " & NumErrori
        If NumErrori = 0 Then
            RTB.SelectionLength = 0
            RTB.SelectionStart = 0
        End If

    End Sub

    Private Sub lbErrate_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lbErrate.SelectedIndexChanged
        On Error Resume Next
        SelezionaErrata(lbErrate.SelectedIndex)
        SenzaEco(CStr(lbErrate.Items.Item(lbErrate.SelectedIndex)))
        RTB.Focus()
    End Sub

    Private Sub lbSuggerimenti_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles lbSuggerimenti.DoubleClick
        CorreggiParola()
    End Sub

    Private Sub lbSuggerimenti_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles lbSuggerimenti.SelectedIndexChanged
        On Error Resume Next
        SenzaEco(CStr(lbSuggerimenti.Items.Item(lbSuggerimenti.SelectedIndex)))
        RTB.Focus()
    End Sub

#End Region

    Private Sub C5_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles C5.CheckedChanged, C10.CheckedChanged, CTutte.CheckedChanged
        Dim c As ToolStripButton = sender
        If c.Checked Then
            c.ForeColor = Color.Red
        Else
            c.ForeColor = Color.Black
        End If
    End Sub

    Private Sub C5_Click(ByVal sender As Object, ByVal e As EventArgs) Handles C5.Click
        MaxSuggerimenti = 5
        C5.Checked = True
        C10.Checked = False
        CTutte.Checked = False
    End Sub
    Private Sub C10_Click(ByVal sender As Object, ByVal e As EventArgs) Handles C10.Click
        MaxSuggerimenti = 10
        C5.Checked = False
        C10.Checked = True
        CTutte.Checked = False
    End Sub
    Private Sub CTutte_Click(ByVal sender As Object, ByVal e As EventArgs) Handles CTutte.Click
        MaxSuggerimenti = 100
        C5.Checked = False
        C10.Checked = False
        CTutte.Checked = True
    End Sub

    Private Sub btnZoomPiu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnZoomPiu.Click
        If RTB.ZoomFactor < 5 Then
            RTB.ZoomFactor = CSng(RTB.ZoomFactor + 0.1)
            FattoreZoom = RTB.ZoomFactor
        End If
    End Sub

    Private Sub btnZoomMeno_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnZoomMeno.Click
        If RTB.ZoomFactor > 0.2 Then
            RTB.ZoomFactor = CSng(RTB.ZoomFactor - 0.1)
            FattoreZoom = RTB.ZoomFactor
        End If
    End Sub

    Private Sub btnZoomVia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnZoomVia.Click
        RTB.ZoomFactor = 1
        FattoreZoom = 1
    End Sub

    Dim blnSelez As Boolean = True

    Private Sub btnEvidenzia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnEvidenzia.Click
        EvidenziaPerRiassunto()
    End Sub

    Sub EvidenziaPerRiassunto()
        RTB.SelectionBackColor = ColoreEvidenziato
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Private Sub btnLeggiEvidenziato_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLeggiEvidenziato.Click
        FermaVoce()
        If blnSelez = True Then
            SenzaEco(TestoEvidenziato)
        Else
            SenzaEco(TestoNonEvidenziato)
        End If
    End Sub

    Private Function TestoEvidenziatoEl() As String
        Dim tempo As String = ""
        Dim i As Integer = 0
        Dim blnEvidenziato As Boolean = False

        inizio = 0
        lungh = RTB.TextLength - 1
        blnRiassuntoParziale = False
        If RTB.SelectedText <> "" Then
            inizio = RTB.SelectionStart
            lungh = RTB.SelectionLength
            blnRiassuntoParziale = True
        End If
        zeppa = inizio
        For i = inizio To inizio + lungh
            RTB.SelectionStart = i
            RTB.SelectionLength = 1
            If RTB.SelectionBackColor.R = 0 Then 'ColoreEvidenziato Then
                tempo = tempo & RTB.SelectedText ' & " "
                blnEvidenziato = True
            Else
                If tempo <> "" Then
                    If blnEvidenziato = True Then
                        tempo = tempo & vbCrLf '" "
                        blnEvidenziato = False
                    End If
                End If
            End If
        Next
        RTB.SelectionLength = 0
        Return tempo
    End Function

    Private Function TestoEvidenziato() As String
        Dim tempo As String = ""
        Dim i As Integer = 0

        inizio = 0
        lungh = RTB.TextLength - 1
        blnRiassuntoParziale = False
        If RTB.SelectedText <> "" Then
            inizio = RTB.SelectionStart
            lungh = RTB.SelectionLength
            blnRiassuntoParziale = True
        End If
        zeppa = inizio
        For i = inizio To inizio + lungh
            RTB.SelectionStart = i
            RTB.SelectionLength = 1
            If RTB.SelectionBackColor.R = 0 Then 'ColoreEvidenziato Then
                tempo = tempo & RTB.SelectedText ' & " "
            Else
                If tempo <> "" Then
                    If Mid(tempo, Len(tempo), 1) <> " " Then
                        tempo = tempo & " "
                    End If
                End If
            End If
        Next
        RTB.SelectionLength = 0
        TestoEvidenziato = tempo
    End Function

    Private Function TestoNonEvidenziato() As String
        Dim tempo As String = ""
        Dim i As Integer = 0

        inizio = 0
        lungh = RTB.TextLength - 1
        blnRiassuntoParziale = False
        If RTB.SelectedText <> "" Then
            inizio = RTB.SelectionStart
            lungh = RTB.SelectionLength
            blnRiassuntoParziale = True
        End If
        zeppa = inizio
        For i = inizio To inizio + lungh
            RTB.SelectionStart = i
            RTB.SelectionLength = 1
            If RTB.SelectionBackColor.R <> 0 Then ' <> ColoreEvidenziato Then
                tempo = tempo & RTB.SelectedText ' & " "
            End If
        Next
        RTB.SelectionLength = 0
        TestoNonEvidenziato = tempo
    End Function

    Dim blnRiassuntoParziale As Boolean = False

    Private Sub btnCancellaEvidenziazione_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancellaEvidenziazione.Click
        btnAnnullaEvidenzia.Enabled = True
        tmpRTF = RTB.Rtf
        Dim Testo As String = ""
        If blnSelez = True Then
            Testo = TestoEvidenziato()
        Else
            Testo = TestoNonEvidenziato()
        End If
        If Testo = "" Then
            RTB.SelectAll()
            RTB.SelectionBackColor = ColoreSfondo
            RTB.SelectionLength = 0
            Exit Sub
        End If

        If blnRiassuntoParziale = False Then
            RTB.Text = Testo
            RTB.SelectAll()
        Else
            RTB.SelectionStart = zeppa
            RTB.SelectionLength = lungh
            Clipboard.SetText(Testo)
            RTB.Paste()
        End If
        RTB.SelectAll()
        RTB.SelectionFont = FontPredefinito
        RTB.SelectionBackColor = ColoreSfondo
        RTB.SelectionStart = 1
        RTB.SelectionLength = 0
        RTB.BackColor = ColoreSfondo
    End Sub

    Private Sub btnAnnullaEvidenzia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAnnullaEvidenzia.Click
        RTB.Rtf = tmpRTF
        btnAnnullaEvidenzia.Enabled = False
    End Sub

    Private Sub btnElenco_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnElenco.Click
        Dim i As Integer = 0
        Dim Testo As String = ""
        btnAnnullaEvidenzia.Enabled = True
        tmpRTF = RTB.Rtf
        If blnSelez = True Then
            Testo = TestoEvidenziatoEl()
        Else
            'Testo = TestoNonEvidenziato()
            MsgBox("ATTENZIONE! Gli elenchi si possono fare solo in modalità 'Conserva?.")
            Exit Sub
        End If
        If Testo = "" Then Exit Sub
        'Testo = Testo.Replace(" ", vbCrLf)
        RTB.Text = Testo
        RTB.SelectAll()
        RTB.SelectionBackColor = ColoreSfondo
        RTB.SelectionLength = 0
        RTB.BackColor = ColoreSfondo
    End Sub

    Dim blnTastiRegistrati As Boolean = False

    Dim ScorciatoieAttive As Boolean = True

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        If m.Msg = WM_HOTKEY And ScorciatoieAttive = True Then

            Dim numTasto As Integer = (CInt(m.WParam))
            Select Case numTasto
                Case 40000
                    'FermaVoce()
                    Leggi()
                Case 40001
                    If blnFinestraAperta = True Then
                        FermaVoce()
                    Else
                        Pausa()
                    End If
                Case 40002
                    AumentaVelocita()
                Case 40003
                    DiminuisciVelocita()
                Case 40004
                    Cattura_Immagine()
                Case Else
            End Select
        End If

        MyBase.WndProc(m)
    End Sub

    Public Sub RegistraTasti()
        If ScorciatoieAttive = False Then
            Exit Sub
        End If
        'Exit Sub
        Call RegisterHotKey(Me.Handle, 40000, MOD_CONTROL, Keys.A)
        Call RegisterHotKey(Me.Handle, 40001, MOD_CONTROL, Keys.S)
        Call RegisterHotKey(Me.Handle, 40002, MOD_CONTROL, Keys.Up)
        Call RegisterHotKey(Me.Handle, 40003, MOD_CONTROL, Keys.Down)
        Call RegisterHotKey(Me.Handle, 40004, MOD_CONTROL, Keys.F)
        blnTastiRegistrati = True
    End Sub

    Private Sub DeRegistraTasti()
        'Exit Sub
        Call UnregisterHotKey(Me.Handle, 40000)
        Call UnregisterHotKey(Me.Handle, 40001)
        Call UnregisterHotKey(Me.Handle, 40002)
        Call UnregisterHotKey(Me.Handle, 40003)
        Call UnregisterHotKey(Me.Handle, 40004)
        blnTastiRegistrati = False
    End Sub

    Private Sub btnRichiudi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRichiudi.Click
        DisattivaLens()
        ChiudiFinestra()
    End Sub

    Private Sub Annulla_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Annulla.Click
        If RTB.CanUndo Then
            RTB.Undo()
        End If
    End Sub

    Private Sub Ripristina_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Ripristina.Click
        If RTB.CanRedo Then
            RTB.Redo()
        End If
    End Sub

    Private Sub Taglia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Taglia.Click
        fnTaglia()
    End Sub

    Private Sub Copia_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Copia.Click
        fnCopia()
    End Sub

    Private Sub Incolla_Testo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Incolla_Testo.Click
        If My.Computer.Clipboard.ContainsText Then
            RTB.SelectedText = Clipboard.GetText
        End If
    End Sub

    Private Sub Incolla_Tutto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Incolla_Tutto.Click
        fnIncolla()
    End Sub

    Private Sub Sinonimi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Sinonimi.Click
        CercaSinonimi()
    End Sub

    Sub Traduci()

        If RTB.SelectedText = "" Then
            If RTB.Text <> "" Then
                fnSinonimi()
            End If
        End If

        Dim p As String = RTB.SelectedText
        If RTB.SelectedText <> "" Then
            RTB.SelectionStart = RTB.SelectionStart + RTB.SelectionLength
            RTB.SelectionLength = 0
        End If
        Me.TopMost = True
        With frmDizio
            .txtDaCercare.Text = p
            .ShowDialog()
        End With
        Me.TopMost = False
    End Sub

    Sub CercaSinonimi()

        ScegliLingua(intParlante)
        If RTB.Text = "" Then Exit Sub

        If RTB.SelectedText = "" Then
            fnSinonimi()
        End If

        If RTB.SelectedText <> "" Then MostraSinonimi(RTB.SelectedText)
    End Sub

    Private Sub fnSinonimi()

        If RTB.Text = "" Then Exit Sub

        Dim i As Integer = RTB.SelectionStart
        If i < 1 Then i = 1
        If Mid(RTB.Text, i, 1) <= " " Then
            If i < 1 Then Exit Sub
        End If

        Do
            If i > 0 Then
                If InStr(Spazi, Mid(RTB.Text, i, 1)) = 0 Then
                    i -= 1
                Else
                    Exit Do
                End If
            Else
                Exit Do
            End If
        Loop
        Dim l As Integer = 1
        Do
            If InStr(Spazi, Mid(RTB.Text, i + l, 1)) = 0 Then
                l += 1
            Else
                Exit Do
            End If
        Loop

        RTB.SelectionStart = i
        RTB.SelectionLength = l - 1

        Dim ii As Integer = InStr(RTB.SelectedText, "'")
        If ii = Len(RTB.SelectedText) Then ii = 0
        If ii = 0 Then
            ii = InStr(RTB.SelectedText, Chr(146))
            If ii = Len(RTB.SelectedText) Then ii = 0
        End If
        RTB.SelectionStart += ii
        RTB.SelectionLength -= ii

    End Sub

    Private Sub AggiungiAdAppuntiToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles AggiungiAdAppunti.Click
        AggiungiAgliAppunti()
    End Sub

    Sub AggiungiAgliAppunti()
        If RTB.Text = "" Then Exit Sub
        If RTB.Text = Appunti(NAppunti) Then Exit Sub
        NAppunti += 1
        ReDim Preserve Appunti(NAppunti)
        If RTB.SelectionLength > 0 Then
            Appunti(NAppunti) = RTB.SelectedText
        Else
            Appunti(NAppunti) = RTB.Text
        End If
    End Sub

    Sub NascondiTraduttore()
        If CeDizionario() = False Then
            'TradIItaIngToolStripMenuItem.Visible = False
            If blnInternet = False Then
                btnTrad.Visible = False
            End If
        End If

    End Sub

    Private Sub btnAppunti_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAppunti.Click
        DisattivaLens()
        frmAPP.Show()
        Me.Hide()
    End Sub

    Private Sub btnPDF_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPDF.Click
        DisattivaLens()
        frmPDF.Show()
        Me.Hide()
    End Sub


    Sub LeggiImpostazioni()

        ChDrive(My.Application.Info.DirectoryPath)
        ChDir(My.Application.Info.DirectoryPath)

        If IO.File.Exists(PercorsoOrtografici & "\LeggiXme_SP.cfg") Then
            Using sw As New System.IO.StreamReader(PercorsoOrtografici & "\LeggiXme_SP.cfg", False)
                NomeVocePrincipale = sw.ReadLine
                Velocita = CInt(sw.ReadLine)
                interlinea = CInt(sw.ReadLine)
                NomeFontPredefinito = sw.ReadLine
                MisuraFontPredefinito = CSng(sw.ReadLine)
                AmpiezzaPannelloPDF = CInt(sw.ReadLine)
                If AmpiezzaPannelloPDF <= 200 Then
                    AmpiezzaPannelloPDF = -1
                End If
                Dim a As String = ""
                Try
                    a = sw.ReadLine
                    If a = "True" Then
                        blnAggTesto = True
                        AggTesto.Checked = True
                    End If
                Catch ex As Exception
                End Try
                Try
                    a = sw.ReadLine
                    If a = "True" Then
                        ScorciatoieAttive = True
                        ckScorciatoie.Checked = True
                    Else
                        ScorciatoieAttive = False
                        ckScorciatoie.Checked = False
                    End If
                Catch ex As Exception
                End Try
            End Using
        Else
            NomeVocePrincipale = "Microsoft Server Speech Text to Speech Voice (it-IT, Lucia)"
            NomeFontPredefinito = "Verdana"
            MisuraFontPredefinito = 14
            Velocita = 0
            interlinea = 1
            AmpiezzaPannelloPDF = -1
        End If
        If NomeFontPredefinito = "" Then NomeFontPredefinito = "Verdana"
        If MisuraFontPredefinito < 8 Or MisuraFontPredefinito > 36 Then MisuraFontPredefinito = 14

        If Velocita > 8 Then Velocita = 8
        ImpostaInterlinea(RTB)
        Parlante = NomeVocePrincipale
        Volume = 99 ' lo metto al massimo
        lblVelocita.Text = CStr(Velocita)

        If NomeFontPredefinito = "BiancoeneroBook" Then
            BiancoNero()
            NomeFontPredefinito = RTB.Font.Name
        Else
            Dim MioFont As New Font(NomeFontPredefinito, MisuraFontPredefinito, System.Drawing.FontStyle.Regular)
            RTB.Font = MioFont
        End If

        If RTB.Font.Name <> NomeFontPredefinito Then
            RTB.Font = New Font("Verdana", 14, FontStyle.Regular)
        End If
        Risoluzione = TrovaZoom()
    End Sub

    Sub SalvaImpostazioni()
        If PercorsoOrtografici <> "" Then
            Dim NFP As String = NomeFontPredefinito
            If NFP = "Biancoenero Book" Then NFP = "BiancoeneroBook"
            Using sw As New System.IO.StreamWriter(PercorsoOrtografici & "\LeggiXme_SP.cfg", False)
                sw.WriteLine(NomeVocePrincipale)
                sw.WriteLine(CStr(Velocita))
                sw.WriteLine(CStr(interlinea))
                sw.WriteLine(NFP)
                sw.WriteLine(CStr(CInt(MisuraFontPredefinito)))
                sw.WriteLine(CStr(AmpiezzaPannelloPDF))
                sw.WriteLine(blnAggTesto.ToString)
                sw.WriteLine(ScorciatoieAttive.ToString)
            End Using
        End If

    End Sub

    Private Sub btnProva_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnProva.Click
        SenzaEco("Questo è un testo di prova.")
    End Sub

    Sub ChiudiFinestra()

        AggiungiAgliAppunti()
        tmrSalva.Enabled = False
        Try
            frmPDF.Close()
        Catch ex As Exception
        End Try
        DeRegistraTasti()
        Try
            frmLettore.Show()
            Me.Hide()
        Catch ex As Exception
            MsgBox(ex.Message)
            Me.Show()
        End Try

    End Sub

    Private Sub btnInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInfo.Click

        frmAboutBox.ShowDialog()

        If blnManuale = True Then
            blnManuale = False
            Try
                If CePDFViewer() = True Then
                    Dim processo As String = PDFXCviewer()
                    Dim myProcess As Process = System.Diagnostics.Process.Start(processo, Percorso & "\Manuale_LeggiXme_SP.pdf")
                Else
                    Dim myProcess As Process = System.Diagnostics.Process.Start(Percorso & "\Manuale_LeggiXme_SP.pdf")
                End If
                ChiudiFinestra()
            Catch ex As Exception
                MsgBox("Problemi col manuale.", MsgBoxStyle.Critical)
            End Try
        ElseIf blnSito = True Then
            Try
                Process.Start("https://sites.google.com/site/leggixme")
                ChiudiFinestra()
            Catch ex As Exception
                MsgBox("Non c'è connessione ad internet.", MsgBoxStyle.Critical)
            End Try

        End If
    End Sub

    Private Sub btnLeggi_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs) Handles btnLeggi.MouseUp, btnStop.MouseUp, btnLingua.MouseUp, _
        btnRichiudi.MouseUp, btnModifica.MouseUp, btnAudio.MouseUp, btnVisualizza.MouseUp, _
        btnCorrettore.MouseUp, btnRiassunto.MouseUp, btnTrova.MouseUp, btnPDF.MouseUp, btnAppunti.MouseUp, btnTrad.MouseUp, _
        btnCalcola.MouseUp, btnAnnulla.MouseUp, btnRipristina.MouseUp, btnInfo.MouseUp

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.ToolTipText)
        Else
            RTB.Focus()
        End If
    End Sub

    Private Sub btnFile_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnFile.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi("fàail")
        End If
    End Sub

    Private Sub btnTrad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnTrad.Click

    End Sub

    Sub AvviaDizionario()
        Dim pd As String = PercorsoDizionario
        If PercorsoDizionario = "" Then
            MsgBox("Il dizionario per le traduzioni non è presente", MsgBoxStyle.Critical)
        Else
            ChDir(PercorsoDizionario)
            Dim proc As Process = Process.Start("dizio.exe")
            ChDir(Percorso)
        End If
    End Sub

    Sub AvviaTraduttore()
        Dim miaPos As Integer = RTB.SelectionStart
        Dim lunghezza As Integer = RTB.SelectionLength

        RTB.SelectionStart = miaPos
        RTB.SelectionLength = lunghezza

        Try
            If RTB.Text = "" Then
                Clipboard.Clear()
            Else
                If RTB.SelectedText <> "" Then
                    Clipboard.SetText(RTB.SelectedText)
                Else
                    Clipboard.SetText(RTB.Text)
                End If
            End If

            frmTRAD.Show()
            RTB.SelectionStart = miaPos + lunghezza
            RTB.SelectionLength = 0
            Me.Hide()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub tmrSalva_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles tmrSalva.Tick

        If RTB.Text <> "" And blnSalvato = False Then
            RTB.SaveFile(FileTemporaneo)
            blnTempSalvato = True
        End If
    End Sub

    Private Sub btnSostituisci_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSostituisci.Click
        CorreggiParola()
    End Sub

    Private Sub btnIgnora_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIgnora.Click
        TogliOnda()
        'RTB.SelectionBackColor = Color.White
        TogliErrata()
        'RTB.SelectionLength = 0
    End Sub

    Private Sub btnAggiungi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAggiungi.Click
        Try
            Dim NuovaParola As String = CStr(lbErrate.Items.Item(lbErrate.SelectedIndex))
            AggiornaDizionarioUtente(NuovaParola)
            TogliErrata()
        Catch ex As Exception
            MsgBox("SI POSSONO INSERIRE SOLO PAROLE PRESENTI NEL RIQUADRO" & vbCrLf & "'ERRORI TROVATI'", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnIgnoraTutto_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnIgnoraTutto.Click
        NascondiMenu()
    End Sub

    Private Sub btnSinonimi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSinonimi.Click
        CercaSinonimi()
    End Sub

    Sub CaratteriSpeciali()

        Dim c(40) As String

        c(1) = Chr(192) : car1.Text = c(1)
        c(2) = Chr(193) : car2.Text = c(2)
        c(3) = Chr(194) : car3.Text = c(3)
        c(4) = Chr(196) : car4.Text = c(4)

        c(5) = Chr(200) : car5.Text = c(5)
        c(6) = Chr(201) : car6.Text = c(6)
        c(7) = Chr(202) : car7.Text = c(7)
        c(8) = Chr(203) : car8.Text = c(8)

        c(9) = Chr(204) : car9.Text = c(9)
        c(10) = Chr(205) : car10.Text = c(10)
        c(11) = Chr(206) : car11.Text = c(11)
        c(12) = Chr(207) : car12.Text = c(12)

        c(13) = Chr(210) : car13.Text = c(13)
        c(14) = Chr(211) : car14.Text = c(14)
        c(15) = Chr(212) : car15.Text = c(15)
        c(16) = Chr(214) : car16.Text = c(16)

        c(17) = Chr(217) : car17.Text = c(17)
        c(18) = Chr(218) : car18.Text = c(18)
        c(19) = Chr(219) : car19.Text = c(19)
        c(20) = Chr(220) : car20.Text = c(20)

        c(21) = Chr(225) : car21.Text = c(21)
        c(22) = Chr(226) : car22.Text = c(22)
        c(23) = Chr(228) : car23.Text = c(23)

        c(24) = Chr(234) : car24.Text = c(24)
        c(25) = Chr(235) : car25.Text = c(25)

        c(26) = Chr(237) : car26.Text = c(26)
        c(27) = Chr(238) : car27.Text = c(27)
        c(28) = Chr(239) : car28.Text = c(28)

        c(29) = Chr(243) : car29.Text = c(29)
        c(30) = Chr(244) : car30.Text = c(30)
        c(31) = Chr(246) : car31.Text = c(31)

        c(32) = Chr(250) : car32.Text = c(32)
        c(33) = Chr(251) : car33.Text = c(33)
        c(34) = Chr(252) : car34.Text = c(34)

        c(35) = Chr(199) : car35.Text = c(35)
        c(36) = Chr(209) : car36.Text = c(36)
        c(37) = Chr(241) : car37.Text = c(37)
        c(38) = Chr(191) : car38.Text = c(38)
        c(39) = Chr(161) : car39.Text = c(39)
        c(40) = Chr(223) : car40.Text = c(40)
        tbCaratteri.Visible = False
        Me.Refresh()
        '
    End Sub

    Private Sub btnSpeciali_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSpeciali.Click
        MostraCaratteriSpeciali()
    End Sub

    Sub MostraCaratteriSpeciali()

        If tbCaratteri.Visible = True Then
            tbCaratteri.Visible = False
            RTB.Top -= AltezzaToolbar
            RTB.Height += AltezzaToolbar
        Else
            tbCaratteri.Visible = True
            RTB.Top += AltezzaToolbar
            RTB.Height -= AltezzaToolbar
        End If
    End Sub

    Private Sub car1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles car1.Click, car2.Click, _
      car3.Click, car4.Click, car5.Click, car6.Click, car7.Click, car8.Click, car9.Click, car10.Click, car11.Click, car12.Click, _
      car13.Click, car14.Click, car15.Click, car16.Click, car17.Click, car18.Click, car19.Click, car20.Click, car21.Click, car22.Click, _
      car23.Click, car24.Click, car25.Click, car26.Click, car27.Click, car28.Click, car29.Click, car30.Click, car31.Click, car32.Click, car33.Click, _
      car34.Click, car35.Click, car36.Click, car37.Click, car38.Click, car39.Click, car40.Click

        RTB.SelectedText = sender.text

    End Sub

    Private Sub btnNuovo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnNuovo.MouseUp, btnSalva.MouseUp, btnApri.MouseUp, _
    btnImpostaPagina.MouseUp, btnAnteprimaDiStampa.MouseUp, btnStampa.MouseUp, btnCaratterePredefinito.MouseUp, FiltroPDF.MouseUp

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.ToolTipText)
        End If
    End Sub

    Private Sub btnMeno_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMeno.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.ToolTipText)
        End If
    End Sub

    Private Sub ckLeggeParola_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ckLeggeParola.MouseUp, ckLeggeFrase.MouseUp, rbSel.MouseUp, rbCanc.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.ToolTipText)
        End If
    End Sub

    Private Sub lblVeloc_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblVeloc.MouseUp, btnMeno.MouseUp, btnPiu.MouseUp, ToolStripLabel2.MouseUp, _
    btnProva.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.ToolTipText)
        End If
    End Sub

    Private Sub btnImmagine_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnImmagine.MouseUp, btnImg.MouseUp, btnCarattere.MouseUp, _
    btnColore.MouseUp, btnEvidenziatore.MouseUp, btnBold.MouseUp, btnCorsivo.MouseUp, btnSottolineato.MouseUp, btnASinistra.MouseUp, btnCentra.MouseUp, btnADestra.MouseUp, _
    btnTaglia.MouseUp, btnCopia.MouseUp, btnIncolla.MouseUp, btnElencoPunt.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.ToolTipText)
        End If
    End Sub

    Private Sub btnTrovaParola_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTrovaParola.MouseUp, btnEvidenzia.MouseUp, btnLeggiEvidenziato.MouseUp, _
    btnCancellaEvidenziazione.MouseUp, btnElenco.MouseUp, btnContaParole.MouseUp, btnAnnullaEvidenzia.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.ToolTipText)
        End If
    End Sub

    Private Sub btnTrovaErrori_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTrovaErrori.MouseUp, btnCorreggiErrori.MouseUp, ToolStripLabel25.MouseUp, btnSinonimi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.ToolTipText)
        End If
    End Sub

    Private Sub btnSpeciali_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSpeciali.MouseUp, btnZoomPiu.MouseUp, btnZoomMeno.MouseUp, btnZoomVia.MouseUp, ToolStripLabel21.MouseUp, _
    rbMin.MouseUp, rbMaiu.MouseUp, rbSmall.MouseUp, ToolStripLabel23.MouseUp, rbLavagna.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.ToolTipText)
        End If
    End Sub

    Private Sub lbLingua_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbLingua.MouseUp, ToolStripLabel12.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.Text)
        End If
    End Sub

    Private Sub ScientificaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ScientificaToolStripMenuItem.Click
        frmCalc.Show()
    End Sub

    Private Sub NormaleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NormaleToolStripMenuItem.Click
        frmCalcolatrice.Show()
    End Sub

    Private Sub btnPreparaGlossario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Hide()
        Shell("PrepGloss.exe", AppWinStyle.NormalFocus, True)
        Me.Show()
    End Sub

    Private Sub InserisciClipart()
        If RTB.Text = "" Then
            AggiungiClipArt()
            Exit Sub
        End If
        If RTB.SelectedText = "" Then
            fnSinonimi()
        End If
        If RTB.SelectedText <> "" Then
            If AutoImmagine(LCase(RTB.SelectedText), RTB.SelectionStart) = False Then
                AggiungiClipArt()
            End If
        Else
            AggiungiClipArt()
        End If
    End Sub

    Function AutoImmagine(ByVal parola As String, ByVal start As Integer) As Boolean

        parola = parola.Trim(Chr(32), Chr(10), Chr(13), Chr(34), CChar("*"), CChar("\"), CChar("/"), CChar(":"), CChar("?"), CChar(";"))
        If parola = "" Then Exit Function
        If PercorsoClipart = "" Then Exit Function
        Dim perc As String = PercorsoClipart & "\" ' "immagini\"
        Dim fil As String = ""

        Try
            fil = Dir(perc & parola & ".*")
        Catch ex As Exception
        End Try

        If fil = "" Then
            Try
                fil = Dir(perc & TrovaParolaBase(parola) & ".*")
            Catch ex As Exception
            End Try
        End If
        If fil = "" Then
            Try
                Dim parol As String = TrovaParolaIrregolari(parola)
                fil = Dir(perc & parol & ".*")
            Catch ex As Exception
            End Try
        End If

        RTB.SelectionStart = start + Len(parola)
        RTB.SelectionLength = 0

        If fil <> "" Then
            Dim img As Image = Image.FromFile(perc & fil)
            Try
                Clipboard.SetImage(img)
                RidimensionaImmagineInClipboard(120)
                RTB.Paste()
            Catch er As Exception
            End Try
            Return True
        Else
            Return False
        End If
    End Function

    Public Function TrovaParolaBase(ByVal p As String) As String
        Dim comando As String = FormaComandoSinonimi()
        Dim ProcID As Integer = 0
        My.Computer.FileSystem.WriteAllText(CartellaTemp & "testo.txt", p, False, System.Text.Encoding.GetEncoding(28605))
        ProcID = Shell(comando, AppWinStyle.Hide, Wait:=True)

        Dim parola As String = "", pa As String = ""
        Dim lett As String
        Dim i As Integer = 0, k As Integer = 0, h As Integer = 0
        Dim inizio As Integer = 0, fine As Integer = 0

        Dim f As Integer = FreeFile()
        lett = CartellaTemp & "errori.txt"
        If IO.File.Exists(lett) Then
            Try
                FileOpen(f, lett, OpenMode.Input)
                parola = LineInput(f)
                If EOF(f) = False Then
                    pa = LineInput(f)
                    If pa <> "" Then parola = pa
                End If
            Catch ex As Exception
            End Try
            FileClose(f)
        End If
        If Len(parola) = 0 Then
            Return p
            Exit Function
        End If
        i = InStr(parola, " ")
        If i = 0 Then
            Return p
        Else
            Return Trim(Mid(parola, i + 1))
        End If

    End Function

    Dim procMM As Process

    Private Sub CreaMappa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mTraduci.Click
        Traduci()
    End Sub

    Private Sub CatturaImmagine_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CatturaImmagine.Click
        Cattura_Immagine()
    End Sub

    Sub Cattura_Immagine()
        Schermo2.Show()
        Me.Hide()

    End Sub

    Private Sub btnElencoPunt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElencoPunt.Click
        If RTB.SelectionBullet = False Then
            RTB.SelectionBullet = True
        Else
            RTB.SelectionBullet = False
        End If
    End Sub

    Private Sub btnMappe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMappe.Click
        'SelezionaPulsante(btnMappe, tbMappe)
        DisattivaLens()
        Dim a As String = ""
        Try
            a = frmMMaple.RTB.Text
        Catch ex As Exception
        End Try
        If a = "" Then
            TornaMMaple.Visible = False
        Else
            TornaMMaple.Visible = True
        End If
    End Sub

    Private Sub btnMappe_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMappe.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("Crea una mappa con maind meipol")
        Else
            RTB.Focus()
        End If
    End Sub

    Private Sub ToolStripButton1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(bot.ToolTipText)
        Else
            RTB.Focus()
        End If
    End Sub

    Public Sub AggiornaVoce()
        If blnVoce = False Then Exit Sub
        lblVelocita.Text = Velocita.ToString
        AssegnaLaVoce(intParlante)
    End Sub

    Private Sub Wikipedia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Wikipedia.Click
        AttivaWikipedia()
    End Sub

    'Dim WikiAttiva As Boolean = False

    Sub CercaInDizionario()
        If RTB.Text <> "" Then
            If RTB.SelectedText = "" Then
                fnSinonimi()
            End If
        End If


        Dim ParolaCercata As String = RTB.SelectedText 'MsgBox(t)

        If RTB.SelectedText <> "" Then
            RTB.SelectionStart = RTB.SelectionStart + RTB.SelectionLength
            RTB.SelectionLength = 0
        End If
        DaTradurre = "http://www.grandidizionari.it/Dizionario_Italiano/parola/C/" & ParolaCercata & ".aspx?query=" & ParolaCercata
        'DaTradurre = "https://dizionari.repubblica.it/Italiano/" & UCase(Chr(Asc(ParolaCercata))) & "/" & ParolaCercata & ".html"

        If ParolaCercata <> "" Then
            'btnWiki.Visible = True
            Try
                frmINT.Close()
            Catch ex As Exception

            End Try
            frmINT.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub AttivaWikipedia()
        If RTB.Text <> "" Then
            If RTB.SelectedText = "" Then
                fnSinonimi()
            End If
        End If


        Dim t As String = RTB.SelectedText 'MsgBox(t)

        If RTB.SelectedText <> "" Then
            RTB.SelectionStart = RTB.SelectionStart + RTB.SelectionLength
            RTB.SelectionLength = 0
        End If

        t = Trim(t.Replace(" ", "_"))

        '        RTB.Text += vbCrLf 'MALEDETTO!!!!!

        'Exit Sub

        'RTB.SelectionStart = RTB.Text.Length
        'RTB.SelectionLength = 0

        Dim l As String = ""
        Select Case Lingua(intParlante)
            Case Italiano : l = "http://it"
            Case Inglese : l = "http://en"
            Case IngleseUS : l = "http://en"
            Case Francese : l = "http://fr"
            Case Spagnolo : l = "http://es"
            Case Tedesco : l = "http://de"
            Case Else : l = "http://it"
        End Select

        If t <> "" Then
            DaTradurre = l & ".wikipedia.org/wiki/" & t
        Else
            DaTradurre = l & ".wikipedia.org"
        End If

        If DaTradurre <> "" Then
            btnWiki.Visible = True
            Try
                frmINT.Close()
            Catch ex As Exception

            End Try

            Dim proc As Process
            If ChromeInstallato() <> "" Then
                proc = Process.Start(ChromeInstallato, DaTradurre)
            Else
                proc = Process.Start(DaTradurre)
            End If
            frmLettore.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnAcca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcca.Click
        Clipboard.SetText(RTB.Text)
        Me.Cursor = Cursors.WaitCursor
        MsgBox(RTB.Font.Size)
        Shell("ai-hai.exe", AppWinStyle.NormalFocus, True)
        If Clipboard.ContainsText Then RTB.Text = Clipboard.GetText
        Me.Cursor = Cursors.Arrow
        MsgBox(RTB.Font.Size)

    End Sub

    Private Sub btnAcca_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAcca.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("controlla le acca")
        Else
            RTB.Focus()
        End If
    End Sub

    Sub ImmGoogle()
        If RTB.SelectedText = "" Then
            If RTB.Text <> "" Then
                fnSinonimi()
            End If
        End If

        Dim p As String = RTB.SelectedText

        If RTB.SelectedText <> "" Then
            RTB.SelectionStart = RTB.SelectionStart + RTB.SelectionLength
            RTB.SelectionLength = 0
        End If
        'Dim pr As Process = Process.Start("https://www.google.it/search?safe=active&hl=it&site=imghp&tbm=isch&source=hp&biw=1440&bih=762&q=" + p)
        DaTradurre = "https://www.google.it/search?safe=active&hl=it&site=imghp&tbm=isch&source=hp&biw=1440&bih=762&q=" & p
        Try
            frmINT.Close()
        Catch ex As Exception

        End Try
        frmINT.Show()
        'Me.Hide()

    End Sub

    Private Sub btnMicrofono_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMicrofono.Click

        If win1011() = True Then
            WinH()
            RTB.Focus()
        Else
            Dim proc As Process
            If ChromeInstallato() <> "" Then
                proc = Process.Start(ChromeInstallato, "https://speechnotes.co/")
            End If
            frmLettore.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub NuovaImmagine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuovaImmagine.Click
        ImmGoogle()
    End Sub

    Private Sub TornaImmagine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TornaImmagine.Click
        frmINT.Show()
        Me.Hide()

    End Sub

    Private Sub btnCmap_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCmap.Click
        DisattivaLens()
        Dim a As String = ""
        Try
            a = frmCmap.RTB.Text
        Catch ex As Exception
        End Try
        If a = "" Then
            TornaCMap.Visible = False
        Else
            TornaCMap.Visible = True
        End If
        'frmCmap.RTB.Rtf = RTB.Rtf
        'frmCmap.Show()
        'Me.Hide()
    End Sub

    Private Sub NuovaMappaCMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuovaMappaCMap.Click
        frmCmap.VuotaGriglia()
        frmCmap.ListBox1.Items.Clear()
        'frmCmap.RTB.Font = FontPredefinito
        'frmCmap.RTB.Text = RTB.Text
        frmCmap.RTB.Rtf = RTB.Rtf
        frmCmap.RTB.ZoomFactor = RTB.ZoomFactor
        frmCmap.RTB.SelectAll()
        frmCmap.RTB.SelectionBackColor = ColoreSfondo
        frmCmap.RTB.SelectionStart = 1
        frmCmap.RTB.SelectionLength = 0

        frmCmap.Show()
        Me.Hide()
    End Sub

    Private Sub TornaCMap_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TornaCMap.Click
        'frmCmap.RTB.Rtf = RTB.Rtf
        frmCmap.Show()
        frmCmap.RTB.ZoomFactor = RTB.ZoomFactor
        Me.Hide()
    End Sub

    Private Sub NuovaMappaMMaple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NuovaMappaMMaple.Click
        'frmMMaple.RTB.Font = FontPredefinito
        frmMMaple.Text = ""
        frmMMaple.BackColor = ColoreSfondo
        'frmMMaple.RTB.Text = RTB.Text
        frmMMaple.RTB.Rtf = RTB.Rtf
        frmMMaple.RTB.SelectAll()
        frmMMaple.RTB.SelectionBackColor = ColoreSfondo
        frmMMaple.RTB.SelectionStart = 1
        frmMMaple.RTB.SelectionLength = 0
        frmMMaple.Show()
        Me.Hide()
    End Sub

    Private Sub TornaMMaple_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TornaMMaple.Click
        frmMMaple.Show()
        Me.Hide()
    End Sub

    Private Sub AggTesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AggTesto.Click
        blnAggTesto = AggTesto.Checked

    End Sub

    Private Sub Ck1spazio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ck1spazio.Click
        UnoSpazio()
    End Sub

    Private Sub Ck2spazi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ck2spazi.Click
        DoppiSpazi()
    End Sub

    Sub UnoSpazio()
        Dim t As String = RTB.Text
        t = t.Replace(" .", ".")
        t = t.Replace(" ?", "?")
        t = t.Replace(" !", "!")
        t = t.Replace(" ,", ",")
        t = t.Replace(" ;", ";")
        t = t.Replace(" :", ":")
        t = t.Replace(" )", ")")
        t = t.Replace(".", ". ")
        t = t.Replace("?", "? ")
        t = t.Replace("!", "! ")
        t = t.Replace(",", ", ")
        t = t.Replace(";", "; ")
        t = t.Replace(":", ": ")

        t = t.Replace("   ", " ")
        t = t.Replace("  ", " ")
        RTB.Text = t
    End Sub

    Sub DoppiSpazi()
        UnoSpazio()
        Dim t As String = RTB.Text
        t = t.Replace(" ", "  ")
        RTB.Text = t
    End Sub

    Private Sub btnCalcola_Click(sender As Object, e As EventArgs) Handles btnCalcola.Click
        If lbLingua.Text <> "ITALIANO" Then
            MsgBox("Attenzione! La calcolatrice funziona solo con la lingua italiana")
            btnCalcola.DropDown.Close()
        End If
    End Sub

    Private Sub frmLeggiConMe_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        'Me.Hide()
        'While CeZoom() = False
        'frmZoom.ShowDialog()
        'End While
        'Me.Show()
        If Percorso.Contains(".zip\") Or Percorso.EndsWith(".zip") Then
            Me.Hide()
            MsgBox("ATTENZIONE!!!" & vbCrLf & "Prima di utilizzare il programma devi estrarlo dalla cartella compressa", MsgBoxStyle.Critical)
            End
        End If

        If MessaggioErrore <> "" Then
            Me.Hide()
            MsgBox(MessaggioErrore, MsgBoxStyle.Critical)
            Me.Show()
        End If
        CaricaVerbiIrregolari()
        If Dir(FileTemporaneo) <> "" Then
            Dim res As Integer
            res = MsgBox("ATTENZIONE! C'è un documento che può essere recuperato." & vbCrLf & "Vuoi recuperarlo?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo)
            If res = vbYes Then
                RTB.LoadFile(FileTemporaneo, RichTextBoxStreamType.RichText)
                'ApriFinestra()
                'Me.Show()
            Else
                Try
                    Kill(FileTemporaneo)
                Catch ex As Exception
                End Try
                Me.Hide()
                frmLettore.Show()
            End If
        Else
            Me.Hide()
            frmLettore.Show()
        End If
        If NomeVocePrincipale = "" Then
            MsgBox("Installare la voce italiana di Microsoft Speech Platform 11.0", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub txtTrova_TextChanged(sender As Object, e As EventArgs) Handles txtTrova.TextChanged
        blnTrovaNuovo = True
    End Sub

    Private Sub btnSistemaTesto_Click(sender As Object, e As EventArgs) Handles btnSistemaTesto.Click
        RTB.Text = filtrata2(RTB.Text)
    End Sub

    Private Sub ToolStripButton1_Click_1(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        EvidenziaCancella()
    End Sub

    Sub EvidenziaCancella()
        RTB.SelectionBackColor = ColoreSfondo
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs) Handles ToolStripButton3.Click
        EvidenziaCancella()
    End Sub

    Private Sub btnWiki_Click(sender As Object, e As EventArgs) Handles btnWiki.Click
        DisattivaLens()
        AttivaWikipedia()
    End Sub

    Private Sub ToolStripButton5_Click(sender As Object, e As EventArgs) Handles ToolStripButton5.Click
        CercaInDizionario()
    End Sub

    Private Sub btnImposta_Click(sender As Object, e As EventArgs) Handles btnImposta.Click
        MettiFont(RTB)
        'RTB.SelectAll()
        'Dim ilFont As New Font(FontPredefinito.Name, FontPredefinito.Size)
        'RTB.SelectionFont = ilFont
        'RTB.SelectionLength = 0
    End Sub

    Dim OldClip As String = ""

    Private Sub tmrClip_Tick(sender As Object, e As EventArgs) Handles tmrClip.Tick
        Dim c As String = ""

        If ChromeAttivo() = False Then
            DisattivaLens()
            Exit Sub
        End If

        If InternetConnesso() = False Then
            DisattivaLens()
            Exit Sub
        End If

        If Clipboard.ContainsText Then
            c = Clipboard.GetText
            If c <> "" And c <> OldClip Then
                OldClip = c
                RTB.AppendText(c & vbCrLf)
            End If
        End If
    End Sub

    Private Sub btnLens_Click(sender As Object, e As EventArgs) Handles btnLens.Click
        If tmrClip.Enabled = False Then
            AttivaLens()
        Else
            DisattivaLens()
        End If
    End Sub

    Sub AttivaLens()
        If ChromeAttivo() AndAlso InternetConnesso() = True Then
            btnLens.BackColor = Color.Green
            Clipboard.Clear()
            tmrClip.Enabled = True
            blnLens = True
            frmMessaggioLens.ShowDialog()
            'MsgBox("Lens attivato", MsgBoxStyle.Exclamation)
        Else
            DisattivaLens()
            If ChromeAttivo() = False Then
                MsgBox("Chrome deve essere in esecuzione", MsgBoxStyle.Critical)
            End If
        End If
    End Sub

    Sub DisattivaLens()
        If tmrClip.Enabled = False Then Exit Sub
        btnLens.BackColor = Color.Red
        tmrClip.Enabled = False
        blnLens = False
        frmMessaggioLens.ShowDialog()

        'MsgBox("Lens disattivato", MsgBoxStyle.Exclamation)
    End Sub

    Private Sub TraduttoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TraduttoreToolStripMenuItem.Click
        DisattivaLens()
        If InternetConnesso() = True Then 'ConnessioneInternet
            AvviaTraduttore()
        End If
    End Sub

    Private Sub DizionarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DizionarioToolStripMenuItem.Click
        DisattivaLens()
        AvviaDizionario()
    End Sub

    Private Sub ckTradLat_Click(sender As Object, e As EventArgs) Handles ckTradLat.Click
        If ckTradLat.Checked = True Then ckTrad.Checked = False
    End Sub

    Private Sub ckTrad_Click(sender As Object, e As EventArgs) Handles ckTrad.Click
        If ckTrad.Checked = True Then ckTradLat.Checked = False
    End Sub

    Private Sub ckScorciatoie_Click(sender As Object, e As EventArgs) Handles ckScorciatoie.Click
        If ckScorciatoie.Checked = True Then
            ScorciatoieAttive = True
            RegistraTasti()
        Else
            ScorciatoieAttive = False
            DeRegistraTasti()
        End If
    End Sub

    Private Sub btnMicrofono_MouseUp(sender As Object, e As MouseEventArgs) Handles btnMicrofono.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(btnMicrofono.ToolTipText.ToString)
        End If
    End Sub

    Private Sub btnImposta_MouseUp(sender As Object, e As MouseEventArgs) Handles btnImposta.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(btnImposta.ToolTipText.ToString)
        End If
    End Sub

    Private Sub btnLens_MouseUp(sender As Object, e As MouseEventArgs) Handles btnLens.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(btnLens.ToolTipText.ToString)
        End If
    End Sub

    Private Sub btnImmGoogle_MouseUp(sender As Object, e As MouseEventArgs) Handles btnImmGoogle.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(btnImmGoogle.ToolTipText.ToString)
        End If
    End Sub

    Private Sub btnWiki_MouseUp(sender As Object, e As MouseEventArgs) Handles btnWiki.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As ToolStripItem = sender
            LeggiMessaggi(btnWiki.ToolTipText.ToString)
        End If
    End Sub

    Private Sub tbFile_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbFile.ItemClicked

    End Sub

    Private Sub AutoVerbMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles AutoVerbMenu.Opening

    End Sub
End Class
