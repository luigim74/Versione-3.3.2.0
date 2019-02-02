' Nome form:            POS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/04/2006
' Data ultima modifica: 07/12/2015
' Descrizione:          Interfaccia Punto cassa - conto immediato.

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
   Const TAB_DOCUMENTI As String = "Documenti"
   Const TAB_POS_IMPOSTAZIONI_PIATTI As String = "POS_ImpostazioniPiatti"

   Const TIPO_DOC_PF As String = "Proforma"

   Const LARGHEZZA_CATEGORIA As Integer = 82
   Public ALTEZZA_CATEGORIA As Integer = 50
   Public LARGHEZZA_PIATTO As Integer = 50
   Public ALTEZZA_PIATTO As Integer = 50
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
   Public CausaleMovMag As String = "Vendita"
   Public idTavolo As Integer
   Public nomeTavolo As String
   Private infoTitolo As String
   Private ComandeEsistenti As Boolean = False
   Private nomeTavoloDoc As String
   Private nomeCameriereDoc As String
   Public numeroContoDoc As String
   Public tipoDocumento As String
   Public totContoCamera As String

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
   Private op1 As Double = 0
   Private op2 As Double = 0

   Public confermaModifiche As Boolean

   ' Utilizzata per le varianti.
   Private segnoVariante As String = "+"

   Private controlloAttivo As Control

   Dim percorsoRep As String = PERCORSO_REP_COMANDA_REPARTI
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents netBtn_CancellaTutto As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Cancella As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_QuantitàMeno As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_QuantitàPiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Escludi As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Conferma As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Impostazioni As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Conto As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Esci As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_C As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_9 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_8 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_7 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Prezzo As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Ok As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Percentuale As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_X As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_00 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_0 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Virgola As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_3 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_2 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_1 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_6 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_5 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_4 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Listino As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Reparto As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Modifica As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton31 As Softgroup.NetButton.NetButton
   Friend WithEvents NavigationBarGroupItemsContainer1 As Elegant.Ui.NavigationBarGroupItemsContainer
   Friend WithEvents NavigationBarItem1 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NavigationBarItem2 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NavigationBarItem3 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NavigationBarItem4 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NavigationBarGroupItemsContainer2 As Elegant.Ui.NavigationBarGroupItemsContainer
   Friend WithEvents NavigationBarItem5 As Elegant.Ui.NavigationBarItem
   Friend WithEvents netBtn_PiattiSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_PiattiGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_VarianteSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_VarianteGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_CategoriaSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_CategoriaGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_VariantePiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_SottoCategoria As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Tastiera As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Codice As Softgroup.NetButton.NetButton
   Friend WithEvents NetButton1 As NetButton
   Friend WithEvents netBtn_Messaggi As NetButton
   Friend WithEvents netBtn_VarianteMeno As NetButton
   Friend WithEvents netBtn_Offerto As NetButton
   Friend WithEvents Offerto As ColumnHeader
   Friend WithEvents IdComanda As ColumnHeader
   Friend WithEvents eui_txtPrezzo As Elegant.Ui.TextBox
   Friend WithEvents eui_txtCodice As Elegant.Ui.TextBox
   Friend WithEvents eui_cmdOk As Elegant.Ui.Button
   Friend WithEvents netBtn_ListaPiattiSu As NetButton
   Friend WithEvents netBtn_ListaPiattiGiù As NetButton
   Friend WithEvents netBtn_ContiParcheggiati As NetButton
   Friend WithEvents AliquotaIva As ColumnHeader
   Friend WithEvents ColumnHeader1 As ColumnHeader
   Public NumListino As Short

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

      Select Case tavolo
         Case String.Empty
            ' Conto Immediato.
            idTavolo = Nothing
            nomeTavolo = String.Empty
            nomeTavoloDoc = "Conto Imm."
            nomeCameriereDoc = "Cassa"
            infoTitolo = "Visual POS - CONTO IMMEDIATO"

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_PUNTO_CASSA, MODULO_GESTIONE_POS)

         Case "Tavoli"
            ' Conto Immediato aperto dalla Gestione Tavoli.
            idTavolo = Nothing
            nomeTavolo = tavolo
            nomeTavoloDoc = "Conto Imm."
            nomeCameriereDoc = "Cassa"
            infoTitolo = "Visual POS - CONTO IMMEDIATO"

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_PUNTO_CASSA, MODULO_GESTIONE_POS)

         Case "Asporto"
            ' Gestione Asporto.
            idTavolo = codiceTavolo
            nomeTavolo = "Asporto"
            nomeTavoloDoc = "Asporto"
            nomeCameriereDoc = "Cassa"
            infoTitolo = "Visual POS - ASPORTO"

            ' Disattiva il pulsante.
            netBtn_ContiParcheggiati.Enabled = False

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.ApriAsporto, String.Empty, MODULO_TAVOLI)

         Case "Hotel"
            ' Conto Immediato.
            idTavolo = codiceTavolo
            nomeTavolo = tavolo
            nomeTavoloDoc = "Conto Imm."
            nomeCameriereDoc = "Cassa"
            totContoCamera = oraOcc
            infoTitolo = "Visual POS - CONTO IMMEDIATO"
            netBtn_ContiParcheggiati.Enabled = False
            netBtn_Conferma.Enabled = False

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_PUNTO_CASSA, MODULO_GESTIONE_POS)

         Case Else
            ' Tavolo.
            idTavolo = codiceTavolo
            nomeTavolo = tavolo
            nomeTavoloDoc = tavolo
            nomeCameriereDoc = cameriere
            infoTitolo = "Visual POS - TAVOLO: " & tavolo & "  - ORA OCCUPAZIONE: " & oraOcc & " - CAMERIERE: " & cameriere

            ' Disattiva il pulsante.
            netBtn_ContiParcheggiati.Enabled = False

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.ApriTavolo, "(" & tavolo & ")", MODULO_TAVOLI)

      End Select

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
   Friend WithEvents lblTotale As System.Windows.Forms.Label
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents Quantità As System.Windows.Forms.ColumnHeader
   Friend WithEvents Descrizione As System.Windows.Forms.ColumnHeader
   Friend WithEvents Importo As System.Windows.Forms.ColumnHeader
   Friend WithEvents Id As System.Windows.Forms.ColumnHeader
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents lblQuantità As System.Windows.Forms.Label
   Friend WithEvents lblData As System.Windows.Forms.Label
   Friend WithEvents lblOra As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Friend WithEvents Prezzo As System.Windows.Forms.ColumnHeader
   Friend WithEvents IdPiatto As System.Windows.Forms.ColumnHeader
   Friend WithEvents Categoria As System.Windows.Forms.ColumnHeader
   Friend WithEvents Reparto As System.Windows.Forms.ColumnHeader
   Friend WithEvents Inviata As System.Windows.Forms.ColumnHeader
   Friend WithEvents Escludi As System.Windows.Forms.ColumnHeader
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents lstMessaggi As System.Windows.Forms.ListBox
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmPos))
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
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
      Me.pnlCategoria = New System.Windows.Forms.Panel()
      Me.lblData = New System.Windows.Forms.Label()
      Me.lblOra = New System.Windows.Forms.Label()
      Me.lstvDettagli = New System.Windows.Forms.ListView()
      Me.Id = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Quantità = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Descrizione = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Importo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Prezzo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.IdPiatto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Categoria = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Reparto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Inviata = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Escludi = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Offerto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.IdComanda = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.AliquotaIva = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.lblQuantità = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.lstMessaggi = New System.Windows.Forms.ListBox()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.netBtn_Esci = New Softgroup.NetButton.NetButton()
      Me.netBtn_Conto = New Softgroup.NetButton.NetButton()
      Me.netBtn_Impostazioni = New Softgroup.NetButton.NetButton()
      Me.netBtn_Escludi = New Softgroup.NetButton.NetButton()
      Me.netBtn_Conferma = New Softgroup.NetButton.NetButton()
      Me.netBtn_QuantitàPiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_QuantitàMeno = New Softgroup.NetButton.NetButton()
      Me.netBtn_Cancella = New Softgroup.NetButton.NetButton()
      Me.netBtn_CancellaTutto = New Softgroup.NetButton.NetButton()
      Me.netBtn_4 = New Softgroup.NetButton.NetButton()
      Me.netBtn_5 = New Softgroup.NetButton.NetButton()
      Me.netBtn_6 = New Softgroup.NetButton.NetButton()
      Me.netBtn_1 = New Softgroup.NetButton.NetButton()
      Me.netBtn_2 = New Softgroup.NetButton.NetButton()
      Me.netBtn_3 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Virgola = New Softgroup.NetButton.NetButton()
      Me.netBtn_0 = New Softgroup.NetButton.NetButton()
      Me.netBtn_00 = New Softgroup.NetButton.NetButton()
      Me.netBtn_X = New Softgroup.NetButton.NetButton()
      Me.netBtn_Percentuale = New Softgroup.NetButton.NetButton()
      Me.netBtn_Ok = New Softgroup.NetButton.NetButton()
      Me.netBtn_Prezzo = New Softgroup.NetButton.NetButton()
      Me.netBtn_C = New Softgroup.NetButton.NetButton()
      Me.netBtn_9 = New Softgroup.NetButton.NetButton()
      Me.netBtn_8 = New Softgroup.NetButton.NetButton()
      Me.netBtn_7 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Reparto = New Softgroup.NetButton.NetButton()
      Me.netBtn_Listino = New Softgroup.NetButton.NetButton()
      Me.netBtn_Modifica = New Softgroup.NetButton.NetButton()
      Me.NetButton31 = New Softgroup.NetButton.NetButton()
      Me.NavigationBarGroupItemsContainer1 = New Elegant.Ui.NavigationBarGroupItemsContainer()
      Me.NavigationBarItem1 = New Elegant.Ui.NavigationBarItem()
      Me.NavigationBarItem2 = New Elegant.Ui.NavigationBarItem()
      Me.NavigationBarItem3 = New Elegant.Ui.NavigationBarItem()
      Me.NavigationBarItem4 = New Elegant.Ui.NavigationBarItem()
      Me.NavigationBarGroupItemsContainer2 = New Elegant.Ui.NavigationBarGroupItemsContainer()
      Me.NavigationBarItem5 = New Elegant.Ui.NavigationBarItem()
      Me.netBtn_CategoriaGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_CategoriaSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_VarianteSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_VarianteGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_PiattiSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_PiattiGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_SottoCategoria = New Softgroup.NetButton.NetButton()
      Me.netBtn_VariantePiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_Tastiera = New Softgroup.NetButton.NetButton()
      Me.netBtn_Codice = New Softgroup.NetButton.NetButton()
      Me.NetButton1 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Messaggi = New Softgroup.NetButton.NetButton()
      Me.netBtn_VarianteMeno = New Softgroup.NetButton.NetButton()
      Me.netBtn_Offerto = New Softgroup.NetButton.NetButton()
      Me.eui_txtPrezzo = New Elegant.Ui.TextBox()
      Me.eui_txtCodice = New Elegant.Ui.TextBox()
      Me.eui_cmdOk = New Elegant.Ui.Button()
      Me.netBtn_ListaPiattiSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_ListaPiattiGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_ContiParcheggiati = New Softgroup.NetButton.NetButton()
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
      'lblTotale
      '
      Me.lblTotale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTotale.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblTotale.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTotale.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblTotale.Location = New System.Drawing.Point(911, 0)
      Me.lblTotale.Name = "lblTotale"
      Me.lblTotale.Size = New System.Drawing.Size(247, 56)
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
      Me.pnlPiatti.Location = New System.Drawing.Point(149, 5)
      Me.pnlPiatti.Name = "pnlPiatti"
      Me.pnlPiatti.Size = New System.Drawing.Size(399, 607)
      Me.pnlPiatti.TabIndex = 3
      '
      'pnlVariazioni
      '
      Me.pnlVariazioni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlVariazioni.Location = New System.Drawing.Point(551, 64)
      Me.pnlVariazioni.Name = "pnlVariazioni"
      Me.pnlVariazioni.Size = New System.Drawing.Size(138, 548)
      Me.pnlVariazioni.TabIndex = 6
      '
      'pnlCategoria
      '
      Me.pnlCategoria.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlCategoria.Location = New System.Drawing.Point(8, 5)
      Me.pnlCategoria.Name = "pnlCategoria"
      Me.pnlCategoria.Size = New System.Drawing.Size(138, 607)
      Me.pnlCategoria.TabIndex = 0
      '
      'lblData
      '
      Me.lblData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblData.AutoSize = True
      Me.lblData.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblData.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblData.Location = New System.Drawing.Point(854, 58)
      Me.lblData.Name = "lblData"
      Me.lblData.Size = New System.Drawing.Size(17, 16)
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
      Me.lblOra.Location = New System.Drawing.Point(895, 80)
      Me.lblOra.Name = "lblOra"
      Me.lblOra.Size = New System.Drawing.Size(69, 24)
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
      Me.lstvDettagli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.Id, Me.Quantità, Me.Descrizione, Me.Importo, Me.Prezzo, Me.IdPiatto, Me.Categoria, Me.Reparto, Me.Inviata, Me.Escludi, Me.Offerto, Me.IdComanda, Me.AliquotaIva, Me.ColumnHeader1})
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me.lstvDettagli.Location = New System.Drawing.Point(836, 113)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(337, 269)
      Me.lstvDettagli.TabIndex = 25
      Me.lstvDettagli.UseCompatibleStateImageBehavior = False
      Me.lstvDettagli.View = System.Windows.Forms.View.Details
      '
      'Id
      '
      Me.Id.Width = 0
      '
      'Quantità
      '
      Me.Quantità.Text = "Q.tà"
      Me.Quantità.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Descrizione
      '
      Me.Descrizione.Text = "Descrizione"
      Me.Descrizione.Width = 190
      '
      'Importo
      '
      Me.Importo.Text = "Importo"
      Me.Importo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.Importo.Width = 65
      '
      'Prezzo
      '
      Me.Prezzo.Text = "Prezzo"
      Me.Prezzo.Width = 0
      '
      'IdPiatto
      '
      Me.IdPiatto.Width = 0
      '
      'Categoria
      '
      Me.Categoria.Width = 0
      '
      'Reparto
      '
      Me.Reparto.Width = 0
      '
      'Inviata
      '
      Me.Inviata.Width = 0
      '
      'Escludi
      '
      Me.Escludi.Width = 0
      '
      'Offerto
      '
      Me.Offerto.Width = 0
      '
      'IdComanda
      '
      Me.IdComanda.Width = 0
      '
      'AliquotaIva
      '
      Me.AliquotaIva.Text = "Iva"
      Me.AliquotaIva.Width = 0
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Width = 0
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label2.Location = New System.Drawing.Point(836, 0)
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
      Me.Label6.Location = New System.Drawing.Point(855, 0)
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
      Me.Label7.Location = New System.Drawing.Point(982, 80)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(89, 24)
      Me.Label7.TabIndex = 83
      Me.Label7.Text = "Totale Q.tà:"
      Me.Label7.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'lblQuantità
      '
      Me.lblQuantità.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblQuantità.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblQuantità.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblQuantità.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblQuantità.Location = New System.Drawing.Point(1077, 80)
      Me.lblQuantità.Name = "lblQuantità"
      Me.lblQuantità.Size = New System.Drawing.Size(73, 24)
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
      Me.Label4.Location = New System.Drawing.Point(855, 80)
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
      Me.dtpData.Location = New System.Drawing.Point(-77, 1038)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(200, 20)
      Me.dtpData.TabIndex = 86
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
      Me.lstMessaggi.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstMessaggi.Location = New System.Drawing.Point(741, 717)
      Me.lstMessaggi.Name = "lstMessaggi"
      Me.lstMessaggi.Size = New System.Drawing.Size(85, 17)
      Me.lstMessaggi.TabIndex = 87
      Me.lstMessaggi.Visible = False
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'netBtn_Esci
      '
      Me.netBtn_Esci.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Esci.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.netBtn_Esci.ColorDisabled = System.Drawing.Color.Brown
      Me.netBtn_Esci.ColorLight = System.Drawing.Color.MistyRose
      Me.netBtn_Esci.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Red
      Me.netBtn_Esci.ColorText = System.Drawing.Color.Black
      Me.netBtn_Esci.ColorTop = System.Drawing.Color.White
      Me.netBtn_Esci.CornerRadius = 2
      Me.netBtn_Esci.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Esci.Location = New System.Drawing.Point(621, 677)
      Me.netBtn_Esci.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Esci.Name = "netBtn_Esci"
      Me.netBtn_Esci.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_Esci.TabIndex = 13
      Me.netBtn_Esci.TextButton = "Esci"
      '
      'netBtn_Conto
      '
      Me.netBtn_Conto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Conto.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(40, Byte), Integer))
      Me.netBtn_Conto.ColorDisabled = System.Drawing.Color.SeaGreen
      Me.netBtn_Conto.ColorLight = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(189, Byte), Integer))
      Me.netBtn_Conto.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Green
      Me.netBtn_Conto.ColorText = System.Drawing.Color.Black
      Me.netBtn_Conto.ColorTop = System.Drawing.Color.White
      Me.netBtn_Conto.CornerRadius = 2
      Me.netBtn_Conto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Conto.Location = New System.Drawing.Point(480, 677)
      Me.netBtn_Conto.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Conto.Name = "netBtn_Conto"
      Me.netBtn_Conto.Size = New System.Drawing.Size(139, 56)
      Me.netBtn_Conto.TabIndex = 12
      Me.netBtn_Conto.TextButton = "Conto"
      '
      'netBtn_Impostazioni
      '
      Me.netBtn_Impostazioni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Impostazioni.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Impostazioni.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Impostazioni.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Impostazioni.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Impostazioni.ColorText = System.Drawing.Color.White
      Me.netBtn_Impostazioni.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Impostazioni.CornerRadius = 2
      Me.netBtn_Impostazioni.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Impostazioni.Location = New System.Drawing.Point(78, 677)
      Me.netBtn_Impostazioni.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Impostazioni.Name = "netBtn_Impostazioni"
      Me.netBtn_Impostazioni.Size = New System.Drawing.Size(115, 56)
      Me.netBtn_Impostazioni.TabIndex = 10
      Me.netBtn_Impostazioni.TextButton = "Impostazioni"
      '
      'netBtn_Escludi
      '
      Me.netBtn_Escludi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Escludi.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Escludi.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Escludi.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Escludi.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Escludi.ColorText = System.Drawing.Color.White
      Me.netBtn_Escludi.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Escludi.CornerRadius = 2
      Me.netBtn_Escludi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Escludi.Location = New System.Drawing.Point(701, 233)
      Me.netBtn_Escludi.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Escludi.Name = "netBtn_Escludi"
      Me.netBtn_Escludi.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Escludi.TabIndex = 18
      Me.netBtn_Escludi.TextButton = "Escludi dal conto"
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
      Me.netBtn_Conferma.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Conferma.Location = New System.Drawing.Point(701, 518)
      Me.netBtn_Conferma.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Conferma.Name = "netBtn_Conferma"
      Me.netBtn_Conferma.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Conferma.TabIndex = 24
      Me.netBtn_Conferma.TextButton = "Conferma"
      '
      'netBtn_QuantitàPiù
      '
      Me.netBtn_QuantitàPiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_QuantitàPiù.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_QuantitàPiù.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_QuantitàPiù.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_QuantitàPiù.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_QuantitàPiù.ColorText = System.Drawing.Color.Black
      Me.netBtn_QuantitàPiù.ColorTop = System.Drawing.Color.White
      Me.netBtn_QuantitàPiù.CornerRadius = 2
      Me.netBtn_QuantitàPiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_QuantitàPiù.Location = New System.Drawing.Point(701, 347)
      Me.netBtn_QuantitàPiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_QuantitàPiù.Name = "netBtn_QuantitàPiù"
      Me.netBtn_QuantitàPiù.Size = New System.Drawing.Size(65, 56)
      Me.netBtn_QuantitàPiù.TabIndex = 20
      Me.netBtn_QuantitàPiù.TextButton = "+1"
      '
      'netBtn_QuantitàMeno
      '
      Me.netBtn_QuantitàMeno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_QuantitàMeno.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_QuantitàMeno.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_QuantitàMeno.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_QuantitàMeno.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_QuantitàMeno.ColorText = System.Drawing.Color.Black
      Me.netBtn_QuantitàMeno.ColorTop = System.Drawing.Color.White
      Me.netBtn_QuantitàMeno.CornerRadius = 2
      Me.netBtn_QuantitàMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_QuantitàMeno.Location = New System.Drawing.Point(766, 347)
      Me.netBtn_QuantitàMeno.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_QuantitàMeno.Name = "netBtn_QuantitàMeno"
      Me.netBtn_QuantitàMeno.Size = New System.Drawing.Size(65, 56)
      Me.netBtn_QuantitàMeno.TabIndex = 21
      Me.netBtn_QuantitàMeno.TextButton = "-1"
      '
      'netBtn_Cancella
      '
      Me.netBtn_Cancella.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Cancella.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Cancella.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Cancella.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Cancella.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Cancella.ColorText = System.Drawing.Color.White
      Me.netBtn_Cancella.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Cancella.CornerRadius = 2
      Me.netBtn_Cancella.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Cancella.Location = New System.Drawing.Point(701, 119)
      Me.netBtn_Cancella.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Cancella.Name = "netBtn_Cancella"
      Me.netBtn_Cancella.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Cancella.TabIndex = 16
      Me.netBtn_Cancella.TextButton = "Cancella"
      '
      'netBtn_CancellaTutto
      '
      Me.netBtn_CancellaTutto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_CancellaTutto.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_CancellaTutto.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_CancellaTutto.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_CancellaTutto.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_CancellaTutto.ColorText = System.Drawing.Color.White
      Me.netBtn_CancellaTutto.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_CancellaTutto.CornerRadius = 2
      Me.netBtn_CancellaTutto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_CancellaTutto.Location = New System.Drawing.Point(701, 176)
      Me.netBtn_CancellaTutto.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_CancellaTutto.Name = "netBtn_CancellaTutto"
      Me.netBtn_CancellaTutto.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_CancellaTutto.TabIndex = 17
      Me.netBtn_CancellaTutto.TextButton = "Cancella tutto"
      '
      'netBtn_4
      '
      Me.netBtn_4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_4.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_4.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_4.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_4.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_4.ColorText = System.Drawing.Color.Black
      Me.netBtn_4.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_4.CornerRadius = 2
      Me.netBtn_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_4.Location = New System.Drawing.Point(836, 578)
      Me.netBtn_4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_4.Name = "netBtn_4"
      Me.netBtn_4.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_4.TabIndex = 36
      Me.netBtn_4.TextButton = "4"
      '
      'netBtn_5
      '
      Me.netBtn_5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_5.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_5.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_5.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_5.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_5.ColorText = System.Drawing.Color.Black
      Me.netBtn_5.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_5.CornerRadius = 2
      Me.netBtn_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_5.Location = New System.Drawing.Point(917, 578)
      Me.netBtn_5.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_5.Name = "netBtn_5"
      Me.netBtn_5.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_5.TabIndex = 37
      Me.netBtn_5.TextButton = "5"
      '
      'netBtn_6
      '
      Me.netBtn_6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_6.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_6.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_6.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_6.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_6.ColorText = System.Drawing.Color.Black
      Me.netBtn_6.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_6.CornerRadius = 2
      Me.netBtn_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_6.Location = New System.Drawing.Point(998, 578)
      Me.netBtn_6.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_6.Name = "netBtn_6"
      Me.netBtn_6.Size = New System.Drawing.Size(78, 51)
      Me.netBtn_6.TabIndex = 38
      Me.netBtn_6.TextButton = "6"
      '
      'netBtn_1
      '
      Me.netBtn_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_1.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_1.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_1.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_1.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_1.ColorText = System.Drawing.Color.Black
      Me.netBtn_1.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_1.CornerRadius = 2
      Me.netBtn_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_1.Location = New System.Drawing.Point(836, 630)
      Me.netBtn_1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_1.Name = "netBtn_1"
      Me.netBtn_1.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_1.TabIndex = 40
      Me.netBtn_1.TextButton = "1"
      '
      'netBtn_2
      '
      Me.netBtn_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_2.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_2.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_2.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_2.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_2.ColorText = System.Drawing.Color.Black
      Me.netBtn_2.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_2.CornerRadius = 2
      Me.netBtn_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_2.Location = New System.Drawing.Point(917, 630)
      Me.netBtn_2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_2.Name = "netBtn_2"
      Me.netBtn_2.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_2.TabIndex = 41
      Me.netBtn_2.TextButton = "2"
      '
      'netBtn_3
      '
      Me.netBtn_3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_3.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_3.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_3.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_3.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_3.ColorText = System.Drawing.Color.Black
      Me.netBtn_3.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_3.CornerRadius = 2
      Me.netBtn_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_3.Location = New System.Drawing.Point(998, 630)
      Me.netBtn_3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_3.Name = "netBtn_3"
      Me.netBtn_3.Size = New System.Drawing.Size(78, 51)
      Me.netBtn_3.TabIndex = 42
      Me.netBtn_3.TextButton = "3"
      '
      'netBtn_Virgola
      '
      Me.netBtn_Virgola.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Virgola.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_Virgola.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_Virgola.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_Virgola.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_Virgola.ColorText = System.Drawing.Color.Black
      Me.netBtn_Virgola.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_Virgola.CornerRadius = 2
      Me.netBtn_Virgola.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Virgola.Location = New System.Drawing.Point(836, 682)
      Me.netBtn_Virgola.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Virgola.Name = "netBtn_Virgola"
      Me.netBtn_Virgola.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_Virgola.TabIndex = 44
      Me.netBtn_Virgola.TextButton = ","
      '
      'netBtn_0
      '
      Me.netBtn_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_0.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_0.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_0.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_0.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_0.ColorText = System.Drawing.Color.Black
      Me.netBtn_0.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_0.CornerRadius = 2
      Me.netBtn_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_0.Location = New System.Drawing.Point(917, 682)
      Me.netBtn_0.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_0.Name = "netBtn_0"
      Me.netBtn_0.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_0.TabIndex = 45
      Me.netBtn_0.TextButton = "0"
      '
      'netBtn_00
      '
      Me.netBtn_00.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_00.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_00.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_00.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_00.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_00.ColorText = System.Drawing.Color.Black
      Me.netBtn_00.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_00.CornerRadius = 2
      Me.netBtn_00.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_00.Location = New System.Drawing.Point(998, 682)
      Me.netBtn_00.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_00.Name = "netBtn_00"
      Me.netBtn_00.Size = New System.Drawing.Size(78, 51)
      Me.netBtn_00.TabIndex = 46
      Me.netBtn_00.TextButton = "00"
      '
      'netBtn_X
      '
      Me.netBtn_X.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_X.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_X.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_X.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_X.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_X.ColorText = System.Drawing.Color.Black
      Me.netBtn_X.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_X.CornerRadius = 2
      Me.netBtn_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_X.Location = New System.Drawing.Point(1077, 578)
      Me.netBtn_X.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_X.Name = "netBtn_X"
      Me.netBtn_X.Size = New System.Drawing.Size(95, 51)
      Me.netBtn_X.TabIndex = 39
      Me.netBtn_X.TextButton = "X"
      '
      'netBtn_Percentuale
      '
      Me.netBtn_Percentuale.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Percentuale.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_Percentuale.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_Percentuale.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Percentuale.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Percentuale.ColorText = System.Drawing.Color.Black
      Me.netBtn_Percentuale.ColorTop = System.Drawing.Color.White
      Me.netBtn_Percentuale.CornerRadius = 2
      Me.netBtn_Percentuale.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Percentuale.Location = New System.Drawing.Point(1077, 630)
      Me.netBtn_Percentuale.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Percentuale.Name = "netBtn_Percentuale"
      Me.netBtn_Percentuale.Size = New System.Drawing.Size(95, 51)
      Me.netBtn_Percentuale.TabIndex = 43
      Me.netBtn_Percentuale.TextButton = "%"
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
      Me.netBtn_Ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Ok.Location = New System.Drawing.Point(1077, 682)
      Me.netBtn_Ok.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Ok.Name = "netBtn_Ok"
      Me.netBtn_Ok.Size = New System.Drawing.Size(95, 51)
      Me.netBtn_Ok.TabIndex = 47
      Me.netBtn_Ok.TextButton = "OK"
      '
      'netBtn_Prezzo
      '
      Me.netBtn_Prezzo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Prezzo.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Prezzo.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Prezzo.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Prezzo.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Prezzo.ColorText = System.Drawing.Color.White
      Me.netBtn_Prezzo.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Prezzo.CornerRadius = 2
      Me.netBtn_Prezzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Prezzo.Location = New System.Drawing.Point(836, 484)
      Me.netBtn_Prezzo.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Prezzo.Name = "netBtn_Prezzo"
      Me.netBtn_Prezzo.Size = New System.Drawing.Size(80, 40)
      Me.netBtn_Prezzo.TabIndex = 30
      Me.netBtn_Prezzo.TextButton = "€"
      Me.netBtn_Prezzo.TextButtonAlign = System.Drawing.ContentAlignment.BottomCenter
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
      Me.netBtn_C.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_C.Location = New System.Drawing.Point(1077, 526)
      Me.netBtn_C.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_C.Name = "netBtn_C"
      Me.netBtn_C.Size = New System.Drawing.Size(95, 51)
      Me.netBtn_C.TabIndex = 35
      Me.netBtn_C.TextButton = "C"
      '
      'netBtn_9
      '
      Me.netBtn_9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_9.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_9.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_9.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_9.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_9.ColorText = System.Drawing.Color.Black
      Me.netBtn_9.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_9.CornerRadius = 2
      Me.netBtn_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_9.Location = New System.Drawing.Point(998, 526)
      Me.netBtn_9.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_9.Name = "netBtn_9"
      Me.netBtn_9.Size = New System.Drawing.Size(78, 51)
      Me.netBtn_9.TabIndex = 34
      Me.netBtn_9.TextButton = "9"
      '
      'netBtn_8
      '
      Me.netBtn_8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_8.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_8.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_8.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_8.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_8.ColorText = System.Drawing.Color.Black
      Me.netBtn_8.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_8.CornerRadius = 2
      Me.netBtn_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_8.Location = New System.Drawing.Point(917, 526)
      Me.netBtn_8.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_8.Name = "netBtn_8"
      Me.netBtn_8.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_8.TabIndex = 33
      Me.netBtn_8.TextButton = "8"
      '
      'netBtn_7
      '
      Me.netBtn_7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_7.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_7.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_7.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_7.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_7.ColorText = System.Drawing.Color.Black
      Me.netBtn_7.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_7.CornerRadius = 2
      Me.netBtn_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_7.Location = New System.Drawing.Point(836, 526)
      Me.netBtn_7.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_7.Name = "netBtn_7"
      Me.netBtn_7.Size = New System.Drawing.Size(80, 51)
      Me.netBtn_7.TabIndex = 32
      Me.netBtn_7.TextButton = "7"
      '
      'netBtn_Reparto
      '
      Me.netBtn_Reparto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Reparto.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Reparto.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Reparto.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Reparto.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Reparto.ColorText = System.Drawing.Color.White
      Me.netBtn_Reparto.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Reparto.CornerRadius = 2
      Me.netBtn_Reparto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Reparto.Location = New System.Drawing.Point(194, 677)
      Me.netBtn_Reparto.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Reparto.Name = "netBtn_Reparto"
      Me.netBtn_Reparto.Size = New System.Drawing.Size(115, 56)
      Me.netBtn_Reparto.TabIndex = 11
      Me.netBtn_Reparto.TextButton = "Reparto 2 (10%)"
      '
      'netBtn_Listino
      '
      Me.netBtn_Listino.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Listino.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Listino.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Listino.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Listino.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Listino.ColorText = System.Drawing.Color.White
      Me.netBtn_Listino.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Listino.CornerRadius = 2
      Me.netBtn_Listino.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Listino.Location = New System.Drawing.Point(701, 5)
      Me.netBtn_Listino.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Listino.Name = "netBtn_Listino"
      Me.netBtn_Listino.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Listino.TabIndex = 14
      Me.netBtn_Listino.TextButton = "Listino 1"
      '
      'netBtn_Modifica
      '
      Me.netBtn_Modifica.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Modifica.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_Modifica.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_Modifica.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Modifica.ColorText = System.Drawing.SystemColors.ControlText
      Me.netBtn_Modifica.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Modifica.CornerRadius = 2
      Me.netBtn_Modifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Modifica.Location = New System.Drawing.Point(701, 62)
      Me.netBtn_Modifica.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Modifica.Name = "netBtn_Modifica"
      Me.netBtn_Modifica.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Modifica.TabIndex = 15
      Me.netBtn_Modifica.TextButton = "Modifica"
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
      Me.netBtn_CategoriaGiù.Location = New System.Drawing.Point(8, 618)
      Me.netBtn_CategoriaGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_CategoriaGiù.Name = "netBtn_CategoriaGiù"
      Me.netBtn_CategoriaGiù.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_CategoriaGiù.TabIndex = 1
      Me.netBtn_CategoriaGiù.TextButton = ""
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
      Me.netBtn_CategoriaSu.Location = New System.Drawing.Point(78, 618)
      Me.netBtn_CategoriaSu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_CategoriaSu.Name = "netBtn_CategoriaSu"
      Me.netBtn_CategoriaSu.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_CategoriaSu.TabIndex = 2
      Me.netBtn_CategoriaSu.TextButton = ""
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
      Me.netBtn_VarianteSu.Location = New System.Drawing.Point(621, 618)
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
      Me.netBtn_VarianteGiù.Location = New System.Drawing.Point(551, 618)
      Me.netBtn_VarianteGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_VarianteGiù.Name = "netBtn_VarianteGiù"
      Me.netBtn_VarianteGiù.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_VarianteGiù.TabIndex = 7
      Me.netBtn_VarianteGiù.TextButton = ""
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
      Me.netBtn_PiattiSu.Location = New System.Drawing.Point(480, 618)
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
      Me.netBtn_PiattiGiù.Location = New System.Drawing.Point(149, 618)
      Me.netBtn_PiattiGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_PiattiGiù.Name = "netBtn_PiattiGiù"
      Me.netBtn_PiattiGiù.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_PiattiGiù.TabIndex = 4
      Me.netBtn_PiattiGiù.TextButton = ""
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
      Me.netBtn_SottoCategoria.Location = New System.Drawing.Point(218, 618)
      Me.netBtn_SottoCategoria.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_SottoCategoria.Name = "netBtn_SottoCategoria"
      Me.netBtn_SottoCategoria.Size = New System.Drawing.Size(261, 56)
      Me.netBtn_SottoCategoria.TabIndex = 309
      Me.netBtn_SottoCategoria.Tag = ""
      Me.netBtn_SottoCategoria.TextButton = ""
      '
      'netBtn_VariantePiù
      '
      Me.netBtn_VariantePiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_VariantePiù.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_VariantePiù.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_VariantePiù.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_VariantePiù.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_VariantePiù.ColorText = System.Drawing.Color.Black
      Me.netBtn_VariantePiù.ColorTop = System.Drawing.Color.White
      Me.netBtn_VariantePiù.CornerRadius = 2
      Me.netBtn_VariantePiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_VariantePiù.Location = New System.Drawing.Point(551, 5)
      Me.netBtn_VariantePiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_VariantePiù.Name = "netBtn_VariantePiù"
      Me.netBtn_VariantePiù.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_VariantePiù.TabIndex = 48
      Me.netBtn_VariantePiù.TextButton = "+"
      '
      'netBtn_Tastiera
      '
      Me.netBtn_Tastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
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
      Me.netBtn_Tastiera.Location = New System.Drawing.Point(8, 677)
      Me.netBtn_Tastiera.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Tastiera.Name = "netBtn_Tastiera"
      Me.netBtn_Tastiera.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_Tastiera.TabIndex = 9
      Me.netBtn_Tastiera.TextButton = ""
      '
      'netBtn_Codice
      '
      Me.netBtn_Codice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Codice.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Codice.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Codice.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Codice.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Codice.ColorText = System.Drawing.Color.White
      Me.netBtn_Codice.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Codice.CornerRadius = 2
      Me.netBtn_Codice.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Codice.Image = CType(resources.GetObject("netBtn_Codice.Image"), System.Drawing.Image)
      Me.netBtn_Codice.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_Codice.Location = New System.Drawing.Point(836, 442)
      Me.netBtn_Codice.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Codice.Name = "netBtn_Codice"
      Me.netBtn_Codice.Size = New System.Drawing.Size(80, 40)
      Me.netBtn_Codice.TabIndex = 28
      Me.netBtn_Codice.TextButton = ""
      Me.netBtn_Codice.TextButtonAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'NetButton1
      '
      Me.NetButton1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.NetButton1.ColorBottom = System.Drawing.Color.Black
      Me.NetButton1.ColorDisabled = System.Drawing.Color.DeepSkyBlue
      Me.NetButton1.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.NetButton1.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.NetButton1.ColorText = System.Drawing.Color.White
      Me.NetButton1.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.NetButton1.CornerRadius = 2
      Me.NetButton1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.NetButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.NetButton1.Location = New System.Drawing.Point(310, 677)
      Me.NetButton1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.NetButton1.Name = "NetButton1"
      Me.NetButton1.Size = New System.Drawing.Size(170, 56)
      Me.NetButton1.TabIndex = 316
      Me.NetButton1.Tag = ""
      Me.NetButton1.TextButton = ""
      '
      'netBtn_Messaggi
      '
      Me.netBtn_Messaggi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Messaggi.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Messaggi.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Messaggi.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Messaggi.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Messaggi.ColorText = System.Drawing.Color.White
      Me.netBtn_Messaggi.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Messaggi.CornerRadius = 2
      Me.netBtn_Messaggi.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Messaggi.Location = New System.Drawing.Point(701, 404)
      Me.netBtn_Messaggi.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Messaggi.Name = "netBtn_Messaggi"
      Me.netBtn_Messaggi.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Messaggi.TabIndex = 22
      Me.netBtn_Messaggi.TextButton = "Messaggi"
      '
      'netBtn_VarianteMeno
      '
      Me.netBtn_VarianteMeno.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_VarianteMeno.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_VarianteMeno.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_VarianteMeno.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_VarianteMeno.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_VarianteMeno.ColorText = System.Drawing.Color.White
      Me.netBtn_VarianteMeno.ColorTop = System.Drawing.Color.White
      Me.netBtn_VarianteMeno.CornerRadius = 2
      Me.netBtn_VarianteMeno.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_VarianteMeno.Location = New System.Drawing.Point(620, 5)
      Me.netBtn_VarianteMeno.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_VarianteMeno.Name = "netBtn_VarianteMeno"
      Me.netBtn_VarianteMeno.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_VarianteMeno.TabIndex = 49
      Me.netBtn_VarianteMeno.TextButton = "-"
      '
      'netBtn_Offerto
      '
      Me.netBtn_Offerto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Offerto.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Offerto.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Offerto.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Offerto.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Offerto.ColorText = System.Drawing.Color.White
      Me.netBtn_Offerto.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Offerto.CornerRadius = 2
      Me.netBtn_Offerto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Offerto.Location = New System.Drawing.Point(701, 290)
      Me.netBtn_Offerto.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Offerto.Name = "netBtn_Offerto"
      Me.netBtn_Offerto.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Offerto.TabIndex = 19
      Me.netBtn_Offerto.TextButton = "Offerto"
      '
      'eui_txtPrezzo
      '
      Me.eui_txtPrezzo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtPrezzo.BannerTextFont = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtPrezzo.Enabled = False
      Me.eui_txtPrezzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtPrezzo.Id = "6f57f64d-4b12-4a64-89a5-4c70437ded83"
      Me.eui_txtPrezzo.Location = New System.Drawing.Point(918, 484)
      Me.eui_txtPrezzo.Name = "eui_txtPrezzo"
      Me.eui_txtPrezzo.Size = New System.Drawing.Size(254, 39)
      Me.eui_txtPrezzo.TabIndex = 31
      Me.eui_txtPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_txtPrezzo.TextEditorWidth = 248
      '
      'eui_txtCodice
      '
      Me.eui_txtCodice.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_txtCodice.BannerTextColor = System.Drawing.SystemColors.GrayText
      Me.eui_txtCodice.BannerTextFont = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCodice.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_txtCodice.Id = "35ef4608-81fd-4c67-8182-0e75fd179969"
      Me.eui_txtCodice.Location = New System.Drawing.Point(918, 442)
      Me.eui_txtCodice.Name = "eui_txtCodice"
      Me.eui_txtCodice.Size = New System.Drawing.Size(254, 39)
      Me.eui_txtCodice.TabIndex = 29
      Me.eui_txtCodice.TextEditorWidth = 248
      '
      'eui_cmdOk
      '
      Me.eui_cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdOk.Id = "635fe2eb-2416-4796-8cf7-4f7e8e962ca5"
      Me.eui_cmdOk.Location = New System.Drawing.Point(741, 690)
      Me.eui_cmdOk.Name = "eui_cmdOk"
      Me.eui_cmdOk.Size = New System.Drawing.Size(85, 24)
      Me.eui_cmdOk.TabIndex = 319
      Me.eui_cmdOk.Text = "OK"
      Me.eui_cmdOk.Visible = False
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
      Me.netBtn_ListaPiattiSu.Location = New System.Drawing.Point(1005, 384)
      Me.netBtn_ListaPiattiSu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ListaPiattiSu.Name = "netBtn_ListaPiattiSu"
      Me.netBtn_ListaPiattiSu.Size = New System.Drawing.Size(168, 56)
      Me.netBtn_ListaPiattiSu.TabIndex = 27
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
      Me.netBtn_ListaPiattiGiù.Location = New System.Drawing.Point(836, 384)
      Me.netBtn_ListaPiattiGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ListaPiattiGiù.Name = "netBtn_ListaPiattiGiù"
      Me.netBtn_ListaPiattiGiù.Size = New System.Drawing.Size(168, 56)
      Me.netBtn_ListaPiattiGiù.TabIndex = 26
      Me.netBtn_ListaPiattiGiù.TextButton = ""
      '
      'netBtn_ContiParcheggiati
      '
      Me.netBtn_ContiParcheggiati.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_ContiParcheggiati.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_ContiParcheggiati.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_ContiParcheggiati.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_ContiParcheggiati.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_ContiParcheggiati.ColorText = System.Drawing.Color.White
      Me.netBtn_ContiParcheggiati.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_ContiParcheggiati.CornerRadius = 2
      Me.netBtn_ContiParcheggiati.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_ContiParcheggiati.Location = New System.Drawing.Point(701, 461)
      Me.netBtn_ContiParcheggiati.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ContiParcheggiati.Name = "netBtn_ContiParcheggiati"
      Me.netBtn_ContiParcheggiati.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_ContiParcheggiati.TabIndex = 23
      Me.netBtn_ContiParcheggiati.TextButton = "Conti parcheggiati"
      '
      'frmPos
      '
      Me.AcceptButton = Me.eui_cmdOk
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(1175, 752)
      Me.Controls.Add(Me.netBtn_ContiParcheggiati)
      Me.Controls.Add(Me.lstMessaggi)
      Me.Controls.Add(Me.netBtn_ListaPiattiSu)
      Me.Controls.Add(Me.netBtn_ListaPiattiGiù)
      Me.Controls.Add(Me.eui_cmdOk)
      Me.Controls.Add(Me.eui_txtCodice)
      Me.Controls.Add(Me.eui_txtPrezzo)
      Me.Controls.Add(Me.netBtn_Offerto)
      Me.Controls.Add(Me.netBtn_VarianteMeno)
      Me.Controls.Add(Me.netBtn_Messaggi)
      Me.Controls.Add(Me.NetButton1)
      Me.Controls.Add(Me.netBtn_Codice)
      Me.Controls.Add(Me.netBtn_Tastiera)
      Me.Controls.Add(Me.netBtn_VariantePiù)
      Me.Controls.Add(Me.netBtn_SottoCategoria)
      Me.Controls.Add(Me.netBtn_PiattiSu)
      Me.Controls.Add(Me.netBtn_PiattiGiù)
      Me.Controls.Add(Me.netBtn_VarianteSu)
      Me.Controls.Add(Me.netBtn_VarianteGiù)
      Me.Controls.Add(Me.netBtn_CategoriaSu)
      Me.Controls.Add(Me.netBtn_CategoriaGiù)
      Me.Controls.Add(Me.netBtn_Modifica)
      Me.Controls.Add(Me.netBtn_Listino)
      Me.Controls.Add(Me.netBtn_Reparto)
      Me.Controls.Add(Me.netBtn_C)
      Me.Controls.Add(Me.netBtn_9)
      Me.Controls.Add(Me.netBtn_8)
      Me.Controls.Add(Me.netBtn_7)
      Me.Controls.Add(Me.netBtn_Prezzo)
      Me.Controls.Add(Me.netBtn_Ok)
      Me.Controls.Add(Me.netBtn_Percentuale)
      Me.Controls.Add(Me.netBtn_X)
      Me.Controls.Add(Me.netBtn_00)
      Me.Controls.Add(Me.netBtn_0)
      Me.Controls.Add(Me.netBtn_Virgola)
      Me.Controls.Add(Me.netBtn_3)
      Me.Controls.Add(Me.netBtn_2)
      Me.Controls.Add(Me.netBtn_1)
      Me.Controls.Add(Me.netBtn_6)
      Me.Controls.Add(Me.netBtn_5)
      Me.Controls.Add(Me.netBtn_4)
      Me.Controls.Add(Me.netBtn_CancellaTutto)
      Me.Controls.Add(Me.netBtn_Cancella)
      Me.Controls.Add(Me.netBtn_QuantitàMeno)
      Me.Controls.Add(Me.netBtn_QuantitàPiù)
      Me.Controls.Add(Me.netBtn_Escludi)
      Me.Controls.Add(Me.netBtn_Conferma)
      Me.Controls.Add(Me.netBtn_Impostazioni)
      Me.Controls.Add(Me.netBtn_Conto)
      Me.Controls.Add(Me.netBtn_Esci)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.lblData)
      Me.Controls.Add(Me.lblTotale)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.lblQuantità)
      Me.Controls.Add(Me.lblOra)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.pnlCategoria)
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

