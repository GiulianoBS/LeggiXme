Option Strict Off
Option Explicit On
Module modSinonimi
    'Public Spazi, SpaziInizio As String
    'Public SpaziFine As String
    Public itm, NParola As Integer
    Public QuantiSinonimi As Short
    Public Sinonimi(30) As String
    Public LemmaSinonimi(160000, 40) As String
    Public Sinon(160000) As String
    Public NVoci(160000) As Short
    Public SpostIniziale As Integer
    Public LunghezzaEffettiva As Short
    Dim InizioParola As Integer
    Dim FineParola As Integer
    Public DizSinonimi As String = "" ' "thes_fr.txt" "th_it_IT.txt" "th_en_GB_final.txt" "th_es_ES_v2.txt" "th_de_DE_v2.txt"
    Public DizionarioCaricato As String = ""
    Public DifferenzaLunghezza As Integer
    Public ParolaSostitutiva As String
    Public blnEsci As Boolean
    Public ParolaGlossario As String = ""
    Dim VerbiIrregolari() As String
    Dim verbo() As String


    Public Function TrovaParolaIrregolari(ByVal p As String) As String
        Dim i As Integer = -1, a As String = ""
        i = Array.IndexOf(VerbiIrregolari, p)
        If i > -1 Then
            a = verbo(i)
        End If
        Return a
    End Function

    Public Sub CaricaVerbiIrregolari()

        If IO.File.Exists(My.Application.Info.DirectoryPath & "\irregolari.txt") = False Then Exit Sub

        Dim parola As String = ""
        Dim f As Integer
        Dim lett As String
        Dim i As Integer = 0, nv As Integer = 0, conta As Integer = 0
        Dim infinito As String = ""
        Dim index As Integer = 0

        f = FreeFile()
        lett = My.Application.Info.DirectoryPath & "\irregolari.txt"

        FileOpen(f, lett, OpenMode.Input)

        Input(f, parola)

        While Not EOF(f)
            Input(f, parola)
            parola = Mid(parola, 2)
            If parola = "" Then
                If EOF(f) Then Exit While
                Input(f, parola)
                parola = Mid(parola, 2)
                infinito = parola
            Else
                i = InStr(parola, "/")
                If i = 0 Then
                    ReDim Preserve VerbiIrregolari(nv)
                    VerbiIrregolari(nv) = parola & " " & infinito
                    nv += 1
                Else
                    parola = Mid(parola, 1, i - 2)
                    ReDim Preserve VerbiIrregolari(nv)
                    VerbiIrregolari(nv) = parola & "a" & " " & infinito
                    nv += 1
                    ReDim Preserve VerbiIrregolari(nv)
                    VerbiIrregolari(nv) = parola & "e" & " " & infinito
                    nv += 1
                    ReDim Preserve VerbiIrregolari(nv)
                    VerbiIrregolari(nv) = parola & "i" & " " & infinito
                    nv += 1
                    ReDim Preserve VerbiIrregolari(nv)
                    VerbiIrregolari(nv) = parola & "o" & " " & infinito
                    nv += 1
                End If
            End If
        End While
        FileClose(f)
        nv -= 1


        ReDim verbo(nv)
        Dim t As String = ""

        For conta = 0 To nv
            t = VerbiIrregolari(conta)
            i = InStr(t, " ")
            verbo(conta) = Mid(t, i + 1)
            VerbiIrregolari(conta) = Mid(t, 1, i - 1)
        Next

    End Sub


    Function Maiuscola(ByRef p As String) As Boolean
        Dim a As Short
        a = Asc(p)
        If a > 63 And a < 91 Then
            Maiuscola = True
        Else
            Maiuscola = False
        End If
    End Function

    Public Function CercaParola(ByRef paro As String) As Integer
        Dim volte As Integer = 0
        Dim k As Integer = 0
        Dim h As Integer = 0
        'Dim tr As INTEGER
        Dim par As String
        CercaParola = 0

        par = LCase(paro)
        Select Case Lingua(intParlante)
            Case Italiano
                If Right(par, 1) = "á" Then Mid(par, Len(par), 1) = "à"
                If Right(par, 1) = "é" Then Mid(par, Len(par), 1) = "è"
                If Right(par, 1) = "í" Then Mid(par, Len(par), 1) = "ì"
                If Right(par, 1) = "ó" Then Mid(par, Len(par), 1) = "ò"
                If Right(par, 1) = "ú" Then Mid(par, Len(par), 1) = "ù"
            Case Spagnolo
                If Right(par, 1) = "à" Then Mid(par, Len(par), 1) = "á"
                If Right(par, 1) = "è" Then Mid(par, Len(par), 1) = "é"
                If Right(par, 1) = "ì" Then Mid(par, Len(par), 1) = "í"
                If Right(par, 1) = "ò" Then Mid(par, Len(par), 1) = "ó"
                If Right(par, 1) = "ù" Then Mid(par, Len(par), 1) = "ú"
            Case Else
        End Select

        Dim i As Integer = Array.IndexOf(Sinon, par)
        CercaParola = i

        Exit Function

        k = Int(System.Math.Log(itm) / System.Math.Log(2)) : h = 2 ^ k
        k = h

        Do
            If LemmaSinonimi(h, 0) = par Then
                CercaParola = h
                Exit Function
            End If
            volte = volte + 1
            k = k \ 2
            If par < LemmaSinonimi(h, 0) Then
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

    End Function

    Private Sub CaricaDizionario()
        Dim parola As String = ""
        Dim f As Integer = 0
        Dim k As Short
        Dim diz As String
        Dim h As Short

        itm = 0
        f = FreeFile()
        diz = PercorsoOrtografici & "\" & DizSinonimi
        FileOpen(f, diz, OpenMode.Input)

        Try
            Input(f, parola)
            While Not EOF(f)
                parola = LineInput(f)
                If parola <> "" Then
                    itm = itm + 1
                    h = InStr(parola, "|")
                    k = CShort(Mid(parola, h + 1))
                    NVoci(itm) = k
                    If k > 40 Then NVoci(itm) = 40
                    LemmaSinonimi(itm, 0) = Trim(Left(parola, h - 1))
                    Sinon(itm) = LemmaSinonimi(itm, 0)
                    For h = 1 To k
                        parola = LineInput(f)
                        If h < 41 Then
                            LemmaSinonimi(itm, h) = Trim(parola)
                        End If

                    Next h
                End If

            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        FileClose(f)
        DizionarioCaricato = DizSinonimi

    End Sub

    Public Function PulisciParola(ByRef wd As String) As String
        Dim l As Short = 0
        Dim tmp As String

        PulisciParola = wd
        tmp = wd
        SpostIniziale = 0
        Do
            If InStr(SpaziInizio, Left(tmp, 1)) = 0 Then Exit Do
            If Len(tmp) < 2 Then Exit Do
            tmp = Mid(tmp, 2)
            SpostIniziale = SpostIniziale + 1
        Loop
        Do
            If InStr(SpaziFine, Right(tmp, 1)) = 0 Then Exit Do
            If Len(tmp) < 2 Then Exit Do
            tmp = Left(tmp, Len(tmp) - 1)
        Loop
        LunghezzaEffettiva = Len(tmp)
        PulisciParola = tmp
    End Function

    Function TrovaFine(ByRef i As Integer, ByRef t As String) As Integer
        Dim blnInvio As Boolean
        Dim blnSpazio As Boolean
        Dim blnApostrofo As Boolean
        Dim fine As Integer
        Dim f2 As Integer
        Dim k As Short

        fine = Len(t)
        blnApostrofo = False
        blnSpazio = False
        blnInvio = False
        For k = 1 To Len(Spazi)
            f2 = InStr(i, t, Mid(Spazi, k, 1))
            If f2 > 0 And f2 < fine Then
                fine = f2

                If k = 1 Then
                    blnSpazio = True
                    blnApostrofo = False
                Else
                    blnSpazio = False
                End If

                If k = 14 Then
                    blnApostrofo = True
                    blnSpazio = False
                Else
                    blnApostrofo = False
                End If
            End If
        Next k
        If Mid(t, fine, 1) = Chr(13) Then
            fine = fine + 1
            blnInvio = True
        End If
        TrovaFine = fine
    End Function

    Public Function tipo(ByRef p As String) As String
        Dim k As Short
        k = InStr(p, "|")
        tipo = Left(p, k - 1)

    End Function

    Public Sub TrovaSinonimi(ByRef p As String, ByRef lst As System.Windows.Forms.ListBox)
        Dim k As Integer
        Dim h As Short
        Dim tp As String

        On Error GoTo Esci
        lst.Items.Clear()
        tp = Mid(p, InStr(p, "|") + 1)
        Do
            k = InStr(tp, "|")
            If k = 0 Then Exit Do
            lst.Items.Add(Left(tp, k - 1))
            tp = Mid(tp, k + 1)
        Loop
        lst.Items.Add(tp)

