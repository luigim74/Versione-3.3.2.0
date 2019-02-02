' Nome form:            POS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/04/2006
' Data ultima modifica: 27/05/2015
' Descrizione:          Interfaccia Punto cassa - conto immediato

#Region "Importazioni"

Imports System.Data.SQLite
Imports System.IO
Imports Softgroup.NetButton

#End Region

Public Class frmVCTavoli
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"

   Const START_POS_X As Integer = 0
   Const START_POS_Y As Integer = 0

   Const DIM_SPAZIO As Short = 1
   'Const POS_Y_SALE As Integer = 675

   Const LARGHEZZA_TAVOLI_PICCOLO As Integer = 30
   Const ALTEZZA_TAVOLI_PICCOLO As Integer = 30
   Const LARGHEZZA_TAVOLI_MEDIO As Integer = 60
   Const ALTEZZA_TAVOLI_MEDIO As Integer = 60
   Const LARGHEZZA_TAVOLI_GRANDE As Integer = 100
   Const ALTEZZA_TAVOLI_GRANDE As Integer = 100

   Const LARGHEZZA_SALE As Integer = 82
   Public ALTEZZA_SALE As Integer = 50
   Public LARGHEZZA_TAVOLO_PULSANTI As Integer = 50
   Public ALTEZZA_TAVOLO_PULSANTI As Integer = 50
   Public LARGHEZZA_TAVOLO_PIANTINA As Integer = LARGHEZZA_TAVOLI_MEDIO
   Public ALTEZZA_TAVOLO_PIANTINA As Integer = ALTEZZA_TAVOLI_MEDIO

   Public NUMERO_TAVOLI_RIGA As Integer = 5

   Const ALTEZZA_RIGA_DETTAGLI As Short = 22

   Public Const LUNGHEZZA_ORA As Integer = 9
   Public Const LUNGHEZZA_ORA_BREVE As Integer = 8

   Const TITOLO_FINESTRA As String = "Visual POS - GESTIONE TAVOLI"

   Public Const ANAG_TAVOLI As String = "Tavoli"
   Const TAB_CONTI_TAVOLI As String = "ContiTavoli"
   Const TAB_SALE As String = "Sale"
   Const TAB_PREN As String = "Prenotazioni"
   Const TAB_COMANDE As String = "Comande"
   Const TAB_PIATTI_ESAURITI As String = "PiattiEsauriti"
   Const TAB_CATEGORIE As String = "CategoriePiatti"
   Const TAB_MESSAGGI As String = "Messaggi"
   Const TAB_POS_IMPOSTAZIONI_TAVOLI As String = "POS_ImpostazioniTavoli"

   Const TESTO_BTN_QUADRO_PULSANTI As String = "Visualizza tasti"
   Const TESTO_BTN_QUADRO_PIANTINA As String = "Visualizza piantina"

   ' Colori utilizzati per la gestione dei Tavoli.
   Public TAVOLO_LIBERO As Color = Color.MediumSeaGreen
   Public TAVOLO_PRENOTATO As Color = Color.DodgerBlue
   Public TAVOLO_DEVE_ORDINARE As Color = Color.LightCoral
   Public TAVOLO_DA_SERVIRE As Color = Color.Brown
   Public TAVOLO_SERVITO As Color = Color.Gray
   Public TAVOLO_ATTESA_CONTO As Color = Color.DarkCyan
   Public TAVOLO_DA_LIBERARE As Color = Color.Olive

   Public Risorsa() As NetButton
   Public NumRisorse As Integer = 0
   Public Sala() As NetButton
    Public NumSale As Integer = 0
    ' Stato occupazione dei tavoli.
    Public IndiceTavoloOccupato() As Integer
   Public NumTavoliOccupati As Integer = 0
   Public OraOccupazione() As DateTime

   'Public infoNuovaRisorsa As String = ""

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)
   Private CFormatta As New ClsFormatta

   Private dataOggi As String = FormattaData(Today.ToShortDateString, False)
   Public tavoloSelezionato As Integer
   Private salaSelezionata As String
   Private salaSel As String

   ' Per il tavolo da spostare.
   Private spostaTavoloId As String
   Private spostaTavoloColore As Color
   Private spostaTavoloNum As Short

   ' Per la gestione dei palmari.
   Public modificatoStatoTavolo As Boolean = False

   Private ultimoReparto As String

   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0

   ' Tipo di Quadro da visualizzare. (True = Pulsanti / False = Piantina).
   Public quadroPulsanti As Boolean = True

   Dim muoviPulsanti As Boolean = False
   Dim cursorOffset As Point

   Private impostaListino As Boolean

   ' B_TODO: Codice da attivare per il comando Unisci.
   ' Per il tavolo da unire.
   'Private unisciTavoloId As String
   'Private unisciTavoloNum As Short

   Public copertiAnnulla As Boolean
   Public asportoAnnulla As Boolean

   Private NumListino As Short
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents netBtn_Occupa As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Apri As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Libera As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Sposta As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Esauriti As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Prenota As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Asporto As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_PuntoCassa As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Esci As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_BarraTavoli As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_TavoliSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_TavoliGiù As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_SalaSu As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_SalaGiù As Softgroup.NetButton.NetButton
   Friend WithEvents pnlSale As System.Windows.Forms.Panel
   Friend WithEvents pnlPulsanti As System.Windows.Forms.Panel
   Friend WithEvents picImmagine As System.Windows.Forms.PictureBox
   Friend WithEvents netBtn_VisualizzaQuadro As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_Listino As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_PosizionaTavoli As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_ListaPrenSu As NetButton
   Friend WithEvents netBtn_ListaPrenGiù As NetButton
   Friend WithEvents colonnaOraOrdine As ColumnHeader
   Friend WithEvents colonnaOraRitiro As ColumnHeader
   Friend WithEvents lblInvioComande As Label
   Friend WithEvents netBtn_Impostazioni As NetButton

   Public Enum Listino As Short
      Uno = 1
      Due = 2
      Tre = 3
      Quattro = 4
   End Enum

