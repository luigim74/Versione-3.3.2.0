#Region " DATI FILE.VB "
' **********************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       07/01/2006
' Data ultima modifica: 22/12/2018
' Descrizione:          Form per la compilazione del modulo di registrazione licenza.
' Note:
'
' Elenco Attivita:
'
' ***********************************************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Data.OleDb
Imports System.Drawing.Drawing2D
Imports System.Runtime.InteropServices
Imports System.Reflection.Assembly

Public Class frmModuloReg
   Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

   End Sub

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Richiesto da Progettazione Windows Form
   Private components As System.ComponentModel.IContainer

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents Label10 As System.Windows.Forms.Label
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Public WithEvents txtNome As System.Windows.Forms.TextBox
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents txtEmail As System.Windows.Forms.TextBox
   Friend WithEvents ImageList3 As System.Windows.Forms.ImageList
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents Label7 As System.Windows.Forms.Label
   Public WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtVia As System.Windows.Forms.TextBox
   Public WithEvents txtRagSoc As System.Windows.Forms.TextBox
   Public WithEvents txtTelefono As System.Windows.Forms.TextBox
   Public WithEvents txtFax As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents txtPiva As System.Windows.Forms.TextBox
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents Label14 As System.Windows.Forms.Label
   Public WithEvents Label15 As System.Windows.Forms.Label
   Public WithEvents Label16 As System.Windows.Forms.Label
   Public WithEvents Label17 As System.Windows.Forms.Label
   Public WithEvents Label18 As System.Windows.Forms.Label
   Public WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents Label28 As System.Windows.Forms.Label
   Public WithEvents txtEmailRiv As System.Windows.Forms.TextBox
   Public WithEvents Label27 As System.Windows.Forms.Label
   Public WithEvents txtTelefonoRiv As System.Windows.Forms.TextBox
   Public WithEvents Label26 As System.Windows.Forms.Label
   Public WithEvents Label25 As System.Windows.Forms.Label
   Public WithEvents Label24 As System.Windows.Forms.Label
   Public WithEvents txtPivaRiv As System.Windows.Forms.TextBox
   Public WithEvents Label23 As System.Windows.Forms.Label
   Public WithEvents txtNomeRiv As System.Windows.Forms.TextBox
   Public WithEvents txtRagSocRiv As System.Windows.Forms.TextBox
   Public WithEvents Label21 As System.Windows.Forms.Label
   Public WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdCancella As Elegant.Ui.Button
   Friend WithEvents eui_cmdInvia As Elegant.Ui.Button
   Public WithEvents Label29 As System.Windows.Forms.Label
   Friend WithEvents cmdSalva As Elegant.Ui.Button
   Public WithEvents Label20 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModuloReg))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtVia = New System.Windows.Forms.TextBox()
      Me.txtNome = New System.Windows.Forms.TextBox()
      Me.txtRagSoc = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.txtEmail = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.ImageList3 = New System.Windows.Forms.ImageList(Me.components)
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.txtTelefono = New System.Windows.Forms.TextBox()
      Me.txtFax = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtPiva = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.txtNomeRiv = New System.Windows.Forms.TextBox()
      Me.txtRagSocRiv = New System.Windows.Forms.TextBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.txtPivaRiv = New System.Windows.Forms.TextBox()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.txtTelefonoRiv = New System.Windows.Forms.TextBox()
      Me.Label26 = New System.Windows.Forms.Label()
      Me.txtEmailRiv = New System.Windows.Forms.TextBox()
      Me.Label27 = New System.Windows.Forms.Label()
      Me.Label28 = New System.Windows.Forms.Label()
      Me.eui_cmdInvia = New Elegant.Ui.Button()
      Me.eui_cmdCancella = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.cmdSalva = New Elegant.Ui.Button()
      Me.SuspendLayout()
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "")
      Me.ImageList1.Images.SetKeyName(1, "")
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(120, 272)
      Me.txtProv.MaxLength = 0
      Me.txtProv.Name = "txtProv"
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(224, 20)
      Me.txtProv.TabIndex = 5
      '
      'txtNote
      '
      Me.txtNote.AcceptsReturn = True
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNote.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNote.Location = New System.Drawing.Point(384, 320)
      Me.txtNote.MaxLength = 0
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNote.Size = New System.Drawing.Size(328, 88)
      Me.txtNote.TabIndex = 15
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(120, 248)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(80, 20)
      Me.txtCap.TabIndex = 4
      '
      'txtVia
      '
      Me.txtVia.AcceptsReturn = True
      Me.txtVia.BackColor = System.Drawing.SystemColors.Window
      Me.txtVia.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtVia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtVia.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtVia.Location = New System.Drawing.Point(120, 200)
      Me.txtVia.MaxLength = 0
      Me.txtVia.Name = "txtVia"
      Me.txtVia.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtVia.Size = New System.Drawing.Size(224, 20)
      Me.txtVia.TabIndex = 2
      '
      'txtNome
      '
      Me.txtNome.AcceptsReturn = True
      Me.txtNome.BackColor = System.Drawing.SystemColors.Window
      Me.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNome.Location = New System.Drawing.Point(120, 168)
      Me.txtNome.MaxLength = 0
      Me.txtNome.Name = "txtNome"
      Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNome.Size = New System.Drawing.Size(224, 20)
      Me.txtNome.TabIndex = 1
      '
      'txtRagSoc
      '
      Me.txtRagSoc.AcceptsReturn = True
      Me.txtRagSoc.BackColor = System.Drawing.SystemColors.Window
      Me.txtRagSoc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRagSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRagSoc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRagSoc.Location = New System.Drawing.Point(120, 144)
      Me.txtRagSoc.MaxLength = 0
      Me.txtRagSoc.Name = "txtRagSoc"
      Me.txtRagSoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRagSoc.Size = New System.Drawing.Size(224, 20)
      Me.txtRagSoc.TabIndex = 0
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(16, 272)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(54, 13)
      Me.Label10.TabIndex = 22
      Me.Label10.Text = "Provincia:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(16, 248)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(31, 13)
      Me.Label9.TabIndex = 21
      Me.Label9.Text = "CAP:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(16, 200)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(72, 13)
      Me.Label6.TabIndex = 19
      Me.Label6.Text = "Via e numero:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(16, 168)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(94, 13)
      Me.Label5.TabIndex = 18
      Me.Label5.Text = "Nome e cognome:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 144)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(86, 13)
      Me.Label4.TabIndex = 17
      Me.Label4.Text = "Ragione sociale:"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(16, 224)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(31, 13)
      Me.Label8.TabIndex = 20
      Me.Label8.Text = "Città:"
      '
      'txtEmail
      '
      Me.txtEmail.AcceptsReturn = True
      Me.txtEmail.BackColor = System.Drawing.SystemColors.Window
      Me.txtEmail.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtEmail.ForeColor = System.Drawing.Color.Red
      Me.txtEmail.Location = New System.Drawing.Point(120, 352)
      Me.txtEmail.MaxLength = 0
      Me.txtEmail.Name = "txtEmail"
      Me.txtEmail.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtEmail.Size = New System.Drawing.Size(224, 20)
      Me.txtEmail.TabIndex = 8
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(16, 352)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(38, 13)
      Me.Label11.TabIndex = 25
      Me.Label11.Text = "E-mail:"
      '
      'ImageList3
      '
      Me.ImageList3.ImageStream = CType(resources.GetObject("ImageList3.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList3.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList3.Images.SetKeyName(0, "")
      Me.ImageList3.Images.SetKeyName(1, "")
      Me.ImageList3.Images.SetKeyName(2, "")
      Me.ImageList3.Images.SetKeyName(3, "")
      Me.ImageList3.Images.SetKeyName(4, "")
      Me.ImageList3.Images.SetKeyName(5, "")
      Me.ImageList3.Images.SetKeyName(6, "")
      Me.ImageList3.Images.SetKeyName(7, "")
      Me.ImageList3.Images.SetKeyName(8, "")
      Me.ImageList3.Images.SetKeyName(9, "")
      Me.ImageList3.Images.SetKeyName(10, "")
      Me.ImageList3.Images.SetKeyName(11, "")
      Me.ImageList3.Images.SetKeyName(12, "")
      Me.ImageList3.Images.SetKeyName(13, "")
      Me.ImageList3.Images.SetKeyName(14, "")
      Me.ImageList3.Images.SetKeyName(15, "")
      Me.ImageList3.Images.SetKeyName(16, "")
      Me.ImageList3.Images.SetKeyName(17, "")
      Me.ImageList3.Images.SetKeyName(18, "")
      Me.ImageList3.Images.SetKeyName(19, "")
      Me.ImageList3.Images.SetKeyName(20, "")
      Me.ImageList3.Images.SetKeyName(21, "")
      Me.ImageList3.Images.SetKeyName(22, "")
      Me.ImageList3.Images.SetKeyName(23, "")
      Me.ImageList3.Images.SetKeyName(24, "")
      Me.ImageList3.Images.SetKeyName(25, "")
      Me.ImageList3.Images.SetKeyName(26, "")
      Me.ImageList3.Images.SetKeyName(27, "")
      Me.ImageList3.Images.SetKeyName(28, "")
      Me.ImageList3.Images.SetKeyName(29, "")
      Me.ImageList3.Images.SetKeyName(30, "")
      Me.ImageList3.Images.SetKeyName(31, "")
      Me.ImageList3.Images.SetKeyName(32, "")
      Me.ImageList3.Images.SetKeyName(33, "")
      Me.ImageList3.Images.SetKeyName(34, "")
      Me.ImageList3.Images.SetKeyName(35, "")
      Me.ImageList3.Images.SetKeyName(36, "")
      Me.ImageList3.Images.SetKeyName(37, "")
      Me.ImageList3.Images.SetKeyName(38, "")
      Me.ImageList3.Images.SetKeyName(39, "")
      Me.ImageList3.Images.SetKeyName(40, "")
      Me.ImageList3.Images.SetKeyName(41, "")
      Me.ImageList3.Images.SetKeyName(42, "")
      Me.ImageList3.Images.SetKeyName(43, "")
      Me.ImageList3.Images.SetKeyName(44, "")
      Me.ImageList3.Images.SetKeyName(45, "")
      Me.ImageList3.Images.SetKeyName(46, "")
      Me.ImageList3.Images.SetKeyName(47, "")
      Me.ImageList3.Images.SetKeyName(48, "")
      Me.ImageList3.Images.SetKeyName(49, "")
      Me.ImageList3.Images.SetKeyName(50, "")
      Me.ImageList3.Images.SetKeyName(51, "")
      Me.ImageList3.Images.SetKeyName(52, "")
      Me.ImageList3.Images.SetKeyName(53, "")
      Me.ImageList3.Images.SetKeyName(54, "")
      Me.ImageList3.Images.SetKeyName(55, "")
      Me.ImageList3.Images.SetKeyName(56, "")
      Me.ImageList3.Images.SetKeyName(57, "")
      Me.ImageList3.Images.SetKeyName(58, "")
      Me.ImageList3.Images.SetKeyName(59, "")
      Me.ImageList3.Images.SetKeyName(60, "")
      Me.ImageList3.Images.SetKeyName(61, "")
      Me.ImageList3.Images.SetKeyName(62, "")
      Me.ImageList3.Images.SetKeyName(63, "")
      Me.ImageList3.Images.SetKeyName(64, "")
      Me.ImageList3.Images.SetKeyName(65, "")
      Me.ImageList3.Images.SetKeyName(66, "")
      Me.ImageList3.Images.SetKeyName(67, "")
      Me.ImageList3.Images.SetKeyName(68, "")
      Me.ImageList3.Images.SetKeyName(69, "")
      Me.ImageList3.Images.SetKeyName(70, "")
      Me.ImageList3.Images.SetKeyName(71, "")
      Me.ImageList3.Images.SetKeyName(72, "")
      Me.ImageList3.Images.SetKeyName(73, "")
      Me.ImageList3.Images.SetKeyName(74, "")
      Me.ImageList3.Images.SetKeyName(75, "")
      Me.ImageList3.Images.SetKeyName(76, "")
      Me.ImageList3.Images.SetKeyName(77, "")
      Me.ImageList3.Images.SetKeyName(78, "")
      Me.ImageList3.Images.SetKeyName(79, "")
      Me.ImageList3.Images.SetKeyName(80, "")
      Me.ImageList3.Images.SetKeyName(81, "")
      Me.ImageList3.Images.SetKeyName(82, "")
      Me.ImageList3.Images.SetKeyName(83, "")
      Me.ImageList3.Images.SetKeyName(84, "")
      Me.ImageList3.Images.SetKeyName(85, "")
      Me.ImageList3.Images.SetKeyName(86, "")
      Me.ImageList3.Images.SetKeyName(87, "")
      Me.ImageList3.Images.SetKeyName(88, "")
      Me.ImageList3.Images.SetKeyName(89, "")
      Me.ImageList3.Images.SetKeyName(90, "")
      Me.ImageList3.Images.SetKeyName(91, "")
      Me.ImageList3.Images.SetKeyName(92, "")
      Me.ImageList3.Images.SetKeyName(93, "")
      Me.ImageList3.Images.SetKeyName(94, "")
      Me.ImageList3.Images.SetKeyName(95, "")
      Me.ImageList3.Images.SetKeyName(96, "")
      Me.ImageList3.Images.SetKeyName(97, "")
      Me.ImageList3.Images.SetKeyName(98, "")
      Me.ImageList3.Images.SetKeyName(99, "")
      Me.ImageList3.Images.SetKeyName(100, "")
      Me.ImageList3.Images.SetKeyName(101, "")
      Me.ImageList3.Images.SetKeyName(102, "")
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(704, 56)
      Me.Label1.TabIndex = 15
      Me.Label1.Text = resources.GetString("Label1.Text")
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(16, 328)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(27, 13)
      Me.Label2.TabIndex = 24
      Me.Label2.Text = "Fax:"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(16, 304)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(52, 13)
      Me.Label7.TabIndex = 23
      Me.Label7.Text = "Telefono:"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(16, 384)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(60, 13)
      Me.Label12.TabIndex = 26
      Me.Label12.Text = "Partita IVA:"
      '
      'txtTelefono
      '
      Me.txtTelefono.AcceptsReturn = True
      Me.txtTelefono.BackColor = System.Drawing.SystemColors.Window
      Me.txtTelefono.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTelefono.ForeColor = System.Drawing.Color.Red
      Me.txtTelefono.Location = New System.Drawing.Point(120, 304)
      Me.txtTelefono.MaxLength = 15
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTelefono.Size = New System.Drawing.Size(224, 20)
      Me.txtTelefono.TabIndex = 6
      '
      'txtFax
      '
      Me.txtFax.AcceptsReturn = True
      Me.txtFax.BackColor = System.Drawing.SystemColors.Window
      Me.txtFax.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtFax.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtFax.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtFax.Location = New System.Drawing.Point(120, 328)
      Me.txtFax.MaxLength = 15
      Me.txtFax.Name = "txtFax"
      Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtFax.Size = New System.Drawing.Size(224, 20)
      Me.txtFax.TabIndex = 7
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(120, 224)
      Me.txtCittà.MaxLength = 0
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(224, 20)
      Me.txtCittà.TabIndex = 3
      '
      'txtPiva
      '
      Me.txtPiva.AcceptsReturn = True
      Me.txtPiva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPiva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPiva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPiva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPiva.Location = New System.Drawing.Point(120, 384)
      Me.txtPiva.MaxLength = 11
      Me.txtPiva.Name = "txtPiva"
      Me.txtPiva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPiva.Size = New System.Drawing.Size(224, 20)
      Me.txtPiva.TabIndex = 9
      '
      'Label3
      '
      Me.Label3.ForeColor = System.Drawing.Color.Red
      Me.Label3.Location = New System.Drawing.Point(16, 80)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(704, 21)
      Me.Label3.TabIndex = 16
      Me.Label3.Tag = "EFFETTUATA LA REGISTRAZIONE RICEVERETE AL VOSTRO INDIRIZZO E-MAIL LA CHIAVE DI AT" &
    "TIVAZIONE."
      Me.Label3.Text = "EFFETTUATA LA REGISTRAZIONE RICEVERETE AL VOSTRO INDIRIZZO E-MAIL LA CHIAVE DI AT" &
    "TIVAZIONE."
      '
      'Label13
      '
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label13.ForeColor = System.Drawing.Color.Red
      Me.Label13.Location = New System.Drawing.Point(344, 168)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(16, 16)
      Me.Label13.TabIndex = 30
      Me.Label13.Text = "*"
      '
      'Label14
      '
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label14.ForeColor = System.Drawing.Color.Red
      Me.Label14.Location = New System.Drawing.Point(344, 200)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(16, 16)
      Me.Label14.TabIndex = 31
      Me.Label14.Text = "*"
      '
      'Label15
      '
      Me.Label15.BackColor = System.Drawing.Color.Transparent
      Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label15.ForeColor = System.Drawing.Color.Red
      Me.Label15.Location = New System.Drawing.Point(344, 224)
      Me.Label15.Name = "Label15"
      Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label15.Size = New System.Drawing.Size(16, 16)
      Me.Label15.TabIndex = 32
      Me.Label15.Text = "*"
      '
      'Label16
      '
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label16.ForeColor = System.Drawing.Color.Red
      Me.Label16.Location = New System.Drawing.Point(200, 248)
      Me.Label16.Name = "Label16"
      Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label16.Size = New System.Drawing.Size(16, 16)
      Me.Label16.TabIndex = 33
      Me.Label16.Text = "*"
      '
      'Label17
      '
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label17.ForeColor = System.Drawing.Color.Red
      Me.Label17.Location = New System.Drawing.Point(344, 272)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(16, 16)
      Me.Label17.TabIndex = 34
      Me.Label17.Text = "*"
      '
      'Label18
      '
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label18.ForeColor = System.Drawing.Color.Red
      Me.Label18.Location = New System.Drawing.Point(344, 352)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(16, 16)
      Me.Label18.TabIndex = 35
      Me.Label18.Text = "*"
      '
      'Label19
      '
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label19.ForeColor = System.Drawing.Color.Red
      Me.Label19.Location = New System.Drawing.Point(17, 438)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(16, 16)
      Me.Label19.TabIndex = 28
      Me.Label19.Text = "*"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(32, 440)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(87, 13)
      Me.Label20.TabIndex = 29
      Me.Label20.Text = "Campi obbligatori"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'txtNomeRiv
      '
      Me.txtNomeRiv.AcceptsReturn = True
      Me.txtNomeRiv.BackColor = System.Drawing.SystemColors.Window
      Me.txtNomeRiv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNomeRiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNomeRiv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNomeRiv.Location = New System.Drawing.Point(488, 168)
      Me.txtNomeRiv.MaxLength = 0
      Me.txtNomeRiv.Name = "txtNomeRiv"
      Me.txtNomeRiv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNomeRiv.Size = New System.Drawing.Size(224, 20)
      Me.txtNomeRiv.TabIndex = 11
      '
      'txtRagSocRiv
      '
      Me.txtRagSocRiv.AcceptsReturn = True
      Me.txtRagSocRiv.BackColor = System.Drawing.SystemColors.Window
      Me.txtRagSocRiv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRagSocRiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRagSocRiv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRagSocRiv.Location = New System.Drawing.Point(488, 144)
      Me.txtRagSocRiv.MaxLength = 0
      Me.txtRagSocRiv.Name = "txtRagSocRiv"
      Me.txtRagSocRiv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRagSocRiv.Size = New System.Drawing.Size(224, 20)
      Me.txtRagSocRiv.TabIndex = 10
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(384, 168)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(94, 13)
      Me.Label21.TabIndex = 39
      Me.Label21.Text = "Nome e cognome:"
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.BackColor = System.Drawing.Color.Transparent
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(384, 144)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(86, 13)
      Me.Label22.TabIndex = 38
      Me.Label22.Text = "Ragione sociale:"
      '
      'txtPivaRiv
      '
      Me.txtPivaRiv.AcceptsReturn = True
      Me.txtPivaRiv.BackColor = System.Drawing.SystemColors.Window
      Me.txtPivaRiv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPivaRiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPivaRiv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPivaRiv.Location = New System.Drawing.Point(488, 256)
      Me.txtPivaRiv.MaxLength = 11
      Me.txtPivaRiv.Name = "txtPivaRiv"
      Me.txtPivaRiv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPivaRiv.Size = New System.Drawing.Size(224, 20)
      Me.txtPivaRiv.TabIndex = 14
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.BackColor = System.Drawing.Color.Transparent
      Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label23.ForeColor = System.Drawing.Color.Black
      Me.Label23.Location = New System.Drawing.Point(384, 256)
      Me.Label23.Name = "Label23"
      Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label23.Size = New System.Drawing.Size(60, 13)
      Me.Label23.TabIndex = 41
      Me.Label23.Text = "Partita IVA:"
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.BackColor = System.Drawing.Color.Transparent
      Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label24.ForeColor = System.Drawing.Color.Black
      Me.Label24.Location = New System.Drawing.Point(16, 120)
      Me.Label24.Name = "Label24"
      Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label24.Size = New System.Drawing.Size(79, 13)
      Me.Label24.TabIndex = 42
      Me.Label24.Text = "Dati Azienda"
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.BackColor = System.Drawing.Color.Transparent
      Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label25.ForeColor = System.Drawing.Color.Black
      Me.Label25.Location = New System.Drawing.Point(384, 120)
      Me.Label25.Name = "Label25"
      Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label25.Size = New System.Drawing.Size(99, 13)
      Me.Label25.TabIndex = 43
      Me.Label25.Text = "Dati Rivenditore"
      '
      'txtTelefonoRiv
      '
      Me.txtTelefonoRiv.AcceptsReturn = True
      Me.txtTelefonoRiv.BackColor = System.Drawing.SystemColors.Window
      Me.txtTelefonoRiv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTelefonoRiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTelefonoRiv.ForeColor = System.Drawing.Color.Red
      Me.txtTelefonoRiv.Location = New System.Drawing.Point(488, 200)
      Me.txtTelefonoRiv.MaxLength = 15
      Me.txtTelefonoRiv.Name = "txtTelefonoRiv"
      Me.txtTelefonoRiv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTelefonoRiv.Size = New System.Drawing.Size(224, 20)
      Me.txtTelefonoRiv.TabIndex = 12
      '
      'Label26
      '
      Me.Label26.AutoSize = True
      Me.Label26.BackColor = System.Drawing.Color.Transparent
      Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label26.ForeColor = System.Drawing.Color.Black
      Me.Label26.Location = New System.Drawing.Point(384, 200)
      Me.Label26.Name = "Label26"
      Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label26.Size = New System.Drawing.Size(52, 13)
      Me.Label26.TabIndex = 45
      Me.Label26.Text = "Telefono:"
      '
      'txtEmailRiv
      '
      Me.txtEmailRiv.AcceptsReturn = True
      Me.txtEmailRiv.BackColor = System.Drawing.SystemColors.Window
      Me.txtEmailRiv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtEmailRiv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtEmailRiv.ForeColor = System.Drawing.Color.Red
      Me.txtEmailRiv.Location = New System.Drawing.Point(488, 224)
      Me.txtEmailRiv.MaxLength = 0
      Me.txtEmailRiv.Name = "txtEmailRiv"
      Me.txtEmailRiv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtEmailRiv.Size = New System.Drawing.Size(224, 20)
      Me.txtEmailRiv.TabIndex = 13
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.BackColor = System.Drawing.Color.Transparent
      Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label27.ForeColor = System.Drawing.Color.Black
      Me.Label27.Location = New System.Drawing.Point(384, 224)
      Me.Label27.Name = "Label27"
      Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label27.Size = New System.Drawing.Size(38, 13)
      Me.Label27.TabIndex = 47
      Me.Label27.Text = "E-mail:"
      '
      'Label28
      '
      Me.Label28.AutoSize = True
      Me.Label28.BackColor = System.Drawing.Color.Transparent
      Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label28.ForeColor = System.Drawing.Color.Black
      Me.Label28.Location = New System.Drawing.Point(384, 296)
      Me.Label28.Name = "Label28"
      Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label28.Size = New System.Drawing.Size(34, 13)
      Me.Label28.TabIndex = 48
      Me.Label28.Text = "Note"
      '
      'eui_cmdInvia
      '
      Me.eui_cmdInvia.Id = "4424ad4a-5dcb-4688-86a5-b03c625020b5"
      Me.eui_cmdInvia.KeyTip = "I"
      Me.eui_cmdInvia.Location = New System.Drawing.Point(304, 440)
      Me.eui_cmdInvia.Name = "eui_cmdInvia"
      Me.eui_cmdInvia.ScreenTip.Caption = "Invia e-mail"
      Me.eui_cmdInvia.ScreenTip.Text = "Invia la richiesta di attivazione del software tramite e-mail"
      Me.eui_cmdInvia.Size = New System.Drawing.Size(96, 32)
      Me.eui_cmdInvia.TabIndex = 16
      Me.eui_cmdInvia.Text = "&Invia e-mail"
      '
      'eui_cmdCancella
      '
      Me.eui_cmdCancella.Id = "e7b200a2-0075-47e4-ba44-cdb79973bfdf"
      Me.eui_cmdCancella.KeyTip = "C"
      Me.eui_cmdCancella.Location = New System.Drawing.Point(408, 440)
      Me.eui_cmdCancella.Name = "eui_cmdCancella"
      Me.eui_cmdCancella.ScreenTip.Caption = "Cancella tutto"
      Me.eui_cmdCancella.ScreenTip.Text = "Cancella il contenuto di tutte le caselle"
      Me.eui_cmdCancella.Size = New System.Drawing.Size(96, 32)
      Me.eui_cmdCancella.TabIndex = 17
      Me.eui_cmdCancella.Text = "&Cancella tutto"
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "ee04bc96-4cb8-422d-b281-e097ea1667ba"
      Me.eui_cmdAnnulla.KeyTip = "A"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(616, 440)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.ScreenTip.Caption = "Annulla"
      Me.eui_cmdAnnulla.ScreenTip.Text = "Annulla l'operazione e chiude la finestra"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(96, 32)
      Me.eui_cmdAnnulla.TabIndex = 19
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'Label29
      '
      Me.Label29.BackColor = System.Drawing.Color.Transparent
      Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label29.ForeColor = System.Drawing.Color.Red
      Me.Label29.Location = New System.Drawing.Point(344, 304)
      Me.Label29.Name = "Label29"
      Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label29.Size = New System.Drawing.Size(16, 16)
      Me.Label29.TabIndex = 52
      Me.Label29.Text = "*"
      '
      'cmdSalva
      '
      Me.cmdSalva.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdSalva.Id = "0c170bc1-1dc6-4a22-a6cd-fbc342b48ddb"
      Me.cmdSalva.KeyTip = "A"
      Me.cmdSalva.Location = New System.Drawing.Point(512, 440)
      Me.cmdSalva.Name = "cmdSalva"
      Me.cmdSalva.ScreenTip.Caption = "Salva"
      Me.cmdSalva.ScreenTip.Text = "Salva i dati e chiude la finestra"
      Me.cmdSalva.Size = New System.Drawing.Size(96, 32)
      Me.cmdSalva.TabIndex = 18
      Me.cmdSalva.Text = "&Salva"
      '
      'frmModuloReg
      '
      Me.AcceptButton = Me.eui_cmdInvia
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(723, 479)
      Me.Controls.Add(Me.cmdSalva)
      Me.Controls.Add(Me.Label29)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdCancella)
      Me.Controls.Add(Me.eui_cmdInvia)
      Me.Controls.Add(Me.Label28)
      Me.Controls.Add(Me.txtEmailRiv)
      Me.Controls.Add(Me.Label27)
      Me.Controls.Add(Me.txtTelefonoRiv)
      Me.Controls.Add(Me.Label26)
      Me.Controls.Add(Me.Label25)
      Me.Controls.Add(Me.Label24)
      Me.Controls.Add(Me.txtPivaRiv)
      Me.Controls.Add(Me.Label23)
      Me.Controls.Add(Me.txtNomeRiv)
      Me.Controls.Add(Me.txtRagSocRiv)
      Me.Controls.Add(Me.Label21)
      Me.Controls.Add(Me.Label22)
      Me.Controls.Add(Me.Label20)
      Me.Controls.Add(Me.Label19)
      Me.Controls.Add(Me.Label18)
      Me.Controls.Add(Me.Label17)
      Me.Controls.Add(Me.Label16)
      Me.Controls.Add(Me.Label15)
      Me.Controls.Add(Me.Label14)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.txtPiva)
      Me.Controls.Add(Me.txtCittà)
      Me.Controls.Add(Me.txtFax)
      Me.Controls.Add(Me.txtTelefono)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtEmail)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.txtProv)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.txtCap)
      Me.Controls.Add(Me.txtVia)
      Me.Controls.Add(Me.txtNome)
      Me.Controls.Add(Me.txtRagSoc)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label4)
      Me.ForeColor = System.Drawing.Color.Black
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmModuloReg"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Richiesta di attivazione licenza"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Dichiarazioni "
   Private DatiConfig As AppConfig
   Private CConvalida As New ConvalidaKeyPress
   Private CRandom As New Random
   Private sequenzaPos(24) As String
   Private chiaveAttivazione As String
   Private nomeModulo As String
   Public datiReg As String

