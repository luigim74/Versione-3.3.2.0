Imports System.IO
Imports System.Data.OleDb
Imports Softgroup.NetButton

Public Class ImpostazioniPos
   Inherits System.Windows.Forms.Form

   Const LARGHEZZA_SALE As Integer = 82
   Const ALTEZZA_SALE As Integer = 50

   Const LARGHEZZA_TAVOLI As Integer = 50
   Const ALTEZZA_TAVOLI As Integer = 50

   Const LARGHEZZA_TAVOLI_PICCOLO As Integer = 30
   Const ALTEZZA_TAVOLI_PICCOLO As Integer = 30
   Const LARGHEZZA_TAVOLI_MEDIO As Integer = 60
   Const ALTEZZA_TAVOLI_MEDIO As Integer = 60
   Const LARGHEZZA_TAVOLI_GRANDE As Integer = 100
   Const ALTEZZA_TAVOLI_GRANDE As Integer = 100

   Const LARGHEZZA_FUNZIONI As Integer = 82
   Const ALTEZZA_FUNZIONI As Integer = 50

   Const LARGHEZZA_CATEGORIE As Integer = 82
   Const ALTEZZA_CATEGORIE As Integer = 50

   Const LARGHEZZA_PIATTO As Integer = 50
   Const ALTEZZA_PIATTO As Integer = 50

   Const LARGHEZZA_VARIANTI As Integer = 82
   Const ALTEZZA_VARIANTI As Integer = 30

   Const NUM_TASTI_RIGA As Integer = 5

   ' Tavoli.
   Const TASTO_APRI As String = "Apri"
   Const TASTO_PRENOTA As String = "Prenota"
   Const TASTO_ASPORTO As String = "Asporto"
   Const TASTO_BLOCCA_SBLOCCA_TAVOLI As String = "Tavoli (blocca-sblocca)"
   Const TASTO_PUNTO_CASSA As String = "Punto cassa"
   Const TASTO_ESCI As String = "Esci"

   ' Piatti.
   Const TASTO_MODIFICA As String = "Modifica"
   Const TASTO_PIU_1 As String = "+1"
   Const TASTO_MENO_1 As String = "-1"
   Const TASTO_CONFERMA As String = "Conferma"
   Const TASTO_CONTO As String = "Conto"
   Const TASTO_C As String = "C"
   Const TASTO_X As String = "X"
   Const TASTO_PERCENTUALE As String = "%"
   Const TASTO_OK As String = "OK"
   Const TASTO_PIU As String = "+"
   Const TASTO_1 As String = "1"
   Const TASTO_2 As String = "2"
   Const TASTO_3 As String = "3"
   Const TASTO_4 As String = "4"
   Const TASTO_5 As String = "5"
   Const TASTO_6 As String = "6"
   Const TASTO_7 As String = "7"
   Const TASTO_8 As String = "8"
   Const TASTO_9 As String = "9"
   Const TASTO_0 As String = "0"
   Const TASTO_00 As String = "00"
   Const TASTO_VIRGOLA As String = ","

   Dim COLORE_SFONDO_TASTO As Color = Color.Black
   Dim COLORE_TESTO_TASTO As Color = Color.White
   Dim COLORE_SFONDO_TASTO_ASPORTO As Color = Color.Orange
   Dim COLORE_TESTO_TASTO_ASPORTO As Color = Color.Black
   Dim COLORE_SFONDO_TASTO_ORANGE As Color = Color.Orange
   Dim COLORE_TESTO_TASTO_BLACK As Color = Color.Black
   Dim COLORE_SFONDO_TASTO_PIATTO As Color = Color.White
   Dim COLORE_TESTO_TASTO_PIATTO As Color = Color.Black

   Const ANA_SALE As String = "Sale"
   Const ANA_TAVOLI As String = "Tavoli"
   Const ANA_CATEGORIE As String = "CategoriePiatti"
   Const ANA_PIATTI As String = "Piatti"
   Const TAB_POS_IMPOSTAZIONI_TAVOLI As String = "POS_ImpostazioniTavoli"
   Const TAB_POS_IMPOSTAZIONI_PIATTI As String = "POS_ImpostazioniPiatti"

   Private Sala() As NetButton
   Private NumSale As Integer = 0
   Private salaSelezionata As Integer = 0

   Private Tavolo() As NetButton
   Private NumTavoli As Integer = 0
   Private tavoloSelezionato As Integer = 1

   Private FunzioneTavolo() As NetButton
   Private NumFunzioniTavoli As Integer = 0
   Private funzioneTavoloSelezionata As Integer = 0

   Private Categoria() As NetButton
   Private NumCategorie As Integer = 0
   Private categoriaSelezionata As Integer = 0

   Private Piatto() As NetButton
   Private NumPiatti As Integer = 0
   Private piattoSelezionato As Integer = 0

   Private Variante() As NetButton
   Private NumVarianti As Integer = 0
   Private varianteSelezionata As Integer = 0

   Private FunzionePiatto() As NetButton
   Private NumFunzioniPiatti As Integer = 0
   Private funzionePiattoSelezionata As Integer = 0

   Private nomeFinestra As String

   Private CFormatta As New ClsFormatta

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private sql As String
   Private cmd As New OleDbCommand(sql, cn)
   Friend WithEvents eui_cmdAnnulla As Elegant.Ui.Button
   Friend WithEvents eui_cmdOK As Elegant.Ui.Button
   Friend WithEvents TabControl1 As Elegant.Ui.TabControl
   Friend WithEvents tpSale As Elegant.Ui.TabPage
   Friend WithEvents tpTavoli As Elegant.Ui.TabPage
   Friend WithEvents tpFunzioniTavoli As Elegant.Ui.TabPage
   Friend WithEvents Label1 As Elegant.Ui.Label
   Friend WithEvents GroupBox2 As Elegant.Ui.GroupBox
   Friend WithEvents Label5 As Elegant.Ui.Label
   Friend WithEvents GroupBox1 As Elegant.Ui.GroupBox
   Friend WithEvents Label3 As Elegant.Ui.Label
   Friend WithEvents Label2 As Elegant.Ui.Label
   Friend WithEvents eui_cmdSpostaGiuSale As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaSuSale As Elegant.Ui.Button
   Friend WithEvents eui_nudAltezzaSale As Elegant.Ui.NumericUpDown
   Friend WithEvents eui_cmdReimpostaSale As Elegant.Ui.Button
   Friend WithEvents lstSale As ListBox
   Friend WithEvents GroupBox3 As Elegant.Ui.GroupBox
   Friend WithEvents eui_nudAltezzaTavoli As Elegant.Ui.NumericUpDown
   Friend WithEvents eui_nudNumTastiRigaTavoli As Elegant.Ui.NumericUpDown
   Friend WithEvents Label7 As Elegant.Ui.Label
   Friend WithEvents Label8 As Elegant.Ui.Label
   Friend WithEvents Label9 As Elegant.Ui.Label
   Friend WithEvents lstTavoli As ListBox
   Friend WithEvents GroupBox4 As Elegant.Ui.GroupBox
   Friend WithEvents Label10 As Elegant.Ui.Label
   Friend WithEvents Label11 As Elegant.Ui.Label
   Friend WithEvents eui_cmdReimpostaTavoli As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaGiuTavoli As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaSuTavoli As Elegant.Ui.Button
   Friend WithEvents lstFunzioniTavoli As ListBox
   Friend WithEvents GroupBox6 As Elegant.Ui.GroupBox
   Friend WithEvents cmdColoreSfondoFunzioniTavoli As Button
   Friend WithEvents cmdColoreTestoFunzioniTavoli As Button
   Friend WithEvents Label15 As Elegant.Ui.Label
   Friend WithEvents Label16 As Elegant.Ui.Label
   Friend WithEvents eui_cmdReimpostaFunzioniTavoli As Elegant.Ui.Button
   Friend WithEvents pnlSale As Panel
   Friend WithEvents netBtn_AnteprimaSale As NetButton
   Friend WithEvents GroupBox5 As Elegant.Ui.GroupBox
   Friend WithEvents cmdColoreTestoSale As Button
   Friend WithEvents cmdColoreSfondoSale As Button
   Friend WithEvents ColorDialog1 As ColorDialog
   Friend WithEvents GroupBox7 As Elegant.Ui.GroupBox
   Friend WithEvents netBtn_AnteprimaFunzioniTavoli As NetButton
   Public WithEvents Label4 As Label
   Friend WithEvents eui_nudDimensionePosti As Elegant.Ui.NumericUpDown
   Friend WithEvents GroupBox9 As Elegant.Ui.GroupBox
   Friend WithEvents netBtn_AnteprimaTavoli As NetButton
   Friend WithEvents GroupBox8 As Elegant.Ui.GroupBox
   Friend WithEvents Label12 As Elegant.Ui.Label
   Friend WithEvents TabControl2 As Elegant.Ui.TabControl
   Friend WithEvents TabPage1 As Elegant.Ui.TabPage
   Friend WithEvents GroupBox10 As Elegant.Ui.GroupBox
   Friend WithEvents netBtn_AnteprimaTavoliPiantina As NetButton
   Friend WithEvents TabPage2 As Elegant.Ui.TabPage
   Friend WithEvents eui_ddwnDimensioneTavoli As Elegant.Ui.DropDown
   Friend WithEvents eui_ddwnOrientamentoTavoli As Elegant.Ui.DropDown
   Friend WithEvents pnlFunzioniTavoli As Panel
   Friend WithEvents eui_ddwnStileColoreFunzioniTavoli As Elegant.Ui.DropDown
   Friend WithEvents Label6 As Elegant.Ui.Label
   Friend WithEvents Label13 As Elegant.Ui.Label
   Friend WithEvents eui_ddwnStileColoreSale As Elegant.Ui.DropDown
   Friend WithEvents pnlTavoli As Panel
   Friend WithEvents PopupMenu3 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_btnTastoPiccolo As Elegant.Ui.Button
   Friend WithEvents eui_btnTastoMedio As Elegant.Ui.Button
   Friend WithEvents eui_btnTastoGrande As Elegant.Ui.Button
   Friend WithEvents PopupMenu2 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_btnOrizzontale As Elegant.Ui.Button
   Friend WithEvents eui_btnVerticale As Elegant.Ui.Button
   Public WithEvents Label14 As Label
   Friend WithEvents eui_nudLarghezzaTavoli As Elegant.Ui.NumericUpDown
   Friend WithEvents tpCategorie As Elegant.Ui.TabPage
   Friend WithEvents GroupBox11 As Elegant.Ui.GroupBox
   Public WithEvents Label17 As Label
   Friend WithEvents netBtn_AnteprimaCategorie As NetButton
   Friend WithEvents pnlCategorie As Panel
   Friend WithEvents GroupBox12 As Elegant.Ui.GroupBox
   Friend WithEvents eui_nudAltezzaCategorie As Elegant.Ui.NumericUpDown
   Friend WithEvents Label18 As Elegant.Ui.Label
   Friend WithEvents lstCategorie As ListBox
   Friend WithEvents GroupBox13 As Elegant.Ui.GroupBox
   Friend WithEvents Label19 As Elegant.Ui.Label
   Friend WithEvents eui_ddwnStileColoreCategorie As Elegant.Ui.DropDown
   Friend WithEvents cmdColoreTestoCategorie As Button
   Friend WithEvents cmdColoreSfondoCategorie As Button
   Friend WithEvents Label20 As Elegant.Ui.Label
   Friend WithEvents Label21 As Elegant.Ui.Label
   Friend WithEvents eui_cmdReimpostaCategorie As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaGiùCategorie As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaSuCategorie As Elegant.Ui.Button
   Friend WithEvents eui_cmdRimuoviImgCategorie As Elegant.Ui.Button
   Friend WithEvents eui_cmdInserisciImgCategorie As Elegant.Ui.Button
   Friend WithEvents OpenFileDialog1 As OpenFileDialog
   Friend WithEvents tpPiatti As Elegant.Ui.TabPage
   Friend WithEvents eui_cmdRimuoviImgPiatti As Elegant.Ui.Button
   Friend WithEvents eui_cmdInserisciImgPiatti As Elegant.Ui.Button
   Friend WithEvents GroupBox14 As Elegant.Ui.GroupBox
   Friend WithEvents netBtn_AnteprimaPiatti As Softgroup.NetButton.NetButton
   Friend WithEvents pnlPiatti As System.Windows.Forms.Panel
   Friend WithEvents GroupBox15 As Elegant.Ui.GroupBox
   Friend WithEvents eui_nudAltezzaPiatti As Elegant.Ui.NumericUpDown
   Friend WithEvents Label23 As Elegant.Ui.Label
   Friend WithEvents lstPiatti As System.Windows.Forms.ListBox
   Friend WithEvents GroupBox16 As Elegant.Ui.GroupBox
   Friend WithEvents Label24 As Elegant.Ui.Label
   Friend WithEvents eui_ddwnStileColorePiatti As Elegant.Ui.DropDown
   Friend WithEvents cmdColoreTestoPiatti As System.Windows.Forms.Button
   Friend WithEvents cmdColoreSfondoPiatti As System.Windows.Forms.Button
   Friend WithEvents Label25 As Elegant.Ui.Label
   Friend WithEvents Label26 As Elegant.Ui.Label
   Friend WithEvents eui_cmdReimpostaPiatti As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaGiùPiatti As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaSuPiatti As Elegant.Ui.Button
   Friend WithEvents eui_nudLarghezzaPiatti As Elegant.Ui.NumericUpDown
   Friend WithEvents eui_nudNumTastiRigaPiatti As Elegant.Ui.NumericUpDown
   Friend WithEvents Label27 As Elegant.Ui.Label
   Friend WithEvents Label28 As Elegant.Ui.Label
   Friend WithEvents tpVarianti As Elegant.Ui.TabPage
   Friend WithEvents eui_cmdRimuoviImgVarianti As Elegant.Ui.Button
   Friend WithEvents eui_cmdInserisciImgVarianti As Elegant.Ui.Button
   Friend WithEvents GroupBox17 As Elegant.Ui.GroupBox
   Public WithEvents Label22 As Label
   Friend WithEvents netBtn_AnteprimaVarianti As NetButton
   Friend WithEvents pnlVarianti As Panel
   Friend WithEvents GroupBox18 As Elegant.Ui.GroupBox
   Friend WithEvents eui_nudAltezzaVarianti As Elegant.Ui.NumericUpDown
   Friend WithEvents Label29 As Elegant.Ui.Label
   Friend WithEvents lstVarianti As ListBox
   Friend WithEvents GroupBox19 As Elegant.Ui.GroupBox
   Friend WithEvents Label30 As Elegant.Ui.Label
   Friend WithEvents eui_ddwnStileColoreVarianti As Elegant.Ui.DropDown
   Friend WithEvents cmdColoreTestoVarianti As Button
   Friend WithEvents cmdColoreSfondoVarianti As Button
   Friend WithEvents Label31 As Elegant.Ui.Label
   Friend WithEvents Label32 As Elegant.Ui.Label
   Friend WithEvents eui_cmdReimpostaVarianti As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaGiùVarianti As Elegant.Ui.Button
   Friend WithEvents eui_cmdSpostaSuVarianti As Elegant.Ui.Button
   Friend WithEvents PopupMenu1 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_btnColorePredefinito As Elegant.Ui.Button
   Friend WithEvents Separator1 As Elegant.Ui.Separator
   Friend WithEvents eui_btnColoreBianco As Elegant.Ui.Button
   Friend WithEvents eui_btnColoreBlu As Elegant.Ui.Button
   Friend WithEvents eui_btnColoreGrigio As Elegant.Ui.Button
   Friend WithEvents eui_btnColoreVerde As Elegant.Ui.Button
   Friend WithEvents eui_btnColoreViola As Elegant.Ui.Button
   Friend WithEvents eui_btnColoreRosso As Elegant.Ui.Button
   Friend WithEvents eui_btnColoreGiallo As Elegant.Ui.Button
   Friend WithEvents Separator2 As Elegant.Ui.Separator
   Friend WithEvents eui_btnColorePersonalizzato As Elegant.Ui.Button
   Friend WithEvents tpFunzioniPiatti As Elegant.Ui.TabPage
   Friend WithEvents GroupBox21 As Elegant.Ui.GroupBox
   Friend WithEvents Label34 As Elegant.Ui.Label
   Friend WithEvents eui_ddwnStileColoreFunzioniPiatti As Elegant.Ui.DropDown
   Friend WithEvents cmdColoreSfondoFunzioniPiatti As Button
   Friend WithEvents cmdColoreTestoFunzioniPiatti As Button
   Friend WithEvents Label35 As Elegant.Ui.Label
   Friend WithEvents Label36 As Elegant.Ui.Label
   Friend WithEvents pnlFunzioniPiatti As Panel
   Friend WithEvents GroupBox20 As Elegant.Ui.GroupBox
   Friend WithEvents netBtn_AnteprimaFunzioniPiatti As NetButton
   Public WithEvents Label33 As Label
   Friend WithEvents lstFunzioniPiatti As ListBox
   Friend WithEvents eui_cmdReimpostaFunzioniPiatti As Elegant.Ui.Button
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner

