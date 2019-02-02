' Nome form:            POS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/04/2006
' Data ultima modifica: 24/04/2006
' Descrizione:          Interfaccia Punto cassa - conto immediato

Imports System.IO
Imports System.Data.OleDb
Imports Softgroup.NetButton


Public Class frmPos
   Inherits System.Windows.Forms.Form

   Const TAB_AZIENDA As String = "Azienda"
   Const TAB_PIATTI As String = "Piatti"
   Const TAB_CATEGORIE As String = "CategoriePiatti"
   Const TAB_COMANDE As String = "Comande"
   Const TAB_STATISTICHE As String = "Statistiche"
   Const TAB_MESSAGGI As String = "Messaggi"

   Const LARGHEZZA_CATEGORIA As Short = 80 '138
   Const ALTEZZA_CATEGORIA As Short = 100 '70
   Const LARGHEZZA_PIATTO As Short = 90 ' 104
   Const ALTEZZA_PIATTO As Short = 90 ' 70
   Const LARGHEZZA_VARIAZIONE As Short = 80 ' 130
   Const ALTEZZA_VARIAZIONE As Short = 40 '40
   Const ALTEZZA_RIGA_DETTAGLI As Short = 22

   Public Categorie() As NetButton
   Public NumCategorie As Short = 0
   Public Piatti() As NetButton
   Public NumPiatti As Short = 0
   Public Variazioni() As NetButton
   Public NumVariazioni As Short = 0
   Public CategoriaIniziale As String
   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0
   Public CausaleMovMag As String = "Vendita"
   Private idTavolo As Integer
   Public nomeTavolo As String
   Private infoTitolo As String
   Private ComandeEsistenti As Boolean = False
   Private nomeTavoloDoc As String
   Private nomeCameriereDoc As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Private DatiConfig As AppConfig
   Private Stat As New Statistiche
   Private CFormatta As New ClsFormatta
   Private AArticoli As New Articoli
   Private CConvalida As New ConvalidaKeyPress

   ' Per la moltiplicazione.
   Private moltiplica As Boolean
   Private op1 As Double
   Private op2 As Double

   Public confermaModifiche As Boolean

   Dim percorsoRep As String = PERCORSO_REP_COMANDA_REPARTI
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents cmdModalità As System.Windows.Forms.Button
   Friend WithEvents cmdNum00 As System.Windows.Forms.Button
   Friend WithEvents cmdVirgola As System.Windows.Forms.Button
   Friend WithEvents cmdC As System.Windows.Forms.Button
   Friend WithEvents cmdX As System.Windows.Forms.Button
   Friend WithEvents NetButton10 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton9 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton8 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton7 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton5 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton6 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton3 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton4 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton2 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton1 As Softgroup.NetButton.NetButton
   Friend WithEvents cmdTastiera As System.Windows.Forms.Button
   Friend WithEvents NetButton26 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton27 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton28 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton29 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton25 As Softgroup.NetButton.NetButton
   Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
   Friend WithEvents NetButton24 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton23 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton22 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton21 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton20 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton19 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton18 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton17 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton16 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton15 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton14 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton13 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton12 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton11 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton30 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton31 As Softgroup.NetButton.NetButton
   Friend WithEvents NavigationBarGroupItemsContainer1 As Elegant.Ui.NavigationBarGroupItemsContainer
   Friend WithEvents NavigationBarItem1 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NavigationBarItem2 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NavigationBarItem3 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NavigationBarItem4 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NavigationBarGroupItemsContainer2 As Elegant.Ui.NavigationBarGroupItemsContainer
   Friend WithEvents NavigationBarItem5 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NetButton38 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton39 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton36 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton37 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton34 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton35 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton33 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton32 As Softgroup.NetButton.NetButton
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents NetButton41 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton42 As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton40 As Softgroup.NetButton.NetButton

   Private NumListino As Short

   Public Enum Listino As Short
      Uno = 1
      Due = 2
      Tre = 3
      Quattro = 4
   End Enum

   Public Enum Documento As Short
      Conto = 1
      Proforma = 2
      Scontrino = 3
   End Enum

   Private Enum percorsiStampa As Short
      Reparto = 0
      Stampante = 1
      Report = 2
   End Enum

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal codiceTavolo As Integer, ByVal tavolo As String, ByVal oraOcc As String, ByVal cameriere As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

      ReDim Categorie(LeggiNumRecord(TAB_CATEGORIE))
      ReDim Piatti(LeggiNumRecord(TAB_PIATTI))
      ReDim Variazioni(LeggiNumRecord(TAB_PIATTI))

      If tavolo = "" Then
         ' Conto Immediato.
         idTavolo = Nothing
         nomeTavolo = ""
         nomeTavoloDoc = "Conto Imm."
         nomeCameriereDoc = "Cassa"
         infoTitolo = "Visual POS - CONTO IMMEDIATO"

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_PUNTO_CASSA, MODULO_GESTIONE_POS)

      ElseIf tavolo = "Tavoli" Then
         ' Conto Immediato aperto dalla Gestione Tavoli.
         idTavolo = Nothing
         nomeTavolo = tavolo
         nomeTavoloDoc = "Conto Imm."
         nomeCameriereDoc = "Cassa"
         infoTitolo = "Visual POS - CONTO IMMEDIATO"

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_PUNTO_CASSA, MODULO_GESTIONE_POS)

      ElseIf tavolo = "Asporto" Then
         ' Asporto.
         idTavolo = 0
         nomeTavolo = "Asporto"
         nomeTavoloDoc = "Asporto"
         nomeCameriereDoc = "Cassa"
         infoTitolo = "Visual POS - ASPORTO"

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ApriAsporto, String.Empty, MODULO_TAVOLI)

      Else
         ' Tavolo.
         idTavolo = codiceTavolo
         nomeTavolo = tavolo
         nomeTavoloDoc = tavolo
         nomeCameriereDoc = cameriere
         infoTitolo = "Visual POS - TAVOLO: " & tavolo & "  - ORA OCCUPAZIONE: " & oraOcc & " - CAMERIERE: " & cameriere

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.ApriTavolo, "(" & tavolo & ")", MODULO_TAVOLI)

      End If
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
   Friend WithEvents cmdVariazioniMeno As System.Windows.Forms.Button
   Friend WithEvents cmdVariazioniPiù As System.Windows.Forms.Button
   Friend WithEvents cmdListino4 As System.Windows.Forms.Button
   Friend WithEvents cmdListino3 As System.Windows.Forms.Button
   Friend WithEvents cmdListino2 As System.Windows.Forms.Button
   Friend WithEvents cmdListino1 As System.Windows.Forms.Button
   Friend WithEvents cmdConto As System.Windows.Forms.Button
   Friend WithEvents cmdQuantitàMeno As System.Windows.Forms.Button
   Friend WithEvents cmdQuantitaPiù As System.Windows.Forms.Button
   Friend WithEvents cmdEscludiStampa As System.Windows.Forms.Button
   Friend WithEvents cmdCancella As System.Windows.Forms.Button
   Friend WithEvents cmdDettagliSu As System.Windows.Forms.Button
   Friend WithEvents cmdDettagliGiù As System.Windows.Forms.Button
   Friend WithEvents lblTotale As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdCancTutto As System.Windows.Forms.Button
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents lblQuantità As System.Windows.Forms.Label
   Friend WithEvents lblData As System.Windows.Forms.Label
   Friend WithEvents lblOra As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmdEsci As System.Windows.Forms.Button
   Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdConferma As System.Windows.Forms.Button
   Friend WithEvents cmdProforma As System.Windows.Forms.Button
   Friend WithEvents cmdScontrino As System.Windows.Forms.Button
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents lstMessaggi As System.Windows.Forms.ListBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPos))
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
      Me.cmdVariazioniMeno = New System.Windows.Forms.Button()
      Me.cmdVariazioniPiù = New System.Windows.Forms.Button()
      Me.cmdQuantitàMeno = New System.Windows.Forms.Button()
      Me.cmdQuantitaPiù = New System.Windows.Forms.Button()
      Me.cmdEscludiStampa = New System.Windows.Forms.Button()
      Me.cmdCancella = New System.Windows.Forms.Button()
      Me.cmdDettagliSu = New System.Windows.Forms.Button()
      Me.cmdDettagliGiù = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmdListino4 = New System.Windows.Forms.Button()
      Me.cmdListino3 = New System.Windows.Forms.Button()
      Me.cmdListino2 = New System.Windows.Forms.Button()
      Me.cmdListino1 = New System.Windows.Forms.Button()
      Me.lblTotale = New System.Windows.Forms.Label()
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
      Me.cmdEsci = New System.Windows.Forms.Button()
      Me.cmdConto = New System.Windows.Forms.Button()
      Me.pnlCategoria = New System.Windows.Forms.Panel()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.lblData = New System.Windows.Forms.Label()
      Me.lblOra = New System.Windows.Forms.Label()
      Me.lstvDettagli = New System.Windows.Forms.ListView()
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.cmdCancTutto = New System.Windows.Forms.Button()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.lblQuantità = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.cmdConferma = New System.Windows.Forms.Button()
      Me.cmdProforma = New System.Windows.Forms.Button()
      Me.cmdScontrino = New System.Windows.Forms.Button()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.lstMessaggi = New System.Windows.Forms.ListBox()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.cmdModalità = New System.Windows.Forms.Button()
      Me.cmdNum00 = New System.Windows.Forms.Button()
      Me.cmdVirgola = New System.Windows.Forms.Button()
      Me.cmdC = New System.Windows.Forms.Button()
      Me.cmdX = New System.Windows.Forms.Button()
      Me.NetButton1 = New Softgroup.NetButton.NetButton()
      Me.NetButton2 = New Softgroup.NetButton.NetButton()
      Me.NetButton3 = New Softgroup.NetButton.NetButton()
      Me.NetButton4 = New Softgroup.NetButton.NetButton()
      Me.NetButton5 = New Softgroup.NetButton.NetButton()
      Me.NetButton6 = New Softgroup.NetButton.NetButton()
      Me.NetButton7 = New Softgroup.NetButton.NetButton()
      Me.NetButton8 = New Softgroup.NetButton.NetButton()
      Me.NetButton9 = New Softgroup.NetButton.NetButton()
      Me.NetButton10 = New Softgroup.NetButton.NetButton()
      Me.cmdTastiera = New System.Windows.Forms.Button()
      Me.NetButton13 = New Softgroup.NetButton.NetButton()
      Me.NetButton14 = New Softgroup.NetButton.NetButton()
      Me.NetButton15 = New Softgroup.NetButton.NetButton()
      Me.NetButton16 = New Softgroup.NetButton.NetButton()
      Me.NetButton17 = New Softgroup.NetButton.NetButton()
      Me.NetButton18 = New Softgroup.NetButton.NetButton()
      Me.NetButton19 = New Softgroup.NetButton.NetButton()
      Me.NetButton20 = New Softgroup.NetButton.NetButton()
      Me.NetButton21 = New Softgroup.NetButton.NetButton()
      Me.NetButton22 = New Softgroup.NetButton.NetButton()
      Me.NetButton23 = New Softgroup.NetButton.NetButton()
      Me.NetButton24 = New Softgroup.NetButton.NetButton()
      Me.TextBox1 = New System.Windows.Forms.TextBox()
      Me.NetButton25 = New Softgroup.NetButton.NetButton()
      Me.NetButton26 = New Softgroup.NetButton.NetButton()
      Me.NetButton27 = New Softgroup.NetButton.NetButton()
      Me.NetButton28 = New Softgroup.NetButton.NetButton()
      Me.NetButton29 = New Softgroup.NetButton.NetButton()
      Me.NetButton11 = New Softgroup.NetButton.NetButton()
      Me.NetButton12 = New Softgroup.NetButton.NetButton()
      Me.NetButton30 = New Softgroup.NetButton.NetButton()
      Me.NetButton31 = New Softgroup.NetButton.NetButton()
      Me.NavigationBarGroupItemsContainer1 = New Elegant.Ui.NavigationBarGroupItemsContainer()
      Me.NavigationBarItem1 = New Elegant.Ui.NavigationBarItem()
      Me.NavigationBarItem2 = New Elegant.Ui.NavigationBarItem()
      Me.NavigationBarItem3 = New Elegant.Ui.NavigationBarItem()
      Me.NavigationBarItem4 = New Elegant.Ui.NavigationBarItem()
      Me.NavigationBarGroupItemsContainer2 = New Elegant.Ui.NavigationBarGroupItemsContainer()
      Me.NavigationBarItem5 = New Elegant.Ui.NavigationBarItem()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.NetButton32 = New Softgroup.NetButton.NetButton()
      Me.NetButton33 = New Softgroup.NetButton.NetButton()
      Me.NetButton34 = New Softgroup.NetButton.NetButton()
      Me.NetButton35 = New Softgroup.NetButton.NetButton()
      Me.NetButton36 = New Softgroup.NetButton.NetButton()
      Me.NetButton37 = New Softgroup.NetButton.NetButton()
      Me.NetButton38 = New Softgroup.NetButton.NetButton()
      Me.NetButton39 = New Softgroup.NetButton.NetButton()
      Me.NetButton40 = New Softgroup.NetButton.NetButton()
      Me.NetButton41 = New Softgroup.NetButton.NetButton()
      Me.NetButton42 = New Softgroup.NetButton.NetButton()
      CType(Me.NavigationBarGroupItemsContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.NavigationBarGroupItemsContainer1.SuspendLayout()
      CType(Me.NavigationBarGroupItemsContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.NavigationBarGroupItemsContainer2.SuspendLayout()
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
      Me.cmdCategorieGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdCategorieGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCategorieGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCategorieGiù.Image = CType(resources.GetObject("cmdCategorieGiù.Image"), System.Drawing.Image)
      Me.cmdCategorieGiù.Location = New System.Drawing.Point(12, 744)
      Me.cmdCategorieGiù.Name = "cmdCategorieGiù"
      Me.cmdCategorieGiù.Size = New System.Drawing.Size(64, 40)
      Me.cmdCategorieGiù.TabIndex = 1
      Me.cmdCategorieGiù.UseVisualStyleBackColor = False
      Me.cmdCategorieGiù.Visible = False
      '
      'cmdCategorieSu
      '
      Me.cmdCategorieSu.BackColor = System.Drawing.Color.Silver
      Me.cmdCategorieSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCategorieSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCategorieSu.Image = CType(resources.GetObject("cmdCategorieSu.Image"), System.Drawing.Image)
      Me.cmdCategorieSu.Location = New System.Drawing.Point(84, 744)
      Me.cmdCategorieSu.Name = "cmdCategorieSu"
      Me.cmdCategorieSu.Size = New System.Drawing.Size(64, 40)
      Me.cmdCategorieSu.TabIndex = 2
      Me.cmdCategorieSu.UseVisualStyleBackColor = False
      Me.cmdCategorieSu.Visible = False
      '
      'cmdPiattiGiù
      '
      Me.cmdPiattiGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdPiattiGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdPiattiGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPiattiGiù.Image = CType(resources.GetObject("cmdPiattiGiù.Image"), System.Drawing.Image)
      Me.cmdPiattiGiù.Location = New System.Drawing.Point(156, 744)
      Me.cmdPiattiGiù.Name = "cmdPiattiGiù"
      Me.cmdPiattiGiù.Size = New System.Drawing.Size(154, 40)
      Me.cmdPiattiGiù.TabIndex = 4
      Me.cmdPiattiGiù.UseVisualStyleBackColor = False
      Me.cmdPiattiGiù.Visible = False
      '
      'cmdPiattiSu
      '
      Me.cmdPiattiSu.BackColor = System.Drawing.Color.Silver
      Me.cmdPiattiSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdPiattiSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPiattiSu.Image = CType(resources.GetObject("cmdPiattiSu.Image"), System.Drawing.Image)
      Me.cmdPiattiSu.Location = New System.Drawing.Point(316, 744)
      Me.cmdPiattiSu.Name = "cmdPiattiSu"
      Me.cmdPiattiSu.Size = New System.Drawing.Size(154, 40)
      Me.cmdPiattiSu.TabIndex = 5
      Me.cmdPiattiSu.UseVisualStyleBackColor = False
      Me.cmdPiattiSu.Visible = False
      '
      'cmdVariazioniSu
      '
      Me.cmdVariazioniSu.BackColor = System.Drawing.Color.Silver
      Me.cmdVariazioniSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdVariazioniSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdVariazioniSu.Image = CType(resources.GetObject("cmdVariazioniSu.Image"), System.Drawing.Image)
      Me.cmdVariazioniSu.Location = New System.Drawing.Point(544, 744)
      Me.cmdVariazioniSu.Name = "cmdVariazioniSu"
      Me.cmdVariazioniSu.Size = New System.Drawing.Size(62, 40)
      Me.cmdVariazioniSu.TabIndex = 8
      Me.cmdVariazioniSu.UseVisualStyleBackColor = False
      Me.cmdVariazioniSu.Visible = False
      '
      'cmdVariazioniGiù
      '
      Me.cmdVariazioniGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdVariazioniGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdVariazioniGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdVariazioniGiù.Image = CType(resources.GetObject("cmdVariazioniGiù.Image"), System.Drawing.Image)
      Me.cmdVariazioniGiù.Location = New System.Drawing.Point(476, 744)
      Me.cmdVariazioniGiù.Name = "cmdVariazioniGiù"
      Me.cmdVariazioniGiù.Size = New System.Drawing.Size(62, 40)
      Me.cmdVariazioniGiù.TabIndex = 7
      Me.cmdVariazioniGiù.UseVisualStyleBackColor = False
      Me.cmdVariazioniGiù.Visible = False
      '
      'cmdNum1
      '
      Me.cmdNum1.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum1.ForeColor = System.Drawing.Color.White
      Me.cmdNum1.Location = New System.Drawing.Point(12, 796)
      Me.cmdNum1.Name = "cmdNum1"
      Me.cmdNum1.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum1.TabIndex = 9
      Me.cmdNum1.Text = "1"
      Me.cmdNum1.UseVisualStyleBackColor = False
      Me.cmdNum1.Visible = False
      '
      'cmdNum2
      '
      Me.cmdNum2.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum2.ForeColor = System.Drawing.Color.White
      Me.cmdNum2.Location = New System.Drawing.Point(73, 796)
      Me.cmdNum2.Name = "cmdNum2"
      Me.cmdNum2.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum2.TabIndex = 10
      Me.cmdNum2.Text = "2"
      Me.cmdNum2.UseVisualStyleBackColor = False
      Me.cmdNum2.Visible = False
      '
      'cmdNum3
      '
      Me.cmdNum3.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum3.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum3.ForeColor = System.Drawing.Color.White
      Me.cmdNum3.Location = New System.Drawing.Point(134, 796)
      Me.cmdNum3.Name = "cmdNum3"
      Me.cmdNum3.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum3.TabIndex = 11
      Me.cmdNum3.Text = "3"
      Me.cmdNum3.UseVisualStyleBackColor = False
      Me.cmdNum3.Visible = False
      '
      'cmdNum4
      '
      Me.cmdNum4.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum4.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum4.ForeColor = System.Drawing.Color.White
      Me.cmdNum4.Location = New System.Drawing.Point(195, 796)
      Me.cmdNum4.Name = "cmdNum4"
      Me.cmdNum4.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum4.TabIndex = 12
      Me.cmdNum4.Text = "4"
      Me.cmdNum4.UseVisualStyleBackColor = False
      Me.cmdNum4.Visible = False
      '
      'cmdNum5
      '
      Me.cmdNum5.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum5.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum5.ForeColor = System.Drawing.Color.White
      Me.cmdNum5.Location = New System.Drawing.Point(256, 796)
      Me.cmdNum5.Name = "cmdNum5"
      Me.cmdNum5.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum5.TabIndex = 13
      Me.cmdNum5.Text = "5"
      Me.cmdNum5.UseVisualStyleBackColor = False
      Me.cmdNum5.Visible = False
      '
      'cmdNum6
      '
      Me.cmdNum6.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum6.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum6.ForeColor = System.Drawing.Color.White
      Me.cmdNum6.Location = New System.Drawing.Point(12, 844)
      Me.cmdNum6.Name = "cmdNum6"
      Me.cmdNum6.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum6.TabIndex = 14
      Me.cmdNum6.Text = "6"
      Me.cmdNum6.UseVisualStyleBackColor = False
      Me.cmdNum6.Visible = False
      '
      'cmdNum7
      '
      Me.cmdNum7.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum7.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum7.ForeColor = System.Drawing.Color.White
      Me.cmdNum7.Location = New System.Drawing.Point(73, 844)
      Me.cmdNum7.Name = "cmdNum7"
      Me.cmdNum7.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum7.TabIndex = 15
      Me.cmdNum7.Text = "7"
      Me.cmdNum7.UseVisualStyleBackColor = False
      Me.cmdNum7.Visible = False
      '
      'cmdNum0
      '
      Me.cmdNum0.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum0.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum0.ForeColor = System.Drawing.Color.White
      Me.cmdNum0.Location = New System.Drawing.Point(256, 844)
      Me.cmdNum0.Name = "cmdNum0"
      Me.cmdNum0.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum0.TabIndex = 18
      Me.cmdNum0.Text = "0"
      Me.cmdNum0.UseVisualStyleBackColor = False
      Me.cmdNum0.Visible = False
      '
      'cmdNum9
      '
      Me.cmdNum9.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum9.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum9.ForeColor = System.Drawing.Color.White
      Me.cmdNum9.Location = New System.Drawing.Point(195, 844)
      Me.cmdNum9.Name = "cmdNum9"
      Me.cmdNum9.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum9.TabIndex = 17
      Me.cmdNum9.Text = "9"
      Me.cmdNum9.UseVisualStyleBackColor = False
      Me.cmdNum9.Visible = False
      '
      'cmdNum8
      '
      Me.cmdNum8.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum8.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum8.ForeColor = System.Drawing.Color.White
      Me.cmdNum8.Location = New System.Drawing.Point(134, 844)
      Me.cmdNum8.Name = "cmdNum8"
      Me.cmdNum8.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum8.TabIndex = 16
      Me.cmdNum8.Text = "8"
      Me.cmdNum8.UseVisualStyleBackColor = False
      Me.cmdNum8.Visible = False
      '
      'cmdOk
      '
      Me.cmdOk.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdOk.ForeColor = System.Drawing.Color.White
      Me.cmdOk.Location = New System.Drawing.Point(437, 844)
      Me.cmdOk.Name = "cmdOk"
      Me.cmdOk.Size = New System.Drawing.Size(108, 40)
      Me.cmdOk.TabIndex = 24
      Me.cmdOk.Text = "OK"
      Me.cmdOk.UseVisualStyleBackColor = False
      Me.cmdOk.Visible = False
      '
      'txtCodice
      '
      Me.txtCodice.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodice.ForeColor = System.Drawing.Color.DodgerBlue
      Me.txtCodice.Location = New System.Drawing.Point(377, 796)
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.Size = New System.Drawing.Size(168, 40)
      Me.txtCodice.TabIndex = 20
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtCodice.Visible = False
      '
      'cmdVariazioniMeno
      '
      Me.cmdVariazioniMeno.BackColor = System.Drawing.Color.LightCoral
      Me.cmdVariazioniMeno.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdVariazioniMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdVariazioniMeno.ForeColor = System.Drawing.Color.White
      Me.cmdVariazioniMeno.Location = New System.Drawing.Point(540, 887)
      Me.cmdVariazioniMeno.Name = "cmdVariazioniMeno"
      Me.cmdVariazioniMeno.Size = New System.Drawing.Size(64, 40)
      Me.cmdVariazioniMeno.TabIndex = 7
      Me.cmdVariazioniMeno.Text = "-"
      Me.cmdVariazioniMeno.UseVisualStyleBackColor = False
      Me.cmdVariazioniMeno.Visible = False
      '
      'cmdVariazioniPiù
      '
      Me.cmdVariazioniPiù.BackColor = System.Drawing.Color.LightCoral
      Me.cmdVariazioniPiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdVariazioniPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdVariazioniPiù.ForeColor = System.Drawing.Color.White
      Me.cmdVariazioniPiù.Location = New System.Drawing.Point(468, 887)
      Me.cmdVariazioniPiù.Name = "cmdVariazioniPiù"
      Me.cmdVariazioniPiù.Size = New System.Drawing.Size(64, 40)
      Me.cmdVariazioniPiù.TabIndex = 6
      Me.cmdVariazioniPiù.Text = "+"
      Me.cmdVariazioniPiù.UseVisualStyleBackColor = False
      Me.cmdVariazioniPiù.Visible = False
      '
      'cmdQuantitàMeno
      '
      Me.cmdQuantitàMeno.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdQuantitàMeno.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdQuantitàMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdQuantitàMeno.ForeColor = System.Drawing.Color.White
      Me.cmdQuantitàMeno.Location = New System.Drawing.Point(656, 704)
      Me.cmdQuantitàMeno.Name = "cmdQuantitàMeno"
      Me.cmdQuantitàMeno.Size = New System.Drawing.Size(71, 40)
      Me.cmdQuantitàMeno.TabIndex = 33
      Me.cmdQuantitàMeno.Text = "&-1"
      Me.cmdQuantitàMeno.UseVisualStyleBackColor = False
      Me.cmdQuantitàMeno.Visible = False
      '
      'cmdQuantitaPiù
      '
      Me.cmdQuantitaPiù.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdQuantitaPiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdQuantitaPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdQuantitaPiù.ForeColor = System.Drawing.Color.White
      Me.cmdQuantitaPiù.Location = New System.Drawing.Point(736, 704)
      Me.cmdQuantitaPiù.Name = "cmdQuantitaPiù"
      Me.cmdQuantitaPiù.Size = New System.Drawing.Size(71, 40)
      Me.cmdQuantitaPiù.TabIndex = 34
      Me.cmdQuantitaPiù.Text = "&+1"
      Me.cmdQuantitaPiù.UseVisualStyleBackColor = False
      Me.cmdQuantitaPiù.Visible = False
      '
      'cmdEscludiStampa
      '
      Me.cmdEscludiStampa.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdEscludiStampa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEscludiStampa.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEscludiStampa.ForeColor = System.Drawing.Color.White
      Me.cmdEscludiStampa.Location = New System.Drawing.Point(656, 752)
      Me.cmdEscludiStampa.Name = "cmdEscludiStampa"
      Me.cmdEscludiStampa.Size = New System.Drawing.Size(151, 40)
      Me.cmdEscludiStampa.TabIndex = 37
      Me.cmdEscludiStampa.Text = "E&SCLUDI"
      Me.cmdEscludiStampa.UseVisualStyleBackColor = False
      Me.cmdEscludiStampa.Visible = False
      '
      'cmdCancella
      '
      Me.cmdCancella.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdCancella.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCancella.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCancella.ForeColor = System.Drawing.Color.White
      Me.cmdCancella.Location = New System.Drawing.Point(816, 704)
      Me.cmdCancella.Name = "cmdCancella"
      Me.cmdCancella.Size = New System.Drawing.Size(71, 40)
      Me.cmdCancella.TabIndex = 35
      Me.cmdCancella.Text = "Canc"
      Me.cmdCancella.UseVisualStyleBackColor = False
      Me.cmdCancella.Visible = False
      '
      'cmdDettagliSu
      '
      Me.cmdDettagliSu.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliSu.Image = CType(resources.GetObject("cmdDettagliSu.Image"), System.Drawing.Image)
      Me.cmdDettagliSu.Location = New System.Drawing.Point(816, 656)
      Me.cmdDettagliSu.Name = "cmdDettagliSu"
      Me.cmdDettagliSu.Size = New System.Drawing.Size(151, 40)
      Me.cmdDettagliSu.TabIndex = 32
      Me.cmdDettagliSu.UseVisualStyleBackColor = False
      Me.cmdDettagliSu.Visible = False
      '
      'cmdDettagliGiù
      '
      Me.cmdDettagliGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliGiù.Image = CType(resources.GetObject("cmdDettagliGiù.Image"), System.Drawing.Image)
      Me.cmdDettagliGiù.Location = New System.Drawing.Point(656, 656)
      Me.cmdDettagliGiù.Name = "cmdDettagliGiù"
      Me.cmdDettagliGiù.Size = New System.Drawing.Size(151, 40)
      Me.cmdDettagliGiù.TabIndex = 31
      Me.cmdDettagliGiù.UseVisualStyleBackColor = False
      Me.cmdDettagliGiù.Visible = False
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(295, 699)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(128, 31)
      Me.Label1.TabIndex = 69
      Me.Label1.Text = "LISTINO"
      Me.Label1.Visible = False
      '
      'cmdListino4
      '
      Me.cmdListino4.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdListino4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdListino4.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdListino4.ForeColor = System.Drawing.Color.White
      Me.cmdListino4.Location = New System.Drawing.Point(559, 696)
      Me.cmdListino4.Name = "cmdListino4"
      Me.cmdListino4.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino4.TabIndex = 29
      Me.cmdListino4.Text = "4"
      Me.cmdListino4.UseVisualStyleBackColor = False
      Me.cmdListino4.Visible = False
      '
      'cmdListino3
      '
      Me.cmdListino3.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdListino3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdListino3.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdListino3.ForeColor = System.Drawing.Color.White
      Me.cmdListino3.Location = New System.Drawing.Point(517, 696)
      Me.cmdListino3.Name = "cmdListino3"
      Me.cmdListino3.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino3.TabIndex = 28
      Me.cmdListino3.Text = "3"
      Me.cmdListino3.UseVisualStyleBackColor = False
      Me.cmdListino3.Visible = False
      '
      'cmdListino2
      '
      Me.cmdListino2.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdListino2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdListino2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdListino2.ForeColor = System.Drawing.Color.White
      Me.cmdListino2.Location = New System.Drawing.Point(475, 696)
      Me.cmdListino2.Name = "cmdListino2"
      Me.cmdListino2.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino2.TabIndex = 27
      Me.cmdListino2.Text = "2"
      Me.cmdListino2.UseVisualStyleBackColor = False
      Me.cmdListino2.Visible = False
      '
      'cmdListino1
      '
      Me.cmdListino1.BackColor = System.Drawing.Color.LightCoral
      Me.cmdListino1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdListino1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdListino1.ForeColor = System.Drawing.Color.White
      Me.cmdListino1.Location = New System.Drawing.Point(433, 696)
      Me.cmdListino1.Name = "cmdListino1"
      Me.cmdListino1.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino1.TabIndex = 26
      Me.cmdListino1.Text = "1"
      Me.cmdListino1.UseVisualStyleBackColor = False
      Me.cmdListino1.Visible = False
      '
      'lblTotale
      '
      Me.lblTotale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotale.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotale.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblTotale.Location = New System.Drawing.Point(843, 0)
      Me.lblTotale.Name = "lblTotale"
      Me.lblTotale.Size = New System.Drawing.Size(216, 56)
      Me.lblTotale.TabIndex = 76
      Me.lblTotale.Text = "#"
      Me.lblTotale.TextAlign = System.Drawing.ContentAlignment.BottomRight
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
      Me.pnlPiatti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlPiatti.Location = New System.Drawing.Point(290, 5)
      Me.pnlPiatti.Name = "pnlPiatti"
      Me.pnlPiatti.Size = New System.Drawing.Size(160, 575)
      Me.pnlPiatti.TabIndex = 3
      '
      'pnlVariazioni
      '
      Me.pnlVariazioni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlVariazioni.Location = New System.Drawing.Point(453, 66)
      Me.pnlVariazioni.Name = "pnlVariazioni"
      Me.pnlVariazioni.Size = New System.Drawing.Size(138, 514)
      Me.pnlVariazioni.TabIndex = 6
      '
      'cmdEsci
      '
      Me.cmdEsci.BackColor = System.Drawing.Color.LightCoral
      Me.cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdEsci.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEsci.ForeColor = System.Drawing.Color.White
      Me.cmdEsci.Location = New System.Drawing.Point(816, 848)
      Me.cmdEsci.Name = "cmdEsci"
      Me.cmdEsci.Size = New System.Drawing.Size(151, 40)
      Me.cmdEsci.TabIndex = 42
      Me.cmdEsci.Text = "&ESCI"
      Me.cmdEsci.UseVisualStyleBackColor = False
      Me.cmdEsci.Visible = False
      '
      'cmdConto
      '
      Me.cmdConto.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdConto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdConto.ForeColor = System.Drawing.Color.White
      Me.cmdConto.Location = New System.Drawing.Point(656, 848)
      Me.cmdConto.Name = "cmdConto"
      Me.cmdConto.Size = New System.Drawing.Size(151, 40)
      Me.cmdConto.TabIndex = 41
      Me.cmdConto.Text = "&CONTO"
      Me.cmdConto.UseVisualStyleBackColor = False
      Me.cmdConto.Visible = False
      '
      'pnlCategoria
      '
      Me.pnlCategoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlCategoria.Location = New System.Drawing.Point(8, 5)
      Me.pnlCategoria.Name = "pnlCategoria"
      Me.pnlCategoria.Size = New System.Drawing.Size(138, 575)
      Me.pnlCategoria.TabIndex = 0
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.BackColor = System.Drawing.Color.White
      Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(737, 112)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(337, 32)
      Me.Label3.TabIndex = 78
      Me.Label3.Text = "Q.tà   Descrizione                               Totale"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblData
      '
      Me.lblData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblData.AutoSize = True
      Me.lblData.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblData.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblData.Location = New System.Drawing.Point(778, 58)
      Me.lblData.Name = "lblData"
      Me.lblData.Size = New System.Drawing.Size(16, 16)
      Me.lblData.TabIndex = 79
      Me.lblData.Text = "#"
      Me.lblData.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'lblOra
      '
      Me.lblOra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblOra.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblOra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblOra.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblOra.Location = New System.Drawing.Point(819, 80)
      Me.lblOra.Name = "lblOra"
      Me.lblOra.Size = New System.Drawing.Size(40, 24)
      Me.lblOra.TabIndex = 80
      Me.lblOra.Text = "#"
      Me.lblOra.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'lstvDettagli
      '
      Me.lstvDettagli.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagli.BackColor = System.Drawing.Color.White
      Me.lstvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10})
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagli.Location = New System.Drawing.Point(737, 136)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(337, 255)
      Me.lstvDettagli.TabIndex = 30
      Me.lstvDettagli.UseCompatibleStateImageBehavior = False
      Me.lstvDettagli.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Width = 0
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader1.Width = 33
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Width = 190
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader3.Width = 70
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.Width = 0
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.Width = 0
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Width = 0
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Width = 0
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Width = 0
      '
      'ColumnHeader10
      '
      Me.ColumnHeader10.Width = 0
      '
      'cmdCancTutto
      '
      Me.cmdCancTutto.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdCancTutto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCancTutto.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCancTutto.ForeColor = System.Drawing.Color.White
      Me.cmdCancTutto.Location = New System.Drawing.Point(896, 704)
      Me.cmdCancTutto.Name = "cmdCancTutto"
      Me.cmdCancTutto.Size = New System.Drawing.Size(71, 40)
      Me.cmdCancTutto.TabIndex = 36
      Me.cmdCancTutto.Text = "&X"
      Me.cmdCancTutto.UseVisualStyleBackColor = False
      Me.cmdCancTutto.Visible = False
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label2.Location = New System.Drawing.Point(737, 0)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(337, 112)
      Me.Label2.TabIndex = 81
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label6.Location = New System.Drawing.Point(779, 0)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(32, 56)
      Me.Label6.TabIndex = 82
      Me.Label6.Text = "€"
      Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label7.Location = New System.Drawing.Point(923, 80)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(88, 24)
      Me.Label7.TabIndex = 83
      Me.Label7.Text = " Quantità:"
      Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'lblQuantità
      '
      Me.lblQuantità.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblQuantità.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblQuantità.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblQuantità.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblQuantità.Location = New System.Drawing.Point(1011, 80)
      Me.lblQuantità.Name = "lblQuantità"
      Me.lblQuantità.Size = New System.Drawing.Size(40, 24)
      Me.lblQuantità.TabIndex = 84
      Me.lblQuantità.Text = "#"
      Me.lblQuantità.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label4.Location = New System.Drawing.Point(779, 80)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(40, 24)
      Me.Label4.TabIndex = 85
      Me.Label4.Text = "Ore:"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'Timer1
      '
      Me.Timer1.Enabled = True
      Me.Timer1.Interval = 1000
      '
      'dtpData
      '
      Me.dtpData.Anchor = System.Windows.Forms.AnchorStyles.Bottom
      Me.dtpData.Location = New System.Drawing.Point(-126, 946)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(200, 20)
      Me.dtpData.TabIndex = 86
      '
      'cmdConferma
      '
      Me.cmdConferma.BackColor = System.Drawing.Color.Gray
      Me.cmdConferma.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdConferma.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdConferma.ForeColor = System.Drawing.Color.White
      Me.cmdConferma.Location = New System.Drawing.Point(816, 752)
      Me.cmdConferma.Name = "cmdConferma"
      Me.cmdConferma.Size = New System.Drawing.Size(151, 40)
      Me.cmdConferma.TabIndex = 38
      Me.cmdConferma.Text = "C&ONFERMA"
      Me.cmdConferma.UseVisualStyleBackColor = False
      Me.cmdConferma.Visible = False
      '
      'cmdProforma
      '
      Me.cmdProforma.BackColor = System.Drawing.Color.Silver
      Me.cmdProforma.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdProforma.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdProforma.ForeColor = System.Drawing.Color.White
      Me.cmdProforma.Location = New System.Drawing.Point(656, 800)
      Me.cmdProforma.Name = "cmdProforma"
      Me.cmdProforma.Size = New System.Drawing.Size(151, 40)
      Me.cmdProforma.TabIndex = 39
      Me.cmdProforma.Text = "&PROFORMA"
      Me.cmdProforma.UseVisualStyleBackColor = False
      Me.cmdProforma.Visible = False
      '
      'cmdScontrino
      '
      Me.cmdScontrino.BackColor = System.Drawing.Color.LightSalmon
      Me.cmdScontrino.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdScontrino.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdScontrino.ForeColor = System.Drawing.Color.White
      Me.cmdScontrino.Location = New System.Drawing.Point(816, 800)
      Me.cmdScontrino.Name = "cmdScontrino"
      Me.cmdScontrino.Size = New System.Drawing.Size(151, 40)
      Me.cmdScontrino.TabIndex = 40
      Me.cmdScontrino.Text = "SCONTRINO"
      Me.cmdScontrino.UseVisualStyleBackColor = False
      Me.cmdScontrino.Visible = False
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "Comanda.rpt"
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'lstMessaggi
      '
      Me.lstMessaggi.Location = New System.Drawing.Point(8, 720)
      Me.lstMessaggi.Name = "lstMessaggi"
      Me.lstMessaggi.Size = New System.Drawing.Size(88, 17)
      Me.lstMessaggi.TabIndex = 87
      Me.lstMessaggi.Visible = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'cmdModalità
      '
      Me.cmdModalità.BackColor = System.Drawing.Color.White
      Me.cmdModalità.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdModalità.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdModalità.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdModalità.Location = New System.Drawing.Point(316, 796)
      Me.cmdModalità.Name = "cmdModalità"
      Me.cmdModalità.Size = New System.Drawing.Size(54, 40)
      Me.cmdModalità.TabIndex = 19
      Me.cmdModalità.Text = "€"
      Me.cmdModalità.UseVisualStyleBackColor = False
      Me.cmdModalità.Visible = False
      '
      'cmdNum00
      '
      Me.cmdNum00.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum00.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum00.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum00.ForeColor = System.Drawing.Color.White
      Me.cmdNum00.Location = New System.Drawing.Point(377, 844)
      Me.cmdNum00.Name = "cmdNum00"
      Me.cmdNum00.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum00.TabIndex = 23
      Me.cmdNum00.Text = "00"
      Me.cmdNum00.UseVisualStyleBackColor = False
      Me.cmdNum00.Visible = False
      '
      'cmdVirgola
      '
      Me.cmdVirgola.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdVirgola.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdVirgola.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdVirgola.ForeColor = System.Drawing.Color.White
      Me.cmdVirgola.Location = New System.Drawing.Point(316, 844)
      Me.cmdVirgola.Name = "cmdVirgola"
      Me.cmdVirgola.Size = New System.Drawing.Size(54, 40)
      Me.cmdVirgola.TabIndex = 22
      Me.cmdVirgola.Text = ","
      Me.cmdVirgola.UseVisualStyleBackColor = False
      Me.cmdVirgola.Visible = False
      '
      'cmdC
      '
      Me.cmdC.BackColor = System.Drawing.Color.LightCoral
      Me.cmdC.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdC.ForeColor = System.Drawing.Color.White
      Me.cmdC.Location = New System.Drawing.Point(552, 844)
      Me.cmdC.Name = "cmdC"
      Me.cmdC.Size = New System.Drawing.Size(54, 40)
      Me.cmdC.TabIndex = 25
      Me.cmdC.Text = "C"
      Me.cmdC.UseVisualStyleBackColor = False
      Me.cmdC.Visible = False
      '
      'cmdX
      '
      Me.cmdX.BackColor = System.Drawing.Color.LightSalmon
      Me.cmdX.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdX.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdX.ForeColor = System.Drawing.Color.White
      Me.cmdX.Location = New System.Drawing.Point(552, 796)
      Me.cmdX.Name = "cmdX"
      Me.cmdX.Size = New System.Drawing.Size(54, 40)
      Me.cmdX.TabIndex = 21
      Me.cmdX.Text = "X"
      Me.cmdX.UseVisualStyleBackColor = False
      Me.cmdX.Visible = False
      '
      'NetButton1
      '
      Me.NetButton1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton1.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.NetButton1.ColorDisabled = System.Drawing.Color.Brown
      Me.NetButton1.ColorLight = System.Drawing.Color.MistyRose
      Me.NetButton1.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Red
      Me.NetButton1.ColorText = System.Drawing.Color.Black
      Me.NetButton1.ColorTop = System.Drawing.Color.White
      Me.NetButton1.CornerRadius = 2
      Me.NetButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton1.Location = New System.Drawing.Point(605, 576)
      Me.NetButton1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton1.Name = "NetButton1"
      Me.NetButton1.Size = New System.Drawing.Size(127, 56)
      Me.NetButton1.TabIndex = 88
      Me.NetButton1.TextButton = "Esci"
      '
      'NetButton2
      '
      Me.NetButton2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton2.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(40, Byte), Integer))
      Me.NetButton2.ColorDisabled = System.Drawing.Color.SeaGreen
      Me.NetButton2.ColorLight = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(189, Byte), Integer))
      Me.NetButton2.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Green
      Me.NetButton2.ColorText = System.Drawing.Color.Black
      Me.NetButton2.ColorTop = System.Drawing.Color.White
      Me.NetButton2.CornerRadius = 2
      Me.NetButton2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton2.Location = New System.Drawing.Point(605, 518)
      Me.NetButton2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton2.Name = "NetButton2"
      Me.NetButton2.Size = New System.Drawing.Size(127, 56)
      Me.NetButton2.TabIndex = 89
      Me.NetButton2.TextButton = "Conto"
      '
      'NetButton3
      '
      Me.NetButton3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton3.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton3.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton3.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton3.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton3.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton3.CornerRadius = 2
      Me.NetButton3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton3.Location = New System.Drawing.Point(605, 404)
      Me.NetButton3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton3.Name = "NetButton3"
      Me.NetButton3.Size = New System.Drawing.Size(127, 56)
      Me.NetButton3.TabIndex = 91
      Me.NetButton3.TextButton = "Proforma"
      '
      'NetButton4
      '
      Me.NetButton4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton4.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton4.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton4.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton4.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton4.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton4.CornerRadius = 2
      Me.NetButton4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton4.Location = New System.Drawing.Point(605, 461)
      Me.NetButton4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton4.Name = "NetButton4"
      Me.NetButton4.Size = New System.Drawing.Size(127, 56)
      Me.NetButton4.TabIndex = 90
      Me.NetButton4.TextButton = "Scontrino"
      '
      'NetButton5
      '
      Me.NetButton5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton5.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton5.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton5.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton5.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton5.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton5.CornerRadius = 2
      Me.NetButton5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton5.Location = New System.Drawing.Point(605, 290)
      Me.NetButton5.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton5.Name = "NetButton5"
      Me.NetButton5.Size = New System.Drawing.Size(127, 56)
      Me.NetButton5.TabIndex = 93
      Me.NetButton5.TextButton = "Escludi"
      '
      'NetButton6
      '
      Me.NetButton6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton6.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton6.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton6.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton6.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton6.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton6.CornerRadius = 2
      Me.NetButton6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton6.Location = New System.Drawing.Point(605, 347)
      Me.NetButton6.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton6.Name = "NetButton6"
      Me.NetButton6.Size = New System.Drawing.Size(127, 56)
      Me.NetButton6.TabIndex = 92
      Me.NetButton6.TextButton = "Conferma"
      '
      'NetButton7
      '
      Me.NetButton7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton7.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton7.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton7.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton7.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton7.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton7.CornerRadius = 2
      Me.NetButton7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton7.Location = New System.Drawing.Point(605, 176)
      Me.NetButton7.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton7.Name = "NetButton7"
      Me.NetButton7.Size = New System.Drawing.Size(63, 56)
      Me.NetButton7.TabIndex = 94
      Me.NetButton7.TextButton = "-1"
      '
      'NetButton8
      '
      Me.NetButton8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton8.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton8.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton8.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton8.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton8.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton8.CornerRadius = 2
      Me.NetButton8.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton8.Location = New System.Drawing.Point(669, 176)
      Me.NetButton8.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton8.Name = "NetButton8"
      Me.NetButton8.Size = New System.Drawing.Size(63, 56)
      Me.NetButton8.TabIndex = 95
      Me.NetButton8.TextButton = "+1"
      '
      'NetButton9
      '
      Me.NetButton9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton9.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton9.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton9.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton9.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton9.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton9.CornerRadius = 2
      Me.NetButton9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton9.Location = New System.Drawing.Point(605, 233)
      Me.NetButton9.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton9.Name = "NetButton9"
      Me.NetButton9.Size = New System.Drawing.Size(63, 56)
      Me.NetButton9.TabIndex = 96
      Me.NetButton9.TextButton = "Canc."
      '
      'NetButton10
      '
      Me.NetButton10.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton10.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton10.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton10.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton10.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton10.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton10.CornerRadius = 2
      Me.NetButton10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton10.Location = New System.Drawing.Point(669, 233)
      Me.NetButton10.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton10.Name = "NetButton10"
      Me.NetButton10.Size = New System.Drawing.Size(63, 56)
      Me.NetButton10.TabIndex = 97
      Me.NetButton10.TextButton = "X"
      '
      'cmdTastiera
      '
      Me.cmdTastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdTastiera.BackColor = System.Drawing.Color.Gray
      Me.cmdTastiera.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdTastiera.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdTastiera.ForeColor = System.Drawing.Color.White
      Me.cmdTastiera.Image = CType(resources.GetObject("cmdTastiera.Image"), System.Drawing.Image)
      Me.cmdTastiera.Location = New System.Drawing.Point(328, 808)
      Me.cmdTastiera.Name = "cmdTastiera"
      Me.cmdTastiera.Size = New System.Drawing.Size(56, 40)
      Me.cmdTastiera.TabIndex = 277
      Me.cmdTastiera.UseVisualStyleBackColor = False
      Me.cmdTastiera.Visible = False
      '
      'NetButton13
      '
      Me.NetButton13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton13.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton13.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton13.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton13.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton13.ColorText = System.Drawing.Color.Black
      Me.NetButton13.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton13.CornerRadius = 2
      Me.NetButton13.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton13.Location = New System.Drawing.Point(832, 487)
      Me.NetButton13.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton13.Name = "NetButton13"
      Me.NetButton13.Size = New System.Drawing.Size(80, 51)
      Me.NetButton13.TabIndex = 278
      Me.NetButton13.TextButton = "4"
      '
      'NetButton14
      '
      Me.NetButton14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton14.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton14.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton14.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton14.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton14.ColorText = System.Drawing.Color.Black
      Me.NetButton14.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton14.CornerRadius = 2
      Me.NetButton14.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton14.Location = New System.Drawing.Point(913, 487)
      Me.NetButton14.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton14.Name = "NetButton14"
      Me.NetButton14.Size = New System.Drawing.Size(80, 51)
      Me.NetButton14.TabIndex = 279
      Me.NetButton14.TextButton = "5"
      '
      'NetButton15
      '
      Me.NetButton15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton15.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton15.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton15.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton15.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton15.ColorText = System.Drawing.Color.Black
      Me.NetButton15.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton15.CornerRadius = 2
      Me.NetButton15.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton15.Location = New System.Drawing.Point(994, 487)
      Me.NetButton15.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton15.Name = "NetButton15"
      Me.NetButton15.Size = New System.Drawing.Size(78, 51)
      Me.NetButton15.TabIndex = 280
      Me.NetButton15.TextButton = "6"
      '
      'NetButton16
      '
      Me.NetButton16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton16.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton16.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton16.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton16.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton16.ColorText = System.Drawing.Color.Black
      Me.NetButton16.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton16.CornerRadius = 2
      Me.NetButton16.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton16.Location = New System.Drawing.Point(832, 539)
      Me.NetButton16.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton16.Name = "NetButton16"
      Me.NetButton16.Size = New System.Drawing.Size(80, 51)
      Me.NetButton16.TabIndex = 281
      Me.NetButton16.TextButton = "1"
      '
      'NetButton17
      '
      Me.NetButton17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton17.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton17.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton17.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton17.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton17.ColorText = System.Drawing.Color.Black
      Me.NetButton17.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton17.CornerRadius = 2
      Me.NetButton17.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton17.Location = New System.Drawing.Point(913, 539)
      Me.NetButton17.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton17.Name = "NetButton17"
      Me.NetButton17.Size = New System.Drawing.Size(80, 51)
      Me.NetButton17.TabIndex = 282
      Me.NetButton17.TextButton = "2"
      '
      'NetButton18
      '
      Me.NetButton18.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton18.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton18.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton18.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton18.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton18.ColorText = System.Drawing.Color.Black
      Me.NetButton18.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton18.CornerRadius = 2
      Me.NetButton18.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton18.Location = New System.Drawing.Point(994, 539)
      Me.NetButton18.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton18.Name = "NetButton18"
      Me.NetButton18.Size = New System.Drawing.Size(78, 51)
      Me.NetButton18.TabIndex = 283
      Me.NetButton18.TextButton = "3"
      '
      'NetButton19
      '
      Me.NetButton19.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton19.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton19.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton19.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton19.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton19.ColorText = System.Drawing.Color.Black
      Me.NetButton19.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton19.CornerRadius = 2
      Me.NetButton19.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton19.Location = New System.Drawing.Point(832, 591)
      Me.NetButton19.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton19.Name = "NetButton19"
      Me.NetButton19.Size = New System.Drawing.Size(80, 51)
      Me.NetButton19.TabIndex = 284
      Me.NetButton19.TextButton = ","
      '
      'NetButton20
      '
      Me.NetButton20.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton20.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton20.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton20.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton20.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton20.ColorText = System.Drawing.Color.Black
      Me.NetButton20.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton20.CornerRadius = 2
      Me.NetButton20.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton20.Location = New System.Drawing.Point(913, 591)
      Me.NetButton20.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton20.Name = "NetButton20"
      Me.NetButton20.Size = New System.Drawing.Size(80, 51)
      Me.NetButton20.TabIndex = 285
      Me.NetButton20.TextButton = "0"
      '
      'NetButton21
      '
      Me.NetButton21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton21.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton21.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton21.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton21.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton21.ColorText = System.Drawing.Color.Black
      Me.NetButton21.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton21.CornerRadius = 2
      Me.NetButton21.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton21.Location = New System.Drawing.Point(994, 591)
      Me.NetButton21.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton21.Name = "NetButton21"
      Me.NetButton21.Size = New System.Drawing.Size(78, 51)
      Me.NetButton21.TabIndex = 286
      Me.NetButton21.TextButton = "00"
      '
      'NetButton22
      '
      Me.NetButton22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton22.ColorBottom = System.Drawing.Color.Orange
      Me.NetButton22.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.NetButton22.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton22.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton22.ColorText = System.Drawing.Color.Black
      Me.NetButton22.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton22.CornerRadius = 2
      Me.NetButton22.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton22.Location = New System.Drawing.Point(737, 487)
      Me.NetButton22.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton22.Name = "NetButton22"
      Me.NetButton22.Size = New System.Drawing.Size(88, 51)
      Me.NetButton22.TabIndex = 287
      Me.NetButton22.TextButton = "X"
      '
      'NetButton23
      '
      Me.NetButton23.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton23.ColorBottom = System.Drawing.Color.Orange
      Me.NetButton23.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton23.ColorLight = System.Drawing.Color.LightSalmon
      Me.NetButton23.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton23.ColorText = System.Drawing.Color.Black
      Me.NetButton23.ColorTop = System.Drawing.Color.White
      Me.NetButton23.CornerRadius = 2
      Me.NetButton23.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton23.Location = New System.Drawing.Point(737, 539)
      Me.NetButton23.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton23.Name = "NetButton23"
      Me.NetButton23.Size = New System.Drawing.Size(88, 51)
      Me.NetButton23.TabIndex = 288
      Me.NetButton23.TextButton = "%"
      '
      'NetButton24
      '
      Me.NetButton24.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton24.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(40, Byte), Integer))
      Me.NetButton24.ColorDisabled = System.Drawing.Color.SeaGreen
      Me.NetButton24.ColorLight = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(189, Byte), Integer))
      Me.NetButton24.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Green
      Me.NetButton24.ColorText = System.Drawing.Color.Black
      Me.NetButton24.ColorTop = System.Drawing.Color.White
      Me.NetButton24.CornerRadius = 2
      Me.NetButton24.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton24.Location = New System.Drawing.Point(737, 591)
      Me.NetButton24.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton24.Name = "NetButton24"
      Me.NetButton24.Size = New System.Drawing.Size(88, 51)
      Me.NetButton24.TabIndex = 289
      Me.NetButton24.TextButton = "OK"
      '
      'TextBox1
      '
      Me.TextBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.TextBox1.BackColor = System.Drawing.SystemColors.Window
      Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.TextBox1.ForeColor = System.Drawing.Color.DodgerBlue
      Me.TextBox1.Location = New System.Drawing.Point(832, 393)
      Me.TextBox1.Name = "TextBox1"
      Me.TextBox1.Size = New System.Drawing.Size(241, 40)
      Me.TextBox1.TabIndex = 290
      Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'NetButton25
      '
      Me.NetButton25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton25.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton25.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton25.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton25.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton25.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton25.CornerRadius = 2
      Me.NetButton25.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton25.Location = New System.Drawing.Point(737, 392)
      Me.NetButton25.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton25.Name = "NetButton25"
      Me.NetButton25.Size = New System.Drawing.Size(88, 40)
      Me.NetButton25.TabIndex = 291
      Me.NetButton25.TextButton = "€"
      Me.NetButton25.TextButtonAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'NetButton26
      '
      Me.NetButton26.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton26.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.NetButton26.ColorDisabled = System.Drawing.Color.Brown
      Me.NetButton26.ColorLight = System.Drawing.Color.MistyRose
      Me.NetButton26.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Red
      Me.NetButton26.ColorText = System.Drawing.Color.Black
      Me.NetButton26.ColorTop = System.Drawing.Color.White
      Me.NetButton26.CornerRadius = 2
      Me.NetButton26.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton26.Location = New System.Drawing.Point(737, 435)
      Me.NetButton26.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton26.Name = "NetButton26"
      Me.NetButton26.Size = New System.Drawing.Size(88, 51)
      Me.NetButton26.TabIndex = 295
      Me.NetButton26.TextButton = "C"
      '
      'NetButton27
      '
      Me.NetButton27.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton27.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton27.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton27.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton27.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton27.ColorText = System.Drawing.Color.Black
      Me.NetButton27.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton27.CornerRadius = 2
      Me.NetButton27.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton27.Location = New System.Drawing.Point(994, 435)
      Me.NetButton27.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton27.Name = "NetButton27"
      Me.NetButton27.Size = New System.Drawing.Size(78, 51)
      Me.NetButton27.TabIndex = 294
      Me.NetButton27.TextButton = "9"
      '
      'NetButton28
      '
      Me.NetButton28.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton28.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton28.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton28.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton28.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton28.ColorText = System.Drawing.Color.Black
      Me.NetButton28.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton28.CornerRadius = 2
      Me.NetButton28.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton28.Location = New System.Drawing.Point(913, 435)
      Me.NetButton28.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton28.Name = "NetButton28"
      Me.NetButton28.Size = New System.Drawing.Size(80, 51)
      Me.NetButton28.TabIndex = 293
      Me.NetButton28.TextButton = "8"
      '
      'NetButton29
      '
      Me.NetButton29.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton29.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.NetButton29.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.NetButton29.ColorLight = System.Drawing.Color.LightCyan
      Me.NetButton29.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.NetButton29.ColorText = System.Drawing.Color.Black
      Me.NetButton29.ColorTop = System.Drawing.Color.AliceBlue
      Me.NetButton29.CornerRadius = 2
      Me.NetButton29.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton29.Location = New System.Drawing.Point(832, 435)
      Me.NetButton29.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton29.Name = "NetButton29"
      Me.NetButton29.Size = New System.Drawing.Size(80, 51)
      Me.NetButton29.TabIndex = 292
      Me.NetButton29.TextButton = "7"
      '
      'NetButton11
      '
      Me.NetButton11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton11.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton11.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton11.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton11.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton11.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton11.CornerRadius = 2
      Me.NetButton11.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton11.Location = New System.Drawing.Point(605, 62)
      Me.NetButton11.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton11.Name = "NetButton11"
      Me.NetButton11.Size = New System.Drawing.Size(127, 56)
      Me.NetButton11.TabIndex = 296
      Me.NetButton11.TextButton = "Reparto 2 (10%)"
      '
      'NetButton12
      '
      Me.NetButton12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton12.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton12.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton12.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton12.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton12.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton12.CornerRadius = 2
      Me.NetButton12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton12.Location = New System.Drawing.Point(605, 5)
      Me.NetButton12.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton12.Name = "NetButton12"
      Me.NetButton12.Size = New System.Drawing.Size(127, 56)
      Me.NetButton12.TabIndex = 297
      Me.NetButton12.TextButton = "Listino 1"
      '
      'NetButton30
      '
      Me.NetButton30.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton30.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton30.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton30.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton30.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton30.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton30.CornerRadius = 2
      Me.NetButton30.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton30.Location = New System.Drawing.Point(605, 119)
      Me.NetButton30.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton30.Name = "NetButton30"
      Me.NetButton30.Size = New System.Drawing.Size(127, 56)
      Me.NetButton30.TabIndex = 299
      Me.NetButton30.TextButton = "Sconti %"
      '
      'NetButton31
      '
      Me.NetButton31.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton31.ColorBottom = System.Drawing.Color.Silver
      Me.NetButton31.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton31.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton31.ColorText = System.Drawing.SystemColors.ControlText
      Me.NetButton31.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton31.CornerRadius = 2
      Me.NetButton31.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton31.Location = New System.Drawing.Point(0, 48)
      Me.NetButton31.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton31.Name = "NetButton31"
      Me.NetButton31.Size = New System.Drawing.Size(334, 56)
      Me.NetButton31.TabIndex = 298
      Me.NetButton31.TextButton = "Maggiorazioni %"
      '
      'NavigationBarGroupItemsContainer1
      '
      Me.NavigationBarGroupItemsContainer1.Id = "108cd603-d964-41f3-ab47-7eb8793881c3"
      Me.NavigationBarGroupItemsContainer1.Items.AddRange(New Elegant.Ui.NavigationBarItem() {Me.NavigationBarItem1, Me.NavigationBarItem2, Me.NavigationBarItem3, Me.NavigationBarItem4})
      Me.NavigationBarGroupItemsContainer1.Location = New System.Drawing.Point(0, 48)
      Me.NavigationBarGroupItemsContainer1.Name = "NavigationBarGroupItemsContainer1"
      Me.NavigationBarGroupItemsContainer1.Size = New System.Drawing.Size(334, 86)
      Me.NavigationBarGroupItemsContainer1.TabIndex = 4
      '
      'NavigationBarItem1
      '
      Me.NavigationBarItem1.Id = "40210738-1478-4735-b44f-5c27416878ce"
      Me.NavigationBarItem1.Location = New System.Drawing.Point(0, 0)
      Me.NavigationBarItem1.Name = "NavigationBarItem1"
      Me.NavigationBarItem1.Size = New System.Drawing.Size(334, 19)
      Me.NavigationBarItem1.TabIndex = 1
      Me.NavigationBarItem1.Text = "NavigationBarItem1"
      '
      'NavigationBarItem2
      '
      Me.NavigationBarItem2.Id = "9566ea7d-dcd0-47fa-8342-52711ba6760f"
      Me.NavigationBarItem2.Location = New System.Drawing.Point(0, 19)
      Me.NavigationBarItem2.Name = "NavigationBarItem2"
      Me.NavigationBarItem2.Size = New System.Drawing.Size(334, 19)
      Me.NavigationBarItem2.TabIndex = 2
      Me.NavigationBarItem2.Text = "NavigationBarItem2"
      '
      'NavigationBarItem3
      '
      Me.NavigationBarItem3.Id = "9e0c164b-9e7b-4efb-90e3-c13f42b61942"
      Me.NavigationBarItem3.Location = New System.Drawing.Point(0, 38)
      Me.NavigationBarItem3.Name = "NavigationBarItem3"
      Me.NavigationBarItem3.Size = New System.Drawing.Size(334, 19)
      Me.NavigationBarItem3.TabIndex = 3
      Me.NavigationBarItem3.Text = "NavigationBarItem3"
      '
      'NavigationBarItem4
      '
      Me.NavigationBarItem4.Id = "aca30b1a-1926-48ab-8a2f-741fa8155023"
      Me.NavigationBarItem4.Location = New System.Drawing.Point(0, 57)
      Me.NavigationBarItem4.Name = "NavigationBarItem4"
      Me.NavigationBarItem4.Size = New System.Drawing.Size(334, 19)
      Me.NavigationBarItem4.TabIndex = 4
      Me.NavigationBarItem4.Text = "NavigationBarItem4"
      '
      'NavigationBarGroupItemsContainer2
      '
      Me.NavigationBarGroupItemsContainer2.Id = "ef9a6125-fbe7-46a3-9359-3816349a7527"
      Me.NavigationBarGroupItemsContainer2.Items.AddRange(New Elegant.Ui.NavigationBarItem() {Me.NavigationBarItem5})
      Me.NavigationBarGroupItemsContainer2.Location = New System.Drawing.Point(0, 96)
      Me.NavigationBarGroupItemsContainer2.Name = "NavigationBarGroupItemsContainer2"
      Me.NavigationBarGroupItemsContainer2.Size = New System.Drawing.Size(334, 29)
      Me.NavigationBarGroupItemsContainer2.TabIndex = 306
      '
      'NavigationBarItem5
      '
      Me.NavigationBarItem5.Id = "58f0d069-f6cc-404b-9229-90b9ebef71d0"
      Me.NavigationBarItem5.Location = New System.Drawing.Point(0, 0)
      Me.NavigationBarItem5.Name = "NavigationBarItem5"
      Me.NavigationBarItem5.Size = New System.Drawing.Size(334, 19)
      Me.NavigationBarItem5.TabIndex = 1
      Me.NavigationBarItem5.Text = "NavigationBarItem5"
      '
      'Panel1
      '
      Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.Panel1.Location = New System.Drawing.Point(149, 5)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(138, 575)
      Me.Panel1.TabIndex = 300
      '
      'NetButton32
      '
      Me.NetButton32.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.NetButton32.ColorBottom = System.Drawing.Color.Black
      Me.NetButton32.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton32.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton32.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton32.ColorText = System.Drawing.Color.White
      Me.NetButton32.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton32.CornerRadius = 2
      Me.NetButton32.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton32.Location = New System.Drawing.Point(8, 586)
      Me.NetButton32.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton32.Name = "NetButton32"
      Me.NetButton32.Size = New System.Drawing.Size(68, 56)
      Me.NetButton32.TabIndex = 301
      Me.NetButton32.TextButton = "<"
      '
      'NetButton33
      '
      Me.NetButton33.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.NetButton33.ColorBottom = System.Drawing.Color.Black
      Me.NetButton33.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton33.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton33.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton33.ColorText = System.Drawing.Color.White
      Me.NetButton33.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton33.CornerRadius = 2
      Me.NetButton33.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton33.Location = New System.Drawing.Point(78, 586)
      Me.NetButton33.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton33.Name = "NetButton33"
      Me.NetButton33.Size = New System.Drawing.Size(68, 56)
      Me.NetButton33.TabIndex = 302
      Me.NetButton33.TextButton = ">"
      '
      'NetButton34
      '
      Me.NetButton34.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.NetButton34.ColorBottom = System.Drawing.Color.Black
      Me.NetButton34.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton34.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton34.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton34.ColorText = System.Drawing.Color.White
      Me.NetButton34.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton34.CornerRadius = 2
      Me.NetButton34.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton34.Location = New System.Drawing.Point(219, 586)
      Me.NetButton34.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton34.Name = "NetButton34"
      Me.NetButton34.Size = New System.Drawing.Size(68, 56)
      Me.NetButton34.TabIndex = 304
      Me.NetButton34.TextButton = ">"
      '
      'NetButton35
      '
      Me.NetButton35.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.NetButton35.ColorBottom = System.Drawing.Color.Black
      Me.NetButton35.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton35.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton35.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton35.ColorText = System.Drawing.Color.White
      Me.NetButton35.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton35.CornerRadius = 2
      Me.NetButton35.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton35.Location = New System.Drawing.Point(149, 586)
      Me.NetButton35.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton35.Name = "NetButton35"
      Me.NetButton35.Size = New System.Drawing.Size(68, 56)
      Me.NetButton35.TabIndex = 303
      Me.NetButton35.TextButton = "<"
      '
      'NetButton36
      '
      Me.NetButton36.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton36.ColorBottom = System.Drawing.Color.Black
      Me.NetButton36.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton36.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton36.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton36.ColorText = System.Drawing.Color.White
      Me.NetButton36.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton36.CornerRadius = 2
      Me.NetButton36.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton36.Location = New System.Drawing.Point(523, 586)
      Me.NetButton36.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton36.Name = "NetButton36"
      Me.NetButton36.Size = New System.Drawing.Size(68, 56)
      Me.NetButton36.TabIndex = 306
      Me.NetButton36.TextButton = ">"
      '
      'NetButton37
      '
      Me.NetButton37.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton37.ColorBottom = System.Drawing.Color.Black
      Me.NetButton37.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton37.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton37.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton37.ColorText = System.Drawing.Color.White
      Me.NetButton37.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton37.CornerRadius = 2
      Me.NetButton37.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton37.Location = New System.Drawing.Point(453, 586)
      Me.NetButton37.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton37.Name = "NetButton37"
      Me.NetButton37.Size = New System.Drawing.Size(68, 56)
      Me.NetButton37.TabIndex = 305
      Me.NetButton37.TextButton = "<"
      '
      'NetButton38
      '
      Me.NetButton38.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton38.ColorBottom = System.Drawing.Color.Black
      Me.NetButton38.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton38.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton38.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton38.ColorText = System.Drawing.Color.White
      Me.NetButton38.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton38.CornerRadius = 2
      Me.NetButton38.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton38.Location = New System.Drawing.Point(382, 586)
      Me.NetButton38.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton38.Name = "NetButton38"
      Me.NetButton38.Size = New System.Drawing.Size(68, 56)
      Me.NetButton38.TabIndex = 308
      Me.NetButton38.TextButton = ">"
      '
      'NetButton39
      '
      Me.NetButton39.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.NetButton39.ColorBottom = System.Drawing.Color.Black
      Me.NetButton39.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton39.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton39.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton39.ColorText = System.Drawing.Color.White
      Me.NetButton39.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton39.CornerRadius = 2
      Me.NetButton39.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton39.Location = New System.Drawing.Point(290, 586)
      Me.NetButton39.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton39.Name = "NetButton39"
      Me.NetButton39.Size = New System.Drawing.Size(68, 56)
      Me.NetButton39.TabIndex = 307
      Me.NetButton39.TextButton = "<"
      '
      'NetButton40
      '
      Me.NetButton40.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton40.ColorBottom = System.Drawing.Color.Black
      Me.NetButton40.ColorDisabled = System.Drawing.Color.DimGray
      Me.NetButton40.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton40.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton40.ColorText = System.Drawing.Color.White
      Me.NetButton40.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton40.CornerRadius = 2
      Me.NetButton40.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton40.Location = New System.Drawing.Point(360, 586)
      Me.NetButton40.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton40.Name = "NetButton40"
      Me.NetButton40.Size = New System.Drawing.Size(20, 56)
      Me.NetButton40.TabIndex = 309
      Me.NetButton40.TextButton = ""
      '
      'NetButton41
      '
      Me.NetButton41.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton41.ColorBottom = System.Drawing.Color.Gold
      Me.NetButton41.ColorDisabled = System.Drawing.Color.DarkGoldenrod
      Me.NetButton41.ColorLight = System.Drawing.Color.LightYellow
      Me.NetButton41.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Yellow
      Me.NetButton41.ColorText = System.Drawing.Color.Black
      Me.NetButton41.ColorTop = System.Drawing.Color.White
      Me.NetButton41.CornerRadius = 2
      Me.NetButton41.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton41.Location = New System.Drawing.Point(523, 5)
      Me.NetButton41.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton41.Name = "NetButton41"
      Me.NetButton41.Size = New System.Drawing.Size(68, 56)
      Me.NetButton41.TabIndex = 311
      Me.NetButton41.TextButton = "-"
      '
      'NetButton42
      '
      Me.NetButton42.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton42.ColorBottom = System.Drawing.Color.Gold
      Me.NetButton42.ColorDisabled = System.Drawing.Color.DarkGoldenrod
      Me.NetButton42.ColorLight = System.Drawing.Color.LightYellow
      Me.NetButton42.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Yellow
      Me.NetButton42.ColorText = System.Drawing.Color.Black
      Me.NetButton42.ColorTop = System.Drawing.Color.White
      Me.NetButton42.CornerRadius = 2
      Me.NetButton42.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton42.Location = New System.Drawing.Point(453, 5)
      Me.NetButton42.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton42.Name = "NetButton42"
      Me.NetButton42.Size = New System.Drawing.Size(68, 56)
      Me.NetButton42.TabIndex = 310
      Me.NetButton42.TextButton = "+"
      '
      'frmPos
      '
      Me.AcceptButton = Me.cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdEsci
      Me.ClientSize = New System.Drawing.Size(1076, 660)
      Me.Controls.Add(Me.NetButton41)
      Me.Controls.Add(Me.NetButton42)
      Me.Controls.Add(Me.NetButton40)
      Me.Controls.Add(Me.NetButton38)
      Me.Controls.Add(Me.NetButton39)
      Me.Controls.Add(Me.NetButton36)
      Me.Controls.Add(Me.NetButton37)
      Me.Controls.Add(Me.NetButton34)
      Me.Controls.Add(Me.NetButton35)
      Me.Controls.Add(Me.NetButton33)
      Me.Controls.Add(Me.NetButton32)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.NetButton30)
      Me.Controls.Add(Me.NetButton12)
      Me.Controls.Add(Me.NetButton11)
      Me.Controls.Add(Me.NetButton26)
      Me.Controls.Add(Me.NetButton27)
      Me.Controls.Add(Me.NetButton28)
      Me.Controls.Add(Me.NetButton29)
      Me.Controls.Add(Me.NetButton25)
      Me.Controls.Add(Me.TextBox1)
      Me.Controls.Add(Me.NetButton24)
      Me.Controls.Add(Me.NetButton23)
      Me.Controls.Add(Me.NetButton22)
      Me.Controls.Add(Me.NetButton21)
      Me.Controls.Add(Me.NetButton20)
      Me.Controls.Add(Me.NetButton19)
      Me.Controls.Add(Me.NetButton18)
      Me.Controls.Add(Me.NetButton17)
      Me.Controls.Add(Me.NetButton16)
      Me.Controls.Add(Me.NetButton15)
      Me.Controls.Add(Me.NetButton14)
      Me.Controls.Add(Me.NetButton13)
      Me.Controls.Add(Me.cmdTastiera)
      Me.Controls.Add(Me.NetButton10)
      Me.Controls.Add(Me.NetButton9)
      Me.Controls.Add(Me.NetButton8)
      Me.Controls.Add(Me.NetButton7)
      Me.Controls.Add(Me.NetButton5)
      Me.Controls.Add(Me.NetButton6)
      Me.Controls.Add(Me.NetButton3)
      Me.Controls.Add(Me.NetButton4)
      Me.Controls.Add(Me.NetButton2)
      Me.Controls.Add(Me.NetButton1)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.cmdC)
      Me.Controls.Add(Me.cmdX)
      Me.Controls.Add(Me.cmdModalità)
      Me.Controls.Add(Me.cmdNum00)
      Me.Controls.Add(Me.cmdVirgola)
      Me.Controls.Add(Me.lstMessaggi)
      Me.Controls.Add(Me.lblData)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.txtCodice)
      Me.Controls.Add(Me.lblTotale)
      Me.Controls.Add(Me.cmdProforma)
      Me.Controls.Add(Me.cmdScontrino)
      Me.Controls.Add(Me.cmdConferma)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.lblQuantità)
      Me.Controls.Add(Me.lblOra)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.cmdCancTutto)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.pnlCategoria)
      Me.Controls.Add(Me.cmdConto)
      Me.Controls.Add(Me.cmdEsci)
      Me.Controls.Add(Me.cmdListino4)
      Me.Controls.Add(Me.cmdListino3)
      Me.Controls.Add(Me.cmdListino2)
      Me.Controls.Add(Me.cmdListino1)
      Me.Controls.Add(Me.cmdDettagliSu)
      Me.Controls.Add(Me.cmdDettagliGiù)
      Me.Controls.Add(Me.cmdEscludiStampa)
      Me.Controls.Add(Me.cmdCancella)
      Me.Controls.Add(Me.cmdQuantitàMeno)
      Me.Controls.Add(Me.cmdQuantitaPiù)
      Me.Controls.Add(Me.cmdVariazioniMeno)
      Me.Controls.Add(Me.cmdVariazioniPiù)
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
      Me.Controls.Add(Me.Label2)
      Me.ForeColor = System.Drawing.Color.Silver
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Visual POS - CONTO IMMEDIATO"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      CType(Me.NavigationBarGroupItemsContainer1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.NavigationBarGroupItemsContainer1.ResumeLayout(False)
      Me.NavigationBarGroupItemsContainer1.PerformLayout()
      CType(Me.NavigationBarGroupItemsContainer2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.NavigationBarGroupItemsContainer2.ResumeLayout(False)
      Me.NavigationBarGroupItemsContainer2.PerformLayout()
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

   Private Function CalcolaGiacenza(ByVal giacenza As Double, ByVal scortaMin As Double, ByVal quantità As Double) As Double
      Try
         If scortaMin > 0 Then
            If (giacenza - quantità) < scortaMin Then
               ' Messaggio sottoscorta.
               MessageBox.Show("L'articolo o l'ingrediente selezionato risulterà essere sottoscorta!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Return (giacenza - quantità)

         ElseIf scortaMin = 0 Then
            If quantità = giacenza Then
               ' Messaggio giacenza pari a zero.
               MessageBox.Show("L'articolo o l'ingrediente selezionato risulterà essere con giacenza pari a zero!", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return 0

            ElseIf quantità > giacenza Then
               ' Messaggio quantità maggiore della giacenza.
               MessageBox.Show("Si sta scaricando una quantità maggiore della giacenza! " & _
                               "La quantità presente in giacenza assumerà un valore negativo.", "Attenzione!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return (giacenza - quantità)
            Else
               Return (giacenza - quantità)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Function CalcolaScarico(ByVal scarico As Double, ByVal nuovoScarico As Double) As Double
      Try
         Return (scarico + nuovoScarico)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub ScaricaIngredienti()
      Try
         Dim idArticolo As Integer
         Dim qtàScarico As Double

         cn.Open()

         Dim i As Integer
         For i = 0 To lstvDettagli.Items.Count - 1
            ' Ottiene l'Id del piatto.
            Dim IdPiatto As Integer = lstvDettagli.Items(i).SubItems(5).Text
            Dim qtàPiatto As Integer = lstvDettagli.Items(i).SubItems(1).Text

            ' Legge i dati degli ingredienti del piatto.
            Dim cmd As New OleDbCommand("SELECT * FROM Ingredienti WHERE Id_Piatto = " & IdPiatto & " ORDER BY Id ASC", cn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            Do While dr.Read
               idArticolo = Convert.ToInt32((dr.Item("Id_Articolo")))
               ' Moltiplica per il numero di piatti venduti.
               qtàScarico = Convert.ToDouble(dr.Item("Quantità")) * qtàPiatto


               AArticoli.LeggiDati("Articoli", dr.Item("Id_Articolo"))

               Dim nuovaGiacenza As Double = CalcolaGiacenza(AArticoli.Giacenza, AArticoli.ScortaMin, qtàScarico)
               Dim Carico As Double = 0
               Dim Scarico As Double = 0
               Dim situazioneScorta As Double = 0
               Dim valCarico As Double = 0
               Dim valScarico As Double = 0
               Dim valAttuale As Double = 0

               Scarico = CalcolaScarico(AArticoli.Scarico, qtàScarico)
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

               ' Verifica se è un carico o scarico.
               Dim qtàCaricata As Double = 0
               Dim qtàScaricata As Double = 0
               qtàScaricata = qtàScarico
               qtàCaricata = 0

               Dim data As Date = dtpData.Text

               ' Salva i dati per i movimenti di magazzino.
               SalvaMovimentiMag("MovMagazzino", idArticolo, data.ToShortDateString, AArticoli.Codice, AArticoli.Descrizione, _
                                  qtàCaricata, qtàScaricata, CausaleMovMag, AArticoli.PrezzoAcquisto, _
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

            cmd.Dispose()
            dr.Close()
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      Finally
         cn.Close()
      End Try
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

            ' Quantità
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(QTA)

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Descrizione"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Importo.
            Select Case NumListino
               Case Listino.Uno
                  If IsDBNull(dr.Item("Listino1")) = False Then
                     If dr.Item("Listino1") <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino1"))
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Due
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     If dr.Item("Listino2") <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino2"))
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Tre
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     If dr.Item("Listino3") <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino3"))
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Quattro
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     If dr.Item("Listino4") <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino4"))
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If
            End Select

            ' Prezzo.
            Select Case NumListino
               Case Listino.Uno
                  If IsDBNull(dr.Item("Listino1")) = False Then
                     If dr.Item("Listino1") <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino1"))
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Due
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     If dr.Item("Listino2") <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino2"))
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Tre
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     If dr.Item("Listino3") <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino3"))
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Quattro
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     If dr.Item("Listino4") <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino4"))
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If
            End Select

            ' Id Piatto.
            If IsDBNull(dr.Item("Id")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Id"))
            End If

            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Categoria"))
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(LeggiReparto(TAB_CATEGORIE, dr.Item("Categoria")))
            End If

            ' Inviata.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

            ' Stringa per registrare loperazione effettuata dall'operatore identificato.
            strDescrizione = "(" & dr.Item("Descrizione") & ")"

            trovato = True
         Loop

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.SelezionaPiatto, strDescrizione, MODULO_GESTIONE_POS)

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

            If i = 6 Then
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

   Public Function LeggiReparto(ByVal tabella As String, ByVal categoria As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & categoria & "'", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("Reparto")) = False Then
               Return dr.Item("Reparto")
            Else
               Return ""
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDatiComande(ByVal sql As String, ByVal tabella As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(sql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            CategoriaIniziale = dr.Item("Descrizione")

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

         Categorie(NumCategorie) = New NetButton
         Categorie(NumCategorie).Name = numero
         Categorie(NumCategorie).CornerRadius = 2
         Categorie(NumCategorie).Location = New Point(x, y)
         Categorie(NumCategorie).Size = New Size(LARGHEZZA_CATEGORIA, ALTEZZA_CATEGORIA)
         'Categorie(NumCategorie).FlatStyle = FlatStyle.Popup
         'Categorie(NumCategorie).BackColor = colore
         'Categorie(NumCategorie).ForeColor = Color.Black
         Categorie(NumCategorie).ColorBottom = colore
         Categorie(NumCategorie).ColorText = Color.Black
         Categorie(NumCategorie).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         'Categorie(NumCategorie).TextAlign = ContentAlignment.BottomCenter
         'Categorie(NumCategorie).Text = nome
         Categorie(NumCategorie).TextButton = nome
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
         'Panel1.Controls.Add(Categorie(NumCategorie))

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

         Piatti(NumPiatti) = New NetButton
         Piatti(NumPiatti).Name = numero
         Piatti(NumPiatti).Location = New Point(x, y)
         Piatti(NumPiatti).Size = New Size(LARGHEZZA_PIATTO, ALTEZZA_PIATTO)
         'Piatti(NumPiatti).FlatStyle = FlatStyle.Popup
         'Piatti(NumPiatti).BackColor = colore
         'Piatti(NumPiatti).ForeColor = Color.Black
         Piatti(NumPiatti).CornerRadius = 2
         Piatti(NumPiatti).ColorBottom = colore
         Piatti(NumPiatti).ColorText = Color.Black

         Piatti(NumPiatti).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         'Piatti(NumPiatti).TextAlign = ContentAlignment.BottomCenter
         'Piatti(NumPiatti).Text = nome
         Piatti(NumPiatti).TextButton = nome
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

         Variazioni(NumVariazioni) = New NetButton
         Variazioni(NumVariazioni).Name = numero
         Variazioni(NumVariazioni).Location = New Point(x, y)
         Variazioni(NumVariazioni).Size = New Size(LARGHEZZA_VARIAZIONE, ALTEZZA_VARIAZIONE)
         ' Variazioni(NumVariazioni).FlatStyle = FlatStyle.Popup
         'Variazioni(NumVariazioni).BackColor = colore
         'Variazioni(NumVariazioni).ForeColor = Color.Black
         Variazioni(NumVariazioni).CornerRadius = 2
         Variazioni(NumVariazioni).ColorBottom = colore
         Variazioni(NumVariazioni).ColorText = Color.Black

         Variazioni(NumVariazioni).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         'Variazioni(NumVariazioni).TextAlign = ContentAlignment.MiddleCenter
         ' Variazioni(NumVariazioni).Text = nome
         Variazioni(NumVariazioni).TextButton = nome
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

   Private Function AumentaDiminuisciQta(ByVal val As Boolean) As Boolean
      ' Vero: aumenta di 1 - Falso: diminuisce di 1.
      Try
         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Focus()

            Dim quantità As Integer = CInt(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text)
            Dim totPrezzo As Decimal = CDec(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(3).Text)
            Dim prezzo As Decimal

            ' Ottiene il prezzo di una singola unità.
            prezzo = totPrezzo / quantità

            If val = True Then
               quantità += 1
            Else
               If quantità = 1 Then
                  CancellaElemento()

                  Return False
               Else
                  quantità -= 1
               End If
            End If

            ' Calcola il prezzo totale in base alla quantità inserita.
            totPrezzo = prezzo * quantità
            lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(3).Text = String.Format("{0:0.00}", totPrezzo)

            lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text = quantità

            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Private Sub CancellaElemento()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         lstvDettagli.Focus()
         Dim strDescrizione As String = "(" & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text & _
                                        " " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text & _
                                        " € " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(3).Text & ")"

         g_frmMain.RegistraOperazione(TipoOperazione.Cancella, strDescrizione, MODULO_GESTIONE_POS)

         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Focus()
            lstvDettagli.Items.RemoveAt(lstvDettagli.FocusedItem.Index)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CancellaTutto()
      Try
         ' Registra loperazione effettuata dall'operatore identificato.
         lstvDettagli.Focus()
         g_frmMain.RegistraOperazione(TipoOperazione.CancellaTutto, String.Empty, MODULO_GESTIONE_POS)

         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Items.Clear()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EscludiElemento()
      Try
         Dim escludi As String

         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Focus()

            Dim colore As String = Convert.ToString(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor.ToArgb)

            ' Se il testo è già evidenziato...
            If colore = Convert.ToString(Color.LightCoral.ToArgb) Then
               If lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(8).Text = "No" Then
                  ' Imposta il nero.
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.White
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.Black
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                  escludi = "Incluso"
               Else
                  ' Imposta il nero.
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.MediumSeaGreen
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.White
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Bold)
                  escludi = "Incluso"
               End If
            Else
               ' Imposta il rosa.
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.LightCoral
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.White
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 12, FontStyle.Italic)
               escludi = "Escluso"
            End If

         Else
            Exit Sub
         End If

         ' Registra loperazione effettuata dall'operatore identificato.
         Dim strDescrizione As String = "(" & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text & _
                                        " " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text & _
                                        " € " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(3).Text & " - " & escludi & ")"

         g_frmMain.RegistraOperazione(TipoOperazione.Escludi, strDescrizione, MODULO_GESTIONE_POS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

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

   Private Sub CalcolaTotaleContoRep()
      Try
         If lstvDettagli.Items.Count <> 0 Then
            Dim i As Integer = 0
            Dim TotRiga As Decimal
            Dim TotaleConto As Decimal

            For i = 0 To lstvDettagli.Items.Count - 1

               Dim colore As Color = lstvDettagli.Items(i).BackColor
               If colore.Equals(Color.LightCoral) = False Then

                  TotRiga = CDec(lstvDettagli.Items(i).SubItems(3).Text)
                  TotaleConto = TotaleConto + TotRiga

               End If
            Next i

            TotaleContoRep = CFormatta.FormattaEuro(TotaleConto)
         Else
            TotaleContoRep = VALORE_ZERO
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

   Private Sub SelezionaPiatto(ByVal codice As String)
      Try
         If LeggiDatiPiatto(TAB_PIATTI, CInt(codice)) = False Then
            MsgBox("Codice inesistente!.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
         Else
            CalcolaTotaleQtà()
            CalcolaTotaleConto()
            CalcolaTotaleContoRep()
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

   Private Sub SalvaStatistiche(ByVal rifDoc As Boolean)

      Try
         Dim i As Integer
         For i = 0 To lstvDettagli.Items.Count - 1

            With Stat
               ' Assegna i dati dei campi della classe alle caselle di testo.
               .Data = CStr(dtpData.Value.Date)
               If rifDoc = True Then
                  ' Salva un riferimento Id del documento per il comando Annulla documento.
                  .IdCategoria = LeggiUltimoRecord("Documenti") ' Salva un riferimento Id del documento.
               Else
                  .IdCategoria = 0
               End If
               .DesCategoria = FormattaApici(lstvDettagli.Items(i).SubItems(6).Text)
               .IdPiatto = lstvDettagli.Items(i).SubItems(5).Text
               .DesPiatto = FormattaApici(lstvDettagli.Items(i).SubItems(2).Text)
               .IdTavolo = 0
               .DesTavolo = ""
               .IdCameriere = 0
               .DesCameriere = ""
               .Quantità = lstvDettagli.Items(i).SubItems(1).Text
               .Prezzo = lstvDettagli.Items(i).SubItems(4).Text
               .Importo = lstvDettagli.Items(i).SubItems(3).Text

               .InserisciDati(TAB_STATISTICHE)

               ' B_TODO: Modifica per Retail.
               If IsNothing(g_frmStatistiche) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmStatistiche.AggiornaDati()
               End If

            End With
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

      End Try
   End Sub

   Private Function LeggiPercorsiComanda(ByVal indice As Integer, ByVal valPos As Short) As String
      Dim val() As String = PercorsiStampantiComande(indice).Split(";")

      If val(valPos) <> String.Empty Then
         Return val(valPos)
      Else
         Return String.Empty
      End If
   End Function

   Private Sub ApriComande()
      Try
         Dim CComande As New Comande

         With CComande
            .LeggiDati(lstvDettagli, TAB_COMANDE, idTavolo)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ModificaStatoComande(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET Inviata = @Inviata", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Inviata", "Sì")

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

   Private Function SalvaComande() As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         Dim CComande As New Comande
         Dim i As Integer

         With CComande
            .EliminaDati(TAB_COMANDE, idTavolo)

            For i = 0 To lstvDettagli.Items.Count - 1
               .IdRisorsa = idTavolo
               .Risorsa = nomeTavolo
               .Cameriere = nomeCameriereDoc
               .Coperti = g_frmVCTavoli.lblCoperti.Text
               .Quantità = lstvDettagli.Items(i).SubItems(1).Text
               .Descrizione = lstvDettagli.Items(i).SubItems(2).Text
               .ImportoNetto = lstvDettagli.Items(i).SubItems(3).Text
               .ValoreUnitario = lstvDettagli.Items(i).SubItems(4).Text
               .IdPiatto = lstvDettagli.Items(i).SubItems(5).Text
               .CategoriaPiatto = lstvDettagli.Items(i).SubItems(6).Text
               .Reparto = lstvDettagli.Items(i).SubItems(7).Text
               .Inviata = lstvDettagli.Items(i).SubItems(8).Text

               .InserisciDati(TAB_COMANDE)
            Next
         End With

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Sub StampaComande()
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         cn.Open()

         ' Stampa della comanda aggiuntiva con tutti i piatti.
         sql = "SELECT * FROM Comande WHERE Inviata = 'No'"

         If LeggiPercorsiComanda(10, percorsiStampa.Report) <> String.Empty Then
            percorsoRep = "\Reports\" & LeggiPercorsiComanda(10, percorsiStampa.Report)
         Else
            percorsoRep = PERCORSO_REP_COMANDA_CLIENTI
         End If

         If LeggiPercorsiComanda(10, percorsiStampa.Stampante) <> String.Empty And _
            LeggiPercorsiComanda(10, percorsiStampa.Stampante) <> "Nessuna" Then

            Select Case percorsoRep
               Case PERCORSO_REP_COMANDA_CLIENTI
                  ' Esegue la stampa.
                  StampaDocumento(sql, percorsoRep, LeggiPercorsiComanda(10, percorsiStampa.Stampante))

               Case PERCORSO_REP_COMANDA_CLIENTI_KUBEII
                  StampaComandaKUBEII(sql, percorsoRep, nomeTavolo, nomeCameriereDoc, LeggiPercorsiComanda(10, percorsiStampa.Stampante))
            End Select
         End If

         ' Stampa delle comande suddivise per reparti.
         Dim cmd As New OleDbCommand("SELECT * FROM Reparti", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("Descrizione")) = False Then
               sql = "SELECT * FROM Comande WHERE Reparto = '" & dr.Item("Descrizione") & "' AND Inviata = 'No'"

               ' Controlla se ci sono comande da inviare per il reparto specificato.
               If VerificaNumRecord(sql) <> 0 Then
                  Dim i As Integer
                  For i = 0 To 9
                     If LeggiPercorsiComanda(i, percorsiStampa.Reparto) = dr.Item("Descrizione") Then
                        ' Invio stampa per le comande.
                        If LeggiPercorsiComanda(i, percorsiStampa.Report) <> String.Empty Then
                           percorsoRep = "\Reports\" & LeggiPercorsiComanda(i, percorsiStampa.Report)
                        Else
                           percorsoRep = PERCORSO_REP_COMANDA_REPARTI
                        End If

                        Select Case percorsoRep
                           Case PERCORSO_REP_COMANDA_REPARTI
                              ' Esegue la stampa.
                              StampaDocumento(sql, percorsoRep, LeggiPercorsiComanda(i, percorsiStampa.Stampante))

                           Case PERCORSO_REP_COMANDA_REPARTI_KUBEII
                              StampaComandaKUBEII(sql, percorsoRep, nomeTavolo, nomeCameriereDoc, LeggiPercorsiComanda(i, percorsiStampa.Stampante))
                        End Select

                     End If
                  Next
               End If
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub StampaDocumento(ByVal sql As String, ByVal nomeDoc As String, ByVal nomeStampante As String)
      Try
         'If PrintDialog1.ShowDialog() = DialogResult.OK Then

         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim ds As New Dataset1
         ds.Clear()

         ' Tabella Comande.
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand(sql, cn)
         oleAdapter1.Fill(ds, TAB_COMANDE)

         ' Tabella Azienda
         Dim oleAdapter2 As New OleDbDataAdapter
         oleAdapter2.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_AZIENDA, cn)
         oleAdapter2.Fill(ds, TAB_AZIENDA)

         ' Tabella Messaggi.
         Dim oleAdapter3 As New OleDbDataAdapter
         oleAdapter3.SelectCommand = New OleDbCommand(sql, cn)
         oleAdapter3.Fill(ds, TAB_MESSAGGI)

         Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

         rep.Load(Application.StartupPath & nomeDoc)

         rep.SetDataSource(ds)

         If nomeStampante <> String.Empty And nomeStampante <> "Nessuna" Then
            rep.PrintOptions.PrinterName = nomeStampante
         End If

         rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True, _
                   PrintDialog1.PrinterSettings.FromPage, _
                   PrintDialog1.PrinterSettings.ToPage)
         'End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub StampaMessaggi()
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         cn.Open()

         ' Stampa delle comande suddivise per reparti.
         Dim cmd As New OleDbCommand("SELECT * FROM Reparti", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("Descrizione")) = False Then
               sql = "SELECT * FROM Messaggi WHERE Reparto = '" & dr.Item("Descrizione") & "' AND Inviato = 'No'"

               ' Controlla se ci sono messaggi da inviare per il reparto specificato.
               If VerificaNumRecord(sql) <> 0 Then
                  Dim i As Integer
                  For i = 0 To 9
                     If LeggiPercorsiComanda(i, percorsiStampa.Reparto) = dr.Item("Descrizione") Then
                        ' Invio stampa per le comande.
                        'If LeggiPercorsiComanda(i, percorsiStampa.Report) <> String.Empty Then
                        '   percorsoRep = "\Reports\" & LeggiPercorsiComanda(i, percorsiStampa.Report)
                        'Else
                        'percorsoRep = PERCORSO_REP_MESSAGGI
                        'End If

                        ' Esegue la stampa.
                        StampaDocumento(sql, PERCORSO_REP_MESSAGGI, LeggiPercorsiComanda(i, percorsiStampa.Stampante))
                     End If
                  Next
               End If
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Function RegistraMsgComanda() As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         Dim daRegistrare As Boolean

         Dim i As Integer
         For i = 0 To lstvDettagli.Items.Count - 1
            If lstvDettagli.Items(i).SubItems(8).Text = "No" Then
               daRegistrare = True
               Exit For
            End If
         Next

         If daRegistrare = False Then
            Exit Function
         End If

         ' Intestazione.
         SalvaDatiMsgComande(TAB_MESSAGGI, "", idTavolo, nomeTavolo, "TAVOLO: " & nomeTavolo & " - CAMERIERE: " & nomeCameriereDoc)
         'SalvaDatiMessaggi(TAB_MESSAGGI, "", idTavolo, nomeTavolo, "-")

         For i = 0 To lstvDettagli.Items.Count - 1
            If lstvDettagli.Items(i).SubItems(8).Text = "No" Then
               ' Dettagli.
               SalvaDatiMsgComande(TAB_MESSAGGI, lstvDettagli.Items(i).SubItems(7).Text, idTavolo, nomeTavolo, _
                                 lstvDettagli.Items(i).SubItems(1).Text & " " & lstvDettagli.Items(i).SubItems(2).Text)
            End If
         Next

         ' Fine.
         SalvaDatiMsgComande(TAB_MESSAGGI, "", idTavolo, nomeTavolo, "-")

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Function RegistraMsgModificaComanda(ByVal Qta As Integer) As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         ' Intestazione.
         lstMessaggi.Items.Add(";TAVOLO: " & nomeTavolo & " - CAMERIERE: " & nomeCameriereDoc)
         ' Dettagli.
         lstMessaggi.Items.Add(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(7).Text & _
                              ";MODIFICA: " & Qta & " " & _
                              lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text & " IN " & _
                              lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text & " " & _
                              lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text)
         ' Fine.
         lstMessaggi.Items.Add(";-")

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Function RegistraMsgCancellaComanda() As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         ' Intestazione.
         lstMessaggi.Items.Add(";TAVOLO: " & nomeTavolo & " - CAMERIERE: " & nomeCameriereDoc)
         ' Dettagli.
         lstMessaggi.Items.Add(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(7).Text & _
                              ";CANCELLA: " & _
                              lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text & " " & _
                              lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text)
         ' Fine.
         lstMessaggi.Items.Add(";-")

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Function RegistraMsgAnnullaComanda() As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         Dim intestazione As Boolean

         Dim i As Integer
         For i = 0 To lstvDettagli.Items.Count - 1
            If lstvDettagli.Items(i).SubItems(8).Text = "Sì" Then

               If intestazione = False Then
                  ' Intestazione.
                  lstMessaggi.Items.Add(";TAVOLO: " & nomeTavolo & " - CAMERIERE: " & nomeCameriereDoc)
                  intestazione = True
               End If

               ' Dettagli.
               lstMessaggi.Items.Add(lstvDettagli.Items(i).SubItems(7).Text & _
                                    ";CANCELLA: " & _
                                    lstvDettagli.Items(i).SubItems(1).Text & " " & _
                                    lstvDettagli.Items(i).SubItems(2).Text)
            End If
         Next

         If intestazione = True Then
            ' Fine.
            lstMessaggi.Items.Add(";-")
         End If

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Function RegistraTuttiMsgComanda() As Boolean
      Try
         If lstMessaggi.Items.Count = 0 Then
            Return False
         End If

         Dim i As Integer
         For i = 0 To lstMessaggi.Items.Count - 1
            lstMessaggi.SelectedIndex = i
            Dim sep As Char() = ";"
            Dim val() As String = lstMessaggi.Text.Split(sep, 2) 'lstMessaggi.Text.Split(";", 2)

            SalvaDatiMessaggi(TAB_MESSAGGI, val(0), idTavolo, nomeTavolo, val(1))
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Function SalvaDatiMessaggi(ByVal tabella As String, ByVal reparto As String, ByVal idTavolo As Integer, ByVal Tavolo As String, ByVal messaggio As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Data, Reparto, IdRisorsa, DescrizioneRisorsa, Messaggio, Inviato) " & _
                                       "VALUES(@Data, @Reparto, @IdRisorsa, @DescrizioneRisorsa, @Messaggio, @Inviato)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Data", Now.ToShortDateString & " " & Now.ToShortTimeString)
         cmdInsert.Parameters.Add("@Reparto", reparto)
         cmdInsert.Parameters.Add("@IdRisorsa", idTavolo)
         cmdInsert.Parameters.Add("@DescrizioneRisorsa", Tavolo)
         cmdInsert.Parameters.Add("@Messaggio", messaggio)
         cmdInsert.Parameters.Add("@Inviato", "No")

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

   Public Function SalvaDatiMsgComande(ByVal tabella As String, ByVal reparto As String, ByVal idTavolo As Integer, ByVal Tavolo As String, ByVal messaggio As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Data, Reparto, IdRisorsa, DescrizioneRisorsa, Messaggio, Inviato) " & _
                                       "VALUES(@Data, @Reparto, @IdRisorsa, @DescrizioneRisorsa, @Messaggio, @Inviato)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Data", Now.ToShortDateString & " " & Now.ToShortTimeString)
         cmdInsert.Parameters.Add("@Reparto", reparto)
         cmdInsert.Parameters.Add("@IdRisorsa", idTavolo)
         cmdInsert.Parameters.Add("@DescrizioneRisorsa", Tavolo)
         cmdInsert.Parameters.Add("@Messaggio", messaggio)
         cmdInsert.Parameters.Add("@Inviato", "Sì")

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

   Public Function ModificaStatoMessaggi(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET Inviato = @Inviato", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Inviato", "Sì")

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

   Public Function VerificaNumRecord(ByVal sql As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = sql
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

   Private Sub TavoloDaLiberare()
      Try
         ' Imposta il colore del tavolo come Da liberare.
         g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).BackColor = g_frmVCTavoli.TAVOLO_DA_LIBERARE

         ' Rimuove il contatore del tempo.
         g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).Text = _
                               g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).Text.Remove(g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).Text.Length - _
                               g_frmVCTavoli.LUNGHEZZA_ORA, g_frmVCTavoli.LUNGHEZZA_ORA)

         ' Modifica lo stato del tavolo nel database. 
         g_frmVCTavoli.ModificaStatoTavolo(g_frmVCTavoli.ANAG_TAVOLI, g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).Name, _
                                           g_frmVCTavoli.TAVOLO_DA_LIBERARE, "", "")

         ' Elimina le comande del tavolo nel database.
         g_frmVCTavoli.EliminaComandeTavolo(g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).Name)

         ' Rimuove il tavolo dalla lista dei tavoli occupati.
         Dim i As Integer = 0
         For i = 0 To g_frmVCTavoli.NumTavoliOccupati - 1
            If g_frmVCTavoli.IndiceTavoloOccupato(i) <> Nothing Then
               If g_frmVCTavoli.Risorsa(g_frmVCTavoli.IndiceTavoloOccupato(i)).Name = _
                  g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).Name Then
                  g_frmVCTavoli.IndiceTavoloOccupato(i) = Nothing
                  g_frmVCTavoli.NumTavoliOccupati -= 1
                  Exit For
               End If
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub AsportoDaLiberare()
      Try
         ' Elimina le comande del tavolo nel database.
         g_frmVCTavoli.EliminaComandeTavolo(idTavolo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub InfoScontrino()
      MsgBox("Non è possibile stampare lo scontrino! Verificare che per questo documento sia impostata una stampante o registratore di cassa.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
   End Sub

   Private Sub StampaConto(ByVal tipo As Short)
      Try
         ' Serve a registrare l'operazione svolta.
         Dim totConto As String = lblTotale.Text

         If lstvDettagli.Items.Count = 0 Then
            MsgBox("Non è possibile eseguire il comando. Il conto è vuoto!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
            Return
         Else
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            g_frmContoPos = New ContoPos(tipo, idTavolo, nomeTavoloDoc, nomeCameriereDoc)
            If g_frmContoPos.ShowDialog() = DialogResult.OK Then
               If mantieniDatiTavolo = False Then
                  If nomeTavoloDoc = "Asporto" Then
                     AsportoDaLiberare()
                     ScaricaIngredienti()
                     SalvaStatistiche(True)
                     cmdCancTutto.PerformClick()
                  End If

                  If nomeTavoloDoc <> "Conto Imm." And nomeTavoloDoc <> "Asporto" Then
                     TavoloDaLiberare()
                     ScaricaIngredienti()
                     SalvaStatistiche(True)
                     cmdCancTutto.PerformClick()
                  Else
                     ScaricaIngredienti()
                     SalvaStatistiche(True)
                     cmdCancTutto.PerformClick()
                  End If
               Else
                  If nomeTavoloDoc = "Conto Imm." Then
                     ScaricaIngredienti()
                     SalvaStatistiche(True)
                     cmdCancTutto.PerformClick()
                  End If

                  mantieniDatiTavolo = False
               End If

               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.Default

               ' Registra loperazione effettuata dall'operatore identificato.
               Select Case tipo
                  Case Documento.Proforma
                     g_frmMain.RegistraOperazione(TipoOperazione.Proforma, "(Tot. € " & totConto & ")", MODULO_GESTIONE_POS)

                  Case Documento.Scontrino
                     g_frmMain.RegistraOperazione(TipoOperazione.Scontrino, "(Tot. € " & totConto & ")", MODULO_GESTIONE_POS)
               End Select

               ' B_TODO: Modifica per Retail.
               If IsNothing(g_frmDocumenti) = False Then
                  With g_frmDocumenti
                     If .tbrSospesi.Pushed = True Then
                        ' Aggiorna la griglia dati.
                        .AggiornaDatiSospesi()
                        Exit Sub
                     ElseIf .tbrMese.Pushed = True Then
                        ' Aggiorna la griglia dati.
                        .AggiornaDatiMese()
                        Exit Sub
                     ElseIf .tbrAnno.Pushed = True Then
                        ' Aggiorna la griglia dati.
                        .AggiornaDatiAnno()
                        Exit Sub
                     ElseIf .tbrPeriodo.Pushed = True Then
                        ' Aggiorna la griglia dati.
                        .AggiornaDatiPeriodo()
                        Exit Sub
                     Else
                        ' Aggiorna la griglia dati.
                        .AggiornaDati()
                        Exit Sub
                     End If
                  End With
               End If

               ' Se è stato aperto dalla gestione Tavoli chiude il form.
               If nomeTavolo <> String.Empty Then
                  confermaModifiche = True
                  Me.Close()
               End If
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Function VerificaPiattiEsauriti(ByVal idPiatto As Integer) As Boolean
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM PiattiEsauriti WHERE IdPiatto = " & idPiatto)
         numRec = CInt(cmd.ExecuteScalar())

         If numRec = 0 Then
            Return False
         Else
            Return True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

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

      If VerificaPiattiEsauriti(Convert.ToInt32(CType(sender, NetButton).Name)) = False Then
         SelezionaPiatto(CType(sender, NetButton).Name)
      Else
         MessageBox.Show("Il piatto selezionato è esaurito!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If
   End Sub

   Private Sub Variazioni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      If VerificaPiattiEsauriti(Convert.ToInt32(CType(sender, NetButton).Name)) = False Then
         SelezionaPiatto(CType(sender, NetButton).Name)
      Else
         MessageBox.Show("La variante selezionata è esaurita!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If
   End Sub

   Private Sub VPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         If AbilitaPalmareWindows = True Then
            If IsNothing(g_frmVCTavoli) = False Then
               g_frmVCTavoli.Timer3.Enabled = False
            End If
         End If

         If AbilitaPalmareAndroid = True Then
            If IsNothing(g_frmVCTavoli) = False Then
               g_frmVCTavoli.Timer3.Enabled = False
            End If
         End If

         Me.Text = infoTitolo

         ' to_do: leggere da file di configurazione.
         NumListino = Listino.Uno

         LeggiDatiCategorie(TAB_CATEGORIE)

         LeggiDatiPiatti(TAB_PIATTI, CategoriaIniziale)

         LeggiDatiVariazioni(TAB_PIATTI, CategoriaIniziale)

         ApriComande()

         CalcolaTotaleQtà()

         CalcolaTotaleConto()

         CalcolaTotaleContoRep()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
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

      'txtCodice.Text = txtCodice.Text & "1"
      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdNum2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum2.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      'txtCodice.Text = txtCodice.Text & "2"
      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdNum3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum3.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      'txtCodice.Text = txtCodice.Text & "3"
      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdNum4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum4.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      'txtCodice.Text = txtCodice.Text & "4"
      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdNum5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum5.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      'txtCodice.Text = txtCodice.Text & "5"
      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdNum6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum6.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      'txtCodice.Text = txtCodice.Text & "6"
      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdNum7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum7.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      'txtCodice.Text = txtCodice.Text & "7"
      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdNum8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum8.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      'txtCodice.Text = txtCodice.Text & "8"
      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdNum9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum9.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      'txtCodice.Text = txtCodice.Text & "9"
      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdNum0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum0.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      'txtCodice.Text = txtCodice.Text & "0"
      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEsci.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub cmdListino1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListino1.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         cmdListino1.BackColor = Color.LightCoral
         cmdListino2.BackColor = Color.DodgerBlue
         cmdListino3.BackColor = Color.DodgerBlue
         cmdListino4.BackColor = Color.DodgerBlue

         NumListino = Listino.Uno

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Listino, "(Listino " & NumListino.ToString & ")", MODULO_GESTIONE_POS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdListino2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListino2.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         cmdListino1.BackColor = Color.DodgerBlue
         cmdListino2.BackColor = Color.LightCoral
         cmdListino3.BackColor = Color.DodgerBlue
         cmdListino4.BackColor = Color.DodgerBlue

         NumListino = Listino.Due

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Listino, "(Listino " & NumListino.ToString & ")", MODULO_GESTIONE_POS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdListino3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListino3.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         cmdListino1.BackColor = Color.DodgerBlue
         cmdListino2.BackColor = Color.DodgerBlue
         cmdListino3.BackColor = Color.LightCoral
         cmdListino4.BackColor = Color.DodgerBlue

         NumListino = Listino.Tre

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Listino, "(Listino " & NumListino.ToString & ")", MODULO_GESTIONE_POS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdListino4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListino4.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         cmdListino1.BackColor = Color.DodgerBlue
         cmdListino2.BackColor = Color.DodgerBlue
         cmdListino3.BackColor = Color.DodgerBlue
         cmdListino4.BackColor = Color.LightCoral

         NumListino = Listino.Quattro

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Listino, "(Listino " & NumListino.ToString & ")", MODULO_GESTIONE_POS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
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

   Private Sub cmdEscludiStampa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEscludiStampa.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      EscludiElemento()
      CalcolaTotaleContoRep()
   End Sub

   Private Sub cmdCancella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancella.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvDettagli.Items.Count = 0 Then
            Exit Sub
         End If

         If lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(8).Text = "Sì" Then
            RegistraMsgCancellaComanda()
         End If

         CancellaElemento()
         CalcolaTotaleQtà()
         CalcolaTotaleConto()
         CalcolaTotaleContoRep()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdQuantitaPiù_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuantitaPiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim operazioneQtà As Boolean

         lstvDettagli.Focus()

         If lstvDettagli.Items.Count <> 0 Then
            Dim quantità As Integer = CInt(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text)

            operazioneQtà = AumentaDiminuisciQta(True)

            If lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(8).Text = "Sì" Then
               RegistraMsgModificaComanda(quantità)
            End If
         End If

         CalcolaTotaleQtà()
         CalcolaTotaleConto()
         CalcolaTotaleContoRep()

         If operazioneQtà = True Then
            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text & _
                                           " " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text & ")"

            g_frmMain.RegistraOperazione(TipoOperazione.QuantitàPiù, strDescrizione, MODULO_GESTIONE_POS)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdQuantitàMeno_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdQuantitàMeno.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim operazioneQtà As Boolean

         lstvDettagli.Focus()

         If lstvDettagli.Items.Count <> 0 Then
            Dim quantità As Integer = CInt(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text)

            operazioneQtà = AumentaDiminuisciQta(False)

            If quantità = 1 Then
               If lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(8).Text = "Sì" Then
                  RegistraMsgCancellaComanda()
               End If
            Else
               If lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(8).Text = "Sì" Then
                  RegistraMsgModificaComanda(quantità)
               End If
            End If
         End If

         CalcolaTotaleQtà()
         CalcolaTotaleConto()
         CalcolaTotaleContoRep()

         If operazioneQtà = True Then
            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text & _
                                           " " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text & ")"

            g_frmMain.RegistraOperazione(TipoOperazione.QuantitàMeno, strDescrizione, MODULO_GESTIONE_POS)
         End If

      Catch ex As NullReferenceException
         lblTotale.Text = VALORE_ZERO
         lblQuantità.Text = "0"
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdCancTutto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancTutto.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      RegistraMsgAnnullaComanda()

      CancellaTutto()
      CalcolaTotaleQtà()
      CalcolaTotaleConto()
      CalcolaTotaleContoRep()
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

   Private Sub lstvDettagli_Click(sender As Object, e As System.EventArgs) Handles lstvDettagli.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)
   End Sub

   Private Sub lstvDettagli_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvDettagli.Resize
      Try
         NumElementi = (lstvDettagli.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
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

   Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
      'If txtCodice.Text.Length <> 0 Then
      '   If IsNumeric(txtCodice.Text) Then
      '      SelezionaPiatto(txtCodice.Text)
      '   Else
      '      MsgBox("Inserire un valore numerico!.", MsgBoxStyle.OKOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
      '   End If
      'End If

      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      Select Case cmdModalità.Text
         Case "€"
            If txtCodice Is Nothing = False Then
               If txtCodice.Text = "" Then
                  txtCodice.Text = VALORE_ZERO
               End If
            End If

            ' Moltiplicazione su una TextBox.
            If moltiplica = True Then
               txtCodice.Text = CFormatta.FormattaNumeroDouble(op1 * op2)
               op1 = 0.0
               op2 = 0.0
               moltiplica = False
            End If

            ' Inserisce l'importo per un Articolo generico.
            If txtCodice.Text.Length <> 0 Then
               If IsNumeric(txtCodice.Text) Then
                  SelezionaImporto(CFormatta.FormattaEuro(txtCodice.Text))
               Else
                  MsgBox("Inserire un valore numerico!.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
               End If
            End If

         Case "?"
            ' Ricerca il codice selezionato.
            If txtCodice.Text.Length <> 0 Then
               If IsNumeric(txtCodice.Text) Then
                  SelezionaPiatto(txtCodice.Text)
               Else
                  MsgBox("Inserire un valore numerico!.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
               End If
            End If
      End Select

   End Sub

   Private Sub cmdConto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConto.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_CONTO, MODULO_CONTO)

      StampaConto(Documento.Conto)
   End Sub

   Private Sub frmPos_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         ' Distrugge l'oggetto e libera le risorse.
         g_frmPos.Dispose()
         g_frmPos = Nothing

         If AbilitaPalmareWindows = True Then
            If IsNothing(g_frmVCTavoli) = False Then
               g_frmVCTavoli.Timer3.Enabled = True
            End If
         End If

         If AbilitaPalmareAndroid = True Then
            If IsNothing(g_frmVCTavoli) = False Then
               g_frmVCTavoli.Timer3.Enabled = True
            End If
         End If

         Select Case idTavolo
            Case Nothing
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_PUNTO_CASSA, MODULO_GESTIONE_POS)

            Case 0
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.ChiudiAsporto, String.Empty, MODULO_TAVOLI)

            Case Else
               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.ChiudiTavolo, "(" & nomeTavolo & ")", MODULO_TAVOLI)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub frmPos_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      Try
         ' Se la finestra viene chiusa per il cambio operatore non chiede la conferma.
         If g_frmPos.Tag = "OPERATORE" Then
            Exit Sub
         End If

         ' Se la finestra viene aperta dalla gestione dei tavoli non chiede la conferma.
         If idTavolo <> 0 And IsNothing(idTavolo) = False Then
            Exit Sub
         End If

         If confermaModifiche = False Then
            Dim risposta As MsgBoxResult = MsgBox("Sicuro di voler uscire?.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)

            If risposta = MsgBoxResult.No Then
               e.Cancel = True
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub frmPos_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      If Me.Width <= 936 Then
         Me.Width = 936
      End If

      If Me.Height <= 520 Then
         Me.Height = 520
      End If
   End Sub

   Private Sub cmdConferma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConferma.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If nomeTavolo <> String.Empty And nomeTavolo <> "Tavoli" Then
            If SalvaComande() = True Then

               ' Inviare comande ai reparti.
               StampaComande()
               RegistraMsgComanda()
               RegistraTuttiMsgComanda()
               StampaMessaggi()
               ModificaStatoMessaggi(TAB_MESSAGGI)
               ModificaStatoComande(TAB_COMANDE)
               If IsNothing(g_frmMessaggi) = False Then
                  g_frmMessaggi.AggiornaDati()
               End If

               If idTavolo <> 0 Then
                  ' Imposta il tavolo come Da servire.
                  g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).BackColor = g_frmVCTavoli.TAVOLO_DA_SERVIRE
                  g_frmVCTavoli.ModificaStatoColoreTavolo(g_frmVCTavoli.ANAG_TAVOLI, g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).Name, _
                                                          g_frmVCTavoli.TAVOLO_DA_SERVIRE)
               End If

               confermaModifiche = True
               Me.Close()

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Conferma, "(Tot. € " & lblTotale.Text & ")", MODULO_GESTIONE_POS)

            End If
         Else
            ' Conferma il Conto immediato.
            If lstvDettagli.Items.Count = 0 Then
               MsgBox("Non è possibile eseguire il comando. Il conto è vuoto!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
               Return
            Else
               Dim risposta As MsgBoxResult = MsgBox("Sicuro di voler confermare il conto? Non verrà stampato nessun documento.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)

               If risposta = MsgBoxResult.Yes Then
                  ' Modifica il cursore del mouse.
                  Cursor.Current = Cursors.AppStarting

                  CausaleMovMag = "Vendita"

                  ScaricaIngredienti()
                  SalvaStatistiche("0")
                  cmdCancTutto.PerformClick()

                  ' Modifica il cursore del mouse.
                  Cursor.Current = Cursors.Default

                  ' Registra loperazione effettuata dall'operatore identificato.
                  g_frmMain.RegistraOperazione(TipoOperazione.Conferma, String.Empty, MODULO_GESTIONE_POS)

                  ' Se è stato aperto dalla gestione Tavoli chiude il form.
                  If nomeTavolo <> String.Empty Then
                     confermaModifiche = True
                     Me.Close()
                  End If
               Else
                  Return
               End If
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub txtCodice_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodice.KeyPress
      'e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub cmdProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProforma.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      StampaConto(Documento.Proforma)
   End Sub

   Private Sub cmdScontrino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScontrino.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      StampaConto(Documento.Scontrino)
   End Sub

   Private Sub DigitaNumeri(ByVal ctrl As Control, ByVal sndr As Object)
      Try
         If ctrl Is Nothing = False Then
            ' Salva i dati per la moltiplicazione.
            If moltiplica = False Then
               ctrl.Text = ctrl.Text & sndr.Text
               op1 = CDbl(ctrl.Text)
            Else
               ctrl.Text = ""
               ctrl.Text = ctrl.Text & sndr.Text
               op2 = CDbl(ctrl.Text)
            End If

            ctrl.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub SelezionaImporto(ByVal importo As String)
      Try
         If InserisciImporto(importo) = False Then
            MsgBox("Valore numerico errato! Digitare un valore corretto.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
         Else
            CalcolaTotaleQtà()
            CalcolaTotaleConto()
            CalcolaTotaleContoRep()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         txtCodice.Text = VALORE_ZERO

         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).Focused = True
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).Selected = True
            lstvDettagli.Focus()
         End If
      End Try
   End Sub

   Public Function InserisciImporto(ByVal importo As String) As Boolean
      Const QTA As String = "1"
      Dim strDescrizione As String

      Try
         ' Indice
         lstvDettagli.Items.Add(lstvDettagli.Items.Count)

         ' Quantità
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(QTA)

         ' Descrizione.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("Art. Generico")

         ' Importo.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(importo)

         ' Prezzo.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(importo)

         ' Id Piatto.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("0")

         ' Categoria.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("Generico")

         ' Reparto.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("Generico")

         ' Inviata.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("Sì")

         ' Stringa per registrare l'operazione effettuata dall'operatore identificato.
         strDescrizione = "(Art. Generico)"

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.SelezionaPiatto, strDescrizione, MODULO_GESTIONE_POS)

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Private Sub cmdVirgola_Click(sender As System.Object, e As System.EventArgs) Handles cmdVirgola.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         ' Verifica la presenza della virgola.

         If txtCodice.Text = "" Then
            txtCodice.Focus()
            Exit Sub
         Else
            Dim virgola As Integer = txtCodice.Text.IndexOf(sender.Text)

            If virgola <> -1 Then
               txtCodice.Focus()
               Exit Sub
            Else
               DigitaNumeri(txtCodice, sender)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdNum00_Click(sender As System.Object, e As System.EventArgs) Handles cmdNum00.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(txtCodice, sender)
   End Sub

   Private Sub cmdC_Click(sender As System.Object, e As System.EventArgs) Handles cmdC.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         txtCodice.Text = ""
         txtCodice.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdX_Click(sender As System.Object, e As System.EventArgs) Handles cmdX.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      moltiplica = True
   End Sub

   Private Sub cmdModalità_Click(sender As System.Object, e As System.EventArgs) Handles cmdModalità.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Select Case cmdModalità.Text
         Case "€"
            cmdModalità.Text = "?"
            txtCodice.Text = String.Empty
            cmdVirgola.Enabled = False
            cmdX.Enabled = False
            txtCodice.Focus()

         Case "?"
            cmdModalità.Text = "€"
            txtCodice.Text = VALORE_ZERO
            cmdVirgola.Enabled = True
            cmdX.Enabled = True
            txtCodice.Focus()

      End Select
   End Sub


End Class
