#Region " DATI FILE.VB "
' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       18/01/2005
' Data ultima modifica: 25/08/2018
' Descrizione:          Anagrafica Prenotazioni Camere.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Data.OleDb

Public Class frmPrenCamera
   Inherits System.Windows.Forms.Form

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal nomeFrm As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      ' Nome della finestra che ha effettuato la chiamata.
      tipoFrm = nomeFrm

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
   Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Label20 As System.Windows.Forms.Label
   Public WithEvents txtNote As System.Windows.Forms.TextBox
   Friend WithEvents Salva As System.Windows.Forms.ToolBarButton
   Friend WithEvents Annulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents cmdColore As System.Windows.Forms.Button
   Public WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents lvwAllegati As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmbTrattamento As System.Windows.Forms.ComboBox
   Friend WithEvents cmdApriIntestatario As System.Windows.Forms.Button
   Friend WithEvents cmbTipologia As System.Windows.Forms.ComboBox
   Public WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Public WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage7 As System.Windows.Forms.TabPage
   Friend WithEvents cmbListino As System.Windows.Forms.ComboBox
   Public WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents cmbPagamento As System.Windows.Forms.ComboBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents txtNumero As System.Windows.Forms.TextBox
   Public WithEvents Label12 As System.Windows.Forms.Label
   Public WithEvents txtDescrizioneCamera As System.Windows.Forms.TextBox
   Friend WithEvents cmbNumeroCamera As System.Windows.Forms.ComboBox
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents txtAccontoCamera As System.Windows.Forms.TextBox
   Public WithEvents Label18 As System.Windows.Forms.Label
   Public WithEvents txtPrezzoCamera As System.Windows.Forms.TextBox
   Public WithEvents txtTotaleCostoCamera As System.Windows.Forms.TextBox
   Public WithEvents Label16 As System.Windows.Forms.Label
   Public WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents nudBambini As System.Windows.Forms.NumericUpDown
   Friend WithEvents nudAdulti As System.Windows.Forms.NumericUpDown
   Friend WithEvents lvwOccupanti As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
   Friend WithEvents lvwAddebiti As System.Windows.Forms.ListView
   Friend WithEvents clnData As System.Windows.Forms.ColumnHeader
   Friend WithEvents clnDescrizione As System.Windows.Forms.ColumnHeader
   Friend WithEvents clnQta As System.Windows.Forms.ColumnHeader
   Friend WithEvents clnImporto As System.Windows.Forms.ColumnHeader
   Friend WithEvents clnIndice As System.Windows.Forms.ColumnHeader
   Friend WithEvents eui_QuantitàMeno As Elegant.Ui.Button
   Friend WithEvents eui_cmdQuantitàPiù As Elegant.Ui.Button
   Public WithEvents txtTotaleAddebitiExtra As System.Windows.Forms.TextBox
   Public WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents eui_ddwnInserisciAddebiti As Elegant.Ui.DropDown
   Friend WithEvents eui_cmdEliminaRiga As Elegant.Ui.Button
   Friend WithEvents cmdInserisciOccupanti As Elegant.Ui.Button
   Friend WithEvents cmdEliminaOccupanti As Elegant.Ui.Button
   Friend WithEvents eui_cmdInserisci As Elegant.Ui.Button
   Friend WithEvents eui_cmdModifica As Elegant.Ui.Button
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents PopupMenu1 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdAccessori As Elegant.Ui.Button
   Friend WithEvents eui_cmdServizi As Elegant.Ui.Button
   Friend WithEvents Separator1 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdApriPos As Elegant.Ui.Button
   Friend WithEvents cmbStatoPren As System.Windows.Forms.ComboBox
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents txtTotaleAddebiti As System.Windows.Forms.TextBox
   Public WithEvents Label15 As System.Windows.Forms.Label
   Public WithEvents txtTotaleConto As System.Windows.Forms.TextBox
   Public WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Public WithEvents lblPartenza As System.Windows.Forms.Label
   Public WithEvents lblArrivo As System.Windows.Forms.Label
   Friend WithEvents mcDataPartenza As System.Windows.Forms.MonthCalendar
   Public WithEvents txtNumeroNotti As System.Windows.Forms.TextBox
   Public WithEvents Label27 As System.Windows.Forms.Label
   Friend WithEvents dtpOraArrivo As System.Windows.Forms.DateTimePicker
   Public WithEvents Label28 As System.Windows.Forms.Label
   Friend WithEvents mcDataArrivo As System.Windows.Forms.MonthCalendar
   Friend WithEvents cmbCognome As System.Windows.Forms.ComboBox
   Public WithEvents txtNome As System.Windows.Forms.TextBox
   Friend WithEvents cmbIdCliente As System.Windows.Forms.ComboBox
   Friend WithEvents cmbNome As System.Windows.Forms.ComboBox
   Friend WithEvents nudNeonati As System.Windows.Forms.NumericUpDown
   Public WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents nudRagazzi As System.Windows.Forms.NumericUpDown
   Public WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
   Friend WithEvents txtSconto As System.Windows.Forms.TextBox
   Public WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents cmbApplicaSconto As System.Windows.Forms.ComboBox
   Public WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents txtServizio As System.Windows.Forms.TextBox
   Public WithEvents Label24 As System.Windows.Forms.Label
   Public WithEvents txtTotaleIncassare As System.Windows.Forms.TextBox
   Public WithEvents Label25 As System.Windows.Forms.Label
   Public WithEvents txtTotaleTassaSoggiorno As System.Windows.Forms.TextBox
   Public WithEvents Label26 As System.Windows.Forms.Label
   Friend WithEvents cmbIdListino As System.Windows.Forms.ComboBox
   Public WithEvents txtTassaSoggiorno As TextBox
   Public WithEvents Label29 As Label
   Friend WithEvents clnCodice As ColumnHeader
   Friend WithEvents clnAliquotaIva As ColumnHeader
   Friend WithEvents clnCategoria As ColumnHeader
   Public WithEvents txtTotaleImporto As TextBox
   Friend WithEvents ColumnHeader2 As ColumnHeader
   Friend WithEvents ckbSchedina As CheckBox
   Friend WithEvents cmdNuovoIntestatario As Button
   Friend WithEvents ColumnHeader1 As ColumnHeader
   Friend WithEvents ColumnHeader3 As ColumnHeader
   Friend WithEvents cmbAgenzia As ComboBox
   Public WithEvents Label32 As Label
   Friend WithEvents cmbCanaleVendita As ComboBox
   Public WithEvents Label31 As Label
   Friend WithEvents cmbGruppo As ComboBox
   Public WithEvents Label30 As Label
   Friend WithEvents ColumnHeader4 As ColumnHeader
   Friend WithEvents eui_cmdApri As Elegant.Ui.Button
   Friend WithEvents eui_cmdElimina As Elegant.Ui.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPrenCamera))
      Dim ListViewGroup1 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Articoli vari", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup2 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Accessori", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup3 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Servizi", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup4 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Bar/Ristorante", System.Windows.Forms.HorizontalAlignment.Left)
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Salva = New System.Windows.Forms.ToolBarButton()
      Me.Annulla = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.cmbAgenzia = New System.Windows.Forms.ComboBox()
      Me.Label32 = New System.Windows.Forms.Label()
      Me.cmbCanaleVendita = New System.Windows.Forms.ComboBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.cmbGruppo = New System.Windows.Forms.ComboBox()
      Me.Label30 = New System.Windows.Forms.Label()
      Me.cmdNuovoIntestatario = New System.Windows.Forms.Button()
      Me.ckbSchedina = New System.Windows.Forms.CheckBox()
      Me.nudNeonati = New System.Windows.Forms.NumericUpDown()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.nudRagazzi = New System.Windows.Forms.NumericUpDown()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.cmbNome = New System.Windows.Forms.ComboBox()
      Me.cmbIdCliente = New System.Windows.Forms.ComboBox()
      Me.txtNome = New System.Windows.Forms.TextBox()
      Me.cmbCognome = New System.Windows.Forms.ComboBox()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.mcDataArrivo = New System.Windows.Forms.MonthCalendar()
      Me.txtNumeroNotti = New System.Windows.Forms.TextBox()
      Me.Label27 = New System.Windows.Forms.Label()
      Me.dtpOraArrivo = New System.Windows.Forms.DateTimePicker()
      Me.Label28 = New System.Windows.Forms.Label()
      Me.lblPartenza = New System.Windows.Forms.Label()
      Me.lblArrivo = New System.Windows.Forms.Label()
      Me.mcDataPartenza = New System.Windows.Forms.MonthCalendar()
      Me.cmbStatoPren = New System.Windows.Forms.ComboBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.nudBambini = New System.Windows.Forms.NumericUpDown()
      Me.nudAdulti = New System.Windows.Forms.NumericUpDown()
      Me.txtNumero = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.txtDescrizioneCamera = New System.Windows.Forms.TextBox()
      Me.cmbNumeroCamera = New System.Windows.Forms.ComboBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmdColore = New System.Windows.Forms.Button()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmbTrattamento = New System.Windows.Forms.ComboBox()
      Me.cmdApriIntestatario = New System.Windows.Forms.Button()
      Me.cmbTipologia = New System.Windows.Forms.ComboBox()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.TabPage3 = New System.Windows.Forms.TabPage()
      Me.cmdInserisciOccupanti = New Elegant.Ui.Button()
      Me.cmdEliminaOccupanti = New Elegant.Ui.Button()
      Me.lvwOccupanti = New System.Windows.Forms.ListView()
      Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TabPage4 = New System.Windows.Forms.TabPage()
      Me.eui_QuantitàMeno = New Elegant.Ui.Button()
      Me.eui_cmdQuantitàPiù = New Elegant.Ui.Button()
      Me.txtTotaleAddebitiExtra = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.eui_ddwnInserisciAddebiti = New Elegant.Ui.DropDown()
      Me.PopupMenu1 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdAccessori = New Elegant.Ui.Button()
      Me.eui_cmdServizi = New Elegant.Ui.Button()
      Me.Separator1 = New Elegant.Ui.Separator()
      Me.eui_cmdApriPos = New Elegant.Ui.Button()
      Me.eui_cmdEliminaRiga = New Elegant.Ui.Button()
      Me.lvwAddebiti = New System.Windows.Forms.ListView()
      Me.clnData = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnDescrizione = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnQta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnImporto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCodice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnIndice = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnAliquotaIva = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.clnCategoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TabPage7 = New System.Windows.Forms.TabPage()
      Me.txtTotaleImporto = New System.Windows.Forms.TextBox()
      Me.txtTassaSoggiorno = New System.Windows.Forms.TextBox()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.cmbIdListino = New System.Windows.Forms.ComboBox()
      Me.txtTotaleTassaSoggiorno = New System.Windows.Forms.TextBox()
      Me.Label26 = New System.Windows.Forms.Label()
      Me.txtTotaleIncassare = New System.Windows.Forms.TextBox()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.txtServizio = New System.Windows.Forms.TextBox()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.txtSconto = New System.Windows.Forms.TextBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.cmbApplicaSconto = New System.Windows.Forms.ComboBox()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.txtTotaleAddebiti = New System.Windows.Forms.TextBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.txtTotaleConto = New System.Windows.Forms.TextBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.txtAccontoCamera = New System.Windows.Forms.TextBox()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.txtPrezzoCamera = New System.Windows.Forms.TextBox()
      Me.txtTotaleCostoCamera = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.cmbListino = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.cmbPagamento = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.TabPage5 = New System.Windows.Forms.TabPage()
      Me.eui_cmdApri = New Elegant.Ui.Button()
      Me.eui_cmdInserisci = New Elegant.Ui.Button()
      Me.eui_cmdModifica = New Elegant.Ui.Button()
      Me.eui_cmdElimina = New Elegant.Ui.Button()
      Me.lvwAllegati = New System.Windows.Forms.ListView()
      Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
      CType(Me.nudNeonati, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudRagazzi, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel2.SuspendLayout()
      CType(Me.nudBambini, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.nudAdulti, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage3.SuspendLayout()
      Me.TabPage4.SuspendLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage7.SuspendLayout()
      Me.TabPage5.SuspendLayout()
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
      Me.ToolBar1.Size = New System.Drawing.Size(576, 26)
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
      Me.Panel1.Size = New System.Drawing.Size(576, 20)
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
      Me.TabControl1.Controls.Add(Me.TabPage4)
      Me.TabControl1.Controls.Add(Me.TabPage7)
      Me.TabControl1.Controls.Add(Me.TabPage5)
      Me.TabControl1.Controls.Add(Me.TabPage6)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 46)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(576, 543)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.cmbAgenzia)
      Me.TabPage1.Controls.Add(Me.Label32)
      Me.TabPage1.Controls.Add(Me.cmbCanaleVendita)
      Me.TabPage1.Controls.Add(Me.Label31)
      Me.TabPage1.Controls.Add(Me.cmbGruppo)
      Me.TabPage1.Controls.Add(Me.Label30)
      Me.TabPage1.Controls.Add(Me.cmdNuovoIntestatario)
      Me.TabPage1.Controls.Add(Me.ckbSchedina)
      Me.TabPage1.Controls.Add(Me.nudNeonati)
      Me.TabPage1.Controls.Add(Me.Label21)
      Me.TabPage1.Controls.Add(Me.nudRagazzi)
      Me.TabPage1.Controls.Add(Me.Label19)
      Me.TabPage1.Controls.Add(Me.cmbNome)
      Me.TabPage1.Controls.Add(Me.cmbIdCliente)
      Me.TabPage1.Controls.Add(Me.txtNome)
      Me.TabPage1.Controls.Add(Me.cmbCognome)
      Me.TabPage1.Controls.Add(Me.Panel2)
      Me.TabPage1.Controls.Add(Me.cmbStatoPren)
      Me.TabPage1.Controls.Add(Me.Label13)
      Me.TabPage1.Controls.Add(Me.nudBambini)
      Me.TabPage1.Controls.Add(Me.nudAdulti)
      Me.TabPage1.Controls.Add(Me.txtNumero)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.txtDescrizioneCamera)
      Me.TabPage1.Controls.Add(Me.cmbNumeroCamera)
      Me.TabPage1.Controls.Add(Me.Label11)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.Label1)
      Me.TabPage1.Controls.Add(Me.cmdColore)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.dtpData)
      Me.TabPage1.Controls.Add(Me.Label7)
      Me.TabPage1.Controls.Add(Me.cmbTrattamento)
      Me.TabPage1.Controls.Add(Me.cmdApriIntestatario)
      Me.TabPage1.Controls.Add(Me.cmbTipologia)
      Me.TabPage1.Controls.Add(Me.txtCodice)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.Controls.Add(Me.Label20)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.ForeColor = System.Drawing.Color.Black
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(568, 517)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Dati principali"
      '
      'cmbAgenzia
      '
      Me.cmbAgenzia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbAgenzia.Location = New System.Drawing.Point(112, 248)
      Me.cmbAgenzia.Name = "cmbAgenzia"
      Me.cmbAgenzia.Size = New System.Drawing.Size(136, 21)
      Me.cmbAgenzia.TabIndex = 18
      '
      'Label32
      '
      Me.Label32.AutoSize = True
      Me.Label32.BackColor = System.Drawing.Color.Transparent
      Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label32.ForeColor = System.Drawing.Color.Black
      Me.Label32.Location = New System.Drawing.Point(253, 217)
      Me.Label32.Name = "Label32"
      Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label32.Size = New System.Drawing.Size(104, 13)
      Me.Label32.TabIndex = 247
      Me.Label32.Text = "Canale provenienza:"
      '
      'cmbCanaleVendita
      '
      Me.cmbCanaleVendita.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCanaleVendita.Location = New System.Drawing.Point(363, 217)
      Me.cmbCanaleVendita.Name = "cmbCanaleVendita"
      Me.cmbCanaleVendita.Size = New System.Drawing.Size(160, 21)
      Me.cmbCanaleVendita.TabIndex = 17
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(32, 248)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(48, 13)
      Me.Label31.TabIndex = 245
      Me.Label31.Text = "Agenzia:"
      '
      'cmbGruppo
      '
      Me.cmbGruppo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbGruppo.Location = New System.Drawing.Point(112, 217)
      Me.cmbGruppo.Name = "cmbGruppo"
      Me.cmbGruppo.Size = New System.Drawing.Size(136, 21)
      Me.cmbGruppo.TabIndex = 16
      '
      'Label30
      '
      Me.Label30.AutoSize = True
      Me.Label30.BackColor = System.Drawing.Color.Transparent
      Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label30.ForeColor = System.Drawing.Color.Black
      Me.Label30.Location = New System.Drawing.Point(33, 217)
      Me.Label30.Name = "Label30"
      Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label30.Size = New System.Drawing.Size(45, 13)
      Me.Label30.TabIndex = 243
      Me.Label30.Text = "Gruppo:"
      '
      'cmdNuovoIntestatario
      '
      Me.cmdNuovoIntestatario.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdNuovoIntestatario.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNuovoIntestatario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdNuovoIntestatario.Location = New System.Drawing.Point(499, 100)
      Me.cmdNuovoIntestatario.Name = "cmdNuovoIntestatario"
      Me.cmdNuovoIntestatario.Size = New System.Drawing.Size(24, 22)
      Me.cmdNuovoIntestatario.TabIndex = 8
      Me.cmdNuovoIntestatario.Tag = ""
      Me.cmdNuovoIntestatario.Text = "+"
      Me.ToolTip1.SetToolTip(Me.cmdNuovoIntestatario, "Apre la finestra Clienti per un nuovo inserimento.")
      '
      'ckbSchedina
      '
      Me.ckbSchedina.AutoSize = True
      Me.ckbSchedina.Location = New System.Drawing.Point(363, 247)
      Me.ckbSchedina.Name = "ckbSchedina"
      Me.ckbSchedina.Size = New System.Drawing.Size(94, 17)
      Me.ckbSchedina.TabIndex = 19
      Me.ckbSchedina.Text = "Schedina P.S."
      Me.ckbSchedina.UseVisualStyleBackColor = True
      '
      'nudNeonati
      '
      Me.nudNeonati.Location = New System.Drawing.Point(232, 127)
      Me.nudNeonati.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me.nudNeonati.Name = "nudNeonati"
      Me.nudNeonati.Size = New System.Drawing.Size(48, 20)
      Me.nudNeonati.TabIndex = 10
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(167, 127)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(65, 13)
      Me.Label21.TabIndex = 241
      Me.Label21.Text = "Neonati 0-2:"
      '
      'nudRagazzi
      '
      Me.nudRagazzi.Location = New System.Drawing.Point(475, 127)
      Me.nudRagazzi.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me.nudRagazzi.Name = "nudRagazzi"
      Me.nudRagazzi.Size = New System.Drawing.Size(48, 20)
      Me.nudRagazzi.TabIndex = 12
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(419, 127)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(48, 13)
      Me.Label19.TabIndex = 239
      Me.Label19.Text = "Ragazzi:"
      '
      'cmbNome
      '
      Me.cmbNome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNome.Location = New System.Drawing.Point(529, 101)
      Me.cmbNome.Name = "cmbNome"
      Me.cmbNome.Size = New System.Drawing.Size(24, 21)
      Me.cmbNome.TabIndex = 237
      Me.cmbNome.Visible = False
      '
      'cmbIdCliente
      '
      Me.cmbIdCliente.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdCliente.Location = New System.Drawing.Point(88, 100)
      Me.cmbIdCliente.Name = "cmbIdCliente"
      Me.cmbIdCliente.Size = New System.Drawing.Size(24, 21)
      Me.cmbIdCliente.TabIndex = 236
      Me.cmbIdCliente.Visible = False
      '
      'txtNome
      '
      Me.txtNome.AcceptsReturn = True
      Me.txtNome.BackColor = System.Drawing.SystemColors.Window
      Me.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNome.Location = New System.Drawing.Point(346, 101)
      Me.txtNome.MaxLength = 0
      Me.txtNome.Name = "txtNome"
      Me.txtNome.ReadOnly = True
      Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNome.Size = New System.Drawing.Size(131, 20)
      Me.txtNome.TabIndex = 6
      Me.txtNome.TabStop = False
      '
      'cmbCognome
      '
      Me.cmbCognome.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbCognome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbCognome.Location = New System.Drawing.Point(112, 100)
      Me.cmbCognome.Name = "cmbCognome"
      Me.cmbCognome.Size = New System.Drawing.Size(232, 21)
      Me.cmbCognome.TabIndex = 5
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.White
      Me.Panel2.Controls.Add(Me.mcDataArrivo)
      Me.Panel2.Controls.Add(Me.txtNumeroNotti)
      Me.Panel2.Controls.Add(Me.Label27)
      Me.Panel2.Controls.Add(Me.dtpOraArrivo)
      Me.Panel2.Controls.Add(Me.Label28)
      Me.Panel2.Controls.Add(Me.lblPartenza)
      Me.Panel2.Controls.Add(Me.lblArrivo)
      Me.Panel2.Controls.Add(Me.mcDataPartenza)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 279)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(568, 238)
      Me.Panel2.TabIndex = 232
      '
      'mcDataArrivo
      '
      Me.mcDataArrivo.Location = New System.Drawing.Point(32, 34)
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
      Me.txtNumeroNotti.Location = New System.Drawing.Point(440, 210)
      Me.txtNumeroNotti.MaxLength = 0
      Me.txtNumeroNotti.Name = "txtNumeroNotti"
      Me.txtNumeroNotti.ReadOnly = True
      Me.txtNumeroNotti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumeroNotti.Size = New System.Drawing.Size(80, 20)
      Me.txtNumeroNotti.TabIndex = 3
      Me.txtNumeroNotti.TabStop = False
      Me.txtNumeroNotti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.BackColor = System.Drawing.Color.Transparent
      Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label27.ForeColor = System.Drawing.Color.Black
      Me.Label27.Location = New System.Drawing.Point(360, 210)
      Me.Label27.Name = "Label27"
      Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label27.Size = New System.Drawing.Size(70, 13)
      Me.Label27.TabIndex = 237
      Me.Label27.Text = "Numero notti:"
      '
      'dtpOraArrivo
      '
      Me.dtpOraArrivo.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpOraArrivo.Location = New System.Drawing.Point(104, 210)
      Me.dtpOraArrivo.Name = "dtpOraArrivo"
      Me.dtpOraArrivo.ShowUpDown = True
      Me.dtpOraArrivo.Size = New System.Drawing.Size(80, 20)
      Me.dtpOraArrivo.TabIndex = 2
      Me.dtpOraArrivo.Value = New Date(2014, 8, 27, 17, 52, 25, 0)
      '
      'Label28
      '
      Me.Label28.AutoSize = True
      Me.Label28.BackColor = System.Drawing.Color.Transparent
      Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label28.ForeColor = System.Drawing.Color.Black
      Me.Label28.Location = New System.Drawing.Point(32, 210)
      Me.Label28.Name = "Label28"
      Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label28.Size = New System.Drawing.Size(67, 13)
      Me.Label28.TabIndex = 236
      Me.Label28.Text = "Ora di arrivo:"
      '
      'lblPartenza
      '
      Me.lblPartenza.AutoSize = True
      Me.lblPartenza.BackColor = System.Drawing.Color.Transparent
      Me.lblPartenza.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblPartenza.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblPartenza.ForeColor = System.Drawing.Color.Green
      Me.lblPartenza.Location = New System.Drawing.Point(295, 13)
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
      Me.lblArrivo.Location = New System.Drawing.Point(31, 13)
      Me.lblArrivo.Name = "lblArrivo"
      Me.lblArrivo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblArrivo.Size = New System.Drawing.Size(47, 15)
      Me.lblArrivo.TabIndex = 232
      Me.lblArrivo.Text = "Arrivo:"
      '
      'mcDataPartenza
      '
      Me.mcDataPartenza.Location = New System.Drawing.Point(295, 34)
      Me.mcDataPartenza.MaxSelectionCount = 1
      Me.mcDataPartenza.Name = "mcDataPartenza"
      Me.mcDataPartenza.ShowToday = False
      Me.mcDataPartenza.ShowTodayCircle = False
      Me.mcDataPartenza.TabIndex = 1
      '
      'cmbStatoPren
      '
      Me.cmbStatoPren.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStatoPren.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbStatoPren.Location = New System.Drawing.Point(363, 66)
      Me.cmbStatoPren.Name = "cmbStatoPren"
      Me.cmbStatoPren.Size = New System.Drawing.Size(160, 21)
      Me.cmbStatoPren.TabIndex = 4
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(258, 69)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(99, 13)
      Me.Label13.TabIndex = 231
      Me.Label13.Text = "Stato prenotazione:"
      '
      'nudBambini
      '
      Me.nudBambini.Location = New System.Drawing.Point(352, 127)
      Me.nudBambini.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me.nudBambini.Name = "nudBambini"
      Me.nudBambini.Size = New System.Drawing.Size(48, 20)
      Me.nudBambini.TabIndex = 11
      '
      'nudAdulti
      '
      Me.nudAdulti.Location = New System.Drawing.Point(112, 127)
      Me.nudAdulti.Maximum = New Decimal(New Integer() {1000, 0, 0, 0})
      Me.nudAdulti.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudAdulti.Name = "nudAdulti"
      Me.nudAdulti.Size = New System.Drawing.Size(48, 20)
      Me.nudAdulti.TabIndex = 9
      Me.nudAdulti.ThousandsSeparator = True
      Me.nudAdulti.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'txtNumero
      '
      Me.txtNumero.AcceptsReturn = True
      Me.txtNumero.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumero.ForeColor = System.Drawing.Color.Red
      Me.txtNumero.Location = New System.Drawing.Point(363, 14)
      Me.txtNumero.MaxLength = 0
      Me.txtNumero.Name = "txtNumero"
      Me.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumero.Size = New System.Drawing.Size(160, 20)
      Me.txtNumero.TabIndex = 1
      Me.txtNumero.TabStop = False
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(258, 14)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(47, 13)
      Me.Label12.TabIndex = 200
      Me.Label12.Text = "Numero:"
      '
      'txtDescrizioneCamera
      '
      Me.txtDescrizioneCamera.AcceptsReturn = True
      Me.txtDescrizioneCamera.BackColor = System.Drawing.SystemColors.Window
      Me.txtDescrizioneCamera.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDescrizioneCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDescrizioneCamera.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtDescrizioneCamera.Location = New System.Drawing.Point(259, 154)
      Me.txtDescrizioneCamera.MaxLength = 0
      Me.txtDescrizioneCamera.Name = "txtDescrizioneCamera"
      Me.txtDescrizioneCamera.ReadOnly = True
      Me.txtDescrizioneCamera.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDescrizioneCamera.Size = New System.Drawing.Size(264, 20)
      Me.txtDescrizioneCamera.TabIndex = 14
      Me.txtDescrizioneCamera.TabStop = False
      '
      'cmbNumeroCamera
      '
      Me.cmbNumeroCamera.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNumeroCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbNumeroCamera.Location = New System.Drawing.Point(112, 153)
      Me.cmbNumeroCamera.Name = "cmbNumeroCamera"
      Me.cmbNumeroCamera.Size = New System.Drawing.Size(136, 21)
      Me.cmbNumeroCamera.TabIndex = 13
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(32, 153)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(46, 13)
      Me.Label11.TabIndex = 197
      Me.Label11.Text = "Camera:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(287, 127)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(65, 13)
      Me.Label10.TabIndex = 195
      Me.Label10.Text = "Bambini 3-6:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(32, 127)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(36, 13)
      Me.Label1.TabIndex = 194
      Me.Label1.Text = "Adulti:"
      '
      'cmdColore
      '
      Me.cmdColore.BackColor = System.Drawing.Color.White
      Me.cmdColore.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColore.Location = New System.Drawing.Point(363, 40)
      Me.cmdColore.Name = "cmdColore"
      Me.cmdColore.Size = New System.Drawing.Size(160, 20)
      Me.cmdColore.TabIndex = 20
      Me.cmdColore.UseVisualStyleBackColor = False
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(258, 40)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(40, 13)
      Me.Label8.TabIndex = 193
      Me.Label8.Text = "Colore:"
      '
      'dtpData
      '
      Me.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpData.Location = New System.Drawing.Point(112, 40)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(130, 20)
      Me.dtpData.TabIndex = 2
      Me.dtpData.Value = New Date(2005, 8, 17, 15, 37, 0, 654)
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(32, 40)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(33, 13)
      Me.Label7.TabIndex = 189
      Me.Label7.Text = "Data:"
      '
      'cmbTrattamento
      '
      Me.cmbTrattamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTrattamento.Items.AddRange(New Object() {"PN - Pernottamento", "BB - Pernottamento e prima colazione", "MP - Mezza Pensione", "PC - Pensione Completa"})
      Me.cmbTrattamento.Location = New System.Drawing.Point(112, 185)
      Me.cmbTrattamento.Name = "cmbTrattamento"
      Me.cmbTrattamento.Size = New System.Drawing.Size(411, 21)
      Me.cmbTrattamento.TabIndex = 15
      '
      'cmdApriIntestatario
      '
      Me.cmdApriIntestatario.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdApriIntestatario.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdApriIntestatario.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriIntestatario.Location = New System.Drawing.Point(477, 100)
      Me.cmdApriIntestatario.Name = "cmdApriIntestatario"
      Me.cmdApriIntestatario.Size = New System.Drawing.Size(24, 22)
      Me.cmdApriIntestatario.TabIndex = 7
      Me.cmdApriIntestatario.Tag = ""
      Me.cmdApriIntestatario.Text = "..."
      Me.ToolTip1.SetToolTip(Me.cmdApriIntestatario, "Apre la finestra Clienti per la modifica dei dati.")
      '
      'cmbTipologia
      '
      Me.cmbTipologia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipologia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipologia.Items.AddRange(New Object() {"Ospite Singolo", "Capo Famiglia", "Capo Gruppo"})
      Me.cmbTipologia.Location = New System.Drawing.Point(112, 66)
      Me.cmbTipologia.Name = "cmbTipologia"
      Me.cmbTipologia.Size = New System.Drawing.Size(130, 21)
      Me.cmbTipologia.TabIndex = 3
      '
      'txtCodice
      '
      Me.txtCodice.AcceptsReturn = True
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodice.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.Red
      Me.txtCodice.Location = New System.Drawing.Point(112, 14)
      Me.txtCodice.MaxLength = 0
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.ReadOnly = True
      Me.txtCodice.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodice.Size = New System.Drawing.Size(130, 20)
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
      Me.Label5.Location = New System.Drawing.Point(32, 14)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(43, 13)
      Me.Label5.TabIndex = 164
      Me.Label5.Text = "Codice:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(32, 185)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(78, 13)
      Me.Label3.TabIndex = 162
      Me.Label3.Text = "Arrangiamento:"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(32, 100)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(62, 13)
      Me.Label20.TabIndex = 153
      Me.Label20.Text = "Intestatario:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(32, 69)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(79, 13)
      Me.Label4.TabIndex = 163
      Me.Label4.Text = "Tipo alloggiato:"
      '
      'TabPage3
      '
      Me.TabPage3.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage3.Controls.Add(Me.cmdInserisciOccupanti)
      Me.TabPage3.Controls.Add(Me.cmdEliminaOccupanti)
      Me.TabPage3.Controls.Add(Me.lvwOccupanti)
      Me.TabPage3.Location = New System.Drawing.Point(4, 22)
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(568, 517)
      Me.TabPage3.TabIndex = 7
      Me.TabPage3.Text = "Altri componenti"
      '
      'cmdInserisciOccupanti
      '
      Me.cmdInserisciOccupanti.Id = "8485d232-a43b-4483-a6a6-c15e4f570a9b"
      Me.cmdInserisciOccupanti.Location = New System.Drawing.Point(345, 480)
      Me.cmdInserisciOccupanti.Name = "cmdInserisciOccupanti"
      Me.cmdInserisciOccupanti.Size = New System.Drawing.Size(104, 32)
      Me.cmdInserisciOccupanti.TabIndex = 1
      Me.cmdInserisciOccupanti.Text = "&Inserisci"
      '
      'cmdEliminaOccupanti
      '
      Me.cmdEliminaOccupanti.Id = "6c1360cb-165c-4af0-9574-c4c5088a37f3"
      Me.cmdEliminaOccupanti.Location = New System.Drawing.Point(457, 480)
      Me.cmdEliminaOccupanti.Name = "cmdEliminaOccupanti"
      Me.cmdEliminaOccupanti.Size = New System.Drawing.Size(104, 32)
      Me.cmdEliminaOccupanti.TabIndex = 2
      Me.cmdEliminaOccupanti.Text = "&Elimina"
      '
      'lvwOccupanti
      '
      Me.lvwOccupanti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader14, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader1, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader13, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader12})
      Me.lvwOccupanti.Dock = System.Windows.Forms.DockStyle.Top
      Me.lvwOccupanti.FullRowSelect = True
      Me.lvwOccupanti.Location = New System.Drawing.Point(0, 0)
      Me.lvwOccupanti.MultiSelect = False
      Me.lvwOccupanti.Name = "lvwOccupanti"
      Me.lvwOccupanti.Size = New System.Drawing.Size(568, 477)
      Me.lvwOccupanti.TabIndex = 0
      Me.lvwOccupanti.UseCompatibleStateImageBehavior = False
      Me.lvwOccupanti.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader14
      '
      Me.ColumnHeader14.Text = "Indice"
      Me.ColumnHeader14.Width = 0
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Text = "Cognome"
      Me.ColumnHeader7.Width = 150
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Text = "Nome"
      Me.ColumnHeader8.Width = 100
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Sesso"
      Me.ColumnHeader1.Width = 50
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Text = "Data di Nascita"
      Me.ColumnHeader9.Width = 90
      '
      'ColumnHeader10
      '
      Me.ColumnHeader10.Text = "Luogo di Nascita"
      Me.ColumnHeader10.Width = 120
      '
      'ColumnHeader11
      '
      Me.ColumnHeader11.Text = "Prov. Nascita"
      Me.ColumnHeader11.Width = 80
      '
      'ColumnHeader13
      '
      Me.ColumnHeader13.Text = "Nazione Nascita"
      Me.ColumnHeader13.Width = 100
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Permanenza"
      Me.ColumnHeader3.Width = 80
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Text = "Tipo Alloggiato"
      Me.ColumnHeader4.Width = 100
      '
      'ColumnHeader12
      '
      Me.ColumnHeader12.Text = "Codice"
      Me.ColumnHeader12.Width = 0
      '
      'TabPage4
      '
      Me.TabPage4.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage4.Controls.Add(Me.eui_QuantitàMeno)
      Me.TabPage4.Controls.Add(Me.eui_cmdQuantitàPiù)
      Me.TabPage4.Controls.Add(Me.txtTotaleAddebitiExtra)
      Me.TabPage4.Controls.Add(Me.Label6)
      Me.TabPage4.Controls.Add(Me.eui_ddwnInserisciAddebiti)
      Me.TabPage4.Controls.Add(Me.eui_cmdEliminaRiga)
      Me.TabPage4.Controls.Add(Me.lvwAddebiti)
      Me.TabPage4.Location = New System.Drawing.Point(4, 22)
      Me.TabPage4.Name = "TabPage4"
      Me.TabPage4.Size = New System.Drawing.Size(568, 517)
      Me.TabPage4.TabIndex = 8
      Me.TabPage4.Text = "Addebiti extra / Supplementi"
      '
      'eui_QuantitàMeno
      '
      Me.eui_QuantitàMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_QuantitàMeno.Id = "1bdcfa63-a355-45cb-be8c-8396d1251400"
      Me.eui_QuantitàMeno.Location = New System.Drawing.Point(273, 480)
      Me.eui_QuantitàMeno.Name = "eui_QuantitàMeno"
      Me.eui_QuantitàMeno.Size = New System.Drawing.Size(54, 32)
      Me.eui_QuantitàMeno.TabIndex = 4
      Me.eui_QuantitàMeno.Text = "-"
      '
      'eui_cmdQuantitàPiù
      '
      Me.eui_cmdQuantitàPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdQuantitàPiù.Id = "f850f174-e68d-4f90-894f-a82b055c1fc6"
      Me.eui_cmdQuantitàPiù.Location = New System.Drawing.Point(209, 480)
      Me.eui_cmdQuantitàPiù.Name = "eui_cmdQuantitàPiù"
      Me.eui_cmdQuantitàPiù.Size = New System.Drawing.Size(54, 32)
      Me.eui_cmdQuantitàPiù.TabIndex = 3
      Me.eui_cmdQuantitàPiù.Text = "+"
      '
      'txtTotaleAddebitiExtra
      '
      Me.txtTotaleAddebitiExtra.AcceptsReturn = True
      Me.txtTotaleAddebitiExtra.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleAddebitiExtra.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleAddebitiExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleAddebitiExtra.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleAddebitiExtra.Location = New System.Drawing.Point(391, 488)
      Me.txtTotaleAddebitiExtra.MaxLength = 0
      Me.txtTotaleAddebitiExtra.Name = "txtTotaleAddebitiExtra"
      Me.txtTotaleAddebitiExtra.ReadOnly = True
      Me.txtTotaleAddebitiExtra.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleAddebitiExtra.Size = New System.Drawing.Size(164, 20)
      Me.txtTotaleAddebitiExtra.TabIndex = 5
      Me.txtTotaleAddebitiExtra.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(345, 488)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 246
      Me.Label6.Text = "Totale:"
      '
      'eui_ddwnInserisciAddebiti
      '
      Me.eui_ddwnInserisciAddebiti.Id = "ac2efeeb-f5cc-4303-a41e-d5268d684f8a"
      Me.eui_ddwnInserisciAddebiti.Location = New System.Drawing.Point(9, 480)
      Me.eui_ddwnInserisciAddebiti.Name = "eui_ddwnInserisciAddebiti"
      Me.eui_ddwnInserisciAddebiti.Popup = Me.PopupMenu1
      Me.eui_ddwnInserisciAddebiti.Size = New System.Drawing.Size(88, 32)
      Me.eui_ddwnInserisciAddebiti.TabIndex = 1
      Me.eui_ddwnInserisciAddebiti.Text = "&Inserisci"
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
      Me.eui_cmdAccessori.Id = "062a4576-9133-431d-8dfa-d3575a08c7dc"
      Me.eui_cmdAccessori.KeyTip = "A"
      Me.eui_cmdAccessori.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdAccessori.Name = "eui_cmdAccessori"
      Me.eui_cmdAccessori.ScreenTip.Caption = "Accessori"
      Me.eui_cmdAccessori.ScreenTip.Text = "Apre un'elenco per l'inserimento degli accessori."
      Me.eui_cmdAccessori.Size = New System.Drawing.Size(164, 23)
      Me.eui_cmdAccessori.TabIndex = 3
      Me.eui_cmdAccessori.Text = "&Accessori"
      '
      'eui_cmdServizi
      '
      Me.eui_cmdServizi.Id = "248a545d-fdd9-48f5-8349-a6aed50a16b0"
      Me.eui_cmdServizi.KeyTip = "S"
      Me.eui_cmdServizi.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdServizi.Name = "eui_cmdServizi"
      Me.eui_cmdServizi.ScreenTip.Caption = "Servizi"
      Me.eui_cmdServizi.ScreenTip.Text = "Apre un'elenco per l'inserimento dei servizi."
      Me.eui_cmdServizi.Size = New System.Drawing.Size(164, 23)
      Me.eui_cmdServizi.TabIndex = 4
      Me.eui_cmdServizi.Text = "&Servizi / Trattamenti"
      '
      'Separator1
      '
      Me.Separator1.Id = "e3ce86f5-050c-4d5a-af24-0f65a6e38cc9"
      Me.Separator1.Location = New System.Drawing.Point(2, 48)
      Me.Separator1.Name = "Separator1"
      Me.Separator1.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator1.Size = New System.Drawing.Size(164, 5)
      Me.Separator1.TabIndex = 6
      Me.Separator1.Text = "Separator1"
      '
      'eui_cmdApriPos
      '
      Me.eui_cmdApriPos.Id = "43c34c34-cefe-4450-8cb4-d84669cf19d4"
      Me.eui_cmdApriPos.KeyTip = "P"
      Me.eui_cmdApriPos.Location = New System.Drawing.Point(2, 53)
      Me.eui_cmdApriPos.Name = "eui_cmdApriPos"
      Me.eui_cmdApriPos.ScreenTip.Caption = "Apri Punto cassa"
      Me.eui_cmdApriPos.ScreenTip.Text = "Apre il Punto cassa per l'inserimento di prodotti vari."
      Me.eui_cmdApriPos.Size = New System.Drawing.Size(164, 23)
      Me.eui_cmdApriPos.TabIndex = 5
      Me.eui_cmdApriPos.Text = "Apri &Punto cassa"
      '
      'eui_cmdEliminaRiga
      '
      Me.eui_cmdEliminaRiga.Id = "a92e1ccd-83b1-4aba-bc06-de0f6becb4f3"
      Me.eui_cmdEliminaRiga.Location = New System.Drawing.Point(105, 480)
      Me.eui_cmdEliminaRiga.Name = "eui_cmdEliminaRiga"
      Me.eui_cmdEliminaRiga.Size = New System.Drawing.Size(88, 32)
      Me.eui_cmdEliminaRiga.TabIndex = 2
      Me.eui_cmdEliminaRiga.Text = "&Elimina riga"
      '
      'lvwAddebiti
      '
      Me.lvwAddebiti.AllowColumnReorder = True
      Me.lvwAddebiti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.clnData, Me.clnDescrizione, Me.clnQta, Me.clnImporto, Me.clnCodice, Me.clnIndice, Me.clnAliquotaIva, Me.clnCategoria, Me.ColumnHeader2})
      Me.lvwAddebiti.Dock = System.Windows.Forms.DockStyle.Top
      Me.lvwAddebiti.FullRowSelect = True
      ListViewGroup1.Header = "Articoli vari"
      ListViewGroup1.Name = "ListViewGroup1"
      ListViewGroup2.Header = "Accessori"
      ListViewGroup2.Name = "ListViewGroup2"
      ListViewGroup3.Header = "Servizi"
      ListViewGroup3.Name = "ListViewGroup3"
      ListViewGroup4.Header = "Bar/Ristorante"
      ListViewGroup4.Name = "ListViewGroup4"
      Me.lvwAddebiti.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup1, ListViewGroup2, ListViewGroup3, ListViewGroup4})
      Me.lvwAddebiti.Location = New System.Drawing.Point(0, 0)
      Me.lvwAddebiti.MultiSelect = False
      Me.lvwAddebiti.Name = "lvwAddebiti"
      Me.lvwAddebiti.Size = New System.Drawing.Size(568, 477)
      Me.lvwAddebiti.TabIndex = 0
      Me.lvwAddebiti.UseCompatibleStateImageBehavior = False
      Me.lvwAddebiti.View = System.Windows.Forms.View.Details
      '
      'clnData
      '
      Me.clnData.Text = "Data"
      Me.clnData.Width = 80
      '
      'clnDescrizione
      '
      Me.clnDescrizione.Text = "Descrizione"
      Me.clnDescrizione.Width = 300
      '
      'clnQta
      '
      Me.clnQta.Text = "Quantità"
      Me.clnQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'clnImporto
      '
      Me.clnImporto.Text = "Importo"
      Me.clnImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.clnImporto.Width = 80
      '
      'clnCodice
      '
      Me.clnCodice.Text = "Codice"
      Me.clnCodice.Width = 0
      '
      'clnIndice
      '
      Me.clnIndice.Text = "Indice"
      Me.clnIndice.Width = 0
      '
      'clnAliquotaIva
      '
      Me.clnAliquotaIva.Width = 0
      '
      'clnCategoria
      '
      Me.clnCategoria.Width = 0
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Width = 0
      '
      'TabPage7
      '
      Me.TabPage7.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage7.Controls.Add(Me.txtTotaleImporto)
      Me.TabPage7.Controls.Add(Me.txtTassaSoggiorno)
      Me.TabPage7.Controls.Add(Me.Label29)
      Me.TabPage7.Controls.Add(Me.cmbIdListino)
      Me.TabPage7.Controls.Add(Me.txtTotaleTassaSoggiorno)
      Me.TabPage7.Controls.Add(Me.Label26)
      Me.TabPage7.Controls.Add(Me.txtTotaleIncassare)
      Me.TabPage7.Controls.Add(Me.Label25)
      Me.TabPage7.Controls.Add(Me.txtServizio)
      Me.TabPage7.Controls.Add(Me.Label24)
      Me.TabPage7.Controls.Add(Me.txtSconto)
      Me.TabPage7.Controls.Add(Me.Label22)
      Me.TabPage7.Controls.Add(Me.cmbApplicaSconto)
      Me.TabPage7.Controls.Add(Me.Label23)
      Me.TabPage7.Controls.Add(Me.txtTotaleAddebiti)
      Me.TabPage7.Controls.Add(Me.Label15)
      Me.TabPage7.Controls.Add(Me.txtTotaleConto)
      Me.TabPage7.Controls.Add(Me.Label14)
      Me.TabPage7.Controls.Add(Me.txtAccontoCamera)
      Me.TabPage7.Controls.Add(Me.Label18)
      Me.TabPage7.Controls.Add(Me.txtPrezzoCamera)
      Me.TabPage7.Controls.Add(Me.txtTotaleCostoCamera)
      Me.TabPage7.Controls.Add(Me.Label16)
      Me.TabPage7.Controls.Add(Me.Label17)
      Me.TabPage7.Controls.Add(Me.cmbListino)
      Me.TabPage7.Controls.Add(Me.Label9)
      Me.TabPage7.Controls.Add(Me.cmbPagamento)
      Me.TabPage7.Controls.Add(Me.Label2)
      Me.TabPage7.Location = New System.Drawing.Point(4, 22)
      Me.TabPage7.Name = "TabPage7"
      Me.TabPage7.Size = New System.Drawing.Size(568, 517)
      Me.TabPage7.TabIndex = 9
      Me.TabPage7.Text = "Gestione Conto"
      '
      'txtTotaleImporto
      '
      Me.txtTotaleImporto.AcceptsReturn = True
      Me.txtTotaleImporto.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleImporto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleImporto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleImporto.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleImporto.Location = New System.Drawing.Point(160, 237)
      Me.txtTotaleImporto.MaxLength = 0
      Me.txtTotaleImporto.Name = "txtTotaleImporto"
      Me.txtTotaleImporto.ReadOnly = True
      Me.txtTotaleImporto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleImporto.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleImporto.TabIndex = 258
      Me.txtTotaleImporto.TabStop = False
      Me.txtTotaleImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtTotaleImporto.Visible = False
      '
      'txtTassaSoggiorno
      '
      Me.txtTassaSoggiorno.AcceptsReturn = True
      Me.txtTassaSoggiorno.BackColor = System.Drawing.SystemColors.Window
      Me.txtTassaSoggiorno.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTassaSoggiorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTassaSoggiorno.ForeColor = System.Drawing.Color.Blue
      Me.txtTassaSoggiorno.Location = New System.Drawing.Point(160, 122)
      Me.txtTassaSoggiorno.MaxLength = 0
      Me.txtTassaSoggiorno.Name = "txtTassaSoggiorno"
      Me.txtTassaSoggiorno.ReadOnly = True
      Me.txtTassaSoggiorno.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTassaSoggiorno.Size = New System.Drawing.Size(104, 20)
      Me.txtTassaSoggiorno.TabIndex = 257
      Me.txtTassaSoggiorno.TabStop = False
      Me.txtTassaSoggiorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtTassaSoggiorno.Visible = False
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.BackColor = System.Drawing.Color.Transparent
      Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label29.ForeColor = System.Drawing.Color.Black
      Me.Label29.Location = New System.Drawing.Point(32, 122)
      Me.Label29.Name = "Label29"
      Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label29.Size = New System.Drawing.Size(99, 13)
      Me.Label29.TabIndex = 256
      Me.Label29.Text = "Tassa di soggiorno:"
      Me.Label29.Visible = False
      '
      'cmbIdListino
      '
      Me.cmbIdListino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIdListino.Location = New System.Drawing.Point(128, 24)
      Me.cmbIdListino.Name = "cmbIdListino"
      Me.cmbIdListino.Size = New System.Drawing.Size(24, 21)
      Me.cmbIdListino.TabIndex = 255
      Me.cmbIdListino.Visible = False
      '
      'txtTotaleTassaSoggiorno
      '
      Me.txtTotaleTassaSoggiorno.AcceptsReturn = True
      Me.txtTotaleTassaSoggiorno.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleTassaSoggiorno.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleTassaSoggiorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleTassaSoggiorno.ForeColor = System.Drawing.Color.Blue
      Me.txtTotaleTassaSoggiorno.Location = New System.Drawing.Point(416, 123)
      Me.txtTotaleTassaSoggiorno.MaxLength = 0
      Me.txtTotaleTassaSoggiorno.Name = "txtTotaleTassaSoggiorno"
      Me.txtTotaleTassaSoggiorno.ReadOnly = True
      Me.txtTotaleTassaSoggiorno.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleTassaSoggiorno.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleTassaSoggiorno.TabIndex = 4
      Me.txtTotaleTassaSoggiorno.TabStop = False
      Me.txtTotaleTassaSoggiorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label26
      '
      Me.Label26.AutoSize = True
      Me.Label26.BackColor = System.Drawing.Color.Transparent
      Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label26.ForeColor = System.Drawing.Color.Black
      Me.Label26.Location = New System.Drawing.Point(280, 123)
      Me.Label26.Name = "Label26"
      Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label26.Size = New System.Drawing.Size(128, 13)
      Me.Label26.TabIndex = 254
      Me.Label26.Text = "Totale tassa di soggiorno:"
      '
      'txtTotaleIncassare
      '
      Me.txtTotaleIncassare.AcceptsReturn = True
      Me.txtTotaleIncassare.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleIncassare.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleIncassare.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleIncassare.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleIncassare.Location = New System.Drawing.Point(416, 293)
      Me.txtTotaleIncassare.MaxLength = 0
      Me.txtTotaleIncassare.Name = "txtTotaleIncassare"
      Me.txtTotaleIncassare.ReadOnly = True
      Me.txtTotaleIncassare.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleIncassare.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleIncassare.TabIndex = 11
      Me.txtTotaleIncassare.TabStop = False
      Me.txtTotaleIncassare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.BackColor = System.Drawing.Color.Transparent
      Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label25.ForeColor = System.Drawing.Color.Black
      Me.Label25.Location = New System.Drawing.Point(280, 293)
      Me.Label25.Name = "Label25"
      Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label25.Size = New System.Drawing.Size(103, 13)
      Me.Label25.TabIndex = 252
      Me.Label25.Text = "Totale da incassare:"
      '
      'txtServizio
      '
      Me.txtServizio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtServizio.ForeColor = System.Drawing.Color.Black
      Me.txtServizio.Location = New System.Drawing.Point(416, 181)
      Me.txtServizio.MaxLength = 0
      Me.txtServizio.Name = "txtServizio"
      Me.txtServizio.Size = New System.Drawing.Size(104, 20)
      Me.txtServizio.TabIndex = 6
      Me.txtServizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.BackColor = System.Drawing.Color.Transparent
      Me.Label24.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label24.ForeColor = System.Drawing.Color.Black
      Me.Label24.Location = New System.Drawing.Point(280, 181)
      Me.Label24.Name = "Label24"
      Me.Label24.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label24.Size = New System.Drawing.Size(58, 13)
      Me.Label24.TabIndex = 250
      Me.Label24.Text = "% Servizio:"
      '
      'txtSconto
      '
      Me.txtSconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSconto.ForeColor = System.Drawing.Color.Black
      Me.txtSconto.Location = New System.Drawing.Point(416, 205)
      Me.txtSconto.MaxLength = 0
      Me.txtSconto.Name = "txtSconto"
      Me.txtSconto.Size = New System.Drawing.Size(104, 20)
      Me.txtSconto.TabIndex = 8
      Me.txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.BackColor = System.Drawing.Color.Transparent
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(280, 205)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(55, 13)
      Me.Label22.TabIndex = 248
      Me.Label22.Text = "% Sconto:"
      '
      'cmbApplicaSconto
      '
      Me.cmbApplicaSconto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbApplicaSconto.Items.AddRange(New Object() {"Totale camera", "Totale conto"})
      Me.cmbApplicaSconto.Location = New System.Drawing.Point(160, 205)
      Me.cmbApplicaSconto.Name = "cmbApplicaSconto"
      Me.cmbApplicaSconto.Size = New System.Drawing.Size(104, 21)
      Me.cmbApplicaSconto.TabIndex = 7
      Me.cmbApplicaSconto.Visible = False
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.BackColor = System.Drawing.Color.Transparent
      Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label23.ForeColor = System.Drawing.Color.Black
      Me.Label23.Location = New System.Drawing.Point(32, 205)
      Me.Label23.Name = "Label23"
      Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label23.Size = New System.Drawing.Size(107, 13)
      Me.Label23.TabIndex = 247
      Me.Label23.Text = "Applica lo sconto sul:"
      Me.Label23.Visible = False
      '
      'txtTotaleAddebiti
      '
      Me.txtTotaleAddebiti.AcceptsReturn = True
      Me.txtTotaleAddebiti.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleAddebiti.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleAddebiti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleAddebiti.ForeColor = System.Drawing.Color.Black
      Me.txtTotaleAddebiti.Location = New System.Drawing.Point(416, 149)
      Me.txtTotaleAddebiti.MaxLength = 0
      Me.txtTotaleAddebiti.Name = "txtTotaleAddebiti"
      Me.txtTotaleAddebiti.ReadOnly = True
      Me.txtTotaleAddebiti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleAddebiti.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleAddebiti.TabIndex = 5
      Me.txtTotaleAddebiti.TabStop = False
      Me.txtTotaleAddebiti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.BackColor = System.Drawing.Color.Transparent
      Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label15.ForeColor = System.Drawing.Color.Black
      Me.Label15.Location = New System.Drawing.Point(280, 152)
      Me.Label15.Name = "Label15"
      Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label15.Size = New System.Drawing.Size(106, 13)
      Me.Label15.TabIndex = 214
      Me.Label15.Text = "Totale addebiti extra:"
      '
      'txtTotaleConto
      '
      Me.txtTotaleConto.AcceptsReturn = True
      Me.txtTotaleConto.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleConto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleConto.ForeColor = System.Drawing.Color.Red
      Me.txtTotaleConto.Location = New System.Drawing.Point(416, 237)
      Me.txtTotaleConto.MaxLength = 0
      Me.txtTotaleConto.Name = "txtTotaleConto"
      Me.txtTotaleConto.ReadOnly = True
      Me.txtTotaleConto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleConto.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleConto.TabIndex = 9
      Me.txtTotaleConto.TabStop = False
      Me.txtTotaleConto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(280, 237)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(70, 13)
      Me.Label14.TabIndex = 212
      Me.Label14.Text = "Totale conto:"
      '
      'txtAccontoCamera
      '
      Me.txtAccontoCamera.AcceptsReturn = True
      Me.txtAccontoCamera.BackColor = System.Drawing.SystemColors.Window
      Me.txtAccontoCamera.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtAccontoCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtAccontoCamera.ForeColor = System.Drawing.Color.DarkGreen
      Me.txtAccontoCamera.Location = New System.Drawing.Point(416, 261)
      Me.txtAccontoCamera.MaxLength = 0
      Me.txtAccontoCamera.Name = "txtAccontoCamera"
      Me.txtAccontoCamera.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtAccontoCamera.Size = New System.Drawing.Size(104, 20)
      Me.txtAccontoCamera.TabIndex = 10
      Me.txtAccontoCamera.TabStop = False
      Me.txtAccontoCamera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.ForeColor = System.Drawing.Color.Black
      Me.Label18.Location = New System.Drawing.Point(280, 261)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(50, 13)
      Me.Label18.TabIndex = 210
      Me.Label18.Text = "Acconto:"
      '
      'txtPrezzoCamera
      '
      Me.txtPrezzoCamera.BackColor = System.Drawing.SystemColors.Window
      Me.txtPrezzoCamera.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPrezzoCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPrezzoCamera.ForeColor = System.Drawing.Color.Black
      Me.txtPrezzoCamera.Location = New System.Drawing.Point(160, 96)
      Me.txtPrezzoCamera.MaxLength = 0
      Me.txtPrezzoCamera.Name = "txtPrezzoCamera"
      Me.txtPrezzoCamera.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPrezzoCamera.Size = New System.Drawing.Size(104, 20)
      Me.txtPrezzoCamera.TabIndex = 2
      Me.txtPrezzoCamera.TabStop = False
      Me.txtPrezzoCamera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotaleCostoCamera
      '
      Me.txtTotaleCostoCamera.AcceptsReturn = True
      Me.txtTotaleCostoCamera.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotaleCostoCamera.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleCostoCamera.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleCostoCamera.ForeColor = System.Drawing.Color.Black
      Me.txtTotaleCostoCamera.Location = New System.Drawing.Point(416, 96)
      Me.txtTotaleCostoCamera.MaxLength = 0
      Me.txtTotaleCostoCamera.Name = "txtTotaleCostoCamera"
      Me.txtTotaleCostoCamera.ReadOnly = True
      Me.txtTotaleCostoCamera.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleCostoCamera.Size = New System.Drawing.Size(104, 20)
      Me.txtTotaleCostoCamera.TabIndex = 3
      Me.txtTotaleCostoCamera.TabStop = False
      Me.txtTotaleCostoCamera.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(280, 96)
      Me.Label16.Name = "Label16"
      Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label16.Size = New System.Drawing.Size(78, 13)
      Me.Label16.TabIndex = 207
      Me.Label16.Text = "Totale camera:"
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(32, 96)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(120, 13)
      Me.Label17.TabIndex = 206
      Me.Label17.Text = "Prezzo camera / giorno:"
      '
      'cmbListino
      '
      Me.cmbListino.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbListino.Location = New System.Drawing.Point(160, 24)
      Me.cmbListino.Name = "cmbListino"
      Me.cmbListino.Size = New System.Drawing.Size(360, 21)
      Me.cmbListino.TabIndex = 0
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(32, 24)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(40, 13)
      Me.Label9.TabIndex = 205
      Me.Label9.Text = "Listino:"
      '
      'cmbPagamento
      '
      Me.cmbPagamento.Location = New System.Drawing.Point(160, 56)
      Me.cmbPagamento.Name = "cmbPagamento"
      Me.cmbPagamento.Size = New System.Drawing.Size(360, 21)
      Me.cmbPagamento.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(32, 56)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(106, 13)
      Me.Label2.TabIndex = 188
      Me.Label2.Text = "Modalità pagamento:"
      '
      'TabPage5
      '
      Me.TabPage5.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage5.Controls.Add(Me.eui_cmdApri)
      Me.TabPage5.Controls.Add(Me.eui_cmdInserisci)
      Me.TabPage5.Controls.Add(Me.eui_cmdModifica)
      Me.TabPage5.Controls.Add(Me.eui_cmdElimina)
      Me.TabPage5.Controls.Add(Me.lvwAllegati)
      Me.TabPage5.Location = New System.Drawing.Point(4, 22)
      Me.TabPage5.Name = "TabPage5"
      Me.TabPage5.Size = New System.Drawing.Size(568, 517)
      Me.TabPage5.TabIndex = 4
      Me.TabPage5.Text = "Documenti allegati"
      '
      'eui_cmdApri
      '
      Me.eui_cmdApri.Id = "8a5e496a-4502-4174-8645-50e2d9e0f588"
      Me.eui_cmdApri.Location = New System.Drawing.Point(5, 480)
      Me.eui_cmdApri.Name = "eui_cmdApri"
      Me.eui_cmdApri.Size = New System.Drawing.Size(104, 32)
      Me.eui_cmdApri.TabIndex = 1
      Me.eui_cmdApri.Text = "&Apri allegato"
      '
      'eui_cmdInserisci
      '
      Me.eui_cmdInserisci.Id = "4304d4d0-9e05-49ae-8d27-505bd1497a25"
      Me.eui_cmdInserisci.Location = New System.Drawing.Point(234, 480)
      Me.eui_cmdInserisci.Name = "eui_cmdInserisci"
      Me.eui_cmdInserisci.Size = New System.Drawing.Size(104, 32)
      Me.eui_cmdInserisci.TabIndex = 2
      Me.eui_cmdInserisci.Text = "&Inserisci"
      '
      'eui_cmdModifica
      '
      Me.eui_cmdModifica.Id = "00026964-bc08-4678-9f2b-f2bbddda1db3"
      Me.eui_cmdModifica.Location = New System.Drawing.Point(346, 480)
      Me.eui_cmdModifica.Name = "eui_cmdModifica"
      Me.eui_cmdModifica.Size = New System.Drawing.Size(104, 32)
      Me.eui_cmdModifica.TabIndex = 3
      Me.eui_cmdModifica.Text = "&Modifica"
      '
      'eui_cmdElimina
      '
      Me.eui_cmdElimina.Id = "6debe14b-5f4c-4228-9100-e16ab991f767"
      Me.eui_cmdElimina.Location = New System.Drawing.Point(458, 480)
      Me.eui_cmdElimina.Name = "eui_cmdElimina"
      Me.eui_cmdElimina.Size = New System.Drawing.Size(104, 32)
      Me.eui_cmdElimina.TabIndex = 4
      Me.eui_cmdElimina.Text = "&Elimina"
      '
      'lvwAllegati
      '
      Me.lvwAllegati.AllowColumnReorder = True
      Me.lvwAllegati.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21, Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24})
      Me.lvwAllegati.Dock = System.Windows.Forms.DockStyle.Top
      Me.lvwAllegati.Location = New System.Drawing.Point(0, 0)
      Me.lvwAllegati.MultiSelect = False
      Me.lvwAllegati.Name = "lvwAllegati"
      Me.lvwAllegati.Size = New System.Drawing.Size(568, 477)
      Me.lvwAllegati.TabIndex = 0
      Me.lvwAllegati.UseCompatibleStateImageBehavior = False
      Me.lvwAllegati.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader19
      '
      Me.ColumnHeader19.Text = "Documento"
      Me.ColumnHeader19.Width = 200
      '
      'ColumnHeader20
      '
      Me.ColumnHeader20.Text = "Data"
      Me.ColumnHeader20.Width = 75
      '
      'ColumnHeader21
      '
      Me.ColumnHeader21.Text = "Ora"
      Me.ColumnHeader21.Width = 75
      '
      'ColumnHeader22
      '
      Me.ColumnHeader22.Text = "Note"
      Me.ColumnHeader22.Width = 200
      '
      'ColumnHeader23
      '
      Me.ColumnHeader23.Text = "Percorso"
      Me.ColumnHeader23.Width = 500
      '
      'ColumnHeader24
      '
      Me.ColumnHeader24.Text = "Codice"
      Me.ColumnHeader24.Width = 0
      '
      'TabPage6
      '
      Me.TabPage6.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage6.Controls.Add(Me.txtNote)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(576, 527)
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
      Me.txtNote.Size = New System.Drawing.Size(576, 527)
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
      'frmPrenCamera
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(576, 589)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmPrenCamera"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Prenotazione camera"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.nudNeonati, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudRagazzi, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      CType(Me.nudBambini, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.nudAdulti, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage4.ResumeLayout(False)
      Me.TabPage4.PerformLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage7.ResumeLayout(False)
      Me.TabPage7.PerformLayout()
      Me.TabPage5.ResumeLayout(False)
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public IPren As New PrenCamere
   Public IPrenOccupanti As New PrenCamereOccupanti
   Public IPrenAddebiti As New PrenCamereAddebiti
   Public IPrenStorico As New StoricoPresenzeCamere
   Public IAllegati As New Allegati
   Public CSchedina As New SchedinaPS

   Const NOME_TABELLA As String = "PrenCamere"
   Const TAB_CLIENTI As String = "Clienti"
   Const TAB_CAMERE As String = "Camere"
   Const TAB_LISTINO As String = "ListiniCamere"
   Const TAB_PAGAMENTO As String = "ModPagamento"
   Const TAB_ALLEGATI As String = "PrenCamereAllegati"
   Const TAB_STATO_PREN As String = "StatoPren"
   Const TAB_PREN_OCCUPANTI As String = "PrenCamereOccupanti"
   Const TAB_SCHEDINE_OCCUPANTI As String = "ComponentiSchedinePS"
   Const TAB_PREN_ADDEBITI As String = "PrenCamereAddebiti"
   Const TAB_PREN_STORICO As String = "StoricoPresenzeCamere"
   Const TAB_STAGIONI As String = "Stagioni"
   Const TAB_GRUPPI As String = "GruppiOspiti"
   Const TAB_AGENZIE As String = "Agenzie"
   Const TAB_CANALI_PROV As String = "CanaliVendita"
   Public Const TAB_SCHEDINE_PS As String = "SchedinePS"

   Const BASSA_STAGIONE As String = "BASSA"
   Const MEDIA_STAGIONE As String = "MEDIA"
   Const ALTA_STAGIONE As String = "ALTA"

   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress
   Private DatiConfig As AppConfig

   ' Il tipo di finestra che ha effettuato la chiamata.
   Dim tipoFrm As String
   ' Il tipo di Listino - Prezzo a persona o Camera.
   Dim tipoListino As String
   ' Sconto applicato ai bambini.
   Dim scontoNeonato As String
   Dim scontoBambino As String
   Dim scontoRagazzo As String

   ' Servono a sapere se il periodo di prenotazione è stato modificato.
   Dim numCameraPren As String
   Dim dataArrivoPren As Date
   Dim dataPartenzaPren As Date

   ' Serve a sapere se il form è stato caricato.
   Dim loadForm As Boolean = False

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   Public Function SalvaDati() As Boolean

      ' Salva eventuali nuovi valori nelle rispettive tabelle dati.
      AggiornaTabella(cmbPagamento, TAB_PAGAMENTO)
      AggiornaTabella(cmbGruppo, TAB_GRUPPI)
      AggiornaTabella(cmbAgenzia, TAB_AGENZIE)
      AggiornaTabella(cmbCanaleVendita, TAB_CANALI_PROV)

      Try
         With IPren
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .IdCliente = Convert.ToInt32(cmbIdCliente.Text)
            .Numero = Convert.ToInt32(txtNumero.Text)
            .Data = dtpData.Text
            .Tipologia = cmbTipologia.Text
            .Stato = cmbStatoPren.Text
            .Cognome = FormattaApici(cmbCognome.Text)
            .Nome = FormattaApici(txtNome.Text)
            .Nazionalità = LeggiNazionalitàCliente(TAB_CLIENTI, cmbIdCliente.Text)

            If .Nazionalità.ToUpper = "ITALIA" Then
               .Provincia = LeggiProvinciaCliente(TAB_CLIENTI, cmbIdCliente.Text)
            Else
               .Provincia = VALORE_NESSUNA
            End If

            .Adulti = nudAdulti.Value
            .Neonati = nudNeonati.Value
            .Bambini = nudBambini.Value
            .Ragazzi = nudRagazzi.Value
            .NumeroCamera = FormattaApici(cmbNumeroCamera.Text)
            .DescrizioneCamera = txtDescrizioneCamera.Text
            .Trattamento = cmbTrattamento.Text
            .Gruppo = cmbGruppo.Text
            .Agenzia = cmbAgenzia.Text
            .CanaleVendita = cmbCanaleVendita.Text
            .DataArrivo = FormattaData(mcDataArrivo.SelectionRange.Start.Date, True)
            .DataPartenza = FormattaData(mcDataPartenza.SelectionRange.Start.Date, True)
            .OraArrivo = dtpOraArrivo.Text
            .NumeroNotti = Convert.ToInt32(txtNumeroNotti.Text)
            .Listino = cmbListino.Text
            .Pagamento = FormattaApici(cmbPagamento.Text)

            If IsNumeric(txtPrezzoCamera.Text) = True Then
               .CostoCamera = CFormatta.FormattaEuro(Convert.ToDouble(txtPrezzoCamera.Text))
            Else
               .CostoCamera = VALORE_ZERO
            End If
            If IsNumeric(txtTassaSoggiorno.Text) = True Then
               .TassaSoggiorno = CFormatta.FormattaEuro(Convert.ToDouble(txtTassaSoggiorno.Text))
            Else
               .TassaSoggiorno = VALORE_ZERO
            End If
            If IsNumeric(txtAccontoCamera.Text) = True Then
               .AccontoCamera = CFormatta.FormattaEuro(Convert.ToDouble(txtAccontoCamera.Text))
            Else
               .AccontoCamera = VALORE_ZERO
            End If
            If IsNumeric(txtTotaleConto.Text) = True Then
               .TotaleConto = CFormatta.FormattaEuro(Convert.ToDouble(txtTotaleConto.Text))
            Else
               .TotaleConto = VALORE_ZERO
            End If

            If IsNumeric(txtSconto.Text) = True Then
               .Sconto = CFormatta.FormattaEuro(Convert.ToDouble(txtSconto.Text))
            Else
               .Sconto = VALORE_ZERO
            End If
            If IsNumeric(txtServizio.Text) = True Then
               .Servizio = CFormatta.FormattaEuro(Convert.ToDouble(txtServizio.Text))
            Else
               .Servizio = VALORE_ZERO
            End If

            ' Utilizzare per sconto camera o totale conto.
            '.ApplicaSconto = cmbApplicaSconto.SelectedIndex.ToString

            .ApplicaSconto = txtTotaleImporto.Text

            If ckbSchedina.Checked = True Then
               .Schedina = VALORE_INSERITA
            Else
               .Schedina = VALORE_NESSUNA
            End If

            .Note = FormattaApici(txtNote.Text)

            If .Colore = 0 Then
               .Colore = Convert.ToInt32(Color.White.ToArgb)
            End If

            '  Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
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

   Private Function SalvaOccupantiPren(ByVal id As String) As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         Dim idPren As Integer

         If id <> String.Empty Then
            idPren = id
         Else
            idPren = LeggiUltimoRecord(NOME_TABELLA)
         End If

         With IPrenOccupanti
            .EliminaDati(TAB_PREN_OCCUPANTI, idPren)

            Dim i As Integer
            For i = 0 To lvwOccupanti.Items.Count - 1
               .RifPren = idPren
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

               .InserisciDati(TAB_PREN_OCCUPANTI)
            Next
         End With

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Function SalvaOccupantiSchedina(ByVal id As String) As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         With IPrenOccupanti
            .EliminaDati(TAB_SCHEDINE_OCCUPANTI, id)

            Dim i As Integer
            For i = 0 To lvwOccupanti.Items.Count - 1
               .RifPren = id
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

               .InserisciDati(TAB_SCHEDINE_OCCUPANTI)
            Next
         End With

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Function EliminaOccupantiSchedina(ByVal id As String) As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         If id = String.Empty Then
            Exit Function
         End If

         CSchedina.LeggiDati(TAB_SCHEDINE_PS, Convert.ToInt32(id))

         IPrenOccupanti.EliminaDati(TAB_SCHEDINE_OCCUPANTI, CSchedina.Codice)

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Function SalvaAddebitiExtra(ByVal id As String) As Boolean
      ' Salva i dati per gli addebiti extra.
      Try
         Dim idPren As Integer

         If id <> String.Empty Then
            idPren = id
         Else
            idPren = LeggiUltimoRecord(NOME_TABELLA)
         End If

         With IPrenAddebiti
            .EliminaDati(TAB_PREN_ADDEBITI, idPren)

            Dim i As Integer
            For i = 0 To lvwAddebiti.Items.Count - 1
               .RifPren = idPren
               .Data = lvwAddebiti.Items(i).Text
               .Descrizione = lvwAddebiti.Items(i).SubItems(1).Text
               .Quantità = lvwAddebiti.Items(i).SubItems(2).Text
               .Importo = lvwAddebiti.Items(i).SubItems(3).Text
               .Codice = lvwAddebiti.Items(i).SubItems(4).Text
               .AliquotaIva = lvwAddebiti.Items(i).SubItems(6).Text
               .Categoria = lvwAddebiti.Items(i).SubItems(7).Text
               .Colore = lvwAddebiti.Items(i).ForeColor.ToArgb
               .Gruppo = lvwAddebiti.Items(i).Group.ToString
               .InserisciDati(TAB_PREN_ADDEBITI)
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
                                         ByVal dataArrivo As String, ByVal dataPartenza As String, ByVal nazionalità As String, ByVal provincia As String) As Boolean
      Try
         With IPrenStorico
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .RifPren = id
            .Numero = Convert.ToInt32(txtNumero.Text)
            .Mese = valMese
            .Anno = valAnno
            .Adulti = nudAdulti.Value
            .Neonati = nudNeonati.Value
            .Bambini = nudBambini.Value
            .Ragazzi = nudRagazzi.Value
            .NumeroNotti = valNumNotti
            .DataArrivo = dataArrivo
            .DataPartenza = dataPartenza
            .Nazionalità = nazionalità
            .Provincia = provincia

            .InserisciDati(TAB_PREN_STORICO)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Sub SalvaStoricoPresenzeMeseAnno(ByVal id As String)
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
         Dim nazionalità As String = LeggiNazionalitàCliente(TAB_CLIENTI, cmbIdCliente.Text)

         If nazionalità.ToUpper = "ITALIA" Then
            provincia = LeggiProvinciaCliente(TAB_CLIENTI, cmbIdCliente.Text)
         Else
            provincia = VALORE_NESSUNA
         End If

         ' In caso di nuova prenotazione dove l'Id non è ancora disponibile.
         Dim idSchedina As Integer
         If id <> String.Empty Then
            idSchedina = id
         Else
            idSchedina = LeggiUltimoRecord(NOME_TABELLA)
         End If

         ' Elimina eventuali dati esistenti.
         IPrenStorico.EliminaDati(TAB_PREN_STORICO, idSchedina)

         Dim i As Integer
         For i = 1 To valNumNotti
            If valDataArrivo.Month <> valMese Then
               ' Salva lo storico delle presenze.
               SalvaStoricoPresenze(idSchedina, valMese, valAnno, NumNottiTemp, valDataArrivoStorico, valDataPartenzaStorico, nazionalità, provincia)

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
         SalvaStoricoPresenze(idSchedina, valMese, valAnno, NumNottiTemp, valDataArrivoStorico, valDataPartenzaStorico, nazionalità, provincia)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function SalvaSchedinaPS(ByVal id As String) As Boolean
      Dim CClienti As New Anagrafiche.Cliente(ConnStringAnagrafiche)

      ' Legge i dati del cliente.
      CClienti.LeggiDati("Clienti", IPren.IdCliente)

      Try
         With CSchedina
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .IdCliente = CClienti.Codice
            .TipologiaCliente = cmbTipologia.Text
            .Cognome = CClienti.Cognome
            .Nome = CClienti.Nome
            .Sesso = CClienti.Sesso
            .DataNascita = CClienti.DataNascita
            .LuogoNascita = CClienti.LuogoNascita
            .ProvNascita = CClienti.ProvNascita
            .NazioneNascita = CClienti.NazioneNascita
            .Cittadinanza = CClienti.Nazionalità
            .TipoDoc = CClienti.TipoDoc
            .NumeroDoc = CClienti.NumeroDocIdentità
            .RilasciatoDoc = CClienti.RilasciatoDa
            .ComuneRilascioDoc = CClienti.CittàRilascioDoc
            .DataRilascioDoc = CClienti.DataRilascioDoc
            .DataScadenzaDoc = String.Empty ' DA_FARE_B: Sviluppare! Campo mancante nella tabelle Clienti.
            .NazioneRilascioDoc = CClienti.NazioneRilascioDoc
            .DataArrivo = FormattaData(mcDataArrivo.SelectionRange.Start.Date, True)
            .DataPartenza = FormattaData(mcDataPartenza.SelectionRange.Start.Date, True)
            .Permanenza = txtNumeroNotti.Text
            .NumCamera = cmbNumeroCamera.Text
            .NumPren = txtNumero.Text

            If id = String.Empty Then
               ' Nuova prenotazione.
               .Numero = g_frmMain.LeggiNumeroSchedinaConfig(TAB_SCHEDINE_PS)
               .IdPren = LeggiUltimoRecord(NOME_TABELLA)
               .Stato = VALORE_INSERITA
               .DataStampa = String.Empty
            Else

               .IdPren = id

               If IsNothing(CSchedina.Numero) = False And CSchedina.Numero <> "0" Then
                  .Numero = CSchedina.Numero
               Else
                  .Numero = g_frmMain.LeggiNumeroSchedinaConfig(TAB_SCHEDINE_PS)
               End If

               If IsNothing(CSchedina.Stato) = False Then
                  .Stato = CSchedina.Stato
               Else
                  .Stato = VALORE_INSERITA
               End If

               If IsNothing(CSchedina.DataStampa) = False Then
                  .DataStampa = CSchedina.DataStampa
               Else
                  .DataStampa = String.Empty
               End If
            End If

            ' Inserisce i dati nel database con Stato e DataStampa.
            If .InserisciDati(TAB_SCHEDINE_PS) = True Then
               ' Salva il Numero del prossimo documento da stampare.
               g_frmMain.SalvaNumeroSchedinaConfig(TAB_SCHEDINE_PS, Convert.ToInt32(.Numero))

               Return True
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Public Sub EliminaScedinePS(ByVal idPren As String)
      Try
         ' Se è una nuova prenotazione non deve eliminare nulla.
         If idPren = String.Empty Then
            Exit Sub
         End If

         Dim sql As String

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM SchedinePS WHERE IdPren = {0}", idPren)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

         ' DA_FARE_B: Modificare!
         ' Registra loperazione effettuata dall'operatore identificato.
         'g_frmMain.RegistraOperazione(TipoOperazione.Elimina, Descrizione, MODULO_GESTIONE_PLANNING_RISORSE)

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

         If IsNothing(g_frmSchedinePS) = False Then
            ' Aggiorna la griglia dati.
            g_frmSchedinePS.AggiornaDati()

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            g_frmSchedinePS.ConvalidaDati()
         End If

      End Try
   End Sub

   Private Sub LeggiOccupanti()
      Try
         With IPrenOccupanti
            .LeggiDati(lvwOccupanti, TAB_PREN_OCCUPANTI, Me.Tag)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub LeggiAddebitiExtra()
      Try
         With IPrenAddebiti
            .LeggiDati(lvwAddebiti, TAB_PREN_ADDEBITI, Me.Tag)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function LeggiTotaleTassaSoggiorno(ByVal numAdulti As Integer, ByVal numNeonati As Integer, ByVal numBambini As Integer, ByVal numRagazzi As Integer) As Decimal
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Legge il prezzo della Tassa di soggiorno.
         Dim tassaSoggiorno As Double
         If IsNumeric(DatiConfig.GetValue("TassaSoggiornoHotel")) = True Then
            tassaSoggiorno = Convert.ToDouble(DatiConfig.GetValue("TassaSoggiornoHotel"))
         Else
            tassaSoggiorno = 0
         End If

         ' Aggiunge gli Adulti al numero di persone che pagheranno la tassa.
         Dim numPersone As Integer = numAdulti

         ' Verifica se i Neonati pagheranno la tassa.
         Dim applicaTassaNeonati As Boolean
         If DatiConfig.GetValue("ApplicaTassaNeonati") <> String.Empty Then
            applicaTassaNeonati = DatiConfig.GetValue("ApplicaTassaNeonati")
         Else
            applicaTassaNeonati = False
         End If

         ' Aggiunge i Neonati al numero di persone che pagheranno la tassa.
         If applicaTassaNeonati = True Then
            numPersone = numPersone + numNeonati
         End If

         ' Verifica se i Bambini pagheranno la tassa.
         Dim applicaTassaBambini As Boolean
         If DatiConfig.GetValue("ApplicaTassaBambini") <> String.Empty Then
            applicaTassaBambini = DatiConfig.GetValue("ApplicaTassaBambini")
         Else
            applicaTassaBambini = False
         End If

         ' Aggiunge i Bambini al numero di persone che pagheranno la tassa.
         If applicaTassaBambini = True Then
            numPersone = numPersone + numBambini
         End If

         ' Verifica se i Ragazzi pagheranno la tassa.
         Dim applicaTassaRagazzi As Boolean
         If DatiConfig.GetValue("ApplicaTassaRagazzi") <> String.Empty Then
            applicaTassaRagazzi = DatiConfig.GetValue("ApplicaTassaRagazzi")
         Else
            applicaTassaRagazzi = False
         End If

         ' Aggiunge i Ragazzi al numero di persone che pagheranno la tassa.
         If applicaTassaRagazzi = True Then
            numPersone = numPersone + numRagazzi
         End If

         Return (tassaSoggiorno * numPersone).ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      End Try
   End Function

   Private Sub LeggiServizio()
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Percentuale per il Servizio.
         txtServizio.Text = DatiConfig.GetValue("ServizioHotel")
         If txtServizio.Text.Length = 0 Then
            txtServizio.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
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

   Public Function LeggiNazionalitàCliente(ByVal tabella As String, ByVal id As Integer) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()
         Dim nazionalità As String

         Do While dr.Read
            nazionalità = dr.Item("Nazionalità").ToString
         Loop

         If nazionalità = String.Empty Then
            nazionalità = VALORE_NESSUNA
         End If

         Return nazionalità

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_NESSUNA

      Finally
         cn.Close()

      End Try
   End Function

   ' DA_FARE_B: Non usata.
   Private Function VerificaDisponibilitàCamera1(ByVal numeroCamera As String, ByVal dataDal As Date, ByVal dataAl As Date) As Integer
      'Dim closeOnExit As Boolean
      'Dim numRec As Integer

      'Try
      '   ' Se necessario apre la connessione.
      '   If cn.State = ConnectionState.Closed Then
      '      cn.Open()
      '      closeOnExit = True
      '   End If

      '   ' Ottiene il numero di record.
      '   cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} " &
      '                                   "WHERE NumeroCamera = '{1}' " &
      '                                   "AND (DataArrivo BETWEEN #{2}# AND #{3}#)",
      '                                   NOME_TABELLA, numeroCamera, CFormatta.FormattaData_IT(dataDal), CFormatta.FormattaData_IT(dataAl.AddDays(-1)))

      '   numRec = CInt(cmd.ExecuteScalar())

      '   ' Se un operazione di modifica sottrae la prenotazione in fase di modifica.
      '   Dim numRecDataArrivo As Integer
      '   If Me.Tag <> String.Empty Then
      '      numRecDataArrivo = numRec - 1
      '   Else
      '      numRecDataArrivo = numRec
      '   End If

      '   numRec = 0

      '   ' Chiude la connessione.
      '   cn.Close()

      '   If numRecDataArrivo = 0 Then
      '      cn.Open()

      '      cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} " &
      '                                   "WHERE NumeroCamera = '{1}' " &
      '                                   "AND (DataPartenza BETWEEN #{2}# AND #{3}#)",
      '                                   NOME_TABELLA, numeroCamera, CFormatta.FormattaData_IT(dataDal.AddDays(1)), CFormatta.FormattaData_IT(dataAl))

      '      numRec = CInt(cmd.ExecuteScalar())

      '      ' Se un operazione di modifica sottrae la prenotazione in fase di modifica.
      '      If Me.Tag <> String.Empty Then
      '         Return numRec - 1
      '      Else
      '         Return numRec
      '      End If
      '   Else
      '      Return numRecDataArrivo
      '   End If

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      '   Return 0

      'Finally
      '   ' Chiude la connessione.
      '   cn.Close()

      'End Try
   End Function

   Private Function VerificaDisponibilitàCamera(ByVal numeroCamera As String, ByVal dataDal As Date, ByVal dataAl As Date, ByVal idPren As String) As Boolean
      Try
         ' Se il numero della camera non è stato assegnato non verifica la disponibilità. 
         If numeroCamera = VALORE_NESSUNA Then
            Return False
         End If

         ' In caso di prenotazione esistente se il periodo e la camera non sono cambiati non verifica la disponibilità della camera. 
         If numCameraPren = numeroCamera And dataArrivoPren = dataDal And dataPartenzaPren = dataAl Then
            Return False
         End If

         ' Se è una nuova prenotazione con Id ancora non assegnato imposta la variabile di controllo a '0' per consentire di eseguire la query. 
         If idPren = String.Empty Then
            idPren = "0"
         End If

         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         '  Leggo tutte le prenotazioni della camera.
         Dim cmd As New OleDbCommand("SELECT * FROM " & NOME_TABELLA & " WHERE NumeroCamera = '" & numeroCamera & "' AND Id <> " & idPren & " ORDER BY DataArrivo ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Data arrivo.
            Dim valDataArrivo As Date
            If IsDate(dr.Item("DataArrivo")) = True Then
               valDataArrivo = Convert.ToDateTime(dr.Item("DataArrivo"))
            Else
               Return False
            End If

            ' Data partenza.
            Dim valDataPartenza As Date
            If IsDate(dr.Item("DataPartenza")) = True Then
               valDataPartenza = Convert.ToDateTime(dr.Item("DataPartenza"))
            Else
               Return False
            End If

            ' Numero notti.
            Dim valNumNotti As Integer
            If IsDBNull(dr.Item("NumeroNotti")) = False Then
               valNumNotti = Convert.ToInt32(dr.Item("NumeroNotti"))
            Else
               Return False
            End If

            Dim dataDalTemp As Date = dataDal

            Do
               ' Viene incrementato di uno perchè il primo giorno dell'intervallo può incrociarsi con l'ultimo giorno di eventuali prenotazioni.
               dataDalTemp = dataDalTemp.AddDays(1)

               Dim valDatatemp As Date = valDataArrivo
               Dim i As Integer
               For i = 0 To valNumNotti
                  If valDatatemp = dataDalTemp Then
                     If dataDalTemp <> valDataArrivo Then
                        ' Prenotazione esistente!
                        Return True
                     End If
                  Else
                     ' Incrementa di un giorno.
                     valDatatemp = valDatatemp.AddDays(1)
                  End If
               Next

               ' Non tiene conto dell'ultimo giorno dell'intervallo perchè può incrociarsi con il primo giorno di eventuali prenotazioni.
            Loop Until dataDalTemp = dataAl

         Loop

         Return False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Public Function ApriClienti(ByVal val As String) As Boolean
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se è un nuovo inserimento verifica il numero dei record.
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

   Private Function ImpostaDatiAllegati(ByVal note As String, ByVal ins As Boolean) As Boolean
      Try
         OpenFileDialog1.Filter = "Tutti i file |*.*"

         OpenFileDialog1.FilterIndex = 1

         IAllegati.IdCliente = CInt(IPren.Codice)

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
                           "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma rimozione")

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

   Private Sub AttivaDisattivaAllegati()
      If Me.Tag = String.Empty Then
         eui_cmdApri.Enabled = False
         eui_cmdInserisci.Enabled = False
         eui_cmdModifica.Enabled = False
         eui_cmdElimina.Enabled = False
      Else
         eui_cmdApri.Enabled = True
         eui_cmdInserisci.Enabled = True
         eui_cmdModifica.Enabled = True
         eui_cmdElimina.Enabled = True
      End If
   End Sub

   Private Sub ConvalidaAllegati()

      If Me.Tag = String.Empty Then
         eui_cmdApri.Enabled = False
         eui_cmdInserisci.Enabled = False
         eui_cmdModifica.Enabled = False
         eui_cmdElimina.Enabled = False
      Else
         If IAllegati.LeggiDati(lvwAllegati, TAB_ALLEGATI, IPren.Codice) = True Then
            eui_cmdApri.Enabled = True
            eui_cmdInserisci.Enabled = True
            eui_cmdModifica.Enabled = True
            eui_cmdElimina.Enabled = True
         Else
            eui_cmdApri.Enabled = False
            eui_cmdInserisci.Enabled = True
            eui_cmdModifica.Enabled = False
            eui_cmdElimina.Enabled = False
         End If
      End If

   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Verifica la presenza di un numero per la prenotazione.
            If txtNumero.Text = String.Empty Or txtNumero.Text = "0" Then
               MessageBox.Show("Inserire un numero valido per la prenotazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               txtNumero.Focus()
               Exit Sub
            End If

            ' Verifica la presenza di un nome Intestatario.
            If cmbCognome.Text = String.Empty Then
               MessageBox.Show("Inserire un nominativo per l'intestatario della prenotazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               cmbCognome.Focus()
               Exit Sub
            End If

            ' Verifica se il numero totale di persone è coerente con il numero degli occupanti inseriti.
            Dim totPersone As Integer = nudAdulti.Value + nudNeonati.Value + nudBambini.Value + nudRagazzi.Value

            If totPersone <> (lvwOccupanti.Items.Count + 1) Then
               MessageBox.Show("Il numero di persone specificato non corrisponde con il numero di componenti inseriti.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Error)
               nudAdulti.Focus()
               Exit Sub
            End If

            If VerificaDisponibilitàCamera(cmbNumeroCamera.Text, mcDataArrivo.SelectionRange.Start.Date, mcDataPartenza.SelectionRange.Start.Date, Me.Tag) = True Then
               MessageBox.Show("La camera che si vuole prenotare non è disponibile per il periodo selezionato!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
               ' Esegue i calcoli per il totale degli importi.
               CalcolaTotaleConto()

               ' Salva i dati nel database.
               If SalvaDati() = True Then

                  ' Salva eventuali clienti occupanti.
                  SalvaOccupantiPren(Me.Tag)

                  ' Salva eventuali addebiti extra.
                  SalvaAddebitiExtra(Me.Tag)

                  ' Salva i dati per la schedina PS.
                  If ckbSchedina.Checked = True Then

                     ' Se la prenotazione è già esistente legge i dati Stato e DataStampa per salvarli.
                     If Me.Tag <> String.Empty Then
                        CSchedina.LeggiDati(TAB_SCHEDINE_PS, Convert.ToInt32(Me.Tag))
                     End If

                     ' Elimina tutte le schedine della prenotazione.
                     EliminaScedinePS(Me.Tag)

                     ' Elimina anche tutti i componenti associati.
                     EliminaOccupantiSchedina(Me.Tag)

                     If SalvaSchedinaPS(Me.Tag) = True Then
                        Dim idSchedina As Integer = LeggiUltimoRecord(TAB_SCHEDINE_PS)

                        ' Salva anche tutti i componenti associati.
                        SalvaOccupantiSchedina(idSchedina)

                        ' Salva lo storico delle presenze.
                        SalvaStoricoPresenzeMeseAnno(idSchedina)

                        If IsNothing(g_frmSchedinePS) = False Then
                           ' Aggiorna la griglia dati.
                           g_frmSchedinePS.AggiornaDati()
                        End If
                     End If
                  Else
                     'Elimina anche tutti i componenti associati.
                     EliminaOccupantiSchedina(Me.Tag)

                     ' Elimina tutte le schedine della prenotazione.
                     EliminaScedinePS(Me.Tag)
                  End If

                  Select Case tipoFrm
                     Case ElencoPrenCamere.Name
                        ' Aggiorna la griglia dati.
                        g_frmPrenCamere.AggiornaDati()

                        If IsNothing(g_frmPlanningCamere) = False Then
                           ' Aggiorna la griglia dati.
                           g_frmPlanningCamere.AggiornaPlanning()
                        End If

                     Case PlanningCamere.Name
                        ' Aggiorna il Planning con eventuali nuove camere e prentazioni..
                        g_frmPlanningCamere.AggiornaPlanning()

                        If IsNothing(g_frmPrenCamere) = False Then
                           ' Aggiorna la griglia dati.
                           g_frmPrenCamere.AggiornaDati()
                        End If

                  End Select

                  ' Chiude la finestra.
                  Me.Close()
               End If
            End If

         Case "Annulla"

            ' Chiude la finestra.
            Me.Close()

      End Select
   End Sub

   Private Sub frmPrenCamera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Carica le liste.
         CaricaListaClienti(cmbCognome, cmbNome, cmbIdCliente, TAB_CLIENTI)
         CaricaListaCamere(cmbNumeroCamera, TAB_CAMERE)
         CaricaLista(cmbListino, cmbIdListino, TAB_LISTINO)
         CaricaLista(cmbPagamento, TAB_PAGAMENTO)
         CaricaLista(cmbStatoPren, TAB_STATO_PREN)
         CaricaLista(cmbGruppo, TAB_GRUPPI)
         CaricaLista(cmbAgenzia, TAB_AGENZIE)
         CaricaLista(cmbCanaleVendita, TAB_CANALI_PROV)

         If Me.Tag <> String.Empty Then
            With IPren
               ' Comando Modifica.

               ' Visualizza i dati nei rispettivi campi.
               .LeggiDati(NOME_TABELLA, Me.Tag)

               ' Assegna i dati dei campi della classe alle caselle di testo.
               txtCodice.Text = .Codice
               txtNumero.Text = .Numero
               dtpData.Value = Convert.ToDateTime(.Data)
               cmbTipologia.Text = .Tipologia
               cmbStatoPren.Text = .Stato
               cmbCognome.Text = .Cognome
               txtNome.Text = .Nome
               cmbListino.Text = .Listino
               nudAdulti.Value = Convert.ToDecimal(.Adulti)
               nudNeonati.Value = Convert.ToDecimal(.Neonati)
               nudBambini.Value = Convert.ToDecimal(.Bambini)
               nudRagazzi.Value = Convert.ToDecimal(.Ragazzi)
               cmbNumeroCamera.Text = .NumeroCamera
               txtDescrizioneCamera.Text = .DescrizioneCamera
               cmbTrattamento.Text = .Trattamento
               cmbGruppo.Text = .Gruppo
               cmbAgenzia.Text = .Agenzia
               cmbCanaleVendita.Text = .CanaleVendita
               mcDataArrivo.SetDate(Convert.ToDateTime(.DataArrivo))
               mcDataPartenza.SetDate(Convert.ToDateTime(.DataPartenza))
               dtpOraArrivo.Value = Convert.ToDateTime(.OraArrivo)
               txtNumeroNotti.Text = .NumeroNotti.ToString
               cmbPagamento.Text = .Pagamento
               txtPrezzoCamera.Text = CFormatta.FormattaNumeroDouble(.CostoCamera)
               txtTassaSoggiorno.Text = CFormatta.FormattaNumeroDouble(.TassaSoggiorno)
               txtAccontoCamera.Text = CFormatta.FormattaNumeroDouble(.AccontoCamera)
               txtTotaleConto.Text = CFormatta.FormattaNumeroDouble(.TotaleConto)
               txtTotaleConto.Text = CFormatta.FormattaNumeroDouble(.ApplicaSconto)
               'cmbApplicaSconto.SelectedIndex = Convert.ToInt32(.ApplicaSconto)

               If IsNumeric(.Sconto) = True Then
                  txtSconto.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Sconto))
               Else
                  txtSconto.Text = VALORE_ZERO
               End If
               If IsNumeric(.Servizio) = True Then
                  txtServizio.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Servizio))
               Else
                  txtServizio.Text = VALORE_ZERO
               End If

               If .Schedina <> VALORE_NESSUNA Then
                  ckbSchedina.Checked = True
               Else
                  ckbSchedina.Checked = False
               End If

               txtNote.Text = .Note

               If .Colore <> 0 Then
                  cmdColore.BackColor = Color.FromArgb(.Colore)
               End If

               ' Aggiorna la nuova data di arrivo.
               lblArrivo.Text = "Arrivo: " & Convert.ToDateTime(.DataArrivo).ToLongDateString
               ' Aggiorna la nuova data di partenza.
               lblPartenza.Text = "Partenza: " & Convert.ToDateTime(.DataPartenza).ToLongDateString

               ' Carica eventuali clienti occupanti.
               LeggiOccupanti()

               ' Carica eventuali addebiti extra.
               LeggiAddebitiExtra()
               CalcolaTotaleAddebiti()

               ' Legge il Sevizio.
               LeggiServizio()

               ' Attiva / Disattiva i comandi appropriati degli allegati.
               ConvalidaAllegati()

               ' Salva i dati per verificare se la prenotazione è cambiata.
               numCameraPren = .NumeroCamera
               dataArrivoPren = Convert.ToDateTime(.DataArrivo)
               dataPartenzaPren = Convert.ToDateTime(.DataPartenza)

            End With
         Else
            ' Comando Nuovo.

            ' Genera il numero progressivo.
            txtNumero.Text = LeggiUltimoRecord(NOME_TABELLA, "Numero") + 1

            ' Data prenotazione - Oggi.
            dtpData.Value = Today

            ' Seleziona il valore Ospite Singolo.
            cmbTipologia.SelectedIndex = 0

            ' Seleziona il valore Nessuna.
            cmbNumeroCamera.SelectedIndex = 0

            ' Seleziona il valore Solo Pernottamento.
            cmbTrattamento.SelectedIndex = 0

            Select Case tipoFrm
               Case ElencoPrenCamere.Name
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

                  ' Contabile.
                  txtPrezzoCamera.Text = VALORE_ZERO
                  txtTotaleCostoCamera.Text = VALORE_ZERO
                  txtTotaleAddebiti.Text = VALORE_ZERO
                  txtSconto.Text = VALORE_ZERO
                  txtServizio.Text = VALORE_ZERO
                  txtTotaleTassaSoggiorno.Text = VALORE_ZERO
                  txtTotaleConto.Text = VALORE_ZERO
                  txtAccontoCamera.Text = VALORE_ZERO
                  txtTotaleImporto.Text = VALORE_ZERO
                  'cmbApplicaSconto.SelectedIndex = 0

               Case PlanningCamere.Name
                  Dim data As Date = Convert.ToDateTime(g_frmPlanningCamere.dgvPrenotazioni.Columns(g_frmPlanningCamere.dgvPrenotazioni.CurrentCell.ColumnIndex).Name).Date

                  ' Data e ora di arrivo
                  mcDataArrivo.SetDate(data)
                  mcDataPartenza.MinDate = data.AddDays(1)
                  mcDataPartenza.SetDate(data.AddDays(1))
                  ' Aggiorna la nuova data di arrivo.
                  lblArrivo.Text = "Arrivo: " & data.ToLongDateString
                  ' Aggiorna la nuova data di partenza.
                  lblPartenza.Text = "Partenza: " & data.AddDays(1).ToLongDateString
                  ' Aggiorna il numero delle notti.
                  txtNumeroNotti.Text = CalcolaNumGiorni(data, mcDataPartenza.SelectionRange.Start.Date).ToString
                  ' Assegna il numero di camera selezionato dal Planning.
                  cmbNumeroCamera.Text = g_frmPlanningCamere.dgvCamere.Rows(g_frmPlanningCamere.dgvPrenotazioni.CurrentCell.RowIndex).Cells("Numero").Value

                  If cmbListino.Text <> String.Empty Then
                     ApplicaListino()
                  Else
                     ' Contabile.
                     txtPrezzoCamera.Text = VALORE_ZERO
                     txtTotaleCostoCamera.Text = VALORE_ZERO
                     txtTotaleAddebiti.Text = VALORE_ZERO
                     txtSconto.Text = VALORE_ZERO
                     txtServizio.Text = VALORE_ZERO
                     txtTotaleTassaSoggiorno.Text = VALORE_ZERO
                     txtTotaleConto.Text = VALORE_ZERO
                     txtAccontoCamera.Text = VALORE_ZERO
                     txtTotaleImporto.Text = VALORE_ZERO
                     'cmbApplicaSconto.SelectedIndex = 0
                  End If

            End Select

            ' Schedina P.S.
            ckbSchedina.Checked = False

            ' Ora corrente.
            dtpOraArrivo.Value = Now
         End If

         ' Attiva / Disattiva i comandi appropriati degli allegati.
         ConvalidaAllegati()

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, cmbCognome.Text, txtNome.Text)

         ' Imposta lo stato attivo.
         txtNumero.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

         ' Serve a sapere se il form è stato caricato.
         loadForm = True
      End Try
   End Sub

   ' DA_FARE_B: HOTEL - da modificare!
   Private Sub frmPrenCamera_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      If Me.Tag <> "0" Then
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
            ' Occupanti.
            lvwOccupanti.Focus()

         Case 2
            ' Addebiti extra.
            lvwAddebiti.Focus()

         Case 3
            ' Contabile.
            cmbListino.Focus()

            ' Inserisce il prezzo della camera in base al Listino elezionato.
            ApplicaListino()

         Case 4
            ' Allegati.
            lvwAllegati.Focus()

         Case 5
            ' Note.
            txtNote.Focus()

      End Select
   End Sub

   Private Sub cmdColore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdColore.Click
      'ModificaColore()
      MessageBox.Show("Per assegnare un colore alla prenotazione selezionare un valore nella casella 'Stato prenotazione'.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
   End Sub

   Private Sub cmdNuovoIntestatario_Click(sender As Object, e As EventArgs) Handles cmdNuovoIntestatario.Click
      Try
         ' Se è stato inserito un nuovo cliente...
         If ApriClienti(String.Empty) = True Then
            CaricaListaClienti(cmbCognome, cmbNome, cmbIdCliente, TAB_CLIENTI)

            cmbCognome.Text = String.Empty
            cmbNome.Text = String.Empty
            txtNome.Text = String.Empty
            cmbIdCliente.Text = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdApriIntestatario_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApriIntestatario.Click
      Try
         ' Modifica cliente esistente...
         If ApriClienti(cmbIdCliente.Text) = True Then
            CaricaListaClienti(cmbCognome, cmbNome, cmbIdCliente, TAB_CLIENTI)

            cmbCognome.Text = String.Empty
            cmbNome.Text = String.Empty
            txtNome.Text = String.Empty
            cmbIdCliente.Text = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmbStatoPren_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatoPren.SelectedIndexChanged
      Try
         cmdColore.BackColor = Color.FromArgb(AssegnaColore(cmbStatoPren.Text, TAB_STATO_PREN))
         IPren.Colore = Convert.ToString(cmdColore.BackColor.ToArgb)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub mcDataArrivo_DateChanged(sender As System.Object, e As System.Windows.Forms.DateRangeEventArgs) Handles mcDataArrivo.DateChanged
      Try
         ' Aggiorna la nuova data di arrivo.
         lblArrivo.Text = "Arrivo: " & e.Start.Date.ToLongDateString

         ' Se la data di arrivo è maggiore o uguale alla data di partenza.
         If e.Start.Date.Date >= mcDataPartenza.SelectionRange.Start.Date Then

            ' Imposta nuovamente il calendario.
            mcDataPartenza.MinDate = e.Start.Date.AddDays(1)

            ' Aggiorna la nuova data di partenza.
            lblPartenza.Text = "Partenza: " & mcDataPartenza.SelectionRange.Start.Date.ToLongDateString

            ' Aggiorna il numero delle notti.
            txtNumeroNotti.Text = CalcolaNumGiorni(e.Start.Date, mcDataPartenza.SelectionRange.Start.Date).ToString

            ' Inserisce il prezzo della camera in base al Listino elezionato.
            ApplicaListino()

            Exit Sub
         End If

         ' Imposta nuovamente il calendario.
         mcDataPartenza.MinDate = e.Start.Date.AddDays(1)

         ' Aggiorna il numero delle notti.
         txtNumeroNotti.Text = CalcolaNumGiorni(e.Start.Date, mcDataPartenza.SelectionRange.Start.Date).ToString

         ' Inserisce il prezzo della camera in base al Listino elezionato.
         ApplicaListino()

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

         ' Inserisce il prezzo della camera in base al Listino elezionato.
         'ApplicaListino()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmbNumeroCamera_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbNumeroCamera.SelectedIndexChanged
      Try
         ' Imposta la descrizione della camera selezionata.
         txtDescrizioneCamera.Text = LeggiDescrizioneCamera(cmbNumeroCamera.Text, TAB_CAMERE)

         ' Se non è impostato un listino prezzi, Imposta il listino della camera selezionata.
         If cmbListino.Text = String.Empty Then
            cmbListino.Text = LeggiListinoCamera(cmbNumeroCamera.Text, TAB_CAMERE)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmbCognome_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbCognome.SelectedIndexChanged
      Try
         ' Legge il nome relativo alla lista Cognome.
         cmbIdCliente.SelectedIndex = cmbCognome.SelectedIndex
         cmbNome.SelectedIndex = cmbCognome.SelectedIndex
         txtNome.Text = cmbNome.Text

         ' Genera l'intestazione con i dati del form.
         lblIntestazione.Text = VisIntestazione(txtNumero.Text, cmbCognome.Text, txtNome.Text)

         ' Se è impostata l'aliquota Iva per il cliente... Altrimenti viene utilzzata quella di reparto.
         'Dim valIva As String = CFormatta.FormattaEuro(LeggiIvaCliente(ANA_CLIENTI, cmbIdCliente.Text))
         'If valIva <> VALORE_ZERO Then
         '   txtIva.Text = valIva
         'End If

         Dim valSconto As String = LeggiScontoCliente(TAB_CLIENTI, cmbIdCliente.Text)

         If IsNumeric(valSconto) = True Then
            txtSconto.Text = CFormatta.FormattaEuro(Convert.ToDecimal(valSconto)) '& "%"
         Else
            txtSconto.Text = VALORE_ZERO
         End If

         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub txtPrezzoCamera_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrezzoCamera.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtAccontoCamera_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccontoCamera.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtPrezzoCamera_LostFocus(sender As Object, e As System.EventArgs) Handles txtPrezzoCamera.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtAccontoCamera_LostFocus(sender As Object, e As System.EventArgs) Handles txtAccontoCamera.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub CalcolaTotaleAddebiti()
      Try
         If lvwAddebiti.Items.Count <> 0 Then
            Dim i As Integer = 0
            Dim TotRiga As Decimal
            Dim TotaleConto As Decimal

            For i = 0 To lvwAddebiti.Items.Count - 1
               TotRiga = Convert.ToDecimal(lvwAddebiti.Items(i).SubItems(3).Text)
               TotaleConto = TotaleConto + TotRiga
            Next i

            txtTotaleAddebitiExtra.Text = CFormatta.FormattaEuro(TotaleConto)
         Else
            txtTotaleAddebitiExtra.Text = VALORE_ZERO
         End If

         ' Aggiorna il campo nella scheda Contabile.
         txtTotaleAddebiti.Text = txtTotaleAddebitiExtra.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub CalcolaTotaleConto()
      Try
         Dim numNotti As Integer
         If IsNumeric(txtNumeroNotti.Text) = True Then
            numNotti = Convert.ToInt32(txtNumeroNotti.Text)
         Else
            numNotti = 0
         End If

         Dim prezzoCamera As Double
         If IsNumeric(txtPrezzoCamera.Text) = True Then
            prezzoCamera = Convert.ToDouble(txtPrezzoCamera.Text)
         Else
            prezzoCamera = 0
         End If

         Dim addebitiExtra As Double
         If IsNumeric(txtTotaleAddebiti.Text) = True Then
            addebitiExtra = Convert.ToDouble(txtTotaleAddebiti.Text)
         Else
            addebitiExtra = 0
         End If

         Dim accontoCamera As Double
         If IsNumeric(txtAccontoCamera.Text) = True Then
            accontoCamera = Convert.ToDouble(txtAccontoCamera.Text)
         Else
            accontoCamera = 0
         End If

         ' Calcola il totale del costo della camera in base al tipo di listino applicato.
         Dim totCamera As Double
         Dim numAdulti As Integer = Convert.ToInt32(nudAdulti.Value)
         Dim numNeonati As Integer = Convert.ToInt32(nudNeonati.Value)
         Dim numBambini As Integer = Convert.ToInt32(nudBambini.Value)
         Dim numRagazzi As Integer = Convert.ToInt32(nudRagazzi.Value)

         ' Totale camera complessivo.
         totCamera = (prezzoCamera * numNotti)
         txtTotaleCostoCamera.Text = CFormatta.FormattaEuro(totCamera)

         ' Legge e calcola il totale per la Tassa di Soggiorno.
         Dim totaleTassaSoggiorno As Double
         totaleTassaSoggiorno = LeggiTotaleTassaSoggiorno(numAdulti, numNeonati, numBambini, numRagazzi)
         txtTassaSoggiorno.Text = CFormatta.FormattaEuro(totaleTassaSoggiorno)
         txtTotaleTassaSoggiorno.Text = CFormatta.FormattaEuro(totaleTassaSoggiorno * numNotti)

         ' Calcola il totale parziale del conto.
         Dim totConto As Double = totCamera + addebitiExtra + (totaleTassaSoggiorno * numNotti)

         ' Calcola il valore del servizio sul totale del conto.
         Dim valServizio As Double
         Dim servizio As Double
         'Dim percServizio As Integer = txtServizio.Text.IndexOf("%")
         'If percServizio <> -1 Then
         If IsNumeric((txtServizio.Text)) Then
            servizio = Convert.ToDouble(txtServizio.Text) '.Remove(txtServizio.Text.Length - 1, 1))
            valServizio = CalcolaPercentuale(totConto, servizio)
         Else
            valServizio = 0 'Convert.ToDouble(txtServizio.Text)
            txtServizio.Text = VALORE_ZERO
         End If

         ' Calcola il valore dello sconto.
         Dim valSconto As Double
         Dim sconto As Double
         'Dim percSconto As Integer = txtSconto.Text.IndexOf("%")
         'If percSconto <> -1 Then
         If IsNumeric((txtSconto.Text)) Then
            sconto = Convert.ToDouble(txtSconto.Text) '.Remove(txtSconto.Text.Length - 1, 1))

            'If cmbApplicaSconto.SelectedIndex = 1 Then
            ' Sul totale del conto.
            valSconto = CalcolaPercentuale(totConto, sconto)
            'Else
            '   ' Sul totale della camera.
            '   valSconto = CalcolaPercentuale(totCamera, sconto)
            'End If
         Else
            valSconto = 0 'Convert.ToDouble(txtSconto.Text)
            txtSconto.Text = VALORE_ZERO
         End If

         ' Calcola il totale del conto.
         Dim valDaPagare As Double = (totConto + valServizio - valSconto)
         txtTotaleConto.Text = CFormatta.FormattaEuro(valDaPagare)

         ' Utilizzato per calcolare lo sconto nella creazione documento.
         Dim valTotale As Double = (totConto + valServizio)
         txtTotaleImporto.Text = CFormatta.FormattaEuro(valTotale)

         ' Calcola il totale da incassare sottraendo eventuali acconti.
         Dim totIncassare As Double = (valDaPagare - accontoCamera)
         txtTotaleIncassare.Text = CFormatta.FormattaEuro(totIncassare)

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

         Select Case cmbTipologia.Text
            Case "Capo Famiglia"
               tipoAlloggiato = "Familiare"

            Case "Capo Gruppo"
               tipoAlloggiato = "Membro Gruppo"

         End Select

         Dim frm As New frmInsClienti("Prenotazioni", tipoAlloggiato)
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

   Private Sub eui_cmdAccessori_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdAccessori.Click
      Try
         Dim frm As New ListaAccessoriServizi("Accessorio")
         frm.Tag = "PrenCamera"
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdServizi_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdServizi.Click
      Try
         Dim frm As New ListaAccessoriServizi("Servizio")
         frm.Tag = "PrenCamera"
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdApriPos_Click(sender As Object, e As EventArgs) Handles eui_cmdApriPos.Click
      ' Apre il punto cassa.
      g_frmMain.ApriPos(Convert.ToInt32(txtNumero.Text), "Hotel", txtTotaleConto.Text, String.Empty)
   End Sub

   Private Sub eui_cmdEliminaRiga_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdEliminaRiga.Click
      EliminaRiga()
      CalcolaTotaleAddebiti()
   End Sub

   Private Sub EliminaRiga()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         'lvwAddebiti.Focus()
         'Dim strDescrizione As String = "(" & lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(1).Text & _
         '                               " " & lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(2).Text & _
         '                               " € " & lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(3).Text & ")"

         'g_frmMain.RegistraOperazione(TipoOperazione.Cancella, strDescrizione, MODULO_GESTIONE_POS)

         If lvwAddebiti.Items.Count <> 0 Then
            lvwAddebiti.Focus()
            lvwAddebiti.Items.RemoveAt(lvwAddebiti.FocusedItem.Index)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdQuantitàPiù_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdQuantitàPiù.Click
      AumentaDiminuisciQta(True)
      CalcolaTotaleAddebiti()
   End Sub

   Private Sub eui_QuantitàMeno_Click(sender As System.Object, e As System.EventArgs) Handles eui_QuantitàMeno.Click
      AumentaDiminuisciQta(False)
      CalcolaTotaleAddebiti()
   End Sub

   Private Function AumentaDiminuisciQta(ByVal val As Boolean) As Boolean
      ' Vero: aumenta di 1 - Falso: diminuisce di 1.
      Try
         If lvwAddebiti.Items.Count <> 0 Then
            lvwAddebiti.Focus()

            Dim quantità As Integer = Convert.ToInt32(lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(2).Text)
            Dim totPrezzo As Decimal = Convert.ToDecimal(lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(3).Text)
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
            lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(3).Text = String.Format("{0:0.00}", totPrezzo)

            lvwAddebiti.Items(lvwAddebiti.FocusedItem.Index).SubItems(2).Text = quantità

            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Private Sub txtServizio_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtServizio.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtServizio_LostFocus(sender As Object, e As System.EventArgs) Handles txtServizio.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

         ' Esegue i calcoli per il totale degli importi.
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
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmbApplicaSconto_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbApplicaSconto.SelectedIndexChanged
      Try
         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmbListino_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbListino.SelectedIndexChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Sub cmbTrattamento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTrattamento.SelectedIndexChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Sub nudAdulti_ValueChanged(sender As Object, e As EventArgs) Handles nudAdulti.ValueChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Sub nudNeonati_ValueChanged(sender As Object, e As EventArgs) Handles nudNeonati.ValueChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Sub nudBambini_ValueChanged(sender As Object, e As EventArgs) Handles nudBambini.ValueChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Sub nudRagazzi_ValueChanged(sender As Object, e As EventArgs) Handles nudRagazzi.ValueChanged
      ' Inserisce il prezzo della camera in base al Listino elezionato.
      If loadForm = True Then
         ApplicaListino()
      End If

   End Sub

   Private Function LeggiBassaStagione1(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio1_Bassa) = True And IsDate(.DataFine1_Bassa) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio1_Bassa & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine1_Bassa & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return BASSA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return BASSA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiBassaStagione2(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio2_Bassa) = True And IsDate(.DataFine2_Bassa) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio2_Bassa & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine2_Bassa & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return BASSA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return BASSA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiBassaStagione3(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio3_Bassa) = True And IsDate(.DataFine3_Bassa) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio3_Bassa & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine3_Bassa & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return BASSA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return BASSA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiMediaStagione1(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio1_Media) = True And IsDate(.DataFine1_Media) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio1_Media & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine1_Media & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return MEDIA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return MEDIA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiMediaStagione2(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio2_Media) = True And IsDate(.DataFine2_Media) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio2_Media & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine2_Media & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return MEDIA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return MEDIA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiMediaStagione3(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio3_Media) = True And IsDate(.DataFine3_Media) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio3_Media & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine3_Media & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return MEDIA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return MEDIA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiAltaStagione1(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio1_Alta) = True And IsDate(.DataFine1_Alta) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio1_Alta & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine1_Alta & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return ALTA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return ALTA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiAltaStagione2(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio2_Alta) = True And IsDate(.DataFine2_Alta) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio2_Alta & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine2_Alta & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return ALTA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return ALTA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiAltaStagione3(ByVal dataPren As Date) As String
      Try
         ' Verifico la data per sapere il periodo di stagione.
         Dim AStagioni As New Stagioni

         With AStagioni

            ' Leggo i dati.
            .LeggiDati(TAB_STAGIONI)

            If IsDate(.DataInizio3_Alta) = True And IsDate(.DataFine3_Alta) = True Then
               Dim dataTemp As Date = Convert.ToDateTime(.DataInizio3_Alta & Today.Year.ToString)
               Dim dataTempFine As Date = Convert.ToDateTime(.DataFine3_Alta & Today.Year.ToString)

               If dataTemp <> dataTempFine Then
                  Do
                     If dataTemp = dataPren Then
                        Return ALTA_STAGIONE
                     Else
                        dataTemp = dataTemp.AddDays(1)
                     End If
                  Loop Until dataTemp = dataTempFine
               Else
                  If dataTemp = dataPren Then
                     Return ALTA_STAGIONE
                  End If
               End If
            End If

         End With

         Return String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiPrezzoListino(ByVal tipoStagione As String) As String
      Try
         Const PERNOTTAMENTO As String = "PN"
         Const BED_AND_BREAKFAST As String = "BB"
         Const MEZZA_PENSIONE As String = "MP"
         Const PENSIONE_COMPLETA As String = "PC"

         If cmbListino.SelectedIndex = -1 Then
            Return VALORE_ZERO
         End If

         ' Leggo l'Id del listino selezionato.
         cmbIdListino.SelectedIndex = cmbListino.SelectedIndex

         ' Estraggo i dati del listino selezionato.
         Dim AListinoCamera As New ListinoCamera
         With AListinoCamera
            .LeggiDati(TAB_LISTINO, cmbIdListino.Text)

            ' Leggo il tipo di Listino - Prezzo a persona o Camera.
            tipoListino = .Tipologia

            ' Leggo il Trattamento selezionato.
            Dim trattamento As String = cmbTrattamento.Text.Substring(0, 2)

            ' Leggo il prezzo da applicare.
            Select Case tipoStagione
               Case BASSA_STAGIONE
                  scontoNeonato = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoNeonato_Bassa))
                  scontoBambino = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoBambino_Bassa))
                  scontoRagazzo = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoRagazzo_Bassa))

                  Select Case trattamento
                     Case PERNOTTAMENTO
                        Return .SoloPernottamento_Bassa
                     Case BED_AND_BREAKFAST
                        Return .BB_Bassa
                     Case MEZZA_PENSIONE
                        Return .MezzaPensione_Bassa
                     Case PENSIONE_COMPLETA
                        Return .PensioneCompleta_Bassa
                  End Select

               Case MEDIA_STAGIONE
                  scontoNeonato = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoNeonato_Media))
                  scontoBambino = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoBambino_Media))
                  scontoRagazzo = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoRagazzo_Media))

                  Select Case trattamento
                     Case PERNOTTAMENTO
                        Return .SoloPernottamento_Media
                     Case BED_AND_BREAKFAST
                        Return .BB_Media
                     Case MEZZA_PENSIONE
                        Return .MezzaPensione_Media
                     Case PENSIONE_COMPLETA
                        Return .PensioneCompleta_Media
                  End Select

               Case ALTA_STAGIONE
                  scontoNeonato = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoNeonato_Alta))
                  scontoBambino = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoBambino_Alta))
                  scontoRagazzo = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ScontoRagazzo_Alta))

                  Select Case trattamento
                     Case PERNOTTAMENTO
                        Return .SoloPernottamento_Alta
                     Case BED_AND_BREAKFAST
                        Return .BB_Alta
                     Case MEZZA_PENSIONE
                        Return .MezzaPensione_Alta
                     Case PENSIONE_COMPLETA
                        Return .PensioneCompleta_Alta
                  End Select

               Case Else
                  Return VALORE_ZERO

            End Select

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO
      End Try
   End Function

   Private Sub ApplicaListino()
      Try
         Dim tipoStagione As String
         Dim prezzoCamera As String

         ' Leggo la data di inizio prenotazione.
         Dim dataPrenotazione As Date = mcDataArrivo.SelectionRange.Start.Date

         ' Bassa stagione - Intervallo 1.
         tipoStagione = LeggiBassaStagione1(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Bassa stagione - Intervallo 2.
         tipoStagione = LeggiBassaStagione2(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Bassa stagione - Intervallo 3.
         tipoStagione = LeggiBassaStagione3(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Media stagione - Intervallo 1.
         tipoStagione = LeggiMediaStagione1(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Media stagione - Intervallo 2.
         tipoStagione = LeggiMediaStagione2(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Media stagione - Intervallo 3.
         tipoStagione = LeggiMediaStagione3(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Alta stagione - Intervallo 1.
         tipoStagione = LeggiAltaStagione1(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Alta stagione - Intervallo 2.
         tipoStagione = LeggiAltaStagione2(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Alta stagione - Intervallo 3.
         tipoStagione = LeggiAltaStagione3(dataPrenotazione)
         If tipoStagione <> String.Empty Then
            prezzoCamera = LeggiPrezzoListino(tipoStagione)
         End If

         ' Calcola il totale del costo della camera in base al tipo di listino applicato.
         Dim totCameraAdulti As Double
         Dim totCameraNeonati As Double
         Dim totCameraBambini As Double
         Dim totCameraRagazzi As Double

         Dim numAdulti As Integer = Convert.ToInt32(nudAdulti.Value)
         Dim numNeonati As Integer = Convert.ToInt32(nudNeonati.Value)
         Dim numBambini As Integer = Convert.ToInt32(nudBambini.Value)
         Dim numRagazzi As Integer = Convert.ToInt32(nudRagazzi.Value)

         Select Case tipoListino

            Case "Tariffa a Persona"
               ' Adulti.
               totCameraAdulti = (prezzoCamera * numAdulti)

               ' Neonati.
               If scontoNeonato = VALORE_ZERO Or scontoNeonato = String.Empty Then
                  totCameraNeonati = (prezzoCamera * numNeonati)
               Else
                  Dim scontoPrezzoCamera As Double = ((prezzoCamera * Convert.ToDouble(scontoNeonato)) / 100)
                  totCameraNeonati = (scontoPrezzoCamera * numNeonati)
               End If

               ' Bambini.
               If scontoBambino = VALORE_ZERO Or scontoBambino = String.Empty Then
                  totCameraBambini = (prezzoCamera * numBambini)
               Else
                  Dim scontoPrezzoCamera As Double = ((prezzoCamera * Convert.ToDouble(scontoBambino)) / 100)
                  totCameraBambini = (scontoPrezzoCamera * numBambini)
               End If

               ' Ragazzi.
               If scontoRagazzo = VALORE_ZERO Or scontoRagazzo = String.Empty Then
                  totCameraRagazzi = (prezzoCamera * numRagazzi)
               Else
                  Dim scontoPrezzoCamera As Double = ((prezzoCamera * Convert.ToDouble(scontoRagazzo)) / 100)
                  totCameraRagazzi = (scontoPrezzoCamera * numRagazzi)
               End If

               ' Assegna il prezzo alla camera.
               txtPrezzoCamera.Text = CFormatta.FormattaNumeroDouble((totCameraAdulti + totCameraNeonati + totCameraBambini + totCameraRagazzi))

            Case "Tariffa a Camera"
               ' Assegna il prezzo alla camera.
               txtPrezzoCamera.Text = CFormatta.FormattaNumeroDouble(prezzoCamera)

         End Select

         ' Esegue i calcoli per il totale degli importi.
         CalcolaTotaleConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdApri_Click(sender As Object, e As EventArgs) Handles eui_cmdApri.Click
      ' DA_FARE_A: DA TERMINARE - IMPOSTARE TUTTI I PROGRAMMI APRIBILI.
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
            Case ".RTF"
               ' WordPad
               NomeApp = "WORDPAD.EXE"

            Case ".DOC"
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

   Private Sub eui_cmdInserisci_Click(sender As Object, e As EventArgs) Handles eui_cmdInserisci.Click
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

   Private Sub eui_cmdModifica_Click(sender As Object, e As EventArgs) Handles eui_cmdModifica.Click
      Try
         'cmdInserimento.NotifyDefault(False)

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

   Private Sub eui_cmdElimina_Click(sender As Object, e As EventArgs) Handles eui_cmdElimina.Click
      Try
         'cmdInserimento.NotifyDefault(False)

         RimuoviAllegati(TAB_ALLEGATI, lvwAllegati.Items(lvwAllegati.FocusedItem.Index).SubItems(5).Text)
         ConvalidaAllegati()

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      End Try
   End Sub

   Private Sub lvwAllegati_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvwAllegati.DoubleClick
      eui_cmdApri.PerformClick()
   End Sub

   Private Sub txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNumero.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmbTipologia_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbTipologia.SelectedIndexChanged
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

End Class
