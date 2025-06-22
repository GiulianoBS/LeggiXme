Imports System.Drawing.Imaging
Imports System.Drawing
Imports System.Drawing.Drawing2D

Public Class frmImmagini

    Dim alfa As Single = 1.0
    Dim inizio As Point
    Dim W As Integer, H As Integer
    Dim g As Graphics
    Dim pic As Bitmap
    'Dim mybrush As SolidBrush
    Dim MyPen As New Pen(Color.Black)
    'Dim myPenStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid
    Dim PenColor As Color = Color.Yellow
    Dim IsThePenDown As Boolean

    Dim LastPoint, NewPoint As New Point

    Private Sub setRGBBrightNess()
        Dim brtR As Single = CSng(TrackBarR.Value / 50)
        Dim brtG As Single = CSng(TrackBarG.Value / 50)
        Dim brtB As Single = CSng(TrackBarB.Value / 50)

        Dim FattoreT As Single = 0.5F * (1.0F - brtR)
        Dim image_attr As New ImageAttributes
        Dim cm As ColorMatrix = New ColorMatrix(New Single()() _
            { _
            New Single() {brtR, 0.0, 0.0, 0.0, 0.0}, _
            New Single() {0.0, brtG, 0.0, 0.0, 0.0}, _
            New Single() {0.0, 0.0, brtB, 0.0, 0.0}, _
            New Single() {0.0, 0.0, 0.0, alfa, 0.0}, _
            New Single() {FattoreT, FattoreT, FattoreT, 0.0, 1.0}})

        Dim rect As Rectangle = Rectangle.Round(PictureBox1.Image.GetBounds(GraphicsUnit.Pixel))

        Dim wid As Integer = PictureBox1.Image.Width
        Dim hgt As Integer = PictureBox1.Image.Height

        Dim img As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(img)

        image_attr.SetColorMatrix(cm)
        gr.DrawImage(PictureBox1.Image, rect, 0, 0, wid, hgt, GraphicsUnit.Pixel, image_attr)
        PictureBox2.Image = img

    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        TrackBarR.Value = 50
        TrackBarG.Value = 50
        TrackBarB.Value = 50
        TrackBarC.Value = 50
        resizingTrackBar.Value = 0
        Try
            PictureBox1.Image = Clipboard.GetImage
            PictureBox2.Image = PictureBox1.Image
            pic0.Image = PictureBox1.Image
            pic = New Bitmap(PictureBox1.Width, PictureBox1.Height)
            pic = PictureBox1.Image
        Catch ex As Exception
            Me.Close()
        End Try

    End Sub

    Private Sub PictureBox2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseDown
        If e.Button = Windows.Forms.MouseButtons.Left Then
            IsThePenDown = True
            inizio = New Point(e.X, e.Y)
        End If
    End Sub

    Private Sub PictureBox2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseMove
        If IsThePenDown = True Then
            'NewPoint.X = e.X
            'NewPoint.Y = e.Y
            W = e.X - inizio.X
            H = e.Y - inizio.Y
            ' per tracciare linee *********
            'g = Graphics.FromImage(pic)
            'g.DrawLine(MyPen, LastPoint.X, LastPoint.Y, e.X, e.Y)
            'PictureBox2.Image = pic
            '******************************
            MyPen.DashStyle = DashStyle.DashDotDot
            MyPen.Color = PenColor
            PictureBox2.Refresh()
            PictureBox2.CreateGraphics.DrawRectangle(MyPen, inizio.X, inizio.Y, W, H)
            'LastPoint = NewPoint
        End If
    End Sub

    Private Sub PictureBox2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox2.MouseUp
        IsThePenDown = False
    End Sub

    Private Function CropBitmap(ByRef bmp As Bitmap, ByVal X As Integer, ByVal Y As Integer, ByVal W As Integer, ByVal H As Integer) As Bitmap
        Dim rect As New Rectangle(X, Y, W, H)
        Dim cropped As Bitmap = bmp.Clone(rect, bmp.PixelFormat)
        Return cropped
    End Function

    Private Sub btnRitaglia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRitaglia.Click
        Dim rect As Rectangle = New Rectangle(inizio.X, inizio.Y, W, H)
        Dim bit As Bitmap = New Bitmap(PictureBox2.Image, PictureBox2.Width, PictureBox2.Height)

        Dim CropBitmap As Bitmap = New Bitmap(W, H)
        Dim g As Graphics = Graphics.FromImage(CropBitmap)
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel)
        PictureBox2.Image = CropBitmap
        PictureBox1.Image = PictureBox2.Image
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnulla.Click
        PictureBox2.Image = pic0.Image
        PictureBox1.Image = pic0.Image
        Ridimensiona()
        setRGBBrightNess()
    End Sub

    Private Sub resizingTrackBar_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles resizingTrackBar.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("ridimensiona l'immagine.")
        End If
    End Sub

    Private Sub resizingTrackBar_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles resizingTrackBar.Scroll
        Ridimensiona()
    End Sub

    Private Sub Ridimensiona()
        Dim i As Int16 = 0.5
        Try

            Dim scale_factor As Single
            Dim img1 As New PictureBox

            'scale_factor = Integer.Parse(resizingTrackBar.Value)
            scale_factor = 1 + CSng(resizingTrackBar.Value) / 10

            'If scale_factor = 0 Then Exit Sub
            img1.Image = pic0.Image
            Dim bm_source As Bitmap = New Bitmap(img1.Image)

            Dim bm_dest As Bitmap = New Bitmap(CInt(bm_source.Width * scale_factor), CInt(bm_source.Height * scale_factor))

            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

            gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width + i, bm_dest.Height + i)

            PictureBox2.Image = bm_dest
            PictureBox1.Image = PictureBox2.Image
            setRGBBrightNess()

        Catch ex As Exception

        End Try
    End Sub

    Private Sub btnAnnullaTutto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnullaTutto.Click
        TrackBarR.Value = 50
        TrackBarG.Value = 50
        TrackBarB.Value = 50
        TrackBarC.Value = 50
        resizingTrackBar.Value = 0
        PictureBox2.Image = pic0.Image
        PictureBox1.Image = pic0.Image
    End Sub

    Private Sub btnAnnullaMisure_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnullaMisure.Click
        resizingTrackBar.Value = 0
        Ridimensiona()
        setRGBBrightNess()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Clipboard.SetImage(PictureBox2.Image)
        Me.Close()
    End Sub

    Private Sub btnChiudi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChiudi.Click
        Clipboard.Clear()
        Me.Close()
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("regola il rosso.")
        End If
    End Sub

    Private Sub Panel2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("regola il verde.")
        End If
    End Sub

    Private Sub Panel3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel3.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("regola il blu.")
        End If
    End Sub

    Private Sub Panel4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel4.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("regola il contrasto.")
        End If
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("ritaglia l'immagine.")
        End If
    End Sub

    Private Sub btnRitaglia_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRitaglia.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("ritaglia l'immagine.")
        End If
    End Sub

    Private Sub btnAnnulla_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAnnulla.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("annulla ritaglia.")
        End If
    End Sub

    Private Sub btnAnnullaMisure_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAnnullaMisure.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("annulla ridimensiona.")
        End If
    End Sub

    Private Sub btnAnnullaTutto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAnnullaTutto.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("annulla tutto.")
        End If
    End Sub

    Private Sub Label2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("annulla tutto.")
        End If
    End Sub

    Private Sub Label3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("annulla ridimensiona.")
        End If
    End Sub

    Private Sub btnOK_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnOK.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("conferma modifiche e chiudi.")
        End If
    End Sub

    Private Sub btnChiudi_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnChiudi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("annulla modifiche e chiudi.")
        End If
    End Sub

    Private Sub TrackBarR_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBarR.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("regola il rosso.")
        End If
    End Sub

    Private Sub TrackBarR_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarR.Scroll
        setRGBBrightNess()
    End Sub

    Private Sub TrackBarG_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBarG.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("regola il verde.")
        End If
    End Sub

    Private Sub TrackBarG_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarG.Scroll
        setRGBBrightNess()
    End Sub

    Private Sub TrackBarB_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBarB.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("regola il blu.")
        End If
    End Sub

    Private Sub TrackBarB_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarB.Scroll
        setRGBBrightNess()
    End Sub

    Private Sub TrackBarC_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBarC.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("regola il contrasto.")
        End If
    End Sub

    Private Sub TrackBarC_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarC.Scroll
        TrackBarR.Value = TrackBarC.Value
        TrackBarG.Value = TrackBarC.Value
        TrackBarB.Value = TrackBarC.Value
        setRGBBrightNess()
    End Sub

End Class