Esci:
    End Sub

    Public Function FormaComandoSinonimi() As String

        Dim TestoInput As String = CartellaTemp & "testo.txt"
        Dim TestoOutput As String = CartellaTemp & "errori.txt"
        Return "cmd /c hunspell -d " & Chr(34) & dizionario & Chr(34) & " -s < " & TestoInput & " > " & TestoOutput

    End Function

    Private Function TrovaParolaBase(ByVal p As String) As String
        Dim comando As String = FormaComandoSinonimi()
        Dim ProcID As Integer = 0
        My.Computer.FileSystem.WriteAllText(CartellaTemp & "\testo.txt", p, False, System.Text.Encoding.GetEncoding(28605))
        ProcID = Shell(comando, AppWinStyle.Hide, Wait:=True)

        Dim parola As String = ""
        Dim lett As String
        Dim i As Integer = 0, k As Integer = 0, h As Integer = 0
        Dim inizio As Integer = 0, fine As Integer = 0

        Dim f As Integer = FreeFile()
        lett = CartellaTemp & "errori.txt"
        Try
            FileOpen(f, lett, OpenMode.Input)
            parola = LineInput(f)
        Catch ex As Exception
        End Try
        FileClose(f)
        If Len(parola) = 0 Then
            Return p
            Exit Function
        End If
        i = InStr(parola, " ")
        If i = 0 Then
            Return p
        Else
            Return Trim(Mid(parola, i + 1))
        End If

    End Function

    Public Sub MostraSinonimi(ByVal prl As String)
        Dim z As Short
        Dim DaCercare As String = LCase(prl)
        Dim ParolaDaCercare As String = DaCercare

        If DizionarioCaricato <> DizSinonimi Then CaricaDizionario()

        NParola = CercaParola(ParolaDaCercare)

        Dim c As String = ParolaDaCercare

        If NParola = -1 Then

            If Lingua(intParlante) = Italiano Then
                If ParolaDaCercare <> "" And ParolaDaCercare <> "*" Then
                    Dim finale As String = Mid(DaCercare, Len(DaCercare), 1)
                    If finale = "i" Then
                        Mid(ParolaDaCercare, Len(ParolaDaCercare)) = "o"
                        NParola = CercaParola(ParolaDaCercare)
                        If NParola = -1 Then
                            Mid(ParolaDaCercare, Len(ParolaDaCercare)) = "e"
                            NParola = CercaParola(ParolaDaCercare)
                        End If
                    ElseIf finale = "e" Then
                        Mid(ParolaDaCercare, Len(ParolaDaCercare)) = "a"
                        NParola = CercaParola(ParolaDaCercare)
                    End If
                End If
            End If

            If NParola = -1 Then
                ParolaDaCercare = TrovaParolaBase(DaCercare)
                NParola = CercaParola(ParolaDaCercare)
            End If

            If NParola = -1 Then
                ParolaDaCercare = TrovaRadice(DaCercare)
                NParola = CercaParola(ParolaDaCercare)
            End If
        End If

        With frmSinonimi
            .txtDaCercare.Text = ParolaDaCercare
            .lsSignificati.Items.Clear()
            .lstSuggerimenti.Items.Clear()

            If NParola = -1 Then ' NParola=0
                MsgBox(DaCercare & " non trovata")
                .txtDaCercare.Text = prl
            Else
                For z = 1 To NVoci(NParola)
                    .lsSignificati.Items.Add(tipo(LemmaSinonimi(NParola, z)))
                Next z
                .lsSignificati.SelectedIndex = 0
            End If
            .ShowDialog()

            If ParolaSostitutiva <> "" Then
                frmLeggiConMe.RTB.SelectedText = ParolaSostitutiva
                FineParola = FineParola + DifferenzaLunghezza
            End If
        End With

    End Sub

    Public Sub MostraSinonimi2(ByVal prl As String)
        Dim z As Short
        Dim DaCercare As String = LCase(prl)
        Dim ParolaDaCercare As String = DaCercare

        NParola = CercaParola(ParolaDaCercare)

        Dim c As String = ParolaDaCercare

        If NParola = -1 Then

            If Lingua(intParlante) = Italiano Then
                If ParolaDaCercare <> "" And ParolaDaCercare <> "*" Then
                    Dim finale As String = Mid(DaCercare, Len(DaCercare), 1)
                    If finale = "i" Then
                        Mid(ParolaDaCercare, Len(ParolaDaCercare)) = "o"
                        NParola = CercaParola(ParolaDaCercare)
                        If NParola = -1 Then
                            Mid(ParolaDaCercare, Len(ParolaDaCercare)) = "e"
                            NParola = CercaParola(ParolaDaCercare)
                        End If
                    ElseIf finale = "e" Then
                        Mid(ParolaDaCercare, Len(ParolaDaCercare)) = "a"
                        NParola = CercaParola(ParolaDaCercare)
                    End If
                End If
            End If

            If NParola = -1 Then
                ParolaDaCercare = TrovaParolaBase(DaCercare)
                NParola = CercaParola(ParolaDaCercare)
            End If

            If NParola = -1 Then
                ParolaDaCercare = TrovaRadice(DaCercare)
                NParola = CercaParola(ParolaDaCercare)
            End If
        End If

        With frmSinonimi
            .txtDaCercare.Text = ParolaDaCercare
            .lsSignificati.Items.Clear()
            .lstSuggerimenti.Items.Clear()
            If NParola = -1 Then
                MsgBox(DaCercare & " non trovata")
            Else
                For z = 1 To NVoci(NParola)
                    .lsSignificati.Items.Add(tipo(LemmaSinonimi(NParola, z)))
                Next z
                .lsSignificati.SelectedIndex = 0
            End If

            If ParolaSostitutiva <> "" Then
                frmLeggiConMe.RTB.SelectedText = ParolaSostitutiva
                FineParola = FineParola + DifferenzaLunghezza
            End If
        End With


    End Sub

    Public Function TrovaRadice(ByVal P As String) As String
        Dim i As Integer = 0, k As Integer = 0, h As Integer = 0
        Dim ProcID As Integer = 0
        Dim parola As String = ""
        TrovaRadice = ""

        My.Computer.FileSystem.WriteAllText(CartellaTemp & "testo.txt", P, False, System.Text.Encoding.GetEncoding(28605))

        ProcID = Shell(FormaComando, AppWinStyle.Hide, Wait:=True)
        NumErrori = 0
        'On Error GoTo Esci
        Dim f As Integer = FreeFile()
        'Dim lett As String = "errori.txt"
        Dim lett As String = CartellaTemp & "errori.txt"
        FileOpen(f, lett, OpenMode.Input)

        parola = LineInput(f)
        parola = LineInput(f) ' mi interessa la 2° riga
        FileClose(f)
        If parola <> "" Then
            If Asc(parola) = 43 Then
                TrovaRadice = Mid(parola, 3)
            End If
        End If

        Exit Function
Esci:

        FileClose(f)
        TrovaRadice = "*"

    End Function

End Module