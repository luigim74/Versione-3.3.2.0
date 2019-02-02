#Region " DATI FILE.VB "

' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       05/08/2005
' Data ultima modifica: 26/01/2019
' Descrizione:          Form per la configurazione di tutte le opzioni del programma.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************

#End Region

Imports System.IO

Public Class frmOpzioni
   Inherits System.Windows.Forms.Form
#Region " Codice generato da Progettazione Windows Form "

   Public Sub New()
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      'Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent()

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
   Friend WithEvents cmdAnnulla As System.Windows.Forms.Button
   Friend WithEvents cmdOK As System.Windows.Forms.Button
   Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents tabOpzioni As System.Windows.Forms.TabControl
   Friend WithEvents tbpGenerali As System.Windows.Forms.TabPage
   Friend WithEvents tbpStampanti As System.Windows.Forms.TabPage
   Public WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents cmbFormatoFatt As System.Windows.Forms.ComboBox
   Friend WithEvents cmdApriDB2 As System.Windows.Forms.Button
   Friend WithEvents cmdApriDB1 As System.Windows.Forms.Button
   Friend WithEvents cmbNumElementi As System.Windows.Forms.ComboBox
   Public WithEvents Label2 As System.Windows.Forms.Label
   Public WithEvents label As System.Windows.Forms.Label
   Friend WithEvents txtPercorsoDBClienti As System.Windows.Forms.TextBox
   Friend WithEvents txtPercorsoDB As System.Windows.Forms.TextBox
   Public WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
   Public WithEvents Label9 As System.Windows.Forms.Label
   Public WithEvents Label8 As System.Windows.Forms.Label
   Public WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
   Public WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents cmbReportProforma As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteProforma As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportFatture As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteFatture As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportRicevute As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteRicevute As System.Windows.Forms.ComboBox
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Public WithEvents Label4 As System.Windows.Forms.Label
   Public WithEvents Label6 As System.Windows.Forms.Label
   Public WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents cmbReportComandaAgg As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComandaAgg As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportComanda1 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComanda1 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReparto1 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportComanda2 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComanda2 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReparto2 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportComanda3 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComanda3 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReparto3 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportComanda4 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComanda4 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReparto4 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportComanda5 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComanda5 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReparto5 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportComanda6 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComanda6 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReparto6 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportComanda7 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComanda7 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReparto7 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportComanda8 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComanda8 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReparto8 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportComanda9 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComanda9 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReparto9 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReportComanda10 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteComanda10 As System.Windows.Forms.ComboBox
   Friend WithEvents cmbReparto10 As System.Windows.Forms.ComboBox
   Public WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents cmdApriBackup As System.Windows.Forms.Button
   Friend WithEvents txtPercorsoBackup As System.Windows.Forms.TextBox
   Friend WithEvents chkSalvaBackup As System.Windows.Forms.CheckBox
   Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
   Friend WithEvents tbpPalmare As System.Windows.Forms.TabPage
   Public WithEvents Label13 As System.Windows.Forms.Label
   Public WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents cmdApriPercorsoPalmare As System.Windows.Forms.Button
   Friend WithEvents txtPercorsoRetePalmare As System.Windows.Forms.TextBox
   Friend WithEvents cmbFreqAggPalmare As System.Windows.Forms.ComboBox
   Friend WithEvents chkAbilitaPalmareWindows As System.Windows.Forms.CheckBox
   Public WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents cmdAggiornaFilePalmare As System.Windows.Forms.Button
   Friend WithEvents cmbReportScontrini As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteScontrini As System.Windows.Forms.ComboBox
   Public WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents tbpFiscali As System.Windows.Forms.TabPage
   Public WithEvents Label18 As System.Windows.Forms.Label
   Public WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents cmbStampanteProduttore As System.Windows.Forms.ComboBox
   Friend WithEvents cmbStampanteModello As System.Windows.Forms.ComboBox
   Friend WithEvents tbpRecovery As System.Windows.Forms.TabPage
   Friend WithEvents cmdApriPercorsoRecovery As System.Windows.Forms.Button
   Friend WithEvents txtPercorsoRecovery As System.Windows.Forms.TextBox
   Public WithEvents lblPercorsoRecovery As System.Windows.Forms.Label
   Friend WithEvents Label24 As System.Windows.Forms.Label
   Friend WithEvents chkAttivaRecovery As System.Windows.Forms.CheckBox
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents grbSwing As System.Windows.Forms.GroupBox
   Friend WithEvents cmbStampantePorta As System.Windows.Forms.ComboBox
   Public WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents txtNomeScontrino As System.Windows.Forms.TextBox
   Public WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents cmdPercorsoDriver As System.Windows.Forms.Button
   Friend WithEvents txtPercorsoDriver As System.Windows.Forms.TextBox
   Public WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents txtStampanteParametri As System.Windows.Forms.TextBox
   Public WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents cmdPercorsoOutput As System.Windows.Forms.Button
   Friend WithEvents txtPercorsoOutput As System.Windows.Forms.TextBox
   Public WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents grbWpos As System.Windows.Forms.GroupBox
   Friend WithEvents txtEstensioneFileWpos1 As System.Windows.Forms.TextBox
   Public WithEvents Label26 As System.Windows.Forms.Label
   Friend WithEvents txtPasswordWpos1 As System.Windows.Forms.TextBox
   Public WithEvents Label28 As System.Windows.Forms.Label
   Friend WithEvents cmdPercorsoWpos1 As System.Windows.Forms.Button
   Friend WithEvents txtPercorsoWpos1 As System.Windows.Forms.TextBox
   Public WithEvents Label29 As System.Windows.Forms.Label
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents Label32 As System.Windows.Forms.Label
   Friend WithEvents cmdAvviaWpos1 As System.Windows.Forms.Button
   Friend WithEvents grbAliquote As System.Windows.Forms.GroupBox
   Friend WithEvents txtAliquotaIva2 As System.Windows.Forms.TextBox
   Public WithEvents Label30 As System.Windows.Forms.Label
   Friend WithEvents txtAliquotaIva1 As System.Windows.Forms.TextBox
   Public WithEvents Label31 As System.Windows.Forms.Label
   Friend WithEvents txtAliquotaIva4 As System.Windows.Forms.TextBox
   Public WithEvents Label25 As System.Windows.Forms.Label
   Friend WithEvents txtAliquotaIva3 As System.Windows.Forms.TextBox
   Public WithEvents Label27 As System.Windows.Forms.Label
   Friend WithEvents cmdPercorsoDriverWPOS1 As System.Windows.Forms.Button
   Friend WithEvents txtPercorsoDriverWPOS1 As System.Windows.Forms.TextBox
   Public WithEvents Label33 As System.Windows.Forms.Label
   Friend WithEvents tbpBarRist As System.Windows.Forms.TabPage
   Friend WithEvents tbpCentroSportivo As System.Windows.Forms.TabPage
   Friend WithEvents txtServizioRistorante As System.Windows.Forms.TextBox
   Friend WithEvents txtCopertoRistorante As System.Windows.Forms.TextBox
   Public WithEvents Label36 As System.Windows.Forms.Label
   Public WithEvents Label35 As System.Windows.Forms.Label
   Friend WithEvents cmbIvaRistorante As System.Windows.Forms.ComboBox
   Public WithEvents Label34 As System.Windows.Forms.Label
   Public WithEvents Label37 As System.Windows.Forms.Label
   Public WithEvents Label42 As System.Windows.Forms.Label
   Public WithEvents Label41 As System.Windows.Forms.Label
   Public WithEvents Label40 As System.Windows.Forms.Label
   Public WithEvents Label38 As System.Windows.Forms.Label
   Friend WithEvents cmbIvaCentroSportivo As System.Windows.Forms.ComboBox
   Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
   Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
   Friend WithEvents ckbEffettiSonoriPos As System.Windows.Forms.CheckBox
   Friend WithEvents gbPrenOnLine As System.Windows.Forms.GroupBox
   Friend WithEvents cmdPercorsoFileTavAgent As System.Windows.Forms.Button
   Friend WithEvents txtPercorsoFileTavAgent As System.Windows.Forms.TextBox
   Public WithEvents Label43 As System.Windows.Forms.Label
   Friend WithEvents cmdPercorsoCartellaTavAgent As System.Windows.Forms.Button
   Friend WithEvents txtPercorsoCartellaTavAgent As System.Windows.Forms.TextBox
   Public WithEvents Label46 As System.Windows.Forms.Label
   Friend WithEvents cmdAvviaTavAgent As System.Windows.Forms.Button
   Friend WithEvents ckbNotificaTavAgent As System.Windows.Forms.CheckBox
   Friend WithEvents ckbAbilitaRicezioneTavAgent As System.Windows.Forms.CheckBox
   Friend WithEvents cmdColorePrenTavAgent As System.Windows.Forms.Button
   Public WithEvents Label44 As System.Windows.Forms.Label
   Friend WithEvents cmdImpostazioniTavAgent As System.Windows.Forms.Button
   Friend WithEvents ColorDialog1 As System.Windows.Forms.ColorDialog
   Friend WithEvents tbpFidelity As System.Windows.Forms.TabPage
   Friend WithEvents ckdScontrinoPunti As System.Windows.Forms.CheckBox
   Friend WithEvents ckdProformaPunti As System.Windows.Forms.CheckBox
   Friend WithEvents ckdFatturaPunti As System.Windows.Forms.CheckBox
   Friend WithEvents ckdRicevutaPunti As System.Windows.Forms.CheckBox
   Friend WithEvents Label49 As System.Windows.Forms.Label
   Friend WithEvents ckdlCategoriePunti As System.Windows.Forms.CheckedListBox
   Friend WithEvents ckdMsgPunti As System.Windows.Forms.CheckBox
   Friend WithEvents Label48 As System.Windows.Forms.Label
   Friend WithEvents txtValPunti As System.Windows.Forms.TextBox
   Friend WithEvents Label47 As System.Windows.Forms.Label
   Friend WithEvents txtNomePunti As System.Windows.Forms.TextBox
   Friend WithEvents Label45 As System.Windows.Forms.Label
   Friend WithEvents ckdAbilitaRaccoltaPunti As System.Windows.Forms.CheckBox
   Friend WithEvents cmdDeselTutteCategorie As System.Windows.Forms.Button
   Friend WithEvents cmdSelTutteCategorie As System.Windows.Forms.Button
   Friend WithEvents cmdApriPercorsoAmica As System.Windows.Forms.Button
   Public WithEvents Label50 As System.Windows.Forms.Label
   Friend WithEvents txtPercorsoAmica As System.Windows.Forms.TextBox
   Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
   Friend WithEvents nudNumCopieStampa As System.Windows.Forms.NumericUpDown
   Friend WithEvents txtNumeroRicevuta As System.Windows.Forms.TextBox
   Friend WithEvents txtNumeroFattura As System.Windows.Forms.TextBox
   Public WithEvents Label58 As System.Windows.Forms.Label
   Friend WithEvents chkNumeroRicevuta As System.Windows.Forms.CheckBox
   Friend WithEvents chkNumeroFattura As System.Windows.Forms.CheckBox
   Friend WithEvents tbpCamere As System.Windows.Forms.TabPage
   Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
   Friend WithEvents cmbNumStelle As System.Windows.Forms.ComboBox
   Public WithEvents Label53 As System.Windows.Forms.Label
   Friend WithEvents cmbTipoEsercizio As System.Windows.Forms.ComboBox
   Public WithEvents Label55 As System.Windows.Forms.Label
   Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
   Friend WithEvents txtServizioCamere As System.Windows.Forms.TextBox
   Public WithEvents Label39 As System.Windows.Forms.Label
   Friend WithEvents txtTassaSoggiorno As System.Windows.Forms.TextBox
   Friend WithEvents cmbIvaCamere As System.Windows.Forms.ComboBox
   Public WithEvents Label51 As System.Windows.Forms.Label
   Public WithEvents Label52 As System.Windows.Forms.Label
   Friend WithEvents chkIvaInclusa As System.Windows.Forms.CheckBox
   Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
   Friend WithEvents ckbNumeroModC59 As System.Windows.Forms.CheckBox
   Friend WithEvents ckbNumeroSchedinaPS As System.Windows.Forms.CheckBox
   Friend WithEvents txtNumeroModC59 As System.Windows.Forms.TextBox
   Friend WithEvents txtNumeroSchedinaPS As System.Windows.Forms.TextBox
   Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
   Friend WithEvents ckbApplicaTassaRagazzi As System.Windows.Forms.CheckBox
   Friend WithEvents ckbApplicaTassaNeonati As System.Windows.Forms.CheckBox
   Friend WithEvents ckbApplicaTassaBambini As System.Windows.Forms.CheckBox
   Friend WithEvents chkAbilitaPalmareAndroid As System.Windows.Forms.CheckBox
   Friend WithEvents txtDescrizioneTassaSogg As TextBox
   Public WithEvents Label54 As Label
   Friend WithEvents lblDataSalvataggio As System.Windows.Forms.Label
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmOpzioni))
      Me.cmdAnnulla = New System.Windows.Forms.Button()
      Me.cmdOK = New System.Windows.Forms.Button()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.tabOpzioni = New System.Windows.Forms.TabControl()
      Me.tbpGenerali = New System.Windows.Forms.TabPage()
      Me.txtPercorsoAmica = New System.Windows.Forms.TextBox()
      Me.GroupBox5 = New System.Windows.Forms.GroupBox()
      Me.chkIvaInclusa = New System.Windows.Forms.CheckBox()
      Me.chkNumeroRicevuta = New System.Windows.Forms.CheckBox()
      Me.chkNumeroFattura = New System.Windows.Forms.CheckBox()
      Me.nudNumCopieStampa = New System.Windows.Forms.NumericUpDown()
      Me.txtNumeroRicevuta = New System.Windows.Forms.TextBox()
      Me.txtNumeroFattura = New System.Windows.Forms.TextBox()
      Me.Label58 = New System.Windows.Forms.Label()
      Me.cmdApriPercorsoAmica = New System.Windows.Forms.Button()
      Me.grbAliquote = New System.Windows.Forms.GroupBox()
      Me.Label42 = New System.Windows.Forms.Label()
      Me.Label41 = New System.Windows.Forms.Label()
      Me.Label40 = New System.Windows.Forms.Label()
      Me.Label38 = New System.Windows.Forms.Label()
      Me.txtAliquotaIva2 = New System.Windows.Forms.TextBox()
      Me.Label30 = New System.Windows.Forms.Label()
      Me.txtAliquotaIva1 = New System.Windows.Forms.TextBox()
      Me.Label31 = New System.Windows.Forms.Label()
      Me.txtAliquotaIva4 = New System.Windows.Forms.TextBox()
      Me.Label25 = New System.Windows.Forms.Label()
      Me.txtAliquotaIva3 = New System.Windows.Forms.TextBox()
      Me.Label27 = New System.Windows.Forms.Label()
      Me.cmbFormatoFatt = New System.Windows.Forms.ComboBox()
      Me.chkSalvaBackup = New System.Windows.Forms.CheckBox()
      Me.cmdApriBackup = New System.Windows.Forms.Button()
      Me.txtPercorsoBackup = New System.Windows.Forms.TextBox()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.cmdApriDB2 = New System.Windows.Forms.Button()
      Me.cmdApriDB1 = New System.Windows.Forms.Button()
      Me.cmbNumElementi = New System.Windows.Forms.ComboBox()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.label = New System.Windows.Forms.Label()
      Me.txtPercorsoDBClienti = New System.Windows.Forms.TextBox()
      Me.txtPercorsoDB = New System.Windows.Forms.TextBox()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.Label50 = New System.Windows.Forms.Label()
      Me.tbpBarRist = New System.Windows.Forms.TabPage()
      Me.gbPrenOnLine = New System.Windows.Forms.GroupBox()
      Me.cmdImpostazioniTavAgent = New System.Windows.Forms.Button()
      Me.cmdColorePrenTavAgent = New System.Windows.Forms.Button()
      Me.Label44 = New System.Windows.Forms.Label()
      Me.ckbAbilitaRicezioneTavAgent = New System.Windows.Forms.CheckBox()
      Me.cmdPercorsoFileTavAgent = New System.Windows.Forms.Button()
      Me.txtPercorsoFileTavAgent = New System.Windows.Forms.TextBox()
      Me.Label43 = New System.Windows.Forms.Label()
      Me.cmdPercorsoCartellaTavAgent = New System.Windows.Forms.Button()
      Me.txtPercorsoCartellaTavAgent = New System.Windows.Forms.TextBox()
      Me.Label46 = New System.Windows.Forms.Label()
      Me.cmdAvviaTavAgent = New System.Windows.Forms.Button()
      Me.ckbNotificaTavAgent = New System.Windows.Forms.CheckBox()
      Me.GroupBox3 = New System.Windows.Forms.GroupBox()
      Me.ckbEffettiSonoriPos = New System.Windows.Forms.CheckBox()
      Me.txtServizioRistorante = New System.Windows.Forms.TextBox()
      Me.Label34 = New System.Windows.Forms.Label()
      Me.txtCopertoRistorante = New System.Windows.Forms.TextBox()
      Me.cmbIvaRistorante = New System.Windows.Forms.ComboBox()
      Me.Label36 = New System.Windows.Forms.Label()
      Me.Label35 = New System.Windows.Forms.Label()
      Me.tbpCamere = New System.Windows.Forms.TabPage()
      Me.GroupBox9 = New System.Windows.Forms.GroupBox()
      Me.txtDescrizioneTassaSogg = New System.Windows.Forms.TextBox()
      Me.Label54 = New System.Windows.Forms.Label()
      Me.ckbApplicaTassaRagazzi = New System.Windows.Forms.CheckBox()
      Me.ckbApplicaTassaNeonati = New System.Windows.Forms.CheckBox()
      Me.txtTassaSoggiorno = New System.Windows.Forms.TextBox()
      Me.ckbApplicaTassaBambini = New System.Windows.Forms.CheckBox()
      Me.Label52 = New System.Windows.Forms.Label()
      Me.GroupBox8 = New System.Windows.Forms.GroupBox()
      Me.ckbNumeroModC59 = New System.Windows.Forms.CheckBox()
      Me.ckbNumeroSchedinaPS = New System.Windows.Forms.CheckBox()
      Me.txtNumeroModC59 = New System.Windows.Forms.TextBox()
      Me.txtNumeroSchedinaPS = New System.Windows.Forms.TextBox()
      Me.GroupBox7 = New System.Windows.Forms.GroupBox()
      Me.cmbNumStelle = New System.Windows.Forms.ComboBox()
      Me.Label53 = New System.Windows.Forms.Label()
      Me.cmbTipoEsercizio = New System.Windows.Forms.ComboBox()
      Me.Label55 = New System.Windows.Forms.Label()
      Me.GroupBox6 = New System.Windows.Forms.GroupBox()
      Me.txtServizioCamere = New System.Windows.Forms.TextBox()
      Me.Label39 = New System.Windows.Forms.Label()
      Me.cmbIvaCamere = New System.Windows.Forms.ComboBox()
      Me.Label51 = New System.Windows.Forms.Label()
      Me.tbpCentroSportivo = New System.Windows.Forms.TabPage()
      Me.GroupBox4 = New System.Windows.Forms.GroupBox()
      Me.cmbIvaCentroSportivo = New System.Windows.Forms.ComboBox()
      Me.Label37 = New System.Windows.Forms.Label()
      Me.tbpStampanti = New System.Windows.Forms.TabPage()
      Me.GroupBox2 = New System.Windows.Forms.GroupBox()
      Me.cmbReportComanda10 = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComanda10 = New System.Windows.Forms.ComboBox()
      Me.cmbReparto10 = New System.Windows.Forms.ComboBox()
      Me.cmbReportComanda9 = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComanda9 = New System.Windows.Forms.ComboBox()
      Me.cmbReparto9 = New System.Windows.Forms.ComboBox()
      Me.cmbReportComanda8 = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComanda8 = New System.Windows.Forms.ComboBox()
      Me.cmbReparto8 = New System.Windows.Forms.ComboBox()
      Me.cmbReportComanda7 = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComanda7 = New System.Windows.Forms.ComboBox()
      Me.cmbReparto7 = New System.Windows.Forms.ComboBox()
      Me.cmbReportComanda6 = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComanda6 = New System.Windows.Forms.ComboBox()
      Me.cmbReparto6 = New System.Windows.Forms.ComboBox()
      Me.cmbReportComanda5 = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComanda5 = New System.Windows.Forms.ComboBox()
      Me.cmbReparto5 = New System.Windows.Forms.ComboBox()
      Me.cmbReportComanda4 = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComanda4 = New System.Windows.Forms.ComboBox()
      Me.cmbReparto4 = New System.Windows.Forms.ComboBox()
      Me.cmbReportComanda3 = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComanda3 = New System.Windows.Forms.ComboBox()
      Me.cmbReparto3 = New System.Windows.Forms.ComboBox()
      Me.cmbReportComanda2 = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComanda2 = New System.Windows.Forms.ComboBox()
      Me.cmbReparto2 = New System.Windows.Forms.ComboBox()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.cmbReportComandaAgg = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComandaAgg = New System.Windows.Forms.ComboBox()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cmbReportComanda1 = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteComanda1 = New System.Windows.Forms.ComboBox()
      Me.cmbReparto1 = New System.Windows.Forms.ComboBox()
      Me.GroupBox1 = New System.Windows.Forms.GroupBox()
      Me.cmbReportScontrini = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteScontrini = New System.Windows.Forms.ComboBox()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.cmbReportProforma = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteProforma = New System.Windows.Forms.ComboBox()
      Me.cmbReportFatture = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteFatture = New System.Windows.Forms.ComboBox()
      Me.cmbReportRicevute = New System.Windows.Forms.ComboBox()
      Me.cmbStampanteRicevute = New System.Windows.Forms.ComboBox()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.tbpPalmare = New System.Windows.Forms.TabPage()
      Me.chkAbilitaPalmareAndroid = New System.Windows.Forms.CheckBox()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.cmdAggiornaFilePalmare = New System.Windows.Forms.Button()
      Me.chkAbilitaPalmareWindows = New System.Windows.Forms.CheckBox()
      Me.cmdApriPercorsoPalmare = New System.Windows.Forms.Button()
      Me.txtPercorsoRetePalmare = New System.Windows.Forms.TextBox()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.cmbFreqAggPalmare = New System.Windows.Forms.ComboBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.tbpFiscali = New System.Windows.Forms.TabPage()
      Me.grbWpos = New System.Windows.Forms.GroupBox()
      Me.cmdPercorsoDriverWPOS1 = New System.Windows.Forms.Button()
      Me.txtPercorsoDriverWPOS1 = New System.Windows.Forms.TextBox()
      Me.Label33 = New System.Windows.Forms.Label()
      Me.cmdAvviaWpos1 = New System.Windows.Forms.Button()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.txtEstensioneFileWpos1 = New System.Windows.Forms.TextBox()
      Me.Label26 = New System.Windows.Forms.Label()
      Me.txtPasswordWpos1 = New System.Windows.Forms.TextBox()
      Me.Label28 = New System.Windows.Forms.Label()
      Me.cmdPercorsoWpos1 = New System.Windows.Forms.Button()
      Me.txtPercorsoWpos1 = New System.Windows.Forms.TextBox()
      Me.Label29 = New System.Windows.Forms.Label()
      Me.cmbStampanteModello = New System.Windows.Forms.ComboBox()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.cmbStampanteProduttore = New System.Windows.Forms.ComboBox()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.grbSwing = New System.Windows.Forms.GroupBox()
      Me.Label32 = New System.Windows.Forms.Label()
      Me.cmbStampantePorta = New System.Windows.Forms.ComboBox()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.txtNomeScontrino = New System.Windows.Forms.TextBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.cmdPercorsoDriver = New System.Windows.Forms.Button()
      Me.txtPercorsoDriver = New System.Windows.Forms.TextBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.txtStampanteParametri = New System.Windows.Forms.TextBox()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.cmdPercorsoOutput = New System.Windows.Forms.Button()
      Me.txtPercorsoOutput = New System.Windows.Forms.TextBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.tbpRecovery = New System.Windows.Forms.TabPage()
      Me.lblDataSalvataggio = New System.Windows.Forms.Label()
      Me.txtPercorsoRecovery = New System.Windows.Forms.TextBox()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.chkAttivaRecovery = New System.Windows.Forms.CheckBox()
      Me.cmdApriPercorsoRecovery = New System.Windows.Forms.Button()
      Me.lblPercorsoRecovery = New System.Windows.Forms.Label()
      Me.tbpFidelity = New System.Windows.Forms.TabPage()
      Me.cmdDeselTutteCategorie = New System.Windows.Forms.Button()
      Me.cmdSelTutteCategorie = New System.Windows.Forms.Button()
      Me.ckdScontrinoPunti = New System.Windows.Forms.CheckBox()
      Me.ckdProformaPunti = New System.Windows.Forms.CheckBox()
      Me.ckdFatturaPunti = New System.Windows.Forms.CheckBox()
      Me.ckdRicevutaPunti = New System.Windows.Forms.CheckBox()
      Me.Label49 = New System.Windows.Forms.Label()
      Me.ckdlCategoriePunti = New System.Windows.Forms.CheckedListBox()
      Me.ckdMsgPunti = New System.Windows.Forms.CheckBox()
      Me.Label48 = New System.Windows.Forms.Label()
      Me.txtValPunti = New System.Windows.Forms.TextBox()
      Me.Label47 = New System.Windows.Forms.Label()
      Me.txtNomePunti = New System.Windows.Forms.TextBox()
      Me.Label45 = New System.Windows.Forms.Label()
      Me.ckdAbilitaRaccoltaPunti = New System.Windows.Forms.CheckBox()
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.tabOpzioni.SuspendLayout()
      Me.tbpGenerali.SuspendLayout()
      Me.GroupBox5.SuspendLayout()
      CType(Me.nudNumCopieStampa, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbAliquote.SuspendLayout()
      Me.tbpBarRist.SuspendLayout()
      Me.gbPrenOnLine.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      Me.tbpCamere.SuspendLayout()
      Me.GroupBox9.SuspendLayout()
      Me.GroupBox8.SuspendLayout()
      Me.GroupBox7.SuspendLayout()
      Me.GroupBox6.SuspendLayout()
      Me.tbpCentroSportivo.SuspendLayout()
      Me.GroupBox4.SuspendLayout()
      Me.tbpStampanti.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      Me.GroupBox1.SuspendLayout()
      Me.tbpPalmare.SuspendLayout()
      Me.tbpFiscali.SuspendLayout()
      Me.grbWpos.SuspendLayout()
      Me.grbSwing.SuspendLayout()
      Me.tbpRecovery.SuspendLayout()
      Me.tbpFidelity.SuspendLayout()
      Me.SuspendLayout()
      '
      'cmdAnnulla
      '
      Me.cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.cmdAnnulla.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAnnulla.Location = New System.Drawing.Point(694, 536)
      Me.cmdAnnulla.Name = "cmdAnnulla"
      Me.cmdAnnulla.Size = New System.Drawing.Size(75, 23)
      Me.cmdAnnulla.TabIndex = 1
      Me.cmdAnnulla.Text = "&Annulla"
      '
      'cmdOK
      '
      Me.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdOK.Location = New System.Drawing.Point(614, 536)
      Me.cmdOK.Name = "cmdOK"
      Me.cmdOK.Size = New System.Drawing.Size(75, 23)
      Me.cmdOK.TabIndex = 0
      Me.cmdOK.Text = "&OK"
      '
      'tabOpzioni
      '
      Me.tabOpzioni.Controls.Add(Me.tbpGenerali)
      Me.tabOpzioni.Controls.Add(Me.tbpBarRist)
      Me.tabOpzioni.Controls.Add(Me.tbpCamere)
      Me.tabOpzioni.Controls.Add(Me.tbpCentroSportivo)
      Me.tabOpzioni.Controls.Add(Me.tbpStampanti)
      Me.tabOpzioni.Controls.Add(Me.tbpPalmare)
      Me.tabOpzioni.Controls.Add(Me.tbpFiscali)
      Me.tabOpzioni.Controls.Add(Me.tbpRecovery)
      Me.tabOpzioni.Controls.Add(Me.tbpFidelity)
      Me.tabOpzioni.Location = New System.Drawing.Point(8, 8)
      Me.tabOpzioni.Name = "tabOpzioni"
      Me.tabOpzioni.SelectedIndex = 0
      Me.tabOpzioni.Size = New System.Drawing.Size(765, 520)
      Me.tabOpzioni.TabIndex = 2
      '
      'tbpGenerali
      '
      Me.tbpGenerali.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tbpGenerali.Controls.Add(Me.txtPercorsoAmica)
      Me.tbpGenerali.Controls.Add(Me.GroupBox5)
      Me.tbpGenerali.Controls.Add(Me.cmdApriPercorsoAmica)
      Me.tbpGenerali.Controls.Add(Me.grbAliquote)
      Me.tbpGenerali.Controls.Add(Me.cmbFormatoFatt)
      Me.tbpGenerali.Controls.Add(Me.chkSalvaBackup)
      Me.tbpGenerali.Controls.Add(Me.cmdApriBackup)
      Me.tbpGenerali.Controls.Add(Me.txtPercorsoBackup)
      Me.tbpGenerali.Controls.Add(Me.Label11)
      Me.tbpGenerali.Controls.Add(Me.cmdApriDB2)
      Me.tbpGenerali.Controls.Add(Me.cmdApriDB1)
      Me.tbpGenerali.Controls.Add(Me.cmbNumElementi)
      Me.tbpGenerali.Controls.Add(Me.Label2)
      Me.tbpGenerali.Controls.Add(Me.label)
      Me.tbpGenerali.Controls.Add(Me.txtPercorsoDBClienti)
      Me.tbpGenerali.Controls.Add(Me.txtPercorsoDB)
      Me.tbpGenerali.Controls.Add(Me.Label3)
      Me.tbpGenerali.Controls.Add(Me.Label1)
      Me.tbpGenerali.Controls.Add(Me.Label50)
      Me.tbpGenerali.Location = New System.Drawing.Point(4, 22)
      Me.tbpGenerali.Name = "tbpGenerali"
      Me.tbpGenerali.Size = New System.Drawing.Size(757, 494)
      Me.tbpGenerali.TabIndex = 0
      Me.tbpGenerali.Text = "Generali"
      '
      'txtPercorsoAmica
      '
      Me.txtPercorsoAmica.Location = New System.Drawing.Point(32, 232)
      Me.txtPercorsoAmica.Name = "txtPercorsoAmica"
      Me.txtPercorsoAmica.Size = New System.Drawing.Size(678, 20)
      Me.txtPercorsoAmica.TabIndex = 7
      '
      'GroupBox5
      '
      Me.GroupBox5.Controls.Add(Me.chkIvaInclusa)
      Me.GroupBox5.Controls.Add(Me.chkNumeroRicevuta)
      Me.GroupBox5.Controls.Add(Me.chkNumeroFattura)
      Me.GroupBox5.Controls.Add(Me.nudNumCopieStampa)
      Me.GroupBox5.Controls.Add(Me.txtNumeroRicevuta)
      Me.GroupBox5.Controls.Add(Me.txtNumeroFattura)
      Me.GroupBox5.Controls.Add(Me.Label58)
      Me.GroupBox5.Location = New System.Drawing.Point(32, 328)
      Me.GroupBox5.Name = "GroupBox5"
      Me.GroupBox5.Size = New System.Drawing.Size(344, 136)
      Me.GroupBox5.TabIndex = 11
      Me.GroupBox5.TabStop = False
      Me.GroupBox5.Text = "Fatture / Ricevute fiscali"
      '
      'chkIvaInclusa
      '
      Me.chkIvaInclusa.AutoSize = True
      Me.chkIvaInclusa.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkIvaInclusa.Checked = True
      Me.chkIvaInclusa.CheckState = System.Windows.Forms.CheckState.Checked
      Me.chkIvaInclusa.Enabled = False
      Me.chkIvaInclusa.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIvaInclusa.Location = New System.Drawing.Point(24, 32)
      Me.chkIvaInclusa.Name = "chkIvaInclusa"
      Me.chkIvaInclusa.Size = New System.Drawing.Size(116, 18)
      Me.chkIvaInclusa.TabIndex = 0
      Me.chkIvaInclusa.Text = "Prezzi IVA inclusa"
      '
      'chkNumeroRicevuta
      '
      Me.chkNumeroRicevuta.AutoSize = True
      Me.chkNumeroRicevuta.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkNumeroRicevuta.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkNumeroRicevuta.Location = New System.Drawing.Point(24, 80)
      Me.chkNumeroRicevuta.Name = "chkNumeroRicevuta"
      Me.chkNumeroRicevuta.Size = New System.Drawing.Size(137, 18)
      Me.chkNumeroRicevuta.TabIndex = 3
      Me.chkNumeroRicevuta.Text = "N° prossima Ricevuta:"
      '
      'chkNumeroFattura
      '
      Me.chkNumeroFattura.AutoSize = True
      Me.chkNumeroFattura.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkNumeroFattura.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkNumeroFattura.Location = New System.Drawing.Point(24, 56)
      Me.chkNumeroFattura.Name = "chkNumeroFattura"
      Me.chkNumeroFattura.Size = New System.Drawing.Size(127, 18)
      Me.chkNumeroFattura.TabIndex = 1
      Me.chkNumeroFattura.Text = "N° prossima Fattura:"
      '
      'nudNumCopieStampa
      '
      Me.nudNumCopieStampa.Location = New System.Drawing.Point(160, 104)
      Me.nudNumCopieStampa.Maximum = New Decimal(New Integer() {10, 0, 0, 0})
      Me.nudNumCopieStampa.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.nudNumCopieStampa.Name = "nudNumCopieStampa"
      Me.nudNumCopieStampa.Size = New System.Drawing.Size(72, 20)
      Me.nudNumCopieStampa.TabIndex = 6
      Me.nudNumCopieStampa.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.nudNumCopieStampa.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'txtNumeroRicevuta
      '
      Me.txtNumeroRicevuta.Enabled = False
      Me.txtNumeroRicevuta.ForeColor = System.Drawing.Color.Red
      Me.txtNumeroRicevuta.Location = New System.Drawing.Point(160, 80)
      Me.txtNumeroRicevuta.Name = "txtNumeroRicevuta"
      Me.txtNumeroRicevuta.Size = New System.Drawing.Size(72, 20)
      Me.txtNumeroRicevuta.TabIndex = 4
      Me.txtNumeroRicevuta.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNumeroFattura
      '
      Me.txtNumeroFattura.Enabled = False
      Me.txtNumeroFattura.ForeColor = System.Drawing.Color.Red
      Me.txtNumeroFattura.Location = New System.Drawing.Point(160, 56)
      Me.txtNumeroFattura.Name = "txtNumeroFattura"
      Me.txtNumeroFattura.Size = New System.Drawing.Size(72, 20)
      Me.txtNumeroFattura.TabIndex = 2
      Me.txtNumeroFattura.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label58
      '
      Me.Label58.AutoSize = True
      Me.Label58.BackColor = System.Drawing.Color.Transparent
      Me.Label58.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label58.ForeColor = System.Drawing.Color.Black
      Me.Label58.Location = New System.Drawing.Point(24, 104)
      Me.Label58.Name = "Label58"
      Me.Label58.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label58.Size = New System.Drawing.Size(113, 13)
      Me.Label58.TabIndex = 5
      Me.Label58.Text = "Stampa numero copie:"
      '
      'cmdApriPercorsoAmica
      '
      Me.cmdApriPercorsoAmica.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdApriPercorsoAmica.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdApriPercorsoAmica.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriPercorsoAmica.Location = New System.Drawing.Point(710, 232)
      Me.cmdApriPercorsoAmica.Name = "cmdApriPercorsoAmica"
      Me.cmdApriPercorsoAmica.Size = New System.Drawing.Size(24, 20)
      Me.cmdApriPercorsoAmica.TabIndex = 8
      Me.cmdApriPercorsoAmica.Tag = ""
      Me.cmdApriPercorsoAmica.Text = "..."
      '
      'grbAliquote
      '
      Me.grbAliquote.Controls.Add(Me.Label42)
      Me.grbAliquote.Controls.Add(Me.Label41)
      Me.grbAliquote.Controls.Add(Me.Label40)
      Me.grbAliquote.Controls.Add(Me.Label38)
      Me.grbAliquote.Controls.Add(Me.txtAliquotaIva2)
      Me.grbAliquote.Controls.Add(Me.Label30)
      Me.grbAliquote.Controls.Add(Me.txtAliquotaIva1)
      Me.grbAliquote.Controls.Add(Me.Label31)
      Me.grbAliquote.Controls.Add(Me.txtAliquotaIva4)
      Me.grbAliquote.Controls.Add(Me.Label25)
      Me.grbAliquote.Controls.Add(Me.txtAliquotaIva3)
      Me.grbAliquote.Controls.Add(Me.Label27)
      Me.grbAliquote.Location = New System.Drawing.Point(393, 328)
      Me.grbAliquote.Name = "grbAliquote"
      Me.grbAliquote.Size = New System.Drawing.Size(341, 136)
      Me.grbAliquote.TabIndex = 12
      Me.grbAliquote.TabStop = False
      Me.grbAliquote.Text = "Aliquote IVA associate ai reparti:"
      '
      'Label42
      '
      Me.Label42.AutoSize = True
      Me.Label42.BackColor = System.Drawing.Color.Transparent
      Me.Label42.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label42.ForeColor = System.Drawing.Color.Black
      Me.Label42.Location = New System.Drawing.Point(184, 104)
      Me.Label42.Name = "Label42"
      Me.Label42.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label42.Size = New System.Drawing.Size(15, 13)
      Me.Label42.TabIndex = 231
      Me.Label42.Text = "%"
      '
      'Label41
      '
      Me.Label41.AutoSize = True
      Me.Label41.BackColor = System.Drawing.Color.Transparent
      Me.Label41.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label41.ForeColor = System.Drawing.Color.Black
      Me.Label41.Location = New System.Drawing.Point(184, 80)
      Me.Label41.Name = "Label41"
      Me.Label41.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label41.Size = New System.Drawing.Size(15, 13)
      Me.Label41.TabIndex = 230
      Me.Label41.Text = "%"
      '
      'Label40
      '
      Me.Label40.AutoSize = True
      Me.Label40.BackColor = System.Drawing.Color.Transparent
      Me.Label40.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label40.ForeColor = System.Drawing.Color.Black
      Me.Label40.Location = New System.Drawing.Point(184, 56)
      Me.Label40.Name = "Label40"
      Me.Label40.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label40.Size = New System.Drawing.Size(15, 13)
      Me.Label40.TabIndex = 229
      Me.Label40.Text = "%"
      '
      'Label38
      '
      Me.Label38.AutoSize = True
      Me.Label38.BackColor = System.Drawing.Color.Transparent
      Me.Label38.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label38.ForeColor = System.Drawing.Color.Black
      Me.Label38.Location = New System.Drawing.Point(184, 32)
      Me.Label38.Name = "Label38"
      Me.Label38.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label38.Size = New System.Drawing.Size(15, 13)
      Me.Label38.TabIndex = 228
      Me.Label38.Text = "%"
      '
      'txtAliquotaIva2
      '
      Me.txtAliquotaIva2.ForeColor = System.Drawing.Color.Red
      Me.txtAliquotaIva2.Location = New System.Drawing.Point(104, 56)
      Me.txtAliquotaIva2.MaxLength = 2
      Me.txtAliquotaIva2.Name = "txtAliquotaIva2"
      Me.txtAliquotaIva2.Size = New System.Drawing.Size(80, 20)
      Me.txtAliquotaIva2.TabIndex = 1
      Me.txtAliquotaIva2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label30
      '
      Me.Label30.AutoSize = True
      Me.Label30.BackColor = System.Drawing.Color.Transparent
      Me.Label30.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label30.ForeColor = System.Drawing.Color.Black
      Me.Label30.Location = New System.Drawing.Point(24, 56)
      Me.Label30.Name = "Label30"
      Me.Label30.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label30.Size = New System.Drawing.Size(57, 13)
      Me.Label30.TabIndex = 227
      Me.Label30.Text = "Reparto 2:"
      '
      'txtAliquotaIva1
      '
      Me.txtAliquotaIva1.ForeColor = System.Drawing.Color.Red
      Me.txtAliquotaIva1.Location = New System.Drawing.Point(104, 32)
      Me.txtAliquotaIva1.MaxLength = 2
      Me.txtAliquotaIva1.Name = "txtAliquotaIva1"
      Me.txtAliquotaIva1.Size = New System.Drawing.Size(80, 20)
      Me.txtAliquotaIva1.TabIndex = 0
      Me.txtAliquotaIva1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label31
      '
      Me.Label31.AutoSize = True
      Me.Label31.BackColor = System.Drawing.Color.Transparent
      Me.Label31.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label31.ForeColor = System.Drawing.Color.Black
      Me.Label31.Location = New System.Drawing.Point(24, 32)
      Me.Label31.Name = "Label31"
      Me.Label31.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label31.Size = New System.Drawing.Size(57, 13)
      Me.Label31.TabIndex = 0
      Me.Label31.Text = "Reparto 1:"
      '
      'txtAliquotaIva4
      '
      Me.txtAliquotaIva4.ForeColor = System.Drawing.Color.Red
      Me.txtAliquotaIva4.Location = New System.Drawing.Point(104, 104)
      Me.txtAliquotaIva4.MaxLength = 2
      Me.txtAliquotaIva4.Name = "txtAliquotaIva4"
      Me.txtAliquotaIva4.Size = New System.Drawing.Size(80, 20)
      Me.txtAliquotaIva4.TabIndex = 3
      Me.txtAliquotaIva4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label25
      '
      Me.Label25.AutoSize = True
      Me.Label25.BackColor = System.Drawing.Color.Transparent
      Me.Label25.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label25.ForeColor = System.Drawing.Color.Black
      Me.Label25.Location = New System.Drawing.Point(24, 104)
      Me.Label25.Name = "Label25"
      Me.Label25.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label25.Size = New System.Drawing.Size(57, 13)
      Me.Label25.TabIndex = 223
      Me.Label25.Text = "Reparto 4:"
      '
      'txtAliquotaIva3
      '
      Me.txtAliquotaIva3.ForeColor = System.Drawing.Color.Red
      Me.txtAliquotaIva3.Location = New System.Drawing.Point(104, 80)
      Me.txtAliquotaIva3.MaxLength = 2
      Me.txtAliquotaIva3.Name = "txtAliquotaIva3"
      Me.txtAliquotaIva3.Size = New System.Drawing.Size(80, 20)
      Me.txtAliquotaIva3.TabIndex = 2
      Me.txtAliquotaIva3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label27
      '
      Me.Label27.AutoSize = True
      Me.Label27.BackColor = System.Drawing.Color.Transparent
      Me.Label27.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label27.ForeColor = System.Drawing.Color.Black
      Me.Label27.Location = New System.Drawing.Point(24, 80)
      Me.Label27.Name = "Label27"
      Me.Label27.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label27.Size = New System.Drawing.Size(57, 13)
      Me.Label27.TabIndex = 221
      Me.Label27.Text = "Reparto 3:"
      '
      'cmbFormatoFatt
      '
      Me.cmbFormatoFatt.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFormatoFatt.Items.AddRange(New Object() {"GRANDE: (1 copia in verticale su foglio formato A4)", "PICCOLA: (2 copie in orizzontale su foglio formato A4)"})
      Me.cmbFormatoFatt.Location = New System.Drawing.Point(32, 288)
      Me.cmbFormatoFatt.Name = "cmbFormatoFatt"
      Me.cmbFormatoFatt.Size = New System.Drawing.Size(344, 21)
      Me.cmbFormatoFatt.TabIndex = 9
      '
      'chkSalvaBackup
      '
      Me.chkSalvaBackup.AutoSize = True
      Me.chkSalvaBackup.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkSalvaBackup.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkSalvaBackup.Location = New System.Drawing.Point(32, 184)
      Me.chkSalvaBackup.Name = "chkSalvaBackup"
      Me.chkSalvaBackup.Size = New System.Drawing.Size(275, 18)
      Me.chkSalvaBackup.TabIndex = 6
      Me.chkSalvaBackup.Text = "Salva una copia di Backup all'uscita del programma"
      '
      'cmdApriBackup
      '
      Me.cmdApriBackup.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdApriBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdApriBackup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriBackup.Location = New System.Drawing.Point(710, 152)
      Me.cmdApriBackup.Name = "cmdApriBackup"
      Me.cmdApriBackup.Size = New System.Drawing.Size(24, 20)
      Me.cmdApriBackup.TabIndex = 5
      Me.cmdApriBackup.Tag = ""
      Me.cmdApriBackup.Text = "..."
      '
      'txtPercorsoBackup
      '
      Me.txtPercorsoBackup.Location = New System.Drawing.Point(32, 152)
      Me.txtPercorsoBackup.Name = "txtPercorsoBackup"
      Me.txtPercorsoBackup.Size = New System.Drawing.Size(678, 20)
      Me.txtPercorsoBackup.TabIndex = 4
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.BackColor = System.Drawing.Color.Transparent
      Me.Label11.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label11.ForeColor = System.Drawing.Color.Black
      Me.Label11.Location = New System.Drawing.Point(32, 136)
      Me.Label11.Name = "Label11"
      Me.Label11.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label11.Size = New System.Drawing.Size(200, 13)
      Me.Label11.TabIndex = 188
      Me.Label11.Text = "Percorso del file di Backup del database:"
      '
      'cmdApriDB2
      '
      Me.cmdApriDB2.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdApriDB2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdApriDB2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriDB2.Location = New System.Drawing.Point(710, 96)
      Me.cmdApriDB2.Name = "cmdApriDB2"
      Me.cmdApriDB2.Size = New System.Drawing.Size(24, 20)
      Me.cmdApriDB2.TabIndex = 3
      Me.cmdApriDB2.Tag = ""
      Me.cmdApriDB2.Text = "..."
      '
      'cmdApriDB1
      '
      Me.cmdApriDB1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdApriDB1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdApriDB1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriDB1.Location = New System.Drawing.Point(710, 48)
      Me.cmdApriDB1.Name = "cmdApriDB1"
      Me.cmdApriDB1.Size = New System.Drawing.Size(24, 20)
      Me.cmdApriDB1.TabIndex = 1
      Me.cmdApriDB1.Tag = ""
      Me.cmdApriDB1.Text = "..."
      '
      'cmbNumElementi
      '
      Me.cmbNumElementi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNumElementi.Items.AddRange(New Object() {"10", "20", "30", "40", "50", "60", "70", "80", "90", "100"})
      Me.cmbNumElementi.Location = New System.Drawing.Point(534, 288)
      Me.cmbNumElementi.Name = "cmbNumElementi"
      Me.cmbNumElementi.Size = New System.Drawing.Size(200, 21)
      Me.cmbNumElementi.TabIndex = 10
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.BackColor = System.Drawing.Color.Transparent
      Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label2.ForeColor = System.Drawing.Color.Black
      Me.Label2.Location = New System.Drawing.Point(534, 272)
      Me.Label2.Name = "Label2"
      Me.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label2.Size = New System.Drawing.Size(195, 13)
      Me.Label2.TabIndex = 184
      Me.Label2.Text = "Numero elementi visualizzati per pagina:"
      '
      'label
      '
      Me.label.AutoSize = True
      Me.label.BackColor = System.Drawing.Color.Transparent
      Me.label.Cursor = System.Windows.Forms.Cursors.Default
      Me.label.ForeColor = System.Drawing.Color.Black
      Me.label.Location = New System.Drawing.Point(32, 32)
      Me.label.Name = "label"
      Me.label.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.label.Size = New System.Drawing.Size(99, 13)
      Me.label.TabIndex = 183
      Me.label.Text = "Percorso database:"
      '
      'txtPercorsoDBClienti
      '
      Me.txtPercorsoDBClienti.Location = New System.Drawing.Point(32, 96)
      Me.txtPercorsoDBClienti.Name = "txtPercorsoDBClienti"
      Me.txtPercorsoDBClienti.Size = New System.Drawing.Size(678, 20)
      Me.txtPercorsoDBClienti.TabIndex = 2
      '
      'txtPercorsoDB
      '
      Me.txtPercorsoDB.Location = New System.Drawing.Point(32, 48)
      Me.txtPercorsoDB.Name = "txtPercorsoDB"
      Me.txtPercorsoDB.Size = New System.Drawing.Size(678, 20)
      Me.txtPercorsoDB.TabIndex = 0
      '
      'Label3
      '
      Me.Label3.AutoSize = True
      Me.Label3.BackColor = System.Drawing.Color.Transparent
      Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label3.ForeColor = System.Drawing.Color.Black
      Me.Label3.Location = New System.Drawing.Point(32, 80)
      Me.Label3.Name = "Label3"
      Me.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label3.Size = New System.Drawing.Size(164, 13)
      Me.Label3.TabIndex = 182
      Me.Label3.Text = "Percorso database tabella Clienti:"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.BackColor = System.Drawing.Color.Transparent
      Me.Label1.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(32, 272)
      Me.Label1.Name = "Label1"
      Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label1.Size = New System.Drawing.Size(154, 13)
      Me.Label1.TabIndex = 185
      Me.Label1.Text = "Formato Fattura per le Aziende:"
      '
      'Label50
      '
      Me.Label50.AutoSize = True
      Me.Label50.BackColor = System.Drawing.Color.Transparent
      Me.Label50.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label50.ForeColor = System.Drawing.Color.Black
      Me.Label50.Location = New System.Drawing.Point(32, 216)
      Me.Label50.Name = "Label50"
      Me.Label50.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label50.Size = New System.Drawing.Size(137, 13)
      Me.Label50.TabIndex = 220
      Me.Label50.Text = "Percorso Gestionale Amica:"
      '
      'tbpBarRist
      '
      Me.tbpBarRist.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tbpBarRist.Controls.Add(Me.gbPrenOnLine)
      Me.tbpBarRist.Controls.Add(Me.GroupBox3)
      Me.tbpBarRist.Location = New System.Drawing.Point(4, 22)
      Me.tbpBarRist.Name = "tbpBarRist"
      Me.tbpBarRist.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpBarRist.Size = New System.Drawing.Size(757, 494)
      Me.tbpBarRist.TabIndex = 6
      Me.tbpBarRist.Text = "Bar/Ristorante"
      '
      'gbPrenOnLine
      '
      Me.gbPrenOnLine.Controls.Add(Me.cmdImpostazioniTavAgent)
      Me.gbPrenOnLine.Controls.Add(Me.cmdColorePrenTavAgent)
      Me.gbPrenOnLine.Controls.Add(Me.Label44)
      Me.gbPrenOnLine.Controls.Add(Me.ckbAbilitaRicezioneTavAgent)
      Me.gbPrenOnLine.Controls.Add(Me.cmdPercorsoFileTavAgent)
      Me.gbPrenOnLine.Controls.Add(Me.txtPercorsoFileTavAgent)
      Me.gbPrenOnLine.Controls.Add(Me.Label43)
      Me.gbPrenOnLine.Controls.Add(Me.cmdPercorsoCartellaTavAgent)
      Me.gbPrenOnLine.Controls.Add(Me.txtPercorsoCartellaTavAgent)
      Me.gbPrenOnLine.Controls.Add(Me.Label46)
      Me.gbPrenOnLine.Controls.Add(Me.cmdAvviaTavAgent)
      Me.gbPrenOnLine.Controls.Add(Me.ckbNotificaTavAgent)
      Me.gbPrenOnLine.Location = New System.Drawing.Point(24, 192)
      Me.gbPrenOnLine.Name = "gbPrenOnLine"
      Me.gbPrenOnLine.Size = New System.Drawing.Size(714, 280)
      Me.gbPrenOnLine.TabIndex = 191
      Me.gbPrenOnLine.TabStop = False
      Me.gbPrenOnLine.Text = "Tavoloso - Prenotazione on-line dei tavoli"
      '
      'cmdImpostazioniTavAgent
      '
      Me.cmdImpostazioniTavAgent.Location = New System.Drawing.Point(224, 128)
      Me.cmdImpostazioniTavAgent.Name = "cmdImpostazioniTavAgent"
      Me.cmdImpostazioniTavAgent.Size = New System.Drawing.Size(160, 32)
      Me.cmdImpostazioniTavAgent.TabIndex = 4
      Me.cmdImpostazioniTavAgent.Text = "&Impostazioni Tavoloso Agent"
      Me.cmdImpostazioniTavAgent.UseVisualStyleBackColor = True
      '
      'cmdColorePrenTavAgent
      '
      Me.cmdColorePrenTavAgent.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColorePrenTavAgent.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColorePrenTavAgent.Location = New System.Drawing.Point(440, 240)
      Me.cmdColorePrenTavAgent.Name = "cmdColorePrenTavAgent"
      Me.cmdColorePrenTavAgent.Size = New System.Drawing.Size(112, 19)
      Me.cmdColorePrenTavAgent.TabIndex = 8
      Me.cmdColorePrenTavAgent.TabStop = False
      Me.cmdColorePrenTavAgent.UseVisualStyleBackColor = False
      '
      'Label44
      '
      Me.Label44.AutoSize = True
      Me.Label44.BackColor = System.Drawing.Color.Transparent
      Me.Label44.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label44.ForeColor = System.Drawing.Color.Black
      Me.Label44.Location = New System.Drawing.Point(24, 240)
      Me.Label44.Name = "Label44"
      Me.Label44.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label44.Size = New System.Drawing.Size(385, 13)
      Me.Label44.TabIndex = 237
      Me.Label44.Text = "Colore delle prenotazioni ricevute. Verranno evidenziate nell'elenco prenotazioni" &
    ":"
      '
      'ckbAbilitaRicezioneTavAgent
      '
      Me.ckbAbilitaRicezioneTavAgent.AutoSize = True
      Me.ckbAbilitaRicezioneTavAgent.Location = New System.Drawing.Point(24, 176)
      Me.ckbAbilitaRicezioneTavAgent.Name = "ckbAbilitaRicezioneTavAgent"
      Me.ckbAbilitaRicezioneTavAgent.Size = New System.Drawing.Size(214, 17)
      Me.ckbAbilitaRicezioneTavAgent.TabIndex = 6
      Me.ckbAbilitaRicezioneTavAgent.Text = "Abilita ricezione automatica prenotazioni"
      Me.ckbAbilitaRicezioneTavAgent.UseVisualStyleBackColor = True
      '
      'cmdPercorsoFileTavAgent
      '
      Me.cmdPercorsoFileTavAgent.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdPercorsoFileTavAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPercorsoFileTavAgent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdPercorsoFileTavAgent.Location = New System.Drawing.Point(528, 48)
      Me.cmdPercorsoFileTavAgent.Name = "cmdPercorsoFileTavAgent"
      Me.cmdPercorsoFileTavAgent.Size = New System.Drawing.Size(24, 20)
      Me.cmdPercorsoFileTavAgent.TabIndex = 1
      Me.cmdPercorsoFileTavAgent.Tag = ""
      Me.cmdPercorsoFileTavAgent.Text = "..."
      '
      'txtPercorsoFileTavAgent
      '
      Me.txtPercorsoFileTavAgent.Location = New System.Drawing.Point(24, 48)
      Me.txtPercorsoFileTavAgent.Name = "txtPercorsoFileTavAgent"
      Me.txtPercorsoFileTavAgent.Size = New System.Drawing.Size(504, 20)
      Me.txtPercorsoFileTavAgent.TabIndex = 0
      '
      'Label43
      '
      Me.Label43.AutoSize = True
      Me.Label43.BackColor = System.Drawing.Color.Transparent
      Me.Label43.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label43.ForeColor = System.Drawing.Color.Black
      Me.Label43.Location = New System.Drawing.Point(24, 32)
      Me.Label43.Name = "Label43"
      Me.Label43.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label43.Size = New System.Drawing.Size(146, 13)
      Me.Label43.TabIndex = 234
      Me.Label43.Text = "Percorso file Tavoloso Agent:"
      '
      'cmdPercorsoCartellaTavAgent
      '
      Me.cmdPercorsoCartellaTavAgent.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdPercorsoCartellaTavAgent.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPercorsoCartellaTavAgent.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdPercorsoCartellaTavAgent.Location = New System.Drawing.Point(528, 96)
      Me.cmdPercorsoCartellaTavAgent.Name = "cmdPercorsoCartellaTavAgent"
      Me.cmdPercorsoCartellaTavAgent.Size = New System.Drawing.Size(24, 20)
      Me.cmdPercorsoCartellaTavAgent.TabIndex = 3
      Me.cmdPercorsoCartellaTavAgent.Tag = ""
      Me.cmdPercorsoCartellaTavAgent.Text = "..."
      '
      'txtPercorsoCartellaTavAgent
      '
      Me.txtPercorsoCartellaTavAgent.Location = New System.Drawing.Point(24, 96)
      Me.txtPercorsoCartellaTavAgent.Name = "txtPercorsoCartellaTavAgent"
      Me.txtPercorsoCartellaTavAgent.Size = New System.Drawing.Size(504, 20)
      Me.txtPercorsoCartellaTavAgent.TabIndex = 2
      '
      'Label46
      '
      Me.Label46.AutoSize = True
      Me.Label46.BackColor = System.Drawing.Color.Transparent
      Me.Label46.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label46.ForeColor = System.Drawing.Color.Black
      Me.Label46.Location = New System.Drawing.Point(24, 80)
      Me.Label46.Name = "Label46"
      Me.Label46.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label46.Size = New System.Drawing.Size(221, 13)
      Me.Label46.TabIndex = 231
      Me.Label46.Text = "Percorso cartella di lavoro di Tavoloso Agent:"
      '
      'cmdAvviaTavAgent
      '
      Me.cmdAvviaTavAgent.Location = New System.Drawing.Point(392, 128)
      Me.cmdAvviaTavAgent.Name = "cmdAvviaTavAgent"
      Me.cmdAvviaTavAgent.Size = New System.Drawing.Size(160, 32)
      Me.cmdAvviaTavAgent.TabIndex = 5
      Me.cmdAvviaTavAgent.Text = "&Avvia Tavoloso Agent"
      Me.cmdAvviaTavAgent.UseVisualStyleBackColor = True
      '
      'ckbNotificaTavAgent
      '
      Me.ckbNotificaTavAgent.AutoSize = True
      Me.ckbNotificaTavAgent.Location = New System.Drawing.Point(24, 208)
      Me.ckbNotificaTavAgent.Name = "ckbNotificaTavAgent"
      Me.ckbNotificaTavAgent.Size = New System.Drawing.Size(292, 17)
      Me.ckbNotificaTavAgent.TabIndex = 7
      Me.ckbNotificaTavAgent.Text = "Riproduci effetto sonoro quando arriva una prenotazione"
      Me.ckbNotificaTavAgent.UseVisualStyleBackColor = True
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.ckbEffettiSonoriPos)
      Me.GroupBox3.Controls.Add(Me.txtServizioRistorante)
      Me.GroupBox3.Controls.Add(Me.Label34)
      Me.GroupBox3.Controls.Add(Me.txtCopertoRistorante)
      Me.GroupBox3.Controls.Add(Me.cmbIvaRistorante)
      Me.GroupBox3.Controls.Add(Me.Label36)
      Me.GroupBox3.Controls.Add(Me.Label35)
      Me.GroupBox3.Location = New System.Drawing.Point(24, 24)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(714, 144)
      Me.GroupBox3.TabIndex = 190
      Me.GroupBox3.TabStop = False
      Me.GroupBox3.Text = "Varie"
      '
      'ckbEffettiSonoriPos
      '
      Me.ckbEffettiSonoriPos.AutoSize = True
      Me.ckbEffettiSonoriPos.Location = New System.Drawing.Point(344, 32)
      Me.ckbEffettiSonoriPos.Name = "ckbEffettiSonoriPos"
      Me.ckbEffettiSonoriPos.Size = New System.Drawing.Size(210, 17)
      Me.ckbEffettiSonoriPos.TabIndex = 193
      Me.ckbEffettiSonoriPos.Text = "Riproduci effetti sonori nel Punto cassa"
      Me.ckbEffettiSonoriPos.UseVisualStyleBackColor = True
      '
      'txtServizioRistorante
      '
      Me.txtServizioRistorante.ForeColor = System.Drawing.Color.Red
      Me.txtServizioRistorante.Location = New System.Drawing.Point(144, 96)
      Me.txtServizioRistorante.Name = "txtServizioRistorante"
      Me.txtServizioRistorante.Size = New System.Drawing.Size(112, 20)
      Me.txtServizioRistorante.TabIndex = 2
      Me.txtServizioRistorante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label34
      '
      Me.Label34.AutoSize = True
      Me.Label34.BackColor = System.Drawing.Color.Transparent
      Me.Label34.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label34.ForeColor = System.Drawing.Color.Black
      Me.Label34.Location = New System.Drawing.Point(24, 32)
      Me.Label34.Name = "Label34"
      Me.Label34.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label34.Size = New System.Drawing.Size(112, 13)
      Me.Label34.TabIndex = 186
      Me.Label34.Text = "Aliquota IVA standard:"
      '
      'txtCopertoRistorante
      '
      Me.txtCopertoRistorante.ForeColor = System.Drawing.Color.Red
      Me.txtCopertoRistorante.Location = New System.Drawing.Point(144, 64)
      Me.txtCopertoRistorante.Name = "txtCopertoRistorante"
      Me.txtCopertoRistorante.Size = New System.Drawing.Size(112, 20)
      Me.txtCopertoRistorante.TabIndex = 1
      Me.txtCopertoRistorante.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'cmbIvaRistorante
      '
      Me.cmbIvaRistorante.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIvaRistorante.Items.AddRange(New Object() {"Reparto 1", "Reparto 2", "Reparto 3", "Reparto 4"})
      Me.cmbIvaRistorante.Location = New System.Drawing.Point(144, 32)
      Me.cmbIvaRistorante.Name = "cmbIvaRistorante"
      Me.cmbIvaRistorante.Size = New System.Drawing.Size(112, 21)
      Me.cmbIvaRistorante.TabIndex = 0
      '
      'Label36
      '
      Me.Label36.AutoSize = True
      Me.Label36.BackColor = System.Drawing.Color.Transparent
      Me.Label36.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label36.ForeColor = System.Drawing.Color.Black
      Me.Label36.Location = New System.Drawing.Point(24, 96)
      Me.Label36.Name = "Label36"
      Me.Label36.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label36.Size = New System.Drawing.Size(88, 13)
      Me.Label36.TabIndex = 189
      Me.Label36.Text = "Costo Servizio %:"
      '
      'Label35
      '
      Me.Label35.AutoSize = True
      Me.Label35.BackColor = System.Drawing.Color.Transparent
      Me.Label35.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label35.ForeColor = System.Drawing.Color.Black
      Me.Label35.Location = New System.Drawing.Point(24, 64)
      Me.Label35.Name = "Label35"
      Me.Label35.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label35.Size = New System.Drawing.Size(80, 13)
      Me.Label35.TabIndex = 188
      Me.Label35.Text = "Costo Coperto: "
      '
      'tbpCamere
      '
      Me.tbpCamere.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tbpCamere.Controls.Add(Me.GroupBox9)
      Me.tbpCamere.Controls.Add(Me.GroupBox8)
      Me.tbpCamere.Controls.Add(Me.GroupBox7)
      Me.tbpCamere.Controls.Add(Me.GroupBox6)
      Me.tbpCamere.Location = New System.Drawing.Point(4, 22)
      Me.tbpCamere.Name = "tbpCamere"
      Me.tbpCamere.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpCamere.Size = New System.Drawing.Size(757, 494)
      Me.tbpCamere.TabIndex = 9
      Me.tbpCamere.Text = "Camere"
      '
      'GroupBox9
      '
      Me.GroupBox9.Controls.Add(Me.txtDescrizioneTassaSogg)
      Me.GroupBox9.Controls.Add(Me.Label54)
      Me.GroupBox9.Controls.Add(Me.ckbApplicaTassaRagazzi)
      Me.GroupBox9.Controls.Add(Me.ckbApplicaTassaNeonati)
      Me.GroupBox9.Controls.Add(Me.txtTassaSoggiorno)
      Me.GroupBox9.Controls.Add(Me.ckbApplicaTassaBambini)
      Me.GroupBox9.Controls.Add(Me.Label52)
      Me.GroupBox9.Location = New System.Drawing.Point(392, 128)
      Me.GroupBox9.Name = "GroupBox9"
      Me.GroupBox9.Size = New System.Drawing.Size(344, 199)
      Me.GroupBox9.TabIndex = 2
      Me.GroupBox9.TabStop = False
      Me.GroupBox9.Text = "Tassa di Soggiorno"
      '
      'txtDescrizioneTassaSogg
      '
      Me.txtDescrizioneTassaSogg.ForeColor = System.Drawing.Color.Black
      Me.txtDescrizioneTassaSogg.Location = New System.Drawing.Point(27, 80)
      Me.txtDescrizioneTassaSogg.Name = "txtDescrizioneTassaSogg"
      Me.txtDescrizioneTassaSogg.Size = New System.Drawing.Size(293, 20)
      Me.txtDescrizioneTassaSogg.TabIndex = 1
      '
      'Label54
      '
      Me.Label54.AutoSize = True
      Me.Label54.BackColor = System.Drawing.Color.Transparent
      Me.Label54.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label54.ForeColor = System.Drawing.Color.Black
      Me.Label54.Location = New System.Drawing.Point(24, 64)
      Me.Label54.Name = "Label54"
      Me.Label54.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label54.Size = New System.Drawing.Size(134, 13)
      Me.Label54.TabIndex = 189
      Me.Label54.Text = "Descrizione nei documenti:"
      '
      'ckbApplicaTassaRagazzi
      '
      Me.ckbApplicaTassaRagazzi.AutoSize = True
      Me.ckbApplicaTassaRagazzi.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.ckbApplicaTassaRagazzi.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ckbApplicaTassaRagazzi.Location = New System.Drawing.Point(27, 163)
      Me.ckbApplicaTassaRagazzi.Name = "ckbApplicaTassaRagazzi"
      Me.ckbApplicaTassaRagazzi.Size = New System.Drawing.Size(119, 18)
      Me.ckbApplicaTassaRagazzi.TabIndex = 4
      Me.ckbApplicaTassaRagazzi.Text = "Applica ai Ragazzi"
      '
      'ckbApplicaTassaNeonati
      '
      Me.ckbApplicaTassaNeonati.AutoSize = True
      Me.ckbApplicaTassaNeonati.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.ckbApplicaTassaNeonati.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ckbApplicaTassaNeonati.Location = New System.Drawing.Point(27, 115)
      Me.ckbApplicaTassaNeonati.Name = "ckbApplicaTassaNeonati"
      Me.ckbApplicaTassaNeonati.Size = New System.Drawing.Size(118, 18)
      Me.ckbApplicaTassaNeonati.TabIndex = 2
      Me.ckbApplicaTassaNeonati.Text = "Applica ai Neonati"
      '
      'txtTassaSoggiorno
      '
      Me.txtTassaSoggiorno.ForeColor = System.Drawing.Color.Red
      Me.txtTassaSoggiorno.Location = New System.Drawing.Point(208, 32)
      Me.txtTassaSoggiorno.Name = "txtTassaSoggiorno"
      Me.txtTassaSoggiorno.Size = New System.Drawing.Size(112, 20)
      Me.txtTassaSoggiorno.TabIndex = 0
      Me.txtTassaSoggiorno.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'ckbApplicaTassaBambini
      '
      Me.ckbApplicaTassaBambini.AutoSize = True
      Me.ckbApplicaTassaBambini.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.ckbApplicaTassaBambini.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ckbApplicaTassaBambini.Location = New System.Drawing.Point(27, 139)
      Me.ckbApplicaTassaBambini.Name = "ckbApplicaTassaBambini"
      Me.ckbApplicaTassaBambini.Size = New System.Drawing.Size(118, 18)
      Me.ckbApplicaTassaBambini.TabIndex = 3
      Me.ckbApplicaTassaBambini.Text = "Applica ai Bambini"
      '
      'Label52
      '
      Me.Label52.AutoSize = True
      Me.Label52.BackColor = System.Drawing.Color.Transparent
      Me.Label52.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label52.ForeColor = System.Drawing.Color.Black
      Me.Label52.Location = New System.Drawing.Point(24, 32)
      Me.Label52.Name = "Label52"
      Me.Label52.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label52.Size = New System.Drawing.Size(129, 13)
      Me.Label52.TabIndex = 188
      Me.Label52.Text = "Costo Tassa di soggiorno:"
      '
      'GroupBox8
      '
      Me.GroupBox8.Controls.Add(Me.ckbNumeroModC59)
      Me.GroupBox8.Controls.Add(Me.ckbNumeroSchedinaPS)
      Me.GroupBox8.Controls.Add(Me.txtNumeroModC59)
      Me.GroupBox8.Controls.Add(Me.txtNumeroSchedinaPS)
      Me.GroupBox8.Location = New System.Drawing.Point(24, 352)
      Me.GroupBox8.Name = "GroupBox8"
      Me.GroupBox8.Size = New System.Drawing.Size(712, 112)
      Me.GroupBox8.TabIndex = 3
      Me.GroupBox8.TabStop = False
      Me.GroupBox8.Text = "Documenti:"
      '
      'ckbNumeroModC59
      '
      Me.ckbNumeroModC59.AutoSize = True
      Me.ckbNumeroModC59.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.ckbNumeroModC59.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ckbNumeroModC59.Location = New System.Drawing.Point(24, 64)
      Me.ckbNumeroModC59.Name = "ckbNumeroModC59"
      Me.ckbNumeroModC59.Size = New System.Drawing.Size(192, 18)
      Me.ckbNumeroModC59.TabIndex = 2
      Me.ckbNumeroModC59.Text = "N° prossimo Modello ISTAT C/59:"
      '
      'ckbNumeroSchedinaPS
      '
      Me.ckbNumeroSchedinaPS.AutoSize = True
      Me.ckbNumeroSchedinaPS.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.ckbNumeroSchedinaPS.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ckbNumeroSchedinaPS.Location = New System.Drawing.Point(24, 32)
      Me.ckbNumeroSchedinaPS.Name = "ckbNumeroSchedinaPS"
      Me.ckbNumeroSchedinaPS.Size = New System.Drawing.Size(156, 18)
      Me.ckbNumeroSchedinaPS.TabIndex = 0
      Me.ckbNumeroSchedinaPS.Text = "N° prossima Schedina PS:"
      '
      'txtNumeroModC59
      '
      Me.txtNumeroModC59.Enabled = False
      Me.txtNumeroModC59.ForeColor = System.Drawing.Color.Red
      Me.txtNumeroModC59.Location = New System.Drawing.Point(224, 64)
      Me.txtNumeroModC59.Name = "txtNumeroModC59"
      Me.txtNumeroModC59.Size = New System.Drawing.Size(72, 20)
      Me.txtNumeroModC59.TabIndex = 1
      Me.txtNumeroModC59.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtNumeroSchedinaPS
      '
      Me.txtNumeroSchedinaPS.Enabled = False
      Me.txtNumeroSchedinaPS.ForeColor = System.Drawing.Color.Red
      Me.txtNumeroSchedinaPS.Location = New System.Drawing.Point(224, 32)
      Me.txtNumeroSchedinaPS.Name = "txtNumeroSchedinaPS"
      Me.txtNumeroSchedinaPS.Size = New System.Drawing.Size(72, 20)
      Me.txtNumeroSchedinaPS.TabIndex = 0
      Me.txtNumeroSchedinaPS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'GroupBox7
      '
      Me.GroupBox7.Controls.Add(Me.cmbNumStelle)
      Me.GroupBox7.Controls.Add(Me.Label53)
      Me.GroupBox7.Controls.Add(Me.cmbTipoEsercizio)
      Me.GroupBox7.Controls.Add(Me.Label55)
      Me.GroupBox7.Location = New System.Drawing.Point(24, 24)
      Me.GroupBox7.Name = "GroupBox7"
      Me.GroupBox7.Size = New System.Drawing.Size(712, 80)
      Me.GroupBox7.TabIndex = 0
      Me.GroupBox7.TabStop = False
      Me.GroupBox7.Text = "Attività:"
      '
      'cmbNumStelle
      '
      Me.cmbNumStelle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbNumStelle.Items.AddRange(New Object() {"", "1", "2", "3", "4", "5"})
      Me.cmbNumStelle.Location = New System.Drawing.Point(576, 32)
      Me.cmbNumStelle.Name = "cmbNumStelle"
      Me.cmbNumStelle.Size = New System.Drawing.Size(112, 21)
      Me.cmbNumStelle.TabIndex = 1
      '
      'Label53
      '
      Me.Label53.AutoSize = True
      Me.Label53.BackColor = System.Drawing.Color.Transparent
      Me.Label53.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label53.ForeColor = System.Drawing.Color.Black
      Me.Label53.Location = New System.Drawing.Point(492, 34)
      Me.Label53.Name = "Label53"
      Me.Label53.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label53.Size = New System.Drawing.Size(76, 13)
      Me.Label53.TabIndex = 186
      Me.Label53.Text = "Numero Stelle:"
      '
      'cmbTipoEsercizio
      '
      Me.cmbTipoEsercizio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTipoEsercizio.Items.AddRange(New Object() {"", "Affittacamere", "Agriturismo", "Albergo", "Beauty Farm", "Bed & Breakfast", "Campeggio", "Hotel", "Locanda", "Motel", "Residence", "Villaggio Turistico"})
      Me.cmbTipoEsercizio.Location = New System.Drawing.Point(112, 32)
      Me.cmbTipoEsercizio.Name = "cmbTipoEsercizio"
      Me.cmbTipoEsercizio.Size = New System.Drawing.Size(184, 21)
      Me.cmbTipoEsercizio.TabIndex = 0
      '
      'Label55
      '
      Me.Label55.AutoSize = True
      Me.Label55.BackColor = System.Drawing.Color.Transparent
      Me.Label55.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label55.ForeColor = System.Drawing.Color.Black
      Me.Label55.Location = New System.Drawing.Point(24, 32)
      Me.Label55.Name = "Label55"
      Me.Label55.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label55.Size = New System.Drawing.Size(76, 13)
      Me.Label55.TabIndex = 188
      Me.Label55.Text = "Tipo Esercizio:"
      '
      'GroupBox6
      '
      Me.GroupBox6.Controls.Add(Me.txtServizioCamere)
      Me.GroupBox6.Controls.Add(Me.Label39)
      Me.GroupBox6.Controls.Add(Me.cmbIvaCamere)
      Me.GroupBox6.Controls.Add(Me.Label51)
      Me.GroupBox6.Location = New System.Drawing.Point(24, 128)
      Me.GroupBox6.Name = "GroupBox6"
      Me.GroupBox6.Size = New System.Drawing.Size(344, 199)
      Me.GroupBox6.TabIndex = 1
      Me.GroupBox6.TabStop = False
      Me.GroupBox6.Text = "Varie:"
      '
      'txtServizioCamere
      '
      Me.txtServizioCamere.ForeColor = System.Drawing.Color.Red
      Me.txtServizioCamere.Location = New System.Drawing.Point(184, 64)
      Me.txtServizioCamere.Name = "txtServizioCamere"
      Me.txtServizioCamere.Size = New System.Drawing.Size(112, 20)
      Me.txtServizioCamere.TabIndex = 1
      Me.txtServizioCamere.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label39
      '
      Me.Label39.AutoSize = True
      Me.Label39.BackColor = System.Drawing.Color.Transparent
      Me.Label39.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label39.ForeColor = System.Drawing.Color.Black
      Me.Label39.Location = New System.Drawing.Point(24, 32)
      Me.Label39.Name = "Label39"
      Me.Label39.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label39.Size = New System.Drawing.Size(112, 13)
      Me.Label39.TabIndex = 186
      Me.Label39.Text = "Aliquota IVA standard:"
      '
      'cmbIvaCamere
      '
      Me.cmbIvaCamere.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIvaCamere.Items.AddRange(New Object() {"Reparto 1", "Reparto 2", "Reparto 3", "Reparto 4"})
      Me.cmbIvaCamere.Location = New System.Drawing.Point(184, 32)
      Me.cmbIvaCamere.Name = "cmbIvaCamere"
      Me.cmbIvaCamere.Size = New System.Drawing.Size(112, 21)
      Me.cmbIvaCamere.TabIndex = 0
      '
      'Label51
      '
      Me.Label51.AutoSize = True
      Me.Label51.BackColor = System.Drawing.Color.Transparent
      Me.Label51.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label51.ForeColor = System.Drawing.Color.Black
      Me.Label51.Location = New System.Drawing.Point(24, 64)
      Me.Label51.Name = "Label51"
      Me.Label51.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label51.Size = New System.Drawing.Size(88, 13)
      Me.Label51.TabIndex = 189
      Me.Label51.Text = "Costo Servizio %:"
      '
      'tbpCentroSportivo
      '
      Me.tbpCentroSportivo.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tbpCentroSportivo.Controls.Add(Me.GroupBox4)
      Me.tbpCentroSportivo.Location = New System.Drawing.Point(4, 22)
      Me.tbpCentroSportivo.Name = "tbpCentroSportivo"
      Me.tbpCentroSportivo.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpCentroSportivo.Size = New System.Drawing.Size(757, 494)
      Me.tbpCentroSportivo.TabIndex = 7
      Me.tbpCentroSportivo.Text = "Centro sportivo"
      '
      'GroupBox4
      '
      Me.GroupBox4.Controls.Add(Me.cmbIvaCentroSportivo)
      Me.GroupBox4.Controls.Add(Me.Label37)
      Me.GroupBox4.Location = New System.Drawing.Point(24, 24)
      Me.GroupBox4.Name = "GroupBox4"
      Me.GroupBox4.Size = New System.Drawing.Size(713, 144)
      Me.GroupBox4.TabIndex = 191
      Me.GroupBox4.TabStop = False
      Me.GroupBox4.Text = "Varie"
      '
      'cmbIvaCentroSportivo
      '
      Me.cmbIvaCentroSportivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbIvaCentroSportivo.Items.AddRange(New Object() {"Reparto 1", "Reparto 2", "Reparto 3", "Reparto 4"})
      Me.cmbIvaCentroSportivo.Location = New System.Drawing.Point(144, 32)
      Me.cmbIvaCentroSportivo.Name = "cmbIvaCentroSportivo"
      Me.cmbIvaCentroSportivo.Size = New System.Drawing.Size(112, 21)
      Me.cmbIvaCentroSportivo.TabIndex = 189
      '
      'Label37
      '
      Me.Label37.AutoSize = True
      Me.Label37.BackColor = System.Drawing.Color.Transparent
      Me.Label37.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label37.ForeColor = System.Drawing.Color.Black
      Me.Label37.Location = New System.Drawing.Point(24, 32)
      Me.Label37.Name = "Label37"
      Me.Label37.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label37.Size = New System.Drawing.Size(112, 13)
      Me.Label37.TabIndex = 188
      Me.Label37.Text = "Aliquota IVA standard:"
      '
      'tbpStampanti
      '
      Me.tbpStampanti.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tbpStampanti.Controls.Add(Me.GroupBox2)
      Me.tbpStampanti.Controls.Add(Me.GroupBox1)
      Me.tbpStampanti.Location = New System.Drawing.Point(4, 22)
      Me.tbpStampanti.Name = "tbpStampanti"
      Me.tbpStampanti.Size = New System.Drawing.Size(757, 494)
      Me.tbpStampanti.TabIndex = 2
      Me.tbpStampanti.Text = "Percorsi di stampa"
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.cmbReportComanda10)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComanda10)
      Me.GroupBox2.Controls.Add(Me.cmbReparto10)
      Me.GroupBox2.Controls.Add(Me.cmbReportComanda9)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComanda9)
      Me.GroupBox2.Controls.Add(Me.cmbReparto9)
      Me.GroupBox2.Controls.Add(Me.cmbReportComanda8)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComanda8)
      Me.GroupBox2.Controls.Add(Me.cmbReparto8)
      Me.GroupBox2.Controls.Add(Me.cmbReportComanda7)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComanda7)
      Me.GroupBox2.Controls.Add(Me.cmbReparto7)
      Me.GroupBox2.Controls.Add(Me.cmbReportComanda6)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComanda6)
      Me.GroupBox2.Controls.Add(Me.cmbReparto6)
      Me.GroupBox2.Controls.Add(Me.cmbReportComanda5)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComanda5)
      Me.GroupBox2.Controls.Add(Me.cmbReparto5)
      Me.GroupBox2.Controls.Add(Me.cmbReportComanda4)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComanda4)
      Me.GroupBox2.Controls.Add(Me.cmbReparto4)
      Me.GroupBox2.Controls.Add(Me.cmbReportComanda3)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComanda3)
      Me.GroupBox2.Controls.Add(Me.cmbReparto3)
      Me.GroupBox2.Controls.Add(Me.cmbReportComanda2)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComanda2)
      Me.GroupBox2.Controls.Add(Me.cmbReparto2)
      Me.GroupBox2.Controls.Add(Me.Label10)
      Me.GroupBox2.Controls.Add(Me.Label6)
      Me.GroupBox2.Controls.Add(Me.Label4)
      Me.GroupBox2.Controls.Add(Me.cmbReportComandaAgg)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComandaAgg)
      Me.GroupBox2.Controls.Add(Me.Label5)
      Me.GroupBox2.Controls.Add(Me.cmbReportComanda1)
      Me.GroupBox2.Controls.Add(Me.cmbStampanteComanda1)
      Me.GroupBox2.Controls.Add(Me.cmbReparto1)
      Me.GroupBox2.ForeColor = System.Drawing.Color.Black
      Me.GroupBox2.Location = New System.Drawing.Point(16, 8)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(723, 344)
      Me.GroupBox2.TabIndex = 0
      Me.GroupBox2.TabStop = False
      Me.GroupBox2.Text = "Percorsi di stampa per le Comande:"
      '
      'cmbReportComanda10
      '
      Me.cmbReportComanda10.Location = New System.Drawing.Point(392, 256)
      Me.cmbReportComanda10.Name = "cmbReportComanda10"
      Me.cmbReportComanda10.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComanda10.TabIndex = 29
      '
      'cmbStampanteComanda10
      '
      Me.cmbStampanteComanda10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComanda10.Location = New System.Drawing.Point(168, 256)
      Me.cmbStampanteComanda10.Name = "cmbStampanteComanda10"
      Me.cmbStampanteComanda10.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComanda10.TabIndex = 28
      '
      'cmbReparto10
      '
      Me.cmbReparto10.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReparto10.Location = New System.Drawing.Point(16, 256)
      Me.cmbReparto10.Name = "cmbReparto10"
      Me.cmbReparto10.Size = New System.Drawing.Size(144, 21)
      Me.cmbReparto10.TabIndex = 27
      '
      'cmbReportComanda9
      '
      Me.cmbReportComanda9.Location = New System.Drawing.Point(392, 232)
      Me.cmbReportComanda9.Name = "cmbReportComanda9"
      Me.cmbReportComanda9.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComanda9.TabIndex = 26
      '
      'cmbStampanteComanda9
      '
      Me.cmbStampanteComanda9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComanda9.Location = New System.Drawing.Point(168, 232)
      Me.cmbStampanteComanda9.Name = "cmbStampanteComanda9"
      Me.cmbStampanteComanda9.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComanda9.TabIndex = 25
      '
      'cmbReparto9
      '
      Me.cmbReparto9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReparto9.Location = New System.Drawing.Point(16, 232)
      Me.cmbReparto9.Name = "cmbReparto9"
      Me.cmbReparto9.Size = New System.Drawing.Size(144, 21)
      Me.cmbReparto9.TabIndex = 24
      '
      'cmbReportComanda8
      '
      Me.cmbReportComanda8.Location = New System.Drawing.Point(392, 208)
      Me.cmbReportComanda8.Name = "cmbReportComanda8"
      Me.cmbReportComanda8.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComanda8.TabIndex = 23
      '
      'cmbStampanteComanda8
      '
      Me.cmbStampanteComanda8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComanda8.Location = New System.Drawing.Point(168, 208)
      Me.cmbStampanteComanda8.Name = "cmbStampanteComanda8"
      Me.cmbStampanteComanda8.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComanda8.TabIndex = 22
      '
      'cmbReparto8
      '
      Me.cmbReparto8.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReparto8.Location = New System.Drawing.Point(16, 208)
      Me.cmbReparto8.Name = "cmbReparto8"
      Me.cmbReparto8.Size = New System.Drawing.Size(144, 21)
      Me.cmbReparto8.TabIndex = 21
      '
      'cmbReportComanda7
      '
      Me.cmbReportComanda7.Location = New System.Drawing.Point(392, 184)
      Me.cmbReportComanda7.Name = "cmbReportComanda7"
      Me.cmbReportComanda7.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComanda7.TabIndex = 20
      '
      'cmbStampanteComanda7
      '
      Me.cmbStampanteComanda7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComanda7.Location = New System.Drawing.Point(168, 184)
      Me.cmbStampanteComanda7.Name = "cmbStampanteComanda7"
      Me.cmbStampanteComanda7.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComanda7.TabIndex = 19
      '
      'cmbReparto7
      '
      Me.cmbReparto7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReparto7.Location = New System.Drawing.Point(16, 184)
      Me.cmbReparto7.Name = "cmbReparto7"
      Me.cmbReparto7.Size = New System.Drawing.Size(144, 21)
      Me.cmbReparto7.TabIndex = 18
      '
      'cmbReportComanda6
      '
      Me.cmbReportComanda6.Location = New System.Drawing.Point(392, 160)
      Me.cmbReportComanda6.Name = "cmbReportComanda6"
      Me.cmbReportComanda6.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComanda6.TabIndex = 17
      '
      'cmbStampanteComanda6
      '
      Me.cmbStampanteComanda6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComanda6.Location = New System.Drawing.Point(168, 160)
      Me.cmbStampanteComanda6.Name = "cmbStampanteComanda6"
      Me.cmbStampanteComanda6.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComanda6.TabIndex = 16
      '
      'cmbReparto6
      '
      Me.cmbReparto6.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReparto6.Location = New System.Drawing.Point(16, 160)
      Me.cmbReparto6.Name = "cmbReparto6"
      Me.cmbReparto6.Size = New System.Drawing.Size(144, 21)
      Me.cmbReparto6.TabIndex = 15
      '
      'cmbReportComanda5
      '
      Me.cmbReportComanda5.Location = New System.Drawing.Point(392, 136)
      Me.cmbReportComanda5.Name = "cmbReportComanda5"
      Me.cmbReportComanda5.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComanda5.TabIndex = 14
      '
      'cmbStampanteComanda5
      '
      Me.cmbStampanteComanda5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComanda5.Location = New System.Drawing.Point(168, 136)
      Me.cmbStampanteComanda5.Name = "cmbStampanteComanda5"
      Me.cmbStampanteComanda5.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComanda5.TabIndex = 13
      '
      'cmbReparto5
      '
      Me.cmbReparto5.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReparto5.Location = New System.Drawing.Point(16, 136)
      Me.cmbReparto5.Name = "cmbReparto5"
      Me.cmbReparto5.Size = New System.Drawing.Size(144, 21)
      Me.cmbReparto5.TabIndex = 12
      '
      'cmbReportComanda4
      '
      Me.cmbReportComanda4.Location = New System.Drawing.Point(392, 112)
      Me.cmbReportComanda4.Name = "cmbReportComanda4"
      Me.cmbReportComanda4.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComanda4.TabIndex = 11
      '
      'cmbStampanteComanda4
      '
      Me.cmbStampanteComanda4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComanda4.Location = New System.Drawing.Point(168, 112)
      Me.cmbStampanteComanda4.Name = "cmbStampanteComanda4"
      Me.cmbStampanteComanda4.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComanda4.TabIndex = 10
      '
      'cmbReparto4
      '
      Me.cmbReparto4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReparto4.Location = New System.Drawing.Point(16, 112)
      Me.cmbReparto4.Name = "cmbReparto4"
      Me.cmbReparto4.Size = New System.Drawing.Size(144, 21)
      Me.cmbReparto4.TabIndex = 9
      '
      'cmbReportComanda3
      '
      Me.cmbReportComanda3.Location = New System.Drawing.Point(392, 88)
      Me.cmbReportComanda3.Name = "cmbReportComanda3"
      Me.cmbReportComanda3.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComanda3.TabIndex = 8
      '
      'cmbStampanteComanda3
      '
      Me.cmbStampanteComanda3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComanda3.Location = New System.Drawing.Point(168, 88)
      Me.cmbStampanteComanda3.Name = "cmbStampanteComanda3"
      Me.cmbStampanteComanda3.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComanda3.TabIndex = 7
      '
      'cmbReparto3
      '
      Me.cmbReparto3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReparto3.Location = New System.Drawing.Point(16, 88)
      Me.cmbReparto3.Name = "cmbReparto3"
      Me.cmbReparto3.Size = New System.Drawing.Size(144, 21)
      Me.cmbReparto3.TabIndex = 6
      '
      'cmbReportComanda2
      '
      Me.cmbReportComanda2.Location = New System.Drawing.Point(392, 64)
      Me.cmbReportComanda2.Name = "cmbReportComanda2"
      Me.cmbReportComanda2.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComanda2.TabIndex = 5
      '
      'cmbStampanteComanda2
      '
      Me.cmbStampanteComanda2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComanda2.Location = New System.Drawing.Point(168, 64)
      Me.cmbStampanteComanda2.Name = "cmbStampanteComanda2"
      Me.cmbStampanteComanda2.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComanda2.TabIndex = 4
      '
      'cmbReparto2
      '
      Me.cmbReparto2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReparto2.Location = New System.Drawing.Point(16, 64)
      Me.cmbReparto2.Name = "cmbReparto2"
      Me.cmbReparto2.Size = New System.Drawing.Size(144, 21)
      Me.cmbReparto2.TabIndex = 3
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.BackColor = System.Drawing.Color.Transparent
      Me.Label10.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label10.ForeColor = System.Drawing.Color.Black
      Me.Label10.Location = New System.Drawing.Point(392, 22)
      Me.Label10.Name = "Label10"
      Me.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label10.Size = New System.Drawing.Size(42, 13)
      Me.Label10.TabIndex = 210
      Me.Label10.Text = "Report:"
      '
      'Label6
      '
      Me.Label6.AutoSize = True
      Me.Label6.BackColor = System.Drawing.Color.Transparent
      Me.Label6.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label6.ForeColor = System.Drawing.Color.Black
      Me.Label6.Location = New System.Drawing.Point(168, 22)
      Me.Label6.Name = "Label6"
      Me.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label6.Size = New System.Drawing.Size(61, 13)
      Me.Label6.TabIndex = 209
      Me.Label6.Text = "Stampante:"
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(16, 22)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(48, 13)
      Me.Label4.TabIndex = 208
      Me.Label4.Text = "Reparto:"
      '
      'cmbReportComandaAgg
      '
      Me.cmbReportComandaAgg.Location = New System.Drawing.Point(392, 296)
      Me.cmbReportComandaAgg.Name = "cmbReportComandaAgg"
      Me.cmbReportComandaAgg.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComandaAgg.TabIndex = 31
      '
      'cmbStampanteComandaAgg
      '
      Me.cmbStampanteComandaAgg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComandaAgg.Location = New System.Drawing.Point(168, 296)
      Me.cmbStampanteComandaAgg.Name = "cmbStampanteComandaAgg"
      Me.cmbStampanteComandaAgg.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComandaAgg.TabIndex = 30
      '
      'Label5
      '
      Me.Label5.BackColor = System.Drawing.Color.Transparent
      Me.Label5.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label5.ForeColor = System.Drawing.Color.Black
      Me.Label5.Location = New System.Drawing.Point(16, 296)
      Me.Label5.Name = "Label5"
      Me.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label5.Size = New System.Drawing.Size(144, 32)
      Me.Label5.TabIndex = 197
      Me.Label5.Text = "Stampa anche una copia delle comande su:"
      '
      'cmbReportComanda1
      '
      Me.cmbReportComanda1.Location = New System.Drawing.Point(392, 40)
      Me.cmbReportComanda1.Name = "cmbReportComanda1"
      Me.cmbReportComanda1.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportComanda1.TabIndex = 2
      '
      'cmbStampanteComanda1
      '
      Me.cmbStampanteComanda1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteComanda1.Location = New System.Drawing.Point(168, 40)
      Me.cmbStampanteComanda1.Name = "cmbStampanteComanda1"
      Me.cmbStampanteComanda1.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteComanda1.TabIndex = 1
      '
      'cmbReparto1
      '
      Me.cmbReparto1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbReparto1.Location = New System.Drawing.Point(16, 40)
      Me.cmbReparto1.Name = "cmbReparto1"
      Me.cmbReparto1.Size = New System.Drawing.Size(144, 21)
      Me.cmbReparto1.TabIndex = 0
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.cmbReportScontrini)
      Me.GroupBox1.Controls.Add(Me.cmbStampanteScontrini)
      Me.GroupBox1.Controls.Add(Me.Label16)
      Me.GroupBox1.Controls.Add(Me.Label8)
      Me.GroupBox1.Controls.Add(Me.Label7)
      Me.GroupBox1.Controls.Add(Me.cmbReportProforma)
      Me.GroupBox1.Controls.Add(Me.cmbStampanteProforma)
      Me.GroupBox1.Controls.Add(Me.cmbReportFatture)
      Me.GroupBox1.Controls.Add(Me.cmbStampanteFatture)
      Me.GroupBox1.Controls.Add(Me.cmbReportRicevute)
      Me.GroupBox1.Controls.Add(Me.cmbStampanteRicevute)
      Me.GroupBox1.Controls.Add(Me.Label9)
      Me.GroupBox1.ForeColor = System.Drawing.Color.Black
      Me.GroupBox1.Location = New System.Drawing.Point(16, 360)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(723, 128)
      Me.GroupBox1.TabIndex = 1
      Me.GroupBox1.TabStop = False
      Me.GroupBox1.Text = "Percorsi di stampa per i Documenti:"
      '
      'cmbReportScontrini
      '
      Me.cmbReportScontrini.ItemHeight = 13
      Me.cmbReportScontrini.Items.AddRange(New Object() {"Scontrino.rpt"})
      Me.cmbReportScontrini.Location = New System.Drawing.Point(392, 96)
      Me.cmbReportScontrini.Name = "cmbReportScontrini"
      Me.cmbReportScontrini.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportScontrini.TabIndex = 209
      '
      'cmbStampanteScontrini
      '
      Me.cmbStampanteScontrini.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteScontrini.ItemHeight = 13
      Me.cmbStampanteScontrini.Location = New System.Drawing.Point(168, 96)
      Me.cmbStampanteScontrini.Name = "cmbStampanteScontrini"
      Me.cmbStampanteScontrini.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteScontrini.TabIndex = 208
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.BackColor = System.Drawing.Color.Transparent
      Me.Label16.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label16.ForeColor = System.Drawing.Color.Black
      Me.Label16.Location = New System.Drawing.Point(16, 96)
      Me.Label16.Name = "Label16"
      Me.Label16.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label16.Size = New System.Drawing.Size(51, 13)
      Me.Label16.TabIndex = 210
      Me.Label16.Text = "Scontrini:"
      '
      'Label8
      '
      Me.Label8.AutoSize = True
      Me.Label8.BackColor = System.Drawing.Color.Transparent
      Me.Label8.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label8.ForeColor = System.Drawing.Color.Black
      Me.Label8.Location = New System.Drawing.Point(16, 48)
      Me.Label8.Name = "Label8"
      Me.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label8.Size = New System.Drawing.Size(43, 13)
      Me.Label8.TabIndex = 207
      Me.Label8.Text = "Fatture:"
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.BackColor = System.Drawing.Color.Transparent
      Me.Label7.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label7.ForeColor = System.Drawing.Color.Black
      Me.Label7.Location = New System.Drawing.Point(16, 24)
      Me.Label7.Name = "Label7"
      Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label7.Size = New System.Drawing.Size(82, 13)
      Me.Label7.TabIndex = 206
      Me.Label7.Text = "Ricevute fiscali:"
      '
      'cmbReportProforma
      '
      Me.cmbReportProforma.ItemHeight = 13
      Me.cmbReportProforma.Location = New System.Drawing.Point(392, 72)
      Me.cmbReportProforma.Name = "cmbReportProforma"
      Me.cmbReportProforma.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportProforma.TabIndex = 5
      '
      'cmbStampanteProforma
      '
      Me.cmbStampanteProforma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteProforma.ItemHeight = 13
      Me.cmbStampanteProforma.Location = New System.Drawing.Point(168, 72)
      Me.cmbStampanteProforma.Name = "cmbStampanteProforma"
      Me.cmbStampanteProforma.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteProforma.TabIndex = 4
      '
      'cmbReportFatture
      '
      Me.cmbReportFatture.ItemHeight = 13
      Me.cmbReportFatture.Location = New System.Drawing.Point(392, 48)
      Me.cmbReportFatture.Name = "cmbReportFatture"
      Me.cmbReportFatture.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportFatture.TabIndex = 3
      '
      'cmbStampanteFatture
      '
      Me.cmbStampanteFatture.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteFatture.ItemHeight = 13
      Me.cmbStampanteFatture.Location = New System.Drawing.Point(168, 48)
      Me.cmbStampanteFatture.Name = "cmbStampanteFatture"
      Me.cmbStampanteFatture.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteFatture.TabIndex = 2
      '
      'cmbReportRicevute
      '
      Me.cmbReportRicevute.ItemHeight = 13
      Me.cmbReportRicevute.Location = New System.Drawing.Point(392, 24)
      Me.cmbReportRicevute.Name = "cmbReportRicevute"
      Me.cmbReportRicevute.Size = New System.Drawing.Size(312, 21)
      Me.cmbReportRicevute.TabIndex = 1
      '
      'cmbStampanteRicevute
      '
      Me.cmbStampanteRicevute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteRicevute.ItemHeight = 13
      Me.cmbStampanteRicevute.Location = New System.Drawing.Point(168, 24)
      Me.cmbStampanteRicevute.Name = "cmbStampanteRicevute"
      Me.cmbStampanteRicevute.Size = New System.Drawing.Size(216, 21)
      Me.cmbStampanteRicevute.TabIndex = 0
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.BackColor = System.Drawing.Color.Transparent
      Me.Label9.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label9.ForeColor = System.Drawing.Color.Black
      Me.Label9.Location = New System.Drawing.Point(16, 72)
      Me.Label9.Name = "Label9"
      Me.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label9.Size = New System.Drawing.Size(87, 13)
      Me.Label9.TabIndex = 199
      Me.Label9.Text = "Conti / Proforma:"
      '
      'tbpPalmare
      '
      Me.tbpPalmare.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tbpPalmare.Controls.Add(Me.chkAbilitaPalmareAndroid)
      Me.tbpPalmare.Controls.Add(Me.Label15)
      Me.tbpPalmare.Controls.Add(Me.cmdAggiornaFilePalmare)
      Me.tbpPalmare.Controls.Add(Me.chkAbilitaPalmareWindows)
      Me.tbpPalmare.Controls.Add(Me.cmdApriPercorsoPalmare)
      Me.tbpPalmare.Controls.Add(Me.txtPercorsoRetePalmare)
      Me.tbpPalmare.Controls.Add(Me.Label13)
      Me.tbpPalmare.Controls.Add(Me.cmbFreqAggPalmare)
      Me.tbpPalmare.Controls.Add(Me.Label14)
      Me.tbpPalmare.Location = New System.Drawing.Point(4, 22)
      Me.tbpPalmare.Name = "tbpPalmare"
      Me.tbpPalmare.Size = New System.Drawing.Size(757, 494)
      Me.tbpPalmare.TabIndex = 3
      Me.tbpPalmare.Text = "Dispositivo palmare"
      '
      'chkAbilitaPalmareAndroid
      '
      Me.chkAbilitaPalmareAndroid.AutoSize = True
      Me.chkAbilitaPalmareAndroid.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkAbilitaPalmareAndroid.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkAbilitaPalmareAndroid.Location = New System.Drawing.Point(32, 160)
      Me.chkAbilitaPalmareAndroid.Name = "chkAbilitaPalmareAndroid"
      Me.chkAbilitaPalmareAndroid.Size = New System.Drawing.Size(389, 18)
      Me.chkAbilitaPalmareAndroid.TabIndex = 4
      Me.chkAbilitaPalmareAndroid.Text = "Abilita la gestione con dispositivi Android (Tablet, SmartPhone, Palmari ecc.)"
      '
      'Label15
      '
      Me.Label15.BackColor = System.Drawing.Color.Transparent
      Me.Label15.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label15.ForeColor = System.Drawing.Color.Black
      Me.Label15.Location = New System.Drawing.Point(32, 352)
      Me.Label15.Name = "Label15"
      Me.Label15.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label15.Size = New System.Drawing.Size(576, 40)
      Me.Label15.TabIndex = 197
      Me.Label15.Text = resources.GetString("Label15.Text")
      '
      'cmdAggiornaFilePalmare
      '
      Me.cmdAggiornaFilePalmare.Enabled = False
      Me.cmdAggiornaFilePalmare.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdAggiornaFilePalmare.Location = New System.Drawing.Point(344, 408)
      Me.cmdAggiornaFilePalmare.Name = "cmdAggiornaFilePalmare"
      Me.cmdAggiornaFilePalmare.Size = New System.Drawing.Size(256, 40)
      Me.cmdAggiornaFilePalmare.TabIndex = 5
      Me.cmdAggiornaFilePalmare.Text = "Aggiorna &File dati per il dispositivo palmare."
      '
      'chkAbilitaPalmareWindows
      '
      Me.chkAbilitaPalmareWindows.AutoSize = True
      Me.chkAbilitaPalmareWindows.CheckAlign = System.Drawing.ContentAlignment.TopLeft
      Me.chkAbilitaPalmareWindows.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkAbilitaPalmareWindows.Location = New System.Drawing.Point(32, 128)
      Me.chkAbilitaPalmareWindows.Name = "chkAbilitaPalmareWindows"
      Me.chkAbilitaPalmareWindows.Size = New System.Drawing.Size(391, 18)
      Me.chkAbilitaPalmareWindows.TabIndex = 3
      Me.chkAbilitaPalmareWindows.Text = "Abilita la gestione con dispositivi Windows Mobile (Pocket PC, Palmari, ecc.)"
      '
      'cmdApriPercorsoPalmare
      '
      Me.cmdApriPercorsoPalmare.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdApriPercorsoPalmare.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdApriPercorsoPalmare.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriPercorsoPalmare.Location = New System.Drawing.Point(576, 48)
      Me.cmdApriPercorsoPalmare.Name = "cmdApriPercorsoPalmare"
      Me.cmdApriPercorsoPalmare.Size = New System.Drawing.Size(24, 20)
      Me.cmdApriPercorsoPalmare.TabIndex = 1
      Me.cmdApriPercorsoPalmare.Tag = ""
      Me.cmdApriPercorsoPalmare.Text = "..."
      '
      'txtPercorsoRetePalmare
      '
      Me.txtPercorsoRetePalmare.Location = New System.Drawing.Point(32, 48)
      Me.txtPercorsoRetePalmare.Name = "txtPercorsoRetePalmare"
      Me.txtPercorsoRetePalmare.Size = New System.Drawing.Size(544, 20)
      Me.txtPercorsoRetePalmare.TabIndex = 0
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.BackColor = System.Drawing.Color.Transparent
      Me.Label13.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label13.ForeColor = System.Drawing.Color.Black
      Me.Label13.Location = New System.Drawing.Point(32, 32)
      Me.Label13.Name = "Label13"
      Me.Label13.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label13.Size = New System.Drawing.Size(173, 13)
      Me.Label13.TabIndex = 195
      Me.Label13.Text = "Percorso di rete / Cartella di lavoro:"
      '
      'cmbFreqAggPalmare
      '
      Me.cmbFreqAggPalmare.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbFreqAggPalmare.Items.AddRange(New Object() {"5", "10", "15", "20", "25", "30", "35", "40", "45", "50", "55", "60"})
      Me.cmbFreqAggPalmare.Location = New System.Drawing.Point(256, 88)
      Me.cmbFreqAggPalmare.Name = "cmbFreqAggPalmare"
      Me.cmbFreqAggPalmare.Size = New System.Drawing.Size(80, 21)
      Me.cmbFreqAggPalmare.TabIndex = 2
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(32, 88)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(195, 13)
      Me.Label14.TabIndex = 194
      Me.Label14.Text = "Frequenza di aggiornamento in secondi:"
      '
      'tbpFiscali
      '
      Me.tbpFiscali.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tbpFiscali.Controls.Add(Me.grbWpos)
      Me.tbpFiscali.Controls.Add(Me.cmbStampanteModello)
      Me.tbpFiscali.Controls.Add(Me.Label19)
      Me.tbpFiscali.Controls.Add(Me.cmbStampanteProduttore)
      Me.tbpFiscali.Controls.Add(Me.Label18)
      Me.tbpFiscali.Controls.Add(Me.grbSwing)
      Me.tbpFiscali.Location = New System.Drawing.Point(4, 22)
      Me.tbpFiscali.Name = "tbpFiscali"
      Me.tbpFiscali.Size = New System.Drawing.Size(757, 494)
      Me.tbpFiscali.TabIndex = 4
      Me.tbpFiscali.Text = "Registratori di cassa"
      '
      'grbWpos
      '
      Me.grbWpos.Controls.Add(Me.cmdPercorsoDriverWPOS1)
      Me.grbWpos.Controls.Add(Me.txtPercorsoDriverWPOS1)
      Me.grbWpos.Controls.Add(Me.Label33)
      Me.grbWpos.Controls.Add(Me.cmdAvviaWpos1)
      Me.grbWpos.Controls.Add(Me.Label12)
      Me.grbWpos.Controls.Add(Me.txtEstensioneFileWpos1)
      Me.grbWpos.Controls.Add(Me.Label26)
      Me.grbWpos.Controls.Add(Me.txtPasswordWpos1)
      Me.grbWpos.Controls.Add(Me.Label28)
      Me.grbWpos.Controls.Add(Me.cmdPercorsoWpos1)
      Me.grbWpos.Controls.Add(Me.txtPercorsoWpos1)
      Me.grbWpos.Controls.Add(Me.Label29)
      Me.grbWpos.Location = New System.Drawing.Point(16, 112)
      Me.grbWpos.Name = "grbWpos"
      Me.grbWpos.Size = New System.Drawing.Size(724, 368)
      Me.grbWpos.TabIndex = 215
      Me.grbWpos.TabStop = False
      Me.grbWpos.Text = "Impostazioni driver WPOS1"
      '
      'cmdPercorsoDriverWPOS1
      '
      Me.cmdPercorsoDriverWPOS1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdPercorsoDriverWPOS1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPercorsoDriverWPOS1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdPercorsoDriverWPOS1.Location = New System.Drawing.Point(504, 112)
      Me.cmdPercorsoDriverWPOS1.Name = "cmdPercorsoDriverWPOS1"
      Me.cmdPercorsoDriverWPOS1.Size = New System.Drawing.Size(24, 20)
      Me.cmdPercorsoDriverWPOS1.TabIndex = 226
      Me.cmdPercorsoDriverWPOS1.Tag = ""
      Me.cmdPercorsoDriverWPOS1.Text = "..."
      '
      'txtPercorsoDriverWPOS1
      '
      Me.txtPercorsoDriverWPOS1.Location = New System.Drawing.Point(24, 112)
      Me.txtPercorsoDriverWPOS1.Name = "txtPercorsoDriverWPOS1"
      Me.txtPercorsoDriverWPOS1.Size = New System.Drawing.Size(480, 20)
      Me.txtPercorsoDriverWPOS1.TabIndex = 225
      '
      'Label33
      '
      Me.Label33.AutoSize = True
      Me.Label33.BackColor = System.Drawing.Color.Transparent
      Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label33.ForeColor = System.Drawing.Color.Black
      Me.Label33.Location = New System.Drawing.Point(24, 96)
      Me.Label33.Name = "Label33"
      Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label33.Size = New System.Drawing.Size(123, 13)
      Me.Label33.TabIndex = 227
      Me.Label33.Text = "Percorso driver WPOS1:"
      '
      'cmdAvviaWpos1
      '
      Me.cmdAvviaWpos1.Location = New System.Drawing.Point(384, 144)
      Me.cmdAvviaWpos1.Name = "cmdAvviaWpos1"
      Me.cmdAvviaWpos1.Size = New System.Drawing.Size(144, 32)
      Me.cmdAvviaWpos1.TabIndex = 3
      Me.cmdAvviaWpos1.Text = "&Avvia WPOS1"
      Me.cmdAvviaWpos1.UseVisualStyleBackColor = True
      '
      'Label12
      '
      Me.Label12.Location = New System.Drawing.Point(24, 32)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(512, 48)
      Me.Label12.TabIndex = 224
      Me.Label12.Text = resources.GetString("Label12.Text")
      '
      'txtEstensioneFileWpos1
      '
      Me.txtEstensioneFileWpos1.Location = New System.Drawing.Point(384, 272)
      Me.txtEstensioneFileWpos1.MaxLength = 3
      Me.txtEstensioneFileWpos1.Name = "txtEstensioneFileWpos1"
      Me.txtEstensioneFileWpos1.Size = New System.Drawing.Size(56, 20)
      Me.txtEstensioneFileWpos1.TabIndex = 2
      Me.txtEstensioneFileWpos1.Text = "001"
      '
      'Label26
      '
      Me.Label26.BackColor = System.Drawing.Color.Transparent
      Me.Label26.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label26.ForeColor = System.Drawing.Color.Black
      Me.Label26.Location = New System.Drawing.Point(24, 272)
      Me.Label26.Name = "Label26"
      Me.Label26.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label26.Size = New System.Drawing.Size(336, 32)
      Me.Label26.TabIndex = 223
      Me.Label26.Text = "Estensione dei file generati da WPOS1 (001 se la cassa è collegata su COM1, 002 s" &
    "e su COM2 ecc.):"
      '
      'txtPasswordWpos1
      '
      Me.txtPasswordWpos1.Location = New System.Drawing.Point(384, 240)
      Me.txtPasswordWpos1.Name = "txtPasswordWpos1"
      Me.txtPasswordWpos1.Size = New System.Drawing.Size(144, 20)
      Me.txtPasswordWpos1.TabIndex = 1
      '
      'Label28
      '
      Me.Label28.AutoSize = True
      Me.Label28.BackColor = System.Drawing.Color.Transparent
      Me.Label28.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label28.ForeColor = System.Drawing.Color.Black
      Me.Label28.Location = New System.Drawing.Point(24, 240)
      Me.Label28.Name = "Label28"
      Me.Label28.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label28.Size = New System.Drawing.Size(316, 13)
      Me.Label28.TabIndex = 221
      Me.Label28.Text = "Password WPOS1 (indispensabile per il funzionamento del driver):"
      '
      'cmdPercorsoWpos1
      '
      Me.cmdPercorsoWpos1.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdPercorsoWpos1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPercorsoWpos1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdPercorsoWpos1.Location = New System.Drawing.Point(504, 208)
      Me.cmdPercorsoWpos1.Name = "cmdPercorsoWpos1"
      Me.cmdPercorsoWpos1.Size = New System.Drawing.Size(24, 20)
      Me.cmdPercorsoWpos1.TabIndex = 217
      Me.cmdPercorsoWpos1.Tag = ""
      Me.cmdPercorsoWpos1.Text = "..."
      '
      'txtPercorsoWpos1
      '
      Me.txtPercorsoWpos1.Location = New System.Drawing.Point(24, 208)
      Me.txtPercorsoWpos1.Name = "txtPercorsoWpos1"
      Me.txtPercorsoWpos1.Size = New System.Drawing.Size(480, 20)
      Me.txtPercorsoWpos1.TabIndex = 0
      '
      'Label29
      '
      Me.Label29.AutoSize = True
      Me.Label29.BackColor = System.Drawing.Color.Transparent
      Me.Label29.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label29.ForeColor = System.Drawing.Color.Black
      Me.Label29.Location = New System.Drawing.Point(24, 192)
      Me.Label29.Name = "Label29"
      Me.Label29.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label29.Size = New System.Drawing.Size(173, 13)
      Me.Label29.TabIndex = 220
      Me.Label29.Text = "Percorso caltella di lavoro WPOS1:"
      '
      'cmbStampanteModello
      '
      Me.cmbStampanteModello.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteModello.Items.AddRange(New Object() {"SWING ECR 65/A"})
      Me.cmbStampanteModello.Location = New System.Drawing.Point(96, 64)
      Me.cmbStampanteModello.Name = "cmbStampanteModello"
      Me.cmbStampanteModello.Size = New System.Drawing.Size(248, 21)
      Me.cmbStampanteModello.TabIndex = 1
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.BackColor = System.Drawing.Color.Transparent
      Me.Label19.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label19.ForeColor = System.Drawing.Color.Black
      Me.Label19.Location = New System.Drawing.Point(24, 64)
      Me.Label19.Name = "Label19"
      Me.Label19.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label19.Size = New System.Drawing.Size(47, 13)
      Me.Label19.TabIndex = 202
      Me.Label19.Text = "Modello:"
      '
      'cmbStampanteProduttore
      '
      Me.cmbStampanteProduttore.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampanteProduttore.Items.AddRange(New Object() {"RCH"})
      Me.cmbStampanteProduttore.Location = New System.Drawing.Point(96, 32)
      Me.cmbStampanteProduttore.Name = "cmbStampanteProduttore"
      Me.cmbStampanteProduttore.Size = New System.Drawing.Size(248, 21)
      Me.cmbStampanteProduttore.TabIndex = 0
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.BackColor = System.Drawing.Color.Transparent
      Me.Label18.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label18.ForeColor = System.Drawing.Color.Black
      Me.Label18.Location = New System.Drawing.Point(24, 32)
      Me.Label18.Name = "Label18"
      Me.Label18.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label18.Size = New System.Drawing.Size(40, 13)
      Me.Label18.TabIndex = 199
      Me.Label18.Text = "Marca:"
      '
      'grbSwing
      '
      Me.grbSwing.Controls.Add(Me.Label32)
      Me.grbSwing.Controls.Add(Me.cmbStampantePorta)
      Me.grbSwing.Controls.Add(Me.Label23)
      Me.grbSwing.Controls.Add(Me.txtNomeScontrino)
      Me.grbSwing.Controls.Add(Me.Label22)
      Me.grbSwing.Controls.Add(Me.cmdPercorsoDriver)
      Me.grbSwing.Controls.Add(Me.txtPercorsoDriver)
      Me.grbSwing.Controls.Add(Me.Label21)
      Me.grbSwing.Controls.Add(Me.txtStampanteParametri)
      Me.grbSwing.Controls.Add(Me.Label20)
      Me.grbSwing.Controls.Add(Me.cmdPercorsoOutput)
      Me.grbSwing.Controls.Add(Me.txtPercorsoOutput)
      Me.grbSwing.Controls.Add(Me.Label17)
      Me.grbSwing.Location = New System.Drawing.Point(16, 112)
      Me.grbSwing.Name = "grbSwing"
      Me.grbSwing.Size = New System.Drawing.Size(552, 368)
      Me.grbSwing.TabIndex = 213
      Me.grbSwing.TabStop = False
      Me.grbSwing.Text = "Parametri di configurazione"
      Me.grbSwing.Visible = False
      '
      'Label32
      '
      Me.Label32.Location = New System.Drawing.Point(24, 40)
      Me.Label32.Name = "Label32"
      Me.Label32.Size = New System.Drawing.Size(480, 24)
      Me.Label32.TabIndex = 225
      Me.Label32.Text = "E' necessario installare il driver commerciale SwingDriver, prodotto dalla RCH."
      '
      'cmbStampantePorta
      '
      Me.cmbStampantePorta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbStampantePorta.Items.AddRange(New Object() {"COM 1", "COM 2", "COM 3", "COM 4", "COM 5", "COM 6", "COM 7", "COM 8", "COM 9", "COM 10"})
      Me.cmbStampantePorta.Location = New System.Drawing.Point(168, 80)
      Me.cmbStampantePorta.Name = "cmbStampantePorta"
      Me.cmbStampantePorta.Size = New System.Drawing.Size(160, 21)
      Me.cmbStampantePorta.TabIndex = 0
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.BackColor = System.Drawing.Color.Transparent
      Me.Label23.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label23.ForeColor = System.Drawing.Color.Black
      Me.Label23.Location = New System.Drawing.Point(24, 80)
      Me.Label23.Name = "Label23"
      Me.Label23.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label23.Size = New System.Drawing.Size(106, 13)
      Me.Label23.TabIndex = 224
      Me.Label23.Text = "Porta di trasmissione:"
      '
      'txtNomeScontrino
      '
      Me.txtNomeScontrino.Location = New System.Drawing.Point(168, 144)
      Me.txtNomeScontrino.Name = "txtNomeScontrino"
      Me.txtNomeScontrino.Size = New System.Drawing.Size(160, 20)
      Me.txtNomeScontrino.TabIndex = 2
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.BackColor = System.Drawing.Color.Transparent
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(24, 144)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(102, 13)
      Me.Label22.TabIndex = 223
      Me.Label22.Text = "Nome file Scontrino:"
      '
      'cmdPercorsoDriver
      '
      Me.cmdPercorsoDriver.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdPercorsoDriver.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPercorsoDriver.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdPercorsoDriver.Location = New System.Drawing.Point(504, 264)
      Me.cmdPercorsoDriver.Name = "cmdPercorsoDriver"
      Me.cmdPercorsoDriver.Size = New System.Drawing.Size(24, 20)
      Me.cmdPercorsoDriver.TabIndex = 219
      Me.cmdPercorsoDriver.Tag = ""
      Me.cmdPercorsoDriver.Text = "..."
      '
      'txtPercorsoDriver
      '
      Me.txtPercorsoDriver.Location = New System.Drawing.Point(24, 264)
      Me.txtPercorsoDriver.Name = "txtPercorsoDriver"
      Me.txtPercorsoDriver.Size = New System.Drawing.Size(480, 20)
      Me.txtPercorsoDriver.TabIndex = 4
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.BackColor = System.Drawing.Color.Transparent
      Me.Label21.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label21.ForeColor = System.Drawing.Color.Black
      Me.Label21.Location = New System.Drawing.Point(24, 248)
      Me.Label21.Name = "Label21"
      Me.Label21.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label21.Size = New System.Drawing.Size(99, 13)
      Me.Label21.TabIndex = 222
      Me.Label21.Text = "Percorso file Driver:"
      '
      'txtStampanteParametri
      '
      Me.txtStampanteParametri.Location = New System.Drawing.Point(168, 112)
      Me.txtStampanteParametri.Name = "txtStampanteParametri"
      Me.txtStampanteParametri.Size = New System.Drawing.Size(160, 20)
      Me.txtStampanteParametri.TabIndex = 1
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.BackColor = System.Drawing.Color.Transparent
      Me.Label20.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label20.ForeColor = System.Drawing.Color.Black
      Me.Label20.Location = New System.Drawing.Point(24, 112)
      Me.Label20.Name = "Label20"
      Me.Label20.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label20.Size = New System.Drawing.Size(125, 13)
      Me.Label20.TabIndex = 221
      Me.Label20.Text = "Parametri di trasmissione:"
      '
      'cmdPercorsoOutput
      '
      Me.cmdPercorsoOutput.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdPercorsoOutput.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdPercorsoOutput.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdPercorsoOutput.Location = New System.Drawing.Point(504, 216)
      Me.cmdPercorsoOutput.Name = "cmdPercorsoOutput"
      Me.cmdPercorsoOutput.Size = New System.Drawing.Size(24, 20)
      Me.cmdPercorsoOutput.TabIndex = 217
      Me.cmdPercorsoOutput.Tag = ""
      Me.cmdPercorsoOutput.Text = "..."
      '
      'txtPercorsoOutput
      '
      Me.txtPercorsoOutput.Location = New System.Drawing.Point(24, 216)
      Me.txtPercorsoOutput.Name = "txtPercorsoOutput"
      Me.txtPercorsoOutput.Size = New System.Drawing.Size(480, 20)
      Me.txtPercorsoOutput.TabIndex = 3
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(24, 200)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(134, 13)
      Me.Label17.TabIndex = 220
      Me.Label17.Text = "Percorso caltella di Output:"
      '
      'tbpRecovery
      '
      Me.tbpRecovery.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tbpRecovery.Controls.Add(Me.lblDataSalvataggio)
      Me.tbpRecovery.Controls.Add(Me.txtPercorsoRecovery)
      Me.tbpRecovery.Controls.Add(Me.Label24)
      Me.tbpRecovery.Controls.Add(Me.chkAttivaRecovery)
      Me.tbpRecovery.Controls.Add(Me.cmdApriPercorsoRecovery)
      Me.tbpRecovery.Controls.Add(Me.lblPercorsoRecovery)
      Me.tbpRecovery.Location = New System.Drawing.Point(4, 22)
      Me.tbpRecovery.Name = "tbpRecovery"
      Me.tbpRecovery.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpRecovery.Size = New System.Drawing.Size(757, 494)
      Me.tbpRecovery.TabIndex = 5
      Me.tbpRecovery.Text = "Pen Drive Recovery"
      '
      'lblDataSalvataggio
      '
      Me.lblDataSalvataggio.AutoSize = True
      Me.lblDataSalvataggio.BackColor = System.Drawing.Color.Transparent
      Me.lblDataSalvataggio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.lblDataSalvataggio.ForeColor = System.Drawing.Color.Black
      Me.lblDataSalvataggio.Location = New System.Drawing.Point(32, 280)
      Me.lblDataSalvataggio.Name = "lblDataSalvataggio"
      Me.lblDataSalvataggio.Size = New System.Drawing.Size(14, 13)
      Me.lblDataSalvataggio.TabIndex = 213
      Me.lblDataSalvataggio.Text = "#"
      '
      'txtPercorsoRecovery
      '
      Me.txtPercorsoRecovery.Enabled = False
      Me.txtPercorsoRecovery.Location = New System.Drawing.Point(32, 232)
      Me.txtPercorsoRecovery.Name = "txtPercorsoRecovery"
      Me.txtPercorsoRecovery.Size = New System.Drawing.Size(552, 20)
      Me.txtPercorsoRecovery.TabIndex = 1
      '
      'Label24
      '
      Me.Label24.BackColor = System.Drawing.Color.Transparent
      Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label24.ForeColor = System.Drawing.Color.Black
      Me.Label24.Location = New System.Drawing.Point(24, 24)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(592, 120)
      Me.Label24.TabIndex = 212
      Me.Label24.Text = resources.GetString("Label24.Text")
      '
      'chkAttivaRecovery
      '
      Me.chkAttivaRecovery.AutoSize = True
      Me.chkAttivaRecovery.BackColor = System.Drawing.Color.Transparent
      Me.chkAttivaRecovery.ForeColor = System.Drawing.Color.Black
      Me.chkAttivaRecovery.Location = New System.Drawing.Point(32, 176)
      Me.chkAttivaRecovery.Name = "chkAttivaRecovery"
      Me.chkAttivaRecovery.Size = New System.Drawing.Size(159, 17)
      Me.chkAttivaRecovery.TabIndex = 0
      Me.chkAttivaRecovery.Text = "Salva dati su Usb Pen Drive"
      Me.chkAttivaRecovery.UseVisualStyleBackColor = False
      '
      'cmdApriPercorsoRecovery
      '
      Me.cmdApriPercorsoRecovery.Enabled = False
      Me.cmdApriPercorsoRecovery.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.cmdApriPercorsoRecovery.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.cmdApriPercorsoRecovery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriPercorsoRecovery.Location = New System.Drawing.Point(584, 232)
      Me.cmdApriPercorsoRecovery.Name = "cmdApriPercorsoRecovery"
      Me.cmdApriPercorsoRecovery.Size = New System.Drawing.Size(24, 20)
      Me.cmdApriPercorsoRecovery.TabIndex = 2
      Me.cmdApriPercorsoRecovery.Tag = ""
      Me.cmdApriPercorsoRecovery.Text = "..."
      '
      'lblPercorsoRecovery
      '
      Me.lblPercorsoRecovery.AutoSize = True
      Me.lblPercorsoRecovery.BackColor = System.Drawing.Color.Transparent
      Me.lblPercorsoRecovery.Cursor = System.Windows.Forms.Cursors.Default
      Me.lblPercorsoRecovery.Enabled = False
      Me.lblPercorsoRecovery.ForeColor = System.Drawing.Color.Black
      Me.lblPercorsoRecovery.Location = New System.Drawing.Point(32, 216)
      Me.lblPercorsoRecovery.Name = "lblPercorsoRecovery"
      Me.lblPercorsoRecovery.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.lblPercorsoRecovery.Size = New System.Drawing.Size(124, 13)
      Me.lblPercorsoRecovery.TabIndex = 210
      Me.lblPercorsoRecovery.Text = "Percorso Usb Pen Drive:"
      '
      'tbpFidelity
      '
      Me.tbpFidelity.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.tbpFidelity.Controls.Add(Me.cmdDeselTutteCategorie)
      Me.tbpFidelity.Controls.Add(Me.cmdSelTutteCategorie)
      Me.tbpFidelity.Controls.Add(Me.ckdScontrinoPunti)
      Me.tbpFidelity.Controls.Add(Me.ckdProformaPunti)
      Me.tbpFidelity.Controls.Add(Me.ckdFatturaPunti)
      Me.tbpFidelity.Controls.Add(Me.ckdRicevutaPunti)
      Me.tbpFidelity.Controls.Add(Me.Label49)
      Me.tbpFidelity.Controls.Add(Me.ckdlCategoriePunti)
      Me.tbpFidelity.Controls.Add(Me.ckdMsgPunti)
      Me.tbpFidelity.Controls.Add(Me.Label48)
      Me.tbpFidelity.Controls.Add(Me.txtValPunti)
      Me.tbpFidelity.Controls.Add(Me.Label47)
      Me.tbpFidelity.Controls.Add(Me.txtNomePunti)
      Me.tbpFidelity.Controls.Add(Me.Label45)
      Me.tbpFidelity.Controls.Add(Me.ckdAbilitaRaccoltaPunti)
      Me.tbpFidelity.Location = New System.Drawing.Point(4, 22)
      Me.tbpFidelity.Name = "tbpFidelity"
      Me.tbpFidelity.Padding = New System.Windows.Forms.Padding(3)
      Me.tbpFidelity.Size = New System.Drawing.Size(757, 494)
      Me.tbpFidelity.TabIndex = 8
      Me.tbpFidelity.Text = "Punti Fedeltà"
      '
      'cmdDeselTutteCategorie
      '
      Me.cmdDeselTutteCategorie.Enabled = False
      Me.cmdDeselTutteCategorie.Location = New System.Drawing.Point(584, 232)
      Me.cmdDeselTutteCategorie.Name = "cmdDeselTutteCategorie"
      Me.cmdDeselTutteCategorie.Size = New System.Drawing.Size(104, 32)
      Me.cmdDeselTutteCategorie.TabIndex = 10
      Me.cmdDeselTutteCategorie.Text = "&Deseleziona tutto"
      Me.cmdDeselTutteCategorie.UseVisualStyleBackColor = True
      '
      'cmdSelTutteCategorie
      '
      Me.cmdSelTutteCategorie.Enabled = False
      Me.cmdSelTutteCategorie.Location = New System.Drawing.Point(584, 192)
      Me.cmdSelTutteCategorie.Name = "cmdSelTutteCategorie"
      Me.cmdSelTutteCategorie.Size = New System.Drawing.Size(104, 32)
      Me.cmdSelTutteCategorie.TabIndex = 9
      Me.cmdSelTutteCategorie.Text = "&Seleziona tutto"
      Me.cmdSelTutteCategorie.UseVisualStyleBackColor = True
      '
      'ckdScontrinoPunti
      '
      Me.ckdScontrinoPunti.AutoSize = True
      Me.ckdScontrinoPunti.BackColor = System.Drawing.Color.Transparent
      Me.ckdScontrinoPunti.Enabled = False
      Me.ckdScontrinoPunti.ForeColor = System.Drawing.Color.Black
      Me.ckdScontrinoPunti.Location = New System.Drawing.Point(616, 128)
      Me.ckdScontrinoPunti.Name = "ckdScontrinoPunti"
      Me.ckdScontrinoPunti.Size = New System.Drawing.Size(71, 17)
      Me.ckdScontrinoPunti.TabIndex = 7
      Me.ckdScontrinoPunti.Text = "Scontrino"
      Me.ckdScontrinoPunti.UseVisualStyleBackColor = False
      '
      'ckdProformaPunti
      '
      Me.ckdProformaPunti.AutoSize = True
      Me.ckdProformaPunti.BackColor = System.Drawing.Color.Transparent
      Me.ckdProformaPunti.Enabled = False
      Me.ckdProformaPunti.ForeColor = System.Drawing.Color.Black
      Me.ckdProformaPunti.Location = New System.Drawing.Point(544, 128)
      Me.ckdProformaPunti.Name = "ckdProformaPunti"
      Me.ckdProformaPunti.Size = New System.Drawing.Size(68, 17)
      Me.ckdProformaPunti.TabIndex = 6
      Me.ckdProformaPunti.Text = "Proforma"
      Me.ckdProformaPunti.UseVisualStyleBackColor = False
      '
      'ckdFatturaPunti
      '
      Me.ckdFatturaPunti.AutoSize = True
      Me.ckdFatturaPunti.BackColor = System.Drawing.Color.Transparent
      Me.ckdFatturaPunti.Enabled = False
      Me.ckdFatturaPunti.ForeColor = System.Drawing.Color.Black
      Me.ckdFatturaPunti.Location = New System.Drawing.Point(480, 128)
      Me.ckdFatturaPunti.Name = "ckdFatturaPunti"
      Me.ckdFatturaPunti.Size = New System.Drawing.Size(59, 17)
      Me.ckdFatturaPunti.TabIndex = 5
      Me.ckdFatturaPunti.Text = "Fattura"
      Me.ckdFatturaPunti.UseVisualStyleBackColor = False
      '
      'ckdRicevutaPunti
      '
      Me.ckdRicevutaPunti.AutoSize = True
      Me.ckdRicevutaPunti.BackColor = System.Drawing.Color.Transparent
      Me.ckdRicevutaPunti.Enabled = False
      Me.ckdRicevutaPunti.ForeColor = System.Drawing.Color.Black
      Me.ckdRicevutaPunti.Location = New System.Drawing.Point(408, 128)
      Me.ckdRicevutaPunti.Name = "ckdRicevutaPunti"
      Me.ckdRicevutaPunti.Size = New System.Drawing.Size(69, 17)
      Me.ckdRicevutaPunti.TabIndex = 4
      Me.ckdRicevutaPunti.Text = "Ricevuta"
      Me.ckdRicevutaPunti.UseVisualStyleBackColor = False
      '
      'Label49
      '
      Me.Label49.AutoSize = True
      Me.Label49.BackColor = System.Drawing.Color.Transparent
      Me.Label49.Enabled = False
      Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label49.ForeColor = System.Drawing.Color.Black
      Me.Label49.Location = New System.Drawing.Point(24, 168)
      Me.Label49.Name = "Label49"
      Me.Label49.Size = New System.Drawing.Size(156, 13)
      Me.Label49.TabIndex = 222
      Me.Label49.Text = "Categorie che producono punti:"
      '
      'ckdlCategoriePunti
      '
      Me.ckdlCategoriePunti.Enabled = False
      Me.ckdlCategoriePunti.FormattingEnabled = True
      Me.ckdlCategoriePunti.Items.AddRange(New Object() {"Antipasti", "Primi", "Secondi", "Carne", "Pesce", "Dolci", "Pizze"})
      Me.ckdlCategoriePunti.Location = New System.Drawing.Point(24, 192)
      Me.ckdlCategoriePunti.MultiColumn = True
      Me.ckdlCategoriePunti.Name = "ckdlCategoriePunti"
      Me.ckdlCategoriePunti.Size = New System.Drawing.Size(552, 274)
      Me.ckdlCategoriePunti.TabIndex = 8
      '
      'ckdMsgPunti
      '
      Me.ckdMsgPunti.AutoSize = True
      Me.ckdMsgPunti.BackColor = System.Drawing.Color.Transparent
      Me.ckdMsgPunti.Enabled = False
      Me.ckdMsgPunti.ForeColor = System.Drawing.Color.Black
      Me.ckdMsgPunti.Location = New System.Drawing.Point(24, 96)
      Me.ckdMsgPunti.Name = "ckdMsgPunti"
      Me.ckdMsgPunti.Size = New System.Drawing.Size(350, 17)
      Me.ckdMsgPunti.TabIndex = 3
      Me.ckdMsgPunti.Text = "Visualizza un messaggio ogni volta che vengono accreditati dei punti"
      Me.ckdMsgPunti.UseVisualStyleBackColor = False
      '
      'Label48
      '
      Me.Label48.AutoSize = True
      Me.Label48.BackColor = System.Drawing.Color.Transparent
      Me.Label48.Enabled = False
      Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label48.ForeColor = System.Drawing.Color.Black
      Me.Label48.Location = New System.Drawing.Point(24, 128)
      Me.Label48.Name = "Label48"
      Me.Label48.Size = New System.Drawing.Size(353, 13)
      Me.Label48.TabIndex = 218
      Me.Label48.Text = "Vengono considerati validi ai fini della raccolta punti i seguenti documenti:"
      '
      'txtValPunti
      '
      Me.txtValPunti.Enabled = False
      Me.txtValPunti.Location = New System.Drawing.Point(624, 24)
      Me.txtValPunti.Name = "txtValPunti"
      Me.txtValPunti.Size = New System.Drawing.Size(64, 20)
      Me.txtValPunti.TabIndex = 1
      Me.txtValPunti.Text = "1"
      Me.txtValPunti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'Label47
      '
      Me.Label47.AutoSize = True
      Me.Label47.BackColor = System.Drawing.Color.Transparent
      Me.Label47.Enabled = False
      Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label47.ForeColor = System.Drawing.Color.Black
      Me.Label47.Location = New System.Drawing.Point(352, 24)
      Me.Label47.Name = "Label47"
      Me.Label47.Size = New System.Drawing.Size(253, 13)
      Me.Label47.TabIndex = 216
      Me.Label47.Text = "Punti da attribuire al cliente per ogni Euro di incasso:"
      '
      'txtNomePunti
      '
      Me.txtNomePunti.Enabled = False
      Me.txtNomePunti.Location = New System.Drawing.Point(488, 64)
      Me.txtNomePunti.Name = "txtNomePunti"
      Me.txtNomePunti.Size = New System.Drawing.Size(200, 20)
      Me.txtNomePunti.TabIndex = 2
      Me.txtNomePunti.Text = "Punti"
      '
      'Label45
      '
      Me.Label45.AutoSize = True
      Me.Label45.BackColor = System.Drawing.Color.Transparent
      Me.Label45.Enabled = False
      Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label45.ForeColor = System.Drawing.Color.Black
      Me.Label45.Location = New System.Drawing.Point(24, 64)
      Me.Label45.Name = "Label45"
      Me.Label45.Size = New System.Drawing.Size(437, 13)
      Me.Label45.TabIndex = 214
      Me.Label45.Text = "Nome da attribuire alla raccolta punti. Verrà indicato in stampa accanto al numer" &
    "o deil punti:"
      '
      'ckdAbilitaRaccoltaPunti
      '
      Me.ckdAbilitaRaccoltaPunti.AutoSize = True
      Me.ckdAbilitaRaccoltaPunti.BackColor = System.Drawing.Color.Transparent
      Me.ckdAbilitaRaccoltaPunti.Enabled = False
      Me.ckdAbilitaRaccoltaPunti.ForeColor = System.Drawing.Color.Black
      Me.ckdAbilitaRaccoltaPunti.Location = New System.Drawing.Point(24, 24)
      Me.ckdAbilitaRaccoltaPunti.Name = "ckdAbilitaRaccoltaPunti"
      Me.ckdAbilitaRaccoltaPunti.Size = New System.Drawing.Size(121, 17)
      Me.ckdAbilitaRaccoltaPunti.TabIndex = 0
      Me.ckdAbilitaRaccoltaPunti.Text = "Abilita raccolta punti"
      Me.ckdAbilitaRaccoltaPunti.UseVisualStyleBackColor = False
      '
      'ImageList1
      '
      Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
      Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
      Me.ImageList1.Images.SetKeyName(0, "")
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'frmOpzioni
      '
      Me.AcceptButton = Me.cmdOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(778, 564)
      Me.Controls.Add(Me.cmdOK)
      Me.Controls.Add(Me.cmdAnnulla)
      Me.Controls.Add(Me.tabOpzioni)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "frmOpzioni"
      Me.ShowInTaskbar = False
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Opzioni di configurazione"
      Me.tabOpzioni.ResumeLayout(False)
      Me.tbpGenerali.ResumeLayout(False)
      Me.tbpGenerali.PerformLayout()
      Me.GroupBox5.ResumeLayout(False)
      Me.GroupBox5.PerformLayout()
      CType(Me.nudNumCopieStampa, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbAliquote.ResumeLayout(False)
      Me.grbAliquote.PerformLayout()
      Me.tbpBarRist.ResumeLayout(False)
      Me.gbPrenOnLine.ResumeLayout(False)
      Me.gbPrenOnLine.PerformLayout()
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      Me.tbpCamere.ResumeLayout(False)
      Me.GroupBox9.ResumeLayout(False)
      Me.GroupBox9.PerformLayout()
      Me.GroupBox8.ResumeLayout(False)
      Me.GroupBox8.PerformLayout()
      Me.GroupBox7.ResumeLayout(False)
      Me.GroupBox7.PerformLayout()
      Me.GroupBox6.ResumeLayout(False)
      Me.GroupBox6.PerformLayout()
      Me.tbpCentroSportivo.ResumeLayout(False)
      Me.GroupBox4.ResumeLayout(False)
      Me.GroupBox4.PerformLayout()
      Me.tbpStampanti.ResumeLayout(False)
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.tbpPalmare.ResumeLayout(False)
      Me.tbpPalmare.PerformLayout()
      Me.tbpFiscali.ResumeLayout(False)
      Me.tbpFiscali.PerformLayout()
      Me.grbWpos.ResumeLayout(False)
      Me.grbWpos.PerformLayout()
      Me.grbSwing.ResumeLayout(False)
      Me.grbSwing.PerformLayout()
      Me.tbpRecovery.ResumeLayout(False)
      Me.tbpRecovery.PerformLayout()
      Me.tbpFidelity.ResumeLayout(False)
      Me.tbpFidelity.PerformLayout()
      Me.ResumeLayout(False)

   End Sub

#End Region

   Const TIPO_DOC_RF As String = "Ricevuta Fiscale"
   Const TIPO_DOC_FF As String = "Fattura"
   Const TAB_DOC As String = "Documenti"
   Const TAB_SCHEDINE As String = "SchedinePS"

   Const NUMERO_DOC As Integer = 25

   Const DIM_PAGINA As String = "50"

   Private DatiConfig As AppConfig
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress

#Region "Registratori di cassa e stampanti fiscali "

   ' Registratori di cassa.
   Const numMarcheECR As Integer = 41
   Private marcheECR(numMarcheECR) As String

   ' 3i.
   Const ECR_3i As String = "3i"
   Const ECR_3i_Chigago As String = "Chicago"
   Const ECR_3i_Dallas As String = "Dallas"
   Const ECR_3i_FTP_Fast As String = "FTP - Fast"
   Const ECR_3i_FTP_Easy As String = "FTP - Easy"
   Const ECR_3i_Manhattan As String = "Manhattan"
   Const ECR_3i_Miami As String = "Miami"
   Const ECR_3i_Texas As String = "Texas"
   Const numModelliECR_3i As Integer = 7
   Private modelliECR_3i(numModelliECR_3i) As String

   ' Asem.
   Const ECR_Asem As String = "Asem"
   Const ECR_Asem_SF58 As String = "SF 58"
   Const ECR_Asem_SF60 As String = "SF 60"
   Const ECR_Asem_SF80 As String = "SF 80"
   Const numModelliECR_Asem As Integer = 3
   Private modelliECR_Asem(numModelliECR_Asem) As String

   ' Axon.
   Const ECR_Axon As String = "AXON"
   Const ECR_Axon_ONE As String = "AXON ONE"
   Const ECR_Axon_SKY_TP07F As String = "SKY mod. TP07F (RS-232)"
   Const numModelliECR_Axon As Integer = 2
   Private modelliECR_Axon(numModelliECR_Axon) As String

   ' Buffetti.
   Const ECR_Buffetti As String = "Buffetti"
   Const ECR_Buffetti_Compact7 As String = "Compact 7"
   Const ECR_Buffetti_ECRC9 As String = "ECR-C9"
   Const ECR_Buffetti_ECRP9 As String = "ECR-P9"
   Const ECR_Buffetti_NETTUNA200 As String = "NETTUNA 200"
   Const numModelliECR_Buffetti As Integer = 4
   Private modelliECR_Buffetti(numModelliECR_Buffetti) As String

   ' Cei.
   Const ECR_Cei As String = "Cei"
   Const ECR_Cei_RC300 As String = "RC 300"
   Const ECR_Cei_SPR500 As String = "SPR 500"
   Const numModelliECR_Cei As Integer = 2
   Private modelliECR_Cei(numModelliECR_Cei) As String

   ' Coris.
   Const ECR_Coris As String = "Coris"
   Const ECR_Coris_Fly_ETH As String = "Coris Fly@ - RETE ETH"
   Const ECR_Coris_Fly As String = "Fly"
   Const ECR_Coris_Zero5 As String = "Zero 5"
   Const ECR_Coris_Zero7 As String = "Zero 7"
   Const numModelliECR_Coris As Integer = 4
   Private modelliECR_Coris(numModelliECR_Coris) As String

   ' Custom.
   Const ECR_Custom As String = "Custom"
   Const ECR_Custom_Big As String = "Big"
   Const ECR_Custom_BigII As String = "Big II"
   Const ECR_Custom_BigII_Touch As String = "Big II Touch"
   Const ECR_Custom_BigU33 As String = "Big U33"
   Const ECR_Custom_Kube As String = "Kube"
   Const ECR_Custom_KubeEcr As String = "Kube Ecr"
   Const ECR_Custom_KubeETH As String = "Kube Ethernet"
   Const ECR_Custom_KubeEvo As String = "Kube Evo"
   Const ECR_Custom_KubeF As String = "Kube F"
   Const ECR_Custom_KubeIIF As String = "Kube II F"
   Const ECR_Custom_Max As String = "Max"
   Const ECR_Custom_MaxA As String = "Max A"
   Const ECR_Custom_MaxI As String = "Max I"
   Const ECR_Custom_MaxPlay As String = "Max Play"
   Const ECR_Custom_Play As String = "Play"
   Const ECR_Custom_Q3F As String = "Q3 F Stampante Pos"
   Const ECR_Custom_Q3F_ETH As String = "Q3 F Stampante Pos Rete ETH"
   Const ECR_Custom_Thea As String = "Thea"
   Const ECR_Custom_TheaA As String = "Thea A"
   Const ECR_Custom_XKube As String = "XKube"
   Const ECR_Custom_XKubeETH As String = "XKube Ethernet"
   Const numModelliECR_Custom As Integer = 21
   Private modelliECR_Custom(numModelliECR_Custom) As String

   ' DataProcess.
   Const ECR_DataProcess As String = "DataProcess"
   Const ECR_DataProcess_100S As String = "100 S"
   Const ECR_DataProcess_200S As String = "200 S"
   Const ECR_DataProcess_270GE As String = "270 GE"
   Const ECR_DataProcess_270M As String = "270 M"
   Const ECR_DataProcess_40Silver As String = "40 Silver"
   Const ECR_DataProcess_Delphys As String = "Delphys"
   Const ECR_DataProcess_Diesis As String = "Diesis"
   Const ECR_DataProcess_Diesis8 As String = "Diesis 8"
   Const ECR_DataProcess_Magic As String = "Magic"
   Const ECR_DataProcess_Saturno As String = "Saturno"
   Const numModelliECR_DataProcess As Integer = 10
   Private modelliECR_DataProcess(numModelliECR_DataProcess) As String

   ' Distribution System.
   Const ECR_DistributionSystem As String = "Distribution System"
   Const ECR_DistributionSystem_DS204 As String = "DS 204"
   Const ECR_DistributionSystem_DS280 As String = "DS 280"
   Const ECR_DistributionSystem_DSDot As String = "DS Dot"
   Const ECR_DistributionSystem_Progress As String = "Progress"
   Const ECR_DistributionSystem_ProgressEJ As String = "Progress EJ"
   Const ECR_DistributionSystem_ProgressGE As String = "Progress GE"
   Const ECR_DistributionSystem_ProgressT As String = "Progress T"
   Const ECR_DistributionSystem_RS40 As String = "RS 40"
   Const ECR_DistributionSystem_RS50 As String = "RS 50"
   Const numModelliECR_DistributionSystem As Integer = 9
   Private modelliECR_DistributionSystem(numModelliECR_DistributionSystem) As String

   ' Ditron.
   Const ECR_Ditron As String = "Ditron"
   Const ECR_Ditron_CasioMarketEJ As String = "Casio Market new EJ"
   Const ECR_Ditron_ETH As String = "Ditron - RETE ETH"
   Const ECR_Ditron_FP600 As String = "FP 600 Ditron"
   Const ECR_Ditron_Medea As String = "Medea"
   Const ECR_Ditron_Mi200 As String = "Mi 200"
   Const ECR_Ditron_Mi3000 As String = "Mi 3000"
   Const ECR_Ditron_Mi320EJ As String = "Mi 320 EJ"
   Const ECR_Ditron_Nesso As String = "Nesso"
   Const ECR_Ditron_Simple As String = "Simple"
   Const ECR_Ditron_Sun As String = "Sun"
   Const ECR_Ditron_UniversoEJ As String = "Universo EJ"
   Const ECR_Ditron_Velvet As String = "Velvet"
   Const ECR_Ditron_Zip As String = "Zip"
   Const numModelliECR_Ditron As Integer = 13
   Private modelliECR_Ditron(numModelliECR_Ditron) As String

   ' DTR-Italia.
   Const ECR_DTR_Italia As String = "DTR-Italia"
   Const ECR_DTR_Italia_DCash As String = "DCash"
   Const ECR_DTR_Italia_DPalm As String = "DPalm"
   Const ECR_DTR_Italia_DPrint As String = "DPrint"
   Const numModelliECR_DTR_Italia As Integer = 3
   Private modelliECR_DTR_Italia(numModelliECR_DTR_Italia) As String

   ' Elsi Retail.
   Const ECR_Elsi_Retail As String = "Elsi Retail"
   Const ECR_Elsi_Retail_R1000 As String = "R1000"
   Const ECR_Elsi_Retail_R158EJ As String = "R158 EJ"
   Const ECR_Elsi_Retail_R338EJ As String = "R338 EJ"
   Const ECR_Elsi_Retail_R503 As String = "R503"
   Const ECR_Elsi_Retail_R504 As String = "R504"
   Const ECR_Elsi_Retail_R58EJ As String = "R58 EJ"
   Const ECR_Elsi_Retail_R680EJ As String = "R680 EJ"
   Const ECR_Elsi_Retail_R680EJ_ETH As String = "R680 EJ RETE ETH"
   Const ECR_Elsi_Retail_R800 As String = "R800"
   Const ECR_Elsi_Retail_R800EJ As String = "R800 EJ"
   Const numModelliECR_Elsi_Retail As Integer = 10
   Private modelliECR_Elsi_Retail(numModelliECR_Elsi_Retail) As String

   ' Epm Ed.It.
   Const ECR_EpmEdIt As String = "Epm Ed.It"
   Const ECR_EpmEdIt_ONE As String = "ONE"
   Const ECR_EpmEdIt_ONE_XonXoff As String = "ONE (XonXoff)"
   Const ECR_EpmEdIt_ONELE As String = "ONE-LE"
   Const ECR_EpmEdIt_ONELE_XonXoff As String = "ONE-LE (XonXoff)"
   Const ECR_EpmEdIt_ONESX As String = "ONE-SX"
   Const ECR_EpmEdIt_ONESX_XonXoff As String = "ONE-SX (XonXoff)"
   Const ECR_EpmEdIt_SEVENT As String = "SEVEN-T"
   Const ECR_EpmEdIt_Smarty As String = "Smarty"
   Const ECR_EpmEdIt_SFEP80 As String = "ST. FISC. SF-EP80"
   Const ECR_EpmEdIt_SFEP80_XonXoff As String = "ST. FISC. SF-EP80 (XonXoff)"
   Const numModelliECR_EpmEdIt As Integer = 10
   Private modelliECR_EpmEdIt(numModelliECR_EpmEdIt) As String

   ' Epson.
   Const ECR_Epson As String = "Epson"
   Const ECR_Epson_FP81 As String = "FP 81"
   Const ECR_Epson_FP90 As String = "FP 90"
   Const ECR_Epson_FP90II As String = "FP 90 II"
   Const ECR_Epson_FP90III As String = "FP 90 III"
   Const numModelliECR_Epson As Integer = 4
   Private modelliECR_Epson(numModelliECR_Epson) As String

   ' Eurodata.
   Const ECR_Eurodata As String = "Eurodata"
   Const ECR_Eurodata_Pagaso As String = "Pegaso"
   Const numModelliECR_Eurodata As Integer = 1
   Private modelliECR_Eurodata(numModelliECR_Eurodata) As String

   ' Fasy.
   Const ECR_Fasy As String = "Fasy"
   Const ECR_Fasy_Butterfly As String = "Butterfly"
   Const ECR_Fasy_Grecale As String = "Grecale"
   Const ECR_Fasy_Libeccio As String = "Libeccio"
   Const ECR_Fasy_MistralPlus As String = "Mistral Plus"
   Const ECR_Fasy_MistralTop As String = "Mistral Top"
   Const ECR_Fasy_Scirocco As String = "Scirocco"
   Const ECR_Fasy_SciroccoSmart As String = "Scirocco Smart"
   Const ECR_Fasy_Windkey As String = "Windkey"
   Const ECR_Fasy_Windy As String = "Windy"
   Const ECR_Fasy_Zephyr As String = "Zephyr"
   Const ECR_Fasy_Zephyr80PlusEJ As String = "Zephyr 80 Plus EJ"
   Const ECR_Fasy_ZephyrLite As String = "Zephyr Lite"
   Const ECR_Fasy_ZephyrPlus As String = "Zephyr Plus"
   Const numModelliECR_Fasy As Integer = 13
   Private modelliECR_Fasy(numModelliECR_Fasy) As String

   ' Helmac.
   Const ECR_Helmac As String = "Helmac"
   Const ECR_Helmac_Linx As String = "Linx"
   Const ECR_Helmac_Puma As String = "Puma"
   Const ECR_Helmac_PumaT As String = "Puma-T"
   Const ECR_Helmac_Tiger As String = "Tiger"
   Const ECR_Helmac_TigerPro As String = "Tiger Pro"
   Const numModelliECR_Helmac As Integer = 5
   Private modelliECR_Helmac(numModelliECR_Helmac) As String

   ' Hugin.
   Const ECR_Hugin As String = "Hugin"
   Const ECR_Hugin_K120GE As String = "K120 GE"
   Const ECR_Hugin_One As String = "One"
   Const ECR_Hugin_Tornado As String = "Tornado"
   Const ECR_Hugin_Twister As String = "Twister"
   Const numModelliECR_Hugin As Integer = 4
   Private modelliECR_Hugin(numModelliECR_Hugin) As String

   ' I2 Idee Italiane.
   Const ECR_I2_Idee_Italiane As String = "I2 Idee Italiane"
   Const ECR_I2_Idee_Italiane_Forma As String = "Forma"
   Const ECR_I2_Idee_Italiane_Segno As String = "Segno"
   Const ECR_I2_Idee_Italiane_SegnoTouch As String = "Segno Touch"
   Const numModelliECR_I2_Idee_Italiane As Integer = 3
   Private modelliECR_I2_Idee_Italiane(numModelliECR_I2_Idee_Italiane) As String

   ' Ibm.
   Const ECR_Ibm As String = "Ibm"
   Const ECR_Ibm_Entry01 As String = "Entry 01"
   Const ECR_Ibm_Entry01A As String = "Entry 01/A"
   Const ECR_Ibm_Entry2000 As String = "Entry 2000"
   Const ECR_Ibm_PD25 As String = "PD 25"
   Const ECR_Ibm_PD215 As String = "PD215"
   Const numModelliECR_Ibm As Integer = 5
   Private modelliECR_Ibm(numModelliECR_Ibm) As String

   ' Indesit/Ditron.
   Const ECR_Indesit_Ditron As String = "Indesit/Ditron"
   Const ECR_Indesit_Ditron_ As String = "Serena"
   Const numModelliECR_Indesit_Ditron As Integer = 1
   Private modelliECR_Indesit_Ditron(numModelliECR_Indesit_Ditron) As String

   ' Italiana Macchi.
   Const ECR_Italiana_Macchi As String = "Italiana Macchi"
   Const ECR_Italiana_Macchi_A1500 As String = "A1500"
   Const ECR_Italiana_Macchi_A1500BT As String = "A1500BT"
   Const ECR_Italiana_Macchi_S850 As String = "S 850"
   Const ECR_Italiana_Macchi_S850Touch As String = "S 850 Touch"
   Const ECR_Italiana_Macchi_Speed As String = "Speed"
   Const numModelliECR_Italiana_Macchi As Integer = 5
   Private modelliECR_Italiana_Macchi(numModelliECR_Italiana_Macchi) As String

   ' Mct.
   Const ECR_Mct As String = "Mct"
   Const ECR_Mct_Flea As String = "Flea"
   Const ECR_Mct_Flea_AT As String = "Flea @"
   Const ECR_Mct_FleaA As String = "Flea A"
   Const ECR_Mct_FlyXT As String = "Fly xt"
   Const ECR_Mct_OverPC_ETH As String = "Over PC - RETE ETH"
   Const ECR_Mct_Over As String = "Over"
   Const ECR_Mct_OverTouch As String = "Over Touch"
   Const ECR_Mct_Print_F As String = "Print!F (RS-232 / USB)"
   Const ECR_Mct_Print_F_ETH As String = "Print!F RETE ETH"
   Const ECR_Mct_Spot As String = "Spot"
   Const numModelliECR_Mct As Integer = 10
   Private modelliECR_Mct(numModelliECR_Mct) As String

   ' Micrelec.
   Const ECR_Micrelec As String = "Micrelec"
   Const ECR_Micrelec_ByBLOS As String = "ByBLOS"
   Const ECR_Micrelec_Edipos As String = "Edipos"
   Const ECR_Micrelec_Krono As String = "Krono"
   Const ECR_Micrelec_Mi100 As String = "Mi 100"
   Const ECR_Micrelec_Mi110 As String = "Mi 110"
   Const ECR_Micrelec_Mi310 As String = "Mi 310"
   Const ECR_Micrelec_Mi710 As String = "Mi 710"
   Const ECR_Micrelec_Paros As String = "Paros"
   Const numModelliECR_Micrelec As Integer = 8
   Private modelliECR_Micrelec(numModelliECR_Micrelec) As String

   ' Microrex.
   Const ECR_Microrex As String = "Microrex"
   Const ECR_Microrex_TH35 As String = "TH 35"
   Const ECR_Microrex_TH36LUX As String = "TH 36 LUX"
   Const ECR_Microrex_TH39 As String = "TH 39"
   Const numModelliECR_Microrex As Integer = 3
   Private modelliECR_Microrex(numModelliECR_Microrex) As String

   ' Ncr.
   Const ECR_Ncr As String = "Ncr"
   Const ECR_Ncr_2140 As String = "2140"
   Const ECR_Ncr_2215 As String = "2215"
   Const ECR_Ncr_2215EJ As String = "2215 EJ"
   Const ECR_Ncr_RealCash As String = "Real Cash"
   Const ECR_Ncr_RealCashEJ As String = "Real Cash EJ"
   Const ECR_Ncr_RealprintEJ As String = "Realprint EJ"
   Const numModelliECR_Ncr As Integer = 6
   Private modelliECR_Ncr(numModelliECR_Ncr) As String

   ' OkCash.
   Const ECR_OkCash As String = "OkCash"
   Const ECR_OkCash_Elegant As String = "Elegant"
   Const ECR_OkCash_OKCash As String = "OK Cash"
   Const numModelliECR_OkCash As Integer = 2
   Private modelliECR_OkCash(numModelliECR_OkCash) As String

   ' Olivetti.
   Const ECR_Olivetti As String = "Olivetti"
   Const ECR_Olivetti_CRFEJ As String = "CRF EJ"
   Const ECR_Olivetti_CRFPJ As String = "CRF PJ"
   Const ECR_Olivetti_Logic As String = "Logic"
   Const ECR_Olivetti_Nettuna As String = "Nettuna"
   Const ECR_Olivetti_Nettuna200 As String = "Nettuna 200 (CRF 4040)"
   Const ECR_Olivetti_Nettuna250 As String = "Nettuna 250 (CRF 4055)"
   Const ECR_Olivetti_Nettuna300 As String = "Nettuna 300 (CRF 4045)"
   Const ECR_Olivetti_Nettuna400 As String = "Nettuna 400 (CRF 4095)"
   Const ECR_Olivetti_Nettuna500 As String = "Nettuna 500 (CRF 4095 EJ)"
   Const ECR_Olivetti_Nettuna600 As String = "Nettuna 600 (CRF 5090)"
   Const ECR_Olivetti_Nettuna700 As String = "Nettuna 700 (CRF 5095)"
   Const ECR_Olivetti_NettunaJet As String = "Nettuna Jet"
   Const ECR_Olivetti_NettunaPRT200FX As String = "Nettuna PRT 200 FX"
   Const ECR_Olivetti_Open As String = "Open"
   Const ECR_Olivetti_PRT100 As String = "PRT 100"
   Const ECR_Olivetti_PRT100F As String = "PRT 100 F"
   Const ECR_Olivetti_PRT100FX As String = "PRT 100 FX"
   Const ECR_Olivetti_PRT105 As String = "PRT 105"
   Const ECR_Olivetti_PRT110FX As String = "PRT 110 FX"
   Const ECR_Olivetti_PRT200F As String = "PRT 200 F"
   Const ECR_Olivetti_PRT200FX As String = "PRT 200 FX"
   Const ECR_Olivetti_PRT300FX_RETE As String = "PRT 300 FX (RETE)"
   Const ECR_Olivetti_PRT300FX_RS232 As String = "PRT 300 FX (RS-232)"
   Const numModelliECR_Olivetti As Integer = 23
   Private modelliECR_Olivetti(numModelliECR_Olivetti) As String

   ' RCH.
   Const ECR_RCH As String = "RCH"
   Const ECR_RCH_G1200 As String = "G1200"
   Const ECR_RCH_G1201 As String = "G1201"
   Const ECR_RCH_G2000 As String = "G2000"
   Const ECR_RCH_G3000 As String = "G3000"
   Const ECR_RCH_G3000F As String = "G3000 F"
   Const ECR_RCH_G3000S As String = "G3000 S"
   Const ECR_RCH_Globe As String = "Globe"
   Const ECR_RCH_GlobeECR As String = "Globe ECR"
   Const ECR_RCH_GlobePC As String = "Globe PC"
   Const ECR_RCH_GlobePC_RETE_ETH As String = "Globe PC - RETE ETH"
   Const ECR_RCH_Mizar As String = "Mizar"
   Const ECR_RCH_Nucleo As String = "Nucleo"
   Const ECR_RCH_NucleoGE As String = "Nucleo GE"
   Const ECR_RCH_Onda As String = "Onda"
   Const ECR_RCH_OndaSpot As String = "Onda Spot"
   Const ECR_RCH_PrintF_RS232_USB As String = "Print!F (RS-232 / USB)"
   Const ECR_RCH_PrintF_RETE_ETH As String = "Print!F - RETE ETH"
   Const ECR_RCH_Swing As String = "Swing"
   Const ECR_RCH_SwingECR65A As String = "Swing ECR 65/A"
   Const ECR_RCH_Till As String = "Till"
   Const ECR_RCH_TouchMe As String = "Touch Me"
   Const ECR_RCH_XOnda As String = "X-Onda"
   Const numModelliECR_RCH As Integer = 22
   Private modelliECR_RCH(numModelliECR_RCH) As String

   ' Ricoh.
   Const ECR_Ricoh As String = "Ricoh"
   Const ECR_Ricoh_Logic As String = "Logic"
   Const numModelliECR_Ricoh As Integer = 1
   Private modelliECR_Ricoh(numModelliECR_Ricoh) As String

   ' Royal.
   Const ECR_Royal As String = "Royal"
   Const ECR_Royal_Dialog As String = "Dialog"
   Const ECR_Royal_Nettuna200 As String = "Nettuna 200 (CRF 4040)"
   Const ECR_Royal_Nettuna500 As String = "Nettuna 500 (CRF 4095 EJ)"
   Const ECR_Royal_PRT100 As String = "PRT 100"
   Const ECR_Royal_PRT100FX As String = "PRT 100 FX"
   Const numModelliECR_Royal As Integer = 5
   Private modelliECR_Royal(numModelliECR_Royal) As String

   ' Sarema.
   Const ECR_Sarema As String = "Sarema"
   Const ECR_Sarema_Extra As String = "Extra"
   Const ECR_Sarema_Frontiera As String = "Frontiera"
   Const ECR_Sarema_FrontieraSx2 As String = "Frontiera Sx2"
   Const ECR_Sarema_FrontieraSx3 As String = "Frontiera Sx3"
   Const ECR_Sarema_Grillo As String = "Grillo"
   Const ECR_Sarema_Grillo38 As String = "Grillo 38"
   Const ECR_Sarema_GrilloEJ As String = "Grillo EJ"
   Const ECR_Sarema_Jump As String = "Jump"
   Const ECR_Sarema_Record As String = "Record"
   Const ECR_Sarema_RecordDS As String = "Record DS"
   Const ECR_Sarema_RecordEJ As String = "Record EJ"
   Const ECR_Sarema_RecordGE As String = "Record GE"
   Const ECR_Sarema_SR100 As String = "SR 100"
   Const ECR_Sarema_SR204 As String = "SR 204"
   Const ECR_Sarema_Style As String = "Style"
   Const ECR_Sarema_StyleEJ As String = "Style EJ"
   Const ECR_Sarema_Xtx As String = "Xtx"
   Const numModelliECR_Sarema As Integer = 17
   Private modelliECR_Sarema(numModelliECR_Sarema) As String

   ' SHS.
   Const ECR_SHS As String = "SHS"
   Const ECR_SHS_SH2000EJ As String = "SH 2000 EJ"
   Const ECR_SHS_SH401EJ As String = "SH 401 EJ"
   Const ECR_SHS_SH401EJLE As String = "SH 401 EJ LE"
   Const ECR_SHS_SH501EJ As String = "SH 501 EJ"
   Const ECR_SHS_SHSmarty As String = "SH Smarty"
   Const numModelliECR_SHS As Integer = 5
   Private modelliECR_SHS(numModelliECR_SHS) As String

   ' Sico.
   Const ECR_Sico As String = "Sico"
   Const ECR_Sico_6000Top As String = "6000 Top"
   Const ECR_Sico_ATHOM As String = "ATHOM"
   Const ECR_Sico_Club As String = "Club"
   Const ECR_Sico_IdeaEJ As String = "Idea EJ"
   Const ECR_Sico_R338EJ As String = "R338 EJ"
   Const ECR_Sico_Universo As String = "Universo"
   Const ECR_Sico_UniversoEJ As String = "Universo EJ"
   Const numModelliECR_Sico As Integer = 7
   Private modelliECR_Sico(numModelliECR_Sico) As String

   ' Suprema.
   Const ECR_Suprema As String = "Suprema"
   Const ECR_Suprema_Mercury As String = "Mercury"
   Const ECR_Suprema_Olimpo As String = "Olimpo"
   Const ECR_Suprema_Pulsar As String = "Pulsar"
   Const ECR_Suprema_PulsarEthernet As String = "Pulsar Ethernet"
   Const ECR_Suprema_Sun As String = "Sun"
   Const numModelliECR_Suprema As Integer = 5
   Private modelliECR_Suprema(numModelliECR_Suprema) As String

   ' Sweda.
   Const ECR_Sweda As String = "Sweda"
   Const ECR_Sweda_Gear As String = "Gear"
   Const ECR_Sweda_Labor As String = "Labor"
   Const ECR_Sweda_LaborDS As String = "Labor DS"
   Const ECR_Sweda_LaborEJ As String = "Labor EJ"
   Const ECR_Sweda_LaborGE As String = "Labor GE"
   Const ECR_Sweda_MasterRS50 As String = "Master RS 50"
   Const ECR_Sweda_Mikropos As String = "Mikropos"
   Const ECR_Sweda_Mikropos2004 As String = "Mikropos 2004"
   Const ECR_Sweda_MikroposDS As String = "Mikropos DS"
   Const ECR_Sweda_MikroposEJ As String = "Mikropos EJ"
   Const ECR_Sweda_MikroposGE As String = "Mikropos GE"
   Const ECR_Sweda_Modus As String = "Modus"
   Const ECR_Sweda_Point As String = "Point"
   Const ECR_Sweda_SW204 As String = "SW 204"
   Const numModelliECR_Sweda As Integer = 14
   Private modelliECR_Sweda(numModelliECR_Sweda) As String

   ' System Retail.
   Const ECR_SystemRetail As String = "System Retail"
   Const ECR_SystemRetail_SYS100 As String = "SYS@100"
   Const ECR_SystemRetail_SYS200X As String = "SYS@200 X"
   Const ECR_SystemRetail_SYSTOUCHCENTO As String = "SYS@TOUCH CENTO"
   Const ECR_SystemRetail_SYSUNO As String = "SYS@UNO"
   Const ECR_SystemRetail_TIKEECR As String = "TIKE ECR"
   Const ECR_SystemRetail_TIKELANF As String = "TIKE LAN F"
   Const ECR_SystemRetail_TIKESF As String = "TIKE SF"
   Const ECR_SystemRetail_XTIKEECR As String = "X TIKE ECR"
   Const ECR_SystemRetail_XTIKESF As String = "X TIKE SF"
   Const numModelliECR_SystemRetail As Integer = 9
   Private modelliECR_SystemRetail(numModelliECR_SystemRetail) As String

   ' Underwood.
   Const ECR_Underwood As String = "Underwood"
   Const ECR_Underwood_Format As String = "Format"
   Const ECR_Underwood_Nettuna200 As String = "Nettuna 200 (CRF 4040)"
   Const ECR_Underwood_Nettuna250 As String = "Nettuna 250 (CRF 4055)"
   Const ECR_Underwood_Nettuna300 As String = "Nettuna 300 (CRF 4045)"
   Const ECR_Underwood_Nettuna500 As String = "Nettuna 500 (CRF 4095 EJ)"
   Const ECR_Underwood_Open As String = "Open"
   Const numModelliECR_Underwood As Integer = 6
   Private modelliECR_Underwood(numModelliECR_Underwood) As String

   ' Vandoni.
   Const ECR_Vandoni As String = "Vandoni"
   Const ECR_Vandoni_SE200 As String = "SE 200"
   Const numModelliECR_Vandoni As Integer = 1
   Private modelliECR_Vandoni(numModelliECR_Vandoni) As String

   ' Vis Elettronica.
   Const ECR_VisElettronica As String = " Vis Elettronica"
   Const ECR_VisElettronica_12BT As String = "12 BT"
   Const ECR_VisElettronica_EJ100 As String = "EJ 100"
   Const ECR_VisElettronica_EJ100BT As String = "EJ 100 BT"
   Const ECR_VisElettronica_EJ300 As String = "EJ 300"
   Const ECR_VisElettronica_Graphics As String = "Graphics"
   Const ECR_VisElettronica_GraphicsEJ As String = "Graphics EJ"
   Const ECR_VisElettronica_GraphicsGE As String = "Graphics GE"
   Const ECR_VisElettronica_Millenium As String = "Millenium"
   Const ECR_VisElettronica_ProgressEJ As String = "Progress EJ"
   Const numModelliECR_VisElettronica As Integer = 9
   Private modelliECR_VisElettronica(numModelliECR_VisElettronica) As String

   ' WincorNixdorf.
   Const ECR_WincorNixdorf As String = "WincorNixdorf"
   Const ECR_WincorNixdorf_ButterflyPlus As String = "Butterfly Plus"
   Const ECR_WincorNixdorf_ER400Smart1 As String = "ER400 Smart/1"
   Const ECR_WincorNixdorf_ER400Smart2 As String = "ER400 Smart/2"
   Const ECR_WincorNixdorf_ER400Smart3 As String = "ER400 Smart/3"
   Const ECR_WincorNixdorf_Executive As String = "Executive"
   Const ECR_WincorNixdorf_ExtremeBasic As String = "Extreme Basic"
   Const ECR_WincorNixdorf_ExtremeBasicPlus As String = "Extreme Basic Plus"
   Const ECR_WincorNixdorf_ExtremeLite As String = "Extreme Lite"
   Const ECR_WincorNixdorf_Link As String = "Link"
   Const ECR_WincorNixdorf_Opportunity As String = "Opportunity"
   Const ECR_WincorNixdorf_OpportunityEJ As String = "Opportunity EJ"
   Const ECR_WincorNixdorf_OpportunityLite As String = "Opportunity Lite"
   Const ECR_WincorNixdorf_Storm As String = "Storm"
   Const numModelliECR_WincorNixdorf As Integer = 13
   Private modelliECR_WincorNixdorf(numModelliECR_WincorNixdorf) As String


#End Region

   'Private nuovoPercorsoStampante As Boolean
   'Private indiceElemento As Integer

#Region "Per caricare i percorsi in una Lista - Non utilizzate "

   Public Sub NascondiCampiComande(ByVal val As Boolean)
      'Try
      '   cmbReparto1.Visible = val
      '   cmbStampanteComanda1.Visible = val
      '   cmbReportComanda1.Visible = val

      '   cmbReparto1.Text = Nothing
      '   cmbStampanteComanda1.Text = Nothing
      '   cmbReportComanda1.Text = String.Empty

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Public Sub CaricaListaPercorsi(ByVal lvw As ListView)
      'Try
      '   Dim val(2) As String

      '   lvw.Items.Clear()

      '   Dim i As Integer
      '   For i = 0 To 9
      '      val = elencoPercorsiStampanti(i).Split(";")

      '      If val(0) <> String.Empty Then
      '         lvw.Items.Add(val(0))
      '         lvw.Items(lvw.Items.Count - 1).SubItems.Add(val(1))
      '         lvw.Items(lvw.Items.Count - 1).SubItems.Add(val(2))
      '         lvw.Items(lvw.Items.Count - 1).StateImageIndex = 0
      '      End If
      '   Next

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub cmdNuovo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'nuovoPercorsoStampante = True
      'NascondiCampiComande(True)

   End Sub

   Private Sub cmdAggiungi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Try
      '   If cmbReparto1.Visible = False Then
      '      Exit Sub
      '   End If

      '   If cmbReparto1.Text = String.Empty Then
      '      MessageBox.Show("Inserire il nome del Reparto!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '      Exit Sub
      '   End If

      '   If cmbStampanteComanda1.Text = String.Empty Then
      '      MessageBox.Show("Inserire il nome della Stampante!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '      Exit Sub
      '   End If

      '   If cmbReportComanda1.Text = String.Empty Then
      '      MessageBox.Show("Inserire il nome del Report!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      '      Exit Sub
      '   End If

      '   If nuovoPercorsoStampante = False Then
      '      elencoPercorsiStampanti(indiceElemento) = String.Empty
      '   End If

      '   'lvwPercorsi.Items.Add(cmbReparto.SelectedItem)
      '   'lvwPercorsi.Items(lvwPercorsi.Items.Count - 1).SubItems.Add(cmbStampanteComanda.SelectedItem)
      '   'lvwPercorsi.Items(lvwPercorsi.Items.Count - 1).SubItems.Add(cmbReportComanda.SelectedItem)
      '   'lvwPercorsi.Items(lvwPercorsi.Items.Count - 1).StateImageIndex = 0

      '   elencoPercorsiStampanti(lvwPercorsi.Items.Count - 1) = cmbReparto1.Text & ";" & cmbStampanteComanda1.Text & ";" & cmbReportComanda1.Text
      '   CaricaListaPercorsi(lvwPercorsi)

      '   NascondiCampiComande(False)

      '   nuovoPercorsoStampante = False

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub cmdModifica_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Try
      '   If lvwPercorsi.Items.Count <> 0 Then
      '      NascondiCampiComande(True)

      '      cmbReparto1.Text = lvwPercorsi.SelectedItems(0).Text()
      '      cmbStampanteComanda1.Text = lvwPercorsi.SelectedItems(0).SubItems(1).Text()
      '      cmbReportComanda1.Text = lvwPercorsi.SelectedItems(0).SubItems(2).Text()
      '      indiceElemento = lvwPercorsi.FocusedItem.Index
      '   End If

      'Catch ex As Exception
      '   If ex.Message = "Argomento specificato non compreso nell'intervallo." & Chr(13) & Chr(10) & "Nome parametro: index" Then
      '      cmbReparto1.Text = ""
      '      cmbStampanteComanda1.Text = ""
      '      cmbReportComanda1.Text = ""
      '      Return
      '   Else
      '      ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '      err.GestisciErrore(ex.StackTrace, ex.Message)
      '   End If
      'End Try
   End Sub

   Private Sub cmdElimina_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'Try
      '   If lvwPercorsi.Items.Count <> 0 Then
      '      elencoPercorsiStampanti(lvwPercorsi.FocusedItem.Index) = String.Empty
      '      lvwPercorsi.Items(lvwPercorsi.FocusedItem.Index).Remove()
      '   End If

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub lvwPercorsi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
      'NascondiCampiComande(False)

   End Sub

#End Region

   Private Sub LeggiDatiConfig()
      Try

#Region "SCHEDA GENERALI "

         If DatiConfig.GetValue("FormatoFattAziende").Length = 0 Then
            cmbFormatoFatt.SelectedIndex = 0
         Else
            cmbFormatoFatt.SelectedIndex = 1
         End If

         If DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) = String.Empty Then
            txtPercorsoDB.Text = DatiConfig.GetValue("PercorsoDB")
            If txtPercorsoDB.Text.Length = 0 Then
               txtPercorsoDB.Text = Application.StartupPath & PERCORSO_DB
            End If

            txtPercorsoDBClienti.Text = DatiConfig.GetValue("PercorsoDBClienti")
            If txtPercorsoDBClienti.Text.Length = 0 Then
               txtPercorsoDBClienti.Text = Application.StartupPath & PERCORSO_DB_CLIENTI
            End If

            txtPercorsoBackup.Text = DatiConfig.GetValue("PercorsoBKP")
            If txtPercorsoBackup.Text.Length = 0 Then
               txtPercorsoBackup.Text = Application.StartupPath & PERCORSO_BKP
            End If

         Else
            txtPercorsoDB.Text = Application.StartupPath & PERCORSO_DB
            txtPercorsoDBClienti.Text = Application.StartupPath & PERCORSO_DB_CLIENTI
            txtPercorsoBackup.Text = Application.StartupPath & PERCORSO_BKP
         End If

         If DatiConfig.GetValue("SalvaBKP") <> "" Then
            chkSalvaBackup.Checked = DatiConfig.GetValue("SalvaBKP")
         Else
            chkSalvaBackup.Checked = True
         End If

         cmbNumElementi.Text = DatiConfig.GetValue("NumElememti")
         If cmbNumElementi.Text = "" Then
            cmbNumElementi.Text = DIM_PAGINA
         End If
         dimPagina = CInt(cmbNumElementi.Text)

         ' Percorso Gestionale Amica.
         If DatiConfig.GetValue("PercorsoAmica") <> String.Empty Then
            txtPercorsoAmica.Text = DatiConfig.GetValue("PercorsoAmica")
         Else
            txtPercorsoAmica.Text = String.Empty
         End If

         ' Fatture / Ricevute fiscali.
         txtNumeroFattura.Text = DatiConfig.GetValue("NumeroFattura")
         If IsNumeric(txtNumeroFattura.Text) = False Then
            Dim num As Integer = LeggiNumeroMax(TAB_DOC, TIPO_DOC_FF)
            If num = 0 Then
               txtNumeroFattura.Text = "1"
            Else
               txtNumeroFattura.Text = (num + 1).ToString
            End If
         End If
         txtNumeroRicevuta.Text = DatiConfig.GetValue("NumeroRicevuta")
         If IsNumeric(txtNumeroRicevuta.Text) = False Then
            Dim num As Integer = LeggiNumeroMax(TAB_DOC, TIPO_DOC_RF)
            If num = 0 Then
               txtNumeroRicevuta.Text = "1"
            Else
               txtNumeroRicevuta.Text = (num + 1).ToString
            End If
         End If

         If IsNumeric(DatiConfig.GetValue("NumCopieStampa")) = True Then
            nudNumCopieStampa.Value = Convert.ToDecimal(DatiConfig.GetValue("NumCopieStampa"))
            NumeroCopieStampa = Convert.ToInt16(DatiConfig.GetValue("NumCopieStampa"))
         Else
            nudNumCopieStampa.Value = 1
            NumeroCopieStampa = 1
         End If

         ' Aliquote per i reparti.
         txtAliquotaIva1.Text = DatiConfig.GetValue("AliquotaIva1")
         If txtAliquotaIva1.Text.Length = 0 Then
            txtAliquotaIva1.Text = ""
         End If
         txtAliquotaIva2.Text = DatiConfig.GetValue("AliquotaIva2")
         If txtAliquotaIva2.Text.Length = 0 Then
            txtAliquotaIva2.Text = ""
         End If
         txtAliquotaIva3.Text = DatiConfig.GetValue("AliquotaIva3")
         If txtAliquotaIva3.Text.Length = 0 Then
            txtAliquotaIva3.Text = ""
         End If
         txtAliquotaIva4.Text = DatiConfig.GetValue("AliquotaIva4")
         If txtAliquotaIva4.Text.Length = 0 Then
            txtAliquotaIva4.Text = ""
         End If

