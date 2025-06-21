Imports System.Speech.Synthesis
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports system.speech.recognition


Module VoceSapi5

    WithEvents voce As SpeechSynthesizer


    Public Const Italiano As String = "it-IT"
    Public Const Inglese As String = "en-GB"
    Public Const Francese As String = "fr-FR"
    Public Const Tedesco As String = "de-DE"
    Public Const Spagnolo As String = "es-ES"
    Public Const Cinese As String = "zh-ZH"
    Public Const IngleseUS As String = "en-US"
    Public Lingua(100) As String

    Public PosAttuale As Integer = 0
    Public NomeVoce() As String
    Public NumVoci As Integer = -1
    Public NomeCorto() As String
    Public VoceConEco As Integer = 0
    Public VocePrincipale As Integer = 1
    Public VoceNoEco As Integer = 2
    Public Velocita As Integer = 0
    Public m_bSpeaking, bSpeaking As Boolean
    Public bPaused, m_bPaused As Boolean
    Public blnStoLeggendo As Boolean = False
    Public blnStoLeggendoTraduzione As Boolean = False
    Public zeppa As Integer = 0
    Public inizio As Integer = 0, lungh As Integer = 0

    Public trasforma(2, 0) As String

    Dim blnEco As Boolean = False
    Dim RTB As RichTextBox

    Public blnVoce As Boolean = False
    Public MessaggioErrore As String = ""


    Public Sub InitVoce()
        Try
            voce = New SpeechSynthesizer
        Catch ex As Exception

            MsgBox(ex.Message)
            End
            'MsgBox("La voce non sarà attiva")
            'MessaggioErrore = "Speech Platform non installata" & vbCrLf & "La voce non sarà attiva"
            blnVoce = False
            Exit Sub
            'End
        End Try
        'blnVoce = True
        Try
            For Each v As InstalledVoice In voce.GetInstalledVoices
                NumVoci += 1
                ReDim Preserve NomeVoce(NumVoci)
                ReDim Preserve NomeCorto(NumVoci)
                NomeVoce(NumVoci) = v.VoiceInfo.Name
                NomeCorto(NumVoci) = FaiNomeCorto(NomeVoce(NumVoci)) 'Mid(NomeVoce(NumVoci), 46)
                Lingua(NumVoci) = v.VoiceInfo.Culture.Name
            Next

            voce.SelectVoice(NomeVoce(0))
            voce.TtsVolume = 100
            Try
                voce.SetOutputToDefaultAudioDevice()
            Catch exx As Exception
                Dim a As String = exx.ToString.ToLower
                If InStr(a, "audiodevice") <> 0 Then
                    'MsgBox("Non trovo un dispositivo per l'uscita audio" & vbCrLf & "Il programma verrà chiuso", MsgBoxStyle.Critical)
                    'MsgBox("Non trovo un dispositivo per l'uscita audio", MsgBoxStyle.Critical)
                    MessaggioErrore = "Non trovo un dispositivo per l'uscita audio"
                    'End
                Else
                    'MsgBox(exx.Message)
                    MessaggioErrore = exx.Message
                End If
                'MsgBox("La voce non sarà attiva")
                MessaggioErrore &= vbCrLf & "La voce non sarà attiva"
                blnVoce = False
            End Try

            NomeVocePrincipale = ""
            For k As Integer = 0 To NumVoci
                If Lingua(k) = Italiano Then
                    NomeVocePrincipale = NomeVoce(k)
                    intParlante = k
                End If
            Next
        Catch ex As Exception
            'MsgBox(ex.Message)
            MessaggioErrore = ex.Message
        End Try
        If NumVoci > 0 Then blnVoce = True
        CaricaTrasforma(Percorso & "\it-IT.trs")

        Lex = Percorso & "\it-IT.lex"
        If IO.File.Exists(Lex) Then
            Try
                AggiungiLexicon(Lex)
            Catch ex As Exception
            End Try
        End If

    End Sub

    Public DaTrasformare As Integer = 0

    Sub CaricaTrasforma(ByVal fil As String)
        Dim parola As String = ""
        Dim f As Integer = 0, i As Integer = 0
        DaTrasformare = 0
        ReDim Preserve trasforma(2, DaTrasformare)

        f = FreeFile()
        If IO.File.Exists(fil) = False Then
            Exit Sub
        End If

        FileOpen(f, fil, OpenMode.Input)

        Try
            While Not EOF(f)
                Input(f, parola)
                If parola <> "" Then
                    DaTrasformare += 1
                    ReDim Preserve trasforma(2, DaTrasformare)
                    i = InStr(parola, ":")
                    If i > 0 Then
                        trasforma(0, DaTrasformare) = ":"
                    Else
                        i = InStr(parola, ">")
                        If i > 0 Then
                            trasforma(0, DaTrasformare) = ">"
                        End If
                    End If
                    If i > 0 Then
                        trasforma(1, DaTrasformare) = Mid(parola, 1, i - 1)
                        trasforma(2, DaTrasformare) = Mid(parola, i + 1)
                    Else
                        DaTrasformare -= 1
                        ReDim Preserve trasforma(2, DaTrasformare)
                        Exit While
                    End If
                End If
            End While
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        FileClose(f)
    End Sub

    Public Sub ChiudiVoce()
        TogliLexicon(Lexicon)
        FermaVoce()
        Try
            voce = Nothing
        Catch ex As Exception
        End Try
    End Sub

    Function FaiNomeCorto(ByVal t As String) As String
        Dim nc As String = Mid(t, InStr(t, ",") + 1)
        Dim lin As String = Mid(t, 47, 5)
        nc = "Microsoft " & nc & lin
        nc = nc.Replace(")", "-")
        Return nc
    End Function

    Public Sub SalvaAudio(ByVal t As String, ByVal nf As String)

        If blnVoce = False Then Exit Sub
        Dim voceRec As New SpeechSynthesizer

        voceRec.SetOutputToWaveFile(nf)
        voceRec.SelectVoice(NomeVoce(intParlante))
        voceRec.TtsVolume = 100
        voceRec.Rate = Velocita

        Dim sp As New System.Media.SoundPlayer
        Try
            voceRec.Speak(PulisciTesto(t))
            sp.Play()
        Catch ex As Exception

        End Try
        sp.Dispose()
        sp = Nothing
        voceRec.Dispose()
        voceRec = Nothing
    End Sub

    Public Sub ConEco(ByVal tb As RichTextBox, ByVal t As String, Optional ByVal v As Integer = -1)
        If blnVoce = True Then
            blnStoLeggendo = True
            Eco(tb, t, v)
        End If
    End Sub

    Private Sub Eco(ByVal tb As RichTextBox, ByVal t As String, Optional ByVal v As Integer = -1)
        If blnVoce = False Then Exit Sub
        FermaVoce()
        If t = "" Then Exit Sub

        blnEco = True
        If v = -1 Then v = intParlante
        Try
            voce.SelectVoice(NomeVoce(v))
            voce.Rate = Velocita
            RTB = tb
            'If t = "" Then t = RTB.Text
            RTB.Focus()
            'voce.SetOutputToDefaultAudioDevice()
            blnStoLeggendo = True
            voce.SpeakAsync(PulisciTesto(t))
        Catch ex As Exception
            'MsgBox(NomeVoce(intParlante))
        End Try
    End Sub

    Public Sub LeggiMessaggi(ByVal t As String)
        If blnVoce = False Then Exit Sub
        Sincrono(PulisciTesto(t))
    End Sub

    Public Sub LeggiLaTraduzione(ByVal t As String)
        If blnVoce = False Then Exit Sub
        FermaVoce()
        blnEco = False
        voce.SelectVoice(NomeVocePrincipale)
        voce.Rate = Velocita
        Try
            voce.SetOutputToDefaultAudioDevice()
            blnStoLeggendo = True
            voce.SpeakAsync(PulisciTesto(t))
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SenzaEco(ByVal t As String)
        If blnVoce = True Then
            SenzEco(t)
        End If
    End Sub

    Private Sub SenzEco(ByVal t As String)
        If blnVoce = False Then Exit Sub
        FermaVoce()
        blnEco = False
        voce.SelectVoice(NomeVoce(intParlante))
        voce.Rate = Velocita
        Try
            voce.SetOutputToDefaultAudioDevice()
            blnStoLeggendo = True
            voce.SpeakAsync(PulisciTesto(t))
        Catch ex As Exception
        End Try
    End Sub

    Public Sub Sincrono(ByVal t As String)
        If blnVoce = True Then Sincr(t)
    End Sub

    Private Sub Sincr(ByVal t As String)
        If blnVoce = False Then Exit Sub
        FermaVoce()
        blnEco = False
        voce.SelectVoice(NomeVocePrincipale)
        voce.Rate = Velocita
        Try
            voce.SetOutputToDefaultAudioDevice()
        Catch ex As Exception
        End Try

        Try
            blnStoLeggendo = True
            voce.Speak(PulisciTesto(t))
        Catch ex As Exception

        End Try
    End Sub

    Private Function PulisciTesto(ByVal t As String) As String

        If DaTrasformare = 0 Then
            Return t
            Exit Function
        End If

        Dim tt As String = LCase(t)
        Dim l As Integer = 1, i As Integer = 1, lun As Integer = 0

        For l = 1 To DaTrasformare
            If trasforma(0, l) = ":" Then
                i = 1
                Do
                    i = InStr(i, tt, trasforma(1, l))
                    If i = 0 Then Exit Do
                    lun = Len(trasforma(1, l))
                    If eUnaParola(tt, i, lun) Then
                        tt = Mid(tt, 1, i - 1) & trasforma(2, l) & Mid(tt, i + lun)
                    End If
                    If i < Len(tt) Then
                        i += 1
                    Else
                        Exit Do
                    End If
                Loop
            Else
                tt = tt.Replace(trasforma(1, l), trasforma(2, l))
            End If
        Next

        Return tt

    End Function

    Private Sub voce0_SpeakCompleted(ByVal sender As Object, ByVal e As SpeakCompletedEventArgs) Handles voce.SpeakCompleted
        If blnVoce = False Then Exit Sub
        If blnEco = False Then Exit Sub
        Try
            RTB.SelectionStart = PosAttuale + zeppa
            RTB.SelectionLength = 0
            If blnEco = True Then
                blnEco = False
                RTB.Focus()
                If lungh <> 0 Then
                    RTB.SelectionStart = inizio
                    RTB.SelectionLength = lungh
                End If
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub voce0_SpeakProgress(ByVal sender As Object, ByVal e As SpeakProgressEventArgs) Handles voce.SpeakProgress
        'e.CharacterPosition, e.CharacterCount, e.AudioPosition, e.Text
        If blnVoce = False Then Exit Sub
        If blnEco = False Then Exit Sub
        Try
            RTB.SelectionStart = e.CharacterPosition + zeppa
            RTB.SelectionLength = e.CharacterCount
            PosAttuale = e.CharacterPosition + RTB.SelectionLength
        Catch ex As Exception
        End Try
    End Sub

    Public Sub FermaVoce()
        If blnVoce = True Then StopVoce()
    End Sub

    Private Sub StopVoce()
        Try
            If VoceInPausa() Then voce.Resume()
            voce.SpeakAsyncCancelAll()
            blnStoLeggendo = False
            SetSpeakingState(False, False)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub Pausa()
        If blnVoce = True Then PausaP()
    End Sub

    Private Sub PausaP()
        If VoceZitta() = True Then Exit Sub
        If voce.State = SynthesizerState.Speaking Then
            voce.Pause()
            SetSpeakingState(False, True)
            If blnEco Then
                RTB.SelectionLength = 0
                RTB.Refresh()
                RTB.Focus()
            End If
        Else
            voce.Resume()
            SetSpeakingState(True, False)
        End If

    End Sub

    Public Sub Riprendi()
        If blnVoce = True Then RiprendiP()
    End Sub

    Private Sub RiprendiP()
        If voce.State = SynthesizerState.Paused Then
            voce.Resume()
        End If
    End Sub

    Public Sub RegolaVelocita()
        If blnVoce = True Then RegolaLaVelocita()
    End Sub

    Public Sub RegolaLaVelocita()
        voce.Rate = Velocita
    End Sub

    Public Sub AumentaVelocita()
        If blnVoce = False Then Exit Sub
        If Velocita < 8 Then
            Velocita += 1
            RegolaVelocita()
        End If
    End Sub

    Public Sub DiminuisciVelocita()
        If blnVoce = False Then Exit Sub
        If Velocita > -10 Then
            Velocita -= 1
            RegolaVelocita()
        End If
    End Sub

    Public Sub SetSpeakingState(ByVal bSpeaking As Boolean, ByVal bPaused As Boolean)
        If blnVoce = False Then Exit Sub
        m_bSpeaking = bSpeaking
        m_bPaused = bPaused
    End Sub

    Public Function VoceInPausa() As Boolean
        If blnVoce = False Then Exit Function
        Return voce.State = SynthesizerState.Paused
    End Function

    Public Function VoceStaParlando() As Boolean
        If blnVoce = False Then
            Return False
        Else
            Return StaParlando()
        End If
    End Function

    Private Function StaParlando() As Boolean
        Return voce.State = SynthesizerState.Speaking
    End Function

    Public Function VoceZitta() As Boolean
        If blnVoce = False Then
            Return True
        Else
            Return StoZitta()
        End If
    End Function

    Private Function StoZitta() As Boolean
        Return voce.State = SynthesizerState.Ready
    End Function

    Public Function ConvertiMinuscole(ByVal tt As String) As String
        tt = StrConv(LCase(tt), VbStrConv.ProperCase)
        'tt = tt.Replace("dislessia", "dislessìa")
        Return tt
    End Function

    Private Sub voce0_SpeakStarted(ByVal sender As Object, ByVal e As Microsoft.Speech.Synthesis.SpeakStartedEventArgs) Handles voce.SpeakStarted
        If blnVoce = False Then Exit Sub
        Try
            RTB.Focus()
        Catch ex As Exception

        End Try
    End Sub

    Dim Maschera As String = "##,###"

    Private Function InCifre(ByVal n As String) As String
        If n <> "0" Then
            n = Format(Val(n), Maschera)
        End If
        Return n.Replace(",", ".")
    End Function

    Private Function Decimali(ByVal n As String) As String
        Dim t As String = "", i As Integer = 0
        If Len(n) > 3 Then
            For i = 1 To Len(n)
                t &= Mid(n, i, 1) + " "
            Next
        Else
            t = n
        End If
        Return t
    End Function

    Public Function FormattaNumero(ByVal n As String) As String

        n = n.Replace(".", "")
        n = n.Replace(",", ".")

        Dim i As Integer = InStr(n, ".")
        Dim Formattato As String = ""
        If i = 0 Then
            Formattato = InCifre(n)
        Else
            Try
                Formattato = InCifre(Mid(n, 1, i - 1)) & "," & Decimali(Mid(n, i + 1))
            Catch ex As Exception

            End Try
        End If
        Return Formattato
    End Function

    Public Function ConvertiInLettere(ByVal n As String) As String
        'Dim n As String = numero.Replace(".", "")
        Dim i As Integer = InStr(n, ",")
        If i = 0 Then
            Return NumeroInLettere(n)
        Else
            Return NumeroInLettere(Mid(n, 1, i - 1)) & " virgola " & NumeroInLettere(Mid(n, i + 1))
        End If
    End Function

    Private Function NumeroInLettere(ByVal n As String) As String

        Dim numero As Double = Val(n)
        If numero = 0 Then
            Return "Zero"
            Exit Function
        End If

        Dim Frazione1, Frazione2, Frazione3, Esp As Integer
        Dim InLettere As String = ""
        Dim Temp As Double
        Static Cifra(28) As String
        Cifra(1) = "zero "
        Cifra(2) = "uno "
        Cifra(3) = "due "
        Cifra(4) = "tre "
        Cifra(5) = "quattro "
        Cifra(6) = "cinque "
        Cifra(7) = "sei "
        Cifra(8) = "sette "
        Cifra(9) = "otto "
        Cifra(10) = "nove "
        Cifra(11) = "dieci "
        Cifra(12) = "undici "
        Cifra(13) = "dodici "
        Cifra(14) = "tredici "
        Cifra(15) = "quattordici "
        Cifra(16) = "quindici "
        Cifra(17) = "sedici "
        Cifra(18) = "diciassette "
        Cifra(19) = "diciotto "
        Cifra(20) = "diciannove "
        Cifra(21) = "venti "
        Cifra(22) = "trenta "
        Cifra(23) = "quaranta "
        Cifra(24) = "cinquanta "
        Cifra(25) = "sessanta "
        Cifra(26) = "settanta "
        Cifra(27) = "ottanta "
        Cifra(28) = "novanta "

        For Esp = 3 To 0 Step -1
            Temp = numero / 1000 ^ Esp
            Frazione1 = Int(Temp)
            If Frazione1 > 0 Then
                Frazione2 = Frazione1
                If Frazione2 > 99 Then
                    Temp = Frazione2 / 100
                    Frazione3 = Int(Temp)
                    Frazione2 = Frazione2 - Frazione3 * 100
                    If Frazione3 = 1 Then
                        InLettere = InLettere + "cento "
                    Else
                        InLettere = InLettere + Cifra(Frazione3 + 1) + "cento "
                    End If
                End If
                If Frazione2 <= 20 Then
                    InLettere = InLettere + Cifra(Frazione2 + 1)
                Else
                    Temp = Frazione2 / 10
                    Frazione3 = Int(Temp)
                    InLettere = InLettere + Cifra(Frazione3 + 19)
                    Frazione2 = Frazione2 - Frazione3 * 10
                    If Frazione2 = 1 Or Frazione2 = 8 Then
                        InLettere = Mid(InLettere, 1, Len(InLettere) - 2)
                    End If
                    InLettere = InLettere + Cifra(Frazione2 + 1)
                End If
                Select Case Esp
                    Case 1
                        If Frazione1 = 1 Then
                            InLettere = Mid(InLettere, 1, Len(InLettere) - 3) + "mille "
                        Else
                            InLettere = InLettere + "mila "
                        End If
                    Case 2
                        If Frazione1 = 1 Then
                            InLettere = Mid(InLettere, 1, Len(InLettere) - 3) + "un milione "
                        Else
                            InLettere = InLettere + "milioni "
                        End If
                    Case 3
                        If Frazione1 = 1 Then
                            InLettere = "un miliardo "
                        Else
                            InLettere = InLettere + "miliardi "
                        End If
                End Select
                numero = numero - Frazione1 * 1000 ^ Esp
            End If
        Next
        Return InLettere
    End Function

    Public Lex As String = ""
    Public Lexicon As Uri 'New Uri(Lex)

    Public Sub AggiungiLexicon(ByVal l As String)
        If blnVoce = True Then AggiungiIlLexicon(l)
    End Sub

    Private Sub AggiungiIlLexicon(ByVal l As String)
        'voce.AddLexicon(New Uri(Percorso & "\nun.pls"), "application/pls+xml")
        'Exit Sub
        If IO.File.Exists(l) = False Then
            MsgBox("Lexicon " & l.ToString & " non trovato", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Lexicon = New Uri(l)
        Try
            voce.AddLexicon(Lexicon, "application/pls+xml")
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Public Sub TogliLexicon(ByVal l As Uri)
        If blnVoce = True Then TogliIlLexicon(l)
    End Sub

    Private Sub TogliIlLexicon(ByVal l As Uri)
        Try
            voce.RemoveLexicon(l)
        Catch ex As Exception
        End Try
    End Sub

End Module
