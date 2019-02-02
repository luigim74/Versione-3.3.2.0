' Nome form:            frmPrenotazioni
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 28/02/2006
' Descrizione:          Scheda prenotazione risorse.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmVCPren
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

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents dtpOraFine As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpOraInizio As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmbIdCliente As System.Windows.Forms.ComboBox
   Friend WithEvents txtPersone As System.Windows.Forms.TextBox
   Public WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents cmbRisorsa As System.Windows.Forms.ComboBox
   Public WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmdColore As System.Windows.Forms.Button
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Public WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cmbPostiRisorsa As System.Windows.Forms.ComboBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdSalva As Elegant.Ui.Button
   Public WithEvents lblNumPersone As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVCPren))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
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
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cmbPostiRisorsa = New System.Windows.Forms.ComboBox()
      Me.lblNumPersone = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdSalva = New Elegant.Ui.Button()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "")
      Me.ImageList1.Images.SetKeyName(1, "")
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'dtpOraFine
      '
      Me.dtpOraFine.CustomFormat = ""
      Me.dtpOraFine.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpOraFine.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpOraFine.Location = New System.Drawing.Point(408, 176)
      Me.dtpOraFine.Name = "dtpOraFine"
      Me.dtpOraFine.ShowUpDown = True
      Me.dtpOraFine.Size = New System.Drawing.Size(112, 29)
      Me.dtpOraFine.TabIndex = 7
      Me.dtpOraFine.Value = New Date(2006, 8, 23, 0, 0, 0, 0)
      '
      'dtpOraInizio
      '
      Me.dtpOraInizio.CustomFormat = ""
      Me.dtpOraInizio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpOraInizio.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpOraInizio.Location = New System.Drawing.Point(128, 176)
      Me.dtpOraInizio.Name = "dtpOraInizio"
      Me.dtpOraInizio.ShowUpDown = True
      Me.dtpOraInizio.Size = New System.Drawing.Size(120, 29)
      Me.dtpOraInizio.TabIndex = 6
      Me.dtpOraInizio.Value = New Date(2006, 8, 23, 0, 0, 0, 0)
      '
      'cmbIdCliente
      '
      Me.cmbIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbIdCliente.Location = New System.Drawing.Point(448, 88)
      Me.cmbIdCliente.Name = "cmbIdCliente"
      Me.cmbIdCliente.Size = New System.Drawing.Size(70, 21)
      Me.cmbIdCliente.TabIndex = 220
      Me.cmbIdCliente.Visible = False
      '
      'txtPersone
      '
      Me.txtPersone.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPersone.Location = New System.Drawing.Point(128, 136)
      Me.txtPersone.Name = "txtPersone"
      Me.txtPersone.Size = New System.Drawing.Size(120, 26)
      Me.txtPersone.TabIndex = 4
      Me.txtPersone.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(16, 136)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(99, 20)
      Me.Label11.TabIndex = 219
      Me.Label11.Text = "PERSONE:"
      '
      'cmbRisorsa
      '
      Me.cmbRisorsa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRisorsa.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbRisorsa.Location = New System.Drawing.Point(128, 96)
      Me.cmbRisorsa.Name = "cmbRisorsa"
      Me.cmbRisorsa.Size = New System.Drawing.Size(208, 28)
      Me.cmbRisorsa.TabIndex = 3
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(16, 96)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(84, 20)
      Me.Label3.TabIndex = 218
      Me.Label3.Text = "TAVOLO:"
      '
      'cmbCliente
      '
      Me.cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCliente.Location = New System.Drawing.Point(128, 56)
      Me.cmbCliente.Name = "cmbCliente"
      Me.cmbCliente.Size = New System.Drawing.Size(392, 28)
      Me.cmbCliente.TabIndex = 2
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(304, 176)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(101, 20)
      Me.Label2.TabIndex = 217
      Me.Label2.Text = "ALLE ORE:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(185, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(61, 20)
      Me.Label1.TabIndex = 216
      Me.Label1.Text = "DATA:"
      '
      'dtpData
      '
      Me.dtpData.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpData.Location = New System.Drawing.Point(248, 16)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(272, 29)
      Me.dtpData.TabIndex = 1
      '
      'cmdColore
      '
      Me.cmdColore.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColore.Location = New System.Drawing.Point(408, 136)
      Me.cmdColore.Name = "cmdColore"
      Me.cmdColore.Size = New System.Drawing.Size(112, 32)
      Me.cmdColore.TabIndex = 5
      Me.cmdColore.TabStop = False
      Me.cmdColore.UseVisualStyleBackColor = False
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(304, 136)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(87, 20)
      Me.Label8.TabIndex = 215
      Me.Label8.Text = "COLORE:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(16, 176)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(114, 20)
      Me.Label6.TabIndex = 214
      Me.Label6.Text = "DALLE ORE:"
      '
      'txtNumero
      '
      Me.txtNumero.AcceptsReturn = True
      Me.txtNumero.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumero.ForeColor = System.Drawing.Color.Red
      Me.txtNumero.Location = New System.Drawing.Point(128, 16)
      Me.txtNumero.MaxLength = 0
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(56, 26)
      Me.txtNumero.TabIndex = 0
      Me.txtNumero.TabStop = False
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(16, 16)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(82, 20)
      Me.Label5.TabIndex = 213
      Me.Label5.Text = "CODICE:"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(16, 56)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(88, 20)
      Me.Label20.TabIndex = 212
      Me.Label20.Text = "CLIENTE:"
      '
      'txtNote
      '
      Me.txtNote.AcceptsReturn = True
      Me.txtNote.BackColor = System.Drawing.SystemColors.Window
      Me.txtNote.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNote.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNote.Location = New System.Drawing.Point(128, 216)
      Me.txtNote.MaxLength = 0
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.txtNote.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(392, 124)
      Me.txtNote.TabIndex = 8
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 216)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(61, 20)
      Me.Label4.TabIndex = 222
      Me.Label4.Text = "NOTE:"
      '
      'cmbPostiRisorsa
      '
      Me.cmbPostiRisorsa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPostiRisorsa.Location = New System.Drawing.Point(264, 136)
      Me.cmbPostiRisorsa.Name = "cmbPostiRisorsa"
      Me.cmbPostiRisorsa.Size = New System.Drawing.Size(70, 21)
      Me.cmbPostiRisorsa.TabIndex = 223
      Me.cmbPostiRisorsa.Visible = False
      '
      'lblNumPersone
      '
      Me.lblNumPersone.AutoSize = True
      Me.lblNumPersone.BackColor = System.Drawing.Color.Transparent
      Me.lblNumPersone.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblNumPersone.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblNumPersone.ForeColor = System.Drawing.Color.Black
      Me.lblNumPersone.Location = New System.Drawing.Point(344, 96)
      Me.lblNumPersone.Name = "lblNumPersone"
      Me.lblNumPersone.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblNumPersone.Size = New System.Drawing.Size(19, 20)
      Me.lblNumPersone.TabIndex = 224
      Me.lblNumPersone.Text = "#"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Id = "0ff03341-583e-4c63-8adc-163fd9a16474"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(20, 363)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(75, 53)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 11
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "712effff-0d29-4d2b-9a14-29e9c9177fae"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(390, 363)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 10
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdSalva
      '
      Me.eui_cmdSalva.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdSalva.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSalva.Id = "12768304-546b-46ee-b0f7-4cace93143e4"
      Me.eui_cmdSalva.Location = New System.Drawing.Point(252, 363)
      Me.eui_cmdSalva.Name = "eui_cmdSalva"
      Me.eui_cmdSalva.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdSalva.TabIndex = 9
      Me.eui_cmdSalva.Text = "&Salva"
      '
      'frmVCPren
      '
      Me.AcceptButton = Me.eui_cmdSalva
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(530, 425)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdSalva)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.lblNumPersone)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.txtNote)
      Me.Controls.Add(Me.dtpOraFine)
      Me.Controls.Add(Me.dtpOraInizio)
      Me.Controls.Add(Me.cmbIdCliente)
      Me.Controls.Add(Me.txtPersone)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.cmbRisorsa)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cmbCliente)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.cmdColore)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.txtNumero)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label20)
      Me.Controls.Add(Me.cmbPostiRisorsa)
      Me.Controls.Add(Me.Label1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmVCPren"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "PRENOTAZIONE TAVOLO"
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

            If dtpData.Value < Date.Today Then
               MessageBox.Show("Data non valida! La data di una prenotazione non può essere passata.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
               .Cliente = FormattaApici(cmbCliente.Text)
            End If

            ' ID prenotazione da Tavoloso. Non viene utilizzata!
            .IdPren = String.Empty
            .IdRisorsa = LeggiIdRisorsa(ANA_TAVOLI, cmbRisorsa.Text)
            .DescrizioneRisorsa = FormattaApici(cmbRisorsa.Text)
            .Telefono = String.Empty
            .eMail = String.Empty
            .Stato = "Confermata"

            ' Controllo sul campo Persone.
            If txtPersone.Text <> "0" And txtPersone.Text <> String.Empty Then
               .Persone = txtPersone.Text
            Else
               MessageBox.Show("Numero di persone non valido! Specificare un numero di uno o più persone.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               txtPersone.Focus()
               Return False
            End If

            ' Controllo sul campo Ore.
            Dim timeInizio As DateTime = dtpOraInizio.Value
            Dim timeFine As DateTime = dtpOraFine.Value
            Dim timeIntervallo As DateTime = dtpOraInizio.Value.AddMinutes(30)
            Dim messaggio As String = "Ore non valide!" & vbCrLf &
                                      "Le ore di una prenotazione non possono essere invertite, ravvicinate o passate. " & vbCrLf &
                                      "Specificare un intervallo di ore di almeno trenta minuti."
            ' Se l'ora è uguale.
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

            .Note = FormattaApici(txtNote.Text)

            If .Colore = 0 Then
               .Colore = Convert.ToInt32(Color.White.ToArgb)
            End If

            '  Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
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

   Private Sub ModificaColore()
      Try
         With ColorDialog1()
            .Color = cmdColore.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColore.BackColor = .Color
            End If

            IPren.Colore = Convert.ToString(.Color.ToArgb)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' B_TODO: VER. FUTURA.
   Public Sub RimuoviAllegati(ByVal tabella As String, ByVal id As Integer)
      'Try
      '   Dim Risposta As Short
      '   Dim sql As String

      '   Dim Documento As String = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text

      '   ' Chiede conferma per l'eliminazione.
      '   Risposta = MsgBox("Si desidera rimuovere il documento """ & Documento & """?" & vbCrLf & vbCrLf & _
      '                     "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma rimozione")

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
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Data = '{1}' " &
                                         "AND IdRisorsa = '{2}' AND oraInizio = '{3}' " &
                                         "AND oraFine = '{4}'",
                                          tabella,
                                          data,
                                          idRisorsa,
                                          oraInizio,
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

   Private Sub frmVCPren_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         If AbilitaPalmareWindows = True Then
            g_frmVCTavoli.Timer3.Enabled = False
         End If

         If AbilitaPalmareAndroid = True Then
            g_frmVCTavoli.Timer3.Enabled = False
         End If

         ' Carica le liste.
         CaricaListaClienti(cmbCliente, cmbIdCliente, ANA_CLIENTI)
         CaricaListaTavoli(cmbRisorsa, cmbPostiRisorsa, ANA_TAVOLI)

         If cmbRisorsa.Items.Count = 0 Then
            MessageBox.Show("Non ci sono Tavoli da prenotare! " & vbCrLf &
                            "Si suggerisce di creare un nuovo Tavolo e in seguito effettuare la prenotazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
            Exit Sub
         End If

         If Me.Tag <> "" Then
            With IPren
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtNumero.Text = .Codice
               dtpData.Value = .Data
               cmbCliente.Text = .Cliente
               cmbRisorsa.Text = .DescrizioneRisorsa
               txtPersone.Text = .Persone
               dtpOraInizio.Value = FormattaOra(.OraInizio)
               dtpOraFine.Value = FormattaOra(.OraFine)
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
                  dtpData.Value = Data
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

   Private Sub frmVCPren_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If AbilitaPalmareWindows = True Then
         g_frmVCTavoli.Timer3.Enabled = True
      End If

      If AbilitaPalmareAndroid = True Then
         g_frmVCTavoli.Timer3.Enabled = True
      End If

      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_TAVOLI)
      End If
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
      ModificaColore()
   End Sub

   Private Sub cmbRisorsa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRisorsa.SelectedIndexChanged
      lblNumPersone.Text = "Per " & cmbPostiRisorsa.Items.Item(cmbRisorsa.SelectedIndex) & " persone."
   End Sub

   Private Sub eui_cmdSalva_Click(sender As Object, e As EventArgs) Handles eui_cmdSalva.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If Me.Tag = String.Empty Then
         If VerificaEsistenzaPren(NOME_TABELLA, FormattaData(dtpData.Value, True),
            LeggiIdRisorsa(ANA_TAVOLI, cmbRisorsa.Text), dtpOraInizio.Value.ToShortTimeString, dtpOraFine.Value.ToShortTimeString) = True Then

            MsgBox("La prenotazione che si vuole salvare è già esistente!" & vbCrLf &
                   "Si suggerisce di modificare i dati della prenotazione o annullare l'operazione.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
            Exit Sub
         End If
      End If

      Dim persone As Integer = Convert.ToInt32(txtPersone.Text)
      Dim posti As Integer = Convert.ToInt32(cmbPostiRisorsa.Items.Item(cmbRisorsa.SelectedIndex))

      Dim risposta As Integer
      If persone > posti Then
         risposta = MsgBox("Il tavolo selezionato è troppo piccolo per il numero degli occupanti!" & vbCrLf &
                           "Si desidera continuare comunque?.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)
         If risposta = vbNo Then
            Exit Sub
         End If
      End If

      If persone < posti Then
         risposta = MsgBox("Il tavolo selezionato è troppo grande per il numero degli occupanti!" & vbCrLf &
                           "Si desidera continuare comunque?.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)
         If risposta = vbNo Then
            Exit Sub
         End If
      End If

      ' Salva i dati nel database.
      If SalvaDati() = True Then
         If IsNothing(g_frmVCPren) = False Then
            ' Aggiorna la griglia dati.
            g_frmVCPren.AggiornaDati()
            ' Cancella il colore di eventuali prenotazioni non più valide.
            g_frmVCTavoli.CancellaColorePren(LeggiIdRisorsa(ANA_TAVOLI, nomeTavolo))
            ' Aggiorna la situazione dei tavoli.
            g_frmVCTavoli.AggiornaTavoli()
         End If

         ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
         Me.Tag = "0"

         ' Chiude la finestra.
         Me.Close()

         ' Registra loperazione effettuata dall'operatore identificato.
         Dim strDescrizione As String = " (" & IPren.Cliente & " - Per " & IPren.Persone & " il " & IPren.Data & " alle " & IPren.OraInizio & " / " & IPren.OraFine & " - Tavolo: " & IPren.DescrizioneRisorsa & ")"

         g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_GESTIONE_PREN_TAVOLI)
      Else
         DialogResult = DialogResult.None
      End If
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
      Me.Tag = "0"

      ' Chiude la finestra.
      Me.Close()

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_TAVOLI)
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      ' Apre la Tastiera virtuale di Windows (XP, 7, 8, 10).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub
End Class
