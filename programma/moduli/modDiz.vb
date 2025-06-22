Option Strict Off
Option Explicit On


Module modDiz
    Public Spazi, SpaziInizio As String
    Public SpaziFine As String
    Public NumErrori As Integer
    Public LemmaUtente() As String
    Public NumLemmiUtente As Integer
    Public ParCorretta(200) As String
    Public NumParCorrette As Integer

    Public Const accentate As String = "אטלעשביםףת"
    Public MaxSuggerimenti As Integer = 0

    Public blnApostrofo, blnSpazio As Boolean
    Public blnInvio As Boolean
    Public blnCorreggiMaiuscole As Boolean
    Public xDiz As Integer, yDiz As Integer
    Dim InizioParola As Integer
    Dim FineParola As Integer

    Public DA_A As Integer = 1
    Public blnDallItaliano As Boolean
    Public dizionario As String = "" '  "it_IT" "en_GB" "es_ES" "fr-classique+reforme1990" "de_DE_frami"
    Public DizionarioUtente As String = "" ' "utente_it.diz" "utente_en.diz" "utente_es.diz" "utente_fr.diz" "utente_de.diz"
    Public comando As String = ""
    Public PercorsoDizionario As String = ""
    Public PercorsoOrtografici As String = ""

    Public DaTradurre As String = ""


    Public Sub Init()

        ChDir(My.Application.Info.DirectoryPath)
        Spazi = " .,;:!?([{)]}" & Chr(34) & Chr(10) & Chr(13) & Chr(147) & Chr(148)
        SpaziInizio = " .,;:!?([{'" & Chr(34) & Chr(13) & Chr(10)
        SpaziFine = " .,;:!?)]}" & Chr(34) & Chr(13) & Chr(10)
        PercorsoOrtografici = TrovaPercorsoOrtografici()
    End Sub

    Public Function FormaComando() As String

        Dim TestoInput As String = CartellaTemp & "testo.txt"
        Dim TestoOutput As String = CartellaTemp & "errori.txt"
        FormaComando = "cmd /c hunspell -d " & Chr(34) & dizionario & Chr(34) & " < " & TestoInput & " > " & TestoOutput

    End Function

    Public Sub CercaCorrezione(ByRef parola As String)

        Dim pa, np As String
        Dim l As Short
        Dim k, h As Short
        Dim c() As String

        If parola = "" Then Exit Sub

        'Azzera la matrice
        For k = 1 To NumParCorrette
            ParCorretta(k) = ""
        Next k
        NumParCorrette = 0

        CaricaDizionarioUtente()
        If NumLemmiUtente = 0 Then
            Exit Sub
        End If

        'inizia la ricerca
        pa = parola : l = Len(pa)
        ReDim c(l)

        'tolgo un un carattere
        np = Mid(pa, 2)
        If CeLaParola(np) = True Then
            NumParCorrette = NumParCorrette + 1
            ParCorretta(NumParCorrette) = np
        End If

        np = Left(pa, l - 1)
        If CeLaParola(np) = True Then
            NumParCorrette = NumParCorrette + 1
            ParCorretta(NumParCorrette) = np
        End If

        For k = 2 To l - 1
            np = Left(pa, k - 1) & Mid(pa, k + 1)
            If CeLaParola(np) = True Then
                NumParCorrette = NumParCorrette + 1
                ParCorretta(NumParCorrette) = np
            End If
        Next k

        'inverto 2 caratteri
        For k = 1 To l
            c(k) = Mid(pa, k, 1)
        Next k

        For k = 1 To l - 1
            np = pa
            Mid(np, k, 1) = c(k + 1)
            Mid(np, k + 1) = c(k)
            If CeLaParola(np) = True Then
                NumParCorrette = NumParCorrette + 1
                ParCorretta(NumParCorrette) = np
            End If
        Next k

        'inserisco carattere  da 97 (a) a 122(z)
        For k = 97 To 122
            np = Chr(k) & pa
            If CeLaParola(np) = True Then
                NumParCorrette = NumParCorrette + 1
                ParCorretta(NumParCorrette) = np
            End If
        Next k

        For h = 1 To l - 1
            For k = 97 To 122
                np = Left(pa, h) & Chr(k) & Mid(pa, h + 1)
                If CeLaParola(np) = True Then
                    NumParCorrette = NumParCorrette + 1
                    ParCorretta(NumParCorrette) = np
                End If
            Next k
        Next h

        For k = 97 To 122
            np = pa & Chr(k)
            If CeLaParola(np) = True Then
                NumParCorrette = NumParCorrette + 1
                ParCorretta(NumParCorrette) = np
            End If
        Next k

        For k = 1 To 5
            np = pa & Mid(accentate, k, 1)
            If CeLaParola(np) = True Then
                NumParCorrette = NumParCorrette + 1
                ParCorretta(NumParCorrette) = np
            End If
        Next k

        'sostituisco carattere
        For h = 1 To l
            For k = 97 To 122
                np = pa
                Mid(np, h, 1) = Chr(k)
                If CeLaParola(np) = True Then
                    NumParCorrette = NumParCorrette + 1
                    ParCorretta(NumParCorrette) = np
                End If
            Next k
        Next h

        For k = 1 To 5
            np = pa
            Mid(np, l, 1) = Mid(accentate, k, 1)
            If CeLaParola(np) = True Then
                NumParCorrette = NumParCorrette + 1
                ParCorretta(NumParCorrette) = np
            End If
        Next k

        'elimino voci vuote

        For k = 1 To NumParCorrette
            If ParCorretta(k) = "" Then
                For h = k To NumParCorrette - 1
                    ParCorretta(h) = ParCorretta(h + 1)
                    NumParCorrette = NumParCorrette - 1
                Next h
            End If
        Next k

        ' elimino eventuali doppioni
        For k = 1 To NumParCorrette
            For h = 1 To NumParCorrette
                If k <> h Then
                    If ParCorretta(k) = ParCorretta(h) Then
                        ParCorretta(h) = ""
                    End If
                End If
            Next h
        Next k

    End Sub

    Public Function CeLaParola(ByVal p As String) As Boolean
        Dim ce As Boolean = False
        Dim K As Integer = 0
        For K = 1 To NumLemmiUtente
            If LemmaUtente(K) = p Then
                ce = True
                Exit For
            End If
        Next
        Return ce

    End Function

    Public Sub CaricaDizionarioUtente()

        Dim parola As String = ""
        Dim f As Integer = 0
        Dim diz As String = PercorsoOrtografici & "\" & DizionarioUtente

        NumLemmiUtente = 0
        ReDim Preserve LemmaUtente(NumLemmiUtente)

        f = FreeFile()
        If IO.File.Exists(diz) = False Then
            Exit Sub
        End If

        FileOpen(f, diz, OpenMode.Input)

        Try
            While Not EOF(f)
                parola = LineInput(f)
                If parola <> "" Then
                    NumLemmiUtente += 1
                    ReDim Preserve LemmaUtente(NumLemmiUtente)
                    LemmaUtente(NumLemmiUtente) = parola
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        FileClose(f)

    End Sub

    Public Sub SalvaDizionarioUtente()

        Dim f As Integer = FreeFile()
        Dim k As Integer = 0
        Dim diz As String = PercorsoOrtografici & "\" & DizionarioUtente

        FileOpen(f, diz, OpenMode.Output)
        For k = 0 To NumLemmiUtente
            If LemmaUtente(k) <> "" Then
                PrintLine(f, LemmaUtente(k))
            End If
        Next k
        FileClose(f)

    End Sub

    Public Sub AggiornaDizionarioUtente(ByVal p As String)
        Dim k As Integer
        Dim t As String = ""

        NumLemmiUtente += 1
        ReDim Preserve LemmaUtente(NumLemmiUtente)
        LemmaUtente(NumLemmiUtente) = p
        For k = NumLemmiUtente - 1 To 1 Step -1
            If p > LemmaUtente(k) Then
                Exit For
            Else
                t = LemmaUtente(k)
                LemmaUtente(k + 1) = LemmaUtente(k)
                LemmaUtente(k) = p
            End If
        Next
        SalvaDizionarioUtente()
    End Sub

    Public Function CercaParola(ByRef lemma() As String, ByRef paro As String) As Boolean
        Dim volte As Integer
        Dim k, h As Integer
        Dim par As String
        Dim NumItems As Integer = UBound(lemma)

        If blnCorreggiMaiuscole = False And Maiuscola(paro) = True Then
            CercaParola = True
            Exit Function
        End If

        par = LCase(paro)

        If Right(par, 1) = "ב" Then Mid(par, Len(par), 1) = "א"
        If Right(par, 1) = "י" Then Mid(par, Len(par), 1) = "ט"
        If Right(par, 1) = "ם" Then Mid(par, Len(par), 1) = "ל"
        If Right(par, 1) = "ף" Then Mid(par, Len(par), 1) = "ע"
        If Right(par, 1) = "ת" Then Mid(par, Len(par), 1) = "ש"

        k = Int(System.Math.Log(NumItems) / System.Math.Log(2)) : h = 2 ^ k
        k = h

        Do
            If lemma(h) = par Then
                Return True
                Exit Function
            End If
            volte = volte + 1
            k = k \ 2

            If par < lemma(h) Then
                h = h - k
            Else
                h = h + k
            End If
            If h < 1 Then h = 1
            If h > itm Then
                Do
                    k = k \ 2
                    h = h - k
                Loop While h > itm And k > 0
            End If
        Loop Until k < 1
        Return False
    End Function

    Public Function CeDizionario() As Boolean
        Dim i As Integer = InStrRev(Percorso, "\")
        PercorsoDizionario = Mid(Percorso, 1, i) & "Dizionario" 'CartellaLeggiXme() & "\Dizionario"
        If IO.File.Exists(PercorsoDizionario & "\Dizio.exe") = False Then
            PercorsoDizionario = CartellaLeggiXme() & "\Dizionario" ' Mid(Percorso, 1, i) & "Dizionario"
            If IO.File.Exists(PercorsoDizionario & "\Dizio.exe") = False Then
                PercorsoDizionario = ""
                Return False
            Else
                Return True
            End If
        Else
            Return True
        End If
    End Function

    Public Function TrovaPercorsoOrtografici() As String
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim PO As String = Mid(Percorso, 1, i) & "Ortografici" 'CartellaLeggiXme() & "\Ortografici"
        If IO.Directory.Exists(PO) = False Then
            PO = CartellaLeggiXme() & "\Ortografici" 'Mid(Percorso, 1, i) & "Ortografici"
            If IO.Directory.Exists(PO) = False Then
                PO = ""
            End If
        End If
        Return PO
    End Function

    Public Sub SistemaSelezione(rtb As RichTextBox)
        If rtb.SelectionLength < 1 Then Exit Sub

        Do
            If InStr(SpaziInizio, Mid(rtb.SelectedText, 1, 1)) <> 0 Then
                rtb.SelectionStart += 1
                rtb.SelectionLength -= 1
            Else
                Exit Do
            End If
            If rtb.SelectionLength < 2 Then Exit Sub
        Loop

        Do
            If InStr(SpaziFine, Mid(rtb.SelectedText, rtb.SelectionLength)) <> 0 Then
                rtb.SelectionLength -= 1
            Else
                Exit Do
            End If
            If rtb.SelectionLength < 2 Then Exit Sub
        Loop

    End Sub

End Module