#Region "Scarico ingredienti "
   Private Function SalvaDati(ByVal tabella As String, ByVal id As Integer, ByVal giacenza As Double,
                              ByVal carico As Double, ByVal scarico As Double,
                              ByVal situazione As Double, ByVal prezzo As String,
                              ByVal valCarico As Double, ByVal valScarico As Double, ByVal valAttuale As Double) As Boolean

      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET Giacenza = @Giacenza, " &
                             "Carico = @Carico, " &
                             "Scarico = @Scarico, " &
                             "SituazioneScorta = @SituazioneScorta, " &
                             "ValCarico = @ValCarico, " &
                             "valScarico = @ValScarico, " &
                             "ValAttuale = @ValAttuale, " &
                             "PrezzoAcquisto = @Prezzo " &
                             "WHERE Id = {1}",
                              tabella,
                              id)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Giacenza", giacenza)
         cmdUpdate.Parameters.AddWithValue("@Carico", carico)
         cmdUpdate.Parameters.AddWithValue("@Scarico", scarico)
         cmdUpdate.Parameters.AddWithValue("@SituazioneScorta", situazione)
         cmdUpdate.Parameters.AddWithValue("@ValCarico", valCarico)
         cmdUpdate.Parameters.AddWithValue("@ValScarico", valScarico)
         cmdUpdate.Parameters.AddWithValue("@ValAttuale", valAttuale)
         cmdUpdate.Parameters.AddWithValue("@Prezzo", prezzo)

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

   Private Function SalvaMovimentiMag(ByVal tabella As String, ByVal id_Articolo As Integer, ByVal data As String,
                                      ByVal codice As String, ByVal descrizione As String,
                                      ByVal carico As Double, ByVal scarico As Double,
                                      ByVal causale As String, ByVal prezzo As String,
                                      ByVal fornitore As String, ByVal magazzino As String) As Boolean

      Dim cn As New OleDbConnection(ConnString)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Id_Articolo, Data, Codice, Descrizione, PrezzoAcquisto, " &
                                              "Carico, Scarico, Causale, Fornitore, Magazzino) " &
                                       "VALUES(@Id_Articolo, @Data, @Codice, @Descrizione, @PrezzoAcquisto, " &
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

   Private Function CalcolaGiacenza(ByVal descrizione As String, ByVal giacenza As Double, ByVal scortaMin As Double, ByVal quantità As Double) As Double
      Try
         If scortaMin > 0 Then
            If (giacenza - quantità) < scortaMin Then
               ' Messaggio sottoscorta.
               MessageBox.Show("L'articolo o l'ingrediente '" & descrizione & "' risulterà essere sottoscorta!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
            Return (giacenza - quantità)

         ElseIf scortaMin = 0 Then
            If quantità = giacenza Then
               ' Messaggio giacenza pari a zero.
               MessageBox.Show("L'articolo o l'ingrediente '" & descrizione & "' risulterà essere con giacenza pari a zero!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Return 0

            ElseIf quantità > giacenza Then
               ' Messaggio quantità maggiore della giacenza.
               MessageBox.Show("Per l'articolo o l'ingrediente '" & descrizione & "' si sta scaricando una quantità maggiore della giacenza! " &
                               "La quantità presente in giacenza assumerà un valore negativo.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
            Dim IdPiatto As Integer = Convert.ToInt32(lstvDettagli.Items(i).SubItems(5).Text)

            ' Codice necessario per le varianti che non hanno una quantità.
            Dim qtàPiatto As Integer
            If lstvDettagli.Items(i).SubItems(1).Text <> String.Empty Then
               qtàPiatto = Convert.ToInt32(lstvDettagli.Items(i).SubItems(1).Text)
            Else
               qtàPiatto = 1
            End If

            ' Legge i dati degli ingredienti del piatto.
            Dim cmd As New OleDbCommand("SELECT * FROM Ingredienti WHERE Id_Piatto = " & IdPiatto & " ORDER BY Id ASC", cn)
            Dim dr As OleDbDataReader = cmd.ExecuteReader()

            Do While dr.Read
               idArticolo = Convert.ToInt32((dr.Item("Id_Articolo")))
               ' Moltiplica per il numero di piatti venduti.
               qtàScarico = Convert.ToDouble(dr.Item("Quantità")) * qtàPiatto

               AArticoli.LeggiDati("Articoli", dr.Item("Id_Articolo").ToString)

               Dim nuovaGiacenza As Double = CalcolaGiacenza(AArticoli.Descrizione, AArticoli.Giacenza, AArticoli.ScortaMin, qtàScarico)
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
                        valCarico = CFormatta.FormattaEuro(CalcolaValore(Convert.ToDecimal(AArticoli.PrezzoAcquisto), Carico))
                     Else
                        valCarico = 0
                     End If

                     If Scarico <> 0 Then
                        valScarico = CFormatta.FormattaEuro(CalcolaValore(Convert.ToDecimal(AArticoli.PrezzoAcquisto), Scarico))
                     Else
                        valScarico = 0
                     End If

                     If nuovaGiacenza <> 0 Then
                        valAttuale = CFormatta.FormattaEuro(CalcolaValore(Convert.ToDecimal(AArticoli.PrezzoAcquisto), nuovaGiacenza))
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
               SalvaDati("Articoli", idArticolo, nuovaGiacenza,
                          Carico, Scarico, situazioneScorta, AArticoli.PrezzoAcquisto,
                          valCarico, valScarico, valAttuale)

               ' Verifica se è un carico o scarico.
               Dim qtàCaricata As Double = 0
               Dim qtàScaricata As Double = 0
               qtàScaricata = qtàScarico
               qtàCaricata = 0

               Dim data As Date = dtpData.Text

               ' Salva i dati per i movimenti di magazzino.
               SalvaMovimentiMag("MovMagazzino", idArticolo, data.ToShortDateString, AArticoli.Codice, AArticoli.Descrizione,
                                  qtàCaricata, qtàScaricata, CausaleMovMag, AArticoli.PrezzoAcquisto,
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

   Public Function CaricaComandeConto(ByVal data As String, ByVal oraOcc As String, ByVal numeroConto As String, ByVal tavolo As String, ByVal cameriere As String) As Boolean
      Try
         ' Imposta il numero di un eventuale conto da modificare.
         numeroContoDoc = numeroConto

         ' Conto Immediato da documento conto.
         If tavolo = String.Empty Or tavolo = "Conto Imm." Then
            idTavolo = Nothing
            nomeTavolo = String.Empty
            nomeTavoloDoc = "Conto Imm."
            nomeCameriereDoc = "Cassa"
            infoTitolo = "Visual POS - CONTO NUMERO: " & numeroConto & " DEL " & data & " ORA: " & oraOcc
         Else
            idTavolo = Nothing
            nomeTavolo = tavolo
            nomeTavoloDoc = tavolo
            nomeCameriereDoc = cameriere
            infoTitolo = "Visual POS - CONTO NUMERO: " & numeroConto & " DEL " & data & " ORA: " & oraOcc & " - TAVOLO: " & tavolo & " - CAMERIERE: " & cameriere
         End If

         ' Imposta il titolo della finestra.
         Me.Text = infoTitolo

         ' Carica i dettagli del conto nella lista per essere modificate.
         ApriDettagliConto()

         CalcolaTotaleQtà()
         CalcolaTotaleConto()
         CalcolaTotaleContoRep()

         netBtn_Conferma.TextButton = "Annulla"
         eui_txtCodice.Focus()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_PUNTO_CASSA, MODULO_GESTIONE_POS)

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Sub EliminaConto(ByVal numeroConto As String)
      Try
         If numeroConto <> String.Empty Then
            ' Elimina il conto.
            Dim conto As New Documenti
            If conto.EliminaDati(TAB_DOCUMENTI, Convert.ToInt32(numeroConto)) = True Then
               ' Se il conto è stato eliminato correttamente elimina i dettagli del conto.
               Dim dettagliConto As New Comande
               dettagliConto.EliminaDati(TAB_COMANDE, numeroConto)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Ripristina il titolo della finestra.
         infoTitolo = "Visual POS - CONTO IMMEDIATO"
         Me.Text = infoTitolo

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
            lstvDettagli.Items.Add(lstvDettagli.Items.Count.ToString)

            ' Quantità
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(QTA)

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Descrizione").ToString)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Importo.
            Select Case NumListino
               Case Listino.Uno
                  If IsDBNull(dr.Item("Listino1")) = False Then
                     If dr.Item("Listino1").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino1").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Due
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     If dr.Item("Listino2").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino2").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Tre
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     If dr.Item("Listino3").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino3").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Quattro
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     If dr.Item("Listino4").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino4").ToString)
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
                     If dr.Item("Listino1").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino1").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Due
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     If dr.Item("Listino2").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino2").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Tre
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     If dr.Item("Listino3").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino3").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Quattro
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     If dr.Item("Listino4").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino4").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If
            End Select

            ' Id Piatto.
            If IsDBNull(dr.Item("Id")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Id").ToString)
            End If

            ' Categoria e Reparto.
            If IsDBNull(dr.Item("Categoria")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Categoria").ToString)
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(LeggiReparto(TAB_CATEGORIE, dr.Item("Categoria").ToString))
            End If

            ' Inviata.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

            ' Esclusa.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

            ' Offerta.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

            ' Id  Comanda.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = True Or dr.Item("AliquotaIva") = String.Empty Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(AliquotaIvaRistorante)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(LeggiAliquotaIva(dr.Item("AliquotaIva")))
            End If

            ' Stringa per registrare loperazione effettuata dall'operatore identificato.
            strDescrizione = "(" & dr.Item("Descrizione").ToString & ")"

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

   Public Function LeggiDatiPiatto(ByVal tabella As String, ByVal codiceBarre As String) As Boolean
      Const QTA As String = "1"
      Dim trovato As Boolean = False
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE CodBarre = '" & codiceBarre & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Indice
            lstvDettagli.Items.Add(lstvDettagli.Items.Count.ToString)

            ' Quantità
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(QTA)

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Descrizione").ToString)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Importo.
            Select Case NumListino
               Case Listino.Uno
                  If IsDBNull(dr.Item("Listino1")) = False Then
                     If dr.Item("Listino1").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino1").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Due
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     If dr.Item("Listino2").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino2").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Tre
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     If dr.Item("Listino3").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino3").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Quattro
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     If dr.Item("Listino4").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino4").ToString)
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
                     If dr.Item("Listino1").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino1").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Due
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     If dr.Item("Listino2").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino2").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Tre
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     If dr.Item("Listino3").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino3").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Quattro
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     If dr.Item("Listino4").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Listino4").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If
            End Select

            ' Id Piatto.
            If IsDBNull(dr.Item("Id")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Id").ToString)
            End If

            ' Categoria e Reparto.
            If IsDBNull(dr.Item("Categoria")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Categoria").ToString)
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(LeggiReparto(TAB_CATEGORIE, dr.Item("Categoria").ToString))
            End If

            ' Inviata.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

            ' Esclusa.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

            ' Offerta.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

            ' Id  Comanda.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Or dr.Item("AliquotaIva") = String.Empty Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(AliquotaIvaRistorante)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(LeggiAliquotaIva(dr.Item("AliquotaIva")))
            End If

            ' Stringa per registrare loperazione effettuata dall'operatore identificato.
            strDescrizione = "(" & dr.Item("Descrizione").ToString & ")"

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

   Public Function LeggiDatiVariazione(ByVal tabella As String, ByVal codice As Integer) As Boolean
      Dim trovato As Boolean = False
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String

      Try
         ' Verifica del segno +/- per le varianti.
         Dim valSegno As String = String.Empty
         Dim descrizioneSegno As String = String.Empty

         Select Case segnoVariante
            Case "-"
               valSegno = segnoVariante
               descrizioneSegno = segnoVariante & " "

            Case "+"
               valSegno = String.Empty
               descrizioneSegno = segnoVariante & " "

            Case String.Empty
               valSegno = String.Empty
               descrizioneSegno = String.Empty

         End Select

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & codice & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' Indice
            lstvDettagli.Items.Add(lstvDettagli.Items.Count.ToString)

            ' Quantità
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(descrizioneSegno & dr.Item("Descrizione").ToString)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
            End If

            ' Importo.
            Select Case NumListino
               Case Listino.Uno
                  If IsDBNull(dr.Item("Listino1")) = False Then
                     If dr.Item("Listino1").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(valSegno & dr.Item("Listino1").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Due
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     If dr.Item("Listino2").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(valSegno & dr.Item("Listino2").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Tre
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     If dr.Item("Listino3").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(valSegno & dr.Item("Listino3").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Quattro
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     If dr.Item("Listino4").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(valSegno & dr.Item("Listino4").ToString)
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
                     If dr.Item("Listino1").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(valSegno & dr.Item("Listino1").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Due
                  If IsDBNull(dr.Item("Listino2")) = False Then
                     If dr.Item("Listino2").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(valSegno & dr.Item("Listino2").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Tre
                  If IsDBNull(dr.Item("Listino3")) = False Then
                     If dr.Item("Listino3").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(valSegno & dr.Item("Listino3").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

               Case Listino.Quattro
                  If IsDBNull(dr.Item("Listino4")) = False Then
                     If dr.Item("Listino4").ToString <> "" Then
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(valSegno & dr.Item("Listino4").ToString)
                     Else
                        lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     End If
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If
            End Select

            ' Id Piatto.
            If IsDBNull(dr.Item("Id")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Id").ToString)
            End If

            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Categoria").ToString)
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(LeggiReparto(TAB_CATEGORIE, dr.Item("Categoria").ToString))
            End If

            ' Inviata.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

            ' Esclusa.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

            ' Offerta.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

            ' Id  Comanda.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = True Or dr.Item("AliquotaIva") = String.Empty Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(AliquotaIvaRistorante)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(LeggiAliquotaIva(dr.Item("AliquotaIva")))
            End If

            ' Stringa per registrare loperazione effettuata dall'operatore identificato.
            strDescrizione = "(" & dr.Item("Descrizione").ToString & ")"

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

   Public Function LeggiReparto(ByVal tabella As String, ByVal categoria As String) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & categoria & "'", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("Reparto")) = False Then
               Return dr.Item("Reparto").ToString
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
            CategoriaIniziale = dr.Item("Descrizione").ToString
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

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

   Private Function AumentaDiminuisciQta(ByVal val As Boolean) As Boolean
      ' Vero: aumenta di 1 - Falso: diminuisce di 1.
      Try
         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Focus()

            Dim quantità As Decimal = Convert.ToDecimal(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text)
            Dim totPrezzo As Decimal = Convert.ToDecimal(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(3).Text)
            Dim prezzo As Decimal

            ' Ottiene il prezzo di una singola unità.
            prezzo = totPrezzo / quantità

            If val = True Then
               quantità += 1
            Else
               If quantità = 1 Or quantità < 1 Then
                  Return False
               Else
                  quantità -= 1
               End If
            End If

            ' Aggiorna la quantità.
            lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text = quantità.ToString

            ' Calcola il prezzo totale in base alla quantità inserita.
            totPrezzo = prezzo * quantità
            lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(3).Text = CFormatta.FormattaEuro(totPrezzo)

         End If

         Return True

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
         Dim strDescrizione As String = "(" & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text &
                                        " " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text &
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
            If colore = Convert.ToString(Color.DimGray.ToArgb) Then
               If lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(8).Text = "No" Then
                  ' Imposta il nero.
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.White
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.Black
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(9).Text = "No"
                  escludi = "Incluso"
               Else
                  ' Imposta il nero.
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.MediumSeaGreen
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.White
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(9).Text = "No"

                  escludi = "Incluso"
               End If
            Else
               ' Imposta il rosa.
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.DimGray
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.White
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic)
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(9).Text = "Sì"
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(10).Text = "No"
               escludi = "Escluso"
            End If

         Else
            Exit Sub
         End If

         ' Registra loperazione effettuata dall'operatore identificato.
         Dim strDescrizione As String = "(" & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text &
                                        " " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text &
                                        " € " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(3).Text & " - " & escludi & ")"

         g_frmMain.RegistraOperazione(TipoOperazione.Escludi, strDescrizione, MODULO_GESTIONE_POS)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub OffriElemento()
      Try
         Dim offri As String

         If lstvDettagli.Items.Count <> 0 Then
            lstvDettagli.Focus()

            Dim colore As String = Convert.ToString(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor.ToArgb)

            ' Se il testo è già evidenziato...
            If colore = Convert.ToString(Color.Orange.ToArgb) Then
               If lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(8).Text = "No" Then
                  ' Imposta il nero.
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.White
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.Black
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(10).Text = "No"
                  offri = "Non offerto"
               Else
                  ' Imposta il nero.
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.MediumSeaGreen
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.White
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
                  lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(10).Text = "No"
                  offri = "Non offerto"
               End If
            Else
               ' Imposta il rosa.
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).BackColor = Color.Orange
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).ForeColor = Color.White
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Strikeout)
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(10).Text = "Sì"
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(9).Text = "No"
               offri = "Offerto"
            End If

         Else
            Exit Sub
         End If

         ' Registra loperazione effettuata dall'operatore identificato.
         Dim strDescrizione As String = "(" & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text &
                                        " " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text &
                                        " € " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(3).Text & " - " & offri & ")"

         g_frmMain.RegistraOperazione(TipoOperazione.Offerto, strDescrizione, MODULO_GESTIONE_POS)

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
               If IsNumeric(lstvDettagli.Items(i).SubItems(3).Text) = True Then
                  TotRiga = Convert.ToDecimal(lstvDettagli.Items(i).SubItems(3).Text)
                  TotaleConto = TotaleConto + TotRiga
               End If
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
               If lstvDettagli.Items(i).SubItems(9).Text = "No" Then
                  If IsNumeric(lstvDettagli.Items(i).SubItems(3).Text) = True Then
                     If lstvDettagli.Items(i).SubItems(10).Text = "No" Then
                        TotRiga = Convert.ToDecimal(lstvDettagli.Items(i).SubItems(3).Text)
                     Else
                        TotRiga = 0
                     End If

                     TotaleConto = TotaleConto + TotRiga
                  End If
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
         ' Ricerca sul codice a barre.
         If LeggiDatiPiatto(TAB_PIATTI, codice) = False Then

            ' Ricerca sul codice di sistema.
            If LeggiDatiPiatto(TAB_PIATTI, Convert.ToInt32(codice)) = False Then
               MessageBox.Show("Codice di sistema o Codice a barre inesistente!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
               CalcolaTotaleQtà()
               CalcolaTotaleConto()
               CalcolaTotaleContoRep()
            End If

         Else
            CalcolaTotaleQtà()
            CalcolaTotaleConto()
            CalcolaTotaleContoRep()
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

   Private Sub SelezionaVariazione(ByVal codice As String)
      Try
         If LeggiDatiVariazione(TAB_PIATTI, Convert.ToInt32(codice)) = False Then
            MessageBox.Show("Codice inesistente!.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            CalcolaTotaleQtà()
            CalcolaTotaleConto()
            CalcolaTotaleContoRep()
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

   Private Sub SalvaStatistiche(ByVal rifDoc As Boolean)

      Try
         Dim i As Integer
         For i = 0 To lstvDettagli.Items.Count - 1

            With Stat
               ' Assegna i dati dei campi della classe alle caselle di testo.
               .Data = CStr(dtpData.Value.Date)
               If rifDoc = True Then
                  ' Salva un riferimento Id del documento per il comando Annulla documento.
                  .IdCategoria = LeggiUltimoRecord("Documenti").ToString ' Salva un riferimento Id del documento.
               Else
                  .IdCategoria = "0"
               End If

               ' Se non esiste un valore per il campo Descrizione Categoria.
               If lstvDettagli.Items(i).SubItems(6).Text = String.Empty Then
                  .DesCategoria = VALORE_NESSUNA
               Else
                  .DesCategoria = FormattaApici(lstvDettagli.Items(i).SubItems(6).Text)
               End If

               .IdPiatto = lstvDettagli.Items(i).SubItems(5).Text
               .DesPiatto = FormattaApici(lstvDettagli.Items(i).SubItems(2).Text)
               .IdTavolo = "0"
               .DesTavolo = String.Empty
               .IdCameriere = "0"
               .DesCameriere = String.Empty

               If lstvDettagli.Items(i).SubItems(1).Text <> String.Empty Then
                  .Quantità = Convert.ToDouble(lstvDettagli.Items(i).SubItems(1).Text)
               Else
                  .Quantità = 1
               End If

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

   Private Sub ApriDettagliConto()
      Try
         Dim CComande As New Comande

         With CComande
            .LeggiDati(lstvDettagli, TAB_COMANDE, numeroContoDoc)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

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

         cmdUpdate.Parameters.AddWithValue("@Inviata", "Sì")

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

               If lstvDettagli.Items(i).SubItems(1).Text <> String.Empty Then
                  .Quantità = Convert.ToDouble(lstvDettagli.Items(i).SubItems(1).Text)
               Else
                  .Quantità = 0
               End If

               .Descrizione = lstvDettagli.Items(i).SubItems(2).Text
               .ImportoNetto = lstvDettagli.Items(i).SubItems(3).Text
               .ValoreUnitario = lstvDettagli.Items(i).SubItems(4).Text
               .IdPiatto = Convert.ToInt32(lstvDettagli.Items(i).SubItems(5).Text)
               .CategoriaPiatto = lstvDettagli.Items(i).SubItems(6).Text
               .Reparto = lstvDettagli.Items(i).SubItems(7).Text
               .Inviata = lstvDettagli.Items(i).SubItems(8).Text
               .Esclusa = lstvDettagli.Items(i).SubItems(9).Text
               .Offerta = lstvDettagli.Items(i).SubItems(10).Text
               .AliquotaIva = lstvDettagli.Items(i).SubItems(12).Text
               .NumeroConto = String.Empty

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

         If LeggiPercorsiComanda(10, percorsiStampa.Stampante) <> String.Empty And
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
               sql = "SELECT * FROM Comande WHERE Reparto = '" & dr.Item("Descrizione").ToString & "' AND Inviata = 'No'"

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

         rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True,
                      PrintDialog1.PrinterSettings.FromPage,
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
               sql = "SELECT * FROM Messaggi WHERE Reparto = '" & dr.Item("Descrizione").ToString & "' AND Inviato = 'No'"

               ' Controlla se ci sono messaggi da inviare per il reparto specificato.
               If VerificaNumRecord(sql) <> 0 Then
                  Dim i As Integer
                  For i = 0 To 9
                     If LeggiPercorsiComanda(i, percorsiStampa.Reparto) = dr.Item("Descrizione").ToString Then
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
               SalvaDatiMsgComande(TAB_MESSAGGI, lstvDettagli.Items(i).SubItems(7).Text, idTavolo, nomeTavolo,
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

   Public Function RegistraMsgModificaComanda(ByVal Qta As String) As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         ' Intestazione.
         lstMessaggi.Items.Add(";TAVOLO: " & nomeTavolo & " - CAMERIERE: " & nomeCameriereDoc)
         ' Dettagli.
         lstMessaggi.Items.Add(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(7).Text &
                              ";MODIFICA: " & Qta & " " &
                              lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text & " IN " &
                              lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text & " " &
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
         lstMessaggi.Items.Add(lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(7).Text &
                              ";CANCELLA: " &
                              lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text & " " &
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
               lstMessaggi.Items.Add(lstvDettagli.Items(i).SubItems(7).Text &
                                    ";CANCELLA: " &
                                    lstvDettagli.Items(i).SubItems(1).Text & " " &
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
         sql = String.Format("INSERT INTO {0} (Data, Reparto, IdRisorsa, DescrizioneRisorsa, Messaggio, Inviato) " &
                                       "VALUES(@Data, @Reparto, @IdRisorsa, @DescrizioneRisorsa, @Messaggio, @Inviato)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Data", Now.ToShortDateString & " " & Now.ToShortTimeString)
         cmdInsert.Parameters.AddWithValue("@Reparto", reparto)
         cmdInsert.Parameters.AddWithValue("@IdRisorsa", idTavolo)
         cmdInsert.Parameters.AddWithValue("@DescrizioneRisorsa", Tavolo)
         cmdInsert.Parameters.AddWithValue("@Messaggio", messaggio)
         cmdInsert.Parameters.AddWithValue("@Inviato", "No")

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
         sql = String.Format("INSERT INTO {0} (Data, Reparto, IdRisorsa, DescrizioneRisorsa, Messaggio, Inviato) " &
                                       "VALUES(@Data, @Reparto, @IdRisorsa, @DescrizioneRisorsa, @Messaggio, @Inviato)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Data", Now.ToShortDateString & " " & Now.ToShortTimeString)
         cmdInsert.Parameters.AddWithValue("@Reparto", reparto)
         cmdInsert.Parameters.AddWithValue("@IdRisorsa", idTavolo)
         cmdInsert.Parameters.AddWithValue("@DescrizioneRisorsa", Tavolo)
         cmdInsert.Parameters.AddWithValue("@Messaggio", messaggio)
         cmdInsert.Parameters.AddWithValue("@Inviato", "Sì")

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

         cmdUpdate.Parameters.AddWithValue("@Inviato", "Sì")

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
         g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).ColorBottom = g_frmVCTavoli.TAVOLO_DA_LIBERARE

         ' Rimuove il contatore del tempo.
         g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).TextButton =
                               g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).TextButton.Remove(g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).TextButton.Length -
                               g_frmVCTavoli.LUNGHEZZA_ORA, g_frmVCTavoli.LUNGHEZZA_ORA)

         ' Modifica lo stato del tavolo nel database. 
         g_frmVCTavoli.modificatoStatoTavolo = g_frmVCTavoli.ModificaStatoTavolo(g_frmVCTavoli.ANAG_TAVOLI, g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).Name,
                                               g_frmVCTavoli.TAVOLO_DA_LIBERARE, String.Empty, String.Empty)

         ' Elimina le comande del tavolo nel database.
         g_frmVCTavoli.EliminaComandeTavolo(g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).Name)

         ' Rimuove il tavolo dalla lista dei tavoli occupati.
         Dim i As Integer = 0
         For i = 0 To g_frmVCTavoli.NumTavoliOccupati - 1
            If g_frmVCTavoli.IndiceTavoloOccupato(i) <> Nothing Then
               If g_frmVCTavoli.Risorsa(g_frmVCTavoli.IndiceTavoloOccupato(i)).Name =
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
                     BtnCancellaTutto()
                  End If

                  If nomeTavoloDoc <> "Conto Imm." And nomeTavoloDoc <> "Asporto" Then
                     TavoloDaLiberare()
                     ScaricaIngredienti()
                     SalvaStatistiche(True)
                     BtnCancellaTutto()
                  Else
                     ScaricaIngredienti()
                     SalvaStatistiche(True)
                     BtnCancellaTutto()

                     If tipoDocumento <> TIPO_DOC_PF Then
                        ' Elimina il conto del documento stampato.
                        EliminaConto(numeroContoDoc)
                     End If

                     ' Ripristina il Punto cassa.
                     AnnullaConto()
                  End If
               Else
                  ' Punto cassa.
                  If nomeTavoloDoc = "Conto Imm." Then
                     ScaricaIngredienti()
                     SalvaStatistiche(True)
                     BtnCancellaTutto()

                     If tipoDocumento <> TIPO_DOC_PF Then
                        ' Elimina il conto del documento stampato.
                        EliminaConto(numeroContoDoc)
                     End If

                     ' Ripristina il Punto cassa.
                     AnnullaConto()
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
                     If g_frmMain.eui_Strumenti_Sospesi_Filtra.Pressed = True Then
                        ' Aggiorna la griglia dati.
                        .AggiornaDatiSospesi()
                        Exit Sub
                     ElseIf g_frmMain.eui_Strumenti_Periodo_Mese.Pressed = True Then
                        ' Aggiorna la griglia dati.
                        .AggiornaDatiMese()
                        Exit Sub
                     ElseIf g_frmMain.eui_Strumenti_Periodo_Anno.Pressed = True Then
                        ' Aggiorna la griglia dati.
                        .AggiornaDatiAnno()
                        Exit Sub
                     ElseIf g_frmMain.eui_Strumenti_Periodo_DalAl.Pressed = True Then
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
            Else
               ' DialogResult = Cancel
               If numeroContoDoc = String.Empty Then
                  ' Pulsante esci.
                  ' DA_FARE_B: BtnCancellaTutto() - Non utilizzata per mantenere i piatti nel punto cassa quando si esce dal conto senza stampare un documento.
               Else
                  ' Parcheggia il conto.
                  If IsNothing(g_frmVCTavoli) = False Then
                     ' Da Gestione Tavoli.

                     ' Chiude il Punto cassa.
                     Me.Close()

                     ' Imposta il tavolo come da liberare.
                     TavoloDaLiberare()

                     ' Elimina il numero del conto.
                     numeroContoDoc = String.Empty
                  Else
                     ' Da Punto cassa.
                     BtnCancellaTutto()
                  End If

                  Exit Sub
               End If
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         tipoDocumento = String.Empty
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

   Private Sub ImpostaTastiFunzione()
      Try
         ' Tasto funzione - Listino 1,2,3,4.
         LeggiColoriTastiFunzione("Listino (1,2,3,4)", netBtn_Listino, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Modifica.
         LeggiColoriTastiFunzione("Modifica", netBtn_Modifica, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Cancella.
         LeggiColoriTastiFunzione("Cancella", netBtn_Cancella, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Cancella tutto.
         LeggiColoriTastiFunzione("Cancella tutto", netBtn_CancellaTutto, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Escludi dal conto.
         LeggiColoriTastiFunzione("Escludi dal conto", netBtn_Escludi, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Escludi dal conto.
         LeggiColoriTastiFunzione("Offerto", netBtn_Offerto, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - +1.
         LeggiColoriTastiFunzione("+1", netBtn_QuantitàPiù, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - -1.
         LeggiColoriTastiFunzione("-1", netBtn_QuantitàMeno, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Messaggi.
         LeggiColoriTastiFunzione("Messaggi", netBtn_Messaggi, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Messaggi.
         LeggiColoriTastiFunzione("Conti parcheggiati", netBtn_ContiParcheggiati, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Conferma Invia comanda.
         LeggiColoriTastiFunzione("Conferma Invia comanda", netBtn_Conferma, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Impostazioni.
         LeggiColoriTastiFunzione("Impostazioni", netBtn_Impostazioni, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Reparto (1,2,3,4).
         LeggiColoriTastiFunzione("Reparto (1,2,3,4)", netBtn_Reparto, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Conto.
         LeggiColoriTastiFunzione("Conto", netBtn_Conto, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Esci.
         LeggiColoriTastiFunzione("Esci", netBtn_Esci, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - +.
         LeggiColoriTastiFunzione("+", netBtn_VariantePiù, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - -.
         LeggiColoriTastiFunzione("-", netBtn_VarianteMeno, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Codice a barre.
         LeggiColoriTastiFunzione("Codice a barre", netBtn_Codice, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - €.
         LeggiColoriTastiFunzione("€", netBtn_Prezzo, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - C.
         LeggiColoriTastiFunzione("C", netBtn_C, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - X.
         LeggiColoriTastiFunzione("X", netBtn_X, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - %.
         LeggiColoriTastiFunzione("%", netBtn_Percentuale, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - OK.
         LeggiColoriTastiFunzione("OK", netBtn_Ok, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 1.
         LeggiColoriTastiFunzione("1", netBtn_1, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 2.
         LeggiColoriTastiFunzione("2", netBtn_2, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 3.
         LeggiColoriTastiFunzione("3", netBtn_3, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 4.
         LeggiColoriTastiFunzione("4", netBtn_4, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 5.
         LeggiColoriTastiFunzione("5", netBtn_5, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 6.
         LeggiColoriTastiFunzione("6", netBtn_6, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 7.
         LeggiColoriTastiFunzione("7", netBtn_7, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 8.
         LeggiColoriTastiFunzione("8", netBtn_8, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 9.
         LeggiColoriTastiFunzione("9", netBtn_9, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 0.
         LeggiColoriTastiFunzione("0", netBtn_0, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - 00.
         LeggiColoriTastiFunzione("00", netBtn_00, TAB_POS_IMPOSTAZIONI_PIATTI)

         ' Tasto funzione - Virgola.
         LeggiColoriTastiFunzione(",", netBtn_Virgola, TAB_POS_IMPOSTAZIONI_PIATTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Sub LeggiColoriTastiFunzione(ByVal nomeTasto As String, ByVal btn As NetButton, ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & nomeTasto & "'", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            btn.ColorBottom = Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo")))
            btn.ColorText = Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto")))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

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

         ' Reset del segno +/- per le varianti.
         segnoVariante = String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Piatti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

         If VerificaPiattiEsauriti(Convert.ToInt32(CType(sender, NetButton).Name)) = False Then
            SelezionaPiatto(CType(sender, NetButton).Name)
         Else
            MessageBox.Show("Il piatto selezionato è esaurito!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

         ' Reset del segno +/- per le varianti.
         segnoVariante = String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Variazioni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

         If VerificaPiattiEsauriti(Convert.ToInt32(CType(sender, NetButton).Name)) = False Then
            SelezionaVariazione(CType(sender, NetButton).Name)
         Else
            MessageBox.Show("La variante selezionata è esaurita!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

         ' Reset del segno +/- per le varianti.
         segnoVariante = String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
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

   Private Sub frmPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta i colori dei tasti funzione.
         ImpostaTastiFunzione()

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

         ' Imposta il titolo della finestra.
         Me.Text = infoTitolo

         Dim APiatti As New Piatti
         NUMERO_PIATTI_RIGA = APiatti.LeggiUltimoRecord("NumTastiRiga", TAB_PIATTI)
         LARGHEZZA_PIATTO = APiatti.LeggiUltimoRecord("LarghezzaTasto", TAB_PIATTI)
         ALTEZZA_PIATTO = APiatti.LeggiUltimoRecord("AltezzaTasto", TAB_PIATTI)

         If LARGHEZZA_PIATTO = 0 Then
            LARGHEZZA_PIATTO = CalcolaLarghezzaPiatto()
         End If

         ' to_do: leggere da file di configurazione.
         NumListino = Listino.Uno

         LeggiDatiCategorie(TAB_CATEGORIE)

         LeggiDatiPiatti(TAB_PIATTI, CategoriaIniziale)

         LeggiDatiVariazioni(TAB_PIATTI, CategoriaIniziale)

         ' Viene aperto il punto cassa per l'inserimento delle comande.
         If IsNothing(idTavolo) = False And idTavolo <> 0 Then
            ApriComande()
         End If

         CalcolaTotaleQtà()
         CalcolaTotaleConto()
         CalcolaTotaleContoRep()

         eui_txtCodice.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmPos_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         ' Distrugge l'oggetto e libera le risorse.
         If IsNothing(g_frmPos) = False Then
            g_frmPos.Dispose()
            g_frmPos = Nothing
         End If

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
         If g_frmPos.Tag = "OPERATORE" Or g_frmPos.Tag = "IMPOSTAZIONI" Then
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
      Try
         If Me.Width <= 1015 Then
            Me.Width = 1015
         End If

         If Me.Height <= 615 Then
            Me.Height = 615
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DigitaNumeri(ByVal ctrl As Control, ByVal net_Btn As NetButton)
      Try
         If ctrl Is Nothing = False Then
            If ctrl.Name = eui_txtCodice.Name Then
               If ctrl Is Nothing = False Then
                  ctrl.Text = ctrl.Text & net_Btn.TextButton
                  ctrl.Focus()
               End If

            ElseIf ctrl.Name = eui_txtPrezzo.Name Then
               ' Salva i dati per la moltiplicazione.
               If moltiplica = False Then
                  ctrl.Text = ctrl.Text & net_Btn.TextButton
                  op1 = Convert.ToDouble(ctrl.Text)
               Else
                  If op2 = 0 Then
                     ctrl.Text = String.Empty
                  End If

                  ctrl.Text = ctrl.Text & net_Btn.TextButton
                  op2 = Convert.ToDouble(ctrl.Text)
               End If
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
            MessageBox.Show("Valore numerico errato! Inserire un valore numerico valido per l'importo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Else
            CalcolaTotaleQtà()
            CalcolaTotaleConto()
            CalcolaTotaleContoRep()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         eui_txtPrezzo.Text = String.Empty

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
         lstvDettagli.Items.Add(lstvDettagli.Items.Count.ToString)

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

         ' Esclusa.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

         ' Offerta.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")

         ' Id  Comanda.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

         ' Aliquota Iva.
         lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(AliquotaIvaRistorante)

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

   Public Sub AnnullaConto()
      Try
         ' Ripristina il titolo della finestra.
         infoTitolo = "Visual POS - CONTO IMMEDIATO"
         Me.Text = infoTitolo

         ' Ripristina il pulsante Conferma.
         netBtn_Conferma.TextButton = "Conferma"

         CancellaTutto()
         CalcolaTotaleQtà()
         CalcolaTotaleConto()
         CalcolaTotaleContoRep()

         nomeTavolo = String.Empty
         numeroContoDoc = String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub BtnCancellaTutto()
      RegistraMsgAnnullaComanda()

      CancellaTutto()
      CalcolaTotaleQtà()
      CalcolaTotaleConto()
      CalcolaTotaleContoRep()
   End Sub

   Private Sub ModificaElemento()
      Try
         lstvDettagli.Focus()
         If lstvDettagli.Items.Count <> 0 Then

            Dim quantità As String = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text
            Dim descrizione As String = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text
            Dim totPrezzo As String = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(3).Text
            Dim prezzo As String = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(4).Text
            Dim idPiatto As String = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(5).Text
            Dim aliquotaIva As String = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(12).Text

            Dim frm As New ModificaPiattoPOS(idPiatto, quantità, descrizione, prezzo, totPrezzo, aliquotaIva)
            If frm.ShowDialog() = DialogResult.OK Then
               lstvDettagli.Focus()
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text = frm.eui_txtQuantità.Text
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text = frm.eui_txtDescrizione.Text
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(3).Text = CFormatta.FormattaEuro(Convert.ToDecimal(frm.netBtn_Totale.TextButton))
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(4).Text = frm.eui_txtPrezzo.Text
               lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(12).Text = frm.aliquotaIvaPiatto

               CalcolaTotaleQtà()
               CalcolaTotaleConto()
               CalcolaTotaleContoRep()
            End If
         Else
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ApplicaListino(ByVal nomeListino As String)
      Try
         netBtn_Listino.TextButton = nomeListino

         Select Case nomeListino
            Case "Listino 1"
               NumListino = Listino.Uno

            Case "Listino 2"
               NumListino = Listino.Due

            Case "Listino 3"
               NumListino = Listino.Tre

            Case "Listino 4"
               NumListino = Listino.Quattro

         End Select

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Listino, "(Listino " & NumListino.ToString & ")", MODULO_TAVOLI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub TrovaCodice(ByVal txt As Elegant.Ui.TextBox)
      Try
         If txt.Text <> String.Empty Then
            SelezionaPiatto(txt.Text)
         Else
            MessageBox.Show("Inserire un codice per la ricerca! Un Codice di sistema o un Codice a barre.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub InserisciArticoloGenerico(ByVal txt As Elegant.Ui.TextBox)
      Try
         If txt Is Nothing = False Then
            If txt.Text = String.Empty Then
               txt.Text = VALORE_ZERO
            End If
         End If

         ' Moltiplicazione su una TextBox.
         If moltiplica = True Then
            txt.Text = CFormatta.FormattaEuro(op1 * op2)
            op1 = 0.0
            op2 = 0.0
            moltiplica = False
         End If

         ' Inserisce l'importo per un Articolo generico.
         If txt.Text <> String.Empty Then
            If IsNumeric(txt.Text) = True Then
               Dim importo As Double = Convert.ToDouble(txt.Text)
               SelezionaImporto(CFormatta.FormattaEuro(importo))
            Else
               MessageBox.Show("Inserire un valore numerico valido per l'importo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub ComandoOK()
      Try
         If eui_txtCodice.Enabled = True Then
            TrovaCodice(eui_txtCodice)
            eui_txtCodice.Focus()
         Else
            InserisciArticoloGenerico(eui_txtPrezzo)
            eui_txtPrezzo.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdModalità_Click(sender As System.Object, e As System.EventArgs)
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      'Select Case cmdModalità.Text
      '   Case "€"
      '      cmdModalità.Text = "?"
      '      eui_txtCodice.Text = String.Empty
      '      cmdVirgola.Enabled = False
      '      cmdX.Enabled = False
      '      eui_txtCodice.Focus()

      '   Case "?"
      '      cmdModalità.Text = "€"
      '      eui_txtCodice.Text = VALORE_ZERO
      '      cmdVirgola.Enabled = True
      '      cmdX.Enabled = True
      '      eui_txtCodice.Focus()

      'End Select
   End Sub

   Private Sub netBtn_Esci_Click(sender As Object, e As EventArgs) Handles netBtn_Esci.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = String.Empty
      Me.Close()
   End Sub

   Private Sub netBtn_Conto_Click(sender As Object, e As EventArgs) Handles netBtn_Conto.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_CONTO, MODULO_CONTO)

      StampaConto(Documento.Conto)
   End Sub

   Private Sub netBtn_Scontrino_Click(sender As Object, e As EventArgs)
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      StampaConto(Documento.Scontrino)
   End Sub

   Private Sub netBtn_Impostazioni_Click(sender As Object, e As EventArgs) Handles netBtn_Impostazioni.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Try
         Dim frm As New ImpostazioniPos(g_frmPos.Name)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
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

   Private Sub netBtn_QuantitàPiù_Click(sender As Object, e As EventArgs) Handles netBtn_QuantitàPiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim operazioneQtà As Boolean

         lstvDettagli.Focus()

         If lstvDettagli.Items.Count <> 0 Then
            Dim quantità As String = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text

            ' Se è una variante senza quantità esce dalla procedura.
            If quantità = String.Empty Then
               Exit Sub
            End If

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
            Dim strDescrizione As String = "(" & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text &
                                           " " & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(2).Text & ")"

            g_frmMain.RegistraOperazione(TipoOperazione.QuantitàPiù, strDescrizione, MODULO_GESTIONE_POS)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_QuantitàMeno_Click(sender As Object, e As EventArgs) Handles netBtn_QuantitàMeno.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim operazioneQtà As Boolean

         lstvDettagli.Focus()

         If lstvDettagli.Items.Count <> 0 Then
            Dim quantità As String = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text

            ' Se è una variante senza quantità esce dalla procedura.
            If quantità = String.Empty Then
               Exit Sub
            End If

            operazioneQtà = AumentaDiminuisciQta(False)

            If lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(8).Text = "Sì" Then
               RegistraMsgModificaComanda(quantità)
            End If
         End If

         CalcolaTotaleQtà()
         CalcolaTotaleConto()
         CalcolaTotaleContoRep()

         If operazioneQtà = True Then
            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(1).Text &
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

   Private Sub netBtn_Cancella_Click(sender As Object, e As EventArgs) Handles netBtn_Cancella.Click
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

   Private Sub netBtn_CancellaTutto_Click(sender As Object, e As EventArgs) Handles netBtn_CancellaTutto.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      BtnCancellaTutto()
   End Sub

   Private Sub netBtn_Escludi_Click(sender As Object, e As EventArgs) Handles netBtn_Escludi.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      EscludiElemento()
      CalcolaTotaleContoRep()
   End Sub

   Private Sub netBtn_Conferma_Click(sender As Object, e As EventArgs) Handles netBtn_Conferma.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Se il tasto Conferma e in modalità Annulla.
         If netBtn_Conferma.TextButton = "Annulla" Then
            ' Cancella tutti gli elementi della lista del conto.
            AnnullaConto()
            Exit Sub
         End If

         If nomeTavolo <> String.Empty And nomeTavolo <> "Tavoli" Then
            If SalvaComande() = True Then
               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.AppStarting

               ' Visualizza un messaggio sulla barra di stato.
               g_frmVCTavoli.lblInvioComande.Text = "Invio dati ai reparti in corso..."

               ' Invia comande ai reparti.
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
                  g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).ColorBottom = g_frmVCTavoli.TAVOLO_DA_SERVIRE
                  g_frmVCTavoli.modificatoStatoTavolo = g_frmVCTavoli.ModificaStatoColoreTavolo(g_frmVCTavoli.ANAG_TAVOLI, g_frmVCTavoli.Risorsa(g_frmVCTavoli.tavoloSelezionato).Name,
                                                          g_frmVCTavoli.TAVOLO_DA_SERVIRE)
               End If

               confermaModifiche = True
               Me.Close()

               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.Default

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Conferma, "(Tot. € " & lblTotale.Text & ")", MODULO_GESTIONE_POS)
            End If
         Else
            ' Conferma il Conto immediato.
            If lstvDettagli.Items.Count = 0 Then
               MsgBox("Non è possibile eseguire il comando. Il conto è vuoto!", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
               Return
            Else
               Dim risposta As MsgBoxResult = MsgBox("Sicuro di voler confermare l'operazione? Non verrà stampato nessun documento.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)

               If risposta = MsgBoxResult.Yes Then
                  ' Modifica il cursore del mouse.
                  Cursor.Current = Cursors.AppStarting

                  CausaleMovMag = "Vendita"

                  ScaricaIngredienti()
                  SalvaStatistiche(False)
                  BtnCancellaTutto()

                  ' Modifica il cursore del mouse.
                  Cursor.Current = Cursors.Default

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

      Finally
         If IsNothing(g_frmVCTavoli) = False Then
            ' Visualizza un messaggio sulla barra di stato.
            g_frmVCTavoli.lblInvioComande.Text = String.Empty
         End If
      End Try
   End Sub

   Private Sub eui_cmdOk_Click(sender As Object, e As EventArgs) Handles eui_cmdOk.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

      ' Pressione del tasto OK.
      ComandoOK()

   End Sub

   Private Sub netBtn_Ok_Click(sender As Object, e As EventArgs) Handles netBtn_Ok.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

         ' Pressione del tasto OK.
         ComandoOK()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Percentuale_Click(sender As Object, e As EventArgs) Handles netBtn_Percentuale.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

         If eui_txtPrezzo.Enabled = True Then

            If eui_txtPrezzo Is Nothing = False Then
               If eui_txtPrezzo.Text = String.Empty Then
                  eui_txtPrezzo.Text = VALORE_ZERO
               End If
            End If

            ' Moltiplicazione su una TextBox.
            If moltiplica = True Then
               If op1 <> 0 And op2 <> 0 Then
                  Dim valPercentuale As Double = (op1 * op2) / 100
                  eui_txtPrezzo.Text = CFormatta.FormattaEuro(valPercentuale)
               Else
                  eui_txtPrezzo.Text = VALORE_ZERO
               End If
            End If

            op1 = 0.0
            op2 = 0.0

            moltiplica = False
         Else
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub netBtn_X_Click(sender As Object, e As EventArgs) Handles netBtn_X.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      moltiplica = True
   End Sub

   Private Sub netBtn_C_Click(sender As Object, e As EventArgs) Handles netBtn_C.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         controlloAttivo.Text = String.Empty
         controlloAttivo.Focus()

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

   Private Sub netBtn_Virgola_Click(sender As Object, e As EventArgs) Handles netBtn_Virgola.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         If eui_txtPrezzo.Enabled = True Then
            ' Verifica la presenza della virgola.
            If eui_txtPrezzo.Text = String.Empty Then
               eui_txtPrezzo.Focus()
               Exit Sub
            Else
               Dim virgola As Integer = Convert.ToInt32(eui_txtPrezzo.Text.IndexOf(netBtn_Virgola.TextButton))
               If virgola <> -1 Then
                  eui_txtPrezzo.Focus()
                  Exit Sub
               Else
                  DigitaNumeri(eui_txtPrezzo, netBtn_Virgola)
               End If
            End If
         Else
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub netBtn_0_Click(sender As Object, e As EventArgs) Handles netBtn_0.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_00_Click(sender As Object, e As EventArgs) Handles netBtn_00.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_1_Click(sender As Object, e As EventArgs) Handles netBtn_1.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_2_Click(sender As Object, e As EventArgs) Handles netBtn_2.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_3_Click(sender As Object, e As EventArgs) Handles netBtn_3.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_4_Click(sender As Object, e As EventArgs) Handles netBtn_4.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_5_Click(sender As Object, e As EventArgs) Handles netBtn_5.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_6_Click(sender As Object, e As EventArgs) Handles netBtn_6.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_7_Click(sender As Object, e As EventArgs) Handles netBtn_7.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_8_Click(sender As Object, e As EventArgs) Handles netBtn_8.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_9_Click(sender As Object, e As EventArgs) Handles netBtn_9.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub netBtn_Listino_Click(sender As Object, e As EventArgs) Handles netBtn_Listino.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New TipoListinoPos
         If frm.ShowDialog() = DialogResult.OK Then
            ApplicaListino(frm.Tag.ToString)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Modifica_Click(sender As Object, e As EventArgs) Handles netBtn_Modifica.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Apre la finestra di modifica dell'elemento selezionato.
      ModificaElemento()
   End Sub

   Private Sub lstvDettagli_DoubleClick(sender As Object, e As EventArgs) Handles lstvDettagli.DoubleClick
      ' Apre la finestra di modifica dell'elemento selezionato.
      ModificaElemento()
   End Sub

   Private Sub netBtn_Offerto_Click(sender As Object, e As EventArgs) Handles netBtn_Offerto.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      OffriElemento()
      CalcolaTotaleContoRep()

   End Sub

   Private Sub netBtn_Messaggi_Click(sender As Object, e As EventArgs) Handles netBtn_Messaggi.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Dim frm As New ElencoMessaggi
      frm.WindowState = FormWindowState.Normal
      frm.StartPosition = FormStartPosition.CenterScreen
      frm.ShowDialog()

      ' CODICE NON UTILIZZATO!
      'If frm.ShowDialog() = DialogResult.OK Then
      '   lstvDettagli.Focus()
      '   ' Indice
      '   lstvDettagli.Items.Add(lstvDettagli.Items.Count)
      '   ' Quantità
      '   lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
      '   ' Descrizione.
      '   lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(frm.Tag.ToString)
      '   ' Importo.
      '   lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
      '   ' Prezzo.
      '   lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
      '   ' Id Piatto.
      '   lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("0")
      '   ' Categoria.
      '   lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("Primi")
      '   ' Reparto.
      '   lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("Cucina")
      '   ' Inviata.
      '   lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("No")
      'End If

   End Sub

   Private Sub netBtn_ContiParcheggiati_Click(sender As Object, e As EventArgs) Handles netBtn_ContiParcheggiati.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New ElencoContiPos()
         If frm.ShowDialog() = DialogResult.OK Then

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try


   End Sub

   Private Sub netBtn_Reparto_Click(sender As Object, e As EventArgs) Handles netBtn_Reparto.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New TipoAliquotaIvaPos(True)
         If frm.ShowDialog() = DialogResult.OK Then
            AliquotaIvaRistorante = frm.Tag.ToString
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub netBtn_VariantePiù_Click(sender As Object, e As EventArgs) Handles netBtn_VariantePiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         segnoVariante = "+"

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub netBtn_VarianteMeno_Click(sender As Object, e As EventArgs) Handles netBtn_VarianteMeno.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         segnoVariante = "-"

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Prezzo_Click(sender As Object, e As EventArgs) Handles netBtn_Prezzo.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         eui_txtCodice.Text = String.Empty
         eui_txtCodice.Enabled = False

         eui_txtPrezzo.Enabled = True
         eui_txtPrezzo.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub netBtn_Codice_Click(sender As Object, e As EventArgs) Handles netBtn_Codice.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         eui_txtPrezzo.Text = String.Empty
         eui_txtPrezzo.Enabled = False

         eui_txtCodice.Enabled = True
         eui_txtCodice.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtPrezzo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtPrezzo.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCodice_GotFocus(sender As Object, e As EventArgs) Handles eui_txtCodice.GotFocus
      Try
         controlloAttivo = sender

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_txtPrezzo_GotFocus(sender As Object, e As EventArgs) Handles eui_txtPrezzo.GotFocus
      Try
         controlloAttivo = sender

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
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


End Class
