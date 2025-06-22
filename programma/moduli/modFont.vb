Imports System.Runtime.InteropServices

Module modFont
    Private Const EM_SETCHARFORMAT As Integer = 1092
    Private Const SCF_SELECTION As Integer = 1
    Private Const CFM_FACE As UInteger = &H20000000

    <StructLayout(LayoutKind.Sequential)> _
    Private Structure CHARFORMAT
        Public cbSize As Integer
        Public dwMask As UInteger
        Public dwEffects As UInteger
        Public yHeight As Integer
        Public yOffset As Integer
        Public crTextColor As Integer
        Public bCharSet As Byte
        Public bPitchAndFamily As Byte
        <MarshalAs(UnmanagedType.ByValArray, SizeConst:=32)> _
        Public szFaceName As Char()
        ' CHARFORMAT2 from here onwards.
        Public wWeight As Short
        Public sSpacing As Short
        Public crBackColor As Integer
        Public LCID As Integer
        Public dwReserved As UInteger
        Public sStyle As Short
        Public wKerning As Short
        Public bUnderlineType As Byte
        Public bAnimation As Byte
        Public bRevAuthor As Byte
    End Structure

    <DllImport("user32", CharSet:=CharSet.Auto)> _
    Private Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As Integer, ByRef lp As CHARFORMAT) As Integer
    End Function

    Public Sub SetSelectionFont(rtb As RichTextBox, font As String)
        Dim fmt As New CHARFORMAT()
        fmt.cbSize = Marshal.SizeOf(fmt)
        fmt.dwMask = CFM_FACE
        Dim f As Char() = New Char(31) {}
        For i As Integer = 0 To font.Length - 1
            f(i) = font(i)
        Next
        fmt.szFaceName = f
        SendMessage(rtb.Handle, EM_SETCHARFORMAT, SCF_SELECTION, fmt)
    End Sub

    Public Sub MettiFont(rtb As RichTextBox)
        Dim MioStile As FontStyle
        For k As Integer = 0 To rtb.TextLength - 1
            rtb.SelectionStart = k
            rtb.SelectionLength = 1
            If rtb.SelectionType = 1 Then
                MioStile = rtb.SelectionFont.Style
                rtb.SelectionFont = New Font(FontPredefinito.Name, FontPredefinito.Size, MioStile)
            End If
        Next
    End Sub

    Public Sub ControllaTesto()
        Dim vvv As Integer = 0
        If (Clipboard.ContainsText(TextDataFormat.Text)) Then
            vvv += 0
        End If
        If (Clipboard.ContainsText(TextDataFormat.UnicodeText)) Then
            vvv += 1
        End If
        If (Clipboard.ContainsText(TextDataFormat.Rtf)) Then
            vvv += 2
        End If
        If (Clipboard.ContainsText(TextDataFormat.Html)) Then
            vvv += 4
        End If
        msgbox(vvv)
    End Sub

End Module
