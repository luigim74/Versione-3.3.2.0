Imports System.IO
Imports System.Data.OleDb

Public Class ClientiPos
   Inherits System.Windows.Forms.Form

   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_AZIENDE As String = "Aziende"

   Private AClienti As New Anagrafiche.Cliente(ConnStringAnagrafiche)
   Private AAziende As New Anagrafiche.AziendaCliente(ConnStringAnagrafiche)
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmdSalva As System.Windows.Forms.Button
   Public WithEvents txtIva As System.Windows.Forms.TextBox
   Public WithEvents txtPIva As System.Windows.Forms.TextBox
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents txtIndirizzo As System.Windows.Forms.TextBox
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents Label31 As System.Windows.Forms.Label
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents txtSconto As System.Windows.Forms.TextBox
   Public WithEvents txtNome As System.Windows.Forms.TextBox
   Public WithEvents lblNome As System.Windows.Forms.Label
   Public WithEvents txtCognome As System.Windows.Forms.TextBox
   Public WithEvents lblCognome As System.Windows.Forms.Label
   Public WithEvents txtRagioneSociale As System.Windows.Forms.TextBox
   Public WithEvents lblRagioneSociale As System.Windows.Forms.Label
   Friend WithEvents cmdTastiera As System.Windows.Forms.Button
   Public WithEvents Label1 As System.Windows.Forms.Label

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

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
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ClientiPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.cmdSalva = New System.Windows.Forms.Button()
      Me.txtIva = New System.Windows.Forms.TextBox()
      Me.txtPIva = New System.Windows.Forms.TextBox()
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtIndirizzo = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtSconto = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtCognome = New System.Windows.Forms.TextBox()
      Me.lblCognome = New System.Windows.Forms.Label()
      Me.txtNome = New System.Windows.Forms.TextBox()
      Me.lblNome = New System.Windows.Forms.Label()
      Me.txtRagioneSociale = New System.Windows.Forms.TextBox()
      Me.lblRagioneSociale = New System.Windows.Forms.Label()
      Me.cmdTastiera = New System.Windows.Forms.Button()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "RFiscale.rpt"
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAnnulla.BackColor = System.Drawing.Color.LightCoral
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAnnulla.ForeColor = System.Drawing.Color.White
      Me.cmdAnnulla.Location = New System.Drawing.Point(360, 264)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(160, 56)
      Me.cmdAnnulla.TabIndex = 11
      Me.cmdAnnulla.Text = "&ANNULLA"
      Me.cmdAnnulla.UseVisualStyleBackColor = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'cmdSalva
      '
      Me.cmdSalva.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSalva.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdSalva.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdSalva.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdSalva.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdSalva.ForeColor = System.Drawing.Color.White
      Me.cmdSalva.Location = New System.Drawing.Point(192, 264)
      Me.cmdSalva.Name = "cmdSalva"
      Me.cmdSalva.Size = New System.Drawing.Size(160, 56)
      Me.cmdSalva.TabIndex = 10
      Me.cmdSalva.Text = "&SALVA"
      Me.cmdSalva.UseVisualStyleBackColor = False
      '
      'txtIva
      '
      Me.txtIva.AcceptsReturn = True
      Me.txtIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIva.Location = New System.Drawing.Point(192, 216)
      Me.txtIva.MaxLength = 10
      Me.txtIva.Name = "txtIva"
      Me.txtIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIva.Size = New System.Drawing.Size(104, 29)
      Me.txtIva.TabIndex = 8
      Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(192, 176)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(328, 29)
      Me.txtPIva.TabIndex = 7
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(480, 136)
      Me.txtProv.MaxLength = 2
      Me.txtProv.Name = "txtProv"
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(40, 29)
      Me.txtProv.TabIndex = 6
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(192, 136)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(72, 29)
      Me.txtCap.TabIndex = 4
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(270, 136)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(204, 29)
      Me.txtCittà.TabIndex = 5
      '
      'txtIndirizzo
      '
      Me.txtIndirizzo.AcceptsReturn = True
      Me.txtIndirizzo.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIndirizzo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo.Location = New System.Drawing.Point(192, 96)
      Me.txtIndirizzo.MaxLength = 100
      Me.txtIndirizzo.Name = "txtIndirizzo"
      Me.txtIndirizzo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo.Size = New System.Drawing.Size(328, 29)
      Me.txtIndirizzo.TabIndex = 3
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(16, 224)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(65, 16)
      Me.Label11.TabIndex = 239
      Me.Label11.Text = "% I.V.A.:"
      Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(16, 184)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(117, 16)
      Me.Label31.TabIndex = 238
      Me.Label31.Text = "PARTITA I.V.A.:"
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(16, 144)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(174, 16)
      Me.Label5.TabIndex = 237
      Me.Label5.Text = "C.A.P. / CITTA' / PROV.:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 104)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(86, 16)
      Me.Label4.TabIndex = 236
      Me.Label4.Text = "INDIRIZZO:"
      '
      'txtSconto
      '
      Me.txtSconto.AcceptsReturn = True
      Me.txtSconto.BackColor = System.Drawing.SystemColors.Window
      Me.txtSconto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtSconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSconto.ForeColor = System.Drawing.Color.Red
      Me.txtSconto.Location = New System.Drawing.Point(416, 216)
      Me.txtSconto.MaxLength = 10
      Me.txtSconto.Name = "txtSconto"
      Me.txtSconto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSconto.Size = New System.Drawing.Size(104, 29)
      Me.txtSconto.TabIndex = 9
      Me.txtSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(320, 224)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(92, 16)
      Me.Label1.TabIndex = 241
      Me.Label1.Text = "% SCONTO:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'txtCognome
      '
      Me.txtCognome.AcceptsReturn = True
      Me.txtCognome.BackColor = System.Drawing.SystemColors.Window
      Me.txtCognome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCognome.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCognome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCognome.Location = New System.Drawing.Point(192, 16)
      Me.txtCognome.MaxLength = 100
      Me.txtCognome.Name = "txtCognome"
      Me.txtCognome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCognome.Size = New System.Drawing.Size(328, 29)
      Me.txtCognome.TabIndex = 0
      '
      'lblCognome
      '
      Me.lblCognome.AutoSize = True
      Me.lblCognome.BackColor = System.Drawing.Color.Transparent
      Me.lblCognome.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblCognome.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCognome.ForeColor = System.Drawing.Color.Black
      Me.lblCognome.Location = New System.Drawing.Point(16, 24)
      Me.lblCognome.Name = "lblCognome"
      Me.lblCognome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblCognome.Size = New System.Drawing.Size(88, 16)
      Me.lblCognome.TabIndex = 243
      Me.lblCognome.Text = "COGNOME:"
      '
      'txtNome
      '
      Me.txtNome.AcceptsReturn = True
      Me.txtNome.BackColor = System.Drawing.SystemColors.Window
      Me.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNome.Location = New System.Drawing.Point(192, 56)
      Me.txtNome.MaxLength = 100
      Me.txtNome.Name = "txtNome"
      Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNome.Size = New System.Drawing.Size(328, 29)
      Me.txtNome.TabIndex = 1
      '
      'lblNome
      '
      Me.lblNome.AutoSize = True
      Me.lblNome.BackColor = System.Drawing.Color.Transparent
      Me.lblNome.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblNome.ForeColor = System.Drawing.Color.Black
      Me.lblNome.Location = New System.Drawing.Point(16, 64)
      Me.lblNome.Name = "lblNome"
      Me.lblNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblNome.Size = New System.Drawing.Size(56, 16)
      Me.lblNome.TabIndex = 245
      Me.lblNome.Text = "NOME:"
      '
      'txtRagioneSociale
      '
      Me.txtRagioneSociale.AcceptsReturn = True
      Me.txtRagioneSociale.BackColor = System.Drawing.SystemColors.Window
      Me.txtRagioneSociale.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRagioneSociale.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRagioneSociale.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtRagioneSociale.Location = New System.Drawing.Point(192, 16)
      Me.txtRagioneSociale.MaxLength = 100
      Me.txtRagioneSociale.Name = "txtRagioneSociale"
      Me.txtRagioneSociale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRagioneSociale.Size = New System.Drawing.Size(328, 29)
      Me.txtRagioneSociale.TabIndex = 2
      '
      'lblRagioneSociale
      '
      Me.lblRagioneSociale.AutoSize = True
      Me.lblRagioneSociale.BackColor = System.Drawing.Color.Transparent
      Me.lblRagioneSociale.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblRagioneSociale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblRagioneSociale.ForeColor = System.Drawing.Color.Black
      Me.lblRagioneSociale.Location = New System.Drawing.Point(16, 24)
      Me.lblRagioneSociale.Name = "lblRagioneSociale"
      Me.lblRagioneSociale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblRagioneSociale.Size = New System.Drawing.Size(147, 16)
      Me.lblRagioneSociale.TabIndex = 247
      Me.lblRagioneSociale.Text = "RAGIONE SOCIALE:"
      '
      'cmdTastiera
      '
      Me.cmdTastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdTastiera.BackColor = System.Drawing.Color.Gray
      Me.cmdTastiera.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdTastiera.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdTastiera.ForeColor = System.Drawing.Color.White
      Me.cmdTastiera.Image = CType(resources.GetObject("cmdTastiera.Image"), System.Drawing.Image)
      Me.cmdTastiera.Location = New System.Drawing.Point(16, 280)
      Me.cmdTastiera.Name = "cmdTastiera"
      Me.cmdTastiera.Size = New System.Drawing.Size(56, 40)
      Me.cmdTastiera.TabIndex = 248
      Me.cmdTastiera.UseVisualStyleBackColor = False
      '
      'ClientiPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(23, 55)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(534, 333)
      Me.Controls.Add(Me.cmdTastiera)
      Me.Controls.Add(Me.txtNome)
      Me.Controls.Add(Me.lblNome)
      Me.Controls.Add(Me.txtCognome)
      Me.Controls.Add(Me.lblCognome)
      Me.Controls.Add(Me.txtSconto)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtIva)
      Me.Controls.Add(Me.txtPIva)
      Me.Controls.Add(Me.txtProv)
      Me.Controls.Add(Me.txtCap)
      Me.Controls.Add(Me.txtCittà)
      Me.Controls.Add(Me.txtIndirizzo)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.Label31)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.cmdSalva)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.txtRagioneSociale)
      Me.Controls.Add(Me.lblRagioneSociale)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ClientiPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "CLIENTI"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub CancellaDatiCliente()
      txtIndirizzo.Text = ""
      txtCap.Text = ""
      txtCittà.Text = ""
      txtProv.Text = ""
      txtPIva.Text = ""
      txtIva.Text = VALORE_ZERO
      txtSconto.Text = VALORE_ZERO
   End Sub

   Public Sub LeggiDatiClienteAzienda(ByVal tabella As String, ByVal id As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & Convert.ToInt32(id), cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         CancellaDatiCliente()

         Do While dr.Read
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               txtIndirizzo.Text = dr.Item("Indirizzo")
            Else
               txtIndirizzo.Text = ""
            End If
            If IsDBNull(dr.Item("Cap")) = False Then
               txtCap.Text = dr.Item("Cap")
            Else
               txtCap.Text = ""
            End If
            If IsDBNull(dr.Item("Città")) = False Then
               txtCittà.Text = dr.Item("Città")
            Else
               txtCittà.Text = ""
            End If
            If IsDBNull(dr.Item("Provincia")) = False Then
               txtProv.Text = dr.Item("Provincia")
            Else
               txtProv.Text = ""
            End If
            If IsDBNull(dr.Item("PIva")) = False Then
               txtPIva.Text = dr.Item("PIva")
            Else
               txtPIva.Text = ""
            End If
            If IsDBNull(dr.Item("Iva")) = False Then
               txtIva.Text = CFormatta.FormattaNumeroDouble(dr.Item("Iva"))
            Else
               txtIva.Text = VALORE_ZERO
            End If
            If IsDBNull(dr.Item("Sconto")) = False Then
               txtSconto.Text = CFormatta.FormattaNumeroDouble(dr.Item("Sconto")) & "%"
            Else
               txtSconto.Text = VALORE_ZERO
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiDatiCliente(ByVal tabella As String, ByVal id As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & Convert.ToInt32(id), cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         CancellaDatiCliente()

         Do While dr.Read
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               txtIndirizzo.Text = dr.Item("Indirizzo")
            Else
               txtIndirizzo.Text = ""
            End If
            If IsDBNull(dr.Item("Cap")) = False Then
               txtCap.Text = dr.Item("Cap")
            Else
               txtCap.Text = ""
            End If
            If IsDBNull(dr.Item("Città")) = False Then
               txtCittà.Text = dr.Item("Città")
            Else
               txtCittà.Text = ""
            End If
            If IsDBNull(dr.Item("Provincia")) = False Then
               txtProv.Text = dr.Item("Provincia")
            Else
               txtProv.Text = ""
            End If
            If IsDBNull(dr.Item("PIva")) = False Then
               txtPIva.Text = dr.Item("PIva")
            Else
               txtPIva.Text = ""
            End If
            If IsDBNull(dr.Item("Iva")) = False Then
               txtIva.Text = CFormatta.FormattaNumeroDouble(dr.Item("Iva"))
            Else
               txtIva.Text = VALORE_ZERO
            End If
            If IsDBNull(dr.Item("Sconto")) = False Then
               txtSconto.Text = CFormatta.FormattaNumeroDouble(dr.Item("Sconto")) & "%"
            Else
               txtSconto.Text = VALORE_ZERO
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub ClientiPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         Select Case tipoCliente
            Case Cliente.Azienda
               lblRagioneSociale.Visible = True
               txtRagioneSociale.Visible = True
               lblCognome.Visible = False
               txtCognome.Visible = False
               lblNome.Visible = False
               txtNome.Visible = False

               If Me.Tag <> "" Then
                  With AAziende
                     ' Visualizza i dati nei rispettivi campi.
                     .LeggiDati(ANA_AZIENDE, Me.Tag)

                     ' Assegna i dati dei campi della classe alle caselle di testo.
                     txtRagioneSociale.Text = .RagSociale
                     txtPIva.Text = .PIva
                     txtIndirizzo.Text = .Indirizzo1
                     txtCap.Text = .Cap
                     txtCittà.Text = .Città
                     txtProv.Text = .Provincia
                     txtSconto.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Sconto))
                     txtIva.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Iva))
                  End With
               Else
                  ' In caso di nuovo inserimento dati imposta i valori di default.
                  txtSconto.Text = VALORE_ZERO
                  txtIva.Text = VALORE_ZERO
               End If

               ' Imposta lo stato attivo.
               txtRagioneSociale.Focus()

            Case Cliente.Privato

               lblRagioneSociale.Visible = False
               txtRagioneSociale.Visible = False
               lblCognome.Visible = True
               txtCognome.Visible = True
               lblNome.Visible = True
               txtNome.Visible = True

               If Me.Tag <> "" Then
                  With AClienti
                     ' Visualizza i dati nei rispettivi campi.
                     .LeggiDati(ANA_CLIENTI, Me.Tag)

                     ' Assegna i dati dei campi della classe alle caselle di testo.
                     txtCognome.Text = .Cognome
                     txtNome.Text = .Nome
                     txtPIva.Text = .PIva
                     txtIndirizzo.Text = .Indirizzo1
                     txtCap.Text = .Cap
                     txtCittà.Text = .Città
                     txtProv.Text = .Provincia
                     txtSconto.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Sconto))
                     txtIva.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Iva))
                  End With
               Else
                  ' In caso di nuovo inserimento dati imposta i valori di default.
                  txtSconto.Text = VALORE_ZERO
                  txtIva.Text = VALORE_ZERO
               End If

               ' Imposta lo stato attivo.
               txtCognome.Focus()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try

   End Sub

   Private Sub ClientiPos_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      If Me.Tag <> "0" Then
         Select Case tipoCliente
            Case Cliente.Azienda
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_AZIENDE)

            Case Cliente.Privato
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_CLIENTI)

         End Select
      End If
   End Sub

   Private Sub cmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
      Me.Tag = "0"

      ' Chiude la finestra.
      Me.Close()

      Select Case tipoCliente
         Case Cliente.Azienda
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_AZIENDE)

         Case Cliente.Privato
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_ANAGRAFICA_CLIENTI)

      End Select
   End Sub

   Private Sub cmdSalva_Click(sender As System.Object, e As System.EventArgs) Handles cmdSalva.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Select Case tipoCliente
            Case Cliente.Azienda
               ' Salva i dati nel database.
               If SalvaDatiAziende() = True Then

                  If IsNothing(g_frmAziende) = False Then
                     ' Aggiorna la griglia dati.
                     g_frmAziende.AggiornaDati()
                  End If

                  ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
                  Me.Tag = "0"

                  ' Chiude la finestra.
                  Me.Close()

                  ' Registra l'operazione effettuata dall'operatore identificato.
                  Dim strDescrizione As String = " (" & AAziende.RagSociale & ")"

                  g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_AZIENDE)
               End If

            Case Cliente.Privato
               ' Salva i dati nel database.
               If SalvaDatiClienti() = True Then

                  If IsNothing(g_frmClienti) = False Then
                     ' Aggiorna la griglia dati.
                     g_frmClienti.AggiornaDati()
                  End If

                  ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
                  Me.Tag = "0"

                  ' Chiude la finestra.
                  Me.Close()

                  ' Registra l'operazione effettuata dall'operatore identificato.
                  Dim strDescrizione As String = " (" & AClienti.Cognome & " " & AClienti.Nome & ")"

                  g_frmMain.RegistraOperazione(TipoOperazione.Salva, strDescrizione, MODULO_ANAGRAFICA_CLIENTI)

               End If
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function SalvaDatiClienti() As Boolean
      Try
         With AClienti
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .Cognome = FormattaApici(txtCognome.Text)
            .Nome = FormattaApici(txtNome.Text)
            .Titolo = .Titolo
            .DataNascita = .DataNascita
            .CodFisc = .CodFisc
            .PIva = FormattaApici(txtPIva.Text)
            .Indirizzo1 = FormattaApici(txtIndirizzo.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .Regione = .Regione
            .Nazione = .Nazione
            .TipoCliente = .TipoCliente
            .NumeroDoc = .NumeroDoc
            If IsNumeric(txtSconto.Text) = True Then
               .Sconto = txtSconto.Text
            Else
               .Sconto = VALORE_ZERO
            End If
            If IsNumeric(txtIva.Text) = True Then
               .Iva = txtIva.Text
            Else
               .Iva = VALORE_ZERO
            End If
            .TelCasa = .TelCasa
            .TelUfficio = .TelUfficio
            .Cell = .Cell
            .Fax = .Fax
            .Email = .Email
            .Internet = .Internet
            .Note = .Note
            .Privacy = .Privacy

            ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> "" Then
               Return .ModificaDati(ANA_CLIENTI, Me.Tag)
            Else
               Return .InserisciDati(ANA_CLIENTI)
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Function SalvaDatiAziende() As Boolean
      Try
         With AAziende
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .RagSociale = FormattaApici(txtRagioneSociale.Text)
            .Titolo = .Titolo
            .CodFisc = .CodFisc
            .PIva = FormattaApici(txtPIva.Text)
            .Indirizzo1 = FormattaApici(txtIndirizzo.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .Regione = .Regione
            .Nazione = .Nazione
            .TipoCliente = .TipoCliente
            If IsNumeric(txtSconto.Text) = True Then
               .Sconto = txtSconto.Text
            Else
               .Sconto = VALORE_ZERO
            End If
            If IsNumeric(txtIva.Text) = True Then
               .Iva = txtIva.Text
            Else
               .Iva = VALORE_ZERO
            End If
            .Privacy = .Privacy
            .TelCasa = .TelCasa
            .TelUfficio = .TelUfficio
            .Cell = .Cell
            .Fax = .Fax
            .Email = .Email
            .Internet = .Internet
            .TipoPagamento = .TipoPagamento
            .Banca = .Banca
            .Abi = .Abi
            .Cab = .Cab
            .Cc = .Cc
            .Cin = .Cin
            .Iban = .Iban

            .CodAzienda = .CodAzienda
            .Note = .Note
            .NoteDoc = .NoteDoc

            ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> "" Then
               Return .ModificaDati(ANA_AZIENDE, Me.Tag)
            Else
               Return .InserisciDati(ANA_AZIENDE)
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Sub txtIva_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtIva.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtSconto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSconto.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtPIva_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPIva.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtCap_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCap.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub cmdTastiera_Click(sender As System.Object, e As System.EventArgs) Handles cmdTastiera.Click
      ' Apre la Tastiera virtuale di Windows (XP, 7, 8).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub
End Class