#End Region

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

      'ReDim Categorie(LeggiNumRecord(TAB_CATEGORIE))
      'ReDim Piatti(LeggiNumRecord(TAB_PIATTI))
      'ReDim Variazioni(LeggiNumRecord(TAB_PIATTI))

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

   'NOTE: la procedura che segue è richiesta da Progettazione Windows Form.
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
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents lblData As System.Windows.Forms.Label
   Friend WithEvents lblOra As System.Windows.Forms.Label
   Public WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents lblPrenAsporto As System.Windows.Forms.Label
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents colonnaCliente As System.Windows.Forms.ColumnHeader
   Friend WithEvents colonnaDalle As System.Windows.Forms.ColumnHeader
   Friend WithEvents colonnaAlle As System.Windows.Forms.ColumnHeader
   Friend WithEvents colonnaCoperti As System.Windows.Forms.ColumnHeader
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents pnlPiantina As System.Windows.Forms.Panel
   Friend WithEvents lblTavolo As System.Windows.Forms.Label
   Friend WithEvents lblPosti As System.Windows.Forms.Label
   Friend WithEvents lblCoperti As System.Windows.Forms.Label
   Friend WithEvents lblCameriere As System.Windows.Forms.Label
   Friend WithEvents pnlLegenda As System.Windows.Forms.Panel
   Friend WithEvents lblInCorso As System.Windows.Forms.Label
   Friend WithEvents lblScaduta As System.Windows.Forms.Label
   Friend WithEvents lblVostraCanc As System.Windows.Forms.Label
   Friend WithEvents lblNostraCanc As System.Windows.Forms.Label
   Friend WithEvents lblSospesa As System.Windows.Forms.Label
   Friend WithEvents lblConfermata As System.Windows.Forms.Label
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents Timer2 As System.Windows.Forms.Timer
   Friend WithEvents LblPostiLiberi As System.Windows.Forms.Label
   Friend WithEvents lblLiberi As System.Windows.Forms.Label
   Friend WithEvents lblOccupati As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents lblOraOcc As System.Windows.Forms.Label
   Friend WithEvents txtNotePren As System.Windows.Forms.TextBox
   Friend WithEvents colonnaNote As System.Windows.Forms.ColumnHeader
   Friend WithEvents Timer3 As System.Windows.Forms.Timer

   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVCTavoli))
      Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Luigi Montana", "12.30", "13.30", "10", ""}, -1)
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.lblTavolo = New System.Windows.Forms.Label()
      Me.cmd8 = New System.Windows.Forms.Button()
      Me.cmd7 = New System.Windows.Forms.Button()
      Me.cmd6 = New System.Windows.Forms.Button()
      Me.cmd1 = New System.Windows.Forms.Button()
      Me.cmd2 = New System.Windows.Forms.Button()
      Me.cmd3 = New System.Windows.Forms.Button()
      Me.cmd4 = New System.Windows.Forms.Button()
      Me.cmd5 = New System.Windows.Forms.Button()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.lblInCorso = New System.Windows.Forms.Label()
      Me.lblScaduta = New System.Windows.Forms.Label()
      Me.lblVostraCanc = New System.Windows.Forms.Label()
      Me.lblNostraCanc = New System.Windows.Forms.Label()
      Me.lblSospesa = New System.Windows.Forms.Label()
      Me.lblConfermata = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.lblData = New System.Windows.Forms.Label()
      Me.lblOra = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.lblPosti = New System.Windows.Forms.Label()
      Me.lblCoperti = New System.Windows.Forms.Label()
      Me.LblPostiLiberi = New System.Windows.Forms.Label()
      Me.lblPrenAsporto = New System.Windows.Forms.Label()
      Me.lstvDettagli = New System.Windows.Forms.ListView()
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaCliente = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaDalle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaAlle = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaCoperti = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaNote = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaOraOrdine = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaOraRitiro = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Label16 = New System.Windows.Forms.Label()
      Me.pnlPiantina = New System.Windows.Forms.Panel()
      Me.picImmagine = New System.Windows.Forms.PictureBox()
      Me.lblCameriere = New System.Windows.Forms.Label()
      Me.pnlLegenda = New System.Windows.Forms.Panel()
      Me.lblInvioComande = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
      Me.lblLiberi = New System.Windows.Forms.Label()
      Me.lblOccupati = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.lblOraOcc = New System.Windows.Forms.Label()
      Me.txtNotePren = New System.Windows.Forms.TextBox()
      Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.netBtn_Occupa = New Softgroup.NetButton.NetButton()
      Me.netBtn_Apri = New Softgroup.NetButton.NetButton()
      Me.netBtn_Libera = New Softgroup.NetButton.NetButton()
      Me.netBtn_Sposta = New Softgroup.NetButton.NetButton()
      Me.netBtn_Asporto = New Softgroup.NetButton.NetButton()
      Me.netBtn_Prenota = New Softgroup.NetButton.NetButton()
      Me.netBtn_Esauriti = New Softgroup.NetButton.NetButton()
      Me.netBtn_PuntoCassa = New Softgroup.NetButton.NetButton()
      Me.netBtn_Esci = New Softgroup.NetButton.NetButton()
      Me.netBtn_BarraTavoli = New Softgroup.NetButton.NetButton()
      Me.netBtn_TavoliSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_TavoliGiù = New Softgroup.NetButton.NetButton()
      Me.netBtn_SalaSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_SalaGiù = New Softgroup.NetButton.NetButton()
      Me.pnlSale = New System.Windows.Forms.Panel()
      Me.pnlPulsanti = New System.Windows.Forms.Panel()
      Me.netBtn_VisualizzaQuadro = New Softgroup.NetButton.NetButton()
      Me.netBtn_Listino = New Softgroup.NetButton.NetButton()
      Me.netBtn_PosizionaTavoli = New Softgroup.NetButton.NetButton()
      Me.netBtn_Impostazioni = New Softgroup.NetButton.NetButton()
      Me.netBtn_ListaPrenSu = New Softgroup.NetButton.NetButton()
      Me.netBtn_ListaPrenGiù = New Softgroup.NetButton.NetButton()
      Me.pnlPiantina.SuspendLayout()
      CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.pnlLegenda.SuspendLayout()
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
      'lblTavolo
      '
      Me.lblTavolo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTavolo.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblTavolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTavolo.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblTavolo.Location = New System.Drawing.Point(681, 61)
      Me.lblTavolo.Name = "lblTavolo"
      Me.lblTavolo.Size = New System.Drawing.Size(128, 40)
      Me.lblTavolo.TabIndex = 76
      Me.lblTavolo.Text = "#"
      Me.lblTavolo.TextAlign = System.Drawing.ContentAlignment.BottomRight
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
      'lblInCorso
      '
      Me.lblInCorso.BackColor = System.Drawing.Color.DarkCyan
      Me.lblInCorso.ForeColor = System.Drawing.Color.White
      Me.lblInCorso.Location = New System.Drawing.Point(553, 0)
      Me.lblInCorso.Name = "lblInCorso"
      Me.lblInCorso.Size = New System.Drawing.Size(92, 16)
      Me.lblInCorso.TabIndex = 6
      Me.lblInCorso.Text = "Attesa conto"
      Me.lblInCorso.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblScaduta
      '
      Me.lblScaduta.BackColor = System.Drawing.Color.Silver
      Me.lblScaduta.ForeColor = System.Drawing.Color.White
      Me.lblScaduta.ImageAlign = System.Drawing.ContentAlignment.TopRight
      Me.lblScaduta.Location = New System.Drawing.Point(461, 0)
      Me.lblScaduta.Name = "lblScaduta"
      Me.lblScaduta.Size = New System.Drawing.Size(92, 16)
      Me.lblScaduta.TabIndex = 5
      Me.lblScaduta.Text = "Servito"
      Me.lblScaduta.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblVostraCanc
      '
      Me.lblVostraCanc.BackColor = System.Drawing.Color.Brown
      Me.lblVostraCanc.ForeColor = System.Drawing.Color.White
      Me.lblVostraCanc.Location = New System.Drawing.Point(369, 0)
      Me.lblVostraCanc.Name = "lblVostraCanc"
      Me.lblVostraCanc.Size = New System.Drawing.Size(92, 16)
      Me.lblVostraCanc.TabIndex = 4
      Me.lblVostraCanc.Text = "Da servire"
      Me.lblVostraCanc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblNostraCanc
      '
      Me.lblNostraCanc.BackColor = System.Drawing.Color.LightCoral
      Me.lblNostraCanc.ForeColor = System.Drawing.Color.White
      Me.lblNostraCanc.Location = New System.Drawing.Point(277, 0)
      Me.lblNostraCanc.Name = "lblNostraCanc"
      Me.lblNostraCanc.Size = New System.Drawing.Size(92, 16)
      Me.lblNostraCanc.TabIndex = 3
      Me.lblNostraCanc.Text = "Deve ordinare"
      Me.lblNostraCanc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblSospesa
      '
      Me.lblSospesa.BackColor = System.Drawing.Color.DodgerBlue
      Me.lblSospesa.ForeColor = System.Drawing.Color.White
      Me.lblSospesa.Location = New System.Drawing.Point(181, 0)
      Me.lblSospesa.Name = "lblSospesa"
      Me.lblSospesa.Size = New System.Drawing.Size(96, 16)
      Me.lblSospesa.TabIndex = 2
      Me.lblSospesa.Text = "Prenotato"
      Me.lblSospesa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblConfermata
      '
      Me.lblConfermata.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.lblConfermata.ForeColor = System.Drawing.Color.White
      Me.lblConfermata.ImageAlign = System.Drawing.ContentAlignment.TopRight
      Me.lblConfermata.Location = New System.Drawing.Point(89, 0)
      Me.lblConfermata.Name = "lblConfermata"
      Me.lblConfermata.Size = New System.Drawing.Size(92, 16)
      Me.lblConfermata.TabIndex = 1
      Me.lblConfermata.Text = "Libero"
      Me.lblConfermata.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Label5
      '
      Me.Label5.BackColor = System.Drawing.Color.Olive
      Me.Label5.ForeColor = System.Drawing.Color.White
      Me.Label5.Location = New System.Drawing.Point(645, 0)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(92, 16)
      Me.Label5.TabIndex = 7
      Me.Label5.Text = "Da liberare"
      Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblData
      '
      Me.lblData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblData.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblData.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblData.Location = New System.Drawing.Point(521, 8)
      Me.lblData.Name = "lblData"
      Me.lblData.Size = New System.Drawing.Size(280, 24)
      Me.lblData.TabIndex = 79
      Me.lblData.Text = "#"
      Me.lblData.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblOra
      '
      Me.lblOra.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblOra.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblOra.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblOra.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblOra.Location = New System.Drawing.Point(521, 29)
      Me.lblOra.Name = "lblOra"
      Me.lblOra.Size = New System.Drawing.Size(280, 16)
      Me.lblOra.TabIndex = 80
      Me.lblOra.Text = "#"
      Me.lblOra.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label2.Location = New System.Drawing.Point(505, 0)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(312, 184)
      Me.Label2.TabIndex = 81
      Me.Label2.TextAlign = System.Drawing.ContentAlignment.BottomRight
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label7.Location = New System.Drawing.Point(521, 120)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(84, 16)
      Me.Label7.TabIndex = 83
      Me.Label7.Text = "Cameriere:"
      Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Timer1
      '
      Me.Timer1.Enabled = True
      Me.Timer1.Interval = 1000
      '
      'dtpData
      '
      Me.dtpData.Location = New System.Drawing.Point(-200, 576)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(200, 20)
      Me.dtpData.TabIndex = 86
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label6.Location = New System.Drawing.Point(513, 61)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(176, 40)
      Me.Label6.TabIndex = 82
      Me.Label6.Text = "TAVOLO:"
      Me.Label6.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'lblPosti
      '
      Me.lblPosti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPosti.AutoSize = True
      Me.lblPosti.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblPosti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblPosti.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblPosti.Location = New System.Drawing.Point(568, 96)
      Me.lblPosti.Name = "lblPosti"
      Me.lblPosti.Size = New System.Drawing.Size(16, 16)
      Me.lblPosti.TabIndex = 247
      Me.lblPosti.Text = "#"
      Me.lblPosti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblCoperti
      '
      Me.lblCoperti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCoperti.AutoSize = True
      Me.lblCoperti.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblCoperti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCoperti.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblCoperti.Location = New System.Drawing.Point(678, 96)
      Me.lblCoperti.Name = "lblCoperti"
      Me.lblCoperti.Size = New System.Drawing.Size(16, 16)
      Me.lblCoperti.TabIndex = 248
      Me.lblCoperti.Text = "#"
      Me.lblCoperti.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'LblPostiLiberi
      '
      Me.LblPostiLiberi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.LblPostiLiberi.AutoSize = True
      Me.LblPostiLiberi.BackColor = System.Drawing.Color.MidnightBlue
      Me.LblPostiLiberi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.LblPostiLiberi.ForeColor = System.Drawing.Color.DodgerBlue
      Me.LblPostiLiberi.Location = New System.Drawing.Point(769, 96)
      Me.LblPostiLiberi.Name = "LblPostiLiberi"
      Me.LblPostiLiberi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.LblPostiLiberi.Size = New System.Drawing.Size(16, 16)
      Me.LblPostiLiberi.TabIndex = 249
      Me.LblPostiLiberi.Text = "#"
      Me.LblPostiLiberi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblPrenAsporto
      '
      Me.lblPrenAsporto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPrenAsporto.BackColor = System.Drawing.Color.White
      Me.lblPrenAsporto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lblPrenAsporto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblPrenAsporto.ForeColor = System.Drawing.Color.Black
      Me.lblPrenAsporto.Location = New System.Drawing.Point(505, 184)
      Me.lblPrenAsporto.Name = "lblPrenAsporto"
      Me.lblPrenAsporto.Size = New System.Drawing.Size(312, 22)
      Me.lblPrenAsporto.TabIndex = 250
      Me.lblPrenAsporto.Text = "[ PRENOTAZIONI DEL GIORNO ]"
      Me.lblPrenAsporto.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lstvDettagli
      '
      Me.lstvDettagli.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagli.BackColor = System.Drawing.Color.White
      Me.lstvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.colonnaCliente, Me.colonnaDalle, Me.colonnaAlle, Me.colonnaCoperti, Me.colonnaNote, Me.colonnaOraOrdine, Me.colonnaOraRitiro})
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me.lstvDettagli.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
      Me.lstvDettagli.Location = New System.Drawing.Point(505, 205)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(312, 251)
      Me.lstvDettagli.TabIndex = 12
      Me.lstvDettagli.UseCompatibleStateImageBehavior = False
      Me.lstvDettagli.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Width = 0
      '
      'colonnaCliente
      '
      Me.colonnaCliente.Text = "Cliente"
      Me.colonnaCliente.Width = 140
      '
      'colonnaDalle
      '
      Me.colonnaDalle.Text = "Dalle"
      Me.colonnaDalle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.colonnaDalle.Width = 50
      '
      'colonnaAlle
      '
      Me.colonnaAlle.Text = "Alle"
      Me.colonnaAlle.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.colonnaAlle.Width = 50
      '
      'colonnaCoperti
      '
      Me.colonnaCoperti.Text = "Cop."
      Me.colonnaCoperti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.colonnaCoperti.Width = 50
      '
      'colonnaNote
      '
      Me.colonnaNote.Width = 0
      '
      'colonnaOraOrdine
      '
      Me.colonnaOraOrdine.Text = "Ora Ordine"
      Me.colonnaOraOrdine.Width = 0
      '
      'colonnaOraRitiro
      '
      Me.colonnaOraRitiro.Text = "Ora Ritiro / Consegna"
      Me.colonnaOraRitiro.Width = 0
      '
      'Label16
      '
      Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label16.BackColor = System.Drawing.Color.White
      Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(505, 455)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(312, 138)
      Me.Label16.TabIndex = 260
      Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'pnlPiantina
      '
      Me.pnlPiantina.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlPiantina.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.pnlPiantina.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.pnlPiantina.Controls.Add(Me.picImmagine)
      Me.pnlPiantina.Location = New System.Drawing.Point(149, 8)
      Me.pnlPiantina.Name = "pnlPiantina"
      Me.pnlPiantina.Size = New System.Drawing.Size(217, 706)
      Me.pnlPiantina.TabIndex = 0
      '
      'picImmagine
      '
      Me.picImmagine.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.picImmagine.Dock = System.Windows.Forms.DockStyle.Fill
      Me.picImmagine.Image = CType(resources.GetObject("picImmagine.Image"), System.Drawing.Image)
      Me.picImmagine.Location = New System.Drawing.Point(0, 0)
      Me.picImmagine.Name = "picImmagine"
      Me.picImmagine.Size = New System.Drawing.Size(215, 704)
      Me.picImmagine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picImmagine.TabIndex = 228
      Me.picImmagine.TabStop = False
      '
      'lblCameriere
      '
      Me.lblCameriere.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCameriere.AutoSize = True
      Me.lblCameriere.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblCameriere.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCameriere.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblCameriere.Location = New System.Drawing.Point(602, 120)
      Me.lblCameriere.Name = "lblCameriere"
      Me.lblCameriere.Size = New System.Drawing.Size(16, 16)
      Me.lblCameriere.TabIndex = 263
      Me.lblCameriere.Text = "#"
      Me.lblCameriere.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'pnlLegenda
      '
      Me.pnlLegenda.BackColor = System.Drawing.Color.Black
      Me.pnlLegenda.Controls.Add(Me.lblInvioComande)
      Me.pnlLegenda.Controls.Add(Me.Label5)
      Me.pnlLegenda.Controls.Add(Me.lblInCorso)
      Me.pnlLegenda.Controls.Add(Me.lblScaduta)
      Me.pnlLegenda.Controls.Add(Me.lblVostraCanc)
      Me.pnlLegenda.Controls.Add(Me.lblNostraCanc)
      Me.pnlLegenda.Controls.Add(Me.lblSospesa)
      Me.pnlLegenda.Controls.Add(Me.lblConfermata)
      Me.pnlLegenda.Controls.Add(Me.Label3)
      Me.pnlLegenda.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.pnlLegenda.Location = New System.Drawing.Point(0, 721)
      Me.pnlLegenda.Name = "pnlLegenda"
      Me.pnlLegenda.Size = New System.Drawing.Size(820, 16)
      Me.pnlLegenda.TabIndex = 264
      '
      'lblInvioComande
      '
      Me.lblInvioComande.AutoSize = True
      Me.lblInvioComande.BackColor = System.Drawing.Color.Black
      Me.lblInvioComande.ForeColor = System.Drawing.SystemColors.Window
      Me.lblInvioComande.Location = New System.Drawing.Point(743, 2)
      Me.lblInvioComande.Name = "lblInvioComande"
      Me.lblInvioComande.Size = New System.Drawing.Size(150, 13)
      Me.lblInvioComande.TabIndex = 8
      Me.lblInvioComande.Text = "Ricezione comande in corso..."
      Me.lblInvioComande.TextAlign = System.Drawing.ContentAlignment.TopCenter
      '
      'Label3
      '
      Me.Label3.BackColor = System.Drawing.Color.Black
      Me.Label3.ForeColor = System.Drawing.SystemColors.Window
      Me.Label3.Location = New System.Drawing.Point(8, -1)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(80, 18)
      Me.Label3.TabIndex = 0
      Me.Label3.Text = "Legenda:"
      Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label8.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label8.Location = New System.Drawing.Point(521, 144)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(119, 16)
      Me.Label8.TabIndex = 265
      Me.Label8.Text = "Tavoli occupati:"
      Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label11
      '
      Me.Label11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label11.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label11.Location = New System.Drawing.Point(673, 144)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(95, 16)
      Me.Label11.TabIndex = 266
      Me.Label11.Text = "Tavoli liberi:"
      Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Timer2
      '
      Me.Timer2.Enabled = True
      Me.Timer2.Interval = 1000
      '
      'lblLiberi
      '
      Me.lblLiberi.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblLiberi.AutoSize = True
      Me.lblLiberi.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblLiberi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblLiberi.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblLiberi.Location = New System.Drawing.Point(761, 144)
      Me.lblLiberi.Name = "lblLiberi"
      Me.lblLiberi.Size = New System.Drawing.Size(16, 16)
      Me.lblLiberi.TabIndex = 267
      Me.lblLiberi.Text = "#"
      Me.lblLiberi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblOccupati
      '
      Me.lblOccupati.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblOccupati.AutoSize = True
      Me.lblOccupati.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblOccupati.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblOccupati.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblOccupati.Location = New System.Drawing.Point(633, 144)
      Me.lblOccupati.Name = "lblOccupati"
      Me.lblOccupati.Size = New System.Drawing.Size(16, 16)
      Me.lblOccupati.TabIndex = 268
      Me.lblOccupati.Text = "#"
      Me.lblOccupati.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label4
      '
      Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label4.Location = New System.Drawing.Point(521, 96)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(47, 16)
      Me.Label4.TabIndex = 269
      Me.Label4.Text = "Posti:"
      Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label12
      '
      Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label12.AutoSize = True
      Me.Label12.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label12.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label12.Location = New System.Drawing.Point(617, 96)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(62, 16)
      Me.Label12.TabIndex = 270
      Me.Label12.Text = "Coperti:"
      Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label13
      '
      Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label13.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label13.Location = New System.Drawing.Point(721, 96)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(51, 16)
      Me.Label13.TabIndex = 271
      Me.Label13.Text = "Liberi:"
      Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblOraOcc
      '
      Me.lblOraOcc.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblOraOcc.AutoSize = True
      Me.lblOraOcc.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblOraOcc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblOraOcc.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblOraOcc.Location = New System.Drawing.Point(517, 56)
      Me.lblOraOcc.Name = "lblOraOcc"
      Me.lblOraOcc.Size = New System.Drawing.Size(15, 13)
      Me.lblOraOcc.TabIndex = 272
      Me.lblOraOcc.Text = "#"
      Me.lblOraOcc.TextAlign = System.Drawing.ContentAlignment.TopCenter
      Me.lblOraOcc.Visible = False
      '
      'txtNotePren
      '
      Me.txtNotePren.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNotePren.BackColor = System.Drawing.Color.White
      Me.txtNotePren.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.txtNotePren.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNotePren.ForeColor = System.Drawing.Color.Black
      Me.txtNotePren.Location = New System.Drawing.Point(507, 462)
      Me.txtNotePren.MaxLength = 0
      Me.txtNotePren.Multiline = True
      Me.txtNotePren.Name = "txtNotePren"
      Me.txtNotePren.ReadOnly = True
      Me.txtNotePren.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.txtNotePren.Size = New System.Drawing.Size(308, 128)
      Me.txtNotePren.TabIndex = 13
      '
      'Timer3
      '
      Me.Timer3.Interval = 15000
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'netBtn_Occupa
      '
      Me.netBtn_Occupa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Occupa.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Occupa.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Occupa.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Occupa.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Occupa.ColorText = System.Drawing.Color.White
      Me.netBtn_Occupa.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Occupa.CornerRadius = 2
      Me.netBtn_Occupa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Occupa.Location = New System.Drawing.Point(371, 122)
      Me.netBtn_Occupa.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Occupa.Name = "netBtn_Occupa"
      Me.netBtn_Occupa.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Occupa.TabIndex = 275
      Me.netBtn_Occupa.TextButton = "Occupa"
      '
      'netBtn_Apri
      '
      Me.netBtn_Apri.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Apri.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(40, Byte), Integer))
      Me.netBtn_Apri.ColorDisabled = System.Drawing.Color.SeaGreen
      Me.netBtn_Apri.ColorLight = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(189, Byte), Integer))
      Me.netBtn_Apri.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Green
      Me.netBtn_Apri.ColorText = System.Drawing.Color.Black
      Me.netBtn_Apri.ColorTop = System.Drawing.Color.White
      Me.netBtn_Apri.CornerRadius = 2
      Me.netBtn_Apri.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Apri.Location = New System.Drawing.Point(371, 65)
      Me.netBtn_Apri.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Apri.Name = "netBtn_Apri"
      Me.netBtn_Apri.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Apri.TabIndex = 274
      Me.netBtn_Apri.TextButton = "Apri"
      '
      'netBtn_Libera
      '
      Me.netBtn_Libera.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Libera.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Libera.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Libera.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Libera.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Libera.ColorText = System.Drawing.Color.White
      Me.netBtn_Libera.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Libera.CornerRadius = 2
      Me.netBtn_Libera.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Libera.Location = New System.Drawing.Point(371, 179)
      Me.netBtn_Libera.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Libera.Name = "netBtn_Libera"
      Me.netBtn_Libera.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Libera.TabIndex = 273
      Me.netBtn_Libera.TextButton = "Libera"
      '
      'netBtn_Sposta
      '
      Me.netBtn_Sposta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Sposta.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Sposta.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Sposta.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Sposta.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Sposta.ColorText = System.Drawing.Color.White
      Me.netBtn_Sposta.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Sposta.CornerRadius = 2
      Me.netBtn_Sposta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Sposta.Location = New System.Drawing.Point(371, 236)
      Me.netBtn_Sposta.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Sposta.Name = "netBtn_Sposta"
      Me.netBtn_Sposta.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Sposta.TabIndex = 276
      Me.netBtn_Sposta.TextButton = "Sposta"
      '
      'netBtn_Asporto
      '
      Me.netBtn_Asporto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Asporto.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_Asporto.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Asporto.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Asporto.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Asporto.ColorText = System.Drawing.SystemColors.ControlText
      Me.netBtn_Asporto.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Asporto.CornerRadius = 2
      Me.netBtn_Asporto.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Asporto.Location = New System.Drawing.Point(371, 351)
      Me.netBtn_Asporto.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Asporto.Name = "netBtn_Asporto"
      Me.netBtn_Asporto.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Asporto.TabIndex = 300
      Me.netBtn_Asporto.TextButton = "Asporto"
      '
      'netBtn_Prenota
      '
      Me.netBtn_Prenota.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Prenota.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_Prenota.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_Prenota.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_Prenota.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_Prenota.ColorText = System.Drawing.Color.Black
      Me.netBtn_Prenota.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_Prenota.CornerRadius = 2
      Me.netBtn_Prenota.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Prenota.Location = New System.Drawing.Point(371, 293)
      Me.netBtn_Prenota.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Prenota.Name = "netBtn_Prenota"
      Me.netBtn_Prenota.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Prenota.TabIndex = 301
      Me.netBtn_Prenota.TextButton = "Prenota"
      '
      'netBtn_Esauriti
      '
      Me.netBtn_Esauriti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Esauriti.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Esauriti.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Esauriti.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Esauriti.ColorText = System.Drawing.Color.White
      Me.netBtn_Esauriti.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Esauriti.CornerRadius = 2
      Me.netBtn_Esauriti.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Esauriti.Location = New System.Drawing.Point(371, 409)
      Me.netBtn_Esauriti.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Esauriti.Name = "netBtn_Esauriti"
      Me.netBtn_Esauriti.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Esauriti.TabIndex = 302
      Me.netBtn_Esauriti.TextButton = "Piatti esauriti"
      '
      'netBtn_PuntoCassa
      '
      Me.netBtn_PuntoCassa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_PuntoCassa.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(40, Byte), Integer))
      Me.netBtn_PuntoCassa.ColorDisabled = System.Drawing.Color.SeaGreen
      Me.netBtn_PuntoCassa.ColorLight = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(189, Byte), Integer))
      Me.netBtn_PuntoCassa.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Green
      Me.netBtn_PuntoCassa.ColorText = System.Drawing.Color.Black
      Me.netBtn_PuntoCassa.ColorTop = System.Drawing.Color.White
      Me.netBtn_PuntoCassa.CornerRadius = 2
      Me.netBtn_PuntoCassa.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_PuntoCassa.Location = New System.Drawing.Point(505, 658)
      Me.netBtn_PuntoCassa.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_PuntoCassa.Name = "netBtn_PuntoCassa"
      Me.netBtn_PuntoCassa.Size = New System.Drawing.Size(155, 56)
      Me.netBtn_PuntoCassa.TabIndex = 303
      Me.netBtn_PuntoCassa.TextButton = "Punto cassa"
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
      Me.netBtn_Esci.Location = New System.Drawing.Point(662, 658)
      Me.netBtn_Esci.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Esci.Name = "netBtn_Esci"
      Me.netBtn_Esci.Size = New System.Drawing.Size(155, 56)
      Me.netBtn_Esci.TabIndex = 304
      Me.netBtn_Esci.TextButton = "Esci"
      '
      'netBtn_BarraTavoli
      '
      Me.netBtn_BarraTavoli.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_BarraTavoli.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_BarraTavoli.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_BarraTavoli.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_BarraTavoli.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_BarraTavoli.ColorText = System.Drawing.Color.White
      Me.netBtn_BarraTavoli.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_BarraTavoli.CornerRadius = 2
      Me.netBtn_BarraTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_BarraTavoli.Location = New System.Drawing.Point(219, 659)
      Me.netBtn_BarraTavoli.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_BarraTavoli.Name = "netBtn_BarraTavoli"
      Me.netBtn_BarraTavoli.Size = New System.Drawing.Size(78, 56)
      Me.netBtn_BarraTavoli.TabIndex = 316
      Me.netBtn_BarraTavoli.Tag = ""
      Me.netBtn_BarraTavoli.TextButton = ""
      '
      'netBtn_TavoliSu
      '
      Me.netBtn_TavoliSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_TavoliSu.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_TavoliSu.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_TavoliSu.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_TavoliSu.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_TavoliSu.ColorText = System.Drawing.Color.White
      Me.netBtn_TavoliSu.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_TavoliSu.CornerRadius = 2
      Me.netBtn_TavoliSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_TavoliSu.Image = CType(resources.GetObject("netBtn_TavoliSu.Image"), System.Drawing.Image)
      Me.netBtn_TavoliSu.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_TavoliSu.Location = New System.Drawing.Point(298, 659)
      Me.netBtn_TavoliSu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_TavoliSu.Name = "netBtn_TavoliSu"
      Me.netBtn_TavoliSu.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_TavoliSu.TabIndex = 315
      Me.netBtn_TavoliSu.TextButton = ""
      '
      'netBtn_TavoliGiù
      '
      Me.netBtn_TavoliGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_TavoliGiù.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_TavoliGiù.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_TavoliGiù.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_TavoliGiù.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_TavoliGiù.ColorText = System.Drawing.Color.White
      Me.netBtn_TavoliGiù.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_TavoliGiù.CornerRadius = 2
      Me.netBtn_TavoliGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_TavoliGiù.Image = CType(resources.GetObject("netBtn_TavoliGiù.Image"), System.Drawing.Image)
      Me.netBtn_TavoliGiù.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_TavoliGiù.Location = New System.Drawing.Point(150, 659)
      Me.netBtn_TavoliGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_TavoliGiù.Name = "netBtn_TavoliGiù"
      Me.netBtn_TavoliGiù.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_TavoliGiù.TabIndex = 314
      Me.netBtn_TavoliGiù.TextButton = ""
      '
      'netBtn_SalaSu
      '
      Me.netBtn_SalaSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_SalaSu.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_SalaSu.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_SalaSu.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_SalaSu.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_SalaSu.ColorText = System.Drawing.Color.White
      Me.netBtn_SalaSu.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_SalaSu.CornerRadius = 2
      Me.netBtn_SalaSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_SalaSu.Image = CType(resources.GetObject("netBtn_SalaSu.Image"), System.Drawing.Image)
      Me.netBtn_SalaSu.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_SalaSu.Location = New System.Drawing.Point(77, 659)
      Me.netBtn_SalaSu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_SalaSu.Name = "netBtn_SalaSu"
      Me.netBtn_SalaSu.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_SalaSu.TabIndex = 313
      Me.netBtn_SalaSu.TextButton = ""
      '
      'netBtn_SalaGiù
      '
      Me.netBtn_SalaGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.netBtn_SalaGiù.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_SalaGiù.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_SalaGiù.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_SalaGiù.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_SalaGiù.ColorText = System.Drawing.Color.White
      Me.netBtn_SalaGiù.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_SalaGiù.CornerRadius = 2
      Me.netBtn_SalaGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_SalaGiù.Image = CType(resources.GetObject("netBtn_SalaGiù.Image"), System.Drawing.Image)
      Me.netBtn_SalaGiù.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_SalaGiù.Location = New System.Drawing.Point(8, 659)
      Me.netBtn_SalaGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_SalaGiù.Name = "netBtn_SalaGiù"
      Me.netBtn_SalaGiù.Size = New System.Drawing.Size(68, 56)
      Me.netBtn_SalaGiù.TabIndex = 312
      Me.netBtn_SalaGiù.TextButton = ""
      '
      'pnlSale
      '
      Me.pnlSale.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.pnlSale.Location = New System.Drawing.Point(8, 8)
      Me.pnlSale.Name = "pnlSale"
      Me.pnlSale.Size = New System.Drawing.Size(138, 645)
      Me.pnlSale.TabIndex = 310
      '
      'pnlPulsanti
      '
      Me.pnlPulsanti.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.pnlPulsanti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.pnlPulsanti.Location = New System.Drawing.Point(149, 8)
      Me.pnlPulsanti.Name = "pnlPulsanti"
      Me.pnlPulsanti.Size = New System.Drawing.Size(217, 644)
      Me.pnlPulsanti.TabIndex = 311
      '
      'netBtn_VisualizzaQuadro
      '
      Me.netBtn_VisualizzaQuadro.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_VisualizzaQuadro.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_VisualizzaQuadro.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_VisualizzaQuadro.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_VisualizzaQuadro.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_VisualizzaQuadro.ColorText = System.Drawing.Color.White
      Me.netBtn_VisualizzaQuadro.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_VisualizzaQuadro.CornerRadius = 2
      Me.netBtn_VisualizzaQuadro.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_VisualizzaQuadro.Location = New System.Drawing.Point(371, 523)
      Me.netBtn_VisualizzaQuadro.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_VisualizzaQuadro.Name = "netBtn_VisualizzaQuadro"
      Me.netBtn_VisualizzaQuadro.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_VisualizzaQuadro.TabIndex = 317
      Me.netBtn_VisualizzaQuadro.TextButton = "Visualizza piantina"
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
      Me.netBtn_Listino.Location = New System.Drawing.Point(371, 8)
      Me.netBtn_Listino.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Listino.Name = "netBtn_Listino"
      Me.netBtn_Listino.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Listino.TabIndex = 318
      Me.netBtn_Listino.TextButton = "Listino 1"
      '
      'netBtn_PosizionaTavoli
      '
      Me.netBtn_PosizionaTavoli.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_PosizionaTavoli.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.netBtn_PosizionaTavoli.ColorDisabled = System.Drawing.Color.Brown
      Me.netBtn_PosizionaTavoli.ColorLight = System.Drawing.Color.MistyRose
      Me.netBtn_PosizionaTavoli.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Red
      Me.netBtn_PosizionaTavoli.ColorText = System.Drawing.Color.Black
      Me.netBtn_PosizionaTavoli.ColorTop = System.Drawing.Color.White
      Me.netBtn_PosizionaTavoli.CornerRadius = 2
      Me.netBtn_PosizionaTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_PosizionaTavoli.Location = New System.Drawing.Point(371, 580)
      Me.netBtn_PosizionaTavoli.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_PosizionaTavoli.Name = "netBtn_PosizionaTavoli"
      Me.netBtn_PosizionaTavoli.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_PosizionaTavoli.TabIndex = 319
      Me.netBtn_PosizionaTavoli.TextButton = "Sblocca tavoli"
      Me.netBtn_PosizionaTavoli.Visible = False
      '
      'netBtn_Impostazioni
      '
      Me.netBtn_Impostazioni.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Impostazioni.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_Impostazioni.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_Impostazioni.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Impostazioni.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Impostazioni.ColorText = System.Drawing.Color.White
      Me.netBtn_Impostazioni.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_Impostazioni.CornerRadius = 2
      Me.netBtn_Impostazioni.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Impostazioni.Location = New System.Drawing.Point(371, 466)
      Me.netBtn_Impostazioni.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Impostazioni.Name = "netBtn_Impostazioni"
      Me.netBtn_Impostazioni.Size = New System.Drawing.Size(130, 56)
      Me.netBtn_Impostazioni.TabIndex = 320
      Me.netBtn_Impostazioni.TextButton = "Impostazioni"
      '
      'netBtn_ListaPrenSu
      '
      Me.netBtn_ListaPrenSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_ListaPrenSu.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_ListaPrenSu.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_ListaPrenSu.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_ListaPrenSu.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_ListaPrenSu.ColorText = System.Drawing.Color.White
      Me.netBtn_ListaPrenSu.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_ListaPrenSu.CornerRadius = 2
      Me.netBtn_ListaPrenSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_ListaPrenSu.Image = CType(resources.GetObject("netBtn_ListaPrenSu.Image"), System.Drawing.Image)
      Me.netBtn_ListaPrenSu.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_ListaPrenSu.Location = New System.Drawing.Point(662, 597)
      Me.netBtn_ListaPrenSu.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ListaPrenSu.Name = "netBtn_ListaPrenSu"
      Me.netBtn_ListaPrenSu.Size = New System.Drawing.Size(155, 56)
      Me.netBtn_ListaPrenSu.TabIndex = 323
      Me.netBtn_ListaPrenSu.TextButton = ""
      '
      'netBtn_ListaPrenGiù
      '
      Me.netBtn_ListaPrenGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_ListaPrenGiù.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_ListaPrenGiù.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_ListaPrenGiù.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_ListaPrenGiù.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_ListaPrenGiù.ColorText = System.Drawing.Color.White
      Me.netBtn_ListaPrenGiù.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_ListaPrenGiù.CornerRadius = 2
      Me.netBtn_ListaPrenGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_ListaPrenGiù.Image = CType(resources.GetObject("netBtn_ListaPrenGiù.Image"), System.Drawing.Image)
      Me.netBtn_ListaPrenGiù.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter
      Me.netBtn_ListaPrenGiù.Location = New System.Drawing.Point(505, 597)
      Me.netBtn_ListaPrenGiù.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_ListaPrenGiù.Name = "netBtn_ListaPrenGiù"
      Me.netBtn_ListaPrenGiù.Size = New System.Drawing.Size(155, 56)
      Me.netBtn_ListaPrenGiù.TabIndex = 322
      Me.netBtn_ListaPrenGiù.TextButton = ""
      '
      'frmVCTavoli
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(820, 737)
      Me.Controls.Add(Me.txtNotePren)
      Me.Controls.Add(Me.netBtn_ListaPrenSu)
      Me.Controls.Add(Me.netBtn_ListaPrenGiù)
      Me.Controls.Add(Me.netBtn_Impostazioni)
      Me.Controls.Add(Me.netBtn_PosizionaTavoli)
      Me.Controls.Add(Me.netBtn_Listino)
      Me.Controls.Add(Me.netBtn_BarraTavoli)
      Me.Controls.Add(Me.netBtn_TavoliSu)
      Me.Controls.Add(Me.netBtn_TavoliGiù)
      Me.Controls.Add(Me.netBtn_VisualizzaQuadro)
      Me.Controls.Add(Me.pnlPiantina)
      Me.Controls.Add(Me.netBtn_SalaSu)
      Me.Controls.Add(Me.netBtn_SalaGiù)
      Me.Controls.Add(Me.pnlSale)
      Me.Controls.Add(Me.pnlPulsanti)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.netBtn_Esci)
      Me.Controls.Add(Me.netBtn_PuntoCassa)
      Me.Controls.Add(Me.netBtn_Esauriti)
      Me.Controls.Add(Me.netBtn_Prenota)
      Me.Controls.Add(Me.netBtn_Asporto)
      Me.Controls.Add(Me.netBtn_Sposta)
      Me.Controls.Add(Me.netBtn_Occupa)
      Me.Controls.Add(Me.netBtn_Apri)
      Me.Controls.Add(Me.netBtn_Libera)
      Me.Controls.Add(Me.lblOraOcc)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.lblOccupati)
      Me.Controls.Add(Me.lblLiberi)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.lblCameriere)
      Me.Controls.Add(Me.LblPostiLiberi)
      Me.Controls.Add(Me.lblCoperti)
      Me.Controls.Add(Me.lblPosti)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.pnlLegenda)
      Me.Controls.Add(Me.lblPrenAsporto)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.lblData)
      Me.Controls.Add(Me.lblOra)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.lblTavolo)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label16)
      Me.ForeColor = System.Drawing.Color.Silver
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmVCTavoli"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Visual POS - GESTIONE TAVOLI"
      Me.pnlPiantina.ResumeLayout(False)
      CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).EndInit()
      Me.pnlLegenda.ResumeLayout(False)
      Me.pnlLegenda.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Function LeggiDatiConfigVisQuadro() As Boolean
      Try
         Dim DatiConfig As New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If DatiConfig.GetValue("QuadroPulsantiTavoli") = String.Empty Then
            ' Se non trova un'impostazione visualizza i pulsanti.
            Return True
         Else
            ' Visualizza il quadro salvato.
            Return Convert.ToBoolean(DatiConfig.GetValue("QuadroPulsantiTavoli"))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         ' In caso di errore visualizza i pulsanti.
         Return True

      End Try
   End Function

   Public Sub SalvaDatiConfigVisQuadro(ByVal val As Boolean)
      Try
         Dim DatiConfig As New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Salva la modalità di visualizzazione Pulsanti o Piantina del quadro Tavoli.
         DatiConfig.SetValue("QuadroPulsantiTavoli", val.ToString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ImpostaTastiFunzione()
      Try
         ' Tasto funzione - Listino 1.
         LeggiColoriTastiFunzione("Listino (1,2,3,4)", netBtn_Listino, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Apri.
         LeggiColoriTastiFunzione("Apri", netBtn_Apri, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Occupa.
         LeggiColoriTastiFunzione("Occupa", netBtn_Occupa, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Libera.
         LeggiColoriTastiFunzione("Libera", netBtn_Libera, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Sposta.
         LeggiColoriTastiFunzione("Sposta", netBtn_Sposta, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Prenota.
         LeggiColoriTastiFunzione("Prenota", netBtn_Prenota, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Asporto.
         LeggiColoriTastiFunzione("Asporto", netBtn_Asporto, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Piatti esauriti.
         LeggiColoriTastiFunzione("Piatti esauriti", netBtn_Esauriti, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Impostazioni.
         LeggiColoriTastiFunzione("Impostazioni", netBtn_Impostazioni, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Visualizza piantina.
         LeggiColoriTastiFunzione("Visualizza (piantina-tasti)", netBtn_VisualizzaQuadro, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Sblocca tavoli.
         LeggiColoriTastiFunzione("Tavoli (blocca-sblocca)", netBtn_PosizionaTavoli, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Punto cassa.
         LeggiColoriTastiFunzione("Punto cassa", netBtn_PuntoCassa, TAB_POS_IMPOSTAZIONI_TAVOLI)

         ' Tasto funzione - Esci.
         LeggiColoriTastiFunzione("Esci", netBtn_Esci, TAB_POS_IMPOSTAZIONI_TAVOLI)

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

   Private Sub DisegnaTavoliPiantina(ByVal nome As String, ByVal note As String, ByVal id As Integer, ByVal posX As Integer, ByVal posY As Integer, ByVal colore As Color)
      Try
         NumRisorse += 1
         Risorsa(NumRisorse) = New NetButton
         Risorsa(NumRisorse).Name = id.ToString
         Risorsa(NumRisorse).Tag = NumRisorse
         Risorsa(NumRisorse).Location = New Point(posX, posY)
         Risorsa(NumRisorse).Size = New Size(LARGHEZZA_TAVOLO_PIANTINA, ALTEZZA_TAVOLO_PIANTINA)
         Risorsa(NumRisorse).CornerRadius = 0
         Risorsa(NumRisorse).ColorStyle = NetButton.ColorStyleEnum.Custom
         Risorsa(NumRisorse).ColorBottom = colore
         Risorsa(NumRisorse).ColorText = Color.Black
         Risorsa(NumRisorse).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Risorsa(NumRisorse).TextButtonAlign = ContentAlignment.MiddleCenter
         Risorsa(NumRisorse).TextButton = nome
         Risorsa(NumRisorse).ImageAlign = ContentAlignment.TopCenter

         'If File.Exists(icona) = True Then
         '   Dim bmp As New Bitmap(icona)
         '   Risorsa(NumRisorse).Image = bmp
         'End If

         If note = "" Then
            ToolTip1.SetToolTip(Risorsa(NumRisorse), "Nessuna nota.")
         Else
            ToolTip1.SetToolTip(Risorsa(NumRisorse), note)
         End If

         pnlPiantina.Controls.Add(Risorsa(NumRisorse))

         Risorsa(NumRisorse).BringToFront()

         AddHandler Risorsa(NumRisorse).Click, AddressOf Risorsa_Click
         AddHandler Risorsa(NumRisorse).BackColorChanged, AddressOf Risorsa_BackColorChanged

         AddHandler Risorsa(NumRisorse).MouseMove, AddressOf Risorsa_MouseMove
         AddHandler Risorsa(NumRisorse).MouseUp, AddressOf Risorsa_MouseUp
         AddHandler Risorsa(NumRisorse).MouseDown, AddressOf Risorsa_MouseDown


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaTavoliPulsanti(ByVal nome As String, ByVal note As String, ByVal id As Integer, ByVal posX As Integer, ByVal posY As Integer, ByVal colore As Color)
      Try
         NumRisorse += 1
         Risorsa(NumRisorse) = New NetButton
         Risorsa(NumRisorse).Name = id.ToString
         Risorsa(NumRisorse).Tag = NumRisorse
         Risorsa(NumRisorse).Location = New Point(posX, posY)
         Risorsa(NumRisorse).Size = New Size(LARGHEZZA_TAVOLO_PULSANTI, ALTEZZA_TAVOLO_PULSANTI)
         Risorsa(NumRisorse).CornerRadius = 0
         Risorsa(NumRisorse).ColorStyle = NetButton.ColorStyleEnum.Custom
         Risorsa(NumRisorse).ColorBottom = colore
         Risorsa(NumRisorse).ColorText = Color.Black
         Risorsa(NumRisorse).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Risorsa(NumRisorse).TextButtonAlign = ContentAlignment.MiddleCenter
         Risorsa(NumRisorse).TextButton = nome
         Risorsa(NumRisorse).ImageAlign = ContentAlignment.TopCenter

         'If File.Exists(icona) = True Then
         '   Dim bmp As New Bitmap(icona)
         '   Risorsa(NumRisorse).Image = bmp
         'End If

         If note = "" Then
            ToolTip1.SetToolTip(Risorsa(NumRisorse), "Nessuna nota.")
         Else
            ToolTip1.SetToolTip(Risorsa(NumRisorse), note)
         End If

         pnlPulsanti.Controls.Add(Risorsa(NumRisorse))

         Risorsa(NumRisorse).BringToFront()

         AddHandler Risorsa(NumRisorse).Click, AddressOf Risorsa_Click
         'AddHandler Risorsa(NumRisorse).BackColorChanged, AddressOf Risorsa_BackColorChanged ' NON FUNZIONA!

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaSale(ByVal nome As String, ByVal id As Integer, ByVal altezza As Integer, ByVal iniziale As String, ByVal x As Integer, ByVal y As Integer, ByVal coloreSfondo As Color, ByVal coloreTesto As Color)
      Try
         NumSale += 1

         'Dim posX As Integer = CalcolaPosizioneCtrl(NumSale, DIM_SPAZIO, larghezza)

         Sala(NumSale) = New NetButton
         Sala(NumSale).Name = id.ToString
         Sala(NumSale).CornerRadius = 2
         Sala(NumSale).Tag = nome
         Sala(NumSale).Location = New Point(x, y)
         Sala(NumSale).Size = New Size(LARGHEZZA_SALE, altezza)
         Sala(NumSale).ColorStyle = NetButton.ColorStyleEnum.Custom
         'If iniziale = "Sì" Then
         '   Sala(NumSale).ColorBottom = Color.Orange
         'Else
         Sala(NumSale).ColorBottom = coloreSfondo
         'End If
         If iniziale = "Sì" Then
            Sala(NumSale).Enabled = False
         Else
            Sala(NumSale).Enabled = True
         End If

         Sala(NumSale).ColorText = coloreTesto
         Sala(NumSale).Font = New Font(FontFamily.GenericSansSerif, 11, FontStyle.Bold)
         Sala(NumSale).TextButton = nome

         pnlSale.Controls.Add(Sala(NumSale))

         Sala(NumSale).BringToFront()

         AddHandler Sala(NumSale).Click, AddressOf Sala_Click

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiDatiTavoli(ByVal tabella As String, ByVal sala As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim infoRisorse As String = ""
      Dim descrizione As String
      Dim posti As String
      Dim cameriere As String
      Dim listino As String
      Dim note As String
      Dim posX As Integer
      Dim posY As Integer
      Dim orientamento As String
      Dim dimensione As String
      Dim colore As String
      Dim ora As String
      Dim i As Integer = 0
      Dim datiTrovati As Boolean = False
      Dim CordX As Integer = 1
      Dim CordY As Integer = 1

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Sala = '" & sala & "' AND Escludi = 'No' ORDER BY OrdineTasto ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         NumTavoliOccupati = 0

         Do While dr.Read()
            i += 1

            If IsDBNull(dr.Item("Descrizione")) = False Then
               descrizione = dr.Item("Descrizione").ToString
            Else
               descrizione = ""
            End If
            If IsDBNull(dr.Item("Posti")) = False Then
               posti = dr.Item("Posti").ToString
            Else
               posti = "2"
            End If
            If IsDBNull(dr.Item("Cameriere")) = False Then
               cameriere = dr.Item("Cameriere").ToString
            Else
               cameriere = ""
            End If
            If IsDBNull(dr.Item("Listino")) = False Then
               listino = dr.Item("Listino").ToString
            Else
               listino = ""
            End If
            If IsDBNull(dr.Item("Note")) = False Then
               note = dr.Item("Note").ToString
            Else
               note = ""
            End If
            If IsDBNull(dr.Item("PosX")) = False Then
               posX = Convert.ToInt32(dr.Item("PosX"))
            Else
               posX = 0
            End If
            If IsDBNull(dr.Item("PosY")) = False Then
               posY = Convert.ToInt32(dr.Item("PosY"))
            Else
               posY = 0
            End If
            If IsDBNull(dr.Item("Orientamento")) = False Then
               orientamento = dr.Item("Orientamento").ToString
            Else
               orientamento = "Orizzontale"
            End If
            If IsDBNull(dr.Item("DimensioneTasto")) = False Then
               dimensione = dr.Item("DimensioneTasto").ToString
            Else
               dimensione = "Medio"
            End If

            If IsDBNull(dr.Item("Colore")) = False Then
               colore = dr.Item("Colore").ToString
            Else
               colore = Convert.ToString(Color.MediumSeaGreen.ToArgb)
            End If
            If IsDBNull(dr.Item("OraOcc")) = False Then
               If dr.Item("OraOcc").ToString <> "" Then
                  ora = dr.Item("OraOcc").ToString
               Else
                  ora = ""
               End If
            Else
               ora = ""
            End If

            infoRisorse = "Posti: " & posti & vbCrLf &
                          "Cameriere: " & cameriere & vbCrLf &
                          "Listino: " & listino & vbCrLf &
                          "Note: " & note

            If quadroPulsanti = True Then
               DisegnaTavoliPulsanti(descrizione, infoRisorse, Convert.ToInt32(dr.Item("Id")), CordX, CordY, Color.FromArgb(Convert.ToInt32(dr.Item("Colore"))))

               CordX = CordX + LARGHEZZA_TAVOLO_PULSANTI + DIM_SPAZIO

               If i = NUMERO_TAVOLI_RIGA Then
                  CordY = CordY + ALTEZZA_TAVOLO_PULSANTI + DIM_SPAZIO
                  CordX = 1
                  i = 0
               End If
            Else
               ImpostaDimensioniTavolo(posti, orientamento, dimensione)
               DisegnaTavoliPiantina(descrizione, infoRisorse, Convert.ToInt32(dr.Item("Id")), posX, posY, Color.FromArgb(Convert.ToInt32(colore)))
            End If

            If ora <> "" Then
               NumTavoliOccupati += 1
               OraOccupazione(NumTavoliOccupati - 1) = Convert.ToDateTime(ora)
               IndiceTavoloOccupato(NumTavoliOccupati - 1) = Convert.ToInt32(Risorsa(NumRisorse).Tag)
            End If

            datiTrovati = True
         Loop

         Return datiTrovati

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Function CalcolaLarghezzaTavolo() As Integer
      Try
         Dim larghezzaPulsante As Double = (pnlPulsanti.Width - (NUMERO_TAVOLI_RIGA * 2 + 3)) / NUMERO_TAVOLI_RIGA

         ' Calcola il 60% in più per il controllo NetButton.
         Return ((larghezzaPulsante * 60) / 100)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return LARGHEZZA_TAVOLO_PULSANTI

      End Try
   End Function

   Public Sub CancellaColorePren(ByVal indice As Integer)
      Try
         If Risorsa(indice).Visible = False Then
            Exit Sub
         End If

         If ConfrontaColore(Risorsa(indice).ColorBottom, Color.DodgerBlue, Color.DodgerBlue) = True Then
            Risorsa(indice).ColorBottom = Color.MediumSeaGreen
            ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(indice).Name, Color.MediumSeaGreen)
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub LeggiDatiPren(ByVal tabella As String, ByVal data As String, ByVal ora As String, ByVal numRec As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim idTavolo As Integer

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Data = #" & data & "# AND OraInizio <= #" & ora & "# ORDER BY OraInizio ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("IdRisorsa")) = False Then
               idTavolo = Convert.ToInt32(dr.Item("IdRisorsa"))
            Else
               idTavolo = 0
            End If

            Dim i As Integer = 0

            For i = 1 To numRec - 1
               If Risorsa(i).Visible = False Then
                  Exit For
               End If
               If Risorsa(i).Name = idTavolo.ToString Then
                  If ConfrontaColore(Risorsa(i).ColorBottom, Color.MediumSeaGreen, Color.MediumSeaGreen) = True Then
                     Risorsa(i).ColorBottom = Color.DodgerBlue
                     Risorsa(i).TextButton = ""
                     Risorsa(i).TextButton = dr.Item("DescrizioneRisorsa").ToString & vbCrLf & "[" & FormattaOreMinuti(dr.Item("OraInizio").ToString) & "]"
                     ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(i).Name, Color.DodgerBlue)
                  End If
                  Exit For
               End If
            Next i
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiDatiPrenTavolo(ByVal tabella As String, ByVal data As String, ByVal idRisorsa As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Data = #" & data & "# AND IdRisorsa = '" & idRisorsa & "' ORDER BY OraInizio ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         ' Pulisce la casella di testo per le note.
         txtNotePren.Text = String.Empty

         ' Pulisce la lista.
         lstvDettagli.Items.Clear()

         Do While dr.Read()
            ' Imposta il titolo della lista.
            lblPrenAsporto.Text = "[ PRENOTAZIONI DEL GIORNO ]"

            ' Indice
            lstvDettagli.Items.Add(lstvDettagli.Items.Count.ToString)

            ' Assegna il colore della prenotazione.
            If IsDBNull(dr.Item("Colore")) = False Then
               Dim colore As Integer = Convert.ToInt32(dr.Item("Colore"))
               If colore <> 0 And colore <> Color.White.ToArgb Then
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).BackColor = Color.FromArgb(colore)
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).ForeColor = Color.White
               End If
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).BackColor = Color.White
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).ForeColor = Color.Black
            End If

            ' Cliente
            colonnaCliente.Width = 140
            If IsDBNull(dr.Item("Cliente")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Cliente").ToString)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            colonnaDalle.Width = 50
            If IsDBNull(dr.Item("OraInizio")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(FormattaOreMinuti(dr.Item("OraInizio").ToString))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            colonnaAlle.Width = 50
            If IsDBNull(dr.Item("OraFine")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(FormattaOreMinuti(dr.Item("OraFine").ToString))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            colonnaCoperti.Width = 50
            If IsDBNull(dr.Item("Persone")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Persone").ToString)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            colonnaNote.Width = 0
            If IsDBNull(dr.Item("Note")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Note").ToString)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            colonnaOraOrdine.Width = 0
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

            colonnaOraRitiro.Width = 0
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiDatiAsportoTavolo(ByVal tabella As String, ByVal idRisorsa As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & idRisorsa & " ORDER BY OraRitiro ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         ' Pulisce la casella di testo per le note.
         txtNotePren.Text = String.Empty

         ' Pulisce la lista.
         lstvDettagli.Items.Clear()

         Do While dr.Read()
            ' Imposta il titolo della lista.
            lblPrenAsporto.Text = "[ DATI ASPORTO ]"

            ' Indice
            lstvDettagli.Items.Add(lstvDettagli.Items.Count.ToString)

            ' Cliente
            colonnaCliente.Width = 0
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

            colonnaDalle.Width = 0
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

            colonnaAlle.Width = 0
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

            colonnaCoperti.Width = 0
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)

            colonnaNote.Width = 0
            If IsDBNull(dr.Item("Note")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Note").ToString)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            colonnaOraOrdine.Width = 110
            If IsDBNull(dr.Item("OraOcc")) = False Then
               Dim oraOrdine As DateTime = Convert.ToDateTime(dr.Item("OraOcc"))
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(oraOrdine.ToShortTimeString)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
            End If

            colonnaOraRitiro.Width = 180
            If IsDBNull(dr.Item("OraRitiro")) = False Then
               Dim oraRitiro As DateTime = Convert.ToDateTime(dr.Item("OraRitiro"))
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(oraRitiro.ToShortTimeString)
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(String.Empty)
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub


   Public Function LeggiNumCopertiPren(ByVal tabella As String, ByVal val As String, ByVal id As Integer) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim coperti As Integer

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE idRisorsa = '" & id & "' AND Data = #" & val & "# ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("Persone")) = False Then
               coperti = Convert.ToInt32(dr.Item("Persone"))
            Else
               coperti = 0
            End If
         Loop

         Return coperti

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiNumCopertiOcc(ByVal tabella As String, ByVal id As Integer) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim coperti As Integer

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE id = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("Coperti")) = False Then
               If IsNumeric(dr.Item("Coperti")) = True Then
                  coperti = Convert.ToInt32(dr.Item("Coperti"))
               Else
                  coperti = 0
               End If
            Else
               coperti = 0
            End If
         Loop

         Return coperti

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Sub LeggiDatiTavolo(ByVal tabella As String, ByVal id As Integer)
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim infoRisorse As String = ""

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            If IsDBNull(dr.Item("Descrizione")) = False Then
               lblTavolo.Text = dr.Item("Descrizione").ToString
            Else
               lblTavolo.Text = ""
            End If
            If IsDBNull(dr.Item("Posti")) = False Then
               lblPosti.Text = dr.Item("Posti").ToString
            Else
               lblPosti.Text = ""
            End If
            If IsDBNull(dr.Item("Coperti")) = False Then
               lblCoperti.Text = dr.Item("Coperti").ToString
            Else
               lblCoperti.Text = ""
            End If
            If IsDBNull(dr.Item("Cameriere")) = False Then
               lblCameriere.Text = dr.Item("Cameriere").ToString
            Else
               lblCameriere.Text = ""
            End If

            Select Case dr.Item("Listino").ToString
               Case "1"
                  netBtn_Listino.TextButton = "Listino 1"
                  NumListino = Listino.Uno

               Case "2"
                  netBtn_Listino.TextButton = "Listino 2"
                  NumListino = Listino.Due

               Case "3"
                  netBtn_Listino.TextButton = "Listino 3"
                  NumListino = Listino.Tre

               Case "4"
                  netBtn_Listino.TextButton = "Listino 4"
                  NumListino = Listino.Quattro
            End Select

            If IsDBNull(dr.Item("OraOcc")) = False Then
               lblOraOcc.Text = dr.Item("OraOcc").ToString
            Else
               lblOraOcc.Text = ""
            End If

         Loop
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiDatiSale(ByVal tabella As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY OrdineTasto ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CordY As Integer = 0

         pnlSale.Controls.Clear()

         Do While dr.Read
            DisegnaSale(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), Convert.ToInt32(dr.Item("AltezzaTasto")), dr.Item("Iniziale").ToString, 0, CordY, Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))))

            ALTEZZA_SALE = Convert.ToInt32(dr.Item("AltezzaTasto"))
            CordY = CordY + ALTEZZA_SALE + 1
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Function LeggiNumPrenSale(ByVal tabella As String, ByVal val As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Sala = '{1}' AND Escludi = 'No'", tabella, val)
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

   Public Function VerificaAsportoTavolo(ByVal tabella As String, ByVal id As Integer) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim infoRisorse As String = ""

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            If IsDBNull(dr.Item("Coperti")) = False Then
               Return dr.Item("Coperti").ToString
            Else
               Return String.Empty
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function


   Public Sub CaricaImgSala(ByVal tabella As String, ByVal val As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & val & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            Dim imgSfondo As String = dr.Item("Sfondo").ToString

            If File.Exists(imgSfondo) = True Then
               Dim bmp As New Bitmap(imgSfondo)
               picImmagine.Image = bmp
            Else
               picImmagine.Image = Nothing
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Function CaricaSale() As Boolean
      ' 730 - Valore non più utilizzato perchè non compatibile con risoluzione 1024x748.
      'Const DIM_MAX As Short = 680
      'Const POS_INIZIALE As Short = 8

      'Dim dimControllo As Integer
      'dimControllo = CalcolaDimensioneCtrl(LeggiNumRecord(TAB_SALE, cn, cmd), DIM_MAX, DIM_SPAZIO)

      LeggiDatiSale(TAB_SALE)

      Dim iniziale As Boolean = False
      Dim i As Integer
      For i = 1 To NumSale
         ' If ConfrontaColore(Sala(i).ColorBottom, Color.LightCoral, Color.LightCoral) = True Then
         If Sala(i).Enabled = False Then
            Me.Text = TITOLO_FINESTRA & " - " & Sala(i).TextButton.ToUpper
            CaricaImgSala(TAB_SALE, Sala(i).Tag.ToString)
            salaSelezionata = Sala(i).Tag.ToString
            iniziale = True

            Return LeggiDatiTavoli(ANAG_TAVOLI, Sala(i).Tag.ToString)
         End If
      Next

      ' Nel caso non è impostata una sala iniziale carica la prima.
      If iniziale = False Then
         'Sala(1).ColorBottom = Color.LightCoral
         Me.Text = TITOLO_FINESTRA & " - " & Sala(1).TextButton.ToUpper
         Sala(1).Enabled = False
         CaricaImgSala(TAB_SALE, Sala(1).Tag.ToString)
         salaSelezionata = Sala(1).Tag.ToString

         Return LeggiDatiTavoli(ANAG_TAVOLI, Sala(1).Tag.ToString)
      End If

   End Function

   Private Sub ImpostaDimensioniTavolo(ByVal posti As String, ByVal orientamento As String, ByVal dimensione As String)
      Try
         Dim numPosti As Integer = CInt(posti)
         Dim altezza As Integer
         Dim larghezza As Integer

         Select Case dimensione
            Case "Piccolo"
               altezza = ALTEZZA_TAVOLI_PICCOLO
               larghezza = LARGHEZZA_TAVOLI_PICCOLO

            Case "Medio"
               altezza = ALTEZZA_TAVOLI_MEDIO
               larghezza = LARGHEZZA_TAVOLI_MEDIO

            Case "Grande"
               altezza = ALTEZZA_TAVOLI_GRANDE
               larghezza = LARGHEZZA_TAVOLI_GRANDE

         End Select

         ' Tavolo standard.
         If numPosti < 5 Then
            LARGHEZZA_TAVOLO_PIANTINA = larghezza
            ALTEZZA_TAVOLO_PIANTINA = altezza

            ' Tavolo più grande di 4 posti.
         ElseIf numPosti > 4 Then
            Dim menoQuattro As Integer = (numPosti - 4)
            Dim restoPosti As Integer = 0

            ' Se è dispari lo fa diventare pari.
            If (menoQuattro Mod 2) <> 0 Then
               restoPosti = menoQuattro + 1
            Else
               restoPosti = menoQuattro
            End If

            ' Posti da aggiungere.
            Dim postiDaAgg As Integer = ((restoPosti / 2) + 1)

            Select Case orientamento
               Case "Orizzontale"
                  If postiDaAgg <> 0 Then
                     LARGHEZZA_TAVOLO_PIANTINA = (postiDaAgg * larghezza)
                     ALTEZZA_TAVOLO_PIANTINA = altezza
                  End If

               Case "Verticale"
                  If postiDaAgg <> 0 Then
                     ALTEZZA_TAVOLO_PIANTINA = (postiDaAgg * altezza)
                     LARGHEZZA_TAVOLO_PIANTINA = larghezza
                  End If
            End Select

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub RimuoviTavoli()
      Try
         ' Rimuove tutti i Tavoli dal quadro pulsanti.
         pnlPulsanti.Controls.Clear()
         NumRisorse = 0

         ' Rimuove tutti i Tavoli dal quadro piantina.
         Dim i As Integer = 0
         For i = 0 To pnlPiantina.Controls.Count - 1
            If pnlPiantina.Controls.Contains(Risorsa(i)) = True Then
               pnlPiantina.Controls.Remove(Risorsa(i))
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub AggiornaTavoli()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         RimuoviTavoli()

         Dim i As Integer
         For i = 1 To NumSale
            If ConfrontaColore(Sala(i).ColorBottom, Color.LightCoral, Color.LightCoral) = True Then
               NumRisorse = 0
               LeggiDatiTavoli(ANAG_TAVOLI, Sala(i).TextButton)
               Exit Sub
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Public Sub AggiornaVCTavoli()
      Try
         Dim numTavoli As Integer = LeggiNumRecord(ANAG_TAVOLI, cn, cmd)
         ReDim Risorsa(numTavoli)
         ReDim Sala(LeggiNumRecord(TAB_SALE, cn, cmd))
         ReDim IndiceTavoloOccupato(numTavoli)
         ReDim OraOccupazione(numTavoli)

         NumRisorse = 0
         NumSale = 0

         If CaricaSale() = True Then
            NumListino = Listino.Uno

            tavoloSelezionato = 1

            LeggiDatiTavolo(ANAG_TAVOLI, CInt(Risorsa(1).Name))

            AggiornaDisplay()

            Risorsa(1).Focus()

            ' Carica le prenotazioni del giorno per il tavolo selezionato.
            LeggiDatiPrenTavolo(TAB_PREN, dataOggi, Risorsa(1).Name)
         Else
            lblTavolo.Text = String.Empty
            lblPosti.Text = String.Empty
            lblCoperti.Text = String.Empty
            LblPostiLiberi.Text = String.Empty
            lblCameriere.Text = String.Empty
            lblOccupati.Text = String.Empty
            lblLiberi.Text = String.Empty

            ' Pulisce la lista.
            lstvDettagli.Items.Clear()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function VerificaTavoloVisibile(ByVal idTavolo As String) As Boolean
      Try
         Dim i As Integer
         For i = 1 To NumRisorse
            If Risorsa(i).Name = idTavolo Then
               Return True
            End If
         Next

         Return False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try

   End Function

   Public Sub PalmOccupaTavolo(ByVal id As Integer, ByVal coperti As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim indiceTavoloSel As Integer

         Dim i As Integer
         For i = 1 To NumRisorse
            If Risorsa(i).Name = id.ToString Then
               indiceTavoloSel = i
            End If
         Next

         ' Verifica se il Tavolo è già occupato.
         If LeggiNumCopertiOcc("Tavoli", id) <> 0 Then
            Exit Sub
         End If

         NumTavoliOccupati += 1

         IndiceTavoloOccupato(NumTavoliOccupati - 1) = indiceTavoloSel

         OraOccupazione(NumTavoliOccupati - 1) = New DateTime(Today.Year, Today.Month, Today.Day, Today.Now.Hour, Today.Now.Minute, Today.Now.Second)

         Risorsa(indiceTavoloSel).ColorBottom = TAVOLO_DEVE_ORDINARE

         modificatoStatoTavolo = ModificaStatoTavolo(ANAG_TAVOLI, Risorsa(indiceTavoloSel).Name, TAVOLO_DEVE_ORDINARE, Convert.ToString(OraOccupazione(NumTavoliOccupati - 1)), coperti)

         AggiornaDisplay()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub PalmOccupaTavoloNonVisibile(ByVal id As Integer, ByVal coperti As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Verifica se il Tavolo è già occupato.
         If LeggiNumCopertiOcc("Tavoli", id) <> 0 Then
            Exit Sub
         End If

         NumTavoliOccupati += 1

         OraOccupazione(NumTavoliOccupati - 1) = New DateTime(Today.Year, Today.Month, Today.Day, Today.Now.Hour, Today.Now.Minute, Today.Now.Second)

         modificatoStatoTavolo = ModificaStatoTavolo(ANAG_TAVOLI, id, TAVOLO_DEVE_ORDINARE, Convert.ToString(OraOccupazione(NumTavoliOccupati - 1)), coperti)

         AggiornaDisplay()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub PalmLiberaTavolo(ByVal id As Integer)
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      Dim indiceTavoloSel As Integer

      Dim i As Integer
      For i = 1 To NumRisorse
         If Risorsa(i).Name = id.ToString Then
            indiceTavoloSel = i
         End If
      Next

      Dim y As Integer = 0
      For y = 0 To NumTavoliOccupati - 1
         If IndiceTavoloOccupato(y) = indiceTavoloSel Then
            IndiceTavoloOccupato(y) = Nothing
            NumTavoliOccupati -= 1
            Exit For
         End If
      Next

      If ConfrontaColore(Risorsa(indiceTavoloSel).ColorBottom, TAVOLO_DA_LIBERARE, TAVOLO_DA_LIBERARE) = False Then
         EliminaComandeTavolo(Convert.ToInt32(Risorsa(indiceTavoloSel).Name))
         Risorsa(indiceTavoloSel).TextButton = Risorsa(indiceTavoloSel).TextButton.Remove(Risorsa(indiceTavoloSel).TextButton.Length - LUNGHEZZA_ORA_BREVE, LUNGHEZZA_ORA_BREVE)
      End If

      modificatoStatoTavolo = ModificaStatoTavolo(ANAG_TAVOLI, Risorsa(indiceTavoloSel).Name, TAVOLO_LIBERO, "", "")
      Risorsa(indiceTavoloSel).ColorBottom = TAVOLO_LIBERO

      AggiornaDisplay()

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Public Sub PalmDaServireTavolo(ByVal id As Integer)
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      Dim indiceTavoloSel As Integer

      Dim i As Integer
      For i = 1 To NumRisorse
         If Risorsa(i).Name = id.ToString Then
            indiceTavoloSel = i
         End If
      Next

      Risorsa(indiceTavoloSel).ColorBottom = TAVOLO_DA_SERVIRE
      ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(indiceTavoloSel).Name, TAVOLO_DA_SERVIRE)

      AggiornaDisplay()

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Public Sub PalmDaServireTavoloNonVisibile(ByVal id As Integer)
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      ModificaStatoColoreTavolo(ANAG_TAVOLI, id, TAVOLO_DA_SERVIRE)

      AggiornaDisplay()

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Public Sub PalmServitoTavolo(ByVal id As Integer)
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      Dim indiceTavoloSel As Integer

      Dim i As Integer
      For i = 1 To NumRisorse
         If Risorsa(i).Name = id.ToString Then
            indiceTavoloSel = i
         End If
      Next

      Risorsa(indiceTavoloSel).ColorBottom = TAVOLO_SERVITO
      ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(indiceTavoloSel).Name, TAVOLO_SERVITO)

      AggiornaDisplay()

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Public Sub PalmServitoTavoloNonVisibile(ByVal id As Integer)
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      ModificaStatoColoreTavolo(ANAG_TAVOLI, id, TAVOLO_SERVITO)

      AggiornaDisplay()

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Public Sub PalmContoTavolo(ByVal id As Integer)
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      Dim indiceTavoloSel As Integer

      Dim i As Integer
      For i = 1 To NumRisorse
         If Risorsa(i).Name = id.ToString Then
            indiceTavoloSel = i
         End If
      Next

      Risorsa(indiceTavoloSel).ColorBottom = TAVOLO_ATTESA_CONTO
      ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(indiceTavoloSel).Name, TAVOLO_ATTESA_CONTO)

      AggiornaDisplay()

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Public Sub PalmContoTavoloNonVisibile(ByVal id As Integer)
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      ModificaStatoColoreTavolo(ANAG_TAVOLI, id, TAVOLO_ATTESA_CONTO)

      AggiornaDisplay()

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Public Function PalmSalvaComande(ByVal idPiatto As Integer, ByVal quantità As Integer, ByVal importo As String,
                                 ByVal idRisorsa As Integer, ByVal risorsa As String, ByVal cameriere As String, ByVal coperti As String) As Boolean
      Dim trovato As Boolean = False
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim CComande As New Comande

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM Piatti WHERE Id = " & idPiatto & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            With CComande
               .IdRisorsa = idRisorsa
               .Risorsa = risorsa
               .Cameriere = cameriere
               .Coperti = coperti

               ' Quantità
               .Quantità = quantità

               ' Descrizione.
               If IsDBNull(dr.Item("Descrizione")) = False Then
                  .Descrizione = dr.Item("Descrizione").ToString
               Else
                  .Descrizione = String.Empty
               End If

               ' Importo.
               .ImportoNetto = importo

               ' Prezzo.
               Select Case NumListino
                  Case Listino.Uno
                     If IsDBNull(dr.Item("Listino1")) = False Then
                        If dr.Item("Listino1") <> "" Then
                           .ValoreUnitario = dr.Item("Listino1").ToString
                        Else
                           .ValoreUnitario = VALORE_ZERO
                        End If
                     Else
                        .ValoreUnitario = VALORE_ZERO
                     End If

                  Case Listino.Due
                     If IsDBNull(dr.Item("Listino2")) = False Then
                        If dr.Item("Listino2").ToString <> "" Then
                           .ValoreUnitario = dr.Item("Listino2").ToString
                        Else
                           .ValoreUnitario = VALORE_ZERO
                        End If
                     Else
                        .ValoreUnitario = VALORE_ZERO
                     End If

                  Case Listino.Tre
                     If IsDBNull(dr.Item("Listino3")) = False Then
                        If dr.Item("Listino3").ToString <> "" Then
                           .ValoreUnitario = dr.Item("Listino3").ToString
                        Else
                           .ValoreUnitario = VALORE_ZERO
                        End If
                     Else
                        .ValoreUnitario = VALORE_ZERO
                     End If

                  Case Listino.Quattro
                     If IsDBNull(dr.Item("Listino4")) = False Then
                        If dr.Item("Listino4").ToString <> "" Then
                           .ValoreUnitario = dr.Item("Listino4").ToString
                        Else
                           .ValoreUnitario = VALORE_ZERO
                        End If
                     Else
                        .ValoreUnitario = VALORE_ZERO
                     End If
               End Select

               ' Id Piatto.
               If IsDBNull(dr.Item("Id")) = False Then
                  .IdPiatto = Convert.ToInt32(dr.Item("Id"))
               End If

               ' Categoria.
               If IsDBNull(dr.Item("Categoria")) = False Then
                  .CategoriaPiatto = dr.Item("Categoria").ToString
                  .Reparto = LeggiReparto(TAB_CATEGORIE, dr.Item("Categoria").ToString)
                  ultimoReparto = .Reparto
               Else
                  .CategoriaPiatto = String.Empty
                  .Reparto = String.Empty
                  ultimoReparto = .Reparto
               End If

               ' Numero conto.
               .NumeroConto = "0"

               ' Inviata.
               .Inviata = "No"
               ' Esclusa.
               .Esclusa = "No"
               ' Offerta.
               .Offerta = "No"

               .InserisciDati(TAB_COMANDE)
            End With

            trovato = True
         Loop

         Return trovato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         cn.Close()

      End Try
   End Function

   Public Function PalmSalvaMsgComande(ByVal idRisorsa As Integer, ByVal descrizione As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim CComande As New Comande

      Try
         cn.Open()

         With CComande
            .IdRisorsa = idRisorsa
            .Risorsa = ""
            .Cameriere = ""
            .Coperti = ""
            ' Quantità
            .Quantità = Nothing
            ' Descrizione.
            .Descrizione = descrizione
            ' Importo.
            .ImportoNetto = VALORE_ZERO
            ' Prezzo.
            .ValoreUnitario = VALORE_ZERO
            ' Id Piatto.
            .IdPiatto = 0
            ' Categoria.
            .CategoriaPiatto = ""
            .Reparto = ultimoReparto
            ' Numero conto.
            .NumeroConto = "0"
            ' Inviata.
            .Inviata = "No"
            ' Esclusa.
            .Esclusa = "No"
            ' Offerta.
            .Offerta = "No"

            .InserisciDati(TAB_COMANDE)

            Return True

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         cn.Close()

      End Try
   End Function

   Public Function PalmEliminaMsgComande(ByVal tabella As String, ByVal Id As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE IdPiatto = {1}", tabella, Id)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

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

   Public Function LeggiCameriere(ByVal tabella As String, ByVal idTavolo As Integer) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & idTavolo, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("Cameriere")) = False Then
               Return dr.Item("Cameriere").ToString
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

   Public Function LeggiNumPren(ByVal tabella As String, ByVal cn As OleDbConnection, ByVal cmd As OleDbCommand, ByVal val As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Data = #" & val & "#", tabella)
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

   Public Function LeggiNumTavoliOccupati(ByVal tabella As String, ByVal cn As OleDbConnection, ByVal cmd As OleDbCommand) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE OraOcc <> ''", tabella)
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

   Public Function LeggiNumTavoliLiberi(ByVal tabella As String, ByVal cn As OleDbConnection, ByVal cmd As OleDbCommand) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE OraOcc = ''", tabella)
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

   Public Function ModificaStatoTavolo(ByVal tabella As String, ByVal codice As String, ByVal colore As Color, ByVal ora As String, ByVal coperti As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET Colore = {1}, " &
                             "OraOcc = '{2}', " &
                             "Coperti = '{3}' " &
                             "WHERE Id = {4}",
                             tabella,
                             Convert.ToString(colore.ToArgb),
                             ora,
                             coperti,
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
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

   Public Function ModificaStatoColoreTavolo(ByVal tabella As String, ByVal codice As String, ByVal colore As Color) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET Colore = {1} " &
                             "WHERE Id = {2}",
                             tabella,
                             Convert.ToString(colore.ToArgb),
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
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

   Public Function ModificaStatoAsportoTavolo(ByVal tabella As String, ByVal codice As String, ByVal oraRitiro As String, ByVal note As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET OraRitiro = '{1}', " &
                             "[Note] = '{2}' " &
                             "WHERE Id = {3}",
                             tabella,
                             oraRitiro,
                             note,
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
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

   Private Sub LeggiFileStatoTavoli(ByVal abilita As Boolean)
      Dim riga As String
      Dim colore As Color

      Try
         If abilita = False Then
            Exit Sub
         End If

         If File.Exists(PercorsoRP & NOME_FILE_TAVOLI) = True Then

            Dim leggiFile As StreamReader = New StreamReader(PercorsoRP & NOME_FILE_TAVOLI)

            Do While leggiFile.Peek >= 0
               riga = leggiFile.ReadLine()

               Dim datiRiga As String() = Nothing
               Dim tipoDati As String = String.Empty

               ' Se trova [ vengono identificati il tipo di dati.
               If riga.Substring(0, 1) = "[" Then
                  tipoDati = riga
               Else
                  ' Altrimenti vengono identificati i dati.
                  datiRiga = riga.Split(";")

                  If tipoDati = "[TAVOLI]" Then
                     ModificaStatoColoreTavolo(ANAG_TAVOLI, datiRiga(0), colore.FromArgb(Convert.ToInt32(datiRiga(3))))
                  End If

               End If
            Loop

            leggiFile.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub LeggiFileStatoEsauriti(ByVal abilita As Boolean)
      Dim riga As String
      Dim CEsauriti As New PiattiEsauriti

      Try
         If abilita = False Then
            Exit Sub
         End If

         If File.Exists(PercorsoRP & NOME_FILE_TAVOLI) = True Then

            Dim leggiFile As StreamReader = New StreamReader(PercorsoRP & NOME_FILE_TAVOLI)

            CEsauriti.EliminaDati(TAB_PIATTI_ESAURITI)

            Do While leggiFile.Peek >= 0
               riga = leggiFile.ReadLine()

               Dim datiRiga As String() = Nothing
               Dim tipoDati As String = String.Empty

               ' Se trova [ vengono identificati il tipo di dati.
               If riga.Substring(0, 1) = "[" Then
                  tipoDati = riga
               Else
                  ' Altrimenti vengono identificati i dati.
                  datiRiga = riga.Split(";")

                  Select Case tipoDati
                     Case "[PIATTI]", "[VARIANTI]"
                        If datiRiga(3) = 0 Then
                           With CEsauriti
                              .Descrizione = datiRiga(2)
                              .Categoria = datiRiga(1)
                              .IdPiatto = Convert.ToInt32(datiRiga(0))

                              .InserisciDati(TAB_PIATTI_ESAURITI)
                           End With

                        End If
                  End Select
               End If
            Loop

            leggiFile.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub VerificaPresenzaFileTemp(ByVal abilita As Boolean)
      Try
         Dim fileComandi() As String

         If abilita = False Then
            Exit Sub
         End If

         ' Controlla se ci sono file da leggere.
         fileComandi = Directory.GetFiles(PercorsoRP, "CHS_TEMP*")

         ' Se non ci sono file da leggere...
         If fileComandi.Length = 0 Then
            Exit Sub
         Else
            Array.Sort(fileComandi)

            Dim i As Integer
            For i = 0 To fileComandi.Length - 1
               File.Move(fileComandi(i), fileComandi(i).Replace("TEMP", "CMD"))
            Next
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub LeggiFileComandi(ByVal abilita As Boolean)
      Try
         Dim riga As String
         Dim colore As Color
         Dim fileComandi() As String
         Dim comandeSalvate As Boolean

         If abilita = False Then
            Exit Sub
         End If

         ' Controlla se ci sono file da leggere.
         fileComandi = Directory.GetFiles(PercorsoRP, "CHS_CMD*.TXT")

         ' Se non ci sono file da leggere...
         If fileComandi.Length = 0 Then
            Exit Sub
         End If

         Timer3.Enabled = False

         Array.Sort(fileComandi)

         Dim i As Integer
         For i = 0 To fileComandi.Length - 1
            If File.Exists(fileComandi(i)) = True Then
               Dim leggiFile As New StreamReader(fileComandi(i))

               Do While leggiFile.Peek >= 0
                  riga = leggiFile.ReadLine()

                  Dim datiRiga As String() = Nothing
                  Dim tipoDati As String = String.Empty

                  ' Se trova [ vengono identificati il tipo di dati.
                  If riga.Substring(0, 1) = "[" Then
                     tipoDati = riga
                  Else
                     ' Altrimenti vengono identificati i dati.
                     datiRiga = riga.Split(";")

                     Dim idTavolo As String
                     Dim coperti As String
                     Dim nomeTavolo As String
                     Dim cameriere As String

                     Select Case tipoDati
                        Case "[TAVOLO]"
                           idTavolo = datiRiga(0)
                           ModificaStatoColoreTavolo(ANAG_TAVOLI, datiRiga(0), colore.FromArgb(Convert.ToInt32(datiRiga(3))))
                           nomeTavolo = datiRiga(1)
                           coperti = datiRiga(2)

                           If VerificaTavoloVisibile(idTavolo) = False Then
                              leggiFile.Close()
                              File.Move(fileComandi(i), fileComandi(i).Replace("CMD", "TEMP"))
                              Exit Sub
                           End If

                        Case "[COMANDE]"
                           ' Se manca l'id del piatto significa che è un messaggio.
                           If datiRiga(3) <> String.Empty Then
                              cameriere = LeggiCameriere(ANAG_TAVOLI, idTavolo)
                              comandeSalvate = PalmSalvaComande(datiRiga(3), datiRiga(0), datiRiga(2), idTavolo, nomeTavolo, cameriere, coperti)
                           Else
                              ' Verifica la presenza di un messaggio.
                              If datiRiga(1) <> String.Empty Then
                                 If ultimoReparto <> "" Then
                                    PalmSalvaMsgComande(idTavolo, datiRiga(1))
                                 End If
                              End If
                           End If

                        Case "[COMANDO]"
                           Select Case datiRiga(0)
                              Case "Occupa"
                                 PalmOccupaTavolo(idTavolo, coperti)

                              Case "Libera"
                                 PalmLiberaTavolo(idTavolo)

                              Case "DaServire"
                                 PalmDaServireTavolo(idTavolo)

                                 If comandeSalvate = True Then
                                    g_frmPos = New frmPos(idTavolo, nomeTavolo, "", cameriere)
                                    g_frmPos.Opacity = 0
                                    g_frmPos.Show()
                                    g_frmPos.StampaComande()
                                    g_frmPos.RegistraMsgComanda()
                                    g_frmPos.RegistraTuttiMsgComanda()
                                    g_frmPos.StampaMessaggi()
                                    g_frmPos.ModificaStatoMessaggi(TAB_MESSAGGI)
                                    g_frmPos.ModificaStatoComande(TAB_COMANDE)
                                    If IsNothing(g_frmMessaggi) = False Then
                                       g_frmMessaggi.AggiornaDati()
                                    End If
                                    g_frmPos.confermaModifiche = True
                                    g_frmPos.Close()
                                 End If

                                 PalmEliminaMsgComande(TAB_COMANDE, 0)

                              Case "Servito"
                                 PalmServitoTavolo(idTavolo)

                              Case "Conto"
                                 PalmContoTavolo(idTavolo)

                              Case "Esauriti"
                                 LeggiFileStatoEsauriti(abilita)

                           End Select
                     End Select
                  End If
               Loop

               leggiFile.Close()

               ' Se il file è stato letto correttamente lo cancella. 
               If File.Exists(fileComandi(i)) = True Then
                  File.Delete(fileComandi(i))
               End If
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Timer3.Enabled = True
      End Try
   End Sub

   Private Sub LeggiFileComandiSQLite(ByVal abilita As Boolean)
      Try
         If abilita = False Then
            Exit Sub
         End If

         ' Disattiva il timer.
         Timer3.Enabled = False

         CopiaFileComandiSQLite(abilita)
         SalvaFileComandiSQLite(abilita)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Timer3.Enabled = True
      End Try
   End Sub

   Private Sub CopiaFileComandiSQLite(ByVal abilita As Boolean)
      Try
         Dim connStrSQLite As String
         Dim fileComandi() As String

         If abilita = False Then
            Exit Sub
         End If

         ' Controlla se ci sono file da leggere.
         fileComandi = Directory.GetFiles(PercorsoRP, "CHS_CMD_*")

         ' Se non ci sono file da leggere...
         If fileComandi.Length = 0 Then
            Exit Sub
         Else
            'Rallenta di 5 secondi.
            'Sleep(1000)
         End If

         Array.Sort(fileComandi)

         Dim i As Integer
         For i = 0 To fileComandi.Length - 1
            If File.Exists(fileComandi(i)) = True Then
               Const LUNGHEZZA_FILE As Integer = 26

               ' Crea la copia del file.
               File.Copy(fileComandi(i), Application.StartupPath & "\Android\" & fileComandi(i).Substring(fileComandi(i).Length - LUNGHEZZA_FILE, LUNGHEZZA_FILE))

               ' Se il file è stato letto correttamente lo cancella. 
               File.Delete(fileComandi(i))
            End If

            Application.DoEvents()
         Next

      Catch ex As IOException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaFileComandiSQLite(ByVal abilita As Boolean)
      Try
         ' Stringa di connessione.
         Dim connStrSQLite As String
         Dim fileComandi() As String
         Dim comandeSalvate As Boolean
         Dim colore As Color
         Dim idTavolo As String
         Dim coperti As String
         Dim nomeTavolo As String
         Dim cameriere As String
         Dim comando As String

         If abilita = False Then
            Exit Sub
         End If

         ' Controlla se ci sono file da leggere.
         fileComandi = Directory.GetFiles(Application.StartupPath & "\Android\", "CHS_CMD_*")

         ' Se non ci sono file da leggere...
         If fileComandi.Length = 0 Then
            Exit Sub
         End If

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Visualizza un messaggio sulla barra di stato.
         lblInvioComande.Text = "Ricezione dati da dispositivo in corso..."

         Array.Sort(fileComandi)

         Dim i As Integer
         For i = 0 To fileComandi.Length - 1
            If File.Exists(fileComandi(i)) = True Then
               ' Crea la stringa di connessione.
               connStrSQLite = "Data Source=" & fileComandi(i)
               Dim cn As New SQLiteConnection(connStrSQLite)
               cn.Open()

               ' Legge i dati del Tavolo.
               Dim strSqlTavoli As String = "SELECT * FROM Tavoli ORDER BY Id ASC"
               Dim cmdTavoli As New SQLiteCommand(strSqlTavoli, cn)
               Dim drTavoli As SQLiteDataReader = cmdTavoli.ExecuteReader()

               Do While drTavoli.Read
                  idTavolo = drTavoli.Item("IdTavolo").ToString
                  nomeTavolo = drTavoli.Item("Descrizione").ToString
                  coperti = drTavoli.Item("Coperti").ToString
                  comando = drTavoli.Item("Comando").ToString

                  Application.DoEvents()
               Loop

               cmdTavoli.Dispose()
               drTavoli.Close()

               ' Legge i dati delle Comande.
               Dim strSqlComande As String = "SELECT * FROM Comande ORDER BY Id ASC"

               Dim cmdComande As New SQLiteCommand(strSqlComande, cn)
               Dim drComande As SQLiteDataReader = cmdComande.ExecuteReader()

               Do While drComande.Read
                  ' Se manca l'id del piatto significa che è un messaggio.
                  If drComande.Item("IdPiatto").ToString <> String.Empty Then
                     cameriere = LeggiCameriere(ANAG_TAVOLI, idTavolo)
                     Dim importo As String
                     If IsDBNull(drComande.Item("Importo")) = False Then
                        importo = drComande.Item("Importo").ToString
                     Else
                        importo = VALORE_ZERO
                     End If
                     comandeSalvate = PalmSalvaComande(Convert.ToInt32(drComande.Item("IdPiatto")), Convert.ToInt32(drComande.Item("Quantita")), importo, idTavolo, nomeTavolo, cameriere, coperti)
                  Else
                     ' Verifica la presenza di un messaggio.
                     If drComande.Item("Piatto").ToString <> String.Empty Then
                        If ultimoReparto <> "" Then
                           PalmSalvaMsgComande(idTavolo, drComande.Item("Piatto").ToString)
                        End If
                     End If
                  End If

                  Application.DoEvents()
               Loop

               cmdComande.Dispose()
               drComande.Close()

               cn.Close()

               ' Se il file è stato letto correttamente lo cancella. 
               If File.Exists(fileComandi(i)) = True Then
                  File.Delete(fileComandi(i))
               End If

               ' Legge il Comando.
               Select Case comando
                  Case "Occupa"
                     If VerificaTavoloVisibile(idTavolo) = True Then
                        PalmOccupaTavolo(idTavolo, coperti)
                     Else
                        PalmOccupaTavoloNonVisibile(idTavolo, coperti)
                     End If
                     Exit Sub

                  Case "Libera"
                     If VerificaTavoloVisibile(idTavolo) = True Then
                        PalmLiberaTavolo(idTavolo)
                        Exit Sub
                     End If

                  Case "DaServire"
                     If VerificaTavoloVisibile(idTavolo) = True Then
                        ' Nel caso di comande prese da dispositivo Android verifica se deve anche Occupare il tavolo per visualizzare il tempo.
                        PalmOccupaTavolo(idTavolo, coperti)
                        PalmDaServireTavolo(idTavolo)
                     Else
                        PalmOccupaTavoloNonVisibile(idTavolo, coperti)
                        PalmDaServireTavoloNonVisibile(idTavolo)
                     End If

                     ' Imposta la variabile globale per il numero dei coperti.
                     NumCopertiRistorante = coperti

                     If comandeSalvate = True Then
                        g_frmPos = New frmPos(idTavolo, nomeTavolo, String.Empty, cameriere)
                        g_frmPos.Opacity = 0
                        g_frmPos.Show()
                        g_frmPos.StampaComande()

                        g_frmPos.RegistraMsgComanda()

                        g_frmPos.RegistraTuttiMsgComanda()

                        g_frmPos.StampaMessaggi()

                        g_frmPos.ModificaStatoMessaggi(TAB_MESSAGGI)

                        g_frmPos.ModificaStatoComande(TAB_COMANDE)

                        If IsNothing(g_frmMessaggi) = False Then
                           g_frmMessaggi.AggiornaDati()

                        End If
                        g_frmPos.confermaModifiche = True
                        g_frmPos.Close()
                     End If

                     PalmEliminaMsgComande(TAB_COMANDE, 0)

                     Exit Sub

                  Case "Servito"
                     If VerificaTavoloVisibile(idTavolo) = True Then
                        PalmServitoTavolo(idTavolo)
                     Else
                        PalmServitoTavoloNonVisibile(idTavolo)
                     End If

                     Exit Sub

                  Case "Conto"
                     If VerificaTavoloVisibile(idTavolo) = True Then
                        PalmContoTavolo(idTavolo)
                     Else
                        PalmContoTavoloNonVisibile(idTavolo)
                     End If

                     Exit Sub

                  Case "Esauriti"
                     LeggiFileStatoEsauriti(abilita)

               End Select
            End If
         Next i

      Catch ex As IOException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Application.DoEvents()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub LeggiFileStatoPiatti()
      'Dim riga As String
      'Dim colore As Color

      '' TODO: PERCORSO DI RETE: Sostituire tutti i riferimenti con il percorso giusto.
      'If File.Exists(PercorsoRP & NOME_FILE_TAVOLI) = True Then

      '   Dim leggiFile As StreamReader = New StreamReader(PercorsoRP & NOME_FILE_TAVOLI)

      '   Do While leggiFile.Peek >= 0
      '      riga = leggiFile.ReadLine()

      '      Dim datiRiga As String() = Nothing
      '      Dim tipoDati As String

      '      ' Se trova [ vengono identificati il tipo di dati.
      '      If riga.Substring(0, 1) = "[" Then
      '         tipoDati = riga
      '      Else
      '         ' Altrimenti vengono identificati i dati.
      '         datiRiga = riga.Split(";")

      '         If tipoDati = "[TAVOLI]" Then
      '            ModificaStatoColoreTavolo(ANAG_TAVOLI, datiRiga(0), colore.FromArgb(Convert.ToInt32(datiRiga(3))))
      '         End If

      '      End If
      '   Loop

      '   leggiFile.Close()
      'End If
   End Sub

   Private Function SalvaPiattiEsauriti(ByVal id As Integer, ByVal categoria As String, ByVal descrizione As String) As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         Dim CEsauriti As New PiattiEsauriti
         Dim i As Integer

         With CEsauriti
            .EliminaDati(TAB_PIATTI_ESAURITI)

            For i = 0 To lstvDettagli.Items.Count - 1
               .Descrizione = descrizione
               .Categoria = categoria
               .IdPiatto = id

               .InserisciDati(TAB_PIATTI_ESAURITI)
            Next
         End With

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub AggiornaDisplay()
      Try
         If ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_PRENOTATO, TAVOLO_PRENOTATO) = True Then
            lblCoperti.Text = LeggiNumCopertiPren(TAB_PREN, dataOggi, Risorsa(tavoloSelezionato).Name).ToString
         Else
            lblCoperti.Text = LeggiNumCopertiOcc(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name).ToString
         End If

         NumCopertiRistorante = lblCoperti.Text

         Dim coperti As Integer = Convert.ToInt32(lblCoperti.Text)
         Dim posti As Integer = Convert.ToInt32(lblPosti.Text)

         LblPostiLiberi.Text = (posti - coperti).ToString

         lblOccupati.Text = LeggiNumTavoliOccupati(ANAG_TAVOLI, cn, cmd).ToString
         lblLiberi.Text = LeggiNumTavoliLiberi(ANAG_TAVOLI, cn, cmd).ToString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function SpostaComandeTavolo(ByVal idTavoloA As Integer, ByVal idTavoloB As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET IdRisorsa = @IdRisorsa " &
                             "WHERE IdRisorsa = {1}",
                             TAB_COMANDE,
                             idTavoloA)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@IdRisorsa", idTavoloB)

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

   Public Sub SpostaDatiTavolo(ByVal idTavoloA As Integer, ByVal idTavoloB As Integer, ByVal Occupato As Boolean)
      Dim tr1 As OleDbTransaction
      Dim tr2 As OleDbTransaction
      Dim colore As Integer
      Dim oraOcc As String
      Dim coperti As String
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Legge i dati del Tavolo da spostare.
         Dim cmd As New OleDbCommand("SELECT * FROM Tavoli WHERE Id = " & idTavoloA, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("Colore")) = False Then
               colore = Convert.ToInt32(dr.Item("Colore"))
            Else
               colore = Color.MediumSeaGreen.ToArgb
            End If
            If IsDBNull(dr.Item("OraOcc")) = False Then
               oraOcc = dr.Item("OraOcc").ToString
            Else
               oraOcc = ""
            End If
            If IsDBNull(dr.Item("Coperti")) = False Then
               coperti = dr.Item("Coperti").ToString
            Else
               coperti = ""
            End If
         Loop

         dr.Close()

         ' Ripristina i dati del Tavolo da spostare.
         ' Avvia una transazione.
         tr1 = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET Colore = @Colore, " &
                             "OraOcc = @OraOcc, " &
                             "Coperti = @Coperti " &
                             "WHERE Id = {1}",
                             ANAG_TAVOLI,
                             idTavoloA)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr1)
         cmdUpdate.Parameters.Add("@Colore", TAVOLO_LIBERO.ToArgb)
         cmdUpdate.Parameters.Add("@OraOcc", "")
         cmdUpdate.Parameters.Add("@Coperti", "")
         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()
         ' Conferma transazione.
         tr1.Commit()

         ' Salva i dati del Tavolo da spostare nel nuovo Tavolo.
         ' Avvia una transazione.
         tr2 = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         If Occupato = False Then
            ' Crea la stringa di eliminazione.
            sql = String.Format("UPDATE {0} " &
                                "SET Colore = @Colore, " &
                                "OraOcc = @OraOcc, " &
                                "Coperti = @Coperti " &
                                "WHERE Id = {1}",
                                ANAG_TAVOLI,
                                idTavoloB)

            ' Crea il comando per la connessione corrente.
            Dim cmdUpdate1 As New OleDbCommand(sql, cn, tr2)
            cmdUpdate1.Parameters.Add("@Colore", colore)
            cmdUpdate1.Parameters.Add("@OraOcc", oraOcc)
            cmdUpdate1.Parameters.Add("@Coperti", coperti)

            ' Esegue il comando.
            Dim Record1 As Integer = cmdUpdate1.ExecuteNonQuery()
         Else
            ' Crea la stringa di eliminazione.
            sql = String.Format("UPDATE {0} " &
                                "SET Colore = @Colore, " &
                                "Coperti = @Coperti " &
                                "WHERE Id = {1}",
                                ANAG_TAVOLI,
                                idTavoloB)

            ' Crea il comando per la connessione corrente.
            Dim cmdUpdate1 As New OleDbCommand(sql, cn, tr2)
            cmdUpdate1.Parameters.Add("@Colore", colore)
            cmdUpdate1.Parameters.Add("@Coperti", coperti)

            ' Esegue il comando.
            Dim Record1 As Integer = cmdUpdate1.ExecuteNonQuery()
         End If

         ' Conferma transazione.
         tr2.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr1.Rollback()
         tr2.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Public Sub SpostaContoTavolo(ByVal idTavoloA As String, ByVal idTavoloB As String)
      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET IdTavolo = @IdTavolo " &
                             "WHERE IdTavolo = '{1}'",
                             TAB_CONTI_TAVOLI,
                             idTavoloA)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@IdTavolo", idTavoloB)

         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Public Sub SpostaOccupazioneTavolo(ByVal idTavoloA As Integer)
      Try
         Dim i As Integer = 0
         For i = 0 To NumTavoliOccupati - 1

            If IndiceTavoloOccupato(i) <> Nothing Then
               If Risorsa(IndiceTavoloOccupato(i)).Name = idTavoloA.ToString Then
                  IndiceTavoloOccupato(i) = tavoloSelezionato
                  Exit For
               End If
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function EliminaComandeTavolo(ByVal idTavolo As Integer) As Boolean
      Try
         Dim CComande As New Comande

         With CComande
            If .EliminaDati(TAB_COMANDE, idTavolo) = True Then
               Return True
            Else
               Return False
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Sub EliminaDatiClienteConto(ByVal tabella As String, ByVal idTavolo As Integer)
      Try
         Dim sql As String

         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE IdTavolo = '{1}'", tabella, idTavolo)

         ' Crea il comando per la connessione corrente.
         Dim cmdDelete As New OleDbCommand(sql, cn, tr)

         ' Esegue il comando.
         Dim Record As Integer = cmdDelete.ExecuteNonQuery()

         ' Conferma la transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla la transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Sub

   Private Function SpostamentoInCorso() As Boolean
      If ConfrontaColore(netBtn_Sposta.ColorBottom, Color.Red, Color.Red) = True Then
         MessageBox.Show("Completare l'operazione di spostamento selezionando il Tavolo desiderato.",
                         NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return True
      Else
         Return False
      End If
   End Function

   Private Function UnioneInCorso() As Boolean
      'If ConfrontaColore(cmdUnisci.BackColor, Color.Black, Color.Black) = True Then
      '   MessageBox.Show("Completare l'operazione di unione selezionando il Tavolo desiderato.",
      '                   NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '   Return True
      'Else
      '   Return False
      'End If
   End Function

   Public Sub ApriPiattiEsauriti()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim frm As New frmVCEsauriti

         frm.WindowState = FormWindowState.Maximized

         frm.ShowDialog()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub ImpostaQuadro()
      Try
         ' Imposta il tipo di quadro da visualizzare.
         quadroPulsanti = LeggiDatiConfigVisQuadro()

         If quadroPulsanti = True Then
            ' Legge le dimensioni dei tavoli.
            Dim ATavoli As New Tavoli

            NUMERO_TAVOLI_RIGA = ATavoli.LeggiUltimoRecord("NumTastiRiga", ANAG_TAVOLI)
            LARGHEZZA_TAVOLO_PULSANTI = ATavoli.LeggiUltimoRecord("LarghezzaTasto", ANAG_TAVOLI)
            ALTEZZA_TAVOLO_PULSANTI = ATavoli.LeggiUltimoRecord("AltezzaTasto", ANAG_TAVOLI)

            If LARGHEZZA_TAVOLO_PULSANTI = 0 Then
               LARGHEZZA_TAVOLO_PULSANTI = CalcolaLarghezzaTavolo()
            End If

            ' Visaulizza i Pulsanti.
            pnlPiantina.Visible = False
            pnlPulsanti.Visible = True
            netBtn_TavoliGiù.Visible = True
            netBtn_BarraTavoli.Visible = True
            netBtn_TavoliSu.Visible = True
            netBtn_PosizionaTavoli.Visible = False
            netBtn_VisualizzaQuadro.TextButton = TESTO_BTN_QUADRO_PIANTINA
         Else
            ' Visualizza la Piantina.
            pnlPulsanti.Visible = False
            netBtn_TavoliGiù.Visible = False
            netBtn_BarraTavoli.Visible = False
            netBtn_TavoliSu.Visible = False
            pnlPiantina.Visible = True
            netBtn_PosizionaTavoli.Visible = True
            netBtn_VisualizzaQuadro.TextButton = TESTO_BTN_QUADRO_PULSANTI
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub MuoviNetButton(ByVal ctr As NetButton, ByVal ctrContenitore As Panel, ByVal nome As String, ByVal eventArg As System.Windows.Forms.MouseEventArgs,
                          ByVal cursorOffset As Point, ByVal frm As Form)
      ' Procedura per lo spostamento di un controllo con il mouse.
      Try
         ' Cambia cursore.
         Cursor.Current = Cursors.SizeAll

         ' Verifica che sia premuto il tasto sinistro del mouse.
         If eventArg.Button = Windows.Forms.MouseButtons.Left Then

            ' Limita lo spostamento del puntatore del mouse all'interno del controllo contenitore.
            Cursor.Clip = ctrContenitore.RectangleToScreen(ctrContenitore.ClientRectangle)

            ' Posizione del cursore rispetto al form.
            Dim newLocation As Point = frm.PointToClient(Cursor.Position)

            ' Coordinate dell'angolo superiore sinistro.
            newLocation.Offset(-cursorOffset.X, -cursorOffset.Y)

            ' Muove il controllo selezionato.
            ctr.Location = New Point(newLocation.X - 150, newLocation.Y - 5)


            ' Visualizza le cordinate all'interno del controllo.
            'ctr.TextButton = "x: " & CStr(ctr.Location.X) & " " & "y: " & CStr(ctr.Location.Y)
            'Me.Text = "Visual POS - GESTIONE TAVOLI - " & ctr.TextButton.ToUpper & "(X: " & ctr.Location.X.ToString & " " & "Y: " & ctr.Location.Y.ToString & ")"
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub SalvaPosizioneRisorse(ByVal tabella As String, ByVal id As String, ByVal posX As Integer, ByVal posY As Integer)
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "Set PosX = '{1}', " &
                             "PosY = '{2}' " &
                             "WHERE Id = {3}",
                             tabella,
                             posX,
                             posY,
                             id)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
         ' Esegue il comando.
         Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

         ' Conferma transazione.
         tr.Commit()

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Sub

   Private Sub SalvaPosizioneTavoli()
      Try
         Dim i As Integer = 0
         For i = 0 To pnlPiantina.Controls.Count - 1
            If pnlPiantina.Controls.Contains(Risorsa(i)) = True Then
               Dim percX As Double = (Risorsa(i).Location.X * 40) / 100
               Dim percY As Double = (Risorsa(i).Location.Y * 27) / 100
               SalvaPosizioneRisorse(ANAG_TAVOLI, Risorsa(i).Name, Risorsa(i).Location.X - percX, Risorsa(i).Location.Y - percY)
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub OccupaTavolo()
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If AbilitaPalmareWindows = True Then
            Timer3.Enabled = False
         End If

         If AbilitaPalmareAndroid = True Then
            Timer3.Enabled = False
         End If

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         If ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = True Then

            g_frmCoperti = New CopertiPOS
            If g_frmCoperti.ShowDialog = DialogResult.OK Then
               If tavoloSelezionato = -1 Then
                  Exit Sub
               End If

               NumTavoliOccupati += 1

               IndiceTavoloOccupato(NumTavoliOccupati - 1) = tavoloSelezionato

               OraOccupazione(NumTavoliOccupati - 1) = New DateTime(Today.Year, Today.Month, Today.Day, Today.Now.Hour, Today.Now.Minute, Today.Now.Second)

               Risorsa(tavoloSelezionato).ColorBottom = TAVOLO_DEVE_ORDINARE

               modificatoStatoTavolo = ModificaStatoTavolo(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name, TAVOLO_DEVE_ORDINARE,
                                       Convert.ToString(OraOccupazione(NumTavoliOccupati - 1)), g_frmCoperti.Tag)

               AggiornaDisplay()

               g_frmCoperti.SalvaDatiClienti(Risorsa(tavoloSelezionato).Name)

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.OccupaTavolo, "(" & Risorsa(tavoloSelezionato).TextButton & ")", MODULO_TAVOLI)

            End If
         Else
            MsgBox("Il tavolo selezionato è già occupato o da liberare.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
         End If

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         If AbilitaPalmareWindows = True Then
            Timer3.Enabled = True
         End If

         If AbilitaPalmareAndroid = True Then
            Timer3.Enabled = True
         End If

      End Try
   End Sub

   Private Sub AsportoTavolo()
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If AbilitaPalmareWindows = True Then
            Timer3.Enabled = False
         End If

         If AbilitaPalmareAndroid = True Then
            Timer3.Enabled = False
         End If

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         If ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = True Then

            g_frmAsporto = New AsportoPOS
            If g_frmAsporto.ShowDialog = DialogResult.OK Then
               If tavoloSelezionato = -1 Then
                  Exit Sub
               End If

               NumTavoliOccupati += 1

               IndiceTavoloOccupato(NumTavoliOccupati - 1) = tavoloSelezionato

               OraOccupazione(NumTavoliOccupati - 1) = New DateTime(g_frmAsporto.dtpDataOrdine.Value.Year,
                                                                    g_frmAsporto.dtpDataOrdine.Value.Month,
                                                                    g_frmAsporto.dtpDataOrdine.Value.Day,
                                                                    g_frmAsporto.dtpOraOrdine.Value.Hour,
                                                                    g_frmAsporto.dtpOraOrdine.Value.Minute,
                                                                    g_frmAsporto.dtpOraOrdine.Value.Second)

               Risorsa(tavoloSelezionato).ColorBottom = TAVOLO_DEVE_ORDINARE

               modificatoStatoTavolo = ModificaStatoTavolo(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name, TAVOLO_DEVE_ORDINARE, Convert.ToString(OraOccupazione(NumTavoliOccupati - 1)), g_frmAsporto.Tag)

               ModificaStatoAsportoTavolo(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name, g_frmAsporto.dtpOraRitiroOrdine.Value.ToShortTimeString, g_frmAsporto.eui_txtNote.Text)

               AggiornaDisplay()

               g_frmAsporto.SalvaDatiClienti(Risorsa(tavoloSelezionato).Name)

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.OccupaTavolo, "(" & Risorsa(tavoloSelezionato).TextButton & ")", MODULO_TAVOLI)

            End If
         Else
            MsgBox("Il tavolo selezionato è già occupato o da liberare.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
         End If

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         If AbilitaPalmareWindows = True Then
            Timer3.Enabled = True
         End If

         If AbilitaPalmareAndroid = True Then
            Timer3.Enabled = True
         End If

      End Try
   End Sub

   Private Sub Risorsa_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         If muoviPulsanti = False Then
            ' Riproduce un effetto sonoro.
            RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)
         End If

         impostaListino = True

         tavoloSelezionato = CInt(sender.Tag)
         LeggiDatiTavolo(ANAG_TAVOLI, CInt(sender.Name))

         AggiornaDisplay()

         If VerificaAsportoTavolo(ANAG_TAVOLI, Convert.ToInt32(sender.Name)) = "0" Then
            ' Carica i dati dell'ordinazione dell'asporto per il tavolo selezionato.
            LeggiDatiAsportoTavolo(ANAG_TAVOLI, sender.Name)
         Else
            ' Carica le prenotazioni del giorno per il tavolo selezionato.
            LeggiDatiPrenTavolo(TAB_PREN, dataOggi, sender.Name)
         End If

         If muoviPulsanti = True Then
            Exit Sub
         End If

         ' -----------------------------------------------------------------------------------------------------------------------------------
         ' SE È STATO SCELTO IL COMANDO SPOSTA.
         ' -----------------------------------------------------------------------------------------------------------------------------------
         If spostaTavoloId <> String.Empty Then
            If ConfrontaColore(sender.ColorBottom, TAVOLO_ATTESA_CONTO, TAVOLO_ATTESA_CONTO) = False Then

               ' Verifica se il tavolo di destinazione è già occupato.
               Dim oraOccPresente As Boolean = False
               If ConfrontaColore(sender.ColorBottom, TAVOLO_DEVE_ORDINARE, TAVOLO_DEVE_ORDINARE) = True Then
                  oraOccPresente = True
               End If
               If ConfrontaColore(sender.ColorBottom, TAVOLO_DA_SERVIRE, TAVOLO_DA_SERVIRE) = True Then
                  oraOccPresente = True
               End If
               If ConfrontaColore(sender.ColorBottom, TAVOLO_SERVITO, TAVOLO_SERVITO) = True Then
                  oraOccPresente = True
               End If

               If SpostaComandeTavolo(spostaTavoloId, sender.Name) = True Then
                  SpostaDatiTavolo(spostaTavoloId, sender.Name, oraOccPresente)
                  SpostaOccupazioneTavolo(spostaTavoloId)
                  If salaSel = salaSelezionata Then
                     Risorsa(spostaTavoloNum).TextButton = Risorsa(spostaTavoloNum).TextButton.Remove(Risorsa(spostaTavoloNum).TextButton.Length - LUNGHEZZA_ORA, LUNGHEZZA_ORA)
                     Risorsa(spostaTavoloNum).ColorBottom = TAVOLO_LIBERO
                  End If
                  sender.ColorBottom = spostaTavoloColore
               End If

               ' Se non esistono i dati del cliente per il tavolo selezionato...
               If VerificaEsistenzaValore(TAB_CONTI_TAVOLI, cn, cmd, "IdTavolo", sender.Name) = 0 Then
                  ' ...li sposta sul nuovo tavolo.
                  SpostaContoTavolo(spostaTavoloId, sender.Name)
               Else
                  ' Altrimenti li elimina.
                  EliminaDatiClienteConto(TAB_CONTI_TAVOLI, spostaTavoloId)
               End If

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.SpostaTavolo, "(" & Risorsa(spostaTavoloNum).TextButton & " -> " & lblTavolo.Text & ")", MODULO_TAVOLI)

               netBtn_Sposta.ColorBottom = Color.Black
               salaSel = ""
               spostaTavoloId = String.Empty
               spostaTavoloNum = Nothing
               spostaTavoloColore = Nothing

               If salaSel <> salaSelezionata Then
                  RimuoviTavoli()
                  NumRisorse = 0
                  If LeggiDatiTavoli(ANAG_TAVOLI, salaSelezionata) = True Then
                     Exit Sub
                  End If
               End If

               Exit Sub
            Else
               MessageBox.Show("Non è possibile completare l'operazione il Tavolo selezionato ha il conto chiuso.",
                               NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

               netBtn_Sposta.ColorBottom = Color.Black
               salaSel = ""
               spostaTavoloId = String.Empty
               spostaTavoloNum = Nothing
               spostaTavoloColore = Nothing
               Exit Sub
            End If
         End If

         ' B_TODO: Codice da attivare per il comando Unisci.
         ' -----------------------------------------------------------------------------------------------------------------------------------
         ' SE È STATO SCELTO IL COMANDO UNISCI.
         ' -----------------------------------------------------------------------------------------------------------------------------------
         'If unisciTavoloId <> String.Empty Then
         '   If salaSel = salaSelezionata Then
         '      'Risorsa(unisciTavoloNum).TextButton = Risorsa(unisciTavoloNum).TextButton.Remove(Risorsa(unisciTavoloNum).TextButton.Length - LUNGHEZZA_ORA, LUNGHEZZA_ORA)
         '      Risorsa(unisciTavoloNum).TextButton = Risorsa(unisciTavoloNum).TextButton & vbCrLf & "-> " & sender.TextButton.Remove(sender.TextButton.Length - LUNGHEZZA_ORA, LUNGHEZZA_ORA)
         '      Risorsa(unisciTavoloNum).ColorBottom = sender.ColorBottom
         '   End If
         '   cmdUnisci.BackColor = Color.DodgerBlue
         '   salaSel = ""
         '   unisciTavoloId = String.Empty
         '   unisciTavoloNum = Nothing
         '   Exit Sub
         'End If

         ' -----------------------------------------------------------------------------------------------------------------------------------
         ' SE LO STATO DEL TAVOLO È DA SERVIRE ALLORA CHIEDE SE È STATO SERVITO.
         ' -----------------------------------------------------------------------------------------------------------------------------------
         If ConfrontaColore(sender.ColorBottom, TAVOLO_DA_SERVIRE, TAVOLO_DA_SERVIRE) = True Then
            Dim risposta As Integer
            risposta = MessageBox.Show("Al tavolo selezionato le ordinazioni sono state servite?",
                                       NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If risposta = DialogResult.Yes Then
               sender.ColorBottom = TAVOLO_SERVITO
               modificatoStatoTavolo = ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name, TAVOLO_SERVITO)
               Exit Sub
            Else
               Exit Sub
            End If
         End If

         ' -----------------------------------------------------------------------------------------------------------------------------------
         ' Se lo stato del tavolo è SERVITO allora chiede se si vuole chiudere il conto.
         ' -----------------------------------------------------------------------------------------------------------------------------------
         If ConfrontaColore(sender.ColorBottom, TAVOLO_SERVITO, TAVOLO_SERVITO) = True Then
            Dim risposta As Integer
            risposta = MessageBox.Show("Al tavolo selezionato si desidera chiudere il conto?",
                                       NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If risposta = DialogResult.Yes Then
               sender.ColorBottom = TAVOLO_ATTESA_CONTO
               modificatoStatoTavolo = ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name, TAVOLO_ATTESA_CONTO)
               Exit Sub
            Else
               Exit Sub
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Risorsa_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs) ' NON FUNZIONA!!!
      'Try
      '   modificatoStatoTavolo = True

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub Risorsa_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      Try
         If muoviPulsanti = True Then
            MuoviNetButton(sender, pnlPiantina, sender.TextButton, e, cursorOffset, Me)
         Else
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Risorsa_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      Try
         ' Posiziona il cursore al centro del controllo.
         'Cursor.Position = sender.PointToScreen(New Point(CInt(sender.Width / 2), CInt(sender.Height / 2)))

         ' Posiziona il cursore nell'angolo superiore sinistro.
         'Cursor.Position = sender.PointToScreen(New Point(0, 0))

         If muoviPulsanti = True Then
            cursorOffset = e.Location
         Else
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Risorsa_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
      ' free the mouse cursor
      Cursor.Clip = Nothing

   End Sub

   Private Sub Sala_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Me.Text = TITOLO_FINESTRA & " - " & sender.TextButton.ToString.ToUpper

         'Dim i As Integer
         'For i = 1 To NumSale
         '   Sala(i).ColorBottom = Color.Black
         '   Sala(i).ColorText = Color.White
         'Next
         'sender.ColorBottom = Color.Orange
         'sender.ColorText = Color.Black
         Dim i As Integer
         For i = 1 To NumSale
            Sala(i).Enabled = True
         Next
         sender.Enabled = False

         salaSelezionata = sender.TextButton

         RimuoviTavoli()

         If quadroPulsanti = False Then
            CaricaImgSala(TAB_SALE, sender.TextButton)
         End If

         NumRisorse = 0

         If LeggiDatiTavoli(ANAG_TAVOLI, sender.TextButton) = True Then
            NumListino = Listino.Uno

            tavoloSelezionato = 1

            LeggiDatiTavolo(ANAG_TAVOLI, CInt(Risorsa(1).Name))

            AggiornaDisplay()

            Risorsa(1).Focus()

            ' Carica le prenotazioni del giorno per il tavolo selezionato.
            LeggiDatiPrenTavolo(TAB_PREN, dataOggi, Risorsa(1).Name)
         Else
            lblTavolo.Text = String.Empty
            lblPosti.Text = String.Empty
            lblCoperti.Text = String.Empty
            LblPostiLiberi.Text = String.Empty
            lblCameriere.Text = String.Empty
            lblOccupati.Text = String.Empty
            lblLiberi.Text = String.Empty

            ' Pulisce la lista.
            lstvDettagli.Items.Clear()
         End If

         ' Verifica la presenza dei file di comanda nella cartella di rete che non sono stati processati.
         VerificaPresenzaFileTemp(AbilitaPalmareWindows)

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub PosizionaTavoli()
      Try
         If muoviPulsanti = False Then
            netBtn_PosizionaTavoli.TextButton = "Blocca Tavoli"

            picImmagine.BackColor = Color.White
            picImmagine.Refresh()

            muoviPulsanti = True

            AttivaPulsanti(False)

            VisualizzaGrigliaTavoli()
         Else
            netBtn_PosizionaTavoli.TextButton = "Sblocca Tavoli"

            picImmagine.BackColor = SystemColors.AppWorkspace
            picImmagine.Refresh()

            muoviPulsanti = False

            AttivaPulsanti(True)

            g_frmVCTavoli.MinimizeBox = True

            SalvaPosizioneTavoli()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub VisualizzaGrigliaTavoli()
      ' Disegna la griglia.
      Dim grGriglia As Graphics = picImmagine.CreateGraphics

      Try
         'grGriglia.Clear(Color.White)

         Dim p As New Pen(Color.Silver, 1)
         Dim x, y As Single
         For x = 0 To picImmagine.Width Step 20
            grGriglia.DrawLine(p, x, 0, x, picImmagine.Height)
         Next
         For y = 0 To picImmagine.Height Step 20
            grGriglia.DrawLine(p, 0, y, picImmagine.Width, y)
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         grGriglia.Dispose()

      End Try
   End Sub

   Private Sub AttivaPulsanti(ByVal val As Boolean)
      Try
         pnlSale.Enabled = val
         netBtn_SalaSu.Enabled = val
         netBtn_SalaGiù.Enabled = val

         netBtn_Listino.Enabled = val
         netBtn_Apri.Enabled = val
         netBtn_Occupa.Enabled = val
         netBtn_Libera.Enabled = val
         netBtn_Sposta.Enabled = val
         netBtn_Prenota.Enabled = val
         netBtn_Asporto.Enabled = val
         netBtn_Esauriti.Enabled = val
         netBtn_Impostazioni.Enabled = val
         netBtn_VisualizzaQuadro.Enabled = val

         netBtn_PuntoCassa.Enabled = val

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

   Private Sub VCTavoli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      ' Imposta i colori dei tasti funzione.
      ImpostaTastiFunzione()

      ' Imposta la visualizzazione del quadro Pulsanti o Piantina.
      ImpostaQuadro()

      ' Imposta il listino di vendita.
      impostaListino = True

      ' Carica i dati dei tavoli.
      AggiornaVCTavoli()

      ' Attiva/Disattiva la gestione dei palmari.
      Timer3.Interval = FreqAggPalmare

      ' Abilita la gestione dei palmari.
      If AbilitaPalmareWindows = True Or AbilitaPalmareAndroid = True Then
         Timer3.Enabled = True
      Else
         Timer3.Enabled = False
      End If

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_TAVOLI, MODULO_TAVOLI)
   End Sub

   Private Sub frmVCTavoli_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      Try
         ' Distrugge l'oggetto e libera le risorse.
         g_frmVCTavoli.Dispose()
         g_frmVCTavoli = Nothing

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_TAVOLI, MODULO_TAVOLI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub frmVCTavoli_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      Try
         ' Se la finestra viene chiusa per il cambio operatore non chiede la conferma.
         If g_frmVCTavoli.Tag = "OPERATORE" Or g_frmVCTavoli.Tag = "IMPOSTAZIONI" Then
            Exit Sub
         End If

         Dim risposta As MsgBoxResult = MsgBox("Sicuro di voler uscire?.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)

         If risposta = MsgBoxResult.No Then
            e.Cancel = True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub frmVCTavoli_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Resize
      Try
         ' 1080 - Valore non più utilizzato perchè non compatibile con risoluzione 1024x748.
         If Me.Width <= 760 Then
            Me.Width = 760
         End If

         ' 784 - Valore non più utilizzato perchè non compatibile con risoluzione 1024x748.
         If Me.Height <= 700 Then
            Me.Height = 700
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdUnisci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      ' B_TODO: Codice da attivare per il comando Unisci.

      'If SpostamentoInCorso() = True Then
      '   Exit Sub
      'End If

      'If UnioneInCorso() = True Then
      '   Exit Sub
      'End If

      'If tavoloSelezionato = -1 Then
      '   Exit Sub
      'End If

      'If ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_DA_SERVIRE, TAVOLO_SERVITO) = True Then
      '   MessageBox.Show("Per completare l'operazione è necessario selezionare un tavolo vuoto e non già unito.", _
      '                   NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Exit Sub

      'ElseIf ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_DEVE_ORDINARE, TAVOLO_DA_LIBERARE) = True Then
      '   MessageBox.Show("Per completare l'operazione è necessario selezionare un tavolo vuoto e non già unito.", _
      '                   NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Exit Sub

      'ElseIf ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_ATTESA_CONTO, TAVOLO_ATTESA_CONTO) = True Then
      '   MessageBox.Show("Per completare l'operazione è necessario selezionare un tavolo vuoto e non già unito.", _
      '                   NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
      '   Exit Sub
      'End If

      'If ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = True Then
      '   sender.BackColor = Color.Black

      '   Dim risposta As Integer
      '   risposta = MessageBox.Show("Selezionare il tavolo che si intende unire al tavolo '" & lblTavolo.Text & "'.", _
      '                              NOME_PRODOTTO, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

      '   If risposta = DialogResult.OK Then
      '      salaSel = salaSelezionata
      '      unisciTavoloId = Risorsa(tavoloSelezionato).Name
      '      unisciTavoloNum = Risorsa(tavoloSelezionato).Tag
      '   Else
      '      sender.BackColor = Color.DodgerBlue
      '      salaSel = ""
      '      unisciTavoloId = String.Empty
      '      unisciTavoloNum = Nothing
      '      Exit Sub
      '   End If
      'End If

   End Sub

   Private Sub cmdSepara_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'If SpostamentoInCorso() = True Then
      '   Exit Sub
      'End If
   End Sub

   Private Sub lstvDettagli_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lstvDettagli.SelectedIndexChanged
      Try
         txtNotePren.Text = String.Empty
         txtNotePren.Text = lstvDettagli.Items(lstvDettagli.FocusedItem.Index).SubItems(5).Text

      Catch ex As NullReferenceException
         Exit Sub

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

   Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      Try
         ' Visualizza la data estesa sulla barra di stato.
         lblData.Text = Today.ToLongDateString

         If DateTime.Now.Minute.ToString.Length = 1 And DateTime.Now.Second.ToString.Length = 1 Then
            lblOra.Text = DateTime.Now.Hour & sepOra & "0" & DateTime.Now.Minute & sepOra & "0" & DateTime.Now.Second

         ElseIf DateTime.Now.Minute.ToString.Length = 1 And DateTime.Now.Second.ToString.Length > 1 Then
            lblOra.Text = DateTime.Now.Hour & sepOra & "0" & DateTime.Now.Minute & sepOra & DateTime.Now.Second

         ElseIf DateTime.Now.Minute.ToString.Length > 1 And DateTime.Now.Second.ToString.Length = 1 Then
            lblOra.Text = DateTime.Now.Hour & sepOra & DateTime.Now.Minute & sepOra & "0" & DateTime.Now.Second

         Else
            lblOra.Text = DateTime.Now.Hour & sepOra & DateTime.Now.Minute & sepOra & DateTime.Now.Second
         End If

         ' Controlla se ci sono prenotazioni.
         LeggiDatiPren(TAB_PREN, dataOggi, Convert.ToString(DateTime.Now.Hour & sepOra & DateTime.Now.Minute), LeggiNumPrenSale(ANAG_TAVOLI, salaSelezionata))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
      Try
         Dim nome As String

         Dim i As Integer = 0
         For i = 0 To NumTavoliOccupati - 1
            If IndiceTavoloOccupato(i) <> Nothing Then
               Dim ts As TimeSpan = Date.Now.Subtract(OraOccupazione(i))

               If Risorsa(IndiceTavoloOccupato(i)).TextButton.Length > LUNGHEZZA_ORA Then
                  nome = Risorsa(IndiceTavoloOccupato(i)).TextButton.Remove(Risorsa(IndiceTavoloOccupato(i)).TextButton.Length - LUNGHEZZA_ORA, LUNGHEZZA_ORA)
               Else
                  nome = Risorsa(IndiceTavoloOccupato(i)).TextButton
               End If

               If ts.Hours.ToString.Length = 1 And ts.Minutes.ToString.Length = 1 Then
                  Risorsa(IndiceTavoloOccupato(i)).TextButton = nome & vbCrLf & "[" & "0" & ts.Hours.ToString & sepOra & "0" & ts.Minutes.ToString & "]"
               ElseIf ts.Hours.ToString.Length = 1 And ts.Minutes.ToString.Length > 1 Then
                  Risorsa(IndiceTavoloOccupato(i)).TextButton = nome & vbCrLf & "[" & "0" & ts.Hours.ToString & sepOra & ts.Minutes.ToString & "]"
               ElseIf ts.Hours.ToString.Length > 1 And ts.Minutes.ToString.Length = 1 Then
                  Risorsa(IndiceTavoloOccupato(i)).TextButton = nome & vbCrLf & "[" & ts.Hours.ToString & sepOra & "0" & ts.Minutes.ToString & "]"
               Else
                  Risorsa(IndiceTavoloOccupato(i)).TextButton = nome & vbCrLf & "[" & ts.Hours.ToString & sepOra & ts.Minutes.ToString & "]"
               End If
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
      Try
         ' Legge i file contenete le comande.
         LeggiFileComandi(AbilitaPalmareWindows)
         LeggiFileComandiSQLite(AbilitaPalmareAndroid)

         ' Legge e scrive i dati sullo stato dei Tavoli, Colore e numero Coperti.
         If modificatoStatoTavolo = True Then
            g_frmMain.CreaFileStatoTavoli(AbilitaPalmareWindows, AbilitaPalmareAndroid)

            modificatoStatoTavolo = False

            ' Visualizza un messaggio sulla barra di stato.
            lblInvioComande.Text = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_VisualizzaQuadro_Click(sender As Object, e As EventArgs) Handles netBtn_VisualizzaQuadro.Click
      Try
         Dim risposta As DialogResult = MessageBox.Show("Procedendo con l'operazione verrà cambiata il tipo di visualizzazione del Quadro dei tavoli. Si desidera procedere?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If risposta = Windows.Forms.DialogResult.Yes Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            If pnlPiantina.Visible = True Then
               ' Legge le dimensioni dei tavoli.
               Dim ATavoli As New Tavoli

               NUMERO_TAVOLI_RIGA = ATavoli.LeggiUltimoRecord("NumTastiRiga", ANAG_TAVOLI)
               LARGHEZZA_TAVOLO_PULSANTI = ATavoli.LeggiUltimoRecord("LarghezzaTasto", ANAG_TAVOLI)
               ALTEZZA_TAVOLO_PULSANTI = ATavoli.LeggiUltimoRecord("AltezzaTasto", ANAG_TAVOLI)

               If LARGHEZZA_TAVOLO_PULSANTI = 0 Then
                  LARGHEZZA_TAVOLO_PULSANTI = CalcolaLarghezzaTavolo()
               End If

               ' Visualizza i pulsanti.
               pnlPiantina.Visible = False
               pnlPulsanti.Visible = True
               netBtn_TavoliGiù.Visible = True
               netBtn_BarraTavoli.Visible = True
               netBtn_TavoliSu.Visible = True
               netBtn_PosizionaTavoli.Visible = False
               netBtn_VisualizzaQuadro.TextButton = TESTO_BTN_QUADRO_PIANTINA
               quadroPulsanti = True
            Else
               ' Visualizza la piantina.
               pnlPulsanti.Visible = False
               netBtn_TavoliGiù.Visible = False
               netBtn_BarraTavoli.Visible = False
               netBtn_TavoliSu.Visible = False
               pnlPiantina.Visible = True
               netBtn_PosizionaTavoli.Visible = True
               netBtn_VisualizzaQuadro.TextButton = TESTO_BTN_QUADRO_PULSANTI
               quadroPulsanti = False
            End If

            RimuoviTavoli()
            AggiornaVCTavoli()

            SalvaDatiConfigVisQuadro(quadroPulsanti)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub netBtn_Apri_Click(sender As Object, e As EventArgs) Handles netBtn_Apri.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         If VerificaAsportoTavolo(ANAG_TAVOLI, Convert.ToInt32(Risorsa(tavoloSelezionato).Name)) = "0" Then
            MessageBox.Show("Attenzione! Sul tavolo sono presenti ordinazioni per l'asporto. Aprire il tavolo con il tasto 'Asporto'.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
         End If

         If ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = True Then
            ' Occupa il tavolo con i dati del cliente.
            OccupaTavolo()

            If copertiAnnulla = False Then
               g_frmMain.ApriPos(Risorsa(tavoloSelezionato).Name, lblTavolo.Text, lblOraOcc.Text, lblCameriere.Text)
               Exit Sub
            Else
               copertiAnnulla = False
               Exit Sub
            End If
         End If

         g_frmMain.ApriPos(Risorsa(tavoloSelezionato).Name, lblTavolo.Text, lblOraOcc.Text, lblCameriere.Text)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Occupa_Click(sender As Object, e As EventArgs) Handles netBtn_Occupa.Click
      Try
         OccupaTavolo()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Libera_Click(sender As Object, e As EventArgs) Handles netBtn_Libera.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If AbilitaPalmareWindows = True Then
            Timer3.Enabled = False
         End If

         If AbilitaPalmareAndroid = True Then
            Timer3.Enabled = False
         End If

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         If tavoloSelezionato = -1 Then
            Exit Sub
         End If

         If ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = False Then
            Dim risposta As MsgBoxResult
            risposta = MsgBox("Sicuro di voler liberare il tavolo selezionato?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)

            If risposta = DialogResult.Yes Then
               Dim i As Integer = 0
               For i = 0 To NumTavoliOccupati - 1
                  If IndiceTavoloOccupato(i) = tavoloSelezionato Then
                     IndiceTavoloOccupato(i) = Nothing
                     NumTavoliOccupati -= 1
                     Exit For
                  End If
               Next

               If ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_DA_LIBERARE, TAVOLO_DA_LIBERARE) = False Then
                  EliminaComandeTavolo(Risorsa(tavoloSelezionato).Name)
                  Risorsa(tavoloSelezionato).TextButton = Risorsa(tavoloSelezionato).TextButton.Remove(Risorsa(tavoloSelezionato).TextButton.Length - LUNGHEZZA_ORA_BREVE, LUNGHEZZA_ORA_BREVE)
               End If

               ' Elimina i dati del cliente del tavolo selezionato salvati nel conto.
               EliminaDatiClienteConto(TAB_CONTI_TAVOLI, Risorsa(tavoloSelezionato).Name)

               modificatoStatoTavolo = ModificaStatoTavolo(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name, TAVOLO_LIBERO, "", "")
               Risorsa(tavoloSelezionato).ColorBottom = TAVOLO_LIBERO
               AggiornaDisplay()

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.LiberaTavolo, "(" & Risorsa(tavoloSelezionato).TextButton & ")", MODULO_TAVOLI)

            End If
         Else
            MsgBox("Il tavolo selezionato è già disponibile.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
         End If


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         If AbilitaPalmareWindows = True Then
            Timer3.Enabled = True
         End If

         If AbilitaPalmareAndroid = True Then
            Timer3.Enabled = True
         End If

      End Try
   End Sub

   Private Sub netBtn_Sposta_Click(sender As Object, e As EventArgs) Handles netBtn_Sposta.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If AbilitaPalmareWindows = True Then
            Timer3.Enabled = False
         End If

         If AbilitaPalmareAndroid = True Then
            Timer3.Enabled = False
         End If

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         If tavoloSelezionato = -1 Then
            Exit Sub
         End If

         If ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = True Then
            MessageBox.Show("Al tavolo selezionato non è assosciata alcuna ordinazione da poter spostare.",
                            NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

         ElseIf ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_DEVE_ORDINARE, TAVOLO_DA_LIBERARE) = True Then
            MessageBox.Show("Al tavolo selezionato non è assosciata alcuna ordinazione da poter spostare.",
                            NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

         ElseIf ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_ATTESA_CONTO, TAVOLO_ATTESA_CONTO) = True Then
            MessageBox.Show("Al tavolo selezionato non è assosciata alcuna ordinazione da poter spostare.",
                            NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_DA_SERVIRE, TAVOLO_SERVITO) = True Then
            sender.ColorBottom = Color.Red

            Dim risposta As Integer
            risposta = MessageBox.Show("Selezionare il tavolo su cui riversare le comande del tavolo '" & lblTavolo.Text & "'.",
                                       NOME_PRODOTTO, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            If risposta = DialogResult.OK Then
               salaSel = salaSelezionata
               spostaTavoloId = Risorsa(tavoloSelezionato).Name
               spostaTavoloNum = Risorsa(tavoloSelezionato).Tag
               spostaTavoloColore = Risorsa(tavoloSelezionato).ColorBottom
            Else
               sender.ColorBottom = Color.Black
               salaSel = ""
               spostaTavoloId = String.Empty
               spostaTavoloNum = Nothing
               spostaTavoloColore = Nothing
               Exit Sub
            End If

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         If AbilitaPalmareWindows = True Then
            Timer3.Enabled = True
         End If

         If AbilitaPalmareAndroid = True Then
            Timer3.Enabled = True
         End If

      End Try
   End Sub

   Private Sub netBtn_Prenota_Click(sender As Object, e As EventArgs) Handles netBtn_Prenota.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         Application.DoEvents()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ConnStringAnagrafiche = CreaConnString(PercorsoDB)

         g_frmVCPren = New frmElencoPren
         g_frmVCPren.ShowDialog()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub netBtn_Asporto_Click(sender As Object, e As EventArgs) Handles netBtn_Asporto.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         If ConfrontaColore(Risorsa(tavoloSelezionato).ColorBottom, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = True Then
            ' Occupa il tavolo con i dati del cliente per l'asporto.
            AsportoTavolo()

            If asportoAnnulla = False Then
               g_frmMain.ApriPos(Risorsa(tavoloSelezionato).Name, "Asporto", "", "")
               Exit Sub
            Else
               asportoAnnulla = False
               Exit Sub
            End If
         End If

         g_frmMain.ApriPos(Risorsa(tavoloSelezionato).Name, "Asporto", "", "")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Esauriti_Click(sender As Object, e As EventArgs) Handles netBtn_Esauriti.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If SpostamentoInCorso() = True Then
         Exit Sub
      End If

      ApriPiattiEsauriti()
   End Sub

   Private Sub netBtn_PuntoCassa_Click(sender As Object, e As EventArgs) Handles netBtn_PuntoCassa.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         g_frmMain.ApriPos(0, "Tavoli", "", "")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Esci_Click(sender As Object, e As EventArgs) Handles netBtn_Esci.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Tag = String.Empty
      Me.Close()
   End Sub

   Private Sub netBtn_SalaGiù_Click(sender As Object, e As EventArgs) Handles netBtn_SalaGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlSale.Controls.Count = 0 Then
            Return
         End If

         If Sala(pnlSale.Controls.Count).Location.Y <= pnlSale.Size.Height - ALTEZZA_SALE Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlSale.Controls.Count
               Sala(i).Location = New Point(0, Sala(i).Location.Y - ALTEZZA_SALE - 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub netBtn_SalaSu_Click(sender As Object, e As EventArgs) Handles netBtn_SalaSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlSale.Controls.Count = 0 Then
            Return
         End If

         If Sala(1).Location.Y >= 0 Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlSale.Controls.Count
               Sala(i).Location = New Point(0, Sala(i).Location.Y + ALTEZZA_SALE + 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_TavoliGiù_Click(sender As Object, e As EventArgs) Handles netBtn_TavoliGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlPulsanti.Controls.Count = 0 Then
            Return
         End If

         If Risorsa(pnlPulsanti.Controls.Count).Location.Y <= pnlPulsanti.Size.Height - ALTEZZA_TAVOLO_PULSANTI Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlPulsanti.Controls.Count
               Risorsa(i).Location = New Point(Risorsa(i).Location.X, Risorsa(i).Location.Y - ALTEZZA_TAVOLO_PULSANTI - 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub netBtn_TavoliSu_Click(sender As Object, e As EventArgs) Handles netBtn_TavoliSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If pnlPulsanti.Controls.Count = 0 Then
            Return
         End If

         If Risorsa(1).Location.Y >= 0 Then
            Exit Sub
         Else
            Dim i As Integer
            For i = 1 To pnlPulsanti.Controls.Count
               Risorsa(i).Location = New Point(Risorsa(i).Location.X, Risorsa(i).Location.Y + ALTEZZA_TAVOLO_PULSANTI + 1)
            Next i
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_PosizionaTavoli_Click(sender As Object, e As EventArgs) Handles netBtn_PosizionaTavoli.Click
      PosizionaTavoli()
   End Sub

   Private Sub picImmagine_Paint(sender As Object, e As PaintEventArgs) Handles picImmagine.Paint
      If muoviPulsanti = True Then
         VisualizzaGrigliaTavoli()
      End If
   End Sub

   Private Sub netBtn_Listino_Click(sender As Object, e As EventArgs) Handles netBtn_Listino.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New TipoListinoPos
         If frm.ShowDialog() = DialogResult.OK Then
            ApplicaListino(frm.Tag.ToString)
         End If

         If impostaListino = False Then
            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Listino, "(Listino " & NumListino.ToString & ")", MODULO_TAVOLI)
         End If

         impostaListino = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Impostazioni_Click(sender As Object, e As EventArgs) Handles netBtn_Impostazioni.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New ImpostazioniPos(g_frmVCTavoli.Name)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_ListaPrenGiù_Click(sender As Object, e As EventArgs) Handles netBtn_ListaPrenGiù.Click
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

   Private Sub netBtn_ListaPrenSu_Click(sender As Object, e As EventArgs) Handles netBtn_ListaPrenSu.Click
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

End Class