#Region " Codice generato da Progettazione Windows Form "

   Public Sub New(ByVal frmName As String)
      MyBase.New()

      'Chiamata richiesta da Progettazione Windows Form.
      InitializeComponent()

      nomeFinestra = frmName
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
   Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
   Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
   Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
   <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ImpostazioniPos))
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
      Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.TabControl1 = New Elegant.Ui.TabControl()
      Me.tpFunzioniPiatti = New Elegant.Ui.TabPage()
      Me.GroupBox21 = New Elegant.Ui.GroupBox()
      Me.Label34 = New Elegant.Ui.Label()
      Me.eui_ddwnStileColoreFunzioniPiatti = New Elegant.Ui.DropDown()
      Me.PopupMenu1 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_btnColorePredefinito = New Elegant.Ui.Button()
      Me.Separator1 = New Elegant.Ui.Separator()
      Me.eui_btnColoreBianco = New Elegant.Ui.Button()
      Me.eui_btnColoreBlu = New Elegant.Ui.Button()
      Me.eui_btnColoreGrigio = New Elegant.Ui.Button()
      Me.eui_btnColoreVerde = New Elegant.Ui.Button()
      Me.eui_btnColoreViola = New Elegant.Ui.Button()
      Me.eui_btnColoreRosso = New Elegant.Ui.Button()
      Me.eui_btnColoreGiallo = New Elegant.Ui.Button()
      Me.Separator2 = New Elegant.Ui.Separator()
      Me.eui_btnColorePersonalizzato = New Elegant.Ui.Button()
      Me.cmdColoreSfondoFunzioniPiatti = New System.Windows.Forms.Button()
      Me.cmdColoreTestoFunzioniPiatti = New System.Windows.Forms.Button()
      Me.Label35 = New Elegant.Ui.Label()
      Me.Label36 = New Elegant.Ui.Label()
      Me.pnlFunzioniPiatti = New System.Windows.Forms.Panel()
      Me.GroupBox20 = New Elegant.Ui.GroupBox()
      Me.netBtn_AnteprimaFunzioniPiatti = New Softgroup.NetButton.NetButton()
      Me.Label33 = New System.Windows.Forms.Label()
      Me.lstFunzioniPiatti = New System.Windows.Forms.ListBox()
      Me.eui_cmdReimpostaFunzioniPiatti = New Elegant.Ui.Button()
      Me.tpSale = New Elegant.Ui.TabPage()
      Me.GroupBox5 = New Elegant.Ui.GroupBox()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.netBtn_AnteprimaSale = New Softgroup.NetButton.NetButton()
      Me.pnlSale = New System.Windows.Forms.Panel()
      Me.GroupBox2 = New Elegant.Ui.GroupBox()
      Me.eui_nudAltezzaSale = New Elegant.Ui.NumericUpDown()
      Me.Label5 = New Elegant.Ui.Label()
      Me.lstSale = New System.Windows.Forms.ListBox()
      Me.GroupBox1 = New Elegant.Ui.GroupBox()
      Me.Label13 = New Elegant.Ui.Label()
      Me.eui_ddwnStileColoreSale = New Elegant.Ui.DropDown()
      Me.cmdColoreTestoSale = New System.Windows.Forms.Button()
      Me.cmdColoreSfondoSale = New System.Windows.Forms.Button()
      Me.Label3 = New Elegant.Ui.Label()
      Me.Label2 = New Elegant.Ui.Label()
      Me.eui_cmdReimpostaSale = New Elegant.Ui.Button()
      Me.eui_cmdSpostaGiuSale = New Elegant.Ui.Button()
      Me.eui_cmdSpostaSuSale = New Elegant.Ui.Button()
      Me.tpTavoli = New Elegant.Ui.TabPage()
      Me.pnlTavoli = New System.Windows.Forms.Panel()
      Me.TabControl2 = New Elegant.Ui.TabControl()
      Me.TabPage2 = New Elegant.Ui.TabPage()
      Me.GroupBox9 = New Elegant.Ui.GroupBox()
      Me.netBtn_AnteprimaTavoli = New Softgroup.NetButton.NetButton()
      Me.GroupBox3 = New Elegant.Ui.GroupBox()
      Me.eui_nudLarghezzaTavoli = New Elegant.Ui.NumericUpDown()
      Me.eui_nudAltezzaTavoli = New Elegant.Ui.NumericUpDown()
      Me.eui_nudNumTastiRigaTavoli = New Elegant.Ui.NumericUpDown()
      Me.Label7 = New Elegant.Ui.Label()
      Me.Label8 = New Elegant.Ui.Label()
      Me.Label9 = New Elegant.Ui.Label()
      Me.TabPage1 = New Elegant.Ui.TabPage()
      Me.GroupBox10 = New Elegant.Ui.GroupBox()
      Me.netBtn_AnteprimaTavoliPiantina = New Softgroup.NetButton.NetButton()
      Me.GroupBox8 = New Elegant.Ui.GroupBox()
      Me.eui_ddwnDimensioneTavoli = New Elegant.Ui.DropDown()
      Me.PopupMenu3 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_btnTastoPiccolo = New Elegant.Ui.Button()
      Me.eui_btnTastoMedio = New Elegant.Ui.Button()
      Me.eui_btnTastoGrande = New Elegant.Ui.Button()
      Me.Label12 = New Elegant.Ui.Label()
      Me.GroupBox4 = New Elegant.Ui.GroupBox()
      Me.eui_ddwnOrientamentoTavoli = New Elegant.Ui.DropDown()
      Me.PopupMenu2 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_btnOrizzontale = New Elegant.Ui.Button()
      Me.eui_btnVerticale = New Elegant.Ui.Button()
      Me.eui_nudDimensionePosti = New Elegant.Ui.NumericUpDown()
      Me.Label10 = New Elegant.Ui.Label()
      Me.Label11 = New Elegant.Ui.Label()
      Me.lstTavoli = New System.Windows.Forms.ListBox()
      Me.eui_cmdReimpostaTavoli = New Elegant.Ui.Button()
      Me.eui_cmdSpostaGiuTavoli = New Elegant.Ui.Button()
      Me.eui_cmdSpostaSuTavoli = New Elegant.Ui.Button()
      Me.tpFunzioniTavoli = New Elegant.Ui.TabPage()
      Me.pnlFunzioniTavoli = New System.Windows.Forms.Panel()
      Me.GroupBox7 = New Elegant.Ui.GroupBox()
      Me.netBtn_AnteprimaFunzioniTavoli = New Softgroup.NetButton.NetButton()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.lstFunzioniTavoli = New System.Windows.Forms.ListBox()
      Me.GroupBox6 = New Elegant.Ui.GroupBox()
      Me.Label6 = New Elegant.Ui.Label()
      Me.eui_ddwnStileColoreFunzioniTavoli = New Elegant.Ui.DropDown()
      Me.cmdColoreSfondoFunzioniTavoli = New System.Windows.Forms.Button()
      Me.cmdColoreTestoFunzioniTavoli = New System.Windows.Forms.Button()
      Me.Label15 = New Elegant.Ui.Label()
      Me.Label16 = New Elegant.Ui.Label()
      Me.eui_cmdReimpostaFunzioniTavoli = New Elegant.Ui.Button()
      Me.tpCategorie = New Elegant.Ui.TabPage()
      Me.eui_cmdRimuoviImgCategorie = New Elegant.Ui.Button()
      Me.eui_cmdInserisciImgCategorie = New Elegant.Ui.Button()
      Me.GroupBox11 = New Elegant.Ui.GroupBox()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.netBtn_AnteprimaCategorie = New Softgroup.NetButton.NetButton()
      Me.pnlCategorie = New System.Windows.Forms.Panel()
      Me.GroupBox12 = New Elegant.Ui.GroupBox()
      Me.eui_nudAltezzaCategorie = New Elegant.Ui.NumericUpDown()
      Me.Label18 = New Elegant.Ui.Label()
      Me.lstCategorie = New System.Windows.Forms.ListBox()
      Me.GroupBox13 = New Elegant.Ui.GroupBox()
      Me.Label19 = New Elegant.Ui.Label()
      Me.eui_ddwnStileColoreCategorie = New Elegant.Ui.DropDown()
      Me.cmdColoreTestoCategorie = New System.Windows.Forms.Button()
      Me.cmdColoreSfondoCategorie = New System.Windows.Forms.Button()
      Me.Label20 = New Elegant.Ui.Label()
      Me.Label21 = New Elegant.Ui.Label()
      Me.eui_cmdReimpostaCategorie = New Elegant.Ui.Button()
      Me.eui_cmdSpostaGiùCategorie = New Elegant.Ui.Button()
      Me.eui_cmdSpostaSuCategorie = New Elegant.Ui.Button()
      Me.tpPiatti = New Elegant.Ui.TabPage()
      Me.eui_cmdRimuoviImgPiatti = New Elegant.Ui.Button()
      Me.eui_cmdInserisciImgPiatti = New Elegant.Ui.Button()
      Me.GroupBox14 = New Elegant.Ui.GroupBox()
      Me.netBtn_AnteprimaPiatti = New Softgroup.NetButton.NetButton()
      Me.pnlPiatti = New System.Windows.Forms.Panel()
      Me.GroupBox15 = New Elegant.Ui.GroupBox()
      Me.eui_nudLarghezzaPiatti = New Elegant.Ui.NumericUpDown()
      Me.eui_nudNumTastiRigaPiatti = New Elegant.Ui.NumericUpDown()
      Me.Label27 = New Elegant.Ui.Label()
      Me.Label28 = New Elegant.Ui.Label()
      Me.eui_nudAltezzaPiatti = New Elegant.Ui.NumericUpDown()
      Me.Label23 = New Elegant.Ui.Label()
      Me.lstPiatti = New System.Windows.Forms.ListBox()
      Me.GroupBox16 = New Elegant.Ui.GroupBox()
      Me.Label24 = New Elegant.Ui.Label()
      Me.eui_ddwnStileColorePiatti = New Elegant.Ui.DropDown()
      Me.cmdColoreTestoPiatti = New System.Windows.Forms.Button()
      Me.cmdColoreSfondoPiatti = New System.Windows.Forms.Button()
      Me.Label25 = New Elegant.Ui.Label()
      Me.Label26 = New Elegant.Ui.Label()
      Me.eui_cmdReimpostaPiatti = New Elegant.Ui.Button()
      Me.eui_cmdSpostaGiùPiatti = New Elegant.Ui.Button()
      Me.eui_cmdSpostaSuPiatti = New Elegant.Ui.Button()
      Me.tpVarianti = New Elegant.Ui.TabPage()
      Me.eui_cmdRimuoviImgVarianti = New Elegant.Ui.Button()
      Me.eui_cmdInserisciImgVarianti = New Elegant.Ui.Button()
      Me.GroupBox17 = New Elegant.Ui.GroupBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.netBtn_AnteprimaVarianti = New Softgroup.NetButton.NetButton()
      Me.pnlVarianti = New System.Windows.Forms.Panel()
      Me.GroupBox18 = New Elegant.Ui.GroupBox()
      Me.eui_nudAltezzaVarianti = New Elegant.Ui.NumericUpDown()
      Me.Label29 = New Elegant.Ui.Label()
      Me.lstVarianti = New System.Windows.Forms.ListBox()
      Me.GroupBox19 = New Elegant.Ui.GroupBox()
      Me.Label30 = New Elegant.Ui.Label()
      Me.eui_ddwnStileColoreVarianti = New Elegant.Ui.DropDown()
      Me.cmdColoreTestoVarianti = New System.Windows.Forms.Button()
      Me.cmdColoreSfondoVarianti = New System.Windows.Forms.Button()
      Me.Label31 = New Elegant.Ui.Label()
      Me.Label32 = New Elegant.Ui.Label()
      Me.eui_cmdReimpostaVarianti = New Elegant.Ui.Button()
      Me.eui_cmdSpostaGiùVarianti = New Elegant.Ui.Button()
      Me.eui_cmdSpostaSuVarianti = New Elegant.Ui.Button()
      Me.eui_cmdOK = New Elegant.Ui.Button()
      Me.eui_cmdAnnulla = New Elegant.Ui.Button()
      Me.Label1 = New Elegant.Ui.Label()
      Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tpFunzioniPiatti.SuspendLayout()
      Me.GroupBox21.SuspendLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox20.SuspendLayout()
      Me.tpSale.SuspendLayout()
      Me.GroupBox5.SuspendLayout()
      Me.GroupBox2.SuspendLayout()
      CType(Me.eui_nudAltezzaSale, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox1.SuspendLayout()
      Me.tpTavoli.SuspendLayout()
      CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage2.SuspendLayout()
      Me.GroupBox9.SuspendLayout()
      Me.GroupBox3.SuspendLayout()
      CType(Me.eui_nudLarghezzaTavoli, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.eui_nudAltezzaTavoli, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.eui_nudNumTastiRigaTavoli, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.TabPage1.SuspendLayout()
      Me.GroupBox10.SuspendLayout()
      Me.GroupBox8.SuspendLayout()
      CType(Me.PopupMenu3, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox4.SuspendLayout()
      CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.eui_nudDimensionePosti, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.tpFunzioniTavoli.SuspendLayout()
      Me.GroupBox7.SuspendLayout()
      Me.GroupBox6.SuspendLayout()
      Me.tpCategorie.SuspendLayout()
      Me.GroupBox11.SuspendLayout()
      Me.GroupBox12.SuspendLayout()
      CType(Me.eui_nudAltezzaCategorie, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox13.SuspendLayout()
      Me.tpPiatti.SuspendLayout()
      Me.GroupBox14.SuspendLayout()
      Me.GroupBox15.SuspendLayout()
      CType(Me.eui_nudLarghezzaPiatti, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.eui_nudNumTastiRigaPiatti, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.eui_nudAltezzaPiatti, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox16.SuspendLayout()
      Me.tpVarianti.SuspendLayout()
      Me.GroupBox17.SuspendLayout()
      Me.GroupBox18.SuspendLayout()
      CType(Me.eui_nudAltezzaVarianti, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.GroupBox19.SuspendLayout()
      Me.SuspendLayout()
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'PrintDialog1
      '
      Me.PrintDialog1.Document = Me.PrintDocument1
      '
      'PrintDocument1
      '
      Me.PrintDocument1.DocumentName = "RFiscale.rpt"
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      '
      'TabControl1
      '
      Me.TabControl1.EndScrollButtonVisible = True
      Me.TabControl1.EqualTabWidth = True
      Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.TabControl1.Location = New System.Drawing.Point(9, 29)
      Me.TabControl1.Name = "TabControl1"
      Me.TabControl1.SelectedTabPage = Me.tpSale
      Me.TabControl1.Size = New System.Drawing.Size(692, 578)
      Me.TabControl1.TabIndex = 242
      Me.TabControl1.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.tpSale, Me.tpTavoli, Me.tpFunzioniTavoli, Me.tpCategorie, Me.tpPiatti, Me.tpVarianti, Me.tpFunzioniPiatti})
      Me.TabControl1.TabsPlacement = Elegant.Ui.TabsPlacement.Bottom
      Me.TabControl1.Text = "TabControl1"
      '
      'tpFunzioniPiatti
      '
      Me.tpFunzioniPiatti.ActiveControl = Nothing
      Me.tpFunzioniPiatti.Controls.Add(Me.GroupBox21)
      Me.tpFunzioniPiatti.Controls.Add(Me.pnlFunzioniPiatti)
      Me.tpFunzioniPiatti.Controls.Add(Me.GroupBox20)
      Me.tpFunzioniPiatti.Controls.Add(Me.lstFunzioniPiatti)
      Me.tpFunzioniPiatti.Controls.Add(Me.eui_cmdReimpostaFunzioniPiatti)
      Me.tpFunzioniPiatti.KeyTip = Nothing
      Me.tpFunzioniPiatti.Name = "tpFunzioniPiatti"
      Me.tpFunzioniPiatti.Size = New System.Drawing.Size(690, 550)
      Me.tpFunzioniPiatti.TabIndex = 6
      Me.tpFunzioniPiatti.Text = "Funzioni "
      '
      'GroupBox21
      '
      Me.GroupBox21.Controls.Add(Me.Label34)
      Me.GroupBox21.Controls.Add(Me.eui_ddwnStileColoreFunzioniPiatti)
      Me.GroupBox21.Controls.Add(Me.cmdColoreSfondoFunzioniPiatti)
      Me.GroupBox21.Controls.Add(Me.cmdColoreTestoFunzioniPiatti)
      Me.GroupBox21.Controls.Add(Me.Label35)
      Me.GroupBox21.Controls.Add(Me.Label36)
      Me.GroupBox21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox21.Id = "806a59db-f798-4b83-b7f5-48daa9fe500b"
      Me.GroupBox21.Location = New System.Drawing.Point(393, 14)
      Me.GroupBox21.Name = "GroupBox21"
      Me.GroupBox21.Size = New System.Drawing.Size(285, 250)
      Me.GroupBox21.TabIndex = 270
      Me.GroupBox21.Text = "Opzioni singolo elemento"
      '
      'Label34
      '
      Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label34.Location = New System.Drawing.Point(12, 35)
      Me.Label34.Name = "Label34"
      Me.Label34.Size = New System.Drawing.Size(108, 20)
      Me.Label34.TabIndex = 265
      Me.Label34.Text = "Stile colore:"
      '
      'eui_ddwnStileColoreFunzioniPiatti
      '
      Me.eui_ddwnStileColoreFunzioniPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_ddwnStileColoreFunzioniPiatti.Id = "af79d192-654c-4b46-a9e7-672c21df3096"
      Me.eui_ddwnStileColoreFunzioniPiatti.Location = New System.Drawing.Point(164, 32)
      Me.eui_ddwnStileColoreFunzioniPiatti.Name = "eui_ddwnStileColoreFunzioniPiatti"
      Me.eui_ddwnStileColoreFunzioniPiatti.Popup = Me.PopupMenu1
      Me.eui_ddwnStileColoreFunzioniPiatti.Size = New System.Drawing.Size(106, 28)
      Me.eui_ddwnStileColoreFunzioniPiatti.TabIndex = 0
      Me.eui_ddwnStileColoreFunzioniPiatti.Text = "Predefinito"
      '
      'PopupMenu1
      '
      Me.PopupMenu1.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_btnColorePredefinito, Me.Separator1, Me.eui_btnColoreBianco, Me.eui_btnColoreBlu, Me.eui_btnColoreGrigio, Me.eui_btnColoreVerde, Me.eui_btnColoreViola, Me.eui_btnColoreRosso, Me.eui_btnColoreGiallo, Me.Separator2, Me.eui_btnColorePersonalizzato})
      Me.PopupMenu1.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu1.Size = New System.Drawing.Size(100, 100)
      '
      'eui_btnColorePredefinito
      '
      Me.eui_btnColorePredefinito.Id = "8216979a-c5a5-4baa-b8a9-b1f88811e9d5"
      Me.eui_btnColorePredefinito.Location = New System.Drawing.Point(2, 2)
      Me.eui_btnColorePredefinito.Name = "eui_btnColorePredefinito"
      Me.eui_btnColorePredefinito.Size = New System.Drawing.Size(134, 23)
      Me.eui_btnColorePredefinito.TabIndex = 3
      Me.eui_btnColorePredefinito.Text = "&Predefinito"
      '
      'Separator1
      '
      Me.Separator1.Id = "52e39e68-662f-49bf-b22b-305ce9a4b00f"
      Me.Separator1.Location = New System.Drawing.Point(2, 25)
      Me.Separator1.Name = "Separator1"
      Me.Separator1.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator1.Size = New System.Drawing.Size(134, 5)
      Me.Separator1.TabIndex = 5
      Me.Separator1.Text = "Separator1"
      '
      'eui_btnColoreBianco
      '
      Me.eui_btnColoreBianco.Id = "e20159b7-0636-4c93-a452-1c9d4ea1580c"
      Me.eui_btnColoreBianco.Location = New System.Drawing.Point(2, 30)
      Me.eui_btnColoreBianco.Name = "eui_btnColoreBianco"
      Me.eui_btnColoreBianco.Size = New System.Drawing.Size(134, 23)
      Me.eui_btnColoreBianco.TabIndex = 4
      Me.eui_btnColoreBianco.Text = "&Bianco"
      '
      'eui_btnColoreBlu
      '
      Me.eui_btnColoreBlu.Id = "b46b1f07-b288-4e1a-8fd3-89cc7ceb19e9"
      Me.eui_btnColoreBlu.Location = New System.Drawing.Point(2, 53)
      Me.eui_btnColoreBlu.Name = "eui_btnColoreBlu"
      Me.eui_btnColoreBlu.Size = New System.Drawing.Size(134, 23)
      Me.eui_btnColoreBlu.TabIndex = 6
      Me.eui_btnColoreBlu.Text = "Bl&u"
      '
      'eui_btnColoreGrigio
      '
      Me.eui_btnColoreGrigio.Id = "d07ffe2d-328e-47c1-8914-6c11cf803a1d"
      Me.eui_btnColoreGrigio.Location = New System.Drawing.Point(2, 76)
      Me.eui_btnColoreGrigio.Name = "eui_btnColoreGrigio"
      Me.eui_btnColoreGrigio.Size = New System.Drawing.Size(134, 23)
      Me.eui_btnColoreGrigio.TabIndex = 7
      Me.eui_btnColoreGrigio.Text = "&Grigio"
      '
      'eui_btnColoreVerde
      '
      Me.eui_btnColoreVerde.Id = "ba5729c2-890a-4a08-91fd-5724c11e296f"
      Me.eui_btnColoreVerde.Location = New System.Drawing.Point(2, 99)
      Me.eui_btnColoreVerde.Name = "eui_btnColoreVerde"
      Me.eui_btnColoreVerde.Size = New System.Drawing.Size(134, 23)
      Me.eui_btnColoreVerde.TabIndex = 8
      Me.eui_btnColoreVerde.Text = "&Verde"
      '
      'eui_btnColoreViola
      '
      Me.eui_btnColoreViola.Id = "1c322d3c-4fc3-4e99-bfd7-bcf7ba14a3c5"
      Me.eui_btnColoreViola.Location = New System.Drawing.Point(2, 122)
      Me.eui_btnColoreViola.Name = "eui_btnColoreViola"
      Me.eui_btnColoreViola.Size = New System.Drawing.Size(134, 23)
      Me.eui_btnColoreViola.TabIndex = 9
      Me.eui_btnColoreViola.Text = "Vi&ola"
      '
      'eui_btnColoreRosso
      '
      Me.eui_btnColoreRosso.Id = "7f27ae88-f2ca-4948-9560-b3a1cfc84bc1"
      Me.eui_btnColoreRosso.Location = New System.Drawing.Point(2, 145)
      Me.eui_btnColoreRosso.Name = "eui_btnColoreRosso"
      Me.eui_btnColoreRosso.Size = New System.Drawing.Size(134, 23)
      Me.eui_btnColoreRosso.TabIndex = 10
      Me.eui_btnColoreRosso.Text = "&Rosso"
      '
      'eui_btnColoreGiallo
      '
      Me.eui_btnColoreGiallo.Id = "05e8b8c3-62c9-4bfb-b4c3-b8a3f52305fb"
      Me.eui_btnColoreGiallo.Location = New System.Drawing.Point(2, 168)
      Me.eui_btnColoreGiallo.Name = "eui_btnColoreGiallo"
      Me.eui_btnColoreGiallo.Size = New System.Drawing.Size(134, 23)
      Me.eui_btnColoreGiallo.TabIndex = 11
      Me.eui_btnColoreGiallo.Text = "Gi&allo"
      '
      'Separator2
      '
      Me.Separator2.Id = "6e45cd27-2461-4f74-9be6-609b0b8b1691"
      Me.Separator2.Location = New System.Drawing.Point(2, 191)
      Me.Separator2.Name = "Separator2"
      Me.Separator2.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator2.Size = New System.Drawing.Size(134, 5)
      Me.Separator2.TabIndex = 12
      Me.Separator2.Text = "Separator2"
      '
      'eui_btnColorePersonalizzato
      '
      Me.eui_btnColorePersonalizzato.Id = "7e89c645-dbd0-4f62-97bb-890bcc950989"
      Me.eui_btnColorePersonalizzato.Location = New System.Drawing.Point(2, 196)
      Me.eui_btnColorePersonalizzato.Name = "eui_btnColorePersonalizzato"
      Me.eui_btnColorePersonalizzato.Size = New System.Drawing.Size(134, 23)
      Me.eui_btnColorePersonalizzato.TabIndex = 13
      Me.eui_btnColorePersonalizzato.Text = "P&ersonalizzato"
      '
      'cmdColoreSfondoFunzioniPiatti
      '
      Me.cmdColoreSfondoFunzioniPiatti.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreSfondoFunzioniPiatti.Enabled = False
      Me.cmdColoreSfondoFunzioniPiatti.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreSfondoFunzioniPiatti.Location = New System.Drawing.Point(165, 77)
      Me.cmdColoreSfondoFunzioniPiatti.Name = "cmdColoreSfondoFunzioniPiatti"
      Me.cmdColoreSfondoFunzioniPiatti.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreSfondoFunzioniPiatti.TabIndex = 1
      Me.cmdColoreSfondoFunzioniPiatti.UseVisualStyleBackColor = False
      '
      'cmdColoreTestoFunzioniPiatti
      '
      Me.cmdColoreTestoFunzioniPiatti.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreTestoFunzioniPiatti.Enabled = False
      Me.cmdColoreTestoFunzioniPiatti.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreTestoFunzioniPiatti.Location = New System.Drawing.Point(164, 124)
      Me.cmdColoreTestoFunzioniPiatti.Name = "cmdColoreTestoFunzioniPiatti"
      Me.cmdColoreTestoFunzioniPiatti.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreTestoFunzioniPiatti.TabIndex = 2
      Me.cmdColoreTestoFunzioniPiatti.UseVisualStyleBackColor = False
      '
      'Label35
      '
      Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label35.Location = New System.Drawing.Point(12, 127)
      Me.Label35.Name = "Label35"
      Me.Label35.Size = New System.Drawing.Size(108, 20)
      Me.Label35.TabIndex = 253
      Me.Label35.Text = "Colore testo:"
      '
      'Label36
      '
      Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label36.Location = New System.Drawing.Point(12, 76)
      Me.Label36.Name = "Label36"
      Me.Label36.Size = New System.Drawing.Size(108, 20)
      Me.Label36.TabIndex = 252
      Me.Label36.Text = "Colore sfondo:"
      '
      'pnlFunzioniPiatti
      '
      Me.pnlFunzioniPiatti.Location = New System.Drawing.Point(284, 22)
      Me.pnlFunzioniPiatti.Name = "pnlFunzioniPiatti"
      Me.pnlFunzioniPiatti.Size = New System.Drawing.Size(96, 43)
      Me.pnlFunzioniPiatti.TabIndex = 269
      Me.pnlFunzioniPiatti.Visible = False
      '
      'GroupBox20
      '
      Me.GroupBox20.Controls.Add(Me.netBtn_AnteprimaFunzioniPiatti)
      Me.GroupBox20.Controls.Add(Me.Label33)
      Me.GroupBox20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox20.Id = "abbe5638-c658-4fe3-9a2d-bea19f1889e9"
      Me.GroupBox20.Location = New System.Drawing.Point(392, 286)
      Me.GroupBox20.Name = "GroupBox20"
      Me.GroupBox20.Size = New System.Drawing.Size(285, 251)
      Me.GroupBox20.TabIndex = 268
      Me.GroupBox20.Text = "Anteprima"
      '
      'netBtn_AnteprimaFunzioniPiatti
      '
      Me.netBtn_AnteprimaFunzioniPiatti.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_AnteprimaFunzioniPiatti.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_AnteprimaFunzioniPiatti.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_AnteprimaFunzioniPiatti.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_AnteprimaFunzioniPiatti.ColorText = System.Drawing.SystemColors.ControlText
      Me.netBtn_AnteprimaFunzioniPiatti.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_AnteprimaFunzioniPiatti.CornerRadius = 2
      Me.netBtn_AnteprimaFunzioniPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_AnteprimaFunzioniPiatti.Location = New System.Drawing.Point(120, 16)
      Me.netBtn_AnteprimaFunzioniPiatti.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_AnteprimaFunzioniPiatti.Name = "netBtn_AnteprimaFunzioniPiatti"
      Me.netBtn_AnteprimaFunzioniPiatti.Size = New System.Drawing.Size(150, 60)
      Me.netBtn_AnteprimaFunzioniPiatti.TabIndex = 0
      Me.netBtn_AnteprimaFunzioniPiatti.TextButton = ""
      '
      'Label33
      '
      Me.Label33.AutoSize = True
      Me.Label33.BackColor = System.Drawing.Color.Transparent
      Me.Label33.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label33.ForeColor = System.Drawing.Color.Black
      Me.Label33.Location = New System.Drawing.Point(14, 16)
      Me.Label33.Name = "Label33"
      Me.Label33.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label33.Size = New System.Drawing.Size(53, 20)
      Me.Label33.TabIndex = 254
      Me.Label33.Text = "Tasto:"
      '
      'lstFunzioniPiatti
      '
      Me.lstFunzioniPiatti.FormattingEnabled = True
      Me.lstFunzioniPiatti.ItemHeight = 20
      Me.lstFunzioniPiatti.Location = New System.Drawing.Point(13, 13)
      Me.lstFunzioniPiatti.Name = "lstFunzioniPiatti"
      Me.lstFunzioniPiatti.Size = New System.Drawing.Size(266, 524)
      Me.lstFunzioniPiatti.TabIndex = 266
      '
      'eui_cmdReimpostaFunzioniPiatti
      '
      Me.eui_cmdReimpostaFunzioniPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdReimpostaFunzioniPiatti.Id = "f2739ae8-9673-426e-b909-907acf0d62f8"
      Me.eui_cmdReimpostaFunzioniPiatti.Location = New System.Drawing.Point(282, 492)
      Me.eui_cmdReimpostaFunzioniPiatti.Name = "eui_cmdReimpostaFunzioniPiatti"
      Me.eui_cmdReimpostaFunzioniPiatti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdReimpostaFunzioniPiatti.TabIndex = 267
      Me.eui_cmdReimpostaFunzioniPiatti.Text = "&Reimposta"
      '
      'tpSale
      '
      Me.tpSale.ActiveControl = Nothing
      Me.tpSale.Controls.Add(Me.GroupBox5)
      Me.tpSale.Controls.Add(Me.pnlSale)
      Me.tpSale.Controls.Add(Me.GroupBox2)
      Me.tpSale.Controls.Add(Me.lstSale)
      Me.tpSale.Controls.Add(Me.GroupBox1)
      Me.tpSale.Controls.Add(Me.eui_cmdReimpostaSale)
      Me.tpSale.Controls.Add(Me.eui_cmdSpostaGiuSale)
      Me.tpSale.Controls.Add(Me.eui_cmdSpostaSuSale)
      Me.tpSale.KeyTip = Nothing
      Me.tpSale.Name = "tpSale"
      Me.tpSale.Size = New System.Drawing.Size(690, 550)
      Me.tpSale.TabIndex = 0
      Me.tpSale.Text = "Sale"
      '
      'GroupBox5
      '
      Me.GroupBox5.Controls.Add(Me.Label14)
      Me.GroupBox5.Controls.Add(Me.netBtn_AnteprimaSale)
      Me.GroupBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox5.Id = "8c1c3a65-40c0-4264-b2fd-6288596b934a"
      Me.GroupBox5.Location = New System.Drawing.Point(388, 303)
      Me.GroupBox5.Name = "GroupBox5"
      Me.GroupBox5.Size = New System.Drawing.Size(289, 235)
      Me.GroupBox5.TabIndex = 255
      Me.GroupBox5.Text = "Anteprima"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.BackColor = System.Drawing.Color.Transparent
      Me.Label14.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label14.ForeColor = System.Drawing.Color.Black
      Me.Label14.Location = New System.Drawing.Point(13, 20)
      Me.Label14.Name = "Label14"
      Me.Label14.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label14.Size = New System.Drawing.Size(53, 20)
      Me.Label14.TabIndex = 255
      Me.Label14.Text = "Tasto:"
      '
      'netBtn_AnteprimaSale
      '
      Me.netBtn_AnteprimaSale.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_AnteprimaSale.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_AnteprimaSale.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_AnteprimaSale.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_AnteprimaSale.ColorText = System.Drawing.Color.White
      Me.netBtn_AnteprimaSale.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_AnteprimaSale.CornerRadius = 2
      Me.netBtn_AnteprimaSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_AnteprimaSale.Location = New System.Drawing.Point(120, 20)
      Me.netBtn_AnteprimaSale.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_AnteprimaSale.Name = "netBtn_AnteprimaSale"
      Me.netBtn_AnteprimaSale.Size = New System.Drawing.Size(150, 60)
      Me.netBtn_AnteprimaSale.TabIndex = 0
      Me.netBtn_AnteprimaSale.TextButton = ""
      '
      'pnlSale
      '
      Me.pnlSale.Location = New System.Drawing.Point(280, 116)
      Me.pnlSale.Name = "pnlSale"
      Me.pnlSale.Size = New System.Drawing.Size(96, 43)
      Me.pnlSale.TabIndex = 3
      Me.pnlSale.Visible = False
      '
      'GroupBox2
      '
      Me.GroupBox2.Controls.Add(Me.eui_nudAltezzaSale)
      Me.GroupBox2.Controls.Add(Me.Label5)
      Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox2.Id = "be50507f-040b-486e-bcdd-729b80c0288d"
      Me.GroupBox2.Location = New System.Drawing.Point(387, 207)
      Me.GroupBox2.Name = "GroupBox2"
      Me.GroupBox2.Size = New System.Drawing.Size(289, 80)
      Me.GroupBox2.TabIndex = 253
      Me.GroupBox2.Text = "Opzioni di gruppo"
      '
      'eui_nudAltezzaSale
      '
      Me.eui_nudAltezzaSale.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.eui_nudAltezzaSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_nudAltezzaSale.Id = "702b8a66-1bb9-459e-9830-cbc29910069e"
      Me.eui_nudAltezzaSale.Location = New System.Drawing.Point(169, 29)
      Me.eui_nudAltezzaSale.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
      Me.eui_nudAltezzaSale.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
      Me.eui_nudAltezzaSale.Name = "eui_nudAltezzaSale"
      Me.eui_nudAltezzaSale.Size = New System.Drawing.Size(101, 28)
      Me.eui_nudAltezzaSale.TabIndex = 0
      Me.eui_nudAltezzaSale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_nudAltezzaSale.TextEditorWidth = 78
      Me.eui_nudAltezzaSale.Value = New Decimal(New Integer() {50, 0, 0, 0})
      '
      'Label5
      '
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label5.Location = New System.Drawing.Point(18, 33)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(91, 20)
      Me.Label5.TabIndex = 252
      Me.Label5.Text = "Altezza:"
      '
      'lstSale
      '
      Me.lstSale.FormattingEnabled = True
      Me.lstSale.ItemHeight = 20
      Me.lstSale.Location = New System.Drawing.Point(12, 14)
      Me.lstSale.Name = "lstSale"
      Me.lstSale.Size = New System.Drawing.Size(266, 524)
      Me.lstSale.TabIndex = 0
      '
      'GroupBox1
      '
      Me.GroupBox1.Controls.Add(Me.Label13)
      Me.GroupBox1.Controls.Add(Me.eui_ddwnStileColoreSale)
      Me.GroupBox1.Controls.Add(Me.cmdColoreTestoSale)
      Me.GroupBox1.Controls.Add(Me.cmdColoreSfondoSale)
      Me.GroupBox1.Controls.Add(Me.Label3)
      Me.GroupBox1.Controls.Add(Me.Label2)
      Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox1.Id = "904084cd-0d95-4440-b8b5-de53d0114fb2"
      Me.GroupBox1.Location = New System.Drawing.Point(388, 14)
      Me.GroupBox1.Name = "GroupBox1"
      Me.GroupBox1.Size = New System.Drawing.Size(289, 175)
      Me.GroupBox1.TabIndex = 5
      Me.GroupBox1.Text = "Opzioni singolo elemento"
      '
      'Label13
      '
      Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label13.Location = New System.Drawing.Point(17, 32)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(108, 20)
      Me.Label13.TabIndex = 267
      Me.Label13.Text = "Stile colore:"
      '
      'eui_ddwnStileColoreSale
      '
      Me.eui_ddwnStileColoreSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_ddwnStileColoreSale.Id = "05e53216-160e-448c-8d47-6f2b2bfe72be"
      Me.eui_ddwnStileColoreSale.Location = New System.Drawing.Point(168, 29)
      Me.eui_ddwnStileColoreSale.Name = "eui_ddwnStileColoreSale"
      Me.eui_ddwnStileColoreSale.Popup = Me.PopupMenu1
      Me.eui_ddwnStileColoreSale.Size = New System.Drawing.Size(102, 28)
      Me.eui_ddwnStileColoreSale.TabIndex = 0
      Me.eui_ddwnStileColoreSale.Text = "Predefinito"
      '
      'cmdColoreTestoSale
      '
      Me.cmdColoreTestoSale.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreTestoSale.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreTestoSale.Location = New System.Drawing.Point(168, 119)
      Me.cmdColoreTestoSale.Name = "cmdColoreTestoSale"
      Me.cmdColoreTestoSale.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreTestoSale.TabIndex = 2
      Me.cmdColoreTestoSale.UseVisualStyleBackColor = False
      '
      'cmdColoreSfondoSale
      '
      Me.cmdColoreSfondoSale.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreSfondoSale.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreSfondoSale.Location = New System.Drawing.Point(168, 73)
      Me.cmdColoreSfondoSale.Name = "cmdColoreSfondoSale"
      Me.cmdColoreSfondoSale.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreSfondoSale.TabIndex = 1
      Me.cmdColoreSfondoSale.UseVisualStyleBackColor = False
      '
      'Label3
      '
      Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label3.Location = New System.Drawing.Point(18, 119)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(108, 20)
      Me.Label3.TabIndex = 253
      Me.Label3.Text = "Colore testo:"
      '
      'Label2
      '
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label2.Location = New System.Drawing.Point(18, 73)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(108, 20)
      Me.Label2.TabIndex = 252
      Me.Label2.Text = "Colore sfondo:"
      '
      'eui_cmdReimpostaSale
      '
      Me.eui_cmdReimpostaSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdReimpostaSale.Id = "ba71207d-7180-404f-9516-39b8c2adce0e"
      Me.eui_cmdReimpostaSale.Location = New System.Drawing.Point(280, 493)
      Me.eui_cmdReimpostaSale.Name = "eui_cmdReimpostaSale"
      Me.eui_cmdReimpostaSale.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdReimpostaSale.TabIndex = 3
      Me.eui_cmdReimpostaSale.Text = "&Reimposta"
      '
      'eui_cmdSpostaGiuSale
      '
      Me.eui_cmdSpostaGiuSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSpostaGiuSale.Id = "5002a0e1-7df4-4224-bd66-995c2388c63e"
      Me.eui_cmdSpostaGiuSale.Location = New System.Drawing.Point(281, 68)
      Me.eui_cmdSpostaGiuSale.Name = "eui_cmdSpostaGiuSale"
      Me.eui_cmdSpostaGiuSale.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdSpostaGiuSale.TabIndex = 2
      Me.eui_cmdSpostaGiuSale.Text = "Sposta in &Basso"
      '
      'eui_cmdSpostaSuSale
      '
      Me.eui_cmdSpostaSuSale.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSpostaSuSale.Id = "55c773d6-4913-463b-8ff9-ec59c9e29f17"
      Me.eui_cmdSpostaSuSale.Location = New System.Drawing.Point(281, 14)
      Me.eui_cmdSpostaSuSale.Name = "eui_cmdSpostaSuSale"
      Me.eui_cmdSpostaSuSale.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdSpostaSuSale.TabIndex = 1
      Me.eui_cmdSpostaSuSale.Text = "Sposta in &Alto"
      '
      'tpTavoli
      '
      Me.tpTavoli.ActiveControl = Nothing
      Me.tpTavoli.Controls.Add(Me.pnlTavoli)
      Me.tpTavoli.Controls.Add(Me.TabControl2)
      Me.tpTavoli.Controls.Add(Me.lstTavoli)
      Me.tpTavoli.Controls.Add(Me.eui_cmdReimpostaTavoli)
      Me.tpTavoli.Controls.Add(Me.eui_cmdSpostaGiuTavoli)
      Me.tpTavoli.Controls.Add(Me.eui_cmdSpostaSuTavoli)
      Me.tpTavoli.KeyTip = Nothing
      Me.tpTavoli.Name = "tpTavoli"
      Me.tpTavoli.Size = New System.Drawing.Size(690, 550)
      Me.tpTavoli.TabIndex = 1
      Me.tpTavoli.Text = "Tavoli"
      '
      'pnlTavoli
      '
      Me.pnlTavoli.Location = New System.Drawing.Point(283, 122)
      Me.pnlTavoli.Name = "pnlTavoli"
      Me.pnlTavoli.Size = New System.Drawing.Size(96, 43)
      Me.pnlTavoli.TabIndex = 264
      Me.pnlTavoli.Visible = False
      '
      'TabControl2
      '
      Me.TabControl2.EndScrollButtonVisible = True
      Me.TabControl2.Location = New System.Drawing.Point(386, 16)
      Me.TabControl2.Name = "TabControl2"
      Me.TabControl2.SelectedTabPage = Me.TabPage2
      Me.TabControl2.Size = New System.Drawing.Size(292, 519)
      Me.TabControl2.TabIndex = 248
      Me.TabControl2.TabPages.AddRange(New Elegant.Ui.TabPage() {Me.TabPage2, Me.TabPage1})
      Me.TabControl2.Text = "TabControl2"
      '
      'TabPage2
      '
      Me.TabPage2.ActiveControl = Nothing
      Me.TabPage2.Controls.Add(Me.GroupBox9)
      Me.TabPage2.Controls.Add(Me.GroupBox3)
      Me.TabPage2.KeyTip = Nothing
      Me.TabPage2.Name = "TabPage2"
      Me.TabPage2.Size = New System.Drawing.Size(290, 491)
      Me.TabPage2.TabIndex = 1
      Me.TabPage2.Text = "Modalità Tasti"
      '
      'GroupBox9
      '
      Me.GroupBox9.Controls.Add(Me.netBtn_AnteprimaTavoli)
      Me.GroupBox9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox9.Id = "3507eaee-6d5a-4fdc-845a-58d2263a35b0"
      Me.GroupBox9.Location = New System.Drawing.Point(13, 212)
      Me.GroupBox9.Name = "GroupBox9"
      Me.GroupBox9.Size = New System.Drawing.Size(266, 266)
      Me.GroupBox9.TabIndex = 265
      Me.GroupBox9.Text = "Anteprima Tasto"
      '
      'netBtn_AnteprimaTavoli
      '
      Me.netBtn_AnteprimaTavoli.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_AnteprimaTavoli.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_AnteprimaTavoli.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_AnteprimaTavoli.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_AnteprimaTavoli.ColorText = System.Drawing.Color.White
      Me.netBtn_AnteprimaTavoli.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_AnteprimaTavoli.CornerRadius = 2
      Me.netBtn_AnteprimaTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_AnteprimaTavoli.Location = New System.Drawing.Point(16, 28)
      Me.netBtn_AnteprimaTavoli.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_AnteprimaTavoli.Name = "netBtn_AnteprimaTavoli"
      Me.netBtn_AnteprimaTavoli.Size = New System.Drawing.Size(150, 60)
      Me.netBtn_AnteprimaTavoli.TabIndex = 0
      Me.netBtn_AnteprimaTavoli.TextButton = ""
      '
      'GroupBox3
      '
      Me.GroupBox3.Controls.Add(Me.eui_nudLarghezzaTavoli)
      Me.GroupBox3.Controls.Add(Me.eui_nudAltezzaTavoli)
      Me.GroupBox3.Controls.Add(Me.eui_nudNumTastiRigaTavoli)
      Me.GroupBox3.Controls.Add(Me.Label7)
      Me.GroupBox3.Controls.Add(Me.Label8)
      Me.GroupBox3.Controls.Add(Me.Label9)
      Me.GroupBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox3.Id = "9b153b32-2388-4de7-826f-415dc173e638"
      Me.GroupBox3.Location = New System.Drawing.Point(11, 13)
      Me.GroupBox3.Name = "GroupBox3"
      Me.GroupBox3.Size = New System.Drawing.Size(266, 176)
      Me.GroupBox3.TabIndex = 259
      Me.GroupBox3.Text = "Modalità Tasti - Opzioni di gruppo"
      '
      'eui_nudLarghezzaTavoli
      '
      Me.eui_nudLarghezzaTavoli.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.eui_nudLarghezzaTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_nudLarghezzaTavoli.Id = "ee2a9dd4-4e8b-4590-af4b-8b650696a83a"
      Me.eui_nudLarghezzaTavoli.Location = New System.Drawing.Point(179, 74)
      Me.eui_nudLarghezzaTavoli.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
      Me.eui_nudLarghezzaTavoli.Name = "eui_nudLarghezzaTavoli"
      Me.eui_nudLarghezzaTavoli.Size = New System.Drawing.Size(74, 28)
      Me.eui_nudLarghezzaTavoli.TabIndex = 1
      Me.eui_nudLarghezzaTavoli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_nudLarghezzaTavoli.TextEditorWidth = 51
      '
      'eui_nudAltezzaTavoli
      '
      Me.eui_nudAltezzaTavoli.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.eui_nudAltezzaTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_nudAltezzaTavoli.Id = "7cfd5f87-caa7-498d-96c0-c78ee3fc0efd"
      Me.eui_nudAltezzaTavoli.Location = New System.Drawing.Point(179, 29)
      Me.eui_nudAltezzaTavoli.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
      Me.eui_nudAltezzaTavoli.Minimum = New Decimal(New Integer() {50, 0, 0, 0})
      Me.eui_nudAltezzaTavoli.Name = "eui_nudAltezzaTavoli"
      Me.eui_nudAltezzaTavoli.Size = New System.Drawing.Size(74, 28)
      Me.eui_nudAltezzaTavoli.TabIndex = 0
      Me.eui_nudAltezzaTavoli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_nudAltezzaTavoli.TextEditorWidth = 51
      Me.eui_nudAltezzaTavoli.Value = New Decimal(New Integer() {50, 0, 0, 0})
      '
      'eui_nudNumTastiRigaTavoli
      '
      Me.eui_nudNumTastiRigaTavoli.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.eui_nudNumTastiRigaTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_nudNumTastiRigaTavoli.Id = "f803cf33-7380-413a-b5a7-796bc57c9fbc"
      Me.eui_nudNumTastiRigaTavoli.Location = New System.Drawing.Point(179, 129)
      Me.eui_nudNumTastiRigaTavoli.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.eui_nudNumTastiRigaTavoli.Name = "eui_nudNumTastiRigaTavoli"
      Me.eui_nudNumTastiRigaTavoli.Size = New System.Drawing.Size(74, 28)
      Me.eui_nudNumTastiRigaTavoli.TabIndex = 2
      Me.eui_nudNumTastiRigaTavoli.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_nudNumTastiRigaTavoli.TextEditorWidth = 51
      Me.eui_nudNumTastiRigaTavoli.Value = New Decimal(New Integer() {5, 0, 0, 0})
      '
      'Label7
      '
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label7.Location = New System.Drawing.Point(17, 129)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(151, 20)
      Me.Label7.TabIndex = 256
      Me.Label7.Text = "Numero tasti per riga:"
      '
      'Label8
      '
      Me.Label8.AutoSize = False
      Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label8.Location = New System.Drawing.Point(17, 69)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(136, 56)
      Me.Label8.TabIndex = 253
      Me.Label8.Text = "Larghezza: (0=Automatica)"
      '
      'Label9
      '
      Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label9.Location = New System.Drawing.Point(17, 29)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(91, 20)
      Me.Label9.TabIndex = 252
      Me.Label9.Text = "Altezza:"
      '
      'TabPage1
      '
      Me.TabPage1.ActiveControl = Nothing
      Me.TabPage1.Controls.Add(Me.GroupBox10)
      Me.TabPage1.Controls.Add(Me.GroupBox8)
      Me.TabPage1.Controls.Add(Me.GroupBox4)
      Me.TabPage1.KeyTip = Nothing
      Me.TabPage1.Name = "TabPage1"
      Me.TabPage1.Size = New System.Drawing.Size(290, 491)
      Me.TabPage1.TabIndex = 0
      Me.TabPage1.Text = "Modalità Piantina"
      '
      'GroupBox10
      '
      Me.GroupBox10.Controls.Add(Me.netBtn_AnteprimaTavoliPiantina)
      Me.GroupBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox10.Id = "68138f40-cbcd-4a70-970e-6a5db0838655"
      Me.GroupBox10.Location = New System.Drawing.Point(13, 252)
      Me.GroupBox10.Name = "GroupBox10"
      Me.GroupBox10.Size = New System.Drawing.Size(266, 226)
      Me.GroupBox10.TabIndex = 266
      Me.GroupBox10.Text = "Anteprima tasto"
      '
      'netBtn_AnteprimaTavoliPiantina
      '
      Me.netBtn_AnteprimaTavoliPiantina.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_AnteprimaTavoliPiantina.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_AnteprimaTavoliPiantina.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_AnteprimaTavoliPiantina.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_AnteprimaTavoliPiantina.ColorText = System.Drawing.Color.White
      Me.netBtn_AnteprimaTavoliPiantina.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_AnteprimaTavoliPiantina.CornerRadius = 2
      Me.netBtn_AnteprimaTavoliPiantina.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_AnteprimaTavoliPiantina.Location = New System.Drawing.Point(17, 20)
      Me.netBtn_AnteprimaTavoliPiantina.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_AnteprimaTavoliPiantina.Name = "netBtn_AnteprimaTavoliPiantina"
      Me.netBtn_AnteprimaTavoliPiantina.Size = New System.Drawing.Size(150, 60)
      Me.netBtn_AnteprimaTavoliPiantina.TabIndex = 0
      Me.netBtn_AnteprimaTavoliPiantina.TextButton = ""
      '
      'GroupBox8
      '
      Me.GroupBox8.Controls.Add(Me.eui_ddwnDimensioneTavoli)
      Me.GroupBox8.Controls.Add(Me.Label12)
      Me.GroupBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox8.Id = "3fd1d606-265b-4b8b-bc2e-b427049b7dca"
      Me.GroupBox8.Location = New System.Drawing.Point(13, 164)
      Me.GroupBox8.Name = "GroupBox8"
      Me.GroupBox8.Size = New System.Drawing.Size(266, 73)
      Me.GroupBox8.TabIndex = 264
      Me.GroupBox8.Text = "Opzioni di gruppo"
      '
      'eui_ddwnDimensioneTavoli
      '
      Me.eui_ddwnDimensioneTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_ddwnDimensioneTavoli.Id = "cc8402ea-4816-4fae-ac09-4f7441e97147"
      Me.eui_ddwnDimensioneTavoli.Location = New System.Drawing.Point(166, 26)
      Me.eui_ddwnDimensioneTavoli.Name = "eui_ddwnDimensioneTavoli"
      Me.eui_ddwnDimensioneTavoli.Popup = Me.PopupMenu3
      Me.eui_ddwnDimensioneTavoli.Size = New System.Drawing.Size(87, 28)
      Me.eui_ddwnDimensioneTavoli.TabIndex = 263
      Me.eui_ddwnDimensioneTavoli.Text = "Medio"
      '
      'PopupMenu3
      '
      Me.PopupMenu3.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_btnTastoPiccolo, Me.eui_btnTastoMedio, Me.eui_btnTastoGrande})
      Me.PopupMenu3.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu3.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu3.Size = New System.Drawing.Size(100, 100)
      '
      'eui_btnTastoPiccolo
      '
      Me.eui_btnTastoPiccolo.Id = "048494e6-60af-4c74-8722-8a7dbc0465b2"
      Me.eui_btnTastoPiccolo.Location = New System.Drawing.Point(2, 2)
      Me.eui_btnTastoPiccolo.Name = "eui_btnTastoPiccolo"
      Me.eui_btnTastoPiccolo.Size = New System.Drawing.Size(126, 23)
      Me.eui_btnTastoPiccolo.TabIndex = 17
      Me.eui_btnTastoPiccolo.Text = "Piccolo"
      '
      'eui_btnTastoMedio
      '
      Me.eui_btnTastoMedio.Id = "1bae4dd3-7cf3-4861-aacb-1bf00a235b69"
      Me.eui_btnTastoMedio.Location = New System.Drawing.Point(2, 25)
      Me.eui_btnTastoMedio.Name = "eui_btnTastoMedio"
      Me.eui_btnTastoMedio.Size = New System.Drawing.Size(126, 23)
      Me.eui_btnTastoMedio.TabIndex = 18
      Me.eui_btnTastoMedio.Text = "Medio"
      '
      'eui_btnTastoGrande
      '
      Me.eui_btnTastoGrande.Id = "fb8a1218-4336-455f-a3dd-d60ec346b2d8"
      Me.eui_btnTastoGrande.Location = New System.Drawing.Point(2, 48)
      Me.eui_btnTastoGrande.Name = "eui_btnTastoGrande"
      Me.eui_btnTastoGrande.Size = New System.Drawing.Size(126, 23)
      Me.eui_btnTastoGrande.TabIndex = 19
      Me.eui_btnTastoGrande.Text = "Grande"
      '
      'Label12
      '
      Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label12.Location = New System.Drawing.Point(17, 29)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(136, 20)
      Me.Label12.TabIndex = 262
      Me.Label12.Text = "Dimensione tasto:"
      '
      'GroupBox4
      '
      Me.GroupBox4.Controls.Add(Me.eui_ddwnOrientamentoTavoli)
      Me.GroupBox4.Controls.Add(Me.eui_nudDimensionePosti)
      Me.GroupBox4.Controls.Add(Me.Label10)
      Me.GroupBox4.Controls.Add(Me.Label11)
      Me.GroupBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox4.Id = "b5a8ccc2-a21f-46c3-aae3-d0533da3cbee"
      Me.GroupBox4.Location = New System.Drawing.Point(13, 13)
      Me.GroupBox4.Name = "GroupBox4"
      Me.GroupBox4.Size = New System.Drawing.Size(266, 130)
      Me.GroupBox4.TabIndex = 258
      Me.GroupBox4.Text = "Opzioni singolo elemento"
      '
      'eui_ddwnOrientamentoTavoli
      '
      Me.eui_ddwnOrientamentoTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_ddwnOrientamentoTavoli.Id = "a46e1bfd-6817-434a-be5b-1130a77c88d4"
      Me.eui_ddwnOrientamentoTavoli.Location = New System.Drawing.Point(165, 70)
      Me.eui_ddwnOrientamentoTavoli.Name = "eui_ddwnOrientamentoTavoli"
      Me.eui_ddwnOrientamentoTavoli.Popup = Me.PopupMenu2
      Me.eui_ddwnOrientamentoTavoli.Size = New System.Drawing.Size(87, 28)
      Me.eui_ddwnOrientamentoTavoli.TabIndex = 262
      Me.eui_ddwnOrientamentoTavoli.Text = "Orizzontale"
      '
      'PopupMenu2
      '
      Me.PopupMenu2.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_btnOrizzontale, Me.eui_btnVerticale})
      Me.PopupMenu2.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu2.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu2.Size = New System.Drawing.Size(100, 100)
      '
      'eui_btnOrizzontale
      '
      Me.eui_btnOrizzontale.Id = "f892afb3-1d10-411d-937d-7fdeb28d6f0a"
      Me.eui_btnOrizzontale.Location = New System.Drawing.Point(2, 2)
      Me.eui_btnOrizzontale.Name = "eui_btnOrizzontale"
      Me.eui_btnOrizzontale.Size = New System.Drawing.Size(126, 23)
      Me.eui_btnOrizzontale.TabIndex = 17
      Me.eui_btnOrizzontale.Text = "Orizzontale"
      '
      'eui_btnVerticale
      '
      Me.eui_btnVerticale.Id = "826c64e5-434f-4500-8fb1-a990f7551aa4"
      Me.eui_btnVerticale.Location = New System.Drawing.Point(2, 25)
      Me.eui_btnVerticale.Name = "eui_btnVerticale"
      Me.eui_btnVerticale.Size = New System.Drawing.Size(126, 23)
      Me.eui_btnVerticale.TabIndex = 18
      Me.eui_btnVerticale.Text = "Verticale"
      '
      'eui_nudDimensionePosti
      '
      Me.eui_nudDimensionePosti.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.eui_nudDimensionePosti.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_nudDimensionePosti.Id = "31981755-35d3-4b20-a184-3fe3a6354b89"
      Me.eui_nudDimensionePosti.Location = New System.Drawing.Point(165, 30)
      Me.eui_nudDimensionePosti.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.eui_nudDimensionePosti.Name = "eui_nudDimensionePosti"
      Me.eui_nudDimensionePosti.Size = New System.Drawing.Size(87, 28)
      Me.eui_nudDimensionePosti.TabIndex = 261
      Me.eui_nudDimensionePosti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_nudDimensionePosti.TextEditorWidth = 64
      Me.eui_nudDimensionePosti.Value = New Decimal(New Integer() {1, 0, 0, 0})
      '
      'Label10
      '
      Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label10.Location = New System.Drawing.Point(17, 73)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(108, 20)
      Me.Label10.TabIndex = 253
      Me.Label10.Text = "Orientamento:"
      '
      'Label11
      '
      Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label11.Location = New System.Drawing.Point(17, 30)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(136, 20)
      Me.Label11.TabIndex = 252
      Me.Label11.Text = "Dimensione (posti):"
      '
      'lstTavoli
      '
      Me.lstTavoli.FormattingEnabled = True
      Me.lstTavoli.ItemHeight = 20
      Me.lstTavoli.Location = New System.Drawing.Point(12, 14)
      Me.lstTavoli.Name = "lstTavoli"
      Me.lstTavoli.Size = New System.Drawing.Size(266, 524)
      Me.lstTavoli.TabIndex = 0
      '
      'eui_cmdReimpostaTavoli
      '
      Me.eui_cmdReimpostaTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdReimpostaTavoli.Id = "3af69fcb-c24d-4483-b8e9-1c2eac56b617"
      Me.eui_cmdReimpostaTavoli.Location = New System.Drawing.Point(280, 493)
      Me.eui_cmdReimpostaTavoli.Name = "eui_cmdReimpostaTavoli"
      Me.eui_cmdReimpostaTavoli.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdReimpostaTavoli.TabIndex = 3
      Me.eui_cmdReimpostaTavoli.Text = "&Reimposta"
      '
      'eui_cmdSpostaGiuTavoli
      '
      Me.eui_cmdSpostaGiuTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSpostaGiuTavoli.Id = "1f3386ce-2a4b-45e7-acae-fc2d4d72eaee"
      Me.eui_cmdSpostaGiuTavoli.Location = New System.Drawing.Point(281, 68)
      Me.eui_cmdSpostaGiuTavoli.Name = "eui_cmdSpostaGiuTavoli"
      Me.eui_cmdSpostaGiuTavoli.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdSpostaGiuTavoli.TabIndex = 2
      Me.eui_cmdSpostaGiuTavoli.Text = "Sposta in &Basso"
      '
      'eui_cmdSpostaSuTavoli
      '
      Me.eui_cmdSpostaSuTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSpostaSuTavoli.Id = "bbd71055-ba78-4855-866e-2ff506873d28"
      Me.eui_cmdSpostaSuTavoli.Location = New System.Drawing.Point(281, 14)
      Me.eui_cmdSpostaSuTavoli.Name = "eui_cmdSpostaSuTavoli"
      Me.eui_cmdSpostaSuTavoli.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdSpostaSuTavoli.TabIndex = 1
      Me.eui_cmdSpostaSuTavoli.Text = "Sposta in &Alto"
      '
      'tpFunzioniTavoli
      '
      Me.tpFunzioniTavoli.ActiveControl = Nothing
      Me.tpFunzioniTavoli.Controls.Add(Me.pnlFunzioniTavoli)
      Me.tpFunzioniTavoli.Controls.Add(Me.GroupBox7)
      Me.tpFunzioniTavoli.Controls.Add(Me.lstFunzioniTavoli)
      Me.tpFunzioniTavoli.Controls.Add(Me.GroupBox6)
      Me.tpFunzioniTavoli.Controls.Add(Me.eui_cmdReimpostaFunzioniTavoli)
      Me.tpFunzioniTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.tpFunzioniTavoli.KeyTip = Nothing
      Me.tpFunzioniTavoli.Name = "tpFunzioniTavoli"
      Me.tpFunzioniTavoli.Size = New System.Drawing.Size(690, 550)
      Me.tpFunzioniTavoli.TabIndex = 2
      Me.tpFunzioniTavoli.Text = "Funzioni"
      '
      'pnlFunzioniTavoli
      '
      Me.pnlFunzioniTavoli.Location = New System.Drawing.Point(283, 23)
      Me.pnlFunzioniTavoli.Name = "pnlFunzioniTavoli"
      Me.pnlFunzioniTavoli.Size = New System.Drawing.Size(96, 43)
      Me.pnlFunzioniTavoli.TabIndex = 265
      Me.pnlFunzioniTavoli.Visible = False
      '
      'GroupBox7
      '
      Me.GroupBox7.Controls.Add(Me.netBtn_AnteprimaFunzioniTavoli)
      Me.GroupBox7.Controls.Add(Me.Label4)
      Me.GroupBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox7.Id = "0733d5c1-6c68-40e9-a1c2-59ad499feebd"
      Me.GroupBox7.Location = New System.Drawing.Point(391, 287)
      Me.GroupBox7.Name = "GroupBox7"
      Me.GroupBox7.Size = New System.Drawing.Size(285, 251)
      Me.GroupBox7.TabIndex = 264
      Me.GroupBox7.Text = "Anteprima"
      '
      'netBtn_AnteprimaFunzioniTavoli
      '
      Me.netBtn_AnteprimaFunzioniTavoli.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_AnteprimaFunzioniTavoli.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_AnteprimaFunzioniTavoli.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_AnteprimaFunzioniTavoli.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_AnteprimaFunzioniTavoli.ColorText = System.Drawing.SystemColors.ControlText
      Me.netBtn_AnteprimaFunzioniTavoli.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_AnteprimaFunzioniTavoli.CornerRadius = 2
      Me.netBtn_AnteprimaFunzioniTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_AnteprimaFunzioniTavoli.Location = New System.Drawing.Point(120, 16)
      Me.netBtn_AnteprimaFunzioniTavoli.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_AnteprimaFunzioniTavoli.Name = "netBtn_AnteprimaFunzioniTavoli"
      Me.netBtn_AnteprimaFunzioniTavoli.Size = New System.Drawing.Size(150, 60)
      Me.netBtn_AnteprimaFunzioniTavoli.TabIndex = 0
      Me.netBtn_AnteprimaFunzioniTavoli.TextButton = ""
      '
      'Label4
      '
      Me.Label4.AutoSize = True
      Me.Label4.BackColor = System.Drawing.Color.Transparent
      Me.Label4.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label4.ForeColor = System.Drawing.Color.Black
      Me.Label4.Location = New System.Drawing.Point(14, 16)
      Me.Label4.Name = "Label4"
      Me.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label4.Size = New System.Drawing.Size(53, 20)
      Me.Label4.TabIndex = 254
      Me.Label4.Text = "Tasto:"
      '
      'lstFunzioniTavoli
      '
      Me.lstFunzioniTavoli.FormattingEnabled = True
      Me.lstFunzioniTavoli.ItemHeight = 20
      Me.lstFunzioniTavoli.Location = New System.Drawing.Point(12, 14)
      Me.lstFunzioniTavoli.Name = "lstFunzioniTavoli"
      Me.lstFunzioniTavoli.Size = New System.Drawing.Size(266, 524)
      Me.lstFunzioniTavoli.TabIndex = 0
      '
      'GroupBox6
      '
      Me.GroupBox6.Controls.Add(Me.Label6)
      Me.GroupBox6.Controls.Add(Me.eui_ddwnStileColoreFunzioniTavoli)
      Me.GroupBox6.Controls.Add(Me.cmdColoreSfondoFunzioniTavoli)
      Me.GroupBox6.Controls.Add(Me.cmdColoreTestoFunzioniTavoli)
      Me.GroupBox6.Controls.Add(Me.Label15)
      Me.GroupBox6.Controls.Add(Me.Label16)
      Me.GroupBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox6.Id = "5b8c8c65-734c-462c-803c-87ae9bbcdc03"
      Me.GroupBox6.Location = New System.Drawing.Point(391, 14)
      Me.GroupBox6.Name = "GroupBox6"
      Me.GroupBox6.Size = New System.Drawing.Size(285, 250)
      Me.GroupBox6.TabIndex = 258
      Me.GroupBox6.Text = "Opzioni singolo elemento"
      '
      'Label6
      '
      Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label6.Location = New System.Drawing.Point(12, 35)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(108, 20)
      Me.Label6.TabIndex = 265
      Me.Label6.Text = "Stile colore:"
      '
      'eui_ddwnStileColoreFunzioniTavoli
      '
      Me.eui_ddwnStileColoreFunzioniTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_ddwnStileColoreFunzioniTavoli.Id = "1e466a86-e5d8-449d-b312-29790227bbaf"
      Me.eui_ddwnStileColoreFunzioniTavoli.Location = New System.Drawing.Point(164, 32)
      Me.eui_ddwnStileColoreFunzioniTavoli.Name = "eui_ddwnStileColoreFunzioniTavoli"
      Me.eui_ddwnStileColoreFunzioniTavoli.Popup = Me.PopupMenu1
      Me.eui_ddwnStileColoreFunzioniTavoli.Size = New System.Drawing.Size(106, 28)
      Me.eui_ddwnStileColoreFunzioniTavoli.TabIndex = 0
      Me.eui_ddwnStileColoreFunzioniTavoli.Text = "Predefinito"
      '
      'cmdColoreSfondoFunzioniTavoli
      '
      Me.cmdColoreSfondoFunzioniTavoli.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreSfondoFunzioniTavoli.Enabled = False
      Me.cmdColoreSfondoFunzioniTavoli.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreSfondoFunzioniTavoli.Location = New System.Drawing.Point(165, 77)
      Me.cmdColoreSfondoFunzioniTavoli.Name = "cmdColoreSfondoFunzioniTavoli"
      Me.cmdColoreSfondoFunzioniTavoli.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreSfondoFunzioniTavoli.TabIndex = 1
      Me.cmdColoreSfondoFunzioniTavoli.UseVisualStyleBackColor = False
      '
      'cmdColoreTestoFunzioniTavoli
      '
      Me.cmdColoreTestoFunzioniTavoli.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreTestoFunzioniTavoli.Enabled = False
      Me.cmdColoreTestoFunzioniTavoli.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreTestoFunzioniTavoli.Location = New System.Drawing.Point(164, 124)
      Me.cmdColoreTestoFunzioniTavoli.Name = "cmdColoreTestoFunzioniTavoli"
      Me.cmdColoreTestoFunzioniTavoli.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreTestoFunzioniTavoli.TabIndex = 2
      Me.cmdColoreTestoFunzioniTavoli.UseVisualStyleBackColor = False
      '
      'Label15
      '
      Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label15.Location = New System.Drawing.Point(12, 127)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(108, 20)
      Me.Label15.TabIndex = 253
      Me.Label15.Text = "Colore testo:"
      '
      'Label16
      '
      Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label16.Location = New System.Drawing.Point(12, 76)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(108, 20)
      Me.Label16.TabIndex = 252
      Me.Label16.Text = "Colore sfondo:"
      '
      'eui_cmdReimpostaFunzioniTavoli
      '
      Me.eui_cmdReimpostaFunzioniTavoli.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdReimpostaFunzioniTavoli.Id = "7d128295-d521-4dee-bc30-2f5f4500b1d3"
      Me.eui_cmdReimpostaFunzioniTavoli.Location = New System.Drawing.Point(281, 493)
      Me.eui_cmdReimpostaFunzioniTavoli.Name = "eui_cmdReimpostaFunzioniTavoli"
      Me.eui_cmdReimpostaFunzioniTavoli.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdReimpostaFunzioniTavoli.TabIndex = 1
      Me.eui_cmdReimpostaFunzioniTavoli.Text = "&Reimposta"
      '
      'tpCategorie
      '
      Me.tpCategorie.ActiveControl = Nothing
      Me.tpCategorie.Controls.Add(Me.eui_cmdRimuoviImgCategorie)
      Me.tpCategorie.Controls.Add(Me.eui_cmdInserisciImgCategorie)
      Me.tpCategorie.Controls.Add(Me.GroupBox11)
      Me.tpCategorie.Controls.Add(Me.pnlCategorie)
      Me.tpCategorie.Controls.Add(Me.GroupBox12)
      Me.tpCategorie.Controls.Add(Me.lstCategorie)
      Me.tpCategorie.Controls.Add(Me.GroupBox13)
      Me.tpCategorie.Controls.Add(Me.eui_cmdReimpostaCategorie)
      Me.tpCategorie.Controls.Add(Me.eui_cmdSpostaGiùCategorie)
      Me.tpCategorie.Controls.Add(Me.eui_cmdSpostaSuCategorie)
      Me.tpCategorie.KeyTip = Nothing
      Me.tpCategorie.Name = "tpCategorie"
      Me.tpCategorie.Size = New System.Drawing.Size(690, 550)
      Me.tpCategorie.TabIndex = 3
      Me.tpCategorie.Text = "Categorie Piatti"
      '
      'eui_cmdRimuoviImgCategorie
      '
      Me.eui_cmdRimuoviImgCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdRimuoviImgCategorie.Id = "9b31171a-2a4b-44f7-b4e9-bcfbd575a0f8"
      Me.eui_cmdRimuoviImgCategorie.Location = New System.Drawing.Point(281, 432)
      Me.eui_cmdRimuoviImgCategorie.Name = "eui_cmdRimuoviImgCategorie"
      Me.eui_cmdRimuoviImgCategorie.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdRimuoviImgCategorie.TabIndex = 4
      Me.eui_cmdRimuoviImgCategorie.Text = "&Rimuovi immagine"
      '
      'eui_cmdInserisciImgCategorie
      '
      Me.eui_cmdInserisciImgCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdInserisciImgCategorie.Id = "769aff4d-982d-4bfb-bb45-6c501039a9b8"
      Me.eui_cmdInserisciImgCategorie.Location = New System.Drawing.Point(281, 378)
      Me.eui_cmdInserisciImgCategorie.Name = "eui_cmdInserisciImgCategorie"
      Me.eui_cmdInserisciImgCategorie.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdInserisciImgCategorie.TabIndex = 3
      Me.eui_cmdInserisciImgCategorie.Text = "&Inserisci immagine"
      '
      'GroupBox11
      '
      Me.GroupBox11.Controls.Add(Me.Label17)
      Me.GroupBox11.Controls.Add(Me.netBtn_AnteprimaCategorie)
      Me.GroupBox11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox11.Id = "f3fff239-a10c-4475-8557-85ba84bf6f9e"
      Me.GroupBox11.Location = New System.Drawing.Point(389, 302)
      Me.GroupBox11.Name = "GroupBox11"
      Me.GroupBox11.Size = New System.Drawing.Size(289, 234)
      Me.GroupBox11.TabIndex = 263
      Me.GroupBox11.Text = "Anteprima"
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.BackColor = System.Drawing.Color.Transparent
      Me.Label17.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label17.ForeColor = System.Drawing.Color.Black
      Me.Label17.Location = New System.Drawing.Point(13, 20)
      Me.Label17.Name = "Label17"
      Me.Label17.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label17.Size = New System.Drawing.Size(53, 20)
      Me.Label17.TabIndex = 255
      Me.Label17.Text = "Tasto:"
      '
      'netBtn_AnteprimaCategorie
      '
      Me.netBtn_AnteprimaCategorie.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_AnteprimaCategorie.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_AnteprimaCategorie.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_AnteprimaCategorie.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_AnteprimaCategorie.ColorText = System.Drawing.Color.White
      Me.netBtn_AnteprimaCategorie.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_AnteprimaCategorie.CornerRadius = 2
      Me.netBtn_AnteprimaCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_AnteprimaCategorie.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.netBtn_AnteprimaCategorie.Location = New System.Drawing.Point(120, 20)
      Me.netBtn_AnteprimaCategorie.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_AnteprimaCategorie.Name = "netBtn_AnteprimaCategorie"
      Me.netBtn_AnteprimaCategorie.Size = New System.Drawing.Size(150, 60)
      Me.netBtn_AnteprimaCategorie.TabIndex = 0
      Me.netBtn_AnteprimaCategorie.TextButton = ""
      '
      'pnlCategorie
      '
      Me.pnlCategorie.Location = New System.Drawing.Point(281, 115)
      Me.pnlCategorie.Name = "pnlCategorie"
      Me.pnlCategorie.Size = New System.Drawing.Size(96, 43)
      Me.pnlCategorie.TabIndex = 259
      Me.pnlCategorie.Visible = False
      '
      'GroupBox12
      '
      Me.GroupBox12.Controls.Add(Me.eui_nudAltezzaCategorie)
      Me.GroupBox12.Controls.Add(Me.Label18)
      Me.GroupBox12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox12.Id = "7b1a4543-272d-4ec2-9b7d-1630b917e9b1"
      Me.GroupBox12.Location = New System.Drawing.Point(388, 206)
      Me.GroupBox12.Name = "GroupBox12"
      Me.GroupBox12.Size = New System.Drawing.Size(289, 80)
      Me.GroupBox12.TabIndex = 262
      Me.GroupBox12.Text = "Opzioni di gruppo"
      '
      'eui_nudAltezzaCategorie
      '
      Me.eui_nudAltezzaCategorie.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.eui_nudAltezzaCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_nudAltezzaCategorie.Id = "7736ec00-2102-4f7f-8526-0109d0b5f2d8"
      Me.eui_nudAltezzaCategorie.Location = New System.Drawing.Point(169, 29)
      Me.eui_nudAltezzaCategorie.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
      Me.eui_nudAltezzaCategorie.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
      Me.eui_nudAltezzaCategorie.Name = "eui_nudAltezzaCategorie"
      Me.eui_nudAltezzaCategorie.Size = New System.Drawing.Size(101, 28)
      Me.eui_nudAltezzaCategorie.TabIndex = 0
      Me.eui_nudAltezzaCategorie.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_nudAltezzaCategorie.TextEditorWidth = 78
      Me.eui_nudAltezzaCategorie.Value = New Decimal(New Integer() {50, 0, 0, 0})
      '
      'Label18
      '
      Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label18.Location = New System.Drawing.Point(18, 33)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(91, 20)
      Me.Label18.TabIndex = 252
      Me.Label18.Text = "Altezza:"
      '
      'lstCategorie
      '
      Me.lstCategorie.FormattingEnabled = True
      Me.lstCategorie.ItemHeight = 20
      Me.lstCategorie.Location = New System.Drawing.Point(13, 13)
      Me.lstCategorie.Name = "lstCategorie"
      Me.lstCategorie.Size = New System.Drawing.Size(266, 524)
      Me.lstCategorie.TabIndex = 0
      '
      'GroupBox13
      '
      Me.GroupBox13.Controls.Add(Me.Label19)
      Me.GroupBox13.Controls.Add(Me.eui_ddwnStileColoreCategorie)
      Me.GroupBox13.Controls.Add(Me.cmdColoreTestoCategorie)
      Me.GroupBox13.Controls.Add(Me.cmdColoreSfondoCategorie)
      Me.GroupBox13.Controls.Add(Me.Label20)
      Me.GroupBox13.Controls.Add(Me.Label21)
      Me.GroupBox13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox13.Id = "55c55a39-9491-4afb-94c1-1175b7e4e7b8"
      Me.GroupBox13.Location = New System.Drawing.Point(389, 13)
      Me.GroupBox13.Name = "GroupBox13"
      Me.GroupBox13.Size = New System.Drawing.Size(289, 175)
      Me.GroupBox13.TabIndex = 261
      Me.GroupBox13.Text = "Opzioni singolo elemento"
      '
      'Label19
      '
      Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label19.Location = New System.Drawing.Point(17, 32)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(108, 20)
      Me.Label19.TabIndex = 267
      Me.Label19.Text = "Stile colore:"
      '
      'eui_ddwnStileColoreCategorie
      '
      Me.eui_ddwnStileColoreCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_ddwnStileColoreCategorie.Id = "8babaf2b-a330-42f0-8de5-5b715e60b033"
      Me.eui_ddwnStileColoreCategorie.Location = New System.Drawing.Point(168, 29)
      Me.eui_ddwnStileColoreCategorie.Name = "eui_ddwnStileColoreCategorie"
      Me.eui_ddwnStileColoreCategorie.Popup = Me.PopupMenu1
      Me.eui_ddwnStileColoreCategorie.Size = New System.Drawing.Size(102, 28)
      Me.eui_ddwnStileColoreCategorie.TabIndex = 0
      Me.eui_ddwnStileColoreCategorie.Text = "Predefinito"
      '
      'cmdColoreTestoCategorie
      '
      Me.cmdColoreTestoCategorie.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreTestoCategorie.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreTestoCategorie.Location = New System.Drawing.Point(168, 119)
      Me.cmdColoreTestoCategorie.Name = "cmdColoreTestoCategorie"
      Me.cmdColoreTestoCategorie.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreTestoCategorie.TabIndex = 2
      Me.cmdColoreTestoCategorie.UseVisualStyleBackColor = False
      '
      'cmdColoreSfondoCategorie
      '
      Me.cmdColoreSfondoCategorie.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreSfondoCategorie.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreSfondoCategorie.Location = New System.Drawing.Point(168, 73)
      Me.cmdColoreSfondoCategorie.Name = "cmdColoreSfondoCategorie"
      Me.cmdColoreSfondoCategorie.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreSfondoCategorie.TabIndex = 1
      Me.cmdColoreSfondoCategorie.UseVisualStyleBackColor = False
      '
      'Label20
      '
      Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label20.Location = New System.Drawing.Point(18, 119)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(108, 20)
      Me.Label20.TabIndex = 253
      Me.Label20.Text = "Colore testo:"
      '
      'Label21
      '
      Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label21.Location = New System.Drawing.Point(18, 73)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(108, 20)
      Me.Label21.TabIndex = 252
      Me.Label21.Text = "Colore sfondo:"
      '
      'eui_cmdReimpostaCategorie
      '
      Me.eui_cmdReimpostaCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdReimpostaCategorie.Id = "acfb2e0d-caeb-426c-9c88-d5f37bf57ef5"
      Me.eui_cmdReimpostaCategorie.Location = New System.Drawing.Point(281, 492)
      Me.eui_cmdReimpostaCategorie.Name = "eui_cmdReimpostaCategorie"
      Me.eui_cmdReimpostaCategorie.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdReimpostaCategorie.TabIndex = 5
      Me.eui_cmdReimpostaCategorie.Text = "&Reimposta"
      '
      'eui_cmdSpostaGiùCategorie
      '
      Me.eui_cmdSpostaGiùCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSpostaGiùCategorie.Id = "35d0e312-51f7-4134-9b64-c015c2cd5aaf"
      Me.eui_cmdSpostaGiùCategorie.Location = New System.Drawing.Point(282, 67)
      Me.eui_cmdSpostaGiùCategorie.Name = "eui_cmdSpostaGiùCategorie"
      Me.eui_cmdSpostaGiùCategorie.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdSpostaGiùCategorie.TabIndex = 2
      Me.eui_cmdSpostaGiùCategorie.Text = "Sposta in &Basso"
      '
      'eui_cmdSpostaSuCategorie
      '
      Me.eui_cmdSpostaSuCategorie.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSpostaSuCategorie.Id = "980e85d1-5cec-4f33-84f6-50255580e164"
      Me.eui_cmdSpostaSuCategorie.Location = New System.Drawing.Point(282, 13)
      Me.eui_cmdSpostaSuCategorie.Name = "eui_cmdSpostaSuCategorie"
      Me.eui_cmdSpostaSuCategorie.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdSpostaSuCategorie.TabIndex = 1
      Me.eui_cmdSpostaSuCategorie.Text = "Sposta in &Alto"
      '
      'tpPiatti
      '
      Me.tpPiatti.ActiveControl = Nothing
      Me.tpPiatti.Controls.Add(Me.eui_cmdRimuoviImgPiatti)
      Me.tpPiatti.Controls.Add(Me.eui_cmdInserisciImgPiatti)
      Me.tpPiatti.Controls.Add(Me.GroupBox14)
      Me.tpPiatti.Controls.Add(Me.pnlPiatti)
      Me.tpPiatti.Controls.Add(Me.GroupBox15)
      Me.tpPiatti.Controls.Add(Me.lstPiatti)
      Me.tpPiatti.Controls.Add(Me.GroupBox16)
      Me.tpPiatti.Controls.Add(Me.eui_cmdReimpostaPiatti)
      Me.tpPiatti.Controls.Add(Me.eui_cmdSpostaGiùPiatti)
      Me.tpPiatti.Controls.Add(Me.eui_cmdSpostaSuPiatti)
      Me.tpPiatti.KeyTip = Nothing
      Me.tpPiatti.Name = "tpPiatti"
      Me.tpPiatti.Size = New System.Drawing.Size(690, 550)
      Me.tpPiatti.TabIndex = 4
      Me.tpPiatti.Text = "Piatti"
      '
      'eui_cmdRimuoviImgPiatti
      '
      Me.eui_cmdRimuoviImgPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdRimuoviImgPiatti.Id = "e44e4ce2-1b17-4237-bcb2-3fc25dcc071e"
      Me.eui_cmdRimuoviImgPiatti.Location = New System.Drawing.Point(281, 432)
      Me.eui_cmdRimuoviImgPiatti.Name = "eui_cmdRimuoviImgPiatti"
      Me.eui_cmdRimuoviImgPiatti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdRimuoviImgPiatti.TabIndex = 4
      Me.eui_cmdRimuoviImgPiatti.Text = "&Rimuovi immagine"
      '
      'eui_cmdInserisciImgPiatti
      '
      Me.eui_cmdInserisciImgPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdInserisciImgPiatti.Id = "5e5d0871-38a2-4e43-a4c3-fe5dc5457f1f"
      Me.eui_cmdInserisciImgPiatti.Location = New System.Drawing.Point(281, 378)
      Me.eui_cmdInserisciImgPiatti.Name = "eui_cmdInserisciImgPiatti"
      Me.eui_cmdInserisciImgPiatti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdInserisciImgPiatti.TabIndex = 3
      Me.eui_cmdInserisciImgPiatti.Text = "&Inserisci immagine"
      '
      'GroupBox14
      '
      Me.GroupBox14.Controls.Add(Me.netBtn_AnteprimaPiatti)
      Me.GroupBox14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox14.Id = "57494511-f7d2-4e69-ad7e-c9269d1e5ec3"
      Me.GroupBox14.Location = New System.Drawing.Point(388, 344)
      Me.GroupBox14.Name = "GroupBox14"
      Me.GroupBox14.Size = New System.Drawing.Size(289, 192)
      Me.GroupBox14.TabIndex = 273
      Me.GroupBox14.Text = "Anteprima Tasto"
      '
      'netBtn_AnteprimaPiatti
      '
      Me.netBtn_AnteprimaPiatti.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_AnteprimaPiatti.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_AnteprimaPiatti.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_AnteprimaPiatti.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_AnteprimaPiatti.ColorText = System.Drawing.Color.White
      Me.netBtn_AnteprimaPiatti.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_AnteprimaPiatti.CornerRadius = 2
      Me.netBtn_AnteprimaPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_AnteprimaPiatti.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.netBtn_AnteprimaPiatti.Location = New System.Drawing.Point(11, 19)
      Me.netBtn_AnteprimaPiatti.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_AnteprimaPiatti.Name = "netBtn_AnteprimaPiatti"
      Me.netBtn_AnteprimaPiatti.Size = New System.Drawing.Size(150, 60)
      Me.netBtn_AnteprimaPiatti.TabIndex = 0
      Me.netBtn_AnteprimaPiatti.TextButton = ""
      '
      'pnlPiatti
      '
      Me.pnlPiatti.Location = New System.Drawing.Point(281, 115)
      Me.pnlPiatti.Name = "pnlPiatti"
      Me.pnlPiatti.Size = New System.Drawing.Size(96, 43)
      Me.pnlPiatti.TabIndex = 270
      Me.pnlPiatti.Visible = False
      '
      'GroupBox15
      '
      Me.GroupBox15.Controls.Add(Me.eui_nudLarghezzaPiatti)
      Me.GroupBox15.Controls.Add(Me.eui_nudNumTastiRigaPiatti)
      Me.GroupBox15.Controls.Add(Me.Label27)
      Me.GroupBox15.Controls.Add(Me.Label28)
      Me.GroupBox15.Controls.Add(Me.eui_nudAltezzaPiatti)
      Me.GroupBox15.Controls.Add(Me.Label23)
      Me.GroupBox15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox15.Id = "fbaccf1a-c7cf-437d-82bd-6d822d4fa5ad"
      Me.GroupBox15.Location = New System.Drawing.Point(389, 176)
      Me.GroupBox15.Name = "GroupBox15"
      Me.GroupBox15.Size = New System.Drawing.Size(289, 160)
      Me.GroupBox15.TabIndex = 272
      Me.GroupBox15.Text = "Opzioni di gruppo"
      '
      'eui_nudLarghezzaPiatti
      '
      Me.eui_nudLarghezzaPiatti.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.eui_nudLarghezzaPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_nudLarghezzaPiatti.Id = "eb4bd174-c68b-44d8-a409-58bb1c47a37a"
      Me.eui_nudLarghezzaPiatti.Location = New System.Drawing.Point(195, 72)
      Me.eui_nudLarghezzaPiatti.Maximum = New Decimal(New Integer() {300, 0, 0, 0})
      Me.eui_nudLarghezzaPiatti.Name = "eui_nudLarghezzaPiatti"
      Me.eui_nudLarghezzaPiatti.Size = New System.Drawing.Size(74, 28)
      Me.eui_nudLarghezzaPiatti.TabIndex = 1
      Me.eui_nudLarghezzaPiatti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_nudLarghezzaPiatti.TextEditorWidth = 51
      '
      'eui_nudNumTastiRigaPiatti
      '
      Me.eui_nudNumTastiRigaPiatti.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.eui_nudNumTastiRigaPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_nudNumTastiRigaPiatti.Id = "735bbd6f-5539-4143-9509-dc64924cc18e"
      Me.eui_nudNumTastiRigaPiatti.Location = New System.Drawing.Point(195, 120)
      Me.eui_nudNumTastiRigaPiatti.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
      Me.eui_nudNumTastiRigaPiatti.Name = "eui_nudNumTastiRigaPiatti"
      Me.eui_nudNumTastiRigaPiatti.Size = New System.Drawing.Size(74, 28)
      Me.eui_nudNumTastiRigaPiatti.TabIndex = 2
      Me.eui_nudNumTastiRigaPiatti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_nudNumTastiRigaPiatti.TextEditorWidth = 51
      Me.eui_nudNumTastiRigaPiatti.Value = New Decimal(New Integer() {5, 0, 0, 0})
      '
      'Label27
      '
      Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label27.Location = New System.Drawing.Point(14, 120)
      Me.Label27.Name = "Label27"
      Me.Label27.Size = New System.Drawing.Size(151, 20)
      Me.Label27.TabIndex = 260
      Me.Label27.Text = "Numero tasti per riga:"
      '
      'Label28
      '
      Me.Label28.AutoSize = False
      Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label28.Location = New System.Drawing.Point(14, 67)
      Me.Label28.Name = "Label28"
      Me.Label28.Size = New System.Drawing.Size(136, 45)
      Me.Label28.TabIndex = 259
      Me.Label28.Text = "Larghezza: (0=Automatica)"
      '
      'eui_nudAltezzaPiatti
      '
      Me.eui_nudAltezzaPiatti.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.eui_nudAltezzaPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_nudAltezzaPiatti.Id = "d79d1493-c961-4591-9256-7be5b102b3d2"
      Me.eui_nudAltezzaPiatti.Location = New System.Drawing.Point(195, 24)
      Me.eui_nudAltezzaPiatti.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
      Me.eui_nudAltezzaPiatti.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
      Me.eui_nudAltezzaPiatti.Name = "eui_nudAltezzaPiatti"
      Me.eui_nudAltezzaPiatti.Size = New System.Drawing.Size(74, 28)
      Me.eui_nudAltezzaPiatti.TabIndex = 0
      Me.eui_nudAltezzaPiatti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_nudAltezzaPiatti.TextEditorWidth = 51
      Me.eui_nudAltezzaPiatti.Value = New Decimal(New Integer() {50, 0, 0, 0})
      '
      'Label23
      '
      Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label23.Location = New System.Drawing.Point(17, 28)
      Me.Label23.Name = "Label23"
      Me.Label23.Size = New System.Drawing.Size(91, 20)
      Me.Label23.TabIndex = 252
      Me.Label23.Text = "Altezza:"
      '
      'lstPiatti
      '
      Me.lstPiatti.FormattingEnabled = True
      Me.lstPiatti.ItemHeight = 20
      Me.lstPiatti.Location = New System.Drawing.Point(13, 13)
      Me.lstPiatti.Name = "lstPiatti"
      Me.lstPiatti.Size = New System.Drawing.Size(266, 524)
      Me.lstPiatti.TabIndex = 0
      '
      'GroupBox16
      '
      Me.GroupBox16.Controls.Add(Me.Label24)
      Me.GroupBox16.Controls.Add(Me.eui_ddwnStileColorePiatti)
      Me.GroupBox16.Controls.Add(Me.cmdColoreTestoPiatti)
      Me.GroupBox16.Controls.Add(Me.cmdColoreSfondoPiatti)
      Me.GroupBox16.Controls.Add(Me.Label25)
      Me.GroupBox16.Controls.Add(Me.Label26)
      Me.GroupBox16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox16.Id = "2ef27929-7b4e-4f6b-933d-1156fe1c43d1"
      Me.GroupBox16.Location = New System.Drawing.Point(389, 13)
      Me.GroupBox16.Name = "GroupBox16"
      Me.GroupBox16.Size = New System.Drawing.Size(289, 155)
      Me.GroupBox16.TabIndex = 271
      Me.GroupBox16.Text = "Opzioni singolo elemento"
      '
      'Label24
      '
      Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label24.Location = New System.Drawing.Point(17, 32)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(108, 20)
      Me.Label24.TabIndex = 267
      Me.Label24.Text = "Stile colore:"
      '
      'eui_ddwnStileColorePiatti
      '
      Me.eui_ddwnStileColorePiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_ddwnStileColorePiatti.Id = "83755172-b188-4101-a404-9b7a664315dc"
      Me.eui_ddwnStileColorePiatti.Location = New System.Drawing.Point(168, 29)
      Me.eui_ddwnStileColorePiatti.Name = "eui_ddwnStileColorePiatti"
      Me.eui_ddwnStileColorePiatti.Popup = Me.PopupMenu1
      Me.eui_ddwnStileColorePiatti.Size = New System.Drawing.Size(102, 28)
      Me.eui_ddwnStileColorePiatti.TabIndex = 0
      Me.eui_ddwnStileColorePiatti.Text = "Predefinito"
      '
      'cmdColoreTestoPiatti
      '
      Me.cmdColoreTestoPiatti.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreTestoPiatti.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreTestoPiatti.Location = New System.Drawing.Point(168, 111)
      Me.cmdColoreTestoPiatti.Name = "cmdColoreTestoPiatti"
      Me.cmdColoreTestoPiatti.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreTestoPiatti.TabIndex = 2
      Me.cmdColoreTestoPiatti.UseVisualStyleBackColor = False
      '
      'cmdColoreSfondoPiatti
      '
      Me.cmdColoreSfondoPiatti.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreSfondoPiatti.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreSfondoPiatti.Location = New System.Drawing.Point(168, 72)
      Me.cmdColoreSfondoPiatti.Name = "cmdColoreSfondoPiatti"
      Me.cmdColoreSfondoPiatti.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreSfondoPiatti.TabIndex = 1
      Me.cmdColoreSfondoPiatti.UseVisualStyleBackColor = False
      '
      'Label25
      '
      Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label25.Location = New System.Drawing.Point(18, 111)
      Me.Label25.Name = "Label25"
      Me.Label25.Size = New System.Drawing.Size(108, 20)
      Me.Label25.TabIndex = 253
      Me.Label25.Text = "Colore testo:"
      '
      'Label26
      '
      Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label26.Location = New System.Drawing.Point(18, 72)
      Me.Label26.Name = "Label26"
      Me.Label26.Size = New System.Drawing.Size(108, 20)
      Me.Label26.TabIndex = 252
      Me.Label26.Text = "Colore sfondo:"
      '
      'eui_cmdReimpostaPiatti
      '
      Me.eui_cmdReimpostaPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdReimpostaPiatti.Id = "00ce9f99-78fd-43bc-b6d0-3e70805f78e8"
      Me.eui_cmdReimpostaPiatti.Location = New System.Drawing.Point(281, 492)
      Me.eui_cmdReimpostaPiatti.Name = "eui_cmdReimpostaPiatti"
      Me.eui_cmdReimpostaPiatti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdReimpostaPiatti.TabIndex = 5
      Me.eui_cmdReimpostaPiatti.Text = "&Reimposta"
      '
      'eui_cmdSpostaGiùPiatti
      '
      Me.eui_cmdSpostaGiùPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSpostaGiùPiatti.Id = "402e65b7-2aad-497a-94a0-a3ad1101a6d0"
      Me.eui_cmdSpostaGiùPiatti.Location = New System.Drawing.Point(282, 67)
      Me.eui_cmdSpostaGiùPiatti.Name = "eui_cmdSpostaGiùPiatti"
      Me.eui_cmdSpostaGiùPiatti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdSpostaGiùPiatti.TabIndex = 2
      Me.eui_cmdSpostaGiùPiatti.Text = "Sposta in &Basso"
      '
      'eui_cmdSpostaSuPiatti
      '
      Me.eui_cmdSpostaSuPiatti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSpostaSuPiatti.Id = "0edf6174-431c-4186-a9a6-9c51f834c8f2"
      Me.eui_cmdSpostaSuPiatti.Location = New System.Drawing.Point(282, 13)
      Me.eui_cmdSpostaSuPiatti.Name = "eui_cmdSpostaSuPiatti"
      Me.eui_cmdSpostaSuPiatti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdSpostaSuPiatti.TabIndex = 1
      Me.eui_cmdSpostaSuPiatti.Text = "Sposta in &Alto"
      '
      'tpVarianti
      '
      Me.tpVarianti.ActiveControl = Nothing
      Me.tpVarianti.Controls.Add(Me.eui_cmdRimuoviImgVarianti)
      Me.tpVarianti.Controls.Add(Me.eui_cmdInserisciImgVarianti)
      Me.tpVarianti.Controls.Add(Me.GroupBox17)
      Me.tpVarianti.Controls.Add(Me.pnlVarianti)
      Me.tpVarianti.Controls.Add(Me.GroupBox18)
      Me.tpVarianti.Controls.Add(Me.lstVarianti)
      Me.tpVarianti.Controls.Add(Me.GroupBox19)
      Me.tpVarianti.Controls.Add(Me.eui_cmdReimpostaVarianti)
      Me.tpVarianti.Controls.Add(Me.eui_cmdSpostaGiùVarianti)
      Me.tpVarianti.Controls.Add(Me.eui_cmdSpostaSuVarianti)
      Me.tpVarianti.KeyTip = Nothing
      Me.tpVarianti.Name = "tpVarianti"
      Me.tpVarianti.Size = New System.Drawing.Size(690, 550)
      Me.tpVarianti.TabIndex = 5
      Me.tpVarianti.Text = "Varianti"
      '
      'eui_cmdRimuoviImgVarianti
      '
      Me.eui_cmdRimuoviImgVarianti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdRimuoviImgVarianti.Id = "53470201-636e-4ded-afb5-a5a5344dc34e"
      Me.eui_cmdRimuoviImgVarianti.Location = New System.Drawing.Point(281, 432)
      Me.eui_cmdRimuoviImgVarianti.Name = "eui_cmdRimuoviImgVarianti"
      Me.eui_cmdRimuoviImgVarianti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdRimuoviImgVarianti.TabIndex = 268
      Me.eui_cmdRimuoviImgVarianti.Text = "&Rimuovi immagine"
      '
      'eui_cmdInserisciImgVarianti
      '
      Me.eui_cmdInserisciImgVarianti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdInserisciImgVarianti.Id = "c7f524b3-0a66-4376-9d48-c2c0721e1a94"
      Me.eui_cmdInserisciImgVarianti.Location = New System.Drawing.Point(281, 378)
      Me.eui_cmdInserisciImgVarianti.Name = "eui_cmdInserisciImgVarianti"
      Me.eui_cmdInserisciImgVarianti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdInserisciImgVarianti.TabIndex = 267
      Me.eui_cmdInserisciImgVarianti.Text = "&Inserisci immagine"
      '
      'GroupBox17
      '
      Me.GroupBox17.Controls.Add(Me.Label22)
      Me.GroupBox17.Controls.Add(Me.netBtn_AnteprimaVarianti)
      Me.GroupBox17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox17.Id = "35b7e126-fd32-42fd-9f84-422f00f80098"
      Me.GroupBox17.Location = New System.Drawing.Point(389, 302)
      Me.GroupBox17.Name = "GroupBox17"
      Me.GroupBox17.Size = New System.Drawing.Size(289, 234)
      Me.GroupBox17.TabIndex = 273
      Me.GroupBox17.Text = "Anteprima"
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.BackColor = System.Drawing.Color.Transparent
      Me.Label22.Cursor = System.Windows.Forms.Cursors.Default
      Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label22.ForeColor = System.Drawing.Color.Black
      Me.Label22.Location = New System.Drawing.Point(13, 20)
      Me.Label22.Name = "Label22"
      Me.Label22.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.Label22.Size = New System.Drawing.Size(53, 20)
      Me.Label22.TabIndex = 255
      Me.Label22.Text = "Tasto:"
      '
      'netBtn_AnteprimaVarianti
      '
      Me.netBtn_AnteprimaVarianti.ColorBottom = System.Drawing.Color.Black
      Me.netBtn_AnteprimaVarianti.ColorDisabled = System.Drawing.Color.DimGray
      Me.netBtn_AnteprimaVarianti.ColorLight = System.Drawing.SystemColors.HighlightText
      Me.netBtn_AnteprimaVarianti.ColorStyle = Softgroup.NetButton.NetButton.ColorStyleEnum.Custom
      Me.netBtn_AnteprimaVarianti.ColorText = System.Drawing.Color.White
      Me.netBtn_AnteprimaVarianti.ColorTop = System.Drawing.SystemColors.ControlLightLight
      Me.netBtn_AnteprimaVarianti.CornerRadius = 2
      Me.netBtn_AnteprimaVarianti.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.netBtn_AnteprimaVarianti.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.netBtn_AnteprimaVarianti.Location = New System.Drawing.Point(120, 20)
      Me.netBtn_AnteprimaVarianti.Margin = New System.Windows.Forms.Padding(5, 4, 5, 4)
      Me.netBtn_AnteprimaVarianti.Name = "netBtn_AnteprimaVarianti"
      Me.netBtn_AnteprimaVarianti.Size = New System.Drawing.Size(150, 60)
      Me.netBtn_AnteprimaVarianti.TabIndex = 0
      Me.netBtn_AnteprimaVarianti.TextButton = ""
      '
      'pnlVarianti
      '
      Me.pnlVarianti.Location = New System.Drawing.Point(281, 115)
      Me.pnlVarianti.Name = "pnlVarianti"
      Me.pnlVarianti.Size = New System.Drawing.Size(96, 43)
      Me.pnlVarianti.TabIndex = 270
      Me.pnlVarianti.Visible = False
      '
      'GroupBox18
      '
      Me.GroupBox18.Controls.Add(Me.eui_nudAltezzaVarianti)
      Me.GroupBox18.Controls.Add(Me.Label29)
      Me.GroupBox18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox18.Id = "eee5efc0-1da3-46ba-8c33-6155d8ed389e"
      Me.GroupBox18.Location = New System.Drawing.Point(388, 206)
      Me.GroupBox18.Name = "GroupBox18"
      Me.GroupBox18.Size = New System.Drawing.Size(289, 80)
      Me.GroupBox18.TabIndex = 272
      Me.GroupBox18.Text = "Opzioni di gruppo"
      '
      'eui_nudAltezzaVarianti
      '
      Me.eui_nudAltezzaVarianti.BannerTextStyle = System.Drawing.FontStyle.Regular
      Me.eui_nudAltezzaVarianti.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_nudAltezzaVarianti.Id = "349ae741-b635-4b7e-bd0d-4a04bda0c96c"
      Me.eui_nudAltezzaVarianti.Location = New System.Drawing.Point(169, 29)
      Me.eui_nudAltezzaVarianti.Maximum = New Decimal(New Integer() {200, 0, 0, 0})
      Me.eui_nudAltezzaVarianti.Minimum = New Decimal(New Integer() {20, 0, 0, 0})
      Me.eui_nudAltezzaVarianti.Name = "eui_nudAltezzaVarianti"
      Me.eui_nudAltezzaVarianti.Size = New System.Drawing.Size(101, 28)
      Me.eui_nudAltezzaVarianti.TabIndex = 0
      Me.eui_nudAltezzaVarianti.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.eui_nudAltezzaVarianti.TextEditorWidth = 78
      Me.eui_nudAltezzaVarianti.Value = New Decimal(New Integer() {50, 0, 0, 0})
      '
      'Label29
      '
      Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label29.Location = New System.Drawing.Point(18, 33)
      Me.Label29.Name = "Label29"
      Me.Label29.Size = New System.Drawing.Size(91, 20)
      Me.Label29.TabIndex = 252
      Me.Label29.Text = "Altezza:"
      '
      'lstVarianti
      '
      Me.lstVarianti.FormattingEnabled = True
      Me.lstVarianti.ItemHeight = 20
      Me.lstVarianti.Location = New System.Drawing.Point(13, 13)
      Me.lstVarianti.Name = "lstVarianti"
      Me.lstVarianti.Size = New System.Drawing.Size(266, 524)
      Me.lstVarianti.TabIndex = 264
      '
      'GroupBox19
      '
      Me.GroupBox19.Controls.Add(Me.Label30)
      Me.GroupBox19.Controls.Add(Me.eui_ddwnStileColoreVarianti)
      Me.GroupBox19.Controls.Add(Me.cmdColoreTestoVarianti)
      Me.GroupBox19.Controls.Add(Me.cmdColoreSfondoVarianti)
      Me.GroupBox19.Controls.Add(Me.Label31)
      Me.GroupBox19.Controls.Add(Me.Label32)
      Me.GroupBox19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.GroupBox19.Id = "61c9bffe-eb2d-44c3-bd98-e68ad635a2ba"
      Me.GroupBox19.Location = New System.Drawing.Point(389, 13)
      Me.GroupBox19.Name = "GroupBox19"
      Me.GroupBox19.Size = New System.Drawing.Size(289, 175)
      Me.GroupBox19.TabIndex = 271
      Me.GroupBox19.Text = "Opzioni singolo elemento"
      '
      'Label30
      '
      Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label30.Location = New System.Drawing.Point(17, 32)
      Me.Label30.Name = "Label30"
      Me.Label30.Size = New System.Drawing.Size(108, 20)
      Me.Label30.TabIndex = 267
      Me.Label30.Text = "Stile colore:"
      '
      'eui_ddwnStileColoreVarianti
      '
      Me.eui_ddwnStileColoreVarianti.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_ddwnStileColoreVarianti.Id = "60f11edb-1767-48d1-aebb-4242df32aace"
      Me.eui_ddwnStileColoreVarianti.Location = New System.Drawing.Point(168, 29)
      Me.eui_ddwnStileColoreVarianti.Name = "eui_ddwnStileColoreVarianti"
      Me.eui_ddwnStileColoreVarianti.Popup = Me.PopupMenu1
      Me.eui_ddwnStileColoreVarianti.Size = New System.Drawing.Size(102, 28)
      Me.eui_ddwnStileColoreVarianti.TabIndex = 0
      Me.eui_ddwnStileColoreVarianti.Text = "Predefinito"
      '
      'cmdColoreTestoVarianti
      '
      Me.cmdColoreTestoVarianti.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreTestoVarianti.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreTestoVarianti.Location = New System.Drawing.Point(168, 119)
      Me.cmdColoreTestoVarianti.Name = "cmdColoreTestoVarianti"
      Me.cmdColoreTestoVarianti.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreTestoVarianti.TabIndex = 2
      Me.cmdColoreTestoVarianti.UseVisualStyleBackColor = False
      '
      'cmdColoreSfondoVarianti
      '
      Me.cmdColoreSfondoVarianti.BackColor = System.Drawing.SystemColors.Control
      Me.cmdColoreSfondoVarianti.FlatStyle = System.Windows.Forms.FlatStyle.Popup
      Me.cmdColoreSfondoVarianti.Location = New System.Drawing.Point(168, 73)
      Me.cmdColoreSfondoVarianti.Name = "cmdColoreSfondoVarianti"
      Me.cmdColoreSfondoVarianti.Size = New System.Drawing.Size(102, 28)
      Me.cmdColoreSfondoVarianti.TabIndex = 1
      Me.cmdColoreSfondoVarianti.UseVisualStyleBackColor = False
      '
      'Label31
      '
      Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label31.Location = New System.Drawing.Point(18, 119)
      Me.Label31.Name = "Label31"
      Me.Label31.Size = New System.Drawing.Size(108, 20)
      Me.Label31.TabIndex = 253
      Me.Label31.Text = "Colore testo:"
      '
      'Label32
      '
      Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label32.Location = New System.Drawing.Point(18, 73)
      Me.Label32.Name = "Label32"
      Me.Label32.Size = New System.Drawing.Size(108, 20)
      Me.Label32.TabIndex = 252
      Me.Label32.Text = "Colore sfondo:"
      '
      'eui_cmdReimpostaVarianti
      '
      Me.eui_cmdReimpostaVarianti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdReimpostaVarianti.Id = "733cbd44-2812-4b8d-8ac4-d52089cefbdb"
      Me.eui_cmdReimpostaVarianti.Location = New System.Drawing.Point(281, 492)
      Me.eui_cmdReimpostaVarianti.Name = "eui_cmdReimpostaVarianti"
      Me.eui_cmdReimpostaVarianti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdReimpostaVarianti.TabIndex = 269
      Me.eui_cmdReimpostaVarianti.Text = "&Reimposta"
      '
      'eui_cmdSpostaGiùVarianti
      '
      Me.eui_cmdSpostaGiùVarianti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSpostaGiùVarianti.Id = "dc82d208-ac1d-46ec-8e47-67c90dd289a4"
      Me.eui_cmdSpostaGiùVarianti.Location = New System.Drawing.Point(282, 67)
      Me.eui_cmdSpostaGiùVarianti.Name = "eui_cmdSpostaGiùVarianti"
      Me.eui_cmdSpostaGiùVarianti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdSpostaGiùVarianti.TabIndex = 266
      Me.eui_cmdSpostaGiùVarianti.Text = "Sposta in &Basso"
      '
      'eui_cmdSpostaSuVarianti
      '
      Me.eui_cmdSpostaSuVarianti.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdSpostaSuVarianti.Id = "4a28cc92-0b3c-4399-b1c1-51d01ba3d854"
      Me.eui_cmdSpostaSuVarianti.Location = New System.Drawing.Point(282, 13)
      Me.eui_cmdSpostaSuVarianti.Name = "eui_cmdSpostaSuVarianti"
      Me.eui_cmdSpostaSuVarianti.Size = New System.Drawing.Size(96, 45)
      Me.eui_cmdSpostaSuVarianti.TabIndex = 265
      Me.eui_cmdSpostaSuVarianti.Text = "Sposta in &Alto"
      '
      'eui_cmdOK
      '
      Me.eui_cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdOK.Id = "a2b67520-3937-4e73-9344-9cd89b9f1ccc"
      Me.eui_cmdOK.Location = New System.Drawing.Point(712, 29)
      Me.eui_cmdOK.Name = "eui_cmdOK"
      Me.eui_cmdOK.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdOK.TabIndex = 0
      Me.eui_cmdOK.Text = "&OK"
      '
      'eui_cmdAnnulla
      '
      Me.eui_cmdAnnulla.DialogResult = System.Windows.Forms.DialogResult.Cancel
      Me.eui_cmdAnnulla.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.eui_cmdAnnulla.Id = "166c690d-1071-4880-8f4b-2c9f9f15c0ab"
      Me.eui_cmdAnnulla.Location = New System.Drawing.Point(712, 96)
      Me.eui_cmdAnnulla.Name = "eui_cmdAnnulla"
      Me.eui_cmdAnnulla.Size = New System.Drawing.Size(128, 53)
      Me.eui_cmdAnnulla.TabIndex = 1
      Me.eui_cmdAnnulla.Text = "&Annulla"
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Label1.Location = New System.Drawing.Point(10, 9)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(140, 20)
      Me.Label1.TabIndex = 247
      Me.Label1.Text = "Elenco tasti:"
      '
      'ImpostazioniPos
      '
      Me.AcceptButton = Me.eui_cmdOK
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.SystemColors.AppWorkspace
      Me.CancelButton = Me.eui_cmdAnnulla
      Me.ClientSize = New System.Drawing.Size(852, 614)
      Me.Controls.Add(Me.Label1)
      Me.Controls.Add(Me.eui_cmdAnnulla)
      Me.Controls.Add(Me.eui_cmdOK)
      Me.Controls.Add(Me.TabControl1)
      Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.MaximizeBox = False
      Me.MinimizeBox = False
      Me.Name = "ImpostazioniPos"
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "IMPOSTAZIONI"
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tpFunzioniPiatti.ResumeLayout(False)
      Me.GroupBox21.ResumeLayout(False)
      Me.GroupBox21.PerformLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox20.ResumeLayout(False)
      Me.GroupBox20.PerformLayout()
      Me.tpSale.ResumeLayout(False)
      Me.GroupBox5.ResumeLayout(False)
      Me.GroupBox5.PerformLayout()
      Me.GroupBox2.ResumeLayout(False)
      Me.GroupBox2.PerformLayout()
      CType(Me.eui_nudAltezzaSale, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox1.ResumeLayout(False)
      Me.GroupBox1.PerformLayout()
      Me.tpTavoli.ResumeLayout(False)
      CType(Me.TabControl2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage2.ResumeLayout(False)
      Me.GroupBox9.ResumeLayout(False)
      Me.GroupBox3.ResumeLayout(False)
      Me.GroupBox3.PerformLayout()
      CType(Me.eui_nudLarghezzaTavoli, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.eui_nudAltezzaTavoli, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.eui_nudNumTastiRigaTavoli, System.ComponentModel.ISupportInitialize).EndInit()
      Me.TabPage1.ResumeLayout(False)
      Me.GroupBox10.ResumeLayout(False)
      Me.GroupBox8.ResumeLayout(False)
      Me.GroupBox8.PerformLayout()
      CType(Me.PopupMenu3, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox4.ResumeLayout(False)
      Me.GroupBox4.PerformLayout()
      CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.eui_nudDimensionePosti, System.ComponentModel.ISupportInitialize).EndInit()
      Me.tpFunzioniTavoli.ResumeLayout(False)
      Me.GroupBox7.ResumeLayout(False)
      Me.GroupBox7.PerformLayout()
      Me.GroupBox6.ResumeLayout(False)
      Me.GroupBox6.PerformLayout()
      Me.tpCategorie.ResumeLayout(False)
      Me.GroupBox11.ResumeLayout(False)
      Me.GroupBox11.PerformLayout()
      Me.GroupBox12.ResumeLayout(False)
      Me.GroupBox12.PerformLayout()
      CType(Me.eui_nudAltezzaCategorie, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox13.ResumeLayout(False)
      Me.GroupBox13.PerformLayout()
      Me.tpPiatti.ResumeLayout(False)
      Me.GroupBox14.ResumeLayout(False)
      Me.GroupBox15.ResumeLayout(False)
      Me.GroupBox15.PerformLayout()
      CType(Me.eui_nudLarghezzaPiatti, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.eui_nudNumTastiRigaPiatti, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.eui_nudAltezzaPiatti, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox16.ResumeLayout(False)
      Me.GroupBox16.PerformLayout()
      Me.tpVarianti.ResumeLayout(False)
      Me.GroupBox17.ResumeLayout(False)
      Me.GroupBox17.PerformLayout()
      Me.GroupBox18.ResumeLayout(False)
      Me.GroupBox18.PerformLayout()
      CType(Me.eui_nudAltezzaVarianti, System.ComponentModel.ISupportInitialize).EndInit()
      Me.GroupBox19.ResumeLayout(False)
      Me.GroupBox19.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub

#End Region

   Private Function SalvaImpostazioni() As Boolean
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Select Case nomeFinestra
            Case "frmPos"
               ' PUNTO CASSA.

               If SalvaImpostazioniCategorie() = False Then
                  Return False
               End If

               If SalvaImpostazioniPiatti() = False Then
                  Return False
               End If

               If SalvaImpostazioniVarianti() = False Then
                  Return False
               End If

               If SalvaImpostazioniFunzioniPiatti() = False Then
                  Return False
               End If

            Case "frmVCTavoli"
               ' GESTIONE TAVOLI.

               If SalvaImpostazioniSale() = False Then
                  Return False
               End If

               If SalvaImpostazioniTavoli() = False Then
                  Return False
               End If

               If SalvaImpostazioniFunzioniTavoli() = False Then
                  Return False
               End If

         End Select

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Function

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

   Private Function LeggiNumRecordPiatti(ByVal tabella As String, ByVal variante As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT COUNT(*) FROM {0} WHERE Variazione = '" & variante & "'", tabella)
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

   Private Sub ImpostazioniPos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         Select Case nomeFinestra
            Case "frmPos"
               ' Nasconde le schede che non servono.
               tpSale.Visible = False
               tpTavoli.Visible = False
               tpFunzioniTavoli.Visible = False

               ' CATEGORIE PIATTI.
               ' Se nella tabella non ci sono record disattiva i pulsanti.
               If LeggiNumRecord(ANA_CATEGORIE) = 0 Then
                  tpCategorie.Enabled = True
               Else
                  CaricaListaCategorie(lstCategorie, "OrdineTasto", ANA_CATEGORIE)

                  ' Seleziona il primo elemento.
                  lstCategorie.SelectedIndex = 0
               End If

               ' PIATTI.
               ' Se nella tabella non ci sono record disattiva i pulsanti.
               If LeggiNumRecordPiatti(ANA_PIATTI, "No") = 0 Then
                  tpPiatti.Enabled = True
               Else
                  CaricaListaPiatti(lstPiatti, "OrdineTasto", ANA_PIATTI)

                  ' Seleziona il primo elemento.
                  lstPiatti.SelectedIndex = 0
               End If

               ' VARIANTI.
               ' Se nella tabella non ci sono record disattiva i pulsanti.
               If LeggiNumRecordPiatti(ANA_PIATTI, "Sì") = 0 Then
                  tpVarianti.Enabled = True
               Else
                  CaricaListaVarianti(lstVarianti, "OrdineTasto", ANA_PIATTI)

                  ' Seleziona il primo elemento.
                  lstVarianti.SelectedIndex = 0
               End If

               'FUNZIONI PIATTI.
               ' Se nella tabella non ci sono record disattiva i pulsanti.
               If LeggiNumRecord(TAB_POS_IMPOSTAZIONI_PIATTI) = 0 Then
                  tpFunzioniPiatti.Enabled = True
               Else
                  CaricaListaFunzioniPiatti(lstFunzioniPiatti, "OrdineTasto", TAB_POS_IMPOSTAZIONI_PIATTI)

                  ' Seleziona il primo elemento.
                  lstFunzioniPiatti.SelectedIndex = 0
               End If

            Case "frmVCTavoli"
               ' Nasconde le schede che non servono.
               tpCategorie.Visible = False
               tpPiatti.Visible = False
               tpVarianti.Visible = False
               tpFunzioniPiatti.Visible = False

               ' SALE.
               ' Se nella tabella non ci sono record disattiva i pulsanti.
               If LeggiNumRecord(ANA_SALE) = 0 Then
                  tpSale.Enabled = True
               Else
                  CaricaListaSale(lstSale, "OrdineTasto", ANA_SALE)

                  ' Seleziona il primo elemento.
                  lstSale.SelectedIndex = 0
               End If

               ' TAVOLI.
               ' Se nella tabella non ci sono record disattiva i pulsanti.
               If LeggiNumRecord(ANA_TAVOLI) = 0 Then
                  tpTavoli.Enabled = True
               Else
                  CaricaListaTavoli(lstTavoli, "OrdineTasto", ANA_TAVOLI)

                  ' Seleziona il primo elemento.
                  lstTavoli.SelectedIndex = 0
               End If

               'FUNZIONI TAVOLI.
               ' Se nella tabella non ci sono record disattiva i pulsanti.
               If LeggiNumRecord(TAB_POS_IMPOSTAZIONI_TAVOLI) = 0 Then
                  tpFunzioniTavoli.Enabled = True
               Else
                  CaricaListaFunzioniTavoli(lstFunzioniTavoli, "OrdineTasto", TAB_POS_IMPOSTAZIONI_TAVOLI)

                  ' Seleziona il primo elemento.
                  lstFunzioniTavoli.SelectedIndex = 0
               End If

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub eui_cmdOK_Click(sender As Object, e As EventArgs) Handles eui_cmdOK.Click
      Try
         If SalvaImpostazioni() = True Then
            Me.Close()

            Select Case nomeFinestra
               Case "frmPos"
                  MessageBox.Show("Per rendere effettive le impostazioni verrà chiuso e riaperto il Visual POS - CONTO IMMEDIATO.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

                  g_frmPos.Tag = "IMPOSTAZIONI"
                  g_frmPos.Close()

                  If IsNothing(g_frmPos) = False Then
                     ' Distrugge l'oggetto e libera le risorse.
                     g_frmPos.Dispose()
                     g_frmPos = Nothing
                  End If

                  g_frmMain.ApriPos(0, String.Empty, String.Empty, String.Empty)

               Case "frmVCTavoli"
                  MessageBox.Show("Per rendere effettive le impostazioni verrà chiuso e riaperto il Visual POS - GESTIONE TAVOLI.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

                  g_frmVCTavoli.Tag = "IMPOSTAZIONI"
                  g_frmVCTavoli.Close()

                  g_frmMain.ApriVCTavoli()
            End Select
         Else
            Me.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnColorePredefinito_Click(sender As Object, e As EventArgs) Handles eui_btnColorePredefinito.Click
      Try
         Select Case TabControl1.SelectedTabPage.Text
            Case TabControl1.TabPages(0).Text
               ' SALE.
               eui_ddwnStileColoreSale.Text = eui_btnColorePredefinito.Text

               netBtn_AnteprimaSale.ColorBottom = COLORE_SFONDO_TASTO
               netBtn_AnteprimaSale.ColorText = COLORE_TESTO_TASTO

               Sala(salaSelezionata).ColorBottom = COLORE_SFONDO_TASTO
               Sala(salaSelezionata).ColorText = COLORE_TESTO_TASTO

               cmdColoreSfondoSale.BackColor = Sala(salaSelezionata).ColorBottom
               cmdColoreTestoSale.BackColor = Sala(salaSelezionata).ColorText

               cmdColoreSfondoSale.Enabled = False
               cmdColoreTestoSale.Enabled = False

            Case TabControl1.TabPages(2).Text
               ' FUNZIONI POS TAVOLI.
               eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColorePredefinito.Text

               netBtn_AnteprimaFunzioniTavoli.ColorBottom = COLORE_SFONDO_TASTO
               netBtn_AnteprimaFunzioniTavoli.ColorText = COLORE_TESTO_TASTO

               FunzioneTavolo(funzioneTavoloSelezionata).ColorBottom = COLORE_SFONDO_TASTO
               FunzioneTavolo(funzioneTavoloSelezionata).ColorText = COLORE_TESTO_TASTO

               cmdColoreSfondoFunzioniTavoli.BackColor = FunzioneTavolo(funzioneTavoloSelezionata).ColorBottom
               cmdColoreTestoFunzioniTavoli.BackColor = FunzioneTavolo(funzioneTavoloSelezionata).ColorText

               cmdColoreSfondoFunzioniTavoli.Enabled = False
               cmdColoreTestoFunzioniTavoli.Enabled = False

            Case TabControl1.TabPages(3).Text
               ' CATEGORIE PIATTI.
               eui_ddwnStileColoreCategorie.Text = eui_btnColorePredefinito.Text

               netBtn_AnteprimaCategorie.ColorBottom = COLORE_SFONDO_TASTO
               netBtn_AnteprimaCategorie.ColorText = COLORE_TESTO_TASTO

               Categoria(categoriaSelezionata).ColorBottom = COLORE_SFONDO_TASTO
               Categoria(categoriaSelezionata).ColorText = COLORE_TESTO_TASTO

               cmdColoreSfondoCategorie.BackColor = Categoria(categoriaSelezionata).ColorBottom
               cmdColoreTestoCategorie.BackColor = Categoria(categoriaSelezionata).ColorText

               cmdColoreSfondoCategorie.Enabled = False
               cmdColoreTestoCategorie.Enabled = False

            Case TabControl1.TabPages(4).Text
               ' PIATTI.
               eui_ddwnStileColorePiatti.Text = eui_btnColorePredefinito.Text

               netBtn_AnteprimaPiatti.ColorBottom = COLORE_SFONDO_TASTO_PIATTO
               netBtn_AnteprimaPiatti.ColorText = COLORE_TESTO_TASTO_PIATTO

               Piatto(piattoSelezionato).ColorBottom = COLORE_SFONDO_TASTO_PIATTO
               Piatto(piattoSelezionato).ColorText = COLORE_TESTO_TASTO_PIATTO

               cmdColoreSfondoPiatti.BackColor = Piatto(piattoSelezionato).ColorBottom
               cmdColoreTestoPiatti.BackColor = Piatto(piattoSelezionato).ColorText

               cmdColoreSfondoPiatti.Enabled = False
               cmdColoreTestoPiatti.Enabled = False

            Case TabControl1.TabPages(5).Text
               ' VARIANTI.
               eui_ddwnStileColoreVarianti.Text = eui_btnColorePredefinito.Text

               netBtn_AnteprimaVarianti.ColorBottom = COLORE_SFONDO_TASTO_PIATTO
               netBtn_AnteprimaVarianti.ColorText = COLORE_TESTO_TASTO_PIATTO

               Variante(varianteSelezionata).ColorBottom = COLORE_SFONDO_TASTO_PIATTO
               Variante(varianteSelezionata).ColorText = COLORE_TESTO_TASTO_PIATTO

               cmdColoreSfondoVarianti.BackColor = Variante(varianteSelezionata).ColorBottom
               cmdColoreTestoVarianti.BackColor = Variante(varianteSelezionata).ColorText

               cmdColoreSfondoVarianti.Enabled = False
               cmdColoreTestoVarianti.Enabled = False

            Case TabControl1.TabPages(6).Text
               ' FUNZIONI POS PIATTI.
               eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColorePredefinito.Text

               netBtn_AnteprimaFunzioniPiatti.ColorBottom = COLORE_SFONDO_TASTO
               netBtn_AnteprimaFunzioniPiatti.ColorText = COLORE_TESTO_TASTO

               FunzionePiatto(funzionePiattoSelezionata).ColorBottom = COLORE_SFONDO_TASTO
               FunzionePiatto(funzionePiattoSelezionata).ColorText = COLORE_TESTO_TASTO

               cmdColoreSfondoFunzioniPiatti.BackColor = FunzionePiatto(funzionePiattoSelezionata).ColorBottom
               cmdColoreTestoFunzioniPiatti.BackColor = FunzionePiatto(funzionePiattoSelezionata).ColorText

               cmdColoreSfondoFunzioniPiatti.Enabled = False
               cmdColoreTestoFunzioniPiatti.Enabled = False

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnColorePersonalizzato_Click(sender As Object, e As EventArgs) Handles eui_btnColorePersonalizzato.Click
      Try
         Select Case TabControl1.SelectedTabPage.Text
            Case TabControl1.TabPages(0).Text
               ' SALE.
               eui_ddwnStileColoreSale.Text = eui_btnColorePersonalizzato.Text

               Sala(salaSelezionata).ColorStyle = NetButton.ColorStyleEnum.Custom

               cmdColoreSfondoSale.Enabled = True
               cmdColoreTestoSale.Enabled = True

            Case TabControl1.TabPages(2).Text
               ' FUNZIONI POS TAVOLI.
               eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColorePersonalizzato.Text

               FunzioneTavolo(funzioneTavoloSelezionata).ColorStyle = NetButton.ColorStyleEnum.Custom

               cmdColoreSfondoFunzioniTavoli.Enabled = True
               cmdColoreTestoFunzioniTavoli.Enabled = True

            Case TabControl1.TabPages(3).Text
               ' CATEGORIE PIATTI.
               eui_ddwnStileColoreCategorie.Text = eui_btnColorePersonalizzato.Text

               Categoria(categoriaSelezionata).ColorStyle = NetButton.ColorStyleEnum.Custom

               cmdColoreSfondoCategorie.Enabled = True
               cmdColoreTestoCategorie.Enabled = True

            Case TabControl1.TabPages(4).Text
               ' PIATTI.
               eui_ddwnStileColorePiatti.Text = eui_btnColorePersonalizzato.Text

               Piatto(piattoSelezionato).ColorStyle = NetButton.ColorStyleEnum.Custom

               cmdColoreSfondoPiatti.Enabled = True
               cmdColoreTestoPiatti.Enabled = True

            Case TabControl1.TabPages(5).Text
               ' VARIANTI.
               eui_ddwnStileColoreVarianti.Text = eui_btnColorePersonalizzato.Text

               Variante(varianteSelezionata).ColorStyle = NetButton.ColorStyleEnum.Custom

               cmdColoreSfondoVarianti.Enabled = True
               cmdColoreTestoVarianti.Enabled = True

            Case TabControl1.TabPages(6).Text
               ' FUNZIONI POS PIATTI.
               eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColorePersonalizzato.Text

               FunzionePiatto(funzionePiattoSelezionata).ColorStyle = NetButton.ColorStyleEnum.Custom

               cmdColoreSfondoFunzioniPiatti.Enabled = True
               cmdColoreTestoFunzioniPiatti.Enabled = True

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnColoreBlu_Click(sender As Object, e As EventArgs) Handles eui_btnColoreBlu.Click
      Try
         Select Case TabControl1.SelectedTabPage.Text
            Case TabControl1.TabPages(0).Text
               ' SALE.
               SelezionaColoreSale(eui_btnColoreBlu.Text, NetButton.ColorStyleEnum.Blue)

            Case TabControl1.TabPages(2).Text
               ' FUNZIONI POS TAVOLI.
               SelezionaColoreFunzioniTavoli(eui_btnColoreBlu.Text, NetButton.ColorStyleEnum.Blue)

            Case TabControl1.TabPages(3).Text
               ' CATEGORIE PIATTI.
               SelezionaColoreCategorie(eui_btnColoreBlu.Text, NetButton.ColorStyleEnum.Blue)

            Case TabControl1.TabPages(4).Text
               ' PIATTI.
               SelezionaColorePiatti(eui_btnColoreBlu.Text, NetButton.ColorStyleEnum.Blue)

            Case TabControl1.TabPages(5).Text
               ' VARIANTI.
               SelezionaColoreVarianti(eui_btnColoreBlu.Text, NetButton.ColorStyleEnum.Blue)

            Case TabControl1.TabPages(6).Text
               ' FUNZIONI POS PIATTI.
               SelezionaColoreFunzioniPiatti(eui_btnColoreBlu.Text, NetButton.ColorStyleEnum.Blue)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnColoreVerde_Click(sender As Object, e As EventArgs) Handles eui_btnColoreVerde.Click
      Try
         Select Case TabControl1.SelectedTabPage.Text
            Case TabControl1.TabPages(0).Text
               ' SALE.
               SelezionaColoreSale(eui_btnColoreVerde.Text, NetButton.ColorStyleEnum.Green)

            Case TabControl1.TabPages(2).Text
               ' FUNZIONI POS TAVOLI.
               SelezionaColoreFunzioniTavoli(eui_btnColoreVerde.Text, NetButton.ColorStyleEnum.Green)

            Case TabControl1.TabPages(3).Text
               ' CATEGORIE PIATTI.
               SelezionaColoreCategorie(eui_btnColoreVerde.Text, NetButton.ColorStyleEnum.Green)

            Case TabControl1.TabPages(4).Text
               ' PIATTI.
               SelezionaColorePiatti(eui_btnColoreVerde.Text, NetButton.ColorStyleEnum.Green)

            Case TabControl1.TabPages(5).Text
               ' VARIANTI.
               SelezionaColoreVarianti(eui_btnColoreVerde.Text, NetButton.ColorStyleEnum.Green)

            Case TabControl1.TabPages(6).Text
               ' FUNZIONI POS PIATTI.
               SelezionaColoreFunzioniPiatti(eui_btnColoreVerde.Text, NetButton.ColorStyleEnum.Green)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnColoreGiallo_Click(sender As Object, e As EventArgs) Handles eui_btnColoreGiallo.Click
      Try
         Select Case TabControl1.SelectedTabPage.Text
            Case TabControl1.TabPages(0).Text
               ' SALE.
               SelezionaColoreSale(eui_btnColoreGiallo.Text, NetButton.ColorStyleEnum.Yellow)

            Case TabControl1.TabPages(2).Text
               ' FUNZIONI POS TAVOLI.
               SelezionaColoreFunzioniTavoli(eui_btnColoreGiallo.Text, NetButton.ColorStyleEnum.Yellow)

            Case TabControl1.TabPages(3).Text
               ' CATEGORIE PIATTI.
               SelezionaColoreCategorie(eui_btnColoreGiallo.Text, NetButton.ColorStyleEnum.Yellow)

            Case TabControl1.TabPages(4).Text
               ' PIATTI.
               SelezionaColorePiatti(eui_btnColoreGiallo.Text, NetButton.ColorStyleEnum.Yellow)

            Case TabControl1.TabPages(5).Text
               ' VARIANTI.
               SelezionaColoreVarianti(eui_btnColoreGiallo.Text, NetButton.ColorStyleEnum.Yellow)

            Case TabControl1.TabPages(6).Text
               ' FUNZIONI POS PIATTI.
               SelezionaColoreFunzioniPiatti(eui_btnColoreGiallo.Text, NetButton.ColorStyleEnum.Yellow)
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnColoreRosso_Click(sender As Object, e As EventArgs) Handles eui_btnColoreRosso.Click
      Try
         Select Case TabControl1.SelectedTabPage.Text
            Case TabControl1.TabPages(0).Text
               ' SALE.
               SelezionaColoreSale(eui_btnColoreRosso.Text, NetButton.ColorStyleEnum.Red)

            Case TabControl1.TabPages(2).Text
               ' FUNZIONI POS TAVOLI.
               SelezionaColoreFunzioniTavoli(eui_btnColoreRosso.Text, NetButton.ColorStyleEnum.Red)

            Case TabControl1.TabPages(3).Text
               ' CATEGORIE PIATTI.
               SelezionaColoreCategorie(eui_btnColoreRosso.Text, NetButton.ColorStyleEnum.Red)

            Case TabControl1.TabPages(4).Text
               ' PIATTI.
               SelezionaColorePiatti(eui_btnColoreRosso.Text, NetButton.ColorStyleEnum.Red)

            Case TabControl1.TabPages(5).Text
               ' VARIANTI.
               SelezionaColoreVarianti(eui_btnColoreRosso.Text, NetButton.ColorStyleEnum.Red)

            Case TabControl1.TabPages(6).Text
               ' FUNZIONI POS PIATTI.
               SelezionaColoreFunzioniPiatti(eui_btnColoreRosso.Text, NetButton.ColorStyleEnum.Red)
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnColoreViola_Click(sender As Object, e As EventArgs) Handles eui_btnColoreViola.Click
      Try
         Select Case TabControl1.SelectedTabPage.Text
            Case TabControl1.TabPages(0).Text
               ' SALE.
               SelezionaColoreSale(eui_btnColoreViola.Text, NetButton.ColorStyleEnum.Pink)

            Case TabControl1.TabPages(2).Text
               ' FUNZIONI POS TAVOLI.
               SelezionaColoreFunzioniTavoli(eui_btnColoreViola.Text, NetButton.ColorStyleEnum.Pink)

            Case TabControl1.TabPages(3).Text
               ' CATEGORIE PIATTI.
               SelezionaColoreCategorie(eui_btnColoreViola.Text, NetButton.ColorStyleEnum.Pink)

            Case TabControl1.TabPages(4).Text
               ' PIATTI.
               SelezionaColorePiatti(eui_btnColoreViola.Text, NetButton.ColorStyleEnum.Pink)

            Case TabControl1.TabPages(5).Text
               ' VARIANTI.
               SelezionaColoreVarianti(eui_btnColoreViola.Text, NetButton.ColorStyleEnum.Pink)

            Case TabControl1.TabPages(6).Text
               ' FUNZIONI POS PIATI.
               SelezionaColoreFunzioniPiatti(eui_btnColoreViola.Text, NetButton.ColorStyleEnum.Pink)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnColoreGrigio_Click(sender As Object, e As EventArgs) Handles eui_btnColoreGrigio.Click
      Try
         Select Case TabControl1.SelectedTabPage.Text
            Case TabControl1.TabPages(0).Text
               ' SALE.
               SelezionaColoreSale(eui_btnColoreGrigio.Text, NetButton.ColorStyleEnum.Gray)

            Case TabControl1.TabPages(2).Text
               ' FUNZIONI POS TAVOLI.
               SelezionaColoreFunzioniTavoli(eui_btnColoreGrigio.Text, NetButton.ColorStyleEnum.Gray)

            Case TabControl1.TabPages(3).Text
               ' CATEGORIE PIATTI.
               SelezionaColoreCategorie(eui_btnColoreGrigio.Text, NetButton.ColorStyleEnum.Gray)

            Case TabControl1.TabPages(4).Text
               ' PIATTI.
               SelezionaColorePiatti(eui_btnColoreGrigio.Text, NetButton.ColorStyleEnum.Gray)

            Case TabControl1.TabPages(5).Text
               ' VARIANTI.
               SelezionaColoreVarianti(eui_btnColoreGrigio.Text, NetButton.ColorStyleEnum.Gray)

            Case TabControl1.TabPages(6).Text
               ' FUNZIONI POS PIATTI.
               SelezionaColoreFunzioniPiatti(eui_btnColoreGrigio.Text, NetButton.ColorStyleEnum.Gray)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnColoreBianco_Click(sender As Object, e As EventArgs) Handles eui_btnColoreBianco.Click
      Try
         Select Case TabControl1.SelectedTabPage.Text
            Case TabControl1.TabPages(0).Text
               ' SALE.
               SelezionaColoreSale(eui_btnColoreBianco.Text, NetButton.ColorStyleEnum.Default)

            Case TabControl1.TabPages(2).Text
               ' FUNZIONI POS TAVOLI.
               SelezionaColoreFunzioniTavoli(eui_btnColoreBianco.Text, NetButton.ColorStyleEnum.Default)

            Case TabControl1.TabPages(3).Text
               ' CATEGORIE PIATTI.
               SelezionaColoreCategorie(eui_btnColoreBianco.Text, NetButton.ColorStyleEnum.Default)

            Case TabControl1.TabPages(4).Text
               ' PIATTI.
               SelezionaColorePiatti(eui_btnColoreBianco.Text, NetButton.ColorStyleEnum.Default)

            Case TabControl1.TabPages(5).Text
               ' VARIANTI.
               SelezionaColoreVarianti(eui_btnColoreBianco.Text, NetButton.ColorStyleEnum.Default)

            Case TabControl1.TabPages(6).Text
               ' FUNZIONI POS PIATTI.
               SelezionaColoreFunzioniPiatti(eui_btnColoreBianco.Text, NetButton.ColorStyleEnum.Default)

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#Region "Tasti Sale "

   Private Sub CreaTastoSala(ByVal nome As String, ByVal id As Integer, ByVal altezza As Integer, ByVal coloreSfondo As Color, ByVal coloreTesto As Color, ByVal stileTasto As NetButton.ColorStyleEnum)
      Try
         NumSale += 1

         Sala(NumSale) = New NetButton
         Sala(NumSale).Name = id.ToString
         Sala(NumSale).Tag = nome
         Sala(NumSale).Size = New Size(LARGHEZZA_SALE, altezza)

         If stileTasto = NetButton.ColorStyleEnum.Custom Then
            Sala(NumSale).ColorStyle = NetButton.ColorStyleEnum.Custom
            Sala(NumSale).ColorBottom = coloreSfondo
            Sala(NumSale).ColorText = coloreTesto
         Else
            Sala(NumSale).ColorStyle = stileTasto
         End If

         Sala(NumSale).TextButton = nome
         Sala(NumSale).Visible = False

         pnlSale.Controls.Add(Sala(NumSale))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ReimpostaListaSale(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim Sala(LeggiNumRecord(ANA_SALE))
         NumSale = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("Descrizione").ToString)
            Select Case dr.Item("Descrizione").ToString
               Case TASTO_ASPORTO
                  ' Crea il pulsante Sala per memorizzare i dati.
                  CreaTastoSala(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), ALTEZZA_SALE, COLORE_SFONDO_TASTO_ASPORTO, COLORE_TESTO_TASTO_ASPORTO, NetButton.ColorStyleEnum.Custom)

               Case Else
                  ' Crea il pulsante Sala per memorizzare i dati.
                  CreaTastoSala(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), ALTEZZA_SALE, COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Custom)

            End Select
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaListaSale(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim Sala(LeggiNumRecord(ANA_SALE))
         NumSale = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("Descrizione").ToString)

            ' Crea il pulsante Sala per memorizzare i dati.
            CreaTastoSala(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), Convert.ToInt32(dr.Item("AltezzaTasto")), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), dr.Item("ColoreStile"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Function SalvaImpostazioniSale() As Boolean
      Try
         Dim ASale As New Sale

         Dim i As Integer
         For i = 0 To lstSale.Items.Count - 1

            Dim y As Integer
            For y = 1 To NumSale
               ' Modifica le proprietà.
               If lstSale.Items(i).ToString = Sala(y).TextButton Then
                  ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
                  ASale.ModificaDati(Sala(y).ColorStyle, Sala(y).ColorBottom.ToArgb, Sala(y).ColorText.ToArgb, Sala(y).Size.Height, Sala(y).TextButton, ANA_SALE)
                  Exit For
               End If
            Next
         Next

         i = 0

         For i = 0 To lstSale.Items.Count - 1
            ' Modifica l'ordine.
            ASale.ModificaOrdineTasto(i, lstSale.Items(i).ToString, ANA_SALE)
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub ModificaColoreSfondoSale()
      Try
         With ColorDialog1()
            .Color = cmdColoreSfondoSale.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreSfondoSale.BackColor = .Color
               netBtn_AnteprimaSale.ColorBottom = .Color
               Sala(salaSelezionata).ColorBottom = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaColoreTestoSale()
      Try
         With ColorDialog1()
            .Color = cmdColoreTestoSale.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreTestoSale.BackColor = .Color
               netBtn_AnteprimaSale.ColorText = .Color
               Sala(salaSelezionata).ColorText = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SelezionaColoreSale(ByVal nomeColore As String, ByVal stileColore As NetButton.ColorStyleEnum)
      Try
         eui_ddwnStileColoreSale.Text = nomeColore

         netBtn_AnteprimaSale.ColorStyle = stileColore

         Sala(salaSelezionata).ColorStyle = stileColore

         cmdColoreSfondoSale.BackColor = Sala(salaSelezionata).ColorBottom
         cmdColoreTestoSale.BackColor = Sala(salaSelezionata).ColorText

         cmdColoreSfondoSale.Enabled = False
         cmdColoreTestoSale.Enabled = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdSpostaSuSale_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaSuSale.Click
      ' Sposta in alto di una posizione l'elemento selezionato.
      SpostaElememtoSu(lstSale)
   End Sub

   Private Sub eui_cmdSpostaGiuSale_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaGiuSale.Click
      ' Sposta in basso di una posizione l'elemento selezionato.
      SpostaElememtoGiù(lstSale)
   End Sub

   Private Sub eui_cmdReimpostaSale_Click(sender As Object, e As EventArgs) Handles eui_cmdReimpostaSale.Click
      Try
         ' Rimuove tutti i pulsanti.
         pnlSale.Controls.Clear()

         ' Rimuove tutti gli elementi dalla lista.
         lstSale.Items.Clear()

         ' Carica la lista con le impostazioni di default.
         ReimpostaListaSale(lstSale, "Id", ANA_SALE)

         lstSale.SelectedIndex = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lstSale_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstSale.SelectedIndexChanged
      Try
         Dim i As Integer
         For i = 1 To NumSale
            ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
            ' Se lo trova assegna le proprietà ai controlli.
            If lstSale.Text = Sala(i).TextButton Then
               ' Disattiva i controlli colore.
               cmdColoreSfondoSale.Enabled = False
               cmdColoreTestoSale.Enabled = False

               ' Nome Tasto.
               netBtn_AnteprimaSale.TextButton = Sala(i).TextButton

               ' Stile colore.
               If Sala(i).ColorBottom.ToArgb = COLORE_SFONDO_TASTO.ToArgb And Sala(i).ColorText.ToArgb = COLORE_TESTO_TASTO.ToArgb Then
                  eui_ddwnStileColoreSale.Text = eui_btnColorePredefinito.Text
               Else
                  Select Case Sala(i).ColorStyle
                     Case NetButton.ColorStyleEnum.Custom
                        eui_ddwnStileColoreSale.Text = eui_btnColorePersonalizzato.Text

                        ' Attiva i controlli colore.
                        cmdColoreSfondoSale.Enabled = True
                        cmdColoreTestoSale.Enabled = True

                     Case NetButton.ColorStyleEnum.Default
                        eui_ddwnStileColoreSale.Text = eui_btnColoreBianco.Text

                     Case NetButton.ColorStyleEnum.Blue
                        eui_ddwnStileColoreSale.Text = eui_btnColoreBlu.Text

                     Case NetButton.ColorStyleEnum.Gray
                        eui_ddwnStileColoreSale.Text = eui_btnColoreGrigio.Text

                     Case NetButton.ColorStyleEnum.Green
                        eui_ddwnStileColoreSale.Text = eui_btnColoreVerde.Text

                     Case NetButton.ColorStyleEnum.Pink
                        eui_ddwnStileColoreSale.Text = eui_btnColoreViola.Text

                     Case NetButton.ColorStyleEnum.Red
                        eui_ddwnStileColoreSale.Text = eui_btnColoreRosso.Text

                     Case NetButton.ColorStyleEnum.Yellow
                        eui_ddwnStileColoreSale.Text = eui_btnColoreGiallo.Text

                  End Select
               End If

               ' Colore di sfondo.
               cmdColoreSfondoSale.BackColor = Sala(i).ColorBottom
               netBtn_AnteprimaSale.ColorBottom = Sala(i).ColorBottom

               ' Colore del testo.
               cmdColoreTestoSale.BackColor = Sala(i).ColorText
               netBtn_AnteprimaSale.ColorText = Sala(i).ColorText

               ' Altezza del tasto.
               eui_nudAltezzaSale.Value = Sala(i).Size.Height

               ' Salva l'indice dell'elemento selezionato.
               salaSelezionata = i

               Exit Sub
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub cmdColoreSfondoSale_Click(sender As Object, e As EventArgs) Handles cmdColoreSfondoSale.Click
      ModificaColoreSfondoSale()
   End Sub

   Private Sub cmdColoreTestoSale_Click(sender As Object, e As EventArgs) Handles cmdColoreTestoSale.Click
      ModificaColoreTestoSale()
   End Sub

   Private Sub eui_nudAltezzaSale_ValueChanged(sender As Object, e As EventArgs) Handles eui_nudAltezzaSale.ValueChanged
      Try
         ' Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudAltezzaSale.Value

            Case Is < eui_nudAltezzaSale.Minimum
               eui_nudAltezzaSale.Value = eui_nudAltezzaSale.Minimum

            Case Is > eui_nudAltezzaSale.Maximum
               eui_nudAltezzaSale.Value = eui_nudAltezzaSale.Maximum

         End Select

         ' Imposta l'anteprima del tasto.
         netBtn_AnteprimaSale.Size = New Drawing.Size(netBtn_AnteprimaSale.Size.Width, Convert.ToInt32(eui_nudAltezzaSale.Value))

         Dim i As Integer
         For i = 1 To NumSale
            ' Modifica i dati.
            Sala(i).Size = New Drawing.Size(LARGHEZZA_SALE, Convert.ToInt32(eui_nudAltezzaSale.Value))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region "Tasti Tavoli "

   Private Sub CreaTastoTavolo(ByVal nome As String, ByVal id As Integer, ByVal posti As String, ByVal orientamento As String, ByVal dimensioneTasto As String, ByVal altezza As Integer, ByVal larghezza As Integer, ByVal numTastiRiga As Integer)
      Try
         NumTavoli += 1

         Tavolo(NumTavoli) = New NetButton
         Tavolo(NumTavoli).Name = id.ToString
         Tavolo(NumTavoli).Tag = posti & ";" & orientamento & ";" & dimensioneTasto & ";" & numTastiRiga
         Tavolo(NumTavoli).Size = New Size(larghezza, altezza)
         Tavolo(NumTavoli).ColorStyle = NetButton.ColorStyleEnum.Default
         Tavolo(NumTavoli).TextButton = nome
         Tavolo(NumTavoli).Visible = False

         pnlTavoli.Controls.Add(Tavolo(NumTavoli))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ReimpostaListaTavoli(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim Tavolo(LeggiNumRecord(ANA_TAVOLI))
         NumTavoli = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("Descrizione").ToString)

            ' Crea il pulsante Tavolo per memorizzare i dati.
            CreaTastoTavolo(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), dr.Item("Posti").ToString, dr.Item("Orientamento").ToString, dr.Item("DimensioneTasto").ToString, ALTEZZA_TAVOLI, LARGHEZZA_TAVOLI, NUM_TASTI_RIGA)

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaListaTavoli(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim Tavolo(LeggiNumRecord(ANA_TAVOLI))
         NumTavoli = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("Descrizione").ToString)

            ' Crea il pulsante Tavolo per memorizzare i dati.
            CreaTastoTavolo(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), dr.Item("Posti").ToString, dr.Item("Orientamento").ToString, dr.Item("DimensioneTasto").ToString, Convert.ToInt32(dr.Item("AltezzaTasto")), Convert.ToInt32(dr.Item("LarghezzaTasto")), Convert.ToInt32(dr.Item("NumTastiRiga")))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Function SalvaImpostazioniTavoli() As Boolean
      Try
         Dim ATavoli As New Tavoli

         Dim i As Integer
         For i = 0 To lstTavoli.Items.Count - 1

            Dim y As Integer
            For y = 1 To NumTavoli
               ' Modifica le proprietà.
               If lstTavoli.Items(i).ToString = Tavolo(y).TextButton Then

                  Dim datiTavolo() As String
                  datiTavolo = Tavolo(y).Tag.ToString.Split(";")

                  ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
                  ATavoli.ModificaDati(datiTavolo(0), datiTavolo(1), Tavolo(y).Size.Height, Tavolo(y).Size.Width, Convert.ToInt32(datiTavolo(3)), datiTavolo(2), Tavolo(y).TextButton, ANA_TAVOLI)
                  Exit For
               End If
            Next
         Next

         i = 0

         For i = 0 To lstTavoli.Items.Count - 1
            ' Modifica l'ordine.
            ATavoli.ModificaOrdineTasto(i, lstTavoli.Items(i).ToString, ANA_TAVOLI)
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub CalcolaDimensioneTavolo(ByVal numPosti As Integer, ByVal orientamento As String, ByVal dimensione As String)
      Try
         Const VALORE_VENTI As Integer = 20
         Dim LARGHEZZA_RISORSA As Integer
         Dim ALTEZZA_RISORSA As Integer
         Dim larghezzaTavolo As Integer
         Dim altezzaTavolo As Integer

         Select Case dimensione
            Case "Piccolo"
               larghezzaTavolo = LARGHEZZA_TAVOLI_PICCOLO + VALORE_VENTI
               altezzaTavolo = ALTEZZA_TAVOLI_PICCOLO + VALORE_VENTI

            Case "Medio"
               larghezzaTavolo = LARGHEZZA_TAVOLI_MEDIO + VALORE_VENTI
               altezzaTavolo = ALTEZZA_TAVOLI_MEDIO + VALORE_VENTI

            Case "Grande"
               larghezzaTavolo = LARGHEZZA_TAVOLI_GRANDE + VALORE_VENTI
               altezzaTavolo = ALTEZZA_TAVOLI_GRANDE + VALORE_VENTI
         End Select

         ' Tavolo standard.
         If numPosti < 5 Then
            LARGHEZZA_RISORSA = larghezzaTavolo
            ALTEZZA_RISORSA = altezzaTavolo

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
                     LARGHEZZA_RISORSA = (postiDaAgg * larghezzaTavolo)
                     ALTEZZA_RISORSA = altezzaTavolo
                  End If

               Case "Verticale"
                  If postiDaAgg <> 0 Then
                     ALTEZZA_RISORSA = (postiDaAgg * altezzaTavolo)
                     LARGHEZZA_RISORSA = larghezzaTavolo
                  End If
            End Select

         End If

         ' Applica le dimensioni.
         netBtn_AnteprimaTavoliPiantina.Size = New Size(LARGHEZZA_RISORSA, ALTEZZA_RISORSA)

         ' Centra il pulsante nel controllo contenitore.
         netBtn_AnteprimaTavoliPiantina.Location = CentraControllo(netBtn_AnteprimaTavoliPiantina, GroupBox10)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdSpostaSuTavoli_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaSuTavoli.Click
      ' Sposta in alto di una posizione l'elemento selezionato.
      SpostaElememtoSu(lstTavoli)
   End Sub

   Private Sub eui_cmdSpostaGiuTavoli_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaGiuTavoli.Click
      ' Sposta in basso di una posizione l'elemento selezionato.
      SpostaElememtoGiù(lstTavoli)
   End Sub

   Private Sub eui_cmdReimpostaTavoli_Click(sender As Object, e As EventArgs) Handles eui_cmdReimpostaTavoli.Click
      Try
         ' Rimuove tutti i pulsanti.
         pnlTavoli.Controls.Clear()

         ' Rimuove tutti gli elementi dalla lista.
         lstTavoli.Items.Clear()

         ' Carica la lista con le impostazioni di default.
         ReimpostaListaTavoli(lstTavoli, "Id", ANA_TAVOLI)

         lstTavoli.SelectedIndex = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub lstTavoli_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstTavoli.SelectedIndexChanged
      Try
         Dim i As Integer
         For i = 1 To NumTavoli
            ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
            ' Se lo trova assegna le proprietà ai controlli.
            If lstTavoli.Text = Tavolo(i).TextButton Then
               Dim datiTavolo() As String
               datiTavolo = Tavolo(i).Tag.ToString.Split(";")

               Dim altezza As Integer = Tavolo(i).Size.Height
               Dim larghezza As Integer = Tavolo(i).Size.Width

               ' Salva l'indice dell'elemento selezionato.
               tavoloSelezionato = i

               ' Nome Tasto.
               netBtn_AnteprimaTavoli.TextButton = Tavolo(i).TextButton
               netBtn_AnteprimaTavoliPiantina.TextButton = Tavolo(i).TextButton

               ' Altezza del tasto.
               eui_nudAltezzaTavoli.Value = Convert.ToDecimal(altezza)

               ' Larghezza del tasto.
               eui_nudLarghezzaTavoli.Value = Convert.ToDecimal(larghezza)

               ' Dimensione - Posti.
               eui_nudDimensionePosti.Value = Convert.ToDecimal(datiTavolo(0))

               ' Orientamento.
               eui_ddwnOrientamentoTavoli.Text = datiTavolo(1)

               ' Dimensione tavolo.
               eui_ddwnDimensioneTavoli.Text = datiTavolo(2)

               ' Numero di tasti per riga.
               eui_nudNumTastiRigaTavoli.Value = Convert.ToDecimal(datiTavolo(3))

               Exit Sub
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub eui_nudAltezzaTavoli_ValueChanged(sender As Object, e As EventArgs) Handles eui_nudAltezzaTavoli.ValueChanged
      Try
         ' Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudAltezzaTavoli.Value

            Case Is < eui_nudAltezzaTavoli.Minimum
               eui_nudAltezzaTavoli.Value = eui_nudAltezzaTavoli.Minimum

            Case Is > eui_nudAltezzaTavoli.Maximum
               eui_nudAltezzaTavoli.Value = eui_nudAltezzaTavoli.Maximum

         End Select

         ' Imposta l'anteprima del tasto.
         netBtn_AnteprimaTavoli.Size = New Drawing.Size(Convert.ToInt32(eui_nudLarghezzaTavoli.Value), Convert.ToInt32(eui_nudAltezzaTavoli.Value))

         ' Centra il pulsante nel controllo contenitore.
         netBtn_AnteprimaTavoli.Location = CentraControllo(netBtn_AnteprimaTavoli, GroupBox9)

         Dim i As Integer
         For i = 1 To NumTavoli
            ' Modifica i dati.
            Tavolo(i).Size = New Drawing.Size(Convert.ToInt32(eui_nudLarghezzaTavoli.Value), Convert.ToInt32(eui_nudAltezzaTavoli.Value))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_nudLarghezzaTavoli_ValueChanged(sender As Object, e As EventArgs) Handles eui_nudLarghezzaTavoli.ValueChanged
      Try
         'Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudLarghezzaTavoli.Value
            Case 1
               eui_nudLarghezzaTavoli.Value = LARGHEZZA_TAVOLI

            Case LARGHEZZA_TAVOLI - 1
               eui_nudLarghezzaTavoli.Value = 0

            Case Is > eui_nudLarghezzaTavoli.Maximum
               eui_nudLarghezzaTavoli.Value = eui_nudLarghezzaTavoli.Maximum

         End Select

         ' Imposta l'anteprima del tasto.
         If eui_nudLarghezzaTavoli.Value <> 0 Then
            netBtn_AnteprimaTavoli.Size = New Drawing.Size(Convert.ToInt32(eui_nudLarghezzaTavoli.Value), Convert.ToInt32(eui_nudAltezzaTavoli.Value))
         Else
            netBtn_AnteprimaTavoli.Size = New Drawing.Size(LARGHEZZA_TAVOLI, Convert.ToInt32(eui_nudAltezzaTavoli.Value))
         End If

         ' Centra il pulsante nel controllo contenitore.
         netBtn_AnteprimaTavoli.Location = CentraControllo(netBtn_AnteprimaTavoli, GroupBox9)

         Dim i As Integer
         For i = 1 To NumTavoli
            ' Modifica i dati.
            Tavolo(i).Size = New Drawing.Size(Convert.ToInt32(eui_nudLarghezzaTavoli.Value), Convert.ToInt32(eui_nudAltezzaTavoli.Value))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_nudLarghezzaTavoli_LostFocus(sender As Object, e As EventArgs) Handles eui_nudLarghezzaTavoli.LostFocus
      Try
         ' Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudLarghezzaTavoli.Value
            Case Is < LARGHEZZA_TAVOLI
               eui_nudLarghezzaTavoli.Value = 0

            Case Is > eui_nudLarghezzaTavoli.Maximum
               eui_nudLarghezzaTavoli.Value = eui_nudLarghezzaTavoli.Maximum
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_nudNumTastiRigaTavoli_ValueChanged(sender As Object, e As EventArgs) Handles eui_nudNumTastiRigaTavoli.ValueChanged
      Try
         ' Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudNumTastiRigaTavoli.Value

            Case Is < eui_nudNumTastiRigaTavoli.Minimum
               eui_nudNumTastiRigaTavoli.Value = eui_nudNumTastiRigaTavoli.Minimum

            Case Is > eui_nudNumTastiRigaTavoli.Maximum
               eui_nudNumTastiRigaTavoli.Value = eui_nudNumTastiRigaTavoli.Maximum

         End Select

         Dim i As Integer
         For i = 1 To NumTavoli
            Dim datiTavolo() As String
            datiTavolo = Tavolo(i).Tag.ToString.Split(";")

            ' Modifica i dati.
            Tavolo(i).Tag = datiTavolo(0) & ";" & datiTavolo(1) & ";" & datiTavolo(2) & ";" & eui_nudNumTastiRigaTavoli.Value.ToString
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_nudDimensionePosti_ValueChanged(sender As Object, e As EventArgs) Handles eui_nudDimensionePosti.ValueChanged
      Try
         ' Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudDimensionePosti.Value

            Case Is < eui_nudDimensionePosti.Minimum
               eui_nudDimensionePosti.Value = eui_nudDimensionePosti.Minimum

            Case Is > eui_nudDimensionePosti.Maximum
               eui_nudDimensionePosti.Value = eui_nudDimensionePosti.Maximum

         End Select

         ' Imposta l'anteprima del tasto.
         CalcolaDimensioneTavolo(Convert.ToInt32(eui_nudDimensionePosti.Value), eui_ddwnOrientamentoTavoli.Text, eui_ddwnDimensioneTavoli.Text)

         If NumTavoli <> 0 Then
            Dim datiTavolo() As String
            datiTavolo = Tavolo(tavoloSelezionato).Tag.ToString.Split(";")

            ' Modifica i dati.
            Tavolo(tavoloSelezionato).Tag = eui_nudDimensionePosti.Value & ";" & datiTavolo(1) & ";" & datiTavolo(2) & ";" & datiTavolo(3)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnOrizzontale_Click(sender As Object, e As EventArgs) Handles eui_btnOrizzontale.Click
      Try
         ' Imposta l'orientamento del Tavolo.
         eui_ddwnOrientamentoTavoli.Text = eui_btnOrizzontale.Text

         ' Imposta l'anteprima del tasto.
         CalcolaDimensioneTavolo(Convert.ToInt32(eui_nudDimensionePosti.Value), eui_ddwnOrientamentoTavoli.Text, eui_ddwnDimensioneTavoli.Text)

         If NumTavoli <> 0 Then
            Dim datiTavolo() As String
            datiTavolo = Tavolo(tavoloSelezionato).Tag.ToString.Split(";")

            ' Modifica i dati.
            Tavolo(tavoloSelezionato).Tag = datiTavolo(0) & ";" & eui_ddwnOrientamentoTavoli.Text & ";" & datiTavolo(2) & ";" & datiTavolo(3)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnVerticale_Click(sender As Object, e As EventArgs) Handles eui_btnVerticale.Click
      Try
         ' Imposta l'orientamento del Tavolo.
         eui_ddwnOrientamentoTavoli.Text = eui_btnVerticale.Text

         ' Imposta l'anteprima del tasto.
         CalcolaDimensioneTavolo(Convert.ToInt32(eui_nudDimensionePosti.Value), eui_ddwnOrientamentoTavoli.Text, eui_ddwnDimensioneTavoli.Text)

         If NumTavoli <> 0 Then
            Dim datiTavolo() As String
            datiTavolo = Tavolo(tavoloSelezionato).Tag.ToString.Split(";")

            ' Modifica i dati.
            Tavolo(tavoloSelezionato).Tag = datiTavolo(0) & ";" & eui_ddwnOrientamentoTavoli.Text & ";" & datiTavolo(2) & ";" & datiTavolo(3)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnTastoPiccolo_Click(sender As Object, e As EventArgs) Handles eui_btnTastoPiccolo.Click
      Try
         ' Imposta l'orientamento del Tavolo.
         eui_ddwnDimensioneTavoli.Text = eui_btnTastoPiccolo.Text

         ' Imposta l'anteprima del tasto.
         CalcolaDimensioneTavolo(Convert.ToInt32(eui_nudDimensionePosti.Value), eui_ddwnOrientamentoTavoli.Text, eui_ddwnDimensioneTavoli.Text)

         Dim i As Integer
         For i = 1 To NumTavoli
            Dim datiTavolo() As String
            datiTavolo = Tavolo(i).Tag.ToString.Split(";")

            ' Modifica i dati.
            Tavolo(i).Tag = datiTavolo(0) & ";" & datiTavolo(1) & ";" & eui_ddwnDimensioneTavoli.Text & ";" & datiTavolo(3)
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnTastoMedio_Click(sender As Object, e As EventArgs) Handles eui_btnTastoMedio.Click
      Try
         ' Imposta l'orientamento del Tavolo.
         eui_ddwnDimensioneTavoli.Text = eui_btnTastoMedio.Text

         ' Imposta l'anteprima del tasto.
         CalcolaDimensioneTavolo(Convert.ToInt32(eui_nudDimensionePosti.Value), eui_ddwnOrientamentoTavoli.Text, eui_ddwnDimensioneTavoli.Text)

         Dim i As Integer
         For i = 1 To NumTavoli
            Dim datiTavolo() As String
            datiTavolo = Tavolo(i).Tag.ToString.Split(";")

            ' Modifica i dati.
            Tavolo(i).Tag = datiTavolo(0) & ";" & datiTavolo(1) & ";" & eui_ddwnDimensioneTavoli.Text & ";" & datiTavolo(3)
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_btnTastoGrande_Click(sender As Object, e As EventArgs) Handles eui_btnTastoGrande.Click
      Try
         ' Imposta l'orientamento del Tavolo.
         eui_ddwnDimensioneTavoli.Text = eui_btnTastoGrande.Text

         ' Imposta l'anteprima del tasto.
         CalcolaDimensioneTavolo(Convert.ToInt32(eui_nudDimensionePosti.Value), eui_ddwnOrientamentoTavoli.Text, eui_ddwnDimensioneTavoli.Text)

         Dim i As Integer
         For i = 1 To NumTavoli
            Dim datiTavolo() As String
            datiTavolo = Tavolo(i).Tag.ToString.Split(";")

            ' Modifica i dati.
            Tavolo(i).Tag = datiTavolo(0) & ";" & datiTavolo(1) & ";" & eui_ddwnDimensioneTavoli.Text & ";" & datiTavolo(3)
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region "Tasti Funzione Tavoli"

   Private Sub CreaTastoFunzioneTavoli(ByVal nome As String, ByVal id As Integer, ByVal coloreSfondo As Color, ByVal coloreTesto As Color, ByVal stileTasto As NetButton.ColorStyleEnum)
      Try
         NumFunzioniTavoli += 1

         FunzioneTavolo(NumFunzioniTavoli) = New NetButton
         FunzioneTavolo(NumFunzioniTavoli).Name = id.ToString
         FunzioneTavolo(NumFunzioniTavoli).Tag = nome
         FunzioneTavolo(NumFunzioniTavoli).Size = New Size(LARGHEZZA_FUNZIONI, ALTEZZA_FUNZIONI)

         If stileTasto = NetButton.ColorStyleEnum.Custom Then
            FunzioneTavolo(NumFunzioniTavoli).ColorStyle = NetButton.ColorStyleEnum.Custom
            FunzioneTavolo(NumFunzioniTavoli).ColorBottom = coloreSfondo
            FunzioneTavolo(NumFunzioniTavoli).ColorText = coloreTesto
         Else
            FunzioneTavolo(NumFunzioniTavoli).ColorStyle = stileTasto
         End If

         FunzioneTavolo(NumFunzioniTavoli).TextButton = nome
         FunzioneTavolo(NumFunzioniTavoli).Visible = False

         pnlFunzioniTavoli.Controls.Add(FunzioneTavolo(NumFunzioniTavoli))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ReimpostaListaFunzioniTavoli(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim FunzioneTavolo(LeggiNumRecord(TAB_POS_IMPOSTAZIONI_TAVOLI))
         NumFunzioniTavoli = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("Descrizione").ToString)

            Select Case dr.Item("Descrizione").ToString
               Case TASTO_APRI
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzioneTavoli(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Green)

               Case TASTO_PRENOTA
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzioneTavoli(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_ASPORTO
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzioneTavoli(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO_ASPORTO, COLORE_TESTO_TASTO_ASPORTO, NetButton.ColorStyleEnum.Custom)

               Case TASTO_BLOCCA_SBLOCCA_TAVOLI
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzioneTavoli(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Red)

               Case TASTO_PUNTO_CASSA
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzioneTavoli(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Green)

               Case TASTO_ESCI
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzioneTavoli(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Red)

               Case Else
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzioneTavoli(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Custom)

            End Select
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaListaFunzioniTavoli(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim FunzioneTavolo(LeggiNumRecord(TAB_POS_IMPOSTAZIONI_TAVOLI))
         NumFunzioniTavoli = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("Descrizione").ToString)

            ' Crea il pulsante Funzione per memorizzare i dati.
            CreaTastoFunzioneTavoli(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), dr.Item("ColoreStile"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Function SalvaImpostazioniFunzioniTavoli() As Boolean
      Try
         Dim AFunzioni As New ImpostazioniTavoliPOS

         Dim i As Integer
         For i = 0 To lstFunzioniTavoli.Items.Count - 1

            Dim y As Integer
            For y = 1 To NumFunzioniTavoli
               ' Modifica le proprietà.
               If lstFunzioniTavoli.Items(i).ToString = FunzioneTavolo(y).TextButton Then
                  ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
                  AFunzioni.ModificaDati(FunzioneTavolo(y).ColorStyle, FunzioneTavolo(y).ColorBottom.ToArgb, FunzioneTavolo(y).ColorText.ToArgb, FunzioneTavolo(y).TextButton, TAB_POS_IMPOSTAZIONI_TAVOLI)
                  Exit For
               End If
            Next
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub ModificaColoreSfondoFunzioneTavoli()
      Try
         With ColorDialog1()
            .Color = cmdColoreSfondoFunzioniTavoli.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreSfondoFunzioniTavoli.BackColor = .Color
               netBtn_AnteprimaFunzioniTavoli.ColorBottom = .Color
               FunzioneTavolo(funzioneTavoloSelezionata).ColorBottom = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaColoreTestoFunzioneTavoli()
      Try
         With ColorDialog1()
            .Color = cmdColoreTestoFunzioniTavoli.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreTestoFunzioniTavoli.BackColor = .Color
               netBtn_AnteprimaFunzioniTavoli.ColorText = .Color
               FunzioneTavolo(funzioneTavoloSelezionata).ColorText = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SelezionaColoreFunzioniTavoli(ByVal nomeColore As String, ByVal stileColore As NetButton.ColorStyleEnum)
      Try
         eui_ddwnStileColoreFunzioniTavoli.Text = nomeColore

         netBtn_AnteprimaFunzioniTavoli.ColorStyle = stileColore

         FunzioneTavolo(funzioneTavoloSelezionata).ColorStyle = stileColore

         cmdColoreSfondoFunzioniTavoli.BackColor = FunzioneTavolo(funzioneTavoloSelezionata).ColorBottom
         cmdColoreTestoFunzioniTavoli.BackColor = FunzioneTavolo(funzioneTavoloSelezionata).ColorText

         cmdColoreSfondoFunzioniTavoli.Enabled = False
         cmdColoreTestoFunzioniTavoli.Enabled = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdReimpostaFunzioniTavoli_Click(sender As Object, e As EventArgs) Handles eui_cmdReimpostaFunzioniTavoli.Click
      Try
         ' Rimuove tutti i pulsanti.
         pnlFunzioniTavoli.Controls.Clear()

         ' Rimuove tutti gli elementi dalla lista.
         lstFunzioniTavoli.Items.Clear()

         ' Carica la lista con le impostazioni di default.
         ReimpostaListaFunzioniTavoli(lstFunzioniTavoli, "OrdineTasto", TAB_POS_IMPOSTAZIONI_TAVOLI)

         lstFunzioniTavoli.SelectedIndex = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lstFunzioniTavoli_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFunzioniTavoli.SelectedIndexChanged
      Try
         Dim i As Integer
         For i = 1 To NumFunzioniTavoli
            ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
            ' Se lo trova assegna le proprietà ai controlli.
            If lstFunzioniTavoli.Text = FunzioneTavolo(i).TextButton Then
               ' Disattiva i controlli colore.
               cmdColoreSfondoFunzioniTavoli.Enabled = False
               cmdColoreTestoFunzioniTavoli.Enabled = False

               ' Nome Tasto.
               netBtn_AnteprimaFunzioniTavoli.TextButton = FunzioneTavolo(i).TextButton

               ' Stile colore.
               If FunzioneTavolo(i).ColorBottom.ToArgb = COLORE_SFONDO_TASTO.ToArgb And FunzioneTavolo(i).ColorText.ToArgb = COLORE_TESTO_TASTO.ToArgb Then
                  eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColorePredefinito.Text
               Else
                  Select Case FunzioneTavolo(i).ColorStyle
                     Case NetButton.ColorStyleEnum.Custom
                        eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColorePersonalizzato.Text

                        ' Attiva i controlli colore.
                        cmdColoreSfondoFunzioniTavoli.Enabled = True
                        cmdColoreTestoFunzioniTavoli.Enabled = True

                     Case NetButton.ColorStyleEnum.Default
                        eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColoreBianco.Text

                     Case NetButton.ColorStyleEnum.Blue
                        eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColoreBlu.Text

                     Case NetButton.ColorStyleEnum.Gray
                        eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColoreGrigio.Text

                     Case NetButton.ColorStyleEnum.Green
                        eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColoreVerde.Text

                     Case NetButton.ColorStyleEnum.Pink
                        eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColoreViola.Text

                     Case NetButton.ColorStyleEnum.Red
                        eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColoreRosso.Text

                     Case NetButton.ColorStyleEnum.Yellow
                        eui_ddwnStileColoreFunzioniTavoli.Text = eui_btnColoreGiallo.Text

                  End Select
               End If

               ' Colore di sfondo.
               cmdColoreSfondoFunzioniTavoli.BackColor = FunzioneTavolo(i).ColorBottom
               netBtn_AnteprimaFunzioniTavoli.ColorBottom = FunzioneTavolo(i).ColorBottom

               ' Colore del testo.
               cmdColoreTestoFunzioniTavoli.BackColor = FunzioneTavolo(i).ColorText
               netBtn_AnteprimaFunzioniTavoli.ColorText = FunzioneTavolo(i).ColorText

               ' Salva l'indice dell'elemento selezionato.
               funzioneTavoloSelezionata = i

               Exit Sub
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub cmdColoreSfondoFunzioniTavoli_Click(sender As Object, e As EventArgs) Handles cmdColoreSfondoFunzioniTavoli.Click
      ModificaColoreSfondoFunzioneTavoli()
   End Sub

   Private Sub cmdColoreTestoFunzioniTavoli_Click(sender As Object, e As EventArgs) Handles cmdColoreTestoFunzioniTavoli.Click
      ModificaColoreTestoFunzioneTavoli()
   End Sub


#End Region

#Region "Tasti Categorie Piatti "

   Private Sub CreaTastoCategoria(ByVal nome As String, ByVal id As Integer, ByVal altezza As Integer, ByVal immagine As String, ByVal coloreSfondo As Color, ByVal coloreTesto As Color, ByVal stileTasto As NetButton.ColorStyleEnum)
      Try
         NumCategorie += 1

         Categoria(NumCategorie) = New NetButton
         Categoria(NumCategorie).Name = id.ToString
         Categoria(NumCategorie).Tag = immagine
         Categoria(NumCategorie).Size = New Size(LARGHEZZA_CATEGORIE, altezza)

         If stileTasto = NetButton.ColorStyleEnum.Custom Then
            Categoria(NumCategorie).ColorStyle = NetButton.ColorStyleEnum.Custom
            Categoria(NumCategorie).ColorBottom = coloreSfondo
            Categoria(NumCategorie).ColorText = coloreTesto
         Else
            Categoria(NumCategorie).ColorStyle = stileTasto
         End If

         Categoria(NumCategorie).TextButton = nome
         Categoria(NumCategorie).Visible = False

         If File.Exists(immagine) = True Then
            Dim bmp As New Bitmap(immagine)
            Categoria(NumCategorie).Image = bmp
         End If

         pnlCategorie.Controls.Add(Categoria(NumCategorie))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ReimpostaListaCategorie(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim Categoria(LeggiNumRecord(ANA_CATEGORIE))
         NumCategorie = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("Descrizione").ToString)

            ' Crea il pulsante Categoria per memorizzare i dati.
            CreaTastoCategoria(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), ALTEZZA_CATEGORIE, String.Empty, COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Custom)

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaListaCategorie(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim Categoria(LeggiNumRecord(ANA_CATEGORIE))
         NumCategorie = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("Descrizione").ToString)

            ' Crea il pulsante Categoria per memorizzare i dati.
            CreaTastoCategoria(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), Convert.ToInt32(dr.Item("AltezzaTasto")), dr.Item("Icona").ToString, Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), dr.Item("ColoreStile"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Function SalvaImpostazioniCategorie() As Boolean
      Try
         Dim ACategorie As New CategoriePiatti

         Dim i As Integer
         For i = 0 To lstCategorie.Items.Count - 1

            Dim y As Integer
            For y = 1 To NumCategorie
               ' Modifica le proprietà.
               If lstCategorie.Items(i).ToString = Categoria(y).TextButton Then
                  ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
                  ACategorie.ModificaDati(Categoria(y).ColorStyle, Categoria(y).ColorBottom.ToArgb, Categoria(y).ColorText.ToArgb, Categoria(y).Size.Height, Categoria(y).Tag.ToString, Categoria(y).TextButton, ANA_CATEGORIE)
                  Exit For
               End If
            Next
         Next

         i = 0

         For i = 0 To lstCategorie.Items.Count - 1
            ' Modifica l'ordine.
            ACategorie.ModificaOrdineTasto(i, lstCategorie.Items(i).ToString, ANA_CATEGORIE)
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub ModificaColoreSfondoCategorie()
      Try
         With ColorDialog1()
            .Color = cmdColoreSfondoCategorie.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreSfondoCategorie.BackColor = .Color
               netBtn_AnteprimaCategorie.ColorBottom = .Color
               Categoria(categoriaSelezionata).ColorBottom = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaColoreTestoCategorie()
      Try
         With ColorDialog1()
            .Color = cmdColoreTestoCategorie.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreTestoCategorie.BackColor = .Color
               netBtn_AnteprimaCategorie.ColorText = .Color
               Categoria(categoriaSelezionata).ColorText = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub InserisciImmagineCategorie()
      Try
         With OpenFileDialog1
            .Filter = "Tutti i formati |*.Ico; *.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" &
                      "Ico (Icona di Windows)|*.Ico|" &
                      "Bmp (Bitmap di Windows)|*.Bmp|" &
                      "Gif |*.Gif|" &
                      "Jpeg/Jpg |*.Jpg; *.Jpeg |" &
                      "Png |*.Png|" &
                      "Tga |*.Tga|" &
                      "Tiff |*.Tiff|" &
                      "Wmf (Metafile di Windows) |*.Wmf"

            .FilterIndex = 1
            .InitialDirectory = Application.StartupPath & "\Immagini"

            If .ShowDialog = DialogResult.OK Then
               If File.Exists(.FileName) = True Then
                  Dim bmp As New Bitmap(.FileName)

                  netBtn_AnteprimaCategorie.TextButtonAlign = ContentAlignment.BottomCenter
                  netBtn_AnteprimaCategorie.Image = bmp

                  Categoria(categoriaSelezionata).Image = bmp
                  Categoria(categoriaSelezionata).Tag = .FileName
               End If
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub RimuoviImmagineCategorie()
      Try
         If IsNothing(netBtn_AnteprimaCategorie.Image) = False Then
            netBtn_AnteprimaCategorie.TextButtonAlign = ContentAlignment.MiddleCenter
            netBtn_AnteprimaCategorie.Image.Dispose()
            netBtn_AnteprimaCategorie.Image = Nothing
            Categoria(categoriaSelezionata).Image.Dispose()
            Categoria(categoriaSelezionata).Image = Nothing
            Categoria(categoriaSelezionata).Tag = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SelezionaColoreCategorie(ByVal nomeColore As String, ByVal stileColore As NetButton.ColorStyleEnum)
      Try
         eui_ddwnStileColoreCategorie.Text = nomeColore

         netBtn_AnteprimaCategorie.ColorStyle = stileColore

         Categoria(categoriaSelezionata).ColorStyle = stileColore

         cmdColoreSfondoCategorie.BackColor = Categoria(categoriaSelezionata).ColorBottom
         cmdColoreTestoCategorie.BackColor = Categoria(categoriaSelezionata).ColorText

         cmdColoreSfondoCategorie.Enabled = False
         cmdColoreTestoCategorie.Enabled = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdSpostaSuCategorie_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaSuCategorie.Click
      ' Sposta in alto di una posizione l'elemento selezionato.
      SpostaElememtoSu(lstCategorie)
   End Sub

   Private Sub eui_cmdSpostaGiùCategorie_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaGiùCategorie.Click
      ' Sposta in basso di una posizione l'elemento selezionato.
      SpostaElememtoGiù(lstCategorie)
   End Sub

   Private Sub eui_cmdReimpostaCategorie_Click(sender As Object, e As EventArgs) Handles eui_cmdReimpostaCategorie.Click
      Try
         ' Rimuove tutti i pulsanti.
         pnlCategorie.Controls.Clear()

         ' Rimuove tutti gli elementi dalla lista.
         lstCategorie.Items.Clear()

         ' Carica la lista con le impostazioni di default.
         ReimpostaListaCategorie(lstCategorie, "Id", ANA_CATEGORIE)

         lstCategorie.SelectedIndex = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub lstCategorie_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstCategorie.SelectedIndexChanged
      Try
         Dim i As Integer
         For i = 1 To NumCategorie
            ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
            ' Se lo trova assegna le proprietà ai controlli.
            If lstCategorie.Text = Categoria(i).TextButton Then
               ' Disattiva i controlli colore.
               cmdColoreSfondoCategorie.Enabled = False
               cmdColoreTestoCategorie.Enabled = False

               ' Nome Tasto.
               netBtn_AnteprimaCategorie.TextButton = Categoria(i).TextButton

               ' Stile colore.
               If Categoria(i).ColorBottom.ToArgb = COLORE_SFONDO_TASTO.ToArgb And Categoria(i).ColorText.ToArgb = COLORE_TESTO_TASTO.ToArgb Then
                  eui_ddwnStileColoreCategorie.Text = eui_btnColorePredefinito.Text
               Else
                  Select Case Categoria(i).ColorStyle
                     Case NetButton.ColorStyleEnum.Custom
                        eui_ddwnStileColoreCategorie.Text = eui_btnColorePersonalizzato.Text

                        ' Attiva i controlli colore.
                        cmdColoreSfondoCategorie.Enabled = True
                        cmdColoreTestoCategorie.Enabled = True

                     Case NetButton.ColorStyleEnum.Default
                        eui_ddwnStileColoreCategorie.Text = eui_btnColoreBianco.Text

                     Case NetButton.ColorStyleEnum.Blue
                        eui_ddwnStileColoreCategorie.Text = eui_btnColoreBlu.Text

                     Case NetButton.ColorStyleEnum.Gray
                        eui_ddwnStileColoreCategorie.Text = eui_btnColoreGrigio.Text

                     Case NetButton.ColorStyleEnum.Green
                        eui_ddwnStileColoreCategorie.Text = eui_btnColoreVerde.Text

                     Case NetButton.ColorStyleEnum.Pink
                        eui_ddwnStileColoreCategorie.Text = eui_btnColoreViola.Text

                     Case NetButton.ColorStyleEnum.Red
                        eui_ddwnStileColoreCategorie.Text = eui_btnColoreRosso.Text

                     Case NetButton.ColorStyleEnum.Yellow
                        eui_ddwnStileColoreCategorie.Text = eui_btnColoreGiallo.Text

                  End Select
               End If

               ' Colore di sfondo.
               cmdColoreSfondoCategorie.BackColor = Categoria(i).ColorBottom
               netBtn_AnteprimaCategorie.ColorBottom = Categoria(i).ColorBottom

               ' Colore del testo.
               cmdColoreTestoCategorie.BackColor = Categoria(i).ColorText
               netBtn_AnteprimaCategorie.ColorText = Categoria(i).ColorText

               ' Altezza del tasto.
               eui_nudAltezzaCategorie.Value = Categoria(i).Size.Height

               ' Immagine.
               If File.Exists(Categoria(i).Tag.ToString) = True Then
                  Dim bmp As New Bitmap(Categoria(i).Tag.ToString)
                  netBtn_AnteprimaCategorie.TextButtonAlign = ContentAlignment.BottomCenter
                  netBtn_AnteprimaCategorie.Image = bmp
               Else
                  If IsNothing(netBtn_AnteprimaCategorie.Image) = False Then
                     netBtn_AnteprimaCategorie.TextButtonAlign = ContentAlignment.MiddleCenter
                     netBtn_AnteprimaCategorie.Image.Dispose()
                     netBtn_AnteprimaCategorie.Image = Nothing
                  End If
               End If

               ' Salva l'indice dell'elemento selezionato.
               categoriaSelezionata = i

               Exit Sub
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub cmdColoreSfondoCategorie_Click(sender As Object, e As EventArgs) Handles cmdColoreSfondoCategorie.Click
      ModificaColoreSfondoCategorie()
   End Sub

   Private Sub cmdColoreTestoCategorie_Click(sender As Object, e As EventArgs) Handles cmdColoreTestoCategorie.Click
      ModificaColoreTestoCategorie()
   End Sub

   Private Sub eui_nudAltezzaCategorie_ValueChanged(sender As Object, e As EventArgs) Handles eui_nudAltezzaCategorie.ValueChanged
      Try
         ' Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudAltezzaCategorie.Value

            Case Is < eui_nudAltezzaCategorie.Minimum
               eui_nudAltezzaCategorie.Value = eui_nudAltezzaCategorie.Minimum

            Case Is > eui_nudAltezzaCategorie.Maximum
               eui_nudAltezzaCategorie.Value = eui_nudAltezzaCategorie.Maximum

         End Select

         ' Imposta l'anteprima del tasto.
         netBtn_AnteprimaCategorie.Size = New Drawing.Size(netBtn_AnteprimaCategorie.Size.Width, Convert.ToInt32(eui_nudAltezzaCategorie.Value))

         Dim i As Integer
         For i = 1 To NumCategorie
            ' Modifica i dati.
            Categoria(i).Size = New Drawing.Size(LARGHEZZA_CATEGORIE, Convert.ToInt32(eui_nudAltezzaCategorie.Value))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdInserisciImg_Click(sender As Object, e As EventArgs) Handles eui_cmdInserisciImgCategorie.Click
      InserisciImmagineCategorie()
   End Sub

   Private Sub eui_cmdRimuoviImg_Click(sender As Object, e As EventArgs) Handles eui_cmdRimuoviImgCategorie.Click
      RimuoviImmagineCategorie()
   End Sub

#End Region

#Region "Tasti Piatti "

   Private Sub CreaTastoPiatto(ByVal nome As String, ByVal id As Integer, ByVal altezza As Integer, ByVal larghezza As Integer, ByVal numTastiRiga As Integer, ByVal immagine As String, ByVal coloreSfondo As Color, ByVal coloreTesto As Color, ByVal stileTasto As NetButton.ColorStyleEnum)
      Try
         NumPiatti += 1

         Piatto(NumPiatti) = New NetButton
         Piatto(NumPiatti).Name = id.ToString
         Piatto(NumPiatti).Tag = numTastiRiga & ";" & immagine
         Piatto(NumPiatti).Size = New Size(larghezza, altezza)

         If stileTasto = NetButton.ColorStyleEnum.Custom Then
            Piatto(NumPiatti).ColorStyle = NetButton.ColorStyleEnum.Custom
            Piatto(NumPiatti).ColorBottom = coloreSfondo
            Piatto(NumPiatti).ColorText = coloreTesto
         Else
            Piatto(NumPiatti).ColorStyle = stileTasto
         End If

         Piatto(NumPiatti).TextButton = nome
         Piatto(NumPiatti).Visible = False

         If File.Exists(immagine) = True Then
            Dim bmp As New Bitmap(immagine)
            Piatto(NumPiatti).Image = bmp
         End If

         pnlPiatti.Controls.Add(Piatto(NumPiatti))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ReimpostaListaPiatti(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim Piatto(LeggiNumRecordPiatti(ANA_PIATTI, "No"))
         NumPiatti = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Variazione = 'No' ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("DescrizionePos").ToString)

            ' Crea il pulsante Categoria per memorizzare i dati.
            CreaTastoPiatto(dr.Item("DescrizionePos").ToString, Convert.ToInt32(dr.Item("Id")), ALTEZZA_PIATTO, LARGHEZZA_PIATTO, NUM_TASTI_RIGA, String.Empty, COLORE_SFONDO_TASTO_PIATTO, COLORE_TESTO_TASTO_PIATTO, NetButton.ColorStyleEnum.Custom)

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaListaPiatti(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim Piatto(LeggiNumRecordPiatti(ANA_PIATTI, "No"))
         NumPiatti = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Variazione = 'No' ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("DescrizionePos").ToString)

            ' Crea il pulsante Categoria per memorizzare i dati.
            CreaTastoPiatto(dr.Item("DescrizionePos").ToString, Convert.ToInt32(dr.Item("Id")), Convert.ToInt32(dr.Item("AltezzaTasto")), Convert.ToInt32(dr.Item("LarghezzaTasto")), Convert.ToInt32(dr.Item("NumTastiRiga")), dr.Item("Icona").ToString, Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), dr.Item("ColoreStile"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Function SalvaImpostazioniPiatti() As Boolean
      Try
         Dim APiatti As New Piatti

         Dim i As Integer
         For i = 0 To lstPiatti.Items.Count - 1

            Dim y As Integer
            For y = 1 To NumPiatti
               ' Modifica le proprietà.
               If lstPiatti.Items(i).ToString = Piatto(y).TextButton Then

                  Dim datiPiatto() As String
                  datiPiatto = Piatto(y).Tag.ToString.Split(";")

                  ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
                  APiatti.ModificaDati(Piatto(y).ColorStyle, Piatto(y).ColorBottom.ToArgb, Piatto(y).ColorText.ToArgb, Piatto(y).Size.Height, Piatto(y).Size.Width, Convert.ToInt32(datiPiatto(0)), datiPiatto(1).ToString, Piatto(y).TextButton, ANA_PIATTI)
                  Exit For
               End If
            Next
         Next

         i = 0

         For i = 0 To lstPiatti.Items.Count - 1
            ' Modifica l'ordine.
            APiatti.ModificaOrdineTasto(i, lstPiatti.Items(i).ToString, ANA_PIATTI)
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub ModificaColoreSfondoPiatti()
      Try
         With ColorDialog1()
            .Color = cmdColoreSfondoPiatti.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreSfondoPiatti.BackColor = .Color
               netBtn_AnteprimaPiatti.ColorBottom = .Color
               Piatto(piattoSelezionato).ColorBottom = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaColoreTestoPiatti()
      Try
         With ColorDialog1()
            .Color = cmdColoreTestoPiatti.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreTestoPiatti.BackColor = .Color
               netBtn_AnteprimaPiatti.ColorText = .Color
               Piatto(piattoSelezionato).ColorText = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub InserisciImmaginePiatti()
      Try
         With OpenFileDialog1
            .Filter = "Tutti i formati |*.Ico; *.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" &
                      "Ico (Icona di Windows)|*.Ico|" &
                      "Bmp (Bitmap di Windows)|*.Bmp|" &
                      "Gif |*.Gif|" &
                      "Jpeg/Jpg |*.Jpg; *.Jpeg |" &
                      "Png |*.Png|" &
                      "Tga |*.Tga|" &
                      "Tiff |*.Tiff|" &
                      "Wmf (Metafile di Windows) |*.Wmf"

            .FilterIndex = 1
            .InitialDirectory = Application.StartupPath & "\Immagini"

            If .ShowDialog = DialogResult.OK Then
               If File.Exists(.FileName) = True Then
                  Dim bmp As New Bitmap(.FileName)

                  netBtn_AnteprimaPiatti.TextButtonAlign = ContentAlignment.BottomCenter
                  netBtn_AnteprimaPiatti.Image = bmp

                  Piatto(piattoSelezionato).Image = bmp
                  Piatto(piattoSelezionato).Tag = eui_nudNumTastiRigaPiatti.Value.ToString & ";" & .FileName
               End If
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub RimuoviImmaginePiatti()
      Try
         If IsNothing(netBtn_AnteprimaPiatti.Image) = False Then
            netBtn_AnteprimaPiatti.TextButtonAlign = ContentAlignment.MiddleCenter
            netBtn_AnteprimaPiatti.Image.Dispose()
            netBtn_AnteprimaPiatti.Image = Nothing
            Piatto(piattoSelezionato).Image.Dispose()
            Piatto(piattoSelezionato).Image = Nothing
            Piatto(piattoSelezionato).Tag = eui_nudNumTastiRigaPiatti.Value.ToString & ";" & String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SelezionaColorePiatti(ByVal nomeColore As String, ByVal stileColore As NetButton.ColorStyleEnum)
      Try
         eui_ddwnStileColorePiatti.Text = nomeColore

         netBtn_AnteprimaPiatti.ColorStyle = stileColore

         Piatto(piattoSelezionato).ColorStyle = stileColore

         cmdColoreSfondoPiatti.BackColor = Piatto(piattoSelezionato).ColorBottom
         cmdColoreTestoPiatti.BackColor = Piatto(piattoSelezionato).ColorText

         cmdColoreSfondoPiatti.Enabled = False
         cmdColoreTestoPiatti.Enabled = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdSpostaSuPiatti_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaSuPiatti.Click
      ' Sposta in alto di una posizione l'elemento selezionato.
      SpostaElememtoSu(lstPiatti)
   End Sub

   Private Sub eui_cmdSpostaGiùPiatti_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaGiùPiatti.Click
      ' Sposta in basso di una posizione l'elemento selezionato.
      SpostaElememtoGiù(lstPiatti)
   End Sub

   Private Sub eui_cmdReimpostaPiatti_Click(sender As Object, e As EventArgs) Handles eui_cmdReimpostaPiatti.Click
      Try
         ' Rimuove tutti i pulsanti.
         pnlPiatti.Controls.Clear()

         ' Rimuove tutti gli elementi dalla lista.
         lstPiatti.Items.Clear()

         ' Carica la lista con le impostazioni di default.
         ReimpostaListaPiatti(lstPiatti, "Id", ANA_PIATTI)

         lstPiatti.SelectedIndex = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lstPiatti_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstPiatti.SelectedIndexChanged
      Try
         Dim i As Integer
         For i = 1 To NumPiatti
            ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
            ' Se lo trova assegna le proprietà ai controlli.
            If lstPiatti.Text = Piatto(i).TextButton Then
               Dim datiPiatti() As String
               datiPiatti = Piatto(i).Tag.ToString.Split(";")

               Dim altezza As Integer = Piatto(i).Size.Height
               Dim larghezza As Integer = Piatto(i).Size.Width

               ' Disattiva i controlli colore.
               cmdColoreSfondoPiatti.Enabled = False
               cmdColoreTestoPiatti.Enabled = False

               ' Nome Tasto.
               netBtn_AnteprimaPiatti.TextButton = Piatto(i).TextButton

               ' Stile colore.
               If Piatto(i).ColorBottom.ToArgb = COLORE_SFONDO_TASTO_PIATTO.ToArgb And Piatto(i).ColorText.ToArgb = COLORE_TESTO_TASTO_PIATTO.ToArgb Then
                  eui_ddwnStileColorePiatti.Text = eui_btnColorePredefinito.Text
               Else
                  Select Case Piatto(i).ColorStyle
                     Case NetButton.ColorStyleEnum.Custom
                        eui_ddwnStileColorePiatti.Text = eui_btnColorePersonalizzato.Text

                        ' Attiva i controlli colore.
                        cmdColoreSfondoPiatti.Enabled = True
                        cmdColoreTestoPiatti.Enabled = True

                     Case NetButton.ColorStyleEnum.Default
                        eui_ddwnStileColorePiatti.Text = eui_btnColoreBianco.Text

                     Case NetButton.ColorStyleEnum.Blue
                        eui_ddwnStileColorePiatti.Text = eui_btnColoreBlu.Text

                     Case NetButton.ColorStyleEnum.Gray
                        eui_ddwnStileColorePiatti.Text = eui_btnColoreGrigio.Text

                     Case NetButton.ColorStyleEnum.Green
                        eui_ddwnStileColorePiatti.Text = eui_btnColoreVerde.Text

                     Case NetButton.ColorStyleEnum.Pink
                        eui_ddwnStileColorePiatti.Text = eui_btnColoreViola.Text

                     Case NetButton.ColorStyleEnum.Red
                        eui_ddwnStileColorePiatti.Text = eui_btnColoreRosso.Text

                     Case NetButton.ColorStyleEnum.Yellow
                        eui_ddwnStileColorePiatti.Text = eui_btnColoreGiallo.Text

                  End Select
               End If

               ' Colore di sfondo.
               cmdColoreSfondoPiatti.BackColor = Piatto(i).ColorBottom
               netBtn_AnteprimaPiatti.ColorBottom = Piatto(i).ColorBottom

               ' Colore del testo.
               cmdColoreTestoPiatti.BackColor = Piatto(i).ColorText
               netBtn_AnteprimaPiatti.ColorText = Piatto(i).ColorText

               ' Altezza del tasto.
               eui_nudAltezzaPiatti.Value = Convert.ToDecimal(altezza)

               ' Larghezza del tasto.
               eui_nudLarghezzaPiatti.Value = Convert.ToDecimal(larghezza)

               ' Numero di tasti per riga.
               eui_nudNumTastiRigaPiatti.Value = Convert.ToDecimal(datiPiatti(0))

               ' Immagine.
               If File.Exists(datiPiatti(1).ToString) = True Then
                  Dim bmp As New Bitmap(datiPiatti(1).ToString)
                  netBtn_AnteprimaPiatti.TextButtonAlign = ContentAlignment.BottomCenter
                  netBtn_AnteprimaPiatti.Image = bmp
               Else
                  If IsNothing(netBtn_AnteprimaPiatti.Image) = False Then
                     netBtn_AnteprimaPiatti.TextButtonAlign = ContentAlignment.MiddleCenter
                     netBtn_AnteprimaPiatti.Image.Dispose()
                     netBtn_AnteprimaPiatti.Image = Nothing
                  End If
               End If

               ' Salva l'indice dell'elemento selezionato.
               piattoSelezionato = i

               Exit Sub
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub cmdColoreSfondoPiatti_Click(sender As Object, e As EventArgs) Handles cmdColoreSfondoPiatti.Click
      ModificaColoreSfondoPiatti()
   End Sub

   Private Sub cmdColoreTestoPiatti_Click(sender As Object, e As EventArgs) Handles cmdColoreTestoPiatti.Click
      ModificaColoreTestoPiatti()
   End Sub

   Private Sub eui_nudAltezzaPiatti_ValueChanged(sender As Object, e As EventArgs) Handles eui_nudAltezzaPiatti.ValueChanged
      Try
         ' Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudAltezzaPiatti.Value

            Case Is < eui_nudAltezzaPiatti.Minimum
               eui_nudAltezzaPiatti.Value = eui_nudAltezzaPiatti.Minimum

            Case Is > eui_nudAltezzaPiatti.Maximum
               eui_nudAltezzaPiatti.Value = eui_nudAltezzaPiatti.Maximum

         End Select

         ' Imposta l'anteprima del tasto.
         netBtn_AnteprimaPiatti.Size = New Drawing.Size(netBtn_AnteprimaPiatti.Size.Width, Convert.ToInt32(eui_nudAltezzaPiatti.Value))

         Dim i As Integer
         For i = 1 To NumPiatti
            ' Modifica i dati.
            Piatto(i).Size = New Drawing.Size(LARGHEZZA_PIATTO, Convert.ToInt32(eui_nudAltezzaPiatti.Value))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_nudLarghezzaPiatti_ValueChanged(sender As Object, e As EventArgs) Handles eui_nudLarghezzaPiatti.ValueChanged
      Try
         'Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudLarghezzaPiatti.Value
            Case 1
               eui_nudLarghezzaPiatti.Value = LARGHEZZA_PIATTO

            Case LARGHEZZA_PIATTO - 1
               eui_nudLarghezzaPiatti.Value = 0

            Case Is > eui_nudLarghezzaPiatti.Maximum
               eui_nudLarghezzaPiatti.Value = eui_nudLarghezzaPiatti.Maximum

         End Select

         ' Imposta l'anteprima del tasto.
         If eui_nudLarghezzaPiatti.Value <> 0 Then
            netBtn_AnteprimaPiatti.Size = New Drawing.Size(Convert.ToInt32(eui_nudLarghezzaPiatti.Value), Convert.ToInt32(eui_nudAltezzaPiatti.Value))

         Else
            netBtn_AnteprimaPiatti.Size = New Drawing.Size(LARGHEZZA_PIATTO, Convert.ToInt32(eui_nudAltezzaPiatti.Value))
         End If

         ' Centra il pulsante nel controllo contenitore.
         netBtn_AnteprimaPiatti.Location = CentraControllo(netBtn_AnteprimaPiatti, GroupBox14)

         Dim i As Integer
         For i = 1 To NumPiatti
            ' Modifica i dati.
            Piatto(i).Size = New Drawing.Size(Convert.ToInt32(eui_nudLarghezzaPiatti.Value), Convert.ToInt32(eui_nudAltezzaPiatti.Value))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_nudLarghezzaPiatti_LostFocus(sender As Object, e As EventArgs) Handles eui_nudLarghezzaPiatti.LostFocus
      Try
         ' Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudLarghezzaPiatti.Value
            Case Is < LARGHEZZA_PIATTO
               eui_nudLarghezzaPiatti.Value = 0

            Case Is > eui_nudLarghezzaPiatti.Maximum
               eui_nudLarghezzaPiatti.Value = eui_nudLarghezzaPiatti.Maximum
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_nudNumTastiRigaPiatti_ValueChanged(sender As Object, e As EventArgs) Handles eui_nudNumTastiRigaPiatti.ValueChanged
      Try
         ' Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudNumTastiRigaPiatti.Value

            Case Is < eui_nudNumTastiRigaPiatti.Minimum
               eui_nudNumTastiRigaPiatti.Value = eui_nudNumTastiRigaPiatti.Minimum

            Case Is > eui_nudNumTastiRigaPiatti.Maximum
               eui_nudNumTastiRigaPiatti.Value = eui_nudNumTastiRigaPiatti.Maximum

         End Select

         Dim i As Integer
         For i = 1 To NumPiatti
            Dim datiPiatto() As String
            datiPiatto = Piatto(i).Tag.ToString.Split(";")

            ' Modifica i dati.
            Piatto(i).Tag = eui_nudNumTastiRigaPiatti.Value.ToString & ";" & datiPiatto(1)
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdInserisciImgPiatti_Click(sender As Object, e As EventArgs) Handles eui_cmdInserisciImgPiatti.Click
      InserisciImmaginePiatti()
   End Sub

   Private Sub eui_cmdRimuoviImgPiatti_Click(sender As Object, e As EventArgs) Handles eui_cmdRimuoviImgPiatti.Click
      RimuoviImmaginePiatti()
   End Sub

#End Region

#Region "Tasti Varianti "

   Private Sub CreaTastoVarianti(ByVal nome As String, ByVal id As Integer, ByVal altezza As Integer, ByVal immagine As String, ByVal coloreSfondo As Color, ByVal coloreTesto As Color, ByVal stileTasto As NetButton.ColorStyleEnum)
      Try
         NumVarianti += 1

         Variante(NumVarianti) = New NetButton
         Variante(NumVarianti).Name = id.ToString
         Variante(NumVarianti).Tag = immagine
         Variante(NumVarianti).Size = New Size(LARGHEZZA_VARIANTI, altezza)

         If stileTasto = NetButton.ColorStyleEnum.Custom Then
            Variante(NumVarianti).ColorStyle = NetButton.ColorStyleEnum.Custom
            Variante(NumVarianti).ColorBottom = coloreSfondo
            Variante(NumVarianti).ColorText = coloreTesto
         Else
            Variante(NumVarianti).ColorStyle = stileTasto
         End If

         Variante(NumVarianti).TextButton = nome
         Variante(NumVarianti).Visible = False

         If File.Exists(immagine) = True Then
            Dim bmp As New Bitmap(immagine)
            Variante(NumVarianti).Image = bmp
         End If

         pnlVarianti.Controls.Add(Variante(NumVarianti))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ReimpostaListaVarianti(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim Variante(LeggiNumRecordPiatti(ANA_PIATTI, "Sì"))
         NumVarianti = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Variazione = 'Sì' ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("DescrizionePos").ToString)

            ' Crea il pulsante Categoria per memorizzare i dati.
            CreaTastoVarianti(dr.Item("DescrizionePos").ToString, Convert.ToInt32(dr.Item("Id")), ALTEZZA_VARIANTI, String.Empty, COLORE_SFONDO_TASTO_PIATTO, COLORE_TESTO_TASTO_PIATTO, NetButton.ColorStyleEnum.Custom)
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaListaVarianti(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim Variante(LeggiNumRecordPiatti(ANA_PIATTI, "Sì"))
         NumVarianti = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Variazione = 'Sì' ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("DescrizionePos").ToString)

            ' Crea il pulsante Variante per memorizzare i dati.
            CreaTastoVarianti(dr.Item("DescrizionePos").ToString, Convert.ToInt32(dr.Item("Id")), Convert.ToInt32(dr.Item("AltezzaTasto")), dr.Item("Icona").ToString, Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), dr.Item("ColoreStile"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Function SalvaImpostazioniVarianti() As Boolean
      Try
         Dim AVarianti As New Piatti

         Dim i As Integer
         For i = 0 To lstVarianti.Items.Count - 1

            Dim y As Integer
            For y = 1 To NumVarianti
               ' Modifica le proprietà.
               If lstVarianti.Items(i).ToString = Variante(y).TextButton Then
                  ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
                  AVarianti.ModificaDati(Variante(y).ColorStyle, Variante(y).ColorBottom.ToArgb, Variante(y).ColorText.ToArgb, Variante(y).Size.Height, Variante(y).Size.Width, 0, Variante(y).Tag.ToString, Variante(y).TextButton, ANA_PIATTI)
                  Exit For
               End If
            Next
         Next

         i = 0

         For i = 0 To lstVarianti.Items.Count - 1
            ' Modifica l'ordine.
            AVarianti.ModificaOrdineTasto(i, lstVarianti.Items(i).ToString, ANA_PIATTI)
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub ModificaColoreSfondoVarianti()
      Try
         With ColorDialog1()
            .Color = cmdColoreSfondoVarianti.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreSfondoVarianti.BackColor = .Color
               netBtn_AnteprimaVarianti.ColorBottom = .Color
               Variante(varianteSelezionata).ColorBottom = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaColoreTestoVarianti()
      Try
         With ColorDialog1()
            .Color = cmdColoreTestoVarianti.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreTestoVarianti.BackColor = .Color
               netBtn_AnteprimaVarianti.ColorText = .Color
               Variante(varianteSelezionata).ColorText = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub InserisciImmagineVarianti()
      Try
         With OpenFileDialog1
            .Filter = "Tutti i formati |*.Ico; *.Bmp; *.Gif; *.Jpg; *.Jpeg; *.Png; *.Tga; *.Tiff; *.Wmf|" &
                      "Ico (Icona di Windows)|*.Ico|" &
                      "Bmp (Bitmap di Windows)|*.Bmp|" &
                      "Gif |*.Gif|" &
                      "Jpeg/Jpg |*.Jpg; *.Jpeg |" &
                      "Png |*.Png|" &
                      "Tga |*.Tga|" &
                      "Tiff |*.Tiff|" &
                      "Wmf (Metafile di Windows) |*.Wmf"

            .FilterIndex = 1
            .InitialDirectory = Application.StartupPath & "\Immagini"

            If .ShowDialog = DialogResult.OK Then
               If File.Exists(.FileName) = True Then
                  Dim bmp As New Bitmap(.FileName)

                  netBtn_AnteprimaVarianti.TextButtonAlign = ContentAlignment.BottomCenter
                  netBtn_AnteprimaVarianti.Image = bmp

                  Variante(varianteSelezionata).Image = bmp
                  Variante(varianteSelezionata).Tag = .FileName
               End If
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub RimuoviImmagineVarianti()
      Try
         If IsNothing(netBtn_AnteprimaVarianti.Image) = False Then
            netBtn_AnteprimaVarianti.TextButtonAlign = ContentAlignment.MiddleCenter
            netBtn_AnteprimaVarianti.Image.Dispose()
            netBtn_AnteprimaVarianti.Image = Nothing
            Variante(varianteSelezionata).Image.Dispose()
            Variante(varianteSelezionata).Image = Nothing
            Variante(varianteSelezionata).Tag = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SelezionaColoreVarianti(ByVal nomeColore As String, ByVal stileColore As NetButton.ColorStyleEnum)
      Try
         eui_ddwnStileColoreVarianti.Text = nomeColore

         netBtn_AnteprimaVarianti.ColorStyle = stileColore

         Variante(varianteSelezionata).ColorStyle = stileColore

         cmdColoreSfondoVarianti.BackColor = Variante(varianteSelezionata).ColorBottom
         cmdColoreTestoVarianti.BackColor = Variante(varianteSelezionata).ColorText

         cmdColoreSfondoVarianti.Enabled = False
         cmdColoreTestoVarianti.Enabled = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdSpostaSuVarianti_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaSuVarianti.Click
      ' Sposta in alto di una posizione l'elemento selezionato.
      SpostaElememtoSu(lstVarianti)
   End Sub

   Private Sub eui_cmdSpostaGiùVarianti_Click(sender As Object, e As EventArgs) Handles eui_cmdSpostaGiùVarianti.Click
      ' Sposta in basso di una posizione l'elemento selezionato.
      SpostaElememtoGiù(lstVarianti)
   End Sub

   Private Sub eui_cmdReimpostaVarianti_Click(sender As Object, e As EventArgs) Handles eui_cmdReimpostaVarianti.Click
      Try
         ' Rimuove tutti i pulsanti.
         pnlVarianti.Controls.Clear()

         ' Rimuove tutti gli elementi dalla lista.
         lstVarianti.Items.Clear()

         ' Carica la lista con le impostazioni di default.
         ReimpostaListaVarianti(lstVarianti, "Id", ANA_PIATTI)

         lstVarianti.SelectedIndex = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lstVarianti_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstVarianti.SelectedIndexChanged
      Try
         Dim i As Integer
         For i = 1 To NumVarianti
            ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
            ' Se lo trova assegna le proprietà ai controlli.
            If lstVarianti.Text = Variante(i).TextButton Then
               ' Disattiva i controlli colore.
               cmdColoreSfondoVarianti.Enabled = False
               cmdColoreTestoVarianti.Enabled = False

               ' Nome Tasto.
               netBtn_AnteprimaVarianti.TextButton = Variante(i).TextButton

               ' Stile colore.
               If Variante(i).ColorBottom.ToArgb = COLORE_SFONDO_TASTO_PIATTO.ToArgb And Variante(i).ColorText.ToArgb = COLORE_TESTO_TASTO_PIATTO.ToArgb Then
                  eui_ddwnStileColoreVarianti.Text = eui_btnColorePredefinito.Text
               Else
                  Select Case Variante(i).ColorStyle
                     Case NetButton.ColorStyleEnum.Custom
                        eui_ddwnStileColoreVarianti.Text = eui_btnColorePersonalizzato.Text

                        ' Attiva i controlli colore.
                        cmdColoreSfondoVarianti.Enabled = True
                        cmdColoreTestoVarianti.Enabled = True

                     Case NetButton.ColorStyleEnum.Default
                        eui_ddwnStileColoreVarianti.Text = eui_btnColoreBianco.Text

                     Case NetButton.ColorStyleEnum.Blue
                        eui_ddwnStileColoreVarianti.Text = eui_btnColoreBlu.Text

                     Case NetButton.ColorStyleEnum.Gray
                        eui_ddwnStileColoreVarianti.Text = eui_btnColoreGrigio.Text

                     Case NetButton.ColorStyleEnum.Green
                        eui_ddwnStileColoreVarianti.Text = eui_btnColoreVerde.Text

                     Case NetButton.ColorStyleEnum.Pink
                        eui_ddwnStileColoreVarianti.Text = eui_btnColoreViola.Text

                     Case NetButton.ColorStyleEnum.Red
                        eui_ddwnStileColoreVarianti.Text = eui_btnColoreRosso.Text

                     Case NetButton.ColorStyleEnum.Yellow
                        eui_ddwnStileColoreVarianti.Text = eui_btnColoreGiallo.Text

                  End Select
               End If

               ' Colore di sfondo.
               cmdColoreSfondoVarianti.BackColor = Variante(i).ColorBottom
               netBtn_AnteprimaVarianti.ColorBottom = Variante(i).ColorBottom

               ' Colore del testo.
               cmdColoreTestoVarianti.BackColor = Variante(i).ColorText
               netBtn_AnteprimaVarianti.ColorText = Variante(i).ColorText

               ' Altezza del tasto.
               eui_nudAltezzaVarianti.Value = Variante(i).Size.Height

               ' Immagine.
               If File.Exists(Variante(i).Tag.ToString) = True Then
                  Dim bmp As New Bitmap(Variante(i).Tag.ToString)
                  netBtn_AnteprimaVarianti.TextButtonAlign = ContentAlignment.BottomCenter
                  netBtn_AnteprimaVarianti.Image = bmp
               Else
                  If IsNothing(netBtn_AnteprimaVarianti.Image) = False Then
                     netBtn_AnteprimaVarianti.TextButtonAlign = ContentAlignment.MiddleCenter
                     netBtn_AnteprimaVarianti.Image.Dispose()
                     netBtn_AnteprimaVarianti.Image = Nothing
                  End If
               End If

               ' Salva l'indice dell'elemento selezionato.
               varianteSelezionata = i

               Exit Sub
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub cmdColoreSfondoVarianti_Click(sender As Object, e As EventArgs) Handles cmdColoreSfondoVarianti.Click
      ModificaColoreSfondoVarianti()
   End Sub

   Private Sub cmdColoreTestoVarianti_Click(sender As Object, e As EventArgs) Handles cmdColoreTestoVarianti.Click
      ModificaColoreTestoVarianti()
   End Sub

   Private Sub eui_nudAltezzaVarianti_ValueChanged(sender As Object, e As EventArgs) Handles eui_nudAltezzaVarianti.ValueChanged
      Try
         ' Verifica che non vengano inseriti valori non consentiti.
         Select Case eui_nudAltezzaVarianti.Value

            Case Is < eui_nudAltezzaVarianti.Minimum
               eui_nudAltezzaVarianti.Value = eui_nudAltezzaVarianti.Minimum

            Case Is > eui_nudAltezzaVarianti.Maximum
               eui_nudAltezzaVarianti.Value = eui_nudAltezzaVarianti.Maximum

         End Select

         ' Imposta l'anteprima del tasto.
         netBtn_AnteprimaVarianti.Size = New Drawing.Size(netBtn_AnteprimaVarianti.Size.Width, Convert.ToInt32(eui_nudAltezzaVarianti.Value))

         Dim i As Integer
         For i = 1 To NumVarianti
            ' Modifica i dati.
            Variante(i).Size = New Drawing.Size(LARGHEZZA_VARIANTI, Convert.ToInt32(eui_nudAltezzaVarianti.Value))
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdInserisciImgVarianti_Click(sender As Object, e As EventArgs) Handles eui_cmdInserisciImgVarianti.Click
      InserisciImmagineVarianti()
   End Sub

   Private Sub eui_cmdRimuoviImgVarianti_Click(sender As Object, e As EventArgs) Handles eui_cmdRimuoviImgVarianti.Click
      RimuoviImmagineVarianti()
   End Sub


#End Region

#Region "Tasti Funzione Piatti"

   Private Sub CreaTastoFunzionePiatti(ByVal nome As String, ByVal id As Integer, ByVal coloreSfondo As Color, ByVal coloreTesto As Color, ByVal stileTasto As NetButton.ColorStyleEnum)
      Try
         NumFunzioniPiatti += 1

         FunzionePiatto(NumFunzioniPiatti) = New NetButton
         FunzionePiatto(NumFunzioniPiatti).Name = id.ToString
         FunzionePiatto(NumFunzioniPiatti).Tag = nome
         FunzionePiatto(NumFunzioniPiatti).Size = New Size(LARGHEZZA_FUNZIONI, ALTEZZA_FUNZIONI)

         If stileTasto = NetButton.ColorStyleEnum.Custom Then
            FunzionePiatto(NumFunzioniPiatti).ColorStyle = NetButton.ColorStyleEnum.Custom
            FunzionePiatto(NumFunzioniPiatti).ColorBottom = coloreSfondo
            FunzionePiatto(NumFunzioniPiatti).ColorText = coloreTesto
         Else
            FunzionePiatto(NumFunzioniPiatti).ColorStyle = stileTasto
         End If

         FunzionePiatto(NumFunzioniPiatti).TextButton = nome
         FunzionePiatto(NumFunzioniPiatti).Visible = False

         pnlFunzioniPiatti.Controls.Add(FunzionePiatto(NumFunzioniPiatti))

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ReimpostaListaFunzioniPiatti(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim FunzionePiatto(LeggiNumRecord(TAB_POS_IMPOSTAZIONI_PIATTI))
         NumFunzioniPiatti = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("Descrizione").ToString)

            Select Case dr.Item("Descrizione").ToString
               Case TASTO_MODIFICA
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO_ORANGE, COLORE_TESTO_TASTO_BLACK, NetButton.ColorStyleEnum.Custom)

               Case TASTO_PIU_1
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO_ORANGE, COLORE_TESTO_TASTO_BLACK, NetButton.ColorStyleEnum.Custom)

               Case TASTO_MENO_1
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO_ORANGE, COLORE_TESTO_TASTO_BLACK, NetButton.ColorStyleEnum.Custom)

               Case TASTO_CONFERMA
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Green)

               Case TASTO_CONTO
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Green)

               Case TASTO_ESCI
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Red)

               Case TASTO_C
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Red)

               Case TASTO_X
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO_ORANGE, COLORE_TESTO_TASTO_BLACK, NetButton.ColorStyleEnum.Custom)

               Case TASTO_PERCENTUALE
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO_ORANGE, COLORE_TESTO_TASTO_BLACK, NetButton.ColorStyleEnum.Custom)

               Case TASTO_PIU
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO_ORANGE, COLORE_TESTO_TASTO_BLACK, NetButton.ColorStyleEnum.Custom)

               Case TASTO_OK
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Green)

               Case TASTO_1
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_2
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_3
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_4
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_5
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_6
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_7
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_8
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_9
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_0
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_00
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case TASTO_VIRGOLA
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Blue)

               Case Else
                  ' Crea il pulsante Funzione per memorizzare i dati.
                  CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), COLORE_SFONDO_TASTO, COLORE_TESTO_TASTO, NetButton.ColorStyleEnum.Custom)

            End Select
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaListaFunzioniPiatti(ByVal lstBox As ListBox, ByVal campo As String, ByVal tabella As String)
      Try
         ReDim FunzionePiatto(LeggiNumRecord(TAB_POS_IMPOSTAZIONI_PIATTI))
         NumFunzioniPiatti = 0

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " ORDER BY " & campo & " ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lstBox.Items.Clear()

         Do While dr.Read
            ' Descrizione.
            lstBox.Items.Add(dr.Item("Descrizione").ToString)

            ' Crea il pulsante Funzione per memorizzare i dati.
            CreaTastoFunzionePiatti(dr.Item("Descrizione").ToString, Convert.ToInt32(dr.Item("Id")), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreSfondo"))), Color.FromArgb(Convert.ToInt32(dr.Item("ColoreTesto"))), dr.Item("ColoreStile"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Function SalvaImpostazioniFunzioniPiatti() As Boolean
      Try
         Dim AFunzioni As New ImpostazioniPiattiPOS

         Dim i As Integer
         For i = 0 To lstFunzioniPiatti.Items.Count - 1

            Dim y As Integer
            For y = 1 To NumFunzioniPiatti
               ' Modifica le proprietà.
               If lstFunzioniPiatti.Items(i).ToString = FunzionePiatto(y).TextButton Then
                  ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
                  AFunzioni.ModificaDati(FunzionePiatto(y).ColorStyle, FunzionePiatto(y).ColorBottom.ToArgb, FunzionePiatto(y).ColorText.ToArgb, FunzionePiatto(y).TextButton, TAB_POS_IMPOSTAZIONI_PIATTI)
                  Exit For
               End If
            Next
         Next

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub ModificaColoreSfondoFunzionePiatti()
      Try
         With ColorDialog1()
            .Color = cmdColoreSfondoFunzioniPiatti.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreSfondoFunzioniPiatti.BackColor = .Color
               netBtn_AnteprimaFunzioniPiatti.ColorBottom = .Color
               FunzionePiatto(funzionePiattoSelezionata).ColorBottom = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ModificaColoreTestoFunzionePiatti()
      Try
         With ColorDialog1()
            .Color = cmdColoreTestoFunzioniPiatti.BackColor
            .AllowFullOpen = True
            .SolidColorOnly = True

            If .ShowDialog = DialogResult.OK Then
               cmdColoreTestoFunzioniPiatti.BackColor = .Color
               netBtn_AnteprimaFunzioniPiatti.ColorText = .Color
               FunzionePiatto(funzionePiattoSelezionata).ColorText = .Color
            End If
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub SelezionaColoreFunzioniPiatti(ByVal nomeColore As String, ByVal stileColore As NetButton.ColorStyleEnum)
      Try
         eui_ddwnStileColoreFunzioniPiatti.Text = nomeColore

         netBtn_AnteprimaFunzioniPiatti.ColorStyle = stileColore

         FunzionePiatto(funzionePiattoSelezionata).ColorStyle = stileColore

         cmdColoreSfondoFunzioniPiatti.BackColor = FunzionePiatto(funzionePiattoSelezionata).ColorBottom
         cmdColoreTestoFunzioniPiatti.BackColor = FunzionePiatto(funzionePiattoSelezionata).ColorText

         cmdColoreSfondoFunzioniPiatti.Enabled = False
         cmdColoreTestoFunzioniPiatti.Enabled = False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdReimpostaFunzioniPiatti_Click(sender As Object, e As EventArgs) Handles eui_cmdReimpostaFunzioniPiatti.Click
      Try
         ' Rimuove tutti i pulsanti.
         pnlFunzioniPiatti.Controls.Clear()

         ' Rimuove tutti gli elementi dalla lista.
         lstFunzioniPiatti.Items.Clear()

         ' Carica la lista con le impostazioni di default.
         ReimpostaListaFunzioniPiatti(lstFunzioniPiatti, "OrdineTasto", TAB_POS_IMPOSTAZIONI_PIATTI)

         lstFunzioniPiatti.SelectedIndex = 0

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub lstFunzioniPiatti_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lstFunzioniPiatti.SelectedIndexChanged
      Try
         Dim i As Integer
         For i = 1 To NumFunzioniPiatti
            ' Cerca il pulsante corrispondente all'elemento selezionato nella lista.
            ' Se lo trova assegna le proprietà ai controlli.
            If lstFunzioniPiatti.Text = FunzionePiatto(i).TextButton Then
               ' Disattiva i controlli colore.
               cmdColoreSfondoFunzioniPiatti.Enabled = False
               cmdColoreTestoFunzioniPiatti.Enabled = False

               ' Nome Tasto.
               netBtn_AnteprimaFunzioniPiatti.TextButton = FunzionePiatto(i).TextButton

               ' Stile colore.
               If FunzionePiatto(i).ColorBottom.ToArgb = COLORE_SFONDO_TASTO.ToArgb And FunzionePiatto(i).ColorText.ToArgb = COLORE_TESTO_TASTO.ToArgb Then
                  eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColorePredefinito.Text
               Else
                  Select Case FunzionePiatto(i).ColorStyle
                     Case NetButton.ColorStyleEnum.Custom
                        eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColorePersonalizzato.Text

                        ' Attiva i controlli colore.
                        cmdColoreSfondoFunzioniPiatti.Enabled = True
                        cmdColoreTestoFunzioniPiatti.Enabled = True

                     Case NetButton.ColorStyleEnum.Default
                        eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColoreBianco.Text

                     Case NetButton.ColorStyleEnum.Blue
                        eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColoreBlu.Text

                     Case NetButton.ColorStyleEnum.Gray
                        eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColoreGrigio.Text

                     Case NetButton.ColorStyleEnum.Green
                        eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColoreVerde.Text

                     Case NetButton.ColorStyleEnum.Pink
                        eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColoreViola.Text

                     Case NetButton.ColorStyleEnum.Red
                        eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColoreRosso.Text

                     Case NetButton.ColorStyleEnum.Yellow
                        eui_ddwnStileColoreFunzioniPiatti.Text = eui_btnColoreGiallo.Text

                  End Select
               End If

               ' Colore di sfondo.
               cmdColoreSfondoFunzioniPiatti.BackColor = FunzionePiatto(i).ColorBottom
               netBtn_AnteprimaFunzioniPiatti.ColorBottom = FunzionePiatto(i).ColorBottom

               ' Colore del testo.
               cmdColoreTestoFunzioniPiatti.BackColor = FunzionePiatto(i).ColorText
               netBtn_AnteprimaFunzioniPiatti.ColorText = FunzionePiatto(i).ColorText

               ' Salva l'indice dell'elemento selezionato.
               funzionePiattoSelezionata = i

               Exit Sub
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub cmdColoreSfondoFunzioniPiatti_Click(sender As Object, e As EventArgs) Handles cmdColoreSfondoFunzioniPiatti.Click
      ModificaColoreSfondoFunzionePiatti()
   End Sub

   Private Sub cmdColoreTestoFunzioniPiatti_Click(sender As Object, e As EventArgs) Handles cmdColoreTestoFunzioniPiatti.Click
      ModificaColoreTestoFunzionePiatti()
   End Sub

#End Region

End Class
