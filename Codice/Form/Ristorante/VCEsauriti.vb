' Nome form:            POS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/04/2006
' Data ultima modifica: 24/04/2006
' Descrizione:          Interfaccia Punto cassa - conto immediato

Imports System.IO
Imports System.Data.OleDb
Imports Softgroup.NetButton

Public Class frmVCEsauriti
   Inherits System.Windows.Forms.Form

   Const TAB_PIATTI As String = "Piatti"
   Const TAB_CATEGORIE As String = "CategoriePiatti"
   Const TAB_PIATTI_ESAURITI As String = "PiattiEsauriti"

   Const LARGHEZZA_CATEGORIA As Integer = 82
   Public ALTEZZA_CATEGORIA As Integer = 50
   Public LARGHEZZA_PIATTO As Integer = 100
   Public ALTEZZA_PIATTO As Integer = 100
   Const LARGHEZZA_VARIAZIONE As Integer = 82
   Public ALTEZZA_VARIAZIONE As Integer = 30
   Const ALTEZZA_RIGA_DETTAGLI As Integer = 22

   Public NUMERO_PIATTI_RIGA As Integer = 10

   Public Categorie() As NetButton
   Public NumCategorie As Integer = 0
   Public Piatti() As NetButton
   Public NumPiatti As Integer = 0
   Public Variazioni() As NetButton
   Public NumVariazioni As Integer = 0
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
   Private confermaModifiche As Boolean
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents netBtn_SottoCategoria As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_PiattiSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_PiattiGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_VarianteSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_VarianteGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_CategoriaSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_CategoriaGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_9 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_8 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_7 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_3 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_2 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_1 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_6 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_5 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_4 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_0 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_C As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Ok As Softgroup.NetButton.NetButton
   Friend WithEvents eui_txtCodice As Elegant.Ui.TextBox
   Friend WithEvents netBtn_Tastiera As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_ListaPiattiSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_ListaPiattiGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Conferma As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Esci As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Rimuovi As Softgroup.NetButton.NetButton
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button

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
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVCEsauriti))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
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
      Me.pnlCategoria = New System.Windows.Forms.Panel()
      Me.lstvDettagli = New System.Windows.Forms.ListView()
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.netBtn_SottoCategoria = New Softgroup.NetButton.NetButton()
      Me.netBtn_PiattiSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_PiattiGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_VarianteSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_VarianteGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_CategoriaSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_CategoriaGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_9 = New Softgroup.NetButton.NetButton()
      Me.netBtn_8 = New Softgroup.NetButton.NetButton()
      Me.netBtn_7 = New Softgroup.NetButton.NetButton()
      Me.netBtn_3 = New Softgroup.NetButton.NetButton()
      Me.netBtn_2 = New Softgroup.NetButton.NetButton()
      Me.netBtn_1 = New Softgroup.NetButton.NetButton()
      Me.netBtn_6 = New Softgroup.NetButton.NetButton()
      Me.netBtn_5 = New Softgroup.NetButton.NetButton()
      Me.netBtn_4 = New Softgroup.NetButton.NetButton()
      Me.netBtn_0 = New Softgroup.NetButton.NetButton()
      Me.netBtn_C = New Softgroup.NetButton.NetButton()
      Me.netBtn_Ok = New Softgroup.NetButton.NetButton()
      Me.eui_txtCodice = New Elegant.Ui.TextBox()
      Me.netBtn_Tastiera = New Softgroup.NetButton.NetButton()
      Me.netBtn_ListaPiattiSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_ListaPiattiGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_Esci = New Softgroup.NetButton.NetButton()
      Me.netBtn_Conferma = New Softgroup.NetButton.NetButton()
      Me.netBtn_Rimuovi = New Softgroup.NetButton.NetButton()
      Me.eui_cmdOk = New Elegant.Ui.Button()
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
      Me.cmd8.Visible = False
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
      Me.cmd7.Visible = False
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
      Me.cmd6.Visible = False
      '
      'cmd1
      '
      Me.cmd1.BackColor = System.Drawing.Color.Gainsboro
      Me.cmd1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd1.Image = CType(resources.GetObject("cmd1.Image"), System.Drawing.Image)
      Me.cmd1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd1.Location = New System.Drawing.Point(865, 476)
      Me.cmd1.Name = "cmd1"
      Me.cmd1.Size = New System.Drawing.Size(136, 70)
      Me.cmd1.TabIndex = 65
      Me.cmd1.Text = "Antipasti"
      Me.cmd1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd1.UseVisualStyleBackColor = False
      Me.cmd1.Visible = False
      '
      'cmd2
      '
      Me.cmd2.BackColor = System.Drawing.Color.Beige
      Me.cmd2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd2.Image = CType(resources.GetObject("cmd2.Image"), System.Drawing.Image)
      Me.cmd2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd2.Location = New System.Drawing.Point(2, 2)
      Me.cmd2.Name = "cmd2"
      Me.cmd2.Size = New System.Drawing.Size(136, 70)
      Me.cmd2.TabIndex = 64
      Me.cmd2.Text = "Primi piatti"
      Me.cmd2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd2.UseVisualStyleBackColor = False
      Me.cmd2.Visible = False
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
      Me.cmd3.Visible = False
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
      Me.cmd4.Visible = False
      '
      'cmd5
      '
      Me.cmd5.BackColor = System.Drawing.Color.Purple
      Me.cmd5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmd5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmd5.Image = CType(resources.GetObject("cmd5.Image"), System.Drawing.Image)
      Me.cmd5.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmd5.Location = New System.Drawing.Point(2, 284)
      Me.cmd5.Name = "cmd5"
      Me.cmd5.Size = New System.Drawing.Size(136, 70)
      Me.cmd5.TabIndex = 61
      Me.cmd5.Text = "Contorni"
      Me.cmd5.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmd5.UseVisualStyleBackColor = False
      Me.cmd5.Visible = False
      '
      'pnlPiatti
      '
      Me.pnlPiatti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlPiatti.Location = New System.Drawing.Point(149, 8)
      Me.pnlPiatti.Name = "pnlPiatti"
      Me.pnlPiatti.Size = New System.Drawing.Size(216, 333)
      Me.pnlPiatti.TabIndex = 3
      '
      'pnlVariazioni
      '
      Me.pnlVariazioni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlVariazioni.Location = New System.Drawing.Point(368, 8)
      Me.pnlVariazioni.Name = "pnlVariazioni"
      Me.pnlVariazioni.Size = New System.Drawing.Size(138, 333)
      Me.pnlVariazioni.TabIndex = 6
      '
      'pnlCategoria
      '
      Me.pnlCategoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlCategoria.Location = New System.Drawing.Point(8, 8)
      Me.pnlCategoria.Name = "pnlCategoria"
      Me.pnlCategoria.Size = New System.Drawing.Size(138, 333)
      Me.pnlCategoria.TabIndex = 0
      '
      'lstvDettagli
      '
      Me.lstvDettagli.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagli.BackColor = System.Drawing.Color.White
      Me.lstvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader2, Me.ColumnHeader7, Me.ColumnHeader8})
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me.lstvDettagli.Location = New System.Drawing.Point(655, 8)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(312, 337)
      Me.lstvDettagli.TabIndex = 13
      Me.lstvDettagli.UseCompatibleStateImageBehavior = False
      Me.lstvDettagli.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Width = 0
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Descrizione"
      Me.ColumnHeader2.Width = 200
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Text = "Categoria"
      Me.ColumnHeader7.Width = 93
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Width = 0
      '
      'dtpData
      '
      Me.dtpData.Anchor = System.Windows.Forms.AnchorStyles.Bottom
      Me.dtpData.Location = New System.Drawing.Point(-179, 778)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(200, 20)
      Me.dtpData.TabIndex = 86
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'netBtn_SottoCategoria
      '
      Me.netBtn_SottoCategoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_SottoCategoria.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_SottoCategoria.ColorDisabled = System.Drawing.Color.DeepSkyBlue
      Me.netBtn_SottoCategoria.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_SottoCategoria.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_SottoCategoria.ColorText = System.Drawing.Color.White
      Me.netBtn_SottoCategoria.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_SottoCategoria.CornerRadius = 2
      Me.netBtn_SottoCategoria.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_SottoCategoria.Location = New System.Drawing.Point(218, 347)
      Me.netBtn_SottoCategoria.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_SottoCategoria.Name = "netBtn_SottoCategoria"
      Me.netBtn_SottoCategoria.Size = New System.Drawing.Size(78, 56)
      Me.netBtn_SottoCategoria.TabIndex = 316
      Me.netBtn_SottoCategoria.Tag = ""
      Me.netBtn_SottoCategoria.TextButton = ""
      '
      'netBtn_PiattiSu
      '
      Me.netBtn_PiattiSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_PiattiSu.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_PiattiSu.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_PiattiSu.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_PiattiSu.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_PiattiSu.ColorText = System.Drawing.Color.White
      Me.netBtn_PiattiSu.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_PiattiSu.CornerRadius = 2
      Me.netBtn_PiattiSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_PiattiSu.Image = CType(resources.GetObject("netBtn_PiattiSu.Image"), System.Drawing.Image)
      Me.netBtn_PiattiSu.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_PiattiSu.Location = New System.Drawing.Point(297, 347)
      Me.netBtn_PiattiSu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_PiattiSu.Name = "netBtn_PiattiSu"
      Me.netBtn_PiattiSu.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_PiattiSu.TabIndex = 5
      Me.netBtn_PiattiSu.TextButton = ""
      '
      'netBtn_PiattiGiù
      '
      Me.netBtn_PiattiGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_PiattiGiù.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_PiattiGiù.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_PiattiGiù.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_PiattiGiù.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_PiattiGiù.ColorText = System.Drawing.Color.White
      Me.netBtn_PiattiGiù.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_PiattiGiù.CornerRadius = 2
      Me.netBtn_PiattiGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_PiattiGiù.Image = CType(resources.GetObject("netBtn_PiattiGiù.Image"), System.Drawing.Image)
      Me.netBtn_PiattiGiù.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_PiattiGiù.Location = New System.Drawing.Point(149, 347)
      Me.netBtn_PiattiGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_PiattiGiù.Name = "netBtn_PiattiGiù"
      Me.netBtn_PiattiGiù.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_PiattiGiù.TabIndex = 4
      Me.netBtn_PiattiGiù.TextButton = ""
      '
      'netBtn_VarianteSu
      '
      Me.netBtn_VarianteSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_VarianteSu.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_VarianteSu.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_VarianteSu.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_VarianteSu.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_VarianteSu.ColorText = System.Drawing.Color.White
      Me.netBtn_VarianteSu.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_VarianteSu.CornerRadius = 2
      Me.netBtn_VarianteSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_VarianteSu.Image = CType(resources.GetObject("netBtn_VarianteSu.Image"), System.Drawing.Image)
      Me.netBtn_VarianteSu.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_VarianteSu.Location = New System.Drawing.Point(438, 347)
      Me.netBtn_VarianteSu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_VarianteSu.Name = "netBtn_VarianteSu"
      Me.netBtn_VarianteSu.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_VarianteSu.TabIndex = 8
      Me.netBtn_VarianteSu.TextButton = ""
      '
      'netBtn_VarianteGiù
      '
      Me.netBtn_VarianteGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_VarianteGiù.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_VarianteGiù.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_VarianteGiù.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_VarianteGiù.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_VarianteGiù.ColorText = System.Drawing.Color.White
      Me.netBtn_VarianteGiù.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_VarianteGiù.CornerRadius = 2
      Me.netBtn_VarianteGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_VarianteGiù.Image = CType(resources.GetObject("netBtn_VarianteGiù.Image"), System.Drawing.Image)
      Me.netBtn_VarianteGiù.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_VarianteGiù.Location = New System.Drawing.Point(368, 347)
      Me.netBtn_VarianteGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_VarianteGiù.Name = "netBtn_VarianteGiù"
      Me.netBtn_VarianteGiù.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_VarianteGiù.TabIndex = 7
      Me.netBtn_VarianteGiù.TextButton = ""
      '
      'netBtn_CategoriaSu
      '
      Me.netBtn_CategoriaSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_CategoriaSu.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_CategoriaSu.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_CategoriaSu.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_CategoriaSu.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_CategoriaSu.ColorText = System.Drawing.Color.White
      Me.netBtn_CategoriaSu.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_CategoriaSu.CornerRadius = 2
      Me.netBtn_CategoriaSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_CategoriaSu.Image = CType(resources.GetObject("netBtn_CategoriaSu.Image"), System.Drawing.Image)
      Me.netBtn_CategoriaSu.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_CategoriaSu.Location = New System.Drawing.Point(78, 347)
      Me.netBtn_CategoriaSu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_CategoriaSu.Name = "netBtn_CategoriaSu"
      Me.netBtn_CategoriaSu.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_CategoriaSu.TabIndex = 2
      Me.netBtn_CategoriaSu.TextButton = ""
      '
      'netBtn_CategoriaGiù
      '
      Me.netBtn_CategoriaGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_CategoriaGiù.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_CategoriaGiù.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_CategoriaGiù.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_CategoriaGiù.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_CategoriaGiù.ColorText = System.Drawing.Color.White
      Me.netBtn_CategoriaGiù.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_CategoriaGiù.CornerRadius = 2
      Me.netBtn_CategoriaGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_CategoriaGiù.Image = CType(resources.GetObject("netBtn_CategoriaGiù.Image"), System.Drawing.Image)
      Me.netBtn_CategoriaGiù.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_CategoriaGiù.Location = New System.Drawing.Point(8, 347)
      Me.netBtn_CategoriaGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_CategoriaGiù.Name = "netBtn_CategoriaGiù"
      Me.netBtn_CategoriaGiù.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_CategoriaGiù.TabIndex = 1
      Me.netBtn_CategoriaGiù.TextButton = ""
      '
      'netBtn_9
      '
      Me.netBtn_9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_9.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_9.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_9.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_9.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_9.ColorText = System.Drawing.Color.Black
      Me.netBtn_9.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_9.CornerRadius = 2
      Me.netBtn_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_9.Location = New System.Drawing.Point(464, 409)
      Me.netBtn_9.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_9.Name = "netBtn_9"
      Me.netBtn_9.Size = New System.Drawing.Size(56, 56)
      Me.netBtn_9.TabIndex = 24
      Me.netBtn_9.TextButton = "9"
      '
      'netBtn_8
      '
      Me.netBtn_8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_8.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_8.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_8.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_8.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_8.ColorText = System.Drawing.Color.Black
      Me.netBtn_8.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_8.CornerRadius = 2
      Me.netBtn_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_8.Location = New System.Drawing.Point(407, 409)
      Me.netBtn_8.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_8.Name = "netBtn_8"
      Me.netBtn_8.Size = New System.Drawing.Size(56, 56)
      Me.netBtn_8.TabIndex = 23
      Me.netBtn_8.TextButton = "8"
      '
      'netBtn_7
      '
      Me.netBtn_7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_7.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_7.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_7.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_7.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_7.ColorText = System.Drawing.Color.Black
      Me.netBtn_7.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_7.CornerRadius = 2
      Me.netBtn_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_7.Location = New System.Drawing.Point(350, 409)
      Me.netBtn_7.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_7.Name = "netBtn_7"
      Me.netBtn_7.Size = New System.Drawing.Size(56, 56)
      Me.netBtn_7.TabIndex = 22
      Me.netBtn_7.TextButton = "7"
      '
      'netBtn_3
      '
      Me.netBtn_3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_3.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_3.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_3.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_3.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_3.ColorText = System.Drawing.Color.Black
      Me.netBtn_3.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_3.CornerRadius = 2
      Me.netBtn_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_3.Location = New System.Drawing.Point(122, 409)
      Me.netBtn_3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_3.Name = "netBtn_3"
      Me.netBtn_3.Size = New System.Drawing.Size(56, 56)
      Me.netBtn_3.TabIndex = 18
      Me.netBtn_3.TextButton = "3"
      '
      'netBtn_2
      '
      Me.netBtn_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_2.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_2.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_2.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_2.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_2.ColorText = System.Drawing.Color.Black
      Me.netBtn_2.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_2.CornerRadius = 2
      Me.netBtn_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_2.Location = New System.Drawing.Point(65, 409)
      Me.netBtn_2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_2.Name = "netBtn_2"
      Me.netBtn_2.Size = New System.Drawing.Size(56, 56)
      Me.netBtn_2.TabIndex = 17
      Me.netBtn_2.TextButton = "2"
      '
      'netBtn_1
      '
      Me.netBtn_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_1.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_1.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_1.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_1.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_1.ColorText = System.Drawing.Color.Black
      Me.netBtn_1.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_1.CornerRadius = 2
      Me.netBtn_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_1.Location = New System.Drawing.Point(8, 409)
      Me.netBtn_1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_1.Name = "netBtn_1"
      Me.netBtn_1.Size = New System.Drawing.Size(56, 56)
      Me.netBtn_1.TabIndex = 16
      Me.netBtn_1.TextButton = "1"
      '
      'netBtn_6
      '
      Me.netBtn_6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_6.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_6.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_6.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_6.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_6.ColorText = System.Drawing.Color.Black
      Me.netBtn_6.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_6.CornerRadius = 2
      Me.netBtn_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_6.Location = New System.Drawing.Point(293, 409)
      Me.netBtn_6.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_6.Name = "netBtn_6"
      Me.netBtn_6.Size = New System.Drawing.Size(56, 56)
      Me.netBtn_6.TabIndex = 21
      Me.netBtn_6.TextButton = "6"
      '
      'netBtn_5
      '
      Me.netBtn_5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_5.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_5.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_5.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_5.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_5.ColorText = System.Drawing.Color.Black
      Me.netBtn_5.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_5.CornerRadius = 2
      Me.netBtn_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_5.Location = New System.Drawing.Point(236, 409)
      Me.netBtn_5.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_5.Name = "netBtn_5"
      Me.netBtn_5.Size = New System.Drawing.Size(56, 56)
      Me.netBtn_5.TabIndex = 20
      Me.netBtn_5.TextButton = "5"
      '
      'netBtn_4
      '
      Me.netBtn_4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_4.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_4.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_4.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_4.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_4.ColorText = System.Drawing.Color.Black
      Me.netBtn_4.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_4.CornerRadius = 2
      Me.netBtn_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_4.Location = New System.Drawing.Point(179, 409)
      Me.netBtn_4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_4.Name = "netBtn_4"
      Me.netBtn_4.Size = New System.Drawing.Size(56, 56)
      Me.netBtn_4.TabIndex = 19
      Me.netBtn_4.TextButton = "4"
      '
      'netBtn_0
      '
      Me.netBtn_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_0.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_0.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_0.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_0.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_0.ColorText = System.Drawing.Color.Black
      Me.netBtn_0.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_0.CornerRadius = 2
      Me.netBtn_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_0.Location = New System.Drawing.Point(521, 409)
      Me.netBtn_0.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_0.Name = "netBtn_0"
      Me.netBtn_0.Size = New System.Drawing.Size(56, 56)
      Me.netBtn_0.TabIndex = 25
      Me.netBtn_0.TextButton = "0"
      '
      'netBtn_C
      '
      Me.netBtn_C.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_C.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.netBtn_C.ColorDisabled = System.Drawing.Color.Brown
      Me.netBtn_C.ColorLight = System.Drawing.Color.MistyRose
      Me.netBtn_C.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Red
      Me.netBtn_C.ColorText = System.Drawing.Color.Black
      Me.netBtn_C.ColorTop = System.Drawing.Color.White
      Me.netBtn_C.CornerRadius = 2
      Me.netBtn_C.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_C.Location = New System.Drawing.Point(655, 409)
      Me.netBtn_C.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_C.Name = "netBtn_C"
      Me.netBtn_C.Size = New System.Drawing.Size(92, 56)
      Me.netBtn_C.TabIndex = 26
      Me.netBtn_C.TextButton = "C"
      '
      'netBtn_Ok
      '
      Me.netBtn_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Ok.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(40, Byte), Integer))
      Me.netBtn_Ok.ColorDisabled = System.Drawing.Color.SeaGreen
      Me.netBtn_Ok.ColorLight = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(189, Byte), Integer))
      Me.netBtn_Ok.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Green
      Me.netBtn_Ok.ColorText = System.Drawing.Color.Black
      Me.netBtn_Ok.ColorTop = System.Drawing.Color.White
      Me.netBtn_Ok.CornerRadius = 2
      Me.netBtn_Ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Ok.Location = New System.Drawing.Point(750, 409)
      Me.netBtn_Ok.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Ok.Name = "netBtn_Ok"
      Me.netBtn_Ok.Size = New System.Drawing.Size(217, 56)
      Me.netBtn_Ok.TabIndex = 27
      Me.netBtn_Ok.TextButton = "OK"
      '
      'eui_txtCodice
      '
      Me.eui_txtCodice.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtCodice.BannerTextColor = System.Drawing.SystemColors.GrayText
      Me.eui_txtCodice.BannerTextFont = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCodice.Id = "25dccf24-fe71-4a31-bda2-c5bf246a85aa"
      Me.eui_txtCodice.Location = New System.Drawing.Point(583, 409)
      Me.eui_txtCodice.Name = "eui_txtCodice"
      Me.eui_txtCodice.Size = New System.Drawing.Size(66, 50)
      Me.eui_txtCodice.TabIndex = 0
      Me.eui_txtCodice.TextEditorWidth = 288
      '
      'netBtn_Tastiera
      '
      Me.netBtn_Tastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Tastiera.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Tastiera.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Tastiera.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Tastiera.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Tastiera.ColorText = System.Drawing.Color.White
      Me.netBtn_Tastiera.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Tastiera.CornerRadius = 2
      Me.netBtn_Tastiera.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Tastiera.Image = CType(resources.GetObject("netBtn_Tastiera.Image"), System.Drawing.Image)
      Me.netBtn_Tastiera.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_Tastiera.Location = New System.Drawing.Point(519, 347)
      Me.netBtn_Tastiera.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Tastiera.Name = "netBtn_Tastiera"
      Me.netBtn_Tastiera.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Tastiera.TabIndex = 12
      Me.netBtn_Tastiera.TextButton = ""
      '
      'netBtn_ListaPiattiSu
      '
      Me.netBtn_ListaPiattiSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_ListaPiattiSu.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_ListaPiattiSu.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_ListaPiattiSu.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_ListaPiattiSu.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_ListaPiattiSu.ColorText = System.Drawing.Color.White
      Me.netBtn_ListaPiattiSu.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_ListaPiattiSu.CornerRadius = 2
      Me.netBtn_ListaPiattiSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_ListaPiattiSu.Image = CType(resources.GetObject("netBtn_ListaPiattiSu.Image"), System.Drawing.Image)
      Me.netBtn_ListaPiattiSu.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_ListaPiattiSu.Location = New System.Drawing.Point(812, 347)
      Me.netBtn_ListaPiattiSu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ListaPiattiSu.Name = "netBtn_ListaPiattiSu"
      Me.netBtn_ListaPiattiSu.Size = New System.Drawing.Size(155, 56)
      Me.netBtn_ListaPiattiSu.TabIndex = 15
      Me.netBtn_ListaPiattiSu.TextButton = ""
      '
      'netBtn_ListaPiattiGiù
      '
      Me.netBtn_ListaPiattiGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_ListaPiattiGiù.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_ListaPiattiGiù.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_ListaPiattiGiù.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_ListaPiattiGiù.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_ListaPiattiGiù.ColorText = System.Drawing.Color.White
      Me.netBtn_ListaPiattiGiù.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_ListaPiattiGiù.CornerRadius = 2
      Me.netBtn_ListaPiattiGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_ListaPiattiGiù.Image = CType(resources.GetObject("netBtn_ListaPiattiGiù.Image"), System.Drawing.Image)
      Me.netBtn_ListaPiattiGiù.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_ListaPiattiGiù.Location = New System.Drawing.Point(655, 347)
      Me.netBtn_ListaPiattiGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ListaPiattiGiù.Name = "netBtn_ListaPiattiGiù"
      Me.netBtn_ListaPiattiGiù.Size = New System.Drawing.Size(155, 56)
      Me.netBtn_ListaPiattiGiù.TabIndex = 14
      Me.netBtn_ListaPiattiGiù.TextButton = ""
      '
      'netBtn_Esci
      '
      Me.netBtn_Esci.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Esci.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.netBtn_Esci.ColorDisabled = System.Drawing.Color.Brown
      Me.netBtn_Esci.ColorLight = System.Drawing.Color.MistyRose
      Me.netBtn_Esci.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Red
      Me.netBtn_Esci.ColorText = System.Drawing.Color.Black
      Me.netBtn_Esci.ColorTop = System.Drawing.Color.White
      Me.netBtn_Esci.CornerRadius = 2
      Me.netBtn_Esci.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Esci.Location = New System.Drawing.Point(519, 110)
      Me.netBtn_Esci.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Esci.Name = "netBtn_Esci"
      Me.netBtn_Esci.Size = New System.Drawing.Size(130, 100)
      Me.netBtn_Esci.TabIndex = 10
      Me.netBtn_Esci.TextButton = "Esci"
      '
      'netBtn_Conferma
      '
      Me.netBtn_Conferma.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Conferma.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(40, Byte), Integer))
      Me.netBtn_Conferma.ColorDisabled = System.Drawing.Color.SeaGreen
      Me.netBtn_Conferma.ColorLight = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(189, Byte), Integer))
      Me.netBtn_Conferma.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Green
      Me.netBtn_Conferma.ColorText = System.Drawing.Color.Black
      Me.netBtn_Conferma.ColorTop = System.Drawing.Color.White
      Me.netBtn_Conferma.CornerRadius = 2
      Me.netBtn_Conferma.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Conferma.Location = New System.Drawing.Point(519, 8)
      Me.netBtn_Conferma.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Conferma.Name = "netBtn_Conferma"
      Me.netBtn_Conferma.Size = New System.Drawing.Size(130, 100)
      Me.netBtn_Conferma.TabIndex = 9
      Me.netBtn_Conferma.TextButton = "Conferma"
      '
      'netBtn_Rimuovi
      '
      Me.netBtn_Rimuovi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Rimuovi.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Rimuovi.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Rimuovi.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Rimuovi.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Rimuovi.ColorText = System.Drawing.Color.White
      Me.netBtn_Rimuovi.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Rimuovi.CornerRadius = 2
      Me.netBtn_Rimuovi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Rimuovi.Location = New System.Drawing.Point(519, 211)
      Me.netBtn_Rimuovi.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Rimuovi.Name = "netBtn_Rimuovi"
      Me.netBtn_Rimuovi.Size = New System.Drawing.Size(130, 100)
      Me.netBtn_Rimuovi.TabIndex = 11
      Me.netBtn_Rimuovi.TextButton = "Rimuovi"
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdOk.Id = "4955da7b-b7d5-4547-87f6-d454b70e3741"
      Me.eui_cmdOk.Location = New System.Drawing.Point(880, 469)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(85, 24)
      Me.eui_cmdOk.TabIndex = 320
      Me.eui_cmdOk.Text = "OK"
      Me.eui_cmdOk.Visible = False
      '
      'frmVCEsauriti
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(970, 492)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.netBtn_Rimuovi)
      Me.Controls.Add(Me.netBtn_Conferma)
      Me.Controls.Add(Me.netBtn_Esci)
      Me.Controls.Add(Me.netBtn_ListaPiattiSu)
      Me.Controls.Add(Me.netBtn_ListaPiattiGiù)
      Me.Controls.Add(Me.netBtn_Tastiera)
      Me.Controls.Add(Me.eui_txtCodice)
      Me.Controls.Add(Me.netBtn_C)
      Me.Controls.Add(Me.netBtn_Ok)
      Me.Controls.Add(Me.netBtn_0)
      Me.Controls.Add(Me.netBtn_9)
      Me.Controls.Add(Me.netBtn_8)
      Me.Controls.Add(Me.netBtn_7)
      Me.Controls.Add(Me.netBtn_3)
      Me.Controls.Add(Me.netBtn_2)
      Me.Controls.Add(Me.netBtn_1)
      Me.Controls.Add(Me.netBtn_6)
      Me.Controls.Add(Me.netBtn_5)
      Me.Controls.Add(Me.netBtn_4)
      Me.Controls.Add(Me.netBtn_SottoCategoria)
      Me.Controls.Add(Me.netBtn_PiattiSu)
      Me.Controls.Add(Me.netBtn_PiattiGiù)
      Me.Controls.Add(Me.netBtn_VarianteSu)
      Me.Controls.Add(Me.netBtn_VarianteGiù)
      Me.Controls.Add(Me.netBtn_CategoriaSu)
      Me.Controls.Add(Me.netBtn_CategoriaGiù)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.pnlCategoria)
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

   Private Function CalcolaLarghezzaPiatto() As Integer
      Try
         Dim larghezzaPulsante As Double = (pnlPiatti.Width - (NUMERO_PIATTI_RIGA - 1)) / NUMERO_PIATTI_RIGA ' Il numero di pulsanti per riga.

         ' Calcolo il 60% della larghezza del pulsante.
         Return (larghezzaPulsante * 60) / 100

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return LARGHEZZA_PIATTO

      End Try
   End Function

   Public Function LeggiDatiCategorie0(ByVal tabella As String) As Boolean
      '' Dichiara un oggetto connessione.
      'Dim cn As New OleDbConnection(ConnString)

      'Try
      '   cn.Open()

      '   Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY IdOrd ASC", cn)
      '   Dim dr As OleDbDataReader = cmd.ExecuteReader()

      '   Dim CordY As Integer = 0
      '   Dim PrimoElememto As Boolean = True

      '   Do While dr.Read()
      '      If PrimoElememto = True Then
      '         CategoriaIniziale = dr.Item("Descrizione")
      '         PrimoElememto = False
      '      End If

      '      Dim colore As Integer
      '      If IsDBNull(dr.Item("Colore")) = False Then
      '         colore = dr.Item("Colore")
      '      Else
      '         colore = 0
      '      End If

      '      Dim icona As String
      '      If IsDBNull(dr.Item("Icona")) = False Then
      '         icona = dr.Item("Icona")
      '      Else
      '         icona = ""
      '      End If

      '      DisegnaCategoria(dr.Item("Id"), dr.Item("Descrizione"), "", Color.FromArgb(colore), icona, 0, CordY)
      '      CordY = CordY + ALTEZZA_CATEGORIA + 1
      '   Loop

      '   Return True

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   cn.Close()

      'End Try
   End Function

   Public Function LeggiDatiCategorie(ByVal tabella As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY OrdineTasto ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CordY As Integer = 0
         Dim PrimoElememto As Boolean = True

         Do While dr.Read()
            If PrimoElememto = True Then
               CategoriaIniziale = dr.Item("Descrizione").ToString
               PrimoElememto = False
            End If

            Dim immagine As String
            If IsDBNull(dr.Item("Icona")) = False Then
               immagine = dr.Item("Icona").ToString
            Else
               immagine = ""
            End If

            DisegnaCategoria(dr.Item("Id").ToString, dr.Item("Descrizione").ToString, String.Empty, Convert.ToInt32(dr.Item("AltezzaTasto")), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), immagine, 0, CordY)

            ALTEZZA_CATEGORIA = Convert.ToInt32(dr.Item("AltezzaTasto"))
            CordY = CordY + ALTEZZA_CATEGORIA + 1

            Application.DoEvents()
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

   Public Function LeggiDatiPiatti0(ByVal tabella As String, ByVal categoria As String) As Boolean
      '' Dichiara un oggetto connessione.
      'Dim cn As New OleDbConnection(ConnString)

      'Try
      '   cn.Open()

      '   Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Categoria = '" & categoria & "' AND Variazione = 'No' ORDER BY Id ASC", cn)
      '   Dim dr As OleDbDataReader = cmd.ExecuteReader()

      '   Dim CordX As Integer = 0
      '   Dim CordY As Integer = 0
      '   Dim i As Integer = 0

      '   Do While dr.Read()
      '      i += 1
      '      If IsDBNull(dr.Item("DescrizionePos")) = False Then
      '         DisegnaPiatto(dr.Item("Id"), dr.Item("DescrizionePos"), categoria, Color.FromArgb(dr.Item("Colore")), dr.Item("Icona"), CordX, CordY)
      '      Else
      '         DisegnaPiatto(dr.Item("Id"), "", categoria, dr.Item("Colore"), dr.Item("Icona"), CordX, CordY)
      '      End If
      '      CordX = CordX + LARGHEZZA_PIATTO + 1

      '      If i = 3 Then
      '         CordY = CordY + ALTEZZA_PIATTO + 1
      '         CordX = 0
      '         i = 0
      '      End If

      '   Loop

      '   Return True

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   cn.Close()

      'End Try
   End Function

   Public Function LeggiDatiPiatti(ByVal tabella As String, ByVal categoria As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Categoria = '" & categoria & "' AND Variazione = 'No' ORDER BY OrdineTasto ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CordX As Integer = 0
         Dim CordY As Integer = 0
         Dim i As Integer = 0

         Do While dr.Read()
            i += 1
            If IsDBNull(dr.Item("DescrizionePos")) = False Then
               DisegnaPiatto(dr.Item("Id").ToString, dr.Item("DescrizionePos").ToString, categoria, Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), dr.Item("Icona").ToString, CordX, CordY)
            Else
               DisegnaPiatto(dr.Item("Id").ToString, String.Empty, categoria, Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), dr.Item("Icona").ToString, CordX, CordY)
            End If

            CordX = CordX + LARGHEZZA_PIATTO + 1

            If i = NUMERO_PIATTI_RIGA Then
               CordY = CordY + ALTEZZA_PIATTO + 1
               CordX = 0
               i = 0
            End If

            Application.DoEvents()
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDatiVariazioni0(ByVal tabella As String, ByVal categoria As String) As Boolean
      '' Dichiara un oggetto connessione.
      'Dim cn As New OleDbConnection(ConnString)

      'Try
      '   cn.Open()

      '   Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Categoria = '" & categoria & "' AND Variazione = 'Sì' ORDER BY OrdCategoria ASC", cn)
      '   Dim dr As OleDbDataReader = cmd.ExecuteReader()

      '   Dim CordX As Integer = 0
      '   Dim CordY As Integer = 0
      '   Dim i As Integer = 0

      '   Do While dr.Read()
      '      i += 1
      '      If IsDBNull(dr.Item("DescrizionePos")) = False Then
      '         DisegnaVariazione(dr.Item("Id"), dr.Item("DescrizionePos"), "", Color.FromArgb(dr.Item("Colore")), CordX, CordY)
      '      Else
      '         DisegnaVariazione(dr.Item("Id"), "", "", Color.Aqua, CordX, CordY)
      '      End If

      '      CordY = CordY + ALTEZZA_VARIAZIONE + 1
      '   Loop

      '   Return True

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'Finally
      '   cn.Close()

      'End Try
   End Function

   Public Function LeggiDatiVariazioni(ByVal tabella As String, ByVal categoria As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Categoria = '" & categoria & "' AND Variazione = 'Sì' ORDER BY OrdineTasto ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CordX As Integer = 0
         Dim CordY As Integer = 0
         Dim i As Integer = 0

         Do While dr.Read()
            i += 1
            If IsDBNull(dr.Item("DescrizionePos")) = False Then
               DisegnaVariazione(dr.Item("Id").ToString, dr.Item("DescrizionePos").ToString, String.Empty, Convert.ToInt32(dr.Item("AltezzaTasto")), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), dr.Item("Icona").ToString, CordX, CordY)
            Else
               DisegnaVariazione(dr.Item("Id").ToString, String.Empty, String.Empty, Convert.ToInt32(dr.Item("AltezzaTasto")), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), dr.Item("Icona").ToString, CordX, CordY)
            End If

            ALTEZZA_VARIAZIONE = Convert.ToInt32(dr.Item("AltezzaTasto"))
            CordY = CordY + ALTEZZA_VARIAZIONE + 1

            Application.DoEvents()
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Sub DisegnaCategoria0(ByVal numero As String, ByVal nome As String, ByVal componenti As String, ByVal colore As Color, ByVal icona As String, ByVal x As Integer, ByVal y As Integer)
      'Try
      '   NumCategorie += 1

      '   Categorie(NumCategorie) = New Button
      '   Categorie(NumCategorie).Name = numero
      '   Categorie(NumCategorie).Location = New Point(x, y)
      '   Categorie(NumCategorie).Size = New Size(LARGHEZZA_CATEGORIA, ALTEZZA_CATEGORIA)
      '   Categorie(NumCategorie).FlatStyle = FlatStyle.Popup
      '   Categorie(NumCategorie).BackColor = colore
      '   Categorie(NumCategorie).ForeColor = Color.Black
      '   Categorie(NumCategorie).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
      '   Categorie(NumCategorie).TextAlign = ContentAlignment.BottomCenter
      '   Categorie(NumCategorie).Text = nome
      '   Categorie(NumCategorie).Tag = componenti
      '   Categorie(NumCategorie).ImageAlign = ContentAlignment.TopCenter

      '   If File.Exists(icona) = True Then
      '      Dim bmp As New Bitmap(icona)
      '      Categorie(NumCategorie).Image = bmp
      '   End If

      '   'If note = "" Then
      '   '   ToolTip1.SetToolTip(Categorie(NumCategorie), "Nessuna nota.")
      '   'Else
      '   '   ToolTip1.SetToolTip(Categorie(NumCategorie), note)
      '   'End If

      '   pnlCategoria.Controls.Add(Categorie(NumCategorie))

      '   AddHandler Categorie(NumCategorie).Click, AddressOf Categorie_Click
      '   'AddHandler Categorie(NumCategorie).DoubleClick, AddressOf Categorie_DoubleClick
      '   'AddHandler Categorie(NumCategorie).GotFocus, AddressOf Categorie_GotFocus


      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub
   Private Sub DisegnaCategoria(ByVal numero As String, ByVal nome As String, ByVal componenti As String, ByVal altezza As Integer, ByVal coloreSfondo As Color, ByVal coloreTesto As Color, ByVal immagine As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumCategorie += 1

         Categorie(NumCategorie) = New NetButton
         Categorie(NumCategorie).Name = numero
         Categorie(NumCategorie).CornerRadius = 2
         Categorie(NumCategorie).Location = New Point(x, y)
         Categorie(NumCategorie).Size = New Size(LARGHEZZA_CATEGORIA, altezza)
         Categorie(NumCategorie).ColorBottom = coloreSfondo
         Categorie(NumCategorie).ColorText = coloreTesto
         Categorie(NumCategorie).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Categorie(NumCategorie).TextButton = nome
         Categorie(NumCategorie).Tag = componenti
         Categorie(NumCategorie).ImageAlign = ContentAlignment.TopCenter

         If File.Exists(immagine) = True Then
            Dim bmp As New Bitmap(immagine)
            Categorie(NumCategorie).Image = bmp
            Categorie(NumCategorie).TextButtonAlign = ContentAlignment.BottomCenter
         End If

         'If note = "" Then
         '   ToolTip1.SetToolTip(Categorie(NumCategorie), "Nessuna nota.")
         'Else
         '   ToolTip1.SetToolTip(Categorie(NumCategorie), note)
         'End If

         pnlCategoria.Controls.Add(Categorie(NumCategorie))
         'Panel1.Controls.Add(Categorie(NumCategorie))

         AddHandler Categorie(NumCategorie).Click, AddressOf Categorie_Click
         'AddHandler Categorie(NumCategorie).DoubleClick, AddressOf Categorie_DoubleClick
         'AddHandler Categorie(NumCategorie).GotFocus, AddressOf Categorie_GotFocus


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaPiatto0(ByVal numero As String, ByVal nome As String, ByVal categoria As String, ByVal colore As Color, ByVal icona As String, ByVal x As Integer, ByVal y As Integer)
      'Try
      '   NumPiatti += 1

      '   Piatti(NumPiatti) = New Button
      '   Piatti(NumPiatti).Name = numero
      '   Piatti(NumPiatti).Location = New Point(x, y)
      '   Piatti(NumPiatti).Size = New Size(LARGHEZZA_PIATTO, ALTEZZA_PIATTO)
      '   Piatti(NumPiatti).FlatStyle = FlatStyle.Popup
      '   Piatti(NumPiatti).BackColor = colore
      '   Piatti(NumPiatti).ForeColor = Color.Black
      '   Piatti(NumPiatti).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
      '   Piatti(NumPiatti).TextAlign = ContentAlignment.BottomCenter
      '   Piatti(NumPiatti).Text = nome
      '   Piatti(NumPiatti).Tag = categoria
      '   Piatti(NumPiatti).ImageAlign = ContentAlignment.TopCenter

      '   If File.Exists(icona) = True Then
      '      Dim bmp As New Bitmap(icona)
      '      Piatti(NumPiatti).Image = bmp
      '   End If

      '   'If note = "" Then
      '   '   ToolTip1.SetToolTip(Categorie(NumCategorie), "Nessuna nota.")
      '   'Else
      '   '   ToolTip1.SetToolTip(Categorie(NumCategorie), note)
      '   'End If

      '   pnlPiatti.Controls.Add(Piatti(NumPiatti))

      '   AddHandler Piatti(NumPiatti).Click, AddressOf Piatti_Click
      '   'AddHandler Piatti(NumPiatti).DoubleClick, AddressOf Piatti_DoubleClick
      '   'AddHandler Piatti(NumPiatti).GotFocus, AddressOf Piatti_GotFocus

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub DisegnaPiatto(ByVal numero As String, ByVal nome As String, ByVal categoria As String, ByVal coloreSfondo As Color, ByVal coloreTesto As Color, ByVal icona As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumPiatti += 1

         Piatti(NumPiatti) = New NetButton
         Piatti(NumPiatti).Name = numero
         Piatti(NumPiatti).Location = New Point(x, y)
         Piatti(NumPiatti).Size = New Size(LARGHEZZA_PIATTO, ALTEZZA_PIATTO)
         Piatti(NumPiatti).CornerRadius = 0
         Piatti(NumPiatti).ColorBottom = coloreSfondo
         Piatti(NumPiatti).ColorText = coloreTesto
         Piatti(NumPiatti).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Piatti(NumPiatti).TextButtonAlign = ContentAlignment.MiddleCenter
         Piatti(NumPiatti).TextButton = nome
         Piatti(NumPiatti).ImageAlign = ContentAlignment.TopCenter
         Piatti(NumPiatti).Tag = categoria

         If File.Exists(icona) = True Then
            Dim bmp As New Bitmap(icona)
            Piatti(NumPiatti).Image = bmp
            Piatti(NumPiatti).TextButtonAlign = ContentAlignment.BottomCenter
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

   Private Sub DisegnaVariazione0(ByVal numero As String, ByVal nome As String, ByVal componenti As String, ByVal colore As Color, ByVal x As Integer, ByVal y As Integer)
      'Try
      '   NumVariazioni += 1

      '   Variazioni(NumVariazioni) = New Button
      '   Variazioni(NumVariazioni).Name = numero
      '   Variazioni(NumVariazioni).Location = New Point(x, y)
      '   Variazioni(NumVariazioni).Size = New Size(LARGHEZZA_VARIAZIONE, ALTEZZA_VARIAZIONE)
      '   Variazioni(NumVariazioni).FlatStyle = FlatStyle.Popup
      '   Variazioni(NumVariazioni).BackColor = colore
      '   Variazioni(NumVariazioni).ForeColor = Color.Black
      '   Variazioni(NumVariazioni).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
      '   Variazioni(NumVariazioni).TextAlign = ContentAlignment.MiddleCenter
      '   Variazioni(NumVariazioni).Text = nome
      '   Variazioni(NumVariazioni).Tag = componenti

      '   'If note = "" Then
      '   '   ToolTip1.SetToolTip(Categorie(NumCategorie), "Nessuna nota.")
      '   'Else
      '   '   ToolTip1.SetToolTip(Categorie(NumCategorie), note)
      '   'End If

      '   pnlVariazioni.Controls.Add(Variazioni(NumVariazioni))

      '   AddHandler Variazioni(NumVariazioni).Click, AddressOf Variazioni_Click
      '   'AddHandler Variazioni(NumVariazioni).DoubleClick, AddressOf Variazioni_DoubleClick
      '   'AddHandler Variazioni(NumVariazioni).GotFocus, AddressOf Variazioni_GotFocus

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub
   Private Sub DisegnaVariazione(ByVal numero As String, ByVal nome As String, ByVal componenti As String, ByVal altezza As Integer, ByVal coloreSfondo As Color, ByVal coloreTesto As Color, ByVal icona As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumVariazioni += 1

         Variazioni(NumVariazioni) = New NetButton
         Variazioni(NumVariazioni).Name = numero
         Variazioni(NumVariazioni).Location = New Point(x, y)
         Variazioni(NumVariazioni).Size = New Size(LARGHEZZA_VARIAZIONE, altezza)
         Variazioni(NumVariazioni).CornerRadius = 2
         Variazioni(NumVariazioni).ColorBottom = coloreSfondo
         Variazioni(NumVariazioni).ColorText = coloreTesto
         Variazioni(NumVariazioni).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Variazioni(NumVariazioni).TextButtonAlign = ContentAlignment.MiddleCenter
         Variazioni(NumVariazioni).TextButton = nome
         Variazioni(NumVariazioni).ImageAlign = ContentAlignment.TopCenter
         Variazioni(NumVariazioni).Tag = componenti

         If File.Exists(icona) = True Then
            Dim bmp As New Bitmap(icona)
            Variazioni(NumVariazioni).Image = bmp
            Variazioni(NumVariazioni).TextButtonAlign = ContentAlignment.BottomCenter
         End If

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
            MessageBox.Show("Codice di sistema o Codice a barre inesistente!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         eui_txtCodice.Text = String.Empty

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

   Private Sub DigitaNumeri(ByVal ctrl As Control, ByVal net_Btn As NetButton)
      Try
         If ctrl Is Nothing = False Then
            ctrl.Text = ctrl.Text & net_Btn.TextButton
            ctrl.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub TrovaCodice(ByVal txt As Elegant.Ui.TextBox)
      Try
         If txt.Text <> String.Empty Then
            SelezionaPiatto(txt.Text)
            eui_txtCodice.Focus()
         Else
            MessageBox.Show("Inserire un codice per la ricerca! Un Codice di sistema o un Codice a barre.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Categorie_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         pnlPiatti.Controls.Clear()
         NumPiatti = 0

         LeggiDatiPiatti(TAB_PIATTI, CType(sender, NetButton).TextButton)

         pnlVariazioni.Controls.Clear()
         NumVariazioni = 0

         LeggiDatiVariazioni(TAB_PIATTI, CType(sender, NetButton).TextButton)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Piatti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      If VerificaEsistenzaPiatto(CType(sender, NetButton).Name) = False Then
         SelezionaPiatto(CType(sender, NetButton).Name)
      End If
   End Sub

   Private Sub Variazioni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      SelezionaPiatto(CType(sender, NetButton).Name)
   End Sub

   Private Sub frmVCEsauriti_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         If AbilitaPalmareWindows = True Then
            g_frmVCTavoli.Timer3.Enabled = False
         End If

         If AbilitaPalmareAndroid = True Then
            g_frmVCTavoli.Timer3.Enabled = False
         End If

         Dim APiatti As New Piatti
         NUMERO_PIATTI_RIGA = APiatti.LeggiUltimoRecord("NumTastiRiga", TAB_PIATTI)
         LARGHEZZA_PIATTO = APiatti.LeggiUltimoRecord("LarghezzaTasto", TAB_PIATTI)
         ALTEZZA_PIATTO = APiatti.LeggiUltimoRecord("AltezzaTasto", TAB_PIATTI)

         If LARGHEZZA_PIATTO = 0 Then
            LARGHEZZA_PIATTO = CalcolaLarghezzaPiatto()
         End If

         LeggiDatiCategorie(TAB_CATEGORIE)

         LeggiDatiPiatti(TAB_PIATTI, CategoriaIniziale)

         LeggiDatiVariazioni(TAB_PIATTI, CategoriaIniziale)

         ApriPiattiEsauriti()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_PIATTI_ESAURITI, MODULO_PIATTI_ESAURITI)

         eui_txtCodice.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmVCEsauriti_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         If confermaModifiche = False Then
            Dim risposta As Integer
            risposta = MessageBox.Show("Si desidera confermare eventuali modifiche?",
                                       NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If risposta = DialogResult.Yes Then
               SalvaPiattiEsauriti()
            End If
         End If

         If AbilitaPalmareWindows = True Then
            g_frmVCTavoli.Timer3.Enabled = True
         End If

         If AbilitaPalmareAndroid = True Then
            g_frmVCTavoli.Timer3.Enabled = True
         End If

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_PIATTI_ESAURITI, MODULO_PIATTI_ESAURITI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
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

   Private Sub frmVCEsauriti_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      Try
         If Me.Width <= 950 Then
            Me.Width = 950
         End If

         If Me.Height <= 495 Then
            Me.Height = 495
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_CategoriaGiù_Click(sender As Object, e As EventArgs) Handles netBtn_CategoriaGiù.Click
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

   Private Sub netBtn_CategoriaSu_Click(sender As Object, e As EventArgs) Handles netBtn_CategoriaSu.Click
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

   Private Sub netBtn_PiattiGiù_Click(sender As Object, e As EventArgs) Handles netBtn_PiattiGiù.Click
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

   Private Sub netBtn_PiattiSu_Click(sender As Object, e As EventArgs) Handles netBtn_PiattiSu.Click
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

   Private Sub netBtn_VarianteGiù_Click(sender As Object, e As EventArgs) Handles netBtn_VarianteGiù.Click
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

   Private Sub netBtn_VarianteSu_Click(sender As Object, e As EventArgs) Handles netBtn_VarianteSu.Click
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

   Private Sub netBtn_ListaPiattiGiù_Click(sender As Object, e As EventArgs) Handles netBtn_ListaPiattiGiù.Click
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

   Private Sub netBtn_ListaPiattiSu_Click(sender As Object, e As EventArgs) Handles netBtn_ListaPiattiSu.Click
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

   Private Sub netBtn_Rimuovi_Click(sender As Object, e As EventArgs) Handles netBtn_Rimuovi.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      CancellaElemento()
   End Sub

   Private Sub netBtn_Conferma_Click(sender As Object, e As EventArgs) Handles netBtn_Conferma.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         confermaModifiche = True

         SalvaPiattiEsauriti()

         g_frmMain.CreaFileStatoTavoli(AbilitaPalmareWindows, AbilitaPalmareAndroid)

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub netBtn_Esci_Click(sender As Object, e As EventArgs) Handles netBtn_Esci.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub netBtn_Tastiera_Click(sender As Object, e As EventArgs) Handles netBtn_Tastiera.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Apre la Tastiera virtuale di Windows (XP, 7, 8, 10).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

   Private Sub netBtn_1_Click(sender As Object, e As EventArgs) Handles netBtn_1.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtCodice, sender)
   End Sub

   Private Sub netBtn_2_Click(sender As Object, e As EventArgs) Handles netBtn_2.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtCodice, sender)
   End Sub

   Private Sub netBtn_3_Click(sender As Object, e As EventArgs) Handles netBtn_3.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtCodice, sender)
   End Sub

   Private Sub netBtn_4_Click(sender As Object, e As EventArgs) Handles netBtn_4.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtCodice, sender)
   End Sub

   Private Sub netBtn_5_Click(sender As Object, e As EventArgs) Handles netBtn_5.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtCodice, sender)
   End Sub

   Private Sub netBtn_6_Click(sender As Object, e As EventArgs) Handles netBtn_6.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtCodice, sender)
   End Sub

   Private Sub netBtn_7_Click(sender As Object, e As EventArgs) Handles netBtn_7.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtCodice, sender)
   End Sub

   Private Sub netBtn_8_Click(sender As Object, e As EventArgs) Handles netBtn_8.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtCodice, sender)
   End Sub

   Private Sub netBtn_9_Click(sender As Object, e As EventArgs) Handles netBtn_9.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtCodice, sender)
   End Sub

   Private Sub netBtn_0_Click(sender As Object, e As EventArgs) Handles netBtn_0.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(eui_txtCodice, sender)
   End Sub

   Private Sub netBtn_C_Click(sender As Object, e As EventArgs) Handles netBtn_C.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         eui_txtCodice.Text = String.Empty
         eui_txtCodice.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub netBtn_Ok_Click(sender As Object, e As EventArgs) Handles netBtn_Ok.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      TrovaCodice(eui_txtCodice)
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      TrovaCodice(eui_txtCodice)
   End Sub


End Class
