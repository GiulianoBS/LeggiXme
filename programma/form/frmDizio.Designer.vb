<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmDizio
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
    Public WithEvents txtDaCercare As System.Windows.Forms.TextBox
    Public WithEvents Label3 As System.Windows.Forms.Label
    Public WithEvents Label1 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDizio))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.txtDaCercare = New System.Windows.Forms.TextBox
        Me.txtTraduzione = New System.Windows.Forms.TextBox
        Me.RadioButton3 = New System.Windows.Forms.RadioButton
        Me.cmdEsci = New System.Windows.Forms.Button
        Me.cmdCambia = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton4 = New System.Windows.Forms.RadioButton
        Me.RadioButton5 = New System.Windows.Forms.RadioButton
        Me.RadioButton6 = New System.Windows.Forms.RadioButton
        Me.RadioButton7 = New System.Windows.Forms.RadioButton
        Me.RadioButton8 = New System.Windows.Forms.RadioButton
        Me.SuspendLayout()
        '
        'txtDaCercare
        '
        Me.txtDaCercare.AcceptsReturn = True
        Me.txtDaCercare.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtDaCercare.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtDaCercare.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDaCercare.ForeColor = System.Drawing.Color.Black
        Me.txtDaCercare.Location = New System.Drawing.Point(8, 30)
        Me.txtDaCercare.MaxLength = 0
        Me.txtDaCercare.Name = "txtDaCercare"
        Me.txtDaCercare.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtDaCercare.Size = New System.Drawing.Size(228, 26)
        Me.txtDaCercare.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.txtDaCercare, "parola da tradurre")
        '
        'txtTraduzione
        '
        Me.txtTraduzione.AcceptsReturn = True
        Me.txtTraduzione.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.txtTraduzione.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtTraduzione.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTraduzione.ForeColor = System.Drawing.Color.Black
        Me.txtTraduzione.Location = New System.Drawing.Point(8, 91)
        Me.txtTraduzione.MaxLength = 0
        Me.txtTraduzione.Name = "txtTraduzione"
        Me.txtTraduzione.ReadOnly = True
        Me.txtTraduzione.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtTraduzione.Size = New System.Drawing.Size(228, 26)
        Me.txtTraduzione.TabIndex = 8
        Me.txtTraduzione.TabStop = False
        Me.ToolTip1.SetToolTip(Me.txtTraduzione, "Word not found in dictionary")
        '
        'RadioButton3
        '
        Me.RadioButton3.BackColor = System.Drawing.Color.Beige
        Me.RadioButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton3.ForeColor = System.Drawing.Color.Black
        Me.RadioButton3.Location = New System.Drawing.Point(12, 260)
        Me.RadioButton3.Name = "RadioButton3"
        Me.RadioButton3.Size = New System.Drawing.Size(94, 25)
        Me.RadioButton3.TabIndex = 11
        Me.RadioButton3.TabStop = True
        Me.RadioButton3.Tag = "3"
        Me.RadioButton3.Text = "ITA -> TED"
        Me.RadioButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.RadioButton3.UseVisualStyleBackColor = False
        '
        'cmdEsci
        '
        Me.cmdEsci.BackColor = System.Drawing.SystemColors.Control
        Me.cmdEsci.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEsci.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdEsci.Image = CType(resources.GetObject("cmdEsci.Image"), System.Drawing.Image)
        Me.cmdEsci.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdEsci.Location = New System.Drawing.Point(143, 137)
        Me.cmdEsci.Name = "cmdEsci"
        Me.cmdEsci.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdEsci.Size = New System.Drawing.Size(92, 45)
        Me.cmdEsci.TabIndex = 7
        Me.cmdEsci.Text = "Esci"
        Me.cmdEsci.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdEsci.UseVisualStyleBackColor = False
        '
        'cmdCambia
        '
        Me.cmdCambia.BackColor = System.Drawing.SystemColors.Control
        Me.cmdCambia.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdCambia.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCambia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdCambia.Image = Global.LeggiXme.My.Resources.Resources.Copia2
        Me.cmdCambia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCambia.Location = New System.Drawing.Point(8, 137)
        Me.cmdCambia.Name = "cmdCambia"
        Me.cmdCambia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdCambia.Size = New System.Drawing.Size(95, 45)
        Me.cmdCambia.TabIndex = 5
        Me.cmdCambia.Text = "COPIA"
        Me.cmdCambia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCambia.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(5, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label3.Size = New System.Drawing.Size(181, 16)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "TRADUZIONE"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(5, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label1.Size = New System.Drawing.Size(181, 16)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "DA TRADURRE"
        '
        'RadioButton1
        '
        Me.RadioButton1.BackColor = System.Drawing.Color.Beige
        Me.RadioButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton1.ForeColor = System.Drawing.Color.Black
        Me.RadioButton1.Location = New System.Drawing.Point(12, 196)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(94, 25)
        Me.RadioButton1.TabIndex = 9
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Tag = "1"
        Me.RadioButton1.Text = "ITA -> ING"
        Me.RadioButton1.UseVisualStyleBackColor = False
        '
        'RadioButton2
        '
        Me.RadioButton2.BackColor = System.Drawing.Color.Beige
        Me.RadioButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton2.ForeColor = System.Drawing.Color.Black
        Me.RadioButton2.Location = New System.Drawing.Point(12, 228)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(94, 25)
        Me.RadioButton2.TabIndex = 10
        Me.RadioButton2.TabStop = True
        Me.RadioButton2.Tag = "2"
        Me.RadioButton2.Text = "ITA -> FRA"
        Me.RadioButton2.UseVisualStyleBackColor = False
        '
        'RadioButton4
        '
        Me.RadioButton4.BackColor = System.Drawing.Color.Beige
        Me.RadioButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton4.ForeColor = System.Drawing.Color.Black
        Me.RadioButton4.Location = New System.Drawing.Point(12, 292)
        Me.RadioButton4.Name = "RadioButton4"
        Me.RadioButton4.Size = New System.Drawing.Size(94, 25)
        Me.RadioButton4.TabIndex = 12
        Me.RadioButton4.TabStop = True
        Me.RadioButton4.Tag = "4"
        Me.RadioButton4.Text = "ITA -> SPA"
        Me.RadioButton4.UseVisualStyleBackColor = False
        '
        'RadioButton5
        '
        Me.RadioButton5.BackColor = System.Drawing.Color.Beige
        Me.RadioButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton5.ForeColor = System.Drawing.Color.Black
        Me.RadioButton5.Location = New System.Drawing.Point(139, 196)
        Me.RadioButton5.Name = "RadioButton5"
        Me.RadioButton5.Size = New System.Drawing.Size(94, 25)
        Me.RadioButton5.TabIndex = 13
        Me.RadioButton5.TabStop = True
        Me.RadioButton5.Tag = "5"
        Me.RadioButton5.Text = "ING -> ITA"
        Me.RadioButton5.UseVisualStyleBackColor = False
        '
        'RadioButton6
        '
        Me.RadioButton6.BackColor = System.Drawing.Color.Beige
        Me.RadioButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton6.ForeColor = System.Drawing.Color.Black
        Me.RadioButton6.Location = New System.Drawing.Point(139, 228)
        Me.RadioButton6.Name = "RadioButton6"
        Me.RadioButton6.Size = New System.Drawing.Size(94, 25)
        Me.RadioButton6.TabIndex = 14
        Me.RadioButton6.TabStop = True
        Me.RadioButton6.Tag = "6"
        Me.RadioButton6.Text = "FRA -> ITA"
        Me.RadioButton6.UseVisualStyleBackColor = False
        '
        'RadioButton7
        '
        Me.RadioButton7.BackColor = System.Drawing.Color.Beige
        Me.RadioButton7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton7.ForeColor = System.Drawing.Color.Black
        Me.RadioButton7.Location = New System.Drawing.Point(139, 260)
        Me.RadioButton7.Name = "RadioButton7"
        Me.RadioButton7.Size = New System.Drawing.Size(94, 25)
        Me.RadioButton7.TabIndex = 15
        Me.RadioButton7.TabStop = True
        Me.RadioButton7.Tag = "7"
        Me.RadioButton7.Text = "TED -> ITA"
        Me.RadioButton7.UseVisualStyleBackColor = False
        '
        'RadioButton8
        '
        Me.RadioButton8.BackColor = System.Drawing.Color.Beige
        Me.RadioButton8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RadioButton8.ForeColor = System.Drawing.Color.Black
        Me.RadioButton8.Location = New System.Drawing.Point(139, 292)
        Me.RadioButton8.Name = "RadioButton8"
        Me.RadioButton8.Size = New System.Drawing.Size(94, 25)
        Me.RadioButton8.TabIndex = 16
        Me.RadioButton8.TabStop = True
        Me.RadioButton8.Tag = "8"
        Me.RadioButton8.Text = "SPA -> ITA"
        Me.RadioButton8.UseVisualStyleBackColor = False
        '
        'frmDizio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(247, 329)
        Me.Controls.Add(Me.RadioButton8)
        Me.Controls.Add(Me.RadioButton7)
        Me.Controls.Add(Me.RadioButton6)
        Me.Controls.Add(Me.RadioButton5)
        Me.Controls.Add(Me.RadioButton4)
        Me.Controls.Add(Me.RadioButton3)
        Me.Controls.Add(Me.RadioButton2)
        Me.Controls.Add(Me.RadioButton1)
        Me.Controls.Add(Me.txtTraduzione)
        Me.Controls.Add(Me.cmdEsci)
        Me.Controls.Add(Me.cmdCambia)
        Me.Controls.Add(Me.txtDaCercare)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Location = New System.Drawing.Point(378, 206)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDizio"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "DIZIONARIO"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents txtTraduzione As System.Windows.Forms.TextBox
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton3 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton4 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton5 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton6 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton7 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton8 As System.Windows.Forms.RadioButton
#End Region
End Class