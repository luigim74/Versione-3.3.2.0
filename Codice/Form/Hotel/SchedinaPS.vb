#Region " DATI FILE.VB "
' ******************************************************************
' Nome form:            frmSchedinaPS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       13/08/2018
' Data ultima modifica: 25/08/2018
' Descrizione:          Anagrafica Schedine pubblica sicurezza.
' Note:

' Elenco Attivita:
'
' ******************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmSchedinaPS
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

   'NOTA: la procedura che segue Ë richiesta da Progettazione Windows Form.
   'PuÚ essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
   Public WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents tpComponenti As System.Windows.Forms.TabPage
   Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Public WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents cmbNumeroCamera As System.Windows.Forms.ComboBox
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmdInserisciOccupanti As Elegant.Ui.Button
   Friend WithEvents cmdEliminaOccupanti As Elegant.Ui.Button
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents cmbStato As System.Windows.Forms.ComboBox
   Public WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Public WithEvents lblPartenza As System.Windows.Forms.Label
   Public WithEvents lblArrivo As System.Windows.Forms.Label
   Friend WithEvents mcDataPartenza As System.Windows.Forms.MonthCalendar
   Public WithEvents txtNumeroNotti As System.Windows.Forms.TextBox
   Public WithEvents Label27 As System.Windows.Forms.Label
   Friend WithEvents mcDataArrivo As System.Windows.Forms.MonthCalendar
   Friend WithEvents dtpDataStampa As DateTimePicker
   Public WithEvents Label3 As Label
   Public WithEvents txtNumeroPren As TextBox
   Public WithEvents Label8 As Label
   Friend WithEvents cmbNome As ComboBox
   Friend WithEvents cmbIdCliente As ComboBox
   Public WithEvents txtNome As TextBox
   Friend WithEvents cmbCognome As ComboBox
   Friend WithEvents dtpDataNascita As DateTimePicker
   Public WithEvents Label7 As Label
   Friend WithEvents cmdApriIntestatario As Button
   Public WithEvents Label20 As Label
   Friend WithEvents cmbSesso As ComboBox
   Public WithEvents Label4 As Label
   Public WithEvents Label1 As Label
   Friend WithEvents cmbCittadinanza As ComboBox
   Public WithEvents Label21 As Label
   Friend WithEvents cmbNazioneNascita As ComboBox
   Public WithEvents Label19 As Label
   Public WithEvents txtProvNascita As TextBox
   Public WithEvents Label29 As Label
   Public WithEvents txtNumeroDoc As TextBox
   Public WithEvents Label16 As Label
   Public WithEvents Label17 As Label
   Friend WithEvents cmbTipoDoc As ComboBox
   Public WithEvents Label9 As Label
   Public WithEvents Label2 As Label
   Friend WithEvents dtpDataRilascioDoc As DateTimePicker
   Friend WithEvents cmbNazioneRilascioDoc As ComboBox
   Public WithEvents Label35 As Label
   Public WithEvents txtRilasciatoDaDoc As TextBox
   Friend WithEvents cmdNuovoIntestatario As Button
   Friend WithEvents cmbTipoAlloggiato As ComboBox
   Public WithEvents Label14 As Label
   Friend WithEvents lvwOccupanti As ListView
   Friend WithEvents ColumnHeader2 As ColumnHeader
   Friend WithEvents ColumnHeader3 As ColumnHeader
   Friend WithEvents ColumnHeader4 As ColumnHeader
   Friend WithEvents ColumnHeader5 As ColumnHeader
   Friend WithEvents ColumnHeader6 As ColumnHeader
   Friend WithEvents ColumnHeader11 As ColumnHeader
   Friend WithEvents ColumnHeader15 As ColumnHeader
   Friend WithEvents ColumnHeader16 As ColumnHeader
   Friend WithEvents ColumnHeader17 As ColumnHeader
   Friend WithEvents ColumnHeader18 As ColumnHeader
   Friend WithEvents ColumnHeader19 As ColumnHeader
   Friend WithEvents ColumnHeader1 As ColumnHeader
   Friend WithEvents ColumnHeader7 As ColumnHeader
   Friend WithEvents cmbComuneNascita As ComboBox
   Friend WithEvents cmbComuneRilascioDoc As ComboBox
   Public WithEvents Label10 As Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSchedinaPS))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.txtNumeroPren = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.dtpDataStampa = New System.Windows.Forms.DateTimePicker()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.mcDataArrivo = New System.Windows.Forms.MonthCalendar()
      Me.txtNumeroNotti = New System.Windows.Forms.TextBox()
      Me.Label27 = New System.Windows.Forms.Label()
      Me.lblPartenza = New System.Windows.Forms.Label()
      Me.lblArrivo = New System.Windows.Forms.Label()
      Me.mcDataPartenza = New System.Windows.Forms.MonthCalendar()
      Me.cmbStato = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.txtNumero = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cmbNumeroCamera = New System.Windows.Forms.ComboBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.TabPage4 = New System.Windows.Forms.TabPage()
      Me.cmbComuneNascita = New System.Windows.Forms.ComboBox()
      Me.cmbTipoAlloggiato = New System.Windows.Forms.ComboBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.cmdNuovoIntestatario = New System.Windows.Forms.Button()
      Me.cmbCittadinanza = New System.Windows.Forms.ComboBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.cmbNazioneNascita = New System.Windows.Forms.ComboBox()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.txtProvNascita = New System.Windows.Forms.TextBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.cmbSesso = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmbNome = New System.Windows.Forms.ComboBox()
      Me.cmbIdCliente = New System.Windows.Forms.ComboBox()
      Me.txtNome = New System.Windows.Forms.TextBox()
      Me.cmbCognome = New System.Windows.Forms.ComboBox()
      Me.dtpDataNascita = New System.Windows.Forms.DateTimePicker()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmdApriIntestatario = New System.Windows.Forms.Button()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.TabPage5 = New System.Windows.Forms.TabPage()
      Me.cmbComuneRilascioDoc = New System.Windows.Forms.ComboBox()
      Me.txtRilasciatoDaDoc = New System.Windows.Forms.TextBox()
      Me.cmbNazioneRilascioDoc = New System.Windows.Forms.ComboBox()
      Me.Label35 = New System.Windows.Forms.Label()
      Me.dtpDataRilascioDoc = New System.Windows.Forms.DateTimePicker()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.txtNumeroDoc = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.cmbTipoDoc = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.tpComponenti = New System.Windows.Forms.TabPage()
      Me.lvwOccupanti = New System.Windows.Forms.ListView()
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.cmdInserisciOccupanti = New Elegant.Ui.Button()
      Me.cmdEliminaOccupanti = New Elegant.Ui.Button()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.TabPage4.SuspendLayout()
      Me.TabPage5.SuspendLayout()
      Me.tpComponenti.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(560, 26)
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
      Me.ImageList1.Images.SetKeyName(0, "saveHS.png")
      Me.ImageList1.Images.SetKeyName(1, "Edit_UndoHS.png")
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(560, 20)
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
      Me.TabControl1.Controls.Add(Me.TabPage4)
      Me.TabControl1.Controls.Add(Me.TabPage5)
      Me.TabControl1.Controls.Add(Me.tpComponenti)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(560, 395)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.txtNumeroPren)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.dtpDataStampa)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.Panel2)
      Me.TabPage1.Controls.Add(Me.cmbStato)
      Me.TabPage1.Controls.Add(Me.Label13)
      Me.TabPage1.Controls.Add(Me.txtNumero)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.cmbNumeroCamera)
      Me.TabPage1.Controls.Add(Me.Label11)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.ForeColor = System.Drawing.Color.Black
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(552, 369)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati schedina"
      '
      'txtNumeroPren
      '
      Me.txtNumeroPren.AcceptsReturn = True
      Me.txtNumeroPren.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumeroPren.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumeroPren.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumeroPren.ForeColor = System.Drawing.Color.Black
      Me.txtNumeroPren.Location = New System.Drawing.Point(386, 55)
      Me.txtNumeroPren.MaxLength = 0
      Me.txtNumeroPren.Name = "txtNumeroPren"
      Me.txtNumeroPren.ReadOnly = True
      Me.txtNumeroPren.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumeroPren.Size = New System.Drawing.Size(134, 20)
      Me.txtNumeroPren.TabIndex = 3
      Me.txtNumeroPren.TabStop = False
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(269, 59)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(111, 13)
      Me.Label8.TabIndex = 245
      Me.Label8.Text = "Numero prenotazione:"
      '
      'dtpDataStampa
      '
      Me.dtpDataStampa.Checked = False
      Me.dtpDataStampa.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDataStampa.Location = New System.Drawing.Point(386, 92)
      Me.dtpDataStampa.Name = "dtpDataStampa"
      Me.dtpDataStampa.ShowCheckBox = True
      Me.dtpDataStampa.Size = New System.Drawing.Size(134, 20)
      Me.dtpDataStampa.TabIndex = 5
      Me.dtpDataStampa.Value = New Date(2005, 8, 17, 15, 37, 0, 654)
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(269, 95)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(81, 13)
      Me.Label3.TabIndex = 243
      Me.Label3.Text = "Data di stampa:"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.White
      Me.Panel2.Controls.Add(Me.mcDataArrivo)
      Me.Panel2.Controls.Add(Me.txtNumeroNotti)
      Me.Panel2.Controls.Add(Me.Label27)
      Me.Panel2.Controls.Add(Me.lblPartenza)
      Me.Panel2.Controls.Add(Me.lblArrivo)
      Me.Panel2.Controls.Add(Me.mcDataPartenza)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 134)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(552, 235)
      Me.Panel2.TabIndex = 232
      '
      'mcDataArrivo
      '
      Me.mcDataArrivo.Location = New System.Drawing.Point(32, 40)
      Me.mcDataArrivo.MaxSelectionCount = 1
      Me.mcDataArrivo.Name = "mcDataArrivo"
      Me.mcDataArrivo.ShowToday = False
      Me.mcDataArrivo.ShowTodayCircle = False
      Me.mcDataArrivo.TabIndex = 0
      Me.mcDataArrivo.TodayDate = New Date(2014, 8, 27, 0, 0, 0, 0)
      '
      'txtNumeroNotti
      '
      Me.txtNumeroNotti.AcceptsReturn = True
      Me.txtNumeroNotti.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumeroNotti.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumeroNotti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumeroNotti.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNumeroNotti.Location = New System.Drawing.Point(440, 202)
      Me.txtNumeroNotti.MaxLength = 0
      Me.txtNumeroNotti.Name = "txtNumeroNotti"
      Me.txtNumeroNotti.ReadOnly = True
      Me.txtNumeroNotti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumeroNotti.Size = New System.Drawing.Size(80, 20)
      Me.txtNumeroNotti.TabIndex = 2
      Me.txtNumeroNotti.TabStop = False
      Me.txtNumeroNotti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.BackColor = System.Drawing.Color.Transparent
      Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label27.ForeColor = System.Drawing.Color.Black
      Me.Label27.Location = New System.Drawing.Point(325, 205)
      Me.Label27.Name = "Label27"
      Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label27.Size = New System.Drawing.Size(109, 13)
      Me.Label27.TabIndex = 237
      Me.Label27.Text = "Giorni di permanenza:"
      '
      'lblPartenza
      '
      Me.lblPartenza.AutoSize = True
      Me.lblPartenza.BackColor = System.Drawing.Color.Transparent
      Me.lblPartenza.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblPartenza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblPartenza.ForeColor = System.Drawing.Color.Green
      Me.lblPartenza.Location = New System.Drawing.Point(295, 19)
      Me.lblPartenza.Name = "lblPartenza"
      Me.lblPartenza.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblPartenza.Size = New System.Drawing.Size(68, 15)
      Me.lblPartenza.TabIndex = 233
      Me.lblPartenza.Text = "Partenza:"
      '
      'lblArrivo
      '
      Me.lblArrivo.AutoSize = True
      Me.lblArrivo.BackColor = System.Drawing.Color.Transparent
      Me.lblArrivo.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblArrivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblArrivo.ForeColor = System.Drawing.Color.Red
      Me.lblArrivo.Location = New System.Drawing.Point(31, 19)
      Me.lblArrivo.Name = "lblArrivo"
      Me.lblArrivo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblArrivo.Size = New System.Drawing.Size(47, 15)
      Me.lblArrivo.TabIndex = 232
      Me.lblArrivo.Text = "Arrivo:"
      '
      'mcDataPartenza
      '
      Me.mcDataPartenza.Location = New System.Drawing.Point(295, 40)
      Me.mcDataPartenza.MaxSelectionCount = 1
      Me.mcDataPartenza.Name = "mcDataPartenza"
      Me.mcDataPartenza.ShowToday = False
      Me.mcDataPartenza.ShowTodayCircle = False
      Me.mcDataPartenza.TabIndex = 1
      '
      'cmbStato
      '
      Me.cmbStato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbStato.Items.AddRange(New Object() {"Inserita", "Inviata", "Stampata"})
      Me.cmbStato.Location = New System.Drawing.Point(118, 92)
      Me.cmbStato.Name = "cmbStato"
      Me.cmbStato.Size = New System.Drawing.Size(134, 21)
      Me.cmbStato.TabIndex = 4
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(31, 95)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(81, 13)
      Me.Label13.TabIndex = 231
      Me.Label13.Text = "Stato schedina:"
      '
      'txtNumero
      '
      Me.txtNumero.AcceptsReturn = True
      Me.txtNumero.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumero.ForeColor = System.Drawing.Color.Red
      Me.txtNumero.Location = New System.Drawing.Point(386, 20)
      Me.txtNumero.MaxLength = 0
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(134, 20)
      Me.txtNumero.TabIndex = 1
      Me.txtNumero.TabStop = False
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(269, 23)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(93, 13)
      Me.Label12.TabIndex = 200
      Me.Label12.Text = "Numero schedina:"
      '
      'cmbNumeroCamera
      '
      Me.cmbNumeroCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNumeroCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbNumeroCamera.Location = New System.Drawing.Point(118, 55)
      Me.cmbNumeroCamera.Name = "cmbNumeroCamera"
      Me.cmbNumeroCamera.Size = New System.Drawing.Size(134, 21)
      Me.cmbNumeroCamera.TabIndex = 2
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(29, 59)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(46, 13)
      Me.Label11.TabIndex = 197
      Me.Label11.Text = "Camera:"
      '
      'txtCodice
      '
      Me.txtCodice.AcceptsReturn = True
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodice.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.Red
      Me.txtCodice.Location = New System.Drawing.Point(118, 20)
      Me.txtCodice.MaxLength = 0
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodice.Size = New System.Drawing.Size(134, 20)
      Me.txtCodice.TabIndex = 0
      Me.txtCodice.TabStop = False
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(29, 23)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(43, 13)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Codice:"
      '
      'TabPage4
      '
      Me.TabPage4.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage4.Controls.Add(Me.cmbComuneNascita)
      Me.TabPage4.Controls.Add(Me.cmbTipoAlloggiato)
      Me.TabPage4.Controls.Add(Me.Label14)
      Me.TabPage4.Controls.Add(Me.cmdNuovoIntestatario)
      Me.TabPage4.Controls.Add(Me.cmbCittadinanza)
      Me.TabPage4.Controls.Add(Me.Label21)
      Me.TabPage4.Controls.Add(Me.cmbNazioneNascita)
      Me.TabPage4.Controls.Add(Me.Label19)
      Me.TabPage4.Controls.Add(Me.txtProvNascita)
      Me.TabPage4.Controls.Add(Me.Label10)
      Me.TabPage4.Controls.Add(Me.cmbSesso)
      Me.TabPage4.Controls.Add(Me.Label4)
      Me.TabPage4.Controls.Add(Me.Label1)
      Me.TabPage4.Controls.Add(Me.cmbNome)
      Me.TabPage4.Controls.Add(Me.cmbIdCliente)
      Me.TabPage4.Controls.Add(Me.txtNome)
      Me.TabPage4.Controls.Add(Me.cmbCognome)
      Me.TabPage4.Controls.Add(Me.dtpDataNascita)
      Me.TabPage4.Controls.Add(Me.Label7)
      Me.TabPage4.Controls.Add(Me.cmdApriIntestatario)
      Me.TabPage4.Controls.Add(Me.Label20)
      Me.TabPage4.Controls.Add(Me.Label6)
      Me.TabPage4.Location = New System.Drawing.Point(4, 22)
      Me.TabPage4.Name = "TabPage4"
      Me.TabPage4.Size = New System.Drawing.Size(552, 369)
      Me.TabPage4.TabIndex = 8
      Me.TabPage4.Text = "Dati Anagrafici"
      '
      'cmbComuneNascita
      '
      Me.cmbComuneNascita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbComuneNascita.Location = New System.Drawing.Point(125, 187)
      Me.cmbComuneNascita.Name = "cmbComuneNascita"
      Me.cmbComuneNascita.Size = New System.Drawing.Size(160, 21)
      Me.cmbComuneNascita.TabIndex = 7
      '
      'cmbTipoAlloggiato
      '
      Me.cmbTipoAlloggiato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoAlloggiato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoAlloggiato.Items.AddRange(New Object() {"Ospite Singolo", "Capo Famiglia", "Capo Gruppo"})
      Me.cmbTipoAlloggiato.Location = New System.Drawing.Point(394, 96)
      Me.cmbTipoAlloggiato.Name = "cmbTipoAlloggiato"
      Me.cmbTipoAlloggiato.Size = New System.Drawing.Size(112, 21)
      Me.cmbTipoAlloggiato.TabIndex = 5
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(305, 99)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(79, 13)
      Me.Label14.TabIndex = 266
      Me.Label14.Text = "Tipo alloggiato:"
      '
      'cmdNuovoIntestatario
      '
      Me.cmdNuovoIntestatario.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdNuovoIntestatario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNuovoIntestatario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdNuovoIntestatario.Location = New System.Drawing.Point(482, 58)
      Me.cmdNuovoIntestatario.Name = "cmdNuovoIntestatario"
      Me.cmdNuovoIntestatario.Size = New System.Drawing.Size(24, 22)
      Me.cmdNuovoIntestatario.TabIndex = 3
      Me.cmdNuovoIntestatario.Tag = ""
      Me.cmdNuovoIntestatario.Text = "+"
      Me.ToolTip1.SetToolTip(Me.cmdNuovoIntestatario, "Apre la finestra Clienti per un nuovo inserimento.")
      '
      'cmbCittadinanza
      '
      Me.cmbCittadinanza.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCittadinanza.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCittadinanza.Location = New System.Drawing.Point(379, 223)
      Me.cmbCittadinanza.Name = "cmbCittadinanza"
      Me.cmbCittadinanza.Size = New System.Drawing.Size(127, 21)
      Me.cmbCittadinanza.TabIndex = 10
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(305, 223)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(68, 13)
      Me.Label21.TabIndex = 263
      Me.Label21.Text = "Cittadinanza:"
      '
      'cmbNazioneNascita
      '
      Me.cmbNazioneNascita.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNazioneNascita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbNazioneNascita.Location = New System.Drawing.Point(125, 223)
      Me.cmbNazioneNascita.Name = "cmbNazioneNascita"
      Me.cmbNazioneNascita.Size = New System.Drawing.Size(160, 21)
      Me.cmbNazioneNascita.TabIndex = 9
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(21, 223)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(97, 13)
      Me.Label19.TabIndex = 261
      Me.Label19.Text = "Nazione di nascita:"
      '
      'txtProvNascita
      '
      Me.txtProvNascita.AcceptsReturn = True
      Me.txtProvNascita.BackColor = System.Drawing.SystemColors.Window
      Me.txtProvNascita.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProvNascita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProvNascita.ForeColor = System.Drawing.Color.Black
      Me.txtProvNascita.Location = New System.Drawing.Point(411, 188)
      Me.txtProvNascita.MaxLength = 0
      Me.txtProvNascita.Name = "txtProvNascita"
      Me.txtProvNascita.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProvNascita.Size = New System.Drawing.Size(94, 20)
      Me.txtProvNascita.TabIndex = 8
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(305, 188)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(102, 13)
      Me.Label10.TabIndex = 259
      Me.Label10.Text = "Provincia di nascita:"
      '
      'cmbSesso
      '
      Me.cmbSesso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbSesso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbSesso.Items.AddRange(New Object() {"M", "F"})
      Me.cmbSesso.Location = New System.Drawing.Point(124, 95)
      Me.cmbSesso.Name = "cmbSesso"
      Me.cmbSesso.Size = New System.Drawing.Size(53, 21)
      Me.cmbSesso.TabIndex = 4
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(21, 96)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(39, 13)
      Me.Label4.TabIndex = 257
      Me.Label4.Text = "Sesso:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(22, 61)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(38, 13)
      Me.Label1.TabIndex = 255
      Me.Label1.Text = "Nome:"
      '
      'cmbNome
      '
      Me.cmbNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNome.Location = New System.Drawing.Point(512, 58)
      Me.cmbNome.Name = "cmbNome"
      Me.cmbNome.Size = New System.Drawing.Size(24, 21)
      Me.cmbNome.TabIndex = 254
      Me.cmbNome.Visible = False
      '
      'cmbIdCliente
      '
      Me.cmbIdCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdCliente.Location = New System.Drawing.Point(511, 22)
      Me.cmbIdCliente.Name = "cmbIdCliente"
      Me.cmbIdCliente.Size = New System.Drawing.Size(24, 21)
      Me.cmbIdCliente.TabIndex = 253
      Me.cmbIdCliente.Visible = False
      '
      'txtNome
      '
      Me.txtNome.AcceptsReturn = True
      Me.txtNome.BackColor = System.Drawing.SystemColors.Window
      Me.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNome.Location = New System.Drawing.Point(124, 59)
      Me.txtNome.MaxLength = 0
      Me.txtNome.Name = "txtNome"
      Me.txtNome.ReadOnly = True
      Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNome.Size = New System.Drawing.Size(336, 20)
      Me.txtNome.TabIndex = 1
      Me.txtNome.TabStop = False
      '
      'cmbCognome
      '
      Me.cmbCognome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCognome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCognome.Location = New System.Drawing.Point(124, 22)
      Me.cmbCognome.Name = "cmbCognome"
      Me.cmbCognome.Size = New System.Drawing.Size(381, 21)
      Me.cmbCognome.TabIndex = 0
      '
      'dtpDataNascita
      '
      Me.dtpDataNascita.Checked = False
      Me.dtpDataNascita.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDataNascita.Location = New System.Drawing.Point(124, 150)
      Me.dtpDataNascita.Name = "dtpDataNascita"
      Me.dtpDataNascita.ShowCheckBox = True
      Me.dtpDataNascita.Size = New System.Drawing.Size(112, 20)
      Me.dtpDataNascita.TabIndex = 6
      Me.dtpDataNascita.Value = New Date(2005, 8, 17, 15, 37, 0, 654)
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(21, 150)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(81, 13)
      Me.Label7.TabIndex = 252
      Me.Label7.Text = "Data di nascita:"
      '
      'cmdApriIntestatario
      '
      Me.cmdApriIntestatario.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdApriIntestatario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdApriIntestatario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriIntestatario.Location = New System.Drawing.Point(460, 58)
      Me.cmdApriIntestatario.Name = "cmdApriIntestatario"
      Me.cmdApriIntestatario.Size = New System.Drawing.Size(24, 22)
      Me.cmdApriIntestatario.TabIndex = 2
      Me.cmdApriIntestatario.Tag = ""
      Me.cmdApriIntestatario.Text = "..."
      Me.ToolTip1.SetToolTip(Me.cmdApriIntestatario, "Apre la finestra Clienti per un nuovo inserimento.")
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(21, 25)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(55, 13)
      Me.Label20.TabIndex = 251
      Me.Label20.Text = "Cognome:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(21, 188)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(88, 13)
      Me.Label6.TabIndex = 246
      Me.Label6.Text = "Luogo di nascita:"
      '
      'TabPage5
      '
      Me.TabPage5.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage5.Controls.Add(Me.cmbComuneRilascioDoc)
      Me.TabPage5.Controls.Add(Me.txtRilasciatoDaDoc)
      Me.TabPage5.Controls.Add(Me.cmbNazioneRilascioDoc)
      Me.TabPage5.Controls.Add(Me.Label35)
      Me.TabPage5.Controls.Add(Me.dtpDataRilascioDoc)
      Me.TabPage5.Controls.Add(Me.Label29)
      Me.TabPage5.Controls.Add(Me.txtNumeroDoc)
      Me.TabPage5.Controls.Add(Me.Label16)
      Me.TabPage5.Controls.Add(Me.Label17)
      Me.TabPage5.Controls.Add(Me.cmbTipoDoc)
      Me.TabPage5.Controls.Add(Me.Label9)
      Me.TabPage5.Controls.Add(Me.Label2)
      Me.TabPage5.Location = New System.Drawing.Point(4, 22)
      Me.TabPage5.Name = "TabPage5"
      Me.TabPage5.Size = New System.Drawing.Size(552, 369)
      Me.TabPage5.TabIndex = 4
      Me.TabPage5.Text = "Documento di riconoscimento"
      '
      'cmbComuneRilascioDoc
      '
      Me.cmbComuneRilascioDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbComuneRilascioDoc.Location = New System.Drawing.Point(113, 62)
      Me.cmbComuneRilascioDoc.Name = "cmbComuneRilascioDoc"
      Me.cmbComuneRilascioDoc.Size = New System.Drawing.Size(160, 21)
      Me.cmbComuneRilascioDoc.TabIndex = 302
      '
      'txtRilasciatoDaDoc
      '
      Me.txtRilasciatoDaDoc.AcceptsReturn = True
      Me.txtRilasciatoDaDoc.BackColor = System.Drawing.SystemColors.Window
      Me.txtRilasciatoDaDoc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRilasciatoDaDoc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRilasciatoDaDoc.Location = New System.Drawing.Point(389, 100)
      Me.txtRilasciatoDaDoc.MaxLength = 0
      Me.txtRilasciatoDaDoc.Name = "txtRilasciatoDaDoc"
      Me.txtRilasciatoDaDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRilasciatoDaDoc.Size = New System.Drawing.Size(149, 20)
      Me.txtRilasciatoDaDoc.TabIndex = 5
      '
      'cmbNazioneRilascioDoc
      '
      Me.cmbNazioneRilascioDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNazioneRilascioDoc.Location = New System.Drawing.Point(389, 63)
      Me.cmbNazioneRilascioDoc.Name = "cmbNazioneRilascioDoc"
      Me.cmbNazioneRilascioDoc.Size = New System.Drawing.Size(149, 21)
      Me.cmbNazioneRilascioDoc.TabIndex = 3
      '
      'Label35
      '
      Me.Label35.AutoSize = True
      Me.Label35.BackColor = System.Drawing.Color.Transparent
      Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label35.ForeColor = System.Drawing.Color.Black
      Me.Label35.Location = New System.Drawing.Point(288, 65)
      Me.Label35.Name = "Label35"
      Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label35.Size = New System.Drawing.Size(95, 13)
      Me.Label35.TabIndex = 301
      Me.Label35.Text = "Nazione di rilascio:"
      '
      'dtpDataRilascioDoc
      '
      Me.dtpDataRilascioDoc.Checked = False
      Me.dtpDataRilascioDoc.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDataRilascioDoc.Location = New System.Drawing.Point(113, 100)
      Me.dtpDataRilascioDoc.Name = "dtpDataRilascioDoc"
      Me.dtpDataRilascioDoc.ShowCheckBox = True
      Me.dtpDataRilascioDoc.Size = New System.Drawing.Size(161, 20)
      Me.dtpDataRilascioDoc.TabIndex = 4
      Me.dtpDataRilascioDoc.Value = New Date(2005, 8, 17, 15, 37, 0, 654)
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.BackColor = System.Drawing.Color.Transparent
      Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label29.ForeColor = System.Drawing.Color.Black
      Me.Label29.Location = New System.Drawing.Point(12, 65)
      Me.Label29.Name = "Label29"
      Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label29.Size = New System.Drawing.Size(95, 13)
      Me.Label29.TabIndex = 284
      Me.Label29.Text = "Comune di rilascio:"
      '
      'txtNumeroDoc
      '
      Me.txtNumeroDoc.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumeroDoc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumeroDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumeroDoc.ForeColor = System.Drawing.Color.Black
      Me.txtNumeroDoc.Location = New System.Drawing.Point(389, 22)
      Me.txtNumeroDoc.MaxLength = 0
      Me.txtNumeroDoc.Name = "txtNumeroDoc"
      Me.txtNumeroDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumeroDoc.Size = New System.Drawing.Size(150, 20)
      Me.txtNumeroDoc.TabIndex = 1
      Me.txtNumeroDoc.TabStop = False
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(12, 100)
      Me.Label16.Name = "Label16"
      Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label16.Size = New System.Drawing.Size(68, 13)
      Me.Label16.TabIndex = 274
      Me.Label16.Text = "Data rilascio:"
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(288, 22)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(47, 13)
      Me.Label17.TabIndex = 273
      Me.Label17.Text = "Numero:"
      '
      'cmbTipoDoc
      '
      Me.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoDoc.Location = New System.Drawing.Point(113, 22)
      Me.cmbTipoDoc.Name = "cmbTipoDoc"
      Me.cmbTipoDoc.Size = New System.Drawing.Size(161, 21)
      Me.cmbTipoDoc.TabIndex = 0
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(12, 22)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(87, 13)
      Me.Label9.TabIndex = 272
      Me.Label9.Text = "Tipo documento:"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(288, 100)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(71, 13)
      Me.Label2.TabIndex = 271
      Me.Label2.Text = "Rilasciato da:"
      '
      'tpComponenti
      '
      Me.tpComponenti.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tpComponenti.Controls.Add(Me.lvwOccupanti)
      Me.tpComponenti.Controls.Add(Me.cmdInserisciOccupanti)
      Me.tpComponenti.Controls.Add(Me.cmdEliminaOccupanti)
      Me.tpComponenti.Location = New System.Drawing.Point(4, 22)
      Me.tpComponenti.Name = "tpComponenti"
      Me.tpComponenti.Size = New System.Drawing.Size(552, 369)
      Me.tpComponenti.TabIndex = 7
      Me.tpComponenti.Text = "Altri componenti"
      '
      'lvwOccupanti
      '
      Me.lvwOccupanti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader11, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17, Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader1, Me.ColumnHeader7})
      Me.lvwOccupanti.FullRowSelect = True
      Me.lvwOccupanti.Location = New System.Drawing.Point(0, 0)
      Me.lvwOccupanti.MultiSelect = False
      Me.lvwOccupanti.Name = "lvwOccupanti"
      Me.lvwOccupanti.Size = New System.Drawing.Size(552, 328)
      Me.lvwOccupanti.TabIndex = 3
      Me.lvwOccupanti.UseCompatibleStateImageBehavior = False
      Me.lvwOccupanti.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Indice"
      Me.ColumnHeader2.Width = 0
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Cognome"
      Me.ColumnHeader3.Width = 150
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Text = "Nome"
      Me.ColumnHeader4.Width = 100
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Text = "Sesso"
      Me.ColumnHeader5.Width = 50
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.Text = "Data di Nascita"
      Me.ColumnHeader6.Width = 90
      '
      'ColumnHeader11
      '
      Me.ColumnHeader11.Text = "Luogo di Nascita"
      Me.ColumnHeader11.Width = 120
      '
      'ColumnHeader15
      '
      Me.ColumnHeader15.Text = "Prov. Nascita"
      Me.ColumnHeader15.Width = 80
      '
      'ColumnHeader16
      '
      Me.ColumnHeader16.Text = "Nazione Nascita"
      Me.ColumnHeader16.Width = 100
      '
      'ColumnHeader17
      '
      Me.ColumnHeader17.Text = "Permanenza"
      Me.ColumnHeader17.Width = 80
      '
      'ColumnHeader18
      '
      Me.ColumnHeader18.Text = "Tipo Alloggiato"
      Me.ColumnHeader18.Width = 100
      '
      'ColumnHeader19
      '
      Me.ColumnHeader19.Text = "Codice"
      Me.ColumnHeader19.Width = 0
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Cittadinanza"
      Me.ColumnHeader1.Width = 0
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Text = "DataArrivo"
      Me.ColumnHeader7.Width = 0
      '
      'cmdInserisciOccupanti
      '
      Me.cmdInserisciOccupanti.Id = "5cb4629d-8026-4d6c-9815-611d4bacb7c7"
      Me.cmdInserisciOccupanti.Location = New System.Drawing.Point(331, 332)
      Me.cmdInserisciOccupanti.Name = "cmdInserisciOccupanti"
      Me.cmdInserisciOccupanti.Size = New System.Drawing.Size(104, 32)
      Me.cmdInserisciOccupanti.TabIndex = 1
      Me.cmdInserisciOccupanti.Text = "&Inserisci"
      '
      'cmdEliminaOccupanti
      '
      Me.cmdEliminaOccupanti.Id = "f4c880ee-0846-4e54-a486-3bc390ef19a6"
      Me.cmdEliminaOccupanti.Location = New System.Drawing.Point(443, 332)
      Me.cmdEliminaOccupanti.Name = "cmdEliminaOccupanti"
      Me.cmdEliminaOccupanti.Size = New System.Drawing.Size(104, 32)
      Me.cmdEliminaOccupanti.TabIndex = 2
      Me.cmdEliminaOccupanti.Text = "&Elimina"
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
      'frmSchedinaPS
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(560, 441)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmSchedinaPS"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Schedina P.S."
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.TabPage4.ResumeLayout(False)
      Me.TabPage4.PerformLayout()
      Me.TabPage5.ResumeLayout(False)
      Me.TabPage5.PerformLayout()
      Me.tpComponenti.ResumeLayout(False)
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public CSchedina As New SchedinaPS
   Public CSchedinaComponenti As New PrenCamereOccupanti
   Public CPrenStorico As New StoricoPresenzeCamere

   Const NOME_TABELLA As String = "SchedinePS"
   Const TAB_CLIENTI As String = "Clienti"
   Const TAB_CAMERE As String = "Camere"
   Const TAB_COMUNI As String = "Comuni"
   Const TAB_NAZIONI As String = "Nazioni"
   Const TAB_DOC_IDENTITA As String = "DocIdentit‡"
   Const TAB_COMPONENTI As String = "ComponentiSchedinePS"
   Const TAB_PREN_STORICO As String = "StoricoPresenzeCamere"

   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress
   Private DatiConfig As AppConfig

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

      ' Salva eventuali nuovi valori nelle rispettive tabelle dati.
      'AggiornaTabella(cmbNazioneNascita, TAB_NAZIONI)
      'AggiornaTabella(cmbCittadinanza, TAB_NAZIONI)
      'AggiornaTabella(cmbNazioneRilascioDoc, TAB_NAZIONI)
      'AggiornaTabella(cmbTipoDoc, TAB_DOC_IDENTITA)

      Try
         With CSchedina
            ' Assegna i dati dei campi della classe alle caselle di testo.
            If txtNumero.Text = String.Empty Then
               txtNumero.Text = "0"
               .Numero = "0"
            Else
               .Numero = txtNumero.Text
            End If

            .IdCliente = cmbIdCliente.Text
            .TipologiaCliente = cmbTipoAlloggiato.Text
            .Cognome = cmbCognome.Text
            .Nome = txtNome.Text
            .Sesso = cmbSesso.Text

            If dtpDataNascita.Checked = True Then
               .DataNascita = dtpDataNascita.Text
            Else
               .DataNascita = String.Empty
            End If

            .LuogoNascita = cmbComuneNascita.Text
            .ProvNascita = txtProvNascita.Text.ToUpper
            .NazioneNascita = cmbNazioneNascita.Text
            .Cittadinanza = cmbCittadinanza.Text
            .TipoDoc = cmbTipoDoc.Text
            .NumeroDoc = txtNumeroDoc.Text
            .RilasciatoDoc = txtRilasciatoDaDoc.Text
            .ComuneRilascioDoc = cmbComuneRilascioDoc.Text

            If dtpDataRilascioDoc.Checked = True Then
               .DataRilascioDoc = dtpDataRilascioDoc.Text
            Else
               .DataRilascioDoc = String.Empty
            End If

            .DataScadenzaDoc = String.Empty ' DA_FARE_B: Sviluppare! Campo mancante nella tabelle Clienti.
            .NazioneRilascioDoc = cmbNazioneRilascioDoc.Text
            .DataArrivo = FormattaData(mcDataArrivo.SelectionRange.Start.Date, True)
            .DataPartenza = FormattaData(mcDataPartenza.SelectionRange.Start.Date, True)
            .Permanenza = txtNumeroNotti.Text
            .NumCamera = cmbNumeroCamera.Text
            .IdPren = 0
            .NumPren = txtNumeroPren.Text
            .Stato = cmbStato.Text

            If dtpDataStampa.Checked = True Then
               .DataStampa = dtpDataStampa.Text
            Else
               .DataStampa = String.Empty
            End If

            '  Se la propriet‡ 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> String.Empty Then
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

   Private Function SalvaOccupanti(ByVal id As String) As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         Dim idSchedina As Integer

         If id <> String.Empty Then
            idSchedina = id
         Else
            idSchedina = LeggiUltimoRecord(NOME_TABELLA)
         End If

         With CSchedinaComponenti
            .EliminaDati(TAB_COMPONENTI, idSchedina)

            Dim i As Integer
            For i = 0 To lvwOccupanti.Items.Count - 1
               .RifPren = idSchedina
               .Cognome = lvwOccupanti.Items(i).SubItems(1).Text
               .Nome = lvwOccupanti.Items(i).SubItems(2).Text
               .Sesso = lvwOccupanti.Items(i).SubItems(3).Text
               .DataNascita = lvwOccupanti.Items(i).SubItems(4).Text
               .LuogoNascita = lvwOccupanti.Items(i).SubItems(5).Text
               .ProvNascita = lvwOccupanti.Items(i).SubItems(6).Text
               .StatoNascita = lvwOccupanti.Items(i).SubItems(7).Text
               .Permanenza = lvwOccupanti.Items(i).SubItems(8).Text
               .TipoAlloggiato = lvwOccupanti.Items(i).SubItems(9).Text
               .CodiceCliente = lvwOccupanti.Items(i).SubItems(10).Text
               .Cittadinanza = lvwOccupanti.Items(i).SubItems(11).Text
               .DataArrivo = lvwOccupanti.Items(i).SubItems(12).Text

               .InserisciDati(TAB_COMPONENTI)
            Next
         End With

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Function SalvaStoricoPresenze(ByVal id As String, ByVal valMese As Integer, ByVal valAnno As Integer, ByVal valNumNotti As Integer,
                                         ByVal dataArrivo As String, ByVal dataPartenza As String, ByVal nazionalit‡ As String, ByVal provincia As String) As Boolean
      Try
         With CPrenStorico
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .RifPren = id
            .Numero = Convert.ToInt32(txtNumero.Text)
            .Mese = valMese
            .Anno = valAnno
            .Adulti = lvwOccupanti.Items.Count + 1
            .Neonati = 0
            .Bambini = 0
            .Ragazzi = 0
            .NumeroNotti = valNumNotti
            .DataArrivo = dataArrivo
            .DataPartenza = dataPartenza
            .Nazionalit‡ = nazionalit‡
            .Provincia = provincia

            .InserisciDati(TAB_PREN_STORICO)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub SalvaStoricoPresenzeMeseAnno()
      Try
         Dim valNumNotti As Integer = Convert.ToInt32(txtNumeroNotti.Text)
         Dim valDataArrivo As Date = FormattaData(mcDataArrivo.SelectionRange.Start.Date, True)
         Dim valDataArrivoStorico As Date = FormattaData(mcDataArrivo.SelectionRange.Start.Date, True)
         Dim valDataPartenzaStorico As Date = FormattaData(mcDataPartenza.SelectionRange.Start.Date, True)
         Dim valMese As Integer = valDataArrivo.Month
         Dim valAnno As Integer = valDataArrivo.Year
         Dim NumNottiTemp As Integer
         Dim salvato As Boolean
         Dim provincia As String
         Dim nazionalit‡ As String = LeggiNazionalit‡Cliente(TAB_CLIENTI, cmbIdCliente.Text)

         If nazionalit‡.ToUpper = "ITALIA" Then
            provincia = LeggiProvinciaCliente(TAB_CLIENTI, cmbIdCliente.Text)
         Else
            provincia = VALORE_NESSUNA
         End If

         ' In caso di nuova schedina dove l'Id non Ë ancora disponibile.
         Dim idSchedina As Integer
         If Me.Tag <> String.Empty Then
            idSchedina = Me.Tag
         Else
            idSchedina = LeggiUltimoRecord(NOME_TABELLA)
         End If

         ' Elimina eventuali dati esistenti.
         CPrenStorico.EliminaDati(TAB_PREN_STORICO, idSchedina)

         Dim i As Integer
         For i = 1 To valNumNotti
            If valDataArrivo.Month <> valMese Then
               ' Salva lo storico delle presenze.
               SalvaStoricoPresenze(idSchedina, valMese, valAnno, NumNottiTemp, valDataArrivoStorico, valDataPartenzaStorico, nazionalit‡, provincia)

               ' Salvo in nuovo mese e l'eventuale nuovo anno.
               valMese = valDataArrivo.Month
               valAnno = valDataArrivo.Year

               NumNottiTemp = 0
            End If

            ' Incrementa di un giorno.
            valDataArrivo = valDataArrivo.AddDays(1)

            ' Conta le notti.
            NumNottiTemp += 1
         Next

         ' Salva lo storico delle presenze.
         SalvaStoricoPresenze(idSchedina, valMese, valAnno, NumNottiTemp, valDataArrivoStorico, valDataPartenzaStorico, nazionalit‡, provincia)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub LeggiComponenti()
      Try
         With CSchedinaComponenti
            .LeggiDati(lvwOccupanti, TAB_COMPONENTI, Me.Tag)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiProvinciaCliente(ByVal tabella As String, ByVal id As Integer) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()
         Dim provincia As String

         Do While dr.Read
            provincia = dr.Item("Provincia").ToString
         Loop

         If provincia = String.Empty Then
            provincia = VALORE_NESSUNA
         End If

         Return provincia

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_NESSUNA

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiNazionalit‡Cliente(ByVal tabella As String, ByVal id As Integer) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()
         Dim nazionalit‡ As String

         Do While dr.Read
            nazionalit‡ = dr.Item("Nazionalit‡").ToString
         Loop

         If nazionalit‡ = String.Empty Then
            nazionalit‡ = VALORE_NESSUNA
         End If

         Return nazionalit‡

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_NESSUNA

      Finally
         cn.Close()

      End Try
   End Function

   Public Function ApriClienti(ByVal val As String) As Boolean
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se Ë un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_CLIENTI, cn, cmd)) = True Then
                  Exit Function
               End If
            End If
         End If

         Dim frm As New frmClienti
         frm.Tag = val

         If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub CaricaDatiCliente()
      Try
         ' Legge il nome relativo alla lista Cognome.
         cmbIdCliente.SelectedIndex = cmbCognome.SelectedIndex

         Dim AClienti As New Anagrafiche.Cliente(ConnString)

         With AClienti
            .LeggiDati(TAB_CLIENTI, cmbIdCliente.Text)

            ' DATI ANAGRAFICI.
            txtNome.Text = .Nome
            cmbSesso.Text = .Sesso
            cmbTipoAlloggiato.Text = .TipoAlloggiato

            If IsDate(.DataNascita) Then
               dtpDataNascita.Value = Convert.ToDateTime(.DataNascita)
            Else
               dtpDataNascita.Value = Today
               dtpDataNascita.Checked = False
            End If

            cmbComuneNascita.Text = .LuogoNascita
            txtProvNascita.Text = .ProvNascita
            cmbNazioneNascita.Text = .NazioneNascita
            cmbCittadinanza.Text = .Nazionalit‡

            ' DOCUMENTO DI RICONOSCIMENTO.
            cmbTipoDoc.Text = .TipoDoc
            txtNumeroDoc.Text = .NumeroDocIdentit‡
            cmbComuneRilascioDoc.Text = .Citt‡RilascioDoc
            cmbNazioneRilascioDoc.Text = .NazioneRilascioDoc
            txtRilasciatoDaDoc.Text = .RilasciatoDa

            If .DataRilascioDoc <> String.Empty Then
               dtpDataRilascioDoc.Value = Convert.ToDateTime(.DataRilascioDoc)
            Else
               dtpDataRilascioDoc.Value = Today
               dtpDataRilascioDoc.Checked = False
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Verifica la presenza di un nome Intestatario.
            If cmbCognome.Text = String.Empty Then
               MessageBox.Show("Inserire un nominativo per l'intestatario della Schedina P.S.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               cmbCognome.Focus()
               Exit Sub
            End If

            ' Salva i dati nel database.
            If SalvaDati() = True Then
               ' Salva il Numero del prossimo documento da stampare.
               g_frmMain.SalvaNumeroSchedinaConfig(NOME_TABELLA, Convert.ToInt32(txtNumero.Text))

               ' Salva eventuali clienti occupanti.
               SalvaOccupanti(Me.Tag)

               If txtNumero.Text <> "0" Then
                  ' Salva lo storico delle presenze.
                  SalvaStoricoPresenzeMeseAnno()
               End If

               ' Aggiorna la griglia dati.
               g_frmSchedinePS.AggiornaDati()

               ' Chiude la finestra.
               Me.Close()
            End If

         Case "Annulla"

            ' Chiude la finestra.
            Me.Close()

      End Select
   End Sub

   Private Sub frmSchedinaPS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica le liste.
         CaricaListaClienti(cmbCognome, cmbNome, cmbIdCliente, TAB_CLIENTI)
         CaricaListaCamere(cmbNumeroCamera, TAB_CAMERE)
         CaricaLista(cmbNazioneNascita, TAB_NAZIONI)
         CaricaLista(cmbCittadinanza, TAB_NAZIONI)
         CaricaLista(cmbNazioneRilascioDoc, TAB_NAZIONI)
         CaricaLista(cmbTipoDoc, TAB_DOC_IDENTITA)
         CaricaLista(cmbComuneRilascioDoc, TAB_COMUNI)
         CaricaLista(cmbComuneNascita, TAB_COMUNI)

         If Me.Tag <> String.Empty Then
            With CSchedina
               ' Comando Modifica.

               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCodice.Text = .Codice
               txtNumero.Text = .Numero
               cmbCognome.Text = .Cognome
               txtNome.Text = .Nome
               cmbSesso.Text = .Sesso
               cmbTipoAlloggiato.Text = .TipologiaCliente

               If .DataNascita <> String.Empty Then
                  dtpDataNascita.Checked = True
                  dtpDataNascita.Value = Convert.ToDateTime(.DataNascita)
               End If

               cmbComuneNascita.Text = .LuogoNascita
               txtProvNascita.Text = .ProvNascita
               cmbNazioneNascita.Text = .NazioneNascita
               cmbCittadinanza.Text = .Cittadinanza
               cmbTipoDoc.Text = .TipoDoc
               txtNumeroDoc.Text = .NumeroDoc
               txtRilasciatoDaDoc.Text = .RilasciatoDoc
               cmbComuneRilascioDoc.Text = .ComuneRilascioDoc

               If .DataRilascioDoc <> String.Empty Then
                  dtpDataRilascioDoc.Checked = True
                  dtpDataRilascioDoc.Value = Convert.ToDateTime(.DataRilascioDoc)
               End If

               cmbNazioneRilascioDoc.Text = .NazioneRilascioDoc
               mcDataArrivo.SetDate(Convert.ToDateTime(.DataArrivo))
               mcDataPartenza.SetDate(Convert.ToDateTime(.DataPartenza))
               txtNumeroNotti.Text = .Permanenza.ToString
               cmbNumeroCamera.Text = .NumCamera
               txtNumeroPren.Text = .NumPren
               cmbStato.Text = .Stato

               If .DataStampa <> String.Empty Then
                  dtpDataStampa.Checked = True
                  dtpDataStampa.Value = Convert.ToDateTime(.DataStampa)
               End If

               ' Aggiorna la nuova data di arrivo.
               lblArrivo.Text = "Arrivo: " & Convert.ToDateTime(.DataArrivo).ToLongDateString

               ' Aggiorna la nuova data di partenza.
               lblPartenza.Text = "Partenza: " & Convert.ToDateTime(.DataPartenza).ToLongDateString

               ' Carica eventuali clienti occupanti.
               LeggiComponenti()

            End With
         Else
            ' Comando Nuovo.

            ' Genera il numero progressivo.
            txtNumero.Text = g_frmMain.LeggiNumeroSchedinaConfig(NOME_TABELLA)
            txtNumeroPren.Text = "0"

            ' Seleziona il valore Inserita.
            cmbStato.SelectedIndex = 0

            ' Seleziona il valore Nessuna.
            cmbNumeroCamera.SelectedIndex = 0

            ' Seleziona il valore M.
            cmbSesso.SelectedIndex = 0

            ' Seleziona il valore Ospite singolo.
            cmbTipoAlloggiato.SelectedIndex = 0

            ' Data e ora di arrivo
            mcDataArrivo.SetDate(Today)
            mcDataPartenza.MinDate = Today.AddDays(1)
            mcDataPartenza.SetDate(Today.AddDays(1))

            ' Aggiorna la nuova data di arrivo.
            lblArrivo.Text = "Arrivo: " & Today.ToLongDateString

            ' Aggiorna la nuova data di partenza.
            lblPartenza.Text = "Partenza: " & Today.AddDays(1).ToLongDateString

            ' Aggiorna il numero delle notti.
            txtNumeroNotti.Text = CalcolaNumGiorni(Today, mcDataPartenza.SelectionRange.Start.Date).ToString

         End If

         ' Genera l'intestazione con i dati del form.
         If txtNumero.Text <> String.Empty Then
            lblIntestazione.Text = VisIntestazione("Schedina N. " & txtNumero.Text, cmbCognome.Text, txtNome.Text)
         Else
            lblIntestazione.Text = VisIntestazione(txtNumero.Text, cmbCognome.Text, txtNome.Text)
         End If

         ' Imposta lo stato attivo.
         txtNumero.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub frmSchedinaPS_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      If Me.Tag <> "0" Then
         ' DA_FARE_B: HOTEL - da modificare!
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_RISORSE)
      End If
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      ' Imposta lo stato attivo.
      Select Case TabControl1.SelectedIndex()
         Case 0
            ' Dati principali.
            txtNumero.Focus()

         Case 1
            ' Dati Anagrafici.
            cmbCognome.Focus()

         Case 2
            ' Documento di riconoscimento.
            cmbTipoDoc.Focus()

         Case 3
            ' Componenti.
            lvwOccupanti.Focus()

      End Select
   End Sub

   Private Sub cmdNuovoIntestatario_Click(sender As Object, e As EventArgs) Handles cmdNuovoIntestatario.Click
      Try
         ' Se Ë stato inserito un nuovo cliente...
         If ApriClienti(String.Empty) = True Then
            CaricaListaClienti(cmbCognome, cmbIdCliente, TAB_CLIENTI)

            ' DATI ANAGRAFICI.
            cmbIdCliente.Text = String.Empty
            cmbCognome.Text = String.Empty
            txtNome.Text = String.Empty
            cmbSesso.Text = "M"

            dtpDataNascita.Value = Today
            dtpDataNascita.Checked = False

            cmbComuneNascita.Text = String.Empty
            txtProvNascita.Text = String.Empty
            cmbNazioneNascita.Text = String.Empty
            cmbCittadinanza.Text = String.Empty

            ' DOCUMENTO DI RICONOSCIMENTO.
            cmbTipoDoc.Text = String.Empty
            txtNumeroDoc.Text = String.Empty
            cmbComuneRilascioDoc.Text = String.Empty
            cmbNazioneRilascioDoc.Text = String.Empty
            txtRilasciatoDaDoc.Text = String.Empty

            dtpDataRilascioDoc.Value = Today
            dtpDataRilascioDoc.Checked = False

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdApriIntestatario_Click(sender As Object, e As EventArgs) Handles cmdApriIntestatario.Click
      Try
         ' Modifica cliente esistente...
         If ApriClienti(cmbIdCliente.Text) = True Then
            CaricaListaClienti(cmbCognome, cmbIdCliente, TAB_CLIENTI)

            ' DATI ANAGRAFICI.
            cmbIdCliente.Text = String.Empty
            cmbCognome.Text = String.Empty
            txtNome.Text = String.Empty
            cmbSesso.Text = "M"

            dtpDataNascita.Value = Today
            dtpDataNascita.Checked = False

            cmbComuneNascita.Text = String.Empty
            txtProvNascita.Text = String.Empty
            cmbNazioneNascita.Text = String.Empty
            cmbCittadinanza.Text = String.Empty

            ' DOCUMENTO DI RICONOSCIMENTO.
            cmbTipoDoc.Text = String.Empty
            txtNumeroDoc.Text = String.Empty
            cmbComuneRilascioDoc.Text = String.Empty
            cmbNazioneRilascioDoc.Text = String.Empty
            txtRilasciatoDaDoc.Text = String.Empty

            dtpDataRilascioDoc.Value = Today
            dtpDataRilascioDoc.Checked = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub mcDataArrivo_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles mcDataArrivo.DateChanged
      Try
         ' Aggiorna la nuova data di arrivo.
         lblArrivo.Text = "Arrivo: " & e.Start.Date.ToLongDateString

         ' Se la data di arrivo Ë maggiore o uguale alla data di partenza.
         If e.Start.Date.Date >= mcDataPartenza.SelectionRange.Start.Date Then

            ' Imposta nuovamente il calendario.
            mcDataPartenza.MinDate = e.Start.Date.AddDays(1)

            ' Aggiorna la nuova data di partenza.
            lblPartenza.Text = "Partenza: " & mcDataPartenza.SelectionRange.Start.Date.ToLongDateString

            ' Aggiorna il numero delle notti.
            txtNumeroNotti.Text = CalcolaNumGiorni(e.Start.Date, mcDataPartenza.SelectionRange.Start.Date).ToString

            Exit Sub
         End If

         ' Imposta nuovamente il calendario.
         mcDataPartenza.MinDate = e.Start.Date.AddDays(1)

         ' Aggiorna il numero delle notti.
         txtNumeroNotti.Text = CalcolaNumGiorni(e.Start.Date, mcDataPartenza.SelectionRange.Start.Date).ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub mcDataPartenza_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles mcDataPartenza.DateChanged
      Try
         ' Aggiorna la nuova data di partenza.
         lblPartenza.Text = "Partenza: " & e.Start.Date.ToLongDateString

         ' Aggiorna il numero delle notti.
         txtNumeroNotti.Text = CalcolaNumGiorni(mcDataArrivo.SelectionRange.Start.Date, e.Start.Date).ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmbCognome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCognome.SelectedIndexChanged
      Try
         ' Legge il nome relativo alla lista Cognome.
         CaricaDatiCliente()

         ' Genera l'intestazione con i dati del form.
         If txtNumero.Text <> String.Empty Then
            lblIntestazione.Text = VisIntestazione("Schedina N. " & txtNumero.Text, cmbCognome.Text, txtNome.Text)
         Else
            lblIntestazione.Text = VisIntestazione(txtNumero.Text, cmbCognome.Text, txtNome.Text)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdInserisciOccupanti_Click(sender As System.Object, e As System.EventArgs) Handles cmdInserisciOccupanti.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim tipoAlloggiato As String

         Select Case cmbTipoAlloggiato.Text
            Case "Capo Famiglia"
               tipoAlloggiato = "Familiare"

            Case "Capo Gruppo"
               tipoAlloggiato = "Membro Gruppo"

         End Select

         Dim frm As New frmInsClienti("Schedine", tipoAlloggiato)
         frm.Tag = txtNumeroNotti.Text
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmdEliminaOccupanti_Click(sender As System.Object, e As System.EventArgs) Handles cmdEliminaOccupanti.Click
      Try
         If lvwOccupanti.Items.Count <> 0 Then

            lvwOccupanti.Focus()

            ' L'elemento inserito viene rimosso dall'elenco.
            lvwOccupanti.Items(lvwOccupanti.FocusedItem.Index).Remove()

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmbStato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbStato.SelectedIndexChanged
      Try
         If cmbStato.Text = VALORE_STAMPATA Then
            dtpDataStampa.Checked = True
         Else
            dtpDataStampa.Checked = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmbTipoAlloggiato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipoAlloggiato.SelectedIndexChanged
      Try
         ' Rimuove tutti i componenti.
         lvwOccupanti.Items.Clear()

         ' Se si seleziona Ospite Singolo viene disattivata la scheda Altri Componenti.
         If sender.text = "Ospite Singolo" Then
            lvwOccupanti.Enabled = False
            cmdInserisciOccupanti.Enabled = False
            cmdEliminaOccupanti.Enabled = False
         Else
            lvwOccupanti.Enabled = True
            cmdInserisciOccupanti.Enabled = True
            cmdEliminaOccupanti.Enabled = True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmbComuneNascita_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbComuneNascita.SelectedIndexChanged
      Try
         txtProvNascita.Text = LeggiProvinciaComune(sender.text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
End Class
