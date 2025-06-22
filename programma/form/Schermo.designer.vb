<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Schermo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Sel = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'Sel
        '
        Me.Sel.BackColor = System.Drawing.Color.Black
        Me.Sel.Location = New System.Drawing.Point(2, 0)
        Me.Sel.Name = "Sel"
        Me.Sel.Size = New System.Drawing.Size(9, 9)
        Me.Sel.TabIndex = 0
        '
        'Schermo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(284, 262)
        Me.ControlBox = False
        Me.Controls.Add(Me.Sel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Schermo"
        Me.Opacity = 0.1
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Sel As System.Windows.Forms.Label
End Class
