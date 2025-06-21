<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class frmCalcolatrice
#Region "Codice generato da Progettazione Windows Form "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'Chiamata richiesta dalla progettazione Windows Form.
		InitializeComponent()
        System.Windows.Forms.Application.EnableVisualStyles()
    End Sub
	'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Richiesto da Progettazione Windows Form
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents ckNumeri As System.Windows.Forms.CheckBox
	Public WithEvents ckCifre As System.Windows.Forms.CheckBox
	Public WithEvents cmdTutto As System.Windows.Forms.Button
    Public WithEvents btnLeggi As System.Windows.Forms.Button
    Public WithEvents txtMemo1 As System.Windows.Forms.TextBox
    Public WithEvents CmdEq As System.Windows.Forms.Button
    Public WithEvents CmdBack As System.Windows.Forms.Button
    Public WithEvents CmdCE As System.Windows.Forms.Button
    Public WithEvents CmdC As System.Windows.Forms.Button
    Public WithEvents CmdD As System.Windows.Forms.Button
    Public WithEvents CmdMu As System.Windows.Forms.Button
    Public WithEvents CmdMi As System.Windows.Forms.Button
    Public WithEvents CmdP As System.Windows.Forms.Button
    Public WithEvents Dot As System.Windows.Forms.Button
    Public WithEvents _num_9 As System.Windows.Forms.Button
    Public WithEvents _num_8 As System.Windows.Forms.Button
    Public WithEvents _num_7 As System.Windows.Forms.Button
    Public WithEvents _num_6 As System.Windows.Forms.Button
    Public WithEvents _num_5 As System.Windows.Forms.Button
    Public WithEvents _num_4 As System.Windows.Forms.Button
    Public WithEvents _num_3 As System.Windows.Forms.Button
    Public WithEvents _num_2 As System.Windows.Forms.Button
    Public WithEvents _num_1 As System.Windows.Forms.Button
    Public WithEvents _num_0 As System.Windows.Forms.Button
    Public WithEvents txt As System.Windows.Forms.TextBox
    'Public WithEvents num As Microsoft.VisualBasic.Compatibility.VB6.ButtonArray
    'NOTA: la routine che segue è richiesta da Progettazione Windows Form.
    'Può essere modificata in Progettazione Windows Form.
    'Non modificarla nell'editor del codice.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCalcolatrice))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdTutto = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.ckNumeri = New System.Windows.Forms.CheckBox
        Me.ckCifre = New System.Windows.Forms.CheckBox
        Me.btnLeggi = New System.Windows.Forms.Button
        Me.txtMemo1 = New System.Windows.Forms.TextBox
        Me.CmdEq = New System.Windows.Forms.Button
        Me.CmdBack = New System.Windows.Forms.Button
        Me.CmdCE = New System.Windows.Forms.Button
        Me.CmdC = New System.Windows.Forms.Button
        Me.CmdD = New System.Windows.Forms.Button
        Me.CmdMu = New System.Windows.Forms.Button
        Me.CmdMi = New System.Windows.Forms.Button
        Me.CmdP = New System.Windows.Forms.Button
        Me.Dot = New System.Windows.Forms.Button
        Me._num_9 = New System.Windows.Forms.Button
        Me._num_8 = New System.Windows.Forms.Button
        Me._num_7 = New System.Windows.Forms.Button
        Me._num_6 = New System.Windows.Forms.Button
        Me._num_5 = New System.Windows.Forms.Button
        Me._num_4 = New System.Windows.Forms.Button
        Me._num_3 = New System.Windows.Forms.Button
        Me._num_2 = New System.Windows.Forms.Button
        Me._num_1 = New System.Windows.Forms.Button
        Me._num_0 = New System.Windows.Forms.Button
        Me.txt = New System.Windows.Forms.TextBox
        Me.btnCopia = New System.Windows.Forms.Button
        Me.btnCopiaT = New System.Windows.Forms.Button
        Me.btnIncolla = New System.Windows.Forms.Button
        Me.btnPrec = New System.Windows.Forms.Button
        Me.btnSeg = New System.Windows.Forms.Button
        Me.cmdRQ = New System.Windows.Forms.Button
        Me.cmdQu = New System.Windows.Forms.Button
        Me.MaxDecim = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtMemo = New System.Windows.Forms.RichTextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.MaxDecim, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdTutto
        '
        Me.cmdTutto.BackColor = System.Drawing.SystemColors.Menu
        Me.cmdTutto.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdTutto.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdTutto.Image = CType(resources.GetObject("cmdTutto.Image"), System.Drawing.Image)
        Me.cmdTutto.Location = New System.Drawing.Point(198, 44)
        Me.cmdTutto.Name = "cmdTutto"
        Me.cmdTutto.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdTutto.Size = New System.Drawing.Size(40, 41)
        Me.cmdTutto.TabIndex = 24
        Me.cmdTutto.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.cmdTutto, " Leggi tutto il testo ")
        Me.cmdTutto.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.Yellow
        Me.Button2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button2.Image = CType(resources.GetObject("Button2.Image"), System.Drawing.Image)
        Me.Button2.Location = New System.Drawing.Point(927, 295)
        Me.Button2.Name = "Button2"
        Me.Button2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button2.Size = New System.Drawing.Size(42, 40)
        Me.Button2.TabIndex = 38
        Me.ToolTip1.SetToolTip(Me.Button2, "RICHIUDI")
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.LightBlue
        Me.Button3.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button3.Location = New System.Drawing.Point(505, 295)
        Me.Button3.Name = "Button3"
        Me.Button3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button3.Size = New System.Drawing.Size(57, 39)
        Me.Button3.TabIndex = 39
        Me.Button3.Text = "x÷"
        Me.ToolTip1.SetToolTip(Me.Button3, "Allarga Pannello")
        Me.Button3.UseVisualStyleBackColor = False
        '
        'ckNumeri
        '
        Me.ckNumeri.BackColor = System.Drawing.Color.LightBlue
        Me.ckNumeri.Checked = True
        Me.ckNumeri.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ckNumeri.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ckNumeri.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckNumeri.ForeColor = System.Drawing.Color.Black
        Me.ckNumeri.Location = New System.Drawing.Point(126, 274)
        Me.ckNumeri.Name = "ckNumeri"
        Me.ckNumeri.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckNumeri.Size = New System.Drawing.Size(122, 25)
        Me.ckNumeri.TabIndex = 26
        Me.ckNumeri.Text = "LEGGI NUMERI"
        Me.ckNumeri.UseVisualStyleBackColor = False
        '
        'ckCifre
        '
        Me.ckCifre.BackColor = System.Drawing.Color.LightBlue
        Me.ckCifre.Cursor = System.Windows.Forms.Cursors.Hand
        Me.ckCifre.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ckCifre.ForeColor = System.Drawing.Color.Black
        Me.ckCifre.Location = New System.Drawing.Point(6, 274)
        Me.ckCifre.Name = "ckCifre"
        Me.ckCifre.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ckCifre.Size = New System.Drawing.Size(114, 25)
        Me.ckCifre.TabIndex = 25
        Me.ckCifre.Text = "LEGGI CIFRE"
        Me.ckCifre.UseVisualStyleBackColor = False
        '
        'btnLeggi
        '
        Me.btnLeggi.BackColor = System.Drawing.Color.Yellow
        Me.btnLeggi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnLeggi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnLeggi.Image = CType(resources.GetObject("btnLeggi.Image"), System.Drawing.Image)
        Me.btnLeggi.Location = New System.Drawing.Point(328, 293)
        Me.btnLeggi.Name = "btnLeggi"
        Me.btnLeggi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnLeggi.Size = New System.Drawing.Size(42, 40)
        Me.btnLeggi.TabIndex = 23
        Me.btnLeggi.UseVisualStyleBackColor = False
        '
        'txtMemo1
        '
        Me.txtMemo1.AcceptsReturn = True
        Me.txtMemo1.BackColor = System.Drawing.SystemColors.Window
        Me.txtMemo1.Cursor = System.Windows.Forms.Cursors.IBeam
        Me.txtMemo1.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemo1.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtMemo1.HideSelection = False
        Me.txtMemo1.Location = New System.Drawing.Point(257, 6)
        Me.txtMemo1.MaxLength = 0
        Me.txtMemo1.Multiline = True
        Me.txtMemo1.Name = "txtMemo1"
        Me.txtMemo1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtMemo1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMemo1.Size = New System.Drawing.Size(306, 279)
        Me.txtMemo1.TabIndex = 20
        Me.txtMemo1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CmdEq
        '
        Me.CmdEq.BackColor = System.Drawing.Color.PaleTurquoise
        Me.CmdEq.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdEq.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdEq.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdEq.Location = New System.Drawing.Point(198, 89)
        Me.CmdEq.Name = "CmdEq"
        Me.CmdEq.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdEq.Size = New System.Drawing.Size(40, 135)
        Me.CmdEq.TabIndex = 19
        Me.CmdEq.TabStop = False
        Me.CmdEq.Text = "="
        Me.CmdEq.UseVisualStyleBackColor = False
        '
        'CmdBack
        '
        Me.CmdBack.BackColor = System.Drawing.Color.LightBlue
        Me.CmdBack.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdBack.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdBack.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdBack.Location = New System.Drawing.Point(6, 44)
        Me.CmdBack.Name = "CmdBack"
        Me.CmdBack.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdBack.Size = New System.Drawing.Size(89, 36)
        Me.CmdBack.TabIndex = 18
        Me.CmdBack.TabStop = False
        Me.CmdBack.Text = "<CANC"
        Me.CmdBack.UseVisualStyleBackColor = False
        '
        'CmdCE
        '
        Me.CmdCE.BackColor = System.Drawing.Color.LightBlue
        Me.CmdCE.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdCE.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdCE.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdCE.Location = New System.Drawing.Point(102, 44)
        Me.CmdCE.Name = "CmdCE"
        Me.CmdCE.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdCE.Size = New System.Drawing.Size(40, 37)
        Me.CmdCE.TabIndex = 17
        Me.CmdCE.TabStop = False
        Me.CmdCE.Text = "CE"
        Me.CmdCE.UseVisualStyleBackColor = False
        '
        'CmdC
        '
        Me.CmdC.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.CmdC.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdC.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdC.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdC.Location = New System.Drawing.Point(224, 259)
        Me.CmdC.Name = "CmdC"
        Me.CmdC.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdC.Size = New System.Drawing.Size(41, 37)
        Me.CmdC.TabIndex = 16
        Me.CmdC.TabStop = False
        Me.CmdC.Text = "C"
        Me.CmdC.UseVisualStyleBackColor = False
        Me.CmdC.Visible = False
        '
        'CmdD
        '
        Me.CmdD.BackColor = System.Drawing.Color.PaleTurquoise
        Me.CmdD.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdD.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdD.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdD.Location = New System.Drawing.Point(150, 232)
        Me.CmdD.Name = "CmdD"
        Me.CmdD.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdD.Size = New System.Drawing.Size(40, 40)
        Me.CmdD.TabIndex = 15
        Me.CmdD.TabStop = False
        Me.CmdD.Text = "÷"
        Me.CmdD.UseVisualStyleBackColor = False
        '
        'CmdMu
        '
        Me.CmdMu.BackColor = System.Drawing.Color.PaleTurquoise
        Me.CmdMu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdMu.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdMu.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdMu.Location = New System.Drawing.Point(150, 184)
        Me.CmdMu.Name = "CmdMu"
        Me.CmdMu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdMu.Size = New System.Drawing.Size(40, 40)
        Me.CmdMu.TabIndex = 14
        Me.CmdMu.TabStop = False
        Me.CmdMu.Text = "x"
        Me.CmdMu.UseVisualStyleBackColor = False
        '
        'CmdMi
        '
        Me.CmdMi.BackColor = System.Drawing.Color.PaleTurquoise
        Me.CmdMi.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdMi.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdMi.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdMi.Location = New System.Drawing.Point(150, 136)
        Me.CmdMi.Name = "CmdMi"
        Me.CmdMi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdMi.Size = New System.Drawing.Size(40, 40)
        Me.CmdMi.TabIndex = 13
        Me.CmdMi.TabStop = False
        Me.CmdMi.Text = "_"
        Me.CmdMi.TextAlign = System.Drawing.ContentAlignment.TopCenter
        Me.CmdMi.UseVisualStyleBackColor = False
        '
        'CmdP
        '
        Me.CmdP.BackColor = System.Drawing.Color.PaleTurquoise
        Me.CmdP.Cursor = System.Windows.Forms.Cursors.Hand
        Me.CmdP.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CmdP.ForeColor = System.Drawing.SystemColors.ControlText
        Me.CmdP.Location = New System.Drawing.Point(150, 88)
        Me.CmdP.Name = "CmdP"
        Me.CmdP.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.CmdP.Size = New System.Drawing.Size(40, 40)
        Me.CmdP.TabIndex = 12
        Me.CmdP.TabStop = False
        Me.CmdP.Text = "+"
        Me.CmdP.UseVisualStyleBackColor = False
        '
        'Dot
        '
        Me.Dot.BackColor = System.Drawing.Color.White
        Me.Dot.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Dot.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Dot.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Dot.Location = New System.Drawing.Point(198, 232)
        Me.Dot.Name = "Dot"
        Me.Dot.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Dot.Size = New System.Drawing.Size(40, 40)
        Me.Dot.TabIndex = 11
        Me.Dot.TabStop = False
        Me.Dot.Text = ","
        Me.Dot.UseVisualStyleBackColor = False
        '
        '_num_9
        '
        Me._num_9.BackColor = System.Drawing.Color.White
        Me._num_9.Cursor = System.Windows.Forms.Cursors.Hand
        Me._num_9.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._num_9.ForeColor = System.Drawing.SystemColors.ControlText
        Me._num_9.Location = New System.Drawing.Point(102, 88)
        Me._num_9.Name = "_num_9"
        Me._num_9.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._num_9.Size = New System.Drawing.Size(40, 40)
        Me._num_9.TabIndex = 10
        Me._num_9.TabStop = False
        Me._num_9.Text = "9"
        Me._num_9.UseVisualStyleBackColor = False
        '
        '_num_8
        '
        Me._num_8.BackColor = System.Drawing.Color.White
        Me._num_8.Cursor = System.Windows.Forms.Cursors.Hand
        Me._num_8.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._num_8.ForeColor = System.Drawing.SystemColors.ControlText
        Me._num_8.Location = New System.Drawing.Point(54, 88)
        Me._num_8.Name = "_num_8"
        Me._num_8.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._num_8.Size = New System.Drawing.Size(40, 40)
        Me._num_8.TabIndex = 9
        Me._num_8.TabStop = False
        Me._num_8.Text = "8"
        Me._num_8.UseVisualStyleBackColor = False
        '
        '_num_7
        '
        Me._num_7.BackColor = System.Drawing.Color.White
        Me._num_7.Cursor = System.Windows.Forms.Cursors.Hand
        Me._num_7.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._num_7.ForeColor = System.Drawing.SystemColors.ControlText
        Me._num_7.Location = New System.Drawing.Point(6, 88)
        Me._num_7.Name = "_num_7"
        Me._num_7.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._num_7.Size = New System.Drawing.Size(40, 40)
        Me._num_7.TabIndex = 8
        Me._num_7.TabStop = False
        Me._num_7.Text = "7"
        Me._num_7.UseVisualStyleBackColor = False
        '
        '_num_6
        '
        Me._num_6.BackColor = System.Drawing.Color.White
        Me._num_6.Cursor = System.Windows.Forms.Cursors.Hand
        Me._num_6.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._num_6.ForeColor = System.Drawing.SystemColors.ControlText
        Me._num_6.Location = New System.Drawing.Point(102, 136)
        Me._num_6.Name = "_num_6"
        Me._num_6.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._num_6.Size = New System.Drawing.Size(40, 40)
        Me._num_6.TabIndex = 7
        Me._num_6.TabStop = False
        Me._num_6.Text = "6"
        Me._num_6.UseVisualStyleBackColor = False
        '
        '_num_5
        '
        Me._num_5.BackColor = System.Drawing.Color.White
        Me._num_5.Cursor = System.Windows.Forms.Cursors.Hand
        Me._num_5.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._num_5.ForeColor = System.Drawing.SystemColors.ControlText
        Me._num_5.Location = New System.Drawing.Point(54, 136)
        Me._num_5.Name = "_num_5"
        Me._num_5.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._num_5.Size = New System.Drawing.Size(40, 40)
        Me._num_5.TabIndex = 6
        Me._num_5.TabStop = False
        Me._num_5.Text = "5"
        Me._num_5.UseVisualStyleBackColor = False
        '
        '_num_4
        '
        Me._num_4.BackColor = System.Drawing.Color.White
        Me._num_4.Cursor = System.Windows.Forms.Cursors.Hand
        Me._num_4.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._num_4.ForeColor = System.Drawing.SystemColors.ControlText
        Me._num_4.Location = New System.Drawing.Point(6, 136)
        Me._num_4.Name = "_num_4"
        Me._num_4.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._num_4.Size = New System.Drawing.Size(40, 40)
        Me._num_4.TabIndex = 5
        Me._num_4.TabStop = False
        Me._num_4.Text = "4"
        Me._num_4.UseVisualStyleBackColor = False
        '
        '_num_3
        '
        Me._num_3.BackColor = System.Drawing.Color.White
        Me._num_3.Cursor = System.Windows.Forms.Cursors.Hand
        Me._num_3.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._num_3.ForeColor = System.Drawing.SystemColors.ControlText
        Me._num_3.Location = New System.Drawing.Point(102, 184)
        Me._num_3.Name = "_num_3"
        Me._num_3.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._num_3.Size = New System.Drawing.Size(40, 40)
        Me._num_3.TabIndex = 4
        Me._num_3.TabStop = False
        Me._num_3.Text = "3"
        Me._num_3.UseVisualStyleBackColor = False
        '
        '_num_2
        '
        Me._num_2.BackColor = System.Drawing.Color.White
        Me._num_2.Cursor = System.Windows.Forms.Cursors.Hand
        Me._num_2.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._num_2.ForeColor = System.Drawing.SystemColors.ControlText
        Me._num_2.Location = New System.Drawing.Point(54, 184)
        Me._num_2.Name = "_num_2"
        Me._num_2.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._num_2.Size = New System.Drawing.Size(40, 40)
        Me._num_2.TabIndex = 3
        Me._num_2.TabStop = False
        Me._num_2.Text = "2"
        Me._num_2.UseVisualStyleBackColor = False
        '
        '_num_1
        '
        Me._num_1.BackColor = System.Drawing.Color.White
        Me._num_1.Cursor = System.Windows.Forms.Cursors.Hand
        Me._num_1.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._num_1.ForeColor = System.Drawing.SystemColors.ControlText
        Me._num_1.Location = New System.Drawing.Point(6, 184)
        Me._num_1.Name = "_num_1"
        Me._num_1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._num_1.Size = New System.Drawing.Size(40, 40)
        Me._num_1.TabIndex = 2
        Me._num_1.TabStop = False
        Me._num_1.Text = "1"
        Me._num_1.UseVisualStyleBackColor = False
        '
        '_num_0
        '
        Me._num_0.BackColor = System.Drawing.Color.White
        Me._num_0.Cursor = System.Windows.Forms.Cursors.Hand
        Me._num_0.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._num_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._num_0.Location = New System.Drawing.Point(6, 232)
        Me._num_0.Name = "_num_0"
        Me._num_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._num_0.Size = New System.Drawing.Size(40, 40)
        Me._num_0.TabIndex = 1
        Me._num_0.TabStop = False
        Me._num_0.Text = "0"
        Me._num_0.UseVisualStyleBackColor = False
        '
        'txt
        '
        Me.txt.AcceptsReturn = True
        Me.txt.BackColor = System.Drawing.SystemColors.Window
        Me.txt.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.txt.Font = New System.Drawing.Font("Tahoma", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txt.HideSelection = False
        Me.txt.Location = New System.Drawing.Point(5, 6)
        Me.txt.MaxLength = 0
        Me.txt.Name = "txt"
        Me.txt.ReadOnly = True
        Me.txt.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txt.Size = New System.Drawing.Size(233, 27)
        Me.txt.TabIndex = 0
        Me.txt.TabStop = False
        Me.txt.Text = "0"
        Me.txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnCopia
        '
        Me.btnCopia.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.btnCopia.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopia.Font = New System.Drawing.Font("Verdana", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopia.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCopia.Image = CType(resources.GetObject("btnCopia.Image"), System.Drawing.Image)
        Me.btnCopia.Location = New System.Drawing.Point(152, 45)
        Me.btnCopia.Name = "btnCopia"
        Me.btnCopia.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCopia.Size = New System.Drawing.Size(40, 37)
        Me.btnCopia.TabIndex = 27
        Me.btnCopia.TabStop = False
        Me.btnCopia.UseVisualStyleBackColor = False
        '
        'btnCopiaT
        '
        Me.btnCopiaT.BackColor = System.Drawing.Color.LightBlue
        Me.btnCopiaT.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCopiaT.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnCopiaT.Location = New System.Drawing.Point(228, 306)
        Me.btnCopiaT.Name = "btnCopiaT"
        Me.btnCopiaT.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnCopiaT.Size = New System.Drawing.Size(49, 25)
        Me.btnCopiaT.TabIndex = 28
        Me.btnCopiaT.Text = "COPIA"
        Me.btnCopiaT.UseVisualStyleBackColor = False
        Me.btnCopiaT.Visible = False
        '
        'btnIncolla
        '
        Me.btnIncolla.BackColor = System.Drawing.Color.LightBlue
        Me.btnIncolla.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnIncolla.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnIncolla.Image = CType(resources.GetObject("btnIncolla.Image"), System.Drawing.Image)
        Me.btnIncolla.Location = New System.Drawing.Point(271, 294)
        Me.btnIncolla.Name = "btnIncolla"
        Me.btnIncolla.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnIncolla.Size = New System.Drawing.Size(42, 40)
        Me.btnIncolla.TabIndex = 29
        Me.btnIncolla.UseVisualStyleBackColor = False
        '
        'btnPrec
        '
        Me.btnPrec.BackColor = System.Drawing.Color.LightBlue
        Me.btnPrec.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnPrec.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrec.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnPrec.Location = New System.Drawing.Point(388, 295)
        Me.btnPrec.Name = "btnPrec"
        Me.btnPrec.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnPrec.Size = New System.Drawing.Size(40, 39)
        Me.btnPrec.TabIndex = 30
        Me.btnPrec.Text = "<<"
        Me.btnPrec.UseVisualStyleBackColor = False
        '
        'btnSeg
        '
        Me.btnSeg.BackColor = System.Drawing.Color.LightBlue
        Me.btnSeg.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnSeg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSeg.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSeg.Location = New System.Drawing.Point(451, 295)
        Me.btnSeg.Name = "btnSeg"
        Me.btnSeg.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnSeg.Size = New System.Drawing.Size(38, 39)
        Me.btnSeg.TabIndex = 31
        Me.btnSeg.Text = ">>"
        Me.btnSeg.UseVisualStyleBackColor = False
        '
        'cmdRQ
        '
        Me.cmdRQ.BackColor = System.Drawing.Color.PaleTurquoise
        Me.cmdRQ.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdRQ.Font = New System.Drawing.Font("Times New Roman", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdRQ.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdRQ.Image = CType(resources.GetObject("cmdRQ.Image"), System.Drawing.Image)
        Me.cmdRQ.Location = New System.Drawing.Point(101, 232)
        Me.cmdRQ.Name = "cmdRQ"
        Me.cmdRQ.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdRQ.Size = New System.Drawing.Size(40, 40)
        Me.cmdRQ.TabIndex = 32
        Me.cmdRQ.TabStop = False
        Me.cmdRQ.UseVisualStyleBackColor = False
        '
        'cmdQu
        '
        Me.cmdQu.BackColor = System.Drawing.Color.PaleTurquoise
        Me.cmdQu.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdQu.Font = New System.Drawing.Font("Verdana", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdQu.ForeColor = System.Drawing.SystemColors.ControlText
        Me.cmdQu.Location = New System.Drawing.Point(55, 232)
        Me.cmdQu.Name = "cmdQu"
        Me.cmdQu.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmdQu.Size = New System.Drawing.Size(40, 40)
        Me.cmdQu.TabIndex = 33
        Me.cmdQu.TabStop = False
        Me.cmdQu.Text = "x²"
        Me.cmdQu.UseVisualStyleBackColor = False
        '
        'MaxDecim
        '
        Me.MaxDecim.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaxDecim.Location = New System.Drawing.Point(181, 312)
        Me.MaxDecim.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.MaxDecim.Name = "MaxDecim"
        Me.MaxDecim.Size = New System.Drawing.Size(41, 22)
        Me.MaxDecim.TabIndex = 34
        Me.MaxDecim.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.MaxDecim.Value = New Decimal(New Integer() {3, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(8, 315)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(170, 16)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Numero Massimo Decimali"
        '
        'txtMemo
        '
        Me.txtMemo.Font = New System.Drawing.Font("Courier New", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMemo.Location = New System.Drawing.Point(593, 6)
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedBoth
        Me.txtMemo.Size = New System.Drawing.Size(383, 276)
        Me.txtMemo.TabIndex = 36
        Me.txtMemo.Text = ""
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LightBlue
        Me.Button1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Button1.Image = CType(resources.GetObject("Button1.Image"), System.Drawing.Image)
        Me.Button1.Location = New System.Drawing.Point(623, 298)
        Me.Button1.Name = "Button1"
        Me.Button1.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Button1.Size = New System.Drawing.Size(42, 40)
        Me.Button1.TabIndex = 37
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(673, 306)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(242, 20)
        Me.Label2.TabIndex = 40
        Me.Label2.Text = "MOLTIPLICAZIONI E DIVISIONI"
        '
        'frmCalcolatrice
        '
        Me.AcceptButton = Me.CmdEq
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(990, 348)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.MaxDecim)
        Me.Controls.Add(Me.btnSeg)
        Me.Controls.Add(Me.btnPrec)
        Me.Controls.Add(Me.btnIncolla)
        Me.Controls.Add(Me.btnCopiaT)
        Me.Controls.Add(Me.btnCopia)
        Me.Controls.Add(Me.ckNumeri)
        Me.Controls.Add(Me.ckCifre)
        Me.Controls.Add(Me.cmdTutto)
        Me.Controls.Add(Me.btnLeggi)
        Me.Controls.Add(Me.txtMemo1)
        Me.Controls.Add(Me.CmdEq)
        Me.Controls.Add(Me.CmdBack)
        Me.Controls.Add(Me.CmdCE)
        Me.Controls.Add(Me.CmdD)
        Me.Controls.Add(Me.CmdMu)
        Me.Controls.Add(Me.CmdMi)
        Me.Controls.Add(Me.CmdP)
        Me.Controls.Add(Me.Dot)
        Me.Controls.Add(Me._num_9)
        Me.Controls.Add(Me._num_8)
        Me.Controls.Add(Me._num_7)
        Me.Controls.Add(Me._num_6)
        Me.Controls.Add(Me._num_5)
        Me.Controls.Add(Me._num_4)
        Me.Controls.Add(Me._num_3)
        Me.Controls.Add(Me._num_2)
        Me.Controls.Add(Me._num_1)
        Me.Controls.Add(Me._num_0)
        Me.Controls.Add(Me.txt)
        Me.Controls.Add(Me.CmdC)
        Me.Controls.Add(Me.cmdQu)
        Me.Controls.Add(Me.cmdRQ)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(294, 205)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCalcolatrice"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Calcolatrice -di G. Serena"
        Me.TopMost = True
        CType(Me.MaxDecim, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Public WithEvents btnCopia As System.Windows.Forms.Button
    Public WithEvents btnCopiaT As System.Windows.Forms.Button
    Public WithEvents btnIncolla As System.Windows.Forms.Button
    Public WithEvents btnPrec As System.Windows.Forms.Button
    Public WithEvents btnSeg As System.Windows.Forms.Button
    Public WithEvents cmdRQ As System.Windows.Forms.Button
    Public WithEvents cmdQu As System.Windows.Forms.Button
    Friend WithEvents MaxDecim As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtMemo As System.Windows.Forms.RichTextBox
    Public WithEvents Button1 As System.Windows.Forms.Button
    Public WithEvents Button2 As System.Windows.Forms.Button
    Public WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
#End Region 
End Class