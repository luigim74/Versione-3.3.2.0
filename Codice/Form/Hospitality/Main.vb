#Region " DATI FILE.VB "
' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2006
' Data ultima modifica: 29/12/2018
' Descrizione:          Form MDI principale.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

Option Strict Off
Option Explicit On

Imports System.IO
Imports System.Data.OleDb
Imports System.Reflection.Assembly
Imports Elegant.Ui
Imports System.Data.SQLite
Imports iTextSharp.text
Imports iTextSharp.text.pdf
Imports Softgroup.NetButton

Friend Class frmMain
   Inherits System.Windows.Forms.Form

#Region "Codice generato dalla finestra di progettazione Windows Form "
   Public Sub New()
      MyBase.New()

      Elegant.Ui.RibbonLicenser.LicenseKey = "5571-8ED3-5F80-7709-F70B-028A-62CC-E3AA"

      Softgroup.NetButton.License.LicenseName = "FD48CF22-7B82-43D2-A389-2DBD1967BCB1"
      Softgroup.NetButton.License.LicenseKey = "IRAXZXJ3E5FHVKAH8RIADDHOE"
      Softgroup.NetButton.License.LicenseUser = "sales@componentsource.com"

      'Chiamata richiesta dalla progettazione Windows Form.
      InitializeComponent()

      AddHandler FinestreMDI.Showing, AddressOf finestreMDI_Showing

   End Sub
   'Il form esegue l'override del metodo Dispose per pulire l'elenco dei componenti.
   Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
      If Disposing Then
         If Not components Is Nothing Then
            components.Dispose()
         End If
      End If
      MyBase.Dispose(Disposing)
   End Sub
   'Richiesto dalla progettazione Windows Form
   Private components As System.ComponentModel.IContainer
   Public ToolTip1 As System.Windows.Forms.ToolTip
   'Public WithEvents tbMain As AxComctlLib.AxToolbar
   Public WithEvents Timer1 As System.Windows.Forms.Timer
   Private openDocumentsPopupMenu As PopupMenu
   'NOTE: la routine seguente è richiesta dalla progettazione Windows Form.
   'Può essere modificata utilizzando la finestra di progettazione Windows Form.
   'Non modificarla mediante l'editor di codice.
   Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
   Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
   Friend WithEvents SaveFileDialog1 As System.Windows.Forms.SaveFileDialog
   ' Friend WithEvents Kube As AxOposPOSPrinter_1_8_Lib.AxOPOSPOSPrinter
   'Friend WithEvents AxOPOSPOSPrinter1 As AxOposPOSPrinter_1_8_Lib.AxOPOSPOSPrinter
   'Private WithEvents AxOPOSPOSPrinter2 As AxOposPOSPrinter_1_8_Lib.AxOPOSPOSPrinter
   Friend WithEvents formFrameSkinner As Elegant.Ui.FormFrameSkinner
   Friend WithEvents eui_File As Elegant.Ui.Ribbon
   Friend WithEvents eui_Gestione As Elegant.Ui.RibbonTabPage
   Friend WithEvents eui_Archivi As Elegant.Ui.RibbonTabPage
   Friend WithEvents eui_Contabilità As Elegant.Ui.RibbonTabPage
   Friend WithEvents eui_Magazzino As Elegant.Ui.RibbonTabPage
   Friend WithEvents eui_Visualizza As Elegant.Ui.RibbonTabPage
   Friend WithEvents eui_Strumenti As Elegant.Ui.RibbonTabPage
   Friend WithEvents eui_Finestra As Elegant.Ui.RibbonTabPage
   Friend WithEvents rtgStrumentiModifica As Elegant.Ui.RibbonContextualTabGroup
   Friend WithEvents eui_GruppoPos As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_cmdGestionePosCassa As Elegant.Ui.Button
   Friend WithEvents eui_cmdGestionePosTavoli As Elegant.Ui.Button
   Friend WithEvents eui_GruppoPrenotazioni As Elegant.Ui.RibbonGroup
   Friend WithEvents RibbonGroup5 As Elegant.Ui.RibbonGroup
   Friend WithEvents RibbonGroup6 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_ContabilitàChiusura As Elegant.Ui.Button
   Friend WithEvents eui_ContabilitàCorrispettivi As Elegant.Ui.Button
   Friend WithEvents eui_ContabilitàPrimaNota As Elegant.Ui.Button
   Friend WithEvents RibbonGroup7 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_ContabilitàElencoDocVendita As Elegant.Ui.Button
   Friend WithEvents RibbonGroup8 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_MagazzinoArticoli As Elegant.Ui.Button
   Friend WithEvents RibbonGroup9 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_MagazzinoMovimenti As Elegant.Ui.Button
   Friend WithEvents RibbonGroup11 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_MagazzinoInventario As Elegant.Ui.Button
   Friend WithEvents RibbonGroup12 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_MagazzinoScorte As Elegant.Ui.Button
   Friend WithEvents RibbonGroup10 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_VisualizzaRegOperazioni As Elegant.Ui.Button
   Friend WithEvents eui_VisualizzaRegErrori As Elegant.Ui.Button
   Friend WithEvents eui_GruppoReparti As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_StrumentiMsgReparti As Elegant.Ui.Button
   Friend WithEvents eui_StrumentiEtichette As Elegant.Ui.Button
   Friend WithEvents eui_StrumentiDispTavoli As Elegant.Ui.Button
   Friend WithEvents eui_StrumentiCap As Elegant.Ui.Button
   Friend WithEvents eui_StrumentiNote As Elegant.Ui.Button
   Friend WithEvents eui_StrumentiCalcolatrice As Elegant.Ui.Button
   Friend WithEvents RibbonGroup14 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_cmdFinestraSovrapponi As Elegant.Ui.Button
   Friend WithEvents eui_cmdFinestraDisponi As Elegant.Ui.Button
   Friend WithEvents eui_cmdFinestraChiudi As Elegant.Ui.Button
   Friend WithEvents eui_cmdFinestraChiudiTutto As Elegant.Ui.Button
   Friend WithEvents NavigationBarItem1 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NavigationBarItem2 As Elegant.Ui.NavigationBarItem
   Friend WithEvents NavigationBarItem3 As Elegant.Ui.NavigationBarItem
   Friend WithEvents eui_BackstageView1 As Elegant.Ui.BackstageView
   Friend WithEvents eui_Guida As Elegant.Ui.BackstageViewPage
   Friend WithEvents Button34 As Elegant.Ui.Button
   Friend WithEvents eui_Opzioni As Elegant.Ui.BackstageViewButton
   Friend WithEvents eui_Esci As Elegant.Ui.BackstageViewButton
   Friend WithEvents ToggleButton2 As Elegant.Ui.ToggleButton
   Friend WithEvents ToggleButton3 As Elegant.Ui.ToggleButton
   Friend WithEvents ToggleButton1 As Elegant.Ui.ToggleButton
   Friend WithEvents RibbonGroup15 As Elegant.Ui.RibbonGroup
   Friend WithEvents RibbonGroup16 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_cmdGestioneOperatori As Elegant.Ui.Button
   Friend WithEvents eui_cmdGestioneGruppiOp As Elegant.Ui.Button
   Friend WithEvents eui_cmdGestioneCambiaOp As Elegant.Ui.Button
   Friend WithEvents RibbonGroup17 As Elegant.Ui.RibbonGroup
   Friend WithEvents DropDown3 As Elegant.Ui.DropDown
   Friend WithEvents RibbonGroup1 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_cmdArchiviImporta As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviBackup As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviPulizia As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviCompatta As Elegant.Ui.Button
   Friend WithEvents PopupMenu1 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdArchiviAnagraficheClienti As Elegant.Ui.Button
   Friend WithEvents DropDown1 As Elegant.Ui.DropDown
   Friend WithEvents PopupMenu3 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdArchiviTabelleTitoli As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviAnagraficheFornitori As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviAnagraficheCamerieri As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviAnagraficheAziende As Elegant.Ui.Button
   Friend WithEvents Separator1 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdArchiviAnagraficheSale As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviAnagraficheTavoli As Elegant.Ui.Button
   Friend WithEvents sepRistorante As Elegant.Ui.Separator
   Friend WithEvents eui_cmdArchiviAnagrafichePiatti As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviAnagraficheCategoriePiatti As Elegant.Ui.Button
   Friend WithEvents sepBar As Elegant.Ui.Separator
   Friend WithEvents eui_cmdArchiviAnagraficheDatiAzienda As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleCategorieCliente As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleAttività As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleNazioni As Elegant.Ui.Button
   Friend WithEvents Separator4 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdArchiviTabelleUM As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleCategorieMerce As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleMagazzini As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleUbicazioni As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleScaffali As Elegant.Ui.Button
   Friend WithEvents sepMagazzino As Elegant.Ui.Separator
   Friend WithEvents eui_cmdArchiviTabelleReparti As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleMsgReparti As Elegant.Ui.Button
   Friend WithEvents sepReparti As Elegant.Ui.Separator
   Friend WithEvents eui_cmdArchiviTabelleCausaliDoc As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabellePagamenti As Elegant.Ui.Button
   Friend WithEvents eui_cmdFinestraAffianca As Elegant.Ui.DropDown
   Friend WithEvents PopupMenu4 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdFinestraAffiancaOrizz As Elegant.Ui.Button
   Friend WithEvents eui_cmdFinestraAffiancaVert As Elegant.Ui.Button
   Friend WithEvents eui_drpFinestraSel As Elegant.Ui.DropDown
   Friend WithEvents PopupMenu2 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_GruppoEtichette As Elegant.Ui.RibbonGroup
   Friend WithEvents RibbonGroup19 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_GruppoTavoli As Elegant.Ui.RibbonGroup
   Friend WithEvents RibbonGroup22 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_GruppoMenu As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_StrumentiMenù As Elegant.Ui.Button
   Friend WithEvents ToggleButton4 As Elegant.Ui.ToggleButton
   Friend WithEvents ToggleButton5 As Elegant.Ui.ToggleButton
   Friend WithEvents ContextMenuExtenderProvider1 As Elegant.Ui.ContextMenuExtenderProvider
   Friend WithEvents PopupMenu5 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_sbrMain As Elegant.Ui.StatusBar
   Friend WithEvents StatusBarNotificationsArea1 As Elegant.Ui.StatusBarNotificationsArea
   Friend WithEvents StatusBarControlsArea1 As Elegant.Ui.StatusBarControlsArea
   Friend WithEvents StatusBarPane1 As Elegant.Ui.StatusBarPane
   Friend WithEvents StatusBarPane3 As Elegant.Ui.StatusBarPane
   Friend WithEvents StatusBarPane4 As Elegant.Ui.StatusBarPane
   Friend WithEvents StatusBarPane5 As Elegant.Ui.StatusBarPane
   Friend WithEvents eui_cmdArchivio As Elegant.Ui.Button
   Friend WithEvents PictureBox1 As Elegant.Ui.PictureBox
   Friend WithEvents eui_cmdAzienda As Elegant.Ui.Button
   Friend WithEvents PictureBox2 As Elegant.Ui.PictureBox
   Friend WithEvents eui_cmdPostazione As Elegant.Ui.Button
   Friend WithEvents PictureBox3 As Elegant.Ui.PictureBox
   Friend WithEvents eui_cmdOperatore As Elegant.Ui.Button
   Friend WithEvents StatusBarPane6 As Elegant.Ui.StatusBarPane
   Friend WithEvents eui_cmdData As Elegant.Ui.Button
   Friend WithEvents BackstageViewSeparator1 As Elegant.Ui.BackstageViewSeparator
   Friend WithEvents NavigationBarItem6 As Elegant.Ui.NavigationBarItem
   Friend WithEvents CheckBox7 As Elegant.Ui.CheckBox
   Friend WithEvents eui_GestioneModuli As Elegant.Ui.BackstageViewPage
   Friend WithEvents StatusBarPane8 As Elegant.Ui.StatusBarPane
   Friend WithEvents eui_Informazioni As Elegant.Ui.Label
   Friend WithEvents lvwGestioneModuli As System.Windows.Forms.ListView
   Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
   Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
   Friend WithEvents eui_Info As Elegant.Ui.BackstageViewPage
   Friend WithEvents PictureBox5 As Elegant.Ui.PictureBox
   Friend WithEvents PictureBox4 As Elegant.Ui.PictureBox
   Friend WithEvents eui_cmdArchiviAnagraficheRisorse As Elegant.Ui.Button
   Friend WithEvents sepRisorse As Elegant.Ui.Separator
   Friend WithEvents Separator8 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdArchiviTabelleTipoRisorse As Elegant.Ui.Button
   Friend WithEvents eui_ddwnGestioneStatistiche As Elegant.Ui.DropDown
   Friend WithEvents PopupMenu6 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdGestioneStatistiche As Elegant.Ui.Button
   Friend WithEvents sepBarRistorante As Elegant.Ui.Separator
   Friend WithEvents eui_cmdGestioneStatisticheRisorse As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviAnagraficheAccServ As Elegant.Ui.Button
   Friend WithEvents cmdAttivaModuli As Elegant.Ui.Button
   Friend WithEvents cmdApriPercorso As Elegant.Ui.Button
   Friend WithEvents cmdCompatta As Elegant.Ui.Button
   Friend WithEvents cmdPulizia As Elegant.Ui.Button
   Friend WithEvents cmdBackup As Elegant.Ui.Button
   Friend WithEvents Label3 As System.Windows.Forms.Label
   Friend WithEvents Label2 As System.Windows.Forms.Label
   Friend WithEvents Label4 As System.Windows.Forms.Label
   Friend WithEvents Label5 As System.Windows.Forms.Label
   Friend WithEvents Label8 As System.Windows.Forms.Label
   Friend WithEvents Label9 As System.Windows.Forms.Label
   Friend WithEvents Label6 As System.Windows.Forms.Label
   Friend WithEvents Label7 As System.Windows.Forms.Label
   Friend WithEvents PictureBox9 As System.Windows.Forms.PictureBox
   Friend WithEvents PictureBox8 As System.Windows.Forms.PictureBox
   Friend WithEvents PictureBox7 As System.Windows.Forms.PictureBox
   Friend WithEvents PictureBox6 As System.Windows.Forms.PictureBox
   Friend WithEvents picProg As System.Windows.Forms.PictureBox
   Friend WithEvents PictureBox11 As System.Windows.Forms.PictureBox
   Friend WithEvents Label10 As System.Windows.Forms.Label
   Friend WithEvents lblDataUltimaScrittura As System.Windows.Forms.Label
   Friend WithEvents lblDataUltimoAccesso As System.Windows.Forms.Label
   Friend WithEvents lblDataCreazione As System.Windows.Forms.Label
   Friend WithEvents lblAttributi As System.Windows.Forms.Label
   Friend WithEvents lblDimensioniFile As System.Windows.Forms.Label
   Friend WithEvents Label11 As System.Windows.Forms.Label
   Friend WithEvents Label12 As System.Windows.Forms.Label
   Friend WithEvents Label13 As System.Windows.Forms.Label
   Friend WithEvents Label14 As System.Windows.Forms.Label
   Friend WithEvents Label15 As System.Windows.Forms.Label
   Friend WithEvents Label18 As System.Windows.Forms.Label
   Friend WithEvents Label17 As System.Windows.Forms.Label
   Friend WithEvents Label16 As System.Windows.Forms.Label
   Friend WithEvents txtPercorso As Elegant.Ui.TextBox
   Friend WithEvents lblPercorso As System.Windows.Forms.Label
   Friend WithEvents Label19 As System.Windows.Forms.Label
   Friend WithEvents Label1 As System.Windows.Forms.Label
   Friend WithEvents Button6 As Elegant.Ui.Button
   Friend WithEvents Button5 As Elegant.Ui.Button
   Friend WithEvents Button3 As Elegant.Ui.Button
   Friend WithEvents Button2 As Elegant.Ui.Button
   Friend WithEvents BackstageViewPage1 As Elegant.Ui.BackstageViewPage
   Friend WithEvents PictureBox12 As System.Windows.Forms.PictureBox
   Friend WithEvents PictureBox10 As System.Windows.Forms.PictureBox
   Friend WithEvents Label21 As System.Windows.Forms.Label
   Friend WithEvents Label20 As System.Windows.Forms.Label
   Friend WithEvents eui_cmdAggiornamenti As Elegant.Ui.Button
   Friend WithEvents eui_cmdMobile As Elegant.Ui.Button
   Friend WithEvents eui_cmdOpzioni As Elegant.Ui.Button
   Friend WithEvents eui_cmdContattaci As Elegant.Ui.Button
   Friend WithEvents eui_cmdGuida As Elegant.Ui.Button
   Friend WithEvents PictureBox13 As System.Windows.Forms.PictureBox
   Friend WithEvents PictureBox15 As System.Windows.Forms.PictureBox
   Friend WithEvents PictureBox14 As System.Windows.Forms.PictureBox
   Friend WithEvents Label23 As System.Windows.Forms.Label
   Friend WithEvents PictureBox16 As System.Windows.Forms.PictureBox
   Friend WithEvents Label22 As System.Windows.Forms.Label
   Friend WithEvents eui_txtDettagliProdotto As Elegant.Ui.TextBox
   Friend WithEvents eui_lstProdottiAttivati As Elegant.Ui.ListBox
   Friend WithEvents lnkInfoSu As System.Windows.Forms.LinkLabel
   Friend WithEvents lblVersione As System.Windows.Forms.Label
   Friend WithEvents Label24 As System.Windows.Forms.Label
   Friend WithEvents PictureBox17 As System.Windows.Forms.PictureBox
   Friend WithEvents Label26 As System.Windows.Forms.Label
   Friend WithEvents lblInfo As System.Windows.Forms.Label
   Friend WithEvents lnkLicenza As System.Windows.Forms.LinkLabel
   Friend WithEvents lblNumSerie As System.Windows.Forms.Label
   Friend WithEvents lnkSupporto As System.Windows.Forms.LinkLabel
   Friend WithEvents lblDemo As System.Windows.Forms.Label
   Friend WithEvents lblGiorniProva As System.Windows.Forms.Label
   Friend WithEvents PopupMenu7 As Elegant.Ui.PopupMenu
   Friend WithEvents PopupMenu8 As Elegant.Ui.PopupMenu
   Friend WithEvents PopupMenu9 As Elegant.Ui.PopupMenu
   Friend WithEvents FinestreMDI As Elegant.Ui.PopupMenu
   Friend WithEvents Timer2 As System.Windows.Forms.Timer
   Friend WithEvents eui_StrumentiTastiera As Elegant.Ui.Button
   Friend WithEvents rtgGestionaleAmica As Elegant.Ui.RibbonContextualTabGroup
   Friend WithEvents eui_StrumentiModifica As Elegant.Ui.RibbonTabPage
   Friend WithEvents eui_Amica_ImportaEsporta As Elegant.Ui.RibbonTabPage
   Friend WithEvents RibbonGroup2 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_cmdAmicaImporta As Elegant.Ui.Button
   Friend WithEvents eui_cmdAmicaEsporta As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviAnagraficheCamere As Elegant.Ui.Button
   Friend WithEvents sepCamere As Elegant.Ui.Separator
   Friend WithEvents sepListini As Elegant.Ui.Separator
   Friend WithEvents eui_cmdArchiviTabelleListini As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleTipologieCamere As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleUbicazioniCamere As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabellePosizioniCamere As Elegant.Ui.Button
   Friend WithEvents rtgPlanningCamere As Elegant.Ui.RibbonContextualTabGroup
   Friend WithEvents eui_PCamere_Prenotazioni As Elegant.Ui.RibbonTabPage
   Friend WithEvents RibbonGroup13 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_PCamere_PrenNuova As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_PrenElimina As Elegant.Ui.Button
   Friend WithEvents Separator5 As Elegant.Ui.Separator
   Friend WithEvents eui_PCamere_PrenElencoCamere As Elegant.Ui.Button
   Friend WithEvents RibbonGroup3 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_PCamere_PrenListini As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_PrenStagioni As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_PrenCamere As Elegant.Ui.Button
   Friend WithEvents RibbonGroup4 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_PCamere_PrenIstat As Elegant.Ui.Button
   Friend WithEvents Separator6 As Elegant.Ui.Separator
   Friend WithEvents eui_PCamere_PrenClienti As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_Visualizza As Elegant.Ui.RibbonTabPage
   Friend WithEvents RibbonGroup23 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_PCamere_VisIndieto As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_VisAvanti As Elegant.Ui.Button
   Friend WithEvents Separator12 As Elegant.Ui.Separator
   Friend WithEvents eui_PCamere_VisSu As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_VisGiù As Elegant.Ui.Button
   Friend WithEvents RibbonGroup24 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_PCamere_VisAnnoIndietro As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_VisAnnoAvanti As Elegant.Ui.Button
   Friend WithEvents Separator13 As Elegant.Ui.Separator
   Friend WithEvents eui_PCamere_VisMeseIndietro As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_VisMeseAvanti As Elegant.Ui.Button
   Friend WithEvents Separator14 As Elegant.Ui.Separator
   Friend WithEvents eui_PCamere_VisGiorniMeno As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_VisGiorniPiù As Elegant.Ui.Button
   Friend WithEvents RibbonTabPage3 As Elegant.Ui.RibbonTabPage
   Friend WithEvents eui_ddwnGestionePlanningRisorse As Elegant.Ui.DropDown
   Friend WithEvents PopupMenu10 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdGestionePlanningCamere As Elegant.Ui.Button
   Friend WithEvents sepPlannigCamere As Elegant.Ui.Separator
   Friend WithEvents PopupMenu11 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdGestionePrenCamere As Elegant.Ui.Button
   Friend WithEvents sepPrenCamere As Elegant.Ui.Separator
   Friend WithEvents eui_cmdGestionePrenTavoli As Elegant.Ui.Button
   Friend WithEvents eui_cmdGestionePrenSale As Elegant.Ui.Button
   Friend WithEvents sepPrenRisorse As Elegant.Ui.Separator
   Friend WithEvents Separator15 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdArchiviTabelleStagioni As Elegant.Ui.Button
   Friend WithEvents RibbonTabPage2 As Elegant.Ui.RibbonTabPage
   Friend WithEvents RibbonGroup18 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_Strumenti_Stampa_Anteprima As Elegant.Ui.Button
   Friend WithEvents eui_Strumenti_Stampa_Elenco As Elegant.Ui.Button
   Friend WithEvents Separator17 As Elegant.Ui.Separator
   Friend WithEvents RibbonGroup21 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_Strumenti_Nuovo As Elegant.Ui.Button
   Friend WithEvents eui_Strumenti_Modifica As Elegant.Ui.Button
   Friend WithEvents eui_Strumenti_Elimina As Elegant.Ui.Button
   Friend WithEvents Separator16 As Elegant.Ui.Separator
   Friend WithEvents eui_Strumenti_Aggiorna As Elegant.Ui.Button
   Friend WithEvents eui_Strumenti_Duplica As Elegant.Ui.Button
   Friend WithEvents eui_StrumentiPeriodo As Elegant.Ui.RibbonTabPage
   Friend WithEvents RibbonGroup26 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_Strumenti_Periodo_Tutte As Elegant.Ui.ToggleButton
   Friend WithEvents Separator20 As Elegant.Ui.Separator
   Friend WithEvents eui_Strumenti_Periodo_Mese As Elegant.Ui.ToggleButton
   Friend WithEvents eui_Strumenti_Periodo_DalAl As Elegant.Ui.ToggleButton
   Friend WithEvents eui_rib_Visualizza As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_Strumenti_Periodo_Arrivo As Elegant.Ui.ToggleButton
   Friend WithEvents eui_Strumenti_Periodo_Partenza As Elegant.Ui.ToggleButton
   Friend WithEvents eui_StrumentiDocumenti As Elegant.Ui.RibbonTabPage
   Friend WithEvents RibbonGroup29 As Elegant.Ui.RibbonGroup
   Friend WithEvents eui_Strumenti_Documenti_Fattura As Elegant.Ui.Button
   Friend WithEvents eui_Strumenti_Documenti_Ricevuta As Elegant.Ui.Button
   Friend WithEvents eui_Strumenti_Visualizza_Presenze As Elegant.Ui.Button
   Friend WithEvents Separator19 As Elegant.Ui.Separator
   Friend WithEvents eui_PCamere_PrenAggiorna As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleStatoPren As Elegant.Ui.Button
   Friend WithEvents sepStatoPren As Elegant.Ui.Separator
   Friend WithEvents eui_Strumenti_Documenti_Sep1 As Elegant.Ui.Separator
   Friend WithEvents eui_Strumenti_Documenti_Schedina As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_PrenModifica As Elegant.Ui.Button
   Friend WithEvents eui_PCamere_PrenSchedina As Elegant.Ui.Button
   Friend WithEvents eui_cmdArchiviTabelleDocIdentità As Elegant.Ui.Button
   Friend WithEvents Separator24 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdArchiviAnagraficheUtilizzoRisorse As Elegant.Ui.Button
   Friend WithEvents PictureBox19 As Elegant.Ui.PictureBox
   Friend WithEvents Separator2 As Elegant.Ui.Separator
   Friend WithEvents eui_PCamere_VisOggi As Elegant.Ui.Button
   Friend WithEvents eui_Strumenti_Periodo_Sep1 As Elegant.Ui.Separator
   Friend WithEvents eui_Strumenti_Periodo_Anno As Elegant.Ui.ToggleButton
   Friend WithEvents eui_cmdGestionePlanningRisorseSport As Elegant.Ui.SplitButton
   Friend WithEvents PopupMenu12 As Elegant.Ui.PopupMenu
   Friend WithEvents eui_cmdGestionePlanningRisorseSport1 As Elegant.Ui.Button
   Friend WithEvents eui_cmdGestionePlanningRisorseSport2 As Elegant.Ui.Button
   Friend WithEvents eui_cmdGestionePlanningRisorseSport3 As Elegant.Ui.Button
   Friend WithEvents eui_cmdGestionePlanningRisorseSport4 As Elegant.Ui.Button
   Friend WithEvents Separator7 As Elegant.Ui.Separator
   Friend WithEvents eui_cmdGestionePlanningRisorseApriTutti As Elegant.Ui.Button
   Friend WithEvents Separator9 As Elegant.Ui.Separator
   Friend WithEvents eui_StrumentiSospesiBuoni As RibbonTabPage
   Friend WithEvents RibbonTabPage1 As RibbonTabPage
   Friend WithEvents RibbonTabPage4 As RibbonTabPage
   Friend WithEvents RibbonGroup20 As RibbonGroup
   Friend WithEvents Separator10 As Separator
   Friend WithEvents eui_Strumenti_Sospesi_Incassa As Button
   Friend WithEvents eui_Strumenti_Sospesi_Passa As Button
   Friend WithEvents eui_Strumenti_Sospesi_Annulla As Button
   Friend WithEvents RibbonGroup25 As RibbonGroup
   Friend WithEvents eui_Strumenti_Buoni_Pasto As Button
   Friend WithEvents eui_Strumenti_Annulla As Button
   Friend WithEvents eui_Strumenti_Sospesi_Filtra As ToggleButton
   Friend WithEvents StatusBarPane2 As StatusBarPane
   Friend WithEvents eui_picAggiornamenti As PictureBox
   Friend WithEvents eui_cmdNuovoAgg As Button
   Friend WithEvents PictureBox18 As Windows.Forms.PictureBox
   Friend WithEvents lnkMsWeb As LinkLabel
   Friend WithEvents PictureBox20 As Windows.Forms.PictureBox
   Friend WithEvents lnkVideo As LinkLabel
   Friend WithEvents StatusBarPane7 As StatusBarPane
   Friend WithEvents PictureBox21 As PictureBox
   Friend WithEvents eui_cmdLicenza As Button
   Friend WithEvents eui_Strumenti_Documenti_Proforma As Button
   Friend WithEvents RibbonGroup27 As RibbonGroup
   Friend WithEvents eui_Strumenti_Documenti_Esporta As DropDown
   Friend WithEvents PopupMenu13 As PopupMenu
   Friend WithEvents eui_cmdEsportaPdf As Button
   Friend WithEvents Separator3 As Separator
   Friend WithEvents eui_cmdEsportaHtml As Button
   Friend WithEvents eui_Strumenti_Documenti_Invia As DropDown
   Friend WithEvents PopupMenu14 As PopupMenu
   Friend WithEvents eui_Strumenti_Documenti_Invia_Riepilogo As Button
   Friend WithEvents Separator11 As Separator
   Friend WithEvents eui_Strumenti_Documenti_Invia_Acconto As Button
   Friend WithEvents eui_Strumenti_Documenti_Invia_Caparra As Button
   Friend WithEvents RibbonGroup28 As RibbonGroup
   Friend WithEvents eui_StrumentiEmail As Button
   Friend WithEvents eui_cmdGestioneSchedine As Button
   Friend WithEvents RibbonGroup30 As RibbonGroup
   Friend WithEvents eui_cmdGestioneOpzioni As Button
   Friend WithEvents eui_cmdArchiviTabelleGruppi As Button
   Friend WithEvents eui_cmdArchiviTabelleAgenzie As Button
   Friend WithEvents eui_cmdArchiviTabelleCanali As Button
   Friend WithEvents eui_cmdGestioneClienti As Button
   Friend WithEvents eui_ddwnGestioneQuadroGiornaliero As DropDown
   Friend WithEvents eui_ddwnGestionePrenotazioni As DropDown
   Friend WithEvents eui_Strumenti_Documenti_Sep As Separator
   Friend WithEvents eui_Strumenti_Periodo_Sep2 As Separator
   Friend WithEvents eui_Strumenti_Periodo_NonAssegnate As ToggleButton
   Friend WithEvents eui_Strumenti_Periodo_Terminate As ToggleButton
   Friend WithEvents eui_PCamere_PrenAnnulla As Button
   Friend WithEvents eui_Strumenti_Documenti_Stampa_Schedina As Button
   Friend WithEvents sepStatistiche As Separator
   Friend WithEvents Separator22 As Separator
   Friend WithEvents Separator21 As Separator
   Friend WithEvents eui_cmdEsportaTxt As SplitButton
   Friend WithEvents PopupMenu15 As PopupMenu
   Friend WithEvents eui_cmdEsportaTxtSelezione As Button
   Friend WithEvents eui_cmdEsportaTxtTutte As Button
   Friend WithEvents eui_cmdArchiviTabelleComuni As Button
   Friend WithEvents eui_cmdArchiviTabelleTipoAlloggiati As Button
   Friend WithEvents eui_Strumenti_Documenti_IstatC59 As Button
   Friend WithEvents eui_cmdGestioneStatisticheHotel As Button
   Friend WithEvents sepHotel As Separator
   Friend WithEvents eui_Strumenti_Esporta As DropDown
   Friend WithEvents PopupMenu16 As PopupMenu
   Friend WithEvents eui_Strumenti_Esporta_Anteprima As Button
   Friend WithEvents eui_Strumenti_Esporta_SepXML As Separator
   Friend WithEvents eui_Strumenti_Esporta_XML As Button
   Friend WithEvents eui_Strumenti_Esporta_EML As Button
   Friend WithEvents eui_ContabilitàElencoDocAcquisto As Button
   Friend WithEvents RibbonTabPage5 As RibbonTabPage
   Friend WithEvents eui_cmdGestionePrenRisorse As Elegant.Ui.Button

   <System.Diagnostics.DebuggerStepThrough()>
   Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim themeSelector As Elegant.Ui.ThemeSelector
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
      Dim ListViewGroup11 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Hospitality Solution", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup12 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Bar", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup13 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Ristorante", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup14 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Hotel", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup15 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Campeggio", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup16 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Centro balneare", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup17 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Centro benessere", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup18 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Centro sportivo", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup19 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Vendita al dettaglio", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewGroup20 As System.Windows.Forms.ListViewGroup = New System.Windows.Forms.ListViewGroup("Moduli aggiuntivi", System.Windows.Forms.HorizontalAlignment.Left)
      Dim ListViewItem19 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "HOSPITALITY SOLUTION SUITE", System.Drawing.Color.MidnightBlue, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Software per strutture turistiche.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, 15)
      Dim ListViewItem20 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "BAR SOLUTION", System.Drawing.Color.Green, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Software per bar e gelaterie.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, 17)
      Dim ListViewItem21 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "CHEF SOLUTION", System.Drawing.Color.DarkGreen, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Software per strutture ristorative.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, 16)
      Dim ListViewItem22 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "PALMARI", System.Drawing.Color.DarkGreen, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Modulo per la gestione dei palmari.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, -1)
      Dim ListViewItem23 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "HOTEL SOLUTION", System.Drawing.Color.Brown, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Software per strutture ricettive.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, 21)
      Dim ListViewItem24 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "CAMPING SOLUTION", System.Drawing.Color.Crimson, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Software per campeggi.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, 22)
      Dim ListViewItem25 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "BEACH SOLUTION", System.Drawing.Color.Crimson, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Software per centri balneari e piscine.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, 19)
      Dim ListViewItem26 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "BEAUTY SOLUTION", System.Drawing.Color.Purple, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Software per centri benessere.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, 18)
      Dim ListViewItem27 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "SPORTING CLUB SOLUTION", System.Drawing.Color.DarkCyan, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Software per centri sportivi.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, 20)
      Dim ListViewItem28 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "RETAIL SOLUTION", System.Drawing.Color.DarkOrange, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Software per la vendita al dettaglio.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, 23)
      Dim ListViewItem29 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "TAGLIE E COLORI", System.Drawing.Color.DarkOrange, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Modulo per la gestione delle Taglie e Colori.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, -1)
      Dim ListViewItem30 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "MAGAZZINO", System.Drawing.Color.MidnightBlue, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Modulo per la gestione del magazzino.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, -1)
      Dim ListViewItem31 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "ETICHETTE E CODICI A BARRE", System.Drawing.Color.MidnightBlue, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Modulo per la gestione di etichette e codici a barre.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, -1)
      Dim ListViewItem32 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "PRENOTAZIONI ON-LINE", System.Drawing.Color.DarkGreen, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Modulo per le prenotazioni da Internet.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, -1)
      Dim ListViewItem33 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "PEN DRIVE PORTABLE", System.Drawing.Color.MidnightBlue, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Modulo per l'installazione del software su memoria esterna.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, -1)
      Dim ListViewItem34 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "PEN DRIVE RECOVERY", System.Drawing.Color.MidnightBlue, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Modulo per il salvataggio e recupero automatico dei dati del software.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, -1)
      Dim ListViewItem35 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "REGISTRATORI DI CASSA", System.Drawing.Color.MidnightBlue, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Modulo per il collegamento ai registratori di cassa e stampanti fiscali.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!)), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!))}, -1)
      Dim ListViewItem36 As System.Windows.Forms.ListViewItem = New System.Windows.Forms.ListViewItem(New System.Windows.Forms.ListViewItem.ListViewSubItem() {New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "FATTURAZIONE ELETTRONICA", System.Drawing.Color.MidnightBlue, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "Modulo per la Fatturazione Elettronica.", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))), New System.Windows.Forms.ListViewItem.ListViewSubItem(Nothing, "NON ATTIVO", System.Drawing.Color.Gray, System.Drawing.SystemColors.Window, New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte)))}, -1)
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.picProg = New System.Windows.Forms.PictureBox()
      Me.txtPercorso = New Elegant.Ui.TextBox()
      Me.lvwGestioneModuli = New System.Windows.Forms.ListView()
      Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
      Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
      Me.eui_cmdGestionePosCassa = New Elegant.Ui.Button()
      Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
      Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
      Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
      Me.formFrameSkinner = New Elegant.Ui.FormFrameSkinner()
      Me.eui_File = New Elegant.Ui.Ribbon()
      Me.eui_BackstageView1 = New Elegant.Ui.BackstageView()
      Me.eui_Guida = New Elegant.Ui.BackstageViewPage()
      Me.BackstageViewPage1 = New Elegant.Ui.BackstageViewPage()
      Me.PictureBox20 = New System.Windows.Forms.PictureBox()
      Me.lnkVideo = New System.Windows.Forms.LinkLabel()
      Me.lblGiorniProva = New System.Windows.Forms.Label()
      Me.lblDemo = New System.Windows.Forms.Label()
      Me.PictureBox18 = New System.Windows.Forms.PictureBox()
      Me.lnkMsWeb = New System.Windows.Forms.LinkLabel()
      Me.lnkLicenza = New System.Windows.Forms.LinkLabel()
      Me.lblNumSerie = New System.Windows.Forms.Label()
      Me.lnkSupporto = New System.Windows.Forms.LinkLabel()
      Me.lblInfo = New System.Windows.Forms.Label()
      Me.lnkInfoSu = New System.Windows.Forms.LinkLabel()
      Me.lblVersione = New System.Windows.Forms.Label()
      Me.Label24 = New System.Windows.Forms.Label()
      Me.PictureBox17 = New System.Windows.Forms.PictureBox()
      Me.Label26 = New System.Windows.Forms.Label()
      Me.eui_txtDettagliProdotto = New Elegant.Ui.TextBox()
      Me.eui_lstProdottiAttivati = New Elegant.Ui.ListBox()
      Me.Label23 = New System.Windows.Forms.Label()
      Me.PictureBox16 = New System.Windows.Forms.PictureBox()
      Me.Label22 = New System.Windows.Forms.Label()
      Me.PictureBox15 = New System.Windows.Forms.PictureBox()
      Me.PictureBox14 = New System.Windows.Forms.PictureBox()
      Me.PictureBox13 = New System.Windows.Forms.PictureBox()
      Me.PictureBox12 = New System.Windows.Forms.PictureBox()
      Me.PictureBox10 = New System.Windows.Forms.PictureBox()
      Me.Label21 = New System.Windows.Forms.Label()
      Me.Label20 = New System.Windows.Forms.Label()
      Me.eui_cmdAggiornamenti = New Elegant.Ui.Button()
      Me.eui_cmdMobile = New Elegant.Ui.Button()
      Me.eui_cmdOpzioni = New Elegant.Ui.Button()
      Me.eui_cmdContattaci = New Elegant.Ui.Button()
      Me.eui_cmdGuida = New Elegant.Ui.Button()
      Me.Button6 = New Elegant.Ui.Button()
      Me.Button5 = New Elegant.Ui.Button()
      Me.Button3 = New Elegant.Ui.Button()
      Me.Button2 = New Elegant.Ui.Button()
      Me.Button34 = New Elegant.Ui.Button()
      Me.eui_Info = New Elegant.Ui.BackstageViewPage()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.lblPercorso = New System.Windows.Forms.Label()
      Me.Label19 = New System.Windows.Forms.Label()
      Me.Label18 = New System.Windows.Forms.Label()
      Me.Label17 = New System.Windows.Forms.Label()
      Me.Label16 = New System.Windows.Forms.Label()
      Me.Label11 = New System.Windows.Forms.Label()
      Me.Label12 = New System.Windows.Forms.Label()
      Me.Label13 = New System.Windows.Forms.Label()
      Me.Label14 = New System.Windows.Forms.Label()
      Me.Label15 = New System.Windows.Forms.Label()
      Me.lblDimensioniFile = New System.Windows.Forms.Label()
      Me.lblDataUltimaScrittura = New System.Windows.Forms.Label()
      Me.lblDataUltimoAccesso = New System.Windows.Forms.Label()
      Me.lblDataCreazione = New System.Windows.Forms.Label()
      Me.lblAttributi = New System.Windows.Forms.Label()
      Me.Label10 = New System.Windows.Forms.Label()
      Me.PictureBox11 = New System.Windows.Forms.PictureBox()
      Me.PictureBox9 = New System.Windows.Forms.PictureBox()
      Me.PictureBox8 = New System.Windows.Forms.PictureBox()
      Me.PictureBox7 = New System.Windows.Forms.PictureBox()
      Me.PictureBox6 = New System.Windows.Forms.PictureBox()
      Me.Label8 = New System.Windows.Forms.Label()
      Me.Label9 = New System.Windows.Forms.Label()
      Me.Label6 = New System.Windows.Forms.Label()
      Me.Label7 = New System.Windows.Forms.Label()
      Me.Label4 = New System.Windows.Forms.Label()
      Me.Label5 = New System.Windows.Forms.Label()
      Me.cmdCompatta = New Elegant.Ui.Button()
      Me.cmdPulizia = New Elegant.Ui.Button()
      Me.cmdBackup = New Elegant.Ui.Button()
      Me.Label3 = New System.Windows.Forms.Label()
      Me.Label2 = New System.Windows.Forms.Label()
      Me.cmdAttivaModuli = New Elegant.Ui.Button()
      Me.cmdApriPercorso = New Elegant.Ui.Button()
      Me.eui_GestioneModuli = New Elegant.Ui.BackstageViewPage()
      Me.BackstageViewSeparator1 = New Elegant.Ui.BackstageViewSeparator()
      Me.eui_Opzioni = New Elegant.Ui.BackstageViewButton()
      Me.eui_Esci = New Elegant.Ui.BackstageViewButton()
      Me.rtgStrumentiModifica = New Elegant.Ui.RibbonContextualTabGroup(Me.components)
      Me.eui_StrumentiModifica = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup21 = New Elegant.Ui.RibbonGroup()
      Me.eui_Strumenti_Nuovo = New Elegant.Ui.Button()
      Me.eui_Strumenti_Modifica = New Elegant.Ui.Button()
      Me.eui_Strumenti_Duplica = New Elegant.Ui.Button()
      Me.eui_Strumenti_Elimina = New Elegant.Ui.Button()
      Me.eui_Strumenti_Annulla = New Elegant.Ui.Button()
      Me.Separator17 = New Elegant.Ui.Separator()
      Me.eui_Strumenti_Aggiorna = New Elegant.Ui.Button()
      Me.Separator16 = New Elegant.Ui.Separator()
      Me.eui_Strumenti_Esporta = New Elegant.Ui.DropDown()
      Me.PopupMenu16 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_Strumenti_Esporta_Anteprima = New Elegant.Ui.Button()
      Me.eui_Strumenti_Esporta_SepXML = New Elegant.Ui.Separator()
      Me.eui_Strumenti_Esporta_XML = New Elegant.Ui.Button()
      Me.eui_Strumenti_Esporta_EML = New Elegant.Ui.Button()
      Me.RibbonGroup18 = New Elegant.Ui.RibbonGroup()
      Me.eui_Strumenti_Stampa_Anteprima = New Elegant.Ui.Button()
      Me.eui_Strumenti_Stampa_Elenco = New Elegant.Ui.Button()
      Me.eui_StrumentiPeriodo = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup26 = New Elegant.Ui.RibbonGroup()
      Me.eui_Strumenti_Periodo_Tutte = New Elegant.Ui.ToggleButton()
      Me.Separator20 = New Elegant.Ui.Separator()
      Me.eui_Strumenti_Periodo_Anno = New Elegant.Ui.ToggleButton()
      Me.eui_Strumenti_Periodo_Mese = New Elegant.Ui.ToggleButton()
      Me.eui_Strumenti_Periodo_DalAl = New Elegant.Ui.ToggleButton()
      Me.eui_Strumenti_Periodo_Sep1 = New Elegant.Ui.Separator()
      Me.eui_Strumenti_Periodo_Arrivo = New Elegant.Ui.ToggleButton()
      Me.eui_Strumenti_Periodo_Partenza = New Elegant.Ui.ToggleButton()
      Me.eui_Strumenti_Periodo_Sep2 = New Elegant.Ui.Separator()
      Me.eui_Strumenti_Periodo_NonAssegnate = New Elegant.Ui.ToggleButton()
      Me.eui_Strumenti_Periodo_Terminate = New Elegant.Ui.ToggleButton()
      Me.eui_rib_Visualizza = New Elegant.Ui.RibbonGroup()
      Me.eui_Strumenti_Visualizza_Presenze = New Elegant.Ui.Button()
      Me.eui_StrumentiDocumenti = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup29 = New Elegant.Ui.RibbonGroup()
      Me.eui_Strumenti_Documenti_Proforma = New Elegant.Ui.Button()
      Me.eui_Strumenti_Documenti_Sep = New Elegant.Ui.Separator()
      Me.eui_Strumenti_Documenti_Ricevuta = New Elegant.Ui.Button()
      Me.eui_Strumenti_Documenti_Fattura = New Elegant.Ui.Button()
      Me.eui_Strumenti_Documenti_Stampa_Schedina = New Elegant.Ui.Button()
      Me.RibbonGroup27 = New Elegant.Ui.RibbonGroup()
      Me.eui_Strumenti_Documenti_IstatC59 = New Elegant.Ui.Button()
      Me.eui_Strumenti_Documenti_Schedina = New Elegant.Ui.Button()
      Me.eui_Strumenti_Documenti_Sep1 = New Elegant.Ui.Separator()
      Me.eui_Strumenti_Documenti_Invia = New Elegant.Ui.DropDown()
      Me.PopupMenu14 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_Strumenti_Documenti_Invia_Riepilogo = New Elegant.Ui.Button()
      Me.Separator11 = New Elegant.Ui.Separator()
      Me.eui_Strumenti_Documenti_Invia_Acconto = New Elegant.Ui.Button()
      Me.eui_Strumenti_Documenti_Invia_Caparra = New Elegant.Ui.Button()
      Me.eui_Strumenti_Documenti_Esporta = New Elegant.Ui.DropDown()
      Me.PopupMenu13 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdEsportaPdf = New Elegant.Ui.Button()
      Me.Separator3 = New Elegant.Ui.Separator()
      Me.eui_cmdEsportaHtml = New Elegant.Ui.Button()
      Me.eui_cmdEsportaTxt = New Elegant.Ui.SplitButton()
      Me.PopupMenu15 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdEsportaTxtSelezione = New Elegant.Ui.Button()
      Me.eui_cmdEsportaTxtTutte = New Elegant.Ui.Button()
      Me.eui_StrumentiSospesiBuoni = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup20 = New Elegant.Ui.RibbonGroup()
      Me.eui_Strumenti_Sospesi_Filtra = New Elegant.Ui.ToggleButton()
      Me.Separator10 = New Elegant.Ui.Separator()
      Me.eui_Strumenti_Sospesi_Incassa = New Elegant.Ui.Button()
      Me.eui_Strumenti_Sospesi_Annulla = New Elegant.Ui.Button()
      Me.eui_Strumenti_Sospesi_Passa = New Elegant.Ui.Button()
      Me.RibbonGroup25 = New Elegant.Ui.RibbonGroup()
      Me.eui_Strumenti_Buoni_Pasto = New Elegant.Ui.Button()
      Me.rtgGestionaleAmica = New Elegant.Ui.RibbonContextualTabGroup(Me.components)
      Me.eui_Amica_ImportaEsporta = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup2 = New Elegant.Ui.RibbonGroup()
      Me.eui_cmdAmicaImporta = New Elegant.Ui.Button()
      Me.eui_cmdAmicaEsporta = New Elegant.Ui.Button()
      Me.rtgPlanningCamere = New Elegant.Ui.RibbonContextualTabGroup(Me.components)
      Me.eui_PCamere_Prenotazioni = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup13 = New Elegant.Ui.RibbonGroup()
      Me.eui_PCamere_PrenNuova = New Elegant.Ui.Button()
      Me.eui_PCamere_PrenModifica = New Elegant.Ui.Button()
      Me.eui_PCamere_PrenElimina = New Elegant.Ui.Button()
      Me.eui_PCamere_PrenAnnulla = New Elegant.Ui.Button()
      Me.Separator19 = New Elegant.Ui.Separator()
      Me.eui_PCamere_PrenAggiorna = New Elegant.Ui.Button()
      Me.Separator5 = New Elegant.Ui.Separator()
      Me.eui_PCamere_PrenElencoCamere = New Elegant.Ui.Button()
      Me.RibbonGroup3 = New Elegant.Ui.RibbonGroup()
      Me.eui_PCamere_PrenListini = New Elegant.Ui.Button()
      Me.eui_PCamere_PrenStagioni = New Elegant.Ui.Button()
      Me.Separator6 = New Elegant.Ui.Separator()
      Me.eui_PCamere_PrenCamere = New Elegant.Ui.Button()
      Me.eui_PCamere_PrenClienti = New Elegant.Ui.Button()
      Me.RibbonGroup4 = New Elegant.Ui.RibbonGroup()
      Me.eui_PCamere_PrenIstat = New Elegant.Ui.Button()
      Me.eui_PCamere_PrenSchedina = New Elegant.Ui.Button()
      Me.eui_PCamere_Visualizza = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup23 = New Elegant.Ui.RibbonGroup()
      Me.eui_PCamere_VisIndieto = New Elegant.Ui.Button()
      Me.eui_PCamere_VisAvanti = New Elegant.Ui.Button()
      Me.Separator12 = New Elegant.Ui.Separator()
      Me.eui_PCamere_VisSu = New Elegant.Ui.Button()
      Me.eui_PCamere_VisGiù = New Elegant.Ui.Button()
      Me.RibbonGroup24 = New Elegant.Ui.RibbonGroup()
      Me.eui_PCamere_VisOggi = New Elegant.Ui.Button()
      Me.Separator2 = New Elegant.Ui.Separator()
      Me.eui_PCamere_VisAnnoIndietro = New Elegant.Ui.Button()
      Me.eui_PCamere_VisAnnoAvanti = New Elegant.Ui.Button()
      Me.Separator13 = New Elegant.Ui.Separator()
      Me.eui_PCamere_VisMeseIndietro = New Elegant.Ui.Button()
      Me.eui_PCamere_VisMeseAvanti = New Elegant.Ui.Button()
      Me.Separator14 = New Elegant.Ui.Separator()
      Me.eui_PCamere_VisGiorniMeno = New Elegant.Ui.Button()
      Me.eui_PCamere_VisGiorniPiù = New Elegant.Ui.Button()
      Me.eui_Gestione = New Elegant.Ui.RibbonTabPage()
      Me.eui_GruppoPos = New Elegant.Ui.RibbonGroup()
      Me.eui_cmdGestionePosTavoli = New Elegant.Ui.Button()
      Me.eui_GruppoPrenotazioni = New Elegant.Ui.RibbonGroup()
      Me.eui_ddwnGestioneQuadroGiornaliero = New Elegant.Ui.DropDown()
      Me.eui_ddwnGestionePlanningRisorse = New Elegant.Ui.DropDown()
      Me.PopupMenu10 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdGestionePlanningCamere = New Elegant.Ui.Button()
      Me.sepPlannigCamere = New Elegant.Ui.Separator()
      Me.eui_cmdGestionePlanningRisorseSport = New Elegant.Ui.SplitButton()
      Me.PopupMenu12 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdGestionePlanningRisorseApriTutti = New Elegant.Ui.Button()
      Me.Separator9 = New Elegant.Ui.Separator()
      Me.eui_cmdGestionePlanningRisorseSport1 = New Elegant.Ui.Button()
      Me.Separator7 = New Elegant.Ui.Separator()
      Me.eui_cmdGestionePlanningRisorseSport2 = New Elegant.Ui.Button()
      Me.eui_cmdGestionePlanningRisorseSport3 = New Elegant.Ui.Button()
      Me.eui_cmdGestionePlanningRisorseSport4 = New Elegant.Ui.Button()
      Me.eui_ddwnGestionePrenotazioni = New Elegant.Ui.DropDown()
      Me.PopupMenu11 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdGestionePrenCamere = New Elegant.Ui.Button()
      Me.sepPrenCamere = New Elegant.Ui.Separator()
      Me.eui_cmdGestionePrenTavoli = New Elegant.Ui.Button()
      Me.eui_cmdGestionePrenSale = New Elegant.Ui.Button()
      Me.sepPrenRisorse = New Elegant.Ui.Separator()
      Me.eui_cmdGestionePrenRisorse = New Elegant.Ui.Button()
      Me.RibbonGroup15 = New Elegant.Ui.RibbonGroup()
      Me.eui_cmdGestioneClienti = New Elegant.Ui.Button()
      Me.eui_cmdGestioneSchedine = New Elegant.Ui.Button()
      Me.sepStatistiche = New Elegant.Ui.Separator()
      Me.eui_ddwnGestioneStatistiche = New Elegant.Ui.DropDown()
      Me.PopupMenu6 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdGestioneStatisticheHotel = New Elegant.Ui.Button()
      Me.sepHotel = New Elegant.Ui.Separator()
      Me.eui_cmdGestioneStatistiche = New Elegant.Ui.Button()
      Me.sepBarRistorante = New Elegant.Ui.Separator()
      Me.eui_cmdGestioneStatisticheRisorse = New Elegant.Ui.Button()
      Me.RibbonGroup16 = New Elegant.Ui.RibbonGroup()
      Me.eui_cmdGestioneOperatori = New Elegant.Ui.Button()
      Me.eui_cmdGestioneGruppiOp = New Elegant.Ui.Button()
      Me.Separator15 = New Elegant.Ui.Separator()
      Me.eui_cmdGestioneCambiaOp = New Elegant.Ui.Button()
      Me.RibbonGroup30 = New Elegant.Ui.RibbonGroup()
      Me.eui_cmdGestioneOpzioni = New Elegant.Ui.Button()
      Me.eui_Archivi = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup17 = New Elegant.Ui.RibbonGroup()
      Me.DropDown3 = New Elegant.Ui.DropDown()
      Me.PopupMenu1 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdArchiviAnagraficheClienti = New Elegant.Ui.Button()
      Me.eui_cmdArchiviAnagraficheFornitori = New Elegant.Ui.Button()
      Me.eui_cmdArchiviAnagraficheCamerieri = New Elegant.Ui.Button()
      Me.eui_cmdArchiviAnagraficheAziende = New Elegant.Ui.Button()
      Me.Separator1 = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviAnagraficheCamere = New Elegant.Ui.Button()
      Me.sepCamere = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviAnagraficheSale = New Elegant.Ui.Button()
      Me.eui_cmdArchiviAnagraficheTavoli = New Elegant.Ui.Button()
      Me.sepRistorante = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviAnagrafichePiatti = New Elegant.Ui.Button()
      Me.eui_cmdArchiviAnagraficheCategoriePiatti = New Elegant.Ui.Button()
      Me.sepBar = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviAnagraficheRisorse = New Elegant.Ui.Button()
      Me.eui_cmdArchiviAnagraficheUtilizzoRisorse = New Elegant.Ui.Button()
      Me.eui_cmdArchiviAnagraficheAccServ = New Elegant.Ui.Button()
      Me.sepRisorse = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviAnagraficheDatiAzienda = New Elegant.Ui.Button()
      Me.RibbonGroup5 = New Elegant.Ui.RibbonGroup()
      Me.DropDown1 = New Elegant.Ui.DropDown()
      Me.PopupMenu3 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdArchiviTabelleTitoli = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleCategorieCliente = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleAttività = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleComuni = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleNazioni = New Elegant.Ui.Button()
      Me.Separator4 = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviTabelleUM = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleCategorieMerce = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleMagazzini = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleUbicazioni = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleScaffali = New Elegant.Ui.Button()
      Me.sepMagazzino = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviTabelleReparti = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleMsgReparti = New Elegant.Ui.Button()
      Me.sepReparti = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviTabelleCausaliDoc = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabellePagamenti = New Elegant.Ui.Button()
      Me.Separator8 = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviTabelleListini = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleStagioni = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleTipologieCamere = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleUbicazioniCamere = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabellePosizioniCamere = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleTipoAlloggiati = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleGruppi = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleAgenzie = New Elegant.Ui.Button()
      Me.eui_cmdArchiviTabelleCanali = New Elegant.Ui.Button()
      Me.sepListini = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviTabelleStatoPren = New Elegant.Ui.Button()
      Me.sepStatoPren = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviTabelleDocIdentità = New Elegant.Ui.Button()
      Me.Separator24 = New Elegant.Ui.Separator()
      Me.eui_cmdArchiviTabelleTipoRisorse = New Elegant.Ui.Button()
      Me.RibbonGroup1 = New Elegant.Ui.RibbonGroup()
      Me.eui_cmdArchiviImporta = New Elegant.Ui.Button()
      Me.eui_cmdArchiviBackup = New Elegant.Ui.Button()
      Me.eui_cmdArchiviPulizia = New Elegant.Ui.Button()
      Me.eui_cmdArchiviCompatta = New Elegant.Ui.Button()
      Me.eui_Contabilità = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup6 = New Elegant.Ui.RibbonGroup()
      Me.eui_ContabilitàChiusura = New Elegant.Ui.Button()
      Me.eui_ContabilitàCorrispettivi = New Elegant.Ui.Button()
      Me.eui_ContabilitàPrimaNota = New Elegant.Ui.Button()
      Me.RibbonGroup7 = New Elegant.Ui.RibbonGroup()
      Me.eui_ContabilitàElencoDocVendita = New Elegant.Ui.Button()
      Me.eui_ContabilitàElencoDocAcquisto = New Elegant.Ui.Button()
      Me.eui_Magazzino = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup8 = New Elegant.Ui.RibbonGroup()
      Me.eui_MagazzinoArticoli = New Elegant.Ui.Button()
      Me.RibbonGroup9 = New Elegant.Ui.RibbonGroup()
      Me.eui_MagazzinoMovimenti = New Elegant.Ui.Button()
      Me.RibbonGroup11 = New Elegant.Ui.RibbonGroup()
      Me.eui_MagazzinoInventario = New Elegant.Ui.Button()
      Me.RibbonGroup12 = New Elegant.Ui.RibbonGroup()
      Me.eui_MagazzinoScorte = New Elegant.Ui.Button()
      Me.eui_Visualizza = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup10 = New Elegant.Ui.RibbonGroup()
      Me.eui_VisualizzaRegOperazioni = New Elegant.Ui.Button()
      Me.eui_VisualizzaRegErrori = New Elegant.Ui.Button()
      Me.eui_Strumenti = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup28 = New Elegant.Ui.RibbonGroup()
      Me.eui_StrumentiEmail = New Elegant.Ui.Button()
      Me.eui_GruppoReparti = New Elegant.Ui.RibbonGroup()
      Me.eui_StrumentiMsgReparti = New Elegant.Ui.Button()
      Me.eui_GruppoEtichette = New Elegant.Ui.RibbonGroup()
      Me.eui_StrumentiEtichette = New Elegant.Ui.Button()
      Me.RibbonGroup19 = New Elegant.Ui.RibbonGroup()
      Me.eui_StrumentiCap = New Elegant.Ui.Button()
      Me.eui_GruppoTavoli = New Elegant.Ui.RibbonGroup()
      Me.eui_StrumentiDispTavoli = New Elegant.Ui.Button()
      Me.eui_GruppoMenu = New Elegant.Ui.RibbonGroup()
      Me.eui_StrumentiMenù = New Elegant.Ui.Button()
      Me.RibbonGroup22 = New Elegant.Ui.RibbonGroup()
      Me.eui_StrumentiNote = New Elegant.Ui.Button()
      Me.eui_StrumentiCalcolatrice = New Elegant.Ui.Button()
      Me.eui_StrumentiTastiera = New Elegant.Ui.Button()
      Me.eui_Finestra = New Elegant.Ui.RibbonTabPage()
      Me.RibbonGroup14 = New Elegant.Ui.RibbonGroup()
      Me.eui_cmdFinestraSovrapponi = New Elegant.Ui.Button()
      Me.eui_cmdFinestraAffianca = New Elegant.Ui.DropDown()
      Me.PopupMenu4 = New Elegant.Ui.PopupMenu(Me.components)
      Me.eui_cmdFinestraAffiancaOrizz = New Elegant.Ui.Button()
      Me.eui_cmdFinestraAffiancaVert = New Elegant.Ui.Button()
      Me.eui_cmdFinestraDisponi = New Elegant.Ui.Button()
      Me.Separator22 = New Elegant.Ui.Separator()
      Me.eui_cmdFinestraChiudi = New Elegant.Ui.Button()
      Me.eui_cmdFinestraChiudiTutto = New Elegant.Ui.Button()
      Me.Separator21 = New Elegant.Ui.Separator()
      Me.eui_drpFinestraSel = New Elegant.Ui.DropDown()
      Me.FinestreMDI = New Elegant.Ui.PopupMenu(Me.components)
      Me.PopupMenu2 = New Elegant.Ui.PopupMenu(Me.components)
      Me.ToggleButton4 = New Elegant.Ui.ToggleButton()
      Me.ToggleButton5 = New Elegant.Ui.ToggleButton()
      Me.PopupMenu5 = New Elegant.Ui.PopupMenu(Me.components)
      Me.ToggleButton2 = New Elegant.Ui.ToggleButton()
      Me.ToggleButton3 = New Elegant.Ui.ToggleButton()
      Me.ToggleButton1 = New Elegant.Ui.ToggleButton()
      Me.ContextMenuExtenderProvider1 = New Elegant.Ui.ContextMenuExtenderProvider(Me.components)
      Me.eui_sbrMain = New Elegant.Ui.StatusBar()
      Me.StatusBarNotificationsArea1 = New Elegant.Ui.StatusBarNotificationsArea()
      Me.StatusBarPane5 = New Elegant.Ui.StatusBarPane()
      Me.PictureBox5 = New Elegant.Ui.PictureBox()
      Me.eui_cmdArchivio = New Elegant.Ui.Button()
      Me.StatusBarPane8 = New Elegant.Ui.StatusBarPane()
      Me.PictureBox19 = New Elegant.Ui.PictureBox()
      Me.eui_Informazioni = New Elegant.Ui.Label()
      Me.StatusBarControlsArea1 = New Elegant.Ui.StatusBarControlsArea()
      Me.StatusBarPane1 = New Elegant.Ui.StatusBarPane()
      Me.PictureBox1 = New Elegant.Ui.PictureBox()
      Me.eui_cmdAzienda = New Elegant.Ui.Button()
      Me.StatusBarPane3 = New Elegant.Ui.StatusBarPane()
      Me.PictureBox2 = New Elegant.Ui.PictureBox()
      Me.eui_cmdPostazione = New Elegant.Ui.Button()
      Me.StatusBarPane4 = New Elegant.Ui.StatusBarPane()
      Me.PictureBox3 = New Elegant.Ui.PictureBox()
      Me.eui_cmdOperatore = New Elegant.Ui.Button()
      Me.StatusBarPane6 = New Elegant.Ui.StatusBarPane()
      Me.PictureBox4 = New Elegant.Ui.PictureBox()
      Me.eui_cmdData = New Elegant.Ui.Button()
      Me.StatusBarPane2 = New Elegant.Ui.StatusBarPane()
      Me.eui_picAggiornamenti = New Elegant.Ui.PictureBox()
      Me.eui_cmdNuovoAgg = New Elegant.Ui.Button()
      Me.StatusBarPane7 = New Elegant.Ui.StatusBarPane()
      Me.PictureBox21 = New Elegant.Ui.PictureBox()
      Me.eui_cmdLicenza = New Elegant.Ui.Button()
      Me.NavigationBarItem6 = New Elegant.Ui.NavigationBarItem()
      Me.CheckBox7 = New Elegant.Ui.CheckBox()
      Me.PopupMenu7 = New Elegant.Ui.PopupMenu(Me.components)
      Me.PopupMenu8 = New Elegant.Ui.PopupMenu(Me.components)
      Me.PopupMenu9 = New Elegant.Ui.PopupMenu(Me.components)
      Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
      Me.RibbonTabPage3 = New Elegant.Ui.RibbonTabPage()
      Me.RibbonTabPage2 = New Elegant.Ui.RibbonTabPage()
      Me.RibbonTabPage1 = New Elegant.Ui.RibbonTabPage()
      Me.RibbonTabPage4 = New Elegant.Ui.RibbonTabPage()
      Me.RibbonTabPage5 = New Elegant.Ui.RibbonTabPage()
      themeSelector = New Elegant.Ui.ThemeSelector(Me.components)
      CType(Me.picProg, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.eui_File, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.eui_BackstageView1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_Guida.SuspendLayout()
      Me.BackstageViewPage1.SuspendLayout()
      CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.eui_lstProdottiAttivati, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_Info.SuspendLayout()
      CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_GestioneModuli.SuspendLayout()
      CType(Me.eui_StrumentiModifica, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_StrumentiModifica.SuspendLayout()
      CType(Me.RibbonGroup21, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup21.SuspendLayout()
      CType(Me.PopupMenu16, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RibbonGroup18, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup18.SuspendLayout()
      CType(Me.eui_StrumentiPeriodo, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_StrumentiPeriodo.SuspendLayout()
      CType(Me.RibbonGroup26, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup26.SuspendLayout()
      CType(Me.eui_rib_Visualizza, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_rib_Visualizza.SuspendLayout()
      CType(Me.eui_StrumentiDocumenti, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_StrumentiDocumenti.SuspendLayout()
      CType(Me.RibbonGroup29, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup29.SuspendLayout()
      CType(Me.RibbonGroup27, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup27.SuspendLayout()
      CType(Me.PopupMenu14, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu13, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu15, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.eui_StrumentiSospesiBuoni, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_StrumentiSospesiBuoni.SuspendLayout()
      CType(Me.RibbonGroup20, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup20.SuspendLayout()
      CType(Me.RibbonGroup25, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup25.SuspendLayout()
      CType(Me.eui_Amica_ImportaEsporta, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_Amica_ImportaEsporta.SuspendLayout()
      CType(Me.RibbonGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup2.SuspendLayout()
      CType(Me.eui_PCamere_Prenotazioni, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_PCamere_Prenotazioni.SuspendLayout()
      CType(Me.RibbonGroup13, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup13.SuspendLayout()
      CType(Me.RibbonGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup3.SuspendLayout()
      CType(Me.RibbonGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup4.SuspendLayout()
      CType(Me.eui_PCamere_Visualizza, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_PCamere_Visualizza.SuspendLayout()
      CType(Me.RibbonGroup23, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup23.SuspendLayout()
      CType(Me.RibbonGroup24, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup24.SuspendLayout()
      CType(Me.eui_Gestione, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_Gestione.SuspendLayout()
      CType(Me.eui_GruppoPos, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_GruppoPos.SuspendLayout()
      CType(Me.eui_GruppoPrenotazioni, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_GruppoPrenotazioni.SuspendLayout()
      CType(Me.PopupMenu10, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu12, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu11, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RibbonGroup15, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup15.SuspendLayout()
      CType(Me.PopupMenu6, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RibbonGroup16, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup16.SuspendLayout()
      CType(Me.RibbonGroup30, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup30.SuspendLayout()
      CType(Me.eui_Archivi, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_Archivi.SuspendLayout()
      CType(Me.RibbonGroup17, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup17.SuspendLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RibbonGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup5.SuspendLayout()
      CType(Me.PopupMenu3, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RibbonGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup1.SuspendLayout()
      CType(Me.eui_Contabilità, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_Contabilità.SuspendLayout()
      CType(Me.RibbonGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup6.SuspendLayout()
      CType(Me.RibbonGroup7, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup7.SuspendLayout()
      CType(Me.eui_Magazzino, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_Magazzino.SuspendLayout()
      CType(Me.RibbonGroup8, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup8.SuspendLayout()
      CType(Me.RibbonGroup9, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup9.SuspendLayout()
      CType(Me.RibbonGroup11, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup11.SuspendLayout()
      CType(Me.RibbonGroup12, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup12.SuspendLayout()
      CType(Me.eui_Visualizza, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_Visualizza.SuspendLayout()
      CType(Me.RibbonGroup10, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup10.SuspendLayout()
      CType(Me.eui_Strumenti, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_Strumenti.SuspendLayout()
      CType(Me.RibbonGroup28, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup28.SuspendLayout()
      CType(Me.eui_GruppoReparti, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_GruppoReparti.SuspendLayout()
      CType(Me.eui_GruppoEtichette, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_GruppoEtichette.SuspendLayout()
      CType(Me.RibbonGroup19, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup19.SuspendLayout()
      CType(Me.eui_GruppoTavoli, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_GruppoTavoli.SuspendLayout()
      CType(Me.eui_GruppoMenu, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_GruppoMenu.SuspendLayout()
      CType(Me.RibbonGroup22, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup22.SuspendLayout()
      CType(Me.eui_Finestra, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_Finestra.SuspendLayout()
      CType(Me.RibbonGroup14, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.RibbonGroup14.SuspendLayout()
      CType(Me.PopupMenu4, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.FinestreMDI, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu5, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.eui_sbrMain.SuspendLayout()
      Me.StatusBarNotificationsArea1.SuspendLayout()
      Me.StatusBarPane5.SuspendLayout()
      Me.StatusBarPane8.SuspendLayout()
      Me.StatusBarControlsArea1.SuspendLayout()
      Me.StatusBarPane1.SuspendLayout()
      Me.StatusBarPane3.SuspendLayout()
      Me.StatusBarPane4.SuspendLayout()
      Me.StatusBarPane6.SuspendLayout()
      Me.StatusBarPane2.SuspendLayout()
      Me.StatusBarPane7.SuspendLayout()
      CType(Me.PopupMenu7, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu8, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.PopupMenu9, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RibbonTabPage3, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RibbonTabPage2, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RibbonTabPage1, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RibbonTabPage4, System.ComponentModel.ISupportInitialize).BeginInit()
      CType(Me.RibbonTabPage5, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'picProg
      '
      Me.picProg.Image = CType(resources.GetObject("picProg.Image"), System.Drawing.Image)
      Me.picProg.Location = New System.Drawing.Point(513, 24)
      Me.picProg.Name = "picProg"
      Me.picProg.Size = New System.Drawing.Size(249, 154)
      Me.picProg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.picProg.TabIndex = 20
      Me.picProg.TabStop = False
      Me.ToolTip1.SetToolTip(Me.picProg, "Torna al programma.")
      '
      'txtPercorso
      '
      Me.txtPercorso.Id = "1316ac3b-9a65-40c8-a779-c19ca8d3e24d"
      Me.txtPercorso.KeyTip = "L"
      Me.txtPercorso.Location = New System.Drawing.Point(24, 48)
      Me.txtPercorso.Name = "txtPercorso"
      Me.txtPercorso.ReadOnly = True
      Me.txtPercorso.Size = New System.Drawing.Size(432, 21)
      Me.txtPercorso.TabIndex = 0
      Me.txtPercorso.Text = "C:\Progetti Software\Hospitality Solution\Versione 3.0.0.0\bin\Archivi"
      Me.txtPercorso.TextEditorWidth = 474
      Me.ToolTip1.SetToolTip(Me.txtPercorso, "Percorso dell'archivio.")
      '
      'lvwGestioneModuli
      '
      Me.lvwGestioneModuli.Activation = System.Windows.Forms.ItemActivation.OneClick
      Me.lvwGestioneModuli.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lvwGestioneModuli.BorderStyle = System.Windows.Forms.BorderStyle.None
      Me.lvwGestioneModuli.CheckBoxes = True
      Me.lvwGestioneModuli.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
      Me.lvwGestioneModuli.FullRowSelect = True
      ListViewGroup11.Header = "Hospitality Solution"
      ListViewGroup11.Name = "ListViewGroup1"
      ListViewGroup12.Header = "Bar"
      ListViewGroup12.Name = "ListViewGroup4"
      ListViewGroup13.Header = "Ristorante"
      ListViewGroup13.Name = "ListViewGroup3"
      ListViewGroup14.Header = "Hotel"
      ListViewGroup14.Name = "ListViewGroup5"
      ListViewGroup15.Header = "Campeggio"
      ListViewGroup15.Name = "ListViewGroup6"
      ListViewGroup16.Header = "Centro balneare"
      ListViewGroup16.Name = "ListViewGroup10"
      ListViewGroup17.Header = "Centro benessere"
      ListViewGroup17.Name = "ListViewGroup7"
      ListViewGroup18.Header = "Centro sportivo"
      ListViewGroup18.Name = "ListViewGroup8"
      ListViewGroup19.Header = "Vendita al dettaglio"
      ListViewGroup19.Name = "ListViewGroup9"
      ListViewGroup20.Header = "Moduli aggiuntivi"
      ListViewGroup20.Name = "ListViewGroup2"
      Me.lvwGestioneModuli.Groups.AddRange(New System.Windows.Forms.ListViewGroup() {ListViewGroup11, ListViewGroup12, ListViewGroup13, ListViewGroup14, ListViewGroup15, ListViewGroup16, ListViewGroup17, ListViewGroup18, ListViewGroup19, ListViewGroup20})
      Me.lvwGestioneModuli.HideSelection = False
      ListViewItem19.Group = ListViewGroup11
      ListViewItem19.StateImageIndex = 0
      ListViewItem19.UseItemStyleForSubItems = False
      ListViewItem20.Group = ListViewGroup12
      ListViewItem20.StateImageIndex = 0
      ListViewItem20.UseItemStyleForSubItems = False
      ListViewItem21.Group = ListViewGroup13
      ListViewItem21.StateImageIndex = 0
      ListViewItem21.UseItemStyleForSubItems = False
      ListViewItem22.Group = ListViewGroup13
      ListViewItem22.StateImageIndex = 0
      ListViewItem22.UseItemStyleForSubItems = False
      ListViewItem23.Group = ListViewGroup14
      ListViewItem23.StateImageIndex = 0
      ListViewItem23.UseItemStyleForSubItems = False
      ListViewItem24.Group = ListViewGroup15
      ListViewItem24.StateImageIndex = 0
      ListViewItem24.UseItemStyleForSubItems = False
      ListViewItem25.Group = ListViewGroup16
      ListViewItem25.StateImageIndex = 0
      ListViewItem25.UseItemStyleForSubItems = False
      ListViewItem26.Group = ListViewGroup17
      ListViewItem26.StateImageIndex = 0
      ListViewItem26.UseItemStyleForSubItems = False
      ListViewItem27.Group = ListViewGroup18
      ListViewItem27.StateImageIndex = 0
      ListViewItem27.UseItemStyleForSubItems = False
      ListViewItem28.Group = ListViewGroup19
      ListViewItem28.StateImageIndex = 0
      ListViewItem28.UseItemStyleForSubItems = False
      ListViewItem29.Group = ListViewGroup19
      ListViewItem29.StateImageIndex = 0
      ListViewItem29.UseItemStyleForSubItems = False
      ListViewItem30.Group = ListViewGroup20
      ListViewItem30.StateImageIndex = 0
      ListViewItem30.UseItemStyleForSubItems = False
      ListViewItem31.Group = ListViewGroup20
      ListViewItem31.StateImageIndex = 0
      ListViewItem31.UseItemStyleForSubItems = False
      ListViewItem32.Group = ListViewGroup13
      ListViewItem32.StateImageIndex = 0
      ListViewItem32.UseItemStyleForSubItems = False
      ListViewItem33.Group = ListViewGroup20
      ListViewItem33.StateImageIndex = 0
      ListViewItem33.UseItemStyleForSubItems = False
      ListViewItem34.Group = ListViewGroup20
      ListViewItem34.StateImageIndex = 0
      ListViewItem34.UseItemStyleForSubItems = False
      ListViewItem35.Group = ListViewGroup20
      ListViewItem35.StateImageIndex = 0
      ListViewItem35.UseItemStyleForSubItems = False
      ListViewItem36.Group = ListViewGroup20
      ListViewItem36.StateImageIndex = 0
      ListViewItem36.UseItemStyleForSubItems = False
      Me.lvwGestioneModuli.Items.AddRange(New System.Windows.Forms.ListViewItem() {ListViewItem19, ListViewItem20, ListViewItem21, ListViewItem22, ListViewItem23, ListViewItem24, ListViewItem25, ListViewItem26, ListViewItem27, ListViewItem28, ListViewItem29, ListViewItem30, ListViewItem31, ListViewItem32, ListViewItem33, ListViewItem34, ListViewItem35, ListViewItem36})
      Me.lvwGestioneModuli.Location = New System.Drawing.Point(0, 1)
      Me.lvwGestioneModuli.MultiSelect = False
      Me.lvwGestioneModuli.Name = "lvwGestioneModuli"
      Me.lvwGestioneModuli.ShowItemToolTips = True
      Me.lvwGestioneModuli.Size = New System.Drawing.Size(1313, 602)
      Me.lvwGestioneModuli.SmallImageList = Me.ImageList1
      Me.lvwGestioneModuli.TabIndex = 79
      Me.ToolTip1.SetToolTip(Me.lvwGestioneModuli, "Elenco moduli.")
      Me.lvwGestioneModuli.UseCompatibleStateImageBehavior = False
      Me.lvwGestioneModuli.View = System.Windows.Forms.View.Details
      '
      'ColumnHeader1
      '
      Me.ColumnHeader1.Text = "Nome modulo o prodotto"
      Me.ColumnHeader1.Width = 270
      '
      'ColumnHeader2
      '
      Me.ColumnHeader2.Text = "Descrizione"
      Me.ColumnHeader2.Width = 391
      '
      'ColumnHeader3
      '
      Me.ColumnHeader3.Text = "Codice di attivazione"
      Me.ColumnHeader3.Width = 221
      '
      'ColumnHeader4
      '
      Me.ColumnHeader4.Text = "Stato"
      Me.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
      Me.ColumnHeader4.Width = 92
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
      Me.ImageList1.Images.SetKeyName(9, "")
      Me.ImageList1.Images.SetKeyName(10, "")
      Me.ImageList1.Images.SetKeyName(11, "")
      Me.ImageList1.Images.SetKeyName(12, "")
      Me.ImageList1.Images.SetKeyName(13, "")
      Me.ImageList1.Images.SetKeyName(14, "")
      Me.ImageList1.Images.SetKeyName(15, "ApplicationButtonStyleDarkBlue.png")
      Me.ImageList1.Images.SetKeyName(16, "ApplicationButtonStyleGreen.png")
      Me.ImageList1.Images.SetKeyName(17, "ApplicationButtonStyleOlive.png")
      Me.ImageList1.Images.SetKeyName(18, "ApplicationButtonStylePurple.png")
      Me.ImageList1.Images.SetKeyName(19, "ApplicationButtonStyleRose.png")
      Me.ImageList1.Images.SetKeyName(20, "ApplicationButtonStyleCyan.png")
      Me.ImageList1.Images.SetKeyName(21, "ApplicationButtonStyleRust.png")
      Me.ImageList1.Images.SetKeyName(22, "ApplicationButtonStyleRose.png")
      Me.ImageList1.Images.SetKeyName(23, "ApplicationButtonStyleOrange.png")
      Me.ImageList1.Images.SetKeyName(24, "icona-small.ico")
      '
      'eui_cmdGestionePosCassa
      '
      Me.eui_cmdGestionePosCassa.Id = "2a0132b8-0107-4236-8d6f-397ae32b3f0c"
      Me.eui_cmdGestionePosCassa.KeyTip = "PC"
      Me.eui_cmdGestionePosCassa.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestionePosCassa.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestionePosCassa.Location = New System.Drawing.Point(4, 2)
      Me.eui_cmdGestionePosCassa.Name = "eui_cmdGestionePosCassa"
      Me.eui_cmdGestionePosCassa.ScreenTip.Caption = "Punto cassa (F2)"
      Me.eui_cmdGestionePosCassa.ScreenTip.Text = "Apre il Punto cassa per la vendita dei piatti con gestione del Conto immediato."
      Me.eui_GruppoPos.SetShortcutKeys(Me.eui_cmdGestionePosCassa, System.Windows.Forms.Keys.F2)
      Me.eui_cmdGestionePosCassa.Size = New System.Drawing.Size(42, 72)
      Me.eui_cmdGestionePosCassa.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestionePosCassa.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestionePosCassa.TabIndex = 0
      Me.eui_cmdGestionePosCassa.Text = "Punto cassa"
      '
      'Timer1
      '
      Me.Timer1.Enabled = True
      Me.Timer1.Interval = 1000
      '
      'formFrameSkinner
      '
      Me.formFrameSkinner.AllowGlass = False
      Me.formFrameSkinner.Form = Me
      Me.formFrameSkinner.TitleFont = New System.Drawing.Font("Segoe UI", 9.0!)
      '
      'eui_File
      '
      Me.eui_File.ApplicationButtonKeyTip = "F"
      Me.eui_File.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Office2010DarkBlue
      Me.eui_File.ApplicationButtonText = "File"
      Me.eui_File.BackstageView = Me.eui_BackstageView1
      Me.eui_File.ContextualTabGroups.AddRange(New Elegant.Ui.RibbonContextualTabGroup() {Me.rtgStrumentiModifica, Me.rtgGestionaleAmica, Me.rtgPlanningCamere})
      Me.eui_File.CurrentTabPage = Me.eui_Gestione
      Me.eui_File.Dock = System.Windows.Forms.DockStyle.Top
      Me.eui_File.HelpButtonImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_File.HelpButtonImages.Images"), System.Drawing.Image))})
      Me.eui_File.HelpButtonVisible = True
      Me.eui_File.Id = "e41ab4e2-2087-47dc-a9c0-67de24cd60ee"
      Me.eui_File.Location = New System.Drawing.Point(0, 0)
      Me.eui_File.Name = "eui_File"
      Me.eui_File.QuickAccessToolbarCustomizationDialogEnabled = False
      Me.eui_File.QuickAccessToolbarCustomizationEnabled = False
      Me.eui_File.Size = New System.Drawing.Size(1469, 154)
      Me.eui_File.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_File.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_File.TabIndex = 15
      Me.eui_File.TabPages.AddRange(New Elegant.Ui.RibbonTabPage() {Me.eui_Gestione, Me.eui_Archivi, Me.eui_Contabilità, Me.eui_Magazzino, Me.eui_Visualizza, Me.eui_Strumenti, Me.eui_Finestra})
      '
      'eui_BackstageView1
      '
      Me.eui_BackstageView1.CurrentPage = Me.eui_Guida
      Me.eui_BackstageView1.Id = "26b6ed12-6b3d-4104-bf29-d19f8880bdff"
      Me.eui_BackstageView1.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_Info, Me.eui_GestioneModuli, Me.BackstageViewSeparator1, Me.eui_Guida, Me.eui_Opzioni, Me.eui_Esci})
      Me.eui_BackstageView1.Location = New System.Drawing.Point(0, 55)
      Me.eui_BackstageView1.Name = "eui_BackstageView1"
      Me.eui_BackstageView1.Size = New System.Drawing.Size(1461, 732)
      Me.eui_BackstageView1.Style = Elegant.Ui.BackstageViewStyle.Office2010DarkBlue
      Me.eui_BackstageView1.TabIndex = 16
      '
      'eui_Guida
      '
      Me.eui_Guida.Controls.Add(Me.BackstageViewPage1)
      Me.eui_Guida.Controls.Add(Me.Button6)
      Me.eui_Guida.Controls.Add(Me.Button5)
      Me.eui_Guida.Controls.Add(Me.Button3)
      Me.eui_Guida.Controls.Add(Me.Button2)
      Me.eui_Guida.Controls.Add(Me.Button34)
      Me.eui_Guida.KeyTip = "W"
      Me.eui_Guida.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Guida.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Guida.Location = New System.Drawing.Point(0, 0)
      Me.eui_Guida.Name = "eui_Guida"
      Me.eui_Guida.Padding = New System.Windows.Forms.Padding(0, 1, 2, 1)
      Me.eui_Guida.Size = New System.Drawing.Size(1376, 730)
      Me.eui_Guida.TabIndex = 0
      Me.eui_Guida.Text = "Guida"
      '
      'BackstageViewPage1
      '
      Me.BackstageViewPage1.Controls.Add(Me.PictureBox20)
      Me.BackstageViewPage1.Controls.Add(Me.lnkVideo)
      Me.BackstageViewPage1.Controls.Add(Me.lblGiorniProva)
      Me.BackstageViewPage1.Controls.Add(Me.lblDemo)
      Me.BackstageViewPage1.Controls.Add(Me.PictureBox18)
      Me.BackstageViewPage1.Controls.Add(Me.lnkMsWeb)
      Me.BackstageViewPage1.Controls.Add(Me.lnkLicenza)
      Me.BackstageViewPage1.Controls.Add(Me.lblNumSerie)
      Me.BackstageViewPage1.Controls.Add(Me.lnkSupporto)
      Me.BackstageViewPage1.Controls.Add(Me.lblInfo)
      Me.BackstageViewPage1.Controls.Add(Me.lnkInfoSu)
      Me.BackstageViewPage1.Controls.Add(Me.lblVersione)
      Me.BackstageViewPage1.Controls.Add(Me.Label24)
      Me.BackstageViewPage1.Controls.Add(Me.PictureBox17)
      Me.BackstageViewPage1.Controls.Add(Me.Label26)
      Me.BackstageViewPage1.Controls.Add(Me.eui_txtDettagliProdotto)
      Me.BackstageViewPage1.Controls.Add(Me.eui_lstProdottiAttivati)
      Me.BackstageViewPage1.Controls.Add(Me.Label23)
      Me.BackstageViewPage1.Controls.Add(Me.PictureBox16)
      Me.BackstageViewPage1.Controls.Add(Me.Label22)
      Me.BackstageViewPage1.Controls.Add(Me.PictureBox15)
      Me.BackstageViewPage1.Controls.Add(Me.PictureBox14)
      Me.BackstageViewPage1.Controls.Add(Me.PictureBox13)
      Me.BackstageViewPage1.Controls.Add(Me.PictureBox12)
      Me.BackstageViewPage1.Controls.Add(Me.PictureBox10)
      Me.BackstageViewPage1.Controls.Add(Me.Label21)
      Me.BackstageViewPage1.Controls.Add(Me.Label20)
      Me.BackstageViewPage1.Controls.Add(Me.eui_cmdAggiornamenti)
      Me.BackstageViewPage1.Controls.Add(Me.eui_cmdMobile)
      Me.BackstageViewPage1.Controls.Add(Me.eui_cmdOpzioni)
      Me.BackstageViewPage1.Controls.Add(Me.eui_cmdContattaci)
      Me.BackstageViewPage1.Controls.Add(Me.eui_cmdGuida)
      Me.BackstageViewPage1.KeyTip = "W"
      Me.BackstageViewPage1.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("BackstageViewPage1.LargeImages.Images"), System.Drawing.Image))})
      Me.BackstageViewPage1.Location = New System.Drawing.Point(0, 1)
      Me.BackstageViewPage1.Name = "BackstageViewPage1"
      Me.BackstageViewPage1.Padding = New System.Windows.Forms.Padding(0, 1, 2, 1)
      Me.BackstageViewPage1.Size = New System.Drawing.Size(1374, 728)
      Me.BackstageViewPage1.TabIndex = 6
      Me.BackstageViewPage1.Text = "Guida"
      '
      'PictureBox20
      '
      Me.PictureBox20.Image = CType(resources.GetObject("PictureBox20.Image"), System.Drawing.Image)
      Me.PictureBox20.Location = New System.Drawing.Point(52, 252)
      Me.PictureBox20.Name = "PictureBox20"
      Me.PictureBox20.Size = New System.Drawing.Size(32, 32)
      Me.PictureBox20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox20.TabIndex = 49
      Me.PictureBox20.TabStop = False
      '
      'lnkVideo
      '
      Me.lnkVideo.ActiveLinkColor = System.Drawing.Color.DarkOrange
      Me.lnkVideo.AutoSize = True
      Me.lnkVideo.LinkColor = System.Drawing.Color.Gray
      Me.lnkVideo.Location = New System.Drawing.Point(116, 260)
      Me.lnkVideo.Name = "lnkVideo"
      Me.lnkVideo.Size = New System.Drawing.Size(220, 13)
      Me.lnkVideo.TabIndex = 2
      Me.lnkVideo.TabStop = True
      Me.lnkVideo.Text = "Guarda le Video Guide di Hospitality Solution."
      '
      'lblGiorniProva
      '
      Me.lblGiorniProva.AutoSize = True
      Me.lblGiorniProva.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.lblGiorniProva.ForeColor = System.Drawing.Color.Gray
      Me.lblGiorniProva.Location = New System.Drawing.Point(741, 56)
      Me.lblGiorniProva.Name = "lblGiorniProva"
      Me.lblGiorniProva.Size = New System.Drawing.Size(117, 13)
      Me.lblGiorniProva.TabIndex = 46
      Me.lblGiorniProva.Text = "GIORNI DI PROVA: 30"
      '
      'lblDemo
      '
      Me.lblDemo.AutoSize = True
      Me.lblDemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!)
      Me.lblDemo.ForeColor = System.Drawing.Color.DarkOrange
      Me.lblDemo.Location = New System.Drawing.Point(733, 32)
      Me.lblDemo.Name = "lblDemo"
      Me.lblDemo.Size = New System.Drawing.Size(181, 16)
      Me.lblDemo.TabIndex = 45
      Me.lblDemo.Text = "VERSIONE DIMOSTRATIVA"
      '
      'PictureBox18
      '
      Me.PictureBox18.Image = CType(resources.GetObject("PictureBox18.Image"), System.Drawing.Image)
      Me.PictureBox18.Location = New System.Drawing.Point(52, 303)
      Me.PictureBox18.Name = "PictureBox18"
      Me.PictureBox18.Size = New System.Drawing.Size(32, 32)
      Me.PictureBox18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox18.TabIndex = 44
      Me.PictureBox18.TabStop = False
      '
      'lnkMsWeb
      '
      Me.lnkMsWeb.ActiveLinkColor = System.Drawing.Color.DarkOrange
      Me.lnkMsWeb.AutoSize = True
      Me.lnkMsWeb.LinkColor = System.Drawing.Color.Gray
      Me.lnkMsWeb.Location = New System.Drawing.Point(116, 311)
      Me.lnkMsWeb.Name = "lnkMsWeb"
      Me.lnkMsWeb.Size = New System.Drawing.Size(215, 13)
      Me.lnkMsWeb.TabIndex = 3
      Me.lnkMsWeb.TabStop = True
      Me.lnkMsWeb.Text = "Visita il sito Internet della Montana Software."
      '
      'lnkLicenza
      '
      Me.lnkLicenza.ActiveLinkColor = System.Drawing.Color.DarkOrange
      Me.lnkLicenza.AutoSize = True
      Me.lnkLicenza.LinkColor = System.Drawing.Color.Gray
      Me.lnkLicenza.Location = New System.Drawing.Point(416, 624)
      Me.lnkLicenza.Name = "lnkLicenza"
      Me.lnkLicenza.Size = New System.Drawing.Size(238, 13)
      Me.lnkLicenza.TabIndex = 10
      Me.lnkLicenza.TabStop = True
      Me.lnkLicenza.Text = "Condizioni di licenza software Montana Software."
      '
      'lblNumSerie
      '
      Me.lblNumSerie.AutoSize = True
      Me.lblNumSerie.Location = New System.Drawing.Point(416, 600)
      Me.lblNumSerie.Name = "lblNumSerie"
      Me.lblNumSerie.Size = New System.Drawing.Size(63, 13)
      Me.lblNumSerie.TabIndex = 41
      Me.lblNumSerie.Text = "ID prodotto:"
      '
      'lnkSupporto
      '
      Me.lnkSupporto.ActiveLinkColor = System.Drawing.Color.DarkOrange
      Me.lnkSupporto.AutoSize = True
      Me.lnkSupporto.LinkColor = System.Drawing.Color.Gray
      Me.lnkSupporto.Location = New System.Drawing.Point(416, 576)
      Me.lnkSupporto.Name = "lnkSupporto"
      Me.lnkSupporto.Size = New System.Drawing.Size(225, 13)
      Me.lnkSupporto.TabIndex = 9
      Me.lnkSupporto.TabStop = True
      Me.lnkSupporto.Text = "Servizio Supporto Tecnico Montana Software."
      '
      'lblInfo
      '
      Me.lblInfo.AutoSize = True
      Me.lblInfo.Location = New System.Drawing.Point(416, 552)
      Me.lblInfo.Name = "lblInfo"
      Me.lblInfo.Size = New System.Drawing.Size(28, 13)
      Me.lblInfo.TabIndex = 39
      Me.lblInfo.Text = "Info:"
      '
      'lnkInfoSu
      '
      Me.lnkInfoSu.ActiveLinkColor = System.Drawing.Color.DarkOrange
      Me.lnkInfoSu.AutoSize = True
      Me.lnkInfoSu.LinkColor = System.Drawing.Color.Gray
      Me.lnkInfoSu.Location = New System.Drawing.Point(416, 528)
      Me.lnkInfoSu.Name = "lnkInfoSu"
      Me.lnkInfoSu.Size = New System.Drawing.Size(227, 13)
      Me.lnkInfoSu.TabIndex = 8
      Me.lnkInfoSu.TabStop = True
      Me.lnkInfoSu.Text = "Informazioni aggiuntive su versione e copyrigth"
      '
      'lblVersione
      '
      Me.lblVersione.AutoSize = True
      Me.lblVersione.Location = New System.Drawing.Point(416, 504)
      Me.lblVersione.Name = "lblVersione"
      Me.lblVersione.Size = New System.Drawing.Size(51, 13)
      Me.lblVersione.TabIndex = 37
      Me.lblVersione.Text = "Versione:"
      '
      'Label24
      '
      Me.Label24.AutoSize = True
      Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Label24.ForeColor = System.Drawing.Color.DimGray
      Me.Label24.Location = New System.Drawing.Point(416, 464)
      Me.Label24.Name = "Label24"
      Me.Label24.Size = New System.Drawing.Size(249, 16)
      Me.Label24.TabIndex = 36
      Me.Label24.Text = "Informazioni su Hospitality Solution"
      '
      'PictureBox17
      '
      Me.PictureBox17.BackColor = System.Drawing.Color.Transparent
      Me.PictureBox17.Image = CType(resources.GetObject("PictureBox17.Image"), System.Drawing.Image)
      Me.PictureBox17.Location = New System.Drawing.Point(416, 480)
      Me.PictureBox17.Name = "PictureBox17"
      Me.PictureBox17.Size = New System.Drawing.Size(500, 8)
      Me.PictureBox17.TabIndex = 35
      Me.PictureBox17.TabStop = False
      '
      'Label26
      '
      Me.Label26.AutoSize = True
      Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Label26.ForeColor = System.Drawing.Color.DimGray
      Me.Label26.Location = New System.Drawing.Point(416, 339)
      Me.Label26.Name = "Label26"
      Me.Label26.Size = New System.Drawing.Size(124, 16)
      Me.Label26.TabIndex = 34
      Me.Label26.Text = "Dettagli prodotto"
      '
      'eui_txtDettagliProdotto
      '
      Me.eui_txtDettagliProdotto.Id = "fbf90a56-48ff-4512-ad51-95b021fe30df"
      Me.eui_txtDettagliProdotto.KeyTip = "D"
      Me.eui_txtDettagliProdotto.Location = New System.Drawing.Point(416, 360)
      Me.eui_txtDettagliProdotto.Multiline = True
      Me.eui_txtDettagliProdotto.Name = "eui_txtDettagliProdotto"
      Me.eui_txtDettagliProdotto.ReadOnly = True
      Me.eui_txtDettagliProdotto.ScreenTip.Caption = "Dettagli prodotto"
      Me.eui_txtDettagliProdotto.ScreenTip.Text = "Informazioni sul prodotto installato."
      Me.eui_txtDettagliProdotto.Size = New System.Drawing.Size(500, 80)
      Me.eui_txtDettagliProdotto.TabIndex = 6
      Me.eui_txtDettagliProdotto.TextEditorWidth = 506
      '
      'eui_lstProdottiAttivati
      '
      Me.eui_lstProdottiAttivati.AutoScroll = True
      Me.eui_lstProdottiAttivati.Id = "12df6a0f-8828-44b9-948d-aff61ccffa9a"
      Me.eui_lstProdottiAttivati.KeyTip = "P"
      Me.eui_lstProdottiAttivati.Location = New System.Drawing.Point(416, 152)
      Me.eui_lstProdottiAttivati.Name = "eui_lstProdottiAttivati"
      Me.eui_lstProdottiAttivati.ScreenTip.Caption = "Prodotti attivati"
      Me.eui_lstProdottiAttivati.ScreenTip.Text = "Elenco dei prodotti attivi installati nel software."
      Me.eui_lstProdottiAttivati.Size = New System.Drawing.Size(500, 168)
      Me.eui_lstProdottiAttivati.TabIndex = 7
      Me.eui_lstProdottiAttivati.Text = "ListBox1"
      '
      'Label23
      '
      Me.Label23.AutoSize = True
      Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Label23.ForeColor = System.Drawing.Color.DimGray
      Me.Label23.Location = New System.Drawing.Point(416, 88)
      Me.Label23.Name = "Label23"
      Me.Label23.Size = New System.Drawing.Size(193, 16)
      Me.Label23.TabIndex = 29
      Me.Label23.Text = "Hospitality Solution Suite 3"
      '
      'PictureBox16
      '
      Me.PictureBox16.Image = CType(resources.GetObject("PictureBox16.Image"), System.Drawing.Image)
      Me.PictureBox16.Location = New System.Drawing.Point(416, 104)
      Me.PictureBox16.Name = "PictureBox16"
      Me.PictureBox16.Size = New System.Drawing.Size(500, 8)
      Me.PictureBox16.TabIndex = 28
      Me.PictureBox16.TabStop = False
      '
      'Label22
      '
      Me.Label22.AutoSize = True
      Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Label22.ForeColor = System.Drawing.Color.DimGray
      Me.Label22.Location = New System.Drawing.Point(416, 132)
      Me.Label22.Name = "Label22"
      Me.Label22.Size = New System.Drawing.Size(112, 16)
      Me.Label22.TabIndex = 27
      Me.Label22.Text = "Prodotti attivati"
      '
      'PictureBox15
      '
      Me.PictureBox15.Image = CType(resources.GetObject("PictureBox15.Image"), System.Drawing.Image)
      Me.PictureBox15.Location = New System.Drawing.Point(462, 30)
      Me.PictureBox15.Name = "PictureBox15"
      Me.PictureBox15.Size = New System.Drawing.Size(260, 35)
      Me.PictureBox15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox15.TabIndex = 26
      Me.PictureBox15.TabStop = False
      '
      'PictureBox14
      '
      Me.PictureBox14.Image = CType(resources.GetObject("PictureBox14.Image"), System.Drawing.Image)
      Me.PictureBox14.Location = New System.Drawing.Point(416, 24)
      Me.PictureBox14.Name = "PictureBox14"
      Me.PictureBox14.Size = New System.Drawing.Size(40, 40)
      Me.PictureBox14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
      Me.PictureBox14.TabIndex = 25
      Me.PictureBox14.TabStop = False
      '
      'PictureBox13
      '
      Me.PictureBox13.BackColor = System.Drawing.Color.Transparent
      Me.PictureBox13.Image = CType(resources.GetObject("PictureBox13.Image"), System.Drawing.Image)
      Me.PictureBox13.Location = New System.Drawing.Point(392, 0)
      Me.PictureBox13.Name = "PictureBox13"
      Me.PictureBox13.Size = New System.Drawing.Size(8, 823)
      Me.PictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox13.TabIndex = 24
      Me.PictureBox13.TabStop = False
      '
      'PictureBox12
      '
      Me.PictureBox12.Image = CType(resources.GetObject("PictureBox12.Image"), System.Drawing.Image)
      Me.PictureBox12.Location = New System.Drawing.Point(24, 377)
      Me.PictureBox12.Name = "PictureBox12"
      Me.PictureBox12.Size = New System.Drawing.Size(352, 8)
      Me.PictureBox12.TabIndex = 23
      Me.PictureBox12.TabStop = False
      '
      'PictureBox10
      '
      Me.PictureBox10.Image = CType(resources.GetObject("PictureBox10.Image"), System.Drawing.Image)
      Me.PictureBox10.Location = New System.Drawing.Point(24, 40)
      Me.PictureBox10.Name = "PictureBox10"
      Me.PictureBox10.Size = New System.Drawing.Size(352, 8)
      Me.PictureBox10.TabIndex = 22
      Me.PictureBox10.TabStop = False
      '
      'Label21
      '
      Me.Label21.AutoSize = True
      Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Label21.ForeColor = System.Drawing.Color.DimGray
      Me.Label21.Location = New System.Drawing.Point(24, 361)
      Me.Label21.Name = "Label21"
      Me.Label21.Size = New System.Drawing.Size(313, 16)
      Me.Label21.TabIndex = 7
      Me.Label21.Text = "Strumenti per l'utilizzo di Hospitality Solution"
      '
      'Label20
      '
      Me.Label20.AutoSize = True
      Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Label20.ForeColor = System.Drawing.Color.DimGray
      Me.Label20.Location = New System.Drawing.Point(24, 24)
      Me.Label20.Name = "Label20"
      Me.Label20.Size = New System.Drawing.Size(71, 16)
      Me.Label20.TabIndex = 6
      Me.Label20.Text = "Supporto"
      '
      'eui_cmdAggiornamenti
      '
      Me.eui_cmdAggiornamenti.BackColor = System.Drawing.Color.White
      Me.eui_cmdAggiornamenti.DescriptionText = "E' possibile recuperare gli aggiornamenti più recenti di Hospitality Solution."
      Me.eui_cmdAggiornamenti.FlatStyle = Elegant.Ui.FlatStyle.Flat
      Me.eui_cmdAggiornamenti.Id = "4a13c6bc-7ce5-4d8b-86a4-556a801346e5"
      Me.eui_cmdAggiornamenti.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.eui_cmdAggiornamenti.KeyTip = "A"
      Me.eui_cmdAggiornamenti.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdAggiornamenti.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdAggiornamenti.Location = New System.Drawing.Point(24, 577)
      Me.eui_cmdAggiornamenti.Name = "eui_cmdAggiornamenti"
      Me.eui_cmdAggiornamenti.Size = New System.Drawing.Size(344, 80)
      Me.eui_cmdAggiornamenti.TabIndex = 6
      Me.eui_cmdAggiornamenti.Text = "Controlla aggiornamenti"
      Me.eui_cmdAggiornamenti.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.eui_cmdAggiornamenti.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.eui_cmdAggiornamenti.WordWrap = True
      '
      'eui_cmdMobile
      '
      Me.eui_cmdMobile.BackColor = System.Drawing.Color.White
      Me.eui_cmdMobile.DescriptionText = "Installa Hospitality Solution in un dispositivo USB mobile per l'utilizzo su altr" &
    "i computer."
      Me.eui_cmdMobile.Enabled = False
      Me.eui_cmdMobile.FlatStyle = Elegant.Ui.FlatStyle.Flat
      Me.eui_cmdMobile.Id = "818d90e4-7ef8-42ef-b3cc-a44414c7c574"
      Me.eui_cmdMobile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.eui_cmdMobile.KeyTip = "H"
      Me.eui_cmdMobile.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdMobile.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdMobile.Location = New System.Drawing.Point(24, 489)
      Me.eui_cmdMobile.Name = "eui_cmdMobile"
      Me.eui_cmdMobile.Size = New System.Drawing.Size(344, 80)
      Me.eui_cmdMobile.TabIndex = 5
      Me.eui_cmdMobile.Text = "Hospitality Solution Mobile"
      Me.eui_cmdMobile.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.eui_cmdMobile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.eui_cmdMobile.WordWrap = True
      '
      'eui_cmdOpzioni
      '
      Me.eui_cmdOpzioni.BackColor = System.Drawing.Color.White
      Me.eui_cmdOpzioni.DescriptionText = "Consente di effettuare tutte le impostazioni del programma e di personalizzarne l" &
    "'utilizzo."
      Me.eui_cmdOpzioni.FlatStyle = Elegant.Ui.FlatStyle.Flat
      Me.eui_cmdOpzioni.Id = "217bb603-74f8-45f6-9c7c-a2686d2f73f6"
      Me.eui_cmdOpzioni.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.eui_cmdOpzioni.KeyTip = "OP"
      Me.eui_cmdOpzioni.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdOpzioni.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdOpzioni.Location = New System.Drawing.Point(24, 401)
      Me.eui_cmdOpzioni.Name = "eui_cmdOpzioni"
      Me.eui_cmdOpzioni.Size = New System.Drawing.Size(344, 80)
      Me.eui_cmdOpzioni.TabIndex = 4
      Me.eui_cmdOpzioni.Text = "Opzioni di configurazione"
      Me.eui_cmdOpzioni.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.eui_cmdOpzioni.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.eui_cmdOpzioni.WordWrap = True
      '
      'eui_cmdContattaci
      '
      Me.eui_cmdContattaci.BackColor = System.Drawing.Color.White
      Me.eui_cmdContattaci.DescriptionText = "Richiedi informazioni sull'utilizzo di Hospitality Solution."
      Me.eui_cmdContattaci.FlatStyle = Elegant.Ui.FlatStyle.Flat
      Me.eui_cmdContattaci.Id = "2eebbb8d-762c-43dc-af16-1a668c0ce0f8"
      Me.eui_cmdContattaci.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.eui_cmdContattaci.KeyTip = "C"
      Me.eui_cmdContattaci.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdContattaci.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdContattaci.Location = New System.Drawing.Point(24, 152)
      Me.eui_cmdContattaci.Name = "eui_cmdContattaci"
      Me.eui_cmdContattaci.Size = New System.Drawing.Size(344, 80)
      Me.eui_cmdContattaci.TabIndex = 1
      Me.eui_cmdContattaci.Text = "Contattaci"
      Me.eui_cmdContattaci.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.eui_cmdContattaci.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.eui_cmdContattaci.WordWrap = True
      '
      'eui_cmdGuida
      '
      Me.eui_cmdGuida.BackColor = System.Drawing.Color.White
      Me.eui_cmdGuida.DescriptionText = "Informazioni sull'utilizzo di Hospitality Solution."
      Me.eui_cmdGuida.FlatStyle = Elegant.Ui.FlatStyle.Flat
      Me.eui_cmdGuida.Id = "3c3f465e-94df-4801-8852-bab4d26a3ca0"
      Me.eui_cmdGuida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.eui_cmdGuida.KeyTip = "X"
      Me.eui_cmdGuida.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGuida.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGuida.Location = New System.Drawing.Point(24, 64)
      Me.eui_cmdGuida.Name = "eui_cmdGuida"
      Me.eui_cmdGuida.Size = New System.Drawing.Size(344, 80)
      Me.eui_cmdGuida.TabIndex = 0
      Me.eui_cmdGuida.Text = "Guida di Hospitality Solution."
      Me.eui_cmdGuida.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.eui_cmdGuida.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.eui_cmdGuida.WordWrap = True
      '
      'Button6
      '
      Me.Button6.BackColor = System.Drawing.Color.White
      Me.Button6.DescriptionText = "E' possibile recuperare gli aggiornamenti più recenti di Hospitality Solution."
      Me.Button6.FlatStyle = Elegant.Ui.FlatStyle.Flat
      Me.Button6.Id = "3164e3b2-02c9-4501-b907-1c2608384c8e"
      Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.Button6.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("Button6.LargeImages.Images"), System.Drawing.Image))})
      Me.Button6.Location = New System.Drawing.Point(32, 448)
      Me.Button6.Name = "Button6"
      Me.Button6.Size = New System.Drawing.Size(344, 80)
      Me.Button6.TabIndex = 5
      Me.Button6.Text = "Controlla aggiornamenti"
      Me.Button6.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.Button6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.Button6.WordWrap = True
      '
      'Button5
      '
      Me.Button5.BackColor = System.Drawing.Color.White
      Me.Button5.DescriptionText = "Installa Hospitality Solution in un dispositivo USB mobile per l'utilizzo su altr" &
    "i computer"
      Me.Button5.FlatStyle = Elegant.Ui.FlatStyle.Flat
      Me.Button5.Id = "9bdf162d-28cc-4184-93e8-8e1c87241eae"
      Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.Button5.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("Button5.LargeImages.Images"), System.Drawing.Image))})
      Me.Button5.Location = New System.Drawing.Point(32, 352)
      Me.Button5.Name = "Button5"
      Me.Button5.Size = New System.Drawing.Size(344, 80)
      Me.Button5.TabIndex = 4
      Me.Button5.Text = "Hospitality Solution Mobile"
      Me.Button5.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.Button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.Button5.WordWrap = True
      '
      'Button3
      '
      Me.Button3.BackColor = System.Drawing.Color.White
      Me.Button3.DescriptionText = "Consente di effettuare tutte le impostazioni del programma e di personalizzarne l" &
    "'utilizzo."
      Me.Button3.FlatStyle = Elegant.Ui.FlatStyle.Flat
      Me.Button3.Id = "09809a12-e86a-48dd-8bba-10fedb3f8828"
      Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.Button3.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("Button3.LargeImages.Images"), System.Drawing.Image))})
      Me.Button3.Location = New System.Drawing.Point(32, 256)
      Me.Button3.Name = "Button3"
      Me.Button3.Size = New System.Drawing.Size(344, 80)
      Me.Button3.TabIndex = 3
      Me.Button3.Text = "Opzioni"
      Me.Button3.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.Button3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.Button3.WordWrap = True
      '
      'Button2
      '
      Me.Button2.BackColor = System.Drawing.Color.White
      Me.Button2.DescriptionText = "Richiedi informazioni sull'utilizzo di Hospitality Solution."
      Me.Button2.FlatStyle = Elegant.Ui.FlatStyle.Flat
      Me.Button2.Id = "fabae588-5598-4230-be39-b8aa81452c38"
      Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.Button2.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("Button2.LargeImages.Images"), System.Drawing.Image))})
      Me.Button2.Location = New System.Drawing.Point(32, 136)
      Me.Button2.Name = "Button2"
      Me.Button2.Size = New System.Drawing.Size(344, 80)
      Me.Button2.TabIndex = 2
      Me.Button2.Text = "Contattaci"
      Me.Button2.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.Button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.Button2.WordWrap = True
      '
      'Button34
      '
      Me.Button34.BackColor = System.Drawing.Color.White
      Me.Button34.DescriptionText = "Informazioni sull'utilizzo di Hospitality Solution."
      Me.Button34.FlatStyle = Elegant.Ui.FlatStyle.Flat
      Me.Button34.Id = "aa5d4eb2-a6ef-4b5e-a2f5-64c34f016635"
      Me.Button34.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.Button34.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("Button34.LargeImages.Images"), System.Drawing.Image))})
      Me.Button34.Location = New System.Drawing.Point(32, 40)
      Me.Button34.Name = "Button34"
      Me.Button34.Size = New System.Drawing.Size(344, 80)
      Me.Button34.TabIndex = 1
      Me.Button34.Text = "Guida di Hospitality Solution."
      Me.Button34.TextAlign = System.Drawing.ContentAlignment.TopLeft
      Me.Button34.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      Me.Button34.WordWrap = True
      '
      'eui_Info
      '
      Me.eui_Info.Controls.Add(Me.Label1)
      Me.eui_Info.Controls.Add(Me.txtPercorso)
      Me.eui_Info.Controls.Add(Me.lblPercorso)
      Me.eui_Info.Controls.Add(Me.Label19)
      Me.eui_Info.Controls.Add(Me.Label18)
      Me.eui_Info.Controls.Add(Me.Label17)
      Me.eui_Info.Controls.Add(Me.Label16)
      Me.eui_Info.Controls.Add(Me.Label11)
      Me.eui_Info.Controls.Add(Me.Label12)
      Me.eui_Info.Controls.Add(Me.Label13)
      Me.eui_Info.Controls.Add(Me.Label14)
      Me.eui_Info.Controls.Add(Me.Label15)
      Me.eui_Info.Controls.Add(Me.lblDimensioniFile)
      Me.eui_Info.Controls.Add(Me.lblDataUltimaScrittura)
      Me.eui_Info.Controls.Add(Me.lblDataUltimoAccesso)
      Me.eui_Info.Controls.Add(Me.lblDataCreazione)
      Me.eui_Info.Controls.Add(Me.lblAttributi)
      Me.eui_Info.Controls.Add(Me.Label10)
      Me.eui_Info.Controls.Add(Me.PictureBox11)
      Me.eui_Info.Controls.Add(Me.picProg)
      Me.eui_Info.Controls.Add(Me.PictureBox9)
      Me.eui_Info.Controls.Add(Me.PictureBox8)
      Me.eui_Info.Controls.Add(Me.PictureBox7)
      Me.eui_Info.Controls.Add(Me.PictureBox6)
      Me.eui_Info.Controls.Add(Me.Label8)
      Me.eui_Info.Controls.Add(Me.Label9)
      Me.eui_Info.Controls.Add(Me.Label6)
      Me.eui_Info.Controls.Add(Me.Label7)
      Me.eui_Info.Controls.Add(Me.Label4)
      Me.eui_Info.Controls.Add(Me.Label5)
      Me.eui_Info.Controls.Add(Me.cmdCompatta)
      Me.eui_Info.Controls.Add(Me.cmdPulizia)
      Me.eui_Info.Controls.Add(Me.cmdBackup)
      Me.eui_Info.Controls.Add(Me.Label3)
      Me.eui_Info.Controls.Add(Me.Label2)
      Me.eui_Info.Controls.Add(Me.cmdAttivaModuli)
      Me.eui_Info.Controls.Add(Me.cmdApriPercorso)
      Me.eui_Info.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
      Me.eui_Info.KeyTip = "I"
      Me.eui_Info.Location = New System.Drawing.Point(0, 0)
      Me.eui_Info.Name = "eui_Info"
      Me.eui_Info.Padding = New System.Windows.Forms.Padding(0, 1, 2, 1)
      Me.eui_Info.Size = New System.Drawing.Size(1318, 730)
      Me.eui_Info.TabIndex = 0
      Me.eui_Info.Text = "Informazioni"
      '
      'Label1
      '
      Me.Label1.AutoSize = True
      Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
      Me.Label1.Location = New System.Drawing.Point(24, 24)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(229, 20)
      Me.Label1.TabIndex = 39
      Me.Label1.Text = "Informazioni su Hospitality.mdb"
      '
      'lblPercorso
      '
      Me.lblPercorso.AutoSize = True
      Me.lblPercorso.ForeColor = System.Drawing.Color.DimGray
      Me.lblPercorso.Location = New System.Drawing.Point(633, 256)
      Me.lblPercorso.Name = "lblPercorso"
      Me.lblPercorso.Size = New System.Drawing.Size(49, 13)
      Me.lblPercorso.TabIndex = 37
      Me.lblPercorso.Text = "Proprietà"
      '
      'Label19
      '
      Me.Label19.AutoSize = True
      Me.Label19.ForeColor = System.Drawing.Color.DimGray
      Me.Label19.Location = New System.Drawing.Point(513, 256)
      Me.Label19.Name = "Label19"
      Me.Label19.Size = New System.Drawing.Size(52, 13)
      Me.Label19.TabIndex = 36
      Me.Label19.Text = "Percorso:"
      '
      'Label18
      '
      Me.Label18.AutoSize = True
      Me.Label18.Location = New System.Drawing.Point(513, 344)
      Me.Label18.Name = "Label18"
      Me.Label18.Size = New System.Drawing.Size(30, 13)
      Me.Label18.TabIndex = 35
      Me.Label18.Text = "Date"
      '
      'Label17
      '
      Me.Label17.AutoSize = True
      Me.Label17.ForeColor = System.Drawing.Color.DimGray
      Me.Label17.Location = New System.Drawing.Point(633, 232)
      Me.Label17.Name = "Label17"
      Me.Label17.Size = New System.Drawing.Size(214, 13)
      Me.Label17.TabIndex = 34
      Me.Label17.Text = "Applicazione Microsoft Office Access (.mdb)"
      '
      'Label16
      '
      Me.Label16.AutoSize = True
      Me.Label16.ForeColor = System.Drawing.Color.DimGray
      Me.Label16.Location = New System.Drawing.Point(513, 232)
      Me.Label16.Name = "Label16"
      Me.Label16.Size = New System.Drawing.Size(47, 13)
      Me.Label16.TabIndex = 33
      Me.Label16.Text = "Tipo file:"
      '
      'Label11
      '
      Me.Label11.AutoSize = True
      Me.Label11.ForeColor = System.Drawing.Color.DimGray
      Me.Label11.Location = New System.Drawing.Point(513, 280)
      Me.Label11.Name = "Label11"
      Me.Label11.Size = New System.Drawing.Size(61, 13)
      Me.Label11.TabIndex = 32
      Me.Label11.Text = "Dimensioni:"
      '
      'Label12
      '
      Me.Label12.AutoSize = True
      Me.Label12.ForeColor = System.Drawing.Color.DimGray
      Me.Label12.Location = New System.Drawing.Point(513, 392)
      Me.Label12.Name = "Label12"
      Me.Label12.Size = New System.Drawing.Size(105, 13)
      Me.Label12.TabIndex = 31
      Me.Label12.Text = "Data ultima modifica:"
      '
      'Label13
      '
      Me.Label13.AutoSize = True
      Me.Label13.ForeColor = System.Drawing.Color.DimGray
      Me.Label13.Location = New System.Drawing.Point(513, 416)
      Me.Label13.Name = "Label13"
      Me.Label13.Size = New System.Drawing.Size(106, 13)
      Me.Label13.TabIndex = 30
      Me.Label13.Text = "Data ultimo accesso:"
      '
      'Label14
      '
      Me.Label14.AutoSize = True
      Me.Label14.ForeColor = System.Drawing.Color.DimGray
      Me.Label14.Location = New System.Drawing.Point(513, 368)
      Me.Label14.Name = "Label14"
      Me.Label14.Size = New System.Drawing.Size(82, 13)
      Me.Label14.TabIndex = 29
      Me.Label14.Text = "Data creazione:"
      '
      'Label15
      '
      Me.Label15.AutoSize = True
      Me.Label15.ForeColor = System.Drawing.Color.DimGray
      Me.Label15.Location = New System.Drawing.Point(513, 304)
      Me.Label15.Name = "Label15"
      Me.Label15.Size = New System.Drawing.Size(45, 13)
      Me.Label15.TabIndex = 28
      Me.Label15.Text = "Attributi:"
      '
      'lblDimensioniFile
      '
      Me.lblDimensioniFile.AutoSize = True
      Me.lblDimensioniFile.ForeColor = System.Drawing.Color.DimGray
      Me.lblDimensioniFile.Location = New System.Drawing.Point(633, 280)
      Me.lblDimensioniFile.Name = "lblDimensioniFile"
      Me.lblDimensioniFile.Size = New System.Drawing.Size(52, 13)
      Me.lblDimensioniFile.TabIndex = 27
      Me.lblDimensioniFile.Text = "Proprietà:"
      '
      'lblDataUltimaScrittura
      '
      Me.lblDataUltimaScrittura.AutoSize = True
      Me.lblDataUltimaScrittura.ForeColor = System.Drawing.Color.DimGray
      Me.lblDataUltimaScrittura.Location = New System.Drawing.Point(633, 392)
      Me.lblDataUltimaScrittura.Name = "lblDataUltimaScrittura"
      Me.lblDataUltimaScrittura.Size = New System.Drawing.Size(52, 13)
      Me.lblDataUltimaScrittura.TabIndex = 26
      Me.lblDataUltimaScrittura.Text = "Proprietà:"
      '
      'lblDataUltimoAccesso
      '
      Me.lblDataUltimoAccesso.AutoSize = True
      Me.lblDataUltimoAccesso.ForeColor = System.Drawing.Color.DimGray
      Me.lblDataUltimoAccesso.Location = New System.Drawing.Point(633, 416)
      Me.lblDataUltimoAccesso.Name = "lblDataUltimoAccesso"
      Me.lblDataUltimoAccesso.Size = New System.Drawing.Size(52, 13)
      Me.lblDataUltimoAccesso.TabIndex = 25
      Me.lblDataUltimoAccesso.Text = "Proprietà:"
      '
      'lblDataCreazione
      '
      Me.lblDataCreazione.AutoSize = True
      Me.lblDataCreazione.ForeColor = System.Drawing.Color.DimGray
      Me.lblDataCreazione.Location = New System.Drawing.Point(633, 368)
      Me.lblDataCreazione.Name = "lblDataCreazione"
      Me.lblDataCreazione.Size = New System.Drawing.Size(52, 13)
      Me.lblDataCreazione.TabIndex = 24
      Me.lblDataCreazione.Text = "Proprietà:"
      '
      'lblAttributi
      '
      Me.lblAttributi.AutoSize = True
      Me.lblAttributi.ForeColor = System.Drawing.Color.DimGray
      Me.lblAttributi.Location = New System.Drawing.Point(633, 304)
      Me.lblAttributi.Name = "lblAttributi"
      Me.lblAttributi.Size = New System.Drawing.Size(52, 13)
      Me.lblAttributi.TabIndex = 23
      Me.lblAttributi.Text = "Proprietà:"
      '
      'Label10
      '
      Me.Label10.AutoSize = True
      Me.Label10.Location = New System.Drawing.Point(513, 208)
      Me.Label10.Name = "Label10"
      Me.Label10.Size = New System.Drawing.Size(49, 13)
      Me.Label10.TabIndex = 22
      Me.Label10.Text = "Proprietà"
      '
      'PictureBox11
      '
      Me.PictureBox11.Image = CType(resources.GetObject("PictureBox11.Image"), System.Drawing.Image)
      Me.PictureBox11.Location = New System.Drawing.Point(8, 88)
      Me.PictureBox11.Name = "PictureBox11"
      Me.PictureBox11.Size = New System.Drawing.Size(465, 16)
      Me.PictureBox11.TabIndex = 21
      Me.PictureBox11.TabStop = False
      '
      'PictureBox9
      '
      Me.PictureBox9.Image = CType(resources.GetObject("PictureBox9.Image"), System.Drawing.Image)
      Me.PictureBox9.Location = New System.Drawing.Point(488, -16)
      Me.PictureBox9.Name = "PictureBox9"
      Me.PictureBox9.Size = New System.Drawing.Size(8, 823)
      Me.PictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
      Me.PictureBox9.TabIndex = 19
      Me.PictureBox9.TabStop = False
      '
      'PictureBox8
      '
      Me.PictureBox8.Image = CType(resources.GetObject("PictureBox8.Image"), System.Drawing.Image)
      Me.PictureBox8.Location = New System.Drawing.Point(8, 512)
      Me.PictureBox8.Name = "PictureBox8"
      Me.PictureBox8.Size = New System.Drawing.Size(465, 11)
      Me.PictureBox8.TabIndex = 18
      Me.PictureBox8.TabStop = False
      '
      'PictureBox7
      '
      Me.PictureBox7.Image = CType(resources.GetObject("PictureBox7.Image"), System.Drawing.Image)
      Me.PictureBox7.Location = New System.Drawing.Point(8, 376)
      Me.PictureBox7.Name = "PictureBox7"
      Me.PictureBox7.Size = New System.Drawing.Size(465, 11)
      Me.PictureBox7.TabIndex = 17
      Me.PictureBox7.TabStop = False
      '
      'PictureBox6
      '
      Me.PictureBox6.Image = CType(resources.GetObject("PictureBox6.Image"), System.Drawing.Image)
      Me.PictureBox6.Location = New System.Drawing.Point(8, 240)
      Me.PictureBox6.Name = "PictureBox6"
      Me.PictureBox6.Size = New System.Drawing.Size(465, 11)
      Me.PictureBox6.TabIndex = 16
      Me.PictureBox6.TabStop = False
      '
      'Label8
      '
      Me.Label8.Location = New System.Drawing.Point(144, 568)
      Me.Label8.Name = "Label8"
      Me.Label8.Size = New System.Drawing.Size(316, 72)
      Me.Label8.TabIndex = 15
      Me.Label8.Text = "Consente di effettuare la compattazione e il ripristino degli archivi. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Riduce" &
    " le dimensioni dell'archivio." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Corregge eventuali errori sul file." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Aumenta le p" &
    "restazioni di accesso ai dati."
      '
      'Label9
      '
      Me.Label9.AutoSize = True
      Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Label9.ForeColor = System.Drawing.Color.DimGray
      Me.Label9.Location = New System.Drawing.Point(144, 544)
      Me.Label9.Name = "Label9"
      Me.Label9.Size = New System.Drawing.Size(201, 16)
      Me.Label9.TabIndex = 14
      Me.Label9.Text = "Compatta e ripristina archivi"
      '
      'Label6
      '
      Me.Label6.Location = New System.Drawing.Point(144, 432)
      Me.Label6.Name = "Label6"
      Me.Label6.Size = New System.Drawing.Size(308, 64)
      Me.Label6.TabIndex = 13
      Me.Label6.Text = "Consente di effettuare l'eliminazione dei dati per singola tabella presenti negli" &
    " archivi."
      '
      'Label7
      '
      Me.Label7.AutoSize = True
      Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Label7.ForeColor = System.Drawing.Color.DimGray
      Me.Label7.Location = New System.Drawing.Point(144, 408)
      Me.Label7.Name = "Label7"
      Me.Label7.Size = New System.Drawing.Size(143, 16)
      Me.Label7.TabIndex = 12
      Me.Label7.Text = "Pulizia degli archivi"
      '
      'Label4
      '
      Me.Label4.Location = New System.Drawing.Point(144, 304)
      Me.Label4.Name = "Label4"
      Me.Label4.Size = New System.Drawing.Size(308, 56)
      Me.Label4.TabIndex = 11
      Me.Label4.Text = "Consente di effettuare copie di sicurezza degli archivi specificando il percorso " &
    "desiderato."
      '
      'Label5
      '
      Me.Label5.AutoSize = True
      Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Label5.ForeColor = System.Drawing.Color.DimGray
      Me.Label5.Location = New System.Drawing.Point(144, 280)
      Me.Label5.Name = "Label5"
      Me.Label5.Size = New System.Drawing.Size(116, 16)
      Me.Label5.TabIndex = 10
      Me.Label5.Text = "Backup dei dati"
      '
      'cmdCompatta
      '
      Me.cmdCompatta.Id = "3beaa235-1cf2-428b-bc5f-a89ca116578d"
      Me.cmdCompatta.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmdCompatta.KeyTip = "C"
      Me.cmdCompatta.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("cmdCompatta.LargeImages.Images"), System.Drawing.Image))})
      Me.cmdCompatta.Location = New System.Drawing.Point(24, 544)
      Me.cmdCompatta.Name = "cmdCompatta"
      Me.cmdCompatta.Size = New System.Drawing.Size(96, 88)
      Me.cmdCompatta.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("cmdCompatta.SmallImages.Images"), System.Drawing.Image))})
      Me.cmdCompatta.TabIndex = 4
      Me.cmdCompatta.Text = "&Compatta e ripristina archivi"
      Me.cmdCompatta.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmdCompatta.WordWrap = True
      '
      'cmdPulizia
      '
      Me.cmdPulizia.Id = "a26273e3-99b4-4aef-bfc7-06a038020054"
      Me.cmdPulizia.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmdPulizia.KeyTip = "P"
      Me.cmdPulizia.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("cmdPulizia.LargeImages.Images"), System.Drawing.Image))})
      Me.cmdPulizia.Location = New System.Drawing.Point(24, 408)
      Me.cmdPulizia.Name = "cmdPulizia"
      Me.cmdPulizia.Size = New System.Drawing.Size(96, 88)
      Me.cmdPulizia.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("cmdPulizia.SmallImages.Images"), System.Drawing.Image))})
      Me.cmdPulizia.TabIndex = 3
      Me.cmdPulizia.Text = "&Pulizia degli archivi"
      Me.cmdPulizia.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmdPulizia.WordWrap = True
      '
      'cmdBackup
      '
      Me.cmdBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
      Me.cmdBackup.Id = "0a083b69-95e9-4f3d-9bdb-3e7a42c9a4f4"
      Me.cmdBackup.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmdBackup.KeyTip = "B"
      Me.cmdBackup.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Default", CType(resources.GetObject("cmdBackup.LargeImages.Images"), System.Drawing.Image)), New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("cmdBackup.LargeImages.Images1"), System.Drawing.Image))})
      Me.cmdBackup.Location = New System.Drawing.Point(24, 280)
      Me.cmdBackup.Name = "cmdBackup"
      Me.cmdBackup.Size = New System.Drawing.Size(96, 80)
      Me.cmdBackup.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("cmdBackup.SmallImages.Images"), System.Drawing.Image))})
      Me.cmdBackup.TabIndex = 2
      Me.cmdBackup.Text = "&Backup dati archivi"
      Me.cmdBackup.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmdBackup.WordWrap = True
      '
      'Label3
      '
      Me.Label3.Location = New System.Drawing.Point(144, 152)
      Me.Label3.Name = "Label3"
      Me.Label3.Size = New System.Drawing.Size(300, 72)
      Me.Label3.TabIndex = 5
      Me.Label3.Text = resources.GetString("Label3.Text")
      '
      'Label2
      '
      Me.Label2.AutoSize = True
      Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold)
      Me.Label2.ForeColor = System.Drawing.Color.DimGray
      Me.Label2.Location = New System.Drawing.Point(144, 128)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(232, 16)
      Me.Label2.TabIndex = 4
      Me.Label2.Text = "Che cosa è Hospitality Solution?"
      '
      'cmdAttivaModuli
      '
      Me.cmdAttivaModuli.Enabled = False
      Me.cmdAttivaModuli.Id = "47bd6e8b-ff32-4fe7-8d53-cb2317e0671a"
      Me.cmdAttivaModuli.ImageAlign = System.Drawing.ContentAlignment.TopCenter
      Me.cmdAttivaModuli.KeyTip = "G"
      Me.cmdAttivaModuli.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("cmdAttivaModuli.LargeImages.Images"), System.Drawing.Image))})
      Me.cmdAttivaModuli.Location = New System.Drawing.Point(24, 128)
      Me.cmdAttivaModuli.Name = "cmdAttivaModuli"
      Me.cmdAttivaModuli.Size = New System.Drawing.Size(96, 88)
      Me.cmdAttivaModuli.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("cmdAttivaModuli.SmallImages.Images"), System.Drawing.Image))})
      Me.cmdAttivaModuli.TabIndex = 1
      Me.cmdAttivaModuli.Text = "&Vai a Gestione Moduli"
      Me.cmdAttivaModuli.TextAlign = System.Drawing.ContentAlignment.BottomCenter
      Me.cmdAttivaModuli.WordWrap = True
      '
      'cmdApriPercorso
      '
      Me.cmdApriPercorso.Id = "9aa60f9d-9ffb-4c55-a5eb-f497a2e91e6b"
      Me.cmdApriPercorso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriPercorso.KeyTip = "A"
      Me.cmdApriPercorso.Location = New System.Drawing.Point(513, 464)
      Me.cmdApriPercorso.Name = "cmdApriPercorso"
      Me.cmdApriPercorso.ScreenTip.Caption = "Apri percorso archivio"
      Me.cmdApriPercorso.ScreenTip.Text = "Apre il percorso archivio in Esplora file."
      Me.cmdApriPercorso.Size = New System.Drawing.Size(248, 40)
      Me.cmdApriPercorso.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("cmdApriPercorso.SmallImages.Images"), System.Drawing.Image))})
      Me.cmdApriPercorso.TabIndex = 5
      Me.cmdApriPercorso.Text = "Apri percorso archivio"
      Me.cmdApriPercorso.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.cmdApriPercorso.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      '
      'eui_GestioneModuli
      '
      Me.eui_GestioneModuli.AutoScroll = True
      Me.eui_GestioneModuli.Controls.Add(Me.lvwGestioneModuli)
      Me.eui_GestioneModuli.KeyTip = "G"
      Me.eui_GestioneModuli.Location = New System.Drawing.Point(0, 0)
      Me.eui_GestioneModuli.Name = "eui_GestioneModuli"
      Me.eui_GestioneModuli.Padding = New System.Windows.Forms.Padding(0, 1, 2, 1)
      Me.eui_GestioneModuli.Size = New System.Drawing.Size(1318, 730)
      Me.eui_GestioneModuli.TabIndex = 0
      Me.eui_GestioneModuli.Text = "Gestione Moduli    "
      '
      'BackstageViewSeparator1
      '
      Me.BackstageViewSeparator1.Id = "c365ef30-7323-4c13-8726-3d28dd1304d8"
      Me.BackstageViewSeparator1.Location = New System.Drawing.Point(1, 83)
      Me.BackstageViewSeparator1.Name = "BackstageViewSeparator1"
      Me.BackstageViewSeparator1.Size = New System.Drawing.Size(142, 2)
      Me.BackstageViewSeparator1.TabIndex = 4
      Me.BackstageViewSeparator1.Text = "BackstageViewSeparator1"
      '
      'eui_Opzioni
      '
      Me.eui_Opzioni.Id = "0e82a020-6e5b-4c5a-abdd-4fa582758f36"
      Me.eui_Opzioni.ImageToTextSpace = 5
      Me.eui_Opzioni.KeyTip = "O"
      Me.eui_Opzioni.Location = New System.Drawing.Point(7, 123)
      Me.eui_Opzioni.Margin = New System.Windows.Forms.Padding(6, 0, 6, 2)
      Me.eui_Opzioni.Name = "eui_Opzioni"
      Me.eui_Opzioni.Padding = New System.Windows.Forms.Padding(16, 6, 16, 6)
      Me.eui_Opzioni.ScreenTip.Caption = "Opzioni"
      Me.eui_Opzioni.ScreenTip.Text = "Apre la finestra per le impostazioni del programma."
      Me.eui_Opzioni.Size = New System.Drawing.Size(130, 28)
      Me.eui_Opzioni.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Opzioni.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Opzioni.TabIndex = 2
      Me.eui_Opzioni.Text = "Opzioni"
      '
      'eui_Esci
      '
      Me.eui_Esci.Id = "decd5ffb-3ae2-4154-9df5-d0fc238ce126"
      Me.eui_Esci.ImageToTextSpace = 5
      Me.eui_Esci.KeyTip = "E"
      Me.eui_Esci.Location = New System.Drawing.Point(7, 153)
      Me.eui_Esci.Margin = New System.Windows.Forms.Padding(6, 0, 6, 2)
      Me.eui_Esci.Name = "eui_Esci"
      Me.eui_Esci.Padding = New System.Windows.Forms.Padding(16, 6, 16, 6)
      Me.eui_Esci.ScreenTip.Caption = "Esci"
      Me.eui_Esci.ScreenTip.Text = "Esce dal programma."
      Me.eui_Esci.Size = New System.Drawing.Size(130, 28)
      Me.eui_Esci.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Esci.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Esci.TabIndex = 3
      Me.eui_Esci.Text = "Esci"
      '
      'rtgStrumentiModifica
      '
      Me.rtgStrumentiModifica.Caption = "Strumenti di Modifica"
      Me.rtgStrumentiModifica.Color = Elegant.Ui.RibbonContextualTabGroupColor.Orange
      Me.rtgStrumentiModifica.TabPages.AddRange(New Elegant.Ui.RibbonTabPage() {Me.eui_StrumentiModifica, Me.eui_StrumentiPeriodo, Me.eui_StrumentiDocumenti, Me.eui_StrumentiSospesiBuoni})
      Me.rtgStrumentiModifica.Visible = False
      '
      'eui_StrumentiModifica
      '
      Me.eui_StrumentiModifica.Controls.Add(Me.RibbonGroup21)
      Me.eui_StrumentiModifica.Controls.Add(Me.RibbonGroup18)
      Me.eui_StrumentiModifica.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_StrumentiModifica.KeyTip = Nothing
      Me.eui_StrumentiModifica.Location = New System.Drawing.Point(0, 0)
      Me.eui_StrumentiModifica.Name = "eui_StrumentiModifica"
      Me.eui_StrumentiModifica.Size = New System.Drawing.Size(1469, 99)
      Me.eui_StrumentiModifica.TabIndex = 0
      Me.eui_StrumentiModifica.Text = "Modifica"
      '
      'RibbonGroup21
      '
      Me.RibbonGroup21.Controls.Add(Me.eui_Strumenti_Nuovo)
      Me.RibbonGroup21.Controls.Add(Me.eui_Strumenti_Modifica)
      Me.RibbonGroup21.Controls.Add(Me.eui_Strumenti_Duplica)
      Me.RibbonGroup21.Controls.Add(Me.eui_Strumenti_Elimina)
      Me.RibbonGroup21.Controls.Add(Me.eui_Strumenti_Annulla)
      Me.RibbonGroup21.Controls.Add(Me.Separator17)
      Me.RibbonGroup21.Controls.Add(Me.eui_Strumenti_Aggiorna)
      Me.RibbonGroup21.Controls.Add(Me.Separator16)
      Me.RibbonGroup21.Controls.Add(Me.eui_Strumenti_Esporta)
      Me.RibbonGroup21.DialogLauncherButtonVisible = False
      Me.RibbonGroup21.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup21.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup21.Name = "RibbonGroup21"
      Me.RibbonGroup21.Size = New System.Drawing.Size(358, 94)
      Me.RibbonGroup21.TabIndex = 3
      Me.RibbonGroup21.Text = "Dati"
      '
      'eui_Strumenti_Nuovo
      '
      Me.eui_Strumenti_Nuovo.Id = "ec688adb-6632-4b6a-8e9f-93d7d0bbde7c"
      Me.eui_Strumenti_Nuovo.KeyTip = "N"
      Me.eui_Strumenti_Nuovo.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Nuovo.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Nuovo.Location = New System.Drawing.Point(4, 2)
      Me.eui_Strumenti_Nuovo.Name = "eui_Strumenti_Nuovo"
      Me.eui_Strumenti_Nuovo.ScreenTip.Caption = "Nuovo"
      Me.eui_Strumenti_Nuovo.ScreenTip.Text = "Apre una finestra per l'inserimento di nuovi dati."
      Me.eui_Strumenti_Nuovo.Size = New System.Drawing.Size(42, 72)
      Me.eui_Strumenti_Nuovo.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Nuovo.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Nuovo.TabIndex = 0
      Me.eui_Strumenti_Nuovo.Text = "Nuovo"
      '
      'eui_Strumenti_Modifica
      '
      Me.eui_Strumenti_Modifica.Id = "0f22e12b-43eb-415a-b344-bcb8d9dfaece"
      Me.eui_Strumenti_Modifica.KeyTip = "M"
      Me.eui_Strumenti_Modifica.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Modifica.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Modifica.Location = New System.Drawing.Point(48, 2)
      Me.eui_Strumenti_Modifica.Name = "eui_Strumenti_Modifica"
      Me.eui_Strumenti_Modifica.ScreenTip.Caption = "Modifica"
      Me.eui_Strumenti_Modifica.ScreenTip.Text = "Apre una finestra per la modifica dei dati selezionati."
      Me.eui_Strumenti_Modifica.Size = New System.Drawing.Size(51, 72)
      Me.eui_Strumenti_Modifica.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Modifica.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Modifica.TabIndex = 3
      Me.eui_Strumenti_Modifica.Text = "Modifica"
      '
      'eui_Strumenti_Duplica
      '
      Me.eui_Strumenti_Duplica.Id = "69f08b0a-99c0-49e0-8b87-545ae1ea299a"
      Me.eui_Strumenti_Duplica.KeyTip = "D"
      Me.eui_Strumenti_Duplica.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Duplica.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Duplica.Location = New System.Drawing.Point(101, 2)
      Me.eui_Strumenti_Duplica.Name = "eui_Strumenti_Duplica"
      Me.eui_Strumenti_Duplica.ScreenTip.Caption = "Duplica"
      Me.eui_Strumenti_Duplica.ScreenTip.Text = "Duplica i dati selezionati."
      Me.eui_Strumenti_Duplica.Size = New System.Drawing.Size(44, 72)
      Me.eui_Strumenti_Duplica.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Duplica.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Duplica.TabIndex = 5
      Me.eui_Strumenti_Duplica.Text = "Duplica"
      '
      'eui_Strumenti_Elimina
      '
      Me.eui_Strumenti_Elimina.Id = "5af7a3f4-dfc0-4ed3-8d5b-aa1ed1b0f8bf"
      Me.eui_Strumenti_Elimina.KeyTip = "E"
      Me.eui_Strumenti_Elimina.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Elimina.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Elimina.Location = New System.Drawing.Point(147, 2)
      Me.eui_Strumenti_Elimina.Name = "eui_Strumenti_Elimina"
      Me.eui_Strumenti_Elimina.ScreenTip.Caption = "Elimina"
      Me.eui_Strumenti_Elimina.ScreenTip.Text = "Elimina i dati selezionati."
      Me.eui_Strumenti_Elimina.Size = New System.Drawing.Size(43, 72)
      Me.eui_Strumenti_Elimina.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Elimina.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Elimina.TabIndex = 1
      Me.eui_Strumenti_Elimina.Text = "Elimina"
      '
      'eui_Strumenti_Annulla
      '
      Me.eui_Strumenti_Annulla.Id = "a2230725-5509-4355-846f-0126ee6faaf5"
      Me.eui_Strumenti_Annulla.KeyTip = "U"
      Me.eui_Strumenti_Annulla.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Annulla.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Annulla.Location = New System.Drawing.Point(192, 2)
      Me.eui_Strumenti_Annulla.Name = "eui_Strumenti_Annulla"
      Me.eui_Strumenti_Annulla.ScreenTip.Caption = "Annulla documento"
      Me.eui_Strumenti_Annulla.ScreenTip.Text = "Annulla il documento selezionato e ripristina i dati contabili."
      Me.eui_Strumenti_Annulla.Size = New System.Drawing.Size(45, 72)
      Me.eui_Strumenti_Annulla.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Annulla.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Annulla.TabIndex = 7
      Me.eui_Strumenti_Annulla.Text = "Annulla"
      '
      'Separator17
      '
      Me.Separator17.Id = "b023b9e3-3057-4879-995b-39dc62dfff2f"
      Me.Separator17.Location = New System.Drawing.Point(240, 6)
      Me.Separator17.Name = "Separator17"
      Me.Separator17.Size = New System.Drawing.Size(3, 61)
      Me.Separator17.TabIndex = 2
      Me.Separator17.Text = "Separator17"
      '
      'eui_Strumenti_Aggiorna
      '
      Me.eui_Strumenti_Aggiorna.Id = "56f5a6fb-2aab-4640-9e45-4aee9e32019b"
      Me.eui_Strumenti_Aggiorna.KeyTip = "A"
      Me.eui_Strumenti_Aggiorna.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Aggiorna.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Aggiorna.Location = New System.Drawing.Point(246, 2)
      Me.eui_Strumenti_Aggiorna.Name = "eui_Strumenti_Aggiorna"
      Me.eui_Strumenti_Aggiorna.ScreenTip.Caption = "Aggiorna"
      Me.eui_Strumenti_Aggiorna.ScreenTip.Text = "Esegue un aggiornamento sui dati."
      Me.eui_Strumenti_Aggiorna.Size = New System.Drawing.Size(53, 72)
      Me.eui_Strumenti_Aggiorna.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Aggiorna.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Aggiorna.TabIndex = 4
      Me.eui_Strumenti_Aggiorna.Text = "Aggiorna"
      '
      'Separator16
      '
      Me.Separator16.Id = "2b0390c5-fe43-4f49-8e74-f0229a6468cc"
      Me.Separator16.Location = New System.Drawing.Point(302, 6)
      Me.Separator16.Name = "Separator16"
      Me.Separator16.Size = New System.Drawing.Size(3, 61)
      Me.Separator16.TabIndex = 2
      Me.Separator16.Text = "Separator16"
      '
      'eui_Strumenti_Esporta
      '
      Me.eui_Strumenti_Esporta.Id = "9a23c28d-7aa5-4ef9-8695-727562324a6d"
      Me.eui_Strumenti_Esporta.KeyTip = "S"
      Me.eui_Strumenti_Esporta.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Esporta.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Esporta.Location = New System.Drawing.Point(308, 2)
      Me.eui_Strumenti_Esporta.Name = "eui_Strumenti_Esporta"
      Me.eui_Strumenti_Esporta.Popup = Me.PopupMenu16
      Me.eui_Strumenti_Esporta.ScreenTip.Caption = "Esporta"
      Me.eui_Strumenti_Esporta.ScreenTip.Text = "Esporta i dati in diversi formati."
      Me.eui_Strumenti_Esporta.Size = New System.Drawing.Size(45, 72)
      Me.eui_Strumenti_Esporta.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Esporta.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Esporta.TabIndex = 8
      Me.eui_Strumenti_Esporta.Text = "Esporta"
      '
      'PopupMenu16
      '
      Me.PopupMenu16.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_Strumenti_Esporta_Anteprima, Me.eui_Strumenti_Esporta_SepXML, Me.eui_Strumenti_Esporta_EML, Me.eui_Strumenti_Esporta_XML})
      Me.PopupMenu16.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu16.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu16.Size = New System.Drawing.Size(100, 100)
      '
      'eui_Strumenti_Esporta_Anteprima
      '
      Me.eui_Strumenti_Esporta_Anteprima.Id = "65b2f3b7-7e45-4100-9e1f-71edc9e90288"
      Me.eui_Strumenti_Esporta_Anteprima.Location = New System.Drawing.Point(2, 2)
      Me.eui_Strumenti_Esporta_Anteprima.Name = "eui_Strumenti_Esporta_Anteprima"
      Me.eui_Strumenti_Esporta_Anteprima.Size = New System.Drawing.Size(267, 23)
      Me.eui_Strumenti_Esporta_Anteprima.TabIndex = 3
      Me.eui_Strumenti_Esporta_Anteprima.Text = "Elenco dati in formato PDF, Excel, Word"
      '
      'eui_Strumenti_Esporta_SepXML
      '
      Me.eui_Strumenti_Esporta_SepXML.Id = "e4a65587-a5fb-4e59-a2fe-588fbebb3401"
      Me.eui_Strumenti_Esporta_SepXML.Location = New System.Drawing.Point(2, 25)
      Me.eui_Strumenti_Esporta_SepXML.Name = "eui_Strumenti_Esporta_SepXML"
      Me.eui_Strumenti_Esporta_SepXML.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.eui_Strumenti_Esporta_SepXML.Size = New System.Drawing.Size(267, 5)
      Me.eui_Strumenti_Esporta_SepXML.TabIndex = 4
      Me.eui_Strumenti_Esporta_SepXML.Text = "Separator18"
      '
      'eui_Strumenti_Esporta_XML
      '
      Me.eui_Strumenti_Esporta_XML.Id = "790025bf-e591-4d18-9a2c-b77846bd6147"
      Me.eui_Strumenti_Esporta_XML.Location = New System.Drawing.Point(2, 53)
      Me.eui_Strumenti_Esporta_XML.Name = "eui_Strumenti_Esporta_XML"
      Me.eui_Strumenti_Esporta_XML.Size = New System.Drawing.Size(267, 23)
      Me.eui_Strumenti_Esporta_XML.TabIndex = 5
      Me.eui_Strumenti_Esporta_XML.Text = "Fattura Elettronica in formato XML "
      '
      'eui_Strumenti_Esporta_EML
      '
      Me.eui_Strumenti_Esporta_EML.Id = "55aeca89-faf6-40f8-9975-84df1329a9a1"
      Me.eui_Strumenti_Esporta_EML.Location = New System.Drawing.Point(2, 30)
      Me.eui_Strumenti_Esporta_EML.Name = "eui_Strumenti_Esporta_EML"
      Me.eui_Strumenti_Esporta_EML.Size = New System.Drawing.Size(267, 23)
      Me.eui_Strumenti_Esporta_EML.TabIndex = 7
      Me.eui_Strumenti_Esporta_EML.Text = "E-mail in formato messaggio EML"
      '
      'RibbonGroup18
      '
      Me.RibbonGroup18.Controls.Add(Me.eui_Strumenti_Stampa_Anteprima)
      Me.RibbonGroup18.Controls.Add(Me.eui_Strumenti_Stampa_Elenco)
      Me.RibbonGroup18.DialogLauncherButtonVisible = False
      Me.RibbonGroup18.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup18.Location = New System.Drawing.Point(363, 1)
      Me.RibbonGroup18.Name = "RibbonGroup18"
      Me.RibbonGroup18.Size = New System.Drawing.Size(115, 94)
      Me.RibbonGroup18.TabIndex = 1
      Me.RibbonGroup18.Text = "Stampa"
      '
      'eui_Strumenti_Stampa_Anteprima
      '
      Me.eui_Strumenti_Stampa_Anteprima.Id = "3534b19c-ac6e-4fc8-b46f-9fefc2db756e"
      Me.eui_Strumenti_Stampa_Anteprima.KeyTip = "P"
      Me.eui_Strumenti_Stampa_Anteprima.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Stampa_Anteprima.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Stampa_Anteprima.Location = New System.Drawing.Point(4, 2)
      Me.eui_Strumenti_Stampa_Anteprima.Name = "eui_Strumenti_Stampa_Anteprima"
      Me.eui_Strumenti_Stampa_Anteprima.ScreenTip.Caption = "Anteprima di Stampa"
      Me.eui_Strumenti_Stampa_Anteprima.ScreenTip.Text = "Visualizza l'anteprima di stampa per l'elenco dati."
      Me.eui_Strumenti_Stampa_Anteprima.Size = New System.Drawing.Size(60, 72)
      Me.eui_Strumenti_Stampa_Anteprima.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Stampa_Anteprima.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Stampa_Anteprima.TabIndex = 0
      Me.eui_Strumenti_Stampa_Anteprima.Text = "Anteprima"
      '
      'eui_Strumenti_Stampa_Elenco
      '
      Me.eui_Strumenti_Stampa_Elenco.Id = "885fed30-0915-40ca-9d08-e218bc9de2fc"
      Me.eui_Strumenti_Stampa_Elenco.KeyTip = "T"
      Me.eui_Strumenti_Stampa_Elenco.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Stampa_Elenco.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Stampa_Elenco.Location = New System.Drawing.Point(66, 2)
      Me.eui_Strumenti_Stampa_Elenco.Name = "eui_Strumenti_Stampa_Elenco"
      Me.eui_Strumenti_Stampa_Elenco.ScreenTip.Caption = "Stampa Elenco"
      Me.eui_Strumenti_Stampa_Elenco.ScreenTip.Text = "Stampa l'elenco dati."
      Me.eui_Strumenti_Stampa_Elenco.Size = New System.Drawing.Size(44, 72)
      Me.eui_Strumenti_Stampa_Elenco.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Stampa_Elenco.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Stampa_Elenco.TabIndex = 3
      Me.eui_Strumenti_Stampa_Elenco.Text = "Stampa"
      '
      'eui_StrumentiPeriodo
      '
      Me.eui_StrumentiPeriodo.Controls.Add(Me.RibbonGroup26)
      Me.eui_StrumentiPeriodo.Controls.Add(Me.eui_rib_Visualizza)
      Me.eui_StrumentiPeriodo.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_StrumentiPeriodo.KeyTip = Nothing
      Me.eui_StrumentiPeriodo.Location = New System.Drawing.Point(0, 0)
      Me.eui_StrumentiPeriodo.Name = "eui_StrumentiPeriodo"
      Me.eui_StrumentiPeriodo.ScreenTip.Caption = "Tutti i dati"
      Me.eui_StrumentiPeriodo.ScreenTip.Text = "Visualizza tutti i dati contenuti in archivio."
      Me.eui_StrumentiPeriodo.Size = New System.Drawing.Size(1333, 99)
      Me.eui_StrumentiPeriodo.TabIndex = 0
      Me.eui_StrumentiPeriodo.Text = "Periodo"
      '
      'RibbonGroup26
      '
      Me.RibbonGroup26.Controls.Add(Me.eui_Strumenti_Periodo_Tutte)
      Me.RibbonGroup26.Controls.Add(Me.Separator20)
      Me.RibbonGroup26.Controls.Add(Me.eui_Strumenti_Periodo_Anno)
      Me.RibbonGroup26.Controls.Add(Me.eui_Strumenti_Periodo_Mese)
      Me.RibbonGroup26.Controls.Add(Me.eui_Strumenti_Periodo_DalAl)
      Me.RibbonGroup26.Controls.Add(Me.eui_Strumenti_Periodo_Sep1)
      Me.RibbonGroup26.Controls.Add(Me.eui_Strumenti_Periodo_Arrivo)
      Me.RibbonGroup26.Controls.Add(Me.eui_Strumenti_Periodo_Partenza)
      Me.RibbonGroup26.Controls.Add(Me.eui_Strumenti_Periodo_Sep2)
      Me.RibbonGroup26.Controls.Add(Me.eui_Strumenti_Periodo_NonAssegnate)
      Me.RibbonGroup26.Controls.Add(Me.eui_Strumenti_Periodo_Terminate)
      Me.RibbonGroup26.DialogLauncherButtonVisible = False
      Me.RibbonGroup26.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup26.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup26.Name = "RibbonGroup26"
      Me.RibbonGroup26.Size = New System.Drawing.Size(443, 94)
      Me.RibbonGroup26.TabIndex = 3
      Me.RibbonGroup26.Text = "Periodo"
      '
      'eui_Strumenti_Periodo_Tutte
      '
      Me.eui_Strumenti_Periodo_Tutte.Id = "13458d09-04c8-4314-b816-7bc12dc08cb7"
      Me.eui_Strumenti_Periodo_Tutte.KeyTip = "T"
      Me.eui_Strumenti_Periodo_Tutte.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_Tutte.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_Tutte.Location = New System.Drawing.Point(98, 2)
      Me.eui_Strumenti_Periodo_Tutte.Name = "eui_Strumenti_Periodo_Tutte"
      Me.eui_Strumenti_Periodo_Tutte.Pressed = True
      Me.eui_Strumenti_Periodo_Tutte.Size = New System.Drawing.Size(30, 0)
      Me.eui_Strumenti_Periodo_Tutte.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_Tutte.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_Tutte.TabIndex = 7
      Me.eui_Strumenti_Periodo_Tutte.Text = "Tutti"
      '
      'Separator20
      '
      Me.Separator20.Id = "f0314c1a-0a61-47b2-964d-8a602d54cd94"
      Me.Separator20.Location = New System.Drawing.Point(99, 6)
      Me.Separator20.Name = "Separator20"
      Me.Separator20.Size = New System.Drawing.Size(3, 61)
      Me.Separator20.TabIndex = 5
      Me.Separator20.Text = "Separator20"
      '
      'eui_Strumenti_Periodo_Anno
      '
      Me.eui_Strumenti_Periodo_Anno.Id = "ef554c52-51ca-4dd1-8574-dc9b5cfc1aeb"
      Me.eui_Strumenti_Periodo_Anno.KeyTip = "A"
      Me.eui_Strumenti_Periodo_Anno.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_Anno.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_Anno.Location = New System.Drawing.Point(98, 74)
      Me.eui_Strumenti_Periodo_Anno.Name = "eui_Strumenti_Periodo_Anno"
      Me.eui_Strumenti_Periodo_Anno.ScreenTip.Caption = "Anno in corso"
      Me.eui_Strumenti_Periodo_Anno.ScreenTip.Text = "Visualizza solo i dati dell'anno in corso."
      Me.eui_Strumenti_Periodo_Anno.Size = New System.Drawing.Size(74, 0)
      Me.eui_Strumenti_Periodo_Anno.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_Anno.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_Anno.TabIndex = 9
      Me.eui_Strumenti_Periodo_Anno.Text = "Anno in corso"
      '
      'eui_Strumenti_Periodo_Mese
      '
      Me.eui_Strumenti_Periodo_Mese.Id = "a967bcab-51d2-459f-8016-bbb39d16ce4d"
      Me.eui_Strumenti_Periodo_Mese.KeyTip = "M"
      Me.eui_Strumenti_Periodo_Mese.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_Mese.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_Mese.Location = New System.Drawing.Point(98, 74)
      Me.eui_Strumenti_Periodo_Mese.Name = "eui_Strumenti_Periodo_Mese"
      Me.eui_Strumenti_Periodo_Mese.ScreenTip.Caption = "Mese in corso"
      Me.eui_Strumenti_Periodo_Mese.ScreenTip.Text = "Visualizza solo i dati del mese in corso."
      Me.eui_Strumenti_Periodo_Mese.Size = New System.Drawing.Size(75, 0)
      Me.eui_Strumenti_Periodo_Mese.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_Mese.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_Mese.TabIndex = 9
      Me.eui_Strumenti_Periodo_Mese.Text = "Mese in corso"
      '
      'eui_Strumenti_Periodo_DalAl
      '
      Me.eui_Strumenti_Periodo_DalAl.Id = "38ab1e23-04d8-4a76-8ae3-2cb9354865ce"
      Me.eui_Strumenti_Periodo_DalAl.KeyTip = "D"
      Me.eui_Strumenti_Periodo_DalAl.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_DalAl.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_DalAl.Location = New System.Drawing.Point(98, 74)
      Me.eui_Strumenti_Periodo_DalAl.Name = "eui_Strumenti_Periodo_DalAl"
      Me.eui_Strumenti_Periodo_DalAl.ScreenTip.Caption = "Periodo"
      Me.eui_Strumenti_Periodo_DalAl.ScreenTip.Text = "Visualizza solo i dati del periodo selezionato."
      Me.eui_Strumenti_Periodo_DalAl.Size = New System.Drawing.Size(55, 0)
      Me.eui_Strumenti_Periodo_DalAl.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_DalAl.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_DalAl.TabIndex = 10
      Me.eui_Strumenti_Periodo_DalAl.Text = "Dal... Al..."
      '
      'eui_Strumenti_Periodo_Sep1
      '
      Me.eui_Strumenti_Periodo_Sep1.Id = "7591c18c-c76a-4324-abf8-49b23cf67142"
      Me.eui_Strumenti_Periodo_Sep1.Location = New System.Drawing.Point(176, 6)
      Me.eui_Strumenti_Periodo_Sep1.Name = "eui_Strumenti_Periodo_Sep1"
      Me.eui_Strumenti_Periodo_Sep1.Size = New System.Drawing.Size(3, 61)
      Me.eui_Strumenti_Periodo_Sep1.TabIndex = 11
      Me.eui_Strumenti_Periodo_Sep1.Text = "Separator3"
      '
      'eui_Strumenti_Periodo_Arrivo
      '
      Me.eui_Strumenti_Periodo_Arrivo.Id = "63e7b88e-a03f-4d28-af64-6086a8a9d358"
      Me.eui_Strumenti_Periodo_Arrivo.KeyTip = "I"
      Me.eui_Strumenti_Periodo_Arrivo.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_Arrivo.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_Arrivo.Location = New System.Drawing.Point(175, 74)
      Me.eui_Strumenti_Periodo_Arrivo.Name = "eui_Strumenti_Periodo_Arrivo"
      Me.eui_Strumenti_Periodo_Arrivo.ScreenTip.Caption = "In Arrivo oggi"
      Me.eui_Strumenti_Periodo_Arrivo.ScreenTip.Text = "Visualizza tutte le prenotazioni in arrivo oggi."
      Me.eui_Strumenti_Periodo_Arrivo.Size = New System.Drawing.Size(71, 0)
      Me.eui_Strumenti_Periodo_Arrivo.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_Arrivo.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_Arrivo.TabIndex = 7
      Me.eui_Strumenti_Periodo_Arrivo.Text = "In Arrivo oggi"
      '
      'eui_Strumenti_Periodo_Partenza
      '
      Me.eui_Strumenti_Periodo_Partenza.Id = "bb229afd-d869-456c-b860-4b39f3d60389"
      Me.eui_Strumenti_Periodo_Partenza.KeyTip = "O"
      Me.eui_Strumenti_Periodo_Partenza.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_Partenza.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_Partenza.Location = New System.Drawing.Point(175, 74)
      Me.eui_Strumenti_Periodo_Partenza.Name = "eui_Strumenti_Periodo_Partenza"
      Me.eui_Strumenti_Periodo_Partenza.ScreenTip.Caption = "In Partenza oggi"
      Me.eui_Strumenti_Periodo_Partenza.ScreenTip.Text = "Visualizza tutte le prenotazioni in partenza oggi."
      Me.eui_Strumenti_Periodo_Partenza.Size = New System.Drawing.Size(86, 0)
      Me.eui_Strumenti_Periodo_Partenza.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Periodo_Partenza.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Periodo_Partenza.TabIndex = 8
      Me.eui_Strumenti_Periodo_Partenza.Text = "In Partenza oggi"
      '
      'eui_Strumenti_Periodo_Sep2
      '
      Me.eui_Strumenti_Periodo_Sep2.Id = "25700696-e287-4cd2-b05a-4e6690651b66"
      Me.eui_Strumenti_Periodo_Sep2.Location = New System.Drawing.Point(264, 6)
      Me.eui_Strumenti_Periodo_Sep2.Name = "eui_Strumenti_Periodo_Sep2"
      Me.eui_Strumenti_Periodo_Sep2.Size = New System.Drawing.Size(3, 61)
      Me.eui_Strumenti_Periodo_Sep2.TabIndex = 12
      Me.eui_Strumenti_Periodo_Sep2.Text = "Separator21"
      '
      'eui_Strumenti_Periodo_NonAssegnate
      '
      Me.eui_Strumenti_Periodo_NonAssegnate.Id = "ed23aae2-e9e7-4231-a336-b8b56fe0aa7e"
      Me.eui_Strumenti_Periodo_NonAssegnate.KeyTip = "NA"
      Me.eui_Strumenti_Periodo_NonAssegnate.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", Global.Hospitality_Solution.My.Resources.Resources.DiscardChanges)})
      Me.eui_Strumenti_Periodo_NonAssegnate.Location = New System.Drawing.Point(263, 74)
      Me.eui_Strumenti_Periodo_NonAssegnate.Name = "eui_Strumenti_Periodo_NonAssegnate"
      Me.eui_Strumenti_Periodo_NonAssegnate.ScreenTip.Caption = "Non assegnate"
      Me.eui_Strumenti_Periodo_NonAssegnate.ScreenTip.Text = "Visualizza tutte le prenotazioni non assegnate ad una camera che non sono ancora " &
    "scadute."
      Me.eui_Strumenti_Periodo_NonAssegnate.Size = New System.Drawing.Size(81, 0)
      Me.eui_Strumenti_Periodo_NonAssegnate.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", Global.Hospitality_Solution.My.Resources.Resources.DiscardChanges)})
      Me.eui_Strumenti_Periodo_NonAssegnate.TabIndex = 15
      Me.eui_Strumenti_Periodo_NonAssegnate.Text = "Non assegnate"
      '
      'eui_Strumenti_Periodo_Terminate
      '
      Me.eui_Strumenti_Periodo_Terminate.Id = "c7a2a66d-42d2-471e-8a47-44ee8f06ac19"
      Me.eui_Strumenti_Periodo_Terminate.KeyTip = "TE"
      Me.eui_Strumenti_Periodo_Terminate.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", Global.Hospitality_Solution.My.Resources.Resources.CancelApproval_32x32)})
      Me.eui_Strumenti_Periodo_Terminate.Location = New System.Drawing.Point(263, 74)
      Me.eui_Strumenti_Periodo_Terminate.Name = "eui_Strumenti_Periodo_Terminate"
      Me.eui_Strumenti_Periodo_Terminate.ScreenTip.Caption = "Terminate"
      Me.eui_Strumenti_Periodo_Terminate.ScreenTip.Text = "Visualizza tutte le prenotazioni terminate."
      Me.eui_Strumenti_Periodo_Terminate.Size = New System.Drawing.Size(56, 0)
      Me.eui_Strumenti_Periodo_Terminate.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", Global.Hospitality_Solution.My.Resources.Resources.CancelApproval_32x32)})
      Me.eui_Strumenti_Periodo_Terminate.TabIndex = 14
      Me.eui_Strumenti_Periodo_Terminate.Text = "Terminate"
      '
      'eui_rib_Visualizza
      '
      Me.eui_rib_Visualizza.Controls.Add(Me.eui_Strumenti_Visualizza_Presenze)
      Me.eui_rib_Visualizza.DialogLauncherButtonVisible = False
      Me.eui_rib_Visualizza.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_rib_Visualizza.Location = New System.Drawing.Point(448, 1)
      Me.eui_rib_Visualizza.Name = "eui_rib_Visualizza"
      Me.eui_rib_Visualizza.Size = New System.Drawing.Size(70, 94)
      Me.eui_rib_Visualizza.TabIndex = 5
      Me.eui_rib_Visualizza.Text = "Visualizza"
      '
      'eui_Strumenti_Visualizza_Presenze
      '
      Me.eui_Strumenti_Visualizza_Presenze.Id = "07e3c8f2-dc55-42d8-bb1a-f05965817c79"
      Me.eui_Strumenti_Visualizza_Presenze.KeyTip = "S"
      Me.eui_Strumenti_Visualizza_Presenze.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Visualizza_Presenze.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Visualizza_Presenze.Location = New System.Drawing.Point(4, 2)
      Me.eui_Strumenti_Visualizza_Presenze.Name = "eui_Strumenti_Visualizza_Presenze"
      Me.eui_Strumenti_Visualizza_Presenze.ScreenTip.Caption = "Storico presenze"
      Me.eui_Strumenti_Visualizza_Presenze.ScreenTip.Text = "Visualizza l'elenco strorico delle presenze."
      Me.eui_Strumenti_Visualizza_Presenze.Size = New System.Drawing.Size(89, 0)
      Me.eui_Strumenti_Visualizza_Presenze.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Visualizza_Presenze.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Visualizza_Presenze.TabIndex = 10
      Me.eui_Strumenti_Visualizza_Presenze.Text = "Storico Presenze"
      '
      'eui_StrumentiDocumenti
      '
      Me.eui_StrumentiDocumenti.Controls.Add(Me.RibbonGroup29)
      Me.eui_StrumentiDocumenti.Controls.Add(Me.RibbonGroup27)
      Me.eui_StrumentiDocumenti.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_StrumentiDocumenti.KeyTip = Nothing
      Me.eui_StrumentiDocumenti.Location = New System.Drawing.Point(0, 0)
      Me.eui_StrumentiDocumenti.Name = "eui_StrumentiDocumenti"
      Me.eui_StrumentiDocumenti.Size = New System.Drawing.Size(1341, 99)
      Me.eui_StrumentiDocumenti.TabIndex = 0
      Me.eui_StrumentiDocumenti.Text = "Documenti"
      '
      'RibbonGroup29
      '
      Me.RibbonGroup29.Controls.Add(Me.eui_Strumenti_Documenti_Proforma)
      Me.RibbonGroup29.Controls.Add(Me.eui_Strumenti_Documenti_Sep)
      Me.RibbonGroup29.Controls.Add(Me.eui_Strumenti_Documenti_Ricevuta)
      Me.RibbonGroup29.Controls.Add(Me.eui_Strumenti_Documenti_Fattura)
      Me.RibbonGroup29.Controls.Add(Me.eui_Strumenti_Documenti_Stampa_Schedina)
      Me.RibbonGroup29.DialogLauncherButtonVisible = False
      Me.RibbonGroup29.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup29.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup29.Name = "RibbonGroup29"
      Me.RibbonGroup29.Size = New System.Drawing.Size(219, 94)
      Me.RibbonGroup29.TabIndex = 6
      Me.RibbonGroup29.Text = "Stampa"
      '
      'eui_Strumenti_Documenti_Proforma
      '
      Me.eui_Strumenti_Documenti_Proforma.Id = "583195b5-3ccf-436e-a5d8-8c817995cb3f"
      Me.eui_Strumenti_Documenti_Proforma.KeyTip = "P"
      Me.eui_Strumenti_Documenti_Proforma.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Proforma.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Proforma.Location = New System.Drawing.Point(66, 2)
      Me.eui_Strumenti_Documenti_Proforma.Name = "eui_Strumenti_Documenti_Proforma"
      Me.eui_Strumenti_Documenti_Proforma.ScreenTip.Caption = "Stampa Proforma"
      Me.eui_Strumenti_Documenti_Proforma.ScreenTip.Text = "Stampa il conto Proforma per la prenotazione selezionata."
      Me.eui_Strumenti_Documenti_Proforma.Size = New System.Drawing.Size(51, 0)
      Me.eui_Strumenti_Documenti_Proforma.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Proforma.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Proforma.TabIndex = 6
      Me.eui_Strumenti_Documenti_Proforma.Text = "Proforma"
      '
      'eui_Strumenti_Documenti_Sep
      '
      Me.eui_Strumenti_Documenti_Sep.Id = "487ce7ae-a8ea-478c-90af-3ece9659c76f"
      Me.eui_Strumenti_Documenti_Sep.Location = New System.Drawing.Point(67, 6)
      Me.eui_Strumenti_Documenti_Sep.Name = "eui_Strumenti_Documenti_Sep"
      Me.eui_Strumenti_Documenti_Sep.Size = New System.Drawing.Size(3, 61)
      Me.eui_Strumenti_Documenti_Sep.TabIndex = 7
      Me.eui_Strumenti_Documenti_Sep.Text = "Separator18"
      '
      'eui_Strumenti_Documenti_Ricevuta
      '
      Me.eui_Strumenti_Documenti_Ricevuta.Id = "40fb78a2-d1a2-4d76-9d83-c420f1b36310"
      Me.eui_Strumenti_Documenti_Ricevuta.KeyTip = "R"
      Me.eui_Strumenti_Documenti_Ricevuta.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Ricevuta.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Ricevuta.Location = New System.Drawing.Point(66, 74)
      Me.eui_Strumenti_Documenti_Ricevuta.Name = "eui_Strumenti_Documenti_Ricevuta"
      Me.eui_Strumenti_Documenti_Ricevuta.ScreenTip.Caption = "Ricevuta fiscale"
      Me.eui_Strumenti_Documenti_Ricevuta.ScreenTip.Text = "Stampa la Ricevuta fiscale per la prenotazione selezionata."
      Me.eui_Strumenti_Documenti_Ricevuta.Size = New System.Drawing.Size(85, 0)
      Me.eui_Strumenti_Documenti_Ricevuta.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Ricevuta.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Ricevuta.TabIndex = 3
      Me.eui_Strumenti_Documenti_Ricevuta.Text = "Ricevuta fiscale"
      '
      'eui_Strumenti_Documenti_Fattura
      '
      Me.eui_Strumenti_Documenti_Fattura.Id = "ed4d06e2-69ee-46d8-8703-f665763e7b5e"
      Me.eui_Strumenti_Documenti_Fattura.KeyTip = "F"
      Me.eui_Strumenti_Documenti_Fattura.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Fattura.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Fattura.Location = New System.Drawing.Point(66, 74)
      Me.eui_Strumenti_Documenti_Fattura.Name = "eui_Strumenti_Documenti_Fattura"
      Me.eui_Strumenti_Documenti_Fattura.ScreenTip.Caption = "Stampa Fattura"
      Me.eui_Strumenti_Documenti_Fattura.ScreenTip.Text = "Stampa la Fattura per la prenotazione selezionata."
      Me.eui_Strumenti_Documenti_Fattura.Size = New System.Drawing.Size(42, 0)
      Me.eui_Strumenti_Documenti_Fattura.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Fattura.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Fattura.TabIndex = 0
      Me.eui_Strumenti_Documenti_Fattura.Text = "Fattura"
      '
      'eui_Strumenti_Documenti_Stampa_Schedina
      '
      Me.eui_Strumenti_Documenti_Stampa_Schedina.Id = "321eb080-94ff-4f42-acd7-6e69ba51391f"
      Me.eui_Strumenti_Documenti_Stampa_Schedina.KeyTip = "SS"
      Me.eui_Strumenti_Documenti_Stampa_Schedina.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Stampa_Schedina.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Stampa_Schedina.Location = New System.Drawing.Point(66, 74)
      Me.eui_Strumenti_Documenti_Stampa_Schedina.Name = "eui_Strumenti_Documenti_Stampa_Schedina"
      Me.eui_Strumenti_Documenti_Stampa_Schedina.ScreenTip.Caption = "Schedina P. S."
      Me.eui_Strumenti_Documenti_Stampa_Schedina.ScreenTip.Text = "Stampa la Schedina di Pubbica Sicurezza per l'elemento selezionato."
      Me.eui_Strumenti_Documenti_Stampa_Schedina.Size = New System.Drawing.Size(77, 0)
      Me.eui_Strumenti_Documenti_Stampa_Schedina.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Stampa_Schedina.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Stampa_Schedina.TabIndex = 6
      Me.eui_Strumenti_Documenti_Stampa_Schedina.Text = "Schedina P.S."
      '
      'RibbonGroup27
      '
      Me.RibbonGroup27.Controls.Add(Me.eui_Strumenti_Documenti_IstatC59)
      Me.RibbonGroup27.Controls.Add(Me.eui_Strumenti_Documenti_Schedina)
      Me.RibbonGroup27.Controls.Add(Me.eui_Strumenti_Documenti_Sep1)
      Me.RibbonGroup27.Controls.Add(Me.eui_Strumenti_Documenti_Invia)
      Me.RibbonGroup27.Controls.Add(Me.eui_Strumenti_Documenti_Esporta)
      Me.RibbonGroup27.DialogLauncherButtonVisible = False
      Me.RibbonGroup27.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup27.Location = New System.Drawing.Point(224, 1)
      Me.RibbonGroup27.Name = "RibbonGroup27"
      Me.RibbonGroup27.Size = New System.Drawing.Size(221, 94)
      Me.RibbonGroup27.TabIndex = 7
      Me.RibbonGroup27.Text = "Documento"
      '
      'eui_Strumenti_Documenti_IstatC59
      '
      Me.eui_Strumenti_Documenti_IstatC59.Id = "34a3f8f9-2e6d-44aa-ab29-1fa6216b5c74"
      Me.eui_Strumenti_Documenti_IstatC59.KeyTip = "MI"
      Me.eui_Strumenti_Documenti_IstatC59.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_IstatC59.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_IstatC59.Location = New System.Drawing.Point(62, 2)
      Me.eui_Strumenti_Documenti_IstatC59.Name = "eui_Strumenti_Documenti_IstatC59"
      Me.eui_Strumenti_Documenti_IstatC59.ScreenTip.Caption = "Modello Istat C/59"
      Me.eui_Strumenti_Documenti_IstatC59.ScreenTip.Text = "Genera il modello Istat C/59 per la stampa."
      Me.eui_Strumenti_Documenti_IstatC59.Size = New System.Drawing.Size(96, 0)
      Me.eui_Strumenti_Documenti_IstatC59.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_IstatC59.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_IstatC59.TabIndex = 6
      Me.eui_Strumenti_Documenti_IstatC59.Text = "Modello Istat C/59"
      '
      'eui_Strumenti_Documenti_Schedina
      '
      Me.eui_Strumenti_Documenti_Schedina.Id = "8ff6c145-83eb-4912-8e1f-214058db0341"
      Me.eui_Strumenti_Documenti_Schedina.KeyTip = "S"
      Me.eui_Strumenti_Documenti_Schedina.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Schedina.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Schedina.Location = New System.Drawing.Point(62, 2)
      Me.eui_Strumenti_Documenti_Schedina.Name = "eui_Strumenti_Documenti_Schedina"
      Me.eui_Strumenti_Documenti_Schedina.ScreenTip.Caption = "Schedina P. S."
      Me.eui_Strumenti_Documenti_Schedina.ScreenTip.Text = "Genera la Schedina di Pubbica Sicurezza per il documento selezionato."
      Me.eui_Strumenti_Documenti_Schedina.Size = New System.Drawing.Size(77, 0)
      Me.eui_Strumenti_Documenti_Schedina.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Schedina.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Schedina.TabIndex = 5
      Me.eui_Strumenti_Documenti_Schedina.Text = "Schedina P.S."
      '
      'eui_Strumenti_Documenti_Sep1
      '
      Me.eui_Strumenti_Documenti_Sep1.Id = "4a143a9b-d4d1-4655-bc13-df4474f55c31"
      Me.eui_Strumenti_Documenti_Sep1.Location = New System.Drawing.Point(63, 6)
      Me.eui_Strumenti_Documenti_Sep1.Name = "eui_Strumenti_Documenti_Sep1"
      Me.eui_Strumenti_Documenti_Sep1.Size = New System.Drawing.Size(3, 61)
      Me.eui_Strumenti_Documenti_Sep1.TabIndex = 4
      Me.eui_Strumenti_Documenti_Sep1.Text = "Separator23"
      '
      'eui_Strumenti_Documenti_Invia
      '
      Me.eui_Strumenti_Documenti_Invia.Id = "34645938-3532-4bae-a1dd-d81587bc084f"
      Me.eui_Strumenti_Documenti_Invia.KeyTip = "I"
      Me.eui_Strumenti_Documenti_Invia.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Invia.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Invia.Location = New System.Drawing.Point(62, 74)
      Me.eui_Strumenti_Documenti_Invia.Name = "eui_Strumenti_Documenti_Invia"
      Me.eui_Strumenti_Documenti_Invia.Popup = Me.PopupMenu14
      Me.eui_Strumenti_Documenti_Invia.ScreenTip.Caption = "Invia E-mail"
      Me.eui_Strumenti_Documenti_Invia.ScreenTip.Text = "Invia il documento selezionato tramite e-mail in formato PDF."
      Me.eui_Strumenti_Documenti_Invia.Size = New System.Drawing.Size(71, 0)
      Me.eui_Strumenti_Documenti_Invia.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Invia.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Invia.TabIndex = 2
      Me.eui_Strumenti_Documenti_Invia.Text = "Invia E-mail"
      '
      'PopupMenu14
      '
      Me.PopupMenu14.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_Strumenti_Documenti_Invia_Riepilogo, Me.Separator11, Me.eui_Strumenti_Documenti_Invia_Acconto, Me.eui_Strumenti_Documenti_Invia_Caparra})
      Me.PopupMenu14.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu14.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu14.Size = New System.Drawing.Size(100, 100)
      '
      'eui_Strumenti_Documenti_Invia_Riepilogo
      '
      Me.eui_Strumenti_Documenti_Invia_Riepilogo.Id = "c4939e4b-9c70-4b9b-abea-409bd0f5aa92"
      Me.eui_Strumenti_Documenti_Invia_Riepilogo.Location = New System.Drawing.Point(2, 2)
      Me.eui_Strumenti_Documenti_Invia_Riepilogo.Name = "eui_Strumenti_Documenti_Invia_Riepilogo"
      Me.eui_Strumenti_Documenti_Invia_Riepilogo.Size = New System.Drawing.Size(223, 23)
      Me.eui_Strumenti_Documenti_Invia_Riepilogo.TabIndex = 3
      Me.eui_Strumenti_Documenti_Invia_Riepilogo.Text = "Riepilogo prenotazione"
      '
      'Separator11
      '
      Me.Separator11.Id = "96eececa-c489-49e7-97d9-6e9b020b1ff2"
      Me.Separator11.Location = New System.Drawing.Point(2, 25)
      Me.Separator11.Name = "Separator11"
      Me.Separator11.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator11.Size = New System.Drawing.Size(223, 5)
      Me.Separator11.TabIndex = 5
      Me.Separator11.Text = "Separator11"
      '
      'eui_Strumenti_Documenti_Invia_Acconto
      '
      Me.eui_Strumenti_Documenti_Invia_Acconto.Id = "905cb56d-c140-4ac9-a5c7-38bdf81c16ac"
      Me.eui_Strumenti_Documenti_Invia_Acconto.Location = New System.Drawing.Point(2, 30)
      Me.eui_Strumenti_Documenti_Invia_Acconto.Name = "eui_Strumenti_Documenti_Invia_Acconto"
      Me.eui_Strumenti_Documenti_Invia_Acconto.Size = New System.Drawing.Size(223, 23)
      Me.eui_Strumenti_Documenti_Invia_Acconto.TabIndex = 4
      Me.eui_Strumenti_Documenti_Invia_Acconto.Text = "Ricevuta Acconto"
      '
      'eui_Strumenti_Documenti_Invia_Caparra
      '
      Me.eui_Strumenti_Documenti_Invia_Caparra.Id = "dd20b62d-b6bc-471f-8bab-80b8682f05d5"
      Me.eui_Strumenti_Documenti_Invia_Caparra.Location = New System.Drawing.Point(2, 53)
      Me.eui_Strumenti_Documenti_Invia_Caparra.Name = "eui_Strumenti_Documenti_Invia_Caparra"
      Me.eui_Strumenti_Documenti_Invia_Caparra.Size = New System.Drawing.Size(223, 23)
      Me.eui_Strumenti_Documenti_Invia_Caparra.TabIndex = 6
      Me.eui_Strumenti_Documenti_Invia_Caparra.Text = "Ricevuta Caparra confirmatoria"
      '
      'eui_Strumenti_Documenti_Esporta
      '
      Me.eui_Strumenti_Documenti_Esporta.Id = "fb143d4e-04aa-4681-bdf0-22caf76abf9f"
      Me.eui_Strumenti_Documenti_Esporta.KeyTip = "E"
      Me.eui_Strumenti_Documenti_Esporta.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Esporta.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Esporta.Location = New System.Drawing.Point(62, 74)
      Me.eui_Strumenti_Documenti_Esporta.Name = "eui_Strumenti_Documenti_Esporta"
      Me.eui_Strumenti_Documenti_Esporta.Popup = Me.PopupMenu13
      Me.eui_Strumenti_Documenti_Esporta.ScreenTip.Caption = "Esporta documento"
      Me.eui_Strumenti_Documenti_Esporta.ScreenTip.Text = "Esporta il documento selezionato in vari formati."
      Me.eui_Strumenti_Documenti_Esporta.Size = New System.Drawing.Size(53, 0)
      Me.eui_Strumenti_Documenti_Esporta.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Documenti_Esporta.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Documenti_Esporta.TabIndex = 1
      Me.eui_Strumenti_Documenti_Esporta.Text = "Esporta"
      '
      'PopupMenu13
      '
      Me.PopupMenu13.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdEsportaPdf, Me.Separator3, Me.eui_cmdEsportaHtml, Me.eui_cmdEsportaTxt})
      Me.PopupMenu13.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu13.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu13.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdEsportaPdf
      '
      Me.eui_cmdEsportaPdf.Id = "8ebf521e-f32a-472a-8435-b9e6176fd63b"
      Me.eui_cmdEsportaPdf.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdEsportaPdf.Name = "eui_cmdEsportaPdf"
      Me.eui_cmdEsportaPdf.Size = New System.Drawing.Size(245, 23)
      Me.eui_cmdEsportaPdf.TabIndex = 3
      Me.eui_cmdEsportaPdf.Text = "In formato PDF"
      '
      'Separator3
      '
      Me.Separator3.Id = "34fd3fb8-6f4e-4286-b900-84f8c6f21faf"
      Me.Separator3.Location = New System.Drawing.Point(2, 25)
      Me.Separator3.Name = "Separator3"
      Me.Separator3.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator3.Size = New System.Drawing.Size(245, 5)
      Me.Separator3.TabIndex = 4
      Me.Separator3.Text = "Separator3"
      '
      'eui_cmdEsportaHtml
      '
      Me.eui_cmdEsportaHtml.Id = "e5cd08e2-c3c5-41cb-ac3a-50149c604df6"
      Me.eui_cmdEsportaHtml.Location = New System.Drawing.Point(2, 30)
      Me.eui_cmdEsportaHtml.Name = "eui_cmdEsportaHtml"
      Me.eui_cmdEsportaHtml.Size = New System.Drawing.Size(245, 23)
      Me.eui_cmdEsportaHtml.TabIndex = 5
      Me.eui_cmdEsportaHtml.Text = "In formato HTML"
      '
      'eui_cmdEsportaTxt
      '
      Me.eui_cmdEsportaTxt.DescriptionText = Nothing
      Me.eui_cmdEsportaTxt.Id = "0e8e8a10-dc8c-4902-b455-9eb5a8601896"
      Me.eui_cmdEsportaTxt.Location = New System.Drawing.Point(2, 53)
      Me.eui_cmdEsportaTxt.Name = "eui_cmdEsportaTxt"
      Me.eui_cmdEsportaTxt.Popup = Me.PopupMenu15
      Me.eui_cmdEsportaTxt.Size = New System.Drawing.Size(245, 22)
      Me.eui_cmdEsportaTxt.TabIndex = 10
      Me.eui_cmdEsportaTxt.Text = "In formato TXT (alloggiatiweb)"
      '
      'PopupMenu15
      '
      Me.PopupMenu15.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdEsportaTxtSelezione, Me.eui_cmdEsportaTxtTutte})
      Me.PopupMenu15.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu15.PlacementMode = Elegant.Ui.PopupPlacementMode.Right
      Me.PopupMenu15.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdEsportaTxtSelezione
      '
      Me.eui_cmdEsportaTxtSelezione.Id = "7a3739bb-d740-442a-8e35-0498364ea424"
      Me.eui_cmdEsportaTxtSelezione.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdEsportaTxtSelezione.Name = "eui_cmdEsportaTxtSelezione"
      Me.eui_cmdEsportaTxtSelezione.Size = New System.Drawing.Size(204, 23)
      Me.eui_cmdEsportaTxtSelezione.TabIndex = 3
      Me.eui_cmdEsportaTxtSelezione.Text = "Schedina selezionata"
      '
      'eui_cmdEsportaTxtTutte
      '
      Me.eui_cmdEsportaTxtTutte.Id = "43cac2e9-628a-42a0-a853-d5c606833795"
      Me.eui_cmdEsportaTxtTutte.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdEsportaTxtTutte.Name = "eui_cmdEsportaTxtTutte"
      Me.eui_cmdEsportaTxtTutte.Size = New System.Drawing.Size(204, 23)
      Me.eui_cmdEsportaTxtTutte.TabIndex = 4
      Me.eui_cmdEsportaTxtTutte.Text = "Tutte le Schedine da inviare"
      '
      'eui_StrumentiSospesiBuoni
      '
      Me.eui_StrumentiSospesiBuoni.Controls.Add(Me.RibbonGroup20)
      Me.eui_StrumentiSospesiBuoni.Controls.Add(Me.RibbonGroup25)
      Me.eui_StrumentiSospesiBuoni.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_StrumentiSospesiBuoni.KeyTip = Nothing
      Me.eui_StrumentiSospesiBuoni.Location = New System.Drawing.Point(0, 0)
      Me.eui_StrumentiSospesiBuoni.Name = "eui_StrumentiSospesiBuoni"
      Me.eui_StrumentiSospesiBuoni.Size = New System.Drawing.Size(1252, 99)
      Me.eui_StrumentiSospesiBuoni.TabIndex = 0
      Me.eui_StrumentiSospesiBuoni.Text = "Sospesi / Buoni pasto"
      '
      'RibbonGroup20
      '
      Me.RibbonGroup20.Controls.Add(Me.eui_Strumenti_Sospesi_Filtra)
      Me.RibbonGroup20.Controls.Add(Me.Separator10)
      Me.RibbonGroup20.Controls.Add(Me.eui_Strumenti_Sospesi_Incassa)
      Me.RibbonGroup20.Controls.Add(Me.eui_Strumenti_Sospesi_Annulla)
      Me.RibbonGroup20.Controls.Add(Me.eui_Strumenti_Sospesi_Passa)
      Me.RibbonGroup20.DialogLauncherButtonVisible = False
      Me.RibbonGroup20.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup20.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup20.Name = "RibbonGroup20"
      Me.RibbonGroup20.Size = New System.Drawing.Size(198, 0)
      Me.RibbonGroup20.TabIndex = 0
      Me.RibbonGroup20.Text = "Sospesi"
      '
      'eui_Strumenti_Sospesi_Filtra
      '
      Me.eui_Strumenti_Sospesi_Filtra.Id = "2bbbb142-390f-4244-a27e-f7d97951fc9a"
      Me.eui_Strumenti_Sospesi_Filtra.KeyTip = "S"
      Me.eui_Strumenti_Sospesi_Filtra.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Sospesi_Filtra.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Sospesi_Filtra.Location = New System.Drawing.Point(53, 2)
      Me.eui_Strumenti_Sospesi_Filtra.Name = "eui_Strumenti_Sospesi_Filtra"
      Me.eui_Strumenti_Sospesi_Filtra.ScreenTip.Caption = "Sospesi"
      Me.eui_Strumenti_Sospesi_Filtra.ScreenTip.Text = "Visualizza l'elenco dei documenti con importo in sospeso."
      Me.eui_Strumenti_Sospesi_Filtra.Size = New System.Drawing.Size(46, 0)
      Me.eui_Strumenti_Sospesi_Filtra.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Sospesi_Filtra.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Sospesi_Filtra.TabIndex = 8
      Me.eui_Strumenti_Sospesi_Filtra.Text = "Sospesi"
      '
      'Separator10
      '
      Me.Separator10.Id = "cecacd73-3cd0-4b9b-b5b8-8c0d0abc80ec"
      Me.Separator10.Location = New System.Drawing.Point(54, 6)
      Me.Separator10.Name = "Separator10"
      Me.Separator10.Size = New System.Drawing.Size(3, -11)
      Me.Separator10.TabIndex = 10
      Me.Separator10.Text = "Separator10"
      '
      'eui_Strumenti_Sospesi_Incassa
      '
      Me.eui_Strumenti_Sospesi_Incassa.Id = "8149d0aa-ab4d-47dc-882d-fde6c5636944"
      Me.eui_Strumenti_Sospesi_Incassa.KeyTip = "I"
      Me.eui_Strumenti_Sospesi_Incassa.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Sospesi_Incassa.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Sospesi_Incassa.Location = New System.Drawing.Point(53, 2)
      Me.eui_Strumenti_Sospesi_Incassa.Name = "eui_Strumenti_Sospesi_Incassa"
      Me.eui_Strumenti_Sospesi_Incassa.ScreenTip.Caption = "Incassa sospeso"
      Me.eui_Strumenti_Sospesi_Incassa.ScreenTip.Text = "Apre una finestra per incassare l'importo in sospeso del documento selezionato."
      Me.eui_Strumenti_Sospesi_Incassa.Size = New System.Drawing.Size(46, 0)
      Me.eui_Strumenti_Sospesi_Incassa.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Sospesi_Incassa.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Sospesi_Incassa.TabIndex = 8
      Me.eui_Strumenti_Sospesi_Incassa.Text = "Incassa"
      '
      'eui_Strumenti_Sospesi_Annulla
      '
      Me.eui_Strumenti_Sospesi_Annulla.Id = "d87911c4-43c2-4ead-b840-d407567d4bfa"
      Me.eui_Strumenti_Sospesi_Annulla.KeyTip = "A"
      Me.eui_Strumenti_Sospesi_Annulla.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Sospesi_Annulla.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Sospesi_Annulla.Location = New System.Drawing.Point(53, 2)
      Me.eui_Strumenti_Sospesi_Annulla.Name = "eui_Strumenti_Sospesi_Annulla"
      Me.eui_Strumenti_Sospesi_Annulla.ScreenTip.Caption = "Annulla sospeso"
      Me.eui_Strumenti_Sospesi_Annulla.ScreenTip.Text = "Annulla l'importo in sospeso del documento selezionato."
      Me.eui_Strumenti_Sospesi_Annulla.Size = New System.Drawing.Size(44, 0)
      Me.eui_Strumenti_Sospesi_Annulla.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Sospesi_Annulla.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Sospesi_Annulla.TabIndex = 7
      Me.eui_Strumenti_Sospesi_Annulla.Text = "Annulla"
      '
      'eui_Strumenti_Sospesi_Passa
      '
      Me.eui_Strumenti_Sospesi_Passa.Id = "0bb61b8d-9a7b-433b-9192-beda49cdbc13"
      Me.eui_Strumenti_Sospesi_Passa.KeyTip = "P"
      Me.eui_Strumenti_Sospesi_Passa.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Sospesi_Passa.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Sospesi_Passa.Location = New System.Drawing.Point(53, 2)
      Me.eui_Strumenti_Sospesi_Passa.Name = "eui_Strumenti_Sospesi_Passa"
      Me.eui_Strumenti_Sospesi_Passa.ScreenTip.Caption = "Passa in sospeso"
      Me.eui_Strumenti_Sospesi_Passa.ScreenTip.Text = "Passa l'importo del documento selezionato in sospeso."
      Me.eui_Strumenti_Sospesi_Passa.Size = New System.Drawing.Size(91, 0)
      Me.eui_Strumenti_Sospesi_Passa.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Sospesi_Passa.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Sospesi_Passa.TabIndex = 9
      Me.eui_Strumenti_Sospesi_Passa.Text = "Passa in sospeso"
      '
      'RibbonGroup25
      '
      Me.RibbonGroup25.Controls.Add(Me.eui_Strumenti_Buoni_Pasto)
      Me.RibbonGroup25.DialogLauncherButtonVisible = False
      Me.RibbonGroup25.Location = New System.Drawing.Point(203, 1)
      Me.RibbonGroup25.Name = "RibbonGroup25"
      Me.RibbonGroup25.Size = New System.Drawing.Size(83, 0)
      Me.RibbonGroup25.TabIndex = 1
      Me.RibbonGroup25.Text = "Buoni pasto"
      '
      'eui_Strumenti_Buoni_Pasto
      '
      Me.eui_Strumenti_Buoni_Pasto.Id = "c9385b76-e8e1-448b-8ba7-a7a494160ca0"
      Me.eui_Strumenti_Buoni_Pasto.KeyTip = "B"
      Me.eui_Strumenti_Buoni_Pasto.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Buoni_Pasto.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Buoni_Pasto.Location = New System.Drawing.Point(4, 2)
      Me.eui_Strumenti_Buoni_Pasto.Name = "eui_Strumenti_Buoni_Pasto"
      Me.eui_Strumenti_Buoni_Pasto.ScreenTip.Caption = "Apri Buoni pasto"
      Me.eui_Strumenti_Buoni_Pasto.ScreenTip.Text = "Apre una finestra con l'elenco dei buoni pasto contenuti nel documento selezionat" &
    "o."
      Me.eui_Strumenti_Buoni_Pasto.Size = New System.Drawing.Size(95, 0)
      Me.eui_Strumenti_Buoni_Pasto.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_Strumenti_Buoni_Pasto.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_Strumenti_Buoni_Pasto.TabIndex = 7
      Me.eui_Strumenti_Buoni_Pasto.Text = "Apri Buoni pasto..."
      '
      'rtgGestionaleAmica
      '
      Me.rtgGestionaleAmica.Caption = "Gestionale Amica"
      Me.rtgGestionaleAmica.Color = Elegant.Ui.RibbonContextualTabGroupColor.Green
      Me.rtgGestionaleAmica.TabPages.AddRange(New Elegant.Ui.RibbonTabPage() {Me.eui_Amica_ImportaEsporta})
      Me.rtgGestionaleAmica.Visible = False
      '
      'eui_Amica_ImportaEsporta
      '
      Me.eui_Amica_ImportaEsporta.Controls.Add(Me.RibbonGroup2)
      Me.eui_Amica_ImportaEsporta.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_Amica_ImportaEsporta.KeyTip = Nothing
      Me.eui_Amica_ImportaEsporta.Location = New System.Drawing.Point(0, 0)
      Me.eui_Amica_ImportaEsporta.Name = "eui_Amica_ImportaEsporta"
      Me.eui_Amica_ImportaEsporta.Size = New System.Drawing.Size(1122, 99)
      Me.eui_Amica_ImportaEsporta.TabIndex = 0
      Me.eui_Amica_ImportaEsporta.Text = "Importa/Esporta"
      '
      'RibbonGroup2
      '
      Me.RibbonGroup2.Controls.Add(Me.eui_cmdAmicaImporta)
      Me.RibbonGroup2.Controls.Add(Me.eui_cmdAmicaEsporta)
      Me.RibbonGroup2.DialogLauncherButtonVisible = False
      Me.RibbonGroup2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup2.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup2.Name = "RibbonGroup2"
      Me.RibbonGroup2.Size = New System.Drawing.Size(106, 0)
      Me.RibbonGroup2.TabIndex = 1
      Me.RibbonGroup2.Text = "Importa/Esporta"
      '
      'eui_cmdAmicaImporta
      '
      Me.eui_cmdAmicaImporta.Id = "c4696f2f-7544-413f-b3d4-179ed53b4dd1"
      Me.eui_cmdAmicaImporta.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdAmicaImporta.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdAmicaImporta.Location = New System.Drawing.Point(20, 2)
      Me.eui_cmdAmicaImporta.Name = "eui_cmdAmicaImporta"
      Me.eui_cmdAmicaImporta.ScreenTip.Caption = "Importa dati"
      Me.eui_cmdAmicaImporta.ScreenTip.Text = "Apre la finestra per l'importazione dei dati dal gestionale Amica."
      Me.eui_cmdAmicaImporta.Size = New System.Drawing.Size(64, 0)
      Me.eui_cmdAmicaImporta.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdAmicaImporta.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdAmicaImporta.TabIndex = 1
      Me.eui_cmdAmicaImporta.Text = "Importa dati"
      '
      'eui_cmdAmicaEsporta
      '
      Me.eui_cmdAmicaEsporta.Id = "7f8ed827-330c-402b-8a5e-977bec675ee7"
      Me.eui_cmdAmicaEsporta.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdAmicaEsporta.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdAmicaEsporta.Location = New System.Drawing.Point(20, 2)
      Me.eui_cmdAmicaEsporta.Name = "eui_cmdAmicaEsporta"
      Me.eui_cmdAmicaEsporta.ScreenTip.Caption = "Esporta dati"
      Me.eui_cmdAmicaEsporta.ScreenTip.Text = "Apre la finestra per l'esportazione dei dati nel gestionale Amica."
      Me.eui_cmdAmicaEsporta.Size = New System.Drawing.Size(65, 0)
      Me.eui_cmdAmicaEsporta.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdAmicaEsporta.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdAmicaEsporta.TabIndex = 0
      Me.eui_cmdAmicaEsporta.Text = "Esporta dati"
      '
      'rtgPlanningCamere
      '
      Me.rtgPlanningCamere.Caption = "Planning Camere"
      Me.rtgPlanningCamere.TabPages.AddRange(New Elegant.Ui.RibbonTabPage() {Me.eui_PCamere_Prenotazioni, Me.eui_PCamere_Visualizza})
      Me.rtgPlanningCamere.Visible = False
      '
      'eui_PCamere_Prenotazioni
      '
      Me.eui_PCamere_Prenotazioni.Controls.Add(Me.RibbonGroup13)
      Me.eui_PCamere_Prenotazioni.Controls.Add(Me.RibbonGroup3)
      Me.eui_PCamere_Prenotazioni.Controls.Add(Me.RibbonGroup4)
      Me.eui_PCamere_Prenotazioni.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_PCamere_Prenotazioni.KeyTip = Nothing
      Me.eui_PCamere_Prenotazioni.Location = New System.Drawing.Point(0, 0)
      Me.eui_PCamere_Prenotazioni.Name = "eui_PCamere_Prenotazioni"
      Me.eui_PCamere_Prenotazioni.Size = New System.Drawing.Size(1333, 99)
      Me.eui_PCamere_Prenotazioni.TabIndex = 0
      Me.eui_PCamere_Prenotazioni.Text = "Prenotazioni"
      '
      'RibbonGroup13
      '
      Me.RibbonGroup13.Controls.Add(Me.eui_PCamere_PrenNuova)
      Me.RibbonGroup13.Controls.Add(Me.eui_PCamere_PrenModifica)
      Me.RibbonGroup13.Controls.Add(Me.eui_PCamere_PrenElimina)
      Me.RibbonGroup13.Controls.Add(Me.eui_PCamere_PrenAnnulla)
      Me.RibbonGroup13.Controls.Add(Me.Separator19)
      Me.RibbonGroup13.Controls.Add(Me.eui_PCamere_PrenAggiorna)
      Me.RibbonGroup13.Controls.Add(Me.Separator5)
      Me.RibbonGroup13.Controls.Add(Me.eui_PCamere_PrenElencoCamere)
      Me.RibbonGroup13.DialogLauncherButtonVisible = False
      Me.RibbonGroup13.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup13.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup13.Name = "RibbonGroup13"
      Me.RibbonGroup13.Size = New System.Drawing.Size(336, 94)
      Me.RibbonGroup13.TabIndex = 0
      Me.RibbonGroup13.Text = "Prenotazioni"
      '
      'eui_PCamere_PrenNuova
      '
      Me.eui_PCamere_PrenNuova.Id = "4f5ffd8e-11f1-45e2-8a7b-d448771151ea"
      Me.eui_PCamere_PrenNuova.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenNuova.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenNuova.Location = New System.Drawing.Point(87, 2)
      Me.eui_PCamere_PrenNuova.Name = "eui_PCamere_PrenNuova"
      Me.eui_PCamere_PrenNuova.ScreenTip.Caption = "Nuova"
      Me.eui_PCamere_PrenNuova.ScreenTip.Text = "Apre la finestra per l'inserimento dei dati di una nuova prenotazione."
      Me.eui_PCamere_PrenNuova.Size = New System.Drawing.Size(41, 0)
      Me.eui_PCamere_PrenNuova.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenNuova.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenNuova.TabIndex = 0
      Me.eui_PCamere_PrenNuova.Text = "Nuova"
      '
      'eui_PCamere_PrenModifica
      '
      Me.eui_PCamere_PrenModifica.Id = "146f175d-1704-43f5-8b47-ac8b845f926b"
      Me.eui_PCamere_PrenModifica.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenModifica.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenModifica.Location = New System.Drawing.Point(87, 2)
      Me.eui_PCamere_PrenModifica.Name = "eui_PCamere_PrenModifica"
      Me.eui_PCamere_PrenModifica.ScreenTip.Caption = "Modifica"
      Me.eui_PCamere_PrenModifica.ScreenTip.Text = "Apre la finestra per la modifica dei dati di una prenotazione."
      Me.eui_PCamere_PrenModifica.Size = New System.Drawing.Size(49, 0)
      Me.eui_PCamere_PrenModifica.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenModifica.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenModifica.TabIndex = 7
      Me.eui_PCamere_PrenModifica.Text = "Modifica"
      '
      'eui_PCamere_PrenElimina
      '
      Me.eui_PCamere_PrenElimina.Id = "403ae566-6647-4ca1-92f2-8cc53f819c21"
      Me.eui_PCamere_PrenElimina.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenElimina.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenElimina.Location = New System.Drawing.Point(87, 2)
      Me.eui_PCamere_PrenElimina.Name = "eui_PCamere_PrenElimina"
      Me.eui_PCamere_PrenElimina.ScreenTip.Caption = "Elimina"
      Me.eui_PCamere_PrenElimina.ScreenTip.Text = "Elimina i dati della prenotazione selezionata."
      Me.eui_PCamere_PrenElimina.Size = New System.Drawing.Size(42, 0)
      Me.eui_PCamere_PrenElimina.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenElimina.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenElimina.TabIndex = 1
      Me.eui_PCamere_PrenElimina.Text = "Elimina"
      '
      'eui_PCamere_PrenAnnulla
      '
      Me.eui_PCamere_PrenAnnulla.Id = "05583a73-f639-4c62-8580-ee8fe47dd0d1"
      Me.eui_PCamere_PrenAnnulla.KeyTip = "U"
      Me.eui_PCamere_PrenAnnulla.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenAnnulla.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenAnnulla.Location = New System.Drawing.Point(87, 2)
      Me.eui_PCamere_PrenAnnulla.Name = "eui_PCamere_PrenAnnulla"
      Me.eui_PCamere_PrenAnnulla.ScreenTip.Caption = "Annulla "
      Me.eui_PCamere_PrenAnnulla.ScreenTip.Text = "Annulla la prenotazione selezionata."
      Me.eui_PCamere_PrenAnnulla.Size = New System.Drawing.Size(44, 0)
      Me.eui_PCamere_PrenAnnulla.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenAnnulla.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenAnnulla.TabIndex = 8
      Me.eui_PCamere_PrenAnnulla.Text = "Annulla"
      '
      'Separator19
      '
      Me.Separator19.Id = "01947619-ff31-404d-a008-6a27351044c5"
      Me.Separator19.Location = New System.Drawing.Point(88, 6)
      Me.Separator19.Name = "Separator19"
      Me.Separator19.Size = New System.Drawing.Size(3, 61)
      Me.Separator19.TabIndex = 6
      Me.Separator19.Text = "Separator19"
      '
      'eui_PCamere_PrenAggiorna
      '
      Me.eui_PCamere_PrenAggiorna.Id = "15da7ec0-94d5-4618-85bd-0dfaa2fe696c"
      Me.eui_PCamere_PrenAggiorna.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenAggiorna.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenAggiorna.Location = New System.Drawing.Point(87, 74)
      Me.eui_PCamere_PrenAggiorna.Name = "eui_PCamere_PrenAggiorna"
      Me.eui_PCamere_PrenAggiorna.ScreenTip.Caption = "Aggiorna"
      Me.eui_PCamere_PrenAggiorna.ScreenTip.Text = "Aggiorna l'elenco con eventuali nuove prenotazioni. "
      Me.eui_PCamere_PrenAggiorna.Size = New System.Drawing.Size(51, 0)
      Me.eui_PCamere_PrenAggiorna.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenAggiorna.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenAggiorna.TabIndex = 5
      Me.eui_PCamere_PrenAggiorna.Text = "Aggiorna"
      '
      'Separator5
      '
      Me.Separator5.Id = "7d00ee35-f748-4560-a866-97722e4dbec7"
      Me.Separator5.Location = New System.Drawing.Point(141, 6)
      Me.Separator5.Name = "Separator5"
      Me.Separator5.Size = New System.Drawing.Size(3, 61)
      Me.Separator5.TabIndex = 2
      Me.Separator5.Text = "Separator5"
      '
      'eui_PCamere_PrenElencoCamere
      '
      Me.eui_PCamere_PrenElencoCamere.Id = "0006492e-5487-434c-a764-dc30565fc195"
      Me.eui_PCamere_PrenElencoCamere.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", Global.Hospitality_Solution.My.Resources.Resources.NewContentPage_32x32)})
      Me.eui_PCamere_PrenElencoCamere.Location = New System.Drawing.Point(140, 74)
      Me.eui_PCamere_PrenElencoCamere.Name = "eui_PCamere_PrenElencoCamere"
      Me.eui_PCamere_PrenElencoCamere.ScreenTip.Caption = "Elenco prenotazioni camere"
      Me.eui_PCamere_PrenElencoCamere.ScreenTip.Text = "Apre la finestra Elenco prenotazioni camere."
      Me.eui_PCamere_PrenElencoCamere.Size = New System.Drawing.Size(107, 0)
      Me.eui_PCamere_PrenElencoCamere.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", Global.Hospitality_Solution.My.Resources.Resources.NewContentPage_32x32)})
      Me.eui_PCamere_PrenElencoCamere.TabIndex = 3
      Me.eui_PCamere_PrenElencoCamere.Text = "Elenco pren. camere"
      '
      'RibbonGroup3
      '
      Me.RibbonGroup3.Controls.Add(Me.eui_PCamere_PrenListini)
      Me.RibbonGroup3.Controls.Add(Me.eui_PCamere_PrenStagioni)
      Me.RibbonGroup3.Controls.Add(Me.Separator6)
      Me.RibbonGroup3.Controls.Add(Me.eui_PCamere_PrenCamere)
      Me.RibbonGroup3.Controls.Add(Me.eui_PCamere_PrenClienti)
      Me.RibbonGroup3.DialogLauncherButtonVisible = False
      Me.RibbonGroup3.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup3.Location = New System.Drawing.Point(341, 1)
      Me.RibbonGroup3.Name = "RibbonGroup3"
      Me.RibbonGroup3.Size = New System.Drawing.Size(196, 94)
      Me.RibbonGroup3.TabIndex = 1
      Me.RibbonGroup3.Text = "Archivi"
      '
      'eui_PCamere_PrenListini
      '
      Me.eui_PCamere_PrenListini.Id = "d7eaaeae-b2a3-453d-82d8-42df893473b7"
      Me.eui_PCamere_PrenListini.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenListini.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenListini.Location = New System.Drawing.Point(57, 2)
      Me.eui_PCamere_PrenListini.Name = "eui_PCamere_PrenListini"
      Me.eui_PCamere_PrenListini.ScreenTip.Caption = "Listini"
      Me.eui_PCamere_PrenListini.ScreenTip.Text = "Apre la finestra Listini."
      Me.eui_PCamere_PrenListini.Size = New System.Drawing.Size(35, 0)
      Me.eui_PCamere_PrenListini.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenListini.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenListini.TabIndex = 0
      Me.eui_PCamere_PrenListini.Text = "Listini"
      '
      'eui_PCamere_PrenStagioni
      '
      Me.eui_PCamere_PrenStagioni.Id = "728c7270-e804-4e64-be60-208b7bd5dd18"
      Me.eui_PCamere_PrenStagioni.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenStagioni.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenStagioni.Location = New System.Drawing.Point(57, 2)
      Me.eui_PCamere_PrenStagioni.Name = "eui_PCamere_PrenStagioni"
      Me.eui_PCamere_PrenStagioni.ScreenTip.Caption = "Stagioni"
      Me.eui_PCamere_PrenStagioni.ScreenTip.Text = "Apre la finestra Stagioni."
      Me.eui_PCamere_PrenStagioni.Size = New System.Drawing.Size(47, 0)
      Me.eui_PCamere_PrenStagioni.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenStagioni.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenStagioni.TabIndex = 1
      Me.eui_PCamere_PrenStagioni.Text = "Stagioni"
      '
      'Separator6
      '
      Me.Separator6.Id = "520f566d-3b09-4e21-9c2a-3e5339b95f7a"
      Me.Separator6.Location = New System.Drawing.Point(58, 6)
      Me.Separator6.Name = "Separator6"
      Me.Separator6.Size = New System.Drawing.Size(3, 61)
      Me.Separator6.TabIndex = 2
      Me.Separator6.Text = "Separator6"
      '
      'eui_PCamere_PrenCamere
      '
      Me.eui_PCamere_PrenCamere.Id = "15b09ce6-9660-4e90-a29f-af38e05662ba"
      Me.eui_PCamere_PrenCamere.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenCamere.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenCamere.Location = New System.Drawing.Point(57, 74)
      Me.eui_PCamere_PrenCamere.Name = "eui_PCamere_PrenCamere"
      Me.eui_PCamere_PrenCamere.ScreenTip.Caption = "Elenco camere"
      Me.eui_PCamere_PrenCamere.ScreenTip.Text = "Apre la finestra Elenco Camere."
      Me.eui_PCamere_PrenCamere.Size = New System.Drawing.Size(80, 0)
      Me.eui_PCamere_PrenCamere.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenCamere.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenCamere.TabIndex = 3
      Me.eui_PCamere_PrenCamere.Text = "Elenco camere"
      '
      'eui_PCamere_PrenClienti
      '
      Me.eui_PCamere_PrenClienti.Id = "b2873928-94d5-41d5-924f-c1cc799d0a25"
      Me.eui_PCamere_PrenClienti.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenClienti.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenClienti.Location = New System.Drawing.Point(57, 74)
      Me.eui_PCamere_PrenClienti.Name = "eui_PCamere_PrenClienti"
      Me.eui_PCamere_PrenClienti.ScreenTip.Caption = "Elenco clienti"
      Me.eui_PCamere_PrenClienti.ScreenTip.Text = "Apre la finestra Elenco Clienti."
      Me.eui_PCamere_PrenClienti.Size = New System.Drawing.Size(72, 0)
      Me.eui_PCamere_PrenClienti.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenClienti.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenClienti.TabIndex = 4
      Me.eui_PCamere_PrenClienti.Text = "Elenco clienti"
      '
      'RibbonGroup4
      '
      Me.RibbonGroup4.Controls.Add(Me.eui_PCamere_PrenIstat)
      Me.RibbonGroup4.Controls.Add(Me.eui_PCamere_PrenSchedina)
      Me.RibbonGroup4.DialogLauncherButtonVisible = False
      Me.RibbonGroup4.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup4.Location = New System.Drawing.Point(537, 1)
      Me.RibbonGroup4.Name = "RibbonGroup4"
      Me.RibbonGroup4.Size = New System.Drawing.Size(117, 94)
      Me.RibbonGroup4.TabIndex = 2
      Me.RibbonGroup4.Text = "Documenti"
      '
      'eui_PCamere_PrenIstat
      '
      Me.eui_PCamere_PrenIstat.Id = "00c43a66-311d-4bdc-a0b1-a3f889630c99"
      Me.eui_PCamere_PrenIstat.KeyTip = "MI"
      Me.eui_PCamere_PrenIstat.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenIstat.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenIstat.Location = New System.Drawing.Point(10, 2)
      Me.eui_PCamere_PrenIstat.Name = "eui_PCamere_PrenIstat"
      Me.eui_PCamere_PrenIstat.ScreenTip.Caption = "Modello Istat C/59"
      Me.eui_PCamere_PrenIstat.ScreenTip.Text = "Genera il modello Istat C/59 per la stampa."
      Me.eui_PCamere_PrenIstat.Size = New System.Drawing.Size(96, 0)
      Me.eui_PCamere_PrenIstat.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenIstat.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenIstat.TabIndex = 0
      Me.eui_PCamere_PrenIstat.Text = "Modello Istat C/59"
      '
      'eui_PCamere_PrenSchedina
      '
      Me.eui_PCamere_PrenSchedina.Id = "93036274-e320-464c-b007-042c9ee1a852"
      Me.eui_PCamere_PrenSchedina.KeyTip = "SP"
      Me.eui_PCamere_PrenSchedina.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenSchedina.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenSchedina.Location = New System.Drawing.Point(10, 2)
      Me.eui_PCamere_PrenSchedina.Name = "eui_PCamere_PrenSchedina"
      Me.eui_PCamere_PrenSchedina.ScreenTip.Caption = "Schedina P. S."
      Me.eui_PCamere_PrenSchedina.ScreenTip.Text = "Genera la Schedina di Pubblica Sicurezza per la stampa."
      Me.eui_PCamere_PrenSchedina.Size = New System.Drawing.Size(77, 0)
      Me.eui_PCamere_PrenSchedina.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_PrenSchedina.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_PrenSchedina.TabIndex = 6
      Me.eui_PCamere_PrenSchedina.Text = "Schedina P.S."
      '
      'eui_PCamere_Visualizza
      '
      Me.eui_PCamere_Visualizza.Controls.Add(Me.RibbonGroup23)
      Me.eui_PCamere_Visualizza.Controls.Add(Me.RibbonGroup24)
      Me.eui_PCamere_Visualizza.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_PCamere_Visualizza.KeyTip = Nothing
      Me.eui_PCamere_Visualizza.Location = New System.Drawing.Point(0, 0)
      Me.eui_PCamere_Visualizza.Name = "eui_PCamere_Visualizza"
      Me.eui_PCamere_Visualizza.Size = New System.Drawing.Size(1276, 99)
      Me.eui_PCamere_Visualizza.TabIndex = 0
      Me.eui_PCamere_Visualizza.Text = "Visualizza"
      '
      'RibbonGroup23
      '
      Me.RibbonGroup23.Controls.Add(Me.eui_PCamere_VisIndieto)
      Me.RibbonGroup23.Controls.Add(Me.eui_PCamere_VisAvanti)
      Me.RibbonGroup23.Controls.Add(Me.Separator12)
      Me.RibbonGroup23.Controls.Add(Me.eui_PCamere_VisSu)
      Me.RibbonGroup23.Controls.Add(Me.eui_PCamere_VisGiù)
      Me.RibbonGroup23.DialogLauncherButtonVisible = False
      Me.RibbonGroup23.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup23.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup23.Name = "RibbonGroup23"
      Me.RibbonGroup23.Size = New System.Drawing.Size(193, 0)
      Me.RibbonGroup23.TabIndex = 0
      Me.RibbonGroup23.Text = "Movimento"
      '
      'eui_PCamere_VisIndieto
      '
      Me.eui_PCamere_VisIndieto.Id = "1c757c9c-4acc-4d70-910e-a99f21817fa7"
      Me.eui_PCamere_VisIndieto.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisIndieto.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisIndieto.Location = New System.Drawing.Point(74, 2)
      Me.eui_PCamere_VisIndieto.Name = "eui_PCamere_VisIndieto"
      Me.eui_PCamere_VisIndieto.ScreenTip.Caption = "Indietro"
      Me.eui_PCamere_VisIndieto.ScreenTip.Text = "Scorre la griglia indietro di un giorno."
      Me.eui_PCamere_VisIndieto.Size = New System.Drawing.Size(44, 0)
      Me.eui_PCamere_VisIndieto.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisIndieto.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisIndieto.TabIndex = 0
      Me.eui_PCamere_VisIndieto.Text = "Indietro"
      '
      'eui_PCamere_VisAvanti
      '
      Me.eui_PCamere_VisAvanti.Id = "ee707384-c3f9-4472-9b8d-a3648a2a8513"
      Me.eui_PCamere_VisAvanti.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisAvanti.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisAvanti.Location = New System.Drawing.Point(74, 2)
      Me.eui_PCamere_VisAvanti.Name = "eui_PCamere_VisAvanti"
      Me.eui_PCamere_VisAvanti.ScreenTip.Caption = "Avanti"
      Me.eui_PCamere_VisAvanti.ScreenTip.Text = "Scorre la griglia avanti di un giorno."
      Me.eui_PCamere_VisAvanti.Size = New System.Drawing.Size(39, 0)
      Me.eui_PCamere_VisAvanti.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisAvanti.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisAvanti.TabIndex = 1
      Me.eui_PCamere_VisAvanti.Text = "Avanti"
      '
      'Separator12
      '
      Me.Separator12.Id = "8f0c343d-6148-46c4-8cbf-c09598bdfbe6"
      Me.Separator12.Location = New System.Drawing.Point(75, 6)
      Me.Separator12.Name = "Separator12"
      Me.Separator12.Size = New System.Drawing.Size(3, -11)
      Me.Separator12.TabIndex = 2
      Me.Separator12.Text = "Separator12"
      '
      'eui_PCamere_VisSu
      '
      Me.eui_PCamere_VisSu.Id = "de3bcd86-4de3-4002-b9eb-089101ecfae8"
      Me.eui_PCamere_VisSu.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisSu.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisSu.Location = New System.Drawing.Point(74, 2)
      Me.eui_PCamere_VisSu.Name = "eui_PCamere_VisSu"
      Me.eui_PCamere_VisSu.ScreenTip.Caption = "Su"
      Me.eui_PCamere_VisSu.ScreenTip.Text = "Scorre la griglia verso l'alto."
      Me.eui_PCamere_VisSu.Size = New System.Drawing.Size(22, 0)
      Me.eui_PCamere_VisSu.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisSu.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisSu.TabIndex = 2
      Me.eui_PCamere_VisSu.Text = "Su"
      '
      'eui_PCamere_VisGiù
      '
      Me.eui_PCamere_VisGiù.Id = "3cd61c7b-b245-4182-b3eb-fa9fa78b5ad8"
      Me.eui_PCamere_VisGiù.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisGiù.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisGiù.Location = New System.Drawing.Point(74, 2)
      Me.eui_PCamere_VisGiù.Name = "eui_PCamere_VisGiù"
      Me.eui_PCamere_VisGiù.ScreenTip.Caption = "Giù"
      Me.eui_PCamere_VisGiù.ScreenTip.Text = "Scorre la griglia verso il basso."
      Me.eui_PCamere_VisGiù.Size = New System.Drawing.Size(25, 0)
      Me.eui_PCamere_VisGiù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisGiù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisGiù.TabIndex = 3
      Me.eui_PCamere_VisGiù.Text = "Giù"
      '
      'RibbonGroup24
      '
      Me.RibbonGroup24.Controls.Add(Me.eui_PCamere_VisOggi)
      Me.RibbonGroup24.Controls.Add(Me.Separator2)
      Me.RibbonGroup24.Controls.Add(Me.eui_PCamere_VisAnnoIndietro)
      Me.RibbonGroup24.Controls.Add(Me.eui_PCamere_VisAnnoAvanti)
      Me.RibbonGroup24.Controls.Add(Me.Separator13)
      Me.RibbonGroup24.Controls.Add(Me.eui_PCamere_VisMeseIndietro)
      Me.RibbonGroup24.Controls.Add(Me.eui_PCamere_VisMeseAvanti)
      Me.RibbonGroup24.Controls.Add(Me.Separator14)
      Me.RibbonGroup24.Controls.Add(Me.eui_PCamere_VisGiorniMeno)
      Me.RibbonGroup24.Controls.Add(Me.eui_PCamere_VisGiorniPiù)
      Me.RibbonGroup24.DialogLauncherButtonVisible = False
      Me.RibbonGroup24.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup24.Location = New System.Drawing.Point(198, 1)
      Me.RibbonGroup24.Name = "RibbonGroup24"
      Me.RibbonGroup24.Size = New System.Drawing.Size(387, 0)
      Me.RibbonGroup24.TabIndex = 1
      Me.RibbonGroup24.Text = "Periodo"
      '
      'eui_PCamere_VisOggi
      '
      Me.eui_PCamere_VisOggi.Id = "228a6f2c-300d-4bf9-8f72-88e8dd785843"
      Me.eui_PCamere_VisOggi.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisOggi.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisOggi.Location = New System.Drawing.Point(146, 2)
      Me.eui_PCamere_VisOggi.Name = "eui_PCamere_VisOggi"
      Me.eui_PCamere_VisOggi.ScreenTip.Caption = "Oggi"
      Me.eui_PCamere_VisOggi.ScreenTip.Text = "Scorre la griglia al giorno corrente."
      Me.eui_PCamere_VisOggi.Size = New System.Drawing.Size(31, 0)
      Me.eui_PCamere_VisOggi.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisOggi.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisOggi.TabIndex = 0
      Me.eui_PCamere_VisOggi.Text = "Oggi"
      '
      'Separator2
      '
      Me.Separator2.Id = "0ec20f16-4126-4c98-8cf1-90aa6dcb4636"
      Me.Separator2.Location = New System.Drawing.Point(147, 6)
      Me.Separator2.Name = "Separator2"
      Me.Separator2.Size = New System.Drawing.Size(3, -11)
      Me.Separator2.TabIndex = 2
      Me.Separator2.Text = "Separator2"
      '
      'eui_PCamere_VisAnnoIndietro
      '
      Me.eui_PCamere_VisAnnoIndietro.Id = "6c3dc5ea-0d88-4eef-b6b8-ea46fa44241f"
      Me.eui_PCamere_VisAnnoIndietro.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisAnnoIndietro.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisAnnoIndietro.Location = New System.Drawing.Point(146, 2)
      Me.eui_PCamere_VisAnnoIndietro.Name = "eui_PCamere_VisAnnoIndietro"
      Me.eui_PCamere_VisAnnoIndietro.ScreenTip.Caption = "Indietro di 1 Anno"
      Me.eui_PCamere_VisAnnoIndietro.ScreenTip.Text = "Scorre la griglia indietro di un Anno."
      Me.eui_PCamere_VisAnnoIndietro.Size = New System.Drawing.Size(92, 0)
      Me.eui_PCamere_VisAnnoIndietro.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisAnnoIndietro.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisAnnoIndietro.TabIndex = 1
      Me.eui_PCamere_VisAnnoIndietro.Text = "Indietro di 1 Anno"
      '
      'eui_PCamere_VisAnnoAvanti
      '
      Me.eui_PCamere_VisAnnoAvanti.Id = "b37941e1-caef-4d85-85f4-ab38f376e3ef"
      Me.eui_PCamere_VisAnnoAvanti.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisAnnoAvanti.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisAnnoAvanti.Location = New System.Drawing.Point(146, 2)
      Me.eui_PCamere_VisAnnoAvanti.Name = "eui_PCamere_VisAnnoAvanti"
      Me.eui_PCamere_VisAnnoAvanti.ScreenTip.Caption = "Avanti di 1 Anno"
      Me.eui_PCamere_VisAnnoAvanti.ScreenTip.Text = "Scorre la griglia avanti di un Anno."
      Me.eui_PCamere_VisAnnoAvanti.Size = New System.Drawing.Size(87, 0)
      Me.eui_PCamere_VisAnnoAvanti.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisAnnoAvanti.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisAnnoAvanti.TabIndex = 3
      Me.eui_PCamere_VisAnnoAvanti.Text = "Avanti di 1 Anno"
      '
      'Separator13
      '
      Me.Separator13.Id = "384c08a9-2f1f-47b1-8192-9ec0de32912f"
      Me.Separator13.Location = New System.Drawing.Point(147, 6)
      Me.Separator13.Name = "Separator13"
      Me.Separator13.Size = New System.Drawing.Size(3, -11)
      Me.Separator13.TabIndex = 2
      Me.Separator13.Text = "Separator13"
      '
      'eui_PCamere_VisMeseIndietro
      '
      Me.eui_PCamere_VisMeseIndietro.Id = "6443740a-f9e6-4336-9bc1-81156917a6b2"
      Me.eui_PCamere_VisMeseIndietro.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisMeseIndietro.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisMeseIndietro.Location = New System.Drawing.Point(146, 2)
      Me.eui_PCamere_VisMeseIndietro.Name = "eui_PCamere_VisMeseIndietro"
      Me.eui_PCamere_VisMeseIndietro.ScreenTip.Caption = "Indietro di 1 Mese"
      Me.eui_PCamere_VisMeseIndietro.ScreenTip.Text = "Scorre la griglia indietro di un Mese."
      Me.eui_PCamere_VisMeseIndietro.Size = New System.Drawing.Size(93, 0)
      Me.eui_PCamere_VisMeseIndietro.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisMeseIndietro.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisMeseIndietro.TabIndex = 4
      Me.eui_PCamere_VisMeseIndietro.Text = "Indietro di 1 Mese"
      '
      'eui_PCamere_VisMeseAvanti
      '
      Me.eui_PCamere_VisMeseAvanti.Id = "a07fa684-49f9-4e71-a481-721aaedd6c51"
      Me.eui_PCamere_VisMeseAvanti.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisMeseAvanti.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisMeseAvanti.Location = New System.Drawing.Point(146, 2)
      Me.eui_PCamere_VisMeseAvanti.Name = "eui_PCamere_VisMeseAvanti"
      Me.eui_PCamere_VisMeseAvanti.ScreenTip.Caption = "Avanti di 1 Mese"
      Me.eui_PCamere_VisMeseAvanti.ScreenTip.Text = "Scorre la griglia avanti di un Mese."
      Me.eui_PCamere_VisMeseAvanti.Size = New System.Drawing.Size(88, 0)
      Me.eui_PCamere_VisMeseAvanti.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisMeseAvanti.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisMeseAvanti.TabIndex = 5
      Me.eui_PCamere_VisMeseAvanti.Text = "Avanti di 1 Mese"
      '
      'Separator14
      '
      Me.Separator14.Id = "e627ef79-b7b2-4d52-bcc3-e75307efc5a4"
      Me.Separator14.Location = New System.Drawing.Point(147, 6)
      Me.Separator14.Name = "Separator14"
      Me.Separator14.Size = New System.Drawing.Size(3, -11)
      Me.Separator14.TabIndex = 5
      Me.Separator14.Text = "Separator14"
      Me.Separator14.Visible = False
      '
      'eui_PCamere_VisGiorniMeno
      '
      Me.eui_PCamere_VisGiorniMeno.Id = "c8f23e76-9431-4a15-a34a-ed4e09f758ca"
      Me.eui_PCamere_VisGiorniMeno.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisGiorniMeno.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisGiorniMeno.Location = New System.Drawing.Point(146, 2)
      Me.eui_PCamere_VisGiorniMeno.Name = "eui_PCamere_VisGiorniMeno"
      Me.eui_PCamere_VisGiorniMeno.ScreenTip.Caption = "Meno 15 Giorni"
      Me.eui_PCamere_VisGiorniMeno.ScreenTip.Text = "Scorre la griglia indietro di quindici Giorni."
      Me.eui_PCamere_VisGiorniMeno.Size = New System.Drawing.Size(81, 0)
      Me.eui_PCamere_VisGiorniMeno.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisGiorniMeno.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisGiorniMeno.TabIndex = 6
      Me.eui_PCamere_VisGiorniMeno.Text = "Meno 15 Giorni"
      Me.eui_PCamere_VisGiorniMeno.Visible = False
      '
      'eui_PCamere_VisGiorniPiù
      '
      Me.eui_PCamere_VisGiorniPiù.Id = "0894fe18-fd6f-4f58-ac2e-66db5e2f0c80"
      Me.eui_PCamere_VisGiorniPiù.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisGiorniPiù.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisGiorniPiù.Location = New System.Drawing.Point(146, 2)
      Me.eui_PCamere_VisGiorniPiù.Name = "eui_PCamere_VisGiorniPiù"
      Me.eui_PCamere_VisGiorniPiù.ScreenTip.Caption = "Più 15 Giorni"
      Me.eui_PCamere_VisGiorniPiù.ScreenTip.Text = "Scorre la griglia avanti di quindici Giorni."
      Me.eui_PCamere_VisGiorniPiù.Size = New System.Drawing.Size(69, 0)
      Me.eui_PCamere_VisGiorniPiù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_PCamere_VisGiorniPiù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_PCamere_VisGiorniPiù.TabIndex = 7
      Me.eui_PCamere_VisGiorniPiù.Text = "Più 15 Giorni"
      Me.eui_PCamere_VisGiorniPiù.Visible = False
      '
      'eui_Gestione
      '
      Me.eui_Gestione.Controls.Add(Me.eui_GruppoPos)
      Me.eui_Gestione.Controls.Add(Me.eui_GruppoPrenotazioni)
      Me.eui_Gestione.Controls.Add(Me.RibbonGroup15)
      Me.eui_Gestione.Controls.Add(Me.RibbonGroup16)
      Me.eui_Gestione.Controls.Add(Me.RibbonGroup30)
      Me.eui_Gestione.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_Gestione.KeyTip = "G"
      Me.eui_Gestione.Location = New System.Drawing.Point(0, 0)
      Me.eui_Gestione.Name = "eui_Gestione"
      Me.eui_Gestione.Size = New System.Drawing.Size(1469, 99)
      Me.eui_Gestione.TabIndex = 0
      Me.eui_Gestione.Text = "Gestione"
      '
      'eui_GruppoPos
      '
      Me.eui_GruppoPos.Controls.Add(Me.eui_cmdGestionePosCassa)
      Me.eui_GruppoPos.Controls.Add(Me.eui_cmdGestionePosTavoli)
      Me.eui_GruppoPos.DialogLauncherButtonVisible = False
      Me.eui_GruppoPos.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_GruppoPos.Location = New System.Drawing.Point(5, 1)
      Me.eui_GruppoPos.Name = "eui_GruppoPos"
      Me.eui_GruppoPos.Size = New System.Drawing.Size(97, 94)
      Me.eui_GruppoPos.TabIndex = 0
      Me.eui_GruppoPos.Text = "Pos"
      '
      'eui_cmdGestionePosTavoli
      '
      Me.eui_cmdGestionePosTavoli.Id = "b33f0d84-1a2a-4e9f-8868-227a991f1bae"
      Me.eui_cmdGestionePosTavoli.KeyTip = "T"
      Me.eui_cmdGestionePosTavoli.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestionePosTavoli.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestionePosTavoli.Location = New System.Drawing.Point(48, 2)
      Me.eui_cmdGestionePosTavoli.Name = "eui_cmdGestionePosTavoli"
      Me.eui_cmdGestionePosTavoli.ScreenTip.Caption = "Tavoli e conto (F3)"
      Me.eui_cmdGestionePosTavoli.ScreenTip.Text = "Apre la gestione dei Tavoli per l'inserimento delle comande."
      Me.eui_GruppoPos.SetShortcutKeys(Me.eui_cmdGestionePosTavoli, System.Windows.Forms.Keys.F3)
      Me.eui_cmdGestionePosTavoli.Size = New System.Drawing.Size(44, 72)
      Me.eui_cmdGestionePosTavoli.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestionePosTavoli.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestionePosTavoli.TabIndex = 1
      Me.eui_cmdGestionePosTavoli.Text = "Tavoli e conto"
      '
      'eui_GruppoPrenotazioni
      '
      Me.eui_GruppoPrenotazioni.Controls.Add(Me.eui_ddwnGestioneQuadroGiornaliero)
      Me.eui_GruppoPrenotazioni.Controls.Add(Me.eui_ddwnGestionePlanningRisorse)
      Me.eui_GruppoPrenotazioni.Controls.Add(Me.eui_ddwnGestionePrenotazioni)
      Me.eui_GruppoPrenotazioni.DialogLauncherButtonVisible = False
      Me.eui_GruppoPrenotazioni.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_GruppoPrenotazioni.Location = New System.Drawing.Point(102, 1)
      Me.eui_GruppoPrenotazioni.Name = "eui_GruppoPrenotazioni"
      Me.eui_GruppoPrenotazioni.Size = New System.Drawing.Size(217, 94)
      Me.eui_GruppoPrenotazioni.TabIndex = 1
      Me.eui_GruppoPrenotazioni.Text = "Prenotazioni"
      '
      'eui_ddwnGestioneQuadroGiornaliero
      '
      Me.eui_ddwnGestioneQuadroGiornaliero.Id = "ac15bf3c-d7fa-400e-ab21-5f65e6ce572d"
      Me.eui_ddwnGestioneQuadroGiornaliero.KeyTip = "Q"
      Me.eui_ddwnGestioneQuadroGiornaliero.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ddwnGestioneQuadroGiornaliero.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_ddwnGestioneQuadroGiornaliero.Location = New System.Drawing.Point(4, 2)
      Me.eui_ddwnGestioneQuadroGiornaliero.Name = "eui_ddwnGestioneQuadroGiornaliero"
      Me.eui_ddwnGestioneQuadroGiornaliero.Size = New System.Drawing.Size(71, 72)
      Me.eui_ddwnGestioneQuadroGiornaliero.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ddwnGestioneQuadroGiornaliero.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_ddwnGestioneQuadroGiornaliero.TabIndex = 2
      Me.eui_ddwnGestioneQuadroGiornaliero.Text = "Quadro giornaliero"
      Me.eui_ddwnGestioneQuadroGiornaliero.Visible = False
      '
      'eui_ddwnGestionePlanningRisorse
      '
      Me.eui_ddwnGestionePlanningRisorse.Id = "f9eafe92-077d-443d-81f4-2ca05cc46188"
      Me.eui_ddwnGestionePlanningRisorse.KeyTip = "PR"
      Me.eui_ddwnGestionePlanningRisorse.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ddwnGestionePlanningRisorse.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_ddwnGestionePlanningRisorse.Location = New System.Drawing.Point(77, 2)
      Me.eui_ddwnGestionePlanningRisorse.Name = "eui_ddwnGestionePlanningRisorse"
      Me.eui_ddwnGestionePlanningRisorse.Popup = Me.PopupMenu10
      Me.eui_ddwnGestionePlanningRisorse.Size = New System.Drawing.Size(53, 72)
      Me.eui_ddwnGestionePlanningRisorse.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ddwnGestionePlanningRisorse.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_ddwnGestionePlanningRisorse.TabIndex = 0
      Me.eui_ddwnGestionePlanningRisorse.Text = "Planning risorse"
      '
      'PopupMenu10
      '
      Me.PopupMenu10.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdGestionePlanningCamere, Me.sepPlannigCamere, Me.eui_cmdGestionePlanningRisorseSport})
      Me.PopupMenu10.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu10.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu10.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdGestionePlanningCamere
      '
      Me.eui_cmdGestionePlanningCamere.Id = "ee833b79-f1b4-4f76-986a-cc5982602802"
      Me.eui_cmdGestionePlanningCamere.KeyTip = "C"
      Me.eui_cmdGestionePlanningCamere.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdGestionePlanningCamere.Name = "eui_cmdGestionePlanningCamere"
      Me.PopupMenu10.SetShortcutKeys(Me.eui_cmdGestionePlanningCamere, System.Windows.Forms.Keys.F12)
      Me.eui_cmdGestionePlanningCamere.Size = New System.Drawing.Size(165, 23)
      Me.eui_cmdGestionePlanningCamere.TabIndex = 3
      Me.eui_cmdGestionePlanningCamere.Text = "Camere"
      '
      'sepPlannigCamere
      '
      Me.sepPlannigCamere.Id = "2d2ecf80-6f3b-4851-b985-2b8912d46bec"
      Me.sepPlannigCamere.Location = New System.Drawing.Point(2, 25)
      Me.sepPlannigCamere.Name = "sepPlannigCamere"
      Me.sepPlannigCamere.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepPlannigCamere.Size = New System.Drawing.Size(165, 5)
      Me.sepPlannigCamere.TabIndex = 5
      Me.sepPlannigCamere.Text = "Separator9"
      '
      'eui_cmdGestionePlanningRisorseSport
      '
      Me.eui_cmdGestionePlanningRisorseSport.DescriptionText = Nothing
      Me.eui_cmdGestionePlanningRisorseSport.Id = "33d88ca9-3f2c-4b4a-a608-1c8285fa953c"
      Me.eui_cmdGestionePlanningRisorseSport.Location = New System.Drawing.Point(2, 30)
      Me.eui_cmdGestionePlanningRisorseSport.Name = "eui_cmdGestionePlanningRisorseSport"
      Me.eui_cmdGestionePlanningRisorseSport.Popup = Me.PopupMenu12
      Me.eui_cmdGestionePlanningRisorseSport.Size = New System.Drawing.Size(165, 22)
      Me.eui_cmdGestionePlanningRisorseSport.TabIndex = 8
      Me.eui_cmdGestionePlanningRisorseSport.Text = "Risorse sportive"
      '
      'PopupMenu12
      '
      Me.PopupMenu12.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdGestionePlanningRisorseApriTutti, Me.Separator9, Me.eui_cmdGestionePlanningRisorseSport1, Me.Separator7, Me.eui_cmdGestionePlanningRisorseSport2, Me.eui_cmdGestionePlanningRisorseSport3, Me.eui_cmdGestionePlanningRisorseSport4})
      Me.PopupMenu12.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu12.PlacementMode = Elegant.Ui.PopupPlacementMode.Right
      Me.PopupMenu12.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdGestionePlanningRisorseApriTutti
      '
      Me.eui_cmdGestionePlanningRisorseApriTutti.Id = "c08ecec2-d18e-49bf-8bcc-0665912f5cd9"
      Me.eui_cmdGestionePlanningRisorseApriTutti.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdGestionePlanningRisorseApriTutti.Name = "eui_cmdGestionePlanningRisorseApriTutti"
      Me.PopupMenu12.SetShortcutKeyDisplayString(Me.eui_cmdGestionePlanningRisorseApriTutti, "F5")
      Me.PopupMenu12.SetShortcutKeys(Me.eui_cmdGestionePlanningRisorseApriTutti, System.Windows.Forms.Keys.F5)
      Me.eui_cmdGestionePlanningRisorseApriTutti.Size = New System.Drawing.Size(383, 23)
      Me.eui_cmdGestionePlanningRisorseApriTutti.TabIndex = 13
      Me.eui_cmdGestionePlanningRisorseApriTutti.Text = "Apri tutti i Planning"
      '
      'Separator9
      '
      Me.Separator9.Id = "f5b4834d-db28-4bd2-863c-b81b5cfc4894"
      Me.Separator9.Location = New System.Drawing.Point(2, 25)
      Me.Separator9.Name = "Separator9"
      Me.Separator9.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator9.Size = New System.Drawing.Size(383, 5)
      Me.Separator9.TabIndex = 14
      Me.Separator9.Text = "Separator9"
      '
      'eui_cmdGestionePlanningRisorseSport1
      '
      Me.eui_cmdGestionePlanningRisorseSport1.Id = "59273f1a-1912-4794-b779-8bb83540aef0"
      Me.eui_cmdGestionePlanningRisorseSport1.Location = New System.Drawing.Point(2, 30)
      Me.eui_cmdGestionePlanningRisorseSport1.Name = "eui_cmdGestionePlanningRisorseSport1"
      Me.eui_cmdGestionePlanningRisorseSport1.Size = New System.Drawing.Size(383, 23)
      Me.eui_cmdGestionePlanningRisorseSport1.TabIndex = 3
      Me.eui_cmdGestionePlanningRisorseSport1.Text = "Planning 1 - (Inizio ore: 6:00 - Prenotazione minima mezz'ora)"
      '
      'Separator7
      '
      Me.Separator7.Id = "e29ddd97-bfc6-42fe-96b6-eef266eb68c5"
      Me.Separator7.Location = New System.Drawing.Point(2, 53)
      Me.Separator7.Name = "Separator7"
      Me.Separator7.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator7.Size = New System.Drawing.Size(383, 5)
      Me.Separator7.TabIndex = 11
      Me.Separator7.Text = "Separator7"
      '
      'eui_cmdGestionePlanningRisorseSport2
      '
      Me.eui_cmdGestionePlanningRisorseSport2.Id = "b592172f-bad8-41c4-877a-0dec01924176"
      Me.eui_cmdGestionePlanningRisorseSport2.Location = New System.Drawing.Point(2, 58)
      Me.eui_cmdGestionePlanningRisorseSport2.Name = "eui_cmdGestionePlanningRisorseSport2"
      Me.eui_cmdGestionePlanningRisorseSport2.Size = New System.Drawing.Size(383, 23)
      Me.eui_cmdGestionePlanningRisorseSport2.TabIndex = 5
      Me.eui_cmdGestionePlanningRisorseSport2.Text = "Planning 2 - (Inizio ore: 6:45 - Prenotazione minima un'ora)"
      '
      'eui_cmdGestionePlanningRisorseSport3
      '
      Me.eui_cmdGestionePlanningRisorseSport3.Id = "9352cf75-dbc2-469b-9377-9d595e17ffcf"
      Me.eui_cmdGestionePlanningRisorseSport3.Location = New System.Drawing.Point(2, 81)
      Me.eui_cmdGestionePlanningRisorseSport3.Name = "eui_cmdGestionePlanningRisorseSport3"
      Me.eui_cmdGestionePlanningRisorseSport3.Size = New System.Drawing.Size(383, 23)
      Me.eui_cmdGestionePlanningRisorseSport3.TabIndex = 6
      Me.eui_cmdGestionePlanningRisorseSport3.Text = "Planning 3 - (Inizio ore: 7:00 - Prenotazione minima un'ora)"
      '
      'eui_cmdGestionePlanningRisorseSport4
      '
      Me.eui_cmdGestionePlanningRisorseSport4.Id = "10c336bb-78c8-4ff3-9984-752041629de5"
      Me.eui_cmdGestionePlanningRisorseSport4.Location = New System.Drawing.Point(2, 104)
      Me.eui_cmdGestionePlanningRisorseSport4.Name = "eui_cmdGestionePlanningRisorseSport4"
      Me.eui_cmdGestionePlanningRisorseSport4.Size = New System.Drawing.Size(383, 23)
      Me.eui_cmdGestionePlanningRisorseSport4.TabIndex = 7
      Me.eui_cmdGestionePlanningRisorseSport4.Text = "Planning 4 - (Inizio ore: 7:15 - Prenotazione minima un'ora)"
      '
      'eui_ddwnGestionePrenotazioni
      '
      Me.eui_ddwnGestionePrenotazioni.Id = "2be97ba2-4420-48e6-8ef0-7304393a8afd"
      Me.eui_ddwnGestionePrenotazioni.KeyTip = "EP"
      Me.eui_ddwnGestionePrenotazioni.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", Global.Hospitality_Solution.My.Resources.Resources.NewContentPage_32x32)})
      Me.eui_ddwnGestionePrenotazioni.Location = New System.Drawing.Point(132, 2)
      Me.eui_ddwnGestionePrenotazioni.Name = "eui_ddwnGestionePrenotazioni"
      Me.eui_ddwnGestionePrenotazioni.Popup = Me.PopupMenu11
      Me.eui_ddwnGestionePrenotazioni.Size = New System.Drawing.Size(80, 72)
      Me.eui_ddwnGestionePrenotazioni.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", Global.Hospitality_Solution.My.Resources.Resources.NewContentPage_32x32)})
      Me.eui_ddwnGestionePrenotazioni.TabIndex = 3
      Me.eui_ddwnGestionePrenotazioni.Text = "Elenco prenotazioni"
      '
      'PopupMenu11
      '
      Me.PopupMenu11.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdGestionePrenCamere, Me.sepPrenCamere, Me.eui_cmdGestionePrenTavoli, Me.eui_cmdGestionePrenSale, Me.sepPrenRisorse, Me.eui_cmdGestionePrenRisorse})
      Me.PopupMenu11.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu11.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu11.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdGestionePrenCamere
      '
      Me.eui_cmdGestionePrenCamere.Id = "27d25c3b-d37a-460a-a9d3-0d569eccc86d"
      Me.eui_cmdGestionePrenCamere.KeyTip = "C"
      Me.eui_cmdGestionePrenCamere.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdGestionePrenCamere.Name = "eui_cmdGestionePrenCamere"
      Me.PopupMenu11.SetShortcutKeys(Me.eui_cmdGestionePrenCamere, System.Windows.Forms.Keys.F4)
      Me.eui_cmdGestionePrenCamere.Size = New System.Drawing.Size(141, 23)
      Me.eui_cmdGestionePrenCamere.TabIndex = 3
      Me.eui_cmdGestionePrenCamere.Text = "Camere"
      '
      'sepPrenCamere
      '
      Me.sepPrenCamere.Id = "761bdea2-81e4-4293-9d3b-9fa0810f0bb4"
      Me.sepPrenCamere.Location = New System.Drawing.Point(2, 25)
      Me.sepPrenCamere.Name = "sepPrenCamere"
      Me.sepPrenCamere.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepPrenCamere.Size = New System.Drawing.Size(141, 5)
      Me.sepPrenCamere.TabIndex = 7
      Me.sepPrenCamere.Text = "Separator10"
      '
      'eui_cmdGestionePrenTavoli
      '
      Me.eui_cmdGestionePrenTavoli.Id = "a63ab7ee-5705-4e85-9785-321c5aa2f6c6"
      Me.eui_cmdGestionePrenTavoli.KeyTip = "T"
      Me.eui_cmdGestionePrenTavoli.Location = New System.Drawing.Point(2, 30)
      Me.eui_cmdGestionePrenTavoli.Name = "eui_cmdGestionePrenTavoli"
      Me.eui_cmdGestionePrenTavoli.Size = New System.Drawing.Size(141, 23)
      Me.eui_cmdGestionePrenTavoli.TabIndex = 4
      Me.eui_cmdGestionePrenTavoli.Text = "Tavoli"
      '
      'eui_cmdGestionePrenSale
      '
      Me.eui_cmdGestionePrenSale.Id = "f283b75e-7c13-482d-b20e-ced0a2191c8f"
      Me.eui_cmdGestionePrenSale.KeyTip = "S"
      Me.eui_cmdGestionePrenSale.Location = New System.Drawing.Point(2, 53)
      Me.eui_cmdGestionePrenSale.Name = "eui_cmdGestionePrenSale"
      Me.eui_cmdGestionePrenSale.Size = New System.Drawing.Size(141, 23)
      Me.eui_cmdGestionePrenSale.TabIndex = 5
      Me.eui_cmdGestionePrenSale.Text = "Sale"
      '
      'sepPrenRisorse
      '
      Me.sepPrenRisorse.Id = "e66f258c-3cf0-4517-a107-0e7c4e27500c"
      Me.sepPrenRisorse.Location = New System.Drawing.Point(2, 76)
      Me.sepPrenRisorse.Name = "sepPrenRisorse"
      Me.sepPrenRisorse.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepPrenRisorse.Size = New System.Drawing.Size(141, 5)
      Me.sepPrenRisorse.TabIndex = 8
      Me.sepPrenRisorse.Text = "Separator11"
      '
      'eui_cmdGestionePrenRisorse
      '
      Me.eui_cmdGestionePrenRisorse.Id = "e725a794-2900-44dd-9d06-86e1d9136015"
      Me.eui_cmdGestionePrenRisorse.KeyTip = "R"
      Me.eui_cmdGestionePrenRisorse.Location = New System.Drawing.Point(2, 81)
      Me.eui_cmdGestionePrenRisorse.Name = "eui_cmdGestionePrenRisorse"
      Me.eui_cmdGestionePrenRisorse.Size = New System.Drawing.Size(141, 23)
      Me.eui_cmdGestionePrenRisorse.TabIndex = 6
      Me.eui_cmdGestionePrenRisorse.Text = "Risorse sportive"
      '
      'RibbonGroup15
      '
      Me.RibbonGroup15.BorderStyle = Elegant.Ui.PanelBorderStyle.[Single]
      Me.RibbonGroup15.Controls.Add(Me.eui_cmdGestioneClienti)
      Me.RibbonGroup15.Controls.Add(Me.eui_cmdGestioneSchedine)
      Me.RibbonGroup15.Controls.Add(Me.sepStatistiche)
      Me.RibbonGroup15.Controls.Add(Me.eui_ddwnGestioneStatistiche)
      Me.RibbonGroup15.DialogLauncherButtonVisible = False
      Me.RibbonGroup15.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup15.Location = New System.Drawing.Point(319, 1)
      Me.RibbonGroup15.Name = "RibbonGroup15"
      Me.RibbonGroup15.Size = New System.Drawing.Size(201, 94)
      Me.RibbonGroup15.TabIndex = 2
      Me.RibbonGroup15.Text = "Gestione"
      '
      'eui_cmdGestioneClienti
      '
      Me.eui_cmdGestioneClienti.Id = "fa565923-1751-4b9d-a00b-f164a1825198"
      Me.eui_cmdGestioneClienti.KeyTip = "EC"
      Me.eui_cmdGestioneClienti.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneClienti.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneClienti.Location = New System.Drawing.Point(4, 2)
      Me.eui_cmdGestioneClienti.Name = "eui_cmdGestioneClienti"
      Me.eui_cmdGestioneClienti.ScreenTip.Caption = "Elenco Clienti (F7)"
      Me.eui_cmdGestioneClienti.ScreenTip.Text = "Apre l'elenco dei Clienti."
      Me.RibbonGroup15.SetShortcutKeys(Me.eui_cmdGestioneClienti, System.Windows.Forms.Keys.F7)
      Me.eui_cmdGestioneClienti.Size = New System.Drawing.Size(42, 72)
      Me.eui_cmdGestioneClienti.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneClienti.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneClienti.TabIndex = 3
      Me.eui_cmdGestioneClienti.Text = "Elenco Clienti"
      '
      'eui_cmdGestioneSchedine
      '
      Me.eui_cmdGestioneSchedine.Id = "a3b40708-6628-4d8d-b215-c2e9b652267b"
      Me.eui_cmdGestioneSchedine.KeyTip = "ES"
      Me.eui_cmdGestioneSchedine.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneSchedine.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneSchedine.Location = New System.Drawing.Point(48, 2)
      Me.eui_cmdGestioneSchedine.Name = "eui_cmdGestioneSchedine"
      Me.eui_cmdGestioneSchedine.ScreenTip.Caption = "Elenco schedine P.S."
      Me.eui_cmdGestioneSchedine.ScreenTip.Text = "Apre l'elenco delle schedine di pubbilica sicurezza."
      Me.eui_cmdGestioneSchedine.Size = New System.Drawing.Size(73, 72)
      Me.eui_cmdGestioneSchedine.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneSchedine.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneSchedine.TabIndex = 2
      Me.eui_cmdGestioneSchedine.Text = "Elenco schedine P.S."
      '
      'sepStatistiche
      '
      Me.sepStatistiche.Id = "bc90f9e6-ab1e-4515-b509-f81d2b2d32d6"
      Me.sepStatistiche.Location = New System.Drawing.Point(124, 6)
      Me.sepStatistiche.Name = "sepStatistiche"
      Me.sepStatistiche.Size = New System.Drawing.Size(3, 59)
      Me.sepStatistiche.TabIndex = 4
      Me.sepStatistiche.Text = "Separator18"
      '
      'eui_ddwnGestioneStatistiche
      '
      Me.eui_ddwnGestioneStatistiche.Id = "9c8367a8-1b54-4729-ab2f-e1995c61b697"
      Me.eui_ddwnGestioneStatistiche.KeyTip = "S"
      Me.eui_ddwnGestioneStatistiche.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ddwnGestioneStatistiche.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_ddwnGestioneStatistiche.Location = New System.Drawing.Point(130, 2)
      Me.eui_ddwnGestioneStatistiche.Name = "eui_ddwnGestioneStatistiche"
      Me.eui_ddwnGestioneStatistiche.Popup = Me.PopupMenu6
      Me.eui_ddwnGestioneStatistiche.ScreenTip.Caption = "Statistiche di vendita"
      Me.eui_ddwnGestioneStatistiche.ScreenTip.Text = "Consente di selezionare le statistiche di vendita."
      Me.eui_ddwnGestioneStatistiche.Size = New System.Drawing.Size(66, 72)
      Me.eui_ddwnGestioneStatistiche.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ddwnGestioneStatistiche.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_ddwnGestioneStatistiche.TabIndex = 1
      Me.eui_ddwnGestioneStatistiche.Text = "Statistiche di vendita"
      '
      'PopupMenu6
      '
      Me.PopupMenu6.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdGestioneStatisticheHotel, Me.sepHotel, Me.eui_cmdGestioneStatistiche, Me.sepBarRistorante, Me.eui_cmdGestioneStatisticheRisorse})
      Me.PopupMenu6.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu6.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu6.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdGestioneStatisticheHotel
      '
      Me.eui_cmdGestioneStatisticheHotel.Enabled = False
      Me.eui_cmdGestioneStatisticheHotel.Id = "79971d5c-dbcb-463f-845e-e353b02bd305"
      Me.eui_cmdGestioneStatisticheHotel.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdGestioneStatisticheHotel.Name = "eui_cmdGestioneStatisticheHotel"
      Me.eui_cmdGestioneStatisticheHotel.Size = New System.Drawing.Size(179, 23)
      Me.eui_cmdGestioneStatisticheHotel.TabIndex = 7
      Me.eui_cmdGestioneStatisticheHotel.Text = "Hotel"
      '
      'sepHotel
      '
      Me.sepHotel.Id = "554543a1-7d79-4002-9d63-98082cb256f1"
      Me.sepHotel.Location = New System.Drawing.Point(2, 25)
      Me.sepHotel.Name = "sepHotel"
      Me.sepHotel.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepHotel.Size = New System.Drawing.Size(179, 5)
      Me.sepHotel.TabIndex = 8
      Me.sepHotel.Text = "Separator23"
      '
      'eui_cmdGestioneStatistiche
      '
      Me.eui_cmdGestioneStatistiche.Id = "e53f25ac-8fbf-43b0-83ed-fe5a6a9ac02e"
      Me.eui_cmdGestioneStatistiche.KeyTip = "BR"
      Me.eui_cmdGestioneStatistiche.Location = New System.Drawing.Point(2, 30)
      Me.eui_cmdGestioneStatistiche.Name = "eui_cmdGestioneStatistiche"
      Me.eui_cmdGestioneStatistiche.ScreenTip.Caption = "Bar / Ristorante (F6)"
      Me.eui_cmdGestioneStatistiche.ScreenTip.Text = "Apre le statistiche di vendita per il Bar / Ristorante."
      Me.PopupMenu6.SetShortcutKeys(Me.eui_cmdGestioneStatistiche, System.Windows.Forms.Keys.F6)
      Me.eui_cmdGestioneStatistiche.Size = New System.Drawing.Size(179, 23)
      Me.eui_cmdGestioneStatistiche.TabIndex = 3
      Me.eui_cmdGestioneStatistiche.Text = "Bar / Ristorante"
      '
      'sepBarRistorante
      '
      Me.sepBarRistorante.Id = "27aedffd-f5b4-47ff-836d-31f57c0b6b83"
      Me.sepBarRistorante.Location = New System.Drawing.Point(2, 53)
      Me.sepBarRistorante.Name = "sepBarRistorante"
      Me.sepBarRistorante.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepBarRistorante.Size = New System.Drawing.Size(179, 5)
      Me.sepBarRistorante.TabIndex = 5
      Me.sepBarRistorante.Text = "Separator9"
      '
      'eui_cmdGestioneStatisticheRisorse
      '
      Me.eui_cmdGestioneStatisticheRisorse.Id = "9e9343c6-db4a-4249-96ba-183162ce77d4"
      Me.eui_cmdGestioneStatisticheRisorse.KeyTip = "C"
      Me.eui_cmdGestioneStatisticheRisorse.Location = New System.Drawing.Point(2, 58)
      Me.eui_cmdGestioneStatisticheRisorse.Name = "eui_cmdGestioneStatisticheRisorse"
      Me.eui_cmdGestioneStatisticheRisorse.ScreenTip.Caption = "Centro sportivo (F11)"
      Me.eui_cmdGestioneStatisticheRisorse.ScreenTip.Text = "Apre le statistiche di vendita per il Centro spotivo."
      Me.PopupMenu6.SetShortcutKeys(Me.eui_cmdGestioneStatisticheRisorse, System.Windows.Forms.Keys.F11)
      Me.eui_cmdGestioneStatisticheRisorse.Size = New System.Drawing.Size(179, 23)
      Me.eui_cmdGestioneStatisticheRisorse.TabIndex = 4
      Me.eui_cmdGestioneStatisticheRisorse.Text = "Centro sportivo"
      '
      'RibbonGroup16
      '
      Me.RibbonGroup16.Controls.Add(Me.eui_cmdGestioneOperatori)
      Me.RibbonGroup16.Controls.Add(Me.eui_cmdGestioneGruppiOp)
      Me.RibbonGroup16.Controls.Add(Me.Separator15)
      Me.RibbonGroup16.Controls.Add(Me.eui_cmdGestioneCambiaOp)
      Me.RibbonGroup16.DialogLauncherButtonVisible = False
      Me.RibbonGroup16.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup16.Location = New System.Drawing.Point(520, 1)
      Me.RibbonGroup16.Name = "RibbonGroup16"
      Me.RibbonGroup16.Size = New System.Drawing.Size(169, 94)
      Me.RibbonGroup16.TabIndex = 3
      Me.RibbonGroup16.Text = "Operatori"
      '
      'eui_cmdGestioneOperatori
      '
      Me.eui_cmdGestioneOperatori.Id = "2002c084-f1a2-44a5-aa80-23e1a1dcfb97"
      Me.eui_cmdGestioneOperatori.KeyTip = "EO"
      Me.eui_cmdGestioneOperatori.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneOperatori.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneOperatori.Location = New System.Drawing.Point(4, 2)
      Me.eui_cmdGestioneOperatori.Name = "eui_cmdGestioneOperatori"
      Me.eui_cmdGestioneOperatori.ScreenTip.Caption = "Elenco operatori"
      Me.eui_cmdGestioneOperatori.ScreenTip.Text = "Apre l'elenco degli operatori che possono utilizzare il programma."
      Me.eui_cmdGestioneOperatori.Size = New System.Drawing.Size(52, 72)
      Me.eui_cmdGestioneOperatori.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneOperatori.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneOperatori.TabIndex = 0
      Me.eui_cmdGestioneOperatori.Text = "Elenco operatori"
      '
      'eui_cmdGestioneGruppiOp
      '
      Me.eui_cmdGestioneGruppiOp.Id = "1e718aec-97e3-4da8-82f3-27270827182c"
      Me.eui_cmdGestioneGruppiOp.KeyTip = "EG"
      Me.eui_cmdGestioneGruppiOp.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneGruppiOp.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneGruppiOp.Location = New System.Drawing.Point(58, 2)
      Me.eui_cmdGestioneGruppiOp.Name = "eui_cmdGestioneGruppiOp"
      Me.eui_cmdGestioneGruppiOp.ScreenTip.Caption = "Elenco gruppi"
      Me.eui_cmdGestioneGruppiOp.ScreenTip.Text = "Apre l'elenco dei gruppi a cui appartengono gli operatori del programma."
      Me.eui_cmdGestioneGruppiOp.Size = New System.Drawing.Size(42, 72)
      Me.eui_cmdGestioneGruppiOp.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneGruppiOp.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneGruppiOp.TabIndex = 1
      Me.eui_cmdGestioneGruppiOp.Text = "Elenco gruppi"
      '
      'Separator15
      '
      Me.Separator15.Id = "bf4d554f-4bed-4d42-ad8e-5444209a5a74"
      Me.Separator15.Location = New System.Drawing.Point(103, 6)
      Me.Separator15.Name = "Separator15"
      Me.Separator15.Size = New System.Drawing.Size(3, 61)
      Me.Separator15.TabIndex = 3
      Me.Separator15.Text = "Separator15"
      '
      'eui_cmdGestioneCambiaOp
      '
      Me.eui_cmdGestioneCambiaOp.Id = "8aac62ec-ec67-4bad-a50c-526cba6998dc"
      Me.eui_cmdGestioneCambiaOp.KeyTip = "O"
      Me.eui_cmdGestioneCambiaOp.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneCambiaOp.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneCambiaOp.Location = New System.Drawing.Point(109, 2)
      Me.eui_cmdGestioneCambiaOp.Name = "eui_cmdGestioneCambiaOp"
      Me.eui_cmdGestioneCambiaOp.ScreenTip.Caption = "Cambia operatore"
      Me.eui_cmdGestioneCambiaOp.ScreenTip.Text = "Permette di effettuare il cambio dell'operatore che sta utilizzando il programma." &
    ""
      Me.eui_cmdGestioneCambiaOp.Size = New System.Drawing.Size(55, 72)
      Me.eui_cmdGestioneCambiaOp.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneCambiaOp.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneCambiaOp.TabIndex = 2
      Me.eui_cmdGestioneCambiaOp.Text = "Cambia operatore"
      '
      'RibbonGroup30
      '
      Me.RibbonGroup30.Controls.Add(Me.eui_cmdGestioneOpzioni)
      Me.RibbonGroup30.DialogLauncherButtonVisible = False
      Me.RibbonGroup30.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup30.Location = New System.Drawing.Point(689, 1)
      Me.RibbonGroup30.Name = "RibbonGroup30"
      Me.RibbonGroup30.Size = New System.Drawing.Size(92, 94)
      Me.RibbonGroup30.TabIndex = 4
      Me.RibbonGroup30.Text = "Impostazioni"
      '
      'eui_cmdGestioneOpzioni
      '
      Me.eui_cmdGestioneOpzioni.Id = "8c50b98a-b94e-4cc2-94d8-18d383744eaf"
      Me.eui_cmdGestioneOpzioni.KeyTip = "OC"
      Me.eui_cmdGestioneOpzioni.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneOpzioni.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneOpzioni.Location = New System.Drawing.Point(4, 2)
      Me.eui_cmdGestioneOpzioni.Name = "eui_cmdGestioneOpzioni"
      Me.eui_cmdGestioneOpzioni.ScreenTip.Caption = "Opzioni di configurazione"
      Me.eui_cmdGestioneOpzioni.ScreenTip.Text = "Apre la finestra Opzioni per la configurazione del programma."
      Me.eui_cmdGestioneOpzioni.Size = New System.Drawing.Size(83, 72)
      Me.eui_cmdGestioneOpzioni.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdGestioneOpzioni.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdGestioneOpzioni.TabIndex = 0
      Me.eui_cmdGestioneOpzioni.Text = "Opzioni di configurazione"
      '
      'eui_Archivi
      '
      Me.eui_Archivi.Controls.Add(Me.RibbonGroup17)
      Me.eui_Archivi.Controls.Add(Me.RibbonGroup5)
      Me.eui_Archivi.Controls.Add(Me.RibbonGroup1)
      Me.eui_Archivi.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_Archivi.KeyTip = "A"
      Me.eui_Archivi.Location = New System.Drawing.Point(0, 0)
      Me.eui_Archivi.Name = "eui_Archivi"
      Me.eui_Archivi.Size = New System.Drawing.Size(1341, 99)
      Me.eui_Archivi.TabIndex = 0
      Me.eui_Archivi.Text = "Archivi"
      '
      'RibbonGroup17
      '
      Me.RibbonGroup17.Controls.Add(Me.DropDown3)
      Me.RibbonGroup17.DialogLauncherButtonVisible = False
      Me.RibbonGroup17.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup17.Name = "RibbonGroup17"
      Me.RibbonGroup17.Size = New System.Drawing.Size(85, 94)
      Me.RibbonGroup17.TabIndex = 0
      Me.RibbonGroup17.Text = "Anagrafiche"
      '
      'DropDown3
      '
      Me.DropDown3.Id = "de7387a9-00fc-4dc9-b492-b909b5b8eb2b"
      Me.DropDown3.KeyTip = "A"
      Me.DropDown3.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("DropDown3.LargeImages.Images"), System.Drawing.Image))})
      Me.DropDown3.Location = New System.Drawing.Point(4, 2)
      Me.DropDown3.Name = "DropDown3"
      Me.DropDown3.Popup = Me.PopupMenu1
      Me.DropDown3.ScreenTip.Caption = "Seleziona anagrafiche"
      Me.DropDown3.ScreenTip.Text = "Consente di selezionare le anagrafiche, ad esempio i clienti o i piatti."
      Me.DropDown3.Size = New System.Drawing.Size(122, 0)
      Me.DropDown3.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("DropDown3.SmallImages.Images"), System.Drawing.Image))})
      Me.DropDown3.TabIndex = 0
      Me.DropDown3.Text = "Seleziona anagrafiche"
      '
      'PopupMenu1
      '
      Me.PopupMenu1.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdArchiviAnagraficheClienti, Me.eui_cmdArchiviAnagraficheFornitori, Me.eui_cmdArchiviAnagraficheCamerieri, Me.eui_cmdArchiviAnagraficheAziende, Me.Separator1, Me.eui_cmdArchiviAnagraficheCamere, Me.sepCamere, Me.eui_cmdArchiviAnagraficheSale, Me.eui_cmdArchiviAnagraficheTavoli, Me.sepRistorante, Me.eui_cmdArchiviAnagrafichePiatti, Me.eui_cmdArchiviAnagraficheCategoriePiatti, Me.sepBar, Me.eui_cmdArchiviAnagraficheRisorse, Me.eui_cmdArchiviAnagraficheUtilizzoRisorse, Me.eui_cmdArchiviAnagraficheAccServ, Me.sepRisorse, Me.eui_cmdArchiviAnagraficheDatiAzienda})
      Me.PopupMenu1.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu1.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu1.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdArchiviAnagraficheClienti
      '
      Me.eui_cmdArchiviAnagraficheClienti.Id = "ff38ea5c-ebcb-49d7-a76b-ba53731b89b5"
      Me.eui_cmdArchiviAnagraficheClienti.KeyTip = "C"
      Me.eui_cmdArchiviAnagraficheClienti.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdArchiviAnagraficheClienti.Name = "eui_cmdArchiviAnagraficheClienti"
      Me.eui_cmdArchiviAnagraficheClienti.ScreenTip.Caption = "Clienti (F7)"
      Me.eui_cmdArchiviAnagraficheClienti.ScreenTip.Text = "Apre l'anagrafica clienti."
      Me.PopupMenu1.SetShortcutKeyDisplayString(Me.eui_cmdArchiviAnagraficheClienti, "F7")
      Me.PopupMenu1.SetShortcutKeys(Me.eui_cmdArchiviAnagraficheClienti, System.Windows.Forms.Keys.F7)
      Me.eui_cmdArchiviAnagraficheClienti.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheClienti.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviAnagraficheClienti.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviAnagraficheClienti.TabIndex = 7
      Me.eui_cmdArchiviAnagraficheClienti.Text = "Clienti"
      '
      'eui_cmdArchiviAnagraficheFornitori
      '
      Me.eui_cmdArchiviAnagraficheFornitori.Id = "6237fc13-8f83-4df1-a458-d21627406548"
      Me.eui_cmdArchiviAnagraficheFornitori.KeyTip = "F"
      Me.eui_cmdArchiviAnagraficheFornitori.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdArchiviAnagraficheFornitori.Name = "eui_cmdArchiviAnagraficheFornitori"
      Me.eui_cmdArchiviAnagraficheFornitori.ScreenTip.Caption = "Fornitori (F8)"
      Me.eui_cmdArchiviAnagraficheFornitori.ScreenTip.Text = "Apre l'anagrafica fornitori."
      Me.PopupMenu1.SetShortcutKeyDisplayString(Me.eui_cmdArchiviAnagraficheFornitori, "F8")
      Me.PopupMenu1.SetShortcutKeys(Me.eui_cmdArchiviAnagraficheFornitori, System.Windows.Forms.Keys.F8)
      Me.eui_cmdArchiviAnagraficheFornitori.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheFornitori.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviAnagraficheFornitori.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviAnagraficheFornitori.TabIndex = 8
      Me.eui_cmdArchiviAnagraficheFornitori.Text = "Fornitori"
      '
      'eui_cmdArchiviAnagraficheCamerieri
      '
      Me.eui_cmdArchiviAnagraficheCamerieri.Id = "660d45f9-e9a2-4e1c-8eae-f95f9fead737"
      Me.eui_cmdArchiviAnagraficheCamerieri.KeyTip = "M"
      Me.eui_cmdArchiviAnagraficheCamerieri.Location = New System.Drawing.Point(2, 48)
      Me.eui_cmdArchiviAnagraficheCamerieri.Name = "eui_cmdArchiviAnagraficheCamerieri"
      Me.eui_cmdArchiviAnagraficheCamerieri.ScreenTip.Caption = "Camerieri"
      Me.eui_cmdArchiviAnagraficheCamerieri.ScreenTip.Text = "Apre l'anagrafica camerieri."
      Me.eui_cmdArchiviAnagraficheCamerieri.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheCamerieri.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviAnagraficheCamerieri.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviAnagraficheCamerieri.TabIndex = 9
      Me.eui_cmdArchiviAnagraficheCamerieri.Text = "Camerieri"
      '
      'eui_cmdArchiviAnagraficheAziende
      '
      Me.eui_cmdArchiviAnagraficheAziende.Id = "d627c2b0-5c0b-4fbe-847b-2c76918e6099"
      Me.eui_cmdArchiviAnagraficheAziende.KeyTip = "A"
      Me.eui_cmdArchiviAnagraficheAziende.Location = New System.Drawing.Point(2, 71)
      Me.eui_cmdArchiviAnagraficheAziende.Name = "eui_cmdArchiviAnagraficheAziende"
      Me.eui_cmdArchiviAnagraficheAziende.ScreenTip.Caption = "Aziende (F9)"
      Me.eui_cmdArchiviAnagraficheAziende.ScreenTip.Text = "Apre l'anagrafica aziende."
      Me.PopupMenu1.SetShortcutKeyDisplayString(Me.eui_cmdArchiviAnagraficheAziende, "F9")
      Me.PopupMenu1.SetShortcutKeys(Me.eui_cmdArchiviAnagraficheAziende, System.Windows.Forms.Keys.F9)
      Me.eui_cmdArchiviAnagraficheAziende.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheAziende.TabIndex = 10
      Me.eui_cmdArchiviAnagraficheAziende.Text = "Aziende"
      '
      'Separator1
      '
      Me.Separator1.Id = "ae1faf3f-271d-42bb-a5f7-a585aa02d3e4"
      Me.Separator1.Location = New System.Drawing.Point(2, 94)
      Me.Separator1.Name = "Separator1"
      Me.Separator1.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator1.Size = New System.Drawing.Size(247, 5)
      Me.Separator1.TabIndex = 11
      Me.Separator1.Text = "Separator1"
      '
      'eui_cmdArchiviAnagraficheCamere
      '
      Me.eui_cmdArchiviAnagraficheCamere.Id = "2285335a-10a4-41b1-8c88-dd45f2c538b7"
      Me.eui_cmdArchiviAnagraficheCamere.KeyTip = "R"
      Me.eui_cmdArchiviAnagraficheCamere.Location = New System.Drawing.Point(2, 99)
      Me.eui_cmdArchiviAnagraficheCamere.Name = "eui_cmdArchiviAnagraficheCamere"
      Me.eui_cmdArchiviAnagraficheCamere.ScreenTip.Caption = "Camere"
      Me.eui_cmdArchiviAnagraficheCamere.ScreenTip.Text = "Apre l'anagrafica camere."
      Me.eui_cmdArchiviAnagraficheCamere.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheCamere.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviAnagraficheCamere.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviAnagraficheCamere.TabIndex = 25
      Me.eui_cmdArchiviAnagraficheCamere.Text = "Camere"
      '
      'sepCamere
      '
      Me.sepCamere.Id = "d1d7164d-8a39-4dca-8dc1-5152d362dd07"
      Me.sepCamere.Location = New System.Drawing.Point(2, 122)
      Me.sepCamere.Name = "sepCamere"
      Me.sepCamere.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepCamere.Size = New System.Drawing.Size(247, 5)
      Me.sepCamere.TabIndex = 26
      Me.sepCamere.Text = "Separator2"
      '
      'eui_cmdArchiviAnagraficheSale
      '
      Me.eui_cmdArchiviAnagraficheSale.Id = "c51d3ced-326d-4a9e-bcc1-2ff2e4b39f32"
      Me.eui_cmdArchiviAnagraficheSale.KeyTip = "S"
      Me.eui_cmdArchiviAnagraficheSale.Location = New System.Drawing.Point(2, 127)
      Me.eui_cmdArchiviAnagraficheSale.Name = "eui_cmdArchiviAnagraficheSale"
      Me.eui_cmdArchiviAnagraficheSale.ScreenTip.Caption = "Sale"
      Me.eui_cmdArchiviAnagraficheSale.ScreenTip.Text = "Apre l'anagrafica sale."
      Me.eui_cmdArchiviAnagraficheSale.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheSale.TabIndex = 12
      Me.eui_cmdArchiviAnagraficheSale.Text = "Sale"
      '
      'eui_cmdArchiviAnagraficheTavoli
      '
      Me.eui_cmdArchiviAnagraficheTavoli.Id = "bf3ffa0f-88e5-4346-82eb-8ee7ffae3059"
      Me.eui_cmdArchiviAnagraficheTavoli.KeyTip = "T"
      Me.eui_cmdArchiviAnagraficheTavoli.Location = New System.Drawing.Point(2, 150)
      Me.eui_cmdArchiviAnagraficheTavoli.Name = "eui_cmdArchiviAnagraficheTavoli"
      Me.eui_cmdArchiviAnagraficheTavoli.ScreenTip.Caption = "Tavoli"
      Me.eui_cmdArchiviAnagraficheTavoli.ScreenTip.Text = "Apre l'anagrafica tavoli."
      Me.eui_cmdArchiviAnagraficheTavoli.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheTavoli.TabIndex = 13
      Me.eui_cmdArchiviAnagraficheTavoli.Text = "Tavoli"
      '
      'sepRistorante
      '
      Me.sepRistorante.Id = "f61803d6-e6a6-4be0-9028-0cfb5f804bac"
      Me.sepRistorante.Location = New System.Drawing.Point(2, 173)
      Me.sepRistorante.Name = "sepRistorante"
      Me.sepRistorante.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepRistorante.Size = New System.Drawing.Size(247, 5)
      Me.sepRistorante.TabIndex = 14
      Me.sepRistorante.Text = "Separator2"
      '
      'eui_cmdArchiviAnagrafichePiatti
      '
      Me.eui_cmdArchiviAnagrafichePiatti.Id = "236f82b9-b53d-46a1-97cc-af70aa9927d8"
      Me.eui_cmdArchiviAnagrafichePiatti.KeyTip = "P"
      Me.eui_cmdArchiviAnagrafichePiatti.Location = New System.Drawing.Point(2, 178)
      Me.eui_cmdArchiviAnagrafichePiatti.Name = "eui_cmdArchiviAnagrafichePiatti"
      Me.eui_cmdArchiviAnagrafichePiatti.ScreenTip.Caption = "Piatti (F10)"
      Me.eui_cmdArchiviAnagrafichePiatti.ScreenTip.Text = "Apre l'anagrafica piatti."
      Me.PopupMenu1.SetShortcutKeyDisplayString(Me.eui_cmdArchiviAnagrafichePiatti, "F10")
      Me.PopupMenu1.SetShortcutKeys(Me.eui_cmdArchiviAnagrafichePiatti, System.Windows.Forms.Keys.F10)
      Me.eui_cmdArchiviAnagrafichePiatti.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagrafichePiatti.TabIndex = 15
      Me.eui_cmdArchiviAnagrafichePiatti.Text = "Piatti"
      '
      'eui_cmdArchiviAnagraficheCategoriePiatti
      '
      Me.eui_cmdArchiviAnagraficheCategoriePiatti.Id = "73b8f15e-bf89-43b5-9664-fa35b7cd6174"
      Me.eui_cmdArchiviAnagraficheCategoriePiatti.KeyTip = "G"
      Me.eui_cmdArchiviAnagraficheCategoriePiatti.Location = New System.Drawing.Point(2, 201)
      Me.eui_cmdArchiviAnagraficheCategoriePiatti.Name = "eui_cmdArchiviAnagraficheCategoriePiatti"
      Me.eui_cmdArchiviAnagraficheCategoriePiatti.ScreenTip.Caption = "Categorie piatti"
      Me.eui_cmdArchiviAnagraficheCategoriePiatti.ScreenTip.Text = "Apre l'anagrafica categorie piatti."
      Me.eui_cmdArchiviAnagraficheCategoriePiatti.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheCategoriePiatti.TabIndex = 16
      Me.eui_cmdArchiviAnagraficheCategoriePiatti.Text = "Categorie piatti"
      '
      'sepBar
      '
      Me.sepBar.Id = "8eefe9cb-b04f-472c-97cd-066be078c7e1"
      Me.sepBar.Location = New System.Drawing.Point(2, 224)
      Me.sepBar.Name = "sepBar"
      Me.sepBar.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepBar.Size = New System.Drawing.Size(247, 5)
      Me.sepBar.TabIndex = 17
      Me.sepBar.Text = "Separator3"
      '
      'eui_cmdArchiviAnagraficheRisorse
      '
      Me.eui_cmdArchiviAnagraficheRisorse.Id = "f4afaa9e-522d-4019-a285-029c6ecb50ca"
      Me.eui_cmdArchiviAnagraficheRisorse.KeyTip = "O"
      Me.eui_cmdArchiviAnagraficheRisorse.Location = New System.Drawing.Point(2, 229)
      Me.eui_cmdArchiviAnagraficheRisorse.Name = "eui_cmdArchiviAnagraficheRisorse"
      Me.eui_cmdArchiviAnagraficheRisorse.ScreenTip.Caption = "Risorse"
      Me.eui_cmdArchiviAnagraficheRisorse.ScreenTip.Text = "Apre l'anagrafica risorse."
      Me.eui_cmdArchiviAnagraficheRisorse.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheRisorse.TabIndex = 20
      Me.eui_cmdArchiviAnagraficheRisorse.Text = "Risorse sportive"
      '
      'eui_cmdArchiviAnagraficheUtilizzoRisorse
      '
      Me.eui_cmdArchiviAnagraficheUtilizzoRisorse.Id = "d0ff87ef-a533-4552-b5c3-56466108fb2d"
      Me.eui_cmdArchiviAnagraficheUtilizzoRisorse.KeyTip = "U"
      Me.eui_cmdArchiviAnagraficheUtilizzoRisorse.Location = New System.Drawing.Point(2, 252)
      Me.eui_cmdArchiviAnagraficheUtilizzoRisorse.Name = "eui_cmdArchiviAnagraficheUtilizzoRisorse"
      Me.eui_cmdArchiviAnagraficheUtilizzoRisorse.ScreenTip.Caption = "Tipologie di utilizzo Risorse"
      Me.eui_cmdArchiviAnagraficheUtilizzoRisorse.ScreenTip.Text = "Apre l'anagrafica tipologie di utilizzo risorse."
      Me.eui_cmdArchiviAnagraficheUtilizzoRisorse.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheUtilizzoRisorse.TabIndex = 28
      Me.eui_cmdArchiviAnagraficheUtilizzoRisorse.Text = "Tipologie di utilizzo Risorse sportive"
      '
      'eui_cmdArchiviAnagraficheAccServ
      '
      Me.eui_cmdArchiviAnagraficheAccServ.Id = "8b4cd28c-31bb-4633-a134-990bf805937e"
      Me.eui_cmdArchiviAnagraficheAccServ.KeyTip = "E"
      Me.eui_cmdArchiviAnagraficheAccServ.Location = New System.Drawing.Point(2, 275)
      Me.eui_cmdArchiviAnagraficheAccServ.Name = "eui_cmdArchiviAnagraficheAccServ"
      Me.eui_cmdArchiviAnagraficheAccServ.ScreenTip.Caption = "Accessori e Servizi"
      Me.eui_cmdArchiviAnagraficheAccServ.ScreenTip.Text = "Apre l'anagrafica accessori e servizi."
      Me.eui_cmdArchiviAnagraficheAccServ.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheAccServ.TabIndex = 23
      Me.eui_cmdArchiviAnagraficheAccServ.Text = "Accessori e Servizi"
      '
      'sepRisorse
      '
      Me.sepRisorse.Id = "62d476ca-61d8-43e2-bb9f-94c1dd1afe65"
      Me.sepRisorse.Location = New System.Drawing.Point(2, 298)
      Me.sepRisorse.Name = "sepRisorse"
      Me.sepRisorse.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepRisorse.Size = New System.Drawing.Size(247, 5)
      Me.sepRisorse.TabIndex = 21
      Me.sepRisorse.Text = "Separator7"
      '
      'eui_cmdArchiviAnagraficheDatiAzienda
      '
      Me.eui_cmdArchiviAnagraficheDatiAzienda.Id = "bb85a2af-cff1-4ee8-aa72-90a4caeedcef"
      Me.eui_cmdArchiviAnagraficheDatiAzienda.KeyTip = "D"
      Me.eui_cmdArchiviAnagraficheDatiAzienda.Location = New System.Drawing.Point(2, 303)
      Me.eui_cmdArchiviAnagraficheDatiAzienda.Name = "eui_cmdArchiviAnagraficheDatiAzienda"
      Me.eui_cmdArchiviAnagraficheDatiAzienda.ScreenTip.Caption = "Dati generali azienda"
      Me.eui_cmdArchiviAnagraficheDatiAzienda.ScreenTip.Text = "Apre l'anagrafica dati generali azienda."
      Me.eui_cmdArchiviAnagraficheDatiAzienda.Size = New System.Drawing.Size(247, 23)
      Me.eui_cmdArchiviAnagraficheDatiAzienda.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviAnagraficheDatiAzienda.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviAnagraficheDatiAzienda.TabIndex = 18
      Me.eui_cmdArchiviAnagraficheDatiAzienda.Text = "Dati generali azienda"
      '
      'RibbonGroup5
      '
      Me.RibbonGroup5.Controls.Add(Me.DropDown1)
      Me.RibbonGroup5.DialogLauncherButtonVisible = False
      Me.RibbonGroup5.Location = New System.Drawing.Point(90, 1)
      Me.RibbonGroup5.Name = "RibbonGroup5"
      Me.RibbonGroup5.Size = New System.Drawing.Size(64, 94)
      Me.RibbonGroup5.TabIndex = 1
      Me.RibbonGroup5.Text = "Tabelle"
      '
      'DropDown1
      '
      Me.DropDown1.Id = "05af90bd-5a7e-446a-822f-c18821da6945"
      Me.DropDown1.KeyTip = "T"
      Me.DropDown1.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("DropDown1.LargeImages.Images"), System.Drawing.Image))})
      Me.DropDown1.Location = New System.Drawing.Point(4, 2)
      Me.DropDown1.Name = "DropDown1"
      Me.DropDown1.Popup = Me.PopupMenu3
      Me.DropDown1.ScreenTip.Caption = "Seleziona tabelle"
      Me.DropDown1.ScreenTip.Text = "Consente di selezionare le tabelle dati, ad esempio nazioni o reparti."
      Me.DropDown1.Size = New System.Drawing.Size(97, 0)
      Me.DropDown1.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("DropDown1.SmallImages.Images"), System.Drawing.Image))})
      Me.DropDown1.TabIndex = 0
      Me.DropDown1.Text = "Seleziona tabelle"
      '
      'PopupMenu3
      '
      Me.PopupMenu3.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdArchiviTabelleTitoli, Me.eui_cmdArchiviTabelleCategorieCliente, Me.eui_cmdArchiviTabelleAttività, Me.eui_cmdArchiviTabelleComuni, Me.eui_cmdArchiviTabelleNazioni, Me.Separator4, Me.eui_cmdArchiviTabelleUM, Me.eui_cmdArchiviTabelleCategorieMerce, Me.eui_cmdArchiviTabelleMagazzini, Me.eui_cmdArchiviTabelleUbicazioni, Me.eui_cmdArchiviTabelleScaffali, Me.sepMagazzino, Me.eui_cmdArchiviTabelleReparti, Me.eui_cmdArchiviTabelleMsgReparti, Me.sepReparti, Me.eui_cmdArchiviTabelleCausaliDoc, Me.eui_cmdArchiviTabellePagamenti, Me.Separator8, Me.eui_cmdArchiviTabelleListini, Me.eui_cmdArchiviTabelleStagioni, Me.eui_cmdArchiviTabelleTipologieCamere, Me.eui_cmdArchiviTabelleUbicazioniCamere, Me.eui_cmdArchiviTabellePosizioniCamere, Me.eui_cmdArchiviTabelleTipoAlloggiati, Me.eui_cmdArchiviTabelleGruppi, Me.eui_cmdArchiviTabelleAgenzie, Me.eui_cmdArchiviTabelleCanali, Me.sepListini, Me.eui_cmdArchiviTabelleStatoPren, Me.sepStatoPren, Me.eui_cmdArchiviTabelleDocIdentità, Me.Separator24, Me.eui_cmdArchiviTabelleTipoRisorse})
      Me.PopupMenu3.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu3.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu3.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdArchiviTabelleTitoli
      '
      Me.eui_cmdArchiviTabelleTitoli.Id = "38f80de3-a8fd-4772-abfd-320a5fa0c961"
      Me.eui_cmdArchiviTabelleTitoli.KeyTip = "F"
      Me.eui_cmdArchiviTabelleTitoli.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdArchiviTabelleTitoli.Name = "eui_cmdArchiviTabelleTitoli"
      Me.eui_cmdArchiviTabelleTitoli.ScreenTip.Caption = "Forme di cortesia"
      Me.eui_cmdArchiviTabelleTitoli.ScreenTip.Text = "Apre la tabella dati forme di cortesia."
      Me.eui_cmdArchiviTabelleTitoli.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleTitoli.TabIndex = 3
      Me.eui_cmdArchiviTabelleTitoli.Text = "Forme di cortesia"
      '
      'eui_cmdArchiviTabelleCategorieCliente
      '
      Me.eui_cmdArchiviTabelleCategorieCliente.Id = "47a5ad0d-c307-428b-9a0f-dc234eb2d0d2"
      Me.eui_cmdArchiviTabelleCategorieCliente.KeyTip = "C"
      Me.eui_cmdArchiviTabelleCategorieCliente.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdArchiviTabelleCategorieCliente.Name = "eui_cmdArchiviTabelleCategorieCliente"
      Me.eui_cmdArchiviTabelleCategorieCliente.ScreenTip.Caption = "Categorie cliente"
      Me.eui_cmdArchiviTabelleCategorieCliente.ScreenTip.Text = "Apre la tabella dati categorie cliente."
      Me.eui_cmdArchiviTabelleCategorieCliente.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleCategorieCliente.TabIndex = 4
      Me.eui_cmdArchiviTabelleCategorieCliente.Text = "Categorie cliente"
      '
      'eui_cmdArchiviTabelleAttività
      '
      Me.eui_cmdArchiviTabelleAttività.Id = "a2261b9a-082e-4bc5-aac3-60a8e9ca639c"
      Me.eui_cmdArchiviTabelleAttività.KeyTip = "A"
      Me.eui_cmdArchiviTabelleAttività.Location = New System.Drawing.Point(2, 48)
      Me.eui_cmdArchiviTabelleAttività.Name = "eui_cmdArchiviTabelleAttività"
      Me.eui_cmdArchiviTabelleAttività.ScreenTip.Caption = "Attività"
      Me.eui_cmdArchiviTabelleAttività.ScreenTip.Text = "Apre la tabella dati attività."
      Me.eui_cmdArchiviTabelleAttività.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleAttività.TabIndex = 5
      Me.eui_cmdArchiviTabelleAttività.Text = "Attività"
      '
      'eui_cmdArchiviTabelleComuni
      '
      Me.eui_cmdArchiviTabelleComuni.Id = "674157ba-aa23-416c-a12e-e4a402798575"
      Me.eui_cmdArchiviTabelleComuni.KeyTip = "CO"
      Me.eui_cmdArchiviTabelleComuni.Location = New System.Drawing.Point(2, 71)
      Me.eui_cmdArchiviTabelleComuni.Name = "eui_cmdArchiviTabelleComuni"
      Me.eui_cmdArchiviTabelleComuni.ScreenTip.Caption = "Comuni"
      Me.eui_cmdArchiviTabelleComuni.ScreenTip.Text = "Apre la tabella Comuni."
      Me.eui_cmdArchiviTabelleComuni.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleComuni.TabIndex = 41
      Me.eui_cmdArchiviTabelleComuni.Text = "Comuni"
      '
      'eui_cmdArchiviTabelleNazioni
      '
      Me.eui_cmdArchiviTabelleNazioni.Id = "3a17d453-8b19-44f3-a820-5ead94841c40"
      Me.eui_cmdArchiviTabelleNazioni.KeyTip = "N"
      Me.eui_cmdArchiviTabelleNazioni.Location = New System.Drawing.Point(2, 94)
      Me.eui_cmdArchiviTabelleNazioni.Name = "eui_cmdArchiviTabelleNazioni"
      Me.eui_cmdArchiviTabelleNazioni.ScreenTip.Caption = "Nazioni"
      Me.eui_cmdArchiviTabelleNazioni.ScreenTip.Text = "Apre la tabella dati nazioni."
      Me.eui_cmdArchiviTabelleNazioni.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleNazioni.TabIndex = 6
      Me.eui_cmdArchiviTabelleNazioni.Text = "Nazioni"
      '
      'Separator4
      '
      Me.Separator4.Id = "50c0a4f8-5ba9-4550-b480-adfc21e028b1"
      Me.Separator4.Location = New System.Drawing.Point(2, 117)
      Me.Separator4.Name = "Separator4"
      Me.Separator4.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator4.Size = New System.Drawing.Size(194, 5)
      Me.Separator4.TabIndex = 7
      Me.Separator4.Text = "Separator4"
      '
      'eui_cmdArchiviTabelleUM
      '
      Me.eui_cmdArchiviTabelleUM.Id = "faf6839f-7052-4676-9417-f1ed8d41244e"
      Me.eui_cmdArchiviTabelleUM.KeyTip = "U"
      Me.eui_cmdArchiviTabelleUM.Location = New System.Drawing.Point(2, 122)
      Me.eui_cmdArchiviTabelleUM.Name = "eui_cmdArchiviTabelleUM"
      Me.eui_cmdArchiviTabelleUM.ScreenTip.Caption = "Unità di misura"
      Me.eui_cmdArchiviTabelleUM.ScreenTip.Text = "Apre la tabella dati unità di misura."
      Me.eui_cmdArchiviTabelleUM.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleUM.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviTabelleUM.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviTabelleUM.TabIndex = 8
      Me.eui_cmdArchiviTabelleUM.Text = "Unità di misura"
      '
      'eui_cmdArchiviTabelleCategorieMerce
      '
      Me.eui_cmdArchiviTabelleCategorieMerce.Id = "dee981ce-d5a3-4325-b5a2-2c71f3400c81"
      Me.eui_cmdArchiviTabelleCategorieMerce.KeyTip = "H"
      Me.eui_cmdArchiviTabelleCategorieMerce.Location = New System.Drawing.Point(2, 145)
      Me.eui_cmdArchiviTabelleCategorieMerce.Name = "eui_cmdArchiviTabelleCategorieMerce"
      Me.eui_cmdArchiviTabelleCategorieMerce.ScreenTip.Caption = "Categorie merceologiche"
      Me.eui_cmdArchiviTabelleCategorieMerce.ScreenTip.Text = "Apre la tabella dati categorie merceologiche."
      Me.eui_cmdArchiviTabelleCategorieMerce.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleCategorieMerce.TabIndex = 9
      Me.eui_cmdArchiviTabelleCategorieMerce.Text = "Categorie merceologiche"
      '
      'eui_cmdArchiviTabelleMagazzini
      '
      Me.eui_cmdArchiviTabelleMagazzini.Id = "be55d212-cf16-43fe-ad96-a9f72bc9f0b5"
      Me.eui_cmdArchiviTabelleMagazzini.KeyTip = "M"
      Me.eui_cmdArchiviTabelleMagazzini.Location = New System.Drawing.Point(2, 168)
      Me.eui_cmdArchiviTabelleMagazzini.Name = "eui_cmdArchiviTabelleMagazzini"
      Me.eui_cmdArchiviTabelleMagazzini.ScreenTip.Caption = "Magazzini"
      Me.eui_cmdArchiviTabelleMagazzini.ScreenTip.Text = "Apre la tabella dati magazzini."
      Me.eui_cmdArchiviTabelleMagazzini.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleMagazzini.TabIndex = 10
      Me.eui_cmdArchiviTabelleMagazzini.Text = "Magazzini"
      '
      'eui_cmdArchiviTabelleUbicazioni
      '
      Me.eui_cmdArchiviTabelleUbicazioni.Id = "5955513e-0173-4c91-b60e-7a47a40272d6"
      Me.eui_cmdArchiviTabelleUbicazioni.KeyTip = "B"
      Me.eui_cmdArchiviTabelleUbicazioni.Location = New System.Drawing.Point(2, 191)
      Me.eui_cmdArchiviTabelleUbicazioni.Name = "eui_cmdArchiviTabelleUbicazioni"
      Me.eui_cmdArchiviTabelleUbicazioni.ScreenTip.Caption = "Ubicazioni"
      Me.eui_cmdArchiviTabelleUbicazioni.ScreenTip.Text = "Apre la tabella dati ubicazioni."
      Me.eui_cmdArchiviTabelleUbicazioni.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleUbicazioni.TabIndex = 11
      Me.eui_cmdArchiviTabelleUbicazioni.Text = "Ubicazioni articoli"
      '
      'eui_cmdArchiviTabelleScaffali
      '
      Me.eui_cmdArchiviTabelleScaffali.Id = "73e60a2d-350f-47d3-9545-20effbe781de"
      Me.eui_cmdArchiviTabelleScaffali.KeyTip = "L"
      Me.eui_cmdArchiviTabelleScaffali.Location = New System.Drawing.Point(2, 214)
      Me.eui_cmdArchiviTabelleScaffali.Name = "eui_cmdArchiviTabelleScaffali"
      Me.eui_cmdArchiviTabelleScaffali.ScreenTip.Caption = "Scaffali"
      Me.eui_cmdArchiviTabelleScaffali.ScreenTip.Text = "Apre la tabella dati scaffali."
      Me.eui_cmdArchiviTabelleScaffali.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleScaffali.TabIndex = 12
      Me.eui_cmdArchiviTabelleScaffali.Text = "Scaffali"
      '
      'sepMagazzino
      '
      Me.sepMagazzino.Id = "da0fb479-de4c-4436-8880-d242264fc739"
      Me.sepMagazzino.Location = New System.Drawing.Point(2, 237)
      Me.sepMagazzino.Name = "sepMagazzino"
      Me.sepMagazzino.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepMagazzino.Size = New System.Drawing.Size(194, 5)
      Me.sepMagazzino.TabIndex = 13
      Me.sepMagazzino.Text = "Separator5"
      '
      'eui_cmdArchiviTabelleReparti
      '
      Me.eui_cmdArchiviTabelleReparti.Id = "60ec5086-cb08-429e-8b0d-3941f2b81dd1"
      Me.eui_cmdArchiviTabelleReparti.KeyTip = "R"
      Me.eui_cmdArchiviTabelleReparti.Location = New System.Drawing.Point(2, 242)
      Me.eui_cmdArchiviTabelleReparti.Name = "eui_cmdArchiviTabelleReparti"
      Me.eui_cmdArchiviTabelleReparti.ScreenTip.Caption = "Reparti"
      Me.eui_cmdArchiviTabelleReparti.ScreenTip.Text = "Apre la tabella dati reparti."
      Me.eui_cmdArchiviTabelleReparti.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleReparti.TabIndex = 14
      Me.eui_cmdArchiviTabelleReparti.Text = "Reparti"
      '
      'eui_cmdArchiviTabelleMsgReparti
      '
      Me.eui_cmdArchiviTabelleMsgReparti.Id = "89281fba-2e57-43ce-8d7e-4b937fdb9a48"
      Me.eui_cmdArchiviTabelleMsgReparti.KeyTip = "MR"
      Me.eui_cmdArchiviTabelleMsgReparti.Location = New System.Drawing.Point(2, 265)
      Me.eui_cmdArchiviTabelleMsgReparti.Name = "eui_cmdArchiviTabelleMsgReparti"
      Me.eui_cmdArchiviTabelleMsgReparti.ScreenTip.Caption = "Messaggi ai reparti"
      Me.eui_cmdArchiviTabelleMsgReparti.ScreenTip.Text = "Apre la tabella dati messaggi ai reparti."
      Me.eui_cmdArchiviTabelleMsgReparti.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleMsgReparti.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviTabelleMsgReparti.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviTabelleMsgReparti.TabIndex = 15
      Me.eui_cmdArchiviTabelleMsgReparti.Text = "Messaggi ai reparti"
      '
      'sepReparti
      '
      Me.sepReparti.Id = "e3bfc13a-0c16-4a6c-ac04-accd7559386a"
      Me.sepReparti.Location = New System.Drawing.Point(2, 288)
      Me.sepReparti.Name = "sepReparti"
      Me.sepReparti.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepReparti.Size = New System.Drawing.Size(194, 5)
      Me.sepReparti.TabIndex = 16
      Me.sepReparti.Text = "Separator6"
      '
      'eui_cmdArchiviTabelleCausaliDoc
      '
      Me.eui_cmdArchiviTabelleCausaliDoc.Id = "72822677-055c-45d1-bd50-bebe2b75f7db"
      Me.eui_cmdArchiviTabelleCausaliDoc.KeyTip = "D"
      Me.eui_cmdArchiviTabelleCausaliDoc.Location = New System.Drawing.Point(2, 293)
      Me.eui_cmdArchiviTabelleCausaliDoc.Name = "eui_cmdArchiviTabelleCausaliDoc"
      Me.eui_cmdArchiviTabelleCausaliDoc.ScreenTip.Caption = "Causali documento"
      Me.eui_cmdArchiviTabelleCausaliDoc.ScreenTip.Text = "Apre la tabella Causali documento."
      Me.eui_cmdArchiviTabelleCausaliDoc.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleCausaliDoc.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviTabelleCausaliDoc.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviTabelleCausaliDoc.TabIndex = 17
      Me.eui_cmdArchiviTabelleCausaliDoc.Text = "Causali documento"
      '
      'eui_cmdArchiviTabellePagamenti
      '
      Me.eui_cmdArchiviTabellePagamenti.Id = "7ed2cf63-f122-444c-8872-1d03eb7f0424"
      Me.eui_cmdArchiviTabellePagamenti.KeyTip = "P"
      Me.eui_cmdArchiviTabellePagamenti.Location = New System.Drawing.Point(2, 316)
      Me.eui_cmdArchiviTabellePagamenti.Name = "eui_cmdArchiviTabellePagamenti"
      Me.eui_cmdArchiviTabellePagamenti.ScreenTip.Caption = "Modalità di pagamento"
      Me.eui_cmdArchiviTabellePagamenti.ScreenTip.Text = "Apre la tabella dati Modalità di pagamento"
      Me.eui_cmdArchiviTabellePagamenti.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabellePagamenti.TabIndex = 18
      Me.eui_cmdArchiviTabellePagamenti.Text = "Modalità di pagamento"
      '
      'Separator8
      '
      Me.Separator8.Id = "0ad3c5b2-6ac0-450d-a422-ae9a2232b901"
      Me.Separator8.Location = New System.Drawing.Point(2, 339)
      Me.Separator8.Name = "Separator8"
      Me.Separator8.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator8.Size = New System.Drawing.Size(194, 5)
      Me.Separator8.TabIndex = 20
      Me.Separator8.Text = "Separator8"
      '
      'eui_cmdArchiviTabelleListini
      '
      Me.eui_cmdArchiviTabelleListini.Id = "bb29d2d5-c941-4a8f-90de-3c51cff7c3da"
      Me.eui_cmdArchiviTabelleListini.KeyTip = "L"
      Me.eui_cmdArchiviTabelleListini.Location = New System.Drawing.Point(2, 344)
      Me.eui_cmdArchiviTabelleListini.Name = "eui_cmdArchiviTabelleListini"
      Me.eui_cmdArchiviTabelleListini.ScreenTip.Caption = "Listini camere"
      Me.eui_cmdArchiviTabelleListini.ScreenTip.Text = "Apre la tabella dati listini."
      Me.PopupMenu3.SetShortcutKeyDisplayString(Me.eui_cmdArchiviTabelleListini, "CTRL+L")
      Me.PopupMenu3.SetShortcutKeys(Me.eui_cmdArchiviTabelleListini, CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.L), System.Windows.Forms.Keys))
      Me.eui_cmdArchiviTabelleListini.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleListini.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviTabelleListini.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviTabelleListini.TabIndex = 24
      Me.eui_cmdArchiviTabelleListini.Text = "Listini camere"
      '
      'eui_cmdArchiviTabelleStagioni
      '
      Me.eui_cmdArchiviTabelleStagioni.Id = "86931de7-ac3b-4630-852a-5026d1dcd891"
      Me.eui_cmdArchiviTabelleStagioni.KeyTip = "ST"
      Me.eui_cmdArchiviTabelleStagioni.Location = New System.Drawing.Point(2, 367)
      Me.eui_cmdArchiviTabelleStagioni.Name = "eui_cmdArchiviTabelleStagioni"
      Me.eui_cmdArchiviTabelleStagioni.ScreenTip.Caption = "Stagioni"
      Me.eui_cmdArchiviTabelleStagioni.ScreenTip.Text = "Apre la tabella dati stagioni."
      Me.eui_cmdArchiviTabelleStagioni.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleStagioni.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviTabelleStagioni.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviTabelleStagioni.TabIndex = 29
      Me.eui_cmdArchiviTabelleStagioni.Text = "Stagioni"
      '
      'eui_cmdArchiviTabelleTipologieCamere
      '
      Me.eui_cmdArchiviTabelleTipologieCamere.Id = "94bbf9a2-ad92-402a-b2da-3b4c3355a3de"
      Me.eui_cmdArchiviTabelleTipologieCamere.KeyTip = "G"
      Me.eui_cmdArchiviTabelleTipologieCamere.Location = New System.Drawing.Point(2, 390)
      Me.eui_cmdArchiviTabelleTipologieCamere.Name = "eui_cmdArchiviTabelleTipologieCamere"
      Me.eui_cmdArchiviTabelleTipologieCamere.ScreenTip.Caption = "Tipologie camere"
      Me.eui_cmdArchiviTabelleTipologieCamere.ScreenTip.Text = "Apre la tabella dati tipologie camere."
      Me.eui_cmdArchiviTabelleTipologieCamere.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleTipologieCamere.TabIndex = 25
      Me.eui_cmdArchiviTabelleTipologieCamere.Text = "Tipologie camere"
      '
      'eui_cmdArchiviTabelleUbicazioniCamere
      '
      Me.eui_cmdArchiviTabelleUbicazioniCamere.Id = "45736403-b4de-4c69-adcd-dc49b47ec18e"
      Me.eui_cmdArchiviTabelleUbicazioniCamere.KeyTip = "Z"
      Me.eui_cmdArchiviTabelleUbicazioniCamere.Location = New System.Drawing.Point(2, 413)
      Me.eui_cmdArchiviTabelleUbicazioniCamere.Name = "eui_cmdArchiviTabelleUbicazioniCamere"
      Me.eui_cmdArchiviTabelleUbicazioniCamere.ScreenTip.Caption = "Ubicazioni camere"
      Me.eui_cmdArchiviTabelleUbicazioniCamere.ScreenTip.Text = "Apre la tabella dati ubicazioni camere."
      Me.eui_cmdArchiviTabelleUbicazioniCamere.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleUbicazioniCamere.TabIndex = 26
      Me.eui_cmdArchiviTabelleUbicazioniCamere.Text = "Ubicazioni camere"
      '
      'eui_cmdArchiviTabellePosizioniCamere
      '
      Me.eui_cmdArchiviTabellePosizioniCamere.Id = "9602ab25-955b-4d8d-96cf-9f7f4b6db982"
      Me.eui_cmdArchiviTabellePosizioniCamere.KeyTip = "I"
      Me.eui_cmdArchiviTabellePosizioniCamere.Location = New System.Drawing.Point(2, 436)
      Me.eui_cmdArchiviTabellePosizioniCamere.Name = "eui_cmdArchiviTabellePosizioniCamere"
      Me.eui_cmdArchiviTabellePosizioniCamere.ScreenTip.Caption = "Posizioni camere"
      Me.eui_cmdArchiviTabellePosizioniCamere.ScreenTip.Text = "Apre la tabella dati posizioni camere."
      Me.eui_cmdArchiviTabellePosizioniCamere.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabellePosizioniCamere.TabIndex = 27
      Me.eui_cmdArchiviTabellePosizioniCamere.Text = "Posizioni camere"
      '
      'eui_cmdArchiviTabelleTipoAlloggiati
      '
      Me.eui_cmdArchiviTabelleTipoAlloggiati.Id = "a5654816-8048-4a0d-b133-0fd94c2b77ab"
      Me.eui_cmdArchiviTabelleTipoAlloggiati.KeyTip = "TA"
      Me.eui_cmdArchiviTabelleTipoAlloggiati.Location = New System.Drawing.Point(2, 459)
      Me.eui_cmdArchiviTabelleTipoAlloggiati.Name = "eui_cmdArchiviTabelleTipoAlloggiati"
      Me.eui_cmdArchiviTabelleTipoAlloggiati.ScreenTip.Caption = "Tipo alloggiati"
      Me.eui_cmdArchiviTabelleTipoAlloggiati.ScreenTip.Text = "Apre la tabella Tipo alloggiati."
      Me.eui_cmdArchiviTabelleTipoAlloggiati.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleTipoAlloggiati.TabIndex = 42
      Me.eui_cmdArchiviTabelleTipoAlloggiati.Text = "Tipo alloggiati"
      '
      'eui_cmdArchiviTabelleGruppi
      '
      Me.eui_cmdArchiviTabelleGruppi.Id = "c048b182-38c3-4574-bc4f-42833221ceb9"
      Me.eui_cmdArchiviTabelleGruppi.KeyTip = "G"
      Me.eui_cmdArchiviTabelleGruppi.Location = New System.Drawing.Point(2, 482)
      Me.eui_cmdArchiviTabelleGruppi.Name = "eui_cmdArchiviTabelleGruppi"
      Me.eui_cmdArchiviTabelleGruppi.ScreenTip.Caption = "Gruppi"
      Me.eui_cmdArchiviTabelleGruppi.ScreenTip.Text = "Apre la tabella dati Gruppi"
      Me.eui_cmdArchiviTabelleGruppi.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleGruppi.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviTabelleGruppi.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviTabelleGruppi.TabIndex = 37
      Me.eui_cmdArchiviTabelleGruppi.Text = "Gruppi"
      '
      'eui_cmdArchiviTabelleAgenzie
      '
      Me.eui_cmdArchiviTabelleAgenzie.Id = "c7458d91-16e5-44c1-a946-3291b5917663"
      Me.eui_cmdArchiviTabelleAgenzie.KeyTip = "AG"
      Me.eui_cmdArchiviTabelleAgenzie.Location = New System.Drawing.Point(2, 505)
      Me.eui_cmdArchiviTabelleAgenzie.Name = "eui_cmdArchiviTabelleAgenzie"
      Me.eui_cmdArchiviTabelleAgenzie.ScreenTip.Caption = "Agenzie"
      Me.eui_cmdArchiviTabelleAgenzie.ScreenTip.Text = "Apre la tabella dati Agenzie"
      Me.eui_cmdArchiviTabelleAgenzie.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleAgenzie.TabIndex = 38
      Me.eui_cmdArchiviTabelleAgenzie.Text = "Agenzie"
      '
      'eui_cmdArchiviTabelleCanali
      '
      Me.eui_cmdArchiviTabelleCanali.Id = "78505507-1a73-4ea0-9e94-3fb8965c9f5c"
      Me.eui_cmdArchiviTabelleCanali.KeyTip = "CP"
      Me.eui_cmdArchiviTabelleCanali.Location = New System.Drawing.Point(2, 528)
      Me.eui_cmdArchiviTabelleCanali.Name = "eui_cmdArchiviTabelleCanali"
      Me.eui_cmdArchiviTabelleCanali.ScreenTip.Caption = "Canali di provenienza"
      Me.eui_cmdArchiviTabelleCanali.ScreenTip.Text = "Apre la tabella dati Canali di provenienza"
      Me.eui_cmdArchiviTabelleCanali.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleCanali.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviTabelleCanali.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviTabelleCanali.TabIndex = 39
      Me.eui_cmdArchiviTabelleCanali.Text = "Canali di provenienza"
      '
      'sepListini
      '
      Me.sepListini.Id = "6b100059-3282-4af3-85d4-eb04fc0260f5"
      Me.sepListini.Location = New System.Drawing.Point(2, 551)
      Me.sepListini.Name = "sepListini"
      Me.sepListini.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepListini.Size = New System.Drawing.Size(194, 5)
      Me.sepListini.TabIndex = 23
      Me.sepListini.Text = "Separator3"
      '
      'eui_cmdArchiviTabelleStatoPren
      '
      Me.eui_cmdArchiviTabelleStatoPren.Id = "a703ba35-3307-49a0-a495-226bdda2dab7"
      Me.eui_cmdArchiviTabelleStatoPren.KeyTip = "SP"
      Me.eui_cmdArchiviTabelleStatoPren.Location = New System.Drawing.Point(2, 556)
      Me.eui_cmdArchiviTabelleStatoPren.Name = "eui_cmdArchiviTabelleStatoPren"
      Me.eui_cmdArchiviTabelleStatoPren.ScreenTip.Caption = "Stato prenotazioni"
      Me.eui_cmdArchiviTabelleStatoPren.ScreenTip.Text = "Apre la tabella dati stato prenotazioni."
      Me.eui_cmdArchiviTabelleStatoPren.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleStatoPren.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviTabelleStatoPren.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviTabelleStatoPren.TabIndex = 31
      Me.eui_cmdArchiviTabelleStatoPren.Text = "Stato prenotazioni"
      '
      'sepStatoPren
      '
      Me.sepStatoPren.Id = "eaf278bb-56aa-4571-9f61-237861ac389b"
      Me.sepStatoPren.Location = New System.Drawing.Point(2, 579)
      Me.sepStatoPren.Name = "sepStatoPren"
      Me.sepStatoPren.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.sepStatoPren.Size = New System.Drawing.Size(194, 5)
      Me.sepStatoPren.TabIndex = 32
      Me.sepStatoPren.Text = "Separator22"
      '
      'eui_cmdArchiviTabelleDocIdentità
      '
      Me.eui_cmdArchiviTabelleDocIdentità.Id = "4c1a5984-0b55-444d-9f0a-e7fed8fb2d7f"
      Me.eui_cmdArchiviTabelleDocIdentità.KeyTip = "DI"
      Me.eui_cmdArchiviTabelleDocIdentità.Location = New System.Drawing.Point(2, 584)
      Me.eui_cmdArchiviTabelleDocIdentità.Name = "eui_cmdArchiviTabelleDocIdentità"
      Me.eui_cmdArchiviTabelleDocIdentità.ScreenTip.Caption = "Documenti d'identità"
      Me.eui_cmdArchiviTabelleDocIdentità.ScreenTip.Text = "Apre la tabella dati documenti d'identità."
      Me.eui_cmdArchiviTabelleDocIdentità.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleDocIdentità.TabIndex = 34
      Me.eui_cmdArchiviTabelleDocIdentità.Text = "Documenti d'identità"
      '
      'Separator24
      '
      Me.Separator24.Id = "7537d85d-aceb-4ee4-a412-c7c19e20f6d8"
      Me.Separator24.Location = New System.Drawing.Point(2, 607)
      Me.Separator24.Name = "Separator24"
      Me.Separator24.Orientation = Elegant.Ui.SeparatorOrientation.Horizontal
      Me.Separator24.Size = New System.Drawing.Size(194, 5)
      Me.Separator24.TabIndex = 35
      Me.Separator24.Text = "Separator24"
      '
      'eui_cmdArchiviTabelleTipoRisorse
      '
      Me.eui_cmdArchiviTabelleTipoRisorse.Id = "56b63c25-3179-48dc-80e3-7136b9fb3c01"
      Me.eui_cmdArchiviTabelleTipoRisorse.KeyTip = "O"
      Me.eui_cmdArchiviTabelleTipoRisorse.Location = New System.Drawing.Point(2, 612)
      Me.eui_cmdArchiviTabelleTipoRisorse.Name = "eui_cmdArchiviTabelleTipoRisorse"
      Me.eui_cmdArchiviTabelleTipoRisorse.ScreenTip.Caption = "Tipologie risorse"
      Me.eui_cmdArchiviTabelleTipoRisorse.ScreenTip.Text = "Apre la tabella dati tipologie risorse."
      Me.eui_cmdArchiviTabelleTipoRisorse.Size = New System.Drawing.Size(194, 23)
      Me.eui_cmdArchiviTabelleTipoRisorse.TabIndex = 21
      Me.eui_cmdArchiviTabelleTipoRisorse.Text = "Tipologie risorse"
      '
      'RibbonGroup1
      '
      Me.RibbonGroup1.Controls.Add(Me.eui_cmdArchiviImporta)
      Me.RibbonGroup1.Controls.Add(Me.eui_cmdArchiviBackup)
      Me.RibbonGroup1.Controls.Add(Me.eui_cmdArchiviPulizia)
      Me.RibbonGroup1.Controls.Add(Me.eui_cmdArchiviCompatta)
      Me.RibbonGroup1.DialogLauncherButtonVisible = False
      Me.RibbonGroup1.Location = New System.Drawing.Point(154, 1)
      Me.RibbonGroup1.Name = "RibbonGroup1"
      Me.RibbonGroup1.Size = New System.Drawing.Size(259, 94)
      Me.RibbonGroup1.TabIndex = 2
      Me.RibbonGroup1.Text = "Strumenti"
      '
      'eui_cmdArchiviImporta
      '
      Me.eui_cmdArchiviImporta.Id = "c178a5ef-e947-46ac-8dfc-abc23a9e4f34"
      Me.eui_cmdArchiviImporta.KeyTip = "I"
      Me.eui_cmdArchiviImporta.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviImporta.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviImporta.Location = New System.Drawing.Point(60, 2)
      Me.eui_cmdArchiviImporta.Name = "eui_cmdArchiviImporta"
      Me.eui_cmdArchiviImporta.ScreenTip.Caption = "Importa dati"
      Me.eui_cmdArchiviImporta.ScreenTip.Text = "Consente di importare dati da altri archivi."
      Me.eui_cmdArchiviImporta.Size = New System.Drawing.Size(64, 0)
      Me.eui_cmdArchiviImporta.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviImporta.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviImporta.TabIndex = 0
      Me.eui_cmdArchiviImporta.Text = "Importa dati"
      Me.eui_cmdArchiviImporta.Visible = False
      '
      'eui_cmdArchiviBackup
      '
      Me.eui_cmdArchiviBackup.Id = "e8fb8df1-ef53-4d07-b79c-07bdd519fb5f"
      Me.eui_cmdArchiviBackup.KeyTip = "B"
      Me.eui_cmdArchiviBackup.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviBackup.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviBackup.Location = New System.Drawing.Point(60, 2)
      Me.eui_cmdArchiviBackup.Name = "eui_cmdArchiviBackup"
      Me.eui_cmdArchiviBackup.ScreenTip.Caption = "Backup dei dati"
      Me.eui_cmdArchiviBackup.ScreenTip.Text = "Consente di effettuare copie di sicurezza degli archivi."
      Me.eui_cmdArchiviBackup.Size = New System.Drawing.Size(83, 0)
      Me.eui_cmdArchiviBackup.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviBackup.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviBackup.TabIndex = 1
      Me.eui_cmdArchiviBackup.Text = "Backup dei dati"
      '
      'eui_cmdArchiviPulizia
      '
      Me.eui_cmdArchiviPulizia.Id = "2f3faba2-356f-4602-a694-0de53831137b"
      Me.eui_cmdArchiviPulizia.KeyTip = "P"
      Me.eui_cmdArchiviPulizia.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviPulizia.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviPulizia.Location = New System.Drawing.Point(60, 2)
      Me.eui_cmdArchiviPulizia.Name = "eui_cmdArchiviPulizia"
      Me.eui_cmdArchiviPulizia.ScreenTip.Caption = "Pulizia degli archivi"
      Me.eui_cmdArchiviPulizia.ScreenTip.Text = "Consente di effettuare l'eliminazione dei dati per singola tabella presenti negli" &
    " archivi."
      Me.eui_cmdArchiviPulizia.Size = New System.Drawing.Size(98, 0)
      Me.eui_cmdArchiviPulizia.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviPulizia.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviPulizia.TabIndex = 2
      Me.eui_cmdArchiviPulizia.Text = "Pulizia degli archivi"
      '
      'eui_cmdArchiviCompatta
      '
      Me.eui_cmdArchiviCompatta.Id = "e849859a-d3f9-484a-a494-6ecad6c05a46"
      Me.eui_cmdArchiviCompatta.KeyTip = "C"
      Me.eui_cmdArchiviCompatta.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviCompatta.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviCompatta.Location = New System.Drawing.Point(60, 2)
      Me.eui_cmdArchiviCompatta.Name = "eui_cmdArchiviCompatta"
      Me.eui_cmdArchiviCompatta.ScreenTip.Caption = "Compatta e ripristina archivi"
      Me.eui_cmdArchiviCompatta.ScreenTip.Text = "Consente di effettuare la compattazione e il ripristino degli archivi."
      Me.eui_cmdArchiviCompatta.Size = New System.Drawing.Size(138, 0)
      Me.eui_cmdArchiviCompatta.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdArchiviCompatta.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdArchiviCompatta.TabIndex = 3
      Me.eui_cmdArchiviCompatta.Text = "Compatta e ripristina archivi"
      '
      'eui_Contabilità
      '
      Me.eui_Contabilità.Controls.Add(Me.RibbonGroup6)
      Me.eui_Contabilità.Controls.Add(Me.RibbonGroup7)
      Me.eui_Contabilità.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_Contabilità.KeyTip = "C"
      Me.eui_Contabilità.Location = New System.Drawing.Point(0, 0)
      Me.eui_Contabilità.Name = "eui_Contabilità"
      Me.eui_Contabilità.Size = New System.Drawing.Size(1365, 99)
      Me.eui_Contabilità.TabIndex = 0
      Me.eui_Contabilità.Text = "Contabilità"
      '
      'RibbonGroup6
      '
      Me.RibbonGroup6.Controls.Add(Me.eui_ContabilitàChiusura)
      Me.RibbonGroup6.Controls.Add(Me.eui_ContabilitàCorrispettivi)
      Me.RibbonGroup6.Controls.Add(Me.eui_ContabilitàPrimaNota)
      Me.RibbonGroup6.DialogLauncherButtonVisible = False
      Me.RibbonGroup6.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup6.Name = "RibbonGroup6"
      Me.RibbonGroup6.Size = New System.Drawing.Size(181, 94)
      Me.RibbonGroup6.TabIndex = 0
      Me.RibbonGroup6.Text = "Contabilità"
      '
      'eui_ContabilitàChiusura
      '
      Me.eui_ContabilitàChiusura.Id = "02cceaf6-7699-4844-9fbc-2dda03a2334a"
      Me.eui_ContabilitàChiusura.KeyTip = "C"
      Me.eui_ContabilitàChiusura.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ContabilitàChiusura.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_ContabilitàChiusura.Location = New System.Drawing.Point(39, 2)
      Me.eui_ContabilitàChiusura.Name = "eui_ContabilitàChiusura"
      Me.eui_ContabilitàChiusura.ScreenTip.Caption = "Chiusura giornaliera"
      Me.eui_ContabilitàChiusura.ScreenTip.Text = "Consente di effettuare la chiusura giornaliera di tutti i documenti emessi."
      Me.eui_ContabilitàChiusura.Size = New System.Drawing.Size(101, 0)
      Me.eui_ContabilitàChiusura.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ContabilitàChiusura.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_ContabilitàChiusura.TabIndex = 0
      Me.eui_ContabilitàChiusura.Text = "&Chiusura giornaliera"
      '
      'eui_ContabilitàCorrispettivi
      '
      Me.eui_ContabilitàCorrispettivi.Id = "2bd98b42-e17d-4dcc-853c-5d173b4c7626"
      Me.eui_ContabilitàCorrispettivi.KeyTip = "EC"
      Me.eui_ContabilitàCorrispettivi.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ContabilitàCorrispettivi.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_ContabilitàCorrispettivi.Location = New System.Drawing.Point(39, 2)
      Me.eui_ContabilitàCorrispettivi.Name = "eui_ContabilitàCorrispettivi"
      Me.eui_ContabilitàCorrispettivi.ScreenTip.Caption = "Elenco corrispettivi"
      Me.eui_ContabilitàCorrispettivi.ScreenTip.Text = "Apre l'elenco dei corrispettivi."
      Me.eui_ContabilitàCorrispettivi.Size = New System.Drawing.Size(98, 0)
      Me.eui_ContabilitàCorrispettivi.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ContabilitàCorrispettivi.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_ContabilitàCorrispettivi.TabIndex = 1
      Me.eui_ContabilitàCorrispettivi.Text = "Elenco corrispettivi"
      '
      'eui_ContabilitàPrimaNota
      '
      Me.eui_ContabilitàPrimaNota.Id = "9123d526-1bd0-4eb8-ad21-2304770e02df"
      Me.eui_ContabilitàPrimaNota.KeyTip = "P"
      Me.eui_ContabilitàPrimaNota.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ContabilitàPrimaNota.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_ContabilitàPrimaNota.Location = New System.Drawing.Point(39, 2)
      Me.eui_ContabilitàPrimaNota.Name = "eui_ContabilitàPrimaNota"
      Me.eui_ContabilitàPrimaNota.ScreenTip.Caption = "Prima nota"
      Me.eui_ContabilitàPrimaNota.ScreenTip.Text = "Apre la prima nota."
      Me.eui_ContabilitàPrimaNota.Size = New System.Drawing.Size(59, 0)
      Me.eui_ContabilitàPrimaNota.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ContabilitàPrimaNota.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_ContabilitàPrimaNota.TabIndex = 2
      Me.eui_ContabilitàPrimaNota.Text = "Prima nota"
      '
      'RibbonGroup7
      '
      Me.RibbonGroup7.Controls.Add(Me.eui_ContabilitàElencoDocVendita)
      Me.RibbonGroup7.Controls.Add(Me.eui_ContabilitàElencoDocAcquisto)
      Me.RibbonGroup7.DialogLauncherButtonVisible = False
      Me.RibbonGroup7.Location = New System.Drawing.Point(186, 1)
      Me.RibbonGroup7.Name = "RibbonGroup7"
      Me.RibbonGroup7.Size = New System.Drawing.Size(211, 94)
      Me.RibbonGroup7.TabIndex = 1
      Me.RibbonGroup7.Text = "Documenti"
      '
      'eui_ContabilitàElencoDocVendita
      '
      Me.eui_ContabilitàElencoDocVendita.Id = "f464d62a-2801-450a-b02b-c8a029dfdfc5"
      Me.eui_ContabilitàElencoDocVendita.KeyTip = "ED"
      Me.eui_ContabilitàElencoDocVendita.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ContabilitàElencoDocVendita.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_ContabilitàElencoDocVendita.Location = New System.Drawing.Point(31, 2)
      Me.eui_ContabilitàElencoDocVendita.Name = "eui_ContabilitàElencoDocVendita"
      Me.eui_ContabilitàElencoDocVendita.ScreenTip.Caption = "Elenco documenti emessi"
      Me.eui_ContabilitàElencoDocVendita.ScreenTip.Text = "Apre l'elenco documenti emessi."
      Me.eui_ContabilitàElencoDocVendita.Size = New System.Drawing.Size(143, 0)
      Me.eui_ContabilitàElencoDocVendita.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ContabilitàElencoDocVendita.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_ContabilitàElencoDocVendita.TabIndex = 0
      Me.eui_ContabilitàElencoDocVendita.Text = "Elenco documenti di vendita"
      '
      'eui_ContabilitàElencoDocAcquisto
      '
      Me.eui_ContabilitàElencoDocAcquisto.Id = "926c3acd-3e39-4204-9bfe-a4c397a993b5"
      Me.eui_ContabilitàElencoDocAcquisto.KeyTip = "EA"
      Me.eui_ContabilitàElencoDocAcquisto.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ContabilitàElencoDocAcquisto.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_ContabilitàElencoDocAcquisto.Location = New System.Drawing.Point(31, 2)
      Me.eui_ContabilitàElencoDocAcquisto.Name = "eui_ContabilitàElencoDocAcquisto"
      Me.eui_ContabilitàElencoDocAcquisto.ScreenTip.Caption = "Elenco Acquisti"
      Me.eui_ContabilitàElencoDocAcquisto.ScreenTip.Text = "Apre l'elenco degli acquisti effettuati."
      Me.eui_ContabilitàElencoDocAcquisto.Size = New System.Drawing.Size(148, 0)
      Me.eui_ContabilitàElencoDocAcquisto.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_ContabilitàElencoDocAcquisto.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_ContabilitàElencoDocAcquisto.TabIndex = 1
      Me.eui_ContabilitàElencoDocAcquisto.Text = "Elenco documenti di acquisto"
      '
      'eui_Magazzino
      '
      Me.eui_Magazzino.Controls.Add(Me.RibbonGroup8)
      Me.eui_Magazzino.Controls.Add(Me.RibbonGroup9)
      Me.eui_Magazzino.Controls.Add(Me.RibbonGroup11)
      Me.eui_Magazzino.Controls.Add(Me.RibbonGroup12)
      Me.eui_Magazzino.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_Magazzino.KeyTip = "M"
      Me.eui_Magazzino.Location = New System.Drawing.Point(0, 0)
      Me.eui_Magazzino.Name = "eui_Magazzino"
      Me.eui_Magazzino.Size = New System.Drawing.Size(1276, 99)
      Me.eui_Magazzino.TabIndex = 0
      Me.eui_Magazzino.Text = "Magazzino"
      '
      'RibbonGroup8
      '
      Me.RibbonGroup8.Controls.Add(Me.eui_MagazzinoArticoli)
      Me.RibbonGroup8.DialogLauncherButtonVisible = False
      Me.RibbonGroup8.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup8.Name = "RibbonGroup8"
      Me.RibbonGroup8.Size = New System.Drawing.Size(87, 0)
      Me.RibbonGroup8.TabIndex = 0
      Me.RibbonGroup8.Text = "Articoli"
      '
      'eui_MagazzinoArticoli
      '
      Me.eui_MagazzinoArticoli.Id = "879e6654-2a6d-4108-b4e2-05a2f7e7039b"
      Me.eui_MagazzinoArticoli.KeyTip = "A"
      Me.eui_MagazzinoArticoli.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_MagazzinoArticoli.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_MagazzinoArticoli.Location = New System.Drawing.Point(4, 2)
      Me.eui_MagazzinoArticoli.Name = "eui_MagazzinoArticoli"
      Me.eui_MagazzinoArticoli.ScreenTip.Caption = "Elenco articoli e ingredienti"
      Me.eui_MagazzinoArticoli.ScreenTip.Text = "Apre l'elenco articoli e ingredienti."
      Me.eui_MagazzinoArticoli.Size = New System.Drawing.Size(135, 0)
      Me.eui_MagazzinoArticoli.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_MagazzinoArticoli.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_MagazzinoArticoli.TabIndex = 0
      Me.eui_MagazzinoArticoli.Text = "Elenco articoli e ingredienti"
      '
      'RibbonGroup9
      '
      Me.RibbonGroup9.Controls.Add(Me.eui_MagazzinoMovimenti)
      Me.RibbonGroup9.DialogLauncherButtonVisible = False
      Me.RibbonGroup9.Location = New System.Drawing.Point(92, 1)
      Me.RibbonGroup9.Name = "RibbonGroup9"
      Me.RibbonGroup9.Size = New System.Drawing.Size(87, 0)
      Me.RibbonGroup9.TabIndex = 1
      Me.RibbonGroup9.Text = "Movimenti"
      '
      'eui_MagazzinoMovimenti
      '
      Me.eui_MagazzinoMovimenti.Id = "2a6cfd68-50a1-43f6-936f-9274349a7241"
      Me.eui_MagazzinoMovimenti.KeyTip = "M"
      Me.eui_MagazzinoMovimenti.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_MagazzinoMovimenti.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_MagazzinoMovimenti.Location = New System.Drawing.Point(4, 2)
      Me.eui_MagazzinoMovimenti.Name = "eui_MagazzinoMovimenti"
      Me.eui_MagazzinoMovimenti.ScreenTip.Caption = "Elenco storico movimenti"
      Me.eui_MagazzinoMovimenti.ScreenTip.Text = "Apre l'elenco storico dei movimenti di magazzino."
      Me.eui_MagazzinoMovimenti.Size = New System.Drawing.Size(126, 0)
      Me.eui_MagazzinoMovimenti.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_MagazzinoMovimenti.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_MagazzinoMovimenti.TabIndex = 0
      Me.eui_MagazzinoMovimenti.Text = "Elenco storico movimenti"
      '
      'RibbonGroup11
      '
      Me.RibbonGroup11.Controls.Add(Me.eui_MagazzinoInventario)
      Me.RibbonGroup11.DialogLauncherButtonVisible = False
      Me.RibbonGroup11.Location = New System.Drawing.Point(179, 1)
      Me.RibbonGroup11.Name = "RibbonGroup11"
      Me.RibbonGroup11.Size = New System.Drawing.Size(73, 0)
      Me.RibbonGroup11.TabIndex = 2
      Me.RibbonGroup11.Text = "Inventario"
      '
      'eui_MagazzinoInventario
      '
      Me.eui_MagazzinoInventario.Id = "40270539-b4fa-4ab7-b6d0-f5ee8bbf3f9c"
      Me.eui_MagazzinoInventario.KeyTip = "I"
      Me.eui_MagazzinoInventario.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_MagazzinoInventario.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_MagazzinoInventario.Location = New System.Drawing.Point(4, 2)
      Me.eui_MagazzinoInventario.Name = "eui_MagazzinoInventario"
      Me.eui_MagazzinoInventario.ScreenTip.Caption = "Elenco inventario"
      Me.eui_MagazzinoInventario.ScreenTip.Text = "Apre l'elenco inventario di magazzino."
      Me.eui_MagazzinoInventario.Size = New System.Drawing.Size(91, 0)
      Me.eui_MagazzinoInventario.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_MagazzinoInventario.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_MagazzinoInventario.TabIndex = 0
      Me.eui_MagazzinoInventario.Text = "Elenco inventario"
      '
      'RibbonGroup12
      '
      Me.RibbonGroup12.Controls.Add(Me.eui_MagazzinoScorte)
      Me.RibbonGroup12.DialogLauncherButtonVisible = False
      Me.RibbonGroup12.Location = New System.Drawing.Point(252, 1)
      Me.RibbonGroup12.Name = "RibbonGroup12"
      Me.RibbonGroup12.Size = New System.Drawing.Size(101, 0)
      Me.RibbonGroup12.TabIndex = 3
      Me.RibbonGroup12.Text = "Scorte"
      '
      'eui_MagazzinoScorte
      '
      Me.eui_MagazzinoScorte.Id = "77ae25cc-1aed-4ec4-93f9-b06abf3c8a16"
      Me.eui_MagazzinoScorte.KeyTip = "S"
      Me.eui_MagazzinoScorte.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_MagazzinoScorte.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_MagazzinoScorte.Location = New System.Drawing.Point(4, 2)
      Me.eui_MagazzinoScorte.Name = "eui_MagazzinoScorte"
      Me.eui_MagazzinoScorte.ScreenTip.Caption = "Elenco situazione scorte"
      Me.eui_MagazzinoScorte.ScreenTip.Text = "Apre l'elenco della situazione scorte."
      Me.eui_MagazzinoScorte.Size = New System.Drawing.Size(124, 0)
      Me.eui_MagazzinoScorte.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_MagazzinoScorte.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_MagazzinoScorte.TabIndex = 0
      Me.eui_MagazzinoScorte.Text = "Elenco situazione scorte"
      '
      'eui_Visualizza
      '
      Me.eui_Visualizza.Controls.Add(Me.RibbonGroup10)
      Me.eui_Visualizza.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_Visualizza.KeyTip = "V"
      Me.eui_Visualizza.Location = New System.Drawing.Point(0, 0)
      Me.eui_Visualizza.Name = "eui_Visualizza"
      Me.eui_Visualizza.Size = New System.Drawing.Size(1276, 99)
      Me.eui_Visualizza.TabIndex = 0
      Me.eui_Visualizza.Text = "Visualizza"
      '
      'RibbonGroup10
      '
      Me.RibbonGroup10.Controls.Add(Me.eui_VisualizzaRegOperazioni)
      Me.RibbonGroup10.Controls.Add(Me.eui_VisualizzaRegErrori)
      Me.RibbonGroup10.DialogLauncherButtonVisible = False
      Me.RibbonGroup10.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup10.Name = "RibbonGroup10"
      Me.RibbonGroup10.Size = New System.Drawing.Size(147, 0)
      Me.RibbonGroup10.TabIndex = 0
      Me.RibbonGroup10.Text = "Visualizza"
      '
      'eui_VisualizzaRegOperazioni
      '
      Me.eui_VisualizzaRegOperazioni.Id = "e9aaf299-3f98-44ac-a698-337d1864f881"
      Me.eui_VisualizzaRegOperazioni.KeyTip = "O"
      Me.eui_VisualizzaRegOperazioni.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_VisualizzaRegOperazioni.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_VisualizzaRegOperazioni.Location = New System.Drawing.Point(11, 2)
      Me.eui_VisualizzaRegOperazioni.Name = "eui_VisualizzaRegOperazioni"
      Me.eui_VisualizzaRegOperazioni.ScreenTip.Caption = "Registro delle operazioni"
      Me.eui_VisualizzaRegOperazioni.ScreenTip.Text = "Apre il registro delle operazioni effettuate dagli operatori."
      Me.eui_VisualizzaRegOperazioni.Size = New System.Drawing.Size(124, 0)
      Me.eui_VisualizzaRegOperazioni.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_VisualizzaRegOperazioni.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_VisualizzaRegOperazioni.TabIndex = 0
      Me.eui_VisualizzaRegOperazioni.Text = "Registro delle operazioni"
      '
      'eui_VisualizzaRegErrori
      '
      Me.eui_VisualizzaRegErrori.Id = "2e01eadd-d861-47aa-958e-944bd4e39ef9"
      Me.eui_VisualizzaRegErrori.KeyTip = "E"
      Me.eui_VisualizzaRegErrori.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_VisualizzaRegErrori.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_VisualizzaRegErrori.Location = New System.Drawing.Point(11, 2)
      Me.eui_VisualizzaRegErrori.Name = "eui_VisualizzaRegErrori"
      Me.eui_VisualizzaRegErrori.ScreenTip.Caption = "Registro degli errori"
      Me.eui_VisualizzaRegErrori.ScreenTip.Text = "Apre il registro degli errori generati dal programma."
      Me.eui_VisualizzaRegErrori.Size = New System.Drawing.Size(99, 0)
      Me.eui_VisualizzaRegErrori.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_VisualizzaRegErrori.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_VisualizzaRegErrori.TabIndex = 1
      Me.eui_VisualizzaRegErrori.Text = "Registro degli errori"
      '
      'eui_Strumenti
      '
      Me.eui_Strumenti.Controls.Add(Me.RibbonGroup28)
      Me.eui_Strumenti.Controls.Add(Me.eui_GruppoReparti)
      Me.eui_Strumenti.Controls.Add(Me.eui_GruppoEtichette)
      Me.eui_Strumenti.Controls.Add(Me.RibbonGroup19)
      Me.eui_Strumenti.Controls.Add(Me.eui_GruppoTavoli)
      Me.eui_Strumenti.Controls.Add(Me.eui_GruppoMenu)
      Me.eui_Strumenti.Controls.Add(Me.RibbonGroup22)
      Me.eui_Strumenti.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_Strumenti.KeyTip = "S"
      Me.eui_Strumenti.Location = New System.Drawing.Point(0, 0)
      Me.eui_Strumenti.Name = "eui_Strumenti"
      Me.eui_Strumenti.Size = New System.Drawing.Size(1054, 99)
      Me.eui_Strumenti.TabIndex = 0
      Me.eui_Strumenti.Text = "Strumenti"
      '
      'RibbonGroup28
      '
      Me.RibbonGroup28.Controls.Add(Me.eui_StrumentiEmail)
      Me.RibbonGroup28.DialogLauncherButtonVisible = False
      Me.RibbonGroup28.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup28.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup28.Name = "RibbonGroup28"
      Me.RibbonGroup28.Size = New System.Drawing.Size(85, 0)
      Me.RibbonGroup28.TabIndex = 6
      Me.RibbonGroup28.Text = "E-mail"
      '
      'eui_StrumentiEmail
      '
      Me.eui_StrumentiEmail.Id = "c96374e1-ab37-4131-a717-90a4726e6ef3"
      Me.eui_StrumentiEmail.KeyTip = "I"
      Me.eui_StrumentiEmail.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiEmail.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiEmail.Location = New System.Drawing.Point(4, 2)
      Me.eui_StrumentiEmail.Name = "eui_StrumentiEmail"
      Me.eui_StrumentiEmail.ScreenTip.Caption = "Elenco E-mail inviate"
      Me.eui_StrumentiEmail.ScreenTip.Text = "Apre l'elenco delle e-mail inviate dal programma."
      Me.eui_StrumentiEmail.Size = New System.Drawing.Size(107, 0)
      Me.eui_StrumentiEmail.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiEmail.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiEmail.TabIndex = 0
      Me.eui_StrumentiEmail.Text = "Elenco E-mail inviate"
      '
      'eui_GruppoReparti
      '
      Me.eui_GruppoReparti.Controls.Add(Me.eui_StrumentiMsgReparti)
      Me.eui_GruppoReparti.DialogLauncherButtonVisible = False
      Me.eui_GruppoReparti.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_GruppoReparti.KeyTip = "M"
      Me.eui_GruppoReparti.Location = New System.Drawing.Point(90, 1)
      Me.eui_GruppoReparti.Name = "eui_GruppoReparti"
      Me.eui_GruppoReparti.Size = New System.Drawing.Size(101, 0)
      Me.eui_GruppoReparti.TabIndex = 0
      Me.eui_GruppoReparti.Text = "Reparti"
      '
      'eui_StrumentiMsgReparti
      '
      Me.eui_StrumentiMsgReparti.Id = "77f68155-9b9e-42a3-b74f-d8d78d1ca38e"
      Me.eui_StrumentiMsgReparti.KeyTip = "M"
      Me.eui_StrumentiMsgReparti.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiMsgReparti.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiMsgReparti.Location = New System.Drawing.Point(4, 2)
      Me.eui_StrumentiMsgReparti.Name = "eui_StrumentiMsgReparti"
      Me.eui_StrumentiMsgReparti.ScreenTip.Caption = "Elenco messaggi ai reparti"
      Me.eui_StrumentiMsgReparti.ScreenTip.Text = "Apre l'elenco dei messaggi inviati ai reparti."
      Me.eui_StrumentiMsgReparti.Size = New System.Drawing.Size(132, 0)
      Me.eui_StrumentiMsgReparti.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiMsgReparti.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiMsgReparti.TabIndex = 0
      Me.eui_StrumentiMsgReparti.Text = "Elenco messaggi ai reparti"
      '
      'eui_GruppoEtichette
      '
      Me.eui_GruppoEtichette.Controls.Add(Me.eui_StrumentiEtichette)
      Me.eui_GruppoEtichette.DialogLauncherButtonVisible = False
      Me.eui_GruppoEtichette.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_GruppoEtichette.Location = New System.Drawing.Point(191, 1)
      Me.eui_GruppoEtichette.Name = "eui_GruppoEtichette"
      Me.eui_GruppoEtichette.Size = New System.Drawing.Size(97, 0)
      Me.eui_GruppoEtichette.TabIndex = 1
      Me.eui_GruppoEtichette.Text = "Etichette"
      '
      'eui_StrumentiEtichette
      '
      Me.eui_StrumentiEtichette.Id = "2455fb3e-07d0-44cd-a59d-c26638220984"
      Me.eui_StrumentiEtichette.KeyTip = "E"
      Me.eui_StrumentiEtichette.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiEtichette.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiEtichette.Location = New System.Drawing.Point(4, 2)
      Me.eui_StrumentiEtichette.Name = "eui_StrumentiEtichette"
      Me.eui_StrumentiEtichette.ScreenTip.Caption = "Elenco etichette e codici a barre"
      Me.eui_StrumentiEtichette.ScreenTip.Text = "Apre l'elenco delle etichette per gli indirizzi e i codici a barre."
      Me.eui_StrumentiEtichette.Size = New System.Drawing.Size(162, 0)
      Me.eui_StrumentiEtichette.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiEtichette.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiEtichette.TabIndex = 0
      Me.eui_StrumentiEtichette.Text = "Elenco etichette e codici a barre"
      '
      'RibbonGroup19
      '
      Me.RibbonGroup19.Controls.Add(Me.eui_StrumentiCap)
      Me.RibbonGroup19.DialogLauncherButtonVisible = False
      Me.RibbonGroup19.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup19.Location = New System.Drawing.Point(288, 1)
      Me.RibbonGroup19.Name = "RibbonGroup19"
      Me.RibbonGroup19.Size = New System.Drawing.Size(91, 0)
      Me.RibbonGroup19.TabIndex = 2
      Me.RibbonGroup19.Text = "Comuni"
      '
      'eui_StrumentiCap
      '
      Me.eui_StrumentiCap.Id = "46bd2427-66f0-4586-bd4d-ef789225e679"
      Me.eui_StrumentiCap.KeyTip = "A"
      Me.eui_StrumentiCap.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiCap.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiCap.Location = New System.Drawing.Point(4, 2)
      Me.eui_StrumentiCap.Name = "eui_StrumentiCap"
      Me.eui_StrumentiCap.ScreenTip.Caption = "Elenco Comuni e CAP"
      Me.eui_StrumentiCap.ScreenTip.Text = "Apre l'elenco dei comuni italiani con una serie di dati informativi."
      Me.eui_StrumentiCap.Size = New System.Drawing.Size(113, 0)
      Me.eui_StrumentiCap.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiCap.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiCap.TabIndex = 0
      Me.eui_StrumentiCap.Text = "Elenco Comuni e CAP"
      '
      'eui_GruppoTavoli
      '
      Me.eui_GruppoTavoli.Controls.Add(Me.eui_StrumentiDispTavoli)
      Me.eui_GruppoTavoli.DialogLauncherButtonVisible = False
      Me.eui_GruppoTavoli.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_GruppoTavoli.Location = New System.Drawing.Point(379, 1)
      Me.eui_GruppoTavoli.Name = "eui_GruppoTavoli"
      Me.eui_GruppoTavoli.Size = New System.Drawing.Size(79, 0)
      Me.eui_GruppoTavoli.TabIndex = 3
      Me.eui_GruppoTavoli.Text = "Tavoli"
      '
      'eui_StrumentiDispTavoli
      '
      Me.eui_StrumentiDispTavoli.Id = "779f5b54-04a5-4117-852c-fbc488e5a93b"
      Me.eui_StrumentiDispTavoli.KeyTip = "D"
      Me.eui_StrumentiDispTavoli.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiDispTavoli.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiDispTavoli.Location = New System.Drawing.Point(4, 2)
      Me.eui_StrumentiDispTavoli.Name = "eui_StrumentiDispTavoli"
      Me.eui_StrumentiDispTavoli.ScreenTip.Caption = "Disposizione tavoli"
      Me.eui_StrumentiDispTavoli.ScreenTip.Text = "Apre lo strumento per la disposizione dei tavoli."
      Me.eui_StrumentiDispTavoli.Size = New System.Drawing.Size(96, 0)
      Me.eui_StrumentiDispTavoli.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiDispTavoli.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiDispTavoli.TabIndex = 0
      Me.eui_StrumentiDispTavoli.Text = "Disposizione tavoli"
      '
      'eui_GruppoMenu
      '
      Me.eui_GruppoMenu.Controls.Add(Me.eui_StrumentiMenù)
      Me.eui_GruppoMenu.DialogLauncherButtonVisible = False
      Me.eui_GruppoMenu.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_GruppoMenu.Location = New System.Drawing.Point(458, 1)
      Me.eui_GruppoMenu.Name = "eui_GruppoMenu"
      Me.eui_GruppoMenu.Size = New System.Drawing.Size(75, 0)
      Me.eui_GruppoMenu.TabIndex = 4
      Me.eui_GruppoMenu.Text = "Menù"
      '
      'eui_StrumentiMenù
      '
      Me.eui_StrumentiMenù.Id = "71571f8c-ad8e-4f03-8f3e-8a56f14b102d"
      Me.eui_StrumentiMenù.KeyTip = "F"
      Me.eui_StrumentiMenù.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiMenù.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiMenù.Location = New System.Drawing.Point(4, 2)
      Me.eui_StrumentiMenù.Name = "eui_StrumentiMenù"
      Me.eui_StrumentiMenù.ScreenTip.Caption = "Formazione Menù"
      Me.eui_StrumentiMenù.ScreenTip.Text = "Apre lo strumento per la generazione automatica del menù."
      Me.eui_StrumentiMenù.Size = New System.Drawing.Size(93, 0)
      Me.eui_StrumentiMenù.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiMenù.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiMenù.TabIndex = 0
      Me.eui_StrumentiMenù.Text = "Formazione Menù"
      '
      'RibbonGroup22
      '
      Me.RibbonGroup22.Controls.Add(Me.eui_StrumentiNote)
      Me.RibbonGroup22.Controls.Add(Me.eui_StrumentiCalcolatrice)
      Me.RibbonGroup22.Controls.Add(Me.eui_StrumentiTastiera)
      Me.RibbonGroup22.DialogLauncherButtonVisible = False
      Me.RibbonGroup22.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonGroup22.Location = New System.Drawing.Point(533, 1)
      Me.RibbonGroup22.Name = "RibbonGroup22"
      Me.RibbonGroup22.Size = New System.Drawing.Size(165, 0)
      Me.RibbonGroup22.TabIndex = 5
      Me.RibbonGroup22.Text = "Strumenti"
      '
      'eui_StrumentiNote
      '
      Me.eui_StrumentiNote.Id = "ce003263-d72e-44d5-bb92-5fff5e70e44f"
      Me.eui_StrumentiNote.KeyTip = "B"
      Me.eui_StrumentiNote.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiNote.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiNote.Location = New System.Drawing.Point(40, 2)
      Me.eui_StrumentiNote.Name = "eui_StrumentiNote"
      Me.eui_StrumentiNote.ScreenTip.Caption = "Blocco note"
      Me.eui_StrumentiNote.ScreenTip.Text = "Apre il blocco note di sistema."
      Me.eui_StrumentiNote.Size = New System.Drawing.Size(66, 0)
      Me.eui_StrumentiNote.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiNote.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiNote.TabIndex = 0
      Me.eui_StrumentiNote.Text = "Blocco note"
      '
      'eui_StrumentiCalcolatrice
      '
      Me.eui_StrumentiCalcolatrice.Id = "8cc9fa60-9f39-4a1d-9409-df4615d62cb9"
      Me.eui_StrumentiCalcolatrice.KeyTip = "C"
      Me.eui_StrumentiCalcolatrice.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiCalcolatrice.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiCalcolatrice.Location = New System.Drawing.Point(40, 2)
      Me.eui_StrumentiCalcolatrice.Name = "eui_StrumentiCalcolatrice"
      Me.eui_StrumentiCalcolatrice.ScreenTip.Caption = "Calcolatrice"
      Me.eui_StrumentiCalcolatrice.ScreenTip.Text = "Apre la calcolatrice di sistema."
      Me.eui_StrumentiCalcolatrice.Size = New System.Drawing.Size(64, 0)
      Me.eui_StrumentiCalcolatrice.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiCalcolatrice.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiCalcolatrice.TabIndex = 1
      Me.eui_StrumentiCalcolatrice.Text = "Calcolatrice"
      '
      'eui_StrumentiTastiera
      '
      Me.eui_StrumentiTastiera.Id = "4eea619f-3d60-4387-b176-ce07aee63a8a"
      Me.eui_StrumentiTastiera.KeyTip = "T"
      Me.eui_StrumentiTastiera.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiTastiera.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiTastiera.Location = New System.Drawing.Point(40, 2)
      Me.eui_StrumentiTastiera.Name = "eui_StrumentiTastiera"
      Me.eui_StrumentiTastiera.ScreenTip.Caption = "Tastiera virtuale"
      Me.eui_StrumentiTastiera.ScreenTip.Text = "Apre la tastiera virtuale di sistema."
      Me.eui_StrumentiTastiera.Size = New System.Drawing.Size(84, 0)
      Me.eui_StrumentiTastiera.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_StrumentiTastiera.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_StrumentiTastiera.TabIndex = 2
      Me.eui_StrumentiTastiera.Text = "Tastiera virtuale"
      '
      'eui_Finestra
      '
      Me.eui_Finestra.Controls.Add(Me.RibbonGroup14)
      Me.eui_Finestra.Dock = System.Windows.Forms.DockStyle.Fill
      Me.eui_Finestra.KeyTip = "W"
      Me.eui_Finestra.Location = New System.Drawing.Point(0, 0)
      Me.eui_Finestra.Name = "eui_Finestra"
      Me.eui_Finestra.Size = New System.Drawing.Size(1276, 99)
      Me.eui_Finestra.TabIndex = 0
      Me.eui_Finestra.Text = "Finestra"
      '
      'RibbonGroup14
      '
      Me.RibbonGroup14.Controls.Add(Me.eui_cmdFinestraSovrapponi)
      Me.RibbonGroup14.Controls.Add(Me.eui_cmdFinestraAffianca)
      Me.RibbonGroup14.Controls.Add(Me.eui_cmdFinestraDisponi)
      Me.RibbonGroup14.Controls.Add(Me.Separator22)
      Me.RibbonGroup14.Controls.Add(Me.eui_cmdFinestraChiudi)
      Me.RibbonGroup14.Controls.Add(Me.eui_cmdFinestraChiudiTutto)
      Me.RibbonGroup14.Controls.Add(Me.Separator21)
      Me.RibbonGroup14.Controls.Add(Me.eui_drpFinestraSel)
      Me.RibbonGroup14.DialogLauncherButtonVisible = False
      Me.RibbonGroup14.Location = New System.Drawing.Point(5, 1)
      Me.RibbonGroup14.Name = "RibbonGroup14"
      Me.RibbonGroup14.Size = New System.Drawing.Size(330, 0)
      Me.RibbonGroup14.TabIndex = 0
      Me.RibbonGroup14.Text = "Finestra"
      '
      'eui_cmdFinestraSovrapponi
      '
      Me.eui_cmdFinestraSovrapponi.Enabled = False
      Me.eui_cmdFinestraSovrapponi.Id = "0ca634e2-eb01-46cf-bac3-419995993362"
      Me.eui_cmdFinestraSovrapponi.KeyTip = "O"
      Me.eui_cmdFinestraSovrapponi.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdFinestraSovrapponi.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdFinestraSovrapponi.Location = New System.Drawing.Point(128, 2)
      Me.eui_cmdFinestraSovrapponi.Name = "eui_cmdFinestraSovrapponi"
      Me.eui_cmdFinestraSovrapponi.ScreenTip.Caption = "Sovrapponi"
      Me.eui_cmdFinestraSovrapponi.ScreenTip.Text = "Consente di sovrapporre tutte le finestre aperte."
      Me.eui_cmdFinestraSovrapponi.Size = New System.Drawing.Size(63, 0)
      Me.eui_cmdFinestraSovrapponi.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdFinestraSovrapponi.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdFinestraSovrapponi.TabIndex = 0
      Me.eui_cmdFinestraSovrapponi.Text = "Sovrapponi"
      '
      'eui_cmdFinestraAffianca
      '
      Me.eui_cmdFinestraAffianca.Enabled = False
      Me.eui_cmdFinestraAffianca.Id = "81ce54a9-9727-4a26-a1fe-97c63f4e90c5"
      Me.eui_cmdFinestraAffianca.KeyTip = "A"
      Me.eui_cmdFinestraAffianca.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdFinestraAffianca.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdFinestraAffianca.Location = New System.Drawing.Point(128, 2)
      Me.eui_cmdFinestraAffianca.Name = "eui_cmdFinestraAffianca"
      Me.eui_cmdFinestraAffianca.Popup = Me.PopupMenu4
      Me.eui_cmdFinestraAffianca.ScreenTip.Caption = "Affianca"
      Me.eui_cmdFinestraAffianca.ScreenTip.Text = "Consente di affiancare tutte le finestre aperte."
      Me.eui_cmdFinestraAffianca.Size = New System.Drawing.Size(56, 0)
      Me.eui_cmdFinestraAffianca.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdFinestraAffianca.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdFinestraAffianca.TabIndex = 1
      Me.eui_cmdFinestraAffianca.Text = "Affianca"
      '
      'PopupMenu4
      '
      Me.PopupMenu4.Items.AddRange(New System.Windows.Forms.Control() {Me.eui_cmdFinestraAffiancaOrizz, Me.eui_cmdFinestraAffiancaVert})
      Me.PopupMenu4.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu4.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu4.Size = New System.Drawing.Size(100, 100)
      '
      'eui_cmdFinestraAffiancaOrizz
      '
      Me.eui_cmdFinestraAffiancaOrizz.Id = "76ce785d-0f71-49dc-8f9c-4e9b1a1076cc"
      Me.eui_cmdFinestraAffiancaOrizz.KeyTip = "O"
      Me.eui_cmdFinestraAffiancaOrizz.Location = New System.Drawing.Point(2, 2)
      Me.eui_cmdFinestraAffiancaOrizz.Name = "eui_cmdFinestraAffiancaOrizz"
      Me.eui_cmdFinestraAffiancaOrizz.ScreenTip.Caption = "Affianca/Orizzontalmente"
      Me.eui_cmdFinestraAffiancaOrizz.ScreenTip.Text = "Consente di affiancare orizzontalmente tutte le finestre aperte."
      Me.eui_cmdFinestraAffiancaOrizz.Size = New System.Drawing.Size(146, 23)
      Me.eui_cmdFinestraAffiancaOrizz.TabIndex = 3
      Me.eui_cmdFinestraAffiancaOrizz.Text = "Orizzontalmente"
      '
      'eui_cmdFinestraAffiancaVert
      '
      Me.eui_cmdFinestraAffiancaVert.Id = "f62ff271-146a-49c7-bbae-35c3c1031526"
      Me.eui_cmdFinestraAffiancaVert.KeyTip = "V"
      Me.eui_cmdFinestraAffiancaVert.Location = New System.Drawing.Point(2, 25)
      Me.eui_cmdFinestraAffiancaVert.Name = "eui_cmdFinestraAffiancaVert"
      Me.eui_cmdFinestraAffiancaVert.ScreenTip.Caption = "Affianca/Verticalmente"
      Me.eui_cmdFinestraAffiancaVert.ScreenTip.Text = "Consente di affiancare verticalmente tutte le finestre aperte."
      Me.eui_cmdFinestraAffiancaVert.Size = New System.Drawing.Size(146, 23)
      Me.eui_cmdFinestraAffiancaVert.TabIndex = 4
      Me.eui_cmdFinestraAffiancaVert.Text = "Verticalmente"
      '
      'eui_cmdFinestraDisponi
      '
      Me.eui_cmdFinestraDisponi.Enabled = False
      Me.eui_cmdFinestraDisponi.Id = "62e050b9-6263-4aca-b11c-21d5f8bf3777"
      Me.eui_cmdFinestraDisponi.KeyTip = "D"
      Me.eui_cmdFinestraDisponi.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdFinestraDisponi.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdFinestraDisponi.Location = New System.Drawing.Point(128, 2)
      Me.eui_cmdFinestraDisponi.Name = "eui_cmdFinestraDisponi"
      Me.eui_cmdFinestraDisponi.ScreenTip.Caption = "Disponi icone"
      Me.eui_cmdFinestraDisponi.ScreenTip.Text = "Consente di disporre in modo ordinato tutte le finestre ridotte a icona."
      Me.eui_cmdFinestraDisponi.Size = New System.Drawing.Size(73, 0)
      Me.eui_cmdFinestraDisponi.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdFinestraDisponi.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdFinestraDisponi.TabIndex = 2
      Me.eui_cmdFinestraDisponi.Text = "Disponi icone"
      '
      'Separator22
      '
      Me.Separator22.Id = "a2f6493d-f63c-43bf-a688-cbeca3921ee7"
      Me.Separator22.Location = New System.Drawing.Point(129, 6)
      Me.Separator22.Name = "Separator22"
      Me.Separator22.Size = New System.Drawing.Size(3, -11)
      Me.Separator22.TabIndex = 7
      Me.Separator22.Text = "Separator22"
      '
      'eui_cmdFinestraChiudi
      '
      Me.eui_cmdFinestraChiudi.Enabled = False
      Me.eui_cmdFinestraChiudi.Id = "9ba147cc-4a83-472a-b56e-c27ee408fd24"
      Me.eui_cmdFinestraChiudi.KeyTip = "C"
      Me.eui_cmdFinestraChiudi.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdFinestraChiudi.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdFinestraChiudi.Location = New System.Drawing.Point(128, 2)
      Me.eui_cmdFinestraChiudi.Name = "eui_cmdFinestraChiudi"
      Me.eui_cmdFinestraChiudi.ScreenTip.Caption = "Chiudi"
      Me.eui_cmdFinestraChiudi.ScreenTip.Text = "Consente di chiudere la finestra selezionata."
      Me.eui_cmdFinestraChiudi.Size = New System.Drawing.Size(38, 0)
      Me.eui_cmdFinestraChiudi.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdFinestraChiudi.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdFinestraChiudi.TabIndex = 3
      Me.eui_cmdFinestraChiudi.Text = "Chiudi"
      '
      'eui_cmdFinestraChiudiTutto
      '
      Me.eui_cmdFinestraChiudiTutto.Enabled = False
      Me.eui_cmdFinestraChiudiTutto.Id = "57932c8e-3fa5-4091-ac30-1b8c401aeb4e"
      Me.eui_cmdFinestraChiudiTutto.KeyTip = "CT"
      Me.eui_cmdFinestraChiudiTutto.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdFinestraChiudiTutto.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_cmdFinestraChiudiTutto.Location = New System.Drawing.Point(128, 2)
      Me.eui_cmdFinestraChiudiTutto.Name = "eui_cmdFinestraChiudiTutto"
      Me.eui_cmdFinestraChiudiTutto.ScreenTip.Caption = "Chiudi tutto"
      Me.eui_cmdFinestraChiudiTutto.ScreenTip.Text = "Consente di chiudere tutte le finestre aperte."
      Me.eui_cmdFinestraChiudiTutto.Size = New System.Drawing.Size(62, 0)
      Me.eui_cmdFinestraChiudiTutto.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_cmdFinestraChiudiTutto.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_cmdFinestraChiudiTutto.TabIndex = 4
      Me.eui_cmdFinestraChiudiTutto.Text = "Chiudi tutto"
      '
      'Separator21
      '
      Me.Separator21.Id = "bd8f7d37-bf5b-4f2b-b29c-57f3f839612b"
      Me.Separator21.Location = New System.Drawing.Point(129, 6)
      Me.Separator21.Name = "Separator21"
      Me.Separator21.Size = New System.Drawing.Size(3, -11)
      Me.Separator21.TabIndex = 6
      Me.Separator21.Text = "Separator21"
      '
      'eui_drpFinestraSel
      '
      Me.eui_drpFinestraSel.Enabled = False
      Me.eui_drpFinestraSel.Id = "3eef7e0c-1794-421d-a951-1b7d31c8841d"
      Me.eui_drpFinestraSel.KeyTip = "S"
      Me.eui_drpFinestraSel.LargeImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_drpFinestraSel.LargeImages.Images"), System.Drawing.Image))})
      Me.eui_drpFinestraSel.Location = New System.Drawing.Point(128, 2)
      Me.eui_drpFinestraSel.Name = "eui_drpFinestraSel"
      Me.eui_drpFinestraSel.Popup = Me.FinestreMDI
      Me.eui_drpFinestraSel.ScreenTip.Caption = "Seleziona"
      Me.eui_drpFinestraSel.ScreenTip.Text = "Consente di selezionare la finestra desiderata."
      Me.eui_drpFinestraSel.Size = New System.Drawing.Size(63, 0)
      Me.eui_drpFinestraSel.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("eui_drpFinestraSel.SmallImages.Images"), System.Drawing.Image))})
      Me.eui_drpFinestraSel.TabIndex = 5
      Me.eui_drpFinestraSel.Text = "Seleziona"
      Me.eui_drpFinestraSel.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage
      Me.eui_drpFinestraSel.TogglePopupByClickWhenOpen = False
      '
      'FinestreMDI
      '
      Me.FinestreMDI.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.FinestreMDI.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.FinestreMDI.Size = New System.Drawing.Size(100, 100)
      '
      'PopupMenu2
      '
      Me.PopupMenu2.Items.AddRange(New System.Windows.Forms.Control() {Me.ToggleButton4, Me.ToggleButton5})
      Me.PopupMenu2.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu2.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu2.Size = New System.Drawing.Size(100, 100)
      '
      'ToggleButton4
      '
      Me.ToggleButton4.Id = "3c1d0654-a3d3-40ea-aaef-201c8031ccf2"
      Me.ToggleButton4.Location = New System.Drawing.Point(2, 2)
      Me.ToggleButton4.Name = "ToggleButton4"
      Me.ToggleButton4.Pressed = True
      Me.ToggleButton4.Size = New System.Drawing.Size(138, 23)
      Me.ToggleButton4.TabIndex = 4
      Me.ToggleButton4.Text = "ToggleButton4"
      '
      'ToggleButton5
      '
      Me.ToggleButton5.Id = "bdf22d91-a927-48fd-a903-0dd59fe54b3d"
      Me.ToggleButton5.Location = New System.Drawing.Point(2, 25)
      Me.ToggleButton5.Name = "ToggleButton5"
      Me.ToggleButton5.Size = New System.Drawing.Size(138, 23)
      Me.ToggleButton5.TabIndex = 5
      Me.ToggleButton5.Text = "ToggleButton5"
      '
      'PopupMenu5
      '
      Me.PopupMenu5.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu5.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu5.Size = New System.Drawing.Size(100, 100)
      '
      'ToggleButton2
      '
      Me.ToggleButton2.Id = "99e33981-21df-4126-86ea-a5e42e872f64"
      Me.ToggleButton2.Location = New System.Drawing.Point(2, 107)
      Me.ToggleButton2.Name = "ToggleButton2"
      Me.ToggleButton2.RadioGroupName = "NavigationBarToggleButtons"
      Me.ToggleButton2.Size = New System.Drawing.Size(285, 25)
      Me.ToggleButton2.TabIndex = 1
      Me.ToggleButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ToggleButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      '
      'ToggleButton3
      '
      Me.ToggleButton3.Id = "93109126-ac32-4ce5-a2a1-d0ea8234a87e"
      Me.ToggleButton3.Location = New System.Drawing.Point(2, 80)
      Me.ToggleButton3.Name = "ToggleButton3"
      Me.ToggleButton3.RadioGroupName = "NavigationBarToggleButtons"
      Me.ToggleButton3.Size = New System.Drawing.Size(285, 25)
      Me.ToggleButton3.TabIndex = 2
      Me.ToggleButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ToggleButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      '
      'ToggleButton1
      '
      Me.ToggleButton1.DescriptionText = "Guida in linea del programma."
      Me.ToggleButton1.Id = "eb0f1f10-64c8-4c35-a4c2-4db03fa006a8"
      Me.ToggleButton1.ImageAlign = System.Drawing.ContentAlignment.TopLeft
      Me.ToggleButton1.Location = New System.Drawing.Point(2, 2)
      Me.ToggleButton1.Name = "ToggleButton1"
      Me.ToggleButton1.RadioGroupName = "NavigationBarToggleButtons"
      Me.ToggleButton1.Size = New System.Drawing.Size(285, 76)
      Me.ToggleButton1.SmallImages.Images.AddRange(New Elegant.Ui.ControlImage() {New Elegant.Ui.ControlImage("Normal", CType(resources.GetObject("ToggleButton1.SmallImages.Images"), System.Drawing.Image))})
      Me.ToggleButton1.TabIndex = 0
      Me.ToggleButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ToggleButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
      '
      'eui_sbrMain
      '
      Me.eui_sbrMain.Controls.Add(Me.StatusBarNotificationsArea1)
      Me.eui_sbrMain.Controls.Add(Me.StatusBarControlsArea1)
      Me.eui_sbrMain.ControlsArea = Me.StatusBarControlsArea1
      Me.eui_sbrMain.Dock = System.Windows.Forms.DockStyle.Bottom
      Me.eui_sbrMain.ForeColor = System.Drawing.SystemColors.ControlText
      Me.eui_sbrMain.Location = New System.Drawing.Point(0, 790)
      Me.eui_sbrMain.Name = "eui_sbrMain"
      Me.eui_sbrMain.NotificationsArea = Me.StatusBarNotificationsArea1
      Me.eui_sbrMain.Size = New System.Drawing.Size(1469, 22)
      Me.eui_sbrMain.TabIndex = 20
      '
      'StatusBarNotificationsArea1
      '
      Me.StatusBarNotificationsArea1.Controls.Add(Me.StatusBarPane5)
      Me.StatusBarNotificationsArea1.Controls.Add(Me.StatusBarPane8)
      Me.StatusBarNotificationsArea1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.StatusBarNotificationsArea1.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarNotificationsArea1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarNotificationsArea1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarNotificationsArea1.Name = "StatusBarNotificationsArea1"
      Me.StatusBarNotificationsArea1.Size = New System.Drawing.Size(872, 22)
      Me.StatusBarNotificationsArea1.TabIndex = 1
      Me.StatusBarNotificationsArea1.Text = "Prova 2"
      '
      'StatusBarPane5
      '
      Me.StatusBarPane5.Controls.Add(Me.PictureBox5)
      Me.StatusBarPane5.Controls.Add(Me.eui_cmdArchivio)
      Me.StatusBarPane5.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarPane5.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane5.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane5.Name = "StatusBarPane5"
      Me.StatusBarPane5.Size = New System.Drawing.Size(96, 22)
      Me.StatusBarPane5.TabIndex = 1
      '
      'PictureBox5
      '
      Me.PictureBox5.Image = CType(resources.GetObject("PictureBox5.Image"), System.Drawing.Image)
      Me.PictureBox5.Location = New System.Drawing.Point(2, 3)
      Me.PictureBox5.Name = "PictureBox5"
      Me.PictureBox5.Size = New System.Drawing.Size(16, 16)
      Me.PictureBox5.SizeMode = Elegant.Ui.PictureBoxSizeMode.StretchImage
      Me.PictureBox5.TabIndex = 1
      Me.PictureBox5.TabStop = False
      Me.PictureBox5.Text = "PictureBox5"
      '
      'eui_cmdArchivio
      '
      Me.eui_cmdArchivio.AutoSize = True
      Me.eui_cmdArchivio.Id = "3c7ccfd4-b66c-488a-aa5b-f67ea108ae72"
      Me.eui_cmdArchivio.Location = New System.Drawing.Point(19, 2)
      Me.eui_cmdArchivio.Name = "eui_cmdArchivio"
      Me.eui_cmdArchivio.ScreenTip.Caption = "Percorso archivio"
      Me.eui_cmdArchivio.Size = New System.Drawing.Size(44, 19)
      Me.eui_cmdArchivio.TabIndex = 0
      Me.eui_cmdArchivio.Text = "Archivio"
      '
      'StatusBarPane8
      '
      Me.StatusBarPane8.Controls.Add(Me.PictureBox19)
      Me.StatusBarPane8.Controls.Add(Me.eui_Informazioni)
      Me.StatusBarPane8.Location = New System.Drawing.Point(96, 0)
      Me.StatusBarPane8.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane8.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane8.Name = "StatusBarPane8"
      Me.StatusBarPane8.Size = New System.Drawing.Size(124, 22)
      Me.StatusBarPane8.TabIndex = 2
      '
      'PictureBox19
      '
      Me.PictureBox19.Dock = System.Windows.Forms.DockStyle.Fill
      Me.PictureBox19.Image = CType(resources.GetObject("PictureBox19.Image"), System.Drawing.Image)
      Me.PictureBox19.Location = New System.Drawing.Point(2, 3)
      Me.PictureBox19.Name = "PictureBox19"
      Me.PictureBox19.Size = New System.Drawing.Size(16, 16)
      Me.PictureBox19.SizeMode = Elegant.Ui.PictureBoxSizeMode.StretchImage
      Me.PictureBox19.TabIndex = 3
      Me.PictureBox19.TabStop = False
      Me.PictureBox19.Text = "PictureBox19"
      '
      'eui_Informazioni
      '
      Me.eui_Informazioni.Location = New System.Drawing.Point(21, 5)
      Me.eui_Informazioni.Name = "eui_Informazioni"
      Me.eui_Informazioni.Size = New System.Drawing.Size(68, 13)
      Me.eui_Informazioni.TabIndex = 2
      Me.eui_Informazioni.Text = " Informazioni..."
      '
      'StatusBarControlsArea1
      '
      Me.StatusBarControlsArea1.Controls.Add(Me.StatusBarPane1)
      Me.StatusBarControlsArea1.Controls.Add(Me.StatusBarPane3)
      Me.StatusBarControlsArea1.Controls.Add(Me.StatusBarPane4)
      Me.StatusBarControlsArea1.Controls.Add(Me.StatusBarPane6)
      Me.StatusBarControlsArea1.Controls.Add(Me.StatusBarPane2)
      Me.StatusBarControlsArea1.Controls.Add(Me.StatusBarPane7)
      Me.StatusBarControlsArea1.Dock = System.Windows.Forms.DockStyle.Right
      Me.StatusBarControlsArea1.Location = New System.Drawing.Point(872, 0)
      Me.StatusBarControlsArea1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarControlsArea1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarControlsArea1.Name = "StatusBarControlsArea1"
      Me.StatusBarControlsArea1.Size = New System.Drawing.Size(597, 22)
      Me.StatusBarControlsArea1.TabIndex = 0
      Me.StatusBarControlsArea1.Text = "Prova"
      '
      'StatusBarPane1
      '
      Me.StatusBarPane1.Controls.Add(Me.PictureBox1)
      Me.StatusBarPane1.Controls.Add(Me.eui_cmdAzienda)
      Me.StatusBarPane1.Location = New System.Drawing.Point(0, 0)
      Me.StatusBarPane1.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane1.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane1.Name = "StatusBarPane1"
      Me.StatusBarPane1.Size = New System.Drawing.Size(90, 22)
      Me.StatusBarPane1.TabIndex = 0
      '
      'PictureBox1
      '
      Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
      Me.PictureBox1.Location = New System.Drawing.Point(2, 3)
      Me.PictureBox1.Name = "PictureBox1"
      Me.PictureBox1.Size = New System.Drawing.Size(16, 16)
      Me.PictureBox1.SizeMode = Elegant.Ui.PictureBoxSizeMode.StretchImage
      Me.PictureBox1.TabIndex = 1
      Me.PictureBox1.TabStop = False
      Me.PictureBox1.Text = "PictureBox1"
      '
      'eui_cmdAzienda
      '
      Me.eui_cmdAzienda.AutoSize = True
      Me.eui_cmdAzienda.Id = "45738afd-e9ab-4638-9af1-0c712f80826b"
      Me.eui_cmdAzienda.Location = New System.Drawing.Point(19, 2)
      Me.eui_cmdAzienda.Name = "eui_cmdAzienda"
      Me.eui_cmdAzienda.ScreenTip.Caption = "Azienda"
      Me.eui_cmdAzienda.ScreenTip.Text = "Ragione sociale dell'azienda. "
      Me.eui_cmdAzienda.Size = New System.Drawing.Size(44, 19)
      Me.eui_cmdAzienda.TabIndex = 0
      Me.eui_cmdAzienda.Text = "Azienda"
      '
      'StatusBarPane3
      '
      Me.StatusBarPane3.Controls.Add(Me.PictureBox2)
      Me.StatusBarPane3.Controls.Add(Me.eui_cmdPostazione)
      Me.StatusBarPane3.Location = New System.Drawing.Point(90, 0)
      Me.StatusBarPane3.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane3.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane3.Name = "StatusBarPane3"
      Me.StatusBarPane3.Size = New System.Drawing.Size(104, 22)
      Me.StatusBarPane3.TabIndex = 1
      '
      'PictureBox2
      '
      Me.PictureBox2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
      Me.PictureBox2.Location = New System.Drawing.Point(2, 3)
      Me.PictureBox2.Name = "PictureBox2"
      Me.PictureBox2.Size = New System.Drawing.Size(16, 16)
      Me.PictureBox2.SizeMode = Elegant.Ui.PictureBoxSizeMode.StretchImage
      Me.PictureBox2.TabIndex = 10
      Me.PictureBox2.TabStop = False
      Me.PictureBox2.Text = "PictureBox2"
      '
      'eui_cmdPostazione
      '
      Me.eui_cmdPostazione.AutoSize = True
      Me.eui_cmdPostazione.Id = "d349e9b9-9300-40c3-a8a8-86808c11eb24"
      Me.eui_cmdPostazione.Location = New System.Drawing.Point(19, 2)
      Me.eui_cmdPostazione.Name = "eui_cmdPostazione"
      Me.eui_cmdPostazione.ScreenTip.Caption = "Postazione"
      Me.eui_cmdPostazione.Size = New System.Drawing.Size(58, 19)
      Me.eui_cmdPostazione.TabIndex = 0
      Me.eui_cmdPostazione.Text = "Postazione"
      '
      'StatusBarPane4
      '
      Me.StatusBarPane4.Controls.Add(Me.PictureBox3)
      Me.StatusBarPane4.Controls.Add(Me.eui_cmdOperatore)
      Me.StatusBarPane4.Location = New System.Drawing.Point(194, 0)
      Me.StatusBarPane4.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane4.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane4.Name = "StatusBarPane4"
      Me.StatusBarPane4.Size = New System.Drawing.Size(99, 22)
      Me.StatusBarPane4.TabIndex = 2
      '
      'PictureBox3
      '
      Me.PictureBox3.Dock = System.Windows.Forms.DockStyle.Fill
      Me.PictureBox3.Image = CType(resources.GetObject("PictureBox3.Image"), System.Drawing.Image)
      Me.PictureBox3.Location = New System.Drawing.Point(2, 3)
      Me.PictureBox3.Name = "PictureBox3"
      Me.PictureBox3.Size = New System.Drawing.Size(16, 16)
      Me.PictureBox3.SizeMode = Elegant.Ui.PictureBoxSizeMode.StretchImage
      Me.PictureBox3.TabIndex = 1
      Me.PictureBox3.TabStop = False
      Me.PictureBox3.Text = "PictureBox3"
      '
      'eui_cmdOperatore
      '
      Me.eui_cmdOperatore.AutoSize = True
      Me.eui_cmdOperatore.Id = "36149af6-aca6-40d3-adf7-c42677d47133"
      Me.eui_cmdOperatore.Location = New System.Drawing.Point(19, 2)
      Me.eui_cmdOperatore.Name = "eui_cmdOperatore"
      Me.eui_cmdOperatore.ScreenTip.Caption = "Operatore"
      Me.eui_cmdOperatore.ScreenTip.Text = "Nome dell'operatore che utilizza il programma."
      Me.eui_cmdOperatore.Size = New System.Drawing.Size(53, 19)
      Me.eui_cmdOperatore.TabIndex = 0
      Me.eui_cmdOperatore.Text = "Operatore"
      '
      'StatusBarPane6
      '
      Me.StatusBarPane6.Controls.Add(Me.PictureBox4)
      Me.StatusBarPane6.Controls.Add(Me.eui_cmdData)
      Me.StatusBarPane6.Location = New System.Drawing.Point(293, 0)
      Me.StatusBarPane6.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane6.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane6.Name = "StatusBarPane6"
      Me.StatusBarPane6.Size = New System.Drawing.Size(75, 22)
      Me.StatusBarPane6.TabIndex = 3
      '
      'PictureBox4
      '
      Me.PictureBox4.Image = CType(resources.GetObject("PictureBox4.Image"), System.Drawing.Image)
      Me.PictureBox4.Location = New System.Drawing.Point(2, 3)
      Me.PictureBox4.Name = "PictureBox4"
      Me.PictureBox4.Size = New System.Drawing.Size(16, 16)
      Me.PictureBox4.SizeMode = Elegant.Ui.PictureBoxSizeMode.StretchImage
      Me.PictureBox4.TabIndex = 1
      Me.PictureBox4.TabStop = False
      Me.PictureBox4.Text = "PictureBox4"
      '
      'eui_cmdData
      '
      Me.eui_cmdData.AutoSize = True
      Me.eui_cmdData.Id = "1885e60f-1bbc-49cd-baca-bb73905d713a"
      Me.eui_cmdData.Location = New System.Drawing.Point(19, 2)
      Me.eui_cmdData.Name = "eui_cmdData"
      Me.eui_cmdData.ScreenTip.Caption = "Data odierna di gestione"
      Me.eui_cmdData.ScreenTip.Text = "Data"
      Me.eui_cmdData.Size = New System.Drawing.Size(29, 19)
      Me.eui_cmdData.TabIndex = 0
      Me.eui_cmdData.Text = "Data"
      '
      'StatusBarPane2
      '
      Me.StatusBarPane2.Controls.Add(Me.eui_picAggiornamenti)
      Me.StatusBarPane2.Controls.Add(Me.eui_cmdNuovoAgg)
      Me.StatusBarPane2.Location = New System.Drawing.Point(368, 0)
      Me.StatusBarPane2.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane2.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane2.Name = "StatusBarPane2"
      Me.StatusBarPane2.Size = New System.Drawing.Size(119, 22)
      Me.StatusBarPane2.TabIndex = 4
      '
      'eui_picAggiornamenti
      '
      Me.eui_picAggiornamenti.Image = CType(resources.GetObject("eui_picAggiornamenti.Image"), System.Drawing.Image)
      Me.eui_picAggiornamenti.Location = New System.Drawing.Point(2, 3)
      Me.eui_picAggiornamenti.Name = "eui_picAggiornamenti"
      Me.eui_picAggiornamenti.Size = New System.Drawing.Size(16, 16)
      Me.eui_picAggiornamenti.SizeMode = Elegant.Ui.PictureBoxSizeMode.StretchImage
      Me.eui_picAggiornamenti.TabIndex = 2
      Me.eui_picAggiornamenti.TabStop = False
      '
      'eui_cmdNuovoAgg
      '
      Me.eui_cmdNuovoAgg.AutoSize = True
      Me.eui_cmdNuovoAgg.Id = "33555ba9-8ada-4f17-824a-83f91c734fe2"
      Me.eui_cmdNuovoAgg.Location = New System.Drawing.Point(19, 2)
      Me.eui_cmdNuovoAgg.Name = "eui_cmdNuovoAgg"
      Me.eui_cmdNuovoAgg.ScreenTip.Caption = "Aaggiornamenti"
      Me.eui_cmdNuovoAgg.ScreenTip.Text = "Premi sul pulsante per verificare se ci sono aggiornamenti disponibili. Oppure vi" &
    "sita il sito Internet www.montanasoftware.it." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
      Me.eui_cmdNuovoAgg.Size = New System.Drawing.Size(73, 19)
      Me.eui_cmdNuovoAgg.TabIndex = 3
      Me.eui_cmdNuovoAgg.Text = "Agg. Nessuno"
      '
      'StatusBarPane7
      '
      Me.StatusBarPane7.Controls.Add(Me.PictureBox21)
      Me.StatusBarPane7.Controls.Add(Me.eui_cmdLicenza)
      Me.StatusBarPane7.Location = New System.Drawing.Point(487, 0)
      Me.StatusBarPane7.MaximumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane7.MinimumSize = New System.Drawing.Size(0, 22)
      Me.StatusBarPane7.Name = "StatusBarPane7"
      Me.StatusBarPane7.Size = New System.Drawing.Size(58, 22)
      Me.StatusBarPane7.TabIndex = 5
      '
      'PictureBox21
      '
      Me.PictureBox21.Image = CType(resources.GetObject("PictureBox21.Image"), System.Drawing.Image)
      Me.PictureBox21.Location = New System.Drawing.Point(2, 3)
      Me.PictureBox21.Name = "PictureBox21"
      Me.PictureBox21.Size = New System.Drawing.Size(16, 16)
      Me.PictureBox21.SizeMode = Elegant.Ui.PictureBoxSizeMode.StretchImage
      Me.PictureBox21.TabIndex = 4
      Me.PictureBox21.TabStop = False
      '
      'eui_cmdLicenza
      '
      Me.eui_cmdLicenza.AutoSize = True
      Me.eui_cmdLicenza.Id = "b2596c82-e48a-42a2-8df1-cc36a654535c"
      Me.eui_cmdLicenza.Location = New System.Drawing.Point(19, 2)
      Me.eui_cmdLicenza.Name = "eui_cmdLicenza"
      Me.eui_cmdLicenza.ScreenTip.Caption = "Assistenza"
      Me.eui_cmdLicenza.ScreenTip.Text = "Premi sul pulsante per avere informazioni sul servizio di assistenza attivo." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
      Me.eui_cmdLicenza.Size = New System.Drawing.Size(12, 19)
      Me.eui_cmdLicenza.TabIndex = 5
      Me.eui_cmdLicenza.Text = "0"
      '
      'NavigationBarItem6
      '
      Me.NavigationBarItem6.Id = "38e77737-afd9-4b4a-b37b-6de24a64ee1a"
      Me.NavigationBarItem6.Location = New System.Drawing.Point(0, 38)
      Me.NavigationBarItem6.Name = "NavigationBarItem6"
      Me.NavigationBarItem6.Size = New System.Drawing.Size(359, 19)
      Me.NavigationBarItem6.TabIndex = 3
      Me.NavigationBarItem6.Text = "NavigationBarItem6"
      '
      'CheckBox7
      '
      Me.CheckBox7.Id = "15cc2da5-fb81-4976-b9e1-4a0bf97e17f5"
      Me.CheckBox7.Location = New System.Drawing.Point(33, 41)
      Me.CheckBox7.Name = "CheckBox7"
      Me.CheckBox7.Size = New System.Drawing.Size(104, 24)
      Me.CheckBox7.TabIndex = 3
      Me.CheckBox7.Text = "CheckBox7"
      '
      'PopupMenu7
      '
      Me.PopupMenu7.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu7.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu7.Size = New System.Drawing.Size(100, 100)
      '
      'PopupMenu8
      '
      Me.PopupMenu8.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu8.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu8.Size = New System.Drawing.Size(100, 100)
      '
      'PopupMenu9
      '
      Me.PopupMenu9.KeepPopupsWithOffsetPlacementWithinPlacementArea = False
      Me.PopupMenu9.PlacementMode = Elegant.Ui.PopupPlacementMode.Bottom
      Me.PopupMenu9.Size = New System.Drawing.Size(100, 100)
      '
      'Timer2
      '
      Me.Timer2.Interval = 1000
      '
      'RibbonTabPage3
      '
      Me.RibbonTabPage3.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonTabPage3.KeyTip = Nothing
      Me.RibbonTabPage3.Location = New System.Drawing.Point(0, 0)
      Me.RibbonTabPage3.Name = "RibbonTabPage3"
      Me.RibbonTabPage3.Size = New System.Drawing.Size(1122, 99)
      Me.RibbonTabPage3.TabIndex = 0
      Me.RibbonTabPage3.Text = "RibbonTabPage3"
      '
      'RibbonTabPage2
      '
      Me.RibbonTabPage2.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonTabPage2.KeyTip = Nothing
      Me.RibbonTabPage2.Location = New System.Drawing.Point(0, 0)
      Me.RibbonTabPage2.Name = "RibbonTabPage2"
      Me.RibbonTabPage2.Size = New System.Drawing.Size(1122, 99)
      Me.RibbonTabPage2.TabIndex = 0
      Me.RibbonTabPage2.Text = "RibbonTabPage2"
      '
      'RibbonTabPage1
      '
      Me.RibbonTabPage1.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonTabPage1.KeyTip = Nothing
      Me.RibbonTabPage1.Location = New System.Drawing.Point(0, 0)
      Me.RibbonTabPage1.Name = "RibbonTabPage1"
      Me.RibbonTabPage1.Size = New System.Drawing.Size(1270, 99)
      Me.RibbonTabPage1.TabIndex = 0
      Me.RibbonTabPage1.Text = "RibbonTabPage1"
      '
      'RibbonTabPage4
      '
      Me.RibbonTabPage4.Dock = System.Windows.Forms.DockStyle.Fill
      Me.RibbonTabPage4.KeyTip = Nothing
      Me.RibbonTabPage4.Location = New System.Drawing.Point(0, 0)
      Me.RibbonTabPage4.Name = "RibbonTabPage4"
      Me.RibbonTabPage4.Size = New System.Drawing.Size(1270, 99)
      Me.RibbonTabPage4.TabIndex = 0
      Me.RibbonTabPage4.Text = "RibbonTabPage4"
      '
      'RibbonTabPage5
      '
      Me.RibbonTabPage5.KeyTip = Nothing
      Me.RibbonTabPage5.Location = New System.Drawing.Point(0, 0)
      Me.RibbonTabPage5.Name = "RibbonTabPage5"
      Me.RibbonTabPage5.Size = New System.Drawing.Size(0, 0)
      Me.RibbonTabPage5.TabIndex = 0
      Me.RibbonTabPage5.Text = "RibbonTabPage5"
      '
      'frmMain
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.BackColor = System.Drawing.Color.White
      Me.ClientSize = New System.Drawing.Size(1469, 812)
      Me.Controls.Add(Me.eui_BackstageView1)
      Me.Controls.Add(Me.eui_File)
      Me.Controls.Add(Me.eui_sbrMain)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.IsMdiContainer = True
      Me.Location = New System.Drawing.Point(6, 57)
      Me.Name = "frmMain"
      Me.RightToLeft = System.Windows.Forms.RightToLeft.No
      Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
      Me.Text = "Hospitality Solution Suite 3"
      CType(Me.picProg, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.eui_File, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.eui_BackstageView1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_Guida.ResumeLayout(False)
      Me.BackstageViewPage1.ResumeLayout(False)
      Me.BackstageViewPage1.PerformLayout()
      CType(Me.PictureBox20, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox18, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox17, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.eui_lstProdottiAttivati, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox16, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox15, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox14, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox13, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox12, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox10, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_Info.ResumeLayout(False)
      Me.eui_Info.PerformLayout()
      CType(Me.PictureBox11, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox9, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox8, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox7, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PictureBox6, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_GestioneModuli.ResumeLayout(False)
      CType(Me.eui_StrumentiModifica, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_StrumentiModifica.ResumeLayout(False)
      Me.eui_StrumentiModifica.PerformLayout()
      CType(Me.RibbonGroup21, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup21.ResumeLayout(False)
      Me.RibbonGroup21.PerformLayout()
      CType(Me.PopupMenu16, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RibbonGroup18, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup18.ResumeLayout(False)
      Me.RibbonGroup18.PerformLayout()
      CType(Me.eui_StrumentiPeriodo, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_StrumentiPeriodo.ResumeLayout(False)
      Me.eui_StrumentiPeriodo.PerformLayout()
      CType(Me.RibbonGroup26, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup26.ResumeLayout(False)
      Me.RibbonGroup26.PerformLayout()
      CType(Me.eui_rib_Visualizza, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_rib_Visualizza.ResumeLayout(False)
      Me.eui_rib_Visualizza.PerformLayout()
      CType(Me.eui_StrumentiDocumenti, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_StrumentiDocumenti.ResumeLayout(False)
      Me.eui_StrumentiDocumenti.PerformLayout()
      CType(Me.RibbonGroup29, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup29.ResumeLayout(False)
      Me.RibbonGroup29.PerformLayout()
      CType(Me.RibbonGroup27, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup27.ResumeLayout(False)
      Me.RibbonGroup27.PerformLayout()
      CType(Me.PopupMenu14, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu13, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu15, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.eui_StrumentiSospesiBuoni, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_StrumentiSospesiBuoni.ResumeLayout(False)
      Me.eui_StrumentiSospesiBuoni.PerformLayout()
      CType(Me.RibbonGroup20, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup20.ResumeLayout(False)
      Me.RibbonGroup20.PerformLayout()
      CType(Me.RibbonGroup25, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup25.ResumeLayout(False)
      Me.RibbonGroup25.PerformLayout()
      CType(Me.eui_Amica_ImportaEsporta, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_Amica_ImportaEsporta.ResumeLayout(False)
      Me.eui_Amica_ImportaEsporta.PerformLayout()
      CType(Me.RibbonGroup2, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup2.ResumeLayout(False)
      Me.RibbonGroup2.PerformLayout()
      CType(Me.eui_PCamere_Prenotazioni, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_PCamere_Prenotazioni.ResumeLayout(False)
      Me.eui_PCamere_Prenotazioni.PerformLayout()
      CType(Me.RibbonGroup13, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup13.ResumeLayout(False)
      Me.RibbonGroup13.PerformLayout()
      CType(Me.RibbonGroup3, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup3.ResumeLayout(False)
      Me.RibbonGroup3.PerformLayout()
      CType(Me.RibbonGroup4, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup4.ResumeLayout(False)
      Me.RibbonGroup4.PerformLayout()
      CType(Me.eui_PCamere_Visualizza, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_PCamere_Visualizza.ResumeLayout(False)
      Me.eui_PCamere_Visualizza.PerformLayout()
      CType(Me.RibbonGroup23, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup23.ResumeLayout(False)
      Me.RibbonGroup23.PerformLayout()
      CType(Me.RibbonGroup24, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup24.ResumeLayout(False)
      Me.RibbonGroup24.PerformLayout()
      CType(Me.eui_Gestione, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_Gestione.ResumeLayout(False)
      Me.eui_Gestione.PerformLayout()
      CType(Me.eui_GruppoPos, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_GruppoPos.ResumeLayout(False)
      Me.eui_GruppoPos.PerformLayout()
      CType(Me.eui_GruppoPrenotazioni, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_GruppoPrenotazioni.ResumeLayout(False)
      Me.eui_GruppoPrenotazioni.PerformLayout()
      CType(Me.PopupMenu10, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu12, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu11, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RibbonGroup15, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup15.ResumeLayout(False)
      Me.RibbonGroup15.PerformLayout()
      CType(Me.PopupMenu6, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RibbonGroup16, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup16.ResumeLayout(False)
      Me.RibbonGroup16.PerformLayout()
      CType(Me.RibbonGroup30, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup30.ResumeLayout(False)
      Me.RibbonGroup30.PerformLayout()
      CType(Me.eui_Archivi, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_Archivi.ResumeLayout(False)
      Me.eui_Archivi.PerformLayout()
      CType(Me.RibbonGroup17, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup17.ResumeLayout(False)
      Me.RibbonGroup17.PerformLayout()
      CType(Me.PopupMenu1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RibbonGroup5, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup5.ResumeLayout(False)
      Me.RibbonGroup5.PerformLayout()
      CType(Me.PopupMenu3, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RibbonGroup1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup1.ResumeLayout(False)
      Me.RibbonGroup1.PerformLayout()
      CType(Me.eui_Contabilità, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_Contabilità.ResumeLayout(False)
      Me.eui_Contabilità.PerformLayout()
      CType(Me.RibbonGroup6, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup6.ResumeLayout(False)
      Me.RibbonGroup6.PerformLayout()
      CType(Me.RibbonGroup7, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup7.ResumeLayout(False)
      Me.RibbonGroup7.PerformLayout()
      CType(Me.eui_Magazzino, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_Magazzino.ResumeLayout(False)
      Me.eui_Magazzino.PerformLayout()
      CType(Me.RibbonGroup8, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup8.ResumeLayout(False)
      Me.RibbonGroup8.PerformLayout()
      CType(Me.RibbonGroup9, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup9.ResumeLayout(False)
      Me.RibbonGroup9.PerformLayout()
      CType(Me.RibbonGroup11, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup11.ResumeLayout(False)
      Me.RibbonGroup11.PerformLayout()
      CType(Me.RibbonGroup12, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup12.ResumeLayout(False)
      Me.RibbonGroup12.PerformLayout()
      CType(Me.eui_Visualizza, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_Visualizza.ResumeLayout(False)
      Me.eui_Visualizza.PerformLayout()
      CType(Me.RibbonGroup10, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup10.ResumeLayout(False)
      Me.RibbonGroup10.PerformLayout()
      CType(Me.eui_Strumenti, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_Strumenti.ResumeLayout(False)
      Me.eui_Strumenti.PerformLayout()
      CType(Me.RibbonGroup28, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup28.ResumeLayout(False)
      Me.RibbonGroup28.PerformLayout()
      CType(Me.eui_GruppoReparti, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_GruppoReparti.ResumeLayout(False)
      Me.eui_GruppoReparti.PerformLayout()
      CType(Me.eui_GruppoEtichette, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_GruppoEtichette.ResumeLayout(False)
      Me.eui_GruppoEtichette.PerformLayout()
      CType(Me.RibbonGroup19, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup19.ResumeLayout(False)
      Me.RibbonGroup19.PerformLayout()
      CType(Me.eui_GruppoTavoli, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_GruppoTavoli.ResumeLayout(False)
      Me.eui_GruppoTavoli.PerformLayout()
      CType(Me.eui_GruppoMenu, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_GruppoMenu.ResumeLayout(False)
      Me.eui_GruppoMenu.PerformLayout()
      CType(Me.RibbonGroup22, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup22.ResumeLayout(False)
      Me.RibbonGroup22.PerformLayout()
      CType(Me.eui_Finestra, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_Finestra.ResumeLayout(False)
      Me.eui_Finestra.PerformLayout()
      CType(Me.RibbonGroup14, System.ComponentModel.ISupportInitialize).EndInit()
      Me.RibbonGroup14.ResumeLayout(False)
      Me.RibbonGroup14.PerformLayout()
      CType(Me.PopupMenu4, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.FinestreMDI, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu5, System.ComponentModel.ISupportInitialize).EndInit()
      Me.eui_sbrMain.ResumeLayout(False)
      Me.eui_sbrMain.PerformLayout()
      Me.StatusBarNotificationsArea1.ResumeLayout(False)
      Me.StatusBarNotificationsArea1.PerformLayout()
      Me.StatusBarPane5.ResumeLayout(False)
      Me.StatusBarPane5.PerformLayout()
      Me.StatusBarPane8.ResumeLayout(False)
      Me.StatusBarPane8.PerformLayout()
      Me.StatusBarControlsArea1.ResumeLayout(False)
      Me.StatusBarControlsArea1.PerformLayout()
      Me.StatusBarPane1.ResumeLayout(False)
      Me.StatusBarPane1.PerformLayout()
      Me.StatusBarPane3.ResumeLayout(False)
      Me.StatusBarPane3.PerformLayout()
      Me.StatusBarPane4.ResumeLayout(False)
      Me.StatusBarPane4.PerformLayout()
      Me.StatusBarPane6.ResumeLayout(False)
      Me.StatusBarPane6.PerformLayout()
      Me.StatusBarPane2.ResumeLayout(False)
      Me.StatusBarPane2.PerformLayout()
      Me.StatusBarPane7.ResumeLayout(False)
      Me.StatusBarPane7.PerformLayout()
      CType(Me.PopupMenu7, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu8, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.PopupMenu9, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RibbonTabPage3, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RibbonTabPage2, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RibbonTabPage1, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RibbonTabPage4, System.ComponentModel.ISupportInitialize).EndInit()
      CType(Me.RibbonTabPage5, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

   End Sub
#End Region

#Region "Dichiarazioni"

   Const NOME_TABELLA_AZIENDA As String = "Azienda"
   Const NOME_TABELLA_CLIENTI As String = "Clienti"
   Const NOME_TABELLA_PREN As String = "Prenotazioni"
   Const NOME_TABELLA As String = "Operazioni"
   Const ANA_TAVOLI As String = "Tavoli"
   Const TAB_PRENOTAZIONI As String = "PrenCamere"
   Const TAB_STORICO_PRESENZE_ISTAT As String = "StoricoPresenzeIstat"
   Const TAB_STORICO_PRESENZE_ISTAT_C59 As String = "StoricoPresenzeIstatC59"

   Const NOME_CMD_ATTIVA_MODULO As String = "Attiva modulo"
   Const NOME_CMD_DISATTIVA_MODULO As String = "Disattiva modulo"
   Const NOME_CMD_ATTIVA_PRODOTTO As String = "Attiva prodotto"
   Const NOME_CMD_DISATTIVA_PRODOTTO As String = "Disattiva prodotto"

   Const MSG_ATTIVA_PRODOTTO As String = "Procedendo con l'operazione verrà attivato il prodotto o modulo selezionato e aggiunte ulteriori funzionalità al software. Procedere?"
   Const MSG_DISATTIVA_PRODOTTO As String = "Procedendo con l'operazione verrà disattivato il prodotto o modulo selezionato e rimosse le relative funzionalità al software. Procedere?"
   Const MSG_RIMOSSI_TUTTI_PRODOTTI As String = "Sono stati rimossi tutti i prodotti, per utilizzare nuovamente il software è necessario inserire almeno un codice di attivazione per il prodotto desiderato."
   Const MSG_PRODOTTO_DISATTIVATO As String = "Il modulo o prodotto è stato disattivato!"
   Const MSG_PRODOTTO_NON_DISPONIBILE As String = "Il prodotto non può essere attivato perchè non ancora disponibile!"
   Const MSG_ATTIVARE_IL_PRODOTTO As String = "Il modulo non può essere attivato! E' necessario attivare prima il prodotto "
   Const MSG_ATTIVARE_UN_PRODOTTO As String = "Il modulo non può essere attivato! E' necessario attivare prima un prodotto."

   Public Const TESTO_FILTRO_PERIODO As String = "Dal... Al..."

   Private DatiConfig As AppConfig
   Private Pwd As String
   Private impostaListaModuli As Boolean = False
   Private CFormatta As New ClsFormatta

#End Region

#Region "Procedure per Tavoloso"

   Public Sub LeggiFilePrenTavoloso(ByVal abilita As Boolean)
      Try
         Const NOME_FILE_PREN As String = "tvlagt*"
         If abilita = False Then
            Exit Sub
         End If

         Dim riga As String
         Dim fileComandi() As String

         ' Controlla se ci sono file da leggere.
         fileComandi = Directory.GetFiles(PercorsoCartellaTavAgent, NOME_FILE_PREN)

         ' Se non ci sono file da leggere...
         If fileComandi.Length = 0 Then
            Exit Sub
         End If

         Timer2.Enabled = False

         Array.Sort(fileComandi)

         Dim i As Integer
         For i = 0 To fileComandi.Length - 1
            If File.Exists(fileComandi(i)) = True Then
               Dim leggiFile As New StreamReader(fileComandi(i))
               Dim datiRiga As String() = Nothing

               Do While leggiFile.Peek >= 0
                  riga = leggiFile.ReadLine()

                  ' Altrimenti vengono identificati i dati.
                  datiRiga = riga.Split(vbTab)
               Loop

               ' Salva i dati nel database.
               Dim campiPren(8) As String
               Dim y As Integer
               For y = 0 To datiRiga.Length - 1
                  campiPren(y) = datiRiga(y)
               Next

               If SalvaPrenTavoloso(campiPren(0), campiPren(1), campiPren(2), campiPren(3), campiPren(4), campiPren(5), campiPren(6), campiPren(7), campiPren(8)) = True Then
                  If IsNothing(g_frmPren) = False Then
                     ' Aggiorna la griglia dati.
                     g_frmPren.AggiornaDati()
                  End If

                  leggiFile.Close()

                  ' Se il file è stato letto correttamente lo cancella. 
                  If File.Exists(fileComandi(i)) = True Then
                     File.Delete(fileComandi(i))
                  End If
               End If
            End If
         Next

         ' Riproduce un effetto sonoro.
         If EffettoSonoroPren = True Then
            RiproduciEffettoSonoro(My.Resources.notifica_Prenotazioni, EffettoSonoroPren)
         End If

         ' Visualizza un messaggio nella barra di stato.
         Me.eui_Informazioni.Text = "Sono arrivate nuove prenotazioni!"

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         Timer2.Enabled = True
      End Try
   End Sub

   Public Function LeggiPrimoIdRisorsa(ByVal tabella As String) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT MIN(Id) FROM " & tabella, cn)
         Return Convert.ToInt32(cmd.ExecuteScalar())

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiPrimaDescrizioneRisorsa(ByVal tabella As String, ByVal Id As Integer) As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & Id, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Descrizione")
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Private Function SalvaPrenTavoloso(ByVal idPren As String, ByVal cognomeCliente As String, ByVal nomeCliente As String, ByVal telefono As String, ByVal eMail As String,
                              ByVal dataPren As String, ByVal oraPren As String, ByVal numPersone As String, ByVal note As String) As Boolean
      Try
         Dim IPren As New Prenotazione

         With IPren
            ' Assegna i dati dei campi della classe alle caselle di testo.

            ' ID prenotazione da Tavoloso. Non viene utilizzata!
            .IdPren = idPren

            ' Data prenotazione.
            .Data = FormattaData(Convert.ToDateTime(dataPren), True)

            ' Nome cliente.
            .Cliente = FormattaApici(cognomeCliente) & " " & FormattaApici(nomeCliente)

            ' Telefono.
            .Telefono = telefono

            ' E-mail.
            .eMail = eMail

            ' Dati del Tavolo. Per Tavoloso non vengono inseriti.
            .IdRisorsa = LeggiPrimoIdRisorsa(ANA_TAVOLI)
            .DescrizioneRisorsa = LeggiPrimaDescrizioneRisorsa(ANA_TAVOLI, .IdRisorsa)

            'Numero persone.
            .Persone = numPersone

            ' Ora prenotazione.
            Dim timeInizio As DateTime = Convert.ToDateTime(oraPren)
            Dim timeFine As DateTime = timeInizio.AddMinutes(30)
            .OraInizio = RimuoviSecondi(oraPren)
            .OraFine = timeFine.Hour.ToString & ":" & timeFine.Minute.ToString

            ' Note.
            .Note = FormattaApici(note)

            ' Colore.
            If .Colore = 0 Then
               .Colore = Convert.ToInt32(ColorePrenTavAgent.ToArgb)
            End If

            Return .InserisciDati(NOME_TABELLA_PREN)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

#End Region

#Region "Procedure"

   Private Sub LeggiDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         If DatiConfig.GetValue("NomePostazione") = String.Empty Then
            eui_cmdPostazione.Text = "P0001"
            eui_cmdPostazione.ScreenTip.Text = "Postazione di lavoro"
         Else
            eui_cmdPostazione.Text = DatiConfig.GetValue("NomePostazione")
            eui_cmdPostazione.ScreenTip.Text = DatiConfig.GetValue("DescrizionePostazione")
         End If

         If DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) = String.Empty Then
            PercorsoDB = DatiConfig.GetValue("PercorsoDB")
            If PercorsoDB.Length = 0 Then
               PercorsoDB = Application.StartupPath & PERCORSO_DB

            ElseIf File.Exists(PercorsoDB) = False Then
               ' In caso di Recovery su computer diversi dall'installazione imposta il percoso di base per evitare errori.
               PercorsoDB = Application.StartupPath & PERCORSO_DB
            End If

            PercorsoDBClienti = DatiConfig.GetValue("PercorsoDBClienti")
            If PercorsoDBClienti.Length = 0 Then
               PercorsoDBClienti = Application.StartupPath & PERCORSO_DB_CLIENTI

            ElseIf File.Exists(PercorsoDBClienti) = False Then
               ' In caso di Recovery su computer diversi dall'installazione imposta il percoso di base per evitare errori.
               PercorsoDBClienti = Application.StartupPath & PERCORSO_DB_CLIENTI
            End If

            PercorsoBKP = DatiConfig.GetValue("PercorsoBKP")
            If PercorsoBKP.Length = 0 Then
               PercorsoBKP = Application.StartupPath & PERCORSO_BKP

            ElseIf File.Exists(PercorsoBKP) = False Then
               ' In caso di Recovery su computer diversi dall'installazione imposta il percoso di base per evitare errori.
               PercorsoBKP = Application.StartupPath & PERCORSO_BKP
            End If

         Else
            PercorsoDB = Application.StartupPath & PERCORSO_DB
            PercorsoDBClienti = Application.StartupPath & PERCORSO_DB_CLIENTI
            PercorsoBKP = Application.StartupPath & PERCORSO_BKP

         End If

         If DatiConfig.GetValue("SalvaBKP") <> "" Then
            SalvaBKP = DatiConfig.GetValue("SalvaBKP")
         Else
            SalvaBKP = True
         End If

         dimPagina = CInt(DatiConfig.GetValue("NumElememti"))

         If DatiConfig.GetValue("WindowState") = CStr(FormWindowState.Maximized) Then
            Me.WindowState = FormWindowState.Maximized
         Else
            If DatiConfig.GetValue("AMain") <> "" Then
               Me.Height = CInt(DatiConfig.GetValue("AMain"))
            Else
               Me.Height = FORM_MAIN_ALTEZZA
            End If

            If DatiConfig.GetValue("LMain") <> "" Then
               Me.Width = CInt(DatiConfig.GetValue("LMain"))
            Else
               Me.Width = FORM_MAIN_LARGHEZZA
            End If

            If DatiConfig.GetValue("MainX") <> "" Then
               Me.Location = New Point(CInt(DatiConfig.GetValue("MainX")), Me.Location.Y)
            Else
               Me.CenterToScreen()
            End If

            If DatiConfig.GetValue("MainY") <> "" Then
               Me.Location = New Point(Me.Location.X, CInt(DatiConfig.GetValue("MainY")))
            Else
               Me.CenterToScreen()
            End If
         End If

         Dim reparto As String
         Dim stampante As String
         Dim report As String
         ' Comanda - Percorso 1.
         reparto = DatiConfig.GetValue("Reparto1")
         If reparto.Length = 0 Then
            reparto = VAL_NESSUNO
         End If
         stampante = DatiConfig.GetValue("PercorsoStampaComanda1")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComanda1")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(0) = reparto & ";" & stampante & ";" & report

         ' Comanda - Percorso 2.
         reparto = DatiConfig.GetValue("Reparto2")
         If reparto.Length = 0 Then
            reparto = VAL_NESSUNO
         End If
         stampante = DatiConfig.GetValue("PercorsoStampaComanda2")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComanda2")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(1) = reparto & ";" & stampante & ";" & report

         ' Comanda - Percorso 3.
         reparto = DatiConfig.GetValue("Reparto3")
         If reparto.Length = 0 Then
            reparto = VAL_NESSUNO
         End If
         stampante = DatiConfig.GetValue("PercorsoStampaComanda3")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComanda3")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(2) = reparto & ";" & stampante & ";" & report

         ' Comanda - Percorso 4.
         reparto = DatiConfig.GetValue("Reparto4")
         If reparto.Length = 0 Then
            reparto = VAL_NESSUNO
         End If
         stampante = DatiConfig.GetValue("PercorsoStampaComanda4")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComanda4")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(3) = reparto & ";" & stampante & ";" & report

         ' Comanda - Percorso 5.
         reparto = DatiConfig.GetValue("Reparto5")
         If reparto.Length = 0 Then
            reparto = VAL_NESSUNO
         End If
         stampante = DatiConfig.GetValue("PercorsoStampaComanda5")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComanda5")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(4) = reparto & ";" & stampante & ";" & report

         ' Comanda - Percorso 6.
         reparto = DatiConfig.GetValue("Reparto6")
         If reparto.Length = 0 Then
            reparto = VAL_NESSUNO
         End If
         stampante = DatiConfig.GetValue("PercorsoStampaComanda6")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComanda6")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(5) = reparto & ";" & stampante & ";" & report

         ' Comanda - Percorso 7.
         reparto = DatiConfig.GetValue("Reparto7")
         If reparto.Length = 0 Then
            reparto = VAL_NESSUNO
         End If
         stampante = DatiConfig.GetValue("PercorsoStampaComanda7")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComanda7")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(6) = reparto & ";" & stampante & ";" & report

         ' Comanda - Percorso 8.
         reparto = DatiConfig.GetValue("Reparto8")
         If reparto.Length = 0 Then
            reparto = VAL_NESSUNO
         End If
         stampante = DatiConfig.GetValue("PercorsoStampaComanda8")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComanda8")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(7) = reparto & ";" & stampante & ";" & report

         ' Comanda - Percorso 9.
         reparto = DatiConfig.GetValue("Reparto9")
         If reparto.Length = 0 Then
            reparto = VAL_NESSUNO
         End If
         stampante = DatiConfig.GetValue("PercorsoStampaComanda9")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComanda9")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(8) = reparto & ";" & stampante & ";" & report

         ' Comanda - Percorso 10.
         reparto = DatiConfig.GetValue("Reparto10")
         If reparto.Length = 0 Then
            reparto = VAL_NESSUNO
         End If
         stampante = DatiConfig.GetValue("PercorsoStampaComanda10")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComanda10")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(9) = reparto & ";" & stampante & ";" & report

         ' Comanda aggiuntiva.
         stampante = DatiConfig.GetValue("PercorsoStampaComandaAgg")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportComandaAgg")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiComande(10) = "Agg" & ";" & stampante & ";" & report

         ' Ricevuta.
         stampante = DatiConfig.GetValue("PercorsoStampaRicevute")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportRicevute")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiDocumenti(0) = "RICEVUTA" & ";" & stampante & ";" & report

         ' Fattura.
         stampante = DatiConfig.GetValue("PercorsoStampaFatture")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportFatture")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiDocumenti(1) = "FATTURA" & ";" & stampante & ";" & report

         ' Proforma.
         stampante = DatiConfig.GetValue("PercorsoStampaProforma")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportProforma")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiDocumenti(2) = "PROFORMA" & ";" & stampante & ";" & report

         ' Scontrino.
         stampante = DatiConfig.GetValue("PercorsoStampaScontrini")
         If stampante.Length = 0 Then
            stampante = VALORE_NESSUNA
         End If
         report = DatiConfig.GetValue("ReportScontrini")
         If report.Length = 0 Then
            report = String.Empty
         End If
         PercorsiStampantiDocumenti(3) = "SCONTRINO" & ";" & stampante & ";" & report

         ' SCHEDA STAMPANTI FISCALI

         ProduttoreSF = DatiConfig.GetValue("ProduttoreSF")
         If ProduttoreSF.Length = 0 Then
            ProduttoreSF = ""
         End If
         ModelloSF = DatiConfig.GetValue("ModelloSF")
         If ModelloSF.Length = 0 Then
            ModelloSF = ""
         End If

         ' RCH Swing ECR A/65
         PortaSF = DatiConfig.GetValue("PortaSF")
         If PortaSF.Length = 0 Then
            PortaSF = ""
         End If
         ParametriSF = DatiConfig.GetValue("ParametriSF")
         If ParametriSF.Length = 0 Then
            ParametriSF = ""
         End If
         NomeScontrinoSF = DatiConfig.GetValue("NomeScontrinoSF")
         If NomeScontrinoSF.Length = 0 Then
            NomeScontrinoSF = ""
         End If
         PercorsoOutputSF = DatiConfig.GetValue("PercorsoOutputSF")
         If PercorsoOutputSF.Length = 0 Then
            PercorsoOutputSF = ""
         End If
         PercorsoDriverSF = DatiConfig.GetValue("PercorsoDriverSF")
         If PercorsoDriverSF.Length = 0 Then
            PercorsoDriverSF = ""
         End If

         ' Driver RTS WPOS1.
         PercorsoDriverWpos1 = DatiConfig.GetValue("PercorsoDriverWpos1")
         If PercorsoDriverWpos1.Length = 0 Then
            PercorsoDriverWpos1 = ""
         End If

         PercorsoLavoroWpos1 = DatiConfig.GetValue("PercorsoLavoroWpos1")
         If PercorsoLavoroWpos1.Length = 0 Then
            PercorsoLavoroWpos1 = ""
         End If

         PwdDriverWpos1 = DatiConfig.GetValue("PwdDriverWpos1")
         If PwdDriverWpos1.Length = 0 Then
            PwdDriverWpos1 = ""
         End If
         EstensioneFileWpos1 = DatiConfig.GetValue("EstensioneFileWpos1")
         If EstensioneFileWpos1.Length = 0 Then
            EstensioneFileWpos1 = ""
         End If

         ' DISPOSITIVO PALMARE
         PercorsoRP = DatiConfig.GetValue("PercorsoRP")
         If PercorsoRP.Length = 0 Then
            PercorsoRP = ""
         End If
         If DatiConfig.GetValue("AbilitaPalmareWindows") <> "" Then
            AbilitaPalmareWindows = DatiConfig.GetValue("AbilitaPalmareWindows")
         Else
            AbilitaPalmareWindows = False
         End If
         If DatiConfig.GetValue("AbilitaPalmareAndroid") <> "" Then
            AbilitaPalmareAndroid = DatiConfig.GetValue("AbilitaPalmareAndroid")
         Else
            AbilitaPalmareAndroid = False
         End If

         FreqAggPalmare = Convert.ToInt16(DatiConfig.GetValue("FreqAggPalmare"))

         ' SCHEDA BAR / RISTORANTE.

         ' Aliquota IVA standard.
         If DatiConfig.GetValue("AliquotaIvaRistorante") = String.Empty Then
            AliquotaIvaRistorante = String.Empty
         Else
            AliquotaIvaRistorante = DatiConfig.GetValue("AliquotaIvaRistorante")
         End If

         ' Prezzo del Coperto.
         If DatiConfig.GetValue("CopertoRistorante") = String.Empty Then
            CopertoRistorante = VALORE_ZERO
         Else
            CopertoRistorante = DatiConfig.GetValue("CopertoRistorante")
         End If

         ' Percentuale per il Servizio.
         If DatiConfig.GetValue("ServizioRistorante") = String.Empty Then
            ServizioRistorante = VALORE_ZERO
         Else
            ServizioRistorante = DatiConfig.GetValue("ServizioRistorante")
         End If

         ' Effetti sonori per il Punto cassa.
         If DatiConfig.GetValue("EffettiSonoriPOS") = String.Empty Then
            EffettiSonoriPOS = True
         Else
            EffettiSonoriPOS = DatiConfig.GetValue("EffettiSonoriPOS")
         End If

         ' IMPOSTAZIONI PER LE PRENOTAZIONI DEI TAVOLI FATTE DA INTERNET. (WWW.TAVOLOSO.IT)

         ' Percorso cartella di lavoro Tavoloso Agent.
         If DatiConfig.GetValue("PercorsoCartellaTavAgent") <> String.Empty Then
            PercorsoCartellaTavAgent = DatiConfig.GetValue("PercorsoCartellaTavAgent")
         Else
            PercorsoCartellaTavAgent = String.Empty
         End If

         ' Abilita ricezione delle prenotazioni.
         If DatiConfig.GetValue("AbilitaRicezionePren") <> String.Empty Then
            AbilitaRicezionePren = DatiConfig.GetValue("AbilitaRicezionePren")
         Else
            AbilitaRicezionePren = True
         End If

         ' Effetto sonoro per la notifica delle prenotazioni.
         If DatiConfig.GetValue("EffettoSonoroPren") <> String.Empty Then
            EffettoSonoroPren = DatiConfig.GetValue("EffettoSonoroPren")
         Else
            EffettoSonoroPren = True
         End If

         ' Colore della prenotazione.
         If DatiConfig.GetValue("ColorePrenTavAgent") <> String.Empty Then
            Dim colore As Integer = Convert.ToInt32(DatiConfig.GetValue("ColorePrenTavAgent"))
            ColorePrenTavAgent = Color.FromArgb(colore)
         Else
            ColorePrenTavAgent = Color.White
         End If

         ' SCHEDA CENTRO SPORTIVO.

         ' Aliquota IVA standard.
         If DatiConfig.GetValue("AliquotaIvaCentroSportivo") = String.Empty Then
            AliquotaIvaCentroSportivo = String.Empty
         Else
            AliquotaIvaCentroSportivo = DatiConfig.GetValue("AliquotaIvaCentroSportivo")
         End If

         ' SCHEDA HOTEL.

         ' Aliquota IVA standard.
         If DatiConfig.GetValue("AliquotaIvaHotel") = String.Empty Then
            AliquotaIvaHotel = String.Empty
         Else
            AliquotaIvaHotel = DatiConfig.GetValue("AliquotaIvaHotel")
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         If dimPagina = 0 Then
            dimPagina = DIM_PAGINA
         End If

         If FreqAggPalmare = 0 Then
            FreqAggPalmare = 15
         End If
      End Try
   End Sub

   Public Sub SalvaDatiConfig()
      Try
         ' Nel caso la directory corrente venga cambiata.
         Environment.CurrentDirectory = Application.StartupPath

         ' Salva il nome del prodotto attivo che viene letto nel form App_Load per impostare le immagini.
         DatiConfig.SetValue("NomeProdotto", NOME_PRODOTTO)

         If PercorsoDB.Length = 0 Then
            DatiConfig.SetValue("PercorsoDB", Application.StartupPath & PERCORSO_DB)
         Else
            DatiConfig.SetValue("PercorsoDB", PercorsoDB)
         End If

         If PercorsoDBClienti.Length = 0 Then
            DatiConfig.SetValue("PercorsoDBClienti", Application.StartupPath & PERCORSO_DB_CLIENTI)
         Else
            DatiConfig.SetValue("PercorsoDBClienti", PercorsoDBClienti)
         End If

         DatiConfig.SetValue("NumElememti", dimPagina)

         DatiConfig.SetValue("WindowState", Me.WindowState)
         DatiConfig.SetValue("MainX", Me.Location.X)
         DatiConfig.SetValue("MainY", Me.Location.Y)
         DatiConfig.SetValue("AMain", Me.Height)
         DatiConfig.SetValue("LMain", Me.Width)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function LeggiGiudizioInviatoConfig() As String
      Try

         Return DatiConfig.GetValue("GiudizioInviato")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return "No"
      End Try

   End Function

   Public Sub SalvaGiudizioInviatoConfig(ByVal inviato As String)
      Try

         DatiConfig.SetValue("GiudizioInviato", inviato)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Sub ImpostaFunzioniOperatore(ByVal wnd As String)

      Select Case wnd
         Case Finestra.Aziende
            If operatore.AnagAziende = VALORE_NESSUNO Then
               eui_cmdArchiviAnagraficheAziende.Enabled = False
            Else
               eui_cmdArchiviAnagraficheAziende.Enabled = True
            End If
         Case Finestra.Camerieri
            If operatore.AnagCamerieri = VALORE_NESSUNO Then
               eui_cmdArchiviAnagraficheCamerieri.Enabled = False
            Else
               eui_cmdArchiviAnagraficheCamerieri.Enabled = True
            End If
         Case Finestra.CatPiatti
            If operatore.AnagCatPiatti = VALORE_NESSUNO Then
               eui_cmdArchiviAnagraficheCategoriePiatti.Enabled = False
            Else
               eui_cmdArchiviAnagraficheCategoriePiatti.Enabled = True
            End If
         Case Finestra.Clienti
            If operatore.AnagClienti = VALORE_NESSUNO Then
               eui_cmdArchiviAnagraficheClienti.Enabled = False
            Else
               eui_cmdArchiviAnagraficheClienti.Enabled = True
            End If

         Case Finestra.DatiAzienda
            If operatore.AnagDatiAzienda = VALORE_NESSUNO Then
               eui_cmdArchiviAnagraficheDatiAzienda.Enabled = False
            Else
               eui_cmdArchiviAnagraficheDatiAzienda.Enabled = True
            End If
         Case Finestra.Fornitori
            If operatore.AnagFornitori = VALORE_NESSUNO Then
               eui_cmdArchiviAnagraficheFornitori.Enabled = False
            Else
               eui_cmdArchiviAnagraficheFornitori.Enabled = True
            End If

         Case Finestra.Piatti
            If operatore.AnagPiatti = VALORE_NESSUNO Then
               eui_cmdArchiviAnagrafichePiatti.Enabled = False
            Else
               eui_cmdArchiviAnagrafichePiatti.Enabled = True
            End If

         Case Finestra.Sale
            If operatore.AnagSale = VALORE_NESSUNO Then
               eui_cmdArchiviAnagraficheSale.Enabled = False
            Else
               eui_cmdArchiviAnagraficheSale.Enabled = True
            End If

         Case Finestra.Tavoli
            If operatore.AnagTavoli = VALORE_NESSUNO Then
               eui_cmdArchiviAnagraficheTavoli.Enabled = False
            Else
               eui_cmdArchiviAnagraficheTavoli.Enabled = True
            End If

         Case Finestra.Risorse
            If operatore.AnagRisorse = VALORE_NESSUNO Then
               eui_cmdArchiviAnagraficheRisorse.Enabled = False
            Else
               eui_cmdArchiviAnagraficheRisorse.Enabled = True
            End If

         Case Finestra.AccessoriServizi
            If operatore.AnagAccessoriServizi = VALORE_NESSUNO Then
               eui_cmdArchiviAnagraficheAccServ.Enabled = False
            Else
               eui_cmdArchiviAnagraficheAccServ.Enabled = True
            End If

         Case Finestra.Backup
            If operatore.ArchiviBackup = VALORE_NESSUNO Then
               eui_cmdArchiviBackup.Enabled = False
            Else
               eui_cmdArchiviBackup.Enabled = True
            End If

         Case Finestra.Compatta
            If operatore.ArchiviCompatta = VALORE_NESSUNO Then
               eui_cmdArchiviCompatta.Enabled = False
            Else
               eui_cmdArchiviCompatta.Enabled = True
            End If

         Case Finestra.Pulizia
            If operatore.ArchiviPulizia = VALORE_NESSUNO Then
               eui_cmdArchiviPulizia.Enabled = False
            Else
               eui_cmdArchiviPulizia.Enabled = True
            End If

         Case Finestra.Attività
            If operatore.TabAttività = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleAttività.Enabled = False
            Else
               eui_cmdArchiviTabelleAttività.Enabled = True
            End If

         Case Finestra.CatCliente
            If operatore.TabCatClienti = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleCategorieCliente.Enabled = False
            Else
               eui_cmdArchiviTabelleCategorieCliente.Enabled = True
            End If

         Case Finestra.CatMerce
            If operatore.TabCatMerce = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleCategorieMerce.Enabled = False
            Else
               eui_cmdArchiviTabelleCategorieMerce.Enabled = True
            End If

         Case Finestra.FormeCortesia
            If operatore.TabFormeCortesia = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleTitoli.Enabled = False
            Else
               eui_cmdArchiviTabelleTitoli.Enabled = True
            End If

         Case Finestra.Magazzini
            If operatore.TabMagazzini = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleMagazzini.Enabled = False
            Else
               eui_cmdArchiviTabelleMagazzini.Enabled = True
            End If

         Case Finestra.MsgReparti
            If operatore.TabMsg = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleMsgReparti.Enabled = False
            Else
               eui_cmdArchiviTabelleMsgReparti.Enabled = True
            End If

         Case Finestra.Nazioni
            If operatore.TabNazioni = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleNazioni.Enabled = False
            Else
               eui_cmdArchiviTabelleNazioni.Enabled = True
            End If

         Case Finestra.Pagamenti
            If operatore.TabPagamenti = VALORE_NESSUNO Then
               eui_cmdArchiviTabellePagamenti.Enabled = False
            Else
               eui_cmdArchiviTabellePagamenti.Enabled = True
            End If

         Case Finestra.Reparti
            If operatore.TabReparti = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleReparti.Enabled = False
            Else
               eui_cmdArchiviTabelleReparti.Enabled = True
            End If

         Case Finestra.Scaffali
            If operatore.TabScaffali = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleScaffali.Enabled = False
            Else
               eui_cmdArchiviTabelleScaffali.Enabled = True
            End If

         Case Finestra.CausaliDoc
            If operatore.TabCausaliDoc = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleCausaliDoc.Enabled = False
            Else
               eui_cmdArchiviTabelleCausaliDoc.Enabled = True
            End If

         Case Finestra.Ubicazioni
            If operatore.TabUbicazioni = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleUbicazioni.Enabled = False
            Else
               eui_cmdArchiviTabelleUbicazioni.Enabled = True
            End If

         Case Finestra.UnitàMisura
            If operatore.TabUM = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleUM.Enabled = False
            Else
               eui_cmdArchiviTabelleUM.Enabled = True
            End If

         Case Finestra.TipologieRisorse
            If operatore.TabTipoRisorse = VALORE_NESSUNO Then
               eui_cmdArchiviTabelleTipoRisorse.Enabled = False
            Else
               eui_cmdArchiviTabelleTipoRisorse.Enabled = True
            End If

         Case Finestra.ChiusuraGiornaliera
            If operatore.ContChiusura = VALORE_NESSUNO Then
               eui_ContabilitàChiusura.Enabled = False
            Else
               eui_ContabilitàChiusura.Enabled = True
            End If

         Case Finestra.Corrispettivi
            If operatore.ContCorrispettivi = VALORE_NESSUNO Then
               eui_ContabilitàCorrispettivi.Enabled = False
            Else
               eui_ContabilitàCorrispettivi.Enabled = True
            End If

         Case Finestra.Documenti
            If operatore.ContDoc = VALORE_NESSUNO Then
               eui_ContabilitàElencoDocVendita.Enabled = False
            Else
               eui_ContabilitàElencoDocVendita.Enabled = True
            End If

         Case Finestra.PrimaNota
            If operatore.ContPrimaNota = VALORE_NESSUNO Then
               eui_ContabilitàPrimaNota.Enabled = False
            Else
               eui_ContabilitàPrimaNota.Enabled = True
            End If

         Case Finestra.Acquisti
            If operatore.GestAcquisti = VALORE_NESSUNO Then
               eui_ContabilitàElencoDocAcquisto.Enabled = False
            Else
               eui_ContabilitàElencoDocAcquisto.Enabled = True
            End If

         Case Finestra.Menù
            If operatore.StruMenù = VALORE_NESSUNO Then
               eui_StrumentiMenù.Enabled = False
            Else
               eui_StrumentiMenù.Enabled = True
            End If

         Case Finestra.Gruppi
            If operatore.GestGruppi = VALORE_NESSUNO Then
               eui_cmdGestioneGruppiOp.Enabled = False
            Else
               eui_cmdGestioneGruppiOp.Enabled = True
            End If

         Case Finestra.Operatori
            If operatore.GestOperatori = VALORE_NESSUNO Then
               eui_cmdGestioneOperatori.Enabled = False
            Else
               eui_cmdGestioneOperatori.Enabled = True
            End If

         Case Finestra.PrenSale
            If operatore.GestPrenSale = VALORE_NESSUNO Then
               eui_cmdGestionePrenSale.Enabled = False
            Else
               eui_cmdGestionePrenSale.Enabled = True
            End If

         Case Finestra.PrenTavoli
            If operatore.GestPrenTavoli = VALORE_NESSUNO Then
               eui_cmdGestionePrenTavoli.Enabled = False
            Else
               eui_cmdGestionePrenTavoli.Enabled = True
            End If

         Case Finestra.PrenRisorse
            If operatore.GestPrenRisorse = VALORE_NESSUNO Then
               eui_cmdGestionePrenRisorse.Enabled = False
            Else
               eui_cmdGestionePrenRisorse.Enabled = True
            End If

         Case Finestra.PlanningRisorse
            If operatore.GestPlanningRisorse = VALORE_NESSUNO Then
               eui_cmdGestionePlanningRisorseSport.Enabled = False
            Else
               eui_cmdGestionePlanningRisorseSport.Enabled = True
            End If

         Case Finestra.StatisticheRisorse
            If operatore.GestStatRisorse = VALORE_NESSUNO Then
               eui_cmdGestioneStatisticheRisorse.Enabled = False
            Else
               eui_cmdGestioneStatisticheRisorse.Enabled = True
            End If

         Case Finestra.PuntoCassa
            If operatore.GestPuntoCassa = VALORE_NESSUNO Then
               eui_cmdGestionePosCassa.Enabled = False
            Else
               eui_cmdGestionePosCassa.Enabled = True
            End If

         Case Finestra.Statistiche
            If operatore.GestStatistiche = VALORE_NESSUNO Then
               eui_cmdGestioneStatistiche.Enabled = False
            Else
               eui_cmdGestioneStatistiche.Enabled = True
            End If

         Case Finestra.TavoliConto
            If operatore.GestTavoli = VALORE_NESSUNO Then
               eui_cmdGestionePosTavoli.Enabled = False
            Else
               eui_cmdGestionePosTavoli.Enabled = True
            End If

         Case Finestra.Articoli
            If operatore.MagArticoli = VALORE_NESSUNO Then
               eui_MagazzinoArticoli.Enabled = False
            Else
               eui_MagazzinoArticoli.Enabled = True
            End If

         Case Finestra.Inventario
            If operatore.MagInventario = VALORE_NESSUNO Then
               eui_MagazzinoInventario.Enabled = False
            Else
               eui_MagazzinoInventario.Enabled = True
            End If

         Case Finestra.Scorte
            If operatore.MagScorte = VALORE_NESSUNO Then
               eui_MagazzinoScorte.Enabled = False
            Else
               eui_MagazzinoScorte.Enabled = True
            End If

         Case Finestra.MovimentiMag
            If operatore.MagMovimenti = VALORE_NESSUNO Then
               eui_MagazzinoMovimenti.Enabled = False
            Else
               eui_MagazzinoMovimenti.Enabled = True
            End If

         Case Finestra.DisponiTavoli
            If operatore.StruDispTavoli = VALORE_NESSUNO Then
               eui_StrumentiDispTavoli.Enabled = False
            Else
               eui_StrumentiDispTavoli.Enabled = True
            End If

         Case Finestra.ElencoCap
            If operatore.StruCap = VALORE_NESSUNO Then
               eui_StrumentiCap.Enabled = False
            Else
               eui_StrumentiCap.Enabled = True
            End If

         Case Finestra.ElencoMsg
            If operatore.StruMsg = VALORE_NESSUNO Then
               eui_StrumentiMsgReparti.Enabled = False
            Else
               eui_StrumentiMsgReparti.Enabled = True
            End If

         Case Finestra.CodiciBarre
            If operatore.StruCodiciBarre = VALORE_NESSUNO Then
               eui_StrumentiEtichette.Enabled = False
            Else
               eui_StrumentiEtichette.Enabled = True
            End If

         Case Finestra.Opzioni
            If operatore.VisOpzioni = VALORE_NESSUNO Then
               eui_Opzioni.Enabled = False
            Else
               eui_Opzioni.Enabled = True
            End If

         Case Finestra.RegErrori
            If operatore.VisErrori = VALORE_NESSUNO Then
               eui_VisualizzaRegErrori.Enabled = False
            Else
               eui_VisualizzaRegErrori.Enabled = True
            End If

         Case Finestra.RegOperazioni
            If operatore.VisOperazioni = VALORE_NESSUNO Then
               eui_VisualizzaRegOperazioni.Enabled = False
            Else
               eui_VisualizzaRegOperazioni.Enabled = True
            End If

      End Select

   End Sub

   Public Sub RegistraOperazione(ByVal Operazione As String, ByVal descrizione As String, ByVal modulo As String)
      Try
         Dim COperazioni As New Operazioni
         Dim descrizioneOp As String

         Select Case Operazione
            Case TipoOperazione.Login
               descrizioneOp = "Effettuata IDENTIFICAZIONE per l'operatore. " & descrizione

            Case TipoOperazione.Logout
               descrizioneOp = "Eseguito comando CAMBIA OPERATORE. " & descrizione

            Case TipoOperazione.Apri
               descrizioneOp = "Eseguito comando APRI per " & descrizione

            Case TipoOperazione.Chiudi
               descrizioneOp = "Eseguito comando CHIUDI per " & descrizione

            Case TipoOperazione.Nuovo
               descrizioneOp = "Eseguito comando NUOVO per " & descrizione

            Case TipoOperazione.Modifica
               descrizioneOp = "Eseguito comando MODIFICA. " & descrizione

            Case TipoOperazione.Elimina
               descrizioneOp = "Eseguito comando ELIMINA. " & descrizione

            Case TipoOperazione.EliminaTutto
               descrizioneOp = "Eseguito comando ELIMINA TUTTO. " & descrizione

            Case TipoOperazione.Aggiorna
               descrizioneOp = "Eseguito comando AGGIORNA per " & descrizione

            Case TipoOperazione.Anteprima
               descrizioneOp = "Eseguito comando ANTEPRIMA DI STAMPA per " & descrizione

            Case TipoOperazione.Stampa
               descrizioneOp = "Eseguito comando STAMPA per " & descrizione

            Case TipoOperazione.Annulla
               descrizioneOp = "Eseguito comando ANNULLA per operazione di Inserimeno o Modifica dati."

            Case TipoOperazione.Salva
               descrizioneOp = "Eseguito comando SALVA. " & descrizione

            Case TipoOperazione.Carico
               descrizioneOp = "Eseguito comando CARICO. " & descrizione

            Case TipoOperazione.Scarico
               descrizioneOp = "Eseguito comando SCARICO. " & descrizione

            Case TipoOperazione.Backup
               descrizioneOp = "Eseguito comando BACKUP DEI DATI."

            Case TipoOperazione.Pulizia
               descrizioneOp = "Eseguito comando PULIZIA DEGLI ARCHIVI."

            Case TipoOperazione.Compatta
               descrizioneOp = "Eseguito comando COMPATTA E RIPRISTINA per i dati degli archivi."

            Case TipoOperazione.Chiusura
               descrizioneOp = "Eseguito comando CHIUSURA GIORNALIERA."

            Case TipoOperazione.AnnullaDoc
               descrizioneOp = "Eseguito comando ANNULLA DOCUMENTO. " & descrizione

            Case TipoOperazione.IncassaSospeso
               descrizioneOp = "Eseguito comando INCASSA SOSPESO. " & descrizione

            Case TipoOperazione.PassaSospeso
               descrizioneOp = "Eseguito comando PASSA A SOSPESO. " & descrizione

            Case TipoOperazione.AnnullaSospeso
               descrizioneOp = "Eseguito comando ANNULLA SOSPESO. " & descrizione

            Case TipoOperazione.ModificaMenù
               descrizioneOp = "Eseguito comando di MODIFICA. " & descrizione

            Case TipoOperazione.InviaMsg
               descrizioneOp = "Eseguito comando INVIA MESSAGGIO ai reparti. " & descrizione

            Case TipoOperazione.SelezionaPiatto
               descrizioneOp = "Eseguito comando SELEZIONE PIATTO. " & descrizione

            Case TipoOperazione.Listino
               descrizioneOp = "Eseguito comando SELEZIONE LISTINO. " & descrizione

            Case TipoOperazione.QuantitàMeno
               descrizioneOp = "Eseguito comando QUANTITA' MENO. " & descrizione

            Case TipoOperazione.QuantitàPiù
               descrizioneOp = "Eseguito comando QUANTITA' PIU'. " & descrizione

            Case TipoOperazione.Cancella
               descrizioneOp = "Eseguito comando CANCELLA PIATTO. " & descrizione

            Case TipoOperazione.CancellaTutto
               descrizioneOp = "Eseguito comando CANCELLA TUTTI I PIATTI. " & descrizione

            Case TipoOperazione.Escludi
               descrizioneOp = "Eseguito comando ESCLUDI PIATTO DAL CONTO. " & descrizione

            Case TipoOperazione.Offerto
               descrizioneOp = "Eseguito comando PIATTO OFFERTO . " & descrizione

            Case TipoOperazione.Conferma
               descrizioneOp = "Eseguito comando CONFERMA. " & descrizione

            Case TipoOperazione.Proforma
               descrizioneOp = "Eseguito comando STAMPA PROFORMA. " & descrizione

            Case TipoOperazione.Scontrino
               descrizioneOp = "Eseguito comando STAMPA SCONTRINO. " & descrizione

            Case TipoOperazione.Ricevuta
               descrizioneOp = "Eseguito comando STAMPA RICEVUTA FISCALE. " & descrizione

            Case TipoOperazione.Fattura
               descrizioneOp = "Eseguito comando STAMPA FATTURA. " & descrizione

            Case TipoOperazione.ApriTavolo
               descrizioneOp = "Eseguito comando APRI TAVOLO. " & descrizione

            Case TipoOperazione.ChiudiTavolo
               descrizioneOp = "Eseguito comando CHIUDI TAVOLO. " & descrizione

            Case TipoOperazione.SpostaTavolo
               descrizioneOp = "Eseguito comando SPOSTA TAVOLO. " & descrizione

            Case TipoOperazione.OccupaTavolo
               descrizioneOp = "Eseguito comando OCCUPA TAVOLO. " & descrizione

            Case TipoOperazione.LiberaTavolo
               descrizioneOp = "Eseguito comando LIBERA TAVOLO. " & descrizione

            Case TipoOperazione.ApriAsporto
               descrizioneOp = "Eseguito comando APRI ASPORTO. " & descrizione

            Case TipoOperazione.ChiudiAsporto
               descrizioneOp = "Eseguito comando CHIUDI ASPORTO. " & descrizione

            Case TipoOperazione.RimuoviPiatto
               descrizioneOp = "Eseguito comando RIMUOVI PIATTO. " & descrizione

            Case TipoOperazione.ProprietàRisorsa
               descrizioneOp = "Eseguito comando PROPRIETA' RISORSA per " & descrizione

         End Select

         ' Assegna i dati dei campi della classe alle caselle di testo.
         With COperazioni
            .Data = Convert.ToString(Now)
            .Operatore = operatore.Nome
            .Modulo = modulo
            .Descrizione = descrizioneOp

            ' Salva i dati nel database.
            .InserisciDati(NOME_TABELLA)
         End With

         ' Se la finestra è aperta aggiorna la griglia dati.
         If IsNothing(g_frmOperazioni) = False Then
            g_frmOperazioni.AggiornaDati()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub SalvaCopiaBackup()
      Try
         ' Visualizza un messaggio nella barra di stato.
         Me.eui_Informazioni.Text = SALVA_BKP

         If SalvaBKP = True Then
            If File.Exists(PercorsoDB) = True Then
               File.Copy(PercorsoDB, PercorsoBKP, True)
            End If
         End If

         ' Visualizza un messaggio nella barra di stato.
         Me.eui_Informazioni.Text = LeggiDatiRivenditore()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ScriviDatiTavoli(ByVal sw As StreamWriter)
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Tavoli WHERE Escludi = 'No' ORDER BY Descrizione ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         sw.WriteLine("[TAVOLI]")

         Do While dr.Read
            sw.WriteLine(dr.Item("Id") & ";" & dr.Item("Descrizione") & ";" & dr.Item("Posti") & ";" & dr.Item("Listino"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiCategorie(ByVal sw As StreamWriter)
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM CategoriePiatti ORDER BY IdOrd ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         sw.WriteLine("[CATEGORIE]")

         Do While dr.Read
            sw.WriteLine(dr.Item("Id") & ";" & dr.Item("Descrizione") & ";" & dr.Item("Colore"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiPiatti(ByVal sw As StreamWriter)
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Piatti WHERE Variazione = 'No' ORDER BY DescrizionePos ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         sw.WriteLine("[PIATTI]")

         Do While dr.Read
            sw.WriteLine(dr.Item("Id") & ";" & dr.Item("Categoria") & ";" & dr.Item("DescrizionePos") & ";" &
                         dr.Item("Listino1") & ";" & dr.Item("Listino2") & ";" & dr.Item("Listino3") & ";" & dr.Item("Listino4"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiVarianti(ByVal sw As StreamWriter)
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Piatti WHERE Variazione = 'Sì' ORDER BY DescrizionePos ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         sw.WriteLine("[VARIANTI]")

         Do While dr.Read
            sw.WriteLine(dr.Item("Id") & ";" & dr.Item("Categoria") & ";" & dr.Item("DescrizionePos") & ";" &
                                 dr.Item("Listino1") & ";" & dr.Item("Listino2") & ";" & dr.Item("Listino3") & ";" & dr.Item("Listino4"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiCamerieri(ByVal sw As StreamWriter)
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Camerieri ORDER BY Nome ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         sw.WriteLine("[CAMERIERI]")

         Do While dr.Read
            sw.WriteLine(dr.Item("Id") & ";" & dr.Item("Nome"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiMessaggi(ByVal sw As StreamWriter)
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM MessaggiReparti ORDER BY Descrizione ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         sw.WriteLine("[MESSAGGI]")

         Do While dr.Read
            sw.WriteLine(dr.Item("Id") & ";" & dr.Item("Descrizione"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiImpostazione(ByVal sw As StreamWriter)
      Try
         sw.WriteLine("[PERCORSO]")
         sw.WriteLine(PercorsoRP)
         sw.WriteLine("[FREQUENZA]")
         sw.WriteLine(FreqAggPalmare)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub ScriviDatiStatoTavoli(ByVal sw As StreamWriter)
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Tavoli WHERE Escludi = 'No' ORDER BY Descrizione ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         sw.WriteLine("[TAVOLI]")

         Do While dr.Read
            Dim coperti As String
            If dr.Item("Coperti") <> "" Then
               coperti = dr.Item("Coperti")
            Else
               coperti = dr.Item("Posti")
            End If
            sw.WriteLine(dr.Item("Id") & ";" & dr.Item("Descrizione") & ";" & coperti & ";" & dr.Item("Colore"))
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiStatoPiatti(ByVal sw As StreamWriter)
      Dim cn As New OleDbConnection(ConnString)
      Dim strSqlPiatti As String = "SELECT * FROM Piatti WHERE Variazione = 'No' ORDER BY DescrizionePos ASC"
      Dim valEsaurito As String

      Try
         Dim strSql As String
         Dim cmd As New OleDbCommand(strSql, cn)
         Dim numRecEsauriti As Integer = LeggiNumRecord("PiattiEsauriti", cn, cmd)
         Dim idPiattiEsauriti(numRecEsauriti - 1) As String

         cmd.Dispose()

         cn.Open()

         If numRecEsauriti > 0 Then
            Dim strSqlEsauriti As String = "SELECT * FROM PiattiEsauriti ORDER BY Id ASC"
            Dim cmdEsauriti As New OleDbCommand(strSqlEsauriti, cn)
            Dim drEsauriti As OleDbDataReader = cmdEsauriti.ExecuteReader()

            Dim i As Integer = 0
            Do While drEsauriti.Read
               idPiattiEsauriti(i) = drEsauriti.Item("IdPiatto")
               i += 1
            Loop

            cmdEsauriti.Dispose()
            drEsauriti.Close()
         End If

         Dim cmdPiatti As New OleDbCommand(strSqlPiatti, cn)
         Dim drPiatti As OleDbDataReader = cmdPiatti.ExecuteReader()

         sw.WriteLine("[PIATTI]")

         Do While drPiatti.Read
            If numRecEsauriti > 0 Then
               valEsaurito = 1
               Dim i As Integer = 0
               For i = 0 To numRecEsauriti - 1
                  If drPiatti.Item("Id") = idPiattiEsauriti(i) Then
                     valEsaurito = 0
                     Exit For
                  End If
               Next
            Else
               valEsaurito = 1
            End If

            sw.WriteLine(drPiatti.Item("Id") & ";" & drPiatti.Item("Categoria") & ";" & drPiatti.Item("DescrizionePos") & ";" & valEsaurito)
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiStatoVarianti(ByVal sw As StreamWriter)
      Dim cn As New OleDbConnection(ConnString)
      Dim strSqlPiatti As String = "SELECT * FROM Piatti WHERE Variazione = 'Sì' ORDER BY DescrizionePos ASC"
      Dim valEsaurito As String

      Try
         Dim strSql As String
         Dim cmd As New OleDbCommand(strSql, cn)
         Dim numRecEsauriti As Integer = LeggiNumRecord("PiattiEsauriti", cn, cmd)
         Dim idPiattiEsauriti(numRecEsauriti - 1) As String

         cmd.Dispose()

         cn.Open()

         If numRecEsauriti > 0 Then
            Dim strSqlEsauriti As String = "SELECT * FROM PiattiEsauriti ORDER BY Id ASC"
            Dim cmdEsauriti As New OleDbCommand(strSqlEsauriti, cn)
            Dim drEsauriti As OleDbDataReader = cmdEsauriti.ExecuteReader()

            Dim i As Integer = 0
            Do While drEsauriti.Read
               idPiattiEsauriti(i) = drEsauriti.Item("IdPiatto")
               i += 1
            Loop

            cmdEsauriti.Dispose()
            drEsauriti.Close()
         End If

         Dim cmdPiatti As New OleDbCommand(strSqlPiatti, cn)
         Dim drPiatti As OleDbDataReader = cmdPiatti.ExecuteReader()

         sw.WriteLine("[VARIANTI]")

         Do While drPiatti.Read
            If numRecEsauriti > 0 Then
               valEsaurito = 1
               Dim i As Integer = 0
               For i = 0 To numRecEsauriti - 1
                  If drPiatti.Item("Id") = idPiattiEsauriti(i) Then
                     valEsaurito = 0
                  Else
                     valEsaurito = 1
                  End If
               Next
            Else
               valEsaurito = 1
            End If

            sw.WriteLine(drPiatti.Item("Id") & ";" & drPiatti.Item("Categoria") & ";" & drPiatti.Item("DescrizionePos") & ";" & valEsaurito)
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiTavoliSQLite()
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Tavoli WHERE Escludi = 'No' ORDER BY Descrizione ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CTavoli As New TavoliSQLite()

         CTavoli.CreaTabella("Tavoli")

         Do While dr.Read

            With CTavoli
               .CancellaCampi()

               .Codice = dr.Item("Id").ToString
               .Descrizione = SostituisciCaratteri(dr.Item("Descrizione").ToString)
               .Posti = dr.Item("Posti").ToString
               .Listino = dr.Item("Listino").ToString
               .Sala = SostituisciCaratteri(dr.Item("Sala").ToString)

               .InserisciDati("Tavoli")
            End With
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiCategoriePiattiSQLite()
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM CategoriePiatti ORDER BY Id ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CCategorie As New CategoriePiattiSQLite()

         CCategorie.CreaTabella("Categorie")

         Do While dr.Read

            With CCategorie
               .CancellaCampi()

               .Codice = dr.Item("Id").ToString
               .Descrizione = SostituisciCaratteri(dr.Item("Descrizione").ToString)
               .Colore = dr.Item("ColoreSfondo").ToString

               .InserisciDati("Categorie")
            End With
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiPiattiSQLite()
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Piatti WHERE Variazione = 'No' ORDER BY DescrizionePos ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CPiatti As New PiattiSQLite()

         CPiatti.CreaTabella("Piatti")

         Do While dr.Read

            With CPiatti
               .CancellaCampi()

               .Codice = dr.Item("Id").ToString
               .Descrizione = SostituisciCaratteri(dr.Item("DescrizionePos").ToString)
               .Categoria = SostituisciCaratteri(dr.Item("Categoria").ToString)
               .Listino1 = dr.Item("Listino1").ToString
               .Listino2 = dr.Item("Listino2").ToString
               .Listino3 = dr.Item("Listino3").ToString
               .Listino4 = dr.Item("Listino4").ToString

               .InserisciDati("Piatti")
            End With
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiVariantiSQLite()
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Piatti WHERE Variazione = 'Sì' ORDER BY Id ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CVarianti As New VariantiSQLite()

         CVarianti.CreaTabella("Varianti")

         Do While dr.Read

            With CVarianti
               .CancellaCampi()

               .Codice = dr.Item("Id").ToString
               .Descrizione = SostituisciCaratteri(dr.Item("DescrizionePos").ToString)
               .Categoria = SostituisciCaratteri(dr.Item("Categoria").ToString)
               .Listino1 = dr.Item("Listino1").ToString
               .Listino2 = dr.Item("Listino2").ToString
               .Listino3 = dr.Item("Listino3").ToString
               .Listino4 = dr.Item("Listino4").ToString

               .InserisciDati("Varianti")
            End With
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiCamerieriSQLite()
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Camerieri ORDER BY Id ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CCamerieri As New CamerieriSQLite()

         CCamerieri.CreaTabella("Camerieri")

         Do While dr.Read

            With CCamerieri
               .CancellaCampi()

               .Codice = dr.Item("Id").ToString
               .Nome = SostituisciCaratteri(dr.Item("Nome").ToString)

               .InserisciDati("Camerieri")
            End With
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiMessaggiSQLite()
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM MessaggiReparti ORDER BY Id ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CMessaggi As New MessaggiSQLite

         CMessaggi.CreaTabella("Messaggi")

         Do While dr.Read

            With CMessaggi
               .CancellaCampi()

               .Codice = dr.Item("Id").ToString
               .Descrizione = SostituisciCaratteri(dr.Item("Descrizione").ToString)

               .InserisciDati("Messaggi")
            End With
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiImpostazioneSQLite()
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim CImpostazioni As New ImpostazioniSQLite

         CImpostazioni.CreaTabella("Impostazioni")

         With CImpostazioni
            .CancellaCampi()

            .Percorso = PercorsoRP
            .Frequenza = FreqAggPalmare

            .InserisciDati("Impostazioni")
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiStatoTavoliSQLite()
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Tavoli WHERE Escludi = 'No' ORDER BY Descrizione ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CTavoli As New StatoTavoliSQLite()

         CTavoli.CreaTabella("Tavoli")

         Do While dr.Read
            With CTavoli
               .CancellaCampi()

               .Codice = dr.Item("Id").ToString
               .Descrizione = SostituisciCaratteri(dr.Item("Descrizione").ToString)
               .Coperti = dr.Item("Posti").ToString
               .Colore = dr.Item("Colore").ToString
               .Sala = SostituisciCaratteri(dr.Item("Sala").ToString)

               .InserisciDati("Tavoli")
            End With
         Loop

         cmd.Dispose()
         dr.Close()

         CTavoli.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiStatoPiattiSQLite()
      Dim cn As New OleDbConnection(ConnString)
      Dim strSqlPiatti As String = "SELECT * FROM Piatti WHERE Variazione = 'No' ORDER BY DescrizionePos ASC"
      Dim valEsaurito As String

      Try
         Dim strSql As String
         Dim cmd As New OleDbCommand(strSql, cn)
         Dim numRecEsauriti As Integer = LeggiNumRecord("PiattiEsauriti", cn, cmd)
         Dim idPiattiEsauriti(numRecEsauriti - 1) As String

         cmd.Dispose()

         cn.Open()

         If numRecEsauriti > 0 Then
            Dim strSqlEsauriti As String = "SELECT * FROM PiattiEsauriti ORDER BY Id ASC"
            Dim cmdEsauriti As New OleDbCommand(strSqlEsauriti, cn)
            Dim drEsauriti As OleDbDataReader = cmdEsauriti.ExecuteReader()

            Dim i As Integer = 0
            Do While drEsauriti.Read
               idPiattiEsauriti(i) = drEsauriti.Item("IdPiatto")
               i += 1
            Loop

            cmdEsauriti.Dispose()
            drEsauriti.Close()
         End If

         Dim cmdPiatti As New OleDbCommand(strSqlPiatti, cn)
         Dim drPiatti As OleDbDataReader = cmdPiatti.ExecuteReader()

         Dim CPiatti As New StatoPiattiSQLite

         CPiatti.CreaTabella("Piatti")

         Do While drPiatti.Read
            If numRecEsauriti > 0 Then
               valEsaurito = 1
               Dim i As Integer = 0
               For i = 0 To numRecEsauriti - 1
                  If drPiatti.Item("Id") = idPiattiEsauriti(i) Then
                     valEsaurito = 0
                     Exit For
                  End If
               Next
            Else
               valEsaurito = 1
            End If

            With CPiatti
               .CancellaCampi()

               .Codice = drPiatti.Item("Id").ToString
               .Descrizione = SostituisciCaratteri(drPiatti.Item("DescrizionePos").ToString)
               .Categoria = SostituisciCaratteri(drPiatti.Item("Categoria").ToString)
               .Esaurito = valEsaurito

               .InserisciDati("Piatti")
            End With
         Loop

         cmdPiatti.Dispose()
         drPiatti.Close()

         CPiatti.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiStatoVariantiSQLite()
      Dim cn As New OleDbConnection(ConnString)
      Dim strSqlPiatti As String = "SELECT * FROM Piatti WHERE Variazione = 'Sì' ORDER BY DescrizionePos ASC"
      Dim valEsaurito As String

      Try
         Dim strSql As String
         Dim cmd As New OleDbCommand(strSql, cn)
         Dim numRecEsauriti As Integer = LeggiNumRecord("PiattiEsauriti", cn, cmd)
         Dim idPiattiEsauriti(numRecEsauriti - 1) As String

         cmd.Dispose()

         cn.Open()

         If numRecEsauriti > 0 Then
            Dim strSqlEsauriti As String = "SELECT * FROM PiattiEsauriti ORDER BY Id ASC"
            Dim cmdEsauriti As New OleDbCommand(strSqlEsauriti, cn)
            Dim drEsauriti As OleDbDataReader = cmdEsauriti.ExecuteReader()

            Dim i As Integer = 0
            Do While drEsauriti.Read
               idPiattiEsauriti(i) = drEsauriti.Item("IdPiatto")
               i += 1
            Loop

            cmdEsauriti.Dispose()
            drEsauriti.Close()
         End If

         Dim cmdPiatti As New OleDbCommand(strSqlPiatti, cn)
         Dim drPiatti As OleDbDataReader = cmdPiatti.ExecuteReader()

         Dim CVarianti As New StatoVariantiSQLite

         CVarianti.CreaTabella("Varianti")

         Do While drPiatti.Read
            If numRecEsauriti > 0 Then
               valEsaurito = 1
               Dim i As Integer = 0
               For i = 0 To numRecEsauriti - 1
                  If drPiatti.Item("Id") = idPiattiEsauriti(i) Then
                     valEsaurito = 0
                     Exit For
                  End If
               Next
            Else
               valEsaurito = 1
            End If

            With CVarianti
               .CancellaCampi()

               .Codice = drPiatti.Item("Id").ToString
               .Descrizione = SostituisciCaratteri(drPiatti.Item("DescrizionePos").ToString)
               .Categoria = SostituisciCaratteri(drPiatti.Item("Categoria").ToString)
               .Esaurito = valEsaurito

               .InserisciDati("Varianti")
            End With
         Loop

         cmdPiatti.Dispose()
         drPiatti.Close()

         CVarianti.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiStatoComandeSQLite()
      Dim cn As New OleDbConnection(ConnString)
      Dim strSql As String = "SELECT * FROM Comande ORDER BY Id ASC"

      Try
         cn.Open()

         Dim cmd As New OleDbCommand(strSql, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Dim CComande As New StatoComandeSQLite()

         CComande.CreaTabella("Comande")

         Do While dr.Read

            With CComande
               .CancellaCampi()

               .IdTavolo = dr.Item("IdRisorsa").ToString
               .IdPiatto = dr.Item("IdPiatto").ToString
               .Quantità = dr.Item("Quantità").ToString
               .Piatto = SostituisciCaratteri(dr.Item("Descrizione").ToString)
               .Importo = dr.Item("ImportoNetto").ToString
               .Variante = String.Empty
               If dr.Item("Inviata").ToString = "Sì" Then
                  .Inviata = "Si"
               Else
                  .Inviata = dr.Item("Inviata").ToString
               End If

               .InserisciDati("Comande")
            End With
         Loop

         cmd.Dispose()
         dr.Close()

         CComande.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiCmdTavoliSQLite()
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim CTavoli As New CmdTavoliSQLite

         CTavoli.CreaTabella("Tavoli")

         With CTavoli
            .CancellaCampi()

            .CodiceDispositivo = String.Empty
            .IdTavolo = String.Empty
            .Descrizione = String.Empty
            .Coperti = String.Empty
            .Colore = String.Empty
            .Comando = String.Empty

            .InserisciDati("Tavoli")
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub ScriviDatiCmdComandeSQLite()
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim CComande As New CmdComandeSQLite

         CComande.CreaTabella("Comande")

         With CComande
            .CancellaCampi()

            .IdTavolo = String.Empty
            .IdPiatto = String.Empty
            .Quantità = String.Empty
            .Piatto = String.Empty
            .Importo = String.Empty
            .Variante = String.Empty
            .ConVar = False

            .InserisciDati("Comande")
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub CreaFileAnagrafiche(ByVal abilitaWindows As Boolean, ByVal abilitaAndroid As Boolean)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         If PercorsoRP = String.Empty Then
            Exit Sub
         End If

         ' SQLite per Android.
         If abilitaAndroid = True Then

            If File.Exists(Application.StartupPath & NOME_PERCORSO_FILE_ANAG_ANDROID) = True Then
               File.Delete(Application.StartupPath & NOME_PERCORSO_FILE_ANAG_ANDROID)
            End If

            ScriviDatiTavoliSQLite()
            ScriviDatiCategoriePiattiSQLite()
            ScriviDatiPiattiSQLite()
            ScriviDatiVariantiSQLite()
            ScriviDatiCamerieriSQLite()
            ScriviDatiMessaggiSQLite()
            ScriviDatiImpostazioneSQLite()

            ' Se esiste crea una copia nel percorso di rete della cartella condivisa.
            If File.Exists(Application.StartupPath & NOME_PERCORSO_FILE_ANAG_ANDROID) = True Then
               ' Verifica se nel percorso di rete il file esiste già e lo elimina.
               If File.Exists(PercorsoRP & NOME_FILE_ANAG_ANDROID) = True Then
                  File.Delete(PercorsoRP & NOME_FILE_ANAG_ANDROID)
               End If

               ' Crea la copia del file.
               File.Copy(Application.StartupPath & NOME_PERCORSO_FILE_ANAG_ANDROID, PercorsoRP & NOME_FILE_ANAG_ANDROID)
            End If

         End If

         ' File di testo per Windows Mobile/CE
         If abilitaWindows = True Then

            Dim sw As StreamWriter

            If File.Exists(PercorsoRP & NOME_FILE_ANAG) = True Then
               sw = File.AppendText(PercorsoRP & NOME_FILE_TEMP)
            Else
               sw = File.CreateText(PercorsoRP & NOME_FILE_ANAG)
            End If

            ScriviDatiTavoli(sw)
            ScriviDatiCategorie(sw)
            ScriviDatiPiatti(sw)
            ScriviDatiVarianti(sw)
            ScriviDatiCamerieri(sw)
            ScriviDatiMessaggi(sw)
            ScriviDatiImpostazione(sw)

            sw.Close()

            If File.Exists(PercorsoRP & NOME_FILE_TEMP) = True Then
               ' Se esiste cancella il vecchio file... 
               File.Delete(PercorsoRP & NOME_FILE_ANAG)
               File.Move(PercorsoRP & NOME_FILE_TEMP, PercorsoRP & NOME_FILE_ANAG)
            End If

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Public Sub CreaFileStatoTavoli(ByVal abilitaWindows As Boolean, ByVal abilitaAndroid As Boolean)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         If PercorsoRP = String.Empty Then
            Exit Sub
         End If

         ' SQLite per Android.
         If abilitaAndroid = True Then

            If File.Exists(Application.StartupPath & NOME_PERCORSO_FILE_TAVOLI_ANDROID) = True Then
               File.Delete(Application.StartupPath & NOME_PERCORSO_FILE_TAVOLI_ANDROID)
            End If

            ScriviDatiStatoTavoliSQLite()
            ScriviDatiStatoComandeSQLite()

            ' ATTENZIONE! Scvivendo troppi dati si verifica un blocco di diversi secondi...
            ' ScriviDatiStatoPiattiSQLite()
            ' ScriviDatiStatoVariantiSQLite()

            ' Se esiste crea una copia nel percorso di rete della cartella condivisa.
            If File.Exists(Application.StartupPath & NOME_PERCORSO_FILE_TAVOLI_ANDROID) = True Then
               ' Verifica se nel percorso di rete il file esiste già e lo elimina.
               If File.Exists(PercorsoRP & NOME_FILE_TAVOLI_ANDROID) = True Then
                  File.Delete(PercorsoRP & NOME_FILE_TAVOLI_ANDROID)
               End If

               ' Crea la copia del file.
               File.Copy(Application.StartupPath & NOME_PERCORSO_FILE_TAVOLI_ANDROID, PercorsoRP & NOME_FILE_TAVOLI_ANDROID)
            End If
         End If

         ' File di testo per Windows Mobile/CE
         If abilitaWindows = True Then

            Dim sw As StreamWriter
            If File.Exists(PercorsoRP & NOME_FILE_TAVOLI) = True Then
               sw = File.AppendText(PercorsoRP & NOME_FILE_TEMP)
            Else
               sw = File.CreateText(PercorsoRP & NOME_FILE_TAVOLI)
            End If

            ScriviDatiStatoTavoli(sw)
            ScriviDatiStatoPiatti(sw)
            ScriviDatiStatoVarianti(sw)

            sw.Close()

            If File.Exists(PercorsoRP & NOME_FILE_TEMP) = True Then
               ' Se esiste cancella il vecchio file... 
               File.Delete(PercorsoRP & NOME_FILE_TAVOLI)
               File.Move(PercorsoRP & NOME_FILE_TEMP, PercorsoRP & NOME_FILE_TAVOLI)
            End If

         End If

      Catch ex As IOException
         ' Errore: Il processo non può acedere al file perchè in uso da un altro processo.
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Public Sub CreaFileSQLiteComande(ByVal abilitaAndroid As Boolean)
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      Dim sw As StreamWriter

      Try
         If abilitaAndroid = False Then
            Exit Sub
         End If

         If PercorsoRP = String.Empty Then
            Exit Sub
         End If

         ' SQLite per Android.
         If File.Exists(Application.StartupPath & NOME_PERCORSO_FILE_COMANDI_ANDROID) = True Then
            File.Delete(Application.StartupPath & NOME_PERCORSO_FILE_COMANDI_ANDROID)
         End If

         ScriviDatiCmdComandeSQLite()
         ScriviDatiCmdTavoliSQLite()

         ' Se esiste crea una copia nel percorso di rete della cartella condivisa.
         If File.Exists(Application.StartupPath & NOME_PERCORSO_FILE_COMANDI_ANDROID) = True Then
            ' Verifica se nel percorso di rete il file esiste già e lo elimina.
            If File.Exists(PercorsoRP & NOME_FILE_COMANDI_ANDROID) = True Then
               File.Delete(PercorsoRP & NOME_FILE_COMANDI_ANDROID)
            End If

            ' Crea la copia del file.
            File.Copy(Application.StartupPath & NOME_PERCORSO_FILE_COMANDI_ANDROID, PercorsoRP & NOME_FILE_COMANDI_ANDROID)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Public Sub ApriAzienda()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmAzienda) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_AZIENDA

            g_frmAzienda = New frmAzienda
            g_frmAzienda.MdiParent = Me

            ' Visualizza l'anagrafica Hotel.
            g_frmAzienda.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmAzienda.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriReports(ByVal sql As String, ByVal tabella As String, ByVal percorso As String, Optional ByVal frmId As String = "")
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Visualizza un messaggio nella barra di stato.
         Me.eui_Informazioni.Text = CAR_REPORTS
         Dim frm As New frmReports(sql, tabella, percorso, frmId)
         frm.MdiParent = Me
         frm.Show()

         ' Visualizza un messaggio nella barra di stato.
         Me.eui_Informazioni.Text = LeggiDatiRivenditore()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriInfo()
      Dim frm As New frmAbout
      frm.ShowDialog()
   End Sub

   Public Sub ApriGuida()
      ' Apre il file della guida in linea.
      ApriFileGuida(Application.StartupPath & PERCORSO_GUIDA)
   End Sub

   Public Sub ApriOpzioni()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Visualizza un messaggio nella barra di stato.
         Me.eui_Informazioni.Text = CAR_OPZIONI

         ' Apre la finestra Opzioni di configurazione.
         Dim frm As New frmOpzioni
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriClienti()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmClienti) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_CLIENTI

            ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

            g_frmClienti = New frmElencoDati(Elenco.Clienti)
            g_frmClienti.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmClienti.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmClienti.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriAziende()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmAziende) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            'Dim frmCaricamento As New Caricamento
            'frmCaricamento.Show()
            'Application.DoEvents()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_AZIENDE

            ConnStringAnagrafiche = CreaConnString(PercorsoDBClienti)

            g_frmAziende = New frmElencoDati(Elenco.Aziende)
            g_frmAziende.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmAziende.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            'frmCaricamento.Close()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmAziende.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriFornitori()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmFornitori) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_FORNITORI

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmFornitori = New frmElencoDati(Elenco.Fornitori)
            g_frmFornitori.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmFornitori.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmFornitori.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriArticoli()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmArticoli) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_ARTICOLI

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmArticoli = New frmElencoDati(Elenco.Articoli)
            g_frmArticoli.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmArticoli.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmArticoli.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriCamerieri()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmCamerieri) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_CAMERIERI

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmCamerieri = New frmElencoDati(Elenco.Camerieri)
            g_frmCamerieri.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmCamerieri.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmCamerieri.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriSale()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmSale) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_SALE

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmSale = New frmElencoDati(Elenco.Sale)
            g_frmSale.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmSale.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmSale.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPiatti()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPiatti) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_PIATTI

            g_frmPiatti = New frmElencoPiatti
            g_frmPiatti.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmPiatti.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPiatti.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriCategoriePiatti()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmCatPiatti) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_CAT_PIATTI

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmCatPiatti = New frmElencoDati(Elenco.CatPiatti)
            g_frmCatPiatti.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmCatPiatti.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmCatPiatti.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriStatoPrenotazioni()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmStatoPren) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_TAB_STATO_PREN

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmStatoPren = New frmElencoDati(Elenco.StatoPren)
            g_frmStatoPren.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmStatoPren.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmStatoPren.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPos(ByVal idTavolo As Integer, ByVal tavolo As String, ByVal oraOcc As String, ByVal cameriere As String)
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPos) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_POS

            g_frmPos = New frmPos(idTavolo, tavolo, oraOcc, cameriere)

            g_frmPos.WindowState = FormWindowState.Maximized

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default

            ' Visualizza l'anagrafica clienti.
            g_frmPos.ShowDialog()

         Else
            ' Altrimenti lo attiva.
            g_frmPos.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriStatistiche()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmStatistiche) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_STAT

            g_frmStatistiche = New frmStatistiche
            g_frmStatistiche.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmStatistiche.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmStatistiche.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriStatisticheRisorse()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmStatisticheRisorse) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_STAT

            g_frmStatisticheRisorse = New frmStatisticheRisorse
            g_frmStatisticheRisorse.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmStatisticheRisorse.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmStatisticheRisorse.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPrimaNota()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPrimaNota) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_PRIMA_NOTA

            g_frmPrimaNota = New PrimaNota
            g_frmPrimaNota.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmPrimaNota.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPrimaNota.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriMenu()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmMenu) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = "Caricamento finestra in corso..."

            g_frmMenu = New Menu
            g_frmMenu.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmMenu.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmMenu.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriAcquisti()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmAcquisti) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ACQUISTI

            g_frmAcquisti = New frmElencoAcquisti
            g_frmAcquisti.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmAcquisti.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmAcquisti.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriEtichette()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmEtichette) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ETICHETTE

            g_frmEtichette = New ElencoEtichette
            g_frmEtichette.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmEtichette.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmEtichette.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriDoc()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmDocumenti) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_DOCUMENTI

            g_frmDocumenti = New ElencoDoc
            g_frmDocumenti.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmDocumenti.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmDocumenti.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriChiusuraGiornaliera()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Visualizza un messaggio nella barra di stato.
         Me.eui_Informazioni.Text = CAR_CHIUSURA

         Dim frm As New Chiusura

         ' Visualizza l'anagrafica clienti.
         frm.ShowDialog()

         ' Visualizza un messaggio nella barra di stato.
         Me.eui_Informazioni.Text = LeggiDatiRivenditore()

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriCorrispettivi()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmCorrispettivi) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_CORRISPETTIVI

            g_frmCorrispettivi = New ElencoCorrispettivi
            g_frmCorrispettivi.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmCorrispettivi.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmCorrispettivi.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriTavoli()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmTavoli) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_TAVOLI

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmTavoli = New frmElencoDati(Elenco.Tavoli)
            g_frmTavoli.MdiParent = Me

            ' Visualizza l'elenco Tavoli.
            g_frmTavoli.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmTavoli.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriCamere()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmCamere) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_CAMERE

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmCamere = New frmElencoDati(Elenco.Camere)
            g_frmCamere.MdiParent = Me

            ' Visualizza l'elenco Tavoli.
            g_frmCamere.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmCamere.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriListiniCamere()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmListiniCamere) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_TAB_LISTINI_CAMERE

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmListiniCamere = New ElencoListiniCamere
            g_frmListiniCamere.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmListiniCamere.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmListiniCamere.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriStagioni()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmStagioni) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_TAB_STAGIONI

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmStagioni = New frmStagioni
            'g_frmStagioni.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmStagioni.ShowDialog()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmStagioni.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriVCTavoli()
      Try
         If LeggiNumTavoli() = 0 Then
            MessageBox.Show("Non ci sono Tavoli! Visual POS - Gestione Tavoli non può essere aperto.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
         End If

         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmVCTavoli) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_VC_TAVOLI

            g_frmVCTavoli = New frmVCTavoli

            g_frmVCTavoli.WindowState = FormWindowState.Maximized

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default

            ' Visualizza la gestione in modalità grafica dei Tavoli.
            g_frmVCTavoli.Show()
         Else
            ' Altrimenti lo attiva.
            g_frmVCTavoli.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriSchedinePS()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmSchedinePS) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_SCHEDINE_PS

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmSchedinePS = New ElencoSchedinePS()
            g_frmSchedinePS.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmSchedinePS.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmSchedinePS.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPrenCamere()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPrenCamere) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_PREN_CAMERE

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmPrenCamere = New ElencoPrenCamere()
            g_frmPrenCamere.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmPrenCamere.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPrenCamere.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPrenTavoli()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPren) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_PREN

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmPren = New frmElencoDati(Elenco.Prenotazioni)
            g_frmPren.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmPren.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPren.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPrenSale()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPrenSale) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_PREN_SALE

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmPrenSale = New frmElencoDati(Elenco.PrenSale)
            g_frmPrenSale.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmPrenSale.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPrenSale.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPrenRisorse()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPrenRisorse) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_PREN_RISORSE

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmPrenRisorse = New frmElencoDatiSport(Elenco.Prenotazioni)
            g_frmPrenRisorse.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmPrenRisorse.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPrenRisorse.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPlanningSport1()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPlanningSport1) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_PLANNING_P

            g_frmPlanningSport1 = New frmPlanningP(TipoPlanning.Planning1)
            g_frmPlanningSport1.MdiParent = Me

            ' Visualizza l'anagrafica Hotel.
            g_frmPlanningSport1.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPlanningSport1.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPlanningSport2()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPlanningSport2) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_PLANNING_P

            g_frmPlanningSport2 = New frmPlanningP(TipoPlanning.Planning2)
            g_frmPlanningSport2.MdiParent = Me

            ' Visualizza l'anagrafica Hotel.
            g_frmPlanningSport2.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPlanningSport2.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPlanningSport3()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPlanningSport3) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_PLANNING_P

            g_frmPlanningSport3 = New frmPlanningP(TipoPlanning.Planning3)
            g_frmPlanningSport3.MdiParent = Me

            ' Visualizza l'anagrafica Hotel.
            g_frmPlanningSport3.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPlanningSport3.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPlanningSport4()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPlanningSport4) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_PLANNING_P

            g_frmPlanningSport4 = New frmPlanningP(TipoPlanning.Planning4)
            g_frmPlanningSport4.MdiParent = Me

            ' Visualizza l'anagrafica Hotel.
            g_frmPlanningSport4.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPlanningSport4.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPlanningCamere()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmPlanningCamere) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_PLANNING_CAMERE

            g_frmPlanningCamere = New PlanningCamere
            g_frmPlanningCamere.MdiParent = Me

            ' Visualizza l'anagrafica Hotel.
            g_frmPlanningCamere.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmPlanningCamere.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriScorte()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmScorte) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_SITUAZIONE_SCORTE

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmScorte = New ElencoScorte
            g_frmScorte.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmScorte.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmScorte.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriInventario()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmInventario) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_INVENTARIO

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmInventario = New ElencoInventario
            g_frmInventario.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmInventario.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmInventario.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriMovMag()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmMovMag) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_MOV_MAG

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmMovMag = New ElencoMovMag
            g_frmMovMag.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmMovMag.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmMovMag.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriCAP()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmCap) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_CAP

            ConnStringCAP = CreaConnString(Application.StartupPath & PERCORSO_DB_CAP)

            g_frmCap = New ElencoCAP
            g_frmCap.MdiParent = Me

            ' Visualizza l'elenco CAP.
            g_frmCap.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmCap.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriEmail()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmEmail) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_EMAIL

            g_frmEmail = New ElencoEmail
            g_frmEmail.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmEmail.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmEmail.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriMessaggi()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmMessaggi) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_MESSAGGI

            g_frmMessaggi = New ElencoMessaggi
            g_frmMessaggi.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmMessaggi.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmMessaggi.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriRisorse()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmRisorse) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_RISORSE

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmRisorse = New frmElencoDatiSport(Elenco.Risorse)
            g_frmRisorse.MdiParent = Me

            ' Visualizza l'anagrafica Hotel.
            g_frmRisorse.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmRisorse.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriTipologieUtilizzoRisorse()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmCaratteristicheRisorse) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_TIPOLOGIE_UTILIZZO_RISORSE

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmCaratteristicheRisorse = New frmElencoDati(Elenco.CaratteristicheRisorse)
            g_frmCaratteristicheRisorse.MdiParent = Me

            ' Visualizza l'anagrafica Hotel.
            g_frmCaratteristicheRisorse.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmCaratteristicheRisorse.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriAccessoriServizi()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmAccessoriServizi) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_ACCESSORI_SERVIZI

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmAccessoriServizi = New frmElencoDatiSport(Elenco.AccessoriServizi)
            g_frmAccessoriServizi.MdiParent = Me

            ' Visualizza l'anagrafica Hotel.
            g_frmAccessoriServizi.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmAccessoriServizi.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriPlanningP()
      Try
         '   ' Se il form non è aperto lo apre.
         '   If IsNothing(g_frmPP) = True Then
         '      ' Modifica il cursore del mouse.
         '      Cursor.Current = Cursors.AppStarting

         '      ' Visualizza un messaggio nella barra di stato.
         '      Me.eui_Informazioni.Text = CAR_PLANNING_P

         '      g_frmPP = New frmPlanningP
         '      g_frmPP.MdiParent = Me

         '      ' Visualizza l'anagrafica Hotel.
         '      g_frmPP.Show()

         '      ' Visualizza un messaggio nella barra di stato.
         '      Me.eui_Informazioni.Text = LeggiDatiRivenditore()

         '      ' Modifica il cursore del mouse.
         '      Cursor.Current = Cursors.Default
         '   Else
         '      ' Altrimenti lo attiva.
         '      g_frmPP.Activate()
         '   End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriOperazioni()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmOperazioni) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_OPERAZIONI

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmOperazioni = New RegOperazioni
            g_frmOperazioni.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmOperazioni.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmOperazioni.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriOperatori()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmOperatori) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_OPERATORI

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmOperatori = New frmElencoDati(Elenco.Operatori)
            g_frmOperatori.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmOperatori.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmOperatori.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriGruppi()
      Try
         ' Se il form non è aperto lo apre.
         If IsNothing(g_frmGruppi) = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = CAR_ANAG_GRUPPI

            ConnStringAnagrafiche = CreaConnString(PercorsoDB)

            g_frmGruppi = New frmElencoDati(Elenco.Gruppi)
            g_frmGruppi.MdiParent = Me

            ' Visualizza l'anagrafica clienti.
            g_frmGruppi.Show()

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default
         Else
            ' Altrimenti lo attiva.
            g_frmGruppi.Activate()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Public Sub ApriTabelle(ByVal tabella As String)
      Try
         Dim frm As New TabelleDati

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting
         Select Case tabella
            Case "CategorieClienti"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Categorie Clienti in corso..."

            Case "CategoriePiatti"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Categorie Piatti in corso..."

            Case "Attività"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Attività in corso..."

            Case "CausaliDocumento"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Causali documento in corso..."

            Case "ModPagamento"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Modalità di pagamento in corso..."

            Case "Qualifiche"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Forme di cortesia in corso..."

            Case "CategorieMerce"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Categorie merceologiche in corso..."

            Case "UnitàMisura"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Unità di misura in corso..."

            Case "MessaggiReparti"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Messaggi per i reparti in corso..."

            Case "TipologieCamere"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Tipologie camere in corso..."

            Case "UbicazioniCamere"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Ubicazioni camere in corso..."

            Case "PosizioniCamere"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Posizioni camere in corso..."

            Case "DocIdentità"
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella Documenti d'identità in corso..."

            Case Else
               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = "Attendere prego. Caricamento della Tabella " & tabella & " in corso..."

         End Select

         frm.MdiParent = Me
         frm.Tag = tabella
         frm.Show()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

#End Region

#Region "Funzioni"

   Private Function SalvaArchivio() As String
      Try
         SaveFileDialog1.InitialDirectory = Application.StartupPath & PERCORSO_BKP

         SaveFileDialog1.Filter = "Microsoft Database Access (.mdb)|*.mdb"

         SaveFileDialog1.FilterIndex = 1

         SaveFileDialog1.FileName = Application.StartupPath & "\Backup\" & "Chef_" & FormattaDataBackup() & ".mdb"

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

   Public Function LeggiNumTavoli() As Integer
      Dim cn As New OleDbConnection(ConnString)
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
         cmd.CommandText = "SELECT COUNT(*) FROM Tavoli"
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

   Public Function LeggiDatiRivenditore() As String
      Try
         Dim datiRivenditore As String = String.Empty
         Dim ragSociale As String = String.Empty
         Dim nome As String = String.Empty
         Dim telefono As String = String.Empty
         Dim email As String = String.Empty

         Application.DoEvents()

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig


         If DatiConfig.GetValue("RagioneSocialeRiv") <> String.Empty Then
            ragSociale = DatiConfig.GetValue("RagioneSocialeRiv")
            datiRivenditore = ragSociale
         End If

         If DatiConfig.GetValue("NomeRiv") <> String.Empty Then
            nome = DatiConfig.GetValue("NomeRiv")

            If datiRivenditore <> String.Empty Then
               datiRivenditore = datiRivenditore & " - " & nome
            Else
               datiRivenditore = nome
            End If
         End If

         If datiRivenditore <> String.Empty Then

            If DatiConfig.GetValue("TelefonoRiv") <> String.Empty Then
               telefono = DatiConfig.GetValue("TelefonoRiv")
               datiRivenditore = datiRivenditore & " - Tel. " & telefono
            End If

            If DatiConfig.GetValue("EmailRiv") <> String.Empty Then
               email = DatiConfig.GetValue("EmailRiv")
               datiRivenditore = datiRivenditore & " - Email: " & email
            End If
         End If

         Return datiRivenditore

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

#End Region

#Region "Eventi"

   Private Sub frmMain_Load(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.Load
      Try
         ' Imposta il titolo della finestra in base al prodotto installato.
         Me.Text = NOME_PRODOTTO
         ' Visualizza un messaggio nella barra di stato.
         Me.eui_Informazioni.Text = LeggiDatiRivenditore()

         ' Imposta l'icona della finestra in base al prodotto installato.
         ImpostaIcona(Me)

         ' Imposta il titolo e l'icona della finestra in base al prodotto installato.
         ' Per la versione demo.
         If g_VerDemo = True Then
            Me.Text = Me.Text & " - " & VER_DEMO

            ' Visualizza o nasconde l'etichetta Versione dimostrativa.
            If eui_lstProdottiAttivati.Items.Count = 0 Then
               lblDemo.Visible = True
               lblGiorniProva.Visible = True
               lblGiorniProva.Text = "GIORNI DI PROVA: " & giorniVerDemo
            Else
               lblDemo.Visible = False
               lblGiorniProva.Visible = False
            End If
         Else
            ' Visualizza le varie funzionalità in base ai moduli installati.
            ImpostaModuli()
         End If

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig
         LeggiDatiConfig()

         ' Effettua le impostazioni necessarie per l'archivio.
         ImpostaArchivio(eui_cmdArchivio)
         ImpostaProprietàArchivio()

         ' Effettua le impostazioni per la versione e il numero di serie.
         ImpostaInfoSu()

         ' Visualizza il nome dell'azienda nella barra di stato.
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)
         AAzienda.LeggiDati(NOME_TABELLA_AZIENDA)
         eui_cmdAzienda.Text = AAzienda.RagSociale

         ' Carica le impostazioni dei moduli nella lista.
         CaricaListaModuli()

         ' Senza questa variabile viene richiamato l'evento ItemChecked per la lista dei moduli.
         impostaListaModuli = True

         ' Imposta la pagina iniziale.
         eui_File.CurrentTabPage = eui_Gestione

         ' Se il modulo Prenotazioni On-line è attivo, attiva/disattiva la ricezione delle prenotazioni da internet. (www.tavoloso.it)
         If moduloAttivo.PrenOnLine = True Then
            Timer2.Enabled = AbilitaRicezionePren
         End If

         Me.Focus()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmMain_Closed(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles MyBase.FormClosed
      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      Dim frm As New frmElaborazione
      frm.ShowDialog()

      Application.Exit()

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default

      ' Se viene premuto il tasto Annulla prima di effettuare il Login - Operatore non identificato.
      If operatore.Nome = String.Empty Then
         operatore.Nome = VAL_NESSUNO
      End If

      ' Registra loperazione effettuata dall'operatore identificato.
      RegistraOperazione(TipoOperazione.Chiudi, STR_HOSPITALITY, MODULO_HOSPITALITY_SOLUTION)
   End Sub

   Private Sub frmMain_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
      Try
         Dim risposta As MsgBoxResult = MsgBox("Sicuro di voler uscire?.", MsgBoxStyle.YesNo + MsgBoxStyle.Question, NOME_PRODOTTO)

         If risposta = MsgBoxResult.No Then
            ' Non esce dal programma.
            e.Cancel = True
         Else
            ' Solo per la versione demo prima di uscire chiede un giudizio.
            If g_VerDemo = True Then
               If LeggiGiudizioInviatoConfig() = String.Empty Then
                  Dim frm As New frmGiudizioDemo
                  frm.ShowDialog()
               End If
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_Opzioni_Click(sender As System.Object, e As System.EventArgs) Handles eui_Opzioni.Click
      Try
         ' Apre la finestra Opzioni di configurazione.
         Dim frm As New frmOpzioni
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Esci_Click(sender As System.Object, e As System.EventArgs) Handles eui_Esci.Click
      ' Scarica il form
      Me.Close()
   End Sub

   Private Sub Timer1_Tick(ByVal eventSender As System.Object, ByVal eventArgs As System.EventArgs) Handles Timer1.Tick
      Try
         ' Visualizza la data estesa sulla barra di stato.
         eui_cmdData.Text = Now.Date.ToShortDateString
         eui_cmdData.ScreenTip.Text = Now.Date.ToLongDateString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Protected Overrides Sub Finalize()
      MyBase.Finalize()
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

      End Try
   End Function

   Private Sub finestreMDI_Showing(ByVal sender As Object, ByVal e As EventArgs)
      Try
         For Each button As ToggleButton In FinestreMDI.Items
            If button.Tag Is ActiveMdiChild Then
               button.Pressed = True
               Exit For
            End If
         Next button

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub FormMenuSeleziona_PressedChanged(ByVal sender As Object, e As System.EventArgs)
      Try
         Dim tb As ToggleButton = TryCast(sender, ToggleButton)
         If tb Is Nothing Then
            Return
         End If

         If tb.Pressed Then
            For Each frm As Form In MdiChildren
               If EstraiNomeFinestra(frm.Text) = tb.Text Then
                  frm.Focus()
               End If
            Next
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function EstraiNomeFinestra(ByVal nomeFinestra As String) As String
      Try
         Dim carattere As Char
         Dim i As Integer
         For i = 0 To nomeFinestra.Length - 1
            carattere = nomeFinestra.Substring(i, 1)
            If carattere = "(" Then
               Return nomeFinestra.Substring(0, i - 1)
               Exit For
            End If
         Next

         Return nomeFinestra

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return nomeFinestra
      End Try

   End Function

   Private Sub AggiungiFormMenuSeleziona()
      Try
         Dim tb As ToggleButton = New ToggleButton()
         Dim titoloFinestra As String = EstraiNomeFinestra(ActiveMdiChild.Text)

         tb.Text = titoloFinestra
         tb.Tag = ActiveMdiChild
         tb.KeyTip = FinestreMDI.Items.Count + 1
         tb.ScreenTip.Caption = "Seleziona Finestra"
         tb.ScreenTip.Text = "Seleziona la finestra " & titoloFinestra
         tb.RadioGroupName = "MDISwitcher"

         AddHandler tb.PressedChanged, AddressOf FormMenuSeleziona_PressedChanged

         FinestreMDI.Items.Add(tb)

         If FinestreMDI.Items.Count <> 0 Then
            ' Attiva tutti i comandi.
            eui_cmdFinestraSovrapponi.Enabled = True
            eui_cmdFinestraAffianca.Enabled = True
            eui_cmdFinestraDisponi.Enabled = True
            eui_cmdFinestraChiudi.Enabled = True
            eui_cmdFinestraChiudiTutto.Enabled = True
            eui_drpFinestraSel.Enabled = True
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub RimuoviFormMenuSeleziona(ByVal frm As Form)
      Try
         Dim titoloFinestra As String = EstraiNomeFinestra(frm.Text)

         For Each button As ToggleButton In FinestreMDI.Items
            If button.Text = titoloFinestra Then
               FinestreMDI.Items.Remove(button)

               If FinestreMDI.Items.Count = 0 Then
                  ' Disattiva tutti i comandi.
                  eui_cmdFinestraSovrapponi.Enabled = False
                  eui_cmdFinestraAffianca.Enabled = False
                  eui_cmdFinestraDisponi.Enabled = False
                  eui_cmdFinestraChiudi.Enabled = False
                  eui_cmdFinestraChiudiTutto.Enabled = False
                  eui_drpFinestraSel.Enabled = False
               End If

               Exit For
            End If

         Next button

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region "Ribbon Menu Gestione"

#Region "Pos"

   Private Sub eui_cmdGestionePosCassa_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestionePosCassa.Click
      ' Apre il punto cassa.
      ApriPos(0, String.Empty, String.Empty, String.Empty)
   End Sub

   Private Sub eui_cmdGestionePosTavoli_Click(sender As Object, e As System.EventArgs) Handles eui_cmdGestionePosTavoli.Click
      ' Apre Visual Chef per la gestione dei tavoli e del conto.
      ApriVCTavoli()
   End Sub

#End Region

#Region "Prenotazioni"

   Private Sub eui_cmdGestionePrenCamere_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestionePrenCamere.Click
      ' Apre l'elenco prenotazioni Camere.
      ApriPrenCamere()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()

   End Sub

   Private Sub eui_cmdGestionePrenTavoli_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestionePrenTavoli.Click
      ' Apre l'elenco prenotazioni tavoli.
      ApriPrenTavoli()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestionePrenSale_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestionePrenSale.Click
      ' Apre l'elenco prenotazioni sale.
      ApriPrenSale()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestionePrenRisorse_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestionePrenRisorse.Click
      ' Apre l'elenco prenotazioni sale.
      ApriPrenRisorse()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestionePlanningRisorseApriTutti_Click(sender As Object, e As EventArgs) Handles eui_cmdGestionePlanningRisorseApriTutti.Click
      Try
         ' Apre tutti i Planning insieme e li affianca verticalmente.
         eui_cmdGestionePlanningRisorseSport4.PerformClick()

         eui_cmdGestionePlanningRisorseSport3.PerformClick()

         eui_cmdGestionePlanningRisorseSport2.PerformClick()

         eui_cmdFinestraAffiancaVert.PerformClick()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdGestionePlanningRisorseSport1_Click(sender As Object, e As EventArgs) Handles eui_cmdGestionePlanningRisorseSport1.Click
      ' Apre il Planning per le prenotazioni delle risorse.
      ApriPlanningSport1()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestionePlanningRisorseSport2_Click(sender As Object, e As EventArgs) Handles eui_cmdGestionePlanningRisorseSport2.Click
      ' Apre il Planning per le prenotazioni delle risorse.
      ApriPlanningSport2()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestionePlanningRisorseSport3_Click(sender As Object, e As EventArgs) Handles eui_cmdGestionePlanningRisorseSport3.Click
      ' Apre il Planning per le prenotazioni delle risorse.
      ApriPlanningSport3()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestionePlanningRisorseSport4_Click(sender As Object, e As EventArgs) Handles eui_cmdGestionePlanningRisorseSport4.Click
      ' Apre il Planning per le prenotazioni delle risorse.
      ApriPlanningSport4()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestionePlanningCamere_Click_1(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestionePlanningCamere.Click
      ' Apre il Planning per le prenotazioni delle camere.
      ApriPlanningCamere()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub
#End Region

#Region "Gestione "

   Private Sub eui_cmdGestioneClienti_Click(sender As Object, e As EventArgs) Handles eui_cmdGestioneClienti.Click
      ' Apre l'anagrafica Clienti.
      eui_cmdArchiviAnagraficheClienti.PerformClick()
   End Sub

   Private Sub eui_cmdGestioneSchedine_Click(sender As Object, e As EventArgs) Handles eui_cmdGestioneSchedine.Click
      ' Apre l'elenco prenotazioni Camere.
      ApriSchedinePS()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestioneStatistiche_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestioneStatistiche.Click
      ' Apre la finestra statistiche di vendita per il Bar / Ristorante.
      ApriStatistiche()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestioneStatisticheRisorse_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestioneStatisticheRisorse.Click
      ' Apre la finestra statistiche di vendita per il Centro sportivo.
      ApriStatisticheRisorse()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

#End Region

#Region "Operatori "

   Private Sub eui_cmdGestioneOperatori_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestioneOperatori.Click
      ' Apre l'elenco degli operatori.
      ApriOperatori()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestioneGruppiOp_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestioneGruppiOp.Click
      ' Apre l'elenco dei gruppi.
      ApriGruppi()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdGestioneCambiaOp_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGestioneCambiaOp.Click
      Try
         Dim risposta As MsgBoxResult
         risposta = MessageBox.Show("Si desidera disconnettersi dal software e cambiare operatore? Tutte le finestre aperte verranno chiuse.",
                                    NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

         If risposta = MsgBoxResult.Yes Then
            ' Se ci sono finestre aperte le chiude.
            eui_cmdFinestraChiudiTutto.PerformClick()

            If IsNothing(g_frmPos) = False Then
               g_frmPos.Tag = "OPERATORE"
               g_frmPos.Close()
            End If

            If IsNothing(g_frmVCTavoli) = False Then
               g_frmVCTavoli.Tag = "OPERATORE"
               g_frmVCTavoli.Close()
            End If

            ' Registra loperazione efettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Logout, String.Empty, MODULO_ACCESSO_OPERATORE)

            ' Apre il dialogo per l'identificazione degli operatori.
            Dim frmAccesso As New frmAccesso
            If frmAccesso.ShowDialog() = DialogResult.Cancel Then
               Application.Exit()
            Else
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

#End Region

#Region " Impostazioni "

   Private Sub eui_cmdGestioneOpzioni_Click(sender As Object, e As EventArgs) Handles eui_cmdGestioneOpzioni.Click
      ' Apre la finestra Opzioni di configurazione.
      ApriOpzioni()
   End Sub

#End Region

#End Region

#Region "Ribbon Menu Archivi "

#Region "Anagrafiche "

   Private Sub eui_cmdArchiviAnagraficheClienti_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheClienti.Click
      ' Apre l'anagrafica Clienti.
      ApriClienti()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()

   End Sub

   Private Sub eui_cmdArchiviAnagraficheFornitori_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheFornitori.Click
      ' Apre l'anagrafica Risorse.
      ApriFornitori()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviAnagraficheCamerieri_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheCamerieri.Click
      ' Apre l'anagrafica Camerieri.
      ApriCamerieri()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviAnagraficheAziende_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheAziende.Click
      ' Apre anagrafica Aziende.
      ApriAziende()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviAnagraficheSale_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheSale.Click
      ' Apre l'anagrafica Sale.
      ApriSale()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviAnagraficheTavoli_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheTavoli.Click
      ' Apre l'elenco Tavoli.
      ApriTavoli()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviAnagraficheCamere_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheCamere.Click
      ' Apre l'elenco Tavoli.
      ApriCamere()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviAnagrafichePiatti_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagrafichePiatti.Click
      ' Apre l'anagrafica Piatti.
      ApriPiatti()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviAnagraficheCategoriePiatti_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheCategoriePiatti.Click
      ' Apre l'anagrafica Categorie Piatti.
      ApriCategoriePiatti()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviAnagraficheRisorse_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheRisorse.Click
      ' Apre l'anagrafica Risorse per il centro sportivo.
      ApriRisorse()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviAnagraficheUtilizzoRisorse_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheUtilizzoRisorse.Click
      ' Apre l'anagrafica Risorse per il centro sportivo.
      ApriTipologieUtilizzoRisorse()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()

   End Sub

   Private Sub eui_cmdArchiviAnagraficheAccServ_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheAccServ.Click
      ' Apre l'anagrafica Accessori e Servizi per il centro sportivo.
      ApriAccessoriServizi()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviAnagraficheDatiAzienda_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviAnagraficheDatiAzienda.Click
      ' Apre anagrafica Azienda.
      ApriAzienda()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

#End Region

#Region "Tabelle"

   Private Sub eui_cmdArchiviTabelleTitoli_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleTitoli.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("Qualifiche")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleCategorieCliente_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleCategorieCliente.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("CategorieClienti")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleAttività_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleAttività.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("Attività")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleComuni_Click(sender As Object, e As EventArgs) Handles eui_cmdArchiviTabelleComuni.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("Comuni")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleNazioni_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleNazioni.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("Nazioni")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleUM_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleUM.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("UnitàMisura")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleCategorieMerce_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleCategorieMerce.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("CategorieMerce")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleMagazzini_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleMagazzini.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("Magazzini")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleUbicazioni_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleUbicazioni.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("Ubicazioni")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleScaffali_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleScaffali.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("Scaffali")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleReparti_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleReparti.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("Reparti")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleMsgReparti_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleMsgReparti.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("MessaggiReparti")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleCausaliDoc_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleCausaliDoc.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("CausaliDocumento")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabellePagamenti_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabellePagamenti.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("ModPagamento")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleListini_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleListini.Click
      ' Apre la tabella dati selezionata.
      ApriListiniCamere()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleStagioni_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleStagioni.Click
      ' Apre la tabella dati selezionata.
      ApriStagioni()
   End Sub

   Private Sub eui_cmdArchiviTabelleTipologieCamere_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleTipologieCamere.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("TipologieCamere")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleUbicazioniCamere_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleUbicazioniCamere.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("UbicazioniCamere")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabellePosizioniCamere_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabellePosizioniCamere.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("PosizioniCamere")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleTipoAlloggiati_Click(sender As Object, e As EventArgs) Handles eui_cmdArchiviTabelleTipoAlloggiati.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("TipoAlloggiato")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleGruppi_Click(sender As Object, e As EventArgs) Handles eui_cmdArchiviTabelleGruppi.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("GruppiOspiti")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleAgenzie_Click(sender As Object, e As EventArgs) Handles eui_cmdArchiviTabelleAgenzie.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("Agenzie")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleCanali_Click(sender As Object, e As EventArgs) Handles eui_cmdArchiviTabelleCanali.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("CanaliVendita")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleStatoPren_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleStatoPren.Click
      ' Questa tabella viene caricata nel form ElencoDati perchè ha il campo Colore.
      ' Apre la tabella dati selezionata. 
      ApriStatoPrenotazioni()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()

   End Sub

   Private Sub eui_cmdArchiviTabelleDocIdentità_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleDocIdentità.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("DocIdentità")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_cmdArchiviTabelleTipoRisorse_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviTabelleTipoRisorse.Click
      ' Apre la tabella dati selezionata.
      ApriTabelle("Tipologie")

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

#End Region

#Region "Strumenti"

   Private Sub eui_cmdArchiviImporta_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviImporta.Click
      ' NON FUNZIONA!
      'Try
      '   Dim cnDbEsterno As OleDbConnection
      '   Dim cnDbInterno As OleDbConnection

      '   Dim percorsoDbEsterno As String = ApriArchivio()

      '   Dim ConnStrDbEsterno As String = CreaConnString(percorsoDbEsterno)
      '   Dim ConnStrDbInterno As String = CreaConnString(PercorsoDB)

      '   ' Apertura dati per il database esterno.
      '   cnDbEsterno = New OleDbConnection(ConnStrDbEsterno)
      '   cnDbEsterno.Open()
      '   Dim oleAdapter As New OleDbDataAdapter
      '   oleAdapter.SelectCommand = New OleDbCommand("SELECT * FROM Clienti", cnDbEsterno)
      '   Dim ds As New DataSet
      '   ds.Clear()
      '   oleAdapter.Fill(ds, "Clienti")
      '   cnDbEsterno.Close()

      '   ' Apertura dati per il database interno.
      '   cnDbInterno = New OleDbConnection(ConnStrDbInterno)
      '   cnDbInterno.Open()
      '   Dim oleAdapter1 As New OleDbDataAdapter
      '   oleAdapter1.UpdateCommand = New OleDbCommand("SELECT * FROM Clienti", cnDbInterno)

      '   oleAdapter1.Update(ds, "Clienti")

      '   cnDbInterno.Close()

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)
      'End Try
   End Sub

   Private Sub eui_cmdArchiviBackup_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviBackup.Click
      Try
         Dim percorsoArchivio As String = SalvaArchivio()

         If percorsoArchivio <> String.Empty Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = SALVA_BKP

            If File.Exists(PercorsoDB) = True Then
               File.Copy(PercorsoDB, percorsoArchivio, True)
            End If

            ' Visualizza un messaggio nella barra di stato.
            Me.eui_Informazioni.Text = LeggiDatiRivenditore()

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default

            MessageBox.Show("Backup eseguito con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            ' Registra loperazione effettuata dall'operatore identificato.
            g_frmMain.RegistraOperazione(TipoOperazione.Backup, String.Empty, MODULO_ARCHIVI_BACKUP)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdArchiviPulizia_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviPulizia.Click
      Try
         Dim risposta As DialogResult
         risposta = MessageBox.Show("Attenzione! Per eseguire la pulizia degli archivi tutte le finestre aperte saranno chiuse. Procedere?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If risposta = DialogResult.Yes Then
            eui_cmdFinestraChiudiTutto.PerformClick()

            If IsNothing(g_frmPos) = False Or IsNothing(g_frmVCTavoli) = False Then
               MessageBox.Show("Attenzione! Chiudere il programma Visual POS è ripetere l'operazione. ", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
               Exit Sub
            End If

            Dim frm As New PuliziaDB
            frm.ShowDialog()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdArchiviCompatta_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchiviCompatta.Click
      Try
         Dim risposta As DialogResult
         risposta = MessageBox.Show("Il comando Compattazione e ripristino provvede a verificare l'integrità del database e ridurre le sue dimensioni! Procedere?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If risposta = DialogResult.Yes Then

            If File.Exists(PercorsoDB) = True Then
               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.AppStarting

               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = SALVA_BKP

               ' Esegue una copia di backup dell'archivio nella cartella Backup dell'applicazione.
               File.Copy(PercorsoDB, Application.StartupPath & PERCORSO_BKP, True)

               ' Esegue la compattazione.
               CompattaDb(PercorsoDB, Application.StartupPath & "\Backup\ChefTemp.mdb")

               ' Elimina il file origine.
               File.Delete(PercorsoDB)

               ' Rinomina il file compattato.
               File.Move(Application.StartupPath & "\Backup\ChefTemp.mdb", Application.StartupPath & PERCORSO_DB)

               ' Visualizza un messaggio nella barra di stato.
               Me.eui_Informazioni.Text = LeggiDatiRivenditore()

               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.Default

               MessageBox.Show("Compattazione e ripristino eseguito con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

               ' Registra loperazione effettuata dall'operatore identificato.
               g_frmMain.RegistraOperazione(TipoOperazione.Compatta, String.Empty, MODULO_ARCHIVI_COMPATTA)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#End Region

#Region "Ribbon Menu Contabilità"

   Private Sub eui_ContabilitàChiusura_Click(sender As System.Object, e As System.EventArgs) Handles eui_ContabilitàChiusura.Click
      ' Apre la finestra per la Chiusura gionaliera.
      ApriChiusuraGiornaliera()
   End Sub

   Private Sub eui_ContabilitàCorrispettivi_Click(sender As System.Object, e As System.EventArgs) Handles eui_ContabilitàCorrispettivi.Click
      ' Apre l'elenco Corrispettivi.
      ApriCorrispettivi()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_ContabilitàPrimaNota_Click(sender As System.Object, e As System.EventArgs) Handles eui_ContabilitàPrimaNota.Click
      ' Apre le statistiche di vendita.
      ApriPrimaNota()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_ContabilitàElencoDocVendita_Click(sender As System.Object, e As System.EventArgs) Handles eui_ContabilitàElencoDocVendita.Click
      ' Apre l'elenco Documenti.
      ApriDoc()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_ContabilitàElencoDocAcquisto_Click(sender As Object, e As EventArgs) Handles eui_ContabilitàElencoDocAcquisto.Click
      ' Apre la finestra elenco acquisti.
      ApriAcquisti()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

#End Region

#Region "Ribbon Menu Magazzino"

   Private Sub eui_MagazzinoArticoli_Click(sender As System.Object, e As System.EventArgs) Handles eui_MagazzinoArticoli.Click
      ' Apre le statistiche di vendita.
      ApriArticoli()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_MagazzinoMovimenti_Click(sender As System.Object, e As System.EventArgs) Handles eui_MagazzinoMovimenti.Click
      ' Apre lo storico dei Movimenti di magazzino.
      ApriMovMag()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_MagazzinoInventario_Click(sender As System.Object, e As System.EventArgs) Handles eui_MagazzinoInventario.Click
      ' Apre l'inventario di magazzino.
      ApriInventario()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_MagazzinoScorte_Click(sender As System.Object, e As System.EventArgs) Handles eui_MagazzinoScorte.Click
      ' Apre l'elenco Situazione Scorte.
      ApriScorte()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

#End Region

#Region "Ribbon Menu Visualizza"

   Private Sub eui_VisualizzaRegOperazioni_Click(sender As System.Object, e As System.EventArgs) Handles eui_VisualizzaRegOperazioni.Click
      ' Apre il registro operazioni.
      ApriOperazioni()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_VisualizzaRegErrori_Click(sender As System.Object, e As System.EventArgs) Handles eui_VisualizzaRegErrori.Click
      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_REG_ERRORI, MODULO_REG_ERRORI)

      ApriRegistroErrori(Me.Handle)
   End Sub

#End Region

#Region "Ribbon Menu Strumenti"

   Private Sub eui_StrumentiEmail_Click(sender As Object, e As EventArgs) Handles eui_StrumentiEmail.Click
      ' Apre l'elenco delle e-mail inviate dal programma.
      ApriEmail()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()

   End Sub

   Private Sub eui_StrumentiMsgReparti_Click(sender As System.Object, e As System.EventArgs) Handles eui_StrumentiMsgReparti.Click
      ' Apre l'elenco dei messaggi ai reparti.
      ApriMessaggi()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_StrumentiEtichette_Click(sender As System.Object, e As System.EventArgs) Handles eui_StrumentiEtichette.Click
      ' Apre l'elenco Etichette.
      ApriEtichette()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_StrumentiCap_Click(sender As System.Object, e As System.EventArgs) Handles eui_StrumentiCap.Click
      ' Apre l'elenco dei CAP.
      ApriCAP()

      ' Aggiunge la finestra aperta al menu Finestra/Seleziona.
      AggiungiFormMenuSeleziona()
   End Sub

   Private Sub eui_StrumentiDispTavoli_Click(sender As System.Object, e As System.EventArgs) Handles eui_StrumentiDispTavoli.Click
      If IsNothing(g_frmVCTavoli) = False Then
         ' Aggiorna Visual POS
         MessageBox.Show("Non è possibile cambiare la disposizione dei tavoli perchè Visual POS è in esecuzione." & vbCrLf &
                         "Si consiglia di chiudere Visual POS e ripetere l'operazione.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         Exit Sub
      End If

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.AppStarting

      Dim frm As New frmDisponiTavoli

      frm.Tag = Me.Tag
      frm.ShowDialog()

      ' Modifica il cursore del mouse.
      Cursor.Current = Cursors.Default
   End Sub

   Private Sub eui_StrumentiMenù_Click(sender As System.Object, e As System.EventArgs) Handles eui_StrumentiMenù.Click
      ' Apre il form per la formazione del Menu.
      ApriMenu()
   End Sub

   Private Sub eui_StrumentiNote_Click(sender As System.Object, e As System.EventArgs) Handles eui_StrumentiNote.Click
      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_STRUMENTI_NOTE, MODULO_STRUMENTI_NOTE)

      AvviaWinBloccoNote(Me.Handle)
   End Sub

   Private Sub eui_StrumentiCalcolatrice_Click(sender As System.Object, e As System.EventArgs) Handles eui_StrumentiCalcolatrice.Click
      ' Registra loperazione effettuata dall'operatore identificato.
      g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_STRUMENTI_CALCOLATRICE, MODULO_STRUMENTI_CALCOLATRICE)

      AvviaWinCalc(Me.Handle)
   End Sub

   Private Sub eui_StrumentiTastiera_Click(sender As System.Object, e As System.EventArgs) Handles eui_StrumentiTastiera.Click
      ' A_TODO: Inserire il modulo Tastiera virtuale per la registrazione delle operazioni. 

      ' Registra loperazione effettuata dall'operatore identificato.
      'g_frmMain.RegistraOperazione(TipoOperazione.Apri, STR_STRUMENTI_CALCOLATRICE, MODULO_STRUMENTI_CALCOLATRICE)

      AvviaTastieraVirtuale(Me.Handle)

   End Sub

#End Region

#Region "Ribbon Menu Finestra"

   Private Sub eui_cmdFinestraSovrapponi_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdFinestraSovrapponi.Click
      Me.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade)
   End Sub

   Private Sub eui_cmdFinestraAffiancaOrizz_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdFinestraAffiancaOrizz.Click
      Me.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal)
   End Sub

   Private Sub eui_cmdFinestraAffiancaVert_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdFinestraAffiancaVert.Click
      Me.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical)
   End Sub

   Private Sub eui_cmdFinestraDisponi_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdFinestraDisponi.Click
      Me.LayoutMdi(System.Windows.Forms.MdiLayout.ArrangeIcons)
   End Sub

   Private Sub eui_cmdFinestraChiudi_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdFinestraChiudi.Click
      Try
         If IsNothing(Me.ActiveMdiChild) <> True Then
            ' Ottiene il form attivo.
            Dim FinestraAttiva As Form = Me.ActiveMdiChild

            ' Chiude il form attivo.
            FinestraAttiva.Close()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdFinestraChiudiTutto_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdFinestraChiudiTutto.Click
      Try
         ' Ottiene il form attivo.
         Dim FinestraAttiva As Form = Me.ActiveMdiChild

         ' Il ciclo serve a chiudere tutti i form attivi.
         Do While (Not FinestraAttiva Is Nothing)
            ' Chiude il form attivo.
            FinestraAttiva.Close()
            ' Ottiene eventuali form attivi.
            FinestraAttiva = Me.ActiveMdiChild
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region "Ribbon Planning Camere "

#Region "Prenotazioni "
   Private Sub eui_PCamere_PrenNuova_Click(sender As System.Object, e As System.EventArgs) Handles eui_PCamere_PrenNuova.Click
      ' Apre una nuova prenotazione.
      g_frmPlanningCamere.ApriDatiPrenotazione(PlanningCamere.Name, "")
   End Sub

   Private Sub eui_PCamere_PrenModifica_Click(sender As System.Object, e As System.EventArgs) Handles eui_PCamere_PrenModifica.Click
      ' Modifica la prenotazione selezionata.
      g_frmPlanningCamere.ApriDatiPrenotazione(PlanningCamere.Name, g_frmPlanningCamere.Tag)
   End Sub

   Private Sub eui_PCamere_PrenElimina_Click(sender As System.Object, e As System.EventArgs) Handles eui_PCamere_PrenElimina.Click
      ' Elimina la prentazione selezionata.
      g_frmPlanningCamere.EliminaPrenotazione()

   End Sub

   Private Sub eui_PCamere_PrenAnnulla_Click(sender As Object, e As EventArgs) Handles eui_PCamere_PrenAnnulla.Click
      ' Elimina la prentazione selezionata.
      g_frmPlanningCamere.AnnullaPrenotazione()
   End Sub

   Private Sub eui_PCamere_PrenAggiorna_Click(sender As Object, e As EventArgs) Handles eui_PCamere_PrenAggiorna.Click
      ' Aggiorna il Planning con eventuali nuove camere e prentazioni..
      g_frmPlanningCamere.AggiornaPlanning()

   End Sub

   Private Sub eui_PCamere_PrenListini_Click(sender As Object, e As EventArgs) Handles eui_PCamere_PrenListini.Click
      ' Apre l'elenco Listini camere.
      eui_cmdArchiviTabelleListini.PerformClick()

   End Sub

   Private Sub eui_PCamere_PrenStagioni_Click(sender As Object, e As EventArgs) Handles eui_PCamere_PrenStagioni.Click
      ' Apre l'elenco Listini camere.
      eui_cmdArchiviTabelleStagioni.PerformClick()

   End Sub

   Private Sub eui_PCamere_PrenElencoCamere_Click(sender As System.Object, e As System.EventArgs) Handles eui_PCamere_PrenElencoCamere.Click
      ' Apre l'elenco Prenotazioni camere.
      eui_cmdGestionePrenCamere.PerformClick()

   End Sub

   Private Sub eui_PCamere_PrenCamere_Click(sender As System.Object, e As System.EventArgs) Handles eui_PCamere_PrenCamere.Click
      ' Apre l'anagrafica Camere.
      eui_cmdArchiviAnagraficheCamere.PerformClick()

   End Sub

   Private Sub eui_PCamere_PrenClienti_Click(sender As System.Object, e As System.EventArgs) Handles eui_PCamere_PrenClienti.Click
      ' Apre l'anagrafica Clienti.
      eui_cmdArchiviAnagraficheClienti.PerformClick()

   End Sub

   Private Sub eui_PCamere_PrenSchedina_Click(sender As Object, e As EventArgs) Handles eui_PCamere_PrenSchedina.Click
      Try
         ' Apre la scheda prenotazioni Camere.
         g_frmPrenCamera = New frmPrenCamera(g_frmPlanningCamere.Name)
         g_frmPrenCamera.Tag = g_frmPlanningCamere.Tag
         g_frmPrenCamera.Show()
         g_frmPrenCamera.ckbSchedina.Checked = True
         g_frmPrenCamera.Hide()

         ' Salva i dati nel database.
         If g_frmPrenCamera.SalvaDati() = True Then

            If g_frmPrenCamera.SalvaSchedinaPS(g_frmPrenCamera.Tag) = True Then
               ' Salva anche tutti i componenti associati.
               g_frmPrenCamera.SalvaOccupantiSchedina(LeggiUltimoRecord(g_frmPrenCamera.TAB_SCHEDINE_PS))

               If IsNothing(g_frmSchedinePS) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmSchedinePS.AggiornaDati()
               End If
            End If

            ' Aggiorna la griglia dati.
            g_frmPlanningCamere.AggiornaPlanning()

            If IsNothing(g_frmPrenCamere) = False Then
               ' Aggiorna la griglia dati.
               g_frmPrenCamere.AggiornaDati()
            End If

         End If

         ' Chiede se aprire l'Elenco Schedine PS.
         Dim risposta As Short
         risposta = MessageBox.Show("La Schedina è stata generata con successo! Si desidera aprire l'Elenco Schedine P.S.?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If risposta = MsgBoxResult.Yes Then
            eui_cmdGestioneSchedine.PerformClick()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         g_frmPrenCamera.Close()

      End Try
   End Sub

   Private Sub eui_PCamere_PrenIstat_Click(sender As Object, e As EventArgs) Handles eui_PCamere_PrenIstat.Click
      Try
         ' Apre la finestra per la selezione della data.
         Dim frm As New DataModIstatC59(PlanningCamere.Name, g_frmPlanningCamere.dtpDataPlanning.Value)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region "Visualizza "

   Private Sub eui_PCamere_VisIndieto_Click(sender As System.Object, e As System.EventArgs) Handles eui_PCamere_VisIndieto.Click
      Try
         If g_frmPlanningCamere.HorizontalScrollBar1.Value >= g_frmPlanningCamere.HorizontalScrollBar1.Maximum Then
            Exit Sub
         Else
            g_frmPlanningCamere.HorizontalScrollBar1.Value -= g_frmPlanningCamere.LARGHEZZA_CELLA

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_PCamere_VisAvanti_Click(sender As System.Object, e As System.EventArgs) Handles eui_PCamere_VisAvanti.Click
      Try
         If g_frmPlanningCamere.HorizontalScrollBar1.Value >= g_frmPlanningCamere.HorizontalScrollBar1.Maximum - 1200 Then
            Exit Sub
         Else
            g_frmPlanningCamere.HorizontalScrollBar1.Value += g_frmPlanningCamere.LARGHEZZA_CELLA

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_PCamere_VisSu_Click(sender As Object, e As EventArgs) Handles eui_PCamere_VisSu.Click
      Try
         If g_frmPlanningCamere.VerticalScrollBar1.Value >= g_frmPlanningCamere.VerticalScrollBar1.Maximum Then
            Exit Sub
         Else
            g_frmPlanningCamere.VerticalScrollBar1.Value -= g_frmPlanningCamere.ALTEZZA_CELLA

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_PCamere_VisGiù_Click(sender As Object, e As EventArgs) Handles eui_PCamere_VisGiù.Click
      Try
         If g_frmPlanningCamere.VerticalScrollBar1.Value >= g_frmPlanningCamere.VerticalScrollBar1.Maximum - 310 Then
            Exit Sub
         Else
            g_frmPlanningCamere.VerticalScrollBar1.Value += g_frmPlanningCamere.ALTEZZA_CELLA

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_PCamere_VisMeseAvanti_Click(sender As Object, e As System.EventArgs) Handles eui_PCamere_VisMeseAvanti.Click
      Try
         If g_frmPlanningCamere.HorizontalScrollBar1.Value >= g_frmPlanningCamere.HorizontalScrollBar1.Maximum - 2000 Then
            Exit Sub
         Else
            With g_frmPlanningCamere

               Dim numGiorniMese As Integer
               numGiorniMese = .dtpCalendario.Value.DaysInMonth(.dtpCalendario.Value.Year, .dtpCalendario.Value.Month)

               Dim larghezzaMese As Integer = numGiorniMese * 40

               .HorizontalScrollBar1.Value += larghezzaMese

               .dtpCalendario.Value = .dtpCalendario.Value.AddMonths(1)
               .dtpDataPlanning.Value = .dtpDataPlanning.Value.GetValueOrDefault.AddMonths(1)

               ' Salva la riga (Camera) corrente.
               Dim rigaCorrente As Integer = .dgvPrenotazioni.CurrentRow.Index

               ' Aggiorna il calendario con il nuovo anno.
               Dim dataSel As String = .dtpDataPlanning.Value.GetValueOrDefault.ToShortDateString

               ' Seleziona la cella prenotazione corrispondende.
               .dgvPrenotazioni.Rows(rigaCorrente).Cells(dataSel).Selected = True

            End With
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         'err.GestisciErrore(ex.StackTrace, ex.Message)

         Exit Sub
      End Try

   End Sub

   Private Sub eui_PCamere_VisMeseIndietro_Click(sender As Object, e As System.EventArgs) Handles eui_PCamere_VisMeseIndietro.Click
      Try
         If g_frmPlanningCamere.HorizontalScrollBar1.Value <= g_frmPlanningCamere.HorizontalScrollBar1.Minimum Then
            Exit Sub
         Else
            With g_frmPlanningCamere
               .dtpCalendario.Value = .dtpCalendario.Value.AddMonths(-1)
               .dtpDataPlanning.Value = .dtpDataPlanning.Value.GetValueOrDefault.AddMonths(-1)

               Dim numGiorniMese As Integer
               numGiorniMese = .dtpCalendario.Value.DaysInMonth(.dtpCalendario.Value.Year, .dtpCalendario.Value.Month)

               Dim larghezzaMese As Integer = numGiorniMese * 40

               .HorizontalScrollBar1.Value -= larghezzaMese

               ' Salva la riga (Camera) corrente.
               Dim rigaCorrente As Integer = .dgvPrenotazioni.CurrentRow.Index

               ' Aggiorna il calendario con il nuovo anno.
               Dim dataSel As String = .dtpDataPlanning.Value.GetValueOrDefault.ToShortDateString

               ' Seleziona la cella prenotazione corrispondende.
               .dgvPrenotazioni.Rows(rigaCorrente).Cells(dataSel).Selected = True

            End With
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         'err.GestisciErrore(ex.StackTrace, ex.Message)

         Exit Sub
      End Try

   End Sub

   Private Sub eui_PCamere_VisAnnoIndietro_Click(sender As Object, e As EventArgs) Handles eui_PCamere_VisAnnoIndietro.Click
      ' False = Indietro.
      g_frmPlanningCamere.ScorriAnno(False)
      g_frmMain.eui_PCamere_VisAnnoAvanti.Enabled = True
   End Sub

   Private Sub eui_PCamere_VisAnnoAvanti_Click(sender As Object, e As EventArgs) Handles eui_PCamere_VisAnnoAvanti.Click
      ' True = Avanti.
      g_frmPlanningCamere.ScorriAnno(True)
      g_frmMain.eui_PCamere_VisAnnoIndietro.Enabled = True
   End Sub

   Private Sub eui_PCamere_VisOggi_Click(sender As Object, e As EventArgs) Handles eui_PCamere_VisOggi.Click
      ' Visualizza il giorno corrente sul planning.
      g_frmPlanningCamere.VisualizzaOggi()
   End Sub

#End Region

#End Region

#Region "Ribbon Strumenti di Modifica "

#Region "Modifica "

   Private Sub eui_Strumenti_Nuovo_Click(sender As System.Object, e As System.EventArgs) Handles eui_Strumenti_Nuovo.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               g_frmPrenCamere.Nuovo()

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS
               g_frmSchedinePS.Nuovo()

            Case TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE
               g_frmListiniCamere.Nuovo()

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               g_frmDocumenti.Nuovo()

            Case TITOLO_FINESTRA_ELENCO_EMAIL
               g_frmEmail.Nuovo()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Modifica_Click(sender As System.Object, e As System.EventArgs) Handles eui_Strumenti_Modifica.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               g_frmPrenCamere.Modifica()

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS
               g_frmSchedinePS.Modifica()

            Case TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE
               g_frmListiniCamere.Modifica()

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.AppStarting

               g_frmDocumento = New frmDocumento("ElencoDoc", g_frmDocumenti.DataGrid1.Item(g_frmDocumenti.DataGrid1.CurrentCell.RowNumber, 4), g_frmDocumenti.DataGrid1.Item(g_frmDocumenti.DataGrid1.CurrentCell.RowNumber, 0))
               g_frmDocumento.ShowDialog()

            Case TITOLO_FINESTRA_ELENCO_EMAIL
               g_frmEmail.Modifica()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Duplica_Click(sender As System.Object, e As System.EventArgs) Handles eui_Strumenti_Duplica.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE
               g_frmListiniCamere.DuplicaDati()

            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               g_frmPrenCamere.DuplicaDati()

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               g_frmDocumenti.DuplicaDocumento()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_Strumenti_Elimina_Click(sender As System.Object, e As System.EventArgs) Handles eui_Strumenti_Elimina.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               g_frmPrenCamere.EliminaDati(ElencoPrenCamere.TAB_PRENOTAZIONI, g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, 0))

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS
               g_frmSchedinePS.EliminaDati(ElencoSchedinePS.TAB_SCHEDINE, g_frmSchedinePS.DataGrid1.Item(g_frmSchedinePS.DataGrid1.CurrentCell.RowNumber, 0))

            Case TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE
               g_frmListiniCamere.EliminaDati(ElencoListiniCamere.TAB_LISTINI, g_frmListiniCamere.DataGrid1.Item(g_frmListiniCamere.DataGrid1.CurrentCell.RowNumber, 0))

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               g_frmDocumenti.EliminaDatiDocumento()

            Case TITOLO_FINESTRA_ELENCO_EMAIL
               g_frmEmail.EliminaDati(ElencoEmail.TAB_EMAIL, g_frmEmail.DataGrid1.Item(g_frmEmail.DataGrid1.CurrentCell.RowNumber, 0))

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Annulla_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Annulla.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               g_frmPrenCamere.AnnullaPrenotazione()

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               g_frmDocumenti.AnnullaDocumento()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_Strumenti_Aggiorna_Click(sender As System.Object, e As System.EventArgs) Handles eui_Strumenti_Aggiorna.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               g_frmPrenCamere.AggiornaDati()

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS
               g_frmSchedinePS.AggiornaDati()

            Case TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE
               g_frmListiniCamere.AggiornaDati()

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               g_frmDocumenti.AggiornaDati()

            Case TITOLO_FINESTRA_ELENCO_EMAIL
               g_frmEmail.AggiornaDati()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_Strumenti_Esporta_Anteprima_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Esporta_Anteprima.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               g_frmPrenCamere.AnteprimaDiStampa(PERCORSO_REP_PREN_CAMERE_A4, g_frmPrenCamere.TAB_PRENOTAZIONI, g_frmPrenCamere.repSql)

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS
               g_frmSchedinePS.AnteprimaDiStampa(PERCORSO_REP_SCHEDINE_PS_A4, g_frmSchedinePS.TAB_SCHEDINE, g_frmSchedinePS.repSql)

            Case TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE
               g_frmListiniCamere.AnteprimaDiStampa(PERCORSO_REP_LISTINI_CAMERE_A4, g_frmListiniCamere.TAB_LISTINI, g_frmListiniCamere.repSql)

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               ' Registra loperazione effettuata dall'operatore identificato.
               RegistraOperazione(TipoOperazione.Anteprima, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

               ' Apre il documento selezionato nell'elenco in anteprima di stampa.
               ApriReports(g_frmDocumenti.repSql, g_frmDocumenti.TAB_DOCUMENTI, PERCORSO_REP_DOC)

            Case TITOLO_FINESTRA_ELENCO_EMAIL
               g_frmEmail.AnteprimaDiStampa(PERCORSO_REP_EMAIL_A4, g_frmEmail.TAB_EMAIL, g_frmEmail.repSql)

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_Strumenti_Esporta_XML_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Esporta_XML.Click
      g_frmDocumenti.NuovaFatturaElettronica()
   End Sub

   Private Sub eui_Strumenti_Esporta_EML_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Esporta_EML.Click
      g_frmEmail.Esporta()
   End Sub

   Private Sub eui_Strumenti_Stampa_Anteprima_Click(sender As System.Object, e As System.EventArgs) Handles eui_Strumenti_Stampa_Anteprima.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               g_frmPrenCamere.AnteprimaDiStampa(PERCORSO_REP_PREN_CAMERE_A4, g_frmPrenCamere.TAB_PRENOTAZIONI, g_frmPrenCamere.repSql)

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS
               g_frmSchedinePS.AnteprimaDiStampa(PERCORSO_REP_SCHEDINE_PS_A4, g_frmSchedinePS.TAB_SCHEDINE, g_frmSchedinePS.repSql)

            Case TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE
               g_frmListiniCamere.AnteprimaDiStampa(PERCORSO_REP_LISTINI_CAMERE_A4, g_frmListiniCamere.TAB_LISTINI, g_frmListiniCamere.repSql)

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               ' Registra loperazione effettuata dall'operatore identificato.
               RegistraOperazione(TipoOperazione.Anteprima, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

               ' Apre il documento selezionato nell'elenco in anteprima di stampa.
               ApriReports(g_frmDocumenti.repSql, g_frmDocumenti.TAB_DOCUMENTI, PERCORSO_REP_DOC)

            Case TITOLO_FINESTRA_ELENCO_EMAIL
               g_frmEmail.AnteprimaDiStampa(PERCORSO_REP_EMAIL_A4, g_frmEmail.TAB_EMAIL, g_frmEmail.repSql)

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Stampa_Elenco_Click(sender As System.Object, e As System.EventArgs) Handles eui_Strumenti_Stampa_Elenco.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               If g_frmPrenCamere.PrintDialog1.ShowDialog() = DialogResult.OK Then
                  g_frmPrenCamere.AnteprimaDiStampa(PERCORSO_REP_PREN_CAMERE_A4, g_frmPrenCamere.TAB_PRENOTAZIONI, g_frmPrenCamere.repSql)
               End If

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS
               If g_frmSchedinePS.PrintDialog1.ShowDialog() = DialogResult.OK Then
                  g_frmSchedinePS.AnteprimaDiStampa(PERCORSO_REP_SCHEDINE_PS_A4, g_frmSchedinePS.TAB_SCHEDINE, g_frmSchedinePS.repSql)
               End If

            Case TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE
               If g_frmListiniCamere.PrintDialog1.ShowDialog() = DialogResult.OK Then
                  g_frmListiniCamere.AnteprimaDiStampa(PERCORSO_REP_LISTINI_CAMERE_A4, g_frmListiniCamere.TAB_LISTINI, g_frmListiniCamere.repSql)
               End If

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               ' Registra loperazione effettuata dall'operatore identificato.
               RegistraOperazione(TipoOperazione.Stampa, STR_CONTABILITA_DOCUMENTI, MODULO_CONTABILITA_DOCUMENTI)

               ' Stampa il documento selezionato nell'elenco.
               g_frmDocumenti.StampaDocumento(PERCORSO_REP_DOC, g_frmDocumenti.TAB_DOCUMENTI, g_frmDocumenti.repSql)

            Case TITOLO_FINESTRA_ELENCO_EMAIL
               If g_frmEmail.PrintDialog1.ShowDialog() = DialogResult.OK Then
                  g_frmEmail.AnteprimaDiStampa(PERCORSO_REP_EMAIL_A4, g_frmEmail.TAB_EMAIL, g_frmEmail.repSql)
               End If

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region "Periodo "

   Private Sub eui_Strumenti_Periodo_Tutte_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Periodo_Tutte.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE

               sender.Pressed = True
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_Arrivo.Pressed = False
               eui_Strumenti_Periodo_Partenza.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               eui_Strumenti_Periodo_NonAssegnate.Pressed = False
               eui_Strumenti_Periodo_Terminate.Pressed = False
               g_frmPrenCamere.AggiornaDatiTutte()

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS

               sender.Pressed = True
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               g_frmSchedinePS.AggiornaDatiTutte()

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI

               sender.Pressed = True
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Sospesi_Filtra.Pressed = False
               g_frmDocumenti.filtroDati = "Tutti"
               g_frmDocumenti.eui_txtTestoRicerca.Text = String.Empty
               g_frmDocumenti.FiltraDati(g_frmDocumenti.eui_txtTestoRicerca.Text, g_frmDocumenti.eui_cmbCampoRicerca.Text)

            Case TITOLO_FINESTRA_ELENCO_EMAIL

               sender.Pressed = True
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               g_frmEmail.AggiornaDatiTutte()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Periodo_Anno_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Periodo_Anno.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Arrivo.Pressed = False
               eui_Strumenti_Periodo_Partenza.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               eui_Strumenti_Periodo_NonAssegnate.Pressed = False
               eui_Strumenti_Periodo_Terminate.Pressed = False
               g_frmPrenCamere.AggiornaDatiAnno()

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               g_frmSchedinePS.AggiornaDatiAnno()

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               sender.Pressed = True
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Sospesi_Filtra.Pressed = False
               g_frmDocumenti.filtroDati = "Anno"
               g_frmDocumenti.eui_txtTestoRicerca.Text = String.Empty
               g_frmDocumenti.AggiornaDatiAnno()

            Case TITOLO_FINESTRA_ELENCO_EMAIL
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               g_frmEmail.AggiornaDatiAnno()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Periodo_Mese_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Periodo_Mese.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_Arrivo.Pressed = False
               eui_Strumenti_Periodo_Partenza.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               eui_Strumenti_Periodo_NonAssegnate.Pressed = False
               eui_Strumenti_Periodo_Terminate.Pressed = False
               g_frmPrenCamere.AggiornaDatiMese()

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               g_frmSchedinePS.AggiornaDatiMese()

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               sender.Pressed = True
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Sospesi_Filtra.Pressed = False
               g_frmDocumenti.filtroDati = "Mese"
               g_frmDocumenti.eui_txtTestoRicerca.Text = String.Empty
               g_frmDocumenti.AggiornaDatiMese()

            Case TITOLO_FINESTRA_ELENCO_EMAIL
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               g_frmEmail.AggiornaDatiMese()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Periodo_DalAl_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Periodo_DalAl.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Arrivo.Pressed = False
               eui_Strumenti_Periodo_Partenza.Pressed = False
               eui_Strumenti_Periodo_NonAssegnate.Pressed = False
               eui_Strumenti_Periodo_Terminate.Pressed = False

               g_frmPrenCamere.AggiornaDatiPeriodo()

            Case TITOLO_FINESTRA_ELENCO_SCHEDINE_PS
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               g_frmSchedinePS.AggiornaDatiPeriodo()

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Sospesi_Filtra.Pressed = False
               g_frmDocumenti.filtroDati = "Periodo"
               g_frmDocumenti.eui_txtTestoRicerca.Text = String.Empty
               g_frmDocumenti.AggiornaDatiPeriodo()

            Case TITOLO_FINESTRA_ELENCO_EMAIL
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               g_frmEmail.AggiornaDatiPeriodo()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Periodo_Arrivo_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Periodo_Arrivo.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Partenza.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               eui_Strumenti_Periodo_NonAssegnate.Pressed = False
               eui_Strumenti_Periodo_Terminate.Pressed = False

               g_frmPrenCamere.AggiornaDatiArrivoOggi()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Periodo_Partenza_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Periodo_Partenza.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Arrivo.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               eui_Strumenti_Periodo_NonAssegnate.Pressed = False
               eui_Strumenti_Periodo_Terminate.Pressed = False

               g_frmPrenCamere.AggiornaDatiPartenzaOggi()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Periodo_NonAssegnate_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Periodo_NonAssegnate.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Arrivo.Pressed = False
               eui_Strumenti_Periodo_Partenza.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               eui_Strumenti_Periodo_Terminate.Pressed = False

               g_frmPrenCamere.AggiornaDatiPrenNonAssegnate()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Periodo_Scadute_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Periodo_Terminate.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Arrivo.Pressed = False
               eui_Strumenti_Periodo_Partenza.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_DalAl.Text = TESTO_FILTRO_PERIODO
               eui_Strumenti_Periodo_NonAssegnate.Pressed = False

               g_frmPrenCamere.AggiornaDatiPrenTerminate()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Visualizza_Presenze_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Visualizza_Presenze.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim frm = New StoricoPresenze
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region "Documenti "

   Private Sub eui_Strumenti_Documenti_Proforma_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Documenti_Proforma.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.AppStarting

               g_frmDocumento = New frmDocumento("ElencoPrenCamere", "Proforma", String.Empty)
               g_frmDocumento.ShowDialog()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Documenti_Ricevuta_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Documenti_Ricevuta.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.AppStarting

               g_frmDocumento = New frmDocumento("ElencoPrenCamere", "Ricevuta Fiscale", String.Empty)
               g_frmDocumento.ShowDialog()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Documenti_Fattura_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Documenti_Fattura.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo
            Case TITOLO_FINESTRA_ELENCO_PREN_CAMERE
               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.AppStarting

               g_frmDocumento = New frmDocumento("ElencoPrenCamere", "Fattura", String.Empty)
               g_frmDocumento.ShowDialog()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Documenti_Stampa_Schedina_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Documenti_Stampa_Schedina.Click
      g_frmSchedinePS.AnteprimaDiStampaSchedina(PERCORSO_REP_SCHEDINA_PS_A4)

   End Sub

   Private Sub eui_Strumenti_Documenti_IstatC59_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Documenti_IstatC59.Click
      Try
         ' Apre la finestra per la selezione della data.
         Dim frm As New DataModIstatC59(ElencoPrenCamere.Name, Today)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Documenti_Schedina_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Documenti_Schedina.Click
      Try
         ' Apre la scheda prenotazioni Camere.
         g_frmPrenCamera = New frmPrenCamera(g_frmPrenCamere.Name)
         g_frmPrenCamera.Tag = Convert.ToString(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, 0))
         g_frmPrenCamera.Show()
         g_frmPrenCamera.ckbSchedina.Checked = True
         g_frmPrenCamera.Hide()

         ' Salva i dati nel database.
         If g_frmPrenCamera.SalvaDati() = True Then

            If g_frmPrenCamera.SalvaSchedinaPS(g_frmPrenCamera.Tag) = True Then
               ' Salva anche tutti i componenti associati.
               g_frmPrenCamera.SalvaOccupantiSchedina(LeggiUltimoRecord(g_frmPrenCamera.TAB_SCHEDINE_PS))

               ' Salva lo storico delle presenze.
               g_frmPrenCamera.SalvaStoricoPresenzeMeseAnno(LeggiUltimoRecord(g_frmPrenCamera.TAB_SCHEDINE_PS))

               If IsNothing(g_frmSchedinePS) = False Then
                  ' Aggiorna la griglia dati.
                  g_frmSchedinePS.AggiornaDati()
               End If
            End If

            ' Aggiorna la griglia dati.
            g_frmPrenCamere.AggiornaDati()

            If IsNothing(g_frmPlanningCamere) = False Then
               ' Aggiorna la griglia dati.
               g_frmPlanningCamere.AggiornaPlanning()
            End If

         End If

         ' Chiede se aprire l'Elenco Schedine PS.
         Dim risposta As Short
         risposta = MessageBox.Show("La Schedina è stata generata con successo! Si desidera aprire l'Elenco Schedine P.S.?", NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question)

         If risposta = MsgBoxResult.Yes Then
            eui_cmdGestioneSchedine.PerformClick()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         g_frmPrenCamera.Close()

      End Try

   End Sub

   Private Sub eui_Strumenti_Documenti_Invia_Riepilogo_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Documenti_Invia_Riepilogo.Click
      Try
         ' Genera il file Riepilogo prenotazione in formato PDF.
         Dim percorsoFilePDF As String = GeneraRiepilogoPren_PDF(LeggiLogoAzienda, LeggiRagSocialeAzienda, LeggiIndirizzoAzienda, LeggiCapAzienda, LeggiPivaAzienda, LeggiTelFaxAzienda, LeggiEmailAzienda,
                                                                 LeggiNumPrenotazione, LeggiDatiRiepilogoPrenotazione, LeggiNomeCompletoDestinatario, LeggiEmailDestinatario,
                                                                 LeggiArrivoPrenotazione(False), LeggiPartenzaPrenotazione(False), LeggiNottiPrenotazione,
                                                                 LeggiAdultiPrenotazione, LeggiNeonatiPrenotazione, LeggiBambiniPrenotazione, LeggiRagazziPrenotazione,
                                                                 LeggiNumCameraPrenotazione, LeggiTipoCameraPrenotazione, LeggiArrangiamentoPrenotazione,
                                                                 LeggiTotaleImportoPrenotazione, LeggiAccontoPrenotazione, LeggiSaldoPrenotazione, LeggiNotePrenotazione,
                                                                 Application.StartupPath & "\Documenti\Riepilogo prenotazione_" & LeggiNumPrenotazione() & ".pdf")

         ' Invia un'e-mail al cliente con allegato un documento pdf della prenotazione camera.
         Dim frmEmail As New InvioEmail(LeggiEmailMittente, LeggiEmailDestinatario, LeggiDatiRiepilogoPrenotazione, CreaMessaggio, percorsoFilePDF,
                                        LeggiIdCliente, LeggiNomeDestinatario, LeggiCognomeDestinatario, CATEGORIA_PREN_CAMERE)

         frmEmail.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_Strumenti_Documenti_Invia_Caparra_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Documenti_Invia_Caparra.Click
      Try
         ' Genera il file Ricevuta Caparra confirmatoria in formato PDF.
         Dim percorsoFilePDF As String = GeneraRicevutaCaparraPren_PDF(LeggiLogoAzienda, LeggiRagSocialeAzienda, LeggiIndirizzoAzienda, LeggiCapAzienda,
                                                                       LeggiPivaAzienda, LeggiTelFaxAzienda, LeggiEmailAzienda, LeggiNumPrenotazione, LeggiDataPrenotazione(True),
                                                                       LeggiNomeCompletoDestinatario, LeggiArrivoPrenotazione(True), LeggiPartenzaPrenotazione(True), LeggiAccontoPrenotazione)

         ' Invia un'e-mail al cliente con allegato un documento pdf della prenotazione camera.
         Dim frmEmail As New InvioEmail(LeggiEmailMittente, LeggiEmailDestinatario, LeggiDatiCaparraPrenotazione, CreaMessaggio, percorsoFilePDF,
                                        LeggiIdCliente, LeggiNomeDestinatario, LeggiCognomeDestinatario, CATEGORIA_PREN_CAMERE)

         frmEmail.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdEsportaPdf_Click(sender As Object, e As EventArgs) Handles eui_cmdEsportaPdf.Click
      Try
         ' Imposta la finesta di dialogo.
         SaveFileDialog1.Filter = "Formato PDF |*.pdf"
         SaveFileDialog1.FilterIndex = 1
         SaveFileDialog1.FileName = "Riepilogo prenotazione_" & LeggiNumPrenotazione() & ".pdf"

         ' Salva il percorso del file selezionato.
         If SaveFileDialog1.ShowDialog() = DialogResult.OK Then

            ' Genera il file.
            Dim percorsoFilePDF As String = GeneraRiepilogoPren_PDF(LeggiLogoAzienda, LeggiRagSocialeAzienda, LeggiIndirizzoAzienda, LeggiCapAzienda, LeggiPivaAzienda, LeggiTelFaxAzienda, LeggiEmailAzienda,
                                                                 LeggiNumPrenotazione, LeggiDatiRiepilogoPrenotazione, LeggiNomeCompletoDestinatario, LeggiEmailDestinatario,
                                                                 LeggiArrivoPrenotazione(False), LeggiPartenzaPrenotazione(False), LeggiNottiPrenotazione,
                                                                 LeggiAdultiPrenotazione, LeggiNeonatiPrenotazione, LeggiBambiniPrenotazione, LeggiRagazziPrenotazione,
                                                                 LeggiNumCameraPrenotazione, LeggiTipoCameraPrenotazione, LeggiArrangiamentoPrenotazione,
                                                                 LeggiTotaleImportoPrenotazione, LeggiAccontoPrenotazione, LeggiSaldoPrenotazione, LeggiNotePrenotazione,
                                                                 SaveFileDialog1.FileName)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ' DA_FARE_B: Sviluppare!
   Private Sub eui_cmdEsportaHtml_Click(sender As Object, e As EventArgs) Handles eui_cmdEsportaHtml.Click

   End Sub

   Private Sub eui_cmdEsportaTxtSelezione_Click(sender As Object, e As EventArgs) Handles eui_cmdEsportaTxtSelezione.Click
      g_frmSchedinePS.SalvaFileTxtAlloggiatiWeb(False)

   End Sub

   Private Sub eui_cmdEsportaTxtTutte_Click(sender As Object, e As EventArgs) Handles eui_cmdEsportaTxtTutte.Click
      g_frmSchedinePS.SalvaFileTxtAlloggiatiWeb(True)

   End Sub

#End Region

#Region "Sospesi / Buoni pasto "

   Private Sub eui_Strumenti_Sospesi_Filtra_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Sospesi_Filtra.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)


         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               sender.Pressed = True
               eui_Strumenti_Periodo_Tutte.Pressed = False
               eui_Strumenti_Periodo_DalAl.Pressed = False
               eui_Strumenti_Periodo_Mese.Pressed = False
               eui_Strumenti_Periodo_Anno.Pressed = False
               g_frmDocumenti.filtroDati = "Tutti"
               g_frmDocumenti.eui_txtTestoRicerca.Text = String.Empty
               g_frmDocumenti.AggiornaDatiSospesi()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_Strumenti_Sospesi_Incassa_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Sospesi_Incassa.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               ' Apre la finestra per l'incasso del sospeso.
               g_frmDocumenti.IncassaSospeso()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_Strumenti_Sospesi_Annulla_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Sospesi_Annulla.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               ' Annulla l'importo sospeso del documento selezionato.
               g_frmDocumenti.AnnullaSospeso(g_frmDocumenti.DataGrid1.Item(g_frmDocumenti.DataGrid1.CurrentCell.RowNumber, 0))

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_Strumenti_Sospesi_Passa_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Sospesi_Passa.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               ' Passa l'importo del documento selezionato in sospeso.
               g_frmDocumenti.PassaSospeso(g_frmDocumenti.DataGrid1.Item(g_frmDocumenti.DataGrid1.CurrentCell.RowNumber, 0), g_frmDocumenti.DataGrid1.Item(g_frmDocumenti.DataGrid1.CurrentCell.RowNumber, 9))

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_Strumenti_Buoni_Pasto_Click(sender As Object, e As EventArgs) Handles eui_Strumenti_Buoni_Pasto.Click
      Try
         ' Ottiene il form attivo.
         Dim frmAttivo As String = EstraiNomeFinestra(Me.ActiveMdiChild.Text)

         ' Richiama la procedura per la modifica dei dati del form attivo.
         Select Case frmAttivo

            Case TITOLO_FINESTRA_ELENCO_DOCUMENTI
               ' Apre l'elenco dei buoni contenuti nel documento selezionato.
               g_frmDocumenti.ApriElencoBuoni()

               ' Inserire qui il codice per gestire le altre finestre.

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

#End Region

#End Region

#Region "Procedure per i Moduli "

   Public Function AttivaProdotto(ByVal chiaveAttivazione As String, ByVal codice1 As String, ByVal codice2 As String,
                                   ByVal codice3 As String, ByVal codice4 As String, ByVal codice5 As String, ByVal nomeChiaveConfig As String) As Boolean
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim chiaveDigitata As String = UCase(codice1.ToUpper & codice2.ToUpper & codice3.ToUpper & codice4.ToUpper & codice5.ToUpper)

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If DatiConfig.GetValue(nomeChiaveConfig).ToUpper = chiaveAttivazione Then
            Dim risposta As DialogResult
            risposta = MessageBox.Show("La licenza per questo modulo o prodotto è già attiva!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            Return False
         Else
            If chiaveDigitata = chiaveAttivazione Then

               ' Salva la chiave ne file di configurazione.
               DatiConfig.SetValue(nomeChiaveConfig, chiaveAttivazione)

               Dim risposta As DialogResult
               risposta = MessageBox.Show("La licenza per questo modulo o prodotto è stata attivata con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
               Return True
            Else
               Dim risposta As DialogResult
               risposta = MessageBox.Show("Il codice di attivazione inserito non è corretto. Richiedere un codice valido!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
               Return False
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Function

   Private Function DisattivaProdotto(ByVal nomeChiaveConfig As String) As Boolean
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         DatiConfig.SetValue(nomeChiaveConfig, "")

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

   Private Sub ImpostaModuli()
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Verifica la presenza della chiave di attivazione.
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) = String.Empty Then

            ' Installazione su computer - La chiave di attivazione viene generata dal PC e confrontata con quella salvata nel file di configurazione.
            If DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY) Then
               moduloAttivo.Hospitality = True
            Else
               moduloAttivo.Hospitality = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_MAGAZZINO_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_MAGAZZINO) Then
               moduloAttivo.Magazzino = True
            Else
               moduloAttivo.Magazzino = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_ETICHETTE_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_ETICHETTE) Then
               moduloAttivo.Etichette = True
            Else
               moduloAttivo.Etichette = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_PENDRIVE_RECOVERY_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_RECOVERY) Then
               moduloAttivo.PenDriveRecovery = True
            Else
               moduloAttivo.PenDriveRecovery = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_PORTABLE) Then
               moduloAttivo.PenDrivePortable = True
            Else
               moduloAttivo.PenDrivePortable = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_REG_CASSA_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_REG_CASSA) Then
               moduloAttivo.RegCassa = True
            Else
               moduloAttivo.RegCassa = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_FATT_ELETTRONICA_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_FATT_ELETTRONICA) Then
               moduloAttivo.FattElettronica = True
            Else
               moduloAttivo.FattElettronica = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_BAR) Then
               moduloAttivo.Bar = True
            Else
               moduloAttivo.Bar = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_RISTORANTE) Then
               moduloAttivo.Ristorante = True
            Else
               moduloAttivo.Ristorante = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_PALMARI_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PALMARI) Then
               moduloAttivo.Palmari = True
            Else
               moduloAttivo.Palmari = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_PREN_ONLINE_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PREN_ONLINE) Then
               moduloAttivo.PrenOnLine = True
            Else
               moduloAttivo.PrenOnLine = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_SPORTING_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_CENTRO_SPORTIVO) Then
               moduloAttivo.CentroSportivo = True
            Else
               moduloAttivo.CentroSportivo = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_HOTEL_CONFIG) = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOTEL) Then
               moduloAttivo.Hotel = True
            Else
               moduloAttivo.Hotel = False
            End If

         Else

            ' Installazione su USB Pen Drive - La chiave di attivazione non viene generata dal PC ma viene controllata la sua esistenza nel file di configurazione.
            If DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG).Length = 25 Then
               moduloAttivo.Hospitality = True
            Else
               moduloAttivo.Hospitality = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_MAGAZZINO_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_MAGAZZINO_CONFIG).Length = 25 Then
               moduloAttivo.Magazzino = True
            Else
               moduloAttivo.Magazzino = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_ETICHETTE_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_ETICHETTE_CONFIG).Length = 25 Then
               moduloAttivo.Etichette = True
            Else
               moduloAttivo.Etichette = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_PENDRIVE_RECOVERY_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_PENDRIVE_RECOVERY_CONFIG).Length = 25 Then
               moduloAttivo.PenDriveRecovery = True
            Else
               moduloAttivo.PenDriveRecovery = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG).Length = 25 Then
               moduloAttivo.PenDrivePortable = True
            Else
               moduloAttivo.PenDrivePortable = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_REG_CASSA_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_REG_CASSA_CONFIG).Length = 25 Then
               moduloAttivo.RegCassa = True
            Else
               moduloAttivo.RegCassa = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_FATT_ELETTRONICA_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_FATT_ELETTRONICA_CONFIG).Length = 25 Then
               moduloAttivo.FattElettronica = True
            Else
               moduloAttivo.FattElettronica = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG).Length = 25 Then
               moduloAttivo.Bar = True
            Else
               moduloAttivo.Bar = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG).Length = 25 Then
               moduloAttivo.Ristorante = True
            Else
               moduloAttivo.Ristorante = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_PALMARI_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_PALMARI_CONFIG).Length = 25 Then
               moduloAttivo.Palmari = True
            Else
               moduloAttivo.Palmari = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_PREN_ONLINE_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_PREN_ONLINE_CONFIG).Length = 25 Then
               moduloAttivo.PrenOnLine = True
            Else
               moduloAttivo.PrenOnLine = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_SPORTING_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_SPORTING_CONFIG).Length = 25 Then
               moduloAttivo.CentroSportivo = True
            Else
               moduloAttivo.CentroSportivo = False
            End If
            If DatiConfig.GetValue(Modulo.NOME_HOTEL_CONFIG) <> String.Empty And DatiConfig.GetValue(Modulo.NOME_HOTEL_CONFIG).Length = 25 Then
               moduloAttivo.Hotel = True
            Else
               moduloAttivo.Hotel = False
            End If

         End If

         Dim i As Integer = 0

         If moduloAttivo.Hospitality = True Then
            eui_File.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Default
            NOME_PRODOTTO = NOME_PRODOTTO_HOSPITALITY_SUITE
            ImpostaIcona(Me)
            Me.Text = NOME_PRODOTTO
            AttivaDisattivaTutto(True)
         Else
            If moduloAttivo.Bar = True And moduloAttivo.Ristorante = False Then
               eui_File.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Office2010Olive
               NOME_PRODOTTO = NOME_PRODOTTO_BAR
               i = i + 1
            End If

            If moduloAttivo.Ristorante = True Then
               eui_File.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Office2010Green
               NOME_PRODOTTO = NOME_PRODOTTO_CHEF
               i = i + 1
            End If

            If moduloAttivo.CentroSportivo = True Then
               eui_File.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Office2010Cyan
               NOME_PRODOTTO = NOME_PRODOTTO_SPORTING
               i = i + 1
            End If

            If moduloAttivo.Hotel = True Then
               eui_File.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Office2010Rust
               NOME_PRODOTTO = NOME_PRODOTTO_HOTEL
               i = i + 1
            End If

            If i = 1 Then
               AttivaDisattivaTutto(True)

            ElseIf i > 1 Then
               eui_File.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Default
               NOME_PRODOTTO = NOME_PRODOTTO_HOSPITALITY
               AttivaDisattivaTutto(True)

            ElseIf i = 0 Then
               eui_File.ApplicationButtonStyle = Elegant.Ui.RibbonApplicationButtonStyle.Default
               NOME_PRODOTTO = NOME_PRODOTTO_HOSPITALITY_SUITE

               If moduloAttivo.Magazzino = True Then
                  If DisattivaProdotto(Modulo.NOME_MAGAZZINO_CONFIG) = True Then
                     ImpostaDatiListaModuli(Modulo.NOME_MAGAZZINO, "", Color.Gray, False)
                     moduloAttivo.Magazzino = False
                  End If
               End If
               If moduloAttivo.Etichette = True Then
                  If DisattivaProdotto(Modulo.NOME_ETICHETTE_CONFIG) = True Then
                     ImpostaDatiListaModuli(Modulo.NOME_ETICHETTE, "", Color.Gray, False)
                     moduloAttivo.Etichette = False
                  End If
               End If
               If moduloAttivo.PenDrivePortable = True Then
                  If DisattivaProdotto(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) = True Then
                     ImpostaDatiListaModuli(Modulo.NOME_PENDRIVE_PORTABLE, "", Color.Gray, False)
                     moduloAttivo.PenDrivePortable = False
                  End If
               End If
               If moduloAttivo.PenDriveRecovery = True Then
                  If DisattivaProdotto(Modulo.NOME_PENDRIVE_RECOVERY_CONFIG) = True Then
                     ImpostaDatiListaModuli(Modulo.NOME_PENDRIVE_RECOVERY, "", Color.Gray, False)
                     moduloAttivo.PenDriveRecovery = False
                  End If
               End If
               If moduloAttivo.RegCassa = True Then
                  If DisattivaProdotto(Modulo.NOME_REG_CASSA_CONFIG) = True Then
                     ImpostaDatiListaModuli(Modulo.NOME_REG_CASSA, "", Color.Gray, False)
                     moduloAttivo.RegCassa = False
                  End If
               End If
               If moduloAttivo.FattElettronica = True Then
                  If DisattivaProdotto(Modulo.NOME_FATT_ELETTRONICA_CONFIG) = True Then
                     ImpostaDatiListaModuli(Modulo.NOME_FATT_ELETTRONICA, "", Color.Gray, False)
                     moduloAttivo.FattElettronica = False
                  End If
               End If

               AttivaDisattivaTutto(False)

               MessageBox.Show(MSG_RIMOSSI_TUTTI_PRODOTTI, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If

            ' Imposta l'icona della finestra in base al prodotto installato.
            ImpostaIcona(Me)
            Me.Text = NOME_PRODOTTO
         End If

         ' Per i prodotti mantenere questo ordine di esecuzione
         ' 1.
         AttivaDisattivaModuloHotel(moduloAttivo.Hotel)
         ' 2.
         AttivaDisattivaModuloRistorante(moduloAttivo.Ristorante)
         ' 3.
         AttivaDisattivaModuloBar(moduloAttivo.Bar)
         ' 4.
         AttivaDisattivaModuloCentroSportivo(moduloAttivo.CentroSportivo)

         ' Per i moduli non è necessario un ordine di esecuzione.
         AttivaDisattivaModuloMagazzino(moduloAttivo.Magazzino)
         AttivaDisattivaModuloEtichette(moduloAttivo.Etichette)
         AttivaDisattivaModuloPalmari(moduloAttivo.Palmari)
         AttivaDisattivaModuloPrenOnLine(moduloAttivo.PrenOnLine)
         AttivaDisattivaModuloPenDriveRecovery(moduloAttivo.PenDriveRecovery)
         AttivaDisattivaModuloPenDrivePortable(moduloAttivo.PenDrivePortable)
         AttivaDisattivaModuloRegCassa(moduloAttivo.RegCassa)
         AttivaDisattivaModuloFattElettronica(moduloAttivo.FattElettronica)

         VerificaVisibilitàGruppiModuli()

         ' Aggiorna le informazioni dei prodotti installati.
         CaricaInfoProdottiAttivi()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub CaricaListaModuli()
      Try
         ' HOSPITALITY SOLUTION SUITE.
         If moduloAttivo.Hospitality = True Then
            ImpostaDatiListaModuli(Modulo.NOME_HOSPITALITY, CHIAVE_ATTIVAZIONE_HOSPITALITY, Color.MidnightBlue, True)
         End If

         ' HOTEL SOLUTION.
         If moduloAttivo.Hotel = True Then
            ImpostaDatiListaModuli(Modulo.NOME_HOTEL, CHIAVE_ATTIVAZIONE_HOTEL, Color.Brown, True)
         End If

         ' BAR SOLUTION.
         If moduloAttivo.Bar = True Then
            ImpostaDatiListaModuli(Modulo.NOME_BAR, CHIAVE_ATTIVAZIONE_BAR, Color.Green, True)
         End If

         ' CHEF SOLUTION.
         If moduloAttivo.Ristorante = True Then
            ImpostaDatiListaModuli(Modulo.NOME_CHEF, CHIAVE_ATTIVAZIONE_RISTORANTE, Color.Green, True)
         End If

         ' SPORTING CLUB SOLUTION.
         If moduloAttivo.CentroSportivo = True Then
            ImpostaDatiListaModuli(Modulo.NOME_SPORTING, CHIAVE_ATTIVAZIONE_CENTRO_SPORTIVO, Color.DarkCyan, True)
         End If

         ' MODULO MAGAZZINO.
         If moduloAttivo.Magazzino = True Then
            ImpostaDatiListaModuli(Modulo.NOME_MAGAZZINO, CHIAVE_ATTIVAZIONE_MAGAZZINO, Color.MidnightBlue, True)
         End If

         ' MODULO ETICHETTE.
         If moduloAttivo.Etichette = True Then
            ImpostaDatiListaModuli(Modulo.NOME_ETICHETTE, CHIAVE_ATTIVAZIONE_ETICHETTE, Color.MidnightBlue, True)
         End If

         ' MODULO PALMARI.
         If moduloAttivo.Palmari = True Then
            ImpostaDatiListaModuli(Modulo.NOME_PALMARI, CHIAVE_ATTIVAZIONE_PALMARI, Color.Green, True)
         End If

         ' MODULO PRENOTAZIONI ON-LINE.
         If moduloAttivo.PrenOnLine = True Then
            ImpostaDatiListaModuli(Modulo.NOME_PREN_ONLINE, CHIAVE_ATTIVAZIONE_PREN_ONLINE, Color.Green, True)
         End If

         ' MODULO PEN DRIVE RECOVERY.
         If moduloAttivo.PenDriveRecovery = True Then
            ImpostaDatiListaModuli(Modulo.NOME_PENDRIVE_RECOVERY, CHIAVE_ATTIVAZIONE_PENDRIVE_RECOVERY, Color.MidnightBlue, True)
         End If

         ' MODULO PEN DRIVE PORTABLE.
         If moduloAttivo.PenDrivePortable = True Then
            ImpostaDatiListaModuli(Modulo.NOME_PENDRIVE_PORTABLE, CHIAVE_ATTIVAZIONE_PENDRIVE_PORTABLE, Color.MidnightBlue, True)
         End If

         ' MODULO REGISTATORI DI CASSA.
         If moduloAttivo.RegCassa = True Then
            ImpostaDatiListaModuli(Modulo.NOME_REG_CASSA, CHIAVE_ATTIVAZIONE_REG_CASSA, Color.MidnightBlue, True)
         End If

         ' MODULO FATTURAZIONE ELETTRONICA.
         If moduloAttivo.FattElettronica = True Then
            ImpostaDatiListaModuli(Modulo.NOME_FATT_ELETTRONICA, CHIAVE_ATTIVAZIONE_FATT_ELETTRONICA, Color.MidnightBlue, True)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub ImpostaDatiListaModuli(ByVal nomeModulo As String, ByVal chiaveAttivazioneModulo As String, ByVal colore As Color, ByVal stato As Boolean)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         For Each Item As ListViewItem In lvwGestioneModuli.Items
            If Item.Text = nomeModulo Then
               impostaListaModuli = True
               Item.SubItems(3).ForeColor = colore

               If stato = True Then
                  Item.SubItems(3).Text = "ATTIVO"
                  Dim codice As String = CodAttivazioneInserisciTrattini(GeneraChiaveLicenza(chiaveAttivazioneModulo))
                  Item.SubItems(2).Text = codice
               Else
                  Item.SubItems(3).Text = "NON ATTIVO"
                  Item.SubItems(2).Text = String.Empty
               End If

               Item.Checked = stato

               impostaListaModuli = False
               Exit For
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Public Sub AttivaDisattivaTutto(ByVal stato As Boolean)

      eui_File.CurrentTabPage = eui_File.TabPages(0)
      eui_Gestione.Enabled = stato
      eui_Archivi.Enabled = stato
      eui_Contabilità.Enabled = stato
      eui_Magazzino.Enabled = stato
      eui_Visualizza.Enabled = stato
      eui_Strumenti.Enabled = stato
      eui_Finestra.Enabled = stato

      cmdBackup.Enabled = stato
      cmdPulizia.Enabled = stato
      cmdCompatta.Enabled = stato
      cmdApriPercorso.Enabled = stato
      picProg.Enabled = stato
      eui_cmdOpzioni.Enabled = stato
      eui_Opzioni.Enabled = stato

   End Sub

   Private Function VerificaProdottoAttivo() As Boolean
      Try
         If DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG) <> String.Empty Then
            Return True
         End If
         If DatiConfig.GetValue(Modulo.NOME_HOTEL_CONFIG) <> String.Empty Then
            Return True
         End If
         If DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG) <> String.Empty Then
            Return True
         End If
         If DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG) <> String.Empty Then
            Return True
         End If
         If DatiConfig.GetValue(Modulo.NOME_SPORTING_CONFIG) <> String.Empty Then
            Return True
         End If

         Return False

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try
   End Function

   Private Sub AttivaDisattivaModuloHotel(ByVal stato As Boolean)
      Try
         ' Prenotazioni.
         If moduloAttivo.Ristorante = False And moduloAttivo.CentroSportivo = False Then
            eui_GruppoPrenotazioni.Visible = stato ' Comune
            eui_ddwnGestionePrenotazioni.Visible = stato ' Comune
         End If

         'eui_ddwnGestioneQuadroGiornaliero.Visible = stato
         eui_cmdGestionePlanningCamere.Visible = stato
         sepPlannigCamere.Visible = stato
         eui_cmdGestionePrenCamere.Visible = stato
         sepPrenCamere.Visible = stato
         eui_cmdGestioneSchedine.Visible = stato

         ' Archivi / Anagrafiche.
         eui_cmdArchiviAnagraficheCamere.Visible = stato
         sepCamere.Visible = stato
         eui_cmdArchiviAnagraficheAccServ.Visible = stato ' Comune

         ' Archivi / Tabelle.
         eui_cmdArchiviTabelleListini.Visible = stato
         eui_cmdArchiviTabelleStagioni.Visible = stato
         eui_cmdArchiviTabelleTipologieCamere.Visible = stato
         eui_cmdArchiviTabelleUbicazioniCamere.Visible = stato
         eui_cmdArchiviTabellePosizioniCamere.Visible = stato
         eui_cmdArchiviTabelleTipoAlloggiati.Visible = stato
         eui_cmdArchiviTabelleGruppi.Visible = stato
         eui_cmdArchiviTabelleAgenzie.Visible = stato
         eui_cmdArchiviTabelleCanali.Visible = stato
         sepListini.Visible = stato
         eui_cmdArchiviTabelleStatoPren.Visible = stato
         sepStatoPren.Visible = stato

         ' Gestione.
         eui_cmdGestioneStatisticheHotel.Visible = stato ' Comune
         sepHotel.Visible = stato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloRistorante(ByVal stato As Boolean)
      Try
         ' Gruppo POS.
         If moduloAttivo.Bar = False Then
            eui_GruppoPos.Visible = stato
         Else
            eui_GruppoPos.Visible = True
         End If

         ' POS.
         eui_cmdGestionePosCassa.Visible = stato ' Comune
         eui_cmdGestionePosTavoli.Visible = stato

         ' Prenotazioni.
         If moduloAttivo.CentroSportivo = False And moduloAttivo.Hotel = False Then
            eui_GruppoPrenotazioni.Visible = stato ' Comune
            eui_ddwnGestionePrenotazioni.Visible = stato ' Comune
         End If

         eui_cmdGestionePrenTavoli.Visible = stato
         eui_cmdGestionePrenSale.Visible = stato
         sepPrenRisorse.Visible = stato
         ' Tavoli
         eui_GruppoTavoli.Visible = stato
         ' Reparti.
         eui_GruppoReparti.Visible = stato
         eui_cmdArchiviTabelleReparti.Visible = stato
         sepReparti.Visible = stato
         ' Menu
         eui_GruppoMenu.Visible = stato ' Comune
         ' Archivi / Anagrafiche.
         eui_cmdArchiviAnagrafichePiatti.Visible = stato ' Comune
         eui_cmdArchiviAnagraficheCategoriePiatti.Visible = stato ' Comune
         sepBar.Visible = stato
         eui_cmdArchiviAnagraficheCamerieri.Visible = stato
         eui_cmdArchiviAnagraficheTavoli.Visible = stato
         eui_cmdArchiviAnagraficheSale.Visible = stato
         sepRistorante.Visible = stato
         ' Archivi / Tabelle.
         eui_cmdArchiviTabelleMsgReparti.Visible = stato
         sepReparti.Visible = stato
         If moduloAttivo.Hotel = False Then
            eui_cmdArchiviTabelleStatoPren.Visible = stato
            sepStatoPren.Visible = stato
         Else
            eui_cmdArchiviTabelleStatoPren.Visible = True
            sepStatoPren.Visible = True
         End If

         ' Gestione.
         eui_cmdGestioneStatistiche.Visible = stato ' Comune
         sepBarRistorante.Visible = stato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloBar(ByVal stato As Boolean)
      Try
         If moduloAttivo.Ristorante = False Then
            ' Gruppo POS.
            eui_GruppoPos.Visible = stato
            ' POS.
            eui_cmdGestionePosCassa.Visible = stato ' Comune
            ' Menu.
            eui_GruppoMenu.Visible = stato ' Comune
            ' Archivi / Anagrafiche.
            eui_cmdArchiviAnagrafichePiatti.Visible = stato ' Comune
            eui_cmdArchiviAnagraficheCategoriePiatti.Visible = stato ' Comune
            sepBar.Visible = stato
            ' Archivi / Tabelle.
            eui_cmdArchiviTabelleReparti.Visible = stato
            sepReparti.Visible = stato
            ' Gestione.
            eui_cmdGestioneStatistiche.Visible = stato ' Comune
            sepBarRistorante.Visible = stato
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloCentroSportivo(ByVal stato As Boolean)
      Try
         ' A_TODO: MODIFICHE ASD AGON

         ' Prenotazioni.
         If moduloAttivo.Ristorante = False And moduloAttivo.Hotel = False Then
            eui_GruppoPrenotazioni.Visible = stato ' Comune
            eui_ddwnGestionePrenotazioni.Visible = stato ' Comune
         End If

         ' Planning.
         If moduloAttivo.Hotel = False Then
            eui_ddwnGestionePlanningRisorse.Visible = stato ' Comune
            eui_cmdArchiviAnagraficheAccServ.Visible = stato ' Comune
         Else
            eui_ddwnGestionePlanningRisorse.Visible = True ' Comune
            eui_cmdArchiviAnagraficheAccServ.Visible = True ' Comune
         End If

         eui_cmdGestionePlanningRisorseSport.Visible = stato
         eui_cmdGestionePrenRisorse.Visible = stato
         ' Statistiche
         eui_cmdGestioneStatisticheRisorse.Visible = stato
         ' Archivi / Anagrafiche.
         eui_cmdArchiviAnagraficheRisorse.Visible = stato
         eui_cmdArchiviAnagraficheUtilizzoRisorse.Visible = stato
         ' Archivi / Tabelle.
         eui_cmdArchiviTabelleTipoRisorse.Visible = stato
         sepRisorse.Visible = stato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloEtichette(ByVal stato As Boolean)
      Try
         eui_GruppoEtichette.Visible = stato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloMagazzino(ByVal stato As Boolean)
      Try
         eui_Magazzino.Visible = stato
         eui_cmdArchiviTabelleUM.Visible = stato
         eui_cmdArchiviTabelleCategorieMerce.Visible = stato
         eui_cmdArchiviTabelleMagazzini.Visible = stato
         eui_cmdArchiviTabelleUbicazioni.Visible = stato
         eui_cmdArchiviTabelleScaffali.Visible = stato
         sepMagazzino.Visible = stato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloPalmari(ByVal stato As Boolean)
      Try
         ' Inserire qui eventuali istruzioni.
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloPrenOnLine(ByVal stato As Boolean)
      Try
         ' Inserire qui eventuali istruzioni.
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloPenDriveRecovery(ByVal stato As Boolean)
      Try
         ' Inserire qui eventuali istruzioni.
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloPenDrivePortable(ByVal stato As Boolean)
      Try
         ' Inserire qui eventuali istruzioni.
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloRegCassa(ByVal stato As Boolean)
      Try
         ' Inserire qui eventuali istruzioni.
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub AttivaDisattivaModuloFattElettronica(ByVal stato As Boolean)
      Try
         eui_Strumenti_Esporta_XML.Visible = stato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub VerificaVisibilitàGruppiModuli()
      Try
         ' Gruppo POS.
         If eui_cmdGestionePosCassa.Visible = False And eui_cmdGestionePosTavoli.Visible = False Then
            eui_GruppoPos.Visible = False
         Else
            eui_GruppoPos.Visible = True
         End If

         ' Gruppo Prenotazioni / Planning.
         If eui_ddwnGestionePlanningRisorse.Visible = False And eui_ddwnGestionePrenotazioni.Visible = False Then
            eui_GruppoPrenotazioni.Visible = False
         Else
            eui_GruppoPrenotazioni.Visible = True
         End If

         eui_Gestione.Refresh()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub VerificaAggiornamenti(ByVal msg As Boolean)
      Try
         If WebCommunication.VerificaConnessione = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            Dim percorsoFileRemoto As String = "Http://www.montanasoftware.it/Aggiornamenti.aspx"
            Dim percorsoFileLocale As String = Application.StartupPath & "\Dati\Aggiornamenti.dat"

            WebCommunication.LeggiFile(percorsoFileRemoto, percorsoFileLocale)

            If File.Exists(percorsoFileLocale) = True Then
               Dim valFile As String

               ' Crea o apre il file.
               FileOpen(1, percorsoFileLocale, OpenMode.Input)

               ' Legge il valore.
               Input(1, valFile)

               ' Chiude il file.
               FileClose(1)

               ' Se il file non contiene un valore numerico lo cancella.
               If IsNumeric(valFile) = False Then
                  File.Delete(percorsoFileLocale)
                  Exit Sub
               End If

               ' legge la versione installata.
               Dim valVersione As Integer = Convert.ToInt32(Application.ProductVersion.ToString.Replace(".", String.Empty))
               Dim valNuovaVersione As Integer = Convert.ToInt32(valFile.ToString.Replace(".", String.Empty))

               ' Verifica se la nuova versione è un aggiornamento.
               If valNuovaVersione > valVersione Then

                  ' Visualizza la versione del software sulla barra di stato.
                  eui_cmdNuovoAgg.Text = "Agg. Ver. " & valFile
                  eui_cmdNuovoAgg.ScreenTip.Text = "E' disponibile una nuova versione del software! Visita il sito Internet www.montanasoftware.it."

                  If msg = True Then
                     ' Modifica il cursore del mouse.
                     Cursor.Current = Cursors.Default

                     MessageBox.Show("E' disponibile una nuova versione del software!" & vbNewLine & vbNewLine &
                                     "Versione installata: " & Application.ProductVersion & vbNewLine & vbNewLine &
                                     "Versione aggiornamento: " & valFile & vbNewLine & vbNewLine &
                                     "E' possibile fare il download della nuova versione del programma dal sito Internet 'Http://www.montanasoftware.it'." & vbNewLine &
                                     "Per informazioni rivolgersi a: 'info@montanasoftware.it'", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  End If
               Else
                  ' Visualizza la versione del software sulla barra di stato.
                  eui_cmdNuovoAgg.Text = "Agg. Nessuno"
                  eui_cmdNuovoAgg.ScreenTip.Text = "Premi sul pulsante per verificare se ci sono aggiornamenti disponibili. Oppure visita il sito Internet www.montanasoftware.it."

                  If msg = True Then
                     ' Modifica il cursore del mouse.
                     Cursor.Current = Cursors.Default

                     MessageBox.Show("Non ci sono nuove versioni del software!" & vbNewLine & vbNewLine &
                                     "Per informazioni rivolgersi a: 'info@montanasoftware.it'", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  End If
               End If

               ' Cancella il file.
               File.Delete(percorsoFileLocale)

            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Public Sub VerificaLicenza(ByVal msg As Boolean)
      Try
         If WebCommunication.VerificaConnessione = True Then
            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            Dim hospitality As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY)

            Dim percorsoFileRemoto As String = "Http://www.montanasoftware.it/Licenze/" & hospitality & ".aspx"
            Dim percorsoFileLocale As String = Application.StartupPath & "\Dati\Licenza.dat"

            WebCommunication.LeggiFile(percorsoFileRemoto, percorsoFileLocale)

            If File.Exists(percorsoFileLocale) = True Then
               Dim valFile As String

               ' Crea o apre il file.
               FileOpen(1, percorsoFileLocale, OpenMode.Input)

               ' Legge il valore.
               Input(1, valFile)

               ' Chiude il file.
               FileClose(1)

               ' Legge il contenuto del file.
               Dim dataLicenza As String() = valFile.Split(" ")

               ' Se il file non contiene una data lo cancella.
               If IsDate(dataLicenza(0)) = False Then
                  File.Delete(percorsoFileLocale)

                  ' Visualizza i giorni rimanenti della Licenza sulla barra di stato.
                  eui_cmdLicenza.Text = 0

                  Exit Sub
               End If

               ' Legge le date di inizio e fine licenza.
               Dim dataInizio As Date = Convert.ToDateTime(dataLicenza(0))
               Dim dataFine As Date = Convert.ToDateTime(dataLicenza(1))

               ' Verifica se la data di licenza è scaduta.
               Dim numGiorniLicenza As Integer
               Dim valTempo As TimeSpan

               If dataFine.Date < Today.Date Then
                  numGiorniLicenza = 0

               ElseIf dataFine.Date >= Today.Date Then
                  valTempo = dataFine.Date - Today.Date
                  numGiorniLicenza = valTempo.Days
               End If

               ' Verifica se la Licenza è attiva.
               If numGiorniLicenza = 0 Then
                  msg = True

                  ' Visualizza i giorni rimanenti della Licenza sulla barra di stato.
                  eui_cmdLicenza.Text = numGiorniLicenza.ToString

                  If msg = True Then
                     ' Modifica il cursore del mouse.
                     Cursor.Current = Cursors.Default

                     MessageBox.Show("Servizio di assistenza: NON ATTIVO!" & vbNewLine & vbNewLine &
                                     "Data di inizio supporto: " & dataInizio.ToShortDateString & vbNewLine &
                                     "Data di fine supporto: " & dataFine.ToShortDateString & vbNewLine & vbNewLine &
                                     "Hai ancora a disposizione " & numGiorniLicenza.ToString & " giorni di assistenza." & vbNewLine & vbNewLine &
                                     "Il servizio di assistenza ti garantisce il supporto tecnico da parte di un operatore in caso di problemi che non ti consentano l'utilizzo del software." & vbNewLine &
                                     "Per informazioni rivolgersi a: 'info@montanasoftware.it'", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  End If
               Else
                  ' Visualizza i giorni rimanenti della Licenza sulla barra di stato.
                  eui_cmdLicenza.Text = numGiorniLicenza.ToString

                  If msg = True Then
                     ' Modifica il cursore del mouse.
                     Cursor.Current = Cursors.Default

                     MessageBox.Show("Servizio di assistenza: ATTIVO!" & vbNewLine & vbNewLine &
                                     "Data di inizio supporto: " & dataInizio.ToShortDateString & vbNewLine &
                                     "Data di fine supporto: " & dataFine.ToShortDateString & vbNewLine & vbNewLine &
                                     "Hai ancora a disposizione " & numGiorniLicenza.ToString & " giorni di assistenza." & vbNewLine &
                                     "Per informazioni rivolgersi a: 'info@montanasoftware.it'", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
                  End If
               End If

               ' Cancella il file.
               File.Delete(percorsoFileLocale)

            Else
               ' Se il file non esiste.

               ' Visualizza i giorni rimanenti della Licenza sulla barra di stato.
               eui_cmdLicenza.Text = 0
            End If
         End If

      Catch ex As System.Net.WebException
         ' Errore del server remoto: (404) Non trovato.
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   ' DA_FARE_B: Non funziona!!! - Versione che scrive sul server remoto -  NON UTILIZZATA.
   Public Sub ScriviDatiLicenza()
      Try
         If WebCommunication.VerificaConnessione = True Then

            Dim percorsoFileRemoto As String = "ftp: //ftp.montanasoftware.it/htdocs/www/" & GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY & ".dat")
            Dim percorsoFileLocale As String = Application.StartupPath & "\Dati\" & GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY & ".dat")

            DatiConfig = New AppConfig
            DatiConfig.ConfigType = ConfigFileType.AppConfig

            ' Crea o apre il file e registra i dati dell'errore.
            FileOpen(1, percorsoFileLocale, OpenMode.Output)

            WriteLine(1, Date.Now.ToString)
            WriteLine(1, String.Empty)
            WriteLine(1, GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY))
            WriteLine(1, GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_BAR))
            WriteLine(1, GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_RISTORANTE))
            WriteLine(1, GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PALMARI))
            WriteLine(1, GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PREN_ONLINE))
            WriteLine(1, GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_MAGAZZINO))
            WriteLine(1, GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_ETICHETTE))
            WriteLine(1, GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_PORTABLE))
            WriteLine(1, GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_RECOVERY))
            WriteLine(1, GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_REG_CASSA))
            WriteLine(1, String.Empty)
            WriteLine(1, DatiConfig.GetValue("RagioneSociale"))
            WriteLine(1, DatiConfig.GetValue("Nome"))
            WriteLine(1, DatiConfig.GetValue("Via"))
            WriteLine(1, DatiConfig.GetValue("Città"))
            WriteLine(1, DatiConfig.GetValue("Cap"))
            WriteLine(1, DatiConfig.GetValue("Provincia"))
            WriteLine(1, DatiConfig.GetValue("Telefono"))
            WriteLine(1, DatiConfig.GetValue("Fax"))
            WriteLine(1, DatiConfig.GetValue("Email"))
            WriteLine(1, DatiConfig.GetValue("Piva"))
            WriteLine(1, String.Empty)
            WriteLine(1, DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG))
            WriteLine(1, DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG))
            WriteLine(1, DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG))
            WriteLine(1, DatiConfig.GetValue(Modulo.NOME_PALMARI_CONFIG))
            WriteLine(1, DatiConfig.GetValue(Modulo.NOME_PREN_ONLINE_CONFIG))
            WriteLine(1, DatiConfig.GetValue(Modulo.NOME_MAGAZZINO_CONFIG))
            WriteLine(1, DatiConfig.GetValue(Modulo.NOME_ETICHETTE_CONFIG))
            WriteLine(1, DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG))
            WriteLine(1, DatiConfig.GetValue(Modulo.NOME_PENDRIVE_RECOVERY_CONFIG))
            WriteLine(1, DatiConfig.GetValue(Modulo.NOME_REG_CASSA_CONFIG))

            ' Chiude il file.
            FileClose(1)

            WebCommunication.ScriviFile("ftp://ftp.montanasoftware.it/", "luigim74@montanasoftware.it", "Lu200774lu_", percorsoFileRemoto, percorsoFileLocale)

            If File.Exists(percorsoFileLocale) = True Then
               File.Delete(percorsoFileLocale)
            End If

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub InviaDatiLicenza()
      Try
         If WebCommunication.VerificaConnessione = True Then

            DatiConfig = New AppConfig
            DatiConfig.ConfigType = ConfigFileType.AppConfig

            Dim versioneOS As String
            If Environment.Is64BitOperatingSystem = True Then
               versioneOS = "64 Bit"
            Else
               versioneOS = "32 Bit"
            End If

            Dim nomeMailServer As String = NOME_MAIL_SERVER_SMTP
            Dim eMailDestinatario As String = EMAIL_DATI_LICENZA_A

            Dim eMailMittente As String = DatiConfig.GetValue("Email")
            If eMailMittente.IsInterned("@") = "" Or eMailMittente = String.Empty Then
               eMailMittente = EMAIL_DATI_LICENZA_A
            End If

            Dim hospitality As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY)
            Dim bar As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_BAR)
            Dim ristorante As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_RISTORANTE)
            Dim centroSportivo As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_CENTRO_SPORTIVO)
            Dim hotel As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOTEL)
            Dim palmari As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PALMARI)
            Dim prenOnLine As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PREN_ONLINE)
            Dim magazzino As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_MAGAZZINO)
            Dim etichette As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_ETICHETTE)
            Dim penDrivePortable As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_PORTABLE)
            Dim penDriveRecovery As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_RECOVERY)
            Dim regCassa As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_REG_CASSA)
            Dim fattElettronica As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_FATT_ELETTRONICA)

            Dim oggetto As String = "HOSPITALITY SOLUTION 3 - " & GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY)

            Dim corpoMessaggio As String = "DATI UTENTE: " & vbNewLine & vbNewLine &
                                           "RAGIONE SOCIALE: " & DatiConfig.GetValue("RagioneSociale") & vbNewLine &
                                           "NOME E COGNOME: " & DatiConfig.GetValue("Nome") & vbNewLine &
                                           "VIA E NUMERO: " & DatiConfig.GetValue("Via") & vbNewLine &
                                           "CITTA': " & DatiConfig.GetValue("Città") & vbNewLine &
                                           "CAP: " & DatiConfig.GetValue("Cap") & vbNewLine &
                                           "PROVINCIA: " & DatiConfig.GetValue("Provincia") & vbNewLine &
                                           "TELEFONO: " & DatiConfig.GetValue("Telefono") & vbNewLine &
                                           "FAX: " & DatiConfig.GetValue("Fax") & vbNewLine &
                                           "E-MAIL: " & DatiConfig.GetValue("Email") & vbNewLine &
                                           "PARTITA IVA: " & DatiConfig.GetValue("Piva") & vbNewLine & vbNewLine &
                                           "DATI RIVENDITORE: " & vbNewLine & vbNewLine &
                                           "RAGIONE SOCIALE: " & DatiConfig.GetValue("RagioneSocialeRiv") & vbNewLine &
                                           "NOME E COGNOME: " & DatiConfig.GetValue("NomeRiv") & vbNewLine &
                                           "TELEFONO: " & DatiConfig.GetValue("TelefonoRiv") & vbNewLine &
                                           "E-MAIL: " & DatiConfig.GetValue("EmailRiv") & vbNewLine &
                                           "PARTITA IVA: " & DatiConfig.GetValue("PivaRiv") & vbNewLine & vbNewLine &
                                           "NUMERO DI SERIE: " & NUMERO_SERIE & vbNewLine &
                                           "VERSIONE PRODOTTO: " & FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).ProductVersion & vbNewLine & vbNewLine &
                                           "MODULI ATTIVI: " & vbNewLine &
                                           "MODULO HOSPITALITY: " & DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG) & vbNewLine &
                                           "MODULO BAR: " & DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG) & vbNewLine &
                                           "MODULO RISTORANTE: " & DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG) & vbNewLine &
                                           "MODULO CENTRO SPORTIVO: " & DatiConfig.GetValue(Modulo.NOME_SPORTING_CONFIG) & vbNewLine &
                                           "MODULO HOTEL: " & DatiConfig.GetValue(Modulo.NOME_HOTEL_CONFIG) & vbNewLine &
                                           "MODULO PALMARI: " & DatiConfig.GetValue(Modulo.NOME_PALMARI_CONFIG) & vbNewLine &
                                           "MODULO PRENOTAZIONI ON-LINE: " & DatiConfig.GetValue(Modulo.NOME_PREN_ONLINE_CONFIG) & vbNewLine &
                                           "MODULO MAGAZZINO: " & DatiConfig.GetValue(Modulo.NOME_MAGAZZINO_CONFIG) & vbNewLine &
                                           "MODULO ETICHETTE: " & DatiConfig.GetValue(Modulo.NOME_ETICHETTE_CONFIG) & vbNewLine &
                                           "MODULO PENDRIVE PORTABLE: " & DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) & vbNewLine &
                                           "MODULO PENDRIVE RECOVERY: " & DatiConfig.GetValue(Modulo.NOME_PENDRIVE_RECOVERY_CONFIG) & vbNewLine &
                                           "MODULO REGISTRATORI DI CASSA: " & DatiConfig.GetValue(Modulo.NOME_REG_CASSA_CONFIG) & vbNewLine &
                                           "MODULO FATTURAZIONE ELETTRONICA: " & DatiConfig.GetValue(Modulo.NOME_FATT_ELETTRONICA_CONFIG) & vbNewLine & vbNewLine &
                                           "INFORMAZIONI DI SISTEMA: " & vbNewLine &
                                           "SISTEMA OPERATIVO: " & My.Computer.Info.OSFullName & " (" & versioneOS & ") - " & My.Computer.Info.OSVersion & " - " & My.Computer.Info.OSPlatform & vbNewLine

            '"CODICI DI ATTIVAZIONE: " & vbNewLine &
            '"CHIAVE MODULO HOSPITALITY: " & hospitality & vbNewLine &
            '"CHIAVE MODULO BAR: " & bar & vbNewLine &
            '"CHIAVE MODULO RISTORANTE: " & ristorante & vbNewLine &
            '"CHIAVE MODULO CENTRO SPORTIVO: " & centroSportivo & vbNewLine &
            '"CHIAVE MODULO HOTEL: " & hotel & vbNewLine &
            '"CHIAVE MODULO PALMARI: " & palmari & vbNewLine &
            '"CHIAVE MODULO PRENOTAZIONI ON-LINE: " & prenOnLine & vbNewLine &
            '"CHIAVE MODULO MAGAZZINO: " & magazzino & vbNewLine &
            '"CHIAVE MODULO ETICHETTE: " & etichette & vbNewLine &
            '"CHIAVE MODULO PENDRIVE PORTABLE: " & penDrivePortable & vbNewLine &
            '"CHIAVE MODULO PENDRIVE RECOVERY: " & penDriveRecovery & vbNewLine &
            '"CHIAVE MODULO REGISTRATORI DI CASSA: " & regCassa & vbNewLine &
            '"CHIAVE MODULO FATTURAZIONE ELETTRONICA: " & fattElettronica & vbNewLine & vbNewLine &

            Dim messaggio As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(eMailMittente, eMailDestinatario)
            messaggio.Subject = oggetto
            messaggio.Body = corpoMessaggio

            Dim smtp As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient(nomeMailServer, 25)

            smtp.Credentials = New System.Net.NetworkCredential(USER_NAME_MAIL_SERVER_SMTP, PWD_MAIL_SERVER_SMTP)

            smtp.Send(messaggio)

         End If

      Catch ex As Exception

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         'err.GestisciErrore(ex.StackTrace, ex.Message)
         Exit Sub
      End Try
   End Sub

   Public Sub InviaDatiGiudizio(ByVal votoSemplicità As Decimal, ByVal votoUtilità As Decimal, ByVal votoGrafica As Decimal, ByVal commento As String)
      Try
         If WebCommunication.VerificaConnessione = True Then

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.AppStarting

            DatiConfig = New AppConfig
            DatiConfig.ConfigType = ConfigFileType.AppConfig

            Dim versioneOS As String
            If Environment.Is64BitOperatingSystem = True Then
               versioneOS = "64 Bit"
            Else
               versioneOS = "32 Bit"
            End If

            Dim nomeMailServer As String = NOME_MAIL_SERVER_SMTP
            Dim eMailDestinatario As String = EMAIL_DATI_LICENZA_A

            Dim eMailMittente As String = DatiConfig.GetValue("Email")
            If eMailMittente.IsInterned("@") = "" Or eMailMittente = String.Empty Then
               eMailMittente = EMAIL_DATI_LICENZA_A
            End If

            Dim hospitality As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY)

            Dim oggetto As String = "HOSPITALITY SOLUTION 3 - GIUDIZIO DEMO - " & GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY)

            Dim corpoMessaggio As String = "DATI UTENTE: " & vbNewLine & vbNewLine &
                                           "RAGIONE SOCIALE: " & DatiConfig.GetValue("RagioneSociale") & vbNewLine &
                                           "NOME E COGNOME: " & DatiConfig.GetValue("Nome") & vbNewLine &
                                           "VIA E NUMERO: " & DatiConfig.GetValue("Via") & vbNewLine &
                                           "CITTA': " & DatiConfig.GetValue("Città") & vbNewLine &
                                           "CAP: " & DatiConfig.GetValue("Cap") & vbNewLine &
                                           "PROVINCIA: " & DatiConfig.GetValue("Provincia") & vbNewLine &
                                           "TELEFONO: " & DatiConfig.GetValue("Telefono") & vbNewLine &
                                           "FAX: " & DatiConfig.GetValue("Fax") & vbNewLine &
                                           "E-MAIL: " & DatiConfig.GetValue("Email") & vbNewLine &
                                           "PARTITA IVA: " & DatiConfig.GetValue("Piva") & vbNewLine & vbNewLine &
                                           "DATI RIVENDITORE: " & vbNewLine & vbNewLine &
                                           "RAGIONE SOCIALE: " & DatiConfig.GetValue("RagioneSocialeRiv") & vbNewLine &
                                           "NOME E COGNOME: " & DatiConfig.GetValue("NomeRiv") & vbNewLine &
                                           "TELEFONO: " & DatiConfig.GetValue("TelefonoRiv") & vbNewLine &
                                           "E-MAIL: " & DatiConfig.GetValue("EmailRiv") & vbNewLine &
                                           "PARTITA IVA: " & DatiConfig.GetValue("PivaRiv") & vbNewLine & vbNewLine &
                                           "NUMERO DI SERIE: " & NUMERO_SERIE & vbNewLine &
                                           "VERSIONE PRODOTTO: " & FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).ProductVersion & vbNewLine & vbNewLine &
                                           "VALORI GIUDIZIO: " & vbNewLine &
                                           "SEMPLICITA': " & votoSemplicità.ToString & vbNewLine &
                                           "UTILITA': " & votoUtilità.ToString & vbNewLine &
                                           "GRAFICA: " & votoGrafica.ToString & vbNewLine &
                                           "COMMENTO: " & commento & vbNewLine & vbNewLine &
                                           "INFORMAZIONI DI SISTEMA: " & vbNewLine &
                                           "SISTEMA OPERATIVO: " & My.Computer.Info.OSFullName & " (" & versioneOS & ") - " & My.Computer.Info.OSVersion & " - " & My.Computer.Info.OSPlatform & vbNewLine

            Dim messaggio As System.Net.Mail.MailMessage = New System.Net.Mail.MailMessage(eMailMittente, eMailDestinatario)
            messaggio.Subject = oggetto
            messaggio.Body = corpoMessaggio

            Dim smtp As System.Net.Mail.SmtpClient = New System.Net.Mail.SmtpClient(nomeMailServer, 25)

            smtp.Credentials = New System.Net.NetworkCredential(USER_NAME_MAIL_SERVER_SMTP, PWD_MAIL_SERVER_SMTP)

            smtp.Send(messaggio)

            ' Modifica il cursore del mouse.
            Cursor.Current = Cursors.Default

            MessageBox.Show("Il tuo giudizio è stato inviato con successo! Ti ringraziamo per avere provato il nostro software.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Exit Sub
      End Try
   End Sub

#Region "Hotel - Prenotazione PDF "

   Public Function LeggiLogoAzienda() As String
      Try
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)

         With AAzienda

            .LeggiDati(NOME_TABELLA_AZIENDA)

            Return .PercorsoImg

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function LeggiRagSocialeAzienda() As String
      Try
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)

         With AAzienda

            .LeggiDati(NOME_TABELLA_AZIENDA)

            Return .RagSociale

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function LeggiIndirizzoAzienda() As String
      Try
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)

         With AAzienda

            .LeggiDati(NOME_TABELLA_AZIENDA)

            Return .Indirizzo

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function LeggiCapAzienda() As String
      Try
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)

         With AAzienda

            .LeggiDati(NOME_TABELLA_AZIENDA)

            Return .Cap & " " & .Città & " " & .Provincia

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function LeggiPivaAzienda() As String
      Try
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)

         With AAzienda

            .LeggiDati(NOME_TABELLA_AZIENDA)

            Return "P. Iva: " & .Piva

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function LeggiTelFaxAzienda() As String
      Try
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)

         With AAzienda

            .LeggiDati(NOME_TABELLA_AZIENDA)

            Return "Tel: " & .Telefono & " Fax: " & .Fax

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function LeggiEmailAzienda() As String
      Try
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)

         With AAzienda

            .LeggiDati(NOME_TABELLA_AZIENDA)

            Return .Email

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Public Function LeggiEmailMittente() As String
      Try
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)

         With AAzienda

            .LeggiDati(NOME_TABELLA_AZIENDA)

            If .Email.IsInterned("@") = String.Empty Then
               Return String.Empty
            Else
               Return .Email
            End If

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Public Function LeggiPECMittente() As String
      Try
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)

         With AAzienda

            .LeggiDati(NOME_TABELLA_AZIENDA)

            If .PEC.IsInterned("@") = String.Empty Then
               Return String.Empty
            Else
               Return .PEC
            End If

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiEmailDestinatario() As String
      Try
         Dim idCliente As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ID_CLIENTE)

         Dim AClienti As New Anagrafiche.Cliente(ConnStringAnagrafiche)

         With AClienti

            .LeggiDati(NOME_TABELLA_CLIENTI, idCliente)

            If .Email.IsInterned("@") = String.Empty Then
               Return String.Empty
            Else
               Return .Email
            End If

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiNomeCompletoDestinatario() As String
      Try
         Dim idCliente As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ID_CLIENTE)

         Dim AClienti As New Anagrafiche.Cliente(ConnStringAnagrafiche)

         With AClienti

            .LeggiDati(NOME_TABELLA_CLIENTI, idCliente)

            Return .Nome & " " & .Cognome

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiNomeDestinatario() As String
      Try
         Dim idCliente As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ID_CLIENTE)

         Dim AClienti As New Anagrafiche.Cliente(ConnStringAnagrafiche)

         With AClienti

            .LeggiDati(NOME_TABELLA_CLIENTI, idCliente)

            Return .Nome

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiCognomeDestinatario() As String
      Try
         Dim idCliente As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ID_CLIENTE)

         Dim AClienti As New Anagrafiche.Cliente(ConnStringAnagrafiche)

         With AClienti

            .LeggiDati(NOME_TABELLA_CLIENTI, idCliente)

            Return .Cognome

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiIdCliente() As String
      Try
         Dim idCliente As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ID_CLIENTE)

         Return idCliente

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiNumPrenotazione() As String
      Try
         Dim numPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NUMERO_PREN)

         Return numPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiDataPrenotazione(ByVal dataLunga As Boolean) As String
      Try
         Dim dataPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_DATA)
         Dim data As Date

         If dataLunga = True Then
            If IsDate(dataPren) = True Then
               data = Convert.ToDateTime(dataPren)
               dataPren = data.ToLongDateString
            Else
               dataPren = String.Empty
            End If

         End If

         Return dataPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiArrivoPrenotazione(ByVal dataLunga As Boolean) As String
      Try
         Dim arrivoPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_DATA_ARRIVO)
         Dim data As Date

         If dataLunga = True Then
            If IsDate(arrivoPren) = True Then
               data = Convert.ToDateTime(arrivoPren)
               arrivoPren = data.ToLongDateString
            Else
               arrivoPren = String.Empty
            End If
         End If

         Return arrivoPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiPartenzaPrenotazione(ByVal dataLunga As Boolean) As String
      Try
         Dim partenzaPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_DATA_PARTENZA)
         Dim data As Date

         If dataLunga = True Then
            If IsDate(partenzaPren) = True Then
               data = Convert.ToDateTime(partenzaPren)
               partenzaPren = data.ToLongDateString
            Else
               partenzaPren = String.Empty
            End If
         End If

         Return partenzaPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiNottiPrenotazione() As String
      Try
         Dim partenzaPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NOTTI)

         Return partenzaPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiAdultiPrenotazione() As String
      Try
         Dim adultiPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ADULTI)

         Return adultiPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiNeonatiPrenotazione() As String
      Try
         Dim NeonatiPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NEONATI)

         Return NeonatiPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiBambiniPrenotazione() As String
      Try
         Dim BambiniPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_BAMBINI)

         Return BambiniPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiRagazziPrenotazione() As String
      Try
         Dim RagazziPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_RAGAZZI)

         Return RagazziPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiNumCameraPrenotazione() As String
      Try
         Dim numCameraPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NUM_CAMERA)

         Return numCameraPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiTipoCameraPrenotazione() As String
      Try
         Dim tipoCameraPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_TIPO_CAMERA)

         Return tipoCameraPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiArrangiamentoPrenotazione() As String
      Try
         Dim arrangiamentoPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ARRANGIAMENTO)

         Return arrangiamentoPren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiTotaleImportoPrenotazione() As String
      Try
         Dim totalePren As Double

         If IsNumeric(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_IMPORTO_TOTALE)) = True Then
            totalePren = Convert.ToDouble(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_IMPORTO_TOTALE))
         Else
            totalePren = 0
         End If

         Return CFormatta.FormattaNumeroDouble(totalePren)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiAccontoPrenotazione() As String
      Try
         Dim accontoPren As Double

         If IsNumeric(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ACCONTO)) = True Then
            accontoPren = Convert.ToDouble(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ACCONTO))
         Else
            accontoPren = 0
         End If

         Return CFormatta.FormattaNumeroDouble(accontoPren)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiSaldoPrenotazione() As String
      Try
         Dim totalePren As Double
         Dim accontoPren As Double
         Dim saldoPren As Double

         If IsNumeric(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_IMPORTO_TOTALE)) = True Then
            totalePren = Convert.ToDouble(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_IMPORTO_TOTALE))
         Else
            totalePren = 0
         End If

         If IsNumeric(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ACCONTO)) = True Then
            accontoPren = Convert.ToDouble(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ACCONTO))
         Else
            accontoPren = 0
         End If

         saldoPren = totalePren - accontoPren

         Return CFormatta.FormattaNumeroDouble(saldoPren)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiNotePrenotazione() As String
      Try
         Dim notePren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NOTE)

         Return notePren

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiDatiRiepilogoPrenotazione() As String
      Try
         Dim numPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NUMERO_PREN)
         Dim dataPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_DATA)
         Dim strOggetto As String = "Riepilogo Prenotazione N. " & numPren & " del " & dataPren

         Return strOggetto

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiDatiAccontoPrenotazione() As String
      Try
         Dim numPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NUMERO_PREN)
         Dim dataPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_DATA)
         Dim strOggetto As String = "Ricevuta per Acconto - (Prenotazione N. " & numPren & " del " & dataPren & ")"

         Return strOggetto

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function LeggiDatiCaparraPrenotazione() As String
      Try
         Dim numPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NUMERO_PREN)
         Dim dataPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_DATA)
         Dim strOggetto As String = "Ricevuta per Caparra confirmatoria - (Prenotazione N. " & numPren & " del " & dataPren & ")"

         Return strOggetto

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Function CreaMessaggio() As String
      Try
         Dim AAzienda As New Anagrafiche.Azienda(ConnString)

         With AAzienda
            .LeggiDati(NOME_TABELLA_AZIENDA)

            Dim messaggio As String = "Gentile " & LeggiNomeCompletoDestinatario() & "," & vbNewLine & vbNewLine &
                                      "Alleghiamo alla presente il documento in oggetto." & vbNewLine &
                                      "Con l'occasione, porgiamo distinti saluti." & vbNewLine & vbNewLine &
                                      .RagSociale & vbNewLine & vbNewLine &
                                      "Telefono: " & .Telefono & vbNewLine &
                                      "Internet: " & .Internet
            Return messaggio

         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

#End Region

   Private Sub CaricaInfoProdottiAttivi()

      ' Pulisce la lista.
      eui_lstProdottiAttivati.Items.Clear()

      ' HOSPITALITY.
      If moduloAttivo.Hospitality = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_HOSPITALITY_CONFIG))
         Dim item As String = Modulo.NOME_HOSPITALITY & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' MAGAZZINO.
      If moduloAttivo.Magazzino = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_MAGAZZINO_CONFIG))
         Dim item As String = Modulo.NOME_MAGAZZINO & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' ETICHETTE.
      If moduloAttivo.Etichette = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_ETICHETTE_CONFIG))
         Dim item As String = Modulo.NOME_ETICHETTE & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' PENDRIVE PORTABLE.
      If moduloAttivo.PenDrivePortable = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG))
         Dim item As String = Modulo.NOME_PENDRIVE_PORTABLE & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' PENDRIVE RECOVERY.
      If moduloAttivo.PenDriveRecovery = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_PENDRIVE_RECOVERY_CONFIG))
         Dim item As String = Modulo.NOME_PENDRIVE_RECOVERY & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' REGISTRATORI DI CASSA.
      If moduloAttivo.RegCassa = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_REG_CASSA_CONFIG))
         Dim item As String = Modulo.NOME_REG_CASSA & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' FATTURAZIONE ELETTRONICA.
      If moduloAttivo.FattElettronica = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_FATT_ELETTRONICA_CONFIG))
         Dim item As String = Modulo.NOME_FATT_ELETTRONICA & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' BAR.
      If moduloAttivo.Bar = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_BAR_CONFIG))
         Dim item As String = Modulo.NOME_BAR & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' RISTORANTE.
      If moduloAttivo.Ristorante = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG))
         Dim item As String = Modulo.NOME_CHEF & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' PALMARI.
      If moduloAttivo.Palmari = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_PALMARI_CONFIG))
         Dim item As String = Modulo.NOME_PALMARI & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' PRENOTAZIONI ON-LINE.
      If moduloAttivo.PrenOnLine = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_PREN_ONLINE_CONFIG))
         Dim item As String = Modulo.NOME_PREN_ONLINE & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' CENTRO SPORTIVO.
      If moduloAttivo.CentroSportivo = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_SPORTING_CONFIG))
         Dim item As String = Modulo.NOME_SPORTING & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' HOTEL.
      If moduloAttivo.Hotel = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_HOTEL_CONFIG))
         Dim item As String = Modulo.NOME_HOTEL & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' CAMPEGGIO.
      If moduloAttivo.Campeggio = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_CAMPING_CONFIG))
         Dim item As String = Modulo.NOME_CAMPING & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' CENTRO BALNEARE.
      If moduloAttivo.CentroBalneare = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_BEACH_CONFIG))
         Dim item As String = Modulo.NOME_BEACH & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' CENTRO BENESSERE.
      If moduloAttivo.CentroBenessere = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_BEAUTY_CONFIG))
         Dim item As String = Modulo.NOME_BEAUTY & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' VENDITA AL DETTAGLIO.
      If moduloAttivo.VenditaDettaglio = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_RETAIL_CONFIG))
         Dim item As String = Modulo.NOME_RETAIL & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' TAGLIE E COLORI.
      If moduloAttivo.TaglieColori = True Then
         Dim codice As String = CodAttivazioneInserisciTrattini(DatiConfig.GetValue(Modulo.NOME_TAGLIE_COLORI_CONFIG))
         Dim item As String = Modulo.NOME_TAGLIE_COLORI & " - " & codice
         eui_lstProdottiAttivati.Items.Add(item)
      End If

      ' Visualizza o nasconde l'etichetta Versione dimostrativa.
      If eui_lstProdottiAttivati.Items.Count <> 0 Then
         lblDemo.Visible = False
         lblGiorniProva.Visible = False
      End If
   End Sub

   Private Sub VisualizzaInfoProdottiAttivi()
      Dim item As String = eui_lstProdottiAttivati.SelectedItem

      ' Pulisce la casella di testo.
      eui_txtDettagliProdotto.Text = String.Empty

      ' HOSPITALITY.
      If item.Contains(Modulo.NOME_HOSPITALITY) = True Then
         eui_txtDettagliProdotto.Text = "Software per strutture turistiche composto da moduli specifici per soddisfare le esigenze di ogni singola attività." &
                                        "Bar, Ristorante, Centro sportivo, Hotel, Campeggio, Centro balneare, Centro benessere e Vendita al detaglio."
      End If

      ' MAGAZZINO.
      If item.Contains(Modulo.NOME_MAGAZZINO) = True Then
         eui_txtDettagliProdotto.Text = "Modulo per la gestione del magazzino."
      End If

      ' ETICHETTE.
      If item.Contains(Modulo.NOME_ETICHETTE) = True Then
         eui_txtDettagliProdotto.Text = "Modulo per la gestione di etichette indirizzi e codici a barre."
      End If

      ' PENDRIVE PORTABLE.
      If item.Contains(Modulo.NOME_PENDRIVE_PORTABLE) = True Then
         eui_txtDettagliProdotto.Text = "Modulo per l'installazione del software su memoria esterna."
      End If

      ' PENDRIVE RECOVERY.
      If item.Contains(Modulo.NOME_PENDRIVE_RECOVERY) = True Then
         eui_txtDettagliProdotto.Text = "Modulo per il salvataggio e recupero automatico dei dati del software."
      End If

      ' REGISTRATORI DI CASSA.
      If item.Contains(Modulo.NOME_REG_CASSA) = True Then
         eui_txtDettagliProdotto.Text = "Modulo per il collegamento ai registratori di cassa e stampanti fiscali."
      End If

      ' FATTURAZIONE ELETTRONICA.
      If item.Contains(Modulo.NOME_FATT_ELETTRONICA) = True Then
         eui_txtDettagliProdotto.Text = "Modulo per la Fatturazione Elettronica."
      End If

      ' BAR.
      If item.Contains(Modulo.NOME_BAR) = True Then
         eui_txtDettagliProdotto.Text = "Software per Bar, Gelaterie e tutte quelle attività che non necessitano di una gestione dei tavoli."
      End If

      ' RISTORANTE.
      If item.Contains(Modulo.NOME_CHEF) = True Then
         eui_txtDettagliProdotto.Text = "Software per strutture ristorative (Ristoranti, Pizzerie, ecc.) che necessitano della gestione dei tavoli."
      End If

      ' PALMARI.
      If item.Contains(Modulo.NOME_PALMARI) = True Then
         eui_txtDettagliProdotto.Text = "Modulo per la gestione dei palmari per la presa delle comande ai tavoli."
      End If

      ' PRENOTAZIONI ON-LINE.
      If item.Contains(Modulo.NOME_PREN_ONLINE) = True Then
         eui_txtDettagliProdotto.Text = "Modulo per la prenotazione dei tavoli tramite Internet da Pc, Tablet, SmartPhone."
      End If

      ' CENTRO SPORTIVO.
      If item.Contains(Modulo.NOME_SPORTING) = True Then
         eui_txtDettagliProdotto.Text = "Software per centri sportivi per la gestione di prenotazioni con tipologie diverse di risorse. Campi da tennis, da calcio, Piscina ecc"
      End If

      ' HOTEL.
      If item.Contains(Modulo.NOME_HOTEL) = True Then
         eui_txtDettagliProdotto.Text = "Software per Hotel."
      End If

      ' CAMPEGGIO.
      If item.Contains(Modulo.NOME_CAMPING) = True Then
         eui_txtDettagliProdotto.Text = "Software per campeggi"
      End If

      ' CENTRO BALNEARE.
      If item.Contains(Modulo.NOME_BEACH) = True Then
         eui_txtDettagliProdotto.Text = "Software per centri balneari"
      End If

      ' CENTRO BENESSERE.
      If item.Contains(Modulo.NOME_BEAUTY) = True Then
         eui_txtDettagliProdotto.Text = "Software per centri benessere."
      End If

      ' VENDITA AL DETTAGLIO.
      If item.Contains(Modulo.NOME_RETAIL) = True Then
         eui_txtDettagliProdotto.Text = "Software per Negozi di vendita al dettaglio."
      End If

      ' TAGLIE E COLORI.
      If item.Contains(Modulo.NOME_TAGLIE_COLORI) = True Then
         eui_txtDettagliProdotto.Text = "Modulo per la gestione delle taglie e colori."
      End If

   End Sub

   Private Sub lvwGestioneModuli_GotFocus(sender As Object, e As System.EventArgs) Handles lvwGestioneModuli.GotFocus
      impostaListaModuli = False
   End Sub

   Private Sub lvwGestioneModuli_ItemChecked(sender As Object, e As System.Windows.Forms.ItemCheckedEventArgs) Handles lvwGestioneModuli.ItemChecked
      Try
         ' Se è in corso l'impostazione dei dati nella lista non esegue l'attivazione dei moduli.
         If impostaListaModuli = True Then
            Exit Sub
         End If

         ' ATTIVA IL MODULO.
         If e.Item.Checked = True Then
            ' Verifica la presenza della chiave di attivazione.
            DatiConfig = New AppConfig
            DatiConfig.ConfigType = ConfigFileType.AppConfig

            Select Case e.Item.Text

               Case Modulo.NOME_CAMPING, Modulo.NOME_BEACH, Modulo.NOME_BEAUTY, Modulo.NOME_RETAIL
                  ' Moduli non disponibili.
                  MessageBox.Show(MSG_PRODOTTO_NON_DISPONIBILE, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  e.Item.Checked = False
                  Exit Sub

               Case Modulo.NOME_MAGAZZINO, Modulo.NOME_ETICHETTE, Modulo.NOME_PENDRIVE_PORTABLE, Modulo.NOME_PENDRIVE_RECOVERY, Modulo.NOME_REG_CASSA, Modulo.NOME_FATT_ELETTRONICA
                  ' Sotto moduli per tutti i Prodotti.
                  If VerificaProdottoAttivo() = False Then
                     MessageBox.Show(MSG_ATTIVARE_UN_PRODOTTO, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                     e.Item.Checked = False
                     Exit Sub
                  End If

               Case Modulo.NOME_PALMARI, Modulo.NOME_PREN_ONLINE
                  ' Sotto moduli per Ristorante.
                  If DatiConfig.GetValue(Modulo.NOME_CHEF_CONFIG) = String.Empty Then
                     MessageBox.Show(MSG_ATTIVARE_IL_PRODOTTO & Modulo.NOME_CHEF, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                     e.Item.Checked = False
                     Exit Sub
                  End If

               Case Modulo.NOME_TAGLIE_COLORI
                  ' Sotto moduli per la Vendita al dettaglio.
                  If DatiConfig.GetValue(Modulo.NOME_RETAIL_CONFIG) = String.Empty Then
                     MessageBox.Show(MSG_ATTIVARE_IL_PRODOTTO & Modulo.NOME_RETAIL, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                     e.Item.Checked = False
                     Exit Sub
                  End If

            End Select

            ' Se non esiste un codice di attivazione apre la finestra per l'inserimento della chiave.
            If e.Item.SubItems(2).Text = String.Empty Then
               Dim frm As New CodAccesso
               ' Passa il nome del modulo alla finestra.
               frm.Tag = e.Item.Text
               frm.ShowDialog()

               ' Se non viene attivato rimuove l'impostazione.
               If frm.DialogResult = DialogResult.Cancel Then
                  e.Item.Checked = False

               ElseIf frm.DialogResult = DialogResult.OK Then
                  ' Messaggio sulla barra di stato.
                  eui_Informazioni.Text = "Caricamento Moduli in corso..."

                  Select Case e.Item.Text
                     Case Modulo.NOME_HOSPITALITY
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOSPITALITY, "-")
                        e.Item.SubItems(3).ForeColor = Color.MidnightBlue

                        ' Attiva anche il modulo Hotel.
                        If moduloAttivo.Hotel = False Then
                           Dim chiaveAttivazioneHotel As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOTEL)
                           DatiConfig.SetValue(Modulo.NOME_HOTEL_CONFIG, chiaveAttivazioneHotel)
                           moduloAttivo.Hotel = True
                           ImpostaDatiListaModuli(Modulo.NOME_HOTEL, CHIAVE_ATTIVAZIONE_HOTEL, Color.Brown, True)
                        End If

                        ' Attiva anche il modulo Bar.
                        If moduloAttivo.Bar = False Then
                           Dim chiaveAttivazioneBar As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_BAR)
                           DatiConfig.SetValue(Modulo.NOME_BAR_CONFIG, chiaveAttivazioneBar)
                           moduloAttivo.Bar = True
                           ImpostaDatiListaModuli(Modulo.NOME_BAR, CHIAVE_ATTIVAZIONE_BAR, Color.Green, True)
                        End If

                        ' Attiva anche il modulo Ristorante.
                        If moduloAttivo.Ristorante = False Then
                           Dim chiaveAttivazioneRistorante As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_RISTORANTE)
                           DatiConfig.SetValue(Modulo.NOME_CHEF_CONFIG, chiaveAttivazioneRistorante)
                           moduloAttivo.Ristorante = True
                           ImpostaDatiListaModuli(Modulo.NOME_CHEF, CHIAVE_ATTIVAZIONE_RISTORANTE, Color.Green, True)
                        End If

                        ' Attiva anche il modulo Centro Sportivo.
                        If moduloAttivo.CentroSportivo = False Then
                           Dim chiaveAttivazioneCentroSportivo As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_CENTRO_SPORTIVO)
                           DatiConfig.SetValue(Modulo.NOME_SPORTING_CONFIG, chiaveAttivazioneCentroSportivo)
                           moduloAttivo.CentroSportivo = True
                           ImpostaDatiListaModuli(Modulo.NOME_SPORTING, CHIAVE_ATTIVAZIONE_CENTRO_SPORTIVO, Color.DarkCyan, True)
                        End If

                     Case Modulo.NOME_HOTEL
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_HOTEL, "-")
                        e.Item.SubItems(3).ForeColor = Color.Brown

                     Case Modulo.NOME_BAR
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_BAR, "-")
                        e.Item.SubItems(3).ForeColor = Color.Green

                     Case Modulo.NOME_CHEF
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_RISTORANTE, "-")
                        e.Item.SubItems(3).ForeColor = Color.Green

                        ' Attivando il modulo Ristorante viene attivato anche il modulo Bar.
                        If moduloAttivo.Bar = False Then
                           Dim chiaveAttivazioneBar As String = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_BAR)
                           DatiConfig.SetValue(Modulo.NOME_BAR_CONFIG, chiaveAttivazioneBar)
                           moduloAttivo.Bar = True
                           ImpostaDatiListaModuli(Modulo.NOME_BAR, CHIAVE_ATTIVAZIONE_BAR, Color.Green, True)
                        End If

                     Case Modulo.NOME_SPORTING
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_CENTRO_SPORTIVO, "-")
                        e.Item.SubItems(3).ForeColor = Color.DarkCyan

                     Case Modulo.NOME_PALMARI
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PALMARI, "-")
                        e.Item.SubItems(3).ForeColor = Color.Green

                     Case Modulo.NOME_PREN_ONLINE
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PREN_ONLINE, "-")
                        e.Item.SubItems(3).ForeColor = Color.Green

                     Case Modulo.NOME_MAGAZZINO
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_MAGAZZINO, "-")
                        e.Item.SubItems(3).ForeColor = Color.MidnightBlue

                     Case Modulo.NOME_ETICHETTE
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_ETICHETTE, "-")
                        e.Item.SubItems(3).ForeColor = Color.MidnightBlue

                     Case Modulo.NOME_PENDRIVE_RECOVERY
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_RECOVERY, "-")
                        e.Item.SubItems(3).ForeColor = Color.MidnightBlue

                     Case Modulo.NOME_PENDRIVE_PORTABLE
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_PENDRIVE_PORTABLE, "-")
                        e.Item.SubItems(3).ForeColor = Color.MidnightBlue

                     Case Modulo.NOME_REG_CASSA
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_REG_CASSA, "-")
                        e.Item.SubItems(3).ForeColor = Color.MidnightBlue

                     Case Modulo.NOME_FATT_ELETTRONICA
                        e.Item.SubItems(2).Text = GeneraChiaveLicenza(CHIAVE_ATTIVAZIONE_FATT_ELETTRONICA, "-")
                        e.Item.SubItems(3).ForeColor = Color.MidnightBlue

                  End Select

                  e.Item.SubItems(3).Text = "ATTIVO"

                  ' Attiva disattiva tutte le funzionalità del software.
                  ImpostaModuli()

                  ' Messaggio sulla barra di stato.
                  eui_Informazioni.Text = LeggiDatiRivenditore()

                  g_VerDemo = False
               End If
            End If

         Else

            ' DISATTIVA IL MODULO.
            If e.Item.SubItems(2).Text = String.Empty Then
               Exit Sub
            End If

            Dim risposta As DialogResult
            risposta = MessageBox.Show(MSG_DISATTIVA_PRODOTTO, NOME_PRODOTTO, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)

            If risposta = Windows.Forms.DialogResult.No Then
               e.Item.Checked = True
               Exit Sub
            Else
               ' Messaggio sulla barra di stato.
               eui_Informazioni.Text = "Rimozione Moduli in corso..."

               Select Case e.Item.Text
                  Case Modulo.NOME_HOSPITALITY
                     If DisattivaProdotto(Modulo.NOME_HOSPITALITY_CONFIG) = True Then

                        If moduloAttivo.Hotel = True Then
                           If DisattivaProdotto(Modulo.NOME_HOTEL_CONFIG) = True Then
                              ImpostaDatiListaModuli(Modulo.NOME_HOTEL, "", Color.Gray, False)
                           End If
                        End If

                        If moduloAttivo.Bar = True Then
                           If DisattivaProdotto(Modulo.NOME_BAR_CONFIG) = True Then
                              ImpostaDatiListaModuli(Modulo.NOME_BAR, "", Color.Gray, False)
                           End If
                        End If

                        If moduloAttivo.Ristorante = True Then
                           If DisattivaProdotto(Modulo.NOME_CHEF_CONFIG) = True Then
                              ImpostaDatiListaModuli(Modulo.NOME_CHEF, "", Color.Gray, False)
                           End If
                        End If
                        If moduloAttivo.Palmari = True Then
                           If DisattivaProdotto(Modulo.NOME_PALMARI_CONFIG) = True Then
                              ImpostaDatiListaModuli(Modulo.NOME_PALMARI, "", Color.Gray, False)
                           End If
                        End If
                        If moduloAttivo.PrenOnLine = True Then
                           If DisattivaProdotto(Modulo.NOME_PREN_ONLINE_CONFIG) = True Then
                              ImpostaDatiListaModuli(Modulo.NOME_PREN_ONLINE, "", Color.Gray, False)
                           End If
                        End If

                        If moduloAttivo.CentroSportivo = True Then
                           If DisattivaProdotto(Modulo.NOME_SPORTING_CONFIG) = True Then
                              ImpostaDatiListaModuli(Modulo.NOME_SPORTING, "", Color.Gray, False)
                           End If
                        End If

                        Exit Select
                     End If

                  Case Modulo.NOME_HOTEL
                     If DisattivaProdotto(Modulo.NOME_HOTEL_CONFIG) = True Then
                        Exit Select
                     End If

                  Case Modulo.NOME_BAR
                     If DisattivaProdotto(Modulo.NOME_BAR_CONFIG) = True Then
                        Exit Select
                     End If

                  Case Modulo.NOME_CHEF
                     If DisattivaProdotto(Modulo.NOME_CHEF_CONFIG) = True Then

                        If DisattivaProdotto(Modulo.NOME_PALMARI_CONFIG) = True Then
                           ImpostaDatiListaModuli(Modulo.NOME_PALMARI, "", Color.Gray, False)
                        End If

                        If DisattivaProdotto(Modulo.NOME_PREN_ONLINE_CONFIG) = True Then
                           ImpostaDatiListaModuli(Modulo.NOME_PREN_ONLINE, "", Color.Gray, False)
                        End If

                        Exit Select
                     End If

                  Case Modulo.NOME_SPORTING
                     If DisattivaProdotto(Modulo.NOME_SPORTING_CONFIG) = True Then
                        Exit Select
                     End If

                  Case Modulo.NOME_PALMARI
                     If DisattivaProdotto(Modulo.NOME_PALMARI_CONFIG) = True Then
                        Exit Select
                     End If

                  Case Modulo.NOME_PREN_ONLINE
                     If DisattivaProdotto(Modulo.NOME_PREN_ONLINE_CONFIG) = True Then
                        Exit Select
                     End If

                  Case Modulo.NOME_MAGAZZINO
                     If DisattivaProdotto(Modulo.NOME_MAGAZZINO_CONFIG) = True Then
                        Exit Select
                     End If

                  Case Modulo.NOME_ETICHETTE
                     If DisattivaProdotto(Modulo.NOME_ETICHETTE_CONFIG) = True Then
                        Exit Select
                     End If

                  Case Modulo.NOME_PENDRIVE_RECOVERY
                     If DisattivaProdotto(Modulo.NOME_PENDRIVE_RECOVERY_CONFIG) = True Then
                        Exit Select
                     End If

                  Case Modulo.NOME_PENDRIVE_PORTABLE
                     If DisattivaProdotto(Modulo.NOME_PENDRIVE_PORTABLE_CONFIG) = True Then
                        Exit Select
                     End If

                  Case Modulo.NOME_REG_CASSA
                     If DisattivaProdotto(Modulo.NOME_REG_CASSA_CONFIG) = True Then
                        Exit Select
                     End If

                  Case Modulo.NOME_FATT_ELETTRONICA
                     If DisattivaProdotto(Modulo.NOME_FATT_ELETTRONICA_CONFIG) = True Then
                        Exit Select
                     End If

               End Select

               e.Item.SubItems(2).Text = String.Empty
               e.Item.SubItems(3).ForeColor = Color.Gray
               e.Item.SubItems(3).Text = "NON ATTIVO"

               ' Attiva disattiva tutte le funzionalità del software.
               ImpostaModuli()

               ' Messaggio sulla barra di stato.
               eui_Informazioni.Text = LeggiDatiRivenditore()

               MessageBox.Show(MSG_PRODOTTO_DISATTIVATO, NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region "Amica Gestionale"

   Public Sub VisualizzaRibbonAmica(ByVal visualizzaRibbon As Boolean)
      ' NON UTILIZZATA!!!
      Try

         If visualizzaRibbon = True Then
            ' Aggiunge il form aperto al contatore.
            NumFormMdiAperti += 1

            ' Visualizza i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
            rtgGestionaleAmica.Visible = visualizzaRibbon
         Else
            ' Rimuove il form aperto dal contatore.
            NumFormMdiAperti -= 1

            ' Se non ci sono form aperti...
            If NumFormMdiAperti = 0 Then
               ' Chiude i comandi sul Ribbon per l'importazione/esportazione dati del Gestionale Amica.
               rtgGestionaleAmica.Visible = visualizzaRibbon
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdAmicaImporta_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdAmicaImporta.Click
      Try

         If ActiveMdiChild.Text.Contains("Clienti") = True Then
            AmicaImportaEsporta("Importa", "Elenco Clienti")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Fornitori") = True Then
            AmicaImportaEsporta("Importa", "Elenco Fornitori")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Aziende") = True Then
            AmicaImportaEsporta("Importa", "Elenco Aziende")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Articoli") = True Then
            AmicaImportaEsporta("Importa", "Elenco Articoli")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Prima Nota") = True Then
            AmicaImportaEsporta("Importa", "Prima Nota")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Nazioni") = True Then
            AmicaImportaEsporta("Importa", "Nazioni")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Attività") = True Then
            AmicaImportaEsporta("Importa", "Attività")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Categorie merceologiche") = True Then
            AmicaImportaEsporta("Importa", "Categorie merceologiche")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Tipo pagamento") = True Then
            AmicaImportaEsporta("Importa", "Tipo pagamento")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Magazzini") = True Then
            AmicaImportaEsporta("Importa", "Magazzini")
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdAmicaEsporta_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdAmicaEsporta.Click
      Try

         If ActiveMdiChild.Text.Contains("Clienti") = True Then
            AmicaImportaEsporta("Esporta", "Elenco Clienti")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Fornitori") = True Then
            AmicaImportaEsporta("Esporta", "Elenco Fornitori")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Aziende") = True Then
            AmicaImportaEsporta("Esporta", "Elenco Aziende")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Articoli") = True Then
            AmicaImportaEsporta("Esporta", "Elenco Articoli")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Prima Nota") = True Then
            AmicaImportaEsporta("Esporta", "Prima Nota")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Nazioni") = True Then
            AmicaImportaEsporta("Esporta", "Nazioni")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Attività") = True Then
            AmicaImportaEsporta("Esporta", "Attività")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Categorie merceologiche") = True Then
            AmicaImportaEsporta("Esporta", "Categorie merceologiche")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Tipo pagamento") = True Then
            AmicaImportaEsporta("Esporta", "Tipo pagamento")
            Exit Sub
         End If

         If ActiveMdiChild.Text.Contains("Magazzini") = True Then
            AmicaImportaEsporta("Esporta", "Magazzini")
            Exit Sub
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub AmicaImportaEsporta(ByVal tipoOperazione As String, ByVal tipoDati As String)
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Const NOME_AMICA_HOSPITALITY_EXE As String = "Amica.Hospitality.exe"
         Const NOME_AMICA_HOSPITALITY_CONFIG As String = "Amica.Hospitality.txt"
         Const NOME_AMICA_HOSPITALITY_IMG As String = "Amica.Img.bmp"

         Dim percorsoAmica As String

         ' Percorso Gestionale Amica.
         If DatiConfig.GetValue("PercorsoAmica") <> String.Empty Then
            percorsoAmica = DatiConfig.GetValue("PercorsoAmica")
         Else
            MessageBox.Show("Per eseguire l'operazione è necessario impostare il percorso del Gestionale Amica nella finestra Opzioni.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
         End If

         ' Verifica l'esistenza del file per l'importazione/esportazione.
         Dim percorsoFileHospitality As String = Application.StartupPath & "\Amica\" & NOME_AMICA_HOSPITALITY_EXE
         Dim percorsoFileAmica As String = percorsoAmica & NOME_AMICA_HOSPITALITY_EXE
         Dim percorsoFileHospitalityConfig As String = Application.StartupPath & "\Amica\" & NOME_AMICA_HOSPITALITY_CONFIG
         Dim percorsoFileAmicaConfig As String = percorsoAmica & NOME_AMICA_HOSPITALITY_CONFIG
         Dim percorsoFileHospitalityImg As String = Application.StartupPath & "\Amica\" & NOME_AMICA_HOSPITALITY_IMG
         Dim percorsoFileAmicaImg As String = percorsoAmica & NOME_AMICA_HOSPITALITY_IMG


         If File.Exists(percorsoAmica & NOME_AMICA_HOSPITALITY_EXE) = True Then
            ScriviFileAmicaHospitality(tipoOperazione, tipoDati, percorsoFileAmicaConfig, ConnString)

            AvviaApplicazione(Me.Handle, percorsoAmica & NOME_AMICA_HOSPITALITY_EXE, "")
         Else
            File.Copy(percorsoFileHospitality, percorsoFileAmica)
            File.Copy(percorsoFileHospitalityConfig, percorsoFileAmicaConfig)
            File.Copy(percorsoFileHospitalityImg, percorsoFileAmicaImg)

            If File.Exists(percorsoAmica & NOME_AMICA_HOSPITALITY_EXE) = True Then
               ScriviFileAmicaHospitality(tipoOperazione, tipoDati, percorsoFileAmicaConfig, ConnString)

               AvviaApplicazione(Me.Handle, percorsoAmica & NOME_AMICA_HOSPITALITY_EXE, "")
            Else
               MessageBox.Show("Il programma di utilità per l'importazione/esportazione dei dati risulta essere mancante si prega di riporvare. Se il problema persiste contattare l'assistenza.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try

   End Sub

   Private Sub ScriviFileAmicaHospitality(ByVal tipoOperazione As String, ByVal nomeDati As String, ByVal percorsoFileHospitalityConfig As String, ByVal connString As String)
      Try
         If File.Exists(percorsoFileHospitalityConfig) = True Then

            FileOpen(1, percorsoFileHospitalityConfig, OpenMode.Output)
            PrintLine(1, connString)
            PrintLine(1, tipoOperazione)
            PrintLine(1, nomeDati)

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         FileClose(1)

      End Try

   End Sub

#End Region

#Region " Schedine PS "

   Public Function LeggiNumeroMax(ByVal tabella As String) As Integer
      Dim closeOnExit As Boolean
      Dim numRec As Integer
      Dim sql As String
      Dim cn As New OleDbConnection(ConnString)
      Dim cmd As New OleDbCommand(sql, cn)

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Ottiene il numero di record.
         cmd.CommandText = String.Format("SELECT MAX(NumDoc) FROM {0}", tabella)

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

   Public Function LeggiNumeroSchedinaConfig(ByVal tabella As String) As Integer
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If IsNumeric(DatiConfig.GetValue("NumeroSchedina")) = False Then
            ' Legge dal database.
            Dim num As Integer = LeggiNumeroMax(tabella)
            If num = 0 Then
               Return 1
            Else
               Return num
            End If
         Else
            ' Legge dal file di configurazione.
            Return Convert.ToInt32(DatiConfig.GetValue("NumeroSchedina"))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Sub SalvaNumeroSchedinaConfig(ByVal tabella As String, ByVal numDoc As Integer)
      Try
         ' In caso di numerazione non valida.
         If numDoc = 0 Then
            Exit Sub
         End If

         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         DatiConfig.SetValue("NumeroSchedina", (numDoc + 1).ToString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

#Region " Modello Istat C/59 "

   Public Function LeggiNumeroModelloIstatC59() As Integer
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If IsNumeric(DatiConfig.GetValue("NumeroModC59")) = False Then
            Return 1
         Else
            ' Legge dal file di configurazione.
            Return Convert.ToInt32(DatiConfig.GetValue("NumeroModC59"))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Sub SalvaNumeroModelloIstatC59(ByVal numDoc As Integer)
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         DatiConfig.SetValue("NumeroModC59", (numDoc + 1).ToString)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function CalcolaClientiItaliani(ByVal data As String) As String()
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim numArrivati As Integer
      Dim numPartiti As Integer
      Dim provincia As String
      Dim adulti As Integer
      Dim bambini As Integer
      Dim ragazzi As Integer
      Dim rigaDettagli(99) As String
      Dim i As Integer

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT Provincia FROM " & TAB_PRENOTAZIONI & " WHERE Nazionalità = 'ITALIA' GROUP BY Provincia", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            i += 1

            If IsDBNull(dr.Item("Provincia")) = False Then
               provincia = dr.Item("Provincia").ToString
            End If

            ' Clienti italiani arrivati oggi.
            Dim cmd1 As New OleDbCommand("SELECT * FROM " & TAB_PRENOTAZIONI & " WHERE DataArrivo = #" & data & "# AND Provincia = '" & provincia & "'", cn)
            Dim dr1 As OleDbDataReader = cmd1.ExecuteReader()

            Do While dr1.Read()

               If IsDBNull(dr1.Item("Adulti")) = False Then
                  adulti = Convert.ToInt32(dr1.Item("Adulti"))
               Else
                  adulti = 0
               End If

               If IsDBNull(dr1.Item("Bambini")) = False Then
                  bambini = Convert.ToInt32(dr1.Item("Bambini"))
               Else
                  bambini = 0
               End If
               If IsDBNull(dr1.Item("Ragazzi")) = False Then
                  ragazzi = Convert.ToInt32(dr1.Item("Ragazzi"))
               Else
                  ragazzi = 0
               End If

               numArrivati = numArrivati + adulti + bambini + ragazzi
            Loop

            ' Clienti italiani partiti oggi.
            Dim cmd2 As New OleDbCommand("SELECT * FROM " & TAB_PRENOTAZIONI & " WHERE DataPartenza = #" & data & "# AND Provincia = '" & provincia & "'", cn)
            Dim dr2 As OleDbDataReader = cmd2.ExecuteReader()

            Do While dr2.Read()

               If IsDBNull(dr2.Item("Adulti")) = False Then
                  adulti = Convert.ToInt32(dr2.Item("Adulti"))
               Else
                  adulti = 0
               End If

               If IsDBNull(dr2.Item("Bambini")) = False Then
                  bambini = Convert.ToInt32(dr2.Item("Bambini"))
               Else
                  bambini = 0
               End If
               If IsDBNull(dr2.Item("Ragazzi")) = False Then
                  ragazzi = Convert.ToInt32(dr2.Item("Ragazzi"))
               Else
                  ragazzi = 0
               End If

               numPartiti = numPartiti + adulti + bambini + ragazzi
            Loop

            ' Legge il nome della provincia per esteso.
            Dim cmd3 As New OleDbCommand("SELECT * FROM Province WHERE Sigla = '" & provincia & "'", cn)
            Dim dr3 As OleDbDataReader = cmd3.ExecuteReader()

            Do While dr3.Read()
               If IsDBNull(dr3.Item("Nome")) = False Then
                  provincia = dr3.Item("Nome").ToString
               Else
                  provincia = String.Empty
               End If
            Loop

            rigaDettagli(i) = provincia & ";" & numArrivati & ";" & numPartiti

            numArrivati = 0
            numPartiti = 0
         Loop

         Return rigaDettagli

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Public Function CalcolaClientiStranieri(ByVal data As String) As String()
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim numArrivati As Integer
      Dim numPartiti As Integer
      Dim nazionalità As String
      Dim adulti As Integer
      Dim bambini As Integer
      Dim ragazzi As Integer
      Dim rigaDettagli(99) As String
      Dim i As Integer

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT Nazionalità FROM " & TAB_PRENOTAZIONI & " WHERE Nazionalità <> 'ITALIA' GROUP BY Nazionalità", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            i += 1

            If IsDBNull(dr.Item("Nazionalità")) = False Then
               nazionalità = dr.Item("Nazionalità").ToString
            End If

            ' Clienti italiani arrivati oggi.
            Dim cmd1 As New OleDbCommand("SELECT * FROM " & TAB_PRENOTAZIONI & " WHERE DataArrivo = #" & data & "# AND Nazionalità = '" & nazionalità & "'", cn)
            Dim dr1 As OleDbDataReader = cmd1.ExecuteReader()

            Do While dr1.Read()

               If IsDBNull(dr1.Item("Adulti")) = False Then
                  adulti = Convert.ToInt32(dr1.Item("Adulti"))
               Else
                  adulti = 0
               End If

               If IsDBNull(dr1.Item("Bambini")) = False Then
                  bambini = Convert.ToInt32(dr1.Item("Bambini"))
               Else
                  bambini = 0
               End If
               If IsDBNull(dr1.Item("Ragazzi")) = False Then
                  ragazzi = Convert.ToInt32(dr1.Item("Ragazzi"))
               Else
                  ragazzi = 0
               End If

               numArrivati = numArrivati + adulti + bambini + ragazzi
            Loop

            ' Clienti italiani partiti oggi.
            Dim cmd2 As New OleDbCommand("SELECT * FROM " & TAB_PRENOTAZIONI & " WHERE DataPartenza = #" & data & "# AND Nazionalità = '" & nazionalità & "'", cn)
            Dim dr2 As OleDbDataReader = cmd2.ExecuteReader()

            Do While dr2.Read()

               If IsDBNull(dr2.Item("Adulti")) = False Then
                  adulti = Convert.ToInt32(dr2.Item("Adulti"))
               Else
                  adulti = 0
               End If

               If IsDBNull(dr2.Item("Bambini")) = False Then
                  bambini = Convert.ToInt32(dr2.Item("Bambini"))
               Else
                  bambini = 0
               End If
               If IsDBNull(dr2.Item("Ragazzi")) = False Then
                  ragazzi = Convert.ToInt32(dr2.Item("Ragazzi"))
               Else
                  ragazzi = 0
               End If

               numPartiti = numPartiti + adulti + bambini + ragazzi
            Loop

            rigaDettagli(i) = nazionalità & ";" & numArrivati & ";" & numPartiti

            numArrivati = 0
            numPartiti = 0
         Loop

         Return rigaDettagli

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Function

   Private Function LeggiRagSocAzienda() As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM Azienda", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("RagSoc").ToString
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Private Function LeggiTipoEsercizio() As String
      Try
         Dim DatiConfig As New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If DatiConfig.GetValue("TipoEsercizioHotel") <> String.Empty Then
            Return DatiConfig.GetValue("TipoEsercizioHotel").ToString
         Else
            Return String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Private Function CalcolaNumeroClientiGiornoPrec(ByVal dataGiornoPrec As Date) As Integer
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim numClienti As Integer
      Dim adulti As Integer
      Dim bambini As Integer
      Dim ragazzi As Integer
      Dim arrivo As Date
      Dim partenza As Date
      Dim i As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
         End If

         Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_PRENOTAZIONI & " ORDER BY DataArrivo ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            If IsDBNull(dr.Item("Adulti")) = False Then
               adulti = Convert.ToInt32(dr.Item("Adulti"))
            Else
               adulti = 0
            End If

            If IsDBNull(dr.Item("Bambini")) = False Then
               bambini = Convert.ToInt32(dr.Item("Bambini"))
            Else
               bambini = 0
            End If
            If IsDBNull(dr.Item("Ragazzi")) = False Then
               ragazzi = Convert.ToInt32(dr.Item("Ragazzi"))
            Else
               ragazzi = 0
            End If

            If IsDBNull(dr.Item("DataArrivo")) = False Then
               arrivo = Convert.ToDateTime(dr.Item("DataArrivo"))
            Else
               arrivo = Nothing
            End If
            If IsDBNull(dr.Item("DataPartenza")) = False Then
               partenza = Convert.ToDateTime(dr.Item("DataPartenza"))
            Else
               partenza = Nothing
            End If

            Dim dataGiorno As Date = arrivo

            Do While dataGiorno < partenza
               i += 1

               If dataGiorno = dataGiornoPrec Then
                  numClienti = numClienti + adulti + bambini + ragazzi
               End If

               dataGiorno = arrivo.AddDays(i)
            Loop

            i = 0
         Loop

         Return numClienti

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

   Private Function LeggiNumeroStelle() As String
      Try
         Dim DatiConfig As New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If DatiConfig.GetValue("NumeroStelleHotel") <> String.Empty Then
            Return DatiConfig.GetValue("NumeroStelleHotel").ToString
         Else
            Return String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try
   End Function

   Private Function LeggiComuneAzienda() As String
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM Azienda", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read
            Return dr.Item("Città").ToString
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      Finally
         cn.Close()

      End Try
   End Function

   Public Sub ElaboraModelloIstaC59(ByVal dataOggi As Date)
      Try
         Dim CStoricoPresenzeIstatC59 As New StoricoPresenzeIstatC59
         Dim CStoricoPresenzeIstat As New StoricoPresenzeIstat
         Dim listaClientiItaliani As String()
         Dim listaClientiStranieri As String()
         Dim datiClientiItaliani As String()
         Dim datiClientiStranieri As String()

         Dim arrivatiNaz As Integer
         Dim arrivatiProv As Integer
         Dim partitiNaz As Integer
         Dim partitiProv As Integer

         Dim clientiGiornoPrec As Integer
         Dim clientiArrivati As Integer
         Dim clientiPartiti As Integer
         Dim totaleClienti As Integer
         Dim clientiPresentiNotte As Integer

         ' Calcola il toale dei clienti italiani arrivati e partiti del giorno corrente.
         listaClientiItaliani = CalcolaClientiItaliani(FormattaData(dataOggi, False))

         ' Calcola il toale dei clienti stranieri arrivati e partiti del giorno corrente.
         listaClientiStranieri = CalcolaClientiStranieri(FormattaData(dataOggi, False))

         ' Unisce i dati dei clienti italiani e stranieri su un'unica riga e li salva in una tabella del database per essere caricati dal Report di stampa.
         With CStoricoPresenzeIstat
            .EliminaDati(TAB_STORICO_PRESENZE_ISTAT)

            Dim i As Integer
            For i = 1 To listaClientiItaliani.Length

               ' Se non ci sono dati esce dal ciclo.
               If IsNothing(listaClientiItaliani(i)) = True And IsNothing(listaClientiStranieri(i)) = True Then
                  Exit For
               End If

               If IsNothing(listaClientiItaliani(i)) = False Then
                  datiClientiItaliani = listaClientiItaliani(i).Split(";")
               Else
                  datiClientiItaliani = ";0;0".Split(";")
                  'datiClientiItaliani(0) = String.Empty
                  'datiClientiItaliani(1) = "0"
                  'datiClientiItaliani(2) = "0"
               End If

               If IsNothing(listaClientiStranieri(i)) = False Then
                  datiClientiStranieri = listaClientiStranieri(i).Split(";")
               Else
                  datiClientiStranieri = ";0;0".Split(";")
                  'datiClientiStranieri(0) = String.Empty
                  'datiClientiStranieri(1) = "0"
                  'datiClientiStranieri(2) = "0"
               End If

               If datiClientiStranieri(1) = "0" And datiClientiStranieri(2) = "0" And datiClientiItaliani(1) = "0" And datiClientiItaliani(2) = "0" Then
                  .Numero = 0
                  .Nazionalità = String.Empty
                  .ArrivatiNaz = 0
                  .PartitiNaz = 0
                  .Provincia = String.Empty
                  .ArrivatiProv = 0
                  .PartitiProv = 0
               Else
                  .Numero = i
                  .ArrivatiNaz = Convert.ToInt32(datiClientiStranieri(1))
                  .PartitiNaz = Convert.ToInt32(datiClientiStranieri(2))

                  If .ArrivatiNaz = 0 And .PartitiNaz = 0 Then
                     .Nazionalità = String.Empty
                  Else
                     .Nazionalità = datiClientiStranieri(0)
                  End If

                  .ArrivatiProv = Convert.ToInt32(datiClientiItaliani(1))
                  .PartitiProv = Convert.ToInt32(datiClientiItaliani(2))

                  If .ArrivatiProv = 0 And .PartitiProv = 0 Then
                     .Provincia = String.Empty
                  Else
                     .Provincia = datiClientiItaliani(0)
                  End If

                  .InserisciDati(TAB_STORICO_PRESENZE_ISTAT)
               End If
            Next

            ' Calcola i totali.
            .Numero = 0
            .Nazionalità = "TOTALE STRANIERI"

            arrivatiNaz = SommaValoriColonna(TAB_STORICO_PRESENZE_ISTAT, "ArrivatiNaz")
            .ArrivatiNaz = arrivatiNaz
            If .ArrivatiNaz = 0 Then
               .ArrivatiNaz = -1
            End If

            partitiNaz = SommaValoriColonna(TAB_STORICO_PRESENZE_ISTAT, "PartitiNaz")
            .PartitiNaz = partitiNaz
            If .PartitiNaz = 0 Then
               .PartitiNaz = -1
            End If

            .Provincia = "TOTALE ITALIANI"

            arrivatiProv = SommaValoriColonna(TAB_STORICO_PRESENZE_ISTAT, "ArrivatiProv")
            .ArrivatiProv = arrivatiProv
            If .ArrivatiProv = 0 Then
               .ArrivatiProv = -1
            End If

            partitiProv = SommaValoriColonna(TAB_STORICO_PRESENZE_ISTAT, "PartitiProv")
            .PartitiProv = partitiProv
            If .PartitiProv = 0 Then
               .PartitiProv = -1
            End If

            .InserisciDati(TAB_STORICO_PRESENZE_ISTAT)
         End With

         ' Calcola il numero dei clienti...
         clientiGiornoPrec = CalcolaNumeroClientiGiornoPrec(dataOggi.AddDays(-1))
         clientiArrivati = arrivatiNaz + arrivatiProv
         totaleClienti = clientiGiornoPrec + clientiArrivati
         clientiPartiti = partitiNaz + partitiProv
         clientiPresentiNotte = totaleClienti - clientiPartiti

         ' Salva i dati per l'intestazione del documento.
         With CStoricoPresenzeIstatC59
            .EliminaDati(TAB_STORICO_PRESENZE_ISTAT_C59)

            .Numero = g_frmMain.LeggiNumeroModelloIstatC59
            .Giorno = dataOggi.Day.ToString
            .Mese = dataOggi.Month.ToString
            .Anno = dataOggi.Year.ToString
            .Comune = LeggiComuneAzienda()
            .TipoEsercizio = LeggiTipoEsercizio()
            .Denominazione = LeggiRagSocAzienda()
            .NumeroStelle = LeggiNumeroStelle()
            .ClientiGiornoPrec = clientiGiornoPrec
            .ClientiArrivati = clientiArrivati
            .TotaleClienti = totaleClienti
            .ClientiPartiti = clientiPartiti
            .ClientiPresentiNotte = clientiPresentiNotte

            .InserisciDati(TAB_STORICO_PRESENZE_ISTAT_C59)

            g_frmMain.SalvaNumeroModelloIstatC59(.Numero)
         End With

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#End Region

   Public Sub SalvaDatiPenDriveRecovery()
      ' Se il modulo Pen Drive Recovery è attivo
      If moduloAttivo.PenDriveRecovery = True Then
         PenDriveRecovery("Hospitality Solution Recovery\HsRecovery", "PercorsoRecovery", "DataRecovery", "AttivaRecovery",
                          "Hospitality Solution 3.0.exe", "HsPack.msi", "Hospitality Solution Recovery.exe")
      End If
   End Sub

   Private Sub ImpostaProprietàArchivio()
      Try
         txtPercorso.Text = Application.StartupPath & CARTELLA_ARCHIVI
         txtPercorso.ScreenTip.Text = Application.StartupPath & CARTELLA_ARCHIVI
         lblPercorso.Text = Application.StartupPath & CARTELLA_ARCHIVI
         cmdApriPercorso.ScreenTip.Text = Application.StartupPath & CARTELLA_ARCHIVI

         lblAttributi.Text = File.GetAttributes(PercorsoDB).ToString
         lblDataCreazione.Text = File.GetCreationTime(PercorsoDB).ToString
         lblDataUltimoAccesso.Text = File.GetLastAccessTime(PercorsoDB).ToString
         lblDataUltimaScrittura.Text = File.GetLastWriteTime(PercorsoDB).ToString

         Dim di As New DirectoryInfo(Application.StartupPath & CARTELLA_ARCHIVI)
         Dim fiArr As FileInfo() = di.GetFiles(NomeDB, SearchOption.TopDirectoryOnly)

         Dim f As FileInfo
         For Each f In fiArr
            Dim B As Long = f.Length
            Dim KB As Long = B / 1024
            Dim MB As Long = KB / 1024

            lblDimensioniFile.Text = String.Format("{0:##,##0}", KB) & " KB (" & String.Format("{0:##,##0}", B) & " byte)"
         Next f

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub ImpostaInfoSu()
      lblVersione.Text = "Versione " & FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).ProductVersion & " (32 Bit)"
      lblInfo.Text = FileVersionInfo.GetVersionInfo(GetExecutingAssembly.Location).LegalCopyright
      lblNumSerie.Text = "ID prodotto: " & NUMERO_SERIE
   End Sub

   Private Sub eui_cmdArchivio_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdArchivio.Click
      Dim frm As New frmOpzioni
      frm.ShowDialog()
   End Sub

   Private Sub eui_cmdAzienda_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdAzienda.Click
      ApriAzienda()
   End Sub

   Private Sub eui_cmdPostazione_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdPostazione.Click
      Dim frm As New frmPostazione
      frm.ShowDialog()
   End Sub

   Private Sub eui_cmdOperatore_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdOperatore.Click
      ApriOperatori()
   End Sub

   Private Sub picProg_Click(sender As System.Object, e As System.EventArgs) Handles picProg.Click
      eui_File.BackstageViewVisible = False

   End Sub

   Private Sub cmdApriPercorso_Click(sender As System.Object, e As System.EventArgs) Handles cmdApriPercorso.Click
      AvviaEsploraFile(Me.Handle, Application.StartupPath & CARTELLA_ARCHIVI)
   End Sub

   Private Sub cmdBackup_Click(sender As System.Object, e As System.EventArgs) Handles cmdBackup.Click
      eui_cmdArchiviBackup.PerformClick()
   End Sub

   Private Sub cmdPulizia_Click(sender As System.Object, e As System.EventArgs) Handles cmdPulizia.Click
      eui_cmdArchiviPulizia.PerformClick()
   End Sub

   Private Sub cmdCompatta_Click(sender As System.Object, e As System.EventArgs) Handles cmdCompatta.Click
      eui_cmdArchiviCompatta.PerformClick()
   End Sub

   Private Sub eui_cmdGuida_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdGuida.Click
      ApriGuida()
   End Sub

   Private Sub eui_cmdContattaci_Click(sender As Object, e As System.EventArgs) Handles eui_cmdContattaci.Click
      Try
         ApriSitoInternet(MS_WEB_CONTATTI)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub lnkMsWeb_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkMsWeb.LinkClicked
      Try
         ApriSitoInternet(MS_WEB)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lnkVideo_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkVideo.LinkClicked
      Try
         ApriSitoInternet(MS_WEB_VIDEO_GUIDE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try

   End Sub

   Private Sub eui_cmdOpzioni_Click(sender As System.Object, e As System.EventArgs) Handles eui_cmdOpzioni.Click
      Try
         Dim frm As New frmOpzioni
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lnkInfoSu_LinkClicked(sender As System.Object, e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles lnkInfoSu.LinkClicked
      Try
         ApriInfo()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub lnkSupporto_Click(sender As Object, e As System.EventArgs) Handles lnkSupporto.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim Web As New Varie.WebSolution
         Dim allegato(-1) As String

         Web.createEmail(Application.StartupPath & "\Documenti\" & EMAIL_NOME_FILE, EMAIL_DA, EMAIL_A, EMAIL_OGGETTO & NOME_PRODOTTO, EMAIL_TESTO, allegato)
         Process.Start(Application.StartupPath & "\Documenti\" & EMAIL_NOME_FILE)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try

   End Sub

   Private Sub lnkLicenza_Click(sender As Object, e As System.EventArgs) Handles lnkLicenza.Click
      AvviaLicenzaRtf(Me.Handle, Application.StartupPath & PERCORSO_LICENZA_RTF)
   End Sub

   Private Sub eui_lstProdottiAttivati_SelectionChanged(sender As Object, e As System.EventArgs) Handles eui_lstProdottiAttivati.SelectionChanged
      VisualizzaInfoProdottiAttivi()
   End Sub

   Private Sub Timer2_Tick(sender As System.Object, e As System.EventArgs) Handles Timer2.Tick
      ' Legge eventuali file di prenotazioni per Tavoloso.
      LeggiFilePrenTavoloso(True)

   End Sub

   Private Sub eui_cmdAggiornamenti_Click(sender As Object, e As EventArgs) Handles eui_cmdAggiornamenti.Click
      Try
         ' Verifica con messaggio a video!
         VerificaAggiornamenti(True)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdNuovoAgg_Click(sender As Object, e As EventArgs) Handles eui_cmdNuovoAgg.Click
      Try
         ' Verifica con messaggio a video!
         VerificaAggiornamenti(True)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdLicenza_Click(sender As Object, e As EventArgs) Handles eui_cmdLicenza.Click
      Try
         If g_VerDemo = False Then
            ' Verifica con messaggio a video!
            VerificaLicenza(True)
         Else
            ' Visualizza i giorni rimanenti della Licenza.
            MessageBox.Show("Servizio di assistenza per la versione dimostativa: ATTIVO!" & vbNewLine & vbNewLine &
                            "Hai ancora a disposizione " & giorniVerDemo & " giorni di assistenza." & vbNewLine &
                            "Per informazioni rivolgersi a: 'info@montanasoftware.it'", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

End Class