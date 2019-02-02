Public Class CopertiPOS
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"
   Const TAB_CONTI_TAVOLI As String = "ContiTavoli"

   Private CConvalida As New ConvalidaKeyPress
   Private AContiTavoli As New ContiTavoli
   Private numPosti As Integer

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(Sql, cn)

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
   Friend WithEvents eui_cmdPiù As Elegant.Ui.Button
   Friend WithEvents eui_cmdMeno As Elegant.Ui.Button
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
   Friend WithEvents txtNumCoperti As System.Windows.Forms.TextBox
   Public WithEvents Label5 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(CopertiPOS))
      Me.txtNumCoperti = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
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
      Me.eui_cmdMeno = New Elegant.Ui.Button()
      Me.eui_cmdPiù = New Elegant.Ui.Button()
      Me.SuspendLayout()
      '
      'txtNumCoperti
      '
      Me.txtNumCoperti.BackColor = System.Drawing.SystemColors.Window
      Me.txtNumCoperti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtNumCoperti.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumCoperti.ForeColor = System.Drawing.Color.Red
      Me.txtNumCoperti.Location = New System.Drawing.Point(14, 128)
      Me.txtNumCoperti.Name = "txtNumCoperti"
      Me.txtNumCoperti.Size = New System.Drawing.Size(263, 40)
      Me.txtNumCoperti.TabIndex = 1
      Me.txtNumCoperti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(15, 96)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(201, 24)
      Me.Label5.TabIndex = 5
      Me.Label5.Text = "NUMERO COPERTI:"
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
      Me.Label1.Location = New System.Drawing.Point(16, 16)
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
      Me.Label19.Location = New System.Drawing.Point(744, 128)
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
      Me.Label16.Location = New System.Drawing.Point(496, 128)
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
      Me.txtIdAzienda.Location = New System.Drawing.Point(872, 128)
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
      Me.txtIdCliente.Location = New System.Drawing.Point(648, 128)
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
      Me.txtIva.Location = New System.Drawing.Point(856, 88)
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
      Me.txtPIva.Location = New System.Drawing.Point(648, 88)
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
      Me.txtProv.Location = New System.Drawing.Point(904, 48)
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
      Me.txtCap.Location = New System.Drawing.Point(648, 48)
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
      Me.txtCittà.Location = New System.Drawing.Point(720, 48)
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
      Me.txtIndirizzo.Location = New System.Drawing.Point(648, 8)
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
      Me.Label11.Location = New System.Drawing.Point(800, 96)
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
      Me.Label31.Location = New System.Drawing.Point(496, 96)
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
      Me.Label2.Location = New System.Drawing.Point(496, 56)
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
      Me.Label4.Location = New System.Drawing.Point(496, 16)
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
      Me.txtValSconto.Location = New System.Drawing.Point(648, 168)
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
      Me.Label3.Location = New System.Drawing.Point(496, 176)
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
      Me.txtCodiceFiscale.Location = New System.Drawing.Point(648, 203)
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
      Me.Label20.Location = New System.Drawing.Point(496, 211)
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
      Me.eui_cmdCliente.Size = New System.Drawing.Size(440, 40)
      Me.eui_cmdCliente.TabIndex = 0
      Me.eui_cmdCliente.Text = "Seleziona cliente"
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "731a82e5-f70c-4ddf-b28b-f1ffa872b5a8"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(326, 197)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 5
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOk.Id = "81a66019-7a4d-49cb-99a0-096b15af1ba0"
      Me.eui_cmdOk.Location = New System.Drawing.Point(188, 197)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdOk.TabIndex = 4
      Me.eui_cmdOk.Text = "&OK"
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Id = "27ea13ed-7109-46ec-b3b4-043242846473"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(14, 197)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(75, 53)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 6
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdMeno
      '
      Me.eui_cmdMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdMeno.Id = "03c62f70-fab9-408c-8245-b25dd6db1b60"
      Me.eui_cmdMeno.Location = New System.Drawing.Point(293, 128)
      Me.eui_cmdMeno.Name = "eui_cmdMeno"
      Me.eui_cmdMeno.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdMeno.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdMeno.Size = New System.Drawing.Size(75, 40)
      Me.eui_cmdMeno.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdMeno.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdMeno.TabIndex = 2
      '
      'eui_cmdPiù
      '
      Me.eui_cmdPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdPiù.Id = "67c6e8b5-d512-494b-bd9d-00a1c2b7d6f6"
      Me.eui_cmdPiù.Location = New System.Drawing.Point(377, 128)
      Me.eui_cmdPiù.Name = "eui_cmdPiù"
      Me.eui_cmdPiù.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdPiù.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdPiù.Size = New System.Drawing.Size(75, 40)
      Me.eui_cmdPiù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdPiù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdPiù.TabIndex = 3
      '
      'CopertiPOS
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(465, 259)
      Me.Controls.Add(Me.eui_cmdPiù)
      Me.Controls.Add(Me.eui_cmdMeno)
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
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.txtNumCoperti)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "CopertiPOS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Numero coperti"
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

   Private Sub CopertiPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         Me.Text = "TAVOLO: " & g_frmVCTavoli.lblTavolo.Text

         numPosti = Convert.ToInt32(g_frmVCTavoli.lblPosti.Text)
         txtNumCoperti.Text = numPosti.ToString
         txtNumCoperti.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub txtNumCoperti_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCoperti.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub eui_cmdCliente_Click(sender As Object, e As EventArgs) Handles eui_cmdCliente.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New ElencoClientiPos(txtIdCliente.Text, txtIdAzienda.Text)

         frm.Tag = "COPERTI"

         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdMeno_Click(sender As Object, e As EventArgs) Handles eui_cmdMeno.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim numCoperti As Integer

         If IsNumeric(txtNumCoperti.Text) = True And txtNumCoperti.Text <> "0" Then
            numCoperti = Convert.ToInt32(txtNumCoperti.Text)
         Else
            txtNumCoperti.Text = "1"
            Exit Sub
         End If

         Dim valTemp As Integer = numCoperti
         valTemp = numCoperti - 1

         If valTemp = 0 Then
            txtNumCoperti.Text = numCoperti.ToString
         Else
            txtNumCoperti.Text = valTemp.ToString
         End If

         txtNumCoperti.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdPiù_Click(sender As Object, e As EventArgs) Handles eui_cmdPiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim numCoperti As Integer

         If IsNumeric(txtNumCoperti.Text) = True Then
            numCoperti = Convert.ToInt32(txtNumCoperti.Text)
         Else
            txtNumCoperti.Text = "1"
            Exit Sub
         End If

         Dim valTemp As Integer = numCoperti
         valTemp = numCoperti + 1

         If valTemp = 0 Then
            txtNumCoperti.Text = numCoperti.ToString
         Else
            txtNumCoperti.Text = valTemp.ToString
         End If

         txtNumCoperti.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Apre la Tastiera virtuale di Windows (XP, 7, 8, 10).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Numero Coperti valido.
         If txtNumCoperti.Text <> "0" And txtNumCoperti.Text <> String.Empty Then
            Dim risposta As Integer

            ' Numero Coperti maggiore al numero dei Posti del Tavolo.
            If Convert.ToInt32(txtNumCoperti.Text) > numPosti Then
               risposta = MessageBox.Show("Il tavolo selezionato è troppo piccolo per il numero degli occupanti!" & vbCrLf &
                                          "Si desidera continuare comunque?.", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               If risposta = DialogResult.No Then
                  txtNumCoperti.Focus()
                  NumCopertiRistorante = String.Empty
                  Me.DialogResult = DialogResult.None
                  Me.Tag = ""
               Else
                  NumCopertiRistorante = txtNumCoperti.Text
                  Me.DialogResult = DialogResult.OK
                  Me.Tag = txtNumCoperti.Text
                  Me.Close()
               End If
            End If

            ' Numero Coperti minore al numero dei Posti del Tavolo.
            If Convert.ToInt32(txtNumCoperti.Text) < numPosti Then
               risposta = MessageBox.Show("Il tavolo selezionato è troppo grande per il numero degli occupanti!" & vbCrLf &
                                          "Si desidera continuare comunque?.", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
               If risposta = DialogResult.No Then
                  txtNumCoperti.Focus()
                  NumCopertiRistorante = String.Empty
                  Me.DialogResult = DialogResult.None
                  Me.Tag = ""
               Else
                  NumCopertiRistorante = txtNumCoperti.Text
                  Me.DialogResult = DialogResult.OK
                  Me.Tag = txtNumCoperti.Text
                  Me.Close()
               End If
            End If

            ' Numero Coperti uguale al numero dei Posti del Tavolo.
            If Convert.ToInt32(txtNumCoperti.Text) = numPosti Then
               NumCopertiRistorante = txtNumCoperti.Text
               Me.DialogResult = DialogResult.OK
               Me.Tag = txtNumCoperti.Text
               Me.Close()
            End If

         Else
            ' Numero Coperti non definito.
            MessageBox.Show("Inserire il numero dei coperti!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtNumCoperti.Focus()
            NumCopertiRistorante = String.Empty
            Me.DialogResult = DialogResult.None
            Me.Tag = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      g_frmVCTavoli.copertiAnnulla = True

      Me.DialogResult = DialogResult.Cancel
      Me.Tag = ""
      Me.Close()
   End Sub
End Class
