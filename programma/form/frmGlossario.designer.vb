<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmGlossario
#Region "Windows Form Designer generated code "
    <System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
        MyBase.New()
        'This call is required by the Windows Form Designer.
        InitializeComponent()
    End Sub
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
        If Disposing Then
            If Not components Is Nothing Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(Disposing)
    End Sub
    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents cmdEsci As System.Windows.Forms.Button
    Public WithEvents cmdCambia As System.Windows.Forms.Button
    Public WithEvents lstContiene As System.Windows.Forms.ListBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lstContiene = New System.Windows.Forms.ListBox
        Me.cmdEsci = New System.Windows.Forms.Button
        Me.cmdCambia = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtDaCercare = New System.Windows.Forms.TextBox
        Me.rbInizia = New System.Windows.Forms.RadioButton
        Me.rbContiene = New System.Windows.Forms.RadioButton
        Me.txtGlossario = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.lstParole = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'lstContiene
        '
        Me.lstContiene.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lstContiene.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstContiene.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstContiene.ForeColor = System.Drawing.Color.Black
        Me.lstContiene.ItemHeight = 18
        Me.lstContiene.Location = New System.Drawing.Point(8, 145)
        Me.lstContiene.Name = "lstContiene"
        Me.lstContiene.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstContiene.Size = New System.Drawing.Size(228, 94)
        Me.lstContiene.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.lstContiene, "Double click to replace with this word")
        '
        'cmdEsci
        '
        Me.cmdEsci.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEsci.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEsci.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEsci.Location = New System.Drawing.Point(242, 189)
        Me.cmdEsci.Name = "cmdEsci"
        Me.cmdEsci.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEsci.Size = New System.Drawing.Size(69, 28)
        Me.cmdEsci.TabIndex = 7
        Me.cmdEsci.Text = "&Esci"
        Me.cmdEsci.UseVisualStyleBackColor = False
        '
        'cmdCambia
        '
        Me.cmdCambia.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCambia.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCambia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCambia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCambia.Location = New System.Drawing.Point(243, 155)
        Me.cmdCambia.Name = "cmdCambia"
        Me.cmdCambia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCambia.Size = New System.Drawing.Size(68, 28)
        Me.cmdCambia.TabIndex = 5
        Me.cmdCambia.Text = "&Cambia"
        Me.cmdCambia.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label2.Location = New System.Drawing.Point(5, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(166, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Suggerimenti"
        '
        'txtDaCercare
        '
        Me.txtDaCercare.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDaCercare.Location = New System.Drawing.Point(12, 84)
        Me.txtDaCercare.Name = "txtDaCercare"
        Me.txtDaCercare.Size = New System.Drawing.Size(159, 24)
        Me.txtDaCercare.TabIndex = 9
        '
        'rbInizia
        '
        Me.rbInizia.AutoSize = True
        Me.rbInizia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbInizia.Location = New System.Drawing.Point(187, 74)
        Me.rbInizia.Name = "rbInizia"
        Me.rbInizia.Size = New System.Drawing.Size(88, 22)
        Me.rbInizia.TabIndex = 10
        Me.rbInizia.TabStop = True
        Me.rbInizia.Text = "Inizia con"
        Me.rbInizia.UseVisualStyleBackColor = True
        '
        'rbContiene
        '
        Me.rbContiene.AutoSize = True
        Me.rbContiene.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbContiene.Location = New System.Drawing.Point(187, 97)
        Me.rbContiene.Name = "rbContiene"
        Me.rbContiene.Size = New System.Drawing.Size(85, 22)
        Me.rbContiene.TabIndex = 11
        Me.rbContiene.TabStop = True
        Me.rbContiene.Text = "Contiene"
        Me.rbContiene.UseVisualStyleBackColor = True
        '
        'txtGlossario
        '
        Me.txtGlossario.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGlossario.Location = New System.Drawing.Point(12, 31)
        Me.txtGlossario.Name = "txtGlossario"
        Me.txtGlossario.Size = New System.Drawing.Size(222, 24)
        Me.txtGlossario.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(166, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Glossario selezionato"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(240, 18)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(68, 51)
        Me.Button1.TabIndex = 14
        Me.Button1.Text = "Cambia Gloss."
        Me.Button1.UseVisualStyleBackColor = False
        '
        'lstParole
        '
        Me.lstParole.FormattingEnabled = True
        Me.lstParole.Location = New System.Drawing.Point(8, 245)
        Me.lstParole.Name = "lstParole"
        Me.lstParole.Size = New System.Drawing.Size(279, 56)
        Me.lstParole.Sorted = True
        Me.lstParole.TabIndex = 15
        Me.lstParole.Visible = False
        '
        'frmGlossario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(316, 254)
        Me.ControlBox = False
        Me.Controls.Add(Me.lstParole)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtGlossario)
        Me.Controls.Add(Me.rbContiene)
        Me.Controls.Add(Me.rbInizia)
        Me.Controls.Add(Me.txtDaCercare)
        Me.Controls.Add(Me.cmdEsci)
        Me.Controls.Add(Me.cmdCambia)
        Me.Controls.Add(Me.lstContiene)
        Me.Controls.Add(Me.Label2)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(378, 206)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmGlossario"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Suggerimenti"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDaCercare As System.Windows.Forms.TextBox
    Friend WithEvents rbInizia As System.Windows.Forms.RadioButton
    Friend WithEvents rbContiene As System.Windows.Forms.RadioButton
    Friend WithEvents txtGlossario As System.Windows.Forms.TextBox
    Public WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents lstParole As System.Windows.Forms.ListBox
#End Region
End Class