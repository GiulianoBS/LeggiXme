
Module modZoom
    Declare Function GetDeviceCaps Lib "gdi32" (ByVal hdc As Integer, ByVal nIndex As Integer) As Integer

    Public Function TrovaZoom() As Integer
        ' calcola il fattore zoom dei caratteri

        Dim r1, r2 As Integer
        Using g As System.Drawing.Graphics = System.Drawing.Graphics.FromHwnd(IntPtr.Zero)
            Dim hdc As IntPtr = g.GetHdc()
            r1 = GetDeviceCaps(hdc, 118)
            r2 = GetDeviceCaps(hdc, 8)
        End Using
        Return CInt(r1 * 100 / r2)
    End Function

End Module
