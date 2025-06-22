Option Strict Off
Imports Microsoft.Speech.Synthesis
Imports System.Collections.ObjectModel

Module modGestisciAudio

    'C:\DOCUME~1\Utente\IMPOST~1\Temp	

    Dim Uno, Due, Tre As String
    Public LengthIn, LengthOut As Integer
    Public Channels As Short
    Public SampleRate As Integer
    Public DataLengthIn, DataLengthOut As Integer
    Public BitsPerSample As Short

    Private WithEvents VoceRegistrazione As New SpeechSynthesizer
    Public Lingue(88) As String

    Public Parte() As String
    Public Frase() As String
    Public InizioParte() As Integer
    Public InizioFrase() As Integer
    Public NumParti As Integer = 0
    Public NumFrasi As Integer = 0
    Public blnPiuParti As Boolean = False
    Public blnPiuFrasi As Boolean = False
    Public Intervallo As Integer

    Declare Auto Function PlaySound Lib "winmm.dll" (ByVal name As String, ByVal hmod As Integer, ByVal flags As Integer) As Integer

    Public Const SND_SYNC As Integer = &H0 ' play synchronously 
    Public Const SND_ASYNC As Integer = &H1 ' play asynchronously 
    Public Const SND_MEMORY As Integer = &H4  'Play wav in memory
    Public Const SND_ALIAS As Integer = &H10000 'Play system alias wav 
    Public Const SND_NODEFAULT As Integer = &H2
    Public Const SND_FILENAME As Integer = &H20000 ' name is file name 
    Public Const SND_RESOURCE As Integer = &H40004 ' name is resource name or atom 

    Public Sub PlayWaveFile(ByVal fileWaveFullPath As String)
        Try
            PlaySound(fileWaveFullPath, 0, SND_FILENAME Or SND_ASYNC)
        Catch
        End Try
    End Sub

    Public Sub ConvertiMP3(ByVal nFileWav As String)
        Dim nFileMP3 As String = nFileWav
        Mid(nFileMP3, Len(nFileMP3) - 3) = ".mp3"
        Dim comando As String = "lame -h " & Chr(34) & nFileWav & Chr(34) & " " & Chr(34) & nFileMP3 & Chr(34)
        frmLeggiConMe.Cursor = Cursors.WaitCursor
        ProcID = Shell(comando, AppWinStyle.Hide, Wait:=True)
        frmLeggiConMe.Cursor = Cursors.Default
        Try
            Kill(nFileWav)
        Catch ex As Exception
            If Dir(nFileWav) <> "" Then
                MsgBox("ATTENZIONE!" & vbCrLf & "Bisogma eliminare manualmente il file " & nFileWav, MsgBoxStyle.Critical)
            End If
        End Try
    End Sub

    Sub ImpostaVoce()
        VoceRegistrazione.SelectVoice(VoceInstallata(Parlante))
        VoceRegistrazione.Rate = Velocita
        VoceRegistrazione.Volume = Volume
    End Sub

    Public Sub CreaWave(ByVal t As String, ByVal NomeFile As String)
        SalvaAudio(t, NomeFile)
    End Sub

    Public Sub SalvaWave(ByVal frm As Form, ByVal testo As String)

        If blnVoce = False Then Exit Sub

        If Len(testo) > 4000 Then
            'LeggiMessaggi("ATTENZIONE! Sarebbe meglio non salvare faail sonori così lunghi!")
            'MsgBox("ATTENZIONE! Sarebbe meglio non salvare file sonori così lunghi!", MsgBoxStyle.Exclamation)
        End If

        Dim k As Integer = 0
        Dim blnInterrompi As Boolean = False

        If testo = "" Then
            MsgBox("Non c'è nulla da salvare come file sonoro!", vbCritical)
            Exit Sub
        End If

        Dim CD As New SaveFileDialog()

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

            SalvaAudio(testo, NomeFile)

            If blnMP3 = True Then
                ConvertiMP3(NomeFile)
            End If
        End If
        frm.Cursor = Cursors.Default

    End Sub


End Module
