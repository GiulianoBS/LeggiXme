Imports System.Text.RegularExpressions

Public Class frmCmap
    Dim ColEv0 As Color = Color.LightGreen 'Color.FromArgb(0, 255, 255)
    Dim ColEv1 As Color = Color.Aqua 'Color.FromArgb(0, 255, 255)
    Dim ColEv2 As Color = Color.Pink 'Color.FromArgb(255, 0, 255)
    Dim ColEv3 As Color = Color.Yellow 'Color.FromArgb(255, 255, 0)
    Public ColoreSfondo As Color = Color.White
    Dim procCM As Process
    Dim Origine As String = "", Relazione As String = "", Destinazione() As String
    Dim qd As Integer = 0
    Dim CartellaDocumenti As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    Public Membro As Integer = 0

    Private Declare Function FindExecutable Lib "shell32.dll" Alias "FindExecutableA" (ByVal lpFile As String, ByVal lpDirectory As String, ByVal lpResult As String) As Integer
    ' Return the path to the program associated with this extension.

    Private Sub frmCmap_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Panel1.Visible = False
        Me.Hide()
        frmLeggiConMe.Show()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        RTB.Font = FontPredefinito
        RTB.Refresh()
    End Sub

    Sub Sottolinea()
        Dim textStyle As New FontStyle
        Try
            textStyle = RTB.SelectionFont.Style Or FontStyle.Underline
            Dim bfont As New Font(RTB.Font, textStyle)
            RTB.SelectionFont = New Font(RTB.SelectionFont, textStyle)
            RTB.SelectionLength = 0
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub pulisci(ByVal t As String)
        If t <> LTrim(t) Then
            RTB.SelectionStart += 1
            RTB.SelectionLength -= 1
            t = LTrim(t)
        End If

        If t <> RTrim(t) Then
            RTB.SelectionLength -= 1
            t = LTrim(t)
        End If
        't = Trim(RTB.SelectedText)
        't = t.Replace(vbLf, "")
        't = t.Replace(vbCr, "")
        'Return t
    End Sub

    Sub TogliSottolineatura()
        Dim textStyle As New FontStyle
        Try
            textStyle = RTB.SelectionFont.Style And Not FontStyle.Underline
            Dim bfont As New Font(RTB.Font, textStyle)
            RTB.SelectionFont = New Font(RTB.SelectionFont, textStyle)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Sub Evidenzia1()
        SistemaSelezione(RTB)
        pulisci(RTB.SelectedText)
        If RTB.SelectionBackColor = ColoreSfondo Then 'RTB.BackColor Then
            RTB.SelectionBackColor = ColEv1
            Origine = RTB.SelectedText
            'Origine = Trim(RTB.SelectedText)
            Origine = Origine.Replace(vbLf, "")
            Origine = Origine.Replace(vbCr, "")
            Sottolinea()
        Else
            MsgBox("ATTENZIONE! Non è possibile modificare manualmente le selezioni." & vbCrLf & "Per rifare la proposizione, premi il pulsante 'AZZERA'.", MsgBoxStyle.Critical)
            'RTB.SelectionBackColor = ColoreSfondo
        End If
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub Evidenzia2()
        SistemaSelezione(RTB)
        pulisci(RTB.SelectedText)
        If RTB.SelectionBackColor = ColoreSfondo Then 'RTB.BackColor Then
            RTB.SelectionBackColor = ColEv2
            Relazione = RTB.SelectedText
            'Relazione = Trim(RTB.SelectedText)
            Relazione = Relazione.Replace(vbLf, "")
            Relazione = Relazione.Replace(vbCr, "")
            Sottolinea()
        Else
            MsgBox("ATTENZIONE! Non è possibile modificare manualmente le selezioni." & vbCrLf & "Per rifare la proposizione, premi il pulsante 'AZZERA'.", MsgBoxStyle.Critical)
            'RTB.SelectionBackColor = ColoreSfondo
        End If
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub Evidenzia3()
        SistemaSelezione(RTB)
        pulisci(RTB.SelectedText)
        If RTB.SelectionBackColor = ColoreSfondo Then 'RTB.BackColor Then
            RTB.SelectionBackColor = ColEv3
            qd += 1
            ReDim Preserve Destinazione(qd)
            Destinazione(qd) = RTB.SelectedText
            'Destinazione(qd) = Trim(RTB.SelectedText)
            Destinazione(qd) = Destinazione(qd).Replace(vbLf, "")
            Destinazione(qd) = Destinazione(qd).Replace(vbCr, "")
            Sottolinea()
        Else
            MsgBox("ATTENZIONE! Non è possibile modificare manualmente le selezioni." & vbCrLf & "Per rifare la proposizione, premi il pulsante 'AZZERA'.", MsgBoxStyle.Critical)
            'RTB.SelectionBackColor = ColoreSfondo
        End If
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

    Sub DisEvidenziaTutto()
        RTB.SelectAll()
        RTB.SelectionBackColor = ColoreSfondo
        RTB.SelectionLength = 0
        qd = 0
        Origine = "" : Relazione = "" : ReDim Destinazione(0)
    End Sub

    Sub DisSottolineaTutto()
        RTB.SelectAll()
        DisSottolineaTutto()
        RTB.SelectionLength = 0
    End Sub

    'Function Cmap() As String
    'Dim fil As String = ""
    '   fil = ProgrammaAssociato("cmap")
    '   Return fil
    'End Function

    'Dim righe() As String
    'Dim qRighe As Integer = -1

    Sub PassaDati()
        'Dim riga As String = ""

        Dim row(2) As String

        For k As Integer = 1 To qd
            'riga &= Origine & Chr(9) & Relazione & Chr(9) & Destinazione(k) & vbCrLf
            'qRighe += 1
            'ReDim Preserve righe(qRighe)
            'righe(qRighe) = Origine & Chr(9) & Relazione & Chr(9) & Destinazione(k)
            row(0) = Origine
            row(1) = Relazione
            row(2) = Destinazione(k)
            DataGridView1.Rows.Add(row)
        Next
        Origine = "" : Relazione = "" : ReDim Destinazione(0)
        'Origine & Chr(9) & Relazione & Chr(9) & Destinazione(k) & vbCrLf
        'TB.AppendText(riga)
    End Sub

    Sub VuotaGriglia()
        DataGridView1.Rows.Clear()
        'ReDim righe(0)
        'qRighe = -1
    End Sub

    Sub Salva()

        For r As Integer = 0 To DataGridView1.RowCount - 2
            'If righe(r) <> "" Then
            If EstraiOrigine(r) = "" Then
                MsgBox("MANCA L'ORIGINE ALLA PROPOSIZIONE " & (r + 1).ToString)
                Exit Sub
            End If
            If EstraiLegame(r) = "" Then
                MsgBox("MANCA LA RELAZIONE ALLA PROPOSIZIONE " & (r + 1).ToString)
                Exit Sub
            End If
            If EstraiDestinazione(r) = "" Then
                MsgBox("MANCA LA DESTINAZIONE ALLA PROPOSIZIONE " & (r + 1).ToString)
                Exit Sub
            End If
            'End If
        Next

        Dim fil As String = SalvaIlFile()
        If fil = "" Then Exit Sub

        Dim f As Integer = FreeFile()
        Dim riga As String = ""
        SalvaDocumento(fil)
        Try
            'Dim t As String = ""
            FileOpen(f, fil, OpenMode.Output)
            For r As Integer = 0 To DataGridView1.RowCount - 2
                'If righe(r) <> "" Then
                't &= righe(r) & vbCrLf
                PrintLine(f, ComponiRiga(r))
                'End If
            Next
            'Dim objWriter As New System.IO.StreamWriter(fil, False)
            'objWriter.WriteLine(t)
            'objWriter.Close()
            'objWriter.Dispose()
            FileClose(f)
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & fil)
            FileClose(f)
            Exit Sub
        End Try
    End Sub

    Sub Apri()
        Dim fil As String = ApriIlFile()
        If fil = "" Then Exit Sub
        Dim riga As String = ""
        Dim f As Integer = FreeFile()
        Try
            FileOpen(f, fil, OpenMode.Input)
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        VuotaGriglia()
        'qRighe = -1
        'ReDim righe(0)
        Dim row(2) As String
        Do While Not EOF(f)
            riga = LineInput(f)
            If Len(riga) > 6 Then
                Try
                    'qRighe += 1
                    'ReDim Preserve righe(qRighe)
                    'righe(qRighe) = riga
                    row(0) = Trim(Mid(riga, 1, InStr(riga, Chr(9)) - 1))
                    riga = Mid(riga, InStr(riga, Chr(9)) + 1)
                    row(1) = Trim(Mid(riga, 1, InStr(riga, Chr(9)) - 1))
                    row(2) = Trim(Mid(riga, InStr(riga, Chr(9)) + 1))
                    DataGridView1.Rows.Add(row)
                Catch ex As Exception

                End Try
            End If
        Loop
        FileClose(f)
        ApriDocumento(fil)

    End Sub

    Function ApriIlFile() As String
        Dim ApriFile As New OpenFileDialog()
        ApriFile.Title = "APRI TESTO PER CMAP"
        ApriFile.Filter = "|*.txt"
        ApriFile.InitialDirectory = CartellaDocumenti

        If ApriFile.ShowDialog() = DialogResult.OK Then
            Return ApriFile.FileName
        Else
            Return ""
        End If

    End Function

    Function SalvaIlFile(Optional ByVal stesso As Boolean = False) As String
        Dim ApriFile As New SaveFileDialog()
        ApriFile.Title = "SALVA TESTO PER CMAP"
        ApriFile.DefaultExt = "txt"
        ApriFile.InitialDirectory = CartellaDocumenti
        ApriFile.FileName = "CMAP_" & Trim(DataGridView1.Rows(0).Cells(0).Value) & ".txt"
        If ApriFile.ShowDialog() = DialogResult.OK Then
            Return ApriFile.FileName
        Else
            Return ""
        End If

    End Function

    Sub fnAnnulla()
        If RTB.CanUndo Then
            RTB.Undo()
        End If
    End Sub

    Sub fnRipristina()
        If RTB.CanRedo Then
            RTB.Redo()
        End If
    End Sub

    Sub fnTaglia()
        If RTB.SelectedText <> "" Then
            RTB.Cut()
        End If
    End Sub

    Sub fnCopia()
        RTB.Copy()
    End Sub

    Sub fnIncolla()
        If My.Computer.Clipboard.ContainsText Or My.Computer.Clipboard.ContainsImage Then
            RTB.Paste()
        End If
    End Sub

    Private Sub Annulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Annulla.Click
        fnAnnulla()
    End Sub

    Private Sub Ripristina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Ripristina.Click
        fnRipristina()
    End Sub

    Private Sub Taglia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Taglia.Click
        fnTaglia()
    End Sub

    Private Sub Copia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Copia.Click
        fnCopia()
    End Sub

    Private Sub Incolla_Tutto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Incolla_Tutto.Click
        fnIncolla()
    End Sub

    Private Sub SalvaDocumento(ByVal fil As String)
        fil = Mid(fil, 1, Len(fil) - 3) & "rtf"
        Dim nf As String = fil
        Try
            RTB.SaveFile(nf, RichTextBoxStreamType.RichText)
        Catch ex As Exception
            MsgBox("Errore nel salvataggio di " & fil, MsgBoxStyle.Critical)
        End Try
    End Sub

    Sub ApriDocumento(ByVal fil As String)

        fil = Mid(fil, 1, Len(fil) - 3) & "rtf"
        If IO.File.Exists(fil) = False Then Exit Sub
        Try
            RTB.LoadFile(fil, RichTextBoxStreamType.RichText)

            Dim nf As String = fil
            Dim i As Integer = InStrRev(nf, "\")
            nf = Mid(nf, i + 1)
            Me.Text = "LeggiXme_CMap - " & nf
        Catch er As Exception
            MsgBox("Errore nell'apertura di " & fil, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub EliminaRigaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaRigaToolStripMenuItem.Click
        If Not DataGridView1.CurrentRow.IsNewRow Then
            Try
                DataGridView1.Rows.Remove(DataGridView1.CurrentRow)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub

    Sub Leggi()
        FermaVoce()
        If RTB.Text = "" Then
            SenzaEco("Non c'è nulla da leggere")
            Exit Sub
        End If
        Dim t As String = ""
        zeppa = RTB.SelectionStart
        inizio = RTB.SelectionStart
        lungh = RTB.SelectionLength
        If RTB.SelectedText <> "" Then
            t = RTB.SelectedText
        Else
            t = Mid(RTB.Text, zeppa + 1, Len(RTB.Text) - zeppa)
        End If
        If t <> "" Then
            ConEco(RTB, t)
            If lungh <> 0 Then
                RTB.SelectionStart = inizio
                RTB.SelectionLength = lungh
            End If
        End If
    End Sub

    Private Sub Button9_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Panel1.Visible = False
        Me.Hide()
        frmLeggiConMe.Show()
    End Sub

    Private Sub btnLeggi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeggi.Click
        Leggi()
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        FermaVoce()
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            procCM = Process.Start(Cmap)
            'proc = Process.Start(prg)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnInvia_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvia.Click
        PassaDati()
        DisEvidenziaTutto()
    End Sub

    Private Sub btnM1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnM1.Click
        Salva()
    End Sub

    Private Sub btnM2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnM2.Click
        Apri()
        ListBox1.Items.Clear()
        CaricaListBox()
    End Sub

    Private Sub btnF4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF4.Click
        TogliSottolineatura()
    End Sub

    Private Sub btnF3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF3.Click
        DisEvidenziaTutto()
    End Sub

    Sub CaricaListBox()
        'Panel1.Visible = True
        Dim a As String = EstraiOrigine(0)
        If a <> "" Then ListBox1.Items.Add(a)
        For i As Integer = 0 To DataGridView1.RowCount - 2
            a = EstraiDestinazione(i)
            Try
                If ListBox1.Items.Contains(a) = False Then
                    ListBox1.Items.Add(a) 'EstraiDestinazione(i))
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next

    End Sub

    Private Sub btnF2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF2.Click
        If RTB.SelectionBackColor <> ColoreSfondo Then
            MsgBox("ATTENZIONE! Non è possibile modificare manualmente le selezioni." & vbCrLf & "Per rifare la proposizione, premi il pulsante 'AZZERA'.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Panel1.Visible = False
        If DataGridView1.RowCount < 2 Then
            Evidenzia3()
        Else
            Membro = 3
            ListBox1.Items.Clear()
            CaricaListBox()
            If RTB.SelectionLength = 0 Then
                Label1.Text = "SCEGLI IL CONCETTO TRA QUESTI:"
                Panel1.Visible = True
            Else
                Dim a As String = Trim(RTB.SelectedText)
                Panel1.Visible = False
                If ListBox1.FindStringExact(a) = ListBox.NoMatches Then
                    Evidenzia3()
                Else
                    Dim Presente As Boolean = False
                    ListBox1.Items.Clear()
                    ListBox1.Items.Add(Trim(a))
                    CaricaListBox()
                    For k As Integer = ListBox1.Items.Count - 1 To 1 Step -1
                        Try
                            If InStr(a, ListBox1.Items(k)) <> 0 Then
                                Presente = True
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                        Try
                            If InStr(ListBox1.Items(k), a) <> 0 Then
                                Presente = True
                            End If
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                        If Presente = False Then
                            ListBox1.Items.RemoveAt(k)
                        End If
                        Presente = False
                    Next
                    If ListBox1.Items.Count > 1 Then
                        Label1.Text = "SCEGLI IL CONCETTO TRA QUESTI:"
                        Panel1.Visible = True
                    Else
                        Evidenzia3()
                    End If
                End If
            End If
        End If

    End Sub

    Private Sub btnF1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF1.Click
        If RTB.SelectionBackColor <> ColoreSfondo Then
            MsgBox("ATTENZIONE! Non è possibile modificare manualmente le selezioni." & vbCrLf & "Per rifare la proposizione, premi il pulsante 'AZZERA'.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Relazione <> "" Then
            MsgBox("ATTENZIONE! Non puoi evidenziare" & vbCrLf & "più di una relazione per volta.", MsgBoxStyle.Critical, "SELEZIONE DI RELAZIONE")
            Exit Sub
        End If
        If DataGridView1.RowCount < 2 Then
            Evidenzia2()
        Else
            Dim a As String = ""
            Dim index As Integer = -1
            If RTB.SelectionLength = 0 Then
                Membro = 2
                For i As Integer = 0 To DataGridView1.RowCount - 2
                    a = EstraiLegame(i)
                    index = ListBox1.FindStringExact(a)
                    Try
                        If index = ListBox.NoMatches Then
                            ListBox1.Items.Add(a)
                        End If
                    Catch ex As Exception

                    End Try
                Next
                Label1.Text = "SCEGLI LA RELAZIONE TRA QUESTE:"
                Panel1.Visible = True
            Else
                Evidenzia2()
            End If
        End If

    End Sub

    ' !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!

    Private Sub btnF0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnF0.Click
        If RTB.SelectionBackColor <> ColoreSfondo Then
            MsgBox("ATTENZIONE! Non è possibile modificare manualmente le selezioni." & vbCrLf & "Per rifare la proposizione, premi il pulsante 'AZZERA'.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If Origine <> "" Then
            MsgBox("ATTENZIONE! Non puoi evidenziare" & vbCrLf & "più di un concetto origine per volta.", MsgBoxStyle.Critical, "SELEZIONE DI CONCETTO-ORIGINE")
            Exit Sub
        End If
        If DataGridView1.RowCount < 2 Then
            Evidenzia1()
        Else
            CaricaListBox()
            Dim a As String = Trim(RTB.SelectedText)
            Dim inz As Integer = 0
            Dim index As Integer = -1 'ListBox1.FindString(RTB.SelectedText)
            For k As Integer = 0 To ListBox1.Items.Count - 1
                If UCase(a) = UCase(ListBox1.Items(k)) Then
                    index = k
                    a = ListBox1.Items(k)
                    If Len(a) < Len(RTB.SelectedText) Then
                        a &= " "
                    End If
                    inz = RTB.SelectionStart
                    RTB.SelectedText = a
                    RTB.SelectionStart = inz
                    RTB.SelectionLength = Len(a)
                    Exit For
                End If
            Next

            If index = -1 Then
                'MsgBox(ListBox1.Items.Count)
                Membro = 1
                Label1.Text = "SCEGLI IL CONCETTO TRA QUESTI:"
                Panel1.Visible = True
            Else
                Evidenzia1()
                ListBox1.Items.Clear()
            End If
        End If
    End Sub

    Private Sub btnAnnullaMappa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnullaMappa.Click
        If RTB.CanUndo Then
            RTB.Undo()
        End If
    End Sub

    Private Sub DataGridView1_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellEndEdit
        Dim r As Integer = e.RowIndex
        Dim c As Integer = e.ColumnIndex
        Try
            'righe(r) = RicomponiRiga(righe(r), c, DataGridView1.CurrentCell.Value)
        Catch ex As Exception

        End Try
    End Sub

    Function ComponiRiga(r As Integer) As String
        Dim row(2) As String
        'righe(qRighe) = riga
        Try
            row(0) = DataGridView1.Item(0, r).Value
            row(1) = DataGridView1.Item(1, r).Value
            row(2) = DataGridView1.Item(2, r).Value
            Return row(0) & Chr(9) & row(1) & Chr(9) & row(2)
        Catch ex As Exception
            Return ""
        End Try
    End Function

    Function RicomponiRiga(ByVal riga As String, ByVal col As Integer, ByVal cont As String) As String
        Dim row(2) As String
        'righe(qRighe) = riga
        Try
            row(0) = Trim(Mid(riga, 1, InStr(riga, Chr(9)) - 1))
            riga = Mid(riga, InStr(riga, Chr(9)) + 1)
            row(1) = Trim(Mid(riga, 1, InStr(riga, Chr(9)) - 1))
            row(2) = Trim(Mid(riga, InStr(riga, Chr(9)) + 1))
            row(col) = cont
            Return row(0) & Chr(9) & row(1) & Chr(9) & row(2)

        Catch ex As Exception
            Return ""
        End Try
    End Function

    Function EstraiOrigine(ByVal i As Integer) As String
        'Dim riga As String = righe(i)
        'riga = Mid(riga, InStr(riga, Chr(9)) + 1)
        'riga = Mid(riga, InStr(riga, Chr(9)) + 1)
        Try
            Return DataGridView1.Item(0, i).Value
        Catch ex As Exception
            MsgBox(i)
            Return ""
        End Try
    End Function

    Function EstraiDestinazione(ByVal i As Integer) As String
        ' Dim riga As String = righe(i)
        'riga = Mid(riga, InStr(riga, Chr(9)) + 1)
        'riga = Mid(riga, InStr(riga, Chr(9)) + 1)
        Return DataGridView1.Item(2, i).Value
    End Function

    Function EstraiLegame(ByVal i As Integer) As String
        'Dim riga As String = righe(i)
        'riga = Mid(riga, InStr(riga, Chr(9)) + 1)
        'riga = Mid(riga, 1, InStr(riga, Chr(9)) - 1)
        Return DataGridView1.Item(1, i).Value
    End Function

    Private dragging As Boolean
    Private beginX, beginY As Integer

    Private Sub Panel1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseDown
        dragging = True
        beginX = e.X
        beginY = e.Y
    End Sub

    Private Sub Panel1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseMove
        If dragging = True Then
            Panel1.Location = New Point(Panel1.Location.X + e.X - beginX, Panel1.Location.Y + e.Y - beginY)
            Me.Refresh()
        End If
    End Sub

    Private Sub Panel1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel1.MouseUp
        dragging = False
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Select Case Membro
            Case 1 : AssegnaScelta1()
            Case 2 : AssegnaScelta2()
            Case 3 : AssegnaScelta3()
        End Select
        Membro = 0
    End Sub

    Sub AssegnaScelta1()
        ' segna risposta
        Dim a As String = ListBox1.SelectedItem
        If a <> "" Then
            Dim i As Integer = InStr(RTB.Text, a)
            If i <> 0 Then
                RTB.SelectionStart = i - 1
                RTB.SelectionLength = Len(a)
                Evidenzia1()
            Else
                'MsgBox("<" & a & ">" & Asc(a))
            End If
            'RTB.SelectedText = a
        End If
        Panel1.Visible = False
    End Sub

    Sub AssegnaScelta2()
        ' segna risposta
        Dim a As String = ListBox1.SelectedItem
        If a <> "" Then
            Dim i As Integer = InStr(RTB.Text, a)
            If i <> 0 Then
                RTB.SelectionStart = i - 1
                RTB.SelectionLength = Len(a)
                Evidenzia2()
            End If
            'RTB.SelectedText = a
        End If
        Panel1.Visible = False
    End Sub

    Sub AssegnaScelta3()
        ' segna risposta
        Dim a As String = ListBox1.SelectedItem
        If a <> "" Then
            Dim i As Integer = InStr(RTB.Text, a)
            If i <> 0 Then
                RTB.SelectionStart = i - 1
                RTB.SelectionLength = Len(a)
                Evidenzia3()
            End If
            'RTB.SelectedText = a
        End If
        Panel1.Visible = False
    End Sub

    Private Sub btnAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAnnulla.Click
        Panel1.Visible = False
        Membro = 0
    End Sub

    Private Sub Panel1_VisibleChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Panel1.VisibleChanged
        If Panel1.Visible = True Then

        Else
            ListBox1.Items.Clear()
        End If
    End Sub

    Private Sub ListBox1_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseDoubleClick
        Select Case Membro
            Case 1 : AssegnaScelta1()
            Case 2 : AssegnaScelta2()
            Case 3 : AssegnaScelta3()
        End Select
    End Sub

    Private Sub ListBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Right Then
            Dim a As String = ListBox1.SelectedItem
            If a <> "" Then
                SenzaEco(a)
            End If
        End If
    End Sub

    Private Sub LeggiRigaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LeggiRigaToolStripMenuItem.Click
        Try
            If Not DataGridView1.CurrentRow.IsNewRow Then
                Dim i As Integer = DataGridView1.CurrentRow.Index
                SenzaEco(ComponiRiga(i))
            End If
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If RTB.ZoomFactor < 5 Then
            RTB.ZoomFactor = CSng(RTB.ZoomFactor + 0.1)
            FattoreZoom = RTB.ZoomFactor
        End If
    End Sub

    Private Sub ToolStripButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton3.Click
        If RTB.ZoomFactor > 0.2 Then
            RTB.ZoomFactor = CSng(RTB.ZoomFactor - 0.1)
            FattoreZoom = RTB.ZoomFactor
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DGmenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles DGmenu.Opening

    End Sub

    Private Sub ToolStripButton4_Click(sender As Object, e As EventArgs)
        RTB.SelectionBackColor = ColoreSfondo
        RTB.SelectionLength = 0
        RTB.Focus()
    End Sub

 
    Private Sub DataGridView1_CellLeave(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellLeave

    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        Dim r As Integer = e.RowIndex
        Dim c As Integer = e.ColumnIndex
        Try
            ComponiRiga(r)
        Catch ex As Exception

        End Try
    End Sub
End Class
