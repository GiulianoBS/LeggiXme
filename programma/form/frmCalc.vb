'This Calculator is made by Fahad Yousaf
'aahat89@hotmail.com
'MSC-E.commerce
'*************************************************
Imports System.Math

Public Class frmCalc

    Inherits System.Windows.Forms.Form
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents Button19 As System.Windows.Forms.Button
    Friend WithEvents Button20 As System.Windows.Forms.Button
    Friend WithEvents Button21 As System.Windows.Forms.Button
    Friend WithEvents Button22 As System.Windows.Forms.Button
    Friend WithEvents Button23 As System.Windows.Forms.Button
    Friend WithEvents Button24 As System.Windows.Forms.Button
    Friend WithEvents Button25 As System.Windows.Forms.Button
    Friend WithEvents Button30 As System.Windows.Forms.Button
    Friend WithEvents Button29 As System.Windows.Forms.Button
    Friend WithEvents Button28 As System.Windows.Forms.Button
    Friend WithEvents Button27 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Button26 As System.Windows.Forms.Button
    Friend WithEvents Button31 As System.Windows.Forms.Button
    Friend WithEvents Button32 As System.Windows.Forms.Button
    Friend WithEvents Button33 As System.Windows.Forms.Button
    Friend WithEvents Button34 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents RadioButton2 As System.Windows.Forms.RadioButton
    Friend WithEvents RadioButton1 As System.Windows.Forms.RadioButton
    Friend WithEvents Button35 As System.Windows.Forms.Button
    Friend WithEvents Button36 As System.Windows.Forms.Button
    Friend WithEvents Button37 As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents btnLeggi As System.Windows.Forms.Button
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.Button3 = New System.Windows.Forms.Button
        Me.Button4 = New System.Windows.Forms.Button
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.Button9 = New System.Windows.Forms.Button
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Button12 = New System.Windows.Forms.Button
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.Button15 = New System.Windows.Forms.Button
        Me.Button16 = New System.Windows.Forms.Button
        Me.Button17 = New System.Windows.Forms.Button
        Me.Button18 = New System.Windows.Forms.Button
        Me.Button19 = New System.Windows.Forms.Button
        Me.Button20 = New System.Windows.Forms.Button
        Me.Button21 = New System.Windows.Forms.Button
        Me.Button22 = New System.Windows.Forms.Button
        Me.Button23 = New System.Windows.Forms.Button
        Me.Button24 = New System.Windows.Forms.Button
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Button25 = New System.Windows.Forms.Button
        Me.Button30 = New System.Windows.Forms.Button
        Me.Button29 = New System.Windows.Forms.Button
        Me.Button28 = New System.Windows.Forms.Button
        Me.Button27 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Button26 = New System.Windows.Forms.Button
        Me.Button31 = New System.Windows.Forms.Button
        Me.Button32 = New System.Windows.Forms.Button
        Me.Button33 = New System.Windows.Forms.Button
        Me.Button34 = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.RadioButton2 = New System.Windows.Forms.RadioButton
        Me.RadioButton1 = New System.Windows.Forms.RadioButton
        Me.Button35 = New System.Windows.Forms.Button
        Me.Button36 = New System.Windows.Forms.Button
        Me.Button37 = New System.Windows.Forms.Button
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.MainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.btnLeggi = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(64, 256)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(40, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.Tag = "0"
        Me.Button1.Text = "0"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(160, 256)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(40, 32)
        Me.Button2.TabIndex = 1
        Me.Button2.Tag = "virgola"
        Me.Button2.Text = ","
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(256, 256)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(40, 32)
        Me.Button3.TabIndex = 2
        Me.Button3.Tag = "uguale"
        Me.Button3.Text = "="
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(208, 136)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(40, 32)
        Me.Button4.TabIndex = 3
        Me.Button4.Tag = "diviso"
        Me.Button4.Text = "/"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(64, 216)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(40, 32)
        Me.Button5.TabIndex = 4
        Me.Button5.Tag = "1"
        Me.Button5.Text = "1"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(112, 216)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(40, 32)
        Me.Button6.TabIndex = 5
        Me.Button6.Tag = "2"
        Me.Button6.Text = "2"
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(160, 216)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(40, 32)
        Me.Button7.TabIndex = 6
        Me.Button7.Tag = "3"
        Me.Button7.Text = "3"
        '
        'Button8
        '
        Me.Button8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button8.Location = New System.Drawing.Point(208, 176)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(40, 32)
        Me.Button8.TabIndex = 7
        Me.Button8.Tag = "per"
        Me.Button8.Text = "*"
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(64, 176)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(40, 32)
        Me.Button9.TabIndex = 8
        Me.Button9.Tag = "4"
        Me.Button9.Text = "4"
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(112, 176)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(40, 32)
        Me.Button10.TabIndex = 9
        Me.Button10.Tag = "5"
        Me.Button10.Text = "5"
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(160, 176)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(40, 32)
        Me.Button11.TabIndex = 10
        Me.Button11.Tag = "6"
        Me.Button11.Text = "6"
        '
        'Button12
        '
        Me.Button12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Button12.Location = New System.Drawing.Point(208, 216)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(40, 32)
        Me.Button12.TabIndex = 11
        Me.Button12.Tag = "meno"
        Me.Button12.Text = "-"
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(64, 136)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(40, 32)
        Me.Button13.TabIndex = 12
        Me.Button13.Tag = "7"
        Me.Button13.Text = "7"
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(112, 136)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(40, 32)
        Me.Button14.TabIndex = 13
        Me.Button14.Tag = "8"
        Me.Button14.Text = "8"
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(160, 136)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(40, 32)
        Me.Button15.TabIndex = 14
        Me.Button15.Tag = "9"
        Me.Button15.Text = "9"
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(208, 256)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(40, 32)
        Me.Button16.TabIndex = 15
        Me.Button16.Tag = "più"
        Me.Button16.Text = "+"
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(112, 256)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(40, 32)
        Me.Button17.TabIndex = 16
        Me.Button17.Tag = "inverti segno"
        Me.Button17.Text = "+/-"
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(304, 176)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(40, 32)
        Me.Button18.TabIndex = 17
        Me.Button18.Tag = "alla seconda"
        Me.Button18.Text = "x^2"
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(256, 176)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(40, 32)
        Me.Button19.TabIndex = 18
        Me.Button19.Tag = "frazione"
        Me.Button19.Text = "1/x"
        '
        'Button20
        '
        Me.Button20.Location = New System.Drawing.Point(256, 136)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(40, 32)
        Me.Button20.TabIndex = 19
        Me.Button20.Tag = "radice quadrata"
        Me.Button20.Text = "RaQ"
        '
        'Button21
        '
        Me.Button21.Location = New System.Drawing.Point(352, 136)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(40, 32)
        Me.Button21.TabIndex = 20
        Me.Button21.Tag = "seno"
        Me.Button21.Text = "Sin"
        '
        'Button22
        '
        Me.Button22.Location = New System.Drawing.Point(352, 176)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(40, 32)
        Me.Button22.TabIndex = 21
        Me.Button22.Tag = "coseno"
        Me.Button22.Text = "Cos"
        '
        'Button23
        '
        Me.Button23.Location = New System.Drawing.Point(352, 216)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(40, 32)
        Me.Button23.TabIndex = 22
        Me.Button23.Tag = "tangente"
        Me.Button23.Text = "Tan"
        '
        'Button24
        '
        Me.Button24.Location = New System.Drawing.Point(352, 256)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(40, 32)
        Me.Button24.TabIndex = 23
        Me.Button24.Tag = "logaritmo"
        Me.Button24.Text = "Log"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(16, 16)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(340, 24)
        Me.TextBox1.TabIndex = 27
        Me.TextBox1.Text = "0"
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Button25
        '
        Me.Button25.Location = New System.Drawing.Point(352, 56)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(40, 32)
        Me.Button25.TabIndex = 28
        Me.Button25.Tag = "cancella numero"
        Me.Button25.Text = "CE"
        '
        'Button30
        '
        Me.Button30.Location = New System.Drawing.Point(304, 256)
        Me.Button30.Name = "Button30"
        Me.Button30.Size = New System.Drawing.Size(40, 32)
        Me.Button30.TabIndex = 37
        Me.Button30.Tag = "alla ennesima"
        Me.Button30.Text = "x^n"
        '
        'Button29
        '
        Me.Button29.Location = New System.Drawing.Point(256, 96)
        Me.Button29.Name = "Button29"
        Me.Button29.Size = New System.Drawing.Size(40, 32)
        Me.Button29.TabIndex = 36
        Me.Button29.Tag = "pi greco"
        Me.Button29.Text = "pi"
        '
        'Button28
        '
        Me.Button28.Location = New System.Drawing.Point(304, 136)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(40, 32)
        Me.Button28.TabIndex = 35
        Me.Button28.Tag = "modulo"
        Me.Button28.Text = "Mod"
        '
        'Button27
        '
        Me.Button27.Location = New System.Drawing.Point(256, 216)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(40, 32)
        Me.Button27.TabIndex = 34
        Me.Button27.Tag = "percento"
        Me.Button27.Text = "%"
        '
        'CheckBox1
        '
        Me.CheckBox1.Location = New System.Drawing.Point(16, 56)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(48, 32)
        Me.CheckBox1.TabIndex = 38
        Me.CheckBox1.Text = "Inv"
        '
        'Button26
        '
        Me.Button26.Location = New System.Drawing.Point(256, 56)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(88, 32)
        Me.Button26.TabIndex = 39
        Me.Button26.Tag = "cancella cifra"
        Me.Button26.Text = "< Cancella"
        '
        'Button31
        '
        Me.Button31.Location = New System.Drawing.Point(16, 256)
        Me.Button31.Name = "Button31"
        Me.Button31.Size = New System.Drawing.Size(40, 32)
        Me.Button31.TabIndex = 44
        Me.Button31.Text = "M+"
        '
        'Button32
        '
        Me.Button32.Location = New System.Drawing.Point(16, 216)
        Me.Button32.Name = "Button32"
        Me.Button32.Size = New System.Drawing.Size(40, 32)
        Me.Button32.TabIndex = 43
        Me.Button32.Text = "MS"
        '
        'Button33
        '
        Me.Button33.Location = New System.Drawing.Point(16, 176)
        Me.Button33.Name = "Button33"
        Me.Button33.Size = New System.Drawing.Size(40, 32)
        Me.Button33.TabIndex = 42
        Me.Button33.Text = "MC"
        '
        'Button34
        '
        Me.Button34.Location = New System.Drawing.Point(16, 136)
        Me.Button34.Name = "Button34"
        Me.Button34.Size = New System.Drawing.Size(40, 32)
        Me.Button34.TabIndex = 41
        Me.Button34.Text = "MR"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioButton2)
        Me.GroupBox1.Controls.Add(Me.RadioButton1)
        Me.GroupBox1.Location = New System.Drawing.Point(64, 48)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(184, 40)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        '
        'RadioButton2
        '
        Me.RadioButton2.Location = New System.Drawing.Point(104, 8)
        Me.RadioButton2.Name = "RadioButton2"
        Me.RadioButton2.Size = New System.Drawing.Size(64, 24)
        Me.RadioButton2.TabIndex = 1
        Me.RadioButton2.Text = "Radianti"
        '
        'RadioButton1
        '
        Me.RadioButton1.Checked = True
        Me.RadioButton1.Location = New System.Drawing.Point(16, 8)
        Me.RadioButton1.Name = "RadioButton1"
        Me.RadioButton1.Size = New System.Drawing.Size(72, 24)
        Me.RadioButton1.TabIndex = 0
        Me.RadioButton1.TabStop = True
        Me.RadioButton1.Text = "Gradi"
        '
        'Button35
        '
        Me.Button35.Location = New System.Drawing.Point(352, 96)
        Me.Button35.Name = "Button35"
        Me.Button35.Size = New System.Drawing.Size(40, 32)
        Me.Button35.TabIndex = 45
        Me.Button35.Tag = "esponenziale"
        Me.Button35.Text = "Exp"
        '
        'Button36
        '
        Me.Button36.Location = New System.Drawing.Point(304, 96)
        Me.Button36.Name = "Button36"
        Me.Button36.Size = New System.Drawing.Size(40, 32)
        Me.Button36.TabIndex = 46
        Me.Button36.Tag = "fattoriale"
        Me.Button36.Text = "n!"
        '
        'Button37
        '
        Me.Button37.Location = New System.Drawing.Point(304, 216)
        Me.Button37.Name = "Button37"
        Me.Button37.Size = New System.Drawing.Size(40, 32)
        Me.Button37.TabIndex = 47
        Me.Button37.Tag = "allaterza"
        Me.Button37.Text = "x^3"
        '
        'TextBox2
        '
        Me.TextBox2.BackColor = System.Drawing.SystemColors.InactiveBorder
        Me.TextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox2.Location = New System.Drawing.Point(64, 96)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(184, 32)
        Me.TextBox2.TabIndex = 48
        Me.TextBox2.Visible = False
        '
        'Label1
        '
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(178, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 32)
        Me.Label1.TabIndex = 49
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.Label1.Visible = False
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem7})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3})
        Me.MenuItem1.Text = "&Modifica"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Shortcut = System.Windows.Forms.Shortcut.CtrlC
        Me.MenuItem2.Text = "&Copia"
        '
        'MenuItem3
        '
        Me.MenuItem3.Enabled = False
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Shortcut = System.Windows.Forms.Shortcut.CtrlV
        Me.MenuItem3.Text = "&Incolla"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = 1
        Me.MenuItem7.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem5})
        Me.MenuItem7.Text = "Im&postazioni"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 0
        Me.MenuItem5.RadioCheck = True
        Me.MenuItem5.Text = "Leggi Tasti"
        '
        'btnLeggi
        '
        Me.btnLeggi.Image = Global.LeggiXme.My.Resources.Resources.AUDIO
        Me.btnLeggi.Location = New System.Drawing.Point(361, 12)
        Me.btnLeggi.Name = "btnLeggi"
        Me.btnLeggi.Size = New System.Drawing.Size(31, 32)
        Me.btnLeggi.TabIndex = 50
        Me.btnLeggi.UseVisualStyleBackColor = True
        '
        'frmCalc
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.LightBlue
        Me.ClientSize = New System.Drawing.Size(405, 294)
        Me.Controls.Add(Me.btnLeggi)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.Button37)
        Me.Controls.Add(Me.Button36)
        Me.Controls.Add(Me.Button35)
        Me.Controls.Add(Me.Button31)
        Me.Controls.Add(Me.Button32)
        Me.Controls.Add(Me.Button33)
        Me.Controls.Add(Me.Button34)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Button26)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button30)
        Me.Controls.Add(Me.Button29)
        Me.Controls.Add(Me.Button28)
        Me.Controls.Add(Me.Button27)
        Me.Controls.Add(Me.Button25)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Button24)
        Me.Controls.Add(Me.Button23)
        Me.Controls.Add(Me.Button22)
        Me.Controls.Add(Me.Button21)
        Me.Controls.Add(Me.Button20)
        Me.Controls.Add(Me.Button19)
        Me.Controls.Add(Me.Button18)
        Me.Controls.Add(Me.Button17)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Menu = Me.MainMenu1
        Me.Name = "frmCalc"
        Me.Text = "Calcolatrice - Idea di Fahad Yousaf"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region
    Dim clearit As Boolean
    Dim operand1, operand2 As Double
    Dim [operator], ms As String
    Dim result, memory As Double
    Dim i As Short
    Dim a, n As Long

    'Private WithEvents Voce As SpeechSynthesizer

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click, Button5.Click, Button6.Click, Button7.Click, Button9.Click, Button10.Click, Button11.Click, Button13.Click, Button14.Click, Button15.Click
        If TextBox1.Text = "0" Then
            TextBox1.Text = ""
        End If
        If clearit Then
            TextBox1.Text = ""
            clearit = False
        End If
        If clearit = False Then
            TextBox1.Text = TextBox1.Text & sender.text
        End If

    End Sub
    Private Sub Button25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button25.Click
        TextBox1.Text = "0"
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        clearit = True
        operand1 = Val(MettiPunto(TextBox1.Text))
        [operator] = "+"
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        clearit = True
        operand2 = Val(MettiPunto(TextBox1.Text))
        If [operator] = "+" Then
            result = operand1 + operand2
        ElseIf [operator] = "*" Then
            result = operand1 * operand2
        ElseIf [operator] = "-" Then
            result = operand1 - operand2
        ElseIf [operator] = "/" And operand2 <> 0 Then
            result = operand1 / operand2
        ElseIf [operator] = "x^y" Then
            result = Pow(operand1, operand2)
        ElseIf [operator] = "mod" Then
            result = operand1 Mod operand2
        End If
        TextBox1.Text = MettiLaVirgola(result.ToString)
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        clearit = True
        operand1 = Val(MettiPunto(TextBox1.Text))
        [operator] = "-"
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        clearit = True
        operand1 = Val(MettiPunto(TextBox1.Text))
        [operator] = "*"
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        clearit = True
        operand1 = Val(MettiPunto(TextBox1.Text))
        [operator] = "/"
    End Sub

    Private Sub Button26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button26.Click
        If Len(TextBox1.Text) = 1 Then
            TextBox1.Text = "0"
        Else
            TextBox1.Text = Mid(TextBox1.Text, 1, Len(TextBox1.Text) - 1)
        End If
    End Sub

    Private Sub Button20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button20.Click
        If TextBox1.Text >= 0 Then
            TextBox1.Text = MettiLaVirgola(Sqrt(Val(TextBox1.Text)).ToString)
        Else
            TextBox1.Text = "E"
        End If
    End Sub

    Private Sub Button21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button21.Click
        If CheckBox1.Checked = True Then
            If RadioButton1.Checked = True Then
                TextBox1.Text = MettiLaVirgola((1 / Sin(Val(TextBox1.Text) * PI / 180)).ToString)
                CheckBox1.Checked = False
            ElseIf RadioButton2.Checked = True Then
                TextBox1.Text = MettiLaVirgola((1 / Sin(Val(TextBox1.Text))).ToString)
                CheckBox1.Checked = False
            End If
        End If
        If RadioButton1.Checked = True Then
            TextBox1.Text = MettiLaVirgola((Sin(Val(TextBox1.Text) * PI / 180)).ToString)
        ElseIf RadioButton2.Checked = True Then
            TextBox1.Text = MettiLaVirgola((Sin(Val(TextBox1.Text))).ToString)
        End If
    End Sub

    Private Sub Button22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button22.Click
        If CheckBox1.CheckState = CheckState.Checked Then
            If RadioButton1.Checked = True Then
                TextBox1.Text = MettiLaVirgola((1 / Cos(Val(MettiPunto(TextBox1.Text)) * PI / 180)).ToString)
                CheckBox1.Checked = False
            ElseIf RadioButton2.Checked = True Then
                TextBox1.Text = MettiLaVirgola((1 / Cos(Val(MettiPunto(TextBox1.Text)))).ToString)
                CheckBox1.Checked = False
            End If
        End If
        If RadioButton1.Checked = True Then
            TextBox1.Text = MettiLaVirgola((Cos(Val(MettiPunto(TextBox1.Text)) * PI / 180)).ToString)
        ElseIf RadioButton2.Checked = True Then
            TextBox1.Text = MettiLaVirgola(Cos(Val(MettiPunto(TextBox1.Text))).ToString)
        End If

    End Sub

    Private Sub Button23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button23.Click
        If CheckBox1.CheckState = CheckState.Checked Then
            If RadioButton1.Checked = True Then
                TextBox1.Text = MettiLaVirgola((1 / Tan(Val(MettiPunto(TextBox1.Text)) * PI / 180)).ToString)
                CheckBox1.Checked = False
            ElseIf RadioButton2.Checked = True Then
                TextBox1.Text = MettiLaVirgola((1 / Tan(Val(MettiPunto(TextBox1.Text)))).ToString)
                CheckBox1.Checked = False
            End If
        End If
        If RadioButton1.Checked = True Then
            TextBox1.Text = MettiLaVirgola(Tan(Val(MettiPunto(TextBox1.Text)) * PI / 180).ToString)
        ElseIf RadioButton2.Checked = True Then
            TextBox1.Text = MettiLaVirgola(Tan(Val(MettiPunto(TextBox1.Text))).ToString)
        End If

    End Sub

    Private Sub Button24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button24.Click
        If CheckBox1.CheckState = CheckState.Checked Then
            If RadioButton1.Checked = True Then
                TextBox1.Text = MettiLaVirgola((1 / Log(Val(MettiPunto(TextBox1.Text)) * PI / 180)).ToString)
                CheckBox1.Checked = False
            ElseIf RadioButton2.Checked = True Then
                TextBox1.Text = MettiLaVirgola((1 / Log(Val(MettiPunto(TextBox1.Text)))).ToString)
                CheckBox1.Checked = False
            End If
        End If
        If RadioButton1.Checked = True Then
            TextBox1.Text = MettiLaVirgola(Log(Val(MettiPunto(TextBox1.Text)) * PI / 180).ToString)
        ElseIf RadioButton2.Checked = True Then
            TextBox1.Text = MettiLaVirgola(Log(Val(MettiPunto(TextBox1.Text))).ToString)
        End If

    End Sub

    Private Sub Button29_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button29.Click
        TextBox1.Text = MettiLaVirgola(PI.ToString)
    End Sub

    Private Sub Button19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button19.Click
        TextBox1.Text = MettiLaVirgola((1 / Val(MettiPunto(TextBox1.Text))).ToString)
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        TextBox1.Text = MettiLaVirgola(Pow(Val(MettiPunto(TextBox1.Text)), 2).ToString)
    End Sub

    Private Sub Button30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button30.Click
        clearit = True
        operand1 = Val(MettiPunto(TextBox1.Text))
        [operator] = "x^y"
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        TextBox1.Text = MettiLaVirgola(-Val(MettiPunto(TextBox1.Text)).ToString)
    End Sub

    Private Sub Button31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button31.Click
        clearit = True
        memory = memory + Val(MettiPunto(TextBox1.Text))
    End Sub

    Private Sub Button34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button34.Click
        clearit = True
        If memory Then
            TextBox1.Text = memory
        ElseIf ms <> "" Then
            TextBox1.Text = ms
        End If

    End Sub

    Private Sub Button32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button32.Click
        clearit = True
        ms = MettiPunto(TextBox1.Text)
        Label1.Text = "M"
    End Sub

    Private Sub Button33_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button33.Click
        clearit = True
        If Label1.Text = "M" Then
            Label1.Text = ""
            TextBox1.Text = "0"
        End If
        memory = "0"
        ms = "0"
        TextBox1.Text = "0"
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If InStr(TextBox1.Text, ",") Then
            TextBox1.Text = "E"
        Else
            TextBox1.Text = TextBox1.Text + ","
        End If
    End Sub

    Private Sub Button37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button37.Click
        clearit = True
        TextBox1.Text = MettiLaVirgola(Pow(Val(MettiPunto(TextBox1.Text)), 3).ToString)
    End Sub

    Private Sub Button27_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button27.Click
        clearit = True
        TextBox1.Text = MettiLaVirgola((Val(MettiPunto(TextBox1.Text)) * 1 / 100).ToString)
    End Sub

    Private Sub Button36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button36.Click
        clearit = True
        n = Int(Val(MettiPunto(TextBox1.Text)))
        a = 1
        Try
            For i = 1 To n
                a = a * n
                n = n - 1
            Next
            TextBox1.Text = MettiLaVirgola(Str(a))
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Button28_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button28.Click
        clearit = True
        operand1 = Val(MettiPunto(TextBox1.Text))
        [operator] = "mod"
    End Sub

    Private Sub Button35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button35.Click
        clearit = True
        TextBox1.Text = MettiLaVirgola(Exp(Val(MettiPunto(TextBox1.Text))).ToString)
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        If TextBox1.Text <> "" Then
            Clipboard.SetDataObject(TextBox1.Text, True)
        End If
        MenuItem3.Enabled = True
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Dim iData As IDataObject = Clipboard.GetDataObject()
        If iData.GetDataPresent(DataFormats.Text) Then
            TextBox1.Text = CType(iData.GetData(DataFormats.Text), String)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Init()
        'Voce = New SpeechSynthesizer
        'Voce.SelectVoice(Parlante)
        'Voce.Volume = volume
        'Voce.Rate = Velocita

    End Sub

    Private Sub MenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem7.Click
    End Sub

    Private Sub Button38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLeggi.Click
        Leggi(TextBox1.Text)
    End Sub

    Sub Leggi(ByVal t As String)
        If t = "" Then Exit Sub
        SenzaEco(t)
    End Sub

    Sub FermaLettura()
        Try
            FermaLettura()
        Catch ex As Exception

        End Try
    End Sub

    Dim blnleggi As Boolean = False

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        If MenuItem5.Checked = True Then
            MenuItem5.Checked = False
            blnLeggi = False
        Else
            MenuItem5.Checked = True
            blnLeggi = True
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'ScegliVoce.ShowDialog()
    End Sub

    Private Sub Button1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Button1.MouseUp, Button2.MouseUp, Button3.MouseUp, Button4.MouseUp, Button5.MouseUp, Button6.MouseUp, Button7.MouseUp, Button8.MouseUp, Button9.MouseUp, Button10.MouseUp, Button11.MouseUp, Button12.MouseUp, Button13.MouseUp, Button14.MouseUp, Button15.MouseUp, Button16.MouseUp, Button17.MouseUp, Button18.MouseUp, Button19.MouseUp, Button20.MouseUp, Button21.MouseUp, Button22.MouseUp, Button23.MouseUp, Button24.MouseUp, Button25.MouseUp, Button26.MouseUp, Button27.MouseUp, Button28.MouseUp, Button29.MouseUp, Button30.MouseUp, Button31.MouseUp, Button32.MouseUp, Button33.MouseUp, Button34.MouseUp, Button35.MouseUp, Button36.MouseUp, Button37.MouseUp

        If e.Button = Windows.Forms.MouseButtons.Right Then
            Leggi(sender.tag)
        Else
            If blnLeggi = True Then
                Leggi(sender.tag)
            End If
        End If

    End Sub

    Function MettiVirgola(ByVal t As String) As String
        If t = "" Then
            Return ""
        Else
            Dim tt As String = t.Replace(".", " virgola ")
            Return tt
        End If

    End Function

    Function MettiLaVirgola(ByVal t As String) As String
        Dim tt As String = t.Replace(".", ",")
        Return tt
    End Function

    Function MettiPunto(ByVal t As String) As String
        Dim tt As String = t.Replace(",", ".")
        Return tt
    End Function
End Class

