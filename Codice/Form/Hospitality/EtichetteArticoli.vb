Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Data.OleDb

Public Class EtichetteArticoli
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
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents label As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents cmbNumero As System.Windows.Forms.ComboBox
   Public WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents picAnteprima As System.Windows.Forms.PictureBox
   Friend WithEvents lblDescrizione As System.Windows.Forms.Label
   Friend WithEvents lstEtichette As System.Windows.Forms.ListBox
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents txtNumEtichette As System.Windows.Forms.TextBox
   Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
   Public WithEvents Label7 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmbTaglia As System.Windows.Forms.ComboBox
   Friend WithEvents cmbIdArticoli As System.Windows.Forms.ComboBox
   Friend WithEvents cmbArticoli As System.Windows.Forms.ComboBox
   Friend WithEvents cmbColore As System.Windows.Forms.ComboBox
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   Public WithEvents txtPrezzo As System.Windows.Forms.TextBox
   Public WithEvents txtDescrizione As System.Windows.Forms.TextBox
   Public WithEvents txtCodBarre As System.Windows.Forms.TextBox
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents picCodBarre As System.Windows.Forms.PictureBox
   Friend WithEvents lstTipoCodBarre As System.Windows.Forms.ListBox
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents chkData As System.Windows.Forms.CheckBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents Label10 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(EtichetteArticoli))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.chkData = New System.Windows.Forms.CheckBox()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.cmbTaglia = New System.Windows.Forms.ComboBox()
      Me.txtCodBarre = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmbIdArticoli = New System.Windows.Forms.ComboBox()
      Me.cmbArticoli = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtNumEtichette = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cmbColore = New System.Windows.Forms.ComboBox()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.txtPrezzo = New System.Windows.Forms.TextBox()
      Me.txtDescrizione = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.label = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.TabPage3 = New System.Windows.Forms.TabPage()
      Me.cmbNumero = New System.Windows.Forms.ComboBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.picAnteprima = New System.Windows.Forms.PictureBox()
      Me.lblDescrizione = New System.Windows.Forms.Label()
      Me.lstEtichette = New System.Windows.Forms.ListBox()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.picCodBarre = New System.Windows.Forms.PictureBox()
      Me.lstTipoCodBarre = New System.Windows.Forms.ListBox()
      Me.TextBox1 = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.TabPage3.SuspendLayout()
      CType(Me.picAnteprima, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage2.SuspendLayout()
      Me.Panel2.SuspendLayout()
      CType(Me.picCodBarre, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Salva, Me.Annulla})
      Me.ToolBar1.ButtonSize = New System.Drawing.Size(22, 22)
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(541, 26)
      Me.ToolBar1.TabIndex = 0
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'Salva
      '
      Me.Salva.ImageIndex = 9
      Me.Salva.Name = "Salva"
      Me.Salva.Tag = "Salva"
      Me.Salva.Text = "Salva"
      Me.Salva.ToolTipText = "Salva"
      '
      'Annulla
      '
      Me.Annulla.ImageIndex = 10
      Me.Annulla.Name = "Annulla"
      Me.Annulla.Tag = "Annulla"
      Me.Annulla.Text = "Annulla"
      Me.Annulla.ToolTipText = "Annulla"
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "")
      Me.ImageList1.Images.SetKeyName(1, "")
      Me.ImageList1.Images.SetKeyName(2, "")
      Me.ImageList1.Images.SetKeyName(3, "")
      Me.ImageList1.Images.SetKeyName(4, "")
      Me.ImageList1.Images.SetKeyName(5, "")
      Me.ImageList1.Images.SetKeyName(6, "")
      Me.ImageList1.Images.SetKeyName(7, "")
      Me.ImageList1.Images.SetKeyName(8, "")
      Me.ImageList1.Images.SetKeyName(9, "")
      Me.ImageList1.Images.SetKeyName(10, "")
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(541, 20)
      Me.Panel1.TabIndex = 0
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.SystemColors.Window
      Me.lblIntestazione.Location = New System.Drawing.Point(4, 2)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(16, 16)
      Me.lblIntestazione.TabIndex = 0
      Me.lblIntestazione.Text = "#"
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage3)
      Me.TabControl1.Controls.Add(Me.TabPage2)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(541, 316)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.chkData)
      Me.TabPage1.Controls.Add(Me.dtpData)
      Me.TabPage1.Controls.Add(Me.cmbTaglia)
      Me.TabPage1.Controls.Add(Me.txtCodBarre)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.cmbIdArticoli)
      Me.TabPage1.Controls.Add(Me.cmbArticoli)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.txtNumEtichette)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.cmbColore)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.txtPrezzo)
      Me.TabPage1.Controls.Add(Me.txtDescrizione)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.label)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.ForeColor = System.Drawing.SystemColors.ControlText
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(533, 290)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      Me.TabPage1.ToolTipText = "Dati principali"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(320, 72)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(68, 13)
      Me.Label10.TabIndex = 235
      Me.Label10.Text = "Escludi data:"
      '
      'chkData
      '
      Me.chkData.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkData.Location = New System.Drawing.Point(392, 72)
      Me.chkData.Name = "chkData"
      Me.chkData.Size = New System.Drawing.Size(16, 16)
      Me.chkData.TabIndex = 2
      '
      'dtpData
      '
      Me.dtpData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpData.Location = New System.Drawing.Point(120, 72)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(176, 20)
      Me.dtpData.TabIndex = 1
      '
      'cmbTaglia
      '
      Me.cmbTaglia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTaglia.Location = New System.Drawing.Point(120, 184)
      Me.cmbTaglia.Name = "cmbTaglia"
      Me.cmbTaglia.Size = New System.Drawing.Size(176, 21)
      Me.cmbTaglia.TabIndex = 7
      Me.cmbTaglia.Visible = False
      '
      'txtCodBarre
      '
      Me.txtCodBarre.AcceptsReturn = True
      Me.txtCodBarre.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodBarre.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodBarre.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodBarre.Location = New System.Drawing.Point(120, 152)
      Me.txtCodBarre.MaxLength = 0
      Me.txtCodBarre.Name = "txtCodBarre"
      Me.txtCodBarre.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodBarre.Size = New System.Drawing.Size(176, 20)
      Me.txtCodBarre.TabIndex = 5
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(40, 152)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(79, 13)
      Me.Label7.TabIndex = 234
      Me.Label7.Text = "Codice a barre:"
      '
      'cmbIdArticoli
      '
      Me.cmbIdArticoli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdArticoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbIdArticoli.Location = New System.Drawing.Point(480, 32)
      Me.cmbIdArticoli.Name = "cmbIdArticoli"
      Me.cmbIdArticoli.Size = New System.Drawing.Size(40, 21)
      Me.cmbIdArticoli.TabIndex = 233
      Me.cmbIdArticoli.Visible = False
      '
      'cmbArticoli
      '
      Me.cmbArticoli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbArticoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbArticoli.Location = New System.Drawing.Point(40, 32)
      Me.cmbArticoli.Name = "cmbArticoli"
      Me.cmbArticoli.Size = New System.Drawing.Size(432, 21)
      Me.cmbArticoli.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(40, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(143, 13)
      Me.Label1.TabIndex = 232
      Me.Label1.Text = "Seleziona dall'elenco Articoli:"
      '
      'txtNumEtichette
      '
      Me.txtNumEtichette.AcceptsReturn = True
      Me.txtNumEtichette.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumEtichette.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumEtichette.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumEtichette.ForeColor = System.Drawing.Color.Red
      Me.txtNumEtichette.Location = New System.Drawing.Point(424, 256)
      Me.txtNumEtichette.MaxLength = 0
      Me.txtNumEtichette.Name = "txtNumEtichette"
      Me.txtNumEtichette.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumEtichette.Size = New System.Drawing.Size(48, 20)
      Me.txtNumEtichette.TabIndex = 9
      Me.txtNumEtichette.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(272, 256)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(152, 13)
      Me.Label12.TabIndex = 230
      Me.Label12.Text = "Numero etichette da stampare:"
      '
      'cmbColore
      '
      Me.cmbColore.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbColore.Location = New System.Drawing.Point(120, 216)
      Me.cmbColore.Name = "cmbColore"
      Me.cmbColore.Size = New System.Drawing.Size(176, 21)
      Me.cmbColore.TabIndex = 8
      Me.cmbColore.Visible = False
      '
      'txtCodice
      '
      Me.txtCodice.AcceptsReturn = True
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodice.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodice.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodice.Location = New System.Drawing.Point(120, 104)
      Me.txtCodice.MaxLength = 0
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodice.Size = New System.Drawing.Size(176, 20)
      Me.txtCodice.TabIndex = 3
      '
      'txtPrezzo
      '
      Me.txtPrezzo.AcceptsReturn = True
      Me.txtPrezzo.BackColor = System.Drawing.SystemColors.Window
      Me.txtPrezzo.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPrezzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPrezzo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPrezzo.Location = New System.Drawing.Point(368, 152)
      Me.txtPrezzo.MaxLength = 0
      Me.txtPrezzo.Name = "txtPrezzo"
      Me.txtPrezzo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPrezzo.Size = New System.Drawing.Size(104, 20)
      Me.txtPrezzo.TabIndex = 6
      '
      'txtDescrizione
      '
      Me.txtDescrizione.AcceptsReturn = True
      Me.txtDescrizione.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescrizione.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizione.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDescrizione.Location = New System.Drawing.Point(120, 128)
      Me.txtDescrizione.MaxLength = 0
      Me.txtDescrizione.Name = "txtDescrizione"
      Me.txtDescrizione.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDescrizione.Size = New System.Drawing.Size(352, 20)
      Me.txtDescrizione.TabIndex = 4
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(40, 72)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(33, 13)
      Me.Label2.TabIndex = 170
      Me.Label2.Text = "Data:"
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(40, 104)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(43, 13)
      Me.label.TabIndex = 169
      Me.label.Text = "Codice:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(40, 216)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 165
      Me.Label6.Text = "Colore:"
      Me.Label6.Visible = False
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(40, 184)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(39, 13)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Taglia:"
      Me.Label5.Visible = False
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(320, 152)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(42, 13)
      Me.Label4.TabIndex = 163
      Me.Label4.Text = "Prezzo:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(40, 128)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(65, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Descrizione:"
      '
      'TabPage3
      '
      Me.TabPage3.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage3.Controls.Add(Me.cmbNumero)
      Me.TabPage3.Controls.Add(Me.Label20)
      Me.TabPage3.Controls.Add(Me.picAnteprima)
      Me.TabPage3.Controls.Add(Me.lblDescrizione)
      Me.TabPage3.Controls.Add(Me.lstEtichette)
      Me.TabPage3.Location = New System.Drawing.Point(4, 22)
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(532, 292)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "Formato"
      Me.TabPage3.ToolTipText = "Dati sul telefono e Internet"
      '
      'cmbNumero
      '
      Me.cmbNumero.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNumero.Location = New System.Drawing.Point(448, 256)
      Me.cmbNumero.Name = "cmbNumero"
      Me.cmbNumero.Size = New System.Drawing.Size(64, 21)
      Me.cmbNumero.TabIndex = 1
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(324, 240)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(189, 13)
      Me.Label20.TabIndex = 159
      Me.Label20.Text = "Inizia a stampare dall'etichetta numero:"
      '
      'picAnteprima
      '
      Me.picAnteprima.Location = New System.Drawing.Point(384, 48)
      Me.picAnteprima.Name = "picAnteprima"
      Me.picAnteprima.Size = New System.Drawing.Size(72, 72)
      Me.picAnteprima.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
      Me.picAnteprima.TabIndex = 158
      Me.picAnteprima.TabStop = False
      '
      'lblDescrizione
      '
      Me.lblDescrizione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDescrizione.ForeColor = System.Drawing.Color.Black
      Me.lblDescrizione.Location = New System.Drawing.Point(328, 136)
      Me.lblDescrizione.Name = "lblDescrizione"
      Me.lblDescrizione.Size = New System.Drawing.Size(184, 64)
      Me.lblDescrizione.TabIndex = 157
      Me.lblDescrizione.Text = "#"
      Me.lblDescrizione.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lstEtichette
      '
      Me.lstEtichette.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstEtichette.Location = New System.Drawing.Point(16, 16)
      Me.lstEtichette.Name = "lstEtichette"
      Me.lstEtichette.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lstEtichette.Size = New System.Drawing.Size(288, 264)
      Me.lstEtichette.TabIndex = 0
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage2.Controls.Add(Me.Label9)
      Me.TabPage2.Controls.Add(Me.Label8)
      Me.TabPage2.Controls.Add(Me.Panel2)
      Me.TabPage2.Controls.Add(Me.lstTipoCodBarre)
      Me.TabPage2.Controls.Add(Me.TextBox1)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(532, 292)
      Me.TabPage2.TabIndex = 3
      Me.TabPage2.Text = "Codice a barre"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(216, 16)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(57, 13)
      Me.Label9.TabIndex = 244
      Me.Label9.Text = "Anteprima:"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(16, 16)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(31, 13)
      Me.Label8.TabIndex = 243
      Me.Label8.Text = "Tipo:"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Panel2.Controls.Add(Me.picCodBarre)
      Me.Panel2.Location = New System.Drawing.Point(217, 33)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(294, 236)
      Me.Panel2.TabIndex = 1
      '
      'picCodBarre
      '
      Me.picCodBarre.BackColor = System.Drawing.SystemColors.Window
      Me.picCodBarre.Location = New System.Drawing.Point(15, 74)
      Me.picCodBarre.Name = "picCodBarre"
      Me.picCodBarre.Size = New System.Drawing.Size(265, 88)
      Me.picCodBarre.TabIndex = 239
      Me.picCodBarre.TabStop = False
      '
      'lstTipoCodBarre
      '
      Me.lstTipoCodBarre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstTipoCodBarre.Items.AddRange(New Object() {"EAN 8", "EAN 13", "CODE 32", "CODE 39", "CODE 128", "BCD Matrix", "2 DI 5 Interleaved (ITF)"})
      Me.lstTipoCodBarre.Location = New System.Drawing.Point(16, 32)
      Me.lstTipoCodBarre.Name = "lstTipoCodBarre"
      Me.lstTipoCodBarre.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lstTipoCodBarre.Size = New System.Drawing.Size(192, 238)
      Me.lstTipoCodBarre.TabIndex = 0
      '
      'TextBox1
      '
      Me.TextBox1.Enabled = False
      Me.TextBox1.Location = New System.Drawing.Point(216, 32)
      Me.TextBox1.Multiline = True
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(296, 238)
      Me.TextBox1.TabIndex = 245
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'ImageList2
      '
      Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList2.Images.SetKeyName(0, "")
      Me.ImageList2.Images.SetKeyName(1, "")
      Me.ImageList2.Images.SetKeyName(2, "")
      Me.ImageList2.Images.SetKeyName(3, "")
      Me.ImageList2.Images.SetKeyName(4, "")
      Me.ImageList2.Images.SetKeyName(5, "")
      Me.ImageList2.Images.SetKeyName(6, "")
      Me.ImageList2.Images.SetKeyName(7, "")
      Me.ImageList2.Images.SetKeyName(8, "")
      Me.ImageList2.Images.SetKeyName(9, "")
      Me.ImageList2.Images.SetKeyName(10, "")
      Me.ImageList2.Images.SetKeyName(11, "")
      Me.ImageList2.Images.SetKeyName(12, "")
      '
      'Timer1
      '
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'EtichetteArticoli
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(541, 362)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.ForeColor = System.Drawing.SystemColors.ControlText
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "EtichetteArticoli"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Etichette Codici a barre Articoli"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      CType(Me.picAnteprima, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      CType(Me.picCodBarre, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Dichiarazioni "

   Private AEtichetteArt As New EtichetteArt
   Private CConvalida As New ConvalidaKeyPress
   Private CFormatta As New ClsFormatta
   Private codiceBarre As New CodeBar

   Const ANA_ARTICOLI As String = "Articoli"
   Const TAB_TAGLIE As String = "Taglie"
   Const TAB_COLORI As String = "Colori"
   Const NOME_TABELLA As String = "EtichetteArticoli"

   Const FORMATO_ETICHETTA_8 As String = "8 etichette per foglio; dimensioni 99.1 x 67.7 mm"
   Const FORMATO_ETICHETTA_12 As String = "12 etichette per foglio; dimensioni 63.5 x 72 mm"
   Const FORMATO_ETICHETTA_14 As String = "14 etichette per foglio; dimensioni 99.1 x 38.1 mm"
   Const FORMATO_ETICHETTA_16 As String = "16 etichette per foglio; dimensioni 99.1 x 33.1 mm"
   Const FORMATO_ETICHETTA_21 As String = "21 etichette per foglio; dimensioni 63.5 x 38.1 mm"
   Const FORMATO_ETICHETTA_24 As String = "24 etichette per foglio; dimensioni 63.5 x 33.9 mm"
   Const FORMATO_ETICHETTA_DYMO As String = "1 x 130 etichette; dimensioni 89 x 28 mm"

   Dim formatoEtichette As String = "STANDARD AVERY; FORMATO 1"
   Dim codBarre As Short = tipoCodBarre.EAN13

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnStringAnagrafiche)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   Dim dt As DataTable

   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Dim idArticolo As String = ""
   Dim idTaglie As String = ""
   Dim idColori As String = ""

   Dim percorsoRepEtichette As String = PERCORSO_ETICHETTE_991_677
   Dim repSql As String

   Enum tipoCodBarre As Short
      EAN8 = 0
      EAN13 = 1
      CODE32 = 2
      CODE39 = 3
      CODE128 = 4
      BCD_MATRIX = 5
      ITF_INTERLEAVED = 6
   End Enum

