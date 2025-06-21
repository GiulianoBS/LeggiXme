Option Strict Off

Module modGestisciImmagini

    Public PercorsoClipart As String = ""

    Sub RidimensionaImmagineInClipboard(Optional ByVal mis As Integer = 240)

        Dim bm As New Bitmap(Clipboard.GetImage)
        Dim x As Int32 = bm.Width 'variable for new width size
        Dim y As Int32 = bm.Height 'variable for new height size
        Dim MaxMisura As Integer = mis


        If x < MaxMisura Then
            bm.Dispose()
            Exit Sub
        End If

        Try
            Dim height As Integer = CInt(MaxMisura / (CSng(x) / CSng(y)))
            Dim width As Integer = MaxMisura

            Dim thumb As New Bitmap(width, height)
            Dim g As Graphics = Graphics.FromImage(thumb)

            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel)
            g.Dispose()

            Clipboard.SetImage(thumb)

            thumb.Dispose()

        Catch ex As Exception

        End Try

        bm.Dispose()

    End Sub


    Sub RidimensionaImmagine(ByVal RTB As RichTextBox, ByVal effetto As Integer)

        Dim n As Integer = RTB.SelectionStart

        RTB.Copy()
        Dim bm As Bitmap
        Try
            bm = New Bitmap(Clipboard.GetImage)
        Catch ex As Exception
            Exit Sub
        End Try

        Dim x As Int32 = bm.Width
        Dim y As Int32 = bm.Height


        If ((x < 11 Or y < 11) And effetto = -1) Or ((x > 640 Or y > 640) And effetto = 1) Then
            bm.Dispose()
            Exit Sub
        End If

        Dim MaxMisura As Integer = 0
        If effetto = -1 Then
            MaxMisura = x - 10
        Else
            MaxMisura = x + 10
        End If

        Dim height As Integer = CInt(MaxMisura / (CSng(x) / CSng(y)))
        Dim width As Integer = MaxMisura

        Dim thumb As New Bitmap(width, height)
        Dim g As Graphics = Graphics.FromImage(thumb)

        g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
        g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel)
        g.Dispose()
        Try
            Clipboard.SetImage(thumb)
        Catch ex As Exception
        End Try

        bm.Dispose()
        thumb.Dispose()
        RTB.Paste()
        RTB.Select(n, 1)

    End Sub

    Sub CreaPercorsoClipart()
        Dim i As Integer = InStrRev(Percorso, "\")
        PercorsoClipart = Mid(Percorso, 1, i) & "Immagini" 'CartellaLeggiXme() & "\Immagini"
        If IO.Directory.Exists(PercorsoClipart) = False Then
            PercorsoClipart = CartellaLeggiXme() & "\Immagini" 'Mid(Percorso, 1, i) & "Immagini"
            If IO.Directory.Exists(PercorsoClipart) = False Then
                PercorsoClipart = ""
            End If
        End If
    End Sub

    Sub RidimensionaInClipboard()

        If Risoluzione = 100 Then Exit Sub

        Dim bm As New Bitmap(Clipboard.GetImage)
        Dim x As Int32 = bm.Width 'variable for new width size
        Dim y As Int32 = bm.Height 'variable for new height size

        Try
            Dim width As Integer = bm.Width * 100 \ Risoluzione
            Dim height As Integer = bm.Height * 100 \ Risoluzione

            Dim thumb As New Bitmap(width, height)
            Dim g As Graphics = Graphics.FromImage(thumb)

            g.InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            g.DrawImage(bm, New Rectangle(0, 0, width, height), New Rectangle(0, 0, bm.Width, bm.Height), GraphicsUnit.Pixel)
            g.Dispose()
            Clipboard.SetImage(thumb)
            thumb.Dispose()

        Catch ex As Exception

        End Try

        bm.Dispose()

    End Sub

End Module


