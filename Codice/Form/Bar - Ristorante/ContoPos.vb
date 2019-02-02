Imports System.IO
Imports System.Data.OleDb
Imports System.Drawing.Printing

Public Class ContoPos
   Inherits System.Windows.Forms.Form

   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_AZIENDE As String = "Aziende"
   Const TAB_CONTI_TAVOLI As String = "ContiTavoli"
   Const TAB_DOC As String = "Documenti"
   Const TAB_DETTAGLI_DOC As String = "DettagliDoc"
   Const TAB_AZIENDA As String = "Azienda"
   Const TAB_BUONI_PASTO = "BuoniPasto"
   Const TAB_BUONI_PASTO_FATT = "BuoniPastoFatt"

   Const TIPO_DOC_RF As String = "Ricevuta Fiscale"
   Const TIPO_DOC_FF As String = "Fattura"
   Const TIPO_DOC_SF As String = "Scontrino"
   Const TIPO_DOC_PF As String = "Proforma"

   Const ALTEZZA_RIGA_DETTAGLI As Short = 22

   Private AContiTavoli As New ContiTavoli

   Public percorsoRep As String = PERCORSO_REP_RF
   Dim idCliente As String = ""
   Dim tipoDocumento As String = TIPO_DOC_RF

   Private Doc As New Documenti
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)

   Private DocSalvato As Boolean = False
   Private controlloAttivo As Control
   Private formatta As Boolean
   Private moltiplica As Boolean
   Private cCredito As Boolean
   Private contanti As Boolean
   Private tipoConto As Short
   Private idTavoloDoc As String
   Private nomeTavoloDoc As String
   Private nomeCameriereDoc As String
   Private totaleContoDaPagare As Double

   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0

   ' Per la moltiplicazione.
   Private op1 As Double
   Private op2 As Double
   Private valSconto As Double
   Private valServizio As Double

   Public Structure Conto
      Public NomeConto As String
      Public Quantità As String
      Public Descrizione As String
      Public Importo As String
      Public Prezzo As String
      Public IdPiatto As String
   End Structure

   Public DatiConto() As Conto
   Public qtàPiatti As Integer

   Public selezioneContoAperto As Boolean
   Public stampaDocInCorso As Boolean

   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Public WithEvents txtCoperto As System.Windows.Forms.TextBox
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Public WithEvents txtQuotaPersona As System.Windows.Forms.TextBox
   Public WithEvents txtTotDividere As System.Windows.Forms.TextBox
   Friend WithEvents lblQuotaPersona As System.Windows.Forms.Label
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents cmdTipoConto As System.Windows.Forms.Button
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents lstvElencoDocAperti As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents cmdTipoElenco As System.Windows.Forms.Button
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents cmdAddebitoHotel As System.Windows.Forms.Button
   Friend WithEvents cmdCliente As System.Windows.Forms.Button
   Friend WithEvents cmdDocApertiSu As System.Windows.Forms.Button
   Friend WithEvents cmdDocApertiGiù As System.Windows.Forms.Button
   Friend WithEvents cmdDivisioneAnalitica As System.Windows.Forms.Button
   Public WithEvents txtNumDoc As System.Windows.Forms.TextBox
   Friend WithEvents ColumnHeader21 As System.Windows.Forms.ColumnHeader
   Friend WithEvents lstvDettagliTemp As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader22 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader23 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader24 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader25 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader26 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader27 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader28 As System.Windows.Forms.ColumnHeader
   Friend WithEvents lstvDettagliCompatto As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader29 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader30 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader31 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader32 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader33 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader34 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader35 As System.Windows.Forms.ColumnHeader
   Friend WithEvents lstvDettagliCopia As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader36 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader37 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader38 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader39 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader40 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader41 As System.Windows.Forms.ColumnHeader
   Public WithEvents txtIdAzienda As System.Windows.Forms.TextBox
   Public WithEvents txtIdCliente As System.Windows.Forms.TextBox
   Public WithEvents Label19 As System.Windows.Forms.Label
   Public WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents cmdTastiera As System.Windows.Forms.Button
   Friend WithEvents ColumnHeader42 As System.Windows.Forms.ColumnHeader

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal val As Short, ByVal idTavolo As Integer, ByVal tavolo As String, ByVal cameriere As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()
      tipoConto = val
      nomeTavoloDoc = tavolo
      nomeCameriereDoc = cameriere

      If IsNothing(idTavolo) = False And idTavolo <> 0 Then
         idTavoloDoc = idTavolo
      Else
         idTavoloDoc = String.Empty
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
   Public WithEvents txtProv As System.Windows.Forms.TextBox
   Public WithEvents txtCap As System.Windows.Forms.TextBox
   Public WithEvents txtCittà As System.Windows.Forms.TextBox
   Public WithEvents Label5 As System.Windows.Forms.Label
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents txtPIva As System.Windows.Forms.TextBox
   Public WithEvents Label31 As System.Windows.Forms.Label
   Friend WithEvents cmdRicevuta As System.Windows.Forms.Button
   Friend WithEvents cmdFattura As System.Windows.Forms.Button
   Friend WithEvents cmdEsci As System.Windows.Forms.Button
   Public WithEvents txtIndirizzo As System.Windows.Forms.TextBox
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents cmdProforma As System.Windows.Forms.Button
   Friend WithEvents cmdScontrino As System.Windows.Forms.Button
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents cmdOk As System.Windows.Forms.Button
   Friend WithEvents cmdNum8 As System.Windows.Forms.Button
   Friend WithEvents cmdNum9 As System.Windows.Forms.Button
   Friend WithEvents cmdNum0 As System.Windows.Forms.Button
   Friend WithEvents cmdNum7 As System.Windows.Forms.Button
   Friend WithEvents cmdNum6 As System.Windows.Forms.Button
   Friend WithEvents cmdNum5 As System.Windows.Forms.Button
   Friend WithEvents cmdNum4 As System.Windows.Forms.Button
   Friend WithEvents cmdNum3 As System.Windows.Forms.Button
   Friend WithEvents cmdNum2 As System.Windows.Forms.Button
   Friend WithEvents cmdNum1 As System.Windows.Forms.Button
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents cmdDettagliSu As System.Windows.Forms.Button
   Friend WithEvents cmdDettagliGiù As System.Windows.Forms.Button
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents cmdTipoPagamento As System.Windows.Forms.Button
   Friend WithEvents cmdContanti As System.Windows.Forms.Button
   Public WithEvents txtContanti As System.Windows.Forms.TextBox
   Public WithEvents txtCartaCredito As System.Windows.Forms.TextBox
   Public WithEvents txtTotaleConto As System.Windows.Forms.TextBox
   Public WithEvents txtValSconto As System.Windows.Forms.TextBox
   Public WithEvents txtServizio As System.Windows.Forms.TextBox
   Public WithEvents txtSospeso As System.Windows.Forms.TextBox
   Public WithEvents txtResto As System.Windows.Forms.TextBox
   Friend WithEvents cmdVirgola As System.Windows.Forms.Button
   Friend WithEvents cmdPercentuale As System.Windows.Forms.Button
   Friend WithEvents cmdX As System.Windows.Forms.Button
   Friend WithEvents cmdC As System.Windows.Forms.Button
   Friend WithEvents cmdNum00 As System.Windows.Forms.Button
   Friend WithEvents cmdCancella As System.Windows.Forms.Button
   Public WithEvents txtIva As System.Windows.Forms.TextBox
   Public WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Public WithEvents txtDaPagare As System.Windows.Forms.TextBox
   Public WithEvents txtBuoni As System.Windows.Forms.TextBox
   Friend WithEvents cmdBuoni As System.Windows.Forms.Button
   Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader11 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader12 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader13 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader14 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader15 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader16 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader17 As System.Windows.Forms.ColumnHeader
   Friend WithEvents lstvDatiBuoni As System.Windows.Forms.ListView
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ContoPos))
      Dim ListViewItem1 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"0", "Aperto", "25,00"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.LightSalmon, Nothing)
      Dim ListViewItem2 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New String() {"", "Aperto", "25,00"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.LightSalmon, Nothing)
      Me.cmdRicevuta = New System.Windows.Forms.Button()
      Me.cmdFattura = New System.Windows.Forms.Button()
      Me.cmdEsci = New System.Windows.Forms.Button()
      Me.txtProv = New System.Windows.Forms.TextBox()
      Me.txtCap = New System.Windows.Forms.TextBox()
      Me.txtCittà = New System.Windows.Forms.TextBox()
      Me.txtIndirizzo = New System.Windows.Forms.TextBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.txtPIva = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.cmdProforma = New System.Windows.Forms.Button()
      Me.cmdScontrino = New System.Windows.Forms.Button()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.cmdContanti = New System.Windows.Forms.Button()
      Me.cmdTipoPagamento = New System.Windows.Forms.Button()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.txtTotaleConto = New System.Windows.Forms.TextBox()
      Me.txtValSconto = New System.Windows.Forms.TextBox()
      Me.txtServizio = New System.Windows.Forms.TextBox()
      Me.txtContanti = New System.Windows.Forms.TextBox()
      Me.txtCartaCredito = New System.Windows.Forms.TextBox()
      Me.txtSospeso = New System.Windows.Forms.TextBox()
      Me.txtResto = New System.Windows.Forms.TextBox()
      Me.cmdOk = New System.Windows.Forms.Button()
      Me.cmdNum8 = New System.Windows.Forms.Button()
      Me.cmdNum9 = New System.Windows.Forms.Button()
      Me.cmdNum0 = New System.Windows.Forms.Button()
      Me.cmdNum7 = New System.Windows.Forms.Button()
      Me.cmdNum6 = New System.Windows.Forms.Button()
      Me.cmdNum5 = New System.Windows.Forms.Button()
      Me.cmdNum4 = New System.Windows.Forms.Button()
      Me.cmdNum3 = New System.Windows.Forms.Button()
      Me.cmdNum2 = New System.Windows.Forms.Button()
      Me.cmdNum1 = New System.Windows.Forms.Button()
      Me.cmdVirgola = New System.Windows.Forms.Button()
      Me.cmdPercentuale = New System.Windows.Forms.Button()
      Me.cmdX = New System.Windows.Forms.Button()
      Me.cmdC = New System.Windows.Forms.Button()
      Me.cmdNum00 = New System.Windows.Forms.Button()
      Me.lstvDettagli = New System.Windows.Forms.ListView()
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Label10 = New System.Windows.Forms.Label()
      Me.cmdDettagliSu = New System.Windows.Forms.Button()
      Me.cmdDettagliGiù = New System.Windows.Forms.Button()
      Me.cmdCancella = New System.Windows.Forms.Button()
      Me.txtIva = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.txtDaPagare = New System.Windows.Forms.TextBox()
      Me.txtBuoni = New System.Windows.Forms.TextBox()
      Me.cmdBuoni = New System.Windows.Forms.Button()
      Me.lstvDatiBuoni = New System.Windows.Forms.ListView()
      Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader11 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader12 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader13 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader14 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader15 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader16 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader17 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.txtCoperto = New System.Windows.Forms.TextBox()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.cmdTipoConto = New System.Windows.Forms.Button()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.lblQuotaPersona = New System.Windows.Forms.Label()
      Me.txtTotDividere = New System.Windows.Forms.TextBox()
      Me.txtQuotaPersona = New System.Windows.Forms.TextBox()
      Me.lstvElencoDocAperti = New System.Windows.Forms.ListView()
      Me.ColumnHeader18 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader19 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader20 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader21 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.Label17 = New System.Windows.Forms.Label()
      Me.cmdTipoElenco = New System.Windows.Forms.Button()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.cmdAddebitoHotel = New System.Windows.Forms.Button()
      Me.cmdCliente = New System.Windows.Forms.Button()
      Me.cmdDocApertiSu = New System.Windows.Forms.Button()
      Me.cmdDocApertiGiù = New System.Windows.Forms.Button()
      Me.cmdDivisioneAnalitica = New System.Windows.Forms.Button()
      Me.txtNumDoc = New System.Windows.Forms.TextBox()
      Me.lstvDettagliTemp = New System.Windows.Forms.ListView()
      Me.ColumnHeader22 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader23 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader24 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader25 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader26 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader27 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader28 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.lstvDettagliCompatto = New System.Windows.Forms.ListView()
      Me.ColumnHeader29 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader30 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader31 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader32 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader33 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader34 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader35 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.lstvDettagliCopia = New System.Windows.Forms.ListView()
      Me.ColumnHeader36 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader37 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader38 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader39 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader40 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader41 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader42 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.txtIdCliente = New System.Windows.Forms.TextBox()
      Me.txtIdAzienda = New System.Windows.Forms.TextBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.cmdTastiera = New System.Windows.Forms.Button()
      Me.SuspendLayout()
      '
      'cmdRicevuta
      '
      Me.cmdRicevuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdRicevuta.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdRicevuta.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdRicevuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdRicevuta.ForeColor = System.Drawing.Color.White
      Me.cmdRicevuta.Location = New System.Drawing.Point(888, 280)
      Me.cmdRicevuta.Name = "cmdRicevuta"
      Me.cmdRicevuta.Size = New System.Drawing.Size(184, 72)
      Me.cmdRicevuta.TabIndex = 38
      Me.cmdRicevuta.Text = "&RICEVUTA FISCALE"
      Me.cmdRicevuta.UseVisualStyleBackColor = False
      '
      'cmdFattura
      '
      Me.cmdFattura.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdFattura.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdFattura.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdFattura.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdFattura.ForeColor = System.Drawing.Color.White
      Me.cmdFattura.Location = New System.Drawing.Point(888, 360)
      Me.cmdFattura.Name = "cmdFattura"
      Me.cmdFattura.Size = New System.Drawing.Size(184, 72)
      Me.cmdFattura.TabIndex = 39
      Me.cmdFattura.Text = "&FATTURA"
      Me.cmdFattura.UseVisualStyleBackColor = False
      '
      'cmdEsci
      '
      Me.cmdEsci.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdEsci.BackColor = System.Drawing.Color.LightCoral
      Me.cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdEsci.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdEsci.ForeColor = System.Drawing.Color.White
      Me.cmdEsci.Location = New System.Drawing.Point(888, 680)
      Me.cmdEsci.Name = "cmdEsci"
      Me.cmdEsci.Size = New System.Drawing.Size(184, 56)
      Me.cmdEsci.TabIndex = 43
      Me.cmdEsci.Text = "&ESCI"
      Me.cmdEsci.UseVisualStyleBackColor = False
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(1504, 72)
      Me.txtProv.MaxLength = 2
      Me.txtProv.Name = "txtProv"
      Me.txtProv.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtProv.Size = New System.Drawing.Size(32, 29)
      Me.txtProv.TabIndex = 4
      Me.txtProv.Visible = False
      '
      'txtCap
      '
      Me.txtCap.AcceptsReturn = True
      Me.txtCap.BackColor = System.Drawing.SystemColors.Window
      Me.txtCap.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCap.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCap.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCap.Location = New System.Drawing.Point(1248, 72)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(64, 29)
      Me.txtCap.TabIndex = 2
      Me.txtCap.Visible = False
      '
      'txtCittà
      '
      Me.txtCittà.AcceptsReturn = True
      Me.txtCittà.BackColor = System.Drawing.SystemColors.Window
      Me.txtCittà.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCittà.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCittà.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCittà.Location = New System.Drawing.Point(1320, 72)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(176, 29)
      Me.txtCittà.TabIndex = 3
      Me.txtCittà.Visible = False
      '
      'txtIndirizzo
      '
      Me.txtIndirizzo.AcceptsReturn = True
      Me.txtIndirizzo.BackColor = System.Drawing.SystemColors.Window
      Me.txtIndirizzo.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIndirizzo.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIndirizzo.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIndirizzo.Location = New System.Drawing.Point(1248, 32)
      Me.txtIndirizzo.MaxLength = 100
      Me.txtIndirizzo.Name = "txtIndirizzo"
      Me.txtIndirizzo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo.Size = New System.Drawing.Size(288, 29)
      Me.txtIndirizzo.TabIndex = 1
      Me.txtIndirizzo.Visible = False
      '
      'Label5
      '
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(1096, 80)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(144, 24)
      Me.Label5.TabIndex = 179
      Me.Label5.Text = "CAP/CITTA'/PROV.:"
      Me.Label5.Visible = False
      '
      'Label4
      '
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(1096, 40)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(144, 24)
      Me.Label4.TabIndex = 178
      Me.Label4.Text = "INDIRIZZO:"
      Me.Label4.Visible = False
      '
      'Label3
      '
      Me.Label3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(632, 16)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(88, 24)
      Me.Label3.TabIndex = 177
      Me.Label3.Text = "CLIENTE:"
      '
      'txtPIva
      '
      Me.txtPIva.AcceptsReturn = True
      Me.txtPIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtPIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtPIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtPIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtPIva.Location = New System.Drawing.Point(1248, 112)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(144, 29)
      Me.txtPIva.TabIndex = 5
      Me.txtPIva.Visible = False
      '
      'Label31
      '
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(1096, 120)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(144, 24)
      Me.Label31.TabIndex = 184
      Me.Label31.Text = "PARTIVA IVA:"
      Me.Label31.Visible = False
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "RFiscale.rpt"
      '
      'cmdProforma
      '
      Me.cmdProforma.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdProforma.BackColor = System.Drawing.Color.Silver
      Me.cmdProforma.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdProforma.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdProforma.ForeColor = System.Drawing.Color.White
      Me.cmdProforma.Location = New System.Drawing.Point(888, 440)
      Me.cmdProforma.Name = "cmdProforma"
      Me.cmdProforma.Size = New System.Drawing.Size(184, 72)
      Me.cmdProforma.TabIndex = 40
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
      Me.cmdScontrino.Location = New System.Drawing.Point(888, 520)
      Me.cmdScontrino.Name = "cmdScontrino"
      Me.cmdScontrino.Size = New System.Drawing.Size(184, 72)
      Me.cmdScontrino.TabIndex = 41
      Me.cmdScontrino.Text = "&SCONTRINO"
      Me.cmdScontrino.UseVisualStyleBackColor = False
      '
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(632, 88)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(144, 16)
      Me.Label1.TabIndex = 188
      Me.Label1.Text = "TOTALE CONTO:"
      '
      'Label2
      '
      Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(632, 128)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(152, 18)
      Me.Label2.TabIndex = 189
      Me.Label2.Text = "SCONTO:"
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(632, 208)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(144, 40)
      Me.Label6.TabIndex = 190
      Me.Label6.Text = "TOT. DA PAGARE:"
      '
      'cmdContanti
      '
      Me.cmdContanti.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdContanti.BackColor = System.Drawing.Color.White
      Me.cmdContanti.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdContanti.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdContanti.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdContanti.Location = New System.Drawing.Point(632, 280)
      Me.cmdContanti.Name = "cmdContanti"
      Me.cmdContanti.Size = New System.Drawing.Size(144, 32)
      Me.cmdContanti.TabIndex = 13
      Me.cmdContanti.Text = "CONTANTI"
      Me.cmdContanti.UseVisualStyleBackColor = False
      '
      'cmdTipoPagamento
      '
      Me.cmdTipoPagamento.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdTipoPagamento.BackColor = System.Drawing.Color.White
      Me.cmdTipoPagamento.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdTipoPagamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdTipoPagamento.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdTipoPagamento.Location = New System.Drawing.Point(632, 320)
      Me.cmdTipoPagamento.Name = "cmdTipoPagamento"
      Me.cmdTipoPagamento.Size = New System.Drawing.Size(144, 32)
      Me.cmdTipoPagamento.TabIndex = 15
      Me.cmdTipoPagamento.Text = "C. CREDITO"
      Me.cmdTipoPagamento.UseVisualStyleBackColor = False
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(632, 448)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(144, 16)
      Me.Label7.TabIndex = 193
      Me.Label7.Text = "RESTO:"
      '
      'Label9
      '
      Me.Label9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(632, 168)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(144, 16)
      Me.Label9.TabIndex = 195
      Me.Label9.Text = "SERVIZIO:"
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(632, 408)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(144, 16)
      Me.Label8.TabIndex = 196
      Me.Label8.Text = "SOSPESO:"
      '
      'txtTotaleConto
      '
      Me.txtTotaleConto.AcceptsReturn = True
      Me.txtTotaleConto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotaleConto.BackColor = System.Drawing.Color.LightSalmon
      Me.txtTotaleConto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleConto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTotaleConto.Location = New System.Drawing.Point(784, 80)
      Me.txtTotaleConto.MaxLength = 100
      Me.txtTotaleConto.Name = "txtTotaleConto"
      Me.txtTotaleConto.ReadOnly = True
      Me.txtTotaleConto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleConto.Size = New System.Drawing.Size(96, 29)
      Me.txtTotaleConto.TabIndex = 7
      Me.txtTotaleConto.TabStop = False
      Me.txtTotaleConto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtValSconto
      '
      Me.txtValSconto.AcceptsReturn = True
      Me.txtValSconto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtValSconto.BackColor = System.Drawing.SystemColors.Window
      Me.txtValSconto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtValSconto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtValSconto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtValSconto.Location = New System.Drawing.Point(784, 120)
      Me.txtValSconto.MaxLength = 100
      Me.txtValSconto.Name = "txtValSconto"
      Me.txtValSconto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtValSconto.Size = New System.Drawing.Size(96, 29)
      Me.txtValSconto.TabIndex = 9
      Me.txtValSconto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtServizio
      '
      Me.txtServizio.AcceptsReturn = True
      Me.txtServizio.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtServizio.BackColor = System.Drawing.SystemColors.Window
      Me.txtServizio.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtServizio.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtServizio.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtServizio.Location = New System.Drawing.Point(784, 160)
      Me.txtServizio.MaxLength = 100
      Me.txtServizio.Name = "txtServizio"
      Me.txtServizio.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtServizio.Size = New System.Drawing.Size(96, 29)
      Me.txtServizio.TabIndex = 10
      Me.txtServizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtContanti
      '
      Me.txtContanti.AcceptsReturn = True
      Me.txtContanti.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtContanti.BackColor = System.Drawing.SystemColors.Window
      Me.txtContanti.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtContanti.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtContanti.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtContanti.Location = New System.Drawing.Point(784, 280)
      Me.txtContanti.MaxLength = 100
      Me.txtContanti.Name = "txtContanti"
      Me.txtContanti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtContanti.Size = New System.Drawing.Size(96, 29)
      Me.txtContanti.TabIndex = 12
      Me.txtContanti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCartaCredito
      '
      Me.txtCartaCredito.AcceptsReturn = True
      Me.txtCartaCredito.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCartaCredito.BackColor = System.Drawing.Color.White
      Me.txtCartaCredito.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCartaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCartaCredito.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCartaCredito.Location = New System.Drawing.Point(784, 320)
      Me.txtCartaCredito.MaxLength = 100
      Me.txtCartaCredito.Name = "txtCartaCredito"
      Me.txtCartaCredito.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCartaCredito.Size = New System.Drawing.Size(96, 29)
      Me.txtCartaCredito.TabIndex = 14
      Me.txtCartaCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtSospeso
      '
      Me.txtSospeso.AcceptsReturn = True
      Me.txtSospeso.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSospeso.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtSospeso.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtSospeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSospeso.ForeColor = System.Drawing.Color.Red
      Me.txtSospeso.Location = New System.Drawing.Point(784, 400)
      Me.txtSospeso.MaxLength = 100
      Me.txtSospeso.Name = "txtSospeso"
      Me.txtSospeso.ReadOnly = True
      Me.txtSospeso.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSospeso.Size = New System.Drawing.Size(96, 29)
      Me.txtSospeso.TabIndex = 18
      Me.txtSospeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtResto
      '
      Me.txtResto.AcceptsReturn = True
      Me.txtResto.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtResto.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtResto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtResto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtResto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtResto.Location = New System.Drawing.Point(784, 440)
      Me.txtResto.MaxLength = 100
      Me.txtResto.Name = "txtResto"
      Me.txtResto.ReadOnly = True
      Me.txtResto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtResto.Size = New System.Drawing.Size(96, 29)
      Me.txtResto.TabIndex = 19
      Me.txtResto.TabStop = False
      Me.txtResto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmdOk
      '
      Me.cmdOk.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdOk.BackColor = System.Drawing.Color.MediumSeaGreen
      Me.cmdOk.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdOk.ForeColor = System.Drawing.Color.White
      Me.cmdOk.Location = New System.Drawing.Point(632, 648)
      Me.cmdOk.Name = "cmdOk"
      Me.cmdOk.Size = New System.Drawing.Size(56, 40)
      Me.cmdOk.TabIndex = 32
      Me.cmdOk.Text = "OK"
      Me.cmdOk.UseVisualStyleBackColor = False
      '
      'cmdNum8
      '
      Me.cmdNum8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum8.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum8.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum8.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum8.ForeColor = System.Drawing.Color.White
      Me.cmdNum8.Location = New System.Drawing.Point(760, 504)
      Me.cmdNum8.Name = "cmdNum8"
      Me.cmdNum8.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum8.TabIndex = 22
      Me.cmdNum8.Text = "8"
      Me.cmdNum8.UseVisualStyleBackColor = False
      '
      'cmdNum9
      '
      Me.cmdNum9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum9.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum9.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum9.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum9.ForeColor = System.Drawing.Color.White
      Me.cmdNum9.Location = New System.Drawing.Point(824, 504)
      Me.cmdNum9.Name = "cmdNum9"
      Me.cmdNum9.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum9.TabIndex = 23
      Me.cmdNum9.Text = "9"
      Me.cmdNum9.UseVisualStyleBackColor = False
      '
      'cmdNum0
      '
      Me.cmdNum0.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum0.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum0.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum0.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum0.ForeColor = System.Drawing.Color.White
      Me.cmdNum0.Location = New System.Drawing.Point(760, 648)
      Me.cmdNum0.Name = "cmdNum0"
      Me.cmdNum0.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum0.TabIndex = 34
      Me.cmdNum0.Text = "0"
      Me.cmdNum0.UseVisualStyleBackColor = False
      '
      'cmdNum7
      '
      Me.cmdNum7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum7.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum7.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum7.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum7.ForeColor = System.Drawing.Color.White
      Me.cmdNum7.Location = New System.Drawing.Point(696, 504)
      Me.cmdNum7.Name = "cmdNum7"
      Me.cmdNum7.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum7.TabIndex = 21
      Me.cmdNum7.Text = "7"
      Me.cmdNum7.UseVisualStyleBackColor = False
      '
      'cmdNum6
      '
      Me.cmdNum6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum6.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum6.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum6.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum6.ForeColor = System.Drawing.Color.White
      Me.cmdNum6.Location = New System.Drawing.Point(824, 552)
      Me.cmdNum6.Name = "cmdNum6"
      Me.cmdNum6.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum6.TabIndex = 27
      Me.cmdNum6.Text = "6"
      Me.cmdNum6.UseVisualStyleBackColor = False
      '
      'cmdNum5
      '
      Me.cmdNum5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum5.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum5.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum5.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum5.ForeColor = System.Drawing.Color.White
      Me.cmdNum5.Location = New System.Drawing.Point(760, 552)
      Me.cmdNum5.Name = "cmdNum5"
      Me.cmdNum5.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum5.TabIndex = 26
      Me.cmdNum5.Text = "5"
      Me.cmdNum5.UseVisualStyleBackColor = False
      '
      'cmdNum4
      '
      Me.cmdNum4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum4.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum4.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum4.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum4.ForeColor = System.Drawing.Color.White
      Me.cmdNum4.Location = New System.Drawing.Point(696, 552)
      Me.cmdNum4.Name = "cmdNum4"
      Me.cmdNum4.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum4.TabIndex = 25
      Me.cmdNum4.Text = "4"
      Me.cmdNum4.UseVisualStyleBackColor = False
      '
      'cmdNum3
      '
      Me.cmdNum3.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum3.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum3.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum3.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum3.ForeColor = System.Drawing.Color.White
      Me.cmdNum3.Location = New System.Drawing.Point(824, 600)
      Me.cmdNum3.Name = "cmdNum3"
      Me.cmdNum3.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum3.TabIndex = 31
      Me.cmdNum3.Text = "3"
      Me.cmdNum3.UseVisualStyleBackColor = False
      '
      'cmdNum2
      '
      Me.cmdNum2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum2.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum2.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum2.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum2.ForeColor = System.Drawing.Color.White
      Me.cmdNum2.Location = New System.Drawing.Point(760, 600)
      Me.cmdNum2.Name = "cmdNum2"
      Me.cmdNum2.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum2.TabIndex = 30
      Me.cmdNum2.Text = "2"
      Me.cmdNum2.UseVisualStyleBackColor = False
      '
      'cmdNum1
      '
      Me.cmdNum1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum1.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum1.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum1.ForeColor = System.Drawing.Color.White
      Me.cmdNum1.Location = New System.Drawing.Point(696, 600)
      Me.cmdNum1.Name = "cmdNum1"
      Me.cmdNum1.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum1.TabIndex = 29
      Me.cmdNum1.Text = "1"
      Me.cmdNum1.UseVisualStyleBackColor = False
      '
      'cmdVirgola
      '
      Me.cmdVirgola.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdVirgola.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdVirgola.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdVirgola.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdVirgola.ForeColor = System.Drawing.Color.White
      Me.cmdVirgola.Location = New System.Drawing.Point(696, 648)
      Me.cmdVirgola.Name = "cmdVirgola"
      Me.cmdVirgola.Size = New System.Drawing.Size(56, 40)
      Me.cmdVirgola.TabIndex = 33
      Me.cmdVirgola.Text = ","
      Me.cmdVirgola.UseVisualStyleBackColor = False
      '
      'cmdPercentuale
      '
      Me.cmdPercentuale.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdPercentuale.BackColor = System.Drawing.Color.LightSalmon
      Me.cmdPercentuale.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdPercentuale.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPercentuale.ForeColor = System.Drawing.Color.White
      Me.cmdPercentuale.Location = New System.Drawing.Point(632, 600)
      Me.cmdPercentuale.Name = "cmdPercentuale"
      Me.cmdPercentuale.Size = New System.Drawing.Size(56, 40)
      Me.cmdPercentuale.TabIndex = 28
      Me.cmdPercentuale.Text = "%"
      Me.cmdPercentuale.UseVisualStyleBackColor = False
      '
      'cmdX
      '
      Me.cmdX.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdX.BackColor = System.Drawing.Color.LightSalmon
      Me.cmdX.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdX.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdX.ForeColor = System.Drawing.Color.White
      Me.cmdX.Location = New System.Drawing.Point(632, 552)
      Me.cmdX.Name = "cmdX"
      Me.cmdX.Size = New System.Drawing.Size(56, 40)
      Me.cmdX.TabIndex = 24
      Me.cmdX.Text = "X"
      Me.cmdX.UseVisualStyleBackColor = False
      '
      'cmdC
      '
      Me.cmdC.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdC.BackColor = System.Drawing.Color.LightCoral
      Me.cmdC.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdC.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdC.ForeColor = System.Drawing.Color.White
      Me.cmdC.Location = New System.Drawing.Point(632, 504)
      Me.cmdC.Name = "cmdC"
      Me.cmdC.Size = New System.Drawing.Size(56, 40)
      Me.cmdC.TabIndex = 20
      Me.cmdC.Text = "C"
      Me.cmdC.UseVisualStyleBackColor = False
      '
      'cmdNum00
      '
      Me.cmdNum00.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdNum00.BackColor = System.Drawing.Color.DodgerBlue
      Me.cmdNum00.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdNum00.Font = New System.Drawing.Font("Microsoft Sans Serif", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdNum00.ForeColor = System.Drawing.Color.White
      Me.cmdNum00.Location = New System.Drawing.Point(824, 648)
      Me.cmdNum00.Name = "cmdNum00"
      Me.cmdNum00.Size = New System.Drawing.Size(56, 40)
      Me.cmdNum00.TabIndex = 35
      Me.cmdNum00.Text = "00"
      Me.cmdNum00.UseVisualStyleBackColor = False
      '
      'lstvDettagli
      '
      Me.lstvDettagli.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagli.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7})
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagli.Location = New System.Drawing.Point(306, 119)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(312, 569)
      Me.lstvDettagli.TabIndex = 46
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
      'Label10
      '
      Me.Label10.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Label10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(306, 80)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(312, 40)
      Me.Label10.TabIndex = 226
      Me.Label10.Text = "Q.tà   Descrizione                               Totale"
      Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'cmdDettagliSu
      '
      Me.cmdDettagliSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliSu.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliSu.Image = CType(resources.GetObject("cmdDettagliSu.Image"), System.Drawing.Image)
      Me.cmdDettagliSu.Location = New System.Drawing.Point(466, 696)
      Me.cmdDettagliSu.Name = "cmdDettagliSu"
      Me.cmdDettagliSu.Size = New System.Drawing.Size(152, 40)
      Me.cmdDettagliSu.TabIndex = 45
      Me.cmdDettagliSu.UseVisualStyleBackColor = False
      '
      'cmdDettagliGiù
      '
      Me.cmdDettagliGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdDettagliGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdDettagliGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDettagliGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDettagliGiù.Image = CType(resources.GetObject("cmdDettagliGiù.Image"), System.Drawing.Image)
      Me.cmdDettagliGiù.Location = New System.Drawing.Point(306, 696)
      Me.cmdDettagliGiù.Name = "cmdDettagliGiù"
      Me.cmdDettagliGiù.Size = New System.Drawing.Size(152, 40)
      Me.cmdDettagliGiù.TabIndex = 44
      Me.cmdDettagliGiù.UseVisualStyleBackColor = False
      '
      'cmdCancella
      '
      Me.cmdCancella.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCancella.BackColor = System.Drawing.Color.Gray
      Me.cmdCancella.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCancella.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCancella.ForeColor = System.Drawing.Color.White
      Me.cmdCancella.Location = New System.Drawing.Point(696, 696)
      Me.cmdCancella.Name = "cmdCancella"
      Me.cmdCancella.Size = New System.Drawing.Size(184, 40)
      Me.cmdCancella.TabIndex = 42
      Me.cmdCancella.Text = "&CANCELLA"
      Me.cmdCancella.UseVisualStyleBackColor = False
      '
      'txtIva
      '
      Me.txtIva.AcceptsReturn = True
      Me.txtIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIva.Location = New System.Drawing.Point(1456, 112)
      Me.txtIva.MaxLength = 10
      Me.txtIva.Name = "txtIva"
      Me.txtIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIva.Size = New System.Drawing.Size(80, 29)
      Me.txtIva.TabIndex = 6
      Me.txtIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtIva.Visible = False
      '
      'Label11
      '
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(1400, 120)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(56, 24)
      Me.Label11.TabIndex = 229
      Me.Label11.Text = "% IVA:"
      Me.Label11.TextAlign = System.Drawing.ContentAlignment.TopRight
      Me.Label11.Visible = False
      '
      'Timer1
      '
      Me.Timer1.Enabled = True
      Me.Timer1.Interval = 1000
      '
      'dtpData
      '
      Me.dtpData.Location = New System.Drawing.Point(-600, 680)
      Me.dtpData.Name = "dtpData"
      Me.dtpData.Size = New System.Drawing.Size(258, 29)
      Me.dtpData.TabIndex = 230
      '
      'txtDaPagare
      '
      Me.txtDaPagare.AcceptsReturn = True
      Me.txtDaPagare.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDaPagare.BackColor = System.Drawing.Color.LightSalmon
      Me.txtDaPagare.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtDaPagare.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtDaPagare.ForeColor = System.Drawing.Color.Black
      Me.txtDaPagare.Location = New System.Drawing.Point(784, 200)
      Me.txtDaPagare.MaxLength = 100
      Me.txtDaPagare.Name = "txtDaPagare"
      Me.txtDaPagare.ReadOnly = True
      Me.txtDaPagare.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtDaPagare.Size = New System.Drawing.Size(288, 62)
      Me.txtDaPagare.TabIndex = 11
      Me.txtDaPagare.TabStop = False
      Me.txtDaPagare.Text = "25,50"
      Me.txtDaPagare.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtBuoni
      '
      Me.txtBuoni.AcceptsReturn = True
      Me.txtBuoni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBuoni.BackColor = System.Drawing.SystemColors.Control
      Me.txtBuoni.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtBuoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBuoni.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtBuoni.Location = New System.Drawing.Point(784, 360)
      Me.txtBuoni.MaxLength = 100
      Me.txtBuoni.Name = "txtBuoni"
      Me.txtBuoni.ReadOnly = True
      Me.txtBuoni.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtBuoni.Size = New System.Drawing.Size(96, 29)
      Me.txtBuoni.TabIndex = 16
      Me.txtBuoni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmdBuoni
      '
      Me.cmdBuoni.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdBuoni.BackColor = System.Drawing.Color.White
      Me.cmdBuoni.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdBuoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdBuoni.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdBuoni.Location = New System.Drawing.Point(632, 360)
      Me.cmdBuoni.Name = "cmdBuoni"
      Me.cmdBuoni.Size = New System.Drawing.Size(144, 32)
      Me.cmdBuoni.TabIndex = 17
      Me.cmdBuoni.Text = "BUONI P."
      Me.cmdBuoni.UseVisualStyleBackColor = False
      '
      'lstvDatiBuoni
      '
      Me.lstvDatiBuoni.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lstvDatiBuoni.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvDatiBuoni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDatiBuoni.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17})
      Me.lstvDatiBuoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDatiBuoni.ForeColor = System.Drawing.Color.Black
      Me.lstvDatiBuoni.FullRowSelect = True
      Me.lstvDatiBuoni.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDatiBuoni.Location = New System.Drawing.Point(312, 640)
      Me.lstvDatiBuoni.MultiSelect = False
      Me.lstvDatiBuoni.Name = "lstvDatiBuoni"
      Me.lstvDatiBuoni.Size = New System.Drawing.Size(296, 40)
      Me.lstvDatiBuoni.TabIndex = 231
      Me.lstvDatiBuoni.UseCompatibleStateImageBehavior = False
      Me.lstvDatiBuoni.View = System.Windows.Forms.View.Details
      Me.lstvDatiBuoni.Visible = False
      '
      'ColumnHeader8
      '
      Me.ColumnHeader8.Width = 0
      '
      'ColumnHeader9
      '
      Me.ColumnHeader9.Text = "Quantità"
      Me.ColumnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader9.Width = 0
      '
      'ColumnHeader10
      '
      Me.ColumnHeader10.Text = "Descrizione"
      Me.ColumnHeader10.Width = 0
      '
      'ColumnHeader11
      '
      Me.ColumnHeader11.Text = "Valore"
      Me.ColumnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader11.Width = 0
      '
      'ColumnHeader12
      '
      Me.ColumnHeader12.Text = "IdBuono"
      Me.ColumnHeader12.Width = 0
      '
      'ColumnHeader13
      '
      Me.ColumnHeader13.Text = "IdAzienda"
      Me.ColumnHeader13.Width = 0
      '
      'ColumnHeader14
      '
      Me.ColumnHeader14.Text = "QuantitàTot"
      Me.ColumnHeader14.Width = 0
      '
      'ColumnHeader15
      '
      Me.ColumnHeader15.Text = "ValoreTotale"
      Me.ColumnHeader15.Width = 0
      '
      'ColumnHeader16
      '
      Me.ColumnHeader16.Text = "QuantitàFatt"
      Me.ColumnHeader16.Width = 0
      '
      'ColumnHeader17
      '
      Me.ColumnHeader17.Text = "ValoreFatt"
      Me.ColumnHeader17.Width = 0
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'txtCoperto
      '
      Me.txtCoperto.AcceptsReturn = True
      Me.txtCoperto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCoperto.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtCoperto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCoperto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCoperto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCoperto.Location = New System.Drawing.Point(984, 160)
      Me.txtCoperto.MaxLength = 100
      Me.txtCoperto.Name = "txtCoperto"
      Me.txtCoperto.ReadOnly = True
      Me.txtCoperto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCoperto.Size = New System.Drawing.Size(88, 29)
      Me.txtCoperto.TabIndex = 8
      Me.txtCoperto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label12
      '
      Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(888, 168)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(88, 24)
      Me.Label12.TabIndex = 233
      Me.Label12.Text = "COPERTO:"
      '
      'Label13
      '
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(10, 16)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(104, 24)
      Me.Label13.TabIndex = 234
      Me.Label13.Text = "TIPO CONTO:"
      '
      'cmdTipoConto
      '
      Me.cmdTipoConto.BackColor = System.Drawing.Color.White
      Me.cmdTipoConto.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdTipoConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdTipoConto.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdTipoConto.Location = New System.Drawing.Point(8, 40)
      Me.cmdTipoConto.Name = "cmdTipoConto"
      Me.cmdTipoConto.Size = New System.Drawing.Size(288, 32)
      Me.cmdTipoConto.TabIndex = 235
      Me.cmdTipoConto.Text = "UNICO"
      Me.cmdTipoConto.UseVisualStyleBackColor = False
      '
      'Label14
      '
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(8, 88)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(184, 24)
      Me.Label14.TabIndex = 236
      Me.Label14.Text = "NUMERO DOCUMENTI:"
      '
      'Label15
      '
      Me.Label15.BackColor = System.Drawing.Color.Transparent
      Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label15.ForeColor = System.Drawing.Color.Black
      Me.Label15.Location = New System.Drawing.Point(8, 128)
      Me.Label15.Name = "Label15"
      Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label15.Size = New System.Drawing.Size(176, 24)
      Me.Label15.TabIndex = 237
      Me.Label15.Text = "TOTALE DA DIVIDERE:"
      '
      'lblQuotaPersona
      '
      Me.lblQuotaPersona.BackColor = System.Drawing.Color.Transparent
      Me.lblQuotaPersona.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblQuotaPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblQuotaPersona.ForeColor = System.Drawing.Color.Black
      Me.lblQuotaPersona.Location = New System.Drawing.Point(8, 168)
      Me.lblQuotaPersona.Name = "lblQuotaPersona"
      Me.lblQuotaPersona.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblQuotaPersona.Size = New System.Drawing.Size(168, 24)
      Me.lblQuotaPersona.TabIndex = 238
      Me.lblQuotaPersona.Text = "QUOTA A PERSONA:"
      '
      'txtTotDividere
      '
      Me.txtTotDividere.AcceptsReturn = True
      Me.txtTotDividere.BackColor = System.Drawing.Color.LightSalmon
      Me.txtTotDividere.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotDividere.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotDividere.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTotDividere.Location = New System.Drawing.Point(184, 120)
      Me.txtTotDividere.MaxLength = 100
      Me.txtTotDividere.Name = "txtTotDividere"
      Me.txtTotDividere.ReadOnly = True
      Me.txtTotDividere.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotDividere.Size = New System.Drawing.Size(112, 29)
      Me.txtTotDividere.TabIndex = 240
      Me.txtTotDividere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtQuotaPersona
      '
      Me.txtQuotaPersona.AcceptsReturn = True
      Me.txtQuotaPersona.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtQuotaPersona.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtQuotaPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtQuotaPersona.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtQuotaPersona.Location = New System.Drawing.Point(184, 160)
      Me.txtQuotaPersona.MaxLength = 100
      Me.txtQuotaPersona.Name = "txtQuotaPersona"
      Me.txtQuotaPersona.ReadOnly = True
      Me.txtQuotaPersona.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtQuotaPersona.Size = New System.Drawing.Size(112, 29)
      Me.txtQuotaPersona.TabIndex = 241
      Me.txtQuotaPersona.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lstvElencoDocAperti
      '
      Me.lstvElencoDocAperti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lstvElencoDocAperti.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvElencoDocAperti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvElencoDocAperti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21})
      Me.lstvElencoDocAperti.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvElencoDocAperti.ForeColor = System.Drawing.Color.Black
      Me.lstvElencoDocAperti.FullRowSelect = True
      Me.lstvElencoDocAperti.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvElencoDocAperti.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem1, ListViewItem2})
      Me.lstvElencoDocAperti.Location = New System.Drawing.Point(8, 239)
      Me.lstvElencoDocAperti.MultiSelect = False
      Me.lstvElencoDocAperti.Name = "lstvElencoDocAperti"
      Me.lstvElencoDocAperti.Size = New System.Drawing.Size(288, 449)
      Me.lstvElencoDocAperti.TabIndex = 243
      Me.lstvElencoDocAperti.UseCompatibleStateImageBehavior = False
      Me.lstvElencoDocAperti.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader18
      '
      Me.ColumnHeader18.Width = 0
      '
      'ColumnHeader19
      '
      Me.ColumnHeader19.Width = 80
      '
      'ColumnHeader20
      '
      Me.ColumnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader20.Width = 190
      '
      'ColumnHeader21
      '
      Me.ColumnHeader21.Width = 0
      '
      'Label17
      '
      Me.Label17.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.Label17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(8, 200)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(288, 40)
      Me.Label17.TabIndex = 244
      Me.Label17.Text = " Stato                          Totale da pagare"
      Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'cmdTipoElenco
      '
      Me.cmdTipoElenco.BackColor = System.Drawing.Color.White
      Me.cmdTipoElenco.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdTipoElenco.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdTipoElenco.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdTipoElenco.Location = New System.Drawing.Point(306, 40)
      Me.cmdTipoElenco.Name = "cmdTipoElenco"
      Me.cmdTipoElenco.Size = New System.Drawing.Size(312, 32)
      Me.cmdTipoElenco.TabIndex = 246
      Me.cmdTipoElenco.Text = "ELENCO COMPLETO"
      Me.cmdTipoElenco.UseVisualStyleBackColor = False
      '
      'Label18
      '
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label18.ForeColor = System.Drawing.Color.Black
      Me.Label18.Location = New System.Drawing.Point(306, 16)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(104, 24)
      Me.Label18.TabIndex = 245
      Me.Label18.Text = "VOCI CONTO:"
      '
      'cmdAddebitoHotel
      '
      Me.cmdAddebitoHotel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdAddebitoHotel.BackColor = System.Drawing.Color.IndianRed
      Me.cmdAddebitoHotel.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdAddebitoHotel.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdAddebitoHotel.ForeColor = System.Drawing.Color.White
      Me.cmdAddebitoHotel.Location = New System.Drawing.Point(888, 600)
      Me.cmdAddebitoHotel.Name = "cmdAddebitoHotel"
      Me.cmdAddebitoHotel.Size = New System.Drawing.Size(184, 72)
      Me.cmdAddebitoHotel.TabIndex = 247
      Me.cmdAddebitoHotel.Text = "&ADDEBITO HOTEL"
      Me.cmdAddebitoHotel.UseVisualStyleBackColor = False
      '
      'cmdCliente
      '
      Me.cmdCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdCliente.BackColor = System.Drawing.Color.White
      Me.cmdCliente.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdCliente.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdCliente.Location = New System.Drawing.Point(632, 40)
      Me.cmdCliente.Name = "cmdCliente"
      Me.cmdCliente.Size = New System.Drawing.Size(440, 32)
      Me.cmdCliente.TabIndex = 248
      Me.cmdCliente.Text = "SELEZIONA CLIENTE"
      Me.cmdCliente.UseVisualStyleBackColor = False
      '
      'cmdDocApertiSu
      '
      Me.cmdDocApertiSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdDocApertiSu.BackColor = System.Drawing.Color.Silver
      Me.cmdDocApertiSu.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDocApertiSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDocApertiSu.Image = CType(resources.GetObject("cmdDocApertiSu.Image"), System.Drawing.Image)
      Me.cmdDocApertiSu.Location = New System.Drawing.Point(160, 696)
      Me.cmdDocApertiSu.Name = "cmdDocApertiSu"
      Me.cmdDocApertiSu.Size = New System.Drawing.Size(136, 40)
      Me.cmdDocApertiSu.TabIndex = 250
      Me.cmdDocApertiSu.UseVisualStyleBackColor = False
      '
      'cmdDocApertiGiù
      '
      Me.cmdDocApertiGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.cmdDocApertiGiù.BackColor = System.Drawing.Color.Silver
      Me.cmdDocApertiGiù.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDocApertiGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDocApertiGiù.Image = CType(resources.GetObject("cmdDocApertiGiù.Image"), System.Drawing.Image)
      Me.cmdDocApertiGiù.Location = New System.Drawing.Point(8, 696)
      Me.cmdDocApertiGiù.Name = "cmdDocApertiGiù"
      Me.cmdDocApertiGiù.Size = New System.Drawing.Size(144, 40)
      Me.cmdDocApertiGiù.TabIndex = 249
      Me.cmdDocApertiGiù.UseVisualStyleBackColor = False
      '
      'cmdDivisioneAnalitica
      '
      Me.cmdDivisioneAnalitica.BackColor = System.Drawing.Color.White
      Me.cmdDivisioneAnalitica.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdDivisioneAnalitica.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdDivisioneAnalitica.ForeColor = System.Drawing.Color.DodgerBlue
      Me.cmdDivisioneAnalitica.Location = New System.Drawing.Point(8, 160)
      Me.cmdDivisioneAnalitica.Name = "cmdDivisioneAnalitica"
      Me.cmdDivisioneAnalitica.Size = New System.Drawing.Size(288, 32)
      Me.cmdDivisioneAnalitica.TabIndex = 251
      Me.cmdDivisioneAnalitica.Text = "DIVISIONE ANALITICA"
      Me.cmdDivisioneAnalitica.UseVisualStyleBackColor = False
      Me.cmdDivisioneAnalitica.Visible = False
      '
      'txtNumDoc
      '
      Me.txtNumDoc.AcceptsReturn = True
      Me.txtNumDoc.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtNumDoc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumDoc.Enabled = False
      Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNumDoc.Location = New System.Drawing.Point(232, 80)
      Me.txtNumDoc.MaxLength = 2
      Me.txtNumDoc.Name = "txtNumDoc"
      Me.txtNumDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumDoc.Size = New System.Drawing.Size(64, 29)
      Me.txtNumDoc.TabIndex = 239
      Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lstvDettagliTemp
      '
      Me.lstvDettagliTemp.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagliTemp.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvDettagliTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagliTemp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28})
      Me.lstvDettagliTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagliTemp.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagliTemp.FullRowSelect = True
      Me.lstvDettagliTemp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagliTemp.Location = New System.Drawing.Point(312, 384)
      Me.lstvDettagliTemp.MultiSelect = False
      Me.lstvDettagliTemp.Name = "lstvDettagliTemp"
      Me.lstvDettagliTemp.Size = New System.Drawing.Size(296, 120)
      Me.lstvDettagliTemp.TabIndex = 252
      Me.lstvDettagliTemp.UseCompatibleStateImageBehavior = False
      Me.lstvDettagliTemp.View = System.Windows.Forms.View.Details
      Me.lstvDettagliTemp.Visible = False
      '
      'ColumnHeader22
      '
      Me.ColumnHeader22.Width = 0
      '
      'ColumnHeader23
      '
      Me.ColumnHeader23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader23.Width = 33
      '
      'ColumnHeader24
      '
      Me.ColumnHeader24.Width = 190
      '
      'ColumnHeader25
      '
      Me.ColumnHeader25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader25.Width = 70
      '
      'ColumnHeader26
      '
      Me.ColumnHeader26.Width = 0
      '
      'ColumnHeader27
      '
      Me.ColumnHeader27.Width = 0
      '
      'ColumnHeader28
      '
      Me.ColumnHeader28.Width = 0
      '
      'lstvDettagliCompatto
      '
      Me.lstvDettagliCompatto.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagliCompatto.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvDettagliCompatto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagliCompatto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader31, Me.ColumnHeader32, Me.ColumnHeader33, Me.ColumnHeader34, Me.ColumnHeader35})
      Me.lstvDettagliCompatto.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagliCompatto.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagliCompatto.FullRowSelect = True
      Me.lstvDettagliCompatto.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagliCompatto.Location = New System.Drawing.Point(312, 512)
      Me.lstvDettagliCompatto.MultiSelect = False
      Me.lstvDettagliCompatto.Name = "lstvDettagliCompatto"
      Me.lstvDettagliCompatto.Size = New System.Drawing.Size(296, 120)
      Me.lstvDettagliCompatto.TabIndex = 253
      Me.lstvDettagliCompatto.UseCompatibleStateImageBehavior = False
      Me.lstvDettagliCompatto.View = System.Windows.Forms.View.Details
      Me.lstvDettagliCompatto.Visible = False
      '
      'ColumnHeader29
      '
      Me.ColumnHeader29.Width = 0
      '
      'ColumnHeader30
      '
      Me.ColumnHeader30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader30.Width = 33
      '
      'ColumnHeader31
      '
      Me.ColumnHeader31.Width = 190
      '
      'ColumnHeader32
      '
      Me.ColumnHeader32.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader32.Width = 70
      '
      'ColumnHeader33
      '
      Me.ColumnHeader33.Width = 0
      '
      'ColumnHeader34
      '
      Me.ColumnHeader34.Width = 0
      '
      'ColumnHeader35
      '
      Me.ColumnHeader35.Width = 0
      '
      'lstvDettagliCopia
      '
      Me.lstvDettagliCopia.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagliCopia.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvDettagliCopia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagliCopia.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader36, Me.ColumnHeader37, Me.ColumnHeader38, Me.ColumnHeader39, Me.ColumnHeader40, Me.ColumnHeader41, Me.ColumnHeader42})
      Me.lstvDettagliCopia.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagliCopia.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagliCopia.FullRowSelect = True
      Me.lstvDettagliCopia.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagliCopia.Location = New System.Drawing.Point(312, 256)
      Me.lstvDettagliCopia.MultiSelect = False
      Me.lstvDettagliCopia.Name = "lstvDettagliCopia"
      Me.lstvDettagliCopia.Size = New System.Drawing.Size(296, 120)
      Me.lstvDettagliCopia.TabIndex = 254
      Me.lstvDettagliCopia.UseCompatibleStateImageBehavior = False
      Me.lstvDettagliCopia.View = System.Windows.Forms.View.Details
      Me.lstvDettagliCopia.Visible = False
      '
      'ColumnHeader36
      '
      Me.ColumnHeader36.Width = 0
      '
      'ColumnHeader37
      '
      Me.ColumnHeader37.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader37.Width = 33
      '
      'ColumnHeader38
      '
      Me.ColumnHeader38.Width = 190
      '
      'ColumnHeader39
      '
      Me.ColumnHeader39.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader39.Width = 70
      '
      'ColumnHeader40
      '
      Me.ColumnHeader40.Width = 0
      '
      'ColumnHeader41
      '
      Me.ColumnHeader41.Width = 0
      '
      'ColumnHeader42
      '
      Me.ColumnHeader42.Width = 0
      '
      'txtIdCliente
      '
      Me.txtIdCliente.AcceptsReturn = True
      Me.txtIdCliente.BackColor = System.Drawing.SystemColors.Window
      Me.txtIdCliente.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIdCliente.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIdCliente.Location = New System.Drawing.Point(1248, 152)
      Me.txtIdCliente.MaxLength = 100
      Me.txtIdCliente.Name = "txtIdCliente"
      Me.txtIdCliente.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIdCliente.Size = New System.Drawing.Size(64, 29)
      Me.txtIdCliente.TabIndex = 255
      Me.txtIdCliente.Visible = False
      '
      'txtIdAzienda
      '
      Me.txtIdAzienda.AcceptsReturn = True
      Me.txtIdAzienda.BackColor = System.Drawing.SystemColors.Window
      Me.txtIdAzienda.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIdAzienda.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIdAzienda.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIdAzienda.Location = New System.Drawing.Point(1472, 152)
      Me.txtIdAzienda.MaxLength = 100
      Me.txtIdAzienda.Name = "txtIdAzienda"
      Me.txtIdAzienda.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIdAzienda.Size = New System.Drawing.Size(64, 29)
      Me.txtIdAzienda.TabIndex = 256
      Me.txtIdAzienda.Visible = False
      '
      'Label16
      '
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(1096, 152)
      Me.Label16.Name = "Label16"
      Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label16.Size = New System.Drawing.Size(144, 24)
      Me.Label16.TabIndex = 257
      Me.Label16.Text = "ID CLIENTE:"
      Me.Label16.Visible = False
      '
      'Label19
      '
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(1344, 152)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(112, 24)
      Me.Label19.TabIndex = 258
      Me.Label19.Text = "ID AZIENDA:"
      Me.Label19.Visible = False
      '
      'cmdTastiera
      '
      Me.cmdTastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmdTastiera.BackColor = System.Drawing.Color.Gray
      Me.cmdTastiera.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdTastiera.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdTastiera.ForeColor = System.Drawing.Color.White
      Me.cmdTastiera.Image = CType(resources.GetObject("cmdTastiera.Image"), System.Drawing.Image)
      Me.cmdTastiera.Location = New System.Drawing.Point(632, 696)
      Me.cmdTastiera.Name = "cmdTastiera"
      Me.cmdTastiera.Size = New System.Drawing.Size(56, 40)
      Me.cmdTastiera.TabIndex = 259
      Me.cmdTastiera.UseVisualStyleBackColor = False
      '
      'ContoPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(1079, 768)
      Me.Controls.Add(Me.cmdTastiera)
      Me.Controls.Add(Me.Label19)
      Me.Controls.Add(Me.Label16)
      Me.Controls.Add(Me.txtIdAzienda)
      Me.Controls.Add(Me.txtIdCliente)
      Me.Controls.Add(Me.lstvDettagliCopia)
      Me.Controls.Add(Me.lstvDettagliCompatto)
      Me.Controls.Add(Me.lstvDettagliTemp)
      Me.Controls.Add(Me.cmdDocApertiSu)
      Me.Controls.Add(Me.cmdDocApertiGiù)
      Me.Controls.Add(Me.cmdCliente)
      Me.Controls.Add(Me.cmdAddebitoHotel)
      Me.Controls.Add(Me.cmdTipoElenco)
      Me.Controls.Add(Me.Label18)
      Me.Controls.Add(Me.lstvElencoDocAperti)
      Me.Controls.Add(Me.Label17)
      Me.Controls.Add(Me.txtQuotaPersona)
      Me.Controls.Add(Me.txtTotDividere)
      Me.Controls.Add(Me.txtNumDoc)
      Me.Controls.Add(Me.lblQuotaPersona)
      Me.Controls.Add(Me.Label15)
      Me.Controls.Add(Me.Label14)
      Me.Controls.Add(Me.cmdTipoConto)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.txtCoperto)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.lstvDatiBuoni)
      Me.Controls.Add(Me.txtBuoni)
      Me.Controls.Add(Me.txtIva)
      Me.Controls.Add(Me.txtResto)
      Me.Controls.Add(Me.txtSospeso)
      Me.Controls.Add(Me.txtCartaCredito)
      Me.Controls.Add(Me.txtContanti)
      Me.Controls.Add(Me.txtDaPagare)
      Me.Controls.Add(Me.txtServizio)
      Me.Controls.Add(Me.txtValSconto)
      Me.Controls.Add(Me.txtTotaleConto)
      Me.Controls.Add(Me.txtPIva)
      Me.Controls.Add(Me.txtProv)
      Me.Controls.Add(Me.txtCap)
      Me.Controls.Add(Me.txtCittà)
      Me.Controls.Add(Me.txtIndirizzo)
      Me.Controls.Add(Me.cmdBuoni)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.Label10)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.Label11)
      Me.Controls.Add(Me.cmdCancella)
      Me.Controls.Add(Me.cmdNum00)
      Me.Controls.Add(Me.cmdC)
      Me.Controls.Add(Me.cmdX)
      Me.Controls.Add(Me.cmdPercentuale)
      Me.Controls.Add(Me.cmdVirgola)
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
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.cmdTipoPagamento)
      Me.Controls.Add(Me.cmdContanti)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.cmdProforma)
      Me.Controls.Add(Me.cmdScontrino)
      Me.Controls.Add(Me.cmdEsci)
      Me.Controls.Add(Me.cmdFattura)
      Me.Controls.Add(Me.cmdRicevuta)
      Me.Controls.Add(Me.Label31)
      Me.Controls.Add(Me.Label5)
      Me.Controls.Add(Me.Label4)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.cmdDettagliSu)
      Me.Controls.Add(Me.cmdDettagliGiù)
      Me.Controls.Add(Me.cmdDivisioneAnalitica)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MinimizeBox = False
      Me.Name = "ContoPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "STAMPA CONTO"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Public Function CreaFileScontrinoWPOS1() As Boolean
      Try
         Dim SR_DATI_TEST As String = "SR_DATI_TEST.TXT"
         Dim SR_DATI As String = "SR_DATI."
         Dim SR_START As String = "SR_START."
         Dim tipoPagContanti As String
         Dim tipoPagCartaCredito As String
         Dim tipoPagBuoni As String
         Dim sw As StreamWriter

         If PercorsoLavoroWpos1 = String.Empty Then
            Return False
         End If

         If EstensioneFileWpos1 = String.Empty Then
            Return False
         Else
            SR_DATI = SR_DATI & EstensioneFileWpos1
            SR_START = SR_START & EstensioneFileWpos1
         End If

         ' Tipo pagamento - Contanti.
         If txtContanti.Text <> "0,00" And txtContanti.Text <> "" Then
            tipoPagContanti = "CASH,V" & RimuoviVirgola(txtContanti.Text) & ";"
         End If

         ' Tipo pagamento.
         If txtCartaCredito.Text <> "0,00" And txtCartaCredito.Text <> "" Then
            If cmdTipoPagamento.Text.ToUpper <> "ASSEGNI" And cmdTipoPagamento.Text.ToUpper <> "ASSEGNO" Then
               ' Tipo pagamento - Carta di credito.
               tipoPagCartaCredito = "CARD,V" & RimuoviVirgola(txtCartaCredito.Text) & ",:" & cmdTipoPagamento.Text & ";"
            Else
               ' Tipo pagamento - Assegno
               tipoPagCartaCredito = "CHEQ,V" & RimuoviVirgola(txtCartaCredito.Text) & ";"
            End If
         End If

         ' Tipo pagamento - Buoni Pasto.
         If txtBuoni.Text <> "0,00" And txtBuoni.Text <> "" Then
            tipoPagBuoni = "CASH,V" & RimuoviVirgola(txtBuoni.Text) & ";"
         End If

         If tipoPagContanti = String.Empty And tipoPagCartaCredito = String.Empty And tipoPagBuoni = String.Empty Then
            MessageBox.Show("E' necessario specificare il tipo di pagamento e il valore dell'importo.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            txtContanti.Focus()
            Return False
         End If

         ' Crea il file Start con la password.
         sw = File.CreateText(PercorsoLavoroWpos1 & "\" & SR_START)
         sw.WriteLine(PwdDriverWpos1)
         sw.Close()

         ' Crea il file Dati con le righe di vendita.
         sw = File.CreateText(PercorsoLavoroWpos1 & "\" & SR_DATI)

         ' Righe di vendita articoli.
         Dim j As Integer
         For j = 0 To lstvDettagli.Items.Count - 1
            Dim rigaScontrino As String = "PLUD,C1,N1,P" & RimuoviVirgola(lstvDettagli.Items(j).SubItems(4).Text) & ",Q" & lstvDettagli.Items(j).SubItems(1).Text & ",:" & lstvDettagli.Items(j).SubItems(2).Text.ToUpper & ";"
            sw.WriteLine(rigaScontrino)
         Next

         ' Servizio %.
         If txtServizio.Text <> "0,00" And txtServizio.Text <> "" Then
            sw.WriteLine("PRNT,N1,:;")

            If txtServizio.Text.Substring(txtServizio.Text.Length - 1, 1) = "%" Then
               ' Maggiorazione percentuale.
               sw.WriteLine("PRNT,:SERVIZIO " & SostituisciVirgola(txtServizio.Text) & "%;")
               sw.WriteLine("MOST,%" & SostituisciVirgola(txtServizio.Text) & ";")
            Else
               ' Maggiorazione a valore.
               sw.WriteLine("PRNT,:SERVIZIO " & txtServizio.Text & ";")
               sw.WriteLine("ADDS,V" & RimuoviVirgola(txtServizio.Text) & ";")
            End If
         End If

         ' Sconto %.
         If txtValSconto.Text <> "0,00" And txtValSconto.Text <> "" Then
            sw.WriteLine("PRNT,N1,:;")
            If txtValSconto.Text.Substring(txtValSconto.Text.Length - 1, 1) = "%" Then
               ' Sconto percentuale.
               sw.WriteLine("DOST,%" & SostituisciVirgola(txtValSconto.Text) & ";")
            Else
               ' Sconto a valore.
               sw.WriteLine("COST,V" & RimuoviVirgola(txtValSconto.Text) & ";")
            End If
         End If

         ' Istruzioni da verificare...non utilizzate perchè il registratore di cassa dovrebbe inserirle automaticamente.
         ' Operatore - Numero postazione cassa.
         'sw.WriteLine("EXTL,N1,:OPERATORE N. " & LeggiCodiceOperatoreConfig() & ";")
         'sw.WriteLine("EXTL,N1,:;")
         'sw.WriteLine("EXTL,N1,:NUMERO CASSA " & g_frmMain.eui_cmdPostazione.Text.Remove(0, 1) & ";")

         ' Tipo pagamento - Contanti.
         sw.WriteLine(tipoPagContanti)

         ' Tipo pagamento - Carta di credito - Assegno.
         sw.WriteLine(tipoPagCartaCredito)

         sw.Close()

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Function CreaFileScontrinoSwing() As Boolean
      Try
         Dim numComandiScontrino As Integer = 2
         Dim numRigheScontrino As Integer = lstvDettagli.Items.Count + numComandiScontrino
         Dim sw As StreamWriter

         If NomeScontrinoSF = String.Empty Then
            Return False
         End If

         If PercorsoOutputSF = String.Empty Then
            Return False
         End If

         If PercorsoDriverSF = String.Empty Then
            Return False
         End If

         If File.Exists(PercorsoOutputSF & "\" & NomeScontrinoSF) = True Then
            File.Delete(PercorsoOutputSF & "\" & NomeScontrinoSF)
         End If

         sw = File.CreateText(PercorsoOutputSF & "\" & NomeScontrinoSF)
         sw.WriteLine(" " & PortaSF.ToString.Substring(4))
         sw.WriteLine(ParametriSF)
         sw.WriteLine(" " & numRigheScontrino.ToString)
         sw.WriteLine("=K")
         sw.WriteLine("=C1")

         Dim i As Integer
         For i = 0 To lstvDettagli.Items.Count - 1
            Dim rigaScontrino As String = "=R1/$" & lstvDettagli.Items(i).SubItems(4).Text & "/*" & lstvDettagli.Items(i).SubItems(1).Text & "/" & "(" & lstvDettagli.Items(i).SubItems(2).Text.ToUpper & ")"
            sw.WriteLine(rigaScontrino)
         Next

         sw.Close()

         EseguiFileScontrino(Me.Handle)

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Public Sub EseguiFileScontrino(ByVal frmHandle As IntPtr)
      Dim NOME_APP As String = PercorsoDriverSF & "SWINGDRIVER.EXE"
      Dim Proc As New Process

      Try
         ' Avvia l'applicazione.
         Proc.StartInfo.FileName = NOME_APP
         Proc.StartInfo.Arguments = PercorsoOutputSF & NomeScontrinoSF
         Proc.StartInfo.ErrorDialog = True
         Proc.StartInfo.ErrorDialogParentHandle = frmHandle
         Proc.StartInfo.UseShellExecute = True
         Proc.Start()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function LeggiCodiceOperatoreConfig() As String
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim codiceOperatore As String

         If DatiConfig.GetValue("CodiceOperatore") <> String.Empty Then
            codiceOperatore = DatiConfig.GetValue("CodiceOperatore")
         Else
            codiceOperatore = "1"
         End If

         Return codiceOperatore

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Sub ImpostaValoriConto()
      Try
         With g_frmPos
            txtIndirizzo.Text = ""
            txtCap.Text = ""
            txtCittà.Text = ""
            txtProv.Text = ""
            txtPIva.Text = ""

            If AliquotaIvaRistorante <> String.Empty Then
               txtIva.Text = CFormatta.FormattaEuro(AliquotaIvaRistorante)
            Else
               txtIva.Text = ""
            End If

            If g_frmPos.nomeTavolo <> String.Empty And g_frmPos.nomeTavolo <> "Asporto" Then
               If CopertoRistorante <> String.Empty Then
                  txtCoperto.Text = CalcolaCostoTotaleCoperto(CopertoRistorante, g_frmVCTavoli.lblCoperti.Text)
               Else
                  txtCoperto.Text = VALORE_ZERO
               End If
            Else
               txtCoperto.Text = VALORE_ZERO
            End If

            txtTotaleConto.Text = TotaleContoRep
            txtValSconto.Text = VALORE_ZERO

            If g_frmPos.nomeTavolo <> String.Empty And g_frmPos.nomeTavolo <> "Asporto" Then
               If ServizioRistorante <> String.Empty Then
                  txtServizio.Text = CFormatta.FormattaEuro(ServizioRistorante) & "%"
               Else
                  txtServizio.Text = VALORE_ZERO
               End If
            Else
               txtServizio.Text = VALORE_ZERO
            End If

            txtDaPagare.Text = TotaleContoRep
            txtContanti.Text = VALORE_ZERO
            txtCartaCredito.Text = VALORE_ZERO
            txtBuoni.Text = VALORE_ZERO
            txtSospeso.Text = VALORE_ZERO
            txtResto.Text = VALORE_ZERO

            lstvDatiBuoni.Items.Clear()

            op1 = 0.0
            op2 = 0.0
            valSconto = 0.0
            valServizio = 0.0

            formatta = False
            moltiplica = False
            cCredito = False
            contanti = False

            cmdOk.PerformClick()
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub CaricaListaConto()
      Try
         lstvDettagli.Items.Clear()
         lstvDettagliCopia.Items.Clear()

         With g_frmPos
            Dim i As Integer
            For i = 0 To .lstvDettagli.Items.Count - 1
               Dim colore As Color = .lstvDettagli.Items(i).BackColor
               If colore.Equals(Color.LightCoral) = False Then
                  ' Indice
                  lstvDettagli.Items.Add(lstvDettagli.Items.Count - 1)
                  lstvDettagliCopia.Items.Add(lstvDettagliCopia.Items.Count - 1)

                  ' Quantità
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(1))
                  lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(1))

                  ' Descrizione.
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(2))
                  lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(2))

                  ' Importo.
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(3))
                  lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(3))

                  ' Prezzo.
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(4))
                  lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(4))

                  ' Id Piatto.
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(5))
                  lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(5))

                  ' Categoria.
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(6))
                  lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(6))
               End If
            Next
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub CancellaDatiCliente()
      txtIdAzienda.Text = String.Empty
      txtIdCliente.Text = String.Empty
      txtIndirizzo.Text = String.Empty
      txtCap.Text = String.Empty
      txtCittà.Text = String.Empty
      txtProv.Text = String.Empty
      txtPIva.Text = String.Empty
      txtIva.Text = VALORE_ZERO
      txtValSconto.Text = VALORE_ZERO
   End Sub

   Public Sub CaricaListaClienteAzienda(ByVal cmb As ComboBox, ByVal cmb1 As ComboBox, ByVal tabella As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY RagSociale ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         cmb.Items.Clear()
         Do While dr.Read
            cmb.Items.Add(dr.Item("RagSociale"))
            cmb1.Items.Add(dr.Item("Id"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub LeggiDatiClienteAzienda(ByVal tabella As String, ByVal id As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         idCliente = id

         Do While dr.Read
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               txtIndirizzo.Text = dr.Item("Indirizzo")
            Else
               txtIndirizzo.Text = ""
            End If
            If IsDBNull(dr.Item("Cap")) = False Then
               txtCap.Text = dr.Item("Cap")
            Else
               txtCap.Text = ""
            End If
            If IsDBNull(dr.Item("Città")) = False Then
               txtCittà.Text = dr.Item("Città")
            Else
               txtCittà.Text = ""
            End If
            If IsDBNull(dr.Item("Provincia")) = False Then
               txtProv.Text = dr.Item("Provincia")
            Else
               txtProv.Text = ""
            End If
            If IsDBNull(dr.Item("PIva")) = False Then
               txtPIva.Text = dr.Item("PIva")
            Else
               txtPIva.Text = ""
            End If
            If IsDBNull(dr.Item("Iva")) = False Then
               txtIva.Text = CFormatta.FormattaNumeroDouble(dr.Item("Iva"))
            Else
               txtIva.Text = VALORE_ZERO
            End If
            If IsDBNull(dr.Item("Sconto")) = False Then
               txtValSconto.Text = CFormatta.FormattaNumeroDouble(dr.Item("Sconto")) & "%"
            Else
               txtValSconto.Text = VALORE_ZERO
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Function VerificaCartaCredito() As Boolean
      If txtCartaCredito.Text <> "" And txtCartaCredito.Text <> VALORE_ZERO Then
         If cmdTipoPagamento.Text = "C. CREDITO" Then
            MsgBox("E' stato inserito un importo pagato con carta di credito. Specificare la carta di credito utilizzata.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
            Return False
         Else
            Return True
         End If
      Else
         Return True
      End If
   End Function

   Public Function VerificaIntestazione() As Boolean
      Dim val(5) As Boolean

      If cmdCliente.Text = "NESSUNO" Then
         MsgBox("Impossibile stampare il documento! Specificare l'intestatario.", MsgBoxStyle.OkOnly + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
         Return False
      Else
         If txtIndirizzo.Text = "" Then
            val(0) = False
         Else
            val(0) = True
         End If
         If txtCap.Text = "" Then
            val(1) = False
         Else
            val(1) = True
         End If
         If txtCittà.Text = "" Then
            val(2) = False
         Else
            val(2) = True
         End If
         If txtProv.Text = "" Then
            val(3) = False
         Else
            val(3) = True
         End If
         If txtPIva.Text = "" Then
            val(4) = False
         Else
            val(4) = True
         End If
         If txtCittà.Text = "" Then
            val(2) = False
         Else
            val(2) = True
         End If
         If txtIva.Text = "" Then
            val(5) = False
         Else
            val(5) = True
         End If

         Dim risposta As Integer
         Dim i As Integer = 0
         For i = 0 To 5
            If val(i) = False Then
               risposta = MsgBox("Alcuni dati del cliente per l'intestazione del documento non sono stati specificati. Effettuare comunque la stampa?  ", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
               If risposta = vbNo Then
                  Return False
               Else
                  Return True
               End If
            End If
         Next

         Return True
      End If
   End Function

   Private Function CalcolaCostoTotaleCoperto(ByVal costoCoperto As String, ByVal numCoperti As String) As String
      Dim costo As Double = Convert.ToDouble(costoCoperto)
      Dim Coperti As Integer = Convert.ToInt32(numCoperti)
      Dim totCoperto As Double = costo * Coperti

      Return CFormatta.FormattaEuro(totCoperto)

   End Function

   Private Sub StampaConto(ByVal nomeStampante As String)
      Try
         ' Identifica che è in corso la stampa di documenti multipli (Alla romana, Separato manuale)
         stampaDocInCorso = True

         ' Controlla quanti conti sono aperti e chiude quello selezionato di cui è stato stampato il documento.
         If lstvElencoDocAperti.Items.Count <> 0 Then
            lstvElencoDocAperti.Focus()
            If lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(1).Text = "Chiuso" Then
               MessageBox.Show("Per stampare il documento è necessario selezionare un conto 'Aperto'.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Sub
            End If
         End If

         If DocSalvato = False Then
            ' Salva il documento fiscale.
            DocSalvato = SalvaDocumento()
         End If

         g_frmPos.CausaleMovMag = tipoDocumento

         Select Case percorsoRep
            Case PERCORSO_REP_PF, PERCORSO_REP_FF, PERCORSO_REP_RF,
                 PERCORSO_REP_PF_CENTRO_SPORTIVO, PERCORSO_REP_FF_CENTRO_SPORTIVO, PERCORSO_REP_RF_CENTRO_SPORTIVO,
                 PERCORSO_REP_RF_BELLA_NAPOLI, PERCORSO_REP_FF_BELLA_NAPOLI, PERCORSO_REP_PF_BELLA_NAPOLI,
                 PERCORSO_REP_RF_CELIDE, PERCORSO_REP_FF_CELIDE, PERCORSO_REP_PF_CELIDE

               ' Esegue la stampa.
               StampaDocumento(percorsoRep, LeggiUltimoRecord(TAB_DOC), nomeStampante)

            Case PERCORSO_REP_SF
               ' Esegue la stampa.
               If ModelloSF = "Swing ECR 65/A" Then
                  If CreaFileScontrinoSwing() = False Then
                     g_frmPos.InfoScontrino()
                     Exit Sub
                  End If
               Else
                  If CreaFileScontrinoWPOS1() = False Then
                     g_frmPos.InfoScontrino()
                     Exit Sub
                  End If
               End If

            Case PERCORSO_REP_PF_KUBEII
               Dim sql As String = "SELECT * FROM " & TAB_DETTAGLI_DOC & " WHERE RifDoc = " & LeggiUltimoRecord(TAB_DOC)
               StampaProformaKUBEII(sql, percorsoRep, LeggiUltimoRecord(TAB_DOC), nomeTavoloDoc, nomeCameriereDoc, nomeStampante)

            Case PERCORSO_REP_RF_KUBEII
               StampaRicevutaFatturaKUBEII(PERCORSO_REP_RF_KUBEII, LeggiUltimoRecord(TAB_DOC), nomeStampante)

            Case PERCORSO_REP_FF_KUBEII
               StampaRicevutaFatturaKUBEII(PERCORSO_REP_FF_KUBEII, LeggiUltimoRecord(TAB_DOC), nomeStampante)

         End Select

         Dim risposta As MsgBoxResult
         risposta = MsgBox("Il conto è stato stampato correttamente?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)

         If risposta = MsgBoxResult.Yes Then
            ' Salva i dati di eventuali Buoni.
            SalvaDatiBuoni()

            ' Registra loperazione effettuata dall'operatore identificato.
            Dim strDescrizione As String = "(" & Doc.Tipo & " n. " & Doc.Numero & " del " & Doc.Data & " - € " & CFormatta.FormattaEuro(Doc.TotDoc) & ")"
            Select Case tipoDocumento
               Case TIPO_DOC_RF
                  g_frmMain.RegistraOperazione(TipoOperazione.Ricevuta, strDescrizione, MODULO_CONTO)

               Case TIPO_DOC_FF
                  g_frmMain.RegistraOperazione(TipoOperazione.Fattura, strDescrizione, MODULO_CONTO)

               Case TIPO_DOC_PF
                  g_frmMain.RegistraOperazione(TipoOperazione.Proforma, strDescrizione, MODULO_CONTO)

               Case TIPO_DOC_SF
                  g_frmMain.RegistraOperazione(TipoOperazione.Scontrino, strDescrizione, MODULO_CONTO)
            End Select

            ' Controlla quanti conti sono aperti e chiude quello selezionato di cui è stato stampato il documento.
            If lstvElencoDocAperti.Items.Count <> 0 Then
               lstvElencoDocAperti.Focus()
               lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(1).Text = "Chiuso"
               DocSalvato = False
            End If

            ' Conta il numero di conti ancora aperti da stampare.
            Dim numDocAperti As Integer = 0
            Dim i As Integer = 0
            For i = 0 To lstvElencoDocAperti.Items.Count - 1
               If lstvElencoDocAperti.Items(i).SubItems(1).Text = "Aperto" Then
                  numDocAperti += 1
               End If
            Next

            ' Se non ci sono documenti aperti chiude la finestra.
            If numDocAperti = 0 Then
               Me.DialogResult = DialogResult.OK
               Me.Close()
            Else
               ' Disattiva i controlli che modificano gli importi.
               cmdTipoConto.Enabled = False
               cmdDivisioneAnalitica.Enabled = False
               txtNumDoc.Enabled = False
               txtValSconto.Enabled = False
               txtServizio.Enabled = False

               txtContanti.Text = VALORE_ZERO
               txtCartaCredito.Text = VALORE_ZERO
               txtBuoni.Text = VALORE_ZERO

               cmdOk.PerformClick()

               Exit Sub
            End If

         Else
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub StampaDocumento(ByVal nomeDoc As String, ByVal numDoc As Integer, ByVal nomeStampante As String)
      Try
         'If PrintDialog1.ShowDialog() = DialogResult.OK Then

         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         ' Tabella Documenti.
         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_DOC & " WHERE Id = " & numDoc, cn)

         Dim ds As New Dataset1
         ds.Clear()
         oleAdapter.Fill(ds, TAB_DOC)

         ' Tabella DettagliDoc
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_DETTAGLI_DOC & " WHERE RifDoc = " & numDoc, cn)
         oleAdapter1.Fill(ds, TAB_DETTAGLI_DOC)

         ' Tabella Azienda
         Dim oleAdapter2 As New OleDbDataAdapter
         oleAdapter2.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_AZIENDA, cn)
         oleAdapter2.Fill(ds, TAB_AZIENDA)

         Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

         rep.Load(Application.StartupPath & nomeDoc)

         rep.SetDataSource(ds)

         'Dim repOp As New CrystalDecisions.Shared.ExportFormatType
         'rep.ExportToDisk(repOp.WordForWindows, "C:\File\Prova.doc")
         'rep.ExportToDisk(repOp.Excel, "C:\File\Prova.xls")
         'rep.ExportToDisk(repOp.PortableDocFormat, "C:\File\Prova.pdf")

         ' Exit Sub

         If nomeStampante <> String.Empty And nomeStampante <> "Nessuna" Then
            rep.PrintOptions.PrinterName = nomeStampante
         End If

         ' Imposta il numero di copie del documento da stampare per il tipo di report.
         Select Case nomeDoc.Remove(0, 9)
            Case REPORT_RICEVUTA_BELLA_NAPOLI, REPORT_FATTURA_BELLA_NAPOLI, REPORT_PROFORMA_BELLA_NAPOLI

               PrintDialog1.PrinterSettings.Copies = 2

            Case Else
               PrintDialog1.PrinterSettings.Copies = 1

         End Select

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

   Private Function SalvaDocumento() As Boolean
      Try
         With Doc
            Dim valSospeso As Double = Convert.ToDouble(txtSospeso.Text) + Convert.ToDouble(txtCartaCredito.Text)
            Dim valDaPagare As Double = Convert.ToDouble(txtDaPagare.Text)

            .Numero = LeggiNumeroMax(TAB_DOC, tipoDocumento) + 1
            .Data = g_frmPos.dtpData.Value.Date
            .Ora = g_frmPos.lblOra.Text
            .Tipo = tipoDocumento
            Select Case tipoCliente
               Case Cliente.Azienda
                  ' Viene aggiunta la lettera A per identificare le Aziende.
                  ' Codice aggiunto dopo la creazione della nuova anagrafica Aziende.
                  .IdCliente = "A" & idCliente
               Case Cliente.Privato
                  ' ID normale.
                  .IdCliente = idCliente
            End Select
            If cmdCliente.Text = "SELEZIONA CLIENTE" Then
               .Cliente = ""
            Else
               .Cliente = FormattaApici(cmdCliente.Text)
            End If
            .Indirizzo = FormattaApici(txtIndirizzo.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .PIva = txtPIva.Text
            .CodAzienda = ""
            .Coperto = CFormatta.FormattaNumeroDouble(txtCoperto.Text)
            .Sconto = CFormatta.FormattaNumeroDouble(valSconto)
            .Servizio = CFormatta.FormattaNumeroDouble(valServizio)
            .BuoniPasto = CFormatta.FormattaNumeroDouble(txtBuoni.Text)
            .BuoniPastoIncassare = CFormatta.FormattaNumeroDouble(txtBuoni.Text)
            .Chiuso = "No"
            .Note = ""

            If txtCartaCredito.Text <> VALORE_ZERO Then
               .TipoPagamento = cmdTipoPagamento.Text & ": € " & CFormatta.FormattaNumeroDouble(valSospeso)
            Else
               .TipoPagamento = ""
            End If

            .Tavolo = nomeTavoloDoc
            .Cameriere = nomeCameriereDoc
            .Sospeso = CFormatta.FormattaNumeroDouble(valSospeso)
            .SospesoIncassare = CFormatta.FormattaNumeroDouble(valSospeso)
            .TotDoc = CFormatta.FormattaNumeroDouble(Convert.ToDouble(valDaPagare))

            If tipoDocumento = TIPO_DOC_FF Then
               ' Calcola l'IVA.
               Dim valImposta As Double
               Dim valImponibile As Double
               If IsNumeric(txtIva.Text) = True Then

                  Dim valCoefficiente As Double
                  Select Case txtIva.Text
                     Case "22,00"
                        valCoefficiente = 1.22
                     Case "21,00"
                        valCoefficiente = 1.21
                     Case "20,00"
                        valCoefficiente = 1.2
                     Case "10,00"
                        valCoefficiente = 1.1
                     Case "4,00"
                        valCoefficiente = 1.04
                     Case Else
                        valCoefficiente = 0.0
                  End Select

                  If valCoefficiente <> 0.0 Then
                     valImponibile = (valDaPagare / valCoefficiente)
                  Else
                     valImponibile = 0.0
                  End If

                  valImposta = CalcolaPercentuale(valImponibile, Convert.ToDouble(txtIva.Text))
               Else
                  valImposta = 0.0
                  txtIva.Text = VALORE_ZERO
               End If

               'Dim valImponibile As Double = (valDaPagare - valImposta)
               .Imponibile = CFormatta.FormattaNumeroDouble(valImponibile)
               .Iva = txtIva.Text
               .Imposta = CFormatta.FormattaNumeroDouble(valImposta)
            Else
               .Imponibile = VALORE_ZERO
               .Iva = VALORE_ZERO
               .Imposta = VALORE_ZERO
            End If

            .InserisciDati(TAB_DOC)
         End With

         ' SALVA I DETTAGLI DEL DOCUMENTO.
         Dim sql As String
         ' Apre la connessione.
         cn.Open()

         If cmdTipoConto.Text = "CONTO UNICO" Then
            ' SALVA I DETTAGLI PER IL COPERTO.
            If Doc.Coperto <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " & _
                                             "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOC)
               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)
               cmdInsert.Parameters.Add("@RifDoc", LeggiUltimoRecord(TAB_DOC))
               cmdInsert.Parameters.Add("@Descrizione", "Coperto")
               cmdInsert.Parameters.Add("@Quantità", NumCopertiRistorante)
               cmdInsert.Parameters.Add("@ImportoNetto", Doc.Coperto)
               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

         ' SALVA I DETTAGLI PER I PIATTI.
         Dim i As Integer
         For i = 0 To lstvDettagli.Items.Count - 1
            'Dim colore As Color = lstvDettagli.Items(i).BackColor
            'If colore.Equals(Color.LightCoral) = False Then

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di eliminazione.
            sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ValoreUnitario, ImportoNetto) " & _
                                          "VALUES(@RifDoc, @Descrizione, @Quantità, @ValoreUnitario, @ImportoNetto)", TAB_DETTAGLI_DOC)

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)

            cmdInsert.Parameters.Add("@RifDoc", LeggiUltimoRecord(TAB_DOC))
            cmdInsert.Parameters.Add("@Descrizione", FormattaApici(lstvDettagli.Items(i).SubItems(2).Text))
            cmdInsert.Parameters.Add("@Quantità", lstvDettagli.Items(i).SubItems(1).Text)
            cmdInsert.Parameters.Add("@ValoreUnitario", VALORE_ZERO) ' B_TODO: Modifica per Retail.
            cmdInsert.Parameters.Add("@ImportoNetto", lstvDettagli.Items(i).SubItems(3).Text)

            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()

            'End If
         Next

         If cmdTipoConto.Text <> "ALLA ROMANA" Then
            ' SALVA I DETTAGLI PER LO SCONTO.
            If Doc.Sconto <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " & _
                                             "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOC)
               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)
               cmdInsert.Parameters.Add("@RifDoc", LeggiUltimoRecord(TAB_DOC))
               cmdInsert.Parameters.Add("@Descrizione", "Sconto")
               cmdInsert.Parameters.Add("@Quantità", "1")
               cmdInsert.Parameters.Add("@ImportoNetto", "-" & Doc.Sconto)
               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

         If cmdTipoConto.Text <> "ALLA ROMANA" Then
            ' SALVA I DETTAGLI PER IL SERVIZIO.
            If Doc.Servizio <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di eliminazione.
               sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " & _
                                             "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOC)
               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)
               cmdInsert.Parameters.Add("@RifDoc", LeggiUltimoRecord(TAB_DOC))
               cmdInsert.Parameters.Add("@Descrizione", "Servizio")
               cmdInsert.Parameters.Add("@Quantità", "1")
               cmdInsert.Parameters.Add("@ImportoNetto", Doc.Servizio)
               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

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

   Private Sub SalvaDatiBuoni()
      Try
         ' Salva i dati per l'anagrafica Aziende.
         Dim CBuoniPasto As New Buoni
         With CBuoniPasto
            Dim i As Integer
            For i = 0 To lstvDatiBuoni.Items.Count - 1
               .IdAzienda = lstvDatiBuoni.Items(i).SubItems(5).Text
               .Descrizione = lstvDatiBuoni.Items(i).SubItems(2).Text
               .ValoreUnitario = lstvDatiBuoni.Items(i).SubItems(3).Text
               .Quantità = lstvDatiBuoni.Items(i).SubItems(6).Text
               .ValoreTotale = lstvDatiBuoni.Items(i).SubItems(7).Text
               .QuantitàFatt = lstvDatiBuoni.Items(i).SubItems(8).Text
               .ValoreFatt = lstvDatiBuoni.Items(i).SubItems(9).Text

               Dim IdBuono As Integer = Convert.ToInt32(lstvDatiBuoni.Items(i).SubItems(4).Text)
               .ModificaDati(TAB_BUONI_PASTO, IdBuono)
            Next
         End With

         ' Salva i dati per la gestione della fatturazione.
         Dim CBuoniPastoFatt As New BuoniFatt
         With CBuoniPastoFatt
            Dim i As Integer
            For i = 0 To lstvDatiBuoni.Items.Count - 1
               .IdBuono = lstvDatiBuoni.Items(i).SubItems(4).Text
               .IdDoc = LeggiUltimoDocCreato(TAB_DOC)
               .NumDoc = Doc.Numero
               .DataDoc = Doc.Data
               .Quantità = lstvDatiBuoni.Items(i).SubItems(1).Text
               .Descrizione = lstvDatiBuoni.Items(i).SubItems(2).Text
               .ValoreUnitario = lstvDatiBuoni.Items(i).SubItems(3).Text
               Dim val As Double = Convert.ToDouble(lstvDatiBuoni.Items(i).SubItems(1).Text * lstvDatiBuoni.Items(i).SubItems(3).Text)
               .ValoreTotale = val.ToString

               .InserisciDati(TAB_BUONI_PASTO_FATT)
            Next
         End With

      Catch ex As NullReferenceException
         ' Visualizza un messaggio.
         MessageBox.Show("Selezionare un elemento dalla lista.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End Try
   End Sub

   Private Sub FormattaControlloAttivo(ByVal controllo As Control)
      Try
         If controllo Is Nothing Then
            Exit Sub
         End If

         If formatta = True Then
            Dim perc As Integer = controllo.Text.IndexOf("%")

            If IsNumeric(controllo.Text) Then
               controllo.Text = CFormatta.FormattaEuro(controllo.Text)

            ElseIf perc <> -1 Then
               Dim val As String = controllo.Text.Replace("%", "")
               controllo.Text = CFormatta.FormattaEuro(val) & "%"

            Else
               controllo.Text = VALORE_ZERO
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Function ImpostaNomeStampante(ByVal indice As Integer) As String
      Try
         Dim val() As String = PercorsiStampantiDocumenti(indice).Split(";")

         If val(1) <> "Nessuna" Then
            Return val(1)
         Else
            Return String.Empty
         End If

      Catch ex As NullReferenceException
         MessageBox.Show("Non è possibile effettuare l'operazione! Verificare nei percorsi di stampa della finestra Opzioni che siano impostate le stampanti.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Exit Function

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Function ImpostaNomeDoc(ByVal indice As Integer) As String
      Try
         Dim val() As String = PercorsiStampantiDocumenti(indice).Split(";")

         If val(2) <> String.Empty Then
            Return val(2)
         Else
            Return String.Empty
         End If

      Catch ex As NullReferenceException
         MessageBox.Show("Non è possibile effettuare l'operazione! Verificare nei percorsi di stampa della finestra Opzioni che siano impostati i reports.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         Exit Function

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Private Sub ContoPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      CaricaListaConto()

      ImpostaValoriConto()

      Select Case tipoConto
         Case g_frmPos.Documento.Conto
            CalcolaContoUnico(1, CFormatta.FormattaNumeroDouble(txtDaPagare.Text))

            ' Legge i dati del cliente.
            LeggiDatiCliente(TAB_CONTI_TAVOLI, idTavoloDoc)

            Exit Sub

         Case g_frmPos.Documento.Proforma
            cmdProforma.PerformClick()

         Case g_frmPos.Documento.Scontrino
            txtContanti.Text = txtDaPagare.Text
            cmdScontrino.PerformClick()
      End Select
   End Sub

   Private Sub DigitaNumeri(ByVal ctrl As Control, ByVal sndr As Object)
      Try
         If ctrl Is Nothing = False Then
            formatta = False

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

   Private Function LeggiNumeroMax(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         'cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0} WHERE TipoDoc = '{1}'", tabella, tipoDoc)

         ' Ottiene i dati per l'anno corrente.
         Dim Anno As String = Year(Now)
         Dim primoGiornoAnno As String = CFormatta.FormattaData("01/01/" & Anno)
         Dim numUltimoGiornoAnno As String = DateTime.DaysInMonth(Anno, 12)
         Dim ultimoGiornoAnno As String = CFormatta.FormattaData(numUltimoGiornoAnno & "/12/" & Anno)

         cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0} WHERE TipoDoc = '{1}' AND DataDoc BETWEEN #{2}# AND #{3}#", tabella, tipoDoc, primoGiornoAnno, ultimoGiornoAnno)

         If IsDBNull(cmd.ExecuteScalar()) = False Then
            numRec = CInt(cmd.ExecuteScalar())
         Else
            numRec = 0
         End If

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function LeggiUltimoDocCreato(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT MAX(Id) FROM {0}", tabella)
         If IsDBNull(cmd.ExecuteScalar()) = False Then
            numRec = CInt(cmd.ExecuteScalar())
         Else
            numRec = 0
         End If

         Return numRec

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Sub cmdEsci_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEsci.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ' Se il conto è stato aperto per un tavolo salva i dati del cliente.
      If idTavoloDoc <> String.Empty Then
         SalvaDatiClienti()
      End If

      ' Esce, chiude il form senza stampare il conto.
      Me.DialogResult = DialogResult.Abort
      Me.Close()
   End Sub

   Private Sub cmdRicevuta_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRicevuta.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If g_frmPos.nomeTavolo <> String.Empty And g_frmPos.nomeTavolo <> "Tavoli" Then
            mantieniDatiTavolo = False
         Else
            mantieniDatiTavolo = True
         End If

         tipoDocumento = TIPO_DOC_RF

         If ImpostaNomeDoc(0) <> String.Empty Then
            percorsoRep = "\Reports\" & ImpostaNomeDoc(0)
         Else
            percorsoRep = PERCORSO_REP_RF
         End If

         ' B_TODO: Modifica per Retail.
         If txtSospeso.Text <> VALORE_ZERO Then
            If VerificaIntestazione() = False Then
               Exit Sub
            End If
         End If

         If VerificaCartaCredito() = True Then
            StampaConto(ImpostaNomeStampante(0))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdFattura_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFattura.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If g_frmPos.nomeTavolo <> String.Empty And g_frmPos.nomeTavolo <> "Tavoli" Then
            mantieniDatiTavolo = False
         Else
            mantieniDatiTavolo = True
         End If

         tipoDocumento = TIPO_DOC_FF

         If ImpostaNomeDoc(1) <> String.Empty Then
            'MessageBox.Show("imposto" & ImpostaNomeDoc(1))
            percorsoRep = "\Reports\" & ImpostaNomeDoc(1)
         Else
            'MessageBox.Show("predefinito")
            percorsoRep = PERCORSO_REP_FF
         End If

         If VerificaIntestazione() = True Then
            If VerificaCartaCredito() = True Then
               StampaConto(ImpostaNomeStampante(1))
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdProforma_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdProforma.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If g_frmPos.nomeTavolo <> String.Empty And g_frmPos.nomeTavolo <> "Tavoli" Then
            Dim risposta As Integer
            risposta = MessageBox.Show("Si desidera mantenere ancora i dati del conto sul Tavolo?", _
                                       NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If risposta = DialogResult.Yes Then
               mantieniDatiTavolo = True
            Else
               mantieniDatiTavolo = False
            End If
         Else
            mantieniDatiTavolo = True
         End If

         tipoDocumento = TIPO_DOC_PF

         If ImpostaNomeDoc(2) <> String.Empty Then
            percorsoRep = "\Reports\" & ImpostaNomeDoc(2)
         Else
            percorsoRep = PERCORSO_REP_PF
         End If

         If VerificaCartaCredito() = True Then
            StampaConto(ImpostaNomeStampante(2))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdScontrino_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdScontrino.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If ImpostaNomeStampante(3) = String.Empty Then
            g_frmPos.InfoScontrino()
            Exit Sub
         End If

         If g_frmPos.nomeTavolo <> String.Empty And g_frmPos.nomeTavolo <> "Tavoli" Then
            mantieniDatiTavolo = False
         Else
            mantieniDatiTavolo = True
         End If

         tipoDocumento = TIPO_DOC_SF

         If ImpostaNomeDoc(3) <> String.Empty Then
            percorsoRep = "\Reports\" & ImpostaNomeDoc(3)
         Else
            percorsoRep = PERCORSO_REP_SF
         End If

         '' B_TODO: Modifica per Retail.
         'If txtSospeso.Text <> VALORE_ZERO Then
         '   If VerificaIntestazione() = False Then
         '      Exit Sub
         '   End If
         'End If

         If VerificaCartaCredito() = True Then
            StampaConto(ImpostaNomeStampante(3))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdTipoPagamento_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTipoPagamento.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New Pagamenti
         If frm.ShowDialog() = DialogResult.OK Then
            cmdTipoPagamento.Text = frm.Tag
         End If

         cmdOk.PerformClick()

         txtCartaCredito.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdContanti_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdContanti.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New Contanti
         If frm.ShowDialog() = DialogResult.OK Then
            txtContanti.Text = frm.Tag
         End If

         cmdOk.PerformClick()

         txtContanti.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdBuoni_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuoni.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New frmElencoBuoniPos
         If frm.ShowDialog() = DialogResult.OK Then
            txtBuoni.Text = frm.Tag
         End If

         cmdOk.PerformClick()

         txtBuoni.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      Try
         If DateTime.Now.Minute.ToString.Length = 1 Then
            Me.Text = "STAMPA CONTO - Data: " & dtpData.Text & " - Ora: " & DateTime.Now.Hour & "." & "0" & DateTime.Now.Minute
         Else
            Me.Text = "STAMPA CONTO - Data: " & dtpData.Text & " - Ora: " & DateTime.Now.Hour & "." & DateTime.Now.Minute
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub txtCap_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCap.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtPIva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPIva.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtIva_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIva.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtValSconto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtValSconto.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
      If CConvalida.KeyReturn(e.KeyChar) = True Then
         cmdOk.PerformClick()
      End If
   End Sub

   Private Sub txtServizio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServizio.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
      If CConvalida.KeyReturn(e.KeyChar) = True Then
         cmdOk.PerformClick()
      End If
   End Sub

   Private Sub txtContanti_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContanti.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
      If CConvalida.KeyReturn(e.KeyChar) = True Then
         cmdOk.PerformClick()
      End If
   End Sub

   Private Sub txtCartaCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCartaCredito.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
      If CConvalida.KeyReturn(e.KeyChar) = True Then
         cmdOk.PerformClick()
      End If
   End Sub

   Private Sub cmdCancella_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancella.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

      ImpostaValoriConto()
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

   Private Sub cmdC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdC.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         If IsNothing(controlloAttivo) = False Then
            formatta = False
            controlloAttivo.Text = ""
            controlloAttivo.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub txtValSconto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtValSconto.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = True
   End Sub

   Private Sub txtTotaleConto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTotaleConto.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub cmdCancella_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancella.GotFocus
      controlloAttivo = Nothing
   End Sub

   Private Sub cmdDettagliGiù_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDettagliGiù.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub cmdDettagliSu_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdDettagliSu.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub lstvDettagli_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvDettagli.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub cmdContanti_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdContanti.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub cmdTipoPagamento_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdTipoPagamento.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub cmdBuoni_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBuoni.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub txtDaPagare_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDaPagare.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub txtResto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResto.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub cmdNum0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum0.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub txtServizio_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServizio.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = True
   End Sub

   Private Sub txtPIva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPIva.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = False
   End Sub

   Private Sub txtProv_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtProv.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = False
   End Sub

   Private Sub txtContanti_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtContanti.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = True
   End Sub

   Private Sub txtCartaCredito_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCartaCredito.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = True
   End Sub

   Private Sub txtBuoni_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBuoni.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = True
   End Sub

   Private Sub txtSospeso_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSospeso.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub txtIndirizzo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIndirizzo.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = False
   End Sub

   Private Sub txtIva_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtIva.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = True
   End Sub

   Private Sub txtCap_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCap.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = False
   End Sub

   Private Sub txtCittà_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCittà.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = False
   End Sub

   Private Sub cmdNum7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum7.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)


      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub cmdNum8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum8.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub cmdNum9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum9.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub cmdNum4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum4.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub cmdNum5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum5.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub cmdNum6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum6.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub cmdNum1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum1.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub cmdNum2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum2.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub cmdNum3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum3.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub cmdVirgola_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdVirgola.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         ' Verifica la presenza della virgola.
         formatta = False

         If controlloAttivo.Text = "" Then
            controlloAttivo.Focus()
            Exit Sub
         Else
            Dim virgola As Integer = controlloAttivo.Text.IndexOf(sender.Text)

            If virgola <> -1 Then
               controlloAttivo.Focus()
               Exit Sub
            Else
               DigitaNumeri(controlloAttivo, sender)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdNum00_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNum00.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      DigitaNumeri(controlloAttivo, sender)
   End Sub

   Private Sub cmdX_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdX.Click
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

      moltiplica = True
   End Sub

   Private Sub cmdOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOk.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

         If controlloAttivo Is Nothing = False Then
            If controlloAttivo.Text = "" Then
               controlloAttivo.Text = VALORE_ZERO
            End If
         End If

         ' Moltiplicazione su una TextBox.
         If moltiplica = True Then
            controlloAttivo.Text = CFormatta.FormattaNumeroDouble(op1 * op2)
            op1 = 0.0
            op2 = 0.0
            moltiplica = False
         End If

         ' Somma il totale da pagare.
         Dim valTotConto As Double
         Dim valCoperto As Double
         Dim sconto As Double
         Dim servizio As Double

         If cmdTipoConto.Text = "SEPARATO MANUALE" Then
            If lstvElencoDocAperti.Items.Count <> 0 Then
               lstvElencoDocAperti.Focus()
               valTotConto = Convert.ToDouble(lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(2).Text)
            End If
         Else
            valTotConto = Convert.ToDouble(txtTotaleConto.Text)
         End If

         ' Calcola il valore del coperto.
         valCoperto = Convert.ToDouble(txtCoperto.Text)

         If cmdTipoConto.Text <> "SEPARATO MANUALE" Then
            ' Calcola il valore da pagare + il coperto.
            valTotConto = (valTotConto + valCoperto)
         End If

         ' Calcola il valore del servizio.
         Dim percServizio As Integer = txtServizio.Text.IndexOf("%")
         If percServizio <> -1 Then
            servizio = Convert.ToDouble(txtServizio.Text.Remove(txtServizio.Text.Length - 1, 1))
            valServizio = CalcolaPercentuale(valTotConto, servizio)
         Else
            valServizio = Convert.ToDouble(txtServizio.Text)
         End If

         ' Calcola il valore da pagare + il servizio.
         valTotConto = (valTotConto + valServizio)

         ' Calcola il valore dello sconto.
         Dim percSconto As Integer = txtValSconto.Text.IndexOf("%")
         If percSconto <> -1 Then
            sconto = Convert.ToDouble(txtValSconto.Text.Remove(txtValSconto.Text.Length - 1, 1))
            valSconto = CalcolaPercentuale(valTotConto, sconto)
         Else
            valSconto = Convert.ToDouble(txtValSconto.Text)
         End If

         ' Calcola il valore da pagare..
         Dim valDaPagare As Double = (valTotConto - valSconto)
         txtDaPagare.Text = CFormatta.FormattaEuro(valDaPagare)

         Select Case cmdTipoConto.Text
            Case "UNICO"
               CalcolaContoUnico(1, CFormatta.FormattaNumeroDouble(txtDaPagare.Text))
               CaricaListaConto()

            Case "SEPARATO MANUALE"
               'CalcolaContoSeparatoManuale(Convert.ToInt32(txtNumDoc.Text), Convert.ToDouble(txtDaPagare.Text))
               'CaricaListaContoSeparatoManuale()

            Case "ALLA ROMANA"
               CalcolaContoAllaRomana(Convert.ToInt32(txtNumDoc.Text), Convert.ToDouble(txtDaPagare.Text))
               CaricaListaContoRigaUnica()

         End Select

         valDaPagare = Convert.ToDouble(txtDaPagare.Text)

         ' Calcola il sospeso e il resto.
         Dim valContanti As Double = Convert.ToDouble(txtContanti.Text)
         Dim valPagamento As Double = Convert.ToDouble(txtCartaCredito.Text)
         Dim valBuoni As Double = Convert.ToDouble(txtBuoni.Text)
         Dim valPagato As Double = valContanti + valPagamento + valBuoni
         Dim valSospeso As Double = Convert.ToDouble(txtSospeso.Text)
         Dim valResto As Double

         If cCredito = True Then
            If valPagamento >= valDaPagare Then
               valContanti = 0.0
               valBuoni = 0.0
            Else
               valContanti = valDaPagare - valPagamento
            End If
            valPagato = valContanti + valPagamento
            txtContanti.Text = CFormatta.FormattaNumeroDouble(valContanti)
            cCredito = False
         End If

         ' Sospeso.
         If valPagato >= valDaPagare Then
            valSospeso = 0.0
         Else
            valSospeso = valDaPagare - valPagato
         End If

         ' Resto.
         If valPagato <= valDaPagare Then
            valResto = 0.0
         Else
            valResto = valPagato - valDaPagare
         End If

         txtSospeso.Text = CFormatta.FormattaNumeroDouble(valSospeso)
         txtResto.Text = CFormatta.FormattaNumeroDouble(valResto)

         ' Restituisce lo stato attivo al pulsante OK.
         sender.focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdPercentuale_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPercentuale.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         formatta = False

         Select Case controlloAttivo.Name
            Case "txtValSconto", "txtServizio"

               If controlloAttivo.Text = "" Then
                  controlloAttivo.Focus()
                  Exit Sub
               Else
                  Dim perc As Integer = controlloAttivo.Text.IndexOf(sender.Text)

                  If perc <> -1 Then
                     controlloAttivo.Focus()
                     Exit Sub
                  Else
                     controlloAttivo.Text = controlloAttivo.Text & sender.Text
                     controlloAttivo.Focus()
                  End If
               End If

            Case Else
               controlloAttivo.Focus()
               Exit Sub
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdOk_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdOk.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      formatta = False
   End Sub

   Private Sub txtCartaCredito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCartaCredito.TextChanged
      cCredito = True
   End Sub

   Private Sub ContoPos_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      ' Distrugge l'oggetto e libera le risorse.
      g_frmContoPos.Dispose()
      g_frmContoPos = Nothing

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTO, MODULO_CONTO)
   End Sub

   Private Sub txtCoperto_GotFocus(sender As Object, e As System.EventArgs) Handles txtCoperto.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = True
   End Sub

   Private Sub txtCoperto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCoperto.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
      If CConvalida.KeyReturn(e.KeyChar) = True Then
         cmdOk.PerformClick()
      End If
   End Sub

   Private Sub cmdTipoConto_Click(sender As System.Object, e As System.EventArgs) Handles cmdTipoConto.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New TipoContoPos
         If frm.ShowDialog() = DialogResult.OK Then
            cmdTipoConto.Text = frm.Tag

            Select Case cmdTipoConto.Text
               Case "UNICO"
                  lblQuotaPersona.Visible = True
                  txtQuotaPersona.Visible = True
                  cmdDivisioneAnalitica.Visible = False

                  cmdOk.PerformClick()

               Case "SEPARATO MANUALE"
                  lblQuotaPersona.Visible = False
                  txtQuotaPersona.Visible = False
                  cmdDivisioneAnalitica.Visible = True
                  txtTotDividere.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(txtDaPagare.Text))

                  txtNumDoc.Enabled = True
                  txtNumDoc.BackColor = Color.White
                  txtNumDoc.Text = "2"

                  cmdTipoElenco.Text = "ELENCO COMPLETO"

                  lstvElencoDocAperti.Items.Clear()
                  lstvDettagli.Items.Clear()

               Case "ALLA ROMANA"
                  lblQuotaPersona.Visible = True
                  txtQuotaPersona.Visible = True
                  cmdDivisioneAnalitica.Visible = False

                  txtNumDoc.Text = "2"

                  cmdOk.PerformClick()
            End Select
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Public Sub CalcolaContoUnico(ByVal numDoc As Integer, ByVal daPagare As String)
      Try
         txtNumDoc.Enabled = False
         txtNumDoc.BackColor = Color.DarkGray

         txtNumDoc.Text = numDoc.ToString
         txtTotDividere.Text = daPagare
         txtQuotaPersona.Text = daPagare
         txtDaPagare.Text = daPagare

         lstvElencoDocAperti.Items.Clear()

         Dim i As Integer
         For i = 0 To numDoc - 1
            ' Indice
            lstvElencoDocAperti.Items.Add(i).BackColor = Color.LightSalmon

            ' Stato.
            lstvElencoDocAperti.Items(i).SubItems.Add("Aperto")

            ' Da pagare.
            lstvElencoDocAperti.Items(i).SubItems.Add(daPagare)
         Next

         cmdTipoElenco.Text = "ELENCO COMPLETO"

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub CalcolaContoAllaRomana(ByVal numDoc As Integer, ByVal daPagare As Double)
      Try
         txtNumDoc.Enabled = True
         txtNumDoc.BackColor = Color.White

         txtNumDoc.Text = numDoc.ToString
         txtTotDividere.Text = CFormatta.FormattaNumeroDouble(daPagare)

         Dim quotaPersona As Double = daPagare / numDoc
         txtQuotaPersona.Text = CFormatta.FormattaNumeroDouble(quotaPersona)

         txtDaPagare.Text = txtQuotaPersona.Text

         If stampaDocInCorso = False Then
            lstvElencoDocAperti.Items.Clear()

            Dim i As Integer
            For i = 0 To numDoc - 1
               ' Indice
               lstvElencoDocAperti.Items.Add(i).BackColor = Color.LightSalmon

               ' Stato.
               lstvElencoDocAperti.Items(i).SubItems.Add("Aperto")

               ' Da pagare.
               lstvElencoDocAperti.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(quotaPersona))
            Next
         End If

         cmdTipoElenco.Text = "RIGA UNICA"

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub cmdTipoElenco_Click(sender As System.Object, e As System.EventArgs) Handles cmdTipoElenco.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New TipoElencoPos(cmdTipoConto.Text)
         If frm.ShowDialog() = DialogResult.OK Then
            cmdTipoElenco.Text = frm.Tag

            Select Case cmdTipoElenco.Text
               Case "ELENCO COMPLETO"
                  If cmdTipoConto.Text = "SEPARATO MANUALE" Then
                     lstvElencoDocAperti.Focus()
                     LeggiDatiConto(lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(3).Text)
                  Else
                     CaricaListaConto()
                  End If

               Case "ELENCO COMPATTO"
                  CompattaElencoConto()

               Case "RIGA UNICA"
                  CaricaListaContoRigaUnica()

            End Select
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Public Sub CaricaListaContoSeparatoManuale()
      Try
         lstvElencoDocAperti.Focus()
         txtDaPagare.Text = lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(2).Text
         LeggiDatiConto(lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(3).Text)

         Select Case cmdTipoElenco.Text
            Case "ELENCO COMPATTO"
               CompattaElencoConto()

            Case "RIGA UNICA"
               CaricaListaContoRigaUnica()
         End Select

         cmdOk.PerformClick()

      Catch ex As NullReferenceException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub CaricaListaContoRigaUnica()
      Try
         lstvDettagli.Items.Clear()

         ' Indice
         lstvDettagli.Items.Add(0)

         ' Quantità
         lstvDettagli.Items(0).SubItems.Add("1")

         ' Descrizione.
         lstvDettagli.Items(0).SubItems.Add(LeggiTestoRigaUnicaConfig)

         ' Importo.
         If lstvElencoDocAperti.Items.Count <> 0 Then
            lstvElencoDocAperti.Focus()
            lstvDettagli.Items(0).SubItems.Add(lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(2))
         Else
            lstvDettagli.Items(0).SubItems.Add(String.Empty)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Function LeggiTestoRigaUnicaConfig() As String
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim TestoRigaUnica As String

         If DatiConfig.GetValue("TestoRigaUnica") <> String.Empty Then
            TestoRigaUnica = DatiConfig.GetValue("TestoRigaUnica")
         Else
            TestoRigaUnica = "Quota alla romana"
         End If

         Return TestoRigaUnica

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return "Quota alla romana"

      End Try
   End Function

   Private Sub cmdDocApertiGiù_Click(sender As System.Object, e As System.EventArgs) Handles cmdDocApertiGiù.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvElencoDocAperti.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvElencoDocAperti.TopItem.Index

         IndiceLista = PrimoElemento + NumElementi

         If IndiceLista > lstvElencoDocAperti.Items.Count - 1 Then
            Exit Sub
         Else
            lstvElencoDocAperti.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdDocApertiSu_Click(sender As System.Object, e As System.EventArgs) Handles cmdDocApertiSu.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If lstvElencoDocAperti.Items.Count = 0 Then
            Return
         End If

         PrimoElemento = lstvElencoDocAperti.TopItem.Index

         IndiceLista = PrimoElemento - 1

         If IndiceLista < 0 Then
            Exit Sub
         Else
            lstvElencoDocAperti.Items(IndiceLista).EnsureVisible()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub cmdDivisioneAnalitica_Click(sender As System.Object, e As System.EventArgs) Handles cmdDivisioneAnalitica.Click
      If IsNumeric(txtNumDoc.Text) = True Then

         CaricaListaConto()

         If Convert.ToInt32(txtNumDoc.Text) > 1 And Convert.ToInt32(txtNumDoc.Text) < 26 Then
            Dim numCoperti As Integer
            If idTavoloDoc <> String.Empty Then ' If IsNothing(g_frmVCTavoli) = False Then
               numCoperti = Convert.ToInt32(g_frmVCTavoli.lblCoperti.Text)
            Else
               numCoperti = 0
            End If

            Dim frm As New DivisioneContoPOS(Convert.ToInt32(txtNumDoc.Text), numCoperti)
            If frm.ShowDialog() = DialogResult.OK Then
               ' Comando Conferma.
               If lstvElencoDocAperti.Items.Count <> 0 Then
                  lstvElencoDocAperti.FocusedItem = lstvElencoDocAperti.Items(0)
                  CaricaListaContoSeparatoManuale()
                  Exit Sub
               End If
            Else
               ' Comando Annulla.
               If lstvElencoDocAperti.Items.Count <> 0 Then
                  lstvElencoDocAperti.FocusedItem = lstvElencoDocAperti.Items(0)
                  CaricaListaContoSeparatoManuale()
                  Exit Sub
               Else
                  lstvDettagli.Items.Clear()
               End If
            End If
         Else
            MessageBox.Show("Inserire il numero dei documenti. Un valore compreso da 2 a 25.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If
      Else
         MessageBox.Show("Inserire il numero dei documenti.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If
   End Sub

   Private Sub txtNumDoc_GotFocus(sender As Object, e As System.EventArgs) Handles txtNumDoc.GotFocus
      controlloAttivo = sender
   End Sub

   Private Sub txtNumDoc_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumDoc.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
         If CConvalida.KeyReturn(e.KeyChar) = True Then

            If txtNumDoc.Text = String.Empty Then
               Exit Sub
            End If

            If Convert.ToInt32(txtNumDoc.Text) < 2 Then
               Exit Sub
            End If

            cmdOk.PerformClick()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Function SalvaDatiClienti() As Boolean
      Try
         With AContiTavoli
            ' Assegna i dati dei campi della classe alle caselle di testo.
            .CodiceTavolo = idTavoloDoc
            .CodiceCliente = txtIdCliente.Text
            .CodiceAzienda = txtIdAzienda.Text
            .Intestatario = cmdCliente.Text
            .Indirizzo = FormattaApici(txtIndirizzo.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .PIva = FormattaApici(txtPIva.Text)
            If IsNumeric(txtValSconto.Text) = True Then
               .Sconto = txtValSconto.Text
            Else
               .Sconto = VALORE_ZERO
            End If
            If IsNumeric(txtIva.Text) = True Then
               .Iva = txtIva.Text
            Else
               .Iva = VALORE_ZERO
            End If

            If VerificaEsistenzaValore(TAB_CONTI_TAVOLI, cn, cmd, "IdTavolo", idTavoloDoc) <> 0 Then
               Return .ModificaDati(TAB_CONTI_TAVOLI, idTavoloDoc)
            Else
               Return .InserisciDati(TAB_CONTI_TAVOLI)
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Function

   Public Sub LeggiDatiConto(ByVal nomeConto As String)
      Try
         Const QTA As String = "1"

         lstvDettagli.Items.Clear()
         lstvDettagliCopia.Items.Clear()

         Dim i As Integer
         For i = 1 To qtàPiatti
            If DatiConto(i).NomeConto = nomeConto Then

               ' Indice
               lstvDettagli.Items.Add(lstvDettagli.Items.Count)
               lstvDettagliCopia.Items.Add(lstvDettagliCopia.Items.Count)

               ' Quantità
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(QTA)
               lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(QTA)

               ' Descrizione.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(DatiConto(i).Descrizione)
               lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(DatiConto(i).Descrizione)

               ' Importo.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(DatiConto(i).Importo)
               lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(DatiConto(i).Importo)

               ' Prezzo.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(DatiConto(i).Prezzo)
               lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(DatiConto(i).Prezzo)

               ' Id Piatto.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(DatiConto(i).IdPiatto)
               lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(DatiConto(i).IdPiatto)

               ' Categoria.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
               lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add("")

            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CompattaElencoConto()
      Try
         Dim Importo1 As Double
         Dim idPiatto1 As String
         Dim numElementiUguali As Integer = 0
         Dim quantitàTotale As Integer = 0

         ' Salvo i dati della lista dettagli in una lista temporanea.
         lstvDettagliTemp.Items.Clear()
         Dim z As Integer
         For z = 0 To lstvDettagliCopia.Items.Count - 1
            ' Indice.
            lstvDettagliTemp.Items.Add(lstvDettagliTemp.Items.Count)
            ' Quantità.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(z).SubItems(1).Text)
            ' Descrizione.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(z).SubItems(2).Text)
            ' Importo.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(z).SubItems(3).Text)
            ' Prezzo.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(z).SubItems(4).Text)
            ' Id Piatto.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(z).SubItems(5).Text)
            ' Categoria.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add("")
         Next

         ' Leggo i dati della lista Dettagli e li confronto con la lista temporanea.
         Dim i As Integer
         For i = 0 To lstvDettagliCopia.Items.Count - 1

            ' Leggo i singoli dati.
            Importo1 = lstvDettagliCopia.Items(i).SubItems(4).Text
            idPiatto1 = lstvDettagliCopia.Items(i).SubItems(5).Text

            ' Numero di elementi da rimuovere dalla lista temporanea.
            Dim elementiDaRimuovere(500) As Integer

            Dim y As Integer = 0
            For y = 0 To lstvDettagliTemp.Items.Count - 1
               Dim quantità2 As Integer
               Dim idPiatto2 As String

               ' Leggo i singoli dati.
               quantità2 = lstvDettagliTemp.Items(y).SubItems(1).Text
               idPiatto2 = lstvDettagliTemp.Items(y).SubItems(5).Text

               ' Confronto quante volte i dati della lista dettagli sono presenti nella lista temporanea.
               If idPiatto1 = idPiatto2 Then
                  numElementiUguali += 1
                  elementiDaRimuovere(numElementiUguali) = y
                  quantitàTotale = quantitàTotale + quantità2
               End If
            Next

            ' Se ho trovato degli elementi uguali li rimuovo dalla lista temporanea e li elaboro inserendoli nella lista Compatto.
            If numElementiUguali <> 0 Then
               Dim n As Integer = 0
               For n = numElementiUguali To 1 Step -1
                  lstvDettagliTemp.Items.Remove(lstvDettagliTemp.Items(elementiDaRimuovere(n)))
               Next

               ' Calcolo il nuovo importo in base alle quantità.
               Dim Importo3 As Double
               Importo3 = Importo1 * quantitàTotale

               ' Inserisco i nuovi dati nella lista Compatto.
               ' Indice.
               lstvDettagliCompatto.Items.Add(lstvDettagliCompatto.Items.Count)
               ' Quantità.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(quantitàTotale)
               'End If
               ' Descrizione.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(i).SubItems(2).Text)
               ' Importo.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(Importo3))
               ' Prezzo.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(i).SubItems(4).Text)
               ' Id Piatto.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(i).SubItems(5).Text)
               ' Categoria.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add("")

               numElementiUguali = 0
               quantitàTotale = 0

            End If
         Next i

         ' Svuoto la lista dettagli.
         lstvDettagli.Items.Clear()

         ' Carico la lista dettagli con tutti gli elementi compattati.
         Dim k As Integer
         For k = 0 To lstvDettagliCompatto.Items.Count - 1
            ' Indice.
            lstvDettagli.Items.Add(lstvDettagli.Items.Count)
            ' Quantità.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(lstvDettagliCompatto.Items(k).SubItems(1).Text)
            ' Descrizione.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(lstvDettagliCompatto.Items(k).SubItems(2).Text)
            ' Importo.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(lstvDettagliCompatto.Items(k).SubItems(3).Text)
            ' Prezzo.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(lstvDettagliCompatto.Items(k).SubItems(4).Text)
            ' Id Piatto.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(lstvDettagliCompatto.Items(k).SubItems(5).Text)
            ' Categoria.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add("")
         Next k

         ' Svuoto la lista compatto.
         lstvDettagliCompatto.Items.Clear()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lstvElencoDocAperti_Resize(sender As Object, e As System.EventArgs) Handles lstvElencoDocAperti.Resize
      Try
         NumElementi = (lstvElencoDocAperti.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lstvElencoDocAperti_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstvElencoDocAperti.SelectedIndexChanged
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         If cmdTipoConto.Text = "SEPARATO MANUALE" Then
            If lstvElencoDocAperti.Focused = True Then
               CaricaListaContoSeparatoManuale()
            End If
         End If

      Catch ex As NullReferenceException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lstvDettagli_Resize(sender As Object, e As System.EventArgs) Handles lstvDettagli.Resize
      Try
         NumElementi = (lstvDettagli.Height) / ALTEZZA_RIGA_DETTAGLI

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub lstvDettagli_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles lstvDettagli.SelectedIndexChanged
      ' Riproduce un effetto sonoro.
      RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

   End Sub

   Private Sub cmdCliente_Click(sender As System.Object, e As System.EventArgs) Handles cmdCliente.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New ElencoClientiPos(txtIdCliente.Text, txtIdAzienda.Text)

         frm.Tag = "CONTO"

         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtIva_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtIva.TextChanged

   End Sub

   Private Sub txtCap_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCap.TextChanged

   End Sub

   Public Sub LeggiDatiCliente(ByVal tabella As String, ByVal idTavolo As String)
      Try
         ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnStringAnagrafiche)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE IdTavolo = '" & idTavolo & "'", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         CancellaDatiCliente()

         Do While dr.Read
            If IsDBNull(dr.Item("Intestatario")) = False Then
               cmdCliente.Text = dr.Item("Intestatario")
            Else
               cmdCliente.Text = "SELEZIONA CLIENTE"
            End If

            If IsDBNull(dr.Item("IdCliente")) = False Then
               txtIdCliente.Text = dr.Item("IdCliente")
            Else
               txtIdCliente.Text = "0"
            End If
            If IsDBNull(dr.Item("IdAzienda")) = False Then
               txtIdAzienda.Text = dr.Item("IdAzienda")
            Else
               txtIdAzienda.Text = "0"
            End If
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               txtIndirizzo.Text = dr.Item("Indirizzo")
            Else
               txtIndirizzo.Text = ""
            End If
            If IsDBNull(dr.Item("Cap")) = False Then
               txtCap.Text = dr.Item("Cap")
            Else
               txtCap.Text = ""
            End If
            If IsDBNull(dr.Item("Città")) = False Then
               txtCittà.Text = dr.Item("Città")
            Else
               txtCittà.Text = ""
            End If
            If IsDBNull(dr.Item("Provincia")) = False Then
               txtProv.Text = dr.Item("Provincia")
            Else
               txtProv.Text = ""
            End If
            If IsDBNull(dr.Item("PIva")) = False Then
               txtPIva.Text = dr.Item("PIva")
            Else
               txtPIva.Text = ""
            End If
            If IsDBNull(dr.Item("Iva")) = False Then
               txtIva.Text = CFormatta.FormattaNumeroDouble(dr.Item("Iva"))
            Else
               txtIva.Text = VALORE_ZERO
            End If
            If IsDBNull(dr.Item("Sconto")) = False Then
               txtValSconto.Text = CFormatta.FormattaNumeroDouble(dr.Item("Sconto"))
            Else
               txtValSconto.Text = VALORE_ZERO
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub cmdTastiera_Click(sender As System.Object, e As System.EventArgs) Handles cmdTastiera.Click
      ' Apre la Tastiera virtuale di Windows (XP, 7, 8).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

   Private Sub cmdAddebitoHotel_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddebitoHotel.Click
      MessageBox.Show("Non è possibile eseguire l'operazione! Il modulo Hotel non è installato.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

   End Sub
End Class
