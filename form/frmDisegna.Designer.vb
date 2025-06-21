<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDisegna
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDisegna))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.btnCopia = New System.Windows.Forms.Button()
        Me.btnIncolla = New System.Windows.Forms.Button()
        Me.btnAnnulla = New System.Windows.Forms.Button()
        Me.lblColore = New System.Windows.Forms.Label()
        Me.btnApri = New System.Windows.Forms.Button()
        Me.picScegliColore = New System.Windows.Forms.PictureBox()
        Me.picRettangoloVuoto = New System.Windows.Forms.PictureBox()
        Me.picEllisseVuoto = New System.Windows.Forms.PictureBox()
        Me.picCarattere = New System.Windows.Forms.PictureBox()
        Me.btnSalva = New System.Windows.Forms.Button()
        Me.picPennello = New System.Windows.Forms.PictureBox()
        Me.btnNuovo = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UpDownSpessore = New System.Windows.Forms.NumericUpDown()
        Me.picRettangoloPieno = New System.Windows.Forms.PictureBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.picLinea = New System.Windows.Forms.PictureBox()
        Me.picScrivi = New System.Windows.Forms.PictureBox()
        Me.PicEllissePieno = New System.Windows.Forms.PictureBox()
        Me.FontDialog1 = New System.Windows.Forms.FontDialog()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TrackBarR = New System.Windows.Forms.TrackBar()
        Me.TrackBarG = New System.Windows.Forms.TrackBar()
        Me.TrackBarB = New System.Windows.Forms.TrackBar()
        Me.PictureBox0 = New System.Windows.Forms.PictureBox()
        Me.PictureBox6 = New System.Windows.Forms.PictureBox()
        Me.Panel1.SuspendLayout()
        CType(Me.picScegliColore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRettangoloVuoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picEllisseVuoto, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picCarattere, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picPennello, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UpDownSpessore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picRettangoloPieno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picScrivi, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PicEllissePieno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarG, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBarB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox0, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.PeachPuff
        Me.Panel1.Controls.Add(Me.btnOK)
        Me.Panel1.Controls.Add(Me.btnCopia)
        Me.Panel1.Controls.Add(Me.btnIncolla)
        Me.Panel1.Controls.Add(Me.btnAnnulla)
        Me.Panel1.Controls.Add(Me.lblColore)
        Me.Panel1.Controls.Add(Me.btnApri)
        Me.Panel1.Controls.Add(Me.picScegliColore)
        Me.Panel1.Controls.Add(Me.picRettangoloVuoto)
        Me.Panel1.Controls.Add(Me.picEllisseVuoto)
        Me.Panel1.Controls.Add(Me.picCarattere)
        Me.Panel1.Controls.Add(Me.btnSalva)
        Me.Panel1.Controls.Add(Me.picPennello)
        Me.Panel1.Controls.Add(Me.btnNuovo)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.UpDownSpessore)
        Me.Panel1.Controls.Add(Me.picRettangoloPieno)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.picLinea)
        Me.Panel1.Controls.Add(Me.picScrivi)
        Me.Panel1.Controls.Add(Me.PicEllissePieno)
        Me.Panel1.Location = New System.Drawing.Point(-1, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(559, 87)
        Me.Panel1.TabIndex = 1
        '
        'btnOK
        '
        Me.btnOK.BackgroundImage = CType(resources.GetObject("btnOK.BackgroundImage"), System.Drawing.Image)
        Me.btnOK.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.ForeColor = System.Drawing.Color.DarkGreen
        Me.btnOK.Location = New System.Drawing.Point(517, 4)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(38, 36)
        Me.btnOK.TabIndex = 38
        Me.btnOK.Text = "OK"
        Me.ToolTip1.SetToolTip(Me.btnOK, "COPIA IMMAGINE")
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCopia
        '
        Me.btnCopia.BackgroundImage = CType(resources.GetObject("btnCopia.BackgroundImage"), System.Drawing.Image)
        Me.btnCopia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnCopia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopia.Location = New System.Drawing.Point(394, 48)
        Me.btnCopia.Name = "btnCopia"
        Me.btnCopia.Size = New System.Drawing.Size(38, 36)
        Me.btnCopia.TabIndex = 37
        Me.ToolTip1.SetToolTip(Me.btnCopia, "COPIA IMMAGINE")
        Me.btnCopia.UseVisualStyleBackColor = True
        '
        'btnIncolla
        '
        Me.btnIncolla.BackgroundImage = CType(resources.GetObject("btnIncolla.BackgroundImage"), System.Drawing.Image)
        Me.btnIncolla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnIncolla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncolla.Location = New System.Drawing.Point(437, 3)
        Me.btnIncolla.Name = "btnIncolla"
        Me.btnIncolla.Size = New System.Drawing.Size(36, 36)
        Me.btnIncolla.TabIndex = 36
        Me.ToolTip1.SetToolTip(Me.btnIncolla, "INCOLLA")
        Me.btnIncolla.UseVisualStyleBackColor = True
        '
        'btnAnnulla
        '
        Me.btnAnnulla.BackgroundImage = CType(resources.GetObject("btnAnnulla.BackgroundImage"), System.Drawing.Image)
        Me.btnAnnulla.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnAnnulla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnAnnulla.Enabled = False
        Me.btnAnnulla.Location = New System.Drawing.Point(61, 2)
        Me.btnAnnulla.Name = "btnAnnulla"
        Me.btnAnnulla.Size = New System.Drawing.Size(41, 38)
        Me.btnAnnulla.TabIndex = 35
        Me.ToolTip1.SetToolTip(Me.btnAnnulla, "ANNULLA")
        Me.btnAnnulla.UseVisualStyleBackColor = True
        '
        'lblColore
        '
        Me.lblColore.BackColor = System.Drawing.Color.Black
        Me.lblColore.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblColore.Location = New System.Drawing.Point(20, 6)
        Me.lblColore.Name = "lblColore"
        Me.lblColore.Size = New System.Drawing.Size(33, 33)
        Me.lblColore.TabIndex = 34
        Me.ToolTip1.SetToolTip(Me.lblColore, "COLORE CORRENTE")
        '
        'btnApri
        '
        Me.btnApri.BackgroundImage = CType(resources.GetObject("btnApri.BackgroundImage"), System.Drawing.Image)
        Me.btnApri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnApri.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnApri.Location = New System.Drawing.Point(476, 1)
        Me.btnApri.Name = "btnApri"
        Me.btnApri.Size = New System.Drawing.Size(39, 41)
        Me.btnApri.TabIndex = 33
        Me.ToolTip1.SetToolTip(Me.btnApri, "APRI")
        Me.btnApri.UseVisualStyleBackColor = True
        '
        'picScegliColore
        '
        Me.picScegliColore.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picScegliColore.Image = CType(resources.GetObject("picScegliColore.Image"), System.Drawing.Image)
        Me.picScegliColore.Location = New System.Drawing.Point(18, 44)
        Me.picScegliColore.Name = "picScegliColore"
        Me.picScegliColore.Size = New System.Drawing.Size(39, 37)
        Me.picScegliColore.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picScegliColore.TabIndex = 31
        Me.picScegliColore.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picScegliColore, "SCEGLI COLORE")
        '
        'picRettangoloVuoto
        '
        Me.picRettangoloVuoto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picRettangoloVuoto.Image = CType(resources.GetObject("picRettangoloVuoto.Image"), System.Drawing.Image)
        Me.picRettangoloVuoto.Location = New System.Drawing.Point(220, 46)
        Me.picRettangoloVuoto.Name = "picRettangoloVuoto"
        Me.picRettangoloVuoto.Size = New System.Drawing.Size(39, 37)
        Me.picRettangoloVuoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRettangoloVuoto.TabIndex = 30
        Me.picRettangoloVuoto.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picRettangoloVuoto, "RETTANGOLO VUOTO")
        '
        'picEllisseVuoto
        '
        Me.picEllisseVuoto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picEllisseVuoto.Image = CType(resources.GetObject("picEllisseVuoto.Image"), System.Drawing.Image)
        Me.picEllisseVuoto.Location = New System.Drawing.Point(303, 47)
        Me.picEllisseVuoto.Name = "picEllisseVuoto"
        Me.picEllisseVuoto.Size = New System.Drawing.Size(39, 37)
        Me.picEllisseVuoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picEllisseVuoto.TabIndex = 26
        Me.picEllisseVuoto.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picEllisseVuoto, "ELLISSE VUOTO")
        '
        'picCarattere
        '
        Me.picCarattere.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picCarattere.Image = CType(resources.GetObject("picCarattere.Image"), System.Drawing.Image)
        Me.picCarattere.Location = New System.Drawing.Point(103, 2)
        Me.picCarattere.Name = "picCarattere"
        Me.picCarattere.Size = New System.Drawing.Size(39, 37)
        Me.picCarattere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picCarattere.TabIndex = 24
        Me.picCarattere.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picCarattere, "CARATTERE")
        '
        'btnSalva
        '
        Me.btnSalva.BackgroundImage = CType(resources.GetObject("btnSalva.BackgroundImage"), System.Drawing.Image)
        Me.btnSalva.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnSalva.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSalva.Location = New System.Drawing.Point(479, 44)
        Me.btnSalva.Name = "btnSalva"
        Me.btnSalva.Size = New System.Drawing.Size(39, 40)
        Me.btnSalva.TabIndex = 19
        Me.ToolTip1.SetToolTip(Me.btnSalva, "SALVA")
        Me.btnSalva.UseVisualStyleBackColor = True
        '
        'picPennello
        '
        Me.picPennello.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picPennello.Image = CType(resources.GetObject("picPennello.Image"), System.Drawing.Image)
        Me.picPennello.Location = New System.Drawing.Point(139, 47)
        Me.picPennello.Name = "picPennello"
        Me.picPennello.Size = New System.Drawing.Size(39, 37)
        Me.picPennello.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picPennello.TabIndex = 16
        Me.picPennello.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picPennello, "PENNELLO")
        '
        'btnNuovo
        '
        Me.btnNuovo.BackgroundImage = CType(resources.GetObject("btnNuovo.BackgroundImage"), System.Drawing.Image)
        Me.btnNuovo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNuovo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnNuovo.Location = New System.Drawing.Point(438, 46)
        Me.btnNuovo.Name = "btnNuovo"
        Me.btnNuovo.Size = New System.Drawing.Size(38, 36)
        Me.btnNuovo.TabIndex = 15
        Me.ToolTip1.SetToolTip(Me.btnNuovo, "NUOVO")
        Me.btnNuovo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(60, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "SPESSORE"
        '
        'UpDownSpessore
        '
        Me.UpDownSpessore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UpDownSpessore.Location = New System.Drawing.Point(63, 61)
        Me.UpDownSpessore.Maximum = New Decimal(New Integer() {20, 0, 0, 0})
        Me.UpDownSpessore.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.UpDownSpessore.Name = "UpDownSpessore"
        Me.UpDownSpessore.Size = New System.Drawing.Size(67, 20)
        Me.UpDownSpessore.TabIndex = 7
        Me.UpDownSpessore.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'picRettangoloPieno
        '
        Me.picRettangoloPieno.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picRettangoloPieno.Image = CType(resources.GetObject("picRettangoloPieno.Image"), System.Drawing.Image)
        Me.picRettangoloPieno.Location = New System.Drawing.Point(262, 45)
        Me.picRettangoloPieno.Name = "picRettangoloPieno"
        Me.picRettangoloPieno.Size = New System.Drawing.Size(39, 37)
        Me.picRettangoloPieno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picRettangoloPieno.TabIndex = 10
        Me.picRettangoloPieno.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picRettangoloPieno, "RETTANGOLO PIENO")
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(145, 0)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(234, 39)
        Me.TextBox1.TabIndex = 12
        Me.TextBox1.Text = "Testo da scrivere"
        '
        'picLinea
        '
        Me.picLinea.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picLinea.Image = CType(resources.GetObject("picLinea.Image"), System.Drawing.Image)
        Me.picLinea.Location = New System.Drawing.Point(180, 47)
        Me.picLinea.Name = "picLinea"
        Me.picLinea.Size = New System.Drawing.Size(39, 37)
        Me.picLinea.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLinea.TabIndex = 8
        Me.picLinea.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picLinea, "LINEA RETTA")
        '
        'picScrivi
        '
        Me.picScrivi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.picScrivi.Image = CType(resources.GetObject("picScrivi.Image"), System.Drawing.Image)
        Me.picScrivi.Location = New System.Drawing.Point(379, 2)
        Me.picScrivi.Name = "picScrivi"
        Me.picScrivi.Size = New System.Drawing.Size(32, 37)
        Me.picScrivi.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picScrivi.TabIndex = 11
        Me.picScrivi.TabStop = False
        Me.ToolTip1.SetToolTip(Me.picScrivi, "SCRIVI TESTO")
        '
        'PicEllissePieno
        '
        Me.PicEllissePieno.Cursor = System.Windows.Forms.Cursors.Hand
        Me.PicEllissePieno.Image = CType(resources.GetObject("PicEllissePieno.Image"), System.Drawing.Image)
        Me.PicEllissePieno.Location = New System.Drawing.Point(344, 47)
        Me.PicEllissePieno.Name = "PicEllissePieno"
        Me.PicEllissePieno.Size = New System.Drawing.Size(39, 37)
        Me.PicEllissePieno.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PicEllissePieno.TabIndex = 9
        Me.PicEllissePieno.TabStop = False
        Me.ToolTip1.SetToolTip(Me.PicEllissePieno, "ELLISSE PIENO")
        '
        'FontDialog1
        '
        Me.FontDialog1.Font = New System.Drawing.Font("Arial", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(1107, 388)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 3
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "open image"
        '
        'TrackBarR
        '
        Me.TrackBarR.BackColor = System.Drawing.Color.Red
        Me.TrackBarR.Location = New System.Drawing.Point(505, 97)
        Me.TrackBarR.Maximum = 100
        Me.TrackBarR.Name = "TrackBarR"
        Me.TrackBarR.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarR.Size = New System.Drawing.Size(45, 138)
        Me.TrackBarR.TabIndex = 4
        Me.TrackBarR.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'TrackBarG
        '
        Me.TrackBarG.BackColor = System.Drawing.Color.Lime
        Me.TrackBarG.Location = New System.Drawing.Point(505, 241)
        Me.TrackBarG.Maximum = 100
        Me.TrackBarG.Name = "TrackBarG"
        Me.TrackBarG.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarG.Size = New System.Drawing.Size(45, 138)
        Me.TrackBarG.TabIndex = 5
        Me.TrackBarG.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'TrackBarB
        '
        Me.TrackBarB.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.TrackBarB.Location = New System.Drawing.Point(505, 385)
        Me.TrackBarB.Maximum = 100
        Me.TrackBarB.Name = "TrackBarB"
        Me.TrackBarB.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.TrackBarB.Size = New System.Drawing.Size(45, 138)
        Me.TrackBarB.TabIndex = 6
        Me.TrackBarB.TickStyle = System.Windows.Forms.TickStyle.None
        '
        'PictureBox0
        '
        Me.PictureBox0.Location = New System.Drawing.Point(505, 535)
        Me.PictureBox0.Name = "PictureBox0"
        Me.PictureBox0.Size = New System.Drawing.Size(44, 41)
        Me.PictureBox0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox0.TabIndex = 7
        Me.PictureBox0.TabStop = False
        Me.PictureBox0.Visible = False
        '
        'PictureBox6
        '
        Me.PictureBox6.BackColor = System.Drawing.Color.White
        Me.PictureBox6.Location = New System.Drawing.Point(17, 97)
        Me.PictureBox6.Name = "PictureBox6"
        Me.PictureBox6.Size = New System.Drawing.Size(480, 480)
        Me.PictureBox6.TabIndex = 0
        Me.PictureBox6.TabStop = False
        '
        'frmDisegna
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(557, 590)
        Me.Controls.Add(Me.PictureBox0)
        Me.Controls.Add(Me.TrackBarB)
        Me.Controls.Add(Me.TrackBarG)
        Me.Controls.Add(Me.TrackBarR)
        Me.Controls.Add(Me.PictureBox6)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmDisegna"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Disegna per LeggiXme"
        Me.TopMost = True
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picScegliColore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRettangoloVuoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picEllisseVuoto, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picCarattere, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picPennello, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UpDownSpessore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picRettangoloPieno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picLinea, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picScrivi, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PicEllissePieno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarG, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBarB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox0, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents UpDownSpessore As System.Windows.Forms.NumericUpDown
    Friend WithEvents picLinea As System.Windows.Forms.PictureBox
    Friend WithEvents PicEllissePieno As System.Windows.Forms.PictureBox
    Friend WithEvents picRettangoloPieno As System.Windows.Forms.PictureBox
    Friend WithEvents picScrivi As System.Windows.Forms.PictureBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents FontDialog1 As System.Windows.Forms.FontDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnNuovo As System.Windows.Forms.Button
    Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
    Friend WithEvents picPennello As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSalva As System.Windows.Forms.Button
    Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
    Friend WithEvents picCarattere As System.Windows.Forms.PictureBox
    Friend WithEvents picEllisseVuoto As System.Windows.Forms.PictureBox
    Friend WithEvents picRettangoloVuoto As System.Windows.Forms.PictureBox
    Friend WithEvents picScegliColore As System.Windows.Forms.PictureBox
    Friend WithEvents btnApri As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
    Friend WithEvents lblColore As System.Windows.Forms.Label
    Friend WithEvents btnAnnulla As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnIncolla As System.Windows.Forms.Button
    Friend WithEvents btnCopia As System.Windows.Forms.Button
    Friend WithEvents TrackBarR As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarG As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBarB As System.Windows.Forms.TrackBar
    Friend WithEvents PictureBox0 As System.Windows.Forms.PictureBox
    Friend WithEvents btnOK As System.Windows.Forms.Button

End Class
