' Nome form:            POS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       10/04/2006
' Data ultima modifica: 24/04/2006
' Descrizione:          Interfaccia Punto cassa - conto immediato

#Region "Importazioni"

Imports System.IO
Imports System.Data.OleDb

#End Region

Public Class frmVCTavoli
   Inherits System.Windows.Forms.Form

#Region "Dichiarazioni"

   Const START_POS_X As Integer = 0
   Const START_POS_Y As Integer = 0
   Const LARGHEZZA As Integer = 48
   Const ALTEZZA As Integer = 48

   Const DIM_SPAZIO As Short = 8
   Const POS_Y_SALE As Integer = 675 '680 per posizionare sotto la piantina.
   Const ALTEZZA_SALE As Integer = 40
   Const ALTEZZA_RIGA_DETTAGLI As Short = 22

   Public Const LUNGHEZZA_ORA As Integer = 9
   Public Const LUNGHEZZA_ORA_BREVE As Integer = 8

   Public Const ANAG_TAVOLI As String = "Tavoli"
   Const TAB_CONTI_TAVOLI As String = "ContiTavoli"
   Const TAB_SALE As String = "Sale"
   Const TAB_PREN As String = "Prenotazioni"
   Const TAB_COMANDE As String = "Comande"
   Const TAB_PIATTI_ESAURITI As String = "PiattiEsauriti"
   Const TAB_CATEGORIE As String = "CategoriePiatti"
   Const TAB_MESSAGGI As String = "Messaggi"

   Public LARGHEZZA_RISORSA As Integer = LARGHEZZA
   Public ALTEZZA_RISORSA As Integer = ALTEZZA

   ' Colori utilizzati per la gestione dei Tavoli.
   Public TAVOLO_LIBERO As Color = Color.MediumSeaGreen
   Public TAVOLO_PRENOTATO As Color = Color.DodgerBlue
   Public TAVOLO_DEVE_ORDINARE As Color = Color.LightCoral
   Public TAVOLO_DA_SERVIRE As Color = Color.Brown
   Public TAVOLO_SERVITO As Color = Color.Gray
   Public TAVOLO_ATTESA_CONTO As Color = Color.DarkCyan
   Public TAVOLO_DA_LIBERARE As Color = Color.Olive

   Public Risorsa() As Button
   Public NumRisorse As Short = 0
   Public Sala() As Button
   Public NumSale As Short = 0
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
   Private modificatoStatoTavolo As Boolean = False

   Private ultimoReparto As String

   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0

   ' B_TODO: Codice da attivare per il comando Unisci.
   ' Per il tavolo da unire.
   'Private unisciTavoloId As String
   'Private unisciTavoloNum As Short

   Public copertiAnnulla As Boolean

   Private NumListino As Short
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Private impostaListino As Boolean

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
   Friend WithEvents cmdListino4 As System.Windows.Forms.Button
   Friend WithEvents cmdListino3 As System.Windows.Forms.Button
   Friend WithEvents cmdListino2 As System.Windows.Forms.Button
   Friend WithEvents cmdListino1 As System.Windows.Forms.Button
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents lblData As System.Windows.Forms.Label
   Friend WithEvents lblOra As System.Windows.Forms.Label
   Public WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Friend WithEvents cmdEsci As System.Windows.Forms.Button
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents cmdDettagliSu As System.Windows.Forms.Button
   Friend WithEvents cmdDettagliGiù As System.Windows.Forms.Button
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents Panel1 As System.Windows.Forms.Panel
   Friend WithEvents picImmagine As System.Windows.Forms.PictureBox
   Friend WithEvents lblTavolo As System.Windows.Forms.Label
   Friend WithEvents lblPosti As System.Windows.Forms.Label
   Friend WithEvents lblCoperti As System.Windows.Forms.Label
   Friend WithEvents lblCameriere As System.Windows.Forms.Label
   Friend WithEvents cmdPrenota As System.Windows.Forms.Button
   Friend WithEvents cmdApriTavolo As System.Windows.Forms.Button
   Friend WithEvents cmdConto As System.Windows.Forms.Button
   Friend WithEvents cmdOccupa As System.Windows.Forms.Button
   Friend WithEvents cmdLibera As System.Windows.Forms.Button
   Friend WithEvents cmdEsauriti As System.Windows.Forms.Button
   Friend WithEvents Panel3 As System.Windows.Forms.Panel
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
   Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
   Friend WithEvents cmdAsporto As System.Windows.Forms.Button
   Friend WithEvents cmdUnisci As System.Windows.Forms.Button
   Friend WithEvents cmdSepara As System.Windows.Forms.Button
   Friend WithEvents cmdSposta As System.Windows.Forms.Button
   Friend WithEvents Timer3 As System.Windows.Forms.Timer
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmVCTavoli))
      Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Luigi Montana", "12.30", "13.30", "10", ""}, -1)
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.Label1 = New System.Windows.Forms.Label()
      Me.cmdListino4 = New System.Windows.Forms.Button()
      Me.cmdListino3 = New System.Windows.Forms.Button()
      Me.cmdListino2 = New System.Windows.Forms.Button()
      Me.cmdListino1 = New System.Windows.Forms.Button()
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
      Me.cmdEsci = New System.Windows.Forms.Button()
      Me.lblData = New System.Windows.Forms.Label()
      Me.lblOra = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.cmdApriTavolo = New System.Windows.Forms.Button()
      Me.cmdConto = New System.Windows.Forms.Button()
      Me.cmdPrenota = New System.Windows.Forms.Button()
      Me.cmdOccupa = New System.Windows.Forms.Button()
      Me.cmdLibera = New System.Windows.Forms.Button()
      Me.cmdUnisci = New System.Windows.Forms.Button()
      Me.cmdSepara = New System.Windows.Forms.Button()
      Me.cmdEsauriti = New System.Windows.Forms.Button()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.lblPosti = New System.Windows.Forms.Label()
      Me.lblCoperti = New System.Windows.Forms.Label()
      Me.LblPostiLiberi = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.lstvDettagli = New System.Windows.Forms.ListView()
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Label15 = New System.Windows.Forms.Label()
      Me.cmdDettagliSu = New System.Windows.Forms.Button()
      Me.cmdDettagliGiù = New System.Windows.Forms.Button()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.picImmagine = New System.Windows.Forms.PictureBox()
      Me.lblCameriere = New System.Windows.Forms.Label()
      Me.Panel3 = New System.Windows.Forms.Panel()
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
      Me.cmdAsporto = New System.Windows.Forms.Button()
      Me.txtNotePren = New System.Windows.Forms.TextBox()
      Me.cmdSposta = New System.Windows.Forms.Button()
      Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.Panel1.SuspendLayout()
      CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.Panel3.SuspendLayout()
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
      'Label1
      '
      Me.Label1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(703, 11)
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
      Me.cmdListino4.Location = New System.Drawing.Point(967, 8)
      Me.cmdListino4.Name = "cmdListino4"
      Me.cmdListino4.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino4.TabIndex = 17
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
      Me.cmdListino3.Location = New System.Drawing.Point(925, 8)
      Me.cmdListino3.Name = "cmdListino3"
      Me.cmdListino3.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino3.TabIndex = 16
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
      Me.cmdListino2.Location = New System.Drawing.Point(883, 8)
      Me.cmdListino2.Name = "cmdListino2"
      Me.cmdListino2.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino2.TabIndex = 15
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
      Me.cmdListino1.Location = New System.Drawing.Point(841, 8)
      Me.cmdListino1.Name = "cmdListino1"
      Me.cmdListino1.Size = New System.Drawing.Size(40, 40)
      Me.cmdListino1.TabIndex = 14
      Me.cmdListino1.Text = "1"
      Me.cmdListino1.UseVisualStyleBackColor = False
      '
      'lblTavolo
      '
      Me.lblTavolo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTavolo.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblTavolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblTavolo.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblTavolo.Location = New System.Drawing.Point(871, 117)
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
      'cmdEsci
      '
      Me.cmdEsci.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdEsci.BackColor = System.Drawing.Color.LightCoral
      Me.cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdEsci.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEsci.ForeColor = System.Drawing.Color.White
      Me.cmdEsci.Location = New System.Drawing.Point(855, 662)
      Me.cmdEsci.Name = "cmdEsci"
      Me.cmdEsci.Size = New System.Drawing.Size(152, 40)
      Me.cmdEsci.TabIndex = 9
      Me.cmdEsci.Text = "&ESCI"
      Me.cmdEsci.UseVisualStyleBackColor = False
      '
      'lblData
      '
      Me.lblData.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblData.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblData.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblData.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblData.Location = New System.Drawing.Point(711, 64)
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
      Me.lblOra.Location = New System.Drawing.Point(711, 85)
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
      Me.Label2.Location = New System.Drawing.Point(695, 56)
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
      Me.Label7.Location = New System.Drawing.Point(711, 176)
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
      'cmdApriTavolo
      '
      Me.cmdApriTavolo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdApriTavolo.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdApriTavolo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdApriTavolo.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdApriTavolo.ForeColor = System.Drawing.Color.White
      Me.cmdApriTavolo.Location = New System.Drawing.Point(695, 470)
      Me.cmdApriTavolo.Name = "cmdApriTavolo"
      Me.cmdApriTavolo.Size = New System.Drawing.Size(152, 40)
      Me.cmdApriTavolo.TabIndex = 1
      Me.cmdApriTavolo.Text = "&APRI"
      Me.cmdApriTavolo.UseVisualStyleBackColor = False
      '
      'cmdConto
      '
      Me.cmdConto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdConto.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdConto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdConto.ForeColor = System.Drawing.Color.White
      Me.cmdConto.Location = New System.Drawing.Point(696, 662)
      Me.cmdConto.Name = "cmdConto"
      Me.cmdConto.Size = New System.Drawing.Size(152, 40)
      Me.cmdConto.TabIndex = 8
      Me.cmdConto.Text = "&P. CASSA"
      Me.cmdConto.UseVisualStyleBackColor = False
      '
      'cmdPrenota
      '
      Me.cmdPrenota.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdPrenota.BackColor = System.Drawing.Color.White
      Me.cmdPrenota.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdPrenota.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPrenota.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdPrenota.Location = New System.Drawing.Point(855, 566)
      Me.cmdPrenota.Name = "cmdPrenota"
      Me.cmdPrenota.Size = New System.Drawing.Size(152, 40)
      Me.cmdPrenota.TabIndex = 6
      Me.cmdPrenota.Text = "&PRENOTA"
      Me.cmdPrenota.UseVisualStyleBackColor = False
      '
      'cmdOccupa
      '
      Me.cmdOccupa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdOccupa.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdOccupa.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdOccupa.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdOccupa.ForeColor = System.Drawing.Color.White
      Me.cmdOccupa.Location = New System.Drawing.Point(695, 518)
      Me.cmdOccupa.Name = "cmdOccupa"
      Me.cmdOccupa.Size = New System.Drawing.Size(152, 40)
      Me.cmdOccupa.TabIndex = 3
      Me.cmdOccupa.Text = "&OCCUPA"
      Me.cmdOccupa.UseVisualStyleBackColor = False
      '
      'cmdLibera
      '
      Me.cmdLibera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdLibera.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdLibera.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdLibera.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdLibera.ForeColor = System.Drawing.Color.White
      Me.cmdLibera.Location = New System.Drawing.Point(855, 518)
      Me.cmdLibera.Name = "cmdLibera"
      Me.cmdLibera.Size = New System.Drawing.Size(152, 40)
      Me.cmdLibera.TabIndex = 4
      Me.cmdLibera.Text = "&LIBERA"
      Me.cmdLibera.UseVisualStyleBackColor = False
      '
      'cmdUnisci
      '
      Me.cmdUnisci.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdUnisci.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdUnisci.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdUnisci.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdUnisci.ForeColor = System.Drawing.Color.White
      Me.cmdUnisci.Location = New System.Drawing.Point(367, 674)
      Me.cmdUnisci.Name = "cmdUnisci"
      Me.cmdUnisci.Size = New System.Drawing.Size(152, 40)
      Me.cmdUnisci.TabIndex = 6
      Me.cmdUnisci.Text = "&UNISCI"
      Me.cmdUnisci.UseVisualStyleBackColor = False
      Me.cmdUnisci.Visible = False
      '
      'cmdSepara
      '
      Me.cmdSepara.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSepara.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdSepara.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdSepara.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdSepara.ForeColor = System.Drawing.Color.White
      Me.cmdSepara.Location = New System.Drawing.Point(527, 674)
      Me.cmdSepara.Name = "cmdSepara"
      Me.cmdSepara.Size = New System.Drawing.Size(152, 40)
      Me.cmdSepara.TabIndex = 7
      Me.cmdSepara.Text = "SEPA&RA"
      Me.cmdSepara.UseVisualStyleBackColor = False
      Me.cmdSepara.Visible = False
      '
      'cmdEsauriti
      '
      Me.cmdEsauriti.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdEsauriti.BackColor = System.Drawing.Color.Gray
      Me.cmdEsauriti.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEsauriti.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEsauriti.ForeColor = System.Drawing.Color.White
      Me.cmdEsauriti.Location = New System.Drawing.Point(695, 614)
      Me.cmdEsauriti.Name = "cmdEsauriti"
      Me.cmdEsauriti.Size = New System.Drawing.Size(312, 40)
      Me.cmdEsauriti.TabIndex = 7
      Me.cmdEsauriti.Text = "PIA&TTI ESAURITI"
      Me.cmdEsauriti.UseVisualStyleBackColor = False
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.BackColor = System.Drawing.Color.MidnightBlue
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.DodgerBlue
      Me.Label6.Location = New System.Drawing.Point(703, 117)
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
      Me.lblPosti.Location = New System.Drawing.Point(758, 152)
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
      Me.lblCoperti.Location = New System.Drawing.Point(868, 152)
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
      Me.LblPostiLiberi.Location = New System.Drawing.Point(959, 152)
      Me.LblPostiLiberi.Name = "LblPostiLiberi"
      Me.LblPostiLiberi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
      Me.LblPostiLiberi.Size = New System.Drawing.Size(16, 16)
      Me.LblPostiLiberi.TabIndex = 249
      Me.LblPostiLiberi.Text = "#"
      Me.LblPostiLiberi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label9.BackColor = System.Drawing.Color.White
      Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label9.ForeColor = System.Drawing.Color.DimGray
      Me.Label9.Location = New System.Drawing.Point(703, 241)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(296, 16)
      Me.Label9.TabIndex = 250
      Me.Label9.Text = "[ PRENOTAZIONI DEL GIORNO ]"
      Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lstvDettagli
      '
      Me.lstvDettagli.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagli.BackColor = System.Drawing.Color.White
      Me.lstvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6})
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagli.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1})
      Me.lstvDettagli.Location = New System.Drawing.Point(695, 280)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(312, 80)
      Me.lstvDettagli.TabIndex = 12
      Me.lstvDettagli.UseCompatibleStateImageBehavior = False
      Me.lstvDettagli.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Width = 0
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Width = 150
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader2.Width = 50
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader3.Width = 50
      '
      'ColumnHeader5
      '
      Me.ColumnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader5.Width = 40
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.Width = 0
      '
      'Label15
      '
      Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label15.BackColor = System.Drawing.Color.White
      Me.Label15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label15.ForeColor = System.Drawing.Color.Black
      Me.Label15.Location = New System.Drawing.Point(695, 233)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(312, 48)
      Me.Label15.TabIndex = 259
      Me.Label15.Text = "Cliente                               Dalle      Alle   Cop."
      Me.Label15.TextAlign = System.Drawing.ContentAlignment.BottomLeft
      '
      'cmdDettagliSu
      '
      Me.cmdDettagliSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliSu.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliSu.Image = CType(resources.GetObject("cmdDettagliSu.Image"), System.Drawing.Image)
      Me.cmdDettagliSu.Location = New System.Drawing.Point(856, 424)
      Me.cmdDettagliSu.Name = "cmdDettagliSu"
      Me.cmdDettagliSu.Size = New System.Drawing.Size(152, 40)
      Me.cmdDettagliSu.TabIndex = 11
      Me.cmdDettagliSu.UseVisualStyleBackColor = False
      '
      'cmdDettagliGiù
      '
      Me.cmdDettagliGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliGiù.Image = CType(resources.GetObject("cmdDettagliGiù.Image"), System.Drawing.Image)
      Me.cmdDettagliGiù.Location = New System.Drawing.Point(696, 424)
      Me.cmdDettagliGiù.Name = "cmdDettagliGiù"
      Me.cmdDettagliGiù.Size = New System.Drawing.Size(152, 40)
      Me.cmdDettagliGiù.TabIndex = 10
      Me.cmdDettagliGiù.UseVisualStyleBackColor = False
      '
      'Label16
      '
      Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label16.BackColor = System.Drawing.Color.White
      Me.Label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(695, 359)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(312, 58)
      Me.Label16.TabIndex = 260
      Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel1
      '
      Me.Panel1.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Panel1.Controls.Add(Me.picImmagine)
      Me.Panel1.Location = New System.Drawing.Point(0, 0)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(696, 672)
      Me.Panel1.TabIndex = 0
      '
      'picImmagine
      '
      Me.picImmagine.BackColor = System.Drawing.Color.White
      Me.picImmagine.Location = New System.Drawing.Point(8, 10)
      Me.picImmagine.Name = "picImmagine"
      Me.picImmagine.Size = New System.Drawing.Size(680, 654)
      Me.picImmagine.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.picImmagine.TabIndex = 227
      Me.picImmagine.TabStop = False
      '
      'lblCameriere
      '
      Me.lblCameriere.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblCameriere.AutoSize = True
      Me.lblCameriere.BackColor = System.Drawing.Color.MidnightBlue
      Me.lblCameriere.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblCameriere.ForeColor = System.Drawing.Color.DodgerBlue
      Me.lblCameriere.Location = New System.Drawing.Point(792, 176)
      Me.lblCameriere.Name = "lblCameriere"
      Me.lblCameriere.Size = New System.Drawing.Size(16, 16)
      Me.lblCameriere.TabIndex = 263
      Me.lblCameriere.Text = "#"
      Me.lblCameriere.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'Panel3
      '
      Me.Panel3.BackColor = System.Drawing.Color.Black
      Me.Panel3.Controls.Add(Me.Label5)
      Me.Panel3.Controls.Add(Me.lblInCorso)
      Me.Panel3.Controls.Add(Me.lblScaduta)
      Me.Panel3.Controls.Add(Me.lblVostraCanc)
      Me.Panel3.Controls.Add(Me.lblNostraCanc)
      Me.Panel3.Controls.Add(Me.lblSospesa)
      Me.Panel3.Controls.Add(Me.lblConfermata)
      Me.Panel3.Controls.Add(Me.Label3)
      Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.Panel3.Location = New System.Drawing.Point(0, 716)
      Me.Panel3.Name = "Panel3"
      Me.Panel3.Size = New System.Drawing.Size(1015, 16)
      Me.Panel3.TabIndex = 264
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
      Me.Label8.Location = New System.Drawing.Point(711, 200)
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
      Me.Label11.Location = New System.Drawing.Point(863, 200)
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
      Me.lblLiberi.Location = New System.Drawing.Point(951, 200)
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
      Me.lblOccupati.Location = New System.Drawing.Point(823, 200)
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
      Me.Label4.Location = New System.Drawing.Point(711, 152)
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
      Me.Label12.Location = New System.Drawing.Point(807, 152)
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
      Me.Label13.Location = New System.Drawing.Point(911, 152)
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
      Me.lblOraOcc.Location = New System.Drawing.Point(711, 56)
      Me.lblOraOcc.Name = "lblOraOcc"
      Me.lblOraOcc.Size = New System.Drawing.Size(15, 13)
      Me.lblOraOcc.TabIndex = 272
      Me.lblOraOcc.Text = "#"
      Me.lblOraOcc.TextAlign = System.Drawing.ContentAlignment.TopCenter
      Me.lblOraOcc.Visible = False
      '
      'cmdAsporto
      '
      Me.cmdAsporto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAsporto.BackColor = System.Drawing.Color.LightSalmon
      Me.cmdAsporto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdAsporto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAsporto.ForeColor = System.Drawing.Color.White
      Me.cmdAsporto.Location = New System.Drawing.Point(695, 566)
      Me.cmdAsporto.Name = "cmdAsporto"
      Me.cmdAsporto.Size = New System.Drawing.Size(152, 40)
      Me.cmdAsporto.TabIndex = 5
      Me.cmdAsporto.Text = "ASPO&RTO"
      Me.cmdAsporto.UseVisualStyleBackColor = False
      '
      'txtNotePren
      '
      Me.txtNotePren.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtNotePren.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.txtNotePren.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNotePren.ForeColor = System.Drawing.Color.Black
      Me.txtNotePren.Location = New System.Drawing.Point(697, 362)
      Me.txtNotePren.MaxLength = 0
      Me.txtNotePren.Multiline = True
      Me.txtNotePren.Name = "txtNotePren"
      Me.txtNotePren.ReadOnly = True
      Me.txtNotePren.ScrollBars = System.Windows.Forms.ScrollBars.Both
      Me.txtNotePren.Size = New System.Drawing.Size(308, 50)
      Me.txtNotePren.TabIndex = 13
      '
      'cmdSposta
      '
      Me.cmdSposta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdSposta.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdSposta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdSposta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdSposta.ForeColor = System.Drawing.Color.White
      Me.cmdSposta.Location = New System.Drawing.Point(855, 470)
      Me.cmdSposta.Name = "cmdSposta"
      Me.cmdSposta.Size = New System.Drawing.Size(152, 40)
      Me.cmdSposta.TabIndex = 2
      Me.cmdSposta.Text = "&SPOSTA"
      Me.cmdSposta.UseVisualStyleBackColor = False
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
      'frmVCTavoli
      '
      Me.AcceptButton = Me.cmdApriTavolo
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdEsci
      Me.ClientSize = New System.Drawing.Size(1015, 732)
      Me.Controls.Add(Me.cmdSposta)
      Me.Controls.Add(Me.txtNotePren)
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
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmdAsporto)
      Me.Controls.Add(Me.Panel3)
      Me.Controls.Add(Me.Label16)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.cmdDettagliSu)
      Me.Controls.Add(Me.cmdDettagliGiù)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.cmdEsauriti)
      Me.Controls.Add(Me.cmdSepara)
      Me.Controls.Add(Me.cmdUnisci)
      Me.Controls.Add(Me.cmdLibera)
      Me.Controls.Add(Me.cmdOccupa)
      Me.Controls.Add(Me.cmdPrenota)
      Me.Controls.Add(Me.cmdConto)
      Me.Controls.Add(Me.cmdApriTavolo)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.lblData)
      Me.Controls.Add(Me.lblOra)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.lblTavolo)
      Me.Controls.Add(Me.cmdEsci)
      Me.Controls.Add(Me.cmdListino4)
      Me.Controls.Add(Me.cmdListino3)
      Me.Controls.Add(Me.cmdListino2)
      Me.Controls.Add(Me.cmdListino1)
      Me.Controls.Add(Me.Label15)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Panel1)
      Me.ForeColor = System.Drawing.Color.Silver
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "frmVCTavoli"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Visual POS - GESTIONE TAVOLI"
      Me.Panel1.ResumeLayout(False)
      CType(Me.picImmagine, System.ComponentModel.ISupportInitialize).EndInit()
      Me.Panel3.ResumeLayout(False)
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Sub DisegnaRisorse(ByVal nome As String, ByVal note As String, ByVal id As Integer, ByVal posX As Integer, ByVal posY As Integer, ByVal colore As Color)
      Try
         NumRisorse += 1
         Risorsa(NumRisorse) = New Button
         Risorsa(NumRisorse).Name = id.ToString
         Risorsa(NumRisorse).Tag = NumRisorse
         Risorsa(NumRisorse).Location = New Point(posX, posY)
         Risorsa(NumRisorse).Size = New Size(LARGHEZZA_RISORSA, ALTEZZA_RISORSA)
         Risorsa(NumRisorse).FlatStyle = FlatStyle.Popup
         Risorsa(NumRisorse).BackColor = colore
         Risorsa(NumRisorse).ForeColor = Color.White
         Risorsa(NumRisorse).Font = New Font("Microsoft Sans Serif", 8, Risorsa(NumRisorse).Font.Style)  'Or FontStyle.Bold

         Risorsa(NumRisorse).Text = nome

         If note = "" Then
            ToolTip1.SetToolTip(Risorsa(NumRisorse), "Nessuna nota.")
         Else
            ToolTip1.SetToolTip(Risorsa(NumRisorse), note)
         End If

         Panel1.Controls.Add(Risorsa(NumRisorse))

         Risorsa(NumRisorse).BringToFront()

         AddHandler Risorsa(NumRisorse).Click, AddressOf Risorsa_Click
         AddHandler Risorsa(NumRisorse).BackColorChanged, AddressOf Risorsa_BackColorChanged
         'AddHandler Risorsa(NumRisorse).MouseUp, AddressOf Risorsa_MouseUp
         'AddHandler Risorsa(NumRisorse).MouseDown, AddressOf Risorsa_MouseDown

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DisegnaSale(ByVal nome As String, ByVal id As Integer, ByVal larghezza As Integer, ByVal iniziale As String)
      Try
         NumSale += 1

         Dim posX As Integer = CalcolaPosizioneCtrl(NumSale, DIM_SPAZIO, larghezza)

         Sala(NumSale) = New Button
         Sala(NumSale).Name = id.ToString
         Sala(NumSale).Tag = nome
         Sala(NumSale).Location = New Point(posX, POS_Y_SALE)
         Sala(NumSale).Size = New Size(larghezza, ALTEZZA_SALE)
         Sala(NumSale).FlatStyle = FlatStyle.Popup
         If iniziale = "Sì" Then
            Sala(NumSale).BackColor = Color.LightCoral
         Else
            Sala(NumSale).BackColor = Color.DodgerBlue
         End If
         Sala(NumSale).ForeColor = Color.White
         Sala(NumSale).Font = New Font("Microsoft Sans Serif", 16, Sala(NumSale).Font.Style Or FontStyle.Bold)
         Sala(NumSale).Text = nome

         Me.Controls.Add(Sala(NumSale))

         'Sala(NumSale).Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
         Sala(NumSale).BringToFront()

         AddHandler Sala(NumSale).Click, AddressOf Sala_Click
         'AddHandler Risorsa(NumRisorse).MouseUp, AddressOf Risorsa_MouseUp
         'AddHandler Risorsa(NumRisorse).MouseDown, AddressOf Risorsa_MouseDown

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiDatiRisorse(ByVal tabella As String, ByVal val As String) As Boolean
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
      Dim colore As String
      Dim ora As String
      Dim i As Integer = 0
      Dim datiTrovati As Boolean = False

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Sala = '" & val & "' AND Escludi = 'No' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         NumTavoliOccupati = 0

         Do While dr.Read()
            If IsDBNull(dr.Item("Descrizione")) = False Then
               descrizione = dr.Item("Descrizione")
            Else
               descrizione = ""
            End If
            If IsDBNull(dr.Item("Posti")) = False Then
               posti = dr.Item("Posti")
            Else
               posti = "2"
            End If
            If IsDBNull(dr.Item("Cameriere")) = False Then
               cameriere = dr.Item("Cameriere")
            Else
               cameriere = ""
            End If
            If IsDBNull(dr.Item("Listino")) = False Then
               listino = dr.Item("Listino")
            Else
               listino = ""
            End If
            If IsDBNull(dr.Item("Note")) = False Then
               note = dr.Item("Note")
            Else
               note = ""
            End If
            If IsDBNull(dr.Item("PosX")) = False Then
               posX = dr.Item("PosX")
            Else
               posX = 0
            End If
            If IsDBNull(dr.Item("PosY")) = False Then
               posY = dr.Item("PosY")
            Else
               posY = 0
            End If
            If IsDBNull(dr.Item("Orientamento")) = False Then
               orientamento = dr.Item("Orientamento")
            Else
               orientamento = "Orizzontale"
            End If
            If IsDBNull(dr.Item("Colore")) = False Then
               colore = dr.Item("Colore")
            Else
               colore = Convert.ToString(Color.MediumSeaGreen.ToArgb)
            End If
            If IsDBNull(dr.Item("OraOcc")) = False Then
               If dr.Item("OraOcc") <> "" Then
                  ora = dr.Item("OraOcc")
               Else
                  ora = ""
               End If
            Else
               ora = ""
            End If

            infoRisorse = "Posti: " & posti & vbCrLf & _
                          "Cameriere: " & cameriere & vbCrLf & _
                          "Listino: " & listino & vbCrLf & _
                          "Note: " & note

            ImpostaDimensioniTavolo(posti, orientamento)

            DisegnaRisorse(descrizione, infoRisorse, dr.Item("Id"), posX, posY, Color.FromArgb(colore))

            If ora <> "" Then
               NumTavoliOccupati += 1
               OraOccupazione(NumTavoliOccupati - 1) = Convert.ToDateTime(ora)
               IndiceTavoloOccupato(NumTavoliOccupati - 1) = Risorsa(NumRisorse).Tag
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

   Public Sub CancellaColorePren(ByVal indice As Integer)
      Try
         MessageBox.Show(indice)
         If Risorsa(indice).Visible = False Then
            Exit Sub
         End If

         If ConfrontaColore(Risorsa(indice).BackColor, Color.DodgerBlue, Color.DodgerBlue) = True Then
            Risorsa(indice).BackColor = Color.MediumSeaGreen
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
               idTavolo = dr.Item("IdRisorsa")
            Else
               idTavolo = 0
            End If

            Dim i As Integer = 0

            For i = 1 To numRec - 1
               If Risorsa(i).Visible = False Then
                  Exit For
               End If
               If Risorsa(i).Name = idTavolo.ToString Then
                  If ConfrontaColore(Risorsa(i).BackColor, Color.MediumSeaGreen, Color.MediumSeaGreen) = True Then
                     Risorsa(i).BackColor = Color.DodgerBlue
                     Risorsa(i).Text = ""
                     Risorsa(i).Text = dr.Item("DescrizioneRisorsa") & vbCrLf & "[" & FormattaOreMinuti(dr.Item("OraInizio")) & "]"
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
            ' Indice
            lstvDettagli.Items.Add(lstvDettagli.Items.Count)

            ' Assegna il colore della prenotazione.
            If IsDBNull(dr.Item("Colore")) = False Then
               Dim colore As Integer = Convert.ToInt32(dr.Item("Colore"))
               If colore <> 0 And colore <> Convert.ToString(Color.White.ToArgb) Then
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).BackColor = Color.FromArgb(colore)
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).ForeColor = Color.White
               End If
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).BackColor = Color.White
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).ForeColor = Color.Black
            End If

            ' Cliente
            If IsDBNull(dr.Item("Cliente")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Cliente"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item(""))
            End If
            If IsDBNull(dr.Item("OraInizio")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(FormattaOreMinuti(dr.Item("OraInizio")))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item(""))
            End If
            If IsDBNull(dr.Item("OraFine")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(FormattaOreMinuti(dr.Item("OraFine")))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item(""))
            End If
            If IsDBNull(dr.Item("Persone")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Persone"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item(""))
            End If
            If IsDBNull(dr.Item("Note")) = False Then
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item("Note"))
            Else
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(dr.Item(""))
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
               lblTavolo.Text = dr.Item("Descrizione")
            Else
               lblTavolo.Text = ""
            End If
            If IsDBNull(dr.Item("Posti")) = False Then
               lblPosti.Text = dr.Item("Posti")
            Else
               lblPosti.Text = ""
            End If
            If IsDBNull(dr.Item("Coperti")) = False Then
               lblCoperti.Text = dr.Item("Coperti")
            Else
               lblCoperti.Text = ""
            End If
            If IsDBNull(dr.Item("Cameriere")) = False Then
               lblCameriere.Text = dr.Item("Cameriere")
            Else
               lblCameriere.Text = ""
            End If

            Select Case dr.Item("Listino")
               Case 1
                  cmdListino1.PerformClick()
               Case 2
                  cmdListino2.PerformClick()
               Case 3
                  cmdListino3.PerformClick()
               Case 4
                  cmdListino4.PerformClick()
            End Select

            If IsDBNull(dr.Item("OraOcc")) = False Then
               lblOraOcc.Text = dr.Item("OraOcc")
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

   Public Sub LeggiDatiSale(ByVal tabella As String, ByVal larghezza As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            DisegnaSale(dr.Item("Descrizione"), dr.Item("Id"), larghezza, dr.Item("Iniziale"))
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

   Public Sub CaricaImgSala(ByVal tabella As String, ByVal val As String)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Descrizione = '" & val & "' ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            Dim imgSfondo As String = dr.Item("Sfondo")

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
      Const DIM_MAX As Short = 680
      Const POS_INIZIALE As Short = 8

      Dim dimControllo As Integer

      dimControllo = CalcolaDimensioneCtrl(LeggiNumRecord(TAB_SALE, cn, cmd), DIM_MAX, DIM_SPAZIO)

      LeggiDatiSale(TAB_SALE, dimControllo)

      Dim iniziale As Boolean = False
      Dim i As Integer
      For i = 1 To NumSale
         If ConfrontaColore(Sala(i).BackColor, Color.LightCoral, Color.LightCoral) = True Then
            CaricaImgSala(TAB_SALE, Sala(i).Tag)
            salaSelezionata = Sala(i).Tag
            iniziale = True
            Return LeggiDatiRisorse(ANAG_TAVOLI, Sala(i).Tag)
         End If
      Next

      ' Nel caso non è impostata una sala iniziale carica la prima.
      If iniziale = False Then
         Sala(1).BackColor = Color.LightCoral
         CaricaImgSala(TAB_SALE, Sala(1).Tag)
         salaSelezionata = Sala(i).Tag
         Return LeggiDatiRisorse(ANAG_TAVOLI, Sala(1).Tag)
      End If

   End Function

   Private Sub ImpostaDimensioniTavolo(ByVal posti As String, ByVal orientamento As String)
      Try
         Dim numPosti As Integer = CInt(posti)

         ' Tavolo standard.
         If numPosti < 5 Then
            LARGHEZZA_RISORSA = LARGHEZZA
            ALTEZZA_RISORSA = ALTEZZA

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
                     LARGHEZZA_RISORSA = (postiDaAgg * LARGHEZZA)
                     ALTEZZA_RISORSA = ALTEZZA
                  End If

               Case "Verticale"
                  If postiDaAgg <> 0 Then
                     ALTEZZA_RISORSA = (postiDaAgg * ALTEZZA)
                     LARGHEZZA_RISORSA = LARGHEZZA
                  End If
            End Select

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub RimuoviTavoli()
      Dim i As Integer = 0
      For i = 0 To Panel1.Controls.Count - 1
         If Panel1.Controls.Contains(Risorsa(i)) = True Then
            Panel1.Controls.Remove(Risorsa(i))
         End If
      Next
   End Sub

   Public Sub AggiornaTavoli()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         RimuoviTavoli()

         Dim i As Integer
         For i = 1 To NumSale
            If ConfrontaColore(Sala(i).BackColor, Color.LightCoral, Color.LightCoral) = True Then
               NumRisorse = 0
               LeggiDatiRisorse(ANAG_TAVOLI, Sala(i).Text)
               Exit Sub
            End If
         Next

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Sub AggiornaVCTavoli()
      Try
         Dim numTavoli As Integer = LeggiNumRecord(ANAG_TAVOLI, cn, cmd)
         ReDim Risorsa(numTavoli)
         ReDim Sala(LeggiNumRecord(TAB_SALE, cn, cmd))
         ReDim IndiceTavoloOccupato(numTavoli)
         ReDim OraOccupazione(numTavoli)

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
            If Risorsa(i).Name = id Then
               indiceTavoloSel = i
            End If
         Next

         NumTavoliOccupati += 1

         IndiceTavoloOccupato(NumTavoliOccupati - 1) = indiceTavoloSel

         OraOccupazione(NumTavoliOccupati - 1) = New DateTime(Today.Year, Today.Month, Today.Day, Today.Now.Hour, Today.Now.Minute, Today.Now.Second)

         Risorsa(indiceTavoloSel).BackColor = TAVOLO_DEVE_ORDINARE

         ModificaStatoTavolo(ANAG_TAVOLI, Risorsa(indiceTavoloSel).Name, _
                 TAVOLO_DEVE_ORDINARE, _
                 Convert.ToString(OraOccupazione(NumTavoliOccupati - 1)), _
                 coperti)

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
         If Risorsa(i).Name = id Then
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

      If ConfrontaColore(Risorsa(indiceTavoloSel).BackColor, TAVOLO_DA_LIBERARE, TAVOLO_DA_LIBERARE) = False Then
         EliminaComandeTavolo(Risorsa(indiceTavoloSel).Name)
         Risorsa(indiceTavoloSel).Text = Risorsa(indiceTavoloSel).Text.Remove(Risorsa(indiceTavoloSel).Text.Length - LUNGHEZZA_ORA_BREVE, LUNGHEZZA_ORA_BREVE)
      End If

      ModificaStatoTavolo(ANAG_TAVOLI, Risorsa(indiceTavoloSel).Name, TAVOLO_LIBERO, "", "")
      Risorsa(indiceTavoloSel).BackColor = TAVOLO_LIBERO

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
         If Risorsa(i).Name = id Then
            indiceTavoloSel = i
         End If
      Next

      Risorsa(indiceTavoloSel).BackColor = TAVOLO_DA_SERVIRE
      ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(indiceTavoloSel).Name, TAVOLO_DA_SERVIRE)

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
         If Risorsa(i).Name = id Then
            indiceTavoloSel = i
         End If
      Next

      Risorsa(indiceTavoloSel).BackColor = TAVOLO_SERVITO
      ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(indiceTavoloSel).Name, TAVOLO_SERVITO)

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
         If Risorsa(i).Name = id Then
            indiceTavoloSel = i
         End If
      Next

      Risorsa(indiceTavoloSel).BackColor = TAVOLO_ATTESA_CONTO
      ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(indiceTavoloSel).Name, TAVOLO_ATTESA_CONTO)

      AggiornaDisplay()

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Public Function PalmSalvaComande(ByVal idPiatto As Integer, ByVal quantità As Integer, ByVal importo As String, _
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
                  .Descrizione = dr.Item("Descrizione")
               Else
                  .Descrizione = ""
               End If

               ' Importo.
               .ImportoNetto = importo

               ' Prezzo.
               Select Case NumListino
                  Case Listino.Uno
                     If IsDBNull(dr.Item("Listino1")) = False Then
                        If dr.Item("Listino1") <> "" Then
                           .ValoreUnitario = dr.Item("Listino1")
                        Else
                           .ValoreUnitario = VALORE_ZERO
                        End If
                     Else
                        .ValoreUnitario = VALORE_ZERO
                     End If

                  Case Listino.Due
                     If IsDBNull(dr.Item("Listino2")) = False Then
                        If dr.Item("Listino2") <> "" Then
                           .ValoreUnitario = dr.Item("Listino2")
                        Else
                           .ValoreUnitario = VALORE_ZERO
                        End If
                     Else
                        .ValoreUnitario = VALORE_ZERO
                     End If

                  Case Listino.Tre
                     If IsDBNull(dr.Item("Listino3")) = False Then
                        If dr.Item("Listino3") <> "" Then
                           .ValoreUnitario = dr.Item("Listino3")
                        Else
                           .ValoreUnitario = VALORE_ZERO
                        End If
                     Else
                        .ValoreUnitario = VALORE_ZERO
                     End If

                  Case Listino.Quattro
                     If IsDBNull(dr.Item("Listino4")) = False Then
                        If dr.Item("Listino4") <> "" Then
                           .ValoreUnitario = dr.Item("Listino4")
                        Else
                           .ValoreUnitario = VALORE_ZERO
                        End If
                     Else
                        .ValoreUnitario = VALORE_ZERO
                     End If
               End Select

               ' Id Piatto.
               If IsDBNull(dr.Item("Id")) = False Then
                  .IdPiatto = dr.Item("Id")
               End If

               ' Categoria.
               If IsDBNull(dr.Item("Categoria")) = False Then
                  .CategoriaPiatto = dr.Item("Categoria")
                  .Reparto = LeggiReparto(TAB_CATEGORIE, dr.Item("Categoria"))
                  ultimoReparto = .Reparto
               End If

               ' Inviata.
               .Inviata = "No"

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
            ' Inviata.
            .Inviata = "No"

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

   Public Function LeggiCameriere(ByVal tabella As String, ByVal idTavolo As Integer) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & idTavolo, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            If IsDBNull(dr.Item("Cameriere")) = False Then
               Return dr.Item("Cameriere")
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
         sql = String.Format("UPDATE {0} " & _
                             "SET Colore = {1}, " & _
                             "OraOcc = '{2}', " & _
                             "Coperti = '{3}' " & _
                             "WHERE Id = {4}", _
                             tabella, _
                             Convert.ToString(colore.ToArgb), _
                             ora, _
                             coperti, _
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
         sql = String.Format("UPDATE {0} " & _
                             "SET Colore = {1} " & _
                             "WHERE Id = {2}", _
                             tabella, _
                             Convert.ToString(colore.ToArgb), _
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
               Dim tipoDati As String

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
               Dim tipoDati As String

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
         Dim cancellaFile As Boolean

         If abilita = False Then
            Exit Sub
         End If

         ' Controlla se ci sono file da leggere.
         fileComandi = Directory.GetFiles(PercorsoRP, "CHS_CMD*")

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
                  Dim tipoDati As String

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
      If ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_PRENOTATO, TAVOLO_PRENOTATO) = True Then
         lblCoperti.Text = LeggiNumCopertiPren(TAB_PREN, dataOggi, Risorsa(tavoloSelezionato).Name).ToString
      Else
         lblCoperti.Text = LeggiNumCopertiOcc(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name).ToString
      End If
      NumCopertiRistorante = lblCoperti.Text
      Dim coperti As Integer = CInt(lblCoperti.Text)
      Dim posti As Integer = CInt(lblPosti.Text)
      LblPostiLiberi.Text = Convert.ToString(posti - coperti)

      lblOccupati.Text = LeggiNumTavoliOccupati(ANAG_TAVOLI, cn, cmd).ToString
      lblLiberi.Text = LeggiNumTavoliLiberi(ANAG_TAVOLI, cn, cmd).ToString
   End Sub

   Public Function SpostaComandeTavolo(ByVal idTavoloA As Integer, ByVal idTavoloB As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET IdRisorsa = @IdRisorsa " & _
                             "WHERE IdRisorsa = {1}", _
                             TAB_COMANDE, _
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
               colore = dr.Item("Colore")
            Else
               colore = Color.MediumSeaGreen.ToArgb
            End If
            If IsDBNull(dr.Item("OraOcc")) = False Then
               oraOcc = dr.Item("OraOcc")
            Else
               oraOcc = ""
            End If
            If IsDBNull(dr.Item("Coperti")) = False Then
               coperti = dr.Item("Coperti")
            Else
               coperti = ""
            End If
         Loop

         dr.Close()

         ' Ripristina i dati del Tavolo da spostare.
         ' Avvia una transazione.
         tr1 = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET Colore = @Colore, " & _
                             "OraOcc = @OraOcc, " & _
                             "Coperti = @Coperti " & _
                             "WHERE Id = {1}", _
                             ANAG_TAVOLI, _
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
            sql = String.Format("UPDATE {0} " & _
                                "SET Colore = @Colore, " & _
                                "OraOcc = @OraOcc, " & _
                                "Coperti = @Coperti " & _
                                "WHERE Id = {1}", _
                                ANAG_TAVOLI, _
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
            sql = String.Format("UPDATE {0} " & _
                                "SET Colore = @Colore, " & _
                                "Coperti = @Coperti " & _
                                "WHERE Id = {1}", _
                                ANAG_TAVOLI, _
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
         sql = String.Format("UPDATE {0} " & _
                             "SET IdTavolo = @IdTavolo " & _
                             "WHERE IdTavolo = '{1}'", _
                             TAB_CONTI_TAVOLI, _
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
               If Risorsa(IndiceTavoloOccupato(i)).Name = idTavoloA Then
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
         Dim i As Integer

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
      If ConfrontaColore(cmdSposta.BackColor, Color.Black, Color.Black) = True Then
         MessageBox.Show("Completare l'operazione di spostamento selezionando il Tavolo desiderato.", _
                         NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return True
      Else
         Return False
      End If
   End Function

   Private Function UnioneInCorso() As Boolean
      If ConfrontaColore(cmdUnisci.BackColor, Color.Black, Color.Black) = True Then
         MessageBox.Show("Completare l'operazione di unione selezionando il Tavolo desiderato.", _
                         NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Return True
      Else
         Return False
      End If
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

   Private Sub Risorsa_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         impostaListino = True

         tavoloSelezionato = CInt(sender.Tag)
         LeggiDatiTavolo(ANAG_TAVOLI, CInt(sender.Name))

         AggiornaDisplay()

         ' Carica le prenotazioni del giorno per il tavolo selezionato.
         LeggiDatiPrenTavolo(TAB_PREN, dataOggi, sender.Name)

         ' -----------------------------------------------------------------------------------------------------------------------------------
         ' SE È STATO SCELTO IL COMANDO SPOSTA.
         ' -----------------------------------------------------------------------------------------------------------------------------------
         If spostaTavoloId <> String.Empty Then
            If ConfrontaColore(sender.BackColor, TAVOLO_ATTESA_CONTO, TAVOLO_ATTESA_CONTO) = False Then

               ' Verifica se il tavolo di destinazione è già occupato.
               Dim oraOccPresente As Boolean = False
               If ConfrontaColore(sender.BackColor, TAVOLO_DEVE_ORDINARE, TAVOLO_DEVE_ORDINARE) = True Then
                  oraOccPresente = True
               End If
               If ConfrontaColore(sender.BackColor, TAVOLO_DA_SERVIRE, TAVOLO_DA_SERVIRE) = True Then
                  oraOccPresente = True
               End If
               If ConfrontaColore(sender.BackColor, TAVOLO_SERVITO, TAVOLO_SERVITO) = True Then
                  oraOccPresente = True
               End If

               If SpostaComandeTavolo(spostaTavoloId, sender.Name) = True Then
                  SpostaDatiTavolo(spostaTavoloId, sender.Name, oraOccPresente)
                  SpostaOccupazioneTavolo(spostaTavoloId)
                  If salaSel = salaSelezionata Then
                     Risorsa(spostaTavoloNum).Text = Risorsa(spostaTavoloNum).Text.Remove(Risorsa(spostaTavoloNum).Text.Length - LUNGHEZZA_ORA, LUNGHEZZA_ORA)
                     Risorsa(spostaTavoloNum).BackColor = TAVOLO_LIBERO
                  End If
                  sender.BackColor = spostaTavoloColore
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
               g_frmMain.RegistraOperazione(TipoOperazione.SpostaTavolo, "(" & Risorsa(spostaTavoloNum).Text & " -> " & lblTavolo.Text & ")", MODULO_TAVOLI)

               cmdSposta.BackColor = Color.DodgerBlue
               salaSel = ""
               spostaTavoloId = String.Empty
               spostaTavoloNum = Nothing
               spostaTavoloColore = Nothing

               If salaSel <> salaSelezionata Then
                  RimuoviTavoli()
                  NumRisorse = 0
                  If LeggiDatiRisorse(ANAG_TAVOLI, salaSelezionata) = True Then
                     Exit Sub
                  End If
               End If

               Exit Sub
            Else
               MessageBox.Show("Non è possibile completare l'operazione il Tavolo selezionato ha il conto chiuso.", _
                               NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

               cmdSposta.BackColor = Color.DodgerBlue
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
         '      'Risorsa(unisciTavoloNum).Text = Risorsa(unisciTavoloNum).Text.Remove(Risorsa(unisciTavoloNum).Text.Length - LUNGHEZZA_ORA, LUNGHEZZA_ORA)
         '      Risorsa(unisciTavoloNum).Text = Risorsa(unisciTavoloNum).Text & vbCrLf & "-> " & sender.Text.Remove(sender.Text.Length - LUNGHEZZA_ORA, LUNGHEZZA_ORA)
         '      Risorsa(unisciTavoloNum).BackColor = sender.BackColor
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
         If ConfrontaColore(sender.BackColor, TAVOLO_DA_SERVIRE, TAVOLO_DA_SERVIRE) = True Then
            Dim risposta As Integer
            risposta = MessageBox.Show("Al tavolo selezionato le ordinazioni sono state servite?", _
                                       NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If risposta = DialogResult.Yes Then
               sender.BackColor = TAVOLO_SERVITO
               ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name, TAVOLO_SERVITO)
               Exit Sub
            Else
               Exit Sub
            End If
         End If

         ' -----------------------------------------------------------------------------------------------------------------------------------
         ' Se lo stato del tavolo è SERVITO allora chiede se si vuole chiudere il conto.
         ' -----------------------------------------------------------------------------------------------------------------------------------
         If ConfrontaColore(sender.BackColor, TAVOLO_SERVITO, TAVOLO_SERVITO) = True Then
            Dim risposta As Integer
            risposta = MessageBox.Show("Al tavolo selezionato si desidera chiudere il conto?", _
                                       NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If risposta = DialogResult.Yes Then
               sender.BackColor = TAVOLO_ATTESA_CONTO
               ModificaStatoColoreTavolo(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name, TAVOLO_ATTESA_CONTO)
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

   Private Sub Risorsa_BackColorChanged(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         modificatoStatoTavolo = True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub Sala_Click(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim i As Integer
         For i = 1 To NumSale
            Sala(i).BackColor = Color.DodgerBlue
         Next
         sender.BackColor = Color.LightCoral
         salaSelezionata = sender.Text

         RimuoviTavoli()

         CaricaImgSala(TAB_SALE, sender.Text)

         NumRisorse = 0

         If LeggiDatiRisorse(ANAG_TAVOLI, sender.Text) = True Then
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
         VerificaPresenzaFileTemp(AbilitaPalmare)

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub VCTavoli_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      impostaListino = True

      AggiornaVCTavoli()

      ' Attiva/Disattiva la gestione dei palmari.
      Timer3.Interval = FreqAggPalmare
      Timer3.Enabled = AbilitaPalmare

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
         If g_frmVCTavoli.Tag = "OPERATORE" Then
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
      ' 1080 - Valore non più utilizzato perchè non compatibile con risoluzione 1024x748.
      If Me.Width <= 1025 Then
         Me.Width = 1025
      End If

      ' 784 - Valore non più utilizzato perchè non compatibile con risoluzione 1024x748.
      If Me.Height <= 765 Then
         Me.Height = 765
      End If
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

   Private Sub cmdListino2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListino2.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         cmdListino1.BackColor = Color.DodgerBlue
         cmdListino2.BackColor = Color.LightCoral
         cmdListino3.BackColor = Color.DodgerBlue
         cmdListino4.BackColor = Color.DodgerBlue

         NumListino = Listino.Due

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

   Private Sub cmdListino3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListino3.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         cmdListino1.BackColor = Color.DodgerBlue
         cmdListino2.BackColor = Color.DodgerBlue
         cmdListino3.BackColor = Color.LightCoral
         cmdListino4.BackColor = Color.DodgerBlue

         NumListino = Listino.Tre

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

   Private Sub cmdListino4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdListino4.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         cmdListino1.BackColor = Color.DodgerBlue
         cmdListino2.BackColor = Color.DodgerBlue
         cmdListino3.BackColor = Color.DodgerBlue
         cmdListino4.BackColor = Color.LightCoral

         NumListino = Listino.Quattro

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

   Private Sub cmdPrenota_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrenota.Click
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

   Private Sub cmdEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEsci.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      Me.Close()
   End Sub

   Private Sub cmdApriTavolo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApriTavolo.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If SpostamentoInCorso() = True Then
         Exit Sub
      End If

      If ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = True Then
         cmdOccupa.PerformClick()

         If copertiAnnulla = False Then
            g_frmMain.ApriPos(Risorsa(tavoloSelezionato).Name, lblTavolo.Text, lblOraOcc.Text, lblCameriere.Text)
            Exit Sub
         Else
            copertiAnnulla = False
            Exit Sub
         End If
      End If

      g_frmMain.ApriPos(Risorsa(tavoloSelezionato).Name, lblTavolo.Text, lblOraOcc.Text, lblCameriere.Text)
   End Sub

   Private Sub cmdSposta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSposta.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If AbilitaPalmare = True Then
            Timer3.Enabled = False
         End If

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         If tavoloSelezionato = -1 Then
            Exit Sub
         End If

         If ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = True Then
            MessageBox.Show("Al tavolo selezionato non è assosciata alcuna ordinazione da poter spostare.", _
                            NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

         ElseIf ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_DEVE_ORDINARE, TAVOLO_DA_LIBERARE) = True Then
            MessageBox.Show("Al tavolo selezionato non è assosciata alcuna ordinazione da poter spostare.", _
                            NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub

         ElseIf ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_ATTESA_CONTO, TAVOLO_ATTESA_CONTO) = True Then
            MessageBox.Show("Al tavolo selezionato non è assosciata alcuna ordinazione da poter spostare.", _
                            NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
         End If

         If ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_DA_SERVIRE, TAVOLO_SERVITO) = True Then
            sender.BackColor = Color.Black

            Dim risposta As Integer
            risposta = MessageBox.Show("Selezionare il tavolo su cui riversare le comande del tavolo '" & lblTavolo.Text & "'.", _
                                       NOME_PRODOTTO, MessageBoxButtons.OKCancel, MessageBoxIcon.Information)

            If risposta = DialogResult.OK Then
               salaSel = salaSelezionata
               spostaTavoloId = Risorsa(tavoloSelezionato).Name
               spostaTavoloNum = Risorsa(tavoloSelezionato).Tag
               spostaTavoloColore = Risorsa(tavoloSelezionato).BackColor
            Else
               sender.BackColor = Color.DodgerBlue
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
         If AbilitaPalmare = True Then
            Timer3.Enabled = True
         End If

      End Try
   End Sub

   Private Sub cmdConto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdConto.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If SpostamentoInCorso() = True Then
         Exit Sub
      End If

      g_frmMain.ApriPos(0, "Tavoli", "", "")
   End Sub

   Private Sub cmdAsporto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAsporto.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If SpostamentoInCorso() = True Then
         Exit Sub
      End If

      g_frmMain.ApriPos(0, "Asporto", "", "")
   End Sub

   Private Sub cmdOccupa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOccupa.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If AbilitaPalmare = True Then
            Timer3.Enabled = False
         End If

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         If ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = True Then

            g_frmCoperti = New CopertiPOS
            If g_frmCoperti.ShowDialog = DialogResult.OK Then
               If tavoloSelezionato = -1 Then
                  Exit Sub
               End If

               NumTavoliOccupati += 1

               IndiceTavoloOccupato(NumTavoliOccupati - 1) = tavoloSelezionato

               OraOccupazione(NumTavoliOccupati - 1) = New DateTime(Today.Year, Today.Month, Today.Day, Today.Now.Hour, Today.Now.Minute, Today.Now.Second)

               Risorsa(tavoloSelezionato).BackColor = TAVOLO_DEVE_ORDINARE

               ModificaStatoTavolo(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name, _
                                   TAVOLO_DEVE_ORDINARE, _
                                   Convert.ToString(OraOccupazione(NumTavoliOccupati - 1)), _
                                   g_frmCoperti.Tag)

               AggiornaDisplay()

               g_frmCoperti.SalvaDatiClienti(Risorsa(tavoloSelezionato).Name)

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.OccupaTavolo, "(" & Risorsa(tavoloSelezionato).Text & ")", MODULO_TAVOLI)

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
         If AbilitaPalmare = True Then
            Timer3.Enabled = True
         End If

      End Try
   End Sub

   Private Sub cmdLibera_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLibera.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If AbilitaPalmare = True Then
            Timer3.Enabled = False
         End If

         If SpostamentoInCorso() = True Then
            Exit Sub
         End If

         If tavoloSelezionato = -1 Then
            Exit Sub
         End If

         If ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_LIBERO, TAVOLO_PRENOTATO) = False Then
            Dim risposta As DialogResult
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

               If ConfrontaColore(Risorsa(tavoloSelezionato).BackColor, TAVOLO_DA_LIBERARE, TAVOLO_DA_LIBERARE) = False Then
                  EliminaComandeTavolo(Risorsa(tavoloSelezionato).Name)
                  Risorsa(tavoloSelezionato).Text = Risorsa(tavoloSelezionato).Text.Remove(Risorsa(tavoloSelezionato).Text.Length - LUNGHEZZA_ORA_BREVE, LUNGHEZZA_ORA_BREVE)
               End If

               ' Elimina i dati del cliente del tavolo selezionato salvati nel conto.
               EliminaDatiClienteConto(TAB_CONTI_TAVOLI, Risorsa(tavoloSelezionato).Name)

               ModificaStatoTavolo(ANAG_TAVOLI, Risorsa(tavoloSelezionato).Name, TAVOLO_LIBERO, "", "")
               Risorsa(tavoloSelezionato).BackColor = TAVOLO_LIBERO
               AggiornaDisplay()

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.LiberaTavolo, "(" & Risorsa(tavoloSelezionato).Text & ")", MODULO_TAVOLI)

            End If
         Else
            MsgBox("Il tavolo selezionato è già disponibile.", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, NOME_PRODOTTO)
         End If


      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         If AbilitaPalmare = True Then
            Timer3.Enabled = True
         End If

      End Try
   End Sub

   Private Sub cmdUnisci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUnisci.Click
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

   Private Sub cmdSepara_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSepara.Click
      If SpostamentoInCorso() = True Then
         Exit Sub
      End If
   End Sub

   Private Sub cmdEsauriti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEsauriti.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      If SpostamentoInCorso() = True Then
         Exit Sub
      End If

      ApriPiattiEsauriti()
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

               If Risorsa(IndiceTavoloOccupato(i)).Text.Length > LUNGHEZZA_ORA Then
                  nome = Risorsa(IndiceTavoloOccupato(i)).Text.Remove(Risorsa(IndiceTavoloOccupato(i)).Text.Length - LUNGHEZZA_ORA, LUNGHEZZA_ORA)
               Else
                  nome = Risorsa(IndiceTavoloOccupato(i)).Text
               End If

               If ts.Hours.ToString.Length = 1 And ts.Minutes.ToString.Length = 1 Then
                  Risorsa(IndiceTavoloOccupato(i)).Text = nome & vbCrLf & "[" & "0" & ts.Hours.ToString & sepOra & "0" & ts.Minutes.ToString & "]"
               ElseIf ts.Hours.ToString.Length = 1 And ts.Minutes.ToString.Length > 1 Then
                  Risorsa(IndiceTavoloOccupato(i)).Text = nome & vbCrLf & "[" & "0" & ts.Hours.ToString & sepOra & ts.Minutes.ToString & "]"
               ElseIf ts.Hours.ToString.Length > 1 And ts.Minutes.ToString.Length = 1 Then
                  Risorsa(IndiceTavoloOccupato(i)).Text = nome & vbCrLf & "[" & ts.Hours.ToString & sepOra & "0" & ts.Minutes.ToString & "]"
               Else
                  Risorsa(IndiceTavoloOccupato(i)).Text = nome & vbCrLf & "[" & ts.Hours.ToString & sepOra & ts.Minutes.ToString & "]"
               End If
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
      LeggiFileComandi(AbilitaPalmare)

      ' Legge e scrive i dati.
      If modificatoStatoTavolo = True Then
         modificatoStatoTavolo = False
         g_frmMain.CreaFileStatoTavoli(AbilitaPalmare)
      End If

   End Sub

   Private Sub cmdDettagliGiù_Click(sender As System.Object, e As System.EventArgs) Handles cmdDettagliGiù.Click
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

   End Sub

   Private Sub cmdDettagliSu_Click(sender As System.Object, e As System.EventArgs) Handles cmdDettagliSu.Click
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
   End Sub
End Class