#End Region

#Region "SCHEDA BAR / RISTORANTE "

         ' Aliquota IVA standard.
         cmbIvaRistorante.Text = DatiConfig.GetValue("RepartoAliquotaIvaRistorante")
         If cmbIvaRistorante.Text.Length = 0 Then
            cmbIvaRistorante.SelectedIndex = 1
         End If

         ' Prezzo del Coperto.
         txtCopertoRistorante.Text = DatiConfig.GetValue("CopertoRistorante")
         If txtCopertoRistorante.Text.Length = 0 Then
            txtCopertoRistorante.Text = VALORE_ZERO
         End If

         ' Percentuale per il Servizio.
         txtServizioRistorante.Text = DatiConfig.GetValue("ServizioRistorante")
         If txtServizioRistorante.Text.Length = 0 Then
            txtServizioRistorante.Text = VALORE_ZERO
         End If

         ' Effetti sonori per il Punto cassa.
         If DatiConfig.GetValue("EffettiSonoriPOS") <> String.Empty Then
            ckbEffettiSonoriPos.Checked = DatiConfig.GetValue("EffettiSonoriPOS")
         Else
            ckbEffettiSonoriPos.Checked = True
         End If

         ' IMPOSTAZIONI PER LE PRENOTAZIONI DEI TAVOLI FATTE DA INTERNET. (WWW.TAVOLOSO.IT)

         ' Percorso file Tavoloso Agent.
         If DatiConfig.GetValue("PercorsoFileTavAgent") <> String.Empty Then
            txtPercorsoFileTavAgent.Text = DatiConfig.GetValue("PercorsoFileTavAgent")
         Else
            txtPercorsoFileTavAgent.Text = String.Empty
         End If

         ' Percorso cartella di lavoro Tavoloso Agent.
         If DatiConfig.GetValue("PercorsoCartellaTavAgent") <> String.Empty Then
            txtPercorsoCartellaTavAgent.Text = DatiConfig.GetValue("PercorsoCartellaTavAgent")
            PercorsoCartellaTavAgent = txtPercorsoCartellaTavAgent.Text
         Else
            txtPercorsoCartellaTavAgent.Text = String.Empty
            PercorsoCartellaTavAgent = String.Empty
         End If

         ' Abilita ricezione delle prenotazioni.
         If DatiConfig.GetValue("AbilitaRicezionePren") <> String.Empty Then
            ckbAbilitaRicezioneTavAgent.Checked = DatiConfig.GetValue("AbilitaRicezionePren")
            AbilitaRicezionePren = ckbAbilitaRicezioneTavAgent.Checked
         Else
            ckbAbilitaRicezioneTavAgent.Checked = False
            AbilitaRicezionePren = False
         End If

         ' Effetto sonoro per la notifica delle prenotazioni.
         If DatiConfig.GetValue("EffettoSonoroPren") <> String.Empty Then
            ckbNotificaTavAgent.Checked = DatiConfig.GetValue("EffettoSonoroPren")
            EffettoSonoroPren = ckbNotificaTavAgent.Checked
         Else
            ckbNotificaTavAgent.Checked = True
            EffettoSonoroPren = True
         End If

         ' Colore della prenotazione.
         If DatiConfig.GetValue("ColorePrenTavAgent") <> String.Empty Then
            Dim colore As Integer = Convert.ToInt32(DatiConfig.GetValue("ColorePrenTavAgent"))
            cmdColorePrenTavAgent.BackColor = Color.FromArgb(colore)
            ColorePrenTavAgent = cmdColorePrenTavAgent.BackColor
         Else
            cmdColorePrenTavAgent.BackColor = Color.White
            ColorePrenTavAgent = Color.White
         End If

