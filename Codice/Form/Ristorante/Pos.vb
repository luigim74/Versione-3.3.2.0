' Nome form:            POS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/04/2006
' Data ultima modifica: 24/04/2006
' Descrizione:          Interfaccia Punto cassa - conto immediato

Imports System.IO
Imports System.Data.OleDb

Public Class frmPos
   Inherits System.Windows.Forms.Form

   Const TAB_AZIENDA As String = "Azienda"
   Const TAB_PIATTI As String = "Piatti"
   Const TAB_CATEGORIE As String = "CategoriePiatti"
   Const TAB_COMANDE As String = "Comande"
   Const TAB_STATISTICHE As String = "Statistiche"
   Const TAB_MESSAGGI As String = "Messaggi"

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
      Me.cmdCategorieGiù.Location = New System.Drawing.Point(8, 480)
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
      Me.cmdCategorieSu.Location = New System.Drawing.Point(80, 480)
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
      Me.cmdPiattiGiù.Location = New System.Drawing.Point(152, 480)
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
      Me.cmdPiattiSu.Location = New System.Drawing.Point(312, 480)
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
      Me.cmdVariazioniSu.Location = New System.Drawing.Point(540, 480)
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
      Me.cmdVariazioniGiù.Location = New System.Drawing.Point(472, 480)
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
      Me.cmdNum1.Location = New System.Drawing.Point(8, 526)
      Me.cmdNum1.Name = "cmdNum1"
      Me.cmdNum1.Size = New System.Drawing.Size(54, 40)
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
      Me.cmdNum2.Location = New System.Drawing.Point(69, 526)
      Me.cmdNum2.Name = "cmdNum2"
      Me.cmdNum2.Size = New System.Drawing.Size(54, 40)
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
      Me.cmdNum3.Location = New System.Drawing.Point(130, 526)
      Me.cmdNum3.Name = "cmdNum3"
      Me.cmdNum3.Size = New System.Drawing.Size(54, 40)
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
      Me.cmdNum4.Location = New System.Drawing.Point(191, 526)
      Me.cmdNum4.Name = "cmdNum4"
      Me.cmdNum4.Size = New System.Drawing.Size(54, 40)
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
      Me.cmdNum5.Location = New System.Drawing.Point(252, 526)
      Me.cmdNum5.Name = "cmdNum5"
      Me.cmdNum5.Size = New System.Drawing.Size(54, 40)
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
      Me.cmdNum6.Location = New System.Drawing.Point(8, 574)
      Me.cmdNum6.Name = "cmdNum6"
      Me.cmdNum6.Size = New System.Drawing.Size(54, 40)
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
      Me.cmdNum7.Location = New System.Drawing.Point(69, 574)
      Me.cmdNum7.Name = "cmdNum7"
      Me.cmdNum7.Size = New System.Drawing.Size(54, 40)
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
      Me.cmdNum0.Location = New System.Drawing.Point(252, 574)
      Me.cmdNum0.Name = "cmdNum0"
      Me.cmdNum0.Size = New System.Drawing.Size(54, 40)
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
      Me.cmdNum9.Location = New System.Drawing.Point(191, 574)
      Me.cmdNum9.Name = "cmdNum9"
      Me.cmdNum9.Size = New System.Drawing.Size(54, 40)
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
      Me.cmdNum8.Location = New System.Drawing.Point(130, 574)
      Me.cmdNum8.Name = "cmdNum8"
      Me.cmdNum8.Size = New System.Drawing.Size(54, 40)
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
      Me.cmdOk.Location = New System.Drawing.Point(433, 574)
      Me.cmdOk.Name = "cmdOk"
      Me.cmdOk.Size = New System.Drawing.Size(108, 40)
      Me.cmdOk.TabIndex = 24
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
      Me.txtCodice.Location = New System.Drawing.Point(373, 526)
      Me.txtCodice.Name = "txtCodice"
      Me.txtCodice.Size = New System.Drawing.Size(168, 40)
      Me.txtCodice.TabIndex = 20
      Me.txtCodice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmdVariazioniMeno
      '
      Me.cmdVariazioniMeno.BackColor = System.Drawing.Color.LightCoral
      Me.cmdVariazioniMeno.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdVariazioniMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdVariazioniMeno.ForeColor = System.Drawing.Color.White
      Me.cmdVariazioniMeno.Location = New System.Drawing.Point(536, 584)
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
      Me.cmdVariazioniPiù.Location = New System.Drawing.Point(464, 584)
      Me.cmdVariazioniPiù.Name = "cmdVariazioniPiù"
      Me.cmdVariazioniPiù.Size = New System.Drawing.Size(64, 40)
      Me.cmdVariazioniPiù.TabIndex = 6
      Me.cmdVariazioniPiù.Text = "+"
      Me.cmdVariazioniPiù.UseVisualStyleBackColor = False
      Me.cmdVariazioniPiù.Visible = False
      '
      'cmdQuantitàMeno
      '
      Me.cmdQuantitàMeno.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdQuantitàMeno.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdQuantitàMeno.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdQuantitàMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdQuantitàMeno.ForeColor = System.Drawing.Color.White
      Me.cmdQuantitàMeno.Location = New System.Drawing.Point(694, 427)
      Me.cmdQuantitàMeno.Name = "cmdQuantitàMeno"
      Me.cmdQuantitàMeno.Size = New System.Drawing.Size(72, 40)
      Me.cmdQuantitàMeno.TabIndex = 33
      Me.cmdQuantitàMeno.Text = "&-1"
      Me.cmdQuantitàMeno.UseVisualStyleBackColor = False
      '
      'cmdQuantitaPiù
      '
      Me.cmdQuantitaPiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdQuantitaPiù.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdQuantitaPiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdQuantitaPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdQuantitaPiù.ForeColor = System.Drawing.Color.White
      Me.cmdQuantitaPiù.Location = New System.Drawing.Point(774, 427)
      Me.cmdQuantitaPiù.Name = "cmdQuantitaPiù"
      Me.cmdQuantitaPiù.Size = New System.Drawing.Size(72, 40)
      Me.cmdQuantitaPiù.TabIndex = 34
      Me.cmdQuantitaPiù.Text = "&+1"
      Me.cmdQuantitaPiù.UseVisualStyleBackColor = False
      '
      'cmdEscludiStampa
      '
      Me.cmdEscludiStampa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdEscludiStampa.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdEscludiStampa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEscludiStampa.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEscludiStampa.ForeColor = System.Drawing.Color.White
      Me.cmdEscludiStampa.Location = New System.Drawing.Point(694, 475)
      Me.cmdEscludiStampa.Name = "cmdEscludiStampa"
      Me.cmdEscludiStampa.Size = New System.Drawing.Size(152, 40)
      Me.cmdEscludiStampa.TabIndex = 37
      Me.cmdEscludiStampa.Text = "E&SCLUDI"
      Me.cmdEscludiStampa.UseVisualStyleBackColor = False
      '
      'cmdCancella
      '
      Me.cmdCancella.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancella.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdCancella.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCancella.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCancella.ForeColor = System.Drawing.Color.White
      Me.cmdCancella.Location = New System.Drawing.Point(854, 427)
      Me.cmdCancella.Name = "cmdCancella"
      Me.cmdCancella.Size = New System.Drawing.Size(72, 40)
      Me.cmdCancella.TabIndex = 35
      Me.cmdCancella.Text = "Canc"
      Me.cmdCancella.UseVisualStyleBackColor = False
      '
      'cmdDettagliSu
      '
      Me.cmdDettagliSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliSu.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliSu.Image = CType(resources.GetObject("cmdDettagliSu.Image"), System.Drawing.Image)
      Me.cmdDettagliSu.Location = New System.Drawing.Point(854, 379)
      Me.cmdDettagliSu.Name = "cmdDettagliSu"
      Me.cmdDettagliSu.Size = New System.Drawing.Size(152, 40)
      Me.cmdDettagliSu.TabIndex = 32
      Me.cmdDettagliSu.UseVisualStyleBackColor = False
      '
      'cmdDettagliGiù
      '
      Me.cmdDettagliGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliGiù.Image = CType(resources.GetObject("cmdDettagliGiù.Image"), System.Drawing.Image)
      Me.cmdDettagliGiù.Location = New System.Drawing.Point(694, 379)
      Me.cmdDettagliGiù.Name = "cmdDettagliGiù"
      Me.cmdDettagliGiù.Size = New System.Drawing.Size(152, 40)
      Me.cmdDettagliGiù.TabIndex = 31
      Me.cmdDettagliGiù.UseVisualStyleBackColor = False
      '
      'Label1
      '
      Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(701, 11)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(128, 31)
      Me.Label1.TabIndex = 69
      Me.Label1.Text = "LISTINO"
      '
      'cmdListino4
      '
      Me.cmdListino4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdListino4.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdListino4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdListino4.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdListino4.ForeColor = System.Drawing.Color.White
      Me.cmdListino4.Location = New System.Drawing.Point(965, 8)
      Me.cmdListino4.Name = "cmdListino4"
      Me.cmdListino4.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino4.TabIndex = 29
      Me.cmdListino4.Text = "4"
      Me.cmdListino4.UseVisualStyleBackColor = False
      '
      'cmdListino3
      '
      Me.cmdListino3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdListino3.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdListino3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdListino3.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdListino3.ForeColor = System.Drawing.Color.White
      Me.cmdListino3.Location = New System.Drawing.Point(923, 8)
      Me.cmdListino3.Name = "cmdListino3"
      Me.cmdListino3.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino3.TabIndex = 28
      Me.cmdListino3.Text = "3"
      Me.cmdListino3.UseVisualStyleBackColor = False
      '
      'cmdListino2
      '
      Me.cmdListino2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdListino2.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdListino2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdListino2.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdListino2.ForeColor = System.Drawing.Color.White
      Me.cmdListino2.Location = New System.Drawing.Point(881, 8)
      Me.cmdListino2.Name = "cmdListino2"
      Me.cmdListino2.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino2.TabIndex = 27
      Me.cmdListino2.Text = "2"
      Me.cmdListino2.UseVisualStyleBackColor = False
      '
      'cmdListino1
      '
      Me.cmdListino1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdListino1.BackColor = System.Drawing.Color.LightCoral
      Me.cmdListino1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdListino1.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdListino1.ForeColor = System.Drawing.Color.White
      Me.cmdListino1.Location = New System.Drawing.Point(839, 8)
      Me.cmdListino1.Name = "cmdListino1"
      Me.cmdListino1.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino1.TabIndex = 26
      Me.cmdListino1.Text = "1"
      Me.cmdListino1.UseVisualStyleBackColor = False
      '
      'lblTotale
      '
      Me.lblTotale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotale.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotale.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblTotale.Location = New System.Drawing.Point(773, 56)
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
      Me.pnlPiatti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlPiatti.Location = New System.Drawing.Point(152, 8)
      Me.pnlPiatti.Name = "pnlPiatti"
      Me.pnlPiatti.Size = New System.Drawing.Size(314, 464)
      Me.pnlPiatti.TabIndex = 3
      '
      'pnlVariazioni
      '
      Me.pnlVariazioni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlVariazioni.Location = New System.Drawing.Point(472, 8)
      Me.pnlVariazioni.Name = "pnlVariazioni"
      Me.pnlVariazioni.Size = New System.Drawing.Size(130, 464)
      Me.pnlVariazioni.TabIndex = 6
      '
      'cmdEsci
      '
      Me.cmdEsci.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdEsci.BackColor = System.Drawing.Color.LightCoral
      Me.cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdEsci.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEsci.ForeColor = System.Drawing.Color.White
      Me.cmdEsci.Location = New System.Drawing.Point(854, 571)
      Me.cmdEsci.Name = "cmdEsci"
      Me.cmdEsci.Size = New System.Drawing.Size(152, 40)
      Me.cmdEsci.TabIndex = 42
      Me.cmdEsci.Text = "&ESCI"
      Me.cmdEsci.UseVisualStyleBackColor = False
      '
      'cmdConto
      '
      Me.cmdConto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdConto.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdConto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdConto.ForeColor = System.Drawing.Color.White
      Me.cmdConto.Location = New System.Drawing.Point(694, 571)
      Me.cmdConto.Name = "cmdConto"
      Me.cmdConto.Size = New System.Drawing.Size(152, 40)
      Me.cmdConto.TabIndex = 41
      Me.cmdConto.Text = "&CONTO"
      Me.cmdConto.UseVisualStyleBackColor = False
      '
      'pnlCategoria
      '
      Me.pnlCategoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlCategoria.Location = New System.Drawing.Point(8, 8)
      Me.pnlCategoria.Name = "pnlCategoria"
      Me.pnlCategoria.Size = New System.Drawing.Size(138, 464)
      Me.pnlCategoria.TabIndex = 0
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.BackColor = System.Drawing.Color.White
      Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(693, 168)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(312, 32)
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
      Me.lblData.Location = New System.Drawing.Point(709, 114)
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
      Me.lblOra.Location = New System.Drawing.Point(749, 136)
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
      Me.lstvDettagli.Location = New System.Drawing.Point(693, 192)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(312, 182)
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
      Me.cmdCancTutto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancTutto.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdCancTutto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCancTutto.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCancTutto.ForeColor = System.Drawing.Color.White
      Me.cmdCancTutto.Location = New System.Drawing.Point(934, 427)
      Me.cmdCancTutto.Name = "cmdCancTutto"
      Me.cmdCancTutto.Size = New System.Drawing.Size(72, 40)
      Me.cmdCancTutto.TabIndex = 36
      Me.cmdCancTutto.Text = "&X"
      Me.cmdCancTutto.UseVisualStyleBackColor = False
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label2.Location = New System.Drawing.Point(693, 56)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(312, 112)
      Me.Label2.TabIndex = 81
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label6.Location = New System.Drawing.Point(709, 56)
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
      Me.Label7.Location = New System.Drawing.Point(853, 136)
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
      Me.lblQuantità.Location = New System.Drawing.Point(941, 136)
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
      Me.Label4.Location = New System.Drawing.Point(709, 136)
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
      Me.dtpData.Location = New System.Drawing.Point(-158, 930)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(200, 20)
      Me.dtpData.TabIndex = 86
      '
      'cmdConferma
      '
      Me.cmdConferma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdConferma.BackColor = System.Drawing.Color.Gray
      Me.cmdConferma.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdConferma.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdConferma.ForeColor = System.Drawing.Color.White
      Me.cmdConferma.Location = New System.Drawing.Point(854, 475)
      Me.cmdConferma.Name = "cmdConferma"
      Me.cmdConferma.Size = New System.Drawing.Size(152, 40)
      Me.cmdConferma.TabIndex = 38
      Me.cmdConferma.Text = "C&ONFERMA"
      Me.cmdConferma.UseVisualStyleBackColor = False
      '
      'cmdProforma
      '
      Me.cmdProforma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdProforma.BackColor = System.Drawing.Color.Silver
      Me.cmdProforma.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdProforma.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdProforma.ForeColor = System.Drawing.Color.White
      Me.cmdProforma.Location = New System.Drawing.Point(694, 523)
      Me.cmdProforma.Name = "cmdProforma"
      Me.cmdProforma.Size = New System.Drawing.Size(152, 40)
      Me.cmdProforma.TabIndex = 39
      Me.cmdProforma.Text = "&PROFORMA"
      Me.cmdProforma.UseVisualStyleBackColor = False
      '
      'cmdScontrino
      '
      Me.cmdScontrino.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdScontrino.BackColor = System.Drawing.Color.LightSalmon
      Me.cmdScontrino.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdScontrino.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdScontrino.ForeColor = System.Drawing.Color.White
      Me.cmdScontrino.Location = New System.Drawing.Point(854, 523)
      Me.cmdScontrino.Name = "cmdScontrino"
      Me.cmdScontrino.Size = New System.Drawing.Size(152, 40)
      Me.cmdScontrino.TabIndex = 40
      Me.cmdScontrino.Text = "SCONTRINO"
      Me.cmdScontrino.UseVisualStyleBackColor = False
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
      Me.lstMessaggi.Location = New System.Drawing.Point(8, 616)
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
      Me.cmdModalità.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdModalità.BackColor = System.Drawing.Color.White
      Me.cmdModalità.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdModalità.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdModalità.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdModalità.Location = New System.Drawing.Point(312, 526)
      Me.cmdModalità.Name = "cmdModalità"
      Me.cmdModalità.Size = New System.Drawing.Size(54, 40)
      Me.cmdModalità.TabIndex = 19
      Me.cmdModalità.Text = "€"
      Me.cmdModalità.UseVisualStyleBackColor = False
      '
      'cmdNum00
      '
      Me.cmdNum00.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdNum00.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum00.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum00.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum00.ForeColor = System.Drawing.Color.White
      Me.cmdNum00.Location = New System.Drawing.Point(373, 574)
      Me.cmdNum00.Name = "cmdNum00"
      Me.cmdNum00.Size = New System.Drawing.Size(54, 40)
      Me.cmdNum00.TabIndex = 23
      Me.cmdNum00.Text = "00"
      Me.cmdNum00.UseVisualStyleBackColor = False
      '
      'cmdVirgola
      '
      Me.cmdVirgola.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdVirgola.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdVirgola.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdVirgola.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdVirgola.ForeColor = System.Drawing.Color.White
      Me.cmdVirgola.Location = New System.Drawing.Point(312, 574)
      Me.cmdVirgola.Name = "cmdVirgola"
      Me.cmdVirgola.Size = New System.Drawing.Size(54, 40)
      Me.cmdVirgola.TabIndex = 22
      Me.cmdVirgola.Text = ","
      Me.cmdVirgola.UseVisualStyleBackColor = False
      '
      'cmdC
      '
      Me.cmdC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdC.BackColor = System.Drawing.Color.LightCoral
      Me.cmdC.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdC.ForeColor = System.Drawing.Color.White
      Me.cmdC.Location = New System.Drawing.Point(548, 574)
      Me.cmdC.Name = "cmdC"
      Me.cmdC.Size = New System.Drawing.Size(54, 40)
      Me.cmdC.TabIndex = 25
      Me.cmdC.Text = "C"
      Me.cmdC.UseVisualStyleBackColor = False
      '
      'cmdX
      '
      Me.cmdX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdX.BackColor = System.Drawing.Color.LightSalmon
      Me.cmdX.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdX.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdX.ForeColor = System.Drawing.Color.White
      Me.cmdX.Location = New System.Drawing.Point(548, 526)
      Me.cmdX.Name = "cmdX"
      Me.cmdX.Size = New System.Drawing.Size(54, 40)
      Me.cmdX.TabIndex = 21
      Me.cmdX.Text = "X"
      Me.cmdX.UseVisualStyleBackColor = False
      '
      'frmPos
      '
      Me.AcceptButton = Me.cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdEsci
      Me.ClientSize = New System.Drawing.Size(1013, 644)
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
            LeggiPercorsiComanda(10, percorsiStampa.Stampante) <> "<Nessuna>" Then

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

         If nomeStampante <> String.Empty And nomeStampante <> "<Nessuna>" Then
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

      If VerificaPiattiEsauriti(Convert.ToInt32(CType(sender, Button).Name)) = False Then
         SelezionaPiatto(CType(sender, Button).Name)
      Else
         MessageBox.Show("Il piatto selezionato è esaurito!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If
   End Sub

   Private Sub Variazioni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      If VerificaPiattiEsauriti(Convert.ToInt32(CType(sender, Button).Name)) = False Then
         SelezionaPiatto(CType(sender, Button).Name)
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
