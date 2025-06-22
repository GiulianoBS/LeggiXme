Imports System.Reflection

Module modVisualizza

    Public interlinea As Integer = 1
    Public spaziatura As Integer = 1
    Public FattoreZoom As Single = 1
    Public blnEffettoLavagna As Boolean = False
    Public AmpiezzaPannelloPDF As Integer = 250
    Public FontPredefinito As Font
    Public ColoreSfondo As Color = Color.White
    Public Risoluzione As Integer = 100

    Public Sub LavagnaRTB(ByVal rtb As RichTextBox)
        If blnEffettoLavagna = True Then
            rtb.ForeColor = Color.White
            rtb.BackColor = Color.Black
            rtb.SelectAll()
            rtb.SelectionBackColor = Color.Black
            rtb.SelectionLength = 0
        Else
            rtb.ForeColor = Color.Black
            rtb.BackColor = ColoreSfondo
            rtb.SelectAll()
            rtb.SelectionBackColor = ColoreSfondo
            rtb.SelectionLength = 0
        End If
    End Sub

    Public Sub EffettoLavagna(ByVal thisForm As System.Windows.Forms.Form)

        For Each thisControl As System.Windows.Forms.Control In thisForm.Controls
            thisControl.BackColor = Color.Black
            If thisControl.BackColor = Color.Black Then
                thisControl.ForeColor = Color.White
            End If
        Next thisControl
        thisForm.BackColor = Color.Black
        thisForm.ForeColor = Color.White

    End Sub

    Public Sub TogliEffettoLavagna(ByVal thisForm As System.Windows.Forms.Form)

        For Each thisControl As System.Windows.Forms.Control In thisForm.Controls
            thisControl.BackColor = ColoreSfondo 'Color.White
            thisControl.ForeColor = Color.Black
        Next thisControl
        thisForm.BackColor = ColoreSfondo 'Color.White
        thisForm.ForeColor = Color.Black

    End Sub

    Public Sub ImpostaCarattere(ByVal rtb As RichTextBox)
        rtb.Font = FontPredefinito
        ImpostaInterlinea(rtb)
        rtb.ZoomFactor = FattoreZoom
        If spaziatura = 2 Then
            Dim t As String = rtb.Text
            rtb.Text = MettiDoppiSpazi(t)
        End If
        LavagnaRTB(rtb)
    End Sub

    Public MisuraPredefinitaFont As Integer = 12

    Public Function CreateFont(ByVal name As String, ByVal style As Drawing.FontStyle, ByVal size As Single, ByVal unit As Drawing.GraphicsUnit) As Drawing.Font

        Dim PFC As Drawing.Text.PrivateFontCollection
        Dim NewFont_FF As Drawing.FontFamily
        'Create a new font collection
        PFC = New Drawing.Text.PrivateFontCollection
        'Add the font file to the new font
        '"name" is the qualified path to your font file
        PFC.AddFontFile(name)
        'Retrieve your new font
        NewFont_FF = PFC.Families(0)

        Return New Drawing.Font(NewFont_FF, size, style, unit)

    End Function

    Public Function AltezzaCaption() As Integer

        Dim t As Type = GetType(System.Windows.Forms.SystemInformation)
        Dim pi As PropertyInfo() = t.GetProperties()
        Dim prop1 As PropertyInfo = Nothing
        Dim i As Integer
        Dim propname1 As String = "CaptionHeight"

        For i = 0 To pi.Length - 1
            If pi(i).Name = propname1 Then
                prop1 = pi(i)
                Exit For
            End If
        Next i

        Dim propval1 As Object = prop1.GetValue(Nothing, Nothing)
        Return CInt(propval1.ToString())

    End Function

    Public Function Capture2text() As String
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim fil As String = Mid(Percorso, 1, i - 1)
        fil = Mid(Percorso, 1, i) & "Capture2text\Capture2text.exe"
        If IO.File.Exists(fil) = False Then
            fil = CartellaLeggiXme() & "\Capture2text\Capture2text.exe"
            If IO.File.Exists(fil) = False Then
                fil = ""
            End If
        End If
        If fil <> "" Then
            fil = Chr(34) + fil + Chr(34)
        End If
        Return fil
    End Function

    Public Function CeZoom() As Boolean
        If IO.File.Exists(Percorso & "\zoom.txt") Then
            Dim f As Integer = FreeFile()
            FileOpen(f, Percorso & "\zoom.txt", OpenMode.Input)
            Dim a As String = LineInput(f)
            Dim r As Integer = CInt(a)
            FileClose(f)
            If r < 100 Then
                Return False
            Else
                Risoluzione = r
                Return True
            End If
        Else
            Return False
        End If

    End Function

End Module