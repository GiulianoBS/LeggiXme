<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMMaple
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMMaple))
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
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.ScambiaLineeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ScambiaLineeSuToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbMappe = New System.Windows.Forms.ToolStrip()
        Me.btnLeggi = New System.Windows.Forms.ToolStripButton()
        Me.btnStop = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel3 = New System.Windows.Forms.ToolStripLabel()
        Me.btnF0 = New System.Windows.Forms.ToolStripButton()
        Me.btnF1 = New System.Windows.Forms.ToolStripButton()
        Me.btnF2 = New System.Windows.Forms.ToolStripButton()
        Me.btnF3 = New System.Windows.Forms.ToolStripButton()
        Me.btnF4 = New System.Windows.Forms.ToolStripButton()
        Me.btnF5 = New System.Windows.Forms.ToolStripButton()
        Me.btnF10 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel29 = New System.Windows.Forms.ToolStripLabel()
        Me.btnM1 = New System.Windows.Forms.ToolStripButton()
        Me.btnM2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel30 = New System.Windows.Forms.ToolStripLabel()
        Me.btnAnnullaMappa = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton3 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel1 = New System.Windows.Forms.ToolStripLabel()
        Me.btnSalva = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel2 = New System.Windows.Forms.ToolStripLabel()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.btnCancella = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel4 = New System.Windows.Forms.ToolStripLabel()
        Me.btnControlla = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripLabel5 = New System.Windows.Forms.ToolStripLabel()
        Me.btnZoomPiu = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomMeno = New System.Windows.Forms.ToolStripButton()
        Me.btnZoomVia = New System.Windows.Forms.ToolStripButton()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RTB1 = New System.Windows.Forms.RichTextBox()
        Me.ToolStripButton4 = New System.Windows.Forms.ToolStripButton()
        Me.AutoVerbMenu.SuspendLayout()
        Me.tbMappe.SuspendLayout()
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
        Me.RTB.Location = New System.Drawing.Point(0, 52)
        Me.RTB.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RTB.Name = "RTB"
        Me.RTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical
        Me.RTB.Size = New System.Drawing.Size(1436, 643)
        Me.RTB.TabIndex = 0
        Me.RTB.Text = ""
        '
        'AutoVerbMenu
        '
        Me.AutoVerbMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.Annulla, Me.Ripristina, Me.ToolStripSeparator1, Me.Taglia, Me.ToolStripSeparator2, Me.Copia, Me.ToolStripSeparator3, Me.Incolla_Tutto, Me.ToolStripSeparator4, Me.ScambiaLineeToolStripMenuItem, Me.ScambiaLineeSuToolStripMenuItem})
        Me.AutoVerbMenu.Name = "AutoVerbMenu"
        Me.AutoVerbMenu.ShowImageMargin = False
        Me.AutoVerbMenu.Size = New System.Drawing.Size(228, 196)
        '
        'Annulla
        '
        Me.Annulla.Name = "Annulla"
        Me.Annulla.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Z), System.Windows.Forms.Keys)
        Me.Annulla.Size = New System.Drawing.Size(227, 24)
        Me.Annulla.Text = "Annulla"
        '
        'Ripristina
        '
        Me.Ripristina.Name = "Ripristina"
        Me.Ripristina.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.Ripristina.Size = New System.Drawing.Size(227, 24)
        Me.Ripristina.Text = "Ripristina"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(224, 6)
        '
        'Taglia
        '
        Me.Taglia.Name = "Taglia"
        Me.Taglia.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.Taglia.Size = New System.Drawing.Size(227, 24)
        Me.Taglia.Text = "Taglia"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(224, 6)
        '
        'Copia
        '
        Me.Copia.Name = "Copia"
        Me.Copia.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.C), System.Windows.Forms.Keys)
        Me.Copia.Size = New System.Drawing.Size(227, 24)
        Me.Copia.Text = "Copia"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(224, 6)
        '
        'Incolla_Tutto
        '
        Me.Incolla_Tutto.Name = "Incolla_Tutto"
        Me.Incolla_Tutto.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.V), System.Windows.Forms.Keys)
        Me.Incolla_Tutto.Size = New System.Drawing.Size(227, 24)
        Me.Incolla_Tutto.Text = "Incolla"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(224, 6)
        '
        'ScambiaLineeToolStripMenuItem
        '
        Me.ScambiaLineeToolStripMenuItem.Name = "ScambiaLineeToolStripMenuItem"
        Me.ScambiaLineeToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.X), System.Windows.Forms.Keys)
        Me.ScambiaLineeToolStripMenuItem.Size = New System.Drawing.Size(227, 24)
        Me.ScambiaLineeToolStripMenuItem.Text = "Scambia Linee Giu"
        '
        'ScambiaLineeSuToolStripMenuItem
        '
        Me.ScambiaLineeSuToolStripMenuItem.Name = "ScambiaLineeSuToolStripMenuItem"
        Me.ScambiaLineeSuToolStripMenuItem.ShortcutKeys = CType((System.Windows.Forms.Keys.Alt Or System.Windows.Forms.Keys.Y), System.Windows.Forms.Keys)
        Me.ScambiaLineeSuToolStripMenuItem.Size = New System.Drawing.Size(227, 24)
        Me.ScambiaLineeSuToolStripMenuItem.Text = "Scambia Linee Su"
        Me.ScambiaLineeSuToolStripMenuItem.ToolTipText = "Scambia Linee Su"
        '
        'tbMappe
        '
        Me.tbMappe.AutoSize = False
        Me.tbMappe.BackColor = System.Drawing.Color.LightBlue
        Me.tbMappe.ImageScalingSize = New System.Drawing.Size(24, 24)
        Me.tbMappe.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLeggi, Me.btnStop, Me.ToolStripLabel3, Me.btnF0, Me.btnF1, Me.btnF2, Me.btnF3, Me.btnF4, Me.btnF5, Me.btnF10, Me.ToolStripLabel29, Me.btnM1, Me.btnM2, Me.ToolStripLabel30, Me.btnAnnullaMappa, Me.ToolStripButton3, Me.ToolStripButton2, Me.ToolStripLabel1, Me.btnSalva, Me.ToolStripButton4, Me.ToolStripLabel2, Me.ToolStripButton1, Me.btnCancella, Me.ToolStripLabel4, Me.btnControlla, Me.ToolStripLabel5, Me.btnZoomPiu, Me.btnZoomMeno, Me.btnZoomVia})
        Me.tbMappe.Location = New System.Drawing.Point(0, 0)
        Me.tbMappe.Name = "tbMappe"
        Me.tbMappe.Size = New System.Drawing.Size(1437, 48)
        Me.tbMappe.TabIndex = 88
        Me.tbMappe.Text = "ToolStrip2"
        '
        'btnLeggi
        '
        Me.btnLeggi.BackColor = System.Drawing.Color.Transparent
        Me.btnLeggi.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnLeggi.ForeColor = System.Drawing.Color.LightSeaGreen
        Me.btnLeggi.Image = CType(resources.GetObject("btnLeggi.Image"), System.Drawing.Image)
        Me.btnLeggi.ImageTransparentColor = System.Drawing.Color.DarkOrchid
        Me.btnLeggi.Name = "btnLeggi"
        Me.btnLeggi.Size = New System.Drawing.Size(28, 45)
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
        Me.btnStop.Size = New System.Drawing.Size(28, 45)
        Me.btnStop.Text = "Stop"
        Me.btnStop.ToolTipText = "Ferma la lettura"
        '
        'ToolStripLabel3
        '
        Me.ToolStripLabel3.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel3.Name = "ToolStripLabel3"
        Me.ToolStripLabel3.Size = New System.Drawing.Size(35, 45)
        Me.ToolStripLabel3.Text = " | "
        '
        'btnF0
        '
        Me.btnF0.Image = CType(resources.GetObject("btnF0.Image"), System.Drawing.Image)
        Me.btnF0.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnF0.Name = "btnF0"
        Me.btnF0.Size = New System.Drawing.Size(52, 45)
        Me.btnF0.Text = "F1"
        Me.btnF0.ToolTipText = "F1 - Titolo"
        '
        'btnF1
        '
        Me.btnF1.Image = CType(resources.GetObject("btnF1.Image"), System.Drawing.Image)
        Me.btnF1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnF1.Name = "btnF1"
        Me.btnF1.Size = New System.Drawing.Size(52, 45)
        Me.btnF1.Text = "F2"
        Me.btnF1.ToolTipText = "F2 - Nodo 1° livello"
        '
        'btnF2
        '
        Me.btnF2.Image = CType(resources.GetObject("btnF2.Image"), System.Drawing.Image)
        Me.btnF2.ImageTransparentColor = System.Drawing.Color.Pink
        Me.btnF2.Name = "btnF2"
        Me.btnF2.Size = New System.Drawing.Size(52, 45)
        Me.btnF2.Text = "F3"
        Me.btnF2.ToolTipText = "F3 - Nodo 2° livello"
        '
        'btnF3
        '
        Me.btnF3.Image = CType(resources.GetObject("btnF3.Image"), System.Drawing.Image)
        Me.btnF3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnF3.Name = "btnF3"
        Me.btnF3.Size = New System.Drawing.Size(52, 45)
        Me.btnF3.Text = "F4"
        Me.btnF3.ToolTipText = "F4 - Nodo 3° livello"
        '
        'btnF4
        '
        Me.btnF4.Image = CType(resources.GetObject("btnF4.Image"), System.Drawing.Image)
        Me.btnF4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnF4.Name = "btnF4"
        Me.btnF4.Size = New System.Drawing.Size(52, 45)
        Me.btnF4.Text = "F5"
        Me.btnF4.ToolTipText = "F5 - nodo 4° livello"
        '
        'btnF5
        '
        Me.btnF5.Image = CType(resources.GetObject("btnF5.Image"), System.Drawing.Image)
        Me.btnF5.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnF5.Name = "btnF5"
        Me.btnF5.Size = New System.Drawing.Size(52, 45)
        Me.btnF5.Text = "F6"
        Me.btnF5.ToolTipText = "F5 - nodo 4° livello"
        '
        'btnF10
        '
        Me.btnF10.Font = New System.Drawing.Font("Segoe UI", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnF10.ForeColor = System.Drawing.Color.Red
        Me.btnF10.Image = CType(resources.GetObject("btnF10.Image"), System.Drawing.Image)
        Me.btnF10.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnF10.Name = "btnF10"
        Me.btnF10.Size = New System.Drawing.Size(46, 45)
        Me.btnF10.Text = "X"
        Me.btnF10.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay
        Me.btnF10.ToolTipText = "TOGLI EVIDENZIATO"
        '
        'ToolStripLabel29
        '
        Me.ToolStripLabel29.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel29.Name = "ToolStripLabel29"
        Me.ToolStripLabel29.Size = New System.Drawing.Size(35, 45)
        Me.ToolStripLabel29.Text = " | "
        '
        'btnM1
        '
        Me.btnM1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnM1.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnM1.Image = CType(resources.GetObject("btnM1.Image"), System.Drawing.Image)
        Me.btnM1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnM1.Name = "btnM1"
        Me.btnM1.Size = New System.Drawing.Size(36, 45)
        Me.btnM1.Text = "M1"
        Me.btnM1.ToolTipText = "Prepara la Mappa "
        '
        'btnM2
        '
        Me.btnM2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.btnM2.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnM2.Image = CType(resources.GetObject("btnM2.Image"), System.Drawing.Image)
        Me.btnM2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnM2.Name = "btnM2"
        Me.btnM2.Size = New System.Drawing.Size(36, 45)
        Me.btnM2.Text = "M2"
        Me.btnM2.ToolTipText = "Crea la Mappa"
        '
        'ToolStripLabel30
        '
        Me.ToolStripLabel30.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel30.Name = "ToolStripLabel30"
        Me.ToolStripLabel30.Size = New System.Drawing.Size(35, 45)
        Me.ToolStripLabel30.Text = " | "
        '
        'btnAnnullaMappa
        '
        Me.btnAnnullaMappa.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnAnnullaMappa.Image = CType(resources.GetObject("btnAnnullaMappa.Image"), System.Drawing.Image)
        Me.btnAnnullaMappa.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAnnullaMappa.Name = "btnAnnullaMappa"
        Me.btnAnnullaMappa.Size = New System.Drawing.Size(28, 45)
        Me.btnAnnullaMappa.Text = "Annulla Cancellazione"
        '
        'ToolStripButton3
        '
        Me.ToolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton3.Image = CType(resources.GetObject("ToolStripButton3.Image"), System.Drawing.Image)
        Me.ToolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton3.Name = "ToolStripButton3"
        Me.ToolStripButton3.Size = New System.Drawing.Size(28, 45)
        Me.ToolStripButton3.Text = "ScambiaLineeGiu"
        Me.ToolStripButton3.ToolTipText = "Scambia con la riga successiva"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(28, 45)
        Me.ToolStripButton2.Text = "ScambiaLineeSu"
        Me.ToolStripButton2.ToolTipText = "Scambia con la riga precedente"
        '
        'ToolStripLabel1
        '
        Me.ToolStripLabel1.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel1.Name = "ToolStripLabel1"
        Me.ToolStripLabel1.Size = New System.Drawing.Size(35, 45)
        Me.ToolStripLabel1.Text = " | "
        '
        'btnSalva
        '
        Me.btnSalva.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnSalva.Image = Global.LeggiXme.My.Resources.Resources.salva
        Me.btnSalva.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(28, 45)
        Me.btnSalva.Text = "ToolStripButton1"
        '
        'ToolStripLabel2
        '
        Me.ToolStripLabel2.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel2.Name = "ToolStripLabel2"
        Me.ToolStripLabel2.Size = New System.Drawing.Size(35, 45)
        Me.ToolStripLabel2.Text = " | "
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(54, 45)
        Me.ToolStripButton1.Text = "--->"
        '
        'btnCancella
        '
        Me.btnCancella.Image = Global.LeggiXme.My.Resources.Resources.gomma
        Me.btnCancella.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnCancella.Name = "btnCancella"
        Me.btnCancella.Size = New System.Drawing.Size(28, 45)
        Me.btnCancella.ToolTipText = "Togli freccia"
        '
        'ToolStripLabel4
        '
        Me.ToolStripLabel4.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel4.Name = "ToolStripLabel4"
        Me.ToolStripLabel4.Size = New System.Drawing.Size(35, 45)
        Me.ToolStripLabel4.Text = " | "
        '
        'btnControlla
        '
        Me.btnControlla.BackColor = System.Drawing.Color.Transparent
        Me.btnControlla.BackgroundImage = Global.LeggiXme.My.Resources.Resources.occhio_
        Me.btnControlla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnControlla.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnControlla.Enabled = False
        Me.btnControlla.Image = Global.LeggiXme.My.Resources.Resources.occhio_
        Me.btnControlla.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnControlla.Name = "btnControlla"
        Me.btnControlla.Size = New System.Drawing.Size(28, 45)
        Me.btnControlla.Text = "Controlla"
        '
        'ToolStripLabel5
        '
        Me.ToolStripLabel5.Font = New System.Drawing.Font("Segoe UI", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripLabel5.Name = "ToolStripLabel5"
        Me.ToolStripLabel5.Size = New System.Drawing.Size(35, 45)
        Me.ToolStripLabel5.Text = " | "
        '
        'btnZoomPiu
        '
        Me.btnZoomPiu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomPiu.Image = Global.LeggiXme.My.Resources.Resources.zoom_1
        Me.btnZoomPiu.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoomPiu.Name = "btnZoomPiu"
        Me.btnZoomPiu.Size = New System.Drawing.Size(28, 45)
        Me.btnZoomPiu.Text = "Aumenta Zoom"
        '
        'btnZoomMeno
        '
        Me.btnZoomMeno.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomMeno.Image = Global.LeggiXme.My.Resources.Resources.zoom_
        Me.btnZoomMeno.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoomMeno.Name = "btnZoomMeno"
        Me.btnZoomMeno.Size = New System.Drawing.Size(28, 45)
        Me.btnZoomMeno.Text = "Diminuisci Zoom"
        '
        'btnZoomVia
        '
        Me.btnZoomVia.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.btnZoomVia.Image = Global.LeggiXme.My.Resources.Resources.zoomvia
        Me.btnZoomVia.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnZoomVia.Name = "btnZoomVia"
        Me.btnZoomVia.Size = New System.Drawing.Size(28, 45)
        Me.btnZoomVia.Text = "Annulla Zoom"
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = Global.LeggiXme.My.Resources.Resources.home_tr
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(1387, 2)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(47, 41)
        Me.Button1.TabIndex = 89
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RTB1
        '
        Me.RTB1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RTB1.Location = New System.Drawing.Point(721, 52)
        Me.RTB1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.RTB1.Name = "RTB1"
        Me.RTB1.Size = New System.Drawing.Size(713, 655)
        Me.RTB1.TabIndex = 90
        Me.RTB1.Text = ""
        Me.RTB1.Visible = False
        '
        'ToolStripButton4
        '
        Me.ToolStripButton4.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToolStripButton4.Image = Global.LeggiXme.My.Resources.Resources.Apri_
        Me.ToolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton4.Name = "ToolStripButton4"
        Me.ToolStripButton4.Size = New System.Drawing.Size(28, 45)
        Me.ToolStripButton4.ToolTipText = "Apri testo preparato"
        '
        'frmMMaple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1437, 709)
        Me.Controls.Add(Me.RTB1)
        Me.Controls.Add(Me.RTB)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.tbMappe)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "frmMMaple"
        Me.Text = "Prepara Mappa per Mind Maple"
        Me.AutoVerbMenu.ResumeLayout(False)
        Me.tbMappe.ResumeLayout(False)
        Me.tbMappe.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RTB As System.Windows.Forms.RichTextBox
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
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents AutoVerbMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents Annulla As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Ripristina As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Taglia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Copia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents Incolla_Tutto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSalva As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel2 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnLeggi As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnStop As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel3 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents RTB1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolStripLabel4 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnControlla As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripLabel5 As System.Windows.Forms.ToolStripLabel
    Friend WithEvents btnZoomPiu As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnZoomMeno As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnZoomVia As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnF10 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnF5 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnCancella As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ScambiaLineeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton3 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ScambiaLineeSuToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripButton4 As System.Windows.Forms.ToolStripButton

End Class
