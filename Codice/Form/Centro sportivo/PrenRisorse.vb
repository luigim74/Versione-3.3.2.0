' Nome form:            frmPrenotazioni
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 28/02/2006
' Descrizione:          Scheda prenotazione risorse.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmPrenRisorse
   Inherits System.Windows.Forms.Form

   Public IPren As New PrenRisorse
   Public IPrenConto As New PrenRisorseConto
   Public IStatVendita As New StatVendita
   Public IStat As New StatGioco

   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   Const TAB_DOC As String = "Documenti"
   Const TAB_DETTAGLI_DOC As String = "DettagliDoc"
   Const TAB_AZIENDA As String = "Azienda"

   Const TIPO_DOC_RF As String = "Ricevuta Fiscale"
   Const TIPO_DOC_FF As String = "Fattura"
   Const TIPO_DOC_SF As String = "Scontrino"
   Const TIPO_DOC_PF As String = "Proforma"

   Dim Doc As New Documenti
   Dim DocSalvato As Boolean = False
   Public percorsoRep As String = PERCORSO_REP_RF_A4_DOPPIA
   Dim tipoDocumento As String = TIPO_DOC_RF

   ' DA_FARE_B: VER. FUTURA.
   'Public IAllegati As New Allegati

   Const ALTEZZA_CELLE As Short = 40

   Const TAB_STATO_PREN As String = "StatoPrenotazione"
   Const TAB_STAT As String = "StatisticheGioco"
   Const TAB_STAT_VENDITA As String = "StatisticheRisorse"
   Const TAB_PREN_CONTO As String = "PrenRisorseConto"
   Const TAB_PAGAMENTO As String = "ModPagamento"
   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_RISORSE As String = "Risorse"
   Const ANA_CARATT_RISORSE As String = "CaratteristicheRisorse"

   ' B_TODO: VER. FUTURA.
   'Const TAB_ALLEGATI As String = "Allegati"
   Const NOME_TABELLA As String = "PrenRisorse"
   Const MEZZA_ORA As Short = 30
   'Dim MinPrenotati As Short = 0
   Dim Ora As String
   Dim Risorsa As String
   Dim Data As String

   Dim OraInizio, OraFine As String
   Dim valSconto As Double

   Dim TipoPlanningSport As Short
   Dim nomePlanning As String

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
   Friend WithEvents DropDown2 As Elegant.Ui.DropDown
   Friend WithEvents DropDown1 As Elegant.Ui.DropDown
   Friend WithEvents eui_cmdEliminaRiga As Elegant.Ui.Button
   Friend WithEvents lvwConto As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents PopupMenu1 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdAccessori As Elegant.Ui.Button
   Friend WithEvents Separator1 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdApriPos As Elegant.Ui.Button
   Friend WithEvents PopupMenu2 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdStampaDocPF As Elegant.Ui.Button
   Friend WithEvents Separator2 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdStampaDocRF As Elegant.Ui.Button
   Friend WithEvents eui_cmdStampaDocFF As Elegant.Ui.Button
   Friend WithEvents Separator3 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdStampaDocSF As Elegant.Ui.Button
   Public WithEvents txtTotale As System.Windows.Forms.TextBox
   Public WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents cmbPagato As System.Windows.Forms.ComboBox
   Public WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents eui_cmdServizi As Elegant.Ui.Button
   Friend WithEvents eui_QuantitàMeno As Elegant.Ui.Button
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents Separator4 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdStampaPos As Elegant.Ui.Button
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents cmbCaratteristiche As System.Windows.Forms.ComboBox
   Public WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents cmbScontoCliente As System.Windows.Forms.ComboBox
   Friend WithEvents txtSconto As System.Windows.Forms.TextBox
   Public WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents cmbApplicaSconto As System.Windows.Forms.ComboBox
   Public WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents cmbPagamento As System.Windows.Forms.ComboBox
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents txtIva As System.Windows.Forms.TextBox
   Friend WithEvents eui_cmdQuantitàPiù As Elegant.Ui.Button

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(Optional ByVal pData As String = "", Optional ByVal pRisorsa As String = "", Optional ByVal pOra As String = "")
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

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

   'NOTE: la procedura che segue è richiesta da Progettazione Windows Form.
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
   Public WithEvents Label34 As System.Windows.Forms.Label
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
   Friend WithEvents cmbStatoPren As System.Windows.Forms.ComboBox
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents cmbCliente As System.Windows.Forms.ComboBox
   Friend WithEvents cmbRisorsa As System.Windows.Forms.ComboBox
   Public WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents cmbOraInizio As System.Windows.Forms.ComboBox
   Friend WithEvents cmbOraFine As System.Windows.Forms.ComboBox
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Friend WithEvents cmbGiocatore2 As System.Windows.Forms.ComboBox
   Public WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents cmbGiocatore3 As System.Windows.Forms.ComboBox
   Public WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents cmbGiocatore4 As System.Windows.Forms.ComboBox
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents cmbIdGiocatore4 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbIdGiocatore3 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbIdGiocatore2 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbIdCliente As System.Windows.Forms.ComboBox
   Public WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents dtpScadenza As System.Windows.Forms.DateTimePicker
   Public WithEvents txtOre As System.Windows.Forms.TextBox
   Public WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents txtCostoRisorsa As System.Windows.Forms.TextBox
   Public WithEvents Label14 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrenRisorse))
      Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Articoli vari", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Accessori", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Servizi", System.Windows.Forms.HorizontalAlignment.Left)
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.txtIva = New System.Windows.Forms.TextBox()
      Me.cmbCaratteristiche = New System.Windows.Forms.ComboBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.txtOre = New System.Windows.Forms.TextBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.txtCostoRisorsa = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.dtpScadenza = New System.Windows.Forms.DateTimePicker()
      Me.cmbOraFine = New System.Windows.Forms.ComboBox()
      Me.cmbOraInizio = New System.Windows.Forms.ComboBox()
      Me.cmbRisorsa = New System.Windows.Forms.ComboBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.cmbCliente = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.cmdColore = New System.Windows.Forms.Button()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cmbStatoPren = New System.Windows.Forms.ComboBox()
      Me.txtNumero = New System.Windows.Forms.TextBox()
      Me.Label34 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.cmbScontoCliente = New System.Windows.Forms.ComboBox()
      Me.cmbIdCliente = New System.Windows.Forms.ComboBox()
      Me.cmbIdGiocatore4 = New System.Windows.Forms.ComboBox()
      Me.cmbIdGiocatore3 = New System.Windows.Forms.ComboBox()
      Me.cmbIdGiocatore2 = New System.Windows.Forms.ComboBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.cmbGiocatore4 = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.cmbGiocatore3 = New System.Windows.Forms.ComboBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmbGiocatore2 = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.TabPage3 = New System.Windows.Forms.TabPage()
      Me.cmbPagamento = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.txtSconto = New System.Windows.Forms.TextBox()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.cmbApplicaSconto = New System.Windows.Forms.ComboBox()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.eui_QuantitàMeno = New Elegant.Ui.Button()
      Me.eui_cmdQuantitàPiù = New Elegant.Ui.Button()
      Me.txtTotale = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.cmbPagato = New System.Windows.Forms.ComboBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.DropDown2 = New Elegant.Ui.DropDown()
      Me.PopupMenu2 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdStampaDocPF = New Elegant.Ui.Button()
      Me.Separator2 = New Elegant.Ui.Separator()
      Me.eui_cmdStampaDocRF = New Elegant.Ui.Button()
      Me.eui_cmdStampaDocFF = New Elegant.Ui.Button()
      Me.Separator3 = New Elegant.Ui.Separator()
      Me.eui_cmdStampaDocSF = New Elegant.Ui.Button()
      Me.Separator4 = New Elegant.Ui.Separator()
      Me.eui_cmdStampaPos = New Elegant.Ui.Button()
      Me.DropDown1 = New Elegant.Ui.DropDown()
      Me.PopupMenu1 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdAccessori = New Elegant.Ui.Button()
      Me.eui_cmdServizi = New Elegant.Ui.Button()
      Me.Separator1 = New Elegant.Ui.Separator()
      Me.eui_cmdApriPos = New Elegant.Ui.Button()
      Me.eui_cmdEliminaRiga = New Elegant.Ui.Button()
      Me.lvwConto = New System.Windows.Forms.ListView()
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TabPage6 = New System.Windows.Forms.TabPage()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.Panel1.SuspendLayout()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      Me.TabPage2.SuspendLayout()
      Me.TabPage3.SuspendLayout()
      CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.ToolBar1.Size = New System.Drawing.Size(596, 26)
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
      Me.Panel1.Size = New System.Drawing.Size(596, 20)
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
      Me.TabControl1.Controls.Add(Me.TabPage2)
      Me.TabControl1.Controls.Add(Me.TabPage3)
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(596, 391)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.txtIva)
      Me.TabPage1.Controls.Add(Me.cmbCaratteristiche)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.txtOre)
      Me.TabPage1.Controls.Add(Me.Label17)
      Me.TabPage1.Controls.Add(Me.txtCostoRisorsa)
      Me.TabPage1.Controls.Add(Me.Label14)
      Me.TabPage1.Controls.Add(Me.Label15)
      Me.TabPage1.Controls.Add(Me.dtpScadenza)
      Me.TabPage1.Controls.Add(Me.cmbOraFine)
      Me.TabPage1.Controls.Add(Me.cmbOraInizio)
      Me.TabPage1.Controls.Add(Me.cmbRisorsa)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.cmbCliente)
      Me.TabPage1.Controls.Add(Me.Label2)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.dtpData)
      Me.TabPage1.Controls.Add(Me.cmdColore)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.cmbStatoPren)
      Me.TabPage1.Controls.Add(Me.txtNumero)
      Me.TabPage1.Controls.Add(Me.Label34)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.ForeColor = System.Drawing.Color.Black
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(588, 365)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'txtIva
      '
      Me.txtIva.AcceptsReturn = True
      Me.txtIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIva.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtIva.Location = New System.Drawing.Point(440, 264)
      Me.txtIva.MaxLength = 0
      Me.txtIva.Name = "txtIva"
      Me.txtIva.ReadOnly = True
      Me.txtIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIva.Size = New System.Drawing.Size(64, 20)
      Me.txtIva.TabIndex = 242
      Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtIva.Visible = False
      '
      'cmbCaratteristiche
      '
      Me.cmbCaratteristiche.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCaratteristiche.Location = New System.Drawing.Point(136, 160)
      Me.cmbCaratteristiche.Name = "cmbCaratteristiche"
      Me.cmbCaratteristiche.Size = New System.Drawing.Size(368, 21)
      Me.cmbCaratteristiche.TabIndex = 5
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(24, 160)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(98, 13)
      Me.Label12.TabIndex = 241
      Me.Label12.Text = "Tipologia di utilizzo:"
      '
      'txtOre
      '
      Me.txtOre.AcceptsReturn = True
      Me.txtOre.BackColor = System.Drawing.SystemColors.Window
      Me.txtOre.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtOre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtOre.ForeColor = System.Drawing.SystemColors.ControlText
      Me.txtOre.Location = New System.Drawing.Point(440, 200)
      Me.txtOre.MaxLength = 0
      Me.txtOre.Name = "txtOre"
      Me.txtOre.ReadOnly = True
      Me.txtOre.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtOre.Size = New System.Drawing.Size(64, 20)
      Me.txtOre.TabIndex = 8
      Me.txtOre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(352, 200)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(75, 13)
      Me.Label17.TabIndex = 235
      Me.Label17.Text = "Ore prenotate:"
      '
      'txtCostoRisorsa
      '
      Me.txtCostoRisorsa.ForeColor = System.Drawing.Color.Red
      Me.txtCostoRisorsa.Location = New System.Drawing.Point(440, 128)
      Me.txtCostoRisorsa.MaxLength = 0
      Me.txtCostoRisorsa.Name = "txtCostoRisorsa"
      Me.txtCostoRisorsa.Size = New System.Drawing.Size(64, 20)
      Me.txtCostoRisorsa.TabIndex = 4
      Me.txtCostoRisorsa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(352, 128)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(70, 13)
      Me.Label14.TabIndex = 232
      Me.Label14.Text = "Costo risorsa:"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.BackColor = System.Drawing.Color.Transparent
      Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label15.ForeColor = System.Drawing.Color.Black
      Me.Label15.Location = New System.Drawing.Point(24, 264)
      Me.Label15.Name = "Label15"
      Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label15.Size = New System.Drawing.Size(58, 13)
      Me.Label15.TabIndex = 212
      Me.Label15.Text = "Scadenza:"
      '
      'dtpScadenza
      '
      Me.dtpScadenza.Location = New System.Drawing.Point(136, 264)
      Me.dtpScadenza.Name = "dtpScadenza"
      Me.dtpScadenza.Size = New System.Drawing.Size(200, 20)
      Me.dtpScadenza.TabIndex = 10
      '
      'cmbOraFine
      '
      Me.cmbOraFine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbOraFine.Location = New System.Drawing.Point(264, 200)
      Me.cmbOraFine.Name = "cmbOraFine"
      Me.cmbOraFine.Size = New System.Drawing.Size(72, 21)
      Me.cmbOraFine.TabIndex = 7
      '
      'cmbOraInizio
      '
      Me.cmbOraInizio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbOraInizio.Location = New System.Drawing.Point(136, 200)
      Me.cmbOraInizio.Name = "cmbOraInizio"
      Me.cmbOraInizio.Size = New System.Drawing.Size(72, 21)
      Me.cmbOraInizio.TabIndex = 6
      '
      'cmbRisorsa
      '
      Me.cmbRisorsa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRisorsa.Location = New System.Drawing.Point(136, 128)
      Me.cmbRisorsa.Name = "cmbRisorsa"
      Me.cmbRisorsa.Size = New System.Drawing.Size(200, 21)
      Me.cmbRisorsa.TabIndex = 3
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(24, 128)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(45, 13)
      Me.Label3.TabIndex = 199
      Me.Label3.Text = "Risorsa:"
      '
      'cmbCliente
      '
      Me.cmbCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCliente.Location = New System.Drawing.Point(136, 88)
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
      Me.Label2.Location = New System.Drawing.Point(216, 200)
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
      Me.dtpData.Location = New System.Drawing.Point(136, 56)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(200, 20)
      Me.dtpData.TabIndex = 1
      '
      'cmdColore
      '
      Me.cmdColore.BackColor = System.Drawing.Color.White
      Me.cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColore.Location = New System.Drawing.Point(416, 56)
      Me.cmdColore.Name = "cmdColore"
      Me.cmdColore.Size = New System.Drawing.Size(88, 19)
      Me.cmdColore.TabIndex = 11
      Me.cmdColore.TabStop = False
      Me.cmdColore.UseVisualStyleBackColor = False
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(352, 56)
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
      Me.Label6.Location = New System.Drawing.Point(24, 200)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(52, 13)
      Me.Label6.TabIndex = 191
      Me.Label6.Text = "Dalle ore:"
      '
      'cmbStatoPren
      '
      Me.cmbStatoPren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatoPren.Location = New System.Drawing.Point(136, 232)
      Me.cmbStatoPren.Name = "cmbStatoPren"
      Me.cmbStatoPren.Size = New System.Drawing.Size(200, 21)
      Me.cmbStatoPren.TabIndex = 9
      '
      'txtNumero
      '
      Me.txtNumero.AcceptsReturn = True
      Me.txtNumero.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumero.ForeColor = System.Drawing.Color.Red
      Me.txtNumero.Location = New System.Drawing.Point(136, 24)
      Me.txtNumero.MaxLength = 0
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.ReadOnly = True
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(120, 20)
      Me.txtNumero.TabIndex = 0
      Me.txtNumero.TabStop = False
      Me.txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label34
      '
      Me.Label34.AutoSize = True
      Me.Label34.BackColor = System.Drawing.Color.Transparent
      Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label34.ForeColor = System.Drawing.Color.Black
      Me.Label34.Location = New System.Drawing.Point(24, 232)
      Me.Label34.Name = "Label34"
      Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label34.Size = New System.Drawing.Size(99, 13)
      Me.Label34.TabIndex = 171
      Me.Label34.Text = "Stato prenotazione:"
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
      Me.Label20.Size = New System.Drawing.Size(62, 13)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Intestatario:"
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage2.Controls.Add(Me.cmbScontoCliente)
      Me.TabPage2.Controls.Add(Me.cmbIdCliente)
      Me.TabPage2.Controls.Add(Me.cmbIdGiocatore4)
      Me.TabPage2.Controls.Add(Me.cmbIdGiocatore3)
      Me.TabPage2.Controls.Add(Me.cmbIdGiocatore2)
      Me.TabPage2.Controls.Add(Me.Label10)
      Me.TabPage2.Controls.Add(Me.cmbGiocatore4)
      Me.TabPage2.Controls.Add(Me.Label9)
      Me.TabPage2.Controls.Add(Me.cmbGiocatore3)
      Me.TabPage2.Controls.Add(Me.Label7)
      Me.TabPage2.Controls.Add(Me.cmbGiocatore2)
      Me.TabPage2.Controls.Add(Me.Label4)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(588, 365)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Altri componenti"
      '
      'cmbScontoCliente
      '
      Me.cmbScontoCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbScontoCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbScontoCliente.Location = New System.Drawing.Point(280, 160)
      Me.cmbScontoCliente.Name = "cmbScontoCliente"
      Me.cmbScontoCliente.Size = New System.Drawing.Size(104, 21)
      Me.cmbScontoCliente.TabIndex = 177
      Me.cmbScontoCliente.Visible = False
      '
      'cmbIdCliente
      '
      Me.cmbIdCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbIdCliente.Location = New System.Drawing.Point(392, 160)
      Me.cmbIdCliente.Name = "cmbIdCliente"
      Me.cmbIdCliente.Size = New System.Drawing.Size(104, 21)
      Me.cmbIdCliente.TabIndex = 176
      Me.cmbIdCliente.Visible = False
      '
      'cmbIdGiocatore4
      '
      Me.cmbIdGiocatore4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdGiocatore4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbIdGiocatore4.Location = New System.Drawing.Point(392, 256)
      Me.cmbIdGiocatore4.Name = "cmbIdGiocatore4"
      Me.cmbIdGiocatore4.Size = New System.Drawing.Size(104, 21)
      Me.cmbIdGiocatore4.TabIndex = 175
      Me.cmbIdGiocatore4.Visible = False
      '
      'cmbIdGiocatore3
      '
      Me.cmbIdGiocatore3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdGiocatore3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbIdGiocatore3.Location = New System.Drawing.Point(392, 224)
      Me.cmbIdGiocatore3.Name = "cmbIdGiocatore3"
      Me.cmbIdGiocatore3.Size = New System.Drawing.Size(104, 21)
      Me.cmbIdGiocatore3.TabIndex = 174
      Me.cmbIdGiocatore3.Visible = False
      '
      'cmbIdGiocatore2
      '
      Me.cmbIdGiocatore2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdGiocatore2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbIdGiocatore2.Location = New System.Drawing.Point(392, 192)
      Me.cmbIdGiocatore2.Name = "cmbIdGiocatore2"
      Me.cmbIdGiocatore2.Size = New System.Drawing.Size(104, 21)
      Me.cmbIdGiocatore2.TabIndex = 173
      Me.cmbIdGiocatore2.Visible = False
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(24, 24)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(316, 13)
      Me.Label10.TabIndex = 172
      Me.Label10.Text = "Inserire eventuali giocatori per le prenotazioni dei campi da tennis."
      '
      'cmbGiocatore4
      '
      Me.cmbGiocatore4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbGiocatore4.Location = New System.Drawing.Point(128, 120)
      Me.cmbGiocatore4.Name = "cmbGiocatore4"
      Me.cmbGiocatore4.Size = New System.Drawing.Size(368, 21)
      Me.cmbGiocatore4.TabIndex = 2
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(24, 120)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(89, 13)
      Me.Label9.TabIndex = 159
      Me.Label9.Text = "Quarto giocatore:"
      '
      'cmbGiocatore3
      '
      Me.cmbGiocatore3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbGiocatore3.Location = New System.Drawing.Point(128, 88)
      Me.cmbGiocatore3.Name = "cmbGiocatore3"
      Me.cmbGiocatore3.Size = New System.Drawing.Size(368, 21)
      Me.cmbGiocatore3.TabIndex = 1
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(24, 88)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(84, 13)
      Me.Label7.TabIndex = 157
      Me.Label7.Text = "Terzo giocatore:"
      '
      'cmbGiocatore2
      '
      Me.cmbGiocatore2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbGiocatore2.Location = New System.Drawing.Point(128, 56)
      Me.cmbGiocatore2.Name = "cmbGiocatore2"
      Me.cmbGiocatore2.Size = New System.Drawing.Size(368, 21)
      Me.cmbGiocatore2.TabIndex = 0
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(24, 56)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(100, 13)
      Me.Label4.TabIndex = 155
      Me.Label4.Text = "Secondo giocatore:"
      '
      'TabPage3
      '
      Me.TabPage3.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage3.Controls.Add(Me.cmbPagamento)
      Me.TabPage3.Controls.Add(Me.Label13)
      Me.TabPage3.Controls.Add(Me.txtSconto)
      Me.TabPage3.Controls.Add(Me.Label18)
      Me.TabPage3.Controls.Add(Me.cmbApplicaSconto)
      Me.TabPage3.Controls.Add(Me.Label19)
      Me.TabPage3.Controls.Add(Me.eui_QuantitàMeno)
      Me.TabPage3.Controls.Add(Me.eui_cmdQuantitàPiù)
      Me.TabPage3.Controls.Add(Me.txtTotale)
      Me.TabPage3.Controls.Add(Me.Label16)
      Me.TabPage3.Controls.Add(Me.cmbPagato)
      Me.TabPage3.Controls.Add(Me.Label11)
      Me.TabPage3.Controls.Add(Me.DropDown2)
      Me.TabPage3.Controls.Add(Me.DropDown1)
      Me.TabPage3.Controls.Add(Me.eui_cmdEliminaRiga)
      Me.TabPage3.Controls.Add(Me.lvwConto)
      Me.TabPage3.Location = New System.Drawing.Point(4, 22)
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(588, 365)
      Me.TabPage3.TabIndex = 7
      Me.TabPage3.Text = "Gestione conto"
      '
      'cmbPagamento
      '
      Me.cmbPagamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPagamento.Location = New System.Drawing.Point(424, 24)
      Me.cmbPagamento.Name = "cmbPagamento"
      Me.cmbPagamento.Size = New System.Drawing.Size(152, 21)
      Me.cmbPagamento.TabIndex = 0
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(424, 8)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(106, 13)
      Me.Label13.TabIndex = 246
      Me.Label13.Text = "Modalità pagamento:"
      '
      'txtSconto
      '
      Me.txtSconto.ForeColor = System.Drawing.Color.Black
      Me.txtSconto.Location = New System.Drawing.Point(496, 96)
      Me.txtSconto.MaxLength = 0
      Me.txtSconto.Name = "txtSconto"
      Me.txtSconto.Size = New System.Drawing.Size(80, 20)
      Me.txtSconto.TabIndex = 2
      Me.txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.ForeColor = System.Drawing.Color.Black
      Me.Label18.Location = New System.Drawing.Point(424, 96)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(44, 13)
      Me.Label18.TabIndex = 244
      Me.Label18.Text = "Sconto:"
      '
      'cmbApplicaSconto
      '
      Me.cmbApplicaSconto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbApplicaSconto.Items.AddRange(New Object() {"Sul costo della Risorsa", "Sul totale del conto"})
      Me.cmbApplicaSconto.Location = New System.Drawing.Point(424, 64)
      Me.cmbApplicaSconto.Name = "cmbApplicaSconto"
      Me.cmbApplicaSconto.Size = New System.Drawing.Size(152, 21)
      Me.cmbApplicaSconto.TabIndex = 1
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(424, 48)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(80, 13)
      Me.Label19.TabIndex = 242
      Me.Label19.Text = "Applica sconto:"
      '
      'eui_QuantitàMeno
      '
      Me.eui_QuantitàMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_QuantitàMeno.Id = "7ddb0454-456a-4157-b997-ee0142d09efc"
      Me.eui_QuantitàMeno.Location = New System.Drawing.Point(504, 200)
      Me.eui_QuantitàMeno.Name = "eui_QuantitàMeno"
      Me.eui_QuantitàMeno.Size = New System.Drawing.Size(72, 32)
      Me.eui_QuantitàMeno.TabIndex = 6
      Me.eui_QuantitàMeno.Text = "-"
      '
      'eui_cmdQuantitàPiù
      '
      Me.eui_cmdQuantitàPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdQuantitàPiù.Id = "a4051c7a-bb82-4e29-98d3-baf5c1ba0f35"
      Me.eui_cmdQuantitàPiù.Location = New System.Drawing.Point(424, 200)
      Me.eui_cmdQuantitàPiù.Name = "eui_cmdQuantitàPiù"
      Me.eui_cmdQuantitàPiù.Size = New System.Drawing.Size(72, 32)
      Me.eui_cmdQuantitàPiù.TabIndex = 5
      Me.eui_cmdQuantitàPiù.Text = "+"
      '
      'txtTotale
      '
      Me.txtTotale.AcceptsReturn = True
      Me.txtTotale.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotale.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotale.ForeColor = System.Drawing.Color.Red
      Me.txtTotale.Location = New System.Drawing.Point(496, 128)
      Me.txtTotale.MaxLength = 0
      Me.txtTotale.Name = "txtTotale"
      Me.txtTotale.ReadOnly = True
      Me.txtTotale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotale.Size = New System.Drawing.Size(80, 20)
      Me.txtTotale.TabIndex = 3
      Me.txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(424, 131)
      Me.Label16.Name = "Label16"
      Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label16.Size = New System.Drawing.Size(65, 13)
      Me.Label16.TabIndex = 237
      Me.Label16.Text = "Totale Euro:"
      '
      'cmbPagato
      '
      Me.cmbPagato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbPagato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbPagato.Items.AddRange(New Object() {"Sì", "No"})
      Me.cmbPagato.Location = New System.Drawing.Point(496, 160)
      Me.cmbPagato.Name = "cmbPagato"
      Me.cmbPagato.Size = New System.Drawing.Size(80, 21)
      Me.cmbPagato.TabIndex = 4
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(424, 160)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(44, 13)
      Me.Label11.TabIndex = 235
      Me.Label11.Text = "Pagato:"
      '
      'DropDown2
      '
      Me.DropDown2.Id = "e1a4a3aa-756d-4dd7-a825-64cb625b1329"
      Me.DropDown2.Location = New System.Drawing.Point(424, 320)
      Me.DropDown2.Name = "DropDown2"
      Me.DropDown2.Popup = Me.PopupMenu2
      Me.DropDown2.Size = New System.Drawing.Size(152, 35)
      Me.DropDown2.TabIndex = 9
      Me.DropDown2.Text = "&Stampa documento"
      '
      'PopupMenu2
      '
      Me.PopupMenu2.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdStampaDocPF, Me.Separator2, Me.eui_cmdStampaDocRF, Me.eui_cmdStampaDocFF, Me.Separator3, Me.eui_cmdStampaDocSF, Me.Separator4, Me.eui_cmdStampaPos})
      Me.PopupMenu2.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu2.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu2.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdStampaDocPF
      '
      Me.eui_cmdStampaDocPF.Id = "00dbb5f1-a365-4575-8695-2ab9c82ed6e1"
      Me.eui_cmdStampaDocPF.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdStampaDocPF.Name = "eui_cmdStampaDocPF"
      Me.eui_cmdStampaDocPF.Size = New System.Drawing.Size(181, 23)
      Me.eui_cmdStampaDocPF.TabIndex = 3
      Me.eui_cmdStampaDocPF.Text = "&Proforma"
      '
      'Separator2
      '
      Me.Separator2.Id = "2e966542-fc56-4791-89d4-d817ae3e36ab"
      Me.Separator2.Location = New System.Drawing.Point(2, 25)
      Me.Separator2.Name = "Separator2"
      Me.Separator2.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator2.Size = New System.Drawing.Size(181, 5)
      Me.Separator2.TabIndex = 7
      Me.Separator2.Text = "Separator2"
      '
      'eui_cmdStampaDocRF
      '
      Me.eui_cmdStampaDocRF.Id = "a8c335c8-97ac-4228-a4d2-89f86b712b47"
      Me.eui_cmdStampaDocRF.Location = New System.Drawing.Point(2, 30)
      Me.eui_cmdStampaDocRF.Name = "eui_cmdStampaDocRF"
      Me.eui_cmdStampaDocRF.Size = New System.Drawing.Size(181, 23)
      Me.eui_cmdStampaDocRF.TabIndex = 4
      Me.eui_cmdStampaDocRF.Text = "&Ricevuta fiscale"
      '
      'eui_cmdStampaDocFF
      '
      Me.eui_cmdStampaDocFF.Id = "a1cb9a2c-b357-4e65-96c0-ddb70659d8f5"
      Me.eui_cmdStampaDocFF.Location = New System.Drawing.Point(2, 53)
      Me.eui_cmdStampaDocFF.Name = "eui_cmdStampaDocFF"
      Me.eui_cmdStampaDocFF.Size = New System.Drawing.Size(181, 23)
      Me.eui_cmdStampaDocFF.TabIndex = 5
      Me.eui_cmdStampaDocFF.Text = "&Fattura"
      '
      'Separator3
      '
      Me.Separator3.Id = "6ef89758-7f74-4407-a0c6-1b61a8e28ff5"
      Me.Separator3.Location = New System.Drawing.Point(2, 76)
      Me.Separator3.Name = "Separator3"
      Me.Separator3.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator3.Size = New System.Drawing.Size(181, 5)
      Me.Separator3.TabIndex = 8
      Me.Separator3.Text = "Separator3"
      '
      'eui_cmdStampaDocSF
      '
      Me.eui_cmdStampaDocSF.Id = "f57b38ce-85f2-4ce1-9bbc-a2dc77aea63d"
      Me.eui_cmdStampaDocSF.Location = New System.Drawing.Point(2, 81)
      Me.eui_cmdStampaDocSF.Name = "eui_cmdStampaDocSF"
      Me.eui_cmdStampaDocSF.Size = New System.Drawing.Size(181, 23)
      Me.eui_cmdStampaDocSF.TabIndex = 6
      Me.eui_cmdStampaDocSF.Text = "S&contrino"
      '
      'Separator4
      '
      Me.Separator4.Id = "a48e2695-3842-4ee1-a297-5b50b8420ff7"
      Me.Separator4.Location = New System.Drawing.Point(2, 104)
      Me.Separator4.Name = "Separator4"
      Me.Separator4.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator4.Size = New System.Drawing.Size(181, 5)
      Me.Separator4.TabIndex = 10
      Me.Separator4.Text = "Separator4"
      '
      'eui_cmdStampaPos
      '
      Me.eui_cmdStampaPos.Enabled = False
      Me.eui_cmdStampaPos.Id = "b21910b8-a43b-4559-98bc-3cbddeca03e7"
      Me.eui_cmdStampaPos.Location = New System.Drawing.Point(2, 109)
      Me.eui_cmdStampaPos.Name = "eui_cmdStampaPos"
      Me.eui_cmdStampaPos.Size = New System.Drawing.Size(181, 23)
      Me.eui_cmdStampaPos.TabIndex = 11
      Me.eui_cmdStampaPos.Text = "S&tampa da Punto cassa"
      '
      'DropDown1
      '
      Me.DropDown1.Id = "17929c68-21dd-41c4-85c4-f6da6176d755"
      Me.DropDown1.Location = New System.Drawing.Point(424, 240)
      Me.DropDown1.Name = "DropDown1"
      Me.DropDown1.Popup = Me.PopupMenu1
      Me.DropDown1.Size = New System.Drawing.Size(152, 32)
      Me.DropDown1.TabIndex = 7
      Me.DropDown1.Text = "&Inserisci"
      '
      'PopupMenu1
      '
      Me.PopupMenu1.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdAccessori, Me.eui_cmdServizi, Me.Separator1, Me.eui_cmdApriPos})
      Me.PopupMenu1.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu1.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdAccessori
      '
      Me.eui_cmdAccessori.Id = "b822c091-f60a-4f8d-9c4d-a04b7f5e16e2"
      Me.eui_cmdAccessori.KeyTip = "A"
      Me.eui_cmdAccessori.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdAccessori.Name = "eui_cmdAccessori"
      Me.eui_cmdAccessori.ScreenTip.Caption = "Accessori"
      Me.eui_cmdAccessori.ScreenTip.Text = "Apre un'elenco per l'inserimento degli accessori."
      Me.eui_cmdAccessori.Size = New System.Drawing.Size(149, 23)
      Me.eui_cmdAccessori.TabIndex = 3
      Me.eui_cmdAccessori.Text = "&Accessori"
      '
      'eui_cmdServizi
      '
      Me.eui_cmdServizi.Id = "497cace7-5d26-4be4-acd5-c6373adfd58e"
      Me.eui_cmdServizi.KeyTip = "S"
      Me.eui_cmdServizi.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdServizi.Name = "eui_cmdServizi"
      Me.eui_cmdServizi.ScreenTip.Caption = "Servizi"
      Me.eui_cmdServizi.ScreenTip.Text = "Apre un'elenco per l'inserimento dei servizi."
      Me.eui_cmdServizi.Size = New System.Drawing.Size(149, 23)
      Me.eui_cmdServizi.TabIndex = 7
      Me.eui_cmdServizi.Text = "&Servizi"
      '
      'Separator1
      '
      Me.Separator1.Id = "bfd7c152-8453-4088-ac46-a4c3e9d61b96"
      Me.Separator1.Location = New System.Drawing.Point(2, 48)
      Me.Separator1.Name = "Separator1"
      Me.Separator1.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator1.Size = New System.Drawing.Size(149, 5)
      Me.Separator1.TabIndex = 5
      Me.Separator1.Text = "Separator1"
      '
      'eui_cmdApriPos
      '
      Me.eui_cmdApriPos.Enabled = False
      Me.eui_cmdApriPos.Id = "c61d05a8-dddf-42a3-b1c0-478e0e86188a"
      Me.eui_cmdApriPos.KeyTip = "P"
      Me.eui_cmdApriPos.Location = New System.Drawing.Point(2, 53)
      Me.eui_cmdApriPos.Name = "eui_cmdApriPos"
      Me.eui_cmdApriPos.ScreenTip.Caption = "Apri Punto cassa"
      Me.eui_cmdApriPos.ScreenTip.Text = "Apre il Punto cassa per l'inserimento di prodotti vari."
      Me.eui_cmdApriPos.Size = New System.Drawing.Size(149, 23)
      Me.eui_cmdApriPos.TabIndex = 4
      Me.eui_cmdApriPos.Text = "Apri &Punto Cassa"
      '
      'eui_cmdEliminaRiga
      '
      Me.eui_cmdEliminaRiga.Id = "f5df8945-aa06-4649-81eb-266957eb6304"
      Me.eui_cmdEliminaRiga.Location = New System.Drawing.Point(424, 280)
      Me.eui_cmdEliminaRiga.Name = "eui_cmdEliminaRiga"
      Me.eui_cmdEliminaRiga.Size = New System.Drawing.Size(152, 32)
      Me.eui_cmdEliminaRiga.TabIndex = 8
      Me.eui_cmdEliminaRiga.Text = "&Elimina riga"
      '
      'lvwConto
      '
      Me.lvwConto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader2, Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader4})
      Me.lvwConto.Dock = System.Windows.Forms.DockStyle.Left
      Me.lvwConto.FullRowSelect = True
      ListViewGroup1.Header = "Articoli vari"
      ListViewGroup1.Name = "ListViewGroup4"
      ListViewGroup2.Header = "Accessori"
      ListViewGroup2.Name = "ListViewGroup2"
      ListViewGroup3.Header = "Servizi"
      ListViewGroup3.Name = "ListViewGroup3"
      Me.lvwConto.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3})
      Me.lvwConto.Location = New System.Drawing.Point(0, 0)
      Me.lvwConto.MultiSelect = False
      Me.lvwConto.Name = "lvwConto"
      Me.lvwConto.Size = New System.Drawing.Size(408, 365)
      Me.lvwConto.TabIndex = 10
      Me.lvwConto.UseCompatibleStateImageBehavior = False
      Me.lvwConto.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Descrizione"
      Me.ColumnHeader2.Width = 245
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Quantità"
      Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Importo"
      Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader3.Width = 80
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Text = "Indice"
      Me.ColumnHeader4.Width = 0
      '
      'TabPage6
      '
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(588, 365)
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
      Me.txtNote.Size = New System.Drawing.Size(588, 365)
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
      'frmPrenRisorse
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(596, 437)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPrenRisorse"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Prenotazione Risorsa sportiva"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' A_TODO: MODIFICHE ASD AGON
      Try
         ' Imposta le dimensioni standard del form.
         Me.Width = larghezza
         Me.Height = altezza

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Function SalvaDati(ByVal CordY As Integer, ByVal oraInizio As String, ByVal oraFine As String) As Boolean
      Try
         With IPren
            ' Assegna i dati dei campi della classe alle caselle di testo.
            ' Formato italiano.
            .Data = FormattaData(dtpData.Value, True)
            .Intestatario = cmbCliente.Text
            .Componente1 = cmbGiocatore2.Text
            .Componente2 = cmbGiocatore3.Text
            .Componente3 = cmbGiocatore4.Text
            .IdRisorsa = LeggiIdRisorsa(ANA_RISORSE, cmbRisorsa.Text)
            .DescrizioneRisorsa = cmbRisorsa.Text
            ' A_TODO: MODIFICHE ASD AGON
            .CaratteristicaRisorsa = cmbCaratteristiche.Text
            .CordY = CordY
            .Stato = cmbStatoPren.Text
            .OraInizio = oraInizio
            .OraFine = oraFine
            .Pagato = cmbPagato.Text

            If IsNumeric(txtCostoRisorsa.Text) Then
               .CostoRisorsa = CFormatta.FormattaEuro(txtCostoRisorsa.Text)
            Else
               .CostoRisorsa = 0
            End If
            If IsNumeric(txtTotale.Text) Then
               .Totale = CFormatta.FormattaEuro(txtTotale.Text)
            Else
               .Totale = 0
            End If

            .ScadenzaAbb = FormattaData(dtpScadenza.Value, True)
            ' A_TODO: MODIFICHE ASD AGON
            .ApplicaSconto = cmbApplicaSconto.SelectedIndex.ToString
            .Note = txtNote.Text

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

   Private Function SalvaDettagliConto(ByVal id As String) As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         Dim idPren As Integer

         If Me.Tag <> "" Then
            idPren = id
         Else
            idPren = LeggiUltimaPren(NOME_TABELLA)
         End If

         With IPrenConto
            .EliminaDati(TAB_PREN_CONTO, idPren)

            Dim i As Integer
            For i = 0 To lvwConto.Items.Count - 1
               .RifPren = idPren
               .Descrizione = lvwConto.Items(i).Text
               .Quantità = lvwConto.Items(i).SubItems(1).Text
               .Importo = lvwConto.Items(i).SubItems(2).Text
               .Colore = lvwConto.Items(i).ForeColor.ToArgb
               .Gruppo = lvwConto.Items(i).Group.ToString
               .InserisciDati(TAB_PREN_CONTO)
            Next

         End With

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub LeggiDettagliConto()
      Try
         With IPrenConto
            .LeggiDati(lvwConto, TAB_PREN_CONTO, Me.Tag)
         End With

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

         Do While dr.Read
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               Doc.Indirizzo = dr.Item("Indirizzo")
            Else
               Doc.Indirizzo = String.Empty
            End If
            If IsDBNull(dr.Item("Cap")) = False Then
               Doc.Cap = dr.Item("Cap")
            Else
               Doc.Cap = String.Empty
            End If
            If IsDBNull(dr.Item("Città")) = False Then
               Doc.Città = dr.Item("Città")
            Else
               Doc.Città = String.Empty
            End If
            If IsDBNull(dr.Item("Provincia")) = False Then
               Doc.Provincia = dr.Item("Provincia")
            Else
               Doc.Provincia = String.Empty
            End If
            If IsDBNull(dr.Item("PIva")) = False Then
               Doc.PIva = dr.Item("PIva")
            Else
               Doc.PIva = String.Empty
            End If
            If IsDBNull(dr.Item("CodFisc")) = False Then
               Doc.CodFiscale = dr.Item("CodFisc")
            Else
               Doc.CodFiscale = String.Empty
            End If
            If IsDBNull(dr.Item("Iva")) = False Then
               Doc.Iva = CFormatta.FormattaNumeroDouble(dr.Item("Iva"))
            Else
               If AliquotaIvaCentroSportivo <> String.Empty Then
                  Doc.Iva = CFormatta.FormattaEuro(AliquotaIvaCentroSportivo)
                  txtIva.Text = Doc.Iva
               Else
                  Doc.Iva = VALORE_ZERO
                  txtIva.Text = VALORE_ZERO
               End If
            End If
            If IsDBNull(dr.Item("Sconto")) = False Then
               Doc.Sconto = CFormatta.FormattaNumeroDouble(dr.Item("Sconto"))
            Else
               Doc.Sconto = VALORE_ZERO
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ImpostaDatiCliente()
      Try
         ' Imposta i dati dei clienti non presenti nell'anagafica per la stampa dei documenti fiscali.
         Doc.Indirizzo = String.Empty
         Doc.Cap = String.Empty
         Doc.Città = String.Empty
         Doc.Provincia = String.Empty
         Doc.PIva = String.Empty
         Doc.CodFiscale = String.Empty
         Doc.Sconto = VALORE_ZERO

         If AliquotaIvaCentroSportivo <> String.Empty Then
            Doc.Iva = CFormatta.FormattaEuro(AliquotaIvaCentroSportivo)
            txtIva.Text = Doc.Iva
         Else
            Doc.Iva = VALORE_ZERO
            txtIva.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function SalvaStatisticheVendita() As Boolean
      Try
         With IStatVendita
            ' Assegna i dati dei campi della classe alle caselle di testo.
            ' Formato italiano.
            .Data = FormattaData(dtpData.Value, True)
            .Intestatario = FormattaApici(cmbCliente.Text)
            .IdRisorsa = LeggiIdRisorsa(ANA_RISORSE, cmbRisorsa.Text)
            .DesRisorsa = FormattaApici(cmbRisorsa.Text)
            ' A_TODO: MODIFICHE ASD AGON
            .CaratteristicaRisorsa = FormattaApici(cmbCaratteristiche.Text)
            ' Verifica l'esistenza dei dati della prenotazione nella tabella Statistiche.
            Dim numRec As Integer = VerificaEsistenzaValore(TAB_STAT_VENDITA, cn, cmd, "IdPren", Me.Tag)

            If Me.Tag <> "" Then
               .IdPren = Me.Tag
            Else
               .IdPren = LeggiUltimaPren(NOME_TABELLA)
            End If

            .OraInizio = cmbOraInizio.Text
            .OraFine = cmbOraFine.Text
            .Quantità = CFormatta.FormattaNumeroDouble2(txtOre.Text)

            If IsNumeric(txtCostoRisorsa.Text) Then
               .CostoRisorsa = CFormatta.FormattaEuro(txtCostoRisorsa.Text)
            Else
               .CostoRisorsa = 0
            End If
            If IsNumeric(txtTotale.Text) Then
               .Importo = CFormatta.FormattaEuro(txtTotale.Text)
            Else
               .Importo = 0
            End If

            '  Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> "" Then
               If numRec <> 0 Then
                  Return .ModificaDati(TAB_STAT_VENDITA, Me.Tag)
               Else
                  Return .InserisciDati(TAB_STAT_VENDITA)
               End If
            Else
               Return .InserisciDati(TAB_STAT_VENDITA)
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub SalvaDatiStat(ByVal data As String, ByVal idCliente As String, ByVal idPartita As String, ByVal codice As String, ByVal minuti As Single)
      Try
         With IStat
            ' Assegna i dati dei campi della classe alle caselle di testo.

            .Data = data
            .IdCliente = idCliente
            .IdPartita = idPartita
            .Codice = codice
            .Minuti = minuti.ToString

            '  Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> "" Then
               '.EliminaDati(TAB_STAT, Me.Tag)
               .ModificaDati(TAB_STAT, Me.Tag)
            Else
               .InserisciDati(TAB_STAT)
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub LeggiNumGiocatori(ByVal idPartita As String)
      Try
         Dim i As Short = 0
         Dim numGiocatori As Short = 0
         Dim index As Integer
         Dim idGiocatore(3) As String

         If cmbCliente.Text <> "" Then
            index = cmbCliente.Items.IndexOf(cmbCliente.Text)
            If index >= 0 Then
               idGiocatore(numGiocatori) = cmbIdCliente.Items.Item(index)
               numGiocatori += 1
            End If
         End If

         If cmbGiocatore2.Text <> "" Then
            index = cmbGiocatore2.Items.IndexOf(cmbGiocatore2.Text)
            If index >= 0 Then
               idGiocatore(numGiocatori) = cmbIdGiocatore2.Items.Item(index)
               numGiocatori += 1
            End If
         End If

         If cmbGiocatore3.Text <> "" Then
            index = cmbGiocatore3.Items.IndexOf(cmbGiocatore3.Text)
            If index >= 0 Then
               idGiocatore(numGiocatori) = cmbIdGiocatore3.Items.Item(index)
               numGiocatori += 1
            End If
         End If

         If cmbGiocatore4.Text <> "" Then
            index = cmbGiocatore4.Items.IndexOf(cmbGiocatore4.Text)
            If index >= 0 Then
               idGiocatore(numGiocatori) = cmbIdGiocatore4.Items.Item(index)
               numGiocatori += 1
            End If
         End If

         If numGiocatori > 0 Then
            Dim codice As String
            If Me.Tag = "" Then
               codice = LeggiUltimaPren(NOME_TABELLA)
            Else
               codice = Me.Tag
            End If
            ' Formato italiano.
            Dim data As String = FormattaData(dtpData.Value, True)
            ' A_TODO: MODIFICHE ASD AGON
            Dim minGiocatore As Single = Convert.ToSingle(txtOre.Text) ' MEZZA_ORA / numGiocatori

            For i = 0 To numGiocatori - 1
               SalvaDatiStat(data, idGiocatore(i), idPartita, codice, minGiocatore)
            Next
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' NON UTILIZZATA!
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

   Public Function LeggiTipoPlanningRisorsa(ByVal tabella As String, ByVal descrizione As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & descrizione & "' ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("TipoPlanning")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

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

   Public Function LeggiCostoRisorsa(ByVal tabella As String, ByVal descrizione As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & descrizione & "' ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Costo")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiScontoCliente(ByVal tabella As String, ByVal id As Integer) As String
      ' A_TODO: MODIFICHE ASD AGON
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Sconto")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiIvaCliente(ByVal tabella As String, ByVal id As Integer) As String
      ' A_TODO: MODIFICHE ASD AGON
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Iva")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Function CalcolaCostoRisorsaTotale(ByVal costoRisorsa As String, ByVal oraInizio As Double, ByVal oraFine As Double) As String
      Dim Ore As Double = 0
      Dim totale As Double = 0
      Dim costoR As Double = 0
      Dim costoC As Double = 0

      Try
         If IsNumeric(costoRisorsa) = True Then
            costoR = CDbl(costoRisorsa)
         Else
            costoR = 0
         End If

         Ore = (oraFine - oraInizio)

         Select Case cmbStatoPren.SelectedItem
            Case "Abbonamento 1", "Abbonamento 2", "Abbonamento 3"
               totale = costoR + costoC

            Case Else
               totale = (costoR * Ore) + costoC
         End Select

         Return CFormatta.FormattaEuro(CDec(totale))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Function

   Private Sub CalcolaOrePrenotate()
      Dim Ore As Double = 0
      Dim OraInizio As Double = ConvertiOra(cmbOraInizio.Text)
      Dim OraFine As Double = ConvertiOra(cmbOraFine.Text)

      Ore = (OraFine - OraInizio)
      txtOre.Text = Ore.ToString
   End Sub

   Private Function CalcolaOra(ByVal ora As String) As Integer
      Try
         Select Case TipoPlanningSport
            Case TipoPlanning.Planning1
               Select Case ora
                  Case "6:00", "6:29"
                     Return 0

                  Case "6:30", "6:59"
                     Return ALTEZZA_CELLE

                  Case "7:00", "7:29"
                     Return ALTEZZA_CELLE * 2

                  Case "7:30", "7:59"
                     Return ALTEZZA_CELLE * 3

                  Case "8:00", "8:29"
                     Return ALTEZZA_CELLE * 4

                  Case "8:30", "8:59"
                     Return ALTEZZA_CELLE * 5

                  Case "9:00", "9:29"
                     Return ALTEZZA_CELLE * 6

                  Case "9:30", "9:59"
                     Return ALTEZZA_CELLE * 7

                  Case "10:00", "10:29"
                     Return ALTEZZA_CELLE * 8

                  Case "10:30", "10:59"
                     Return ALTEZZA_CELLE * 9

                  Case "11:00", "11:29"
                     Return ALTEZZA_CELLE * 10

                  Case "11:30", "11:59"
                     Return ALTEZZA_CELLE * 11

                  Case "12:00", "12:29"
                     Return ALTEZZA_CELLE * 12

                  Case "12:30", "12:59"
                     Return ALTEZZA_CELLE * 13

                  Case "13:00", "13:29"
                     Return ALTEZZA_CELLE * 14

                  Case "13:30", "13:59"
                     Return ALTEZZA_CELLE * 15

                  Case "14:00", "14:29"
                     Return ALTEZZA_CELLE * 16

                  Case "14:30", "14:59"
                     Return ALTEZZA_CELLE * 17

                  Case "15:00", "15:29"
                     Return ALTEZZA_CELLE * 18

                  Case "15:30", "15:59"
                     Return ALTEZZA_CELLE * 19

                  Case "16:00", "16:29"
                     Return ALTEZZA_CELLE * 20

                  Case "16:30", "16:59"
                     Return ALTEZZA_CELLE * 21

                  Case "17:00", "17:29"
                     Return ALTEZZA_CELLE * 22

                  Case "17:30", "17:59"
                     Return ALTEZZA_CELLE * 23

                  Case "18:00", "18:29"
                     Return ALTEZZA_CELLE * 24

                  Case "18:30", "18:59"
                     Return ALTEZZA_CELLE * 25

                  Case "19:00", "19:29"
                     Return ALTEZZA_CELLE * 26

                  Case "19:30", "19:59"
                     Return ALTEZZA_CELLE * 27

                  Case "20:00", "20:29"
                     Return ALTEZZA_CELLE * 28

                  Case "20:30", "20:59"
                     Return ALTEZZA_CELLE * 29

                  Case "21:00", "21:29"
                     Return ALTEZZA_CELLE * 30

                  Case "21:30", "21:59"
                     Return ALTEZZA_CELLE * 31

                  Case "22:00", "22:29"
                     Return ALTEZZA_CELLE * 32

                  Case "22:30", "22:59"
                     Return ALTEZZA_CELLE * 33

                  Case "23:00", "23:29"
                     Return ALTEZZA_CELLE * 34

                  Case "23:30", "24:00"
                     Return ALTEZZA_CELLE * 35

                  Case Else
                     Return 0
               End Select

            Case TipoPlanning.Planning2
               Select Case ora
                  Case "6:45", "7:44"
                     Return 0

                  Case "7:45", "8:44"
                     Return ALTEZZA_CELLE

                  Case "8:45", "9:44"
                     Return ALTEZZA_CELLE * 2

                  Case "9:45", "10:44"
                     Return ALTEZZA_CELLE * 3

                  Case "10:45", "11:44"
                     Return ALTEZZA_CELLE * 4

                  Case "11:45", "12:44"
                     Return ALTEZZA_CELLE * 5

                  Case "12:45", "13:44"
                     Return ALTEZZA_CELLE * 6

                  Case "13:45", "14:44"
                     Return ALTEZZA_CELLE * 7

                  Case "14:45", "15:44"
                     Return ALTEZZA_CELLE * 8

                  Case "15:45", "16:44"
                     Return ALTEZZA_CELLE * 9

                  Case "16:45", "17:44"
                     Return ALTEZZA_CELLE * 10

                  Case "17:45", "18:44"
                     Return ALTEZZA_CELLE * 11

                  Case "18:45", "19:44"
                     Return ALTEZZA_CELLE * 12

                  Case "19:45", "20:44"
                     Return ALTEZZA_CELLE * 13

                  Case "20:45", "21:44"
                     Return ALTEZZA_CELLE * 14

                  Case "21:45", "22:44"
                     Return ALTEZZA_CELLE * 15

                  Case "22:45", "23:44"
                     Return ALTEZZA_CELLE * 16

                  Case "23:45", "24:44"
                     Return ALTEZZA_CELLE * 17

                  Case Else
                     '' L'ora 9:45 non viene riconosciuta dalla casistica. Necessario il codice seguente.
                     'If ora = "9:45" Then
                     '   Return ALTEZZA_CELLE * 3
                     'Else
                     Return 0
                     'End If
               End Select

            Case TipoPlanning.Planning3
               Select Case ora
                  Case "7:00", "7:59"
                     Return 0

                  Case "8:00", "8:59"
                     Return ALTEZZA_CELLE

                  Case "9:00", "9:59"
                     Return ALTEZZA_CELLE * 2

                  Case "10:00", "10:59"
                     Return ALTEZZA_CELLE * 3

                  Case "11:00", "11:59"
                     Return ALTEZZA_CELLE * 4

                  Case "12:00", "12:59"
                     Return ALTEZZA_CELLE * 5

                  Case "13:00", "13:59"
                     Return ALTEZZA_CELLE * 6

                  Case "14:00", "14:59"
                     Return ALTEZZA_CELLE * 7

                  Case "15:00", "15:59"
                     Return ALTEZZA_CELLE * 8

                  Case "16:00", "16:59"
                     Return ALTEZZA_CELLE * 9

                  Case "17:00", "17:59"
                     Return ALTEZZA_CELLE * 10

                  Case "18:00", "18:59"
                     Return ALTEZZA_CELLE * 11

                  Case "19:00", "19:59"
                     Return ALTEZZA_CELLE * 12

                  Case "20:00", "20:59"
                     Return ALTEZZA_CELLE * 13

                  Case "21:00", "21:59"
                     Return ALTEZZA_CELLE * 14

                  Case "22:00", "22:59"
                     Return ALTEZZA_CELLE * 15

                  Case "23:00", "23:59"
                     Return ALTEZZA_CELLE * 16

                  Case Else
                     Return 0
               End Select

            Case TipoPlanning.Planning4
               Select Case ora
                  Case "7:15", "8:14"
                     Return 0

                  Case "8:15", "9:14"
                     Return ALTEZZA_CELLE

                  Case "9:15", "10:14"
                     Return ALTEZZA_CELLE * 2

                  Case "10:15", "11:14"
                     Return ALTEZZA_CELLE * 3

                  Case "11:15", "12:14"
                     Return ALTEZZA_CELLE * 4

                  Case "12:15", "13:14"
                     Return ALTEZZA_CELLE * 5

                  Case "13:15", "14:14"
                     Return ALTEZZA_CELLE * 6

                  Case "14:15", "15:14"
                     Return ALTEZZA_CELLE * 7

                  Case "15:15", "16:14"
                     Return ALTEZZA_CELLE * 8

                  Case "16:15", "17:14"
                     Return ALTEZZA_CELLE * 9

                  Case "17:15", "18:14"
                     Return ALTEZZA_CELLE * 10

                  Case "18:15", "19:14"
                     Return ALTEZZA_CELLE * 11

                  Case "19:15", "20:14"
                     Return ALTEZZA_CELLE * 12

                  Case "20:15", "21:14"
                     Return ALTEZZA_CELLE * 13

                  Case "21:15", "22:14"
                     Return ALTEZZA_CELLE * 14

                  Case "22:15", "23:14"
                     Return ALTEZZA_CELLE * 15

                  Case "23:15", "24:14"
                     Return ALTEZZA_CELLE * 16

                  Case Else
                     ' L'ora 9:15 non viene riconosciuta dalla casistica. Necessario il codice seguente.
                     'If ora = "9:15" Then
                     '   Return ALTEZZA_CELLE * 2
                     'Else
                     Return 0
                     'End If

               End Select

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Function

   Private Function CalcolaCordinataY() As Boolean
      Dim NUM_ORE As Short = 37
      Dim Inizio, Fine, CordY As Integer
      Dim Salvato As Boolean
      Dim NuovaOra As String
      Dim ore(NUM_ORE) As String
      Dim i, j As Short

      Try
         Select Case TipoPlanningSport
            Case TipoPlanning.Planning1
               Select Case cmbOraFine.Text
                  Case "6:30"
                     NuovaOra = "6:29"
                  Case "7:00"
                     NuovaOra = "6:59"
                  Case "7:30"
                     NuovaOra = "7:29"
                  Case "8:00"
                     NuovaOra = "7:59"
                  Case "8:30"
                     NuovaOra = "8:29"
                  Case "9:00"
                     NuovaOra = "8:59"
                  Case "9:30"
                     NuovaOra = "9:29"
                  Case "10:00"
                     NuovaOra = "9:59"
                  Case "10:30"
                     NuovaOra = "10:29"
                  Case "11:00"
                     NuovaOra = "10:59"
                  Case "11:30"
                     NuovaOra = "11:29"
                  Case "12:00"
                     NuovaOra = "11:59"
                  Case "12:30"
                     NuovaOra = "12:29"
                  Case "13:00"
                     NuovaOra = "12:59"
                  Case "13:30"
                     NuovaOra = "13:29"
                  Case "14:00"
                     NuovaOra = "13:59"
                  Case "14:30"
                     NuovaOra = "14:29"
                  Case "15:00"
                     NuovaOra = "14:59"
                  Case "15:30"
                     NuovaOra = "15:29"
                  Case "16:00"
                     NuovaOra = "15:59"
                  Case "16:30"
                     NuovaOra = "16:29"
                  Case "17:00"
                     NuovaOra = "16:59"
                  Case "17:30"
                     NuovaOra = "17:29"
                  Case "18:00"
                     NuovaOra = "17:59"
                  Case "18:30"
                     NuovaOra = "18:29"
                  Case "19:00"
                     NuovaOra = "18:59"
                  Case "19:30"
                     NuovaOra = "19:29"
                  Case "20:00"
                     NuovaOra = "19:59"
                  Case "20:30"
                     NuovaOra = "20:29"
                  Case "21:00"
                     NuovaOra = "20:59"
                  Case "21:30"
                     NuovaOra = "21:29"
                  Case "22:00"
                     NuovaOra = "21:59"
                  Case "22:30"
                     NuovaOra = "22:29"
                  Case "23:00"
                     NuovaOra = "22:59"
                  Case "23:30"
                     NuovaOra = "23:29"
                  Case "0:00"
                     NuovaOra = "23:59"
               End Select

               ore(1) = "6:00"
               ore(2) = "6:30"
               ore(3) = "7:00"
               ore(4) = "7:30"
               ore(5) = "8:00"
               ore(6) = "8:30"
               ore(7) = "9:00"
               ore(8) = "9:30"
               ore(9) = "10:00"
               ore(10) = "10:30"
               ore(11) = "11:00"
               ore(12) = "11:30"
               ore(13) = "12:00"
               ore(14) = "12:30"
               ore(15) = "13:00"
               ore(16) = "13:30"
               ore(17) = "14:00"
               ore(18) = "14:30"
               ore(19) = "15:00"
               ore(20) = "15:30"
               ore(21) = "16:00"
               ore(22) = "16:30"
               ore(23) = "17:00"
               ore(24) = "17:30"
               ore(25) = "18:00"
               ore(26) = "18:30"
               ore(27) = "19:00"
               ore(28) = "19:30"
               ore(29) = "20:00"
               ore(30) = "20:30"
               ore(31) = "21:00"
               ore(32) = "21:30"
               ore(33) = "22:00"
               ore(34) = "22:30"
               ore(35) = "23:00"
               ore(36) = "23:30"
               ore(37) = "0:00"

               NUM_ORE = 37

            Case TipoPlanning.Planning2
               Select Case cmbOraFine.Text
                  Case "7:45"
                     NuovaOra = "7:44"
                  Case "8:45"
                     NuovaOra = "8:44"
                  Case "9:45"
                     NuovaOra = "9:44"
                  Case "10:45"
                     NuovaOra = "10:44"
                  Case "11:45"
                     NuovaOra = "11:44"
                  Case "12:45"
                     NuovaOra = "12:44"
                  Case "13:45"
                     NuovaOra = "13:44"
                  Case "14:45"
                     NuovaOra = "14:44"
                  Case "15:45"
                     NuovaOra = "15:44"
                  Case "16:45"
                     NuovaOra = "16:44"
                  Case "17:45"
                     NuovaOra = "17:44"
                  Case "18:45"
                     NuovaOra = "18:44"
                  Case "19:45"
                     NuovaOra = "19:44"
                  Case "20:45"
                     NuovaOra = "20:44"
                  Case "21:45"
                     NuovaOra = "21:44"
                  Case "22:45"
                     NuovaOra = "22:44"
                  Case "23:45"
                     NuovaOra = "23:44"
               End Select

               ore(1) = "6:45"
               ore(2) = "7:45"
               ore(3) = "8:45"
               ore(4) = "9:45"
               ore(5) = "10:45"
               ore(6) = "11:45"
               ore(7) = "12:45"
               ore(8) = "13:45"
               ore(9) = "14:45"
               ore(10) = "15:45"
               ore(11) = "16:45"
               ore(12) = "17:45"
               ore(13) = "18:45"
               ore(14) = "19:45"
               ore(15) = "20:45"
               ore(16) = "21:45"
               ore(17) = "22:45"
               ore(18) = "23:45"

               NUM_ORE = 18

            Case TipoPlanning.Planning3
               Select Case cmbOraFine.Text
                  Case "8:00"
                     NuovaOra = "7:59"
                  Case "9:00"
                     NuovaOra = "8:59"
                  Case "10:00"
                     NuovaOra = "9:59"
                  Case "11:00"
                     NuovaOra = "10:59"
                  Case "12:00"
                     NuovaOra = "11:59"
                  Case "13:00"
                     NuovaOra = "12:59"
                  Case "14:00"
                     NuovaOra = "13:59"
                  Case "15:00"
                     NuovaOra = "14:59"
                  Case "16:00"
                     NuovaOra = "15:59"
                  Case "17:00"
                     NuovaOra = "16:59"
                  Case "18:00"
                     NuovaOra = "17:59"
                  Case "19:00"
                     NuovaOra = "18:59"
                  Case "20:00"
                     NuovaOra = "19:59"
                  Case "21:00"
                     NuovaOra = "20:59"
                  Case "22:00"
                     NuovaOra = "21:59"
                  Case "23:00"
                     NuovaOra = "22:59"
                  Case "0:00"
                     NuovaOra = "23:59"
               End Select

               ore(1) = "7:00"
               ore(2) = "8:00"
               ore(3) = "9:00"
               ore(4) = "10:00"
               ore(5) = "11:00"
               ore(6) = "12:00"
               ore(7) = "13:00"
               ore(8) = "14:00"
               ore(9) = "15:00"
               ore(10) = "16:00"
               ore(11) = "17:00"
               ore(12) = "18:00"
               ore(13) = "19:00"
               ore(14) = "20:00"
               ore(15) = "21:00"
               ore(16) = "22:00"
               ore(17) = "23:00"
               ore(18) = "0:00"

               NUM_ORE = 18

            Case TipoPlanning.Planning4
               Select Case cmbOraFine.Text
                  Case "8:15"
                     NuovaOra = "8:14"
                  Case "9:15"
                     NuovaOra = "9:14"
                  Case "10:15"
                     NuovaOra = "10:14"
                  Case "11:15"
                     NuovaOra = "11:14"
                  Case "12:15"
                     NuovaOra = "12:14"
                  Case "13:15"
                     NuovaOra = "13:14"
                  Case "14:15"
                     NuovaOra = "14:14"
                  Case "15:15"
                     NuovaOra = "15:14"
                  Case "16:15"
                     NuovaOra = "16:14"
                  Case "17:15"
                     NuovaOra = "17:14"
                  Case "18:15"
                     NuovaOra = "18:14"
                  Case "19:15"
                     NuovaOra = "19:14"
                  Case "20:15"
                     NuovaOra = "20:14"
                  Case "21:15"
                     NuovaOra = "21:14"
                  Case "22:15"
                     NuovaOra = "22:14"
                  Case "23:15"
                     NuovaOra = "23:14"
                  Case "0:15"
                     NuovaOra = "0:14"
               End Select

               ore(1) = "7:15"
               ore(2) = "8:15"
               ore(3) = "9:15"
               ore(4) = "10:15"
               ore(5) = "11:15"
               ore(6) = "12:15"
               ore(7) = "13:15"
               ore(8) = "14:15"
               ore(9) = "15:15"
               ore(10) = "16:15"
               ore(11) = "17:15"
               ore(12) = "18:15"
               ore(13) = "19:15"
               ore(14) = "20:15"
               ore(15) = "21:15"
               ore(16) = "22:15"
               ore(17) = "23:15"
               ore(18) = "0:15"

               NUM_ORE = 18

         End Select

         Inizio = CalcolaOra(cmbOraInizio.Text)
         Fine = CalcolaOra(NuovaOra)

         OraInizio = cmbOraInizio.Text

         For i = 1 To NUM_ORE
            If OraInizio = ore(i) Then
               Exit For
            End If
         Next

         ' Verifica l'esistenza di una prenotazione con gli stessi dati.
         'If Me.Tag = "" Then
         Dim k As Short = i
         Dim oraInizio1 As String = OraInizio

         For CordY = Inizio To Fine Step ALTEZZA_CELLE
            If VerificaEsistenzaPren(NOME_TABELLA, FormattaData(dtpData.Value, True), LeggiIdRisorsa(ANA_RISORSE, cmbRisorsa.Text), oraInizio1, ore(k + 1)) = True Then

               MsgBox("La prenotazione che si vuole salvare si sovrappone ad una prenotazione già esistente!" & vbCrLf &
                      "Si suggerisce di modificare i dati della prenotazione o annullare l'operazione.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)

               Salvato = False

               Exit Function
            End If

            oraInizio1 = ore(k + 1)
            k += 1
         Next
         'End If

         ' Contatore per sapere il numero di prenotazioni create.
         Dim h As Short = 0

         ' Salva i dati.

         CordY = Inizio

         'For CordY = Inizio To Fine Step ALTEZZA_CELLE
         Salvato = SalvaDati(CordY, cmbOraInizio.Text, cmbOraFine.Text)
         'OraInizio = ore(i + 1)
         'Dim codice As String
         LeggiNumGiocatori(LeggiUltimaPren(NOME_TABELLA) - h)
         'i += 1
         'h += 1
         'Next

         Return Salvato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Sub CaricaOreInizio(ByVal cmb As ComboBox)
      Dim NUM_ORE As Short = 36
      Dim ore(NUM_ORE) As String
      Dim i, j As Short

      Try
         Select Case TipoPlanningSport
            Case TipoPlanning.Planning1
               ore(1) = "6:00"
               ore(2) = "6:30"
               ore(3) = "7:00"
               ore(4) = "7:30"
               ore(5) = "8:00"
               ore(6) = "8:30"
               ore(7) = "9:00"
               ore(8) = "9:30"
               ore(9) = "10:00"
               ore(10) = "10:30"
               ore(11) = "11:00"
               ore(12) = "11:30"
               ore(13) = "12:00"
               ore(14) = "12:30"
               ore(15) = "13:00"
               ore(16) = "13:30"
               ore(17) = "14:00"
               ore(18) = "14:30"
               ore(19) = "15:00"
               ore(20) = "15:30"
               ore(21) = "16:00"
               ore(22) = "16:30"
               ore(23) = "17:00"
               ore(24) = "17:30"
               ore(25) = "18:00"
               ore(26) = "18:30"
               ore(27) = "19:00"
               ore(28) = "19:30"
               ore(29) = "20:00"
               ore(30) = "20:30"
               ore(31) = "21:00"
               ore(32) = "21:30"
               ore(33) = "22:00"
               ore(34) = "22:30"
               ore(35) = "23:00"
               ore(36) = "23:30"

               NUM_ORE = 36

            Case TipoPlanning.Planning2
               ore(1) = "6:45"
               ore(2) = "7:45"
               ore(3) = "8:45"
               ore(4) = "9:45"
               ore(5) = "10:45"
               ore(6) = "11:45"
               ore(7) = "12:45"
               ore(8) = "13:45"
               ore(9) = "14:45"
               ore(10) = "15:45"
               ore(11) = "16:45"
               ore(12) = "17:45"
               ore(13) = "18:45"
               ore(14) = "19:45"
               ore(15) = "20:45"
               ore(16) = "21:45"
               ore(17) = "22:45"
               ore(18) = "23:45"

               NUM_ORE = 18

            Case TipoPlanning.Planning3
               ore(1) = "7:00"
               ore(2) = "8:00"
               ore(3) = "9:00"
               ore(4) = "10:00"
               ore(5) = "11:00"
               ore(6) = "12:00"
               ore(7) = "13:00"
               ore(8) = "14:00"
               ore(9) = "15:00"
               ore(10) = "16:00"
               ore(11) = "17:00"
               ore(12) = "18:00"
               ore(13) = "19:00"
               ore(14) = "20:00"
               ore(15) = "21:00"
               ore(16) = "22:00"
               ore(17) = "23:00"

               NUM_ORE = 17

            Case TipoPlanning.Planning4
               ore(1) = "7:15"
               ore(2) = "8:15"
               ore(3) = "9:15"
               ore(4) = "10:15"
               ore(5) = "11:15"
               ore(6) = "12:15"
               ore(7) = "13:15"
               ore(8) = "14:15"
               ore(9) = "15:15"
               ore(10) = "16:15"
               ore(11) = "17:15"
               ore(12) = "18:15"
               ore(13) = "19:15"
               ore(14) = "20:15"
               ore(15) = "21:15"
               ore(16) = "22:15"
               ore(17) = "23:15"

               NUM_ORE = 17

         End Select

         cmb.Items.Clear()

         For i = 1 To NUM_ORE
            cmb.Items.Add(ore(i))
         Next

         cmb.SelectedIndex = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaOreFine(ByVal cmb As ComboBox, ByVal val As String)
      Dim NUM_ORE As Short = 37
      Dim ore(NUM_ORE) As String
      Dim i, j As Short

      Try
         Select Case TipoPlanningSport
            Case TipoPlanning.Planning1
               ore(1) = "6:00"
               ore(2) = "6:30"
               ore(3) = "7:00"
               ore(4) = "7:30"
               ore(5) = "8:00"
               ore(6) = "8:30"
               ore(7) = "9:00"
               ore(8) = "9:30"
               ore(9) = "10:00"
               ore(10) = "10:30"
               ore(11) = "11:00"
               ore(12) = "11:30"
               ore(13) = "12:00"
               ore(14) = "12:30"
               ore(15) = "13:00"
               ore(16) = "13:30"
               ore(17) = "14:00"
               ore(18) = "14:30"
               ore(19) = "15:00"
               ore(20) = "15:30"
               ore(21) = "16:00"
               ore(22) = "16:30"
               ore(23) = "17:00"
               ore(24) = "17:30"
               ore(25) = "18:00"
               ore(26) = "18:30"
               ore(27) = "19:00"
               ore(28) = "19:30"
               ore(29) = "20:00"
               ore(30) = "20:30"
               ore(31) = "21:00"
               ore(32) = "21:30"
               ore(33) = "22:00"
               ore(34) = "22:30"
               ore(35) = "23:00"
               ore(36) = "23:30"
               ore(37) = "0:00"

               NUM_ORE = 37

            Case TipoPlanning.Planning2
               ore(1) = "6:45"
               ore(2) = "7:45"
               ore(3) = "8:45"
               ore(4) = "9:45"
               ore(5) = "10:45"
               ore(6) = "11:45"
               ore(7) = "12:45"
               ore(8) = "13:45"
               ore(9) = "14:45"
               ore(10) = "15:45"
               ore(11) = "16:45"
               ore(12) = "17:45"
               ore(13) = "18:45"
               ore(14) = "19:45"
               ore(15) = "20:45"
               ore(16) = "21:45"
               ore(17) = "22:45"
               ore(18) = "23:45"
               ore(19) = "0:45"

               NUM_ORE = 19

            Case TipoPlanning.Planning3
               ore(1) = "7:00"
               ore(2) = "8:00"
               ore(3) = "9:00"
               ore(4) = "10:00"
               ore(5) = "11:00"
               ore(6) = "12:00"
               ore(7) = "13:00"
               ore(8) = "14:00"
               ore(9) = "15:00"
               ore(10) = "16:00"
               ore(11) = "17:00"
               ore(12) = "18:00"
               ore(13) = "19:00"
               ore(14) = "20:00"
               ore(15) = "21:00"
               ore(16) = "22:00"
               ore(17) = "23:00"
               ore(18) = "0:00"

               NUM_ORE = 18

            Case TipoPlanning.Planning4
               ore(1) = "7:15"
               ore(2) = "8:15"
               ore(3) = "9:15"
               ore(4) = "10:15"
               ore(5) = "11:15"
               ore(6) = "12:15"
               ore(7) = "13:15"
               ore(8) = "14:15"
               ore(9) = "15:15"
               ore(10) = "16:15"
               ore(11) = "17:15"
               ore(12) = "18:15"
               ore(13) = "19:15"
               ore(14) = "20:15"
               ore(15) = "21:15"
               ore(16) = "22:15"
               ore(17) = "23:15"
               ore(18) = "0:15"

               NUM_ORE = 18

         End Select
         cmb.Items.Clear()

         For i = 1 To NUM_ORE
            If val = ore(i) Then
               For j = i + 1 To NUM_ORE
                  cmb.Items.Add(ore(j))
                  ' Se è una prenotazione esistente non carica le ore 
                  ' perchè non può creare le prenotazioni multiple.
                  'If Me.Tag <> "" Then
                  '   Exit For
                  'End If
               Next
               cmb.SelectedIndex = 0
               Exit Sub
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub CaricaListaRisorse(ByVal cmb As ComboBox, ByVal tabella As String, ByVal tipoPlanning As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Escludi = 'No' AND TipoPlanning = '" & FormattaApici(tipoPlanning) & "' ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Descrizione"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   ' DA_FARE_B: Non utilizzata!
   Private Function VerificaEsistenzaPren1(ByVal tabella As String, ByVal data As String, ByVal idRisorsa As String, ByVal oraInizio As String, ByVal oraFine As String) As Boolean
      'Dim closeOnExit As Boolean
      'Dim numRec As Integer

      'Try
      '   ' Se necessario apre la connessione.
      '   If cn.State = ConnectionState.Closed Then
      '      cn.Open()
      '      closeOnExit = True
      '   End If

      '   ' Verifica l'esistenza del record.
      '   cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Data = '{1}' " & _
      '                                   "AND IdRisorsa = '{2}' AND oraInizio = '{3}' " & _
      '                                   "AND oraFine = '{4}'", _
      '                                    tabella, _
      '                                    data, _
      '                                    idRisorsa, _
      '                                    oraInizio, _
      '                                    oraFine)

      '   numRec = CInt(cmd.ExecuteScalar())

      '   If numRec = 0 Then
      '      Return False
      '   ElseIf numRec > 0 Then
      '      Return True
      '   End If

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   ' Chiude la connessione.
      '   cn.Close()

      'End Try
   End Function

   ' A_TODO: MODIFICHE ASD AGON
   Private Function VerificaEsistenzaPren(ByVal tabella As String, ByVal data As String, ByVal idRisorsa As String, ByVal oraInizio As String, ByVal oraFine As String) As Boolean
      Try
         Dim closeOnExit As Boolean
         Dim id As Integer

         Const NUM_ORE As Short = 33
         Dim ore(NUM_ORE) As String
         Dim orePrenArchivio(NUM_ORE) As Boolean
         Dim orePrenNuova(NUM_ORE) As Boolean

         ore(1) = "8:00"
         ore(2) = "8:30"
         ore(3) = "9:00"
         ore(4) = "9:30"
         ore(5) = "10:00"
         ore(6) = "10:30"
         ore(7) = "11:00"
         ore(8) = "11:30"
         ore(9) = "12:00"
         ore(10) = "12:30"
         ore(11) = "13:00"
         ore(12) = "13:30"
         ore(13) = "14:00"
         ore(14) = "14:30"
         ore(15) = "15:00"
         ore(16) = "15:30"
         ore(17) = "16:00"
         ore(18) = "16:30"
         ore(19) = "17:00"
         ore(20) = "17:30"
         ore(21) = "18:00"
         ore(22) = "18:30"
         ore(23) = "19:00"
         ore(24) = "19:30"
         ore(25) = "20:00"
         ore(26) = "20:30"
         ore(27) = "21:00"
         ore(28) = "21:30"
         ore(29) = "22:00"
         ore(30) = "22:30"
         ore(31) = "23:00"
         ore(32) = "23:30"
         ore(33) = "0:00"

         orePrenNuova(1) = False
         orePrenNuova(2) = False
         orePrenNuova(3) = False
         orePrenNuova(4) = False
         orePrenNuova(5) = False
         orePrenNuova(6) = False
         orePrenNuova(7) = False
         orePrenNuova(8) = False
         orePrenNuova(9) = False
         orePrenNuova(10) = False
         orePrenNuova(11) = False
         orePrenNuova(12) = False
         orePrenNuova(13) = False
         orePrenNuova(14) = False
         orePrenNuova(15) = False
         orePrenNuova(16) = False
         orePrenNuova(17) = False
         orePrenNuova(18) = False
         orePrenNuova(19) = False
         orePrenNuova(20) = False
         orePrenNuova(21) = False
         orePrenNuova(22) = False
         orePrenNuova(23) = False
         orePrenNuova(24) = False
         orePrenNuova(25) = False
         orePrenNuova(26) = False
         orePrenNuova(27) = False
         orePrenNuova(28) = False
         orePrenNuova(29) = False
         orePrenNuova(30) = False
         orePrenNuova(31) = False
         orePrenNuova(32) = False
         orePrenNuova(33) = False

         ' Ora di inizio.
         Dim i As Integer
         For i = 1 To NUM_ORE
            If oraInizio = ore(i) Then
               orePrenNuova(i) = True

               ' Ora di fine.
               Dim j As Integer
               For j = i To NUM_ORE
                  If oraFine = ore(j) Then
                     orePrenNuova(j) = True
                     Exit For
                  Else
                     orePrenNuova(j) = False
                  End If
               Next

               Exit For
            End If
         Next

         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Data = '" & data & "' AND IdRisorsa = '" & idRisorsa & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            If IsDBNull(dr.Item("Id")) = False Then
               id = dr.Item("Id")
            Else
               id = 0
            End If

            If IsDBNull(dr.Item("OraInizio")) = False Then
               oraInizio = dr.Item("OraInizio")
            Else
               oraInizio = "8:00"
            End If
            If IsDBNull(dr.Item("OraFine")) = False Then
               oraFine = dr.Item("OraFine")
            Else
               oraFine = "8:30"
            End If

            orePrenArchivio(1) = False
            orePrenArchivio(2) = False
            orePrenArchivio(3) = False
            orePrenArchivio(4) = False
            orePrenArchivio(5) = False
            orePrenArchivio(6) = False
            orePrenArchivio(7) = False
            orePrenArchivio(8) = False
            orePrenArchivio(9) = False
            orePrenArchivio(10) = False
            orePrenArchivio(11) = False
            orePrenArchivio(12) = False
            orePrenArchivio(13) = False
            orePrenArchivio(14) = False
            orePrenArchivio(15) = False
            orePrenArchivio(16) = False
            orePrenArchivio(17) = False
            orePrenArchivio(18) = False
            orePrenArchivio(19) = False
            orePrenArchivio(20) = False
            orePrenArchivio(21) = False
            orePrenArchivio(22) = False
            orePrenArchivio(23) = False
            orePrenArchivio(24) = False
            orePrenArchivio(25) = False
            orePrenArchivio(26) = False
            orePrenArchivio(27) = False
            orePrenArchivio(28) = False
            orePrenArchivio(29) = False
            orePrenArchivio(30) = False
            orePrenArchivio(31) = False
            orePrenArchivio(32) = False
            orePrenArchivio(33) = False

            ' Ora di inizio.
            Dim y As Integer
            For y = 1 To NUM_ORE
               If oraInizio = ore(y) Then
                  y += 1

                  ' Ora di fine.
                  Dim j As Integer
                  For j = y To NUM_ORE
                     If oraFine = ore(j) Then
                        orePrenArchivio(j) = True
                        Exit For
                     Else
                        orePrenArchivio(j) = False
                     End If
                  Next

                  Exit For
               End If
            Next

            ' A_TODO: MODIFICHE ASD AGON
            ' Esegue la verifica solo se la prenotazione non è se stessa.
            If id <> Me.Tag Then
               Dim k As Integer
               For k = 1 To NUM_ORE
                  ' Verifica se le ore della prenotazione si sovrappongono.
                  If orePrenArchivio(k) = True And orePrenNuova(k) = True Then
                     Return True
                  End If
               Next
            End If
         Loop

         Return False

      Catch ex As InvalidCastException
         ' Utilizzata per invalidare l'errore Invalid Cast dalla stringa "" al tipo Double.
         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

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

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i dati nel database.
            If CalcolaCordinataY() = True Then

               SalvaDettagliConto(Me.Tag)

               If cmbPagato.Text = "Sì" Then
                  SalvaStatisticheVendita()
               End If

               If IsNothing(g_frmPlanningSport1) = False Then
                  ' Aggiorna il planning.
                  g_frmPlanningSport1.CaricaPrenotazioni(False)
               End If

               If IsNothing(g_frmPlanningSport2) = False Then
                  ' Aggiorna il planning.
                  g_frmPlanningSport2.CaricaPrenotazioni(False)
               End If

               If IsNothing(g_frmPlanningSport3) = False Then
                  ' Aggiorna il planning.
                  g_frmPlanningSport3.CaricaPrenotazioni(False)
               End If

               If IsNothing(g_frmPlanningSport4) = False Then
                  ' Aggiorna il planning.
                  g_frmPlanningSport4.CaricaPrenotazioni(False)
               End If

               If IsNothing(g_frmPrenRisorse) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmPrenRisorse.AggiornaDati()
               End If

               If IsNothing(g_frmStatisticheRisorse) = False Then
                  ' Aggiorna il planning.
                  g_frmStatisticheRisorse.AggiornaDati()
               End If

               ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
               Me.Tag = "0"

               ' Chiude la finestra.
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = " (" & IPren.Codice & " - " & IPren.Data & " " & IPren.Intestatario &
                                              " - " & IPren.DescrizioneRisorsa & " - Ora: " & IPren.OraInizio & "/" & IPren.OraFine & ")"

               g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_GESTIONE_PREN_RISORSE)
            End If

         Case "Annulla"

            ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
            Me.Tag = "0"

            ' Chiude la finestra.
            Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_RISORSE)
      End Select
   End Sub

   Private Sub frmPrenRisorse_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_GESTIONE_PREN_RISORSE)
      End If
   End Sub

   Private Sub frmPrenRisorse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' A_TODO: MODIFICHE ASD AGON
         ' Imposta le dimensioni del form.
         FormResize(PREN_RISORSE_LARGHEZZA, PREN_RISORSE_ALTEZZA)

         Dim cnStr As String = CreaConnString(PercorsoDBClienti)

         ' Carica le liste.
         CaricaListaClienti(cmbCliente, cmbIdCliente, ANA_CLIENTI)
         CaricaListaClienti(cmbGiocatore2, cmbIdGiocatore2, ANA_CLIENTI)
         CaricaListaClienti(cmbGiocatore3, cmbIdGiocatore3, ANA_CLIENTI)
         CaricaListaClienti(cmbGiocatore4, cmbIdGiocatore4, ANA_CLIENTI)
         CaricaLista(cmbCaratteristiche, ANA_CARATT_RISORSE)
         CaricaLista(cmbStatoPren, TAB_STATO_PREN)
         CaricaLista(cmbPagamento, TAB_PAGAMENTO)

         ' Definisce a quale tipo di planning appartiene la risorsa.
         nomePlanning = LeggiTipoPlanningRisorsa(ANA_RISORSE, Risorsa)

         Select Case nomePlanning
            Case PLANNING_1
               TipoPlanningSport = TipoPlanning.Planning1

            Case PLANNING_2
               TipoPlanningSport = TipoPlanning.Planning2

            Case PLANNING_3
               TipoPlanningSport = TipoPlanning.Planning3

            Case PLANNING_4
               TipoPlanningSport = TipoPlanning.Planning4

            Case Else
               TipoPlanningSport = TipoPlanning.Planning1
               nomePlanning = PLANNING_1

         End Select

         ' Carica l'elenco delle risorse per il planning specifico.
         CaricaListaRisorse(cmbRisorsa, ANA_RISORSE, nomePlanning)

         ' Carica le ore di inizio prenotatione.
         CaricaOreInizio(cmbOraInizio)

         If AliquotaIvaCentroSportivo <> String.Empty Then
            txtIva.Text = CFormatta.FormattaEuro(AliquotaIvaCentroSportivo)
         Else
            txtIva.Text = VALORE_ZERO
         End If

         If Me.Tag <> String.Empty Then
            With IPren
               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtNumero.Text = .Codice
               dtpData.Text = .Data
               cmbCliente.Text = .Intestatario
               cmbGiocatore2.Text = .Componente1
               cmbGiocatore3.Text = .Componente2
               cmbGiocatore4.Text = .Componente3
               cmbRisorsa.Text = .DescrizioneRisorsa
               ' A_TODO: MODIFICHE ASD AGON
               cmbCaratteristiche.Text = .CaratteristicaRisorsa
               cmbStatoPren.Text = .Stato
               cmbOraInizio.Text = .OraInizio
               cmbOraFine.Text = .OraFine
               cmbPagato.Text = .Pagato
               txtCostoRisorsa.Text = CFormatta.FormattaEuro(.CostoRisorsa)
               txtTotale.Text = CFormatta.FormattaEuro(.Totale)
               dtpScadenza.Text = .ScadenzaAbb
               ' A_TODO: MODIFICHE ASD AGON
               cmbApplicaSconto.SelectedIndex = Convert.ToInt32(.ApplicaSconto)
               txtNote.Text = .Note

               If .Colore <> 0 Then
                  cmdColore.BackColor = Color.FromArgb(.Colore)
               End If

               ' Non consente la modifica.
               'cmbCliente.Enabled = False
               'cmbGiocatore2.Enabled = False
               'cmbGiocatore3.Enabled = False
               'cmbGiocatore4.Enabled = False

               LeggiDettagliConto()
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
               cmbCaratteristiche.SelectedItem = VALORE_NESSUNA

               If Risorsa = "" Then
                  cmbRisorsa.SelectedIndex = 0
               Else
                  cmbRisorsa.SelectedIndex = cmbRisorsa.Items.IndexOf(Risorsa)
               End If

               If Ora = "" Then
                  cmbOraInizio.SelectedIndex = 0
               Else
                  cmbOraInizio.SelectedIndex = cmbOraInizio.Items.IndexOf(Ora)
               End If

               Dim valCostoRisorsa As Double
               If IsNumeric(LeggiCostoRisorsa(ANA_RISORSE, cmbRisorsa.Text)) = True Then
                  valCostoRisorsa = Convert.ToDouble(LeggiCostoRisorsa(ANA_RISORSE, cmbRisorsa.Text))
                  txtCostoRisorsa.Text = CFormatta.FormattaEuro(valCostoRisorsa)
               Else
                  txtCostoRisorsa.Text = VALORE_ZERO
               End If

               ' A_TODO: MODIFICHE ASD AGON
               txtSconto.Text = VALORE_ZERO
               cmbApplicaSconto.SelectedIndex = 0
               cmbStatoPren.SelectedItem = "Confermata"
               cmbOraFine.SelectedIndex = 0
               cmbPagato.SelectedIndex = 1
               dtpScadenza.Enabled = False
               txtNote.Text = ""
            End With
         End If

         ' Carica la lista delle degli allegati.
         'ConvalidaAllegati()

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, cmbCliente.Text, "")

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

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      ' Imposta lo stato attivo.
      Select Case TabControl1.SelectedIndex()
         Case 0
            dtpData.Focus()

         Case 1
            cmbGiocatore2.Focus()

         Case 2
            InserisciPrenRisorsaConto()
            CalcolaTotaleConto()
            lvwConto.Focus()

         Case 3
            txtNote.Focus()

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

   Private Sub cmbStatoPren_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatoPren.SelectedIndexChanged
      Try
         cmdColore.BackColor = Color.FromArgb(AssegnaColore(cmbStatoPren.Text, TAB_STATO_PREN))
         IPren.Colore = Convert.ToString(cmdColore.BackColor.ToArgb)

         Select Case cmbStatoPren.SelectedItem
            Case "Abbonamento 1", "Abbonamento 2", "Abbonamento 3"
               dtpScadenza.Enabled = True

            Case Else
               dtpScadenza.Enabled = False
         End Select


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmbOraInizio_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbOraInizio.SelectedIndexChanged
      CaricaOreFine(cmbOraFine, cmbOraInizio.Text)
      CalcolaOrePrenotate()
   End Sub

   Private Sub cmbOraFine_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbOraFine.SelectedIndexChanged
      CalcolaOrePrenotate()
   End Sub

   Private Sub txtCostoRisorsa_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostoRisorsa.TextChanged
      ConvalidaCampi(sender.Text, sender, ErrorProvider1)
   End Sub

   Private Sub txtCostoRisorsa_LostFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCostoRisorsa.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub cmbRisorsa_DropDown(sender As Object, e As System.EventArgs) Handles cmbRisorsa.DropDown
      EliminaPrenRisorsaConto()
   End Sub

   Private Sub cmbRisorsa_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbRisorsa.SelectedIndexChanged
      txtCostoRisorsa.Text = CFormatta.FormattaEuro(LeggiCostoRisorsa(ANA_RISORSE, cmbRisorsa.Text))
   End Sub

   Private Sub eui_cmdApriPos_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdApriPos.Click
      ' Apre il punto cassa.
      g_frmMain.ApriPos(0, "", "", "")
   End Sub

   Private Sub eui_cmdAccessori_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdAccessori.Click
      Try
         Dim frm As New ListaAccessoriServizi("Accessorio")
         frm.Tag = "PrenSport"
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdServizi_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdServizi.Click
      Try
         Dim frm As New ListaAccessoriServizi("Servizio")
         frm.Tag = "PrenSport"
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdEliminaRiga_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdEliminaRiga.Click
      EliminaRiga()
      CalcolaTotaleConto()
   End Sub

   Private Sub EliminaRiga()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         'lvwConto.Focus()
         'Dim strDescrizione As String = "(" & lvwConto.Items(lvwConto.FocusedItem.Index).SubItems(1).Text & _
         '                               " " & lvwConto.Items(lvwConto.FocusedItem.Index).SubItems(2).Text & _
         '                               " € " & lvwConto.Items(lvwConto.FocusedItem.Index).SubItems(3).Text & ")"

         'g_frmMain.RegistraOperazione(TipoOperazione.Cancella, strDescrizione, MODULO_GESTIONE_POS)

         If lvwConto.Items.Count <> 0 Then
            lvwConto.Focus()
            lvwConto.Items.RemoveAt(lvwConto.FocusedItem.Index)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function AumentaDiminuisciQta(ByVal val As Boolean) As Boolean
      ' Vero: aumenta di 1 - Falso: diminuisce di 1.
      Try
         If lvwConto.Items.Count <> 0 Then
            lvwConto.Focus()

            Dim quantità As Integer = Convert.ToInt32(lvwConto.Items(lvwConto.FocusedItem.Index).SubItems(1).Text)
            Dim totPrezzo As Decimal = Convert.ToDecimal(lvwConto.Items(lvwConto.FocusedItem.Index).SubItems(2).Text)
            Dim prezzo As Decimal

            ' Ottiene il prezzo di una singola unità.
            prezzo = totPrezzo / quantità

            If val = True Then
               quantità += 1
            Else
               If quantità = 1 Then
                  EliminaRiga()

                  Return False
               Else
                  quantità -= 1
               End If
            End If

            ' Calcola il prezzo totale in base alla quantità inserita.
            totPrezzo = prezzo * quantità
            lvwConto.Items(lvwConto.FocusedItem.Index).SubItems(2).Text = String.Format("{0:0.00}", totPrezzo)

            lvwConto.Items(lvwConto.FocusedItem.Index).SubItems(1).Text = quantità

            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Public Sub CalcolaTotaleConto()
      ' A_TODO: MODIFICHE ASD AGON
      Try
         If lvwConto.Items.Count <> 0 Then
            Dim i As Integer = 0
            Dim TotRiga As Decimal
            Dim TotaleConto As Decimal

            For i = 0 To lvwConto.Items.Count - 1
               TotRiga = Convert.ToDecimal(lvwConto.Items(i).SubItems(2).Text)
               TotaleConto = TotaleConto + TotRiga
            Next i

            ' Calcola il valore dello sconto.
            Dim sconto As Double
            If IsNumeric(txtSconto.Text) = False Then
               ' Gestito a percentuale.
               Dim percSconto As Integer = txtSconto.Text.IndexOf("%")
               If percSconto <> -1 Then
                  sconto = Convert.ToDouble(txtSconto.Text.Remove(txtSconto.Text.Length - 1, 1))

                  If cmbApplicaSconto.SelectedIndex = 1 Then
                     ' Sul totale del conto.
                     valSconto = CalcolaPercentuale(TotaleConto, sconto)
                  Else
                     ' Sul costo della risorsa.
                     Dim strDescrizione As String = "Costo orario affitto " & cmbRisorsa.Text

                     Dim j As Integer
                     For j = 0 To lvwConto.Items.Count - 1
                        If lvwConto.Items(j).SubItems(0).Text = strDescrizione Then
                           Dim costoRisorsa As Decimal = lvwConto.Items(j).SubItems(2).Text
                           valSconto = CalcolaPercentuale(costoRisorsa, sconto)
                           Exit For
                        Else
                           valSconto = 0
                        End If
                     Next
                  End If
               End If
            Else
               ' Gestito a valore sul totale del conto e sul costo della risorsa.
               valSconto = Convert.ToDouble(txtSconto.Text)
            End If

            ' Calcola il valore da pagare..
            Dim valDaPagare As Double = (TotaleConto - valSconto)

            txtTotale.Text = CFormatta.FormattaEuro(valDaPagare)
         Else
            txtTotale.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function LeggiNumeroMax(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0} WHERE TipoDoc = '{1}'", tabella, tipoDoc)
         If IsDBNull(cmd.ExecuteScalar()) = False Then
            numRec = CInt(cmd.ExecuteScalar())
         Else
            numRec = 0
         End If

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Function CreaFileScontrinoWPOS1() As Boolean
      Try
         Dim SR_DATI_TEST As String = "SR_DATI_TEST.TXT"
         Dim SR_DATI As String = "SR_DATI."
         Dim SR_START As String = "SR_START."
         Dim tipoPagContanti As String
         Dim tipoPagCartaCredito As String
         Dim tipoPagBuoni As String
         Dim sw As StreamWriter

         If PercorsoLavoroWpos1 = String.Empty Then
            Return False
         End If

         If EstensioneFileWpos1 = String.Empty Then
            Return False
         Else
            SR_DATI = SR_DATI & EstensioneFileWpos1
            SR_START = SR_START & EstensioneFileWpos1
         End If

         ' Tipo pagamento - Contanti.
         If txtTotale.Text <> "0,00" And txtTotale.Text <> "" Then
            tipoPagContanti = "CASH,V" & RimuoviVirgola(txtTotale.Text) & ";"
         End If

         '' Tipo pagamento.
         'If txtCartaCredito.Text <> "0,00" And txtCartaCredito.Text <> "" Then
         '   If cmdTipoPagamento.Text.ToUpper <> "ASSEGNI" And cmdTipoPagamento.Text.ToUpper <> "ASSEGNO" Then
         '      ' Tipo pagamento - Carta di credito.
         '      tipoPagCartaCredito = "CARD,V" & RimuoviVirgola(txtCartaCredito.Text) & ",:" & cmdTipoPagamento.Text & ";"
         '   Else
         '      ' Tipo pagamento - Assegno
         '      tipoPagCartaCredito = "CHEQ,V" & RimuoviVirgola(txtCartaCredito.Text) & ";"
         '   End If
         'End If

         '' Tipo pagamento - Buoni Pasto.
         'If txtBuoni.Text <> "0,00" And txtBuoni.Text <> "" Then
         '   tipoPagBuoni = "CASH,V" & RimuoviVirgola(txtBuoni.Text) & ";"
         'End If

         'If tipoPagContanti = String.Empty And tipoPagCartaCredito = String.Empty And tipoPagBuoni = String.Empty Then
         '   MessageBox.Show("E' necessario specificare il tipo di pagamento e il valore dell'importo.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         '   txtContanti.Focus()
         '   Return False
         'End If

         ' Crea il file Start con la password.
         sw = File.CreateText(PercorsoLavoroWpos1 & "\" & SR_START)
         sw.WriteLine(PwdDriverWpos1)
         sw.Close()

         ' Crea il file Dati con le righe di vendita.
         sw = File.CreateText(PercorsoLavoroWpos1 & "\" & SR_DATI)

         ' Righe di vendita articoli.
         Dim j As Integer
         For j = 0 To lvwConto.Items.Count - 1
            Dim rigaScontrino As String = "PLUD,C1,N1,P" & RimuoviVirgola(lvwConto.Items(j).SubItems(2).Text) & ",Q" & lvwConto.Items(j).SubItems(1).Text & ",:" & lvwConto.Items(j).SubItems(0).Text.ToUpper & ";"
            sw.WriteLine(rigaScontrino)
         Next

         '' Servizio %.
         'If txtServizio.Text <> "0,00" And txtServizio.Text <> "" Then
         '   sw.WriteLine("PRNT,N1,:;")

         '   If txtServizio.Text.Substring(txtServizio.Text.Length - 1, 1) = "%" Then
         '      ' Maggiorazione percentuale.
         '      sw.WriteLine("PRNT,:SERVIZIO " & SostituisciVirgola(txtServizio.Text) & "%;")
         '      sw.WriteLine("MOST,%" & SostituisciVirgola(txtServizio.Text) & ";")
         '   Else
         '      ' Maggiorazione a valore.
         '      sw.WriteLine("PRNT,:SERVIZIO " & txtServizio.Text & ";")
         '      sw.WriteLine("ADDS,V" & RimuoviVirgola(txtServizio.Text) & ";")
         '   End If
         'End If

         '' Sconto %.
         'If txtValSconto.Text <> "0,00" And txtValSconto.Text <> "" Then
         '   sw.WriteLine("PRNT,N1,:;")
         '   If txtValSconto.Text.Substring(txtValSconto.Text.Length - 1, 1) = "%" Then
         '      ' Sconto percentuale.
         '      sw.WriteLine("DOST,%" & SostituisciVirgola(txtValSconto.Text) & ";")
         '   Else
         '      ' Sconto a valore.
         '      sw.WriteLine("COST,V" & RimuoviVirgola(txtValSconto.Text) & ";")
         '   End If
         'End If

         ' Istruzioni da verificare...non utilizzate perchè il registratore di cassa dovrebbe inserirle automaticamente.
         ' Operatore - Numero postazione cassa.
         'sw.WriteLine("EXTL,N1,:OPERATORE N. " & LeggiCodiceOperatoreConfig() & ";")
         'sw.WriteLine("EXTL,N1,:;")
         'sw.WriteLine("EXTL,N1,:NUMERO CASSA " & g_frmMain.eui_cmdPostazione.Text.Remove(0, 1) & ";")

         ' Tipo pagamento - Contanti.
         sw.WriteLine(tipoPagContanti)

         '' Tipo pagamento - Carta di credito - Assegno.
         'sw.WriteLine(tipoPagCartaCredito)

         sw.Close()

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Function CreaFileScontrinoSwing() As Boolean
      Try
         Dim numComandiScontrino As Integer = 2
         Dim numRigheScontrino As Integer = lvwConto.Items.Count + numComandiScontrino
         Dim sw As StreamWriter

         If NomeScontrinoSF = String.Empty Then
            Return False
         End If

         If PercorsoOutputSF = String.Empty Then
            Return False
         End If

         If PercorsoDriverSF = String.Empty Then
            Return False
         End If

         If File.Exists(PercorsoOutputSF & "\" & NomeScontrinoSF) = True Then
            File.Delete(PercorsoOutputSF & "\" & NomeScontrinoSF)
         End If

         sw = File.CreateText(PercorsoOutputSF & "\" & NomeScontrinoSF)
         sw.WriteLine(" " & PortaSF.ToString.Substring(4))
         sw.WriteLine(ParametriSF)
         sw.WriteLine(" " & numRigheScontrino.ToString)
         sw.WriteLine("=K")
         sw.WriteLine("=C1")

         Dim i As Integer
         For i = 0 To lvwConto.Items.Count - 1
            Dim rigaScontrino As String = "=R1/$" & lvwConto.Items(i).SubItems(2).Text & "/*" & lvwConto.Items(i).SubItems(1).Text & "/" & "(" & lvwConto.Items(i).SubItems(0).Text.ToUpper & ")"
            sw.WriteLine(rigaScontrino)
         Next

         sw.Close()

         EseguiFileScontrino(Me.Handle)

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Sub EseguiFileScontrino(ByVal frmHandle As IntPtr)
      Dim NOME_APP As String = PercorsoDriverSF & "SWINGDRIVER.EXE"
      Dim Proc As New Process

      Try
         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NOME_APP
         Proc.StartInfo.Arguments = PercorsoOutputSF & NomeScontrinoSF
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = frmHandle
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function LeggiNumeroDocFiscaleConfig(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim chiaveConfig As String = ""
         Select Case tipoDoc
            Case TIPO_DOC_FF
               chiaveConfig = "NumeroFattura"

            Case TIPO_DOC_RF
               chiaveConfig = "NumeroRicevuta"

         End Select

         If IsNumeric(DatiConfig.GetValue(chiaveConfig)) = False Then
            ' Legge dal database.
            Dim num As Integer = LeggiNumeroMax(tabella, tipoDoc)
            If num = 0 Then
               Return 1
            Else
               Return num
            End If
         Else
            ' Legge dal file di configurazione.
            Return DatiConfig.GetValue(chiaveConfig)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub SalvaNumeroDocFiscaleConfig(ByVal tabella As String, ByVal tipoDoc As String, ByVal numDoc As Integer)
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim chiaveConfig As String = ""
         Select Case tipoDoc
            Case TIPO_DOC_FF
               chiaveConfig = "NumeroFattura"

            Case TIPO_DOC_RF
               chiaveConfig = "NumeroRicevuta"

         End Select

         DatiConfig.SetValue(chiaveConfig, (numDoc + 1).ToString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function VerificaCliente(ByVal cmb As ComboBox, ByVal nome As String) As Boolean
      Try
         ' Cerca l'elemento nella lista.
         Dim i As Integer
         For i = 0 To cmb.Items.Count - 1
            If nome = cmb.Items(i) Then
               Return True
            End If
         Next

         Return False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try

   End Function

   ' DA_FARE: Verificare! SalvaDocumento.
   Private Function SalvaDocumento() As Boolean
      Try
         Dim NumeroDocumento As Integer = LeggiNumeroDocFiscaleConfig(TAB_DOC, tipoDocumento)

         With Doc
            Dim valSospeso As Double = Convert.ToDouble(txtTotale.Text)
            Dim valDaPagare As Double = Convert.ToDouble(txtTotale.Text)

            .Numero = NumeroDocumento ' LeggiNumeroMax(TAB_DOC, tipoDocumento) + 1
            .Anno = Now.Year
            .Data = dtpData.Value.Today
            .Ora = dtpData.Value.ToShortTimeString
            .Tipo = tipoDocumento
            .Stato = "Emesso e stampato"
            .Causale = "Vendita da Centro sportivo"

            'Select Case tipoCliente
            '   Case Cliente.Azienda
            '      ' Viene aggiunta la lettera A per identificare le Aziende.
            '      ' Codice aggiunto dopo la creazione della nuova anagrafica Aziende.
            '      .IdCliente = "A" & idCliente
            '   Case Cliente.Privato
            'End Select

            If VerificaCliente(cmbCliente, cmbCliente.Text) = True Then
               ' Se i dati del cliente sono nell'anagrafica li legge per utilizzarli nei documenti fiscali.
               .IdCliente = cmbIdCliente.Items(cmbCliente.SelectedIndex).ToString
               .Cliente = FormattaApici(cmbCliente.Text)
               LeggiDatiCliente("Clienti", .IdCliente)
            Else
               ' Se i dati del cliente non sono nell'anagrafica salva solo il nome per la prenotazione.
               .IdCliente = String.Empty
               .Cliente = FormattaApici(cmbCliente.Text)
               ImpostaDatiCliente()
            End If

            .CodAzienda = String.Empty

            .ImpLordoRep1 = VALORE_ZERO
            .ImpLordoRep2 = VALORE_ZERO
            .ImpLordoRep3 = VALORE_ZERO
            .ImpLordoRep4 = VALORE_ZERO
            .AliquotaIvaRep1 = VALORE_ZERO
            .AliquotaIvaRep2 = VALORE_ZERO
            .AliquotaIvaRep3 = VALORE_ZERO
            .AliquotaIvaRep4 = VALORE_ZERO
            .ImpostaRep1 = VALORE_ZERO
            .ImpostaRep2 = VALORE_ZERO
            .ImpostaRep3 = VALORE_ZERO
            .ImpostaRep4 = VALORE_ZERO

            .Coperto = VALORE_ZERO
            .Sconto = CFormatta.FormattaNumeroDouble(valSconto)
            .TipoSconto = String.Empty
            .Servizio = VALORE_ZERO
            .TipoServizio = String.Empty
            .Contanti = VALORE_ZERO
            .Carte = VALORE_ZERO
            .BuoniPasto = VALORE_ZERO
            .BuoniPastoIncassare = VALORE_ZERO
            .Chiuso = "No"
            .Note = String.Empty

            .TipoPagamento = cmbPagamento.Text

            .Tavolo = String.Empty
            .Cameriere = String.Empty

            If cmbPagato.Text = "Sì" Then
               .Sospeso = VALORE_ZERO
               .SospesoIncassare = VALORE_ZERO
            Else
               .Sospeso = CFormatta.FormattaNumeroDouble(valSospeso)
               .SospesoIncassare = CFormatta.FormattaNumeroDouble(valSospeso)
            End If

            .TotDoc = CFormatta.FormattaNumeroDouble(Convert.ToDouble(valDaPagare))

            ' SCHEDA PA.
            .NumeroDoc_PA = String.Empty
            .CodiceCUP_PA = String.Empty
            .CodiceCIG_PA = String.Empty
            .CodiceCommConv_PA = String.Empty

            If tipoDocumento = TIPO_DOC_FF Or tipoDocumento = TIPO_DOC_RF Or tipoDocumento = TIPO_DOC_SF Then
               ' Calcola l'IVA.
               Dim valImposta As Double
               Dim valImponibile As Double

               If IsNumeric(txtIva.Text) = True Then
                  valImponibile = CalcolaImponibileIva(txtIva.Text, valDaPagare)
                  valImposta = CalcolaPercentuale(valImponibile, Convert.ToDouble(txtIva.Text))
               Else
                  valImposta = 0.0
                  txtIva.Text = VALORE_ZERO
               End If

               .Imponibile = CFormatta.FormattaNumeroDouble(valImponibile)
               .Iva = txtIva.Text
               .Imposta = CFormatta.FormattaNumeroDouble(valImposta)
            Else
               .Imponibile = VALORE_ZERO
               .Iva = VALORE_ZERO
               .Imposta = VALORE_ZERO
            End If

            .InserisciDati(TAB_DOC)
         End With

         ' SALVA I DETTAGLI DEL DOCUMENTO.
         Dim sql As String
         ' Apre la connessione.
         cn.Open()

         Dim i As Integer
         For i = 0 To lvwConto.Items.Count - 1

            'Dim colore As Color = g_frmPos.lstvDettagli.Items(i).BackColor
            'If colore.Equals(Color.LightCoral) = False Then

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di inserimento.
            sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOC)

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)

            cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOC))
            cmdInsert.Parameters.AddWithValue("@CodiceArticolo", String.Empty)
            cmdInsert.Parameters.AddWithValue("@Descrizione", FormattaApici(lvwConto.Items(i).SubItems(0).Text))
            cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
            cmdInsert.Parameters.AddWithValue("@Quantità", lvwConto.Items(i).SubItems(1).Text)
            cmdInsert.Parameters.AddWithValue("@ValoreUnitario", VALORE_ZERO) ' B_TODO: Modifica per Retail.
            cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
            cmdInsert.Parameters.AddWithValue("@ImportoNetto", lvwConto.Items(i).SubItems(2).Text)
            cmdInsert.Parameters.AddWithValue("@AliquotaIva", AliquotaIvaCentroSportivo)
            cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)

            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()
            'End If
         Next

         '' SALVA I DETTAGLI PER LO SCONTO.
         If Doc.Sconto <> VALORE_ZERO Then
            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di inserimento.
            'sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " &
            '                          "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOC)

            sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOC)

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)

            cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOC))
            cmdInsert.Parameters.AddWithValue("@CodiceArticolo", String.Empty)

            If cmbApplicaSconto.SelectedIndex = 1 Then
               ' Sul totale del conto.
               cmdInsert.Parameters.AddWithValue("@Descrizione", "Sconto")
            Else
               ' Sul costo della risorsa.
               cmdInsert.Parameters.AddWithValue("@Descrizione", "Sconto sul costo di " & cmbRisorsa.Text)
            End If

            cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
            cmdInsert.Parameters.AddWithValue("@Quantità", VALORE_ZERO)
            cmdInsert.Parameters.AddWithValue("@ValoreUnitario", VALORE_ZERO) ' B_TODO: Modifica per Retail.
            cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
            cmdInsert.Parameters.AddWithValue("@ImportoNetto", "-" & Doc.Sconto)
            cmdInsert.Parameters.AddWithValue("@AliquotaIva", 0)
            cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)

            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()
         End If

         ' SALVA I DETTAGLI PER IL SERVIZIO.
         'If Doc.Servizio <> VALORE_ZERO Then
         '   ' Avvia una transazione.
         '   tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         '   ' Crea la stringa di eliminazione.
         '   sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " & _
         '                                 "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOC)
         '   ' Crea il comando per la connessione corrente.
         '   Dim cmdInsert As New OleDbCommand(sql, cn, tr)
         '   cmdInsert.Parameters.Add("@RifDoc", LeggiUltimoRecord(TAB_DOC))
         '   cmdInsert.Parameters.Add("@Descrizione", "Servizio")
         '   cmdInsert.Parameters.Add("@Quantità", "1")
         '   cmdInsert.Parameters.Add("@ImportoNetto", Doc.Servizio)
         '   ' Esegue il comando.
         '   Dim Record As Integer = cmdInsert.ExecuteNonQuery()
         '   ' Conferma transazione.
         '   tr.Commit()
         'End If

         ' Salva il Numero del prossimo documento da stampare.
         SalvaNumeroDocFiscaleConfig(TAB_DOC, tipoDocumento, NumeroDocumento)

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub StampaConto(ByVal nomeStampante As String)
      Try
         If DocSalvato = False Then
            ' Salva il documento fiscale.
            DocSalvato = SalvaDocumento()
         End If

         Select Case percorsoRep
            Case PERCORSO_REP_FF_A4, PERCORSO_REP_FF_A4_DOPPIA, PERCORSO_REP_FF_A4_IVA_MULTIPLA,
                 PERCORSO_REP_RF_A4_DOPPIA, PERCORSO_REP_RF_A5, PERCORSO_REP_RF_A6,
                 PERCORSO_REP_PF_A4_DOPPIA, PERCORSO_REP_PF_A5, PERCORSO_REP_PF_A6,
                 PERCORSO_REP_PF_A4_DOPPIA_CENTRO_SPORTIVO, PERCORSO_REP_FF_A4_DOPPIA_CENTRO_SPORTIVO, PERCORSO_REP_RF_A4_DOPPIA_CENTRO_SPORTIVO,
                 PERCORSO_REP_RF_BELLA_NAPOLI, PERCORSO_REP_FF_BELLA_NAPOLI, PERCORSO_REP_PF_BELLA_NAPOLI,
                 PERCORSO_REP_RF_CELIDE, PERCORSO_REP_FF_CELIDE, PERCORSO_REP_PF_CELIDE,
                 PERCORSO_REP_RF_FORCHETTA_DORO, PERCORSO_REP_FF_FORCHETTA_DORO, PERCORSO_REP_PF_FORCHETTA_DORO

               ' Esegue la stampa.
               StampaDocumento(percorsoRep, LeggiUltimoRecord(TAB_DOC), nomeStampante)

            Case PERCORSO_REP_SF
               ' Esegue la stampa.
               If nomeStampante = "Swing ECR 65/A" Then
                  If CreaFileScontrinoSwing() = False Then
                     g_frmPos.InfoScontrino()
                     Exit Sub
                  End If
               Else
                  If CreaFileScontrinoWPOS1() = False Then
                     g_frmPos.InfoScontrino()
                     Exit Sub
                  End If
               End If

            Case PERCORSO_REP_PF_KUBEII
               Dim sql As String = "SELECT * FROM " & TAB_DETTAGLI_DOC & " WHERE RifDoc = " & LeggiUltimoRecord(TAB_DOC)
               'StampaProformaKUBEII(sql, percorsoRep, LeggiUltimoRecord(TAB_DOC), nomeTavoloDoc, nomeCameriereDoc, nomeStampante)

            Case PERCORSO_REP_RF_KUBEII
               StampaRicevutaFatturaKUBEII(PERCORSO_REP_RF_KUBEII, LeggiUltimoRecord(TAB_DOC), nomeStampante)

            Case PERCORSO_REP_FF_KUBEII
               StampaRicevutaFatturaKUBEII(PERCORSO_REP_FF_KUBEII, LeggiUltimoRecord(TAB_DOC), nomeStampante)

         End Select

         Dim risposta As MsgBoxResult
         risposta = MsgBox("Il conto è stato stampato correttamente?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)

         If risposta = MsgBoxResult.Yes Then
            ' Esce, chiude il form e stampa il conto.
            'Me.DialogResult = DialogResult.OK
            ' Salva i dati di eventuali Buoni.
            'SalvaDatiBuoni()
            'Me.Close()

            ' Registra loperazione effettuata dall'operatore identificato.
            'Dim strDescrizione As String = "(" & Doc.Tipo & " n. " & Doc.Numero & " del " & Doc.Data & " - € " & CFormatta.FormattaEuro(Doc.TotDoc) & ")"
            'Select Case tipoDocumento
            '   Case TIPO_DOC_RF
            '      g_frmMain.RegistraOperazione(TipoOperazione.Ricevuta, strDescrizione, MODULO_CONTO)

            '   Case TIPO_DOC_FF
            '      g_frmMain.RegistraOperazione(TipoOperazione.Fattura, strDescrizione, MODULO_CONTO)

            '   Case TIPO_DOC_PF
            '      g_frmMain.RegistraOperazione(TipoOperazione.Proforma, strDescrizione, MODULO_CONTO)

            '   Case TIPO_DOC_SF
            '      g_frmMain.RegistraOperazione(TipoOperazione.Scontrino, strDescrizione, MODULO_CONTO)
            'End Select

         Else
            MessageBox.Show("E' possibile stampare ancora lo stesso documento con gli stessi dati! Nel caso si voglia modificare l'intestazione o gli importi del documento sara necessario annullarlo dall'Elenco Documenti e stamparne uno nuovo.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub StampaDocumento(ByVal nomeDoc As String, ByVal numDoc As Integer, ByVal nomeStampante As String)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         ' Tabella Documenti.
         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_DOC & " WHERE Id = " & numDoc, cn)

         Dim ds As New Dataset1 'utilizzato con Crystal Reports.
         ds.Clear()
         oleAdapter.Fill(ds, TAB_DOC)

         ' Tabella DettagliDoc
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_DETTAGLI_DOC & " WHERE RifDoc = " & numDoc, cn)
         oleAdapter1.Fill(ds, TAB_DETTAGLI_DOC)

         ' Tabella Azienda
         Dim oleAdapter2 As New OleDbDataAdapter
         oleAdapter2.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_AZIENDA, cn)
         oleAdapter2.Fill(ds, TAB_AZIENDA)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepDocumenti(ds, nomeDoc, nomeStampante)
         frm.ShowDialog()

         ' ---------------------------------------------------------------------------------
         ' NON UTILIZZATO! - Vecchio codice che utilizza CrystalReports.

         'Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

         'rep.Load(Application.StartupPath & nomeDoc)

         'rep.SetDataSource(ds)

         'If nomeStampante <> String.Empty And nomeStampante <> VALORE_NESSUNA Then
         '   rep.PrintOptions.PrinterName = nomeStampante
         'End If

         'PrintDialog1.PrinterSettings.Copies = NumeroCopieStampa

         'rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True,
         '          PrintDialog1.PrinterSettings.FromPage,
         '          PrintDialog1.PrinterSettings.ToPage)
         ' ---------------------------------------------------------------------------------

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub eui_QuantitàMeno_Click(sender As System.Object, e As System.EventArgs) Handles eui_QuantitàMeno.Click
      AumentaDiminuisciQta(False)
      CalcolaTotaleConto()

   End Sub

   Private Sub eui_cmdQuantitàPiù_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdQuantitàPiù.Click
      AumentaDiminuisciQta(True)
      CalcolaTotaleConto()
   End Sub

   Public Sub InserisciPrenRisorsaConto()
      Try
         Const VAL_GRUPPO As Short = 2
         Const ID_RISORSA As String = "Risorsa"
         Dim strDescrizione As String = "Costo orario affitto " & cmbRisorsa.Text
         Dim QTA As Integer = 1

         ' Rimuove eventuali voci già presenti per non duplicarle.
         If lvwConto.Items.Count <> 0 Then
            Dim i As Integer
            For i = 0 To lvwConto.Items.Count - 1
               If lvwConto.Items(i).Text = strDescrizione Then
                  lvwConto.Items.RemoveAt(i)
                  Exit For
               End If
            Next
         End If

         ' Descrizione.
         lvwConto.Items.Add(strDescrizione)

         ' Assegna il gruppo.
         lvwConto.Items(lvwConto.Items.Count - 1).Group = lvwConto.Groups.Item(VAL_GRUPPO)
         lvwConto.Items(lvwConto.Items.Count - 1).ForeColor = cmdColore.BackColor

         ' Quantità.
         lvwConto.Items(lvwConto.Items.Count - 1).SubItems.Add(QTA)

         ' Costo.
         Dim val As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(CalcolaCostoRisorsaTotale(txtCostoRisorsa.Text, ConvertiOra(cmbOraInizio.Text), ConvertiOra(cmbOraFine.Text))))
         lvwConto.Items(lvwConto.Items.Count - 1).SubItems.Add(val)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub EliminaPrenRisorsaConto()
      Try
         Dim strDescrizione As String = "Costo orario affitto " & cmbRisorsa.Text

         ' Rimuove eventuali voci già presenti per non duplicarle.
         If lvwConto.Items.Count <> 0 Then
            Dim i As Integer
            For i = 0 To lvwConto.Items.Count - 1
               If lvwConto.Items(i).Text = strDescrizione Then
                  lvwConto.Items.RemoveAt(i)
                  Exit For
               End If
            Next
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function ImpostaNomeStampante(ByVal indice As Integer) As String
      Dim val() As String = PercorsiStampantiDocumenti(indice).Split(";")

      If val(1) <> VALORE_NESSUNA Then
         Return val(1)
      Else
         Return String.Empty
      End If
   End Function

   Private Function ImpostaNomeDoc(ByVal indice As Integer) As String
      Dim val() As String = PercorsiStampantiDocumenti(indice).Split(";")

      If val(2) <> String.Empty Then
         Return val(2)
      Else
         Return String.Empty
      End If
   End Function

   Private Sub eui_cmdStampaDocRF_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdStampaDocRF.Click
      Try
         tipoDocumento = TIPO_DOC_RF

         If ImpostaNomeDoc(0) <> String.Empty Then
            percorsoRep = "\Reports\" & ImpostaNomeDoc(0)
         Else
            percorsoRep = PERCORSO_REP_RF_A4_DOPPIA_CENTRO_SPORTIVO
         End If

         'If txtSospeso.Text <> VALORE_ZERO Then
         '   If VerificaIntestazione() = False Then
         '      Exit Sub
         '   End If
         'End If

         StampaConto(ImpostaNomeStampante(0))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdStampaDocFF_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdStampaDocFF.Click
      Try
         tipoDocumento = TIPO_DOC_FF

         If ImpostaNomeDoc(1) <> String.Empty Then
            percorsoRep = "\Reports\" & ImpostaNomeDoc(1)
         Else
            percorsoRep = PERCORSO_REP_FF_A4_DOPPIA_CENTRO_SPORTIVO
         End If

         'If VerificaIntestazione() = True Then
         '   If VerificaCartaCredito() = True Then
         StampaConto(ImpostaNomeStampante(1))
         '   End If
         'End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdStampaDocPF_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdStampaDocPF.Click
      Try
         tipoDocumento = TIPO_DOC_PF

         If ImpostaNomeDoc(2) <> String.Empty Then
            percorsoRep = "\Reports\" & ImpostaNomeDoc(2)
         Else
            percorsoRep = PERCORSO_REP_PF_A4_DOPPIA_CENTRO_SPORTIVO
         End If

         'If txtSospeso.Text <> VALORE_ZERO Then
         '   If VerificaIntestazione() = False Then
         '      Exit Sub
         '   End If
         'End If

         StampaConto(ImpostaNomeStampante(2))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdStampaDocSF_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdStampaDocSF.Click
      Try
         If ImpostaNomeStampante(3) = String.Empty Then
            InfoScontrino()
            Exit Sub
         End If

         tipoDocumento = TIPO_DOC_SF

         If ImpostaNomeDoc(3) <> String.Empty Then
            percorsoRep = "\Reports\" & ImpostaNomeDoc(3)
         Else
            percorsoRep = PERCORSO_REP_SF
         End If

         'If txtSospeso.Text <> VALORE_ZERO Then
         '   If VerificaIntestazione() = False Then
         '      Exit Sub
         '   End If
         'End If

         StampaConto(ImpostaNomeStampante(3))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub InfoScontrino()
      MsgBox("Non è possibile stampare lo scontrino! Nessuna stampante impostata per stampare questo documento.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
   End Sub

   Private Sub cmdColore_Click(sender As System.Object, e As System.EventArgs) Handles cmdColore.Click
      ' ModificaColore
      MessageBox.Show("Per assegnare un colore alla prenotazione selezionare un valore nella casella 'Stato prenotazione'.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

   End Sub

   Private Sub cmbCliente_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCliente.SelectedIndexChanged
      Try
         ' A_TODO: MODIFICHE ASD AGON
         cmbIdCliente.SelectedIndex = cmbCliente.SelectedIndex

         ' Se è impostata l'aliquota Iva per il cliente... Altrimenti viene utilzzata quella di reparto.
         Dim valIva As Decimal = Convert.ToDecimal(LeggiIvaCliente(ANA_CLIENTI, cmbIdCliente.Text))
         If CFormatta.FormattaAliquotaIva(valIva) <> VALORE_ZERO Then
            txtIva.Text = CFormatta.FormattaAliquotaIva(valIva)
         End If

         Dim valSconto As String = LeggiScontoCliente(ANA_CLIENTI, cmbIdCliente.Text)

         If IsNumeric(valSconto) = True Then
            txtSconto.Text = CFormatta.FormattaEuro(Convert.ToDecimal(valSconto)) & "%"
         Else
            txtSconto.Text = VALORE_ZERO
         End If

         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmbCaratteristiche_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCaratteristiche.SelectedIndexChanged
      ' A_TODO: MODIFICHE ASD AGON
      txtCostoRisorsa.Text = CFormatta.FormattaEuro(LeggiCostoRisorsa(ANA_CARATT_RISORSE, cmbCaratteristiche.Text))

   End Sub

   Private Sub cmbApplicaSconto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbApplicaSconto.SelectedIndexChanged
      Try
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub txtSconto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSconto.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtSconto_LostFocus(sender As Object, e As System.EventArgs) Handles txtSconto.LostFocus
      Try
         Dim perc As Integer = sender.Text.IndexOf("%")

         If IsNumeric(sender.Text) = True Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))

         ElseIf perc <> -1 Then
            Dim val As String = sender.Text.Replace("%", "")
            sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(val)) & "%"

         Else
            sender.Text = VALORE_ZERO
         End If

         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
