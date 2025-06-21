Imports iTextSharp.text.pdf

Public Class modPdfManipulation2

    Private Class MyPdfReader
        Inherits iTextSharp.text.pdf.PdfReader

        Private Sub New(ByVal filename As String)
            MyBase.New(filename)
            Me.encrypted = False
        End Sub

        Friend Shared Function GetInstance(ByVal filePath As String) As MyPdfReader
            Return New MyPdfReader(filePath)
        End Function
    End Class

    Private Class DocumentEx
        Inherits iTextSharp.text.Document

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal pageSize As iTextSharp.text.Rectangle)
            MyBase.New(pageSize)
        End Sub

        Public Sub New(ByVal pageSize As iTextSharp.text.Rectangle, _
                       ByVal leftMargin As Single, ByVal rightMargin As Single, _
                       ByVal topMargin As Single, ByVal bottomMargin As Single)
            MyBase.New(pageSize, leftMargin, rightMargin, topMargin, bottomMargin)
        End Sub

        Public Overloads Function AddProducer(ByVal producerName As String) As Boolean
            Return Me.Add(New iTextSharp.text.Meta(iTextSharp.text.Element.PRODUCER, producerName))
        End Function
    End Class

    Public Shared Function SenzaProtezioni(ByVal Pdf As String) As Boolean
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        reader = New iTextSharp.text.pdf.PdfReader(Pdf)
        If (reader.IsOpenedWithFullPermissions) Then
            Return True
        Else
            Return False
        End If
    End Function

    ''' <summary>
    ''' Remove all resttrictions from a pdf file
    ''' </summary>
    ''' <param name="restrictedPdf">The full path to the restricted pdf file</param>
    ''' <param name="saveABackup">If True, the original restricted pdf will be saved as [filename]_BAK.pdf. Else, it will be overwritten.</param>
    ''' <returns>True if the operation succeeded. False otherwise</returns>
    ''' <remarks></remarks>
    Public Shared Function RemoveRestrictions(ByVal restrictedPdf As String, Optional ByVal saveABackup As Boolean = True) As String
        Dim result As String = ""
        Try
            'MsgBox(Environment.GetEnvironmentVariable("temp"))
            'Dim outputPdf As String = String.Format("{0}\{1}.{2}", IO.Path.GetDirectoryName(restrictedPdf), Date.Now.ToString("yyyyMMddHHmmss"), "LXP")
            Dim outputPdf As String = String.Format("{0}\{1}.{2}", Environment.GetEnvironmentVariable("temp"), "__" & Date.Now.ToString("yyyyMMddHHmmss"), "pdf")
            result = outputPdf
            Dim reader As MyPdfReader = MyPdfReader.GetInstance(restrictedPdf)
            'create a filestream for output
            Dim fs As New System.IO.FileStream(outputPdf, IO.FileMode.Create, IO.FileAccess.Write)
            'use stamper to copy the source pdf to output
            Dim stamper As New iTextSharp.text.pdf.PdfStamper(reader, fs)
            'remove restrictions
            Dim perms As Integer = iTextSharp.text.pdf.PdfWriter.ALLOW_ASSEMBLY Or _
                                   iTextSharp.text.pdf.PdfWriter.ALLOW_COPY Or _
                                   iTextSharp.text.pdf.PdfWriter.ALLOW_DEGRADED_PRINTING Or _
                                   iTextSharp.text.pdf.PdfWriter.ALLOW_FILL_IN Or _
                                   iTextSharp.text.pdf.PdfWriter.ALLOW_MODIFY_ANNOTATIONS Or _
                                   iTextSharp.text.pdf.PdfWriter.ALLOW_MODIFY_CONTENTS Or _
                                   iTextSharp.text.pdf.PdfWriter.ALLOW_PRINTING Or _
                                   iTextSharp.text.pdf.PdfWriter.ALLOW_SCREENREADERS

            stamper.SetEncryption(False, "", "", perms)
            stamper.Close()
            fs.Dispose()
            reader.Close()

            'If saveABackup = True Then
            'My.Computer.FileSystem.RenameFile(restrictedPdf, String.Format("{0}_{1}.{2}", IO.Path.GetFileNameWithoutExtension(restrictedPdf), "BAK", "pdf"))
            'My.Computer.FileSystem.RenameFile(restrictedPdf, String.Format("{0}.{1}", IO.Path.GetFileNameWithoutExtension(restrictedPdf), "pdf"))
            'Else
            'IO.File.Delete(restrictedPdf)
            'End If
            'My.Computer.FileSystem.RenameFile(outputPdf, IO.Path.GetFileName(restrictedPdf))
        Catch ex As Exception
            'MsgBox(ex.Message)
            Debug.Write(ex.Message)
            result = ""
        End Try
        Return result
    End Function
    ''' <summary>
    ''' Extract a single page from source pdf to a new pdf
    ''' </summary>
    ''' <param name="sourcePdf">the full path to source pdf file</param>
    ''' <param name="pageNumberToExtract">the page number to extract</param>
    ''' <param name="outPdf">the full path for the output pdf</param>
    ''' <remarks></remarks>
    Public Overloads Shared Sub ExtractPdfPage(ByVal sourcePdf As String, ByVal pageNumberToExtract As Integer, ByVal outPdf As String)
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim doc As iTextSharp.text.Document = Nothing
        'Dim doc As PdfManipulation.DocumentEx = Nothing
        Dim pdfCpy As iTextSharp.text.pdf.PdfCopy = Nothing
        Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing
        Try
            reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
            doc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1))
            'doc = New PdfManipulation.DocumentEx(reader.GetPageSizeWithRotation(pageNumberToExtract))
            'Debug.WriteLine("Add producer: " & doc.AddProducer().ToString)
            pdfCpy = New iTextSharp.text.pdf.PdfCopy(doc, New IO.FileStream(outPdf, IO.FileMode.Create))
            doc.Open()
            page = pdfCpy.GetImportedPage(reader, pageNumberToExtract)
            pdfCpy.AddPage(page)
            doc.Close()
            reader.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Extract selected pages from a source pdf to a new pdf
    ''' </summary>
    ''' <param name="sourcePdf">the full path to source pdf to a new pdf</param>
    ''' <param name="pageNumbersToExtract">the page numbers to extract (i.e {1, 3, 5, 6})</param>
    ''' <param name="outPdf">The full path for the output pdf</param>
    ''' <remarks>The output pdf will contains the extracted pages in the order of the page numbers listed
    ''' in pageNumbersToExtract parameter.</remarks>
    Public Overloads Shared Sub ExtractPdfPage(ByVal sourcePdf As String, ByVal pageNumbersToExtract As Integer(), ByVal outPdf As String)
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim doc As iTextSharp.text.Document = Nothing
        Dim pdfCpy As iTextSharp.text.pdf.PdfCopy = Nothing
        Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing
        Try
            reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
            doc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1))
            pdfCpy = New iTextSharp.text.pdf.PdfCopy(doc, New IO.FileStream(outPdf, IO.FileMode.Create))
            doc.Open()
            For Each pageNum As Integer In pageNumbersToExtract
                page = pdfCpy.GetImportedPage(reader, pageNum)
                pdfCpy.AddPage(page)
            Next
            doc.Close()
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    ''' <summary>
    ''' Extract pages from an existing pdf file to create a new pdf with bookmarks preserved
    ''' </summary>
    ''' <param name="sourcePdf">full path to sthe source pdf</param>
    ''' <param name="pageNumbersToExtract">an integer array containing the page number of the pages to be extracted</param>
    ''' <param name="outPdf">the full path to the output pdf</param>
    ''' <remarks></remarks>
    Public Shared Sub ExtractPdfPages(ByVal sourcePdf As String, ByVal pageNumbersToExtract As Integer(), ByVal outPdf As String)

        Dim raf As iTextSharp.text.pdf.RandomAccessFileOrArray = Nothing
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim outlines As System.Collections.ArrayList = Nothing
        Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing
        Dim stamper As iTextSharp.text.pdf.PdfStamper = Nothing
        Dim hshTable As System.Collections.Hashtable = Nothing
        Try
            raf = New iTextSharp.text.pdf.RandomAccessFileOrArray(sourcePdf)
            reader = New iTextSharp.text.pdf.PdfReader(raf, Nothing)
            outlines = iTextSharp.text.pdf.SimpleBookmark.GetBookmark(reader)
            reader.SelectPages(New System.Collections.ArrayList(pageNumbersToExtract))
            stamper = New iTextSharp.text.pdf.PdfStamper(reader, New IO.FileStream(outPdf, IO.FileMode.Create))
            RemoveUnusedBookmarks(outlines, pageNumbersToExtract)
            stamper.Outlines = outlines
            stamper.Close()
            reader.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Shared Sub RemoveUnusedBookmarks(ByRef bookmarks As System.Collections.ArrayList, ByVal pagesToKeep() As Integer)
        Dim bookmark As System.Collections.Hashtable = Nothing
        Dim obj As Object = Nothing
        For i As Integer = bookmarks.Count - 1 To 0 Step -1
            obj = bookmarks(i)
            If TypeOf obj Is System.Collections.ArrayList Then
                RemoveUnusedBookmarks(DirectCast(obj, System.Collections.ArrayList), pagesToKeep)
            ElseIf TypeOf obj Is System.Collections.Hashtable Then
                bookmark = DirectCast(obj, System.Collections.Hashtable)
                If bookmark.ContainsKey("Page") Then
                    Dim value As String = DirectCast(bookmark.Item("Page"), String)
                    If Not String.IsNullOrEmpty(value) Then
                        Dim parts() As String = value.Split(" "c)
                        If parts.Length > 0 Then
                            Dim pageNum As Integer = -1
                            If Integer.TryParse(parts(0), pageNum) Then
                                Dim idx As Integer = System.Array.IndexOf(pagesToKeep, pageNum)
                                If idx < 0 Then
                                    bookmarks.Remove(obj)
                                Else
                                    parts(0) = (idx + 1).ToString
                                    value = String.Join(" ", parts)
                                    bookmark.Item("Page") = value
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        Next
    End Sub


    ''' <summary>
    ''' Split a single pdf file into multiple pdfs with equal number of pages.
    ''' </summary>
    ''' <param name="sourcePdf">the full path to the source pdf</param>
    ''' <param name="parts">the number of splitted pdfs to split to</param>
    ''' <param name="baseNameOutPdf">the base file name (full path) for splitted pdfs.
    ''' The actual output pdf file names will be serialized. </param>
    ''' <remarks>The last splitted pdf may not have
    ''' the same number of pages as the rest, depending on the combination of number of pages in the source pdf 
    ''' and the number of parts to be splitted. For example, if the original pdf has 9 pages and it is to be 
    ''' splitted into 5 parts, the last splitted pdf will have only 1 page while all others have 2 pages.</remarks>
    Public Shared Sub SplitPdfByParts(ByVal sourcePdf As String, ByVal parts As Integer, ByVal baseNameOutPdf As String)
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim doc As iTextSharp.text.Document = Nothing
        Dim pdfCpy As iTextSharp.text.pdf.PdfCopy = Nothing
        Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing
        Dim pageCount As Integer = 0
        Try
            reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
            pageCount = reader.NumberOfPages
            If pageCount < parts Then
                Throw New ArgumentException("Not enough pages in source pdf to split")
            Else
                Dim n As Integer = pageCount \ parts
                Dim currentPage As Integer = 1
                Dim ext As String = IO.Path.GetExtension(baseNameOutPdf)
                Dim outfile As String = String.Empty
                For i As Integer = 1 To parts
                    outfile = baseNameOutPdf.Replace(ext, "_" & i & ext)
                    doc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(currentPage))
                    pdfCpy = New iTextSharp.text.pdf.PdfCopy(doc, New IO.FileStream(outfile, IO.FileMode.Create))
                    doc.Open()
                    If i < parts Then
                        For j As Integer = 1 To n
                            page = pdfCpy.GetImportedPage(reader, currentPage)
                            pdfCpy.AddPage(page)
                            currentPage += 1
                        Next j
                    Else
                        For j As Integer = currentPage To pageCount
                            page = pdfCpy.GetImportedPage(reader, j)
                            pdfCpy.AddPage(page)
                        Next j
                    End If
                    doc.Close()
                Next
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



    ''' <summary>
    ''' Split source pdf into multiple pdfs with specifc number of pages
    ''' </summary>
    ''' <param name="sourcePdf">the full path to source pdf</param>
    ''' <param name="numOfPages">the number of pages each splitted pdf should contain</param>
    ''' <param name="baseNameOutPdf">the base file name (full path) for splitted pdfs.
    ''' The actual output pdf file names will be serialized. </param>
    ''' <remarks>The last splitted pdf may not have
    ''' the same number of pages as the rest, depending on the combination of number of pages in the source pdf 
    ''' and the number of target pages in each splitted pdf. For example, if the original pdf has 9 pages and it is to be 
    ''' splitted with 2 pages for each pdf, the last splitted pdf will have only 1 page while all others have 2 pages.</remarks>
    Public Shared Sub SplitPdfByPages(ByVal sourcePdf As String, ByVal numOfPages As Integer, ByVal baseNameOutPdf As String)
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim doc As iTextSharp.text.Document = Nothing
        Dim pdfCpy As iTextSharp.text.pdf.PdfCopy = Nothing
        Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing
        Dim pageCount As Integer = 0

        Try
            reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
            pageCount = reader.NumberOfPages
            If pageCount < numOfPages Then
                Throw New ArgumentException("Not enough pages in source pdf to split")
            Else
                Dim ext As String = IO.Path.GetExtension(baseNameOutPdf)
                Dim outfile As String = String.Empty
                Dim n As Integer = CInt(Math.Ceiling(pageCount / numOfPages))
                Dim currentPage As Integer = 1
                For i As Integer = 1 To n
                    outfile = baseNameOutPdf.Replace(ext, "_" & i & ext)
                    doc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(currentPage))
                    pdfCpy = New iTextSharp.text.pdf.PdfCopy(doc, New IO.FileStream(outfile, IO.FileMode.Create))
                    doc.Open()
                    If i < n Then
                        For j As Integer = 1 To numOfPages
                            page = pdfCpy.GetImportedPage(reader, currentPage)
                            pdfCpy.AddPage(page)
                            currentPage += 1
                        Next j
                    Else
                        For j As Integer = currentPage To pageCount
                            page = pdfCpy.GetImportedPage(reader, j)
                            pdfCpy.AddPage(page)
                        Next j
                    End If
                    doc.Close()
                Next
            End If
            reader.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Helper function to convert a csv integer string to an integer array
    ''' </summary>
    ''' <param name="csvNumbers">the integer string in csv format (ex: "1, 5, 7, 4")</param>
    ''' <returns>Integer array converted from the csv string (ex: {1, 5, 7, 4}</returns>
    ''' <remarks>No error checking/handling. If the input string contains non-numeric values
    ''' the function will crash. It's up to you to handle this error.</remarks>
    Private Shared Function ConvertToIntegerArray(ByVal csvNumbers As String) As Integer()
        Dim numbers() As String = csvNumbers.Split(",".ToCharArray, System.StringSplitOptions.RemoveEmptyEntries)
        Dim upperBound As Integer = numbers.Length - 1
        Dim output(upperBound) As Integer
        For i As Integer = 0 To upperBound
            output(i) = Integer.Parse(numbers(i))
        Next
        Return output
    End Function

    Private Shared Sub SetSecurityPasswords(ByVal sourcePdf As String, ByVal outputPdf As String, ByVal userPassword As String, ByVal ownerPassword As String)
        Try
            Dim outStream As New IO.FileStream(outputPdf, IO.FileMode.Create)
            Dim reader As New PdfReader(sourcePdf)
            Dim userPwdBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(userPassword)
            Dim ownerPwdBytes() As Byte = System.Text.Encoding.ASCII.GetBytes(ownerPassword)
            Dim permissions As Integer = PdfWriter.ALLOW_DEGRADED_PRINTING Or PdfWriter.ALLOW_COPY
            PdfEncryptor.Encrypt(reader, outStream, userPwdBytes, ownerPwdBytes, permissions, PdfWriter.STRENGTH128BITS)
            reader.Close()
        Catch ex As Exception
            'Put your own code for exception handling here

        End Try
    End Sub

    ''' <summary>
    ''' Merge multiple pdf files into a single pdf
    ''' </summary>
    ''' <param name="pdfFiles">string array containing full paths to the pdf files to be merged</param>
    ''' <param name="outputPath">full path to the merged output pdf</param>
    ''' <param name="authorName">Author's name.</param>
    ''' <param name="creatorName">Creator's name</param>
    ''' <param name="subject">Subject field</param>
    ''' <param name="title">Title field</param>
    ''' <param name="keywords">keywords field</param>
    ''' <returns>True if the merging is successful, False otherwise.</returns>
    ''' <remarks>All optional paramters are used for the output pdf metadata.
    ''' You can see a pdf metada by going to the PDF tab of the file's Property window.</remarks>
    Public Shared Function MergePdfFiles(ByVal pdfFiles() As String, ByVal outputPath As String, _
                                         Optional ByVal authorName As String = "", _
                                         Optional ByVal creatorName As String = "", _
                                         Optional ByVal subject As String = "", _
                                         Optional ByVal title As String = "", _
                                         Optional ByVal keywords As String = "") As Boolean
        Dim result As Boolean = False
        Dim pdfCount As Integer = 0     'total input pdf file count
        Dim f As Integer = 0            'pointer to current input pdf file
        Dim fileName As String = String.Empty   'current input pdf filename
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim pageCount As Integer = 0    'cureent input pdf page count
        Dim pdfDoc As iTextSharp.text.Document = Nothing    'the output pdf document
        Dim writer As iTextSharp.text.pdf.PdfWriter = Nothing
        Dim cb As iTextSharp.text.pdf.PdfContentByte = Nothing
        'Declare a variable to hold the imported pages
        Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing
        Dim rotation As Integer = 0
        'Declare a font to used for the bookmarks
        Dim bookmarkFont As iTextSharp.text.Font = iTextSharp.text.FontFactory.GetFont(iTextSharp.text.FontFactory.HELVETICA, _
                                                                  12, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLUE)
        Try
            pdfCount = pdfFiles.Length
            If pdfCount > 1 Then
                'Open the 1st pad using PdfReader object
                fileName = pdfFiles(f)
                reader = New iTextSharp.text.pdf.PdfReader(fileName)
                'Get page count
                pageCount = reader.NumberOfPages
                'Instantiate an new instance of pdf document and set its margins. This will be the output pdf.
                'NOTE: bookmarks will be added at the 1st page of very original pdf file using its filename. The location
                'of this bookmark will be placed at the upper left hand corner of the document. So you'll need to adjust
                'the margin left and margin top values such that the bookmark won't overlay on the merged pdf page. The 
                'unit used is "points" (72 points = 1 inch), thus in this example, the bookmarks' location is at 1/4 inch from
                'left and 1/4 inch from top of the page.
                pdfDoc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(1), 18, 18, 18, 18)
                'Instantiate a PdfWriter that listens to the pdf document
                writer = iTextSharp.text.pdf.PdfWriter.GetInstance(pdfDoc, New System.IO.FileStream(outputPath, IO.FileMode.Create))
                'Set metadata and open the document
                With pdfDoc
                    .AddAuthor(authorName)
                    .AddCreationDate()
                    .AddCreator(creatorName)
                    .AddProducer()
                    .AddSubject(subject)
                    .AddTitle(title)
                    .AddKeywords(keywords)
                    .Open()
                End With
                'Instantiate a PdfContentByte object
                cb = writer.DirectContent
                'Now loop thru the input pdfs
                While f < pdfCount
                    'Declare a page counter variable
                    Dim i As Integer = 0
                    'Loop thru the current input pdf's pages starting at page 1
                    While i < pageCount
                        i += 1
                        'Get the input page size
                        pdfDoc.SetPageSize(reader.GetPageSizeWithRotation(i))
                        'Create a new page on the output document
                        pdfDoc.NewPage()
                        'If it is the 1st page, we add bookmarks to the page
                        If i = 1 Then
                            'First create a paragraph using the filename as the heading
                            Dim para As New iTextSharp.text.Paragraph(IO.Path.GetFileName(fileName).ToUpper(), bookmarkFont)
                            'Then create a chapter from the above paragraph
                            Dim chpter As New iTextSharp.text.Chapter(para, f + 1)
                            'Finally add the chapter to the document
                            pdfDoc.Add(chpter)
                        End If
                        'Now we get the imported page
                        page = writer.GetImportedPage(reader, i)
                        'Read the imported page's rotation
                        rotation = reader.GetPageRotation(i)
                        'Then add the imported page to the PdfContentByte object as a template based on the page's rotation
                        If rotation = 90 Then
                            cb.AddTemplate(page, 0, -1.0F, 1.0F, 0, 0, reader.GetPageSizeWithRotation(i).Height)
                        ElseIf rotation = 270 Then
                            cb.AddTemplate(page, 0, 1.0F, -1.0F, 0, reader.GetPageSizeWithRotation(i).Width + 60, -30)
                        Else
                            cb.AddTemplate(page, 1.0F, 0, 0, 1.0F, 0, 0)
                        End If
                    End While
                    'Increment f and read the next input pdf file
                    f += 1
                    If f < pdfCount Then
                        fileName = pdfFiles(f)
                        reader = New iTextSharp.text.pdf.PdfReader(fileName)
                        pageCount = reader.NumberOfPages
                    End If
                End While
                'When all done, we close the document so that the pdfwriter object can write it to the output file
                pdfDoc.Close()
                result = True
            End If
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
        Return result
    End Function

    Public Shared Sub DrawShapesDemo(ByVal sourcePdf As String, ByVal outputPdf As String)
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim stamper As iTextSharp.text.pdf.PdfStamper = Nothing
        Dim cb As iTextSharp.text.pdf.PdfContentByte = Nothing
        Dim rect As iTextSharp.text.Rectangle = Nothing
        Dim pageCount As Integer = 0
        Dim borderColor, fillColor As iTextSharp.text.BaseColor
        Try
            reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
            rect = reader.GetPageSizeWithRotation(1)
            stamper = New iTextSharp.text.pdf.PdfStamper(reader, New System.IO.FileStream(outputPdf, IO.FileMode.Create))
            ' Set up the border and fill color for the shapes to be drawn
            borderColor = iTextSharp.text.BaseColor.BLUE
            fillColor = iTextSharp.text.BaseColor.PINK
            'Loop thru the pages and draw various shapes to their overcontent layer
            pageCount = reader.NumberOfPages()
            For i As Integer = 1 To pageCount
                'Get the undercontent layer of this page
                cb = stamper.GetUnderContent(i)
                '<<< Note: if you want the drawings to appear on top of the contents (covering it)
                ' then you need to get the overcontent layer.
                'cb = stamper.GetOverContent(i)

                'Set the boder color of the shapes
                cb.SetColorStroke(borderColor)
                'Set the fill color of the shapes
                cb.SetColorFill(fillColor)
                'Start drawing shapes. 

                ' >>>> Remember, the cordinate of the LOWER-LEFT corner of a page is (0, 0)
                ' 1 in = 72 units, so a 8.5 x 11 page will have a width of 612 units and a height of 792 units.
                ' Figuring out where to draw your shapes will be much easier if you use a piece of paper to
                ' plot out the cordinates first.

                'Draw a circle centered at (135, 500) with a radius of 50
                cb.Circle(135, 500, 50)
                'Draw an ellipse that fits in a ractangle with (190, 450) as the lower-left corner
                'and (400, 550) as the upper-right corner
                cb.Ellipse(190, 450, 400, 550)
                'Draw a square with the lower-left corner is (410, 450) and the width (and height) = 100
                cb.Rectangle(410, 450, 100, 100)
                'Draw a rounded rectangle
                cb.RoundRectangle(150, 330, 200, 100, 20)
                'Color fill the shapes above
                cb.FillStroke()
                'Draw a line starting from (150, 310) to (450, 310)
                cb.MoveTo(150, 310)
                cb.LineTo(450, 310)
                cb.Stroke()
                'Draw a triangle with vertices (290, 300), (150, 150) and (450, 150) without filling
                cb.MoveTo(290, 300)
                cb.LineTo(150, 150)
                cb.LineTo(450, 150)
                cb.ClosePathStroke()
            Next
            stamper.Close()
            reader.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    ''' <summary>
    ''' Add an image to pdf pages
    ''' </summary>
    ''' <param name="sourcePdf">The full path to the source pdf file</param>
    ''' <param name="outputPdf">The full path to the image file to use</param>
    ''' <param name="imgPath">The full path to be used for the output pdf file</param>
    ''' <param name="imgLocation">The lower left corner location where the image will be placed on a pdf page</param>
    ''' <param name="imgSize">The size of the image on pdf page</param>
    ''' <param name="pages">The pages where the image should be added. Default option is Nothing which will add the image to all pages on the pdf file</param>
    ''' <remarks>Units for location and size are in points. 1 inch = 72 points</remarks>
    Public Shared Sub AddImageToPage(ByVal sourcePdf As String, ByVal outputPdf As String, ByVal imgPath As String, ByVal imgLocation As Point, ByVal imgSize As Size, Optional ByVal pages() As Integer = Nothing)
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim stamper As iTextSharp.text.pdf.PdfStamper = Nothing
        Dim img As iTextSharp.text.Image = Nothing
        Dim cb As iTextSharp.text.pdf.PdfContentByte = Nothing
        Dim pageCount As Integer = 0
        Try
            reader = New iTextSharp.text.pdf.PdfReader(sourcePdf)
            stamper = New iTextSharp.text.pdf.PdfStamper(reader, New System.IO.FileStream(outputPdf, IO.FileMode.Create))
            img = iTextSharp.text.Image.GetInstance(imgPath)
            img.ScaleAbsolute(imgSize.Width, imgSize.Height)
            img.SetAbsolutePosition(imgLocation.X, imgLocation.Y)
            pageCount = reader.NumberOfPages()
            If pages IsNot Nothing Then
                For Each page As Integer In pages
                    If page > 0 AndAlso page <= pageCount Then
                        cb = stamper.GetUnderContent(page)
                        cb.AddImage(img)
                    End If
                Next
            Else
                For i As Integer = 1 To pageCount
                    cb = stamper.GetOverContent(i)
                    cb.AddImage(img)
                Next
            End If
            stamper.Close()
            reader.Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub



End Class
