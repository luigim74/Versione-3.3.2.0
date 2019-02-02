Imports System.IO
Imports System.Data.OleDb

Public Class ElencoClientiPos
   Inherits System.Windows.Forms.Form

   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_AZIENDE As String = "Aziende"
   Const ALTEZZA_RIGA_DETTAGLI As Short = 24

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
   Friend WithEvents cmdPrivato As System.Windows.Forms.Button
   Friend WithEvents cmdAzienda As System.Windows.Forms.Button
   Friend WithEvents cmdConferma As System.Windows.Forms.Button
   Friend WithEvents cmdClientiSu As System.Windows.Forms.Button
   Friend WithEvents cmdClientiGiù As System.Windows.Forms.Button
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
   Friend WithEvents cmdModifica As System.Windows.Forms.Button
   Friend WithEvents cmdNuovo As System.Windows.Forms.Button
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
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoClientiPos))
      Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Azienda Ligure SRL")
      Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Montana Luigi")
      Dim ListViewItem3 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem("Rossi Fabio")
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.cmdPrivato = New System.Windows.Forms.Button()
      Me.cmdAzienda = New System.Windows.Forms.Button()
      Me.cmdConferma = New System.Windows.Forms.Button()
      Me.cmdClientiSu = New System.Windows.Forms.Button()
      Me.cmdClientiGiù = New System.Windows.Forms.Button()
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
      Me.cmdNuovo = New System.Windows.Forms.Button()
      Me.cmdModifica = New System.Windows.Forms.Button()
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
      Me.cmdAnnulla.Location = New System.Drawing.Point(528, 400)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(152, 56)
      Me.cmdAnnulla.TabIndex = 8
      Me.cmdAnnulla.Text = "&ANNULLA"
      Me.cmdAnnulla.UseVisualStyleBackColor = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'cmdPrivato
      '
      Me.cmdPrivato.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdPrivato.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdPrivato.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdPrivato.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPrivato.ForeColor = System.Drawing.Color.White
      Me.cmdPrivato.Location = New System.Drawing.Point(528, 80)
      Me.cmdPrivato.Name = "cmdPrivato"
      Me.cmdPrivato.Size = New System.Drawing.Size(152, 56)
      Me.cmdPrivato.TabIndex = 2
      Me.cmdPrivato.Text = "&PRIVATI"
      Me.cmdPrivato.UseVisualStyleBackColor = False
      '
      'cmdAzienda
      '
      Me.cmdAzienda.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAzienda.BackColor = System.Drawing.Color.LightCoral
      Me.cmdAzienda.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdAzienda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAzienda.ForeColor = System.Drawing.Color.White
      Me.cmdAzienda.Location = New System.Drawing.Point(528, 16)
      Me.cmdAzienda.Name = "cmdAzienda"
      Me.cmdAzienda.Size = New System.Drawing.Size(152, 56)
      Me.cmdAzienda.TabIndex = 1
      Me.cmdAzienda.Text = "&AZIENDE"
      Me.cmdAzienda.UseVisualStyleBackColor = False
      '
      'cmdConferma
      '
      Me.cmdConferma.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdConferma.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdConferma.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdConferma.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdConferma.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdConferma.ForeColor = System.Drawing.Color.White
      Me.cmdConferma.Location = New System.Drawing.Point(528, 336)
      Me.cmdConferma.Name = "cmdConferma"
      Me.cmdConferma.Size = New System.Drawing.Size(152, 56)
      Me.cmdConferma.TabIndex = 7
      Me.cmdConferma.Text = "&CONFERMA"
      Me.cmdConferma.UseVisualStyleBackColor = False
      '
      'cmdClientiSu
      '
      Me.cmdClientiSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdClientiSu.BackColor = System.Drawing.Color.Silver
      Me.cmdClientiSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdClientiSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdClientiSu.Image = CType(resources.GetObject("cmdClientiSu.Image"), System.Drawing.Image)
      Me.cmdClientiSu.Location = New System.Drawing.Point(528, 152)
      Me.cmdClientiSu.Name = "cmdClientiSu"
      Me.cmdClientiSu.Size = New System.Drawing.Size(152, 80)
      Me.cmdClientiSu.TabIndex = 5
      Me.cmdClientiSu.UseVisualStyleBackColor = False
      '
      'cmdClientiGiù
      '
      Me.cmdClientiGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdClientiGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdClientiGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdClientiGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdClientiGiù.Image = CType(resources.GetObject("cmdClientiGiù.Image"), System.Drawing.Image)
      Me.cmdClientiGiù.Location = New System.Drawing.Point(528, 240)
      Me.cmdClientiGiù.Name = "cmdClientiGiù"
      Me.cmdClientiGiù.Size = New System.Drawing.Size(152, 80)
      Me.cmdClientiGiù.TabIndex = 6
      Me.cmdClientiGiù.UseVisualStyleBackColor = False
      '
      'lstvClienti
      '
      Me.lstvClienti.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvClienti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Id, Me.NomeCliente, Me.IdCliente})
      Me.lstvClienti.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvClienti.FullRowSelect = True
      Me.lstvClienti.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvClienti.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2, ListViewItem3})
      Me.lstvClienti.Location = New System.Drawing.Point(8, 16)
      Me.lstvClienti.MultiSelect = False
      Me.lstvClienti.Name = "lstvClienti"
      Me.lstvClienti.Size = New System.Drawing.Size(504, 448)
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
      Me.txtIva.Location = New System.Drawing.Point(184, 568)
      Me.txtIva.MaxLength = 10
      Me.txtIva.Name = "txtIva"
      Me.txtIva.ReadOnly = True
      Me.txtIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIva.Size = New System.Drawing.Size(104, 29)
      Me.txtIva.TabIndex = 14
      Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(184, 536)
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
      Me.txtProv.Location = New System.Drawing.Point(472, 504)
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
      Me.txtCap.Location = New System.Drawing.Point(184, 504)
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
      Me.txtCittà.Location = New System.Drawing.Point(262, 504)
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
      Me.txtIndirizzo.Location = New System.Drawing.Point(184, 472)
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
      Me.Label11.Location = New System.Drawing.Point(8, 576)
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
      Me.Label31.Location = New System.Drawing.Point(8, 544)
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
      Me.Label5.Location = New System.Drawing.Point(8, 512)
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
      Me.Label4.Location = New System.Drawing.Point(8, 480)
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
      Me.txtValSconto.Location = New System.Drawing.Point(408, 568)
      Me.txtValSconto.MaxLength = 10
      Me.txtValSconto.Name = "txtValSconto"
      Me.txtValSconto.ReadOnly = True
      Me.txtValSconto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtValSconto.Size = New System.Drawing.Size(104, 29)
      Me.txtValSconto.TabIndex = 15
      Me.txtValSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(312, 576)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(92, 16)
      Me.Label1.TabIndex = 241
      Me.Label1.Text = "% SCONTO:"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'cmdNuovo
      '
      Me.cmdNuovo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNuovo.BackColor = System.Drawing.Color.White
      Me.cmdNuovo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNuovo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNuovo.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdNuovo.Location = New System.Drawing.Point(528, 472)
      Me.cmdNuovo.Name = "cmdNuovo"
      Me.cmdNuovo.Size = New System.Drawing.Size(152, 56)
      Me.cmdNuovo.TabIndex = 3
      Me.cmdNuovo.Text = "&NUOVO"
      Me.cmdNuovo.UseVisualStyleBackColor = False
      '
      'cmdModifica
      '
      Me.cmdModifica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdModifica.BackColor = System.Drawing.Color.White
      Me.cmdModifica.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdModifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdModifica.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdModifica.Location = New System.Drawing.Point(528, 536)
      Me.cmdModifica.Name = "cmdModifica"
      Me.cmdModifica.Size = New System.Drawing.Size(152, 56)
      Me.cmdModifica.TabIndex = 4
      Me.cmdModifica.Text = "&MODIFICA"
      Me.cmdModifica.UseVisualStyleBackColor = False
      '
      'ElencoClientiPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(23, 55)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(689, 611)
      Me.Controls.Add(Me.cmdModifica)
      Me.Controls.Add(Me.cmdNuovo)
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
      Me.Controls.Add(Me.cmdClientiSu)
      Me.Controls.Add(Me.cmdClientiGiù)
      Me.Controls.Add(Me.cmdConferma)
      Me.Controls.Add(Me.cmdPrivato)
      Me.Controls.Add(Me.cmdAzienda)
      Me.Controls.Add(Me.cmdAnnulla)
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
      txtIndirizzo.Text = ""
      txtCap.Text = ""
      txtCittà.Text = ""
      txtProv.Text = ""
      txtPIva.Text = ""
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
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Cognome").ToString.ToUpper & " " & dr.Item("Nome").ToString.ToUpper)

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
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("RagSociale").ToString.ToUpper)

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
               txtValSconto.Text = CFormatta.FormattaNumeroDouble(dr.Item("Sconto")) & "%"
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
               txtValSconto.Text = CFormatta.FormattaNumeroDouble(dr.Item("Sconto"))
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
               cmdAzienda.PerformClick()

            Case Cliente.Privato
               cmdPrivato.PerformClick()

         End Select

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub cmdAzienda_Click(sender As System.Object, e As System.EventArgs) Handles cmdAzienda.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         CaricaListaClienteAzienda(lstvClienti, ANA_AZIENDE)

         cmdAzienda.BackColor = Color.LightCoral
         cmdPrivato.BackColor = Color.DodgerBlue

         tipoCliente = Cliente.Azienda

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
         SelezionaCliente(codiceAzienda)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub cmdPrivato_Click(sender As System.Object, e As System.EventArgs) Handles cmdPrivato.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         CaricaListaCliente(lstvClienti, ANA_CLIENTI)

         cmdPrivato.BackColor = Color.LightCoral
         cmdAzienda.BackColor = Color.DodgerBlue

         tipoCliente = Cliente.Privato

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
         SelezionaCliente(codiceCliente)

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

   Private Sub cmdConferma_Click(sender As System.Object, e As System.EventArgs) Handles cmdConferma.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Select Case Me.Tag
            Case "COPERTI"
               ImpostaClienteCoperti()

            Case "CONTO"
               ImpostaClienteConto()

         End Select

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdClientiSu_Click(sender As System.Object, e As System.EventArgs) Handles cmdClientiSu.Click
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

   Private Sub cmdClientiGiù_Click(sender As System.Object, e As System.EventArgs) Handles cmdClientiGiù.Click
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

   Private Sub cmdNuovo_Click(sender As System.Object, e As System.EventArgs) Handles cmdNuovo.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ApriDati("")

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         Select Case tipoCliente
            Case Cliente.Privato
               Dim codiceCliente As String = LeggiUltimoRecord(ANA_CLIENTI)

               CaricaListaCliente(lstvClienti, ANA_CLIENTI)

               ' In caso di cliente già impostato seleziona i relativi dati, altrimenti seleziona il primo elemento.
               SelezionaCliente(codiceCliente)

               LeggiDatiCliente(ANA_CLIENTI, codiceCliente)

            Case Cliente.Azienda
               Dim codiceAzienda As String = LeggiUltimoRecord(ANA_AZIENDE)

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

   Private Sub cmdModifica_Click(sender As System.Object, e As System.EventArgs) Handles cmdModifica.Click
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
            Case Finestra.Aziende
               If operatore.AnagAziende = VALORE_NESSUNO Or operatore.AnagAziende = VALORE_LETTURA Then
                  cmdNuovo.Enabled = False
                  cmdModifica.Enabled = False
               Else
                  cmdNuovo.Enabled = True
                  cmdModifica.Enabled = True
               End If

            Case Finestra.Clienti
               If operatore.AnagClienti = VALORE_NESSUNO Or operatore.AnagClienti = VALORE_LETTURA Then
                  cmdNuovo.Enabled = False
                  cmdModifica.Enabled = False
               Else
                  cmdNuovo.Enabled = True
                  cmdModifica.Enabled = True
               End If

         End Select

         Return cmdNuovo.Enabled

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return True
      End Try

   End Function

   Public Sub ImpostaComandi()
      If lstvClienti.Items.Count = 1 Then
         ' Disattiva i pulsanti appropriati.
         cmdModifica.Enabled = False
      Else
         ' Attiva i pulsanti appropriati.
         cmdModifica.Enabled = True
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
            g_frmCoperti.cmdCliente.Text = "SELEZIONA CLIENTE"
         Else
            ' Nome cliente.
            g_frmCoperti.cmdCliente.Text = nomeCliente
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

         ' % IVA.
         g_frmCoperti.txtIva.Text = txtIva.Text

         ' % Sconto.
         g_frmCoperti.txtValSconto.Text = txtValSconto.Text

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
            g_frmContoPos.cmdCliente.Text = "SELEZIONA CLIENTE"
         Else
            ' Nome cliente.
            g_frmContoPos.cmdCliente.Text = nomeCliente
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

         ' % IVA.
         g_frmContoPos.txtIva.Text = txtIva.Text

         ' % Sconto.
         g_frmContoPos.txtValSconto.Text = txtValSconto.Text

         ' Permette di calcolare il valore dello sconto se presente.
         g_frmContoPos.cmdOk.PerformClick()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
