Public Class frmMessaggioLens

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
        Me.Dispose()
    End Sub

    Private Sub MessaggioLens_Load(sender As Object, e As EventArgs) Handles Me.Load
        If blnLens = True Then
            pb.Image = My.Resources.lens
            Label1.Text = "Lens è stato attivato"
            Me.BackColor = Color.SeaGreen
        Else
            pb.Image = My.Resources.lens_disattivato
            If InternetConnesso() = False Then
                Label1.Text = "Ti sei disconnesso da internet"
            ElseIf ChromeAttivo() = False Then
                Label1.Text = "Hai chiuso Chrome"
            Else
                Label1.Text = "Lens è stato disattivato"
            End If
            Me.BackColor = Color.Salmon
        End If
    End Sub
End Class