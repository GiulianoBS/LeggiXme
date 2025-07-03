Module modNumeri

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
        ' funzione non più utilizzata

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

End Module
