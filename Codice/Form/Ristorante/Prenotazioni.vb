' Nome form:            frmPrenotazioni
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 28/02/2006
' Descrizione:          Scheda prenotazione risorse.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmPrenotazioni
   Inherits System.Windows.Forms.Form


#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(Optional ByVal pData As String = "", Optional ByVal pRisorsa As String = "", Optional ByVal pOra As String = "")
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
      Risorsa = pRisorsa
      Ora = pOra
      Data = pData
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

   'NOTA: la procedura che segue � richiesta da Progettazione Windows Form.
   'Pu� essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Public WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmdColore As System.Windows.Forms.Button
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
   Friend WithEvents cmbRisorsa As System.Windows.Forms.ComboBox
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents txtPersone As System.Windows.Forms.TextBox
   Friend WithEvents cmbIdCliente As System.Windows.Forms.ComboBox
   Friend WithEvents dtpOraInizio As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpOraFine As System.Windows.Forms.DateTimePicker
   Public WithEvents lblNumPersone As System.Windows.Forms.Label
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents txtIdTavoloso As System.Windows.Forms.TextBox
   Friend WithEvents txtEmail As System.Windows.Forms.TextBox
   Public WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
   Public WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cmbStatoPren As System.Windows.Forms.ComboBox
   Public WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents cmbPostiRisorsa As System.Windows.Forms.ComboBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrenotazioni))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.cmbStatoPren = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.txtEmail = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.txtTelefono = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtIdTavoloso = New System.Windows.Forms.TextBox()
      Me.cmbPostiRisorsa = New System.Windows.Forms.ComboBox()
      Me.lblNumPersone = New System.Windows.Forms.Label()
      Me.dtpOraFine = New System.Windows.Forms.DateTimePicker()
      Me.dtpOraInizio = New System.Windows.Forms.DateTimePicker()
      Me.cmbIdCliente = New System.Windows.Forms.ComboBox()
      Me.txtPersone = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.cmbRisorsa = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmbCliente = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.cmdColore = New System.Windows.Forms.Button()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.txtNumero = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.TabPage6 = New System.Windows.Forms.TabPage()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.TabPage6.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(522, 26)
      Me.ToolBar1.TabIndex = 0
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'Salva
      '
      Me.Salva.ImageIndex = 0
      Me.Salva.Name = "Salva"
      Me.Salva.Tag = "Salva"
      Me.Salva.Text = "Salva"
      Me.Salva.ToolTipText = "Salva"
      '
      'Annulla
      '
      Me.Annulla.ImageIndex = 1
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
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(522, 20)
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
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(522, 313)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.cmbStatoPren)
      Me.TabPage1.Controls.Add(Me.Label13)
      Me.TabPage1.Controls.Add(Me.txtEmail)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.txtTelefono)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.txtIdTavoloso)
      Me.TabPage1.Controls.Add(Me.cmbPostiRisorsa)
      Me.TabPage1.Controls.Add(Me.lblNumPersone)
      Me.TabPage1.Controls.Add(Me.dtpOraFine)
      Me.TabPage1.Controls.Add(Me.dtpOraInizio)
      Me.TabPage1.Controls.Add(Me.cmbIdCliente)
      Me.TabPage1.Controls.Add(Me.txtPersone)
      Me.TabPage1.Controls.Add(Me.Label11)
      Me.TabPage1.Controls.Add(Me.cmbRisorsa)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.cmbCliente)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.dtpData)
      Me.TabPage1.Controls.Add(Me.cmdColore)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.txtNumero)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(514, 287)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'cmbStatoPren
      '
      Me.cmbStatoPren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatoPren.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbStatoPren.Location = New System.Drawing.Point(128, 248)
      Me.cmbStatoPren.Name = "cmbStatoPren"
      Me.cmbStatoPren.Size = New System.Drawing.Size(224, 21)
      Me.cmbStatoPren.TabIndex = 9
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(24, 248)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(99, 13)
      Me.Label13.TabIndex = 235
      Me.Label13.Text = "Stato prenotazione:"
      '
      'txtEmail
      '
      Me.txtEmail.Location = New System.Drawing.Point(344, 216)
      Me.txtEmail.Name = "txtEmail"
      Me.txtEmail.Size = New System.Drawing.Size(152, 20)
      Me.txtEmail.TabIndex = 8
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(296, 216)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(38, 13)
      Me.Label7.TabIndex = 229
      Me.Label7.Text = "E-mail:"
      '
      'txtTelefono
      '
      Me.txtTelefono.Location = New System.Drawing.Point(128, 216)
      Me.txtTelefono.Name = "txtTelefono"
      Me.txtTelefono.Size = New System.Drawing.Size(152, 20)
      Me.txtTelefono.TabIndex = 7
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(24, 216)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(52, 13)
      Me.Label4.TabIndex = 227
      Me.Label4.Text = "Telefono:"
      '
      'txtIdTavoloso
      '
      Me.txtIdTavoloso.Location = New System.Drawing.Point(256, 24)
      Me.txtIdTavoloso.Name = "txtIdTavoloso"
      Me.txtIdTavoloso.Size = New System.Drawing.Size(72, 20)
      Me.txtIdTavoloso.TabIndex = 225
      Me.txtIdTavoloso.Visible = False
      '
      'cmbPostiRisorsa
      '
      Me.cmbPostiRisorsa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPostiRisorsa.Location = New System.Drawing.Point(280, 144)
      Me.cmbPostiRisorsa.Name = "cmbPostiRisorsa"
      Me.cmbPostiRisorsa.Size = New System.Drawing.Size(70, 21)
      Me.cmbPostiRisorsa.TabIndex = 224
      Me.cmbPostiRisorsa.Visible = False
      '
      'lblNumPersone
      '
      Me.lblNumPersone.AutoSize = True
      Me.lblNumPersone.BackColor = System.Drawing.Color.Transparent
      Me.lblNumPersone.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblNumPersone.ForeColor = System.Drawing.Color.Black
      Me.lblNumPersone.Location = New System.Drawing.Point(360, 120)
      Me.lblNumPersone.Name = "lblNumPersone"
      Me.lblNumPersone.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblNumPersone.Size = New System.Drawing.Size(14, 13)
      Me.lblNumPersone.TabIndex = 204
      Me.lblNumPersone.Text = "#"
      '
      'dtpOraFine
      '
      Me.dtpOraFine.CustomFormat = ""
      Me.dtpOraFine.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpOraFine.Location = New System.Drawing.Point(272, 184)
      Me.dtpOraFine.Name = "dtpOraFine"
      Me.dtpOraFine.ShowUpDown = True
      Me.dtpOraFine.Size = New System.Drawing.Size(80, 20)
      Me.dtpOraFine.TabIndex = 6
      Me.dtpOraFine.Value = New Date(2006, 8, 23, 0, 0, 0, 0)
      '
      'dtpOraInizio
      '
      Me.dtpOraInizio.CustomFormat = ""
      Me.dtpOraInizio.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpOraInizio.Location = New System.Drawing.Point(128, 184)
      Me.dtpOraInizio.Name = "dtpOraInizio"
      Me.dtpOraInizio.ShowUpDown = True
      Me.dtpOraInizio.Size = New System.Drawing.Size(80, 20)
      Me.dtpOraInizio.TabIndex = 5
      Me.dtpOraInizio.Value = New Date(2013, 2, 16, 0, 0, 0, 0)
      '
      'cmbIdCliente
      '
      Me.cmbIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbIdCliente.Location = New System.Drawing.Point(424, 112)
      Me.cmbIdCliente.Name = "cmbIdCliente"
      Me.cmbIdCliente.Size = New System.Drawing.Size(70, 21)
      Me.cmbIdCliente.TabIndex = 203
      Me.cmbIdCliente.Visible = False
      '
      'txtPersone
      '
      Me.txtPersone.Location = New System.Drawing.Point(128, 152)
      Me.txtPersone.Name = "txtPersone"
      Me.txtPersone.Size = New System.Drawing.Size(80, 20)
      Me.txtPersone.TabIndex = 4
      Me.txtPersone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(24, 152)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(49, 13)
      Me.Label11.TabIndex = 202
      Me.Label11.Text = "Persone:"
      '
      'cmbRisorsa
      '
      Me.cmbRisorsa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRisorsa.Location = New System.Drawing.Point(128, 120)
      Me.cmbRisorsa.Name = "cmbRisorsa"
      Me.cmbRisorsa.Size = New System.Drawing.Size(224, 21)
      Me.cmbRisorsa.TabIndex = 3
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(24, 120)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(43, 13)
      Me.Label3.TabIndex = 199
      Me.Label3.Text = "Tavolo:"
      '
      'cmbCliente
      '
      Me.cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCliente.Location = New System.Drawing.Point(128, 88)
      Me.cmbCliente.Name = "cmbCliente"
      Me.cmbCliente.Size = New System.Drawing.Size(368, 21)
      Me.cmbCliente.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(216, 184)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(45, 13)
      Me.Label2.TabIndex = 197
      Me.Label2.Text = "Alle ore:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(24, 56)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(33, 13)
      Me.Label1.TabIndex = 195
      Me.Label1.Text = "Data:"
      '
      'dtpData
      '
      Me.dtpData.Location = New System.Drawing.Point(128, 56)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(224, 20)
      Me.dtpData.TabIndex = 1
      '
      'cmdColore
      '
      Me.cmdColore.BackColor = System.Drawing.Color.White
      Me.cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColore.Location = New System.Drawing.Point(416, 56)
      Me.cmdColore.Name = "cmdColore"
      Me.cmdColore.Size = New System.Drawing.Size(80, 19)
      Me.cmdColore.TabIndex = 10
      Me.cmdColore.TabStop = False
      Me.cmdColore.UseVisualStyleBackColor = False
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(368, 56)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(40, 13)
      Me.Label8.TabIndex = 193
      Me.Label8.Text = "Colore:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(24, 184)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(52, 13)
      Me.Label6.TabIndex = 191
      Me.Label6.Text = "Dalle ore:"
      '
      'txtNumero
      '
      Me.txtNumero.AcceptsReturn = True
      Me.txtNumero.BackColor = System.Drawing.SystemColors.Control
      Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumero.ForeColor = System.Drawing.Color.Red
      Me.txtNumero.Location = New System.Drawing.Point(128, 24)
      Me.txtNumero.MaxLength = 0
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(120, 20)
      Me.txtNumero.TabIndex = 0
      Me.txtNumero.TabStop = False
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(24, 24)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(43, 13)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Codice:"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(24, 88)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(42, 13)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Cliente:"
      '
      'TabPage6
      '
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(514, 287)
      Me.TabPage6.TabIndex = 5
      Me.TabPage6.Text = "Note"
      '
      'txtNote
      '
      Me.txtNote.AcceptsReturn = True
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNote.Dock = System.Windows.Forms.DockStyle.Fill
      Me.txtNote.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNote.Location = New System.Drawing.Point(0, 0)
      Me.txtNote.MaxLength = 0
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(514, 287)
      Me.txtNote.TabIndex = 0
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmPrenotazioni
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(522, 359)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPrenotazioni"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Prenotazione Tavolo"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   ' B_TODO: VER. FUTURA.
   'Public IAllegati As New Allegati
   ' B_TODO: VER. FUTURA.
   'Const TAB_ALLEGATI As String = "Allegati"

   Dim Ora As String
   Dim Risorsa As String
   Dim Data As String

   Dim nomeTavolo As String

   Private IPren As New Prenotazione
   Private CConvalida As New ConvalidaKeyPress

   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_TAVOLI As String = "Tavoli"
   Const TAB_STATO_PREN As String = "StatoPren"
   Const NOME_TABELLA As String = "Prenotazioni"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Private Function SalvaDati() As Boolean
      Try
         With IPren
            ' Assegna i dati dei campi della classe alle caselle di testo.

            ' ID prenotazione da Tavoloso. Non viene utilizzata!
            .IdPren = txtIdTavoloso.Text

            If dtpData.Value < Date.Today Then
               MessageBox.Show("Data non valida! La data di una prenotazione non pu� essere passata.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpData.Focus()
               Return False
            Else
               ' Formato italiano.
               .Data = FormattaData(dtpData.Value, True)
            End If

            If cmbCliente.Text = String.Empty Then
               MessageBox.Show("Specificare il nome di un cliente!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               cmbCliente.Focus()
               Return False
            Else
               .Cliente = cmbCliente.Text
            End If

            ' Telefono.
            .Telefono = txtTelefono.Text

            ' E-mail.
            .eMail = txtEmail.Text

            .IdRisorsa = LeggiIdRisorsa(ANA_TAVOLI, cmbRisorsa.Text)
            .DescrizioneRisorsa = cmbRisorsa.Text

            ' Controllo sul campo Persone.
            If txtPersone.Text <> "0" And txtPersone.Text <> String.Empty Then
               .Persone = txtPersone.Text
            Else
               MessageBox.Show("Numero di persone non valido! Specificare un numero di uno o pi� persone.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               txtPersone.Focus()
               Return False
            End If

            ' Controllo sul campo Ore.
            Dim timeInizio As DateTime = dtpOraInizio.Value
            Dim timeFine As DateTime = dtpOraFine.Value
            Dim timeIntervallo As DateTime = dtpOraInizio.Value.AddMinutes(30)
            Dim messaggio As String = "Ore non valide!" & vbCrLf & _
                                      "Le ore di una prenotazione non possono essere invertite, ravvicinate o passate. " & vbCrLf & _
                                      "Specificare un intervallo di ore di almeno trenta minuti."
            ' Se l'ora � uguale.
            If timeInizio = timeFine Then
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpOraFine.Focus()
               Return False

            ElseIf timeFine < timeInizio Then
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpOraFine.Focus()
               Return False

            ElseIf timeInizio < DateTime.Now And dtpData.Value = Date.Today Then
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpOraInizio.Focus()
               Return False

            ElseIf timeFine < DateTime.Now And dtpData.Value = Date.Today Then
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpOraFine.Focus()
               Return False

            ElseIf timeFine < timeIntervallo Then
               MessageBox.Show(messaggio, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               dtpOraFine.Focus()
               Return False
            Else
               .OraInizio = RimuoviSecondi(dtpOraInizio.Text)
               .OraFine = RimuoviSecondi(dtpOraFine.Text)
            End If

            .stato = cmbStatoPren.Text
            .Note = txtNote.Text

            If .Colore = 0 Then
               .Colore = Convert.ToInt32(Color.White.ToArgb)
            End If

            '  Se la propriet� 'Tag' contiene un valore viene richiamata la procedura
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

   ' NON PIU' UTILIZZATA!
   Private Sub ModificaColore()
      'Try
      '   With ColorDialog1()
      '      .Color = cmdColore.BackColor
      '      .AllowFullOpen = True
      '      .SolidColorOnly = True

      '      If .ShowDialog = DialogResult.OK Then
      '         cmdColore.BackColor = .Color
      '      End If

      '      IPren.Colore = Convert.ToString(.Color.ToArgb)
      '   End With

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   ' B_TODO: VER. FUTURA.
   Public Sub RimuoviAllegati(ByVal tabella As String, ByVal id As Integer)
      'Try
      '   Dim Risposta As Short
      '   Dim sql As String

      '   Dim Documento As String = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text

      '   ' Chiede conferma per l'eliminazione.
      '   Risposta = MsgBox("Si desidera rimuovere il documento """ & Documento & """?" & vbCrLf & vbCrLf & _
      '                     "Non sar� pi� possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma rimozione")

      '   If Risposta = MsgBoxResult.Yes Then
      '      ' Apre la connessione.
      '      cn.Open()

      '      ' Avvia una transazione.
      '      tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

      '      ' Crea la stringa di eliminazione.
      '      sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)

      '      ' Crea il comando per la connessione corrente.
      '      Dim cmdDelete As New OleDbCommand(sql, cn, tr)

      '      ' Esegue il comando.
      '      Dim Record As Integer = cmdDelete.ExecuteNonQuery()

      '      ' Conferma la transazione.
      '      tr.Commit()

      '   End If

      'Catch ex As Exception
      '   ' Annulla la transazione.
      '   tr.Rollback()

      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   'err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   ' Chiude la connessione.
      '   cn.Close()
      'End Try
   End Sub

   ' B_TODO: VER. FUTURA.
   Private Function ImpostaDatiAllegati(ByVal note As String, ByVal ins As Boolean) As Boolean
      'Try
      '   OpenFileDialog1.Filter = "Tutti i file |*.*"

      '   OpenFileDialog1.FilterIndex = 1

      '   IAllegati.IdCliente = CInt(IPren.IdCliente)

      '   If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
      '      ' Assegna i dati dei campi della classe alle caselle di testo.
      '      IAllegati.Documento = Path.GetFileName(OpenFileDialog1.FileName)
      '      IAllegati.Data = CStr(Today)
      '      IAllegati.Ora = CStr(TimeOfDay)
      '      IAllegati.Percorso = OpenFileDialog1.FileName
      '      IAllegati.Estensione = Path.GetExtension(OpenFileDialog1.FileName)
      '   Else
      '      If ins = True Then
      '         Return False
      '      End If
      '   End If

      '   Dim val As String
      '   val = InputBox("Digitare il testo per il campo Note.", "Note", note)
      '   If val <> "" Then
      '      IAllegati.Note = val
      '   Else
      '      IAllegati.Note = note
      '   End If

      '   Return True

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Function

   ' B_TODO: VER. FUTURA.
   Private Sub ConvalidaAllegati()
      '' Carica la lista dei componenti aggiuntivi.
      'If IAllegati.LeggiDati(lvwAllegati, TAB_ALLEGATI, IPren.IdCliente) = True Then
      '   cmdModifica.Enabled = True
      '   cmdRimuovi.Enabled = True
      'Else
      '   cmdModifica.Enabled = False
      '   cmdRimuovi.Enabled = False
      'End If

   End Sub

   Public Sub CaricaListaTavoli(ByVal cmb As ComboBox, ByVal cmb1 As ComboBox, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Escludi = 'No' ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Descrizione"))
            cmb1.Items.Add(dr.Item("Posti"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Function LeggiIdRisorsa(ByVal tabella As String, ByVal descrizione As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & descrizione & "' ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Id")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Function VerificaEsistenzaPren(ByVal tabella As String, ByVal data As String, ByVal idRisorsa As String, ByVal oraInizio As String, ByVal oraFine As String) As Boolean
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Verifica l'esistenza del record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Data = '{1}' " & _
                                         "AND IdRisorsa = '{2}' AND oraInizio = '{3}' " & _
                                         "AND oraFine = '{4}'", _
                                          tabella, _
                                          data, _
                                          idRisorsa, _
                                          oraInizio, _
                                          oraFine)

         numRec = CInt(cmd.ExecuteScalar())

         If numRec = 0 Then
            Return False
         ElseIf numRec > 0 Then
            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function LeggiUltimaPren(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim id As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Verifica l'esistenza del record.
         cmd.CommandText = String.Format("SELECT MAX(Id) FROM {0}", tabella)

         id = CInt(cmd.ExecuteScalar())

         Return id

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub frmPrenotazioni_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica le liste.
         CaricaListaClienti(cmbCliente, cmbIdCliente, ANA_CLIENTI)
         CaricaListaTavoli(cmbRisorsa, cmbPostiRisorsa, ANA_TAVOLI)
         CaricaLista(cmbStatoPren, TAB_STATO_PREN)

         If cmbRisorsa.Items.Count = 0 Then
            MessageBox.Show("Non ci sono Tavoli da prenotare! " & vbCrLf & _
                            "Si suggerisce di creare un nuovo Tavolo e in seguito effettuare la prenotazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
            Exit Sub
         End If

         If Me.Tag <> "" Then
            With IPren
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtIdTavoloso.Text = .IdPren
               txtNumero.Text = .Codice
               dtpData.Value = .Data
               cmbCliente.Text = .Cliente
               txtTelefono.Text = .Telefono
               txtEmail.Text = .eMail
               cmbRisorsa.Text = .DescrizioneRisorsa
               txtPersone.Text = .Persone
               dtpOraInizio.Value = FormattaOra(.OraInizio)
               dtpOraFine.Value = FormattaOra(.OraFine)
               cmbStatoPren.Text = .Stato
               txtNote.Text = .Note

               If .Colore <> 0 Then
                  cmdColore.BackColor = Color.FromArgb(.Colore)
               End If
            End With
         Else
            With IPren
               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtNumero.Text = ""

               If Data = "" Then
                  dtpData.Value = Today
               Else
                  dtpData.Value = Convert.ToDateTime(Data)
               End If

               cmbCliente.Text = ""
               txtPersone.Text = "0"

               If Risorsa = "" Then
                  cmbRisorsa.SelectedIndex = 0
                  cmbPostiRisorsa.SelectedIndex = 0
                  lblNumPersone.Text = "Per " & cmbPostiRisorsa.SelectedItem & " persone."
               Else
                  cmbRisorsa.SelectedIndex = cmbRisorsa.Items.IndexOf(Risorsa)
               End If

               If Ora = "" Then
                  dtpOraInizio.Value = Now
               Else
                  dtpOraInizio.Value = FormattaOra(Ora)
               End If

               dtpOraFine.Value = Now
               txtNote.Text = ""
            End With
         End If

         ' Carica la lista delle degli allegati.
         'ConvalidaAllegati()

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, cmbCliente.Text, "")

         nomeTavolo = cmbRisorsa.Text

         ' Imposta lo stato attivo.
         cmbCliente.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   Private Sub frmPrenotazioni_FormClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.FormClosed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_TAVOLI)
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            If Me.Tag = "" Then
               If VerificaEsistenzaPren(NOME_TABELLA, FormattaData(dtpData.Value, True), _
                  LeggiIdRisorsa(ANA_TAVOLI, cmbRisorsa.Text), dtpOraInizio.Value.ToShortTimeString, dtpOraFine.Value.ToShortTimeString) = True Then

                  MsgBox("La prenotazione che si vuole salvare � gi� esistente!" & vbCrLf & _
                         "Si suggerisce di modificare i dati della prenotazione o annullare l'operazione.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
                  Exit Sub
               End If
            End If

            Dim persone As Integer = Convert.ToInt32(txtPersone.Text)
            Dim posti As Integer = Convert.ToInt32(cmbPostiRisorsa.Items.Item(cmbRisorsa.SelectedIndex))

            Dim risposta As Integer
            If persone > posti Then
               risposta = MsgBox("Il tavolo selezionato � troppo piccolo per il numero degli occupanti!" & vbCrLf & _
                                 "Si desidera continuare comunque?.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)
               If risposta = vbNo Then
                  Exit Sub
               End If
            End If

            If persone < posti Then
               risposta = MsgBox("Il tavolo selezionato � troppo grande per il numero degli occupanti!" & vbCrLf & _
                                 "Si desidera continuare comunque?.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)
               If risposta = vbNo Then
                  Exit Sub
               End If
            End If

            ' Salva i dati nel database.
            If SalvaDati() = True Then

               If IsNothing(g_frmPren) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmPren.AggiornaDati()

                  ' Cancella il colore di eventuali prenotazioni non pi� valide.
                  g_frmPren.ModificaStatoColoreTavolo(ANA_TAVOLI, LeggiIdRisorsa(ANA_TAVOLI, nomeTavolo), Color.MediumSeaGreen)
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & IPren.Cliente & " - Per " & IPren.Persone & " il " & IPren.Data & " alle " & IPren.OraInizio & " / " & IPren.OraFine & " - Tavolo: " & IPren.DescrizioneRisorsa & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_GESTIONE_PREN_TAVOLI)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_TAVOLI)
      End Select
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Imposta lo stato attivo.
            dtpData.Focus()
         Case 1
            ' Imposta lo stato attivo.
            txtNote.Focus()
            'Case 2
            '   ' Imposta lo stato attivo.
            '   lvwAllegati.Focus()
      End Select
   End Sub

   ' B_TODO: VER. FUTURA.
   Private Sub cmdRimuovi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Try
      '   cmdInserimento.NotifyDefault(False)

      '   RimuoviAllegati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
      '   ConvalidaAllegati()

      'Catch ex As NullReferenceException
      '   ' Visualizza un messaggio.
      '   MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      'End Try
   End Sub

   ' B_TODO: VER. FUTURA.
   Private Sub cmdModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Try
      '   cmdInserimento.NotifyDefault(False)

      '   With IAllegati
      '      .Documento = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text
      '      .Data = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(1).Text
      '      .Ora = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(2).Text
      '      .Note = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(3).Text
      '      .Percorso = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(4).Text

      '      If ImpostaDatiAllegati(.Note, False) = True Then
      '         .ModificaDati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
      '         ConvalidaAllegati()
      '      End If
      '   End With

      'Catch ex As NullReferenceException
      '   ' Visualizza un messaggio.
      '   MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      'End Try
   End Sub

   ' B_TODO: VER. FUTURA.
   Private Sub cmdInserimento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'If ImpostaDatiAllegati("", True) = True Then
      '   IAllegati.InserisciDati(TAB_ALLEGATI)
      '   ConvalidaAllegati()
      'End If

   End Sub

   ' B_TODO: VER. FUTURA.
   Private Sub lvwAllegati_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs)
      '' a_todo: DA TERMINARE - IMPOSTARE TUTTI I PROGRAMMI APRIBILI.
      'Dim Estensione As String
      'Dim NomeFile As String
      'Dim Percorso As String
      'Dim PercorsoApp As String
      'Dim NomeApp As String
      'Dim Proc As New Process

      'Try

      '   ' Nome del file.
      '   NomeFile = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text
      '   ' Percorso del file.
      '   Percorso = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(4).Text

      '   ' Ottiene l'estensione del file.
      '   Estensione = Path.GetExtension(Percorso)

      '   Select Case Estensione.ToUpper
      '      Case ".DOC", ".RTF"
      '         ' Word
      '         NomeApp = "WINWORD.EXE"

      '      Case ".XLS"
      '         ' Excel
      '         NomeApp = "EXCEL.EXE"

      '      Case ".MDB"
      '         ' Access
      '         NomeApp = "MSACCESS.EXE"

      '      Case ".PPT"
      '         ' Power Point
      '         NomeApp = "POWERPNT.EXE"

      '      Case ".TXT"
      '         ' Blocco note.
      '         NomeApp = "NOTEPAD.EXE"

      '      Case ".PDF"
      '         ' Acrobat Reader
      '         NomeApp = "ACRORD32.EXE"

      '      Case ".HTM"
      '         ' Internet Explorer
      '         NomeApp = "IEXPLORE.EXE"
      '   End Select

      '   ' Avvia l'applicazione.
      '   Proc.StartInfo.FileName = NomeApp
      '   Proc.StartInfo.Arguments = Percorso
      '   Proc.StartInfo.ErrorDialog = True
      '   Proc.StartInfo.ErrorDialogParentHandle = Me.Handle
      '   Proc.StartInfo.UseShellExecute = True
      '   Proc.Start()

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   'err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub cmdColore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColore.Click
      'ModificaColore()
      MessageBox.Show("Per assegnare un colore alla prenotazione selezionare un valore nella casella 'Stato prenotazione'.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Sub

   Private Sub txtPersone_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPersone.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub cmbRisorsa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRisorsa.SelectedIndexChanged
      lblNumPersone.Text = "Per " & cmbPostiRisorsa.Items.Item(cmbRisorsa.SelectedIndex) & " persone."
   End Sub

   Private Sub txtTelefono_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriTelefono(e.KeyChar)
   End Sub

   Private Sub cmbStatoPren_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbStatoPren.SelectedIndexChanged
      Try
         cmdColore.BackColor = Color.FromArgb(AssegnaColore(cmbStatoPren.Text, TAB_STATO_PREN))
         IPren.Colore = Convert.ToString(cmdColore.BackColor.ToArgb)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub
End Class
