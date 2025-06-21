Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class Schermo2
    ' Per copiare porzioni di schermo come immagine

    Dim g As Graphics
    Dim pic As Bitmap
    Dim MyPen As New Pen(Color.Red)
    Dim attivo As Boolean

    Private Sub Schermo2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.WindowState = FormWindowState.Maximized
        Dim p As Point
        p.X = 0 : p.Y = 0
    End Sub
    'Dim inizio As Point

    Private Sub Schermo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Me.MouseDown
        Sel.Width = 0
        Sel.Height = 0
        Sel.Location = e.Location
        attivo = True
        ' inizio = New Point(e.X, e.Y)
    End Sub

    Dim W, H As Integer

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
        If MisuraImmagine.Width > 0 And MisuraImmagine.Height > 0 Then
            Me.Width = 1
            Me.Height = 1
            Me.Opacity = 0
            AcquisisciImmagine(InizioImmagine, MisuraImmagine)
            My.Computer.Audio.Play(My.Resources.clic, AudioPlayMode.WaitToComplete)
            Dim r As Integer = MsgBox("Incollo l'immagine?", MsgBoxStyle.YesNo)
            If r = vbYes Then
                frmLeggiConMe.RTB.Paste()
            End If
        End If
        frmLeggiConMe.Show()
        Me.Close()
    End Sub

    Private Sub Sel_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Sel.MouseDown
        Sel.Width = 0 : Sel.Height = 0
        Sel.Location = Cursor.Position
    End Sub

    Private Sub AcquisisciImmagine(ByVal i As Point, ByVal m As Size)
        Me.Opacity = 0
        Dim bmp As New Bitmap(m.Width, m.Height)
        Dim gfx As Graphics = System.Drawing.Graphics.FromImage(bmp)
        gfx.CopyFromScreen(i.X, i.Y, 0, 0, m, CopyPixelOperation.MergeCopy)
        gfx.Dispose()
        Clipboard.SetImage(bmp)
        RidimensionaInClipboard()
    End Sub

End Class