#End Region

#Region "SCHEDA HOTEL "

         ' Tipo esercizio.
         cmbTipoEsercizio.Text = DatiConfig.GetValue("TipoEsercizioHotel")
         If cmbTipoEsercizio.Text.Length = 0 Then
            cmbTipoEsercizio.SelectedIndex = 0
         End If

         ' Numero stelle.
         cmbNumStelle.Text = DatiConfig.GetValue("NumeroStelleHotel")
         If cmbNumStelle.Text.Length = 0 Then
            cmbNumStelle.SelectedIndex = 1
         End If

         ' Aliquota IVA standard.
         cmbIvaCamere.Text = DatiConfig.GetValue("RepartoAliquotaIvaHotel")
         If cmbIvaCamere.Text.Length = 0 Then
            cmbIvaCamere.SelectedIndex = 1
         End If

         ' Percentuale per il Servizio.
         txtServizioCamere.Text = DatiConfig.GetValue("ServizioHotel")
         If txtServizioCamere.Text.Length = 0 Then
            txtServizioCamere.Text = VALORE_ZERO
         End If

         ' Prezzo Tassa di soggiorno.
         txtTassaSoggiorno.Text = DatiConfig.GetValue("TassaSoggiornoHotel")
         If txtTassaSoggiorno.Text.Length = 0 Then
            txtTassaSoggiorno.Text = VALORE_ZERO
         End If

         ' Descrizione Tassa di soggiorno.
         txtDescrizioneTassaSogg.Text = DatiConfig.GetValue("DescrizioneTassaSoggHotel")
         If txtDescrizioneTassaSogg.Text.Length = 0 Then
            txtDescrizioneTassaSogg.Text = String.Empty
         End If

         ' Applica Tassa di soggiorno Neonati.
         If DatiConfig.GetValue("ApplicaTassaNeonati") <> String.Empty Then
            ckbApplicaTassaNeonati.Checked = DatiConfig.GetValue("ApplicaTassaNeonati")
         Else
            ckbApplicaTassaNeonati.Checked = False
         End If

         ' Applica Tassa di soggiorno Bambini.
         If DatiConfig.GetValue("ApplicaTassaBambini") <> String.Empty Then
            ckbApplicaTassaBambini.Checked = DatiConfig.GetValue("ApplicaTassaBambini")
         Else
            ckbApplicaTassaBambini.Checked = False
         End If

         ' Applica Tassa di soggiorno Ragazzi.
         If DatiConfig.GetValue("ApplicaTassaRagazzi") <> String.Empty Then
            ckbApplicaTassaRagazzi.Checked = DatiConfig.GetValue("ApplicaTassaRagazzi")
         Else
            ckbApplicaTassaRagazzi.Checked = False
         End If

         ' Numerazione progressiva Schedine PS
         txtNumeroSchedinaPS.Text = DatiConfig.GetValue("NumeroSchedina")
         If IsNumeric(txtNumeroSchedinaPS.Text) = False Then
            Dim num As Integer = LeggiNumeroMaxSchedine(TAB_SCHEDINE)
            If num = 0 Then
               txtNumeroSchedinaPS.Text = "1"
            Else
               txtNumeroSchedinaPS.Text = (num + 1).ToString
            End If
         End If

         ' Numerazione progressiva Modello ISTAT C/59
         Dim numMod As Integer
         numMod = DatiConfig.GetValue("NumeroModC59")
         If IsNumeric(numMod) = False Then
            txtNumeroModC59.Text = "1"
         Else
            txtNumeroModC59.Text = numMod.ToString
         End If

