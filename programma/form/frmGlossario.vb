Option Strict Off
Option Explicit On
Friend Class frmGlossario
    Inherits System.Windows.Forms.Form

    Dim gloss As String = ""

    Private Sub cmdEsci_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEsci.Click
        ParolaGlossario = ""
        Esci()
    End Sub

    Private Sub cmdCambia_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCambia.Click
        'Dim strText As String = ""

        If lstContiene.SelectedIndex = -1 Then
            Exit Sub
        End If
        Correggi()
        Esci()
    End Sub

    Private Sub Esci()
        blnEsci = True
        Me.Hide()
        'BringWindowToTop(frmLeggiConMe.Handle)
        'frmLeggiConMe.RTB.Focus()
    End Sub

    Private Sub Correggi()
        If blnEsci = True Then Exit Sub
        If lstContiene.Items.Count = 0 Then Exit Sub
        'On Error Resume Next
        ParolaSostitutiva = CStr(lstContiene.Items.Item(lstContiene.SelectedIndex))
        ParolaGlossario = ParolaSostitutiva
        DifferenzaLunghezza = Len(ParolaSostitutiva) - Len(txtDaCercare.Text)
    End Sub

    Private Sub cmdIgnora_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        Dim txtSostituisci As String
        DifferenzaLunghezza = 0
        ParolaSostitutiva = ""
        txtSostituisci = ""
        Esci()
    End Sub

    Private Sub frmSinonimi_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        blnEsci = False
        If rbContiene.Checked = False Then rbInizia.Checked = True
        If gloss = "" Then ApriGlossario()

    End Sub

    Dim itm As Integer = 0
    Dim p() As String

    Dim PercorsoGlossari As String = TrovaPercorsoGlossari()

    Function TrovaPercorsoGlossari() As String
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim cartella As String = Mid(Percorso, 1, i) & "Glossari"
        If IO.Directory.Exists(cartella) = False Then
            cartella = CartellaLeggiXme() & "\Glossari"
            If IO.Directory.Exists(cartella) = False Then
                cartella = CartellaLeggiXme() & "\Glossari"
                CreaCartella(cartella)
            End If
        End If
        Return cartella
    End Function

    Sub ApriGlossario()

        Dim Apri As New OpenFileDialog()
        Apri.Filter = "Glossario(*.gls)|*.gls"
        Apri.FilterIndex = 1
        If PercorsoGlossari = "" Then
            Apri.InitialDirectory = System.Windows.Forms.Application.StartupPath
        Else
            Apri.InitialDirectory = PercorsoGlossari
        End If
        Apri.RestoreDirectory = True
        Apri.FileName = "Glossario.gls"

        Dim parola As String = ""
        Dim f As Integer

        lstParole.Items.Clear()
        lstParole.Sorted = False

        itm = 0
        Dim nf As String
        If Apri.ShowDialog() = DialogResult.OK Then
            f = FreeFile()
            nf = Apri.FileName
            FileOpen(f, nf, OpenMode.Input)
            While Not EOF(f)
                Input(f, parola)
                If parola <> "" Then
                    itm = itm + 1
                    ReDim Preserve p(itm)
                    lstParole.Items.Add(parola)
                    p(itm) = parola
                End If
            End While
            FileClose(f)
            txtGlossario.Text = Mid(nf, InStrRev(nf, "\") + 1)
            gloss = txtGlossario.Text
        End If
        AggiornaContenuti()

    End Sub

    Sub AggiornaContenuti()
        If rbInizia.Checked = True Then
            RiempiInizia()
        Else
            RiempiContiene()
        End If
    End Sub

    Sub RiempiInizia()
        lstContiene.Items.Clear()
        For i As Integer = 0 To lstParole.Items.Count - 1
            If LCase(Mid(lstParole.Items(i).ToString, 1, Len(txtDaCercare.Text))) = LCase(txtDaCercare.Text) Then
                lstContiene.Items.Add(lstParole.Items(i).ToString)
            End If
        Next
    End Sub

    Sub RiempiContiene()
        lstContiene.Items.Clear()
        For i As Integer = 0 To lstParole.Items.Count - 1
            If InStr(LCase(lstParole.Items(i).ToString), LCase(txtDaCercare.Text)) <> 0 Then
                lstContiene.Items.Add(lstParole.Items(i).ToString)
            End If
        Next
    End Sub

    Private Sub frmSinonimi_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        DifferenzaLunghezza = 0
        ParolaSostitutiva = ""
        Me.Hide()
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub lsSignificati_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        'TrovaSinonimi(LemmaSinonimi(NParola, lsSignificati.SelectedIndex + 1), lstSuggerimenti)
    End Sub

    Private Sub lstContiene_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstContiene.DoubleClick
        '
        ' Sostituisce le parole errate.
        '
        Correggi()
        Esci()
    End Sub

    Private Sub lstSuggerimenti_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstContiene.KeyUp
        If e.KeyCode = Keys.Enter Then
            Correggi()
            Esci()
        End If
    End Sub

    Private Sub lstSuggerimenti_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstContiene.SelectedIndexChanged
        SenzaEco(lstContiene.SelectedItem)
    End Sub

    Private Sub rbInizia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbInizia.Click
        RiempiInizia()
    End Sub

    Private Sub rbContiene_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbContiene.Click
        RiempiContiene()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ApriGlossario()
    End Sub

    Private Sub rbContiene_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbContiene.CheckedChanged

    End Sub
End Class