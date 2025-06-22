Imports System.Collections.ObjectModel

Public Class frmAPP

    Private blnStoLeggendo As Boolean = False
    Private blnInPausa As Boolean = False
    Private NumParte As Integer = 0
    Private blnPiuParti As Boolean = False

    Dim BorderWidth As Integer = (Me.Width - Me.ClientSize.Width) / 2
    Dim TitlebarHeight As Integer = Me.Height - Me.ClientSize.Height - 2 * BorderWidth
    Dim blnChiuso As Boolean = False
    Private Const WM_SYSCOMMAND As Integer = 274
    Private Const SC_MAXIMIZE As Integer = 61488
    Declare Auto Function SetParent Lib "user32.dll" (ByVal hWndChild As IntPtr, ByVal hWndNewParent As IntPtr) As Integer
    Declare Auto Function SendMessage Lib "user32.dll" (ByVal hWnd As IntPtr, ByVal Msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Integer

    Private Sub frmAPP_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FermaVoce()
        frmLeggiConMe.AggiornaVoce()
        frmLeggiConMe.Show()
    End Sub

    Private Sub frmAPP_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
    End Sub

    Private Sub frmAPP_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If NumVoci > 0 Then
            CreaMenuVoci(MenuVoci)
            MenuVoci.Items(intParlante).Select()
            cmdVoce.Image = ScegliBandiera(intParlante)
            lbLingua.Text = AssegnaVoce(intParlante)

        Else
            MenuVoci.Items.Add("Nessuna Voce")
        End If

        If ConnessioneInternet() = False Then
            btnTRAD.Visible = False
            btnTorna.Top += 20
        End If
        Ridimensiona()
        lstAppunti.Font = TB1.Font
        ImpostaCarattere(TB1)
        If blnEffettoLavagna = True Then
            lstAppunti.BackColor = Color.Black
            lstAppunti.ForeColor = ColoreSfondo 'Color.White
            TB1.ForeColor = ColoreSfondo
            TB1.BackColor = Color.Black
        End If
        AggiornaElenco()
        TB1.Font = FontPredefinito
        trVelocita.Value = Velocita
    End Sub

    Sub AggiornaElenco()
        Dim k As Integer, i As Integer
        Dim t As String = ""
        Try
            lstAppunti.Items.Clear()
            For k = 1 To NAppunti
                t = Mid(Appunti(k), 1, 24)
                i = InStrRev(t, " ")
                If i <> 0 Then t = Mid(t, 1, i - 1)
                lstAppunti.Items.Add(t)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmAPP_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.WindowState = FormWindowState.Minimized Then Exit Sub
        Me.WindowState = FormWindowState.Maximized
        pnPDF.Width = Me.Width - 300
        TB1.Width = pnPDF.Width - 10
        TB1.Height = pnPDF.Height - 10
    End Sub

    Sub Leggi_1()

        Dim t As String = ""

        inizio = TB1.SelectionStart
        lungh = TB1.SelectionLength
        zeppa = inizio

        If inizio >= TB1.TextLength Then inizio = 0
        If TB1.SelectionLength > 0 Then
            t = TB1.SelectedText
        Else
            t = Mid(TB1.Text, inizio + 1)
        End If

        ConEco(TB1, t)

    End Sub

    Sub Aprifile(ByVal nf As String)
        On Error Resume Next
        TB1.Text = Clipboard.GetText
    End Sub

    Private Sub btnTorna_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTorna.Click
        FermaVoce()
        TornaHome()
    End Sub

    Sub TornaHome()
        frmLeggiConMe.lblVelocita.Text = Velocita.ToString
        Me.Close()
        frmLeggiConMe.RTB.Focus()
    End Sub

    Private Sub btnIncolla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncolla.Click
        If TB1.Text = "" Then Exit Sub
        If TB1.SelectionLength > 0 Then
            frmLeggiConMe.RTB.SelectedText = vbCrLf & TB1.SelectedText
        Else
            frmLeggiConMe.RTB.SelectedText = vbCrLf & TB1.Text
        End If
        My.Computer.Audio.Play(My.Resources.splash, AudioPlayMode.WaitToComplete)
        frmLeggiConMe.RTB.AppendText(System.Environment.NewLine)
        'TornaHome()
    End Sub

    Private Sub Ridimensiona()

        Dim nsize As Size = Me.Size
        nsize.Height = My.Computer.Screen.WorkingArea.Height + BorderWidth * 2 'TitlebarHeight
        Me.MaximumSize = nsize
        Me.WindowState = FormWindowState.Normal

    End Sub

    Private Sub btnIncolla_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnIncolla.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("incolla nel documento il testo.")
        End If
    End Sub

    Private Sub btnTorna_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTorna.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("torna alla schermata principale.")
        End If
    End Sub

    Private Sub cmdImposta_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("apri documento.")
        End If
    End Sub

    Private Declare Function GetWindowTextLength Lib "user32" Alias "GetWindowTextLengthA" (ByVal hwnd As IntPtr) As Integer
    Private Declare Function GetWindowText Lib "user32" Alias "GetWindowTextA" (ByVal hwnd As IntPtr, ByVal lpString As String, ByVal cch As Integer) As Integer


    Private Sub lstAppunti_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lstAppunti.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi(lstAppunti.SelectedItem.ToString)
        End If
    End Sub

    Private Sub lstAppunti_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstAppunti.SelectedIndexChanged
        TB1.Text = Appunti(lstAppunti.SelectedIndex + 1)
        ImpostaInterlinea(TB1)
        Dim t As String = TB1.Text
        If spaziatura = 2 Then
            TB1.Text = MettiDoppiSpazi(t)
            TB1.Refresh()
        End If

    End Sub

    Private Sub cmdLeggi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLeggi.Click
        If blnStoLeggendo = True Then
            FermaVoce()
        End If
        blnStoLeggendo = True
        Leggi_1()
    End Sub

    Private Sub cmdStop_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStop.Click
        FermaVoce()
        blnStoLeggendo = True
    End Sub

    Private Sub cmdLeggi_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdLeggi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("legge il testo.")
        End If
    End Sub

    Private Sub cmdStop_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdStop.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("ferma la lettura.")
        End If
    End Sub

    Private Sub cmdPausa_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPausa.Click
        Pausa()
    End Sub

    Private Sub cmdPausa_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdPausa.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("mette in pausa la lettura.")
        End If
    End Sub

    Private Sub btnTRAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTRAD.Click
        If TB1.Text = "" Then Exit Sub
        If TB1.SelectionLength > 0 Then
            Clipboard.SetText(TB1.SelectedText)
        Else
            Clipboard.SetText(TB1.Text)
        End If
        'frmTRAD.Show()
        Me.Hide()
    End Sub

    Private Sub btnTRAD_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTRAD.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("va alla pagina traduzioni e incolla il testo.")
        End If
    End Sub

    Private Sub AutoVerbMenu_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoVerbMenu.Opened
        ' Determine if Undo should be enabled.
        If TB1.CanUndo = True Then
            Annulla.Enabled = True
        Else
            Annulla.Enabled = False
        End If
        ' Determine if Cut, Copy, and Paste should be enabled.
        If TB1.SelectedText <> "" Then
            Taglia.Enabled = True
            Copia.Enabled = True
            'Elimina.Enabled = True
        Else
            Taglia.Enabled = False
            Copia.Enabled = False
            'Elimina.Enabled = False
        End If
        ' Determine if Paste should be enabled
        If My.Computer.Clipboard.ContainsText = True Or My.Computer.Clipboard.ContainsImage = True Then
            Incolla_Testo.Enabled = True
        Else
            Incolla_Testo.Enabled = False
        End If
    End Sub

    Private Sub Incolla_Testo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Incolla_Testo.Click
        If My.Computer.Clipboard.ContainsText Then
            TB1.SelectedText = Clipboard.GetText
        End If

    End Sub

    Private Sub Copia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copia.Click
        If TB1.SelectedText <> "" Then
            TB1.Copy()
        End If

    End Sub

    Private Sub Taglia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Taglia.Click
        If TB1.SelectedText <> "" Then
            TB1.Cut()
        End If
    End Sub

    Private Sub Ripristina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ripristina.Click
        If TB1.CanRedo Then
            TB1.Redo()
        End If

    End Sub

    Private Sub Annulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annulla.Click
        If TB1.CanUndo Then
            TB1.Undo()
        End If

    End Sub

    Private Sub TB1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TB1.MouseDown
        If blnStoLeggendo = True Then FermaVoce()
    End Sub

    Private Sub TB1_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TB1.TextChanged
        If blnStoLeggendo = True Then FermaVoce()
    End Sub

    Private Sub trVelocita_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles trVelocita.Scroll
        Velocita = trVelocita.Value
        RegolaVelocita()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim i As Integer = lstAppunti.SelectedIndex + 1
        For k As Integer = i To NAppunti - 1
            Appunti(k) = Appunti(k + 1)
        Next
        NAppunti -= 1
        TB1.Text = ""
        AggiornaElenco()
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