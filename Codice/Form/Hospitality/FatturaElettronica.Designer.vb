<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFatturaElettronica
   Inherits System.Windows.Forms.Form

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   <System.Diagnostics.DebuggerNonUserCode()> _
   Protected Overrides Sub Dispose(ByVal disposing As Boolean)
      Try
         If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
         End If
      Finally
         MyBase.Dispose(disposing)
      End Try
   End Sub

   'Richiesto da Progettazione Windows Form
   Private components As System.ComponentModel.IContainer

   'NOTA: la procedura che segue è richiesta da Progettazione Windows Form
   'Può essere modificata in Progettazione Windows Form.  
   'Non modificarla mediante l'editor del codice.
   <System.Diagnostics.DebuggerStepThrough()> _
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFatturaElettronica))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.StatusBar1 = New Elegant.Ui.StatusBar()
      Me.StatusBarNotificationsArea1 = New Elegant.Ui.StatusBarNotificationsArea()
      Me.StatusBarPane2 = New Elegant.Ui.StatusBarPane()
      Me.Label3 = New Elegant.Ui.Label()
      Me.lnkAgenziaEntrate = New System.Windows.Forms.LinkLabel()
      Me.lnkFatturaPA = New System.Windows.Forms.LinkLabel()
      Me.lnkIndicePA = New System.Windows.Forms.LinkLabel()
      Me.StatusBarPane4 = New Elegant.Ui.StatusBarPane()
      Me.eui_lblDirectoryFileXml = New Elegant.Ui.Label()
      Me.StatusBarControlsArea1 = New Elegant.Ui.StatusBarControlsArea()
      Me.StatusBarPane3 = New Elegant.Ui.StatusBarPane()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_tpcDocumento = New Elegant.Ui.TabControl()
      Me.TabPage1 = New Elegant.Ui.TabPage()
      Me.TabControl1 = New Elegant.Ui.TabControl()
      Me.TabPage6 = New Elegant.Ui.TabPage()
      Me.TabControl2 = New Elegant.Ui.TabControl()
      Me.TabPage11 = New Elegant.Ui.TabPage()
      Me.eui_cmbCpRegimeFiscale = New Elegant.Ui.ComboBox()
      Me.Label24 = New Elegant.Ui.Label()
      Me.GroupBox5 = New Elegant.Ui.GroupBox()
      Me.eui_dtpCpDataIscrizioneAlbo = New Elegant.Ui.DateTimePicker()
      Me.eui_cmbCpProvinciaAlbo = New Elegant.Ui.ComboBox()
      Me.Label20 = New Elegant.Ui.Label()
      Me.Label21 = New Elegant.Ui.Label()
      Me.eui_txtCpNumeroIscrizioneAlbo = New Elegant.Ui.TextBox()
      Me.eui_txtCpAlboProfessionale = New Elegant.Ui.TextBox()
      Me.Label22 = New Elegant.Ui.Label()
      Me.Label23 = New Elegant.Ui.Label()
      Me.GroupBox4 = New Elegant.Ui.GroupBox()
      Me.Label18 = New Elegant.Ui.Label()
      Me.Label17 = New Elegant.Ui.Label()
      Me.Label16 = New Elegant.Ui.Label()
      Me.eui_txtCpCodiceEORI = New Elegant.Ui.TextBox()
      Me.eui_txtCpTitolo = New Elegant.Ui.TextBox()
      Me.eui_txtCpCognome = New Elegant.Ui.TextBox()
      Me.eui_txtCpDenominazione = New Elegant.Ui.TextBox()
      Me.eui_txtCpNome = New Elegant.Ui.TextBox()
      Me.Label14 = New Elegant.Ui.Label()
      Me.Label15 = New Elegant.Ui.Label()
      Me.eui_txtCpCodiceFiscale = New Elegant.Ui.TextBox()
      Me.Label13 = New Elegant.Ui.Label()
      Me.GroupBox3 = New Elegant.Ui.GroupBox()
      Me.eui_txtCpIdCodice = New Elegant.Ui.TextBox()
      Me.Label11 = New Elegant.Ui.Label()
      Me.eui_cmbCpIdPaese = New Elegant.Ui.ComboBox()
      Me.Label12 = New Elegant.Ui.Label()
      Me.TabPage12 = New Elegant.Ui.TabPage()
      Me.GroupBox6 = New Elegant.Ui.GroupBox()
      Me.eui_cmbCpSedeNazione = New Elegant.Ui.ComboBox()
      Me.Label29 = New Elegant.Ui.Label()
      Me.eui_cmbCpSedeProvincia = New Elegant.Ui.ComboBox()
      Me.Label19 = New Elegant.Ui.Label()
      Me.Label25 = New Elegant.Ui.Label()
      Me.Label26 = New Elegant.Ui.Label()
      Me.eui_txtCpSedeComune = New Elegant.Ui.TextBox()
      Me.eui_txtCpSedeCAP = New Elegant.Ui.TextBox()
      Me.eui_txtCpSedeIndirizzo = New Elegant.Ui.TextBox()
      Me.eui_txtCpSedeNumeroCivico = New Elegant.Ui.TextBox()
      Me.Label27 = New Elegant.Ui.Label()
      Me.Label28 = New Elegant.Ui.Label()
      Me.TabPage13 = New Elegant.Ui.TabPage()
      Me.GroupBox7 = New Elegant.Ui.GroupBox()
      Me.eui_cmbCpStabileOrgNazione = New Elegant.Ui.ComboBox()
      Me.Label30 = New Elegant.Ui.Label()
      Me.eui_cmbCpStabileOrgProvincia = New Elegant.Ui.ComboBox()
      Me.Label31 = New Elegant.Ui.Label()
      Me.Label32 = New Elegant.Ui.Label()
      Me.Label33 = New Elegant.Ui.Label()
      Me.eui_txtCpStabileOrgComune = New Elegant.Ui.TextBox()
      Me.eui_txtCpStabileOrgCAP = New Elegant.Ui.TextBox()
      Me.eui_txtCpStabileOrgIndirizzo = New Elegant.Ui.TextBox()
      Me.eui_txtCpStabileOrgNumeroCivico = New Elegant.Ui.TextBox()
      Me.Label34 = New Elegant.Ui.Label()
      Me.Label35 = New Elegant.Ui.Label()
      Me.TabPage14 = New Elegant.Ui.TabPage()
      Me.GroupBox8 = New Elegant.Ui.GroupBox()
      Me.eui_cmbCpSocioUnicoREA = New Elegant.Ui.ComboBox()
      Me.eui_cmbCpUfficioREA = New Elegant.Ui.ComboBox()
      Me.eui_cmbCpStatoLiquidazioneREA = New Elegant.Ui.ComboBox()
      Me.Label37 = New Elegant.Ui.Label()
      Me.Label38 = New Elegant.Ui.Label()
      Me.Label39 = New Elegant.Ui.Label()
      Me.eui_txtCpCapitaleSocialeREA = New Elegant.Ui.TextBox()
      Me.eui_txtCpNumeroREA = New Elegant.Ui.TextBox()
      Me.Label40 = New Elegant.Ui.Label()
      Me.Label41 = New Elegant.Ui.Label()
      Me.TabPage15 = New Elegant.Ui.TabPage()
      Me.GroupBox9 = New Elegant.Ui.GroupBox()
      Me.Label36 = New Elegant.Ui.Label()
      Me.eui_txtCpEmail = New Elegant.Ui.TextBox()
      Me.eui_txtCpTelefono = New Elegant.Ui.TextBox()
      Me.eui_txtCpFax = New Elegant.Ui.TextBox()
      Me.Label42 = New Elegant.Ui.Label()
      Me.Label43 = New Elegant.Ui.Label()
      Me.TabPage16 = New Elegant.Ui.TabPage()
      Me.eui_txtCpRifAmministrazione = New Elegant.Ui.TextBox()
      Me.Label44 = New Elegant.Ui.Label()
      Me.TabPage5 = New Elegant.Ui.TabPage()
      Me.GroupBox2 = New Elegant.Ui.GroupBox()
      Me.Label10 = New Elegant.Ui.Label()
      Me.eui_txtTrasmittentePECDestinatario = New Elegant.Ui.TextBox()
      Me.eui_txtTrasmittenteTelefono = New Elegant.Ui.TextBox()
      Me.eui_txtTrasmittenteEmail = New Elegant.Ui.TextBox()
      Me.Label8 = New Elegant.Ui.Label()
      Me.Label9 = New Elegant.Ui.Label()
      Me.eui_txtProgressivoInvio = New Elegant.Ui.TextBox()
      Me.Label7 = New Elegant.Ui.Label()
      Me.eui_txtCodiceDestinatario = New Elegant.Ui.TextBox()
      Me.Label5 = New Elegant.Ui.Label()
      Me.eui_cmbFormatoTrasmissione = New Elegant.Ui.ComboBox()
      Me.Label6 = New Elegant.Ui.Label()
      Me.GroupBox1 = New Elegant.Ui.GroupBox()
      Me.eui_txtTrasmittenteIdCodice = New Elegant.Ui.TextBox()
      Me.Label4 = New Elegant.Ui.Label()
      Me.eui_cmbTrasmittenteIdPaese = New Elegant.Ui.ComboBox()
      Me.Label1 = New Elegant.Ui.Label()
      Me.TabPage7 = New Elegant.Ui.TabPage()
      Me.Label52 = New Elegant.Ui.Label()
      Me.GroupBox10 = New Elegant.Ui.GroupBox()
      Me.Label45 = New Elegant.Ui.Label()
      Me.Label46 = New Elegant.Ui.Label()
      Me.Label47 = New Elegant.Ui.Label()
      Me.eui_txtRfCpCodiceEORI = New Elegant.Ui.TextBox()
      Me.eui_txtRfCpTitolo = New Elegant.Ui.TextBox()
      Me.eui_txtRfCpCognome = New Elegant.Ui.TextBox()
      Me.eui_txtRfCpDenominazione = New Elegant.Ui.TextBox()
      Me.eui_txtRfCpNome = New Elegant.Ui.TextBox()
      Me.Label48 = New Elegant.Ui.Label()
      Me.Label49 = New Elegant.Ui.Label()
      Me.eui_txtRfCpCodiceFiscale = New Elegant.Ui.TextBox()
      Me.GroupBox11 = New Elegant.Ui.GroupBox()
      Me.eui_txtRfCpIdCodice = New Elegant.Ui.TextBox()
      Me.Label50 = New Elegant.Ui.Label()
      Me.eui_cmbRfCpIdPaese = New Elegant.Ui.ComboBox()
      Me.Label51 = New Elegant.Ui.Label()
      Me.TabPage8 = New Elegant.Ui.TabPage()
      Me.TabControl3 = New Elegant.Ui.TabControl()
      Me.TabPage17 = New Elegant.Ui.TabPage()
      Me.GroupBox12 = New Elegant.Ui.GroupBox()
      Me.Label53 = New Elegant.Ui.Label()
      Me.Label54 = New Elegant.Ui.Label()
      Me.Label55 = New Elegant.Ui.Label()
      Me.eui_txtCcCodiceEORI = New Elegant.Ui.TextBox()
      Me.eui_txtCcTitolo = New Elegant.Ui.TextBox()
      Me.eui_txtCcCognome = New Elegant.Ui.TextBox()
      Me.eui_txtCcDenominazione = New Elegant.Ui.TextBox()
      Me.eui_txtCcNome = New Elegant.Ui.TextBox()
      Me.Label56 = New Elegant.Ui.Label()
      Me.Label57 = New Elegant.Ui.Label()
      Me.eui_txtCcCodiceFiscale = New Elegant.Ui.TextBox()
      Me.Label58 = New Elegant.Ui.Label()
      Me.GroupBox13 = New Elegant.Ui.GroupBox()
      Me.eui_txtCcIdCodice = New Elegant.Ui.TextBox()
      Me.Label59 = New Elegant.Ui.Label()
      Me.eui_cmbCcIdPaese = New Elegant.Ui.ComboBox()
      Me.Label60 = New Elegant.Ui.Label()
      Me.TabPage18 = New Elegant.Ui.TabPage()
      Me.GroupBox14 = New Elegant.Ui.GroupBox()
      Me.eui_cmbCcSedeNazione = New Elegant.Ui.ComboBox()
      Me.Label61 = New Elegant.Ui.Label()
      Me.eui_cmbCcSedeProvincia = New Elegant.Ui.ComboBox()
      Me.Label62 = New Elegant.Ui.Label()
      Me.Label63 = New Elegant.Ui.Label()
      Me.Label64 = New Elegant.Ui.Label()
      Me.eui_txtCcSedeComune = New Elegant.Ui.TextBox()
      Me.eui_txtCcSedeCAP = New Elegant.Ui.TextBox()
      Me.eui_txtCcSedeIndirizzo = New Elegant.Ui.TextBox()
      Me.eui_txtCcSedeNumeroCivico = New Elegant.Ui.TextBox()
      Me.Label65 = New Elegant.Ui.Label()
      Me.Label66 = New Elegant.Ui.Label()
      Me.TabPage19 = New Elegant.Ui.TabPage()
      Me.GroupBox17 = New Elegant.Ui.GroupBox()
      Me.eui_cmbCcStabileOrgNazione = New Elegant.Ui.ComboBox()
      Me.Label76 = New Elegant.Ui.Label()
      Me.eui_cmbCcStabileOrgProvincia = New Elegant.Ui.ComboBox()
      Me.Label77 = New Elegant.Ui.Label()
      Me.Label78 = New Elegant.Ui.Label()
      Me.Label79 = New Elegant.Ui.Label()
      Me.eui_txtCcStabileOrgComune = New Elegant.Ui.TextBox()
      Me.eui_txtCcStabileOrgCAP = New Elegant.Ui.TextBox()
      Me.eui_txtCcStabileOrgIndirizzo = New Elegant.Ui.TextBox()
      Me.eui_txtCcStabileOrgNumeroCivico = New Elegant.Ui.TextBox()
      Me.Label80 = New Elegant.Ui.Label()
      Me.Label81 = New Elegant.Ui.Label()
      Me.TabPage20 = New Elegant.Ui.TabPage()
      Me.GroupBox18 = New Elegant.Ui.GroupBox()
      Me.Label85 = New Elegant.Ui.Label()
      Me.eui_txtCcRfCognome = New Elegant.Ui.TextBox()
      Me.eui_txtCcRfDenominazione = New Elegant.Ui.TextBox()
      Me.eui_txtCcRfNome = New Elegant.Ui.TextBox()
      Me.Label86 = New Elegant.Ui.Label()
      Me.Label87 = New Elegant.Ui.Label()
      Me.GroupBox19 = New Elegant.Ui.GroupBox()
      Me.eui_txtCcRfIdCodice = New Elegant.Ui.TextBox()
      Me.Label88 = New Elegant.Ui.Label()
      Me.eui_cmbCcRfIdPaese = New Elegant.Ui.ComboBox()
      Me.Label89 = New Elegant.Ui.Label()
      Me.TabPage9 = New Elegant.Ui.TabPage()
      Me.GroupBox15 = New Elegant.Ui.GroupBox()
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
      Me.eui_txtTiSeCodiceFiscale = New Elegant.Ui.TextBox()
      Me.Label72 = New Elegant.Ui.Label()
      Me.GroupBox16 = New Elegant.Ui.GroupBox()
      Me.eui_txtTiSeIdCodice = New Elegant.Ui.TextBox()
      Me.Label73 = New Elegant.Ui.Label()
      Me.eui_cmbTiSeIdPaese = New Elegant.Ui.ComboBox()
      Me.Label74 = New Elegant.Ui.Label()
      Me.TabPage10 = New Elegant.Ui.TabPage()
      Me.eui_cmbSoggettoEmittente = New Elegant.Ui.ComboBox()
      Me.Label75 = New Elegant.Ui.Label()
      Me.eui_tpConvalida = New Elegant.Ui.TabPage()
      Me.eui_cmdConvalidaWeb = New Elegant.Ui.Button()
      Me.eui_cmdSalvaErrori = New Elegant.Ui.Button()
      Me.eui_cmdConvalida = New Elegant.Ui.Button()
      Me.eui_txtConvalida = New Elegant.Ui.TextBox()
      Me.TabPage3 = New Elegant.Ui.TabPage()
      Me.eui_cmdCopiaPercorso = New Elegant.Ui.Button()
      Me.TabPage21 = New Elegant.Ui.TabPage()
      Me.eui_txtFormatoTxt = New Elegant.Ui.TextBox()
      Me.eui_cmdApriFileTxt = New Elegant.Ui.Button()
      Me.TabPage4 = New Elegant.Ui.TabPage()
      Me.eui_cmdAnteprimaWeb = New Elegant.Ui.Button()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.eui_cmdApriCartella = New Elegant.Ui.Button()
      Me.eui_cmdEsporta = New Elegant.Ui.Button()
      Me.eui_cmdInvia = New Elegant.Ui.Button()
      Me.StatusBarPane5 = New Elegant.Ui.StatusBarPane()
      Me.eui_lblStatoDataDoc = New Elegant.Ui.Label()
      Me.StatusBarPane1 = New Elegant.Ui.StatusBarPane()
      Me.eui_lblStatoClienteDoc = New Elegant.Ui.Label()
      Me.eui_cmdSalva = New Elegant.Ui.Button()
      Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
      Me.StatusBar1.SuspendLayout()
      Me.StatusBarNotificationsArea1.SuspendLayout()
      Me.StatusBarPane2.SuspendLayout()
      Me.StatusBarPane4.SuspendLayout()
      Me.StatusBarControlsArea1.SuspendLayout()
      CType(Me.eui_tpcDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage1.SuspendLayout()
      CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage6.SuspendLayout()
      CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage11.SuspendLayout()
      Me.GroupBox5.SuspendLayout()
      Me.GroupBox4.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.TabPage12.SuspendLayout()
      Me.GroupBox6.SuspendLayout()
      Me.TabPage13.SuspendLayout()
      Me.GroupBox7.SuspendLayout()
      Me.TabPage14.SuspendLayout()
      Me.GroupBox8.SuspendLayout()
      Me.TabPage15.SuspendLayout()
      Me.GroupBox9.SuspendLayout()
      Me.TabPage16.SuspendLayout()
      Me.TabPage5.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.TabPage7.SuspendLayout()
      Me.GroupBox10.SuspendLayout()
      Me.GroupBox11.SuspendLayout()
      Me.TabPage8.SuspendLayout()
      CType(Me.TabControl3, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage17.SuspendLayout()
      Me.GroupBox12.SuspendLayout()
      Me.GroupBox13.SuspendLayout()
      Me.TabPage18.SuspendLayout()
      Me.GroupBox14.SuspendLayout()
      Me.TabPage19.SuspendLayout()
      Me.GroupBox17.SuspendLayout()
      Me.TabPage20.SuspendLayout()
      Me.GroupBox18.SuspendLayout()
      Me.GroupBox19.SuspendLayout()
      Me.TabPage9.SuspendLayout()
      Me.GroupBox15.SuspendLayout()
      Me.GroupBox16.SuspendLayout()
      Me.TabPage10.SuspendLayout()
      Me.eui_tpConvalida.SuspendLayout()
      Me.TabPage3.SuspendLayout()
      Me.TabPage21.SuspendLayout()
      Me.TabPage4.SuspendLayout()
      Me.StatusBarPane5.SuspendLayout()
      Me.StatusBarPane1.SuspendLayout()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'StatusBar1
      '
      Me.StatusBar1.Controls.Add(Me.StatusBarNotificationsArea1)
      Me.StatusBar1.Controls.Add(Me.StatusBarControlsArea1)
      Me.StatusBar1.ControlsArea = Me.StatusBarControlsArea1
      Me.StatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.StatusBar1.Location = New System.Drawing.Point(0, 512)
      Me.StatusBar1.Name = "StatusBar1"
      Me.StatusBar1.NotificationsArea = Me.StatusBarNotificationsArea1
      Me.StatusBar1.Size = New System.Drawing.Size(974, 22)
      Me.StatusBar1.TabIndex = 4
      Me.StatusBar1.Text = "StatusBar1"
      '
      'StatusBarNotificationsArea1
      '
      Me.StatusBarNotificationsArea1.Controls.Add(Me.StatusBarPane2)
      Me.StatusBarNotificationsArea1.Controls.Add(Me.StatusBarPane4)
      Me.StatusBarNotificationsArea1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarNotificationsArea1.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarNotificationsArea1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarNotificationsArea1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarNotificationsArea1.Name = "StatusBarNotificationsArea1"
      Me.StatusBarNotificationsArea1.Size = New System.Drawing.Size(902, 22)
      Me.StatusBarNotificationsArea1.TabIndex = 1
      '
      'StatusBarPane2
      '
      Me.StatusBarPane2.Controls.Add(Me.Label3)
      Me.StatusBarPane2.Controls.Add(Me.lnkAgenziaEntrate)
      Me.StatusBarPane2.Controls.Add(Me.lnkFatturaPA)
      Me.StatusBarPane2.Controls.Add(Me.lnkIndicePA)
      Me.StatusBarPane2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarPane2.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarPane2.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane2.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane2.Name = "StatusBarPane2"
      Me.StatusBarPane2.ScreenTip.Text = "Numero documento"
      Me.StatusBarPane2.Size = New System.Drawing.Size(513, 22)
      Me.StatusBarPane2.TabIndex = 0
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(5, 5)
      Me.Label3.Name = "Label3"
      Me.Label3.ScreenTip.Text = "Cliente intestatario"
      Me.Label3.Size = New System.Drawing.Size(114, 13)
      Me.Label3.TabIndex = 26
      Me.Label3.Text = "Per info e servizi gratuiti:"
      '
      'lnkAgenziaEntrate
      '
      Me.lnkAgenziaEntrate.ActiveLinkColor = System.Drawing.Color.White
      Me.lnkAgenziaEntrate.AutoSize = True
      Me.lnkAgenziaEntrate.BackColor = System.Drawing.Color.Transparent
      Me.lnkAgenziaEntrate.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.lnkAgenziaEntrate.Location = New System.Drawing.Point(125, 5)
      Me.lnkAgenziaEntrate.Name = "lnkAgenziaEntrate"
      Me.lnkAgenziaEntrate.Size = New System.Drawing.Size(133, 13)
      Me.lnkAgenziaEntrate.TabIndex = 27
      Me.lnkAgenziaEntrate.TabStop = True
      Me.lnkAgenziaEntrate.Text = "www.agenziaentrate.gov.it"
      Me.lnkAgenziaEntrate.VisitedLinkColor = System.Drawing.Color.Magenta
      '
      'lnkFatturaPA
      '
      Me.lnkFatturaPA.ActiveLinkColor = System.Drawing.Color.White
      Me.lnkFatturaPA.AutoSize = True
      Me.lnkFatturaPA.BackColor = System.Drawing.Color.Transparent
      Me.lnkFatturaPA.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.lnkFatturaPA.Location = New System.Drawing.Point(264, 5)
      Me.lnkFatturaPA.Name = "lnkFatturaPA"
      Me.lnkFatturaPA.Size = New System.Drawing.Size(105, 13)
      Me.lnkFatturaPA.TabIndex = 28
      Me.lnkFatturaPA.TabStop = True
      Me.lnkFatturaPA.Text = "www.fatturapa.gov.it"
      Me.lnkFatturaPA.VisitedLinkColor = System.Drawing.Color.Magenta
      '
      'lnkIndicePA
      '
      Me.lnkIndicePA.ActiveLinkColor = System.Drawing.Color.White
      Me.lnkIndicePA.AutoSize = True
      Me.lnkIndicePA.BackColor = System.Drawing.Color.Transparent
      Me.lnkIndicePA.LinkColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.lnkIndicePA.Location = New System.Drawing.Point(375, 5)
      Me.lnkIndicePA.Name = "lnkIndicePA"
      Me.lnkIndicePA.Size = New System.Drawing.Size(103, 13)
      Me.lnkIndicePA.TabIndex = 29
      Me.lnkIndicePA.TabStop = True
      Me.lnkIndicePA.Text = "www.indicepa.gov.it"
      Me.lnkIndicePA.VisitedLinkColor = System.Drawing.Color.Magenta
      '
      'StatusBarPane4
      '
      Me.StatusBarPane4.Controls.Add(Me.eui_lblDirectoryFileXml)
      Me.StatusBarPane4.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarPane4.Location = New System.Drawing.Point(513, 0)
      Me.StatusBarPane4.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane4.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane4.Name = "StatusBarPane4"
      Me.StatusBarPane4.Size = New System.Drawing.Size(116, 22)
      Me.StatusBarPane4.TabIndex = 2
      '
      'eui_lblDirectoryFileXml
      '
      Me.eui_lblDirectoryFileXml.Location = New System.Drawing.Point(5, 5)
      Me.eui_lblDirectoryFileXml.Name = "eui_lblDirectoryFileXml"
      Me.eui_lblDirectoryFileXml.ScreenTip.Text = "Numero documento"
      Me.eui_lblDirectoryFileXml.Size = New System.Drawing.Size(76, 13)
      Me.eui_lblDirectoryFileXml.TabIndex = 29
      Me.eui_lblDirectoryFileXml.Text = "Percorso file.xml"
      '
      'StatusBarControlsArea1
      '
      Me.StatusBarControlsArea1.Controls.Add(Me.StatusBarPane3)
      Me.StatusBarControlsArea1.Dock = System.Windows.Forms.DockStyle.Right
      Me.StatusBarControlsArea1.Location = New System.Drawing.Point(902, 0)
      Me.StatusBarControlsArea1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarControlsArea1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarControlsArea1.Name = "StatusBarControlsArea1"
      Me.StatusBarControlsArea1.Size = New System.Drawing.Size(72, 22)
      Me.StatusBarControlsArea1.TabIndex = 0
      '
      'StatusBarPane3
      '
      Me.StatusBarPane3.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarPane3.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane3.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane3.Name = "StatusBarPane3"
      Me.StatusBarPane3.Size = New System.Drawing.Size(20, 22)
      Me.StatusBarPane3.TabIndex = 0
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdTastiera.Id = "295ab16e-e7c5-4477-a8b5-fc8631e2896a"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(832, 434)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 5
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "73a9f32c-e7b8-41a5-b071-7351d12b4ba9"
      Me.eui_cmdAnnulla.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(832, 360)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.ScreenTip.Caption = "Esci"
      Me.eui_cmdAnnulla.ScreenTip.Text = "Annula le modifiche e chiude la finestra."
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdAnnulla.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdAnnulla.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdAnnulla.TabIndex = 4
      Me.eui_cmdAnnulla.Text = "Esci"
      Me.eui_cmdAnnulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_tpcDocumento
      '
      Me.eui_tpcDocumento.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_tpcDocumento.EndScrollButtonVisible = True
      Me.eui_tpcDocumento.EqualTabHeight = True
      Me.eui_tpcDocumento.EqualTabWidth = True
      Me.eui_tpcDocumento.Location = New System.Drawing.Point(9, 9)
      Me.eui_tpcDocumento.Name = "eui_tpcDocumento"
      Me.eui_tpcDocumento.SelectedTabPage = Me.TabPage1
      Me.eui_tpcDocumento.Size = New System.Drawing.Size(814, 490)
      Me.eui_tpcDocumento.TabIndex = 15
      Me.eui_tpcDocumento.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.TabPage1, Me.eui_tpConvalida, Me.TabPage3, Me.TabPage21, Me.TabPage4})
      Me.eui_tpcDocumento.Text = " "
      '
      'TabPage1
      '
      Me.TabPage1.ActiveControl = Nothing
      Me.TabPage1.Controls.Add(Me.TabControl1)
      Me.TabPage1.KeyTip = Nothing
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(812, 469)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Intestazione"
      '
      'TabControl1
      '
      Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TabControl1.Location = New System.Drawing.Point(6, 4)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedTabPage = Me.TabPage5
      Me.TabControl1.Size = New System.Drawing.Size(800, 459)
      Me.TabControl1.TabIndex = 19
      Me.TabControl1.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.TabPage5, Me.TabPage6, Me.TabPage7, Me.TabPage8, Me.TabPage9, Me.TabPage10})
      Me.TabControl1.Text = "TabControl1"
      '
      'TabPage6
      '
      Me.TabPage6.ActiveControl = Nothing
      Me.TabPage6.Controls.Add(Me.TabControl2)
      Me.TabPage6.KeyTip = Nothing
      Me.TabPage6.Name = "TabPage6"
      Me.TabPage6.Size = New System.Drawing.Size(798, 438)
      Me.TabPage6.TabIndex = 1
      Me.TabPage6.Text = "Cedente/Prestatore"
      '
      'TabControl2
      '
      Me.TabControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TabControl2.Location = New System.Drawing.Point(8, 6)
      Me.TabControl2.Name = "TabControl2"
      Me.TabControl2.SelectedTabPage = Me.TabPage11
      Me.TabControl2.Size = New System.Drawing.Size(782, 423)
      Me.TabControl2.TabIndex = 0
      Me.TabControl2.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.TabPage11, Me.TabPage12, Me.TabPage13, Me.TabPage14, Me.TabPage15, Me.TabPage16})
      Me.TabControl2.Text = "TabControl2"
      '
      'TabPage11
      '
      Me.TabPage11.ActiveControl = Nothing
      Me.TabPage11.Controls.Add(Me.eui_cmbCpRegimeFiscale)
      Me.TabPage11.Controls.Add(Me.Label24)
      Me.TabPage11.Controls.Add(Me.GroupBox5)
      Me.TabPage11.Controls.Add(Me.GroupBox4)
      Me.TabPage11.Controls.Add(Me.eui_txtCpCodiceFiscale)
      Me.TabPage11.Controls.Add(Me.Label13)
      Me.TabPage11.Controls.Add(Me.GroupBox3)
      Me.TabPage11.KeyTip = Nothing
      Me.TabPage11.Name = "TabPage11"
      Me.TabPage11.Size = New System.Drawing.Size(780, 402)
      Me.TabPage11.TabIndex = 0
      Me.TabPage11.Text = " Dati Anagrafici"
      '
      'eui_cmbCpRegimeFiscale
      '
      Me.eui_cmbCpRegimeFiscale.Editable = False
      Me.eui_cmbCpRegimeFiscale.FormattingEnabled = False
      Me.eui_cmbCpRegimeFiscale.Id = "9342aff2-e8f4-4f2b-a986-c4be3711957b"
      Me.eui_cmbCpRegimeFiscale.Items.AddRange(New Object() {" ", "RF01 Ordinario", "RF02 Contribuenti minimi (art. 1, c.96-117, L. 244/2007)", "RF04 Agricoltura e attività connesse e pesca (artt. 34 e 34-bis, D.P.R. 633/1972)" &
                "", "RF05 Vendita sali e tabacchi (art. 74, c.1, D.P.R. 633/1972)", "RF06 Commercio dei fiammiferi (art. 74, c.1, D.P.R. 633/1972)", "RF07 Editoria (art. 74, c.1, D.P.R. 633/1972)", "RF08 Gestione di servizi di telefonia pubblica (art. 74, c.1, D.P.R. 633/1972)", "RF09 Rivendita di documenti di trasporto pubblico e di sosta (art. 74, c.1, D.P.R" &
                ". 633/1972)", "RF10 Intrattenimenti, giochi e altre attività di cui alla tariffa allegata al D.P" &
                ".R. n. 640/72 (art. 74, c.6, D.P.R. 633/1972)", "RF11 Agenzie di viaggi e turismo (art. 74-ter, D.P.R. 633/1972)", "RF12 Agriturismo (art. 5, c.2, L. 413/1991)", "RF13 Vendite a domicilio (art. 25-bis, c.6, D.P.R. 600/1973)", "RF14 Rivendita di beni usati, di oggetti d’arte, d’antiquariato o da collezione (" &
                "art. 36, D.L. 41/1995)", "RF15 Agenzie di vendite all’asta di oggetti d’arte, antiquariato o da collezione " &
                "(art. 40-bis, D.L. 41/1995)", "RF16 IVA per cassa P.A. (art. 6, c.5, D.P.R. 633/1972)", "RF17 IVA per cassa (art. 32-bis, D.L. 83/2012)", "RF18 Altro", "RF19 Forfettario (art.1, c. 54-89, L. 190/2014)"})
      Me.eui_cmbCpRegimeFiscale.Location = New System.Drawing.Point(430, 215)
      Me.eui_cmbCpRegimeFiscale.Name = "eui_cmbCpRegimeFiscale"
      Me.eui_cmbCpRegimeFiscale.Size = New System.Drawing.Size(324, 21)
      Me.eui_cmbCpRegimeFiscale.TabIndex = 1
      Me.eui_cmbCpRegimeFiscale.TextEditorWidth = 305
      '
      'Label24
      '
      Me.Label24.Location = New System.Drawing.Point(430, 196)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(131, 19)
      Me.Label24.TabIndex = 8
      Me.Label24.Text = "Regime fiscale:"
      '
      'GroupBox5
      '
      Me.GroupBox5.Controls.Add(Me.eui_dtpCpDataIscrizioneAlbo)
      Me.GroupBox5.Controls.Add(Me.eui_cmbCpProvinciaAlbo)
      Me.GroupBox5.Controls.Add(Me.Label20)
      Me.GroupBox5.Controls.Add(Me.Label21)
      Me.GroupBox5.Controls.Add(Me.eui_txtCpNumeroIscrizioneAlbo)
      Me.GroupBox5.Controls.Add(Me.eui_txtCpAlboProfessionale)
      Me.GroupBox5.Controls.Add(Me.Label22)
      Me.GroupBox5.Controls.Add(Me.Label23)
      Me.GroupBox5.Id = "c2526491-f91e-4474-9225-0cf464988599"
      Me.GroupBox5.Location = New System.Drawing.Point(411, 8)
      Me.GroupBox5.Name = "GroupBox5"
      Me.GroupBox5.Size = New System.Drawing.Size(360, 172)
      Me.GroupBox5.TabIndex = 7
      Me.GroupBox5.Text = "Albo"
      '
      'eui_dtpCpDataIscrizioneAlbo
      '
      Me.eui_dtpCpDataIscrizioneAlbo.Format = Elegant.Ui.DateTimePickerFormat.ShortDate
      Me.eui_dtpCpDataIscrizioneAlbo.Id = "83a0578a-32be-427b-87f2-7d344431693f"
      Me.eui_dtpCpDataIscrizioneAlbo.Location = New System.Drawing.Point(142, 128)
      Me.eui_dtpCpDataIscrizioneAlbo.Name = "eui_dtpCpDataIscrizioneAlbo"
      Me.eui_dtpCpDataIscrizioneAlbo.Size = New System.Drawing.Size(106, 21)
      Me.eui_dtpCpDataIscrizioneAlbo.TabIndex = 3
      Me.eui_dtpCpDataIscrizioneAlbo.TextEditorWidth = 87
      '
      'eui_cmbCpProvinciaAlbo
      '
      Me.eui_cmbCpProvinciaAlbo.Editable = False
      Me.eui_cmbCpProvinciaAlbo.FormattingEnabled = False
      Me.eui_cmbCpProvinciaAlbo.Id = "a1ab4333-0dd0-49e0-85a3-1308f3f36a36"
      Me.eui_cmbCpProvinciaAlbo.Items.AddRange(New Object() {" ", "AG Agrigento", "AL Alessandria", "AN Ancona", "AO Aosta", "AR Arezzo", "AP Ascoli Piceno", "AT Asti", "AV Avellino", "BA Bari", "BT Barletta-Andria-Trani", "BL Belluno", "BN Benevento", "BG Bergamo", "BI Biella", "BO Bologna", "BZ Bolzano", "BS Brescia", "BR Brindisi", "CA Cagliari", "CL Caltanissetta", "CB Campobasso", "CI Carbonia-Iglesias", "CE Caserta", "CT Catania", "CZ Catanzaro", "CH Chieti", "CO Como", "CS Cosenza", "CR Cremona", "KR Crotone", "CN Cuneo", "EN Enna", "FM Fermo", "FE Ferrara", "FI Firenze", "FU Fiume", "FG Foggia", "FC Forlì-Cesena", "FR Frosinone", "GE Genova", "GO Gorizia", "GR Grosseto", "IM Imperia", "IS Isernia", "AQ L'Aquila", "SP La Spezia", "LT Latina", "LE Lecce", "LC Lecco", "LI Livorno", "LO Lodi", "LB Lubiana", "LU Lucca", "MC Macerata", "MN Mantova", "MS Massa-Carrara", "MT Matera", "VS Medio Campidano", "ME Messina", "MI Milano", "MO Modena", "MB Monza e Brianza", "NA Napoli", "NO Novara", "NU Nuoro", "OG Ogliastra", "OT Olbia-Tempio", "OR Oristano", "PD Padova", "PA Palermo", "PR Parma", "PV Pavia", "PG Perugia", "PU Pesaro e Urbino ", "PE Pescara", "PC Piacenza", "PI Pisa", "PT Pistoia", "PL Pola", "PN Pordenone", "PZ Potenza", "PO Prato", "RG Ragusa", "RA Ravenna", "RC Reggio di Calabria", "RE Reggio nell'Emilia", "RI Rieti", "RN Rimini", "RM Roma", "RO Rovigo", "SA Salerno", "SS Sassari", "SV Savona", "SI Siena", "SR Siracusa", "SO Sondrio", "SU Sud Sardegna", "TA Taranto", "TE Teramo", "TR Terni", "TO Torino", "TP Trapani", "TN Trento", "TV Treviso", "TS Trieste", "UD Udine", "VA Varese", "VE Venezia", "VB Verbano-Cusio-Ossola", "VC Vercelli", "VR Verona", "VV Vibo Valentia", "VI Vicenza", "VT Viterbo", "ZA Zara"})
      Me.eui_cmbCpProvinciaAlbo.Location = New System.Drawing.Point(143, 57)
      Me.eui_cmbCpProvinciaAlbo.Name = "eui_cmbCpProvinciaAlbo"
      Me.eui_cmbCpProvinciaAlbo.Size = New System.Drawing.Size(200, 21)
      Me.eui_cmbCpProvinciaAlbo.TabIndex = 1
      Me.eui_cmbCpProvinciaAlbo.TextEditorWidth = 181
      '
      'Label20
      '
      Me.Label20.Location = New System.Drawing.Point(19, 130)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(95, 19)
      Me.Label20.TabIndex = 9
      Me.Label20.Text = "Data iscrizione albo:"
      '
      'Label21
      '
      Me.Label21.Location = New System.Drawing.Point(19, 94)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(109, 19)
      Me.Label21.TabIndex = 8
      Me.Label21.Text = "Numero iscrizione albo:"
      '
      'eui_txtCpNumeroIscrizioneAlbo
      '
      Me.eui_txtCpNumeroIscrizioneAlbo.Id = "1314dd2f-993e-45b9-b743-3b8b79bbe252"
      Me.eui_txtCpNumeroIscrizioneAlbo.Location = New System.Drawing.Point(142, 92)
      Me.eui_txtCpNumeroIscrizioneAlbo.MaxLength = 60
      Me.eui_txtCpNumeroIscrizioneAlbo.Name = "eui_txtCpNumeroIscrizioneAlbo"
      Me.eui_txtCpNumeroIscrizioneAlbo.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpNumeroIscrizioneAlbo.TabIndex = 2
      Me.eui_txtCpNumeroIscrizioneAlbo.TextEditorWidth = 195
      '
      'eui_txtCpAlboProfessionale
      '
      Me.eui_txtCpAlboProfessionale.Id = "5bdf2776-452d-4e6e-93a1-7bed6b6ca55a"
      Me.eui_txtCpAlboProfessionale.Location = New System.Drawing.Point(142, 23)
      Me.eui_txtCpAlboProfessionale.MaxLength = 60
      Me.eui_txtCpAlboProfessionale.Name = "eui_txtCpAlboProfessionale"
      Me.eui_txtCpAlboProfessionale.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpAlboProfessionale.TabIndex = 0
      Me.eui_txtCpAlboProfessionale.TextEditorWidth = 195
      '
      'Label22
      '
      Me.Label22.Location = New System.Drawing.Point(19, 57)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(76, 19)
      Me.Label22.TabIndex = 2
      Me.Label22.Text = "Provincia albo:"
      '
      'Label23
      '
      Me.Label23.Location = New System.Drawing.Point(19, 25)
      Me.Label23.Name = "Label23"
      Me.Label23.Size = New System.Drawing.Size(89, 19)
      Me.Label23.TabIndex = 0
      Me.Label23.Text = "Albo professionale:"
      '
      'GroupBox4
      '
      Me.GroupBox4.Controls.Add(Me.Label18)
      Me.GroupBox4.Controls.Add(Me.Label17)
      Me.GroupBox4.Controls.Add(Me.Label16)
      Me.GroupBox4.Controls.Add(Me.eui_txtCpCodiceEORI)
      Me.GroupBox4.Controls.Add(Me.eui_txtCpTitolo)
      Me.GroupBox4.Controls.Add(Me.eui_txtCpCognome)
      Me.GroupBox4.Controls.Add(Me.eui_txtCpDenominazione)
      Me.GroupBox4.Controls.Add(Me.eui_txtCpNome)
      Me.GroupBox4.Controls.Add(Me.Label14)
      Me.GroupBox4.Controls.Add(Me.Label15)
      Me.GroupBox4.Id = "a3ba7ca2-9f14-4741-bc9f-02e9b1800ef5"
      Me.GroupBox4.Location = New System.Drawing.Point(12, 158)
      Me.GroupBox4.Name = "GroupBox4"
      Me.GroupBox4.Size = New System.Drawing.Size(381, 203)
      Me.GroupBox4.TabIndex = 6
      Me.GroupBox4.Text = "Anagrafica"
      '
      'Label18
      '
      Me.Label18.Location = New System.Drawing.Point(19, 165)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(78, 19)
      Me.Label18.TabIndex = 10
      Me.Label18.Text = "Codice EORI:"
      '
      'Label17
      '
      Me.Label17.Location = New System.Drawing.Point(19, 130)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(78, 19)
      Me.Label17.TabIndex = 9
      Me.Label17.Text = "Titolo:"
      '
      'Label16
      '
      Me.Label16.Location = New System.Drawing.Point(19, 94)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(78, 19)
      Me.Label16.TabIndex = 8
      Me.Label16.Text = "Cognome:"
      '
      'eui_txtCpCodiceEORI
      '
      Me.eui_txtCpCodiceEORI.Id = "f30783d7-f4c0-4c22-bfaa-59b5e0484855"
      Me.eui_txtCpCodiceEORI.Location = New System.Drawing.Point(114, 163)
      Me.eui_txtCpCodiceEORI.MaxLength = 17
      Me.eui_txtCpCodiceEORI.Name = "eui_txtCpCodiceEORI"
      Me.eui_txtCpCodiceEORI.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpCodiceEORI.TabIndex = 4
      Me.eui_txtCpCodiceEORI.TextEditorWidth = 195
      '
      'eui_txtCpTitolo
      '
      Me.eui_txtCpTitolo.Id = "b15edcf2-e5ad-4da3-bada-4a46cb18445b"
      Me.eui_txtCpTitolo.Location = New System.Drawing.Point(114, 128)
      Me.eui_txtCpTitolo.MaxLength = 10
      Me.eui_txtCpTitolo.Name = "eui_txtCpTitolo"
      Me.eui_txtCpTitolo.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpTitolo.TabIndex = 3
      Me.eui_txtCpTitolo.TextEditorWidth = 195
      '
      'eui_txtCpCognome
      '
      Me.eui_txtCpCognome.Id = "79a70f8c-f5d3-4e42-95fa-0887c7a22805"
      Me.eui_txtCpCognome.Location = New System.Drawing.Point(113, 92)
      Me.eui_txtCpCognome.MaxLength = 60
      Me.eui_txtCpCognome.Name = "eui_txtCpCognome"
      Me.eui_txtCpCognome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpCognome.TabIndex = 2
      Me.eui_txtCpCognome.TextEditorWidth = 195
      '
      'eui_txtCpDenominazione
      '
      Me.eui_txtCpDenominazione.Id = "1b832f09-f4b7-4bb4-afa8-42b36a5e1787"
      Me.eui_txtCpDenominazione.Location = New System.Drawing.Point(113, 23)
      Me.eui_txtCpDenominazione.MaxLength = 80
      Me.eui_txtCpDenominazione.Name = "eui_txtCpDenominazione"
      Me.eui_txtCpDenominazione.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpDenominazione.TabIndex = 0
      Me.eui_txtCpDenominazione.TextEditorWidth = 195
      '
      'eui_txtCpNome
      '
      Me.eui_txtCpNome.Id = "c5631033-fb51-42c6-9418-1974d814756a"
      Me.eui_txtCpNome.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCpNome.MaxLength = 60
      Me.eui_txtCpNome.Name = "eui_txtCpNome"
      Me.eui_txtCpNome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpNome.TabIndex = 1
      Me.eui_txtCpNome.TextEditorWidth = 195
      '
      'Label14
      '
      Me.Label14.Location = New System.Drawing.Point(19, 57)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(131, 19)
      Me.Label14.TabIndex = 2
      Me.Label14.Text = "Nome:"
      '
      'Label15
      '
      Me.Label15.Location = New System.Drawing.Point(19, 25)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(76, 19)
      Me.Label15.TabIndex = 0
      Me.Label15.Text = "Denominazione:"
      '
      'eui_txtCpCodiceFiscale
      '
      Me.eui_txtCpCodiceFiscale.Id = "0c0553b3-d9bb-4a60-94ed-76c83114ddc8"
      Me.eui_txtCpCodiceFiscale.Location = New System.Drawing.Point(126, 123)
      Me.eui_txtCpCodiceFiscale.MaxLength = 16
      Me.eui_txtCpCodiceFiscale.Name = "eui_txtCpCodiceFiscale"
      Me.eui_txtCpCodiceFiscale.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpCodiceFiscale.TabIndex = 0
      Me.eui_txtCpCodiceFiscale.TextEditorWidth = 195
      '
      'Label13
      '
      Me.Label13.Location = New System.Drawing.Point(28, 125)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(87, 19)
      Me.Label13.TabIndex = 4
      Me.Label13.Text = "Codice fiscale:"
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.eui_txtCpIdCodice)
      Me.GroupBox3.Controls.Add(Me.Label11)
      Me.GroupBox3.Controls.Add(Me.eui_cmbCpIdPaese)
      Me.GroupBox3.Controls.Add(Me.Label12)
      Me.GroupBox3.Id = "72e0c655-5d6a-41d8-9da0-4fe9f8fdc013"
      Me.GroupBox3.Location = New System.Drawing.Point(12, 8)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(381, 100)
      Me.GroupBox3.TabIndex = 1
      Me.GroupBox3.Text = "Id Fiscale IVA"
      '
      'eui_txtCpIdCodice
      '
      Me.eui_txtCpIdCodice.Id = "4d09c094-ff83-4bff-a658-8574d1049432"
      Me.eui_txtCpIdCodice.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCpIdCodice.MaxLength = 28
      Me.eui_txtCpIdCodice.Name = "eui_txtCpIdCodice"
      Me.eui_txtCpIdCodice.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpIdCodice.TabIndex = 1
      Me.eui_txtCpIdCodice.TextEditorWidth = 195
      '
      'Label11
      '
      Me.Label11.Location = New System.Drawing.Point(19, 57)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(131, 19)
      Me.Label11.TabIndex = 2
      Me.Label11.Text = "Partita IVA:"
      '
      'eui_cmbCpIdPaese
      '
      Me.eui_cmbCpIdPaese.Editable = False
      Me.eui_cmbCpIdPaese.FormattingEnabled = False
      Me.eui_cmbCpIdPaese.Id = "6e13984f-7dea-482a-bb55-a76fe4962fec"
      Me.eui_cmbCpIdPaese.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbCpIdPaese.Location = New System.Drawing.Point(113, 23)
      Me.eui_cmbCpIdPaese.Name = "eui_cmbCpIdPaese"
      Me.eui_cmbCpIdPaese.Size = New System.Drawing.Size(202, 21)
      Me.eui_cmbCpIdPaese.TabIndex = 0
      Me.eui_cmbCpIdPaese.TextEditorWidth = 183
      '
      'Label12
      '
      Me.Label12.Location = New System.Drawing.Point(19, 25)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(50, 19)
      Me.Label12.TabIndex = 0
      Me.Label12.Text = "Paese:"
      '
      'TabPage12
      '
      Me.TabPage12.ActiveControl = Nothing
      Me.TabPage12.Controls.Add(Me.GroupBox6)
      Me.TabPage12.KeyTip = Nothing
      Me.TabPage12.Name = "TabPage12"
      Me.TabPage12.Size = New System.Drawing.Size(780, 398)
      Me.TabPage12.TabIndex = 1
      Me.TabPage12.Text = "Sede"
      '
      'GroupBox6
      '
      Me.GroupBox6.Controls.Add(Me.eui_cmbCpSedeNazione)
      Me.GroupBox6.Controls.Add(Me.Label29)
      Me.GroupBox6.Controls.Add(Me.eui_cmbCpSedeProvincia)
      Me.GroupBox6.Controls.Add(Me.Label19)
      Me.GroupBox6.Controls.Add(Me.Label25)
      Me.GroupBox6.Controls.Add(Me.Label26)
      Me.GroupBox6.Controls.Add(Me.eui_txtCpSedeComune)
      Me.GroupBox6.Controls.Add(Me.eui_txtCpSedeCAP)
      Me.GroupBox6.Controls.Add(Me.eui_txtCpSedeIndirizzo)
      Me.GroupBox6.Controls.Add(Me.eui_txtCpSedeNumeroCivico)
      Me.GroupBox6.Controls.Add(Me.Label27)
      Me.GroupBox6.Controls.Add(Me.Label28)
      Me.GroupBox6.Id = "f492f647-05b9-43df-99d4-1ed3c009846d"
      Me.GroupBox6.Location = New System.Drawing.Point(9, 8)
      Me.GroupBox6.Name = "GroupBox6"
      Me.GroupBox6.Size = New System.Drawing.Size(381, 230)
      Me.GroupBox6.TabIndex = 7
      Me.GroupBox6.Text = "Sede del cedente/prestatore"
      '
      'eui_cmbCpSedeNazione
      '
      Me.eui_cmbCpSedeNazione.Editable = False
      Me.eui_cmbCpSedeNazione.FormattingEnabled = False
      Me.eui_cmbCpSedeNazione.Id = "f807600f-cbfe-45c6-8807-70f0f1488a87"
      Me.eui_cmbCpSedeNazione.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbCpSedeNazione.Location = New System.Drawing.Point(113, 194)
      Me.eui_cmbCpSedeNazione.Name = "eui_cmbCpSedeNazione"
      Me.eui_cmbCpSedeNazione.Size = New System.Drawing.Size(240, 21)
      Me.eui_cmbCpSedeNazione.TabIndex = 5
      Me.eui_cmbCpSedeNazione.TextEditorWidth = 221
      '
      'Label29
      '
      Me.Label29.Location = New System.Drawing.Point(19, 196)
      Me.Label29.Name = "Label29"
      Me.Label29.Size = New System.Drawing.Size(78, 19)
      Me.Label29.TabIndex = 12
      Me.Label29.Text = "Nazione:"
      '
      'eui_cmbCpSedeProvincia
      '
      Me.eui_cmbCpSedeProvincia.Editable = False
      Me.eui_cmbCpSedeProvincia.FormattingEnabled = False
      Me.eui_cmbCpSedeProvincia.Id = "b4a56a8e-95fb-4bed-b2c7-349f96750d72"
      Me.eui_cmbCpSedeProvincia.Items.AddRange(New Object() {" ", "AG Agrigento", "AL Alessandria", "AN Ancona", "AO Aosta", "AR Arezzo", "AP Ascoli Piceno", "AT Asti", "AV Avellino", "BA Bari", "BT Barletta-Andria-Trani", "BL Belluno", "BN Benevento", "BG Bergamo", "BI Biella", "BO Bologna", "BZ Bolzano", "BS Brescia", "BR Brindisi", "CA Cagliari", "CL Caltanissetta", "CB Campobasso", "CI Carbonia-Iglesias", "CE Caserta", "CT Catania", "CZ Catanzaro", "CH Chieti", "CO Como", "CS Cosenza", "CR Cremona", "KR Crotone", "CN Cuneo", "EN Enna", "FM Fermo", "FE Ferrara", "FI Firenze", "FU Fiume", "FG Foggia", "FC Forlì-Cesena", "FR Frosinone", "GE Genova", "GO Gorizia", "GR Grosseto", "IM Imperia", "IS Isernia", "AQ L'Aquila", "SP La Spezia", "LT Latina", "LE Lecce", "LC Lecco", "LI Livorno", "LO Lodi", "LB Lubiana", "LU Lucca", "MC Macerata", "MN Mantova", "MS Massa-Carrara", "MT Matera", "VS Medio Campidano", "ME Messina", "MI Milano", "MO Modena", "MB Monza e Brianza", "NA Napoli", "NO Novara", "NU Nuoro", "OG Ogliastra", "OT Olbia-Tempio", "OR Oristano", "PD Padova", "PA Palermo", "PR Parma", "PV Pavia", "PG Perugia", "PU Pesaro e Urbino ", "PE Pescara", "PC Piacenza", "PI Pisa", "PT Pistoia", "PL Pola", "PN Pordenone", "PZ Potenza", "PO Prato", "RG Ragusa", "RA Ravenna", "RC Reggio di Calabria", "RE Reggio nell'Emilia", "RI Rieti", "RN Rimini", "RM Roma", "RO Rovigo", "SA Salerno", "SS Sassari", "SV Savona", "SI Siena", "SR Siracusa", "SO Sondrio", "SU Sud Sardegna", "TA Taranto", "TE Teramo", "TR Terni", "TO Torino", "TP Trapani", "TN Trento", "TV Treviso", "TS Trieste", "UD Udine", "VA Varese", "VE Venezia", "VB Verbano-Cusio-Ossola", "VC Vercelli", "VR Verona", "VV Vibo Valentia", "VI Vicenza", "VT Viterbo", "ZA Zara"})
      Me.eui_cmbCpSedeProvincia.Location = New System.Drawing.Point(113, 163)
      Me.eui_cmbCpSedeProvincia.Name = "eui_cmbCpSedeProvincia"
      Me.eui_cmbCpSedeProvincia.Size = New System.Drawing.Size(240, 21)
      Me.eui_cmbCpSedeProvincia.TabIndex = 4
      Me.eui_cmbCpSedeProvincia.TextEditorWidth = 221
      '
      'Label19
      '
      Me.Label19.Location = New System.Drawing.Point(19, 165)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(78, 19)
      Me.Label19.TabIndex = 10
      Me.Label19.Text = "Provincia:"
      '
      'Label25
      '
      Me.Label25.Location = New System.Drawing.Point(19, 130)
      Me.Label25.Name = "Label25"
      Me.Label25.Size = New System.Drawing.Size(78, 19)
      Me.Label25.TabIndex = 9
      Me.Label25.Text = "Comune:"
      '
      'Label26
      '
      Me.Label26.Location = New System.Drawing.Point(19, 94)
      Me.Label26.Name = "Label26"
      Me.Label26.Size = New System.Drawing.Size(78, 19)
      Me.Label26.TabIndex = 8
      Me.Label26.Tag = ""
      Me.Label26.Text = "CAP:"
      '
      'eui_txtCpSedeComune
      '
      Me.eui_txtCpSedeComune.Id = "8fa64d04-8b9c-4f84-bd97-2d59fb600624"
      Me.eui_txtCpSedeComune.Location = New System.Drawing.Point(114, 128)
      Me.eui_txtCpSedeComune.MaxLength = 60
      Me.eui_txtCpSedeComune.Name = "eui_txtCpSedeComune"
      Me.eui_txtCpSedeComune.Size = New System.Drawing.Size(239, 21)
      Me.eui_txtCpSedeComune.TabIndex = 3
      Me.eui_txtCpSedeComune.TextEditorWidth = 233
      '
      'eui_txtCpSedeCAP
      '
      Me.eui_txtCpSedeCAP.Id = "f82496b2-1452-45fc-837b-412b1706e4f5"
      Me.eui_txtCpSedeCAP.Location = New System.Drawing.Point(113, 92)
      Me.eui_txtCpSedeCAP.MaxLength = 5
      Me.eui_txtCpSedeCAP.Name = "eui_txtCpSedeCAP"
      Me.eui_txtCpSedeCAP.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtCpSedeCAP.TabIndex = 2
      Me.eui_txtCpSedeCAP.TextEditorWidth = 107
      '
      'eui_txtCpSedeIndirizzo
      '
      Me.eui_txtCpSedeIndirizzo.Id = "d00b49d5-2bd2-424a-8316-1c2dcd428de3"
      Me.eui_txtCpSedeIndirizzo.Location = New System.Drawing.Point(113, 23)
      Me.eui_txtCpSedeIndirizzo.MaxLength = 60
      Me.eui_txtCpSedeIndirizzo.Name = "eui_txtCpSedeIndirizzo"
      Me.eui_txtCpSedeIndirizzo.Size = New System.Drawing.Size(240, 21)
      Me.eui_txtCpSedeIndirizzo.TabIndex = 0
      Me.eui_txtCpSedeIndirizzo.TextEditorWidth = 234
      '
      'eui_txtCpSedeNumeroCivico
      '
      Me.eui_txtCpSedeNumeroCivico.Id = "89aba865-dbbe-4dfb-8ac7-3e127f860ddb"
      Me.eui_txtCpSedeNumeroCivico.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCpSedeNumeroCivico.MaxLength = 8
      Me.eui_txtCpSedeNumeroCivico.Name = "eui_txtCpSedeNumeroCivico"
      Me.eui_txtCpSedeNumeroCivico.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtCpSedeNumeroCivico.TabIndex = 1
      Me.eui_txtCpSedeNumeroCivico.TextEditorWidth = 107
      '
      'Label27
      '
      Me.Label27.Location = New System.Drawing.Point(19, 57)
      Me.Label27.Name = "Label27"
      Me.Label27.Size = New System.Drawing.Size(76, 19)
      Me.Label27.TabIndex = 2
      Me.Label27.Text = "Numero civico:"
      '
      'Label28
      '
      Me.Label28.Location = New System.Drawing.Point(19, 25)
      Me.Label28.Name = "Label28"
      Me.Label28.Size = New System.Drawing.Size(76, 19)
      Me.Label28.TabIndex = 0
      Me.Label28.Text = "Indirizzo:"
      '
      'TabPage13
      '
      Me.TabPage13.ActiveControl = Nothing
      Me.TabPage13.Controls.Add(Me.GroupBox7)
      Me.TabPage13.KeyTip = Nothing
      Me.TabPage13.Name = "TabPage13"
      Me.TabPage13.Size = New System.Drawing.Size(780, 402)
      Me.TabPage13.TabIndex = 2
      Me.TabPage13.Text = "Stabile Organizzazione"
      '
      'GroupBox7
      '
      Me.GroupBox7.Controls.Add(Me.eui_cmbCpStabileOrgNazione)
      Me.GroupBox7.Controls.Add(Me.Label30)
      Me.GroupBox7.Controls.Add(Me.eui_cmbCpStabileOrgProvincia)
      Me.GroupBox7.Controls.Add(Me.Label31)
      Me.GroupBox7.Controls.Add(Me.Label32)
      Me.GroupBox7.Controls.Add(Me.Label33)
      Me.GroupBox7.Controls.Add(Me.eui_txtCpStabileOrgComune)
      Me.GroupBox7.Controls.Add(Me.eui_txtCpStabileOrgCAP)
      Me.GroupBox7.Controls.Add(Me.eui_txtCpStabileOrgIndirizzo)
      Me.GroupBox7.Controls.Add(Me.eui_txtCpStabileOrgNumeroCivico)
      Me.GroupBox7.Controls.Add(Me.Label34)
      Me.GroupBox7.Controls.Add(Me.Label35)
      Me.GroupBox7.Id = "40493241-1207-45aa-9588-1c9608ea3296"
      Me.GroupBox7.Location = New System.Drawing.Point(9, 8)
      Me.GroupBox7.Name = "GroupBox7"
      Me.GroupBox7.Size = New System.Drawing.Size(381, 230)
      Me.GroupBox7.TabIndex = 8
      Me.GroupBox7.Text = "Stabile Organizazzione del cedente/prestatore non residente"
      '
      'eui_cmbCpStabileOrgNazione
      '
      Me.eui_cmbCpStabileOrgNazione.Editable = False
      Me.eui_cmbCpStabileOrgNazione.FormattingEnabled = False
      Me.eui_cmbCpStabileOrgNazione.Id = "fd37e653-6590-4672-9737-458b24cb2cda"
      Me.eui_cmbCpStabileOrgNazione.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbCpStabileOrgNazione.Location = New System.Drawing.Point(113, 194)
      Me.eui_cmbCpStabileOrgNazione.Name = "eui_cmbCpStabileOrgNazione"
      Me.eui_cmbCpStabileOrgNazione.Size = New System.Drawing.Size(240, 21)
      Me.eui_cmbCpStabileOrgNazione.TabIndex = 5
      Me.eui_cmbCpStabileOrgNazione.TextEditorWidth = 221
      '
      'Label30
      '
      Me.Label30.Location = New System.Drawing.Point(19, 196)
      Me.Label30.Name = "Label30"
      Me.Label30.Size = New System.Drawing.Size(78, 19)
      Me.Label30.TabIndex = 12
      Me.Label30.Text = "Nazione:"
      '
      'eui_cmbCpStabileOrgProvincia
      '
      Me.eui_cmbCpStabileOrgProvincia.Editable = False
      Me.eui_cmbCpStabileOrgProvincia.FormattingEnabled = False
      Me.eui_cmbCpStabileOrgProvincia.Id = "6b6d5ef4-0a46-43ae-96fd-6f2cc108807e"
      Me.eui_cmbCpStabileOrgProvincia.Items.AddRange(New Object() {" ", "AG Agrigento", "AL Alessandria", "AN Ancona", "AO Aosta", "AR Arezzo", "AP Ascoli Piceno", "AT Asti", "AV Avellino", "BA Bari", "BT Barletta-Andria-Trani", "BL Belluno", "BN Benevento", "BG Bergamo", "BI Biella", "BO Bologna", "BZ Bolzano", "BS Brescia", "BR Brindisi", "CA Cagliari", "CL Caltanissetta", "CB Campobasso", "CI Carbonia-Iglesias", "CE Caserta", "CT Catania", "CZ Catanzaro", "CH Chieti", "CO Como", "CS Cosenza", "CR Cremona", "KR Crotone", "CN Cuneo", "EN Enna", "FM Fermo", "FE Ferrara", "FI Firenze", "FU Fiume", "FG Foggia", "FC Forlì-Cesena", "FR Frosinone", "GE Genova", "GO Gorizia", "GR Grosseto", "IM Imperia", "IS Isernia", "AQ L'Aquila", "SP La Spezia", "LT Latina", "LE Lecce", "LC Lecco", "LI Livorno", "LO Lodi", "LB Lubiana", "LU Lucca", "MC Macerata", "MN Mantova", "MS Massa-Carrara", "MT Matera", "VS Medio Campidano", "ME Messina", "MI Milano", "MO Modena", "MB Monza e Brianza", "NA Napoli", "NO Novara", "NU Nuoro", "OG Ogliastra", "OT Olbia-Tempio", "OR Oristano", "PD Padova", "PA Palermo", "PR Parma", "PV Pavia", "PG Perugia", "PU Pesaro e Urbino ", "PE Pescara", "PC Piacenza", "PI Pisa", "PT Pistoia", "PL Pola", "PN Pordenone", "PZ Potenza", "PO Prato", "RG Ragusa", "RA Ravenna", "RC Reggio di Calabria", "RE Reggio nell'Emilia", "RI Rieti", "RN Rimini", "RM Roma", "RO Rovigo", "SA Salerno", "SS Sassari", "SV Savona", "SI Siena", "SR Siracusa", "SO Sondrio", "SU Sud Sardegna", "TA Taranto", "TE Teramo", "TR Terni", "TO Torino", "TP Trapani", "TN Trento", "TV Treviso", "TS Trieste", "UD Udine", "VA Varese", "VE Venezia", "VB Verbano-Cusio-Ossola", "VC Vercelli", "VR Verona", "VV Vibo Valentia", "VI Vicenza", "VT Viterbo", "ZA Zara"})
      Me.eui_cmbCpStabileOrgProvincia.Location = New System.Drawing.Point(113, 163)
      Me.eui_cmbCpStabileOrgProvincia.Name = "eui_cmbCpStabileOrgProvincia"
      Me.eui_cmbCpStabileOrgProvincia.Size = New System.Drawing.Size(240, 21)
      Me.eui_cmbCpStabileOrgProvincia.TabIndex = 4
      Me.eui_cmbCpStabileOrgProvincia.TextEditorWidth = 221
      '
      'Label31
      '
      Me.Label31.Location = New System.Drawing.Point(19, 165)
      Me.Label31.Name = "Label31"
      Me.Label31.Size = New System.Drawing.Size(78, 19)
      Me.Label31.TabIndex = 10
      Me.Label31.Text = "Provincia:"
      '
      'Label32
      '
      Me.Label32.Location = New System.Drawing.Point(19, 130)
      Me.Label32.Name = "Label32"
      Me.Label32.Size = New System.Drawing.Size(78, 19)
      Me.Label32.TabIndex = 9
      Me.Label32.Text = "Comune:"
      '
      'Label33
      '
      Me.Label33.Location = New System.Drawing.Point(19, 94)
      Me.Label33.Name = "Label33"
      Me.Label33.Size = New System.Drawing.Size(78, 19)
      Me.Label33.TabIndex = 8
      Me.Label33.Tag = ""
      Me.Label33.Text = "CAP:"
      '
      'eui_txtCpStabileOrgComune
      '
      Me.eui_txtCpStabileOrgComune.Id = "e998e743-c10c-4f5a-a627-d496df4a1475"
      Me.eui_txtCpStabileOrgComune.Location = New System.Drawing.Point(114, 128)
      Me.eui_txtCpStabileOrgComune.MaxLength = 60
      Me.eui_txtCpStabileOrgComune.Name = "eui_txtCpStabileOrgComune"
      Me.eui_txtCpStabileOrgComune.Size = New System.Drawing.Size(239, 21)
      Me.eui_txtCpStabileOrgComune.TabIndex = 3
      Me.eui_txtCpStabileOrgComune.TextEditorWidth = 233
      '
      'eui_txtCpStabileOrgCAP
      '
      Me.eui_txtCpStabileOrgCAP.Id = "4ffe664e-8e2b-415c-8809-2f480fc47a57"
      Me.eui_txtCpStabileOrgCAP.Location = New System.Drawing.Point(113, 92)
      Me.eui_txtCpStabileOrgCAP.MaxLength = 5
      Me.eui_txtCpStabileOrgCAP.Name = "eui_txtCpStabileOrgCAP"
      Me.eui_txtCpStabileOrgCAP.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtCpStabileOrgCAP.TabIndex = 2
      Me.eui_txtCpStabileOrgCAP.TextEditorWidth = 107
      '
      'eui_txtCpStabileOrgIndirizzo
      '
      Me.eui_txtCpStabileOrgIndirizzo.Id = "4c3af0e7-f352-4267-bf7b-183503b29cfd"
      Me.eui_txtCpStabileOrgIndirizzo.Location = New System.Drawing.Point(113, 23)
      Me.eui_txtCpStabileOrgIndirizzo.MaxLength = 60
      Me.eui_txtCpStabileOrgIndirizzo.Name = "eui_txtCpStabileOrgIndirizzo"
      Me.eui_txtCpStabileOrgIndirizzo.Size = New System.Drawing.Size(240, 21)
      Me.eui_txtCpStabileOrgIndirizzo.TabIndex = 0
      Me.eui_txtCpStabileOrgIndirizzo.TextEditorWidth = 234
      '
      'eui_txtCpStabileOrgNumeroCivico
      '
      Me.eui_txtCpStabileOrgNumeroCivico.Id = "79fc9f6f-0ce0-4679-a077-d01e0d282780"
      Me.eui_txtCpStabileOrgNumeroCivico.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCpStabileOrgNumeroCivico.MaxLength = 8
      Me.eui_txtCpStabileOrgNumeroCivico.Name = "eui_txtCpStabileOrgNumeroCivico"
      Me.eui_txtCpStabileOrgNumeroCivico.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtCpStabileOrgNumeroCivico.TabIndex = 1
      Me.eui_txtCpStabileOrgNumeroCivico.TextEditorWidth = 107
      '
      'Label34
      '
      Me.Label34.Location = New System.Drawing.Point(19, 57)
      Me.Label34.Name = "Label34"
      Me.Label34.Size = New System.Drawing.Size(76, 19)
      Me.Label34.TabIndex = 2
      Me.Label34.Text = "Numero civico:"
      '
      'Label35
      '
      Me.Label35.Location = New System.Drawing.Point(19, 25)
      Me.Label35.Name = "Label35"
      Me.Label35.Size = New System.Drawing.Size(76, 19)
      Me.Label35.TabIndex = 0
      Me.Label35.Text = "Indirizzo:"
      '
      'TabPage14
      '
      Me.TabPage14.ActiveControl = Nothing
      Me.TabPage14.Controls.Add(Me.GroupBox8)
      Me.TabPage14.KeyTip = Nothing
      Me.TabPage14.Name = "TabPage14"
      Me.TabPage14.Size = New System.Drawing.Size(780, 398)
      Me.TabPage14.TabIndex = 3
      Me.TabPage14.Text = "Iscrizione REA"
      '
      'GroupBox8
      '
      Me.GroupBox8.Controls.Add(Me.eui_cmbCpSocioUnicoREA)
      Me.GroupBox8.Controls.Add(Me.eui_cmbCpUfficioREA)
      Me.GroupBox8.Controls.Add(Me.eui_cmbCpStatoLiquidazioneREA)
      Me.GroupBox8.Controls.Add(Me.Label37)
      Me.GroupBox8.Controls.Add(Me.Label38)
      Me.GroupBox8.Controls.Add(Me.Label39)
      Me.GroupBox8.Controls.Add(Me.eui_txtCpCapitaleSocialeREA)
      Me.GroupBox8.Controls.Add(Me.eui_txtCpNumeroREA)
      Me.GroupBox8.Controls.Add(Me.Label40)
      Me.GroupBox8.Controls.Add(Me.Label41)
      Me.GroupBox8.Id = "110e466a-07da-4c33-8930-7cccf93194ef"
      Me.GroupBox8.Location = New System.Drawing.Point(11, 8)
      Me.GroupBox8.Name = "GroupBox8"
      Me.GroupBox8.Size = New System.Drawing.Size(381, 207)
      Me.GroupBox8.TabIndex = 9
      Me.GroupBox8.Text = "Iscrizione REA (società iscritte al registro imprese)"
      '
      'eui_cmbCpSocioUnicoREA
      '
      Me.eui_cmbCpSocioUnicoREA.Editable = False
      Me.eui_cmbCpSocioUnicoREA.FormattingEnabled = False
      Me.eui_cmbCpSocioUnicoREA.Id = "5af778c0-ad1b-41dc-bc15-ef4c9adccee3"
      Me.eui_cmbCpSocioUnicoREA.Items.AddRange(New Object() {"SU Socio unico", "SM Più soci"})
      Me.eui_cmbCpSocioUnicoREA.Location = New System.Drawing.Point(113, 128)
      Me.eui_cmbCpSocioUnicoREA.Name = "eui_cmbCpSocioUnicoREA"
      Me.eui_cmbCpSocioUnicoREA.Size = New System.Drawing.Size(153, 21)
      Me.eui_cmbCpSocioUnicoREA.TabIndex = 3
      Me.eui_cmbCpSocioUnicoREA.TextEditorWidth = 134
      '
      'eui_cmbCpUfficioREA
      '
      Me.eui_cmbCpUfficioREA.Editable = False
      Me.eui_cmbCpUfficioREA.FormattingEnabled = False
      Me.eui_cmbCpUfficioREA.Id = "74c2f6ad-fc73-4f8b-8a91-436c36504a2d"
      Me.eui_cmbCpUfficioREA.Items.AddRange(New Object() {" ", "AG Agrigento", "AL Alessandria", "AN Ancona", "AO Aosta", "AR Arezzo", "AP Ascoli Piceno", "AT Asti", "AV Avellino", "BA Bari", "BT Barletta-Andria-Trani", "BL Belluno", "BN Benevento", "BG Bergamo", "BI Biella", "BO Bologna", "BZ Bolzano", "BS Brescia", "BR Brindisi", "CA Cagliari", "CL Caltanissetta", "CB Campobasso", "CI Carbonia-Iglesias", "CE Caserta", "CT Catania", "CZ Catanzaro", "CH Chieti", "CO Como", "CS Cosenza", "CR Cremona", "KR Crotone", "CN Cuneo", "EN Enna", "FM Fermo", "FE Ferrara", "FI Firenze", "FU Fiume", "FG Foggia", "FC Forlì-Cesena", "FR Frosinone", "GE Genova", "GO Gorizia", "GR Grosseto", "IM Imperia", "IS Isernia", "AQ L'Aquila", "SP La Spezia", "LT Latina", "LE Lecce", "LC Lecco", "LI Livorno", "LO Lodi", "LB Lubiana", "LU Lucca", "MC Macerata", "MN Mantova", "MS Massa-Carrara", "MT Matera", "VS Medio Campidano", "ME Messina", "MI Milano", "MO Modena", "MB Monza e Brianza", "NA Napoli", "NO Novara", "NU Nuoro", "OG Ogliastra", "OT Olbia-Tempio", "OR Oristano", "PD Padova", "PA Palermo", "PR Parma", "PV Pavia", "PG Perugia", "PU Pesaro e Urbino ", "PE Pescara", "PC Piacenza", "PI Pisa", "PT Pistoia", "PL Pola", "PN Pordenone", "PZ Potenza", "PO Prato", "RG Ragusa", "RA Ravenna", "RC Reggio di Calabria", "RE Reggio nell'Emilia", "RI Rieti", "RN Rimini", "RM Roma", "RO Rovigo", "SA Salerno", "SS Sassari", "SV Savona", "SI Siena", "SR Siracusa", "SO Sondrio", "SU Sud Sardegna", "TA Taranto", "TE Teramo", "TR Terni", "TO Torino", "TP Trapani", "TN Trento", "TV Treviso", "TS Trieste", "UD Udine", "VA Varese", "VE Venezia", "VB Verbano-Cusio-Ossola", "VC Vercelli", "VR Verona", "VV Vibo Valentia", "VI Vicenza", "VT Viterbo", "ZA Zara"})
      Me.eui_cmbCpUfficioREA.Location = New System.Drawing.Point(113, 23)
      Me.eui_cmbCpUfficioREA.Name = "eui_cmbCpUfficioREA"
      Me.eui_cmbCpUfficioREA.Size = New System.Drawing.Size(238, 21)
      Me.eui_cmbCpUfficioREA.TabIndex = 0
      Me.eui_cmbCpUfficioREA.TextEditorWidth = 219
      '
      'eui_cmbCpStatoLiquidazioneREA
      '
      Me.eui_cmbCpStatoLiquidazioneREA.Editable = False
      Me.eui_cmbCpStatoLiquidazioneREA.FormattingEnabled = False
      Me.eui_cmbCpStatoLiquidazioneREA.Id = "8447bf74-488b-4b2f-a810-5a425fe4f849"
      Me.eui_cmbCpStatoLiquidazioneREA.Items.AddRange(New Object() {"LS In liquidazione", "LN Non in liquidazione"})
      Me.eui_cmbCpStatoLiquidazioneREA.Location = New System.Drawing.Point(113, 163)
      Me.eui_cmbCpStatoLiquidazioneREA.Name = "eui_cmbCpStatoLiquidazioneREA"
      Me.eui_cmbCpStatoLiquidazioneREA.Size = New System.Drawing.Size(153, 21)
      Me.eui_cmbCpStatoLiquidazioneREA.TabIndex = 4
      Me.eui_cmbCpStatoLiquidazioneREA.TextEditorWidth = 134
      '
      'Label37
      '
      Me.Label37.Location = New System.Drawing.Point(19, 165)
      Me.Label37.Name = "Label37"
      Me.Label37.Size = New System.Drawing.Size(86, 19)
      Me.Label37.TabIndex = 10
      Me.Label37.Text = "Stato liquidazione:"
      '
      'Label38
      '
      Me.Label38.Location = New System.Drawing.Point(19, 130)
      Me.Label38.Name = "Label38"
      Me.Label38.Size = New System.Drawing.Size(78, 19)
      Me.Label38.TabIndex = 9
      Me.Label38.Text = "Socio unico:"
      '
      'Label39
      '
      Me.Label39.Location = New System.Drawing.Point(19, 94)
      Me.Label39.Name = "Label39"
      Me.Label39.Size = New System.Drawing.Size(78, 19)
      Me.Label39.TabIndex = 8
      Me.Label39.Tag = ""
      Me.Label39.Text = "Capitale sociale:"
      '
      'eui_txtCpCapitaleSocialeREA
      '
      Me.eui_txtCpCapitaleSocialeREA.Id = "e067a8f5-f3af-40d2-96ff-e59b695f7f10"
      Me.eui_txtCpCapitaleSocialeREA.Location = New System.Drawing.Point(113, 92)
      Me.eui_txtCpCapitaleSocialeREA.MaxLength = 15
      Me.eui_txtCpCapitaleSocialeREA.Name = "eui_txtCpCapitaleSocialeREA"
      Me.eui_txtCpCapitaleSocialeREA.Size = New System.Drawing.Size(153, 21)
      Me.eui_txtCpCapitaleSocialeREA.TabIndex = 2
      Me.eui_txtCpCapitaleSocialeREA.TextEditorWidth = 147
      '
      'eui_txtCpNumeroREA
      '
      Me.eui_txtCpNumeroREA.Id = "6c25ed6c-ae43-40dd-b724-c958e9a55d82"
      Me.eui_txtCpNumeroREA.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCpNumeroREA.MaxLength = 20
      Me.eui_txtCpNumeroREA.Name = "eui_txtCpNumeroREA"
      Me.eui_txtCpNumeroREA.Size = New System.Drawing.Size(238, 21)
      Me.eui_txtCpNumeroREA.TabIndex = 1
      Me.eui_txtCpNumeroREA.TextEditorWidth = 232
      '
      'Label40
      '
      Me.Label40.Location = New System.Drawing.Point(19, 57)
      Me.Label40.Name = "Label40"
      Me.Label40.Size = New System.Drawing.Size(76, 19)
      Me.Label40.TabIndex = 2
      Me.Label40.Text = "Numero REA:"
      '
      'Label41
      '
      Me.Label41.Location = New System.Drawing.Point(19, 25)
      Me.Label41.Name = "Label41"
      Me.Label41.Size = New System.Drawing.Size(76, 19)
      Me.Label41.TabIndex = 0
      Me.Label41.Text = "Ufficio:"
      '
      'TabPage15
      '
      Me.TabPage15.ActiveControl = Nothing
      Me.TabPage15.Controls.Add(Me.GroupBox9)
      Me.TabPage15.KeyTip = Nothing
      Me.TabPage15.Name = "TabPage15"
      Me.TabPage15.Size = New System.Drawing.Size(780, 398)
      Me.TabPage15.TabIndex = 4
      Me.TabPage15.Text = "Contatti"
      '
      'GroupBox9
      '
      Me.GroupBox9.Controls.Add(Me.Label36)
      Me.GroupBox9.Controls.Add(Me.eui_txtCpEmail)
      Me.GroupBox9.Controls.Add(Me.eui_txtCpTelefono)
      Me.GroupBox9.Controls.Add(Me.eui_txtCpFax)
      Me.GroupBox9.Controls.Add(Me.Label42)
      Me.GroupBox9.Controls.Add(Me.Label43)
      Me.GroupBox9.Id = "3ca86c4c-fd42-473c-893c-310a713577a9"
      Me.GroupBox9.Location = New System.Drawing.Point(14, 15)
      Me.GroupBox9.Name = "GroupBox9"
      Me.GroupBox9.Size = New System.Drawing.Size(384, 131)
      Me.GroupBox9.TabIndex = 11
      Me.GroupBox9.Text = "Contatti del cedente/prestatore"
      '
      'Label36
      '
      Me.Label36.Location = New System.Drawing.Point(17, 59)
      Me.Label36.Name = "Label36"
      Me.Label36.Size = New System.Drawing.Size(81, 19)
      Me.Label36.TabIndex = 6
      Me.Label36.Tag = ""
      Me.Label36.Text = "Fax:"
      '
      'eui_txtCpEmail
      '
      Me.eui_txtCpEmail.Id = "2bfd8816-e492-4347-8d58-50374011d4fb"
      Me.eui_txtCpEmail.Location = New System.Drawing.Point(161, 93)
      Me.eui_txtCpEmail.MaxLength = 256
      Me.eui_txtCpEmail.Name = "eui_txtCpEmail"
      Me.eui_txtCpEmail.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpEmail.TabIndex = 2
      Me.eui_txtCpEmail.TextEditorWidth = 195
      '
      'eui_txtCpTelefono
      '
      Me.eui_txtCpTelefono.Id = "8f8a2590-9b3f-4a39-971c-f5fd68aea597"
      Me.eui_txtCpTelefono.Location = New System.Drawing.Point(161, 23)
      Me.eui_txtCpTelefono.MaxLength = 12
      Me.eui_txtCpTelefono.Name = "eui_txtCpTelefono"
      Me.eui_txtCpTelefono.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpTelefono.TabIndex = 0
      Me.eui_txtCpTelefono.TextEditorWidth = 195
      '
      'eui_txtCpFax
      '
      Me.eui_txtCpFax.Id = "ea0c3706-5181-4f2e-91a3-3b66218478dc"
      Me.eui_txtCpFax.Location = New System.Drawing.Point(161, 57)
      Me.eui_txtCpFax.MaxLength = 12
      Me.eui_txtCpFax.Name = "eui_txtCpFax"
      Me.eui_txtCpFax.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCpFax.TabIndex = 1
      Me.eui_txtCpFax.TextEditorWidth = 195
      '
      'Label42
      '
      Me.Label42.Location = New System.Drawing.Point(16, 95)
      Me.Label42.Name = "Label42"
      Me.Label42.Size = New System.Drawing.Size(131, 19)
      Me.Label42.TabIndex = 2
      Me.Label42.Text = "E-mail:"
      '
      'Label43
      '
      Me.Label43.Location = New System.Drawing.Point(19, 25)
      Me.Label43.Name = "Label43"
      Me.Label43.Size = New System.Drawing.Size(50, 19)
      Me.Label43.TabIndex = 0
      Me.Label43.Text = "Telefono:"
      '
      'TabPage16
      '
      Me.TabPage16.ActiveControl = Nothing
      Me.TabPage16.Controls.Add(Me.eui_txtCpRifAmministrazione)
      Me.TabPage16.Controls.Add(Me.Label44)
      Me.TabPage16.KeyTip = Nothing
      Me.TabPage16.Name = "TabPage16"
      Me.TabPage16.Size = New System.Drawing.Size(780, 398)
      Me.TabPage16.TabIndex = 5
      Me.TabPage16.Text = "Riferimento Amministrazione"
      '
      'eui_txtCpRifAmministrazione
      '
      Me.eui_txtCpRifAmministrazione.Id = "55cec3ed-fd53-4c1e-8e18-89dc41335b0a"
      Me.eui_txtCpRifAmministrazione.Location = New System.Drawing.Point(161, 13)
      Me.eui_txtCpRifAmministrazione.MaxLength = 20
      Me.eui_txtCpRifAmministrazione.Name = "eui_txtCpRifAmministrazione"
      Me.eui_txtCpRifAmministrazione.Size = New System.Drawing.Size(225, 21)
      Me.eui_txtCpRifAmministrazione.TabIndex = 7
      Me.eui_txtCpRifAmministrazione.TextEditorWidth = 219
      '
      'Label44
      '
      Me.Label44.Location = New System.Drawing.Point(14, 15)
      Me.Label44.Name = "Label44"
      Me.Label44.Size = New System.Drawing.Size(133, 19)
      Me.Label44.TabIndex = 6
      Me.Label44.Text = "Riferimento amministrazione:"
      '
      'TabPage5
      '
      Me.TabPage5.ActiveControl = Nothing
      Me.TabPage5.Controls.Add(Me.GroupBox2)
      Me.TabPage5.Controls.Add(Me.eui_txtProgressivoInvio)
      Me.TabPage5.Controls.Add(Me.Label7)
      Me.TabPage5.Controls.Add(Me.eui_txtCodiceDestinatario)
      Me.TabPage5.Controls.Add(Me.Label5)
      Me.TabPage5.Controls.Add(Me.eui_cmbFormatoTrasmissione)
      Me.TabPage5.Controls.Add(Me.Label6)
      Me.TabPage5.Controls.Add(Me.GroupBox1)
      Me.TabPage5.KeyTip = Nothing
      Me.TabPage5.Name = "TabPage5"
      Me.TabPage5.Size = New System.Drawing.Size(798, 438)
      Me.TabPage5.TabIndex = 0
      Me.TabPage5.Text = "Dati Trasmissione"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.Label10)
      Me.GroupBox2.Controls.Add(Me.eui_txtTrasmittentePECDestinatario)
      Me.GroupBox2.Controls.Add(Me.eui_txtTrasmittenteTelefono)
      Me.GroupBox2.Controls.Add(Me.eui_txtTrasmittenteEmail)
      Me.GroupBox2.Controls.Add(Me.Label8)
      Me.GroupBox2.Controls.Add(Me.Label9)
      Me.GroupBox2.Id = "0ec4e9c2-0581-4e69-bc73-522dd0fa544e"
      Me.GroupBox2.Location = New System.Drawing.Point(12, 240)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(384, 131)
      Me.GroupBox2.TabIndex = 10
      Me.GroupBox2.Text = "Contatti Trasmittente:"
      '
      'Label10
      '
      Me.Label10.Location = New System.Drawing.Point(19, 94)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(81, 19)
      Me.Label10.TabIndex = 6
      Me.Label10.Tag = ""
      Me.Label10.Text = "PEC destinatario:"
      '
      'eui_txtTrasmittentePECDestinatario
      '
      Me.eui_txtTrasmittentePECDestinatario.Id = "565f1a0b-f27c-4c3f-b58d-a95108ec3465"
      Me.eui_txtTrasmittentePECDestinatario.Location = New System.Drawing.Point(161, 93)
      Me.eui_txtTrasmittentePECDestinatario.MaxLength = 256
      Me.eui_txtTrasmittentePECDestinatario.Name = "eui_txtTrasmittentePECDestinatario"
      Me.eui_txtTrasmittentePECDestinatario.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTrasmittentePECDestinatario.TabIndex = 2
      Me.eui_txtTrasmittentePECDestinatario.TextEditorWidth = 195
      '
      'eui_txtTrasmittenteTelefono
      '
      Me.eui_txtTrasmittenteTelefono.Id = "7fbb2205-1fd0-4f0f-8fd8-d1fdb9c243d9"
      Me.eui_txtTrasmittenteTelefono.Location = New System.Drawing.Point(161, 23)
      Me.eui_txtTrasmittenteTelefono.MaxLength = 12
      Me.eui_txtTrasmittenteTelefono.Name = "eui_txtTrasmittenteTelefono"
      Me.eui_txtTrasmittenteTelefono.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTrasmittenteTelefono.TabIndex = 0
      Me.eui_txtTrasmittenteTelefono.TextEditorWidth = 195
      '
      'eui_txtTrasmittenteEmail
      '
      Me.eui_txtTrasmittenteEmail.Id = "65e93da9-c779-46e0-98d2-aee936ef62fb"
      Me.eui_txtTrasmittenteEmail.Location = New System.Drawing.Point(161, 57)
      Me.eui_txtTrasmittenteEmail.MaxLength = 256
      Me.eui_txtTrasmittenteEmail.Name = "eui_txtTrasmittenteEmail"
      Me.eui_txtTrasmittenteEmail.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTrasmittenteEmail.TabIndex = 1
      Me.eui_txtTrasmittenteEmail.TextEditorWidth = 195
      '
      'Label8
      '
      Me.Label8.Location = New System.Drawing.Point(19, 57)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(131, 19)
      Me.Label8.TabIndex = 2
      Me.Label8.Text = "E-mail:"
      '
      'Label9
      '
      Me.Label9.Location = New System.Drawing.Point(19, 25)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(50, 19)
      Me.Label9.TabIndex = 0
      Me.Label9.Text = "Telefono:"
      '
      'eui_txtProgressivoInvio
      '
      Me.eui_txtProgressivoInvio.Id = "dc244b45-e5d1-483a-8c12-b069b2822598"
      Me.eui_txtProgressivoInvio.Location = New System.Drawing.Point(173, 130)
      Me.eui_txtProgressivoInvio.MaxLength = 10
      Me.eui_txtProgressivoInvio.Name = "eui_txtProgressivoInvio"
      Me.eui_txtProgressivoInvio.ScreenTip.Caption = "Progressivo Invio"
      Me.eui_txtProgressivoInvio.ScreenTip.Text = "Formato alfanumerico; lunghezza massima di 10 caratteri."
      Me.eui_txtProgressivoInvio.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtProgressivoInvio.TabIndex = 0
      Me.eui_txtProgressivoInvio.TextEditorWidth = 195
      '
      'Label7
      '
      Me.Label7.Location = New System.Drawing.Point(31, 130)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(131, 19)
      Me.Label7.TabIndex = 8
      Me.Label7.Text = "Progressivo invio:"
      '
      'eui_txtCodiceDestinatario
      '
      Me.eui_txtCodiceDestinatario.Id = "e70c0676-da53-4b00-b304-f82eb0d9f5bd"
      Me.eui_txtCodiceDestinatario.Location = New System.Drawing.Point(173, 199)
      Me.eui_txtCodiceDestinatario.MaxLength = 7
      Me.eui_txtCodiceDestinatario.Name = "eui_txtCodiceDestinatario"
      Me.eui_txtCodiceDestinatario.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCodiceDestinatario.TabIndex = 2
      Me.eui_txtCodiceDestinatario.TextEditorWidth = 195
      '
      'Label5
      '
      Me.Label5.Location = New System.Drawing.Point(29, 197)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(131, 19)
      Me.Label5.TabIndex = 6
      Me.Label5.Text = "Codice destinatario:"
      '
      'eui_cmbFormatoTrasmissione
      '
      Me.eui_cmbFormatoTrasmissione.Editable = False
      Me.eui_cmbFormatoTrasmissione.FormattingEnabled = False
      Me.eui_cmbFormatoTrasmissione.Id = "d71e40ca-1c67-4fd6-b225-783f1484673c"
      Me.eui_cmbFormatoTrasmissione.Items.AddRange(New Object() {"FPA12", "FPR12"})
      Me.eui_cmbFormatoTrasmissione.Location = New System.Drawing.Point(173, 163)
      Me.eui_cmbFormatoTrasmissione.Name = "eui_cmbFormatoTrasmissione"
      Me.eui_cmbFormatoTrasmissione.Size = New System.Drawing.Size(111, 21)
      Me.eui_cmbFormatoTrasmissione.TabIndex = 1
      Me.eui_cmbFormatoTrasmissione.TextEditorWidth = 92
      '
      'Label6
      '
      Me.Label6.Location = New System.Drawing.Point(29, 165)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(101, 19)
      Me.Label6.TabIndex = 4
      Me.Label6.Text = "Formato trasmissione:"
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.eui_txtTrasmittenteIdCodice)
      Me.GroupBox1.Controls.Add(Me.Label4)
      Me.GroupBox1.Controls.Add(Me.eui_cmbTrasmittenteIdPaese)
      Me.GroupBox1.Controls.Add(Me.Label1)
      Me.GroupBox1.Id = "f3a236fd-ad3d-4d3b-bb74-ee015ee0c032"
      Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(393, 100)
      Me.GroupBox1.TabIndex = 0
      Me.GroupBox1.Text = "Identificativo Trasmittente"
      '
      'eui_txtTrasmittenteIdCodice
      '
      Me.eui_txtTrasmittenteIdCodice.Id = "433798ef-3d1e-4f71-af05-cb5195003521"
      Me.eui_txtTrasmittenteIdCodice.Location = New System.Drawing.Point(161, 57)
      Me.eui_txtTrasmittenteIdCodice.MaxLength = 28
      Me.eui_txtTrasmittenteIdCodice.Name = "eui_txtTrasmittenteIdCodice"
      Me.eui_txtTrasmittenteIdCodice.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTrasmittenteIdCodice.TabIndex = 1
      Me.eui_txtTrasmittenteIdCodice.TextEditorWidth = 195
      '
      'Label4
      '
      Me.Label4.Location = New System.Drawing.Point(19, 57)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(131, 19)
      Me.Label4.TabIndex = 2
      Me.Label4.Text = "Codice identificativo fiscale:"
      '
      'eui_cmbTrasmittenteIdPaese
      '
      Me.eui_cmbTrasmittenteIdPaese.Editable = False
      Me.eui_cmbTrasmittenteIdPaese.FormattingEnabled = False
      Me.eui_cmbTrasmittenteIdPaese.Id = "4ea8545f-2893-4998-bf33-cba9d5abf513"
      Me.eui_cmbTrasmittenteIdPaese.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbTrasmittenteIdPaese.Location = New System.Drawing.Point(161, 23)
      Me.eui_cmbTrasmittenteIdPaese.Name = "eui_cmbTrasmittenteIdPaese"
      Me.eui_cmbTrasmittenteIdPaese.Size = New System.Drawing.Size(201, 21)
      Me.eui_cmbTrasmittenteIdPaese.TabIndex = 0
      Me.eui_cmbTrasmittenteIdPaese.TextEditorWidth = 182
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(19, 25)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(50, 19)
      Me.Label1.TabIndex = 0
      Me.Label1.Text = "Paese:"
      '
      'TabPage7
      '
      Me.TabPage7.ActiveControl = Nothing
      Me.TabPage7.Controls.Add(Me.Label52)
      Me.TabPage7.Controls.Add(Me.GroupBox10)
      Me.TabPage7.Controls.Add(Me.eui_txtRfCpCodiceFiscale)
      Me.TabPage7.Controls.Add(Me.GroupBox11)
      Me.TabPage7.KeyTip = Nothing
      Me.TabPage7.Name = "TabPage7"
      Me.TabPage7.Size = New System.Drawing.Size(798, 438)
      Me.TabPage7.TabIndex = 2
      Me.TabPage7.Text = "Rappresentante Fiscale"
      '
      'Label52
      '
      Me.Label52.Location = New System.Drawing.Point(27, 126)
      Me.Label52.Name = "Label52"
      Me.Label52.Size = New System.Drawing.Size(87, 19)
      Me.Label52.TabIndex = 10
      Me.Label52.Text = "Codice fiscale:"
      '
      'GroupBox10
      '
      Me.GroupBox10.Controls.Add(Me.Label45)
      Me.GroupBox10.Controls.Add(Me.Label46)
      Me.GroupBox10.Controls.Add(Me.Label47)
      Me.GroupBox10.Controls.Add(Me.eui_txtRfCpCodiceEORI)
      Me.GroupBox10.Controls.Add(Me.eui_txtRfCpTitolo)
      Me.GroupBox10.Controls.Add(Me.eui_txtRfCpCognome)
      Me.GroupBox10.Controls.Add(Me.eui_txtRfCpDenominazione)
      Me.GroupBox10.Controls.Add(Me.eui_txtRfCpNome)
      Me.GroupBox10.Controls.Add(Me.Label48)
      Me.GroupBox10.Controls.Add(Me.Label49)
      Me.GroupBox10.Id = "e0fc915e-c43a-4204-acd3-c25858953e4f"
      Me.GroupBox10.Location = New System.Drawing.Point(8, 159)
      Me.GroupBox10.Name = "GroupBox10"
      Me.GroupBox10.Size = New System.Drawing.Size(381, 203)
      Me.GroupBox10.TabIndex = 9
      Me.GroupBox10.Text = "Anagrafica"
      '
      'Label45
      '
      Me.Label45.Location = New System.Drawing.Point(19, 165)
      Me.Label45.Name = "Label45"
      Me.Label45.Size = New System.Drawing.Size(78, 19)
      Me.Label45.TabIndex = 10
      Me.Label45.Text = "Codice EORI:"
      '
      'Label46
      '
      Me.Label46.Location = New System.Drawing.Point(19, 130)
      Me.Label46.Name = "Label46"
      Me.Label46.Size = New System.Drawing.Size(78, 19)
      Me.Label46.TabIndex = 9
      Me.Label46.Text = "Titolo:"
      '
      'Label47
      '
      Me.Label47.Location = New System.Drawing.Point(19, 94)
      Me.Label47.Name = "Label47"
      Me.Label47.Size = New System.Drawing.Size(78, 19)
      Me.Label47.TabIndex = 8
      Me.Label47.Text = "Cognome:"
      '
      'eui_txtRfCpCodiceEORI
      '
      Me.eui_txtRfCpCodiceEORI.Id = "4d0e96fa-fa65-474c-bda1-757280380148"
      Me.eui_txtRfCpCodiceEORI.Location = New System.Drawing.Point(114, 163)
      Me.eui_txtRfCpCodiceEORI.MaxLength = 17
      Me.eui_txtRfCpCodiceEORI.Name = "eui_txtRfCpCodiceEORI"
      Me.eui_txtRfCpCodiceEORI.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtRfCpCodiceEORI.TabIndex = 4
      Me.eui_txtRfCpCodiceEORI.TextEditorWidth = 195
      '
      'eui_txtRfCpTitolo
      '
      Me.eui_txtRfCpTitolo.Id = "9ab9a17b-0ca9-4a7c-85bb-607ceae8c587"
      Me.eui_txtRfCpTitolo.Location = New System.Drawing.Point(114, 128)
      Me.eui_txtRfCpTitolo.MaxLength = 10
      Me.eui_txtRfCpTitolo.Name = "eui_txtRfCpTitolo"
      Me.eui_txtRfCpTitolo.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtRfCpTitolo.TabIndex = 3
      Me.eui_txtRfCpTitolo.TextEditorWidth = 195
      '
      'eui_txtRfCpCognome
      '
      Me.eui_txtRfCpCognome.Id = "b7b28f37-2e3d-41f2-86c1-59578e4f5aa6"
      Me.eui_txtRfCpCognome.Location = New System.Drawing.Point(113, 92)
      Me.eui_txtRfCpCognome.MaxLength = 60
      Me.eui_txtRfCpCognome.Name = "eui_txtRfCpCognome"
      Me.eui_txtRfCpCognome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtRfCpCognome.TabIndex = 2
      Me.eui_txtRfCpCognome.TextEditorWidth = 195
      '
      'eui_txtRfCpDenominazione
      '
      Me.eui_txtRfCpDenominazione.Id = "e6e6549a-2d4f-4bad-98ec-4937e10ba3ee"
      Me.eui_txtRfCpDenominazione.Location = New System.Drawing.Point(113, 23)
      Me.eui_txtRfCpDenominazione.MaxLength = 80
      Me.eui_txtRfCpDenominazione.Name = "eui_txtRfCpDenominazione"
      Me.eui_txtRfCpDenominazione.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtRfCpDenominazione.TabIndex = 0
      Me.eui_txtRfCpDenominazione.TextEditorWidth = 195
      '
      'eui_txtRfCpNome
      '
      Me.eui_txtRfCpNome.Id = "98814ec3-4c8a-49da-bd6e-8c2b98fb5f4f"
      Me.eui_txtRfCpNome.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtRfCpNome.MaxLength = 60
      Me.eui_txtRfCpNome.Name = "eui_txtRfCpNome"
      Me.eui_txtRfCpNome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtRfCpNome.TabIndex = 1
      Me.eui_txtRfCpNome.TextEditorWidth = 195
      '
      'Label48
      '
      Me.Label48.Location = New System.Drawing.Point(19, 57)
      Me.Label48.Name = "Label48"
      Me.Label48.Size = New System.Drawing.Size(131, 19)
      Me.Label48.TabIndex = 2
      Me.Label48.Text = "Nome:"
      '
      'Label49
      '
      Me.Label49.Location = New System.Drawing.Point(19, 25)
      Me.Label49.Name = "Label49"
      Me.Label49.Size = New System.Drawing.Size(76, 19)
      Me.Label49.TabIndex = 0
      Me.Label49.Text = "Denominazione:"
      '
      'eui_txtRfCpCodiceFiscale
      '
      Me.eui_txtRfCpCodiceFiscale.Id = "07138d7e-d5c4-4a6b-b1f6-a5294f53c4ae"
      Me.eui_txtRfCpCodiceFiscale.Location = New System.Drawing.Point(122, 124)
      Me.eui_txtRfCpCodiceFiscale.MaxLength = 16
      Me.eui_txtRfCpCodiceFiscale.Name = "eui_txtRfCpCodiceFiscale"
      Me.eui_txtRfCpCodiceFiscale.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtRfCpCodiceFiscale.TabIndex = 0
      Me.eui_txtRfCpCodiceFiscale.TextEditorWidth = 195
      '
      'GroupBox11
      '
      Me.GroupBox11.Controls.Add(Me.eui_txtRfCpIdCodice)
      Me.GroupBox11.Controls.Add(Me.Label50)
      Me.GroupBox11.Controls.Add(Me.eui_cmbRfCpIdPaese)
      Me.GroupBox11.Controls.Add(Me.Label51)
      Me.GroupBox11.Id = "09af98f6-67bb-429e-b03d-95f8330e087b"
      Me.GroupBox11.Location = New System.Drawing.Point(8, 9)
      Me.GroupBox11.Name = "GroupBox11"
      Me.GroupBox11.Size = New System.Drawing.Size(381, 100)
      Me.GroupBox11.TabIndex = 7
      Me.GroupBox11.Text = "Id Fiscale IVA"
      '
      'eui_txtRfCpIdCodice
      '
      Me.eui_txtRfCpIdCodice.Id = "7495df6b-1c95-4e57-905b-8680851f0663"
      Me.eui_txtRfCpIdCodice.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtRfCpIdCodice.MaxLength = 28
      Me.eui_txtRfCpIdCodice.Name = "eui_txtRfCpIdCodice"
      Me.eui_txtRfCpIdCodice.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtRfCpIdCodice.TabIndex = 1
      Me.eui_txtRfCpIdCodice.TextEditorWidth = 195
      '
      'Label50
      '
      Me.Label50.Location = New System.Drawing.Point(19, 57)
      Me.Label50.Name = "Label50"
      Me.Label50.Size = New System.Drawing.Size(131, 19)
      Me.Label50.TabIndex = 2
      Me.Label50.Text = "Partita IVA:"
      '
      'eui_cmbRfCpIdPaese
      '
      Me.eui_cmbRfCpIdPaese.Editable = False
      Me.eui_cmbRfCpIdPaese.FormattingEnabled = False
      Me.eui_cmbRfCpIdPaese.Id = "1461def2-6c01-4f5c-8b47-1b114053b10e"
      Me.eui_cmbRfCpIdPaese.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbRfCpIdPaese.Location = New System.Drawing.Point(113, 23)
      Me.eui_cmbRfCpIdPaese.Name = "eui_cmbRfCpIdPaese"
      Me.eui_cmbRfCpIdPaese.Size = New System.Drawing.Size(201, 21)
      Me.eui_cmbRfCpIdPaese.TabIndex = 0
      Me.eui_cmbRfCpIdPaese.TextEditorWidth = 182
      '
      'Label51
      '
      Me.Label51.Location = New System.Drawing.Point(19, 25)
      Me.Label51.Name = "Label51"
      Me.Label51.Size = New System.Drawing.Size(50, 19)
      Me.Label51.TabIndex = 0
      Me.Label51.Text = "Paese:"
      '
      'TabPage8
      '
      Me.TabPage8.ActiveControl = Nothing
      Me.TabPage8.Controls.Add(Me.TabControl3)
      Me.TabPage8.KeyTip = Nothing
      Me.TabPage8.Name = "TabPage8"
      Me.TabPage8.Size = New System.Drawing.Size(798, 438)
      Me.TabPage8.TabIndex = 3
      Me.TabPage8.Text = "Cessionario/Committente"
      '
      'TabControl3
      '
      Me.TabControl3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TabControl3.Location = New System.Drawing.Point(8, 9)
      Me.TabControl3.Name = "TabControl3"
      Me.TabControl3.SelectedTabPage = Me.TabPage17
      Me.TabControl3.Size = New System.Drawing.Size(782, 422)
      Me.TabControl3.TabIndex = 0
      Me.TabControl3.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.TabPage17, Me.TabPage18, Me.TabPage19, Me.TabPage20})
      Me.TabControl3.Text = "TabControl3"
      '
      'TabPage17
      '
      Me.TabPage17.ActiveControl = Nothing
      Me.TabPage17.Controls.Add(Me.GroupBox12)
      Me.TabPage17.Controls.Add(Me.eui_txtCcCodiceFiscale)
      Me.TabPage17.Controls.Add(Me.Label58)
      Me.TabPage17.Controls.Add(Me.GroupBox13)
      Me.TabPage17.KeyTip = Nothing
      Me.TabPage17.Name = "TabPage17"
      Me.TabPage17.Size = New System.Drawing.Size(780, 401)
      Me.TabPage17.TabIndex = 0
      Me.TabPage17.Text = "Dati Anagrafici"
      '
      'GroupBox12
      '
      Me.GroupBox12.Controls.Add(Me.Label53)
      Me.GroupBox12.Controls.Add(Me.Label54)
      Me.GroupBox12.Controls.Add(Me.Label55)
      Me.GroupBox12.Controls.Add(Me.eui_txtCcCodiceEORI)
      Me.GroupBox12.Controls.Add(Me.eui_txtCcTitolo)
      Me.GroupBox12.Controls.Add(Me.eui_txtCcCognome)
      Me.GroupBox12.Controls.Add(Me.eui_txtCcDenominazione)
      Me.GroupBox12.Controls.Add(Me.eui_txtCcNome)
      Me.GroupBox12.Controls.Add(Me.Label56)
      Me.GroupBox12.Controls.Add(Me.Label57)
      Me.GroupBox12.Id = "232dfa5d-3669-4f70-b81c-7e77581a16df"
      Me.GroupBox12.Location = New System.Drawing.Point(11, 162)
      Me.GroupBox12.Name = "GroupBox12"
      Me.GroupBox12.Size = New System.Drawing.Size(381, 203)
      Me.GroupBox12.TabIndex = 10
      Me.GroupBox12.Text = "Anagrafica"
      '
      'Label53
      '
      Me.Label53.Location = New System.Drawing.Point(19, 165)
      Me.Label53.Name = "Label53"
      Me.Label53.Size = New System.Drawing.Size(78, 19)
      Me.Label53.TabIndex = 10
      Me.Label53.Text = "Codice EORI:"
      '
      'Label54
      '
      Me.Label54.Location = New System.Drawing.Point(19, 130)
      Me.Label54.Name = "Label54"
      Me.Label54.Size = New System.Drawing.Size(78, 19)
      Me.Label54.TabIndex = 9
      Me.Label54.Text = "Titolo:"
      '
      'Label55
      '
      Me.Label55.Location = New System.Drawing.Point(19, 94)
      Me.Label55.Name = "Label55"
      Me.Label55.Size = New System.Drawing.Size(78, 19)
      Me.Label55.TabIndex = 8
      Me.Label55.Text = "Cognome:"
      '
      'eui_txtCcCodiceEORI
      '
      Me.eui_txtCcCodiceEORI.Id = "15e99148-7540-45b1-958c-03402d03502a"
      Me.eui_txtCcCodiceEORI.Location = New System.Drawing.Point(114, 163)
      Me.eui_txtCcCodiceEORI.MaxLength = 17
      Me.eui_txtCcCodiceEORI.Name = "eui_txtCcCodiceEORI"
      Me.eui_txtCcCodiceEORI.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcCodiceEORI.TabIndex = 4
      Me.eui_txtCcCodiceEORI.TextEditorWidth = 195
      '
      'eui_txtCcTitolo
      '
      Me.eui_txtCcTitolo.Id = "f5d78260-9acf-4925-b876-f6d829438497"
      Me.eui_txtCcTitolo.Location = New System.Drawing.Point(114, 128)
      Me.eui_txtCcTitolo.MaxLength = 10
      Me.eui_txtCcTitolo.Name = "eui_txtCcTitolo"
      Me.eui_txtCcTitolo.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcTitolo.TabIndex = 3
      Me.eui_txtCcTitolo.TextEditorWidth = 195
      '
      'eui_txtCcCognome
      '
      Me.eui_txtCcCognome.Id = "776d7fe0-656d-4ed3-9c73-99f40851695f"
      Me.eui_txtCcCognome.Location = New System.Drawing.Point(113, 92)
      Me.eui_txtCcCognome.MaxLength = 60
      Me.eui_txtCcCognome.Name = "eui_txtCcCognome"
      Me.eui_txtCcCognome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcCognome.TabIndex = 2
      Me.eui_txtCcCognome.TextEditorWidth = 195
      '
      'eui_txtCcDenominazione
      '
      Me.eui_txtCcDenominazione.Id = "7ff21d99-7696-45da-a2df-627c5dcc39b3"
      Me.eui_txtCcDenominazione.Location = New System.Drawing.Point(113, 23)
      Me.eui_txtCcDenominazione.MaxLength = 80
      Me.eui_txtCcDenominazione.Name = "eui_txtCcDenominazione"
      Me.eui_txtCcDenominazione.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcDenominazione.TabIndex = 0
      Me.eui_txtCcDenominazione.TextEditorWidth = 195
      '
      'eui_txtCcNome
      '
      Me.eui_txtCcNome.Id = "b87f3b4d-4366-4e52-82ea-1b91ba4b915d"
      Me.eui_txtCcNome.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCcNome.MaxLength = 60
      Me.eui_txtCcNome.Name = "eui_txtCcNome"
      Me.eui_txtCcNome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcNome.TabIndex = 1
      Me.eui_txtCcNome.TextEditorWidth = 195
      '
      'Label56
      '
      Me.Label56.Location = New System.Drawing.Point(19, 57)
      Me.Label56.Name = "Label56"
      Me.Label56.Size = New System.Drawing.Size(131, 19)
      Me.Label56.TabIndex = 2
      Me.Label56.Text = "Nome:"
      '
      'Label57
      '
      Me.Label57.Location = New System.Drawing.Point(19, 25)
      Me.Label57.Name = "Label57"
      Me.Label57.Size = New System.Drawing.Size(76, 19)
      Me.Label57.TabIndex = 0
      Me.Label57.Text = "Denominazione:"
      '
      'eui_txtCcCodiceFiscale
      '
      Me.eui_txtCcCodiceFiscale.Id = "60aa28cd-e59b-4f2b-b5b6-3f7ecc536c7b"
      Me.eui_txtCcCodiceFiscale.Location = New System.Drawing.Point(125, 127)
      Me.eui_txtCcCodiceFiscale.MaxLength = 16
      Me.eui_txtCcCodiceFiscale.Name = "eui_txtCcCodiceFiscale"
      Me.eui_txtCcCodiceFiscale.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcCodiceFiscale.TabIndex = 0
      Me.eui_txtCcCodiceFiscale.TextEditorWidth = 195
      '
      'Label58
      '
      Me.Label58.Location = New System.Drawing.Point(27, 129)
      Me.Label58.Name = "Label58"
      Me.Label58.Size = New System.Drawing.Size(87, 19)
      Me.Label58.TabIndex = 8
      Me.Label58.Text = "Codice fiscale:"
      '
      'GroupBox13
      '
      Me.GroupBox13.Controls.Add(Me.eui_txtCcIdCodice)
      Me.GroupBox13.Controls.Add(Me.Label59)
      Me.GroupBox13.Controls.Add(Me.eui_cmbCcIdPaese)
      Me.GroupBox13.Controls.Add(Me.Label60)
      Me.GroupBox13.Id = "28c6e520-ba70-4c82-a72e-12d7722fe9bd"
      Me.GroupBox13.Location = New System.Drawing.Point(11, 12)
      Me.GroupBox13.Name = "GroupBox13"
      Me.GroupBox13.Size = New System.Drawing.Size(381, 100)
      Me.GroupBox13.TabIndex = 7
      Me.GroupBox13.Text = "Id Fiscale IVA"
      '
      'eui_txtCcIdCodice
      '
      Me.eui_txtCcIdCodice.Id = "9974755a-122d-40c5-9882-1c5e6365e341"
      Me.eui_txtCcIdCodice.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCcIdCodice.MaxLength = 28
      Me.eui_txtCcIdCodice.Name = "eui_txtCcIdCodice"
      Me.eui_txtCcIdCodice.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcIdCodice.TabIndex = 1
      Me.eui_txtCcIdCodice.TextEditorWidth = 195
      '
      'Label59
      '
      Me.Label59.Location = New System.Drawing.Point(19, 57)
      Me.Label59.Name = "Label59"
      Me.Label59.Size = New System.Drawing.Size(131, 19)
      Me.Label59.TabIndex = 2
      Me.Label59.Text = "Partita IVA:"
      '
      'eui_cmbCcIdPaese
      '
      Me.eui_cmbCcIdPaese.Editable = False
      Me.eui_cmbCcIdPaese.FormattingEnabled = False
      Me.eui_cmbCcIdPaese.Id = "173b940e-60ac-47f1-a963-c134a868fe92"
      Me.eui_cmbCcIdPaese.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbCcIdPaese.Location = New System.Drawing.Point(113, 23)
      Me.eui_cmbCcIdPaese.Name = "eui_cmbCcIdPaese"
      Me.eui_cmbCcIdPaese.Size = New System.Drawing.Size(201, 21)
      Me.eui_cmbCcIdPaese.TabIndex = 0
      Me.eui_cmbCcIdPaese.TextEditorWidth = 182
      '
      'Label60
      '
      Me.Label60.Location = New System.Drawing.Point(19, 25)
      Me.Label60.Name = "Label60"
      Me.Label60.Size = New System.Drawing.Size(50, 19)
      Me.Label60.TabIndex = 0
      Me.Label60.Text = "Paese:"
      '
      'TabPage18
      '
      Me.TabPage18.ActiveControl = Nothing
      Me.TabPage18.Controls.Add(Me.GroupBox14)
      Me.TabPage18.KeyTip = Nothing
      Me.TabPage18.Name = "TabPage18"
      Me.TabPage18.Size = New System.Drawing.Size(780, 397)
      Me.TabPage18.TabIndex = 1
      Me.TabPage18.Text = "Sede"
      '
      'GroupBox14
      '
      Me.GroupBox14.Controls.Add(Me.eui_cmbCcSedeNazione)
      Me.GroupBox14.Controls.Add(Me.Label61)
      Me.GroupBox14.Controls.Add(Me.eui_cmbCcSedeProvincia)
      Me.GroupBox14.Controls.Add(Me.Label62)
      Me.GroupBox14.Controls.Add(Me.Label63)
      Me.GroupBox14.Controls.Add(Me.Label64)
      Me.GroupBox14.Controls.Add(Me.eui_txtCcSedeComune)
      Me.GroupBox14.Controls.Add(Me.eui_txtCcSedeCAP)
      Me.GroupBox14.Controls.Add(Me.eui_txtCcSedeIndirizzo)
      Me.GroupBox14.Controls.Add(Me.eui_txtCcSedeNumeroCivico)
      Me.GroupBox14.Controls.Add(Me.Label65)
      Me.GroupBox14.Controls.Add(Me.Label66)
      Me.GroupBox14.Id = "5da6b73d-f29b-49d6-8f48-40565e019692"
      Me.GroupBox14.Location = New System.Drawing.Point(11, 12)
      Me.GroupBox14.Name = "GroupBox14"
      Me.GroupBox14.Size = New System.Drawing.Size(381, 230)
      Me.GroupBox14.TabIndex = 8
      Me.GroupBox14.Text = "Sede del cessionario/committente"
      '
      'eui_cmbCcSedeNazione
      '
      Me.eui_cmbCcSedeNazione.Editable = False
      Me.eui_cmbCcSedeNazione.FormattingEnabled = False
      Me.eui_cmbCcSedeNazione.Id = "cc881ac6-a2a6-47cf-9a62-73a9b84b4fd3"
      Me.eui_cmbCcSedeNazione.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbCcSedeNazione.Location = New System.Drawing.Point(113, 194)
      Me.eui_cmbCcSedeNazione.Name = "eui_cmbCcSedeNazione"
      Me.eui_cmbCcSedeNazione.Size = New System.Drawing.Size(240, 21)
      Me.eui_cmbCcSedeNazione.TabIndex = 5
      Me.eui_cmbCcSedeNazione.TextEditorWidth = 221
      '
      'Label61
      '
      Me.Label61.Location = New System.Drawing.Point(19, 196)
      Me.Label61.Name = "Label61"
      Me.Label61.Size = New System.Drawing.Size(78, 19)
      Me.Label61.TabIndex = 12
      Me.Label61.Text = "Nazione:"
      '
      'eui_cmbCcSedeProvincia
      '
      Me.eui_cmbCcSedeProvincia.Editable = False
      Me.eui_cmbCcSedeProvincia.FormattingEnabled = False
      Me.eui_cmbCcSedeProvincia.Id = "f26c1c3a-590d-402f-9933-6c96fe5a5796"
      Me.eui_cmbCcSedeProvincia.Items.AddRange(New Object() {" ", "AG Agrigento", "AL Alessandria", "AN Ancona", "AO Aosta", "AR Arezzo", "AP Ascoli Piceno", "AT Asti", "AV Avellino", "BA Bari", "BT Barletta-Andria-Trani", "BL Belluno", "BN Benevento", "BG Bergamo", "BI Biella", "BO Bologna", "BZ Bolzano", "BS Brescia", "BR Brindisi", "CA Cagliari", "CL Caltanissetta", "CB Campobasso", "CI Carbonia-Iglesias", "CE Caserta", "CT Catania", "CZ Catanzaro", "CH Chieti", "CO Como", "CS Cosenza", "CR Cremona", "KR Crotone", "CN Cuneo", "EN Enna", "FM Fermo", "FE Ferrara", "FI Firenze", "FU Fiume", "FG Foggia", "FC Forlì-Cesena", "FR Frosinone", "GE Genova", "GO Gorizia", "GR Grosseto", "IM Imperia", "IS Isernia", "AQ L'Aquila", "SP La Spezia", "LT Latina", "LE Lecce", "LC Lecco", "LI Livorno", "LO Lodi", "LB Lubiana", "LU Lucca", "MC Macerata", "MN Mantova", "MS Massa-Carrara", "MT Matera", "VS Medio Campidano", "ME Messina", "MI Milano", "MO Modena", "MB Monza e Brianza", "NA Napoli", "NO Novara", "NU Nuoro", "OG Ogliastra", "OT Olbia-Tempio", "OR Oristano", "PD Padova", "PA Palermo", "PR Parma", "PV Pavia", "PG Perugia", "PU Pesaro e Urbino ", "PE Pescara", "PC Piacenza", "PI Pisa", "PT Pistoia", "PL Pola", "PN Pordenone", "PZ Potenza", "PO Prato", "RG Ragusa", "RA Ravenna", "RC Reggio di Calabria", "RE Reggio nell'Emilia", "RI Rieti", "RN Rimini", "RM Roma", "RO Rovigo", "SA Salerno", "SS Sassari", "SV Savona", "SI Siena", "SR Siracusa", "SO Sondrio", "SU Sud Sardegna", "TA Taranto", "TE Teramo", "TR Terni", "TO Torino", "TP Trapani", "TN Trento", "TV Treviso", "TS Trieste", "UD Udine", "VA Varese", "VE Venezia", "VB Verbano-Cusio-Ossola", "VC Vercelli", "VR Verona", "VV Vibo Valentia", "VI Vicenza", "VT Viterbo", "ZA Zara"})
      Me.eui_cmbCcSedeProvincia.Location = New System.Drawing.Point(113, 163)
      Me.eui_cmbCcSedeProvincia.Name = "eui_cmbCcSedeProvincia"
      Me.eui_cmbCcSedeProvincia.Size = New System.Drawing.Size(241, 21)
      Me.eui_cmbCcSedeProvincia.TabIndex = 4
      Me.eui_cmbCcSedeProvincia.TextEditorWidth = 222
      '
      'Label62
      '
      Me.Label62.Location = New System.Drawing.Point(19, 165)
      Me.Label62.Name = "Label62"
      Me.Label62.Size = New System.Drawing.Size(78, 19)
      Me.Label62.TabIndex = 10
      Me.Label62.Text = "Provincia:"
      '
      'Label63
      '
      Me.Label63.Location = New System.Drawing.Point(19, 130)
      Me.Label63.Name = "Label63"
      Me.Label63.Size = New System.Drawing.Size(78, 19)
      Me.Label63.TabIndex = 9
      Me.Label63.Text = "Comune:"
      '
      'Label64
      '
      Me.Label64.Location = New System.Drawing.Point(19, 94)
      Me.Label64.Name = "Label64"
      Me.Label64.Size = New System.Drawing.Size(78, 19)
      Me.Label64.TabIndex = 8
      Me.Label64.Tag = ""
      Me.Label64.Text = "CAP:"
      '
      'eui_txtCcSedeComune
      '
      Me.eui_txtCcSedeComune.Id = "dea454d8-8680-4b91-b8d1-d72be0a02597"
      Me.eui_txtCcSedeComune.Location = New System.Drawing.Point(114, 128)
      Me.eui_txtCcSedeComune.MaxLength = 60
      Me.eui_txtCcSedeComune.Name = "eui_txtCcSedeComune"
      Me.eui_txtCcSedeComune.Size = New System.Drawing.Size(240, 21)
      Me.eui_txtCcSedeComune.TabIndex = 3
      Me.eui_txtCcSedeComune.TextEditorWidth = 234
      '
      'eui_txtCcSedeCAP
      '
      Me.eui_txtCcSedeCAP.Id = "da1569ce-a757-41e7-aca9-f14d7007263b"
      Me.eui_txtCcSedeCAP.Location = New System.Drawing.Point(113, 92)
      Me.eui_txtCcSedeCAP.MaxLength = 5
      Me.eui_txtCcSedeCAP.Name = "eui_txtCcSedeCAP"
      Me.eui_txtCcSedeCAP.Size = New System.Drawing.Size(105, 21)
      Me.eui_txtCcSedeCAP.TabIndex = 2
      Me.eui_txtCcSedeCAP.TextEditorWidth = 99
      '
      'eui_txtCcSedeIndirizzo
      '
      Me.eui_txtCcSedeIndirizzo.Id = "bf6f4141-19c4-4406-9a4e-5df57ebcff4e"
      Me.eui_txtCcSedeIndirizzo.Location = New System.Drawing.Point(113, 23)
      Me.eui_txtCcSedeIndirizzo.MaxLength = 60
      Me.eui_txtCcSedeIndirizzo.Name = "eui_txtCcSedeIndirizzo"
      Me.eui_txtCcSedeIndirizzo.Size = New System.Drawing.Size(240, 21)
      Me.eui_txtCcSedeIndirizzo.TabIndex = 0
      Me.eui_txtCcSedeIndirizzo.TextEditorWidth = 234
      '
      'eui_txtCcSedeNumeroCivico
      '
      Me.eui_txtCcSedeNumeroCivico.Id = "aaa9eac4-ff12-439a-9c44-63c8a7d4efe8"
      Me.eui_txtCcSedeNumeroCivico.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCcSedeNumeroCivico.MaxLength = 8
      Me.eui_txtCcSedeNumeroCivico.Name = "eui_txtCcSedeNumeroCivico"
      Me.eui_txtCcSedeNumeroCivico.Size = New System.Drawing.Size(105, 21)
      Me.eui_txtCcSedeNumeroCivico.TabIndex = 1
      Me.eui_txtCcSedeNumeroCivico.TextEditorWidth = 99
      '
      'Label65
      '
      Me.Label65.Location = New System.Drawing.Point(19, 57)
      Me.Label65.Name = "Label65"
      Me.Label65.Size = New System.Drawing.Size(76, 19)
      Me.Label65.TabIndex = 2
      Me.Label65.Text = "Numero civico:"
      '
      'Label66
      '
      Me.Label66.Location = New System.Drawing.Point(19, 25)
      Me.Label66.Name = "Label66"
      Me.Label66.Size = New System.Drawing.Size(76, 19)
      Me.Label66.TabIndex = 0
      Me.Label66.Text = "Indirizzo:"
      '
      'TabPage19
      '
      Me.TabPage19.ActiveControl = Nothing
      Me.TabPage19.Controls.Add(Me.GroupBox17)
      Me.TabPage19.KeyTip = Nothing
      Me.TabPage19.Name = "TabPage19"
      Me.TabPage19.Size = New System.Drawing.Size(780, 397)
      Me.TabPage19.TabIndex = 2
      Me.TabPage19.Text = "Stabile Organizzazione"
      '
      'GroupBox17
      '
      Me.GroupBox17.Controls.Add(Me.eui_cmbCcStabileOrgNazione)
      Me.GroupBox17.Controls.Add(Me.Label76)
      Me.GroupBox17.Controls.Add(Me.eui_cmbCcStabileOrgProvincia)
      Me.GroupBox17.Controls.Add(Me.Label77)
      Me.GroupBox17.Controls.Add(Me.Label78)
      Me.GroupBox17.Controls.Add(Me.Label79)
      Me.GroupBox17.Controls.Add(Me.eui_txtCcStabileOrgComune)
      Me.GroupBox17.Controls.Add(Me.eui_txtCcStabileOrgCAP)
      Me.GroupBox17.Controls.Add(Me.eui_txtCcStabileOrgIndirizzo)
      Me.GroupBox17.Controls.Add(Me.eui_txtCcStabileOrgNumeroCivico)
      Me.GroupBox17.Controls.Add(Me.Label80)
      Me.GroupBox17.Controls.Add(Me.Label81)
      Me.GroupBox17.Id = "dcc297f2-e62c-4f03-a597-fb49c6ea3fe5"
      Me.GroupBox17.Location = New System.Drawing.Point(12, 12)
      Me.GroupBox17.Name = "GroupBox17"
      Me.GroupBox17.Size = New System.Drawing.Size(381, 230)
      Me.GroupBox17.TabIndex = 9
      Me.GroupBox17.Text = "Stabile Organizazzione del cessionario/committente non residente"
      '
      'eui_cmbCcStabileOrgNazione
      '
      Me.eui_cmbCcStabileOrgNazione.Editable = False
      Me.eui_cmbCcStabileOrgNazione.FormattingEnabled = False
      Me.eui_cmbCcStabileOrgNazione.Id = "3a3d54ee-3b99-428d-8b55-62e64c656b75"
      Me.eui_cmbCcStabileOrgNazione.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbCcStabileOrgNazione.Location = New System.Drawing.Point(113, 194)
      Me.eui_cmbCcStabileOrgNazione.Name = "eui_cmbCcStabileOrgNazione"
      Me.eui_cmbCcStabileOrgNazione.Size = New System.Drawing.Size(240, 21)
      Me.eui_cmbCcStabileOrgNazione.TabIndex = 5
      Me.eui_cmbCcStabileOrgNazione.TextEditorWidth = 221
      '
      'Label76
      '
      Me.Label76.Location = New System.Drawing.Point(19, 196)
      Me.Label76.Name = "Label76"
      Me.Label76.Size = New System.Drawing.Size(78, 19)
      Me.Label76.TabIndex = 12
      Me.Label76.Text = "Nazione:"
      '
      'eui_cmbCcStabileOrgProvincia
      '
      Me.eui_cmbCcStabileOrgProvincia.Editable = False
      Me.eui_cmbCcStabileOrgProvincia.FormattingEnabled = False
      Me.eui_cmbCcStabileOrgProvincia.Id = "f07047cd-7c09-46a6-b0d5-d57bbd022de1"
      Me.eui_cmbCcStabileOrgProvincia.Location = New System.Drawing.Point(113, 163)
      Me.eui_cmbCcStabileOrgProvincia.Name = "eui_cmbCcStabileOrgProvincia"
      Me.eui_cmbCcStabileOrgProvincia.Size = New System.Drawing.Size(240, 21)
      Me.eui_cmbCcStabileOrgProvincia.TabIndex = 4
      Me.eui_cmbCcStabileOrgProvincia.TextEditorWidth = 221
      '
      'Label77
      '
      Me.Label77.Location = New System.Drawing.Point(19, 165)
      Me.Label77.Name = "Label77"
      Me.Label77.Size = New System.Drawing.Size(78, 19)
      Me.Label77.TabIndex = 10
      Me.Label77.Text = "Provincia:"
      '
      'Label78
      '
      Me.Label78.Location = New System.Drawing.Point(19, 130)
      Me.Label78.Name = "Label78"
      Me.Label78.Size = New System.Drawing.Size(78, 19)
      Me.Label78.TabIndex = 9
      Me.Label78.Text = "Comune:"
      '
      'Label79
      '
      Me.Label79.Location = New System.Drawing.Point(19, 94)
      Me.Label79.Name = "Label79"
      Me.Label79.Size = New System.Drawing.Size(78, 19)
      Me.Label79.TabIndex = 8
      Me.Label79.Tag = ""
      Me.Label79.Text = "CAP:"
      '
      'eui_txtCcStabileOrgComune
      '
      Me.eui_txtCcStabileOrgComune.Id = "0b38f99d-de8f-4167-bd84-20ad28cf53f9"
      Me.eui_txtCcStabileOrgComune.Location = New System.Drawing.Point(114, 128)
      Me.eui_txtCcStabileOrgComune.MaxLength = 60
      Me.eui_txtCcStabileOrgComune.Name = "eui_txtCcStabileOrgComune"
      Me.eui_txtCcStabileOrgComune.Size = New System.Drawing.Size(239, 21)
      Me.eui_txtCcStabileOrgComune.TabIndex = 3
      Me.eui_txtCcStabileOrgComune.TextEditorWidth = 233
      '
      'eui_txtCcStabileOrgCAP
      '
      Me.eui_txtCcStabileOrgCAP.Id = "500d78d4-3f07-4507-a87b-9d7133b63085"
      Me.eui_txtCcStabileOrgCAP.Location = New System.Drawing.Point(113, 92)
      Me.eui_txtCcStabileOrgCAP.MaxLength = 5
      Me.eui_txtCcStabileOrgCAP.Name = "eui_txtCcStabileOrgCAP"
      Me.eui_txtCcStabileOrgCAP.Size = New System.Drawing.Size(110, 21)
      Me.eui_txtCcStabileOrgCAP.TabIndex = 2
      Me.eui_txtCcStabileOrgCAP.TextEditorWidth = 104
      '
      'eui_txtCcStabileOrgIndirizzo
      '
      Me.eui_txtCcStabileOrgIndirizzo.Id = "e2a8b1b8-ac83-4a2f-9f59-97f98fcf69ec"
      Me.eui_txtCcStabileOrgIndirizzo.Location = New System.Drawing.Point(113, 23)
      Me.eui_txtCcStabileOrgIndirizzo.MaxLength = 60
      Me.eui_txtCcStabileOrgIndirizzo.Name = "eui_txtCcStabileOrgIndirizzo"
      Me.eui_txtCcStabileOrgIndirizzo.Size = New System.Drawing.Size(240, 21)
      Me.eui_txtCcStabileOrgIndirizzo.TabIndex = 0
      Me.eui_txtCcStabileOrgIndirizzo.TextEditorWidth = 234
      '
      'eui_txtCcStabileOrgNumeroCivico
      '
      Me.eui_txtCcStabileOrgNumeroCivico.Id = "9c61c352-fa8b-41e9-8137-8ea26aa3ac28"
      Me.eui_txtCcStabileOrgNumeroCivico.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCcStabileOrgNumeroCivico.MaxLength = 8
      Me.eui_txtCcStabileOrgNumeroCivico.Name = "eui_txtCcStabileOrgNumeroCivico"
      Me.eui_txtCcStabileOrgNumeroCivico.Size = New System.Drawing.Size(110, 21)
      Me.eui_txtCcStabileOrgNumeroCivico.TabIndex = 1
      Me.eui_txtCcStabileOrgNumeroCivico.TextEditorWidth = 104
      '
      'Label80
      '
      Me.Label80.Location = New System.Drawing.Point(19, 57)
      Me.Label80.Name = "Label80"
      Me.Label80.Size = New System.Drawing.Size(76, 19)
      Me.Label80.TabIndex = 2
      Me.Label80.Text = "Numero civico:"
      '
      'Label81
      '
      Me.Label81.Location = New System.Drawing.Point(19, 25)
      Me.Label81.Name = "Label81"
      Me.Label81.Size = New System.Drawing.Size(76, 19)
      Me.Label81.TabIndex = 0
      Me.Label81.Text = "Indirizzo:"
      '
      'TabPage20
      '
      Me.TabPage20.ActiveControl = Nothing
      Me.TabPage20.Controls.Add(Me.GroupBox18)
      Me.TabPage20.Controls.Add(Me.GroupBox19)
      Me.TabPage20.KeyTip = Nothing
      Me.TabPage20.Name = "TabPage20"
      Me.TabPage20.Size = New System.Drawing.Size(780, 397)
      Me.TabPage20.TabIndex = 3
      Me.TabPage20.Text = "Rappresentante Fiscale"
      '
      'GroupBox18
      '
      Me.GroupBox18.Controls.Add(Me.Label85)
      Me.GroupBox18.Controls.Add(Me.eui_txtCcRfCognome)
      Me.GroupBox18.Controls.Add(Me.eui_txtCcRfDenominazione)
      Me.GroupBox18.Controls.Add(Me.eui_txtCcRfNome)
      Me.GroupBox18.Controls.Add(Me.Label86)
      Me.GroupBox18.Controls.Add(Me.Label87)
      Me.GroupBox18.Id = "f97eb022-37ec-427a-9f38-b2f7512da93c"
      Me.GroupBox18.Location = New System.Drawing.Point(12, 127)
      Me.GroupBox18.Name = "GroupBox18"
      Me.GroupBox18.Size = New System.Drawing.Size(381, 135)
      Me.GroupBox18.TabIndex = 13
      Me.GroupBox18.Text = "Anagrafica"
      '
      'Label85
      '
      Me.Label85.Location = New System.Drawing.Point(19, 94)
      Me.Label85.Name = "Label85"
      Me.Label85.Size = New System.Drawing.Size(78, 19)
      Me.Label85.TabIndex = 8
      Me.Label85.Text = "Cognome:"
      '
      'eui_txtCcRfCognome
      '
      Me.eui_txtCcRfCognome.Id = "bc2fd1dd-c9bf-4077-a5db-c9df797bbf82"
      Me.eui_txtCcRfCognome.Location = New System.Drawing.Point(113, 92)
      Me.eui_txtCcRfCognome.MaxLength = 60
      Me.eui_txtCcRfCognome.Name = "eui_txtCcRfCognome"
      Me.eui_txtCcRfCognome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcRfCognome.TabIndex = 2
      Me.eui_txtCcRfCognome.TextEditorWidth = 195
      '
      'eui_txtCcRfDenominazione
      '
      Me.eui_txtCcRfDenominazione.Id = "05038dc0-dbe5-41c9-8513-3116e1c83ca9"
      Me.eui_txtCcRfDenominazione.Location = New System.Drawing.Point(113, 23)
      Me.eui_txtCcRfDenominazione.MaxLength = 80
      Me.eui_txtCcRfDenominazione.Name = "eui_txtCcRfDenominazione"
      Me.eui_txtCcRfDenominazione.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcRfDenominazione.TabIndex = 0
      Me.eui_txtCcRfDenominazione.TextEditorWidth = 195
      '
      'eui_txtCcRfNome
      '
      Me.eui_txtCcRfNome.Id = "7151a3b6-830f-4984-aaa5-bae7b06721ce"
      Me.eui_txtCcRfNome.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCcRfNome.MaxLength = 60
      Me.eui_txtCcRfNome.Name = "eui_txtCcRfNome"
      Me.eui_txtCcRfNome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcRfNome.TabIndex = 1
      Me.eui_txtCcRfNome.TextEditorWidth = 195
      '
      'Label86
      '
      Me.Label86.Location = New System.Drawing.Point(19, 57)
      Me.Label86.Name = "Label86"
      Me.Label86.Size = New System.Drawing.Size(131, 19)
      Me.Label86.TabIndex = 2
      Me.Label86.Text = "Nome:"
      '
      'Label87
      '
      Me.Label87.Location = New System.Drawing.Point(19, 25)
      Me.Label87.Name = "Label87"
      Me.Label87.Size = New System.Drawing.Size(76, 19)
      Me.Label87.TabIndex = 0
      Me.Label87.Text = "Denominazione:"
      '
      'GroupBox19
      '
      Me.GroupBox19.Controls.Add(Me.eui_txtCcRfIdCodice)
      Me.GroupBox19.Controls.Add(Me.Label88)
      Me.GroupBox19.Controls.Add(Me.eui_cmbCcRfIdPaese)
      Me.GroupBox19.Controls.Add(Me.Label89)
      Me.GroupBox19.Id = "bc4f4e63-6e6c-4761-8759-a915e7d573e5"
      Me.GroupBox19.Location = New System.Drawing.Point(12, 12)
      Me.GroupBox19.Name = "GroupBox19"
      Me.GroupBox19.Size = New System.Drawing.Size(381, 100)
      Me.GroupBox19.TabIndex = 12
      Me.GroupBox19.Text = "Id Fiscale IVA"
      '
      'eui_txtCcRfIdCodice
      '
      Me.eui_txtCcRfIdCodice.Id = "d6743b80-4caf-45c5-ae24-dd2da41a5a87"
      Me.eui_txtCcRfIdCodice.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtCcRfIdCodice.MaxLength = 28
      Me.eui_txtCcRfIdCodice.Name = "eui_txtCcRfIdCodice"
      Me.eui_txtCcRfIdCodice.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtCcRfIdCodice.TabIndex = 1
      Me.eui_txtCcRfIdCodice.TextEditorWidth = 195
      '
      'Label88
      '
      Me.Label88.Location = New System.Drawing.Point(19, 57)
      Me.Label88.Name = "Label88"
      Me.Label88.Size = New System.Drawing.Size(131, 19)
      Me.Label88.TabIndex = 2
      Me.Label88.Text = "Partita IVA:"
      '
      'eui_cmbCcRfIdPaese
      '
      Me.eui_cmbCcRfIdPaese.Editable = False
      Me.eui_cmbCcRfIdPaese.FormattingEnabled = False
      Me.eui_cmbCcRfIdPaese.Id = "48cf304a-feb5-4f62-b50c-40ab3a755ed8"
      Me.eui_cmbCcRfIdPaese.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbCcRfIdPaese.Location = New System.Drawing.Point(113, 23)
      Me.eui_cmbCcRfIdPaese.Name = "eui_cmbCcRfIdPaese"
      Me.eui_cmbCcRfIdPaese.Size = New System.Drawing.Size(201, 21)
      Me.eui_cmbCcRfIdPaese.TabIndex = 0
      Me.eui_cmbCcRfIdPaese.TextEditorWidth = 182
      '
      'Label89
      '
      Me.Label89.Location = New System.Drawing.Point(19, 25)
      Me.Label89.Name = "Label89"
      Me.Label89.Size = New System.Drawing.Size(50, 19)
      Me.Label89.TabIndex = 0
      Me.Label89.Text = "Paese:"
      '
      'TabPage9
      '
      Me.TabPage9.ActiveControl = Nothing
      Me.TabPage9.Controls.Add(Me.GroupBox15)
      Me.TabPage9.Controls.Add(Me.eui_txtTiSeCodiceFiscale)
      Me.TabPage9.Controls.Add(Me.Label72)
      Me.TabPage9.Controls.Add(Me.GroupBox16)
      Me.TabPage9.KeyTip = Nothing
      Me.TabPage9.Name = "TabPage9"
      Me.TabPage9.Size = New System.Drawing.Size(798, 438)
      Me.TabPage9.TabIndex = 4
      Me.TabPage9.Text = "Terzo Intermediario o Soggetto Emittente"
      '
      'GroupBox15
      '
      Me.GroupBox15.Controls.Add(Me.Label67)
      Me.GroupBox15.Controls.Add(Me.Label68)
      Me.GroupBox15.Controls.Add(Me.Label69)
      Me.GroupBox15.Controls.Add(Me.eui_txtTiSeCodiceEORI)
      Me.GroupBox15.Controls.Add(Me.eui_txtTiSeTitolo)
      Me.GroupBox15.Controls.Add(Me.eui_txtTiSeCognome)
      Me.GroupBox15.Controls.Add(Me.eui_txtTiSeDenominazione)
      Me.GroupBox15.Controls.Add(Me.eui_txtTiSeNome)
      Me.GroupBox15.Controls.Add(Me.Label70)
      Me.GroupBox15.Controls.Add(Me.Label71)
      Me.GroupBox15.Id = "5b79e596-fb20-4a54-9549-e14bb1a21de9"
      Me.GroupBox15.Location = New System.Drawing.Point(9, 162)
      Me.GroupBox15.Name = "GroupBox15"
      Me.GroupBox15.Size = New System.Drawing.Size(381, 203)
      Me.GroupBox15.TabIndex = 14
      Me.GroupBox15.Text = "Anagrafica"
      '
      'Label67
      '
      Me.Label67.Location = New System.Drawing.Point(19, 165)
      Me.Label67.Name = "Label67"
      Me.Label67.Size = New System.Drawing.Size(78, 19)
      Me.Label67.TabIndex = 10
      Me.Label67.Text = "Codice EORI:"
      '
      'Label68
      '
      Me.Label68.Location = New System.Drawing.Point(19, 130)
      Me.Label68.Name = "Label68"
      Me.Label68.Size = New System.Drawing.Size(78, 19)
      Me.Label68.TabIndex = 9
      Me.Label68.Text = "Titolo:"
      '
      'Label69
      '
      Me.Label69.Location = New System.Drawing.Point(19, 94)
      Me.Label69.Name = "Label69"
      Me.Label69.Size = New System.Drawing.Size(78, 19)
      Me.Label69.TabIndex = 8
      Me.Label69.Text = "Cognome:"
      '
      'eui_txtTiSeCodiceEORI
      '
      Me.eui_txtTiSeCodiceEORI.Id = "83a3e0a1-96b4-47eb-b95d-b24cd79a83d6"
      Me.eui_txtTiSeCodiceEORI.Location = New System.Drawing.Point(114, 163)
      Me.eui_txtTiSeCodiceEORI.MaxLength = 17
      Me.eui_txtTiSeCodiceEORI.Name = "eui_txtTiSeCodiceEORI"
      Me.eui_txtTiSeCodiceEORI.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeCodiceEORI.TabIndex = 4
      Me.eui_txtTiSeCodiceEORI.TextEditorWidth = 195
      '
      'eui_txtTiSeTitolo
      '
      Me.eui_txtTiSeTitolo.Id = "a276f51e-9af8-4075-a9c9-a16f23077ce5"
      Me.eui_txtTiSeTitolo.Location = New System.Drawing.Point(114, 128)
      Me.eui_txtTiSeTitolo.MaxLength = 10
      Me.eui_txtTiSeTitolo.Name = "eui_txtTiSeTitolo"
      Me.eui_txtTiSeTitolo.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeTitolo.TabIndex = 3
      Me.eui_txtTiSeTitolo.TextEditorWidth = 195
      '
      'eui_txtTiSeCognome
      '
      Me.eui_txtTiSeCognome.Id = "f7ef083c-cf9d-4e47-957a-2fd353017251"
      Me.eui_txtTiSeCognome.Location = New System.Drawing.Point(113, 92)
      Me.eui_txtTiSeCognome.MaxLength = 60
      Me.eui_txtTiSeCognome.Name = "eui_txtTiSeCognome"
      Me.eui_txtTiSeCognome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeCognome.TabIndex = 2
      Me.eui_txtTiSeCognome.TextEditorWidth = 195
      '
      'eui_txtTiSeDenominazione
      '
      Me.eui_txtTiSeDenominazione.Id = "5a5e37e5-188f-4bfd-bf17-d3bcdb30cf6a"
      Me.eui_txtTiSeDenominazione.Location = New System.Drawing.Point(113, 23)
      Me.eui_txtTiSeDenominazione.MaxLength = 80
      Me.eui_txtTiSeDenominazione.Name = "eui_txtTiSeDenominazione"
      Me.eui_txtTiSeDenominazione.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeDenominazione.TabIndex = 0
      Me.eui_txtTiSeDenominazione.TextEditorWidth = 195
      '
      'eui_txtTiSeNome
      '
      Me.eui_txtTiSeNome.Id = "9cfedeb5-e462-460d-96eb-56c5e39ab723"
      Me.eui_txtTiSeNome.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtTiSeNome.MaxLength = 60
      Me.eui_txtTiSeNome.Name = "eui_txtTiSeNome"
      Me.eui_txtTiSeNome.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeNome.TabIndex = 1
      Me.eui_txtTiSeNome.TextEditorWidth = 195
      '
      'Label70
      '
      Me.Label70.Location = New System.Drawing.Point(19, 57)
      Me.Label70.Name = "Label70"
      Me.Label70.Size = New System.Drawing.Size(131, 19)
      Me.Label70.TabIndex = 2
      Me.Label70.Text = "Nome:"
      '
      'Label71
      '
      Me.Label71.Location = New System.Drawing.Point(19, 25)
      Me.Label71.Name = "Label71"
      Me.Label71.Size = New System.Drawing.Size(76, 19)
      Me.Label71.TabIndex = 0
      Me.Label71.Text = "Denominazione:"
      '
      'eui_txtTiSeCodiceFiscale
      '
      Me.eui_txtTiSeCodiceFiscale.Id = "9e8059d7-7a99-4c0f-9760-bfe4ae3dc4a9"
      Me.eui_txtTiSeCodiceFiscale.Location = New System.Drawing.Point(123, 127)
      Me.eui_txtTiSeCodiceFiscale.MaxLength = 16
      Me.eui_txtTiSeCodiceFiscale.Name = "eui_txtTiSeCodiceFiscale"
      Me.eui_txtTiSeCodiceFiscale.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeCodiceFiscale.TabIndex = 0
      Me.eui_txtTiSeCodiceFiscale.TextEditorWidth = 195
      '
      'Label72
      '
      Me.Label72.Location = New System.Drawing.Point(25, 129)
      Me.Label72.Name = "Label72"
      Me.Label72.Size = New System.Drawing.Size(87, 19)
      Me.Label72.TabIndex = 12
      Me.Label72.Text = "Codice fiscale:"
      '
      'GroupBox16
      '
      Me.GroupBox16.Controls.Add(Me.eui_txtTiSeIdCodice)
      Me.GroupBox16.Controls.Add(Me.Label73)
      Me.GroupBox16.Controls.Add(Me.eui_cmbTiSeIdPaese)
      Me.GroupBox16.Controls.Add(Me.Label74)
      Me.GroupBox16.Id = "01e0f9f4-ce5b-46e1-99dc-dbcd4bf60cfe"
      Me.GroupBox16.Location = New System.Drawing.Point(9, 12)
      Me.GroupBox16.Name = "GroupBox16"
      Me.GroupBox16.Size = New System.Drawing.Size(381, 100)
      Me.GroupBox16.TabIndex = 11
      Me.GroupBox16.Text = "Id Fiscale IVA"
      '
      'eui_txtTiSeIdCodice
      '
      Me.eui_txtTiSeIdCodice.Id = "3d17eb93-9055-469c-b73b-64adf70c8b77"
      Me.eui_txtTiSeIdCodice.Location = New System.Drawing.Point(113, 57)
      Me.eui_txtTiSeIdCodice.MaxLength = 28
      Me.eui_txtTiSeIdCodice.Name = "eui_txtTiSeIdCodice"
      Me.eui_txtTiSeIdCodice.Size = New System.Drawing.Size(201, 21)
      Me.eui_txtTiSeIdCodice.TabIndex = 1
      Me.eui_txtTiSeIdCodice.TextEditorWidth = 195
      '
      'Label73
      '
      Me.Label73.Location = New System.Drawing.Point(19, 57)
      Me.Label73.Name = "Label73"
      Me.Label73.Size = New System.Drawing.Size(131, 19)
      Me.Label73.TabIndex = 2
      Me.Label73.Text = "Partita IVA:"
      '
      'eui_cmbTiSeIdPaese
      '
      Me.eui_cmbTiSeIdPaese.Editable = False
      Me.eui_cmbTiSeIdPaese.FormattingEnabled = False
      Me.eui_cmbTiSeIdPaese.Id = "8a81ecb8-0b4f-4a40-b81b-0bb6f56365f8"
      Me.eui_cmbTiSeIdPaese.Items.AddRange(New Object() {" ", "AD Andorra", "AE Emirati Arabi Uniti", "AF Afghanistan", "AG Antigua e Barbuda", "AI Anguilla", "AL Albania", "AM Armenia", "AO Angola", "AQ Antartide ", "AR Argentina", "AS Samoa Americane", "AT Austria", "AU Australia", "AW Aruba", "AX Isole Åland", "AZ Azerbaigian", "BA Bosnia ed Erzegovina", "BB Barbados", "BD Bangladesh", "BE Belgio", "BF Burkina Faso", "BG Bulgaria", "BH Bahrein", "BI Burundi", "BJ Benin", "BL Saint-Barthélemy", "BM Bermuda", "BN Brunei", "BO Bolivia", "BQ Isole BES", "BR Brasile", "BS Bahamas", "BT Bhutan", "BV Isola Bouvet", "BW Botswana", "BY Bielorussia", "BZ Belize", "CA Canada", "CC Isole Cocos e Keeling", "CD Repubblica Democratica del Congo", "CF Repubblica Centrafricana", "CG Repubblica del Congo", "CH Svizzera", "CI Costa d'Avorio", "CK Isole Cook", "CL Cile", "CM Camerun", "CN Cina", "CO Colombia", "CR Costa Rica", "CU Cuba", "CV Capo Verde", "CW Curaçao", "CX Isola del Natale", "CY Cipro", "CZ Repubblica Ceca", "DE Germania", "DJ Gibuti", "DK Danimarca", "DM Dominica", "DO Repubblica Dominicana", "DZ Algeria", "EC Ecuador", "EE Estonia", "EG Egitto", "EH Sahara Occidentale", "ER Eritrea", "ES Spagna", "ET Etiopia", "FI Finlandia", "FJ Figi", "FK Isole Falkland", "FM Stati Federati di Micronesia", "FO Isole Fær Øer", "FR Francia", "GA Gabon", "GB Regno Unito", "GD Grenada", "GE Georgia", "GF Guyana francese", "GG Guernsey", "GH Ghana", "GI Gibilterra", "GL Groenlandia", "GM Gambia", "GN Guinea", "GP Guadalupa", "GQ Guinea Equatoriale", "GR Grecia", "GS Georgia del Sud e isole Sandwich meridionali", "GT Guatemala", "GU Guam", "GW Guinea-Bissau", "GY Guyana", "HK Hong Kong", "HM Isole Heard e McDonald", "HN Honduras", "HR Croazia", "HT Haiti", "HU Ungheria", "ID Indonesia", "IE Irlanda", "IL Israele", "IM Isola di Man", "IN India", "IO Territori Britannici dell'Oceano Indiano", "IQ Iraq", "IR Iran", "IS Islanda", "IT Italia", "JE Jersey", "JM Giamaica", "JO Giordania", "JP Giappone", "KE Kenya", "KG Kirghizistan", "KH Cambogia", "KI Kiribati", "KM Comore", "KN Saint Kitts e Nevis", "KP Corea del Nord", "KR Corea del Sud", "KW Kuwait", "KY Isole Cayman", "KZ Kazakistan", "LA Laos", "LB Libano", "LC Santa Lucia", "LI Liechtenstein", "LK Sri Lanka", "LR Liberia", "LS Lesotho", "LT Lituania", "LU Lussemburgo", "LV Lettonia", "LY Libia", "MA Marocco", "MC Monaco", "MD Moldavia", "ME Montenegro", "MF Saint-Martin", "MG Madagascar", "MH Isole Marshall", "MK Macedonia", "ML Mali", "MM Birmania", "MN Mongolia", "MO Macao", "MP Isole Marianne Settentrionali", "MQ Martinica", "MR Mauritania", "MS Montserrat", "MT Malta", "MU Mauritius", "MV Maldive", "MW Malawi", "MX Messico", "MY Malaysia", "MZ Mozambico", "NA Namibia", "NC Nuova Caledonia", "NE Niger", "NF Isola Norfolk", "NG Nigeria", "NI Nicaragua", "NL Paesi Bassi", "NO Norvegia", "NP Nepal", "NR Nauru", "NU Niue", "NZ Nuova Zelanda", "OM Oman", "PA Panama", "PE Perù", "PF Polinesia Francese", "PG Papua Nuova Guinea", "PH Filippine", "PK Pakistan", "PL Polonia", "PM Saint-Pierre e Miquelon", "PN Isole Pitcairn", "PR Porto Rico", "PS Stato di Palestina", "PT Portogallo", "PW Palau", "PY Paraguay", "QA Qatar", "RE Riunione", "RO Romania", "RS Serbia", "RU Russia", "RW Ruanda", "SA Arabia Saudita", "SB Isole Salomone", "SC Seychelles", "SD Sudan", "SE Svezia", "SG Singapore", "SH Sant'Elena, Isola di Ascensione e Tristan da Cunha", "SI Slovenia", "SJ Svalbard e Jan Mayen", "SK Slovacchia", "SL Sierra Leone", "SM San Marino", "SN Senegal", "SO Somalia", "SR Suriname", "SS Sudan del Sud", "ST São Tomé e Príncipe", "SV El Salvador", "SX Sint Maarten", "SY Siria", "SZ Swaziland", "TC Isole Turks e Caicos", "TD Ciad", "TF Territori Francesi del Sud", "TG Togo", "TH Thailandia", "TJ Tagikistan", "TK Tokelau", "TL Timor Est", "TM Turkmenistan", "TN Tunisia", "TO Tonga", "TR Turchia", "TT Trinidad e Tobago", "TV Tuvalu", "TW Repubblica di Cina", "TZ Tanzania", "UA Ucraina", "UG Uganda", "UM Isole minori esterne degli Stati Uniti", "US Stati Uniti d'America", "UY Uruguay", "UZ Uzbekistan", "VA Città del Vaticano", "VC Saint Vincent e Grenadine", "VE Venezuela", "VG Isole Vergini britanniche", "VI Isole Vergini americane", "VN Vietnam", "VU Vanuatu", "WF Wallis e Futuna", "WS Samoa", "YE Yemen", "YT Mayotte", "ZA Sudafrica", "ZM Zambia", "ZW Zimbabwe"})
      Me.eui_cmbTiSeIdPaese.Location = New System.Drawing.Point(113, 23)
      Me.eui_cmbTiSeIdPaese.Name = "eui_cmbTiSeIdPaese"
      Me.eui_cmbTiSeIdPaese.Size = New System.Drawing.Size(201, 21)
      Me.eui_cmbTiSeIdPaese.TabIndex = 0
      Me.eui_cmbTiSeIdPaese.TextEditorWidth = 182
      '
      'Label74
      '
      Me.Label74.Location = New System.Drawing.Point(19, 25)
      Me.Label74.Name = "Label74"
      Me.Label74.Size = New System.Drawing.Size(50, 19)
      Me.Label74.TabIndex = 0
      Me.Label74.Text = "Paese:"
      '
      'TabPage10
      '
      Me.TabPage10.ActiveControl = Nothing
      Me.TabPage10.Controls.Add(Me.eui_cmbSoggettoEmittente)
      Me.TabPage10.Controls.Add(Me.Label75)
      Me.TabPage10.KeyTip = Nothing
      Me.TabPage10.Name = "TabPage10"
      Me.TabPage10.Size = New System.Drawing.Size(798, 438)
      Me.TabPage10.TabIndex = 5
      Me.TabPage10.Text = "Soggetto Emittente"
      '
      'eui_cmbSoggettoEmittente
      '
      Me.eui_cmbSoggettoEmittente.Editable = False
      Me.eui_cmbSoggettoEmittente.FormattingEnabled = False
      Me.eui_cmbSoggettoEmittente.Id = "563fb4f7-645a-4e63-8634-86c9d5aabb58"
      Me.eui_cmbSoggettoEmittente.Items.AddRange(New Object() {"CC Cessionario / Committente", "TZ Terzo"})
      Me.eui_cmbSoggettoEmittente.Location = New System.Drawing.Point(121, 13)
      Me.eui_cmbSoggettoEmittente.Name = "eui_cmbSoggettoEmittente"
      Me.eui_cmbSoggettoEmittente.Size = New System.Drawing.Size(141, 21)
      Me.eui_cmbSoggettoEmittente.TabIndex = 0
      Me.eui_cmbSoggettoEmittente.TextEditorWidth = 122
      '
      'Label75
      '
      Me.Label75.Location = New System.Drawing.Point(15, 16)
      Me.Label75.Name = "Label75"
      Me.Label75.Size = New System.Drawing.Size(92, 19)
      Me.Label75.TabIndex = 20
      Me.Label75.Text = "Soggetto emittente:"
      '
      'eui_tpConvalida
      '
      Me.eui_tpConvalida.ActiveControl = Nothing
      Me.eui_tpConvalida.Controls.Add(Me.eui_cmdConvalidaWeb)
      Me.eui_tpConvalida.Controls.Add(Me.eui_cmdSalvaErrori)
      Me.eui_tpConvalida.Controls.Add(Me.eui_cmdConvalida)
      Me.eui_tpConvalida.Controls.Add(Me.eui_txtConvalida)
      Me.eui_tpConvalida.KeyTip = Nothing
      Me.eui_tpConvalida.Name = "eui_tpConvalida"
      Me.eui_tpConvalida.Size = New System.Drawing.Size(812, 469)
      Me.eui_tpConvalida.TabIndex = 1
      Me.eui_tpConvalida.Text = "Convalida"
      '
      'eui_cmdConvalidaWeb
      '
      Me.eui_cmdConvalidaWeb.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdConvalidaWeb.Id = "4e933d6d-de0d-4317-b0dd-c71a4214d450"
      Me.eui_cmdConvalidaWeb.Location = New System.Drawing.Point(521, 426)
      Me.eui_cmdConvalidaWeb.Name = "eui_cmdConvalidaWeb"
      Me.eui_cmdConvalidaWeb.Size = New System.Drawing.Size(165, 32)
      Me.eui_cmdConvalidaWeb.TabIndex = 2
      Me.eui_cmdConvalidaWeb.Text = "Convalida su fatturapa.gov.it"
      '
      'eui_cmdSalvaErrori
      '
      Me.eui_cmdSalvaErrori.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdSalvaErrori.Id = "b3876e90-9e2d-438a-ab42-9cb94349f33f"
      Me.eui_cmdSalvaErrori.Location = New System.Drawing.Point(695, 426)
      Me.eui_cmdSalvaErrori.Name = "eui_cmdSalvaErrori"
      Me.eui_cmdSalvaErrori.Size = New System.Drawing.Size(110, 32)
      Me.eui_cmdSalvaErrori.TabIndex = 3
      Me.eui_cmdSalvaErrori.Text = "Salva lista errori"
      '
      'eui_cmdConvalida
      '
      Me.eui_cmdConvalida.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdConvalida.Id = "f06cd621-78bb-492f-aebb-74b0711187e1"
      Me.eui_cmdConvalida.Location = New System.Drawing.Point(402, 426)
      Me.eui_cmdConvalida.Name = "eui_cmdConvalida"
      Me.eui_cmdConvalida.Size = New System.Drawing.Size(110, 32)
      Me.eui_cmdConvalida.TabIndex = 1
      Me.eui_cmdConvalida.Text = "Convalida"
      '
      'eui_txtConvalida
      '
      Me.eui_txtConvalida.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtConvalida.Id = "fbd1d89a-a47f-4e31-b0e7-81fc65da197c"
      Me.eui_txtConvalida.Location = New System.Drawing.Point(1, 0)
      Me.eui_txtConvalida.Multiline = True
      Me.eui_txtConvalida.Name = "eui_txtConvalida"
      Me.eui_txtConvalida.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.eui_txtConvalida.Size = New System.Drawing.Size(810, 416)
      Me.eui_txtConvalida.TabIndex = 0
      Me.eui_txtConvalida.TextEditorWidth = 804
      Me.eui_txtConvalida.WordWrap = False
      '
      'TabPage3
      '
      Me.TabPage3.ActiveControl = Nothing
      Me.TabPage3.Controls.Add(Me.WebBrowser1)
      Me.TabPage3.Controls.Add(Me.eui_cmdCopiaPercorso)
      Me.TabPage3.KeyTip = Nothing
      Me.TabPage3.Name = "TabPage3"
      Me.TabPage3.Size = New System.Drawing.Size(812, 469)
      Me.TabPage3.TabIndex = 2
      Me.TabPage3.Text = "XML"
      '
      'eui_cmdCopiaPercorso
      '
      Me.eui_cmdCopiaPercorso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdCopiaPercorso.Id = "60ebbd95-62c4-4451-90f1-4270387cc16d"
      Me.eui_cmdCopiaPercorso.Location = New System.Drawing.Point(694, 430)
      Me.eui_cmdCopiaPercorso.Name = "eui_cmdCopiaPercorso"
      Me.eui_cmdCopiaPercorso.ScreenTip.Caption = "Copia percorso"
      Me.eui_cmdCopiaPercorso.ScreenTip.Text = "Copia il percorso del file XML negli appunti."
      Me.eui_cmdCopiaPercorso.Size = New System.Drawing.Size(110, 32)
      Me.eui_cmdCopiaPercorso.TabIndex = 1
      Me.eui_cmdCopiaPercorso.Text = "Copia percorso"
      '
      'TabPage21
      '
      Me.TabPage21.ActiveControl = Nothing
      Me.TabPage21.Controls.Add(Me.eui_txtFormatoTxt)
      Me.TabPage21.Controls.Add(Me.eui_cmdApriFileTxt)
      Me.TabPage21.KeyTip = Nothing
      Me.TabPage21.Name = "TabPage21"
      Me.TabPage21.Size = New System.Drawing.Size(812, 469)
      Me.TabPage21.TabIndex = 4
      Me.TabPage21.Text = "TXT"
      '
      'eui_txtFormatoTxt
      '
      Me.eui_txtFormatoTxt.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtFormatoTxt.Id = "329cfc75-ea3b-4e9e-9bf1-a485dd548600"
      Me.eui_txtFormatoTxt.Location = New System.Drawing.Point(1, 1)
      Me.eui_txtFormatoTxt.Multiline = True
      Me.eui_txtFormatoTxt.Name = "eui_txtFormatoTxt"
      Me.eui_txtFormatoTxt.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.eui_txtFormatoTxt.Size = New System.Drawing.Size(810, 425)
      Me.eui_txtFormatoTxt.TabIndex = 4
      Me.eui_txtFormatoTxt.TextEditorWidth = 806
      Me.eui_txtFormatoTxt.WordWrap = False
      '
      'eui_cmdApriFileTxt
      '
      Me.eui_cmdApriFileTxt.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdApriFileTxt.Id = "396425fd-fa39-42d2-8af8-2039c1104cdd"
      Me.eui_cmdApriFileTxt.Location = New System.Drawing.Point(694, 430)
      Me.eui_cmdApriFileTxt.Name = "eui_cmdApriFileTxt"
      Me.eui_cmdApriFileTxt.ScreenTip.Caption = "Salva"
      Me.eui_cmdApriFileTxt.ScreenTip.Text = "Salva il codice XML in un file di testo TXT."
      Me.eui_cmdApriFileTxt.Size = New System.Drawing.Size(110, 32)
      Me.eui_cmdApriFileTxt.TabIndex = 3
      Me.eui_cmdApriFileTxt.Text = "Apri"
      '
      'TabPage4
      '
      Me.TabPage4.ActiveControl = Nothing
      Me.TabPage4.Controls.Add(Me.eui_cmdAnteprimaWeb)
      Me.TabPage4.Controls.Add(Me.Label2)
      Me.TabPage4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.TabPage4.ForeColor = System.Drawing.SystemColors.ControlDark
      Me.TabPage4.KeyTip = Nothing
      Me.TabPage4.Name = "TabPage4"
      Me.TabPage4.Size = New System.Drawing.Size(812, 469)
      Me.TabPage4.TabIndex = 3
      Me.TabPage4.Text = "HTML - (Anteprima)"
      '
      'eui_cmdAnteprimaWeb
      '
      Me.eui_cmdAnteprimaWeb.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdAnteprimaWeb.Id = "bd587cbd-9373-4999-8beb-bb10b825c807"
      Me.eui_cmdAnteprimaWeb.Location = New System.Drawing.Point(639, 425)
      Me.eui_cmdAnteprimaWeb.Name = "eui_cmdAnteprimaWeb"
      Me.eui_cmdAnteprimaWeb.Size = New System.Drawing.Size(165, 32)
      Me.eui_cmdAnteprimaWeb.TabIndex = 0
      Me.eui_cmdAnteprimaWeb.Text = "Anteprima su fatturapa.gov.it"
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Silver
      Me.Label2.Location = New System.Drawing.Point(265, 221)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(285, 25)
      Me.Label2.TabIndex = 16
      Me.Label2.Text = "Anteprima non disponibile"
      '
      'eui_cmdApriCartella
      '
      Me.eui_cmdApriCartella.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdApriCartella.Id = "26a292a3-ef05-45a1-8f74-0996002fd2fc"
      Me.eui_cmdApriCartella.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdApriCartella.Location = New System.Drawing.Point(832, 103)
      Me.eui_cmdApriCartella.Name = "eui_cmdApriCartella"
      Me.eui_cmdApriCartella.ScreenTip.Caption = "Apri cartella"
      Me.eui_cmdApriCartella.ScreenTip.Text = "Apre la cartella contenente il file xml."
      Me.eui_cmdApriCartella.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdApriCartella.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdApriCartella.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdApriCartella.TabIndex = 1
      Me.eui_cmdApriCartella.Text = "Apri cartella..."
      Me.eui_cmdApriCartella.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdEsporta
      '
      Me.eui_cmdEsporta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdEsporta.Id = "5d8dd0e2-1657-41ae-af95-d93b67be2536"
      Me.eui_cmdEsporta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdEsporta.Location = New System.Drawing.Point(832, 28)
      Me.eui_cmdEsporta.Name = "eui_cmdEsporta"
      Me.eui_cmdEsporta.ScreenTip.Caption = "Esporta in XML"
      Me.eui_cmdEsporta.ScreenTip.Text = "Esporta il documento in formato XML."
      Me.eui_cmdEsporta.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdEsporta.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdEsporta.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdEsporta.TabIndex = 0
      Me.eui_cmdEsporta.Text = "Esporta in XML"
      Me.eui_cmdEsporta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdInvia
      '
      Me.eui_cmdInvia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdInvia.Id = "e098d816-fac2-4c14-bb8e-ded39b6e9ceb"
      Me.eui_cmdInvia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdInvia.Location = New System.Drawing.Point(832, 178)
      Me.eui_cmdInvia.Name = "eui_cmdInvia"
      Me.eui_cmdInvia.ScreenTip.Caption = "Invia"
      Me.eui_cmdInvia.ScreenTip.Text = "Invia il file xml al servizio SDI tramite e-mail. "
      Me.eui_cmdInvia.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdInvia.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdInvia.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdInvia.TabIndex = 2
      Me.eui_cmdInvia.Text = "Invia"
      Me.eui_cmdInvia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'StatusBarPane5
      '
      Me.StatusBarPane5.Controls.Add(Me.eui_lblStatoDataDoc)
      Me.StatusBarPane5.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarPane5.Location = New System.Drawing.Point(87, 0)
      Me.StatusBarPane5.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane5.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane5.Name = "StatusBarPane5"
      Me.StatusBarPane5.Size = New System.Drawing.Size(20, 22)
      Me.StatusBarPane5.TabIndex = 1
      '
      'eui_lblStatoDataDoc
      '
      Me.eui_lblStatoDataDoc.Location = New System.Drawing.Point(0, 4)
      Me.eui_lblStatoDataDoc.Name = "eui_lblStatoDataDoc"
      Me.eui_lblStatoDataDoc.ScreenTip.Text = "Data documento"
      Me.eui_lblStatoDataDoc.Size = New System.Drawing.Size(58, 13)
      Me.eui_lblStatoDataDoc.TabIndex = 0
      Me.eui_lblStatoDataDoc.Text = "15/08/2015"
      '
      'StatusBarPane1
      '
      Me.StatusBarPane1.Controls.Add(Me.eui_lblStatoClienteDoc)
      Me.StatusBarPane1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarPane1.Location = New System.Drawing.Point(185, 0)
      Me.StatusBarPane1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane1.Name = "StatusBarPane1"
      Me.StatusBarPane1.Size = New System.Drawing.Size(20, 22)
      Me.StatusBarPane1.TabIndex = 2
      '
      'eui_lblStatoClienteDoc
      '
      Me.eui_lblStatoClienteDoc.Location = New System.Drawing.Point(0, 4)
      Me.eui_lblStatoClienteDoc.Name = "eui_lblStatoClienteDoc"
      Me.eui_lblStatoClienteDoc.ScreenTip.Text = "Cliente intestatario"
      Me.eui_lblStatoClienteDoc.Size = New System.Drawing.Size(89, 13)
      Me.eui_lblStatoClienteDoc.TabIndex = 0
      Me.eui_lblStatoClienteDoc.Text = "Luigi Montana Spa"
      '
      'eui_cmdSalva
      '
      Me.eui_cmdSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdSalva.Id = "480f1733-d999-4c61-8154-ce920719f2af"
      Me.eui_cmdSalva.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdSalva.Location = New System.Drawing.Point(832, 286)
      Me.eui_cmdSalva.Name = "eui_cmdSalva"
      Me.eui_cmdSalva.ScreenTip.Caption = "Salva"
      Me.eui_cmdSalva.ScreenTip.Text = "Salva i dati del documento."
      Me.eui_cmdSalva.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdSalva.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdSalva.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdSalva.TabIndex = 3
      Me.eui_cmdSalva.Text = "Salva"
      Me.eui_cmdSalva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.eui_cmdSalva.Visible = False
      '
      'WebBrowser1
      '
      Me.WebBrowser1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.WebBrowser1.Location = New System.Drawing.Point(3, 1)
      Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
      Me.WebBrowser1.Name = "WebBrowser1"
      Me.WebBrowser1.Size = New System.Drawing.Size(805, 421)
      Me.WebBrowser1.TabIndex = 3
      '
      'frmFatturaElettronica
      '
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(974, 534)
      Me.Controls.Add(Me.eui_cmdSalva)
      Me.Controls.Add(Me.eui_cmdInvia)
      Me.Controls.Add(Me.eui_cmdEsporta)
      Me.Controls.Add(Me.eui_cmdApriCartella)
      Me.Controls.Add(Me.eui_tpcDocumento)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.StatusBar1)
      Me.Name = "frmFatturaElettronica"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Fattura Elettronica"
      Me.StatusBar1.ResumeLayout(False)
      Me.StatusBar1.PerformLayout()
      Me.StatusBarNotificationsArea1.ResumeLayout(False)
      Me.StatusBarNotificationsArea1.PerformLayout()
      Me.StatusBarPane2.ResumeLayout(False)
      Me.StatusBarPane2.PerformLayout()
      Me.StatusBarPane4.ResumeLayout(False)
      Me.StatusBarPane4.PerformLayout()
      Me.StatusBarControlsArea1.ResumeLayout(False)
      Me.StatusBarControlsArea1.PerformLayout()
      CType(Me.eui_tpcDocumento, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage1.ResumeLayout(False)
      CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage6.ResumeLayout(False)
      CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage11.ResumeLayout(False)
      Me.TabPage11.PerformLayout()
      Me.GroupBox5.ResumeLayout(False)
      Me.GroupBox5.PerformLayout()
      Me.GroupBox4.ResumeLayout(False)
      Me.GroupBox4.PerformLayout()
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.TabPage12.ResumeLayout(False)
      Me.GroupBox6.ResumeLayout(False)
      Me.GroupBox6.PerformLayout()
      Me.TabPage13.ResumeLayout(False)
      Me.GroupBox7.ResumeLayout(False)
      Me.GroupBox7.PerformLayout()
      Me.TabPage14.ResumeLayout(False)
      Me.GroupBox8.ResumeLayout(False)
      Me.GroupBox8.PerformLayout()
      Me.TabPage15.ResumeLayout(False)
      Me.GroupBox9.ResumeLayout(False)
      Me.GroupBox9.PerformLayout()
      Me.TabPage16.ResumeLayout(False)
      Me.TabPage16.PerformLayout()
      Me.TabPage5.ResumeLayout(False)
      Me.TabPage5.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.TabPage7.ResumeLayout(False)
      Me.TabPage7.PerformLayout()
      Me.GroupBox10.ResumeLayout(False)
      Me.GroupBox10.PerformLayout()
      Me.GroupBox11.ResumeLayout(False)
      Me.GroupBox11.PerformLayout()
      Me.TabPage8.ResumeLayout(False)
      CType(Me.TabControl3, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage17.ResumeLayout(False)
      Me.TabPage17.PerformLayout()
      Me.GroupBox12.ResumeLayout(False)
      Me.GroupBox12.PerformLayout()
      Me.GroupBox13.ResumeLayout(False)
      Me.GroupBox13.PerformLayout()
      Me.TabPage18.ResumeLayout(False)
      Me.GroupBox14.ResumeLayout(False)
      Me.GroupBox14.PerformLayout()
      Me.TabPage19.ResumeLayout(False)
      Me.GroupBox17.ResumeLayout(False)
      Me.GroupBox17.PerformLayout()
      Me.TabPage20.ResumeLayout(False)
      Me.GroupBox18.ResumeLayout(False)
      Me.GroupBox18.PerformLayout()
      Me.GroupBox19.ResumeLayout(False)
      Me.GroupBox19.PerformLayout()
      Me.TabPage9.ResumeLayout(False)
      Me.TabPage9.PerformLayout()
      Me.GroupBox15.ResumeLayout(False)
      Me.GroupBox15.PerformLayout()
      Me.GroupBox16.ResumeLayout(False)
      Me.GroupBox16.PerformLayout()
      Me.TabPage10.ResumeLayout(False)
      Me.TabPage10.PerformLayout()
      Me.eui_tpConvalida.ResumeLayout(False)
      Me.eui_tpConvalida.PerformLayout()
      Me.TabPage3.ResumeLayout(False)
      Me.TabPage21.ResumeLayout(False)
      Me.TabPage21.PerformLayout()
      Me.TabPage4.ResumeLayout(False)
      Me.TabPage4.PerformLayout()
      Me.StatusBarPane5.ResumeLayout(False)
      Me.StatusBarPane5.PerformLayout()
      Me.StatusBarPane1.ResumeLayout(False)
      Me.StatusBarPane1.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents StatusBar1 As Elegant.Ui.StatusBar
   Friend WithEvents StatusBarNotificationsArea1 As Elegant.Ui.StatusBarNotificationsArea
   Friend WithEvents StatusBarPane2 As Elegant.Ui.StatusBarPane
   Friend WithEvents StatusBarControlsArea1 As Elegant.Ui.StatusBarControlsArea
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_tpcDocumento As Elegant.Ui.TabControl
   Friend WithEvents TabPage1 As Elegant.Ui.TabPage
   Friend WithEvents eui_tpConvalida As Elegant.Ui.TabPage
   Friend WithEvents TabPage3 As Elegant.Ui.TabPage
   Friend WithEvents TabPage4 As Elegant.Ui.TabPage
   Friend WithEvents eui_cmdEsporta As Elegant.Ui.Button
   Friend WithEvents eui_cmdApriCartella As Elegant.Ui.Button
   Friend WithEvents eui_cmdSalvaErrori As Elegant.Ui.Button
   Friend WithEvents eui_cmdConvalida As Elegant.Ui.Button
   Friend WithEvents eui_txtConvalida As Elegant.Ui.TextBox
   Friend WithEvents eui_cmdCopiaPercorso As Elegant.Ui.Button
   Friend WithEvents eui_cmdInvia As Elegant.Ui.Button
   Friend WithEvents StatusBarPane5 As Elegant.Ui.StatusBarPane
   Friend WithEvents eui_lblStatoDataDoc As Elegant.Ui.Label
   Friend WithEvents StatusBarPane1 As Elegant.Ui.StatusBarPane
   Friend WithEvents eui_lblStatoClienteDoc As Elegant.Ui.Label
   Friend WithEvents eui_lblDirectoryFileXml As Elegant.Ui.Label
   Friend WithEvents StatusBarPane4 As Elegant.Ui.StatusBarPane
   Friend WithEvents TabControl1 As Elegant.Ui.TabControl
   Friend WithEvents TabPage5 As Elegant.Ui.TabPage
   Friend WithEvents TabPage6 As Elegant.Ui.TabPage
   Friend WithEvents TabPage7 As Elegant.Ui.TabPage
   Friend WithEvents TabPage8 As Elegant.Ui.TabPage
   Friend WithEvents TabPage9 As Elegant.Ui.TabPage
   Friend WithEvents TabPage10 As Elegant.Ui.TabPage
   Friend WithEvents GroupBox1 As Elegant.Ui.GroupBox
   Friend WithEvents Label1 As Elegant.Ui.Label
   Friend WithEvents eui_txtTrasmittenteIdCodice As Elegant.Ui.TextBox
   Friend WithEvents Label4 As Elegant.Ui.Label
   Friend WithEvents eui_cmbTrasmittenteIdPaese As Elegant.Ui.ComboBox
   Friend WithEvents eui_txtProgressivoInvio As Elegant.Ui.TextBox
   Friend WithEvents Label7 As Elegant.Ui.Label
   Friend WithEvents eui_txtCodiceDestinatario As Elegant.Ui.TextBox
   Friend WithEvents Label5 As Elegant.Ui.Label
   Friend WithEvents eui_cmbFormatoTrasmissione As Elegant.Ui.ComboBox
   Friend WithEvents Label6 As Elegant.Ui.Label
   Friend WithEvents TabControl2 As Elegant.Ui.TabControl
   Friend WithEvents TabPage11 As Elegant.Ui.TabPage
   Friend WithEvents TabPage12 As Elegant.Ui.TabPage
   Friend WithEvents TabPage13 As Elegant.Ui.TabPage
   Friend WithEvents TabPage14 As Elegant.Ui.TabPage
   Friend WithEvents TabPage15 As Elegant.Ui.TabPage
   Friend WithEvents TabPage16 As Elegant.Ui.TabPage
   Friend WithEvents GroupBox2 As Elegant.Ui.GroupBox
   Friend WithEvents Label10 As Elegant.Ui.Label
   Friend WithEvents eui_txtTrasmittentePECDestinatario As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTrasmittenteTelefono As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTrasmittenteEmail As Elegant.Ui.TextBox
   Friend WithEvents Label8 As Elegant.Ui.Label
   Friend WithEvents Label9 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCpRegimeFiscale As Elegant.Ui.ComboBox
   Friend WithEvents Label24 As Elegant.Ui.Label
   Friend WithEvents GroupBox5 As Elegant.Ui.GroupBox
   Friend WithEvents Label20 As Elegant.Ui.Label
   Friend WithEvents Label21 As Elegant.Ui.Label
   Friend WithEvents eui_txtCpNumeroIscrizioneAlbo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpAlboProfessionale As Elegant.Ui.TextBox
   Friend WithEvents Label22 As Elegant.Ui.Label
   Friend WithEvents Label23 As Elegant.Ui.Label
   Friend WithEvents GroupBox4 As Elegant.Ui.GroupBox
   Friend WithEvents Label18 As Elegant.Ui.Label
   Friend WithEvents Label17 As Elegant.Ui.Label
   Friend WithEvents Label16 As Elegant.Ui.Label
   Friend WithEvents eui_txtCpCodiceEORI As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpTitolo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpCognome As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpDenominazione As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpNome As Elegant.Ui.TextBox
   Friend WithEvents Label14 As Elegant.Ui.Label
   Friend WithEvents Label15 As Elegant.Ui.Label
   Friend WithEvents eui_txtCpCodiceFiscale As Elegant.Ui.TextBox
   Friend WithEvents Label13 As Elegant.Ui.Label
   Friend WithEvents GroupBox3 As Elegant.Ui.GroupBox
   Friend WithEvents eui_txtCpIdCodice As Elegant.Ui.TextBox
   Friend WithEvents Label11 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCpIdPaese As Elegant.Ui.ComboBox
   Friend WithEvents Label12 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCpProvinciaAlbo As Elegant.Ui.ComboBox
   Friend WithEvents GroupBox6 As Elegant.Ui.GroupBox
   Friend WithEvents Label19 As Elegant.Ui.Label
   Friend WithEvents Label25 As Elegant.Ui.Label
   Friend WithEvents Label26 As Elegant.Ui.Label
   Friend WithEvents eui_txtCpSedeComune As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpSedeCAP As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpSedeIndirizzo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpSedeNumeroCivico As Elegant.Ui.TextBox
   Friend WithEvents Label27 As Elegant.Ui.Label
   Friend WithEvents Label28 As Elegant.Ui.Label
   Friend WithEvents eui_dtpCpDataIscrizioneAlbo As Elegant.Ui.DateTimePicker
   Friend WithEvents eui_cmbCpSedeNazione As Elegant.Ui.ComboBox
   Friend WithEvents Label29 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCpSedeProvincia As Elegant.Ui.ComboBox
   Friend WithEvents GroupBox7 As Elegant.Ui.GroupBox
   Friend WithEvents eui_cmbCpStabileOrgNazione As Elegant.Ui.ComboBox
   Friend WithEvents Label30 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCpStabileOrgProvincia As Elegant.Ui.ComboBox
   Friend WithEvents Label31 As Elegant.Ui.Label
   Friend WithEvents Label32 As Elegant.Ui.Label
   Friend WithEvents Label33 As Elegant.Ui.Label
   Friend WithEvents eui_txtCpStabileOrgComune As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpStabileOrgCAP As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpStabileOrgIndirizzo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpStabileOrgNumeroCivico As Elegant.Ui.TextBox
   Friend WithEvents Label34 As Elegant.Ui.Label
   Friend WithEvents Label35 As Elegant.Ui.Label
   Friend WithEvents GroupBox8 As Elegant.Ui.GroupBox
   Friend WithEvents eui_cmbCpSocioUnicoREA As Elegant.Ui.ComboBox
   Friend WithEvents eui_cmbCpUfficioREA As Elegant.Ui.ComboBox
   Friend WithEvents eui_cmbCpStatoLiquidazioneREA As Elegant.Ui.ComboBox
   Friend WithEvents Label37 As Elegant.Ui.Label
   Friend WithEvents Label38 As Elegant.Ui.Label
   Friend WithEvents Label39 As Elegant.Ui.Label
   Friend WithEvents eui_txtCpCapitaleSocialeREA As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpNumeroREA As Elegant.Ui.TextBox
   Friend WithEvents Label40 As Elegant.Ui.Label
   Friend WithEvents Label41 As Elegant.Ui.Label
   Friend WithEvents GroupBox9 As Elegant.Ui.GroupBox
   Friend WithEvents Label36 As Elegant.Ui.Label
   Friend WithEvents eui_txtCpEmail As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpTelefono As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCpFax As Elegant.Ui.TextBox
   Friend WithEvents Label42 As Elegant.Ui.Label
   Friend WithEvents Label43 As Elegant.Ui.Label
   Friend WithEvents eui_txtCpRifAmministrazione As Elegant.Ui.TextBox
   Friend WithEvents Label44 As Elegant.Ui.Label
   Friend WithEvents Label52 As Elegant.Ui.Label
   Friend WithEvents GroupBox10 As Elegant.Ui.GroupBox
   Friend WithEvents Label45 As Elegant.Ui.Label
   Friend WithEvents Label46 As Elegant.Ui.Label
   Friend WithEvents Label47 As Elegant.Ui.Label
   Friend WithEvents eui_txtRfCpCodiceEORI As Elegant.Ui.TextBox
   Friend WithEvents eui_txtRfCpTitolo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtRfCpCognome As Elegant.Ui.TextBox
   Friend WithEvents eui_txtRfCpDenominazione As Elegant.Ui.TextBox
   Friend WithEvents eui_txtRfCpNome As Elegant.Ui.TextBox
   Friend WithEvents Label48 As Elegant.Ui.Label
   Friend WithEvents Label49 As Elegant.Ui.Label
   Friend WithEvents eui_txtRfCpCodiceFiscale As Elegant.Ui.TextBox
   Friend WithEvents GroupBox11 As Elegant.Ui.GroupBox
   Friend WithEvents eui_txtRfCpIdCodice As Elegant.Ui.TextBox
   Friend WithEvents Label50 As Elegant.Ui.Label
   Friend WithEvents eui_cmbRfCpIdPaese As Elegant.Ui.ComboBox
   Friend WithEvents Label51 As Elegant.Ui.Label
   Friend WithEvents TabControl3 As Elegant.Ui.TabControl
   Friend WithEvents TabPage18 As Elegant.Ui.TabPage
   Friend WithEvents GroupBox14 As Elegant.Ui.GroupBox
   Friend WithEvents eui_cmbCcSedeNazione As Elegant.Ui.ComboBox
   Friend WithEvents Label61 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCcSedeProvincia As Elegant.Ui.ComboBox
   Friend WithEvents Label62 As Elegant.Ui.Label
   Friend WithEvents Label63 As Elegant.Ui.Label
   Friend WithEvents Label64 As Elegant.Ui.Label
   Friend WithEvents eui_txtCcSedeComune As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcSedeCAP As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcSedeIndirizzo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcSedeNumeroCivico As Elegant.Ui.TextBox
   Friend WithEvents Label65 As Elegant.Ui.Label
   Friend WithEvents Label66 As Elegant.Ui.Label
   Friend WithEvents TabPage17 As Elegant.Ui.TabPage
   Friend WithEvents GroupBox12 As Elegant.Ui.GroupBox
   Friend WithEvents Label53 As Elegant.Ui.Label
   Friend WithEvents Label54 As Elegant.Ui.Label
   Friend WithEvents Label55 As Elegant.Ui.Label
   Friend WithEvents eui_txtCcCodiceEORI As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcTitolo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcCognome As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcDenominazione As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcNome As Elegant.Ui.TextBox
   Friend WithEvents Label56 As Elegant.Ui.Label
   Friend WithEvents Label57 As Elegant.Ui.Label
   Friend WithEvents eui_txtCcCodiceFiscale As Elegant.Ui.TextBox
   Friend WithEvents Label58 As Elegant.Ui.Label
   Friend WithEvents GroupBox13 As Elegant.Ui.GroupBox
   Friend WithEvents eui_txtCcIdCodice As Elegant.Ui.TextBox
   Friend WithEvents Label59 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCcIdPaese As Elegant.Ui.ComboBox
   Friend WithEvents Label60 As Elegant.Ui.Label
   Friend WithEvents eui_cmbSoggettoEmittente As Elegant.Ui.ComboBox
   Friend WithEvents Label75 As Elegant.Ui.Label
   Friend WithEvents GroupBox15 As Elegant.Ui.GroupBox
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
   Friend WithEvents eui_txtTiSeCodiceFiscale As Elegant.Ui.TextBox
   Friend WithEvents Label72 As Elegant.Ui.Label
   Friend WithEvents GroupBox16 As Elegant.Ui.GroupBox
   Friend WithEvents eui_txtTiSeIdCodice As Elegant.Ui.TextBox
   Friend WithEvents Label73 As Elegant.Ui.Label
   Friend WithEvents eui_cmbTiSeIdPaese As Elegant.Ui.ComboBox
   Friend WithEvents Label74 As Elegant.Ui.Label
   Friend WithEvents TabPage20 As Elegant.Ui.TabPage
   Friend WithEvents GroupBox18 As Elegant.Ui.GroupBox
   Friend WithEvents Label85 As Elegant.Ui.Label
   Friend WithEvents eui_txtCcRfCognome As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcRfDenominazione As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcRfNome As Elegant.Ui.TextBox
   Friend WithEvents Label86 As Elegant.Ui.Label
   Friend WithEvents Label87 As Elegant.Ui.Label
   Friend WithEvents GroupBox19 As Elegant.Ui.GroupBox
   Friend WithEvents eui_txtCcRfIdCodice As Elegant.Ui.TextBox
   Friend WithEvents Label88 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCcRfIdPaese As Elegant.Ui.ComboBox
   Friend WithEvents Label89 As Elegant.Ui.Label
   Friend WithEvents TabPage19 As Elegant.Ui.TabPage
   Friend WithEvents GroupBox17 As Elegant.Ui.GroupBox
   Friend WithEvents eui_cmbCcStabileOrgNazione As Elegant.Ui.ComboBox
   Friend WithEvents Label76 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCcStabileOrgProvincia As Elegant.Ui.ComboBox
   Friend WithEvents Label77 As Elegant.Ui.Label
   Friend WithEvents Label78 As Elegant.Ui.Label
   Friend WithEvents Label79 As Elegant.Ui.Label
   Friend WithEvents eui_txtCcStabileOrgComune As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcStabileOrgCAP As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcStabileOrgIndirizzo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCcStabileOrgNumeroCivico As Elegant.Ui.TextBox
   Friend WithEvents Label80 As Elegant.Ui.Label
   Friend WithEvents Label81 As Elegant.Ui.Label
   Friend WithEvents Label3 As Elegant.Ui.Label
   Friend WithEvents lnkAgenziaEntrate As LinkLabel
   Friend WithEvents lnkFatturaPA As LinkLabel
   Friend WithEvents lnkIndicePA As LinkLabel
   Friend WithEvents StatusBarPane3 As Elegant.Ui.StatusBarPane
   Friend WithEvents WebBrowser1 As WebBrowser
   Friend WithEvents TabPage21 As Elegant.Ui.TabPage
   Friend WithEvents eui_txtFormatoTxt As Elegant.Ui.TextBox
   Friend WithEvents eui_cmdApriFileTxt As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnteprimaWeb As Elegant.Ui.Button
   Friend WithEvents Label2 As Label
   Friend WithEvents eui_cmdConvalidaWeb As Elegant.Ui.Button
   Friend WithEvents eui_cmdSalva As Elegant.Ui.Button
End Class
