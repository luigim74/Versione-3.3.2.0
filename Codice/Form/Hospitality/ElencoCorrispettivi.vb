' Nome form:            frmElencoDati
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 15/04/2006
' Descrizione:          Elenco dati riutilizzabile per tutte le anagrafiche.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class ElencoCorrispettivi
   Inherits System.Windows.Forms.Form

   Const TAB_CORRISPETTIVI As String = "Corrispettivi"
   Const TITOLO_FINESTRA As String = "Elenco Corrispettivi"
   Const COLONNA_FATTURE As Short = 3
   Const COLONNA_RICEVUTE As Short = 4
   Const COLONNA_SCONTRINI As Short = 5
   Const COLONNA_TOTALE As Short = 6
   Const COLONNA_INCASSATO As Short = 7
   Const COLONNA_NON_INCASSATO As Short = 8

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
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   Dim filtroDati As String


#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_CORRISPETTIVI)

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
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents ToolBarButton4 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Modifica As System.Windows.Forms.ToolBarButton
   Friend WithEvents Elimina As System.Windows.Forms.ToolBarButton
   Friend WithEvents Stampa As System.Windows.Forms.ToolBarButton
   Friend WithEvents Anteprima As System.Windows.Forms.ToolBarButton
   Friend WithEvents Primo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Precedente As System.Windows.Forms.ToolBarButton
   Friend WithEvents Successivo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Ultimo As System.Windows.Forms.ToolBarButton
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents Aggiorna As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton1 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents tbNuovo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Sep13 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Inserisci As System.Windows.Forms.ToolBarButton
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Public WithEvents txtTotImporto As System.Windows.Forms.TextBox
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents tbrTutti As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton2 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents txtNonIncassato As System.Windows.Forms.TextBox
   Public WithEvents txtIncassato As System.Windows.Forms.TextBox
   Public WithEvents txtRicevute As System.Windows.Forms.TextBox
   Public WithEvents txtScontrini As System.Windows.Forms.TextBox
   Public WithEvents txtFatture As System.Windows.Forms.TextBox
   Friend WithEvents lblAl As System.Windows.Forms.Label
   Friend WithEvents lblDal As System.Windows.Forms.Label
   Friend WithEvents dtpAl As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpDal As System.Windows.Forms.DateTimePicker
   Friend WithEvents tbrMese As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrAnno As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrPeriodo As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoCorrispettivi))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Modifica = New System.Windows.Forms.ToolBarButton()
      Me.Elimina = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton2 = New System.Windows.Forms.ToolBarButton()
      Me.tbrTutti = New System.Windows.Forms.ToolBarButton()
      Me.tbrMese = New System.Windows.Forms.ToolBarButton()
      Me.tbrAnno = New System.Windows.Forms.ToolBarButton()
      Me.tbrPeriodo = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
      Me.tbNuovo = New System.Windows.Forms.ToolBarButton()
      Me.Primo = New System.Windows.Forms.ToolBarButton()
      Me.Precedente = New System.Windows.Forms.ToolBarButton()
      Me.Successivo = New System.Windows.Forms.ToolBarButton()
      Me.Ultimo = New System.Windows.Forms.ToolBarButton()
      Me.Aggiorna = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
      Me.Anteprima = New System.Windows.Forms.ToolBarButton()
      Me.Stampa = New System.Windows.Forms.ToolBarButton()
      Me.Sep13 = New System.Windows.Forms.ToolBarButton()
      Me.Inserisci = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.dtpAl = New System.Windows.Forms.DateTimePicker()
      Me.dtpDal = New System.Windows.Forms.DateTimePicker()
      Me.lblAl = New System.Windows.Forms.Label()
      Me.lblDal = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.txtRicevute = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.txtScontrini = New System.Windows.Forms.TextBox()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.txtFatture = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.txtIncassato = New System.Windows.Forms.TextBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.txtNonIncassato = New System.Windows.Forms.TextBox()
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
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Modifica, Me.Elimina, Me.ToolBarButton2, Me.tbrTutti, Me.tbrMese, Me.tbrAnno, Me.tbrPeriodo, Me.ToolBarButton4, Me.tbNuovo, Me.Primo, Me.Precedente, Me.Successivo, Me.Ultimo, Me.Aggiorna, Me.ToolBarButton1, Me.Anteprima, Me.Stampa, Me.Sep13, Me.Inserisci})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(736, 26)
      Me.ToolBar1.TabIndex = 1
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Wrappable = False
      '
      'Modifica
      '
      Me.Modifica.ImageIndex = 1
      Me.Modifica.Name = "Modifica"
      Me.Modifica.Tag = "Modifica"
      Me.Modifica.Text = "Apri"
      Me.Modifica.ToolTipText = "Apri"
      '
      'Elimina
      '
      Me.Elimina.ImageIndex = 2
      Me.Elimina.Name = "Elimina"
      Me.Elimina.Tag = "Elimina"
      Me.Elimina.Text = "Elimina"
      Me.Elimina.ToolTipText = "Elimina"
      '
      'ToolBarButton2
      '
      Me.ToolBarButton2.Name = "ToolBarButton2"
      Me.ToolBarButton2.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbrTutti
      '
      Me.tbrTutti.ImageIndex = 13
      Me.tbrTutti.Name = "tbrTutti"
      Me.tbrTutti.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrTutti.Tag = "Tutti"
      Me.tbrTutti.Text = "Tutti"
      Me.tbrTutti.ToolTipText = "Visualizza tutti i corrispettivi"
      '
      'tbrMese
      '
      Me.tbrMese.ImageIndex = 14
      Me.tbrMese.Name = "tbrMese"
      Me.tbrMese.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrMese.Tag = "Mese"
      Me.tbrMese.Text = "Mese"
      Me.tbrMese.ToolTipText = "Visualizza i corrispettivi del mese in corso"
      '
      'tbrAnno
      '
      Me.tbrAnno.ImageIndex = 15
      Me.tbrAnno.Name = "tbrAnno"
      Me.tbrAnno.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrAnno.Tag = "Anno"
      Me.tbrAnno.Text = "Anno"
      Me.tbrAnno.ToolTipText = "Visualizza i corrispettivi dell'anno in corso"
      '
      'tbrPeriodo
      '
      Me.tbrPeriodo.ImageIndex = 16
      Me.tbrPeriodo.Name = "tbrPeriodo"
      Me.tbrPeriodo.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrPeriodo.Tag = "Periodo"
      Me.tbrPeriodo.Text = "Periodo"
      Me.tbrPeriodo.ToolTipText = "Visualizza i corrispettivi del periodo in corso"
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
      'Aggiorna
      '
      Me.Aggiorna.ImageIndex = 7
      Me.Aggiorna.Name = "Aggiorna"
      Me.Aggiorna.Tag = "Aggiorna"
      Me.Aggiorna.ToolTipText = "Aggiorna"
      '
      'ToolBarButton1
      '
      Me.ToolBarButton1.Name = "ToolBarButton1"
      Me.ToolBarButton1.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'Anteprima
      '
      Me.Anteprima.ImageIndex = 8
      Me.Anteprima.Name = "Anteprima"
      Me.Anteprima.Tag = "Anteprima"
      Me.Anteprima.ToolTipText = "Anteprima di stampa"
      '
      'Stampa
      '
      Me.Stampa.ImageIndex = 9
      Me.Stampa.Name = "Stampa"
      Me.Stampa.Tag = "Stampa"
      Me.Stampa.ToolTipText = "Stampa"
      '
      'Sep13
      '
      Me.Sep13.Name = "Sep13"
      Me.Sep13.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.Sep13.Visible = False
      '
      'Inserisci
      '
      Me.Inserisci.Name = "Inserisci"
      Me.Inserisci.Tag = ""
      Me.Inserisci.Visible = False
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
      Me.DataGrid1.Size = New System.Drawing.Size(736, 254)
      Me.DataGrid1.TabIndex = 0
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.dtpAl)
      Me.Panel1.Controls.Add(Me.dtpDal)
      Me.Panel1.Controls.Add(Me.lblAl)
      Me.Panel1.Controls.Add(Me.lblDal)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(736, 30)
      Me.Panel1.TabIndex = 1
      '
      'dtpAl
      '
      Me.dtpAl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpAl.Location = New System.Drawing.Point(552, 8)
      Me.dtpAl.Name = "dtpAl"
      Me.dtpAl.Size = New System.Drawing.Size(174, 20)
      Me.dtpAl.TabIndex = 1
      '
      'dtpDal
      '
      Me.dtpDal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpDal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.dtpDal.Location = New System.Drawing.Point(336, 8)
      Me.dtpDal.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
      Me.dtpDal.Name = "dtpDal"
      Me.dtpDal.Size = New System.Drawing.Size(174, 20)
      Me.dtpDal.TabIndex = 0
      '
      'lblAl
      '
      Me.lblAl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAl.AutoSize = True
      Me.lblAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblAl.ForeColor = System.Drawing.Color.White
      Me.lblAl.Location = New System.Drawing.Point(528, 8)
      Me.lblAl.Name = "lblAl"
      Me.lblAl.Size = New System.Drawing.Size(23, 15)
      Me.lblAl.TabIndex = 55668
      Me.lblAl.Text = "Al:"
      '
      'lblDal
      '
      Me.lblDal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDal.AutoSize = True
      Me.lblDal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDal.ForeColor = System.Drawing.Color.White
      Me.lblDal.Location = New System.Drawing.Point(304, 8)
      Me.lblDal.Name = "lblDal"
      Me.lblDal.Size = New System.Drawing.Size(33, 15)
      Me.lblDal.TabIndex = 55667
      Me.lblDal.Text = "Dal:"
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
      Me.Panel2.Controls.Add(Me.Label9)
      Me.Panel2.Controls.Add(Me.txtRicevute)
      Me.Panel2.Controls.Add(Me.Label5)
      Me.Panel2.Controls.Add(Me.txtScontrini)
      Me.Panel2.Controls.Add(Me.Label7)
      Me.Panel2.Controls.Add(Me.txtFatture)
      Me.Panel2.Controls.Add(Me.Label8)
      Me.Panel2.Controls.Add(Me.txtIncassato)
      Me.Panel2.Controls.Add(Me.Label4)
      Me.Panel2.Controls.Add(Me.txtNonIncassato)
      Me.Panel2.Controls.Add(Me.Label3)
      Me.Panel2.Controls.Add(Me.txtTotImporto)
      Me.Panel2.Controls.Add(Me.Label6)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 294)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(736, 48)
      Me.Panel2.TabIndex = 2
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label9.AutoSize = True
      Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label9.ForeColor = System.Drawing.Color.White
      Me.Label9.Location = New System.Drawing.Point(56, 24)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(51, 15)
      Me.Label9.TabIndex = 245
      Me.Label9.Text = "Totale:"
      '
      'txtRicevute
      '
      Me.txtRicevute.AcceptsReturn = True
      Me.txtRicevute.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtRicevute.BackColor = System.Drawing.SystemColors.Window
      Me.txtRicevute.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtRicevute.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtRicevute.ForeColor = System.Drawing.Color.Red
      Me.txtRicevute.Location = New System.Drawing.Point(216, 24)
      Me.txtRicevute.MaxLength = 0
      Me.txtRicevute.Name = "txtRicevute"
      Me.txtRicevute.ReadOnly = True
      Me.txtRicevute.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtRicevute.Size = New System.Drawing.Size(96, 20)
      Me.txtRicevute.TabIndex = 1
      Me.txtRicevute.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.ForeColor = System.Drawing.Color.White
      Me.Label5.Location = New System.Drawing.Point(216, 8)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(66, 15)
      Me.Label5.TabIndex = 244
      Me.Label5.Text = "Ricevute:"
      '
      'txtScontrini
      '
      Me.txtScontrini.AcceptsReturn = True
      Me.txtScontrini.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtScontrini.BackColor = System.Drawing.SystemColors.Window
      Me.txtScontrini.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtScontrini.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtScontrini.ForeColor = System.Drawing.Color.Red
      Me.txtScontrini.Location = New System.Drawing.Point(320, 24)
      Me.txtScontrini.MaxLength = 0
      Me.txtScontrini.Name = "txtScontrini"
      Me.txtScontrini.ReadOnly = True
      Me.txtScontrini.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtScontrini.Size = New System.Drawing.Size(96, 20)
      Me.txtScontrini.TabIndex = 2
      Me.txtScontrini.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.AutoSize = True
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.White
      Me.Label7.Location = New System.Drawing.Point(320, 8)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(68, 15)
      Me.Label7.TabIndex = 242
      Me.Label7.Text = "Scontrini:"
      '
      'txtFatture
      '
      Me.txtFatture.AcceptsReturn = True
      Me.txtFatture.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtFatture.BackColor = System.Drawing.SystemColors.Window
      Me.txtFatture.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtFatture.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtFatture.ForeColor = System.Drawing.Color.Red
      Me.txtFatture.Location = New System.Drawing.Point(112, 24)
      Me.txtFatture.MaxLength = 0
      Me.txtFatture.Name = "txtFatture"
      Me.txtFatture.ReadOnly = True
      Me.txtFatture.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtFatture.Size = New System.Drawing.Size(96, 20)
      Me.txtFatture.TabIndex = 0
      Me.txtFatture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label8.AutoSize = True
      Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label8.ForeColor = System.Drawing.Color.White
      Me.Label8.Location = New System.Drawing.Point(112, 8)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(56, 15)
      Me.Label8.TabIndex = 241
      Me.Label8.Text = "Fatture:"
      '
      'txtIncassato
      '
      Me.txtIncassato.AcceptsReturn = True
      Me.txtIncassato.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtIncassato.BackColor = System.Drawing.SystemColors.Window
      Me.txtIncassato.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIncassato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIncassato.ForeColor = System.Drawing.Color.Red
      Me.txtIncassato.Location = New System.Drawing.Point(528, 24)
      Me.txtIncassato.MaxLength = 0
      Me.txtIncassato.Name = "txtIncassato"
      Me.txtIncassato.ReadOnly = True
      Me.txtIncassato.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIncassato.Size = New System.Drawing.Size(96, 20)
      Me.txtIncassato.TabIndex = 4
      Me.txtIncassato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.White
      Me.Label4.Location = New System.Drawing.Point(528, 8)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(72, 15)
      Me.Label4.TabIndex = 238
      Me.Label4.Text = "Incassato:"
      '
      'txtNonIncassato
      '
      Me.txtNonIncassato.AcceptsReturn = True
      Me.txtNonIncassato.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNonIncassato.BackColor = System.Drawing.SystemColors.Window
      Me.txtNonIncassato.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNonIncassato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNonIncassato.ForeColor = System.Drawing.Color.Red
      Me.txtNonIncassato.Location = New System.Drawing.Point(632, 24)
      Me.txtNonIncassato.MaxLength = 0
      Me.txtNonIncassato.Name = "txtNonIncassato"
      Me.txtNonIncassato.ReadOnly = True
      Me.txtNonIncassato.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNonIncassato.Size = New System.Drawing.Size(96, 20)
      Me.txtNonIncassato.TabIndex = 5
      Me.txtNonIncassato.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.AutoSize = True
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.White
      Me.Label3.Location = New System.Drawing.Point(632, 8)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(102, 15)
      Me.Label3.TabIndex = 236
      Me.Label3.Text = "Non incassato:"
      '
      'txtTotImporto
      '
      Me.txtTotImporto.AcceptsReturn = True
      Me.txtTotImporto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotImporto.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotImporto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotImporto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotImporto.ForeColor = System.Drawing.Color.Red
      Me.txtTotImporto.Location = New System.Drawing.Point(424, 24)
      Me.txtTotImporto.MaxLength = 0
      Me.txtTotImporto.Name = "txtTotImporto"
      Me.txtTotImporto.ReadOnly = True
      Me.txtTotImporto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotImporto.Size = New System.Drawing.Size(96, 20)
      Me.txtTotImporto.TabIndex = 3
      Me.txtTotImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.White
      Me.Label6.Location = New System.Drawing.Point(424, 8)
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
      'ElencoCorrispettivi
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(736, 342)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoCorrispettivi"
      Me.ShowInTaskbar = False
      Me.Text = "Elenco Corrispettivi"
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("FiltroCorrispettivi") <> "" Then
            filtroDati = DatiConfig.GetValue("FiltroCorrispettivi")
         Else
            filtroDati = "Tutti"
         End If

         If DatiConfig.GetValue("WSCorrispettivi") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSCorrispettivi") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("ACorrispettivi") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("ACorrispettivi"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LCorrispettivi") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LCorrispettivi"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("CorrispettiviX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("CorrispettiviX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("CorrispettiviY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("CorrispettiviY")))
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

         DatiConfig.SetValue("FiltroCorrispettivi", filtroDati)
         DatiConfig.SetValue("WSCorrispettivi", Me.WindowState)
         DatiConfig.SetValue("CorrispettiviX", Me.Location.X)
         DatiConfig.SetValue("CorrispettiviY", Me.Location.Y)
         DatiConfig.SetValue("ACorrispettivi", Me.Height)
         DatiConfig.SetValue("LCorrispettivi", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Corrispettivi
               If operatore.ContCorrispettivi = VALORE_LETTURA Then
                  Modifica.Enabled = False
                  Elimina.Enabled = False
               Else
                  Modifica.Enabled = True
                  Elimina.Enabled = True
               End If
         End Select

         Return Modifica.Enabled

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return True
      End Try

   End Function

   Public Sub registraModifica()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)
         Dim strDescrizione As String = "(Corrispettivi del " & Data & ")"

         g_frmMain.RegistraOperazione(TipoOperazione.Modifica, strDescrizione, MODULO_CONTABILITA_CORRISPETTIVI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

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

         ' Chiude la connessione se è da chiudere.
         If closeOnExit Then cn.Close()

         ' Ottiene il numero di pagine.
         numPagine = (numRecord + DIM_PAGINA_GRANDE - 1) \ DIM_PAGINA_GRANDE 'dimPagina

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
      Try
         Dim Risposta As Short
         Dim sql As String

         Dim Data As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare i corrispettivi del " & Data & """?" & _
                           vbCrLf & vbCrLf & "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

         If Risposta = MsgBoxResult.Yes Then
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record As Integer = cmdDelete.ExecuteNonQuery()

            ' Conferma la transazione.
            tr.Commit()

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(Corrispettivi del " & Data & ")"
            g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, MODULO_CONTABILITA_CORRISPETTIVI)
         End If

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

         If tbrMese.Pushed = True Then
            ' Aggiorna la griglia dati.
            FiltraDati("Mese")
         ElseIf tbrAnno.Pushed = True Then
            ' Aggiorna la griglia dati.
            FiltraDati("Anno")
         ElseIf tbrPeriodo.Pushed = True Then
            ' Aggiorna la griglia dati.
            FiltraDati("Periodo")
         Else
            ' Aggiorna la griglia dati.
            FiltraDati("Tutti")
         End If

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()
      End Try
   End Sub

   Public Sub AggiornaDati()
      Try
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(TAB_CORRISPETTIVI)

         ' Collega la tabella clienti al controllo griglia dati.
         DataGrid1.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(pagCorrente, sql)

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Somma i valori delle colonne Importi.
         SommaImporti()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDate()
      dtpDal.Enabled = True
      dtpAl.Enabled = True
   End Sub

   Private Sub DisattivaDate()
      dtpDal.Enabled = False
      dtpAl.Enabled = False
   End Sub

   Public Sub ImpostaComandi()
      If numRecord = 0 Then
         ' Disattiva i pulsanti appropriati.
         Modifica.Enabled = False
         Elimina.Enabled = False
         Primo.Enabled = False
         Precedente.Enabled = False
         Successivo.Enabled = False
         Ultimo.Enabled = False
         Aggiorna.Enabled = False
      Else
         ' Disattiva i pulsanti appropriati.
         Modifica.Enabled = True
         Elimina.Enabled = True
         Aggiorna.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      If ImpostaFunzioniOperatore(Finestra.Corrispettivi) = True Then
         ImpostaComandi()
      End If
   End Sub

   Private Sub ApriDati(ByVal codice As String, ByVal data As String, ByVal fatture As String, ByVal ricevute As String, ByVal scontrini As String, ByVal nonIncassato As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim frm As New Corrispettivi(codice, data, fatture, ricevute, scontrini, nonIncassato)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase("Corrispettivi del " & _
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & " - " & _
                                                  DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2))
         Else
            DataGrid1.CaptionText = ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggTitoloFinestra(ByVal titolo As String)
      ' Imposta il titolo della tabella.
      Me.Text = titolo & " (n° totale: " & numRecord & ")"
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
         ' Data documento
         Dim dataStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         dataStyle.MappingName = "Data"
         dataStyle.HeaderText = "Data"
         dataStyle.Width = 75
         dataStyle.NullText = ""
         dataStyle.Alignment = HorizontalAlignment.Center
         dataStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(dataStyle)
         ' Giorno
         Dim giornoStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         giornoStyle.MappingName = "Giorno"
         giornoStyle.HeaderText = "Giorno"
         giornoStyle.Width = 100
         giornoStyle.NullText = ""
         giornoStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(giornoStyle)
         ' Fatture
         Dim fattureStyle As New DataGridTextBoxColumn
         fattureStyle.MappingName = "Fatture"
         fattureStyle.HeaderText = "Fatture"
         fattureStyle.Width = 100
         fattureStyle.NullText = ""
         fattureStyle.Format = "##,##0.00"
         fattureStyle.Alignment = HorizontalAlignment.Right
         fattureStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(fattureStyle)
         ' Ricevute
         Dim ricevuteStyle As New DataGridTextBoxColumn
         ricevuteStyle.MappingName = "Ricevute"
         ricevuteStyle.HeaderText = "Ricevute"
         ricevuteStyle.Width = 100
         ricevuteStyle.NullText = ""
         ricevuteStyle.Format = "##,##0.00"
         ricevuteStyle.Alignment = HorizontalAlignment.Right
         ricevuteStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(ricevuteStyle)
         ' Scontrini
         Dim scontriniStyle As New DataGridTextBoxColumn
         scontriniStyle.MappingName = "Scontrini"
         scontriniStyle.HeaderText = "Scontrini"
         scontriniStyle.Width = 100
         scontriniStyle.NullText = ""
         scontriniStyle.Format = "##,##0.00"
         scontriniStyle.Alignment = HorizontalAlignment.Right
         scontriniStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(scontriniStyle)
         'Totale
         Dim totaleStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         totaleStyle.MappingName = "Totale"
         totaleStyle.HeaderText = "Totale"
         totaleStyle.Width = 100
         totaleStyle.NullText = ""
         totaleStyle.Format = "##,##0.00"
         totaleStyle.Alignment = HorizontalAlignment.Right
         totaleStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(totaleStyle)
         'Incassato
         Dim incassatoStyle As New DataGridTextBoxColumn
         incassatoStyle.MappingName = "Incassato"
         incassatoStyle.HeaderText = "Incassato"
         incassatoStyle.Width = 100
         incassatoStyle.NullText = ""
         incassatoStyle.Format = "##,##0.00"
         incassatoStyle.Alignment = HorizontalAlignment.Right
         incassatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(incassatoStyle)
         'Non incassato
         Dim nonIncassatoStyle As New DataGridTextBoxColumn
         nonIncassatoStyle.MappingName = "NonIncassato"
         nonIncassatoStyle.HeaderText = "Non incassato"
         nonIncassatoStyle.Width = 100
         nonIncassatoStyle.NullText = ""
         nonIncassatoStyle.Format = "##,##0.00"
         nonIncassatoStyle.Alignment = HorizontalAlignment.Right
         nonIncassatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(nonIncassatoStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub FiltraDati(ByVal campoRicerca As String)
      Try
         Dim sql As String

         Dim Anno As String = Year(Now)
         Dim Mese As String = Month(Now)

         Select Case campoRicerca
            Case "Tutti"
               sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Data ASC", DIM_PAGINA_GRANDE, TAB_CORRISPETTIVI)
               repSql = String.Format("SELECT * FROM {0} ORDER BY Data ASC", TAB_CORRISPETTIVI)
               DisattivaDate()
               ' Legge i dati e ottiene il numero totale dei record.
               LeggiDati(TAB_CORRISPETTIVI, sql)

            Case "Anno"
               Dim Appo1 As String = CFormatta.FormattaData("01/01/" & Anno)
               Dim UltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, 12)
               Dim Appo2 As String = CFormatta.FormattaData(UltimoGiornoAnno & "/12/" & Anno)

               sql = String.Format("SELECT * FROM {0} WHERE Data BETWEEN #{1}# AND #{2}# ORDER BY Data ASC", TAB_CORRISPETTIVI, Appo1, Appo2)
               DisattivaDate()
               ' Salva la query per i reports.
               repSql = sql
               ' Legge i dati e ottiene il numero totale dei record.
               LeggiDati("(" & sql & ")", sql)

            Case "Mese"
               Dim Appo1 As String = CFormatta.FormattaData("01/" & Mese & "/" & Anno)
               Dim UltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, Mese)
               Dim Appo2 As String = CFormatta.FormattaData(UltimoGiornoAnno & "/" & Mese & "/" & Anno)

               sql = String.Format("SELECT * FROM {0} WHERE Data BETWEEN #{1}# AND #{2}# ORDER BY Data ASC", TAB_CORRISPETTIVI, Appo1, Appo2)
               DisattivaDate()
               ' Salva la query per i reports.
               repSql = sql
               ' Legge i dati e ottiene il numero totale dei record.
               LeggiDati("(" & sql & ")", sql)

            Case "Periodo"
               Dim Appo1 As String = CFormatta.FormattaData(dtpDal.Text)
               Dim Appo2 As String = CFormatta.FormattaData(dtpAl.Text)

               sql = String.Format("SELECT * FROM {0} WHERE Data BETWEEN #{1}# AND #{2}# ORDER BY Data ASC", TAB_CORRISPETTIVI, Appo1, Appo2)
               AttivaDate()
               ' Salva la query per i reports.
               repSql = sql
               ' Legge i dati e ottiene il numero totale dei record.
               LeggiDati("(" & sql & ")", sql)
         End Select

         ' Somma i valori delle colonne Importi.
         SommaImporti()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

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

   Private Sub SommaImporti()
      ' Somma i valori della colonna Importo.
      txtFatture.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_FATTURE, numRecord))
      ' Somma i valori della colonna Importo.
      txtRicevute.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_RICEVUTE, numRecord))
      ' Somma i valori della colonna Importo.
      txtScontrini.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_SCONTRINI, numRecord))
      ' Somma i valori della colonna Importo.
      txtTotImporto.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_TOTALE, numRecord))
      ' Somma i valori della colonna Importo.
      txtIncassato.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_INCASSATO, numRecord))
      ' Somma i valori della colonna Importo.
      txtNonIncassato.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_NON_INCASSATO, numRecord))
   End Sub

   Private Sub ElencoCorrispettivi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_CORRISPETTIVI)

         Select Case filtroDati
            Case "Tutti"
               tbrTutti.Pushed = True
               tbrPeriodo.Pushed = False
               tbrMese.Pushed = False
               tbrAnno.Pushed = False
               DisattivaDate()
            Case "Mese"
               tbrMese.Pushed = True
               tbrTutti.Pushed = False
               tbrPeriodo.Pushed = False
               tbrAnno.Pushed = False
               DisattivaDate()
            Case "Anno"
               tbrAnno.Pushed = True
               tbrTutti.Pushed = False
               tbrPeriodo.Pushed = False
               tbrMese.Pushed = False
               DisattivaDate()
            Case "Periodo"
               tbrPeriodo.Pushed = True
               tbrTutti.Pushed = False
               tbrMese.Pushed = False
               tbrAnno.Pushed = False
               AttivaDate()
            Case "Sospesi"
               tbrTutti.Pushed = False
               tbrMese.Pushed = False
               tbrAnno.Pushed = False
               tbrPeriodo.Pushed = False
               DisattivaDate()
         End Select

         ' Filtra i dati in base al testo digitato.
         FiltraDati(filtroDati)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_CONTABILITA_CORRISPETTIVI, MODULO_CONTABILITA_CORRISPETTIVI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ElencoCorrispettivi_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmCorrispettivi)

         ' Distrugge l'oggetto e libera le risorse.
         g_frmCorrispettivi.Dispose()
         g_frmCorrispettivi = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTABILITA_CORRISPETTIVI, MODULO_CONTABILITA_CORRISPETTIVI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      ' Visualizza un'intestazione per la griglia dati.
      AggIntGriglia()

   End Sub

   Private Sub ToolBar1_ButtonClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Select Case e.Button.Tag

         Case "Modifica"
            ' Registra loperazione efettuata dall'operatore identificato.
            registraModifica()

            ' Apre la finestra per l'inserimento di nuovi dati.
            ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)), _
                     CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)), _
                     CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)), _
                     CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)), _
                     CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5)), _
                     CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8)))

         Case "Elimina"
            ' Elimina il valore selezionato.
            EliminaDati(TAB_CORRISPETTIVI, DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))

         Case "Tutti"
            tbrPeriodo.Pushed = False
            tbrMese.Pushed = False
            tbrAnno.Pushed = False
            DisattivaDate()
            filtroDati = "Tutti"
            FiltraDati("Tutti")

         Case "Mese"
            tbrTutti.Pushed = False
            tbrPeriodo.Pushed = False
            tbrAnno.Pushed = False
            DisattivaDate()
            filtroDati = "Mese"
            FiltraDati("Mese")

         Case "Anno"
            tbrTutti.Pushed = False
            tbrPeriodo.Pushed = False
            tbrMese.Pushed = False
            DisattivaDate()
            filtroDati = "Anno"
            FiltraDati("Anno")

         Case "Periodo"
            tbrTutti.Pushed = False
            tbrMese.Pushed = False
            tbrAnno.Pushed = False
            AttivaDate()
            filtroDati = "Periodo"
            FiltraDati("Periodo")

         Case "Stampa"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Stampa, STR_CONTABILITA_CORRISPETTIVI, MODULO_CONTABILITA_CORRISPETTIVI)

            StampaDocumento(PERCORSO_REP_CORRISPETTIVI, TAB_CORRISPETTIVI, repSql)

         Case "Anteprima"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_CONTABILITA_CORRISPETTIVI, MODULO_CONTABILITA_CORRISPETTIVI)

            g_frmMain.ApriReports(repSql, TAB_CORRISPETTIVI, PERCORSO_REP_CORRISPETTIVI)

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
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_CORRISPETTIVI, MODULO_CONTABILITA_CORRISPETTIVI)

            If tbrMese.Pushed = True Then
               ' Aggiorna la griglia dati.
               FiltraDati("Mese")
            ElseIf tbrAnno.Pushed = True Then
               ' Aggiorna la griglia dati.
               FiltraDati("Anno")
            ElseIf tbrPeriodo.Pushed = True Then
               ' Aggiorna la griglia dati.
               FiltraDati("Periodo")
            Else
               ' Aggiorna la griglia dati.
               FiltraDati("Tutti")
            End If

      End Select
   End Sub

   Private Sub DataGrid1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGrid1.DoubleClick
      If Modifica.Enabled = True Then
         ' Registra loperazione efettuata dall'operatore identificato.
         registraModifica()

         ' Apre la finestra Cliente per la modifica dei dati.
         ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)), _
                  CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)), _
                  CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 3)), _
                  CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4)), _
                  CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5)), _
                  CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8)))
      End If
   End Sub

   Private Sub cmbDal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDal.ValueChanged
      Try
         FiltraDati("Periodo")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmbAl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpAl.ValueChanged
      Try
         FiltraDati("Periodo")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub
End Class