#End Region

#Region "SCHEDA CENTRO SPORTIVO "

         ' Aliquota IVA standard.
         cmbIvaCentroSportivo.Text = DatiConfig.GetValue("RepartoAliquotaIvaCentroSportivo")
         If cmbIvaCentroSportivo.Text.Length = 0 Then
            cmbIvaCentroSportivo.SelectedIndex = 0
         End If

#End Region

#Region "SCHEDA PERCORSI DI STAMPA "

         ' Comanda - Percorso 1.
         cmbReparto1.Text = DatiConfig.GetValue("Reparto1")
         If cmbReparto1.Text.Length = 0 Then
            cmbReparto1.Text = "<Nessuno>"
         End If
         cmbStampanteComanda1.Text = DatiConfig.GetValue("PercorsoStampaComanda1")
         If cmbStampanteComanda1.Text.Length = 0 Then
            cmbStampanteComanda1.Text = "<Nessuna>"
         End If
         cmbReportComanda1.Text = DatiConfig.GetValue("ReportComanda1")
         If cmbReportComanda1.Text.Length = 0 Then
            cmbReportComanda1.Text = String.Empty
         End If

         ' Comanda - Percorso 2.
         cmbReparto2.Text = DatiConfig.GetValue("Reparto2")
         If cmbReparto2.Text.Length = 0 Then
            cmbReparto2.Text = "<Nessuno>"
         End If
         cmbStampanteComanda2.Text = DatiConfig.GetValue("PercorsoStampaComanda2")
         If cmbStampanteComanda2.Text.Length = 0 Then
            cmbStampanteComanda2.Text = "<Nessuna>"
         End If
         cmbReportComanda2.Text = DatiConfig.GetValue("ReportComanda2")
         If cmbReportComanda2.Text.Length = 0 Then
            cmbReportComanda2.Text = String.Empty
         End If

         ' Comanda - Percorso 3.
         cmbReparto3.Text = DatiConfig.GetValue("Reparto3")
         If cmbReparto3.Text.Length = 0 Then
            cmbReparto3.Text = "<Nessuno>"
         End If
         cmbStampanteComanda3.Text = DatiConfig.GetValue("PercorsoStampaComanda3")
         If cmbStampanteComanda3.Text.Length = 0 Then
            cmbStampanteComanda3.Text = "<Nessuna>"
         End If
         cmbReportComanda3.Text = DatiConfig.GetValue("ReportComanda3")
         If cmbReportComanda3.Text.Length = 0 Then
            cmbReportComanda3.Text = String.Empty
         End If

         ' Comanda - Percorso 4.
         cmbReparto4.Text = DatiConfig.GetValue("Reparto4")
         If cmbReparto4.Text.Length = 0 Then
            cmbReparto4.Text = "<Nessuno>"
         End If
         cmbStampanteComanda4.Text = DatiConfig.GetValue("PercorsoStampaComanda4")
         If cmbStampanteComanda4.Text.Length = 0 Then
            cmbStampanteComanda4.Text = "<Nessuna>"
         End If
         cmbReportComanda4.Text = DatiConfig.GetValue("ReportComanda4")
         If cmbReportComanda4.Text.Length = 0 Then
            cmbReportComanda4.Text = String.Empty
         End If

         ' Comanda - Percorso 5.
         cmbReparto5.Text = DatiConfig.GetValue("Reparto5")
         If cmbReparto5.Text.Length = 0 Then
            cmbReparto5.Text = "<Nessuno>"
         End If
         cmbStampanteComanda5.Text = DatiConfig.GetValue("PercorsoStampaComanda5")
         If cmbStampanteComanda5.Text.Length = 0 Then
            cmbStampanteComanda5.Text = "<Nessuna>"
         End If
         cmbReportComanda5.Text = DatiConfig.GetValue("ReportComanda5")
         If cmbReportComanda5.Text.Length = 0 Then
            cmbReportComanda5.Text = String.Empty
         End If

         ' Comanda - Percorso 6.
         cmbReparto6.Text = DatiConfig.GetValue("Reparto6")
         If cmbReparto6.Text.Length = 0 Then
            cmbReparto6.Text = "<Nessuno>"
         End If
         cmbStampanteComanda6.Text = DatiConfig.GetValue("PercorsoStampaComanda6")
         If cmbStampanteComanda6.Text.Length = 0 Then
            cmbStampanteComanda6.Text = "<Nessuna>"
         End If
         cmbReportComanda6.Text = DatiConfig.GetValue("ReportComanda6")
         If cmbReportComanda6.Text.Length = 0 Then
            cmbReportComanda6.Text = String.Empty
         End If

         ' Comanda - Percorso 7.
         cmbReparto7.Text = DatiConfig.GetValue("Reparto7")
         If cmbReparto7.Text.Length = 0 Then
            cmbReparto7.Text = "<Nessuno>"
         End If
         cmbStampanteComanda7.Text = DatiConfig.GetValue("PercorsoStampaComanda7")
         If cmbStampanteComanda7.Text.Length = 0 Then
            cmbStampanteComanda7.Text = "<Nessuna>"
         End If
         cmbReportComanda7.Text = DatiConfig.GetValue("ReportComanda7")
         If cmbReportComanda7.Text.Length = 0 Then
            cmbReportComanda7.Text = String.Empty
         End If

         ' Comanda - Percorso 8.
         cmbReparto8.Text = DatiConfig.GetValue("Reparto8")
         If cmbReparto8.Text.Length = 0 Then
            cmbReparto8.Text = "<Nessuno>"
         End If
         cmbStampanteComanda8.Text = DatiConfig.GetValue("PercorsoStampaComanda8")
         If cmbStampanteComanda8.Text.Length = 0 Then
            cmbStampanteComanda8.Text = "<Nessuna>"
         End If
         cmbReportComanda8.Text = DatiConfig.GetValue("ReportComanda8")
         If cmbReportComanda8.Text.Length = 0 Then
            cmbReportComanda8.Text = String.Empty
         End If

         ' Comanda - Percorso 9.
         cmbReparto9.Text = DatiConfig.GetValue("Reparto9")
         If cmbReparto9.Text.Length = 0 Then
            cmbReparto9.Text = "<Nessuno>"
         End If
         cmbStampanteComanda9.Text = DatiConfig.GetValue("PercorsoStampaComanda9")
         If cmbStampanteComanda9.Text.Length = 0 Then
            cmbStampanteComanda9.Text = "<Nessuna>"
         End If
         cmbReportComanda9.Text = DatiConfig.GetValue("ReportComanda9")
         If cmbReportComanda9.Text.Length = 0 Then
            cmbReportComanda9.Text = String.Empty
         End If

         ' Comanda - Percorso 10.
         cmbReparto10.Text = DatiConfig.GetValue("Reparto10")
         If cmbReparto10.Text.Length = 0 Then
            cmbReparto10.Text = "<Nessuno>"
         End If
         cmbStampanteComanda10.Text = DatiConfig.GetValue("PercorsoStampaComanda10")
         If cmbStampanteComanda10.Text.Length = 0 Then
            cmbStampanteComanda10.Text = "<Nessuna>"
         End If
         cmbReportComanda10.Text = DatiConfig.GetValue("ReportComanda10")
         If cmbReportComanda10.Text.Length = 0 Then
            cmbReportComanda10.Text = String.Empty
         End If

         ' Comanda aggiuntiva.
         cmbStampanteComandaAgg.Text = DatiConfig.GetValue("PercorsoStampaComandaAgg")
         If cmbStampanteComandaAgg.Text.Length = 0 Then
            cmbStampanteComandaAgg.Text = "<Nessuna>"
         End If
         cmbReportComandaAgg.Text = DatiConfig.GetValue("ReportComandaAgg")
         If cmbReportComandaAgg.Text.Length = 0 Then
            cmbReportComandaAgg.Text = String.Empty
         End If

         cmbStampanteRicevute.Text = DatiConfig.GetValue("PercorsoStampaRicevute")
         If cmbStampanteRicevute.Text.Length = 0 Then
            cmbStampanteRicevute.Text = "<Nessuna>"
         End If
         cmbReportRicevute.Text = DatiConfig.GetValue("ReportRicevute")
         If cmbReportRicevute.Text.Length = 0 Then
            cmbReportRicevute.Text = String.Empty
         End If

         cmbStampanteFatture.Text = DatiConfig.GetValue("PercorsoStampaFatture")
         If cmbStampanteFatture.Text.Length = 0 Then
            cmbStampanteFatture.Text = "<Nessuna>"
         End If
         cmbReportFatture.Text = DatiConfig.GetValue("ReportFatture")
         If cmbReportFatture.Text.Length = 0 Then
            cmbReportFatture.Text = String.Empty
         End If

         cmbStampanteProforma.Text = DatiConfig.GetValue("PercorsoStampaProforma")
         If cmbStampanteProforma.Text.Length = 0 Then
            cmbStampanteProforma.Text = "<Nessuna>"
         End If
         cmbReportProforma.Text = DatiConfig.GetValue("ReportProforma")
         If cmbReportProforma.Text.Length = 0 Then
            cmbReportProforma.Text = String.Empty
         End If

         cmbStampanteScontrini.Text = DatiConfig.GetValue("PercorsoStampaScontrini")
         If cmbStampanteScontrini.Text.Length = 0 Then
            cmbStampanteScontrini.Text = "<Nessuna>"
         End If
         cmbReportScontrini.Text = DatiConfig.GetValue("ReportScontrini")
         If cmbReportScontrini.Text.Length = 0 Then
            cmbReportScontrini.Text = String.Empty
         End If

