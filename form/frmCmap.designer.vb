<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCmap
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCmap))
        Me.RTB = New System.Windows.Forms.RichTextBox()
        Me.AutoVerbMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.Annulla = New System.Windows.Forms.ToolStripMenuItem()
        Me.Ripristina = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.Taglia = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.Copia = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.Incolla_Tutto = New System.Windows.Forms.ToolStripMenuItem()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DGmenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.EliminaRigaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LeggiRigaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbMappe = New System.Windows.Forms.ToolStrip()
        Me.btnLeggi = New System.Windows.Forms.ToolStripButton()
        Me.btnStop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.btnF0 = New System.Windows.Forms.ToolStripButton()
        Me.btnF1 = New System.Windows.Forms.ToolStripButton()
        Me.btnF2 = New System.Windows.Forms.ToolStripButton()
        Me.btnF3 = New System.Windows.Forms.ToolStripButton()
        Me.btnF4 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel29 = New System.Windows.Forms.ToolStripLabel()
        Me.btnM1 = New System.Windows.Forms.ToolStripButton()
        Me.btnM2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel30 = New System.Windows.Forms.ToolStripLabel()
        Me.btnAnnullaMappa = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.btnInvia = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.AutoVerbMenu.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.DGmenu.SuspendLayout()
        Me.tbMappe.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RTB
        '
        Me.RTB.AcceptsTab = True
        Me.RTB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RTB.BackColor = System.Drawing.Color.White
        Me.RTB.ContextMenuStrip = Me.AutoVerbMenu
        Me.RTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RTB.HideSelection = False
        Me.RTB.Location = New System.Drawing.Point(0, 42)
        Me.RTB.Name = "RTB"
        Me.RTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RTB.Size = New System.Drawing.Size(650, 545)
        Me.RTB.TabIndex = 0
        Me.RTB.Text = ""
        '
        'AutoVerbMenu
        '
        Me.AutoVerbMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Annulla, Me.Ripristina, Me.ToolStripSeparator1, Me.Taglia, Me.ToolStripSeparator2, Me.Copia, Me.ToolStripSeparator3, Me.Incolla_Tutto})
        Me.AutoVerbMenu.Name = "AutoVerbMenu"
        Me.AutoVerbMenu.ShowImageMargin = False
        Me.AutoVerbMenu.Size = New System.Drawing.Size(148, 132)
        '
        'Annulla
        '
        Me.Annulla.Name = "Annulla"
        Me.Annulla.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.Annulla.Size = New System.Drawing.Size(147, 22)
        Me.Annulla.Text = "Annulla"
        '
        'Ripristina
        '
        Me.Ripristina.Name = "Ripristina"
        Me.Ripristina.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.Ripristina.Size = New System.Drawing.Size(147, 22)
        Me.Ripristina.Text = "Ripristina"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(144, 6)
        '
        'Taglia
        '
        Me.Taglia.Name = "Taglia"
        Me.Taglia.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.Taglia.Size = New System.Drawing.Size(147, 22)
        Me.Taglia.Text = "Taglia"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(144, 6)
        '
        'Copia
        '
        Me.Copia.Name = "Copia"
        Me.Copia.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.Copia.Size = New System.Drawing.Size(147, 22)
        Me.Copia.Text = "Copia"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(144, 6)
        '
        'Incolla_Tutto
        '
        Me.Incolla_Tutto.Name = "Incolla_Tutto"
        Me.Incolla_Tutto.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.Incolla_Tutto.Size = New System.Drawing.Size(147, 22)
        Me.Incolla_Tutto.Text = "Incolla"
        '
        'DataGridView1
        '
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column1, Me.Column2, Me.Column3})
        Me.DataGridView1.ContextMenuStrip = Me.DGmenu
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Location = New System.Drawing.Point(661, 42)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DataGridView1.Size = New System.Drawing.Size(347, 545)
        Me.DataGridView1.TabIndex = 7
        '
        'Column1
        '
        Me.Column1.HeaderText = "Origine"
        Me.Column1.Name = "Column1"
        Me.Column1.Width = 110
        '
        'Column2
        '
        Me.Column2.HeaderText = "Relazione"
        Me.Column2.Name = "Column2"
        Me.Column2.Width = 110
        '
        'Column3
        '
        Me.Column3.HeaderText = "Destinazione"
        Me.Column3.Name = "Column3"
        Me.Column3.Width = 110
        '
        'DGmenu
        '
        Me.DGmenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.EliminaRigaToolStripMenuItem, Me.LeggiRigaToolStripMenuItem})
        Me.DGmenu.Name = "DGmenu"
        Me.DGmenu.Size = New System.Drawing.Size(140, 48)
        '
        'EliminaRigaToolStripMenuItem
        '
        Me.EliminaRigaToolStripMenuItem.Name = "EliminaRigaToolStripMenuItem"
        Me.EliminaRigaToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.EliminaRigaToolStripMenuItem.Text = "Elimina Riga"
        '
        'LeggiRigaToolStripMenuItem
        '
        Me.LeggiRigaToolStripMenuItem.Name = "LeggiRigaToolStripMenuItem"
        Me.LeggiRigaToolStripMenuItem.Size = New System.Drawing.Size(139, 22)
        Me.LeggiRigaToolStripMenuItem.Text = "Leggi Riga"
        '
        'tbMappe
        '
        Me.tbMappe.AutoSize = False
        Me.tbMappe.BackColor = System.Drawing.Color.LightBlue
        Me.tbMappe.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tbMappe.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLeggi, Me.btnStop, Me.ToolStripLabel3, Me.btnF0, Me.btnF1, Me.btnF2, Me.btnF3, Me.btnF4, Me.ToolStripLabel29, Me.btnM1, Me.btnM2, Me.ToolStripLabel30, Me.btnAnnullaMappa, Me.ToolStripButton2, Me.ToolStripButton3, Me.ToolStripLabel1, Me.ToolStripButton1})
        Me.tbMappe.Location = New System.Drawing.Point(0, 0)
        Me.tbMappe.Name = "tbMappe"
        Me.tbMappe.Size = New System.Drawing.Size(1008, 39)
        Me.tbMappe.TabIndex = 91
        Me.tbMappe.Text = "ToolStrip2"
        '
        'btnLeggi
        '
        Me.btnLeggi.BackColor = System.Drawing.Color.Transparent
        Me.btnLeggi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLeggi.Image = CType(resources.GetObject("btnLeggi.Image"), System.Drawing.Image)
        Me.btnLeggi.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLeggi.Name = "btnLeggi"
        Me.btnLeggi.Size = New System.Drawing.Size(28, 36)
        Me.btnLeggi.Text = "Leggi"
        Me.btnLeggi.ToolTipText = " LEGGI "
        '
        'btnStop
        '
        Me.btnStop.BackColor = System.Drawing.Color.Transparent
        Me.btnStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnStop.Image = CType(resources.GetObject("btnStop.Image"), System.Drawing.Image)
        Me.btnStop.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(28, 36)
        Me.btnStop.Text = "Stop"
        Me.btnStop.ToolTipText = "Ferma la lettura"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(27, 36)
        Me.ToolStripLabel3.Text = " | "
        '
        'btnF0
        '
        Me.btnF0.Image = CType(resources.GetObject("btnF0.Image"), System.Drawing.Image)
        Me.btnF0.ImageTransparentColor = System.Drawing.Color.White
        Me.btnF0.Name = "btnF0"
        Me.btnF0.Size = New System.Drawing.Size(74, 36)
        Me.btnF0.Text = "Origine"
        Me.btnF0.ToolTipText = "F1 - Titolo"
        '
        'btnF1
        '
        Me.btnF1.Image = Global.LeggiXme.My.Resources.Resources.relaz
        Me.btnF1.ImageTransparentColor = System.Drawing.Color.White
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(62, 36)
        Me.btnF1.Text = "Relaz"
        Me.btnF1.ToolTipText = "Relazione"
        '
        'btnF2
        '
        Me.btnF2.Image = CType(resources.GetObject("btnF2.Image"), System.Drawing.Image)
        Me.btnF2.ImageTransparentColor = System.Drawing.Color.White
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(79, 36)
        Me.btnF2.Text = "Destinaz"
        Me.btnF2.ToolTipText = "Destinazione"
        '
        'btnF3
        '
        Me.btnF3.Image = Global.LeggiXme.My.Resources.Resources.annulla
        Me.btnF3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(78, 36)
        Me.btnF3.Text = "AZZERA"
        Me.btnF3.ToolTipText = "Azzera"
        '
        'btnF4
        '
        Me.btnF4.Image = CType(resources.GetObject("btnF4.Image"), System.Drawing.Image)
        Me.btnF4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(87, 36)
        Me.btnF4.Text = "Togli Sott."
        Me.btnF4.ToolTipText = "Togli sottolineatura"
        '
        'ToolStripLabel29
        '
        Me.ToolStripLabel29.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel29.Name = "ToolStripLabel29"
        Me.ToolStripLabel29.Size = New System.Drawing.Size(27, 36)
        Me.ToolStripLabel29.Text = " | "
        '
        'btnM1
        '
        Me.btnM1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnM1.Image = Global.LeggiXme.My.Resources.Resources.salva
        Me.btnM1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnM1.Name = "btnM1"
        Me.btnM1.Size = New System.Drawing.Size(62, 36)
        Me.btnM1.Text = "Salva"
        Me.btnM1.ToolTipText = "Salva Testo Preparato"
        '
        'btnM2
        '
        Me.btnM2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnM2.Image = Global.LeggiXme.My.Resources.Resources.Apri_
        Me.btnM2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnM2.Name = "btnM2"
        Me.btnM2.Size = New System.Drawing.Size(57, 36)
        Me.btnM2.Text = "Apri"
        Me.btnM2.ToolTipText = "Apri testo preparato"
        '
        'ToolStripLabel30
        '
        Me.ToolStripLabel30.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel30.Name = "ToolStripLabel30"
        Me.ToolStripLabel30.Size = New System.Drawing.Size(27, 36)
        Me.ToolStripLabel30.Text = " | "
        '
        'btnAnnullaMappa
        '
        Me.btnAnnullaMappa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAnnullaMappa.Image = CType(resources.GetObject("btnAnnullaMappa.Image"), System.Drawing.Image)
        Me.btnAnnullaMappa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnnullaMappa.Name = "btnAnnullaMappa"
        Me.btnAnnullaMappa.Size = New System.Drawing.Size(28, 36)
        Me.btnAnnullaMappa.Text = "Annulla Cancellazione"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton2.Image = Global.LeggiXme.My.Resources.Resources.zoom_1
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(28, 36)
        Me.ToolStripButton2.Text = "+"
        Me.ToolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.ToolStripButton2.ToolTipText = "zoom +"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton3.Image = Global.LeggiXme.My.Resources.Resources.zoom_
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(28, 36)
        Me.ToolStripButton3.Text = "-"
        Me.ToolStripButton3.ToolTipText = "zoom -"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(27, 36)
        Me.ToolStripLabel1.Text = " | "
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(67, 36)
        Me.ToolStripButton1.Text = "CMap"
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button9.BackgroundImage = Global.LeggiXme.My.Resources.Resources.home_tr
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.Location = New System.Drawing.Point(970, 2)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(34, 33)
        Me.Button9.TabIndex = 92
        Me.Button9.UseVisualStyleBackColor = True
        '
        'btnInvia
        '
        Me.btnInvia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInvia.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnInvia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInvia.Location = New System.Drawing.Point(834, 6)
        Me.btnInvia.Name = "btnInvia"
        Me.btnInvia.Size = New System.Drawing.Size(59, 29)
        Me.btnInvia.TabIndex = 93
        Me.btnInvia.Text = "++>>"
        Me.ToolTip1.SetToolTip(Me.btnInvia, "AGGIUNGI")
        Me.btnInvia.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightCyan
        Me.Panel1.BackgroundImage = Global.LeggiXme.My.Resources.Resources.ARW09DN
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.btnAnnulla)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Controls.Add(Me.ListBox1)
        Me.Panel1.Cursor = System.Windows.Forms.Cursors.SizeAll
        Me.Panel1.Location = New System.Drawing.Point(119, 121)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(250, 287)
        Me.Panel1.TabIndex = 94
        Me.Panel1.Visible = False
        '
        'btnAnnulla
        '
        Me.btnAnnulla.BackColor = System.Drawing.Color.PowderBlue
        Me.btnAnnulla.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnAnnulla.Location = New System.Drawing.Point(15, 256)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Size = New System.Drawing.Size(73, 25)
        Me.btnAnnulla.TabIndex = 3
        Me.btnAnnulla.Text = "ANNULLA"
        Me.btnAnnulla.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Label1.Location = New System.Drawing.Point(45, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(191, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "SCEGLI IL CONCETTO TRA QUESTI:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.Color.PowderBlue
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.btnOK.Location = New System.Drawing.Point(161, 256)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(73, 25)
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'ListBox1
        '
        Me.ListBox1.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(15, 39)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(221, 212)
        Me.ListBox1.TabIndex = 0
        '
        'frmCmap
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 589)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.RTB)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.btnInvia)
        Me.Controls.Add(Me.tbMappe)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCmap"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Prepara Testo per CMap"
        Me.AutoVerbMenu.ResumeLayout(False)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.DGmenu.ResumeLayout(False)
        Me.tbMappe.ResumeLayout(False)
        Me.tbMappe.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RTB As System.Windows.Forms.RichTextBox
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents AutoVerbMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Annulla As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Ripristina As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Taglia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Copia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Incolla_Tutto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DGmenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents EliminaRigaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tbMappe As System.Windows.Forms.ToolStrip
    Friend WithEvents btnF0 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnF1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnF2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnF3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnF4 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel29 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnM1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnM2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel30 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnAnnullaMappa As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel1 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnLeggi As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents btnInvia As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnAnnulla As System.Windows.Forms.Button
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LeggiRigaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton

End Class
