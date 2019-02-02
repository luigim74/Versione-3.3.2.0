' Nome form:            POS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/04/2006
' Data ultima modifica: 24/04/2006
' Descrizione:          Interfaccia Punto cassa - conto immediato

Imports System.IO
Imports System.Data.OleDb

Public Class frmVCEsauriti
   Inherits System.Windows.Forms.Form

   Const TAB_PIATTI As String = "Piatti"
   Const TAB_CATEGORIE As String = "CategoriePiatti"
   Const TAB_PIATTI_ESAURITI As String = "PiattiEsauriti"

   Const LARGHEZZA_CATEGORIA As Short = 138
   Const ALTEZZA_CATEGORIA As Short = 70
   Const LARGHEZZA_PIATTO As Short = 104
   Const ALTEZZA_PIATTO As Short = 70
   Const LARGHEZZA_VARIAZIONE As Short = 130
   Const ALTEZZA_VARIAZIONE As Short = 40
   Const ALTEZZA_RIGA_DETTAGLI As Short = 22

   Public Categorie() As Button
   Public NumCategorie As Short = 0
   Public Piatti() As Button
   Public NumPiatti As Short = 0
   Public Variazioni() As Button
   Public NumVariazioni As Short = 0
   Public CategoriaIniziale As String
   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Private CFormatta As New ClsFormatta
   Private AArticoli As New Articoli
   Private CConvalida As New ConvalidaKeyPress
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

   Private confermaModifiche As Boolean

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

      ReDim Categorie(LeggiNumRecord(TAB_CATEGORIE))
      ReDim Piatti(LeggiNumRecord(TAB_PIATTI))
      ReDim Variazioni(LeggiNumRecord(TAB_PIATTI))

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
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmd8 As System.Windows.Forms.Button
   Friend WithEvents cmd7 As System.Windows.Forms.Button
   Friend WithEvents cmd6 As System.Windows.Forms.Button
   Friend WithEvents cmd1 As System.Windows.Forms.Button
   Friend WithEvents cmd3 As System.Windows.Forms.Button
   Friend WithEvents cmd5 As System.Windows.Forms.Button
   Friend WithEvents cmd2 As System.Windows.Forms.Button
   Friend WithEvents cmd4 As System.Windows.Forms.Button
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents pnlPiatti As System.Windows.Forms.Panel
   Friend WithEvents pnlVariazioni As System.Windows.Forms.Panel
   Friend WithEvents pnlCategoria As System.Windows.Forms.Panel
   Friend WithEvents cmdCategorieGiù As System.Windows.Forms.Button
   Friend WithEvents cmdCategorieSu As System.Windows.Forms.Button
   Friend WithEvents cmdPiattiGiù As System.Windows.Forms.Button
   Friend WithEvents cmdPiattiSu As System.Windows.Forms.Button
   Friend WithEvents cmdVariazioniSu As System.Windows.Forms.Button
   Friend WithEvents cmdVariazioniGiù As System.Windows.Forms.Button
   Friend WithEvents cmdNum1 As System.Windows.Forms.Button
   Friend WithEvents cmdNum2 As System.Windows.Forms.Button
   Friend WithEvents cmdNum3 As System.Windows.Forms.Button
   Friend WithEvents cmdNum4 As System.Windows.Forms.Button
   Friend WithEvents cmdNum5 As System.Windows.Forms.Button
   Friend WithEvents cmdNum6 As System.Windows.Forms.Button
   Friend WithEvents cmdNum7 As System.Windows.Forms.Button
   Friend WithEvents cmdNum0 As System.Windows.Forms.Button
   Friend WithEvents cmdNum9 As System.Windows.Forms.Button
   Friend WithEvents cmdNum8 As System.Windows.Forms.Button
   Friend WithEvents cmdOk As System.Windows.Forms.Button
   Friend WithEvents txtCodice As System.Windows.Forms.TextBox
   Friend WithEvents cmdDettagliSu As System.Windows.Forms.Button
   Friend WithEvents cmdDettagliGiù As System.Windows.Forms.Button
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdRimuovi As System.Windows.Forms.Button
   Friend WithEvents cmdConferma As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVCEsauriti))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.cmdCategorieGiù = New System.Windows.Forms.Button()
      Me.cmdCategorieSu = New System.Windows.Forms.Button()
      Me.cmdPiattiGiù = New System.Windows.Forms.Button()
      Me.cmdPiattiSu = New System.Windows.Forms.Button()
      Me.cmdVariazioniSu = New System.Windows.Forms.Button()
      Me.cmdVariazioniGiù = New System.Windows.Forms.Button()
      Me.cmdNum1 = New System.Windows.Forms.Button()
      Me.cmdNum2 = New System.Windows.Forms.Button()
      Me.cmdNum3 = New System.Windows.Forms.Button()
      Me.cmdNum4 = New System.Windows.Forms.Button()
      Me.cmdNum5 = New System.Windows.Forms.Button()
      Me.cmdNum6 = New System.Windows.Forms.Button()
      Me.cmdNum7 = New System.Windows.Forms.Button()
      Me.cmdNum0 = New System.Windows.Forms.Button()
      Me.cmdNum9 = New System.Windows.Forms.Button()
      Me.cmdNum8 = New System.Windows.Forms.Button()
      Me.cmdOk = New System.Windows.Forms.Button()
      Me.txtCodice = New System.Windows.Forms.TextBox()
      Me.cmdDettagliSu = New System.Windows.Forms.Button()
      Me.cmdDettagliGiù = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmd8 = New System.Windows.Forms.Button()
      Me.cmd7 = New System.Windows.Forms.Button()
      Me.cmd6 = New System.Windows.Forms.Button()
      Me.cmd1 = New System.Windows.Forms.Button()
      Me.cmd2 = New System.Windows.Forms.Button()
      Me.cmd3 = New System.Windows.Forms.Button()
      Me.cmd4 = New System.Windows.Forms.Button()
      Me.cmd5 = New System.Windows.Forms.Button()
      Me.pnlPiatti = New System.Windows.Forms.Panel()
      Me.pnlVariazioni = New System.Windows.Forms.Panel()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.cmdRimuovi = New System.Windows.Forms.Button()
      Me.cmdConferma = New System.Windows.Forms.Button()
      Me.pnlCategoria = New System.Windows.Forms.Panel()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.lstvDettagli = New System.Windows.Forms.ListView()
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
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
      'cmdCategorieGiù
      '
      Me.cmdCategorieGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdCategorieGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdCategorieGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCategorieGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCategorieGiù.Image = CType(resources.GetObject("cmdCategorieGiù.Image"), System.Drawing.Image)
      Me.cmdCategorieGiù.Location = New System.Drawing.Point(8, 471)
      Me.cmdCategorieGiù.Name = "cmdCategorieGiù"
      Me.cmdCategorieGiù.Size = New System.Drawing.Size(64, 40)
      Me.cmdCategorieGiù.TabIndex = 1
      Me.cmdCategorieGiù.UseVisualStyleBackColor = False
      '
      'cmdCategorieSu
      '
      Me.cmdCategorieSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdCategorieSu.BackColor = System.Drawing.Color.Silver
      Me.cmdCategorieSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCategorieSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCategorieSu.Image = CType(resources.GetObject("cmdCategorieSu.Image"), System.Drawing.Image)
      Me.cmdCategorieSu.Location = New System.Drawing.Point(80, 471)
      Me.cmdCategorieSu.Name = "cmdCategorieSu"
      Me.cmdCategorieSu.Size = New System.Drawing.Size(64, 40)
      Me.cmdCategorieSu.TabIndex = 2
      Me.cmdCategorieSu.UseVisualStyleBackColor = False
      '
      'cmdPiattiGiù
      '
      Me.cmdPiattiGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdPiattiGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdPiattiGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdPiattiGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPiattiGiù.Image = CType(resources.GetObject("cmdPiattiGiù.Image"), System.Drawing.Image)
      Me.cmdPiattiGiù.Location = New System.Drawing.Point(152, 471)
      Me.cmdPiattiGiù.Name = "cmdPiattiGiù"
      Me.cmdPiattiGiù.Size = New System.Drawing.Size(154, 40)
      Me.cmdPiattiGiù.TabIndex = 4
      Me.cmdPiattiGiù.UseVisualStyleBackColor = False
      '
      'cmdPiattiSu
      '
      Me.cmdPiattiSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdPiattiSu.BackColor = System.Drawing.Color.Silver
      Me.cmdPiattiSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdPiattiSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPiattiSu.Image = CType(resources.GetObject("cmdPiattiSu.Image"), System.Drawing.Image)
      Me.cmdPiattiSu.Location = New System.Drawing.Point(312, 471)
      Me.cmdPiattiSu.Name = "cmdPiattiSu"
      Me.cmdPiattiSu.Size = New System.Drawing.Size(154, 40)
      Me.cmdPiattiSu.TabIndex = 5
      Me.cmdPiattiSu.UseVisualStyleBackColor = False
      '
      'cmdVariazioniSu
      '
      Me.cmdVariazioniSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdVariazioniSu.BackColor = System.Drawing.Color.Silver
      Me.cmdVariazioniSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdVariazioniSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdVariazioniSu.Image = CType(resources.GetObject("cmdVariazioniSu.Image"), System.Drawing.Image)
      Me.cmdVariazioniSu.Location = New System.Drawing.Point(540, 471)
      Me.cmdVariazioniSu.Name = "cmdVariazioniSu"
      Me.cmdVariazioniSu.Size = New System.Drawing.Size(62, 40)
      Me.cmdVariazioniSu.TabIndex = 8
      Me.cmdVariazioniSu.UseVisualStyleBackColor = False
      '
      'cmdVariazioniGiù
      '
      Me.cmdVariazioniGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdVariazioniGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdVariazioniGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdVariazioniGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdVariazioniGiù.Image = CType(resources.GetObject("cmdVariazioniGiù.Image"), System.Drawing.Image)
      Me.cmdVariazioniGiù.Location = New System.Drawing.Point(472, 471)
      Me.cmdVariazioniGiù.Name = "cmdVariazioniGiù"
      Me.cmdVariazioniGiù.Size = New System.Drawing.Size(62, 40)
      Me.cmdVariazioniGiù.TabIndex = 7
      Me.cmdVariazioniGiù.UseVisualStyleBackColor = False
      '
      'cmdNum1
      '
      Me.cmdNum1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum1.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum1.ForeColor = System.Drawing.Color.White
      Me.cmdNum1.Location = New System.Drawing.Point(8, 519)
      Me.cmdNum1.Name = "cmdNum1"
      Me.cmdNum1.Size = New System.Drawing.Size(40, 40)
      Me.cmdNum1.TabIndex = 9
      Me.cmdNum1.Text = "1"
      Me.cmdNum1.UseVisualStyleBackColor = False
      '
      'cmdNum2
      '
      Me.cmdNum2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum2.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum2.ForeColor = System.Drawing.Color.White
      Me.cmdNum2.Location = New System.Drawing.Point(50, 519)
      Me.cmdNum2.Name = "cmdNum2"
      Me.cmdNum2.Size = New System.Drawing.Size(40, 40)
      Me.cmdNum2.TabIndex = 10
      Me.cmdNum2.Text = "2"
      Me.cmdNum2.UseVisualStyleBackColor = False
      '
      'cmdNum3
      '
      Me.cmdNum3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum3.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum3.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum3.ForeColor = System.Drawing.Color.White
      Me.cmdNum3.Location = New System.Drawing.Point(92, 519)
      Me.cmdNum3.Name = "cmdNum3"
      Me.cmdNum3.Size = New System.Drawing.Size(40, 40)
      Me.cmdNum3.TabIndex = 11
      Me.cmdNum3.Text = "3"
      Me.cmdNum3.UseVisualStyleBackColor = False
      '
      'cmdNum4
      '
      Me.cmdNum4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum4.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum4.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum4.ForeColor = System.Drawing.Color.White
      Me.cmdNum4.Location = New System.Drawing.Point(134, 519)
      Me.cmdNum4.Name = "cmdNum4"
      Me.cmdNum4.Size = New System.Drawing.Size(40, 40)
      Me.cmdNum4.TabIndex = 12
      Me.cmdNum4.Text = "4"
      Me.cmdNum4.UseVisualStyleBackColor = False
      '
      'cmdNum5
      '
      Me.cmdNum5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum5.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum5.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum5.ForeColor = System.Drawing.Color.White
      Me.cmdNum5.Location = New System.Drawing.Point(176, 519)
      Me.cmdNum5.Name = "cmdNum5"
      Me.cmdNum5.Size = New System.Drawing.Size(40, 40)
      Me.cmdNum5.TabIndex = 13
      Me.cmdNum5.Text = "5"
      Me.cmdNum5.UseVisualStyleBackColor = False
      '
      'cmdNum6
      '
      Me.cmdNum6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum6.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum6.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum6.ForeColor = System.Drawing.Color.White
      Me.cmdNum6.Location = New System.Drawing.Point(218, 519)
      Me.cmdNum6.Name = "cmdNum6"
      Me.cmdNum6.Size = New System.Drawing.Size(40, 40)
      Me.cmdNum6.TabIndex = 14
      Me.cmdNum6.Text = "6"
      Me.cmdNum6.UseVisualStyleBackColor = False
      '
      'cmdNum7
      '
      Me.cmdNum7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum7.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum7.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum7.ForeColor = System.Drawing.Color.White
      Me.cmdNum7.Location = New System.Drawing.Point(260, 519)
      Me.cmdNum7.Name = "cmdNum7"
      Me.cmdNum7.Size = New System.Drawing.Size(40, 40)
      Me.cmdNum7.TabIndex = 15
      Me.cmdNum7.Text = "7"
      Me.cmdNum7.UseVisualStyleBackColor = False
      '
      'cmdNum0
      '
      Me.cmdNum0.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum0.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum0.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum0.ForeColor = System.Drawing.Color.White
      Me.cmdNum0.Location = New System.Drawing.Point(386, 519)
      Me.cmdNum0.Name = "cmdNum0"
      Me.cmdNum0.Size = New System.Drawing.Size(40, 40)
      Me.cmdNum0.TabIndex = 18
      Me.cmdNum0.Text = "0"
      Me.cmdNum0.UseVisualStyleBackColor = False
      '
      'cmdNum9
      '
      Me.cmdNum9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum9.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum9.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum9.ForeColor = System.Drawing.Color.White
      Me.cmdNum9.Location = New System.Drawing.Point(344, 519)
      Me.cmdNum9.Name = "cmdNum9"
      Me.cmdNum9.Size = New System.Drawing.Size(40, 40)
      Me.cmdNum9.TabIndex = 17
      Me.cmdNum9.Text = "9"
      Me.cmdNum9.UseVisualStyleBackColor = False
      '
      'cmdNum8
      '
      Me.cmdNum8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum8.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum8.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum8.ForeColor = System.Drawing.Color.White
      Me.cmdNum8.Location = New System.Drawing.Point(302, 519)
      Me.cmdNum8.Name = "cmdNum8"
      Me.cmdNum8.Size = New System.Drawing.Size(40, 40)
      Me.cmdNum8.TabIndex = 16
      Me.cmdNum8.Text = "8"
      Me.cmdNum8.UseVisualStyleBackColor = False
      '
      'cmdOk
      '
      Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdOk.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdOk.ForeColor = System.Drawing.Color.White
      Me.cmdOk.Location = New System.Drawing.Point(550, 519)
      Me.cmdOk.Name = "cmdOk"
      Me.cmdOk.Size = New System.Drawing.Size(52, 40)
      Me.cmdOk.TabIndex = 20
      Me.cmdOk.Text = "OK"
      Me.cmdOk.UseVisualStyleBackColor = False
      '
      'txtCodice
      '
      Me.txtCodice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.DodgerBlue
      Me.txtCodice.Location = New System.Drawing.Point(432, 519)
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.Size = New System.Drawing.Size(112, 40)
      Me.txtCodice.TabIndex = 19
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmdDettagliSu
      '
      Me.cmdDettagliSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliSu.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliSu.Image = CType(resources.GetObject("cmdDettagliSu.Image"), System.Drawing.Image)
      Me.cmdDettagliSu.Location = New System.Drawing.Point(768, 423)
      Me.cmdDettagliSu.Name = "cmdDettagliSu"
      Me.cmdDettagliSu.Size = New System.Drawing.Size(152, 40)
      Me.cmdDettagliSu.TabIndex = 27
      Me.cmdDettagliSu.UseVisualStyleBackColor = False
      '
      'cmdDettagliGiù
      '
      Me.cmdDettagliGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliGiù.Image = CType(resources.GetObject("cmdDettagliGiù.Image"), System.Drawing.Image)
      Me.cmdDettagliGiù.Location = New System.Drawing.Point(608, 423)
      Me.cmdDettagliGiù.Name = "cmdDettagliGiù"
      Me.cmdDettagliGiù.Size = New System.Drawing.Size(152, 40)
      Me.cmdDettagliGiù.TabIndex = 26
      Me.cmdDettagliGiù.UseVisualStyleBackColor = False
      '
      'Label1
      '
      Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(608, 8)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(249, 31)
      Me.Label1.TabIndex = 69
      Me.Label1.Text = "PIATTI ESAURITI"
      '
      'cmd8
      '
      Me.cmd8.BackColor = System.Drawing.Color.SkyBlue
      Me.cmd8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd8.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd8.Image = CType(resources.GetObject("cmd8.Image"), System.Drawing.Image)
      Me.cmd8.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd8.Location = New System.Drawing.Point(0, 497)
      Me.cmd8.Name = "cmd8"
      Me.cmd8.Size = New System.Drawing.Size(136, 70)
      Me.cmd8.TabIndex = 68
      Me.cmd8.Text = "Acqua/Vino"
      Me.cmd8.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd8.UseVisualStyleBackColor = False
      '
      'cmd7
      '
      Me.cmd7.BackColor = System.Drawing.Color.Goldenrod
      Me.cmd7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd7.Image = CType(resources.GetObject("cmd7.Image"), System.Drawing.Image)
      Me.cmd7.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd7.Location = New System.Drawing.Point(0, 426)
      Me.cmd7.Name = "cmd7"
      Me.cmd7.Size = New System.Drawing.Size(136, 70)
      Me.cmd7.TabIndex = 67
      Me.cmd7.Text = "Bibite/Birre"
      Me.cmd7.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd7.UseVisualStyleBackColor = False
      '
      'cmd6
      '
      Me.cmd6.BackColor = System.Drawing.Color.Thistle
      Me.cmd6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd6.Image = CType(resources.GetObject("cmd6.Image"), System.Drawing.Image)
      Me.cmd6.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd6.Location = New System.Drawing.Point(0, 355)
      Me.cmd6.Name = "cmd6"
      Me.cmd6.Size = New System.Drawing.Size(136, 70)
      Me.cmd6.TabIndex = 66
      Me.cmd6.Text = "Dolci"
      Me.cmd6.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd6.UseVisualStyleBackColor = False
      '
      'cmd1
      '
      Me.cmd1.BackColor = System.Drawing.Color.Gainsboro
      Me.cmd1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd1.Image = CType(resources.GetObject("cmd1.Image"), System.Drawing.Image)
      Me.cmd1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd1.Location = New System.Drawing.Point(0, 0)
      Me.cmd1.Name = "cmd1"
      Me.cmd1.Size = New System.Drawing.Size(136, 70)
      Me.cmd1.TabIndex = 65
      Me.cmd1.Text = "Antipasti"
      Me.cmd1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd1.UseVisualStyleBackColor = False
      '
      'cmd2
      '
      Me.cmd2.BackColor = System.Drawing.Color.Beige
      Me.cmd2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd2.Image = CType(resources.GetObject("cmd2.Image"), System.Drawing.Image)
      Me.cmd2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd2.Location = New System.Drawing.Point(0, 71)
      Me.cmd2.Name = "cmd2"
      Me.cmd2.Size = New System.Drawing.Size(136, 70)
      Me.cmd2.TabIndex = 64
      Me.cmd2.Text = "Primi piatti"
      Me.cmd2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd2.UseVisualStyleBackColor = False
      '
      'cmd3
      '
      Me.cmd3.BackColor = System.Drawing.Color.IndianRed
      Me.cmd3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd3.Image = CType(resources.GetObject("cmd3.Image"), System.Drawing.Image)
      Me.cmd3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd3.Location = New System.Drawing.Point(0, 142)
      Me.cmd3.Name = "cmd3"
      Me.cmd3.Size = New System.Drawing.Size(136, 70)
      Me.cmd3.TabIndex = 63
      Me.cmd3.Text = "Pizze"
      Me.cmd3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd3.UseVisualStyleBackColor = False
      '
      'cmd4
      '
      Me.cmd4.BackColor = System.Drawing.Color.DarkGreen
      Me.cmd4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd4.Image = CType(resources.GetObject("cmd4.Image"), System.Drawing.Image)
      Me.cmd4.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd4.Location = New System.Drawing.Point(0, 213)
      Me.cmd4.Name = "cmd4"
      Me.cmd4.Size = New System.Drawing.Size(136, 70)
      Me.cmd4.TabIndex = 62
      Me.cmd4.Text = "Secondi"
      Me.cmd4.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd4.UseVisualStyleBackColor = False
      '
      'cmd5
      '
      Me.cmd5.BackColor = System.Drawing.Color.Purple
      Me.cmd5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd5.Image = CType(resources.GetObject("cmd5.Image"), System.Drawing.Image)
      Me.cmd5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd5.Location = New System.Drawing.Point(0, 284)
      Me.cmd5.Name = "cmd5"
      Me.cmd5.Size = New System.Drawing.Size(136, 70)
      Me.cmd5.TabIndex = 61
      Me.cmd5.Text = "Contorni"
      Me.cmd5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd5.UseVisualStyleBackColor = False
      '
      'pnlPiatti
      '
      Me.pnlPiatti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlPiatti.Location = New System.Drawing.Point(152, 8)
      Me.pnlPiatti.Name = "pnlPiatti"
      Me.pnlPiatti.Size = New System.Drawing.Size(314, 455)
      Me.pnlPiatti.TabIndex = 3
      '
      'pnlVariazioni
      '
      Me.pnlVariazioni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlVariazioni.Location = New System.Drawing.Point(472, 8)
      Me.pnlVariazioni.Name = "pnlVariazioni"
      Me.pnlVariazioni.Size = New System.Drawing.Size(130, 455)
      Me.pnlVariazioni.TabIndex = 6
      '
      'cmdRimuovi
      '
      Me.cmdRimuovi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdRimuovi.BackColor = System.Drawing.Color.LightCoral
      Me.cmdRimuovi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdRimuovi.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdRimuovi.ForeColor = System.Drawing.Color.White
      Me.cmdRimuovi.Location = New System.Drawing.Point(608, 471)
      Me.cmdRimuovi.Name = "cmdRimuovi"
      Me.cmdRimuovi.Size = New System.Drawing.Size(312, 40)
      Me.cmdRimuovi.TabIndex = 37
      Me.cmdRimuovi.Text = "&RIMUOVI"
      Me.cmdRimuovi.UseVisualStyleBackColor = False
      '
      'cmdConferma
      '
      Me.cmdConferma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdConferma.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdConferma.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdConferma.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdConferma.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdConferma.ForeColor = System.Drawing.Color.White
      Me.cmdConferma.Location = New System.Drawing.Point(608, 519)
      Me.cmdConferma.Name = "cmdConferma"
      Me.cmdConferma.Size = New System.Drawing.Size(312, 40)
      Me.cmdConferma.TabIndex = 36
      Me.cmdConferma.Text = "&CONFERMA"
      Me.cmdConferma.UseVisualStyleBackColor = False
      '
      'pnlCategoria
      '
      Me.pnlCategoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlCategoria.Location = New System.Drawing.Point(8, 8)
      Me.pnlCategoria.Name = "pnlCategoria"
      Me.pnlCategoria.Size = New System.Drawing.Size(138, 455)
      Me.pnlCategoria.TabIndex = 0
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.BackColor = System.Drawing.Color.White
      Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(608, 49)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(312, 32)
      Me.Label3.TabIndex = 78
      Me.Label3.Text = " Descrizione"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lstvDettagli
      '
      Me.lstvDettagli.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagli.BackColor = System.Drawing.Color.White
      Me.lstvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader2, Me.ColumnHeader7, Me.ColumnHeader8})
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagli.Location = New System.Drawing.Point(608, 80)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(312, 335)
      Me.lstvDettagli.TabIndex = 25
      Me.lstvDettagli.UseCompatibleStateImageBehavior = False
      Me.lstvDettagli.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Width = 0
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Width = 200
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Width = 93
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Width = 0
      '
      'dtpData
      '
      Me.dtpData.Anchor = System.Windows.Forms.AnchorStyles.Bottom
      Me.dtpData.Location = New System.Drawing.Point(-200, 875)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(200, 20)
      Me.dtpData.TabIndex = 86
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmVCEsauriti
      '
      Me.AcceptButton = Me.cmdConferma
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(928, 589)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.pnlCategoria)
      Me.Controls.Add(Me.cmdConferma)
      Me.Controls.Add(Me.cmdRimuovi)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtCodice)
      Me.Controls.Add(Me.cmdDettagliSu)
      Me.Controls.Add(Me.cmdDettagliGiù)
      Me.Controls.Add(Me.cmdOk)
      Me.Controls.Add(Me.cmdNum8)
      Me.Controls.Add(Me.cmdNum9)
      Me.Controls.Add(Me.cmdNum0)
      Me.Controls.Add(Me.cmdNum7)
      Me.Controls.Add(Me.cmdNum6)
      Me.Controls.Add(Me.cmdNum5)
      Me.Controls.Add(Me.cmdNum4)
      Me.Controls.Add(Me.cmdNum3)
      Me.Controls.Add(Me.cmdNum2)
      Me.Controls.Add(Me.cmdNum1)
      Me.Controls.Add(Me.cmdVariazioniSu)
      Me.Controls.Add(Me.cmdVariazioniGiù)
      Me.Controls.Add(Me.cmdPiattiSu)
      Me.Controls.Add(Me.cmdPiattiGiù)
      Me.Controls.Add(Me.cmdCategorieSu)
      Me.Controls.Add(Me.cmdCategorieGiù)
      Me.Controls.Add(Me.pnlVariazioni)
      Me.Controls.Add(Me.pnlPiatti)
      Me.ForeColor = System.Drawing.Color.White
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MinimizeBox = False
      Me.Name = "frmVCEsauriti"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Visual POS - PIATTI ESAURITI"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

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

   Public Function LeggiDatiCategorie(ByVal tabella As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY IdOrd ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CordY As Integer = 0
         Dim PrimoElememto As Boolean = True

         Do While dr.Read()
            If PrimoElememto = True Then
               CategoriaIniziale = dr.Item("Descrizione")
               PrimoElememto = False
            End If

            Dim colore As Integer
            If IsDBNull(dr.Item("Colore")) = False Then
               colore = dr.Item("Colore")
            Else
               colore = 0
            End If

            Dim icona As String
            If IsDBNull(dr.Item("Icona")) = False Then
               icona = dr.Item("Icona")
            Else
               icona = ""
            End If

            DisegnaCategoria(dr.Item("Id"), dr.Item("Descrizione"), "", Color.FromArgb(colore), icona, 0, CordY)
            CordY = CordY + ALTEZZA_CATEGORIA + 1
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDatiPiatto(ByVal tabella As String, ByVal codice As Integer) As Boolean
      Const QTA As String = "1"
      Dim trovato As Boolean = False
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & codice & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Indice
            lstvDettagli.Items.Add(lstvDettagli.Items.Count)

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Descrizione"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Categoria"))
            End If

            ' Id Piatto.
            If IsDBNull(dr.Item("Id")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Id"))
            End If

            ' Stringa per registrare loperazione effettuata dall'operatore identificato.
            strDescrizione = "(" & dr.Item("Descrizione") & ")"

            trovato = True
         Loop

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.SelezionaPiatto, strDescrizione, MODULO_PIATTI_ESAURITI)

         Return trovato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDatiPiatti(ByVal tabella As String, ByVal categoria As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Categoria = '" & categoria & "' AND Variazione = 'No' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CordX As Integer = 0
         Dim CordY As Integer = 0
         Dim i As Integer = 0

         Do While dr.Read()
            i += 1
            If IsDBNull(dr.Item("DescrizionePos")) = False Then
               DisegnaPiatto(dr.Item("Id"), dr.Item("DescrizionePos"), categoria, Color.FromArgb(dr.Item("Colore")), dr.Item("Icona"), CordX, CordY)
            Else
               DisegnaPiatto(dr.Item("Id"), "", categoria, dr.Item("Colore"), dr.Item("Icona"), CordX, CordY)
            End If
            CordX = CordX + LARGHEZZA_PIATTO + 1

            If i = 3 Then
               CordY = CordY + ALTEZZA_PIATTO + 1
               CordX = 0
               i = 0
            End If

         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDatiVariazioni(ByVal tabella As String, ByVal categoria As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Categoria = '" & categoria & "' AND Variazione = 'Sì' ORDER BY OrdCategoria ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CordX As Integer = 0
         Dim CordY As Integer = 0
         Dim i As Integer = 0

         Do While dr.Read()
            i += 1
            If IsDBNull(dr.Item("DescrizionePos")) = False Then
               DisegnaVariazione(dr.Item("Id"), dr.Item("DescrizionePos"), "", Color.FromArgb(dr.Item("Colore")), CordX, CordY)
            Else
               DisegnaVariazione(dr.Item("Id"), "", "", Color.Aqua, CordX, CordY)
            End If

            CordY = CordY + ALTEZZA_VARIAZIONE + 1
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Sub DisegnaCategoria(ByVal numero As String, ByVal nome As String, ByVal componenti As String, ByVal colore As Color, ByVal icona As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumCategorie += 1

         Categorie(NumCategorie) = New Button
         Categorie(NumCategorie).Name = numero
         Categorie(NumCategorie).Location = New Point(x, y)
         Categorie(NumCategorie).Size = New Size(LARGHEZZA_CATEGORIA, ALTEZZA_CATEGORIA)
         Categorie(NumCategorie).FlatStyle = FlatStyle.Popup
         Categorie(NumCategorie).BackColor = colore
         Categorie(NumCategorie).ForeColor = Color.Black
         Categorie(NumCategorie).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Categorie(NumCategorie).TextAlign = ContentAlignment.BottomCenter
         Categorie(NumCategorie).Text = nome
         Categorie(NumCategorie).Tag = componenti
         Categorie(NumCategorie).ImageAlign = ContentAlignment.TopCenter

         If File.Exists(icona) = True Then
            Dim bmp As New Bitmap(icona)
            Categorie(NumCategorie).Image = bmp
         End If

         'If note = "" Then
         '   ToolTip1.SetToolTip(Categorie(NumCategorie), "Nessuna nota.")
         'Else
         '   ToolTip1.SetToolTip(Categorie(NumCategorie), note)
         'End If

         pnlCategoria.Controls.Add(Categorie(NumCategorie))

         AddHandler Categorie(NumCategorie).Click, AddressOf Categorie_Click
         'AddHandler Categorie(NumCategorie).DoubleClick, AddressOf Categorie_DoubleClick
         'AddHandler Categorie(NumCategorie).GotFocus, AddressOf Categorie_GotFocus


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaPiatto(ByVal numero As String, ByVal nome As String, ByVal categoria As String, ByVal colore As Color, ByVal icona As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumPiatti += 1

         Piatti(NumPiatti) = New Button
         Piatti(NumPiatti).Name = numero
         Piatti(NumPiatti).Location = New Point(x, y)
         Piatti(NumPiatti).Size = New Size(LARGHEZZA_PIATTO, ALTEZZA_PIATTO)
         Piatti(NumPiatti).FlatStyle = FlatStyle.Popup
         Piatti(NumPiatti).BackColor = colore
         Piatti(NumPiatti).ForeColor = Color.Black
         Piatti(NumPiatti).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Piatti(NumPiatti).TextAlign = ContentAlignment.BottomCenter
         Piatti(NumPiatti).Text = nome
         Piatti(NumPiatti).Tag = categoria
         Piatti(NumPiatti).ImageAlign = ContentAlignment.TopCenter

         If File.Exists(icona) = True Then
            Dim bmp As New Bitmap(icona)
            Piatti(NumPiatti).Image = bmp
         End If

         'If note = "" Then
         '   ToolTip1.SetToolTip(Categorie(NumCategorie), "Nessuna nota.")
         'Else
         '   ToolTip1.SetToolTip(Categorie(NumCategorie), note)
         'End If

         pnlPiatti.Controls.Add(Piatti(NumPiatti))

         AddHandler Piatti(NumPiatti).Click, AddressOf Piatti_Click
         'AddHandler Piatti(NumPiatti).DoubleClick, AddressOf Piatti_DoubleClick
         'AddHandler Piatti(NumPiatti).GotFocus, AddressOf Piatti_GotFocus

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaVariazione(ByVal numero As String, ByVal nome As String, ByVal componenti As String, ByVal colore As Color, ByVal x As Integer, ByVal y As Integer)
      Try
         NumVariazioni += 1

         Variazioni(NumVariazioni) = New Button
         Variazioni(NumVariazioni).Name = numero
         Variazioni(NumVariazioni).Location = New Point(x, y)
         Variazioni(NumVariazioni).Size = New Size(LARGHEZZA_VARIAZIONE, ALTEZZA_VARIAZIONE)
         Variazioni(NumVariazioni).FlatStyle = FlatStyle.Popup
         Variazioni(NumVariazioni).BackColor = colore
         Variazioni(NumVariazioni).ForeColor = Color.Black
         Variazioni(NumVariazioni).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Variazioni(NumVariazioni).TextAlign = ContentAlignment.MiddleCenter
         Variazioni(NumVariazioni).Text = nome
         Variazioni(NumVariazioni).Tag = componenti

         'If note = "" Then
         '   ToolTip1.SetToolTip(Categorie(NumCategorie), "Nessuna nota.")
         'Else
         '   ToolTip1.SetToolTip(Categorie(NumCategorie), note)
         'End If

         pnlVariazioni.Controls.Add(Variazioni(NumVariazioni))

         AddHandler Variazioni(NumVariazioni).Click, AddressOf Variazioni_Click
         'AddHandler Variazioni(NumVariazioni).DoubleClick, AddressOf Variazioni_DoubleClick
         'AddHandler Variazioni(NumVariazioni).GotFocus, AddressOf Variazioni_GotFocus

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CancellaElemento()
      Try
         lstvDettagli.Focus()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.RimuoviPiatto, "(" & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text & ")", MODULO_PIATTI_ESAURITI)

         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Focus()
            lstvDettagli.Items.RemoveAt(lstvDettagli.FocusedItem.Index)
         End If

      Catch ex As NullReferenceException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function VerificaEsistenzaPiatto(ByVal codice As String) As Boolean
      Try
         Dim i As Integer
         For i = 0 To lstvDettagli.Items.Count - 1
            If lstvDettagli.Items(i).SubItems(3).Text = codice Then
               MsgBox("esiste! ")
               Return True
            End If
         Next

         Return False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub SelezionaPiatto(ByVal codice As String)
      Try
         If LeggiDatiPiatto(TAB_PIATTI, CInt(codice)) = False Then
            MsgBox("Codice inesistente!.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         txtCodice.Text = ""

         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).Focused = True
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).Selected = True
            lstvDettagli.Focus()
         End If
      End Try
   End Sub

   Private Sub ApriPiattiEsauriti()
      Try
         Dim CEsauriti As New PiattiEsauriti

         With CEsauriti
            .LeggiDati(lstvDettagli, TAB_PIATTI_ESAURITI)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function SalvaPiattiEsauriti() As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         Dim CEsauriti As New PiattiEsauriti
         Dim i As Integer

         With CEsauriti
            .EliminaDati(TAB_PIATTI_ESAURITI)

            For i = 0 To lstvDettagli.Items.Count - 1
               .Descrizione = lstvDettagli.Items(i).SubItems(1).Text
               .Categoria = lstvDettagli.Items(i).SubItems(2).Text
               .IdPiatto = lstvDettagli.Items(i).SubItems(3).Text

               .InserisciDati(TAB_PIATTI_ESAURITI)
            Next

         End With

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Salva, String.Empty, MODULO_PIATTI_ESAURITI)

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub Categorie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         pnlPiatti.Controls.Clear()
         NumPiatti = 0

         LeggiDatiPiatti(TAB_PIATTI, CType(sender, Button).Text)

         pnlVariazioni.Controls.Clear()
         NumVariazioni = 0

         LeggiDatiVariazioni(TAB_PIATTI, CType(sender, Button).Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Piatti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      If VerificaEsistenzaPiatto(CType(sender, Button).Name) = False Then
         SelezionaPiatto(CType(sender, Button).Name)
      End If
   End Sub

   Private Sub Variazioni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      SelezionaPiatto(CType(sender, Button).Name)
   End Sub

   Private Sub frmVCEsauriti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         If AbilitaPalmare = True Then
            g_frmVCTavoli.Timer3.Enabled = False
         End If

         LeggiDatiCategorie(TAB_CATEGORIE)

         LeggiDatiPiatti(TAB_PIATTI, CategoriaIniziale)

         LeggiDatiVariazioni(TAB_PIATTI, CategoriaIniziale)

         ApriPiattiEsauriti()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_PIATTI_ESAURITI, MODULO_PIATTI_ESAURITI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmVCEsauriti_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         If confermaModifiche = False Then
            Dim risposta As Integer
            risposta = MessageBox.Show("Si desidera confermare eventuali modifiche?", _
                                       NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If risposta = DialogResult.Yes Then
               SalvaPiattiEsauriti()
            End If
         End If

         If AbilitaPalmare = True Then
            g_frmVCTavoli.Timer3.Enabled = True
         End If

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_PIATTI_ESAURITI, MODULO_PIATTI_ESAURITI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdCategorieSu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCategorieSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlCategoria.Controls.Count = 0 Then
            Return
         End If

         If Categorie(1).Location.Y >= 0 Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlCategoria.Controls.Count
               Categorie(i).Location = New Point(0, Categorie(i).Location.Y + ALTEZZA_CATEGORIA + 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdCategorieGiù_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCategorieGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlCategoria.Controls.Count = 0 Then
            Return
         End If

         If Categorie(pnlCategoria.Controls.Count).Location.Y <= pnlCategoria.Size.Height - ALTEZZA_CATEGORIA Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlCategoria.Controls.Count
               Categorie(i).Location = New Point(0, Categorie(i).Location.Y - ALTEZZA_CATEGORIA - 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdNum1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum1.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "1"
   End Sub

   Private Sub cmdNum2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum2.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "2"
   End Sub

   Private Sub cmdNum3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum3.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "3"
   End Sub

   Private Sub cmdNum4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum4.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "4"
   End Sub

   Private Sub cmdNum5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum5.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "5"
   End Sub

   Private Sub cmdNum6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum6.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "6"
   End Sub

   Private Sub cmdNum7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum7.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "7"
   End Sub

   Private Sub cmdNum8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum8.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "8"
   End Sub

   Private Sub cmdNum9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum9.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "9"
   End Sub

   Private Sub cmdNum0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum0.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "0"
   End Sub

   Private Sub cmdVirgola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      txtCodice.Text = txtCodice.Text & "."
   End Sub

   Private Sub cmdVariazioniGiù_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVariazioniGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlVariazioni.Controls.Count = 0 Then
            Return
         End If

         If Variazioni(pnlVariazioni.Controls.Count).Location.Y <= pnlVariazioni.Size.Height - ALTEZZA_VARIAZIONE Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlVariazioni.Controls.Count
               Variazioni(i).Location = New Point(0, Variazioni(i).Location.Y - ALTEZZA_VARIAZIONE - 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdVariazioniSu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVariazioniSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlVariazioni.Controls.Count = 0 Then
            Return
         End If

         If Variazioni(1).Location.Y >= 0 Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlVariazioni.Controls.Count
               Variazioni(i).Location = New Point(0, Variazioni(i).Location.Y + ALTEZZA_VARIAZIONE + 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdPiattiGiù_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPiattiGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlPiatti.Controls.Count = 0 Then
            Return
         End If

         If Piatti(pnlPiatti.Controls.Count).Location.Y <= pnlPiatti.Size.Height - ALTEZZA_PIATTO Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlPiatti.Controls.Count
               Piatti(i).Location = New Point(Piatti(i).Location.X, Piatti(i).Location.Y - ALTEZZA_PIATTO - 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdPiattiSu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPiattiSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlPiatti.Controls.Count = 0 Then
            Return
         End If

         If Piatti(1).Location.Y >= 0 Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlPiatti.Controls.Count
               Piatti(i).Location = New Point(Piatti(i).Location.X, Piatti(i).Location.Y + ALTEZZA_PIATTO + 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdDettagliGiù_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDettagliGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvDettagli.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvDettagli.TopItem.Index

         IndiceLista = PrimoElemento + NumElementi

         If IndiceLista > lstvDettagli.Items.Count - 1 Then
            Exit Sub
         Else
            lstvDettagli.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdDettagliSu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDettagliSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvDettagli.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvDettagli.TopItem.Index

         IndiceLista = PrimoElemento - 1

         If IndiceLista < 0 Then
            Exit Sub
         Else
            lstvDettagli.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lstvDettagli_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvDettagli.Resize
      Try
         NumElementi = (lstvDettagli.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      If txtCodice.Text.Length <> 0 Then
         If IsNumeric(txtCodice.Text) Then
            SelezionaPiatto(txtCodice.Text)
         Else
            MsgBox("Inserire un valore numerico!.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
         End If
      End If
   End Sub

   Private Sub frmVCEsauriti_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      If Me.Width <= 936 Then
         Me.Width = 936
      End If

      If Me.Height <= 520 Then
         Me.Height = 520
      End If
   End Sub

   Private Sub txtCodice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodice.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub cmdRimuovi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRimuovi.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      CancellaElemento()
   End Sub

   Private Sub cmdConferma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConferma.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      confermaModifiche = True
      SalvaPiattiEsauriti()

      g_frmMain.CreaFileStatoTavoli(AbilitaPalmare)

      Me.Close()
   End Sub

End Class