#End Region

#Region "SCHEDA DISPOSITIVO PALMARE "

         txtPercorsoRetePalmare.Text = DatiConfig.GetValue("PercorsoRP")
         If txtPercorsoRetePalmare.Text.Length = 0 Then
            txtPercorsoRetePalmare.Text = ""
         End If

         If DatiConfig.GetValue("AbilitaPalmareWindows") <> "" Then
            chkAbilitaPalmareWindows.Checked = DatiConfig.GetValue("AbilitaPalmareWindows")
         Else
            chkAbilitaPalmareWindows.Checked = False
         End If

         If DatiConfig.GetValue("AbilitaPalmareAndroid") <> "" Then
            chkAbilitaPalmareAndroid.Checked = DatiConfig.GetValue("AbilitaPalmareAndroid")
         Else
            chkAbilitaPalmareAndroid.Checked = False
         End If

         If chkAbilitaPalmareWindows.Checked = True Or chkAbilitaPalmareAndroid.Checked = True Then
            cmdAggiornaFilePalmare.Enabled = True
         Else
            cmdAggiornaFilePalmare.Enabled = False
         End If

         cmbFreqAggPalmare.Text = DatiConfig.GetValue("FreqAggPalmare")
         If cmbFreqAggPalmare.Text = "" Then
            cmbFreqAggPalmare.Text = "15"
         End If
         FreqAggPalmare = Convert.ToInt16(cmbFreqAggPalmare.Text)

