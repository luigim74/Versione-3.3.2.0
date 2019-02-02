' Nome form:            POS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/04/2006
' Data ultima modifica: 24/04/2006
' Descrizione:          Interfaccia Punto cassa - conto immediato

Imports System.IO
Imports System.Data.OleDb

Public Class DivisioneContoPOS
   Inherits System.Windows.Forms.Form

   Const LARGHEZZA_CONTO As Short = 138
   Const ALTEZZA_CONTO As Short = 70
   Const LARGHEZZA_PIATTO As Short = 104
   Const ALTEZZA_PIATTO As Short = 70
   Const LARGHEZZA_COPERTO As Short = 138
   Const ALTEZZA_COPERTO As Short = 40

   Const ALTEZZA_RIGA_DETTAGLI As Short = 22

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
   Public Conti() As Button
   Public DatiConto() As Conto
   Public IndiceDatiConto As Integer
   Public NumConti As Integer = 0
   Public Coperti() As Button
   Public NumCoperti As Integer = 0
   Public Piatti() As Button
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
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Friend WithEvents cmdCopertiSu As System.Windows.Forms.Button
   Friend WithEvents cmdCopertiGiù As System.Windows.Forms.Button
   Friend WithEvents pnlCoperti As System.Windows.Forms.Panel
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
   Friend WithEvents cmdCategorieGiù As System.Windows.Forms.Button
   Friend WithEvents cmdCategorieSu As System.Windows.Forms.Button
   Friend WithEvents cmdPiattiGiù As System.Windows.Forms.Button
   Friend WithEvents cmdPiattiSu As System.Windows.Forms.Button
   Friend WithEvents cmdDettagliSu As System.Windows.Forms.Button
   Friend WithEvents cmdDettagliGiù As System.Windows.Forms.Button
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmdRimuovi As System.Windows.Forms.Button
   Friend WithEvents cmdConferma As System.Windows.Forms.Button
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(DivisioneContoPOS))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.cmdCategorieGiù = New System.Windows.Forms.Button()
      Me.cmdCategorieSu = New System.Windows.Forms.Button()
      Me.cmdPiattiGiù = New System.Windows.Forms.Button()
      Me.cmdPiattiSu = New System.Windows.Forms.Button()
      Me.cmdDettagliSu = New System.Windows.Forms.Button()
      Me.cmdDettagliGiù = New System.Windows.Forms.Button()
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
      Me.cmdRimuovi = New System.Windows.Forms.Button()
      Me.cmdConferma = New System.Windows.Forms.Button()
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
      Me.Label10 = New System.Windows.Forms.Label()
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmdCopertiSu = New System.Windows.Forms.Button()
      Me.cmdCopertiGiù = New System.Windows.Forms.Button()
      Me.pnlCoperti = New System.Windows.Forms.Panel()
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
      Me.cmdCategorieGiù.Location = New System.Drawing.Point(8, 544)
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
      Me.cmdCategorieSu.Location = New System.Drawing.Point(80, 544)
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
      Me.cmdPiattiGiù.Location = New System.Drawing.Point(152, 544)
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
      Me.cmdPiattiSu.Location = New System.Drawing.Point(312, 544)
      Me.cmdPiattiSu.Name = "cmdPiattiSu"
      Me.cmdPiattiSu.Size = New System.Drawing.Size(154, 40)
      Me.cmdPiattiSu.TabIndex = 5
      Me.cmdPiattiSu.UseVisualStyleBackColor = False
      '
      'cmdDettagliSu
      '
      Me.cmdDettagliSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliSu.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliSu.Image = CType(resources.GetObject("cmdDettagliSu.Image"), System.Drawing.Image)
      Me.cmdDettagliSu.Location = New System.Drawing.Point(865, 446)
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
      Me.cmdDettagliGiù.Location = New System.Drawing.Point(705, 446)
      Me.cmdDettagliGiù.Name = "cmdDettagliGiù"
      Me.cmdDettagliGiù.Size = New System.Drawing.Size(152, 40)
      Me.cmdDettagliGiù.TabIndex = 26
      Me.cmdDettagliGiù.UseVisualStyleBackColor = False
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
      Me.pnlPiatti.Size = New System.Drawing.Size(314, 528)
      Me.pnlPiatti.TabIndex = 3
      '
      'cmdRimuovi
      '
      Me.cmdRimuovi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdRimuovi.BackColor = System.Drawing.Color.DimGray
      Me.cmdRimuovi.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdRimuovi.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdRimuovi.ForeColor = System.Drawing.Color.White
      Me.cmdRimuovi.Location = New System.Drawing.Point(705, 494)
      Me.cmdRimuovi.Name = "cmdRimuovi"
      Me.cmdRimuovi.Size = New System.Drawing.Size(152, 40)
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
      Me.cmdConferma.Location = New System.Drawing.Point(705, 542)
      Me.cmdConferma.Name = "cmdConferma"
      Me.cmdConferma.Size = New System.Drawing.Size(313, 40)
      Me.cmdConferma.TabIndex = 36
      Me.cmdConferma.Text = "&CONFERMA"
      Me.cmdConferma.UseVisualStyleBackColor = False
      '
      'pnlConti
      '
      Me.pnlConti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlConti.Location = New System.Drawing.Point(8, 8)
      Me.pnlConti.Name = "pnlConti"
      Me.pnlConti.Size = New System.Drawing.Size(138, 528)
      Me.pnlConti.TabIndex = 0
      '
      'dtpData
      '
      Me.dtpData.Anchor = System.Windows.Forms.AnchorStyles.Bottom
      Me.dtpData.Location = New System.Drawing.Point(-152, 898)
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
      Me.Label2.Location = New System.Drawing.Point(705, 48)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(312, 112)
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
      Me.lblData.Location = New System.Drawing.Point(729, 106)
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
      Me.lblTotale.Location = New System.Drawing.Point(793, 48)
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
      Me.Label4.Location = New System.Drawing.Point(729, 128)
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
      Me.lblQuantità.Location = New System.Drawing.Point(961, 128)
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
      Me.lblOra.Location = New System.Drawing.Point(769, 128)
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
      Me.Label6.Location = New System.Drawing.Point(729, 48)
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
      Me.lblConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblConto.ForeColor = System.Drawing.Color.Black
      Me.lblConto.Location = New System.Drawing.Point(705, 8)
      Me.lblConto.Name = "lblConto"
      Me.lblConto.Size = New System.Drawing.Size(142, 31)
      Me.lblConto.TabIndex = 94
      Me.lblConto.Text = "CONTO 1"
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
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagli.Location = New System.Drawing.Point(705, 199)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(312, 240)
      Me.lstvDettagli.TabIndex = 227
      Me.lstvDettagli.UseCompatibleStateImageBehavior = False
      Me.lstvDettagli.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Width = 0
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader3.Width = 33
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Width = 190
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader6.Width = 70
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
      'Label10
      '
      Me.Label10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label10.BackColor = System.Drawing.Color.White
      Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(705, 160)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(312, 40)
      Me.Label10.TabIndex = 228
      Me.Label10.Text = "Q.tà   Descrizione                               Totale"
      Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAnnulla.BackColor = System.Drawing.Color.LightCoral
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAnnulla.ForeColor = System.Drawing.Color.White
      Me.cmdAnnulla.Location = New System.Drawing.Point(866, 494)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(152, 40)
      Me.cmdAnnulla.TabIndex = 229
      Me.cmdAnnulla.Text = "&ANNULLA"
      Me.cmdAnnulla.UseVisualStyleBackColor = False
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label7.Location = New System.Drawing.Point(866, 128)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(88, 24)
      Me.Label7.TabIndex = 230
      Me.Label7.Text = " Quantità:"
      Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'cmdCopertiSu
      '
      Me.cmdCopertiSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdCopertiSu.BackColor = System.Drawing.Color.Silver
      Me.cmdCopertiSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCopertiSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCopertiSu.Image = CType(resources.GetObject("cmdCopertiSu.Image"), System.Drawing.Image)
      Me.cmdCopertiSu.Location = New System.Drawing.Point(544, 544)
      Me.cmdCopertiSu.Name = "cmdCopertiSu"
      Me.cmdCopertiSu.Size = New System.Drawing.Size(64, 40)
      Me.cmdCopertiSu.TabIndex = 233
      Me.cmdCopertiSu.UseVisualStyleBackColor = False
      '
      'cmdCopertiGiù
      '
      Me.cmdCopertiGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdCopertiGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdCopertiGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCopertiGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCopertiGiù.Image = CType(resources.GetObject("cmdCopertiGiù.Image"), System.Drawing.Image)
      Me.cmdCopertiGiù.Location = New System.Drawing.Point(472, 544)
      Me.cmdCopertiGiù.Name = "cmdCopertiGiù"
      Me.cmdCopertiGiù.Size = New System.Drawing.Size(64, 40)
      Me.cmdCopertiGiù.TabIndex = 232
      Me.cmdCopertiGiù.UseVisualStyleBackColor = False
      '
      'pnlCoperti
      '
      Me.pnlCoperti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlCoperti.Location = New System.Drawing.Point(472, 8)
      Me.pnlCoperti.Name = "pnlCoperti"
      Me.pnlCoperti.Size = New System.Drawing.Size(138, 528)
      Me.pnlCoperti.TabIndex = 231
      '
      'DivisioneContoPOS
      '
      Me.AcceptButton = Me.cmdConferma
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(1025, 612)
      Me.Controls.Add(Me.cmdCopertiSu)
      Me.Controls.Add(Me.cmdCopertiGiù)
      Me.Controls.Add(Me.pnlCoperti)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.Label10)
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
      Me.Controls.Add(Me.cmdConferma)
      Me.Controls.Add(Me.cmdRimuovi)
      Me.Controls.Add(Me.cmdDettagliSu)
      Me.Controls.Add(Me.cmdDettagliGiù)
      Me.Controls.Add(Me.cmdPiattiSu)
      Me.Controls.Add(Me.cmdPiattiGiù)
      Me.Controls.Add(Me.cmdCategorieSu)
      Me.Controls.Add(Me.cmdCategorieGiù)
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

   Private Function LeggiQuantitàTotalePiatti() As Integer
      Try
         Dim qtàTotale As Integer

         Dim y As Integer
         For y = 0 To g_frmPos.lstvDettagli.Items.Count - 1
            qtàTotale = qtàTotale + Convert.ToInt32(g_frmPos.lstvDettagli.Items(y).SubItems(1).Text)
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
            DisegnaConto(i.ToString, "CONTO " & i.ToString, "", 0, CordY)
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
            DisegnaCoperto(i.ToString, "COPERTO", CopertoRistorante, 0, CordY) '  & i.ToString
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
               DatiConto(i).NomeConto = ""

               ' Quantità.
               DatiConto(i).Quantità = ""

               ' Descrizione.
               DatiConto(i).Descrizione = ""

               ' Importo.
               DatiConto(i).Importo = ""

               ' Prezzo.
               DatiConto(i).Prezzo = ""

               ' Id Piatto.
               DatiConto(i).IdPiatto = ""

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
         Dim colore As Color

         ' Rimuove eventuali coperti selezionati.
         Dim y As Integer
         For y = 1 To NumCoperti
            colore = Coperti(y).BackColor
            If colore.Equals(Color.DodgerBlue) = True Then
               Return False
            End If
         Next

         ' Rimuove il piatto selezionato.
         Dim i As Integer
         For i = 1 To NumPiatti
            colore = Piatti(i).BackColor
            If colore.Equals(Color.LightCoral) = True Then
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
               If DatiConto(i).NomeConto = Conti(y).Text Then
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

   Public Function LeggiDatiPiatto(ByVal piatto As Button) As Boolean
      Try
         Const QTA As String = "1"

         Dim i As Integer
         For i = 1 To qtàPiatti
            If DatiConto(i).NomeConto = "" Then

               ' Indice
               lstvDettagli.Items.Add(lstvDettagli.Items.Count)
               ' Struttura contenente i dati del conto.
               DatiConto(i).NomeConto = lblConto.Text

               ' Quantità
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(QTA)
               ' Struttura contenente i dati del conto.
               DatiConto(i).Quantità = QTA

               ' Descrizione.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(piatto.Text)
               ' Struttura contenente i dati del conto.
               DatiConto(i).Descrizione = piatto.Text

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
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")

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
            qtàTotale = Convert.ToInt32(g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(1).Text)

            If qtàTotale > 1 Then

               Dim j As Integer
               For j = 1 To qtàTotale
                  i += 1
                  DisegnaPiatto(g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(5).Text, g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(2).Text, g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(4).Text, CordX, CordY)

                  CordX = CordX + LARGHEZZA_PIATTO + 1

                  If i = 3 Then
                     CordY = CordY + ALTEZZA_PIATTO + 1
                     CordX = 0
                     i = 0
                  End If
               Next

            Else
               i += 1
               DisegnaPiatto(g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(5).Text, g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(2).Text, g_frmContoPos.lstvDettagliCopia.Items(y).SubItems(4).Text, CordX, CordY)

               CordX = CordX + LARGHEZZA_PIATTO + 1

               If i = 3 Then
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

         Conti(NumConti) = New Button
         Conti(NumConti).Name = numero
         Conti(NumConti).Location = New Point(x, y)
         Conti(NumConti).Size = New Size(LARGHEZZA_CONTO, ALTEZZA_CONTO)
         Conti(NumConti).FlatStyle = FlatStyle.Popup
         Conti(NumConti).BackColor = Color.MediumSeaGreen
         Conti(NumConti).ForeColor = Color.White
         Conti(NumConti).Font = New Font(FontFamily.GenericSansSerif, 16, FontStyle.Bold)
         Conti(NumConti).TextAlign = ContentAlignment.MiddleCenter
         Conti(NumConti).Text = nome
         Conti(NumConti).Tag = val

         pnlConti.Controls.Add(Conti(NumConti))

         AddHandler Conti(NumConti).Click, AddressOf Conti_Click
         'AddHandler Categorie(NumCategorie).DoubleClick, AddressOf Categorie_DoubleClick
         'AddHandler Categorie(NumCategorie).GotFocus, AddressOf Categorie_GotFocus

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaCoperto(ByVal numero As String, ByVal nome As String, ByVal prezzo As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumCoperti += 1

         Coperti(NumCoperti) = New Button
         Coperti(NumCoperti).Name = "C" & numero
         Coperti(NumCoperti).Location = New Point(x, y)
         Coperti(NumCoperti).Size = New Size(LARGHEZZA_COPERTO, ALTEZZA_COPERTO)
         Coperti(NumCoperti).FlatStyle = FlatStyle.Popup
         Coperti(NumCoperti).BackColor = Color.DodgerBlue
         Coperti(NumCoperti).ForeColor = Color.White
         Coperti(NumCoperti).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Coperti(NumCoperti).TextAlign = ContentAlignment.MiddleCenter
         Coperti(NumCoperti).Text = nome
         Coperti(NumCoperti).Tag = prezzo

         pnlCoperti.Controls.Add(Coperti(NumCoperti))

         AddHandler Coperti(NumCoperti).Click, AddressOf Coperti_Click
         'AddHandler Categorie(NumCategorie).DoubleClick, AddressOf Categorie_DoubleClick
         'AddHandler Categorie(NumCategorie).GotFocus, AddressOf Categorie_GotFocus

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaPiatto(ByVal numero As String, ByVal nome As String, ByVal prezzo As String, ByVal x As Integer, ByVal y As Integer)
      Try
         NumPiatti += 1

         Piatti(NumPiatti) = New Button
         Piatti(NumPiatti).Name = "P" & numero
         Piatti(NumPiatti).Location = New Point(x, y)
         Piatti(NumPiatti).Size = New Size(LARGHEZZA_PIATTO, ALTEZZA_PIATTO)
         Piatti(NumPiatti).FlatStyle = FlatStyle.Popup
         Piatti(NumPiatti).BackColor = Color.LightCoral
         Piatti(NumPiatti).ForeColor = Color.White
         Piatti(NumPiatti).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Piatti(NumPiatti).TextAlign = ContentAlignment.MiddleCenter
         Piatti(NumPiatti).Text = nome
         Piatti(NumPiatti).Tag = prezzo
         Piatti(NumPiatti).ImageAlign = ContentAlignment.TopCenter

         pnlPiatti.Controls.Add(Piatti(NumPiatti))

         AddHandler Piatti(NumPiatti).Click, AddressOf Piatti_Click
         'AddHandler Piatti(NumPiatti).DoubleClick, AddressOf Piatti_DoubleClick
         'AddHandler Piatti(NumPiatti).GotFocus, AddressOf Piatti_GotFocus

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CancellaElemento()
      Try
         Dim idPiatto As String
         'lstvDettagli.Focus()

         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Focus()
            idPiatto = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(5).Text

            ' Rimuove eventuali coperti selezionati.
            Dim y As Integer
            For y = 1 To NumCoperti
               If Coperti(y).Name = idPiatto Then
                  Coperti(y).BackColor = Color.DodgerBlue
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
                  Piatti(i).BackColor = Color.LightCoral
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

   Private Sub EvidenziaConto(ByVal conto As Button)
      Try
         Dim i As Integer
         For i = 1 To valNumDoc
            Conti(i).BackColor = Color.MediumSeaGreen
            Conti(i).ForeColor = Color.White
         Next

         conto.BackColor = Color.DarkGray
         conto.ForeColor = Color.Black

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SelezionaPiatto(ByVal piatto As Button)
      Try
         If LeggiDatiPiatto(piatto) = False Then
            Exit Sub
         Else
            piatto.BackColor = Color.DarkGray
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

   Private Sub SelezionaCoperto(ByVal coperto As Button)
      Try
         If LeggiDatiPiatto(coperto) = False Then
            Exit Sub
         Else
            coperto.BackColor = Color.DarkGray
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

         EvidenziaConto(sender)

         lblConto.Text = CType(sender, Button).Text.ToUpper

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

         If AbilitaPalmare = True Then
            g_frmVCTavoli.Timer3.Enabled = False
         End If

         qtàPiatti = LeggiQuantitàTotalePiatti()

         CaricaDatiConti()
         EvidenziaConto(Conti(1))

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

         If AbilitaPalmare = True Then
            g_frmVCTavoli.Timer3.Enabled = True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdCategorieSu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCategorieSu.Click
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

   Private Sub cmdCategorieGiù_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCategorieGiù.Click
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

   Private Sub lstvDettagli_Resize(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         NumElementi = (lstvDettagli.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DivisioneContoPOS_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      If Me.Width <= 936 Then
         Me.Width = 936
      End If

      If Me.Height <= 520 Then
         Me.Height = 520
      End If
   End Sub

   Private Sub cmdRimuovi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRimuovi.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      CancellaElemento()

      CalcolaTotaleConto()

      CalcolaTotaleQtà()

   End Sub

   Private Sub cmdConferma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConferma.Click
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
      Else
         MessageBox.Show("ATTENZIONE! Uno o più conti risultano vuoti. Per procedere con l'operazione tutti i conti devono essere compilati.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         DialogResult = Windows.Forms.DialogResult.None

         Exit Sub
      End If

      Me.Close()
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
         g_frmContoPos.lstvElencoDocAperti.Items.Add(i).BackColor = Color.LightSalmon

         ' Stato.
         g_frmContoPos.lstvElencoDocAperti.Items(i).SubItems.Add("Aperto")

         ' Da pagare.
         g_frmContoPos.lstvElencoDocAperti.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(CalcolaTotaleQuotaPersona(i + 1)))

         ' Nome Conto.
         g_frmContoPos.lstvElencoDocAperti.Items(i).SubItems.Add(Conti(i + 1).Text)
      Next

      g_frmContoPos.qtàPiatti = qtàPiatti

   End Sub

   Private Function CalcolaTotaleQuotaPersona(ByVal numDoc As Integer) As Double
      Try
         Dim TotRiga As Double
         Dim TotaleConto As Double

         Dim i As Integer
         For i = 1 To qtàPiatti
            If DatiConto(i).NomeConto = Conti(numDoc).Text Then

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

   Private Sub cmdAnnulla_Click(sender As System.Object, e As System.EventArgs) Handles cmdAnnulla.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub cmdCopertiGiù_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopertiGiù.Click
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

   Private Sub cmdCopertiSu_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopertiSu.Click
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
End Class
