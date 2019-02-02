Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Data.OleDb

Public Class IndirizziEtichette
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
   Public WithEvents txtNome As System.Windows.Forms.TextBox
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents txtCognome As System.Windows.Forms.TextBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents label As System.Windows.Forms.Label
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents cmbTitolo As System.Windows.Forms.ComboBox
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
   Friend WithEvents cmbIdClienti As System.Windows.Forms.ComboBox
   Friend WithEvents cmbClienti As System.Windows.Forms.ComboBox
   Public WithEvents txtIndirizzo As System.Windows.Forms.TextBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents ImageList2 As System.Windows.Forms.ImageList
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IndirizziEtichette))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.cmbIdClienti = New System.Windows.Forms.ComboBox()
      Me.cmbClienti = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtNumEtichette = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cmbTitolo = New System.Windows.Forms.ComboBox()
      Me.txtNome = New System.Windows.Forms.TextBox()
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtIndirizzo = New System.Windows.Forms.TextBox()
      Me.txtCognome = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.label = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
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
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.TabPage3.SuspendLayout()
      CType(Me.picAnteprima, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.ToolBar1.Size = New System.Drawing.Size(539, 26)
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
      Me.Panel1.Size = New System.Drawing.Size(539, 20)
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
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(539, 321)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.cmbIdClienti)
      Me.TabPage1.Controls.Add(Me.cmbClienti)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.txtNumEtichette)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.cmbTitolo)
      Me.TabPage1.Controls.Add(Me.txtNome)
      Me.TabPage1.Controls.Add(Me.txtProv)
      Me.TabPage1.Controls.Add(Me.txtCap)
      Me.TabPage1.Controls.Add(Me.txtCittà)
      Me.TabPage1.Controls.Add(Me.txtIndirizzo)
      Me.TabPage1.Controls.Add(Me.txtCognome)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.label)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.ForeColor = System.Drawing.SystemColors.Desktop
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(531, 295)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      Me.TabPage1.ToolTipText = "Dati principali"
      '
      'cmbIdClienti
      '
      Me.cmbIdClienti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdClienti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbIdClienti.Location = New System.Drawing.Point(480, 32)
      Me.cmbIdClienti.Name = "cmbIdClienti"
      Me.cmbIdClienti.Size = New System.Drawing.Size(40, 21)
      Me.cmbIdClienti.TabIndex = 233
      Me.cmbIdClienti.Visible = False
      '
      'cmbClienti
      '
      Me.cmbClienti.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbClienti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbClienti.Location = New System.Drawing.Point(40, 32)
      Me.cmbClienti.Name = "cmbClienti"
      Me.cmbClienti.Size = New System.Drawing.Size(432, 21)
      Me.cmbClienti.TabIndex = 0
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
      Me.Label1.Size = New System.Drawing.Size(140, 13)
      Me.Label1.TabIndex = 232
      Me.Label1.Text = "Seleziona dall'elenco Clienti:"
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
      Me.txtNumEtichette.TabIndex = 8
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
      'cmbTitolo
      '
      Me.cmbTitolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTitolo.Location = New System.Drawing.Point(112, 72)
      Me.cmbTitolo.Name = "cmbTitolo"
      Me.cmbTitolo.Size = New System.Drawing.Size(184, 21)
      Me.cmbTitolo.TabIndex = 1
      '
      'txtNome
      '
      Me.txtNome.AcceptsReturn = True
      Me.txtNome.BackColor = System.Drawing.SystemColors.Window
      Me.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNome.Location = New System.Drawing.Point(112, 128)
      Me.txtNome.MaxLength = 50
      Me.txtNome.Name = "txtNome"
      Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNome.Size = New System.Drawing.Size(360, 20)
      Me.txtNome.TabIndex = 3
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(424, 208)
      Me.txtProv.MaxLength = 2
      Me.txtProv.Name = "txtProv"
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(48, 20)
      Me.txtProv.TabIndex = 7
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(112, 208)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(64, 20)
      Me.txtCap.TabIndex = 6
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(112, 184)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(360, 20)
      Me.txtCittà.TabIndex = 5
      '
      'txtIndirizzo
      '
      Me.txtIndirizzo.AcceptsReturn = True
      Me.txtIndirizzo.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo.Location = New System.Drawing.Point(112, 160)
      Me.txtIndirizzo.MaxLength = 100
      Me.txtIndirizzo.Name = "txtIndirizzo"
      Me.txtIndirizzo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo.Size = New System.Drawing.Size(360, 20)
      Me.txtIndirizzo.TabIndex = 4
      '
      'txtCognome
      '
      Me.txtCognome.AcceptsReturn = True
      Me.txtCognome.BackColor = System.Drawing.SystemColors.Window
      Me.txtCognome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCognome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCognome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCognome.Location = New System.Drawing.Point(112, 104)
      Me.txtCognome.MaxLength = 50
      Me.txtCognome.Name = "txtCognome"
      Me.txtCognome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCognome.Size = New System.Drawing.Size(360, 20)
      Me.txtCognome.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(40, 128)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(38, 13)
      Me.Label2.TabIndex = 170
      Me.Label2.Text = "Nome:"
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(40, 72)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(36, 13)
      Me.label.TabIndex = 169
      Me.label.Text = "Titolo:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(368, 208)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(54, 13)
      Me.Label9.TabIndex = 166
      Me.Label9.Text = "Provincia:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(40, 208)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 165
      Me.Label6.Text = "C.A.P.:"
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
      Me.Label5.Size = New System.Drawing.Size(31, 13)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Città:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(40, 160)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(48, 13)
      Me.Label4.TabIndex = 163
      Me.Label4.Text = "Indirizzo:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(40, 104)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(55, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Cognome:"
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
      Me.TabPage3.Size = New System.Drawing.Size(531, 295)
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
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'IndirizziEtichette
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(539, 367)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "IndirizziEtichette"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Etichette Indirizzi"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      CType(Me.picAnteprima, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Dichiarazioni "

   Private AEtichetteInd As New EtichetteInd
   Private CConvalida As New ConvalidaKeyPress
   Private CFormatta As New ClsFormatta

   Const ANA_CLIENTI As String = "Clienti"
   Const TAB_QUALIFICHE As String = "Qualifiche"
   Const NOME_TABELLA As String = "EtichetteIndirizzi"

   Const FORMATO_ETICHETTA_8 As String = "8 etichette per foglio; dimensioni 99.1 x 67.7 mm"
   Const FORMATO_ETICHETTA_12 As String = "12 etichette per foglio; dimensioni 63.5 x 72 mm"
   Const FORMATO_ETICHETTA_14 As String = "14 etichette per foglio; dimensioni 99.1 x 38.1 mm"
   Const FORMATO_ETICHETTA_16 As String = "16 etichette per foglio; dimensioni 99.1 x 33.1 mm"
   Const FORMATO_ETICHETTA_21 As String = "21 etichette per foglio; dimensioni 63.5 x 38.1 mm"
   Const FORMATO_ETICHETTA_24 As String = "24 etichette per foglio; dimensioni 63.5 x 33.9 mm"
   Const FORMATO_ETICHETTA_DYMO As String = "1 x 130 etichette; dimensioni 89 x 28 mm"

   Dim formatoEtichette As String = "STANDARD AVERY; FORMATO 1"

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

   Dim idCliente As String = ""

   Dim percorsoRepEtichette As String = PERCORSO_ETICHETTE_991_677
   Dim repSql As String

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

   Public Sub LeggiDatiCliente(ByVal tabella As String, ByVal id As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         idCliente = id

         Do While dr.Read
            If IsDBNull(dr.Item("Titolo")) = False Then
               cmbTitolo.Text = dr.Item("Titolo")
            Else
               cmbTitolo.Text = ""
            End If
            If IsDBNull(dr.Item("Cognome")) = False Then
               txtCognome.Text = dr.Item("Cognome")
            Else
               txtCognome.Text = ""
            End If
            If IsDBNull(dr.Item("Nome")) = False Then
               txtNome.Text = dr.Item("Nome")
            Else
               txtNome.Text = ""
            End If
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               txtIndirizzo.Text = dr.Item("Indirizzo")
            Else
               txtIndirizzo.Text = ""
            End If
            If IsDBNull(dr.Item("Cap")) = False Then
               txtCap.Text = dr.Item("Cap")
            Else
               txtCap.Text = ""
            End If
            If IsDBNull(dr.Item("Città")) = False Then
               txtCittà.Text = dr.Item("Città")
            Else
               txtCittà.Text = ""
            End If
            If IsDBNull(dr.Item("Provincia")) = False Then
               txtProv.Text = dr.Item("Provincia")
            Else
               txtProv.Text = ""
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

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
         AggiornaTabella(cmbTitolo, TAB_QUALIFICHE)

         With AEtichetteInd
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Cognome = FormattaApici(txtCognome.Text)
            .Nome = FormattaApici(txtNome.Text)
            .Titolo = FormattaApici(cmbTitolo.Text)
            .Indirizzo = FormattaApici(txtIndirizzo.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
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

   Private Sub IndirizziEtichette_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         If Me.Tag <> "" Then
            With AEtichetteInd
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCognome.Text = .Cognome
               txtNome.Text = .Nome
               cmbTitolo.Text = .Titolo
               txtIndirizzo.Text = .Indirizzo
               txtCap.Text = .Cap
               txtCittà.Text = .Città
               txtProv.Text = .Provincia
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
         CaricaListaClienti(cmbClienti, cmbIdClienti, ANA_CLIENTI)
         CaricaLista(cmbTitolo, TAB_QUALIFICHE)

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione("", txtNome.Text, txtCognome.Text)

         ' Imposta lo stato attivo.
         cmbClienti.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub IndirizziEtichette_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_STRUMENTI_ETICHETTE)
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmEtichette) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmEtichette.AggiornaDatiIndirizzi()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & AEtichetteInd.Cognome & " " & AEtichetteInd.Nome & ")"
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
               Me.cmbClienti.Focus()

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
                  If AEtichetteInd.PosStampa > 1 Then
                     cmbNumero.SelectedIndex = AEtichetteInd.PosStampa - 1
                  Else
                     cmbNumero.SelectedIndex = 0
                  End If
               End If

               ' Imposta lo stato attivo.
               lstEtichette.Focus()
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub txtCap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCap.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtNumEtichette_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumEtichette.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtNumEtichette_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumEtichette.LostFocus
      'If IsNumeric(sender.Text) Then
      '   sender.Text = CFormatta.FormattaNumero(Convert.ToInt32(sender.Text))
      'End If
   End Sub

   Private Sub cmbClienti_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbClienti.SelectedIndexChanged
      Try
         ' Ottiene l'indice dell'elemento selezionato.
         Dim index As Integer = sender.Items.IndexOf(sender.Text)

         ' Recupera l'Id del Cliente selezionato per caricare i dati.
         If index >= 0 Then
            LeggiDatiCliente(ANA_CLIENTI, cmbIdClienti.Items.Item(index))
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
            percorsoRepEtichette = PERCORSO_ETICHETTE_991_677

         Case 1
            lblDescrizione.Text = FORMATO_ETICHETTA_12
            picAnteprima.Image = ImageList2.Images(6)
            numEtichette = 12
            percorsoRepEtichette = PERCORSO_ETICHETTE_635_72

         Case 2
            lblDescrizione.Text = FORMATO_ETICHETTA_14
            picAnteprima.Image = ImageList2.Images(7)
            numEtichette = 14
            percorsoRepEtichette = PERCORSO_ETICHETTE_991_381

         Case 3
            lblDescrizione.Text = FORMATO_ETICHETTA_16
            picAnteprima.Image = ImageList2.Images(8)
            numEtichette = 16
            percorsoRepEtichette = PERCORSO_ETICHETTE_991_331

         Case 4
            lblDescrizione.Text = FORMATO_ETICHETTA_21
            picAnteprima.Image = ImageList2.Images(10)
            numEtichette = 21
            percorsoRepEtichette = PERCORSO_ETICHETTE_635_381

         Case 5
            lblDescrizione.Text = FORMATO_ETICHETTA_24
            picAnteprima.Image = ImageList2.Images(11)
            numEtichette = 24
            percorsoRepEtichette = PERCORSO_ETICHETTE_635_339
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
#End Region


End Class