#End Region

#Region "Procedure "

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      Try
         ' Imposta le dimensioni standard del form.
         Me.Width = larghezza
         Me.Height = altezza

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub LeggiDatiArticoli(ByVal tabella As String, ByVal id As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDB)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         idArticolo = id

         Do While dr.Read
            If IsDBNull(dr.Item("Codice")) = False Then
               txtCodice.Text = dr.Item("Codice")
            Else
               txtCodice.Text = ""
            End If
            If IsDBNull(dr.Item("CodBarre")) = False Then
               txtCodBarre.Text = dr.Item("CodBarre")
            Else
               txtCodBarre.Text = ""
            End If
            If IsDBNull(dr.Item("Descrizione")) = False Then
               txtDescrizione.Text = dr.Item("Descrizione")
            Else
               txtDescrizione.Text = ""
            End If
            If IsDBNull(dr.Item("PrezzoAcquisto")) = False Then
               txtPrezzo.Text = dr.Item("PrezzoAcquisto")
            Else
               txtPrezzo.Text = ""
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiTaglieColoriArticoli(ByVal tabella As String, ByVal id As String)
      'Try
      '   ConnStringAnagrafiche = CreaConnString(PercorsoDB)

      '   ' Dichiara un oggetto connessione.
      '   Dim cn As New OleDbConnection(ConnStringAnagrafiche)

      '   cn.Open()

      '   Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id, cn)
      '   Dim dr As OleDbDataReader = cmd.ExecuteReader()

      '   idArticolo = id

      '   Do While dr.Read
      '      If IsDBNull(dr.Item("IdTaglia")) = False Then
      '         idTaglie = dr.Item("IdTaglia")
      '      Else
      '         idTaglie = ""
      '      End If
      '      If IsDBNull(dr.Item("IdColori")) = False Then
      '         idColori = dr.Item("IdColori")
      '      Else
      '         idColori = ""
      '      End If
      '   Loop

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   cn.Close()

      'End Try
   End Sub

   Private Function EstraiCodiceTaglie(ByVal val As String) As String
      'Try
      '   Dim codice As String = val.Substring(0, 5)
      '   Dim id As String = codice.Replace("0", "")

      '   Return id

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)
      'End Try
   End Function

   Private Function EstraiNomeColore(ByVal val As String) As String
      'Try
      '   Const START_INDEX As Integer = 8

      '   Dim nome As String = val.Substring(START_INDEX, val.Length - START_INDEX)

      '   Return nome

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)
      'End Try
   End Function

   Public Sub CaricaListaTaglie(ByVal tabella As String, ByVal id As Integer)
      'Try
      '   Dim trovato As Boolean = False
      '   ' Dichiara un oggetto connessione.
      '   Dim cn As New OleDbConnection(ConnString)

      '   cn.Open()

      '   Dim CTaglie As New Taglie
      '   With CTaglie
      '      ' Visualizza i dati nei rispettivi campi.
      '      .LeggiDati("Taglie", id)

      '      Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
      '      Dim dr As OleDbDataReader = cmd.ExecuteReader()

      '      Dim i As Integer = 0
      '      cmbTaglia.Items.Clear()
      '      Do While dr.Read()
      '         For i = 0 To 29
      '            ' Taglia.
      '            cmbTaglia.Items.Add(.Taglia(i))
      '         Next i
      '      Loop
      '   End With

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   cn.Close()

      'End Try
   End Sub

   Public Sub CaricaListaColori(ByVal id As String)
      Try
         Dim idColori() As String = id.Split(";")
         Dim i As Integer = 0
         cmbColore.Items.Clear()
         For i = 0 To idColori.Length - 2
            ' Colore
            cmbColore.Items.Add(EstraiNomeColore(idColori(i)))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Sub CaricaListaFormati()
      Try
         lstEtichette.Items.Clear()
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 1")
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 2")
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 3")
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 4")
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 5")
         lstEtichette.Items.Add("STANDARD AVERY; FORMATO 6")
         lstEtichette.Items.Add("DYMO LABELWRITER 400; FORMATO INDIRIZZI")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