#End Region

#Region "SCHEDA STAMPANTI FISCALI "

         If cmbStampanteProduttore.Enabled = True Then
            If DatiConfig.GetValue("ProduttoreSF") <> String.Empty Then
               cmbStampanteProduttore.Text = DatiConfig.GetValue("ProduttoreSF")
            Else
               cmbStampanteProduttore.Text = "RCH"
            End If
         End If

         If DatiConfig.GetValue("ModelloSF") <> String.Empty Then
            cmbStampanteModello.Text = DatiConfig.GetValue("ModelloSF")
         Else
            cmbStampanteModello.Text = "SWING ECR 65/A"
         End If

         ' RCH Swing ECR A/65
         cmbStampantePorta.Text = DatiConfig.GetValue("PortaSF")
         If cmbStampantePorta.Text.Length = 0 Then
            cmbStampantePorta.Text = ""
         End If
         txtStampanteParametri.Text = DatiConfig.GetValue("ParametriSF")
         If txtStampanteParametri.Text.Length = 0 Then
            txtStampanteParametri.Text = ""
         End If
         txtNomeScontrino.Text = DatiConfig.GetValue("NomeScontrinoSF")
         If txtNomeScontrino.Text.Length = 0 Then
            txtNomeScontrino.Text = ""
         End If
         txtPercorsoOutput.Text = DatiConfig.GetValue("PercorsoOutputSF")
         If txtPercorsoOutput.Text.Length = 0 Then
            txtPercorsoOutput.Text = ""
         End If
         txtPercorsoDriver.Text = DatiConfig.GetValue("PercorsoDriverSF")
         If txtPercorsoDriver.Text.Length = 0 Then
            txtPercorsoDriver.Text = ""
         End If

         ' Driver RTS WPOS1.
         txtPercorsoDriverWPOS1.Text = DatiConfig.GetValue("PercorsoDriverWpos1")
         If txtPercorsoDriverWPOS1.Text.Length = 0 Then
            txtPercorsoDriverWPOS1.Text = ""
         End If

         txtPercorsoWpos1.Text = DatiConfig.GetValue("PercorsoLavoroWpos1")
         If txtPercorsoWpos1.Text.Length = 0 Then
            txtPercorsoWpos1.Text = ""
         End If

         txtPasswordWpos1.Text = DatiConfig.GetValue("PwdDriverWpos1")
         If txtPasswordWpos1.Text.Length = 0 Then
            txtPasswordWpos1.Text = ""
         End If
         txtEstensioneFileWpos1.Text = DatiConfig.GetValue("EstensioneFileWpos1")
         If txtEstensioneFileWpos1.Text.Length = 0 Then
            txtEstensioneFileWpos1.Text = ""
         End If

#End Region

#Region "SCHEDA USB PEN DRIVE RECOVERY "

         txtPercorsoRecovery.Text = DatiConfig.GetValue("PercorsoRecovery")
         If txtPercorsoRecovery.Text.Length = 0 Then
            txtPercorsoRecovery.Text = String.Empty
         End If

         If DatiConfig.GetValue("AttivaRecovery") <> "" Then
            chkAttivaRecovery.Checked = DatiConfig.GetValue("AttivaRecovery")
         Else
            chkAttivaRecovery.Checked = False
         End If

         Dim dataRecovery As String = DatiConfig.GetValue("DataRecovery")
         If dataRecovery.Length = 0 Then
            lblDataSalvataggio.Text = String.Empty
         Else
            If IsDate(dataRecovery) = True Then
               lblDataSalvataggio.Text = "L'ultimo salvataggio per questa installazione del software risale a " & Convert.ToDateTime(dataRecovery).ToLongDateString
            Else
               lblDataSalvataggio.Text = String.Empty
            End If
         End If

#End Region

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiConfig()
      Try

#Region "SCHEDA GENERALI "

         DatiConfig.SetValue("FormatoFattAziende", cmbFormatoFatt.SelectedIndex.ToString)

         If DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) = String.Empty Then
            If txtPercorsoDB.Text.Length = 0 Then
               DatiConfig.SetValue("PercorsoDB", Application.StartupPath & PERCORSO_DB)
            Else
               DatiConfig.SetValue("PercorsoDB", txtPercorsoDB.Text)
            End If

            If txtPercorsoDBClienti.Text.Length = 0 Then
               DatiConfig.SetValue("PercorsoDBClienti", Application.StartupPath & PERCORSO_DB_CLIENTI)
            Else
               DatiConfig.SetValue("PercorsoDBClienti", txtPercorsoDBClienti.Text)
            End If

            If txtPercorsoBackup.Text.Length = 0 Then
               DatiConfig.SetValue("PercorsoBKP", Application.StartupPath & PERCORSO_BKP)
               PercorsoBKP = Application.StartupPath & PERCORSO_BKP
            Else
               DatiConfig.SetValue("PercorsoBKP", txtPercorsoBackup.Text)
               PercorsoBKP = txtPercorsoBackup.Text
            End If

         Else
            DatiConfig.SetValue("PercorsoDB", Application.StartupPath & PERCORSO_DB)
            DatiConfig.SetValue("PercorsoDBClienti", Application.StartupPath & PERCORSO_DB_CLIENTI)
            DatiConfig.SetValue("PercorsoBKP", Application.StartupPath & PERCORSO_BKP)
         End If

         DatiConfig.SetValue("SalvaBKP", chkSalvaBackup.Checked)
         SalvaBKP = chkSalvaBackup.Checked

         DatiConfig.SetValue("NumElememti", cmbNumElementi.Text)
         dimPagina = CInt(cmbNumElementi.Text)

         ' Percorso Gestionale Amica.
         If txtPercorsoAmica.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoAmica", String.Empty)
         Else
            DatiConfig.SetValue("PercorsoAmica", txtPercorsoAmica.Text)
         End If

         ' Fatture / Ricevute fiscali
         If IsNumeric(txtNumeroFattura.Text) = False Then
            Dim num As Integer = LeggiNumeroMax(TAB_DOC, TIPO_DOC_FF)
            If num = 0 Then
               DatiConfig.SetValue("NumeroFattura", "1")
            Else
               DatiConfig.SetValue("NumeroFattura", (num + 1).ToString)
            End If
         Else
            DatiConfig.SetValue("NumeroFattura", txtNumeroFattura.Text)
         End If

         If IsNumeric(txtNumeroRicevuta.Text) = False Then
            Dim num As Integer = LeggiNumeroMax(TAB_DOC, TIPO_DOC_RF)
            If num = 0 Then
               DatiConfig.SetValue("NumeroRicevuta", "1")
            Else
               DatiConfig.SetValue("NumeroRicevuta", (num + 1).ToString)
            End If
         Else
            DatiConfig.SetValue("NumeroRicevuta", txtNumeroRicevuta.Text)
         End If

         If nudNumCopieStampa.Text.Length = 0 Then
            DatiConfig.SetValue("NumCopieStampa", "1")
            NumeroCopieStampa = 1
         Else
            DatiConfig.SetValue("NumCopieStampa", nudNumCopieStampa.Value.ToString)
            NumeroCopieStampa = nudNumCopieStampa.Value
         End If

         ' Aliquote per i reparti.
         If txtAliquotaIva1.Text.Length = 0 Then
            DatiConfig.SetValue("AliquotaIva1", "")
         Else
            DatiConfig.SetValue("AliquotaIva1", txtAliquotaIva1.Text)
         End If

         If txtAliquotaIva2.Text.Length = 0 Then
            DatiConfig.SetValue("AliquotaIva2", "")
         Else
            DatiConfig.SetValue("AliquotaIva2", txtAliquotaIva2.Text)
         End If

         If txtAliquotaIva3.Text.Length = 0 Then
            DatiConfig.SetValue("AliquotaIva3", "")
         Else
            DatiConfig.SetValue("AliquotaIva3", txtAliquotaIva3.Text)
         End If

         If txtAliquotaIva4.Text.Length = 0 Then
            DatiConfig.SetValue("AliquotaIva4", "")
         Else
            DatiConfig.SetValue("AliquotaIva4", txtAliquotaIva4.Text)
         End If

#End Region

#Region "SCHEDA BAR / RISTORANTE "

         ' Aliquota IVA standard.
         DatiConfig.SetValue("RepartoAliquotaIvaRistorante", cmbIvaRistorante.Text)

         Select Case cmbIvaRistorante.Text
            Case "Reparto 1"
               DatiConfig.SetValue("AliquotaIvaRistorante", txtAliquotaIva1.Text)
               AliquotaIvaRistorante = txtAliquotaIva1.Text

            Case "Reparto 2"
               DatiConfig.SetValue("AliquotaIvaRistorante", txtAliquotaIva2.Text)
               AliquotaIvaRistorante = txtAliquotaIva2.Text

            Case "Reparto 3"
               DatiConfig.SetValue("AliquotaIvaRistorante", txtAliquotaIva3.Text)
               AliquotaIvaRistorante = txtAliquotaIva3.Text

            Case "Reparto 4"
               DatiConfig.SetValue("AliquotaIvaRistorante", txtAliquotaIva4.Text)
               AliquotaIvaRistorante = txtAliquotaIva4.Text

            Case Else
               DatiConfig.SetValue("AliquotaIvaRistorante", "")
               AliquotaIvaRistorante = String.Empty

         End Select

         ' Prezzo del Coperto.
         If txtCopertoRistorante.Text.Length = 0 Then
            DatiConfig.SetValue("CopertoRistorante", VALORE_ZERO)
            CopertoRistorante = VALORE_ZERO
         Else
            DatiConfig.SetValue("CopertoRistorante", txtCopertoRistorante.Text)
            CopertoRistorante = txtCopertoRistorante.Text
         End If

         ' Percentuale per il Servizio.
         If txtServizioRistorante.Text.Length = 0 Then
            DatiConfig.SetValue("ServizioRistorante", VALORE_ZERO)
            ServizioRistorante = VALORE_ZERO
         Else
            DatiConfig.SetValue("ServizioRistorante", txtServizioRistorante.Text)
            ServizioRistorante = txtServizioRistorante.Text
         End If

         ' Effetti sonori per il Punto cassa.
         DatiConfig.SetValue("EffettiSonoriPOS", ckbEffettiSonoriPos.Checked)
         EffettiSonoriPOS = ckbEffettiSonoriPos.Checked

         ' IMPOSTAZIONI PER LE PRENOTAZIONI DEI TAVOLI FATTE DA INTERNET. (WWW.TAVOLOSO.IT)

         ' Percorso file Tavoloso Agent.
         If txtPercorsoFileTavAgent.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoFileTavAgent", "")
         Else
            DatiConfig.SetValue("PercorsoFileTavAgent", txtPercorsoFileTavAgent.Text)
         End If

         ' Percorso cartella di lavoro Tavoloso Agent.
         If txtPercorsoCartellaTavAgent.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoCartellaTavAgent", "")
            PercorsoCartellaTavAgent = ""
         Else
            DatiConfig.SetValue("PercorsoCartellaTavAgent", txtPercorsoCartellaTavAgent.Text)
            PercorsoCartellaTavAgent = txtPercorsoCartellaTavAgent.Text
         End If

         ' Abilita ricezione delle prenotazioni.
         DatiConfig.SetValue("AbilitaRicezionePren", ckbAbilitaRicezioneTavAgent.Checked)
         AbilitaRicezionePren = ckbAbilitaRicezioneTavAgent.Checked

         ' Effetto sonoro per la notifica delle prenotazioni.
         DatiConfig.SetValue("EffettoSonoroPren", ckbNotificaTavAgent.Checked)
         EffettoSonoroPren = ckbNotificaTavAgent.Checked

         ' Colore della prenotazione.
         DatiConfig.SetValue("ColorePrenTavAgent", cmdColorePrenTavAgent.BackColor.ToArgb)
         ColorePrenTavAgent = cmdColorePrenTavAgent.BackColor

#End Region

#Region "SCHEDA HOTEL "

         ' Tipo di esercizio.
         DatiConfig.SetValue("TipoEsercizioHotel", cmbTipoEsercizio.Text)

         ' Numero stelle.
         DatiConfig.SetValue("NumeroStelleHotel", cmbNumStelle.Text)

         ' Aliquota IVA standard.
         DatiConfig.SetValue("RepartoAliquotaIvaHotel", cmbIvaCamere.Text)

         Select Case cmbIvaCamere.Text
            Case "Reparto 1"
               DatiConfig.SetValue("AliquotaIvaHotel", txtAliquotaIva1.Text)
               AliquotaIvaHotel = txtAliquotaIva1.Text

            Case "Reparto 2"
               DatiConfig.SetValue("AliquotaIvaHotel", txtAliquotaIva2.Text)
               AliquotaIvaHotel = txtAliquotaIva2.Text

            Case "Reparto 3"
               DatiConfig.SetValue("AliquotaIvaHotel", txtAliquotaIva3.Text)
               AliquotaIvaHotel = txtAliquotaIva3.Text

            Case "Reparto 4"
               DatiConfig.SetValue("AliquotaIvaHotel", txtAliquotaIva4.Text)
               AliquotaIvaHotel = txtAliquotaIva4.Text

            Case Else
               DatiConfig.SetValue("AliquotaIvaHotel", "")
               AliquotaIvaHotel = String.Empty

         End Select

         ' Percentuale per il Servizio.
         If txtServizioCamere.Text.Length = 0 Then
            DatiConfig.SetValue("ServizioHotel", VALORE_ZERO)
            ServizioHotel = VALORE_ZERO
         Else
            DatiConfig.SetValue("ServizioHotel", txtServizioCamere.Text)
            ServizioHotel = txtServizioCamere.Text
         End If

         ' Tassa di soggiorno.
         If txtTassaSoggiorno.Text.Length = 0 Then
            DatiConfig.SetValue("TassaSoggiornoHotel", VALORE_ZERO)
            'TassaSoggiornoHotel = VALORE_ZERO
         Else
            DatiConfig.SetValue("TassaSoggiornoHotel", txtTassaSoggiorno.Text)
            'TassaSoggiornoHotel = txtTassaSoggiorno.Text
         End If

         ' Descrizione Tassa di soggiorno.
         If txtDescrizioneTassaSogg.Text.Length = 0 Then
            DatiConfig.SetValue("DescrizioneTassaSoggHotel", String.Empty)
         Else
            DatiConfig.SetValue("DescrizioneTassaSoggHotel", txtDescrizioneTassaSogg.Text)
         End If

         ' DA_FARE: Verificare!
         ' Applica Tassa di soggiorno Neonati.
         DatiConfig.SetValue("ApplicaTassaNeonati", ckbApplicaTassaNeonati.Checked)
         'ApplicaTassaNeonati = ckbApplicaTassaNeonati.Checked

         ' Applica Tassa di soggiorno Bambini.
         DatiConfig.SetValue("ApplicaTassaBambini", ckbApplicaTassaBambini.Checked)
         'ApplicaTassaBambini = ckbApplicaTassaBambini.Checked

         ' Applica Tassa di soggiorno Ragazzi.
         DatiConfig.SetValue("ApplicaTassaRagazzi", ckbApplicaTassaRagazzi.Checked)
         'ApplicaTassaRagazzi = ckbApplicaTassaRagazzi.Checked

         ' Numerazione progressiva Schedine PS.
         If IsNumeric(txtNumeroSchedinaPS.Text) = False Then
            Dim num As Integer = LeggiNumeroMaxSchedine(TAB_SCHEDINE)
            If num = 0 Then
               DatiConfig.SetValue("NumeroSchedina", "1")
            Else
               DatiConfig.SetValue("NumeroSchedina", (num + 1).ToString)
            End If
         Else
            DatiConfig.SetValue("NumeroSchedina", txtNumeroSchedinaPS.Text)
         End If

         ' Numerazione progressiva Modello ISTAT C/59.
         If IsNumeric(txtNumeroModC59.Text) = False Then
            DatiConfig.SetValue("NumeroModC59", "1")
         Else
            DatiConfig.SetValue("NumeroModC59", txtNumeroModC59.Text)
         End If

#End Region

#Region "SCHEDA CENTRO SPORTIVO "

         ' Aliquota IVA standard.
         DatiConfig.SetValue("RepartoAliquotaIvaCentroSportivo", cmbIvaCentroSportivo.Text)

         Select Case cmbIvaCentroSportivo.Text
            Case "Reparto 1"
               DatiConfig.SetValue("AliquotaIvaCentroSportivo", txtAliquotaIva1.Text)
               AliquotaIvaCentroSportivo = txtAliquotaIva1.Text

            Case "Reparto 2"
               DatiConfig.SetValue("AliquotaIvaCentroSportivo", txtAliquotaIva2.Text)
               AliquotaIvaCentroSportivo = txtAliquotaIva2.Text

            Case "Reparto 3"
               DatiConfig.SetValue("AliquotaIvaCentroSportivo", txtAliquotaIva3.Text)
               AliquotaIvaCentroSportivo = txtAliquotaIva3.Text

            Case "Reparto 4"
               DatiConfig.SetValue("AliquotaIvaCentroSportivo", txtAliquotaIva4.Text)
               AliquotaIvaCentroSportivo = txtAliquotaIva4.Text

            Case Else
               DatiConfig.SetValue("AliquotaIvaCentroSportivo", "")
               AliquotaIvaCentroSportivo = String.Empty

         End Select

#End Region

#Region "SCHEDA PERCORSI DI STAMPA "

         ' Comande - Percorso 1
         If cmbReparto1.Text.Length = 0 Then
            DatiConfig.SetValue("Reparto1", "<Nessuno>")
         Else
            DatiConfig.SetValue("Reparto1", cmbReparto1.Text)
         End If
         If cmbStampanteComanda1.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComanda1", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComanda1", cmbStampanteComanda1.Text)
         End If
         If cmbReportComanda1.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComanda1", String.Empty)
         Else
            DatiConfig.SetValue("ReportComanda1", cmbReportComanda1.Text)
         End If

         ' Comande - Percorso 2
         If cmbReparto2.Text.Length = 0 Then
            DatiConfig.SetValue("Reparto2", "<Nessuno>")
         Else
            DatiConfig.SetValue("Reparto2", cmbReparto2.Text)
         End If
         If cmbStampanteComanda2.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComanda2", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComanda2", cmbStampanteComanda2.Text)
         End If
         If cmbReportComanda2.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComanda2", String.Empty)
         Else
            DatiConfig.SetValue("ReportComanda2", cmbReportComanda2.Text)
         End If

         ' Comande - Percorso 3
         If cmbReparto3.Text.Length = 0 Then
            DatiConfig.SetValue("Reparto3", "<Nessuno>")
         Else
            DatiConfig.SetValue("Reparto3", cmbReparto3.Text)
         End If
         If cmbStampanteComanda3.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComanda3", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComanda3", cmbStampanteComanda3.Text)
         End If
         If cmbReportComanda3.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComanda3", String.Empty)
         Else
            DatiConfig.SetValue("ReportComanda3", cmbReportComanda3.Text)
         End If

         ' Comande - Percorso 4
         If cmbReparto4.Text.Length = 0 Then
            DatiConfig.SetValue("Reparto4", "<Nessuno>")
         Else
            DatiConfig.SetValue("Reparto4", cmbReparto4.Text)
         End If
         If cmbStampanteComanda4.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComanda4", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComanda4", cmbStampanteComanda4.Text)
         End If
         If cmbReportComanda4.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComanda4", String.Empty)
         Else
            DatiConfig.SetValue("ReportComanda4", cmbReportComanda4.Text)
         End If

         ' Comande - Percorso 5
         If cmbReparto5.Text.Length = 0 Then
            DatiConfig.SetValue("Reparto5", "<Nessuno>")
         Else
            DatiConfig.SetValue("Reparto5", cmbReparto5.Text)
         End If
         If cmbStampanteComanda5.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComanda5", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComanda5", cmbStampanteComanda5.Text)
         End If
         If cmbReportComanda5.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComanda5", String.Empty)
         Else
            DatiConfig.SetValue("ReportComanda5", cmbReportComanda5.Text)
         End If

         ' Comande - Percorso 6
         If cmbReparto6.Text.Length = 0 Then
            DatiConfig.SetValue("Reparto6", "<Nessuno>")
         Else
            DatiConfig.SetValue("Reparto6", cmbReparto6.Text)
         End If
         If cmbStampanteComanda6.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComanda6", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComanda6", cmbStampanteComanda6.Text)
         End If
         If cmbReportComanda6.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComanda6", String.Empty)
         Else
            DatiConfig.SetValue("ReportComanda6", cmbReportComanda6.Text)
         End If

         ' Comande - Percorso 7
         If cmbReparto7.Text.Length = 0 Then
            DatiConfig.SetValue("Reparto7", "<Nessuno>")
         Else
            DatiConfig.SetValue("Reparto7", cmbReparto7.Text)
         End If
         If cmbStampanteComanda7.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComanda7", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComanda7", cmbStampanteComanda7.Text)
         End If
         If cmbReportComanda7.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComanda7", String.Empty)
         Else
            DatiConfig.SetValue("ReportComanda7", cmbReportComanda7.Text)
         End If

         ' Comande - Percorso 8
         If cmbReparto8.Text.Length = 0 Then
            DatiConfig.SetValue("Reparto8", "<Nessuno>")
         Else
            DatiConfig.SetValue("Reparto8", cmbReparto8.Text)
         End If
         If cmbStampanteComanda8.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComanda8", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComanda8", cmbStampanteComanda8.Text)
         End If
         If cmbReportComanda8.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComanda8", String.Empty)
         Else
            DatiConfig.SetValue("ReportComanda8", cmbReportComanda8.Text)
         End If

         ' Comande - Percorso 9
         If cmbReparto9.Text.Length = 0 Then
            DatiConfig.SetValue("Reparto9", "<Nessuno>")
         Else
            DatiConfig.SetValue("Reparto9", cmbReparto9.Text)
         End If
         If cmbStampanteComanda9.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComanda9", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComanda9", cmbStampanteComanda9.Text)
         End If
         If cmbReportComanda9.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComanda9", String.Empty)
         Else
            DatiConfig.SetValue("ReportComanda9", cmbReportComanda9.Text)
         End If

         ' Comande - Percorso 10
         If cmbReparto10.Text.Length = 0 Then
            DatiConfig.SetValue("Reparto10", "<Nessuno>")
         Else
            DatiConfig.SetValue("Reparto10", cmbReparto10.Text)
         End If
         If cmbStampanteComanda10.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComanda10", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComanda10", cmbStampanteComanda10.Text)
         End If
         If cmbReportComanda10.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComanda10", String.Empty)
         Else
            DatiConfig.SetValue("ReportComanda10", cmbReportComanda10.Text)
         End If

         ' Comanda aggiuntiva.
         If cmbStampanteComandaAgg.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaComandaAgg", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaComandaAgg", cmbStampanteComandaAgg.Text)
         End If
         If cmbReportComandaAgg.Text.Length = 0 Then
            DatiConfig.SetValue("ReportComandaAgg", String.Empty)
         Else
            DatiConfig.SetValue("ReportComandaAgg", cmbReportComandaAgg.Text)
         End If

         ' Ricevute.
         If cmbStampanteRicevute.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaRicevute", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaRicevute", cmbStampanteRicevute.Text)
         End If
         If cmbReportRicevute.Text.Length = 0 Then
            DatiConfig.SetValue("ReportRicevute", String.Empty)
         Else
            DatiConfig.SetValue("ReportRicevute", cmbReportRicevute.Text)
         End If

         ' Fatture.
         If cmbStampanteFatture.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaFatture", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaFatture", cmbStampanteFatture.Text)
         End If
         If cmbReportFatture.Text.Length = 0 Then
            DatiConfig.SetValue("ReportFatture", String.Empty)
         Else
            DatiConfig.SetValue("ReportFatture", cmbReportFatture.Text)
         End If

         ' Proforma.
         If cmbStampanteProforma.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaProforma", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaProforma", cmbStampanteProforma.Text)
         End If
         If cmbReportProforma.Text.Length = 0 Then
            DatiConfig.SetValue("ReportProforma", String.Empty)
         Else
            DatiConfig.SetValue("ReportProforma", cmbReportProforma.Text)
         End If

         ' Scontrini.
         If cmbStampanteScontrini.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoStampaScontrini", "<Nessuna>")
         Else
            DatiConfig.SetValue("PercorsoStampaScontrini", cmbStampanteScontrini.Text)
         End If
         If cmbReportScontrini.Text.Length = 0 Then
            DatiConfig.SetValue("ReportScontrini", String.Empty)
         Else
            DatiConfig.SetValue("ReportScontrini", cmbReportScontrini.Text)
         End If

#End Region

#Region "SCHEDA DISPOSITIVO PALMARE "

         If txtPercorsoRetePalmare.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoRP", "")
            PercorsoRP = ""
         Else
            DatiConfig.SetValue("PercorsoRP", txtPercorsoRetePalmare.Text)
            PercorsoRP = txtPercorsoRetePalmare.Text
         End If

         DatiConfig.SetValue("AbilitaPalmareWindows", chkAbilitaPalmareWindows.Checked)
         AbilitaPalmareWindows = chkAbilitaPalmareWindows.Checked

         DatiConfig.SetValue("AbilitaPalmareAndroid", chkAbilitaPalmareAndroid.Checked)
         AbilitaPalmareAndroid = chkAbilitaPalmareAndroid.Checked

         DatiConfig.SetValue("FreqAggPalmare", cmbFreqAggPalmare.Text)
         FreqAggPalmare = Convert.ToInt16(cmbFreqAggPalmare.Text)

#End Region

