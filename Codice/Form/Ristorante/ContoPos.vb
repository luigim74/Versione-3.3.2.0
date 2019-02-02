Imports System.IO
Imports System.Data.OleDb
Imports System.Drawing.Printing
Imports Softgroup.NetButton

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
   Const TAB_COMANDE As String = "Comande"
   Const TAB_PREN_CAMERE As String = "PrenCamere"
   Const TAB_PREN_CAMERE_ADDEBITI As String = "PrenCamereAddebiti"

   Const TIPO_DOC_RF As String = "Ricevuta Fiscale"
   Const TIPO_DOC_FF As String = "Fattura"
   Const TIPO_DOC_SF As String = "Scontrino"
   Const TIPO_DOC_PF As String = "Proforma"
   Const TIPO_DOC_CO As String = "Conto"

   Const ALTEZZA_RIGA_DETTAGLI As Short = 22

   Private AContiTavoli As New ContiTavoli

   Public percorsoRep As String = PERCORSO_REP_RF_A4_DOPPIA
   Public idCliente As String = String.Empty
   Public tipoDocumento As String = TIPO_DOC_RF

   Private Doc As New Documenti
   Private DettagliDoc As New DettagliDocumenti
   Dim DatiConfig As AppConfig
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
   Public nomeTavoloDoc As String
   Public nomeCameriereDoc As String
   Private totaleContoDaPagare As Double

   Public NumElementi As Integer = 0
   Public PrimoElemento As Integer = 0
   Public IndiceLista As Integer = 0

   ' Per la moltiplicazione.
   Private op1 As Double = 0
   Private op2 As Double = 0
   Public valSconto As Double
   Public valServizio As Double

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
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents lstvElencoDocAperti As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader18 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader19 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader20 As System.Windows.Forms.ColumnHeader
   Friend WithEvents Label18 As System.Windows.Forms.Label
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
   Friend WithEvents Timer2 As System.Windows.Forms.Timer
   Public WithEvents txtCodiceFiscale As TextBox
   Public WithEvents Label20 As Label
   Public WithEvents txtNome As TextBox
   Public WithEvents Label22 As Label
   Public WithEvents txtCognome As TextBox
   Public WithEvents Label21 As Label
   Friend WithEvents eui_cmdTipoElenco As Elegant.Ui.Button
   Friend WithEvents eui_cmdTipoConto As Elegant.Ui.Button
   Friend WithEvents eui_cmdCliente As Elegant.Ui.Button
   Friend WithEvents eui_cmdDivisioneAnalitica As Elegant.Ui.Button
   Friend WithEvents eui_cmdBuoni As Elegant.Ui.Button
   Friend WithEvents eui_cmdTipoPagamento As Elegant.Ui.Button
   Friend WithEvents eui_cmdContanti As Elegant.Ui.Button
   Friend WithEvents eui_cmdScontrino As Elegant.Ui.Button
   Friend WithEvents eui_cmdProforma As Elegant.Ui.Button
   Friend WithEvents eui_cmdFattura As Elegant.Ui.Button
   Friend WithEvents eui_cmdRicevuta As Elegant.Ui.Button
   Friend WithEvents eui_cmdEsci As Elegant.Ui.Button
   Friend WithEvents eui_AddebitoSuRisorsa As Elegant.Ui.Button
   Friend WithEvents netBtn_DaPagare As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_C As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_9 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_8 As Softgroup.NetButton.NetButton
   Friend WithEvents netBtn_7 As Softgroup.NetButton.NetButton
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
   Friend WithEvents eui_cmdCancella As Elegant.Ui.Button
   Friend WithEvents eui_cmdTastiera As Elegant.Ui.Button
   Friend WithEvents Button10 As Elegant.Ui.Button
   Friend WithEvents eui_cmdDettagliSu As Elegant.Ui.Button
   Friend WithEvents eui_cmdDettagliGiù As Elegant.Ui.Button
   Friend WithEvents eui_cmdDocApertiSu As Elegant.Ui.Button
   Friend WithEvents eui_cmdDocApertiGiù As Elegant.Ui.Button
   Friend WithEvents colonnaIva As ColumnHeader
   Friend WithEvents Panel1 As Panel
   Friend WithEvents eui_cmdParcheggiaConto As Elegant.Ui.Button
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
         idTavoloDoc = idTavolo.ToString
      Else
         idTavoloDoc = String.Empty
      End If

      ' Se il conto viene aperto da una prenotazione disattiva i pulsanti che non servono..
      If g_frmPos.netBtn_Conferma.Enabled = False And g_frmPos.netBtn_ContiParcheggiati.Enabled = False Then
         eui_cmdTipoConto.Enabled = False
         eui_cmdCliente.Enabled = False
         eui_cmdRicevuta.Enabled = False
         eui_cmdFattura.Enabled = False
         eui_cmdProforma.Enabled = False
         eui_cmdScontrino.Enabled = False
         eui_cmdParcheggiaConto.Enabled = False
         eui_cmdContanti.Enabled = False
         eui_cmdTipoPagamento.Enabled = False
         eui_cmdBuoni.Enabled = False
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
   Public WithEvents txtIndirizzo As System.Windows.Forms.TextBox
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents lstvDettagli As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents colonnaQta As System.Windows.Forms.ColumnHeader
   Friend WithEvents colonnaDescrizione As System.Windows.Forms.ColumnHeader
   Friend WithEvents colonnaImporto As System.Windows.Forms.ColumnHeader
   Friend WithEvents colonnaPrezzo As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Public WithEvents Label11 As System.Windows.Forms.Label
   Public WithEvents txtContanti As System.Windows.Forms.TextBox
   Public WithEvents txtCartaCredito As System.Windows.Forms.TextBox
   Public WithEvents txtTotaleConto As System.Windows.Forms.TextBox
   Public WithEvents txtValSconto As System.Windows.Forms.TextBox
   Public WithEvents txtServizio As System.Windows.Forms.TextBox
   Public WithEvents txtSospeso As System.Windows.Forms.TextBox
   Public WithEvents txtResto As System.Windows.Forms.TextBox
   Public WithEvents txtIva As System.Windows.Forms.TextBox
   Public WithEvents Timer1 As System.Windows.Forms.Timer
   Friend WithEvents dtpData As System.Windows.Forms.DateTimePicker
   Public WithEvents txtBuoni As System.Windows.Forms.TextBox
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
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
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
      Me.lstvDettagli = New System.Windows.Forms.ListView()
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaQta = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaDescrizione = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaPrezzo = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaImporto = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.colonnaIva = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.txtIva = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.dtpData = New System.Windows.Forms.DateTimePicker()
      Me.txtBuoni = New System.Windows.Forms.TextBox()
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
      Me.Label18 = New System.Windows.Forms.Label()
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
      Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
      Me.txtCodiceFiscale = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.txtCognome = New System.Windows.Forms.TextBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.txtNome = New System.Windows.Forms.TextBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.eui_cmdTipoConto = New Elegant.Ui.Button()
      Me.eui_cmdTipoElenco = New Elegant.Ui.Button()
      Me.eui_cmdCliente = New Elegant.Ui.Button()
      Me.eui_cmdDivisioneAnalitica = New Elegant.Ui.Button()
      Me.eui_cmdContanti = New Elegant.Ui.Button()
      Me.eui_cmdTipoPagamento = New Elegant.Ui.Button()
      Me.eui_cmdBuoni = New Elegant.Ui.Button()
      Me.eui_cmdRicevuta = New Elegant.Ui.Button()
      Me.eui_cmdFattura = New Elegant.Ui.Button()
      Me.eui_cmdProforma = New Elegant.Ui.Button()
      Me.eui_cmdScontrino = New Elegant.Ui.Button()
      Me.eui_AddebitoSuRisorsa = New Elegant.Ui.Button()
      Me.eui_cmdEsci = New Elegant.Ui.Button()
      Me.netBtn_DaPagare = New Softgroup.NetButton.NetButton()
      Me.netBtn_C = New Softgroup.NetButton.NetButton()
      Me.netBtn_9 = New Softgroup.NetButton.NetButton()
      Me.netBtn_8 = New Softgroup.NetButton.NetButton()
      Me.netBtn_7 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Ok = New Softgroup.NetButton.NetButton()
      Me.netBtn_Percentuale = New Softgroup.NetButton.NetButton()
      Me.netBtn_X = New Softgroup.NetButton.NetButton()
      Me.netBtn_00 = New Softgroup.NetButton.NetButton()
      Me.netBtn_0 = New Softgroup.NetButton.NetButton()
      Me.netBtn_Virgola = New Softgroup.NetButton.NetButton()
      Me.netBtn_3 = New Softgroup.NetButton.NetButton()
      Me.netBtn_2 = New Softgroup.NetButton.NetButton()
      Me.netBtn_1 = New Softgroup.NetButton.NetButton()
      Me.netBtn_6 = New Softgroup.NetButton.NetButton()
      Me.netBtn_5 = New Softgroup.NetButton.NetButton()
      Me.netBtn_4 = New Softgroup.NetButton.NetButton()
      Me.eui_cmdTastiera = New Elegant.Ui.Button()
      Me.eui_cmdCancella = New Elegant.Ui.Button()
      Me.eui_cmdDocApertiSu = New Elegant.Ui.Button()
      Me.eui_cmdDocApertiGiù = New Elegant.Ui.Button()
      Me.eui_cmdDettagliSu = New Elegant.Ui.Button()
      Me.eui_cmdDettagliGiù = New Elegant.Ui.Button()
      Me.Button10 = New Elegant.Ui.Button()
      Me.Panel1 = New System.Windows.Forms.Panel()
      Me.eui_cmdParcheggiaConto = New Elegant.Ui.Button()
      Me.Panel1.SuspendLayout()
      Me.SuspendLayout()
      '
      'txtProv
      '
      Me.txtProv.AcceptsReturn = True
      Me.txtProv.BackColor = System.Drawing.SystemColors.Window
      Me.txtProv.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtProv.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtProv.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtProv.Location = New System.Drawing.Point(259, 42)
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
      Me.txtCap.Location = New System.Drawing.Point(145, 42)
      Me.txtCap.MaxLength = 5
      Me.txtCap.Name = "txtCap"
      Me.txtCap.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCap.Size = New System.Drawing.Size(51, 29)
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
      Me.txtCittà.Location = New System.Drawing.Point(217, 42)
      Me.txtCittà.MaxLength = 100
      Me.txtCittà.Name = "txtCittà"
      Me.txtCittà.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCittà.Size = New System.Drawing.Size(36, 29)
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
      Me.txtIndirizzo.Location = New System.Drawing.Point(145, 2)
      Me.txtIndirizzo.MaxLength = 100
      Me.txtIndirizzo.Name = "txtIndirizzo"
      Me.txtIndirizzo.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIndirizzo.Size = New System.Drawing.Size(144, 29)
      Me.txtIndirizzo.TabIndex = 1
      Me.txtIndirizzo.Visible = False
      '
      'Label5
      '
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(8, 51)
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
      Me.Label4.Location = New System.Drawing.Point(8, 2)
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
      Me.Label3.Location = New System.Drawing.Point(623, 16)
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
      Me.txtPIva.Location = New System.Drawing.Point(145, 82)
      Me.txtPIva.MaxLength = 11
      Me.txtPIva.Name = "txtPIva"
      Me.txtPIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtPIva.Size = New System.Drawing.Size(51, 29)
      Me.txtPIva.TabIndex = 5
      Me.txtPIva.Visible = False
      '
      'Label31
      '
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(13, 86)
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
      'Label1
      '
      Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(623, 88)
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
      Me.Label2.Location = New System.Drawing.Point(623, 128)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(144, 18)
      Me.Label2.TabIndex = 189
      Me.Label2.Text = "SCONTO:"
      '
      'Label6
      '
      Me.Label6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(623, 208)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(144, 40)
      Me.Label6.TabIndex = 190
      Me.Label6.Text = "TOT. DA PAGARE:"
      '
      'Label7
      '
      Me.Label7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(623, 436)
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
      Me.Label9.Location = New System.Drawing.Point(623, 168)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(144, 16)
      Me.Label9.TabIndex = 195
      Me.Label9.Text = "SERVIZIO:"
      '
      'Label8
      '
      Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(623, 396)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(144, 16)
      Me.Label8.TabIndex = 196
      Me.Label8.Text = "SOSPESO:"
      '
      'txtTotaleConto
      '
      Me.txtTotaleConto.AcceptsReturn = True
      Me.txtTotaleConto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTotaleConto.BackColor = System.Drawing.Color.White
      Me.txtTotaleConto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotaleConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotaleConto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTotaleConto.Location = New System.Drawing.Point(785, 79)
      Me.txtTotaleConto.MaxLength = 100
      Me.txtTotaleConto.Name = "txtTotaleConto"
      Me.txtTotaleConto.ReadOnly = True
      Me.txtTotaleConto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotaleConto.Size = New System.Drawing.Size(125, 29)
      Me.txtTotaleConto.TabIndex = 13
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
      Me.txtValSconto.Location = New System.Drawing.Point(785, 119)
      Me.txtValSconto.MaxLength = 100
      Me.txtValSconto.Name = "txtValSconto"
      Me.txtValSconto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtValSconto.Size = New System.Drawing.Size(125, 29)
      Me.txtValSconto.TabIndex = 14
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
      Me.txtServizio.Location = New System.Drawing.Point(785, 159)
      Me.txtServizio.MaxLength = 100
      Me.txtServizio.Name = "txtServizio"
      Me.txtServizio.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtServizio.Size = New System.Drawing.Size(125, 29)
      Me.txtServizio.TabIndex = 15
      Me.txtServizio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtContanti
      '
      Me.txtContanti.AcceptsReturn = True
      Me.txtContanti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtContanti.BackColor = System.Drawing.SystemColors.Window
      Me.txtContanti.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtContanti.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtContanti.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtContanti.Location = New System.Drawing.Point(785, 267)
      Me.txtContanti.MaxLength = 100
      Me.txtContanti.Name = "txtContanti"
      Me.txtContanti.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtContanti.Size = New System.Drawing.Size(125, 29)
      Me.txtContanti.TabIndex = 17
      Me.txtContanti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCartaCredito
      '
      Me.txtCartaCredito.AcceptsReturn = True
      Me.txtCartaCredito.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtCartaCredito.BackColor = System.Drawing.Color.White
      Me.txtCartaCredito.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCartaCredito.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCartaCredito.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCartaCredito.Location = New System.Drawing.Point(785, 307)
      Me.txtCartaCredito.MaxLength = 100
      Me.txtCartaCredito.Name = "txtCartaCredito"
      Me.txtCartaCredito.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCartaCredito.Size = New System.Drawing.Size(125, 29)
      Me.txtCartaCredito.TabIndex = 19
      Me.txtCartaCredito.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtSospeso
      '
      Me.txtSospeso.AcceptsReturn = True
      Me.txtSospeso.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtSospeso.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtSospeso.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtSospeso.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtSospeso.ForeColor = System.Drawing.Color.Red
      Me.txtSospeso.Location = New System.Drawing.Point(785, 387)
      Me.txtSospeso.MaxLength = 100
      Me.txtSospeso.Name = "txtSospeso"
      Me.txtSospeso.ReadOnly = True
      Me.txtSospeso.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtSospeso.Size = New System.Drawing.Size(125, 29)
      Me.txtSospeso.TabIndex = 18
      Me.txtSospeso.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtResto
      '
      Me.txtResto.AcceptsReturn = True
      Me.txtResto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtResto.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtResto.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtResto.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtResto.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtResto.Location = New System.Drawing.Point(785, 427)
      Me.txtResto.MaxLength = 100
      Me.txtResto.Name = "txtResto"
      Me.txtResto.ReadOnly = True
      Me.txtResto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtResto.Size = New System.Drawing.Size(125, 29)
      Me.txtResto.TabIndex = 19
      Me.txtResto.TabStop = False
      Me.txtResto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lstvDettagli
      '
      Me.lstvDettagli.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lstvDettagli.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvDettagli.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader4, Me.colonnaQta, Me.colonnaDescrizione, Me.colonnaPrezzo, Me.colonnaImporto, Me.colonnaIva, Me.ColumnHeader6, Me.ColumnHeader7})
      Me.lstvDettagli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagli.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagli.FullRowSelect = True
      Me.lstvDettagli.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me.lstvDettagli.Location = New System.Drawing.Point(298, 80)
      Me.lstvDettagli.MultiSelect = False
      Me.lstvDettagli.Name = "lstvDettagli"
      Me.lstvDettagli.Size = New System.Drawing.Size(317, 614)
      Me.lstvDettagli.TabIndex = 9
      Me.lstvDettagli.UseCompatibleStateImageBehavior = False
      Me.lstvDettagli.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Width = 0
      '
      'colonnaQta
      '
      Me.colonnaQta.Text = "Q.tà"
      Me.colonnaQta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.colonnaQta.Width = 50
      '
      'colonnaDescrizione
      '
      Me.colonnaDescrizione.Text = "Descrizione"
      Me.colonnaDescrizione.Width = 220
      '
      'colonnaPrezzo
      '
      Me.colonnaPrezzo.Text = "Prezzo"
      Me.colonnaPrezzo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'colonnaImporto
      '
      Me.colonnaImporto.Text = "Importo"
      Me.colonnaImporto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.colonnaImporto.Width = 70
      '
      'colonnaIva
      '
      Me.colonnaIva.Text = "IVA%"
      Me.colonnaIva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.colonnaIva.Width = 50
      '
      'ColumnHeader6
      '
      Me.ColumnHeader6.Width = 0
      '
      'ColumnHeader7
      '
      Me.ColumnHeader7.Width = 0
      '
      'txtIva
      '
      Me.txtIva.AcceptsReturn = True
      Me.txtIva.BackColor = System.Drawing.SystemColors.Window
      Me.txtIva.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtIva.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtIva.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtIva.Location = New System.Drawing.Point(259, 82)
      Me.txtIva.MaxLength = 10
      Me.txtIva.Name = "txtIva"
      Me.txtIva.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIva.Size = New System.Drawing.Size(34, 29)
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
      Me.Label11.Location = New System.Drawing.Point(197, 87)
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
      'txtBuoni
      '
      Me.txtBuoni.AcceptsReturn = True
      Me.txtBuoni.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtBuoni.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtBuoni.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtBuoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtBuoni.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtBuoni.Location = New System.Drawing.Point(785, 347)
      Me.txtBuoni.MaxLength = 100
      Me.txtBuoni.Name = "txtBuoni"
      Me.txtBuoni.ReadOnly = True
      Me.txtBuoni.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtBuoni.Size = New System.Drawing.Size(125, 29)
      Me.txtBuoni.TabIndex = 21
      Me.txtBuoni.TabStop = False
      Me.txtBuoni.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lstvDatiBuoni
      '
      Me.lstvDatiBuoni.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvDatiBuoni.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDatiBuoni.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader8, Me.ColumnHeader9, Me.ColumnHeader10, Me.ColumnHeader11, Me.ColumnHeader12, Me.ColumnHeader13, Me.ColumnHeader14, Me.ColumnHeader15, Me.ColumnHeader16, Me.ColumnHeader17})
      Me.lstvDatiBuoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDatiBuoni.ForeColor = System.Drawing.Color.Black
      Me.lstvDatiBuoni.FullRowSelect = True
      Me.lstvDatiBuoni.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDatiBuoni.Location = New System.Drawing.Point(301, 273)
      Me.lstvDatiBuoni.MultiSelect = False
      Me.lstvDatiBuoni.Name = "lstvDatiBuoni"
      Me.lstvDatiBuoni.Size = New System.Drawing.Size(274, 45)
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
      Me.txtCoperto.Location = New System.Drawing.Point(916, 159)
      Me.txtCoperto.MaxLength = 100
      Me.txtCoperto.Name = "txtCoperto"
      Me.txtCoperto.ReadOnly = True
      Me.txtCoperto.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCoperto.Size = New System.Drawing.Size(129, 29)
      Me.txtCoperto.TabIndex = 8
      Me.txtCoperto.TabStop = False
      Me.txtCoperto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label12
      '
      Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Label12.BackColor = System.Drawing.Color.Transparent
      Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label12.ForeColor = System.Drawing.Color.Black
      Me.Label12.Location = New System.Drawing.Point(916, 128)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(88, 20)
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
      Me.txtTotDividere.BackColor = System.Drawing.Color.White
      Me.txtTotDividere.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtTotDividere.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtTotDividere.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtTotDividere.Location = New System.Drawing.Point(182, 119)
      Me.txtTotDividere.MaxLength = 100
      Me.txtTotDividere.Name = "txtTotDividere"
      Me.txtTotDividere.ReadOnly = True
      Me.txtTotDividere.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtTotDividere.Size = New System.Drawing.Size(106, 29)
      Me.txtTotDividere.TabIndex = 2
      Me.txtTotDividere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtQuotaPersona
      '
      Me.txtQuotaPersona.AcceptsReturn = True
      Me.txtQuotaPersona.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtQuotaPersona.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtQuotaPersona.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtQuotaPersona.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtQuotaPersona.Location = New System.Drawing.Point(182, 159)
      Me.txtQuotaPersona.MaxLength = 100
      Me.txtQuotaPersona.Name = "txtQuotaPersona"
      Me.txtQuotaPersona.ReadOnly = True
      Me.txtQuotaPersona.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtQuotaPersona.Size = New System.Drawing.Size(106, 29)
      Me.txtQuotaPersona.TabIndex = 4
      Me.txtQuotaPersona.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lstvElencoDocAperti
      '
      Me.lstvElencoDocAperti.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lstvElencoDocAperti.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvElencoDocAperti.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvElencoDocAperti.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader18, Me.ColumnHeader19, Me.ColumnHeader20, Me.ColumnHeader21})
      Me.lstvElencoDocAperti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvElencoDocAperti.ForeColor = System.Drawing.Color.Black
      Me.lstvElencoDocAperti.FullRowSelect = True
      Me.lstvElencoDocAperti.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable
      Me.lstvElencoDocAperti.Location = New System.Drawing.Point(8, 195)
      Me.lstvElencoDocAperti.MultiSelect = False
      Me.lstvElencoDocAperti.Name = "lstvElencoDocAperti"
      Me.lstvElencoDocAperti.Size = New System.Drawing.Size(280, 499)
      Me.lstvElencoDocAperti.TabIndex = 5
      Me.lstvElencoDocAperti.UseCompatibleStateImageBehavior = False
      Me.lstvElencoDocAperti.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader18
      '
      Me.ColumnHeader18.Width = 0
      '
      'ColumnHeader19
      '
      Me.ColumnHeader19.Text = "Stato"
      Me.ColumnHeader19.Width = 80
      '
      'ColumnHeader20
      '
      Me.ColumnHeader20.Text = "Totale da pagare"
      Me.ColumnHeader20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.ColumnHeader20.Width = 175
      '
      'ColumnHeader21
      '
      Me.ColumnHeader21.Width = 0
      '
      'Label18
      '
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label18.ForeColor = System.Drawing.Color.Black
      Me.Label18.Location = New System.Drawing.Point(298, 16)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(104, 24)
      Me.Label18.TabIndex = 245
      Me.Label18.Text = "VOCI CONTO:"
      '
      'txtNumDoc
      '
      Me.txtNumDoc.AcceptsReturn = True
      Me.txtNumDoc.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.txtNumDoc.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNumDoc.Enabled = False
      Me.txtNumDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNumDoc.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNumDoc.Location = New System.Drawing.Point(224, 80)
      Me.txtNumDoc.MaxLength = 2
      Me.txtNumDoc.Name = "txtNumDoc"
      Me.txtNumDoc.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNumDoc.Size = New System.Drawing.Size(64, 29)
      Me.txtNumDoc.TabIndex = 1
      Me.txtNumDoc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lstvDettagliTemp
      '
      Me.lstvDettagliTemp.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvDettagliTemp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagliTemp.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader22, Me.ColumnHeader23, Me.ColumnHeader24, Me.ColumnHeader25, Me.ColumnHeader26, Me.ColumnHeader27, Me.ColumnHeader28})
      Me.lstvDettagliTemp.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagliTemp.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagliTemp.FullRowSelect = True
      Me.lstvDettagliTemp.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagliTemp.Location = New System.Drawing.Point(301, 120)
      Me.lstvDettagliTemp.MultiSelect = False
      Me.lstvDettagliTemp.Name = "lstvDettagliTemp"
      Me.lstvDettagliTemp.Size = New System.Drawing.Size(274, 45)
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
      Me.lstvDettagliCompatto.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvDettagliCompatto.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagliCompatto.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader29, Me.ColumnHeader30, Me.ColumnHeader31, Me.ColumnHeader32, Me.ColumnHeader33, Me.ColumnHeader34, Me.ColumnHeader35})
      Me.lstvDettagliCompatto.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagliCompatto.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagliCompatto.FullRowSelect = True
      Me.lstvDettagliCompatto.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagliCompatto.Location = New System.Drawing.Point(301, 222)
      Me.lstvDettagliCompatto.MultiSelect = False
      Me.lstvDettagliCompatto.Name = "lstvDettagliCompatto"
      Me.lstvDettagliCompatto.Size = New System.Drawing.Size(274, 45)
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
      Me.lstvDettagliCopia.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.lstvDettagliCopia.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.lstvDettagliCopia.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader36, Me.ColumnHeader37, Me.ColumnHeader38, Me.ColumnHeader39, Me.ColumnHeader40, Me.ColumnHeader41, Me.ColumnHeader42})
      Me.lstvDettagliCopia.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lstvDettagliCopia.ForeColor = System.Drawing.Color.Black
      Me.lstvDettagliCopia.FullRowSelect = True
      Me.lstvDettagliCopia.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
      Me.lstvDettagliCopia.Location = New System.Drawing.Point(301, 171)
      Me.lstvDettagliCopia.MultiSelect = False
      Me.lstvDettagliCopia.Name = "lstvDettagliCopia"
      Me.lstvDettagliCopia.Size = New System.Drawing.Size(274, 45)
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
      Me.txtIdCliente.Location = New System.Drawing.Point(145, 122)
      Me.txtIdCliente.MaxLength = 100
      Me.txtIdCliente.Name = "txtIdCliente"
      Me.txtIdCliente.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIdCliente.Size = New System.Drawing.Size(51, 29)
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
      Me.txtIdAzienda.Location = New System.Drawing.Point(145, 166)
      Me.txtIdAzienda.MaxLength = 100
      Me.txtIdAzienda.Name = "txtIdAzienda"
      Me.txtIdAzienda.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtIdAzienda.Size = New System.Drawing.Size(51, 29)
      Me.txtIdAzienda.TabIndex = 256
      Me.txtIdAzienda.Visible = False
      '
      'Label16
      '
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(13, 131)
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
      Me.Label19.Location = New System.Drawing.Point(13, 166)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(112, 24)
      Me.Label19.TabIndex = 258
      Me.Label19.Text = "ID AZIENDA:"
      Me.Label19.Visible = False
      '
      'Timer2
      '
      Me.Timer2.Interval = 1000
      '
      'txtCodiceFiscale
      '
      Me.txtCodiceFiscale.AcceptsReturn = True
      Me.txtCodiceFiscale.BackColor = System.Drawing.SystemColors.Window
      Me.txtCodiceFiscale.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCodiceFiscale.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCodiceFiscale.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCodiceFiscale.Location = New System.Drawing.Point(145, 209)
      Me.txtCodiceFiscale.MaxLength = 11
      Me.txtCodiceFiscale.Name = "txtCodiceFiscale"
      Me.txtCodiceFiscale.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCodiceFiscale.Size = New System.Drawing.Size(144, 29)
      Me.txtCodiceFiscale.TabIndex = 260
      Me.txtCodiceFiscale.Visible = False
      '
      'Label20
      '
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(13, 214)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(171, 24)
      Me.Label20.TabIndex = 261
      Me.Label20.Text = "CODICE FISCALE:"
      Me.Label20.Visible = False
      '
      'txtCognome
      '
      Me.txtCognome.AcceptsReturn = True
      Me.txtCognome.BackColor = System.Drawing.SystemColors.Window
      Me.txtCognome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtCognome.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtCognome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtCognome.Location = New System.Drawing.Point(145, 244)
      Me.txtCognome.MaxLength = 11
      Me.txtCognome.Name = "txtCognome"
      Me.txtCognome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtCognome.Size = New System.Drawing.Size(144, 29)
      Me.txtCognome.TabIndex = 262
      Me.txtCognome.Visible = False
      '
      'Label21
      '
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(13, 249)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(144, 24)
      Me.Label21.TabIndex = 263
      Me.Label21.Text = "COGNOME:"
      Me.Label21.Visible = False
      '
      'txtNome
      '
      Me.txtNome.AcceptsReturn = True
      Me.txtNome.BackColor = System.Drawing.SystemColors.Window
      Me.txtNome.Cursor = System.Windows.Forms.Cursors.IBeam
      Me.txtNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.txtNome.ForeColor = System.Drawing.SystemColors.WindowText
      Me.txtNome.Location = New System.Drawing.Point(145, 279)
      Me.txtNome.MaxLength = 11
      Me.txtNome.Name = "txtNome"
      Me.txtNome.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.txtNome.Size = New System.Drawing.Size(144, 29)
      Me.txtNome.TabIndex = 264
      Me.txtNome.Visible = False
      '
      'Label22
      '
      Me.Label22.BackColor = System.Drawing.Color.Transparent
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(13, 284)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(144, 24)
      Me.Label22.TabIndex = 265
      Me.Label22.Text = "NOME:"
      Me.Label22.Visible = False
      '
      'eui_cmdTipoConto
      '
      Me.eui_cmdTipoConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdTipoConto.Id = "bae94802-85c5-4a0a-9440-d6acf83b8576"
      Me.eui_cmdTipoConto.Location = New System.Drawing.Point(8, 38)
      Me.eui_cmdTipoConto.Name = "eui_cmdTipoConto"
      Me.eui_cmdTipoConto.Size = New System.Drawing.Size(280, 34)
      Me.eui_cmdTipoConto.TabIndex = 0
      Me.eui_cmdTipoConto.Text = "Unico"
      '
      'eui_cmdTipoElenco
      '
      Me.eui_cmdTipoElenco.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdTipoElenco.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdTipoElenco.Id = "0c1154fa-f012-4871-b06b-f4c01a6df540"
      Me.eui_cmdTipoElenco.Location = New System.Drawing.Point(298, 38)
      Me.eui_cmdTipoElenco.Name = "eui_cmdTipoElenco"
      Me.eui_cmdTipoElenco.Size = New System.Drawing.Size(318, 34)
      Me.eui_cmdTipoElenco.TabIndex = 8
      Me.eui_cmdTipoElenco.Text = "Elenco completo"
      '
      'eui_cmdCliente
      '
      Me.eui_cmdCliente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdCliente.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdCliente.Id = "91912e10-0af0-4b35-92c4-aac862f9b961"
      Me.eui_cmdCliente.Location = New System.Drawing.Point(623, 38)
      Me.eui_cmdCliente.Name = "eui_cmdCliente"
      Me.eui_cmdCliente.Size = New System.Drawing.Size(422, 34)
      Me.eui_cmdCliente.TabIndex = 12
      Me.eui_cmdCliente.Text = "Seleziona cliente"
      '
      'eui_cmdDivisioneAnalitica
      '
      Me.eui_cmdDivisioneAnalitica.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdDivisioneAnalitica.Id = "b80c0482-b699-4044-9f7f-d20376b95d72"
      Me.eui_cmdDivisioneAnalitica.Location = New System.Drawing.Point(8, 157)
      Me.eui_cmdDivisioneAnalitica.Name = "eui_cmdDivisioneAnalitica"
      Me.eui_cmdDivisioneAnalitica.Size = New System.Drawing.Size(280, 34)
      Me.eui_cmdDivisioneAnalitica.TabIndex = 3
      Me.eui_cmdDivisioneAnalitica.Text = "&Divisione analitica"
      Me.eui_cmdDivisioneAnalitica.Visible = False
      '
      'eui_cmdContanti
      '
      Me.eui_cmdContanti.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdContanti.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdContanti.Id = "a450c693-540f-480d-a0cc-85da140f5dbf"
      Me.eui_cmdContanti.Location = New System.Drawing.Point(623, 267)
      Me.eui_cmdContanti.Name = "eui_cmdContanti"
      Me.eui_cmdContanti.Size = New System.Drawing.Size(159, 32)
      Me.eui_cmdContanti.TabIndex = 16
      Me.eui_cmdContanti.Text = "Contanti"
      '
      'eui_cmdTipoPagamento
      '
      Me.eui_cmdTipoPagamento.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdTipoPagamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdTipoPagamento.Id = "68ed8e14-f2d2-4fcf-b7e9-b96a2ab95848"
      Me.eui_cmdTipoPagamento.Location = New System.Drawing.Point(623, 307)
      Me.eui_cmdTipoPagamento.Name = "eui_cmdTipoPagamento"
      Me.eui_cmdTipoPagamento.Size = New System.Drawing.Size(159, 32)
      Me.eui_cmdTipoPagamento.TabIndex = 18
      Me.eui_cmdTipoPagamento.Text = "Carte di credito"
      '
      'eui_cmdBuoni
      '
      Me.eui_cmdBuoni.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdBuoni.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdBuoni.Id = "b6adb7f7-858a-491f-ac6e-9ab0305a328f"
      Me.eui_cmdBuoni.Location = New System.Drawing.Point(623, 347)
      Me.eui_cmdBuoni.Name = "eui_cmdBuoni"
      Me.eui_cmdBuoni.Size = New System.Drawing.Size(159, 32)
      Me.eui_cmdBuoni.TabIndex = 20
      Me.eui_cmdBuoni.Text = "Buoni pasto"
      '
      'eui_cmdRicevuta
      '
      Me.eui_cmdRicevuta.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdRicevuta.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdRicevuta.Id = "20a6a06b-510e-4f11-a302-4d5b6d963889"
      Me.eui_cmdRicevuta.Location = New System.Drawing.Point(916, 267)
      Me.eui_cmdRicevuta.Name = "eui_cmdRicevuta"
      Me.eui_cmdRicevuta.Size = New System.Drawing.Size(129, 61)
      Me.eui_cmdRicevuta.TabIndex = 41
      Me.eui_cmdRicevuta.Text = "Ricevuta Fiscale"
      Me.eui_cmdRicevuta.WordWrap = True
      '
      'eui_cmdFattura
      '
      Me.eui_cmdFattura.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdFattura.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdFattura.Id = "4f3f9c86-b0d0-4431-8de4-e3873c4d7c55"
      Me.eui_cmdFattura.Location = New System.Drawing.Point(916, 336)
      Me.eui_cmdFattura.Name = "eui_cmdFattura"
      Me.eui_cmdFattura.Size = New System.Drawing.Size(129, 61)
      Me.eui_cmdFattura.TabIndex = 42
      Me.eui_cmdFattura.Text = "Fattura"
      '
      'eui_cmdProforma
      '
      Me.eui_cmdProforma.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdProforma.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdProforma.Id = "2ea56b5e-671a-43b3-8ad8-7ab81a602bb2"
      Me.eui_cmdProforma.Location = New System.Drawing.Point(916, 405)
      Me.eui_cmdProforma.Name = "eui_cmdProforma"
      Me.eui_cmdProforma.Size = New System.Drawing.Size(129, 61)
      Me.eui_cmdProforma.TabIndex = 43
      Me.eui_cmdProforma.Text = "Proforma"
      '
      'eui_cmdScontrino
      '
      Me.eui_cmdScontrino.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdScontrino.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdScontrino.Id = "7e04d4eb-5141-450a-80d8-a3bc5f3a6183"
      Me.eui_cmdScontrino.Location = New System.Drawing.Point(916, 474)
      Me.eui_cmdScontrino.Name = "eui_cmdScontrino"
      Me.eui_cmdScontrino.Size = New System.Drawing.Size(129, 61)
      Me.eui_cmdScontrino.TabIndex = 44
      Me.eui_cmdScontrino.Text = "Scontrino"
      '
      'eui_AddebitoSuRisorsa
      '
      Me.eui_AddebitoSuRisorsa.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_AddebitoSuRisorsa.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_AddebitoSuRisorsa.Id = "6a87759a-b9e3-4a71-9907-e9f88099bbca"
      Me.eui_AddebitoSuRisorsa.Location = New System.Drawing.Point(916, 612)
      Me.eui_AddebitoSuRisorsa.Name = "eui_AddebitoSuRisorsa"
      Me.eui_AddebitoSuRisorsa.Size = New System.Drawing.Size(129, 61)
      Me.eui_AddebitoSuRisorsa.TabIndex = 45
      Me.eui_AddebitoSuRisorsa.Text = "Addebita..."
      Me.eui_AddebitoSuRisorsa.WordWrap = True
      '
      'eui_cmdEsci
      '
      Me.eui_cmdEsci.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdEsci.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdEsci.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdEsci.Id = "142ec9f4-717a-4e39-89b3-e61402042ebe"
      Me.eui_cmdEsci.Location = New System.Drawing.Point(916, 698)
      Me.eui_cmdEsci.Name = "eui_cmdEsci"
      Me.eui_cmdEsci.Size = New System.Drawing.Size(129, 51)
      Me.eui_cmdEsci.TabIndex = 46
      Me.eui_cmdEsci.Text = "Esci"
      '
      'netBtn_DaPagare
      '
      Me.netBtn_DaPagare.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_DaPagare.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_DaPagare.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_DaPagare.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_DaPagare.ColorText = System.Drawing.SystemColors.ControlText
      Me.netBtn_DaPagare.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_DaPagare.CornerRadius = 2
      Me.netBtn_DaPagare.Font = New System.Drawing.Font("Microsoft Sans Serif", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_DaPagare.Location = New System.Drawing.Point(785, 199)
      Me.netBtn_DaPagare.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_DaPagare.Name = "netBtn_DaPagare"
      Me.netBtn_DaPagare.Size = New System.Drawing.Size(260, 62)
      Me.netBtn_DaPagare.TabIndex = 285
      Me.netBtn_DaPagare.TextButton = "25,50"
      Me.netBtn_DaPagare.TextButtonAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'netBtn_C
      '
      Me.netBtn_C.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_C.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
      Me.netBtn_C.ColorDisabled = System.Drawing.Color.Brown
      Me.netBtn_C.ColorLight = System.Drawing.Color.MistyRose
      Me.netBtn_C.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Red
      Me.netBtn_C.ColorText = System.Drawing.Color.Black
      Me.netBtn_C.ColorTop = System.Drawing.Color.White
      Me.netBtn_C.CornerRadius = 2
      Me.netBtn_C.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_C.Location = New System.Drawing.Point(839, 466)
      Me.netBtn_C.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_C.Name = "netBtn_C"
      Me.netBtn_C.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_C.TabIndex = 25
      Me.netBtn_C.TextButton = "C"
      '
      'netBtn_9
      '
      Me.netBtn_9.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_9.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_9.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_9.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_9.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_9.ColorText = System.Drawing.Color.Black
      Me.netBtn_9.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_9.CornerRadius = 2
      Me.netBtn_9.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_9.Location = New System.Drawing.Point(767, 466)
      Me.netBtn_9.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_9.Name = "netBtn_9"
      Me.netBtn_9.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_9.TabIndex = 24
      Me.netBtn_9.TextButton = "9"
      '
      'netBtn_8
      '
      Me.netBtn_8.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_8.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_8.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_8.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_8.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_8.ColorText = System.Drawing.Color.Black
      Me.netBtn_8.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_8.CornerRadius = 2
      Me.netBtn_8.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_8.Location = New System.Drawing.Point(695, 466)
      Me.netBtn_8.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_8.Name = "netBtn_8"
      Me.netBtn_8.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_8.TabIndex = 23
      Me.netBtn_8.TextButton = "8"
      '
      'netBtn_7
      '
      Me.netBtn_7.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_7.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_7.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_7.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_7.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_7.ColorText = System.Drawing.Color.Black
      Me.netBtn_7.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_7.CornerRadius = 2
      Me.netBtn_7.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_7.Location = New System.Drawing.Point(623, 466)
      Me.netBtn_7.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_7.Name = "netBtn_7"
      Me.netBtn_7.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_7.TabIndex = 22
      Me.netBtn_7.TextButton = "7"
      '
      'netBtn_Ok
      '
      Me.netBtn_Ok.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Ok.ColorBottom = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(211, Byte), Integer), CType(CType(40, Byte), Integer))
      Me.netBtn_Ok.ColorDisabled = System.Drawing.Color.SeaGreen
      Me.netBtn_Ok.ColorLight = System.Drawing.Color.FromArgb(CType(CType(141, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(189, Byte), Integer))
      Me.netBtn_Ok.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Green
      Me.netBtn_Ok.ColorText = System.Drawing.Color.Black
      Me.netBtn_Ok.ColorTop = System.Drawing.Color.White
      Me.netBtn_Ok.CornerRadius = 2
      Me.netBtn_Ok.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Ok.Location = New System.Drawing.Point(839, 622)
      Me.netBtn_Ok.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Ok.Name = "netBtn_Ok"
      Me.netBtn_Ok.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_Ok.TabIndex = 37
      Me.netBtn_Ok.TextButton = "OK"
      '
      'netBtn_Percentuale
      '
      Me.netBtn_Percentuale.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Percentuale.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_Percentuale.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_Percentuale.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_Percentuale.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_Percentuale.ColorText = System.Drawing.Color.Black
      Me.netBtn_Percentuale.ColorTop = System.Drawing.Color.White
      Me.netBtn_Percentuale.CornerRadius = 2
      Me.netBtn_Percentuale.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Percentuale.Location = New System.Drawing.Point(839, 570)
      Me.netBtn_Percentuale.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Percentuale.Name = "netBtn_Percentuale"
      Me.netBtn_Percentuale.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_Percentuale.TabIndex = 33
      Me.netBtn_Percentuale.TextButton = "%"
      '
      'netBtn_X
      '
      Me.netBtn_X.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_X.ColorBottom = System.Drawing.Color.Orange
      Me.netBtn_X.ColorDisabled = System.Drawing.Color.LightSalmon
      Me.netBtn_X.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_X.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_X.ColorText = System.Drawing.Color.Black
      Me.netBtn_X.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_X.CornerRadius = 2
      Me.netBtn_X.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_X.Location = New System.Drawing.Point(839, 518)
      Me.netBtn_X.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_X.Name = "netBtn_X"
      Me.netBtn_X.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_X.TabIndex = 29
      Me.netBtn_X.TextButton = "X"
      '
      'netBtn_00
      '
      Me.netBtn_00.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_00.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_00.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_00.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_00.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_00.ColorText = System.Drawing.Color.Black
      Me.netBtn_00.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_00.CornerRadius = 2
      Me.netBtn_00.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_00.Location = New System.Drawing.Point(767, 622)
      Me.netBtn_00.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_00.Name = "netBtn_00"
      Me.netBtn_00.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_00.TabIndex = 36
      Me.netBtn_00.TextButton = "00"
      '
      'netBtn_0
      '
      Me.netBtn_0.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_0.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_0.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_0.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_0.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_0.ColorText = System.Drawing.Color.Black
      Me.netBtn_0.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_0.CornerRadius = 2
      Me.netBtn_0.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_0.Location = New System.Drawing.Point(695, 622)
      Me.netBtn_0.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_0.Name = "netBtn_0"
      Me.netBtn_0.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_0.TabIndex = 35
      Me.netBtn_0.TextButton = "0"
      '
      'netBtn_Virgola
      '
      Me.netBtn_Virgola.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_Virgola.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_Virgola.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_Virgola.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_Virgola.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_Virgola.ColorText = System.Drawing.Color.Black
      Me.netBtn_Virgola.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_Virgola.CornerRadius = 2
      Me.netBtn_Virgola.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_Virgola.Location = New System.Drawing.Point(623, 622)
      Me.netBtn_Virgola.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_Virgola.Name = "netBtn_Virgola"
      Me.netBtn_Virgola.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_Virgola.TabIndex = 34
      Me.netBtn_Virgola.TextButton = ","
      '
      'netBtn_3
      '
      Me.netBtn_3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_3.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_3.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_3.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_3.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_3.ColorText = System.Drawing.Color.Black
      Me.netBtn_3.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_3.CornerRadius = 2
      Me.netBtn_3.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_3.Location = New System.Drawing.Point(767, 570)
      Me.netBtn_3.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_3.Name = "netBtn_3"
      Me.netBtn_3.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_3.TabIndex = 32
      Me.netBtn_3.TextButton = "3"
      '
      'netBtn_2
      '
      Me.netBtn_2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_2.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_2.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_2.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_2.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_2.ColorText = System.Drawing.Color.Black
      Me.netBtn_2.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_2.CornerRadius = 2
      Me.netBtn_2.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_2.Location = New System.Drawing.Point(695, 570)
      Me.netBtn_2.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_2.Name = "netBtn_2"
      Me.netBtn_2.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_2.TabIndex = 31
      Me.netBtn_2.TextButton = "2"
      '
      'netBtn_1
      '
      Me.netBtn_1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_1.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_1.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_1.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_1.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_1.ColorText = System.Drawing.Color.Black
      Me.netBtn_1.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_1.CornerRadius = 2
      Me.netBtn_1.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_1.Location = New System.Drawing.Point(623, 570)
      Me.netBtn_1.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_1.Name = "netBtn_1"
      Me.netBtn_1.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_1.TabIndex = 30
      Me.netBtn_1.TextButton = "1"
      '
      'netBtn_6
      '
      Me.netBtn_6.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_6.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_6.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_6.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_6.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_6.ColorText = System.Drawing.Color.Black
      Me.netBtn_6.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_6.CornerRadius = 2
      Me.netBtn_6.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_6.Location = New System.Drawing.Point(767, 518)
      Me.netBtn_6.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_6.Name = "netBtn_6"
      Me.netBtn_6.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_6.TabIndex = 28
      Me.netBtn_6.TextButton = "6"
      '
      'netBtn_5
      '
      Me.netBtn_5.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_5.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_5.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_5.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_5.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_5.ColorText = System.Drawing.Color.Black
      Me.netBtn_5.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_5.CornerRadius = 2
      Me.netBtn_5.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_5.Location = New System.Drawing.Point(695, 518)
      Me.netBtn_5.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_5.Name = "netBtn_5"
      Me.netBtn_5.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_5.TabIndex = 27
      Me.netBtn_5.TextButton = "5"
      '
      'netBtn_4
      '
      Me.netBtn_4.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.netBtn_4.ColorBottom = System.Drawing.Color.RoyalBlue
      Me.netBtn_4.ColorDisabled = System.Drawing.Color.SteelBlue
      Me.netBtn_4.ColorLight = System.Drawing.Color.LightCyan
      Me.netBtn_4.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Blue
      Me.netBtn_4.ColorText = System.Drawing.Color.Black
      Me.netBtn_4.ColorTop = System.Drawing.Color.AliceBlue
      Me.netBtn_4.CornerRadius = 2
      Me.netBtn_4.Font = New System.Drawing.Font("Microsoft Sans Serif", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_4.Location = New System.Drawing.Point(623, 518)
      Me.netBtn_4.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_4.Name = "netBtn_4"
      Me.netBtn_4.Size = New System.Drawing.Size(71, 51)
      Me.netBtn_4.TabIndex = 26
      Me.netBtn_4.TextButton = "4"
      '
      'eui_cmdTastiera
      '
      Me.eui_cmdTastiera.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdTastiera.Id = "f72ccff9-cedc-4702-9eba-e3fa4d014db8"
      Me.eui_cmdTastiera.Location = New System.Drawing.Point(623, 698)
      Me.eui_cmdTastiera.Name = "eui_cmdTastiera"
      Me.eui_cmdTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdTastiera.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdTastiera.Size = New System.Drawing.Size(80, 51)
      Me.eui_cmdTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdTastiera.TabIndex = 38
      Me.eui_cmdTastiera.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      '
      'eui_cmdCancella
      '
      Me.eui_cmdCancella.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdCancella.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdCancella.Id = "ccec8484-50d6-4bb7-8a65-30c6a2687fd7"
      Me.eui_cmdCancella.Location = New System.Drawing.Point(704, 698)
      Me.eui_cmdCancella.Name = "eui_cmdCancella"
      Me.eui_cmdCancella.Size = New System.Drawing.Size(206, 51)
      Me.eui_cmdCancella.TabIndex = 39
      Me.eui_cmdCancella.Text = "Cancella tutto"
      '
      'eui_cmdDocApertiSu
      '
      Me.eui_cmdDocApertiSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdDocApertiSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdDocApertiSu.Id = "6b059eae-beb8-459f-9f21-2d487ed272aa"
      Me.eui_cmdDocApertiSu.Location = New System.Drawing.Point(148, 698)
      Me.eui_cmdDocApertiSu.Name = "eui_cmdDocApertiSu"
      Me.eui_cmdDocApertiSu.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdDocApertiSu.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdDocApertiSu.Size = New System.Drawing.Size(140, 51)
      Me.eui_cmdDocApertiSu.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdDocApertiSu.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdDocApertiSu.TabIndex = 7
      '
      'eui_cmdDocApertiGiù
      '
      Me.eui_cmdDocApertiGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdDocApertiGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdDocApertiGiù.Id = "3ebac6e2-30eb-41ab-a4a7-bae15468f153"
      Me.eui_cmdDocApertiGiù.Location = New System.Drawing.Point(8, 698)
      Me.eui_cmdDocApertiGiù.Name = "eui_cmdDocApertiGiù"
      Me.eui_cmdDocApertiGiù.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdDocApertiGiù.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdDocApertiGiù.Size = New System.Drawing.Size(139, 51)
      Me.eui_cmdDocApertiGiù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdDocApertiGiù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdDocApertiGiù.TabIndex = 6
      '
      'eui_cmdDettagliSu
      '
      Me.eui_cmdDettagliSu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdDettagliSu.Font = New System.Drawing.Font("Microsoft Sans Serif", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdDettagliSu.Id = "fe8d24ea-75aa-4e10-a4cb-ce858d8dbf12"
      Me.eui_cmdDettagliSu.Location = New System.Drawing.Point(487, 698)
      Me.eui_cmdDettagliSu.Name = "eui_cmdDettagliSu"
      Me.eui_cmdDettagliSu.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdDettagliSu.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdDettagliSu.Size = New System.Drawing.Size(128, 51)
      Me.eui_cmdDettagliSu.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdDettagliSu.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdDettagliSu.TabIndex = 11
      '
      'eui_cmdDettagliGiù
      '
      Me.eui_cmdDettagliGiù.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdDettagliGiù.Font = New System.Drawing.Font("Microsoft Sans Serif", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdDettagliGiù.Id = "36f1cf5e-85e8-4af3-993a-3ef9d4016630"
      Me.eui_cmdDettagliGiù.Location = New System.Drawing.Point(298, 698)
      Me.eui_cmdDettagliGiù.Name = "eui_cmdDettagliGiù"
      Me.eui_cmdDettagliGiù.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_cmdDettagliGiù.ScreenTip.Text = "Apre la tastiera virtuale."
      Me.eui_cmdDettagliGiù.Size = New System.Drawing.Size(128, 51)
      Me.eui_cmdDettagliGiù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdDettagliGiù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdDettagliGiù.TabIndex = 10
      '
      'Button10
      '
      Me.Button10.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Button10.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Button10.Id = "c3060643-24dd-41c0-ba02-8d7a62780804"
      Me.Button10.Location = New System.Drawing.Point(427, 698)
      Me.Button10.Name = "Button10"
      Me.Button10.Size = New System.Drawing.Size(59, 51)
      Me.Button10.TabIndex = 311
      '
      'Panel1
      '
      Me.Panel1.Controls.Add(Me.txtNome)
      Me.Panel1.Controls.Add(Me.txtCognome)
      Me.Panel1.Controls.Add(Me.Label11)
      Me.Panel1.Controls.Add(Me.txtIndirizzo)
      Me.Panel1.Controls.Add(Me.txtCittà)
      Me.Panel1.Controls.Add(Me.txtCap)
      Me.Panel1.Controls.Add(Me.txtProv)
      Me.Panel1.Controls.Add(Me.txtPIva)
      Me.Panel1.Controls.Add(Me.txtIva)
      Me.Panel1.Controls.Add(Me.txtIdCliente)
      Me.Panel1.Controls.Add(Me.txtIdAzienda)
      Me.Panel1.Controls.Add(Me.Label19)
      Me.Panel1.Controls.Add(Me.txtCodiceFiscale)
      Me.Panel1.Controls.Add(Me.Label4)
      Me.Panel1.Controls.Add(Me.Label16)
      Me.Panel1.Controls.Add(Me.Label22)
      Me.Panel1.Controls.Add(Me.Label20)
      Me.Panel1.Controls.Add(Me.Label21)
      Me.Panel1.Controls.Add(Me.Label5)
      Me.Panel1.Controls.Add(Me.Label31)
      Me.Panel1.Location = New System.Drawing.Point(301, 324)
      Me.Panel1.Name = "Panel1"
      Me.Panel1.Size = New System.Drawing.Size(274, 318)
      Me.Panel1.TabIndex = 316
      Me.Panel1.Visible = False
      '
      'eui_cmdParcheggiaConto
      '
      Me.eui_cmdParcheggiaConto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.eui_cmdParcheggiaConto.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdParcheggiaConto.Id = "2d6cfcc8-f5e7-4f05-9936-774797ba8423"
      Me.eui_cmdParcheggiaConto.Location = New System.Drawing.Point(915, 543)
      Me.eui_cmdParcheggiaConto.Name = "eui_cmdParcheggiaConto"
      Me.eui_cmdParcheggiaConto.Size = New System.Drawing.Size(129, 61)
      Me.eui_cmdParcheggiaConto.TabIndex = 40
      Me.eui_cmdParcheggiaConto.Text = "Parcheggia"
      Me.eui_cmdParcheggiaConto.WordWrap = True
      '
      'ContoPos
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(9, 22)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.ClientSize = New System.Drawing.Size(1068, 774)
      Me.Controls.Add(Me.eui_cmdParcheggiaConto)
      Me.Controls.Add(Me.Panel1)
      Me.Controls.Add(Me.lstvDettagliTemp)
      Me.Controls.Add(Me.lstvDettagliCopia)
      Me.Controls.Add(Me.Button10)
      Me.Controls.Add(Me.eui_cmdDettagliSu)
      Me.Controls.Add(Me.eui_cmdDettagliGiù)
      Me.Controls.Add(Me.eui_cmdDocApertiSu)
      Me.Controls.Add(Me.eui_cmdDocApertiGiù)
      Me.Controls.Add(Me.eui_cmdCancella)
      Me.Controls.Add(Me.eui_cmdTastiera)
      Me.Controls.Add(Me.netBtn_C)
      Me.Controls.Add(Me.netBtn_9)
      Me.Controls.Add(Me.netBtn_8)
      Me.Controls.Add(Me.netBtn_7)
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
      Me.Controls.Add(Me.netBtn_DaPagare)
      Me.Controls.Add(Me.eui_cmdEsci)
      Me.Controls.Add(Me.eui_AddebitoSuRisorsa)
      Me.Controls.Add(Me.eui_cmdScontrino)
      Me.Controls.Add(Me.eui_cmdProforma)
      Me.Controls.Add(Me.eui_cmdFattura)
      Me.Controls.Add(Me.eui_cmdRicevuta)
      Me.Controls.Add(Me.eui_cmdBuoni)
      Me.Controls.Add(Me.eui_cmdTipoPagamento)
      Me.Controls.Add(Me.eui_cmdContanti)
      Me.Controls.Add(Me.eui_cmdCliente)
      Me.Controls.Add(Me.eui_cmdTipoElenco)
      Me.Controls.Add(Me.eui_cmdTipoConto)
      Me.Controls.Add(Me.lstvDettagliCompatto)
      Me.Controls.Add(Me.Label18)
      Me.Controls.Add(Me.lstvElencoDocAperti)
      Me.Controls.Add(Me.txtQuotaPersona)
      Me.Controls.Add(Me.txtTotDividere)
      Me.Controls.Add(Me.txtNumDoc)
      Me.Controls.Add(Me.lblQuotaPersona)
      Me.Controls.Add(Me.Label15)
      Me.Controls.Add(Me.Label14)
      Me.Controls.Add(Me.Label13)
      Me.Controls.Add(Me.txtCoperto)
      Me.Controls.Add(Me.Label12)
      Me.Controls.Add(Me.lstvDatiBuoni)
      Me.Controls.Add(Me.txtBuoni)
      Me.Controls.Add(Me.txtResto)
      Me.Controls.Add(Me.txtSospeso)
      Me.Controls.Add(Me.txtCartaCredito)
      Me.Controls.Add(Me.txtContanti)
      Me.Controls.Add(Me.txtServizio)
      Me.Controls.Add(Me.txtValSconto)
      Me.Controls.Add(Me.txtTotaleConto)
      Me.Controls.Add(Me.lstvDettagli)
      Me.Controls.Add(Me.dtpData)
      Me.Controls.Add(Me.Label8)
      Me.Controls.Add(Me.Label9)
      Me.Controls.Add(Me.Label7)
      Me.Controls.Add(Me.Label6)
      Me.Controls.Add(Me.Label2)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.Label3)
      Me.Controls.Add(Me.eui_cmdDivisioneAnalitica)
      Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MinimizeBox = False
      Me.Name = "ContoPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "DETTAGLI CONTO"
      Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
      Me.Panel1.ResumeLayout(False)
      Me.Panel1.PerformLayout()
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
            If eui_cmdTipoPagamento.Text.ToUpper <> "ASSEGNI" And eui_cmdTipoPagamento.Text.ToUpper <> "ASSEGNO" Then
               ' Tipo pagamento - Carta di credito.
               tipoPagCartaCredito = "CARD,V" & RimuoviVirgola(txtCartaCredito.Text) & ",:" & eui_cmdTipoPagamento.Text & ";"
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

   Public Function LeggiNumeroDocFiscaleConfig(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      Try
         Dim chiaveConfig As String = String.Empty
         Select Case tipoDoc
            Case TIPO_DOC_FF
               chiaveConfig = "NumeroFattura"

            Case TIPO_DOC_RF
               chiaveConfig = "NumeroRicevuta"

            Case TIPO_DOC_PF
               chiaveConfig = "NumeroProforma"

         End Select

         If IsNumeric(DatiConfig.GetValue(chiaveConfig)) = False Then
            ' Legge dal database.
            Dim num As Integer = LeggiNumeroMax(tabella, tipoDoc)
            If num = 0 Then
               Return 1
            Else
               Return num
            End If
         Else
            ' Legge dal file di configurazione.
            Return Convert.ToInt32(DatiConfig.GetValue(chiaveConfig))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Sub SalvaNumeroDocFiscaleConfig(ByVal tabella As String, ByVal tipoDoc As String, ByVal numDoc As Integer)
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim chiaveConfig As String
         Select Case tipoDoc
            Case TIPO_DOC_FF
               chiaveConfig = "NumeroFattura"

            Case TIPO_DOC_RF
               chiaveConfig = "NumeroRicevuta"

            Case TIPO_DOC_PF
               chiaveConfig = "NumeroProforma"

         End Select

         DatiConfig.SetValue(chiaveConfig, (numDoc + 1).ToString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub EliminaNumeroDocFiscaleConfig(ByVal tabella As String, ByVal tipoDoc As String, ByVal numDoc As Integer)
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim chiaveConfig As String
         Select Case tipoDoc
            Case TIPO_DOC_FF
               chiaveConfig = "NumeroFattura"

            Case TIPO_DOC_RF
               chiaveConfig = "NumeroRicevuta"

            Case TIPO_DOC_PF
               chiaveConfig = "NumeroProforma"

         End Select

         DatiConfig.SetValue(chiaveConfig, (numDoc - 1).ToString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiCopertoConto(ByVal numDoc As String, ByVal tabella As String) As String
      Try
         If numDoc = String.Empty Then
            Return VALORE_ZERO
         End If

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NumDoc = " & numDoc, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim valCampo As String

         Do While dr.Read()
            valCampo = CFormatta.FormattaEuro(dr.Item("Coperto").ToString)
         Loop

         Return valCampo

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiScontoConto(ByVal numDoc As String, ByVal tabella As String) As String
      Try
         If numDoc = String.Empty Then
            Return VALORE_ZERO
         End If

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NumDoc = " & numDoc, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim valCampo As String

         Do While dr.Read()
            Dim val As Double = Convert.ToDouble(dr.Item("Sconto"))
            valCampo = CFormatta.FormattaNumeroDouble(val)
         Loop

         Return valCampo

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiTipoScontoConto(ByVal numDoc As String, ByVal tabella As String) As String
      Try
         If numDoc = String.Empty Then
            Return VALORE_ZERO
         End If

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NumDoc = " & numDoc, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim valCampo As String

         Do While dr.Read()
            valCampo = CFormatta.FormattaEuro(dr.Item("TipoSconto").ToString)
         Loop

         Return valCampo

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiServizioConto(ByVal numDoc As String, ByVal tabella As String) As String
      Try
         If numDoc = String.Empty Then
            Return VALORE_ZERO
         End If

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NumDoc = " & numDoc, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim valCampo As String

         Do While dr.Read()
            Dim val As Double = Convert.ToDouble(dr.Item("Servizio"))
            valCampo = CFormatta.FormattaNumeroDouble(val)
         Loop

         Return valCampo

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiTipoServizioConto(ByVal numDoc As String, ByVal tabella As String) As String
      Try
         If numDoc = String.Empty Then
            Return VALORE_ZERO
         End If

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NumDoc = " & numDoc, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim valCampo As String

         Do While dr.Read()
            valCampo = CFormatta.FormattaEuro(dr.Item("TipoServizio").ToString)
         Loop

         Return valCampo

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiContantiConto(ByVal numDoc As String, ByVal tabella As String) As String
      Try
         If numDoc = String.Empty Then
            Return VALORE_ZERO
         End If

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NumDoc = " & numDoc, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim valCampo As String

         Do While dr.Read()
            Dim val As Double = Convert.ToDouble(dr.Item("Contanti"))
            valCampo = CFormatta.FormattaNumeroDouble(val)
         Loop

         Return valCampo

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiCarteConto(ByVal numDoc As String, ByVal tabella As String) As String
      Try
         If numDoc = String.Empty Then
            Return VALORE_ZERO
         End If

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NumDoc = " & numDoc, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim valCampo As String

         Do While dr.Read()
            Dim val As Double = Convert.ToDouble(dr.Item("Carte"))
            valCampo = CFormatta.FormattaNumeroDouble(val)
         Loop

         Return valCampo

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return VALORE_ZERO

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiIdDocumento(ByVal tabella As String, ByVal NumDoc As String) As Integer
      ' Dichiara un oggetto DataAdapter.
      Dim da As OleDbDataAdapter
      ' Dichiara un oggetto DataSet
      Dim ds As DataSet
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Crea la stringa.
         sql = String.Format("SELECT * FROM {0} WHERE NumDoc = {1}", tabella, NumDoc)

         ' Dichiara un oggetto DataAdapter.
         da = New OleDbDataAdapter(sql, cn)

         ' Dichiara un oggetto DataSet
         ds = New DataSet

         ' Riempe il DataSet con i dati della tabella.
         da.Fill(ds, tabella)

         ' Assegna i valori dei campi del DataSet ai campi della classe.
         If IsDBNull(ds.Tables(tabella).Rows(0)("Id")) = False Then
            Return ds.Tables(tabella).Rows(0)("Id")
         Else
            Return 0
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         da.Dispose()
         ds.Dispose()
         ' Chiude la connessione.
         cn.Close()
      End Try
   End Function

   Private Sub ImpostaScontoConto()
      Try
         ' Imposta lo sconto.
         If IsNothing(g_frmVCTavoli) = False Then
            txtValSconto.Text = VALORE_ZERO
         Else
            Dim scontoConto As String = LeggiScontoConto(g_frmPos.numeroContoDoc, TAB_DOC)

            If scontoConto <> VALORE_ZERO Then
               valSconto = Convert.ToDouble(scontoConto)
               txtValSconto.Text = CFormatta.FormattaNumeroDouble(valSconto) '& LeggiTipoScontoConto(g_frmPos.numeroContoDoc, TAB_DOC)
            Else
               ' Se gestito a percentuale ma il valore è 0.
               valSconto = 0.0
               txtValSconto.Text = VALORE_ZERO
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ImpostaServizioConto()
      Try
         ' Imposta il servizio.
         If IsNothing(g_frmVCTavoli) = False Then
            txtServizio.Text = VALORE_ZERO
         Else
            Dim servizioConto As String = LeggiServizioConto(g_frmPos.numeroContoDoc, TAB_DOC)

            If servizioConto <> VALORE_ZERO Then
               valServizio = Convert.ToDouble(servizioConto)
               txtServizio.Text = CFormatta.FormattaNumeroDouble(valServizio) '& LeggiTipoServizioConto(g_frmPos.numeroContoDoc, TAB_DOC)
            Else
               ' Se gestito a percentuale ma il valore è 0.
               valServizio = 0.0
               txtServizio.Text = VALORE_ZERO
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ImpostaContantiConto()
      Try
         ' Imposta il valore dei contanti.
         If IsNothing(g_frmVCTavoli) = False Then
            txtContanti.Text = VALORE_ZERO
         Else
            txtContanti.Text = LeggiContantiConto(g_frmPos.numeroContoDoc, TAB_DOC)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ImpostaCarteConto()
      Try
         ' Imposta il valore dei contanti.
         If IsNothing(g_frmVCTavoli) = False Then
            txtCartaCredito.Text = VALORE_ZERO
         Else
            txtCartaCredito.Text = LeggiCarteConto(g_frmPos.numeroContoDoc, TAB_DOC)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ImpostaValoriConto()
      Try
         With g_frmPos
            txtIndirizzo.Text = String.Empty
            txtCap.Text = String.Empty
            txtCittà.Text = String.Empty
            txtProv.Text = String.Empty
            txtPIva.Text = String.Empty
            txtCodiceFiscale.Text = String.Empty

            If AliquotaIvaRistorante <> String.Empty Then
               txtIva.Text = CFormatta.FormattaEuro(AliquotaIvaRistorante)
            Else
               txtIva.Text = VALORE_ZERO
            End If

            ' Imposta il coperto.
            If .nomeTavolo <> String.Empty And .nomeTavolo <> "Asporto" Then
               If CopertoRistorante <> String.Empty Then
                  If IsNothing(g_frmVCTavoli) = False Then
                     txtCoperto.Text = CalcolaCostoTotaleCoperto(CopertoRistorante, g_frmVCTavoli.lblCoperti.Text)
                  Else
                     txtCoperto.Text = LeggiCopertoConto(g_frmPos.numeroContoDoc, TAB_DOC)
                  End If
               Else
                  txtCoperto.Text = VALORE_ZERO
               End If
            Else
               txtCoperto.Text = VALORE_ZERO
            End If

            ' Imposta lo sconto.
            ImpostaScontoConto()

            ' Il servizio viene inserito solo per la gestione dei Tavoli.
            If .nomeTavolo <> String.Empty And .nomeTavolo <> "Asporto" Then
               If ServizioRistorante <> String.Empty Then
                  txtServizio.Text = CFormatta.FormattaEuro(ServizioRistorante) & "%"
               Else
                  txtServizio.Text = VALORE_ZERO
               End If
            Else
               txtServizio.Text = VALORE_ZERO
            End If

            ' Imposta il servizio inserito manualmente.
            ImpostaServizioConto()

            txtTotaleConto.Text = TotaleContoRep
            netBtn_DaPagare.TextButton = TotaleContoRep

            txtContanti.Text = VALORE_ZERO
            ImpostaContantiConto()

            txtCartaCredito.Text = VALORE_ZERO
            ImpostaCarteConto()

            txtBuoni.Text = VALORE_ZERO
            txtSospeso.Text = VALORE_ZERO
            txtResto.Text = VALORE_ZERO

            lstvDatiBuoni.Items.Clear()

            op1 = 0.0
            op2 = 0.0

            formatta = False
            moltiplica = False
            cCredito = False
            contanti = False

            AggiornaValoriConto()

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
               If .lstvDettagli.Items(i).SubItems(9).Text = "No" Then
                  ' Indice
                  lstvDettagli.Items.Add(lstvDettagli.Items.Count - 1)
                  lstvDettagliCopia.Items.Add(lstvDettagliCopia.Items.Count - 1)

                  ' Quantità
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(1))
                  lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(1))

                  ' Descrizione.
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(2))
                  lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(2))

                  ' Prezzo.
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(4))
                  lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(4))

                  ' Importo.
                  If .lstvDettagli.Items(i).SubItems(10).Text = "No" Then
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(3))
                     lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(3))
                  Else
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Strikeout)
                     lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                     lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(VALORE_ZERO)
                  End If

                  ' Aliquota Iva.
                  lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(12))
                  lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(.lstvDettagli.Items(i).SubItems(12))

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
      txtNome.Text = String.Empty
      txtCognome.Text = String.Empty
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

         'idCliente = id
         txtIdAzienda.Text = id

         Do While dr.Read
            If IsDBNull(dr.Item("Cognome")) = False Then
               txtCognome.Text = dr.Item("Cognome").ToString
            Else
               txtCognome.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Nome")) = False Then
               txtNome.Text = dr.Item("Nome").ToString
            Else
               txtNome.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               txtIndirizzo.Text = dr.Item("Indirizzo").ToString
            Else
               txtIndirizzo.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Cap")) = False Then
               txtCap.Text = dr.Item("Cap").ToString
            Else
               txtCap.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Città")) = False Then
               txtCittà.Text = dr.Item("Città").ToString
            Else
               txtCittà.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Provincia")) = False Then
               txtProv.Text = dr.Item("Provincia").ToString
            Else
               txtProv.Text = String.Empty
            End If
            If IsDBNull(dr.Item("PIva")) = False Then
               txtPIva.Text = dr.Item("PIva").ToString
            Else
               txtPIva.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Iva")) = False Then
               txtIva.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Iva")))
            Else
               txtIva.Text = VALORE_ZERO
            End If
            If IsDBNull(dr.Item("Sconto")) = False Then
               txtValSconto.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(dr.Item("Sconto"))) & "%"
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
         If eui_cmdTipoPagamento.Text = "Carte di credito" Then
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

      If eui_cmdCliente.Text = "Seleziona cliente" Then
         Dim valRisposta As Integer
         valRisposta = MsgBox("Non è stato specificato il Cliente intestatario. Procedendo con l'operazione verrà stampato un documento senza intestazione. Effettuare comunque la stampa? ", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, NOME_PRODOTTO)
         If valRisposta = vbNo Then
            Return False
         Else
            Return True
         End If
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

   Public Sub StampaConto(ByVal nomeStampante As String)
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
            Case PERCORSO_REP_FF_A4, PERCORSO_REP_FF_A4_DOPPIA, PERCORSO_REP_FF_A4_IVA_MULTIPLA,
               PERCORSO_REP_RF_A4_DOPPIA, PERCORSO_REP_RF_A5, PERCORSO_REP_RF_A6,
                 PERCORSO_REP_PF_A4_DOPPIA, PERCORSO_REP_PF_A5, PERCORSO_REP_PF_A6,
                 PERCORSO_REP_PF_A4_DOPPIA_CENTRO_SPORTIVO, PERCORSO_REP_FF_A4_DOPPIA_CENTRO_SPORTIVO, PERCORSO_REP_RF_A4_DOPPIA_CENTRO_SPORTIVO,
                 PERCORSO_REP_RF_BELLA_NAPOLI, PERCORSO_REP_FF_BELLA_NAPOLI, PERCORSO_REP_PF_BELLA_NAPOLI,
                 PERCORSO_REP_RF_CELIDE, PERCORSO_REP_FF_CELIDE, PERCORSO_REP_PF_CELIDE,
                 PERCORSO_REP_RF_FORCHETTA_DORO, PERCORSO_REP_FF_FORCHETTA_DORO, PERCORSO_REP_PF_FORCHETTA_DORO

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
               eui_cmdTipoConto.Enabled = False
               eui_cmdDivisioneAnalitica.Enabled = False
               txtNumDoc.Enabled = False
               txtValSconto.Enabled = False
               txtServizio.Enabled = False

               txtContanti.Text = VALORE_ZERO
               txtCartaCredito.Text = VALORE_ZERO
               txtBuoni.Text = VALORE_ZERO

               AggiornaValoriConto()

               Exit Sub
            End If

         Else
            '' Se il conto non è stato stampato correttamente eliminare l'ultimo Documento.

            '' Apre la connessione.
            'cn.Open()

            '' Avvia una transazione.
            'tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

            '' Crea la stringa di eliminazione.
            'sql = String.Format("DELETE FROM {0} WHERE Id = {1}", TAB_DOC, LeggiUltimoRecord(TAB_DOC))

            '' Crea il comando per la connessione corrente.
            'Dim cmdDelete As New OleDbCommand(sql, cn, tr)

            '' Esegue il comando.
            'Dim Record As Integer = cmdDelete.ExecuteNonQuery()

            '' Conferma la transazione.
            'tr.Commit()

            '' Aggiorna (sottrae 1) il valore progressivo della numerazione de documento.
            'Dim NumeroDocumento As Integer = LeggiNumeroDocFiscaleConfig(TAB_DOC, tipoDocumento)
            'EliminaNumeroDocFiscaleConfig(TAB_DOC, tipoDocumento, NumeroDocumento)

            '' Permette di salvare un nuovo documento modificando i dati.
            'DocSalvato = False

            MessageBox.Show("E' possibile stampare ancora lo stesso documento con gli stessi dati! Nel caso si voglia modificare l'intestazione o gli importi del documento sara necessario annullarlo dall'Elenco Documenti e stamparne uno nuovo.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

            Exit Sub
         End If

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

   Public Sub StampaDocumento(ByVal nomeDoc As String, ByVal numDoc As Integer, ByVal nomeStampante As String)
      Try
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         ' Tabella Documenti.
         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_DOC & " WHERE Id = " & numDoc, cn)

         Dim ds As New HospitalityDataSet 'Dataset1 'utilizzato con Crystal Reports
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

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepDocumenti(ds, nomeDoc, nomeStampante)
         frm.ShowDialog()

         ' ---------------------------------------------------------------------------------
         ' NON UTILIZZATO! - Vecchio codice che utilizza CrystalReports.

         'Dim rep As New CrystalDecisions.CrystalReports.Engine.ReportDocument

         'rep.Load(Application.StartupPath & nomeDoc)

         'rep.SetDataSource(ds)

         'If nomeStampante <> String.Empty And nomeStampante <> "<Nessuna>" Then
         '   rep.PrintOptions.PrinterName = nomeStampante
         'End If

         '' Imposta il numero di copie del documento da stampare per il tipo di report.
         'PrintDialog1.PrinterSettings.Copies = NumeroCopieStampa

         'rep.PrintToPrinter(PrintDialog1.PrinterSettings.Copies, True,
         '          PrintDialog1.PrinterSettings.FromPage,
         '          PrintDialog1.PrinterSettings.ToPage)
         ' ---------------------------------------------------------------------------------

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Function SalvaDocumento() As Boolean
      Try
         Dim NumeroDocumento As Integer = LeggiNumeroDocFiscaleConfig(TAB_DOC, tipoDocumento)

         With Doc
            Dim valSospeso As Double = Convert.ToDouble(txtSospeso.Text)
            Dim valDaPagare As Double = Convert.ToDouble(netBtn_DaPagare.TextButton)

            .Numero = NumeroDocumento
            .Anno = Now.Year.ToString
            .Data = g_frmPos.dtpData.Value.Date
            .Ora = g_frmPos.lblOra.Text
            .Tipo = tipoDocumento
            .Stato = "Emesso e stampato"
            .Causale = "Vendita da ristorante"

            Select Case tipoCliente
               Case Cliente.Azienda
                  ' Viene aggiunta la lettera A per identificare le Aziende.
                  ' Codice aggiunto dopo la creazione della nuova anagrafica Aziende.
                  .IdCliente = "A" & g_frmContoPos.txtIdAzienda.Text
               Case Cliente.Privato
                  ' ID normale.
                  .IdCliente = g_frmContoPos.txtIdCliente.Text
            End Select

            If eui_cmdCliente.Text = "Seleziona cliente" Then
               .Cliente = String.Empty
            Else
               .Cliente = eui_cmdCliente.Text
            End If

            .Indirizzo = FormattaApici(txtIndirizzo.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .PIva = txtPIva.Text
            .CodFiscale = txtCodiceFiscale.Text
            .CodAzienda = String.Empty
            .Coperto = CFormatta.FormattaNumeroDouble(txtCoperto.Text)

            .Sconto = CFormatta.FormattaNumeroDouble(valSconto)
            If txtValSconto.Text.Contains("%") = True Then
               .TipoSconto = "%"
            Else
               .TipoSconto = String.Empty
            End If

            .Servizio = CFormatta.FormattaNumeroDouble(valServizio)
            If txtServizio.Text.Contains("%") = True Then
               .TipoServizio = "%"
            Else
               .TipoServizio = String.Empty
            End If

            .Contanti = CFormatta.FormattaNumeroDouble(txtContanti.Text)
            .Carte = CFormatta.FormattaNumeroDouble(txtCartaCredito.Text)
            .BuoniPasto = CFormatta.FormattaNumeroDouble(txtBuoni.Text)
            .BuoniPastoIncassare = CFormatta.FormattaNumeroDouble(txtBuoni.Text)
            .Note = String.Empty
            .Chiuso = "No"

            If txtCartaCredito.Text <> VALORE_ZERO Then
               .TipoPagamento = eui_cmdTipoPagamento.Text & ": € " & CFormatta.FormattaNumeroDouble(txtCartaCredito.Text)
            Else
               If txtContanti.Text <> VALORE_ZERO Then
                  .TipoPagamento = "Contanti"
               Else
                  .TipoPagamento = String.Empty
               End If
            End If

            .Tavolo = nomeTavoloDoc
            .Cameriere = nomeCameriereDoc
            .Sospeso = CFormatta.FormattaNumeroDouble(valSospeso)
            .SospesoIncassare = CFormatta.FormattaNumeroDouble(valSospeso)
            .TotDoc = CFormatta.FormattaNumeroDouble(Convert.ToDouble(valDaPagare))

            ' SCHEDA PA.
            .NumeroDoc_PA = String.Empty
            .CodiceCUP_PA = String.Empty
            .CodiceCIG_PA = String.Empty
            .CodiceCommConv_PA = String.Empty

            ' Se Fattura, Ricevuta o Scontrino salva l'iva...
            If tipoDocumento = TIPO_DOC_FF Or tipoDocumento = TIPO_DOC_RF Or tipoDocumento = TIPO_DOC_SF Then
               Dim importo1 As Double
               Dim importo2 As Double
               Dim importo3 As Double
               Dim importo4 As Double

               Dim percIva1 As Integer
               Dim percIva2 As Integer
               Dim percIva3 As Integer
               Dim percIva4 As Integer

               Dim valTotaleImpostaRep1 As Double
               Dim valTotaleImpostaRep2 As Double
               Dim valTotaleImpostaRep3 As Double
               Dim valTotaleImpostaRep4 As Double

               Dim valTotaleImponibile1 As Double
               Dim valTotaleImponibile2 As Double
               Dim valTotaleImponibile3 As Double
               Dim valTotaleImponibile4 As Double

               Dim numTotaleImporti As Integer
               Dim valCopertoDiviso As Double
               Dim valServizioDiviso As Double
               Dim valScontoDiviso As Double
               Dim valCoperto As Double = CFormatta.FormattaNumeroDouble(txtCoperto.Text)

               Dim K As Integer
               For K = 0 To lstvDettagli.Items.Count - 1
                  ' Conta il numero degli importi validi. 
                  If IsNumeric(lstvDettagli.Items(K).SubItems(4).Text) = True And lstvDettagli.Items(K).SubItems(4).Text <> VALORE_ZERO Then
                     ' Conta il numero degli importi validi. 
                     numTotaleImporti += 1
                  End If
               Next

               ' COPERTO - Divide il valore del COPERTO per il numero di elementi (Piatti) presenti nella lista.
               valCopertoDiviso = valCoperto / numTotaleImporti

               ' SERVIZIO - Divide il valore del SERVIZIO per il numero di elementi (Piatti) presenti nella lista.
               valServizioDiviso = valServizio / numTotaleImporti

               ' SCONTO - Divide il valore dello SCONTO per il numero di elementi (Piatti) presenti nella lista.
               valScontoDiviso = valSconto / numTotaleImporti

               ' Somma tutti gli importi delle righe del documento.
               Dim j As Integer
               For j = 0 To lstvDettagli.Items.Count - 1

                  Select Case VerificaAliquotaIva(lstvDettagli.Items(j).SubItems(5).Text)

                     Case "Reparto 1"
                        importo1 = Convert.ToDouble(lstvDettagli.Items(j).SubItems(4).Text)
                        importo1 = (importo1 + valCopertoDiviso + valServizioDiviso) - valScontoDiviso
                        percIva1 = Convert.ToInt32(lstvDettagli.Items(j).SubItems(5).Text)
                        valTotaleImponibile1 = valTotaleImponibile1 + CalcolaImponibileIva(percIva1.ToString, importo1)
                        valTotaleImpostaRep1 = CalcolaPercentuale(valTotaleImponibile1, percIva1)

                     Case "Reparto 2"
                        importo2 = Convert.ToDouble(lstvDettagli.Items(j).SubItems(4).Text)
                        importo2 = (importo2 + valCopertoDiviso + valServizioDiviso) - valScontoDiviso
                        percIva2 = Convert.ToInt32(lstvDettagli.Items(j).SubItems(5).Text)
                        valTotaleImponibile2 = valTotaleImponibile2 + CalcolaImponibileIva(percIva2.ToString, importo2)
                        valTotaleImpostaRep2 = CalcolaPercentuale(valTotaleImponibile2, percIva2)

                     Case "Reparto 3"
                        importo3 = Convert.ToDouble(lstvDettagli.Items(j).SubItems(4).Text)
                        importo3 = (importo3 + valCopertoDiviso + valServizioDiviso) - valScontoDiviso
                        percIva3 = Convert.ToInt32(lstvDettagli.Items(j).SubItems(5).Text)
                        valTotaleImponibile3 = valTotaleImponibile3 + CalcolaImponibileIva(percIva3.ToString, importo3)
                        valTotaleImpostaRep3 = CalcolaPercentuale(valTotaleImponibile3, percIva3)

                     Case "Reparto 4"
                        importo4 = Convert.ToDouble(lstvDettagli.Items(j).SubItems(4).Text)
                        importo4 = (importo4 + valCopertoDiviso + valServizioDiviso) - valScontoDiviso
                        percIva4 = Convert.ToInt32(lstvDettagli.Items(j).SubItems(5).Text)
                        valTotaleImponibile4 = valTotaleImponibile4 + CalcolaImponibileIva(percIva4.ToString, importo4)
                        valTotaleImpostaRep4 = CalcolaPercentuale(valTotaleImponibile4, percIva4)

                  End Select
               Next

               ' Aggiorna i totali.

               ' Aliquote Iva.
               .AliquotaIvaRep1 = percIva1.ToString
               .AliquotaIvaRep2 = percIva2.ToString
               .AliquotaIvaRep3 = percIva3.ToString
               .AliquotaIvaRep4 = percIva4.ToString

               ' Imponibile.
               .ImpLordoRep1 = CFormatta.FormattaEuro(valTotaleImponibile1)
               .ImpLordoRep2 = CFormatta.FormattaEuro(valTotaleImponibile2)
               .ImpLordoRep3 = CFormatta.FormattaEuro(valTotaleImponibile3)
               .ImpLordoRep4 = CFormatta.FormattaEuro(valTotaleImponibile4)

               ' Imposte.
               .ImpostaRep1 = CFormatta.FormattaEuro(valTotaleImpostaRep1)
               .ImpostaRep2 = CFormatta.FormattaEuro(valTotaleImpostaRep2)
               .ImpostaRep3 = CFormatta.FormattaEuro(valTotaleImpostaRep3)
               .ImpostaRep4 = CFormatta.FormattaEuro(valTotaleImpostaRep4)

               ' Imponibile totale.
               .Imponibile = CFormatta.FormattaEuro((valTotaleImponibile1 + valTotaleImponibile2 + valTotaleImponibile3 + valTotaleImponibile4))

               ' Imposta totale.
               .Imposta = CFormatta.FormattaEuro((valTotaleImpostaRep1 + valTotaleImpostaRep2 + valTotaleImpostaRep3 + valTotaleImpostaRep4))

               ' DA_FARE: Non più usata.
               .Iva = VALORE_ZERO
            Else
               ' Aliquote Iva.
               .AliquotaIvaRep1 = VALORE_ZERO
               .AliquotaIvaRep2 = VALORE_ZERO
               .AliquotaIvaRep3 = VALORE_ZERO
               .AliquotaIvaRep4 = VALORE_ZERO

               ' Imponibile.
               .ImpLordoRep1 = VALORE_ZERO
               .ImpLordoRep2 = VALORE_ZERO
               .ImpLordoRep3 = VALORE_ZERO
               .ImpLordoRep4 = VALORE_ZERO

               ' Imposte.
               .ImpostaRep1 = VALORE_ZERO
               .ImpostaRep2 = VALORE_ZERO
               .ImpostaRep3 = VALORE_ZERO
               .ImpostaRep4 = VALORE_ZERO

               ' DA_FARE: Non più usata.
               .Iva = VALORE_ZERO
               .Imponibile = VALORE_ZERO
               .Imposta = VALORE_ZERO
            End If

            .InserisciDati(TAB_DOC)
         End With

         ' SALVA I DETTAGLI DEL DOCUMENTO.
         Dim sql As String
         ' Apre la connessione.
         cn.Open()

         If eui_cmdTipoConto.Text.ToUpper = "UNICO" Then
            ' SALVA I DETTAGLI PER IL COPERTO.
            If Doc.Coperto <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di inserimento.
               sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOC)

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOC))
               cmdInsert.Parameters.AddWithValue("@CodiceArticolo", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Descrizione", "COPERTO")
               cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Quantità", NumCopertiRistorante)
               cmdInsert.Parameters.AddWithValue("@ValoreUnitario", CopertoRistorante) ' B_TODO: Modifica per Retail.
               cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
               cmdInsert.Parameters.AddWithValue("@ImportoNetto", Doc.Coperto)
               cmdInsert.Parameters.AddWithValue("@AliquotaIva", "0")
               cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)

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
            ' Crea la stringa di inserimento dati.
            sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOC)

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)

            ' In caso di variante senza una quantità.
            Dim quantità As String
            If lstvDettagli.Items(i).SubItems(1).Text <> String.Empty Then
               quantità = lstvDettagli.Items(i).SubItems(1).Text
            Else
               quantità = VALORE_ZERO
            End If

            cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOC))
            cmdInsert.Parameters.AddWithValue("@CodiceArticolo", lstvDettagli.Items(i).SubItems(6).Text)
            cmdInsert.Parameters.AddWithValue("@Descrizione", FormattaApici(lstvDettagli.Items(i).SubItems(2).Text))
            cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
            cmdInsert.Parameters.AddWithValue("@Quantità", quantità)
            cmdInsert.Parameters.AddWithValue("@ValoreUnitario", lstvDettagli.Items(i).SubItems(3).Text) ' B_TODO: Modifica per Retail.
            cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
            cmdInsert.Parameters.AddWithValue("@ImportoNetto", lstvDettagli.Items(i).SubItems(4).Text)
            cmdInsert.Parameters.AddWithValue("@AliquotaIva", lstvDettagli.Items(i).SubItems(5).Text)
            cmdInsert.Parameters.AddWithValue("@Categoria", lstvDettagli.Items(i).SubItems(7).Text)

            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()

            'End If
         Next

         If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
            ' SALVA I DETTAGLI PER IL SERVIZIO.
            If Doc.Servizio <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di inserimento.
               sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOC)

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOC))
               cmdInsert.Parameters.AddWithValue("@CodiceArticolo", String.Empty)

               If Doc.TipoServizio <> String.Empty Then
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SERVIZIO" & txtServizio.Text)
               Else
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SERVIZIO")
               End If

               cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Quantità", "1")
               cmdInsert.Parameters.AddWithValue("@ValoreUnitario", Doc.Servizio) ' B_TODO: Modifica per Retail.
               cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
               cmdInsert.Parameters.AddWithValue("@ImportoNetto", Doc.Servizio)
               cmdInsert.Parameters.AddWithValue("@AliquotaIva", 0)
               cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)

               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

         If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
            ' SALVA I DETTAGLI PER LO SCONTO.
            If Doc.Sconto <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di inserimento.
               sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOC)

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOC))
               cmdInsert.Parameters.AddWithValue("@CodiceArticolo", String.Empty)

               If Doc.TipoSconto <> String.Empty Then
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SCONTO " & txtValSconto.Text)
               Else
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SCONTO")
               End If

               cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Quantità", "1")
               cmdInsert.Parameters.AddWithValue("@ValoreUnitario", "-" & Doc.Sconto) ' B_TODO: Modifica per Retail.
               cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
               cmdInsert.Parameters.AddWithValue("@ImportoNetto", "-" & Doc.Sconto)
               cmdInsert.Parameters.AddWithValue("@AliquotaIva", 0)
               cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)

               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

         ' Salva il Numero del prossimo documento da stampare.
         SalvaNumeroDocFiscaleConfig(TAB_DOC, tipoDocumento, NumeroDocumento)

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

   Private Function SalvaConto(ByVal numConto As String, ByVal noteDoc As String) As Integer
      Try
         Dim NumeroDocumento As Integer
         If numConto = String.Empty Then
            NumeroDocumento = LeggiNumeroMax(TAB_DOC, TIPO_DOC_CO) + 1
         Else
            NumeroDocumento = Convert.ToInt32(numConto)
         End If

         With Doc
            Dim valSospeso As Double = Convert.ToDouble(txtSospeso.Text)
            Dim valDaPagare As Double = Convert.ToDouble(netBtn_DaPagare.TextButton)

            .Numero = NumeroDocumento
            .Anno = Now.Year.ToString
            .Data = g_frmPos.dtpData.Value.Date
            .Ora = g_frmPos.lblOra.Text
            .Tipo = TIPO_DOC_CO
            .Stato = "Aperto"
            .Causale = "Conto"

            Select Case tipoCliente
               Case Cliente.Azienda
                  ' Viene aggiunta la lettera A per identificare le Aziende.
                  ' Codice aggiunto dopo la creazione della nuova anagrafica Aziende.
                  .IdCliente = "A" & g_frmContoPos.txtIdAzienda.Text
               Case Cliente.Privato
                  ' ID normale.
                  .IdCliente = g_frmContoPos.txtIdCliente.Text
            End Select

            If eui_cmdCliente.Text = "Seleziona cliente" Then
               .Cliente = String.Empty
            Else
               .Cliente = eui_cmdCliente.Text
            End If

            .Indirizzo = FormattaApici(txtIndirizzo.Text)
            .Cap = FormattaApici(txtCap.Text)
            .Città = FormattaApici(txtCittà.Text)
            .Provincia = FormattaApici(txtProv.Text)
            .PIva = txtPIva.Text
            .CodFiscale = txtCodiceFiscale.Text
            .CodAzienda = String.Empty
            .Coperto = CFormatta.FormattaNumeroDouble(txtCoperto.Text)
            .Sconto = CFormatta.FormattaNumeroDouble(valSconto)

            '.TipoSconto = txtValSconto.Text
            If txtValSconto.Text.Contains("%") = True Then
               .TipoSconto = "%"
            Else
               .TipoSconto = String.Empty
            End If

            .Servizio = CFormatta.FormattaNumeroDouble(valServizio)
            '.TipoServizio = txtServizio.Text
            If txtServizio.Text.Contains("%") = True Then
               .TipoServizio = "%"
            Else
               .TipoServizio = String.Empty
            End If

            .Contanti = CFormatta.FormattaNumeroDouble(txtContanti.Text)
            .Carte = CFormatta.FormattaNumeroDouble(txtCartaCredito.Text)
            .BuoniPasto = CFormatta.FormattaNumeroDouble(txtBuoni.Text)
            .BuoniPastoIncassare = CFormatta.FormattaNumeroDouble(txtBuoni.Text)
            .Chiuso = "No"
            .Note = noteDoc

            If txtCartaCredito.Text <> VALORE_ZERO Then
               .TipoPagamento = eui_cmdTipoPagamento.Text & ": € " & CFormatta.FormattaNumeroDouble(txtCartaCredito.Text)
            Else
               If txtContanti.Text <> VALORE_ZERO Then
                  .TipoPagamento = "Contanti"
               Else
                  .TipoPagamento = String.Empty
               End If
            End If

            .Tavolo = nomeTavoloDoc
            .Cameriere = nomeCameriereDoc
            .Sospeso = CFormatta.FormattaNumeroDouble(valSospeso)
            .SospesoIncassare = CFormatta.FormattaNumeroDouble(valSospeso)
            .TotDoc = CFormatta.FormattaNumeroDouble(Convert.ToDouble(valDaPagare))

            ' Aliquote Iva.
            .AliquotaIvaRep1 = VALORE_ZERO
            .AliquotaIvaRep2 = VALORE_ZERO
            .AliquotaIvaRep3 = VALORE_ZERO
            .AliquotaIvaRep4 = VALORE_ZERO

            ' Imponibile.
            .ImpLordoRep1 = VALORE_ZERO
            .ImpLordoRep2 = VALORE_ZERO
            .ImpLordoRep3 = VALORE_ZERO
            .ImpLordoRep4 = VALORE_ZERO

            ' Imposte.
            .ImpostaRep1 = VALORE_ZERO
            .ImpostaRep2 = VALORE_ZERO
            .ImpostaRep3 = VALORE_ZERO
            .ImpostaRep4 = VALORE_ZERO

            ' DA_FARE: Non più usata.
            .Iva = VALORE_ZERO
            .Imponibile = VALORE_ZERO
            .Imposta = VALORE_ZERO

            .InserisciDati(TAB_DOC)
         End With

         ' SALVA I DETTAGLI DEL DOCUMENTO.
         Dim sql As String
         ' Apre la connessione.
         cn.Open()

         If eui_cmdTipoConto.Text.ToUpper = "UNICO" Then
            ' SALVA I DETTAGLI PER IL COPERTO.
            If Doc.Coperto <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di inserimento.
               sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOC)


               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOC))
               cmdInsert.Parameters.AddWithValue("@CodiceArticolo", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Descrizione", "COPERTO")
               cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Quantità", NumCopertiRistorante)
               cmdInsert.Parameters.AddWithValue("@ValoreUnitario", CopertoRistorante) ' B_TODO: Modifica per Retail.
               cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
               cmdInsert.Parameters.AddWithValue("@ImportoNetto", Doc.Coperto)
               cmdInsert.Parameters.AddWithValue("@AliquotaIva", "0")
               cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)

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
            ' Crea la stringa di inserimento dati.
            sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOC)

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)

            ' In caso di variante senza una quantità.
            Dim quantità As String
            If lstvDettagli.Items(i).SubItems(1).Text <> String.Empty Then
               quantità = lstvDettagli.Items(i).SubItems(1).Text
            Else
               quantità = VALORE_ZERO
            End If

            cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOC))
            cmdInsert.Parameters.AddWithValue("@CodiceArticolo", lstvDettagli.Items(i).SubItems(6).Text)
            cmdInsert.Parameters.AddWithValue("@Descrizione", FormattaApici(lstvDettagli.Items(i).SubItems(2).Text))
            cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
            cmdInsert.Parameters.AddWithValue("@Quantità", quantità)
            cmdInsert.Parameters.AddWithValue("@ValoreUnitario", lstvDettagli.Items(i).SubItems(3).Text) ' B_TODO: Modifica per Retail.
            cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
            cmdInsert.Parameters.AddWithValue("@ImportoNetto", lstvDettagli.Items(i).SubItems(4).Text)
            cmdInsert.Parameters.AddWithValue("@AliquotaIva", lstvDettagli.Items(i).SubItems(5).Text)
            cmdInsert.Parameters.AddWithValue("@Categoria", lstvDettagli.Items(i).SubItems(7).Text)

            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()

            'End If
         Next

         If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
            ' SALVA I DETTAGLI PER LO SCONTO.
            If Doc.Sconto <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di inserimento.
               sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOC)

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOC))
               cmdInsert.Parameters.AddWithValue("@CodiceArticolo", String.Empty)

               If Doc.TipoSconto <> String.Empty Then
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SCONTO " & txtValSconto.Text)
               Else
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SCONTO")
               End If

               cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Quantità", "1")
               cmdInsert.Parameters.AddWithValue("@ValoreUnitario", "-" & Doc.Sconto) ' B_TODO: Modifica per Retail.
               cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
               cmdInsert.Parameters.AddWithValue("@ImportoNetto", "-" & Doc.Sconto)
               cmdInsert.Parameters.AddWithValue("@AliquotaIva", 0)
               cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)

               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

         If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
            ' SALVA I DETTAGLI PER IL SERVIZIO.
            If Doc.Servizio <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di inserimento.
               sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOC)

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOC))
               cmdInsert.Parameters.AddWithValue("@CodiceArticolo", String.Empty)

               If Doc.TipoServizio <> String.Empty Then
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SERVIZIO" & txtServizio.Text)
               Else
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SERVIZIO")
               End If

               cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Quantità", "1")
               cmdInsert.Parameters.AddWithValue("@ValoreUnitario", Doc.Servizio) ' B_TODO: Modifica per Retail.
               cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
               cmdInsert.Parameters.AddWithValue("@ImportoNetto", Doc.Servizio)
               cmdInsert.Parameters.AddWithValue("@AliquotaIva", 0)
               cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)

               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

         Return NumeroDocumento

      Catch ex As Exception
         ' Annulla transazione.
         tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function AddebitaConto(ByVal RifPren As String, ByVal totContoPren As String) As Boolean
      Try
         Dim totaleImporto As Double = totContoPren

         Doc.Sconto = CFormatta.FormattaNumeroDouble(valSconto)
         If txtValSconto.Text.Contains("%") = True Then
            Doc.TipoSconto = "%"
         Else
            Doc.TipoSconto = String.Empty
         End If

         Doc.Servizio = CFormatta.FormattaNumeroDouble(valServizio)
         If txtServizio.Text.Contains("%") = True Then
            Doc.TipoServizio = "%"
         Else
            Doc.TipoServizio = String.Empty
         End If

         ' SALVA I DETTAGLI PER I PIATTI.
         Dim i As Integer
         For i = 0 To lstvDettagli.Items.Count - 1

            ' In caso di variante senza una quantità.
            Dim quantità As String
            If lstvDettagli.Items(i).SubItems(1).Text <> String.Empty Then
               quantità = lstvDettagli.Items(i).SubItems(1).Text
            Else
               quantità = VALORE_ZERO
            End If

            ' Data.
            g_frmPrenCamera.lvwAddebiti.Items.Add(Today.ToShortDateString)

            ' Descrizione.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(FormattaApici(lstvDettagli.Items(i).SubItems(2).Text))

            ' Imposta il gruppo di appartenenza Bar/Ristorante.
            Dim valGruppo As Short = 3

            ' Assegna il gruppo.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).Group = g_frmPrenCamera.lvwAddebiti.Groups.Item(valGruppo)
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).ForeColor = Color.FromArgb(Color.Green.ToArgb)

            ' Quantità.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(quantità)

            ' Costo.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(lstvDettagli.Items(i).SubItems(4).Text)

            ' Codice.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(lstvDettagli.Items(i).SubItems(6).Text)

            ' Indice.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(String.Empty)

            ' Aliquota Iva.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(lstvDettagli.Items(i).SubItems(5).Text)

            ' Categoria.
            g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(lstvDettagli.Items(i).SubItems(7).Text)

            ' Aggiorna i valore del conto con i nuovi elementi della lista.
            If IsNumeric(lstvDettagli.Items(i).SubItems(4).Text) = True Then
               totaleImporto = totaleImporto + Convert.ToDouble(lstvDettagli.Items(i).SubItems(4).Text)
            End If
         Next

         ' SALVA I DETTAGLI PER LO SCONTO.
         If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
            If Doc.Sconto <> VALORE_ZERO Then

               ' Data.
               g_frmPrenCamera.lvwAddebiti.Items.Add(Today.ToShortDateString)

               ' Descrizione.
               If Doc.TipoSconto <> String.Empty Then
                  g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add("SCONTO " & txtValSconto.Text)
               Else
                  g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add("SCONTO")
               End If

               ' Imposta il gruppo di appartenenza Bar/Ristorante.
               Dim valGruppo As Short = 3

               ' Assegna il gruppo.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).Group = g_frmPrenCamera.lvwAddebiti.Groups.Item(valGruppo)
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).ForeColor = Color.FromArgb(Color.Green.ToArgb)

               ' Quantità.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(1)

               ' Costo.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add("-" & Doc.Sconto)

               ' Codice.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(String.Empty)

               ' Indice.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(String.Empty)

               ' Aliquota Iva.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(0)

               ' Categoria.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(String.Empty)
            End If
         End If

         ' SALVA I DETTAGLI PER IL SERVIZIO.
         If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
            If Doc.Servizio <> VALORE_ZERO Then

               ' Data.
               g_frmPrenCamera.lvwAddebiti.Items.Add(Today.ToShortDateString)

               ' Descrizione.
               If Doc.TipoSconto <> String.Empty Then
                  g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add("SERVIZIO" & txtServizio.Text)
               Else
                  g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add("SERVIZIO")
               End If

               ' Imposta il gruppo di appartenenza Bar/Ristorante.
               Dim valGruppo As Short = 3

               ' Assegna il gruppo.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).Group = g_frmPrenCamera.lvwAddebiti.Groups.Item(valGruppo)
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).ForeColor = Color.FromArgb(Color.Green.ToArgb)

               ' Quantità.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(1)

               ' Costo.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(Doc.Servizio)

               ' Codice.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(String.Empty)

               ' Indice.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(String.Empty)

               ' Aliquota Iva.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(AliquotaIvaRistorante)

               ' Categoria.
               g_frmPrenCamera.lvwAddebiti.Items(g_frmPrenCamera.lvwAddebiti.Items.Count - 1).SubItems.Add(String.Empty)

            End If
         End If

         ' Aggiunge Coperto, Servizio e Sconto.
         totaleImporto = totaleImporto + valServizio - valSconto

         ' Aggiorna il totale del conto della prenotazione camera.
         g_frmPrenCamera.CalcolaTotaleAddebiti()
         g_frmPrenCamera.CalcolaTotaleConto()

         Return True

      Catch ex As Exception

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Function SalvaAddebitoConto(ByVal RifPren As String, ByVal totContoPren As String) As Boolean
      Try
         Dim totaleImporto As Double = totContoPren
         Dim valCoperto As Double
         Dim sql As String

         If IsNumeric(txtCoperto.Text) = True Then
            valCoperto = Convert.ToDouble(txtCoperto.Text)
         End If

         Doc.Coperto = CFormatta.FormattaNumeroDouble(valCoperto)
         Doc.Sconto = CFormatta.FormattaNumeroDouble(valSconto)

         If txtValSconto.Text.Contains("%") = True Then
            Doc.TipoSconto = "%"
         Else
            Doc.TipoSconto = String.Empty
         End If

         Doc.Servizio = CFormatta.FormattaNumeroDouble(valServizio)
         If txtServizio.Text.Contains("%") = True Then
            Doc.TipoServizio = "%"
         Else
            Doc.TipoServizio = String.Empty
         End If

         ' Apre la connessione.
         cn.Open()

         If eui_cmdTipoConto.Text.ToUpper = "UNICO" Then
            ' SALVA I DETTAGLI PER IL COPERTO.
            If Doc.Coperto <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di inserimento.
               sql = String.Format("INSERT INTO {0} (RifPren, Data, Codice, Descrizione, Quantità, Importo, AliquotaIva, Categoria, Colore, Gruppo) " &
                                   "VALUES(@RifPren, @Data, @Codice, @Descrizione, @Quantità, @Importo, @AliquotaIva, @Categoria, @Colore, @Gruppo)", TAB_PREN_CAMERE_ADDEBITI)

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               cmdInsert.Parameters.AddWithValue("@RifPren", RifPren)
               cmdInsert.Parameters.AddWithValue("@Data", Today.ToShortDateString)
               cmdInsert.Parameters.AddWithValue("@Codice", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Descrizione", "COPERTO")
               cmdInsert.Parameters.AddWithValue("@Quantità", NumCopertiRistorante)
               cmdInsert.Parameters.AddWithValue("@Importo", Doc.Coperto)
               cmdInsert.Parameters.AddWithValue("@AliquotaIva", AliquotaIvaRistorante)
               cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Colore", Convert.ToString(Color.Green.ToArgb))
               cmdInsert.Parameters.AddWithValue("@Gruppo", "Bar/Ristorante")

               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

         ' SALVA I DETTAGLI PER I PIATTI.
         Dim i As Integer
         For i = 0 To lstvDettagli.Items.Count - 1

            ' Avvia una transazione.
            tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
            ' Crea la stringa di inserimento dati.
            sql = String.Format("INSERT INTO {0} (RifPren, Data, Codice, Descrizione, Quantità, Importo, AliquotaIva, Categoria, Colore, Gruppo) " &
                                "VALUES(@RifPren, @Data, @Codice, @Descrizione, @Quantità, @Importo, @AliquotaIva, @Categoria, @Colore, @Gruppo)", TAB_PREN_CAMERE_ADDEBITI)

            ' Crea il comando per la connessione corrente.
            Dim cmdInsert As New OleDbCommand(sql, cn, tr)

            ' In caso di variante senza una quantità.
            Dim quantità As String
            If lstvDettagli.Items(i).SubItems(1).Text <> String.Empty Then
               quantità = lstvDettagli.Items(i).SubItems(1).Text
            Else
               quantità = VALORE_ZERO
            End If

            cmdInsert.Parameters.AddWithValue("@RifPren", RifPren)
            cmdInsert.Parameters.AddWithValue("@Data", Today.ToShortDateString)
            cmdInsert.Parameters.AddWithValue("@Codice", lstvDettagli.Items(i).SubItems(6).Text)
            cmdInsert.Parameters.AddWithValue("@Descrizione", FormattaApici(lstvDettagli.Items(i).SubItems(2).Text))
            cmdInsert.Parameters.AddWithValue("@Quantità", quantità)
            cmdInsert.Parameters.AddWithValue("@Importo", lstvDettagli.Items(i).SubItems(4).Text)
            cmdInsert.Parameters.AddWithValue("@AliquotaIva", lstvDettagli.Items(i).SubItems(5).Text)
            cmdInsert.Parameters.AddWithValue("@Categoria", lstvDettagli.Items(i).SubItems(7).Text)
            cmdInsert.Parameters.AddWithValue("@Colore", Convert.ToString(Color.Green.ToArgb))
            cmdInsert.Parameters.AddWithValue("@Gruppo", "Bar/Ristorante")

            ' Esegue il comando.
            Dim Record As Integer = cmdInsert.ExecuteNonQuery()
            ' Conferma transazione.
            tr.Commit()

            ' Aggiorna i valore del conto con i nuovi elementi della lista.
            If IsNumeric(lstvDettagli.Items(i).SubItems(4).Text) = True Then
               totaleImporto = totaleImporto + Convert.ToDouble(lstvDettagli.Items(i).SubItems(4).Text)
            End If
         Next

         If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
            ' SALVA I DETTAGLI PER LO SCONTO.
            If Doc.Sconto <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di inserimento.
               sql = String.Format("INSERT INTO {0} (RifPren, Data, Codice, Descrizione, Quantità, Importo, AliquotaIva, Categoria, Colore, Gruppo) " &
                                "VALUES(@RifPren, @Data, @Codice, @Descrizione, @Quantità, @Importo, @AliquotaIva, @Categoria, @Colore, @Gruppo)", TAB_PREN_CAMERE_ADDEBITI)

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               cmdInsert.Parameters.AddWithValue("@RifPren", RifPren)
               cmdInsert.Parameters.AddWithValue("@Data", Today.ToShortDateString)
               cmdInsert.Parameters.AddWithValue("@Codice", String.Empty)

               If Doc.TipoSconto <> String.Empty Then
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SCONTO " & txtValSconto.Text)
               Else
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SCONTO")
               End If

               cmdInsert.Parameters.AddWithValue("@Quantità", "1")
               cmdInsert.Parameters.AddWithValue("@Importo", "-" & Doc.Sconto)
               cmdInsert.Parameters.AddWithValue("@AliquotaIva", 0)
               cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Colore", Convert.ToString(Color.Green.ToArgb))
               cmdInsert.Parameters.AddWithValue("@Gruppo", "Bar/Ristorante")

               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

         If eui_cmdTipoConto.Text.ToUpper <> "ALLA ROMANA" Then
            ' SALVA I DETTAGLI PER IL SERVIZIO.
            If Doc.Servizio <> VALORE_ZERO Then
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di inserimento.
               sql = String.Format("INSERT INTO {0} (RifPren, Data, Codice, Descrizione, Quantità, Importo, AliquotaIva, Categoria, Colore, Gruppo) " &
                                "VALUES(@RifPren, @Data, @Codice, @Descrizione, @Quantità, @Importo, @AliquotaIva, @Categoria, @Colore, @Gruppo)", TAB_PREN_CAMERE_ADDEBITI)

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               cmdInsert.Parameters.AddWithValue("@RifPren", RifPren)
               cmdInsert.Parameters.AddWithValue("@Data", Today.ToShortDateString)
               cmdInsert.Parameters.AddWithValue("@Codice", String.Empty)

               If Doc.TipoServizio <> String.Empty Then
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SERVIZIO" & txtServizio.Text)
               Else
                  cmdInsert.Parameters.AddWithValue("@Descrizione", "SERVIZIO")
               End If

               cmdInsert.Parameters.AddWithValue("@Quantità", "1")
               cmdInsert.Parameters.AddWithValue("@Importo", Doc.Servizio)
               cmdInsert.Parameters.AddWithValue("@AliquotaIva", AliquotaIvaRistorante)
               cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)
               cmdInsert.Parameters.AddWithValue("@Colore", Convert.ToString(Color.Green.ToArgb))
               cmdInsert.Parameters.AddWithValue("@Gruppo", "Bar/Ristorante")

               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            End If
         End If

         ' Chiude la connessione.
         cn.Close()

         ' Aggiunge Coperto, Servizio e Sconto.
         totaleImporto = totaleImporto + valCoperto + valServizio - valSconto

         ' Aggiorna il totale del conto della prenotazione camera.
         ModificaTotaleContoPrenCamera(TAB_PREN_CAMERE, RifPren, totaleImporto)

         ' Se aperta aggiorna i dati della finestra Elenco prenotazioni camera per visualizzare i nuovi importi.
         If IsNothing(g_frmPrenCamere) = False Then
            g_frmPrenCamere.AggiornaDati()
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
         If cn.State = ConnectionState.Open Then
            cn.Close()
         End If

      End Try
   End Function

   Public Function ModificaTotaleContoPrenCamera(ByVal tabella As String, ByVal idPren As Double, ByVal totConto As Double) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET TotaleConto = '{1}' " &
                             "WHERE Id = {2}",
                             tabella,
                             totConto,
                             idPren)

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

   Private Function VerificaAliquotaIva(ByVal valIva As String) As String
      Try
         Select Case valIva
            Case LeggiAliquotaIva("Reparto 1")
               Return "Reparto 1"

            Case LeggiAliquotaIva("Reparto 2")
               Return "Reparto 2"

            Case LeggiAliquotaIva("Reparto 3")
               Return "Reparto 3"

            Case LeggiAliquotaIva("Reparto 4")
               Return "Reparto 4"

            Case Else
               Return String.Empty

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      End Try
   End Function

   Private Sub FormattaControlloAttivo(ByVal controllo As Control)
      Try
         If IsNothing(controllo) = True Then
            Exit Sub
         End If

         If formatta = True Then
            Dim perc As Integer = controllo.Text.IndexOf("%")

            If IsNumeric(controllo.Text) = True Then
               controllo.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(controllo.Text))

            ElseIf perc <> -1 Then
               Dim val As String = controllo.Text.Replace("%", "")
               controllo.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(val)) & "%"
            Else
               controllo.Text = VALORE_ZERO
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub AggiornaValoriConto()
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

         If controlloAttivo Is Nothing = False Then
            If controlloAttivo.Text = String.Empty Then
               controlloAttivo.Text = VALORE_ZERO
            End If
         Else
            Exit Sub
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

         If eui_cmdTipoConto.Text.ToUpper = "SEPARATO MANUALE" Then
            If lstvElencoDocAperti.Items.Count <> 0 Then
               lstvElencoDocAperti.Focus()
               valTotConto = Convert.ToDouble(lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(2).Text)
            End If
         Else
            valTotConto = Convert.ToDouble(txtTotaleConto.Text)
         End If

         ' Calcola il valore del coperto.
         valCoperto = Convert.ToDouble(txtCoperto.Text)

         If eui_cmdTipoConto.Text.ToUpper <> "SEPARATO MANUALE" Then
            ' Calcola il valore da pagare + il coperto.
            valTotConto = (valTotConto + valCoperto)
         End If

         ' Calcola il valore del servizio.
         If IsNumeric(txtServizio.Text) = False Then
            ' Gestito a percentuale.
            Dim percServizio As Integer = txtServizio.Text.IndexOf("%")
            If percServizio <> -1 Then

               servizio = Convert.ToDouble(txtServizio.Text.Remove(txtServizio.Text.Length - 1, 1))
               valServizio = CalcolaPercentuale(valTotConto, servizio)
            Else
               valServizio = 0
               txtServizio.Text = VALORE_ZERO
            End If
         Else
            ' Gestito a valore.
            valServizio = Convert.ToDouble(txtServizio.Text)
         End If

         ' Calcola il valore da pagare + il servizio.
         valTotConto = (valTotConto + valServizio)

         ' Calcola il valore dello sconto.
         If IsNumeric(txtValSconto.Text) = False Then
            ' Gestito a percentuale.
            Dim percSconto As Integer = txtValSconto.Text.IndexOf("%")
            If percSconto <> -1 Then
               sconto = Convert.ToDouble(txtValSconto.Text.Remove(txtValSconto.Text.Length - 1, 1))
               valSconto = CalcolaPercentuale(valTotConto, sconto)
            Else
               valSconto = 0
               txtValSconto.Text = VALORE_ZERO
            End If
         Else
            ' Gestito a valore.
            valSconto = Convert.ToDouble(txtValSconto.Text)
         End If

         ' Calcola il valore da pagare..
         Dim valDaPagare As Double = (valTotConto - valSconto)
         netBtn_DaPagare.TextButton = CFormatta.FormattaEuro(valDaPagare)

         Select Case eui_cmdTipoConto.Text.ToUpper
            Case "UNICO"
               CalcolaContoUnico(1, CFormatta.FormattaNumeroDouble(Convert.ToDouble(netBtn_DaPagare.TextButton)))
               CaricaListaConto()

            Case "SEPARATO MANUALE"
               'CalcolaContoSeparatoManuale(Convert.ToInt32(txtNumDoc.Text), Convert.ToDouble(txtDaPagare.Text))
               'CaricaListaContoSeparatoManuale()

            Case "ALLA ROMANA"
               CalcolaContoAllaRomana(Convert.ToInt32(txtNumDoc.Text), Convert.ToDouble(netBtn_DaPagare.TextButton))
               CaricaListaContoRigaUnica()

         End Select

         valDaPagare = Convert.ToDouble(netBtn_DaPagare.TextButton)

         ' Calcola il sospeso e il resto.
         Dim valContanti As Double
         If IsNumeric(txtContanti.Text) = True Then
            valContanti = Convert.ToDouble(txtContanti.Text)
         Else
            valContanti = 0
            txtContanti.Text = VALORE_ZERO
         End If

         Dim valPagamento As Double
         If IsNumeric(txtCartaCredito.Text) = True Then
            valPagamento = Convert.ToDouble(txtCartaCredito.Text)
         Else
            valPagamento = 0
            txtCartaCredito.Text = VALORE_ZERO
         End If

         Dim valBuoni As Double
         If IsNumeric(txtBuoni.Text) = True Then
            valBuoni = Convert.ToDouble(txtBuoni.Text)
         Else
            valBuoni = 0
            txtBuoni.Text = VALORE_ZERO
         End If

         Dim valPagato As Double = valContanti + valPagamento + valBuoni

         Dim valSospeso As Double
         If IsNumeric(txtSospeso.Text) = True Then
            valSospeso = Convert.ToDouble(txtSospeso.Text)
         Else
            valSospeso = 0
            txtSospeso.Text = VALORE_ZERO
         End If

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

         txtSospeso.Text = CFormatta.FormattaEuro(valSospeso)
         txtResto.Text = CFormatta.FormattaEuro(valResto)

         ' Restituisce lo stato attivo al pulsante OK.
         netBtn_Ok.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub ContoPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      ' Imposta l'icona della finestra in base al prodotto installato.
      ImpostaIcona(Me)

      DatiConfig = New AppConfig
      DatiConfig.ConfigType = ConfigFileType.AppConfig

      CaricaListaConto()

      ImpostaValoriConto()

      ' Serve ad aggiornare il totale del conto con eventuale Coperto, Sconto e Servizio.
      Timer2.Enabled = True

      Select Case tipoConto
         Case g_frmPos.Documento.Conto
            CalcolaContoUnico(1, CFormatta.FormattaNumeroDouble(netBtn_DaPagare.TextButton))

            ' Legge i dati del cliente.
            LeggiDatiCliente(TAB_CONTI_TAVOLI, idTavoloDoc)

         Case g_frmPos.Documento.Proforma
            eui_cmdProforma.PerformClick()

         Case g_frmPos.Documento.Scontrino
            txtContanti.Text = netBtn_DaPagare.TextButton
            eui_cmdScontrino.PerformClick()
      End Select

      ' Nel caso non sia stata impostata l'iva per il cliente utilizza l'iva del reparto.
      If txtIva.Text = String.Empty Or txtIva.Text = VALORE_ZERO Then
         If AliquotaIvaRistorante <> String.Empty Then
            txtIva.Text = CFormatta.FormattaEuro(AliquotaIvaRistorante)
         Else
            txtIva.Text = VALORE_ZERO
         End If
      End If

      txtContanti.Focus()
   End Sub

   Private Sub ContoPos_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      ' Distrugge l'oggetto e libera le risorse.
      g_frmContoPos.Dispose()
      g_frmContoPos = Nothing

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Chiudi, STR_CONTO, MODULO_CONTO)
   End Sub

   Private Sub ContoPos_Resize(sender As Object, e As EventArgs) Handles Me.Resize
      Try
         If Me.Width <= 1033 Then
            Me.Width = 1033
         End If

         If Me.Height <= 770 Then
            Me.Height = 770
         End If

         colonnaDescrizione.Width = Me.Width - 1010

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub DigitaNumeri(ByVal ctrl As Control, ByVal net_Btn As NetButton)
      Try
         If ctrl Is Nothing = False Then

            Select Case ctrl.Name
               Case txtCoperto.Name, txtBuoni.Name
                  Exit Sub
            End Select

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

               ctrl.Focus()
            End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Function LeggiNumeroMax(ByVal tabella As String, ByVal tipoDoc As String) As Integer
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

   Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
      Try
         If g_frmPos.numeroContoDoc <> String.Empty Then
            ' Conto parcheggiato.
            If DateTime.Now.Minute.ToString.Length = 1 Then
               Me.Text = "DETTAGLI CONTO N. " & g_frmPos.numeroContoDoc & " - Data: " & dtpData.Text & " - Ora: " & DateTime.Now.Hour & "." & "0" & DateTime.Now.Minute
            Else
               Me.Text = "DETTAGLI CONTO N. " & g_frmPos.numeroContoDoc & " - Data: " & dtpData.Text & " - Ora: " & DateTime.Now.Hour & "." & DateTime.Now.Minute
            End If
         Else
            ' Conto nuovo da elaborare.
            If DateTime.Now.Minute.ToString.Length = 1 Then
               Me.Text = "DETTAGLI CONTO N. " & LeggiNumeroMax(TAB_DOC, TIPO_DOC_CO) + 1 & " - Data: " & dtpData.Text & " - Ora: " & DateTime.Now.Hour & "." & "0" & DateTime.Now.Minute
            Else
               Me.Text = "DETTAGLI CONTO N. " & LeggiNumeroMax(TAB_DOC, TIPO_DOC_CO) + 1 & " - Data: " & dtpData.Text & " - Ora: " & DateTime.Now.Hour & "." & DateTime.Now.Minute
            End If
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
         AggiornaValoriConto()
      End If
   End Sub

   Private Sub txtServizio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtServizio.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
      If CConvalida.KeyReturn(e.KeyChar) = True Then
         AggiornaValoriConto()
      End If
   End Sub

   Private Sub txtContanti_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtContanti.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
      If CConvalida.KeyReturn(e.KeyChar) = True Then
         AggiornaValoriConto()
      End If
   End Sub

   Private Sub txtCartaCredito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCartaCredito.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
      If CConvalida.KeyReturn(e.KeyChar) = True Then
         AggiornaValoriConto()
      End If
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

   Private Sub lstvDettagli_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstvDettagli.GotFocus
      Try
         FormattaControlloAttivo(controlloAttivo)
         controlloAttivo = Nothing
         formatta = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtDaPagare_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs)
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
   End Sub

   Private Sub txtResto_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtResto.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = Nothing
      formatta = False
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

   Private Sub txtCartaCredito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCartaCredito.TextChanged
      cCredito = True
   End Sub

   Private Sub txtCoperto_GotFocus(sender As Object, e As System.EventArgs) Handles txtCoperto.GotFocus
      FormattaControlloAttivo(controlloAttivo)
      controlloAttivo = sender
      formatta = True
   End Sub

   Private Sub txtCoperto_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCoperto.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
      If CConvalida.KeyReturn(e.KeyChar) = True Then
         AggiornaValoriConto()
      End If
   End Sub

   Public Sub CalcolaContoUnico(ByVal numDoc As Integer, ByVal daPagare As String)
      Try
         txtNumDoc.Enabled = False
         txtNumDoc.BackColor = Color.DarkGray

         txtNumDoc.Text = numDoc.ToString
         txtTotDividere.Text = daPagare
         txtQuotaPersona.Text = daPagare
         netBtn_DaPagare.TextButton = daPagare

         lstvElencoDocAperti.Items.Clear()

         Dim i As Integer
         For i = 0 To numDoc - 1
            ' Indice
            lstvElencoDocAperti.Items.Add(i)

            ' Stato.
            lstvElencoDocAperti.Items(i).SubItems.Add("Aperto")

            ' Da pagare.
            lstvElencoDocAperti.Items(i).SubItems.Add(daPagare)
         Next

         eui_cmdTipoElenco.Text = "Elenco completo"

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

         netBtn_DaPagare.TextButton = txtQuotaPersona.Text

         If stampaDocInCorso = False Then
            lstvElencoDocAperti.Items.Clear()

            Dim i As Integer
            For i = 0 To numDoc - 1
               ' Indice
               lstvElencoDocAperti.Items.Add(i)

               ' Stato.
               lstvElencoDocAperti.Items(i).SubItems.Add("Aperto")

               ' Da pagare.
               lstvElencoDocAperti.Items(i).SubItems.Add(CFormatta.FormattaNumeroDouble(quotaPersona))
            Next
         End If

         eui_cmdTipoElenco.Text = "Riga unica"

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Public Sub CaricaListaContoSeparatoManuale()
      Try
         lstvElencoDocAperti.Focus()
         netBtn_DaPagare.TextButton = lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(2).Text
         LeggiDatiConto(lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(3).Text)

         Select Case eui_cmdTipoElenco.Text.ToUpper
            Case "ELENCO COMPATTO"
               CompattaElencoConto()

            Case "RIGA UNICA"
               CaricaListaContoRigaUnica()
         End Select

         AggiornaValoriConto()

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

         ' Prezzo.
         lstvDettagli.Items(0).SubItems.Add(VALORE_ZERO)
         lstvDettagliCopia.Items(0).SubItems.Add(VALORE_ZERO)

         ' Importo.
         If lstvElencoDocAperti.Items.Count <> 0 Then
            lstvElencoDocAperti.Focus()
            lstvDettagli.Items(0).SubItems.Add(lstvElencoDocAperti.Items(lstvElencoDocAperti.FocusedItem.Index).SubItems(2))
         Else
            lstvDettagli.Items(0).SubItems.Add(String.Empty)
         End If

         ' Aliquota Iva.
         lstvDettagli.Items(0).SubItems.Add(AliquotaIvaRistorante)
         lstvDettagliCopia.Items(0).SubItems.Add(AliquotaIvaRistorante)

         ' Id Piatto.
         lstvDettagli.Items(0).SubItems.Add(String.Empty)
         lstvDettagliCopia.Items(0).SubItems.Add(String.Empty)

         ' Categoria.
         lstvDettagli.Items(0).SubItems.Add(String.Empty)
         lstvDettagliCopia.Items(0).SubItems.Add(String.Empty)

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

            AggiornaValoriConto()
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
            .Intestatario = eui_cmdCliente.Text
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

   Private Function SalvaComande(ByVal numConto As String) As Boolean
      ' Salva i dati per il Tavolo selezionato.
      Try
         Dim CComande As New Comande
         Dim i As Integer

         With CComande
            .EliminaDati(TAB_COMANDE, numConto)

            For i = 0 To g_frmPos.lstvDettagli.Items.Count - 1
               .IdRisorsa = 0
               .Risorsa = nomeTavoloDoc
               .Cameriere = nomeCameriereDoc

               If IsNothing(g_frmVCTavoli) = False Then
                  .Coperti = g_frmVCTavoli.lblCoperti.Text
               Else
                  .Coperti = "0"
               End If

               If g_frmPos.lstvDettagli.Items(i).SubItems(1).Text <> String.Empty Then
                  .Quantità = Convert.ToDouble(g_frmPos.lstvDettagli.Items(i).SubItems(1).Text)
               Else
                  .Quantità = 0
               End If

               .Descrizione = g_frmPos.lstvDettagli.Items(i).SubItems(2).Text
               .ImportoNetto = g_frmPos.lstvDettagli.Items(i).SubItems(3).Text
               .ValoreUnitario = g_frmPos.lstvDettagli.Items(i).SubItems(4).Text
               .IdPiatto = Convert.ToInt32(g_frmPos.lstvDettagli.Items(i).SubItems(5).Text)
               .CategoriaPiatto = g_frmPos.lstvDettagli.Items(i).SubItems(6).Text
               .Reparto = g_frmPos.lstvDettagli.Items(i).SubItems(7).Text
               .Inviata = g_frmPos.lstvDettagli.Items(i).SubItems(8).Text
               .Esclusa = g_frmPos.lstvDettagli.Items(i).SubItems(9).Text
               .Offerta = g_frmPos.lstvDettagli.Items(i).SubItems(10).Text
               .AliquotaIva = g_frmPos.lstvDettagli.Items(i).SubItems(12).Text
               .NumeroConto = numConto

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

               ' Prezzo.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(DatiConto(i).Prezzo)
               lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(DatiConto(i).Prezzo)

               ' Importo.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(DatiConto(i).Importo)
               lstvDettagliCopia.Items(lstvDettagliCopia.Items.Count - 1).SubItems.Add(DatiConto(i).Importo)

               ' Aliquota Iva.
               lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(AliquotaIvaRistorante)
               lstvDettagliCopia.Items(lstvDettagli.Items.Count - 1).SubItems.Add(AliquotaIvaRistorante)

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
         Dim quantitàTotale As Decimal = 0
         Dim quantitàVariante As Decimal = 0
         Dim quantitàVarianteTotale As Decimal = 0

         ' Salvo i dati della lista dettagli in una lista temporanea.
         lstvDettagliTemp.Items.Clear()
         Dim z As Integer
         For z = 0 To lstvDettagliCopia.Items.Count - 1
            ' Indice.
            lstvDettagliTemp.Items.Add(lstvDettagliTemp.Items.Count.ToString)
            ' Quantità.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(z).SubItems(1).Text)
            ' Descrizione.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(z).SubItems(2).Text)
            ' Prezzo.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(z).SubItems(3).Text)
            ' Importo.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(z).SubItems(4).Text)
            ' Aliquota Iva.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(AliquotaIvaRistorante)
            ' Id Piatto.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(z).SubItems(6).Text)
            ' Categoria.
            lstvDettagliTemp.Items(lstvDettagliTemp.Items.Count - 1).SubItems.Add(String.Empty)
         Next

         ' Leggo i dati della lista Dettagli e li confronto con la lista temporanea.
         Dim i As Integer
         For i = 0 To lstvDettagliCopia.Items.Count - 1

            ' Leggo i singoli dati.
            If lstvDettagliCopia.Items(i).SubItems(4).Text = String.Empty Then
               Importo1 = 0
            Else
               Importo1 = Convert.ToDouble(lstvDettagliCopia.Items(i).SubItems(4).Text)
            End If

            idPiatto1 = lstvDettagliCopia.Items(i).SubItems(6).Text

            ' Numero di elementi da rimuovere dalla lista temporanea.
            Dim elementiDaRimuovere(500) As Integer

            Dim y As Integer = 0
            For y = 0 To lstvDettagliTemp.Items.Count - 1
               Dim quantità2 As Decimal
               Dim idPiatto2 As String

               ' Leggo i singoli dati.
               If lstvDettagliTemp.Items(y).SubItems(1).Text = String.Empty Then
                  quantitàVariante = 1
                  quantità2 = 0
               Else
                  quantità2 = Convert.ToDecimal(lstvDettagliTemp.Items(y).SubItems(1).Text)
               End If

               idPiatto2 = lstvDettagliTemp.Items(y).SubItems(6).Text

               ' Confronto quante volte i dati della lista dettagli sono presenti nella lista temporanea.
               If idPiatto1 = idPiatto2 Then
                  numElementiUguali += 1
                  elementiDaRimuovere(numElementiUguali) = y
                  quantitàTotale = quantitàTotale + quantità2
                  quantitàVarianteTotale = quantitàVarianteTotale + quantitàVariante
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
               If quantitàTotale <> 0 Then
                  ' Calcola il valore del piatto.
                  Importo3 = Importo1 * quantitàTotale
               Else
                  ' Calcola il valore della variante.
                  Importo3 = Importo1 * quantitàVarianteTotale
               End If

               ' Inserisco i nuovi dati nella lista Compatto.
               ' Indice.
               lstvDettagliCompatto.Items.Add(lstvDettagliCompatto.Items.Count.ToString)
               ' Quantità.
               If quantitàTotale <> 0 Then
                  lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(quantitàTotale.ToString)
               Else
                  lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(String.Empty)
               End If

               ' Descrizione.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(i).SubItems(2).Text)
               ' Prezzo.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(i).SubItems(3).Text)
               ' Importo.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(CFormatta.FormattaNumeroDouble(Importo3))
               ' Aliquota Iva.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(AliquotaIvaRistorante)
               ' Id Piatto.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add(lstvDettagliCopia.Items(i).SubItems(6).Text)
               ' Categoria.
               lstvDettagliCompatto.Items(lstvDettagliCompatto.Items.Count - 1).SubItems.Add("")

               numElementiUguali = 0
               quantitàTotale = 0
               quantitàVarianteTotale = 0
            End If
         Next i

         ' Svuoto la lista dettagli.
         lstvDettagli.Items.Clear()

         ' Carico la lista dettagli con tutti gli elementi compattati.
         Dim k As Integer
         For k = 0 To lstvDettagliCompatto.Items.Count - 1
            ' Indice.
            lstvDettagli.Items.Add(lstvDettagli.Items.Count.ToString)
            ' Quantità.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(lstvDettagliCompatto.Items(k).SubItems(1).Text)
            ' Descrizione.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(lstvDettagliCompatto.Items(k).SubItems(2).Text)
            ' Prezzo.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(lstvDettagliCompatto.Items(k).SubItems(3).Text)
            ' Importo.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(lstvDettagliCompatto.Items(k).SubItems(4).Text)
            ' Aliquota Iva.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(AliquotaIvaRistorante)
            ' Id Piatto.
            lstvDettagli.Items(lstvDettagli.Items.Count - 1).SubItems.Add(lstvDettagliCompatto.Items(k).SubItems(6).Text)
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

   Public Function ModificaStatoConto(ByVal tabella As String, ByVal numConto As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET StatoDoc = 'Stampato' " &
                             "WHERE NumDoc = {1}",
                             tabella,
                             numConto)

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

         If eui_cmdTipoConto.Text.ToUpper = "SEPARATO MANUALE" Then
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
               eui_cmdCliente.Text = dr.Item("Intestatario").ToString
            Else
               eui_cmdCliente.Text = "Seleziona cliente"
            End If

            If IsDBNull(dr.Item("IdCliente")) = False Then
               txtIdCliente.Text = dr.Item("IdCliente").ToString
            Else
               txtIdCliente.Text = "0"
            End If
            If IsDBNull(dr.Item("IdAzienda")) = False Then
               txtIdAzienda.Text = dr.Item("IdAzienda").ToString
            Else
               txtIdAzienda.Text = "0"
            End If
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               txtIndirizzo.Text = dr.Item("Indirizzo").ToString
            Else
               txtIndirizzo.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Cap")) = False Then
               txtCap.Text = dr.Item("Cap").ToString
            Else
               txtCap.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Città")) = False Then
               txtCittà.Text = dr.Item("Città").ToString
            Else
               txtCittà.Text = String.Empty
            End If
            If IsDBNull(dr.Item("Provincia")) = False Then
               txtProv.Text = dr.Item("Provincia").ToString
            Else
               txtProv.Text = String.Empty
            End If
            If IsDBNull(dr.Item("PIva")) = False Then
               txtPIva.Text = dr.Item("PIva").ToString
            Else
               txtPIva.Text = String.Empty
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

   Private Sub cmdAddebitoHotel_Click(sender As System.Object, e As System.EventArgs)
      MessageBox.Show("Non è possibile eseguire l'operazione! Il modulo Hotel non è installato.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

   End Sub

   Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
      ' Imposta il valore dello sconto.
      ImpostaScontoConto()

      ' Serve ad aggiornare il totale del conto con eventuale Coperto, Sconto e Servizio.
      AggiornaValoriConto()

      Timer2.Enabled = False
   End Sub

   Private Sub eui_cmdTipoConto_Click(sender As Object, e As EventArgs) Handles eui_cmdTipoConto.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New TipoContoPos
         If frm.ShowDialog() = DialogResult.OK Then
            eui_cmdTipoConto.Text = frm.Tag.ToString

            Select Case eui_cmdTipoConto.Text.ToUpper
               Case "UNICO"
                  lblQuotaPersona.Visible = True
                  txtQuotaPersona.Visible = True
                  eui_cmdDivisioneAnalitica.Visible = False

                  AggiornaValoriConto()

               Case "SEPARATO MANUALE"
                  lblQuotaPersona.Visible = False
                  txtQuotaPersona.Visible = False
                  eui_cmdDivisioneAnalitica.Visible = True

                  txtNumDoc.Enabled = True
                  txtNumDoc.BackColor = Color.White
                  txtNumDoc.Text = "2"

                  netBtn_DaPagare.TextButton = txtTotDividere.Text
                  txtSospeso.Text = txtTotDividere.Text

                  eui_cmdTipoElenco.Text = "Elenco completo"

                  lstvElencoDocAperti.Items.Clear()
                  lstvDettagli.Items.Clear()

               Case "ALLA ROMANA"
                  lblQuotaPersona.Visible = True
                  txtQuotaPersona.Visible = True
                  eui_cmdDivisioneAnalitica.Visible = False

                  txtNumDoc.Text = "2"

                  AggiornaValoriConto()
            End Select
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub eui_cmdTipoElenco_Click(sender As Object, e As EventArgs) Handles eui_cmdTipoElenco.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New TipoElencoPos(eui_cmdTipoConto.Text)
         If frm.ShowDialog() = DialogResult.OK Then
            eui_cmdTipoElenco.Text = frm.Tag.ToString

            Select Case eui_cmdTipoElenco.Text.ToUpper
               Case "ELENCO COMPLETO"
                  If eui_cmdTipoConto.Text.ToUpper = "SEPARATO MANUALE" Then
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

   Private Sub eui_cmdCliente_Click(sender As Object, e As EventArgs) Handles eui_cmdCliente.Click
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

   Private Sub eui_cmdContanti_Click(sender As Object, e As EventArgs) Handles eui_cmdContanti.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New Contanti
         If frm.ShowDialog() = DialogResult.OK Then
            txtContanti.Text = frm.Tag.ToString
         End If

         txtContanti.Focus()

         AggiornaValoriConto()

         txtContanti.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdContanti_GotFocus(sender As Object, e As EventArgs) Handles eui_cmdContanti.GotFocus
      Try
         FormattaControlloAttivo(controlloAttivo)
         controlloAttivo = Nothing
         formatta = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdTipoPagamento_Click(sender As Object, e As EventArgs) Handles eui_cmdTipoPagamento.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New Pagamenti
         If frm.ShowDialog() = DialogResult.OK Then
            eui_cmdTipoPagamento.Text = frm.Tag.ToString
         End If

         AggiornaValoriConto()

         txtCartaCredito.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub eui_cmdTipoPagamento_GotFocus(sender As Object, e As EventArgs) Handles eui_cmdTipoPagamento.GotFocus
      Try
         FormattaControlloAttivo(controlloAttivo)
         controlloAttivo = Nothing
         formatta = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdBuoni_Click(sender As Object, e As EventArgs) Handles eui_cmdBuoni.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New frmElencoBuoniPos
         If frm.ShowDialog() = DialogResult.OK Then
            txtBuoni.Text = frm.Tag.ToString
         End If

         AggiornaValoriConto()

         txtBuoni.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdBuoni_GotFocus(sender As Object, e As EventArgs) Handles eui_cmdBuoni.GotFocus
      Try
         FormattaControlloAttivo(controlloAttivo)
         controlloAttivo = Nothing
         formatta = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdDocApertiGiù_Click(sender As Object, e As EventArgs) Handles eui_cmdDocApertiGiù.Click
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

   Private Sub eui_cmdDocApertiGiù_GotFocus(sender As Object, e As EventArgs) Handles eui_cmdDocApertiGiù.GotFocus
      Try
         FormattaControlloAttivo(controlloAttivo)
         controlloAttivo = Nothing
         formatta = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdDocApertiSu_Click(sender As Object, e As EventArgs) Handles eui_cmdDocApertiSu.Click
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

   Private Sub eui_cmdDocApertiSu_GotFocus(sender As Object, e As EventArgs) Handles eui_cmdDocApertiSu.GotFocus
      Try
         FormattaControlloAttivo(controlloAttivo)
         controlloAttivo = Nothing
         formatta = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdDettagliGiù_Click(sender As Object, e As EventArgs) Handles eui_cmdDettagliGiù.Click
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

   Private Sub eui_cmdDettagliGiù_GotFocus(sender As Object, e As EventArgs) Handles eui_cmdDettagliGiù.GotFocus
      Try
         FormattaControlloAttivo(controlloAttivo)
         controlloAttivo = Nothing
         formatta = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdDettagliSu_Click(sender As Object, e As EventArgs) Handles eui_cmdDettagliSu.Click
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

   Private Sub eui_cmdDettagliSu_GotFocus(sender As Object, e As EventArgs) Handles eui_cmdDettagliSu.GotFocus
      Try
         FormattaControlloAttivo(controlloAttivo)
         controlloAttivo = Nothing
         formatta = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      ' Apre la Tastiera virtuale di Windows (XP, 7, 8, 10).
      AvviaTastieraVirtuale(Me.Handle)
   End Sub

   Private Sub eui_cmdCancella_Click(sender As Object, e As EventArgs) Handles eui_cmdCancella.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ImpostaValoriConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdCancella_GotFocus(sender As Object, e As EventArgs) Handles eui_cmdCancella.GotFocus
      Try
         controlloAttivo = Nothing

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdEsci_Click(sender As Object, e As EventArgs) Handles eui_cmdEsci.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         ' Se il conto è stato aperto per un tavolo salva i dati del cliente.
         If idTavoloDoc <> String.Empty Then
            SalvaDatiClienti()
         End If

         ' Esce, chiude il form senza stampare il conto.
         Me.DialogResult = DialogResult.Cancel
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         g_frmPos.numeroContoDoc = String.Empty

      End Try
   End Sub

   Private Sub eui_cmdRicevuta_Click(sender As Object, e As EventArgs) Handles eui_cmdRicevuta.Click
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
            percorsoRep = PERCORSO_REP_RF_A4_DOPPIA
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

   Private Sub eui_cmdFattura_Click(sender As Object, e As EventArgs) Handles eui_cmdFattura.Click
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
            percorsoRep = "\Reports\" & ImpostaNomeDoc(1)
         Else
            percorsoRep = PERCORSO_REP_FF_A4_DOPPIA
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

   Private Sub eui_cmdProforma_Click(sender As Object, e As EventArgs) Handles eui_cmdProforma.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         If g_frmPos.nomeTavolo <> String.Empty And g_frmPos.nomeTavolo <> "Tavoli" Then
            Dim risposta As Integer
            risposta = MessageBox.Show("Si desidera mantenere ancora i dati del conto sul Tavolo?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            percorsoRep = PERCORSO_REP_PF_A4_DOPPIA
         End If

         If VerificaCartaCredito() = True Then
            StampaConto(ImpostaNomeStampante(2))
         End If

         ' Se il proforma è stampato da un conto parcheggiato modifica lo stato del conto come Stampato.
         If g_frmPos.numeroContoDoc <> String.Empty Then
            g_frmPos.tipoDocumento = TIPO_DOC_PF
            ModificaStatoConto(TAB_DOC, Convert.ToInt32(g_frmPos.numeroContoDoc))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdScontrino_Click(sender As Object, e As EventArgs) Handles eui_cmdScontrino.Click
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

   Private Sub eui_cmdParcheggiaConto_Click(sender As Object, e As EventArgs) Handles eui_cmdParcheggiaConto.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Normale, EffettiSonoriPOS)

         Dim frm As New NoteContiPOS
         If frm.ShowDialog = DialogResult.Yes Then

            Dim note As String
            If frm.Tag.ToString <> String.Empty Then
               note = frm.Tag.ToString
            Else
               note = String.Empty
            End If

            ' Se un conto esistente.
            If g_frmPos.numeroContoDoc <> String.Empty Then
               ' Elimina il conto del documento stampato.
               g_frmPos.EliminaConto(g_frmPos.numeroContoDoc)
            End If

            ' Salva il documento e chiude la finestra.
            Dim numeroConto As String = SalvaConto(g_frmPos.numeroContoDoc, note)
            If numeroConto <> 0 Then
               ' Salva i dettagli del conto.
               SalvaComande(numeroConto)

               Me.Close()
            End If

            If g_frmPos.numeroContoDoc <> String.Empty Then
               ' Ripristina il Punto cassa e lo lascia aperto.
               g_frmPos.AnnullaConto()
            Else
               ' Serve a chiudere il Punto cassa e liberare il tavolo.
               g_frmPos.numeroContoDoc = numeroConto
            End If

         Else
            Exit Sub
         End If

      Catch ex As NullReferenceException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_AddebitoSuRisorsa_Click(sender As Object, e As EventArgs) Handles eui_AddebitoSuRisorsa.Click
      Try
         ' Aperto dalla gestione Tavoli.
         If g_frmPos.nomeTavolo <> String.Empty And g_frmPos.nomeTavolo <> "Tavoli" And g_frmPos.nomeTavolo <> "Hotel" Then
            Dim risposta As Integer
            risposta = MessageBox.Show("Si desidera mantenere ancora i dati del conto sul Tavolo?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If risposta = DialogResult.Yes Then
               mantieniDatiTavolo = True
            Else
               mantieniDatiTavolo = False
            End If
         Else
            mantieniDatiTavolo = True
         End If

         ' ADDEBITO DALLA PRENOTAZIONE.
         If g_frmPos.nomeTavolo = "Hotel" Then
            ' Viene passato il numero e il totale conto della prenotazione.
            If AddebitaConto(g_frmPos.idTavolo, g_frmPos.totContoCamera) = True Then

               ' Nel caso esista elimina il conto addebitato e le relative righe di dettaglio.
               If g_frmPos.numeroContoDoc <> String.Empty Then
                  DettagliDoc.EliminaDati(TAB_DETTAGLI_DOC, LeggiIdDocumento(TAB_DOC, g_frmPos.numeroContoDoc))
                  Doc.EliminaDati(TAB_DOC, g_frmPos.numeroContoDoc)
               End If

               ' Nasconde il form del Conto.
               Me.Hide()

               MessageBox.Show("Il conto è stato salvato nella prenotazione N. " & g_frmPos.idTavolo, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

               ' Chiude il form del Conto.
               Me.DialogResult = DialogResult.OK
               Me.Close()
            Else
               MessageBox.Show("Si è verificato un errore! Il conto non è stato salvato. Si suggerisce di verificare tutti i dati inseriti e riprovare. ", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
         Else
            ' ADDEBITO DAL PUNTO CASSA.
            Dim frm As New AddebitaContoPos
            If frm.ShowDialog() = DialogResult.OK Then

               Select Case frm.Tag.ToUpper
                  Case "HOTEL"
                     Dim frmSelPren As New frmSelezionaPrenotazione

                     If frmSelPren.ShowDialog() = DialogResult.OK Then
                        ' Id, Numero, TotaleConto prenotazione.
                        Dim charSeparators() As Char = {","c}
                        Dim idNumPren As String() = frmSelPren.Tag.ToString.Split(charSeparators, 3)

                        ' Viene passato il numero e il totale conto della prenotazione.
                        If SalvaAddebitoConto(idNumPren(0), idNumPren(2)) = True Then

                           ' Nel caso esista elimina il conto addebitato e le relative righe di dettaglio.
                           If g_frmPos.numeroContoDoc <> String.Empty Then
                              DettagliDoc.EliminaDati(TAB_DETTAGLI_DOC, LeggiIdDocumento(TAB_DOC, g_frmPos.numeroContoDoc))
                              Doc.EliminaDati(TAB_DOC, g_frmPos.numeroContoDoc)
                           End If

                           ' Nasconde il form del Conto.
                           Me.Hide()

                           MessageBox.Show("Il conto è stato salvato nella prenotazione N. " & idNumPren(1), NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

                           ' Chiude il form del Conto.
                           Me.DialogResult = DialogResult.OK
                           Me.Close()
                        Else
                           MessageBox.Show("Si è verificato un errore! Il conto non è stato salvato. Si suggerisce di verificare tutti i dati inseriti e riprovare.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                        End If
                     End If

                  Case "CENTRO SPORTIVO"
                     ' DA SVILUPPARE!
                     MessageBox.Show("Non è possibile eseguire l'operazione! Il modulo Centro Sportivo non è installato.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                  Case "CAMPEGGIO"
                     ' DA SVILUPPARE!
                     MessageBox.Show("Non ci sono prenotazioni su cui addebitare il conto! Il modulo Campeggio non è installato.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                  Case "CENTRO BALNEARE"
                     ' DA SVILUPPARE!
                     MessageBox.Show("Non ci sono prenotazioni su cui addebitare il conto! Il modulo Centro Balneare non è installato.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                  Case "CENTRO BENESSERE"
                     ' DA SVILUPPARE!
                     MessageBox.Show("Non ci sono prenotazioni su cui addebitare il conto! Il modulo Centro Benessere non è installato.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

               End Select
            End If

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Virgola_Click(sender As Object, e As EventArgs) Handles netBtn_Virgola.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         ' Verifica la presenza della virgola.
         formatta = False

         If controlloAttivo Is Nothing = True Then
            Exit Sub
         End If

         If controlloAttivo.Text = String.Empty Then
            controlloAttivo.Focus()
            Exit Sub
         Else
            Dim virgola As Integer = Convert.ToInt32(controlloAttivo.Text.IndexOf(netBtn_Virgola.TextButton))

            If virgola <> -1 Then
               controlloAttivo.Focus()
               Exit Sub
            Else
               DigitaNumeri(controlloAttivo, netBtn_Virgola)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub netBtn_0_Click(sender As Object, e As EventArgs) Handles netBtn_0.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_00_Click(sender As Object, e As EventArgs) Handles netBtn_00.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_1_Click(sender As Object, e As EventArgs) Handles netBtn_1.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_2_Click(sender As Object, e As EventArgs) Handles netBtn_2.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_3_Click(sender As Object, e As EventArgs) Handles netBtn_3.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_4_Click(sender As Object, e As EventArgs) Handles netBtn_4.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_5_Click(sender As Object, e As EventArgs) Handles netBtn_5.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_6_Click(sender As Object, e As EventArgs) Handles netBtn_6.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_7_Click(sender As Object, e As EventArgs) Handles netBtn_7.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_8_Click(sender As Object, e As EventArgs) Handles netBtn_8.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_9_Click(sender As Object, e As EventArgs) Handles netBtn_9.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         DigitaNumeri(controlloAttivo, sender)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_C_Click(sender As Object, e As EventArgs) Handles netBtn_C.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         If IsNothing(controlloAttivo) = False Then

            Select Case controlloAttivo.Name
               Case txtCoperto.Name, txtBuoni.Name
                  Exit Sub
            End Select

            formatta = False
            controlloAttivo.Text = String.Empty
            controlloAttivo.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub netBtn_X_Click(sender As Object, e As EventArgs) Handles netBtn_X.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Lista, EffettiSonoriPOS)

         moltiplica = True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub netBtn_Percentuale_Click(sender As Object, e As EventArgs) Handles netBtn_Percentuale.Click
      Try
         ' Riproduce un effetto sonoro.
         RiproduciEffettoSonoro(My.Resources.beep_Piatti, EffettiSonoriPOS)

         If controlloAttivo.Enabled = True Then

            If IsNothing(controlloAttivo) = False Then

               Select Case controlloAttivo.Name
                  Case txtCoperto.Name, txtBuoni.Name
                     Exit Sub
               End Select

               If controlloAttivo.Text = String.Empty Then
                  controlloAttivo.Text = VALORE_ZERO
               End If
            End If

            ' Moltiplicazione su una TextBox.
            If moltiplica = True Then
               If op1 <> 0 And op2 <> 0 Then
                  Dim valPercentuale As Double = (op1 * op2) / 100
                  controlloAttivo.Text = CFormatta.FormattaEuro(valPercentuale)
               Else
                  controlloAttivo.Text = VALORE_ZERO
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

   Private Sub netBtn_Ok_Click(sender As Object, e As EventArgs) Handles netBtn_Ok.Click
      Try
         AggiornaValoriConto()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub netBtn_Ok_GotFocus(sender As Object, e As EventArgs) Handles netBtn_Ok.GotFocus
      Try
         FormattaControlloAttivo(controlloAttivo)
         formatta = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdDivisioneAnalitica_Click(sender As Object, e As EventArgs) Handles eui_cmdDivisioneAnalitica.Click
      Try
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

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub


End Class
