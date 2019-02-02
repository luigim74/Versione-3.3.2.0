' Nome form:            frmElencoDati
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 15/04/2006
' Descrizione:          Elenco dati riutilizzabile per tutte le anagrafiche.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class ElencoDoc
   Inherits System.Windows.Forms.Form

   Const TAB_DOCUMENTI As String = "Documenti"
   Const TITOLO_FINESTRA As String = "Elenco Documenti"
   Const COLONNA_ID_DOC As Short = 0
   Const COLONNA_NUMERO_DOC As Short = 1
   Const COLONNA_TIPO_DOC As Short = 4
   Const COLONNA_IMPORTO_TOTALE As Short = 7
   Const COLONNA_IMPORTO_SOSPESO As Short = 8
   Const COLONNA_IMPORTO_SOSPESO_INC As Short = 14
   Const COLONNA_IMPORTO_BUONI As Short = 11
   Const COLONNA_IMPORTO_BUONI_INC As Short = 15

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
   Dim repSql As String

   Private DatiConfig As AppConfig
   Private CFormatta As New ClsFormatta
   Private AArticoli As New Articoli
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Dim filtroDati As String

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
   Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton7 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Elimina As System.Windows.Forms.ToolBarButton
   Friend WithEvents Primo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Precedente As System.Windows.Forms.ToolBarButton
   Friend WithEvents Successivo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Ultimo As System.Windows.Forms.ToolBarButton
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents CampoRicerca As System.Windows.Forms.ComboBox
   Friend WithEvents TestoRicerca As System.Windows.Forms.TextBox
   Friend WithEvents tbNuovo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Sep13 As System.Windows.Forms.ToolBarButton
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Public WithEvents txtTotImporto As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents txtSospeso As System.Windows.Forms.TextBox
   Friend WithEvents Ripristina As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrTutti As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrSospesi As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrPassaSospeso As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrAnnullaSospeso As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrMese As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrAnno As System.Windows.Forms.ToolBarButton
   Friend WithEvents dtpAl As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpDal As System.Windows.Forms.DateTimePicker
   Friend WithEvents lblAl As System.Windows.Forms.Label
   Friend WithEvents lblDal As System.Windows.Forms.Label
   Friend WithEvents lblCampo As System.Windows.Forms.Label
   Friend WithEvents lblTesto As System.Windows.Forms.Label
   Friend WithEvents tbrPeriodo As System.Windows.Forms.ToolBarButton
   Public WithEvents txtBuoni As System.Windows.Forms.TextBox
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents tbrAnnulla As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrSospeso As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrBuoni As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrAggiorna As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrAnteprima As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrStampa As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrInserisci As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrModifica As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoDoc))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.tbrTutti = New System.Windows.Forms.ToolBarButton()
      Me.tbrMese = New System.Windows.Forms.ToolBarButton()
      Me.tbrAnno = New System.Windows.Forms.ToolBarButton()
      Me.tbrPeriodo = New System.Windows.Forms.ToolBarButton()
      Me.tbrSospesi = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
      Me.tbrAnnulla = New System.Windows.Forms.ToolBarButton()
      Me.Sep13 = New System.Windows.Forms.ToolBarButton()
      Me.Ripristina = New System.Windows.Forms.ToolBarButton()
      Me.tbrModifica = New System.Windows.Forms.ToolBarButton()
      Me.tbrSospeso = New System.Windows.Forms.ToolBarButton()
      Me.tbrPassaSospeso = New System.Windows.Forms.ToolBarButton()
      Me.tbrAnnullaSospeso = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton()
      Me.Elimina = New System.Windows.Forms.ToolBarButton()
      Me.tbrBuoni = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
      Me.tbNuovo = New System.Windows.Forms.ToolBarButton()
      Me.Primo = New System.Windows.Forms.ToolBarButton()
      Me.Precedente = New System.Windows.Forms.ToolBarButton()
      Me.Successivo = New System.Windows.Forms.ToolBarButton()
      Me.Ultimo = New System.Windows.Forms.ToolBarButton()
      Me.tbrAggiorna = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
      Me.tbrAnteprima = New System.Windows.Forms.ToolBarButton()
      Me.tbrStampa = New System.Windows.Forms.ToolBarButton()
      Me.tbrInserisci = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.dtpAl = New System.Windows.Forms.DateTimePicker()
      Me.dtpDal = New System.Windows.Forms.DateTimePicker()
      Me.lblAl = New System.Windows.Forms.Label()
      Me.lblDal = New System.Windows.Forms.Label()
      Me.CampoRicerca = New System.Windows.Forms.ComboBox()
      Me.lblCampo = New System.Windows.Forms.Label()
      Me.lblTesto = New System.Windows.Forms.Label()
      Me.TestoRicerca = New System.Windows.Forms.TextBox()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.txtBuoni = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.txtSospeso = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtTotImporto = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbrTutti, Me.tbrMese, Me.tbrAnno, Me.tbrPeriodo, Me.tbrSospesi, Me.ToolBarButton2, Me.tbrAnnulla, Me.Sep13, Me.Ripristina, Me.tbrModifica, Me.tbrSospeso, Me.tbrPassaSospeso, Me.tbrAnnullaSospeso, Me.ToolBarButton7, Me.Elimina, Me.tbrBuoni, Me.ToolBarButton4, Me.tbNuovo, Me.Primo, Me.Precedente, Me.Successivo, Me.Ultimo, Me.tbrAggiorna, Me.ToolBarButton1, Me.tbrAnteprima, Me.tbrStampa, Me.tbrInserisci})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(864, 26)
      Me.ToolBar1.TabIndex = 2
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Wrappable = False
      '
      'tbrTutti
      '
      Me.tbrTutti.ImageIndex = 13
      Me.tbrTutti.Name = "tbrTutti"
      Me.tbrTutti.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrTutti.Tag = "Tutti"
      Me.tbrTutti.Text = "Tutti"
      Me.tbrTutti.ToolTipText = "Visualizza tutti i documenti"
      '
      'tbrMese
      '
      Me.tbrMese.ImageIndex = 15
      Me.tbrMese.Name = "tbrMese"
      Me.tbrMese.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrMese.Tag = "Mese"
      Me.tbrMese.Text = "Mese"
      Me.tbrMese.ToolTipText = "Visualizza documenti del mese corrente"
      '
      'tbrAnno
      '
      Me.tbrAnno.ImageIndex = 16
      Me.tbrAnno.Name = "tbrAnno"
      Me.tbrAnno.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrAnno.Tag = "Anno"
      Me.tbrAnno.Text = "Anno"
      Me.tbrAnno.ToolTipText = "Visualizza documenti dell'anno corrente"
      '
      'tbrPeriodo
      '
      Me.tbrPeriodo.ImageIndex = 14
      Me.tbrPeriodo.Name = "tbrPeriodo"
      Me.tbrPeriodo.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrPeriodo.Tag = "Periodo"
      Me.tbrPeriodo.Text = "Periodo"
      Me.tbrPeriodo.ToolTipText = "Visualizza documenti del periodo selezionato"
      '
      'tbrSospesi
      '
      Me.tbrSospesi.ImageIndex = 10
      Me.tbrSospesi.Name = "tbrSospesi"
      Me.tbrSospesi.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrSospesi.Tag = "Sospesi"
      Me.tbrSospesi.Text = "Sospesi"
      Me.tbrSospesi.ToolTipText = "Visualizza solo documenti sospesi"
      '
      'ToolBarButton2
      '
      Me.ToolBarButton2.Name = "ToolBarButton2"
      Me.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbrAnnulla
      '
      Me.tbrAnnulla.ImageIndex = 2
      Me.tbrAnnulla.Name = "tbrAnnulla"
      Me.tbrAnnulla.Tag = "Annulla"
      Me.tbrAnnulla.Text = "Annulla"
      Me.tbrAnnulla.ToolTipText = "Annulla documento"
      '
      'Sep13
      '
      Me.Sep13.Name = "Sep13"
      Me.Sep13.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'Ripristina
      '
      Me.Ripristina.ImageIndex = 5
      Me.Ripristina.Name = "Ripristina"
      Me.Ripristina.Tag = "Ripristina"
      Me.Ripristina.Text = "Ripristina"
      Me.Ripristina.ToolTipText = "Ripristina documento annullato"
      Me.Ripristina.Visible = False
      '
      'tbrModifica
      '
      Me.tbrModifica.ImageIndex = 1
      Me.tbrModifica.Name = "tbrModifica"
      Me.tbrModifica.Tag = "Modifica"
      Me.tbrModifica.Text = "Apri"
      Me.tbrModifica.ToolTipText = "Apri"
      Me.tbrModifica.Visible = False
      '
      'tbrSospeso
      '
      Me.tbrSospeso.ImageIndex = 11
      Me.tbrSospeso.Name = "tbrSospeso"
      Me.tbrSospeso.Tag = "Sospeso"
      Me.tbrSospeso.Text = "Incassa sospeso"
      Me.tbrSospeso.ToolTipText = "Incassa documento sospeso"
      '
      'tbrPassaSospeso
      '
      Me.tbrPassaSospeso.ImageIndex = 10
      Me.tbrPassaSospeso.Name = "tbrPassaSospeso"
      Me.tbrPassaSospeso.Tag = "PassaSospeso"
      Me.tbrPassaSospeso.ToolTipText = "Passa il documento in sospeso"
      '
      'tbrAnnullaSospeso
      '
      Me.tbrAnnullaSospeso.ImageIndex = 12
      Me.tbrAnnullaSospeso.Name = "tbrAnnullaSospeso"
      Me.tbrAnnullaSospeso.Tag = "AnnullaSospeso"
      Me.tbrAnnullaSospeso.ToolTipText = "Annulla il sospeso di un documento"
      '
      'ToolBarButton7
      '
      Me.ToolBarButton7.Name = "ToolBarButton7"
      Me.ToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'Elimina
      '
      Me.Elimina.ImageIndex = 2
      Me.Elimina.Name = "Elimina"
      Me.Elimina.Tag = "Elimina"
      Me.Elimina.Text = "Elimina"
      Me.Elimina.ToolTipText = "Elimina"
      Me.Elimina.Visible = False
      '
      'tbrBuoni
      '
      Me.tbrBuoni.ImageIndex = 17
      Me.tbrBuoni.Name = "tbrBuoni"
      Me.tbrBuoni.Tag = "Buoni"
      Me.tbrBuoni.Text = "Buoni pasto"
      Me.tbrBuoni.ToolTipText = "Elenco Buoni pasto "
      '
      'ToolBarButton4
      '
      Me.ToolBarButton4.Name = "ToolBarButton4"
      Me.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbNuovo
      '
      Me.tbNuovo.ImageIndex = 0
      Me.tbNuovo.Name = "tbNuovo"
      Me.tbNuovo.Tag = "Nuovo"
      Me.tbNuovo.Text = "Nuovo"
      Me.tbNuovo.ToolTipText = "Nuovo"
      Me.tbNuovo.Visible = False
      '
      'Primo
      '
      Me.Primo.ImageIndex = 3
      Me.Primo.Name = "Primo"
      Me.Primo.Tag = "Primo"
      Me.Primo.ToolTipText = "Prima pagina"
      Me.Primo.Visible = False
      '
      'Precedente
      '
      Me.Precedente.ImageIndex = 4
      Me.Precedente.Name = "Precedente"
      Me.Precedente.Tag = "Precedente"
      Me.Precedente.ToolTipText = "Pagina precedente "
      Me.Precedente.Visible = False
      '
      'Successivo
      '
      Me.Successivo.ImageIndex = 5
      Me.Successivo.Name = "Successivo"
      Me.Successivo.Tag = "Successivo"
      Me.Successivo.ToolTipText = "Pagina successiva"
      Me.Successivo.Visible = False
      '
      'Ultimo
      '
      Me.Ultimo.ImageIndex = 6
      Me.Ultimo.Name = "Ultimo"
      Me.Ultimo.Tag = "Ultimo"
      Me.Ultimo.ToolTipText = "Ultima pagina"
      Me.Ultimo.Visible = False
      '
      'tbrAggiorna
      '
      Me.tbrAggiorna.ImageIndex = 7
      Me.tbrAggiorna.Name = "tbrAggiorna"
      Me.tbrAggiorna.Tag = "Aggiorna"
      Me.tbrAggiorna.ToolTipText = "Aggiorna"
      '
      'ToolBarButton1
      '
      Me.ToolBarButton1.Name = "ToolBarButton1"
      Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbrAnteprima
      '
      Me.tbrAnteprima.ImageIndex = 8
      Me.tbrAnteprima.Name = "tbrAnteprima"
      Me.tbrAnteprima.Tag = "Anteprima"
      Me.tbrAnteprima.ToolTipText = "Anteprima di stampa"
      '
      'tbrStampa
      '
      Me.tbrStampa.ImageIndex = 9
      Me.tbrStampa.Name = "tbrStampa"
      Me.tbrStampa.Tag = "Stampa"
      Me.tbrStampa.ToolTipText = "Stampa"
      '
      'tbrInserisci
      '
      Me.tbrInserisci.Name = "tbrInserisci"
      Me.tbrInserisci.Tag = ""
      Me.tbrInserisci.Visible = False
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
      Me.DataGrid1.Location = New System.Drawing.Point(0, 56)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(864, 254)
      Me.DataGrid1.TabIndex = 0
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.dtpAl)
      Me.Panel1.Controls.Add(Me.dtpDal)
      Me.Panel1.Controls.Add(Me.lblAl)
      Me.Panel1.Controls.Add(Me.lblDal)
      Me.Panel1.Controls.Add(Me.CampoRicerca)
      Me.Panel1.Controls.Add(Me.lblCampo)
      Me.Panel1.Controls.Add(Me.lblTesto)
      Me.Panel1.Controls.Add(Me.TestoRicerca)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(864, 30)
      Me.Panel1.TabIndex = 0
      '
      'dtpAl
      '
      Me.dtpAl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpAl.Location = New System.Drawing.Point(680, 40)
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
      Me.dtpDal.Location = New System.Drawing.Point(464, 40)
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
      Me.lblAl.Location = New System.Drawing.Point(656, 40)
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
      Me.lblDal.Location = New System.Drawing.Point(432, 40)
      Me.lblDal.Name = "lblDal"
      Me.lblDal.Size = New System.Drawing.Size(33, 15)
      Me.lblDal.TabIndex = 55671
      Me.lblDal.Tag = ""
      Me.lblDal.Text = "Dal:"
      Me.lblDal.Visible = False
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(722, 8)
      Me.CampoRicerca.Name = "CampoRicerca"
      Me.CampoRicerca.Size = New System.Drawing.Size(136, 21)
      Me.CampoRicerca.TabIndex = 1
      '
      'lblCampo
      '
      Me.lblCampo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCampo.AutoSize = True
      Me.lblCampo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCampo.ForeColor = System.Drawing.Color.White
      Me.lblCampo.Location = New System.Drawing.Point(640, 8)
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
      'TestoRicerca
      '
      Me.TestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TestoRicerca.Location = New System.Drawing.Point(112, 8)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(519, 20)
      Me.TestoRicerca.TabIndex = 0
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
      Me.Panel2.Controls.Add(Me.txtBuoni)
      Me.Panel2.Controls.Add(Me.Label1)
      Me.Panel2.Controls.Add(Me.txtSospeso)
      Me.Panel2.Controls.Add(Me.Label3)
      Me.Panel2.Controls.Add(Me.txtTotImporto)
      Me.Panel2.Controls.Add(Me.Label6)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 310)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(864, 32)
      Me.Panel2.TabIndex = 13
      '
      'txtBuoni
      '
      Me.txtBuoni.AcceptsReturn = True
      Me.txtBuoni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBuoni.BackColor = System.Drawing.SystemColors.Window
      Me.txtBuoni.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtBuoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBuoni.ForeColor = System.Drawing.Color.Red
      Me.txtBuoni.Location = New System.Drawing.Point(744, 7)
      Me.txtBuoni.MaxLength = 0
      Me.txtBuoni.Name = "txtBuoni"
      Me.txtBuoni.ReadOnly = True
      Me.txtBuoni.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtBuoni.Size = New System.Drawing.Size(112, 20)
      Me.txtBuoni.TabIndex = 2
      Me.txtBuoni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.White
      Me.Label1.Location = New System.Drawing.Point(664, 7)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(87, 15)
      Me.Label1.TabIndex = 238
      Me.Label1.Text = "Buoni pasto:"
      '
      'txtSospeso
      '
      Me.txtSospeso.AcceptsReturn = True
      Me.txtSospeso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSospeso.BackColor = System.Drawing.SystemColors.Window
      Me.txtSospeso.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtSospeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSospeso.ForeColor = System.Drawing.Color.Red
      Me.txtSospeso.Location = New System.Drawing.Point(544, 8)
      Me.txtSospeso.MaxLength = 0
      Me.txtSospeso.Name = "txtSospeso"
      Me.txtSospeso.ReadOnly = True
      Me.txtSospeso.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSospeso.Size = New System.Drawing.Size(112, 20)
      Me.txtSospeso.TabIndex = 1
      Me.txtSospeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.White
      Me.Label3.Location = New System.Drawing.Point(480, 8)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(66, 15)
      Me.Label3.TabIndex = 236
      Me.Label3.Text = "Sospeso:"
      '
      'txtTotImporto
      '
      Me.txtTotImporto.AcceptsReturn = True
      Me.txtTotImporto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotImporto.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotImporto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotImporto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotImporto.ForeColor = System.Drawing.Color.Red
      Me.txtTotImporto.Location = New System.Drawing.Point(360, 8)
      Me.txtTotImporto.MaxLength = 0
      Me.txtTotImporto.Name = "txtTotImporto"
      Me.txtTotImporto.ReadOnly = True
      Me.txtTotImporto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotImporto.Size = New System.Drawing.Size(112, 20)
      Me.txtTotImporto.TabIndex = 0
      Me.txtTotImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.White
      Me.Label6.Location = New System.Drawing.Point(312, 8)
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
      Me.ClientSize = New System.Drawing.Size(864, 342)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoDoc"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco Documenti"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Scarico ingredienti"

   Private Function SalvaDati(ByVal tabella As String, ByVal id As Integer, ByVal giacenza As Double, _
                              ByVal carico As Double, ByVal scarico As Double, _
                              ByVal situazione As Double, ByVal prezzo As String, _
                              ByVal valCarico As Double, ByVal valScarico As Double, ByVal valAttuale As Double) As Boolean

      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET Giacenza = @Giacenza, " & _
                             "Carico = @Carico, " & _
                             "Scarico = @Scarico, " & _
                             "SituazioneScorta = @SituazioneScorta, " & _
                             "ValCarico = @ValCarico, " & _
                             "valScarico = @ValScarico, " & _
                             "ValAttuale = @ValAttuale, " & _
                             "PrezzoAcquisto = @Prezzo " & _
                             "WHERE Id = {1}", _
                              tabella, _
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

   Private Function SalvaMovimentiMag(ByVal tabella As String, ByVal id_Articolo As Integer, ByVal data As String, _
                                      ByVal codice As String, ByVal descrizione As String, _
                                      ByVal carico As Double, ByVal scarico As Double, _
                                      ByVal causale As String, ByVal prezzo As String, _
                                      ByVal fornitore As String, ByVal magazzino As String) As Boolean

      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Id_Articolo, Data, Codice, Descrizione, PrezzoAcquisto, " & _
                                              "Carico, Scarico, Causale, Fornitore, Magazzino) " & _
                                       "VALUES(@Id_Articolo, @Data, @Codice, @Descrizione, @PrezzoAcquisto, " & _
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
               SalvaDati("Articoli", idArticolo, nuovaGiacenza, _
                          Carico, Scarico, situazioneScorta, AArticoli.PrezzoAcquisto, _
                          valCarico, valScarico, valAttuale)

               ' Verifica se Ë un carico o scarico.
               Dim qt‡Caricata As Double = 0
               Dim qt‡Scaricata As Double = 0
               qt‡Scaricata = 0
               qt‡Caricata = qt‡Carico

               Dim data As Date = Now.Today

               ' Salva i dati per i movimenti di magazzino.
               SalvaMovimentiMag("MovMagazzino", idArticolo, data.ToShortDateString, AArticoli.Codice, AArticoli.Descrizione, _
                                  qt‡Caricata, qt‡Scaricata, CausaleMovMag, AArticoli.PrezzoAcquisto, _
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
                  tbrAnnulla.Enabled = False
                  tbrSospeso.Enabled = False
                  tbrPassaSospeso.Enabled = False
                  tbrAnnullaSospeso.Enabled = False
                  tbrBuoni.Enabled = False
                  tbrModifica.Enabled = False
                  tbrAggiorna.Enabled = False
               Else
                  tbrAnnulla.Enabled = True
                  tbrSospeso.Enabled = True
                  tbrPassaSospeso.Enabled = True
                  tbrAnnullaSospeso.Enabled = True
                  tbrBuoni.Enabled = True
                  tbrModifica.Enabled = True
                  tbrAggiorna.Enabled = True
               End If

         End Select

         Return tbrModifica.Enabled

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
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0}", tabella)
         numRecord = CInt(cmd.ExecuteScalar())

         ' Chiude la connessione se Ë da chiudere.
         If closeOnExit Then cn.Close()

         If TestoRicerca.Text <> "" Then
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
         Primo.Enabled = (n > 1)
         Precedente.Enabled = (n > 1)
         Successivo.Enabled = (n < numPagine)
         Ultimo.Enabled = (n < numPagine)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Public Sub EliminaDati(ByVal tabella As String, ByVal id As Integer)
      ' NON UTILIZZATA.
      'Try
      '   Dim Risposta As Short
      '   Dim sql As String

      '   Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
      '   Dim Documento As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)
      '   Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

      '   ' Chiede conferma per l'eliminazione.
      '   Risposta = MsgBox("Si desidera eliminare il documento """ & Documento & " n. " & Numero & " del " & Data & """?" & _
      '                     vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

      '   If Risposta = MsgBoxResult.Yes Then
      '      ' Apre la connessione.
      '      cn.Open()

      '      ' Avvia una transazione.
      '      tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

      '      ' Crea la stringa di eliminazione.
      '      sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)

      '      ' Crea il comando per la connessione corrente.
      '      Dim cmdDelete As New OleDbCommand(sql, cn, tr)

      '      ' Esegue il comando.
      '      Dim Record As Integer = cmdDelete.ExecuteNonQuery()

      '      ' A_TODO: Modifica per Retail.
      '      '--------------------------------------------------------------------------
      '      ' Elimina i dati dei dettaglie relativi al documento.
      '      ' Crea la stringa di eliminazione.
      '      sql = String.Format("DELETE FROM DettagliDoc WHERE RifDoc = {0}", id)

      '      ' Crea il comando per la connessione corrente.
      '      Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)

      '      ' Esegue il comando.
      '      Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
      '      '--------------------------------------------------------------------------

      '   ' Conferma la transazione.
      '   tr.Commit()

      '   End If

      'Catch ex As Exception
      '   ' Annulla la transazione.
      '   tr.Rollback()

      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   ' Chiude la connessione.
      '   cn.Close()

      '   If tbrSospesi.Pushed = True Then
      '      ' Aggiorna la griglia dati.
      '      AggiornaDatiSospesi()
      '   ElseIf tbrMese.Pushed = True Then
      '      ' Aggiorna la griglia dati.
      '      AggiornaDatiMese()
      '   ElseIf tbrAnno.Pushed = True Then
      '      ' Aggiorna la griglia dati.
      '      AggiornaDatiAnno()
      '   ElseIf tbrPeriodo.Pushed = True Then
      '      ' Aggiorna la griglia dati.
      '      AggiornaDatiPeriodo()
      '   Else
      '      ' Aggiorna la griglia dati.
      '      AggiornaDati()
      '   End If

      '   ' Se nella tabella non ci sono record disattiva i pulsanti.
      '   ConvalidaDati()
      'End Try
   End Sub

   Public Sub AggiornaDati()
      Try
         If TestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_DOCUMENTI)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            Select Case filtroDati
               Case "Tutti"
                  ' Filtra i dati in base al testo digitato.
                  FiltraDati(TestoRicerca.Text, CampoRicerca.Text)

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

   Private Sub VisualizzaDate()
      lblAl.Location = New Point(lblAl.Location.X, 8)
      lblDal.Location = New Point(lblDal.Location.X, 8)
      dtpAl.Location = New Point(dtpAl.Location.X, 8)
      dtpDal.Location = New Point(dtpDal.Location.X, 8)
      lblAl.Visible = True
      lblDal.Visible = True
      dtpAl.Visible = True
      dtpDal.Visible = True

      lblTesto.Visible = False
      lblCampo.Visible = False
      TestoRicerca.Visible = False
      CampoRicerca.Visible = False
   End Sub

   Private Sub NascondiDate()
      lblAl.Visible = False
      lblDal.Visible = False
      dtpAl.Visible = False
      dtpDal.Visible = False

      lblTesto.Visible = True
      lblCampo.Visible = True
      TestoRicerca.Visible = True
      CampoRicerca.Visible = True
   End Sub

   Public Sub AggiornaDatiSospesi()
      Try
         ' Crea la stringa di selezione dei dati..
         sql = String.Format("SELECT TOP {0} * FROM {1} WHERE SospesoIncassare <> 0 ORDER BY DataDoc", DIM_PAGINA_GRANDE, TAB_DOCUMENTI)
         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Attiva/disattiva il pulsanti per i sospesi.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()

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
         ' Crea la stringa di selezione dei dati.
         Dim Appo1 As String = CFormatta.FormattaData(dtpDal.Text)
         Dim Appo2 As String = CFormatta.FormattaData(dtpAl.Text)
         sql = String.Format("SELECT TOP {0} * FROM {1} WHERE DataDoc BETWEEN #{2}# AND #{3}# ORDER BY DataDoc ASC", DIM_PAGINA_GRANDE, TAB_DOCUMENTI, Appo1, Appo2)
         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Attiva/disattiva il pulsanti per i sospesi.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()

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

   Public Sub AggiornaDatiMese()
      Try
         ' Crea la stringa di selezione dei dati.
         Dim Anno As String = Year(Now)
         Dim Mese As String = Month(Now)
         Dim Appo1 As String = CFormatta.FormattaData("01/" & Mese & "/" & Anno)
         Dim UltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, Mese)
         Dim Appo2 As String = CFormatta.FormattaData(UltimoGiornoAnno & "/" & Mese & "/" & Anno)
         sql = String.Format("SELECT TOP {0} * FROM {1} WHERE DataDoc BETWEEN #{2}# AND #{3}# ORDER BY DataDoc ASC", DIM_PAGINA_GRANDE, TAB_DOCUMENTI, Appo1, Appo2)

         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Attiva/disattiva il pulsanti per i sospesi.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()

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
         sql = String.Format("SELECT TOP {0} * FROM {1} WHERE DataDoc BETWEEN #{2}# AND #{3}# ORDER BY DataDoc ASC", DIM_PAGINA_GRANDE, TAB_DOCUMENTI, Appo1, Appo2)

         repSql = sql
         LeggiDati("(" & sql & ")", sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Attiva/disattiva il pulsanti per i sospesi.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()

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
      Dim importo As Decimal = SommaColonna(DataGrid1, COLONNA_IMPORTO_TOTALE, numRecord)
      Dim sospeso As Decimal = SommaColonna(DataGrid1, COLONNA_IMPORTO_SOSPESO, numRecord)
      Dim buoni As Decimal = SommaColonna(DataGrid1, COLONNA_IMPORTO_BUONI, numRecord)

      ' Sottrae dal totale dei documenti i valori sospesi e i buoni non fatturati.
      Dim totImporto As Decimal = importo - sospeso - buoni

      ' Somma i valori della colonna Totale.
      txtTotImporto.Text = CFormatta.FormattaEuro(totImporto)
      ' Somma i valori della colonna Sospeso.
      txtSospeso.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO_SOSPESO_INC, numRecord))
      ' Somma i valori della colonna Buoni pasto.
      txtBuoni.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO_BUONI_INC, numRecord))
   End Sub

   Public Sub ImpostaComandi()
      If numRecord = 0 Then
         ' Disattiva i pulsanti appropriati.
         tbrAnnulla.Enabled = False
         'tbrSospesi.Enabled = False
         tbrSospeso.Enabled = False
         tbrPassaSospeso.Enabled = False
         tbrAnnullaSospeso.Enabled = False
         tbrBuoni.Enabled = False
         tbrAggiorna.Enabled = False
         tbrModifica.Enabled = False
         'Elimina.Enabled = False
         'Primo.Enabled = False
         'Precedente.Enabled = False
         'Successivo.Enabled = False
         'Ultimo.Enabled = False
      Else
         ' Attiva i pulsanti appropriati.
         tbrAnnulla.Enabled = True
         'tbrSospesi.Enabled = True
         tbrSospeso.Enabled = False
         tbrPassaSospeso.Enabled = True
         tbrAnnullaSospeso.Enabled = True
         tbrBuoni.Enabled = True
         tbrAggiorna.Enabled = True
         tbrModifica.Enabled = True
         'Elimina.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      If ImpostaFunzioniOperatore(Finestra.Documenti) = True Then
         ImpostaComandi()
      End If
   End Sub

   Private Sub ApriDati(ByVal val As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se Ë un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(TAB_DOCUMENTI)) = True Then
                  Exit Sub
               End If
            End If
         End If

         Dim frm As New frmAcquisti
         frm.Tag = val
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5) & " - " & _
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4) & " n. " & _
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & " del " & _
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
         If tbrModifica.Enabled = True Then
            If numRecord <> 0 Then
               ' Attiva/disattiva il pulsante per l'incasso dei sospesi.
               If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_SOSPESO_INC) = VALORE_ZERO Then
                  tbrSospeso.Enabled = False
               Else
                  tbrSospeso.Enabled = True
               End If
            Else
               tbrSospeso.Enabled = False
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AttivaDisattivaAnnullaSospeso()
      Try
         If tbrModifica.Enabled = True Then
            If numRecord <> 0 Then
               ' Attiva/disattiva il pulsante per l'incasso dei sospesi.
               If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_SOSPESO_INC) = VALORE_ZERO Then
                  tbrAnnullaSospeso.Enabled = False
               Else
                  tbrAnnullaSospeso.Enabled = True
               End If
            Else
               tbrAnnullaSospeso.Enabled = False
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AttivaDisattivaPassaSospeso()
      Try
         If tbrModifica.Enabled = True Then
            If numRecord <> 0 Then
               ' Attiva/disattiva il pulsante per l'incasso dei sospesi.
               If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_TOTALE) = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_SOSPESO_INC) Then
                  tbrPassaSospeso.Enabled = False
               Else
                  tbrPassaSospeso.Enabled = True
               End If
            Else
               tbrPassaSospeso.Enabled = False
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AttivaDisattivaBuoni()
      Try
         If tbrModifica.Enabled = True Then
            If numRecord <> 0 Then
               ' Attiva/disattiva il pulsante per visualizzare l'elenco dei Buoni pasto.
               If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_IMPORTO_BUONI_INC) = VALORE_ZERO Then
                  tbrBuoni.Enabled = False
               Else
                  tbrBuoni.Enabled = True
               End If
            Else
               tbrBuoni.Enabled = False
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AttivaDisattivaAnnullaDoc()
      Try
         If tbrModifica.Enabled = True Then
            If numRecord <> 0 Then

               Dim tipoDoc As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_TIPO_DOC)
               Dim ultimoNumeroDoc As Integer = LeggiNumeroMax(TAB_DOCUMENTI, tipoDoc)

               ' Attiva/disattiva il pulsante per annullare un documento.
               If DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, COLONNA_NUMERO_DOC) <> ultimoNumeroDoc Then
                  tbrAnnulla.Enabled = False
               Else
                  tbrAnnulla.Enabled = True
               End If
            Else
               tbrAnnulla.Enabled = False
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AnnullaDocumento()
      Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
      Dim Documento As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)
      Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
      Dim Importo As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7)

      ' Chiede conferma per l'eliminazione.
      Dim risposta As Integer
      risposta = MessageBox.Show("Si desidera eliminare il documento """ & Documento & " n. " & Numero & " del " & Data & """? " & _
                                 "Confermando l'operazione verr‡ eliminato il documento, verranno ripristinati i valori per le " & _
                                 "giacenze di magazzino degli Articoli e le Statistiche di vendita. Eventuali Buoni pasto contenuti " & _
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

         EliminaDettagliDocumento()
         EliminaDocumento()

         ' Registra loperazione effettuata dall'operatore identificato.
         Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - Ä " & CFormatta.FormattaEuro(Importo) & ")"
         g_frmMain.RegistraOperazione(TipoOperazione.AnnullaDoc, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

      End If
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

         ' Id - Codice
         Dim codiceStyle As New DataGridTextBoxColumn
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 0
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Numero documento
         Dim numeroStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         numeroStyle.MappingName = "NumDoc"
         numeroStyle.HeaderText = "Numero"
         numeroStyle.Width = 50
         numeroStyle.NullText = ""
         numeroStyle.Format = "##,##0"
         numeroStyle.Alignment = HorizontalAlignment.Right
         numeroStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(numeroStyle)
         ' Data documento
         Dim dataStyle As New DataGridTextBoxColumn
         dataStyle.MappingName = "DataDoc"
         dataStyle.HeaderText = "Data"
         dataStyle.Width = 75
         dataStyle.NullText = ""
         dataStyle.Alignment = HorizontalAlignment.Center
         dataStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataStyle)
         ' Ora documento
         Dim oraStyle As New DataGridTextBoxColumn
         oraStyle.MappingName = "OraDoc"
         oraStyle.HeaderText = "Ora"
         oraStyle.Width = 50
         oraStyle.NullText = ""
         oraStyle.Alignment = HorizontalAlignment.Center
         oraStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraStyle)
         ' Documento
         Dim documentoStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         documentoStyle.MappingName = "TipoDoc"
         documentoStyle.HeaderText = "Tipo documento"
         documentoStyle.Width = 150
         documentoStyle.NullText = ""
         documentoStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(documentoStyle)
         ' Cliente
         Dim clienteStyle As New DataGridTextBoxColumn
         clienteStyle.MappingName = "Cliente"
         clienteStyle.HeaderText = "Intestatario"
         clienteStyle.Width = 150
         clienteStyle.NullText = ""
         clienteStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(clienteStyle)
         ' Tavolo
         Dim tavoloStyle As New DataGridTextBoxColumn
         tavoloStyle.MappingName = "Tavolo"
         tavoloStyle.HeaderText = "Tavolo"
         tavoloStyle.Width = 70
         tavoloStyle.NullText = ""
         tavoloStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tavoloStyle)
         ' Totale documento
         Dim totDocStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         totDocStyle.MappingName = "TotDoc"
         totDocStyle.HeaderText = "Totale"
         totDocStyle.Width = 80
         totDocStyle.NullText = ""
         totDocStyle.Format = "##,##0.00"
         totDocStyle.Alignment = HorizontalAlignment.Right
         totDocStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(totDocStyle)
         ' Sospeso
         Dim sospesoStyle As New DataGridTextBoxColumn
         sospesoStyle.MappingName = "Sospeso"
         sospesoStyle.HeaderText = "Sospeso"
         sospesoStyle.Width = 80
         sospesoStyle.NullText = ""
         sospesoStyle.Format = "##,##0.00"
         sospesoStyle.Alignment = HorizontalAlignment.Right
         sospesoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(sospesoStyle)
         ' Imponibile
         Dim imponibileStyle As New DataGridTextBoxColumn
         imponibileStyle.MappingName = "Imponibile"
         imponibileStyle.HeaderText = "Imponibile"
         imponibileStyle.Width = 80
         imponibileStyle.NullText = ""
         imponibileStyle.Format = "##,##0.00"
         imponibileStyle.Alignment = HorizontalAlignment.Right
         imponibileStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(imponibileStyle)
         'Imposta
         Dim impostaStyle As New DataGridTextBoxColumn
         impostaStyle.MappingName = "Imposta"
         impostaStyle.HeaderText = "IVA"
         impostaStyle.Width = 80
         impostaStyle.NullText = ""
         impostaStyle.Format = "##,##0.00"
         impostaStyle.Alignment = HorizontalAlignment.Right
         impostaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(impostaStyle)
         ' Buoni pasto
         Dim buoniStyle As New DataGridTextBoxColumn
         buoniStyle.MappingName = "BuoniPasto"
         buoniStyle.HeaderText = "Buoni pasto"
         buoniStyle.Width = 80
         buoniStyle.NullText = ""
         buoniStyle.Format = "##,##0.00"
         buoniStyle.Alignment = HorizontalAlignment.Right
         buoniStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(buoniStyle)
         ' Tipo pagamento
         Dim tipoPagStyle As New DataGridTextBoxColumn
         tipoPagStyle.MappingName = "TipoPagamento"
         tipoPagStyle.HeaderText = "Tipo pagamento"
         tipoPagStyle.Width = 100
         tipoPagStyle.NullText = ""
         tipoPagStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tipoPagStyle)
         ' Cameriere
         Dim cameriereStyle As New DataGridTextBoxColumn
         cameriereStyle.MappingName = "Cameriere"
         cameriereStyle.HeaderText = "Cameriere"
         cameriereStyle.Width = 150
         cameriereStyle.NullText = ""
         cameriereStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(cameriereStyle)
         ' Sospeso da incassare
         Dim sospesoIncStyle As New DataGridTextBoxColumn
         sospesoIncStyle.MappingName = "SospesoIncassare"
         sospesoIncStyle.HeaderText = ""
         sospesoIncStyle.Width = 0
         sospesoIncStyle.NullText = ""
         'sospesoIncStyle.Format = "##,##0.00"
         sospesoIncStyle.Alignment = HorizontalAlignment.Right
         sospesoIncStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(sospesoIncStyle)
         ' Buoni pasto da incassare
         Dim buoniIncStyle As New DataGridTextBoxColumn
         buoniIncStyle.MappingName = "BuoniPastoIncassare"
         buoniIncStyle.HeaderText = ""
         buoniIncStyle.Width = 0
         buoniIncStyle.NullText = ""
         'buoniIncStyle.Format = "##,##0.00"
         buoniIncStyle.Alignment = HorizontalAlignment.Right
         buoniIncStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(buoniIncStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FiltraDati(ByVal testoRicerca As String, ByVal campoRicerca As String)
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
            Case "Totale"
               campoRicerca = "TotDoc"
            Case "Buoni pasto"
               campoRicerca = "BuoniPasto"
            Case "Tipo pagamento"
               campoRicerca = "TipoPagamento"
            Case "IVA"
               campoRicerca = "Imposta"
         End Select

         If testoRicerca <> "" Then
            tbrTutti.Pushed = False
            tbrPeriodo.Pushed = False
            tbrMese.Pushed = False
            tbrAnno.Pushed = False
            tbrSospesi.Pushed = False

            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_DOCUMENTI, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_DOCUMENTI, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            tbrTutti.Pushed = True
            tbrPeriodo.Pushed = False
            tbrMese.Pushed = False
            tbrAnno.Pushed = False
            tbrSospesi.Pushed = False

            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY DataDoc ASC", DIM_PAGINA_GRANDE, TAB_DOCUMENTI)
            repSql = String.Format("SELECT * FROM {0} ORDER BY DataDoc ASC", TAB_DOCUMENTI)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_DOCUMENTI, sql)
         End If

         ' Somma i valori della colonna Importo.
         SommaImporti()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Attiva/disattiva il pulsanti per i sospesi.
         AttivaDisattivaSospeso()
         AttivaDisattivaPassaSospeso()
         AttivaDisattivaAnnullaSospeso()

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
         CampoRicerca.Items.Add("Numero")
         CampoRicerca.Items.Add("Data")
         CampoRicerca.Items.Add("Ora")
         CampoRicerca.Items.Add("Tipo documento")
         CampoRicerca.Items.Add("Intestatario")
         CampoRicerca.Items.Add("Tavolo")
         CampoRicerca.Items.Add("Totale")
         CampoRicerca.Items.Add("Sospeso")
         CampoRicerca.Items.Add("Imponibile")
         CampoRicerca.Items.Add("IVA")
         CampoRicerca.Items.Add("Buoni pasto")
         CampoRicerca.Items.Add("Tipo pagamento")
         CampoRicerca.Items.Add("Cameriere")

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

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
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

            rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True, _
                               PrintDialog1.PrinterSettings.FromPage, _
                               PrintDialog1.PrinterSettings.ToPage)

            cn.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub PassaSospeso(ByVal id As Integer, ByVal totale As String)
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

            Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
            Dim Documento As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)
            Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
            Dim Importo As String = CFormatta.FormattaEuro(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7))

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - Ä " & Importo & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.PassaSospeso, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

            If tbrSospesi.Pushed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiSospesi()
               Exit Sub
            ElseIf tbrMese.Pushed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiMese()
               Exit Sub
            ElseIf tbrAnno.Pushed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiAnno()
               Exit Sub
            ElseIf tbrPeriodo.Pushed = True Then
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

   Private Sub AnnullaSospeso(ByVal id As Integer)
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

            Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2)
            Dim Documento As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)
            Dim Numero As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
            Dim Importo As String = CFormatta.FormattaEuro(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7))

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & Documento & " n. " & Numero & " del " & Data & " - Ä " & Importo & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.AnnullaSospeso, strDescrizione, MODULO_CONTABILITA_DOCUMENTI)

            If tbrSospesi.Pushed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiSospesi()
               Exit Sub
            ElseIf tbrMese.Pushed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiMese()
               Exit Sub
            ElseIf tbrAnno.Pushed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiAnno()
               Exit Sub
            ElseIf tbrPeriodo.Pushed = True Then
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

   Private Sub ApriElencoBuoni()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ConnStringAnagrafiche = CreaConnString(PercorsoDB)

         Dim frm As New ElencoBuoni

         ' Visualizza l'anagrafica clienti.
         frm.Tag = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)
         frm.ShowDialog()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

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
         CampoRicerca.SelectedIndex = 0

         Select Case filtroDati
            Case "Tutti"
               tbrTutti.Pushed = True
               tbrPeriodo.Pushed = False
               tbrMese.Pushed = False
               tbrAnno.Pushed = False
               tbrSospesi.Pushed = False
               NascondiDate()
               ' Filtra i dati in base al testo digitato.
               FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
            Case "Mese"
               tbrMese.Pushed = True
               tbrTutti.Pushed = False
               tbrPeriodo.Pushed = False
               tbrAnno.Pushed = False
               tbrSospesi.Pushed = False
               NascondiDate()
               ' Aggiorna la griglia dati.
               AggiornaDatiMese()
            Case "Anno"
               tbrAnno.Pushed = True
               tbrTutti.Pushed = False
               tbrPeriodo.Pushed = False
               tbrMese.Pushed = False
               tbrSospesi.Pushed = False
               NascondiDate()
               ' Aggiorna la griglia dati.
               AggiornaDatiAnno()
            Case "Periodo"
               tbrPeriodo.Pushed = True
               tbrTutti.Pushed = False
               tbrMese.Pushed = False
               tbrAnno.Pushed = False
               tbrSospesi.Pushed = False
               VisualizzaDate()
               ' Aggiorna la griglia dati.
               AggiornaDatiPeriodo()
            Case "Sospesi"
               tbrSospesi.Pushed = True
               tbrTutti.Pushed = False
               tbrMese.Pushed = False
               tbrAnno.Pushed = False
               tbrPeriodo.Pushed = False
               NascondiDate()
               ' Aggiorna la griglia dati.
               AggiornaDatiSospesi()
         End Select

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         If tbrModifica.Enabled = True Then
            ' Attiva/disattiva il pulsante per annullare un documento.
            AttivaDisattivaAnnullaDoc()

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

   Private Sub ElencoDoc_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
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

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()

      ' Attiva/disattiva il pulsante per annullare un documento.
      AttivaDisattivaAnnullaDoc()

      ' Attiva/disattiva i pulsanti per i sospesi.
      AttivaDisattivaSospeso()
      AttivaDisattivaPassaSospeso()
      AttivaDisattivaAnnullaSospeso()

      ' Attiva/Disattiva il pulsante per i Buoni.
      AttivaDisattivaBuoni()
   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag
         Case "Tutti"
            tbrPeriodo.Pushed = False
            tbrMese.Pushed = False
            tbrAnno.Pushed = False
            tbrSospesi.Pushed = False
            filtroDati = "Tutti"
            NascondiDate()
            TestoRicerca.Text = ""
            ' Filtra i dati in base al testo digitato.
            FiltraDati(TestoRicerca.Text, CampoRicerca.Text)

         Case "Sospesi"
            tbrTutti.Pushed = False
            tbrPeriodo.Pushed = False
            tbrMese.Pushed = False
            tbrAnno.Pushed = False
            filtroDati = "Sospesi"
            NascondiDate()
            TestoRicerca.Text = ""
            AggiornaDatiSospesi()

         Case "Periodo"
            tbrTutti.Pushed = False
            tbrMese.Pushed = False
            tbrAnno.Pushed = False
            tbrSospesi.Pushed = False
            filtroDati = "Periodo"
            VisualizzaDate()
            TestoRicerca.Text = ""
            AggiornaDatiPeriodo()

         Case "Mese"
            tbrTutti.Pushed = False
            tbrPeriodo.Pushed = False
            tbrAnno.Pushed = False
            tbrSospesi.Pushed = False
            filtroDati = "Mese"
            NascondiDate()
            TestoRicerca.Text = ""
            AggiornaDatiMese()

         Case "Anno"
            tbrTutti.Pushed = False
            tbrPeriodo.Pushed = False
            tbrMese.Pushed = False
            tbrSospesi.Pushed = False
            filtroDati = "Anno"
            NascondiDate()
            TestoRicerca.Text = ""
            AggiornaDatiAnno()

         Case "Annulla"
            ' Annulla l'ultimo documento selezionato.
            AnnullaDocumento()

         Case "Nuovo"
            '' Apre la finestra per l'inserimento di nuovi dati.
            'ApriDati("")

            '' Se nella tabella non ci sono record disattiva i pulsanti.
            'ConvalidaDati()

         Case "Modifica"
            '' Apre la finestra per l'inserimento di nuovi dati.
            'ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))

         Case "Elimina"
            ' NON UTILIZZATA.
            ' Elimina il valore selezionato.
            'EliminaDati(TAB_DOCUMENTI, DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))

         Case "Buoni"
            ' Apre l'elenco dei buoni contenuti nel documento selezionato.
            ApriElencoBuoni()

         Case "Sospeso"
            ' Apre la finestra per l'incasso del sospeso.
            Dim frm As New IncassaSospeso(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0), _
                                          DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1), _
                                          DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2), _
                                          DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4), _
                                          DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5), _
                                          DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8))
            frm.ShowDialog()

         Case "PassaSospeso"
            ' Apre la finestra per l'incasso del sospeso.
            PassaSospeso(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0), _
                         DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7))

         Case "AnnullaSospeso"
            ' Apre la finestra per l'incasso del sospeso.
            AnnullaSospeso(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))

         Case "Stampa"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Stampa, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

            StampaDocumento(PERCORSO_REP_DOC, TAB_DOCUMENTI, repSql)

         Case "Anteprima"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

            g_frmMain.ApriReports(repSql, TAB_DOCUMENTI, PERCORSO_REP_DOC)

         Case "Primo"
            '' Crea la stringa sql.
            'sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", dimPagina, TAB_ACQUISTI)

            '' Visualizza la prima pagina di dati.
            'VisualizzaPagina(1, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Precedente"
            '' Crea la stringa sql.
            'sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} WHERE Id < {3} ORDER BY Id DESC) ORDER BY Id", TAB_ACQUISTI, dimPagina, TAB_ACQUISTI, dt.Rows(0)("Id"))

            '' Visualizza la pagina di dati precedente.
            'VisualizzaPagina(pagCorrente - 1, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Successivo"
            '' Crea la stringa sql.
            'sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Id > {2} ORDER BY Id", dimPagina, TAB_ACQUISTI, dt.Rows(dt.Rows.Count - 1)("Id"))

            '' Visualizza la pagina di dati successiva.
            'VisualizzaPagina(pagCorrente + 1, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Ultimo"
            'Dim num As Integer = numRecord - dimPagina * (numPagine - 1)

            '' Crea la stringa sql.
            'sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} ORDER BY Id DESC) ORDER BY Id", TAB_ACQUISTI, num, TAB_ACQUISTI)

            '' Visualizza l'ultima pagina di dati.
            'VisualizzaPagina(numPagine, sql)

            '' Visualizza un'intestazione per la griglia dati.
            'AggIntGriglia()

         Case "Aggiorna"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

            If tbrSospesi.Pushed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiSospesi()
               Exit Sub
            ElseIf tbrMese.Pushed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiMese()
               Exit Sub
            ElseIf tbrAnno.Pushed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiAnno()
               Exit Sub
            ElseIf tbrPeriodo.Pushed = True Then
               ' Aggiorna la griglia dati.
               AggiornaDatiPeriodo()
               Exit Sub
            Else
               ' Aggiorna la griglia dati.
               AggiornaDati()
               Exit Sub
            End If
      End Select
   End Sub

   Private Sub TestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestoRicerca.TextChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
   End Sub

   Private Sub CampoRicerca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CampoRicerca.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
   End Sub

   Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
      'If Modifica.Enabled = True Then
      '   ' Registra loperazione efettuata dall'operatore identificato.
      '   registraModifica()

      '   ' Apre la finestra Cliente per la modifica dei dati.
      '   ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))
      'End If
   End Sub

   Private Sub dtpDal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDal.ValueChanged
      AggiornaDatiPeriodo()
   End Sub

   Private Sub dtpAl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAl.ValueChanged
      AggiornaDatiPeriodo()
   End Sub
End Class
