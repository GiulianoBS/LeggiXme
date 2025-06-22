Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging

Public Class frmDisegna
    Dim xpos As Integer
    Dim ypos As Integer
    Dim firstx As Integer
    Dim firsty As Integer
    Dim secx As Integer
    Dim secy As Integer
    Dim larghezza As Integer = 480
    Dim altezza As Integer = 480

    Dim paint1 As Boolean

    Dim pencolor As New Pen(Color.Black, 1)
    Dim brushcolor As Brush = Brushes.Black
    Dim drawellipse As Boolean
    Dim drawrectangle As Boolean
    Dim drawText As Boolean

    Dim spray As Boolean
    Dim spraystart As Boolean


    Dim font1 As New Font("arial", 10)

    'save
    Dim bm As New Bitmap(larghezza, altezza)
    Dim graph As Graphics = Graphics.FromImage(bm)
    Dim name1 As String
    Dim save As Boolean
    'draw polygon / triangle
    Dim drawtriangle As Boolean
    Dim remhits As Integer = 0
    Dim firstclick As Point
    Dim secondclick As Point
    Dim thirdclick As Point

    'draw clear ellipse
    Dim drawclearellipse As Boolean
    'draw clear rectangle
    Dim drawclearrectangle As Boolean
    'draw filled triangle
    Dim drawfilledtriangle As Boolean
    Dim remhits1 As Integer = 0
    Dim firstclick1 As Point
    Dim secondclick1 As Point
    Dim thirdclick1 As Point
    'resize picturebox
    Dim resizepic As Boolean
    Dim drawresize As Boolean
    Dim picx As Integer
    Dim picy As Integer
    Dim resized As Boolean
    Dim picwidth As Integer
    Dim picheight As Integer

    'labelA properties
    Dim labelA As New Label
    'new image properties
    Dim newimage As Bitmap
    Dim newimagedraw As Boolean
    Dim padx As Integer
    Dim pady As Integer

    'remember image size 
    Dim imagex As Integer
    Dim imagey As Integer


    Public CartellaTemp As String = Environment.GetEnvironmentVariable("temp") & "\"
    Public ImgTemp As String = CartellaTemp & "ImgTemp.jpg"

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        brushcolor = Brushes.Black
        'Me.WindowState = FormWindowState.Maximized
        TrackBarR.Value = 50
        TrackBarG.Value = 50
        TrackBarB.Value = 50
        'create graphics 
        PictureBox6.CreateGraphics()
        PictureBox6.Width = larghezza
        PictureBox6.Height = altezza
        'picTemp.Size = PictureBox6.Size
        IncollaImmagine()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpDownSpessore.ValueChanged
        pencolor.Width = UpDownSpessore.Value
    End Sub

    Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picLinea.Click

        TogliBordi()
        picLinea.BorderStyle = BorderStyle.Fixed3D
        Azzera()
        paint1 = True
        PictureBox6.Cursor = Cursors.Cross
        'fix drawing on new image
        fixonnewimage()

    End Sub

    Private Sub PictureBox2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PicEllissePieno.Click
        TogliBordi()
        PicEllissePieno.BorderStyle = BorderStyle.Fixed3D
        Azzera()
        drawellipse = True
        PictureBox6.Cursor = Cursors.Cross
        'fix drawing on new image
        fixonnewimage()

    End Sub

    Private Sub PictureBox3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picRettangoloPieno.Click
        TogliBordi()
        picRettangoloPieno.BorderStyle = BorderStyle.Fixed3D
        Azzera()
        drawrectangle = True
        PictureBox6.Cursor = Cursors.Cross

        'fix drawing on new image
        fixonnewimage()

    End Sub

    Private Sub PictureBox4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picScrivi.Click
        'current tool

        If TextBox1.Text.Length > 0 Then
            Azzera()
            drawText = True
            PictureBox6.Cursor = Cursors.IBeam
        Else
            MsgBox("Prima scrivi il testo da inserire." + vbNewLine + "Poi premi il pulsante" + vbNewLine + "e clicca dove vuoi che compaia.", MsgBoxStyle.Information)
        End If

        'fix drawing on new image
        fixonnewimage()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuovo.Click

        'clear paint
        Using g As Graphics = Graphics.FromImage(PictureBox6.Image)
            g.Clear(Color.White)
            Me.Refresh()
        End Using

        'clear pen width
        UpDownSpessore.Value = 3
        'clear color for default
        brushcolor = Brushes.Black
        'unselect tools
        drawText = False
        drawrectangle = False
        paint1 = False
        drawellipse = False
        'clear textbox
        TextBox1.Text = ""
        'default pen color
        pencolor.Color = Color.Black

        ' UNSELECT ALL THE TOOLS WHILE OPENING NEW IMAGE 
        Azzera()

        'update status bar


    End Sub

    Sub clearpaint()
        Dim bm As New Bitmap(larghezza, altezza)
    End Sub

    Private Sub picPennello_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picPennello.Click

        TogliBordi()
        picPennello.BorderStyle = BorderStyle.Fixed3D

        spray = True

        paint1 = False
        resizepic = False
        drawText = False
        drawrectangle = False
        drawclearrectangle = False
        drawellipse = False
        drawtriangle = False
        drawfilledtriangle = False
        drawclearellipse = False
        PictureBox6.Cursor = Cursors.Cross
        'fix drawing on new image
        fixonnewimage()
    End Sub


    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        If newimagedraw = True Then
            ' Get the source bitmap.
            Dim bm_source As New Bitmap(PictureBox6.Image)

            ' Make a bitmap for the result.
            Dim bm_dest As New Bitmap( _
                CInt(PictureBox6.Width), _
                CInt(PictureBox6.Width))

            ' Make a Graphics object for the result Bitmap.
            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

            ' Copy the source image into the destination bitmap.
            gr_dest.DrawImage(bm_source, 0, 0, _
                bm_dest.Width + 1, _
                bm_dest.Height + 1)

            ' Display the result.

            Dim savefile As New SaveFileDialog
            savefile.FileName = "immagine"
            savefile.Filter = "Immagine JPG |*.jpg"
            savefile.ShowDialog()
            bm_dest.Save(savefile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)

        End If

        If newimagedraw = False Then
            'Get the image and the background color
            Dim oldImage As Image = PictureBox6.Image
            Dim backColor As Color = PictureBox6.BackColor
            '---------------------------------------------------------
            'edited code
            Dim picsizewidth As Integer = PictureBox6.Width
            Dim picsizeheight As Integer = PictureBox6.Height

            ' make a new image of the appropriate size, and get ready to draw on it
            '//picsizeheight instead of oldImage.Height
            Dim newImage1 As Image = New Bitmap(picsizewidth, picsizeheight, _
                                             Imaging.PixelFormat.Format32bppArgb)
            Using g As Graphics = Graphics.FromImage(newImage1)
                ' Draw the background, then the image
                Using backBrush As New SolidBrush(backColor)
                    g.FillRectangle(backBrush, 0, 0, newImage1.Width, newImage1.Height)
                    g.DrawImage(oldImage, 0, 0)
                End Using
            End Using

            Clipboard.SetImage(newImage1)

            Dim savefile As New SaveFileDialog
            savefile.FileName = "immagine"
            savefile.Filter = "Immagine JPG |*.jpg"
            savefile.ShowDialog()
            newImage1.Save(savefile.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
        End If

    End Sub

    Sub ScegliColore()
        ColorDialog1.ShowDialog()
        If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            pencolor.Color = ColorDialog1.Color
            brushcolor = New SolidBrush(ColorDialog1.Color)
        End If
    End Sub

    Private Sub TextBox1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Click
        TextBox1.Text = ""
    End Sub

    Private Sub PictureBox7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picCarattere.Click
        FontDialog1.ShowDialog()
        NomeFont = FontDialog1.Font.Name
        Stilefont = FontDialog1.Font.Style.ToString
        Misurafont = FontDialog1.Font.Size
    End Sub

    Private Sub PictureBox9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picEllisseVuoto.Click
        TogliBordi()
        picEllisseVuoto.BorderStyle = BorderStyle.Fixed3D

        drawclearellipse = True

        paint1 = False
        resizepic = False
        drawText = False
        drawrectangle = False
        drawclearrectangle = False
        drawellipse = False
        drawtriangle = False
        drawfilledtriangle = False
        spray = False

        PictureBox6.Cursor = Cursors.Cross

        'fix drawing on new image
        fixonnewimage()

    End Sub


    Private Sub PictureBox11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picRettangoloVuoto.Click
        TogliBordi()
        picRettangoloVuoto.BorderStyle = BorderStyle.Fixed3D
        Azzera()
        drawclearrectangle = True

        PictureBox6.Cursor = Cursors.Cross

        'fix drawing on new image
        fixonnewimage()

    End Sub

    Private Sub PictureBox12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picScegliColore.Click

    End Sub

    Private Sub Button1_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApri.Click

        OpenFileDialog1.FileName = ""
        OpenFileDialog1.Filter = "File immagine|*.bmp;*.gif;*.jpg;*.png"
        OpenFileDialog1.ShowDialog()
        ' OpenFileDialog1.Filter = "Bitmap file's |*.bmp"

        If IO.File.Exists(OpenFileDialog1.FileName) Then
            Azzera()
            Dim file As String = OpenFileDialog1.FileName
            Dim validation As New IO.FileInfo(file)
            Dim valida As String = validation.Extension.ToString
            'MsgBox(valida)
            If valida = ".bmp" Or valida = ".gif" Or valida = ".jpg" Or valida = ".png" Or valida = ".BMP" Or valida = ".GIF" Or valida = ".JPG" Or valida = ".PNG" Then
                CaricaImmagine(OpenFileDialog1.FileName)
            Else
                MsgBox("File Non Accettato. solo file immagine.", MsgBoxStyle.Exclamation)
            End If
            PictureBox0.Image = PictureBox6.Image
        End If

    End Sub

    Dim IsThePenDown As Boolean = False
    Dim inizio, LastPoint As Point
    Dim W As Integer, H As Integer
    Dim g As Graphics
    Dim MyPen As New Pen(Color.Black)
    'Dim myPenStyle As Drawing2D.DashStyle = Drawing2D.DashStyle.Solid

    Private Sub PictureBox6_MouseDown1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseDown
        'firstx = xpos.ToString
        'firsty = ypos.ToString
        If e.Button = Windows.Forms.MouseButtons.Left Then
            Try
                'PictureBox6.Image.Save(ImgTemp, System.Drawing.Imaging.ImageFormat.Jpeg)
                SalvaImmagine()
                btnAnnulla.Enabled = True
            Catch ex As Exception
            End Try

            IsThePenDown = True
            inizio = New Point(e.X, e.Y)
        End If

        firstx = e.X
        firsty = e.Y
        'test
        If spray = True Then
            spraystart = True
        End If

    End Sub

    Private Sub PictureBox6_MouseMove1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseMove

        xpos = e.X
        ypos = e.Y

        picx = e.X
        picy = e.Y

        'spray
        If spray = True And spraystart = True Then

            Dim g As Graphics = PictureBox6.CreateGraphics
            If newimagedraw = True Then
                'graph.DrawLine(pencolor, firstx, firsty, secx, secy)
                Dim graph1 As Graphics = Graphics.FromImage(newimage)
                'graph1.DrawEllipse(pencolor, e.X, e.Y, 10, 10)
                'graph1.FillEllipse(brushcolor, e.X, e.Y, 10, 10)
                graph1.DrawEllipse(pencolor, e.X, e.Y, UpDownSpessore.Value, UpDownSpessore.Value)
                graph1.FillEllipse(brushcolor, e.X, e.Y, UpDownSpessore.Value, UpDownSpessore.Value)

                PictureBox6.Image = newimage
            Else
                graph.DrawEllipse(pencolor, e.X, e.Y, UpDownSpessore.Value, UpDownSpessore.Value)
                graph.FillEllipse(brushcolor, e.X, e.Y, UpDownSpessore.Value, UpDownSpessore.Value)
                PictureBox6.Image = bm
            End If
        Else
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
                MyPen.Color = Color.Green
                PictureBox6.Refresh()
                If paint1 = True Then
                    PictureBox6.CreateGraphics.DrawLine(MyPen, inizio.X, inizio.Y, xpos, ypos)
                End If
                If drawclearrectangle = True Or drawrectangle = True Then
                    PictureBox6.CreateGraphics.DrawRectangle(MyPen, inizio.X, inizio.Y, W, H)
                End If
                If drawclearellipse = True Or drawellipse = True Then
                    PictureBox6.CreateGraphics.DrawEllipse(MyPen, inizio.X, inizio.Y, W, H)
                End If
                'LastPoint = NewPoint
            End If
        End If

    End Sub

    Dim NomeFont As String = "Verdana", Stilefont As String = "Regular", Misurafont As Single = 12

    Private Sub PictureBox6_MouseUp1(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PictureBox6.MouseUp

        IsThePenDown = False
        secx = e.X
        secy = e.Y

        If paint1 = True Then

            If newimagedraw = True Then
                'graph.DrawLine(pencolor, firstx, firsty, secx, secy)

                Dim graph1 As Graphics = Graphics.FromImage(newimage)
                graph1.DrawLine(pencolor, firstx, firsty, secx, secy)
                PictureBox6.Image = newimage
            Else
                graph.DrawLine(pencolor, firstx, firsty, secx, secy)
                PictureBox6.Image = bm
            End If
        End If

        '-------------------------------------------

        If drawellipse = True Then

            Dim g As Graphics = PictureBox6.CreateGraphics

            If newimagedraw = True Then
                'graph.DrawLine(pencolor, firstx, firsty, secx, secy)
                Dim graph1 As Graphics = Graphics.FromImage(newimage)
                graph1.DrawEllipse(pencolor, firstx, firsty, secx - firstx, secy - firsty)
                graph1.FillEllipse(brushcolor, firstx, firsty, secx - firstx, secy - firsty)
                PictureBox6.Image = newimage

            Else

                graph.DrawEllipse(pencolor, firstx, firsty, secx - firstx, secy - firsty)
                graph.FillEllipse(brushcolor, firstx, firsty, secx - firstx, secy - firsty)
                PictureBox6.Image = bm
            End If

        End If
        If drawrectangle = True Then

            Dim g As Graphics = PictureBox6.CreateGraphics

            If newimagedraw = True Then
                'graph.DrawLine(pencolor, firstx, firsty, secx, secy)
                Dim graph1 As Graphics = Graphics.FromImage(newimage)
                graph1.DrawRectangle(pencolor, firstx, firsty, secx - firstx, secy - firsty)
                graph1.FillRectangle(brushcolor, firstx, firsty, secx - firstx, secy - firsty)
                PictureBox6.Image = newimage

            Else

                graph.DrawRectangle(pencolor, firstx, firsty, secx - firstx, secy - firsty)
                graph.FillRectangle(brushcolor, firstx, firsty, secx - firstx, secy - firsty)
                PictureBox6.Image = bm
            End If
        End If
        If drawText = True Then
            Dim g As Graphics = PictureBox6.CreateGraphics
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            'font 
            Dim font2 As Font
            Dim textStyle As New FontStyle
            If Stilefont = "Italic" Then
                textStyle = FontStyle.Italic
            ElseIf Stilefont = "Regular" Then
                textStyle = FontStyle.Regular
            ElseIf Stilefont = "Bold" Then
                textStyle = FontStyle.Bold
            ElseIf Stilefont = "Strikeout" Then
                textStyle = FontStyle.Strikeout
            ElseIf Stilefont = "Underline" Then
                textStyle = FontStyle.Underline
            Else
                'default
                textStyle = FontStyle.Regular
            End If

            font2 = New Font(NomeFont, Misurafont, textStyle)
            '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            If newimagedraw = True Then
                'graph.DrawLine(pencolor, firstx, firsty, secx, secy)

                Dim graph1 As Graphics = Graphics.FromImage(newimage)
                graph1.DrawString(TextBox1.Text, font2, brushcolor, firstx, firsty)
                PictureBox6.Image = newimage

            Else

                graph.DrawString(TextBox1.Text, font2, brushcolor, firstx, firsty)
                PictureBox6.Image = bm
            End If

        End If

        If drawclearellipse = True Then

            Dim g As Graphics = PictureBox6.CreateGraphics

            If newimagedraw = True Then
                'graph.DrawLine(pencolor, firstx, firsty, secx, secy)
                Dim graph1 As Graphics = Graphics.FromImage(newimage)
                graph1.DrawEllipse(pencolor, firstx, firsty, secx - firstx, secy - firsty)
                PictureBox6.Image = newimage

            Else

                graph.DrawEllipse(pencolor, firstx, firsty, secx - firstx, secy - firsty)
                PictureBox6.Image = bm
            End If

        End If

        If drawclearrectangle = True Then

            Dim g As Graphics = PictureBox6.CreateGraphics

            If newimagedraw = True Then
                'graph.DrawLine(pencolor, firstx, firsty, secx, secy)
                Dim graph1 As Graphics = Graphics.FromImage(newimage)
                graph1.DrawRectangle(pencolor, firstx, firsty, secx - firstx, secy - firsty)
                PictureBox6.Image = newimage

            Else
                graph.DrawRectangle(pencolor, firstx, firsty, secx - firstx, secy - firsty)
                PictureBox6.Image = bm
            End If

        End If

        drawresize = False
        resizepic = False
        'new picturebox size

        resized = True

        'PictureBox6.Cursor = Cursors.Arrow

        spraystart = False
    End Sub

    Sub fixonnewimage()
        'cannot draw on new image because of picturebox stretch
        'fix for that
        If newimagedraw = True Then
            If PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage Then
                PictureBox6.SizeMode = PictureBoxSizeMode.Normal
                PictureBox6.Image = newimage
            End If
            'test
            If PictureBox6.SizeMode = PictureBoxSizeMode.Normal Then
                PictureBox6.Width = imagex
                PictureBox6.Height = imagey
                'PictureBox6.Image = newimage
            End If
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnIncolla.Click
        IncollaImmagine()
    End Sub

    Sub IncollaImmagine()
        If Clipboard.ContainsImage Then
            newimage = New Bitmap(Ridimensiona(Clipboard.GetImage))
            PictureBox6.Image = newimage ' Clipboard.GetImage
            newimagedraw = True

            ' UNSELECT ALL THE TOOLS WHILE OPENING NEW IMAGE 
            Azzera()

            'remember image size
            imagex = PictureBox6.Width
            imagey = PictureBox6.Height

            ' fixonnewimage()
        End If
    End Sub

    Private Function Ridimensiona(i As Image) As Image

        Try

            Dim img1 As New PictureBox

            img1.Image = i
            Dim bm_source As Bitmap = New Bitmap(img1.Image)

            Dim bm_dest As Bitmap = New Bitmap(480, 480)

            Dim gr_dest As Graphics = Graphics.FromImage(bm_dest)

            gr_dest.DrawImage(bm_source, 0, 0, bm_dest.Width, bm_dest.Height)

            Return bm_dest

        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Sub TogliBordi()
        picPennello.BorderStyle = BorderStyle.None
        picLinea.BorderStyle = BorderStyle.None
        picRettangoloPieno.BorderStyle = BorderStyle.None
        picRettangoloVuoto.BorderStyle = BorderStyle.None
        PicEllissePieno.BorderStyle = BorderStyle.None
        picEllisseVuoto.BorderStyle = BorderStyle.None
    End Sub

    Sub Azzera()
        paint1 = False
        resizepic = False
        drawText = False
        drawrectangle = False
        drawclearrectangle = False
        spray = False
        drawtriangle = False
        drawfilledtriangle = False
        drawellipse = False
        drawclearellipse = False
        TrackBarR.Value = 50
        TrackBarG.Value = 50
        TrackBarB.Value = 50
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnCopia.Click
        Clipboard.SetImage(PictureBox6.Image)
    End Sub

    Private Sub PictureBox12_MouseUp(sender As Object, e As MouseEventArgs) Handles picScegliColore.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then

            If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                PictureBox6.BackColor = ColorDialog1.Color
            End If
        Else

            If ColorDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
                pencolor.Color = ColorDialog1.Color
                brushcolor = New SolidBrush(ColorDialog1.Color)
                lblColore.BackColor = ColorDialog1.Color
            End If

        End If
    End Sub


    Private Sub btnAnnulla_Click(sender As Object, e As EventArgs) Handles btnAnnulla.Click
        If PictureBox6.Image IsNot Nothing Then
            Using g As Graphics = Graphics.FromImage(PictureBox6.Image)
                'g.Clear(Color.White)
                Me.Refresh()
            End Using
        End If
        PictureBox6.Image = Nothing
        TogliBordi()
        'CaricaImmagine(ImgTemp)
        PictureBox6.Image = GetImmagine(ImgTemp)
        Clipboard.SetImage(PictureBox6.Image)
        IncollaImmagine()
        'Kill(ImgTemp)

        btnAnnulla.Enabled = False
    End Sub

    Sub CaricaImmagine(imm As String)
        If PictureBox6.Image IsNot Nothing Then
            Using g As Graphics = Graphics.FromImage(PictureBox6.Image)
                'g.Clear(Color.White)
                Me.Refresh()
            End Using
        End If
        newimage = New Bitmap(imm)
        newimage = Ridimensiona(newimage)
        PictureBox6.Image = newimage
        'Azzera()
        newimagedraw = True
        'clear paint
        'remember image size
        imagex = PictureBox6.Width
        imagey = PictureBox6.Height
        Try
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub ImmagineAvvio()

    End Sub

    Public Function GetImmagine(ByVal nomeFile As String) As Image

        Dim Img As Image
        Using FS As New System.IO.FileStream(nomeFile, IO.FileMode.Open, IO.FileAccess.Read)
            Img = Image.FromStream(FS)
            'Close : chiude il flusso corrente e rende disponibili risorse ad esso associate
            FS.Close()
        End Using
        Return Img

    End Function

    Sub SalvaImmagine()
        Dim oldImage As Image = PictureBox6.Image
        Dim backColor As Color = PictureBox6.BackColor

        Dim picsizewidth As Integer = PictureBox6.Width
        Dim picsizeheight As Integer = PictureBox6.Height

        ' make a new image of the appropriate size, and get ready to draw on it
        '//picsizeheight instead of oldImage.Height
        Dim newImage1 As Image = New Bitmap(picsizewidth, picsizeheight, Imaging.PixelFormat.Format32bppArgb)
        Using g As Graphics = Graphics.FromImage(newImage1)
            ' Draw the background, then the image
            Using backBrush As New SolidBrush(backColor)
                g.FillRectangle(backBrush, 0, 0, newImage1.Width, newImage1.Height)
                g.DrawImage(oldImage, 0, 0)
            End Using
        End Using

        'Clipboard.SetImage(newImage1)
        newImage1.Save(ImgTemp, System.Drawing.Imaging.ImageFormat.Jpeg)
    End Sub

    Dim alfa As Single = 1.0

    Private Sub setRGBBrightNess()
        Dim brtR As Single = CSng(TrackBarR.Value / 50)
        Dim brtG As Single = CSng(TrackBarG.Value / 50)
        Dim brtB As Single = CSng(TrackBarB.Value / 50)

        Dim FattoreT As Single = 0.5F * (1.0F - brtR)
        Dim image_attr As New Imaging.ImageAttributes
        Dim cm As ColorMatrix = New ColorMatrix(New Single()() _
            { _
            New Single() {brtR, 0.0, 0.0, 0.0, 0.0}, _
            New Single() {0.0, brtG, 0.0, 0.0, 0.0}, _
            New Single() {0.0, 0.0, brtB, 0.0, 0.0}, _
            New Single() {0.0, 0.0, 0.0, alfa, 0.0}, _
            New Single() {FattoreT, FattoreT, FattoreT, 0.0, 1.0}})

        Dim rect As Rectangle = Rectangle.Round(PictureBox0.Image.GetBounds(GraphicsUnit.Pixel))

        Dim wid As Integer = PictureBox0.Image.Width
        Dim hgt As Integer = PictureBox0.Image.Height

        Dim img As New Bitmap(wid, hgt)
        Dim gr As Graphics = Graphics.FromImage(img)

        image_attr.SetColorMatrix(cm)
        gr.DrawImage(PictureBox0.Image, rect, 0, 0, wid, hgt, GraphicsUnit.Pixel, image_attr)
        PictureBox6.Image = img
        fixonnewimage()

    End Sub


    Private Sub TrackBarR_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBarR.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            'LeggiMessaggi("regola il rosso.")
        End If
    End Sub

    Private Sub TrackBarR_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarR.Scroll
        setRGBBrightNess()
    End Sub

    Private Sub TrackBarG_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBarG.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            ' LeggiMessaggi("regola il verde.")
        End If
    End Sub

    Private Sub TrackBarG_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarG.Scroll
        setRGBBrightNess()
    End Sub

    Private Sub TrackBarB_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TrackBarB.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            'LeggiMessaggi("regola il blu.")
        End If
    End Sub

    Private Sub TrackBarB_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBarB.Scroll
        setRGBBrightNess()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnOK.Click
        Try
            Clipboard.SetImage(PictureBox6.Image)
            Me.Close()
        Catch ex As Exception
        End Try
    End Sub


    Sub Ritaglia(x As Integer, y As Integer, w As Integer, h As Integer)
        Dim rect As Rectangle = New Rectangle(x, y, w, h)
        Dim bit As Bitmap = New Bitmap(PictureBox6.Image, PictureBox6.Width, PictureBox6.Height)

        Dim CropBitmap As Bitmap = New Bitmap(w, h)
        Dim g As Graphics = Graphics.FromImage(CropBitmap)
        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.PixelOffsetMode = Drawing2D.PixelOffsetMode.HighQuality
        g.CompositingQuality = Drawing2D.CompositingQuality.HighQuality
        g.DrawImage(bit, 0, 0, rect, GraphicsUnit.Pixel)
        Clipboard.SetImage(Ridimensiona(CropBitmap))
        IncollaImmagine()

    End Sub

End Class
