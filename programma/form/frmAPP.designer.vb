<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAPP
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAPP))
        Me.pnPDF = New System.Windows.Forms.Panel()
        Me.TB1 = New System.Windows.Forms.RichTextBox()
        Me.AutoVerbMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Annulla = New System.Windows.Forms.ToolStripMenuItem()
        Me.Ripristina = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Taglia = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Copia = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Incolla_Testo = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.pnComandi = New System.Windows.Forms.Panel()
        Me.lbLingua = New System.Windows.Forms.Label()
        Me.cmdVoce = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.trVelocita = New System.Windows.Forms.TrackBar()
        Me.btnTRAD = New System.Windows.Forms.Button()
        Me.picComandi = New System.Windows.Forms.Panel()
        Me.cmdPausa = New System.Windows.Forms.Button()
        Me.cmdRipeti = New System.Windows.Forms.Button()
        Me.cmdLeggi = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.lstAppunti = New System.Windows.Forms.ListBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.lblVoce1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnTorna = New System.Windows.Forms.Button()
        Me.btnIncolla = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuVoci = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnPDF.SuspendLayout()
        Me.AutoVerbMenu.SuspendLayout()
        Me.pnComandi.SuspendLayout()
        CType(Me.trVelocita, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.picComandi.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnPDF
        '
        Me.pnPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnPDF.Controls.Add(Me.TB1)
        Me.pnPDF.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnPDF.Location = New System.Drawing.Point(0, 0)
        Me.pnPDF.Name = "pnPDF"
        Me.pnPDF.Size = New System.Drawing.Size(488, 522)
        Me.pnPDF.TabIndex = 0
        '
        'TB1
        '
        Me.TB1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB1.AutoWordSelection = True
        Me.TB1.ContextMenuStrip = Me.AutoVerbMenu
        Me.TB1.Font = New System.Drawing.Font("Tahoma", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TB1.HideSelection = False
        Me.TB1.Location = New System.Drawing.Point(2, 2)
        Me.TB1.Name = "TB1"
        Me.TB1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.TB1.Size = New System.Drawing.Size(484, 513)
        Me.TB1.TabIndex = 0
        Me.TB1.Text = ""
        '
        'AutoVerbMenu
        '
        Me.AutoVerbMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Annulla, Me.Ripristina, Me.ToolStripSeparator1, Me.Taglia, Me.ToolStripSeparator2, Me.Copia, Me.ToolStripSeparator3, Me.Incolla_Testo, Me.ToolStripSeparator4})
        Me.AutoVerbMenu.Name = "AutoVerbMenu"
        Me.AutoVerbMenu.ShowImageMargin = False
        Me.AutoVerbMenu.Size = New System.Drawing.Size(163, 138)
        '
        'Annulla
        '
        Me.Annulla.Name = "Annulla"
        Me.Annulla.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.Annulla.Size = New System.Drawing.Size(162, 22)
        Me.Annulla.Text = "Annulla"
        '
        'Ripristina
        '
        Me.Ripristina.Name = "Ripristina"
        Me.Ripristina.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.Ripristina.Size = New System.Drawing.Size(162, 22)
        Me.Ripristina.Text = "Ripristina"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(159, 6)
        '
        'Taglia
        '
        Me.Taglia.Name = "Taglia"
        Me.Taglia.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.Taglia.Size = New System.Drawing.Size(162, 22)
        Me.Taglia.Text = "Taglia"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(159, 6)
        '
        'Copia
        '
        Me.Copia.Name = "Copia"
        Me.Copia.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.Copia.Size = New System.Drawing.Size(162, 22)
        Me.Copia.Text = "Copia"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(159, 6)
        '
        'Incolla_Testo
        '
        Me.Incolla_Testo.Name = "Incolla_Testo"
        Me.Incolla_Testo.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.T), System.Windows.Forms.Keys)
        Me.Incolla_Testo.Size = New System.Drawing.Size(162, 22)
        Me.Incolla_Testo.Text = "Incolla Testo"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(159, 6)
        '
        'pnComandi
        '
        Me.pnComandi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnComandi.BackColor = System.Drawing.Color.PaleTurquoise
        Me.pnComandi.Controls.Add(Me.lbLingua)
        Me.pnComandi.Controls.Add(Me.cmdVoce)
        Me.pnComandi.Controls.Add(Me.Button1)
        Me.pnComandi.Controls.Add(Me.Label5)
        Me.pnComandi.Controls.Add(Me.trVelocita)
        Me.pnComandi.Controls.Add(Me.btnTRAD)
        Me.pnComandi.Controls.Add(Me.picComandi)
        Me.pnComandi.Controls.Add(Me.lstAppunti)
        Me.pnComandi.Controls.Add(Me.PictureBox1)
        Me.pnComandi.Controls.Add(Me.lblVoce1)
        Me.pnComandi.Controls.Add(Me.Label3)
        Me.pnComandi.Controls.Add(Me.btnTorna)
        Me.pnComandi.Controls.Add(Me.btnIncolla)
        Me.pnComandi.Controls.Add(Me.Label1)
        Me.pnComandi.Location = New System.Drawing.Point(492, 0)
        Me.pnComandi.Name = "pnComandi"
        Me.pnComandi.Size = New System.Drawing.Size(292, 522)
        Me.pnComandi.TabIndex = 1
        '
        'lbLingua
        '
        Me.lbLingua.AutoSize = True
        Me.lbLingua.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLingua.Location = New System.Drawing.Point(134, 195)
        Me.lbLingua.Name = "lbLingua"
        Me.lbLingua.Size = New System.Drawing.Size(57, 16)
        Me.lbLingua.TabIndex = 115
        Me.lbLingua.Text = "LINGUA"
        '
        'cmdVoce
        '
        Me.cmdVoce.BackColor = System.Drawing.Color.Transparent
        Me.cmdVoce.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdVoce.Font = New System.Drawing.Font("Courier New", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVoce.ForeColor = System.Drawing.Color.White
        Me.cmdVoce.Image = Global.LeggiXme.My.Resources.Resources.BandIta
        Me.cmdVoce.Location = New System.Drawing.Point(70, 178)
        Me.cmdVoce.Name = "cmdVoce"
        Me.cmdVoce.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVoce.Size = New System.Drawing.Size(40, 40)
        Me.cmdVoce.TabIndex = 114
        Me.cmdVoce.Tag = "SCEGLI LINGUA"
        Me.cmdVoce.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.cmdVoce, "SCEGLI LINGUA")
        Me.cmdVoce.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(26, 482)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(238, 33)
        Me.Button1.TabIndex = 113
        Me.Button1.Text = "Elimina Appunto Selezionato"
        Me.ToolTip1.SetToolTip(Me.Button1, "ELIMINA APPUNTO SELEZIONATO")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(255, 100)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 63)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "+" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'trVelocita
        '
        Me.trVelocita.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trVelocita.Location = New System.Drawing.Point(233, 102)
        Me.trVelocita.Maximum = 8
        Me.trVelocita.Minimum = -10
        Me.trVelocita.Name = "trVelocita"
        Me.trVelocita.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trVelocita.Size = New System.Drawing.Size(45, 61)
        Me.trVelocita.TabIndex = 108
        '
        'btnTRAD
        '
        Me.btnTRAD.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnTRAD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTRAD.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTRAD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTRAD.Image = CType(resources.GetObject("btnTRAD.Image"), System.Drawing.Image)
        Me.btnTRAD.Location = New System.Drawing.Point(194, 50)
        Me.btnTRAD.Name = "btnTRAD"
        Me.btnTRAD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnTRAD.Size = New System.Drawing.Size(40, 40)
        Me.btnTRAD.TabIndex = 100
        Me.btnTRAD.UseVisualStyleBackColor = False
        Me.btnTRAD.Visible = False
        '
        'picComandi
        '
        Me.picComandi.BackColor = System.Drawing.Color.DodgerBlue
        Me.picComandi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picComandi.Controls.Add(Me.cmdPausa)
        Me.picComandi.Controls.Add(Me.cmdRipeti)
        Me.picComandi.Controls.Add(Me.cmdLeggi)
        Me.picComandi.Controls.Add(Me.cmdStop)
        Me.picComandi.Cursor = System.Windows.Forms.Cursors.Default
        Me.picComandi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picComandi.Location = New System.Drawing.Point(77, 110)
        Me.picComandi.Name = "picComandi"
        Me.picComandi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picComandi.Size = New System.Drawing.Size(122, 42)
        Me.picComandi.TabIndex = 99
        Me.picComandi.TabStop = True
        '
        'cmdPausa
        '
        Me.cmdPausa.BackColor = System.Drawing.Color.Transparent
        Me.cmdPausa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPausa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPausa.Image = Global.LeggiXme.My.Resources.Resources.pausa1
        Me.cmdPausa.Location = New System.Drawing.Point(79, 0)
        Me.cmdPausa.Name = "cmdPausa"
        Me.cmdPausa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPausa.Size = New System.Drawing.Size(40, 40)
        Me.cmdPausa.TabIndex = 19
        Me.cmdPausa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPausa.UseVisualStyleBackColor = False
        '
        'cmdRipeti
        '
        Me.cmdRipeti.BackColor = System.Drawing.Color.Transparent
        Me.cmdRipeti.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRipeti.Font = New System.Drawing.Font("Courier New", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRipeti.ForeColor = System.Drawing.Color.White
        Me.cmdRipeti.Image = CType(resources.GetObject("cmdRipeti.Image"), System.Drawing.Image)
        Me.cmdRipeti.Location = New System.Drawing.Point(200, 2)
        Me.cmdRipeti.Name = "cmdRipeti"
        Me.cmdRipeti.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRipeti.Size = New System.Drawing.Size(40, 40)
        Me.cmdRipeti.TabIndex = 18
        Me.cmdRipeti.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdRipeti.UseVisualStyleBackColor = False
        '
        'cmdLeggi
        '
        Me.cmdLeggi.BackColor = System.Drawing.Color.Transparent
        Me.cmdLeggi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdLeggi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLeggi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeggi.Image = Global.LeggiXme.My.Resources.Resources.play
        Me.cmdLeggi.Location = New System.Drawing.Point(1, 0)
        Me.cmdLeggi.Name = "cmdLeggi"
        Me.cmdLeggi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeggi.Size = New System.Drawing.Size(40, 40)
        Me.cmdLeggi.TabIndex = 15
        Me.cmdLeggi.UseVisualStyleBackColor = False
        '
        'cmdStop
        '
        Me.cmdStop.BackColor = System.Drawing.Color.Transparent
        Me.cmdStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStop.Image = Global.LeggiXme.My.Resources.Resources._stop
        Me.cmdStop.Location = New System.Drawing.Point(40, 0)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStop.Size = New System.Drawing.Size(40, 40)
        Me.cmdStop.TabIndex = 13
        Me.cmdStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStop.UseVisualStyleBackColor = False
        '
        'lstAppunti
        '
        Me.lstAppunti.BackColor = System.Drawing.Color.White
        Me.lstAppunti.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lstAppunti.FormattingEnabled = True
        Me.lstAppunti.ItemHeight = 18
        Me.lstAppunti.Location = New System.Drawing.Point(4, 224)
        Me.lstAppunti.Name = "lstAppunti"
        Me.lstAppunti.Size = New System.Drawing.Size(285, 256)
        Me.lstAppunti.TabIndex = 98
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(52, 30)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.PictureBox1.TabIndex = 97
        Me.PictureBox1.TabStop = False
        '
        'lblVoce1
        '
        Me.lblVoce1.AutoSize = True
        Me.lblVoce1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoce1.Location = New System.Drawing.Point(91, 164)
        Me.lblVoce1.Name = "lblVoce1"
        Me.lblVoce1.Size = New System.Drawing.Size(0, 16)
        Me.lblVoce1.TabIndex = 96
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 195)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "VOCE: "
        '
        'btnTorna
        '
        Me.btnTorna.BackColor = System.Drawing.Color.Transparent
        Me.btnTorna.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTorna.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTorna.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTorna.Image = Global.LeggiXme.My.Resources.Resources.home_tr
        Me.btnTorna.Location = New System.Drawing.Point(194, 10)
        Me.btnTorna.Name = "btnTorna"
        Me.btnTorna.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnTorna.Size = New System.Drawing.Size(40, 40)
        Me.btnTorna.TabIndex = 82
        Me.btnTorna.UseVisualStyleBackColor = False
        '
        'btnIncolla
        '
        Me.btnIncolla.BackColor = System.Drawing.Color.Green
        Me.btnIncolla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncolla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnIncolla.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIncolla.Image = CType(resources.GetObject("btnIncolla.Image"), System.Drawing.Image)
        Me.btnIncolla.Location = New System.Drawing.Point(103, 27)
        Me.btnIncolla.Name = "btnIncolla"
        Me.btnIncolla.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIncolla.Size = New System.Drawing.Size(40, 40)
        Me.btnIncolla.TabIndex = 81
        Me.btnIncolla.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(34, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 74)
        Me.Label1.TabIndex = 86
        '
        'MenuVoci
        '
        Me.MenuVoci.ImageScalingSize = New System.Drawing.Size(24, 16)
        Me.MenuVoci.Name = "MenuVoci"
        Me.MenuVoci.Size = New System.Drawing.Size(153, 26)
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(61, 4)
        '
        'frmAPP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.PaleTurquoise
        Me.ClientSize = New System.Drawing.Size(784, 522)
        Me.Controls.Add(Me.pnComandi)
        Me.Controls.Add(Me.pnPDF)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAPP"
        Me.Text = "LeggiXme -Appunti"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnPDF.ResumeLayout(False)
        Me.AutoVerbMenu.ResumeLayout(False)
        Me.pnComandi.ResumeLayout(False)
        Me.pnComandi.PerformLayout()
        CType(Me.trVelocita, System.ComponentModel.ISupportInitialize).EndInit()
        Me.picComandi.ResumeLayout(False)
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnPDF As System.Windows.Forms.Panel
    Friend WithEvents pnComandi As System.Windows.Forms.Panel
    Friend WithEvents btnIncolla As System.Windows.Forms.Button
    Friend WithEvents btnTorna As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblVoce1 As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lstAppunti As System.Windows.Forms.ListBox
    Public WithEvents picComandi As System.Windows.Forms.Panel
    Public WithEvents cmdPausa As System.Windows.Forms.Button
    Public WithEvents cmdRipeti As System.Windows.Forms.Button
    Friend WithEvents cmdLeggi As System.Windows.Forms.Button
    Public WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents btnTRAD As System.Windows.Forms.Button
    Friend WithEvents AutoVerbMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Annulla As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Ripristina As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Taglia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Copia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Incolla_Testo As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TB1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents trVelocita As System.Windows.Forms.TrackBar
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MenuVoci As System.Windows.Forms.ContextMenuStrip
    Public WithEvents cmdVoce As System.Windows.Forms.Button
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents lbLingua As System.Windows.Forms.Label
    'Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
End Class
