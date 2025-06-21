Imports System
Imports System.Collections.Generic
Imports System.IO
Imports System.Linq
Imports System.Net
Imports System.Web
Imports System.Text

Namespace GoogleTranslator
    Public Class Translator
        Public Shared ReadOnly Property Languages As IEnumerable(Of String)
            Get
                Translator.EnsureInitialized()
                Return Translator._languageModeMap.Keys.OrderBy(Function(p) p)
            End Get
        End Property

        Public TranslationTime As TimeSpan
        Public TranslationSpeechUrl As String
        Public [Error] As Exception

        Public Function Translate(ByVal origine As String, ByVal sourceLanguage As String, ByVal targetLanguage As String) As String
            Dim testo As String = ""
            Dim i As Integer = 1, ii As Integer = 0
             'origine = Codifica(origine)
            Do
                i = InStr(origine, ".")
                ii = InStr(origine, "!") : If ii > 0 And ii < i Then i = ii
                ii = InStr(origine, "?") : If ii > 0 And ii < i Then i = ii
                ii = InStr(origine, ";") : If ii > 0 And ii < i Then i = ii
                If i > 0 Then
                    testo &= Trad(Mid(origine, 1, i), sourceLanguage, targetLanguage) & " "
                    origine = Mid(origine, i + 1)
                End If
            Loop Until i = 0
            If origine <> "" Then
                testo &= Trad(origine, sourceLanguage, targetLanguage)
            End If

            Return testo
        End Function

        Public Function Trad(ByVal sourceText As String, ByVal sourceLanguage As String, ByVal targetLanguage As String) As String
            Me.[Error] = Nothing
            Me.TranslationSpeechUrl = Nothing
            Me.TranslationTime = TimeSpan.Zero
            Dim tmStart As DateTime = DateTime.Now
            Dim translation As String = String.Empty
            Try
                Dim url As String = String.Format("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}", Translator.LanguageEnumToIdentifier(sourceLanguage), Translator.LanguageEnumToIdentifier(targetLanguage), Codifica(sourceText))
                Dim outputFile As String = Path.GetTempFileName()

                Using wc As WebClient = New WebClient()
                    wc.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36")
                    wc.DownloadFile(url, outputFile)
                End Using
                If File.Exists(outputFile) Then
                    Dim text As String = File.ReadAllText(outputFile)
                    text = text.Replace("\" & Chr(34), Chr(162))

                    Dim index As Integer = text.IndexOf(String.Format(",,""{0}""", Translator.LanguageEnumToIdentifier(sourceLanguage)))

                    If index = -1 Then
                        Dim startQuote As Integer = text.IndexOf(""""c)

                        If startQuote <> -1 Then
                            Dim endQuote As Integer = text.IndexOf(""""c, startQuote + 1)

                            If endQuote <> -1 Then
                                translation = text.Substring(startQuote + 1, endQuote - startQuote - 1)
                            End If
                        End If
                    Else
                        text = text.Substring(0, index)
                        text = text.Replace("],[", ",")
                        text = text.Replace("]", String.Empty)
                        text = text.Replace("[", String.Empty)
                        text = text.Replace(""",""", """")
                        Dim phrases As String() = text.Split({""""c}, StringSplitOptions.RemoveEmptyEntries)
                        Dim i As Integer = 0

                        While (i < phrases.Count())
                            Dim translatedPhrase As String = phrases(i)

                            If translatedPhrase.StartsWith(",,") Then
                                i -= 1
                                Continue While
                            End If

                            translation += translatedPhrase & "  "
                            i += 2
                        End While
                    End If

                    translation = translation.Trim()
                    translation = translation.Replace(" ?", "?")
                    translation = translation.Replace(" !", "!")
                    translation = translation.Replace(" ,", ",")
                    translation = translation.Replace(" .", ".")
                    translation = translation.Replace(" ;", ";")
                    translation = translation.Replace(Chr(162), Chr(34))
                    Me.TranslationSpeechUrl = String.Format("https://translate.googleapis.com/translate_tts?ie=UTF-8&q={0}&tl={1}&total=1&idx=0&textlen={2}&client=gtx", translation, Codifica(translation), Translator.LanguageEnumToIdentifier(targetLanguage), translation.Length)
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

            Me.TranslationTime = DateTime.Now - tmStart
            Return translation
        End Function

        Private Shared Function LanguageEnumToIdentifier(ByVal language As String) As String
            Dim mode As String = String.Empty
            Translator.EnsureInitialized()
            Translator._languageModeMap.TryGetValue(language, mode)
            Return mode
        End Function

        Private Shared Sub EnsureInitialized()
            If Translator._languageModeMap Is Nothing Then
                Translator._languageModeMap = New Dictionary(Of String, String)()
                Translator._languageModeMap.Add("Automatico", "auto")
                Translator._languageModeMap.Add("Afrikaans", "af")
                Translator._languageModeMap.Add("Albanian", "sq")
                Translator._languageModeMap.Add("Arabic", "ar")
                Translator._languageModeMap.Add("Armenian", "hy")
                Translator._languageModeMap.Add("Azerbaijani", "az")
                Translator._languageModeMap.Add("Basque", "eu")
                Translator._languageModeMap.Add("Belarusian", "be")
                Translator._languageModeMap.Add("Bengali", "bn")
                Translator._languageModeMap.Add("Bulgarian", "bg")
                Translator._languageModeMap.Add("Catalan", "ca")
                Translator._languageModeMap.Add("Chinese", "zh-CN")
                Translator._languageModeMap.Add("Croatian", "hr")
                Translator._languageModeMap.Add("Czech", "cs")
                Translator._languageModeMap.Add("Danish", "da")
                Translator._languageModeMap.Add("Dutch", "nl")
                Translator._languageModeMap.Add("English", "en")
                Translator._languageModeMap.Add("Esperanto", "eo")
                Translator._languageModeMap.Add("Estonian", "et")
                Translator._languageModeMap.Add("Filipino", "tl")
                Translator._languageModeMap.Add("Finnish", "fi")
                Translator._languageModeMap.Add("French", "fr")
                Translator._languageModeMap.Add("Galician", "gl")
                Translator._languageModeMap.Add("German", "de")
                Translator._languageModeMap.Add("Georgian", "ka")
                Translator._languageModeMap.Add("Greek", "el")
                Translator._languageModeMap.Add("Haitian Creole", "ht")
                Translator._languageModeMap.Add("Hebrew", "iw")
                Translator._languageModeMap.Add("Hindi", "hi")
                Translator._languageModeMap.Add("Hungarian", "hu")
                Translator._languageModeMap.Add("Icelandic", "is")
                Translator._languageModeMap.Add("Indonesian", "id")
                Translator._languageModeMap.Add("Irish", "ga")
                Translator._languageModeMap.Add("Italian", "it")
                Translator._languageModeMap.Add("Japanese", "ja")
                Translator._languageModeMap.Add("Korean", "ko")
                Translator._languageModeMap.Add("Lao", "lo")
                Translator._languageModeMap.Add("Latin", "la")
                Translator._languageModeMap.Add("Latvian", "lv")
                Translator._languageModeMap.Add("Lithuanian", "lt")
                Translator._languageModeMap.Add("Macedonian", "mk")
                Translator._languageModeMap.Add("Malay", "ms")
                Translator._languageModeMap.Add("Maltese", "mt")
                Translator._languageModeMap.Add("Norwegian", "no")
                Translator._languageModeMap.Add("Persian", "fa")
                Translator._languageModeMap.Add("Polish", "pl")
                Translator._languageModeMap.Add("Portuguese", "pt")
                Translator._languageModeMap.Add("Romanian", "ro")
                Translator._languageModeMap.Add("Russian", "ru")
                Translator._languageModeMap.Add("Serbian", "sr")
                Translator._languageModeMap.Add("Slovak", "sk")
                Translator._languageModeMap.Add("Slovenian", "sl")
                Translator._languageModeMap.Add("Spanish", "es")
                Translator._languageModeMap.Add("Swahili", "sw")
                Translator._languageModeMap.Add("Swedish", "sv")
                Translator._languageModeMap.Add("Tamil", "ta")
                Translator._languageModeMap.Add("Telugu", "te")
                Translator._languageModeMap.Add("Thai", "th")
                Translator._languageModeMap.Add("Turkish", "tr")
                Translator._languageModeMap.Add("Ukrainian", "uk")
                Translator._languageModeMap.Add("Urdu", "ur")
                Translator._languageModeMap.Add("Vietnamese", "vi")
                Translator._languageModeMap.Add("Welsh", "cy")
                Translator._languageModeMap.Add("Yiddish", "yi")
            End If
        End Sub

        Private Shared _languageModeMap As Dictionary(Of String, String)

        Private Function Codifica(s As String) As String
            s = s.Replace(Chr(10), "")
            s = s.Replace(Chr(13), "")
            's = s.Replace(Chr(34), " ")
            s = s.Replace(" ", "%20")
            s = s.Replace(Chr(161), "%" & Hex(161))
            For k As Integer = 191 To 252
                s = s.Replace(Chr(k), "%" & Hex(k))
            Next
 
            Return s

        End Function

    End Class
End Namespace
