Module modMenuVoci

    Sub CreaMenuVoci(mnv As ContextMenuStrip)
        If NumVoci > 0 Then
            For k As Integer = 0 To NumVoci
                AggiungiVoceMenu(mnv, Lingua(k), NomeCorto(k))
            Next
            Dim item As New ToolStripMenuItem
            item.Image = My.Resources.annulla
            item.Text = "ANNULLA"
            mnv.Items.Add(item)
        Else
            mnv.Items.Add("Nessuna Voce")
        End If
        NomeVocePrincipale = NomeVoce(intParlante)
    End Sub

    Public Sub AggiungiVoceMenu(ByVal mv As ContextMenuStrip, ByVal Lingua As String, ByVal Voce As String)
        Dim item As New ToolStripMenuItem
        item.Text = Voce
        Select Case Lingua
            Case Italiano : item.Image = My.Resources.BandIta
            Case Inglese : item.Image = My.Resources.bandUk
            Case IngleseUS : item.Image = My.Resources.BandUSA
            Case Francese : item.Image = My.Resources.bandFra
            Case Spagnolo : item.Image = My.Resources.bandSpa
            Case Tedesco : item.Image = My.Resources.BanGer
        End Select
        mv.Items.Add(item)
    End Sub

    Public lalingua As String = ""

    Public Function ScegliLingua(numLingua As Integer) As String

        lalingua = ""
        Select Case Lingua(numLingua)
            Case Italiano
                If dizionario <> "it_IT" Then
                    dizionario = "it_IT"
                    DizSinonimi = "th_it_IT.txt"
                    'frmLeggiConMe.lblLingua.Text = "ITALIANO"
                    DizionarioUtente = "utente_it.diz"
                    lalingua = "ITALIANO"
                End If
            Case Inglese
                If dizionario <> "en_GB" Then
                    dizionario = "en_GB"
                    DizSinonimi = "th_en_GB_final.txt"
                    'frmLeggiConMe.lblLingua.Text = "INGLESE"
                    DizionarioUtente = "utente_en.diz"
                    lalingua = "INGLESE"
                End If
            Case IngleseUS
                If dizionario <> "en_GB" Then
                    dizionario = "en_GB"
                    DizSinonimi = "th_en_GB_final.txt"
                    'frmLeggiConMe.lblLingua.Text = "INGLESE"
                    DizionarioUtente = "utente_en.diz"
                    lalingua = "INGL. USA"
                End If
            Case Francese
                If dizionario <> "fr-classique+reforme1990" Then '"fr-toutesvariantes" Then '
                    dizionario = "fr-classique+reforme1990" '"fr-toutesvariantes"  '
                    DizSinonimi = "thes_fr.txt"
                    DizionarioUtente = "utente_fr.diz"
                    'frmLeggiConMe.lblLingua.Text = "FRANCESE"
                    lalingua = "FRANCESE"
                End If
            Case Tedesco
                If dizionario <> "de_DE_frami" Then
                    dizionario = "de_DE_frami"
                    DizSinonimi = "th_de_DE_v2.txt"
                    'frmLeggiConMe.lblLingua.Text = "TEDESCO"
                    DizionarioUtente = "utente_de.diz"
                    lalingua = "TEDESCO"
                End If
            Case Spagnolo
                If dizionario <> "es_ES" Then
                    dizionario = "es_ES"
                    DizSinonimi = "th_es_ES_v2.txt"
                    'frmLeggiConMe.lblLingua.Text = "SPAGNOLO"
                    DizionarioUtente = "utente_es.diz"
                    lalingua = "SPAGNOLO"
                End If
            Case Else
                Select Case Mid(Lingua(numLingua), 1, 2)
                    Case "en"
                        If dizionario <> "en_GB" Then
                            dizionario = "en_GB"
                            DizSinonimi = "th_en_GB_final.txt"
                            DizionarioUtente = "utente_en.diz"
                            lalingua = "INGLESE"
                        End If
                    Case "fr"
                        If dizionario <> "fr-classique+reforme1990" Then '"fr-toutesvariantes" Then '
                            dizionario = "fr-classique+reforme1990" '"fr-toutesvariantes"  '
                            DizSinonimi = "thes_fr.txt"
                            DizionarioUtente = "utente_fr.diz"
                            'frmLeggiConMe.lblLingua.Text = "FRANCESE"
                            lalingua = "FRANCESE"
                        End If
                    Case "de"
                        If dizionario <> "de_DE_frami" Then
                            dizionario = "de_DE_frami"
                            DizSinonimi = "th_de_DE_v2.txt"
                            'frmLeggiConMe.lblLingua.Text = "TEDESCO"
                            DizionarioUtente = "utente_de.diz"
                            lalingua = "TEDESCO"
                        End If
                    Case "es"
                        If dizionario <> "es_ES" Then
                            dizionario = "es_ES"
                            DizSinonimi = "th_es_ES_v2.txt"
                            'frmLeggiConMe.lblLingua.Text = "SPAGNOLO"
                            DizionarioUtente = "utente_es.diz"
                            lalingua = "SPAGNOLO"
                        End If
                    Case Else
                        MsgBox("Purtroppo le uniche lingue supportate con dizionario sono:" & vbCrLf & "ITALIANO INGLESE FRANCESE TEDESCO SPAGNOLO", MsgBoxStyle.MsgBoxSetForeground)
                        Return ""
                        Exit Function
                End Select
        End Select
        'frmLeggiConMe.lblLingua2.Text = frmLeggiConMe.lblLingua.Text
        If dizionario <> "" Then dizionario = PercorsoOrtografici & "\" & dizionario

        CaricaDizionarioUtente()
        ' MsgBox(LaLingua)
        Return lalingua
    End Function

    Public Function ScegliBandiera(ByVal numVoce As Integer) As Image
        Dim immagine As Image = Nothing
        Select Case Lingua(numVoce)
            Case Italiano : immagine = My.Resources.BanIta
            Case Inglese : immagine = My.Resources.BanUk
            Case IngleseUS : immagine = My.Resources.BanUSA
            Case Francese : immagine = My.Resources.banFra
            Case Spagnolo : immagine = My.Resources.banSpa
            Case Tedesco : immagine = My.Resources.BanGer
            Case Else : immagine = My.Resources.PunDom
        End Select
        Return immagine
    End Function

    Public Function Sceltavoce(ByVal item As String, MenuVoci As System.Windows.Forms.ContextMenuStrip, cmdVoce As Button) As Integer
        Dim indice As Integer = -1
        For i As Integer = 0 To MenuVoci.Items.Count - 1
            If MenuVoci.Items(i).ToString.Contains(item) Then
                indice = i
            End If
        Next

        Try
            Parlante = item
            ScegliLingua(indice)
        Catch
            Parlante = VocePrincipale
        End Try

        Return indice
    End Function

    Public Function AssegnaVoce(numVoce As Integer) As String
        Dim risposta As String = ""

        Try
            Select Case Lingua(numVoce)
                Case Italiano : risposta = "ITALIANO"
                Case Inglese : risposta = "INGLESE"
                Case IngleseUS : risposta = "INGLESE"
                Case Francese : risposta = "FRANCESE"
                Case Spagnolo : risposta = "SPAGNOLO"
                Case Tedesco : risposta = "TEDESCO"
                Case Else
                    If lalingua <> "" Then
                        risposta = lalingua
                    End If
            End Select
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        Return risposta
    End Function
End Module
