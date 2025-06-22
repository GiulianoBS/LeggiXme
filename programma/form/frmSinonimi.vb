Option Strict Off
Option Explicit On
Friend Class frmSinonimi
	Inherits System.Windows.Forms.Form
	

	Private Sub cmdEsci_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEsci.Click
        Esci()
	End Sub
	
	Private Sub cmdCambia_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCambia.Click
        Dim strText As String = ""
		
		If lstSuggerimenti.SelectedIndex = -1 Then
			Exit Sub
		End If

        Correggi()
        Esci()
    End Sub

    Private Sub Esci()
        blnEsci = True
        Me.Close()
        frmLeggiConMe.BringToFront()
        frmLeggiConMe.RTB.Focus()
    End Sub

    Private Sub Correggi()
        If lstSuggerimenti.Items.Count = 0 Then Exit Sub
        On Error Resume Next
        ParolaSostitutiva = CStr(lstSuggerimenti.Items.Item(lstSuggerimenti.SelectedIndex))
        DifferenzaLunghezza = Len(ParolaSostitutiva) - Len(txtDaCercare.Text)
        'frmLeggiXme.RTB.SelectionBackColor = Color.White

        frmLeggiConMe.RTB.SelectedText = CStr(lstSuggerimenti.Items.Item(lstSuggerimenti.SelectedIndex))
        frmLeggiConMe.RTB.SelectionStart += Len(frmLeggiConMe.RTB.SelectedText)
    End Sub

	Private Sub cmdIgnora_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdIgnora.Click
        Dim txtSostituisci As String
		'Chiude il form e ignora
		DifferenzaLunghezza = 0
		ParolaSostitutiva = ""
        txtSostituisci = ""
        Esci()
    End Sub

    Private Sub frmSinonimi_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        blnEsci = False
    End Sub

    Private Sub frmSinonimi_FormClosing(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Dim Cancel As Boolean = eventArgs.Cancel
        Dim UnloadMode As System.Windows.Forms.CloseReason = eventArgs.CloseReason
        DifferenzaLunghezza = 0
        ParolaSostitutiva = ""
        Me.Hide()
        eventArgs.Cancel = Cancel
    End Sub

    Private Sub lsSignificati_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lsSignificati.Click
        Dim p As String = lsSignificati.SelectedItem

        If InStr(p, "s.m.") <> 0 Then
            p = "sostantivo maschile. " & Mid(p, 6)
        End If
        If InStr(p, "s.f.") <> 0 Then
            p = "sostantivo femminile. " & Mid(p, 6)
        End If
        If InStr(p, "agg.") <> 0 Then
            p = "aggettivo. " & Mid(p, 6)
        End If
        If InStr(p, "avv.") <> 0 Then
            p = "avverbio. " & Mid(p, 6)
        End If
        If InStr(p, "inter.") <> 0 Then
            p = "interiezione. " & Mid(p, 8)
        End If
        If InStr(p, "v.") <> 0 Then
            p = "verbo. " & Mid(p, 4)
        End If
        If InStr(p, "cong.") <> 0 Then
            p = "congiunzione. " & Mid(p, 7)
        End If

        SenzaEco(p)
        frmLeggiConMe.Focus()

    End Sub

    Private Sub lsSignificati_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lsSignificati.SelectedIndexChanged
        TrovaSinonimi(LemmaSinonimi(NParola, lsSignificati.SelectedIndex + 1), lstSuggerimenti)
    End Sub

    Private Sub lstSuggerimenti_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSuggerimenti.DoubleClick
        '
        ' Sostituisce le parole errate.
        '
        Correggi()
        Esci()
    End Sub

    Private Sub lstSuggerimenti_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstSuggerimenti.KeyUp
        If e.KeyCode = Keys.Enter Then
            Correggi()
            Esci()
        End If
    End Sub

    Private Sub lstSuggerimenti_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles lstSuggerimenti.SelectedIndexChanged
        'Leggi2(lstSuggerimenti.Items.Item(lstSuggerimenti.SelectedIndex))
        SenzaEco(lstSuggerimenti.SelectedItem)
        frmLeggiConMe.Focus()
    End Sub

    Private Sub txtDaCercare_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDaCercare.Click
        SenzaEco(txtDaCercare.Text)
        'frmLeggiConMe.Focus()
    End Sub

   
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txtDaCercare.Text <> "" Then
            MostraSinonimi2(txtDaCercare.Text)
        End If
    End Sub
End Class