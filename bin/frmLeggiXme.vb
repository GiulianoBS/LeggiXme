Option Strict On
Option Explicit On
'Imports System.Diagnostics.Process
Imports System.Reflection
Imports System.Speech.Synthesis
Imports System.Collections.ObjectModel
Imports System.Text.RegularExpressions
Imports System.IO

Friend Class frmLeggiXme
#Region "Dichiarazioni"
    Inherits System.Windows.Forms.Form

    Dim blnMostaErrori As Boolean = False
    'Dim Velocita As Integer
    Dim Volume As Integer

    Public WithEvents Voice As SpeechSynthesizer
    Public WithEvents Voice2 As SpeechSynthesizer

    'Public m_speakFlags As SpeechLib.SpeechVoiceSpeakFlags
    Dim m_bSpeaking, bSpeaking As Boolean
    Dim bPaused, m_bPaused As Boolean
    Dim MisuraCar As Integer

    Dim blnTastiRegistrati As Boolean = False
    Dim blnAperto As Boolean = False

    Dim s As String
    Dim p, iniz, l, OldI As Integer
    Dim inizio, lungh As Integer
    Dim blnTasto, blnParola As Boolean
    Dim UnaParola As String
    Dim StatoFinestra As Integer = 0
    Dim blnLeggiFrase As Boolean = False

    Public testo As String
    Dim blnDaQui As Boolean
    Dim PosIniziale As Integer
    Dim LunghezzaSelezione As Integer, FineSelezione As Integer
    Dim blnLeggereParola As Boolean
    Dim blnLeggiUnaFrasePerVolta As Boolean
    Dim blnLeggiUnaFrase As Boolean = False
    Dim blnStoLeggendo As Boolean = False
    Dim blnStoLeggendoTraduzione As Boolean = False
    Dim VecchioInizio, VecchiaLunghezza As Integer
    Dim tmp As String
    Dim StoAdattando As Boolean
    Dim c(31) As String

    Dim res As Integer
    Dim OldStart, Scarto, OldEnd, SStart As Integer
    Dim InizSelezione, LunghSelezione As Integer
    Dim blnRipristinareSelezione As Boolean = False
    Dim larghezza As Integer = 142
    Dim altezza As Integer = 70
    Dim aCapo As Boolean

    Dim zeppa As Integer = 0
    Dim NumParte As Integer = 0
    Dim NumFrase As Integer = 0
    'Dim blnPiuParti As Boolean = False

    Dim mioHandle As IntPtr, altroHandle As IntPtr, PuntaFinestra As IntPtr
    Dim NomeApplicazione As String

    Dim spaziInizio As String = " .,;:!?([{" & Chr(34) & Chr(13)
    Dim spaziFine As String = " .,;:!?)]}" & Chr(34) & Chr(13)

    Dim blnCaratteriVisibili, blnMenuVisibile As Boolean

    Dim NumErrori As Integer = 0
    Const MassSuggerimenti As Integer = 100
    Const MaxErrori As Integer = 200
    Dim lemma(MaxErrori) As String
    Dim errata(MaxErrori) As String
    Dim NumSuggerimenti(MaxErrori) As Integer
    Dim Suggerimenti(MaxErrori, MassSuggerimenti) As String

    ' lunghezza massima file audio
    Dim blnSelez As Boolean = True

    Dim voce2speaking As Boolean = False
    Dim blnMaiuscolo As Boolean = False

    Dim ColoreEvidenziato As Color = Color.FromArgb(0, 255, 255)
    Dim ColoreEvidenziato2 As Color = Color.FromArgb(0, 254, 255)
    Dim Rosso As Color = Color.FromArgb(255, 0, 0)
    Dim Rosso2 As Color = Color.FromArgb(254, 0, 0)
    Dim tmpRTF As String = ""
    Dim ColoreSfondo As Color

    Dim Intestazione As String = ""
    Dim blnSalvato As Boolean = True
    Dim blnTempSalvato As Boolean = True
    Dim blnFinestraAperta As Boolean = False
    Dim blnHoAperto As Boolean = False

    Dim MisuraFontPredefinito As Single = 0
    Dim NomeFontPredefinito As String = ""

    Dim NomeDocumento As String = "Documento.rtf"

    Dim blnInstallato As Boolean = True
    Dim blnAggiornaVelocità As Boolean = False

    Dim blnStoSalvando As Boolean = False
    Dim PercorsoClipart As String = ""

    Dim blnDaRipristinare As Boolean = False

    'Private Declare Sub mouse_event Lib "user32.dll" (ByVal dwFlags As Integer, ByVal dx As Integer, ByVal dy As Integer, ByVal cButtons As Integer, ByVal dwExtraInfo As IntPtr)

