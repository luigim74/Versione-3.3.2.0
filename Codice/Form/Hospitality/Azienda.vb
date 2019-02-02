#Region " DATI FILE.VB "
' ***************************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 19/12/2018
' Descrizione:          Anagrafica Azienda.
' Note:
'
' Elenco Attivita:
'
'
' ***************************************************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.IO

Friend Class frmAzienda
   Inherits System.Windows.Forms.Form
#Region "Codice generato dalla finestra di progettazione Windows Form "
   Public Sub New()
      MyBase.New()
      'Chiamata richiesta dalla progettazione Windows Form.
      InitializeComponent()
      Me.Show()
   End Sub
   'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
      If Disposing Then
         If Not components Is Nothing Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(Disposing)
   End Sub
   'Richiesto dalla progettazione Windows Form
   Private components As System.ComponentModel.IContainer
   'NOTA: la routine seguente è richiesta dalla progettazione Windows Form.
   'Può essere modificata utilizzando la finestra di progettazione Windows Form.
   'Non modificarla mediante l'editor di codice.
   Friend WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents chkVisRagSoc As System.Windows.Forms.CheckBox
   Friend WithEvents lblIntestazione As System.Windows.Forms.Label
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
   Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
   Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
   Public WithEvents txtIBAN As System.Windows.Forms.TextBox
   Public WithEvents Label32 As System.Windows.Forms.Label
   Friend WithEvents cmbPagamento As System.Windows.Forms.ComboBox
   Friend WithEvents Label33 As System.Windows.Forms.Label
   Public WithEvents txtCIN As System.Windows.Forms.TextBox
   Public WithEvents txtCC As System.Windows.Forms.TextBox
   Public WithEvents txtCAB As System.Windows.Forms.TextBox
   Public WithEvents txtABI As System.Windows.Forms.TextBox
   Public WithEvents txtBanca As System.Windows.Forms.TextBox
   Public WithEvents Label34 As System.Windows.Forms.Label
   Public WithEvents Label35 As System.Windows.Forms.Label
   Public WithEvents Label36 As System.Windows.Forms.Label
   Public WithEvents Label37 As System.Windows.Forms.Label
   Public WithEvents Label38 As System.Windows.Forms.Label
   Friend WithEvents EliminaImg As System.Windows.Forms.Button
   Friend WithEvents ApriImg As System.Windows.Forms.Button
   Public WithEvents picFoto As System.Windows.Forms.PictureBox
   Public WithEvents txtIndirizzo As System.Windows.Forms.TextBox
   Public WithEvents txtPIva As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents txtRagSoc As System.Windows.Forms.TextBox
   Public WithEvents Label31 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents txtInternet As System.Windows.Forms.TextBox
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents txtMail As System.Windows.Forms.TextBox
   Public WithEvents txtFax As System.Windows.Forms.TextBox
   Public WithEvents txtTel As System.Windows.Forms.TextBox
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents Button1 As System.Windows.Forms.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents tbrSalva As ToolBarButton
   Public WithEvents txtCodiceFiscale As TextBox
   Public WithEvents Label8 As Label
   Friend WithEvents cmbNazione As ComboBox
   Public WithEvents txtPec As TextBox
   Friend WithEvents Label13 As Label
   Friend WithEvents TabPage4 As TabPage
   Friend WithEvents eui_txtTiSeCodiceFiscale As Elegant.Ui.TextBox
   Friend WithEvents Label72 As Elegant.Ui.Label
   Friend WithEvents cmbRegimeFiscale As ComboBox
   Public WithEvents Label12 As Label
   Friend WithEvents TabControl2 As TabControl
   Friend WithEvents TabPage5 As TabPage
   Friend WithEvents TabPage6 As TabPage
   Friend WithEvents Label67 As Elegant.Ui.Label
   Friend WithEvents Label68 As Elegant.Ui.Label
   Friend WithEvents Label69 As Elegant.Ui.Label
   Friend WithEvents eui_txtTiSeCodiceEORI As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTiSeTitolo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTiSeCognome As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTiSeDenominazione As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTiSeNome As Elegant.Ui.TextBox
   Friend WithEvents Label70 As Elegant.Ui.Label
   Friend WithEvents Label71 As Elegant.Ui.Label
   Friend WithEvents eui_txtTiSeIdCodice As Elegant.Ui.TextBox
   Friend WithEvents Label73 As Elegant.Ui.Label
   Friend WithEvents eui_cmbTiSeIdPaese As Elegant.Ui.ComboBox
   Friend WithEvents Label74 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCpUfficioREA As Elegant.Ui.ComboBox
   Friend WithEvents eui_cmbCpStatoLiquidazioneREA As Elegant.Ui.ComboBox
   Friend WithEvents Label14 As Elegant.Ui.Label
   Friend WithEvents Label41 As Elegant.Ui.Label
   Public WithEvents Label11 As Label
   Friend WithEvents eui_txtCpNumeroREA As Elegant.Ui.TextBox
   Friend WithEvents eui_cmbSoggettoEmittente As Elegant.Ui.ComboBox
   Friend WithEvents Label75 As Elegant.Ui.Label
   Public WithEvents txtProvincia As TextBox
   Friend WithEvents tbrElimina As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAzienda))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.tbrSalva = New System.Windows.Forms.ToolBarButton()
      Me.tbrElimina = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.lblIntestazione = New System.Windows.Forms.Label()
      Me.chkVisRagSoc = New System.Windows.Forms.CheckBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.TabControl1 = New System.Windows.Forms.TabControl()
      Me.TabPage1 = New System.Windows.Forms.TabPage()
      Me.txtProvincia = New System.Windows.Forms.TextBox()
      Me.cmbRegimeFiscale = New System.Windows.Forms.ComboBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.cmbNazione = New System.Windows.Forms.ComboBox()
      Me.txtCodiceFiscale = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.EliminaImg = New System.Windows.Forms.Button()
      Me.ApriImg = New System.Windows.Forms.Button()
      Me.picFoto = New System.Windows.Forms.PictureBox()
      Me.txtIndirizzo = New System.Windows.Forms.TextBox()
      Me.txtPIva = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtRagSoc = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.TabPage3 = New System.Windows.Forms.TabPage()
      Me.txtPec = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.txtInternet = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtMail = New System.Windows.Forms.TextBox()
      Me.txtFax = New System.Windows.Forms.TextBox()
      Me.txtTel = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.TabPage2 = New System.Windows.Forms.TabPage()
      Me.Button1 = New System.Windows.Forms.Button()
      Me.txtIBAN = New System.Windows.Forms.TextBox()
      Me.Label32 = New System.Windows.Forms.Label()
      Me.cmbPagamento = New System.Windows.Forms.ComboBox()
      Me.Label33 = New System.Windows.Forms.Label()
      Me.txtCIN = New System.Windows.Forms.TextBox()
      Me.txtCC = New System.Windows.Forms.TextBox()
      Me.txtCAB = New System.Windows.Forms.TextBox()
      Me.txtABI = New System.Windows.Forms.TextBox()
      Me.txtBanca = New System.Windows.Forms.TextBox()
      Me.Label34 = New System.Windows.Forms.Label()
      Me.Label35 = New System.Windows.Forms.Label()
      Me.Label36 = New System.Windows.Forms.Label()
      Me.Label37 = New System.Windows.Forms.Label()
      Me.Label38 = New System.Windows.Forms.Label()
      Me.TabPage4 = New System.Windows.Forms.TabPage()
      Me.TabControl2 = New System.Windows.Forms.TabControl()
      Me.TabPage5 = New System.Windows.Forms.TabPage()
      Me.eui_txtCpNumeroREA = New Elegant.Ui.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.eui_cmbCpUfficioREA = New Elegant.Ui.ComboBox()
      Me.eui_cmbCpStatoLiquidazioneREA = New Elegant.Ui.ComboBox()
      Me.Label14 = New Elegant.Ui.Label()
      Me.Label41 = New Elegant.Ui.Label()
      Me.TabPage6 = New System.Windows.Forms.TabPage()
      Me.eui_cmbSoggettoEmittente = New Elegant.Ui.ComboBox()
      Me.Label75 = New Elegant.Ui.Label()
      Me.Label67 = New Elegant.Ui.Label()
      Me.Label68 = New Elegant.Ui.Label()
      Me.Label69 = New Elegant.Ui.Label()
      Me.eui_txtTiSeCodiceEORI = New Elegant.Ui.TextBox()
      Me.eui_txtTiSeTitolo = New Elegant.Ui.TextBox()
      Me.eui_txtTiSeCognome = New Elegant.Ui.TextBox()
      Me.eui_txtTiSeDenominazione = New Elegant.Ui.TextBox()
      Me.eui_txtTiSeNome = New Elegant.Ui.TextBox()
      Me.Label70 = New Elegant.Ui.Label()
      Me.Label71 = New Elegant.Ui.Label()
      Me.eui_txtTiSeIdCodice = New Elegant.Ui.TextBox()
      Me.Label73 = New Elegant.Ui.Label()
      Me.eui_cmbTiSeIdPaese = New Elegant.Ui.ComboBox()
      Me.Label74 = New Elegant.Ui.Label()
      Me.Label72 = New Elegant.Ui.Label()
      Me.eui_txtTiSeCodiceFiscale = New Elegant.Ui.TextBox()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabControl1.SuspendLayout()
      Me.TabPage1.SuspendLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage3.SuspendLayout()
      Me.TabPage2.SuspendLayout()
      Me.TabPage4.SuspendLayout()
      Me.TabControl2.SuspendLayout()
      Me.TabPage5.SuspendLayout()
      Me.TabPage6.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbrSalva, Me.tbrElimina})
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(581, 28)
      Me.ToolBar1.TabIndex = 1
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      '
      'tbrSalva
      '
      Me.tbrSalva.ImageIndex = 1
      Me.tbrSalva.Name = "tbrSalva"
      Me.tbrSalva.Tag = "Salva"
      Me.tbrSalva.Text = "Salva e chiudi"
      Me.tbrSalva.ToolTipText = "Salva tutti i dati e chiude la finestra."
      '
      'tbrElimina
      '
      Me.tbrElimina.ImageIndex = 2
      Me.tbrElimina.Name = "tbrElimina"
      Me.tbrElimina.Tag = "Elimina"
      Me.tbrElimina.Text = "Elimina"
      Me.tbrElimina.ToolTipText = "Elimina tutti i dati"
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "DeleteHS.png")
      Me.ImageList1.Images.SetKeyName(1, "Save_Small.png")
      Me.ImageList1.Images.SetKeyName(2, "Delete_Small.png")
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.lblIntestazione)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 28)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(581, 20)
      Me.Panel1.TabIndex = 19
      '
      'lblIntestazione
      '
      Me.lblIntestazione.AutoSize = True
      Me.lblIntestazione.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblIntestazione.ForeColor = System.Drawing.SystemColors.Window
      Me.lblIntestazione.Location = New System.Drawing.Point(5, 2)
      Me.lblIntestazione.Name = "lblIntestazione"
      Me.lblIntestazione.Size = New System.Drawing.Size(16, 16)
      Me.lblIntestazione.TabIndex = 0
      Me.lblIntestazione.Text = "#"
      '
      'chkVisRagSoc
      '
      Me.chkVisRagSoc.BackColor = System.Drawing.SystemColors.Control
      Me.chkVisRagSoc.Cursor = System.Windows.Forms.Cursors.Default
      Me.chkVisRagSoc.ForeColor = System.Drawing.SystemColors.Desktop
      Me.chkVisRagSoc.Location = New System.Drawing.Point(104, 360)
      Me.chkVisRagSoc.Name = "chkVisRagSoc"
      Me.chkVisRagSoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.chkVisRagSoc.Size = New System.Drawing.Size(400, 16)
      Me.chkVisRagSoc.TabIndex = 11
      Me.chkVisRagSoc.Text = "Visualizzare la ragione sociale nella barra di intestazione dell'applicazione"
      Me.chkVisRagSoc.UseVisualStyleBackColor = False
      Me.chkVisRagSoc.Visible = False
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'TabControl1
      '
      Me.TabControl1.Controls.Add(Me.TabPage1)
      Me.TabControl1.Controls.Add(Me.TabPage3)
      Me.TabControl1.Controls.Add(Me.TabPage2)
      Me.TabControl1.Controls.Add(Me.TabPage4)
      Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl1.Location = New System.Drawing.Point(0, 48)
      Me.TabControl1.Multiline = True
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedIndex = 0
      Me.TabControl1.Size = New System.Drawing.Size(581, 333)
      Me.TabControl1.TabIndex = 0
      '
      'TabPage1
      '
      Me.TabPage1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage1.Controls.Add(Me.txtProvincia)
      Me.TabPage1.Controls.Add(Me.cmbRegimeFiscale)
      Me.TabPage1.Controls.Add(Me.Label12)
      Me.TabPage1.Controls.Add(Me.cmbNazione)
      Me.TabPage1.Controls.Add(Me.txtCodiceFiscale)
      Me.TabPage1.Controls.Add(Me.Label8)
      Me.TabPage1.Controls.Add(Me.EliminaImg)
      Me.TabPage1.Controls.Add(Me.ApriImg)
      Me.TabPage1.Controls.Add(Me.picFoto)
      Me.TabPage1.Controls.Add(Me.txtIndirizzo)
      Me.TabPage1.Controls.Add(Me.txtPIva)
      Me.TabPage1.Controls.Add(Me.txtCap)
      Me.TabPage1.Controls.Add(Me.txtCittà)
      Me.TabPage1.Controls.Add(Me.txtRagSoc)
      Me.TabPage1.Controls.Add(Me.Label31)
      Me.TabPage1.Controls.Add(Me.Label10)
      Me.TabPage1.Controls.Add(Me.Label9)
      Me.TabPage1.Controls.Add(Me.Label6)
      Me.TabPage1.Controls.Add(Me.Label5)
      Me.TabPage1.Controls.Add(Me.Label4)
      Me.TabPage1.Controls.Add(Me.Label3)
      Me.TabPage1.ForeColor = System.Drawing.SystemColors.Desktop
      Me.TabPage1.Location = New System.Drawing.Point(4, 22)
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(573, 307)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Tag = "Codice fornito da Azienda emettitrice di Buoni pasto:"
      Me.TabPage1.Text = "Dati principali"
      Me.TabPage1.ToolTipText = "Dati principali"
      '
      'txtProvincia
      '
      Me.txtProvincia.AcceptsReturn = True
      Me.txtProvincia.BackColor = System.Drawing.SystemColors.Window
      Me.txtProvincia.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProvincia.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProvincia.Location = New System.Drawing.Point(104, 197)
      Me.txtProvincia.MaxLength = 2
      Me.txtProvincia.Name = "txtProvincia"
      Me.txtProvincia.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProvincia.Size = New System.Drawing.Size(90, 20)
      Me.txtProvincia.TabIndex = 6
      '
      'cmbRegimeFiscale
      '
      Me.cmbRegimeFiscale.BackColor = System.Drawing.SystemColors.Window
      Me.cmbRegimeFiscale.Cursor = System.Windows.Forms.Cursors.Default
      Me.cmbRegimeFiscale.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbRegimeFiscale.ForeColor = System.Drawing.SystemColors.WindowText
      Me.cmbRegimeFiscale.Items.AddRange(New Object() {" ", "RF01 Ordinario", "RF02 Contribuenti minimi (art. 1, c.96-117, L. 244/2007)", "RF04 Agricoltura e attività connesse e pesca (artt. 34 e 34-bis, D.P.R. 633/1972)" &
                "", "RF05 Vendita sali e tabacchi (art. 74, c.1, D.P.R. 633/1972)", "RF06 Commercio dei fiammiferi (art. 74, c.1, D.P.R. 633/1972)", "RF07 Editoria (art. 74, c.1, D.P.R. 633/1972)", "RF08 Gestione di servizi di telefonia pubblica (art. 74, c.1, D.P.R. 633/1972)", "RF09 Rivendita di documenti di trasporto pubblico e di sosta (art. 74, c.1, D.P.R" &
                ". 633/1972)", "RF10 Intrattenimenti, giochi e altre attività di cui alla tariffa allegata al D.P" &
                ".R. n. 640/72 (art. 74, c.6, D.P.R. 633/1972)", "RF11 Agenzie di viaggi e turismo (art. 74-ter, D.P.R. 633/1972)", "RF12 Agriturismo (art. 5, c.2, L. 413/1991)", "RF13 Vendite a domicilio (art. 25-bis, c.6, D.P.R. 600/1973)", "RF14 Rivendita di beni usati, di oggetti d’arte, d’antiquariato o da collezione (" &
                "art. 36, D.L. 41/1995)", "RF15 Agenzie di vendite all’asta di oggetti d’arte, antiquariato o da collezione " &
                "(art. 40-bis, D.L. 41/1995)", "RF16 IVA per cassa P.A. (art. 6, c.5, D.P.R. 633/1972)", "RF17 IVA per cassa (art. 32-bis, D.L. 83/2012)", "RF18 Altro", "RF19 Forfettario (art.1, c. 54-89, L. 190/2014)"})
      Me.cmbRegimeFiscale.Location = New System.Drawing.Point(104, 251)
      Me.cmbRegimeFiscale.Name = "cmbRegimeFiscale"
      Me.cmbRegimeFiscale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.cmbRegimeFiscale.Size = New System.Drawing.Size(416, 21)
      Me.cmbRegimeFiscale.TabIndex = 8
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(14, 251)
      Me.Label12.Name = "Label12"
      Me.Label12.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label12.Size = New System.Drawing.Size(82, 13)
      Me.Label12.TabIndex = 219
      Me.Label12.Text = "Regime Fiscale:"
      '
      'cmbNazione
      '
      Me.cmbNazione.Location = New System.Drawing.Point(104, 224)
      Me.cmbNazione.Name = "cmbNazione"
      Me.cmbNazione.Size = New System.Drawing.Size(160, 21)
      Me.cmbNazione.TabIndex = 7
      '
      'txtCodiceFiscale
      '
      Me.txtCodiceFiscale.AcceptsReturn = True
      Me.txtCodiceFiscale.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodiceFiscale.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodiceFiscale.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodiceFiscale.Location = New System.Drawing.Point(104, 82)
      Me.txtCodiceFiscale.MaxLength = 16
      Me.txtCodiceFiscale.Name = "txtCodiceFiscale"
      Me.txtCodiceFiscale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodiceFiscale.Size = New System.Drawing.Size(160, 20)
      Me.txtCodiceFiscale.TabIndex = 2
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(14, 82)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(79, 13)
      Me.Label8.TabIndex = 211
      Me.Label8.Text = "Codice Fiscale:"
      '
      'EliminaImg
      '
      Me.EliminaImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.EliminaImg.Location = New System.Drawing.Point(447, 184)
      Me.EliminaImg.Name = "EliminaImg"
      Me.EliminaImg.Size = New System.Drawing.Size(72, 24)
      Me.EliminaImg.TabIndex = 10
      Me.EliminaImg.Text = "&Elimina"
      '
      'ApriImg
      '
      Me.ApriImg.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ApriImg.Location = New System.Drawing.Point(367, 184)
      Me.ApriImg.Name = "ApriImg"
      Me.ApriImg.Size = New System.Drawing.Size(72, 24)
      Me.ApriImg.TabIndex = 9
      Me.ApriImg.Text = "&Apri"
      '
      'picFoto
      '
      Me.picFoto.BackColor = System.Drawing.Color.White
      Me.picFoto.Cursor = System.Windows.Forms.Cursors.Default
      Me.picFoto.Location = New System.Drawing.Point(367, 24)
      Me.picFoto.Name = "picFoto"
      Me.picFoto.Size = New System.Drawing.Size(153, 153)
      Me.picFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picFoto.TabIndex = 209
      Me.picFoto.TabStop = False
      '
      'txtIndirizzo
      '
      Me.txtIndirizzo.AcceptsReturn = True
      Me.txtIndirizzo.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo.Location = New System.Drawing.Point(104, 119)
      Me.txtIndirizzo.MaxLength = 100
      Me.txtIndirizzo.Name = "txtIndirizzo"
      Me.txtIndirizzo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo.Size = New System.Drawing.Size(248, 20)
      Me.txtIndirizzo.TabIndex = 3
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(104, 56)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(160, 20)
      Me.txtPIva.TabIndex = 1
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(104, 171)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(90, 20)
      Me.txtCap.TabIndex = 5
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(104, 145)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(248, 20)
      Me.txtCittà.TabIndex = 4
      '
      'txtRagSoc
      '
      Me.txtRagSoc.AcceptsReturn = True
      Me.txtRagSoc.BackColor = System.Drawing.SystemColors.Window
      Me.txtRagSoc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRagSoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRagSoc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRagSoc.Location = New System.Drawing.Point(104, 24)
      Me.txtRagSoc.MaxLength = 50
      Me.txtRagSoc.Name = "txtRagSoc"
      Me.txtRagSoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRagSoc.Size = New System.Drawing.Size(248, 20)
      Me.txtRagSoc.TabIndex = 0
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(14, 56)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(69, 13)
      Me.Label31.TabIndex = 206
      Me.Label31.Text = "Partita I.V.A.:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(14, 224)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(49, 13)
      Me.Label10.TabIndex = 204
      Me.Label10.Text = "Nazione:"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(14, 197)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(54, 13)
      Me.Label9.TabIndex = 203
      Me.Label9.Text = "Provincia:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(14, 171)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(40, 13)
      Me.Label6.TabIndex = 202
      Me.Label6.Text = "C.A.P.:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(14, 145)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(31, 13)
      Me.Label5.TabIndex = 201
      Me.Label5.Text = "Città:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(14, 119)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(48, 13)
      Me.Label4.TabIndex = 200
      Me.Label4.Text = "Indirizzo:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(14, 24)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(86, 13)
      Me.Label3.TabIndex = 199
      Me.Label3.Text = "Ragione sociale:"
      '
      'TabPage3
      '
      Me.TabPage3.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage3.Controls.Add(Me.txtPec)
      Me.TabPage3.Controls.Add(Me.Label13)
      Me.TabPage3.Controls.Add(Me.txtInternet)
      Me.TabPage3.Controls.Add(Me.Label2)
      Me.TabPage3.Controls.Add(Me.txtMail)
      Me.TabPage3.Controls.Add(Me.txtFax)
      Me.TabPage3.Controls.Add(Me.txtTel)
      Me.TabPage3.Controls.Add(Me.Label7)
      Me.TabPage3.Controls.Add(Me.Label1)
      Me.TabPage3.Controls.Add(Me.Label21)
      Me.TabPage3.Location = New System.Drawing.Point(4, 22)
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(565, 299)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "Tel./Internet"
      Me.TabPage3.ToolTipText = "Dati sul telefono e Internet"
      Me.TabPage3.Visible = False
      '
      'txtPec
      '
      Me.txtPec.AcceptsReturn = True
      Me.txtPec.BackColor = System.Drawing.SystemColors.Window
      Me.txtPec.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPec.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPec.Location = New System.Drawing.Point(112, 106)
      Me.txtPec.MaxLength = 0
      Me.txtPec.Name = "txtPec"
      Me.txtPec.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPec.Size = New System.Drawing.Size(248, 20)
      Me.txtPec.TabIndex = 3
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(24, 106)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(31, 13)
      Me.Label13.TabIndex = 220
      Me.Label13.Text = "PEC:"
      '
      'txtInternet
      '
      Me.txtInternet.AcceptsReturn = True
      Me.txtInternet.BackColor = System.Drawing.SystemColors.Window
      Me.txtInternet.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtInternet.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtInternet.Location = New System.Drawing.Point(112, 133)
      Me.txtInternet.MaxLength = 0
      Me.txtInternet.Name = "txtInternet"
      Me.txtInternet.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtInternet.Size = New System.Drawing.Size(248, 20)
      Me.txtInternet.TabIndex = 4
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(24, 133)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(46, 13)
      Me.Label2.TabIndex = 218
      Me.Label2.Text = "Internet:"
      '
      'txtMail
      '
      Me.txtMail.AcceptsReturn = True
      Me.txtMail.BackColor = System.Drawing.SystemColors.Window
      Me.txtMail.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtMail.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtMail.Location = New System.Drawing.Point(112, 80)
      Me.txtMail.MaxLength = 0
      Me.txtMail.Name = "txtMail"
      Me.txtMail.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtMail.Size = New System.Drawing.Size(248, 20)
      Me.txtMail.TabIndex = 2
      '
      'txtFax
      '
      Me.txtFax.AcceptsReturn = True
      Me.txtFax.BackColor = System.Drawing.SystemColors.Window
      Me.txtFax.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtFax.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtFax.Location = New System.Drawing.Point(112, 48)
      Me.txtFax.MaxLength = 15
      Me.txtFax.Name = "txtFax"
      Me.txtFax.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtFax.Size = New System.Drawing.Size(160, 20)
      Me.txtFax.TabIndex = 1
      '
      'txtTel
      '
      Me.txtTel.AcceptsReturn = True
      Me.txtTel.BackColor = System.Drawing.SystemColors.Window
      Me.txtTel.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTel.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTel.Location = New System.Drawing.Point(112, 24)
      Me.txtTel.MaxLength = 15
      Me.txtTel.Name = "txtTel"
      Me.txtTel.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTel.Size = New System.Drawing.Size(160, 20)
      Me.txtTel.TabIndex = 0
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(24, 80)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(39, 13)
      Me.Label7.TabIndex = 217
      Me.Label7.Text = "E-Mail:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(24, 48)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(27, 13)
      Me.Label1.TabIndex = 216
      Me.Label1.Text = "Fax:"
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(24, 24)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(52, 13)
      Me.Label21.TabIndex = 215
      Me.Label21.Text = "Telefono:"
      '
      'TabPage2
      '
      Me.TabPage2.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage2.Controls.Add(Me.Button1)
      Me.TabPage2.Controls.Add(Me.txtIBAN)
      Me.TabPage2.Controls.Add(Me.Label32)
      Me.TabPage2.Controls.Add(Me.cmbPagamento)
      Me.TabPage2.Controls.Add(Me.Label33)
      Me.TabPage2.Controls.Add(Me.txtCIN)
      Me.TabPage2.Controls.Add(Me.txtCC)
      Me.TabPage2.Controls.Add(Me.txtCAB)
      Me.TabPage2.Controls.Add(Me.txtABI)
      Me.TabPage2.Controls.Add(Me.txtBanca)
      Me.TabPage2.Controls.Add(Me.Label34)
      Me.TabPage2.Controls.Add(Me.Label35)
      Me.TabPage2.Controls.Add(Me.Label36)
      Me.TabPage2.Controls.Add(Me.Label37)
      Me.TabPage2.Controls.Add(Me.Label38)
      Me.TabPage2.Location = New System.Drawing.Point(4, 22)
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(565, 299)
      Me.TabPage2.TabIndex = 6
      Me.TabPage2.Text = "Modalità pagamento"
      Me.TabPage2.Visible = False
      '
      'Button1
      '
      Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.Button1.Location = New System.Drawing.Point(408, 192)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(64, 24)
      Me.Button1.TabIndex = 55721
      Me.Button1.Text = "Button1"
      Me.Button1.Visible = False
      '
      'txtIBAN
      '
      Me.txtIBAN.AcceptsReturn = True
      Me.txtIBAN.BackColor = System.Drawing.SystemColors.Window
      Me.txtIBAN.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIBAN.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIBAN.Location = New System.Drawing.Point(120, 192)
      Me.txtIBAN.MaxLength = 0
      Me.txtIBAN.Name = "txtIBAN"
      Me.txtIBAN.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIBAN.Size = New System.Drawing.Size(260, 20)
      Me.txtIBAN.TabIndex = 6
      '
      'Label32
      '
      Me.Label32.AutoSize = True
      Me.Label32.BackColor = System.Drawing.Color.Transparent
      Me.Label32.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label32.ForeColor = System.Drawing.Color.Black
      Me.Label32.Location = New System.Drawing.Point(32, 192)
      Me.Label32.Name = "Label32"
      Me.Label32.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label32.Size = New System.Drawing.Size(35, 13)
      Me.Label32.TabIndex = 55720
      Me.Label32.Text = "IBAN:"
      '
      'cmbPagamento
      '
      Me.cmbPagamento.Location = New System.Drawing.Point(120, 32)
      Me.cmbPagamento.Name = "cmbPagamento"
      Me.cmbPagamento.Size = New System.Drawing.Size(312, 21)
      Me.cmbPagamento.TabIndex = 0
      '
      'Label33
      '
      Me.Label33.AutoSize = True
      Me.Label33.ForeColor = System.Drawing.Color.Black
      Me.Label33.Location = New System.Drawing.Point(32, 32)
      Me.Label33.Name = "Label33"
      Me.Label33.Size = New System.Drawing.Size(87, 13)
      Me.Label33.TabIndex = 55718
      Me.Label33.Text = "Tipo pagamento:"
      '
      'txtCIN
      '
      Me.txtCIN.AcceptsReturn = True
      Me.txtCIN.BackColor = System.Drawing.SystemColors.Window
      Me.txtCIN.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCIN.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCIN.Location = New System.Drawing.Point(120, 168)
      Me.txtCIN.MaxLength = 1
      Me.txtCIN.Name = "txtCIN"
      Me.txtCIN.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCIN.Size = New System.Drawing.Size(40, 20)
      Me.txtCIN.TabIndex = 5
      '
      'txtCC
      '
      Me.txtCC.AcceptsReturn = True
      Me.txtCC.BackColor = System.Drawing.SystemColors.Window
      Me.txtCC.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCC.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCC.Location = New System.Drawing.Point(120, 136)
      Me.txtCC.MaxLength = 12
      Me.txtCC.Name = "txtCC"
      Me.txtCC.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCC.Size = New System.Drawing.Size(144, 20)
      Me.txtCC.TabIndex = 4
      '
      'txtCAB
      '
      Me.txtCAB.AcceptsReturn = True
      Me.txtCAB.BackColor = System.Drawing.SystemColors.Window
      Me.txtCAB.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCAB.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCAB.Location = New System.Drawing.Point(120, 112)
      Me.txtCAB.MaxLength = 5
      Me.txtCAB.Name = "txtCAB"
      Me.txtCAB.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCAB.Size = New System.Drawing.Size(144, 20)
      Me.txtCAB.TabIndex = 3
      '
      'txtABI
      '
      Me.txtABI.AcceptsReturn = True
      Me.txtABI.BackColor = System.Drawing.SystemColors.Window
      Me.txtABI.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtABI.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtABI.Location = New System.Drawing.Point(120, 88)
      Me.txtABI.MaxLength = 5
      Me.txtABI.Name = "txtABI"
      Me.txtABI.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtABI.Size = New System.Drawing.Size(144, 20)
      Me.txtABI.TabIndex = 2
      '
      'txtBanca
      '
      Me.txtBanca.AcceptsReturn = True
      Me.txtBanca.BackColor = System.Drawing.SystemColors.Window
      Me.txtBanca.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtBanca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBanca.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtBanca.Location = New System.Drawing.Point(120, 64)
      Me.txtBanca.MaxLength = 50
      Me.txtBanca.Name = "txtBanca"
      Me.txtBanca.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtBanca.Size = New System.Drawing.Size(312, 20)
      Me.txtBanca.TabIndex = 1
      '
      'Label34
      '
      Me.Label34.AutoSize = True
      Me.Label34.BackColor = System.Drawing.Color.Transparent
      Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label34.ForeColor = System.Drawing.Color.Black
      Me.Label34.Location = New System.Drawing.Point(32, 168)
      Me.Label34.Name = "Label34"
      Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label34.Size = New System.Drawing.Size(28, 13)
      Me.Label34.TabIndex = 176
      Me.Label34.Text = "CIN:"
      '
      'Label35
      '
      Me.Label35.AutoSize = True
      Me.Label35.BackColor = System.Drawing.Color.Transparent
      Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label35.ForeColor = System.Drawing.Color.Black
      Me.Label35.Location = New System.Drawing.Point(32, 136)
      Me.Label35.Name = "Label35"
      Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label35.Size = New System.Drawing.Size(29, 13)
      Me.Label35.TabIndex = 175
      Me.Label35.Text = "C/C:"
      '
      'Label36
      '
      Me.Label36.AutoSize = True
      Me.Label36.BackColor = System.Drawing.Color.Transparent
      Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label36.ForeColor = System.Drawing.Color.Black
      Me.Label36.Location = New System.Drawing.Point(32, 112)
      Me.Label36.Name = "Label36"
      Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label36.Size = New System.Drawing.Size(31, 13)
      Me.Label36.TabIndex = 174
      Me.Label36.Text = "CAB:"
      '
      'Label37
      '
      Me.Label37.AutoSize = True
      Me.Label37.BackColor = System.Drawing.Color.Transparent
      Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label37.ForeColor = System.Drawing.Color.Black
      Me.Label37.Location = New System.Drawing.Point(32, 88)
      Me.Label37.Name = "Label37"
      Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label37.Size = New System.Drawing.Size(27, 13)
      Me.Label37.TabIndex = 173
      Me.Label37.Text = "ABI:"
      '
      'Label38
      '
      Me.Label38.AutoSize = True
      Me.Label38.BackColor = System.Drawing.Color.Transparent
      Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label38.ForeColor = System.Drawing.Color.Black
      Me.Label38.Location = New System.Drawing.Point(32, 64)
      Me.Label38.Name = "Label38"
      Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label38.Size = New System.Drawing.Size(41, 13)
      Me.Label38.TabIndex = 172
      Me.Label38.Text = "Banca:"
      '
      'TabPage4
      '
      Me.TabPage4.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage4.Controls.Add(Me.TabControl2)
      Me.TabPage4.Location = New System.Drawing.Point(4, 22)
      Me.TabPage4.Name = "TabPage4"
      Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage4.Size = New System.Drawing.Size(573, 307)
      Me.TabPage4.TabIndex = 7
      Me.TabPage4.Text = "Fatturazione Elettronica"
      '
      'TabControl2
      '
      Me.TabControl2.Controls.Add(Me.TabPage5)
      Me.TabControl2.Controls.Add(Me.TabPage6)
      Me.TabControl2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.TabControl2.Location = New System.Drawing.Point(3, 3)
      Me.TabControl2.Name = "TabControl2"
      Me.TabControl2.SelectedIndex = 0
      Me.TabControl2.Size = New System.Drawing.Size(567, 301)
      Me.TabControl2.TabIndex = 222
      '
      'TabPage5
      '
      Me.TabPage5.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage5.Controls.Add(Me.eui_txtCpNumeroREA)
      Me.TabPage5.Controls.Add(Me.Label11)
      Me.TabPage5.Controls.Add(Me.eui_cmbCpUfficioREA)
      Me.TabPage5.Controls.Add(Me.eui_cmbCpStatoLiquidazioneREA)
      Me.TabPage5.Controls.Add(Me.Label14)
      Me.TabPage5.Controls.Add(Me.Label41)
      Me.TabPage5.Location = New System.Drawing.Point(4, 22)
      Me.TabPage5.Name = "TabPage5"
      Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage5.Size = New System.Drawing.Size(559, 275)
      Me.TabPage5.TabIndex = 0
      Me.TabPage5.Text = "Iscrizione REA"
      '
      'eui_txtCpNumeroREA
      '
      Me.eui_txtCpNumeroREA.Id = "d6e12046-94d2-44bc-ac29-6669b5e32222"
      Me.eui_txtCpNumeroREA.Location = New System.Drawing.Point(110, 48)
      Me.eui_txtCpNumeroREA.MaxLength = 20
      Me.eui_txtCpNumeroREA.Name = "eui_txtCpNumeroREA"
      Me.eui_txtCpNumeroREA.Size = New System.Drawing.Size(202, 21)
      Me.eui_txtCpNumeroREA.TabIndex = 1
      Me.eui_txtCpNumeroREA.TextEditorWidth = 196
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(13, 48)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(81, 13)
      Me.Label11.TabIndex = 215
      Me.Label11.Text = "Numero R.E.A.:"
      '
      'eui_cmbCpUfficioREA
      '
      Me.eui_cmbCpUfficioREA.Editable = False
      Me.eui_cmbCpUfficioREA.FormattingEnabled = False
      Me.eui_cmbCpUfficioREA.Id = "4d686c59-8292-4895-8cf4-6da4193c5757"
      Me.eui_cmbCpUfficioREA.Items.AddRange(New Object() {" ", "AG Agrigento", "AL Alessandria", "AN Ancona", "AO Aosta", "AR Arezzo", "AP Ascoli Piceno", "AT Asti", "AV Avellino", "BA Bari", "BT Barletta-Andria-Trani", "BL Belluno", "BN Benevento", "BG Bergamo", "BI Biella", "BO Bologna", "BZ Bolzano", "BS Brescia", "BR Brindisi", "CA Cagliari", "CL Caltanissetta", "CB Campobasso", "CI Carbonia-Iglesias", "CE Caserta", "CT Catania", "CZ Catanzaro", "CH Chieti", "CO Como", "CS Cosenza", "CR Cremona", "KR Crotone", "CN Cuneo", "EN Enna", "FM Fermo", "FE Ferrara", "FI Firenze", "FU Fiume", "FG Foggia", "FC Forlì-Cesena", "FR Frosinone", "GE Genova", "GO Gorizia", "GR Grosseto", "IM Imperia", "IS Isernia", "AQ L'Aquila", "SP La Spezia", "LT Latina", "LE Lecce", "LC Lecco", "LI Livorno", "LO Lodi", "LB Lubiana", "LU Lucca", "MC Macerata", "MN Mantova", "MS Massa-Carrara", "MT Matera", "VS Medio Campidano", "ME Messina", "MI Milano", "MO Modena", "MB Monza e Brianza", "NA Napoli", "NO Novara", "NU Nuoro", "OG Ogliastra", "OT Olbia-Tempio", "OR Oristano", "PD Padova", "PA Palermo", "PR Parma", "PV Pavia", "PG Perugia", "PU Pesaro e Urbino ", "PE Pescara", "PC Piacenza", "PI Pisa", "PT Pistoia", "PL Pola", "PN Pordenone", "PZ Potenza", "PO Prato", "RG Ragusa", "RA Ravenna", "RC Reggio di Calabria", "RE Reggio nell'Emilia", "RI Rieti", "RN Rimini", "RM Roma", "RO Rovigo", "SA Salerno", "SS Sassari", "SV Savona", "SI Siena", "SR Siracusa", "SO Sondrio", "SU Sud Sardegna", "TA Taranto", "TE Teramo", "TR Terni", "TO Torino", "TP Trapani", "TN Trento", "TV Treviso", "TS Trieste", "UD Udine", "VA Varese", "VE Venezia", "VB Verbano-Cusio-Ossola", "VC Vercelli", "VR Verona", "VV Vibo Valentia", "VI Vicenza", "VT Viterbo", "ZA Zara"})
      Me.eui_cmbCpUfficioREA.Location = New System.Drawing.Point(110, 14)
      Me.eui_cmbCpUfficioREA.Name = "eui_cmbCpUfficioREA"
      Me.eui_cmbCpUfficioREA.Size = New System.Drawing.Size(202, 21)
      Me.eui_cmbCpUfficioREA.TabIndex = 0
      Me.eui_cmbCpUfficioREA.TextEditorWidth = 183
      '
      'eui_cmbCpStatoLiquidazioneREA
      '
      Me.eui_cmbCpStatoLiquidazioneREA.Editable = False
      Me.eui_cmbCpStatoLiquidazioneREA.FormattingEnabled = False
      Me.eui_cmbCpStatoLiquidazioneREA.Id = "0a10dbc8-8458-48de-960e-87a137997afb"
      Me.eui_cmbCpStatoLiquidazioneREA.Items.AddRange(New Object() {"LS In liquidazione", "LN Non in liquidazione"})
      Me.eui_cmbCpStatoLiquidazioneREA.Location = New System.Drawing.Point(110, 80)
      Me.eui_cmbCpStatoLiquidazioneREA.Name = "eui_cmbCpStatoLiquidazioneREA"
      Me.eui_cmbCpStatoLiquidazioneREA.Size = New System.Drawing.Size(202, 21)
      Me.eui_cmbCpStatoLiquidazioneREA.TabIndex = 2
      Me.eui_cmbCpStatoLiquidazioneREA.TextEditorWidth = 183
      '
      'Label14
      '
      Me.Label14.Location = New System.Drawing.Point(16, 82)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(86, 19)
      Me.Label14.TabIndex = 16
      Me.Label14.Text = "Stato liquidazione:"
      '
      'Label41
      '
      Me.Label41.Location = New System.Drawing.Point(16, 16)
      Me.Label41.Name = "Label41"
      Me.Label41.Size = New System.Drawing.Size(76, 19)
      Me.Label41.TabIndex = 12
      Me.Label41.Text = "Ufficio:"
      '
      'TabPage6
      '
      Me.TabPage6.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.TabPage6.Controls.Add(Me.eui_cmbSoggettoEmittente)
      Me.TabPage6.Controls.Add(Me.Label75)
      Me.TabPage6.Controls.Add(Me.Label67)
      Me.TabPage6.Controls.Add(Me.Label68)
      Me.TabPage6.Controls.Add(Me.Label69)
      Me.TabPage6.Controls.Add(Me.eui_txtTiSeCodiceEORI)
      Me.TabPage6.Controls.Add(Me.eui_txtTiSeTitolo)
      Me.TabPage6.Controls.Add(Me.eui_txtTiSeCognome)
      Me.TabPage6.Controls.Add(Me.eui_txtTiSeDenominazione)
      Me.TabPage6.Controls.Add(Me.eui_txtTiSeNome)
      Me.TabPage6.Controls.Add(Me.Label70)
      Me.TabPage6.Controls.Add(Me.Label71)
      Me.TabPage6.Controls.Add(Me.eui_txtTiSeIdCodice)
      Me.TabPage6.Controls.Add(Me.Label73)
      Me.TabPage6.Controls.Add(Me.eui_cmbTiSeIdPaese)
      Me.TabPage6.Controls.Add(Me.Label74)
      Me.TabPage6.Controls.Add(Me.Label72)
      Me.TabPage6.Controls.Add(Me.eui_txtTiSeCodiceFiscale)
      Me.TabPage6.Location = New System.Drawing.Point(4, 22)
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
      Me.TabPage6.Size = New System.Drawing.Size(551, 267)
      Me.TabPage6.TabIndex = 1
      Me.TabPage6.Text = "Terzo Intermediario o Soggetto Emittente"
      '
      'eui_cmbSoggettoEmittente
      '
      Me.eui_cmbSoggettoEmittente.Editable = False
      Me.eui_cmbSoggettoEmittente.FormattingEnabled = False
      Me.eui_cmbSoggettoEmittente.Id = "aedfaf46-34ed-4262-bc19-e9d011b6dfa4"
      Me.eui_cmbSoggettoEmittente.Items.AddRange(New Object() {"CC Cessionario / Committente", "TZ Terzo"})
      Me.eui_cmbSoggettoEmittente.Location = New System.Drawing.Point(352, 220)
      Me.eui_cmbSoggettoEmittente.Name = "eui_cmbSoggettoEmittente"
      Me.eui_cmbSoggettoEmittente.Size = New System.Drawing.Size(160, 21)
      Me.eui_cmbSoggettoEmittente.TabIndex = 8
      Me.eui_cmbSoggettoEmittente.TextEditorWidth = 141
      '
      'Label75
      '
      Me.Label75.Location = New System.Drawing.Point(352, 201)
      Me.Label75.Name = "Label75"
      Me.Label75.Size = New System.Drawing.Size(92, 19)
      Me.Label75.TabIndex = 237
      Me.Label75.Text = "Soggetto emittente:"
      '
      'Label67
      '
      Me.Label67.Location = New System.Drawing.Point(18, 222)
      Me.Label67.Name = "Label67"
      Me.Label67.Size = New System.Drawing.Size(78, 19)
      Me.Label67.TabIndex = 235
      Me.Label67.Text = "Codice EORI:"
      '
      'Label68
      '
      Me.Label68.Location = New System.Drawing.Point(18, 195)
      Me.Label68.Name = "Label68"
      Me.Label68.Size = New System.Drawing.Size(78, 19)
      Me.Label68.TabIndex = 234
      Me.Label68.Text = "Titolo:"
      '
      'Label69
      '
      Me.Label69.Location = New System.Drawing.Point(19, 167)
      Me.Label69.Name = "Label69"
      Me.Label69.Size = New System.Drawing.Size(78, 19)
      Me.Label69.TabIndex = 233
      Me.Label69.Text = "Cognome:"
      '
      'eui_txtTiSeCodiceEORI
      '
      Me.eui_txtTiSeCodiceEORI.Id = "cfb7d1d7-790d-4dc4-81b2-a727944fea34"
      Me.eui_txtTiSeCodiceEORI.Location = New System.Drawing.Point(113, 220)
      Me.eui_txtTiSeCodiceEORI.MaxLength = 17
      Me.eui_txtTiSeCodiceEORI.Name = "eui_txtTiSeCodiceEORI"
      Me.eui_txtTiSeCodiceEORI.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeCodiceEORI.TabIndex = 7
      Me.eui_txtTiSeCodiceEORI.TextEditorWidth = 195
      '
      'eui_txtTiSeTitolo
      '
      Me.eui_txtTiSeTitolo.Id = "d7b2c482-99bf-4cba-a955-0654a417d113"
      Me.eui_txtTiSeTitolo.Location = New System.Drawing.Point(113, 193)
      Me.eui_txtTiSeTitolo.MaxLength = 10
      Me.eui_txtTiSeTitolo.Name = "eui_txtTiSeTitolo"
      Me.eui_txtTiSeTitolo.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeTitolo.TabIndex = 6
      Me.eui_txtTiSeTitolo.TextEditorWidth = 195
      '
      'eui_txtTiSeCognome
      '
      Me.eui_txtTiSeCognome.Id = "50d76e36-d8a6-4fe6-a906-e8ddc67ca282"
      Me.eui_txtTiSeCognome.Location = New System.Drawing.Point(113, 165)
      Me.eui_txtTiSeCognome.MaxLength = 60
      Me.eui_txtTiSeCognome.Name = "eui_txtTiSeCognome"
      Me.eui_txtTiSeCognome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeCognome.TabIndex = 5
      Me.eui_txtTiSeCognome.TextEditorWidth = 195
      '
      'eui_txtTiSeDenominazione
      '
      Me.eui_txtTiSeDenominazione.Id = "ede56250-1958-45df-9a25-7b64c8b28fca"
      Me.eui_txtTiSeDenominazione.Location = New System.Drawing.Point(112, 109)
      Me.eui_txtTiSeDenominazione.MaxLength = 80
      Me.eui_txtTiSeDenominazione.Name = "eui_txtTiSeDenominazione"
      Me.eui_txtTiSeDenominazione.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeDenominazione.TabIndex = 3
      Me.eui_txtTiSeDenominazione.TextEditorWidth = 195
      '
      'eui_txtTiSeNome
      '
      Me.eui_txtTiSeNome.Id = "567f89fa-c9dd-4004-8b09-2cd6c8b90932"
      Me.eui_txtTiSeNome.Location = New System.Drawing.Point(113, 137)
      Me.eui_txtTiSeNome.MaxLength = 60
      Me.eui_txtTiSeNome.Name = "eui_txtTiSeNome"
      Me.eui_txtTiSeNome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeNome.TabIndex = 4
      Me.eui_txtTiSeNome.TextEditorWidth = 195
      '
      'Label70
      '
      Me.Label70.Location = New System.Drawing.Point(19, 137)
      Me.Label70.Name = "Label70"
      Me.Label70.Size = New System.Drawing.Size(86, 19)
      Me.Label70.TabIndex = 230
      Me.Label70.Text = "Nome:"
      '
      'Label71
      '
      Me.Label71.Location = New System.Drawing.Point(18, 111)
      Me.Label71.Name = "Label71"
      Me.Label71.Size = New System.Drawing.Size(76, 19)
      Me.Label71.TabIndex = 227
      Me.Label71.Text = "Denominazione:"
      '
      'eui_txtTiSeIdCodice
      '
      Me.eui_txtTiSeIdCodice.Id = "9b8c1992-718b-4d99-8ca2-b2dc1efac116"
      Me.eui_txtTiSeIdCodice.Location = New System.Drawing.Point(112, 42)
      Me.eui_txtTiSeIdCodice.MaxLength = 28
      Me.eui_txtTiSeIdCodice.Name = "eui_txtTiSeIdCodice"
      Me.eui_txtTiSeIdCodice.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeIdCodice.TabIndex = 1
      Me.eui_txtTiSeIdCodice.TextEditorWidth = 195
      '
      'Label73
      '
      Me.Label73.Location = New System.Drawing.Point(18, 42)
      Me.Label73.Name = "Label73"
      Me.Label73.Size = New System.Drawing.Size(131, 19)
      Me.Label73.TabIndex = 225
      Me.Label73.Text = "Partita IVA:"
      '
      'eui_cmbTiSeIdPaese
      '
      Me.eui_cmbTiSeIdPaese.Editable = False
      Me.eui_cmbTiSeIdPaese.FormattingEnabled = False
      Me.eui_cmbTiSeIdPaese.Id = "1e3daa27-5dfd-46fb-b48f-94bbc397b819"
      Me.eui_cmbTiSeIdPaese.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbTiSeIdPaese.Location = New System.Drawing.Point(112, 14)
      Me.eui_cmbTiSeIdPaese.Name = "eui_cmbTiSeIdPaese"
      Me.eui_cmbTiSeIdPaese.Size = New System.Drawing.Size(201, 21)
      Me.eui_cmbTiSeIdPaese.TabIndex = 0
      Me.eui_cmbTiSeIdPaese.TextEditorWidth = 182
      '
      'Label74
      '
      Me.Label74.Location = New System.Drawing.Point(18, 16)
      Me.Label74.Name = "Label74"
      Me.Label74.Size = New System.Drawing.Size(50, 19)
      Me.Label74.TabIndex = 223
      Me.Label74.Text = "Paese:"
      '
      'Label72
      '
      Me.Label72.Location = New System.Drawing.Point(18, 77)
      Me.Label72.Name = "Label72"
      Me.Label72.Size = New System.Drawing.Size(87, 19)
      Me.Label72.TabIndex = 220
      Me.Label72.Text = "Codice fiscale:"
      '
      'eui_txtTiSeCodiceFiscale
      '
      Me.eui_txtTiSeCodiceFiscale.Id = "73541a07-8808-4c65-ac81-d943f8a01e93"
      Me.eui_txtTiSeCodiceFiscale.Location = New System.Drawing.Point(112, 75)
      Me.eui_txtTiSeCodiceFiscale.MaxLength = 16
      Me.eui_txtTiSeCodiceFiscale.Name = "eui_txtTiSeCodiceFiscale"
      Me.eui_txtTiSeCodiceFiscale.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeCodiceFiscale.TabIndex = 2
      Me.eui_txtTiSeCodiceFiscale.TextEditorWidth = 195
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmAzienda
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(581, 381)
      Me.Controls.Add(Me.TabControl1)
      Me.Controls.Add(Me.chkVisRagSoc)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Cursor = System.Windows.Forms.Cursors.Default
      Me.ForeColor = System.Drawing.Color.Black
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.KeyPreview = True
      Me.Location = New System.Drawing.Point(81, 63)
      Me.Name = "frmAzienda"
      Me.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.ShowInTaskbar = False
      Me.Tag = ""
      Me.Text = "Dati generali Azienda"
      Me.TransparencyKey = System.Drawing.Color.White
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabControl1.ResumeLayout(False)
      Me.TabPage1.ResumeLayout(False)
      Me.TabPage1.PerformLayout()
      CType(Me.picFoto, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage3.PerformLayout()
      Me.TabPage2.ResumeLayout(False)
      Me.TabPage2.PerformLayout()
      Me.TabPage4.ResumeLayout(False)
      Me.TabControl2.ResumeLayout(False)
      Me.TabPage5.ResumeLayout(False)
      Me.TabPage5.PerformLayout()
      Me.TabPage6.ResumeLayout(False)
      Me.TabPage6.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
#End Region

   Const NOME_TABELLA As String = "Azienda"
   Const TAB_NAZIONI As String = "Nazioni"
   Const TAB_PAGAMENTO As String = "ModPagamento"

   'Public PercorsoLogo As String = ""

   Private AAzienda As New Anagrafiche.Azienda(ConnString)
   Private CConvalida As New ConvalidaKeyPress

   Private Sub Salva()
      Try
         ' Aggiorna le tabelle dati da eventuali valori inseriti.
         AggiornaTabella(cmbNazione, TAB_NAZIONI)
         AggiornaTabella(cmbPagamento, TAB_PAGAMENTO)

         ' Salva i dati eventualmente modificati.
         AAzienda.RagSociale = txtRagSoc.Text
         AAzienda.Descrizione = String.Empty
         AAzienda.Piva = txtPIva.Text
         AAzienda.CodFisc = txtCodiceFiscale.Text
         AAzienda.Iri = String.Empty
         AAzienda.Indirizzo = txtIndirizzo.Text
         AAzienda.Cap = txtCap.Text
         AAzienda.Città = txtCittà.Text
         AAzienda.Provincia = txtProvincia.Text
         AAzienda.Regione = String.Empty
         AAzienda.Nazione = cmbNazione.Text
         AAzienda.RegimeFiscale = cmbRegimeFiscale.Text
         AAzienda.Telefono = txtTel.Text
         AAzienda.Fax = txtFax.Text
         AAzienda.Email = txtMail.Text
         AAzienda.PEC = txtPec.Text
         AAzienda.Internet = txtInternet.Text
         AAzienda.Attività = String.Empty
         AAzienda.PercorsoDB = String.Empty
         AAzienda.TipoPagamento = cmbPagamento.Text
         AAzienda.Banca = txtBanca.Text
         AAzienda.Abi = txtABI.Text
         AAzienda.Cab = txtCAB.Text
         AAzienda.Cc = txtCC.Text
         AAzienda.Cin = txtCIN.Text
         AAzienda.Iban = txtIBAN.Text

         ' Fatturazione Elettronica.
         AAzienda.UfficioRea = eui_cmbCpUfficioREA.Text
         AAzienda.NumeroRea = eui_txtCpNumeroREA.Text
         AAzienda.StatoLiquidazioneRea = eui_cmbCpStatoLiquidazioneREA.Text
         AAzienda.TiSeIdPaese = eui_cmbTiSeIdPaese.Text
         AAzienda.TiSePartitaIva = eui_txtTiSeIdCodice.Text
         AAzienda.TiSeCodiceFiscale = eui_txtTiSeCodiceFiscale.Text
         AAzienda.TiSeDenominazione = eui_txtTiSeDenominazione.Text
         AAzienda.TiSeNome = eui_txtTiSeNome.Text
         AAzienda.TiSeCognome = eui_txtTiSeCognome.Text
         AAzienda.TiSeTitolo = eui_txtTiSeTitolo.Text
         AAzienda.TiSeCodiceEORI = eui_txtTiSeCodiceEORI.Text
         AAzienda.SoggettoEmittente = eui_cmbSoggettoEmittente.Text

         AAzienda.ModificaDati(NOME_TABELLA, AAzienda.Codice)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Elimina()
      Try
         ' Svuota tutte le caselle di testo da eventuali valori.
         txtRagSoc.Text = String.Empty
         txtPIva.Text = String.Empty
         txtCodiceFiscale.Text = String.Empty
         txtIndirizzo.Text = String.Empty
         txtCap.Text = String.Empty
         txtCittà.Text = String.Empty
         txtProvincia.Text = String.Empty
         cmbNazione.Text = String.Empty
         cmbRegimeFiscale.Text = String.Empty
         txtTel.Text = String.Empty
         txtFax.Text = String.Empty
         txtMail.Text = String.Empty
         txtPec.Text = String.Empty
         txtInternet.Text = String.Empty
         cmbPagamento.Text = String.Empty
         txtBanca.Text = String.Empty
         txtCIN.Text = String.Empty
         txtABI.Text = String.Empty
         txtCAB.Text = String.Empty
         txtCC.Text = String.Empty
         txtIBAN.Text = String.Empty

         ' Fatturazione Elettronica.
         eui_cmbCpUfficioREA.Text = String.Empty
         eui_txtCpNumeroREA.Text = String.Empty
         eui_cmbCpStatoLiquidazioneREA.Text = String.Empty
         eui_cmbTiSeIdPaese.Text = String.Empty
         eui_txtTiSeIdCodice.Text = String.Empty
         eui_txtTiSeCodiceFiscale.Text = String.Empty
         eui_txtTiSeDenominazione.Text = String.Empty
         eui_txtTiSeNome.Text = String.Empty
         eui_txtTiSeCognome.Text = String.Empty
         eui_txtTiSeTitolo.Text = String.Empty
         eui_txtTiSeCodiceEORI.Text = String.Empty
         eui_cmbSoggettoEmittente.Text = String.Empty

         EliminaImmagine()

         ' Salva i dati modificati ed esce dal form.
         Salva()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      ' Imposta le dimensioni standard del form.
      Me.Width = larghezza
      Me.Height = altezza
   End Sub

   Private Sub InserisciImmagine()
      Try
         OpenFileDialog1.Filter = "Tutti i formati |*.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" &
                                  "Bmp (Bitmap di Windows)|*.Bmp|" &
                                  "Gif |*.Gif|" &
                                  "Jpeg/Jpg |*.Jpg; *.Jpeg |" &
                                  "Png |*.Png|" &
                                  "Tga |*.Tga|" &
                                  "Tiff |*.Tiff|" &
                                  "Wmf (Metafile di Windows) |*.Wmf"

         OpenFileDialog1.FilterIndex = 1

         If OpenFileDialog1.ShowDialog() = DialogResult.OK Then

            AAzienda.PercorsoImg = OpenFileDialog1.FileName
            ' Salva l'immagine in un campo BLOB del database.
            AAzienda.Immagine = CreaStream(OpenFileDialog1.FileName)

            If File.Exists(OpenFileDialog1.FileName) = True Then
               Dim bmp As New Bitmap(OpenFileDialog1.FileName)
               picFoto.Image = bmp
               bmp = Nothing
            End If

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub EliminaImmagine()
      Try
         If Not (picFoto.Image Is Nothing) Then
            picFoto.Image.Dispose()
            picFoto.Image = Nothing
            AAzienda.Immagine = CreaStream(Application.StartupPath & PERCORSO_IMG_LOGO)
            AAzienda.PercorsoImg = Application.StartupPath & PERCORSO_IMG_LOGO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ImpostaFunzioniOperatore(ByVal wnd As String)
      Try
         Select Case wnd
            Case Finestra.DatiAzienda
               If operatore.AnagDatiAzienda = VALORE_LETTURA Then
                  tbrElimina.Enabled = False
                  TabPage1.Enabled = False
                  TabPage2.Enabled = False
                  TabPage3.Enabled = False
               Else
                  tbrElimina.Enabled = True
                  TabPage1.Enabled = True
                  TabPage2.Enabled = True
                  TabPage3.Enabled = True
               End If
         End Select


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub frmAzienda_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = True

   End Sub

   Private Sub frmAzienda_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
      Dim tempFile As String = Application.StartupPath & "\temp.bmp"

      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)


         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         ' Imposta le dimensioni del form.
         FormResize(FORM_LARGHEZZA, FORM_ALTEZZA)

         ' Visualizza i dati nei rispettivi campi.
         AAzienda.LeggiDati(NOME_TABELLA)

         ' Assegna i dati dei campi della classe alle caselle di testo.
         txtRagSoc.Text = AAzienda.RagSociale
         txtPIva.Text = AAzienda.Piva
         txtCodiceFiscale.Text = AAzienda.CodFisc
         txtIndirizzo.Text = AAzienda.Indirizzo
         txtCap.Text = AAzienda.Cap
         txtCittà.Text = AAzienda.Città
         txtProvincia.Text = AAzienda.Provincia
         cmbNazione.Text = AAzienda.Nazione
         cmbRegimeFiscale.Text = AAzienda.RegimeFiscale
         txtTel.Text = AAzienda.Telefono
         txtFax.Text = AAzienda.Fax
         txtMail.Text = AAzienda.Email
         txtPec.Text = AAzienda.PEC
         txtInternet.Text = AAzienda.Internet
         cmbPagamento.Text = AAzienda.TipoPagamento
         txtBanca.Text = AAzienda.Banca
         txtABI.Text = AAzienda.Abi
         txtCAB.Text = AAzienda.Cab
         txtCC.Text = AAzienda.Cc
         txtCIN.Text = AAzienda.Cin
         txtIBAN.Text = AAzienda.Iban

         ' Fatturazione Elettronica.
         eui_cmbCpUfficioREA.Text = AAzienda.UfficioRea
         eui_txtCpNumeroREA.Text = AAzienda.NumeroRea
         eui_cmbCpStatoLiquidazioneREA.Text = AAzienda.StatoLiquidazioneRea
         eui_cmbTiSeIdPaese.Text = AAzienda.TiSeIdPaese
         eui_txtTiSeIdCodice.Text = AAzienda.TiSePartitaIva
         eui_txtTiSeCodiceFiscale.Text = AAzienda.TiSeCodiceFiscale
         eui_txtTiSeDenominazione.Text = AAzienda.TiSeDenominazione
         eui_txtTiSeNome.Text = AAzienda.TiSeNome
         eui_txtTiSeCognome.Text = AAzienda.TiSeCognome
         eui_txtTiSeTitolo.Text = AAzienda.TiSeTitolo
         eui_txtTiSeCodiceEORI.Text = AAzienda.TiSeCodiceEORI
         eui_cmbSoggettoEmittente.Text = AAzienda.SoggettoEmittente

         If AAzienda.PercorsoImg <> Nothing Then
            If File.Exists(AAzienda.PercorsoImg) = True Then
               Dim bmp As New Bitmap(AAzienda.PercorsoImg)
               picFoto.Image = bmp
            End If
         End If

         ' Carica la lista del campo Nazioni.
         CaricaLista(cmbNazione, TAB_NAZIONI)
         CaricaLista(cmbPagamento, TAB_PAGAMENTO)

         ' Visualizza la ragione sociale nell'intestazione.
         lblIntestazione.Text = txtRagSoc.Text.ToUpper

         ' Attiva/disattiva i comandi in base ai permessi dell'operatore.
         ImpostaFunzioniOperatore(Finestra.DatiAzienda)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_ANAGRAFICA_DATI_AZIENDA, MODULO_ANAGRAFICA_DATI_AZIENDA)

         ' Imposta lo stato attivo.
         txtRagSoc.Focus()

      Catch ex As OutOfMemoryException
         picFoto.Image = Image.FromFile(tempFile)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmAzienda_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Closed
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         ' Salva i dati modificati ed esce dal form.
         Salva()

         ' Visualizza il nome dell'azienda sulla barra di stato.
         g_frmMain.eui_cmdAzienda.Text = AAzienda.RagSociale

         Dim descrizione As String = "(" & AAzienda.RagSociale & ")"

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Salva, descrizione, MODULO_ANAGRAFICA_DATI_AZIENDA)

         ' Effetto scomparsa verso il basso.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmAzienda)

         ' Distrugge gli oggetti e libera le risorse.
         g_frmAzienda.Dispose()
         g_frmAzienda = Nothing
         AAzienda = Nothing

         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         g_frmMain.rtgGestionaleAmica.Visible = False

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_ANAGRAFICA_DATI_AZIENDA, MODULO_ANAGRAFICA_DATI_AZIENDA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Salva"
            ' Salva i data e chiude il form.
            Me.Close()

         Case "Elimina"
            Dim descrizione As String = "(" & AAzienda.RagSociale & ")"

            ' Svuota tutti i campi e salva i dati.
            Elimina()

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, descrizione, MODULO_ANAGRAFICA_DATI_AZIENDA)
      End Select
   End Sub

   Private Sub txtRagSoc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Visualizza la ragione sociale nell'intestazione del form.
      lblIntestazione.Text = txtRagSoc.Text.ToUpper
   End Sub

   Protected Overrides Sub Finalize()
      MyBase.Finalize()
   End Sub

   Private Sub ApriImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ApriImg.Click
      InserisciImmagine()
   End Sub

   Private Sub EliminaImg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EliminaImg.Click
      ApriImg.NotifyDefault(False)
      EliminaImmagine()
   End Sub

   Private Sub txtPIva_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtCap_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtTel_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtFax_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
      Try
         Select Case TabControl1.SelectedIndex()
            Case 0
               ' Imposta lo stato attivo.
               txtRagSoc.Focus()

            Case 1
               ' Imposta lo stato attivo.
               txtTel.Focus()

            Case 2
               ' Imposta lo stato attivo.
               cmbPagamento.Focus()

            Case 3
               ' Imposta lo stato attivo.
               eui_cmbCpUfficioREA.Focus()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
      'If (txtCC.Text.Length > 12) Then
      '   'Lunghezza errata
      '   Exit Sub
      'Else
      '   Dim IBAN As New CalcolaIBAN
      '   IBAN.Abi = txtABI.Text
      '   IBAN.Cab = txtCAB.Text
      '   IBAN.ContoCorrente = txtCC.Text
      '   IBAN.Paese = "IT"

      '   txtCIN.Text = IBAN.CalcolaCin()
      '   txtIBAN.Text = IBAN.CalcolaIBAN()
      '   'Dim sCheck As String = String.Empty
      '   'sCheck = IBAN.CalcolaCheckIBAN(paese, IBAN.CalcolaBBAN())

      'End If
   End Sub

End Class