Imports System.IO
Imports System.Reflection

Public Class frmLettore
    Dim testo As String = ""
    Dim mioHandle As IntPtr, altroHndl As IntPtr, PuntaFinestra As IntPtr
    Dim larghezza As Integer = 0
    Dim altezza As Integer = 70
    Dim blnChiudi As Boolean = True

    Private Sub cmdLeggi_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdLeggi.Click
        Leggi()
    End Sub

    Dim blnCMap As Boolean = False

    Private Sub CopiaTesto()
        Dim tmp As String = "", strProg As String = ""
        SetForegroundWindow(altroHndl)
        strProg = GetWT(altroHndl)
        SetForegroundWindow(altroHndl)

        Threading.Thread.Sleep(100)
        SendKeys.SendWait("^(c)")
        Threading.Thread.Sleep(100)

        Try
            If Clipboard.ContainsText = False Then
                SetForegroundWindow(altroHndl)
                Threading.Thread.Sleep(200)
                SendKeys.SendWait("^(c)")
            End If
        Catch ex As Exception
            SetForegroundWindow(altroHndl)
            Threading.Thread.Sleep(200)
            SendKeys.SendWait("^(c)")
        End Try

        Try
            'Me.Text = strProg
            If Clipboard.ContainsText = True Then
                'MsgBox(strProg)

                tmp = Clipboard.GetText
                'MsgBox(tmp)
                If strProg = "ACRORD32" Or strProg = "PDFXCVIEW" Or strProg = "PDFXEDIT" Or strProg = "PDFREADER" Or strProg = "NITRO" Or strProg = "SUMATRAPDF" Or strProg = "FOXIT READER" Or strProg = UCase(IO.Path.GetFileNameWithoutExtension(ProgrammaAssociato("pdf"))) Or strProg = "" Or frmLeggiConMe.FiltroPDF.Checked = True Then tmp = filtrata(tmp)
                If strProg = "WINWORD" Then tmp = tmp.Replace(Chr(172), "")
                blnCMap = False
                If strProg = "JAVAW" Then
                    blnCMap = True
                    tmp = ConvertiDaCMap(tmp)
                End If
                'tmp = FiltroLineetta(tmp)
                tmp = tmp.Replace("É", "È")
                ' tmp = FiltroNumeri(tmp)
                'tmp = tmp.Replace(ChrW(64257) & " ", "fi")

                If InStr(strProg, "MINDMAPLE") = 0 Then
                    If tmp <> "" Then
                        'If NAppunti = 0 Then
                        'frmLeggiConMe.RTB.Text = tmp
                        'NAppunti += 1
                        'ReDim Preserve Appunti(NAppunti)
                        'Appunti(NAppunti) = tmp
                        'Else
                        AggiungiAppunto(tmp)
                        'End If
                    End If
                End If
            Else
                'Me.Text = strProg
            End If
        Catch ex As Exception
        End Try
        testo = tmp
    End Sub

    Sub AggiungiAppunto(ByVal tmp As String)
        If tmp <> Appunti(NAppunti) Then
            If blnAggTesto = False Then
                'frmLeggiConMe.RTB.Text = ""
                frmLeggiConMe.RTB.Text = tmp
            Else
                'frmLeggiConMe.RTB.Text &= Appunti(NAppunti)
            End If
            NAppunti += 1
            ReDim Preserve Appunti(NAppunti)
            Appunti(NAppunti) = tmp
        End If
    End Sub

    Sub Leggi()

        FermaVoce()
        CopiaTesto()

        If testo = "" Then
            SenzaEco("Non c'è nulla da leggere.")
            Exit Sub
        End If

        If VoceZitta() = False Then
            FermaVoce()
        End If

        'If blnCMap = True Then
        'testo = ConvertiDaCMap(testo)
        'End If

        SenzaEco(ConvertiMinuscole(testo))

    End Sub

    Structure UnNodo
        Dim origine As String
        Dim connettivo As String
        Dim destinazione() As String
        Dim nd As Integer
        Dim foglia As Boolean
    End Structure

    Dim nodo() As UnNodo
    Dim NumNodi As Integer = 0
    Dim Destinazioni() As String
    'Dim NumDestinazioni As Integer = 0

    Function TrovaPrincipale(ByVal t As String) As String

        Dim orig(0) As String, dest(0) As String, relaz(0) As String
        Dim no As Integer = 0, nd As Integer = 0, nr As Integer = 0

        Dim tt As String = ""
        Dim righe() As String = t.Split(New Char() {vbCrLf})
        Dim riga As String = ""
        Dim nRighe As Integer = UBound(righe), nRiga As Integer = 0, l As Integer = 0

        For nRiga = 0 To nRighe - 1
            righe(nRiga) = righe(nRiga).TrimEnd(Chr(10), Chr(13), Chr(32))
            righe(nRiga) = righe(nRiga).TrimStart(Chr(32), Chr(9), Chr(10))
        Next
        For nRiga = 0 To nRighe - 1
            If InStr(righe(nRiga), "LinkingPhrase") <> 0 Then
                Exit For
            Else
                righe(nRiga) = ""
            End If
        Next
        For k As Integer = nRiga To nRighe - 1
            righe(k - nRiga) = righe(k)
        Next
        nRighe -= nRiga - 1
        ReDim Preserve righe(nRighe)


        For k As Integer = 0 To nRighe - 1
            If InStr(righe(k), "LinkingPhrase") <> 0 Then
                nr += 1
                ReDim Preserve relaz(nr)
                relaz(nr) = Mid(righe(k), 16)
                'm &= relaz(nr) & vbCrLf
            End If
            If InStr(righe(k), "OutgoingConnection") <> 0 Then
                nd += 1
                ReDim Preserve dest(nd)
                dest(nd) = Mid(righe(k), 23)
                'm &= dest(nd) & vbCrLf
            End If
            If InStr(righe(k), "IncomingConnection") <> 0 Then
                no += 1
                ReDim Preserve orig(no)
                orig(no) = Mid(righe(k), 25)
                'm &= orig(no) & vbCrLf
            End If
        Next
        'MsgBox(m)
        Dim goal As String = ""
        For k As Integer = 1 To no
            For h As Integer = 1 To nd
                goal = orig(k)
                If goal = dest(h) Then
                    goal = ""
                    Exit For
                End If
            Next
            If goal <> "" Then
                Exit For
            End If
        Next
        'MsgBox(goal)
        If goal = "" Then goal = "Non trovo il concetto di partenza"
        Return goal
        'End

    End Function

    Function ConvertiDaCMap(ByVal t As String) As String

        Dim OriginePrima As String = TrovaPrincipale(t)

        If OriginePrima = "Non trovo il concetto di partenza" Then
            'MsgBox("ATTENZIONE! Non trovo il concetto di partenza", MsgBoxStyle.Critical)
            Return OriginePrima
        End If

        Dim tt As String = ""
        Dim righe() As String = t.Split(New Char() {vbCrLf})
        Dim riga As String = ""
        Dim nRighe As Integer = UBound(righe), nRiga As Integer = 0, l As Integer = 0
        Dim n As Integer = 0, k As Integer = 0, h As Integer = 0


        For nRiga = 0 To nRighe - 1
            righe(nRiga) = righe(nRiga).TrimEnd(Chr(10), Chr(13), Chr(32))
            righe(nRiga) = righe(nRiga).TrimStart(Chr(32), Chr(9), Chr(10))
        Next
        For nRiga = 0 To nRighe - 1
            If InStr(righe(nRiga), "LinkingPhrase") <> 0 Then
                Exit For
            Else
                righe(nRiga) = ""
            End If
        Next
        For k = nRiga To nRighe - 1
            righe(k - nRiga) = righe(k)
        Next

        nRighe -= nRiga - 1
        ReDim Preserve righe(nRighe)

        Dim origine As String = ""
        Dim connettivo As String = ""
        Dim destinazione(20) As String
        NumNodi = 0 : nRiga = 0

        Do While nRiga < nRighe
            If InStr(righe(nRiga), "LinkingPhrase") <> 0 Then
                connettivo = Mid(righe(nRiga), 16)
                'MsgBox(connettivo & nRiga)
                n = 0
            End If
            If InStr(righe(nRiga), "OutgoingConnection") <> 0 Then
                n += 1
                destinazione(n) = Mid(righe(nRiga), 23) '& "."
                'MsgBox(destinazione(n) & nRiga)
            End If
            If InStr(righe(nRiga), "IncomingConnection") <> 0 Then
                origine = Mid(righe(nRiga), 25)
                'MsgBox(origine & nRiga)

                For k = 1 To n
                    NumNodi += 1
                    ReDim Preserve nodo(NumNodi)
                    ReDim Preserve nodo(NumNodi).destinazione(1) ' (20)
                    nodo(NumNodi).destinazione(1) = destinazione(k)
                    nodo(NumNodi).connettivo = connettivo
                    nodo(NumNodi).origine = origine
                    nodo(NumNodi).nd = 1 'n
                Next

                Do
                    If nRiga < nRighe Then ' And 2 = 1 Then
                        'nRiga += 1
                        If InStr(righe(nRiga + 1), "IncomingConnection") <> 0 Then
                            nRiga += 1
                            origine = Mid(righe(nRiga), 25)
                            'MsgBox(origine & nRiga)
                            For k = 1 To n
                                NumNodi += 1
                                ReDim Preserve nodo(NumNodi)
                                ReDim Preserve nodo(NumNodi).destinazione(1) ' (20)
                                nodo(NumNodi).destinazione(1) = destinazione(k)
                                nodo(NumNodi).connettivo = connettivo
                                nodo(NumNodi).origine = origine
                                nodo(NumNodi).nd = 1 'n
                            Next
                        Else
                            n = 0
                            Exit Do
                        End If
                    Else
                        n = 0
                        Exit Do
                    End If
                Loop
            End If
            nRiga += 1
        Loop

        'Dim m As String = "" : For k = 1 To NumNodi : m &= nodo(k).origine & " " & nodo(k).connettivo & " " & nodo(k).destinazione(1) & vbCrLf : Next : MsgBox(m)

        Dim fatti As Integer = 0
        Dim destinaz As String = ""
        Dim nullo As Boolean = False
        Dim Origine1 As Integer = 0

        Try
            For k = 1 To NumNodi
                destinaz = nodo(k).destinazione(1)
                nullo = False
                If destinaz <> "" Then
                    nodo(k).foglia = True
                    For h = 1 To NumNodi
                        If nodo(h).origine = destinaz Then
                            nodo(k).foglia = False
                            Exit For
                        End If
                    Next
                End If
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim ListaOrigini(1) As String
        Dim o As String = ""
        Dim lo As Integer = 1
        Dim p As Integer

        ListaOrigini(1) = OriginePrima
        Dim Porigini(0) As Integer

        For k = 1 To NumNodi
            o = nodo(k).origine
            p = Array.IndexOf(ListaOrigini, o)
            If p = -1 Then
                lo += 1
                ReDim Preserve ListaOrigini(lo)
                ReDim Preserve Porigini(lo)
                ListaOrigini(lo) = o
                Porigini(lo) = k
            End If
        Next
        'Dim m1 As String = "" : For h = 1 To lo : m1 += ListaOrigini(h) + vbCrLf : Next : MsgBox(m1) ' :End

        Dim PosOrigini(lo) As String

        For h = 1 To lo
            For k = 1 To NumNodi
                If ListaOrigini(h) = nodo(k).origine Then
                    PosOrigini(h) &= k.ToString & " "
                End If
            Next
            PosOrigini(h) = Trim(PosOrigini(h))
        Next


        Dim fatto As Boolean = True
        Dim presente As Boolean = False
        Dim v As String = ""
        Do
            fatto = True
            For h = 2 To lo
                presente = False
                For k = 1 To h - 1
                    Dim indice() As String
                    'Try
                    indice = PosOrigini(k).Split(" ")

                    Try
                        For Each v In indice
                            If ListaOrigini(h) = nodo(CInt(v)).destinazione(1) Then
                                presente = True
                                Exit For
                            End If
                        Next
                    Catch ex As Exception
                        MsgBox(Val(v))
                    End Try
                    If presente = True Then Exit For
                Next

                If presente = False Then
                    fatto = False
                    Dim tp As String = ListaOrigini(h)
                    Dim ti As String = PosOrigini(h)
                    Dim tr As Integer = Porigini(h)
                    For i As Integer = h + 1 To lo
                        ListaOrigini(i - 1) = ListaOrigini(i)
                        PosOrigini(i - 1) = PosOrigini(i)
                        Porigini(i - 1) = Porigini(i)
                    Next
                    ListaOrigini(lo) = tp
                    PosOrigini(lo) = ti
                    Porigini(lo) = tr
                    Exit For
                End If
            Next
            If fatto = True Then Exit Do
        Loop
        'Dim m As String = "" : For z As Integer = 1 To lo : m += ListaOrigini(z) + vbCrLf : Next : MsgBox(m)

        ': End

        Dim VecchiaOrigine As String = ""
        Dim VecchioConnettivo As String = ""

        For h = 1 To lo
            Dim indice() As String = PosOrigini(h).Split(" ")
            For Each v In indice
                k = Val(v)
                Try
                    If nodo(k).origine <> "" Then
                        If nodo(k).origine <> VecchiaOrigine Then
                            VecchiaOrigine = nodo(k).origine
                            VecchioConnettivo = nodo(k).connettivo
                            tt &= nodo(k).origine & vbCrLf '& tt
                            tt &= Chr(9) & nodo(k).connettivo & vbCrLf
                        Else
                            If VecchioConnettivo <> nodo(k).connettivo Then
                                VecchioConnettivo = nodo(k).connettivo
                                tt &= Chr(9) & nodo(k).connettivo & vbCrLf
                            End If
                        End If
                        tt &= Chr(9) & Chr(9) & nodo(k).destinazione(1) & vbCrLf ' nodo(k).nd)
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Next
        Next

        Return tt

    End Function

    Public Sub LeggiOCR()
        FermaVoce()
        testo = Clipboard.GetText
        If testo = "" Then
            SenzaEco("Non c'è nulla da leggere.")
            Exit Sub
        End If
        AggiungiAppunto(testo)
        testo = FiltroLineetta(testo)
        If VoceZitta() = False Then
            FermaVoce()
        End If
        SenzaEco(ConvertiMinuscole(testo))
    End Sub

    Private Sub MioTimer_Tick(ByVal sender As Object, ByVal e As EventArgs) Handles MioTimer.Tick
        Dim tmp As IntPtr = Nothing
        tmp = GetForegroundWindow
        If tmp <> Me.Handle And tmp <> Nothing And tmp <> altroHndl Then
            altroHndl = tmp
        End If
    End Sub

    Private Sub cmdImposta_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdApriDocumento.Click
        PaginaPrincipale()
        Me.Close()
    End Sub

    Sub PaginaPrincipale()

        FermaVoce()
        MioTimer.Enabled = False
        blnChiudi = False
        blnHoAperto = True
        DeRegistraTasti()
        SalvaPosizione()
        'frmLeggiConMe.tmrSalva.Enabled = True
        frmLeggiConMe.AggiornaVoce()
        frmLeggiConMe.Show()
        frmLeggiConMe.RegistraTasti()
        frmLeggiConMe.tmrSalva.Enabled = True
    End Sub

    Sub ApriPDF(ByVal nf As String)
        FermaVoce()
        MioTimer.Enabled = False
        blnChiudi = False
        blnHoAperto = True
        DeRegistraTasti()
        frmLeggiConMe.tmrSalva.Enabled = True
        frmPDF.Show()
        frmPDF.Timer1.Enabled = False
        frmPDF.AprifilePDF(nf)
        Me.Close()
    End Sub

    Sub ApriRTF(ByVal nf As String)
        FermaVoce()
        MioTimer.Enabled = False
        blnChiudi = False
        blnHoAperto = True
        DeRegistraTasti()
        frmLeggiConMe.tmrSalva.Enabled = True
        frmLeggiConMe.RTB.LoadFile(FileDaAprire, RichTextBoxStreamType.RichText)
        frmLeggiConMe.RTB.SelectAll()
        frmLeggiConMe.RTB.Font = FontPredefinito
        frmLeggiConMe.RTB.SelectionStart = 0
        frmLeggiConMe.RTB.SelectionLength = 0
        frmLeggiConMe.Show()
        Me.Close()
    End Sub

    Sub ApriDocx(ByVal nf As String)
        FermaVoce()
        MioTimer.Enabled = False
        blnChiudi = False
        blnHoAperto = True
        DeRegistraTasti()
        frmLeggiConMe.tmrSalva.Enabled = True
        frmLeggiConMe.RTB.Text = ExtractText(FileDaAprire)
        frmLeggiConMe.RTB.SelectAll()
        frmLeggiConMe.RTB.Font = FontPredefinito
        frmLeggiConMe.RTB.SelectionStart = 0
        frmLeggiConMe.RTB.SelectionLength = 0
        frmLeggiConMe.Show()
        Me.Close()
    End Sub

    Private Sub cmdStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdStop.Click
        FermaVoce()
    End Sub

    Private Sub cmdPausa_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPausa.Click
        Pausa()
    End Sub

    Private Sub cmdVoce_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdVoce.Click
        MenuVoci.Show()
        MenuVoci.Left = Me.Left
        MenuVoci.Top = Me.Top + altezza
    End Sub

    Private Sub MenuVoci_ItemClicked(ByVal sender As Object, ByVal e As ToolStripItemClickedEventArgs) Handles MenuVoci.ItemClicked
        Dim item As String = e.ClickedItem.ToString
        If item = "ANNULLA" Then Exit Sub
        Sceglivoce(item)
    End Sub

    Public Sub Sceglivoce(item As String)
        intParlante = Sceltavoce(item, MenuVoci, cmdVoce)
        cmdVoce.Image = ScegliBandiera(intParlante)
    End Sub

    Private Sub frmLettore_FormClosed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles Me.FormClosed
        If blnChiudi = True Then frmLeggiConMe.Close()
    End Sub

    Private Sub frmLettore_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'SalvaPosizione()
        Try
            DeRegistraTasti()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmLettore_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
        'frmLeggiConMe.Hide()
        cmdApriDocumento.AllowDrop = True
        If NumVoci > 0 Then
            CreamenuVoci(MenuVoci)
            For i As Integer = 0 To MenuVoci.Items.Count - 1
                If MenuVoci.Items(i).ToString = NomeCorto(intParlante) Then
                    MenuVoci.Items(i).Select()
                    cmdVoce.Image = ScegliBandiera(i)
                End If
            Next
        Else
            MenuVoci.Items.Add("Nessuna Voce")
        End If

        If Capture2text() = "" Or frmLeggiConMe.ckOCR.Checked = False Then
            btnOCR.Enabled = False
            btnOCR.Visible = False
            btnTrad.Left -= cmdApriDocumento.Width
            btnAggiungiTesto.Left -= cmdApriDocumento.Width
            cmdApriDocumento.Left -= cmdApriDocumento.Width
            picComandi.Width -= cmdApriDocumento.Width
            Me.Width -= cmdApriDocumento.Width
        End If

        If ConnessioneInternet() = False Or (frmLeggiConMe.ckTrad.Checked = False And frmLeggiConMe.ckTradLat.Checked = False) Then 'ConnessioneInternet() InternetConnesso()
            btnTrad.Enabled = False
            btnTrad.Visible = False
            btnAggiungiTesto.Left -= cmdApriDocumento.Width
            cmdApriDocumento.Left -= cmdApriDocumento.Width
            picComandi.Width -= cmdApriDocumento.Width
            Me.Width -= cmdApriDocumento.Width
        Else
            If frmLeggiConMe.ckTradLat.Checked = True Then
                btnTrad.Text = ""
                btnTrad.BackgroundImage = My.Resources.bandLat
            Else
                btnTrad.BackgroundImage = My.Resources.BandIta
                btnTrad.Text = "T"
            End If
        End If

        If blnAggTesto = False Then
            btnAggiungiTesto.Enabled = False
            btnAggiungiTesto.Visible = False
            cmdApriDocumento.Left -= cmdApriDocumento.Width
            picComandi.Width -= cmdApriDocumento.Width
            Me.Width -= cmdApriDocumento.Width
        End If

        mioHandle = Me.Handle
        LeggiMisureFinestra()
        Me.Width = larghezza : Me.Height = altezza
        RegistraTasti()

        MioTimer.Enabled = True

    End Sub

    Private Sub cmdImposta_DragDrop(ByVal sender As Object, ByVal e As System.Windows.Forms.DragEventArgs) Handles cmdApriDocumento.DragDrop

        FileDaAprire = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
        If blnApriCartella = True Then
            blnApriCartella = False
            Process.Start("explorer.exe", FileDaAprire)
        Else
            Dim est As String = ext(FileDaAprire)
            If est = "" Then Exit Sub
            est = UCase(Mid(est, 2))
            If est = "PDF" Then
                If CeLettorePDF() = True Then
                    ApriPDF(FileDaAprire)
                End If
                'Process.Start(PDFXCviewer, Chr(34) & FileDaAprire & Chr(34))
            ElseIf est = "RTF" Then
                ApriRTF(FileDaAprire)
            ElseIf est = "DOCX" Then
                ApriDocx(FileDaAprire)
            Else
                Process.Start(FileDaAprire)
            End If
        End If

    End Sub

    Private Sub cmdPiu_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdPiu.Click
        FermaVoce()
        AumentaVelocita()
        Leggi()
    End Sub

    Private Sub cmdMeno_Click(ByVal sender As Object, ByVal e As EventArgs) Handles cmdMeno.Click
        FermaVoce()
        DiminuisciVelocita()
        Leggi()
    End Sub

    Dim blnApriCartella As Boolean = False

    Private Sub cmdImposta_DragEnter(ByVal sender As Object, ByVal e As DragEventArgs) Handles cmdApriDocumento.DragEnter

        If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
            FileDaAprire = CType(e.Data.GetData(DataFormats.FileDrop), Array).GetValue(0).ToString
            If FileDaAprire = "" Then Exit Sub
            Dim file As String = (System.IO.Path.GetFileName(FileDaAprire))
            file = file.Replace("_", " ")
            SenzaEco(file)
            Dim attributes As System.IO.FileAttributes = System.IO.File.GetAttributes(FileDaAprire)
            If (attributes And FileAttributes.Directory) = FileAttributes.Directory Then
                blnApriCartella = True
            End If
            Dim est As String = ext(FileDaAprire)
            If est <> "" Then est = UCase(Mid(est, 2))
            e.Effect = DragDropEffects.Copy
        End If

    End Sub

    Private Sub cmdImposta_DragLeave(ByVal sender As Object, ByVal e As EventArgs) Handles cmdApriDocumento.DragLeave
        FermaVoce()
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

    Private Sub cmdImposta_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmdApriDocumento.MouseUp, cmdLeggi.MouseUp, cmdStop.MouseUp, cmdPausa.MouseUp, cmdVoce.MouseUp, cmdPiu.MouseUp, cmdMeno.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As System.Windows.Forms.Button = sender
            LeggiMessaggi(bot.Tag)
        End If
    End Sub

    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)

        If m.Msg = WM_HOTKEY Then

            Dim numTasto As Integer = (CInt(m.WParam))
            Select Case numTasto
                Case 40010
                    Leggi()
                Case 40011
                    FermaVoce()
                Case 40012
                    AumentaVelocita()
                Case 40013
                    DiminuisciVelocita()
                Case Else
            End Select
        End If

        MyBase.WndProc(m)
    End Sub

    Private Sub RegistraTasti()
        'Exit Sub
        Call RegisterHotKey(Me.Handle, 40010, MOD_CONTROL, Keys.A)
        Call RegisterHotKey(Me.Handle, 40011, MOD_CONTROL, Keys.S)
        Call RegisterHotKey(Me.Handle, 40012, MOD_CONTROL, Keys.Up)
        Call RegisterHotKey(Me.Handle, 40013, MOD_CONTROL, Keys.Down)

    End Sub

    Private Sub DeRegistraTasti()
        'Exit Sub
        Call UnregisterHotKey(Me.Handle, 40010)
        Call UnregisterHotKey(Me.Handle, 40011)
        Call UnregisterHotKey(Me.Handle, 40012)
        Call UnregisterHotKey(Me.Handle, 40013)
    End Sub

    Function Traduci(ByVal daTr As String) As String

        If daTr = "" Then
            Return ""
            Exit Function
        End If

        Dim t As GoogleTranslator.Translator = New GoogleTranslator.Translator
        'Dim st2 As String = t.Translate(st, "Italian", "English")
        Dim st2 As String = ""
        If btnTrad.Text = "" Then
            st2 = t.Translate(daTr, "Latin", "Italian")
        Else
            st2 = t.Translate(daTr, "Automatico", "Italian")
        End If
        daTr = ""
        Return st2
    End Function

    Sub LeggiTraduzione()

        FermaVoce()
        Clipboard.Clear()
        CopiaTesto()

        If testo = "" Then
            SenzaEco("Non c'è nulla da leggere.")
            Exit Sub
        End If

        If VoceZitta() = False Then
            FermaVoce()
        End If
        'MsgBox("1 " & testo)
        Dim tes As String = (Traduci(testo))

        'MsgBox(tes) : LeggiLaTraduzione(tes) : Exit Sub

        LeggiLaTraduzione(ConvertiMinuscole(tes))

    End Sub

    Private Sub btnTrad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTrad.Click
        If VoceZitta() = False Then
            FermaVoce()
        Else
            LeggiTraduzione()
        End If
    End Sub

    Private Sub btnTrad_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnTrad.MouseUp, btnOCR.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim bot As System.Windows.Forms.Button = sender
            LeggiMessaggi(bot.Tag)
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOCR.Click
        Schermo3.Show()
        Me.Hide()
    End Sub

    Public Sub LeggiPosizione()

        Dim loc As Point
        Try
            loc.X = CShort(GetSetting("LeggiXme", "impostazioni", "X", "0"))
            loc.Y = CShort(GetSetting("LeggiXme", "impostazioni", "Y", "0"))
        Catch ex As Exception
            loc.X = 0
            loc.Y = 0
        End Try

        Dim a As Integer = My.Computer.Screen.Bounds.Size.Width
        Dim b As Integer = My.Computer.Screen.Bounds.Size.Height

        If loc.X > (a - Me.Width) Or loc.Y > (b - Me.Height) Then
            loc.X = 0
            loc.Y = 0
        End If

        Me.Location = loc

    End Sub

    Sub SalvaPosizione()

        Try
            SaveSetting("LeggiXme", "impostazioni", "X", Me.Location.X.ToString)
            SaveSetting("LeggiXme", "impostazioni", "Y", Me.Location.Y.ToString)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnAggiungiTesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAggiungiTesto.Click
        FermaVoce()
        frmLeggiConMe.RTB.AppendText(vbCrLf & Appunti(NAppunti))
        My.Computer.Audio.Play(My.Resources.splash, AudioPlayMode.WaitToComplete)
    End Sub

  

    Private Sub MenuVoci_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles MenuVoci.Opening

    End Sub
End Class