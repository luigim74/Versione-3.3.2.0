Public Class AsportoPOS
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"
   Const TAB_CONTI_TAVOLI As String = "ContiTavoli"

   Private CConvalida As New ConvalidaKeyPress
   Private AContiTavoli As New ContiTavoli

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label19 As System.Windows.Forms.Label
   Public WithEvents Label16 As System.Windows.Forms.Label
   Public WithEvents txtIdAzienda As System.Windows.Forms.TextBox
   Public WithEvents txtIdCliente As System.Windows.Forms.TextBox
   Public WithEvents txtIva As System.Windows.Forms.TextBox
   Public WithEvents txtPIva As System.Windows.Forms.TextBox
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents txtIndirizzo As System.Windows.Forms.TextBox
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents Label31 As System.Windows.Forms.Label
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents txtValSconto As System.Windows.Forms.TextBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents txtCodiceFiscale As TextBox
   Public WithEvents Label20 As Label
   Friend WithEvents eui_cmdCliente As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button
   Public WithEvents Label7 As Label
   Friend WithEvents dtpOraOrdine As DateTimePicker
   Friend WithEvents dtpDataOrdine As DateTimePicker
   Public WithEvents Label6 As Label
   Friend WithEvents eui_txtNote As Elegant.Ui.TextBox
   Public WithEvents Label8 As Label
   Public WithEvents Label10 As Label
   Public WithEvents Label9 As Label
   Friend WithEvents eui_cmdMenoMezzora As Elegant.Ui.Button
   Friend WithEvents eui_cmdPiùMezzora As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre24 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre23 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre22 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre21 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre20 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre19 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre18 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre14 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre13 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre12 As Elegant.Ui.Button
   Friend WithEvents eui_cmdOre11 As Elegant.Ui.Button
   Friend WithEvents eui_cmdMenoGiorno As Elegant.Ui.Button
   Friend WithEvents eui_cmdPiùGiorno As Elegant.Ui.Button
   Friend WithEvents eui_cmdDomani As Elegant.Ui.Button
   Friend WithEvents eui_cmdOggi As Elegant.Ui.Button
   Friend WithEvents dtpOraRitiroOrdine As DateTimePicker
   Friend WithEvents dtpDataRitiroOrdine As DateTimePicker
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button

