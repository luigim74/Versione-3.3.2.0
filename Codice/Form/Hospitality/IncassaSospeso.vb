Imports System.Data.OleDb

Public Class IncassaSospeso
   Inherits System.Windows.Forms.Form

   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_AZIENDE As String = "Aziende"
   Const TAB_DOC As String = "Documenti"
   Const TAB_DETTAGLI_DOC As String = "DettagliDoc"
   Const TAB_AZIENDA As String = "Azienda"

   Const TIPO_DOC_RF As String = "Ricevuta Fiscale"
   Const TIPO_DOC_FF As String = "Fattura"
   Const TIPO_DOC_SF As String = "Scontrino"

   Dim percorsoRep As String = PERCORSO_REP_RF
   Dim idCliente As String = ""
   Dim tipoDocumento As String = TIPO_DOC_RF
   Dim nomeStampante As String

   Private Doc As New Documenti
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Dim idDoc As Integer
   Dim numeroDoc As String
   Dim dataDoc As String
   Dim tipoDoc As String
   Dim intestatario As String
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Dim totaleDoc As Double = 0

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal id As Integer, ByVal numero As String, ByVal data As String, ByVal tipo As String, ByVal int As String, ByVal totale As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
      idDoc = id
      numeroDoc = numero
      dataDoc = data
      tipoDoc = tipo
      intestatario = int
      totaleDoc = CDbl(totale)
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
   Friend WithEvents cmdConto As System.Windows.Forms.Button
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents txtPIva As System.Windows.Forms.TextBox
   Public WithEvents Label31 As System.Windows.Forms.Label
   Public WithEvents txtIndirizzo As System.Windows.Forms.TextBox
   Friend WithEvents cmbIntestatario As System.Windows.Forms.ComboBox
   Friend WithEvents cmbId As System.Windows.Forms.ComboBox
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents cmbTipoDoc As System.Windows.Forms.ComboBox
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Public WithEvents txtRiscosso As System.Windows.Forms.TextBox
   Public WithEvents txtSospeso As System.Windows.Forms.TextBox
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(IncassaSospeso))
      Me.cmdConto = New System.Windows.Forms.Button()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtIndirizzo = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtPIva = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.cmbIntestatario = New System.Windows.Forms.ComboBox()
      Me.cmbId = New System.Windows.Forms.ComboBox()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.cmbTipoDoc = New System.Windows.Forms.ComboBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtRiscosso = New System.Windows.Forms.TextBox()
      Me.txtSospeso = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'cmdConto
      '
      Me.cmdConto.BackColor = System.Drawing.SystemColors.Control
      Me.cmdConto.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdConto.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.cmdConto.Location = New System.Drawing.Point(216, 208)
      Me.cmdConto.Name = "cmdConto"
      Me.cmdConto.Size = New System.Drawing.Size(88, 24)
      Me.cmdConto.TabIndex = 9
      Me.cmdConto.Text = "&Stampa"
      Me.cmdConto.UseVisualStyleBackColor = False
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.BackColor = System.Drawing.SystemColors.Control
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAnnulla.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.cmdAnnulla.Location = New System.Drawing.Point(312, 208)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(80, 24)
      Me.cmdAnnulla.TabIndex = 10
      Me.cmdAnnulla.Text = "&Annulla"
      Me.cmdAnnulla.UseVisualStyleBackColor = False
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.Enabled = False
      Me.txtProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(368, 104)
      Me.txtProv.MaxLength = 2
      Me.txtProv.Name = "txtProv"
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(32, 20)
      Me.txtProv.TabIndex = 5
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.Enabled = False
      Me.txtCap.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(112, 104)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(64, 20)
      Me.txtCap.TabIndex = 3
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.Enabled = False
      Me.txtCittà.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(184, 104)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(176, 20)
      Me.txtCittà.TabIndex = 4
      '
      'txtIndirizzo
      '
      Me.txtIndirizzo.AcceptsReturn = True
      Me.txtIndirizzo.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo.Enabled = False
      Me.txtIndirizzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIndirizzo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo.Location = New System.Drawing.Point(112, 80)
      Me.txtIndirizzo.MaxLength = 100
      Me.txtIndirizzo.Name = "txtIndirizzo"
      Me.txtIndirizzo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo.Size = New System.Drawing.Size(288, 20)
      Me.txtIndirizzo.TabIndex = 2
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(16, 104)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(87, 13)
      Me.Label5.TabIndex = 15
      Me.Label5.Text = "Cap/Città'/Prov.:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 80)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(48, 13)
      Me.Label4.TabIndex = 14
      Me.Label4.Text = "Indirizzo:"
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(16, 48)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(62, 13)
      Me.Label3.TabIndex = 13
      Me.Label3.Text = "Intestatario:"
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.Enabled = False
      Me.txtPIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(112, 128)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(288, 20)
      Me.txtPIva.TabIndex = 6
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(16, 128)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(69, 13)
      Me.Label31.TabIndex = 16
      Me.Label31.Text = "Partita I.V.A.:"
      '
      'cmbIntestatario
      '
      Me.cmbIntestatario.Enabled = False
      Me.cmbIntestatario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbIntestatario.Location = New System.Drawing.Point(112, 48)
      Me.cmbIntestatario.Name = "cmbIntestatario"
      Me.cmbIntestatario.Size = New System.Drawing.Size(288, 21)
      Me.cmbIntestatario.TabIndex = 1
      '
      'cmbId
      '
      Me.cmbId.Enabled = False
      Me.cmbId.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbId.Location = New System.Drawing.Point(304, 16)
      Me.cmbId.Name = "cmbId"
      Me.cmbId.Size = New System.Drawing.Size(40, 23)
      Me.cmbId.TabIndex = 11
      Me.cmbId.TabStop = False
      Me.cmbId.Visible = False
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
      'cmbTipoDoc
      '
      Me.cmbTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbTipoDoc.Items.AddRange(New Object() {"Ricevuta fiscale intestata", "Ricevuta fiscale", "Fattura"})
      Me.cmbTipoDoc.Location = New System.Drawing.Point(112, 16)
      Me.cmbTipoDoc.Name = "cmbTipoDoc"
      Me.cmbTipoDoc.Size = New System.Drawing.Size(184, 21)
      Me.cmbTipoDoc.TabIndex = 0
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(16, 16)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(87, 13)
      Me.Label1.TabIndex = 12
      Me.Label1.Text = "Tipo documento:"
      '
      'txtRiscosso
      '
      Me.txtRiscosso.AcceptsReturn = True
      Me.txtRiscosso.BackColor = System.Drawing.SystemColors.Window
      Me.txtRiscosso.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRiscosso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRiscosso.ForeColor = System.Drawing.Color.Red
      Me.txtRiscosso.Location = New System.Drawing.Point(112, 168)
      Me.txtRiscosso.MaxLength = 5
      Me.txtRiscosso.Name = "txtRiscosso"
      Me.txtRiscosso.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRiscosso.Size = New System.Drawing.Size(104, 20)
      Me.txtRiscosso.TabIndex = 7
      Me.txtRiscosso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtSospeso
      '
      Me.txtSospeso.AcceptsReturn = True
      Me.txtSospeso.BackColor = System.Drawing.SystemColors.Window
      Me.txtSospeso.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtSospeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSospeso.ForeColor = System.Drawing.Color.Red
      Me.txtSospeso.Location = New System.Drawing.Point(296, 168)
      Me.txtSospeso.MaxLength = 5
      Me.txtSospeso.Name = "txtSospeso"
      Me.txtSospeso.ReadOnly = True
      Me.txtSospeso.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSospeso.Size = New System.Drawing.Size(104, 20)
      Me.txtSospeso.TabIndex = 8
      Me.txtSospeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(16, 168)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(53, 13)
      Me.Label2.TabIndex = 17
      Me.Label2.Text = "Riscosso:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(232, 168)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(51, 13)
      Me.Label6.TabIndex = 191
      Me.Label6.Text = "Sospeso:"
      '
      'dtpData
      '
      Me.dtpData.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpData.Location = New System.Drawing.Point(24, 208)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(96, 20)
      Me.dtpData.TabIndex = 192
      Me.dtpData.Visible = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'IncassaSospeso
      '
      Me.AcceptButton = Me.cmdConto
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(418, 248)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtSospeso)
      Me.Controls.Add(Me.txtRiscosso)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmbTipoDoc)
      Me.Controls.Add(Me.cmbId)
      Me.Controls.Add(Me.cmbIntestatario)
      Me.Controls.Add(Me.cmdConto)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.txtPIva)
      Me.Controls.Add(Me.Label31)
      Me.Controls.Add(Me.txtProv)
      Me.Controls.Add(Me.txtCap)
      Me.Controls.Add(Me.txtCittà)
      Me.Controls.Add(Me.txtIndirizzo)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "IncassaSospeso"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Stampa documento"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public Sub CaricaListaCliente(ByVal cmb As ComboBox, ByVal cmb1 As ComboBox, ByVal tabella As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Cognome ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            cmb.Items.Add(dr.Item("Cognome") & " " & dr.Item("Nome"))
            cmb1.Items.Add(dr.Item("Id"))
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

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         idCliente = id

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
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaClienteAzienda(ByVal cmb As ComboBox, ByVal cmb1 As ComboBox, ByVal tabella As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY RagSociale ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         cmb.Items.Clear()
         Do While dr.Read
            cmb.Items.Add(dr.Item("RagSociale"))
            cmb1.Items.Add("A" & dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiDatiClienteAzienda(ByVal tabella As String, ByVal id As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         idCliente = "A" & id

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
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal numDoc As Integer, ByVal nomeStampante As String)
      Try

         'If PrintDialog1.ShowDialog() = DialogResult.OK Then

         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         ' Tabella Documenti.
         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_DOC & " WHERE Id = " & numDoc, cn)

         Dim ds As New Dataset1
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

         Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

         rep.Load(Application.StartupPath & nomeDoc)

         rep.SetDataSource(ds)

         If nomeStampante <> String.Empty And nomeStampante <> "Nessuna" Then
            rep.PrintOptions.PrinterName = nomeStampante
         End If

         ' Imposta il numero di copie del documento da stampare per il tipo di report.
         Select Case nomeDoc.Remove(0, 9)
            Case REPORT_RICEVUTA_BELLA_NAPOLI, REPORT_FATTURA_BELLA_NAPOLI, REPORT_PROFORMA_BELLA_NAPOLI
               PrintDialog1.PrinterSettings.Copies = 2

            Case Else
               PrintDialog1.PrinterSettings.Copies = 1

         End Select

         rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True, _
                   PrintDialog1.PrinterSettings.FromPage, _
                   PrintDialog1.PrinterSettings.ToPage)

         'End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub SalvaDocumento()
      Try
         With Doc
            .Numero = LeggiNumeroMax(TAB_DOC, tipoDocumento) + 1
            .Data = dtpData.Value.Date

            If DateTime.Now.Minute.ToString.Length = 1 Then
               .Ora = DateTime.Now.Hour & "." & "0" & DateTime.Now.Minute
            Else
               .Ora = DateTime.Now.Hour & "." & DateTime.Now.Minute
            End If

            .Tipo = tipoDocumento
            .IdCliente = idCliente
            .Cliente = FormattaApici(cmbIntestatario.Text)
            .Indirizzo = FormattaApici(txtIndirizzo.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .PIva = txtPIva.Text
            .CodAzienda = ""
            .Sconto = VALORE_ZERO
            .Servizio = VALORE_ZERO
            .BuoniPasto = VALORE_ZERO
            .BuoniPastoIncassare = VALORE_ZERO
            .TipoPagamento = ""
            .Tavolo = ""
            .Cameriere = ""
            .Sospeso = txtSospeso.Text
            .SospesoIncassare = txtSospeso.Text
            .TotDoc = CFormatta.FormattaEuro(totaleDoc)
            .Imponibile = VALORE_ZERO
            .Iva = VALORE_ZERO
            .Imposta = VALORE_ZERO
            .Chiuso = "No"
            .Note = ""

            .InserisciDati(TAB_DOC)

         End With

         ' SALVA I DETTAGLI DEL DOCUMENTO.
         Dim sql As String
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa.
         sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ValoreUnitario, ImportoNetto) " & _
                                             "VALUES(@RifDoc, @Descrizione, @Quantità, @ValoreUnitario, @ImportoNetto)", TAB_DETTAGLI_DOC)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@RifDoc", LeggiUltimoRecord(TAB_DOC))
         cmdInsert.Parameters.Add("@Descrizione", "Rif. " & tipoDoc & " n. " & numeroDoc & " del " & dataDoc)
         cmdInsert.Parameters.Add("@Quantità", "1")
         cmdInsert.Parameters.Add("@ValoreUnitario", VALORE_ZERO) ' B_TODO: Modifica per Retail.
         cmdInsert.Parameters.Add("@ImportoNetto", totaleDoc)

         ' Esegue il comando.
         Dim Record As Integer = cmdInsert.ExecuteNonQuery()
         ' Conferma transazione.
         tr.Commit()

         ' AZZERA IL VALORE DEL CAMPO SOSPESO.
         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa.
         sql = String.Format("UPDATE {0} SET SospesoIncassare = @SospesoIncassare WHERE Id = {1}", TAB_DOC, idDoc)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@SospesoIncassare", VALORE_ZERO)

         ' Esegue il comando.
         Dim Record1 As Integer = cmdUpdate.ExecuteNonQuery()
         ' Conferma transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

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

   Public Function VerificaIntestazione() As Boolean
      Dim val(5) As Boolean

      If cmbIntestatario.Text = "" Then
         MsgBox("Impossibile stampare il documento! Specificare l'intestatario.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
         Return False
      Else
         If txtIndirizzo.Text = "" Then
            val(0) = False
         Else
            val(0) = True
         End If
         If txtCap.Text = "" Then
            val(1) = False
         Else
            val(1) = True
         End If
         If txtCittà.Text = "" Then
            val(2) = False
         Else
            val(2) = True
         End If
         If txtProv.Text = "" Then
            val(3) = False
         Else
            val(3) = True
         End If
         If txtPIva.Text = "" Then
            val(4) = False
         Else
            val(4) = True
         End If
         If txtCittà.Text = "" Then
            val(2) = False
         Else
            val(2) = True
         End If
         If txtPIva.Text = "" Then
            val(5) = False
         Else
            val(5) = True
         End If

         Dim risposta As Integer
         Dim i As Integer = 0
         For i = 0 To 5
            If val(i) = False Then
               risposta = MsgBox("Alcuni campi per l'intestazione del documento non sono stati specificati. Effettuare comunque la stampa?  ", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
               If risposta = vbNo Then
                  Return False
               Else
                  Return True
               End If
            End If
         Next

         Return True
      End If
   End Function

   Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
      Try
         ' Esce, chiude il form senza stampare il conto.
         'Me.DialogResult = DialogResult.Abort
         ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
         Me.Tag = "0"

         ' Chiude la finestra.
         Me.Close()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdConto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConto.Click
      Try
         ' B_TODO: Modifica per Retail.
         If txtSospeso.Text <> VALORE_ZERO Then
            If VerificaIntestazione() = False Then
               Exit Sub
            End If
         End If

         ' Salva il documento fiscale.
         SalvaDocumento()

         ' Esegue la stampa.
         StampaDocumento(percorsoRep, LeggiUltimoRecord(TAB_DOC), nomeStampante)

         ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
         Me.Tag = "0"

         ' Esce, chiude il form e stampa il conto.
         Me.Close()

         ' Registra loperazione effettuata dall'operatore identificato.
         Dim strDescrizione As String = " (" & Doc.Tipo & " n. " & Doc.Numero & " del " & Doc.Data & " - € " & Doc.TotDoc & ")"
         g_frmMain.RegistraOperazione(TipoOperazione.IncassaSospeso, strDescrizione, MODULO_GESTIONE_ACQUISTI)

         If IsNothing(g_frmDocumenti) = False Then
            With g_frmDocumenti
               If .tbrSospesi.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  .AggiornaDatiSospesi()
                  Exit Sub
               ElseIf .tbrMese.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  .AggiornaDatiMese()
                  Exit Sub
               ElseIf .tbrAnno.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  .AggiornaDatiAnno()
                  Exit Sub
               ElseIf .tbrPeriodo.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  .AggiornaDatiPeriodo()
                  Exit Sub
               Else
                  ' Aggiorna la griglia dati.
                  .AggiornaDati()
                  Exit Sub
               End If
            End With
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub IncassaSospeso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      CaricaListaClienteAzienda(cmbIntestatario, cmbId, ANA_AZIENDE)
      CaricaListaCliente(cmbIntestatario, cmbId, ANA_CLIENTI)

      'cmbIntestatario.SelectedItem = intestatario
      cmbTipoDoc.SelectedIndex = 0

      txtRiscosso.Text = CFormatta.FormattaEuro(totaleDoc)
      txtSospeso.Text = VALORE_ZERO
   End Sub

   Private Sub IncassaSospeso_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_CONTABILITA_DOCUMENTI)
      End If
   End Sub

   Private Sub cmbIntestatario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbIntestatario.SelectedIndexChanged
      Try
         ' Ottiene l'indice dell'elemento selezionato.
         Dim index As Integer = sender.Items.IndexOf(sender.Text)

         ' Recupera l'Id del Cliente selezionato per caricare i dati.
         If index >= 0 Then
            If IsNumeric(cmbId.Items.Item(index)) = True Then
               LeggiDatiCliente(ANA_CLIENTI, cmbId.Items.Item(index))
            Else
               LeggiDatiClienteAzienda(ANA_AZIENDE, cmbId.Items.Item(index).ToString.Remove(0, 1))
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function ImpostaNomeDoc(ByVal indice As Integer) As String
      Dim val() As String = PercorsiStampantiDocumenti(indice).Split(";")

      If val(2) <> String.Empty Then
         Return val(2)
      Else
         Return String.Empty
      End If
   End Function

   Private Function ImpostaNomeStampante(ByVal indice As Integer) As String
      Dim val() As String = PercorsiStampantiDocumenti(indice).Split(";")

      If val(1) <> "Nessuna" Then
         Return val(1)
      Else
         Return String.Empty
      End If
   End Function

   Private Sub cmbTipoDoc_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoDoc.SelectedIndexChanged
      Try
         Select Case cmbTipoDoc.SelectedIndex
            Case 0
               ' Ricevuta intestata
               tipoDocumento = TIPO_DOC_RF

               If ImpostaNomeDoc(0) <> String.Empty Then
                  percorsoRep = "\Reports\" & ImpostaNomeDoc(0)
               Else
                  percorsoRep = PERCORSO_REP_RF
               End If
               nomeStampante = ImpostaNomeStampante(0)

               ' Attiva le caselle.
               cmbIntestatario.Enabled = True
               txtIndirizzo.Enabled = True
               txtCap.Enabled = True
               txtCittà.Enabled = True
               txtProv.Enabled = True
               txtPIva.Enabled = True
               cmbIntestatario.SelectedItem = intestatario

            Case 1
               ' Ricevuta
               tipoDocumento = TIPO_DOC_RF

               If ImpostaNomeDoc(0) <> String.Empty Then
                  percorsoRep = "\Reports\" & ImpostaNomeDoc(0)
               Else
                  percorsoRep = PERCORSO_REP_RF
               End If
               nomeStampante = ImpostaNomeStampante(0)

               ' Pulisce le caselle da eventuali dati.
               cmbIntestatario.SelectedItem = Nothing
               txtIndirizzo.Text = ""
               txtCap.Text = ""
               txtCittà.Text = ""
               txtProv.Text = ""
               txtPIva.Text = ""
               ' Disattiva le caselle.
               cmbIntestatario.Enabled = False
               txtIndirizzo.Enabled = False
               txtCap.Enabled = False
               txtCittà.Enabled = False
               txtProv.Enabled = False
               txtPIva.Enabled = False

            Case 2
               'Fattura
               tipoDocumento = TIPO_DOC_FF

               If ImpostaNomeDoc(1) <> String.Empty Then
                  percorsoRep = "\Reports\" & ImpostaNomeDoc(1)
               Else
                  percorsoRep = PERCORSO_REP_FF
               End If
               nomeStampante = ImpostaNomeStampante(1)

               ' Attiva le caselle.
               cmbIntestatario.Enabled = True
               txtIndirizzo.Enabled = True
               txtCap.Enabled = True
               txtCittà.Enabled = True
               txtProv.Enabled = True
               txtPIva.Enabled = True
               cmbIntestatario.SelectedItem = intestatario

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub txtSospeso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSospeso.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub txtRiscosso_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRiscosso.TextChanged
      If IsNumeric(sender.Text) Then
         Dim Riscosso As Double = CDbl(sender.Text)
         Dim Sospeso As Double = 0

         Sospeso = totaleDoc - Riscosso

         txtSospeso.Text = CFormatta.FormattaEuro(Sospeso)
      End If

   End Sub

   Private Sub txtRiscosso_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtRiscosso.LostFocus
      If IsNumeric(sender.Text) Then
         sender.Text = CFormatta.FormattaEuro(sender.Text)
      End If
   End Sub

   Private Sub txtCap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCap.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtPIva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPIva.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtSospeso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSospeso.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtRiscosso_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRiscosso.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

End Class
