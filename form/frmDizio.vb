Option Strict Off
Option Explicit On
Friend Class frmDizio
    Inherits System.Windows.Forms.Form

    Private Sub cmdEsci_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdEsci.Click
        Esci()
    End Sub

    Private Sub cmdCambia_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdCambia.Click
        Dim strText As String = ""

        If txtTraduzione.Text = "" Then
            Exit Sub
        End If
        Clipboard.SetText(" " + txtTraduzione.Text + " ")
        'Correggi()
        Esci()
    End Sub

    Private Sub Esci()
        blnEsci = True
        Me.Close()
        frmLeggiConMe.BringToFront()
        frmLeggiConMe.RTB.Focus()
    End Sub

    Private Sub Correggi()
        If txtTraduzione.Text = "" Then Exit Sub
        Clipboard.SetText(" " + txtTraduzione.Text + " ")
        On Error Resume Next
        frmLeggiConMe.fnIncolla()
    End Sub

    Private Sub frmSinonimi_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        blnEsci = False
        'MsgBox(DA_A)
        Select Case DA_A
            Case 1 : RadioButton1.Checked = True
            Case 2 : RadioButton2.Checked = True
            Case 3 : RadioButton3.Checked = True
            Case 4 : RadioButton4.Checked = True
            Case 5 : RadioButton5.Checked = True
            Case 6 : RadioButton6.Checked = True
            Case 7 : RadioButton7.Checked = True
            Case 8 : RadioButton8.Checked = True
        End Select

        Traduci()

    End Sub

    Dim VOrigine As String = "", VTraduzione As String = ""

    Sub Traduci()
        DaTradurre = txtDaCercare.Text
        If DaTradurre = "" Then Exit Sub
        Select Case DA_A
            Case 1
                VOrigine = "Italian" : VTraduzione = "English"
            Case 2
                VOrigine = "Italian" : VTraduzione = "French"
            Case 3
                VOrigine = "Italian" : VTraduzione = "German"
            Case 4
                VOrigine = "Italian" : VTraduzione = "Spanish"
            Case 5
                VOrigine = "English" : VTraduzione = "Italian"
            Case 6
                VOrigine = "French" : VTraduzione = "Italian"
            Case 7
                VOrigine = "German" : VTraduzione = "Italian"
            Case 8
                VOrigine = "Spanish" : VTraduzione = "Italian"
        End Select

        Dim t As GoogleTranslator.Translator = New GoogleTranslator.Translator
        txtTraduzione.Text = t.Translate(DaTradurre, VOrigine, VTraduzione)

    End Sub

    Private Sub lstSuggerimenti_DoubleClick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs)
        '
        ' Sostituisce le parole errate.
        '
        Correggi()
        Esci()
    End Sub

    Private Sub lstSuggerimenti_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            Correggi()
            Esci()
        End If
    End Sub

    Private Sub txtDaCercare_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDaCercare.Click
        'SenzaEco(txtDaCercare.Text)
        'frmLeggiConMe.Focus()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadioButton1.CheckedChanged

    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadioButton1.Click, _
                  RadioButton2.Click, RadioButton3.Click, RadioButton4.Click, RadioButton5.Click, RadioButton6.Click, RadioButton7.Click, RadioButton8.Click
        DA_A = CInt(sender.TAG)
        Traduci()
    End Sub

    Private Sub txtDaCercare_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDaCercare.KeyDown
        If e.KeyCode = Keys.Enter Then
            Traduci()
        End If
    End Sub

    Private Sub txtDaCercare_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDaCercare.TextChanged

    End Sub
End Class