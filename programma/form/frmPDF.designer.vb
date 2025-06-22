<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPDF
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPDF))
        Me.pnPDF = New System.Windows.Forms.Panel()
        Me.LabelImpedisciResizing = New System.Windows.Forms.Label()
        Me.pnAllarga = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnZoomVia = New System.Windows.Forms.Button()
        Me.btnZoomPiu = New System.Windows.Forms.Button()
        Me.btnZoomMeno = New System.Windows.Forms.Button()
        Me.btnChiudiAllarga = New System.Windows.Forms.Button()
        Me.btnStringi = New System.Windows.Forms.Button()
        Me.btnAllarga = New System.Windows.Forms.Button()
        Me.pnComandi = New System.Windows.Forms.Panel()
        Me.cmdVoce = New System.Windows.Forms.Button()
        Me.pnEstraiPDF = New System.Windows.Forms.Panel()
        Me.lblFile = New System.Windows.Forms.Label()
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.btnSalvaApri = New System.Windows.Forms.Button()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txPagg = New System.Windows.Forms.TextBox()
        Me.picComandi = New System.Windows.Forms.Panel()
        Me.cmdPausa = New System.Windows.Forms.Button()
        Me.cmdRipeti = New System.Windows.Forms.Button()
        Me.cmdLeggiVerde = New System.Windows.Forms.Button()
        Me.cmdApri = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.RTB = New System.Windows.Forms.RichTextBox()
        Me.btnEstrai = New System.Windows.Forms.Button()
        Me.btnSproteggi = New System.Windows.Forms.Button()
        Me.btnOpzioniVisualizzazione = New System.Windows.Forms.Button()
        Me.lbLingua = New System.Windows.Forms.Label()
        Me.ckTesto = New System.Windows.Forms.CheckBox()
        Me.ckFoto = New System.Windows.Forms.CheckBox()
        Me.btnTorna = New System.Windows.Forms.Button()
        Me.btnIncolla = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.trVelocita = New System.Windows.Forms.TrackBar()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tmrPDF = New System.Windows.Forms.Timer(Me.components)
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.MenuVoci = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.pnPDF.SuspendLayout()
        Me.pnAllarga.SuspendLayout()
        Me.pnComandi.SuspendLayout()
        Me.pnEstraiPDF.SuspendLayout()
        Me.picComandi.SuspendLayout()
        CType(Me.trVelocita, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnPDF
        '
        Me.pnPDF.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnPDF.Controls.Add(Me.LabelImpedisciResizing)
        Me.pnPDF.Dock = System.Windows.Forms.DockStyle.Left
        Me.pnPDF.Location = New System.Drawing.Point(0, 0)
        Me.pnPDF.Name = "pnPDF"
        Me.pnPDF.Size = New System.Drawing.Size(535, 635)
        Me.pnPDF.TabIndex = 0
        '
        'LabelImpedisciResizing
        '
        Me.LabelImpedisciResizing.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelImpedisciResizing.BackColor = System.Drawing.Color.Transparent
        Me.LabelImpedisciResizing.Location = New System.Drawing.Point(503, 610)
        Me.LabelImpedisciResizing.Name = "LabelImpedisciResizing"
        Me.LabelImpedisciResizing.Size = New System.Drawing.Size(25, 25)
        Me.LabelImpedisciResizing.TabIndex = 0
        Me.LabelImpedisciResizing.Visible = False
        '
        'pnAllarga
        '
        Me.pnAllarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnAllarga.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnAllarga.Controls.Add(Me.Label4)
        Me.pnAllarga.Controls.Add(Me.btnZoomVia)
        Me.pnAllarga.Controls.Add(Me.btnZoomPiu)
        Me.pnAllarga.Controls.Add(Me.btnZoomMeno)
        Me.pnAllarga.Controls.Add(Me.btnChiudiAllarga)
        Me.pnAllarga.Controls.Add(Me.btnStringi)
        Me.pnAllarga.Controls.Add(Me.btnAllarga)
        Me.pnAllarga.Location = New System.Drawing.Point(7, 302)
        Me.pnAllarga.Name = "pnAllarga"
        Me.pnAllarga.Size = New System.Drawing.Size(247, 234)
        Me.pnAllarga.TabIndex = 104
        Me.pnAllarga.Visible = False
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 54)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(226, 54)
        Me.Label4.TabIndex = 89
        Me.Label4.Text = "REGOLA LA LARGHEZZA" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "DELLA FINESTRA DI TESTO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnZoomVia
        '
        Me.btnZoomVia.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnZoomVia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnZoomVia.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnZoomVia.FlatAppearance.BorderSize = 2
        Me.btnZoomVia.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnZoomVia.Image = CType(resources.GetObject("btnZoomVia.Image"), System.Drawing.Image)
        Me.btnZoomVia.Location = New System.Drawing.Point(177, 10)
        Me.btnZoomVia.Name = "btnZoomVia"
        Me.btnZoomVia.Size = New System.Drawing.Size(36, 36)
        Me.btnZoomVia.TabIndex = 88
        Me.ToolTip1.SetToolTip(Me.btnZoomVia, " ZOOM VIA")
        Me.btnZoomVia.UseVisualStyleBackColor = False
        '
        'btnZoomPiu
        '
        Me.btnZoomPiu.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnZoomPiu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnZoomPiu.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnZoomPiu.FlatAppearance.BorderSize = 2
        Me.btnZoomPiu.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnZoomPiu.Image = CType(resources.GetObject("btnZoomPiu.Image"), System.Drawing.Image)
        Me.btnZoomPiu.Location = New System.Drawing.Point(42, 11)
        Me.btnZoomPiu.Name = "btnZoomPiu"
        Me.btnZoomPiu.Size = New System.Drawing.Size(36, 36)
        Me.btnZoomPiu.TabIndex = 86
        Me.ToolTip1.SetToolTip(Me.btnZoomPiu, " ZOOM + ")
        Me.btnZoomPiu.UseVisualStyleBackColor = False
        '
        'btnZoomMeno
        '
        Me.btnZoomMeno.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.btnZoomMeno.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnZoomMeno.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnZoomMeno.FlatAppearance.BorderSize = 2
        Me.btnZoomMeno.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.btnZoomMeno.Image = CType(resources.GetObject("btnZoomMeno.Image"), System.Drawing.Image)
        Me.btnZoomMeno.Location = New System.Drawing.Point(109, 11)
        Me.btnZoomMeno.Name = "btnZoomMeno"
        Me.btnZoomMeno.Size = New System.Drawing.Size(36, 36)
        Me.btnZoomMeno.TabIndex = 87
        Me.ToolTip1.SetToolTip(Me.btnZoomMeno, " ZOOM - ")
        Me.btnZoomMeno.UseVisualStyleBackColor = False
        '
        'btnChiudiAllarga
        '
        Me.btnChiudiAllarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnChiudiAllarga.BackColor = System.Drawing.Color.Pink
        Me.btnChiudiAllarga.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnChiudiAllarga.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnChiudiAllarga.Font = New System.Drawing.Font("Verdana", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChiudiAllarga.ForeColor = System.Drawing.Color.Red
        Me.btnChiudiAllarga.Location = New System.Drawing.Point(94, 158)
        Me.btnChiudiAllarga.Name = "btnChiudiAllarga"
        Me.btnChiudiAllarga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnChiudiAllarga.Size = New System.Drawing.Size(58, 40)
        Me.btnChiudiAllarga.TabIndex = 85
        Me.btnChiudiAllarga.Text = "OK"
        Me.ToolTip1.SetToolTip(Me.btnChiudiAllarga, " FINITO ")
        Me.btnChiudiAllarga.UseVisualStyleBackColor = False
        '
        'btnStringi
        '
        Me.btnStringi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnStringi.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnStringi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnStringi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnStringi.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStringi.ForeColor = System.Drawing.Color.White
        Me.btnStringi.Location = New System.Drawing.Point(142, 110)
        Me.btnStringi.Name = "btnStringi"
        Me.btnStringi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnStringi.Size = New System.Drawing.Size(93, 40)
        Me.btnStringi.TabIndex = 84
        Me.btnStringi.Text = ">| |<"
        Me.ToolTip1.SetToolTip(Me.btnStringi, " RESTRINGI PANNELLO ")
        Me.btnStringi.UseVisualStyleBackColor = False
        '
        'btnAllarga
        '
        Me.btnAllarga.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAllarga.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnAllarga.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAllarga.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAllarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAllarga.ForeColor = System.Drawing.Color.White
        Me.btnAllarga.Location = New System.Drawing.Point(14, 111)
        Me.btnAllarga.Name = "btnAllarga"
        Me.btnAllarga.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAllarga.Size = New System.Drawing.Size(85, 40)
        Me.btnAllarga.TabIndex = 83
        Me.btnAllarga.Text = "|< >|"
        Me.ToolTip1.SetToolTip(Me.btnAllarga, " ALLARGA PANNELLO ")
        Me.btnAllarga.UseVisualStyleBackColor = False
        '
        'pnComandi
        '
        Me.pnComandi.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnComandi.Controls.Add(Me.pnAllarga)
        Me.pnComandi.Controls.Add(Me.pnEstraiPDF)
        Me.pnComandi.Controls.Add(Me.RTB)
        Me.pnComandi.Controls.Add(Me.btnEstrai)
        Me.pnComandi.Controls.Add(Me.btnSproteggi)
        Me.pnComandi.Controls.Add(Me.btnOpzioniVisualizzazione)
        Me.pnComandi.Controls.Add(Me.lbLingua)
        Me.pnComandi.Controls.Add(Me.ckTesto)
        Me.pnComandi.Controls.Add(Me.ckFoto)
        Me.pnComandi.Controls.Add(Me.btnTorna)
        Me.pnComandi.Controls.Add(Me.btnIncolla)
        Me.pnComandi.Controls.Add(Me.Label5)
        Me.pnComandi.Controls.Add(Me.trVelocita)
        Me.pnComandi.Controls.Add(Me.Label1)
        Me.pnComandi.Controls.Add(Me.Label3)
        Me.pnComandi.Controls.Add(Me.cmdVoce)
        Me.pnComandi.Controls.Add(Me.picComandi)
        Me.pnComandi.Dock = System.Windows.Forms.DockStyle.Right
        Me.pnComandi.Location = New System.Drawing.Point(544, 0)
        Me.pnComandi.Name = "pnComandi"
        Me.pnComandi.Size = New System.Drawing.Size(250, 635)
        Me.pnComandi.TabIndex = 1
        '
        'cmdVoce
        '
        Me.cmdVoce.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdVoce.BackColor = System.Drawing.Color.Transparent
        Me.cmdVoce.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdVoce.Font = New System.Drawing.Font("Courier New", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVoce.ForeColor = System.Drawing.Color.White
        Me.cmdVoce.Image = Global.LeggiXme.My.Resources.Resources.BandIta
        Me.cmdVoce.Location = New System.Drawing.Point(69, 189)
        Me.cmdVoce.Name = "cmdVoce"
        Me.cmdVoce.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVoce.Size = New System.Drawing.Size(40, 40)
        Me.cmdVoce.TabIndex = 115
        Me.cmdVoce.Tag = "SCEGLI LINGUA"
        Me.cmdVoce.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.cmdVoce, "SCEGLI LINGUA")
        Me.cmdVoce.UseVisualStyleBackColor = False
        '
        'pnEstraiPDF
        '
        Me.pnEstraiPDF.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnEstraiPDF.BackColor = System.Drawing.Color.LightSteelBlue
        Me.pnEstraiPDF.Controls.Add(Me.lblFile)
        Me.pnEstraiPDF.Controls.Add(Me.btnAnnulla)
        Me.pnEstraiPDF.Controls.Add(Me.btnSalvaApri)
        Me.pnEstraiPDF.Controls.Add(Me.btnSalva)
        Me.pnEstraiPDF.Controls.Add(Me.Label2)
        Me.pnEstraiPDF.Controls.Add(Me.txPagg)
        Me.pnEstraiPDF.Location = New System.Drawing.Point(0, 6)
        Me.pnEstraiPDF.Name = "pnEstraiPDF"
        Me.pnEstraiPDF.Size = New System.Drawing.Size(248, 237)
        Me.pnEstraiPDF.TabIndex = 103
        Me.pnEstraiPDF.Visible = False
        '
        'lblFile
        '
        Me.lblFile.BackColor = System.Drawing.Color.LightSteelBlue
        Me.lblFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFile.ForeColor = System.Drawing.Color.Black
        Me.lblFile.Location = New System.Drawing.Point(17, 150)
        Me.lblFile.Name = "lblFile"
        Me.lblFile.Size = New System.Drawing.Size(227, 47)
        Me.lblFile.TabIndex = 5
        '
        'btnAnnulla
        '
        Me.btnAnnulla.Image = CType(resources.GetObject("btnAnnulla.Image"), System.Drawing.Image)
        Me.btnAnnulla.Location = New System.Drawing.Point(194, 102)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Size = New System.Drawing.Size(38, 36)
        Me.btnAnnulla.TabIndex = 4
        Me.ToolTip1.SetToolTip(Me.btnAnnulla, " CHIUDI ")
        Me.btnAnnulla.UseVisualStyleBackColor = True
        '
        'btnSalvaApri
        '
        Me.btnSalvaApri.Image = CType(resources.GetObject("btnSalvaApri.Image"), System.Drawing.Image)
        Me.btnSalvaApri.Location = New System.Drawing.Point(110, 102)
        Me.btnSalvaApri.Name = "btnSalvaApri"
        Me.btnSalvaApri.Size = New System.Drawing.Size(38, 36)
        Me.btnSalvaApri.TabIndex = 3
        Me.ToolTip1.SetToolTip(Me.btnSalvaApri, " APRI PAGINE ESTRATTE ")
        Me.btnSalvaApri.UseVisualStyleBackColor = True
        '
        'btnSalva
        '
        Me.btnSalva.Image = CType(resources.GetObject("btnSalva.Image"), System.Drawing.Image)
        Me.btnSalva.Location = New System.Drawing.Point(17, 102)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(38, 36)
        Me.btnSalva.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.btnSalva, " SALVA PAGINE ESTRATTE ")
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(34, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(185, 18)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "ESTRAI QUESTE PAGINE"
        '
        'txPagg
        '
        Me.txPagg.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txPagg.Location = New System.Drawing.Point(12, 60)
        Me.txPagg.Name = "txPagg"
        Me.txPagg.Size = New System.Drawing.Size(220, 24)
        Me.txPagg.TabIndex = 0
        '
        'picComandi
        '
        Me.picComandi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.picComandi.BackColor = System.Drawing.Color.DodgerBlue
        Me.picComandi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.picComandi.Controls.Add(Me.cmdPausa)
        Me.picComandi.Controls.Add(Me.cmdRipeti)
        Me.picComandi.Controls.Add(Me.cmdLeggiVerde)
        Me.picComandi.Controls.Add(Me.cmdApri)
        Me.picComandi.Controls.Add(Me.cmdStop)
        Me.picComandi.Cursor = System.Windows.Forms.Cursors.Default
        Me.picComandi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picComandi.Location = New System.Drawing.Point(31, 142)
        Me.picComandi.Name = "picComandi"
        Me.picComandi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picComandi.Size = New System.Drawing.Size(155, 42)
        Me.picComandi.TabIndex = 78
        Me.picComandi.TabStop = True
        '
        'cmdPausa
        '
        Me.cmdPausa.BackColor = System.Drawing.Color.Transparent
        Me.cmdPausa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPausa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPausa.Image = Global.LeggiXme.My.Resources.Resources.pausa_2
        Me.cmdPausa.Location = New System.Drawing.Point(76, 0)
        Me.cmdPausa.Name = "cmdPausa"
        Me.cmdPausa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPausa.Size = New System.Drawing.Size(40, 40)
        Me.cmdPausa.TabIndex = 19
        Me.cmdPausa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdPausa, " PAUSA LETTURA ")
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
        Me.cmdLeggiVerde.Location = New System.Drawing.Point(-1, 0)
        Me.cmdLeggiVerde.Name = "cmdLeggiVerde"
        Me.cmdLeggiVerde.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeggiVerde.Size = New System.Drawing.Size(40, 40)
        Me.cmdLeggiVerde.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.cmdLeggiVerde, " IMPORTA TESTO SELEZIONATO ")
        Me.cmdLeggiVerde.UseVisualStyleBackColor = False
        '
        'cmdApri
        '
        Me.cmdApri.BackColor = System.Drawing.Color.Transparent
        Me.cmdApri.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdApri.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdApri.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdApri.Image = CType(resources.GetObject("cmdApri.Image"), System.Drawing.Image)
        Me.cmdApri.Location = New System.Drawing.Point(114, 0)
        Me.cmdApri.Name = "cmdApri"
        Me.cmdApri.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdApri.Size = New System.Drawing.Size(40, 40)
        Me.cmdApri.TabIndex = 14
        Me.cmdApri.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdApri, " APRI DOCUMENTO PDF ")
        Me.cmdApri.UseVisualStyleBackColor = False
        '
        'cmdStop
        '
        Me.cmdStop.BackColor = System.Drawing.Color.Transparent
        Me.cmdStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStop.Image = Global.LeggiXme.My.Resources.Resources._stop
        Me.cmdStop.Location = New System.Drawing.Point(37, 0)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStop.Size = New System.Drawing.Size(40, 40)
        Me.cmdStop.TabIndex = 13
        Me.cmdStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdStop, " FERMA LETTURA ")
        Me.cmdStop.UseVisualStyleBackColor = False
        '
        'RTB
        '
        Me.RTB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.RTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.RTB.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.RTB.HideSelection = False
        Me.RTB.Location = New System.Drawing.Point(7, 243)
        Me.RTB.Name = "RTB"
        Me.RTB.ReadOnly = True
        Me.RTB.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.RTB.Size = New System.Drawing.Size(234, 389)
        Me.RTB.TabIndex = 1
        Me.RTB.Text = ""
        '
        'btnEstrai
        '
        Me.btnEstrai.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEstrai.BackColor = System.Drawing.Color.Transparent
        Me.btnEstrai.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnEstrai.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnEstrai.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEstrai.Image = Global.LeggiXme.My.Resources.Resources.EstraiPDF_r
        Me.btnEstrai.Location = New System.Drawing.Point(40, 98)
        Me.btnEstrai.Name = "btnEstrai"
        Me.btnEstrai.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnEstrai.Size = New System.Drawing.Size(40, 40)
        Me.btnEstrai.TabIndex = 102
        Me.ToolTip1.SetToolTip(Me.btnEstrai, " ESTRAI PAGINE DAL DOCUMENTO ")
        Me.btnEstrai.UseVisualStyleBackColor = False
        '
        'btnSproteggi
        '
        Me.btnSproteggi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSproteggi.BackColor = System.Drawing.Color.Transparent
        Me.btnSproteggi.Font = New System.Drawing.Font("Arial Narrow", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSproteggi.Location = New System.Drawing.Point(152, 96)
        Me.btnSproteggi.Name = "btnSproteggi"
        Me.btnSproteggi.Size = New System.Drawing.Size(43, 42)
        Me.btnSproteggi.TabIndex = 101
        Me.btnSproteggi.Text = "Sprot"
        Me.btnSproteggi.UseCompatibleTextRendering = True
        Me.btnSproteggi.UseVisualStyleBackColor = False
        Me.btnSproteggi.Visible = False
        '
        'btnOpzioniVisualizzazione
        '
        Me.btnOpzioniVisualizzazione.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnOpzioniVisualizzazione.BackColor = System.Drawing.Color.Transparent
        Me.btnOpzioniVisualizzazione.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOpzioniVisualizzazione.Font = New System.Drawing.Font("Courier New", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpzioniVisualizzazione.ForeColor = System.Drawing.Color.White
        Me.btnOpzioniVisualizzazione.Image = CType(resources.GetObject("btnOpzioniVisualizzazione.Image"), System.Drawing.Image)
        Me.btnOpzioniVisualizzazione.Location = New System.Drawing.Point(97, 99)
        Me.btnOpzioniVisualizzazione.Name = "btnOpzioniVisualizzazione"
        Me.btnOpzioniVisualizzazione.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpzioniVisualizzazione.Size = New System.Drawing.Size(40, 40)
        Me.btnOpzioniVisualizzazione.TabIndex = 17
        Me.btnOpzioniVisualizzazione.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.btnOpzioniVisualizzazione, " OPZIONI DI VISUALIZZAZIONE ")
        Me.btnOpzioniVisualizzazione.UseVisualStyleBackColor = False
        '
        'lbLingua
        '
        Me.lbLingua.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lbLingua.AutoSize = True
        Me.lbLingua.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLingua.Location = New System.Drawing.Point(121, 206)
        Me.lbLingua.Name = "lbLingua"
        Me.lbLingua.Size = New System.Drawing.Size(57, 16)
        Me.lbLingua.TabIndex = 100
        Me.lbLingua.Text = "LINGUA"
        '
        'ckTesto
        '
        Me.ckTesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckTesto.AutoSize = True
        Me.ckTesto.Image = CType(resources.GetObject("ckTesto.Image"), System.Drawing.Image)
        Me.ckTesto.Location = New System.Drawing.Point(40, 46)
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
        Me.ckFoto.Location = New System.Drawing.Point(40, 11)
        Me.ckFoto.Name = "ckFoto"
        Me.ckFoto.Size = New System.Drawing.Size(47, 32)
        Me.ckFoto.TabIndex = 84
        Me.ckFoto.UseVisualStyleBackColor = True
        '
        'btnTorna
        '
        Me.btnTorna.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTorna.BackColor = System.Drawing.Color.Transparent
        Me.btnTorna.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTorna.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTorna.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnTorna.Image = Global.LeggiXme.My.Resources.Resources.home_tr
        Me.btnTorna.Location = New System.Drawing.Point(186, 6)
        Me.btnTorna.Name = "btnTorna"
        Me.btnTorna.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnTorna.Size = New System.Drawing.Size(40, 40)
        Me.btnTorna.TabIndex = 82
        Me.ToolTip1.SetToolTip(Me.btnTorna, "SCHERMATA PRINCIPALE")
        Me.btnTorna.UseVisualStyleBackColor = False
        '
        'btnIncolla
        '
        Me.btnIncolla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnIncolla.BackColor = System.Drawing.Color.Transparent
        Me.btnIncolla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncolla.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnIncolla.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIncolla.Image = Global.LeggiXme.My.Resources.Resources.annaffiatoio
        Me.btnIncolla.Location = New System.Drawing.Point(97, 20)
        Me.btnIncolla.Name = "btnIncolla"
        Me.btnIncolla.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIncolla.Size = New System.Drawing.Size(40, 40)
        Me.btnIncolla.TabIndex = 81
        Me.ToolTip1.SetToolTip(Me.btnIncolla, " INCOLLA NEL DOCUMENTO PRINCIPALE ")
        Me.btnIncolla.UseVisualStyleBackColor = False
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(219, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(17, 55)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "+" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "-"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'trVelocita
        '
        Me.trVelocita.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.trVelocita.Location = New System.Drawing.Point(196, 135)
        Me.trVelocita.Maximum = 8
        Me.trVelocita.Minimum = -10
        Me.trVelocita.Name = "trVelocita"
        Me.trVelocita.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.trVelocita.Size = New System.Drawing.Size(45, 59)
        Me.trVelocita.TabIndex = 104
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Location = New System.Drawing.Point(32, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(123, 75)
        Me.Label1.TabIndex = 86
        '
        'Label3
        '
        Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(23, 206)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "VOCE:"
        '
        'Timer1
        '
        Me.Timer1.Interval = 200
        '
        'Timer2
        '
        Me.Timer2.Interval = 2000
        '
        'tmrPDF
        '
        Me.tmrPDF.Interval = 2000
        '
        'Timer3
        '
        Me.Timer3.Interval = 1000
        '
        'MenuVoci
        '
        Me.MenuVoci.ImageScalingSize = New System.Drawing.Size(24, 16)
        Me.MenuVoci.Name = "MenuVoci"
        Me.MenuVoci.Size = New System.Drawing.Size(61, 4)
        '
        'frmPDF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(794, 635)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnPDF)
        Me.Controls.Add(Me.pnComandi)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmPDF"
        Me.Text = "LeggiXme - Leggi Libri PDF"
        Me.pnPDF.ResumeLayout(False)
        Me.pnAllarga.ResumeLayout(False)
        Me.pnComandi.ResumeLayout(False)
        Me.pnComandi.PerformLayout()
        Me.pnEstraiPDF.ResumeLayout(False)
        Me.pnEstraiPDF.PerformLayout()
        Me.picComandi.ResumeLayout(False)
        CType(Me.trVelocita, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents pnPDF As System.Windows.Forms.Panel
    Friend WithEvents pnComandi As System.Windows.Forms.Panel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Public WithEvents picComandi As System.Windows.Forms.Panel
    Public WithEvents cmdPausa As System.Windows.Forms.Button
    Public WithEvents cmdRipeti As System.Windows.Forms.Button
    Public WithEvents btnOpzioniVisualizzazione As System.Windows.Forms.Button
    Friend WithEvents cmdLeggiVerde As System.Windows.Forms.Button
    Public WithEvents cmdApri As System.Windows.Forms.Button
    Public WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents btnIncolla As System.Windows.Forms.Button
    Friend WithEvents btnTorna As System.Windows.Forms.Button
    Friend WithEvents ckFoto As System.Windows.Forms.CheckBox
    Friend WithEvents ckTesto As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents lbLingua As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents LabelImpedisciResizing As System.Windows.Forms.Label
    Friend WithEvents btnSproteggi As System.Windows.Forms.Button
    Friend WithEvents tmrPDF As System.Windows.Forms.Timer
    Friend WithEvents btnEstrai As System.Windows.Forms.Button
    Friend WithEvents pnEstraiPDF As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txPagg As System.Windows.Forms.TextBox
    Friend WithEvents btnSalvaApri As System.Windows.Forms.Button
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents btnAnnulla As System.Windows.Forms.Button
    Friend WithEvents lblFile As System.Windows.Forms.Label
    Friend WithEvents RTB As System.Windows.Forms.RichTextBox
    Friend WithEvents pnAllarga As System.Windows.Forms.Panel
    Friend WithEvents btnChiudiAllarga As System.Windows.Forms.Button
    Friend WithEvents btnStringi As System.Windows.Forms.Button
    Friend WithEvents btnAllarga As System.Windows.Forms.Button
    Friend WithEvents btnZoomVia As System.Windows.Forms.Button
    Friend WithEvents btnZoomPiu As System.Windows.Forms.Button
    Friend WithEvents btnZoomMeno As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Timer3 As System.Windows.Forms.Timer
    Friend WithEvents trVelocita As System.Windows.Forms.TrackBar
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Public WithEvents cmdVoce As System.Windows.Forms.Button
    Friend WithEvents MenuVoci As System.Windows.Forms.ContextMenuStrip
    'Friend WithEvents ShapeContainer1 As Microsoft.VisualBasic.PowerPacks.ShapeContainer
    'Friend WithEvents RectangleShape1 As Microsoft.VisualBasic.PowerPacks.RectangleShape
End Class
