<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmSinonimi
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
	Public WithEvents lsSignificati As System.Windows.Forms.ListBox
	Public WithEvents cmdEsci As System.Windows.Forms.Button
	Public WithEvents cmdIgnora As System.Windows.Forms.Button
	Public WithEvents cmdCambia As System.Windows.Forms.Button
	Public WithEvents lstSuggerimenti As System.Windows.Forms.ListBox
	Public WithEvents txtDaCercare As System.Windows.Forms.TextBox
	Public WithEvents Label3 As System.Windows.Forms.Label
	Public WithEvents Label2 As System.Windows.Forms.Label
	Public WithEvents Label1 As System.Windows.Forms.Label
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.lstSuggerimenti = New System.Windows.Forms.ListBox
        Me.txtDaCercare = New System.Windows.Forms.TextBox
        Me.lsSignificati = New System.Windows.Forms.ListBox
        Me.cmdEsci = New System.Windows.Forms.Button
        Me.cmdIgnora = New System.Windows.Forms.Button
        Me.cmdCambia = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'lstSuggerimenti
        '
        Me.lstSuggerimenti.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lstSuggerimenti.Cursor = System.Windows.Forms.Cursors.Default
        Me.lstSuggerimenti.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstSuggerimenti.ForeColor = System.Drawing.Color.Black
        Me.lstSuggerimenti.ItemHeight = 18
        Me.lstSuggerimenti.Location = New System.Drawing.Point(8, 165)
        Me.lstSuggerimenti.Name = "lstSuggerimenti"
        Me.lstSuggerimenti.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lstSuggerimenti.Size = New System.Drawing.Size(228, 148)
        Me.lstSuggerimenti.TabIndex = 1
        Me.ToolTip1.SetToolTip(Me.lstSuggerimenti, "Double click to replace with this word")
        '
        'txtDaCercare
        '
        Me.txtDaCercare.AcceptsReturn = True
        Me.txtDaCercare.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDaCercare.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDaCercare.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDaCercare.ForeColor = System.Drawing.Color.Black
        Me.txtDaCercare.Location = New System.Drawing.Point(8, 24)
        Me.txtDaCercare.MaxLength = 0
        Me.txtDaCercare.Name = "txtDaCercare"
        Me.txtDaCercare.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDaCercare.Size = New System.Drawing.Size(228, 24)
        Me.txtDaCercare.TabIndex = 0
        Me.txtDaCercare.TabStop = False
        '
        'lsSignificati
        '
        Me.lsSignificati.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lsSignificati.Cursor = System.Windows.Forms.Cursors.Default
        Me.lsSignificati.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsSignificati.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lsSignificati.ItemHeight = 18
        Me.lsSignificati.Location = New System.Drawing.Point(8, 64)
        Me.lsSignificati.Name = "lsSignificati"
        Me.lsSignificati.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lsSignificati.Size = New System.Drawing.Size(229, 76)
        Me.lsSignificati.TabIndex = 8
        '
        'cmdEsci
        '
        Me.cmdEsci.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEsci.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEsci.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEsci.Location = New System.Drawing.Point(240, 176)
        Me.cmdEsci.Name = "cmdEsci"
        Me.cmdEsci.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEsci.Size = New System.Drawing.Size(69, 28)
        Me.cmdEsci.TabIndex = 7
        Me.cmdEsci.Text = "&Esci"
        Me.cmdEsci.UseVisualStyleBackColor = False
        '
        'cmdIgnora
        '
        Me.cmdIgnora.BackColor = System.Drawing.SystemColors.Control
        Me.cmdIgnora.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdIgnora.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdIgnora.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdIgnora.Location = New System.Drawing.Point(240, 120)
        Me.cmdIgnora.Name = "cmdIgnora"
        Me.cmdIgnora.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdIgnora.Size = New System.Drawing.Size(68, 28)
        Me.cmdIgnora.TabIndex = 6
        Me.cmdIgnora.Text = "&Ignora"
        Me.cmdIgnora.UseVisualStyleBackColor = False
        '
        'cmdCambia
        '
        Me.cmdCambia.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCambia.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCambia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCambia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCambia.Location = New System.Drawing.Point(240, 72)
        Me.cmdCambia.Name = "cmdCambia"
        Me.cmdCambia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCambia.Size = New System.Drawing.Size(68, 28)
        Me.cmdCambia.TabIndex = 5
        Me.cmdCambia.Text = "&Cambia"
        Me.cmdCambia.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label3.Location = New System.Drawing.Point(5, 45)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(181, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Significati:"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label2.Location = New System.Drawing.Point(5, 142)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(166, 16)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Suggerimenti:"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.MenuText
        Me.Label1.Location = New System.Drawing.Point(5, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(181, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Trova sinonimo di"
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Location = New System.Drawing.Point(241, 24)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(68, 28)
        Me.Button1.TabIndex = 9
        Me.Button1.Text = "Cerca"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'frmSinonimi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Menu
        Me.ClientSize = New System.Drawing.Size(316, 329)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.lsSignificati)
        Me.Controls.Add(Me.cmdEsci)
        Me.Controls.Add(Me.cmdIgnora)
        Me.Controls.Add(Me.cmdCambia)
        Me.Controls.Add(Me.lstSuggerimenti)
        Me.Controls.Add(Me.txtDaCercare)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(378, 206)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSinonimi"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Suggerimenti"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents Button1 As System.Windows.Forms.Button
#End Region 
End Class