#End Region

    Private Sub cbVoci_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cbVoci.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Scegli voce")
        End If
    End Sub

    Private Sub cbVoci_SelectedIndexChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cbVoci.SelectedIndexChanged
        Try
            Parlante = cbVoci.Text
            intParlante = cbVoci.SelectedIndex
            'Voice.Voice = Voice.GetVoices().Item(Parlante)
            Voice.SelectVoice(cbVoci.Text)
            'Voice2.Voice = Voice.Voice
            ScegliLingua()
        Catch
            'MsgBox("sono qui")
            cbVoci.Text = VocePrincipale
            Parlante = VocePrincipale
        End Try
        intParlante = cbVoci.SelectedIndex

    End Sub

    Private Sub chkTrasparente_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles chkTrasparente.CheckStateChanged
        blnTrasparente = False '(chkTrasparente.CheckState = 1)
    End Sub

    Private Sub cmdChiudi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdChiudi.Click
        ChiudiFinestra()
    End Sub

    Private Sub ChiudiFinestra()
        MioTimer.Enabled = True
        blnFinestraAperta = False
        Me.TopMost = True
        MostraPausa()
        Me.WindowState = FormWindowState.Normal
        Me.Width = larghezza : Me.Height = altezza
        cmdImposta.Enabled = True

        Me.MaximizeBox = False
        If Ridotta() = False Then
            cmdChiudi.Left = Me.Width - 100
        End If

        If blnTrasparente = True Then
            res = RendiTrasparente(Me.Handle.ToInt32, 128)
        End If
        cmdTraduci.Enabled = True
        blnAperto = False
        On Error Resume Next
        frmPDF.Close()
        tmrSalva.Enabled = False

    End Sub

    Private Sub cmdLeggi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdLeggi.Click
        If bln64bit = True Then
            Me.WindowState = FormWindowState.Minimized
            blnDaRipristinare = True
        End If
        Leggi()
    End Sub

    Private Sub cmdMenoVel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdMenoVel.Click
        DiminuisciVelocita()
    End Sub

    Private Sub DiminuisciVelocita()
        If Velocita > -10 Then Velocita = Velocita - 1
        lblVel.Text = CStr(Velocita)
        Voice.Rate = Velocita
        If blnStoLeggendo = True Then
            blnAggiornaVelocità = True
            FermaLettura()
            Leggi()
        End If
    End Sub

    Private Sub cmdPiuVel_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdPiuVel.Click
        AumentaVelocita()
    End Sub

    Private Sub AumentaVelocita()
        If Velocita < 8 Then Velocita = Velocita + 1
        lblVel.Text = CStr(Velocita)
        Voice.Rate = Velocita
        If blnStoLeggendo = True Then
            blnAggiornaVelocità = True
            FermaLettura()
            Leggi()
        End If
    End Sub

    Private Sub cmdStop_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdStop.Click
        FermaLettura()
        FermaVoce2()
    End Sub

    Private Function ChiediSalva() As Boolean
        If blnHoAperto = False Then
            Return False
            Exit Function
        End If
        If blnSalvato = False Then
            Dim res As Integer = MsgBox("Vuoi salvare il tuo documento?", MsgBoxStyle.Information Or MsgBoxStyle.YesNoCancel)
            If res = vbCancel Then
                Return True
                Exit Function
            End If
            If res = vbYes Then
                SalvaDocumento()
            End If
        End If
        Return False
    End Function

    Private Sub frmLeggiXme_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        On Error Resume Next
        If ChiediSalva() = True Then
            e.Cancel = True
            Exit Sub
        End If

        DeRegistraTasti()
        On Error Resume Next
        If IO.File.Exists(CartellaTemp & "testo.txt") Then
            Kill(CartellaTemp & "testo.txt")
        End If
        If IO.File.Exists(CartellaTemp & "errori.txt") Then
            Kill(CartellaTemp & "errori.txt")
        End If
        If IO.File.Exists(FileTemporaneo) Then
            Kill(FileTemporaneo)
        End If

        frmPDF.Close()
        'frmINT.Close()
        'frmWRD.Close()
    End Sub

    Private Sub RegistraTasti()
        Call RegisterHotKey(Me.Handle, 40000, MOD_CONTROL, Keys.A)
        Call RegisterHotKey(Me.Handle, 40001, MOD_CONTROL, Keys.S)
        Call RegisterHotKey(Me.Handle, 40002, MOD_CONTROL, Keys.Up)
        Call RegisterHotKey(Me.Handle, 40003, MOD_CONTROL, Keys.Down)
        Call RegisterHotKey(Me.Handle, 40004, MOD_CONTROL, Keys.Left)
        Call RegisterHotKey(Me.Handle, 40005, MOD_CONTROL, Keys.Right)
        Call RegisterHotKey(Me.Handle, 40006, MOD_CONTROL, Keys.LButton)
        'Call RegisterHotKey(Me.Handle, 40007, MOD_CONTROL, Keys.T)
        Call RegisterHotKey(Me.Handle, 40008, MOD_CONTROL, Keys.PageDown)
        Call RegisterHotKey(Me.Handle, 40009, MOD_CONTROL, Keys.PageUp)
        Call RegisterHotKey(Me.Handle, 40010, MOD_CONTROL, Keys.D)
        blnTastiRegistrati = True
    End Sub

    Private Sub DeRegistraTasti()
        Call UnregisterHotKey(Me.Handle, 40000)
        Call UnregisterHotKey(Me.Handle, 40001)
        Call UnregisterHotKey(Me.Handle, 40002)
        Call UnregisterHotKey(Me.Handle, 40003)
        Call UnregisterHotKey(Me.Handle, 40004)
        Call UnregisterHotKey(Me.Handle, 40005)
        Call UnregisterHotKey(Me.Handle, 40006)
        'Call UnregisterHotKey(Me.Handle, 40007)
        Call UnregisterHotKey(Me.Handle, 40008)
        Call UnregisterHotKey(Me.Handle, 40009)
        Call UnregisterHotKey(Me.Handle, 40010)
        blnTastiRegistrati = False
    End Sub

    Private Sub NascondiPausa()
        picComandi.Width -= 40
        cmdTraduci.Left -= 40
        cmdImposta.Left -= 40
        'btnAppunti.Left -= 40
        cmdPausa.Visible = False
    End Sub

    Private Sub MostraPausa()
        picComandi.Width += 40
        cmdTraduci.Left += 40
        cmdImposta.Left += 40
        'btnAppunti.Left += 40
        cmdPausa.Visible = True
    End Sub

    Sub NascondiTraduttore()
        cmdTraduci.Visible = False
        cmdImposta.Left -= 40
        picComandi.Width -= 40
        If CeDizionario() = False Then
            TradIItaIngToolStripMenuItem.Visible = False
            If blnInternet = False Then
                btnTRAD.Visible = False
            End If
        End If
        'btnTRAD.Visible = False
        'btnAppunti.Left = btnTRAD.Left
    End Sub

    Sub ControllaTemporaneo()
        If Dir(FileTemporaneo) <> "" Then
            Dim res As Integer
            res = MsgBox("ATTENZIONE! C'è un documento che può essere recuperato." & vbCrLf & "Vuoi recuperarlo?", MsgBoxStyle.Information Or MsgBoxStyle.YesNo)
            If res = vbYes Then
                RTB.LoadFile(FileTemporaneo, RichTextBoxStreamType.RichText)
                ApriFinestra()
            Else
                Try
                    Kill(FileTemporaneo)
                Catch ex As Exception
                End Try
            End If
        End If
    End Sub

    Sub IconaPDF()
        Dim ico As Icon
        Dim i As Integer = InStrRev(Percorso, "\")
        Dim prog As String = Mid(Percorso, 1, i) & "PDFX_Vwr_Port\PDFXCview.exe"
        MsgBox(prog)
        On Error GoTo Esci

        If IO.File.Exists(prog) Then
            ico = Icon.ExtractAssociatedIcon(prog)
            blnInstallato = False
        Else
            Dim np As String = ProgrammaAssociato("pdf")
            ico = Icon.ExtractAssociatedIcon(np)
        End If
        btnPDF.Image = ico.ToBitmap

        Exit Sub

Esci:
        MsgBox(Err.Description)

    End Sub

    Sub NascondiIconaClipart()
        'Dim i As Integer = InStrRev(Percorso, "\")
        PercorsoClipart = Percorso & "\Immagini"
        If IO.Directory.Exists(PercorsoClipart) = False Then
            btnImmagine.Visible = False
        End If

    End Sub

    Private Sub frmLeggiXme_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load

        VersioneAttuale = "20120925"

        RegistraTasti()
        CaratteriSpeciali()

        RTB.AllowDrop = True
        cmdImposta.AllowDrop = True
        cmdLeggi.AllowDrop = True

        If CeFW35() = False Then
            NascondiTraduttore()
        End If

        If ConnessioneInternet() = True Then
            blnInternet = True
            If Mid(Percorso, 1, 1) = "C" Then
                Try
                    AggiornamentoDisponibile()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
        Else
            blnInternet = False
        End If

        NascondiTraduttore()
        NascondiIconaClipart()

        blnCaratteriVisibili = False
        blnMenuVisibile = False
        RTB.Top = 45
        Voice = New SpeechSynthesizer
        Voice2 = New SpeechSynthesizer

        'Dim n As String
        Dim ContaVoci As Integer = 0
        'Dim Token As SpeechLib.ISpeechObjectToken


        Try
            Init()
            c10.Checked = True
            blnTrasparente = True

            Parlante = ""
            VocePrincipale = ""
            Velocita = 0 : Voice.Rate = Velocita : Voice2.Rate = Velocita
            Volume = 100 : Voice.Volume = Volume : Voice2.Volume = Volume

            Dim italiane As Integer = 0
            cbVoci.Items.Clear()

            Dim objvoices As ReadOnlyCollection(Of InstalledVoice) = Voice.GetInstalledVoices()
            Dim objvoiceInformation As VoiceInfo = objvoices(0).VoiceInfo
            For Each tmpvoice As InstalledVoice In objvoices
                objvoiceInformation = tmpvoice.VoiceInfo
                Lingua(ContaVoci) = objvoiceInformation.Culture.Name
                ReDim Preserve VoceInstallata(ContaVoci)
                VoceInstallata(ContaVoci) = objvoiceInformation.Name.ToString
                If Lingua(ContaVoci) = Italiano Then
                    italiane += 1
                End If
                cbVoci.Items.Add(objvoiceInformation.Name.ToString)
                ContaVoci = ContaVoci + 1
            Next

            If ContaVoci = 0 Then
                MsgBox("Non ci sono voci SAPI 5 installate", MsgBoxStyle.Critical, "LeggiXme")
                End
            End If

            If italiane = 0 Then
                Dim messaggio As String = "Non ci sono voci SAPI 5 italiane installate" '& vbCrLf & "Vuoi proseguire comunque?"
                MsgBox(messaggio, MsgBoxStyle.Critical, "LeggiXme")
                End
            End If


            ChDir(My.Application.Info.DirectoryPath)

            'm_speakFlags = "" 'SpeechLib.SpeechVoiceSpeakFlags.SVSFlagsAsync Or SpeechLib.SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak Or SpeechLib.SpeechVoiceSpeakFlags.SVSFIsXML

            rbInterl1.Checked = True

            LeggiImpostazioni()

            Select Case interlinea
                Case 1
                    rbInterl1.Checked = True
                Case 2
                    rbInterl15.Checked = True
                Case 3
                    rbInterl2.Checked = True
            End Select

            Dim MioFont As New Font(NomeFontPredefinito, MisuraFontPredefinito, FontStyle.Regular)
            RTB.SelectionFont = MioFont
            FontPredefinito = MioFont

            If Parlante = "" Or cbVoci.FindString(Parlante) = -1 Then
                ScegliVoce.ShowDialog()
            End If

            If cbVoci.FindString(VocePrincipale) = -1 Or Lingua(cbVoci.FindString(VocePrincipale)) <> Italiano Then
                VocePrincipale = Parlante
                If Lingua(cbVoci.FindString(Parlante)) <> Italiano Then
                    ScegliVoce.ShowDialog()
                End If
            End If

            Voice2.SelectVoice(VocePrincipale)
            'Voice2.Voice = Voice2.GetVoices.Item(VocePrincipale)
            cbVoci.Text = Parlante

            LeggiMisureFinestra()

            NascondiPausa()
            ChiudiFinestra()

            Me.Location = New Point(1, 1)

            rbNormale.Checked = True

            pnAudio.Left = 9
            pnAudio.Top = 42
            pnAudio.Visible = False

            pnFile.Left = 168 '15
            pnFile.Top = 42
            pnFile.Visible = False

            pnModifica.Left = 168 '15
            pnModifica.Top = 42
            pnModifica.Visible = False

            pnVisualizza.Left = 168 '15
            pnVisualizza.Top = 42
            pnVisualizza.Visible = False

            pnOrtografia.Left = 168 '15
            pnOrtografia.Top = 42
            pnOrtografia.Visible = False

            pnSpeciale.Left = 208
            pnSpeciale.Top = 42
            pnSpeciale.Visible = False

            pnTrova.Left = 399
            pnTrova.Top = 42
            pnTrova.Visible = False

            pnCaratteri.Visible = False


            InitSinonimi()
            Clipboard.Clear()
            rbMin.Checked = True

        Catch e As Exception
            Dim mes As String = ""
            mes = "Problema: " & e.Message
            If ContaVoci = 0 Then
                mes = "Non ci sono voci SAPI 5 installate"
            End If
            MsgBox(mes)
            End

        End Try
        RBSel.Checked = True
        Intestazione = Me.Text
        ControllaTemporaneo()
        IconaPDF()
        Me.TopMost = True
        mioHandle = Me.Handle
        ColoreSfondo = RTB.BackColor

        '        CaricaDizInglese() : TradIItaIngToolStripMenuItem.Visible = True : TradIngItaToolStripMenuItem.Visible = True

        If bln64bit Then
            MioTimer.Enabled = True
        End If

    End Sub

    Function TrovaHandleDaNome(ByVal n As String) As IntPtr

        Dim procList() As Process = Process.GetProcesses()
        Dim i As IntPtr = Nothing
        Dim m As String = ""
        For Each p As Process In procList ' i + 1
            If InStr(UCase(p.ProcessName), n) > 0 Then
                i = p.Handle
                Exit For
            End If
        Next
        Return i

    End Function

    Sub ImpostazioniStandard()
        ResettaAudio()
    End Sub

    Sub ResettaAudio()
    End Sub

    Private Sub frmLeggiXme_FormClosed(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        FermaLettura()
        Voice = Nothing
        SalvaImpostazioni()
    End Sub

    Public Sub SetSpeakingState(ByVal bSpeaking As Boolean, ByVal bPaused As Boolean)
        m_bSpeaking = bSpeaking
        m_bPaused = bPaused

    End Sub

    Private Sub EvidenziaParola(ByVal Pos As Integer, ByVal Length As Integer)
        ' MsgBox(zeppa & " " & inizio & " " & iniz)
        Try
            Pos = Pos + inizio 'Scarto
            RTB.SelectionStart = Pos
            RTB.SelectionLength = Length
        Catch e As Exception
            MsgBox("Non riesco ad evidenziare le parole.")
        End Try

    End Sub

    Sub LeggiMisureFinestra()
        larghezza = picComandi.Width + 5

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

        altezza = CInt(propval1.ToString()) + picComandi.Height + 6

    End Sub

    Dim Programma As String = "LeggiXme"

    Sub LeggiImpostazioni()

        Dim trasp As String

        ChDrive(My.Application.Info.DirectoryPath)
        ChDir(My.Application.Info.DirectoryPath)

        VocePrincipale = GetSetting(Programma, "impostazioni", "VocePrincipale", "")
        Velocita = CShort(GetSetting(Programma, "impostazioni", "Velocita", "0"))
        trasp = GetSetting(Programma, "impostazioni", "Trasparente", "F")
        interlinea = CInt(GetSetting(Programma, "impostazioni", "Interlinea", "1"))
        NomeFontPredefinito = Trim(GetSetting(Programma, "impostazioni", "NomeFont", "Verdana"))
        MisuraFontPredefinito = CSng(GetSetting(Programma, "impostazioni", "MisuraFont", "14"))
        AmpiezzaPannelloPDF = CInt(CSng(GetSetting(Programma, "impostazioni", "AmpiezzaPannelloPDF", "250")))
        If NomeFontPredefinito = "" Then NomeFontPredefinito = "Verdana"
        If MisuraFontPredefinito = 0 Then MisuraFontPredefinito = 14

        If Velocita > 8 Then Velocita = 8
        If trasp = "F" Then
            blnTrasparente = False
            chkTrasparente.CheckState = System.Windows.Forms.CheckState.Unchecked
        Else
            blnTrasparente = True
            chkTrasparente.CheckState = System.Windows.Forms.CheckState.Checked
        End If

        ImpostaInterlinea(RTB)
        Parlante = VocePrincipale
        Volume = 90 ' lo metto quasi al massimo
        lblVel.Text = CStr(Velocita)

    End Sub

    Sub SalvaImpostazioni()

        Dim trasp As String

        If blnTrasparente = True Then trasp = "V" Else trasp = "F"
        SaveSetting(Programma, "impostazioni", "VocePrincipale", VocePrincipale)
        SaveSetting(Programma, "impostazioni", "Velocita", CStr(Velocita))
        SaveSetting(Programma, "impostazioni", "Trasparente", trasp)
        SaveSetting(Programma, "impostazioni", "Interlinea", CStr(interlinea))
        SaveSetting(Programma, "impostazioni", "NomeFont", NomeFontPredefinito)
        SaveSetting(Programma, "impostazioni", "MisuraFont", CStr(MisuraFontPredefinito))
        SaveSetting(Programma, "impostazioni", "AmpiezzaPannelloPDF", CStr(AmpiezzaPannelloPDF))

    End Sub

    Sub RipulisciSelezione()
        Dim t As String = RTB.SelectedText
        Dim i As Integer = Len(t)
        Do
            If Asc(Mid(t, i, 1)) > 32 Then
                Exit Do
            Else
                If i > 1 Then
                    i -= 1
                Else
                    i = 0
                    Exit Do
                End If
            End If
        Loop
        RTB.SelectionLength = i
    End Sub

    Private Sub Leggi()

        FermaVoce2()
        If Ridotta() = True And blnLeggiUnaFrase = False And blnAggiornaVelocità = False Then
            CopiaTesto()
        Else
            blnAggiornaVelocità = False
        End If

        If Trim(RTB.Text) = "" Then
            Voice2.Speak("Non c'è nulla da leggere.")
            Exit Sub
        End If

        Dim t As String = ""

        zeppa = RTB.SelectionStart
        inizio = zeppa

        If RTB.SelectionLength > 0 Then
            RipulisciSelezione()
            t = RTB.SelectedText
            InizSelezione = RTB.SelectionStart
            LunghSelezione = RTB.SelectionLength
            blnRipristinareSelezione = True
        Else
            t = Mid(RTB.Text, zeppa + 1)
        End If

        If VoceZitta() = False Then
            FermaLettura()
        End If

        Intervallo = 2000
        NumParti = 0
        If Len(RTB.SelectedText) > Intervallo Then
            NumParti = DividiInParti2(t)
            If NumParti < 1 Then
                NumParti = DividiACapo(t)
            End If
        End If

        Voice.SelectVoice(Parlante)
        SetSpeakingState(True, False)
        If NumParti < 1 Then
            blnPiuParti = False
            Voice.SpeakAsync(EliminaPunti(t))
        Else
            blnPiuParti = True
            NumParte = 0
            LeggiUnaParte()
        End If

    End Sub

    Private Sub LeggiUnaParte()
        zeppa = zeppa + Len(Parte(NumParte))
        NumParte = NumParte + 1
        If NumParte > NumParti Then
            blnPiuParti = False
            If blnRipristinareSelezione Then
                RTB.SelectionStart = InizSelezione
                RTB.SelectionLength = LunghSelezione
                blnRipristinareSelezione = False
            End If
            Exit Sub
        End If
        blnStoLeggendo = True
        Voice.Speakasync(EliminaPunti(Parte(NumParte)))
    End Sub

    Private Sub LeggiFrase()
        zeppa = zeppa + Len(Frase(NumParte))
        NumParte = NumParte + 1
        If NumParte > NumParti Then
            blnPiuParti = False
            Exit Sub
        End If
        blnStoLeggendo = True
        Voice.SpeakAsync(EliminaPunti(Frase(NumParte)))
    End Sub

    Sub LeggiOld()

        Dim InizioSelezione As Integer = RTB.SelectionStart 'inizio
        LunghezzaSelezione = RTB.SelectionLength

        'If blnStoLeggendo = True Then FermaLettura()
        FermaLettura()

        RTB.SelectionStart = InizioSelezione
        'inizio = InizioSelezione

        Try
            If Ridotta() = True And blnLeggiUnaFrase = False Then
                CopiaTesto()
            End If

            If Trim(RTB.Text) = "" Then
                Voice2.Speak("Non c'è nulla da leggere.")
                Exit Sub
            End If

            s = RTB.Text ' fa copia del testo da passate a LeggiUnaFrase
            If Ridotta() = True Then 'And blnLeggiUnaFrase = False Then


                If blnLeggiUnaFrase = False Then
                    iniz = 1
                    inizio = 1
                    RTB.SelectionStart = 1
                    FineSelezione = Len(RTB.Text)
                    RTB.SelectionLength = FineSelezione
                    blnLeggiUnaFrasePerVolta = True
                    LeggiUnaFrase()
                Else
                    iniz = RTB.SelectionStart
                    inizio = RTB.SelectionStart
                    FineSelezione = Len(RTB.Text)
                    'RTB.SelectionLength = FineSelezione
                    blnLeggiUnaFrasePerVolta = False
                    LeggiUnaFrase()
                End If

            Else ' la finestra è aperta

                'RTB.SelectionStart = InizioSelezione
                RTB.SelectionLength = LunghezzaSelezione
                inizio = RTB.SelectionStart
                FineSelezione = LunghezzaSelezione + RTB.SelectionStart

                If RTB.SelectionLength = 0 Then

                    RTB.SelectionLength = Len(RTB.Text) - RTB.SelectionStart
                    FineSelezione = RTB.SelectionLength + RTB.SelectionStart

                    If blnLeggiUnaFrase = False Then
                        If RTB.SelectionLength < 1000 Then
                            blnLeggiUnaFrasePerVolta = False
                            Voice.SpeakAsync(RTB.SelectedText)
                        Else
                            blnLeggiUnaFrasePerVolta = True
                            LeggiUnaFrase()
                        End If
                    Else
                        s = Microsoft.VisualBasic.Left(RTB.Text, FineSelezione)
                        blnLeggiUnaFrasePerVolta = False
                        LeggiUnaFrase()
                    End If

                Else ' devo leggere il testo selezionato

                    blnLeggiUnaFrase = False

                    If RTB.SelectionLength < 1000 Then
                        blnLeggiUnaFrasePerVolta = False
                        Voice.SpeakAsync(RTB.SelectedText)
                    Else
                        s = Microsoft.VisualBasic.Left(RTB.Text, FineSelezione)
                        blnLeggiUnaFrasePerVolta = True
                        LeggiUnaFrase()
                    End If

                End If

            End If

            SetSpeakingState(True, False)

        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Sub

    Sub LeggiMi(ByVal t As String)
        Voice.SpeakAsync(t)
    End Sub

    Sub Leggi1frase(ByVal t As String, ByVal inizio As Integer, ByVal lunghezza As Integer)
        Dim p1 As Integer
        Dim p2 As Integer

        On Error GoTo Trap
        If t = "" Then
            Leggi2("Non c'è nulla da leggere!")
            Exit Sub
        End If

IniziaLetturaFrase:

        If inizio = 0 Then inizio = 1
        If p > OldI Then
            If OldI = 0 Then OldI = 1
            RTB.SelectionStart = OldI - 1
            RTB.SelectionLength = p - OldI
        End If
        If RTB.SelectionStart >= FineSelezione Then
            blnLeggiUnaFrasePerVolta = False
            RTB.Focus()
            Exit Sub
        End If
        aCapo = False
        p = InStr(iniz, s, Chr(10), CompareMethod.Binary) : p2 = p
        p1 = InStr(iniz, s, ".", CompareMethod.Text) : If p1 > 0 And (p1 < p Or p = 0) Then p = p1 + 1
        p1 = InStr(iniz, s, "?", CompareMethod.Text) : If p1 > 0 And (p1 < p Or p = 0) Then p = p1 + 1
        p1 = InStr(iniz, s, "!", CompareMethod.Text) : If p1 > 0 And (p1 < p Or p = 0) Then p = p1 + 1


        If p = iniz + 1 Then
            iniz = iniz + 1
            GoTo IniziaLetturaFrase
        End If
        If p2 = p Then aCapo = True
        If p = 0 Then
            If inizio >= Len(s) Then
                blnLeggiUnaFrasePerVolta = False
                blnLeggiUnaFrase = False
                Exit Sub
            Else
                p = Len(s) + 1
            End If
        End If
        RTB.SelectionStart = iniz - 1 : inizio = iniz - 1
        lungh = p - iniz : RTB.SelectionLength = lungh + 1

        OldI = iniz
        testo = RTB.SelectedText
        If aCapo = False Then iniz = p Else iniz = p + 1

        On Error Resume Next

        If Trim(testo) = "" Then
            'Exit Sub
            GoTo IniziaLetturaFrase
        End If

        VecchioInizio = RTB.SelectionStart
        VecchiaLunghezza = RTB.SelectionLength
        LeggiMi(RTB.SelectedText)

        RTB.SelectionStart = RTB.SelectionStart + RTB.SelectionLength
        RTB.SelectionLength = 0
        iniz = RTB.SelectionStart

Trap:
        blnLeggiUnaFrase = False


    End Sub

    Sub LeggiUnaFrase()

        Dim p1 As Integer
        Dim p2 As Integer

        On Error GoTo Trap
        If RTB.Text = "" Then
            Leggi2("Non c'è nulla da leggere!")
            Exit Sub
        End If

IniziaLetturaFrase:

        If iniz = 0 Then iniz = 1
        If p > OldI Then
            If OldI = 0 Then OldI = 1
            RTB.SelectionStart = OldI - 1
            RTB.SelectionLength = p - OldI
        End If
        If RTB.SelectionStart >= FineSelezione Then
            blnLeggiUnaFrasePerVolta = False
            RTB.Focus()
            Exit Sub
        End If
        aCapo = False
        p = InStr(iniz, s, Chr(10), CompareMethod.Binary) : p2 = p
        p1 = InStr(iniz, s, ".", CompareMethod.Text) : If p1 > 0 And (p1 < p Or p = 0) Then p = p1 + 1
        p1 = InStr(iniz, s, "?", CompareMethod.Text) : If p1 > 0 And (p1 < p Or p = 0) Then p = p1 + 1
        p1 = InStr(iniz, s, "!", CompareMethod.Text) : If p1 > 0 And (p1 < p Or p = 0) Then p = p1 + 1


        If p = iniz + 1 Then
            iniz = iniz + 1
            GoTo IniziaLetturaFrase
        End If
        If p2 = p Then aCapo = True
        If p = 0 Then
            If inizio >= Len(s) Then
                blnLeggiUnaFrasePerVolta = False
                blnLeggiUnaFrase = False
                Exit Sub
            Else
                p = Len(s) + 1
            End If
        End If
        RTB.SelectionStart = iniz - 1 : inizio = iniz - 1
        lungh = p - iniz : RTB.SelectionLength = lungh + 1

        OldI = iniz
        testo = RTB.SelectedText
        If aCapo = False Then iniz = p Else iniz = p + 1

        On Error Resume Next

        If Trim(testo) = "" Then
            'Exit Sub
            GoTo IniziaLetturaFrase
        End If

        VecchioInizio = RTB.SelectionStart
        VecchiaLunghezza = RTB.SelectionLength
        LeggiMi(RTB.SelectedText)

        RTB.SelectionStart = RTB.SelectionStart + RTB.SelectionLength
        RTB.SelectionLength = 0
        iniz = RTB.SelectionStart

Trap:
        blnLeggiUnaFrase = False

    End Sub

    Function FormaParola() As Boolean
        Dim tmp As String = ""
        Dim t As String = ""
        Dim a As String = ""
        Dim l As Integer = 0
        On Error GoTo Trap

        t = Mid(RTB.Text, 1, RTB.SelectionStart)

        If Len(t) = 0 Then Exit Function

        For l = Len(t) To 1 Step -1
            a = Mid(t, l, 1)
            If InStr(spaziInizio, a) <> 0 Then Exit For
            tmp = a & tmp
        Next l
        UnaParola = tmp
        If UnaParola <> "" Then FormaParola = True

        Exit Function

Trap:
        MsgBox(Err.Description)
        Err.Clear()

    End Function

    Private Function PosizioneFinale() As Integer
        Dim p1 As Integer
        Dim p2 As Integer
        Dim posFinale As Integer = 0

        aCapo = False
        posFinale = LunghezzaSelezione

        posFinale = InStr(iniz, s, Chr(10), CompareMethod.Binary) : p2 = posFinale
        If posFinale = 0 Then posFinale = LunghezzaSelezione

        p1 = InStr(iniz, s, ".", CompareMethod.Text)
        If p1 < posFinale And p1 > 0 Then posFinale = p1 + 1
        p1 = InStr(iniz, s, "?", CompareMethod.Text)
        If p1 < posFinale And p1 > 0 Then posFinale = p1 + 1
        p1 = InStr(iniz, s, "!", CompareMethod.Text)
        If p1 < posFinale And p1 > 0 Then posFinale = p1 + 1
        If p2 = p Then aCapo = True

        PosizioneFinale = posFinale - PosIniziale

    End Function

    Function Ridotta() As Boolean
        Ridotta = False
        If (Me.Width = larghezza And Me.Height = altezza) Or Me.WindowState = FormWindowState.Minimized Then
            Ridotta = True
        End If
    End Function

    Sub PausaLettura()

        If blnStoLeggendoTraduzione = True Then
            If Voice2.State = SynthesizerState.Paused Then
                Voice2.Resume()
            Else
                Voice2.Pause()
            End If
            Exit Sub
        End If

        If VoceZitta() = True Then Exit Sub

        If Voice2.State = SynthesizerState.Speaking Then
            FermaVoce2()
        End If

        Try
            If Voice.State = SynthesizerState.Speaking Then
                Voice.Pause()
                SetSpeakingState(False, True)
                RTB.SelectionLength = 0
                RTB.Refresh()
                RTB.Focus()
            Else
                Voice.Resume()
                SetSpeakingState(True, False)
            End If

        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Sub

    Sub RiprendiLettura()

        Try
            If m_bPaused = False Then Exit Sub
            SetSpeakingState(True, False)
            Voice.Resume()
        Catch e As Exception
            MsgBox(e.Message)
        End Try

    End Sub

    Sub FermaLettura()

        SStart = RTB.SelectionStart

        blnPiuParti = False
        If blnStoLeggendoTraduzione = True Then
            FermaVoce2()
        End If
        blnLeggiUnaFrasePerVolta = False
        RTB.SelectionLength = 0
        Try
            If VoceInPausa() Then Voice.Resume()
            Voice.SpeakAsyncCancelAll()
            SetSpeakingState(False, False)
        Catch e As Exception
            MsgBox(e.Message)
        End Try
        RTB.SelectionStart = SStart

    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        If m.Msg = WM_HOTKEY Then

            Dim numTasto As Integer = (CInt(m.WParam))
            Select Case numTasto
                Case 40000
                    'FermaLettura()
                    Leggi()
                Case 40001
                    If blnStoLeggendoTraduzione = True Then FermaVoce2()
                    PausaLettura()
                Case 40002
                    AumentaVelocita()
                Case 40003
                    DiminuisciVelocita()
                Case 40004
                    ComandoRipeti()
                Case 40005
                    ComandoUnaFrase()
                Case 40007
                    LeggiTraduzione()
                Case 40009
                    MostraNascondi()
                Case 40010
                    SalvaImmaginePresenteInClipboard()
                Case Else
            End Select
        End If

        MyBase.WndProc(m)
    End Sub

    Sub MostraNascondi()
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Minimized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub AutoVerbMenu_Opened(ByVal sender As Object, ByVal e As System.EventArgs) Handles AutoVerbMenu.Opened
        ' Determine if Undo should be enabled.
        If RTB.CanUndo = True Then
            Annulla.Enabled = True
        Else
            Annulla.Enabled = False
        End If
        ' Determine if Cut, Copy, and Paste should be enabled.
        If RTB.SelectedText <> "" Then
            Taglia.Enabled = True
            Copia.Enabled = True
            'Elimina.Enabled = True
        Else
            Taglia.Enabled = False
            Copia.Enabled = False
            'Elimina.Enabled = False
        End If
        ' Determine if Paste should be enabled
        If My.Computer.Clipboard.ContainsText = True Or My.Computer.Clipboard.ContainsImage = True Then
            Incolla_Tutto.Enabled = True
        Else
            Incolla_Tutto.Enabled = False
        End If

    End Sub

    Private Sub Annulla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Annulla.Click
        ' Undo the last edit operation in the RichTextBox
        If RTB.CanUndo Then
            RTB.Undo()
        End If

    End Sub

    Private Sub Ripristina_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Ripristina.Click
        If RTB.CanRedo Then
            RTB.Redo()
        End If
    End Sub

    Private Sub Taglia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Taglia.Click
        fnTaglia()
    End Sub

    Private Sub Copia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Copia.Click
        fnCopia()
    End Sub

    Private Sub Incolla_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles Incolla_Tutto.Click
        fnIncolla()
    End Sub

    Sub fnTaglia()
        If RTB.SelectedText <> "" Then
            RTB.Cut()
        End If
    End Sub

    Sub fnCopia()
        If RTB.SelectedText <> "" Then
            Dim tmp As String = Trim(RTB.SelectedText)
            Try
                Clipboard.SetText(tmp)
            Catch ex As Exception
                'MsgBox(tmp)
            End Try
        End If
    End Sub

    Sub fnIncolla()
        If My.Computer.Clipboard.ContainsText Or My.Computer.Clipboard.ContainsImage Then
            RTB.Paste()
            RTB.SelectionLength = 0
            MaiuscoloMinuscolo()
        End If
    End Sub

    Private Sub Elimina_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        If RTB.SelectedText <> "" Then
            RTB.SelectedText = ""
        End If
    End Sub

    Private Sub CopiaTesto()
        Dim tmp As String, strProg As String
        If bln64bit Then
            SetForegroundWindow(altroHandle)
            strProg = GetWT(altroHandle)
            SetForegroundWindow(altroHandle)

            ' AppActivate(strProg)

            Threading.Thread.Sleep(100)

            Dim a As String = Mid(strProg, 1, 5)
            If a = "NITRO" Then strProg = a

            If strProg = "NITRO" Then
                SendKeys.SendWait("^(z)")
            Else
                SendKeys.SendWait("^(c)")
            End If

            Threading.Thread.Sleep(100)

            If Clipboard.ContainsText = False Then
                SetForegroundWindow(altroHandle)
                Threading.Thread.Sleep(200)
                If InStr(strProg, "NITRO") > 0 Then
                    SendKeys.SendWait("^(z)")
                Else
                    SendKeys.SendWait("^(c)")
                End If
            End If
        Else
            Threading.Thread.Sleep(100)
            altroHandle = GetForegroundWindow
            strProg = GetWT(altroHandle)

            If InStr(strProg, "NITRO") > 0 Then
                SendKeys.SendWait("^(z)")
            Else
                SendKeys.SendWait("^(c)")
            End If
        End If


        Try
            If Clipboard.ContainsText = True Then
                tmp = Clipboard.GetText
                If FiltroPDF.Checked = True Or strProg = "ACRORD32" Or strProg = "PDFXCVIEW" Or strProg = "PDFREADER" Or strProg = "NITRO" Then tmp = filtrata(tmp)
                If strProg = "WINWORD" Then tmp = tmp.Replace(Chr(172), "")
                tmp = filtrataRomani(tmp)
                tmp = tmp.Replace("É", "È")
                RTB.Text = Trim(tmp)
                If RTB.Text <> "" Then
                    NAppunti += 1
                    ReDim Preserve Appunti(NAppunti)
                    Appunti(NAppunti) = RTB.Text
                End If
                ImpostaInterlinea(RTB)
                RTB.SelectAll()
                RTB.SelectionFont = FontPredefinito
                RTB.SelectionStart = 0
                RTB.SelectionLength = 0
                Me.Text = Intestazione
            Else
                'Me.Text = strProg
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub frmLeggiGXme_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If StatoFinestra = 1 And Me.WindowState = 0 Then
            FermaLettura()
        End If
        StatoFinestra = Me.WindowState
        RisistemaRTB()
    End Sub

    Sub RisistemaRTB()
        Const zeppaRTB As Integer = 5

        RTB.Width = Me.Width - 25
        If blnMostaErrori = True Then
            RTB.Width = RTB.Width - panErrori.Width
            lblTrovati.Visible = True
            lbErrate.Visible = True
        Else
            lblTrovati.Visible = False
            lbErrate.Visible = False
        End If
        Select Case RTB.Top
            Case 45
                RTB.Height = Me.Height - 80 - zeppaRTB
            Case 85
                RTB.Height = Me.Height - 120 - zeppaRTB
            Case 125
                RTB.Height = Me.Height - 160 - zeppaRTB
        End Select

    End Sub

    Private Sub btnSalva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalva.Click
        SalvaDocumento()
    End Sub

    Private Sub SalvaDocumento()

        Dim saveRTB As New SaveFileDialog()
        saveRTB.Filter = "RTF files (*.rtf)|*.rtf|txt files (*.txt)|*.txt"
        saveRTB.FilterIndex = 1
        saveRTB.RestoreDirectory = True
        saveRTB.FileName = IO.Path.GetFileNameWithoutExtension(NomeDocumento)

        If saveRTB.ShowDialog() = DialogResult.OK Then
            Dim nf As String = saveRTB.FileName
            Try
                If IO.Path.GetExtension(nf) = ".rtf" Then
                    RTB.SaveFile(nf, RichTextBoxStreamType.RichText)
                Else
                    RTB.SaveFile(nf, RichTextBoxStreamType.PlainText)
                End If
                Dim i As Integer = InStrRev(nf, "\")
                NomeDocumento = IO.Path.GetFileName(nf)
                Me.Text = "LXM LeggiXme - " & NomeDocumento
                blnSalvato = True
            Catch ex As Exception
                MsgBox("Errore nel salvataggio del file", MsgBoxStyle.Critical)
            End Try
        End If

    End Sub

    Private Sub AggiungiImmagine()
        Dim apriRTB As New OpenFileDialog()
        apriRTB.Filter = "File di immagine|*.jpg;*.gif;*.png;*.tif;*.bmp"
        apriRTB.FilterIndex = 1
        apriRTB.RestoreDirectory = True

        If apriRTB.ShowDialog() = DialogResult.OK Then
            Dim img As Image = Image.FromFile(apriRTB.FileName)
            Try
                Clipboard.SetImage(img)
                RidimensionaImmagineInClipboard()
                RTB.Paste()
            Catch er As Exception
            End Try
        End If
    End Sub

    Private Sub btnApri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApri.Click

        If ChiediSalva() = True Then Exit Sub

        Dim apriRTB As New OpenFileDialog()
        apriRTB.Filter = "file RTF o TXT(*.rtf)(*.txt)|*.rtf;*.txt"
        apriRTB.FilterIndex = 1
        apriRTB.RestoreDirectory = True

        If apriRTB.ShowDialog() = DialogResult.OK Then
            Try
                If InStr(LCase(apriRTB.FileName), ".rtf") > 0 Then
                    RTB.LoadFile(apriRTB.FileName, RichTextBoxStreamType.RichText)
                Else
                    RTB.LoadFile(apriRTB.FileName, RichTextBoxStreamType.PlainText)
                End If
                Dim nf As String = apriRTB.FileName
                Dim i As Integer = InStrRev(nf, "\")
                nf = Mid(nf, i + 1)
                Me.Text = "LXM LeggiXme - " & nf

            Catch er As Exception
                MsgBox("Errore nell'apertura di " & apriRTB.FileName, MsgBoxStyle.Critical)
            End Try
        End If
        MaiuscoloMinuscolo()
    End Sub

    Private Sub btnImmagine_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImmagine.Click
        AggiungiClipArt()
    End Sub

    Private Sub AggiungiClipArt()
        Dim apriImg As New OpenFileDialog()
        apriImg.Filter = "File di immagine|*.jpg;*.gif;*.png;*.tif;*.bmp"
        apriImg.FilterIndex = 1
        apriImg.InitialDirectory = PercorsoClipart

        'apriRTB.RestoreDirectory = True

        If apriImg.ShowDialog() = DialogResult.OK Then
            Dim img As Image = Image.FromFile(apriImg.FileName)
            Try
                Clipboard.SetImage(img)
                RidimensionaImmagineInClipboard(120)
                RTB.Paste()
            Catch er As Exception
            End Try
        End If
    End Sub

    Private Sub btnCarattere_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCarattere.Click
        Dim fontRTB As New FontDialog
        Dim MioStile As FontStyle
        Try
            MioStile = RTB.SelectionFont.Style
        Catch ex As Exception
            MioStile = FontStyle.Regular
        End Try
        fontRTB.Font = RTB.SelectionFont
        Try
            If fontRTB.ShowDialog() = DialogResult.OK Then
                Dim MioFont As New Font(fontRTB.Font, fontRTB.Font.Style)
                RTB.SelectionFont = MioFont
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Incolla_Testo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Incolla_Testo.Click
        If My.Computer.Clipboard.ContainsText Then
            'RTB.Paste()
            RTB.SelectedText = Clipboard.GetText

        End If
    End Sub

    Private Sub btnColore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnColore.Click
        Dim colorRTB As New ColorDialog
        If colorRTB.ShowDialog() = DialogResult.OK Then
            Dim MioColore As Color = colorRTB.Color
            RTB.SelectionColor = MioColore
        End If
    End Sub

    Private Sub btnWave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWave.Click
        'Dim a As Integer = 10
        'a = CInt(10 / (a - 10))
        blnMP3 = False
        SalvaWav()
    End Sub

    Private Sub btnMP3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMP3.Click
        blnMP3 = True
        SalvaWav()
    End Sub

    Sub SalvaWav()
        Dim t As String = RTB.SelectedText
        If Len(t) < 2 Then t = RTB.Text
        SalvaWave(Me, t)
    End Sub

    Public Sub CreaWave(ByVal t As String, ByVal NomeFile As String)

        'Dim cpFileStream As New SpFileStream
        Dim velocita2 As Integer = Voice.Rate

        Voice.SetOutputToWaveFile(NomeFile)
        Voice.Speak(EliminaPunti(t))
        Voice.SetOutputToDefaultAudioDevice()

    End Sub

    Public Sub SalvaWave(ByVal frm As Form, ByVal testo As String)

        Dim k As Integer = 0
        'Dim TestString As String = testo
        'Dim TestNumber As Integer = 0, TestNumber2 As Integer = 0, TestNumber3 As Integer = 0
        'Dim Partenza As Integer = intervallo, inizio As Integer = 0
        'Dim Lung As Integer = Len(TestString)
        Dim blnInterrompi As Boolean = False
        'Dim Parte() As String
        'Dim QuanteParti As Integer = 0

        If Len(testo) > 4000 Then
            Leggi2("ATTENZIONE! Sarebbe meglio non salvare faail sonori così lunghi!")
            MsgBox("ATTENZIONE! Sarebbe meglio non salvare file sonori così lunghi!", MsgBoxStyle.Exclamation)
        End If

        If testo = "" Then
            MsgBox("Non c'è nulla da salvare come file sonoro!", vbCritical)
            Exit Sub
        End If

        Intervallo = 1600

        Dim CD As New SaveFileDialog()

        Try
            CD.Title = "Salva in un File Wav"
            CD.Filter = "Tutti i file (*.*)|*.*|File Wave (*.wav)|*.wav"
            If blnMP3 = True Then
                CD.Title = "Salva in un File MP3"
                CD.Filter = "Tutti i file (*.*)|*.*|File MP3 (*.mp3)|*.mp3"
            End If
            CD.FilterIndex = 2
            CD.RestoreDirectory = True
            CD.OverwritePrompt = True
            If CD.ShowDialog() = DialogResult.OK Then
                frm.Cursor = Cursors.WaitCursor
                Dim NomeFile As String = CD.FileName
                Dim i As Integer = InStr(LCase(NomeFile), ".mp3")
                If i <> 0 Then
                    Mid(NomeFile, i) = ".wav"
                End If

                If Len(testo) < intervallo Then
                    CreaWave(testo, NomeFile)
                Else
                    NumParti = DividiInParti2(testo)
                    ' crea le diverse parti
                    Dim NomeTemp(NumParti) As String
                    For k = 1 To NumParti
                        NomeTemp(k) = CartellaTemp & "tpWave" & k & ".wav"
                        CreaWave(Parte(k), NomeTemp(k))
                    Next
                    Unisci(NumParti, NomeFile)
                End If

                If blnMP3 = True Then
                    ConvertiMP3(NomeFile)
                End If
            End If
        Catch e As Exception
            MsgBox(e.ToString)
        End Try

        frm.Cursor = Cursors.Default

    End Sub

    Sub SalvaImmaginePresenteInClipboard()
        If blnStoSalvando = True Then Exit Sub

        If Clipboard.ContainsImage Then
            Dim SalvaImmagine As New SaveFileDialog()
            SalvaImmagine.Filter = "Immagine (*.jpg)|*.jpg"
            SalvaImmagine.FileName = "Immagine.jpg"
            SalvaImmagine.Title = "Salva Immagine - LeggiXme"
            SalvaImmagine.RestoreDirectory = True
            blnStoSalvando = True

            If SalvaImmagine.ShowDialog() = DialogResult.OK Then
                Dim img As Image
                Try
                    img = Clipboard.GetImage
                    img.Save(SalvaImmagine.FileName, System.Drawing.Imaging.ImageFormat.Jpeg)
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End If
            blnStoSalvando = False
        End If
    End Sub

    Private Sub btnNuovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNuovo.Click
        If ChiediSalva() = True Then Exit Sub
        RTB.Text = ""
    End Sub

    Private checkPrint As Integer

    Private Sub btnStampa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStampa.Click
        If PrintDialog1.ShowDialog() = DialogResult.OK Then
            PrintDocument1.Print()
        End If
    End Sub

    Private Sub PrintDocument1_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDocument1.BeginPrint
        checkPrint = 0
    End Sub

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        ' Print the content of the RichTextBox. Store the last character printed.
        checkPrint = RTB.Print(checkPrint, RTB.TextLength, e)

        ' Look for more pages
        If checkPrint < RTB.TextLength Then
            e.HasMorePages = True
        Else
            e.HasMorePages = False
        End If
    End Sub

    Private Sub btnPrintPreview_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnteprimaDiStampa.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub btnImpostaPagina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImpostaPagina.Click
        PageSetupDialog1.ShowDialog()
    End Sub

    Private Sub btnASinistra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnASinistra.Click
        RTB.SelectionAlignment = HorizontalAlignment.Left
    End Sub

    Private Sub btnCentra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCentra.Click
        RTB.SelectionAlignment = HorizontalAlignment.Center
    End Sub

    Private Sub btnADestra_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADestra.Click
        RTB.SelectionAlignment = HorizontalAlignment.Right
    End Sub

    Sub CaratteriSpeciali()

        c(1) = Chr(196) : car1.Text = c(1)
        c(2) = Chr(228) : car2.Text = c(2)
        c(3) = Chr(214) : car3.Text = c(3)
        c(4) = Chr(246) : car4.Text = c(4)
        c(5) = Chr(220) : car5.Text = c(5)
        c(6) = Chr(252) : car6.Text = c(6)
        c(7) = Chr(216) : car7.Text = c(7)
        c(8) = Chr(248) : car8.Text = c(8)
        c(9) = Chr(199) : car9.Text = c(9)
        c(10) = Chr(231) : car10.Text = c(10)
        c(11) = Chr(209) : car11.Text = c(11)
        c(12) = Chr(241) : car12.Text = c(12)
        c(13) = Chr(191) : car13.Text = c(13)
        c(14) = Chr(161) : car14.Text = c(14)

        c(15) = Chr(192) : car15.Text = c(15)
        c(16) = Chr(200) : car16.Text = c(16)
        c(17) = Chr(201) : car17.Text = c(17)
        c(18) = Chr(204) : car18.Text = c(18)
        c(19) = Chr(210) : car19.Text = c(19)
        c(20) = Chr(217) : car20.Text = c(20)

        c(21) = Chr(194) : car21.Text = c(21)
        c(22) = Chr(226) : car22.Text = c(22)
        c(23) = Chr(202) : car23.Text = c(23)
        c(24) = Chr(234) : car24.Text = c(24)
        c(25) = Chr(206) : car25.Text = c(25)
        c(26) = Chr(238) : car26.Text = c(26)
        c(27) = Chr(212) : car27.Text = c(27)
        c(28) = Chr(244) : car28.Text = c(28)
        c(29) = Chr(219) : car29.Text = c(29)
        c(30) = Chr(251) : car30.Text = c(30)
        c(31) = Chr(223) : car31.Text = c(31)
        Me.Refresh()

    End Sub

    Private Sub btnSpeciali_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSpeciali.Click
        SistemaPnCaratteri()
    End Sub

    Private Sub SistemaPnCaratteri()
        If pnCaratteri.Visible = True Then
            pnCaratteri.Visible = False
        Else
            pnCaratteri.Visible = True
        End If
        SistemaMisureRTB()
    End Sub

    Private Sub SistemaMisureRTB()
        If blnMenuVisibile = False Then
            If pnCaratteri.Visible = True Then
                pnCaratteri.Top = 45
                RTB.Top = 85
            Else
                RTB.Top = 45
            End If
        Else
            If pnCaratteri.Visible = True Then
                pnCaratteri.Top = 85
                RTB.Top = 125
            Else
                RTB.Top = 85
            End If
        End If
        RTB.Height = Me.Height - RTB.Top - 40
        panErrori.Top = RTB.Top
        'If RTB.Top = 120 Then
        ' RTB.Top = 88
        'RTB.Height += 32
        'Else
        'RTB.Top = 120
        'RTB.Height -= 32
        'End If

    End Sub

    Private Sub btnZoomPiu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomPiu.Click
        If RTB.ZoomFactor < 5 Then
            RTB.ZoomFactor = CSng(RTB.ZoomFactor + 0.1)
            FattoreZoom = RTB.ZoomFactor
        End If
    End Sub

    Private Sub btnZoomMeno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomMeno.Click
        If RTB.ZoomFactor > 0.2 Then
            RTB.ZoomFactor = CSng(RTB.ZoomFactor - 0.1)
            FattoreZoom = RTB.ZoomFactor
        End If
    End Sub

    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
        If pnFile.Visible = True Then
            ResettaBottoni()
        Else
            ResettaBottoni()
            pnFile.Visible = True
            btnFile.BackColor = Color.LightGreen
            blnMenuVisibile = True
        End If
        SistemaMisureRTB()

    End Sub

    Private Sub btnModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModifica.Click
        If pnModifica.Visible = True Then
            ResettaBottoni()
        Else
            ResettaBottoni()
            pnModifica.Visible = True
            btnModifica.BackColor = Color.LightGreen
            blnMenuVisibile = True
        End If
        SistemaMisureRTB()
    End Sub

    Private Sub btnVisualizza_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVisualizza.Click
        If pnVisualizza.Visible = True Then
            ResettaBottoni()
        Else
            ResettaBottoni()
            pnVisualizza.Visible = True
            btnVisualizza.BackColor = Color.LightGreen
            blnMenuVisibile = True
        End If
        SistemaMisureRTB()

    End Sub

    Private Sub btnAudio_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAudio.Click
        Static vc As Integer
        If pnAudio.Visible = True Then
            Voice2.Rate = vc
            ResettaBottoni()
        Else
            vc = Voice2.Rate
            ResettaBottoni()
            pnAudio.Visible = True
            btnAudio.BackColor = Color.LightGreen
            blnMenuVisibile = True
        End If
        SistemaMisureRTB()
    End Sub

    Private Sub btnProva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProva.Click
        'Voice2.Voice = Voice.Voice 
        'Voice.SelectVoice(Parlante)
        Voice.Rate = Velocita
        Voice.SpeakAsync("Questo è un testo di prova.")
        'Leggi1("velocità " & Voice2.Rate)
        'Voice2.Voice = Voice.GetVoices().Item(VocePrincipale)
        'Voice2.Rate = vc
    End Sub

    Private Sub btnZoomVia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZoomVia.Click
        RTB.ZoomFactor = 1
        FattoreZoom = 1
    End Sub

    Private Sub cmdLeggi_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles cmdLeggi.DragDrop
        'FileDaAprire = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString

        'MsgBox("letto")

    End Sub

    Private Sub cmdLeggi_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles cmdLeggi.DragEnter
        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            FileDaAprire = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
            Dim est As String = ext(FileDaAprire)
            If est = "" Then Exit Sub
            est = UCase(Mid(est, 2))
            'If est = "PDF" Then
            If blnAperto = False Then
                e.Effect = DragDropEffects.Copy
            End If
            'cmdImposta.Cursor = New Cursor("pdf.cur")
            'End If
        End If
    End Sub

    Private Sub cmdLeggi_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdLeggi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Leggi")
        End If
    End Sub

    Private Sub cmdImposta_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles cmdImposta.DragDrop
        FileDaAprire = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
        Dim est As String = ext(FileDaAprire)
        If est = "" Then Exit Sub
        est = UCase(Mid(est, 2))
        Try
            Select Case est
                Case "PDF"

                    If pnTrova.Visible = False Then
                        ResettaBottoni()
                        'pnDocumenti.Visible = True
                        btnDocumenti.BackColor = Color.LightGreen
                        'blnMenuVisibile = True
                        SistemaMisureRTB()
                    End If

                    frmPDF.Show()
                    ApriFinestra()
                    Me.Hide()
                Case Else
                    Process.Start(FileDaAprire)
                    'Case "DOC", "RTF", "TXT", "ODT"
                    '   frmWRD.Show()
                    '  ApriFinestra()
                    ' Me.Hide()
                    'Case "HTM", "HTML", "MHT"
                    ' frmINT.Show()
                    ' Me.WindowState = FormWindowState.Maximized
                    ' Me.Hide()
                    'Case Else
                    'MsgBox("ATTENZIONE! Il programma non può aprire un file di questo tipo: " & est, MsgBoxStyle.Exclamation And MsgBoxStyle.Information)
            End Select
        Catch ex As Exception

        End Try
    End Sub

    Dim blnApriCartella As Boolean = False

    Private Sub cmdImposta_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles cmdImposta.DragEnter

        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            FileDaAprire = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
            Dim file As String = (System.IO.Path.GetFileName(FileDaAprire))
            file = file.Replace("_", " ")
            Leggi2(file)
            Dim attributes As System.IO.FileAttributes = System.IO.File.GetAttributes(FileDaAprire)
            If (attributes And FileAttributes.Directory) = FileAttributes.Directory Then
                blnApriCartella = True
            End If
            Dim est As String = ext(FileDaAprire)
            If est <> "" Then est = UCase(Mid(est, 2))
            If blnAperto = False Then
                e.Effect = DragDropEffects.Copy
            End If
        End If
        If FileDaAprire = "" Then Exit Sub

    End Sub

    Private Sub cmdImposta_DragLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImposta.DragLeave
        FermaVoce2()
    End Sub

    Private Sub cmdImposta_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdImposta.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Accesso al testo e agli strumenti")
        Else
            FermaVoce2()
        End If
        If blnApriCartella = True Then
            blnApriCartella = False
            Process.Start("explorer.exe", FileDaAprire)
        End If
    End Sub

    Private Sub btnFile_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnFile.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("faail")
        End If
    End Sub

    Private Sub btnModifica_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnModifica.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Modifica")
        End If
    End Sub

    Private Sub btnVisualizza_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnVisualizza.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Visualizza")
        End If
    End Sub

    Private Sub btnAudio_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAudio.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Audio")
        End If
    End Sub

    Private Sub cmdMenoVel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdMenoVel.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Diminuisci velocità")
        End If
    End Sub

    Private Sub cmdPiuVel_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdPiuVel.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Aumenta velocità")
        End If
    End Sub

    Private Sub btnProva_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnProva.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Prova voce")
        End If
    End Sub

    Private Sub btnWave_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnWave.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Salva come faail ueeiv")
        End If
    End Sub

    Private Sub btnSpeciali_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSpeciali.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("mostra caratteri stranieri")
        End If
    End Sub

    Private Sub btnZoomPiu_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZoomPiu.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Aumenta lo zoom")
        End If
    End Sub

    Private Sub btnZoomMeno_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZoomMeno.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("diminuisci lo zoom")
        End If
    End Sub

    Private Sub btnZoomVia_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnZoomVia.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("visualizzazione normale")
        End If
    End Sub

    Private Sub chkTrasparente_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles chkTrasparente.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Trasparenza della finestra dei comandi ridotta")
        End If
    End Sub

    Private Sub btnNuovo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnNuovo.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("nuovo documento")
        End If
    End Sub

    Private Sub btnSalva_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSalva.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("salva documento")
        End If
    End Sub

    Private Sub btnApri_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnApri.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("apri documento")
        End If
    End Sub

    Private Sub btnImpostaPagina_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnImpostaPagina.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("imposta pagina")
        End If
    End Sub

    Private Sub btnAnteprimaDiStampa_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAnteprimaDiStampa.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("anteprima di stampa")
        End If
    End Sub

    Private Sub btnStampa_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnStampa.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("stampa documento")
        End If
    End Sub

    Private Sub btnImmagine_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnImmagine.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("inserisci clipart")
        End If
    End Sub

    Private Sub btnCarattere_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCarattere.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("seleziona carattere")
        End If
    End Sub

    Private Sub btnColore_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnColore.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("colore del testo")
        End If
    End Sub

    Private Sub btnASinistra_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnASinistra.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("allineamento a sinistra")
        End If
    End Sub

    Private Sub btnCentra_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCentra.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("allineamento centrato")
        End If
    End Sub

    Private Sub btnADestra_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnADestra.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Allineamento a destra")
        End If
    End Sub

    Private Sub btnBold_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBold.Click
        On Error Resume Next
        Dim Grassetto As Integer = 0
        If RTB.SelectionFont.Bold = True Then Grassetto = 1
        Dim Corsivo As Integer = 0
        If RTB.SelectionFont.Italic = True Then Corsivo = 2
        Dim Sottolineato As Integer = 0
        If RTB.SelectionFont.Underline = True Then Sottolineato = 4

        If Grassetto = 0 Then
            Grassetto = 1
        Else
            Grassetto = 0
        End If

        Dim stile As Integer = Grassetto + Corsivo + Sottolineato

        ImpostaIlFont(stile)

    End Sub

    Private Sub btnCorsivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorsivo.Click
        On Error Resume Next
        Dim Grassetto As Integer = 0
        If RTB.SelectionFont.Bold = True Then Grassetto = 1
        Dim Corsivo As Integer = 0
        If RTB.SelectionFont.Italic = True Then Corsivo = 2
        Dim Sottolineato As Integer = 0
        If RTB.SelectionFont.Underline = True Then Sottolineato = 4

        If Corsivo = 0 Then
            Corsivo = 2
        Else
            Corsivo = 0
        End If

        Dim stile As Integer = Grassetto + Corsivo + Sottolineato

        ImpostaIlFont(stile)
    End Sub

    Private Sub btnSottolineato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSottolineato.Click
        On Error Resume Next
        Dim Grassetto As Integer = 0
        If RTB.SelectionFont.Bold = True Then Grassetto = 1
        Dim Corsivo As Integer = 0
        If RTB.SelectionFont.Italic = True Then Corsivo = 2
        Dim Sottolineato As Integer = 0
        If RTB.SelectionFont.Underline = True Then Sottolineato = 4

        If Sottolineato = 0 Then
            Sottolineato = 4
        Else
            Sottolineato = 0
        End If

        Dim stile As Integer = Grassetto + Corsivo + Sottolineato

        ImpostaIlFont(stile)
    End Sub

    Private Sub ImpostaIlFont(ByVal stile As Integer)

        Dim textStyle As New FontStyle
        Select Case stile
            Case 1 : textStyle = FontStyle.Bold
            Case 2 : textStyle = FontStyle.Italic
            Case 3 : textStyle = FontStyle.Bold Or FontStyle.Italic
            Case 4 : textStyle = FontStyle.Underline
            Case 5 : textStyle = FontStyle.Bold Or FontStyle.Underline
            Case 6 : textStyle = FontStyle.Italic Or FontStyle.Underline
            Case 7 : textStyle = FontStyle.Bold Or FontStyle.Italic Or FontStyle.Underline
        End Select

        Dim bfont As New Font(RTB.Font, textStyle)

        RTB.SelectionFont = New Font(RTB.SelectionFont, textStyle)

    End Sub

    Private Sub btnBold_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnBold.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Grassetto")
        End If
    End Sub

    Private Sub btnCorsivo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCorsivo.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Corsivo")
        End If
    End Sub

    Private Sub btnSottolineato_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSottolineato.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Sottolineato")
        End If
    End Sub

    Private Sub cmdChiudi_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdChiudi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Riduci la finestra")
        End If
    End Sub

    Private Sub ResettaBottoni()

        blnMenuVisibile = False

        pnFile.Visible = False
        pnAudio.Visible = False
        pnModifica.Visible = False
        pnVisualizza.Visible = False
        pnOrtografia.Visible = False
        NascondiCorrettore()
        pnSpeciale.Visible = False
        pnTrova.Visible = False
        btnFile.BackColor = Color.LightGray
        btnModifica.BackColor = Color.LightGray
        btnVisualizza.BackColor = Color.LightGray
        btnAudio.BackColor = Color.LightGray
        btnDocumenti.BackColor = Color.LightGray
        If pnCaratteri.Visible = True Then
            SistemaPnCaratteri()
            'pnCaratteri.Visible = False
        End If
    End Sub

    Private Sub chkTrasparente_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkTrasparente.CheckedChanged
        blnTrasparente = (chkTrasparente.Checked = True)
    End Sub

    Private Sub RTB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RTB.Click
        inizio = RTB.SelectionStart
        iniz = RTB.SelectionStart + 1
        'If RTB.SelectionType.ToString = "Empty" Then
        '  iniz = RTB.SelectionStart + 1
        '  RTB.Cursor = Cursors.IBeam
        'Else
        '  RTB.Cursor = Cursors.Default
        'End If

    End Sub

    Private Sub RTB_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RTB.MouseDown

        If m_bSpeaking = True Or m_bPaused = True Then
            FermaLettura()
        End If

        If RTB.SelectedText <> "" Then MousePremuto = True

        'inizio = RTB.SelectionStart
        'iniz = RTB.SelectionStart + 1

    End Sub

    Private Sub car1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles car1.Click, car2.Click, car3.Click, _
    car4.Click, car5.Click, car6.Click, car7.Click, car8.Click, car9.Click, car10.Click, car11.Click, car12.Click, car13.Click, car14.Click, _
    car15.Click, car16.Click, car17.Click, car18.Click, car19.Click, car20.Click, car21.Click, car22.Click, car23.Click, car24.Click, _
    car25.Click, car26.Click, car27.Click, car28.Click, car29.Click, car30.Click, car31.Click

        Dim a As String = ""
        If sender.Equals(car1) Then
            a = car1.Text
        ElseIf sender.Equals(car2) Then
            a = car2.Text
        ElseIf sender.Equals(car3) Then
            a = car3.Text
        ElseIf sender.Equals(car4) Then
            a = car4.Text
        ElseIf sender.Equals(car5) Then
            a = car5.Text
        ElseIf sender.Equals(car6) Then
            a = car6.Text
        ElseIf sender.Equals(car7) Then
            a = car7.Text
        ElseIf sender.Equals(car8) Then
            a = car8.Text
        ElseIf sender.Equals(car9) Then
            a = car9.Text
        ElseIf sender.Equals(car10) Then
            a = car10.Text
        ElseIf sender.Equals(car11) Then
            a = car11.Text
        ElseIf sender.Equals(car12) Then
            a = car12.Text
        ElseIf sender.Equals(car13) Then
            a = car13.Text
        ElseIf sender.Equals(car14) Then
            a = car14.Text
        ElseIf sender.Equals(car15) Then
            a = car15.Text
        ElseIf sender.Equals(car16) Then
            a = car16.Text
        ElseIf sender.Equals(car17) Then
            a = car17.Text
        ElseIf sender.Equals(car18) Then
            a = car18.Text
        ElseIf sender.Equals(car19) Then
            a = car19.Text
        ElseIf sender.Equals(car20) Then
            a = car20.Text
        ElseIf sender.Equals(car21) Then
            a = car21.Text
        ElseIf sender.Equals(car22) Then
            a = car22.Text
        ElseIf sender.Equals(car23) Then
            a = car23.Text
        ElseIf sender.Equals(car24) Then
            a = car24.Text
        ElseIf sender.Equals(car25) Then
            a = car25.Text
        ElseIf sender.Equals(car26) Then
            a = car26.Text
        ElseIf sender.Equals(car27) Then
            a = car27.Text
        ElseIf sender.Equals(car28) Then
            a = car28.Text
        ElseIf sender.Equals(car29) Then
            a = car29.Text
        ElseIf sender.Equals(car30) Then
            a = car30.Text
        ElseIf sender.Equals(car31) Then
            a = car31.Text
        End If
        Try
            Clipboard.SetText(a)
            RTB.Paste()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub MioTimer_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MioTimer.Tick
        Dim tmp As IntPtr = Nothing
        tmp = GetForegroundWindow
        If tmp <> Me.Handle And tmp <> Nothing And tmp <> altroHandle Then
            altroHandle = tmp
        End If

    End Sub

    Private Sub RTB_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles RTB.KeyPress

        If m_bSpeaking = True Or m_bPaused = True Then
            FermaLettura()
        Else
            Dim KeyAscii As Integer = Asc(e.KeyChar)

            Dim c As Integer
            c = KeyAscii

            If ckLeggeParola.CheckState = 1 Then
                blnLeggereParola = False
                If InStr(spaziFine, Chr(c)) <> 0 Then blnLeggereParola = FormaParola()
            End If
            If ckLeggeFrase.CheckState = CheckState.Checked Then
                If c = Asc(".") Or c = Asc("!") Or c = Asc("?") Then
                    blnLeggiFrase = True
                End If
            End If
            e.KeyChar = Chr(KeyAscii)
            If KeyAscii = 0 Then
                e.Handled = True
            End If
        End If

    End Sub

    Sub LeggiTutto()

        If Ridotta() = True Then Exit Sub

        RTB.SelectionStart = 0
        RTB.SelectionLength = 0
        inizio = RTB.SelectionStart
        iniz = RTB.SelectionStart + 1

        Leggi()

    End Sub

    Private Sub RTB_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles RTB.KeyUp
        Dim KeyCode As Integer = e.KeyCode
        Dim Shift As Integer = e.KeyData \ &H10000
        If blnLeggereParola = True Then
            Leggi2(UnaParola)
            blnLeggereParola = False
            'If blnInserisciImmagine = False Then UnaParola = ""
        End If
        If blnLeggiFrase = True Then
            blnLeggiFrase = False
            'RTB.SelectionStart = start
            LeggiLaFrase()
        End If
        'If blnInserisciImmagine = True Then
        ' InserisciImmagine()
        'If blnLeggereParola = False Then UnaParola = ""
        'blnInserisciImmagine = False
        'End If
    End Sub

    Private Sub Label4_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label4.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2(Label4.Text)
        End If
    End Sub

    Private Sub Label2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label2.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2(Label2.Text)
        End If
    End Sub

    Private Sub ckLeggeParola_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ckLeggeParola.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2(ckLeggeParola.Text)
        End If
    End Sub

    Private Sub btnEvidenzia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEvidenzia.Click

        If RTB.SelectionBackColor = Color.White Then 'RTB.BackColor Then
            RTB.SelectionBackColor = ColoreEvidenziato
        Else
            RTB.SelectionBackColor = RTB.BackColor
        End If
        RTB.Focus()

        Exit Sub

        If RTB.SelectionBackColor.R = 0 Then 'ColoreEvidenziato.B Then '   Yellow Then
            If RTB.SelectionBackColor.G = ColoreEvidenziato.G Then
                RTB.SelectionBackColor = RTB.BackColor 'ColoreSfondo 'Color.White
            Else
                RTB.SelectionBackColor = Color.Yellow
            End If
        Else
            If RTB.SelectionBackColor = Color.Yellow Then
                RTB.SelectionBackColor = ColoreEvidenziato2
            Else
                RTB.SelectionBackColor = ColoreEvidenziato
            End If
        End If

    End Sub

    Private Sub btnEvidenzia_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnEvidenzia.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("evidenziatore")
        End If
    End Sub

    Private Sub btnLeggiEvidenziato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeggiEvidenziato.Click
        If voce2speaking = True Then
            FermaVoce2()
        End If
        If blnSelez = True Then
            Leggi2(TestoEvidenziato)
        Else
            Leggi2(TestoNonEvidenziato)
        End If
    End Sub

    Private Sub btnLeggiEvidenziato_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnLeggiEvidenziato.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            If blnSelez = True Then
                Leggi2("LEGGE IL TESTO EVIDENZIATO")
            Else
                Leggi2("LEGGE IL TESTO NON EVIDENZIATO")
            End If
        End If
    End Sub

    Private Sub btnCopiaEvidenziatoeVIDENZIATO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiaEvidenziato.Click

        Dim Testo As String = ""
        If blnSelez = True Then
            Testo = TestoEvidenziato()
        Else
            Testo = TestoNonEvidenziato()
        End If
        If Testo = "" Then Exit Sub
        My.Computer.Clipboard.SetText(Testo)
    End Sub

    Private Sub TogliEvidenziato()

        RTB.SelectAll()
        RTB.SelectionBackColor = Color.White
        RTB.SelectionStart = 1
        RTB.SelectionLength = 0

    End Sub

    Private Function TestoEvidenziato() As String
        Dim tempo As String = ""
        Dim i As Integer = 0
        For i = 0 To Len(RTB.Text) - 1
            RTB.SelectionStart = i
            RTB.SelectionLength = 1
            If RTB.SelectionBackColor.R = 0 Then 'ColoreEvidenziato Then
                tempo = tempo & RTB.SelectedText ' & " "
            Else
                If tempo <> "" Then
                    If Mid(tempo, Len(tempo), 1) <> " " Then
                        tempo = tempo & " "
                    End If
                End If
            End If
        Next
        RTB.SelectionLength = 0
        TestoEvidenziato = tempo
    End Function

    Private Function TestoNonEvidenziato() As String
        Dim tempo As String = ""
        Dim i As Integer = 0
        For i = 0 To Len(RTB.Text) - 1
            RTB.SelectionStart = i
            RTB.SelectionLength = 1
            If RTB.SelectionBackColor.R = 255 Then ' <> ColoreEvidenziato Then
                tempo = tempo & RTB.SelectedText ' & " "
            End If
        Next
        RTB.SelectionLength = 0
        TestoNonEvidenziato = tempo
    End Function

    Private Sub btnSalvaEvidenziato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalvaEvidenziato.Click

        Dim Testo As String = ""
        If blnSelez = True Then
            Testo = TestoEvidenziato()
        Else
            Testo = TestoNonEvidenziato()
        End If

        Dim SalvaTesto As New SaveFileDialog()
        SalvaTesto.Filter = "txt files (*.txt)|*.txt"
        SalvaTesto.FilterIndex = 1
        SalvaTesto.RestoreDirectory = True

        If SalvaTesto.ShowDialog() = DialogResult.OK Then
            Dim res As Boolean = SaveTextToFile(Testo, SalvaTesto.FileName)
            If res = False Then
                MsgBox("SALVATAGGIO NON RIUSCITO!", MsgBoxStyle.Critical)
            End If
        End If

    End Sub

    Private Sub btnSintesi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSintesi.Click
        If pnSpeciale.Visible = True Then
            ResettaBottoni()
            'RTB.SelectAll()
            'RTB.SelectionBackColor = Color.White
            'RTB.SelectionLength = 0
            TogliEvidenziato()
            btnAnnullaEvidenzia.Enabled = False
        Else
            TogliEvidenziato()
            IgnoraTutto()
            ResettaBottoni()
            pnSpeciale.Visible = True
            btnSintesi.BackColor = Color.LightGreen
            blnMenuVisibile = True
        End If
        SistemaMisureRTB()
    End Sub

    Private Sub btnSintesi_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSintesi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("evidenzia e riassumi")
        End If
    End Sub

    Private Sub btnSalvaEvidenziato_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSalvaEvidenziato.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2(ToolTip1.GetToolTip(btnSalvaEvidenziato))
        End If
    End Sub

    Private Sub btnCorrettore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorrettore.Click
        Correttore()
    End Sub

    Sub ScegliLingua()
        Select Case Lingua(cbVoci.FindString(Parlante))
            Case Italiano
                If dizionario <> "it_IT" Then
                    dizionario = "it_IT"
                    DizSinonimi = "th_it_IT.txt"
                    lblLingua.Text = "ITALIANO"
                    DizionarioUtente = "utente_it.diz"
                End If
            Case Inglese, Britannico, IngleseUK
                If dizionario <> "en_GB" Then
                    dizionario = "en_GB"
                    DizSinonimi = "th_en_GB_final.txt"
                    lblLingua.Text = "INGLESE"
                    DizionarioUtente = "utente_en.diz"
                End If
            Case Francese
                If dizionario <> "fr-classique+reforme1990" Then
                    dizionario = "fr-classique+reforme1990"
                    DizSinonimi = "thes_fr.txt"
                    DizionarioUtente = "utente_fr.diz"
                    lblLingua.Text = "FRANCESE"
                End If
            Case Tedesco
                If dizionario <> "de_DE_frami" Then
                    dizionario = "de_DE_frami"
                    DizSinonimi = "th_de_DE_v2.txt"
                    lblLingua.Text = "TEDESCO"
                    DizionarioUtente = "utente_de.diz"
                End If
            Case Spagnolo
                If dizionario <> "es_ES" Then
                    dizionario = "es_ES"
                    DizSinonimi = "th_es_ES_v2.txt"
                    lblLingua.Text = "SPAGNOLO"
                    DizionarioUtente = "utente_es.diz"
                End If
            Case Else
                MsgBox(Lingua(cbVoci.FindString(Parlante)))
                MsgBox("Purtroppo le uniche lingue supportate sono:" & vbCrLf & "ITALIANO INGLESE FRANCESE TEDESCO SPAGNOLO", MsgBoxStyle.MsgBoxSetForeground)
                Exit Sub
        End Select
        lblLingua2.Text = lblLingua.Text
        CaricaDizionarioUtente()

    End Sub

    Sub Correttore()

        If pnOrtografia.Visible = True Then
            ResettaBottoni()
            'NascondiCorrettore()
        Else
            ResettaBottoni()
            pnOrtografia.Visible = True
            'pnOrtografia.BackColor = Color.LightGreen
            blnMenuVisibile = True
            ScegliLingua()
        End If
        SistemaMisureRTB()

    End Sub

    Sub NascondiCorrettore()
        blnMostaErrori = False
        panErrori.Visible = False
        RisistemaRTB()
        IgnoraTutto()
    End Sub
    Private Sub cmdStop_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdStop.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2(" Arresta la lettura")
        End If
    End Sub

    Private Sub btnCalcola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcola.Click
        frmCalcolatrice.Show()
    End Sub

    Private Sub btnAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnulla.Click
        If RTB.CanUndo Then
            RTB.Undo()
        End If
    End Sub

    Private Sub btnRipristina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRipristina.Click
        If RTB.CanRedo Then
            RTB.Redo()
        End If
    End Sub

    Private Sub C5_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C5.CheckedChanged
        MaxSuggerimenti = 5
    End Sub

    Private Sub c10_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles c10.CheckedChanged
        MaxSuggerimenti = 10
    End Sub

    Private Sub cTutte_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cTutte.CheckedChanged
        MaxSuggerimenti = 100
    End Sub

    Private Sub btnCorrettore_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCorrettore.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("AVVIA IL CORRETTORE ORTOGRAFICO")
        End If
    End Sub

    Private Sub btnCalcola_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCalcola.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("calcolatrice")
        End If
    End Sub

    Private Sub btnCopiaEvidenziato_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCopiaEvidenziato.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2(ToolTip1.GetToolTip(btnCopiaEvidenziato))
        End If
    End Sub

    Private Sub btnAnnulla_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAnnulla.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("ANNULLA")
        End If
    End Sub

    Private Sub btnRipristina_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRipristina.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("RIPRISTINA")
        End If
    End Sub

    Private Sub btnTrovaErrori_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrovaErrori.Click

        If pnOrtografia.Visible = True Then
            'ResettaBottoni()
            blnMostaErrori = False
            panErrori.Visible = False
            'RisistemaRTB()
            IgnoraTutto()
        End If
        RisistemaRTB()
        If RTB.TextLength = 0 Then Exit Sub
        SegnaErrori()
    End Sub

    Private Sub btnCorreggiErrori_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCorreggiErrori.Click
        If RTB.TextLength = 0 Then Exit Sub
        If pnCaratteri.Visible = True Then
            pnCaratteri.Visible = False
            'SistemaMisureRTB()
        End If
        CorreggiErrori()
    End Sub

    Private Sub CorreggiErrori()
        IgnoraTutto()
        'SegnaErrori()
        blnMostaErrori = True
        RisistemaRTB()
        panErrori.Top = RTB.Top
        panErrori.Visible = True
        lblTrovati.Text = "ATTENDERE..."
        Me.Refresh()
        'MsgBox(Me.Width)
        Ortografia()
    End Sub

    Private Sub btnTrovaErrori_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTrovaErrori.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("CERCA GLI ERRORI")
        End If

    End Sub

    Private Sub btnCorreggiErrori_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCorreggiErrori.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("CORREGGI GLI ERRORI")
        End If

    End Sub

    Private Sub cmdImposta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdImposta.Click

        'If Me.Width > larghezza Then
        If blnfinestraaperta = True Then
            ChiudiFinestra()
        Else
            ApriFinestra()
        End If
    End Sub

    Sub ApriFinestra()

        MioTimer.Enabled = False
        blnFinestraAperta = True
        blnHoAperto = True
        NascondiPausa()
        cmdTraduci.Enabled = False
        Me.MaximizeBox = True
        Me.Width = 800 : Me.Height = 540
        Me.TopMost = False
        Me.WindowState = FormWindowState.Maximized
        res = RendiOpaco(Me.Handle.ToInt32)
        RTB.Focus()
        blnAperto = True
        tmrSalva.Enabled = True

    End Sub


    Sub ComandoRipeti()
        RTB.SelectionStart = VecchioInizio
        RTB.SelectionLength = VecchiaLunghezza
        LeggiMi(RTB.SelectedText)

    End Sub

    Sub ComandoUnaFrase()
        blnLeggiUnaFrase = True
        blnLeggiUnaFrasePerVolta = False
        iniz = RTB.SelectionStart
        LeggiUnaFrase()

    End Sub

    Private Sub cmdPausa_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdPausa.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Pausa lettura")
        End If
    End Sub

    Private Sub cmdPausa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPausa.Click
        PausaLettura()
    End Sub

    Sub SegnaErrori()
        'Dim U As New Underline(Me.RTB)
        Dim p As Integer = 0
        Me.Cursor = Cursors.WaitCursor

        TrovaErrori()
        Dim k As Integer
        For k = 1 To NumErrori
            RTB.Find(errata(k), p, Len(RTB.Text), RichTextBoxFinds.WholeWord)
            'RTB.SelectionBackColor = Color.LightPink
            'U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave
            'U.SelectionUnderlineColor = Underline.UnderlineColor.Red
            MettiOnda()
            p = RTB.SelectionStart + RTB.SelectionLength
        Next
        RTB.SelectionStart = 0
        RTB.SelectionLength = 0
        Me.Cursor = Cursors.Default

    End Sub

    Sub TrovaErrori()
        Dim i As Integer = 0, k As Integer = 0, h As Integer = 0
        Dim ProcID As Integer = 0
        Dim parola As String = ""

        'My.Computer.FileSystem.WriteAllText(Percorso & "\testo.txt", RTB.Text, False, System.Text.Encoding.GetEncoding(28605))
        My.Computer.FileSystem.WriteAllText(CartellaTemp & "testo.txt", RTB.Text, False, System.Text.Encoding.GetEncoding(28605))
        comando = FormaComando()
        ProcID = Shell(comando, AppWinStyle.Hide, Wait:=True)

        NumErrori = 0
        Dim f As Integer = FreeFile()
        'Dim lett As String = "errori.txt"
        Dim lett As String = CartellaTemp & "errori.txt"
        FileOpen(f, lett, OpenMode.Input)
        While Not EOF(f)
            parola = LineInput(f)
            If parola <> "" Then
                If Asc(parola) = 38 Then
                    NumErrori = NumErrori + 1
                    If NumErrori > MaxErrori Then
                        MsgBox("In questo testo vi sono più di " & MaxErrori & " errori: sarebbe follia correggerlo.", MsgBoxStyle.Critical)
                        Exit Sub
                    End If
                    lemma(NumErrori) = Mid(parola, 3)
                    i = InStr(lemma(NumErrori), " ") - 1
                    errata(NumErrori) = Mid(lemma(NumErrori), 1, i)
                    Select Case LCase(errata(NumErrori))
                        Case "all", "coll", "dall", "dell", "nell", "sull", "bell", "quell", "quest"
                            errata(NumErrori) = ""
                            lemma(NumErrori) = ""
                    End Select
                End If
            End If
        End While
        FileClose(f)

        Dim quanti As Integer = NumErrori
        If lemma(NumErrori) = "" Then quanti = NumErrori - 1
        For k = NumErrori - 1 To 1 Step -1
            If lemma(k) = "" Then
                For h = k To NumErrori - 1
                    lemma(h) = lemma(h + 1)
                    errata(h) = errata(h + 1)
                Next
                quanti = quanti - 1
                lemma(NumErrori) = ""
                errata(NumErrori) = ""
            End If
        Next

        NumErrori = quanti

        If NumLemmiUtente > 0 Then
            RiduciErroriConDizUtente()
        End If
    End Sub

    Sub RiduciErroriConDizUtente()
        Dim k As Integer = 0, h As Integer = 0
        For k = NumErrori To 1 Step -1
            If CeLaParola(errata(k)) Then
                errata(h) = ""
                lemma(h) = ""
                NumErrori -= 1
                For h = k To NumErrori
                    errata(h) = errata(h + 1)
                    lemma(h) = lemma(h + 1)
                Next
            End If
        Next
    End Sub

    Sub Ortografia()

        Dim k As Integer = 0, h As Integer = 0, ps As Integer = 0
        Dim inizio As Integer = 0, fine As Integer = 0
        Dim Primo As Integer = 0
        Me.Cursor = Cursors.WaitCursor

        TrovaErrori()
        ' aggiungere possibile riduzione da diz utente

        lbErrate.Items.Clear()
        lbSuggerimenti.Items.Clear()
        lbPos.Items.Clear()

        If NumErrori < 0 Then NumErrori = 0
        For k = 1 To NumErrori
            lbErrate.Items.Add(errata(k))
            lbPos.Items.Add(ps)
            ps = RTB.Find(errata(k), ps, Len(RTB.Text), RichTextBoxFinds.WholeWord)
        Next

        For k = 1 To NumErrori
            NumSuggerimenti(k) = 0
            For h = 1 To MassSuggerimenti 'MaxSuggerimenti
                Suggerimenti(k, h) = ""
            Next h
        Next k

        lblTrovati.Text = "ERRORI TROVATI " & NumErrori

        '^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        ' aggiunge i suggerimenti da Diz utente in testa
        If NumLemmiUtente > 0 Then
            For k = 1 To NumErrori
                CercaCorrezione(errata(k))
                If NumParCorrette > 0 Then
                    NumSuggerimenti(k) = NumParCorrette
                    For h = 1 To NumParCorrette
                        Suggerimenti(k, h) = ParCorretta(h)
                    Next
                End If
            Next
        End If
        ' il blocco sopra va inserito sotto, con ricerca di suggerimenti se i suggerimenti sono 0
        ' ^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
        For k = 1 To NumErrori
            inizio = InStr(1, lemma(k), " ") + 1
            fine = InStr(inizio, lemma(k), " ")
            Primo = NumSuggerimenti(k) + 1
            NumSuggerimenti(k) += CInt(Mid(lemma(k), inizio, fine - inizio))
            inizio = InStr(lemma(k), ":") + 2
            For h = Primo To NumSuggerimenti(k) - 1
                fine = InStr(inizio, lemma(k), ",")
                Suggerimenti(k, h) = Mid(lemma(k), inizio, fine - inizio)
                inizio = fine + 2
            Next h
            Suggerimenti(k, h) = Mid(lemma(k), inizio)
        Next k
        If lbErrate.Items.Count > 0 Then
            lbErrate.SelectedIndex = 0
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Sub SelezionaErrata(ByVal indice As Integer)

        Try
            Dim k As Integer = 0
            Dim DaCercare As String = CStr(lbErrate.Items.Item(indice))
            Dim ps As Integer = CInt(lbPos.Items.Item(indice))
            Dim p As Integer = RTB.Find(DaCercare, ps, Len(RTB.Text), RichTextBoxFinds.WholeWord)

            If p = -1 Then
                'lbErrate.Items.RemoveAt(lbErrate.SelectedIndex)
                'NumErrori -= 1
                'lblTrovati.Text = "ERRORI TROVATI " & NumErrori
                TogliErrata()
            Else
                lbSuggerimenti.Items.Clear()
                Dim QuantiSuggerimenti As Integer = NumSuggerimenti(indice + 1)
                If QuantiSuggerimenti > MaxSuggerimenti Then QuantiSuggerimenti = MaxSuggerimenti

                For k = 1 To QuantiSuggerimenti
                    lbSuggerimenti.Items.Add(Suggerimenti(indice + 1, k))
                Next
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub lbErrate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbErrate.Click
        SelezionaErrata(lbErrate.SelectedIndex)
    End Sub

    Private Sub lbErrate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbErrate.SelectedIndexChanged
        On Error Resume Next
        SelezionaErrata(lbErrate.SelectedIndex)
        'Voice2.Voice = Voice2.GetVoices.Item(Parlante)
        Leggi1(CStr(lbErrate.Items.Item(lbErrate.SelectedIndex)))
        'Voice2.Voice = Voice2.GetVoices.Item(VocePrincipale)
    End Sub

    Private Sub lblTrovati_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblTrovati.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("errori trovati.")
        End If
    End Sub

    Private Sub Label5_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label5.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("suggerimenti per la correzione.")
        End If
    End Sub

    Private Sub lbSuggerimenti_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbSuggerimenti.DoubleClick
        CorreggiParola()
    End Sub

    Sub CorreggiParola()
        TogliOnda()
        If lbSuggerimenti.Items.Count = 0 Then Exit Sub
        On Error Resume Next
        RTB.SelectionBackColor = Color.White
        RTB.SelectedText = CStr(lbSuggerimenti.Items.Item(lbSuggerimenti.SelectedIndex))

        TogliErrata()

    End Sub

    Sub TogliErrata()

        If NumErrori = 0 Then Exit Sub

        Dim k, h As Integer
        For k = lbErrate.SelectedIndex + 1 To lbErrate.Items.Count - 1
            NumSuggerimenti(k) = NumSuggerimenti(k + 1)
            For h = 1 To NumSuggerimenti(k)
                Suggerimenti(k, h) = Suggerimenti(k + 1, h)
            Next
        Next
        On Error Resume Next
        lbErrate.Items.RemoveAt(lbErrate.SelectedIndex)
        lbPos.Items.RemoveAt(lbErrate.SelectedIndex)
        lbSuggerimenti.Items.Clear()
        lbErrate.SelectedIndex = 0
        SelezionaErrata(lbErrate.SelectedIndex)
        NumErrori -= 1
        lblTrovati.Text = "ERRORI TROVATI " & NumErrori
        If NumErrori = 0 Then
            RTB.SelectionLength = 0
            RTB.SelectionStart = 0
        End If

    End Sub

    Private Sub lbSuggerimenti_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbSuggerimenti.SelectedIndexChanged
        On Error Resume Next
        Leggi1(CStr(lbSuggerimenti.Items.Item(lbSuggerimenti.SelectedIndex)))
    End Sub

    Private Sub btnIgnora_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgnora.Click
        TogliOnda()
        'RTB.SelectionBackColor = Color.White
        TogliErrata()
        'RTB.SelectionLength = 0
    End Sub

    Private Sub btnIgnoraTutto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIgnoraTutto.Click
        Correttore()
    End Sub

    Sub IgnoraTutto()
        Dim U As New Underline(Me.RTB)
        Dim s As String = RTB.Text
        Dim delimStr As String = " ,.:!?()" & Chr(34)
        Dim delimiter As Char() = delimStr.ToCharArray()

        Dim words As String() = SeparaParole(s) 's.Split(New Char() {" "c})
        Dim word As String
        Dim p As Integer = 0
        For Each word In words
            RTB.Find(word, p, RichTextBoxFinds.WholeWord) ' RTB.Find(word, p, Len(RTB.Text), RichTextBoxFinds.WholeWord)
            p = RTB.SelectionStart + RTB.SelectionLength
            If U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave Then
                'U.SelectionUnderlineStyle = Underline.UnderlineStyle.None
                TogliOnda()
            End If
        Next
        RTB.SelectionStart = 0
        RTB.SelectionLength = 0

    End Sub

    Sub MettiOnda()

        Dim U As New Underline(Me.RTB)
        'MsgBox(U.SelectionUnderlineStyle & vbCrLf & U.SelectionUnderlineColor)

        If RTB.SelectionFont.Underline = False Then
            U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave
            U.SelectionUnderlineColor = Underline.UnderlineColor.Red
            'MsgBox("1" & U.SelectionUnderlineColor.ToString)
        Else
            U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave
            U.SelectionUnderlineColor = Underline.UnderlineColor.Magenta
            'MsgBox("2" & U.SelectionUnderlineColor.ToString)
        End If

        'Select Case CInt(U.SelectionUnderlineStyle)
        '    Case 0
        'U.SelectionUnderlineColor = Underline.UnderlineColor.Red
        'MsgBox(U.SelectionUnderlineColor.ToString)
        '    Case 1
        'U.SelectionUnderlineColor = Underline.UnderlineColor.Magenta
        'MsgBox(U.SelectionUnderlineColor.ToString)
        'End Select

        U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave

    End Sub

    Sub TogliOnda()

        Dim U As New Underline(Me.RTB)
        If U.SelectionUnderlineStyle = Underline.UnderlineStyle.Wave Then
            If U.SelectionUnderlineColor = Underline.UnderlineColor.Red Then
                'U.SelectionUnderlineColor = Underline.UnderlineColor.White 'Underline.UnderlineColor.Black
                U.SelectionUnderlineStyle = Underline.UnderlineStyle.None
                'U.SelectionUnderlineColor = Underline.UnderlineColor.White
            Else
                U.SelectionUnderlineStyle = Underline.UnderlineStyle.Normal
                U.SelectionUnderlineColor = Underline.UnderlineColor.Black
            End If

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.Click
        'blnManuale = True
        'frmPDF.Show()
        'Me.Hide()
        'Exit Sub
        Try
            Dim myProcess As Process = System.Diagnostics.Process.Start(Percorso & "\Manuale_LeggiXme.pdf")
            ChiudiFinestra()
        Catch ex As Exception
            MsgBox("Non riesco a trovare il manuale", MsgBoxStyle.Critical)
        End Try
        'myProcess.WaitForExit()

    End Sub

    Private Sub btnSostituisci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSostituisci.Click
        CorreggiParola()
    End Sub

    Private Sub btnInfo_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnInfo.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Apri il manuale del programma.")
        End If
    End Sub


    Private Sub cmdRiduci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRiduci.Click
        If Me.WindowState = FormWindowState.Normal Then
            Me.WindowState = FormWindowState.Maximized
        Else
            Me.WindowState = FormWindowState.Normal
        End If
    End Sub

    Private Sub cmdRiduci_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdRiduci.MouseMove
    End Sub

    Private Sub RBSel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBSel.CheckedChanged
        blnSelez = RBSel.Checked = True
        If blnSelez = True Then
            ToolTip1.SetToolTip(btnCancellaEvidenziazione, " CANCELLA IL TESTO NON SELEZIONATO ")
            ToolTip1.SetToolTip(btnCopiaEvidenziato, " COPIA IL TESTO SELEZIONATO ")
            ToolTip1.SetToolTip(btnSalvaEvidenziato, " SALVA IL TESTO SELEZIONATO ")
        Else
            ToolTip1.SetToolTip(btnCancellaEvidenziazione, " CANCELLA IL TESTO SELEZIONATO ")
            ToolTip1.SetToolTip(btnCopiaEvidenziato, " COPIA IL TESTO NON SELEZIONATO ")
            ToolTip1.SetToolTip(btnSalvaEvidenziato, " SALVA IL TESTO NON SELEZIONATO ")
        End If

        'MsgBox(ToolTip1.GetToolTip(btnCancellaEvidenziazione))

    End Sub

    Private Sub RBCanc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBCanc.CheckedChanged
        blnSelez = RBSel.Checked = True
    End Sub

    Private Sub rbInterl1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInterl1.CheckedChanged
        interlinea = 1
        ImpostaInterlinea(RTB)
    End Sub

    Private Sub rbInterl15_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInterl15.CheckedChanged
        interlinea = 2
        ImpostaInterlinea(RTB)
    End Sub

    Private Sub rbInterl2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInterl2.CheckedChanged
        interlinea = 3
        ImpostaInterlinea(RTB)
    End Sub

    Private Sub Label1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Numero massimo di suggerimenti.")
        End If
    End Sub

    Private Sub Label3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label3.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Interlinea.")
        End If
    End Sub

    Sub FermaVoce2()
        blnPiuParti = False
        blnStoLeggendoTraduzione = False
        If Voice2.State = SynthesizerState.Paused Then Voice2.Resume()
        If Voice2.State = SynthesizerState.Speaking Then
            Voice2.SpeakAsyncCancelAll()
        End If
    End Sub

    Private Sub btnCancellaEvidenziazione_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancellaEvidenziazione.Click
        btnAnnullaEvidenzia.Enabled = True
        tmpRTF = RTB.Rtf
        Dim Testo As String = ""
        If blnSelez = True Then
            Testo = TestoEvidenziato()
        Else
            Testo = TestoNonEvidenziato()
        End If
        If Testo = "" Then
            RTB.SelectAll()
            RTB.SelectionBackColor = Color.White
            RTB.SelectionLength = 0
            Exit Sub
        End If

        RTB.Text = Testo

        RTB.SelectAll()
        RTB.SelectionBackColor = Color.White

        RTB.SelectionLength = 0
    End Sub

    Private Sub btnCancellaEvidenziazione_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCancellaEvidenziazione.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2(ToolTip1.GetToolTip(btnCancellaEvidenziazione))
        End If
    End Sub

    Sub Maiuscolo_Minuscolo()

        Dim MisuraFont As Single = RTB.Font.Size
        If MisuraFont < 8 Then MisuraFont = 14

        Dim MioFont As Font = FontPredefinito
        If rbMaiu.Checked = True Then
            MioFont = CreateFont(Percorso & "\cdw_maiuscolo.ttf", FontStyle.Regular, MisuraFont, RTB.Font.Unit)
        ElseIf rbSmall.Checked = True Then
            MioFont = CreateFont(Percorso & "\figuralsmallcapsplain-regular.ttf", FontStyle.Regular, MisuraFont, RTB.Font.Unit)
        End If

        RTB.Font = MioFont ' unica riga diversa rispetto a quella sotto

        ImpostaInterlinea(RTB)

    End Sub

    Private Sub MaiuscoloMinuscolo()

        Dim MisuraFont As Single = RTB.Font.Size
        If MisuraFont < 8 Then MisuraFont = 14
        Dim MioFont As Font

        If rbMaiu.Checked = True Then
            MioFont = CreateFont(Percorso & "\cdw_maiuscolo.ttf", FontStyle.Regular, MisuraFont, RTB.Font.Unit)
        ElseIf rbSmall.Checked = True Then
            MioFont = CreateFont(Percorso & "\figuralsmallcapsplain-regular.ttf", FontStyle.Regular, MisuraFont, RTB.Font.Unit)
        Else
            MioFont = FontPredefinito
        End If

        RTB.SelectionFont = MioFont
        ImpostaInterlinea(RTB)

    End Sub

    Private Shared PFC As Drawing.Text.PrivateFontCollection
    Private Shared NewFont_FF As Drawing.FontFamily

    Private Function CreateFont(ByVal name As String, ByVal style As Drawing.FontStyle, ByVal size As Single, ByVal unit As Drawing.GraphicsUnit) As Drawing.Font
        'Create a new font collection
        PFC = New Drawing.Text.PrivateFontCollection
        'Add the font file to the new font
        '"name" is the qualified path to your font file
        PFC.AddFontFile(name)
        'Retrieve your new font
        NewFont_FF = PFC.Families(0)

        Return New Drawing.Font(NewFont_FF, size, style, unit)

    End Function

    Private Sub btnPDF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPDF.Click
        Dim miaPos As Integer = RTB.SelectionStart
        Dim lunghezza As Integer = RTB.SelectionLength
        ResettaBottoni()
        SistemaMisureRTB()
        FileDaAprire = ""
        frmPDF.Show()
        If frmPDF.blnTimerPDF = True Then frmPDF.tmrPDF.Enabled = True
        RTB.SelectionStart = miaPos + lunghezza
        RTB.SelectionLength = 0
        Me.Hide()
    End Sub

    Private Sub btnSinonimi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSinonimi.Click
        CercaSinonimi()
    End Sub

    Private Sub Sinonimi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Sinonimi.Click
        CercaSinonimi()
    End Sub

    Sub CercaSinonimi()

        ScegliLingua()
        If RTB.Text = "" Then Exit Sub

        If RTB.SelectedText = "" Then
            fnSinonimi()
        End If

        If RTB.SelectedText <> "" Then MostraSinonimi()
    End Sub

    Private Sub fnSinonimi()

        If RTB.Text = "" Then Exit Sub

        Dim i As Integer = RTB.SelectionStart
        If i < 1 Then i = 1
        If Mid(RTB.Text, i, 1) <= " " Then
            If i < 1 Then Exit Sub
        End If

        Do
            If i > 0 Then
                'If Mid(RTB.Text, i, 1) > " " Then
                If InStr(Spazi, Mid(RTB.Text, i, 1)) = 0 Then
                    i -= 1
                Else
                    Exit Do
                End If
            Else
                Exit Do
            End If
        Loop
        Dim l As Integer = 1
        Do
            'If Mid(RTB.Text, i + l, 1) > " " Then
            If InStr(Spazi, Mid(RTB.Text, i + l, 1)) = 0 Then
                l += 1
            Else
                Exit Do
            End If
        Loop
        RTB.SelectionStart = i
        RTB.SelectionLength = l - 1

        'MostraSinonimi()
    End Sub

    Private Sub Button1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSinonimi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Sinonimi.")
        End If

    End Sub

    Private Sub btnElenco_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnElenco.Click
        Dim i As Integer = 0
        Dim Testo As String = ""
        btnAnnullaEvidenzia.Enabled = True
        tmpRTF = RTB.Rtf
        If blnSelez = True Then
            Testo = TestoEvidenziato()
        Else
            Testo = TestoNonEvidenziato()
        End If
        If Testo = "" Then Exit Sub
        Testo = Testo.Replace(" ", vbCrLf)
        RTB.Text = Testo
        RTB.SelectAll()
        RTB.SelectionBackColor = Color.White
        RTB.SelectionLength = 0

    End Sub

    Private Sub btnPDF_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPDF.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("apri. faa'il pi di effe.")
        End If
    End Sub

    Private Sub btnEvidenziatore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEvidenziatore.Click
        If RTB.SelectionBackColor = Color.Yellow Then
            RTB.SelectionBackColor = Color.White
        Else
            RTB.SelectionBackColor = Color.Yellow
        End If
        RTB.Focus()
    End Sub

    Private Sub btnMP3_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnMP3.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("Salva come emme pi 3")
        End If
    End Sub

    Private Sub btnTrova_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btntROVA.Click
        If pnTrova.Visible = True Then
            ResettaBottoni()
        Else
            ResettaBottoni()
            pnTrova.Visible = True
            'pnTrova.BackColor = Color.LightGreen
            blnMenuVisibile = True
            txtTrova.Focus()
        End If
        SistemaMisureRTB()

    End Sub

    Private Sub btnTrova_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btntROVA.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("trova nel testo")
        End If
    End Sub

    Private Function TraduciSelezione() As String
        CopiaTesto()
        TraduciSelezione = TraduciInItaliano(RTB.Text)
    End Function

    Private Sub cmdTraduci_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTraduci.Click
        If ConnessioneInternet() = True Then
            Voice.SpeakAsyncCancelAll()
            CopiaTesto()
            If Clipboard.GetText = "" Then
                Leggi2("Non c'è nulla da tradurre.")
            Else
                'MsgBox(Len(Clipboard.GetText))
                If Len(Clipboard.GetText) > 1800 Then
                    Leggi2("Non posso tradurre testi così lunghi.")
                    MsgBox("Non posso tradurre testi così lunghi.", MsgBoxStyle.Critical)
                    Exit Sub
                End If
                LeggiTraduzione()
            End If
        Else
            Leggi2("per la traduzione è necessaria una connessione ad internet.")
            MsgBox("PER LA TRADUZIONE E' NECESSARIA UNA CONNESSIONE AD INTERNET", MsgBoxStyle.Critical)
        End If
    End Sub

    Sub LeggiTraduzione()

        If blnStoLeggendoTraduzione = True Then
            blnStoLeggendoTraduzione = False
            FermaVoce2()
        End If
        blnStoLeggendoTraduzione = True
        Dim Traduzione As String = TraduciSelezione()
        RTB.SelectionStart = RTB.TextLength
        RTB.SelectionLength = 0
        FontVerdana()
        RTB.SelectionStart = 1
        RTB.SelectionLength = 0
        Voice2.SelectVoice(VocePrincipale)

        Leggi2(Traduzione)

    End Sub

    Private Sub cmdTraduci_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdTraduci.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("traduci in italiano")
        End If
    End Sub

    Private Sub FontVerdana()
        Dim MioFont As New Font("Verdana", 14, FontStyle.Regular)
        RTB.SelectionFont = MioFont
    End Sub

    Function ContaParole() As Integer
        If RTB.Text = "" Then
            Return 0
        Else
            Dim chArr() As Char = {Chr(10), Chr(13)}
            Dim t As String = Trim(RTB.Text)
            t = t.TrimStart(chArr)
            t = t.TrimEnd(chArr)
            Return UBound(Regex.Split(t, "\W+")) + 1
        End If

    End Function

    Private Sub btnContaParole_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContaParole.Click
        lblNumParole.Text = ContaParole().ToString
    End Sub

    Private Sub btnContaParole_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnContaParole.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("conta parole")
        End If
    End Sub

    Private Sub btnTRAD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTRAD.Click

        Dim miaPos As Integer = RTB.SelectionStart
        Dim lunghezza As Integer = RTB.SelectionLength

        ResettaBottoni()
        SistemaMisureRTB()

        If ConnessioneInternet() = True Then
        Else
            'Leggi2("per la traduzione è necessaria una connessione ad internet.")
            'MsgBox("PER LA TRADUZIONE E' NECESSARIA UNA CONNESSIONE AD INTERNET", MsgBoxStyle.Critical)
            'FermaVoce2()
        End If

        RTB.SelectionStart = miaPos
        RTB.SelectionLength = lunghezza

        Try
            If RTB.Text = "" Then
                Clipboard.Clear()
            Else
                If RTB.SelectedText <> "" Then
                    Clipboard.SetText(RTB.SelectedText)
                Else
                    Clipboard.SetText(RTB.Text)
                End If
            End If

            frmTRAD.Show()
            RTB.SelectionStart = miaPos + lunghezza
            RTB.SelectionLength = 0
            Me.Hide()
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnTRAD_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTRAD.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("traduzioni")
        End If
    End Sub

    Private Sub btnDocumenti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocumenti.Click
        frmImgPdf.ShowDialog()
        Exit Sub

        If pnTrova.Visible = True Then
            ResettaBottoni()
        Else
            ResettaBottoni()
            pnTrova.Visible = True
            btnDocumenti.BackColor = Color.LightGreen
            blnMenuVisibile = True
        End If
        SistemaMisureRTB()
    End Sub

    Private Sub lblNumParole_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lblNumParole.MouseUp
        lblNumParole.Text = ContaParole().ToString
        If lblNumParole.Text = "1" Then
            Leggi2("una parola")
        Else
            Leggi2(lblNumParole.Text & "parole")
        End If
    End Sub

    Private Sub btnAppunti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAppunti.Click
        Dim miaPos As Integer = RTB.SelectionStart
        Dim lunghezza As Integer = RTB.SelectionLength
        ResettaBottoni()
        SistemaMisureRTB()
        frmAPP.Show()
        RTB.SelectionStart = miaPos + lunghezza
        RTB.SelectionLength = 0
        Me.Hide()
    End Sub

    Private Sub btnAppunti_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAppunti.MouseMove
    End Sub

    Private Sub frmLeggiXme_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.GotFocus
        If blnTastiRegistrati = False Then
            RegistraTasti()
        End If
    End Sub

    Private Sub btnDocumenti_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnDocumenti.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("documenti di testo.")
        End If
    End Sub

    Private Sub btnScegliVoce_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnScegliVoce.Click
        Dim vp As String = VocePrincipale
        ScegliVoce.ShowDialog()
        If VocePrincipale <> vp And cbVoci.FindString(VocePrincipale) <> -1 Then
            Voice2.SelectVoice(VocePrincipale)
        End If
    End Sub

    Private Sub btnScegliVoce_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnScegliVoce.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("scegli la voce principale.")
        End If

    End Sub

    Private Sub frmLeggiXme_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.G And e.Modifiers = Keys.Control Then
            RTB.SelectAll()
            RTB.SelectionFont = FontPredefinito
            RTB.SelectionStart = 0
            RTB.SelectionLength = 0
        End If

        If e.KeyCode = Keys.F8 Then
            LeggiTutto()
        End If
    End Sub

    Private Sub cmdRiduci_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdRiduci.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("ingrandisci, ridimensiona la finestra")
        End If
    End Sub

    Private Sub btnAppunti_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAppunti.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("gestione appunti")
        End If
    End Sub

    Private Sub btnAnnullaEvidenzia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnullaEvidenzia.Click
        RTB.Rtf = tmpRTF
        btnAnnullaEvidenzia.Enabled = False
    End Sub

    Private Function VoceInPausa() As Boolean
        Return Voice.State = SynthesizerState.Paused
    End Function

    Private Function VoceStaParlando() As Boolean
        Return Voice.State = SynthesizerState.Speaking
    End Function

    Private Function VoceZitta() As Boolean
        Return Voice.State = SynthesizerState.Ready
    End Function

    Private Sub RTB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RTB.TextChanged
        If RTB.Text = "" Then MaiuscoloMinuscolo()
        inizio = RTB.SelectionStart
        iniz = RTB.SelectionStart + 1
        blnSalvato = False
        blnTempSalvato = False
    End Sub

    Private Sub RTB_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RTB.DragDrop
        Dim img As Image

        img = Image.FromFile(CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString)
        Clipboard.SetImage(img)
        RidimensionaImmagineInClipboard()
        RTB.Paste()

    End Sub

    Private Sub RTB_DragEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles RTB.DragEnter

        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    Private Sub RTB_MouseWheel(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RTB.MouseWheel
        If RTB.SelectionType = 2 Then
            If e.Delta > 0 Then
                RidimensionaImmagine(RTB, 1)
            ElseIf e.Delta < 0 Then
                RidimensionaImmagine(RTB, -1)
            End If
        End If
    End Sub

    Private Sub btnIgnoraTutto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnIgnoraTutto.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("ignora tutto")
        End If
    End Sub

    Private Sub btnSostituisci_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSostituisci.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("sostituisci")
        End If
    End Sub

    Private Sub btnAggiungi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungi.Click
        Try
            Dim NuovaParola As String = CStr(lbErrate.Items.Item(lbErrate.SelectedIndex))
            AggiornaDizionarioUtente(NuovaParola)
            TogliErrata()
        Catch ex As Exception
            MsgBox("SI POSSONO INSERIRE SOLO PAROLE PRESENTI NEL RIQUADRO" & vbCrLf & "'ERRORI TROVATI'", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnAggiungi_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnAggiungi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("aggiungi.")
        End If
    End Sub

    Private Sub RTB_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles RTB.DoubleClick

        'MsgBox(RTB.SelectionType)
        If RTB.SelectionType = 5 Then
            Dim t As String = Trim(RTB.SelectedText)
            RTB.SelectionLength = Len(t)
            If Len(t) > 0 Then
                Try
                    Clipboard.SetText(t)
                Catch ex As Exception
                End Try
            End If
        End If

        If RTB.SelectionType = 2 Then
            RTB.Copy()
            frmImmagini.ShowDialog()
            If Clipboard.ContainsImage Then
                Dim n As Integer = RTB.SelectionStart
                RTB.Paste()
                RTB.Select(n, 1)
            End If
        End If
    End Sub

    Sub UnoSpazio()
        Dim t As String = RTB.Text
        RTB.Text = MettiUnoSpazio(t)
    End Sub

    Sub DoppiSpazi()
        Dim t As String = RTB.Text
        RTB.Text = MettiDoppiSpazi(t)
    End Sub

    Sub LeggiLaFrase()
        Dim fine As Integer = RTB.SelectionStart
        If fine < 5 Then Exit Sub
        Dim inizio As Integer = InStrRev(RTB.Text, ".", fine - 1)
        Dim i As Integer = InStrRev(RTB.Text, "?", fine - 1)
        If i > inizio Then inizio = i
        i = InStrRev(RTB.Text, "!", fine - 1)
        If i > inizio Then inizio = i
        If inizio = 0 Then inizio = 1
        If inizio > fine - 2 Then Exit Sub
        Leggi2(Mid(RTB.Text, inizio, fine - inizio + 1))
    End Sub

    Private Sub ckLeggeFrase_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckLeggeFrase.CheckedChanged
        If ckLeggeFrase.Checked = True Then ckLeggeParola.Checked = False
    End Sub

    Private Sub ckLeggeParola_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ckLeggeParola.CheckedChanged
        If ckLeggeParola.Checked = True Then ckLeggeFrase.Checked = False
    End Sub

    Private Sub rbMin_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbMin.Click
        rbMin.Checked = True
        rbMaiu.Checked = False
        rbSmall.Checked = False
        Maiuscolo_Minuscolo()
    End Sub

    Private Sub rbMaiu_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbMaiu.Click
        rbMaiu.Checked = True
        rbMin.Checked = False
        rbSmall.Checked = False
        Maiuscolo_Minuscolo()
    End Sub

    Private Sub rbSmall_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSmall.Click
        rbSmall.Checked = True
        rbMaiu.Checked = False
        rbMin.Checked = False
        Maiuscolo_Minuscolo()
    End Sub

    Private Sub ckLeggeFrase_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ckLeggeFrase.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2(ckLeggeFrase.Text)
        End If
    End Sub

    Private Sub Label6_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label6.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("caratteri minuscoli, maiuscoli o maiuscoletti.")
        End If
    End Sub

    Private Sub rbMin_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbMin.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("carattere minuscolo.")
        End If
    End Sub

    Private Sub rbMaiu_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbMaiu.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("carattere maiùscolo.")
        End If
    End Sub

    Private Sub rbSmall_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles rbSmall.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("carattere maiuscolétto.")
        End If
    End Sub

    Private Sub rbSpazi2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSpazi2.Click
        If rbSpazi2.Checked = True Then
            rbSpazi1.Checked = False
            spaziatura = 2
            DoppiSpazi()
        End If
    End Sub

    Private Sub rbSpazi1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSpazi1.Click
        If rbSpazi1.Checked = True Then
            rbSpazi2.Checked = False
            spaziatura = 1
            UnoSpazio()
        End If
    End Sub

    Private Sub Label7_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Label7.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("spazi tra le parole.")
        End If
    End Sub

    Private Sub tmrSalva_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSalva.Tick
        If RTB.Text <> "" And blnSalvato = False Then
            RTB.SaveFile(FileTemporaneo)
            blnTempSalvato = True
        End If
    End Sub

    Private Sub rbNormale_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbNormale.Click
        rbLavagna.Checked = False
        blnEffettoLavagna = False
        LavagnaRTB(RTB)
        'TogliEffettoLavagna(Me)
    End Sub

    Private Sub rbLavagna_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbLavagna.Click
        rbNormale.Checked = False
        blnEffettoLavagna = True
        LavagnaRTB(RTB)
        'EffettoLavagna(Me)
    End Sub

    Sub TraduciEn2Ita()

        If RTB.SelectedText = "" Then
            fnSinonimi()
        End If
        If RTB.SelectedText <> "" Then
            Dim a As String = TrEn2It(RTB.SelectedText)
            If a <> "" Then
                Try
                    Clipboard.SetText(a)
                Catch ex As Exception
                End Try
            Else
                Clipboard.Clear()
            End If
            MsgBox(a)
        End If
    End Sub

    Sub TraduciIta2En()

        If RTB.SelectedText = "" Then
            fnSinonimi()
        End If
        If RTB.SelectedText <> "" Then
            Dim a As String = TrIt2En(RTB.SelectedText)
            If a <> "" Then
                Try
                    Clipboard.SetText(a)
                Catch ex As Exception
                End Try
            Else
                Clipboard.Clear()
            End If
            MsgBox(a)
        End If
    End Sub

    Private Sub TradItaIngToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TradIItaIngToolStripMenuItem.Click
        ChDir(Percorso & "\Dizionario")
        Dim proc As Process = Process.Start("dizio.exe")
        ChDir(Percorso)
    End Sub

    Private Sub INGLITALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles INGLITALToolStripMenuItem.Click
        'If RTB.Text = "" Then Exit Sub
        'TraduciEn2Ita()

    End Sub

    Private Sub RTB_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RTB.MouseUp
        MousePremuto = False
    End Sub

    Private Sub RTB_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles RTB.MouseMove
        If MousePremuto Then
            ' Initiate dragging.
            RTB.DoDragDrop(RTB.SelectedText, DragDropEffects.Copy)
        End If
        MousePremuto = False
    End Sub

    Private Sub btnPredefinito_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPredefinito.Click
        Dim fontRTB As New FontDialog
        Dim MioStile As FontStyle
        Try
            MioStile = RTB.SelectionFont.Style
        Catch ex As Exception
            MioStile = FontStyle.Regular
        End Try
        fontRTB.Font = RTB.SelectionFont
        Try
            If fontRTB.ShowDialog() = DialogResult.OK Then
                Dim MioFont As New Font(fontRTB.Font, fontRTB.Font.Style)
                RTB.Font = MioFont
                RTB.SelectionFont = MioFont
                MisuraFontPredefinito = RTB.Font.Size
                NomeFontPredefinito = RTB.Font.Name
                FontPredefinito = MioFont
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Dim blnTrovaNuovo As Boolean = False

    Private Sub btnTrovaParola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrovaParola.Click
        TrovaParola()
    End Sub

    Private Sub TrovaParola()

        Static Dim ps As Integer
        Dim p As Integer
        If blnTrovaNuovo = True Then ps = 1
        blnTrovaNuovo = False
        p = RTB.Find(txtTrova.Text, ps, Len(RTB.Text), RichTextBoxFinds.None)
        If p = -1 Then
            MsgBox("Fine della ricerca", MsgBoxStyle.Information)
            ps = 1
        Else
            ps = p + 1
        End If
    End Sub

    Private Sub txtTrova_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTrova.KeyUp
        If e.KeyCode = Keys.Enter Then
            TrovaParola()
        End If
    End Sub

    Private Sub txtTrova_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTrova.TextChanged
        blnTrovaNuovo = True
    End Sub

    Private Sub ITALENGLToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ITALENGLToolStripMenuItem.Click
        blnDallItaliano = True
        frmDizLS.Show()
    End Sub

    Private Sub ENGLITALToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ENGLITALToolStripMenuItem.Click
        blnDallItaliano = False
        frmDizLS.Show()
    End Sub

    Private Sub btnTaglia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTaglia.Click
        fnTaglia()
    End Sub

    Private Sub btnCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopia.Click
        fnCopia()
    End Sub

    Private Sub btnIncolla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncolla.Click
        fnIncolla()
    End Sub

    Private Sub btnTaglia_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTaglia.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("taglia")
        End If
    End Sub

    Private Sub btnCopia_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCopia.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("copia")
        End If
    End Sub

    Private Sub btnIncolla_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnIncolla.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("incolla")
        End If
    End Sub

    Private Sub btnTrovaParola_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTrovaParola.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("trova la parola nel testo.")
        End If
    End Sub

    Private Sub btnPredefinito_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPredefinito.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("scegli il carattere predefinito.")
        End If
    End Sub

    Private Sub Voice_SpeakCompleted(ByVal sender As Object, ByVal e As System.Speech.Synthesis.SpeakCompletedEventArgs) Handles Voice.SpeakCompleted

        SetSpeakingState(False, m_bPaused)
        If blnDaRipristinare = True Then
            blnDaRipristinare = False
            Me.WindowState = FormWindowState.Normal
        End If
        RTB.SelectionStart = RTB.SelectionStart + RTB.SelectionLength

        Threading.Thread.Sleep(100)
        RTB.SelectionLength = 0
        blnStoLeggendo = False
        cmdLeggi.Enabled = True
        If blnPiuParti = True Then
            LeggiUnaParte()
        Else
            If blnRipristinareSelezione = False Then
                RTB.SelectionStart = SStart
            Else
                RTB.SelectionStart = InizSelezione
                RTB.SelectionLength = LunghSelezione
                blnRipristinareSelezione = False
            End If
        End If
        inizio = RTB.SelectionStart
        iniz = RTB.SelectionStart + 1
        'If blnLeggiUnaFrasePerVolta = True Then LeggiUnaFrase()
        RTB.Focus()
        'MsgBox(RTB.SelectionStart)
    End Sub

    Private Sub Voice_SpeakProgress(ByVal sender As Object, ByVal e As System.Speech.Synthesis.SpeakProgressEventArgs) Handles Voice.SpeakProgress
        EvidenziaParola(e.CharacterPosition, Len(e.Text))
    End Sub

    Private Sub Voice_SpeakStarted(ByVal sender As Object, ByVal e As System.Speech.Synthesis.SpeakStartedEventArgs) Handles Voice.SpeakStarted
        blnStoLeggendo = True
        cmdLeggi.Enabled = False
    End Sub

    Private Sub Voice2_SpeakCompleted(ByVal sender As Object, ByVal e As System.Speech.Synthesis.SpeakCompletedEventArgs) Handles Voice2.SpeakCompleted
        voce2speaking = False
        blnStoLeggendoTraduzione = False
        If blnPiuParti = True Then
            basApiLeggiXme.LeggiUnaParte()
        Else
            Voice2.SelectVoice(VocePrincipale)
        End If
    End Sub

    Private Sub Voice2_SpeakStarted(ByVal sender As Object, ByVal e As System.Speech.Synthesis.SpeakStartedEventArgs) Handles Voice2.SpeakStarted
        voce2speaking = True
    End Sub

    Private Sub btnImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImg.Click
        AggiungiImmagine()
    End Sub

    Private Sub btnImg_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnImg.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi2("inserisci immagine")
        End If
    End Sub

    Private Sub cmdImposta_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdImposta.MouseLeave
        If blnApriCartella = True Then
            blnApriCartella = False
            Process.Start("explorer.exe", FileDaAprire)
        End If
    End Sub
End Class
