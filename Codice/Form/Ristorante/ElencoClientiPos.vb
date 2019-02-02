Imports System.IO
Imports System.Data.OleDb

Public Class ElencoClientiPos
   Inherits System.Windows.Forms.Form

   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_AZIENDE As String = "Aziende"
   Const ALTEZZA_RIGA_DETTAGLI As Short = 24

   Const TITOLO_FINESTRA As String = "ELENCO CLIENTI"

   Private CFormatta As New ClsFormatta
   Private codiceCliente As String = "0"
   Private codiceAzienda As String = "0"

   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents lstvClienti As System.Windows.Forms.ListView
   Friend WithEvents NomeCliente As System.Windows.Forms.ColumnHeader
   Friend WithEvents Id As System.Windows.Forms.ColumnHeader
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
   Public WithEvents txtValSconto As System.Windows.Forms.TextBox
   Public WithEvents Label1 As System.Windows.Forms.Label
   Public WithEvents txtCodiceFiscale As TextBox
   Public WithEvents Label2 As Label
   Public WithEvents txtNome As TextBox
   Public WithEvents Label22 As Label
   Public WithEvents txtCognome As TextBox
   Public WithEvents Label21 As Label
   Friend WithEvents eui_cmdPrivati As Elegant.Ui.Button
   Friend WithEvents eui_cmdAzienda As Elegant.Ui.Button
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button
   Friend WithEvents eui_cmdModifica As Elegant.Ui.Button
   Friend WithEvents eui_cmdNuovo As Elegant.Ui.Button
   Friend WithEvents eui_cmdClientiSu As Elegant.Ui.Button
   Friend WithEvents eui_cmdClientiGiù As Elegant.Ui.Button
   Friend WithEvents IdCliente As System.Windows.Forms.ColumnHeader

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal idCliente As String, ByVal idAzienda As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      codiceCliente = idCliente
      codiceAzienda = idAzienda
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
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Azienda Ligure SRL")
      Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Montana Luigi")
      Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Rossi Fabio")
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoClientiPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.lstvClienti = New System.Windows.Forms.ListView()
      Me.Id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.NomeCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.IdCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
      Me.txtValSconto = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtCodiceFiscale = New System.Windows.Forms.TextBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.txtNome = New System.Windows.Forms.TextBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.txtCognome = New System.Windows.Forms.TextBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.eui_cmdPrivati = New Elegant.Ui.Button()
      Me.eui_cmdAzienda = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.eui_cmdClientiSu = New Elegant.Ui.Button()
      Me.eui_cmdClientiGiù = New Elegant.Ui.Button()
      Me.eui_cmdModifica = New Elegant.Ui.Button()
      Me.eui_cmdNuovo = New Elegant.Ui.Button()
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
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'lstvClienti
      '
      Me.lstvClienti.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvClienti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Id, Me.NomeCliente, Me.IdCliente})
      Me.lstvClienti.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvClienti.FullRowSelect = True
      Me.lstvClienti.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvClienti.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
      Me.lstvClienti.Location = New System.Drawing.Point(12, 16)
      Me.lstvClienti.MultiSelect = False
      Me.lstvClienti.Name = "lstvClienti"
      Me.lstvClienti.Size = New System.Drawing.Size(491, 448)
      Me.lstvClienti.TabIndex = 0
      Me.lstvClienti.UseCompatibleStateImageBehavior = False
      Me.lstvClienti.View = System.Windows.Forms.View.Details
      '
      'Id
      '
      Me.Id.DisplayIndex = 2
      Me.Id.Text = ""
      Me.Id.Width = 0
      '
      'NomeCliente
      '
      Me.NomeCliente.DisplayIndex = 0
      Me.NomeCliente.Text = ""
      Me.NomeCliente.Width = 480
      '
      'IdCliente
      '
      Me.IdCliente.DisplayIndex = 1
      Me.IdCliente.Text = ""
      Me.IdCliente.Width = 0
      '
      'txtIva
      '
      Me.txtIva.AcceptsReturn = True
      Me.txtIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIva.Location = New System.Drawing.Point(175, 600)
      Me.txtIva.MaxLength = 10
      Me.txtIva.Name = "txtIva"
      Me.txtIva.ReadOnly = True
      Me.txtIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIva.Size = New System.Drawing.Size(104, 29)
      Me.txtIva.TabIndex = 15
      Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(175, 536)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.ReadOnly = True
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(328, 29)
      Me.txtPIva.TabIndex = 13
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(463, 504)
      Me.txtProv.MaxLength = 2
      Me.txtProv.Name = "txtProv"
      Me.txtProv.ReadOnly = True
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(40, 29)
      Me.txtProv.TabIndex = 12
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(175, 504)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.ReadOnly = True
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(72, 29)
      Me.txtCap.TabIndex = 10
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(253, 504)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.ReadOnly = True
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(204, 29)
      Me.txtCittà.TabIndex = 11
      '
      'txtIndirizzo
      '
      Me.txtIndirizzo.AcceptsReturn = True
      Me.txtIndirizzo.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIndirizzo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo.Location = New System.Drawing.Point(175, 472)
      Me.txtIndirizzo.MaxLength = 100
      Me.txtIndirizzo.Name = "txtIndirizzo"
      Me.txtIndirizzo.ReadOnly = True
      Me.txtIndirizzo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo.Size = New System.Drawing.Size(328, 29)
      Me.txtIndirizzo.TabIndex = 9
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(8, 600)
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
      Me.Label31.Location = New System.Drawing.Point(8, 536)
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
      Me.Label5.Location = New System.Drawing.Point(8, 504)
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
      Me.Label4.Location = New System.Drawing.Point(9, 472)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(86, 16)
      Me.Label4.TabIndex = 236
      Me.Label4.Text = "INDIRIZZO:"
      '
      'txtValSconto
      '
      Me.txtValSconto.AcceptsReturn = True
      Me.txtValSconto.BackColor = System.Drawing.SystemColors.Window
      Me.txtValSconto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtValSconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtValSconto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtValSconto.Location = New System.Drawing.Point(399, 600)
      Me.txtValSconto.MaxLength = 10
      Me.txtValSconto.Name = "txtValSconto"
      Me.txtValSconto.ReadOnly = True
      Me.txtValSconto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtValSconto.Size = New System.Drawing.Size(104, 29)
      Me.txtValSconto.TabIndex = 16
      Me.txtValSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(292, 600)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(92, 16)
      Me.Label1.TabIndex = 241
      Me.Label1.Text = "% SCONTO:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'txtCodiceFiscale
      '
      Me.txtCodiceFiscale.AcceptsReturn = True
      Me.txtCodiceFiscale.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodiceFiscale.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodiceFiscale.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodiceFiscale.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodiceFiscale.Location = New System.Drawing.Point(175, 568)
      Me.txtCodiceFiscale.MaxLength = 16
      Me.txtCodiceFiscale.Name = "txtCodiceFiscale"
      Me.txtCodiceFiscale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodiceFiscale.Size = New System.Drawing.Size(328, 29)
      Me.txtCodiceFiscale.TabIndex = 14
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(9, 568)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(133, 16)
      Me.Label2.TabIndex = 252
      Me.Label2.Text = "CODICE FISCALE:"
      '
      'txtNome
      '
      Me.txtNome.AcceptsReturn = True
      Me.txtNome.BackColor = System.Drawing.SystemColors.Window
      Me.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNome.Location = New System.Drawing.Point(175, 695)
      Me.txtNome.MaxLength = 11
      Me.txtNome.Name = "txtNome"
      Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNome.Size = New System.Drawing.Size(144, 29)
      Me.txtNome.TabIndex = 268
      Me.txtNome.Visible = False
      '
      'Label22
      '
      Me.Label22.BackColor = System.Drawing.Color.Transparent
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(23, 703)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(144, 24)
      Me.Label22.TabIndex = 269
      Me.Label22.Text = "NOME:"
      Me.Label22.Visible = False
      '
      'txtCognome
      '
      Me.txtCognome.AcceptsReturn = True
      Me.txtCognome.BackColor = System.Drawing.SystemColors.Window
      Me.txtCognome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCognome.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCognome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCognome.Location = New System.Drawing.Point(175, 660)
      Me.txtCognome.MaxLength = 11
      Me.txtCognome.Name = "txtCognome"
      Me.txtCognome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCognome.Size = New System.Drawing.Size(144, 29)
      Me.txtCognome.TabIndex = 266
      Me.txtCognome.Visible = False
      '
      'Label21
      '
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(23, 668)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(144, 24)
      Me.Label21.TabIndex = 267
      Me.Label21.Text = "COGNOME:"
      Me.Label21.Visible = False
      '
      'eui_cmdPrivati
      '
      Me.eui_cmdPrivati.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdPrivati.Id = "d95d7252-15d6-49f8-bdd6-7a4da532e67a"
      Me.eui_cmdPrivati.Location = New System.Drawing.Point(518, 80)
      Me.eui_cmdPrivati.Name = "eui_cmdPrivati"
      Me.eui_cmdPrivati.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdPrivati.TabIndex = 2
      Me.eui_cmdPrivati.Text = "&Privati"
      '
      'eui_cmdAzienda
      '
      Me.eui_cmdAzienda.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAzienda.Id = "80b9e79e-4a8a-47af-a688-45efa3d1020f"
      Me.eui_cmdAzienda.Location = New System.Drawing.Point(518, 16)
      Me.eui_cmdAzienda.Name = "eui_cmdAzienda"
      Me.eui_cmdAzienda.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAzienda.TabIndex = 1
      Me.eui_cmdAzienda.Text = "&Aziende"
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "2b8ba805-3369-4c5e-b816-dc81f831067e"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(518, 576)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 8
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOk.Id = "7a1eb92e-859a-4d27-b576-33ca41ac3da8"
      Me.eui_cmdOk.Location = New System.Drawing.Point(518, 512)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdOk.TabIndex = 7
      Me.eui_cmdOk.Text = "&OK"
      '
      'eui_cmdClientiSu
      '
      Me.eui_cmdClientiSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdClientiSu.Id = "b15386b9-8061-48cc-991d-39bafe9937f0"
      Me.eui_cmdClientiSu.Location = New System.Drawing.Point(518, 154)
      Me.eui_cmdClientiSu.Name = "eui_cmdClientiSu"
      Me.eui_cmdClientiSu.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdClientiSu.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdClientiSu.Size = New System.Drawing.Size(128, 80)
      Me.eui_cmdClientiSu.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdClientiSu.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdClientiSu.TabIndex = 3
      '
      'eui_cmdClientiGiù
      '
      Me.eui_cmdClientiGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdClientiGiù.Id = "4f786491-c59c-4dcc-8654-dc0a91bfc6de"
      Me.eui_cmdClientiGiù.Location = New System.Drawing.Point(518, 245)
      Me.eui_cmdClientiGiù.Name = "eui_cmdClientiGiù"
      Me.eui_cmdClientiGiù.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdClientiGiù.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdClientiGiù.Size = New System.Drawing.Size(128, 80)
      Me.eui_cmdClientiGiù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdClientiGiù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdClientiGiù.TabIndex = 4
      '
      'eui_cmdModifica
      '
      Me.eui_cmdModifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdModifica.Id = "c372cc05-2e91-44b2-9fdc-82c1047e969b"
      Me.eui_cmdModifica.Location = New System.Drawing.Point(518, 411)
      Me.eui_cmdModifica.Name = "eui_cmdModifica"
      Me.eui_cmdModifica.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdModifica.TabIndex = 6
      Me.eui_cmdModifica.Text = "&Modifica"
      '
      'eui_cmdNuovo
      '
      Me.eui_cmdNuovo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdNuovo.Id = "1a246095-f7c0-4465-af49-e54884015a74"
      Me.eui_cmdNuovo.Location = New System.Drawing.Point(518, 347)
      Me.eui_cmdNuovo.Name = "eui_cmdNuovo"
      Me.eui_cmdNuovo.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdNuovo.TabIndex = 5
      Me.eui_cmdNuovo.Text = "&Nuovo"
      '
      'ElencoClientiPos
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(23, 55)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(658, 641)
      Me.Controls.Add(Me.eui_cmdModifica)
      Me.Controls.Add(Me.eui_cmdNuovo)
      Me.Controls.Add(Me.eui_cmdClientiSu)
      Me.Controls.Add(Me.eui_cmdClientiGiù)
      Me.Controls.Add(Me.eui_cmdPrivati)
      Me.Controls.Add(Me.eui_cmdAzienda)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.txtNome)
      Me.Controls.Add(Me.Label22)
      Me.Controls.Add(Me.txtCognome)
      Me.Controls.Add(Me.Label21)
      Me.Controls.Add(Me.txtCodiceFiscale)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.txtValSconto)
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
      Me.Controls.Add(Me.lstvClienti)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ElencoClientiPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "ELENCO CLIENTI"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub CancellaDatiCliente()
      txtNome.Text = String.Empty
      txtCognome.Text = String.Empty
      txtIndirizzo.Text = String.Empty
      txtCap.Text = String.Empty
      txtCittà.Text = String.Empty
      txtProv.Text = String.Empty
      txtPIva.Text = String.Empty
      txtCodiceFiscale.Text = String.Empty
      txtIva.Text = VALORE_ZERO
      txtValSconto.Text = VALORE_ZERO
   End Sub

   Public Sub CaricaListaCliente(ByVal lstv As ListView, ByVal tabella As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Cognome ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstv.Items.Clear()

         ' Id.
         lstv.Items.Add(lstv.Items.Count).BackColor = Color.LightSalmon

         ' Cliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< NESSUNO >")

         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")

         Do While dr.Read
            ' Id.
            lstv.Items.Add(lstv.Items.Count)

            ' Cliente.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Cognome").ToString & " " & dr.Item("Nome").ToString)

            ' IdCliente.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CaricaListaClienteAzienda(ByVal lstv As ListView, ByVal tabella As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY RagSociale ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstv.Items.Clear()

         ' Id.
         lstv.Items.Add(lstv.Items.Count).BackColor = Color.LightSalmon

         ' Cliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("< NESSUNO >")

         ' IdCliente.
         lstv.Items(lstv.Items.Count - 1).SubItems.Add("0")

         Do While dr.Read
            ' Id.
            lstv.Items.Add(lstv.Items.Count)

            ' Cliente.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("RagSociale").ToString)

            ' IdCliente.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Id"))
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

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & Convert.ToInt32(id), cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         CancellaDatiCliente()

         Do While dr.Read
            If IsDBNull(dr.Item("RagSociale")) = False Then
               txtCognome.Text = dr.Item("RagSociale").ToString
            Else
               txtCognome.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               txtIndirizzo.Text = dr.Item("Indirizzo").ToString
            Else
               txtIndirizzo.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Cap")) = False Then
               txtCap.Text = dr.Item("Cap").ToString
            Else
               txtCap.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Città")) = False Then
               txtCittà.Text = dr.Item("Città").ToString
            Else
               txtCittà.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Provincia")) = False Then
               txtProv.Text = dr.Item("Provincia").ToString
            Else
               txtProv.Text = String.Empty
            End If
            If IsDBNull(dr.Item("PIva")) = False Then
               txtPIva.Text = dr.Item("PIva").ToString
            Else
               txtPIva.Text = String.Empty
            End If
            If IsDBNull(dr.Item("CodFisc")) = False Then
               txtCodiceFiscale.Text = dr.Item("CodFisc").ToString
            Else
               txtCodiceFiscale.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Iva")) = False Then
               txtIva.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Iva")))
            Else
               txtIva.Text = VALORE_ZERO
            End If
            If IsDBNull(dr.Item("Sconto")) = False Then
               txtValSconto.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Sconto"))) '& "%"
            Else
               txtValSconto.Text = VALORE_ZERO
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
            If IsDBNull(dr.Item("Cognome")) = False Then
               txtCognome.Text = dr.Item("Cognome").ToString
            Else
               txtCognome.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Nome")) = False Then
               txtNome.Text = dr.Item("Nome").ToString
            Else
               txtNome.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               txtIndirizzo.Text = dr.Item("Indirizzo").ToString
            Else
               txtIndirizzo.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Cap")) = False Then
               txtCap.Text = dr.Item("Cap").ToString
            Else
               txtCap.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Città")) = False Then
               txtCittà.Text = dr.Item("Città").ToString
            Else
               txtCittà.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Provincia")) = False Then
               txtProv.Text = dr.Item("Provincia").ToString
            Else
               txtProv.Text = String.Empty
            End If
            If IsDBNull(dr.Item("PIva")) = False Then
               txtPIva.Text = dr.Item("PIva").ToString
            Else
               txtPIva.Text = String.Empty
            End If
            If IsDBNull(dr.Item("CodFisc")) = False Then
               txtCodiceFiscale.Text = dr.Item("CodFisc").ToString
            Else
               txtCodiceFiscale.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Iva")) = False Then
               txtIva.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Iva")))
            Else
               txtIva.Text = VALORE_ZERO
            End If
            If IsDBNull(dr.Item("Sconto")) = False Then
               txtValSconto.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Sconto"))) '& "%"
            Else
               txtValSconto.Text = VALORE_ZERO
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub SelezionaCliente(ByVal id As String)
      Try
         If id = "0" Then
            lstvClienti.FocusedItem = lstvClienti.Items(0)
            lstvClienti.EnsureVisible(0)
            lstvClienti.FocusedItem.Selected = True
         Else
            Dim i As Integer
            For i = 0 To lstvClienti.Items.Count - 1
               If id = lstvClienti.Items(i).SubItems(2).Text Then
                  lstvClienti.FocusedItem = lstvClienti.Items(i)
                  lstvClienti.EnsureVisible(i)
                  lstvClienti.FocusedItem.Selected = True
                  Exit For
               End If
            Next
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ElencoClientiPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         If codiceAzienda <> "0" Then
            tipoCliente = Cliente.Azienda

         ElseIf codiceCliente <> "0" Then
            tipoCliente = Cliente.Privato

         Else
            tipoCliente = Cliente.Azienda
         End If

         Select Case tipoCliente
            Case Cliente.Azienda
               Me.Text = TITOLO_FINESTRA & "- AZIENDE"

               CaricaListaClienteAzienda(lstvClienti, ANA_AZIENDE)

               tipoCliente = Cliente.Azienda

               ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
               SelezionaCliente(codiceAzienda)

            Case Cliente.Privato
               Me.Text = TITOLO_FINESTRA & "- PRIVATI"

               CaricaListaCliente(lstvClienti, ANA_CLIENTI)

               tipoCliente = Cliente.Privato

               ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
               SelezionaCliente(codiceCliente)

         End Select

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lstvClienti_Resize(sender As Object, e As System.EventArgs) Handles lstvClienti.Resize
      Try
         NumElementi = (lstvClienti.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub lstvClienti_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstvClienti.SelectedIndexChanged
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         If lstvClienti.Items.Count <> 0 Then
            Select Case tipoCliente
               Case Cliente.Azienda
                  lstvClienti.Focus()
                  LeggiDatiClienteAzienda(ANA_AZIENDE, lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(2).Text)

               Case Cliente.Privato
                  lstvClienti.Focus()
                  LeggiDatiCliente(ANA_CLIENTI, lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(2).Text)
            End Select
         End If

      Catch ex As NullReferenceException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function LeggiNumRecord(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0}", tabella)
         numRec = CInt(cmd.ExecuteScalar())

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub ApriDati(ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Select Case tipoCliente
            Case Cliente.Privato
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, STR_ANAGRAFICA_CLIENTI, MODULO_ANAGRAFICA_CLIENTI)

               ' Per la versione demo.
               ' Se è un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(ANA_CLIENTI)) = True Then
                        Exit Sub
                     End If
                  End If
               End If

            Case Cliente.Azienda
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, STR_ANAGRAFICA_AZIENDE, MODULO_ANAGRAFICA_AZIENDE)

               ' Per la versione demo.
               ' Se è un nuovo inserimento verifica il numero dei record.
               If val = String.Empty Then
                  If g_VerDemo = True Then
                     ' Test per la versione demo.
                     If VerificaNumRecord(LeggiNumRecord(ANA_AZIENDE)) = True Then
                        Exit Sub
                     End If
                  End If
               End If
         End Select

         Dim frm As New ClientiPos()
         frm.Tag = val
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Aziende.ToString
               If operatore.AnagAziende = VALORE_NESSUNO Or operatore.AnagAziende = VALORE_LETTURA Then
                  eui_cmdNuovo.Enabled = False
                  eui_cmdModifica.Enabled = False
               Else
                  eui_cmdNuovo.Enabled = True
                  eui_cmdModifica.Enabled = True
               End If

            Case Finestra.Clienti.ToString
               If operatore.AnagClienti = VALORE_NESSUNO Or operatore.AnagClienti = VALORE_LETTURA Then
                  eui_cmdNuovo.Enabled = False
                  eui_cmdModifica.Enabled = False
               Else
                  eui_cmdNuovo.Enabled = True
                  eui_cmdModifica.Enabled = True
               End If

         End Select

         Return eui_cmdNuovo.Enabled

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return True
      End Try

   End Function

   Public Sub ImpostaComandi()
      If lstvClienti.Items.Count = 1 Then
         ' Disattiva i pulsanti appropriati.
         eui_cmdModifica.Enabled = False
      Else
         ' Attiva i pulsanti appropriati.
         eui_cmdModifica.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()

      Select Case tipoCliente
         Case Cliente.Privato
            If ImpostaFunzioniOperatore(Finestra.Clienti) = True Then
               ImpostaComandi()
            End If

         Case Cliente.Azienda
            If ImpostaFunzioniOperatore(Finestra.Aziende) = True Then
               ImpostaComandi()
            End If
      End Select
   End Sub

   Private Sub ImpostaClienteCoperti()
      Try
         lstvClienti.Focus()

         Select Case tipoCliente
            Case Cliente.Azienda
               g_frmCoperti.txtIdAzienda.Text = lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(2).Text
               g_frmCoperti.txtIdCliente.Text = "0"

            Case Cliente.Privato
               g_frmCoperti.txtIdCliente.Text = lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(2).Text
               g_frmCoperti.txtIdAzienda.Text = "0"
         End Select

         Dim nomeCliente As String = lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(1).Text
         If nomeCliente = "< NESSUNO >" Then
            g_frmCoperti.eui_cmdCliente.Text = "Seleziona cliente"
         Else
            ' Nome cliente.
            g_frmCoperti.eui_cmdCliente.Text = nomeCliente
         End If

         ' Indirizzo.
         g_frmCoperti.txtIndirizzo.Text = txtIndirizzo.Text

         ' CAP.
         g_frmCoperti.txtCap.Text = txtCap.Text

         ' Città.
         g_frmCoperti.txtCittà.Text = txtCittà.Text

         ' Provincia.
         g_frmCoperti.txtProv.Text = txtProv.Text

         ' Partita IVA.
         g_frmCoperti.txtPIva.Text = txtPIva.Text

         ' Codice fiscale.
         g_frmCoperti.txtCodiceFiscale.Text = txtCodiceFiscale.Text

         ' % IVA.
         g_frmCoperti.txtIva.Text = txtIva.Text

         ' % Sconto.
         g_frmCoperti.txtValSconto.Text = txtValSconto.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub ImpostaClienteAsporto()
      Try
         lstvClienti.Focus()

         Select Case tipoCliente
            Case Cliente.Azienda
               g_frmAsporto.txtIdAzienda.Text = lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(2).Text
               g_frmAsporto.txtIdCliente.Text = "0"

            Case Cliente.Privato
               g_frmAsporto.txtIdCliente.Text = lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(2).Text
               g_frmAsporto.txtIdAzienda.Text = "0"
         End Select

         Dim nomeCliente As String = lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(1).Text
         If nomeCliente = "< NESSUNO >" Then
            g_frmAsporto.eui_cmdCliente.Text = "Seleziona cliente"
         Else
            ' Nome cliente.
            g_frmAsporto.eui_cmdCliente.Text = nomeCliente
         End If

         ' Indirizzo.
         g_frmAsporto.txtIndirizzo.Text = txtIndirizzo.Text

         ' CAP.
         g_frmAsporto.txtCap.Text = txtCap.Text

         ' Città.
         g_frmAsporto.txtCittà.Text = txtCittà.Text

         ' Provincia.
         g_frmAsporto.txtProv.Text = txtProv.Text

         ' Partita IVA.
         g_frmAsporto.txtPIva.Text = txtPIva.Text

         ' Codice fiscale.
         g_frmAsporto.txtCodiceFiscale.Text = txtCodiceFiscale.Text

         ' % IVA.
         g_frmAsporto.txtIva.Text = txtIva.Text

         ' % Sconto.
         g_frmAsporto.txtValSconto.Text = txtValSconto.Text

         ' Inserisce i dati del cliente nelle Note.
         If nomeCliente <> String.Empty Then
            g_frmAsporto.eui_txtNote.Text = nomeCliente & " " & vbCrLf &
                                            txtIndirizzo.Text & " " & vbCrLf &
                                            txtCap.Text & " " & txtCittà.Text & " " & txtProv.Text
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub ImpostaClienteConto()
      Try
         lstvClienti.Focus()

         Select Case tipoCliente
            Case Cliente.Azienda
               g_frmContoPos.txtIdAzienda.Text = lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(2).Text
               g_frmContoPos.txtIdCliente.Text = "0"

            Case Cliente.Privato
               g_frmContoPos.txtIdCliente.Text = lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(2).Text
               g_frmContoPos.txtIdAzienda.Text = "0"
         End Select

         Dim nomeCliente As String = lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(1).Text
         If nomeCliente = "< NESSUNO >" Then
            g_frmContoPos.eui_cmdCliente.Text = "Seleziona cliente"
            g_frmContoPos.txtCognome.Text = String.Empty
            g_frmContoPos.txtNome.Text = String.Empty
         Else
            ' Nome cliente.
            g_frmContoPos.eui_cmdCliente.Text = nomeCliente
            g_frmContoPos.txtCognome.Text = txtCognome.Text
            g_frmContoPos.txtNome.Text = txtNome.Text
         End If

         ' Indirizzo.
         g_frmContoPos.txtIndirizzo.Text = txtIndirizzo.Text

         ' CAP.
         g_frmContoPos.txtCap.Text = txtCap.Text

         ' Città.
         g_frmContoPos.txtCittà.Text = txtCittà.Text

         ' Provincia.
         g_frmContoPos.txtProv.Text = txtProv.Text

         ' Partita IVA.
         g_frmContoPos.txtPIva.Text = txtPIva.Text

         ' CodiceFiscale.
         g_frmContoPos.txtCodiceFiscale.Text = txtCodiceFiscale.Text

         ' % IVA.
         ' Se è impostata l'aliquota Iva per il cliente... Altrimenti viene utilzzata quella di reparto.
         If txtIva.Text <> VALORE_ZERO Then
            g_frmContoPos.txtIva.Text = txtIva.Text
         End If

         ' % Sconto.
         g_frmContoPos.txtValSconto.Text = txtValSconto.Text & "%"

         ' Permette di calcolare il valore dello sconto se presente.
         g_frmContoPos.AggiornaValoriConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAzienda_Click(sender As Object, e As EventArgs) Handles eui_cmdAzienda.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Me.Text = TITOLO_FINESTRA & "- AZIENDE"

         CaricaListaClienteAzienda(lstvClienti, ANA_AZIENDE)

         tipoCliente = Cliente.Azienda

         ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
         SelezionaCliente(codiceAzienda)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdPrivati_Click(sender As Object, e As EventArgs) Handles eui_cmdPrivati.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Me.Text = TITOLO_FINESTRA & "- PRIVATI"

         CaricaListaCliente(lstvClienti, ANA_CLIENTI)

         tipoCliente = Cliente.Privato

         ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
         SelezionaCliente(codiceCliente)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdClientiSu_Click(sender As Object, e As EventArgs) Handles eui_cmdClientiSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvClienti.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvClienti.TopItem.Index

         IndiceLista = PrimoElemento - 1

         If IndiceLista < 0 Then
            Exit Sub
         Else
            lstvClienti.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdClientiGiù_Click(sender As Object, e As EventArgs) Handles eui_cmdClientiGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvClienti.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvClienti.TopItem.Index

         IndiceLista = PrimoElemento + NumElementi

         If IndiceLista > lstvClienti.Items.Count - 1 Then
            Exit Sub
         Else
            lstvClienti.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdNuovo_Click(sender As Object, e As EventArgs) Handles eui_cmdNuovo.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ApriDati("")

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         Select Case tipoCliente
            Case Cliente.Privato
               Dim codiceCliente As String = LeggiUltimoRecord(ANA_CLIENTI).ToString

               CaricaListaCliente(lstvClienti, ANA_CLIENTI)

               ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
               SelezionaCliente(codiceCliente)

               LeggiDatiCliente(ANA_CLIENTI, codiceCliente)

            Case Cliente.Azienda
               Dim codiceAzienda As String = LeggiUltimoRecord(ANA_AZIENDE).ToString

               CaricaListaClienteAzienda(lstvClienti, ANA_AZIENDE)

               ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
               SelezionaCliente(codiceAzienda)

               LeggiDatiClienteAzienda(ANA_AZIENDE, codiceAzienda)
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdModifica_Click(sender As Object, e As EventArgs) Handles eui_cmdModifica.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)


         lstvClienti.Focus()
         Dim idCliente As String = lstvClienti.Items(lstvClienti.FocusedItem.Index).SubItems(2).Text

         ' Se è selezionata la voce Nessuno.
         If idCliente = "0" Then
            Exit Sub
         End If

         ' Apre la finestra per l'inserimento di nuovi dati.
         ApriDati(idCliente)

         Select Case tipoCliente
            Case Cliente.Privato
               CaricaListaCliente(lstvClienti, ANA_CLIENTI)

               ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
               SelezionaCliente(idCliente)

               LeggiDatiCliente(ANA_CLIENTI, idCliente)

            Case Cliente.Azienda
               CaricaListaClienteAzienda(lstvClienti, ANA_AZIENDE)

               ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
               SelezionaCliente(idCliente)

               LeggiDatiClienteAzienda(ANA_AZIENDE, idCliente)
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Select Case Me.Tag
            Case "COPERTI"
               ImpostaClienteCoperti()

            Case "CONTO"
               ImpostaClienteConto()

            Case "ASPORTO"
               ImpostaClienteAsporto()

         End Select

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub
End Class
