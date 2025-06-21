
Imports System.Collections.ObjectModel

Public Class frmTRAD
    Private Voce1 As Integer, Voce2 As Integer, VoceAttiva As Integer, VoceTraduzione As String = "", VoceOrigine As String = "Automatico"
    Private blnStoLeggendo As Boolean = False
    Private blnStoLeggendoTrad As Boolean = False
    Private blnInPausa As Boolean = False
    Private blnInPausaTrad As Boolean = False
    Private NumParte As Integer = 0
    Private blnPiuParti As Boolean = False
    Private PosAttualeT As Integer = 0

    Private Processo() As String
    Dim BorderWidth As Integer = (Me.Width - Me.ClientSize.Width) / 2
    Dim TitlebarHeight As Integer = Me.Height - Me.ClientSize.Height - 2 * BorderWidth
    Dim blnChiuso As Boolean = False
    Private Const WM_SYSCOMMAND As Integer = 274
    Private Const SC_MAXIMIZE As Integer = 61488
    Declare Auto Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Dim tb As RichTextBox

    Private Sub frmTRAD_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        frmLeggiConMe.Show()
    End Sub

    Private Sub frmTRAD_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        FermaLettura()
        frmLeggiConMe.AggiornaVoce()
        'procW.CloseMainWindow()
    End Sub

    Private Sub frmTRAD_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If NumVoci > 0 Then
            CreaMenuVoci(MenuVoci1)
            For i As Integer = 0 To MenuVoci1.Items.Count - 1
                If MenuVoci1.Items(i).ToString = NomeCorto(intParlante) Then
                    MenuVoci1.Items(i).Select()
                    cmdVoce1.Image = ScegliBandiera(i)
                    Sceglivoce1(NomeCorto(intParlante))
                End If
            Next
            CreaMenuVoci(MenuVoci2)
            For i As Integer = 0 To MenuVoci2.Items.Count - 1
                If MenuVoci2.Items(i).ToString = NomeCorto(intParlante) Then
                    MenuVoci2.Items(i).Select()
                    cmdVoce2.Image = ScegliBandiera(i)
                    Sceglivoce2(NomeCorto(intParlante))
                End If
            Next
        Else
            MenuVoci1.Items.Add("Nessuna Voce")
            MenuVoci2.Items.Add("Nessuna Voce")
        End If


        Me.Size = frmLeggiConMe.Size
        Me.Location = frmLeggiConMe.Location

        Ridimensiona()

        If CeDizionario() = False Then
            btnDiz.Visible = False
        End If

        If blnInternet = False Then
            btnFrancese.Visible = False
            btnInglese.Visible = False
            btnTedesco.Visible = False
            btnSpagnolo.Visible = False
            btnItaliano.Visible = False
            Label2.Visible = False
        End If
        TB1.Font = FontPredefinito
        TB2.Font = FontPredefinito

        TB1.Text = Clipboard.GetText
        TB2.Text = ""
        RB2.Checked = True
        TB1.BackColor = ColoreSfondo
        TB2.BackColor = ColoreSfondo

        rbAuto.Checked = True
        VoceOrigine = "Automatico"
    End Sub

    Private Sub frmTRAD_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        TB1.Height = pnPDF.Height / 2 - 10
        TB2.Top = TB1.Top + TB1.Height + 10
        TB2.Height = TB1.Height
        pnVoci.Top = TB2.Top ' - 110
    End Sub

    Private Sub cmdLeggi1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeggi1.Click
        If blnStoLeggendo = True Then
            FermaLettura()
        End If
        Leggi(TB1, Voce1)
    End Sub


    Private Sub Leggi(ByVal RTB As RichTextBox, ByVal voce As Integer)

        Dim t As String = ""

        zeppa = RTB.SelectionStart
        inizio = zeppa
        lungh = RTB.SelectionLength
        If zeppa >= RTB.TextLength Then zeppa = 0
        If RTB.SelectionLength > 0 Then
            t = RTB.SelectedText
        Else
            t = Mid(RTB.Text, zeppa + 1)
        End If

        ConEco(RTB, t, voce)

    End Sub

    Sub Aprifile(ByVal nf As String)
        On Error Resume Next
        TB1.Text = Clipboard.GetText
    End Sub

    Private Sub EvidenziaParola(ByVal Pos As Integer, ByVal Length As Integer)
        If VoceAttiva = 1 Then
            Try
                TB1.SelectionStart = Pos + zeppa
                TB1.SelectionLength = Length
                TB1.ScrollToCaret()
            Catch e As Exception
                MsgBox("Non riesco ad evidenziare le parole.")
            End Try
        Else
            Try
                TB2.SelectionStart = Pos + zeppa
                TB2.SelectionLength = Length
                TB2.ScrollToCaret()
            Catch e As Exception
                MsgBox("Non riesco ad evidenziare le parole.")
            End Try

        End If

    End Sub

    Sub FermaLettura()
        FermaVoce()
        TB1.SelectionLength = 0
    End Sub

    Private Sub cmdStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        FermaLettura()
    End Sub

    Private Sub cmdLeggi2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeggi2.Click
        If VoceInPausa() Then
            Riprendi()
            FermaVoce()
        End If
        If VoceStaParlando() Then
            FermaVoce()
        End If
        Leggi(TB2, Voce2)
    End Sub

    Private Sub btnTorna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTorna.Click
        TornaHome()
    End Sub

    Sub TornaHome()
        FermaLettura()
        frmLeggiConMe.lblVelocita.Text = Velocita.ToString
        frmLeggiConMe.Show()
        Schermo.Hide()
        frmLeggiConMe.RTB.Focus()
        'Me.Hide()
        Me.Close()
    End Sub

    Private Sub btnIncolla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncolla.Click
        If RB1.Checked = True Then
            If TB1.Text = "" Then Exit Sub
            If TB1.SelectionLength > 0 Then
                Clipboard.SetText(vbCrLf & TB1.SelectedText)
            Else
                Clipboard.SetText(vbCrLf & TB1.Text)
            End If
        Else
            If TB2.Text = "" Then Exit Sub
            If TB2.SelectionLength > 0 Then
                Clipboard.SetText(vbCrLf & TB2.SelectedText)
            Else
                Clipboard.SetText(vbCrLf & TB2.Text)
            End If
        End If
        frmLeggiConMe.RTB.Paste()
        frmLeggiConMe.RTB.AppendText(System.Environment.NewLine)
        My.Computer.Audio.Play(My.Resources.splash, AudioPlayMode.WaitToComplete)
        'TornaHome()
    End Sub

    Private Sub CopiaTesto(ByVal TB As TextBox)
        ' procedura non utilizzata
        If TB.Text = "" Then Exit Sub
        If TB.SelectionLength > 0 Then
            Clipboard.SetText(TB.SelectedText)
        Else
            Clipboard.SetText(TB.Text)
        End If

    End Sub

    Private Sub AcquisisciImmagine(ByVal i As Point, ByVal m As Size)
        ' procedura non utilizzata
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

    Private Sub Ridimensiona()

        Dim nsize As Size = Me.Size
        nsize.Height = My.Computer.Screen.WorkingArea.Height + BorderWidth * 2 'TitlebarHeight
        'Me.MaximumSize = nsize
        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub btnIncolla_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnIncolla.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("incolla  il testo nel documento principale.")
        End If
    End Sub

    Private Sub btnTorna_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTorna.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("torna alla schermata principale.")
        End If
    End Sub

    Private Sub cmdLeggi_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdLeggi1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("incolla il testo selezionato nel riquadro qui sotto e lo legge.")
        End If
    End Sub

    Private Sub cmdLeggiTesto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdLeggi2.MouseUp
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
        Pausa()
    End Sub

    Private Sub cmdPausa_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdPausa.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("mette in pausa la lettura.")
        End If
    End Sub

    Private Sub cmdImposta_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("apri documento.")
        End If
    End Sub
    '
    Dim VoceCon1 As String = "auto", VoceCon2 As String = ""

    Sub Traduci()

        AggiornaVoce2()

        If TB1.Text <> "" Then
            If TB1.SelectionLength > 0 Then
                DaTradurre = TB1.SelectedText
            Else
                DaTradurre = TB1.Text
            End If
        End If

        If DaTradurre = "" Then Exit Sub

        Clipboard.Clear()

        If DaTradurre <> "" Then
            Me.TopMost = True
            Dim t As GoogleTranslator.Translator = New GoogleTranslator.Translator
            Dim st2 As String = t.Translate(DaTradurre, VoceOrigine, VoceTraduzione)
            TB2.Text = st2
            Me.TopMost = False

        End If
    End Sub

    Private Sub btnInglese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInglese.Click
        VoceTraduzione = "English"
        VoceCon2 = "en"
        Traduci()
    End Sub

    Private Sub btnFrancese_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrancese.Click
        VoceTraduzione = "French"
        VoceCon2 = "fr"
        Traduci()
    End Sub

    Private Sub btnSpagnolo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpagnolo.Click
        VoceTraduzione = "Spanish"
        VoceCon2 = "es"
        Traduci()
    End Sub

    Private Sub btnTedesco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTedesco.Click
        VoceTraduzione = "German"
        VoceCon2 = "de"
        Traduci()
    End Sub

    Private Sub btnItaliano_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnItaliano.Click
        VoceTraduzione = "Italian"
        VoceCon2 = "it"
        Traduci()
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop2.Click
        FermaVoce()
    End Sub

    Private Sub cmdPausa2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPausa2.Click
        If VoceStaParlando() Then
            Pausa()
            TB2.SelectionLength = 0
            TB2.Refresh()
            TB2.Focus()
        Else
            Riprendi()
        End If

    End Sub

    Private Sub btnAppunti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAppunti.Click
        frmAPP.Show()
        Me.Hide()
    End Sub

    Private Sub btnAppunti_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAppunti.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("gestione appunti")
        End If
    End Sub

    Private Sub TB1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB1.DoubleClick
        If TB1.SelectionType = 5 Then
            Dim t As String = Trim(TB1.SelectedText)
            TB1.SelectionLength = Len(t)
            If Len(t) > 0 Then
                Try
                    Clipboard.SetText(t)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub TB1_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB1.LostFocus
        If spaziatura = 2 Then
            Dim t As String = TB1.Text
            TB1.Text = MettiDoppiSpazi(t)
        End If
    End Sub

    Private Sub TB1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB1.MouseDown
        If blnStoLeggendo = True Then FermaLettura()
    End Sub

    Private Sub TB2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB2.DoubleClick
        If TB2.SelectionType = 5 Then
            Dim t As String = Trim(TB2.SelectedText)
            TB2.SelectionLength = Len(t)
            If Len(t) > 0 Then
                Try
                    Clipboard.SetText(t)
                Catch ex As Exception
                End Try
            End If
        End If

    End Sub

    Private Sub TB2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB2.MouseDown
        If blnStoLeggendo = True Then FermaLettura()
    End Sub

    Private Sub btnDiz_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiz.Click
        ChDir(PercorsoDizionario)
        Dim proc As Process = Process.Start("dizio.exe")
        ChDir(Percorso)
    End Sub

    Private Sub btnDiz_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnDiz.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("dizionario.")
        End If
    End Sub

    Private Sub AutoVerbMenu_Opening(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AutoVerbMenu.Opening
        tb = AutoVerbMenu.SourceControl
    End Sub

    Private Sub Annulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annulla.Click
        If tb.CanUndo Then tb.Undo()
    End Sub

    Private Sub Taglia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Taglia.Click
        If tb.SelectedText <> "" Then tb.Cut()
    End Sub

    Private Sub Ripristina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ripristina.Click
        If tb.CanRedo Then tb.Redo()
    End Sub

    Private Sub Copia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copia.Click
        tb.Copy()
    End Sub

    Private Sub Incolla_Testo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Incolla_Testo.Click
        Try
            If Clipboard.ContainsText Then
                tb.Text = Clipboard.GetText
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub trVelocita_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trVelocita.Scroll
        Velocita = trVelocita.Value
        RegolaVelocita()
    End Sub

    Private Sub Voice_SpeakStarted()
        blnStoLeggendo = True
        cmdLeggi1.Enabled = False
        cmdLeggi2.Enabled = False
    End Sub

    Private Sub rbAuto_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbAuto.Click
        VoceOrigine = "Automatico"
        VoceCon1 = "auto"
        AggiornaVoce1()
    End Sub

    Private Sub rbItaliano_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbItaliano.Click
        VoceOrigine = "Italian"
        VoceCon1 = "it"
        AggiornaVoce1()
    End Sub

    Private Sub rbInglese_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbInglese.Click
        VoceOrigine = "English"
        VoceCon1 = "en"
        AggiornaVoce1()
    End Sub

    Private Sub rbFrancese_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbFrancese.Click
        VoceOrigine = "French"
        VoceCon1 = "fr"
        AggiornaVoce1()
    End Sub

    Private Sub rbSpagnolo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSpagnolo.Click
        VoceOrigine = "Spanish"
        VoceCon1 = "es"
        AggiornaVoce1()
    End Sub

    Private Sub rbTedesco_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbTedesco.Click
        VoceOrigine = "German"
        VoceCon1 = "de"
        AggiornaVoce1()
    End Sub

    Private Sub rbLatino_Click(sender As Object, e As EventArgs) Handles rbLatino.Click
        VoceOrigine = "Latin"
        VoceCon1 = "la"
        AggiornaVoce1()
    End Sub

    Sub AggiornaVoce1()
        For v As Integer = 0 To NumVoci
            If InStr(Lingua(v), VoceCon1) <> 0 Then
                'cbVoci1.SelectedIndex = v
                Exit For
            End If
        Next
        If VoceOrigine = "Automatico" Or VoceOrigine = "Latin" Then
            For v As Integer = 0 To NumVoci
                If Lingua(v) = Italiano Then
                    'cbVoci1.SelectedIndex = v
                    Exit For
                End If
            Next
        End If

    End Sub

    Sub AggiornaVoce2()

        For v As Integer = 0 To NumVoci
            If InStr(Lingua(v), VoceCon2) <> 0 Then
                'cbVoci2.SelectedIndex = v
                Exit For
            End If
        Next

    End Sub

    Private Sub cmdVoce1_Click(sender As Object, e As EventArgs) Handles cmdVoce1.Click
        MenuVoci1.Show()
        MenuVoci1.Left = cmdVoce1.Left + Me.Left
        MenuVoci1.Top = Me.Top + cmdVoce1.Top + cmdVoce1.Height + AltezzaCaption()
        Me.Refresh()
    End Sub

    Private Sub MenuVoci1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuVoci1.ItemClicked
        Dim item As String = e.ClickedItem.ToString
        If item = "ANNULLA" Then Exit Sub
        Sceglivoce1(item)
    End Sub

    Public Sub Sceglivoce1(item As String)
        Voce1 = Sceltavoce(item, MenuVoci1, cmdVoce1)
        lblVoce1.Text = AssegnaVoce(Voce1)
        cmdVoce1.Image = ScegliBandiera(Voce1)
    End Sub

    Private Sub cmdVoce2_Click(sender As Object, e As EventArgs) Handles cmdVoce2.Click
        MenuVoci2.Show()
        MenuVoci2.Left = cmdVoce2.Left + Me.Left
        MenuVoci2.Top = cmdVoce2.Top + cmdVoce2.Height + AltezzaCaption() + Me.Top
        Me.Refresh()
    End Sub

    Private Sub MenuVoci2_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuVoci2.ItemClicked
        Dim item As String = e.ClickedItem.ToString
        If item = "ANNULLA" Then Exit Sub
        Sceglivoce2(item)
    End Sub

    Public Sub Sceglivoce2(item As String)
        Voce2 = Sceltavoce(item, MenuVoci2, cmdVoce2)
        lblVoce2.Text = AssegnaVoce(Voce2)
        Try
            'ScegliLingua()
            Select Case Lingua(Voce2)
                Case Italiano : lblVoce2.Text = "ITALIANO"
                Case Inglese : lblVoce2.Text = "INGLESE"
                Case IngleseUS : lblVoce2.Text = "INGLESE"
                Case Francese : lblVoce2.Text = "FRANCESE"
                Case Spagnolo : lblVoce2.Text = "SPAGNOLO"
                Case Tedesco : lblVoce2.Text = "TEDESCO"
                Case Else
                    If lalingua <> "" Then
                        lblVoce2.Text = lalingua
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        cmdVoce2.Image = ScegliBandiera(Voce2)

    End Sub

End Class