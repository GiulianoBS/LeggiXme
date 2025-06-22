Public Class Schermo
    ' Per acuisire immagini da frmPDF o da frmINT

    Dim attivo As Boolean

    Private Sub Schermo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Sel.Width = 0
        Sel.Height = 0
        Sel.Location = e.Location
        attivo = True
    End Sub

    Private Sub Schermo_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseMove
        If attivo = False Then Exit Sub
        Sel.Width = e.X - Sel.Left
        Sel.Height = e.Y - Sel.Top
    End Sub

    Private Sub Schermo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseUp
        attivo = False
        TopoSu()
    End Sub

    Public Sub TopoGiu()
        FineImmagine.X = 0
        FineImmagine.Y = 0
        MisuraImmagine.Width = 0
        MisuraImmagine.Height = 0
        InizioImmagine = Cursor.Position
    End Sub

    Private Sub TopoSu()
        InizioImmagine.X = Sel.Location.X * Risoluzione / 100
        InizioImmagine.Y = Sel.Location.Y * Risoluzione / 100
        MisuraImmagine.Width = Sel.Size.Width * Risoluzione / 100
        MisuraImmagine.Height = Sel.Size.Height * Risoluzione / 100
    End Sub

    Private Sub Sel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Sel.MouseDown
        Sel.Width = 0 : Sel.Height = 0
        Sel.Location = Cursor.Position
    End Sub



End Class