#End Region

   Private Function Cripta(ByVal chiave As String) As String
      Try

         If File.Exists(Application.StartupPath & "\Dati\Temp1.dat") = True Then
            File.Delete(Application.StartupPath & "\Dati\Temp1.dat")
         End If

         FileOpen(1, Application.StartupPath & "\Dati\Temp1.dat", OpenMode.Output)
         Print(1, chiave)
         FileClose(1)

         If File.Exists(Application.StartupPath & "\Dati\Temp1.dat") = True Then
            'Genera la chiave a 64 bits, 8 bytes.
            Dim sSecretKey As String = GenerateKey()
            Dim gch As GCHandle = GCHandle.Alloc(sSecretKey, GCHandleType.Pinned)
            ' Cripta il file.        
            EncryptFile(Application.StartupPath & "\Dati\Temp1.dat", Application.StartupPath & "\Dati\Temp2.dat", sSecretKey)
            Dim key As String = sSecretKey
            ' Rimuove la chiave dalla memoria. 
            'ZeroMemory(gch.AddrOfPinnedObject(), sSecretKey.Length * 2)
            'gch.Free()

            If File.Exists(Application.StartupPath & "\Dati\Temp1.dat") = True Then
               File.Delete(Application.StartupPath & "\Dati\Temp1.dat")
            End If

            Dim Stringa As String
            Dim carattere As Char
            If File.Exists(Application.StartupPath & "\Dati\Temp2.dat") = True Then
               FileOpen(1, Application.StartupPath & "\Dati\Temp2.dat", OpenMode.Binary)
               Do While Not EOF(1)
                  carattere = InputString(1, 1)
                  Stringa = Stringa & carattere
               Loop
               FileClose(1)

               If File.Exists(Application.StartupPath & "\Dati\Temp2.dat") = True Then
                  File.Delete(Application.StartupPath & "\Dati\Temp2.dat")
               End If

               Return Stringa & "   " & key
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Function

   Private Function OffuscaChiave(ByVal chiave As String) As String
      Try
         Const stringaCaratteri As String = "ABCDEFGHIJKLMNOPQRSTUVWXJZabcdefghijklmnopqrstuvwxjz0123456789"
         Dim caratteri As String
         Dim i As Integer

         For i = 1 To 75
            caratteri = caratteri & GeneraCarattere(stringaCaratteri)
         Next

         For i = 0 To chiave.Length - 1
            caratteri = caratteri.Insert(Convert.ToInt32(sequenzaPos(i)), chiave.Substring(i, 1))
         Next

         Return caratteri

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Function LeggiChiave(ByVal chiave As String) As String
      Try
         Dim caratteri As String
         Dim i As Integer

         ' 5 8 11 15 18 23 25 28 30 33 36 39 43 47 52 60 66 69 71 74 80 88 91 94 98
         For i = 1 To chiave.Length
            caratteri = chiave.Substring(sequenzaPos(i), 1)
         Next

         Return caratteri

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return ""

      End Try
   End Function

   Private Function GeneraCarattere(ByVal setCaratteri As String) As String
      Try
         Dim startPos As Integer = CRandom.Next(1, setCaratteri.Length)
         Dim val As String = setCaratteri.Substring(startPos - 1, 1)

         Return val

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Private Sub SalvaDatiRegistrazione()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         If txtNome.Text = String.Empty Then
            MessageBox.Show("Campo 'Nome e Cognome' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtVia.Text = String.Empty Then
            MessageBox.Show("Campo 'Via e numero' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtCittà.Text = String.Empty Then
            MessageBox.Show("Campo 'Città' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtCap.Text = String.Empty Then
            MessageBox.Show("Campo 'CAP' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtProv.Text = String.Empty Then
            MessageBox.Show("Campo 'Provincia' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtTelefono.Text = String.Empty Then
            MessageBox.Show("Campo 'Telefono' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtEmail.Text = String.Empty Then
            MessageBox.Show("Campo 'E-mail' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If

         ' Salva i dati dell'utente / azienda nel file di configurazione.
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         DatiConfig.SetValue("RagioneSociale", txtRagSoc.Text)
         DatiConfig.SetValue("Nome", txtNome.Text)
         DatiConfig.SetValue("Via", txtVia.Text)
         DatiConfig.SetValue("Città", txtCittà.Text)
         DatiConfig.SetValue("Cap", txtCap.Text)
         DatiConfig.SetValue("Provincia", txtProv.Text)
         DatiConfig.SetValue("Telefono", txtTelefono.Text)
         DatiConfig.SetValue("Fax", txtFax.Text)
         DatiConfig.SetValue("Email", txtEmail.Text)
         DatiConfig.SetValue("Piva", txtPiva.Text)

         ' Salva i dati del rivenditore nel file di configurazione.
         DatiConfig.SetValue("RagioneSocialeRiv", txtRagSocRiv.Text)
         DatiConfig.SetValue("NomeRiv", txtNomeRiv.Text)
         DatiConfig.SetValue("TelefonoRiv", txtTelefonoRiv.Text)
         DatiConfig.SetValue("EmailRiv", txtEmailRiv.Text)
         DatiConfig.SetValue("PivaRiv", txtPivaRiv.Text)

         Me.DialogResult = Windows.Forms.DialogResult.Cancel

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Me.DialogResult = Windows.Forms.DialogResult.Abort

      Finally
         ' Visualizza un messaggio nella barra di stato.
         g_frmMain.eui_Informazioni.Text = g_frmMain.LeggiDatiRivenditore()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub InviaDatiRegistrazione()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         If txtNome.Text = String.Empty Then
            MessageBox.Show("Campo 'Nome e Cognome' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtVia.Text = String.Empty Then
            MessageBox.Show("Campo 'Via e numero' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtCittà.Text = String.Empty Then
            MessageBox.Show("Campo 'Città' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtCap.Text = String.Empty Then
            MessageBox.Show("Campo 'CAP' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtProv.Text = String.Empty Then
            MessageBox.Show("Campo 'Provincia' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtTelefono.Text = String.Empty Then
            MessageBox.Show("Campo 'Telefono' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If
         If txtEmail.Text = String.Empty Then
            MessageBox.Show("Campo 'E-mail' è vuoto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
            Me.DialogResult = DialogResult.None
            Exit Sub
         End If

         ' Salva i dati dell'utente / azienda nel file di configurazione.
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         DatiConfig.SetValue("RagioneSociale", txtRagSoc.Text)
         DatiConfig.SetValue("Nome", txtNome.Text)
         DatiConfig.SetValue("Via", txtVia.Text)
         DatiConfig.SetValue("Città", txtCittà.Text)
         DatiConfig.SetValue("Cap", txtCap.Text)
         DatiConfig.SetValue("Provincia", txtProv.Text)
         DatiConfig.SetValue("Telefono", txtTelefono.Text)
         DatiConfig.SetValue("Fax", txtFax.Text)
         DatiConfig.SetValue("Email", txtEmail.Text)
         DatiConfig.SetValue("Piva", txtPiva.Text)

         ' Salva i dati del rivenditore nel file di configurazione.
         DatiConfig.SetValue("RagioneSocialeRiv", txtRagSocRiv.Text)
         DatiConfig.SetValue("NomeRiv", txtNomeRiv.Text)
         DatiConfig.SetValue("TelefonoRiv", txtTelefonoRiv.Text)
         DatiConfig.SetValue("EmailRiv", txtEmailRiv.Text)
         DatiConfig.SetValue("PivaRiv", txtPivaRiv.Text)


         Dim nomeMailServer As String = NOME_MAIL_SERVER_SMTP
         Dim eMailDestinatario As String = EMAIL_ATTIVAZIONE_A
         Dim eMailMittente As String = txtEmail.Text

         Dim oggetto As String = EMAIL_ATTIVAZIONE_OGGETTO & nomeModulo

         Dim corpoMessaggio As String = "DATI UTENTE: " & vbNewLine & vbNewLine &
                                        "RAGIONE SOCIALE: " & txtRagSoc.Text & vbNewLine &
                                        "NOME E COGNOME: " & txtNome.Text & vbNewLine &
                                        "VIA E NUMERO: " & txtVia.Text & vbNewLine &
                                        "CITTA': " & txtCittà.Text & vbNewLine &
                                        "CAP: " & txtCap.Text & vbNewLine &
                                        "PROVINCIA: " & txtProv.Text & vbNewLine &
                                        "TELEFONO: " & txtTelefono.Text & vbNewLine &
                                        "FAX: " & txtFax.Text & vbNewLine &
                                        "E-MAIL: " & txtEmail.Text & vbNewLine &
                                        "PARTITA IVA: " & txtPiva.Text & vbNewLine & vbNewLine &
                                        "DATI RIVENDITORE: " & vbNewLine & vbNewLine &
                                        "RAGIONE SOCIALE: " & txtRagSocRiv.Text & vbNewLine &
                                        "NOME E COGNOME: " & txtNomeRiv.Text & vbNewLine &
                                        "TELEFONO: " & txtTelefonoRiv.Text & vbNewLine &
                                        "E-MAIL: " & txtEmailRiv.Text & vbNewLine &
                                        "PARTITA IVA: " & txtPivaRiv.Text & vbNewLine & vbNewLine &
                                        "NOTE: " & txtNote.Text & vbNewLine & vbNewLine &
                                        "NUMERO DI SERIE: " & NUMERO_SERIE & vbNewLine &
                                        "VERSIONE PRODOTTO: " & FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).ProductVersion & vbNewLine &
                                        "NOME MODULO: " & nomeModulo & vbNewLine &
                                        "ID: " & OffuscaChiave(chiaveAttivazione)

         ' Nel caso si verifica l'errore di invio e-mail passa i dati al gestore degli errori.
         datiReg = corpoMessaggio

         Dim messaggio As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(eMailMittente, eMailDestinatario)
         messaggio.Subject = oggetto
         messaggio.Body = corpoMessaggio

         Dim smtp As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient(nomeMailServer, 25)

         smtp.Credentials = New System.Net.NetworkCredential(USER_NAME_MAIL_SERVER_SMTP, PWD_MAIL_SERVER_SMTP)

         smtp.Send(messaggio)

         Me.DialogResult = Windows.Forms.DialogResult.OK

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Dim frm As New DatiUtenteReg
         frm.Tag = datiReg
         frm.ShowDialog()

         Me.DialogResult = Windows.Forms.DialogResult.Abort

      Finally
         ' Visualizza un messaggio nella barra di stato.
         g_frmMain.eui_Informazioni.Text = g_frmMain.LeggiDatiRivenditore()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub frmModuloReg_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         chiaveAttivazione = Me.Tag.ToString.Substring(0, 25)
         nomeModulo = Me.Tag.ToString.Substring(26, Me.Tag.ToString.Length - 26)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Dati utente / azienda.
         txtRagSoc.Text = DatiConfig.GetValue("RagioneSociale")
         txtNome.Text = DatiConfig.GetValue("Nome")
         txtVia.Text = DatiConfig.GetValue("Via")
         txtCittà.Text = DatiConfig.GetValue("Città")
         txtCap.Text = DatiConfig.GetValue("Cap")
         txtProv.Text = DatiConfig.GetValue("Provincia")
         txtTelefono.Text = DatiConfig.GetValue("Telefono")
         txtFax.Text = DatiConfig.GetValue("Fax")
         txtEmail.Text = DatiConfig.GetValue("Email")
         txtPiva.Text = DatiConfig.GetValue("Piva")

         ' Dati rivenditore.
         txtRagSocRiv.Text = DatiConfig.GetValue("RagioneSocialeRiv")
         txtNomeRiv.Text = DatiConfig.GetValue("NomeRiv")
         txtTelefonoRiv.Text = DatiConfig.GetValue("TelefonoRiv")
         txtEmailRiv.Text = DatiConfig.GetValue("EmailRiv")
         txtPivaRiv.Text = DatiConfig.GetValue("PivaRiv")

         ' Dati per offuscare la chiave.
         sequenzaPos(0) = "3"
         sequenzaPos(1) = "5"
         sequenzaPos(2) = "8"
         sequenzaPos(3) = "11"
         sequenzaPos(4) = "15"
         sequenzaPos(5) = "18"
         sequenzaPos(6) = "23"
         sequenzaPos(7) = "25"
         sequenzaPos(8) = "28"
         sequenzaPos(9) = "30"
         sequenzaPos(10) = "33"
         sequenzaPos(11) = "36"
         sequenzaPos(12) = "39"
         sequenzaPos(13) = "41"
         sequenzaPos(14) = "43"
         sequenzaPos(15) = "47"
         sequenzaPos(16) = "50"
         sequenzaPos(17) = "52"
         sequenzaPos(18) = "56"
         sequenzaPos(19) = "60"
         sequenzaPos(20) = "63"
         sequenzaPos(21) = "66"
         sequenzaPos(22) = "68"
         sequenzaPos(23) = "69"
         sequenzaPos(24) = "71"

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmModuloReg_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
      '' Disegna una barra colorata per indicare il livello di sicurezza
      'Panel1.Refresh()
      'Dim gr As Graphics = Panel1.CreateGraphics
      'Dim br As New LinearGradientBrush(New Rectangle(0, 0, Panel1.Width, 30), Color.Gainsboro, Color.DimGray, LinearGradientMode.Horizontal)
      'gr.FillRectangle(br, 0, 0, Panel1.Width, 30)
      'br.Dispose()
   End Sub

   Private Sub cmdSalva_Click(sender As Object, e As EventArgs) Handles cmdSalva.Click
      Try
         SalvaDatiRegistrazione()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub eui_cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub eui_cmdCancella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmdCancella.Click
      Try
         ' Dati Azienda.
         txtRagSoc.Text = ""
         txtNome.Text = ""
         txtVia.Text = ""
         txtCittà.Text = ""
         txtCap.Text = ""
         txtProv.Text = ""
         txtTelefono.Text = ""
         txtFax.Text = ""
         txtEmail.Text = ""
         txtPiva.Text = ""

         ' Dati Rivenditore.
         txtRagSocRiv.Text = ""
         txtNomeRiv.Text = ""
         txtTelefonoRiv.Text = ""
         txtEmailRiv.Text = ""
         txtPivaRiv.Text = ""

         ' Note.
         txtNote.Text = ""

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdInvia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmdInvia.Click
      Try
         InviaDatiRegistrazione()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub txtCap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCap.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtTelefono_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFax.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtPiva_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPiva.TextChanged
   End Sub

   Private Sub txtPiva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPiva.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtTelefonoRiv_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefonoRiv.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

   End Sub

   Private Sub txtPivaRiv_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPivaRiv.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

   End Sub

End Class
