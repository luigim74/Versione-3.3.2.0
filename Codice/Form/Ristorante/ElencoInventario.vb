' Nome form:            frmElencoInventario
' Autore:               Luigi Montana, Montana Software
' Data creazione:       22/10/2006
' Data ultima modifica: 23/10/2006
' Descrizione:          Elenco inventario di magazzino.

Option Strict Off
Option Explicit On 

Imports System.Data.OleDb

Public Class ElencoInventario
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"

   Const TITOLO_FINESTRA As String = "Inventario di magazzino"
   Const TAB_ARTICOLI = "Articoli"
   Const COLONNA_VAL_CARICO As Short = 12
   Const COLONNA_VAL_SCARICO As Short = 13
   Const COLONNA_VAL_ATTUALE As Short = 14

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnStringAnagrafiche)
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

#End Region

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      dt = ds.Tables.Add(TAB_ARTICOLI)

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
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents Panel2 As System.Windows.Forms.Panel
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
   Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents txtTotValScarico As System.Windows.Forms.TextBox
   Public WithEvents txtTotValCarico As System.Windows.Forms.TextBox
   Public WithEvents txtTotValAttuale As System.Windows.Forms.TextBox
   Friend WithEvents Carico As System.Windows.Forms.ToolBarButton
   Friend WithEvents Scarico As System.Windows.Forms.ToolBarButton
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ElencoInventario))
      Me.ToolBar1 = New System.Windows.Forms.ToolBar()
      Me.Carico = New System.Windows.Forms.ToolBarButton()
      Me.Scarico = New System.Windows.Forms.ToolBarButton()
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
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.DataGrid1 = New System.Windows.Forms.DataGrid()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.CheckBox2 = New System.Windows.Forms.CheckBox()
      Me.ComboBox2 = New System.Windows.Forms.ComboBox()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.ComboBox1 = New System.Windows.Forms.ComboBox()
      Me.CheckBox1 = New System.Windows.Forms.CheckBox()
      Me.CampoRicerca = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.TestoRicerca = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.Panel2 = New System.Windows.Forms.Panel()
      Me.txtTotValScarico = New System.Windows.Forms.TextBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.txtTotValCarico = New System.Windows.Forms.TextBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.txtTotValAttuale = New System.Windows.Forms.TextBox()
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
      Me.ToolBar1.Buttons.AddRange(New System.Windows.Forms.ToolBarButton() {Me.Carico, Me.Scarico, Me.ToolBarButton4, Me.Primo, Me.Precedente, Me.Successivo, Me.Ultimo, Me.ToolBarButton7, Me.Aggiorna, Me.ToolBarButton1, Me.Anteprima, Me.Stampa})
      Me.ToolBar1.Divider = False
      Me.ToolBar1.DropDownArrows = True
      Me.ToolBar1.ImageList = Me.ImageList1
      Me.ToolBar1.Location = New System.Drawing.Point(0, 0)
      Me.ToolBar1.Name = "ToolBar1"
      Me.ToolBar1.ShowToolTips = True
      Me.ToolBar1.Size = New System.Drawing.Size(580, 26)
      Me.ToolBar1.TabIndex = 2
      Me.ToolBar1.TextAlign = System.Windows.Forms.ToolBarTextAlign.Right
      Me.ToolBar1.Wrappable = False
      '
      'Carico
      '
      Me.Carico.ImageIndex = 10
      Me.Carico.Name = "Carico"
      Me.Carico.Tag = "Carico"
      Me.Carico.Text = "Carico"
      Me.Carico.ToolTipText = "Carico"
      '
      'Scarico
      '
      Me.Scarico.ImageIndex = 11
      Me.Scarico.Name = "Scarico"
      Me.Scarico.Tag = "Scarico"
      Me.Scarico.Text = "Scarico"
      Me.Scarico.ToolTipText = "Scarico"
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
      Me.DataGrid1.Location = New System.Drawing.Point(0, 64)
      Me.DataGrid1.Name = "DataGrid1"
      Me.DataGrid1.ReadOnly = True
      Me.DataGrid1.Size = New System.Drawing.Size(580, 262)
      Me.DataGrid1.TabIndex = 0
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.Color.Gray
      Me.Panel1.Controls.Add(Me.Label7)
      Me.Panel1.Controls.Add(Me.Label5)
      Me.Panel1.Controls.Add(Me.CheckBox2)
      Me.Panel1.Controls.Add(Me.ComboBox2)
      Me.Panel1.Controls.Add(Me.Label4)
      Me.Panel1.Controls.Add(Me.ComboBox1)
      Me.Panel1.Controls.Add(Me.CheckBox1)
      Me.Panel1.Controls.Add(Me.CampoRicerca)
      Me.Panel1.Controls.Add(Me.Label2)
      Me.Panel1.Controls.Add(Me.Label1)
      Me.Panel1.Controls.Add(Me.TestoRicerca)
      Me.Panel1.Controls.Add(Me.Label3)
      Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Panel1.Location = New System.Drawing.Point(0, 26)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(580, 38)
      Me.Panel1.TabIndex = 0
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.Label7.Location = New System.Drawing.Point(332, 72)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(120, 17)
      Me.Label7.TabIndex = 246
      Me.Label7.Text = "Articoli sotto scorta"
      Me.Label7.Visible = False
      '
      'Label5
      '
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.Label5.Location = New System.Drawing.Point(2, 72)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(222, 17)
      Me.Label5.TabIndex = 245
      Me.Label5.Tag = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Label5.Text = "Articoli con giacenza diversa da zero"
      Me.Label5.Visible = False
      '
      'CheckBox2
      '
      Me.CheckBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.CheckBox2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.CheckBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.CheckBox2.ForeColor = System.Drawing.SystemColors.Window
      Me.CheckBox2.Location = New System.Drawing.Point(460, 72)
      Me.CheckBox2.Name = "CheckBox2"
      Me.CheckBox2.Size = New System.Drawing.Size(112, 16)
      Me.CheckBox2.TabIndex = 5
      '
      'ComboBox2
      '
      Me.ComboBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ComboBox2.Location = New System.Drawing.Point(438, 40)
      Me.ComboBox2.Name = "ComboBox2"
      Me.ComboBox2.Size = New System.Drawing.Size(136, 21)
      Me.ComboBox2.TabIndex = 3
      Me.ComboBox2.Visible = False
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.Label4.Location = New System.Drawing.Point(334, 40)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(107, 15)
      Me.Label4.TabIndex = 243
      Me.Label4.Text = "Raggruppa per:"
      Me.Label4.Visible = False
      '
      'ComboBox1
      '
      Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.ComboBox1.Items.AddRange(New Object() {"Codice", "Descrizione"})
      Me.ComboBox1.Location = New System.Drawing.Point(105, 40)
      Me.ComboBox1.Name = "ComboBox1"
      Me.ComboBox1.Size = New System.Drawing.Size(175, 21)
      Me.ComboBox1.TabIndex = 2
      Me.ComboBox1.Visible = False
      '
      'CheckBox1
      '
      Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.CheckBox1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.CheckBox1.ForeColor = System.Drawing.SystemColors.Window
      Me.CheckBox1.Location = New System.Drawing.Point(232, 72)
      Me.CheckBox1.Name = "CheckBox1"
      Me.CheckBox1.Size = New System.Drawing.Size(48, 16)
      Me.CheckBox1.TabIndex = 4
      '
      'CampoRicerca
      '
      Me.CampoRicerca.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.CampoRicerca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.CampoRicerca.Location = New System.Drawing.Point(438, 8)
      Me.CampoRicerca.Name = "CampoRicerca"
      Me.CampoRicerca.Size = New System.Drawing.Size(136, 21)
      Me.CampoRicerca.TabIndex = 1
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.White
      Me.Label2.Location = New System.Drawing.Point(348, 8)
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
      Me.Label1.Location = New System.Drawing.Point(2, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(110, 15)
      Me.Label1.TabIndex = 6
      Me.Label1.Text = "Testo di ricerca:"
      '
      'TestoRicerca
      '
      Me.TestoRicerca.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TestoRicerca.Location = New System.Drawing.Point(120, 8)
      Me.TestoRicerca.Name = "TestoRicerca"
      Me.TestoRicerca.Size = New System.Drawing.Size(211, 20)
      Me.TestoRicerca.TabIndex = 0
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
      Me.Label3.Location = New System.Drawing.Point(2, 40)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(79, 15)
      Me.Label3.TabIndex = 241
      Me.Label3.Text = "Ordina per:"
      Me.Label3.Visible = False
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = ""
      '
      'Panel2
      '
      Me.Panel2.BackColor = System.Drawing.Color.Gray
      Me.Panel2.Controls.Add(Me.txtTotValScarico)
      Me.Panel2.Controls.Add(Me.Label9)
      Me.Panel2.Controls.Add(Me.txtTotValCarico)
      Me.Panel2.Controls.Add(Me.Label8)
      Me.Panel2.Controls.Add(Me.txtTotValAttuale)
      Me.Panel2.Controls.Add(Me.Label6)
      Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel2.Location = New System.Drawing.Point(0, 326)
      Me.Panel2.Name = "Panel2"
      Me.Panel2.Size = New System.Drawing.Size(580, 48)
      Me.Panel2.TabIndex = 14
      '
      'txtTotValScarico
      '
      Me.txtTotValScarico.AcceptsReturn = True
      Me.txtTotValScarico.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotValScarico.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotValScarico.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotValScarico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotValScarico.ForeColor = System.Drawing.Color.Red
      Me.txtTotValScarico.Location = New System.Drawing.Point(292, 22)
      Me.txtTotValScarico.MaxLength = 0
      Me.txtTotValScarico.Name = "txtTotValScarico"
      Me.txtTotValScarico.ReadOnly = True
      Me.txtTotValScarico.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotValScarico.Size = New System.Drawing.Size(136, 20)
      Me.txtTotValScarico.TabIndex = 19
      Me.txtTotValScarico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label9.AutoSize = True
      Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label9.ForeColor = System.Drawing.Color.White
      Me.Label9.Location = New System.Drawing.Point(292, 4)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(132, 15)
      Me.Label9.TabIndex = 20
      Me.Label9.Text = "Tot. valore scarichi:"
      '
      'txtTotValCarico
      '
      Me.txtTotValCarico.AcceptsReturn = True
      Me.txtTotValCarico.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotValCarico.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotValCarico.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotValCarico.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotValCarico.ForeColor = System.Drawing.Color.Red
      Me.txtTotValCarico.Location = New System.Drawing.Point(148, 22)
      Me.txtTotValCarico.MaxLength = 0
      Me.txtTotValCarico.Name = "txtTotValCarico"
      Me.txtTotValCarico.ReadOnly = True
      Me.txtTotValCarico.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotValCarico.Size = New System.Drawing.Size(136, 20)
      Me.txtTotValCarico.TabIndex = 17
      Me.txtTotValCarico.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label8.AutoSize = True
      Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label8.ForeColor = System.Drawing.Color.White
      Me.Label8.Location = New System.Drawing.Point(148, 4)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(125, 15)
      Me.Label8.TabIndex = 18
      Me.Label8.Text = "Tot. valore carichi:"
      '
      'txtTotValAttuale
      '
      Me.txtTotValAttuale.AcceptsReturn = True
      Me.txtTotValAttuale.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotValAttuale.BackColor = System.Drawing.SystemColors.Window
      Me.txtTotValAttuale.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotValAttuale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotValAttuale.ForeColor = System.Drawing.Color.Red
      Me.txtTotValAttuale.Location = New System.Drawing.Point(436, 22)
      Me.txtTotValAttuale.MaxLength = 0
      Me.txtTotValAttuale.Name = "txtTotValAttuale"
      Me.txtTotValAttuale.ReadOnly = True
      Me.txtTotValAttuale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotValAttuale.Size = New System.Drawing.Size(136, 20)
      Me.txtTotValAttuale.TabIndex = 0
      Me.txtTotValAttuale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.AutoSize = True
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.White
      Me.Label6.Location = New System.Drawing.Point(436, 4)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(126, 15)
      Me.Label6.TabIndex = 16
      Me.Label6.Text = "Tot. valore attuale:"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'ElencoInventario
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(580, 374)
      Me.Controls.Add(Me.Panel2)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.DataGrid1)
      Me.Controls.Add(Me.ToolBar1)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ElencoInventario"
      Me.ShowInTaskbar = False
      Me.Text = "Inventario di magazzino"
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

         If DatiConfig.GetValue("WSInventario") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
            Exit Sub
         ElseIf DatiConfig.GetValue("WSInventario") = CStr(FormWindowState.Minimized) Then
            Me.WindowState = FormWindowState.Minimized
            Exit Sub
         Else
            If DatiConfig.GetValue("AInventario") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("AInventario"))
            Else
               Me.Height = FORM_ALTEZZA
            End If

            If DatiConfig.GetValue("LInventario") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LInventario"))
            Else
               Me.Width = FORM_LARGHEZZA
            End If

            If DatiConfig.GetValue("InventarioX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("InventarioX")), Me.Location.Y)
            End If

            If DatiConfig.GetValue("InventarioY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("InventarioY")))
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

         DatiConfig.SetValue("WSInventario", Me.WindowState)
         DatiConfig.SetValue("InventarioX", Me.Location.X)
         DatiConfig.SetValue("InventarioY", Me.Location.Y)
         DatiConfig.SetValue("AInventario", Me.Height)
         DatiConfig.SetValue("LInventario", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ImpostaFunzioniOperatore(ByVal wnd As String) As Boolean
      Try
         Select Case wnd
            Case Finestra.Inventario
               If operatore.MagInventario = VALORE_LETTURA Then
                  Carico.Enabled = False
                  Scarico.Enabled = False
               Else
                  Carico.Enabled = True
                  Scarico.Enabled = True
               End If
         End Select

         Return Carico.Enabled

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

   Sub LeggiNumPagine(ByVal tabella As String)
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

   Public Sub AggiornaDati()
      Try
         If TestoRicerca.Text <> "" Then
            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            FiltraDati(TestoRicerca.Text, CampoRicerca.Text)
         Else
            ' Calcola il numero delle pagine da visualizzare.
            LeggiNumPagine(TAB_ARTICOLI)

            ' Collega la tabella clienti al controllo griglia dati.
            DataGrid1.DataSource = dt

            ' Visualizza la prima pagina di dati.
            VisualizzaPagina(pagCorrente, sql)

            ' Aggiorna l'intestazione della griglia dati.
            AggIntGriglia()

            ' Aggiorna il titolo della finestra.
            AggTitoloFinestra(TITOLO_FINESTRA)

            ' Somma i valori della colonna Valore Carichi.
            txtTotValCarico.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_VAL_CARICO, numRecord))

            ' Somma i valori della colonna Valore Scarichi.
            txtTotValScarico.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_VAL_SCARICO, numRecord))

            ' Somma i valori della colonna Valore Attuale.
            txtTotValAttuale.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_VAL_ATTUALE, numRecord))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ImpostaComandi()
      If numRecord = 0 Then
         ' Disattiva i pulsanti appropriati.
         Carico.Enabled = False
         Scarico.Enabled = False
         'Primo.Enabled = False
         'Precedente.Enabled = False
         'Successivo.Enabled = False
         'Ultimo.Enabled = False
         Aggiorna.Enabled = False
      Else
         ' Disattiva i pulsanti appropriati.
         Carico.Enabled = True
         Scarico.Enabled = True
         Aggiorna.Enabled = True
      End If
   End Sub

   Public Sub ConvalidaDati()
      If ImpostaFunzioniOperatore(Finestra.Inventario) = True Then
         ImpostaComandi()
      End If
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
         ' Id (non visibile)
         Dim idStyle As New DataGridTextBoxColumn
         idStyle.MappingName = "Id"
         idStyle.HeaderText = "Id"
         idStyle.Width = 0
         idStyle.NullText = ""
         idStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(idStyle)
         ' Codice
         Dim codiceStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_ROSA), Color.Black)
         codiceStyle.MappingName = "Codice"
         codiceStyle.HeaderText = "Codice"
         codiceStyle.Width = 70
         codiceStyle.NullText = ""
         codiceStyle.Alignment = HorizontalAlignment.Right
         codiceStyle.TextBox.BackColor = Color.FromArgb(COLORE_ROSA)
         gridStyle.GridColumnStyles.Add(codiceStyle)
         ' Descrizione
         Dim descrizioneStyle As New ColonnaColorata(DataGrid1, Color.FromArgb(COLORE_AZZURRO), Color.Black)
         descrizioneStyle.MappingName = "Descrizione"
         descrizioneStyle.HeaderText = "Descrizione"
         descrizioneStyle.Width = 200
         descrizioneStyle.NullText = ""
         descrizioneStyle.TextBox.BackColor = Color.FromArgb(COLORE_AZZURRO)
         gridStyle.GridColumnStyles.Add(descrizioneStyle)
         ' Unit‡ di misura
         Dim umStyle As New DataGridTextBoxColumn
         umStyle.MappingName = "Unit‡Misura"
         umStyle.HeaderText = "U.M."
         umStyle.Width = 50
         umStyle.NullText = ""
         umStyle.Alignment = HorizontalAlignment.Center
         umStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(umStyle)
         ' Giacenza
         Dim giacenzaStyle As New ColonnaColorata(DataGrid1, Color.White, Color.Red)
         giacenzaStyle.MappingName = "Giacenza"
         giacenzaStyle.HeaderText = "Giacenza"
         giacenzaStyle.Width = 60
         giacenzaStyle.NullText = ""
         giacenzaStyle.Format = "##,##0.000"
         giacenzaStyle.Alignment = HorizontalAlignment.Right
         giacenzaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(giacenzaStyle)
         ' Caricato
         Dim caricatoStyle As New DataGridTextBoxColumn
         caricatoStyle.MappingName = "Carico"
         caricatoStyle.HeaderText = ""
         caricatoStyle.Width = 0
         caricatoStyle.NullText = ""
         caricatoStyle.Format = "##,##0.000"
         caricatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(caricatoStyle)
         ' Scaricato
         Dim scaricatoStyle As New DataGridTextBoxColumn
         scaricatoStyle.MappingName = "Scarico"
         scaricatoStyle.HeaderText = ""
         scaricatoStyle.Width = 0
         scaricatoStyle.NullText = ""
         scaricatoStyle.Format = "##,##0.000"
         scaricatoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(scaricatoStyle)
         ' Scorta minima
         Dim smStyle As New DataGridTextBoxColumn
         smStyle.MappingName = "ScortaMin"
         smStyle.HeaderText = ""
         smStyle.Width = 0
         smStyle.NullText = ""
         smStyle.Format = "##,##0.000"
         smStyle.Alignment = HorizontalAlignment.Right
         smStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(smStyle)
         ' Prezzo Acquisto
         Dim pAcquistoStyle As New DataGridTextBoxColumn
         pAcquistoStyle.MappingName = "PrezzoAcquisto"
         pAcquistoStyle.HeaderText = "Prezzo di acquisto"
         pAcquistoStyle.Width = 110
         pAcquistoStyle.NullText = ""
         pAcquistoStyle.Format = "##,##0.00"
         pAcquistoStyle.Alignment = HorizontalAlignment.Right
         pAcquistoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(pAcquistoStyle)
         ' Categoria
         Dim categoriaStyle As New DataGridTextBoxColumn
         categoriaStyle.MappingName = "Categoria"
         categoriaStyle.HeaderText = "Categoria"
         categoriaStyle.Width = 100
         categoriaStyle.NullText = ""
         categoriaStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(categoriaStyle)
         ' Fornitore
         Dim fornitoreStyle As New DataGridTextBoxColumn
         fornitoreStyle.MappingName = "Fornitore"
         fornitoreStyle.HeaderText = "Fornitore"
         fornitoreStyle.Width = 120
         fornitoreStyle.NullText = ""
         fornitoreStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(fornitoreStyle)
         ' Magazzino
         Dim magazzinoStyle As New DataGridTextBoxColumn
         magazzinoStyle.MappingName = "Magazzino"
         magazzinoStyle.HeaderText = "Magazzino"
         magazzinoStyle.Width = 100
         magazzinoStyle.NullText = ""
         magazzinoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(magazzinoStyle)
         ' Valore carico
         Dim valCaricoStyle As New DataGridTextBoxColumn
         valCaricoStyle.MappingName = "ValCarico"
         valCaricoStyle.HeaderText = "Valore carichi"
         valCaricoStyle.Width = 90
         valCaricoStyle.NullText = ""
         valCaricoStyle.Format = "##,##0.00"
         valCaricoStyle.Alignment = HorizontalAlignment.Right
         valCaricoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(valCaricoStyle)
         ' Valore scarico
         Dim valScaricoStyle As New DataGridTextBoxColumn
         valScaricoStyle.MappingName = "ValScarico"
         valScaricoStyle.HeaderText = "Valore scarichi"
         valScaricoStyle.Width = 90
         valScaricoStyle.NullText = ""
         valScaricoStyle.Format = "##,##0.00"
         valScaricoStyle.Alignment = HorizontalAlignment.Right
         valScaricoStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(valScaricoStyle)
         ' Valore attuale
         Dim valAttualeStyle As New DataGridTextBoxColumn
         valAttualeStyle.MappingName = "ValAttuale"
         valAttualeStyle.HeaderText = "Valore attuale"
         valAttualeStyle.Width = 90
         valAttualeStyle.NullText = ""
         valAttualeStyle.Format = "##,##0.00"
         valAttualeStyle.Alignment = HorizontalAlignment.Right
         valAttualeStyle.TextBox.BackColor = Color.White
         gridStyle.GridColumnStyles.Add(valAttualeStyle)

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
            Case "Unit‡ di misura"
               campoRicerca = "Unit‡Misura"
            Case "Prezzo di acquisto"
               campoRicerca = "PrezzoAcquisto"
            Case "Valore carichi"
               campoRicerca = "ValCarico"
            Case "Valore scarichi"
               campoRicerca = "ValScarico"
            Case "Valore attuale"
               campoRicerca = "ValAttuale"
         End Select

         If testoRicerca <> "" Then
            ' Crea la stringa sql.
            sql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_ARTICOLI, campoRicerca, campoRicerca)
            repSql = String.Format("SELECT * FROM {0} WHERE {1} LIKE '" & testoRicerca & "%' ORDER BY {2} ASC", TAB_ARTICOLI, campoRicerca, campoRicerca)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati("(" & sql & ")", sql)
         Else
            sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Codice ASC", DIM_PAGINA_GRANDE, TAB_ARTICOLI)
            repSql = String.Format("SELECT * FROM {0} ORDER BY Codice ASC", TAB_ARTICOLI)

            ' Legge i dati e ottiene il numero totale dei record.
            LeggiDati(TAB_ARTICOLI, sql)
         End If

         ' Somma i valori della colonna Valore Carichi.
         txtTotValCarico.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_VAL_CARICO, numRecord))

         ' Somma i valori della colonna Valore Scarichi.
         txtTotValScarico.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_VAL_SCARICO, numRecord))

         ' Somma i valori della colonna Valore Attuale.
         txtTotValAttuale.Text = CFormatta.FormattaEuro(SommaColonna(DataGrid1, COLONNA_VAL_ATTUALE, numRecord))

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
         CampoRicerca.Items.Add("Descrizione")
         CampoRicerca.Items.Add("Unit‡ di misura")
         CampoRicerca.Items.Add("Giacenza")
         CampoRicerca.Items.Add("Prezzo di acquisto")
         CampoRicerca.Items.Add("Categoria")
         CampoRicerca.Items.Add("Fornitore")
         CampoRicerca.Items.Add("Magazzino")
         CampoRicerca.Items.Add("Valore carichi")
         CampoRicerca.Items.Add("Valore scarichi")
         CampoRicerca.Items.Add("Valore attuale")

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

   Private Sub StampaDocumento(ByVal nomeDoc As String, ByVal tabella As String, ByVal sqlRep As String, Optional ByVal frmId As String = "")
      Dim cn As OleDbConnection

      Try
         If PrintDialog1.ShowDialog() = DialogResult.OK Then

            If frmId = "Clienti" Then
               ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

               ' Dichiara un oggetto connessione.
               cn = New OleDbConnection(ConnStringAnagrafiche)
            Else
               'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
               cn = New OleDbConnection(ConnString)
            End If

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

   Private Sub ElencoInventario_Activated(sender As Object, e As System.EventArgs) Handles Me.Activated
      ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
      g_frmMain.rtgGestionaleAmica.Visible = False

   End Sub

   Private Sub ElencoInventario_FormClosed(sender As Object, e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
      Try
         SalvaDatiConfig()

         ' Ottiene l'effetto a scomparsa.
         Me.WindowState = FormWindowState.Minimized

         ' Rimuove la finestra aperta dal menu Finestra/Seleziona.
         g_frmMain.RimuoviFormMenuSeleziona(g_frmInventario)

         ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
         g_frmMain.rtgGestionaleAmica.Visible = False

         ' Distrugge l'oggetto e libera le risorse.
         g_frmInventario.Dispose()
         g_frmInventario = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_MAGAZZINO_INVENTARIO, MODULO_MAGAZZINO_INVENTARIO)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ElencoInventario_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         ' Imposta le dimensioni del form.
         LeggiDatiConfig()

         ' Crea le colonne della griglia dati.
         CreaColonne(TAB_ARTICOLI)

         ' Carica l'elenco dei campi di ricerca.
         CaricaCampiRic()

         ' Imposta l'elenco dei campi di ricerca sul valore predefinito.
         CampoRicerca.SelectedIndex = 1

         ' Crea la stringa di selezione dei dati..
         sql = String.Format("SELECT TOP {0} * FROM {1} ORDER BY Codice", DIM_PAGINA_GRANDE, TAB_ARTICOLI)
         LeggiDati(TAB_ARTICOLI, sql)

         ' Se nella tabella non ci sono record disattiva i pulsanti.
         ConvalidaDati()

         ' Aggiorna l'intestazione della griglia dati.
         AggIntGriglia()

         ' Aggiorna il titolo della finestra.
         AggTitoloFinestra(TITOLO_FINESTRA)

         ' Registra loperazione efettuata dall'operatore identificato.
         strModulo = MODULO_MAGAZZINO_INVENTARIO

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_MAGAZZINO_INVENTARIO, MODULO_MAGAZZINO_INVENTARIO)

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
         Case "Carico"
            Dim frm As New CaricoScarico("Carico", DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 10), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 11))
            frm.ShowDialog()

         Case "Scarico"
            Dim frm As New CaricoScarico("Scarico", DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 0), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 1), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 2), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 4), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 5), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 6), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 7), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 8), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 10), _
                                                   DataGrid1.Item(DataGrid1.CurrentCell.RowNumber, 11))
            frm.ShowDialog()

         Case "Stampa"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Stampa, STR_MAGAZZINO_INVENTARIO, MODULO_MAGAZZINO_INVENTARIO)

            StampaDocumento(PERCORSO_REP_INVENTARIO, TAB_ARTICOLI, repSql)

         Case "Anteprima"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Anteprima, STR_MAGAZZINO_INVENTARIO, MODULO_MAGAZZINO_INVENTARIO)

            g_frmMain.ApriReports(repSql, TAB_ARTICOLI, PERCORSO_REP_INVENTARIO)

            'Case "Primo"
            '   ' Crea la stringa sql.
            '   sql = String.Format("SELECT TOP {0} * FROM {1} WHERE SituazioneScorta < 0 OR Giacenza < 0 ORDER BY Id", dimPagina, TAB_ARTICOLI)

            '   ' Visualizza la prima pagina di dati.
            '   VisualizzaPagina(1, sql)

            '   ' Visualizza un'intestazione per la griglia dati.
            '   AggIntGriglia()

            'Case "Precedente"
            '   ' Crea la stringa sql.
            '   sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} WHERE Id < {3} AND (SituazioneScorta < 0 OR Giacenza < 0) ORDER BY Id DESC) ORDER BY Id", TAB_ARTICOLI, dimPagina, TAB_ARTICOLI, dt.Rows(0)("Id"))

            '   ' Visualizza la pagina di dati precedente.
            '   VisualizzaPagina(pagCorrente - 1, sql)

            '   ' Visualizza un'intestazione per la griglia dati.
            '   AggIntGriglia()

            'Case "Successivo"
            '   ' Crea la stringa sql.
            '   sql = String.Format("SELECT TOP {0} * FROM {1} WHERE Id > {2} AND (SituazioneScorta < 0 OR Giacenza < 0) ORDER BY Id", dimPagina, TAB_ARTICOLI, dt.Rows(dt.Rows.Count - 1)("Id"))

            '   ' Visualizza la pagina di dati successiva.
            '   VisualizzaPagina(pagCorrente + 1, sql)

            '   ' Visualizza un'intestazione per la griglia dati.
            '   AggIntGriglia()

            'Case "Ultimo"
            '   Dim num As Integer = numRecord - dimPagina * (numPagine - 1)

            '   ' Crea la stringa sql.
            '   sql = String.Format("SELECT * FROM {0} WHERE Id IN (SELECT TOP {1} Id FROM {2} WHERE (SituazioneScorta < 0 OR Giacenza < 0) ORDER BY Id DESC) ORDER BY Id", TAB_ARTICOLI, num, TAB_ARTICOLI)

            '   ' Visualizza l'ultima pagina di dati.
            '   VisualizzaPagina(numPagine, sql)

            '   ' Visualizza un'intestazione per la griglia dati.
            '   AggIntGriglia()

         Case "Aggiorna"
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Aggiorna, STR_MAGAZZINO_INVENTARIO, MODULO_MAGAZZINO_INVENTARIO)

            ' Aggiorna la griglia dati.
            AggiornaDati()

            ' Visualizza un'intestazione per la griglia dati.
            AggIntGriglia()

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

End Class
