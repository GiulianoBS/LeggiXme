Imports System.Windows.Forms

Public Class frmMessaggioTasti

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub MessaggioTasti_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

    End Sub

    Private Sub MessaggioTasti_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim mes As String = "Il concetto scelto come origine" & vbCrLf
        mes += "non è ancora stato utilizzato." & vbCrLf
        mes += "Devi sceglierne uno dalla lista qui sotto."
        Label1.Text = mes
    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label1.Click

    End Sub
End Class
