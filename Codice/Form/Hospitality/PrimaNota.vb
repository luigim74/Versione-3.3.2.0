' Nome form:            PrimaNota
' Autore:               Luigi Montana, Montana Software
' Data creazione:       22/05/2006
' Data ultima modifica: 22/05/2006
' Descrizione:          Prima nota.

Option Strict Off
Option Explicit On 

Imports System.IO
Imports System.Diagnostics
Imports System.Data.OleDb

Public Class PrimaNota
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni "
   Const TAB_PRIMA_NOTA As String = "PrimaNota"
   Const TITOLO_FINESTRA As String = "Prima nota"
   Const COLONNA_ENTRATE_CASSA As Short = 3
   Const COLONNA_USCITE_CASSA As Short = 4
   Const COLONNA_VERS_BANCA As Short = 5
   Const COLONNA_PREV_BANCA As Short = 6
   Const COLONNA_ENTRATE_VARIE As Short = 7
   Const COLONNA_USCITE_VARIE As Short = 8

   'Public AClienti As New Cliente(ConnString)
   Public CFormatta As New ClsFormatta

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

    Dim gridStyle As New DataGridTableStyle
   Dim DescrizioneStyle As New DataGridTextBoxColumn
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner 'ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
   Dim filtroDati As String

#End Region

