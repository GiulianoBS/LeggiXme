<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLettore
    Inherits System.Windows.Forms.Form

    'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
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

    'Richiesto da Progettazione Windows Form
    Private components As System.ComponentModel.IContainer

    'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
    'Può essere modificata in Progettazione Windows Form.  
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLettore))
        Me.picComandi = New System.Windows.Forms.Panel()
        Me.btnAggiungiTesto = New System.Windows.Forms.Button()
        Me.btnOCR = New System.Windows.Forms.Button()
        Me.btnTrad = New System.Windows.Forms.Button()
        Me.cmdMeno = New System.Windows.Forms.Button()
        Me.cmdPiu = New System.Windows.Forms.Button()
        Me.cmdVoce = New System.Windows.Forms.Button()
        Me.cmdPausa = New System.Windows.Forms.Button()
        Me.cmdLeggi = New System.Windows.Forms.Button()
        Me.cmdApriDocumento = New System.Windows.Forms.Button()
        Me.cmdStop = New System.Windows.Forms.Button()
        Me.MioTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MenuVoci = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.picComandi.SuspendLayout()
        Me.SuspendLayout()
        '
        'picComandi
        '
        Me.picComandi.BackColor = System.Drawing.Color.Transparent
        Me.picComandi.Controls.Add(Me.btnAggiungiTesto)
        Me.picComandi.Controls.Add(Me.btnOCR)
        Me.picComandi.Controls.Add(Me.btnTrad)
        Me.picComandi.Controls.Add(Me.cmdMeno)
        Me.picComandi.Controls.Add(Me.cmdPiu)
        Me.picComandi.Controls.Add(Me.cmdVoce)
        Me.picComandi.Controls.Add(Me.cmdPausa)
        Me.picComandi.Controls.Add(Me.cmdLeggi)
        Me.picComandi.Controls.Add(Me.cmdApriDocumento)
        Me.picComandi.Controls.Add(Me.cmdStop)
        Me.picComandi.Cursor = System.Windows.Forms.Cursors.Default
        Me.picComandi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.picComandi.Location = New System.Drawing.Point(0, 1)
        Me.picComandi.Name = "picComandi"
        Me.picComandi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.picComandi.Size = New System.Drawing.Size(337, 42)
        Me.picComandi.TabIndex = 78
        Me.picComandi.TabStop = True
        '
        'btnAggiungiTesto
        '
        Me.btnAggiungiTesto.AllowDrop = True
        Me.btnAggiungiTesto.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnAggiungiTesto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAggiungiTesto.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAggiungiTesto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAggiungiTesto.Image = Global.LeggiXme.My.Resources.Resources.AggiungiTesto
        Me.btnAggiungiTesto.Location = New System.Drawing.Point(256, 0)
        Me.btnAggiungiTesto.Name = "btnAggiungiTesto"
        Me.btnAggiungiTesto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnAggiungiTesto.Size = New System.Drawing.Size(40, 40)
        Me.btnAggiungiTesto.TabIndex = 25
        Me.btnAggiungiTesto.Tag = "Aggiungi Testo"
        Me.btnAggiungiTesto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnAggiungiTesto, "AGGIUNGI TESTO IN CODA")
        Me.btnAggiungiTesto.UseVisualStyleBackColor = False
        '
        'btnOCR
        '
        Me.btnOCR.AllowDrop = True
        Me.btnOCR.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnOCR.BackgroundImage = Global.LeggiXme.My.Resources.Resources.BandIta
        Me.btnOCR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOCR.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOCR.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnOCR.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOCR.ForeColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnOCR.Image = CType(resources.GetObject("btnOCR.Image"), System.Drawing.Image)
        Me.btnOCR.Location = New System.Drawing.Point(177, 0)
        Me.btnOCR.Name = "btnOCR"
        Me.btnOCR.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOCR.Size = New System.Drawing.Size(40, 40)
        Me.btnOCR.TabIndex = 24
        Me.btnOCR.Tag = "ACQUISISCI TESTO"
        Me.btnOCR.Text = "OCR"
        Me.ToolTip1.SetToolTip(Me.btnOCR, "ACQUISISCI TESTO")
        Me.btnOCR.UseVisualStyleBackColor = False
        '
        'btnTrad
        '
        Me.btnTrad.AllowDrop = True
        Me.btnTrad.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnTrad.BackgroundImage = Global.LeggiXme.My.Resources.Resources.BandIta
        Me.btnTrad.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnTrad.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnTrad.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnTrad.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTrad.ForeColor = System.Drawing.Color.Blue
        Me.btnTrad.Location = New System.Drawing.Point(216, 0)
        Me.btnTrad.Name = "btnTrad"
        Me.btnTrad.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnTrad.Size = New System.Drawing.Size(40, 40)
        Me.btnTrad.TabIndex = 23
        Me.btnTrad.Tag = "TRADUCI IN ITALIANO"
        Me.btnTrad.Text = "T"
        Me.ToolTip1.SetToolTip(Me.btnTrad, "TRADUCI IN ITALIANO")
        Me.btnTrad.UseVisualStyleBackColor = False
        '
        'cmdMeno
        '
        Me.cmdMeno.AllowDrop = True
        Me.cmdMeno.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdMeno.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdMeno.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdMeno.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdMeno.Image = Global.LeggiXme.My.Resources.Resources.meno
        Me.cmdMeno.Location = New System.Drawing.Point(156, 19)
        Me.cmdMeno.Name = "cmdMeno"
        Me.cmdMeno.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdMeno.Size = New System.Drawing.Size(22, 20)
        Me.cmdMeno.TabIndex = 22
        Me.cmdMeno.Tag = "diminuisci velocità"
        Me.cmdMeno.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdMeno, "DIMINUISCI VELOCITA'")
        Me.cmdMeno.UseVisualStyleBackColor = False
        '
        'cmdPiu
        '
        Me.cmdPiu.AllowDrop = True
        Me.cmdPiu.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPiu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPiu.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdPiu.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPiu.Image = Global.LeggiXme.My.Resources.Resources.Piu
        Me.cmdPiu.Location = New System.Drawing.Point(156, 1)
        Me.cmdPiu.Name = "cmdPiu"
        Me.cmdPiu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPiu.Size = New System.Drawing.Size(22, 20)
        Me.cmdPiu.TabIndex = 21
        Me.cmdPiu.Tag = "aumenta velocità"
        Me.cmdPiu.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdPiu, "AUMENTA VELOCITA'")
        Me.cmdPiu.UseVisualStyleBackColor = False
        '
        'cmdVoce
        '
        Me.cmdVoce.BackColor = System.Drawing.Color.Transparent
        Me.cmdVoce.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdVoce.Font = New System.Drawing.Font("Courier New", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVoce.ForeColor = System.Drawing.Color.White
        Me.cmdVoce.Image = Global.LeggiXme.My.Resources.Resources.BandIta
        Me.cmdVoce.Location = New System.Drawing.Point(117, 0)
        Me.cmdVoce.Name = "cmdVoce"
        Me.cmdVoce.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdVoce.Size = New System.Drawing.Size(40, 40)
        Me.cmdVoce.TabIndex = 20
        Me.cmdVoce.Tag = "SCEGLI LINGUA"
        Me.cmdVoce.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ToolTip1.SetToolTip(Me.cmdVoce, "SCEGLI LINGUA")
        Me.cmdVoce.UseVisualStyleBackColor = False
        '
        'cmdPausa
        '
        Me.cmdPausa.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdPausa.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdPausa.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdPausa.Image = Global.LeggiXme.My.Resources.Resources.pausa_2
        Me.cmdPausa.Location = New System.Drawing.Point(78, 0)
        Me.cmdPausa.Name = "cmdPausa"
        Me.cmdPausa.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdPausa.Size = New System.Drawing.Size(40, 40)
        Me.cmdPausa.TabIndex = 19
        Me.cmdPausa.Tag = "PAUSA LETTURA"
        Me.cmdPausa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdPausa, "PAUSA LETTURA")
        Me.cmdPausa.UseVisualStyleBackColor = False
        '
        'cmdLeggi
        '
        Me.cmdLeggi.AllowDrop = True
        Me.cmdLeggi.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdLeggi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdLeggi.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdLeggi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdLeggi.Image = Global.LeggiXme.My.Resources.Resources.play
        Me.cmdLeggi.Location = New System.Drawing.Point(1, 0)
        Me.cmdLeggi.Name = "cmdLeggi"
        Me.cmdLeggi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdLeggi.Size = New System.Drawing.Size(40, 40)
        Me.cmdLeggi.TabIndex = 15
        Me.cmdLeggi.Tag = "LEGGI"
        Me.ToolTip1.SetToolTip(Me.cmdLeggi, "LEGGI")
        Me.cmdLeggi.UseVisualStyleBackColor = False
        '
        'cmdApriDocumento
        '
        Me.cmdApriDocumento.AllowDrop = True
        Me.cmdApriDocumento.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdApriDocumento.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdApriDocumento.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdApriDocumento.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdApriDocumento.Image = CType(resources.GetObject("cmdApriDocumento.Image"), System.Drawing.Image)
        Me.cmdApriDocumento.Location = New System.Drawing.Point(296, 2)
        Me.cmdApriDocumento.Name = "cmdApriDocumento"
        Me.cmdApriDocumento.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdApriDocumento.Size = New System.Drawing.Size(40, 40)
        Me.cmdApriDocumento.TabIndex = 14
        Me.cmdApriDocumento.Tag = "APRI DOCUMENTO"
        Me.cmdApriDocumento.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdApriDocumento, "APRI DOCUMENTO ")
        Me.cmdApriDocumento.UseVisualStyleBackColor = False
        '
        'cmdStop
        '
        Me.cmdStop.BackColor = System.Drawing.Color.WhiteSmoke
        Me.cmdStop.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdStop.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdStop.Image = Global.LeggiXme.My.Resources.Resources._stop
        Me.cmdStop.Location = New System.Drawing.Point(40, 0)
        Me.cmdStop.Name = "cmdStop"
        Me.cmdStop.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdStop.Size = New System.Drawing.Size(40, 40)
        Me.cmdStop.TabIndex = 13
        Me.cmdStop.Tag = "FERMA LETTURA"
        Me.cmdStop.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdStop, "FERMA LETTURA")
        Me.cmdStop.UseVisualStyleBackColor = False
        '
        'MioTimer
        '
        '
        'MenuVoci
        '
        Me.MenuVoci.ImageScalingSize = New System.Drawing.Size(24, 16)
        Me.MenuVoci.Name = "MenuVoci"
        Me.MenuVoci.Size = New System.Drawing.Size(61, 4)
        '
        'frmLettore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientActiveCaption
        Me.ClientSize = New System.Drawing.Size(336, 43)
        Me.Controls.Add(Me.picComandi)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmLettore"
        Me.Text = "LeggiXme"
        Me.TopMost = True
        Me.picComandi.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Public WithEvents picComandi As System.Windows.Forms.Panel
    Public WithEvents cmdVoce As System.Windows.Forms.Button
    Public WithEvents cmdPausa As System.Windows.Forms.Button
    Friend WithEvents cmdLeggi As System.Windows.Forms.Button
    Public WithEvents cmdApriDocumento As System.Windows.Forms.Button
    Public WithEvents cmdStop As System.Windows.Forms.Button
    Friend WithEvents MioTimer As System.Windows.Forms.Timer
    Friend WithEvents MenuVoci As System.Windows.Forms.ContextMenuStrip
    Public WithEvents cmdMeno As System.Windows.Forms.Button
    Public WithEvents cmdPiu As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents btnTrad As System.Windows.Forms.Button
    Public WithEvents btnOCR As System.Windows.Forms.Button
    Public WithEvents btnAggiungiTesto As System.Windows.Forms.Button
End Class
