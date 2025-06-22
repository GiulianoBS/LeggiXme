Option Strict Off
Option Explicit On
Imports VB = Microsoft.VisualBasic
Imports System.Collections.ObjectModel
Imports System.Reflection

Friend Class frmCalcolatrice
	Inherits System.Windows.Forms.Form

    'lTotLines = SendMessage(Text1.hwnd, EM_GETLINECOUNT, 0, 0)

	Dim blnCifre, blnNumeri As Boolean
    Private Declare Function SendMessage Lib "user32.dll" Alias "SendMessageA" (ByVal winHandle As Int32, ByVal wMsg As Int32, ByVal wParam As Int32, ByVal lParam As Int32) As Int32
    Private Const EM_LINEFROMCHAR As Int32 = &HC9
    Private Const EM_GETLINECOUNT As Int32 = &HBA

    Declare Function SetCaretPos Lib "User32" (ByVal x As Integer, ByVal y As Integer) As Integer
    Declare Function HideCaret Lib "User32" (ByVal hwnd As Integer) As Integer
    Dim Operazione() As String, numOperazioni As Integer, nOperazione As Integer
    Public strmsg, tmp As String
    Public i As Short
    Public DaCancellare As Boolean
    Public UltimoOperando, UltimoOperatore As String
    Public CeCalcolatrice As Boolean

    Public Operatore As Short
    Public Operando1 As Double
    Public Operando2 As Double
    Public dblE As Double

    Public blnOperando1, blnOperando2 As Boolean
    Public FineOperazione As Boolean = False
    Dim TastoNumero(9) As String
    Dim MaxDecimali As Integer = 3

    Private Sub ckCifre_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ckCifre.CheckStateChanged
        blnCifre = ckCifre.CheckState = 1
    End Sub

    Private Sub ckNumeri_CheckStateChanged(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles ckNumeri.CheckStateChanged
        blnNumeri = ckNumeri.CheckState = 1
    End Sub

    Private Sub CmdBack_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdBack.Click
        If txt.Text <> "" Then
            txt.Text = Mid(txt.Text, 1, Len(txt.Text) - 1)
            txt.Focus()
            txt.SelectionStart = Len(txt.Text)
        End If
    End Sub

    Private Sub CmdC_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdC.Click
        txt.Text = "0"
        'txt.Text = CStr(Val(txt.Text))
        Operando2 = 0 : blnOperando2 = False
        txt.Focus()
        txt.SelectionStart = Len(txt.Text)
    End Sub

    Private Sub CmdCE_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdCE.Click
        txt.Text = "" : txtMemo1.Text = "" : txtMemo.Text = ""
        Operando1 = 0 : blnOperando1 = False
        Operando2 = 0 : blnOperando2 = False
        Operatore = 0
        txt.Focus()
        txt.SelectionStart = Len(txt.Text)
    End Sub

    Private Sub CmdD_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdD.Click
        TastoDiviso()
    End Sub

    Private Sub TastoDiviso()
        UltimoOperatore = ":"
        DaCancellare = True
        If FineOperazione = True Then
            AggiungiOperazione()
            txtMemo1.Text = txt.Text & "÷" & vbCrLf
        Else
            txtMemo1.Text = txtMemo1.Text & txt.Text & "÷" & vbCrLf
        End If
        txtMemo1.SelectionStart = Len(txtMemo1.Text)
        Call Diviso()
        txt.Focus()
        txt.SelectionStart = Len(txt.Text)
        If blnNumeri Then LeggiMessaggi(txt.Text & " diviso")
        If blnCifre Then LeggiMessaggi("diviso")
    End Sub

    Private Sub CmdEq_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdEq.Click
        TastoUguale()
    End Sub

    Private Sub TastoUguale()
        'Dim tn As Double
        DaCancellare = True
        tmp = txt.Text
        i = InStr(tmp, ",")

        If i <> 0 Then
            Mid(tmp, i, 1) = "."
        End If

        If blnNumeri Then Sincrono(txt.Text & " uguale")
        If blnCifre Then Sincrono("uguale")

        If (Operatore > 0) And (Operatore < 5) Then 'In a real calculator when you type (6-1=5)
            'and you press Uguale for the second and more time the procedure
            txtMemo1.Text = txtMemo1.Text & txt.Text & "=" & vbCrLf
            Call Uguale() 'will go on and it shows 5 , 4 ,3,....
            'changin Operatore is for that
            Select Case Operatore
                Case 1 : Operatore = 10
                Case 2 : Operatore = 20
                Case 3 : Operatore = 30
                Case 4 : Operatore = 40
            End Select
        Else
            'If Operando2 = Empty Then tn = dblE Else tn = Operando2
            txtMemo1.Text = txtMemo1.Text & txt.Text & UltimoOperatore & vbCrLf & dblE & "=" & vbCrLf

            Select Case Operatore
                Case 10 : txt.Text = CStr(Val(tmp) + dblE)
                Case 20 : txt.Text = CStr(Val(tmp) * dblE)
                Case 30 : txt.Text = CStr(Val(tmp) - dblE)
                Case 40 : txt.Text = CStr(Val(tmp) / dblE)

            End Select

            tmp = txt.Text.Replace(".", ",")
            'i = InStr(tmp, ".")
            'If i <> 0 Then
            'Mid(tmp, i, 1) = ","
            'txt.Text = tmp
            'End If
            txt.Text = tmp
            'txtMemo = txtMemo & txt & "=" & vbCrLf

            txt.Focus()
            txt.SelectionStart = 0
            txt.SelectionLength = Len(txt.Text)

        End If

        Operando1 = 0 'CDbl(Nothing)
        blnOperando1 = False
        txt.Focus()
        txtMemo1.Text = txtMemo1.Text & New String("_", Len(txt.Text) + 2) & vbCrLf & txt.Text & " " & vbCrLf
        txtMemo1.SelectionStart = Len(txtMemo1.Text)
        txt.SelectionStart = Len(txt.Text)
        'txt.Text = MettiPunti(PreparaNumero(txt.Text))
        If InStr(txt.Text, ",") = 1 Then
            txt.Text = "0" & txt.Text
        End If

        If blnNumeri Then LeggiMessaggi(txt.Text)
        FineOperazione = True
        SistemaOperazione()
        Operazione(numOperazioni) = txtMemo1.Text
    End Sub

    Function MettiPunti(ByVal t As Double) As String
        Dim tt As String = Format(Val(t), Maschera(t))
        tt = tt.Replace(",", "@")
        tt = tt.Replace(".", ",")
        tt = tt.Replace("@", ".")
        Return tt
    End Function

    Dim MascheraBase As String = "##,###"

    Private Function Maschera(ByVal n As String) As String

        Dim i As Integer = InStr(n, ".")
        Dim nDec As Integer = Len(n) - i
        If nDec < 1 Then
            Return MascheraBase
        Else
            Return MascheraBase & "." & New String("#"c, nDec)
        End If
    End Function

    Function PreparaNumero(ByVal t As String) As String
        Dim MyStr As String = t
        MyStr = MyStr.Replace(".", "")
        MyStr = MyStr.Replace(",", ".")
        Return MyStr
    End Function

    Private Sub CmdMi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdMi.Click
        TastoMeno()
    End Sub

    Private Sub TastoMeno()
        UltimoOperatore = "-"
        DaCancellare = True
        If FineOperazione = True Then
            AggiungiOperazione()
            txtMemo1.Text = txt.Text & "-" & vbCrLf
        Else
            txtMemo1.Text = txtMemo1.Text & txt.Text & "-" & vbCrLf
        End If
        txtMemo1.SelectionStart = Len(txtMemo1.Text)
        Meno()
        txt.Focus()
        txt.SelectionStart = Len(txt.Text)
        If blnNumeri Then LeggiMessaggi(txt.Text & " meno")
        If blnCifre Then LeggiMessaggi("meno")
    End Sub

    Private Sub CmdMu_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdMu.Click
        TastoPer()
    End Sub

    Private Sub TastoPer()
        UltimoOperatore = "x"
        DaCancellare = True
        If FineOperazione = True Then
            AggiungiOperazione()
            txtMemo1.Text = txt.Text & "x" & vbCrLf
        Else
            txtMemo1.Text = txtMemo1.Text & txt.Text & "x" & vbCrLf
        End If
        txtMemo1.SelectionStart = Len(txtMemo1.Text)
        Per()
        txt.Focus()
        txt.SelectionStart = Len(txt.Text)
        If blnNumeri Then LeggiMessaggi(txt.Text & " per")
        If blnCifre Then LeggiMessaggi("per")
    End Sub

    Sub Moltiplica(ByRef f1 As String, ByRef f2 As String, ByVal rtb As RichTextBox)
        Dim moltip As Object
        Dim lr As Object
        Dim ris As String = ""
        Dim t As String
        Dim k, l, kk As Short
        Dim posVirg1 As Short = 0, posVirg2 As Short = 0
        Dim NumDecimali1, NumDecimali2 As Short
        Dim zeppa1 As String = "", zeppa2 As String = ""
        If InStr(f1, ",") <> 0 Or InStr(f2, ",") <> 0 Then
            rtb.Text = "SOLO PER OPERAZIONI SENZA DECIMALI"
            Exit Sub
        End If
        NumDecimali1 = NumDecimali(f1)
        NumDecimali2 = NumDecimali(f2)

        If NumDecimali1 > NumDecimali2 Then
            zeppa2 = New String(" ", NumDecimali1 - NumDecimali2)
            If NumDecimali2 = 0 Then zeppa2 = zeppa2 & " "
        End If
        If NumDecimali2 > NumDecimali1 Then
            zeppa1 = New String(" ", NumDecimali2 - NumDecimali1)
            If NumDecimali1 = 0 Then zeppa1 = zeppa1 & " "
        End If
        ris = VirgolaDecimale(Str(Val(PuntoDecimale(f1)) * Val(PuntoDecimale(f2))))
        lr = Len(ris)

        My.Computer.Clipboard.Clear()
        RTB.Text = ""
        RTB.SelectionColor = System.Drawing.Color.Black

        t = VB.Right(Space(lr) & f1 & zeppa1, lr + 1) & "x " & vbCrLf
        t = t & VB.Right(Space(lr) & f2 & zeppa2, lr + 1) & "= " & vbCrLf


        RTB.SelectedText = t

        l = Len(f1) : If Len(f2) > l Then l = Len(f2)
        l = l + 2
        t = VB.Right(Space(lr) & New String("_", l), lr + 2) & " " & vbCrLf
        RTB.SelectedText = t

        k = Len(f2)
        kk = k
        Do
            If Mid(f2, kk, 1) = "," Then kk = kk - 1
            moltip = Str(Val(ViaVirgola(f1)) * Val(Mid(f2, kk, 1)))
            If Val(moltip) = 0 Then moltip = New String("0", Len(f1))
            t = VB.Right(Space(lr) & moltip & New String(" ", Len(f2) - k), lr + 1) & vbCrLf
            RTB.SelectedText = t

            kk = kk - 1 : k = k - 1
        Loop Until kk = 0


        t = " " & New String("_", Len(ris) + 1) & " " & vbCrLf
        RTB.SelectedText = t

        t = " " & ViaVirgola(ris) & "  " & vbCrLf
        If InStr(ris, ",") > 0 Then
            t = t & " " & ris & "  " & vbCrLf
        End If
        RTB.SelectedText = t

        'Moltiplica = t

    End Sub

    Private Sub CmdN_Click()
        txt.Text = CStr(CDbl(txt.Text) * (-1))
    End Sub

    Private Sub CmdP_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles CmdP.Click
        TastoPiu()
    End Sub

    Private Sub TastoPiu()
        UltimoOperatore = "+"
        DaCancellare = True
        If FineOperazione = True Then
            AggiungiOperazione()
            txtMemo1.Text = txt.Text & "+" & vbCrLf
        Else
            txtMemo1.Text = txtMemo1.Text & txt.Text & "+" & vbCrLf
        End If
        txtMemo1.SelectionStart = Len(txtMemo1.Text)
        Call Piu()
        txt.Focus()
        txt.SelectionStart = Len(txt.Text)
        If blnNumeri Then LeggiMessaggi(txt.Text & " più")
        If blnCifre Then LeggiMessaggi("più")
    End Sub

    Private Sub cmdRQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRQ.Click
        UltimoOperatore = "R"
        DaCancellare = True
        Dim loperazione As String = ""

        If txt.Text = "" Then Exit Sub
        If Asc(txt.Text) = 45 Then Exit Sub

        If blnCifre = True And (blnNumeri = False Or txt.Text = "0") Then
            LeggiMessaggi("Radice quadrata.")
        Else
            If blnNumeri Then
                LeggiMessaggi("radice di " & txt.Text)
            End If
        End If
        loperazione = "R " & txt.Text & " ="
        Dim tt As String = txt.Text ' Str(System.Math.Sqrt(Val(txt.Text)))
        tt = tt.Replace(",", ".")
        tt = Str(System.Math.Sqrt(Val(tt)))
        txt.Text = tt.Replace(".", ",")
        txt.Text = MettiDecimali(tt.Replace(".", ","))
        loperazione += txt.Text
        loperazione = loperazione.Replace(" ,", " 0,")
        txtMemo1.Text = loperazione
        txt.Text = txt.Text.Replace(" ,", "0,")
        If blnNumeri Then LeggiMessaggi("uguale " & txt.Text) '(txtMemo.Text) 
        SistemaOperazione()
        AggiungiOperazione()
        Operazione(numOperazioni) = txtMemo1.Text
        FineOperazione = True
    End Sub

    Private Sub cmdQu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQu.Click
        UltimoOperatore = "²"
        DaCancellare = True
        Dim loperazione As String = ""

        If txt.Text > CStr(999999999999999.0#) Then
            txt.Text = "Numero troppo grande"
            Exit Sub
        Else
            If blnCifre = True And (blnNumeri = False Or txt.Text = "0") Then
                LeggiMessaggi("alla seconda.")
            Else
                If blnNumeri Then
                    LeggiMessaggi(txt.Text & "alla seconda")
                End If
            End If
        End If
        loperazione = txt.Text & UltimoOperatore & " ="
        Dim tt As String = txt.Text 'Str(Val(txt.Text) ^ 2)
        tt = tt.Replace(",", ".")
        tt = Str(Val(tt) ^ 2)
        txt.Text = MettiDecimali(tt.Replace(".", ","))
        loperazione += txt.Text
        loperazione = loperazione.Replace(" ,", " 0,")
        txtMemo1.Text = loperazione
        If blnNumeri Then LeggiMessaggi("uguale " & txt.Text)
        txt.Text = txt.Text.Replace(" ,", "0,")
        AggiungiOperazione()
        Operazione(numOperazioni) = txtMemo1.Text
        FineOperazione = True
    End Sub

    Private Sub cmdTutto_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles cmdTutto.Click
        LeggiMessaggi(FormattaNumero(txt.Text))
    End Sub

    Private Sub btnLeggi_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles btnLeggi.Click
        Dim m As String
        Dim p As Short
        Dim nl As Integer = SendMessage(txtMemo1.Handle, EM_GETLINECOUNT, 0, 0&)
        Dim i As Integer

        m = Trim(txtMemo1.Text)
        If m = "" Or nl < 0 Then
            m = "Non c'è nulla da leggere."
            LeggiMessaggi(m)
            GoTo Esci
        End If
        Dim PosIn As Integer = 0

        For i = 0 To nl - 1

            m = Trim(txtMemo1.Lines(i))
            p = InStr(m, "²")
            If p > 0 Then
                m = Mid(m, 1, p - 1) & " alla seconda " & Mid(m, p + 1)
            End If

            Do
                p = InStr(m, "+")
                If p = 0 Then Exit Do
                m = FormattaNumero(Mid(m, 1, p - 1)) & " più " & Mid(m, p + 1)
            Loop
            Do
                p = InStr(m, "x")
                If p = 0 Then Exit Do
                m = FormattaNumero(Mid(m, 1, p - 1)) & " per " & Mid(m, p + 1)
            Loop
            Do
                p = InStr(m, "-")
                If p = 0 Then Exit Do
                m = FormattaNumero(Mid(m, 1, p - 1)) & " meno " & Mid(m, p + 1)
            Loop
            Do
                p = InStr(m, "÷")
                If p = 0 Then Exit Do
                m = FormattaNumero(Mid(m, 1, p - 1)) & " diviso " & Mid(m, p + 1)
            Loop

            p = InStr(m, "R")
            If p <> 0 Then
                m = "radice di " & Mid(m, 2)
            End If

            Do
                p = InStr(m, "_")
                If p = 0 Then Exit Do
                m = VB.Left(m, p - 1) & "" & Mid(m, p + 1)
            Loop
            txtMemo1.Select(PosIn, txtMemo1.Lines(i).Length)
            PosIn += txtMemo1.Lines(i).Length + 2
            If Not m = "" Then
                Sincrono(m)
            End If
        Next i
Esci:

        txt.Focus()

    End Sub

    Function FormattaNumero(ByVal n As String) As String

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

    Private Function InCifre(ByVal n As String) As String
        If n <> "0" Then
            n = Format(Val(n), Maschera(n))
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

    Private Sub Dot_Click(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Dot.Click
        TastoVirgola()
    End Sub

    Private Sub TastoVirgola()
        If txt.SelectedText <> "" Then
            txt.Text = ""
        End If

        If InStr(txt.Text, ",") Then 'dot should only be typed once in a number
            txt.Text = txt.Text
        Else
            txt.Text = txt.Text & ","
        End If

        If VB.Left(txt.Text, 1) = "," Then 'if you press (.) as the first number a it will show "0."
            txt.Text = "0" & txt.Text
        End If
        txt.Focus()
        txt.SelectionStart = Len(txt.Text)
        If blnCifre Then LeggiMessaggi("virgola")
    End Sub

    Private Sub frmCalcolatrice_Activated(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Activated

        txt.Focus()

        Dim res As Integer = HideCaret(txt.Handle)

        blnCifre = ckCifre.CheckState = 1
        blnNumeri = ckNumeri.CheckState = 1

    End Sub

    Private Sub frmCalcolatrice_GotFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.GotFocus
        txt.Focus()
    End Sub

    Private Sub frmCalcolatrice_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
        Me.Width = 590
        Dim k As Short

        For k = 0 To 9
            TastoNumero(k) = CStr(k)
        Next

        Operatore = 0
        Operando1 = 0 : blnOperando1 = False
        Operando2 = 0 : blnOperando2 = False
        ckCifre.CheckState = System.Windows.Forms.CheckState.Unchecked
        nOperazione = 1
        numOperazioni = 1
        ReDim Preserve Operazione(numOperazioni)

    End Sub

    Private Sub frmCalcolatrice_LostFocus(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.LostFocus
        txt.Focus()
    End Sub

    Private Sub TastoCliccato(ByVal index As Short)

        If blnCifre = True Then LeggiMessaggi(TastoNumero(index))

        If DaCancellare = True Then
            DaCancellare = False
            txt.Text = ""
        End If
        If FineOperazione = True Then
            FineOperazione = False
            numOperazioni += 1
            ReDim Preserve Operazione(numOperazioni)
            nOperazione = numOperazioni
            txtMemo1.Text = ""
        End If
        If txt.Text = "0" Then

            txt.Text = ""
        End If

        If txt.SelectedText <> "" Then
            txt.Text = ""
        End If

        txt.Text = txt.Text & TastoNumero(index)
        txt.SelectionStart = Len(txt.Text)
        txt.Focus()
    End Sub

    Private Sub paste_Click()
        If IsNumeric(My.Computer.Clipboard.GetText) = True Then
            txt.Text = My.Computer.Clipboard.GetText
        End If
    End Sub

    Private Sub txt_Enter(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles txt.Enter
        Dim res As Integer = HideCaret(txt.Handle)

    End Sub

    Private Sub txt_KeyPress(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyPressEventArgs) Handles txt.KeyPress
        Dim KeyAscii As Short = Asc(eventArgs.KeyChar)
        If KeyAscii = 47 Then KeyAscii = 58
        If KeyAscii = 44 Or KeyAscii = 46 And InStr(txt.Text, ",") <> 0 Then
            KeyAscii = 0
            GoTo EventExitSub
        End If

        If txt.Text = "0" Then 'For prevention of typing i.e. 0254 or 000054
            txt.Text = ""
        End If

        Select Case KeyAscii
            Case 48 To 57
                If txt.SelectedText <> "" Then 'For entering a (new)number
                    txt.Text = ""
                End If
            Case 44, 46 'the (.) click
                If txt.SelectedText <> "" Then
                    txt.Text = ""
                End If
        End Select

        If KeyAscii > 47 And KeyAscii < 58 Then

            If DaCancellare = True Then
                DaCancellare = False
                txt.Text = ""
            End If

            If txt.Text = "0" Then
                txt.Text = ""
            End If

            If txt.SelectedText <> "" Then
                txt.Text = ""
            End If

            txt.Text = txt.Text & Chr(KeyAscii)
            txt.SelectionStart = Len(txt.Text)
            txt.Focus()

        End If

        Select Case KeyAscii
            Case 44, 46 : Call Dot_Click(Dot, New System.EventArgs())
            Case 43 : CmdP_Click(CmdP, New System.EventArgs()) 'Call Piu
            Case 45 : CmdMi_Click(CmdMi, New System.EventArgs()) 'Call Meno
            Case 42, 88, 120 : CmdMu_Click(CmdMu, New System.EventArgs()) 'Call Per
            Case 47, 58 : CmdD_Click(CmdD, New System.EventArgs()) 'Call Diviso
            Case 61 : Call CmdEq_Click(CmdEq, New System.EventArgs())
            Case 8 : Call CmdBack_Click(CmdBack, New System.EventArgs()) 'Backspace
            Case Else
        End Select
        txt.SelectionStart = Len(txt.Text)

EventExitSub:
        eventArgs.KeyChar = Chr(KeyAscii)
        If KeyAscii = 0 Then
            eventArgs.Handled = True
        End If
    End Sub

    Private Sub txtMemo_KeyDown(ByVal eventSender As System.Object, ByVal eventArgs As System.Windows.Forms.KeyEventArgs) Handles txtMemo1.KeyDown
        Dim KeyCode As Short = eventArgs.KeyCode
        Dim Shift As Short = eventArgs.KeyData \ &H10000
        If KeyCode = 13 Then txtMemo1.Text = txtMemo1.Text & vbCrLf
        txtMemo1.SelectionStart = Len(txtMemo1.Text)
        txtMemo1.Focus()
    End Sub

    Public Sub Piu()

        tmp = txt.Text
        i = InStr(tmp, ",")
        If i <> 0 Then
            Mid(tmp, i, 1) = "."
        End If

        If txt.SelectedText <> "" Then 'if u pressed + &then * it will not mess up
            Operatore = 11
            Operando1 = 0 : blnOperando1 = False
            Operando2 = 0 : blnOperando2 = False
        End If

        If Not (blnOperando1 = False) And (blnOperando2 = False) Then 'For pressing the second time
            Call Uguale() 'it should give result and the result should get ready for the next plusing
            Operatore = 1
        End If

        If (blnOperando1 = False) And (blnOperando2 = False) Then
            Operando1 = Val(tmp)
            blnOperando1 = True

            txt.Focus()
            txt.SelectionStart = 0
            txt.SelectionLength = Len(txt.Text)
            Operatore = 1
            DaCancellare = True
        End If
    End Sub

    Public Sub Meno()

        tmp = txt.Text
        i = InStr(tmp, ",")
        If i <> 0 Then
            Mid(tmp, i, 1) = "."
        End If

        If txt.SelectedText <> "" Then
            Operatore = 33
            Operando1 = 0 : blnOperando1 = False
            Operando2 = 0 : blnOperando2 = False
        End If

        If Not (blnOperando1 = False) And (blnOperando2 = False) Then
            Call Uguale()
            Operatore = 3
        End If

        If (blnOperando1 = False) And (blnOperando2 = False) Then
            Operando1 = Val(tmp)
            blnOperando1 = True
            txt.Focus()
            txt.SelectionStart = 0
            txt.SelectionLength = Len(txt.Text)
            Operatore = 3
            DaCancellare = True
        End If

    End Sub

    Public Sub Per()
        tmp = txt.Text
        i = InStr(tmp, ",")
        If i <> 0 Then
            Mid(tmp, i, 1) = "."
        End If

        If txt.SelectedText <> "" Then
            Operatore = 22
            Operando1 = 0 : blnOperando1 = False
            Operando2 = 0 : blnOperando2 = False
        End If
        If Not (blnOperando1 = False) And (blnOperando2 = False) Then
            Call Uguale()
            Operatore = 2
        End If

        If (blnOperando1 = False) And (blnOperando2 = False) Then
            Operando1 = Val(tmp)
            blnOperando1 = True
            txt.Focus()
            txt.SelectionStart = 0
            txt.SelectionLength = Len(txt.Text)
            Operatore = 2
            DaCancellare = True
        End If

    End Sub

    Public Sub Diviso()

        tmp = txt.Text
        i = InStr(tmp, ",")
        If i <> 0 Then
            Mid(tmp, i, 1) = "."
        End If
        If txt.SelectedText <> "" Then
            Operatore = 44
            Operando1 = 0 : blnOperando1 = False
            Operando2 = 0 : blnOperando2 = False
        End If
        If Not (blnOperando1 = False) And (blnOperando2 = False) Then
            Call Uguale()
            Operatore = 4
        End If

        If (blnOperando1 = False) And (blnOperando2 = False) Then
            Operando1 = Val(tmp)
            blnOperando1 = True
            txt.Focus()
            txt.SelectionStart = 0
            txt.SelectionLength = Len(txt.Text)
            Operatore = 4
            DaCancellare = True
        End If
    End Sub

    Sub Dividi(ByRef di1 As String, ByRef di2 As String, ByVal rtb As RichTextBox)
        Dim tempor As Object
        Dim cifre As Object
        Dim ciclo As Object
        Dim l As Object
        Dim d2 As Object
        Dim d1 As Object
        Dim ris As String
        Dim Resto, t, tmp As String
        Dim p As Short
        Dim basta As Boolean
        Dim differenza, abbasso As String

        If InStr(di1, ",") <> 0 Or InStr(di2, ",") <> 0 Then
            rtb.Text = "SOLO PER OPERAZIONI SENZA DECIMALI"
            Exit Sub
        End If
        d1 = Val(di1)

        d2 = Val(di2)

        ris = VirgolaDecimale(Str(Val(PuntoDecimale(d1)) \ Val(PuntoDecimale(d2))))

        Resto = Trim(Str(d1 - d2 * CDbl(ris)))

        t = " " & di1 & ":" & di2 & "=" & ris & vbCrLf

        rtb.Text = ""

        rtb.SelectionColor = System.Drawing.Color.Black
        rtb.SelectedText = t

        l = Len(di2)
        p = l
        tmp = VB.Left(di1, l)
        ciclo = 1

        Do
            differenza = tmp
            abbasso = ""
            cifre = -1
            Do
                If Val(tmp) >= d2 Then Exit Do
                If p + 1 > Len(di1) Then
                    basta = True
                    Exit Do
                End If
                p = p + 1
                cifre = cifre + 1
                tmp = tmp & Mid(di1, p, 1)
                abbasso = abbasso & Mid(di1, p, 1)
            Loop

            Resto = Trim(Str(Val(tmp) Mod Val(di2)))
            tempor = Trim(Str(Val(tmp) - Val(Resto)))

            If ciclo > 1 Then
                t = VB.Right(Space(p) & tmp, p + 1) & vbCrLf
                rtb.SelectionColor = System.Drawing.Color.Black
                If basta = False Then
                    t = Space(p - Len(differenza) - cifre) & differenza
                Else
                    t = Space(p - Len(differenza) - cifre) & differenza
                End If
                rtb.SelectedText = t
                rtb.SelectionColor = System.Drawing.Color.Red
                t = abbasso & vbCrLf
                rtb.SelectedText = t
            End If

            If basta = True Then Exit Do

            t = VB.Right(Space(p) & "-" & tempor, p + 1) & vbCrLf
            rtb.SelectionColor = System.Drawing.ColorTranslator.FromOle(RGB(0, 160, 0))
            rtb.SelectedText = t
            tmp = Resto
            ciclo = ciclo + 1
        Loop
     
    End Sub

    Public Sub Uguale()
        tmp = txt.Text
        i = InStr(tmp, ",")
        If i <> 0 Then
            Mid(tmp, i, 1) = "."
        End If

        Dim t As String = CStr(Operando1)
        Operando2 = Val(tmp) 'Val(txt.Text)

        If Operatore = 4 And Operando2 = 0 Then
            Operatore = 0
            'Operando2 = 0
            blnOperando2 = False
            MsgBox("Errore di divisione per zero", MsgBoxStyle.Exclamation, "Errore")
        End If


        Select Case Operatore
            Case 1 : Operando1 = Operando1 + Operando2
            Case 2 : Operando1 = Operando1 * Operando2
                Moltiplica(t, CStr(Operando2), txtMemo)
            Case 3 : Operando1 = Operando1 - Operando2
            Case 4 : Operando1 = Operando1 / Operando2

                Dividi(t, CStr(Operando2), txtMemo)

                'Case xx is for pressing a function and then pressing (=)[(i.e. u press 12&then (*)&then(=),144 will be displayed)]
            Case 11 : Operando1 = Operando1 + Operando1
            Case 22 : Operando1 = Operando1 * Operando1
            Case 33 : Operando1 = Operando1 - Operando1
            Case 44 : Operando1 = Operando1 / Operando1
        End Select

        txt.Text = CStr(Operando1).Replace(".", ",")
        If Operatore = 4 Then txt.Text = MettiDecimali(txt.Text)

        txt.Focus()
        txt.SelectionStart = 0
        txt.SelectionLength = Len(txt.Text)
        dblE = Operando2
        Operando2 = 0
        blnOperando2 = False

    End Sub

    Private Sub _num_0_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _num_0.Click, _num_1.Click, _num_2.Click, _num_3.Click, _num_4.Click, _
                           _num_5.Click, _num_6.Click, _num_7.Click, _num_8.Click, _num_9.Click
        TastoCliccato(CInt(sender.text))
    End Sub

    Private Sub btnCopia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopia.Click
        My.Computer.Clipboard.SetText(txt.Text)

    End Sub

    Private Sub btnCopiaT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopiaT.Click
        Testo()
    End Sub

    Public Sub Testo()
        Dim s As String = txtMemo1.Text
        Dim strTmp As String = ""
        Dim righe() As String = s.Split(New Char() {vbCrLf})
        Dim riga As String = ""
        Dim nRighe As Integer = UBound(righe), nRiga As Integer = 0, l As Integer = 0
        Dim lungh As Integer = 0
        For nRiga = 0 To nRighe - 2
            If Len(righe(nRiga)) > lungh Then lungh = Len(righe(nRiga))
        Next
        lungh += 1
        For nRiga = 0 To nRighe - 1
            riga = LTrim(righe(nRiga))
            If nRiga > 0 Then riga = Mid(riga, 2)
            l = Len(riga) : If l < 1 Then l = 1
            riga = Space(lungh) & riga
            riga = Mid(riga, l)
            strTmp = strTmp & riga & vbCrLf
        Next
        If nRighe = 0 Then strTmp = txtMemo1.Text
        strTmp = strTmp & vbCrLf
        If strTmp <> "" Then
            Clipboard.SetText(strTmp)
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncolla.Click
        Testo()
    End Sub

    Private Sub btnPrec_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrec.Click
        If nOperazione > 1 Then
            nOperazione -= 1
            txtMemo1.Text = Operazione(nOperazione)
        End If
    End Sub

    Private Sub btnSeg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSeg.Click
        If nOperazione < numOperazioni Then
            nOperazione += 1
            txtMemo1.Text = Operazione(nOperazione)
        End If
    End Sub

    Private Sub CmdBack_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CmdBack.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("cancella l'ultimo caràt tere.")
        End If
    End Sub

    Private Sub CmdCE_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CmdCE.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("cancella tutto.")
        End If
    End Sub

    Private Sub btnCopia_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCopia.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("incolla il numero nel documento.")
        End If
    End Sub

    Private Sub cmdTutto_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdTutto.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("leggi il numero.")
        End If
    End Sub

    Private Sub btnIncolla_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnIncolla.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("incolla l'operazione nel documento.")
        End If
    End Sub

    Private Sub btnLeggi_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnLeggi.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("leggi l'operazione.")
        End If
    End Sub

    Private Sub btnPrec_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnPrec.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("operazione precedente.")
        End If
    End Sub

    Private Sub btnSeg_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnSeg.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("operazione seguente.")
        End If
    End Sub

    Private Sub btnCopiaT_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCopiaT.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("copia l'operazione negli appunti.")
        End If
    End Sub

    Private Sub cmdMostra_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Right Then
            LeggiMessaggi("mostra nascondi gli appunti.")
        End If
    End Sub

    Private Sub MaxDecim_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MaxDecim.ValueChanged
        MaxDecimali = MaxDecim.Value
    End Sub

    Function MettiDecimali(ByVal n As String) As String
        Dim nu As String = n

        If n = "" Then
            Return ""
            Exit Function
        End If
        Dim i As Integer = InStr(nu, ",")
        If i > 0 Then
            If MaxDecimali = 0 Then
                nu = Mid(nu, 1, i - 1)
            Else
                nu = Mid(nu, 1, i + MaxDecimali)
            End If
        End If
        Return nu
    End Function

    Sub SistemaOperazione()
        Dim riga() As String = txtMemo1.Text.Split(vbCrLf)
        Dim nr As Integer = UBound(riga)
        Dim k, h, p As Integer, tp As String = "", tpr As String = ""
        p = 0
        For k = 0 To nr
            riga(k) = riga(k).Trim(Chr(10))
            h = Len(riga(k)) - InStrRev(riga(k), ",")
            If InStrRev(riga(k), ",") = 0 Then h = 0
            If h > p Then p = h
        Next
        't1.Text += p.ToString & vbCrLf & vbCrLf
        If p > 0 Then
            tp = ""
            For k = 0 To nr
                tpr = riga(k)
                h = Len(tpr) - InStrRev(tpr, ",")
                If InStrRev(tpr, ",") = 0 Then h = 0
                If k <> (nr - 2) Then
                    Try
                        Select Case p - h
                            Case 0
                            Case p
                                tpr = Mid(tpr, 1, Len(tpr) - 1) + Space(p) + Mid(tpr, Len(tpr), 1)
                            Case Else
                                tpr = Mid(tpr, 1, Len(tpr) - 1) + Space(p - h) + Mid(tpr, Len(tpr), 1)
                        End Select

                    Catch ex As Exception
                    End Try
                End If
                tp = tp + tpr + vbCrLf
            Next
            txtMemo1.Text = tp
        End If

    End Sub

    Private Sub AggiungiOperazione()
        FineOperazione = False
        numOperazioni += 1
        ReDim Preserve Operazione(numOperazioni)
        nOperazione = numOperazioni
        SistemaOperazione()
        Operazione(numOperazioni) = txtMemo1.Text
    End Sub

    Private Function CreaMessaggio(ByVal s As String) As String
        s = s.Replace("*", " per ")
        Dim i As Integer = 0, k As Integer = 0, esponente As String = "", a As String = ""
        '"²"

        s = s.Replace("²", "^2")
        MsgBox(s)
        Do
            i = InStr(s, "^")
            If i = 0 Then Exit Do
            esponente = ""
            k = 1
            Do
                a = Mid(s, i + k, 1)
                If a = " " Then Exit Do
                esponente += a
                k += 1
            Loop
            s = Mid(s, 1, i - 1) & " alla " & ordinale(esponente) & Mid(s, i + k)
        Loop

        Return s

    End Function

    Private Function ordinale(ByVal num As String) As String
        Select Case Val(num)
            Case 1 : Return " prima "
            Case 2 : Return " seconda "
            Case 3 : Return " terza "
            Case 4 : Return " quarta "
            Case 5 : Return " quinta "
            Case 6 : Return " sesta "
            Case 7 : Return " settima "
            Case 8 : Return " ottava "
            Case 9 : Return " nona "
            Case 10 : Return " decima "
            Case 11 : Return " undicesima "
            Case 12 : Return " dodicesima "
            Case 13 : Return " tredecesima "
            Case 14 : Return " quattordicesima "
            Case 15 : Return " quindicesima "
            Case 16 : Return " sedicesima "
            Case 17 : Return " diciassettesima "
            Case 18 : Return " diciottesima "
            Case 19 : Return " diciannovesima "
            Case 20 : Return " ventesima "
            Case Else : Return " " & num & " "
        End Select
    End Function

    Function NumDecimali(ByRef n As String) As Short
        Dim p As Short
        p = InStr(n, ",")
        If p > 0 Then
            NumDecimali = Len(Mid(n, p + 1))
        Else
            NumDecimali = 0
        End If

    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        AcquisisciImmagine(txtMemo)
    End Sub

    Private Sub AcquisisciImmagine(ByVal rtb As RichTextBox)
        Dim i As Point
        Dim m As Size
        i.X = Me.Left + rtb.Left + 8
        i.Y = Me.Top + rtb.Top + MisureFinestra() + 8
        m.Width = rtb.Width - 24
        m.Height = rtb.Height - 10
        Dim bmp As New Bitmap(m.Width, m.Height)
        Dim gfx As Graphics = System.Drawing.Graphics.FromImage(bmp)
        gfx.CopyFromScreen(i.X, i.Y, 0, 0, m, CopyPixelOperation.MergeCopy)
        gfx.Dispose()
        Clipboard.SetImage(bmp)
    End Sub

    Function MisureFinestra() As Integer

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

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Width = 1000
    End Sub

    Private Sub Button2_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Width = 590
    End Sub

    Function PuntoDecimale(ByRef nn As String) As String
        Dim i As Short
        Dim n As String
        n = Trim(nn)
        i = InStr(n, ",")
        If i > 0 Then n = Mid(n, 1, i - 1) & "." & Mid(n, i + 1)
        PuntoDecimale = n

    End Function

    Function VirgolaDecimale(ByRef nn As String) As String
        Dim i As Short
        Dim n As String
        n = Trim(nn)
        i = InStr(n, ".")
        If i > 0 Then n = Mid(n, 1, i - 1) & "," & Mid(n, i + 1)
        If Mid(n, 1, 1) = "," Then n = "0" & n
        If i = 2 And Mid(n, 1, 1) = "-" Then n = "-0" & Mid(n, 2)
        VirgolaDecimale = n

    End Function

    Function ViaVirgola(ByRef nn As String) As String
        Dim i As Short
        Dim n As String
        n = Trim(nn)
        i = InStr(n, ",")
        If i > 0 Then n = Mid(n, 1, i - 1) & Mid(n, i + 1)
        i = InStr(n, ".")
        If i > 0 Then n = Mid(n, 1, i - 1) & Mid(n, i + 1)
        ViaVirgola = n
    End Function

   
End Class