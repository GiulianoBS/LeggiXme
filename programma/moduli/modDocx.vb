' Copyright (C) 2007  Eugene Pankov

Imports System.IO
Imports System.Text
Imports System.Xml
Imports ICSharpCode.SharpZipLib.Zip

Module modDocx
    Private Const ContentTypeNamespace As String = "http://schemas.openxmlformats.org/package/2006/content-types"

    Private Const WordprocessingMlNamespace As String = "http://schemas.openxmlformats.org/wordprocessingml/2006/main"

    Private Const DocumentXmlXPath As String = "/t:Types/t:Override[@ContentType=""application/vnd.openxmlformats-officedocument.wordprocessingml.document.main+xml""]"

    Private Const BodyXPath As String = "/w:document/w:body"

    Private docxFile As String = ""
    Private docxFileLocation As String = ""

    Public Function ExtractText(docFile As String) As String
        docxFile = docFile
        If String.IsNullOrEmpty(docxFile) Then
            Throw New Exception("Input file not specified.")
        End If

        ' Usually it is "/word/document.xml"

        docxFileLocation = FindDocumentXmlLocation()

        If String.IsNullOrEmpty(docxFileLocation) Then
            Throw New Exception("Non è un file Docx valido.")
        End If

        Return ReadDocumentXml()
    End Function

#Region "FindDocumentXmlLocation()"
    ''' <summary>
    ''' Gets location of the "document.xml" zip entry.
    ''' </summary>
    ''' <returns>Location of the "document.xml".</returns>
    Private Function FindDocumentXmlLocation() As String
        Dim zip As New ZipFile(docxFile)
        For Each entry As ZipEntry In zip
            ' Find "[Content_Types].xml" zip entry

            If String.Compare(entry.Name, "[Content_Types].xml", True) = 0 Then
                Dim contentTypes As Stream = zip.GetInputStream(entry)

                Dim xmlDoc As New XmlDocument()
                xmlDoc.PreserveWhitespace = True
                xmlDoc.Load(contentTypes)
                contentTypes.Close()

                'Create an XmlNamespaceManager for resolving namespaces

                Dim nsmgr As New XmlNamespaceManager(xmlDoc.NameTable)
                nsmgr.AddNamespace("t", ContentTypeNamespace)

                ' Find location of "document.xml"

                Dim node As XmlNode = xmlDoc.DocumentElement.SelectSingleNode(DocumentXmlXPath, nsmgr)

                If node IsNot Nothing Then
                    Dim location As String = DirectCast(node, XmlElement).GetAttribute("PartName")
                    Return location.TrimStart(New Char() {"/"c})
                End If
                Exit For
            End If
        Next
        zip.Close()
        Return Nothing
    End Function
#End Region

#Region "ReadDocumentXml()"
    ''' <summary>
    ''' Reads "document.xml" zip entry.
    ''' </summary>
    ''' <returns>Text containing in the document.</returns>
    Private Function ReadDocumentXml() As String
        Dim sb As New StringBuilder()

        Dim zip As New ZipFile(docxFile)
        For Each entry As ZipEntry In zip
            If String.Compare(entry.Name, docxFileLocation, True) = 0 Then
                Dim documentXml As Stream = zip.GetInputStream(entry)

                Dim xmlDoc As New XmlDocument()
                xmlDoc.PreserveWhitespace = True
                xmlDoc.Load(documentXml)
                documentXml.Close()

                Dim nsmgr As New XmlNamespaceManager(xmlDoc.NameTable)
                nsmgr.AddNamespace("w", WordprocessingMlNamespace)

                Dim node As XmlNode = xmlDoc.DocumentElement.SelectSingleNode(BodyXPath, nsmgr)

                If node Is Nothing Then
                    Return String.Empty
                End If

                sb.Append(ReadNode(node))

                Exit For
            End If
        Next
        zip.Close()
        Return sb.ToString()
    End Function
#End Region

#Region "ReadNode()"
    ''' <summary>
    ''' Reads content of the node and its nested childs.
    ''' </summary>
    ''' <param name="node">XmlNode.</param>
    ''' <returns>Text containing in the node.</returns>
    Private Function ReadNode(node As XmlNode) As String
        If node Is Nothing OrElse node.NodeType <> XmlNodeType.Element Then
            Return String.Empty
        End If

        Dim sb As New StringBuilder()
        For Each child As XmlNode In node.ChildNodes
            If child.NodeType <> XmlNodeType.Element Then
                Continue For
            End If

            Select Case child.LocalName
                Case "t"
                    ' Text
                    sb.Append(child.InnerText.TrimEnd())

                    Dim space As String = DirectCast(child, XmlElement).GetAttribute("xml:space")
                    If Not String.IsNullOrEmpty(space) AndAlso space = "preserve" Then
                        sb.Append(" "c)
                    End If

                    Exit Select

                    ' Carriage return
                Case "cr", "br"
                    ' Page break
                    sb.Append(Environment.NewLine)
                    Exit Select

                Case "tab"
                    ' Tab
                    sb.Append(vbTab)
                    Exit Select

                Case "p"
                    ' Paragraph
                    sb.Append(ReadNode(child))
                    sb.Append(Environment.NewLine)
                    sb.Append(Environment.NewLine)
                    Exit Select
                Case Else

                    sb.Append(ReadNode(child))
                    Exit Select
            End Select
        Next
        Return sb.ToString()
    End Function
#End Region

End Module
