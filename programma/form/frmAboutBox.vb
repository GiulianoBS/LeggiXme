Public NotInheritable Class frmAboutBox

    Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Label1.Text = Programma
        Label2.Text = Programma & Label2.Text
        lblVersione.Text = versione
        lblData.Text = "del " + Mid(VersioneAttuale, 7) + "/" + Mid(VersioneAttuale, 5, 2) + "/" + Mid(VersioneAttuale, 1, 4)
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        blnManuale = True
        Me.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        blnSito = True
        Me.Close()
    End Sub
End Class