#Region " Windows Form Designer generated code "

   Public Sub New()
      MyBase.New()

      'This call is required by the Windows Form Designer.
      InitializeComponent()

      'Add any initialization after the InitializeComponent() call
      dt = ds.Tables.Add(TAB_PRIMA_NOTA)
   End Sub

   'Form overrides dispose to clean up the component list.
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not (components Is Nothing) Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(disposing)
   End Sub

   'Required by the Windows Form Designer
   Private components As System.ComponentModel.IContainer

   ' NOTE: The following procedure is required by the Windows Form Designer
   'It can be modified using the Windows Form Designer.  
   'Do not modify it using the code editor.
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
   Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
   Friend WithEvents MenuEntrateCassa As System.Windows.Forms.MenuItem
   Friend WithEvents MenuUsciteCassa As System.Windows.Forms.MenuItem
   Friend WithEvents MenuVersamenti As System.Windows.Forms.MenuItem
   Friend WithEvents MenuPrelievi As System.Windows.Forms.MenuItem
   Friend WithEvents MenuEntrateVarie As System.Windows.Forms.MenuItem
   Friend WithEvents MenuUsciteVarie As System.Windows.Forms.MenuItem
   Friend WithEvents MenuPrimaNota As System.Windows.Forms.ContextMenu
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents cmbData1 As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmbData2 As System.Windows.Forms.DateTimePicker
   Public WithEvents DataGrid1 As System.Windows.Forms.DataGrid
   Friend WithEvents lblAl As System.Windows.Forms.Label
   Friend WithEvents lblDal As System.Windows.Forms.Label
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents txtUsciteVarie As System.Windows.Forms.TextBox
   Public WithEvents txtEntrateVarie As System.Windows.Forms.TextBox
   Public WithEvents txtPrelieviBanca As System.Windows.Forms.TextBox
   Public WithEvents txtVersamentiBanca As System.Windows.Forms.TextBox
   Public WithEvents txtUsciteCassa As System.Windows.Forms.TextBox
   Public WithEvents txtEntrateCassa As System.Windows.Forms.TextBox
   Public WithEvents txtEntrateMenoUsciteVersamentiVarie As System.Windows.Forms.TextBox
   Public WithEvents txtVersamentiMenoPrelievi As System.Windows.Forms.TextBox
   Public WithEvents txtEntrateMenoUsciteCasse As System.Windows.Forms.TextBox
   Public WithEvents txtSomma As System.Windows.Forms.TextBox
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Public WithEvents ToolBar1 As System.Windows.Forms.ToolBar
   Friend WithEvents ToolBarButton9 As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton11 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Primo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Precedente As System.Windows.Forms.ToolBarButton
   Friend WithEvents Successivo As System.Windows.Forms.ToolBarButton
   Friend WithEvents Ultimo As System.Windows.Forms.ToolBarButton
   Friend WithEvents ToolBarButton13 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Sep13 As System.Windows.Forms.ToolBarButton
   Friend WithEvents Inserisci As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrElimina As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrTutti As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrMese As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrAnno As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrPeriodo As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrAggiorna As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrAnteprima As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrStampa As System.Windows.Forms.ToolBarButton
   Friend WithEvents tbrNuovo As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(PrimaNota))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.MenuPrimaNota = New System.Windows.Forms.ContextMenu()
      Me.MenuEntrateCassa = New System.Windows.Forms.MenuItem()
      Me.MenuUsciteCassa = New System.Windows.Forms.MenuItem()
      Me.MenuItem7 = New System.Windows.Forms.MenuItem()
      Me.MenuVersamenti = New System.Windows.Forms.MenuItem()
      Me.MenuPrelievi = New System.Windows.Forms.MenuItem()
      Me.MenuItem8 = New System.Windows.Forms.MenuItem()
      Me.MenuEntrateVarie = New System.Windows.Forms.MenuItem()
      Me.MenuUsciteVarie = New System.Windows.Forms.MenuItem()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.cmbData2 = New System.Windows.Forms.DateTimePicker()
      Me.cmbData1 = New System.Windows.Forms.DateTimePicker()
      Me.lblAl = New System.Windows.Forms.Label()
      Me.lblDal = New System.Windows.Forms.Label()
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.txtSomma = New System.Windows.Forms.TextBox()
      Me.txtEntrateMenoUsciteVersamentiVarie = New System.Windows.Forms.TextBox()
      Me.txtVersamentiMenoPrelievi = New System.Windows.Forms.TextBox()
      Me.txtEntrateMenoUsciteCasse = New System.Windows.Forms.TextBox()
      Me.txtUsciteVarie = New System.Windows.Forms.TextBox()
      Me.txtEntrateVarie = New System.Windows.Forms.TextBox()
      Me.txtPrelieviBanca = New System.Windows.Forms.TextBox()
      Me.txtVersamentiBanca = New System.Windows.Forms.TextBox()
      Me.txtUsciteCassa = New System.Windows.Forms.TextBox()
      Me.txtEntrateCassa = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.tbrNuovo = New System.Windows.Forms.ToolBarButton()
      Me.tbrElimina = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton11 = New System.Windows.Forms.ToolBarButton()
      Me.tbrTutti = New System.Windows.Forms.ToolBarButton()
      Me.tbrMese = New System.Windows.Forms.ToolBarButton()
      Me.tbrAnno = New System.Windows.Forms.ToolBarButton()
      Me.tbrPeriodo = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton9 = New System.Windows.Forms.ToolBarButton()
      Me.Primo = New System.Windows.Forms.ToolBarButton()
      Me.Precedente = New System.Windows.Forms.ToolBarButton()
      Me.Successivo = New System.Windows.Forms.ToolBarButton()
      Me.Ultimo = New System.Windows.Forms.ToolBarButton()
      Me.tbrAggiorna = New System.Windows.Forms.ToolBarButton()
      Me.ToolBarButton13 = New System.Windows.Forms.ToolBarButton()
      Me.tbrAnteprima = New System.Windows.Forms.ToolBarButton()
      Me.tbrStampa = New System.Windows.Forms.ToolBarButton()
      Me.Sep13 = New System.Windows.Forms.ToolBarButton()
      Me.Inserisci = New System.Windows.Forms.ToolBarButton()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      '
      'MenuPrimaNota
      '
      Me.MenuPrimaNota.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuEntrateCassa, Me.MenuUsciteCassa, Me.MenuItem7, Me.MenuVersamenti, Me.MenuPrelievi, Me.MenuItem8, Me.MenuEntrateVarie, Me.MenuUsciteVarie})
      '
      'MenuEntrateCassa
      '
      Me.MenuEntrateCassa.Index = 0
      Me.MenuEntrateCassa.Text = "Entrate Cassa"
      '
      'MenuUsciteCassa
      '
      Me.MenuUsciteCassa.Index = 1
      Me.MenuUsciteCassa.Text = "Uscite Cassa"
      '
      'MenuItem7
      '
      Me.MenuItem7.Index = 2
      Me.MenuItem7.Text = "-"
      '
      'MenuVersamenti
      '
      Me.MenuVersamenti.Index = 3
      Me.MenuVersamenti.Text = "Versamenti"
      '
      'MenuPrelievi
      '
      Me.MenuPrelievi.Index = 4
      Me.MenuPrelievi.Text = "Prelievi"
      '
      'MenuItem8
      '
      Me.MenuItem8.Index = 5
      Me.MenuItem8.Text = "-"
      '
      'MenuEntrateVarie
      '
      Me.MenuEntrateVarie.Index = 6
      Me.MenuEntrateVarie.Text = "Entrate Varie"
      '
      'MenuUsciteVarie
      '
      Me.MenuUsciteVarie.Index = 7
      Me.MenuUsciteVarie.Text = "Uscite Varie"
      '
      'Panel1
      '
      Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.cmbData2)
      Me.Panel1.Controls.Add(Me.cmbData1)
      Me.Panel1.Controls.Add(Me.lblAl)
      Me.Panel1.Controls.Add(Me.lblDal)
      Me.Panel1.Location = New System.Drawing.Point(0, 40)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(699, 38)
      Me.Panel1.TabIndex = 55665
      '
      'cmbData2
      '
      Me.cmbData2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbData2.Enabled = False
      Me.cmbData2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbData2.Location = New System.Drawing.Point(515, 9)
      Me.cmbData2.Name = "cmbData2"
      Me.cmbData2.Size = New System.Drawing.Size(174, 20)
      Me.cmbData2.TabIndex = 55665
      '
      'cmbData1
      '
      Me.cmbData1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbData1.Enabled = False
      Me.cmbData1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmbData1.Location = New System.Drawing.Point(299, 9)
      Me.cmbData1.MaxDate = New Date(9998, 12, 1, 0, 0, 0, 0)
      Me.cmbData1.Name = "cmbData1"
      Me.cmbData1.Size = New System.Drawing.Size(174, 20)
      Me.cmbData1.TabIndex = 55664
      '
      'lblAl
      '
      Me.lblAl.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAl.AutoSize = True
      Me.lblAl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblAl.ForeColor = System.Drawing.Color.White
      Me.lblAl.Location = New System.Drawing.Point(491, 9)
      Me.lblAl.Name = "lblAl"
      Me.lblAl.Size = New System.Drawing.Size(23, 15)
      Me.lblAl.TabIndex = 10
      Me.lblAl.Text = "Al:"
      '
      'lblDal
      '
      Me.lblDal.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDal.AutoSize = True
      Me.lblDal.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDal.ForeColor = System.Drawing.Color.White
      Me.lblDal.Location = New System.Drawing.Point(267, 9)
      Me.lblDal.Name = "lblDal"
      Me.lblDal.Size = New System.Drawing.Size(33, 15)
      Me.lblDal.TabIndex = 9
      Me.lblDal.Text = "Dal:"
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
      Me.DataGrid1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.DataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.DataGrid1.Location = New System.Drawing.Point(0, 78)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(699, 177)
      Me.DataGrid1.TabIndex = 0
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.Gray
      Me.Panel2.Controls.Add(Me.txtSomma)
      Me.Panel2.Controls.Add(Me.txtEntrateMenoUsciteVersamentiVarie)
      Me.Panel2.Controls.Add(Me.txtVersamentiMenoPrelievi)
      Me.Panel2.Controls.Add(Me.txtEntrateMenoUsciteCasse)
      Me.Panel2.Controls.Add(Me.txtUsciteVarie)
      Me.Panel2.Controls.Add(Me.txtEntrateVarie)
      Me.Panel2.Controls.Add(Me.txtPrelieviBanca)
      Me.Panel2.Controls.Add(Me.txtVersamentiBanca)
      Me.Panel2.Controls.Add(Me.txtUsciteCassa)
      Me.Panel2.Controls.Add(Me.txtEntrateCassa)
      Me.Panel2.Controls.Add(Me.Label3)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 256)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(699, 64)
      Me.Panel2.TabIndex = 55673
      '
      'txtSomma
      '
      Me.txtSomma.AcceptsReturn = True
      Me.txtSomma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSomma.BackColor = System.Drawing.SystemColors.Window
      Me.txtSomma.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtSomma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSomma.ForeColor = System.Drawing.Color.DodgerBlue
      Me.txtSomma.Location = New System.Drawing.Point(502, 84)
      Me.txtSomma.MaxLength = 0
      Me.txtSomma.Name = "txtSomma"
      Me.txtSomma.ReadOnly = True
      Me.txtSomma.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSomma.Size = New System.Drawing.Size(179, 20)
      Me.txtSomma.TabIndex = 55682
      Me.txtSomma.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTip1.SetToolTip(Me.txtSomma, "Totale generale")
      Me.txtSomma.Visible = False
      '
      'txtEntrateMenoUsciteVersamentiVarie
      '
      Me.txtEntrateMenoUsciteVersamentiVarie.AcceptsReturn = True
      Me.txtEntrateMenoUsciteVersamentiVarie.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtEntrateMenoUsciteVersamentiVarie.BackColor = System.Drawing.SystemColors.Window
      Me.txtEntrateMenoUsciteVersamentiVarie.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtEntrateMenoUsciteVersamentiVarie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtEntrateMenoUsciteVersamentiVarie.ForeColor = System.Drawing.Color.DodgerBlue
      Me.txtEntrateMenoUsciteVersamentiVarie.Location = New System.Drawing.Point(511, 33)
      Me.txtEntrateMenoUsciteVersamentiVarie.MaxLength = 0
      Me.txtEntrateMenoUsciteVersamentiVarie.Name = "txtEntrateMenoUsciteVersamentiVarie"
      Me.txtEntrateMenoUsciteVersamentiVarie.ReadOnly = True
      Me.txtEntrateMenoUsciteVersamentiVarie.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtEntrateMenoUsciteVersamentiVarie.Size = New System.Drawing.Size(179, 20)
      Me.txtEntrateMenoUsciteVersamentiVarie.TabIndex = 55681
      Me.txtEntrateMenoUsciteVersamentiVarie.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.ToolTip1.SetToolTip(Me.txtEntrateMenoUsciteVersamentiVarie, "Totale varie")
      '
      'txtVersamentiMenoPrelievi
      '
      Me.txtVersamentiMenoPrelievi.AcceptsReturn = True
      Me.txtVersamentiMenoPrelievi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtVersamentiMenoPrelievi.BackColor = System.Drawing.SystemColors.Window
      Me.txtVersamentiMenoPrelievi.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtVersamentiMenoPrelievi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtVersamentiMenoPrelievi.ForeColor = System.Drawing.Color.DodgerBlue
      Me.txtVersamentiMenoPrelievi.Location = New System.Drawing.Point(331, 33)
      Me.txtVersamentiMenoPrelievi.MaxLength = 0
      Me.txtVersamentiMenoPrelievi.Name = "txtVersamentiMenoPrelievi"
      Me.txtVersamentiMenoPrelievi.ReadOnly = True
      Me.txtVersamentiMenoPrelievi.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtVersamentiMenoPrelievi.Size = New System.Drawing.Size(179, 20)
      Me.txtVersamentiMenoPrelievi.TabIndex = 55680
      Me.txtVersamentiMenoPrelievi.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.ToolTip1.SetToolTip(Me.txtVersamentiMenoPrelievi, "Totale banca")
      '
      'txtEntrateMenoUsciteCasse
      '
      Me.txtEntrateMenoUsciteCasse.AcceptsReturn = True
      Me.txtEntrateMenoUsciteCasse.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtEntrateMenoUsciteCasse.BackColor = System.Drawing.SystemColors.Window
      Me.txtEntrateMenoUsciteCasse.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtEntrateMenoUsciteCasse.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtEntrateMenoUsciteCasse.ForeColor = System.Drawing.Color.DodgerBlue
      Me.txtEntrateMenoUsciteCasse.Location = New System.Drawing.Point(151, 33)
      Me.txtEntrateMenoUsciteCasse.MaxLength = 0
      Me.txtEntrateMenoUsciteCasse.Name = "txtEntrateMenoUsciteCasse"
      Me.txtEntrateMenoUsciteCasse.ReadOnly = True
      Me.txtEntrateMenoUsciteCasse.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtEntrateMenoUsciteCasse.Size = New System.Drawing.Size(179, 20)
      Me.txtEntrateMenoUsciteCasse.TabIndex = 55679
      Me.txtEntrateMenoUsciteCasse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.ToolTip1.SetToolTip(Me.txtEntrateMenoUsciteCasse, "Totale cassa")
      '
      'txtUsciteVarie
      '
      Me.txtUsciteVarie.AcceptsReturn = True
      Me.txtUsciteVarie.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtUsciteVarie.BackColor = System.Drawing.SystemColors.Window
      Me.txtUsciteVarie.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtUsciteVarie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtUsciteVarie.ForeColor = System.Drawing.Color.Red
      Me.txtUsciteVarie.Location = New System.Drawing.Point(601, 12)
      Me.txtUsciteVarie.MaxLength = 0
      Me.txtUsciteVarie.Name = "txtUsciteVarie"
      Me.txtUsciteVarie.ReadOnly = True
      Me.txtUsciteVarie.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtUsciteVarie.Size = New System.Drawing.Size(89, 20)
      Me.txtUsciteVarie.TabIndex = 55678
      Me.txtUsciteVarie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTip1.SetToolTip(Me.txtUsciteVarie, "Totale uscite varie")
      '
      'txtEntrateVarie
      '
      Me.txtEntrateVarie.AcceptsReturn = True
      Me.txtEntrateVarie.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtEntrateVarie.BackColor = System.Drawing.SystemColors.Window
      Me.txtEntrateVarie.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtEntrateVarie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtEntrateVarie.ForeColor = System.Drawing.Color.DodgerBlue
      Me.txtEntrateVarie.Location = New System.Drawing.Point(511, 12)
      Me.txtEntrateVarie.MaxLength = 0
      Me.txtEntrateVarie.Name = "txtEntrateVarie"
      Me.txtEntrateVarie.ReadOnly = True
      Me.txtEntrateVarie.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtEntrateVarie.Size = New System.Drawing.Size(89, 20)
      Me.txtEntrateVarie.TabIndex = 55677
      Me.txtEntrateVarie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTip1.SetToolTip(Me.txtEntrateVarie, "Totale entrate varie")
      '
      'txtPrelieviBanca
      '
      Me.txtPrelieviBanca.AcceptsReturn = True
      Me.txtPrelieviBanca.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtPrelieviBanca.BackColor = System.Drawing.SystemColors.Window
      Me.txtPrelieviBanca.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPrelieviBanca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPrelieviBanca.ForeColor = System.Drawing.Color.Red
      Me.txtPrelieviBanca.Location = New System.Drawing.Point(421, 12)
      Me.txtPrelieviBanca.MaxLength = 0
      Me.txtPrelieviBanca.Name = "txtPrelieviBanca"
      Me.txtPrelieviBanca.ReadOnly = True
      Me.txtPrelieviBanca.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPrelieviBanca.Size = New System.Drawing.Size(89, 20)
      Me.txtPrelieviBanca.TabIndex = 55676
      Me.txtPrelieviBanca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTip1.SetToolTip(Me.txtPrelieviBanca, "Totale prelievi banca")
      '
      'txtVersamentiBanca
      '
      Me.txtVersamentiBanca.AcceptsReturn = True
      Me.txtVersamentiBanca.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtVersamentiBanca.BackColor = System.Drawing.SystemColors.Window
      Me.txtVersamentiBanca.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtVersamentiBanca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtVersamentiBanca.ForeColor = System.Drawing.Color.DodgerBlue
      Me.txtVersamentiBanca.Location = New System.Drawing.Point(331, 12)
      Me.txtVersamentiBanca.MaxLength = 0
      Me.txtVersamentiBanca.Name = "txtVersamentiBanca"
      Me.txtVersamentiBanca.ReadOnly = True
      Me.txtVersamentiBanca.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtVersamentiBanca.Size = New System.Drawing.Size(89, 20)
      Me.txtVersamentiBanca.TabIndex = 55675
      Me.txtVersamentiBanca.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTip1.SetToolTip(Me.txtVersamentiBanca, "Totale versamenti banca")
      '
      'txtUsciteCassa
      '
      Me.txtUsciteCassa.AcceptsReturn = True
      Me.txtUsciteCassa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtUsciteCassa.BackColor = System.Drawing.SystemColors.Window
      Me.txtUsciteCassa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtUsciteCassa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtUsciteCassa.ForeColor = System.Drawing.Color.Red
      Me.txtUsciteCassa.Location = New System.Drawing.Point(241, 12)
      Me.txtUsciteCassa.MaxLength = 0
      Me.txtUsciteCassa.Name = "txtUsciteCassa"
      Me.txtUsciteCassa.ReadOnly = True
      Me.txtUsciteCassa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtUsciteCassa.Size = New System.Drawing.Size(89, 20)
      Me.txtUsciteCassa.TabIndex = 55674
      Me.txtUsciteCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTip1.SetToolTip(Me.txtUsciteCassa, "Totale uscite cassa")
      '
      'txtEntrateCassa
      '
      Me.txtEntrateCassa.AcceptsReturn = True
      Me.txtEntrateCassa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtEntrateCassa.BackColor = System.Drawing.SystemColors.Window
      Me.txtEntrateCassa.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtEntrateCassa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtEntrateCassa.ForeColor = System.Drawing.Color.DodgerBlue
      Me.txtEntrateCassa.Location = New System.Drawing.Point(151, 12)
      Me.txtEntrateCassa.MaxLength = 0
      Me.txtEntrateCassa.Name = "txtEntrateCassa"
      Me.txtEntrateCassa.ReadOnly = True
      Me.txtEntrateCassa.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtEntrateCassa.Size = New System.Drawing.Size(89, 20)
      Me.txtEntrateCassa.TabIndex = 55673
      Me.txtEntrateCassa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ToolTip1.SetToolTip(Me.txtEntrateCassa, "Totale entrate cassa")
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.White
      Me.Label3.Location = New System.Drawing.Point(60, 10)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(88, 32)
      Me.Label3.TabIndex = 9
      Me.Label3.Text = "TOTALI:"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = ""
      '
      'ToolBar1
      '
      Me.ToolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.tbrNuovo, Me.tbrElimina, Me.ToolBarButton11, Me.tbrTutti, Me.tbrMese, Me.tbrAnno, Me.tbrPeriodo, Me.ToolBarButton9, Me.Primo, Me.Precedente, Me.Successivo, Me.Ultimo, Me.tbrAggiorna, Me.ToolBarButton13, Me.tbrAnteprima, Me.tbrStampa, Me.Sep13, Me.Inserisci})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(699, 34)
      Me.ToolBar1.TabIndex = 0
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Wrappable = False
      '
      'tbrNuovo
      '
      Me.tbrNuovo.DropDownMenu = Me.MenuPrimaNota
      Me.tbrNuovo.ImageIndex = 5
      Me.tbrNuovo.Name = "tbrNuovo"
      Me.tbrNuovo.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton
      Me.tbrNuovo.Tag = "Nuovo"
      Me.tbrNuovo.Text = "Nuovo"
      Me.tbrNuovo.ToolTipText = "Nuovo"
      '
      'tbrElimina
      '
      Me.tbrElimina.ImageIndex = 1
      Me.tbrElimina.Name = "tbrElimina"
      Me.tbrElimina.Tag = "Elimina"
      Me.tbrElimina.Text = "Elimina"
      Me.tbrElimina.ToolTipText = "Elimina"
      '
      'ToolBarButton11
      '
      Me.ToolBarButton11.Name = "ToolBarButton11"
      Me.ToolBarButton11.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbrTutti
      '
      Me.tbrTutti.ImageIndex = 0
      Me.tbrTutti.Name = "tbrTutti"
      Me.tbrTutti.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrTutti.Tag = "Tutti"
      Me.tbrTutti.Text = "Tutti"
      Me.tbrTutti.ToolTipText = "Visualizza tutti i documenti"
      '
      'tbrMese
      '
      Me.tbrMese.ImageIndex = 6
      Me.tbrMese.Name = "tbrMese"
      Me.tbrMese.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrMese.Tag = "Mese"
      Me.tbrMese.Text = "Mese"
      Me.tbrMese.ToolTipText = "Visualizza documenti del mese corrente"
      '
      'tbrAnno
      '
      Me.tbrAnno.ImageIndex = 7
      Me.tbrAnno.Name = "tbrAnno"
      Me.tbrAnno.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrAnno.Tag = "Anno"
      Me.tbrAnno.Text = "Anno"
      Me.tbrAnno.ToolTipText = "Visualizza documenti dell'anno corrente"
      '
      'tbrPeriodo
      '
      Me.tbrPeriodo.ImageIndex = 8
      Me.tbrPeriodo.Name = "tbrPeriodo"
      Me.tbrPeriodo.Style = System.Windows.Forms.ToolBarButtonStyle.ToggleButton
      Me.tbrPeriodo.Tag = "Periodo"
      Me.tbrPeriodo.Text = "Periodo"
      Me.tbrPeriodo.ToolTipText = "Visualizza documenti del periodo selezionato"
      '
      'ToolBarButton9
      '
      Me.ToolBarButton9.Name = "ToolBarButton9"
      Me.ToolBarButton9.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
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
      Me.tbrAggiorna.ImageIndex = 2
      Me.tbrAggiorna.Name = "tbrAggiorna"
      Me.tbrAggiorna.Tag = "Aggiorna"
      Me.tbrAggiorna.ToolTipText = "Aggiorna"
      '
      'ToolBarButton13
      '
      Me.ToolBarButton13.Name = "ToolBarButton13"
      Me.ToolBarButton13.Style = System.Windows.Forms.ToolBarButtonStyle.Separator
      '
      'tbrAnteprima
      '
      Me.tbrAnteprima.ImageIndex = 3
      Me.tbrAnteprima.Name = "tbrAnteprima"
      Me.tbrAnteprima.Tag = "Anteprima"
      Me.tbrAnteprima.ToolTipText = "Anteprima di stampa"
      '
      'tbrStampa
      '
      Me.tbrStampa.ImageIndex = 4
      Me.tbrStampa.Name = "tbrStampa"
      Me.tbrStampa.Tag = "Stampa"
      Me.tbrStampa.ToolTipText = "Stampa"
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
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'PrimaNota
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(699, 320)
      Me.Controls.Add(Me.ToolBar1)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.Panel1)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.ForeColor = System.Drawing.Color.Black
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "PrimaNota"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
      Me.Text = "Prima Nota"
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
      CType(Me.DataGrid1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel2.ResumeLayout(False)
      Me.Panel2.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

#Region "Procedure "

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("FiltroPNota") <> "" Then
            filtroDati = DatiConfig.GetValue("FiltroPNota")
         Else
            filtroDati = "Tutti"
         End If

         If DatiConfig.GetValue("WSPNota") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSPNota") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("APNota") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("APNota"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LPNota") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LPNota"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("PNotaX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("PNotaX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("PNotaY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("PNotaY")))
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

         DatiConfig.SetValue("FiltroPNota", filtroDati)
         DatiConfig.SetValue("WSPNota", Me.WindowState)
         DatiConfig.SetValue("PNotaX", Me.Location.X)
         DatiConfig.SetValue("PNotaY", Me.Location.Y)
         DatiConfig.SetValue("APNota", Me.Height)
         DatiConfig.SetValue("LPNota", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.PrimaNota
               If operatore.ContPrimaNota = VALORE_LETTURA Then
                  tbrNuovo.Enabled = False
                  tbrElimina.Enabled = False
               Else
                  tbrNuovo.Enabled = True
                  tbrElimina.Enabled = True
               End If
         End Select

         Return tbrNuovo.Enabled

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return True
      End Try

   End Function

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
         ' Calcola il numero delle pagine da visualizzare.
         LeggiNumPagine(TAB_PRIMA_NOTA)

         ' Collega la tabella clienti al controllo griglia dati.
         DataGrid1.DataSource = dt

         ' Visualizza la prima pagina di dati.
         VisualizzaPagina(pagCorrente, sql)

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

   Public Sub ImpostaComandi()
      If DataGrid1.VisibleRowCount <> 0 Then
         'Disattiva i pulsanti appropriati.
         tbrElimina.Enabled = True
         tbrAggiorna.Enabled = True
      Else
         ' Disattiva i pulsanti appropriati.
         tbrElimina.Enabled = False
         tbrAggiorna.Enabled = False
      End If
   End Sub

   Public Sub ConvalidaDati()
      If ImpostaFunzioniOperatore(Finestra.PrimaNota) = True Then
         ImpostaComandi()
      End If

   End Sub

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String)
      Try

         If PrintDialog1.ShowDialog() = DialogResult.OK Then

            'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
            'Dim cn As New OleDbConnection(ConnString)

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

   Private Sub FormResize(ByVal larghezza As Short, ByVal altezza As Short)
      Try
         ' Imposta le dimensioni standard del form.
         Me.Width = larghezza
         Me.Height = altezza

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub AttivaDate()
      cmbData1.Enabled = True
      cmbData2.Enabled = True
   End Sub

   Private Sub DisattivaDate()
      cmbData1.Enabled = False
      cmbData2.Enabled = False
   End Sub

   Public Sub CaricaGriglia(ByVal CampoData As String)
      Try
         Dim Sql As String

         Dim Anno As String = Year(Now)
         Dim Mese As String = Month(Now)

         Select Case CampoData
            Case "Tutti"
               Sql = String.Format("SELECT * FROM {0} ORDER BY Data ASC", TAB_PRIMA_NOTA)

            Case "Anno"
               Dim Appo1 As String = CFormatta.FormattaData("01/01/" & Anno)
               Dim UltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, 12)
               Dim Appo2 As String = CFormatta.FormattaData(UltimoGiornoAnno & "/12/" & Anno)

               Sql = String.Format("SELECT * FROM {0} WHERE Data BETWEEN #{1}# AND #{2}# ORDER BY Data ASC", TAB_PRIMA_NOTA, Appo1, Appo2)

            Case "Mese"
               Dim Appo1 As String = CFormatta.FormattaData("01/" & Mese & "/" & Anno)
               Dim UltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, Mese)
               Dim Appo2 As String = CFormatta.FormattaData(UltimoGiornoAnno & "/" & Mese & "/" & Anno)

               'Sql = "SELECT * FROM " & TAB_PRIMA_NOTA & " WHERE Data > #" & Appo1 & "# AND Data < #" & Appo2 & "# OR Data = #" & Appo1 & "# OR Data = #" & Appo2 & "# ORDER BY Data"
               Sql = String.Format("SELECT * FROM {0} WHERE Data BETWEEN #{1}# AND #{2}# ORDER BY Data ASC", TAB_PRIMA_NOTA, Appo1, Appo2)

            Case "Periodo"
               Dim Appo1 As String = CFormatta.FormattaData(cmbData1.Text)
               Dim Appo2 As String = CFormatta.FormattaData(cmbData2.Text)

               Sql = String.Format("SELECT * FROM {0} WHERE Data BETWEEN #{1}# AND #{2}# ORDER BY Data ASC", TAB_PRIMA_NOTA, Appo1, Appo2)

         End Select

         ' Salva la query per i reports.
         repSql = Sql
         ' Legge i dati e ottiene il numero totale dei record.
         LeggiDati("(" & Sql & ")", Sql)

         ConvalidaDati()

         AggIntGriglia()

         SommaImporti()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()
      End Try
   End Sub

   Public Sub SommaImporti()
      Try
         Dim AppoEntrateCasse As Double = SommaColonna(DataGrid1, COLONNA_ENTRATE_CASSA, numRecord)
         Dim AppoUsciteCassa As Double = SommaColonna(DataGrid1, COLONNA_USCITE_CASSA, numRecord)
         Dim AppoVersamentiBanca As Double = SommaColonna(DataGrid1, COLONNA_VERS_BANCA, numRecord)
         Dim AppoPrelieviBanca As Double = SommaColonna(DataGrid1, COLONNA_PREV_BANCA, numRecord)
         Dim AppoEntrateVarie As Double = SommaColonna(DataGrid1, COLONNA_ENTRATE_VARIE, numRecord)
         Dim AppoUsciteVarie As Double = SommaColonna(DataGrid1, COLONNA_USCITE_VARIE, numRecord)

         txtEntrateCassa.Text = CFormatta.FormattaEuro(AppoEntrateCasse)
         txtUsciteCassa.Text = CFormatta.FormattaEuro(AppoUsciteCassa)
         txtVersamentiBanca.Text = CFormatta.FormattaEuro(AppoVersamentiBanca)
         txtPrelieviBanca.Text = CFormatta.FormattaEuro(AppoPrelieviBanca)
         txtEntrateVarie.Text = CFormatta.FormattaEuro(AppoEntrateVarie)
         txtUsciteVarie.Text = CFormatta.FormattaEuro(AppoUsciteVarie)

         txtEntrateMenoUsciteCasse.Text = CFormatta.FormattaEuro(AppoEntrateCasse - AppoUsciteCassa)
         txtVersamentiMenoPrelievi.Text = CFormatta.FormattaEuro(AppoVersamentiBanca - AppoPrelieviBanca)
         txtEntrateMenoUsciteVersamentiVarie.Text = CFormatta.FormattaEuro(AppoEntrateVarie - AppoUsciteVarie)

         'txtSomma.Text = (AppoEntrateCasse - AppoUsciteCassa) + (AppoVersamentiBanca - AppoPrelieviBanca) + (AppoEntrateVarie - AppoUsciteVarie)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub AzzeraTXT()
      Try
         txtEntrateCassa.Text = 0
         txtUsciteCassa.Text = 0
         txtVersamentiBanca.Text = 0
         txtPrelieviBanca.Text = 0
         txtEntrateVarie.Text = 0
         txtUsciteVarie.Text = 0
         txtEntrateMenoUsciteCasse.Text = 0
         txtVersamentiMenoPrelievi.Text = 0
         txtEntrateMenoUsciteVersamentiVarie.Text = 0
         txtSomma.Text = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub EliminaRecord()
      Try
         Dim IdSelezionato As Integer = DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0)

         If IdSelezionato <> 0 Then
            Dim Appo As Integer = MsgBox("Si desidera eliminare la nota: """ & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) & _
                                         """?" & vbCrLf & vbCrLf & "Non sarà più possibile recuperare i dati.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Conferma Eliminazione")
            If Appo = vbYes Then
               'comando sql per recupero dei record
               Dim Sql As String = "DELETE * FROM " & TAB_PRIMA_NOTA & " WHERE id=" & IdSelezionato & ";"

               cn.Open()
               cmd = New OleDbCommand(Sql, cn)

               Dim records As Integer = cmd.ExecuteNonQuery

               ' Registra loperazione effettuata dall'operatore identificato.
               Dim strDescrizione As String = "(" & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2) & ")"
               g_frmMain.RegistraOperazione(TipoOperazione.Elimina, strDescrizione, MODULO_CONTABILITA_PRIMA_NOTA)

            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()
      End Try
   End Sub

   Private Sub ImpostaGriglia(ByVal tabella As String)
      Try
         Dim gridStyle As New DataGridTableStyle
         gridStyle.MappingName = tabella

         'Id(-Codice)
         Dim codiceStyle As New DataGridTextBoxColumn
         codiceStyle.MappingName = "Id"
         codiceStyle.HeaderText = ""
         codiceStyle.Width = 0
         codiceStyle.NullText = ""
         codiceStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' data
         Dim DataStyle As New DataGridTextBoxColumn
         DataStyle.MappingName = "Data"
         DataStyle.HeaderText = "Data"
         DataStyle.Width = 80
         DataStyle.NullText = ""
         DataStyle.Alignment = HorizontalAlignment.Left
         DataStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(DataStyle)
         ' Descrizione
         'Dim DescrizioneStyle As New DataGridTextBoxColumn
         DescrizioneStyle.MappingName = "Descrizione"
         DescrizioneStyle.HeaderText = "Descrizione"
         DescrizioneStyle.Width = Me.Width - 680
         DescrizioneStyle.NullText = ""
         DescrizioneStyle.Alignment = HorizontalAlignment.Left
         DescrizioneStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(DescrizioneStyle)
         ' EntrateCassa
         Dim EntrateCassaStyle As New DataGridTextBoxColumn
         EntrateCassaStyle.MappingName = "EntrateCassa"
         EntrateCassaStyle.HeaderText = "Entrate Cassa "
         EntrateCassaStyle.Width = 90
         EntrateCassaStyle.NullText = ""
         EntrateCassaStyle.Format = "##,##0.00"
         EntrateCassaStyle.Alignment = HorizontalAlignment.Right
         EntrateCassaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(EntrateCassaStyle)
         ' UsciteCassa
         Dim UsciteCassaStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         UsciteCassaStyle.MappingName = "UsciteCassa"
         UsciteCassaStyle.HeaderText = "Uscite Cassa "
         UsciteCassaStyle.Width = 90
         UsciteCassaStyle.NullText = ""
         UsciteCassaStyle.Format = "##,##0.00"
         UsciteCassaStyle.Alignment = HorizontalAlignment.Right
         UsciteCassaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(UsciteCassaStyle)
         ' VersamentiBanca
         Dim VersamentiBancaStyle As New DataGridTextBoxColumn
         VersamentiBancaStyle.MappingName = "VersamentiBanca"
         VersamentiBancaStyle.HeaderText = "Versam. Banca "
         VersamentiBancaStyle.Width = 90
         VersamentiBancaStyle.NullText = ""
         VersamentiBancaStyle.Format = "##,##0.00"
         VersamentiBancaStyle.Alignment = HorizontalAlignment.Right
         VersamentiBancaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(VersamentiBancaStyle)
         ' PrelieviBanca
         Dim PrelieviBancaStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         PrelieviBancaStyle.MappingName = "PrelieviBanca"
         PrelieviBancaStyle.HeaderText = "Prelievi Banca "
         PrelieviBancaStyle.Width = 90
         PrelieviBancaStyle.NullText = ""
         PrelieviBancaStyle.Format = "##,##0.00"
         PrelieviBancaStyle.Alignment = HorizontalAlignment.Right
         PrelieviBancaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(PrelieviBancaStyle)
         ' Entrate varie
         Dim EntrateVarieStyle As New DataGridTextBoxColumn
         EntrateVarieStyle.MappingName = "EntrateVarie"
         EntrateVarieStyle.HeaderText = "Entrate Varie "
         EntrateVarieStyle.Width = 90
         EntrateVarieStyle.NullText = ""
         EntrateVarieStyle.Format = "##,##0.00"
         EntrateVarieStyle.Alignment = HorizontalAlignment.Right
         EntrateVarieStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(EntrateVarieStyle)
         ' Uscite varie
         Dim UsciteVarieStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         UsciteVarieStyle.MappingName = "UsciteVarie"
         UsciteVarieStyle.HeaderText = "Uscite Varie"
         UsciteVarieStyle.Width = 90
         UsciteVarieStyle.NullText = ""
         UsciteVarieStyle.Format = "##,##0.00"
         UsciteVarieStyle.Alignment = HorizontalAlignment.Right
         UsciteVarieStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(UsciteVarieStyle)

         DataGrid1.TableStyles.Clear()
         DataGrid1.TableStyles.Add(gridStyle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub AggIntGriglia()
      Try
         If DataGrid1.VisibleRowCount <> 0 Then
            DataGrid1.CaptionText = Strings.UCase(DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1) & " - " & DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2))
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

   Public Sub ApriInsDati(ByVal titoloFinestra As String)
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Nuovo, titoloFinestra & " - " & STR_CONTABILITA_PRIMA_NOTA, MODULO_CONTABILITA_PRIMA_NOTA)

         Dim frm As New InPrimaNota

         frm.Text = titoloFinestra
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

#End Region

#Region "Funzioni "

   Private Function CalcolaSomma(ByVal Campo As String) As Decimal
      Dim closeOnExit As Boolean
      Dim Sql As String

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         Dim filtro As String
         If tbrMese.Pushed = True Then
            filtro = "Mese"
            Exit Function
         ElseIf tbrAnno.Pushed = True Then
            filtro = "Anno"
            Exit Function
         ElseIf tbrPeriodo.Pushed = True Then
            filtro = "Periodo"
            Exit Function
         Else
            filtro = "Tutti"
            Exit Function
         End If

         Dim Anno As String = Year(Now)
         Dim Mese As String = Month(Now)

         Select Case filtro
            Case "Tutti"
               Sql = String.Format("SELECT SUM({0}) AS Somma FROM {1}", Campo, TAB_PRIMA_NOTA)

            Case "Anno"
               Dim Appo1 As String = CFormatta.FormattaData("01/01/" & Anno)
               Dim UltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, 12)
               Dim Appo2 As String = CFormatta.FormattaData(UltimoGiornoAnno & "\12\" & Anno)

               Sql = String.Format("SELECT SUM({0}) AS Somma FROM {1} WHERE Data BETWEEN #{2}# AND #{3}#", Campo, TAB_PRIMA_NOTA, Appo1, Appo2)

            Case "Mese"
               Dim Appo1 As String = CFormatta.FormattaData("01/" & Mese & "/" & Anno)
               Dim UltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, Mese)
               Dim Appo2 As String = CFormatta.FormattaData(UltimoGiornoAnno & "\" & Mese & "\" & Anno)
               Dim CalcoloGiorno2 As String = "28/" & Mese & "/" & Anno

               Sql = String.Format("SELECT SUM({0}) AS Somma FROM {1} WHERE Data BETWEEN #{2}# AND #{3}#", Campo, TAB_PRIMA_NOTA, Appo1, Appo2)

            Case "Periodo"
               Dim Appo1 As String = CFormatta.FormattaData(cmbData1.Text)
               Dim Appo2 As String = CFormatta.FormattaData(cmbData2.Text)

               Sql = String.Format("SELECT SUM({0}) AS Somma FROM {1} WHERE Data BETWEEN #{2}# AND #{3}#", Campo, TAB_PRIMA_NOTA, Appo1, Appo2)
            Case Else
               Exit Function

         End Select

         cmd = New OleDbCommand(Sql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection)

         Do While dr.Read
            If IsDBNull(dr("Somma")) Then Exit Do
            CalcolaSomma = CFormatta.FormattaEuro(dr("Somma"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()
      End Try
   End Function

#End Region

#Region "Eventi "

   Private Sub PrimaNota_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = True

   End Sub

   Private Sub PrimaNota_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmPrimaNota)

         ' Distrugge l'oggetto e libera le risorse.
         g_frmPrimaNota.Dispose()
         g_frmPrimaNota = Nothing

         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         g_frmMain.rtgGestionaleAmica.Visible = False

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTABILITA_PRIMA_NOTA, MODULO_CONTABILITA_PRIMA_NOTA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub PrimaNota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

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
         End Select

         ' Imposta griglia
         ImpostaGriglia(TAB_PRIMA_NOTA)

         ' Carica griglia dati
         CaricaGriglia(filtroDati)

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_CONTABILITA_PRIMA_NOTA, MODULO_CONTABILITA_PRIMA_NOTA)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub MenuEntrateCassa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEntrateCassa.Click
      ApriInsDati("Entrate Cassa")
   End Sub

   Private Sub MenuUsciteCassa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUsciteCassa.Click
      ApriInsDati("Uscite Cassa")
   End Sub

   Private Sub MenuVersamenti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuVersamenti.Click
      ApriInsDati("Versamenti Banca")
   End Sub

   Private Sub MenuPrelievi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuPrelievi.Click
      ApriInsDati("Prelievi Banca")
   End Sub

   Private Sub MenuEntrateVarie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuEntrateVarie.Click
      ApriInsDati("Entrate Varie")
   End Sub

   Private Sub MenuUsciteVarie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuUsciteVarie.Click
      ApriInsDati("Uscite Varie")
   End Sub

   Private Sub cmbData1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbData1.ValueChanged
      Try
         CaricaGriglia("Periodo")
         SommaImporti()
         AggIntGriglia()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmbData2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbData2.ValueChanged
      Try
         CaricaGriglia("Periodo")
         SommaImporti()
         AggIntGriglia()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub DataGrid1_CurrentCellChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGrid1.CurrentCellChanged
      Try
         AggIntGriglia()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub PrimaNota_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      DescrizioneStyle.Width = Me.Width - 680

      If DescrizioneStyle.Width < 100 Then
         DescrizioneStyle.Width = 100
         Return
      End If
   End Sub

   Private Sub ToolBar1_ButtonClick_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolBarButtonClickEventArgs) Handles ToolBar1.ButtonClick
      Try
         Select Case e.Button.Tag
            Case "Nuovo"
               MenuEntrateCassa.PerformClick()

            Case "Elimina"
               EliminaRecord()
               If tbrMese.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  CaricaGriglia("Mese")
               ElseIf tbrAnno.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  CaricaGriglia("Anno")
               ElseIf tbrPeriodo.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  CaricaGriglia("Periodo")
               Else
                  ' Aggiorna la griglia dati.
                  CaricaGriglia("Tutti")
               End If

            Case "Tutti"
               tbrPeriodo.Pushed = False
               tbrMese.Pushed = False
               tbrAnno.Pushed = False
               DisattivaDate()
               filtroDati = "Tutti"
               CaricaGriglia("Tutti")

            Case "Mese"
               tbrTutti.Pushed = False
               tbrPeriodo.Pushed = False
               tbrAnno.Pushed = False
               DisattivaDate()
               filtroDati = "Mese"
               CaricaGriglia("Mese")

            Case "Anno"
               tbrTutti.Pushed = False
               tbrPeriodo.Pushed = False
               tbrMese.Pushed = False
               DisattivaDate()
               filtroDati = "Anno"
               CaricaGriglia("Anno")

            Case "Periodo"
               tbrTutti.Pushed = False
               tbrMese.Pushed = False
               tbrAnno.Pushed = False
               AttivaDate()
               filtroDati = "Periodo"
               CaricaGriglia("Periodo")

            Case "Aggiorna"
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_CONTABILITA_PRIMA_NOTA, MODULO_CONTABILITA_PRIMA_NOTA)

               If tbrMese.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  CaricaGriglia("Mese")
               ElseIf tbrAnno.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  CaricaGriglia("Anno")
               ElseIf tbrPeriodo.Pushed = True Then
                  ' Aggiorna la griglia dati.
                  CaricaGriglia("Periodo")
               Else
                  ' Aggiorna la griglia dati.
                  CaricaGriglia("Tutti")
               End If

            Case "Stampa"
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Stampa, STR_CONTABILITA_PRIMA_NOTA, MODULO_CONTABILITA_PRIMA_NOTA)

               StampaDocumento(PERCORSO_REP_PRIMANOTA, TAB_PRIMA_NOTA, repSql)

            Case "Anteprima"
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_CONTABILITA_PRIMA_NOTA, MODULO_CONTABILITA_PRIMA_NOTA)

               g_frmMain.ApriReports(repSql, TAB_PRIMA_NOTA, PERCORSO_REP_PRIMANOTA)

         End Select

      Catch ex As Exception

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

#End Region

End Class
