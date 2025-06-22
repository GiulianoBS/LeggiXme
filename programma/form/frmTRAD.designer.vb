<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTRAD
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTRAD))
        Me.pnPDF = New System.Windows.Forms.Panel()
        Me.TB2 = New System.Windows.Forms.RichTextBox()
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
        Me.TB1 = New System.Windows.Forms.RichTextBox()
        Me.cmdVoce2 = New System.Windows.Forms.Button()
        Me.cmdVoce1 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.pnDa = New System.Windows.Forms.Panel()
        Me.rbLatino = New System.Windows.Forms.RadioButton()
        Me.rbAuto = New System.Windows.Forms.RadioButton()
        Me.rbTedesco = New System.Windows.Forms.RadioButton()
        Me.rbSpagnolo = New System.Windows.Forms.RadioButton()
        Me.rbFrancese = New System.Windows.Forms.RadioButton()
        Me.rbInglese = New System.Windows.Forms.RadioButton()
        Me.rbItaliano = New System.Windows.Forms.RadioButton()
        Me.picComandi1 = New System.Windows.Forms.Panel()
        Me.cmdPausa = New System.Windows.Forms.Button()
        Me.cmdRipeti = New System.Windows.Forms.Button()
        Me.cmdLeggi1 = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.trVelocita = New System.Windows.Forms.TrackBar()
        Me.btnDiz = New System.Windows.Forms.Button()
        Me.btnAppunti = New System.Windows.Forms.Button()
        Me.lblVoce1 = New System.Windows.Forms.Label()
        Me.lblVoce2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pnVoci = New System.Windows.Forms.Panel()
        Me.btnItaliano = New System.Windows.Forms.Button()
        Me.btnTedesco = New System.Windows.Forms.Button()
        Me.btnSpagnolo = New System.Windows.Forms.Button()
        Me.btnFrancese = New System.Windows.Forms.Button()
        Me.btnInglese = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.picComandi2 = New System.Windows.Forms.Panel()
        Me.cmdPausa2 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.cmdStop2 = New System.Windows.Forms.Button()
        Me.cmdLeggi2 = New System.Windows.Forms.Button()
        Me.RB2 = New System.Windows.Forms.RadioButton()
        Me.RB1 = New System.Windows.Forms.RadioButton()
        Me.btnTorna = New System.Windows.Forms.Button()
        Me.btnIncolla = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuVoci1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.MenuVoci2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnPDF.SuspendLayout()
        Me.AutoVerbMenu.SuspendLayout()
        Me.pnDa.SuspendLayout()
        Me.picComandi1.SuspendLayout()
        CType(Me.trVelocita, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnVoci.SuspendLayout()
        Me.picComandi2.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnPDF
        '
        Me.pnPDF.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnPDF.BackColor = System.Drawing.Color.Gainsboro
        Me.pnPDF.Controls.Add(Me.TB2)
        Me.pnPDF.Controls.Add(Me.TB1)
        Me.pnPDF.Location = New System.Drawing.Point(0, 0)
        Me.pnPDF.Name = "pnPDF"
        Me.pnPDF.Size = New System.Drawing.Size(543, 521)
        Me.pnPDF.TabIndex = 0
        '
        'TB2
        '
        Me.TB2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB2.ContextMenuStrip = Me.AutoVerbMenu
        Me.TB2.HideSelection = False
        Me.TB2.Location = New System.Drawing.Point(2, 266)
        Me.TB2.Name = "TB2"
        Me.TB2.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.TB2.Size = New System.Drawing.Size(534, 255)
        Me.TB2.TabIndex = 90
        Me.TB2.Text = ""
        '
        'AutoVerbMenu
        '
        Me.AutoVerbMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Annulla, Me.Ripristina, Me.ToolStripSeparator1, Me.Taglia, Me.ToolStripSeparator2, Me.Copia, Me.ToolStripSeparator3, Me.Incolla_Testo, Me.ToolStripSeparator4})
        Me.AutoVerbMenu.Name = "AutoVerbMenu"
        Me.AutoVerbMenu.ShowImageMargin = False
        Me.AutoVerbMenu.Size = New System.Drawing.Size(115, 138)
        '
        'Annulla
        '
        Me.Annulla.Name = "Annulla"
        Me.Annulla.Size = New System.Drawing.Size(114, 22)
        Me.Annulla.Text = "Annulla"
        '
        'Ripristina
        '
        Me.Ripristina.Name = "Ripristina"
        Me.Ripristina.Size = New System.Drawing.Size(114, 22)
        Me.Ripristina.Text = "Ripristina"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(111, 6)
        '
        'Taglia
        '
        Me.Taglia.Name = "Taglia"
        Me.Taglia.Size = New System.Drawing.Size(114, 22)
        Me.Taglia.Text = "Taglia"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(111, 6)
        '
        'Copia
        '
        Me.Copia.Name = "Copia"
        Me.Copia.ShowShortcutKeys = False
        Me.Copia.Size = New System.Drawing.Size(114, 22)
        Me.Copia.Text = "Copia"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(111, 6)
        '
        'Incolla_Testo
        '
        Me.Incolla_Testo.Name = "Incolla_Testo"
        Me.Incolla_Testo.Size = New System.Drawing.Size(114, 22)
        Me.Incolla_Testo.Text = "Incolla Testo"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(111, 6)
        '
        'TB1
        '
        Me.TB1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TB1.ContextMenuStrip = Me.AutoVerbMenu
        Me.TB1.HideSelection = False
        Me.TB1.Location = New System.Drawing.Point(2, 2)
        Me.TB1.Name = "TB1"
        Me.TB1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.TB1.Size = New System.Drawing.Size(534, 255)
        Me.TB1.TabIndex = 89
        Me.TB1.Text = ""
        '
        'cmdVoce2
        '
        Me.cmdVoce2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVoce2.BackColor = System.Drawing.Color.Transparent
        Me.cmdVoce2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdVoce2.Font = New System.Drawing.Font("Courier New", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVoce2.ForeColor = System.Drawing.Color.White
        Me.cmdVoce2.Image = Global.LeggiXme.My.Resources.Resources.BandIta
        Me.cmdVoce2.Location = New System.Drawing.Point(752, 248)
        Me.cmdVoce2.Name = "cmdVoce2"
        Me.cmdVoce2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVoce2.Size = New System.Drawing.Size(40, 40)
        Me.cmdVoce2.TabIndex = 116
        Me.cmdVoce2.Tag = "SCEGLI LINGUA"
        Me.cmdVoce2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.cmdVoce2, "SCEGLI LINGUA")
        Me.cmdVoce2.UseVisualStyleBackColor = False
        '
        'cmdVoce1
        '
        Me.cmdVoce1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVoce1.BackColor = System.Drawing.Color.Transparent
        Me.cmdVoce1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdVoce1.Font = New System.Drawing.Font("Courier New", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVoce1.ForeColor = System.Drawing.Color.White
        Me.cmdVoce1.Image = Global.LeggiXme.My.Resources.Resources.BandIta
        Me.cmdVoce1.Location = New System.Drawing.Point(752, 185)
        Me.cmdVoce1.Name = "cmdVoce1"
        Me.cmdVoce1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVoce1.Size = New System.Drawing.Size(40, 40)
        Me.cmdVoce1.TabIndex = 115
        Me.cmdVoce1.Tag = "SCEGLI LINGUA"
        Me.cmdVoce1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.cmdVoce1, "SCEGLI LINGUA")
        Me.cmdVoce1.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(716, 126)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 16)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "VELOCITA'"
        '
        'pnDa
        '
        Me.pnDa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnDa.BackColor = System.Drawing.Color.Silver
        Me.pnDa.Controls.Add(Me.rbLatino)
        Me.pnDa.Controls.Add(Me.rbAuto)
        Me.pnDa.Controls.Add(Me.rbTedesco)
        Me.pnDa.Controls.Add(Me.rbSpagnolo)
        Me.pnDa.Controls.Add(Me.rbFrancese)
        Me.pnDa.Controls.Add(Me.rbInglese)
        Me.pnDa.Controls.Add(Me.rbItaliano)
        Me.pnDa.Controls.Add(Me.picComandi1)
        Me.pnDa.Location = New System.Drawing.Point(549, 2)
        Me.pnDa.Name = "pnDa"
        Me.pnDa.Size = New System.Drawing.Size(131, 250)
        Me.pnDa.TabIndex = 109
        '
        'rbLatino
        '
        Me.rbLatino.BackColor = System.Drawing.Color.Transparent
        Me.rbLatino.Image = Global.LeggiXme.My.Resources.Resources.bandLat
        Me.rbLatino.Location = New System.Drawing.Point(10, 190)
        Me.rbLatino.Name = "rbLatino"
        Me.rbLatino.Size = New System.Drawing.Size(119, 27)
        Me.rbLatino.TabIndex = 104
        Me.rbLatino.TabStop = True
        Me.rbLatino.Text = "LATINO        "
        Me.rbLatino.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbLatino.UseVisualStyleBackColor = False
        '
        'rbAuto
        '
        Me.rbAuto.BackColor = System.Drawing.Color.Transparent
        Me.rbAuto.Image = Global.LeggiXme.My.Resources.Resources.PunDom_R1
        Me.rbAuto.Location = New System.Drawing.Point(12, 217)
        Me.rbAuto.Name = "rbAuto"
        Me.rbAuto.Size = New System.Drawing.Size(117, 27)
        Me.rbAuto.TabIndex = 103
        Me.rbAuto.TabStop = True
        Me.rbAuto.Text = "AUTOMAT. "
        Me.rbAuto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbAuto.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbAuto.UseVisualStyleBackColor = False
        '
        'rbTedesco
        '
        Me.rbTedesco.BackColor = System.Drawing.Color.Transparent
        Me.rbTedesco.Image = Global.LeggiXme.My.Resources.Resources.bandGerm
        Me.rbTedesco.Location = New System.Drawing.Point(9, 164)
        Me.rbTedesco.Name = "rbTedesco"
        Me.rbTedesco.Size = New System.Drawing.Size(119, 27)
        Me.rbTedesco.TabIndex = 102
        Me.rbTedesco.TabStop = True
        Me.rbTedesco.Text = "TEDESCO   "
        Me.rbTedesco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbTedesco.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbTedesco.UseVisualStyleBackColor = False
        '
        'rbSpagnolo
        '
        Me.rbSpagnolo.BackColor = System.Drawing.Color.Transparent
        Me.rbSpagnolo.Image = Global.LeggiXme.My.Resources.Resources.bandSpa
        Me.rbSpagnolo.Location = New System.Drawing.Point(9, 137)
        Me.rbSpagnolo.Name = "rbSpagnolo"
        Me.rbSpagnolo.Size = New System.Drawing.Size(119, 27)
        Me.rbSpagnolo.TabIndex = 101
        Me.rbSpagnolo.TabStop = True
        Me.rbSpagnolo.Text = "SPAGNOLO"
        Me.rbSpagnolo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbSpagnolo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbSpagnolo.UseVisualStyleBackColor = False
        '
        'rbFrancese
        '
        Me.rbFrancese.BackColor = System.Drawing.Color.Transparent
        Me.rbFrancese.Image = Global.LeggiXme.My.Resources.Resources.bandFra
        Me.rbFrancese.Location = New System.Drawing.Point(9, 110)
        Me.rbFrancese.Name = "rbFrancese"
        Me.rbFrancese.Size = New System.Drawing.Size(119, 27)
        Me.rbFrancese.TabIndex = 100
        Me.rbFrancese.TabStop = True
        Me.rbFrancese.Text = "FRANCESE"
        Me.rbFrancese.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbFrancese.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbFrancese.UseVisualStyleBackColor = False
        '
        'rbInglese
        '
        Me.rbInglese.BackColor = System.Drawing.Color.Transparent
        Me.rbInglese.Image = Global.LeggiXme.My.Resources.Resources.bandUk
        Me.rbInglese.Location = New System.Drawing.Point(9, 85)
        Me.rbInglese.Name = "rbInglese"
        Me.rbInglese.Size = New System.Drawing.Size(117, 27)
        Me.rbInglese.TabIndex = 99
        Me.rbInglese.TabStop = True
        Me.rbInglese.Text = " INGLESE   "
        Me.rbInglese.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbInglese.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbInglese.UseVisualStyleBackColor = False
        '
        'rbItaliano
        '
        Me.rbItaliano.BackColor = System.Drawing.Color.Transparent
        Me.rbItaliano.Image = Global.LeggiXme.My.Resources.Resources.BandIta
        Me.rbItaliano.Location = New System.Drawing.Point(10, 57)
        Me.rbItaliano.Name = "rbItaliano"
        Me.rbItaliano.Size = New System.Drawing.Size(116, 27)
        Me.rbItaliano.TabIndex = 98
        Me.rbItaliano.TabStop = True
        Me.rbItaliano.Text = " ITALIANO  "
        Me.rbItaliano.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbItaliano.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.rbItaliano.UseVisualStyleBackColor = False
        '
        'picComandi1
        '
        Me.picComandi1.BackColor = System.Drawing.Color.DodgerBlue
        Me.picComandi1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picComandi1.Controls.Add(Me.cmdPausa)
        Me.picComandi1.Controls.Add(Me.cmdRipeti)
        Me.picComandi1.Controls.Add(Me.cmdLeggi1)
        Me.picComandi1.Controls.Add(Me.cmdStop)
        Me.picComandi1.Cursor = System.Windows.Forms.Cursors.Default
        Me.picComandi1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picComandi1.Location = New System.Drawing.Point(6, 3)
        Me.picComandi1.Name = "picComandi1"
        Me.picComandi1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picComandi1.Size = New System.Drawing.Size(121, 42)
        Me.picComandi1.TabIndex = 78
        Me.picComandi1.TabStop = True
        '
        'cmdPausa
        '
        Me.cmdPausa.BackColor = System.Drawing.Color.Yellow
        Me.cmdPausa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPausa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPausa.Image = CType(resources.GetObject("cmdPausa.Image"), System.Drawing.Image)
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
        'cmdLeggi1
        '
        Me.cmdLeggi1.BackColor = System.Drawing.Color.Green
        Me.cmdLeggi1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdLeggi1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLeggi1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeggi1.Image = CType(resources.GetObject("cmdLeggi1.Image"), System.Drawing.Image)
        Me.cmdLeggi1.Location = New System.Drawing.Point(1, 0)
        Me.cmdLeggi1.Name = "cmdLeggi1"
        Me.cmdLeggi1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeggi1.Size = New System.Drawing.Size(40, 40)
        Me.cmdLeggi1.TabIndex = 15
        Me.cmdLeggi1.UseVisualStyleBackColor = False
        '
        'cmdStop
        '
        Me.cmdStop.BackColor = System.Drawing.Color.Red
        Me.cmdStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStop.Image = CType(resources.GetObject("cmdStop.Image"), System.Drawing.Image)
        Me.cmdStop.Location = New System.Drawing.Point(40, 0)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStop.Size = New System.Drawing.Size(40, 40)
        Me.cmdStop.TabIndex = 13
        Me.cmdStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStop.UseVisualStyleBackColor = False
        '
        'Label6
        '
        Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(705, 146)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(17, 16)
        Me.Label6.TabIndex = 108
        Me.Label6.Text = "-"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(847, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 16)
        Me.Label5.TabIndex = 107
        Me.Label5.Text = "+" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'trVelocita
        '
        Me.trVelocita.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trVelocita.Location = New System.Drawing.Point(709, 158)
        Me.trVelocita.Maximum = 8
        Me.trVelocita.Minimum = -10
        Me.trVelocita.Name = "trVelocita"
        Me.trVelocita.Size = New System.Drawing.Size(152, 45)
        Me.trVelocita.TabIndex = 106
        '
        'btnDiz
        '
        Me.btnDiz.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDiz.BackColor = System.Drawing.Color.Yellow
        Me.btnDiz.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnDiz.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnDiz.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDiz.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDiz.Image = CType(resources.GetObject("btnDiz.Image"), System.Drawing.Image)
        Me.btnDiz.Location = New System.Drawing.Point(837, 100)
        Me.btnDiz.Name = "btnDiz"
        Me.btnDiz.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnDiz.Size = New System.Drawing.Size(36, 35)
        Me.btnDiz.TabIndex = 99
        Me.ToolTip1.SetToolTip(Me.btnDiz, " DIZIONARIO ")
        Me.btnDiz.UseVisualStyleBackColor = True
        Me.btnDiz.Visible = False
        '
        'btnAppunti
        '
        Me.btnAppunti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAppunti.BackColor = System.Drawing.Color.Yellow
        Me.btnAppunti.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAppunti.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnAppunti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAppunti.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAppunti.Image = CType(resources.GetObject("btnAppunti.Image"), System.Drawing.Image)
        Me.btnAppunti.Location = New System.Drawing.Point(835, 58)
        Me.btnAppunti.Name = "btnAppunti"
        Me.btnAppunti.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAppunti.Size = New System.Drawing.Size(37, 36)
        Me.btnAppunti.TabIndex = 98
        Me.ToolTip1.SetToolTip(Me.btnAppunti, "  APPUNTI ")
        Me.btnAppunti.UseVisualStyleBackColor = True
        Me.btnAppunti.Visible = False
        '
        'lblVoce1
        '
        Me.lblVoce1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVoce1.AutoSize = True
        Me.lblVoce1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoce1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.lblVoce1.Location = New System.Drawing.Point(798, 200)
        Me.lblVoce1.Name = "lblVoce1"
        Me.lblVoce1.Size = New System.Drawing.Size(16, 16)
        Me.lblVoce1.TabIndex = 96
        Me.lblVoce1.Text = "a"
        Me.lblVoce1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblVoce2
        '
        Me.lblVoce2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVoce2.AutoSize = True
        Me.lblVoce2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVoce2.Location = New System.Drawing.Point(795, 262)
        Me.lblVoce2.Name = "lblVoce2"
        Me.lblVoce2.Size = New System.Drawing.Size(16, 16)
        Me.lblVoce2.TabIndex = 97
        Me.lblVoce2.Text = "a"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(701, 262)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 16)
        Me.Label4.TabIndex = 95
        Me.Label4.Text = "VOCE 2: "
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(702, 203)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 16)
        Me.Label3.TabIndex = 93
        Me.Label3.Text = "VOCE 1: "
        '
        'pnVoci
        '
        Me.pnVoci.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnVoci.BackColor = System.Drawing.Color.Silver
        Me.pnVoci.Controls.Add(Me.btnItaliano)
        Me.pnVoci.Controls.Add(Me.btnTedesco)
        Me.pnVoci.Controls.Add(Me.btnSpagnolo)
        Me.pnVoci.Controls.Add(Me.btnFrancese)
        Me.pnVoci.Controls.Add(Me.btnInglese)
        Me.pnVoci.Controls.Add(Me.Label2)
        Me.pnVoci.Controls.Add(Me.picComandi2)
        Me.pnVoci.Location = New System.Drawing.Point(551, 266)
        Me.pnVoci.Name = "pnVoci"
        Me.pnVoci.Size = New System.Drawing.Size(127, 234)
        Me.pnVoci.TabIndex = 91
        '
        'btnItaliano
        '
        Me.btnItaliano.Image = CType(resources.GetObject("btnItaliano.Image"), System.Drawing.Image)
        Me.btnItaliano.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnItaliano.Location = New System.Drawing.Point(11, 150)
        Me.btnItaliano.Name = "btnItaliano"
        Me.btnItaliano.Size = New System.Drawing.Size(105, 32)
        Me.btnItaliano.TabIndex = 92
        Me.btnItaliano.Text = "ITALIANO"
        Me.btnItaliano.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnItaliano.UseVisualStyleBackColor = True
        '
        'btnTedesco
        '
        Me.btnTedesco.Image = CType(resources.GetObject("btnTedesco.Image"), System.Drawing.Image)
        Me.btnTedesco.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTedesco.Location = New System.Drawing.Point(11, 120)
        Me.btnTedesco.Name = "btnTedesco"
        Me.btnTedesco.Size = New System.Drawing.Size(105, 32)
        Me.btnTedesco.TabIndex = 91
        Me.btnTedesco.Text = "TEDESCO"
        Me.btnTedesco.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTedesco.UseVisualStyleBackColor = True
        '
        'btnSpagnolo
        '
        Me.btnSpagnolo.Image = CType(resources.GetObject("btnSpagnolo.Image"), System.Drawing.Image)
        Me.btnSpagnolo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSpagnolo.Location = New System.Drawing.Point(11, 91)
        Me.btnSpagnolo.Name = "btnSpagnolo"
        Me.btnSpagnolo.Size = New System.Drawing.Size(105, 32)
        Me.btnSpagnolo.TabIndex = 90
        Me.btnSpagnolo.Text = "SPAGNOLO"
        Me.btnSpagnolo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSpagnolo.UseVisualStyleBackColor = True
        '
        'btnFrancese
        '
        Me.btnFrancese.Image = CType(resources.GetObject("btnFrancese.Image"), System.Drawing.Image)
        Me.btnFrancese.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnFrancese.Location = New System.Drawing.Point(11, 62)
        Me.btnFrancese.Name = "btnFrancese"
        Me.btnFrancese.Size = New System.Drawing.Size(105, 32)
        Me.btnFrancese.TabIndex = 89
        Me.btnFrancese.Text = "FRANCESE"
        Me.btnFrancese.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnFrancese.UseVisualStyleBackColor = True
        '
        'btnInglese
        '
        Me.btnInglese.Image = CType(resources.GetObject("btnInglese.Image"), System.Drawing.Image)
        Me.btnInglese.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnInglese.Location = New System.Drawing.Point(11, 31)
        Me.btnInglese.Name = "btnInglese"
        Me.btnInglese.Size = New System.Drawing.Size(105, 32)
        Me.btnInglese.TabIndex = 1
        Me.btnInglese.Text = "INGLESE"
        Me.btnInglese.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnInglese.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.LavenderBlush
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(2, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(123, 24)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "TRADUCI IN"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'picComandi2
        '
        Me.picComandi2.BackColor = System.Drawing.Color.DodgerBlue
        Me.picComandi2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picComandi2.Controls.Add(Me.cmdPausa2)
        Me.picComandi2.Controls.Add(Me.Button2)
        Me.picComandi2.Controls.Add(Me.Button4)
        Me.picComandi2.Controls.Add(Me.cmdStop2)
        Me.picComandi2.Controls.Add(Me.cmdLeggi2)
        Me.picComandi2.Cursor = System.Windows.Forms.Cursors.Default
        Me.picComandi2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picComandi2.Location = New System.Drawing.Point(3, 188)
        Me.picComandi2.Name = "picComandi2"
        Me.picComandi2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picComandi2.Size = New System.Drawing.Size(121, 42)
        Me.picComandi2.TabIndex = 88
        Me.picComandi2.TabStop = True
        '
        'cmdPausa2
        '
        Me.cmdPausa2.BackColor = System.Drawing.Color.Yellow
        Me.cmdPausa2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPausa2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPausa2.Image = CType(resources.GetObject("cmdPausa2.Image"), System.Drawing.Image)
        Me.cmdPausa2.Location = New System.Drawing.Point(78, 0)
        Me.cmdPausa2.Name = "cmdPausa2"
        Me.cmdPausa2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPausa2.Size = New System.Drawing.Size(40, 40)
        Me.cmdPausa2.TabIndex = 19
        Me.cmdPausa2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdPausa2.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Transparent
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.Font = New System.Drawing.Font("Courier New", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(200, 2)
        Me.Button2.Name = "Button2"
        Me.Button2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button2.Size = New System.Drawing.Size(40, 40)
        Me.Button2.TabIndex = 18
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button4.Image = CType(resources.GetObject("Button4.Image"), System.Drawing.Image)
        Me.Button4.Location = New System.Drawing.Point(156, 0)
        Me.Button4.Name = "Button4"
        Me.Button4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button4.Size = New System.Drawing.Size(40, 40)
        Me.Button4.TabIndex = 14
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Button4.UseVisualStyleBackColor = False
        '
        'cmdStop2
        '
        Me.cmdStop2.BackColor = System.Drawing.Color.Red
        Me.cmdStop2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdStop2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStop2.Image = CType(resources.GetObject("cmdStop2.Image"), System.Drawing.Image)
        Me.cmdStop2.Location = New System.Drawing.Point(39, 0)
        Me.cmdStop2.Name = "cmdStop2"
        Me.cmdStop2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStop2.Size = New System.Drawing.Size(40, 40)
        Me.cmdStop2.TabIndex = 13
        Me.cmdStop2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStop2.UseVisualStyleBackColor = False
        '
        'cmdLeggi2
        '
        Me.cmdLeggi2.BackColor = System.Drawing.Color.SteelBlue
        Me.cmdLeggi2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdLeggi2.Font = New System.Drawing.Font("Courier New", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdLeggi2.ForeColor = System.Drawing.Color.White
        Me.cmdLeggi2.Image = CType(resources.GetObject("cmdLeggi2.Image"), System.Drawing.Image)
        Me.cmdLeggi2.Location = New System.Drawing.Point(1, 0)
        Me.cmdLeggi2.Name = "cmdLeggi2"
        Me.cmdLeggi2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeggi2.Size = New System.Drawing.Size(40, 40)
        Me.cmdLeggi2.TabIndex = 17
        Me.cmdLeggi2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdLeggi2.UseVisualStyleBackColor = False
        '
        'RB2
        '
        Me.RB2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RB2.AutoSize = True
        Me.RB2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB2.Image = CType(resources.GetObject("RB2.Image"), System.Drawing.Image)
        Me.RB2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RB2.Location = New System.Drawing.Point(701, 49)
        Me.RB2.Name = "RB2"
        Me.RB2.Size = New System.Drawing.Size(46, 32)
        Me.RB2.TabIndex = 90
        Me.RB2.TabStop = True
        Me.RB2.Text = "2"
        Me.RB2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RB2.UseVisualStyleBackColor = True
        '
        'RB1
        '
        Me.RB1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RB1.AutoSize = True
        Me.RB1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RB1.Image = CType(resources.GetObject("RB1.Image"), System.Drawing.Image)
        Me.RB1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.RB1.Location = New System.Drawing.Point(701, 15)
        Me.RB1.Name = "RB1"
        Me.RB1.Size = New System.Drawing.Size(46, 32)
        Me.RB1.TabIndex = 89
        Me.RB1.TabStop = True
        Me.RB1.Text = "1"
        Me.RB1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.RB1.UseVisualStyleBackColor = True
        '
        'btnTorna
        '
        Me.btnTorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTorna.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnTorna.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTorna.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTorna.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTorna.Image = CType(resources.GetObject("btnTorna.Image"), System.Drawing.Image)
        Me.btnTorna.Location = New System.Drawing.Point(834, 13)
        Me.btnTorna.Name = "btnTorna"
        Me.btnTorna.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnTorna.Size = New System.Drawing.Size(40, 40)
        Me.btnTorna.TabIndex = 82
        Me.btnTorna.UseVisualStyleBackColor = False
        '
        'btnIncolla
        '
        Me.btnIncolla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIncolla.BackColor = System.Drawing.Color.Green
        Me.btnIncolla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncolla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnIncolla.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIncolla.Image = CType(resources.GetObject("btnIncolla.Image"), System.Drawing.Image)
        Me.btnIncolla.Location = New System.Drawing.Point(758, 26)
        Me.btnIncolla.Name = "btnIncolla"
        Me.btnIncolla.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIncolla.Size = New System.Drawing.Size(40, 40)
        Me.btnIncolla.TabIndex = 81
        Me.btnIncolla.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(686, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 80)
        Me.Label1.TabIndex = 86
        '
        'MenuVoci1
        '
        Me.MenuVoci1.ImageScalingSize = New System.Drawing.Size(24, 16)
        Me.MenuVoci1.Name = "MenuVoci"
        Me.MenuVoci1.Size = New System.Drawing.Size(61, 4)
        '
        'MenuVoci2
        '
        Me.MenuVoci2.ImageScalingSize = New System.Drawing.Size(24, 16)
        Me.MenuVoci2.Name = "MenuVoci"
        Me.MenuVoci2.Size = New System.Drawing.Size(61, 4)
        '
        'frmTRAD
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(884, 521)
        Me.Controls.Add(Me.btnTorna)
        Me.Controls.Add(Me.pnVoci)
        Me.Controls.Add(Me.cmdVoce2)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmdVoce1)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.pnDa)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.trVelocita)
        Me.Controls.Add(Me.pnPDF)
        Me.Controls.Add(Me.btnDiz)
        Me.Controls.Add(Me.btnAppunti)
        Me.Controls.Add(Me.btnIncolla)
        Me.Controls.Add(Me.lblVoce1)
        Me.Controls.Add(Me.RB1)
        Me.Controls.Add(Me.lblVoce2)
        Me.Controls.Add(Me.RB2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label3)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTRAD"
        Me.Text = "LeggiXme -Traduci"
        Me.pnPDF.ResumeLayout(False)
        Me.AutoVerbMenu.ResumeLayout(False)
        Me.pnDa.ResumeLayout(False)
        Me.picComandi1.ResumeLayout(False)
        CType(Me.trVelocita, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnVoci.ResumeLayout(False)
        Me.picComandi2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnPDF As System.Windows.Forms.Panel
    Public WithEvents picComandi1 As System.Windows.Forms.Panel
    Public WithEvents cmdPausa As System.Windows.Forms.Button
    Public WithEvents cmdRipeti As System.Windows.Forms.Button
    Public WithEvents cmdLeggi2 As System.Windows.Forms.Button
    Friend WithEvents cmdLeggi1 As System.Windows.Forms.Button
    Public WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents btnIncolla As System.Windows.Forms.Button
    Friend WithEvents btnTorna As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Public WithEvents picComandi2 As System.Windows.Forms.Panel
    Public WithEvents cmdPausa2 As System.Windows.Forms.Button
    Public WithEvents Button2 As System.Windows.Forms.Button
    Public WithEvents Button4 As System.Windows.Forms.Button
    Public WithEvents cmdStop2 As System.Windows.Forms.Button
    Friend WithEvents RB1 As System.Windows.Forms.RadioButton
    Friend WithEvents RB2 As System.Windows.Forms.RadioButton
    Friend WithEvents pnVoci As System.Windows.Forms.Panel
    Friend WithEvents btnInglese As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnItaliano As System.Windows.Forms.Button
    Friend WithEvents btnTedesco As System.Windows.Forms.Button
    Friend WithEvents btnSpagnolo As System.Windows.Forms.Button
    Friend WithEvents btnFrancese As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblVoce2 As System.Windows.Forms.Label
    Friend WithEvents lblVoce1 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnAppunti As System.Windows.Forms.Button
    Friend WithEvents TB2 As System.Windows.Forms.RichTextBox
    Friend WithEvents TB1 As System.Windows.Forms.RichTextBox
    Friend WithEvents btnDiz As System.Windows.Forms.Button
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
    Friend WithEvents trVelocita As System.Windows.Forms.TrackBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents pnDa As System.Windows.Forms.Panel
    Friend WithEvents rbItaliano As System.Windows.Forms.RadioButton
    Friend WithEvents rbAuto As System.Windows.Forms.RadioButton
    Friend WithEvents rbTedesco As System.Windows.Forms.RadioButton
    Friend WithEvents rbSpagnolo As System.Windows.Forms.RadioButton
    Friend WithEvents rbFrancese As System.Windows.Forms.RadioButton
    Friend WithEvents rbInglese As System.Windows.Forms.RadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rbLatino As System.Windows.Forms.RadioButton
    Friend WithEvents MenuVoci1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents MenuVoci2 As System.Windows.Forms.ContextMenuStrip
    Public WithEvents cmdVoce2 As System.Windows.Forms.Button
    Public WithEvents cmdVoce1 As System.Windows.Forms.Button
    'Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
End Class
