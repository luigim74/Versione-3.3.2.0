#Region " DATI FILE.VB "
' **********************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       13/03/2021
' Data ultima modifica: 30/06/2021
' Descrizione:          Anagrafica Noleggi.
' Note:
'
' Elenco Attivita:
'
' TODO_A: Caricare i dati della tabella Causali Noleggi.
'
' ***********************************************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Data.OleDb

Public Class frmNoleggi
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
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents TabControl2 As Elegant.Ui.TabControl
   Friend WithEvents tpDati As Elegant.Ui.TabPage
   Friend WithEvents eui_txtSconto As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCostoAssicurazione As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCostoMora As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCostoGiorno As Elegant.Ui.TextBox
   Friend WithEvents eui_dtpDataFine As Elegant.Ui.DateTimePicker
   Friend WithEvents eui_dtpDataInizio As Elegant.Ui.DateTimePicker
   Friend WithEvents eui_cmbCausale As Elegant.Ui.ComboBox
   Friend WithEvents eui_txtCodice As Elegant.Ui.TextBox
   Friend WithEvents eui_cmbCliente As Elegant.Ui.ComboBox
   Friend WithEvents Label7 As Label
   Public WithEvents Label8 As Label
   Public WithEvents lblCostoOreGiorni As Label
   Public WithEvents lblCostoMoraOreGiorni As Label
   Public WithEvents Label18 As Label
   Public WithEvents Label19 As Label
   Public WithEvents Label20 As Label
   Public WithEvents Label23 As Label
   Public WithEvents Label24 As Label
   Friend WithEvents tpArticoli As Elegant.Ui.TabPage
   Friend WithEvents tpAllegati As Elegant.Ui.TabPage
   Friend WithEvents tpNote As Elegant.Ui.TabPage
   Friend WithEvents eui_txtNote As Elegant.Ui.TextBox
   Friend WithEvents eui_cmbPeriodo As Elegant.Ui.ComboBox
   Friend WithEvents lstvElencoArticoli As ListView
   Friend WithEvents clnCodice As ColumnHeader
   Friend WithEvents clnDescrizione As ColumnHeader
   Friend WithEvents clnUM As ColumnHeader
   Friend WithEvents clnQuantit‡ As ColumnHeader
   Friend WithEvents clnCostoUnitario As ColumnHeader
   Friend WithEvents clnId As ColumnHeader
   Friend WithEvents lvwAllegati As ListView
   Friend WithEvents ColumnHeader1 As ColumnHeader
   Friend WithEvents ColumnHeader2 As ColumnHeader
   Friend WithEvents ColumnHeader3 As ColumnHeader
   Friend WithEvents ColumnHeader4 As ColumnHeader
   Friend WithEvents ColumnHeader5 As ColumnHeader
   Friend WithEvents ColumnHeader6 As ColumnHeader
   Friend WithEvents eui_txtTotaleImporto As Elegant.Ui.TextBox
   Friend WithEvents Label1 As Label
   Friend WithEvents eui_cmdElimina As Elegant.Ui.Button
   Friend WithEvents eui_cmdInserisci As Elegant.Ui.Button
   Friend WithEvents eui_txtCodiceBarre As Elegant.Ui.TextBox
   Friend WithEvents Label2 As Label
   Friend WithEvents eui_cmdColore As Button
   Friend WithEvents eui_cmbStato As Elegant.Ui.ComboBox
   Public WithEvents Label4 As Label
   Public WithEvents Label3 As Label
   Friend WithEvents eui_txtTotaleOreGiorni As Elegant.Ui.TextBox
   Friend WithEvents lblTotaleOreGiorni As Label
   Friend WithEvents eui_dtpOraFine As Elegant.Ui.DateTimePicker
   Friend WithEvents eui_dtpOraInizio As Elegant.Ui.DateTimePicker
   Public WithEvents Label6 As Label
   Public WithEvents Label9 As Label
   Friend WithEvents eui_cmbTipoPeriodo As Elegant.Ui.ComboBox
   Friend WithEvents eui_cmbIdCliente As Elegant.Ui.ComboBox
   Friend WithEvents eui_cmdNuovoCliente As Elegant.Ui.Button
   Friend WithEvents eui_cmdModificaCliente As Elegant.Ui.Button
   Friend WithEvents clnCostoTotale As ColumnHeader
   Friend WithEvents clnIva As ColumnHeader
   Friend WithEvents clnCategoria As ColumnHeader
   Friend WithEvents clnRifNoleggio As ColumnHeader
   Friend WithEvents eui_cmdInserisciAllegato As Elegant.Ui.Button
   Friend WithEvents eui_cmdRimuoviAllegato As Elegant.Ui.Button
   Friend WithEvents eui_cmdModificaAllegato As Elegant.Ui.Button
   Friend WithEvents eui_cmdApriDocAllegato As Elegant.Ui.Button
   Friend WithEvents eui_cmdNuovaCausale As Elegant.Ui.Button
   Friend WithEvents eui_cmdModificaCausale As Elegant.Ui.Button
   Friend WithEvents eui_cmbIdCausale As Elegant.Ui.ComboBox
   Public WithEvents Label25 As Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNoleggi))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.TabControl2 = New Elegant.Ui.TabControl()
      Me.tpDati = New Elegant.Ui.TabPage()
      Me.eui_cmbIdCausale = New Elegant.Ui.ComboBox()
      Me.eui_cmdNuovaCausale = New Elegant.Ui.Button()
      Me.eui_cmdModificaCausale = New Elegant.Ui.Button()
      Me.eui_cmdNuovoCliente = New Elegant.Ui.Button()
      Me.eui_cmdModificaCliente = New Elegant.Ui.Button()
      Me.eui_cmbIdCliente = New Elegant.Ui.ComboBox()
      Me.eui_cmbTipoPeriodo = New Elegant.Ui.ComboBox()
      Me.eui_dtpOraFine = New Elegant.Ui.DateTimePicker()
      Me.eui_dtpOraInizio = New Elegant.Ui.DateTimePicker()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.eui_txtTotaleOreGiorni = New Elegant.Ui.TextBox()
      Me.lblTotaleOreGiorni = New System.Windows.Forms.Label()
      Me.eui_cmdColore = New System.Windows.Forms.Button()
      Me.eui_cmbStato = New Elegant.Ui.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.eui_txtCodiceBarre = New Elegant.Ui.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.eui_txtTotaleImporto = New Elegant.Ui.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.eui_cmbPeriodo = New Elegant.Ui.ComboBox()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.eui_txtSconto = New Elegant.Ui.TextBox()
      Me.eui_txtCostoAssicurazione = New Elegant.Ui.TextBox()
      Me.eui_txtCostoMora = New Elegant.Ui.TextBox()
      Me.eui_txtCostoGiorno = New Elegant.Ui.TextBox()
      Me.eui_dtpDataFine = New Elegant.Ui.DateTimePicker()
      Me.eui_dtpDataInizio = New Elegant.Ui.DateTimePicker()
      Me.eui_cmbCausale = New Elegant.Ui.ComboBox()
      Me.eui_txtCodice = New Elegant.Ui.TextBox()
      Me.eui_cmbCliente = New Elegant.Ui.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.lblCostoOreGiorni = New System.Windows.Forms.Label()
      Me.lblCostoMoraOreGiorni = New System.Windows.Forms.Label()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.tpArticoli = New Elegant.Ui.TabPage()
      Me.eui_cmdElimina = New Elegant.Ui.Button()
      Me.eui_cmdInserisci = New Elegant.Ui.Button()
      Me.lstvElencoArticoli = New System.Windows.Forms.ListView()
      Me.clnCodice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnDescrizione = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnUM = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnQuantit‡ = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCostoUnitario = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCostoTotale = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnIva = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnId = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnRifNoleggio = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.tpAllegati = New Elegant.Ui.TabPage()
      Me.eui_cmdApriDocAllegato = New Elegant.Ui.Button()
      Me.eui_cmdInserisciAllegato = New Elegant.Ui.Button()
      Me.eui_cmdRimuoviAllegato = New Elegant.Ui.Button()
      Me.eui_cmdModificaAllegato = New Elegant.Ui.Button()
      Me.lvwAllegati = New System.Windows.Forms.ListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.tpNote = New Elegant.Ui.TabPage()
      Me.eui_txtNote = New Elegant.Ui.TextBox()
      Me.Panel1.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tpDati.SuspendLayout()
      Me.tpArticoli.SuspendLayout()
      Me.tpAllegati.SuspendLayout()
      Me.tpNote.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(591, 26)
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
      Me.ImageList1.Images.SetKeyName(11, "id_insert_shapes_large.png")
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(591, 28)
      Me.Panel1.TabIndex = 0
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.SystemColors.Window
      Me.lblIntestazione.Location = New System.Drawing.Point(3, 5)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(16, 16)
      Me.lblIntestazione.TabIndex = 0
      Me.lblIntestazione.Text = "#"
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
      'TabControl2
      '
      Me.TabControl2.Location = New System.Drawing.Point(2, 57)
      Me.TabControl2.Name = "TabControl2"
      Me.TabControl2.SelectedTabPage = Me.tpDati
      Me.TabControl2.Size = New System.Drawing.Size(577, 353)
      Me.TabControl2.TabIndex = 1
      Me.TabControl2.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.tpDati, Me.tpArticoli, Me.tpAllegati, Me.tpNote})
      Me.TabControl2.Text = "TabControl2"
      '
      'tpDati
      '
      Me.tpDati.ActiveControl = Nothing
      Me.tpDati.Controls.Add(Me.eui_cmbIdCausale)
      Me.tpDati.Controls.Add(Me.eui_cmdNuovaCausale)
      Me.tpDati.Controls.Add(Me.eui_cmdModificaCausale)
      Me.tpDati.Controls.Add(Me.eui_cmdNuovoCliente)
      Me.tpDati.Controls.Add(Me.eui_cmdModificaCliente)
      Me.tpDati.Controls.Add(Me.eui_cmbIdCliente)
      Me.tpDati.Controls.Add(Me.eui_cmbTipoPeriodo)
      Me.tpDati.Controls.Add(Me.eui_dtpOraFine)
      Me.tpDati.Controls.Add(Me.eui_dtpOraInizio)
      Me.tpDati.Controls.Add(Me.Label6)
      Me.tpDati.Controls.Add(Me.Label9)
      Me.tpDati.Controls.Add(Me.eui_txtTotaleOreGiorni)
      Me.tpDati.Controls.Add(Me.lblTotaleOreGiorni)
      Me.tpDati.Controls.Add(Me.eui_cmdColore)
      Me.tpDati.Controls.Add(Me.eui_cmbStato)
      Me.tpDati.Controls.Add(Me.Label4)
      Me.tpDati.Controls.Add(Me.Label3)
      Me.tpDati.Controls.Add(Me.eui_txtCodiceBarre)
      Me.tpDati.Controls.Add(Me.Label2)
      Me.tpDati.Controls.Add(Me.eui_txtTotaleImporto)
      Me.tpDati.Controls.Add(Me.Label1)
      Me.tpDati.Controls.Add(Me.eui_cmbPeriodo)
      Me.tpDati.Controls.Add(Me.Label25)
      Me.tpDati.Controls.Add(Me.eui_txtSconto)
      Me.tpDati.Controls.Add(Me.eui_txtCostoAssicurazione)
      Me.tpDati.Controls.Add(Me.eui_txtCostoMora)
      Me.tpDati.Controls.Add(Me.eui_txtCostoGiorno)
      Me.tpDati.Controls.Add(Me.eui_dtpDataFine)
      Me.tpDati.Controls.Add(Me.eui_dtpDataInizio)
      Me.tpDati.Controls.Add(Me.eui_cmbCausale)
      Me.tpDati.Controls.Add(Me.eui_txtCodice)
      Me.tpDati.Controls.Add(Me.eui_cmbCliente)
      Me.tpDati.Controls.Add(Me.Label7)
      Me.tpDati.Controls.Add(Me.Label8)
      Me.tpDati.Controls.Add(Me.lblCostoOreGiorni)
      Me.tpDati.Controls.Add(Me.lblCostoMoraOreGiorni)
      Me.tpDati.Controls.Add(Me.Label18)
      Me.tpDati.Controls.Add(Me.Label19)
      Me.tpDati.Controls.Add(Me.Label20)
      Me.tpDati.Controls.Add(Me.Label23)
      Me.tpDati.Controls.Add(Me.Label24)
      Me.tpDati.KeyTip = Nothing
      Me.tpDati.Name = "tpDati"
      Me.tpDati.Size = New System.Drawing.Size(575, 332)
      Me.tpDati.TabIndex = 0
      Me.tpDati.Text = "Dati principali"
      '
      'eui_cmbIdCausale
      '
      Me.eui_cmbIdCausale.Editable = False
      Me.eui_cmbIdCausale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmbIdCausale.FormattingEnabled = False
      Me.eui_cmbIdCausale.Id = "0f6f9782-8068-40e3-83f2-86881638be1a"
      Me.eui_cmbIdCausale.Location = New System.Drawing.Point(128, 68)
      Me.eui_cmbIdCausale.Name = "eui_cmbIdCausale"
      Me.eui_cmbIdCausale.Size = New System.Drawing.Size(26, 21)
      Me.eui_cmbIdCausale.TabIndex = 55732
      Me.eui_cmbIdCausale.TextEditorWidth = 7
      Me.eui_cmbIdCausale.Visible = False
      '
      'eui_cmdNuovaCausale
      '
      Me.eui_cmdNuovaCausale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdNuovaCausale.Id = "feea2993-c912-42db-9d14-a833f1aa4e5e"
      Me.eui_cmdNuovaCausale.Location = New System.Drawing.Point(491, 68)
      Me.eui_cmdNuovaCausale.Name = "eui_cmdNuovaCausale"
      Me.eui_cmdNuovaCausale.ScreenTip.Text = "Nuova causale noleggio"
      Me.eui_cmdNuovaCausale.Size = New System.Drawing.Size(25, 21)
      Me.eui_cmdNuovaCausale.TabIndex = 55731
      Me.eui_cmdNuovaCausale.Text = "+"
      '
      'eui_cmdModificaCausale
      '
      Me.eui_cmdModificaCausale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdModificaCausale.Id = "5e2724a2-36f6-414c-86b0-7ed3812c363a"
      Me.eui_cmdModificaCausale.Location = New System.Drawing.Point(465, 68)
      Me.eui_cmdModificaCausale.Name = "eui_cmdModificaCausale"
      Me.eui_cmdModificaCausale.ScreenTip.Text = "Modifica causale noleggio"
      Me.eui_cmdModificaCausale.Size = New System.Drawing.Size(25, 21)
      Me.eui_cmdModificaCausale.TabIndex = 55730
      Me.eui_cmdModificaCausale.Text = "..."
      '
      'eui_cmdNuovoCliente
      '
      Me.eui_cmdNuovoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdNuovoCliente.Id = "9ba731e5-a140-44cd-bb32-b105682f9d19"
      Me.eui_cmdNuovoCliente.Location = New System.Drawing.Point(491, 43)
      Me.eui_cmdNuovoCliente.Name = "eui_cmdNuovoCliente"
      Me.eui_cmdNuovoCliente.ScreenTip.Text = "Nuovo cliente"
      Me.eui_cmdNuovoCliente.Size = New System.Drawing.Size(25, 21)
      Me.eui_cmdNuovoCliente.TabIndex = 4
      Me.eui_cmdNuovoCliente.Text = "+"
      '
      'eui_cmdModificaCliente
      '
      Me.eui_cmdModificaCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdModificaCliente.Id = "4fd5f5b4-027f-43a7-ad6f-f54f66391234"
      Me.eui_cmdModificaCliente.Location = New System.Drawing.Point(465, 43)
      Me.eui_cmdModificaCliente.Name = "eui_cmdModificaCliente"
      Me.eui_cmdModificaCliente.ScreenTip.Text = "Modifica cliente"
      Me.eui_cmdModificaCliente.Size = New System.Drawing.Size(25, 21)
      Me.eui_cmdModificaCliente.TabIndex = 3
      Me.eui_cmdModificaCliente.Text = "..."
      '
      'eui_cmbIdCliente
      '
      Me.eui_cmbIdCliente.Editable = False
      Me.eui_cmbIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmbIdCliente.FormattingEnabled = False
      Me.eui_cmbIdCliente.Id = "c64a8f1a-28e8-4c60-91d8-7bfb1cc3fc2c"
      Me.eui_cmbIdCliente.Location = New System.Drawing.Point(128, 43)
      Me.eui_cmbIdCliente.Name = "eui_cmbIdCliente"
      Me.eui_cmbIdCliente.Size = New System.Drawing.Size(26, 21)
      Me.eui_cmbIdCliente.TabIndex = 55729
      Me.eui_cmbIdCliente.TextEditorWidth = 7
      Me.eui_cmbIdCliente.Visible = False
      '
      'eui_cmbTipoPeriodo
      '
      Me.eui_cmbTipoPeriodo.Editable = False
      Me.eui_cmbTipoPeriodo.FormattingEnabled = False
      Me.eui_cmbTipoPeriodo.Id = "1da73c3c-40fd-47ab-b726-5ed15bb70a1b"
      Me.eui_cmbTipoPeriodo.Items.AddRange(New Object() {"Ore", "Giorni"})
      Me.eui_cmbTipoPeriodo.Location = New System.Drawing.Point(156, 98)
      Me.eui_cmbTipoPeriodo.Name = "eui_cmbTipoPeriodo"
      Me.eui_cmbTipoPeriodo.Size = New System.Drawing.Size(60, 21)
      Me.eui_cmbTipoPeriodo.TabIndex = 6
      Me.eui_cmbTipoPeriodo.TextEditorWidth = 41
      '
      'eui_dtpOraFine
      '
      Me.eui_dtpOraFine.CalendarDropDownVisible = False
      Me.eui_dtpOraFine.Enabled = False
      Me.eui_dtpOraFine.Format = Elegant.Ui.DateTimePickerFormat.ShortTime
      Me.eui_dtpOraFine.Id = "09bb06cb-bbd6-4fc2-83ab-52b829781fd4"
      Me.eui_dtpOraFine.IncrementOrDecrementWholeDate = True
      Me.eui_dtpOraFine.Location = New System.Drawing.Point(427, 149)
      Me.eui_dtpOraFine.Name = "eui_dtpOraFine"
      Me.eui_dtpOraFine.Size = New System.Drawing.Size(89, 21)
      Me.eui_dtpOraFine.TabIndex = 11
      Me.eui_dtpOraFine.TextEditorWidth = 70
      Me.eui_dtpOraFine.UpDownButtonsVisible = True
      '
      'eui_dtpOraInizio
      '
      Me.eui_dtpOraInizio.CalendarDropDownVisible = False
      Me.eui_dtpOraInizio.Enabled = False
      Me.eui_dtpOraInizio.Format = Elegant.Ui.DateTimePickerFormat.ShortTime
      Me.eui_dtpOraInizio.Id = "7c88e5b1-85d5-4c1a-8fec-b8b0a217b352"
      Me.eui_dtpOraInizio.IncrementOrDecrementWholeDate = True
      Me.eui_dtpOraInizio.Location = New System.Drawing.Point(427, 124)
      Me.eui_dtpOraInizio.Name = "eui_dtpOraInizio"
      Me.eui_dtpOraInizio.Size = New System.Drawing.Size(89, 21)
      Me.eui_dtpOraInizio.TabIndex = 10
      Me.eui_dtpOraInizio.TextEditorWidth = 70
      Me.eui_dtpOraInizio.UpDownButtonsVisible = True
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(355, 153)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(47, 13)
      Me.Label6.TabIndex = 55725
      Me.Label6.Text = "Ora fine:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(355, 128)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(53, 13)
      Me.Label9.TabIndex = 55724
      Me.Label9.Text = "Ora inizio:"
      '
      'eui_txtTotaleOreGiorni
      '
      Me.eui_txtTotaleOreGiorni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTotaleOreGiorni.Id = "ca4e1ab9-ec7c-4919-b3a1-9044b6a26c49"
      Me.eui_txtTotaleOreGiorni.Location = New System.Drawing.Point(427, 98)
      Me.eui_txtTotaleOreGiorni.Name = "eui_txtTotaleOreGiorni"
      Me.eui_txtTotaleOreGiorni.ReadOnly = True
      Me.eui_txtTotaleOreGiorni.Size = New System.Drawing.Size(89, 21)
      Me.eui_txtTotaleOreGiorni.TabIndex = 55723
      Me.eui_txtTotaleOreGiorni.Text = "30"
      Me.eui_txtTotaleOreGiorni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaleOreGiorni.TextEditorWidth = 83
      '
      'lblTotaleOreGiorni
      '
      Me.lblTotaleOreGiorni.AutoSize = True
      Me.lblTotaleOreGiorni.BackColor = System.Drawing.Color.Transparent
      Me.lblTotaleOreGiorni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotaleOreGiorni.ForeColor = System.Drawing.Color.Black
      Me.lblTotaleOreGiorni.Location = New System.Drawing.Point(355, 102)
      Me.lblTotaleOreGiorni.Name = "lblTotaleOreGiorni"
      Me.lblTotaleOreGiorni.Size = New System.Drawing.Size(68, 13)
      Me.lblTotaleOreGiorni.TabIndex = 55722
      Me.lblTotaleOreGiorni.Text = "Totale giorni:"
      Me.lblTotaleOreGiorni.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'eui_cmdColore
      '
      Me.eui_cmdColore.BackColor = System.Drawing.Color.LightSalmon
      Me.eui_cmdColore.FlatAppearance.BorderColor = System.Drawing.Color.Gray
      Me.eui_cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Flat
      Me.eui_cmdColore.ForeColor = System.Drawing.SystemColors.ControlText
      Me.eui_cmdColore.Location = New System.Drawing.Point(401, 279)
      Me.eui_cmdColore.Name = "eui_cmdColore"
      Me.eui_cmdColore.Size = New System.Drawing.Size(115, 21)
      Me.eui_cmdColore.TabIndex = 18
      Me.eui_cmdColore.UseVisualStyleBackColor = False
      '
      'eui_cmbStato
      '
      Me.eui_cmbStato.Editable = False
      Me.eui_cmbStato.FormattingEnabled = False
      Me.eui_cmbStato.Id = "eb5cdda5-eda0-4dcb-8a13-d77eb500267d"
      Me.eui_cmbStato.Location = New System.Drawing.Point(401, 255)
      Me.eui_cmbStato.Name = "eui_cmbStato"
      Me.eui_cmbStato.Size = New System.Drawing.Size(115, 21)
      Me.eui_cmbStato.TabIndex = 17
      Me.eui_cmbStato.TextEditorWidth = 96
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(355, 259)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(35, 13)
      Me.Label4.TabIndex = 55720
      Me.Label4.Text = "Stato:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(355, 283)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(40, 13)
      Me.Label3.TabIndex = 55719
      Me.Label3.Text = "Colore:"
      '
      'eui_txtCodiceBarre
      '
      Me.eui_txtCodiceBarre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCodiceBarre.Id = "81ed89d4-46fb-45f1-a44a-3d1dc55f8942"
      Me.eui_txtCodiceBarre.Location = New System.Drawing.Point(385, 18)
      Me.eui_txtCodiceBarre.Name = "eui_txtCodiceBarre"
      Me.eui_txtCodiceBarre.Size = New System.Drawing.Size(131, 21)
      Me.eui_txtCodiceBarre.TabIndex = 1
      Me.eui_txtCodiceBarre.TextEditorWidth = 125
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(300, 22)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(79, 13)
      Me.Label2.TabIndex = 55717
      Me.Label2.Text = "Codice a barre:"
      '
      'eui_txtTotaleImporto
      '
      Me.eui_txtTotaleImporto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTotaleImporto.Id = "c2318864-8dc9-4fa5-8871-e1675b39c457"
      Me.eui_txtTotaleImporto.Location = New System.Drawing.Point(156, 280)
      Me.eui_txtTotaleImporto.Name = "eui_txtTotaleImporto"
      Me.eui_txtTotaleImporto.ReadOnly = True
      Me.eui_txtTotaleImporto.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtTotaleImporto.TabIndex = 16
      Me.eui_txtTotaleImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaleImporto.TextEditorWidth = 168
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(21, 284)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(120, 13)
      Me.Label1.TabIndex = 55715
      Me.Label1.Text = "Totale importo noleggio:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'eui_cmbPeriodo
      '
      Me.eui_cmbPeriodo.Editable = False
      Me.eui_cmbPeriodo.FormattingEnabled = False
      Me.eui_cmbPeriodo.Id = "2f9cd914-1baf-40d1-aa0c-b709734c5e6f"
      Me.eui_cmbPeriodo.Items.AddRange(New Object() {"Selezione manuale", "1 Ora", "2 Ore", "3 Ore", "4 Ore", "1 Giorno", "2 Giorni", "3 Giorni", "4 Giorni", "5 Giorni", "6 Giorni", "7 Giorni", "1 Mese", "2 Mesi", "3 Mesi", "4 Mesi", "5 Mesi", "6 Mesi", "1 Anno", "2 Anni", "3 Anni", "4 Anni", "5 Anni"})
      Me.eui_cmbPeriodo.Location = New System.Drawing.Point(218, 98)
      Me.eui_cmbPeriodo.Name = "eui_cmbPeriodo"
      Me.eui_cmbPeriodo.Size = New System.Drawing.Size(112, 21)
      Me.eui_cmbPeriodo.TabIndex = 7
      Me.eui_cmbPeriodo.TextEditorWidth = 93
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.BackColor = System.Drawing.Color.Transparent
      Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label25.ForeColor = System.Drawing.Color.Black
      Me.Label25.Location = New System.Drawing.Point(21, 102)
      Me.Label25.Name = "Label25"
      Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label25.Size = New System.Drawing.Size(46, 13)
      Me.Label25.TabIndex = 55713
      Me.Label25.Text = "Periodo:"
      '
      'eui_txtSconto
      '
      Me.eui_txtSconto.Id = "5b063bf5-811f-496a-854d-663860336292"
      Me.eui_txtSconto.Location = New System.Drawing.Point(156, 205)
      Me.eui_txtSconto.Name = "eui_txtSconto"
      Me.eui_txtSconto.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtSconto.TabIndex = 13
      Me.eui_txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtSconto.TextEditorWidth = 168
      '
      'eui_txtCostoAssicurazione
      '
      Me.eui_txtCostoAssicurazione.Id = "3b9be2ff-bc66-4911-963b-40f5f2a889bc"
      Me.eui_txtCostoAssicurazione.Location = New System.Drawing.Point(156, 255)
      Me.eui_txtCostoAssicurazione.Name = "eui_txtCostoAssicurazione"
      Me.eui_txtCostoAssicurazione.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtCostoAssicurazione.TabIndex = 15
      Me.eui_txtCostoAssicurazione.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCostoAssicurazione.TextEditorWidth = 168
      '
      'eui_txtCostoMora
      '
      Me.eui_txtCostoMora.Id = "9bc8022a-1a8b-4644-8c93-827bc55b820c"
      Me.eui_txtCostoMora.Location = New System.Drawing.Point(156, 230)
      Me.eui_txtCostoMora.Name = "eui_txtCostoMora"
      Me.eui_txtCostoMora.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtCostoMora.TabIndex = 14
      Me.eui_txtCostoMora.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCostoMora.TextEditorWidth = 168
      '
      'eui_txtCostoGiorno
      '
      Me.eui_txtCostoGiorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCostoGiorno.Id = "69a16ebe-88f3-46cd-ba2d-2b6b1abdefb5"
      Me.eui_txtCostoGiorno.Location = New System.Drawing.Point(156, 180)
      Me.eui_txtCostoGiorno.Name = "eui_txtCostoGiorno"
      Me.eui_txtCostoGiorno.ReadOnly = True
      Me.eui_txtCostoGiorno.Size = New System.Drawing.Size(174, 21)
      Me.eui_txtCostoGiorno.TabIndex = 12
      Me.eui_txtCostoGiorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCostoGiorno.TextEditorWidth = 168
      '
      'eui_dtpDataFine
      '
      Me.eui_dtpDataFine.Id = "8be6323f-c3ff-4c10-9f7a-7b4abec7f5f0"
      Me.eui_dtpDataFine.Location = New System.Drawing.Point(156, 149)
      Me.eui_dtpDataFine.Name = "eui_dtpDataFine"
      Me.eui_dtpDataFine.Size = New System.Drawing.Size(174, 21)
      Me.eui_dtpDataFine.TabIndex = 9
      Me.eui_dtpDataFine.TextEditorWidth = 155
      '
      'eui_dtpDataInizio
      '
      Me.eui_dtpDataInizio.Id = "9b71e287-44f5-43fa-a84e-0311ed08ad52"
      Me.eui_dtpDataInizio.Location = New System.Drawing.Point(156, 124)
      Me.eui_dtpDataInizio.Name = "eui_dtpDataInizio"
      Me.eui_dtpDataInizio.Size = New System.Drawing.Size(174, 21)
      Me.eui_dtpDataInizio.TabIndex = 8
      Me.eui_dtpDataInizio.TextEditorWidth = 155
      '
      'eui_cmbCausale
      '
      Me.eui_cmbCausale.Editable = False
      Me.eui_cmbCausale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmbCausale.FormattingEnabled = False
      Me.eui_cmbCausale.Id = "9a095b6c-0aaf-4879-b604-cd6a91beab70"
      Me.eui_cmbCausale.Location = New System.Drawing.Point(156, 68)
      Me.eui_cmbCausale.Name = "eui_cmbCausale"
      Me.eui_cmbCausale.Size = New System.Drawing.Size(307, 21)
      Me.eui_cmbCausale.TabIndex = 5
      Me.eui_cmbCausale.TextEditorWidth = 288
      '
      'eui_txtCodice
      '
      Me.eui_txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCodice.Id = "b3b14f14-c9d0-43cb-ba84-405bc8faaf49"
      Me.eui_txtCodice.Location = New System.Drawing.Point(156, 18)
      Me.eui_txtCodice.Name = "eui_txtCodice"
      Me.eui_txtCodice.ReadOnly = True
      Me.eui_txtCodice.Size = New System.Drawing.Size(131, 21)
      Me.eui_txtCodice.TabIndex = 0
      Me.eui_txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtCodice.TextEditorWidth = 125
      '
      'eui_cmbCliente
      '
      Me.eui_cmbCliente.Editable = False
      Me.eui_cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmbCliente.FormattingEnabled = False
      Me.eui_cmbCliente.Id = "afadeb17-01f4-4309-938a-da3222121b47"
      Me.eui_cmbCliente.Location = New System.Drawing.Point(156, 43)
      Me.eui_cmbCliente.Name = "eui_cmbCliente"
      Me.eui_cmbCliente.Size = New System.Drawing.Size(307, 21)
      Me.eui_cmbCliente.TabIndex = 2
      Me.eui_cmbCliente.TextEditorWidth = 288
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(21, 22)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(40, 13)
      Me.Label7.TabIndex = 55703
      Me.Label7.Text = "Codice"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(21, 259)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(104, 13)
      Me.Label8.TabIndex = 55702
      Me.Label8.Text = "Costo assicurazione:"
      '
      'lblCostoOreGiorni
      '
      Me.lblCostoOreGiorni.AutoSize = True
      Me.lblCostoOreGiorni.BackColor = System.Drawing.Color.Transparent
      Me.lblCostoOreGiorni.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblCostoOreGiorni.ForeColor = System.Drawing.Color.Black
      Me.lblCostoOreGiorni.Location = New System.Drawing.Point(21, 184)
      Me.lblCostoOreGiorni.Name = "lblCostoOreGiorni"
      Me.lblCostoOreGiorni.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblCostoOreGiorni.Size = New System.Drawing.Size(88, 13)
      Me.lblCostoOreGiorni.TabIndex = 55701
      Me.lblCostoOreGiorni.Text = "Costo giornaliero:"
      '
      'lblCostoMoraOreGiorni
      '
      Me.lblCostoMoraOreGiorni.AutoSize = True
      Me.lblCostoMoraOreGiorni.BackColor = System.Drawing.Color.Transparent
      Me.lblCostoMoraOreGiorni.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblCostoMoraOreGiorni.ForeColor = System.Drawing.Color.Black
      Me.lblCostoMoraOreGiorni.Location = New System.Drawing.Point(21, 234)
      Me.lblCostoMoraOreGiorni.Name = "lblCostoMoraOreGiorni"
      Me.lblCostoMoraOreGiorni.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblCostoMoraOreGiorni.Size = New System.Drawing.Size(114, 13)
      Me.lblCostoMoraOreGiorni.TabIndex = 55700
      Me.lblCostoMoraOreGiorni.Text = "Costo mora giornaliera:"
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.ForeColor = System.Drawing.Color.Black
      Me.Label18.Location = New System.Drawing.Point(21, 209)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(44, 13)
      Me.Label18.TabIndex = 55699
      Me.Label18.Text = "Sconto:"
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(21, 153)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(53, 13)
      Me.Label19.TabIndex = 55698
      Me.Label19.Text = "Data fine:"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(21, 128)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(59, 13)
      Me.Label20.TabIndex = 55697
      Me.Label20.Text = "Data inizio:"
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.BackColor = System.Drawing.Color.Transparent
      Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label23.ForeColor = System.Drawing.Color.Black
      Me.Label23.Location = New System.Drawing.Point(21, 72)
      Me.Label23.Name = "Label23"
      Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label23.Size = New System.Drawing.Size(91, 13)
      Me.Label23.TabIndex = 55696
      Me.Label23.Text = "Causale noleggio:"
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.BackColor = System.Drawing.Color.Transparent
      Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label24.ForeColor = System.Drawing.Color.Black
      Me.Label24.Location = New System.Drawing.Point(21, 47)
      Me.Label24.Name = "Label24"
      Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label24.Size = New System.Drawing.Size(42, 13)
      Me.Label24.TabIndex = 55695
      Me.Label24.Text = "Cliente:"
      '
      'tpArticoli
      '
      Me.tpArticoli.ActiveControl = Nothing
      Me.tpArticoli.Controls.Add(Me.eui_cmdElimina)
      Me.tpArticoli.Controls.Add(Me.eui_cmdInserisci)
      Me.tpArticoli.Controls.Add(Me.lstvElencoArticoli)
      Me.tpArticoli.KeyTip = Nothing
      Me.tpArticoli.Name = "tpArticoli"
      Me.tpArticoli.Size = New System.Drawing.Size(575, 332)
      Me.tpArticoli.TabIndex = 1
      Me.tpArticoli.Text = "Articoli noleggiati"
      '
      'eui_cmdElimina
      '
      Me.eui_cmdElimina.Id = "194ff039-f822-43ad-af26-63ee4a6d8ad1"
      Me.eui_cmdElimina.Location = New System.Drawing.Point(491, 295)
      Me.eui_cmdElimina.Name = "eui_cmdElimina"
      Me.eui_cmdElimina.Size = New System.Drawing.Size(75, 30)
      Me.eui_cmdElimina.TabIndex = 2
      Me.eui_cmdElimina.Text = "&Elimina"
      '
      'eui_cmdInserisci
      '
      Me.eui_cmdInserisci.Id = "53c7e9e3-00ac-4b69-b43c-5f17efd9d3ba"
      Me.eui_cmdInserisci.Location = New System.Drawing.Point(410, 295)
      Me.eui_cmdInserisci.Name = "eui_cmdInserisci"
      Me.eui_cmdInserisci.Size = New System.Drawing.Size(75, 30)
      Me.eui_cmdInserisci.TabIndex = 1
      Me.eui_cmdInserisci.Text = "&Inserisci"
      '
      'lstvElencoArticoli
      '
      Me.lstvElencoArticoli.AllowColumnReorder = True
      Me.lstvElencoArticoli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clnCodice, Me.clnDescrizione, Me.clnUM, Me.clnQuantit‡, Me.clnCostoUnitario, Me.clnCostoTotale, Me.clnIva, Me.clnCategoria, Me.clnId, Me.clnRifNoleggio})
      Me.lstvElencoArticoli.FullRowSelect = True
      Me.lstvElencoArticoli.HideSelection = False
      Me.lstvElencoArticoli.Location = New System.Drawing.Point(0, 0)
      Me.lstvElencoArticoli.MultiSelect = False
      Me.lstvElencoArticoli.Name = "lstvElencoArticoli"
      Me.lstvElencoArticoli.Size = New System.Drawing.Size(574, 287)
      Me.lstvElencoArticoli.StateImageList = Me.ImageList1
      Me.lstvElencoArticoli.TabIndex = 0
      Me.lstvElencoArticoli.UseCompatibleStateImageBehavior = False
      Me.lstvElencoArticoli.View = System.Windows.Forms.View.Details
      '
      'clnCodice
      '
      Me.clnCodice.Text = "Codice"
      Me.clnCodice.Width = 100
      '
      'clnDescrizione
      '
      Me.clnDescrizione.Text = "Descrizione"
      Me.clnDescrizione.Width = 150
      '
      'clnUM
      '
      Me.clnUM.Text = "U.M."
      Me.clnUM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      '
      'clnQuantit‡
      '
      Me.clnQuantit‡.Text = "Quantit‡"
      Me.clnQuantit‡.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'clnCostoUnitario
      '
      Me.clnCostoUnitario.Text = "Costo unitario"
      Me.clnCostoUnitario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnCostoUnitario.Width = 90
      '
      'clnCostoTotale
      '
      Me.clnCostoTotale.DisplayIndex = 6
      Me.clnCostoTotale.Text = "Costo totale"
      Me.clnCostoTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnCostoTotale.Width = 90
      '
      'clnIva
      '
      Me.clnIva.DisplayIndex = 8
      Me.clnIva.Text = "Aliquota Iva"
      Me.clnIva.Width = 0
      '
      'clnCategoria
      '
      Me.clnCategoria.DisplayIndex = 9
      Me.clnCategoria.Text = "Categoria"
      Me.clnCategoria.Width = 0
      '
      'clnId
      '
      Me.clnId.DisplayIndex = 5
      Me.clnId.Text = "Id"
      Me.clnId.Width = 0
      '
      'clnRifNoleggio
      '
      Me.clnRifNoleggio.DisplayIndex = 7
      Me.clnRifNoleggio.Text = "RifNoleggio"
      Me.clnRifNoleggio.Width = 0
      '
      'tpAllegati
      '
      Me.tpAllegati.ActiveControl = Nothing
      Me.tpAllegati.Controls.Add(Me.eui_cmdApriDocAllegato)
      Me.tpAllegati.Controls.Add(Me.eui_cmdInserisciAllegato)
      Me.tpAllegati.Controls.Add(Me.eui_cmdRimuoviAllegato)
      Me.tpAllegati.Controls.Add(Me.eui_cmdModificaAllegato)
      Me.tpAllegati.Controls.Add(Me.lvwAllegati)
      Me.tpAllegati.KeyTip = Nothing
      Me.tpAllegati.Name = "tpAllegati"
      Me.tpAllegati.Size = New System.Drawing.Size(575, 332)
      Me.tpAllegati.TabIndex = 2
      Me.tpAllegati.Text = "Documenti allegati"
      '
      'eui_cmdApriDocAllegato
      '
      Me.eui_cmdApriDocAllegato.Id = "296f15c6-df68-43f8-89f0-471b855f6902"
      Me.eui_cmdApriDocAllegato.Location = New System.Drawing.Point(7, 296)
      Me.eui_cmdApriDocAllegato.Name = "eui_cmdApriDocAllegato"
      Me.eui_cmdApriDocAllegato.Size = New System.Drawing.Size(104, 30)
      Me.eui_cmdApriDocAllegato.TabIndex = 1
      Me.eui_cmdApriDocAllegato.Text = "&Apri documento"
      '
      'eui_cmdInserisciAllegato
      '
      Me.eui_cmdInserisciAllegato.Id = "4f490082-3d2e-4073-b7fe-7240f0d40e28"
      Me.eui_cmdInserisciAllegato.Location = New System.Drawing.Point(331, 295)
      Me.eui_cmdInserisciAllegato.Name = "eui_cmdInserisciAllegato"
      Me.eui_cmdInserisciAllegato.Size = New System.Drawing.Size(75, 30)
      Me.eui_cmdInserisciAllegato.TabIndex = 2
      Me.eui_cmdInserisciAllegato.Text = "&Inserisci"
      '
      'eui_cmdRimuoviAllegato
      '
      Me.eui_cmdRimuoviAllegato.Id = "50b6def9-b6c9-4513-afc4-d03f9c51d9a1"
      Me.eui_cmdRimuoviAllegato.Location = New System.Drawing.Point(491, 295)
      Me.eui_cmdRimuoviAllegato.Name = "eui_cmdRimuoviAllegato"
      Me.eui_cmdRimuoviAllegato.Size = New System.Drawing.Size(75, 30)
      Me.eui_cmdRimuoviAllegato.TabIndex = 4
      Me.eui_cmdRimuoviAllegato.Text = "&Rimuovi"
      '
      'eui_cmdModificaAllegato
      '
      Me.eui_cmdModificaAllegato.Id = "4e1a42a7-fbbb-4825-9b25-3b03c18d7efc"
      Me.eui_cmdModificaAllegato.Location = New System.Drawing.Point(411, 295)
      Me.eui_cmdModificaAllegato.Name = "eui_cmdModificaAllegato"
      Me.eui_cmdModificaAllegato.Size = New System.Drawing.Size(75, 30)
      Me.eui_cmdModificaAllegato.TabIndex = 3
      Me.eui_cmdModificaAllegato.Text = "&Modifica"
      '
      'lvwAllegati
      '
      Me.lvwAllegati.AllowColumnReorder = True
      Me.lvwAllegati.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6})
      Me.lvwAllegati.FullRowSelect = True
      Me.lvwAllegati.HideSelection = False
      Me.lvwAllegati.Location = New System.Drawing.Point(0, 0)
      Me.lvwAllegati.MultiSelect = False
      Me.lvwAllegati.Name = "lvwAllegati"
      Me.lvwAllegati.Size = New System.Drawing.Size(574, 287)
      Me.lvwAllegati.StateImageList = Me.ImageList1
      Me.lvwAllegati.TabIndex = 0
      Me.lvwAllegati.UseCompatibleStateImageBehavior = False
      Me.lvwAllegati.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Documento"
      Me.ColumnHeader1.Width = 200
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Data"
      Me.ColumnHeader2.Width = 75
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Ora"
      Me.ColumnHeader3.Width = 75
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Text = "Note"
      Me.ColumnHeader4.Width = 500
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Text = "Percorso"
      Me.ColumnHeader5.Width = 500
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.Text = "Codice"
      Me.ColumnHeader6.Width = 0
      '
      'tpNote
      '
      Me.tpNote.ActiveControl = Nothing
      Me.tpNote.Controls.Add(Me.eui_txtNote)
      Me.tpNote.KeyTip = Nothing
      Me.tpNote.Name = "tpNote"
      Me.tpNote.Size = New System.Drawing.Size(575, 332)
      Me.tpNote.TabIndex = 3
      Me.tpNote.Text = "Note"
      '
      'eui_txtNote
      '
      Me.eui_txtNote.Id = "e5c9cad8-2145-43be-9f3c-f29d123bd56b"
      Me.eui_txtNote.Location = New System.Drawing.Point(1, 0)
      Me.eui_txtNote.Multiline = True
      Me.eui_txtNote.Name = "eui_txtNote"
      Me.eui_txtNote.Size = New System.Drawing.Size(573, 331)
      Me.eui_txtNote.TabIndex = 0
      Me.eui_txtNote.TextEditorWidth = 567
      '
      'frmNoleggi
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(591, 423)
      Me.Controls.Add(Me.TabControl2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmNoleggi"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Noleggi"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tpDati.ResumeLayout(False)
      Me.tpDati.PerformLayout()
      Me.tpArticoli.ResumeLayout(False)
      Me.tpAllegati.ResumeLayout(False)
      Me.tpNote.ResumeLayout(False)
      Me.tpNote.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private CNoleggi As New Noleggi
   Private CDettagliNoleggi As New DettagliNoleggi
   Private CCausaliNoleggio As New CausaliNoleggio

   Private IAllegati As New Allegati
   Private CConvalida As New ConvalidaKeyPress
   Private CFormatta As New ClsFormatta

   Public TAB_NOLEGGI As String = "Noleggi"
   Const TAB_CLIENTI As String = "Clienti"
   Const TAB_CAUSALI_NOLEGGIO As String = "CausaliNoleggio"
   Const TAB_DETTAGLI_CAUSALI_NOLEGGIO As String = "DettagliCausaliNoleggio"
   Const TAB_STATO_NOLEGGI As String = "StatoNoleggi"
   Const TAB_DETTAGLI_NOLEGGI As String = "DettagliNoleggi"
   Const TAB_ALLEGATI As String = "Noleggi_Allegati"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)

   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   Dim dt As DataTable

   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
   End Sub

   Private Function SalvaDati() As Boolean
      Try
         ' Se la data di Inizio Ë pi˘ grande della data di Fine o viceversa lo segnala all'utente.
         Dim dataInizio As DateTime = eui_dtpDataInizio.Value
         Dim dataFine As DateTime = eui_dtpDataFine.Value

         If dataInizio.Date > dataFine.Date Then
            MessageBox.Show("Specificare un'intervallo di date corretto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            eui_dtpDataInizio.Focus()

            Exit Function
         End If

         ' Assegna i dati dei campi della classe alle caselle di testo.
         With CNoleggi

            .CodiceBarre = eui_txtCodiceBarre.Text
            .IdCliente = eui_cmbIdCliente.Text
            .Cliente = eui_cmbCliente.Text
            ' TODO_N: Dati cliente non utilizzati. Valutare se rimuovere!
            .Indirizzo = String.Empty
            .Cap = String.Empty
            .Citt‡ = String.Empty
            .Provincia = String.Empty
            .PIva = String.Empty
            .CodFiscale = String.Empty
            .CodAzienda = String.Empty
            .IdCausale = String.Empty
            .Causale = eui_cmbCausale.Text

            .TipoPeriodo = eui_cmbTipoPeriodo.Text
            .Periodo = eui_cmbPeriodo.Text

            Select Case eui_cmbTipoPeriodo.Text
               Case "Ore"
                  .DataInizio = Convert.ToDateTime(eui_dtpOraInizio.Value.ToString)
                  .DataFine = Convert.ToDateTime(eui_dtpOraFine.Value.ToString)

               Case "Giorni"
                  .DataInizio = Convert.ToDateTime(eui_dtpDataInizio.Value.ToString)
                  .DataFine = Convert.ToDateTime(eui_dtpDataFine.Value.ToString)
            End Select

            .TotaleGiorni = eui_txtTotaleOreGiorni.Text

            If IsNumeric(eui_txtCostoGiorno.Text) = True Then
               .CostoGiorno = Convert.ToDouble(eui_txtCostoGiorno.Text)
            Else
               .CostoGiorno = 0.0
            End If

            If IsNumeric(eui_txtSconto.Text) = True Then
               .Sconto = Convert.ToDouble(eui_txtSconto.Text)
            Else
               .Sconto = 0.0
            End If

            If IsNumeric(eui_txtCostoMora.Text) = True Then
               .CostoMora = Convert.ToDouble(eui_txtCostoMora.Text)
            Else
               .CostoMora = 0.0
            End If

            If IsNumeric(eui_txtCostoAssicurazione.Text) = True Then
               .CostoAssicurazione = Convert.ToDouble(eui_txtCostoAssicurazione.Text)
            Else
               .CostoAssicurazione = 0.0
            End If

            If IsNumeric(eui_txtTotaleImporto.Text) = True Then
               .Totale = Convert.ToDouble(eui_txtTotaleImporto.Text)
            Else
               .Totale = 0.0
            End If

            .TipoSconto = String.Empty
            .Stato = eui_cmbStato.Text
            .Chiuso = "No"
            .Note = eui_txtNote.Text

            If .Colore = 0 Then
               .Colore = Color.White.ToArgb
            Else
               .Colore = eui_cmdColore.BackColor.ToArgb
            End If

         End With

         ' Se la propriet‡ 'Tag' contiene un valore viene richiamata la procedura
         ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
         If Me.Tag <> String.Empty Then
            Return CNoleggi.ModificaDati(TAB_NOLEGGI, Me.Tag)
         Else
            Return CNoleggi.InserisciDati(TAB_NOLEGGI)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Function SalvaArticoli(ByVal id As String) As Boolean
      ' Salva i dati degli occupanti.
      Try
         Dim idNoleggio As Integer

         If id <> String.Empty Then
            idNoleggio = id
         Else
            idNoleggio = LeggiUltimoRecord(TAB_NOLEGGI)
         End If

         With CDettagliNoleggi
            .EliminaDati(TAB_DETTAGLI_NOLEGGI, idNoleggio)

            Dim i As Integer
            For i = 0 To lstvElencoArticoli.Items.Count - 1
               .RifNoleggio = idNoleggio
               .CodiceArticolo = lstvElencoArticoli.Items(i).SubItems(0).Text
               .Descrizione = lstvElencoArticoli.Items(i).SubItems(1).Text
               .Unit‡Misura = lstvElencoArticoli.Items(i).SubItems(2).Text
               .Quantit‡ = Convert.ToDouble(lstvElencoArticoli.Items(i).SubItems(3).Text)
               .ValoreUnitario = lstvElencoArticoli.Items(i).SubItems(4).Text
               .ImportoNetto = lstvElencoArticoli.Items(i).SubItems(5).Text
               .AliquotaIva = lstvElencoArticoli.Items(i).SubItems(6).Text
               .Categoria = lstvElencoArticoli.Items(i).SubItems(7).Text

               .InserisciDati(TAB_DETTAGLI_NOLEGGI)
            Next
         End With

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Function CalcolaCostoTotaleArticoli() As String
      Try
         Dim valCostoArticolo As Double
         Dim valTotaleCostoArticoli As Double

         Dim i As Integer
         For i = 0 To lstvElencoArticoli.Items.Count - 1
            valCostoArticolo = lstvElencoArticoli.Items(i).SubItems(5).Text

            valTotaleCostoArticoli = valTotaleCostoArticoli + valCostoArticolo
         Next

         Return CFormatta.FormattaNumeroDouble(valTotaleCostoArticoli)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0.0
      End Try
   End Function

   Private Function ImpostaDatiAllegati(ByVal note As String, ByVal ins As Boolean) As Boolean
      Try
         OpenFileDialog1.Filter = "Tutti i file |*.*"

         OpenFileDialog1.FilterIndex = 1

         IAllegati.IdCliente = CInt(CNoleggi.Codice)

         If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            ' Assegna i dati dei campi della classe alle caselle di testo.
            IAllegati.Documento = Path.GetFileName(OpenFileDialog1.FileName)
            IAllegati.Data = CStr(Today)
            IAllegati.Ora = CStr(TimeOfDay)
            IAllegati.Percorso = OpenFileDialog1.FileName
            IAllegati.Estensione = Path.GetExtension(OpenFileDialog1.FileName)
         Else
            If ins = True Then
               Return False
            End If
         End If

         Dim val As String
         val = InputBox("Digitare il testo per il campo Note.", "Note", note)
         If val <> "" Then
            IAllegati.Note = val
         Else
            IAllegati.Note = note
         End If

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Sub RimuoviAllegati(ByVal tabella As String, ByVal id As Integer)
      Try
         Dim Risposta As Short
         Dim sql As String

         Dim Documento As String = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera rimuovere il documento """ & Documento & """?" & vbCrLf & vbCrLf &
                           "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma rimozione")

         If Risposta = MsgBoxResult.Yes Then
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record As Integer = cmdDelete.ExecuteNonQuery()

            ' Conferma la transazione.
            tr.Commit()

         End If

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Private Sub ConvalidaAllegati()
      Try
         ' Carica la lista dei documenti allegati.
         If IAllegati.LeggiDati(lvwAllegati, TAB_ALLEGATI, CNoleggi.Codice) = True Then
            eui_cmdApriDocAllegato.Enabled = True
            eui_cmdModificaAllegato.Enabled = True
            eui_cmdRimuoviAllegato.Enabled = True
         Else
            eui_cmdApriDocAllegato.Enabled = False
            eui_cmdModificaAllegato.Enabled = False
            eui_cmdRimuoviAllegato.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Function CaricaElencoArticoli(ByVal lst As ListView, ByVal tabella As String, ByVal rifNoleggio As String) As Boolean
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)
         Dim Caricati As Boolean = False

         Try
            cn.Open()

            Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifNoleggio = " & rifNoleggio & " ORDER BY Descrizione ASC", cn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            Dim i As Integer

            lst.Items.Clear()

            Do While dr.Read
               ' Codice.
               lst.Items.Add(dr.Item("CodiceArticolo"))

               ' Descrizione.
               If IsDBNull(dr.Item("Descrizione")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Descrizione").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If

               ' Unit‡ Misura.
               If IsDBNull(dr.Item("Unit‡Misura")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Unit‡Misura").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If

               ' Quantit‡.
               If IsDBNull(dr.Item("Quantit‡")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Quantit‡"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Valore Unitario.
               If IsDBNull(dr.Item("ValoreUnitario")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("ValoreUnitario"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Importo Netto.
               If IsDBNull(dr.Item("ImportoNetto")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("ImportoNetto"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Aliquota Iva.
               If IsDBNull(dr.Item("AliquotaIva")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("AliquotaIva"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Categoria.
               If IsDBNull(dr.Item("Categoria")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Categoria").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If

               ' Id.
               If IsDBNull(dr.Item("Id")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Id").ToString)
               Else
                  lst.Items(i).SubItems.Add(0.ToString)
               End If

               ' RifNoleggio.
               If IsDBNull(dr.Item("RifNoleggio")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("RifNoleggio").ToString)
               Else
                  lst.Items(i).SubItems.Add(0.ToString)
               End If

               ' Imposta l'immagine.
               lst.Items(i).StateImageIndex = 11

               ' Contatore.
               i += 1

               Caricati = True
            Loop

            Return Caricati

         Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

            Return False

         Finally
            cn.Close()

         End Try

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Function CaricaElencoArticoliCausali(ByVal lst As ListView, ByVal tabella As String, ByVal rifCausale As String) As Boolean
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)
         Dim Caricati As Boolean = False

         Try
            cn.Open()

            Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifCausale = " & rifCausale & " ORDER BY Descrizione ASC", cn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            Dim i As Integer

            lst.Items.Clear()

            Do While dr.Read
               ' Codice.
               lst.Items.Add(dr.Item("CodiceArticolo"))

               ' Descrizione.
               If IsDBNull(dr.Item("Descrizione")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Descrizione").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If

               ' Unit‡ Misura.
               If IsDBNull(dr.Item("Unit‡Misura")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Unit‡Misura").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If

               ' Quantit‡.
               If IsDBNull(dr.Item("Quantit‡")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Quantit‡"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Valore Unitario.
               If IsDBNull(dr.Item("ValoreUnitario")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("ValoreUnitario"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Importo Netto.
               If IsDBNull(dr.Item("ImportoNetto")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("ImportoNetto"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Aliquota Iva.
               If IsDBNull(dr.Item("AliquotaIva")) = False Then
                  lst.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("AliquotaIva"))))
               Else
                  lst.Items(i).SubItems.Add(VALORE_ZERO)
               End If

               ' Categoria.
               If IsDBNull(dr.Item("Categoria")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Categoria").ToString)
               Else
                  lst.Items(i).SubItems.Add(String.Empty)
               End If

               ' Id.
               If IsDBNull(dr.Item("Id")) = False Then
                  lst.Items(i).SubItems.Add(dr.Item("Id").ToString)
               Else
                  lst.Items(i).SubItems.Add(0.ToString)
               End If

               ' RifNoleggio.
               If eui_txtCodice.Text <> String.Empty Then
                  lst.Items(i).SubItems.Add(eui_txtCodice.Text)
               Else
                  lst.Items(i).SubItems.Add(LeggiUltimoRecord(TAB_NOLEGGI))
               End If

               ' Imposta l'immagine.
               lst.Items(i).StateImageIndex = 11

               ' Contatore.
               i += 1

               Caricati = True
            Loop

            Return Caricati

         Catch ex As Exception
            ' Visualizza un messaggio di errore e lo registra nell'apposito file.
            err.GestisciErrore(ex.StackTrace, ex.Message)

            Return False

         Finally
            cn.Close()

         End Try

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Sub EliminaArticolo()
      Try
         Dim Risposta As Short
         Dim Articolo As String = lstvElencoArticoli.Items(lstvElencoArticoli.FocusedItem.Index).SubItems(1).Text

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera rimuovere l'articolo """ & Articolo & """ dalla lista?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma elimina")

         If Risposta = MsgBoxResult.Yes Then
            lstvElencoArticoli.Items(lstvElencoArticoli.FocusedItem.Index).Remove()
         End If

      Catch ex As Exception

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function CalcolaCostoTotaleNoleggio(ByVal numGiorni As String, ByVal costo As String, ByVal sconto As String, ByVal assicurazione As String, ByVal mora As String) As String
      Try
         Dim numGiorniNoleggio As Integer
         Dim costoNoleggio As Double
         Dim scontoNoleggio As Double
         Dim assicurazioneNoleggio As Double
         Dim moraNoleggio As Double
         Dim totaleNoleggio As Double

         ' Conversione di tutti i valori stringa in numerici.
         If IsNumeric(numGiorni) = True Then
            numGiorniNoleggio = Convert.ToInt32(numGiorni)
         Else
            numGiorniNoleggio = 0
         End If

         If IsNumeric(costo) = True Then
            costoNoleggio = Convert.ToDouble(costo)
         Else
            costoNoleggio = 0.0
         End If

         If IsNumeric(assicurazione) = True Then
            assicurazioneNoleggio = Convert.ToDouble(assicurazione * numGiorniNoleggio)
         Else
            assicurazioneNoleggio = 0.0
         End If

         If IsNumeric(mora) = True Then
            moraNoleggio = Convert.ToDouble(mora)
         Else
            moraNoleggio = 0.0
         End If

         ' Calcola lo sconto a valore o percentuale.
         If sconto.Contains("%") = True Then
            ' Sconto a percentuale.
            scontoNoleggio = Convert.ToDouble(sconto.Remove(sconto.Length - 1, 1))
            scontoNoleggio = CalcolaPercentuale(costoNoleggio * numGiorniNoleggio, scontoNoleggio)
         Else
            If IsNumeric(sconto) = True Then
               ' Sconto a valore.
               scontoNoleggio = Convert.ToDouble(sconto)
            Else
               scontoNoleggio = 0.0
            End If
         End If

         ' Calcolo del costo della Mora.
         Dim moraNoleggioTotale As Double

         Select Case eui_cmbTipoPeriodo.Text
            Case "Ore"
               ' Calcola l'eventuale costo orario della Mora aggiuntiva.
               Dim numOreMora As TimeSpan = (Now - eui_dtpOraFine.Value)

               If numOreMora.Hours > 0 Then
                  moraNoleggioTotale = (moraNoleggio * numOreMora.Hours)
               Else
                  moraNoleggioTotale = 0.0
               End If

            Case "Giorni"
               ' Calcola l'eventuale costo giornaliero della Mora aggiuntiva.
               Dim numGiorniMora As TimeSpan = (Now.Date - eui_dtpDataFine.Value)

               If numGiorniMora.Days > 0 Then
                  moraNoleggioTotale = (moraNoleggio * numGiorniMora.Days)
               Else
                  moraNoleggioTotale = 0.0
               End If

         End Select

         ' Calcola il costo totale del Noleggio. 
         totaleNoleggio = ((costoNoleggio * numGiorniNoleggio) - scontoNoleggio) + assicurazioneNoleggio + moraNoleggioTotale

         Return CFormatta.FormattaNumeroDouble(totaleNoleggio)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO
      End Try

   End Function

   Private Sub ApriDocumentoAllegato()
      Dim Estensione As String
      Dim NomeFile As String
      Dim Percorso As String
      Dim PercorsoApp As String
      Dim NomeApp As String
      Dim Proc As New Process

      Try
         ' Nome del file.
         NomeFile = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text
         ' Percorso del file.
         Percorso = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(4).Text

         ' Ottiene l'estensione del file.
         Estensione = Path.GetExtension(Percorso)

         Select Case Estensione.ToUpper
            Case ".DOC", ".RTF"
               ' Word
               NomeApp = "WINWORD.EXE"

            Case ".XLS"
               ' Excel
               NomeApp = "EXCEL.EXE"

            Case ".MDB"
               ' Access
               NomeApp = "MSACCESS.EXE"

            Case ".PPT"
               ' Power Point
               NomeApp = "POWERPNT.EXE"

            Case ".TXT"
               ' Blocco note.
               NomeApp = "NOTEPAD.EXE"

            Case ".PDF"
               ' Acrobat Reader
               NomeApp = "ACRORD32.EXE"

            Case ".HTM"
               ' Internet Explorer
               NomeApp = "IEXPLORE.EXE"
         End Select

         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NomeApp
         Proc.StartInfo.Arguments = Percorso
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = Me.Handle
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub Noleggi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta le dimensioni del form.
         FormResize(NOLEGGI_LARGHEZZA, NOLEGGI_ALTEZZA)

         ' Carica le liste.
         CaricaListaClienti(eui_cmbCliente, eui_cmbIdCliente, TAB_CLIENTI)
         CaricaLista(eui_cmbCausale, eui_cmbIdCausale, TAB_CAUSALI_NOLEGGIO)
         CaricaLista(eui_cmbStato, TAB_STATO_NOLEGGI)

         If Me.Tag <> String.Empty Then
            With CNoleggi

               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(TAB_NOLEGGI, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               eui_txtCodice.Text = .Codice
               eui_txtCodiceBarre.Text = .CodiceBarre
               eui_cmbIdCliente.Text = .IdCliente
               eui_cmbCliente.Text = .Cliente
               eui_cmbCausale.Text = .Causale

               eui_cmbTipoPeriodo.Text = .TipoPeriodo
               eui_cmbPeriodo.Text = .Periodo

               eui_dtpDataInizio.Text = .DataInizio
               eui_dtpDataFine.Text = .DataFine
               eui_dtpOraInizio.Text = .DataInizio
               eui_dtpOraFine.Text = .DataFine
               eui_txtTotaleOreGiorni.Text = .TotaleGiorni

               eui_txtCostoGiorno.Text = CFormatta.FormattaNumeroDouble(.CostoGiorno)
               eui_txtSconto.Text = CFormatta.FormattaNumeroDouble(.Sconto)
               eui_txtCostoMora.Text = CFormatta.FormattaNumeroDouble(.CostoMora)
               eui_txtCostoAssicurazione.Text = CFormatta.FormattaNumeroDouble(.CostoAssicurazione)
               eui_txtTotaleImporto.Text = CFormatta.FormattaNumeroDouble(.Totale)
               eui_cmbStato.Text = .Stato
               eui_txtNote.Text = .Note

               If .Colore <> 0 Then
                  eui_cmdColore.BackColor = Color.FromArgb(.Colore)
               End If

               ' Per i dati gi‡ esistenti nel database (con un id) rende la scheda Allegati disponibile.
               TabControl2.TabPages(2).Enabled = True

               ' Carica la lista delle degli allegati.
               ConvalidaAllegati()

               ' Carica la lista degli Articoli Noleggiati.
               CaricaElencoArticoli(lstvElencoArticoli, TAB_DETTAGLI_NOLEGGI, CNoleggi.Codice)

            End With
         Else
            ' In caso di nuovo inserimento dati imposta i valori di default.

            eui_cmbTipoPeriodo.SelectedIndex = 0
            eui_cmbPeriodo.SelectedIndex = 1

            eui_cmbStato.Text = "Bozza"

            ' Per i nuovi dati che non sono nel database (con un id) disattiva la scheda Allegati.
            TabControl2.TabPages(2).Enabled = False
         End If

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(eui_txtCodice.Text, eui_cmbCliente.Text, String.Empty)

         ' Imposta lo stato attivo.
         eui_cmbCliente.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try
   End Sub

   ' TODO_B: Modificare.
   Private Sub Noleggi_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_FORNITORI)
      End If

      g_frmSchedaNoleggi.Dispose()
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If SalvaDati() = True Then

               ' Salva gli articoli noleggiati.
               SalvaArticoli(Me.Tag)

               If IsNothing(g_frmNoleggi) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmNoleggi.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & CNoleggi.Cliente & ")"

               ' TODO_B: Modificare.
               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_FORNITORI)
            End If

         Case "Annulla"
            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_FORNITORI)
      End Select
   End Sub

   Private Sub TabControl2_SelectedTabPageChanged(sender As Object, e As Elegant.Ui.TabPageChangedEventArgs) Handles TabControl2.SelectedTabPageChanged
      Try
         Select Case TabControl2.SelectedTabPage.TabIndex
            Case 0
               ' Imposta lo stato attivo.
               eui_txtCodice.Focus()

            Case 1
               ' Imposta lo stato attivo.
               lstvElencoArticoli.Focus()

               ' Imposta il pulsante di default.
               eui_cmdInserisci.NotifyDefault(True)

            Case 2
               ' Imposta lo stato attivo.
               lvwAllegati.Focus()

               ' Imposta il pulsante di default.
               eui_cmdInserisciAllegato.NotifyDefault(True)

            Case 3
               ' Imposta lo stato attivo.
               eui_txtNote.Focus()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub lvwAllegati_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwAllegati.DoubleClick
      ApriDocumentoAllegato()
   End Sub

   Private Sub eui_cmbTipoPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbTipoPeriodo.SelectedIndexChanged
      Try
         ' Imposta la data corrente.
         eui_dtpDataInizio.Value = Now
         eui_dtpDataFine.Value = Now

         ' Imposta l'ora corrente.
         eui_dtpOraInizio.Value = Now
         eui_dtpOraFine.Value = Now

         ' Disattiva i controlli data.
         eui_dtpDataInizio.Enabled = False
         eui_dtpDataFine.Enabled = False

         Select Case eui_cmbTipoPeriodo.Text
            Case "Ore"
               ' Elimina tutti gli elementi dalla lista.
               eui_cmbPeriodo.Items.Clear()

               ' Ore.
               eui_cmbPeriodo.Items.Add("1 Ora")
               eui_cmbPeriodo.Items.Add("2 Ore")
               eui_cmbPeriodo.Items.Add("3 Ore")
               eui_cmbPeriodo.Items.Add("4 Ore")
               eui_cmbPeriodo.Items.Add("5 Ore")
               eui_cmbPeriodo.Items.Add("6 Ore")

            Case "Giorni"
               ' Elimina tutti gli elementi dalla lista.
               eui_cmbPeriodo.Items.Clear()

               ' Selezione del periodo manuale.
               eui_cmbPeriodo.Items.Add("Selezione manuale")

               ' Giorni.
               eui_cmbPeriodo.Items.Add("1 Giorno")
               eui_cmbPeriodo.Items.Add("2 Giorni")
               eui_cmbPeriodo.Items.Add("3 Giorni")
               eui_cmbPeriodo.Items.Add("4 Giorni")
               eui_cmbPeriodo.Items.Add("5 Giorni")
               eui_cmbPeriodo.Items.Add("6 Giorni")
               eui_cmbPeriodo.Items.Add("7 Giorni")

               ' Mesi.
               eui_cmbPeriodo.Items.Add("1 Mese")
               eui_cmbPeriodo.Items.Add("2 Mesi")
               eui_cmbPeriodo.Items.Add("3 Mesi")
               eui_cmbPeriodo.Items.Add("4 Mesi")
               eui_cmbPeriodo.Items.Add("5 Mesi")
               eui_cmbPeriodo.Items.Add("6 Mesi")

               ' Anni.
               eui_cmbPeriodo.Items.Add("1 Anno")
               eui_cmbPeriodo.Items.Add("2 Anni")
               eui_cmbPeriodo.Items.Add("3 Anni")
               eui_cmbPeriodo.Items.Add("4 Anni")
               eui_cmbPeriodo.Items.Add("5 Anni")

         End Select

         eui_cmbPeriodo.SelectedIndex = 1

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmbPeriodo_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbPeriodo.SelectedIndexChanged
      Try
         Const TOTALE_ORE As String = "Totale ore:"
         Const TOTALE_GIORNI As String = "Totale giorni:"
         Const COSTO_GIORNI As String = "Costo giornaliero:"
         Const COSTO_ORE As String = "Costo orario:"
         Const COSTO_MORA_GIORNI As String = "Costo Mora giornaliera:"
         Const COSTO_MORA_ORE As String = "Costo Mora oraria:"

         Dim tempoOreGiorni As Double

         ' Disattiva i controlli data.
         eui_dtpDataInizio.Enabled = False
         eui_dtpDataFine.Enabled = False

         Select Case eui_cmbPeriodo.Text

            Case "Selezione manuale"
               ' Imposta il tempo.
               tempoOreGiorni = 0
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now

               eui_dtpDataInizio.Enabled = True
               eui_dtpDataFine.Enabled = True

            Case "1 Ora"
               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               tempoOreGiorni = 1
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now.AddHours(tempoOreGiorni)

               ' Imposta il tempo in ore.
               lblTotaleOreGiorni.Text = TOTALE_ORE
               lblCostoOreGiorni.Text = COSTO_ORE
               lblCostoMoraOreGiorni.Text = COSTO_MORA_ORE
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

            Case "2 Ore"
               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               tempoOreGiorni = 2
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now.AddHours(tempoOreGiorni)

               ' Imposta il tempo in ore.
               lblTotaleOreGiorni.Text = TOTALE_ORE
               lblCostoOreGiorni.Text = COSTO_ORE
               lblCostoMoraOreGiorni.Text = COSTO_MORA_ORE
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

            Case "3 Ore"
               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               tempoOreGiorni = 3
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now.AddHours(tempoOreGiorni)

               ' Imposta il tempo in ore.
               lblTotaleOreGiorni.Text = TOTALE_ORE
               lblCostoOreGiorni.Text = COSTO_ORE
               lblCostoMoraOreGiorni.Text = COSTO_MORA_ORE
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

            Case "4 Ore"
               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               tempoOreGiorni = 4
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now.AddHours(tempoOreGiorni)

               ' Imposta il tempo in ore.
               lblTotaleOreGiorni.Text = TOTALE_ORE
               lblCostoOreGiorni.Text = COSTO_ORE
               lblCostoMoraOreGiorni.Text = COSTO_MORA_ORE
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

            Case "5 Ore"
               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               tempoOreGiorni = 5
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now.AddHours(tempoOreGiorni)

               ' Imposta il tempo in ore.
               lblTotaleOreGiorni.Text = TOTALE_ORE
               lblCostoOreGiorni.Text = COSTO_ORE
               lblCostoMoraOreGiorni.Text = COSTO_MORA_ORE
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

            Case "6 Ore"
               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               tempoOreGiorni = 6
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now.AddHours(tempoOreGiorni)

               ' Imposta il tempo in ore.
               lblTotaleOreGiorni.Text = TOTALE_ORE
               lblCostoOreGiorni.Text = COSTO_ORE
               lblCostoMoraOreGiorni.Text = COSTO_MORA_ORE
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

            Case "1 Giorno"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 1
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "2 Giorni"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 2
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "3 Giorni"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 3
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "4 Giorni"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 4
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "5 Giorni"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 5
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "6 Giorni"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 6
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "7 Giorni"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 7
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "1 Mese"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 30
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "2 Mesi"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 60
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "3 Mesi"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 90
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "4 Mesi"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 120
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "5 Mesi"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 150
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "6 Mesi"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 180
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "1 Anno"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 365
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "2 Anni"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 730
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "3 Anni"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 1095
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "4 Anni"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 1460
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

            Case "5 Anni"
               ' Imposta il tempo in giorni.
               tempoOreGiorni = 1825
               lblTotaleOreGiorni.Text = TOTALE_GIORNI
               lblCostoOreGiorni.Text = COSTO_GIORNI
               lblCostoMoraOreGiorni.Text = COSTO_MORA_GIORNI
               eui_txtTotaleOreGiorni.Text = tempoOreGiorni.ToString

               ' Imposta la data e l'ora correnti di inizio e fine noleggio.
               eui_dtpOraInizio.Value = Now
               eui_dtpOraFine.Value = Now
               eui_dtpDataInizio.Value = Now
               eui_dtpDataFine.Value = Now.AddDays(tempoOreGiorni)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_dtpDataInizio_ValueChanged(sender As Object, e As EventArgs) Handles eui_dtpDataInizio.ValueChanged
      Try
         Dim dataInizio As DateTime = eui_dtpDataInizio.Value
         Dim dataFine As DateTime = eui_dtpDataFine.Value

         Dim oreGiorni As TimeSpan = dataFine.Date - dataInizio.Date

         eui_txtTotaleOreGiorni.Text = oreGiorni.Days.ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_dtpDataFine_ValueChanged(sender As Object, e As EventArgs) Handles eui_dtpDataFine.ValueChanged
      Try
         Dim dataInizio As DateTime = eui_dtpDataInizio.Value
         Dim dataFine As DateTime = eui_dtpDataFine.Value

         Dim oreGiorni As TimeSpan = dataFine.Date - dataInizio.Date

         eui_txtTotaleOreGiorni.Text = oreGiorni.Days.ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCostoGiorno_LostFocus(sender As Object, e As EventArgs) Handles eui_txtCostoGiorno.LostFocus
      Try
         eui_txtTotaleImporto.Text = CalcolaCostoTotaleNoleggio(eui_txtTotaleOreGiorni.Text,
                                                                   eui_txtCostoGiorno.Text,
                                                                   eui_txtSconto.Text,
                                                                   eui_txtCostoAssicurazione.Text,
                                                                   eui_txtCostoMora.Text)

         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtSconto_LostFocus(sender As Object, e As EventArgs) Handles eui_txtSconto.LostFocus
      Try
         eui_txtTotaleImporto.Text = CalcolaCostoTotaleNoleggio(eui_txtTotaleOreGiorni.Text,
                                                                   eui_txtCostoGiorno.Text,
                                                                   eui_txtSconto.Text,
                                                                   eui_txtCostoAssicurazione.Text,
                                                                   eui_txtCostoMora.Text)

         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCostoMora_LostFocus(sender As Object, e As EventArgs) Handles eui_txtCostoMora.LostFocus
      Try
         eui_txtTotaleImporto.Text = CalcolaCostoTotaleNoleggio(eui_txtTotaleOreGiorni.Text,
                                                                   eui_txtCostoGiorno.Text,
                                                                   eui_txtSconto.Text,
                                                                   eui_txtCostoAssicurazione.Text,
                                                                   eui_txtCostoMora.Text)

         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCostoAssicurazione_LostFocus(sender As Object, e As EventArgs) Handles eui_txtCostoAssicurazione.LostFocus
      Try
         eui_txtTotaleImporto.Text = CalcolaCostoTotaleNoleggio(eui_txtTotaleOreGiorni.Text,
                                                                   eui_txtCostoGiorno.Text,
                                                                   eui_txtSconto.Text,
                                                                   eui_txtCostoAssicurazione.Text,
                                                                   eui_txtCostoMora.Text)

         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCostoGiorno_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCostoGiorno.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub eui_txtSconto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtSconto.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub eui_txtCostoMora_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCostoMora.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub eui_txtCostoAssicurazione_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCostoAssicurazione.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub eui_cmbStato_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbStato.SelectedIndexChanged
      Try
         eui_cmdColore.BackColor = Color.FromArgb(AssegnaColore(eui_cmbStato.Text, TAB_STATO_NOLEGGI))
         CNoleggi.Colore = Convert.ToString(eui_cmdColore.BackColor.ToArgb)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub eui_cmdColore_Click(sender As Object, e As EventArgs) Handles eui_cmdColore.Click
      MessageBox.Show("Per assegnare un colore al noleggio selezionare un valore nella casella 'Stato'.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Sub

   Public Function LeggiScontoCliente(ByVal tabella As String, ByVal id As Integer) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Sconto").ToString
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

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

   Private Sub eui_cmdNuovoCliente_Click(sender As Object, e As EventArgs) Handles eui_cmdNuovoCliente.Click
      Try
         ' Se Ë stato inserito un nuovo cliente...
         If ApriClienti(String.Empty) = True Then
            CaricaListaClienti(eui_cmbCliente, eui_cmbIdCliente, TAB_CLIENTI)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdModificaCliente_Click(sender As Object, e As EventArgs) Handles eui_cmdModificaCliente.Click
      Try
         ' Modifica cliente esistente...
         If ApriClienti(eui_cmbIdCliente.Text) = True Then
            CaricaListaClienti(eui_cmbCliente, eui_cmbIdCliente, TAB_CLIENTI)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmbCliente_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbCliente.SelectedIndexChanged
      Try
         ' Legge il nome relativo alla lista Cognome.
         eui_cmbIdCliente.SelectedIndex = eui_cmbCliente.SelectedIndex

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(eui_txtCodice.Text, eui_cmbCliente.Text, String.Empty)

         ' Se Ë impostata l'aliquota Iva per il cliente... Altrimenti viene utilzzata quella di reparto.
         'Dim valIva As String = CFormatta.FormattaEuro(LeggiIvaCliente(ANA_CLIENTI, cmbIdCliente.Text))
         'If valIva <> VALORE_ZERO Then
         '   txtIva.Text = valIva
         'End If

         Dim valSconto As String = LeggiScontoCliente(TAB_CLIENTI, eui_cmbIdCliente.Text)

         If IsNumeric(valSconto) = True Then
            eui_txtSconto.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(valSconto)) & "%"
         Else
            eui_txtSconto.Text = VALORE_ZERO
         End If

         eui_txtTotaleImporto.Text = CalcolaCostoTotaleNoleggio(eui_txtTotaleOreGiorni.Text,
                                                                   eui_txtCostoGiorno.Text,
                                                                   eui_txtSconto.Text,
                                                                   eui_txtCostoAssicurazione.Text,
                                                                   eui_txtCostoMora.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdElimina_Click(sender As Object, e As EventArgs) Handles eui_cmdElimina.Click
      Try
         eui_cmdInserisci.NotifyDefault(False)

         lstvElencoArticoli.Focus()

         EliminaArticolo()

         eui_txtCostoGiorno.Text = CalcolaCostoTotaleArticoli()

         eui_txtTotaleImporto.Text = CalcolaCostoTotaleNoleggio(eui_txtTotaleOreGiorni.Text,
                                                                   eui_txtCostoGiorno.Text,
                                                                   eui_txtSconto.Text,
                                                                   eui_txtCostoAssicurazione.Text,
                                                                   eui_txtCostoMora.Text)

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdInserisci_Click(sender As Object, e As EventArgs) Handles eui_cmdInserisci.Click
      Try
         Dim frm As New ListaArticoli
         frm.ShowDialog()

         eui_txtCostoGiorno.Text = CalcolaCostoTotaleArticoli()

         eui_txtTotaleImporto.Text = CalcolaCostoTotaleNoleggio(eui_txtTotaleOreGiorni.Text,
                                                                   eui_txtCostoGiorno.Text,
                                                                   eui_txtSconto.Text,
                                                                   eui_txtCostoAssicurazione.Text,
                                                                   eui_txtCostoMora.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_txtTotaleOreGiorni_TextChanged(sender As Object, e As EventArgs) Handles eui_txtTotaleOreGiorni.TextChanged
      Try
         eui_txtTotaleImporto.Text = CalcolaCostoTotaleNoleggio(eui_txtTotaleOreGiorni.Text,
                                                                   eui_txtCostoGiorno.Text,
                                                                   eui_txtSconto.Text,
                                                                   eui_txtCostoAssicurazione.Text,
                                                                   eui_txtCostoMora.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdInserisciAllegato_Click(sender As Object, e As EventArgs) Handles eui_cmdInserisciAllegato.Click
      Try
         If ImpostaDatiAllegati(String.Empty, True) = True Then
            IAllegati.InserisciDati(TAB_ALLEGATI)
            ConvalidaAllegati()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdModificaAllegato_Click(sender As Object, e As EventArgs) Handles eui_cmdModificaAllegato.Click
      Try
         eui_cmdInserisciAllegato.NotifyDefault(False)

         With IAllegati
            .Documento = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(0).Text
            .Data = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(1).Text
            .Ora = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(2).Text
            .Note = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(3).Text
            .Percorso = lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(4).Text

            If ImpostaDatiAllegati(.Note, False) = True Then
               .ModificaDati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
               ConvalidaAllegati()
            End If
         End With

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Try

   End Sub

   Private Sub eui_cmdRimuoviAllegato_Click(sender As Object, e As EventArgs) Handles eui_cmdRimuoviAllegato.Click
      Try
         eui_cmdInserisciAllegato.NotifyDefault(False)

         RimuoviAllegati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
         ConvalidaAllegati()

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Try

   End Sub

   Private Sub eui_cmdApriDocAllegato_Click(sender As Object, e As EventArgs) Handles eui_cmdApriDocAllegato.Click
      ApriDocumentoAllegato()
   End Sub

   Private Sub eui_cmbCausale_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbCausale.SelectedIndexChanged
      Try
         eui_cmbIdCausale.SelectedIndex = eui_cmbCausale.SelectedIndex

         With CCausaliNoleggio
            .LeggiDati(TAB_CAUSALI_NOLEGGIO, eui_cmbIdCausale.Text)

            ' Assegna i dati dei campi della classe alle caselle di testo.
            eui_txtCostoGiorno.Text = CFormatta.FormattaNumeroDouble(.CostoGiorno)
            eui_txtCostoMora.Text = CFormatta.FormattaNumeroDouble(.CostoMora)
            eui_txtCostoAssicurazione.Text = CFormatta.FormattaNumeroDouble(.CostoAssicurazione)
         End With

         ' Carica la lista degli Articoli Noleggiati.
         CaricaElencoArticoliCausali(lstvElencoArticoli, TAB_DETTAGLI_CAUSALI_NOLEGGIO, CCausaliNoleggio.Codice)


         eui_txtTotaleImporto.Text = CalcolaCostoTotaleNoleggio(eui_txtTotaleOreGiorni.Text,
                                                                   eui_txtCostoGiorno.Text,
                                                                   eui_txtSconto.Text,
                                                                   eui_txtCostoAssicurazione.Text,
                                                                   eui_txtCostoMora.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

End Class