#Region "SCHEDA STAMPANTI FISCALI "

         If cmbStampanteProduttore.Text.Length = 0 Then
            DatiConfig.SetValue("ProduttoreSF", "")
            ProduttoreSF = ""
         Else
            DatiConfig.SetValue("ProduttoreSF", cmbStampanteProduttore.Text)
            ProduttoreSF = cmbStampanteProduttore.Text
         End If

         If cmbStampanteModello.Text.Length = 0 Then
            DatiConfig.SetValue("ModelloSF", "")
            ModelloSF = ""
         Else
            DatiConfig.SetValue("ModelloSF", cmbStampanteModello.Text)
            ModelloSF = cmbStampanteModello.Text
         End If

         ' RCH Swing A/65 ECR.

         If cmbStampantePorta.Text.Length = 0 Then
            DatiConfig.SetValue("PortaSF", "")
            PortaSF = ""
         Else
            DatiConfig.SetValue("PortaSF", cmbStampantePorta.Text)
            PortaSF = cmbStampantePorta.Text
         End If

         If txtStampanteParametri.Text.Length = 0 Then
            DatiConfig.SetValue("ParametriSF", "")
            ParametriSF = ""
         Else
            DatiConfig.SetValue("ParametriSF", txtStampanteParametri.Text)
            ParametriSF = txtStampanteParametri.Text
         End If

         If txtNomeScontrino.Text.Length = 0 Then
            DatiConfig.SetValue("NomeScontrinoSF", "")
            NomeScontrinoSF = ""
         Else
            DatiConfig.SetValue("NomeScontrinoSF", txtNomeScontrino.Text)
            NomeScontrinoSF = txtNomeScontrino.Text
         End If

         If txtPercorsoOutput.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoOutputSF", "")
            PercorsoOutputSF = ""
         Else
            DatiConfig.SetValue("PercorsoOutputSF", txtPercorsoOutput.Text)
            PercorsoOutputSF = txtPercorsoOutput.Text
         End If

         If txtPercorsoDriver.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoDriverSF", "")
            PercorsoDriverSF = ""
         Else
            DatiConfig.SetValue("PercorsoDriverSF", txtPercorsoDriver.Text)
            PercorsoDriverSF = txtPercorsoDriver.Text
         End If

         ' Driver RTS WPOS1.

         If txtPercorsoDriverWPOS1.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoDriverWpos1", "")
            PercorsoDriverWpos1 = ""
         Else
            DatiConfig.SetValue("PercorsoDriverWpos1", txtPercorsoDriverWPOS1.Text)
            PercorsoDriverWpos1 = txtPercorsoDriverWPOS1.Text
         End If

         If txtPercorsoWpos1.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoLavoroWpos1", "")
            PercorsoLavoroWpos1 = ""
         Else
            DatiConfig.SetValue("PercorsoLavoroWpos1", txtPercorsoWpos1.Text)
            PercorsoLavoroWpos1 = txtPercorsoWpos1.Text
         End If

         If txtPasswordWpos1.Text.Length = 0 Then
            DatiConfig.SetValue("PwdDriverWpos1", "")
            PwdDriverWpos1 = ""
         Else
            DatiConfig.SetValue("PwdDriverWpos1", txtPasswordWpos1.Text)
            PwdDriverWpos1 = txtPasswordWpos1.Text
         End If

         If txtEstensioneFileWpos1.Text.Length = 0 Then
            DatiConfig.SetValue("EstensioneFileWpos1", "")
            EstensioneFileWpos1 = ""
         Else
            DatiConfig.SetValue("EstensioneFileWpos1", txtEstensioneFileWpos1.Text)
            EstensioneFileWpos1 = txtEstensioneFileWpos1.Text
         End If

#End Region

#Region "SCHEDA USB PEN DRIVE RECOVERY "

         If txtPercorsoRecovery.Text.Length = 0 Then
            DatiConfig.SetValue("PercorsoRecovery", "")
         Else
            DatiConfig.SetValue("PercorsoRecovery", txtPercorsoRecovery.Text)
         End If

         DatiConfig.SetValue("AttivaRecovery", chkAttivaRecovery.Checked)

