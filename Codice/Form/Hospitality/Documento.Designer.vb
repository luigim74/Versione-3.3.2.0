<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmDocumento
   Inherits System.Windows.Forms.Form

   'Form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   <System.Diagnostics.DebuggerNonUserCode()>
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
   'Non modificarla nell'editor del codice.
   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmDocumento))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_tpcDocumento = New Elegant.Ui.TabControl()
      Me.eui_tpPA = New Elegant.Ui.TabPage()
      Me.Label40 = New Elegant.Ui.Label()
      Me.eui_txtNumeroDoc_PA = New Elegant.Ui.TextBox()
      Me.eui_txtCodiceCommConv_PA = New Elegant.Ui.TextBox()
      Me.Label32 = New Elegant.Ui.Label()
      Me.Label37 = New Elegant.Ui.Label()
      Me.eui_txtCodiceCIG_PA = New Elegant.Ui.TextBox()
      Me.eui_txtCodiceCUP_PA = New Elegant.Ui.TextBox()
      Me.Label38 = New Elegant.Ui.Label()
      Me.Label39 = New Elegant.Ui.Label()
      Me.eui_tpGenerale = New Elegant.Ui.TabPage()
      Me.eui_txtNumProgressivo = New Elegant.Ui.TextBox()
      Me.eui_txtCameriere = New Elegant.Ui.TextBox()
      Me.eui_txtTavolo = New Elegant.Ui.TextBox()
      Me.eui_txtIdCliente = New Elegant.Ui.TextBox()
      Me.eui_cmdNuovoCliente = New Elegant.Ui.Button()
      Me.Label41 = New Elegant.Ui.Label()
      Me.eui_cmbIdCliente = New Elegant.Ui.ComboBox()
      Me.eui_cmdModificaCliente = New Elegant.Ui.Button()
      Me.eui_txtOra = New Elegant.Ui.TextBox()
      Me.eui_cmbTipoPagamento = New Elegant.Ui.ComboBox()
      Me.Label13 = New Elegant.Ui.Label()
      Me.eui_txtCodiceFiscale = New Elegant.Ui.TextBox()
      Me.eui_txtPartitaIva = New Elegant.Ui.TextBox()
      Me.Label11 = New Elegant.Ui.Label()
      Me.Label12 = New Elegant.Ui.Label()
      Me.eui_cmbCausaleDocumento = New Elegant.Ui.ComboBox()
      Me.Label1 = New Elegant.Ui.Label()
      Me.eui_txtAnno = New Elegant.Ui.TextBox()
      Me.Label5 = New Elegant.Ui.Label()
      Me.eui_txtProvincia = New Elegant.Ui.TextBox()
      Me.eui_cmbTipoDocumento = New Elegant.Ui.ComboBox()
      Me.Label3 = New Elegant.Ui.Label()
      Me.eui_cmbStatoDocumento = New Elegant.Ui.ComboBox()
      Me.eui_txtCap = New Elegant.Ui.TextBox()
      Me.Label2 = New Elegant.Ui.Label()
      Me.eui_dtpData = New Elegant.Ui.DateTimePicker()
      Me.Label4 = New Elegant.Ui.Label()
      Me.eui_txtCittà = New Elegant.Ui.TextBox()
      Me.eui_txtNumero = New Elegant.Ui.TextBox()
      Me.eui_txtIndirizzo = New Elegant.Ui.TextBox()
      Me.Label10 = New Elegant.Ui.Label()
      Me.Label9 = New Elegant.Ui.Label()
      Me.Label8 = New Elegant.Ui.Label()
      Me.Label7 = New Elegant.Ui.Label()
      Me.eui_txtClienteNome = New Elegant.Ui.TextBox()
      Me.eui_cmbClienteCognome = New Elegant.Ui.ComboBox()
      Me.Label6 = New Elegant.Ui.Label()
      Me.eui_tpDettagli = New Elegant.Ui.TabPage()
      Me.eui_cmdImportaDoc = New Elegant.Ui.Button()
      Me.eui_cmdCancellaTutto = New Elegant.Ui.Button()
      Me.eui_cmdEliminaRiga = New Elegant.Ui.Button()
      Me.DropDown1 = New Elegant.Ui.DropDown()
      Me.PopupMenu1 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdInsPiatti = New Elegant.Ui.Button()
      Me.eui_cmdInsProdotti = New Elegant.Ui.Button()
      Me.Separator2 = New Elegant.Ui.Separator()
      Me.eui_cmdInsAccessori = New Elegant.Ui.Button()
      Me.eui_cmdInsiServizi = New Elegant.Ui.Button()
      Me.eui_cmdNuovaRiga = New Elegant.Ui.Button()
      Me.dgvDettagli = New System.Windows.Forms.DataGridView()
      Me.clnCodice = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnDescrizione = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnUm = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnQta = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnPrezzo = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnSconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnImporto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnIva = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnRepartoIva = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnValoreSconto = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.clnCategoria = New System.Windows.Forms.DataGridViewTextBoxColumn()
      Me.eui_tpTotali = New Elegant.Ui.TabPage()
      Me.Label36 = New Elegant.Ui.Label()
      Me.eui_txtTotaliRep4Imposta = New Elegant.Ui.TextBox()
      Me.eui_txtTotaliRep4Aliquota = New Elegant.Ui.TextBox()
      Me.eui_txtTotaliRep4ImponibileLordo = New Elegant.Ui.TextBox()
      Me.Label35 = New Elegant.Ui.Label()
      Me.eui_txtTotaliRep3Imposta = New Elegant.Ui.TextBox()
      Me.eui_txtTotaliRep3Aliquota = New Elegant.Ui.TextBox()
      Me.eui_txtTotaliRep3ImponibileLordo = New Elegant.Ui.TextBox()
      Me.Label34 = New Elegant.Ui.Label()
      Me.eui_txtTotaliRep2Imposta = New Elegant.Ui.TextBox()
      Me.eui_txtTotaliRep2Aliquota = New Elegant.Ui.TextBox()
      Me.eui_txtTotaliRep2ImponibileLordo = New Elegant.Ui.TextBox()
      Me.Label33 = New Elegant.Ui.Label()
      Me.eui_txtTotaliRep1Imposta = New Elegant.Ui.TextBox()
      Me.Label29 = New Elegant.Ui.Label()
      Me.eui_txtTotaliRep1Aliquota = New Elegant.Ui.TextBox()
      Me.Label30 = New Elegant.Ui.Label()
      Me.eui_txtTotaliRep1ImponibileLordo = New Elegant.Ui.TextBox()
      Me.Label31 = New Elegant.Ui.Label()
      Me.eui_txtTotaliSospeso = New Elegant.Ui.TextBox()
      Me.Label28 = New Elegant.Ui.Label()
      Me.eui_txtTotaliBuoni = New Elegant.Ui.TextBox()
      Me.Label25 = New Elegant.Ui.Label()
      Me.eui_txtTotaliContanti = New Elegant.Ui.TextBox()
      Me.eui_txtTotaliCarte = New Elegant.Ui.TextBox()
      Me.Label26 = New Elegant.Ui.Label()
      Me.Label27 = New Elegant.Ui.Label()
      Me.eui_txtTotaliCoperto = New Elegant.Ui.TextBox()
      Me.Label24 = New Elegant.Ui.Label()
      Me.eui_txtTotaliSconto = New Elegant.Ui.TextBox()
      Me.eui_txtTotaliServizio = New Elegant.Ui.TextBox()
      Me.Label22 = New Elegant.Ui.Label()
      Me.Label23 = New Elegant.Ui.Label()
      Me.eui_txtTotaleConto = New Elegant.Ui.TextBox()
      Me.Label19 = New Elegant.Ui.Label()
      Me.eui_txtTotaleImposta = New Elegant.Ui.TextBox()
      Me.eui_txtTotaliImponibile = New Elegant.Ui.TextBox()
      Me.Label20 = New Elegant.Ui.Label()
      Me.Label21 = New Elegant.Ui.Label()
      Me.eui_tpNote = New Elegant.Ui.TabPage()
      Me.eui_txtNote = New Elegant.Ui.TextBox()
      Me.PopupMenu2 = New Elegant.Ui.PopupMenu(Me.components)
      Me.Button1 = New Elegant.Ui.Button()
      Me.Button2 = New Elegant.Ui.Button()
      Me.Button3 = New Elegant.Ui.Button()
      Me.Button4 = New Elegant.Ui.Button()
      Me.StatusBar1 = New Elegant.Ui.StatusBar()
      Me.StatusBarNotificationsArea1 = New Elegant.Ui.StatusBarNotificationsArea()
      Me.StatusBarPane2 = New Elegant.Ui.StatusBarPane()
      Me.eui_lblStatoNumeroDoc = New Elegant.Ui.Label()
      Me.StatusBarPane5 = New Elegant.Ui.StatusBarPane()
      Me.eui_lblStatoDataDoc = New Elegant.Ui.Label()
      Me.StatusBarPane1 = New Elegant.Ui.StatusBarPane()
      Me.eui_lblStatoClienteDoc = New Elegant.Ui.Label()
      Me.StatusBarControlsArea1 = New Elegant.Ui.StatusBarControlsArea()
      Me.StatusBarPane4 = New Elegant.Ui.StatusBarPane()
      Me.eui_lblStatoTotaleDoc = New Elegant.Ui.Label()
      Me.eui_cmdAnteprima = New Elegant.Ui.Button()
      Me.eui_cmdEmetti = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdSalva = New Elegant.Ui.Button()
      Me.eui_txtSconto = New Elegant.Ui.TextBox()
      Me.eui_txtServizio = New Elegant.Ui.TextBox()
      Me.Label14 = New Elegant.Ui.Label()
      Me.Label15 = New Elegant.Ui.Label()
      Me.eui_txtImposta = New Elegant.Ui.TextBox()
      Me.eui_txtImponibile = New Elegant.Ui.TextBox()
      Me.Label16 = New Elegant.Ui.Label()
      Me.Label17 = New Elegant.Ui.Label()
      Me.eui_txtTotaleDocumento = New Elegant.Ui.TextBox()
      Me.Label18 = New Elegant.Ui.Label()
      Me.eui_cmdStampa = New Elegant.Ui.Button()
      Me.eui_cmdEmettiStampa = New Elegant.Ui.Button()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      CType(Me.eui_tpcDocumento, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_tpPA.SuspendLayout()
      Me.eui_tpGenerale.SuspendLayout()
      Me.eui_tpDettagli.SuspendLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.dgvDettagli, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_tpTotali.SuspendLayout()
      Me.eui_tpNote.SuspendLayout()
      CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.StatusBar1.SuspendLayout()
      Me.StatusBarNotificationsArea1.SuspendLayout()
      Me.StatusBarPane2.SuspendLayout()
      Me.StatusBarPane5.SuspendLayout()
      Me.StatusBarPane1.SuspendLayout()
      Me.StatusBarControlsArea1.SuspendLayout()
      Me.StatusBarPane4.SuspendLayout()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
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
      Me.eui_tpcDocumento.SelectedTabPage = Me.eui_tpGenerale
      Me.eui_tpcDocumento.Size = New System.Drawing.Size(679, 480)
      Me.eui_tpcDocumento.TabIndex = 0
      Me.eui_tpcDocumento.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.eui_tpGenerale, Me.eui_tpDettagli, Me.eui_tpPA, Me.eui_tpTotali, Me.eui_tpNote})
      Me.eui_tpcDocumento.Text = " "
      '
      'eui_tpPA
      '
      Me.eui_tpPA.ActiveControl = Nothing
      Me.eui_tpPA.Controls.Add(Me.Label40)
      Me.eui_tpPA.Controls.Add(Me.eui_txtNumeroDoc_PA)
      Me.eui_tpPA.Controls.Add(Me.eui_txtCodiceCommConv_PA)
      Me.eui_tpPA.Controls.Add(Me.Label32)
      Me.eui_tpPA.Controls.Add(Me.Label37)
      Me.eui_tpPA.Controls.Add(Me.eui_txtCodiceCIG_PA)
      Me.eui_tpPA.Controls.Add(Me.eui_txtCodiceCUP_PA)
      Me.eui_tpPA.Controls.Add(Me.Label38)
      Me.eui_tpPA.Controls.Add(Me.Label39)
      Me.eui_tpPA.KeyTip = Nothing
      Me.eui_tpPA.Name = "eui_tpPA"
      Me.eui_tpPA.Size = New System.Drawing.Size(677, 459)
      Me.eui_tpPA.TabIndex = 4
      Me.eui_tpPA.Text = "&PA"
      '
      'Label40
      '
      Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label40.Location = New System.Drawing.Point(22, 21)
      Me.Label40.Name = "Label40"
      Me.Label40.Size = New System.Drawing.Size(313, 16)
      Me.Label40.TabIndex = 49
      Me.Label40.Text = "Dati Ordine di Acquisto della Pubblica Amministrazione:"
      '
      'eui_txtNumeroDoc_PA
      '
      Me.eui_txtNumeroDoc_PA.Id = "fbdefb33-f19c-4bc5-9c44-ba78443ff5c3"
      Me.eui_txtNumeroDoc_PA.Location = New System.Drawing.Point(198, 51)
      Me.eui_txtNumeroDoc_PA.MaxLength = 20
      Me.eui_txtNumeroDoc_PA.Name = "eui_txtNumeroDoc_PA"
      Me.eui_txtNumeroDoc_PA.Size = New System.Drawing.Size(194, 21)
      Me.eui_txtNumeroDoc_PA.TabIndex = 0
      Me.eui_txtNumeroDoc_PA.TextEditorWidth = 188
      '
      'eui_txtCodiceCommConv_PA
      '
      Me.eui_txtCodiceCommConv_PA.Id = "0cd74bbc-5889-45a3-9bd5-a530e2322b63"
      Me.eui_txtCodiceCommConv_PA.Location = New System.Drawing.Point(198, 146)
      Me.eui_txtCodiceCommConv_PA.MaxLength = 100
      Me.eui_txtCodiceCommConv_PA.Name = "eui_txtCodiceCommConv_PA"
      Me.eui_txtCodiceCommConv_PA.Size = New System.Drawing.Size(344, 21)
      Me.eui_txtCodiceCommConv_PA.TabIndex = 3
      Me.eui_txtCodiceCommConv_PA.TextEditorWidth = 338
      '
      'Label32
      '
      Me.Label32.Location = New System.Drawing.Point(21, 51)
      Me.Label32.Name = "Label32"
      Me.Label32.Size = New System.Drawing.Size(113, 13)
      Me.Label32.TabIndex = 39
      Me.Label32.Text = "Numero del documento:"
      '
      'Label37
      '
      Me.Label37.Location = New System.Drawing.Point(22, 146)
      Me.Label37.Name = "Label37"
      Me.Label37.Size = New System.Drawing.Size(164, 13)
      Me.Label37.TabIndex = 38
      Me.Label37.Text = "Codice Commessa o Convenzione:"
      '
      'eui_txtCodiceCIG_PA
      '
      Me.eui_txtCodiceCIG_PA.Id = "b5a08b4c-158f-459e-a233-769b67204e2d"
      Me.eui_txtCodiceCIG_PA.Location = New System.Drawing.Point(198, 115)
      Me.eui_txtCodiceCIG_PA.MaxLength = 15
      Me.eui_txtCodiceCIG_PA.Name = "eui_txtCodiceCIG_PA"
      Me.eui_txtCodiceCIG_PA.Size = New System.Drawing.Size(194, 21)
      Me.eui_txtCodiceCIG_PA.TabIndex = 2
      Me.eui_txtCodiceCIG_PA.TextEditorWidth = 188
      '
      'eui_txtCodiceCUP_PA
      '
      Me.eui_txtCodiceCUP_PA.Id = "3c577f17-03f5-4c4d-90ee-92d8ba242143"
      Me.eui_txtCodiceCUP_PA.Location = New System.Drawing.Point(198, 83)
      Me.eui_txtCodiceCUP_PA.MaxLength = 15
      Me.eui_txtCodiceCUP_PA.Name = "eui_txtCodiceCUP_PA"
      Me.eui_txtCodiceCUP_PA.Size = New System.Drawing.Size(194, 21)
      Me.eui_txtCodiceCUP_PA.TabIndex = 1
      Me.eui_txtCodiceCUP_PA.TextEditorWidth = 188
      '
      'Label38
      '
      Me.Label38.Location = New System.Drawing.Point(22, 115)
      Me.Label38.Name = "Label38"
      Me.Label38.Size = New System.Drawing.Size(57, 13)
      Me.Label38.TabIndex = 37
      Me.Label38.Text = "Codice CIG:"
      '
      'Label39
      '
      Me.Label39.Location = New System.Drawing.Point(22, 83)
      Me.Label39.Name = "Label39"
      Me.Label39.Size = New System.Drawing.Size(61, 13)
      Me.Label39.TabIndex = 36
      Me.Label39.Text = "Codice CUP:"
      '
      'eui_tpGenerale
      '
      Me.eui_tpGenerale.ActiveControl = Nothing
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtNumProgressivo)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtCameriere)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtTavolo)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtIdCliente)
      Me.eui_tpGenerale.Controls.Add(Me.eui_cmdNuovoCliente)
      Me.eui_tpGenerale.Controls.Add(Me.Label41)
      Me.eui_tpGenerale.Controls.Add(Me.eui_cmbIdCliente)
      Me.eui_tpGenerale.Controls.Add(Me.eui_cmdModificaCliente)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtOra)
      Me.eui_tpGenerale.Controls.Add(Me.eui_cmbTipoPagamento)
      Me.eui_tpGenerale.Controls.Add(Me.Label13)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtCodiceFiscale)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtPartitaIva)
      Me.eui_tpGenerale.Controls.Add(Me.Label11)
      Me.eui_tpGenerale.Controls.Add(Me.Label12)
      Me.eui_tpGenerale.Controls.Add(Me.eui_cmbCausaleDocumento)
      Me.eui_tpGenerale.Controls.Add(Me.Label1)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtAnno)
      Me.eui_tpGenerale.Controls.Add(Me.Label5)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtProvincia)
      Me.eui_tpGenerale.Controls.Add(Me.eui_cmbTipoDocumento)
      Me.eui_tpGenerale.Controls.Add(Me.Label3)
      Me.eui_tpGenerale.Controls.Add(Me.eui_cmbStatoDocumento)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtCap)
      Me.eui_tpGenerale.Controls.Add(Me.Label2)
      Me.eui_tpGenerale.Controls.Add(Me.eui_dtpData)
      Me.eui_tpGenerale.Controls.Add(Me.Label4)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtCittà)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtNumero)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtIndirizzo)
      Me.eui_tpGenerale.Controls.Add(Me.Label10)
      Me.eui_tpGenerale.Controls.Add(Me.Label9)
      Me.eui_tpGenerale.Controls.Add(Me.Label8)
      Me.eui_tpGenerale.Controls.Add(Me.Label7)
      Me.eui_tpGenerale.Controls.Add(Me.eui_txtClienteNome)
      Me.eui_tpGenerale.Controls.Add(Me.eui_cmbClienteCognome)
      Me.eui_tpGenerale.Controls.Add(Me.Label6)
      Me.eui_tpGenerale.KeyTip = Nothing
      Me.eui_tpGenerale.Name = "eui_tpGenerale"
      Me.eui_tpGenerale.Size = New System.Drawing.Size(677, 459)
      Me.eui_tpGenerale.TabIndex = 0
      Me.eui_tpGenerale.Text = "&Generale"
      '
      'eui_txtNumProgressivo
      '
      Me.eui_txtNumProgressivo.BannerTextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtNumProgressivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtNumProgressivo.Id = "181f3d9d-f8bd-4437-9f5a-5dcb3fffd1a5"
      Me.eui_txtNumProgressivo.Location = New System.Drawing.Point(72, 84)
      Me.eui_txtNumProgressivo.Name = "eui_txtNumProgressivo"
      Me.eui_txtNumProgressivo.Size = New System.Drawing.Size(75, 21)
      Me.eui_txtNumProgressivo.TabIndex = 3
      Me.eui_txtNumProgressivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtNumProgressivo.Visible = False
      '
      'eui_txtCameriere
      '
      Me.eui_txtCameriere.Id = "d418d228-3193-4bd2-a089-f1344ad8b0c6"
      Me.eui_txtCameriere.Location = New System.Drawing.Point(71, 308)
      Me.eui_txtCameriere.Name = "eui_txtCameriere"
      Me.eui_txtCameriere.Size = New System.Drawing.Size(80, 21)
      Me.eui_txtCameriere.TabIndex = 42
      Me.eui_txtCameriere.TextEditorWidth = 74
      Me.eui_txtCameriere.Visible = False
      '
      'eui_txtTavolo
      '
      Me.eui_txtTavolo.Id = "5bc44102-c309-40d8-83bd-2ae775389abe"
      Me.eui_txtTavolo.Location = New System.Drawing.Point(71, 283)
      Me.eui_txtTavolo.Name = "eui_txtTavolo"
      Me.eui_txtTavolo.Size = New System.Drawing.Size(81, 21)
      Me.eui_txtTavolo.TabIndex = 41
      Me.eui_txtTavolo.TextEditorWidth = 75
      Me.eui_txtTavolo.Visible = False
      '
      'eui_txtIdCliente
      '
      Me.eui_txtIdCliente.Id = "6c3d222b-6453-4dab-913d-8d16ce0dea55"
      Me.eui_txtIdCliente.Location = New System.Drawing.Point(113, 135)
      Me.eui_txtIdCliente.Name = "eui_txtIdCliente"
      Me.eui_txtIdCliente.Size = New System.Drawing.Size(39, 21)
      Me.eui_txtIdCliente.TabIndex = 40
      Me.eui_txtIdCliente.TextEditorWidth = 33
      Me.eui_txtIdCliente.Visible = False
      '
      'eui_cmdNuovoCliente
      '
      Me.eui_cmdNuovoCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdNuovoCliente.Id = "28ee9ae7-92bb-4bc9-8751-dc7ed0d79655"
      Me.eui_cmdNuovoCliente.Location = New System.Drawing.Point(627, 158)
      Me.eui_cmdNuovoCliente.Name = "eui_cmdNuovoCliente"
      Me.eui_cmdNuovoCliente.ScreenTip.Caption = "Nuovo"
      Me.eui_cmdNuovoCliente.ScreenTip.Text = "Apre la finestra per l'inserimento dei dati di un nuovo cliente."
      Me.eui_cmdNuovoCliente.Size = New System.Drawing.Size(30, 21)
      Me.eui_cmdNuovoCliente.TabIndex = 9
      Me.eui_cmdNuovoCliente.Text = "+"
      '
      'Label41
      '
      Me.Label41.Location = New System.Drawing.Point(158, 28)
      Me.Label41.Name = "Label41"
      Me.Label41.Size = New System.Drawing.Size(11, 13)
      Me.Label41.TabIndex = 38
      Me.Label41.Text = "/"
      '
      'eui_cmbIdCliente
      '
      Me.eui_cmbIdCliente.Editable = False
      Me.eui_cmbIdCliente.FormattingEnabled = False
      Me.eui_cmbIdCliente.Id = "92ffe671-631c-47b2-b6e6-5079ba4fd5e3"
      Me.eui_cmbIdCliente.Location = New System.Drawing.Point(71, 135)
      Me.eui_cmbIdCliente.Name = "eui_cmbIdCliente"
      Me.eui_cmbIdCliente.Size = New System.Drawing.Size(30, 21)
      Me.eui_cmbIdCliente.TabIndex = 37
      Me.eui_cmbIdCliente.TextEditorWidth = 11
      Me.eui_cmbIdCliente.Visible = False
      '
      'eui_cmdModificaCliente
      '
      Me.eui_cmdModificaCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdModificaCliente.Id = "8a17ba51-9706-441a-8d53-3f124a07092c"
      Me.eui_cmdModificaCliente.Location = New System.Drawing.Point(596, 158)
      Me.eui_cmdModificaCliente.Name = "eui_cmdModificaCliente"
      Me.eui_cmdModificaCliente.ScreenTip.Caption = "Modifica"
      Me.eui_cmdModificaCliente.ScreenTip.Text = "Apre la finestra di modifica dei dati del cliente selezionato."
      Me.eui_cmdModificaCliente.Size = New System.Drawing.Size(30, 21)
      Me.eui_cmdModificaCliente.TabIndex = 8
      Me.eui_cmdModificaCliente.Text = "..."
      '
      'eui_txtOra
      '
      Me.eui_txtOra.Id = "d0685579-4dd6-45ac-88b5-7536c60ce1de"
      Me.eui_txtOra.Location = New System.Drawing.Point(170, 84)
      Me.eui_txtOra.Name = "eui_txtOra"
      Me.eui_txtOra.Size = New System.Drawing.Size(61, 21)
      Me.eui_txtOra.TabIndex = 4
      Me.eui_txtOra.TextEditorWidth = 55
      Me.eui_txtOra.Visible = False
      '
      'eui_cmbTipoPagamento
      '
      Me.eui_cmbTipoPagamento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmbTipoPagamento.FormattingEnabled = False
      Me.eui_cmbTipoPagamento.Id = "e0e7801f-9f9e-4759-9986-6317c12a9589"
      Me.eui_cmbTipoPagamento.Location = New System.Drawing.Point(463, 254)
      Me.eui_cmbTipoPagamento.Name = "eui_cmbTipoPagamento"
      Me.eui_cmbTipoPagamento.Size = New System.Drawing.Size(194, 21)
      Me.eui_cmbTipoPagamento.Sorted = True
      Me.eui_cmbTipoPagamento.TabIndex = 15
      Me.eui_cmbTipoPagamento.TextEditorWidth = 175
      '
      'Label13
      '
      Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label13.Location = New System.Drawing.Point(383, 254)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(57, 13)
      Me.Label13.TabIndex = 35
      Me.Label13.Text = "Pagamento:"
      '
      'eui_txtCodiceFiscale
      '
      Me.eui_txtCodiceFiscale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtCodiceFiscale.Id = "7bbe9c34-2fb4-4be7-8b34-8a3bf7de247b"
      Me.eui_txtCodiceFiscale.Location = New System.Drawing.Point(463, 222)
      Me.eui_txtCodiceFiscale.MaxLength = 16
      Me.eui_txtCodiceFiscale.Name = "eui_txtCodiceFiscale"
      Me.eui_txtCodiceFiscale.Size = New System.Drawing.Size(194, 21)
      Me.eui_txtCodiceFiscale.TabIndex = 14
      Me.eui_txtCodiceFiscale.TextEditorWidth = 188
      '
      'eui_txtPartitaIva
      '
      Me.eui_txtPartitaIva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtPartitaIva.Id = "cc8e05ad-a451-418c-a92e-0e740c97071f"
      Me.eui_txtPartitaIva.Location = New System.Drawing.Point(463, 190)
      Me.eui_txtPartitaIva.MaxLength = 11
      Me.eui_txtPartitaIva.Name = "eui_txtPartitaIva"
      Me.eui_txtPartitaIva.Size = New System.Drawing.Size(194, 21)
      Me.eui_txtPartitaIva.TabIndex = 13
      Me.eui_txtPartitaIva.TextEditorWidth = 188
      '
      'Label11
      '
      Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label11.Location = New System.Drawing.Point(383, 222)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(69, 13)
      Me.Label11.TabIndex = 31
      Me.Label11.Text = "Codice fiscale:"
      '
      'Label12
      '
      Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label12.Location = New System.Drawing.Point(383, 190)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(53, 13)
      Me.Label12.TabIndex = 30
      Me.Label12.Text = "Partita IVA:"
      '
      'eui_cmbCausaleDocumento
      '
      Me.eui_cmbCausaleDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmbCausaleDocumento.FormattingEnabled = False
      Me.eui_cmbCausaleDocumento.Id = "780b4384-b4be-4d7d-b041-8a5cb40e071e"
      Me.eui_cmbCausaleDocumento.Location = New System.Drawing.Point(364, 88)
      Me.eui_cmbCausaleDocumento.Name = "eui_cmbCausaleDocumento"
      Me.eui_cmbCausaleDocumento.Size = New System.Drawing.Size(293, 21)
      Me.eui_cmbCausaleDocumento.Sorted = True
      Me.eui_cmbCausaleDocumento.TabIndex = 5
      Me.eui_cmbCausaleDocumento.TextEditorWidth = 255
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(272, 24)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(80, 16)
      Me.Label1.TabIndex = 9
      Me.Label1.Text = "Tipo documento:"
      '
      'eui_txtAnno
      '
      Me.eui_txtAnno.BannerTextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtAnno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtAnno.Id = "86422bd2-acc3-4b17-bf5e-f83ec75186b6"
      Me.eui_txtAnno.Location = New System.Drawing.Point(170, 24)
      Me.eui_txtAnno.Name = "eui_txtAnno"
      Me.eui_txtAnno.Size = New System.Drawing.Size(62, 21)
      Me.eui_txtAnno.TabIndex = 1
      Me.eui_txtAnno.Text = "2015"
      Me.eui_txtAnno.TextEditorWidth = 56
      '
      'Label5
      '
      Me.Label5.Location = New System.Drawing.Point(272, 88)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(80, 16)
      Me.Label5.TabIndex = 17
      Me.Label5.Text = "Causale:"
      '
      'eui_txtProvincia
      '
      Me.eui_txtProvincia.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtProvincia.Id = "3985392b-67f1-4adc-8b45-140adb998a16"
      Me.eui_txtProvincia.Location = New System.Drawing.Point(326, 254)
      Me.eui_txtProvincia.MaxLength = 2
      Me.eui_txtProvincia.Name = "eui_txtProvincia"
      Me.eui_txtProvincia.Size = New System.Drawing.Size(47, 21)
      Me.eui_txtProvincia.TabIndex = 12
      Me.eui_txtProvincia.TextEditorWidth = 40
      '
      'eui_cmbTipoDocumento
      '
      Me.eui_cmbTipoDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmbTipoDocumento.Editable = False
      Me.eui_cmbTipoDocumento.FormattingEnabled = False
      Me.eui_cmbTipoDocumento.Id = "dc8327db-c9fa-4fa0-a3b7-59e884bacc1c"
      Me.eui_cmbTipoDocumento.Location = New System.Drawing.Point(364, 24)
      Me.eui_cmbTipoDocumento.Name = "eui_cmbTipoDocumento"
      Me.eui_cmbTipoDocumento.Size = New System.Drawing.Size(293, 21)
      Me.eui_cmbTipoDocumento.Sorted = True
      Me.eui_cmbTipoDocumento.TabIndex = 3
      Me.eui_cmbTipoDocumento.TextEditorWidth = 255
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(24, 24)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(40, 13)
      Me.Label3.TabIndex = 11
      Me.Label3.Text = "Numero:"
      '
      'eui_cmbStatoDocumento
      '
      Me.eui_cmbStatoDocumento.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmbStatoDocumento.Editable = False
      Me.eui_cmbStatoDocumento.FormattingEnabled = False
      Me.eui_cmbStatoDocumento.Id = "76bfb2e5-46f8-4d6d-9a88-956a8c363518"
      Me.eui_cmbStatoDocumento.Location = New System.Drawing.Point(364, 56)
      Me.eui_cmbStatoDocumento.Name = "eui_cmbStatoDocumento"
      Me.eui_cmbStatoDocumento.Size = New System.Drawing.Size(293, 21)
      Me.eui_cmbStatoDocumento.TabIndex = 4
      Me.eui_cmbStatoDocumento.TextEditorWidth = 255
      '
      'eui_txtCap
      '
      Me.eui_txtCap.Id = "4204a4af-49ab-4716-b653-f7f3501302a9"
      Me.eui_txtCap.Location = New System.Drawing.Point(71, 254)
      Me.eui_txtCap.MaxLength = 5
      Me.eui_txtCap.Name = "eui_txtCap"
      Me.eui_txtCap.Size = New System.Drawing.Size(81, 21)
      Me.eui_txtCap.TabIndex = 12
      Me.eui_txtCap.TextEditorWidth = 75
      '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(272, 56)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(80, 16)
      Me.Label2.TabIndex = 10
      Me.Label2.Text = "Stato:"
      '
      'eui_dtpData
      '
      Me.eui_dtpData.Id = "0ebeb455-6b17-4457-ae05-8c666915d35c"
      Me.eui_dtpData.Location = New System.Drawing.Point(72, 56)
      Me.eui_dtpData.Name = "eui_dtpData"
      Me.eui_dtpData.Size = New System.Drawing.Size(160, 21)
      Me.eui_dtpData.TabIndex = 2
      Me.eui_dtpData.TextEditorWidth = 141
      '
      'Label4
      '
      Me.Label4.Location = New System.Drawing.Point(24, 56)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(32, 13)
      Me.Label4.TabIndex = 12
      Me.Label4.Text = "Data:"
      '
      'eui_txtCittà
      '
      Me.eui_txtCittà.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtCittà.Id = "22637545-03a0-4931-b455-632da50ff576"
      Me.eui_txtCittà.Location = New System.Drawing.Point(72, 222)
      Me.eui_txtCittà.Name = "eui_txtCittà"
      Me.eui_txtCittà.Size = New System.Drawing.Size(301, 21)
      Me.eui_txtCittà.TabIndex = 11
      Me.eui_txtCittà.TextEditorWidth = 274
      '
      'eui_txtNumero
      '
      Me.eui_txtNumero.BannerTextFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtNumero.Id = "e3192374-fa23-4e8b-884d-eaecdbb68ab9"
      Me.eui_txtNumero.Location = New System.Drawing.Point(72, 24)
      Me.eui_txtNumero.Name = "eui_txtNumero"
      Me.eui_txtNumero.Size = New System.Drawing.Size(75, 21)
      Me.eui_txtNumero.TabIndex = 0
      Me.eui_txtNumero.Text = "105"
      Me.eui_txtNumero.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'eui_txtIndirizzo
      '
      Me.eui_txtIndirizzo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtIndirizzo.Id = "b905ef6f-4b8d-440a-afca-5f359e1db5cc"
      Me.eui_txtIndirizzo.Location = New System.Drawing.Point(72, 190)
      Me.eui_txtIndirizzo.Name = "eui_txtIndirizzo"
      Me.eui_txtIndirizzo.Size = New System.Drawing.Size(301, 21)
      Me.eui_txtIndirizzo.TabIndex = 10
      Me.eui_txtIndirizzo.TextEditorWidth = 274
      '
      'Label10
      '
      Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label10.Location = New System.Drawing.Point(269, 254)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(47, 13)
      Me.Label10.TabIndex = 25
      Me.Label10.Text = "Provincia:"
      '
      'Label9
      '
      Me.Label9.Location = New System.Drawing.Point(24, 222)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(32, 13)
      Me.Label9.TabIndex = 24
      Me.Label9.Text = "Città:"
      '
      'Label8
      '
      Me.Label8.Location = New System.Drawing.Point(23, 254)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(33, 13)
      Me.Label8.TabIndex = 23
      Me.Label8.Text = "C.A.P.:"
      '
      'Label7
      '
      Me.Label7.Location = New System.Drawing.Point(24, 190)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(41, 13)
      Me.Label7.TabIndex = 22
      Me.Label7.Text = "Indirizzo:"
      '
      'eui_txtClienteNome
      '
      Me.eui_txtClienteNome.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtClienteNome.Id = "0c1086a1-ef0a-4fce-93c7-c93d5dae2b25"
      Me.eui_txtClienteNome.Location = New System.Drawing.Point(383, 158)
      Me.eui_txtClienteNome.Name = "eui_txtClienteNome"
      Me.eui_txtClienteNome.Size = New System.Drawing.Size(212, 21)
      Me.eui_txtClienteNome.TabIndex = 7
      Me.eui_txtClienteNome.TextEditorWidth = 206
      '
      'eui_cmbClienteCognome
      '
      Me.eui_cmbClienteCognome.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmbClienteCognome.FormattingEnabled = False
      Me.eui_cmbClienteCognome.Id = "b3c44817-bd83-445f-87d4-1a655a058aa1"
      Me.eui_cmbClienteCognome.Location = New System.Drawing.Point(72, 158)
      Me.eui_cmbClienteCognome.Name = "eui_cmbClienteCognome"
      Me.eui_cmbClienteCognome.Size = New System.Drawing.Size(301, 21)
      Me.eui_cmbClienteCognome.TabIndex = 6
      Me.eui_cmbClienteCognome.TextEditorWidth = 261
      '
      'Label6
      '
      Me.Label6.Location = New System.Drawing.Point(24, 158)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(33, 13)
      Me.Label6.TabIndex = 20
      Me.Label6.Text = "Clente:"
      '
      'eui_tpDettagli
      '
      Me.eui_tpDettagli.ActiveControl = Nothing
      Me.eui_tpDettagli.Controls.Add(Me.eui_cmdImportaDoc)
      Me.eui_tpDettagli.Controls.Add(Me.eui_cmdCancellaTutto)
      Me.eui_tpDettagli.Controls.Add(Me.eui_cmdEliminaRiga)
      Me.eui_tpDettagli.Controls.Add(Me.DropDown1)
      Me.eui_tpDettagli.Controls.Add(Me.eui_cmdNuovaRiga)
      Me.eui_tpDettagli.Controls.Add(Me.dgvDettagli)
      Me.eui_tpDettagli.KeyTip = Nothing
      Me.eui_tpDettagli.Name = "eui_tpDettagli"
      Me.eui_tpDettagli.Size = New System.Drawing.Size(677, 459)
      Me.eui_tpDettagli.TabIndex = 1
      Me.eui_tpDettagli.Text = "&Dettagli"
      '
      'eui_cmdImportaDoc
      '
      Me.eui_cmdImportaDoc.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdImportaDoc.Id = "ec3e23ac-6c4f-4121-b3fe-64698cc82823"
      Me.eui_cmdImportaDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.eui_cmdImportaDoc.Location = New System.Drawing.Point(5, 418)
      Me.eui_cmdImportaDoc.Name = "eui_cmdImportaDoc"
      Me.eui_cmdImportaDoc.ScreenTip.Caption = "Stampa"
      Me.eui_cmdImportaDoc.ScreenTip.Text = "Salva e stampa il documento."
      Me.eui_cmdImportaDoc.Size = New System.Drawing.Size(122, 29)
      Me.eui_cmdImportaDoc.TabIndex = 1
      Me.eui_cmdImportaDoc.Text = "Importa documento..."
      '
      'eui_cmdCancellaTutto
      '
      Me.eui_cmdCancellaTutto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdCancellaTutto.Id = "a64e0446-1db7-4144-9b7c-e1251124234a"
      Me.eui_cmdCancellaTutto.Location = New System.Drawing.Point(579, 417)
      Me.eui_cmdCancellaTutto.Name = "eui_cmdCancellaTutto"
      Me.eui_cmdCancellaTutto.Size = New System.Drawing.Size(95, 29)
      Me.eui_cmdCancellaTutto.TabIndex = 5
      Me.eui_cmdCancellaTutto.Text = "&Cancella tutto"
      '
      'eui_cmdEliminaRiga
      '
      Me.eui_cmdEliminaRiga.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdEliminaRiga.Id = "ffdf7dee-e67d-4bb1-8383-e023e9410042"
      Me.eui_cmdEliminaRiga.Location = New System.Drawing.Point(475, 417)
      Me.eui_cmdEliminaRiga.Name = "eui_cmdEliminaRiga"
      Me.eui_cmdEliminaRiga.Size = New System.Drawing.Size(95, 29)
      Me.eui_cmdEliminaRiga.TabIndex = 4
      Me.eui_cmdEliminaRiga.Text = "&Elimina riga"
      '
      'DropDown1
      '
      Me.DropDown1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.DropDown1.Id = "8fc42b15-7920-4cc6-8833-4a5a44220cbf"
      Me.DropDown1.Location = New System.Drawing.Point(137, 418)
      Me.DropDown1.Name = "DropDown1"
      Me.DropDown1.Popup = Me.PopupMenu1
      Me.DropDown1.Size = New System.Drawing.Size(122, 29)
      Me.DropDown1.TabIndex = 2
      Me.DropDown1.Text = "&Inserisci"
      '
      'PopupMenu1
      '
      Me.PopupMenu1.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdInsPiatti, Me.eui_cmdInsProdotti, Me.Separator2, Me.eui_cmdInsAccessori, Me.eui_cmdInsiServizi})
      Me.PopupMenu1.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu1.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdInsPiatti
      '
      Me.eui_cmdInsPiatti.Id = "4ac25483-812f-4790-b27f-46db20bebb88"
      Me.eui_cmdInsPiatti.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdInsPiatti.Name = "eui_cmdInsPiatti"
      Me.eui_cmdInsPiatti.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdInsPiatti.TabIndex = 5
      Me.eui_cmdInsPiatti.Text = "&Piatti"
      '
      'eui_cmdInsProdotti
      '
      Me.eui_cmdInsProdotti.Enabled = False
      Me.eui_cmdInsProdotti.Id = "6ae8cd35-7b39-4425-b887-ec304fea57fc"
      Me.eui_cmdInsProdotti.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdInsProdotti.Name = "eui_cmdInsProdotti"
      Me.eui_cmdInsProdotti.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdInsProdotti.TabIndex = 6
      Me.eui_cmdInsProdotti.Text = "Pr&odotti"
      '
      'Separator2
      '
      Me.Separator2.Id = "5b3afab4-cce2-4b7e-b2e5-a49bcb982da3"
      Me.Separator2.Location = New System.Drawing.Point(2, 48)
      Me.Separator2.Name = "Separator2"
      Me.Separator2.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator2.Size = New System.Drawing.Size(126, 5)
      Me.Separator2.TabIndex = 7
      Me.Separator2.Text = "Separator2"
      '
      'eui_cmdInsAccessori
      '
      Me.eui_cmdInsAccessori.Id = "731bfde3-799a-4b0d-937a-67443e967c36"
      Me.eui_cmdInsAccessori.Location = New System.Drawing.Point(2, 53)
      Me.eui_cmdInsAccessori.Name = "eui_cmdInsAccessori"
      Me.eui_cmdInsAccessori.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdInsAccessori.TabIndex = 8
      Me.eui_cmdInsAccessori.Text = "&Accessori"
      '
      'eui_cmdInsiServizi
      '
      Me.eui_cmdInsiServizi.Id = "681de0fa-bff3-460a-86e9-0f84be4abcce"
      Me.eui_cmdInsiServizi.Location = New System.Drawing.Point(2, 76)
      Me.eui_cmdInsiServizi.Name = "eui_cmdInsiServizi"
      Me.eui_cmdInsiServizi.Size = New System.Drawing.Size(126, 23)
      Me.eui_cmdInsiServizi.TabIndex = 10
      Me.eui_cmdInsiServizi.Text = "&Servizi"
      '
      'eui_cmdNuovaRiga
      '
      Me.eui_cmdNuovaRiga.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdNuovaRiga.Id = "009b3784-161a-4521-84d6-77d07b88a7dd"
      Me.eui_cmdNuovaRiga.Location = New System.Drawing.Point(370, 417)
      Me.eui_cmdNuovaRiga.Name = "eui_cmdNuovaRiga"
      Me.eui_cmdNuovaRiga.Size = New System.Drawing.Size(95, 29)
      Me.eui_cmdNuovaRiga.TabIndex = 3
      Me.eui_cmdNuovaRiga.Text = "&Nuova riga"
      '
      'dgvDettagli
      '
      DataGridViewCellStyle19.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
      Me.dgvDettagli.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle19
      Me.dgvDettagli.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dgvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.dgvDettagli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
      Me.dgvDettagli.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clnCodice, Me.clnDescrizione, Me.clnUm, Me.clnQta, Me.clnPrezzo, Me.clnSconto, Me.clnImporto, Me.clnIva, Me.clnRepartoIva, Me.clnValoreSconto, Me.clnCategoria})
      DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
      DataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Window
      DataGridViewCellStyle27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle27.SelectionBackColor = System.Drawing.Color.Orange
      DataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.ControlText
      DataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
      Me.dgvDettagli.DefaultCellStyle = DataGridViewCellStyle27
      Me.dgvDettagli.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
      Me.dgvDettagli.Location = New System.Drawing.Point(5, 2)
      Me.dgvDettagli.MultiSelect = False
      Me.dgvDettagli.Name = "dgvDettagli"
      Me.dgvDettagli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
      Me.dgvDettagli.Size = New System.Drawing.Size(668, 409)
      Me.dgvDettagli.TabIndex = 0
      '
      'clnCodice
      '
      DataGridViewCellStyle20.Format = "N0"
      DataGridViewCellStyle20.NullValue = Nothing
      Me.clnCodice.DefaultCellStyle = DataGridViewCellStyle20
      Me.clnCodice.HeaderText = "Codice"
      Me.clnCodice.Name = "clnCodice"
      Me.clnCodice.ToolTipText = "Codice"
      Me.clnCodice.Width = 80
      '
      'clnDescrizione
      '
      Me.clnDescrizione.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
      DataGridViewCellStyle21.NullValue = Nothing
      Me.clnDescrizione.DefaultCellStyle = DataGridViewCellStyle21
      Me.clnDescrizione.HeaderText = "Descrizione"
      Me.clnDescrizione.Name = "clnDescrizione"
      Me.clnDescrizione.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
      Me.clnDescrizione.ToolTipText = "Descrizione"
      '
      'clnUm
      '
      Me.clnUm.FillWeight = 30.0!
      Me.clnUm.HeaderText = "U.M."
      Me.clnUm.Name = "clnUm"
      Me.clnUm.ToolTipText = "Unità di misura"
      Me.clnUm.Width = 50
      '
      'clnQta
      '
      DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
      DataGridViewCellStyle22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle22.Format = "N2"
      DataGridViewCellStyle22.NullValue = "0,00"
      Me.clnQta.DefaultCellStyle = DataGridViewCellStyle22
      Me.clnQta.HeaderText = "Q.tà"
      Me.clnQta.Name = "clnQta"
      Me.clnQta.ToolTipText = "Quantità"
      Me.clnQta.Width = 50
      '
      'clnPrezzo
      '
      DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
      DataGridViewCellStyle23.Format = "C2"
      DataGridViewCellStyle23.NullValue = "0,00"
      Me.clnPrezzo.DefaultCellStyle = DataGridViewCellStyle23
      Me.clnPrezzo.HeaderText = "Prezzo"
      Me.clnPrezzo.Name = "clnPrezzo"
      Me.clnPrezzo.ToolTipText = "Prezzo unitario"
      '
      'clnSconto
      '
      DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
      DataGridViewCellStyle24.Format = "N2"
      DataGridViewCellStyle24.NullValue = "0,00"
      Me.clnSconto.DefaultCellStyle = DataGridViewCellStyle24
      Me.clnSconto.HeaderText = "Sconto %"
      Me.clnSconto.Name = "clnSconto"
      Me.clnSconto.ToolTipText = "Sconto"
      Me.clnSconto.Width = 60
      '
      'clnImporto
      '
      DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
      DataGridViewCellStyle25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      DataGridViewCellStyle25.Format = "C2"
      DataGridViewCellStyle25.NullValue = "0,00"
      Me.clnImporto.DefaultCellStyle = DataGridViewCellStyle25
      Me.clnImporto.HeaderText = "Importo"
      Me.clnImporto.Name = "clnImporto"
      Me.clnImporto.ReadOnly = True
      Me.clnImporto.ToolTipText = "Importo totale"
      '
      'clnIva
      '
      DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
      DataGridViewCellStyle26.Format = "N0"
      DataGridViewCellStyle26.NullValue = "0"
      Me.clnIva.DefaultCellStyle = DataGridViewCellStyle26
      Me.clnIva.HeaderText = "I.V.A. %"
      Me.clnIva.Name = "clnIva"
      Me.clnIva.ToolTipText = "Aliquota Iva"
      Me.clnIva.Width = 50
      '
      'clnRepartoIva
      '
      Me.clnRepartoIva.HeaderText = "RepartoIva"
      Me.clnRepartoIva.Name = "clnRepartoIva"
      Me.clnRepartoIva.ReadOnly = True
      Me.clnRepartoIva.Visible = False
      '
      'clnValoreSconto
      '
      Me.clnValoreSconto.HeaderText = "Valore Sconto"
      Me.clnValoreSconto.Name = "clnValoreSconto"
      Me.clnValoreSconto.Visible = False
      '
      'clnCategoria
      '
      Me.clnCategoria.HeaderText = "Categoria"
      Me.clnCategoria.Name = "clnCategoria"
      Me.clnCategoria.Visible = False
      '
      'eui_tpTotali
      '
      Me.eui_tpTotali.ActiveControl = Nothing
      Me.eui_tpTotali.Controls.Add(Me.Label36)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep4Imposta)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep4Aliquota)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep4ImponibileLordo)
      Me.eui_tpTotali.Controls.Add(Me.Label35)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep3Imposta)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep3Aliquota)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep3ImponibileLordo)
      Me.eui_tpTotali.Controls.Add(Me.Label34)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep2Imposta)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep2Aliquota)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep2ImponibileLordo)
      Me.eui_tpTotali.Controls.Add(Me.Label33)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep1Imposta)
      Me.eui_tpTotali.Controls.Add(Me.Label29)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep1Aliquota)
      Me.eui_tpTotali.Controls.Add(Me.Label30)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliRep1ImponibileLordo)
      Me.eui_tpTotali.Controls.Add(Me.Label31)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliSospeso)
      Me.eui_tpTotali.Controls.Add(Me.Label28)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliBuoni)
      Me.eui_tpTotali.Controls.Add(Me.Label25)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliContanti)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliCarte)
      Me.eui_tpTotali.Controls.Add(Me.Label26)
      Me.eui_tpTotali.Controls.Add(Me.Label27)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliCoperto)
      Me.eui_tpTotali.Controls.Add(Me.Label24)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliSconto)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliServizio)
      Me.eui_tpTotali.Controls.Add(Me.Label22)
      Me.eui_tpTotali.Controls.Add(Me.Label23)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaleConto)
      Me.eui_tpTotali.Controls.Add(Me.Label19)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaleImposta)
      Me.eui_tpTotali.Controls.Add(Me.eui_txtTotaliImponibile)
      Me.eui_tpTotali.Controls.Add(Me.Label20)
      Me.eui_tpTotali.Controls.Add(Me.Label21)
      Me.eui_tpTotali.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_tpTotali.KeyTip = Nothing
      Me.eui_tpTotali.Name = "eui_tpTotali"
      Me.eui_tpTotali.Size = New System.Drawing.Size(677, 459)
      Me.eui_tpTotali.TabIndex = 3
      Me.eui_tpTotali.Text = "&Totali"
      '
      'Label36
      '
      Me.Label36.Location = New System.Drawing.Point(512, 32)
      Me.Label36.Name = "Label36"
      Me.Label36.Size = New System.Drawing.Size(76, 16)
      Me.Label36.TabIndex = 86
      Me.Label36.Text = "Reparto 4"
      '
      'eui_txtTotaliRep4Imposta
      '
      Me.eui_txtTotaliRep4Imposta.Id = "ffd83ae2-0ec8-4f14-93b6-d911d0b28d90"
      Me.eui_txtTotaliRep4Imposta.Location = New System.Drawing.Point(511, 118)
      Me.eui_txtTotaliRep4Imposta.Name = "eui_txtTotaliRep4Imposta"
      Me.eui_txtTotaliRep4Imposta.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep4Imposta.TabIndex = 11
      Me.eui_txtTotaliRep4Imposta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep4Imposta.TextEditorWidth = 107
      '
      'eui_txtTotaliRep4Aliquota
      '
      Me.eui_txtTotaliRep4Aliquota.Id = "4793859a-b23a-42e5-bc1e-07d61a5befb0"
      Me.eui_txtTotaliRep4Aliquota.Location = New System.Drawing.Point(511, 86)
      Me.eui_txtTotaliRep4Aliquota.Name = "eui_txtTotaliRep4Aliquota"
      Me.eui_txtTotaliRep4Aliquota.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep4Aliquota.TabIndex = 7
      Me.eui_txtTotaliRep4Aliquota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep4Aliquota.TextEditorWidth = 107
      '
      'eui_txtTotaliRep4ImponibileLordo
      '
      Me.eui_txtTotaliRep4ImponibileLordo.Id = "f450f0f3-ca6c-4679-b1e9-6dee97303ddc"
      Me.eui_txtTotaliRep4ImponibileLordo.Location = New System.Drawing.Point(511, 53)
      Me.eui_txtTotaliRep4ImponibileLordo.Name = "eui_txtTotaliRep4ImponibileLordo"
      Me.eui_txtTotaliRep4ImponibileLordo.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep4ImponibileLordo.TabIndex = 3
      Me.eui_txtTotaliRep4ImponibileLordo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep4ImponibileLordo.TextEditorWidth = 107
      '
      'Label35
      '
      Me.Label35.Location = New System.Drawing.Point(386, 32)
      Me.Label35.Name = "Label35"
      Me.Label35.Size = New System.Drawing.Size(76, 16)
      Me.Label35.TabIndex = 81
      Me.Label35.Text = "Reparto 3"
      '
      'eui_txtTotaliRep3Imposta
      '
      Me.eui_txtTotaliRep3Imposta.Id = "7e17eb03-a692-4531-9565-756b88d062e7"
      Me.eui_txtTotaliRep3Imposta.Location = New System.Drawing.Point(385, 118)
      Me.eui_txtTotaliRep3Imposta.Name = "eui_txtTotaliRep3Imposta"
      Me.eui_txtTotaliRep3Imposta.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep3Imposta.TabIndex = 10
      Me.eui_txtTotaliRep3Imposta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep3Imposta.TextEditorWidth = 107
      '
      'eui_txtTotaliRep3Aliquota
      '
      Me.eui_txtTotaliRep3Aliquota.Id = "954846f0-094a-4a2c-8db2-3a1f2af6b0e2"
      Me.eui_txtTotaliRep3Aliquota.Location = New System.Drawing.Point(385, 86)
      Me.eui_txtTotaliRep3Aliquota.Name = "eui_txtTotaliRep3Aliquota"
      Me.eui_txtTotaliRep3Aliquota.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep3Aliquota.TabIndex = 6
      Me.eui_txtTotaliRep3Aliquota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep3Aliquota.TextEditorWidth = 107
      '
      'eui_txtTotaliRep3ImponibileLordo
      '
      Me.eui_txtTotaliRep3ImponibileLordo.Id = "dc250508-4fa8-46ed-9dc1-584c14572782"
      Me.eui_txtTotaliRep3ImponibileLordo.Location = New System.Drawing.Point(385, 53)
      Me.eui_txtTotaliRep3ImponibileLordo.Name = "eui_txtTotaliRep3ImponibileLordo"
      Me.eui_txtTotaliRep3ImponibileLordo.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep3ImponibileLordo.TabIndex = 2
      Me.eui_txtTotaliRep3ImponibileLordo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep3ImponibileLordo.TextEditorWidth = 107
      '
      'Label34
      '
      Me.Label34.Location = New System.Drawing.Point(260, 32)
      Me.Label34.Name = "Label34"
      Me.Label34.Size = New System.Drawing.Size(76, 16)
      Me.Label34.TabIndex = 76
      Me.Label34.Text = "Reparto 2"
      '
      'eui_txtTotaliRep2Imposta
      '
      Me.eui_txtTotaliRep2Imposta.Id = "34118c39-bef2-43b9-810b-7ec2e5d252f3"
      Me.eui_txtTotaliRep2Imposta.Location = New System.Drawing.Point(259, 118)
      Me.eui_txtTotaliRep2Imposta.Name = "eui_txtTotaliRep2Imposta"
      Me.eui_txtTotaliRep2Imposta.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep2Imposta.TabIndex = 9
      Me.eui_txtTotaliRep2Imposta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep2Imposta.TextEditorWidth = 107
      '
      'eui_txtTotaliRep2Aliquota
      '
      Me.eui_txtTotaliRep2Aliquota.Id = "155cd85a-0031-4f1e-a7b8-c7604228e0d0"
      Me.eui_txtTotaliRep2Aliquota.Location = New System.Drawing.Point(259, 86)
      Me.eui_txtTotaliRep2Aliquota.Name = "eui_txtTotaliRep2Aliquota"
      Me.eui_txtTotaliRep2Aliquota.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep2Aliquota.TabIndex = 5
      Me.eui_txtTotaliRep2Aliquota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep2Aliquota.TextEditorWidth = 107
      '
      'eui_txtTotaliRep2ImponibileLordo
      '
      Me.eui_txtTotaliRep2ImponibileLordo.Id = "34790fb5-a700-442f-bbf0-20dfca3f5211"
      Me.eui_txtTotaliRep2ImponibileLordo.Location = New System.Drawing.Point(259, 53)
      Me.eui_txtTotaliRep2ImponibileLordo.Name = "eui_txtTotaliRep2ImponibileLordo"
      Me.eui_txtTotaliRep2ImponibileLordo.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep2ImponibileLordo.TabIndex = 1
      Me.eui_txtTotaliRep2ImponibileLordo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep2ImponibileLordo.TextEditorWidth = 107
      '
      'Label33
      '
      Me.Label33.Location = New System.Drawing.Point(135, 32)
      Me.Label33.Name = "Label33"
      Me.Label33.Size = New System.Drawing.Size(76, 16)
      Me.Label33.TabIndex = 71
      Me.Label33.Text = "Reparto 1"
      '
      'eui_txtTotaliRep1Imposta
      '
      Me.eui_txtTotaliRep1Imposta.Id = "dcf1c4f9-95b8-4574-8f2c-52bed74e2876"
      Me.eui_txtTotaliRep1Imposta.Location = New System.Drawing.Point(134, 118)
      Me.eui_txtTotaliRep1Imposta.Name = "eui_txtTotaliRep1Imposta"
      Me.eui_txtTotaliRep1Imposta.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep1Imposta.TabIndex = 8
      Me.eui_txtTotaliRep1Imposta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep1Imposta.TextEditorWidth = 107
      '
      'Label29
      '
      Me.Label29.Location = New System.Drawing.Point(24, 118)
      Me.Label29.Name = "Label29"
      Me.Label29.Size = New System.Drawing.Size(101, 13)
      Me.Label29.TabIndex = 70
      Me.Label29.Text = "Imposta:"
      '
      'eui_txtTotaliRep1Aliquota
      '
      Me.eui_txtTotaliRep1Aliquota.Id = "ebec8ca3-175b-4e35-86a8-15c4be47759c"
      Me.eui_txtTotaliRep1Aliquota.Location = New System.Drawing.Point(134, 86)
      Me.eui_txtTotaliRep1Aliquota.Name = "eui_txtTotaliRep1Aliquota"
      Me.eui_txtTotaliRep1Aliquota.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep1Aliquota.TabIndex = 4
      Me.eui_txtTotaliRep1Aliquota.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep1Aliquota.TextEditorWidth = 107
      '
      'Label30
      '
      Me.Label30.Location = New System.Drawing.Point(24, 86)
      Me.Label30.Name = "Label30"
      Me.Label30.Size = New System.Drawing.Size(94, 21)
      Me.Label30.TabIndex = 68
      Me.Label30.Text = "Aliquota:"
      '
      'eui_txtTotaliRep1ImponibileLordo
      '
      Me.eui_txtTotaliRep1ImponibileLordo.Id = "c41e3f0d-73b3-4635-80ff-2ee6acc3cc27"
      Me.eui_txtTotaliRep1ImponibileLordo.Location = New System.Drawing.Point(134, 53)
      Me.eui_txtTotaliRep1ImponibileLordo.Name = "eui_txtTotaliRep1ImponibileLordo"
      Me.eui_txtTotaliRep1ImponibileLordo.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliRep1ImponibileLordo.TabIndex = 0
      Me.eui_txtTotaliRep1ImponibileLordo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliRep1ImponibileLordo.TextEditorWidth = 107
      '
      'Label31
      '
      Me.Label31.Location = New System.Drawing.Point(24, 53)
      Me.Label31.Name = "Label31"
      Me.Label31.Size = New System.Drawing.Size(76, 16)
      Me.Label31.TabIndex = 66
      Me.Label31.Text = "Imponibile:"
      '
      'eui_txtTotaliSospeso
      '
      Me.eui_txtTotaliSospeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTotaliSospeso.Id = "fa047992-05aa-45a2-b111-14b2ffce2ddc"
      Me.eui_txtTotaliSospeso.Location = New System.Drawing.Point(134, 358)
      Me.eui_txtTotaliSospeso.Name = "eui_txtTotaliSospeso"
      Me.eui_txtTotaliSospeso.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliSospeso.TabIndex = 16
      Me.eui_txtTotaliSospeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliSospeso.TextEditorWidth = 107
      '
      'Label28
      '
      Me.Label28.Location = New System.Drawing.Point(23, 356)
      Me.Label28.Name = "Label28"
      Me.Label28.Size = New System.Drawing.Size(101, 13)
      Me.Label28.TabIndex = 62
      Me.Label28.Text = "Sospeso:"
      '
      'eui_txtTotaliBuoni
      '
      Me.eui_txtTotaliBuoni.Enabled = False
      Me.eui_txtTotaliBuoni.Id = "f437759b-1a9e-4cf4-9171-a487de788d3a"
      Me.eui_txtTotaliBuoni.Location = New System.Drawing.Point(134, 322)
      Me.eui_txtTotaliBuoni.Name = "eui_txtTotaliBuoni"
      Me.eui_txtTotaliBuoni.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliBuoni.TabIndex = 15
      Me.eui_txtTotaliBuoni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliBuoni.TextEditorWidth = 107
      '
      'Label25
      '
      Me.Label25.Location = New System.Drawing.Point(23, 322)
      Me.Label25.Name = "Label25"
      Me.Label25.Size = New System.Drawing.Size(122, 21)
      Me.Label25.TabIndex = 60
      Me.Label25.Text = "Buoni Pasto / Ticket:"
      '
      'eui_txtTotaliContanti
      '
      Me.eui_txtTotaliContanti.Id = "3b9a5823-baa0-4234-afed-b64c562cc81c"
      Me.eui_txtTotaliContanti.Location = New System.Drawing.Point(134, 253)
      Me.eui_txtTotaliContanti.Name = "eui_txtTotaliContanti"
      Me.eui_txtTotaliContanti.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliContanti.TabIndex = 13
      Me.eui_txtTotaliContanti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliContanti.TextEditorWidth = 107
      '
      'eui_txtTotaliCarte
      '
      Me.eui_txtTotaliCarte.Id = "bef45986-eec3-404c-bccf-3706932d5729"
      Me.eui_txtTotaliCarte.Location = New System.Drawing.Point(134, 287)
      Me.eui_txtTotaliCarte.Name = "eui_txtTotaliCarte"
      Me.eui_txtTotaliCarte.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliCarte.TabIndex = 14
      Me.eui_txtTotaliCarte.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliCarte.TextEditorWidth = 107
      '
      'Label26
      '
      Me.Label26.Location = New System.Drawing.Point(23, 253)
      Me.Label26.Name = "Label26"
      Me.Label26.Size = New System.Drawing.Size(122, 21)
      Me.Label26.TabIndex = 58
      Me.Label26.Text = "Contanti:"
      '
      'Label27
      '
      Me.Label27.Location = New System.Drawing.Point(23, 287)
      Me.Label27.Name = "Label27"
      Me.Label27.Size = New System.Drawing.Size(122, 21)
      Me.Label27.TabIndex = 57
      Me.Label27.Text = "Carta di credito:"
      '
      'eui_txtTotaliCoperto
      '
      Me.eui_txtTotaliCoperto.Id = "972e4d3c-d254-40a1-afd3-5079f291dca1"
      Me.eui_txtTotaliCoperto.Location = New System.Drawing.Point(135, 424)
      Me.eui_txtTotaliCoperto.Name = "eui_txtTotaliCoperto"
      Me.eui_txtTotaliCoperto.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliCoperto.TabIndex = 18
      Me.eui_txtTotaliCoperto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliCoperto.TextEditorWidth = 107
      Me.eui_txtTotaliCoperto.Visible = False
      '
      'Label24
      '
      Me.Label24.Location = New System.Drawing.Point(25, 425)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(72, 13)
      Me.Label24.TabIndex = 54
      Me.Label24.Text = "Totale coperto:"
      Me.Label24.Visible = False
      '
      'eui_txtTotaliSconto
      '
      Me.eui_txtTotaliSconto.Id = "249b0cf7-9686-4ed4-894e-d297f18da089"
      Me.eui_txtTotaliSconto.Location = New System.Drawing.Point(135, 189)
      Me.eui_txtTotaliSconto.Name = "eui_txtTotaliSconto"
      Me.eui_txtTotaliSconto.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliSconto.TabIndex = 12
      Me.eui_txtTotaliSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliSconto.TextEditorWidth = 107
      '
      'eui_txtTotaliServizio
      '
      Me.eui_txtTotaliServizio.Id = "719144b6-18ef-474b-b166-3c2e0bdd5832"
      Me.eui_txtTotaliServizio.Location = New System.Drawing.Point(135, 399)
      Me.eui_txtTotaliServizio.Name = "eui_txtTotaliServizio"
      Me.eui_txtTotaliServizio.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliServizio.TabIndex = 17
      Me.eui_txtTotaliServizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliServizio.TextEditorWidth = 107
      Me.eui_txtTotaliServizio.Visible = False
      '
      'Label22
      '
      Me.Label22.Location = New System.Drawing.Point(22, 189)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(68, 16)
      Me.Label22.TabIndex = 52
      Me.Label22.Text = "Totale sconto:"
      '
      'Label23
      '
      Me.Label23.Location = New System.Drawing.Point(25, 399)
      Me.Label23.Name = "Label23"
      Me.Label23.Size = New System.Drawing.Size(53, 13)
      Me.Label23.TabIndex = 51
      Me.Label23.Text = "Servizio:"
      Me.Label23.Visible = False
      '
      'eui_txtTotaleConto
      '
      Me.eui_txtTotaleConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTotaleConto.Id = "290ee552-7348-4091-bdbd-8913091330c5"
      Me.eui_txtTotaleConto.Location = New System.Drawing.Point(511, 358)
      Me.eui_txtTotaleConto.Name = "eui_txtTotaleConto"
      Me.eui_txtTotaleConto.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaleConto.TabIndex = 19
      Me.eui_txtTotaleConto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaleConto.TextEditorWidth = 107
      '
      'Label19
      '
      Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label19.Location = New System.Drawing.Point(422, 363)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(76, 16)
      Me.Label19.TabIndex = 48
      Me.Label19.Text = "Totale:"
      '
      'eui_txtTotaleImposta
      '
      Me.eui_txtTotaleImposta.Id = "1bb48929-aef4-4843-a704-974e9b2bea73"
      Me.eui_txtTotaleImposta.Location = New System.Drawing.Point(511, 322)
      Me.eui_txtTotaleImposta.Name = "eui_txtTotaleImposta"
      Me.eui_txtTotaleImposta.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaleImposta.TabIndex = 18
      Me.eui_txtTotaleImposta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaleImposta.TextEditorWidth = 107
      '
      'eui_txtTotaliImponibile
      '
      Me.eui_txtTotaliImponibile.Id = "c3e2b9e8-8aa8-4f15-94cb-bd3c25128c65"
      Me.eui_txtTotaliImponibile.Location = New System.Drawing.Point(511, 287)
      Me.eui_txtTotaliImponibile.Name = "eui_txtTotaliImponibile"
      Me.eui_txtTotaliImponibile.Size = New System.Drawing.Size(113, 21)
      Me.eui_txtTotaliImponibile.TabIndex = 17
      Me.eui_txtTotaliImponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaliImponibile.TextEditorWidth = 107
      '
      'Label20
      '
      Me.Label20.Location = New System.Drawing.Point(422, 327)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(56, 16)
      Me.Label20.TabIndex = 47
      Me.Label20.Text = "Imposta:"
      '
      'Label21
      '
      Me.Label21.Location = New System.Drawing.Point(422, 292)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(56, 16)
      Me.Label21.TabIndex = 46
      Me.Label21.Text = "Imponibile:"
      '
      'eui_tpNote
      '
      Me.eui_tpNote.ActiveControl = Nothing
      Me.eui_tpNote.Controls.Add(Me.eui_txtNote)
      Me.eui_tpNote.KeyTip = Nothing
      Me.eui_tpNote.Name = "eui_tpNote"
      Me.eui_tpNote.Size = New System.Drawing.Size(677, 459)
      Me.eui_tpNote.TabIndex = 2
      Me.eui_tpNote.Text = "&Note"
      '
      'eui_txtNote
      '
      Me.eui_txtNote.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_txtNote.Id = "dda24583-0823-4af6-a304-1b9f1a7cf785"
      Me.eui_txtNote.Location = New System.Drawing.Point(0, 0)
      Me.eui_txtNote.Multiline = True
      Me.eui_txtNote.Name = "eui_txtNote"
      Me.eui_txtNote.Size = New System.Drawing.Size(677, 459)
      Me.eui_txtNote.TabIndex = 0
      Me.eui_txtNote.TextEditorWidth = 653
      '
      'PopupMenu2
      '
      Me.PopupMenu2.Items.AddRange(New System.Windows.Forms.Control() {Me.Button1, Me.Button2, Me.Button3, Me.Button4})
      Me.PopupMenu2.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu2.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu2.Size = New System.Drawing.Size(100, 100)
      '
      'Button1
      '
      Me.Button1.Id = "ea91078f-6700-43c9-ad89-368cc7e6627c"
      Me.Button1.Location = New System.Drawing.Point(2, 2)
      Me.Button1.Name = "Button1"
      Me.Button1.Size = New System.Drawing.Size(126, 23)
      Me.Button1.TabIndex = 3
      Me.Button1.Text = "Button1"
      '
      'Button2
      '
      Me.Button2.Id = "4caf48e5-ccba-40cb-a801-98a53a21fe35"
      Me.Button2.Location = New System.Drawing.Point(2, 25)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(126, 23)
      Me.Button2.TabIndex = 4
      Me.Button2.Text = "Button2"
      '
      'Button3
      '
      Me.Button3.Id = "1aa33e9a-bad1-4747-b930-95d345e1f59c"
      Me.Button3.Location = New System.Drawing.Point(2, 48)
      Me.Button3.Name = "Button3"
      Me.Button3.Size = New System.Drawing.Size(126, 23)
      Me.Button3.TabIndex = 5
      Me.Button3.Text = "Button3"
      '
      'Button4
      '
      Me.Button4.Id = "72507412-48a6-4ba4-84e0-28e03af8943a"
      Me.Button4.Location = New System.Drawing.Point(2, 71)
      Me.Button4.Name = "Button4"
      Me.Button4.Size = New System.Drawing.Size(126, 23)
      Me.Button4.TabIndex = 6
      Me.Button4.Text = "Button4"
      '
      'StatusBar1
      '
      Me.StatusBar1.Controls.Add(Me.StatusBarNotificationsArea1)
      Me.StatusBar1.Controls.Add(Me.StatusBarControlsArea1)
      Me.StatusBar1.ControlsArea = Me.StatusBarControlsArea1
      Me.StatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.StatusBar1.Location = New System.Drawing.Point(0, 620)
      Me.StatusBar1.Name = "StatusBar1"
      Me.StatusBar1.NotificationsArea = Me.StatusBarNotificationsArea1
      Me.StatusBar1.Size = New System.Drawing.Size(884, 22)
      Me.StatusBar1.TabIndex = 3
      Me.StatusBar1.Text = "StatusBar1"
      '
      'StatusBarNotificationsArea1
      '
      Me.StatusBarNotificationsArea1.Controls.Add(Me.StatusBarPane2)
      Me.StatusBarNotificationsArea1.Controls.Add(Me.StatusBarPane5)
      Me.StatusBarNotificationsArea1.Controls.Add(Me.StatusBarPane1)
      Me.StatusBarNotificationsArea1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarNotificationsArea1.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarNotificationsArea1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarNotificationsArea1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarNotificationsArea1.Name = "StatusBarNotificationsArea1"
      Me.StatusBarNotificationsArea1.Size = New System.Drawing.Size(750, 22)
      Me.StatusBarNotificationsArea1.TabIndex = 1
      '
      'StatusBarPane2
      '
      Me.StatusBarPane2.Controls.Add(Me.eui_lblStatoNumeroDoc)
      Me.StatusBarPane2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarPane2.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarPane2.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane2.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane2.Name = "StatusBarPane2"
      Me.StatusBarPane2.ScreenTip.Text = "Numero documento"
      Me.StatusBarPane2.Size = New System.Drawing.Size(87, 22)
      Me.StatusBarPane2.TabIndex = 0
      '
      'eui_lblStatoNumeroDoc
      '
      Me.eui_lblStatoNumeroDoc.Location = New System.Drawing.Point(5, 5)
      Me.eui_lblStatoNumeroDoc.Name = "eui_lblStatoNumeroDoc"
      Me.eui_lblStatoNumeroDoc.ScreenTip.Text = "Numero documento"
      Me.eui_lblStatoNumeroDoc.Size = New System.Drawing.Size(47, 13)
      Me.eui_lblStatoNumeroDoc.TabIndex = 0
      Me.eui_lblStatoNumeroDoc.Text = "100/2015"
      '
      'StatusBarPane5
      '
      Me.StatusBarPane5.Controls.Add(Me.eui_lblStatoDataDoc)
      Me.StatusBarPane5.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarPane5.Location = New System.Drawing.Point(87, 0)
      Me.StatusBarPane5.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane5.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane5.Name = "StatusBarPane5"
      Me.StatusBarPane5.Size = New System.Drawing.Size(98, 22)
      Me.StatusBarPane5.TabIndex = 1
      '
      'eui_lblStatoDataDoc
      '
      Me.eui_lblStatoDataDoc.Location = New System.Drawing.Point(5, 5)
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
      Me.StatusBarPane1.Size = New System.Drawing.Size(129, 22)
      Me.StatusBarPane1.TabIndex = 2
      '
      'eui_lblStatoClienteDoc
      '
      Me.eui_lblStatoClienteDoc.Location = New System.Drawing.Point(5, 5)
      Me.eui_lblStatoClienteDoc.Name = "eui_lblStatoClienteDoc"
      Me.eui_lblStatoClienteDoc.ScreenTip.Text = "Cliente intestatario"
      Me.eui_lblStatoClienteDoc.Size = New System.Drawing.Size(89, 13)
      Me.eui_lblStatoClienteDoc.TabIndex = 0
      Me.eui_lblStatoClienteDoc.Text = "Luigi Montana Spa"
      '
      'StatusBarControlsArea1
      '
      Me.StatusBarControlsArea1.Controls.Add(Me.StatusBarPane4)
      Me.StatusBarControlsArea1.Dock = System.Windows.Forms.DockStyle.Right
      Me.StatusBarControlsArea1.Location = New System.Drawing.Point(750, 0)
      Me.StatusBarControlsArea1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarControlsArea1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarControlsArea1.Name = "StatusBarControlsArea1"
      Me.StatusBarControlsArea1.Size = New System.Drawing.Size(134, 22)
      Me.StatusBarControlsArea1.TabIndex = 0
      '
      'StatusBarPane4
      '
      Me.StatusBarPane4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.StatusBarPane4.Controls.Add(Me.eui_lblStatoTotaleDoc)
      Me.StatusBarPane4.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarPane4.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane4.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane4.Name = "StatusBarPane4"
      Me.StatusBarPane4.Size = New System.Drawing.Size(82, 22)
      Me.StatusBarPane4.TabIndex = 2
      '
      'eui_lblStatoTotaleDoc
      '
      Me.eui_lblStatoTotaleDoc.Location = New System.Drawing.Point(5, 5)
      Me.eui_lblStatoTotaleDoc.Name = "eui_lblStatoTotaleDoc"
      Me.eui_lblStatoTotaleDoc.ScreenTip.Text = "Totale conto"
      Me.eui_lblStatoTotaleDoc.Size = New System.Drawing.Size(48, 13)
      Me.eui_lblStatoTotaleDoc.TabIndex = 0
      Me.eui_lblStatoTotaleDoc.Text = "1.2045,00"
      '
      'eui_cmdAnteprima
      '
      Me.eui_cmdAnteprima.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdAnteprima.Id = "a24f06e9-0d6d-457c-a692-06d6a31b5a4c"
      Me.eui_cmdAnteprima.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdAnteprima.Location = New System.Drawing.Point(706, 28)
      Me.eui_cmdAnteprima.Name = "eui_cmdAnteprima"
      Me.eui_cmdAnteprima.ScreenTip.Caption = "Anteprima"
      Me.eui_cmdAnteprima.ScreenTip.Text = "Salva e visualizza l'anteprima del documento."
      Me.eui_cmdAnteprima.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdAnteprima.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdAnteprima.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdAnteprima.TabIndex = 7
      Me.eui_cmdAnteprima.Text = "Anteprima e stampa..."
      Me.eui_cmdAnteprima.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdEmetti
      '
      Me.eui_cmdEmetti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdEmetti.Id = "61543a85-ab7b-43e0-8dda-63529664b486"
      Me.eui_cmdEmetti.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdEmetti.Location = New System.Drawing.Point(706, 176)
      Me.eui_cmdEmetti.Name = "eui_cmdEmetti"
      Me.eui_cmdEmetti.ScreenTip.Caption = "Emetti"
      Me.eui_cmdEmetti.ScreenTip.Text = "Salva ed emette il documento eseguendo le operazioni contabili."
      Me.eui_cmdEmetti.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdEmetti.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdEmetti.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdEmetti.TabIndex = 10
      Me.eui_cmdEmetti.Text = "Emetti"
      Me.eui_cmdEmetti.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Id = "d2bb7da2-7c9a-4b81-aa16-2c2fd422f903"
      Me.eui_cmdAnnulla.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(706, 352)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.ScreenTip.Caption = "Esci"
      Me.eui_cmdAnnulla.ScreenTip.Text = "Annula le modifiche e chiude il documento."
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdAnnulla.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdAnnulla.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdAnnulla.TabIndex = 6
      Me.eui_cmdAnnulla.Text = "Esci"
      Me.eui_cmdAnnulla.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdSalva
      '
      Me.eui_cmdSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdSalva.Id = "2111b041-6033-4a54-af47-7da5c5a57e2b"
      Me.eui_cmdSalva.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdSalva.Location = New System.Drawing.Point(706, 279)
      Me.eui_cmdSalva.Name = "eui_cmdSalva"
      Me.eui_cmdSalva.ScreenTip.Caption = "Salva"
      Me.eui_cmdSalva.ScreenTip.Text = "Salva il documento."
      Me.eui_cmdSalva.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdSalva.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdSalva.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdSalva.TabIndex = 5
      Me.eui_cmdSalva.Text = "Salva"
      Me.eui_cmdSalva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_txtSconto
      '
      Me.eui_txtSconto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.eui_txtSconto.Id = "bff966b8-cb34-4234-96d6-3d92f169b3d2"
      Me.eui_txtSconto.Location = New System.Drawing.Point(81, 532)
      Me.eui_txtSconto.Name = "eui_txtSconto"
      Me.eui_txtSconto.Size = New System.Drawing.Size(64, 21)
      Me.eui_txtSconto.TabIndex = 1
      Me.eui_txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtSconto.TextEditorWidth = 58
      Me.eui_txtSconto.Visible = False
      '
      'eui_txtServizio
      '
      Me.eui_txtServizio.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.eui_txtServizio.Id = "95b58821-86a3-401d-8984-ecca4d27aaaa"
      Me.eui_txtServizio.Location = New System.Drawing.Point(9, 532)
      Me.eui_txtServizio.Name = "eui_txtServizio"
      Me.eui_txtServizio.Size = New System.Drawing.Size(64, 21)
      Me.eui_txtServizio.TabIndex = 0
      Me.eui_txtServizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtServizio.TextEditorWidth = 90
      Me.eui_txtServizio.Visible = False
      '
      'Label14
      '
      Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label14.Location = New System.Drawing.Point(81, 516)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(56, 16)
      Me.Label14.TabIndex = 35
      Me.Label14.Text = "Sconto:"
      Me.Label14.Visible = False
      '
      'Label15
      '
      Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label15.Location = New System.Drawing.Point(9, 516)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(53, 13)
      Me.Label15.TabIndex = 34
      Me.Label15.Text = "Servizio:"
      Me.Label15.Visible = False
      '
      'eui_txtImposta
      '
      Me.eui_txtImposta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtImposta.Id = "47893f1f-16cc-4c5c-9f18-80cc5dfafc75"
      Me.eui_txtImposta.Location = New System.Drawing.Point(428, 533)
      Me.eui_txtImposta.Name = "eui_txtImposta"
      Me.eui_txtImposta.Size = New System.Drawing.Size(124, 21)
      Me.eui_txtImposta.TabIndex = 3
      Me.eui_txtImposta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtImposta.TextEditorWidth = 118
      '
      'eui_txtImponibile
      '
      Me.eui_txtImponibile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtImponibile.Id = "db7f65dd-91d0-44b9-81e5-988cf080c183"
      Me.eui_txtImponibile.Location = New System.Drawing.Point(295, 533)
      Me.eui_txtImponibile.Name = "eui_txtImponibile"
      Me.eui_txtImponibile.Size = New System.Drawing.Size(124, 21)
      Me.eui_txtImponibile.TabIndex = 2
      Me.eui_txtImponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtImponibile.TextEditorWidth = 118
      '
      'Label16
      '
      Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label16.Location = New System.Drawing.Point(428, 517)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(56, 16)
      Me.Label16.TabIndex = 39
      Me.Label16.Text = "Imposta:"
      '
      'Label17
      '
      Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label17.Location = New System.Drawing.Point(295, 517)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(56, 16)
      Me.Label17.TabIndex = 38
      Me.Label17.Text = "Imponibile:"
      '
      'eui_txtTotaleDocumento
      '
      Me.eui_txtTotaleDocumento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtTotaleDocumento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTotaleDocumento.Id = "95402abc-858c-4074-bcbe-42aba8a8657b"
      Me.eui_txtTotaleDocumento.Location = New System.Drawing.Point(563, 533)
      Me.eui_txtTotaleDocumento.Name = "eui_txtTotaleDocumento"
      Me.eui_txtTotaleDocumento.Size = New System.Drawing.Size(124, 21)
      Me.eui_txtTotaleDocumento.TabIndex = 4
      Me.eui_txtTotaleDocumento.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotaleDocumento.TextEditorWidth = 118
      '
      'Label18
      '
      Me.Label18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label18.Location = New System.Drawing.Point(563, 517)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(56, 16)
      Me.Label18.TabIndex = 42
      Me.Label18.Text = "Totale:"
      '
      'eui_cmdStampa
      '
      Me.eui_cmdStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdStampa.Id = "3f5dd41d-365c-44ff-9339-5f43d19c42a9"
      Me.eui_cmdStampa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdStampa.Location = New System.Drawing.Point(706, 499)
      Me.eui_cmdStampa.Name = "eui_cmdStampa"
      Me.eui_cmdStampa.ScreenTip.Caption = "Stampa"
      Me.eui_cmdStampa.ScreenTip.Text = "Salva e stampa il documento."
      Me.eui_cmdStampa.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdStampa.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdStampa.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdStampa.TabIndex = 8
      Me.eui_cmdStampa.Text = "Stampa..."
      Me.eui_cmdStampa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.eui_cmdStampa.Visible = False
      '
      'eui_cmdEmettiStampa
      '
      Me.eui_cmdEmettiStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdEmettiStampa.Id = "39cac427-b8a2-4ffc-8fc8-a532a1f414e9"
      Me.eui_cmdEmettiStampa.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.eui_cmdEmettiStampa.Location = New System.Drawing.Point(706, 102)
      Me.eui_cmdEmettiStampa.Name = "eui_cmdEmettiStampa"
      Me.eui_cmdEmettiStampa.ScreenTip.Caption = "Emetti"
      Me.eui_cmdEmettiStampa.ScreenTip.Text = "Salva, stampa ed emette il documento eseguendo le operazioni contabili."
      Me.eui_cmdEmettiStampa.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdEmettiStampa.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdEmettiStampa.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdEmettiStampa.TabIndex = 9
      Me.eui_cmdEmettiStampa.Text = "Emetti e stampa..."
      Me.eui_cmdEmettiStampa.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdTastiera.Id = "03b32c49-16f5-47ce-837d-3771218e7e99"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(706, 423)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(129, 65)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 11
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'frmDocumento
      '
      Me.AcceptButton = Me.eui_cmdSalva
      Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
      Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(884, 642)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.eui_cmdEmettiStampa)
      Me.Controls.Add(Me.eui_txtTotaleDocumento)
      Me.Controls.Add(Me.Label18)
      Me.Controls.Add(Me.eui_txtImposta)
      Me.Controls.Add(Me.eui_txtImponibile)
      Me.Controls.Add(Me.Label16)
      Me.Controls.Add(Me.Label17)
      Me.Controls.Add(Me.eui_txtSconto)
      Me.Controls.Add(Me.eui_txtServizio)
      Me.Controls.Add(Me.Label14)
      Me.Controls.Add(Me.Label15)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdSalva)
      Me.Controls.Add(Me.eui_cmdEmetti)
      Me.Controls.Add(Me.eui_cmdAnteprima)
      Me.Controls.Add(Me.StatusBar1)
      Me.Controls.Add(Me.eui_tpcDocumento)
      Me.Controls.Add(Me.eui_cmdStampa)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmDocumento"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Conto"
      CType(Me.eui_tpcDocumento, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_tpPA.ResumeLayout(False)
      Me.eui_tpPA.PerformLayout()
      Me.eui_tpGenerale.ResumeLayout(False)
      Me.eui_tpGenerale.PerformLayout()
      Me.eui_tpDettagli.ResumeLayout(False)
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.dgvDettagli, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_tpTotali.ResumeLayout(False)
      Me.eui_tpTotali.PerformLayout()
      Me.eui_tpNote.ResumeLayout(False)
      Me.eui_tpNote.PerformLayout()
      CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.StatusBar1.ResumeLayout(False)
      Me.StatusBar1.PerformLayout()
      Me.StatusBarNotificationsArea1.ResumeLayout(False)
      Me.StatusBarNotificationsArea1.PerformLayout()
      Me.StatusBarPane2.ResumeLayout(False)
      Me.StatusBarPane2.PerformLayout()
      Me.StatusBarPane5.ResumeLayout(False)
      Me.StatusBarPane5.PerformLayout()
      Me.StatusBarPane1.ResumeLayout(False)
      Me.StatusBarPane1.PerformLayout()
      Me.StatusBarControlsArea1.ResumeLayout(False)
      Me.StatusBarControlsArea1.PerformLayout()
      Me.StatusBarPane4.ResumeLayout(False)
      Me.StatusBarPane4.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents StatusBar1 As Elegant.Ui.StatusBar
   Friend WithEvents StatusBarNotificationsArea1 As Elegant.Ui.StatusBarNotificationsArea
   Friend WithEvents StatusBarPane2 As Elegant.Ui.StatusBarPane
   Friend WithEvents StatusBarControlsArea1 As Elegant.Ui.StatusBarControlsArea
   Friend WithEvents eui_tpcDocumento As Elegant.Ui.TabControl
   Friend WithEvents eui_tpGenerale As Elegant.Ui.TabPage
   Friend WithEvents eui_tpDettagli As Elegant.Ui.TabPage
   Friend WithEvents eui_tpNote As Elegant.Ui.TabPage
   Friend WithEvents eui_cmdEmetti As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnteprima As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdSalva As Elegant.Ui.Button
   Friend WithEvents dgvDettagli As System.Windows.Forms.DataGridView
   Friend WithEvents eui_cmbStatoDocumento As Elegant.Ui.ComboBox
   Friend WithEvents Label2 As Elegant.Ui.Label
   Friend WithEvents eui_cmbTipoDocumento As Elegant.Ui.ComboBox
   Friend WithEvents Label1 As Elegant.Ui.Label
   Friend WithEvents eui_dtpData As Elegant.Ui.DateTimePicker
   Friend WithEvents eui_txtAnno As Elegant.Ui.TextBox
   Friend WithEvents eui_txtNumero As Elegant.Ui.TextBox
   Friend WithEvents Label4 As Elegant.Ui.Label
   Friend WithEvents Label3 As Elegant.Ui.Label
   Friend WithEvents eui_cmbCausaleDocumento As Elegant.Ui.ComboBox
   Friend WithEvents Label5 As Elegant.Ui.Label
   Friend WithEvents eui_txtProvincia As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCap As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCittà As Elegant.Ui.TextBox
   Friend WithEvents eui_txtIndirizzo As Elegant.Ui.TextBox
   Friend WithEvents Label10 As Elegant.Ui.Label
   Friend WithEvents Label9 As Elegant.Ui.Label
   Friend WithEvents Label8 As Elegant.Ui.Label
   Friend WithEvents Label7 As Elegant.Ui.Label
   Friend WithEvents eui_txtClienteNome As Elegant.Ui.TextBox
   Friend WithEvents eui_cmbClienteCognome As Elegant.Ui.ComboBox
   Friend WithEvents Label6 As Elegant.Ui.Label
   Friend WithEvents eui_cmbTipoPagamento As Elegant.Ui.ComboBox
   Friend WithEvents Label13 As Elegant.Ui.Label
   Friend WithEvents eui_txtCodiceFiscale As Elegant.Ui.TextBox
   Friend WithEvents eui_txtPartitaIva As Elegant.Ui.TextBox
   Friend WithEvents Label11 As Elegant.Ui.Label
   Friend WithEvents Label12 As Elegant.Ui.Label
   Friend WithEvents eui_txtNote As Elegant.Ui.TextBox
   Friend WithEvents eui_txtSconto As Elegant.Ui.TextBox
   Friend WithEvents eui_txtServizio As Elegant.Ui.TextBox
   Friend WithEvents Label14 As Elegant.Ui.Label
   Friend WithEvents Label15 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaleDocumento As Elegant.Ui.TextBox
   Friend WithEvents Label18 As Elegant.Ui.Label
   Friend WithEvents eui_txtImposta As Elegant.Ui.TextBox
   Friend WithEvents eui_txtImponibile As Elegant.Ui.TextBox
   Friend WithEvents Label16 As Elegant.Ui.Label
   Friend WithEvents Label17 As Elegant.Ui.Label
   Friend WithEvents eui_cmdStampa As Elegant.Ui.Button
   Friend WithEvents eui_tpTotali As Elegant.Ui.TabPage
   Friend WithEvents eui_cmdEmettiStampa As Elegant.Ui.Button
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
   Friend WithEvents eui_txtTotaliSconto As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTotaliServizio As Elegant.Ui.TextBox
   Friend WithEvents Label22 As Elegant.Ui.Label
   Friend WithEvents Label23 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaleConto As Elegant.Ui.TextBox
   Friend WithEvents Label19 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaleImposta As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTotaliImponibile As Elegant.Ui.TextBox
   Friend WithEvents Label20 As Elegant.Ui.Label
   Friend WithEvents Label21 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaliBuoni As Elegant.Ui.TextBox
   Friend WithEvents Label25 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaliContanti As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTotaliCarte As Elegant.Ui.TextBox
   Friend WithEvents Label26 As Elegant.Ui.Label
   Friend WithEvents Label27 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaliCoperto As Elegant.Ui.TextBox
   Friend WithEvents Label24 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaliSospeso As Elegant.Ui.TextBox
   Friend WithEvents Label28 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaliRep1Imposta As Elegant.Ui.TextBox
   Friend WithEvents Label29 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaliRep1Aliquota As Elegant.Ui.TextBox
   Friend WithEvents Label30 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaliRep1ImponibileLordo As Elegant.Ui.TextBox
   Friend WithEvents Label31 As Elegant.Ui.Label
   Friend WithEvents Label33 As Elegant.Ui.Label
   Friend WithEvents Label36 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaliRep4Imposta As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTotaliRep4Aliquota As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTotaliRep4ImponibileLordo As Elegant.Ui.TextBox
   Friend WithEvents Label35 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaliRep3Imposta As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTotaliRep3Aliquota As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTotaliRep3ImponibileLordo As Elegant.Ui.TextBox
   Friend WithEvents Label34 As Elegant.Ui.Label
   Friend WithEvents eui_txtTotaliRep2Imposta As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTotaliRep2Aliquota As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTotaliRep2ImponibileLordo As Elegant.Ui.TextBox
   Friend WithEvents eui_lblStatoNumeroDoc As Elegant.Ui.Label
   Friend WithEvents StatusBarPane5 As Elegant.Ui.StatusBarPane
   Friend WithEvents eui_lblStatoDataDoc As Elegant.Ui.Label
   Friend WithEvents StatusBarPane1 As Elegant.Ui.StatusBarPane
   Friend WithEvents eui_lblStatoClienteDoc As Elegant.Ui.Label
   Friend WithEvents StatusBarPane4 As Elegant.Ui.StatusBarPane
   Friend WithEvents eui_lblStatoTotaleDoc As Elegant.Ui.Label
   Friend WithEvents eui_txtOra As Elegant.Ui.TextBox
   Friend WithEvents eui_cmdModificaCliente As Elegant.Ui.Button
   Friend WithEvents eui_cmbIdCliente As Elegant.Ui.ComboBox
   Friend WithEvents Label41 As Elegant.Ui.Label
   Friend WithEvents eui_cmdNuovoCliente As Elegant.Ui.Button
   Friend WithEvents eui_txtIdCliente As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCameriere As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTavolo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtNumProgressivo As Elegant.Ui.TextBox
   Friend WithEvents DropDown1 As Elegant.Ui.DropDown
   Friend WithEvents PopupMenu2 As Elegant.Ui.PopupMenu
   Friend WithEvents Button1 As Elegant.Ui.Button
   Friend WithEvents Button2 As Elegant.Ui.Button
   Friend WithEvents Button3 As Elegant.Ui.Button
   Friend WithEvents Button4 As Elegant.Ui.Button
   Friend WithEvents PopupMenu1 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdInsPiatti As Elegant.Ui.Button
   Friend WithEvents eui_cmdInsProdotti As Elegant.Ui.Button
   Friend WithEvents Separator2 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdInsAccessori As Elegant.Ui.Button
   Friend WithEvents eui_cmdEliminaRiga As Elegant.Ui.Button
   Friend WithEvents eui_cmdNuovaRiga As Elegant.Ui.Button
   Friend WithEvents eui_cmdCancellaTutto As Elegant.Ui.Button
   Friend WithEvents eui_cmdInsiServizi As Elegant.Ui.Button
   Friend WithEvents eui_cmdImportaDoc As Elegant.Ui.Button
   Friend WithEvents clnCodice As DataGridViewTextBoxColumn
   Friend WithEvents clnDescrizione As DataGridViewTextBoxColumn
   Friend WithEvents clnUm As DataGridViewTextBoxColumn
   Friend WithEvents clnQta As DataGridViewTextBoxColumn
   Friend WithEvents clnPrezzo As DataGridViewTextBoxColumn
   Friend WithEvents clnSconto As DataGridViewTextBoxColumn
   Friend WithEvents clnImporto As DataGridViewTextBoxColumn
   Friend WithEvents clnIva As DataGridViewTextBoxColumn
   Friend WithEvents clnRepartoIva As DataGridViewTextBoxColumn
   Friend WithEvents clnValoreSconto As DataGridViewTextBoxColumn
   Friend WithEvents clnCategoria As DataGridViewTextBoxColumn
   Friend WithEvents eui_tpPA As Elegant.Ui.TabPage
   Friend WithEvents Label40 As Elegant.Ui.Label
   Friend WithEvents eui_txtNumeroDoc_PA As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCodiceCommConv_PA As Elegant.Ui.TextBox
   Friend WithEvents Label32 As Elegant.Ui.Label
   Friend WithEvents Label37 As Elegant.Ui.Label
   Friend WithEvents eui_txtCodiceCIG_PA As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCodiceCUP_PA As Elegant.Ui.TextBox
   Friend WithEvents Label38 As Elegant.Ui.Label
   Friend WithEvents Label39 As Elegant.Ui.Label
End Class
