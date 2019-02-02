Imports System.IO
Imports System.Data.OleDb

Public Class ElencoContiPos
   Inherits System.Windows.Forms.Form

   Const TAB_DOCUMENTI As String = "Documenti"
   Const ALTEZZA_RIGA_DETTAGLI As Short = 24

   Const TITOLO_FINESTRA As String = "ELENCO CONTI PARCHEGGIATI"

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
   Private sqlPeriodo As String
   Private cmd As New OleDbCommand(sql, cn)

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_cmdModifica As Elegant.Ui.Button
   Friend WithEvents eui_cmdViste As Elegant.Ui.Button
   Friend WithEvents eui_cmdEsci As Elegant.Ui.Button
   Friend WithEvents eui_cmdElabora As Elegant.Ui.Button
   Friend WithEvents eui_cmdElimina As Elegant.Ui.Button
   Friend WithEvents eui_cmdContiSu As Elegant.Ui.Button
   Friend WithEvents eui_cmdContiGiù As Elegant.Ui.Button
   Friend WithEvents lstvConti As ListView
   Friend WithEvents IdConto As ColumnHeader
   Friend WithEvents NumeroConto As ColumnHeader
   Friend WithEvents DataConto As ColumnHeader
   Friend WithEvents OraConto As ColumnHeader
   Friend WithEvents ClienteConto As ColumnHeader
   Friend WithEvents TavoloConto As ColumnHeader
   Friend WithEvents StatoConto As ColumnHeader
   Friend WithEvents TotaleConto As ColumnHeader
   Friend WithEvents SospesoConto As ColumnHeader
   Friend WithEvents eui_cmdDeselTutti As Elegant.Ui.Button
   Friend WithEvents eui_cmdSelTutti As Elegant.Ui.Button
   Friend WithEvents eui_cmdChiudi As Elegant.Ui.Button
   Public WithEvents lblTotSospesi As Label
   Public WithEvents lblTotConti As Label
   Public WithEvents Label6 As Label
   Public WithEvents lblNumConti As Label
   Public WithEvents Label1 As Label
   Friend WithEvents eui_txtNote As Elegant.Ui.TextBox
   Friend WithEvents CameriereConto As ColumnHeader
   Friend WithEvents IdClienteConto As ColumnHeader

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
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoContiPos))
      Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "29/03/2016", System.Drawing.Color.Black, System.Drawing.SystemColors.AppWorkspace, New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "15:30"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "5", System.Drawing.Color.Black, System.Drawing.SystemColors.AppWorkspace, New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Luigi Montana"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "A5"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Aperto"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "9.250,00"), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "50,00")}, -1)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_cmdModifica = New Elegant.Ui.Button()
      Me.eui_cmdViste = New Elegant.Ui.Button()
      Me.eui_cmdEsci = New Elegant.Ui.Button()
      Me.eui_cmdElabora = New Elegant.Ui.Button()
      Me.eui_cmdContiSu = New Elegant.Ui.Button()
      Me.eui_cmdContiGiù = New Elegant.Ui.Button()
      Me.eui_cmdElimina = New Elegant.Ui.Button()
      Me.lstvConti = New System.Windows.Forms.ListView()
      Me.DataConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.OraConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.NumeroConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ClienteConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TavoloConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.StatoConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.TotaleConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.SospesoConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.IdConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.IdClienteConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.CameriereConto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.eui_cmdSelTutti = New Elegant.Ui.Button()
      Me.eui_cmdDeselTutti = New Elegant.Ui.Button()
      Me.eui_cmdChiudi = New Elegant.Ui.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.lblTotConti = New System.Windows.Forms.Label()
      Me.lblTotSospesi = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblNumConti = New System.Windows.Forms.Label()
      Me.eui_txtNote = New Elegant.Ui.TextBox()
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
      'eui_cmdModifica
      '
      Me.eui_cmdModifica.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.eui_cmdModifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdModifica.Id = "d95d7252-15d6-49f8-bdd6-7a4da532e67a"
      Me.eui_cmdModifica.Location = New System.Drawing.Point(452, 593)
      Me.eui_cmdModifica.Name = "eui_cmdModifica"
      Me.eui_cmdModifica.Size = New System.Drawing.Size(120, 53)
      Me.eui_cmdModifica.TabIndex = 6
      Me.eui_cmdModifica.Text = "&Modifica"
      '
      'eui_cmdViste
      '
      Me.eui_cmdViste.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdViste.Id = "80b9e79e-4a8a-47af-a688-45efa3d1020f"
      Me.eui_cmdViste.Location = New System.Drawing.Point(12, 9)
      Me.eui_cmdViste.Name = "eui_cmdViste"
      Me.eui_cmdViste.Size = New System.Drawing.Size(647, 31)
      Me.eui_cmdViste.TabIndex = 0
      Me.eui_cmdViste.Text = "< TUTTI >"
      '
      'eui_cmdEsci
      '
      Me.eui_cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdEsci.Id = "2b8ba805-3369-4c5e-b816-dc81f831067e"
      Me.eui_cmdEsci.Location = New System.Drawing.Point(839, 593)
      Me.eui_cmdEsci.Name = "eui_cmdEsci"
      Me.eui_cmdEsci.Size = New System.Drawing.Size(120, 53)
      Me.eui_cmdEsci.TabIndex = 9
      Me.eui_cmdEsci.Text = "&Esci"
      '
      'eui_cmdElabora
      '
      Me.eui_cmdElabora.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdElabora.Id = "7a1eb92e-859a-4d27-b576-33ca41ac3da8"
      Me.eui_cmdElabora.Location = New System.Drawing.Point(318, 593)
      Me.eui_cmdElabora.Name = "eui_cmdElabora"
      Me.eui_cmdElabora.Size = New System.Drawing.Size(120, 53)
      Me.eui_cmdElabora.TabIndex = 6
      Me.eui_cmdElabora.Text = "E&labora"
      Me.eui_cmdElabora.Visible = False
      '
      'eui_cmdContiSu
      '
      Me.eui_cmdContiSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdContiSu.Id = "b15386b9-8061-48cc-991d-39bafe9937f0"
      Me.eui_cmdContiSu.Location = New System.Drawing.Point(12, 593)
      Me.eui_cmdContiSu.Name = "eui_cmdContiSu"
      Me.eui_cmdContiSu.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdContiSu.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdContiSu.Size = New System.Drawing.Size(120, 53)
      Me.eui_cmdContiSu.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdContiSu.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdContiSu.TabIndex = 4
      '
      'eui_cmdContiGiù
      '
      Me.eui_cmdContiGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdContiGiù.Id = "4f786491-c59c-4dcc-8654-dc0a91bfc6de"
      Me.eui_cmdContiGiù.Location = New System.Drawing.Point(141, 593)
      Me.eui_cmdContiGiù.Name = "eui_cmdContiGiù"
      Me.eui_cmdContiGiù.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdContiGiù.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdContiGiù.Size = New System.Drawing.Size(120, 53)
      Me.eui_cmdContiGiù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdContiGiù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdContiGiù.TabIndex = 5
      '
      'eui_cmdElimina
      '
      Me.eui_cmdElimina.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdElimina.Id = "c372cc05-2e91-44b2-9fdc-82c1047e969b"
      Me.eui_cmdElimina.Location = New System.Drawing.Point(581, 593)
      Me.eui_cmdElimina.Name = "eui_cmdElimina"
      Me.eui_cmdElimina.Size = New System.Drawing.Size(120, 53)
      Me.eui_cmdElimina.TabIndex = 7
      Me.eui_cmdElimina.Text = "El&imina"
      '
      'lstvConti
      '
      Me.lstvConti.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvConti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.DataConto, Me.OraConto, Me.NumeroConto, Me.ClienteConto, Me.TavoloConto, Me.StatoConto, Me.TotaleConto, Me.SospesoConto, Me.IdConto, Me.IdClienteConto, Me.CameriereConto})
      Me.lstvConti.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvConti.FullRowSelect = True
      ListViewItem1.StateImageIndex = 0
      Me.lstvConti.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
      Me.lstvConti.Location = New System.Drawing.Point(12, 43)
      Me.lstvConti.MultiSelect = False
      Me.lstvConti.Name = "lstvConti"
      Me.lstvConti.Size = New System.Drawing.Size(947, 457)
      Me.lstvConti.TabIndex = 3
      Me.lstvConti.UseCompatibleStateImageBehavior = False
      Me.lstvConti.View = System.Windows.Forms.View.Details
      '
      'DataConto
      '
      Me.DataConto.Text = "Data"
      Me.DataConto.Width = 120
      '
      'OraConto
      '
      Me.OraConto.Text = "Ora"
      Me.OraConto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.OraConto.Width = 70
      '
      'NumeroConto
      '
      Me.NumeroConto.DisplayIndex = 3
      Me.NumeroConto.Text = "Numero"
      Me.NumeroConto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.NumeroConto.Width = 85
      '
      'ClienteConto
      '
      Me.ClienteConto.DisplayIndex = 4
      Me.ClienteConto.Text = "Cliente"
      Me.ClienteConto.Width = 230
      '
      'TavoloConto
      '
      Me.TavoloConto.DisplayIndex = 6
      Me.TavoloConto.Text = "Tavolo"
      Me.TavoloConto.Width = 110
      '
      'StatoConto
      '
      Me.StatoConto.DisplayIndex = 7
      Me.StatoConto.Text = "Stato"
      Me.StatoConto.Width = 100
      '
      'TotaleConto
      '
      Me.TotaleConto.DisplayIndex = 8
      Me.TotaleConto.Text = "Totale"
      Me.TotaleConto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.TotaleConto.Width = 100
      '
      'SospesoConto
      '
      Me.SospesoConto.DisplayIndex = 9
      Me.SospesoConto.Text = "Sospeso"
      Me.SospesoConto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.SospesoConto.Width = 100
      '
      'IdConto
      '
      Me.IdConto.DisplayIndex = 2
      Me.IdConto.Text = ""
      Me.IdConto.Width = 0
      '
      'IdClienteConto
      '
      Me.IdClienteConto.DisplayIndex = 5
      Me.IdClienteConto.Width = 0
      '
      'CameriereConto
      '
      Me.CameriereConto.Width = 0
      '
      'eui_cmdSelTutti
      '
      Me.eui_cmdSelTutti.Enabled = False
      Me.eui_cmdSelTutti.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSelTutti.Id = "b5406bf5-e8f8-4e84-bd58-ae631b693e72"
      Me.eui_cmdSelTutti.Location = New System.Drawing.Point(671, 9)
      Me.eui_cmdSelTutti.Name = "eui_cmdSelTutti"
      Me.eui_cmdSelTutti.Size = New System.Drawing.Size(138, 31)
      Me.eui_cmdSelTutti.TabIndex = 1
      Me.eui_cmdSelTutti.Text = "&Sel. tutti"
      '
      'eui_cmdDeselTutti
      '
      Me.eui_cmdDeselTutti.Enabled = False
      Me.eui_cmdDeselTutti.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdDeselTutti.Id = "f9cfb57f-4c62-419a-a5f7-c6aa0f4a0667"
      Me.eui_cmdDeselTutti.Location = New System.Drawing.Point(821, 9)
      Me.eui_cmdDeselTutti.Name = "eui_cmdDeselTutti"
      Me.eui_cmdDeselTutti.Size = New System.Drawing.Size(138, 31)
      Me.eui_cmdDeselTutti.TabIndex = 2
      Me.eui_cmdDeselTutti.Text = "&Desel. tutti"
      '
      'eui_cmdChiudi
      '
      Me.eui_cmdChiudi.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdChiudi.Id = "a60d81c3-7001-4f7d-839b-6c593462be03"
      Me.eui_cmdChiudi.Location = New System.Drawing.Point(710, 593)
      Me.eui_cmdChiudi.Name = "eui_cmdChiudi"
      Me.eui_cmdChiudi.Size = New System.Drawing.Size(120, 53)
      Me.eui_cmdChiudi.TabIndex = 8
      Me.eui_cmdChiudi.Text = "&Chiudi"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(545, 560)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(161, 24)
      Me.Label6.TabIndex = 279
      Me.Label6.Text = "TOTALE EURO:"
      '
      'lblTotConti
      '
      Me.lblTotConti.BackColor = System.Drawing.Color.Transparent
      Me.lblTotConti.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblTotConti.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotConti.ForeColor = System.Drawing.Color.DarkGreen
      Me.lblTotConti.Location = New System.Drawing.Point(712, 560)
      Me.lblTotConti.Name = "lblTotConti"
      Me.lblTotConti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblTotConti.Size = New System.Drawing.Size(117, 24)
      Me.lblTotConti.TabIndex = 280
      Me.lblTotConti.Text = "19.500,00"
      Me.lblTotConti.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'lblTotSospesi
      '
      Me.lblTotSospesi.BackColor = System.Drawing.Color.Transparent
      Me.lblTotSospesi.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblTotSospesi.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotSospesi.ForeColor = System.Drawing.Color.DarkRed
      Me.lblTotSospesi.Location = New System.Drawing.Point(835, 560)
      Me.lblTotSospesi.Name = "lblTotSospesi"
      Me.lblTotSospesi.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblTotSospesi.Size = New System.Drawing.Size(105, 24)
      Me.lblTotSospesi.TabIndex = 281
      Me.lblTotSospesi.Text = "19.500,00"
      Me.lblTotSospesi.TextAlign = System.Drawing.ContentAlignment.TopRight
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(12, 560)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(172, 24)
      Me.Label1.TabIndex = 282
      Me.Label1.Text = "TOTALE CONTI: "
      '
      'lblNumConti
      '
      Me.lblNumConti.BackColor = System.Drawing.Color.Transparent
      Me.lblNumConti.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblNumConti.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblNumConti.ForeColor = System.Drawing.Color.DarkBlue
      Me.lblNumConti.Location = New System.Drawing.Point(177, 560)
      Me.lblNumConti.Name = "lblNumConti"
      Me.lblNumConti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblNumConti.Size = New System.Drawing.Size(84, 24)
      Me.lblNumConti.TabIndex = 283
      Me.lblNumConti.Text = "100.000"
      '
      'eui_txtNote
      '
      Me.eui_txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtNote.Id = "5be9c876-20b0-4434-8ba2-62c34ba117bd"
      Me.eui_txtNote.Location = New System.Drawing.Point(12, 503)
      Me.eui_txtNote.Multiline = True
      Me.eui_txtNote.Name = "eui_txtNote"
      Me.eui_txtNote.ReadOnly = True
      Me.eui_txtNote.ScreenTip.Caption = "Note:"
      Me.eui_txtNote.ScreenTip.Text = "Note del conto selezionato."
      Me.eui_txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.eui_txtNote.Size = New System.Drawing.Size(947, 49)
      Me.eui_txtNote.TabIndex = 284
      Me.eui_txtNote.TextEditorWidth = 941
      '
      'ElencoContiPos
      '
      Me.AcceptButton = Me.eui_cmdModifica
      Me.AutoScaleBaseSize = New System.Drawing.Size(23, 55)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdEsci
      Me.ClientSize = New System.Drawing.Size(972, 657)
      Me.Controls.Add(Me.eui_txtNote)
      Me.Controls.Add(Me.lblNumConti)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.lblTotSospesi)
      Me.Controls.Add(Me.lblTotConti)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.eui_cmdChiudi)
      Me.Controls.Add(Me.eui_cmdDeselTutti)
      Me.Controls.Add(Me.eui_cmdSelTutti)
      Me.Controls.Add(Me.lstvConti)
      Me.Controls.Add(Me.eui_cmdElimina)
      Me.Controls.Add(Me.eui_cmdContiSu)
      Me.Controls.Add(Me.eui_cmdContiGiù)
      Me.Controls.Add(Me.eui_cmdModifica)
      Me.Controls.Add(Me.eui_cmdViste)
      Me.Controls.Add(Me.eui_cmdEsci)
      Me.Controls.Add(Me.eui_cmdElabora)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ElencoContiPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "ELENCO CONTI PARCHEGGIATI"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public Sub CaricaListaConti(ByVal lstv As ListView, ByVal tabella As String, ByVal sql As String, ByVal cliente As Boolean)
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand(sql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         ' Pulisce la lista per l'inserimento dei nuovi elementi.
         lstv.Items.Clear()

         ' ---------- VERSIONE FUTURA! ----------------------------------------------------------------------------
         ' Se vengono caricati i documenti di un singolo cliente visualizza le caselle di spunta per una selezione.
         'lstv.CheckBoxes = cliente
         'eui_cmdSelTutti.Enabled = cliente
         'eui_cmdDeselTutti.Enabled = cliente
         ' --------------------------------------------------------------------------------------------------------

         Do While dr.Read

            ' Data.
            Dim data As String = CFormatta.FormattaData_IT(Convert.ToDateTime(dr.Item("DataDoc")))
            Dim ora As DateTime = Convert.ToDateTime(dr.Item("OraDoc"))

            If data = Now.ToShortDateString And ora.Hour = Now.Hour Then
               lstv.Items.Add(data).ForeColor = Color.DarkRed
            Else
               lstv.Items.Add(data).ForeColor = Color.Black
            End If

            ' Ora.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("OraDoc").ToString)

            ' Numero.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("NumDoc").ToString)

            ' Cliente.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Cliente").ToString)

            ' Tavolo.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Tavolo").ToString)

            ' Stato.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("StatoDoc").ToString)

            ' Totale.
            Dim totale As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("TotDoc")))
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(totale)

            ' Sospeso.
            Dim sospeso As String = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Sospeso")))
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(sospeso)

            ' Id documento.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Id"))

            ' IdCliente.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("IdCliente"))

            ' Cameriere.
            lstv.Items(lstv.Items.Count - 1).SubItems.Add(dr.Item("Cameriere"))

         Loop

         ' Aggiorna i totali Conti e Sospesi.
         lblNumConti.Text = CFormatta.FormattaNumero(lstvConti.Items.Count)
         lblTotConti.Text = CFormatta.FormattaEuro(SommaColonna(lstvConti, 6))
         lblTotSospesi.Text = CFormatta.FormattaEuro(SommaColonna(lstvConti, 7))

         ' Se nella lista non ci sono conti.
         If lstv.Items.Count <> 0 Then
            eui_cmdModifica.Enabled = True
            eui_cmdElimina.Enabled = True
            eui_cmdChiudi.Enabled = True
         Else
            eui_cmdModifica.Enabled = False
            eui_cmdElimina.Enabled = False
            eui_cmdChiudi.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Function stringSqlContiTutti() As String
      Try
         'Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND Tavolo <> '' ORDER BY NumDoc DESC", TAB_DOCUMENTI)
         Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' ORDER BY NumDoc DESC", TAB_DOCUMENTI)

         Return sql

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function stringSqlContiChiusi() As String
      Try
         'Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND StatoDoc = 'Chiuso' AND Chiuso = 'No' AND Tavolo <> '' ORDER BY NumDoc DESC", TAB_DOCUMENTI)
         Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND StatoDoc = 'Chiuso' AND Chiuso = 'No' ORDER BY NumDoc DESC", TAB_DOCUMENTI)

         Return sql

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function stringSqlContiAperti() As String
      Try
         'Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto'  AND StatoDoc = 'Aperto' AND Chiuso = 'No' AND Tavolo <> '' ORDER BY NumDoc DESC", TAB_DOCUMENTI)
         Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto'  AND StatoDoc = 'Aperto' AND Chiuso = 'No' ORDER BY NumDoc DESC", TAB_DOCUMENTI)

         Return sql

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function stringSqlContiStampati() As String
      Try
         'Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto'  AND StatoDoc = 'Stampato' AND Chiuso = 'No' AND Tavolo <> '' ORDER BY NumDoc DESC", TAB_DOCUMENTI)
         Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto'  AND StatoDoc = 'Stampato' AND Chiuso = 'No' ORDER BY NumDoc DESC", TAB_DOCUMENTI)

         Return sql

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function stringSqlContiAnno() As String
      Try
         Dim anno As String = Year(Now)
         Dim inizioPeriodo As String = CFormatta.FormattaData("01/01/" & anno)
         Dim ultimoGiornoAnno As String = DateTime.DaysInMonth(anno, 12)
         Dim finePeriodo As String = CFormatta.FormattaData(ultimoGiornoAnno & "/12/" & anno)
         'Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND Tavolo <> '' AND DataDoc BETWEEN #{1}# AND #{2}# ORDER BY NumDoc DESC", TAB_DOCUMENTI, inizioPeriodo, finePeriodo)
         Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND DataDoc BETWEEN #{1}# AND #{2}# ORDER BY NumDoc DESC", TAB_DOCUMENTI, inizioPeriodo, finePeriodo)

         Return sql

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function stringSqlContiMese() As String
      Try
         Dim anno As String = Year(Now)
         Dim mese As String = Month(Now)
         Dim inizioPeriodo As String = CFormatta.FormattaData("01/" & mese & "/" & anno)
         Dim ultimoGiornoAnno As String = DateTime.DaysInMonth(anno, mese)
         Dim finePeriodo As String = CFormatta.FormattaData(ultimoGiornoAnno & "/12/" & anno)
         'Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND Tavolo <> '' AND DataDoc BETWEEN #{1}# AND #{2}# ORDER BY NumDoc DESC", TAB_DOCUMENTI, inizioPeriodo, finePeriodo)
         Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND DataDoc BETWEEN #{1}# AND #{2}# ORDER BY NumDoc DESC", TAB_DOCUMENTI, inizioPeriodo, finePeriodo)

         Return sql

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function stringSqlContiOggi() As String
      Try
         Dim oggi As String = CFormatta.FormattaData(Today.ToShortDateString)
         'Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND Tavolo <> '' AND DataDoc = #{1}# ORDER BY NumDoc DESC", TAB_DOCUMENTI, oggi)
         Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND DataDoc = #{1}# ORDER BY NumDoc DESC", TAB_DOCUMENTI, oggi)

         Return sql

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function stringSqlContiPeriodo(ByVal inizioPeriodo As String, ByVal finePeriodo As String) As String
      Try
         'sqlPeriodo = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND Tavolo <> '' AND DataDoc BETWEEN #{1}# AND #{2}# ORDER BY NumDoc DESC", TAB_DOCUMENTI, inizioPeriodo, finePeriodo)
         sqlPeriodo = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND DataDoc BETWEEN #{1}# AND #{2}# ORDER BY NumDoc DESC", TAB_DOCUMENTI, inizioPeriodo, finePeriodo)

         Return sqlPeriodo

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function stringSqlContiSenzaIntestazione() As String
      Try
         'Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND Tavolo <> '' AND Cliente = '{1}' ORDER BY NumDoc DESC", TAB_DOCUMENTI, String.Empty)
         Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND Cliente = '{1}' ORDER BY NumDoc DESC", TAB_DOCUMENTI, String.Empty)

         Return sql

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function stringSqlContiCliente(ByVal id As String) As String
      Try
         'Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND Tavolo <> '' AND IdCliente = '{1}' ORDER BY NumDoc DESC", TAB_DOCUMENTI, id)
         Dim sql = String.Format("SELECT * FROM {0} WHERE TipoDoc = 'Conto' AND Chiuso = 'No' AND IdCliente = '{1}' ORDER BY NumDoc DESC", TAB_DOCUMENTI, id)

         Return sql

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Public Sub LeggiDatiConti(ByVal tabella As String, ByVal id As String, ByVal parametro As String)
      'Try
      '   'ConnStringAnagrafiche = CreaConnString(PercorsoDB)

      '   ' Dichiara un oggetto connessione.
      '   Dim cn As New OleDbConnection(ConnString)

      '   cn.Open()

      '   Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE TipoDoc = 'Conto' ORDER BY NumDoc DESC", cn)
      '   Dim dr As OleDbDataReader = cmd.ExecuteReader()

      '   Do While dr.Read
      '      If IsDBNull(dr.Item("Cognome")) = False Then
      '         txtCognome.Text = dr.Item("Cognome").ToString
      '      Else
      '         txtCognome.Text = String.Empty
      '      End If
      '      If IsDBNull(dr.Item("Nome")) = False Then
      '         txtNome.Text = dr.Item("Nome").ToString
      '      Else
      '         txtNome.Text = String.Empty
      '      End If
      '      If IsDBNull(dr.Item("Indirizzo")) = False Then
      '         txtIndirizzo.Text = dr.Item("Indirizzo").ToString
      '      Else
      '         txtIndirizzo.Text = String.Empty
      '      End If
      '      If IsDBNull(dr.Item("Cap")) = False Then
      '         txtCap.Text = dr.Item("Cap").ToString
      '      Else
      '         txtCap.Text = String.Empty
      '      End If
      '      If IsDBNull(dr.Item("Città")) = False Then
      '         txtCittà.Text = dr.Item("Città").ToString
      '      Else
      '         txtCittà.Text = String.Empty
      '      End If
      '      If IsDBNull(dr.Item("Provincia")) = False Then
      '         txtProv.Text = dr.Item("Provincia").ToString
      '      Else
      '         txtProv.Text = String.Empty
      '      End If
      '      If IsDBNull(dr.Item("PIva")) = False Then
      '         txtPIva.Text = dr.Item("PIva").ToString
      '      Else
      '         txtPIva.Text = String.Empty
      '      End If
      '      If IsDBNull(dr.Item("CodFisc")) = False Then
      '         txtCodiceFiscale.Text = dr.Item("CodFisc").ToString
      '      Else
      '         txtCodiceFiscale.Text = String.Empty
      '      End If
      '      If IsDBNull(dr.Item("Iva")) = False Then
      '         txtIva.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Iva")))
      '      Else
      '         txtIva.Text = VALORE_ZERO
      '      End If
      '      If IsDBNull(dr.Item("Sconto")) = False Then
      '         txtValSconto.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Sconto"))) '& "%"
      '      Else
      '         txtValSconto.Text = VALORE_ZERO
      '      End If
      '   Loop

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   cn.Close()

      'End Try
   End Sub

   Public Sub LeggiNoteConto(ByVal tabella As String, ByVal id As String)
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            If IsDBNull(dr.Item("Note")) = False Then
               eui_txtNote.Text = dr.Item("Note").ToString
            Else
               eui_txtNote.Text = String.Empty
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Function ModificaStatoConto(ByVal tabella As String, ByVal codice As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET StatoDoc = 'Chiuso' " &
                             "WHERE Id = {1}",
                             tabella,
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

   Private Function EliminaConto(ByVal id As String) As Boolean
      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE Id = {1}", "Documenti", id)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

         Return True

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

   Private Sub AggiornaListaConto()
      Try
         Dim PERIODO As String = eui_cmdViste.Text

         Select Case eui_cmdViste.Text
            Case "< TUTTI >"
               CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiTutti, False)

            Case "< APERTI >"
               CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiAperti, False)

            Case "< CHIUSI >"
               CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiChiusi, False)

            Case "< ANNO CORRENTE " & Today.Year.ToString & " >"
               CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiAnno, False)

            Case "< MESE CORRENTE " & CFormatta.FormattaNumeroMese(Today.Month).ToUpper & " >"
               CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiMese, False)

            Case "< OGGI " & Today.ToShortDateString & " >"
               CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiOggi, False)

            Case PERIODO
               CaricaListaConti(lstvConti, TAB_DOCUMENTI, sqlPeriodo, False)

            Case "< SENZA INTESTAZIONE >"
               CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiSenzaIntestazione, False)

            Case Else
               ' Per cliente.
               If eui_cmdViste.Tag <> "0" Then
                  CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiCliente(eui_cmdViste.Tag), True)
               End If
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ElencoContiPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiTutti, False)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Seleziona il primo elemento della lista.
         If lstvConti.Items.Count <> 0 Then
            lstvConti.Items(0).Selected = True
         End If

      End Try
   End Sub

   Private Sub lstvConti_Resize(sender As Object, e As System.EventArgs) Handles lstvConti.Resize
      Try
         NumElementi = (lstvConti.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ApriDati(ByVal val As String)
      'Try
      '   ' Modifica il cursore del mouse.
      '   Cursor.Current = Cursors.AppStarting

      '   Select Case tipoCliente
      '      Case Cliente.Privato
      '         ' Registra loperazione effettuata dall'operatore identificato.
      '         g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, STR_ANAGRAFICA_CLIENTI, MODULO_ANAGRAFICA_CLIENTI)

      '         ' Per la versione demo.
      '         ' Se è un nuovo inserimento verifica il numero dei record.
      '         If val = String.Empty Then
      '            If g_VerDemo = True Then
      '               ' Test per la versione demo.
      '               If VerificaNumRecord(LeggiNumRecord(TAB_DOCUMENTI)) = True Then
      '                  Exit Sub
      '               End If
      '            End If
      '         End If

      '      Case Cliente.Azienda
      '         ' Registra loperazione effettuata dall'operatore identificato.
      '         g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, STR_ANAGRAFICA_AZIENDE, MODULO_ANAGRAFICA_AZIENDE)

      '         ' Per la versione demo.
      '         ' Se è un nuovo inserimento verifica il numero dei record.
      '         If val = String.Empty Then
      '            If g_VerDemo = True Then
      '               ' Test per la versione demo.
      '               If VerificaNumRecord(LeggiNumRecord(TAB_DOCUMENTI)) = True Then
      '                  Exit Sub
      '               End If
      '            End If
      '         End If
      '   End Select

      '   Dim frm As New ClientiPos()
      '   frm.Tag = val
      '   frm.ShowDialog()

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub eui_cmdViste_Click(sender As Object, e As EventArgs) Handles eui_cmdViste.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New ElencoVisteContiPos()
         If frm.ShowDialog() = DialogResult.OK Then
            eui_cmdViste.Tag = frm.Tag

            Select Case frm.Text
               Case "< TUTTI >"
                  eui_cmdViste.Text = frm.Text
                  CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiTutti, False)

               Case "< APERTI >"
                  eui_cmdViste.Text = frm.Text
                  CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiAperti, False)

               Case "< CHIUSI >"
                  eui_cmdViste.Text = frm.Text
                  CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiChiusi, False)

               Case "< STAMPATI >"
                  eui_cmdViste.Text = frm.Text
                  CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiStampati, False)

               Case "< ANNO CORRENTE >"
                  eui_cmdViste.Text = "< ANNO CORRENTE " & Today.Year.ToString & " >"
                  CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiAnno, False)

               Case "< MESE CORRENTE >"
                  eui_cmdViste.Text = "< MESE CORRENTE " & CFormatta.FormattaNumeroMese(Today.Month).ToUpper & " >"
                  CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiMese, False)

               Case "< OGGI >"
                  eui_cmdViste.Text = "< OGGI " & Today.ToShortDateString & " >"
                  CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiOggi, False)

               Case "< PERIODO >"
                  Dim frmPeriodo As New VisteContiPeriodoPOS

                  If frmPeriodo.ShowDialog() = DialogResult.OK Then
                     Dim inizioPeriodo As String = CFormatta.FormattaData(frmPeriodo.dtpDataInizioPeriodo.Value)
                     Dim finePeriodo As String = CFormatta.FormattaData(frmPeriodo.dtpDataFinePeriodo.Value)

                     eui_cmdViste.Text = "< PERIODO DAL " & frmPeriodo.dtpDataInizioPeriodo.Value.ToShortDateString & " AL " & frmPeriodo.dtpDataFinePeriodo.Value.ToShortDateString & " >"
                     CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiPeriodo(inizioPeriodo, finePeriodo), False)
                  End If

               Case "< SENZA INTESTAZIONE >"
                  eui_cmdViste.Text = frm.Text
                  CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiSenzaIntestazione, False)

               Case Else
                  ' Per cliente.
                  If frm.Tag <> "0" Then
                     eui_cmdViste.Text = frm.Text
                     eui_cmdViste.Tag = frm.Tag
                     CaricaListaConti(lstvConti, TAB_DOCUMENTI, stringSqlContiCliente(frm.Tag), True)
                  End If
            End Select
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Seleziona il primo elemento della lista.
         If lstvConti.Items.Count <> 0 Then
            lstvConti.Items(0).Selected = True
         End If

      End Try
   End Sub

   Private Sub eui_cmdSelTutti_Click(sender As Object, e As EventArgs) Handles eui_cmdSelTutti.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Seleziona tutti gli elementi.
         Dim i As Integer
         For i = 0 To lstvConti.Items.Count - 1
            lstvConti.Items(i).Checked = True
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Seleziona il primo elemento della lista.
         If lstvConti.Items.Count <> 0 Then
            lstvConti.Items(0).Selected = True
         End If

      End Try
   End Sub

   Private Sub eui_cmdDeselTutti_Click(sender As Object, e As EventArgs) Handles eui_cmdDeselTutti.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Deseleziona tutti gli elementi.
         Dim i As Integer
         For i = 0 To lstvConti.Items.Count - 1
            lstvConti.Items(i).Checked = False
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Seleziona il primo elemento della lista.
         If lstvConti.Items.Count <> 0 Then
            lstvConti.Items(0).Selected = True
         End If

      End Try
   End Sub

   Private Sub eui_cmdContiSu_Click(sender As Object, e As EventArgs) Handles eui_cmdContiSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvConti.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvConti.TopItem.Index

         IndiceLista = PrimoElemento - 1

         If IndiceLista < 0 Then
            Exit Sub
         Else
            lstvConti.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdContiGiù_Click(sender As Object, e As EventArgs) Handles eui_cmdContiGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvConti.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvConti.TopItem.Index

         IndiceLista = PrimoElemento + NumElementi

         If IndiceLista > lstvConti.Items.Count - 1 Then
            Exit Sub
         Else
            lstvConti.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdModifica_Click(sender As Object, e As EventArgs) Handles eui_cmdModifica.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim dataConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(0).Text
         Dim oraOccConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(1).Text
         Dim numConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(2).Text
         Dim tavoloConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(4).Text
         Dim statoConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(5).Text
         Dim cameriereConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(10).Text

         ' Se il conto è chiuso...
         If statoConto = "Chiuso" Then
            eui_cmdModifica.Enabled = False
            Exit Sub
         Else
            ' Apre il punto cassa.
            If g_frmPos.CaricaComandeConto(dataConto, oraOccConto, numConto, tavoloConto, cameriereConto) = True Then
               Me.Close()
            Else
               Exit Sub
            End If

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Seleziona il primo elemento della lista.
         If lstvConti.Items.Count <> 0 Then
            lstvConti.Items(0).Selected = True
         End If

      End Try
   End Sub

   Private Sub eui_cmdChiudi_Click(sender As Object, e As EventArgs) Handles eui_cmdChiudi.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Se il conto è già chiuso...
         Dim statoConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(5).Text
         If statoConto = "Chiudi" Then
            eui_cmdChiudi.Enabled = False
            Exit Sub
         End If

         Dim dataConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(0).Text
         Dim numeroConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(2).Text

         Dim risposta As DialogResult
         risposta = MessageBox.Show("Si desidera chiudere il conto " & NumeroConto & " del " & DataConto & " per l'elaborazione del documento fiscale?" & vbCrLf &
                                    "Procedendo con l'operazione non sarà più possibile modificare i dati di dettaglio del conto.", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If risposta = DialogResult.Yes Then
            lstvConti.Focus()

            Dim idConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(8).Text

            If ModificaStatoConto(TAB_DOCUMENTI, idConto) = True Then
               AggiornaListaConto()
            End If
         Else
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Seleziona il primo elemento della lista.
         If lstvConti.Items.Count <> 0 Then
            lstvConti.Items(0).Selected = True
         End If

      End Try
   End Sub

   Private Sub eui_cmdElimina_Click(sender As Object, e As EventArgs) Handles eui_cmdElimina.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim dataConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(0).Text
         Dim numeroConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(2).Text

         Dim risposta As DialogResult
         risposta = MessageBox.Show("Si desidera eliminare il conto numero " & numeroConto & " del " & dataConto & "?" & vbCrLf &
                                    "Procedendo con l'operazione non sarà più possibile recuperare e modificare i dati di dettaglio del conto.", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If risposta = DialogResult.Yes Then
            lstvConti.Focus()

            Dim idConto As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(8).Text

            If EliminaConto(idConto) = True Then
               AggiornaListaConto()
            End If
         Else
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Seleziona il primo elemento della lista.
         If lstvConti.Items.Count <> 0 Then
            lstvConti.Items(0).Selected = True
         End If

      End Try
   End Sub

   Private Sub eui_cmdElabora_Click(sender As Object, e As EventArgs) Handles eui_cmdElabora.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         'Select Case Me.Tag
         '   Case "COPERTI"
         '      ImpostaClienteCoperti()

         '   Case "CONTO"
         '      ImpostaClienteConto()

         '   Case "ASPORTO"
         '      ImpostaClienteAsporto()

         'End Select

         'Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Seleziona il primo elemento della lista.
         If lstvConti.Items.Count <> 0 Then
            lstvConti.Items(0).Selected = True
         End If

      End Try
   End Sub

   Private Sub eui_cmdEsci_Click(sender As Object, e As EventArgs) Handles eui_cmdEsci.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub lstvConti_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstvConti.SelectedIndexChanged
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         lstvConti.Focus()

         Dim statoDoc As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(5).Text
         Dim idDoc As String = lstvConti.Items(lstvConti.FocusedItem.Index).SubItems(8).Text

         ' Attiva / Disattiva i pulsanti in base allo stato del conto.
         If statoDoc = "Chiuso" Then
            eui_cmdModifica.Enabled = False
            eui_cmdChiudi.Enabled = False
         Else
            eui_cmdModifica.Enabled = True
            eui_cmdChiudi.Enabled = True
         End If

         ' Legge le note del conto.
         LeggiNoteConto(TAB_DOCUMENTI, idDoc)

      Catch ex As NullReferenceException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

End Class
