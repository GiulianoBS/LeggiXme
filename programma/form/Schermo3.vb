Public Class Schermo3
    ' Schermo per l'OCR

    Dim attivo As Boolean

    Private Sub Schermo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

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

    Dim InizioImmagine As Point, FineImmagine As Point, MisuraImmagine As Size

    Public Sub TopoGiu()
        FineImmagine.X = 0
        FineImmagine.Y = 0
        MisuraImmagine.Width = 0
        MisuraImmagine.Height = 0
        InizioImmagine = Cursor.Position
    End Sub

    Private Sub TopoSu()
        System.Windows.Forms.Cursor.Current = Cursors.WaitCursor
        InizioImmagine.X = Sel.Location.X * Risoluzione / 100
        InizioImmagine.Y = Sel.Location.Y * Risoluzione / 100
        MisuraImmagine.Width = Sel.Size.Width * Risoluzione / 100
        MisuraImmagine.Height = Sel.Size.Height * Risoluzione / 100
        Dim i As Point = InizioImmagine
        Dim f As Point
        f.X = i.X + MisuraImmagine.Width
        f.Y = i.Y + MisuraImmagine.Height
        Me.Opacity = 0
        Clipboard.Clear()
        If MisuraImmagine.Width > 0 And MisuraImmagine.Height > 0 Then
            Me.Width = 1
            Me.Height = 1

            Dim cm As String = "cmd /c " & Capture2text() & " " & i.X.ToString & " " & i.Y.ToString & " " & f.X.ToString & " " & f.Y.ToString

            My.Computer.Audio.Play(My.Resources.clic, AudioPlayMode.WaitToComplete)

            Dim ProcID As Integer = Shell(cm, AppWinStyle.Hide, Wait:=True)

            Dim a As String = ""
            If Clipboard.ContainsText Then
                a = Clipboard.GetText()
                a = a.Replace("- ", "")
                Clipboard.SetText(a)
            End If
        End If
        frmLettore.Show()
        System.Windows.Forms.Cursor.Current = Cursors.AppStarting
        If Clipboard.ContainsText Then
            frmLettore.LeggiOCR()
        Else
            LeggiMessaggi("Non c'è nulla da leggere.")
        End If
        Me.Close()

    End Sub

    Private Sub Sel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Sel.MouseDown
        Sel.Width = 0 : Sel.Height = 0
        Sel.Location = Cursor.Position
    End Sub

End Class