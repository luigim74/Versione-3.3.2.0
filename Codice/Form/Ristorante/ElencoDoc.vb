#Region " DATI FILE.VB "
' ******************************************************************
' Nome form:            frmElencoDoc
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 15/08/2018
' Descrizione:          Elenco documenti emessi..
' Note:

' Elenco Attivita:

' ******************************************************************
#End Region

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class ElencoDoc
   Inherits System.Windows.Forms.Form

   Public Const TAB_DOCUMENTI As String = "Documenti"
   Const TAB_DETTAGLI_DOC As String = "DettagliDoc"
   Const TITOLO_FINESTRA As String = "Elenco documenti di Vendita"
   Public Const COLONNA_ID_DOC As Short = 0
   Const COLONNA_NUMERO_DOC As Short = 1
   Const COLONNA_DATA_DOC As Short = 2
   Const COLONNA_TIPO_DOC As Short = 4
   Const COLONNA_INTESTATARIO As Short = 5
   Const COLONNA_STATO_DOC As Short = 6
   Const COLONNA_IMPORTO_TOTALE As Short = 9
   Const COLONNA_IMPORTO_SOSPESO As Short = 10
   Const COLONNA_IMPORTO_IMPONIBILE As Short = 11
   Const COLONNA_IMPORTO_IMPOSTA As Short = 12
   Const COLONNA_IMPORTO_BUONI As Short = 13
   Const COLONNA_CONTABILIZZATO As Short = 14
   Const COLONNA_IMPORTO_SOSPESO_INC As Short = 15
   Const COLONNA_IMPORTO_BUONI_INC As Short = 16
   Const COLONNA_ID_CLIENTE As Short = 17

   Const TIPO_DOC_RF As String = "Ricevuta Fiscale"
   Const TIPO_DOC_FF As String = "Fattura"
   Const TIPO_DOC_SF As String = "Scontrino"
   Const TIPO_DOC_PF As String = "Proforma"
   Const TIPO_DOC_CO As String = "Conto"

   Const STATO_DOC_EMESSO As String = "Emesso"
   Const STATO_DOC_EMESSO_STAMPATO As String = "Emesso e stampato"
   Const STATO_DOC_ANNULLATO As String = "Annullato"
   Public Const STATO_DOC_EMESSO_XML As String = "Emesso in XML"

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim da As OleDbDataAdapter

   ' Numero di record.
   Dim numRecord As Integer
   ' Numero di pagine.
   Dim numPagine As Integer
   ' Pagina corrente.
   Dim pagCorrente As Integer

   Dim ds As New DataSet
   Dim dt As DataTable
   Dim sql As String
   Public repSql As String

   Private DatiConfig As AppConfig
   Private CFormatta As New ClsFormatta
   Private AArticoli As New Articoli
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_txtTestoRicerca As Elegant.Ui.TextBox
   Friend WithEvents eui_cmbCampoRicerca As Elegant.Ui.ComboBox
   Friend WithEvents Label4 As Label
   Friend WithEvents eui_txtImposta As Elegant.Ui.TextBox
   Friend WithEvents Label2 As Label
   Friend WithEvents eui_txtImponibile As Elegant.Ui.TextBox
   Friend WithEvents eui_txtBuoni As Elegant.Ui.TextBox
   Friend WithEvents eui_txtSospeso As Elegant.Ui.TextBox
   Friend WithEvents eui_txtTotale As Elegant.Ui.TextBox
   Public filtroDati As String

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_DOCUMENTI)

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

   'NOTA: la procedura che segue Ë richiesta da Progettazione Windows Form.
   'PuÚ essere modificata in Progettazione Windows Form.  
   'Non modificarla nell'editor del codice.
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents dtpAl As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpDal As System.Windows.Forms.DateTimePicker
   Friend WithEvents lblAl As System.Windows.Forms.Label
   Friend WithEvents lblDal As System.Windows.Forms.Label
   Friend WithEvents lblCampo As System.Windows.Forms.Label
   Friend WithEvents lblTesto As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoDoc))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.eui_cmbCampoRicerca = New Elegant.Ui.ComboBox()
      Me.eui_txtTestoRicerca = New Elegant.Ui.TextBox()
      Me.dtpAl = New System.Windows.Forms.DateTimePicker()
      Me.dtpDal = New System.Windows.Forms.DateTimePicker()
      Me.lblAl = New System.Windows.Forms.Label()
      Me.lblDal = New System.Windows.Forms.Label()
      Me.lblCampo = New System.Windows.Forms.Label()
      Me.lblTesto = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.eui_txtBuoni = New Elegant.Ui.TextBox()
      Me.eui_txtSospeso = New Elegant.Ui.TextBox()
      Me.eui_txtTotale = New Elegant.Ui.TextBox()
      Me.eui_txtImposta = New Elegant.Ui.TextBox()
      Me.eui_txtImponibile = New Elegant.Ui.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "")
      Me.ImageList1.Images.SetKeyName(1, "")
      Me.ImageList1.Images.SetKeyName(2, "")
      Me.ImageList1.Images.SetKeyName(3, "")
      Me.ImageList1.Images.SetKeyName(4, "")
      Me.ImageList1.Images.SetKeyName(5, "")
      Me.ImageList1.Images.SetKeyName(6, "")
      Me.ImageList1.Images.SetKeyName(7, "")
      Me.ImageList1.Images.SetKeyName(8, "")
      Me.ImageList1.Images.SetKeyName(9, "")
      Me.ImageList1.Images.SetKeyName(10, "")
      Me.ImageList1.Images.SetKeyName(11, "")
      Me.ImageList1.Images.SetKeyName(12, "")
      Me.ImageList1.Images.SetKeyName(13, "")
      Me.ImageList1.Images.SetKeyName(14, "")
      Me.ImageList1.Images.SetKeyName(15, "")
      Me.ImageList1.Images.SetKeyName(16, "")
      Me.ImageList1.Images.SetKeyName(17, "")
      '
      'DataGrid1
      '
      Me.DataGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.DataGrid1.BackgroundColor = System.Drawing.Color.White
      Me.DataGrid1.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.DataGrid1.CaptionBackColor = System.Drawing.Color.Gray
      Me.DataGrid1.CaptionFont = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.CaptionForeColor = System.Drawing.Color.White
      Me.DataGrid1.DataMember = ""
      Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid1.Location = New System.Drawing.Point(0, 34)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(650, 313)
      Me.DataGrid1.TabIndex = 0
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.eui_cmbCampoRicerca)
      Me.Panel1.Controls.Add(Me.eui_txtTestoRicerca)
      Me.Panel1.Controls.Add(Me.dtpAl)
      Me.Panel1.Controls.Add(Me.dtpDal)
      Me.Panel1.Controls.Add(Me.lblAl)
      Me.Panel1.Controls.Add(Me.lblDal)
      Me.Panel1.Controls.Add(Me.lblCampo)
      Me.Panel1.Controls.Add(Me.lblTesto)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(650, 34)
      Me.Panel1.TabIndex = 0
      '
      'eui_cmbCampoRicerca
      '
      Me.eui_cmbCampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmbCampoRicerca.Editable = False
      Me.eui_cmbCampoRicerca.FormattingEnabled = False
      Me.eui_cmbCampoRicerca.Id = "6e85627c-5d62-4010-971d-8de73ae45222"
      Me.eui_cmbCampoRicerca.Location = New System.Drawing.Point(506, 7)
      Me.eui_cmbCampoRicerca.Name = "eui_cmbCampoRicerca"
      Me.eui_cmbCampoRicerca.Size = New System.Drawing.Size(134, 21)
      Me.eui_cmbCampoRicerca.TabIndex = 1
      Me.eui_cmbCampoRicerca.TextEditorWidth = 115
      '
      'eui_txtTestoRicerca
      '
      Me.eui_txtTestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtTestoRicerca.Id = "bb5a861b-2fcf-4573-8803-b69d17c915f7"
      Me.eui_txtTestoRicerca.Location = New System.Drawing.Point(114, 7)
      Me.eui_txtTestoRicerca.Name = "eui_txtTestoRicerca"
      Me.eui_txtTestoRicerca.Size = New System.Drawing.Size(289, 21)
      Me.eui_txtTestoRicerca.TabIndex = 0
      Me.eui_txtTestoRicerca.TextEditorWidth = 529
      '
      'dtpAl
      '
      Me.dtpAl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpAl.Location = New System.Drawing.Point(466, 40)
      Me.dtpAl.Name = "dtpAl"
      Me.dtpAl.Size = New System.Drawing.Size(174, 20)
      Me.dtpAl.TabIndex = 55670
      Me.dtpAl.Tag = ""
      Me.dtpAl.Visible = False
      '
      'dtpDal
      '
      Me.dtpDal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpDal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpDal.Location = New System.Drawing.Point(250, 40)
      Me.dtpDal.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
      Me.dtpDal.Name = "dtpDal"
      Me.dtpDal.Size = New System.Drawing.Size(174, 20)
      Me.dtpDal.TabIndex = 55669
      Me.dtpDal.Tag = ""
      Me.dtpDal.Visible = False
      '
      'lblAl
      '
      Me.lblAl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAl.AutoSize = True
      Me.lblAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblAl.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.lblAl.Location = New System.Drawing.Point(442, 40)
      Me.lblAl.Name = "lblAl"
      Me.lblAl.Size = New System.Drawing.Size(23, 15)
      Me.lblAl.TabIndex = 55672
      Me.lblAl.Tag = ""
      Me.lblAl.Text = "Al:"
      Me.lblAl.Visible = False
      '
      'lblDal
      '
      Me.lblDal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDal.AutoSize = True
      Me.lblDal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDal.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.lblDal.Location = New System.Drawing.Point(218, 40)
      Me.lblDal.Name = "lblDal"
      Me.lblDal.Size = New System.Drawing.Size(33, 15)
      Me.lblDal.TabIndex = 55671
      Me.lblDal.Tag = ""
      Me.lblDal.Text = "Dal:"
      Me.lblDal.Visible = False
      '
      'lblCampo
      '
      Me.lblCampo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCampo.AutoSize = True
      Me.lblCampo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCampo.ForeColor = System.Drawing.Color.White
      Me.lblCampo.Location = New System.Drawing.Point(417, 8)
      Me.lblCampo.Name = "lblCampo"
      Me.lblCampo.Size = New System.Drawing.Size(85, 15)
      Me.lblCampo.TabIndex = 8
      Me.lblCampo.Text = "Ricerca per:"
      '
      'lblTesto
      '
      Me.lblTesto.AutoSize = True
      Me.lblTesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTesto.ForeColor = System.Drawing.Color.White
      Me.lblTesto.Location = New System.Drawing.Point(2, 8)
      Me.lblTesto.Name = "lblTesto"
      Me.lblTesto.Size = New System.Drawing.Size(110, 15)
      Me.lblTesto.TabIndex = 6
      Me.lblTesto.Text = "Testo di ricerca:"
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "Risorse.rpt"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.Gray
      Me.Panel2.Controls.Add(Me.eui_txtBuoni)
      Me.Panel2.Controls.Add(Me.eui_txtSospeso)
      Me.Panel2.Controls.Add(Me.eui_txtTotale)
      Me.Panel2.Controls.Add(Me.eui_txtImposta)
      Me.Panel2.Controls.Add(Me.eui_txtImponibile)
      Me.Panel2.Controls.Add(Me.Label1)
      Me.Panel2.Controls.Add(Me.Label4)
      Me.Panel2.Controls.Add(Me.Label2)
      Me.Panel2.Controls.Add(Me.Label3)
      Me.Panel2.Controls.Add(Me.Label6)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 348)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(650, 50)
      Me.Panel2.TabIndex = 13
      '
      'eui_txtBuoni
      '
      Me.eui_txtBuoni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtBuoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtBuoni.Id = "b350a5b8-b563-4150-b00a-eab48f81095a"
      Me.eui_txtBuoni.Location = New System.Drawing.Point(538, 20)
      Me.eui_txtBuoni.Name = "eui_txtBuoni"
      Me.eui_txtBuoni.ReadOnly = True
      Me.eui_txtBuoni.Size = New System.Drawing.Size(102, 21)
      Me.eui_txtBuoni.TabIndex = 4
      Me.eui_txtBuoni.Text = "1.000"
      Me.eui_txtBuoni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtBuoni.TextEditorWidth = 96
      '
      'eui_txtSospeso
      '
      Me.eui_txtSospeso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtSospeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtSospeso.Id = "3c2ab487-6393-4c7f-a14d-7837bbdae6d6"
      Me.eui_txtSospeso.Location = New System.Drawing.Point(226, 20)
      Me.eui_txtSospeso.Name = "eui_txtSospeso"
      Me.eui_txtSospeso.ReadOnly = True
      Me.eui_txtSospeso.Size = New System.Drawing.Size(102, 21)
      Me.eui_txtSospeso.TabIndex = 1
      Me.eui_txtSospeso.Text = "1.000"
      Me.eui_txtSospeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtSospeso.TextEditorWidth = 96
      '
      'eui_txtTotale
      '
      Me.eui_txtTotale.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtTotale.Id = "0d65cebb-55d0-4baf-aa53-aa5d7ed71ce2"
      Me.eui_txtTotale.Location = New System.Drawing.Point(122, 20)
      Me.eui_txtTotale.Name = "eui_txtTotale"
      Me.eui_txtTotale.ReadOnly = True
      Me.eui_txtTotale.Size = New System.Drawing.Size(102, 21)
      Me.eui_txtTotale.TabIndex = 0
      Me.eui_txtTotale.Text = "1.000"
      Me.eui_txtTotale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtTotale.TextEditorWidth = 96
      '
      'eui_txtImposta
      '
      Me.eui_txtImposta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtImposta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtImposta.Id = "fa3b517a-f528-4af1-9a37-995fbf6c2301"
      Me.eui_txtImposta.Location = New System.Drawing.Point(434, 20)
      Me.eui_txtImposta.Name = "eui_txtImposta"
      Me.eui_txtImposta.ReadOnly = True
      Me.eui_txtImposta.Size = New System.Drawing.Size(102, 21)
      Me.eui_txtImposta.TabIndex = 3
      Me.eui_txtImposta.Text = "1.300.000.000"
      Me.eui_txtImposta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtImposta.TextEditorWidth = 96
      '
      'eui_txtImponibile
      '
      Me.eui_txtImponibile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtImponibile.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtImponibile.Id = "dcf69703-40b2-49ff-89bd-3697977a0492"
      Me.eui_txtImponibile.Location = New System.Drawing.Point(330, 20)
      Me.eui_txtImponibile.Name = "eui_txtImponibile"
      Me.eui_txtImponibile.ReadOnly = True
      Me.eui_txtImponibile.Size = New System.Drawing.Size(102, 21)
      Me.eui_txtImponibile.TabIndex = 2
      Me.eui_txtImponibile.Text = "1.000"
      Me.eui_txtImponibile.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtImponibile.TextEditorWidth = 96
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.White
      Me.Label1.Location = New System.Drawing.Point(535, 5)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(87, 15)
      Me.Label1.TabIndex = 238
      Me.Label1.Text = "Buoni pasto:"
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.White
      Me.Label4.Location = New System.Drawing.Point(431, 5)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(62, 15)
      Me.Label4.TabIndex = 242
      Me.Label4.Text = "Imposta:"
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.White
      Me.Label2.Location = New System.Drawing.Point(327, 5)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(79, 15)
      Me.Label2.TabIndex = 240
      Me.Label2.Text = "Imponibile:"
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.White
      Me.Label3.Location = New System.Drawing.Point(223, 5)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(66, 15)
      Me.Label3.TabIndex = 236
      Me.Label3.Text = "Sospeso:"
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.White
      Me.Label6.Location = New System.Drawing.Point(119, 5)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(51, 15)
      Me.Label6.TabIndex = 16
      Me.Label6.Text = "Totale:"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'ElencoDoc
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(650, 398)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoDoc"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco documenti di Vendita"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