#End Region

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function LeggiNumeroMax(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim tr As OleDbTransaction
      Dim sql As String
      Dim cmd As New OleDbCommand(sql, cn)

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

   Private Function LeggiNumeroMaxSchedine(ByVal tabella As String) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim tr As OleDbTransaction
      Dim sql As String
      Dim cmd As New OleDbCommand(sql, cn)

      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT MAX(Numero) FROM {0}", tabella)

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

   Private Sub CaricaMarcheECR()
      Try
         ' 3i.
         marcheECR(0) = ECR_3i
         modelliECR_3i(0) = ECR_3i_Chigago
         modelliECR_3i(1) = ECR_3i_Dallas
         modelliECR_3i(2) = ECR_3i_FTP_Fast
         modelliECR_3i(3) = ECR_3i_FTP_Easy
         modelliECR_3i(4) = ECR_3i_Manhattan
         modelliECR_3i(5) = ECR_3i_Miami
         modelliECR_3i(6) = ECR_3i_Texas

         ' Asem
         marcheECR(1) = ECR_Asem
         modelliECR_Asem(0) = ECR_Asem_SF58
         modelliECR_Asem(1) = ECR_Asem_SF60
         modelliECR_Asem(2) = ECR_Asem_SF80

         ' AXON.
         marcheECR(2) = ECR_Axon
         modelliECR_Axon(0) = ECR_Axon_ONE
         modelliECR_Axon(1) = ECR_Axon_SKY_TP07F

         ' Buffetti.
         marcheECR(3) = ECR_Buffetti
         modelliECR_Buffetti(0) = ECR_Buffetti_Compact7
         modelliECR_Buffetti(1) = ECR_Buffetti_ECRC9
         modelliECR_Buffetti(2) = ECR_Buffetti_ECRP9
         modelliECR_Buffetti(3) = ECR_Buffetti_NETTUNA200

         ' Cei.
         marcheECR(4) = ECR_Cei
         modelliECR_Cei(0) = ECR_Cei_RC300
         modelliECR_Cei(1) = ECR_Cei_SPR500

         ' Coris.
         marcheECR(5) = ECR_Coris
         modelliECR_Coris(0) = ECR_Coris_Fly_ETH
         modelliECR_Coris(1) = ECR_Coris_Fly
         modelliECR_Coris(2) = ECR_Coris_Zero5
         modelliECR_Coris(3) = ECR_Coris_Zero7

         ' Custom.
         marcheECR(6) = ECR_Custom
         modelliECR_Custom(0) = ECR_Custom_Big
         modelliECR_Custom(1) = ECR_Custom_BigII
         modelliECR_Custom(2) = ECR_Custom_BigII_Touch
         modelliECR_Custom(3) = ECR_Custom_BigU33
         modelliECR_Custom(4) = ECR_Custom_Kube
         modelliECR_Custom(5) = ECR_Custom_KubeEcr
         modelliECR_Custom(6) = ECR_Custom_KubeETH
         modelliECR_Custom(7) = ECR_Custom_KubeEvo
         modelliECR_Custom(8) = ECR_Custom_KubeF
         modelliECR_Custom(9) = ECR_Custom_KubeIIF
         modelliECR_Custom(10) = ECR_Custom_Max
         modelliECR_Custom(11) = ECR_Custom_MaxA
         modelliECR_Custom(12) = ECR_Custom_MaxI
         modelliECR_Custom(13) = ECR_Custom_MaxPlay
         modelliECR_Custom(14) = ECR_Custom_Play
         modelliECR_Custom(15) = ECR_Custom_Q3F
         modelliECR_Custom(16) = ECR_Custom_Q3F_ETH
         modelliECR_Custom(17) = ECR_Custom_Thea
         modelliECR_Custom(18) = ECR_Custom_TheaA
         modelliECR_Custom(19) = ECR_Custom_XKube
         modelliECR_Custom(20) = ECR_Custom_XKubeETH

         ' DataProcess.
         marcheECR(7) = ECR_DataProcess
         modelliECR_DataProcess(0) = ECR_DataProcess_100S
         modelliECR_DataProcess(1) = ECR_DataProcess_200S
         modelliECR_DataProcess(2) = ECR_DataProcess_270GE
         modelliECR_DataProcess(3) = ECR_DataProcess_270M
         modelliECR_DataProcess(4) = ECR_DataProcess_40Silver
         modelliECR_DataProcess(5) = ECR_DataProcess_Delphys
         modelliECR_DataProcess(6) = ECR_DataProcess_Diesis
         modelliECR_DataProcess(7) = ECR_DataProcess_Diesis8
         modelliECR_DataProcess(8) = ECR_DataProcess_Magic
         modelliECR_DataProcess(9) = ECR_DataProcess_Saturno

         ' Distribution System.
         marcheECR(8) = ECR_DistributionSystem
         modelliECR_DistributionSystem(0) = ECR_DistributionSystem_DS204
         modelliECR_DistributionSystem(1) = ECR_DistributionSystem_DS280
         modelliECR_DistributionSystem(2) = ECR_DistributionSystem_DSDot
         modelliECR_DistributionSystem(3) = ECR_DistributionSystem_Progress
         modelliECR_DistributionSystem(4) = ECR_DistributionSystem_ProgressEJ
         modelliECR_DistributionSystem(5) = ECR_DistributionSystem_ProgressGE
         modelliECR_DistributionSystem(6) = ECR_DistributionSystem_ProgressT
         modelliECR_DistributionSystem(7) = ECR_DistributionSystem_RS40
         modelliECR_DistributionSystem(8) = ECR_DistributionSystem_RS50

         ' Ditron.
         marcheECR(9) = ECR_Ditron
         modelliECR_Ditron(0) = ECR_Ditron_CasioMarketEJ
         modelliECR_Ditron(1) = ECR_Ditron_ETH
         modelliECR_Ditron(2) = ECR_Ditron_FP600
         modelliECR_Ditron(3) = ECR_Ditron_Medea
         modelliECR_Ditron(4) = ECR_Ditron_Mi200
         modelliECR_Ditron(5) = ECR_Ditron_Mi3000
         modelliECR_Ditron(6) = ECR_Ditron_Mi320EJ
         modelliECR_Ditron(7) = ECR_Ditron_Nesso
         modelliECR_Ditron(8) = ECR_Ditron_Simple
         modelliECR_Ditron(9) = ECR_Ditron_Sun
         modelliECR_Ditron(10) = ECR_Ditron_UniversoEJ
         modelliECR_Ditron(11) = ECR_Ditron_Velvet
         modelliECR_Ditron(12) = ECR_Ditron_Zip

         ' DTR-Italia.
         marcheECR(10) = ECR_DTR_Italia
         modelliECR_DTR_Italia(0) = ECR_DTR_Italia_DCash
         modelliECR_DTR_Italia(1) = ECR_DTR_Italia_DPalm
         modelliECR_DTR_Italia(2) = ECR_DTR_Italia_DPrint

         ' Elsi Retail.
         marcheECR(11) = ECR_Elsi_Retail
         modelliECR_Elsi_Retail(0) = ECR_Elsi_Retail_R1000
         modelliECR_Elsi_Retail(1) = ECR_Elsi_Retail_R158EJ
         modelliECR_Elsi_Retail(2) = ECR_Elsi_Retail_R338EJ
         modelliECR_Elsi_Retail(3) = ECR_Elsi_Retail_R503
         modelliECR_Elsi_Retail(4) = ECR_Elsi_Retail_R504
         modelliECR_Elsi_Retail(5) = ECR_Elsi_Retail_R58EJ
         modelliECR_Elsi_Retail(6) = ECR_Elsi_Retail_R680EJ
         modelliECR_Elsi_Retail(7) = ECR_Elsi_Retail_R680EJ_ETH
         modelliECR_Elsi_Retail(8) = ECR_Elsi_Retail_R800
         modelliECR_Elsi_Retail(9) = ECR_Elsi_Retail_R800EJ

         ' Epm Ed.It.
         marcheECR(12) = ECR_EpmEdIt
         modelliECR_EpmEdIt(0) = ECR_EpmEdIt_ONE
         modelliECR_EpmEdIt(1) = ECR_EpmEdIt_ONE_XonXoff
         modelliECR_EpmEdIt(2) = ECR_EpmEdIt_ONELE
         modelliECR_EpmEdIt(3) = ECR_EpmEdIt_ONELE_XonXoff
         modelliECR_EpmEdIt(4) = ECR_EpmEdIt_ONESX
         modelliECR_EpmEdIt(5) = ECR_EpmEdIt_ONESX_XonXoff
         modelliECR_EpmEdIt(6) = ECR_EpmEdIt_SEVENT
         modelliECR_EpmEdIt(7) = ECR_EpmEdIt_Smarty
         modelliECR_EpmEdIt(8) = ECR_EpmEdIt_SFEP80
         modelliECR_EpmEdIt(9) = ECR_EpmEdIt_SFEP80_XonXoff

         ' Epson.
         marcheECR(13) = ECR_Epson
         modelliECR_Epson(0) = ECR_Epson_FP81
         modelliECR_Epson(1) = ECR_Epson_FP90
         modelliECR_Epson(2) = ECR_Epson_FP90II
         modelliECR_Epson(3) = ECR_Epson_FP90III

         ' Eurodata.
         marcheECR(14) = ECR_Eurodata
         modelliECR_Eurodata(0) = ECR_Eurodata_Pagaso

         ' Fasy.
         marcheECR(15) = ECR_Fasy
         modelliECR_Fasy(0) = ECR_Fasy_Butterfly
         modelliECR_Fasy(1) = ECR_Fasy_Grecale
         modelliECR_Fasy(2) = ECR_Fasy_Libeccio
         modelliECR_Fasy(3) = ECR_Fasy_MistralPlus
         modelliECR_Fasy(4) = ECR_Fasy_MistralTop
         modelliECR_Fasy(5) = ECR_Fasy_Scirocco
         modelliECR_Fasy(6) = ECR_Fasy_SciroccoSmart
         modelliECR_Fasy(7) = ECR_Fasy_Windkey
         modelliECR_Fasy(8) = ECR_Fasy_Windy
         modelliECR_Fasy(9) = ECR_Fasy_Zephyr
         modelliECR_Fasy(10) = ECR_Fasy_Zephyr80PlusEJ
         modelliECR_Fasy(11) = ECR_Fasy_ZephyrLite
         modelliECR_Fasy(12) = ECR_Fasy_ZephyrPlus

         ' Helmac.
         marcheECR(16) = ECR_Helmac
         modelliECR_Helmac(0) = ECR_Helmac_Linx
         modelliECR_Helmac(1) = ECR_Helmac_Puma
         modelliECR_Helmac(2) = ECR_Helmac_PumaT
         modelliECR_Helmac(3) = ECR_Helmac_Tiger
         modelliECR_Helmac(4) = ECR_Helmac_TigerPro

         ' Hugin.
         marcheECR(17) = ECR_Hugin
         modelliECR_Hugin(0) = ECR_Hugin_K120GE
         modelliECR_Hugin(1) = ECR_Hugin_One
         modelliECR_Hugin(2) = ECR_Hugin_Tornado
         modelliECR_Hugin(3) = ECR_Hugin_Twister

         ' I2 Idee Italiane.
         marcheECR(18) = ECR_I2_Idee_Italiane
         modelliECR_I2_Idee_Italiane(0) = ECR_I2_Idee_Italiane_Forma
         modelliECR_I2_Idee_Italiane(1) = ECR_I2_Idee_Italiane_Segno
         modelliECR_I2_Idee_Italiane(2) = ECR_I2_Idee_Italiane_SegnoTouch

         ' Ibm.
         marcheECR(19) = ECR_Ibm
         modelliECR_Ibm(0) = ECR_Ibm_Entry01
         modelliECR_Ibm(1) = ECR_Ibm_Entry01A
         modelliECR_Ibm(2) = ECR_Ibm_Entry2000
         modelliECR_Ibm(3) = ECR_Ibm_PD25
         modelliECR_Ibm(4) = ECR_Ibm_PD215

         ' Indesit/Ditron.
         marcheECR(20) = ECR_Indesit_Ditron
         modelliECR_Indesit_Ditron(0) = ECR_Indesit_Ditron_

         ' Italiana Macchi.
         marcheECR(21) = ECR_Italiana_Macchi
         modelliECR_Italiana_Macchi(0) = ECR_Italiana_Macchi_A1500
         modelliECR_Italiana_Macchi(1) = ECR_Italiana_Macchi_A1500BT
         modelliECR_Italiana_Macchi(2) = ECR_Italiana_Macchi_S850
         modelliECR_Italiana_Macchi(3) = ECR_Italiana_Macchi_S850Touch
         modelliECR_Italiana_Macchi(4) = ECR_Italiana_Macchi_Speed

         ' Mct.
         marcheECR(22) = ECR_Mct
         modelliECR_Mct(0) = ECR_Mct_Flea
         modelliECR_Mct(1) = ECR_Mct_Flea_AT
         modelliECR_Mct(2) = ECR_Mct_FleaA
         modelliECR_Mct(3) = ECR_Mct_FlyXT
         modelliECR_Mct(4) = ECR_Mct_OverPC_ETH
         modelliECR_Mct(5) = ECR_Mct_Over
         modelliECR_Mct(6) = ECR_Mct_OverTouch
         modelliECR_Mct(7) = ECR_Mct_Print_F
         modelliECR_Mct(8) = ECR_Mct_Print_F_ETH
         modelliECR_Mct(9) = ECR_Mct_Spot

         ' Micrelec.
         marcheECR(23) = ECR_Micrelec
         modelliECR_Micrelec(0) = ECR_Micrelec_ByBLOS
         modelliECR_Micrelec(1) = ECR_Micrelec_Edipos
         modelliECR_Micrelec(2) = ECR_Micrelec_Krono
         modelliECR_Micrelec(3) = ECR_Micrelec_Mi100
         modelliECR_Micrelec(4) = ECR_Micrelec_Mi110
         modelliECR_Micrelec(5) = ECR_Micrelec_Mi310
         modelliECR_Micrelec(6) = ECR_Micrelec_Mi710
         modelliECR_Micrelec(7) = ECR_Micrelec_Paros

         ' Microrex.
         marcheECR(24) = ECR_Microrex
         modelliECR_Microrex(0) = ECR_Microrex_TH35
         modelliECR_Microrex(1) = ECR_Microrex_TH36LUX
         modelliECR_Microrex(2) = ECR_Microrex_TH39

         ' Ncr.
         marcheECR(25) = ECR_Ncr
         modelliECR_Ncr(0) = ECR_Ncr_2140
         modelliECR_Ncr(1) = ECR_Ncr_2215
         modelliECR_Ncr(2) = ECR_Ncr_2215EJ
         modelliECR_Ncr(3) = ECR_Ncr_RealCash
         modelliECR_Ncr(4) = ECR_Ncr_RealCashEJ
         modelliECR_Ncr(5) = ECR_Ncr_RealprintEJ

         ' OkCash.
         marcheECR(26) = ECR_OkCash
         modelliECR_OkCash(0) = ECR_OkCash_Elegant
         modelliECR_OkCash(1) = ECR_OkCash_OKCash

         ' Olivetti.
         marcheECR(27) = ECR_Olivetti
         modelliECR_Olivetti(0) = ECR_Olivetti_CRFEJ
         modelliECR_Olivetti(1) = ECR_Olivetti_CRFPJ
         modelliECR_Olivetti(2) = ECR_Olivetti_Logic
         modelliECR_Olivetti(3) = ECR_Olivetti_Nettuna
         modelliECR_Olivetti(4) = ECR_Olivetti_Nettuna200
         modelliECR_Olivetti(5) = ECR_Olivetti_Nettuna250
         modelliECR_Olivetti(6) = ECR_Olivetti_Nettuna300
         modelliECR_Olivetti(7) = ECR_Olivetti_Nettuna400
         modelliECR_Olivetti(8) = ECR_Olivetti_Nettuna500
         modelliECR_Olivetti(9) = ECR_Olivetti_Nettuna600
         modelliECR_Olivetti(10) = ECR_Olivetti_Nettuna700
         modelliECR_Olivetti(11) = ECR_Olivetti_NettunaJet
         modelliECR_Olivetti(12) = ECR_Olivetti_NettunaPRT200FX
         modelliECR_Olivetti(13) = ECR_Olivetti_Open
         modelliECR_Olivetti(14) = ECR_Olivetti_PRT100
         modelliECR_Olivetti(15) = ECR_Olivetti_PRT100F
         modelliECR_Olivetti(16) = ECR_Olivetti_PRT100FX
         modelliECR_Olivetti(17) = ECR_Olivetti_PRT105
         modelliECR_Olivetti(18) = ECR_Olivetti_PRT110FX
         modelliECR_Olivetti(19) = ECR_Olivetti_PRT200F
         modelliECR_Olivetti(20) = ECR_Olivetti_PRT200FX
         modelliECR_Olivetti(21) = ECR_Olivetti_PRT300FX_RETE
         modelliECR_Olivetti(22) = ECR_Olivetti_PRT300FX_RS232

         ' RCH.
         marcheECR(28) = ECR_RCH
         modelliECR_RCH(0) = ECR_RCH_G1200
         modelliECR_RCH(1) = ECR_RCH_G1201
         modelliECR_RCH(2) = ECR_RCH_G2000
         modelliECR_RCH(3) = ECR_RCH_G3000
         modelliECR_RCH(4) = ECR_RCH_G3000F
         modelliECR_RCH(5) = ECR_RCH_G3000S
         modelliECR_RCH(6) = ECR_RCH_Globe
         modelliECR_RCH(7) = ECR_RCH_GlobeECR
         modelliECR_RCH(8) = ECR_RCH_GlobePC
         modelliECR_RCH(9) = ECR_RCH_GlobePC_RETE_ETH
         modelliECR_RCH(10) = ECR_RCH_Mizar
         modelliECR_RCH(11) = ECR_RCH_Nucleo
         modelliECR_RCH(12) = ECR_RCH_NucleoGE
         modelliECR_RCH(13) = ECR_RCH_Onda
         modelliECR_RCH(14) = ECR_RCH_OndaSpot
         modelliECR_RCH(15) = ECR_RCH_PrintF_RS232_USB
         modelliECR_RCH(16) = ECR_RCH_PrintF_RETE_ETH
         modelliECR_RCH(17) = ECR_RCH_Swing
         modelliECR_RCH(18) = ECR_RCH_SwingECR65A
         modelliECR_RCH(19) = ECR_RCH_Till
         modelliECR_RCH(20) = ECR_RCH_TouchMe
         modelliECR_RCH(21) = ECR_RCH_XOnda

         ' Ricoh.
         marcheECR(29) = ECR_Ricoh
         modelliECR_Ricoh(0) = ECR_Ricoh_Logic

         ' Royal.
         marcheECR(30) = ECR_Royal
         modelliECR_Royal(0) = ECR_Royal_Dialog
         modelliECR_Royal(1) = ECR_Royal_Nettuna200
         modelliECR_Royal(2) = ECR_Royal_Nettuna500
         modelliECR_Royal(3) = ECR_Royal_PRT100
         modelliECR_Royal(4) = ECR_Royal_PRT100FX

         ' Sarema.
         marcheECR(31) = ECR_Sarema
         modelliECR_Sarema(0) = ECR_Sarema_Extra
         modelliECR_Sarema(1) = ECR_Sarema_Frontiera
         modelliECR_Sarema(2) = ECR_Sarema_FrontieraSx2
         modelliECR_Sarema(3) = ECR_Sarema_FrontieraSx3
         modelliECR_Sarema(4) = ECR_Sarema_Grillo
         modelliECR_Sarema(5) = ECR_Sarema_Grillo38
         modelliECR_Sarema(6) = ECR_Sarema_GrilloEJ
         modelliECR_Sarema(7) = ECR_Sarema_Jump
         modelliECR_Sarema(8) = ECR_Sarema_Record
         modelliECR_Sarema(9) = ECR_Sarema_RecordDS
         modelliECR_Sarema(10) = ECR_Sarema_RecordEJ
         modelliECR_Sarema(11) = ECR_Sarema_RecordGE
         modelliECR_Sarema(12) = ECR_Sarema_SR100
         modelliECR_Sarema(13) = ECR_Sarema_SR204
         modelliECR_Sarema(14) = ECR_Sarema_Style
         modelliECR_Sarema(15) = ECR_Sarema_StyleEJ
         modelliECR_Sarema(16) = ECR_Sarema_Xtx

         ' SHS.
         marcheECR(32) = ECR_SHS
         modelliECR_SHS(0) = ECR_SHS_SH2000EJ
         modelliECR_SHS(1) = ECR_SHS_SH401EJ
         modelliECR_SHS(2) = ECR_SHS_SH401EJLE
         modelliECR_SHS(3) = ECR_SHS_SH501EJ
         modelliECR_SHS(4) = ECR_SHS_SHSmarty

         ' Sico.
         marcheECR(33) = "Sico"
         modelliECR_Sico(0) = ECR_Sico_6000Top
         modelliECR_Sico(1) = ECR_Sico_ATHOM
         modelliECR_Sico(2) = ECR_Sico_Club
         modelliECR_Sico(3) = ECR_Sico_IdeaEJ
         modelliECR_Sico(4) = ECR_Sico_R338EJ
         modelliECR_Sico(5) = ECR_Sico_Universo
         modelliECR_Sico(6) = ECR_Sico_UniversoEJ

         ' Suprema.
         marcheECR(34) = ECR_Suprema
         modelliECR_Suprema(0) = ECR_Suprema_Mercury
         modelliECR_Suprema(1) = ECR_Suprema_Olimpo
         modelliECR_Suprema(2) = ECR_Suprema_Pulsar
         modelliECR_Suprema(3) = ECR_Suprema_PulsarEthernet
         modelliECR_Suprema(4) = ECR_Suprema_Sun

         ' Sweda.
         marcheECR(35) = ECR_Sweda
         modelliECR_Sweda(0) = ECR_Sweda_Gear
         modelliECR_Sweda(1) = ECR_Sweda_Labor
         modelliECR_Sweda(2) = ECR_Sweda_LaborDS
         modelliECR_Sweda(3) = ECR_Sweda_LaborEJ
         modelliECR_Sweda(4) = ECR_Sweda_LaborGE
         modelliECR_Sweda(5) = ECR_Sweda_MasterRS50
         modelliECR_Sweda(6) = ECR_Sweda_Mikropos
         modelliECR_Sweda(7) = ECR_Sweda_Mikropos2004
         modelliECR_Sweda(8) = ECR_Sweda_MikroposDS
         modelliECR_Sweda(9) = ECR_Sweda_MikroposEJ
         modelliECR_Sweda(10) = ECR_Sweda_MikroposGE
         modelliECR_Sweda(11) = ECR_Sweda_Modus
         modelliECR_Sweda(12) = ECR_Sweda_Point
         modelliECR_Sweda(13) = ECR_Sweda_SW204

         ' System Retail.
         marcheECR(36) = ECR_SystemRetail
         modelliECR_SystemRetail(0) = ECR_SystemRetail_SYS100
         modelliECR_SystemRetail(1) = ECR_SystemRetail_SYS200X
         modelliECR_SystemRetail(2) = ECR_SystemRetail_SYSTOUCHCENTO
         modelliECR_SystemRetail(3) = ECR_SystemRetail_SYSUNO
         modelliECR_SystemRetail(4) = ECR_SystemRetail_TIKEECR
         modelliECR_SystemRetail(5) = ECR_SystemRetail_TIKELANF
         modelliECR_SystemRetail(6) = ECR_SystemRetail_TIKESF
         modelliECR_SystemRetail(7) = ECR_SystemRetail_XTIKEECR
         modelliECR_SystemRetail(8) = ECR_SystemRetail_XTIKESF

         ' Underwood.
         marcheECR(37) = ECR_Underwood
         modelliECR_Underwood(0) = ECR_Underwood_Format
         modelliECR_Underwood(1) = ECR_Underwood_Nettuna200
         modelliECR_Underwood(2) = ECR_Underwood_Nettuna250
         modelliECR_Underwood(3) = ECR_Underwood_Nettuna300
         modelliECR_Underwood(4) = ECR_Underwood_Nettuna500
         modelliECR_Underwood(5) = ECR_Underwood_Open

         ' Vandoni.
         marcheECR(38) = ECR_Vandoni
         modelliECR_Vandoni(0) = ECR_Vandoni_SE200

         ' Vis Elettronica.
         marcheECR(39) = ECR_VisElettronica
         modelliECR_VisElettronica(0) = ECR_VisElettronica_12BT
         modelliECR_VisElettronica(1) = ECR_VisElettronica_EJ100
         modelliECR_VisElettronica(2) = ECR_VisElettronica_EJ100BT
         modelliECR_VisElettronica(3) = ECR_VisElettronica_EJ300
         modelliECR_VisElettronica(4) = ECR_VisElettronica_Graphics
         modelliECR_VisElettronica(5) = ECR_VisElettronica_GraphicsEJ
         modelliECR_VisElettronica(6) = ECR_VisElettronica_GraphicsGE
         modelliECR_VisElettronica(7) = ECR_VisElettronica_Millenium
         modelliECR_VisElettronica(8) = ECR_VisElettronica_ProgressEJ

         ' WincorNixdorf.
         marcheECR(40) = ECR_WincorNixdorf
         modelliECR_WincorNixdorf(0) = ECR_WincorNixdorf_ButterflyPlus
         modelliECR_WincorNixdorf(1) = ECR_WincorNixdorf_ER400Smart1
         modelliECR_WincorNixdorf(2) = ECR_WincorNixdorf_ER400Smart2
         modelliECR_WincorNixdorf(3) = ECR_WincorNixdorf_ER400Smart3
         modelliECR_WincorNixdorf(4) = ECR_WincorNixdorf_Executive
         modelliECR_WincorNixdorf(5) = ECR_WincorNixdorf_ExtremeBasic
         modelliECR_WincorNixdorf(6) = ECR_WincorNixdorf_ExtremeBasicPlus
         modelliECR_WincorNixdorf(7) = ECR_WincorNixdorf_ExtremeLite
         modelliECR_WincorNixdorf(8) = ECR_WincorNixdorf_Link
         modelliECR_WincorNixdorf(9) = ECR_WincorNixdorf_Opportunity
         modelliECR_WincorNixdorf(10) = ECR_WincorNixdorf_OpportunityEJ
         modelliECR_WincorNixdorf(11) = ECR_WincorNixdorf_OpportunityLite
         modelliECR_WincorNixdorf(12) = ECR_WincorNixdorf_Storm

         cmbStampanteProduttore.Items.Clear()
         cmbStampanteProduttore.Items.Add("<Nessuna>")

         Dim i As Integer
         For i = 0 To numMarcheECR - 1
            cmbStampanteProduttore.Items.Add(marcheECR(i))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub CaricaStampantiScontrini()
      Try
         Dim i As Integer = 0

         cmbStampanteScontrini.Items.Clear()
         cmbStampanteScontrini.Items.Add("<Nessuna>")

         ' ECR_3i
         For i = 0 To numModelliECR_3i - 1
            cmbStampanteScontrini.Items.Add(ECR_3i & " - " & modelliECR_3i(i))
         Next

         ' ECR_Asem
         i = 0
         For i = 0 To numModelliECR_Asem - 1
            cmbStampanteScontrini.Items.Add(ECR_Asem & " - " & modelliECR_Asem(i))
         Next

         ' ECR_Axon
         i = 0
         For i = 0 To numModelliECR_Axon - 1
            cmbStampanteScontrini.Items.Add(ECR_Axon & " - " & modelliECR_Axon(i))
         Next

         ' ECR_Buffetti
         i = 0
         For i = 0 To numModelliECR_Buffetti - 1
            cmbStampanteScontrini.Items.Add(ECR_Buffetti & " - " & modelliECR_Buffetti(i))
         Next

         ' ECR_Cei
         i = 0
         For i = 0 To numModelliECR_Cei - 1
            cmbStampanteScontrini.Items.Add(ECR_Cei & " - " & modelliECR_Cei(i))
         Next

         ' ECR_Coris
         i = 0
         For i = 0 To numModelliECR_Coris - 1
            cmbStampanteScontrini.Items.Add(ECR_Coris & " - " & modelliECR_Coris(i))
         Next

         ' ECR_Custom
         i = 0
         For i = 0 To numModelliECR_Custom - 1
            cmbStampanteScontrini.Items.Add(ECR_Custom & " - " & modelliECR_Custom(i))
         Next

         ' ECR_DataProcess
         i = 0
         For i = 0 To numModelliECR_DataProcess - 1
            cmbStampanteScontrini.Items.Add(ECR_DataProcess & " - " & modelliECR_DataProcess(i))
         Next

         ' ECR_DistributionSystem
         i = 0
         For i = 0 To numModelliECR_DistributionSystem - 1
            cmbStampanteScontrini.Items.Add(ECR_DistributionSystem & " - " & modelliECR_DistributionSystem(i))
         Next

         ' ECR_Ditron
         i = 0
         For i = 0 To numModelliECR_Ditron - 1
            cmbStampanteScontrini.Items.Add(ECR_Ditron & " - " & modelliECR_Ditron(i))
         Next

         ' ECR_DTR_Italia
         i = 0
         For i = 0 To numModelliECR_DTR_Italia - 1
            cmbStampanteScontrini.Items.Add(ECR_DTR_Italia & " - " & modelliECR_DTR_Italia(i))
         Next

         ' ECR_Elsi_Retail
         i = 0
         For i = 0 To numModelliECR_Elsi_Retail - 1
            cmbStampanteScontrini.Items.Add(ECR_Elsi_Retail & " - " & modelliECR_Elsi_Retail(i))
         Next

         ' ECR_EpmEdIt
         i = 0
         For i = 0 To numModelliECR_EpmEdIt - 1
            cmbStampanteScontrini.Items.Add(ECR_EpmEdIt & " - " & modelliECR_EpmEdIt(i))
         Next

         ' ECR_Epson
         i = 0
         For i = 0 To numModelliECR_Epson - 1
            cmbStampanteScontrini.Items.Add(ECR_Epson & " - " & modelliECR_Epson(i))
         Next

         ' ECR_Eurodata
         i = 0
         For i = 0 To numModelliECR_Eurodata - 1
            cmbStampanteScontrini.Items.Add(ECR_Eurodata & " - " & modelliECR_Eurodata(i))
         Next

         ' ECR_Fasy
         i = 0
         For i = 0 To numModelliECR_Fasy - 1
            cmbStampanteScontrini.Items.Add(ECR_Fasy & " - " & modelliECR_Fasy(i))
         Next

         ' ECR_Helmac
         i = 0
         For i = 0 To numModelliECR_Helmac - 1
            cmbStampanteScontrini.Items.Add(ECR_Helmac & " - " & modelliECR_Helmac(i))
         Next

         ' ECR_Hugin
         i = 0
         For i = 0 To numModelliECR_Hugin - 1
            cmbStampanteScontrini.Items.Add(ECR_Hugin & " - " & modelliECR_Hugin(i))
         Next

         ' ECR_I2_Idee_Italiane
         i = 0
         For i = 0 To numModelliECR_I2_Idee_Italiane - 1
            cmbStampanteScontrini.Items.Add(ECR_I2_Idee_Italiane & " - " & modelliECR_I2_Idee_Italiane(i))
         Next

         ' ECR_Ibm
         i = 0
         For i = 0 To numModelliECR_Ibm - 1
            cmbStampanteScontrini.Items.Add(ECR_Ibm & " - " & modelliECR_Ibm(i))
         Next

         ' ECR_Indesit_Ditron
         i = 0
         For i = 0 To numModelliECR_Indesit_Ditron - 1
            cmbStampanteScontrini.Items.Add(ECR_Indesit_Ditron & " - " & modelliECR_Indesit_Ditron(i))
         Next

         ' ECR_Italiana_Macchi
         i = 0
         For i = 0 To numModelliECR_Italiana_Macchi - 1
            cmbStampanteScontrini.Items.Add(ECR_Italiana_Macchi & " - " & modelliECR_Italiana_Macchi(i))
         Next

         ' ECR_Mct
         i = 0
         For i = 0 To numModelliECR_Mct - 1
            cmbStampanteScontrini.Items.Add(ECR_Mct & " - " & modelliECR_Mct(i))
         Next

         ' ECR_Micrelec
         i = 0
         For i = 0 To numModelliECR_Micrelec - 1
            cmbStampanteScontrini.Items.Add(ECR_Micrelec & " - " & modelliECR_Micrelec(i))
         Next

         ' ECR_Microrex
         i = 0
         For i = 0 To numModelliECR_Microrex - 1
            cmbStampanteScontrini.Items.Add(ECR_Microrex & " - " & modelliECR_Microrex(i))
         Next

         ' ECR_Ncr
         i = 0
         For i = 0 To numModelliECR_Ncr - 1
            cmbStampanteScontrini.Items.Add(ECR_Ncr & " - " & modelliECR_Ncr(i))
         Next

         ' ECR_OkCash
         i = 0
         For i = 0 To numModelliECR_OkCash - 1
            cmbStampanteScontrini.Items.Add(ECR_OkCash & " - " & modelliECR_OkCash(i))
         Next

         ' ECR_Olivetti
         i = 0
         For i = 0 To numModelliECR_Olivetti - 1
            cmbStampanteScontrini.Items.Add(ECR_Olivetti & " - " & modelliECR_Olivetti(i))
         Next

         ' ECR_RCH
         i = 0
         For i = 0 To numModelliECR_RCH - 1
            cmbStampanteScontrini.Items.Add(ECR_RCH & " - " & modelliECR_RCH(i))
         Next

         ' ECR_Ricoh
         i = 0
         For i = 0 To numModelliECR_Ricoh - 1
            cmbStampanteScontrini.Items.Add(ECR_Ricoh & " - " & modelliECR_Ricoh(i))
         Next

         ' ECR_Royal
         i = 0
         For i = 0 To numModelliECR_Royal - 1
            cmbStampanteScontrini.Items.Add(ECR_Royal & " - " & modelliECR_Royal(i))
         Next

         ' ECR_Sarema
         i = 0
         For i = 0 To numModelliECR_Sarema - 1
            cmbStampanteScontrini.Items.Add(ECR_Sarema & " - " & modelliECR_Sarema(i))
         Next

         ' ECR_SHS
         i = 0
         For i = 0 To numModelliECR_SHS - 1
            cmbStampanteScontrini.Items.Add(ECR_SHS & " - " & modelliECR_SHS(i))
         Next

         ' ECR_Sico
         i = 0
         For i = 0 To numModelliECR_Sico - 1
            cmbStampanteScontrini.Items.Add(ECR_Sico & " - " & modelliECR_Sico(i))
         Next

         ' ECR_Suprema
         i = 0
         For i = 0 To numModelliECR_Suprema - 1
            cmbStampanteScontrini.Items.Add(ECR_Suprema & " - " & modelliECR_Suprema(i))
         Next

         ' ECR_Sweda
         i = 0
         For i = 0 To numModelliECR_Sweda - 1
            cmbStampanteScontrini.Items.Add(ECR_Sweda & " - " & modelliECR_Sweda(i))
         Next
         ' ECR_SystemRetail
         i = 0
         For i = 0 To numModelliECR_SystemRetail - 1
            cmbStampanteScontrini.Items.Add(ECR_SystemRetail & " - " & modelliECR_SystemRetail(i))
         Next

         ' ECR_Underwood
         i = 0
         For i = 0 To numModelliECR_Underwood - 1
            cmbStampanteScontrini.Items.Add(ECR_Underwood & " - " & modelliECR_Underwood(i))
         Next

         ' ECR_Vandoni
         i = 0
         For i = 0 To numModelliECR_Vandoni - 1
            cmbStampanteScontrini.Items.Add(ECR_Vandoni & " - " & modelliECR_Vandoni(i))
         Next

         ' ECR_VisElettronica
         i = 0
         For i = 0 To numModelliECR_VisElettronica - 1
            cmbStampanteScontrini.Items.Add(ECR_VisElettronica & " - " & modelliECR_VisElettronica(i))
         Next

         ' ECR_WincorNixdorf
         i = 0
         For i = 0 To numModelliECR_WincorNixdorf - 1
            cmbStampanteScontrini.Items.Add(ECR_WincorNixdorf & " - " & modelliECR_WincorNixdorf(i))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Function ApriArchivio() As String
      Try
         OpenFileDialog1.Filter = "Microsoft Database Access (.mdb)|*.mdb"

         OpenFileDialog1.FilterIndex = 1

         If (OpenFileDialog1.ShowDialog() = DialogResult.OK) Then
            ' Nome dell'archivio i uso completo di percorso.
            Return OpenFileDialog1.FileName()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ChDir(Application.StartupPath)

      End Try
   End Function

   Private Function SalvaArchivio() As String
      Try
         SaveFileDialog1.Filter = "Microsoft Database Access (.mdb)|*.mdb"

         SaveFileDialog1.FilterIndex = 1

         If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            ' Nome dell'archivio i uso completo di percorso.
            Return SaveFileDialog1.FileName()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ChDir(Application.StartupPath)

      End Try
   End Function

   Private Function ApriPercorso() As String
      Try
         SaveFileDialog1.Filter = "File di testo (.txt)|*.txt"

         SaveFileDialog1.FilterIndex = 1

         SaveFileDialog1.FileName = "File.txt"

         If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            Return RestituisciPercorsoDirectory(SaveFileDialog1.FileName, "File.txt")
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ChDir(Application.StartupPath)

      End Try
   End Function

   Private Function ApriPercorsoRecovery() As String
      Try
         SaveFileDialog1.Filter = "File di testo (.txt)|*.txt"

         SaveFileDialog1.FilterIndex = 1

         SaveFileDialog1.FileName = "File.txt"

         If (SaveFileDialog1.ShowDialog() = DialogResult.OK) Then
            Return RestituisciPercorsoDirectory(SaveFileDialog1.FileName, "File.txt")
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ChDir(Application.StartupPath)

      End Try
   End Function

   Public Sub CaricaListaReports(ByVal cmb As ComboBox)
      Try
         Dim documenti(NUMERO_DOC) As String

         documenti(0) = REPORT_RICEVUTA_A4_DOPPIA
         documenti(1) = REPORT_RICEVUTA_A5
         documenti(2) = REPORT_RICEVUTA_A6
         documenti(3) = REPORT_FATTURA_A4_DOPPIA
         documenti(4) = REPORT_FATTURA_A4
         documenti(5) = REPORT_FATTURA_A4_IVA_MULTIPLA
         documenti(6) = REPORT_PROFORMA_A4_DOPPIA
         documenti(7) = REPORT_PROFORMA_A5
         documenti(8) = REPORT_PROFORMA_A6
         documenti(9) = REPORT_COMANDA_REPARTI
         documenti(10) = REPORT_COMANDA_CLIENTI
         documenti(11) = REPORT_COMANDA_REPARTI_KUBEII
         documenti(12) = REPORT_COMANDA_CLIENTI_KUBEII
         documenti(13) = REPORT_RICEVUTA_BELLA_NAPOLI
         documenti(14) = REPORT_FATTURA_BELLA_NAPOLI
         documenti(15) = REPORT_PROFORMA_BELLA_NAPOLI
         documenti(16) = REPORT_PROFORMA_KUBEII
         documenti(17) = REPORT_RICEVUTA_A4_DOPPIA_CENTRO_SPORTIVO
         documenti(18) = REPORT_FATTURA_A4_DOPPIA_CENTRO_SPORTIVO
         documenti(19) = REPORT_PROFORMA_A4_DOPPIA_CENTRO_SPORTIVO
         documenti(20) = REPORT_RICEVUTA_CELIDE
         documenti(21) = REPORT_FATTURA_CELIDE
         documenti(22) = REPORT_PROFORMA_CELIDE
         documenti(23) = REPORT_RICEVUTA_FORCHETTA_DORO
         documenti(24) = REPORT_FATTURA_FORCHETTA_DORO
         documenti(25) = REPORT_PROFORMA_FORCHETTA_DORO
         'documenti(26) = REPORT_RICEVUTA_KUBEII
         'documenti(27) = REPORT_FATTURA_KUBEII

         Dim i As Integer
         For i = 0 To NUMERO_DOC
            cmb.Items.Add(documenti(i))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiPercorsi()
      Try
         ' Comande.
         PercorsiStampantiComande(0) = cmbReparto1.Text & ";" & cmbStampanteComanda1.Text & ";" & cmbReportComanda1.Text
         PercorsiStampantiComande(1) = cmbReparto2.Text & ";" & cmbStampanteComanda2.Text & ";" & cmbReportComanda2.Text
         PercorsiStampantiComande(2) = cmbReparto3.Text & ";" & cmbStampanteComanda3.Text & ";" & cmbReportComanda3.Text
         PercorsiStampantiComande(3) = cmbReparto4.Text & ";" & cmbStampanteComanda4.Text & ";" & cmbReportComanda4.Text
         PercorsiStampantiComande(4) = cmbReparto5.Text & ";" & cmbStampanteComanda5.Text & ";" & cmbReportComanda5.Text
         PercorsiStampantiComande(5) = cmbReparto6.Text & ";" & cmbStampanteComanda6.Text & ";" & cmbReportComanda6.Text
         PercorsiStampantiComande(6) = cmbReparto7.Text & ";" & cmbStampanteComanda7.Text & ";" & cmbReportComanda7.Text
         PercorsiStampantiComande(7) = cmbReparto8.Text & ";" & cmbStampanteComanda8.Text & ";" & cmbReportComanda8.Text
         PercorsiStampantiComande(8) = cmbReparto9.Text & ";" & cmbStampanteComanda9.Text & ";" & cmbReportComanda9.Text
         PercorsiStampantiComande(9) = cmbReparto10.Text & ";" & cmbStampanteComanda10.Text & ";" & cmbReportComanda10.Text
         PercorsiStampantiComande(10) = "Agg" & ";" & cmbStampanteComandaAgg.Text & ";" & cmbReportComandaAgg.Text

         ' Documenti.
         PercorsiStampantiDocumenti(0) = "RICEVUTA" & ";" & cmbStampanteRicevute.Text & ";" & cmbReportRicevute.Text
         PercorsiStampantiDocumenti(1) = "FATTURA" & ";" & cmbStampanteFatture.Text & ";" & cmbReportFatture.Text
         PercorsiStampantiDocumenti(2) = "PROFORMA" & ";" & cmbStampanteProforma.Text & ";" & cmbReportProforma.Text
         PercorsiStampantiDocumenti(3) = "SCONTRINO" & ";" & cmbStampanteScontrini.Text & ";" & cmbReportScontrini.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SalvaDatiStampantiFiscali()
      Try
         ' Comande.
         ProduttoreSF = cmbStampanteProduttore.Text
         ModelloSF = cmbStampanteModello.Text

         ' RCH Swing ECR 65/A
         PortaSF = cmbStampantePorta.Text
         ParametriSF = txtStampanteParametri.Text
         NomeScontrinoSF = txtNomeScontrino.Text
         PercorsoOutputSF = txtPercorsoOutput.Text
         PercorsoDriverSF = txtPercorsoDriver.Text

         ' Driver RTS WPOS1.
         PercorsoDriverWpos1 = txtPercorsoDriverWPOS1.Text
         PercorsoLavoroWpos1 = txtPercorsoWpos1.Text
         PwdDriverWpos1 = txtPasswordWpos1.Text
         EstensioneFileWpos1 = txtEstensioneFileWpos1.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmOpzioni_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Impostazioni per il modulo Prenotazioni On-line (www.tavoloso.it).
         If moduloAttivo.PrenOnLine = True Then
            gbPrenOnLine.Enabled = True
         Else
            gbPrenOnLine.Enabled = False
         End If

         ' Impostazioni per il modulo Palmari.
         If moduloAttivo.Palmari = True Then
            txtPercorsoRetePalmare.Enabled = True
            cmdApriPercorsoPalmare.Enabled = True
            cmbFreqAggPalmare.Enabled = True
            chkAbilitaPalmareWindows.Enabled = True
            chkAbilitaPalmareAndroid.Enabled = True

            ' Imposta i secondi a 15.
            cmbFreqAggPalmare.SelectedIndex = 2
         Else
            txtPercorsoRetePalmare.Enabled = False
            cmdApriPercorsoPalmare.Enabled = False
            cmbFreqAggPalmare.Enabled = False
            chkAbilitaPalmareWindows.Enabled = False
            chkAbilitaPalmareAndroid.Enabled = False
         End If

         ' Impostazioni per il modulo PenDriveRecovery.
         If moduloAttivo.PenDriveRecovery = True Then
            chkAttivaRecovery.Enabled = True
            txtPercorsoRecovery.Enabled = True
            cmdApriPercorsoRecovery.Enabled = True
         Else
            chkAttivaRecovery.Enabled = False
            txtPercorsoRecovery.Enabled = False
            cmdApriPercorsoRecovery.Enabled = False
         End If

         ' Impostazioni per il modulo Registratori di cassa.
         If moduloAttivo.RegCassa = True Then
            cmbStampanteProduttore.Enabled = True
            cmbStampanteModello.Enabled = True
            grbSwing.Enabled = True
            grbWpos.Enabled = True

            CaricaMarcheECR()
            CaricaStampantiScontrini()

         Else
            cmbStampanteProduttore.Enabled = False
            cmbStampanteModello.Enabled = False
            grbSwing.Enabled = False
            grbWpos.Enabled = False

            cmbStampanteScontrini.Items.Clear()
            cmbStampanteScontrini.Items.Add("<Nessuna>")
            cmbStampanteScontrini.SelectedIndex = 0
         End If

         ' Reparti.
         CaricaListaReparti(cmbReparto1, "Reparti")
         CaricaListaReparti(cmbReparto2, "Reparti")
         CaricaListaReparti(cmbReparto3, "Reparti")
         CaricaListaReparti(cmbReparto4, "Reparti")
         CaricaListaReparti(cmbReparto5, "Reparti")
         CaricaListaReparti(cmbReparto6, "Reparti")
         CaricaListaReparti(cmbReparto7, "Reparti")
         CaricaListaReparti(cmbReparto8, "Reparti")
         CaricaListaReparti(cmbReparto9, "Reparti")
         CaricaListaReparti(cmbReparto10, "Reparti")

         ' Stampanti.
         CaricaListaStampanti(cmbStampanteComanda1)
         CaricaListaStampanti(cmbStampanteComanda2)
         CaricaListaStampanti(cmbStampanteComanda3)
         CaricaListaStampanti(cmbStampanteComanda4)
         CaricaListaStampanti(cmbStampanteComanda5)
         CaricaListaStampanti(cmbStampanteComanda6)
         CaricaListaStampanti(cmbStampanteComanda7)
         CaricaListaStampanti(cmbStampanteComanda8)
         CaricaListaStampanti(cmbStampanteComanda9)
         CaricaListaStampanti(cmbStampanteComanda10)
         CaricaListaStampanti(cmbStampanteComandaAgg)
         CaricaListaStampanti(cmbStampanteRicevute)
         CaricaListaStampanti(cmbStampanteFatture)
         CaricaListaStampanti(cmbStampanteProforma)

         ' Report.
         CaricaListaReports(cmbReportComanda1)
         CaricaListaReports(cmbReportComanda2)
         CaricaListaReports(cmbReportComanda3)
         CaricaListaReports(cmbReportComanda4)
         CaricaListaReports(cmbReportComanda5)
         CaricaListaReports(cmbReportComanda6)
         CaricaListaReports(cmbReportComanda7)
         CaricaListaReports(cmbReportComanda8)
         CaricaListaReports(cmbReportComanda9)
         CaricaListaReports(cmbReportComanda10)
         CaricaListaReports(cmbReportComandaAgg)
         CaricaListaReports(cmbReportRicevute)
         CaricaListaReports(cmbReportFatture)
         CaricaListaReports(cmbReportProforma)

         LeggiDatiConfig()

         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_OPZIONI, MODULO_OPZIONI)

         ' Visualizza un messaggio nella barra di stato.
         g_frmMain.eui_Informazioni.Text = g_frmMain.LeggiDatiRivenditore()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmOpzioni_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed
      If Me.Tag <> "0" Then
         ' Registra loperazione effettuata dall'operatore identificato.
         g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_OPZIONI)
      End If
   End Sub

   Private Sub cmdAnnulla_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAnnulla.Click
      ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
      Me.Tag = "0"

      ' Chiude la finestra.
      Me.Close()

      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Annulla, String.Empty, MODULO_OPZIONI)
   End Sub

   Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
      ' Messaggio sulla barra di stato.
      g_frmMain.eui_Informazioni.Text = "Salvataggio impostazioni in corso..."

      ' Nasconde il form.
      Me.Hide()

      Application.DoEvents()
      Me.Refresh()

      ' Effettua le impostazioni necessarie per l'archivio.
      PercorsoDB = txtPercorsoDB.Text
      PercorsoDBClienti = txtPercorsoDBClienti.Text

      ImpostaArchivio(g_frmMain.eui_cmdArchivio)
      ImpostaArchivioClienti()

      SalvaDatiPercorsi()

      SalvaDatiStampantiFiscali()

      SalvaDatiConfig()

      ' Attiva / Disattiva la ricezione delle prenotazioni da internet. (www.tavoloso.it)
      g_frmMain.Timer2.Enabled = AbilitaRicezionePren

      ' Serve a registrare l'operazione ANNULLA nell'evento Closed.
      Me.Tag = "0"

      If WebCommunication.VerificaConnessione = True Then
         g_frmMain.CreaFileAnagrafiche(AbilitaPalmareWindows, AbilitaPalmareAndroid)
         g_frmMain.CreaFileStatoTavoli(AbilitaPalmareWindows, AbilitaPalmareAndroid)
         g_frmMain.CreaFileSQLiteComande(AbilitaPalmareAndroid)
      End If

      ' Chiude la finestra.
      Me.Close()

      g_frmMain.RegistraOperazione(TipoOperazione.Salva, String.Empty, MODULO_OPZIONI)

      ' Messaggio sulla barra di stato.
      g_frmMain.eui_Informazioni.Text = g_frmMain.LeggiDatiRivenditore()
   End Sub

   Private Sub cmdApriDB1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApriDB1.Click
      txtPercorsoDB.Text = ApriArchivio()
   End Sub

   Private Sub cmdApriDB2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApriDB2.Click
      txtPercorsoDBClienti.Text = ApriArchivio()
   End Sub

   Private Sub cmdApriBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApriBackup.Click
      txtPercorsoBackup.Text = SalvaArchivio()
   End Sub

   Private Sub cmdApriPercorsoPalmare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdApriPercorsoPalmare.Click
      txtPercorsoRetePalmare.Text = ApriPercorso()
   End Sub

   Private Sub cmdApriPercorsoRecovery_Click(sender As System.Object, e As System.EventArgs) Handles cmdApriPercorsoRecovery.Click
      txtPercorsoRecovery.Text = ApriPercorsoRecovery()
   End Sub

   Private Sub chkAbilitaPalmareAndroid_Click(sender As Object, e As EventArgs) Handles chkAbilitaPalmareAndroid.Click
      ' Se viene abilitata la gestione dei palmari richiede l'iserimento di un percorso di rete. 
      If chkAbilitaPalmareAndroid.Checked = True And txtPercorsoRetePalmare.Text = "" Then
         MessageBox.Show("Se si abilita la gestione dei palmari è necessario specificare un percorso di lavoro per lo scambio dei dati." & vbCrLf &
                         "In caso contrario i dispositivi palmari non potranno inviare e ricevere informazioni.",
                         NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         txtPercorsoRetePalmare.Focus()
      End If

      If chkAbilitaPalmareWindows.Checked = True Or chkAbilitaPalmareAndroid.Checked = True Then
         cmdAggiornaFilePalmare.Enabled = True
      Else
         cmdAggiornaFilePalmare.Enabled = False
      End If

      If chkAbilitaPalmareAndroid.Checked = True Then
         AbilitaPalmareAndroid = True
      Else
         AbilitaPalmareAndroid = False
      End If
   End Sub

   Private Sub chkAbilitaPalmareWindows_Click(sender As Object, e As EventArgs) Handles chkAbilitaPalmareWindows.Click
      ' Se viene abilitata la gestione dei palmari richiede l'iserimento di un percorso di rete. 
      If chkAbilitaPalmareWindows.Checked = True And txtPercorsoRetePalmare.Text = "" Then
         MessageBox.Show("Se si abilita la gestione dei palmari è necessario specificare un percorso di lavoro per lo scambio dei dati." & vbCrLf &
                         "In caso contrario i dispositivi palmari non potranno inviare e ricevere informazioni.",
                         NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

         txtPercorsoRetePalmare.Focus()
      End If

      If chkAbilitaPalmareWindows.Checked = True Or chkAbilitaPalmareAndroid.Checked = True Then
         cmdAggiornaFilePalmare.Enabled = True
      Else
         cmdAggiornaFilePalmare.Enabled = False
      End If

      If chkAbilitaPalmareWindows.Checked = True Then
         AbilitaPalmareWindows = True
      Else
         AbilitaPalmareWindows = False
      End If

      If chkAbilitaPalmareAndroid.Checked = True Then
         AbilitaPalmareAndroid = True
      Else
         AbilitaPalmareAndroid = False
      End If

   End Sub

   Private Sub cmdAggiornaFilePalmare_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAggiornaFilePalmare.Click
      Try
         If WebCommunication.VerificaConnessione = True Then
            g_frmMain.CreaFileAnagrafiche(AbilitaPalmareWindows, AbilitaPalmareAndroid)

            MessageBox.Show("L'aggiornamento del file è stato effettuato con successo! Per caricare tutti i dati sul palmare è necessario eseguire il comando di sincronizzazione sul software del dispositivo.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         Else
            MessageBox.Show("Connessione di rete non disponibile! Stabilire una connessione e riprovare con l'operazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdPercorsoOutput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPercorsoOutput.Click
      txtPercorsoOutput.Text = ApriPercorso()
   End Sub

   Private Sub cmdPercorsoDriver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPercorsoDriver.Click
      txtPercorsoDriver.Text = ApriPercorso()
   End Sub

   Private Sub chkAttivaRecovery_Click(sender As Object, e As System.EventArgs) Handles chkAttivaRecovery.Click
      If chkAttivaRecovery.Checked = True Then
         lblPercorsoRecovery.Enabled = True
         txtPercorsoRecovery.Enabled = True
         cmdApriPercorsoRecovery.Enabled = True
      Else
         lblPercorsoRecovery.Enabled = False
         txtPercorsoRecovery.Enabled = False
         cmdApriPercorsoRecovery.Enabled = False
      End If
   End Sub

   Private Sub tabOpzioni_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles tabOpzioni.SelectedIndexChanged
      Try
         Select Case tabOpzioni.SelectedIndex()
            Case 0
               ' Imposta lo stato attivo.
               cmbFormatoFatt.Focus()

            Case 1
               ' Imposta lo stato attivo.
               cmbReparto1.Focus()

            Case 2
               ' Imposta lo stato attivo.
               txtPercorsoRetePalmare.Focus()

            Case 3
               cmbStampanteProduttore.Focus()

            Case 4
               ' Imposta lo stato attivo.
               chkAttivaRecovery.Focus()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub cmbStampanteProduttore_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbStampanteProduttore.SelectedIndexChanged
      Try
         cmbStampanteModello.Items.Clear()

         Select Case cmbStampanteProduttore.Text
            Case "<Nessuna>"
               cmbStampanteModello.Items.Add("<Nessuno>")

            Case ECR_3i
               Dim i As Integer
               For i = 0 To numModelliECR_3i - 1
                  cmbStampanteModello.Items.Add(modelliECR_3i(i))
               Next

            Case ECR_Asem
               Dim i As Integer
               For i = 0 To numModelliECR_Asem - 1
                  cmbStampanteModello.Items.Add(modelliECR_Asem(i))
               Next

            Case ECR_Axon
               Dim i As Integer
               For i = 0 To numModelliECR_Axon - 1
                  cmbStampanteModello.Items.Add(modelliECR_Axon(i))
               Next

            Case ECR_Buffetti
               Dim i As Integer
               For i = 0 To numModelliECR_Buffetti - 1
                  cmbStampanteModello.Items.Add(modelliECR_Buffetti(i))
               Next

            Case ECR_Cei
               Dim i As Integer
               For i = 0 To numModelliECR_Cei - 1
                  cmbStampanteModello.Items.Add(modelliECR_Cei(i))
               Next

            Case ECR_Coris
               Dim i As Integer
               For i = 0 To numModelliECR_Coris - 1
                  cmbStampanteModello.Items.Add(modelliECR_Coris(i))
               Next

            Case ECR_Custom
               Dim i As Integer
               For i = 0 To numModelliECR_Custom - 1
                  cmbStampanteModello.Items.Add(modelliECR_Custom(i))
               Next

            Case ECR_DataProcess
               Dim i As Integer
               For i = 0 To numModelliECR_DataProcess - 1
                  cmbStampanteModello.Items.Add(modelliECR_DataProcess(i))
               Next

            Case ECR_DistributionSystem
               Dim i As Integer
               For i = 0 To numModelliECR_DistributionSystem - 1
                  cmbStampanteModello.Items.Add(modelliECR_DistributionSystem(i))
               Next

            Case ECR_Ditron
               Dim i As Integer
               For i = 0 To numModelliECR_Ditron - 1
                  cmbStampanteModello.Items.Add(modelliECR_Ditron(i))
               Next

            Case ECR_DTR_Italia
               Dim i As Integer
               For i = 0 To numModelliECR_DTR_Italia - 1
                  cmbStampanteModello.Items.Add(modelliECR_DTR_Italia(i))
               Next

            Case ECR_Elsi_Retail
               Dim i As Integer
               For i = 0 To numModelliECR_Elsi_Retail - 1
                  cmbStampanteModello.Items.Add(modelliECR_Elsi_Retail(i))
               Next

            Case ECR_EpmEdIt
               Dim i As Integer
               For i = 0 To numModelliECR_EpmEdIt - 1
                  cmbStampanteModello.Items.Add(modelliECR_EpmEdIt(i))
               Next

            Case ECR_Epson
               Dim i As Integer
               For i = 0 To numModelliECR_Epson - 1
                  cmbStampanteModello.Items.Add(modelliECR_Epson(i))
               Next

            Case ECR_Eurodata
               Dim i As Integer
               For i = 0 To numModelliECR_Eurodata - 1
                  cmbStampanteModello.Items.Add(modelliECR_Eurodata(i))
               Next

            Case ECR_Fasy
               Dim i As Integer
               For i = 0 To numModelliECR_Fasy - 1
                  cmbStampanteModello.Items.Add(modelliECR_Fasy(i))
               Next

            Case ECR_Helmac
               Dim i As Integer
               For i = 0 To numModelliECR_Helmac - 1
                  cmbStampanteModello.Items.Add(modelliECR_Helmac(i))
               Next

            Case ECR_Hugin
               Dim i As Integer
               For i = 0 To numModelliECR_Hugin - 1
                  cmbStampanteModello.Items.Add(modelliECR_Hugin(i))
               Next

            Case ECR_I2_Idee_Italiane
               Dim i As Integer
               For i = 0 To numModelliECR_I2_Idee_Italiane - 1
                  cmbStampanteModello.Items.Add(modelliECR_I2_Idee_Italiane(i))
               Next

            Case ECR_Ibm
               Dim i As Integer
               For i = 0 To numModelliECR_Ibm - 1
                  cmbStampanteModello.Items.Add(modelliECR_Ibm(i))
               Next

            Case ECR_Indesit_Ditron
               Dim i As Integer
               For i = 0 To numModelliECR_Indesit_Ditron - 1
                  cmbStampanteModello.Items.Add(modelliECR_Indesit_Ditron(i))
               Next

            Case ECR_Italiana_Macchi
               Dim i As Integer
               For i = 0 To numModelliECR_Italiana_Macchi - 1
                  cmbStampanteModello.Items.Add(modelliECR_Italiana_Macchi(i))
               Next

            Case ECR_Mct
               Dim i As Integer
               For i = 0 To numModelliECR_Mct - 1
                  cmbStampanteModello.Items.Add(modelliECR_Mct(i))
               Next

            Case ECR_Micrelec
               Dim i As Integer
               For i = 0 To numModelliECR_Micrelec - 1
                  cmbStampanteModello.Items.Add(modelliECR_Micrelec(i))
               Next

            Case ECR_Microrex
               Dim i As Integer
               For i = 0 To numModelliECR_Microrex - 1
                  cmbStampanteModello.Items.Add(modelliECR_Microrex(i))
               Next

            Case ECR_Ncr
               Dim i As Integer
               For i = 0 To numModelliECR_Ncr - 1
                  cmbStampanteModello.Items.Add(modelliECR_Ncr(i))
               Next

            Case ECR_OkCash
               Dim i As Integer
               For i = 0 To numModelliECR_OkCash - 1
                  cmbStampanteModello.Items.Add(modelliECR_OkCash(i))
               Next

            Case ECR_Olivetti
               Dim i As Integer
               For i = 0 To numModelliECR_Olivetti - 1
                  cmbStampanteModello.Items.Add(modelliECR_Olivetti(i))
               Next

            Case ECR_RCH
               Dim i As Integer
               For i = 0 To numModelliECR_RCH - 1
                  cmbStampanteModello.Items.Add(modelliECR_RCH(i))
               Next

            Case ECR_Ricoh
               Dim i As Integer
               For i = 0 To numModelliECR_Ricoh - 1
                  cmbStampanteModello.Items.Add(modelliECR_Ricoh(i))
               Next

            Case ECR_Royal
               Dim i As Integer
               For i = 0 To numModelliECR_Royal - 1
                  cmbStampanteModello.Items.Add(modelliECR_Royal(i))
               Next

            Case ECR_Sarema
               Dim i As Integer
               For i = 0 To numModelliECR_Sarema - 1
                  cmbStampanteModello.Items.Add(modelliECR_Sarema(i))
               Next

            Case ECR_SHS
               Dim i As Integer
               For i = 0 To numModelliECR_SHS - 1
                  cmbStampanteModello.Items.Add(modelliECR_SHS(i))
               Next

            Case ECR_Sico
               Dim i As Integer
               For i = 0 To numModelliECR_Sico - 1
                  cmbStampanteModello.Items.Add(modelliECR_Sico(i))
               Next

            Case ECR_Suprema
               Dim i As Integer
               For i = 0 To numModelliECR_Suprema - 1
                  cmbStampanteModello.Items.Add(modelliECR_Suprema(i))
               Next

            Case ECR_Sweda
               Dim i As Integer
               For i = 0 To numModelliECR_Sweda - 1
                  cmbStampanteModello.Items.Add(modelliECR_Sweda(i))
               Next

            Case ECR_SystemRetail
               Dim i As Integer
               For i = 0 To numModelliECR_SystemRetail - 1
                  cmbStampanteModello.Items.Add(modelliECR_SystemRetail(i))
               Next

            Case ECR_SystemRetail
               Dim i As Integer
               For i = 0 To numModelliECR_SystemRetail - 1
                  cmbStampanteModello.Items.Add(modelliECR_SystemRetail(i))
               Next

            Case ECR_Underwood
               Dim i As Integer
               For i = 0 To numModelliECR_Underwood - 1
                  cmbStampanteModello.Items.Add(modelliECR_Underwood(i))
               Next

            Case ECR_Vandoni
               Dim i As Integer
               For i = 0 To numModelliECR_Vandoni - 1
                  cmbStampanteModello.Items.Add(modelliECR_Vandoni(i))
               Next

            Case ECR_VisElettronica
               Dim i As Integer
               For i = 0 To numModelliECR_VisElettronica - 1
                  cmbStampanteModello.Items.Add(modelliECR_VisElettronica(i))
               Next

            Case ECR_WincorNixdorf
               Dim i As Integer
               For i = 0 To numModelliECR_WincorNixdorf - 1
                  cmbStampanteModello.Items.Add(modelliECR_WincorNixdorf(i))
               Next
         End Select

         cmbStampanteModello.SelectedIndex = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmbStampanteModello_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbStampanteModello.SelectedIndexChanged
      If cmbStampanteModello.Text = ECR_RCH_SwingECR65A Then
         grbWpos.Visible = False
         grbSwing.Visible = True
      Else
         grbWpos.Visible = True
         grbSwing.Visible = False
      End If
   End Sub

   Private Sub cmdPercorsoWpos1_Click(sender As System.Object, e As System.EventArgs) Handles cmdPercorsoWpos1.Click
      txtPercorsoWpos1.Text = ApriPercorso()
   End Sub

   Private Sub cmdPercorsoDriverWPOS1_Click(sender As System.Object, e As System.EventArgs) Handles cmdPercorsoDriverWPOS1.Click
      txtPercorsoDriverWPOS1.Text = ApriPercorso()
   End Sub

   Private Sub cmdAvviaWpos1_Click(sender As System.Object, e As System.EventArgs) Handles cmdAvviaWpos1.Click
      Try
         Dim NomeApp As String = "wppos1.exe"
         Dim Percorso As String = txtPercorsoDriverWPOS1.Text & NomeApp
         Dim Proc As New Process

         If File.Exists(Percorso) = True Then
            ' Avvia l'applicazione.
            Proc.StartInfo.FileName = Percorso
            Proc.StartInfo.Arguments = ""
            Proc.StartInfo.ErrorDialog = True
            Proc.StartInfo.ErrorDialogParentHandle = Me.Handle
            Proc.StartInfo.UseShellExecute = True
            Proc.Start()
         Else
            MessageBox.Show("Il file è inesistente! Verificare che sia stato installato il driver e che sia stato specificato il percorso.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub txtEstensioneFileWpos1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtEstensioneFileWpos1.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtCopertoRistorante_LostFocus(sender As Object, e As System.EventArgs) Handles txtCopertoRistorante.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

      'txtCopertoRistorante.Text = CFormatta.FormattaEuro(txtCopertoRistorante.Text)
   End Sub

   Private Sub txtCopertoRistorante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCopertoRistorante.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtServizioRistorante_LostFocus(sender As Object, e As System.EventArgs) Handles txtServizioRistorante.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

      'txtServizioRistorante.Text = CFormatta.FormattaEuro(txtServizioRistorante.Text)
   End Sub

   Private Sub txtServizioRistorante_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtServizioRistorante.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtAliquotaIva1_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAliquotaIva1.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtAliquotaIva2_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAliquotaIva2.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtAliquotaIva3_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAliquotaIva3.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtAliquotaIva4_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAliquotaIva4.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub cmdPercorsoFileTavAgent_Click(sender As System.Object, e As System.EventArgs) Handles cmdPercorsoFileTavAgent.Click
      txtPercorsoFileTavAgent.Text = ApriPercorso()
   End Sub

   Private Sub cmdPercorsoCartellaTavAgent_Click(sender As System.Object, e As System.EventArgs) Handles cmdPercorsoCartellaTavAgent.Click
      txtPercorsoCartellaTavAgent.Text = ApriPercorso()
   End Sub

   Private Sub AvviaTavolosoAgent(ByVal val As String)
      Try
         Dim NomeApp As String = "TavolosoAgent.exe"
         Dim Percorso As String = txtPercorsoFileTavAgent.Text & NomeApp
         Dim Proc As New Process

         If File.Exists(Percorso) = True Then
            ' Avvia l'applicazione.
            Proc.StartInfo.FileName = Percorso
            Proc.StartInfo.Arguments = val
            Proc.StartInfo.ErrorDialog = True
            Proc.StartInfo.ErrorDialogParentHandle = Me.Handle
            Proc.StartInfo.UseShellExecute = True
            Proc.Start()

            MessageBox.Show("TavolosoAgent è stato avviato. Per aprirlo andare nell'area di notifica della barra delle applicazioni e cliccare sull'icona del programma.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Else
            MessageBox.Show("Il file è inesistente! Verificare che sia stato installato il programma TavolosoAgent e che sia stato specificato il percorso.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub cmdAvviaTavAgent_Click(sender As System.Object, e As System.EventArgs) Handles cmdAvviaTavAgent.Click
      ' Avvia il programma TavolosoAgent.
      AvviaTavolosoAgent("")
   End Sub

   Private Sub cmdImpostazioniTavAgent_Click(sender As System.Object, e As System.EventArgs) Handles cmdImpostazioniTavAgent.Click
      ' Avvia il programma TavolosoAgent in modalità configurazione.
      AvviaTavolosoAgent("config")
   End Sub

   Private Sub ModificaColore()
      Try
         With ColorDialog1()
            .Color = cmdColorePrenTavAgent.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColorePrenTavAgent.BackColor = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub cmdColorePrenTavAgent_Click(sender As System.Object, e As System.EventArgs) Handles cmdColorePrenTavAgent.Click
      ModificaColore()
   End Sub

   Private Sub cmdApriPercorsoAmica_Click(sender As System.Object, e As System.EventArgs) Handles cmdApriPercorsoAmica.Click
      txtPercorsoAmica.Text = ApriPercorso()
   End Sub

   Private Sub chkNumeroFattura_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkNumeroFattura.CheckedChanged
      Try
         txtNumeroFattura.Enabled = chkNumeroFattura.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub chkNumeroRicevuta_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkNumeroRicevuta.CheckedChanged
      Try
         txtNumeroRicevuta.Enabled = chkNumeroRicevuta.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtNumeroFattura_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroFattura.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtNumeroRicevuta_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroRicevuta.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtTassaSoggiorno_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtTassaSoggiorno.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtTassaSoggiorno_LostFocus(sender As Object, e As System.EventArgs) Handles txtTassaSoggiorno.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtServizioCamere_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtServizioCamere.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)
   End Sub

   Private Sub txtServizioCamere_LostFocus(sender As Object, e As System.EventArgs) Handles txtServizioCamere.LostFocus
      Try
         If IsNumeric(sender.Text) Then
            sender.Text = CFormatta.FormattaEuro(Convert.ToDecimal(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub txtNumeroSchedinaPS_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroSchedinaPS.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub txtNumeroModC59_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumeroModC59.KeyPress
      e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)
   End Sub

   Private Sub ckbNumeroSchedinaPS_CheckedChanged(sender As Object, e As EventArgs) Handles ckbNumeroSchedinaPS.CheckedChanged
      Try
         txtNumeroSchedinaPS.Enabled = ckbNumeroSchedinaPS.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ckbNumeroModC59_CheckedChanged(sender As Object, e As EventArgs) Handles ckbNumeroModC59.CheckedChanged
      Try
         txtNumeroModC59.Enabled = ckbNumeroModC59.Checked

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub
End Class
