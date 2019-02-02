' Nome form:            frmStatistiche
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/05/2006
' Data ultima modifica: 10/05/2006
' Descrizione:          Elenco statistiche di vendita.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class frmStatisticheRisorse
   Inherits System.Windows.Forms.Form

   Const TAB_STATISTICHE As String = "StatisticheRisorse"
   Const TAB_RISORSE As String = "Risorse"

   Const TITOLO_FINESTRA As String = "Statistiche di vendita Centro sportivo"

   ' A_TODO: MODIFICHE ASD AGON
   Const COLONNA_QTA As Short = 7
   Const COLONNA_IMPORTO As Short = 9

   Const ITEM_TUTTE As String = "< Tutte >"

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
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Private CFormatta As New ClsFormatta

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_STATISTICHE)

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
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents CampoRicerca As System.Windows.Forms.ComboBox
   Friend WithEvents TestoRicerca As System.Windows.Forms.TextBox
   Friend WithEvents tbNuovo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Sep13 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Inserisci As System.Windows.Forms.ToolBarButton
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents dtpDataAl As System.Windows.Forms.DateTimePicker
   Friend WithEvents dtpDataDal As System.Windows.Forms.DateTimePicker
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents lblTotale As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents txtTotQuantit‡ As System.Windows.Forms.TextBox
   Public WithEvents txtTotImporto As System.Windows.Forms.TextBox
   Friend WithEvents lstRisorse As System.Windows.Forms.ListBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStatisticheRisorse))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.tbNuovo = New System.Windows.Forms.ToolBarButton()
      Me.Modifica = New System.Windows.Forms.ToolBarButton()
      Me.Elimina = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton4 = New System.Windows.Forms.ToolBarButton()
      Me.Primo = New System.Windows.Forms.ToolBarButton()
      Me.Precedente = New System.Windows.Forms.ToolBarButton()
      Me.Successivo = New System.Windows.Forms.ToolBarButton()
      Me.Ultimo = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton7 = New System.Windows.Forms.ToolBarButton()
      Me.Aggiorna = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton1 = New System.Windows.Forms.ToolBarButton()
      Me.Anteprima = New System.Windows.Forms.ToolBarButton()
      Me.Stampa = New System.Windows.Forms.ToolBarButton()
      Me.Sep13 = New System.Windows.Forms.ToolBarButton()
      Me.Inserisci = New System.Windows.Forms.ToolBarButton()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.TestoRicerca = New System.Windows.Forms.TextBox()
      Me.dtpDataAl = New System.Windows.Forms.DateTimePicker()
      Me.dtpDataDal = New System.Windows.Forms.DateTimePicker()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.CampoRicerca = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.lstRisorse = New System.Windows.Forms.ListBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.txtTotImporto = New System.Windows.Forms.TextBox()
      Me.txtTotQuantit‡ = New System.Windows.Forms.TextBox()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.lblTotale = New System.Windows.Forms.Label()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel1.SuspendLayout()
      Me.Panel2.SuspendLayout()
      Me.SuspendLayout()
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbNuovo, Me.Modifica, Me.Elimina, Me.ToolBarButton4, Me.Primo, Me.Precedente, Me.Successivo, Me.Ultimo, Me.ToolBarButton7, Me.Aggiorna, Me.ToolBarButton1, Me.Anteprima, Me.Stampa, Me.Sep13, Me.Inserisci})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(672, 26)
      Me.ToolBar1.TabIndex = 2
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Wrappable = False
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
      'Modifica
      '
      Me.Modifica.ImageIndex = 1
      Me.Modifica.Name = "Modifica"
      Me.Modifica.Tag = "Modifica"
      Me.Modifica.Text = "Apri"
      Me.Modifica.ToolTipText = "Apri"
      Me.Modifica.Visible = False
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
      'ToolBarButton4
      '
      Me.ToolBarButton4.Name = "ToolBarButton4"
      Me.ToolBarButton4.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.ToolBarButton4.Visible = False
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
      'ToolBarButton7
      '
      Me.ToolBarButton7.Name = "ToolBarButton7"
      Me.ToolBarButton7.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      Me.ToolBarButton7.Visible = False
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
      Me.DataGrid1.Location = New System.Drawing.Point(211, 80)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(461, 231)
      Me.DataGrid1.TabIndex = 1
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.TestoRicerca)
      Me.Panel1.Controls.Add(Me.dtpDataAl)
      Me.Panel1.Controls.Add(Me.dtpDataDal)
      Me.Panel1.Controls.Add(Me.Label5)
      Me.Panel1.Controls.Add(Me.Label4)
      Me.Panel1.Controls.Add(Me.CampoRicerca)
      Me.Panel1.Controls.Add(Me.Label2)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(672, 54)
      Me.Panel1.TabIndex = 0
      '
      'TestoRicerca
      '
      Me.TestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TestoRicerca.Location = New System.Drawing.Point(5, 25)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(171, 20)
      Me.TestoRicerca.TabIndex = 0
      '
      'dtpDataAl
      '
      Me.dtpDataAl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpDataAl.Location = New System.Drawing.Point(496, 25)
      Me.dtpDataAl.Name = "dtpDataAl"
      Me.dtpDataAl.Size = New System.Drawing.Size(168, 20)
      Me.dtpDataAl.TabIndex = 3
      '
      'dtpDataDal
      '
      Me.dtpDataDal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.dtpDataDal.Location = New System.Drawing.Point(320, 25)
      Me.dtpDataDal.Name = "dtpDataDal"
      Me.dtpDataDal.Size = New System.Drawing.Size(168, 20)
      Me.dtpDataDal.TabIndex = 2
      '
      'Label5
      '
      Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label5.AutoSize = True
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.ForeColor = System.Drawing.Color.White
      Me.Label5.Location = New System.Drawing.Point(496, 8)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(23, 15)
      Me.Label5.TabIndex = 10
      Me.Label5.Text = "Al:"
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.White
      Me.Label4.Location = New System.Drawing.Point(320, 8)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(33, 15)
      Me.Label4.TabIndex = 9
      Me.Label4.Text = "Dal:"
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(184, 24)
      Me.CampoRicerca.Name = "CampoRicerca"
      Me.CampoRicerca.Size = New System.Drawing.Size(128, 21)
      Me.CampoRicerca.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.White
      Me.Label2.Location = New System.Drawing.Point(184, 8)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(85, 15)
      Me.Label2.TabIndex = 8
      Me.Label2.Text = "Ricerca per:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.White
      Me.Label1.Location = New System.Drawing.Point(5, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(110, 15)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Testo di ricerca:"
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "Risorse.rpt"
      '
      'lstRisorse
      '
      Me.lstRisorse.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lstRisorse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstRisorse.Location = New System.Drawing.Point(0, 100)
      Me.lstRisorse.Name = "lstRisorse"
      Me.lstRisorse.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lstRisorse.Size = New System.Drawing.Size(210, 212)
      Me.lstRisorse.TabIndex = 0
      '
      'Label3
      '
      Me.Label3.BackColor = System.Drawing.Color.Gray
      Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.White
      Me.Label3.Location = New System.Drawing.Point(-1, 79)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(218, 22)
      Me.Label3.TabIndex = 9
      Me.Label3.Text = "RISORSE:"
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.Gray
      Me.Panel2.Controls.Add(Me.txtTotImporto)
      Me.Panel2.Controls.Add(Me.txtTotQuantit‡)
      Me.Panel2.Controls.Add(Me.Label6)
      Me.Panel2.Controls.Add(Me.lblTotale)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 313)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(672, 32)
      Me.Panel2.TabIndex = 12
      '
      'txtTotImporto
      '
      Me.txtTotImporto.AcceptsReturn = True
      Me.txtTotImporto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotImporto.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotImporto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotImporto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotImporto.ForeColor = System.Drawing.Color.Red
      Me.txtTotImporto.Location = New System.Drawing.Point(560, 6)
      Me.txtTotImporto.MaxLength = 0
      Me.txtTotImporto.Name = "txtTotImporto"
      Me.txtTotImporto.ReadOnly = True
      Me.txtTotImporto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotImporto.Size = New System.Drawing.Size(104, 20)
      Me.txtTotImporto.TabIndex = 235
      Me.txtTotImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtTotQuantit‡
      '
      Me.txtTotQuantit‡.AcceptsReturn = True
      Me.txtTotQuantit‡.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotQuantit‡.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotQuantit‡.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotQuantit‡.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotQuantit‡.ForeColor = System.Drawing.Color.Red
      Me.txtTotQuantit‡.Location = New System.Drawing.Point(296, 6)
      Me.txtTotQuantit‡.MaxLength = 0
      Me.txtTotQuantit‡.Name = "txtTotQuantit‡"
      Me.txtTotQuantit‡.ReadOnly = True
      Me.txtTotQuantit‡.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotQuantit‡.Size = New System.Drawing.Size(104, 20)
      Me.txtTotQuantit‡.TabIndex = 234
      Me.txtTotQuantit‡.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.White
      Me.Label6.Location = New System.Drawing.Point(409, 8)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(148, 15)
      Me.Label6.TabIndex = 16
      Me.Label6.Text = "Totale valore venduto:"
      '
      'lblTotale
      '
      Me.lblTotale.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotale.AutoSize = True
      Me.lblTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotale.ForeColor = System.Drawing.Color.White
      Me.lblTotale.Location = New System.Drawing.Point(151, 8)
      Me.lblTotale.Name = "lblTotale"
      Me.lblTotale.Size = New System.Drawing.Size(141, 15)
      Me.lblTotale.TabIndex = 13
      Me.lblTotale.Text = "Totale ore prenotate:"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmStatisticheRisorse
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(672, 345)
      Me.Controls.Add(Me.lstRisorse)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.Panel2)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmStatisticheRisorse"
      Me.ShowInTaskbar = False
      Me.Text = "Statistiche"
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

         If DatiConfig.GetValue("WSStatRisorse") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSStatRisorse") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("AStatRisorse") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("AStatRisorse"))
            Else
               Me.Height = STAT_ALTEZZA
            End If

            If DatiConfig.GetValue("LStatRisorse") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LStatRisorse"))
            Else
               Me.Width = STAT_LARGHEZZA
            End If

            If DatiConfig.GetValue("StatXRisorse") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("StatXRisorse")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("StatYRisorse") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("StatYRisorse")))
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

         DatiConfig.SetValue("WSStatRisorse", Me.WindowState)
         DatiConfig.SetValue("StatXRisorse", Me.Location.X)
         DatiConfig.SetValue("StatYRisorse", Me.Location.Y)
         DatiConfig.SetValue("AStatRisorse", Me.Height)
         DatiConfig.SetValue("LStatRisorse", Me.Width)

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

   Sub LeggiNumPagine(ByVal tabella As String)
      Dim closeOnExit As Boolean

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Formatta le date nel formato inglese Mese-Giorno-Anno.
         Dim dataDal As String = FormattaData(dtpDataDal.Text, False)
         Dim dataAl As String = FormattaData(dtpDataAl.Text, False)

         If lstRisorse.SelectedItem = ITEM_TUTTE Then
            ' Ottiene il numero di record.
            cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Data BETWEEN #{1}# AND #{2}#", _
                                            tabella, dataDal, dataAl)
         Else
            ' Ottiene il numero di record.
            cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE DesRisorsa = '{1}' " & _
                                            "AND Data BETWEEN #{2}# AND #{3}#", tabella, lstRisorse.SelectedItem, dataDal, dataAl)
         End If

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
      Try
         Dim Risposta As Short
         Dim sql As String

         Dim descrizione As String = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1)

         ' Chiede conferma per l'eliminazione.
         Risposta = MsgBox("Si desidera eliminare il piatto " & descrizione & _
                           """?" & vbCrLf & vbCrLf & "Non sar‡ pi˘ possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma eliminazione")

         If Risposta = MsgBoxResult.Yes Then
            ' Apre la connessione.
            cn.Open()

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            'If TipoElenco = Elenco.Risorse Then
            ' Crea la stringa di eliminazione.
            'sql = String.Format("DELETE FROM {0} WHERE Numero = '{1}'", tabella, id)
            'Else
            ' Crea la stringa di eliminazione.
            sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, id)
            'End If

            ' Crea il comando per la connessione corrente.
            Dim cmdDelete As New OleDbCommand(sql, cn, tr)

            ' Esegue il comando.
            Dim Record As Integer = cmdDelete.ExecuteNonQuery()

            '' Elimina i dati della prenotazione per le statistiche.
            ''-------------------------------------------------------------------------------
            '' Crea la stringa di eliminazione.
            'sql = String.Format("DELETE FROM Statistiche WHERE Codice = '{0}'", id.ToString)

            '' Crea il comando per la connessione corrente.
            'Dim cmdDelete1 As New OleDbCommand(sql, cn, tr)

            '' Esegue il comando.
            'Dim Record1 As Integer = cmdDelete1.ExecuteNonQuery()
            ''-------------------------------------------------------------------------------

            ' Conferma la transazione.
            tr.Commit()

         End If

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

         ' Aggiorna la griglia dati.
         AggiornaDati()

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()
      End Try
   End Sub

   Public Sub AggiornaDati()
      Try
         If TestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstRisorse.SelectedItem)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_STATISTICHE)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(pagCorrente, sql)

            ' Somma i valori della colonna Quantit‡.
            txtTotQuantit‡.Text = CFormatta.FormattaNumeroDouble2(SommaColonna(DataGrid1, COLONNA_QTA, numRecord))

            ' Somma i valori della colonna Importo.
            txtTotImporto.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO, numRecord))

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TITOLO_FINESTRA)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ConvalidaDati()
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

   Private Sub ApriDati(ByVal val As String)
      'Try
      '   ' Modifica il cursore del mouse.
      '   Cursor.Current = Cursors.AppStarting

      '   ' Per la versione demo.
      '   If g_VerDemo = True Then
      '      ' Test per la versione demo.
      '      If VerificaNumRecord(LeggiNumRecord(TAB_STATISTICHE)) = True Then
      '         Exit Sub
      '      End If
      '   End If

      '   Dim frm As New frmPiatti
      '   frm.Tag = val
      '   frm.ShowDialog()

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If numRecord <> 0 Then
            DataGrid1.CaptionText = Strings.UCase("Pagina " & pagCorrente.ToString & " di " & numPagine.ToString & " - " & _
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
      Me.Text = titolo & " (n∞ totale: " & numRecord & ")"
   End Sub

   Private Sub CreaColonne(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         ' Id - Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "IdPren"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 50
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Data
         Dim dataStyle As New DataGridTextBoxColumn
         dataStyle.MappingName = "Data"
         dataStyle.HeaderText = "Data"
         dataStyle.Width = 80
         dataStyle.NullText = ""
         dataStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(dataStyle)
         ' Cliente
         Dim clienteStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         clienteStyle.MappingName = "Intestatario"
         clienteStyle.HeaderText = "Intestatario"
         clienteStyle.Width = 150
         clienteStyle.NullText = ""
         clienteStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(clienteStyle)
         ' Risorsa
         Dim risorsaStyle As New DataGridTextBoxColumn
         risorsaStyle.MappingName = "DesRisorsa"
         risorsaStyle.HeaderText = "Risorsa"
         risorsaStyle.Width = 120
         risorsaStyle.NullText = ""
         risorsaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(risorsaStyle)
         ' Tipologia di utilizzo
         ' A_TODO: MODIFICHE ASD AGON
         Dim tipologiaStyle As New DataGridTextBoxColumn
         tipologiaStyle.MappingName = "CaratteristicaRisorsa"
         tipologiaStyle.HeaderText = "Tipologia di utilizzo"
         tipologiaStyle.Width = 250
         tipologiaStyle.NullText = ""
         tipologiaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(tipologiaStyle)
         ' OraInizio
         Dim oraInizioStyle As New DataGridTextBoxColumn
         oraInizioStyle.MappingName = "OraInizio"
         oraInizioStyle.HeaderText = "Dalle ore"
         oraInizioStyle.Width = 60
         oraInizioStyle.NullText = ""
         oraInizioStyle.Alignment = HorizontalAlignment.Right
         oraInizioStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraInizioStyle)
         ' OraFine
         Dim oraFineStyle As New DataGridTextBoxColumn
         oraFineStyle.MappingName = "OraFine"
         oraFineStyle.HeaderText = "Alle ore"
         oraFineStyle.Width = 60
         oraFineStyle.NullText = ""
         oraFineStyle.Alignment = HorizontalAlignment.Right
         oraFineStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(oraFineStyle)
         ' Quantit‡
         Dim quantit‡Style As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         quantit‡Style.MappingName = "Quantit‡"
         quantit‡Style.HeaderText = "Ore prenotate"
         quantit‡Style.Width = 80
         quantit‡Style.NullText = ""
         quantit‡Style.Format = "##,##0.0"
         quantit‡Style.Alignment = HorizontalAlignment.Center
         quantit‡Style.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(quantit‡Style)
         ' Costo Risorsa
         Dim costoStyle As New DataGridTextBoxColumn
         costoStyle.MappingName = "CostoRisorsa"
         costoStyle.HeaderText = "Costo risorsa"
         costoStyle.Width = 80
         costoStyle.NullText = ""
         costoStyle.Format = "##,##0.00"
         costoStyle.Alignment = HorizontalAlignment.Right
         costoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(costoStyle)
         ' Importo
         Dim importoStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         importoStyle.MappingName = "Importo"
         importoStyle.HeaderText = "Totale"
         importoStyle.Width = 80
         importoStyle.NullText = ""
         importoStyle.Format = "##,##0.00"
         importoStyle.Alignment = HorizontalAlignment.Right
         importoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(importoStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FiltraDati(ByVal testoRicerca As String, ByVal campoRicerca As String, ByVal categoria As String)
      Try
         testoRicerca = FormattaApici(testoRicerca)

         Select Case campoRicerca
            Case "Codice"
               campoRicerca = "IdPren"
            Case "Risorsa"
               campoRicerca = "DesRisorsa"
            Case "Tipologia di utilizzo"
               ' A_TODO: MODIFICHE ASD AGON
               campoRicerca = "CaratteristicaRisorsa"
            Case "Dalle ore"
               campoRicerca = "OraInizio"
            Case "Alle ore"
               campoRicerca = "OraFine"
            Case "Ore prenotate"
               campoRicerca = "Quantit‡"
            Case "Costo risorsa"
               campoRicerca = "CostoRisorsa"
            Case "Totale"
               campoRicerca = "Importo"

         End Select

         ' Formatta le date nel formato inglese Mese-Giorno-Anno.
         Dim dataDal As String = FormattaData(dtpDataDal.Text, False)
         Dim dataAl As String = FormattaData(dtpDataAl.Text, False)

         If testoRicerca <> "" Then
            If categoria = ITEM_TUTTE Then
               ' Crea la stringa sql.
               sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' " & _
                                   "AND Data BETWEEN #{2}# AND #{3}# ORDER BY {4} ASC", _
                                   TAB_STATISTICHE, campoRicerca, dataDal, dataAl, campoRicerca)
            Else
               ' Crea la stringa sql.
               sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' AND DesRisorsa = '{2}' " & _
                                   "AND Data BETWEEN #{3}# AND #{4}# ORDER BY {5} ASC", _
                                   TAB_STATISTICHE, campoRicerca, categoria, dataDal, dataAl, campoRicerca)
            End If

            repSql = sql

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)

         Else
            If categoria = ITEM_TUTTE Then
               sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Data BETWEEN #{2}# AND #{3}# ORDER BY {4} ASC", _
                                   DIM_PAGINA_GRANDE, TAB_STATISTICHE, dataDal, dataAl, campoRicerca)

               repSql = String.Format("SELECT * FROM {0} WHERE Data BETWEEN #{1}# AND #{2}# ORDER BY {3} ASC", _
                                      TAB_STATISTICHE, dataDal, dataAl, campoRicerca)
            Else
               sql = String.Format("SELECT TOP {0} * FROM {1} WHERE DesRisorsa = '{2}' " & _
                                   "AND Data BETWEEN #{3}# AND #{4}# ORDER BY {5} ASC", _
                                   DIM_PAGINA_GRANDE, TAB_STATISTICHE, categoria, dataDal, dataAl, campoRicerca)

               repSql = String.Format("SELECT * FROM {0} WHERE DesRisorsa = '{1}' " & _
                                      "AND Data BETWEEN #{2}# AND #{3}# ORDER BY {4} ASC", _
                                      TAB_STATISTICHE, categoria, dataDal, dataAl, campoRicerca)
            End If

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_STATISTICHE, sql)
         End If

         ' Somma i valori della colonna Quantit‡.
         txtTotQuantit‡.Text = CFormatta.FormattaNumeroDouble2(SommaColonna(DataGrid1, COLONNA_QTA, numRecord))

         ' Somma i valori della colonna Importo.
         txtTotImporto.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_IMPORTO, numRecord))

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

   Private Sub CaricaCampiRic()
      Try
         CampoRicerca.Items.Add("Codice")
         CampoRicerca.Items.Add("Data")
         CampoRicerca.Items.Add("Intestatario")
         CampoRicerca.Items.Add("Risorsa")
         ' A_TODO: MODIFICHE ASD AGON
         CampoRicerca.Items.Add("Tipologia di utilizzo")
         CampoRicerca.Items.Add("Dalle ore")
         CampoRicerca.Items.Add("Alle ore")
         CampoRicerca.Items.Add("Ore prenotate")
         CampoRicerca.Items.Add("Costo risorsa")
         CampoRicerca.Items.Add("Totale")

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

   Private Sub frmStatisticheRisorse_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

   End Sub

   Private Sub frmStatisticheRisorse_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmStatisticheRisorse)

         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         g_frmMain.rtgGestionaleAmica.Visible = False

         ' Distrugge l'oggetto e libera le risorse.
         g_frmStatisticheRisorse.Dispose()
         g_frmStatisticheRisorse = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_GESTIONE_STATISTICHE_CENTRO_SPORTIVO, MODULO_GESTIONE_STATISTICHE_CENTRO_SPORTIVO)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub frmStatisticheRisorse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_STATISTICHE)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 1

         lstRisorse.Items.Add(ITEM_TUTTE)

         ' Carica la lista delle categorie dei piatti.
         CaricaListaRisorse(lstRisorse, TAB_RISORSE)

         ' Seleziona il primo elemento della lista categorie.
         If lstRisorse.Items.Count <> 0 Then
            lstRisorse.SelectedIndex = 0
         End If

         ' Filtra i dati in base al testo digitato.
         FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstRisorse.SelectedItem)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_GESTIONE_STATISTICHE_CENTRO_SPORTIVO, MODULO_GESTIONE_STATISTICHE_CENTRO_SPORTIVO)

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
         Case "Nuovo"
            ' Apre la finestra per l'inserimento di nuovi dati.
            'ApriDati("")

            ' Se nella tabella non ci sono record disattiva i pulsanti.
            'ConvalidaDati()

         Case "Modifica"
            ' Apre la finestra per l'inserimento di nuovi dati.
            'ApriDati(CStr(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)))

         Case "Elimina"
            ' Elimina il valore selezionato.
            'EliminaDati(TAB_STATISTICHE, DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0))

         Case "Stampa"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Stampa, STR_GESTIONE_STATISTICHE_CENTRO_SPORTIVO, MODULO_GESTIONE_STATISTICHE_CENTRO_SPORTIVO)

            StampaDocumento(PERCORSO_REP_STAT_RISORSE, TAB_STATISTICHE, repSql)

         Case "Anteprima"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_GESTIONE_STATISTICHE_CENTRO_SPORTIVO, MODULO_GESTIONE_STATISTICHE_CENTRO_SPORTIVO)

            g_frmMain.ApriReports(repSql, TAB_STATISTICHE, PERCORSO_REP_STAT_RISORSE)

         Case "Primo"
            ' Crea la stringa sql.
            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Id", dimPagina, TAB_STATISTICHE)

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Precedente"
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} WHERE Id < {3} ORDER BY Id DESC) ORDER BY Id", TAB_STATISTICHE, dimPagina, TAB_STATISTICHE, dt.Rows(0)("Id"))

            ' Visualizza la pagina di dati precedente.
            VisualizzaPagina(pagCorrente - 1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Successivo"
            ' Crea la stringa sql.
            sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Id > {2} ORDER BY Id", dimPagina, TAB_STATISTICHE, dt.Rows(dt.Rows.Count - 1)("Id"))

            ' Visualizza la pagina di dati successiva.
            VisualizzaPagina(pagCorrente + 1, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Ultimo"
            Dim num As Integer = numRecord - dimPagina * (numPagine - 1)

            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} ORDER BY Id DESC) ORDER BY Id", TAB_STATISTICHE, num, TAB_STATISTICHE)

            ' Visualizza l'ultima pagina di dati.
            VisualizzaPagina(numPagine, sql)

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

         Case "Aggiorna"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_GESTIONE_STATISTICHE_CENTRO_SPORTIVO, MODULO_GESTIONE_STATISTICHE_CENTRO_SPORTIVO)

            ' Aggiorna la griglia dati.
            AggiornaDati()

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

      End Select
   End Sub

   Private Sub TestoRicerca_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TestoRicerca.TextChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstRisorse.SelectedItem)
   End Sub

   Private Sub CampoRicerca_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CampoRicerca.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstRisorse.SelectedItem)
   End Sub

   Private Sub lstCategorie_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstRisorse.SelectedIndexChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstRisorse.SelectedItem)
   End Sub

   Private Sub dtpDataDal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDataDal.ValueChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstRisorse.SelectedItem)
   End Sub

   Private Sub dtpDataAl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDataAl.ValueChanged
      ' Filtra i dati in base al testo digitato.
      FiltraDati(TestoRicerca.Text, CampoRicerca.Text, lstRisorse.SelectedItem)
   End Sub

End Class