#Region "Scarico ingredienti"

   Private Function SalvaDati(ByVal tabella As String, ByVal id As Integer, ByVal giacenza As Double,
                              ByVal carico As Double, ByVal scarico As Double,
                              ByVal situazione As Double, ByVal prezzo As String,
                              ByVal valCarico As Double, ByVal valScarico As Double, ByVal valAttuale As Double) As Boolean

      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET Giacenza = @Giacenza, " &
                             "Carico = @Carico, " &
                             "Scarico = @Scarico, " &
                             "SituazioneScorta = @SituazioneScorta, " &
                             "ValCarico = @ValCarico, " &
                             "valScarico = @ValScarico, " &
                             "ValAttuale = @ValAttuale, " &
                             "PrezzoAcquisto = @Prezzo " &
                             "WHERE Id = {1}",
                              tabella,
                              id)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Giacenza", giacenza)
         cmdUpdate.Parameters.Add("@Carico", carico)
         cmdUpdate.Parameters.Add("@Scarico", scarico)
         cmdUpdate.Parameters.Add("@SituazioneScorta", situazione)
         cmdUpdate.Parameters.Add("@ValCarico", valCarico)
         cmdUpdate.Parameters.Add("@ValScarico", valScarico)
         cmdUpdate.Parameters.Add("@ValAttuale", valAttuale)
         cmdUpdate.Parameters.Add("@Prezzo", prezzo)

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

   Private Function SalvaMovimentiMag(ByVal tabella As String, ByVal id_Articolo As Integer, ByVal data As String,
                                      ByVal codice As String, ByVal descrizione As String,
                                      ByVal carico As Double, ByVal scarico As Double,
                                      ByVal causale As String, ByVal prezzo As String,
                                      ByVal fornitore As String, ByVal magazzino As String) As Boolean

      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Id_Articolo, Data, Codice, Descrizione, PrezzoAcquisto, " &
                                              "Carico, Scarico, Causale, Fornitore, Magazzino) " &
                                       "VALUES(@Id_Articolo, @Data, @Codice, @Descrizione, @PrezzoAcquisto, " &
                                              "@Carico, @Scarico, @Causale, @Fornitore, @Magazzino)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Id_Articolo", id_Articolo)
         cmdInsert.Parameters.Add("@Data", data)
         cmdInsert.Parameters.Add("@Codice", codice)
         cmdInsert.Parameters.Add("@Descrizione", descrizione)
         cmdInsert.Parameters.Add("@PrezzoAcquisto", prezzo)
         cmdInsert.Parameters.Add("@Carico", carico)
         cmdInsert.Parameters.Add("@Scarico", scarico)
         cmdInsert.Parameters.Add("@Causale", causale)
         cmdInsert.Parameters.Add("@Fornitore", fornitore)
         cmdInsert.Parameters.Add("@Magazzino", magazzino)

         ' Esegue il comando.
         Dim Record As Integer = cmdInsert.ExecuteNonQuery()

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

   Private Function CalcolaScarico(ByVal scarico As Double, ByVal nuovoScarico As Double) As Double
      Try
         Return (scarico - nuovoScarico)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub RipristinaIngredientiScaricati()
      Try
         Dim idArticolo As Integer
         Dim qt‡Carico As Double
         Dim IdPiatto As Integer = 0
         Dim qt‡Piatto As Integer = 0
         Dim descrizione As String
         Dim rifDoc As Integer
         Dim CausaleMovMag As String = "Documento annullato"

         Dim listaPiatti As New ListBox
         Dim listaIdPiatti As New ListBox
         Dim listaIngredienti As New ListBox

         ' Legge il numero dell'ultimo documento creato.
         rifDoc = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC)

         cn.Open()

         ' Legge i dati di dettaglio (comande).
         Dim cmdComande As New OleDbCommand("SELECT * FROM DettagliDoc WHERE RifDoc = " & rifDoc & " ORDER BY Id ASC", cn)
         Dim drComande As OleDbDataReader = cmdComande.ExecuteReader()
         Do While drComande.Read
            ' Ottiene la quantit‡ del piatto.
            qt‡Piatto = Convert.ToInt32(drComande.Item("Quantit‡"))
            descrizione = drComande.Item("Descrizione")
            listaPiatti.Items.Add(qt‡Piatto & "/" & descrizione)
         Loop

         cmdComande.Dispose()
         drComande.Close()

         Dim i As Integer
         For i = 0 To listaPiatti.Items.Count - 1
            Dim piatto As String = listaPiatti.Items.Item(i)
            Dim datiPiatto As String()
            datiPiatto = piatto.Split("/")

            ' Legge i dati di dettaglio (comande).
            Dim cmdIdPiatto As New OleDbCommand("SELECT * FROM Piatti WHERE Descrizione = '" & datiPiatto(1) & "'", cn)
            Dim drIdPiatto As OleDbDataReader = cmdIdPiatto.ExecuteReader()
            Do While drIdPiatto.Read
               ' Ottiene l'Id del piatto.
               listaIdPiatti.Items.Add(drIdPiatto.Item("Id"))
            Loop

            cmdIdPiatto.Dispose()
            drIdPiatto.Close()
         Next

         Dim y As Integer
         For y = 0 To listaIdPiatti.Items.Count - 1
            ' Legge i dati di dettaglio (comande).
            Dim cmdIngrediente As New OleDbCommand("SELECT * FROM Ingredienti WHERE Id_Piatto = " & listaIdPiatti.Items.Item(y), cn)
            Dim drIngrediente As OleDbDataReader = cmdIngrediente.ExecuteReader()

            Do While drIngrediente.Read
               ' Ottiene la quantit‡ del piatto.
               idArticolo = Convert.ToInt32(drIngrediente.Item("Id_Articolo"))
               qt‡Carico = drIngrediente.Item("Quantit‡")
               listaIngredienti.Items.Add(idArticolo & "/" & qt‡Carico)

               AArticoli.LeggiDati("Articoli", idArticolo)
               Dim nuovaGiacenza As Double = (AArticoli.Giacenza + qt‡Carico)
               Dim Carico As Double = 0
               Dim Scarico As Double = 0
               Dim situazioneScorta As Double = 0
               Dim valCarico As Double = 0
               Dim valScarico As Double = 0
               Dim valAttuale As Double = 0

               Scarico = CalcolaScarico(AArticoli.Scarico, qt‡Carico)
               Carico = AArticoli.Carico

               If AArticoli.ScortaMin > 0 Then
                  situazioneScorta = (nuovaGiacenza - AArticoli.ScortaMin)
               Else
                  situazioneScorta = 0
               End If

               ' Calcola i progressivi.
               If AArticoli.PrezzoAcquisto <> "" Then
                  If IsNumeric(AArticoli.PrezzoAcquisto) = True Then
                     If Carico <> 0 Then
                        valCarico = CFormatta.FormattaEuro(CalcolaValore(CDec(AArticoli.PrezzoAcquisto), Carico))
                     Else
                        valCarico = 0
                     End If

                     If Scarico <> 0 Then
                        valScarico = CFormatta.FormattaEuro(CalcolaValore(CDec(AArticoli.PrezzoAcquisto), Scarico))
                     Else
                        valScarico = 0
                     End If

                     If nuovaGiacenza <> 0 Then
                        valAttuale = CFormatta.FormattaEuro(CalcolaValore(CDec(AArticoli.PrezzoAcquisto), nuovaGiacenza))
                     Else
                        valAttuale = 0
                     End If
                  Else
                     valCarico = 0
                     valScarico = 0
                     valAttuale = 0
                  End If
               Else
                  valCarico = 0
                  valScarico = 0
                  valAttuale = 0
               End If

               ' Aggiorna i dati della tabella Articoli.
               SalvaDati("Articoli", idArticolo, nuovaGiacenza,
                          Carico, Scarico, situazioneScorta, AArticoli.PrezzoAcquisto,
                          valCarico, valScarico, valAttuale)

               ' Verifica se Ë un carico o scarico.
               Dim qt‡Caricata As Double = 0
               Dim qt‡Scaricata As Double = 0
               qt‡Scaricata = 0
               qt‡Caricata = qt‡Carico

               Dim data As Date = Now.Today

               ' Salva i dati per i movimenti di magazzino.
               SalvaMovimentiMag("MovMagazzino", idArticolo, data.ToShortDateString, AArticoli.Codice, AArticoli.Descrizione,
                                  qt‡Caricata, qt‡Scaricata, CausaleMovMag, AArticoli.PrezzoAcquisto,
                                  AArticoli.Fornitore, AArticoli.Magazzino)

               If IsNothing(g_frmArticoli) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmArticoli.AggiornaDati()
               End If

               If IsNothing(g_frmScorte) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmScorte.AggiornaDati()
               End If

               If IsNothing(g_frmInventario) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmInventario.AggiornaDati()
               End If

               If IsNothing(g_frmMovMag) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmMovMag.AggiornaDati()
               End If
            Loop

            cmdIngrediente.Dispose()
            drIngrediente.Close()
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      Finally
         cn.Close()
      End Try
   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("FiltroDoc") <> "" Then
            filtroDati = DatiConfig.GetValue("FiltroDoc")
         Else
            filtroDati = "Tutti"
         End If

         If DatiConfig.GetValue("WSDocumenti") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSDocumenti") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("ADocumenti") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("ADocumenti"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LDocumenti") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LDocumenti"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("DocumentiX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("DocumentiX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("DocumentiY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("DocumentiY")))
            End If

            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         DatiConfig.SetValue("FiltroDoc", filtroDati)
         DatiConfig.SetValue("WSDocumenti", Me.WindowState)
         DatiConfig.SetValue("DocumentiX", Me.Location.X)
         DatiConfig.SetValue("DocumentiY", Me.Location.Y)
         DatiConfig.SetValue("ADocumenti", Me.Height)
         DatiConfig.SetValue("LDocumenti", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Documenti
               If operatore.ContDoc = VALORE_LETTURA Then

                  ' Modifica.
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = False
                  g_frmMain.eui_Strumenti_Modifica.Enabled = False
                  g_frmMain.eui_Strumenti_Duplica.Enabled = False
                  g_frmMain.eui_Strumenti_Elimina.Enabled = False
                  g_frmMain.eui_Strumenti_Annulla.Enabled = False
                  g_frmMain.eui_Strumenti_Aggiorna.Enabled = False
                  g_frmMain.eui_Strumenti_Esporta.Enabled = False
                  g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = False
                  g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = False

                  ' Sospesi.
                  g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = False
                  g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = False
                  g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = False
                  g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = False

               Else
                  ' Modifica.
                  g_frmMain.eui_Strumenti_Nuovo.Enabled = True
                  g_frmMain.eui_Strumenti_Modifica.Enabled = True
                  g_frmMain.eui_Strumenti_Duplica.Enabled = True
                  g_frmMain.eui_Strumenti_Elimina.Enabled = True
                  g_frmMain.eui_Strumenti_Annulla.Enabled = True
                  g_frmMain.eui_Strumenti_Aggiorna.Enabled = True
                  g_frmMain.eui_Strumenti_Esporta.Enabled = True
                  g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = True
                  g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = True

                  ' Sospesi.
                  g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = True
                  g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = True
                  g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = True
                  g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = True
               End If

         End Select

         Return g_frmMain.eui_Strumenti_Modifica.Enabled

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return True
      End Try

   End Function

   Private Sub RipristinaStatistiche()
      Try
         Dim sql As String
         Dim rifDoc As String

         ' Legge il numero dell'ultimo documento creato.
         rifDoc = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC)

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE IdCategoria = '{1}'", "Statistiche", rifDoc)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

         If IsNothing(g_frmStatistiche) = False Then
            ' Aggiorna la griglia dati.
            g_frmStatistiche.AggiornaDati()

            ' Somma i valori della colonna Quantit‡.
            g_frmStatistiche.txtTotQuantit‡.Text = CFormatta.FormattaNumero(SommaColonna(g_frmStatistiche.DataGrid1, g_frmStatistiche.COLONNA_QTA, g_frmStatistiche.numRecord))

            ' Somma i valori della colonna Importo.
            g_frmStatistiche.txtTotImporto.Text = CFormatta.FormattaEuro(SommaColonna(g_frmStatistiche.DataGrid1, g_frmStatistiche.COLONNA_IMPORTO, g_frmStatistiche.numRecord))

         End If

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Private Function RipristinaBuoniPasto() As Boolean
      Try
         Dim sql As String
         Dim rifDoc As String
         Dim idBuono As Integer
         Dim qt‡Buono As Double
         Dim valoreTotBuono As Double
         Dim listaBuoniFatt As New ListBox

         ' Legge il numero dell'ultimo documento creato.
         rifDoc = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC)

         ' Apre la connessione.
         cn.Open()

         ' Legge i dati dei Buoni da fatturare.
         Dim cmdBuoniFatt As New OleDbCommand("SELECT * FROM BuoniPastoFatt WHERE IdDoc = " & rifDoc & " ORDER BY Id ASC", cn)
         Dim drBuoniFatt As OleDbDataReader = cmdBuoniFatt.ExecuteReader()
         Do While drBuoniFatt.Read
            idBuono = Convert.ToInt32(drBuoniFatt.Item("IdBuono"))
            qt‡Buono = Convert.ToDouble(drBuoniFatt.Item("Quantit‡"))
            valoreTotBuono = Convert.ToDouble(drBuoniFatt.Item("ValoreTotale"))
            listaBuoniFatt.Items.Add(idBuono & "/" & qt‡Buono & "/" & valoreTotBuono)
         Loop

         cmdBuoniFatt.Dispose()
         drBuoniFatt.Close()

         ' Legge i dati dei Buoni pasto.
         Dim i As Integer
         For i = 0 To listaBuoniFatt.Items.Count - 1
            Dim buoniFatt As String = listaBuoniFatt.Items.Item(i)
            Dim datiBuoniFatt As String()
            datiBuoniFatt = buoniFatt.Split("/")

            Dim CBuoniPasto As New Buoni
            With CBuoniPasto
               Dim cmdBuoni As New OleDbCommand("SELECT * FROM BuoniPasto WHERE Id = " & datiBuoniFatt(0) & " ORDER BY Id ASC", cn)
               Dim drBuoni As OleDbDataReader = cmdBuoni.ExecuteReader()
               Do While drBuoni.Read
                  .IdAzienda = Convert.ToInt32(drBuoni.Item("IdAzienda"))
                  .Descrizione = drBuoni.Item("Descrizione")
                  .ValoreUnitario = Convert.ToDouble(drBuoni.Item("ValoreUnitario"))
                  .Quantit‡ = Convert.ToDouble(drBuoni.Item("Quantit‡"))
                  .ValoreTotale = Convert.ToDouble(drBuoni.Item("ValoreTotale"))
                  .Quantit‡Fatt = Convert.ToDouble(drBuoni.Item("Quantit‡Fatt"))
                  .ValoreFatt = Convert.ToDouble(drBuoni.Item("ValoreFatt"))
               Loop

               ' Sottrae i valori per ripristinare i dati.
               .Quantit‡ = .Quantit‡ - qt‡Buono
               .ValoreTotale = .ValoreTotale - valoreTotBuono
               .Quantit‡Fatt = .Quantit‡Fatt - qt‡Buono
               .ValoreFatt = .ValoreFatt - valoreTotBuono

               .ModificaDati("BuoniPasto", idBuono)
            End With
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return (False)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

   Private Sub EliminaBuoniPasto()
      Try
         Dim rifDoc As Integer

         ' Elimina i Buoni pasto da fatturare contenuti nel documento annullato.

         ' Legge il numero dell'ultimo documento creato.
         rifDoc = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC)

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE IdDoc = {1}", "BuoniPastoFatt", rifDoc)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Private Sub EliminaDettagliDocumento()
      Try
         Dim rifDoc As Integer

         ' Legge il numero dell'ultimo documento creato.
         rifDoc = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC)

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE RifDoc = {1}", "DettagliDoc", rifDoc)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Private Sub EliminaDocumento()
      Try
         Dim rifDoc As Integer

         ' Legge il numero dell'ultimo documento creato.
         rifDoc = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC)

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE Id = {1}", "Documenti", rifDoc)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

         ' Aggiorna la lista dati.
         AggiornaDati()

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Public Sub EliminaDatiDocumento()
      Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
      Dim Documento As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)
      Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
      Dim Importo As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7)

      ' Chiede conferma per l'eliminazione.
      Dim risposta As Integer
      risposta = MessageBox.Show("Si desidera eliminare il documento """ & Documento & " n. " & Numero & " del " & Data & """? " &
                                 "Confermando l'operazione Non sar‡ pi˘ possibile recuperare i dati.", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
      If risposta = vbYes Then
         EliminaDettagliDocumento()
         EliminaDocumento()

         ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()
         AttivaDisattivaBuoni()
         AttivaDisattivaAnnullaDoc()
         AttivaDisattivaEsportaFatturaElettronica()

         ' Registra loperazione effettuata dall'operatore identificato.
         Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - Ä " & CFormatta.FormattaEuro(Importo) & ")"
         g_frmMain.RegistraOperazione(TipoOperazione.AnnullaDoc, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

      End If
   End Sub

   Public Sub DuplicaDocumento()
      Try
         Dim Risposta As Short
         Dim id As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
         Dim numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_NUMERO_DOC)
         Dim data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_DATA_DOC)
         Dim tipoDoc As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC)

         ' Chiede conferma per l'eliminazione.
         Risposta = MessageBox.Show("Si desidera duplicare il documento """ & tipoDoc & " N. " & numero & " del " & data & """?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If Risposta = MsgBoxResult.Yes Then

            ' Dati documento.
            Dim Doc As New Documenti
            With Doc
               ' Legge i dati del record selezionato nella lista.
               .LeggiDati(TAB_DOCUMENTI, id)

               .Ora = TimeOfDay.Hour.ToString & ":" & FormattaMinuti(TimeOfDay.Minute.ToString)
               .Stato = "Bozza"
               .Chiuso = "No"

               ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
               .InserisciDati(TAB_DOCUMENTI)
            End With

            ' Leggo l'ultimo id del documento duplicato.
            Dim ultimoId As Integer = LeggiUltimoRecord(TAB_DOCUMENTI)

            ' Dati dettagli documento.
            Dim DettagliDoc As New DettagliDocumenti
            With DettagliDoc
               ' Dichiara un oggetto connessione.
               Dim cn As New OleDbConnection(ConnString)
               cn.Open()

               Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_DETTAGLI_DOC & " WHERE RifDoc = " & id & " ORDER BY Id ASC", cn)
               Dim dr As OleDbDataReader = cmd.ExecuteReader()

               ' Legge i dati del record selezionato nella lista.
               Do While dr.Read()
                  .RifDoc = ultimoId

                  ' Codice.
                  If IsDBNull(dr.Item("CodiceArticolo")) = False Then
                     .CodiceArticolo = dr.Item("CodiceArticolo")
                  Else
                     .CodiceArticolo = String.Empty
                  End If

                  ' Descrizione.
                  If IsDBNull(dr.Item("Descrizione")) = False Then
                     .Descrizione = dr.Item("Descrizione")
                  Else
                     .Descrizione = String.Empty
                  End If

                  ' Unit‡ di misura.
                  If IsDBNull(dr.Item("Unit‡Misura")) = False Then
                     .Unit‡Misura = dr.Item("Unit‡Misura")
                  Else
                     .Unit‡Misura = String.Empty
                  End If

                  ' Quantit‡.
                  If IsDBNull(dr.Item("Quantit‡")) = False Then
                     .Quantit‡ = dr.Item("Quantit‡")
                  Else
                     .Quantit‡ = VALORE_ZERO
                  End If

                  ' Valore Unitario.
                  If IsDBNull(dr.Item("ValoreUnitario")) = False Then
                     .ValoreUnitario = dr.Item("ValoreUnitario")
                  Else
                     .ValoreUnitario = VALORE_ZERO
                  End If

                  ' Sconto %.
                  If IsDBNull(dr.Item("Sconto")) = False Then
                     .Sconto = dr.Item("Sconto")
                  Else
                     .Sconto = VALORE_ZERO
                  End If

                  ' Importo.
                  If IsDBNull(dr.Item("ImportoNetto")) = False Then
                     .ImportoNetto = dr.Item("ImportoNetto")
                  Else
                     .ImportoNetto = VALORE_ZERO
                  End If

                  ' Aliquota Iva.
                  If IsDBNull(dr.Item("AliquotaIva")) = False Then
                     .AliquotaIva = dr.Item("AliquotaIva")
                  Else
                     .AliquotaIva = "0"
                  End If

                  ' Categoria.
                  If IsDBNull(dr.Item("Categoria")) = False Then
                     .Categoria = dr.Item("Categoria")
                  Else
                     .Categoria = String.Empty
                  End If

                  ' Crea il nuovo record (duplicato) con i dati del record selezionato nella lista.
                  .InserisciDati(TAB_DETTAGLI_DOC)
               Loop
            End With

            ' Aggiorna l'elenco dati con il record nuovo.
            AggiornaDati()

            MessageBox.Show("La duplicazione dei dati Ë avvenuta con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Registra loperazione effettuata dall'operatore identificato.
            'g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiDati(ByVal tabella As String, ByVal sql As String)
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(tabella)

         DataGrid1.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(1, sql)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub LeggiNumPagine(ByVal tabella As String)
      Dim closeOnExit As Boolean

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("Select COUNT(*) FROM {0}", tabella)
         numRecord = CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se Ë da chiudere.
         If closeOnExit Then cn.Close()

         If eui_txtTestoRicerca.Text <> "" Then
            numPagine = 1
         Else
            ' Ottiene il numero di pagine.
            numPagine = (numRecord + DIM_PAGINA_GRANDE - 1) \ DIM_PAGINA_GRANDE 'dimPagina
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub VisualizzaPagina(ByVal n As Integer, ByVal sql As String)
      Try
         ' Apre la connessione.
         cn.Open()

         ' Crea un nuovo oggetto DataAdapter.
         Dim da As New OleDbDataAdapter(sql, cn)

         ' Pulisce la tabella da precedenti dati.
         dt.Clear()

         ' Visualizza la pagina dati.
         da.Fill(dt)

         ' Salva il numero di pagina corrente.
         pagCorrente = n

         ' Abilita/disabilita i pulsanti.
         'Primo.Enabled = (n > 1)
         'Precedente.Enabled = (n > 1)
         'Successivo.Enabled = (n < numPagine)
         'Ultimo.Enabled = (n < numPagine)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub AggiornaDati()
      Try
         If eui_txtTestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_DOCUMENTI)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            Select Case filtroDati
               Case "Tutti"
                  ' Filtra i dati in base al testo digitato.
                  FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)

               Case "Mese"
                  ' Aggiorna la griglia dati.
                  AggiornaDatiMese()

               Case "Anno"
                  ' Aggiorna la griglia dati.
                  AggiornaDatiAnno()

               Case "Periodo"
                  ' Aggiorna la griglia dati.
                  AggiornaDatiPeriodo()

               Case "Sospesi"
                  ' Aggiorna la griglia dati.
                  AggiornaDatiSospesi()
            End Select
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaDatiSospesi()
      Try
         ' Crea la stringa di selezione dei dati..
         sql = String.Format("Select TOP {0} * FROM {1} WHERE SospesoIncassare <> 0 ORDER BY DataDoc", DIM_PAGINA_GRANDE, TAB_DOCUMENTI)
         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()
         AttivaDisattivaBuoni()
         AttivaDisattivaAnnullaDoc()
         AttivaDisattivaEsportaFatturaElettronica()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Somma i valori della colonna Importo.
         SommaImporti()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaDatiPeriodo()
      Try
         ' Rimuove i dati di un'eventuale ricerca.
         eui_txtTestoRicerca.Text = String.Empty

         Dim frmFiltroPerido As New FiltroPeriodo()
         If frmFiltroPerido.ShowDialog = Windows.Forms.DialogResult.OK Then

            ' Crea la stringa di selezione dei dati.
            Dim dataDal As String = CFormatta.FormattaData(frmFiltroPerido.eui_dtpDataDal.Value.GetValueOrDefault.ToShortDateString)
            Dim dataAl As String = CFormatta.FormattaData(frmFiltroPerido.eui_dtpDataAl.Value.GetValueOrDefault.ToShortDateString)
            sql = String.Format("Select TOP {0} * FROM {1} WHERE DataDoc BETWEEN #{2}# And #{3}# ORDER BY DataDoc ASC", DIM_PAGINA_GRANDE, TAB_DOCUMENTI, dataDal, dataAl)
            repSql = sql
            LeggiDati("(" & sql & ")", sql)

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            ConvalidaDati()

            ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
            AttivaDisattivaSospeso()
            AttivaDisattivaPassaSospeso()
            AttivaDisattivaAnnullaSospeso()
            AttivaDisattivaBuoni()
            AttivaDisattivaAnnullaDoc()
            AttivaDisattivaEsportaFatturaElettronica()

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TITOLO_FINESTRA)

            ' Somma i valori della colonna Importo.
            SommaImporti()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaDatiMese()
      Try
         ' Crea la stringa di selezione dei dati.
         Dim Anno As String = Year(Now)
         Dim Mese As String = Month(Now)
         Dim Appo1 As String = CFormatta.FormattaData("01/" & Mese & "/" & Anno)
         Dim UltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, Mese)
         Dim Appo2 As String = CFormatta.FormattaData(UltimoGiornoAnno & "/" & Mese & "/" & Anno)
         sql = String.Format("Select TOP {0} * FROM {1} WHERE DataDoc BETWEEN #{2}# And #{3}# ORDER BY DataDoc ASC", DIM_PAGINA_GRANDE, TAB_DOCUMENTI, Appo1, Appo2)

         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()
         AttivaDisattivaBuoni()
         AttivaDisattivaAnnullaDoc()
         AttivaDisattivaEsportaFatturaElettronica()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Somma i valori della colonna Importo.
         SommaImporti()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaDatiAnno()
      Try
         ' Crea la stringa di selezione dei dati.
         Dim Anno As String = Year(Now)
         Dim Appo1 As String = CFormatta.FormattaData("01/01/" & Anno)
         Dim UltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, 12)
         Dim Appo2 As String = CFormatta.FormattaData(UltimoGiornoAnno & "/12/" & Anno)
         sql = String.Format("Select TOP {0} * FROM {1} WHERE DataDoc BETWEEN #{2}# And #{3}# ORDER BY DataDoc ASC", DIM_PAGINA_GRANDE, TAB_DOCUMENTI, Appo1, Appo2)

         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()
         AttivaDisattivaBuoni()
         AttivaDisattivaAnnullaDoc()
         AttivaDisattivaEsportaFatturaElettronica()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Somma i valori della colonna Importo.
         SommaImporti()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SommaImporti()
      Try
         'Dim importo As Decimal = SommaColonna(DataGrid1, COLONNA_IMPORTO_TOTALE, numRecord)
         'Dim sospeso As Decimal = SommaColonna(DataGrid1, COLONNA_IMPORTO_SOSPESO, numRecord)
         'Dim buoni As Decimal = SommaColonna(DataGrid1, COLONNA_IMPORTO_BUONI, numRecord)

         ' Sottrae dal totale dei documenti i valori sospesi e i buoni non fatturati.
         'Dim totImporto As Decimal = importo - sospeso - buoni

         ' Somma i valori della colonna Totale.
         'eui_txtTotale.Text = CFormatta.FormattaEuro(totImporto)
         eui_txtTotale.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO_TOTALE, numRecord))

         ' Somma i valori della colonna Sospeso.
         eui_txtSospeso.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO_SOSPESO_INC, numRecord))

         ' Somma i valori della colonna Imponibile.
         eui_txtImponibile.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO_IMPONIBILE, numRecord))

         ' Somma i valori della colonna Imposta.
         eui_txtImposta.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO_IMPOSTA, numRecord))

         ' Somma i valori della colonna Buoni pasto.
         eui_txtBuoni.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO_BUONI_INC, numRecord))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ImpostaComandi()
      If numRecord = 0 Then
         ' Disattiva i pulsanti appropriati.
         ' Modifica.
         g_frmMain.eui_Strumenti_Modifica.Enabled = False
         g_frmMain.eui_Strumenti_Duplica.Enabled = False
         g_frmMain.eui_Strumenti_Elimina.Enabled = False
         g_frmMain.eui_Strumenti_Annulla.Enabled = False
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = False
         g_frmMain.eui_Strumenti_Esporta.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = False
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = False

         ' Sospesi.
         g_frmMain.eui_Strumenti_Sospesi_Filtra.Enabled = False
         g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = False
         g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = False
         g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = False
         g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = False
      Else
         ' Attiva i pulsanti appropriati.
         ' Modifica.
         g_frmMain.eui_Strumenti_Modifica.Enabled = True
         g_frmMain.eui_Strumenti_Duplica.Enabled = True
         g_frmMain.eui_Strumenti_Elimina.Enabled = True
         'g_frmMain.eui_Strumenti_Annulla.Enabled = True
         g_frmMain.eui_Strumenti_Aggiorna.Enabled = True
         g_frmMain.eui_Strumenti_Esporta.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Anteprima.Enabled = True
         g_frmMain.eui_Strumenti_Stampa_Elenco.Enabled = True

         ' Sospesi.
         g_frmMain.eui_Strumenti_Sospesi_Filtra.Enabled = True
         'g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = True
         'g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = True
         'g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = True
         'g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      If ImpostaFunzioniOperatore(Finestra.Documenti) = True Then
         ImpostaComandi()
      End If
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5) & " - " &
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4) & " n. " &
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & " del " &
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2))
         Else
            DataGrid1.CaptionText = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AttivaDisattivaSospeso()
      Try
         ' Attiva/disattiva il pulsante per l'incasso dei sospesi.
         If numRecord <> 0 Then
            Select Case DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC)

               Case TIPO_DOC_RF, TIPO_DOC_FF

                  If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_SOSPESO_INC) = VALORE_ZERO Then
                     g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = False
                  Else
                     g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = True
                  End If

               Case TIPO_DOC_CO, TIPO_DOC_PF, TIPO_DOC_SF

                  g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = False

            End Select
         Else
            g_frmMain.eui_Strumenti_Sospesi_Incassa.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AttivaDisattivaAnnullaSospeso()
      Try
         ' Attiva/disattiva il pulsante per l'incasso dei sospesi.
         If numRecord <> 0 Then
            Select Case DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC)

               Case TIPO_DOC_RF, TIPO_DOC_FF

                  If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_SOSPESO_INC) = VALORE_ZERO Then
                     g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = False
                  Else
                     g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = True
                  End If

               Case TIPO_DOC_CO, TIPO_DOC_PF, TIPO_DOC_SF

                  g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = False

            End Select
         Else
            g_frmMain.eui_Strumenti_Sospesi_Annulla.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AttivaDisattivaPassaSospeso()
      Try
         ' Attiva/disattiva il pulsante per l'incasso dei sospesi.
         If numRecord <> 0 Then
            Select Case DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC)

               Case TIPO_DOC_RF, TIPO_DOC_FF

                  If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_TOTALE) = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_SOSPESO_INC) Then
                     g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = False
                  Else
                     g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = True
                  End If

               Case TIPO_DOC_CO, TIPO_DOC_PF, TIPO_DOC_SF

                  g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = False

            End Select
         Else
            g_frmMain.eui_Strumenti_Sospesi_Passa.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AttivaDisattivaBuoni()
      Try
         If numRecord <> 0 Then
            ' Attiva/disattiva il pulsante per visualizzare l'elenco dei Buoni pasto.
            If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_BUONI_INC) = VALORE_ZERO Then

               g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = False
            Else
               g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = True
            End If
         Else
            g_frmMain.eui_Strumenti_Buoni_Pasto.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AttivaDisattivaAnnullaDoc()
      Try
         ' Attiva/disattiva il pulsante per annullare un documento.
         If numRecord <> 0 Then

            Dim tipoDoc As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC)
            Dim statoDoc As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_STATO_DOC)

            Select Case tipoDoc
               Case TIPO_DOC_RF, TIPO_DOC_FF, TIPO_DOC_SF

                  Select Case statoDoc
                     Case STATO_DOC_EMESSO, STATO_DOC_EMESSO_STAMPATO, STATO_DOC_EMESSO_XML
                        g_frmMain.eui_Strumenti_Annulla.Enabled = True

                     Case Else
                        g_frmMain.eui_Strumenti_Annulla.Enabled = False

                  End Select

               Case Else
                  g_frmMain.eui_Strumenti_Annulla.Enabled = False

            End Select
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AttivaDisattivaEsportaFatturaElettronica()
      Try
         ' Attiva/disattiva il pulsante per esportare il documento in Fattura elettronica.
         If numRecord <> 0 Then
            Dim tipoDoc As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC)
            Dim statoDoc As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_STATO_DOC)

            Select Case tipoDoc
               Case TIPO_DOC_FF

                  Select Case statoDoc
                     Case STATO_DOC_EMESSO, STATO_DOC_EMESSO_STAMPATO
                        g_frmMain.eui_Strumenti_Esporta_XML.Enabled = True

                     Case Else
                        g_frmMain.eui_Strumenti_Esporta_XML.Enabled = False

                  End Select

               Case Else
                  g_frmMain.eui_Strumenti_Esporta_XML.Enabled = False

            End Select
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AnnullaDocumento()
      Try
         Dim Id As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC)
         Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_DATA_DOC)
         Dim Documento As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC)
         Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_NUMERO_DOC)
         Dim Importo As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_TOTALE)

         ' Chiede conferma per l'annullamento.
         Dim risposta As Integer
         risposta = MessageBox.Show("Si desidera annullare il documento """ & Documento & " n. " & Numero & " del " & Data & """? " & vbCrLf & vbCrLf &
                                    "Confermando l'operazione verranno ripristinati i valori per le " &
                                    "giacenze di magazzino degli Articoli e le Statistiche di vendita. Eventuali Buoni pasto contenuti " &
                                    "nel documento non ancora fatturati verranno annullati. Procedere?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         If risposta = vbYes Then
            RipristinaIngredientiScaricati()
            RipristinaStatistiche()

            ' Attiva/disattiva il pulsante per visualizzare l'elenco dei Buoni pasto.
            If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_BUONI_INC) <> VALORE_ZERO Then
               If RipristinaBuoniPasto() = True Then
                  EliminaBuoniPasto()
               End If
            End If
         Else
            Exit Sub
         End If

         ' Chiede conferma per l'eliminazione.
         risposta = MessageBox.Show("Il documento """ & Documento & " n. " & Numero & " del " & Data & """ Ë stato annullato! " & vbCrLf & vbCrLf &
                              "Si desidera mantenere il documento nell'elenco documenti per eventuali consultazioni? ", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
         If risposta = vbNo Then
            EliminaDettagliDocumento()
            EliminaDocumento()

         Else
            ModificaStatoDocumento(TAB_DOCUMENTI, Id, STATO_DOC_ANNULLATO)
         End If

         ' QUESTA PROCEDURA NON E' PIU' NECESSARIA. 
         ' Salva il Numero del documento annullato come prossimo numero da stampare rendendolo nuovamente disponibile.
         'RipristinaNumeroDocFiscaleConfig(TAB_DOCUMENTI, Documento, Numero)

         ' Aggiorna la lista dei documenti.
         g_frmDocumenti.AggiornaDati()

         ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()
         AttivaDisattivaBuoni()
         AttivaDisattivaAnnullaDoc()
         AttivaDisattivaEsportaFatturaElettronica()

         ' Registra loperazione effettuata dall'operatore identificato.
         Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - Ä " & CFormatta.FormattaEuro(Importo) & ")"
         g_frmMain.RegistraOperazione(TipoOperazione.AnnullaDoc, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ModificaStatoDocumento(ByVal tabella As String, ByVal codice As String, ByVal stato As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim tr As OleDbTransaction
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET StatoDoc = @StatoDoc WHERE Id = {1}", tabella, codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@StatoDoc", stato)

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

   Private Sub RipristinaNumeroDocFiscaleConfig(ByVal tabella As String, ByVal tipoDoc As String, ByVal numDoc As Integer)
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim chiaveConfig As String
         Select Case tipoDoc
            Case TIPO_DOC_FF
               chiaveConfig = "NumeroFattura"

            Case TIPO_DOC_RF
               chiaveConfig = "NumeroRicevuta"

         End Select

         DatiConfig.SetValue(chiaveConfig, numDoc.ToString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

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
         'cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0} WHERE TipoDoc = '{1}'", tabella, tipoDoc)

         ' Ottiene i dati per l'anno corrente.
         Dim Anno As String = Year(Now)
         Dim primoGiornoAnno As String = CFormatta.FormattaData("01/01/" & Anno)
         Dim numUltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, 12)
         Dim ultimoGiornoAnno As String = CFormatta.FormattaData(numUltimoGiornoAnno & "/12/" & Anno)

         cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0} WHERE TipoDoc = '{1}' AND DataDoc BETWEEN #{2}# AND #{3}#", tabella, tipoDoc, primoGiornoAnno, ultimoGiornoAnno)

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

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      ' Imposta il titolo della tabella.
      Me.Text = titolo & " (n∞ totale: " & numRecord & ")"
   End Sub

   Private Sub CreaColonne(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' 0 Id - Codice
         Dim codiceStyle As New DataGridTextBoxColumn
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 0
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' 1 Numero documento
         Dim numeroStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         numeroStyle.MappingName = "NumDoc"
         numeroStyle.HeaderText = "Numero."
         numeroStyle.Width = 50
         numeroStyle.NullText = ""
         numeroStyle.Format = "##,##0"
         numeroStyle.Alignment = HorizontalAlignment.Right
         numeroStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(numeroStyle)
         ' 2 Data documento
         Dim dataStyle As New DataGridTextBoxColumn
         dataStyle.MappingName = "DataDoc"
         dataStyle.HeaderText = "Data"
         dataStyle.Width = 75
         dataStyle.NullText = ""
         dataStyle.Alignment = HorizontalAlignment.Center
         dataStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataStyle)
         ' 3 Ora documento
         Dim oraStyle As New DataGridTextBoxColumn
         oraStyle.MappingName = "OraDoc"
         oraStyle.HeaderText = "Ora"
         oraStyle.Width = 50
         oraStyle.NullText = ""
         oraStyle.Alignment = HorizontalAlignment.Left
         oraStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraStyle)
         ' 4 Documento
         Dim documentoStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         documentoStyle.MappingName = "TipoDoc"
         documentoStyle.HeaderText = "Tipo documento"
         documentoStyle.Width = 150
         documentoStyle.NullText = ""
         documentoStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(documentoStyle)
         ' 5 Cliente
         Dim clienteStyle As New DataGridTextBoxColumn
         clienteStyle.MappingName = "Cliente"
         clienteStyle.HeaderText = "Intestatario"
         clienteStyle.Width = 150
         clienteStyle.NullText = ""
         clienteStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(clienteStyle)
         ' 6 Stato
         Dim statoStyle As New DataGridTextBoxColumn
         statoStyle.MappingName = "StatoDoc"
         statoStyle.HeaderText = "Stato"
         statoStyle.Width = 120
         statoStyle.NullText = ""
         statoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(statoStyle)
         ' 7 Causale
         Dim causaleStyle As New DataGridTextBoxColumn
         causaleStyle.MappingName = "CausaleDoc"
         causaleStyle.HeaderText = "Causale"
         causaleStyle.Width = 120
         causaleStyle.NullText = ""
         causaleStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(causaleStyle)
         ' 8 Tipo pagamento
         Dim tipoPagStyle As New DataGridTextBoxColumn
         tipoPagStyle.MappingName = "TipoPagamento"
         tipoPagStyle.HeaderText = "Tipo pagamento"
         tipoPagStyle.Width = 100
         tipoPagStyle.NullText = ""
         tipoPagStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tipoPagStyle)
         ' 9 Totale documento
         Dim totDocStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         totDocStyle.MappingName = "TotDoc"
         totDocStyle.HeaderText = "Totale."
         totDocStyle.Width = 80
         totDocStyle.NullText = ""
         totDocStyle.Format = "##,##0.00"
         totDocStyle.Alignment = HorizontalAlignment.Right
         totDocStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(totDocStyle)
         ' 10 Sospeso
         Dim sospesoStyle As New DataGridTextBoxColumn
         sospesoStyle.MappingName = "Sospeso"
         sospesoStyle.HeaderText = "Sospeso."
         sospesoStyle.Width = 80
         sospesoStyle.NullText = ""
         sospesoStyle.Format = "##,##0.00"
         sospesoStyle.Alignment = HorizontalAlignment.Right
         sospesoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(sospesoStyle)
         ' 11 Imponibile
         Dim imponibileStyle As New DataGridTextBoxColumn
         imponibileStyle.MappingName = "Imponibile"
         imponibileStyle.HeaderText = "Imponibile."
         imponibileStyle.Width = 80
         imponibileStyle.NullText = ""
         imponibileStyle.Format = "##,##0.00"
         imponibileStyle.Alignment = HorizontalAlignment.Right
         imponibileStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(imponibileStyle)
         ' 12 Imposta
         Dim impostaStyle As New DataGridTextBoxColumn
         impostaStyle.MappingName = "Imposta"
         impostaStyle.HeaderText = "Imposta. "
         impostaStyle.Width = 80
         impostaStyle.NullText = ""
         impostaStyle.Format = "##,##0.00"
         impostaStyle.Alignment = HorizontalAlignment.Right
         impostaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(impostaStyle)
         ' 13 Buoni pasto
         Dim buoniStyle As New DataGridTextBoxColumn
         buoniStyle.MappingName = "BuoniPasto"
         buoniStyle.HeaderText = "Buoni pasto."
         buoniStyle.Width = 80
         buoniStyle.NullText = ""
         buoniStyle.Format = "##,##0.00"
         buoniStyle.Alignment = HorizontalAlignment.Right
         buoniStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(buoniStyle)
         ' 14 Chiuso.
         Dim chiusoStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         chiusoStyle.MappingName = "Chiuso"
         chiusoStyle.HeaderText = "Contabilizzato"
         chiusoStyle.Width = 100
         chiusoStyle.NullText = ""
         chiusoStyle.Alignment = HorizontalAlignment.Center
         chiusoStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(chiusoStyle)
         ' 15 Sospeso da incassare
         Dim sospesoIncStyle As New DataGridTextBoxColumn
         sospesoIncStyle.MappingName = "SospesoIncassare"
         sospesoIncStyle.HeaderText = ""
         sospesoIncStyle.Width = 0
         sospesoIncStyle.NullText = ""
         sospesoIncStyle.Alignment = HorizontalAlignment.Right
         sospesoIncStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(sospesoIncStyle)
         ' 16 Buoni pasto da incassare
         Dim buoniIncStyle As New DataGridTextBoxColumn
         buoniIncStyle.MappingName = "BuoniPastoIncassare"
         buoniIncStyle.HeaderText = ""
         buoniIncStyle.Width = 0
         buoniIncStyle.NullText = ""
         buoniIncStyle.Alignment = HorizontalAlignment.Right
         buoniIncStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(buoniIncStyle)
         ' 17 Id Cliente.
         Dim idClienteStyle As New DataGridTextBoxColumn
         idClienteStyle.MappingName = "idCliente"
         idClienteStyle.HeaderText = ""
         idClienteStyle.Width = 0
         idClienteStyle.NullText = ""
         idClienteStyle.Alignment = HorizontalAlignment.Right
         idClienteStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(idClienteStyle)

         '' Tavolo
         'Dim tavoloStyle As New DataGridTextBoxColumn
         'tavoloStyle.MappingName = "Tavolo"
         'tavoloStyle.HeaderText = "Tavolo"
         'tavoloStyle.Width = 70
         'tavoloStyle.NullText = ""
         'tavoloStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(tavoloStyle)

         '' Cameriere
         'Dim cameriereStyle As New DataGridTextBoxColumn
         'cameriereStyle.MappingName = "Cameriere"
         'cameriereStyle.HeaderText = "Cameriere"
         'cameriereStyle.Width = 150
         'cameriereStyle.NullText = ""
         'cameriereStyle.TextBox.BackColor = Color.White
         'gridStyle.GridColumnStyles.Add(cameriereStyle)
         ' Sospeso da incassare

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub FiltraDati(ByVal testoRicerca As String, ByVal campoRicerca As String)
      Try
         Dim sql As String

         testoRicerca = FormattaApici(testoRicerca)

         Select Case campoRicerca
            Case "Numero"
               campoRicerca = "NumDoc"
            Case "Data"
               campoRicerca = "DataDoc"
            Case "Ora"
               campoRicerca = "OraDoc"
            Case "Tipo documento"
               campoRicerca = "TipoDoc"
            Case "Intestatario"
               campoRicerca = "Cliente"
            Case "Stato documento"
               campoRicerca = "StatoDoc"
            Case "Causale"
               campoRicerca = "CausaleDoc"
            Case "Totale"
               campoRicerca = "TotDoc"
            Case "Buoni pasto"
               campoRicerca = "BuoniPasto"
            Case "Tipo pagamento"
               campoRicerca = "TipoPagamento"
            Case "Contabilizzato"
               campoRicerca = "Chiuso"
         End Select

         If testoRicerca <> String.Empty Then
            g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
            g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO

            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_DOCUMENTI, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_DOCUMENTI, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = True
            g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
            g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
            g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO

            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY DataDoc ASC", DIM_PAGINA_GRANDE, TAB_DOCUMENTI)
            repSql = String.Format("SELECT * FROM {0} ORDER BY DataDoc ASC", TAB_DOCUMENTI)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_DOCUMENTI, sql)
         End If

         ' Somma i valori della colonna Importo.
         SommaImporti()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Attiva/disattiva il pulsanti per i sospesi, i buoni e annulla.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()
         AttivaDisattivaBuoni()
         AttivaDisattivaAnnullaDoc()
         AttivaDisattivaEsportaFatturaElettronica()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaCampiRic()
      Try
         eui_cmbCampoRicerca.Items.Add("Numero")
         eui_cmbCampoRicerca.Items.Add("Data")
         eui_cmbCampoRicerca.Items.Add("Ora")
         eui_cmbCampoRicerca.Items.Add("Tipo documento")
         eui_cmbCampoRicerca.Items.Add("Intestatario")
         eui_cmbCampoRicerca.Items.Add("Stato documento")
         eui_cmbCampoRicerca.Items.Add("Causale")
         eui_cmbCampoRicerca.Items.Add("Tipo pagamento")
         eui_cmbCampoRicerca.Items.Add("Totale")
         eui_cmbCampoRicerca.Items.Add("Sospeso")
         eui_cmbCampoRicerca.Items.Add("Imponibile")
         eui_cmbCampoRicerca.Items.Add("Imposta")
         eui_cmbCampoRicerca.Items.Add("Buoni pasto")
         eui_cmbCampoRicerca.Items.Add("Contabilizzato")

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

   Public Sub StampaDocumento(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try

         If PrintDialog1.ShowDialog() = DialogResult.OK Then

            'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
            Dim cn As New OleDbConnection(ConnString)

            cn.Open()

            Dim oleAdapter As New OleDbDataAdapter

            oleAdapter.SelectCommand = New OleDbCommand(sqlRep, cn)

            Dim ds As New Dataset1

            ds.Clear()

            oleAdapter.Fill(ds, tabella)

            Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

            rep.Load(Application.StartupPath & nomeDoc)

            rep.SetDataSource(ds)

            rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True,
                               PrintDialog1.PrinterSettings.FromPage,
                               PrintDialog1.PrinterSettings.ToPage)

            cn.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub IncassaSospeso()
      Try
         ' Apre la finestra per l'incasso del sospeso.
         Dim frm As New IncassaSospeso(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC),
                                          DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_NUMERO_DOC),
                                          DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_DATA_DOC),
                                          DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC),
                                          DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_INTESTATARIO),
                                          DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_SOSPESO))
         frm.ShowDialog()

      Catch ex As Exception

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub PassaSospeso(ByVal id As Integer, ByVal totale As String)
      Try
         Dim risposta As Integer
         risposta = MsgBox("Il totale del documento verr‡ passato in sospeso. Procedere?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)
         If risposta = vbNo Then
            Exit Sub
         Else
            Dim sql As String
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa.
            sql = String.Format("UPDATE {0} SET Sospeso = @Sospeso, SospesoIncassare = @SospesoIncassare WHERE Id = {1}", TAB_DOCUMENTI, id)

            ' Crea il comando per la connessione corrente.
            Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

            cmdUpdate.Parameters.Add("@Sospeso", totale)
            cmdUpdate.Parameters.Add("@SospesoIncassare", totale)

            ' Esegue il comando.
            Dim Record1 As Integer = cmdUpdate.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()

            Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_DATA_DOC)
            Dim Documento As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC)
            Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_NUMERO_DOC)
            Dim Importo As String = CFormatta.FormattaEuro(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_TOTALE))

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - Ä " & Importo & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.PassaSospeso, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

            If g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiSospesi()
               Exit Sub
            ElseIf g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiMese()
               Exit Sub
            ElseIf g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiAnno()
               Exit Sub
            ElseIf g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiPeriodo()
               Exit Sub
            Else
               ' Aggiorna la griglia dati.
               AggiornaDati()
               Exit Sub
            End If
         End If

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

   Public Sub AnnullaSospeso(ByVal id As Integer)
      Try
         Dim risposta As Integer
         risposta = MsgBox("Il valore sospeso del documento verr‡ azzerato. Procedere?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)
         If risposta = vbNo Then
            Exit Sub
         Else
            Dim sql As String
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa.
            sql = String.Format("UPDATE {0} SET Sospeso = @Sospeso, SospesoIncassare = @SospesoIncassare WHERE Id = {1}", TAB_DOCUMENTI, id)

            ' Crea il comando per la connessione corrente.
            Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

            cmdUpdate.Parameters.Add("@Sospeso", VALORE_ZERO)
            cmdUpdate.Parameters.Add("@SospesoIncassare", VALORE_ZERO)

            ' Esegue il comando.
            Dim Record1 As Integer = cmdUpdate.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()

            Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_DATA_DOC)
            Dim Documento As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC)
            Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_NUMERO_DOC)
            Dim Importo As String = CFormatta.FormattaEuro(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_TOTALE))

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - Ä " & Importo & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.AnnullaSospeso, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

            If g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiSospesi()
               Exit Sub
            ElseIf g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiMese()
               Exit Sub
            ElseIf g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiAnno()
               Exit Sub
            ElseIf g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiPeriodo()
               Exit Sub
            Else
               ' Aggiorna la griglia dati.
               AggiornaDati()
               Exit Sub
            End If
         End If

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

   Public Sub ApriElencoBuoni()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ConnStringAnagrafiche = CreaConnString(PercorsoDB)

         Dim frm As New ElencoBuoni

         ' Visualizza l'anagrafica clienti.
         frm.Tag = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC)
         frm.ShowDialog()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ElencoDoc_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated

#Region "Strumenti di Modifica - (Condivisa) "
      ' Visualizza i comandi Strumenti di modifica sul Ribbon.
      g_frmMain.rtgStrumentiModifica.Visible = True

#Region "Modifica - (Condivisa) "
      ' TabPage.
      g_frmMain.eui_StrumentiModifica.Visible = True

      ' Dati.
      g_frmMain.eui_Strumenti_Nuovo.Visible = True
      g_frmMain.eui_Strumenti_Modifica.Visible = True
      g_frmMain.eui_Strumenti_Duplica.Visible = True
      g_frmMain.eui_Strumenti_Elimina.Visible = True
      g_frmMain.eui_Strumenti_Annulla.Visible = True
      g_frmMain.eui_Strumenti_Aggiorna.Visible = True

      ' Esporta.
      g_frmMain.eui_Strumenti_Esporta.Visible = True
      g_frmMain.eui_Strumenti_Esporta_SepXML.Visible = True
      g_frmMain.eui_Strumenti_Esporta_XML.Visible = moduloAttivo.FattElettronica
      g_frmMain.eui_Strumenti_Esporta_EML.Visible = False

      ' Stampa.
      g_frmMain.eui_Strumenti_Stampa_Anteprima.Visible = True
      g_frmMain.eui_Strumenti_Stampa_Elenco.Visible = True

#End Region

#Region "Periodo - (Condivisa) "
      ' TabPage.
      g_frmMain.eui_StrumentiPeriodo.Visible = True

      ' Periodo.
      g_frmMain.eui_Strumenti_Periodo_Tutte.Visible = True
      g_frmMain.eui_Strumenti_Periodo_Anno.Visible = True
      g_frmMain.eui_Strumenti_Periodo_Mese.Visible = True
      g_frmMain.eui_Strumenti_Periodo_DalAl.Visible = True
      g_frmMain.eui_Strumenti_Periodo_Sep1.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Arrivo.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Partenza.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Sep2.Visible = False
      g_frmMain.eui_Strumenti_Periodo_NonAssegnate.Visible = False
      g_frmMain.eui_Strumenti_Periodo_Terminate.Visible = False

      ' Visualizza.
      g_frmMain.eui_Strumenti_Visualizza_Presenze.Visible = False
      g_frmMain.eui_rib_Visualizza.Visible = False

#End Region

#Region "Documenti "
      ' TabPage.
      g_frmMain.eui_StrumentiDocumenti.Visible = False

#End Region

#Region "Sospesi / Buoni pasto "
      ' TabPage.
      g_frmMain.eui_StrumentiSospesiBuoni.Visible = True

#End Region

      ' Serve ad attivare/disattivare i vari comandi in base ai dati visualizzati.
      AggiornaDati()

#End Region

   End Sub

   Private Sub ElencoDoc_Deactivate(sender As Object, e As EventArgs) Handles Me.Deactivate

#Region "Strumenti di Modifica - (Condivisa) "
      ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgStrumentiModifica.Visible = False

#End Region

   End Sub

   Private Sub ElencoDoc_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmDocumenti)

         ' Distrugge l'oggetto e libera le risorse.
         g_frmDocumenti.Dispose()
         g_frmDocumenti = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ElencoDoc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_DOCUMENTI)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         eui_cmbCampoRicerca.SelectedIndex = 0

         Select Case filtroDati
            Case "Tutti"
               g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = True
               g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
               g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO
               ' Filtra i dati in base al testo digitato.
               FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)

            Case "Mese"
               g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = True
               g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
               g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO
               ' Aggiorna la griglia dati.
               AggiornaDatiMese()

            Case "Anno"
               g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = True
               g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO
               ' Aggiorna la griglia dati.
               AggiornaDatiAnno()

            Case "Periodo"
               g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = True
               g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
               g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = False
               ' DA_FARE_A: Salvare stringa di ricerca date.
               g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO
               ' Aggiorna la griglia dati.
               AggiornaDatiPeriodo()

            Case "Sospesi"
               g_frmMain.eui_Strumenti_Periodo_Tutte.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = False
               g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = False
               g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = True
               g_frmMain.eui_Strumenti_Periodo_DalAl.Text = g_frmMain.TESTO_FILTRO_PERIODO
               ' Aggiorna la griglia dati.
               AggiornaDatiSospesi()
         End Select

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         If g_frmMain.eui_Strumenti_Modifica.Enabled = True Then
            ' Attiva/disattiva il pulsante per annullare un documento.
            AttivaDisattivaAnnullaDoc()

            ' Attiva/disattiva il pulsante per esportare il documento in Fattura elettronica.
            AttivaDisattivaEsportaFatturaElettronica()

            ' Attiva/disattiva il pulsanti per i sospesi.
            AttivaDisattivaSospeso()
            AttivaDisattivaPassaSospeso()
            AttivaDisattivaAnnullaSospeso()

            ' Attiva/Disattiva il pulsante per i Buoni.
            AttivaDisattivaBuoni()
         End If

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()

      ' Attiva/disattiva il pulsante per annullare un documento.
      AttivaDisattivaAnnullaDoc()

      ' Attiva/disattiva il pulsante per esportare il documento in Fattura elettronica.
      AttivaDisattivaEsportaFatturaElettronica()

      ' Attiva/disattiva i pulsanti per i sospesi.
      AttivaDisattivaSospeso()
      AttivaDisattivaPassaSospeso()
      AttivaDisattivaAnnullaSospeso()

      ' Attiva/Disattiva il pulsante per i Buoni.
      AttivaDisattivaBuoni()
   End Sub

   Private Sub TestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_txtTestoRicerca.TextChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)
   End Sub

   Private Sub CampoRicerca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles eui_cmbCampoRicerca.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(eui_txtTestoRicerca.Text, eui_cmbCampoRicerca.Text)
   End Sub

   Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
      ' Apre la finestra Documento per la modifica dei dati.
      Modifica()
   End Sub

   Private Sub dtpDal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDal.ValueChanged
      AggiornaDatiPeriodo()
   End Sub

   Private Sub dtpAl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAl.ValueChanged
      AggiornaDatiPeriodo()
   End Sub

   Public Sub Nuovo()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         g_frmDocumento = New frmDocumento("ElencoDoc", "Conto", String.Empty)
         g_frmDocumento.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub Modifica()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Apre la finestra Documento per la modifica dei dati.
         g_frmDocumento = New frmDocumento("ElencoDoc", DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4), DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))
         g_frmDocumento.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub NuovaFatturaElettronica()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         g_frmFatturaElettronica = New frmFatturaElettronica(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_DOC).ToString,
                                                             DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_ID_CLIENTE).ToString)
         g_frmFatturaElettronica.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

End Class