#End Region

#Region "Funzioni "

   Private Function SalvaDati() As Boolean
      Try
         ' Salva eventuali nuovi valori nelle rispettive tabelle dati.
         'AggiornaTabella(cmbTitolo, TAB_QUALIFICHE)

         With AEtichetteArt
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Codice = FormattaApici(txtCodice.Text)
            .CodBarre = FormattaApici(txtCodBarre.Text)
            .CodBarreTipo = lstTipoCodBarre.SelectedItem

            If IsNothing(picCodBarre.Image) = False Then
               Dim imageFormat As System.Drawing.Imaging.ImageFormat
               picCodBarre.Image.Save(Application.StartupPath & "\Dati\" & .CodBarre & ".tiff", imageFormat.Tiff)
               .CodBarrePercorsoImg = Application.StartupPath & "\Dati\" & .CodBarre & ".tiff"
               ' Salva l'immagine in un campo BLOB del database.
               .CodBarreImg = CreaStream(Application.StartupPath & "\Dati\" & .CodBarre & ".tiff")
               Dim f As File
               f.Delete(Application.StartupPath & "\Dati\" & .CodBarre & ".tiff")
            Else
               Dim b() As Byte = {&H0, &H12, &H34, &H56, &HAA, &H55, &HFF}
               ' Salva l'immagine in un campo BLOB del database.
               .CodBarreImg = b
            End If

            .Descrizione = FormattaApici(txtDescrizione.Text)

            If txtPrezzo.Text <> "" Then
               .Prezzo = CFormatta.FormattaEuro(Convert.ToDecimal(txtPrezzo.Text))
            Else
               .Prezzo = ""
            End If

            If chkData.Checked = True Then
               .Data = ""
            Else
               .Data = FormattaData(dtpData.Text, True)
            End If

            .Taglia = FormattaApici(cmbTaglia.Text)
            .Colore = FormattaApici(cmbColore.Text)

            If IsNumeric(txtNumEtichette.Text) = True Then
               .Quantità = Convert.ToInt32(txtNumEtichette.Text)
            Else
               .Quantità = 1
            End If

            .Formato = FormattaApici(formatoEtichette)
            .Percorso = percorsoRepEtichette

            If IsNumeric(cmbNumero.Text) = True Then
               .PosStampa = Convert.ToInt16(cmbNumero.Text)
            Else
               .PosStampa = 1
            End If

            ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> "" Then
               Return .ModificaDati(NOME_TABELLA, Me.Tag)
            Else
               Return .InserisciDati(NOME_TABELLA)
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

#End Region

#Region "Eventi "

   Private Sub EtichetteArticoli_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_STRUMENTI_ETICHETTE)
      End If
   End Sub

   Private Sub EtichetteArticoli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            With AEtichetteArt
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCodice.Text = .Codice
               txtCodBarre.Text = .CodBarre
               lstTipoCodBarre.SelectedItem = .CodBarreTipo
               txtDescrizione.Text = .Descrizione

               If .Prezzo <> "" Then
                  txtPrezzo.Text = CFormatta.FormattaEuro(.Prezzo)
               Else
                  txtPrezzo.Text = ""
               End If

               If .Data = "" Then
                  chkData.Checked = True
               Else
                  chkData.Checked = False
               End If

               dtpData.Text = .Data
               cmbTaglia.Text = .Taglia
               cmbColore.Text = .Colore
               txtNumEtichette.Text = .Quantità.ToString
               formatoEtichette = .Formato
               cmbNumero.Text = .PosStampa.ToString
            End With
         Else
            ' In caso di nuovo inserimento dati imposta i valori di default.
            txtNumEtichette.Text = "1"
            cmbNumero.Text = 1
         End If

         ' Carica le liste.
         CaricaListaArticoli(cmbArticoli, cmbIdArticoli, ANA_ARTICOLI)

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtCodice.Text, txtDescrizione.Text, "")

         ' Imposta lo stato attivo.
         cmbArticoli.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmEtichette) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmEtichette.AggiornaDatiArticoli()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & AEtichetteArt.Codice & " - " & AEtichetteArt.Descrizione & ")"
               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_STRUMENTI_ETICHETTE)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_STRUMENTI_ETICHETTE)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Try
         Select Case TabControl1.SelectedIndex()
            Case 0
               ' Imposta lo stato attivo.
               cmbArticoli.Focus()

            Case 1
               ' Carica la lista delle categorie dei piatti.
               CaricaListaFormati()

               ' Seleziona il primo elemento della lista categorie.
               If lstEtichette.Items.Count <> 0 Then
                  If formatoEtichette <> "" Then
                     lstEtichette.SelectedItem = formatoEtichette
                  Else
                     lstEtichette.SelectedIndex = 0
                  End If
               End If

               If Me.Tag <> "" Then
                  If AEtichetteArt.PosStampa > 1 Then
                     cmbNumero.SelectedIndex = AEtichetteArt.PosStampa - 1
                  Else
                     cmbNumero.SelectedIndex = 0
                  End If
               End If

               ' Imposta lo stato attivo.
               lstEtichette.Focus()

            Case 2
               Timer1.Enabled = True
               If Me.Tag = "" Then
                  lstTipoCodBarre.SelectedIndex = 0
               End If
               lstTipoCodBarre.Focus()
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub txtNumEtichette_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumEtichette.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtNumEtichette_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumEtichette.LostFocus
      'If IsNumeric(sender.Text) Then
      '   sender.Text = CFormatta.FormattaNumero(Convert.ToInt32(sender.Text))
      'End If
   End Sub

   Private Sub cmbArticoli_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbArticoli.SelectedIndexChanged
      Try
         ' Ottiene l'indice dell'elemento selezionato.
         Dim index As Integer = sender.Items.IndexOf(sender.Text)

         ' Recupera l'Id del Cliente selezionato per caricare i dati.
         If index >= 0 Then
            LeggiDatiArticoli(ANA_ARTICOLI, cmbIdArticoli.Items.Item(index))
            LeggiTaglieColoriArticoli(ANA_ARTICOLI, cmbIdArticoli.Items.Item(index))

            If idTaglie <> "" Then
               CaricaListaTaglie(TAB_TAGLIE, EstraiCodiceTaglie(idTaglie))
            Else
               cmbTaglia.Items.Clear()
            End If

            If idColori <> "" Then
               CaricaListaColori(idColori)
            Else
               cmbColore.Items.Clear()
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lstEtichette_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstEtichette.SelectedIndexChanged
      Dim numEtichette As Short = 0

      Select Case sender.SelectedIndex
         Case 0
            lblDescrizione.Text = FORMATO_ETICHETTA_8
            picAnteprima.Image = ImageList2.Images(4)
            numEtichette = 8
            percorsoRepEtichette = PERCORSO_ETICHETTE_ART_991_677

         Case 1
            lblDescrizione.Text = FORMATO_ETICHETTA_12
            picAnteprima.Image = ImageList2.Images(6)
            numEtichette = 12
            percorsoRepEtichette = PERCORSO_ETICHETTE_ART_635_72

         Case 2
            lblDescrizione.Text = FORMATO_ETICHETTA_14
            picAnteprima.Image = ImageList2.Images(7)
            numEtichette = 14
            percorsoRepEtichette = PERCORSO_ETICHETTE_ART_991_381

         Case 3
            lblDescrizione.Text = FORMATO_ETICHETTA_16
            picAnteprima.Image = ImageList2.Images(8)
            numEtichette = 16
            percorsoRepEtichette = PERCORSO_ETICHETTE_ART_991_331

         Case 4
            lblDescrizione.Text = FORMATO_ETICHETTA_21
            picAnteprima.Image = ImageList2.Images(10)
            numEtichette = 21
            percorsoRepEtichette = PERCORSO_ETICHETTE_ART_635_381

         Case 5
            lblDescrizione.Text = FORMATO_ETICHETTA_24
            picAnteprima.Image = ImageList2.Images(11)
            numEtichette = 24
            percorsoRepEtichette = PERCORSO_ETICHETTE_ART_635_339
         Case 6
            lblDescrizione.Text = FORMATO_ETICHETTA_DYMO
            picAnteprima.Image = ImageList2.Images(12)
            numEtichette = 0
            percorsoRepEtichette = ""
      End Select

      Dim i As Integer = 0
      cmbNumero.Items.Clear()

      If numEtichette = 0 Then
         cmbNumero.Enabled = False
      Else
         cmbNumero.Enabled = True
         For i = 1 To numEtichette
            cmbNumero.Items.Add(i)
         Next i
         cmbNumero.SelectedIndex = 0
      End If

      formatoEtichette = lstEtichette.SelectedItem
   End Sub

   Private Sub txtPrezzo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPrezzo.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
      End If
   End Sub

   Private Sub txtPrezzo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrezzo.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      Try
         Dim strFormat As New StringFormat
         Dim FontForText = New Font("Arial", 8, FontStyle.Bold)
         Dim messaggio As String = "Codice non compatibile con il tipo selezionato"

         strFormat.Alignment = StringAlignment.Center

         picCodBarre.CreateGraphics.Clear(Color.White)

         Select Case codBarre
            Case tipoCodBarre.EAN8
               If codiceBarre.EAN8(txtCodBarre, picCodBarre, 0, 0, picCodBarre.Width - 10, picCodBarre.Height - 20) = False Then
                  picCodBarre.CreateGraphics.DrawString(messaggio, FontForText, New System.Drawing.SolidBrush(picCodBarre.ForeColor), 130, 40, strFormat)
               End If

            Case tipoCodBarre.EAN13
               If codiceBarre.EAN13(txtCodBarre, picCodBarre, 0, 0, picCodBarre.Width - 10, picCodBarre.Height - 20) = False Then
                  picCodBarre.CreateGraphics.DrawString(messaggio, FontForText, New System.Drawing.SolidBrush(picCodBarre.ForeColor), 130, 40, strFormat)
               End If

            Case tipoCodBarre.CODE32
               If codiceBarre.CODE32(txtCodBarre, picCodBarre, 0, 0, picCodBarre.Width - 10, picCodBarre.Height - 20) = False Then
                  picCodBarre.CreateGraphics.DrawString(messaggio, FontForText, New System.Drawing.SolidBrush(picCodBarre.ForeColor), 130, 40, strFormat)
               End If

            Case tipoCodBarre.CODE39
               If codiceBarre.CODE39(txtCodBarre, picCodBarre, 0, 0, picCodBarre.Width - 10, picCodBarre.Height - 20) = False Then
                  picCodBarre.CreateGraphics.DrawString(messaggio, FontForText, New System.Drawing.SolidBrush(picCodBarre.ForeColor), 130, 40, strFormat)
               End If

            Case tipoCodBarre.CODE128
               If codiceBarre.CODE128(txtCodBarre, picCodBarre, 0, 0, picCodBarre.Width - 10, picCodBarre.Height - 20) = False Then
                  picCodBarre.CreateGraphics.DrawString(messaggio, FontForText, New System.Drawing.SolidBrush(picCodBarre.ForeColor), 130, 40, strFormat)
               End If

            Case tipoCodBarre.BCD_MATRIX
               If codiceBarre.BCDMatrix(txtCodBarre, picCodBarre, 0, 0, picCodBarre.Width - 10, picCodBarre.Height - 20) = False Then
                  picCodBarre.CreateGraphics.DrawString(messaggio, FontForText, New System.Drawing.SolidBrush(picCodBarre.ForeColor), 130, 40, strFormat)
               End If

            Case tipoCodBarre.ITF_INTERLEAVED
               If codiceBarre.INTERLEAVED(txtCodBarre, picCodBarre, 0, 0, picCodBarre.Width - 10, picCodBarre.Height - 20) = False Then
                  picCodBarre.CreateGraphics.DrawString(messaggio, FontForText, New System.Drawing.SolidBrush(picCodBarre.ForeColor), 130, 40, strFormat)
               End If
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         sender.Enabled = False
      End Try
   End Sub

   Private Sub lstTipoCodBarre_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstTipoCodBarre.SelectedIndexChanged
      Try
         Select Case lstTipoCodBarre.SelectedIndex()
            Case 0
               codBarre = tipoCodBarre.EAN8
            Case 1
               codBarre = tipoCodBarre.EAN13
            Case 2
               codBarre = tipoCodBarre.CODE32
            Case 3
               codBarre = tipoCodBarre.CODE39
            Case 4
               codBarre = tipoCodBarre.CODE128
            Case 5
               codBarre = tipoCodBarre.BCD_MATRIX
            Case 6
               codBarre = tipoCodBarre.ITF_INTERLEAVED
         End Select

         Timer1.Enabled = True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub chkData_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkData.CheckedChanged
      If chkData.Checked = True Then
         dtpData.Enabled = False
      Else
         dtpData.Enabled = True
      End If
   End Sub

#End Region



End Class
