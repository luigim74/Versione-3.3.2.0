' Nome form:            POS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/04/2006
' Data ultima modifica: 07/12/2015
' Descrizione:          Interfaccia Punto cassa - Divisione conto.

Imports System.IO
Imports System.Data.OleDb
Imports Softgroup.NetButton

Public Class DivisioneContoPOS
   Inherits System.Windows.Forms.Form

   Const TAB_PIATTI As String = "Piatti"

   Const LARGHEZZA_CONTO As Integer = 82
   Const ALTEZZA_CONTO As Integer = 50
   Public LARGHEZZA_PIATTO As Integer = 100
   Public ALTEZZA_PIATTO As Integer = 100
   Const LARGHEZZA_COPERTO As Integer = 82
   Const ALTEZZA_COPERTO As Integer = 30

   Const ALTEZZA_RIGA_DETTAGLI As Integer = 22

   Public NUMERO_PIATTI_RIGA As Integer = 10

   Public Structure Conto
      Public NomeConto As String
      Public Quantità As String
      Public Descrizione As String
      Public Importo As String
      Public Prezzo As String
      Public IdPiatto As String
   End Structure

   Public valNumDoc As Integer = 0
   Public valNumCoperti As Integer = 0
   Public Conti() As NetButton
   Public DatiConto() As Conto
   Public IndiceDatiConto As Integer
   Public NumConti As Integer = 0
   Public Coperti() As NetButton
   Public NumCoperti As Integer = 0
   Public Piatti() As NetButton
   Public NumPiatti As Integer = 0
   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0
   Public qtàPiatti As Integer

   Private CFormatta As New ClsFormatta
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents lblData As System.Windows.Forms.Label
   Friend WithEvents lblTotale As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents lblQuantità As System.Windows.Forms.Label
   Friend WithEvents lblOra As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents lblConto As System.Windows.Forms.Label
   Public WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
   Friend WithEvents pnlCoperti As System.Windows.Forms.Panel
   Friend WithEvents netBtn_ListaPiattiSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_ListaPiattiGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Tastiera As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_SottoCategoria As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_PiattiSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_PiattiGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_VarianteSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_VarianteGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_CategoriaSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_CategoriaGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Rimuovi As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Conferma As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Esci As Softgroup.NetButton.NetButton
   Friend WithEvents Label7 As System.Windows.Forms.Label

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal numDoc As Integer, ByVal numCoperti As Integer)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

      valNumDoc = numDoc
      valNumCoperti = numCoperti
      ReDim Conti(numDoc)
      ReDim Coperti(numCoperti)
      ReDim Piatti(LeggiQuantitàTotalePiatti)
      ReDim DatiConto(LeggiQuantitàTotalePiatti)
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
   Friend WithEvents pnlConti As System.Windows.Forms.Panel
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DivisioneContoPOS))
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
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.pnlConti = New System.Windows.Forms.Panel()
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.lblData = New System.Windows.Forms.Label()
      Me.lblTotale = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.lblQuantità = New System.Windows.Forms.Label()
      Me.lblOra = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.lblConto = New System.Windows.Forms.Label()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.lstvDettagli = New System.Windows.Forms.ListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Label7 = New System.Windows.Forms.Label()
      Me.pnlCoperti = New System.Windows.Forms.Panel()
      Me.netBtn_ListaPiattiSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_ListaPiattiGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_Tastiera = New Softgroup.NetButton.NetButton()
      Me.netBtn_SottoCategoria = New Softgroup.NetButton.NetButton()
      Me.netBtn_PiattiSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_PiattiGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_VarianteSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_VarianteGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_CategoriaSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_CategoriaGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_Rimuovi = New Softgroup.NetButton.NetButton()
      Me.netBtn_Conferma = New Softgroup.NetButton.NetButton()
      Me.netBtn_Esci = New Softgroup.NetButton.NetButton()
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
      Me.cmd1.Location = New System.Drawing.Point(0, 0)
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
      Me.cmd2.Location = New System.Drawing.Point(0, 71)
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
      Me.cmd5.Location = New System.Drawing.Point(0, 284)
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
      Me.pnlPiatti.Size = New System.Drawing.Size(186, 344)
      Me.pnlPiatti.TabIndex = 3
      '
      'pnlConti
      '
      Me.pnlConti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlConti.Location = New System.Drawing.Point(8, 8)
      Me.pnlConti.Name = "pnlConti"
      Me.pnlConti.Size = New System.Drawing.Size(138, 344)
      Me.pnlConti.TabIndex = 0
      '
      'dtpData
      '
      Me.dtpData.Anchor = System.Windows.Forms.AnchorStyles.Bottom
      Me.dtpData.Location = New System.Drawing.Point(-194, 723)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(200, 20)
      Me.dtpData.TabIndex = 86
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label2.Location = New System.Drawing.Point(625, -1)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(312, 151)
      Me.Label2.TabIndex = 87
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'lblData
      '
      Me.lblData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblData.AutoSize = True
      Me.lblData.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblData.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblData.Location = New System.Drawing.Point(649, 96)
      Me.lblData.Name = "lblData"
      Me.lblData.Size = New System.Drawing.Size(16, 16)
      Me.lblData.TabIndex = 89
      Me.lblData.Text = "#"
      Me.lblData.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'lblTotale
      '
      Me.lblTotale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotale.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotale.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblTotale.Location = New System.Drawing.Point(713, 38)
      Me.lblTotale.Name = "lblTotale"
      Me.lblTotale.Size = New System.Drawing.Size(216, 56)
      Me.lblTotale.TabIndex = 88
      Me.lblTotale.Text = "#"
      Me.lblTotale.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label4.Location = New System.Drawing.Point(649, 118)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(40, 24)
      Me.Label4.TabIndex = 93
      Me.Label4.Text = "Ore:"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'lblQuantità
      '
      Me.lblQuantità.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblQuantità.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblQuantità.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblQuantità.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblQuantità.Location = New System.Drawing.Point(881, 118)
      Me.lblQuantità.Name = "lblQuantità"
      Me.lblQuantità.Size = New System.Drawing.Size(40, 24)
      Me.lblQuantità.TabIndex = 92
      Me.lblQuantità.Text = "#"
      Me.lblQuantità.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'lblOra
      '
      Me.lblOra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblOra.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblOra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblOra.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblOra.Location = New System.Drawing.Point(689, 118)
      Me.lblOra.Name = "lblOra"
      Me.lblOra.Size = New System.Drawing.Size(40, 24)
      Me.lblOra.TabIndex = 90
      Me.lblOra.Text = "#"
      Me.lblOra.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label6.Location = New System.Drawing.Point(649, 38)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(32, 56)
      Me.Label6.TabIndex = 91
      Me.Label6.Text = "€"
      Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'lblConto
      '
      Me.lblConto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblConto.AutoSize = True
      Me.lblConto.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblConto.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblConto.Location = New System.Drawing.Point(646, 7)
      Me.lblConto.Name = "lblConto"
      Me.lblConto.Size = New System.Drawing.Size(144, 39)
      Me.lblConto.TabIndex = 94
      Me.lblConto.Text = "Conto 1"
      '
      'Timer1
      '
      Me.Timer1.Enabled = True
      Me.Timer1.Interval = 1000
      '
      'lstvDettagli
      '
      Me.lstvDettagli.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagli.BackColor = System.Drawing.Color.White
      Me.lstvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11})
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me.lstvDettagli.Location = New System.Drawing.Point(625, 151)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(312, 203)
      Me.lstvDettagli.TabIndex = 12
      Me.lstvDettagli.UseCompatibleStateImageBehavior = False
      Me.lstvDettagli.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Width = 0
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Q.tà"
      Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader3.Width = 40
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Text = "Descrizione"
      Me.ColumnHeader5.Width = 185
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.Text = "Totale"
      Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader6.Width = 65
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Width = 0
      '
      'ColumnHeader10
      '
      Me.ColumnHeader10.Width = 0
      '
      'ColumnHeader11
      '
      Me.ColumnHeader11.Width = 0
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label7.Location = New System.Drawing.Point(786, 118)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(88, 24)
      Me.Label7.TabIndex = 230
      Me.Label7.Text = " Quantità:"
      Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'pnlCoperti
      '
      Me.pnlCoperti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlCoperti.Location = New System.Drawing.Point(338, 8)
      Me.pnlCoperti.Name = "pnlCoperti"
      Me.pnlCoperti.Size = New System.Drawing.Size(138, 344)
      Me.pnlCoperti.TabIndex = 6
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
      Me.netBtn_ListaPiattiSu.Location = New System.Drawing.Point(782, 359)
      Me.netBtn_ListaPiattiSu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ListaPiattiSu.Name = "netBtn_ListaPiattiSu"
      Me.netBtn_ListaPiattiSu.Size = New System.Drawing.Size(155, 56)
      Me.netBtn_ListaPiattiSu.TabIndex = 14
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
      Me.netBtn_ListaPiattiGiù.Location = New System.Drawing.Point(625, 359)
      Me.netBtn_ListaPiattiGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ListaPiattiGiù.Name = "netBtn_ListaPiattiGiù"
      Me.netBtn_ListaPiattiGiù.Size = New System.Drawing.Size(155, 56)
      Me.netBtn_ListaPiattiGiù.TabIndex = 13
      Me.netBtn_ListaPiattiGiù.TextButton = ""
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
      Me.netBtn_Tastiera.Location = New System.Drawing.Point(489, 359)
      Me.netBtn_Tastiera.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Tastiera.Name = "netBtn_Tastiera"
      Me.netBtn_Tastiera.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Tastiera.TabIndex = 323
      Me.netBtn_Tastiera.TextButton = ""
      Me.netBtn_Tastiera.Visible = False
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
      Me.netBtn_SottoCategoria.Location = New System.Drawing.Point(218, 359)
      Me.netBtn_SottoCategoria.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_SottoCategoria.Name = "netBtn_SottoCategoria"
      Me.netBtn_SottoCategoria.Size = New System.Drawing.Size(48, 56)
      Me.netBtn_SottoCategoria.TabIndex = 326
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
      Me.netBtn_PiattiSu.Location = New System.Drawing.Point(267, 359)
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
      Me.netBtn_PiattiGiù.Location = New System.Drawing.Point(149, 359)
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
      Me.netBtn_VarianteSu.Location = New System.Drawing.Point(408, 359)
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
      Me.netBtn_VarianteGiù.Location = New System.Drawing.Point(338, 359)
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
      Me.netBtn_CategoriaSu.Location = New System.Drawing.Point(78, 359)
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
      Me.netBtn_CategoriaGiù.Location = New System.Drawing.Point(8, 359)
      Me.netBtn_CategoriaGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_CategoriaGiù.Name = "netBtn_CategoriaGiù"
      Me.netBtn_CategoriaGiù.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_CategoriaGiù.TabIndex = 1
      Me.netBtn_CategoriaGiù.TextButton = ""
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
      Me.netBtn_Rimuovi.Location = New System.Drawing.Point(489, 211)
      Me.netBtn_Rimuovi.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Rimuovi.Name = "netBtn_Rimuovi"
      Me.netBtn_Rimuovi.Size = New System.Drawing.Size(130, 100)
      Me.netBtn_Rimuovi.TabIndex = 11
      Me.netBtn_Rimuovi.TextButton = "Rimuovi"
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
      Me.netBtn_Conferma.Location = New System.Drawing.Point(489, 8)
      Me.netBtn_Conferma.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Conferma.Name = "netBtn_Conferma"
      Me.netBtn_Conferma.Size = New System.Drawing.Size(130, 100)
      Me.netBtn_Conferma.TabIndex = 9
      Me.netBtn_Conferma.TextButton = "Conferma"
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
      Me.netBtn_Esci.Location = New System.Drawing.Point(489, 110)
      Me.netBtn_Esci.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Esci.Name = "netBtn_Esci"
      Me.netBtn_Esci.Size = New System.Drawing.Size(130, 100)
      Me.netBtn_Esci.TabIndex = 10
      Me.netBtn_Esci.TextButton = "Esci"
      '
      'DivisioneContoPOS
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(940, 437)
      Me.Controls.Add(Me.netBtn_Rimuovi)
      Me.Controls.Add(Me.netBtn_Conferma)
      Me.Controls.Add(Me.netBtn_Esci)
      Me.Controls.Add(Me.netBtn_ListaPiattiSu)
      Me.Controls.Add(Me.netBtn_ListaPiattiGiù)
      Me.Controls.Add(Me.netBtn_Tastiera)
      Me.Controls.Add(Me.netBtn_SottoCategoria)
      Me.Controls.Add(Me.netBtn_PiattiSu)
      Me.Controls.Add(Me.netBtn_PiattiGiù)
      Me.Controls.Add(Me.netBtn_VarianteSu)
      Me.Controls.Add(Me.netBtn_VarianteGiù)
      Me.Controls.Add(Me.netBtn_CategoriaSu)
      Me.Controls.Add(Me.netBtn_CategoriaGiù)
      Me.Controls.Add(Me.pnlCoperti)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.lblConto)
      Me.Controls.Add(Me.lblData)
      Me.Controls.Add(Me.lblTotale)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.lblQuantità)
      Me.Controls.Add(Me.lblOra)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.pnlConti)
      Me.Controls.Add(Me.pnlPiatti)
      Me.ForeColor = System.Drawing.Color.White
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MinimizeBox = False
      Me.Name = "DivisioneContoPOS"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "CONTO SEPARATO MANUALE - DIVISIONE ANALITICA"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

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

   Private Function LeggiQuantitàTotalePiatti() As Integer
      Try
         Dim qtàTotale As Integer

         Dim y As Integer
         For y = 0 To g_frmPos.lstvDettagli.Items.Count - 1
            If IsNumeric(g_frmPos.lstvDettagli.Items(y).SubItems(1).Text) = True Then
               ' Piatto con quantità.
               qtàTotale = qtàTotale + Convert.ToInt32(g_frmPos.lstvDettagli.Items(y).SubItems(1).Text)
            Else
               ' Variazione senza quantità.
               qtàTotale = qtàTotale + 1
            End If
         Next

         Return qtàTotale + valNumCoperti

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      End Try
   End Function

   Public Sub CaricaDatiConti()
      Try
         Dim CordY As Integer = 0

         Dim i As Integer
         For i = 1 To valNumDoc
            DisegnaConto(i.ToString, "Conto " & i.ToString, String.Empty, 0, CordY)
            CordY = CordY + ALTEZZA_CONTO + 1
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub CaricaDatiCoperto()
      Try
         Dim CordY As Integer = 0

         Dim i As Integer
         For i = 1 To valNumCoperti
            DisegnaCoperto(i.ToString, "Coperto", CopertoRistorante, 0, CordY) '  & i.ToString
            CordY = CordY + ALTEZZA_COPERTO + 1
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub LeggiDatiConto(ByVal nomeConto As String)
      Try
         Const QTA As String = "1"

         lstvDettagli.Items.Clear()

         Dim i As Integer
         For i = 1 To qtàPiatti
            If DatiConto(i).NomeConto = nomeConto Then

               ' Indice
               lstvDettagli.Items.Add(lstvDettagli.Items.Count)

               ' Quantità
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(QTA)

               ' Descrizione.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(DatiConto(i).Descrizione)

               ' Importo.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(DatiConto(i).Importo)

               ' Prezzo.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(DatiConto(i).Prezzo)

               ' Id Piatto.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(DatiConto(i).IdPiatto)

               ' Categoria.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")

            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub RimuoviDatiConto(ByVal idPiatto As String)
      Try

         Dim i As Integer
         For i = 1 To qtàPiatti
            If DatiConto(i).IdPiatto = idPiatto Then

               ' Nome conto.
               DatiConto(i).NomeConto = String.Empty

               ' Quantità.
               DatiConto(i).Quantità = String.Empty

               ' Descrizione.
               DatiConto(i).Descrizione = String.Empty

               ' Importo.
               DatiConto(i).Importo = String.Empty

               ' Prezzo.
               DatiConto(i).Prezzo = String.Empty

               ' Id Piatto.
               DatiConto(i).IdPiatto = String.Empty

               IndiceDatiConto -= 1

               Exit For
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function VerificaPiattiCopertiSelezionati() As Boolean
      Try
         'Dim colore As NetButton.ColorStyleEnum

         ' Rimuove eventuali coperti selezionati.
         Dim y As Integer
         For y = 1 To NumCoperti
            'colore = Coperti(y).ColorStyle
            If Coperti(y).ColorStyle = NetButton.ColorStyleEnum.Default Then
               Return False
            End If
         Next

         ' Rimuove il piatto selezionato.
         Dim i As Integer
         For i = 1 To NumPiatti
            'colore = Piatti(i).BackColor
            If Piatti(i).ColorStyle = NetButton.ColorStyleEnum.Default Then
               Return False
            End If
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Function VerificaEsistenzaDatiConti() As Boolean
      Try
         Dim numContiPieni As Integer

         Dim y As Integer
         For y = 1 To valNumDoc

            Dim i As Integer
            For i = 1 To qtàPiatti
               If DatiConto(i).NomeConto = Conti(y).TextButton Then
                  ' Quantità.
                  If DatiConto(i).Quantità <> String.Empty Then
                     numContiPieni += 1
                     Exit For
                  End If
               End If
            Next
         Next

         If valNumDoc = numContiPieni Then
            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Function LeggiDatiPiatto(ByVal piatto As NetButton) As Boolean
      Try
         Const QTA As String = "1"

         Dim i As Integer
         For i = 1 To qtàPiatti
            If DatiConto(i).NomeConto = String.Empty Then

               ' Indice
               lstvDettagli.Items.Add(lstvDettagli.Items.Count)
               ' Struttura contenente i dati del conto.
               DatiConto(i).NomeConto = lblConto.Text

               ' Quantità
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(QTA)
               ' Struttura contenente i dati del conto.
               DatiConto(i).Quantità = QTA

               ' Descrizione.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(piatto.TextButton)
               ' Struttura contenente i dati del conto.
               DatiConto(i).Descrizione = piatto.TextButton

               ' Importo.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(piatto.Tag)
               ' Struttura contenente i dati del conto.
               DatiConto(i).Importo = piatto.Tag

               ' Prezzo.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(piatto.Tag)
               ' Struttura contenente i dati del conto.
               DatiConto(i).Prezzo = piatto.Tag

               ' Id Piatto.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(piatto.Name)
               ' Struttura contenente i dati del conto.
               DatiConto(i).IdPiatto = piatto.Name

               ' Categoria.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

               IndiceDatiConto += 1

               Exit For
            End If
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Public Sub LeggiDatiPiatti()
      Try
         Dim CordX As Integer = 0
         Dim CordY As Integer = 0
         Dim qtàTotale As Integer
         Dim i As Integer = 0

         Dim y As Integer
         For y = 0 To g_frmContoPos.lstvDettagliCopia.Items.Count - 1
            If IsNumeric(g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(1).Text) = True Then
               ' Piatto con quantità.
               qtàTotale = Convert.ToInt32(g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(1).Text)
            Else
               ' Variazione senza quantità.
               qtàTotale = 1
            End If

            If qtàTotale > 1 Then

               Dim j As Integer
               For j = 1 To qtàTotale
                  i += 1
                  DisegnaPiatto(g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(6).Text, g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(2).Text, g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(4).Text, CordX, CordY)

                  CordX = CordX + LARGHEZZA_PIATTO + 1

                  If i = NUMERO_PIATTI_RIGA Then
                     CordY = CordY + ALTEZZA_PIATTO + 1
                     CordX = 0
                     i = 0
                  End If
               Next

            Else
               i += 1
               DisegnaPiatto(g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(6).Text, g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(2).Text, g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(4).Text, CordX, CordY)

               CordX = CordX + LARGHEZZA_PIATTO + 1

               If i = NUMERO_PIATTI_RIGA Then
                  CordY = CordY + ALTEZZA_PIATTO + 1
                  CordX = 0
                  i = 0
               End If

            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaConto(ByVal numero As String, ByVal nome As String, ByVal val As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumConti += 1

         Conti(NumConti) = New NetButton
         Conti(NumConti).Name = numero
         Conti(NumConti).Location = New Point(x, y)
         Conti(NumConti).Size = New Size(LARGHEZZA_CONTO, ALTEZZA_CONTO)
         Conti(NumConti).CornerRadius = 2
         Conti(NumConti).ColorBottom = Color.Black
         Conti(NumConti).ColorText = Color.White
         Conti(NumConti).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Conti(NumConti).TextButtonAlign = ContentAlignment.MiddleCenter
         Conti(NumConti).TextButton = nome
         Conti(NumConti).Tag = val

         pnlConti.Controls.Add(Conti(NumConti))

         AddHandler Conti(NumConti).Click, AddressOf Conti_Click

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaPiatto(ByVal numero As String, ByVal nome As String, ByVal prezzo As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumPiatti += 1

         Piatti(NumPiatti) = New NetButton
         Piatti(NumPiatti).Name = "P" & NumPiatti ' numero 
         Piatti(NumPiatti).Location = New Point(x, y)
         Piatti(NumPiatti).Size = New Size(LARGHEZZA_PIATTO, ALTEZZA_PIATTO)
         Piatti(NumPiatti).CornerRadius = 0
         Piatti(NumPiatti).ColorStyle = NetButton.ColorStyleEnum.Default
         Piatti(NumPiatti).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Piatti(NumPiatti).TextButtonAlign = ContentAlignment.MiddleCenter
         Piatti(NumPiatti).TextButton = nome
         Piatti(NumPiatti).Tag = prezzo

         pnlPiatti.Controls.Add(Piatti(NumPiatti))

         AddHandler Piatti(NumPiatti).Click, AddressOf Piatti_Click

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaCoperto(ByVal numero As String, ByVal nome As String, ByVal prezzo As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumCoperti += 1

         Coperti(NumCoperti) = New NetButton
         Coperti(NumCoperti).Name = "C" & numero
         Coperti(NumCoperti).Location = New Point(x, y)
         Coperti(NumCoperti).Size = New Size(LARGHEZZA_COPERTO, ALTEZZA_COPERTO)
         Coperti(NumCoperti).CornerRadius = 2
         Coperti(NumCoperti).ColorStyle = NetButton.ColorStyleEnum.Default
         Coperti(NumCoperti).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Coperti(NumCoperti).TextButtonAlign = ContentAlignment.MiddleCenter
         Coperti(NumCoperti).TextButton = nome
         Coperti(NumCoperti).Tag = prezzo

         pnlCoperti.Controls.Add(Coperti(NumCoperti))

         AddHandler Coperti(NumCoperti).Click, AddressOf Coperti_Click

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CancellaElemento()
      Try
         Dim idPiatto As String

         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Focus()
            idPiatto = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(5).Text

            ' Rimuove eventuali coperti selezionati.
            Dim y As Integer
            For y = 1 To NumCoperti
               If Coperti(y).Name = idPiatto Then
                  Coperti(y).ColorStyle = NetButton.ColorStyleEnum.Default
                  Coperti(y).Enabled = True

                  lstvDettagli.Focus()
                  lstvDettagli.Items.RemoveAt(lstvDettagli.FocusedItem.Index)

                  RimuoviDatiConto(idPiatto)
               End If
            Next

            ' Rimuove il piatto selezionato.
            Dim i As Integer
            For i = 1 To NumPiatti
               If Piatti(i).Name = idPiatto Then
                  Piatti(i).ColorStyle = NetButton.ColorStyleEnum.Default
                  Piatti(i).Enabled = True

                  lstvDettagli.Focus()
                  lstvDettagli.Items.RemoveAt(lstvDettagli.FocusedItem.Index)

                  RimuoviDatiConto(idPiatto)
               End If
            Next

         End If

      Catch ex As NullReferenceException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EvidenziaConto(ByVal conto As NetButton)
      'Try
      '   Dim i As Integer
      '   For i = 1 To valNumDoc
      '      Conti(i).BackColor = Color.MediumSeaGreen
      '      Conti(i).ForeColor = Color.White
      '   Next

      '   conto.BackColor = Color.DarkGray
      '   conto.ForeColor = Color.Black

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub SelezionaPiatto(ByVal piatto As NetButton)
      Try
         If LeggiDatiPiatto(piatto) = False Then
            Exit Sub
         Else
            piatto.ColorStyle = NetButton.ColorStyleEnum.Gray
            piatto.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).Focused = True
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).Selected = True
            lstvDettagli.Focus()
         End If
      End Try
   End Sub

   Private Sub SelezionaCoperto(ByVal coperto As NetButton)
      Try
         If LeggiDatiPiatto(coperto) = False Then
            Exit Sub
         Else
            coperto.ColorStyle = NetButton.ColorStyleEnum.Gray
            coperto.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).Focused = True
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).Selected = True
            lstvDettagli.Focus()
         End If
      End Try
   End Sub

   Private Sub Conti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         lblConto.Text = CType(sender, NetButton).TextButton

         LeggiDatiConto(lblConto.Text)

         CalcolaTotaleConto()
         CalcolaTotaleQtà()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Coperti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

         SelezionaCoperto(sender)

         CalcolaTotaleConto()
         CalcolaTotaleQtà()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Piatti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      SelezionaPiatto(sender)

      CalcolaTotaleConto()
      CalcolaTotaleQtà()
   End Sub

   Private Sub DivisioneContoPOS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

         qtàPiatti = LeggiQuantitàTotalePiatti()

         CaricaDatiConti()
         CaricaDatiCoperto()
         LeggiDatiPiatti()

         CalcolaTotaleConto()
         CalcolaTotaleQtà()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DivisioneContoPOS_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         If AbilitaPalmareWindows = True Then
            g_frmVCTavoli.Timer3.Enabled = True
         End If

         If AbilitaPalmareAndroid = True Then
            g_frmVCTavoli.Timer3.Enabled = True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub DivisioneContoPOS_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      Try
         If Me.Width <= 910 Then
            Me.Width = 910
         End If

         If Me.Height <= 430 Then
            Me.Height = 430
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lstvDettagli_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         NumElementi = (lstvDettagli.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CreaDocumentiAperti()
      ReDim g_frmContoPos.DatiConto(qtàPiatti)

      Dim y As Integer
      For y = 1 To qtàPiatti
         ' Nome conto.
         g_frmContoPos.DatiConto(y).NomeConto = DatiConto(y).NomeConto

         ' Quantità
         g_frmContoPos.DatiConto(y).Quantità = DatiConto(y).Quantità

         ' Descrizione.
         g_frmContoPos.DatiConto(y).Descrizione = DatiConto(y).Descrizione

         ' Importo.
         g_frmContoPos.DatiConto(y).Importo = DatiConto(y).Importo

         ' Prezzo.
         g_frmContoPos.DatiConto(y).Prezzo = DatiConto(y).Prezzo

         If DatiConto(y).IdPiatto.Chars(0) = "C" Then
            ' Id Piatto coperto.
            g_frmContoPos.DatiConto(y).IdPiatto = "C0"
         Else
            ' Id Piatto.
            g_frmContoPos.DatiConto(y).IdPiatto = DatiConto(y).IdPiatto
         End If
      Next

      g_frmContoPos.lstvElencoDocAperti.Items.Clear()

      Dim i As Integer
      For i = 0 To valNumDoc - 1
         ' Indice
         g_frmContoPos.lstvElencoDocAperti.Items.Add(i)

         ' Stato.
         g_frmContoPos.lstvElencoDocAperti.Items(i).SubItems.Add("Aperto")

         ' Da pagare.
         g_frmContoPos.lstvElencoDocAperti.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(CalcolaTotaleQuotaPersona(i + 1)))

         ' Nome Conto.
         g_frmContoPos.lstvElencoDocAperti.Items(i).SubItems.Add(Conti(i + 1).TextButton)

      Next

      g_frmContoPos.qtàPiatti = qtàPiatti

   End Sub

   Private Function CalcolaTotaleQuotaPersona(ByVal numDoc As Integer) As Double
      Try
         Dim TotRiga As Double
         Dim TotaleConto As Double

         Dim i As Integer
         For i = 1 To qtàPiatti
            If DatiConto(i).NomeConto = Conti(numDoc).TextButton Then

               If IsNumeric(DatiConto(i).Importo) = True Then
                  TotRiga = Convert.ToDouble(DatiConto(i).Importo)
                  TotaleConto = TotaleConto + TotRiga
               End If
            End If
         Next

         Return CFormatta.FormattaNumeroDouble(TotaleConto)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0
      End Try
   End Function

   Private Sub CalcolaTotaleConto()
      Try
         If lstvDettagli.Items.Count <> 0 Then
            Dim i As Integer = 0
            Dim TotRiga As Decimal
            Dim TotaleConto As Decimal

            For i = 0 To lstvDettagli.Items.Count - 1
               TotRiga = CDec(lstvDettagli.Items(i).SubItems(3).Text)
               TotaleConto = TotaleConto + TotRiga
            Next i

            lblTotale.Text = CFormatta.FormattaEuro(TotaleConto)
         Else
            lblTotale.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CalcolaTotaleQtà()
      Try
         If lstvDettagli.Items.Count <> 0 Then
            Dim i As Integer = 0
            Dim TotRiga As Decimal
            Dim TotaleQta As Decimal

            For i = 0 To lstvDettagli.Items.Count - 1
               If IsNumeric(lstvDettagli.Items(i).SubItems(1).Text) = True Then
                  TotRiga = Convert.ToDecimal(lstvDettagli.Items(i).SubItems(1).Text)
                  TotaleQta = TotaleQta + TotRiga
               End If
            Next i

            lblQuantità.Text = TotaleQta.ToString

         Else
            lblQuantità.Text = "0"
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
      Try
         ' Visualizza la data estesa sulla barra di stato.
         lblData.Text = dtpData.Text

         If DateTime.Now.Minute.ToString.Length = 1 Then
            lblOra.Text = DateTime.Now.Hour & sepOra & "0" & DateTime.Now.Minute
         Else
            lblOra.Text = DateTime.Now.Hour & sepOra & DateTime.Now.Minute
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdCopertiGiù_Click(sender As System.Object, e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlCoperti.Controls.Count = 0 Then
            Return
         End If

         If Coperti(pnlCoperti.Controls.Count).Location.Y <= pnlCoperti.Size.Height - ALTEZZA_COPERTO Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlCoperti.Controls.Count
               Coperti(i).Location = New Point(Coperti(i).Location.X, Coperti(i).Location.Y - ALTEZZA_COPERTO - 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmdCopertiSu_Click(sender As System.Object, e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlCoperti.Controls.Count = 0 Then
            Return
         End If

         If Coperti(1).Location.Y >= 0 Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlCoperti.Controls.Count
               Coperti(i).Location = New Point(Coperti(i).Location.X, Coperti(i).Location.Y + ALTEZZA_PIATTO + 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub netBtn_CategoriaGiù_Click(sender As Object, e As EventArgs) Handles netBtn_CategoriaGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlConti.Controls.Count = 0 Then
            Return
         End If

         If Conti(pnlConti.Controls.Count).Location.Y <= pnlConti.Size.Height - ALTEZZA_CONTO Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlConti.Controls.Count
               Conti(i).Location = New Point(0, Conti(i).Location.Y - ALTEZZA_CONTO - 1)
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

         If pnlConti.Controls.Count = 0 Then
            Return
         End If

         If Conti(1).Location.Y >= 0 Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlConti.Controls.Count
               Conti(i).Location = New Point(0, Conti(i).Location.Y + ALTEZZA_CONTO + 1)
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

         If pnlCoperti.Controls.Count = 0 Then
            Return
         End If

         If Coperti(pnlCoperti.Controls.Count).Location.Y <= pnlCoperti.Size.Height - ALTEZZA_COPERTO Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlCoperti.Controls.Count
               Coperti(i).Location = New Point(Coperti(i).Location.X, Coperti(i).Location.Y - ALTEZZA_COPERTO - 1)
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

         If pnlCoperti.Controls.Count = 0 Then
            Return
         End If

         If Coperti(1).Location.Y >= 0 Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlCoperti.Controls.Count
               Coperti(i).Location = New Point(Coperti(i).Location.X, Coperti(i).Location.Y + ALTEZZA_PIATTO + 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Conferma_Click(sender As Object, e As EventArgs) Handles netBtn_Conferma.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Inserire codice di verifica per tutti i conti. Non ci devono essere conti vuoti.

         If VerificaPiattiCopertiSelezionati() = False Then
            MessageBox.Show("ATTENZIONE! Uno o più piatti/coperti non sono stati selezionati. Per procedere con l'operazione tutti i piatti/coperti devono essere inseriti in un conto.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            DialogResult = Windows.Forms.DialogResult.None

            Exit Sub
         End If

         If VerificaEsistenzaDatiConti() = True Then
            CreaDocumentiAperti()

            DialogResult = Windows.Forms.DialogResult.OK
         Else
            MessageBox.Show("ATTENZIONE! Uno o più conti risultano vuoti. Per procedere con l'operazione tutti i conti devono essere compilati.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            DialogResult = Windows.Forms.DialogResult.None

            Exit Sub
         End If

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

         DialogResult = Windows.Forms.DialogResult.None

         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub netBtn_Rimuovi_Click(sender As Object, e As EventArgs) Handles netBtn_Rimuovi.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         CancellaElemento()

         CalcolaTotaleConto()

         CalcolaTotaleQtà()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
End Class
