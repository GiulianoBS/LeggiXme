<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmINT
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmINT))
        Me.pnPDF = New System.Windows.Forms.Panel()
        Me.frIndirizzi = New System.Windows.Forms.GroupBox()
        Me.cmdHP = New System.Windows.Forms.Button()
        Me.cmdAggiungi = New System.Windows.Forms.Button()
        Me.cmdNaviga = New System.Windows.Forms.Button()
        Me.cmdElimina = New System.Windows.Forms.Button()
        Me.txtUrl = New System.Windows.Forms.TextBox()
        Me.cbUrl = New System.Windows.Forms.ListBox()
        Me.cmdFatto = New System.Windows.Forms.Button()
        Me.StatusBar1 = New System.Windows.Forms.StatusStrip()
        Me._StatusBar1_Panel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsIndietro = New System.Windows.Forms.ToolStripButton()
        Me.tsAvanti = New System.Windows.Forms.ToolStripButton()
        Me.tsTermina = New System.Windows.Forms.ToolStripButton()
        Me.tsRicarica = New System.Windows.Forms.ToolStripButton()
        Me.tsHome = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsPreferiti = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.tsImmagini = New System.Windows.Forms.ToolStripButton()
        Me.tsTesto = New System.Windows.Forms.ToolStripButton()
        Me.cmdVai = New System.Windows.Forms.Button()
        Me.CmbURL = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.WB = New System.Windows.Forms.WebBrowser()
        Me.pnComandi = New System.Windows.Forms.Panel()
        Me.lbLingua = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmdVoce = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.pnAllarga = New System.Windows.Forms.Panel()
        Me.btnAllarga = New System.Windows.Forms.Button()
        Me.btnStringi = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RTB = New System.Windows.Forms.RichTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ckTesto = New System.Windows.Forms.CheckBox()
        Me.ckFoto = New System.Windows.Forms.CheckBox()
        Me.btnTorna = New System.Windows.Forms.Button()
        Me.btnIncolla = New System.Windows.Forms.Button()
        Me.picComandi = New System.Windows.Forms.Panel()
        Me.cmdPausa = New System.Windows.Forms.Button()
        Me.cmdRipeti = New System.Windows.Forms.Button()
        Me.cmdLeggiVerde = New System.Windows.Forms.Button()
        Me.cmdImposta = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuVoci = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnPDF.SuspendLayout()
        Me.frIndirizzi.SuspendLayout()
        Me.StatusBar1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        Me.pnComandi.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.pnAllarga.SuspendLayout()
        Me.picComandi.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnPDF
        '
        Me.pnPDF.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnPDF.Controls.Add(Me.frIndirizzi)
        Me.pnPDF.Controls.Add(Me.StatusBar1)
        Me.pnPDF.Controls.Add(Me.ToolStrip1)
        Me.pnPDF.Controls.Add(Me.cmdVai)
        Me.pnPDF.Controls.Add(Me.CmbURL)
        Me.pnPDF.Controls.Add(Me.Label2)
        Me.pnPDF.Controls.Add(Me.WB)
        Me.pnPDF.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnPDF.Location = New System.Drawing.Point(0, 0)
        Me.pnPDF.Name = "pnPDF"
        Me.pnPDF.Size = New System.Drawing.Size(522, 522)
        Me.pnPDF.TabIndex = 0
        '
        'frIndirizzi
        '
        Me.frIndirizzi.BackColor = System.Drawing.SystemColors.Control
        Me.frIndirizzi.Controls.Add(Me.cmdHP)
        Me.frIndirizzi.Controls.Add(Me.cmdAggiungi)
        Me.frIndirizzi.Controls.Add(Me.cmdNaviga)
        Me.frIndirizzi.Controls.Add(Me.cmdElimina)
        Me.frIndirizzi.Controls.Add(Me.txtUrl)
        Me.frIndirizzi.Controls.Add(Me.cbUrl)
        Me.frIndirizzi.Controls.Add(Me.cmdFatto)
        Me.frIndirizzi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.frIndirizzi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.frIndirizzi.Location = New System.Drawing.Point(3, 25)
        Me.frIndirizzi.Name = "frIndirizzi"
        Me.frIndirizzi.Padding = New System.Windows.Forms.Padding(0)
        Me.frIndirizzi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.frIndirizzi.Size = New System.Drawing.Size(560, 191)
        Me.frIndirizzi.TabIndex = 24
        Me.frIndirizzi.TabStop = False
        Me.frIndirizzi.Text = "Preferiti  "
        Me.frIndirizzi.Visible = False
        '
        'cmdHP
        '
        Me.cmdHP.BackColor = System.Drawing.SystemColors.Control
        Me.cmdHP.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdHP.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdHP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdHP.Location = New System.Drawing.Point(165, 155)
        Me.cmdHP.Name = "cmdHP"
        Me.cmdHP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdHP.Size = New System.Drawing.Size(77, 26)
        Me.cmdHP.TabIndex = 19
        Me.cmdHP.Text = "Home Page"
        Me.cmdHP.UseVisualStyleBackColor = False
        '
        'cmdAggiungi
        '
        Me.cmdAggiungi.BackColor = System.Drawing.SystemColors.Control
        Me.cmdAggiungi.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdAggiungi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAggiungi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdAggiungi.Location = New System.Drawing.Point(92, 155)
        Me.cmdAggiungi.Name = "cmdAggiungi"
        Me.cmdAggiungi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdAggiungi.Size = New System.Drawing.Size(71, 26)
        Me.cmdAggiungi.TabIndex = 15
        Me.cmdAggiungi.Text = "Aggiungi"
        Me.cmdAggiungi.UseVisualStyleBackColor = False
        '
        'cmdNaviga
        '
        Me.cmdNaviga.BackColor = System.Drawing.SystemColors.Control
        Me.cmdNaviga.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdNaviga.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNaviga.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdNaviga.Location = New System.Drawing.Point(292, 154)
        Me.cmdNaviga.Name = "cmdNaviga"
        Me.cmdNaviga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdNaviga.Size = New System.Drawing.Size(86, 26)
        Me.cmdNaviga.TabIndex = 14
        Me.cmdNaviga.Text = "Naviga"
        Me.cmdNaviga.UseVisualStyleBackColor = False
        '
        'cmdElimina
        '
        Me.cmdElimina.BackColor = System.Drawing.SystemColors.Control
        Me.cmdElimina.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdElimina.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdElimina.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdElimina.Location = New System.Drawing.Point(15, 155)
        Me.cmdElimina.Name = "cmdElimina"
        Me.cmdElimina.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdElimina.Size = New System.Drawing.Size(76, 26)
        Me.cmdElimina.TabIndex = 13
        Me.cmdElimina.Text = "Elimina "
        Me.cmdElimina.UseVisualStyleBackColor = False
        '
        'txtUrl
        '
        Me.txtUrl.AcceptsReturn = True
        Me.txtUrl.BackColor = System.Drawing.SystemColors.Window
        Me.txtUrl.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtUrl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtUrl.Location = New System.Drawing.Point(15, 20)
        Me.txtUrl.MaxLength = 0
        Me.txtUrl.Name = "txtUrl"
        Me.txtUrl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUrl.Size = New System.Drawing.Size(466, 22)
        Me.txtUrl.TabIndex = 12
        '
        'cbUrl
        '
        Me.cbUrl.BackColor = System.Drawing.SystemColors.Window
        Me.cbUrl.Cursor = System.Windows.Forms.Cursors.Default
        Me.cbUrl.ForeColor = System.Drawing.SystemColors.WindowText
        Me.cbUrl.ItemHeight = 16
        Me.cbUrl.Location = New System.Drawing.Point(15, 50)
        Me.cbUrl.Name = "cbUrl"
        Me.cbUrl.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbUrl.Size = New System.Drawing.Size(466, 68)
        Me.cbUrl.TabIndex = 11
        '
        'cmdFatto
        '
        Me.cmdFatto.BackColor = System.Drawing.SystemColors.Control
        Me.cmdFatto.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdFatto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFatto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdFatto.Location = New System.Drawing.Point(410, 155)
        Me.cmdFatto.Name = "cmdFatto"
        Me.cmdFatto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdFatto.Size = New System.Drawing.Size(73, 25)
        Me.cmdFatto.TabIndex = 10
        Me.cmdFatto.Text = "Chiudi"
        Me.cmdFatto.UseVisualStyleBackColor = False
        '
        'StatusBar1
        '
        Me.StatusBar1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._StatusBar1_Panel1})
        Me.StatusBar1.Location = New System.Drawing.Point(0, 500)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Size = New System.Drawing.Size(522, 22)
        Me.StatusBar1.TabIndex = 23
        '
        '_StatusBar1_Panel1
        '
        Me._StatusBar1_Panel1.AutoSize = False
        Me._StatusBar1_Panel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me._StatusBar1_Panel1.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter
        Me._StatusBar1_Panel1.Margin = New System.Windows.Forms.Padding(0)
        Me._StatusBar1_Panel1.Name = "_StatusBar1_Panel1"
        Me._StatusBar1_Panel1.Size = New System.Drawing.Size(96, 22)
        Me._StatusBar1_Panel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsIndietro, Me.tsAvanti, Me.tsTermina, Me.tsRicarica, Me.tsHome, Me.ToolStripSeparator1, Me.tsPreferiti, Me.ToolStripSeparator2, Me.tsImmagini, Me.tsTesto})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(522, 25)
        Me.ToolStrip1.Stretch = True
        Me.ToolStrip1.TabIndex = 22
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsIndietro
        '
        Me.tsIndietro.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsIndietro.Image = CType(resources.GetObject("tsIndietro.Image"), System.Drawing.Image)
        Me.tsIndietro.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsIndietro.Name = "tsIndietro"
        Me.tsIndietro.Size = New System.Drawing.Size(23, 22)
        Me.tsIndietro.Text = " INDIETRO "
        '
        'tsAvanti
        '
        Me.tsAvanti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsAvanti.Image = CType(resources.GetObject("tsAvanti.Image"), System.Drawing.Image)
        Me.tsAvanti.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAvanti.Name = "tsAvanti"
        Me.tsAvanti.Size = New System.Drawing.Size(23, 22)
        Me.tsAvanti.Text = " AVANTI "
        '
        'tsTermina
        '
        Me.tsTermina.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsTermina.Image = CType(resources.GetObject("tsTermina.Image"), System.Drawing.Image)
        Me.tsTermina.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsTermina.Name = "tsTermina"
        Me.tsTermina.Size = New System.Drawing.Size(23, 22)
        Me.tsTermina.Text = "TERMINA "
        '
        'tsRicarica
        '
        Me.tsRicarica.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsRicarica.Image = CType(resources.GetObject("tsRicarica.Image"), System.Drawing.Image)
        Me.tsRicarica.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsRicarica.Name = "tsRicarica"
        Me.tsRicarica.Size = New System.Drawing.Size(23, 22)
        Me.tsRicarica.Text = "AGGIORNA "
        '
        'tsHome
        '
        Me.tsHome.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsHome.Image = CType(resources.GetObject("tsHome.Image"), System.Drawing.Image)
        Me.tsHome.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsHome.Name = "tsHome"
        Me.tsHome.Size = New System.Drawing.Size(23, 22)
        Me.tsHome.Text = " HOME "
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'tsPreferiti
        '
        Me.tsPreferiti.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsPreferiti.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsPreferiti.Image = CType(resources.GetObject("tsPreferiti.Image"), System.Drawing.Image)
        Me.tsPreferiti.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsPreferiti.Name = "tsPreferiti"
        Me.tsPreferiti.Size = New System.Drawing.Size(23, 22)
        Me.tsPreferiti.Text = "  PREFERITI  "
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'tsImmagini
        '
        Me.tsImmagini.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.tsImmagini.Image = CType(resources.GetObject("tsImmagini.Image"), System.Drawing.Image)
        Me.tsImmagini.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsImmagini.Name = "tsImmagini"
        Me.tsImmagini.Size = New System.Drawing.Size(23, 22)
        Me.tsImmagini.Text = " IMMAGINI "
        Me.tsImmagini.ToolTipText = " SALVA TUTTE LE IMMAGINI "
        Me.tsImmagini.Visible = False
        '
        'tsTesto
        '
        Me.tsTesto.AutoToolTip = False
        Me.tsTesto.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsTesto.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tsTesto.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsTesto.Name = "tsTesto"
        Me.tsTesto.Size = New System.Drawing.Size(23, 22)
        Me.tsTesto.Text = "T"
        Me.tsTesto.ToolTipText = " SALVA TUTTO IL TESTO "
        Me.tsTesto.Visible = False
        '
        'cmdVai
        '
        Me.cmdVai.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVai.AutoSize = True
        Me.cmdVai.BackColor = System.Drawing.SystemColors.Control
        Me.cmdVai.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmdVai.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdVai.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVai.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdVai.Location = New System.Drawing.Point(480, 25)
        Me.cmdVai.Name = "cmdVai"
        Me.cmdVai.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVai.Size = New System.Drawing.Size(41, 28)
        Me.cmdVai.TabIndex = 20
        Me.cmdVai.Text = "Vai"
        Me.cmdVai.UseVisualStyleBackColor = False
        '
        'CmbURL
        '
        Me.CmbURL.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmbURL.BackColor = System.Drawing.SystemColors.Window
        Me.CmbURL.Cursor = System.Windows.Forms.Cursors.Default
        Me.CmbURL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmbURL.ForeColor = System.Drawing.SystemColors.WindowText
        Me.CmbURL.Location = New System.Drawing.Point(57, 26)
        Me.CmbURL.Name = "CmbURL"
        Me.CmbURL.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmbURL.Size = New System.Drawing.Size(421, 24)
        Me.CmbURL.TabIndex = 19
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(1, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Label2.Size = New System.Drawing.Size(57, 17)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Indirizzo:"
        '
        'WB
        '
        Me.WB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.WB.Location = New System.Drawing.Point(3, 59)
        Me.WB.Name = "WB"
        Me.WB.ScriptErrorsSuppressed = True
        Me.WB.Size = New System.Drawing.Size(563, 438)
        Me.WB.TabIndex = 1
        '
        'pnComandi
        '
        Me.pnComandi.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.pnComandi.Controls.Add(Me.lbLingua)
        Me.pnComandi.Controls.Add(Me.Panel1)
        Me.pnComandi.Controls.Add(Me.cmdVoce)
        Me.pnComandi.Controls.Add(Me.Button2)
        Me.pnComandi.Controls.Add(Me.Button1)
        Me.pnComandi.Controls.Add(Me.pnAllarga)
        Me.pnComandi.Controls.Add(Me.RTB)
        Me.pnComandi.Controls.Add(Me.Label3)
        Me.pnComandi.Controls.Add(Me.ckTesto)
        Me.pnComandi.Controls.Add(Me.ckFoto)
        Me.pnComandi.Controls.Add(Me.btnTorna)
        Me.pnComandi.Controls.Add(Me.btnIncolla)
        Me.pnComandi.Controls.Add(Me.picComandi)
        Me.pnComandi.Controls.Add(Me.Label1)
        Me.pnComandi.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnComandi.Location = New System.Drawing.Point(569, 0)
        Me.pnComandi.Name = "pnComandi"
        Me.pnComandi.Size = New System.Drawing.Size(263, 522)
        Me.pnComandi.TabIndex = 1
        '
        'lbLingua
        '
        Me.lbLingua.AutoSize = True
        Me.lbLingua.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLingua.Location = New System.Drawing.Point(146, 263)
        Me.lbLingua.Name = "lbLingua"
        Me.lbLingua.Size = New System.Drawing.Size(57, 16)
        Me.lbLingua.TabIndex = 120
        Me.lbLingua.Text = "LINGUA"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(15, 124)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(243, 34)
        Me.Panel1.TabIndex = 119
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackColor = System.Drawing.Color.Crimson
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(8, 1)
        Me.Button3.Name = "Button3"
        Me.Button3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button3.Size = New System.Drawing.Size(55, 33)
        Me.Button3.TabIndex = 83
        Me.Button3.Text = "+"
        Me.ToolTip1.SetToolTip(Me.Button3, " ALLARGA PANNELLO ")
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button4.BackColor = System.Drawing.Color.Crimson
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ForeColor = System.Drawing.Color.White
        Me.Button4.Location = New System.Drawing.Point(183, -1)
        Me.Button4.Name = "Button4"
        Me.Button4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button4.Size = New System.Drawing.Size(51, 33)
        Me.Button4.TabIndex = 84
        Me.Button4.Text = "-"
        Me.ToolTip1.SetToolTip(Me.Button4, " RESTRINGI PANNELLO ")
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(226, 34)
        Me.Label5.TabIndex = 89
        Me.Label5.Text = "GRANDEZZA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DELLE IMMAGINI"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdVoce
        '
        Me.cmdVoce.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVoce.BackColor = System.Drawing.Color.Transparent
        Me.cmdVoce.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdVoce.Font = New System.Drawing.Font("Courier New", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVoce.ForeColor = System.Drawing.Color.White
        Me.cmdVoce.Image = Global.LeggiXme.My.Resources.Resources.BandIta
        Me.cmdVoce.Location = New System.Drawing.Point(80, 248)
        Me.cmdVoce.Name = "cmdVoce"
        Me.cmdVoce.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVoce.Size = New System.Drawing.Size(40, 40)
        Me.cmdVoce.TabIndex = 118
        Me.cmdVoce.Tag = "SCEGLI LINGUA"
        Me.cmdVoce.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.cmdVoce, "SCEGLI LINGUA")
        Me.cmdVoce.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.Location = New System.Drawing.Point(175, 41)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(26, 27)
        Me.Button2.TabIndex = 117
        Me.Button2.Text = "-"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(175, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(26, 27)
        Me.Button1.TabIndex = 116
        Me.Button1.Text = "+"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'pnAllarga
        '
        Me.pnAllarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnAllarga.BackColor = System.Drawing.Color.Transparent
        Me.pnAllarga.Controls.Add(Me.btnAllarga)
        Me.pnAllarga.Controls.Add(Me.btnStringi)
        Me.pnAllarga.Controls.Add(Me.Label4)
        Me.pnAllarga.Location = New System.Drawing.Point(17, 83)
        Me.pnAllarga.Name = "pnAllarga"
        Me.pnAllarga.Size = New System.Drawing.Size(243, 34)
        Me.pnAllarga.TabIndex = 115
        '
        'btnAllarga
        '
        Me.btnAllarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAllarga.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAllarga.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAllarga.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAllarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllarga.ForeColor = System.Drawing.Color.White
        Me.btnAllarga.Location = New System.Drawing.Point(8, 1)
        Me.btnAllarga.Name = "btnAllarga"
        Me.btnAllarga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAllarga.Size = New System.Drawing.Size(55, 33)
        Me.btnAllarga.TabIndex = 83
        Me.btnAllarga.Text = "+"
        Me.ToolTip1.SetToolTip(Me.btnAllarga, " ALLARGA PANNELLO ")
        Me.btnAllarga.UseVisualStyleBackColor = False
        '
        'btnStringi
        '
        Me.btnStringi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStringi.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnStringi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStringi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnStringi.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStringi.ForeColor = System.Drawing.Color.White
        Me.btnStringi.Location = New System.Drawing.Point(183, -1)
        Me.btnStringi.Name = "btnStringi"
        Me.btnStringi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnStringi.Size = New System.Drawing.Size(51, 33)
        Me.btnStringi.TabIndex = 84
        Me.btnStringi.Text = "-"
        Me.ToolTip1.SetToolTip(Me.btnStringi, " RESTRINGI PANNELLO ")
        Me.btnStringi.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(12, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(226, 34)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "LARGHEZZA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DELLA FINESTRA"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RTB
        '
        Me.RTB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RTB.HideSelection = False
        Me.RTB.Location = New System.Drawing.Point(3, 305)
        Me.RTB.Name = "RTB"
        Me.RTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.RTB.Size = New System.Drawing.Size(260, 214)
        Me.RTB.TabIndex = 99
        Me.RTB.Text = ""
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 265)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 16)
        Me.Label3.TabIndex = 95
        Me.Label3.Text = "VOCE: "
        '
        'ckTesto
        '
        Me.ckTesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckTesto.AutoSize = True
        Me.ckTesto.Image = CType(resources.GetObject("ckTesto.Image"), System.Drawing.Image)
        Me.ckTesto.Location = New System.Drawing.Point(46, 45)
        Me.ckTesto.Name = "ckTesto"
        Me.ckTesto.Size = New System.Drawing.Size(47, 32)
        Me.ckTesto.TabIndex = 85
        Me.ckTesto.UseVisualStyleBackColor = True
        '
        'ckFoto
        '
        Me.ckFoto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckFoto.AutoSize = True
        Me.ckFoto.Image = CType(resources.GetObject("ckFoto.Image"), System.Drawing.Image)
        Me.ckFoto.Location = New System.Drawing.Point(46, 11)
        Me.ckFoto.Name = "ckFoto"
        Me.ckFoto.Size = New System.Drawing.Size(47, 32)
        Me.ckFoto.TabIndex = 84
        Me.ckFoto.UseVisualStyleBackColor = True
        '
        'btnTorna
        '
        Me.btnTorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTorna.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnTorna.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTorna.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTorna.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTorna.Image = Global.LeggiXme.My.Resources.Resources.home
        Me.btnTorna.Location = New System.Drawing.Point(211, 10)
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
        Me.btnIncolla.Location = New System.Drawing.Point(103, 21)
        Me.btnIncolla.Name = "btnIncolla"
        Me.btnIncolla.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIncolla.Size = New System.Drawing.Size(40, 40)
        Me.btnIncolla.TabIndex = 81
        Me.btnIncolla.UseVisualStyleBackColor = False
        '
        'picComandi
        '
        Me.picComandi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picComandi.BackColor = System.Drawing.Color.DodgerBlue
        Me.picComandi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picComandi.Controls.Add(Me.cmdPausa)
        Me.picComandi.Controls.Add(Me.cmdRipeti)
        Me.picComandi.Controls.Add(Me.cmdLeggiVerde)
        Me.picComandi.Controls.Add(Me.cmdImposta)
        Me.picComandi.Controls.Add(Me.cmdStop)
        Me.picComandi.Cursor = System.Windows.Forms.Cursors.Default
        Me.picComandi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picComandi.Location = New System.Drawing.Point(61, 180)
        Me.picComandi.Name = "picComandi"
        Me.picComandi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picComandi.Size = New System.Drawing.Size(157, 42)
        Me.picComandi.TabIndex = 78
        Me.picComandi.TabStop = True
        '
        'cmdPausa
        '
        Me.cmdPausa.BackColor = System.Drawing.Color.Transparent
        Me.cmdPausa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPausa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPausa.Image = Global.LeggiXme.My.Resources.Resources.pausa
        Me.cmdPausa.Location = New System.Drawing.Point(77, 0)
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
        'cmdLeggiVerde
        '
        Me.cmdLeggiVerde.BackColor = System.Drawing.Color.Transparent
        Me.cmdLeggiVerde.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdLeggiVerde.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLeggiVerde.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeggiVerde.Image = Global.LeggiXme.My.Resources.Resources.play
        Me.cmdLeggiVerde.Location = New System.Drawing.Point(1, 0)
        Me.cmdLeggiVerde.Name = "cmdLeggiVerde"
        Me.cmdLeggiVerde.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeggiVerde.Size = New System.Drawing.Size(40, 40)
        Me.cmdLeggiVerde.TabIndex = 15
        Me.cmdLeggiVerde.UseVisualStyleBackColor = False
        '
        'cmdImposta
        '
        Me.cmdImposta.BackColor = System.Drawing.Color.Transparent
        Me.cmdImposta.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdImposta.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdImposta.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdImposta.Image = CType(resources.GetObject("cmdImposta.Image"), System.Drawing.Image)
        Me.cmdImposta.Location = New System.Drawing.Point(115, 0)
        Me.cmdImposta.Name = "cmdImposta"
        Me.cmdImposta.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdImposta.Size = New System.Drawing.Size(40, 40)
        Me.cmdImposta.TabIndex = 14
        Me.cmdImposta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdImposta.UseVisualStyleBackColor = False
        '
        'cmdStop
        '
        Me.cmdStop.BackColor = System.Drawing.Color.Transparent
        Me.cmdStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStop.Image = Global.LeggiXme.My.Resources.Resources._stop
        Me.cmdStop.Location = New System.Drawing.Point(39, 0)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStop.Size = New System.Drawing.Size(40, 40)
        Me.cmdStop.TabIndex = 13
        Me.cmdStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdStop.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(32, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 74)
        Me.Label1.TabIndex = 86
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Timer2
        '
        Me.Timer2.Interval = 2000
        '
        'MenuVoci
        '
        Me.MenuVoci.ImageScalingSize = New System.Drawing.Size(24, 16)
        Me.MenuVoci.Name = "MenuVoci"
        Me.MenuVoci.Size = New System.Drawing.Size(61, 4)
        '
        'frmINT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(832, 522)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnComandi)
        Me.Controls.Add(Me.pnPDF)
        Me.MaximizeBox = False
        Me.Name = "frmINT"
        Me.Text = "LeggiXme - Naviga in Internet"
        Me.pnPDF.ResumeLayout(False)
        Me.pnPDF.PerformLayout()
        Me.frIndirizzi.ResumeLayout(False)
        Me.frIndirizzi.PerformLayout()
        Me.StatusBar1.ResumeLayout(False)
        Me.StatusBar1.PerformLayout()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.pnComandi.ResumeLayout(False)
        Me.pnComandi.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.pnAllarga.ResumeLayout(False)
        Me.picComandi.ResumeLayout(False)
        Me.ResumeLayout(False)

End Sub
    Friend WithEvents pnPDF As System.Windows.Forms.Panel
    Friend WithEvents pnComandi As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents picComandi As System.Windows.Forms.Panel
    Public WithEvents cmdPausa As System.Windows.Forms.Button
    Public WithEvents cmdRipeti As System.Windows.Forms.Button
    Friend WithEvents cmdLeggiVerde As System.Windows.Forms.Button
    Public WithEvents cmdImposta As System.Windows.Forms.Button
    Public WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents btnIncolla As System.Windows.Forms.Button
    Friend WithEvents btnTorna As System.Windows.Forms.Button
    Friend WithEvents ckFoto As System.Windows.Forms.CheckBox
    Friend WithEvents ckTesto As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Public WithEvents WB As System.Windows.Forms.WebBrowser
    Public WithEvents cmdVai As System.Windows.Forms.Button
    Public WithEvents CmbURL As System.Windows.Forms.ComboBox
    Public WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsIndietro As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsAvanti As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsTermina As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsRicarica As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsHome As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsPreferiti As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents tsImmagini As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsTesto As System.Windows.Forms.ToolStripButton
    Public WithEvents StatusBar1 As System.Windows.Forms.StatusStrip
    Public WithEvents _StatusBar1_Panel1 As System.Windows.Forms.ToolStripStatusLabel
    Public WithEvents frIndirizzi As System.Windows.Forms.GroupBox
    Public WithEvents cmdHP As System.Windows.Forms.Button
    Public WithEvents cmdAggiungi As System.Windows.Forms.Button
    Public WithEvents cmdNaviga As System.Windows.Forms.Button
    Public WithEvents cmdElimina As System.Windows.Forms.Button
    Public WithEvents txtUrl As System.Windows.Forms.TextBox
    Public WithEvents cbUrl As System.Windows.Forms.ListBox
    Public WithEvents cmdFatto As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents RTB As System.Windows.Forms.RichTextBox
    Friend WithEvents pnAllarga As System.Windows.Forms.Panel
    Friend WithEvents btnAllarga As System.Windows.Forms.Button
    Friend WithEvents btnStringi As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Public WithEvents cmdVoce As System.Windows.Forms.Button
    Friend WithEvents MenuVoci As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lbLingua As System.Windows.Forms.Label
    'Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
End Class