#End Region

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
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AsportoPOS))
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.txtIdAzienda = New System.Windows.Forms.TextBox()
      Me.txtIdCliente = New System.Windows.Forms.TextBox()
      Me.txtIva = New System.Windows.Forms.TextBox()
      Me.txtPIva = New System.Windows.Forms.TextBox()
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtIndirizzo = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtValSconto = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtCodiceFiscale = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.eui_cmdCliente = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.dtpDataOrdine = New System.Windows.Forms.DateTimePicker()
      Me.dtpOraOrdine = New System.Windows.Forms.DateTimePicker()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.eui_txtNote = New Elegant.Ui.TextBox()
      Me.dtpOraRitiroOrdine = New System.Windows.Forms.DateTimePicker()
      Me.dtpDataRitiroOrdine = New System.Windows.Forms.DateTimePicker()
      Me.eui_cmdOggi = New Elegant.Ui.Button()
      Me.eui_cmdDomani = New Elegant.Ui.Button()
      Me.eui_cmdPiùGiorno = New Elegant.Ui.Button()
      Me.eui_cmdMenoGiorno = New Elegant.Ui.Button()
      Me.eui_cmdOre11 = New Elegant.Ui.Button()
      Me.eui_cmdOre12 = New Elegant.Ui.Button()
      Me.eui_cmdOre13 = New Elegant.Ui.Button()
      Me.eui_cmdOre14 = New Elegant.Ui.Button()
      Me.eui_cmdOre21 = New Elegant.Ui.Button()
      Me.eui_cmdOre20 = New Elegant.Ui.Button()
      Me.eui_cmdOre19 = New Elegant.Ui.Button()
      Me.eui_cmdOre18 = New Elegant.Ui.Button()
      Me.eui_cmdOre24 = New Elegant.Ui.Button()
      Me.eui_cmdOre23 = New Elegant.Ui.Button()
      Me.eui_cmdOre22 = New Elegant.Ui.Button()
      Me.eui_cmdPiùMezzora = New Elegant.Ui.Button()
      Me.eui_cmdMenoMezzora = New Elegant.Ui.Button()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.SuspendLayout()
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(12, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(102, 24)
      Me.Label1.TabIndex = 7
      Me.Label1.Text = "CLIENTE:"
      '
      'Label19
      '
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(950, 136)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(112, 24)
      Me.Label19.TabIndex = 272
      Me.Label19.Text = "ID AZIENDA:"
      Me.Label19.Visible = False
      '
      'Label16
      '
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(702, 136)
      Me.Label16.Name = "Label16"
      Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label16.Size = New System.Drawing.Size(144, 24)
      Me.Label16.TabIndex = 271
      Me.Label16.Text = "ID CLIENTE:"
      Me.Label16.Visible = False
      '
      'txtIdAzienda
      '
      Me.txtIdAzienda.AcceptsReturn = True
      Me.txtIdAzienda.BackColor = System.Drawing.SystemColors.Window
      Me.txtIdAzienda.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIdAzienda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIdAzienda.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIdAzienda.Location = New System.Drawing.Point(1078, 136)
      Me.txtIdAzienda.MaxLength = 100
      Me.txtIdAzienda.Name = "txtIdAzienda"
      Me.txtIdAzienda.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIdAzienda.Size = New System.Drawing.Size(64, 29)
      Me.txtIdAzienda.TabIndex = 270
      Me.txtIdAzienda.Visible = False
      '
      'txtIdCliente
      '
      Me.txtIdCliente.AcceptsReturn = True
      Me.txtIdCliente.BackColor = System.Drawing.SystemColors.Window
      Me.txtIdCliente.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIdCliente.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIdCliente.Location = New System.Drawing.Point(854, 136)
      Me.txtIdCliente.MaxLength = 100
      Me.txtIdCliente.Name = "txtIdCliente"
      Me.txtIdCliente.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIdCliente.Size = New System.Drawing.Size(64, 29)
      Me.txtIdCliente.TabIndex = 269
      Me.txtIdCliente.Visible = False
      '
      'txtIva
      '
      Me.txtIva.AcceptsReturn = True
      Me.txtIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIva.Location = New System.Drawing.Point(1062, 96)
      Me.txtIva.MaxLength = 10
      Me.txtIva.Name = "txtIva"
      Me.txtIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIva.Size = New System.Drawing.Size(80, 29)
      Me.txtIva.TabIndex = 264
      Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtIva.Visible = False
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(854, 96)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(144, 29)
      Me.txtPIva.TabIndex = 263
      Me.txtPIva.Visible = False
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(1110, 56)
      Me.txtProv.MaxLength = 2
      Me.txtProv.Name = "txtProv"
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(32, 29)
      Me.txtProv.TabIndex = 262
      Me.txtProv.Visible = False
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(854, 56)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(64, 29)
      Me.txtCap.TabIndex = 260
      Me.txtCap.Visible = False
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(926, 56)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(176, 29)
      Me.txtCittà.TabIndex = 261
      Me.txtCittà.Visible = False
      '
      'txtIndirizzo
      '
      Me.txtIndirizzo.AcceptsReturn = True
      Me.txtIndirizzo.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIndirizzo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo.Location = New System.Drawing.Point(854, 16)
      Me.txtIndirizzo.MaxLength = 100
      Me.txtIndirizzo.Name = "txtIndirizzo"
      Me.txtIndirizzo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo.Size = New System.Drawing.Size(288, 29)
      Me.txtIndirizzo.TabIndex = 259
      Me.txtIndirizzo.Visible = False
      '
      'Label11
      '
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(1006, 104)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(56, 24)
      Me.Label11.TabIndex = 268
      Me.Label11.Text = "% IVA:"
      Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
      Me.Label11.Visible = False
      '
      'Label31
      '
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(702, 104)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(144, 24)
      Me.Label31.TabIndex = 267
      Me.Label31.Text = "PARTIVA IVA:"
      Me.Label31.Visible = False
      '
      'Label2
      '
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(702, 64)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(144, 24)
      Me.Label2.TabIndex = 266
      Me.Label2.Text = "CAP/CITTA'/PROV.:"
      Me.Label2.Visible = False
      '
      'Label4
      '
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(702, 24)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(144, 24)
      Me.Label4.TabIndex = 265
      Me.Label4.Text = "INDIRIZZO:"
      Me.Label4.Visible = False
      '
      'txtValSconto
      '
      Me.txtValSconto.AcceptsReturn = True
      Me.txtValSconto.BackColor = System.Drawing.SystemColors.Window
      Me.txtValSconto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtValSconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtValSconto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtValSconto.Location = New System.Drawing.Point(854, 176)
      Me.txtValSconto.MaxLength = 100
      Me.txtValSconto.Name = "txtValSconto"
      Me.txtValSconto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtValSconto.Size = New System.Drawing.Size(96, 29)
      Me.txtValSconto.TabIndex = 273
      Me.txtValSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtValSconto.Visible = False
      '
      'Label3
      '
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(702, 184)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(152, 18)
      Me.Label3.TabIndex = 274
      Me.Label3.Text = "SCONTO:"
      Me.Label3.Visible = False
      '
      'txtCodiceFiscale
      '
      Me.txtCodiceFiscale.AcceptsReturn = True
      Me.txtCodiceFiscale.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodiceFiscale.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodiceFiscale.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodiceFiscale.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodiceFiscale.Location = New System.Drawing.Point(854, 211)
      Me.txtCodiceFiscale.MaxLength = 11
      Me.txtCodiceFiscale.Name = "txtCodiceFiscale"
      Me.txtCodiceFiscale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodiceFiscale.Size = New System.Drawing.Size(144, 29)
      Me.txtCodiceFiscale.TabIndex = 276
      Me.txtCodiceFiscale.Visible = False
      '
      'Label20
      '
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(702, 219)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(144, 24)
      Me.Label20.TabIndex = 277
      Me.Label20.Text = "CODICE FISCALE:"
      Me.Label20.Visible = False
      '
      'eui_cmdCliente
      '
      Me.eui_cmdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdCliente.Id = "90b30357-575c-427d-b421-ff37e3bc0159"
      Me.eui_cmdCliente.Location = New System.Drawing.Point(14, 40)
      Me.eui_cmdCliente.Name = "eui_cmdCliente"
      Me.eui_cmdCliente.Size = New System.Drawing.Size(616, 40)
      Me.eui_cmdCliente.TabIndex = 0
      Me.eui_cmdCliente.Text = "Seleziona cliente"
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "731a82e5-f70c-4ddf-b28b-f1ffa872b5a8"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(276, 518)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 8
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOk.Id = "81a66019-7a4d-49cb-99a0-096b15af1ba0"
      Me.eui_cmdOk.Location = New System.Drawing.Point(138, 518)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdOk.TabIndex = 7
      Me.eui_cmdOk.Text = "&OK"
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Id = "27ea13ed-7109-46ec-b3b4-043242846473"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(14, 518)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(75, 53)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 6
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(12, 95)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(217, 24)
      Me.Label6.TabIndex = 278
      Me.Label6.Text = "DATA / ORA ORDINE:"
      '
      'dtpDataOrdine
      '
      Me.dtpDataOrdine.Enabled = False
      Me.dtpDataOrdine.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpDataOrdine.Location = New System.Drawing.Point(14, 122)
      Me.dtpDataOrdine.Name = "dtpDataOrdine"
      Me.dtpDataOrdine.Size = New System.Drawing.Size(284, 29)
      Me.dtpDataOrdine.TabIndex = 1
      '
      'dtpOraOrdine
      '
      Me.dtpOraOrdine.Enabled = False
      Me.dtpOraOrdine.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpOraOrdine.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpOraOrdine.Location = New System.Drawing.Point(304, 122)
      Me.dtpOraOrdine.Name = "dtpOraOrdine"
      Me.dtpOraOrdine.ShowUpDown = True
      Me.dtpOraOrdine.Size = New System.Drawing.Size(100, 29)
      Me.dtpOraOrdine.TabIndex = 2
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(12, 170)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(350, 24)
      Me.Label7.TabIndex = 281
      Me.Label7.Text = "DATA / ORA RITIRO O CONSEGNA:"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(12, 241)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(74, 24)
      Me.Label8.TabIndex = 284
      Me.Label8.Text = "NOTE:"
      '
      'eui_txtNote
      '
      Me.eui_txtNote.AcceptsReturn = True
      Me.eui_txtNote.AcceptsTab = True
      Me.eui_txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtNote.Id = "8533b42e-990c-48ee-9adc-b71f28b64836"
      Me.eui_txtNote.Location = New System.Drawing.Point(14, 265)
      Me.eui_txtNote.Multiline = True
      Me.eui_txtNote.Name = "eui_txtNote"
      Me.eui_txtNote.Size = New System.Drawing.Size(390, 240)
      Me.eui_txtNote.TabIndex = 5
      Me.eui_txtNote.TextEditorWidth = 384
      '
      'dtpOraRitiroOrdine
      '
      Me.dtpOraRitiroOrdine.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpOraRitiroOrdine.Format = System.Windows.Forms.DateTimePickerFormat.Time
      Me.dtpOraRitiroOrdine.Location = New System.Drawing.Point(306, 197)
      Me.dtpOraRitiroOrdine.Name = "dtpOraRitiroOrdine"
      Me.dtpOraRitiroOrdine.ShowUpDown = True
      Me.dtpOraRitiroOrdine.Size = New System.Drawing.Size(100, 29)
      Me.dtpOraRitiroOrdine.TabIndex = 4
      Me.dtpOraRitiroOrdine.Value = New Date(2016, 1, 2, 9, 38, 0, 0)
      '
      'dtpDataRitiroOrdine
      '
      Me.dtpDataRitiroOrdine.Enabled = False
      Me.dtpDataRitiroOrdine.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpDataRitiroOrdine.Location = New System.Drawing.Point(14, 197)
      Me.dtpDataRitiroOrdine.Name = "dtpDataRitiroOrdine"
      Me.dtpDataRitiroOrdine.Size = New System.Drawing.Size(286, 29)
      Me.dtpDataRitiroOrdine.TabIndex = 3
      '
      'eui_cmdOggi
      '
      Me.eui_cmdOggi.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOggi.Id = "646743ce-2ec0-4faf-9d5c-902aea655759"
      Me.eui_cmdOggi.Location = New System.Drawing.Point(427, 119)
      Me.eui_cmdOggi.Name = "eui_cmdOggi"
      Me.eui_cmdOggi.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOggi.TabIndex = 9
      Me.eui_cmdOggi.Text = "Oggi"
      '
      'eui_cmdDomani
      '
      Me.eui_cmdDomani.Enabled = False
      Me.eui_cmdDomani.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdDomani.Id = "bcc4fd55-bfab-4c1b-a417-35785d1e471d"
      Me.eui_cmdDomani.Location = New System.Drawing.Point(533, 119)
      Me.eui_cmdDomani.Name = "eui_cmdDomani"
      Me.eui_cmdDomani.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdDomani.TabIndex = 10
      Me.eui_cmdDomani.Text = "Domani"
      '
      'eui_cmdPiùGiorno
      '
      Me.eui_cmdPiùGiorno.Enabled = False
      Me.eui_cmdPiùGiorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdPiùGiorno.Id = "70dc3d35-6997-49ec-a883-1f80931a1852"
      Me.eui_cmdPiùGiorno.Location = New System.Drawing.Point(427, 167)
      Me.eui_cmdPiùGiorno.Name = "eui_cmdPiùGiorno"
      Me.eui_cmdPiùGiorno.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdPiùGiorno.TabIndex = 11
      Me.eui_cmdPiùGiorno.Text = "+ Giorno"
      '
      'eui_cmdMenoGiorno
      '
      Me.eui_cmdMenoGiorno.Enabled = False
      Me.eui_cmdMenoGiorno.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdMenoGiorno.Id = "3197e4aa-b4f2-4ee0-b65b-a6a5d012167b"
      Me.eui_cmdMenoGiorno.Location = New System.Drawing.Point(533, 166)
      Me.eui_cmdMenoGiorno.Name = "eui_cmdMenoGiorno"
      Me.eui_cmdMenoGiorno.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdMenoGiorno.TabIndex = 12
      Me.eui_cmdMenoGiorno.Text = "- Giorno"
      '
      'eui_cmdOre11
      '
      Me.eui_cmdOre11.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre11.Id = "6b17cc5c-3679-404d-b796-2a45ce08f77a"
      Me.eui_cmdOre11.Location = New System.Drawing.Point(427, 247)
      Me.eui_cmdOre11.Name = "eui_cmdOre11"
      Me.eui_cmdOre11.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre11.TabIndex = 13
      Me.eui_cmdOre11.Text = "11:00"
      '
      'eui_cmdOre12
      '
      Me.eui_cmdOre12.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre12.Id = "38663d4f-8f43-4e14-9974-957ca11512a4"
      Me.eui_cmdOre12.Location = New System.Drawing.Point(534, 247)
      Me.eui_cmdOre12.Name = "eui_cmdOre12"
      Me.eui_cmdOre12.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre12.TabIndex = 14
      Me.eui_cmdOre12.Text = "12:00"
      '
      'eui_cmdOre13
      '
      Me.eui_cmdOre13.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre13.Id = "5d6cf948-6197-4805-83e3-1a018f510e5c"
      Me.eui_cmdOre13.Location = New System.Drawing.Point(427, 293)
      Me.eui_cmdOre13.Name = "eui_cmdOre13"
      Me.eui_cmdOre13.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre13.TabIndex = 15
      Me.eui_cmdOre13.Text = "13:00"
      '
      'eui_cmdOre14
      '
      Me.eui_cmdOre14.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre14.Id = "d20b3bf4-15e0-495e-9ceb-69bec3599930"
      Me.eui_cmdOre14.Location = New System.Drawing.Point(534, 293)
      Me.eui_cmdOre14.Name = "eui_cmdOre14"
      Me.eui_cmdOre14.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre14.TabIndex = 16
      Me.eui_cmdOre14.Text = "14:00"
      '
      'eui_cmdOre21
      '
      Me.eui_cmdOre21.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre21.Id = "b5f0cdbd-ec58-45bb-bf52-33f6a0e5654e"
      Me.eui_cmdOre21.Location = New System.Drawing.Point(534, 388)
      Me.eui_cmdOre21.Name = "eui_cmdOre21"
      Me.eui_cmdOre21.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre21.TabIndex = 20
      Me.eui_cmdOre21.Text = "21:00"
      '
      'eui_cmdOre20
      '
      Me.eui_cmdOre20.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre20.Id = "c64613c0-401a-4885-b07e-c80e5ca32467"
      Me.eui_cmdOre20.Location = New System.Drawing.Point(427, 388)
      Me.eui_cmdOre20.Name = "eui_cmdOre20"
      Me.eui_cmdOre20.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre20.TabIndex = 19
      Me.eui_cmdOre20.Text = "20:00"
      '
      'eui_cmdOre19
      '
      Me.eui_cmdOre19.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre19.Id = "7053694b-3c30-4238-b7ea-7b72f389d96c"
      Me.eui_cmdOre19.Location = New System.Drawing.Point(534, 342)
      Me.eui_cmdOre19.Name = "eui_cmdOre19"
      Me.eui_cmdOre19.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre19.TabIndex = 18
      Me.eui_cmdOre19.Text = "19:00"
      '
      'eui_cmdOre18
      '
      Me.eui_cmdOre18.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre18.Id = "65736024-16ed-43e3-90a4-b13832a7bdfe"
      Me.eui_cmdOre18.Location = New System.Drawing.Point(427, 342)
      Me.eui_cmdOre18.Name = "eui_cmdOre18"
      Me.eui_cmdOre18.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre18.TabIndex = 17
      Me.eui_cmdOre18.Text = "18:00"
      '
      'eui_cmdOre24
      '
      Me.eui_cmdOre24.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre24.Id = "22583cb2-227e-4397-961b-a71ee68e4464"
      Me.eui_cmdOre24.Location = New System.Drawing.Point(427, 483)
      Me.eui_cmdOre24.Name = "eui_cmdOre24"
      Me.eui_cmdOre24.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre24.TabIndex = 23
      Me.eui_cmdOre24.Text = "00:00"
      '
      'eui_cmdOre23
      '
      Me.eui_cmdOre23.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre23.Id = "7a5a4ba0-d414-4d3e-af1b-ef6c96ed468f"
      Me.eui_cmdOre23.Location = New System.Drawing.Point(534, 437)
      Me.eui_cmdOre23.Name = "eui_cmdOre23"
      Me.eui_cmdOre23.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre23.TabIndex = 22
      Me.eui_cmdOre23.Text = "23:00"
      '
      'eui_cmdOre22
      '
      Me.eui_cmdOre22.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOre22.Id = "5ccf524b-0b30-4909-871f-19a4c0682a31"
      Me.eui_cmdOre22.Location = New System.Drawing.Point(427, 437)
      Me.eui_cmdOre22.Name = "eui_cmdOre22"
      Me.eui_cmdOre22.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdOre22.TabIndex = 21
      Me.eui_cmdOre22.Text = "22:00"
      '
      'eui_cmdPiùMezzora
      '
      Me.eui_cmdPiùMezzora.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdPiùMezzora.Id = "e6ad6d4d-8989-44b8-911a-b7290f8907a0"
      Me.eui_cmdPiùMezzora.Location = New System.Drawing.Point(427, 531)
      Me.eui_cmdPiùMezzora.Name = "eui_cmdPiùMezzora"
      Me.eui_cmdPiùMezzora.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdPiùMezzora.TabIndex = 24
      Me.eui_cmdPiùMezzora.Text = "+ 1/2"
      '
      'eui_cmdMenoMezzora
      '
      Me.eui_cmdMenoMezzora.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdMenoMezzora.Id = "cd6db9d6-a1bc-4dc0-b6fd-02e74355d55d"
      Me.eui_cmdMenoMezzora.Location = New System.Drawing.Point(534, 531)
      Me.eui_cmdMenoMezzora.Name = "eui_cmdMenoMezzora"
      Me.eui_cmdMenoMezzora.Size = New System.Drawing.Size(97, 40)
      Me.eui_cmdMenoMezzora.TabIndex = 25
      Me.eui_cmdMenoMezzora.Text = "- 1/2"
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(423, 95)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(97, 24)
      Me.Label9.TabIndex = 305
      Me.Label9.Text = "GIORNO:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(424, 223)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(176, 24)
      Me.Label10.TabIndex = 306
      Me.Label10.Text = "PRANZO / CENA:"
      '
      'AsportoPOS
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(642, 585)
      Me.Controls.Add(Me.eui_cmdMenoMezzora)
      Me.Controls.Add(Me.eui_cmdPiùMezzora)
      Me.Controls.Add(Me.eui_cmdOre24)
      Me.Controls.Add(Me.eui_cmdOre23)
      Me.Controls.Add(Me.eui_cmdOre22)
      Me.Controls.Add(Me.eui_cmdOre21)
      Me.Controls.Add(Me.eui_cmdOre20)
      Me.Controls.Add(Me.eui_cmdOre19)
      Me.Controls.Add(Me.eui_cmdOre18)
      Me.Controls.Add(Me.eui_cmdOre14)
      Me.Controls.Add(Me.eui_cmdOre13)
      Me.Controls.Add(Me.eui_cmdOre12)
      Me.Controls.Add(Me.eui_cmdOre11)
      Me.Controls.Add(Me.eui_cmdMenoGiorno)
      Me.Controls.Add(Me.eui_cmdPiùGiorno)
      Me.Controls.Add(Me.eui_cmdDomani)
      Me.Controls.Add(Me.eui_cmdOggi)
      Me.Controls.Add(Me.dtpOraRitiroOrdine)
      Me.Controls.Add(Me.dtpDataRitiroOrdine)
      Me.Controls.Add(Me.eui_txtNote)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.dtpOraOrdine)
      Me.Controls.Add(Me.dtpDataOrdine)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.eui_cmdCliente)
      Me.Controls.Add(Me.txtCodiceFiscale)
      Me.Controls.Add(Me.Label20)
      Me.Controls.Add(Me.txtValSconto)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Label19)
      Me.Controls.Add(Me.Label16)
      Me.Controls.Add(Me.txtIdAzienda)
      Me.Controls.Add(Me.txtIdCliente)
      Me.Controls.Add(Me.txtIva)
      Me.Controls.Add(Me.txtPIva)
      Me.Controls.Add(Me.txtProv)
      Me.Controls.Add(Me.txtCap)
      Me.Controls.Add(Me.txtCittà)
      Me.Controls.Add(Me.txtIndirizzo)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.Label31)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.Label10)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "AsportoPOS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Asporto"
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public Function SalvaDatiClienti(ByVal idTavoloDoc As String) As Boolean
      Try
         With AContiTavoli
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .CodiceTavolo = idTavoloDoc
            .CodiceCliente = txtIdCliente.Text
            .CodiceAzienda = txtIdAzienda.Text
            .Intestatario = eui_cmdCliente.Text
            .Indirizzo = FormattaApici(txtIndirizzo.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .PIva = FormattaApici(txtPIva.Text)
            If IsNumeric(txtValSconto.Text) = True Then
               .Sconto = txtValSconto.Text
            Else
               .Sconto = VALORE_ZERO
            End If
            If IsNumeric(txtIva.Text) = True Then
               .Iva = txtIva.Text
            Else
               .Iva = VALORE_ZERO
            End If

            If VerificaEsistenzaValore(TAB_CONTI_TAVOLI, cn, cmd, "IdTavolo", idTavoloDoc) <> 0 Then
               Return .ModificaDati(TAB_CONTI_TAVOLI, idTavoloDoc)
            Else
               Return .InserisciDati(TAB_CONTI_TAVOLI)
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Sub AsportoPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         Me.Text = "ASPORTO: " & g_frmVCTavoli.lblTavolo.Text

         ' Imposta la data e l'ora corrente per i controlli.
         dtpDataOrdine.Value = Now
         dtpOraOrdine.Value = Now

         dtpDataRitiroOrdine.Value = Now
         dtpOraRitiroOrdine.Value = Now

         dtpOraRitiroOrdine.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdCliente_Click(sender As Object, e As EventArgs) Handles eui_cmdCliente.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New ElencoClientiPos(txtIdCliente.Text, txtIdAzienda.Text)

         frm.Tag = "ASPORTO"

         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      ' Apre la Tastiera virtuale di Windows (XP, 7, 8, 10).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Verifica sulla data.
         If dtpDataRitiroOrdine.Value < dtpDataOrdine.Value Then
            MessageBox.Show("Attenzione! La data di ritiro o consegna dell'ordine è minore della data dell'ordine.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.DialogResult = DialogResult.None
            Exit Sub
         Else
            ' Verifica sull'ora.
            If dtpOraRitiroOrdine.Value < dtpOraOrdine.Value Then
               MessageBox.Show("Attenzione! L'ora di ritiro o consegna dell'ordine è minore dell'ora dell'ordine.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Me.DialogResult = DialogResult.None
               Exit Sub
            Else
               Me.DialogResult = DialogResult.OK
               ' Imposta il numero dei coperti a nessuno.
               NumCopertiRistorante = 0
               Me.Tag = 0
               Me.Close()
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      g_frmVCTavoli.asportoAnnulla = True

      Me.DialogResult = DialogResult.Cancel
      Me.Tag = String.Empty
      Me.Close()
   End Sub

   Private Sub eui_cmdOggi_Click(sender As Object, e As EventArgs) Handles eui_cmdOggi.Click
      Try
         ' Imposta la data di oggi.
         dtpDataRitiroOrdine.Value = Today

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdDomani_Click(sender As Object, e As EventArgs) Handles eui_cmdDomani.Click
      Try
         ' Imposta la data di domani.
         dtpDataRitiroOrdine.Value = Today.AddDays(1)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdPiùGiorno_Click(sender As Object, e As EventArgs) Handles eui_cmdPiùGiorno.Click
      Try
         ' Incrementa la data attuale di un giorno.
         dtpDataRitiroOrdine.Value = dtpDataRitiroOrdine.Value.AddDays(1)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdMenoGiorno_Click(sender As Object, e As EventArgs) Handles eui_cmdMenoGiorno.Click
      Try
         ' Decrementa la data attuale di un giorno.
         dtpDataRitiroOrdine.Value = dtpDataRitiroOrdine.Value.AddDays(-1)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre11_Click(sender As Object, e As EventArgs) Handles eui_cmdOre11.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("11:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre12_Click(sender As Object, e As EventArgs) Handles eui_cmdOre12.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("12:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre13_Click(sender As Object, e As EventArgs) Handles eui_cmdOre13.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("13:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre14_Click(sender As Object, e As EventArgs) Handles eui_cmdOre14.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("14:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre18_Click(sender As Object, e As EventArgs) Handles eui_cmdOre18.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("18:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre19_Click(sender As Object, e As EventArgs) Handles eui_cmdOre19.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("19:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre20_Click(sender As Object, e As EventArgs) Handles eui_cmdOre20.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("20:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre21_Click(sender As Object, e As EventArgs) Handles eui_cmdOre21.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("21:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre22_Click(sender As Object, e As EventArgs) Handles eui_cmdOre22.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("22:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre23_Click(sender As Object, e As EventArgs) Handles eui_cmdOre23.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("23:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOre24_Click(sender As Object, e As EventArgs) Handles eui_cmdOre24.Click
      Try
         ' Imposta l'ora di ritiro o consegna dell'ordine.
         dtpOraRitiroOrdine.Value = Convert.ToDateTime("00:00:00")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdPiùMezzora_Click(sender As Object, e As EventArgs) Handles eui_cmdPiùMezzora.Click
      Try
         ' Incrementa l'ora attuale di mezzora.
         dtpOraRitiroOrdine.Value = dtpOraRitiroOrdine.Value.AddMinutes(30)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdMenoMezzora_Click(sender As Object, e As EventArgs) Handles eui_cmdMenoMezzora.Click
      Try
         ' Incrementa l'ora attuale di mezzora.
         dtpOraRitiroOrdine.Value = dtpOraRitiroOrdine.Value.AddMinutes(-30)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
End Class
