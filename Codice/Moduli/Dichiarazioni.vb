#Region " DATI FILE.VB "

' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       05/08/2005
' Data ultima modifica: 22/08/2018
' Descrizione:          Modulo per le dichiarazioni delle variabili e costanto globali.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************

#End Region

Imports System.Data.OleDb

Module Dichiarazioni
   ' Declare Function for Open Communication Port
   'Public Declare Function VbCEFOpen Lib "CeFdll.dll" (ByVal intCom As Integer, ByVal dwBaudRate As Integer, ByVal byParity As Byte, ByVal byDataBit As Byte, ByVal byStopBit As Byte, ByVal byFlowControl As Byte, ByRef lpdwSysError As Integer) As Integer
   ' Declare Function for Write Command on Communication Port
   'Public Declare Function VbCEFWrite Lib "CeFdll.dll" (ByRef textcmd As String, ByRef lpdwSysError As Integer) As Integer
   ' Declare Function for Read from Communication Port
   'Public Declare Function VbCEFRead Lib "CeFdll.dll" (ByRef RetData() As Byte, ByRef pdwByteRead As Integer, ByRef lpdwSysError As Integer) As Integer
   ' Declare Function for Read DLL Version
   'Public Declare Function VbCEFGetVersion Lib "CeFdll.dll" (ByRef RetData() As Byte, ByRef lpdwSysError As Integer) As Integer
   ' Declare Function for Close Communication Port
   'Public Declare Function VbCEFClose Lib "CeFdll.dll" (ByRef lpdwSysError As Integer) As Integer

   ' Dimensioni per il form Main.

   Public Const FORM_MAIN_LARGHEZZA As Integer = 920
   Public Const FORM_MAIN_ALTEZZA As Integer = 600

   ' Posizione per il Logo.
   Public Const MAIN_LARGHEZZA_LOGO As Integer = 1140
   Public Const MAIN_ALTEZZA_LOGO As Integer = 136

   ' Dimensioni delle finestre Anagrafiche.
   Public Const FORM_LARGHEZZA As Integer = 550
   Public Const FORM_ALTEZZA As Integer = 400

   ' Dimensioni della finesta Clienti.
   Public Const CLIENTI_LARGHEZZA As Integer = 600
   Public Const CLIENTI_ALTEZZA As Integer = 420

   ' Dimensioni del form Statistiche.
   Public Const STAT_LARGHEZZA As Integer = 750
   Public Const STAT_ALTEZZA As Integer = 500

   ' Dimensioni del form Prima nota.
   Public Const PN_LARGHEZZA As Integer = 780
   Public Const PN_ALTEZZA As Integer = 500

   ' Dimensioni del planning giornaliero per il centro sportivo.
   Public Const PLANNING_LARGHEZZA As Integer = 800
   Public Const PLANNING_ALTEZZA As Integer = 500

   ' A_TODO: MODIFICHE ASD AGON
   ' Dimensioni della finesta Clienti.
   Public Const PREN_RISORSE_LARGHEZZA As Integer = 610
   Public Const PREN_RISORSE_ALTEZZA As Integer = 460

   ' Dimensioni della finestra tabella.
   Public Const TAB_LARGHEZZA As Integer = 500
   Public Const TAB_ALTEZZA As Integer = 350

   ' Dimensioni della finestra tabella.
   Public Const MAPPA_LARGHEZZA As Integer = 730
   Public Const MAPPA_ALTEZZA As Integer = 650

   ' Dimensioni della finestra Listini Camere.
   Public Const LISTINI_LARGHEZZA As Integer = 789
   Public Const lISTINI_ALTEZZA As Integer = 487

   ' Dimensioni della finestra Listini Camere.
   Public Const STAGIONI_LARGHEZZA As Integer = 506
   Public Const STAGIONI_ALTEZZA As Integer = 630

   ' Dimensioni della finestra Anteprima di stampa.
   Public Const REPORTS_LARGHEZZA As Integer = 1000
   Public Const REPORTS_ALTEZZA As Integer = 700

   ' Dimensioni per la paginazione dei dati.
   Public Const DIM_PAGINA As Integer = 50
   ' Dimensioni per la paginazione utilizzata per non fornire la paginazione.
   Public Const DIM_PAGINA_GRANDE As Integer = 1000000

   ' Colore Rosa per la colonna delle griglie.
   Public Const COLORE_ROSA As Integer = -4884
   ' Colore Azzurro per la colonna delle griglie.
   Public Const COLORE_AZZURRO As Integer = -1376257

   ' Utilizzato per le valute.
   Public Const VALORE_ZERO As String = "0,00"

   ' Di utilizzo generale.
   Public Const VAL_NESSUNO As String = "Nessuno"
   Public Const VALORE_NESSUNA As String = "Nessuna"
   Public Const VALORE_INSERITA As String = "Inserita"
   Public Const VALORE_STAMPATA As String = "Stampata"
   Public Const VALORE_INVIATA As String = "Inviata"
   Public Const VALORE_ANNULLATA As String = "Annullata"

   ' Utilizzato per i permessi degli operatori.
   Public Const VALORE_NESSUNO As String = "NESSUNO"
   Public Const VALORE_LETTURA As String = "LETTURA"
   Public Const VALORE_SCRITTURA As String = "SCRITTURA"

   Public Const NOME_PRODOTTO_HOSPITALITY As String = "Hospitality Solution 3"
   Public Const NOME_PRODOTTO_HOSPITALITY_SUITE As String = "Hospitality Solution Suite 3"
   Public Const NOME_PRODOTTO_HOTEL As String = "Hospitality Hotel Solution 3"
   Public Const NOME_PRODOTTO_BAR As String = "Hospitality Bar Solution 3"
   Public Const NOME_PRODOTTO_CHEF As String = "Hospitality Chef Solution 3"
   Public Const NOME_PRODOTTO_SPORTING As String = "Hospitality Sporting Club Solution 3"

   ' Dati per il server SMTP Autenticato su Register.it
   Public Const NOME_MAIL_SERVER_SMTP As String = "authsmtp.montanasoftware.it"
   Public Const USER_NAME_MAIL_SERVER_SMTP As String = "smtp@montanasoftware.it"
   Public Const PWD_MAIL_SERVER_SMTP As String = "Lu200774lu_"

   ' Dati per l'invio dell'e-mail di assistenza.
   Public Const MS_WEB As String = "http://www.montanasoftware.it"
   Public Const MS_WEB_VIDEO_GUIDE As String = "https://www.youtube.com/user/montanasoftware3"
   Public Const MS_WEB_CONTATTI As String = "http://www.montanasoftware.it/ms_contatti.aspx"
   Public Const EMAIL_NOME_FILE As String = "Richiesta assistenza.eml"
   Public Const EMAIL_DA As String = ""
   Public Const EMAIL_A As String = "assistenza@montanasoftware.it"
   Public Const EMAIL_OGGETTO As String = "Richiesta di assistenza per il software "
   Public Const EMAIL_TESTO As String = "(Inserire qui eventuali informazioni utili per la richiesta di assistenza.) "

   ' Dati per l'invio dell'e-mail di richiesta del codice di attivazione.
   Public Const EMAIL_ATTIVAZIONE_NOME_FILE As String = "Richiesta chiave attivazione.eml"
   Public Const EMAIL_ATTIVAZIONE_A As String = "ordini@montanasoftware.it"
   Public Const EMAIL_ATTIVAZIONE_OGGETTO As String = "Richiesta della chiave di attivazione per il software/modulo "
   Public Const EMAIL_ATTIVAZIONE_TESTO As String = "ATTENZIONE! Inviare l'e-mail senza modificare il suo contenuto."

   ' Dati per l'invio dell'e-mail di utilizzo del software.
   Public Const EMAIL_DATI_LICENZA_A As String = "hospitality@montanasoftware.it"

   ' Indirizzo e-mail per il servizio di interscambio delle fattura elettronica.
   Public Const EMAIL_SDI_FATTURA_PA As String = "sdi01@pec.fatturapa.it"

   ' Stringa per la richiesta di informazioni sul Report non disponibile..
   Public Const MESSAGGIO_REPORT_NON_DISPONIBILE As String = "Per questo elenco non è disponibile un Report di stampa. Per informazioni scrivere a assistenza@montanasoftware.it."

   Public Const NOME_ARCHIVIO As String = "Hospitality.mdb"
   Public Const CARTELLA_ARCHIVI As String = "\Archivi"
   Public Const PERCORSO_LICENZA_RTF As String = "\Documenti\Licenza.rtf"
   Public Const PERCORSO_AZIENDE_DB As String = "\Archivi\StudioA.mdb" ' Non utilizzato.
   Public Const PERCORSO_DB As String = "\Archivi\Hospitality.mdb"
   Public Const PERCORSO_DB_CLIENTI As String = "\Archivi\Hospitality.mdb"
   Public Const PERCORSO_DB_CAP As String = "\Archivi\Cap.mdb"
   Public Const PERCORSO_BKP As String = "\Backup\Hospitality.mdb"
   Public Const CARTELLA_FATTURE_ELETTRONICHE As String = "Fatture elettroniche"

   ' Percorso reports.
   Public Const PERCORSO_REP_CLIENTI As String = "\Reports\Clienti.rpt"
   Public Const PERCORSO_REP_AZIENDE As String = "\Reports\Aziende.rpt"
   Public Const PERCORSO_REP_FORNITORI As String = "\Reports\Fornitori.rpt"
   Public Const PERCORSO_REP_PIATTI As String = "\Reports\Piatti.rpt"
   Public Const PERCORSO_REP_ARTICOLI As String = "\Reports\Articoli.rpt"
   Public Const PERCORSO_REP_MOV_MAG As String = "\Reports\MovMag.rpt"
   Public Const PERCORSO_REP_SCORTE As String = "\Reports\Scorte.rpt"
   Public Const PERCORSO_REP_INVENTARIO As String = "\Reports\Inventario.rpt"
   Public Const PERCORSO_REP_CAT_PIATTI As String = "\Reports\CatPiatti.rpt"
   Public Const PERCORSO_REP_CAMERIERI As String = "\Reports\Camerieri.rpt"
   Public Const PERCORSO_REP_SALE As String = "\Reports\Sale.rpt"
   Public Const PERCORSO_REP_TAVOLI As String = "\Reports\Tavoli.rpt"
   Public Const PERCORSO_REP_CAMERE As String = "\Reports\Camere.rdlc"

   Public Const PERCORSO_REP_PREN As String = "\Reports\Pren.rpt"
   Public Const PERCORSO_REP_PREN_SALE As String = "\Reports\PSale.rpt"
   Public Const PERCORSO_REP_MENU_ARIAL As String = "\Reports\Arial\Menu.rpt"
   Public Const PERCORSO_REP_MENU_TIMES As String = "\Reports\Times\Menu.rpt"
   Public Const PERCORSO_REP_MENU_COMIC As String = "\Reports\Comic\Menu.rpt"
   Public Const PERCORSO_REP_ACQUISTI As String = "\Reports\Acquisti.rpt"
   Public Const PERCORSO_REP_PRIMANOTA As String = "\Reports\PNota.rpt"
   Public Const PERCORSO_REP_DOC As String = "\Reports\Documenti.rpt"
   Public Const PERCORSO_REP_CORRISPETTIVI As String = "\Reports\Corrispettivi.rpt"
   Public Const PERCORSO_REP_STAT As String = "\Reports\Stat.rpt"
   Public Const PERCORSO_REP_ACCESSORI_SERVIZI As String = "\Reports\AccessoriServizi.rpt"
   Public Const PERCORSO_REP_RISORSE As String = "\Reports\Risorse.rpt"
   Public Const PERCORSO_REP_PREN_RISORSE As String = "\Reports\PrenRisorse.rpt"
   Public Const PERCORSO_REP_STAT_RISORSE As String = "\Reports\StatRisorse.rpt"
   Public Const PERCORSO_REP_GRUPPI As String = "\Reports\Gruppi.rpt"
   Public Const PERCORSO_REP_OPERATORI As String = "\Reports\Operatori.rpt"
   Public Const PERCORSO_REP_OPERAZIONI As String = "\Reports\Operazioni.rpt"

   ' Nomi per i reports dei documenti in formato .rdlc
   Public Const PERCORSO_REP_ACCESSORI_SERVIZI_A4 As String = "\Reports\AccessoriServizi.rdlc"
   Public Const PERCORSO_REP_CAP_A4 As String = "\Reports\Cap.rdlc"
   Public Const PERCORSO_REP_EMAIL_A4 As String = "\Reports\Email.rdlc"
   Public Const PERCORSO_REP_PREN_CAMERE_A4 As String = "\Reports\PrenCamere.rdlc"
   Public Const PERCORSO_REP_SCHEDINE_PS_A4 As String = "\Reports\SchedinePS.rdlc"
   Public Const PERCORSO_REP_SCHEDINA_PS_A4 As String = "\Reports\SchedinaPS A4.rdlc"
   Public Const PERCORSO_REP_LISTINI_CAMERE_A4 As String = "\Reports\ListiniCamere.rdlc"
   Public Const PERCORSO_REP_STORICO_PRESENZE_CAMERE_A4 As String = "\Reports\StoricoPresenzeCamere.rdlc"
   Public Const PERCORSO_REP_MODELLO_ISTAT_59_A4 As String = "\Reports\ModelloIstatC59 A4.rdlc"

   ' Nomi per i reports dei documenti in formato .rpt
   Public Const REPORT_RICEVUTA As String = "RFiscale.rpt"
   Public Const REPORT_FATTURA As String = "Fattura.rpt"
   Public Const REPORT_PROFORMA As String = "Proforma.rpt"
   Public Const REPORT_RICEVUTA_CENTRO_SPORTIVO As String = "RFiscale - Centro sportivo.rpt"
   Public Const REPORT_FATTURA_CENTRO_SPORTIVO As String = "Fattura - Centro sportivo.rpt"
   Public Const REPORT_PROFORMA_CENTRO_SPORTIVO As String = "Proforma - Centro sportivo.rpt"

   Public Const REPORT_COMANDA_REPARTI As String = "ComandaReparti.rpt"
   Public Const REPORT_COMANDA_CLIENTI As String = "ComandaClienti.rpt"
   Public Const REPORT_COMANDA_REPARTI_KUBEII As String = "ComandaRepartiKubeII.rpt.txt"
   Public Const REPORT_COMANDA_CLIENTI_KUBEII As String = "ComandaClientiKubeII.rpt.txt"
   Public Const REPORT_RICEVUTA_KUBEII As String = "RicevutaKubeII.rpt.txt" ' NON UTILIZZATA.
   Public Const REPORT_FATTURA_KUBEII As String = "FatturaKubeII.rpt.txt" ' NON UTILIZZATA.
   Public Const REPORT_PROFORMA_KUBEII As String = "ProformaKubeII.rpt.txt"

   ' Nomi per i reports personalizzati in formato .rpt per la Pizzeria Bella Napoli.
   Public Const REPORT_RICEVUTA_BELLA_NAPOLI As String = "RFiscale - Pizz. Bella Napoli.rpt"
   Public Const REPORT_FATTURA_BELLA_NAPOLI As String = "Fattura - Pizz. Bella Napoli.rpt"
   Public Const REPORT_PROFORMA_BELLA_NAPOLI As String = "Proforma - Pizz. Bella Napoli.rpt"

   ' Nomi per i reports personalizzati in formato .rpt per il Ristorante Celide.
   Public Const REPORT_FATTURA_CELIDE As String = "Fattura - Rist. Celide.rpt"
   Public Const REPORT_RICEVUTA_CELIDE As String = "RFiscale - Rist. Celide.rpt"
   Public Const REPORT_PROFORMA_CELIDE As String = "Proforma - Rist. Celide.rpt"

   ' Nomi per i reports personalizzati in formato .rpt per il Ristorante La Forchetta D'Oro.
   Public Const REPORT_FATTURA_FORCHETTA_DORO As String = "Fattura - Rist. La Forchetta D'Oro.rpt"
   Public Const REPORT_RICEVUTA_FORCHETTA_DORO As String = "RFiscale - Rist. La Forchetta D'Oro.rpt"
   Public Const REPORT_PROFORMA_FORCHETTA_DORO As String = "Proforma - Rist. La Forchetta D'Oro.rpt"

   ' Nomi per i reports dei documenti in formato .rdlc
   Public Const REPORT_RICEVUTA_A4_DOPPIA As String = "RFiscale A4_Doppia.rdlc"
   Public Const REPORT_RICEVUTA_A5 As String = "RFiscale A5.rdlc"
   Public Const REPORT_RICEVUTA_A6 As String = "RFiscale A6.rdlc"

   Public Const REPORT_FATTURA_A4_DOPPIA As String = "Fattura A4_Doppia.rdlc"
   Public Const REPORT_FATTURA_A4 As String = "Fattura A4.rdlc"
    Public Const REPORT_FATTURA_A4_IVA_MULTIPLA As String = "Fattura A4_Iva_Multipla.rdlc"

    Public Const REPORT_PROFORMA_A4_DOPPIA As String = "Proforma A4_Doppia.rdlc"
    Public Const REPORT_PROFORMA_A5 As String = "Proforma A5.rdlc"
   Public Const REPORT_PROFORMA_A6 As String = "Proforma A6.rdlc"

   Public Const REPORT_RICEVUTA_A4_DOPPIA_CENTRO_SPORTIVO As String = "RFiscale A4_Doppia - Centro sportivo.rdlc"
   Public Const REPORT_FATTURA_A4_DOPPIA_CENTRO_SPORTIVO As String = "Fattura A4_Doppia - Centro sportivo.rdlc"
   Public Const REPORT_PROFORMA_A4_DOPPIA_CENTRO_SPORTIVO As String = "Proforma A4_Doppia - Centro sportivo.rdlc"

   ' Documenti fiscali formato .rpt
   Public Const PERCORSO_REP_FF_AZIENDE As String = "\Reports\FattAziende.rpt"
   Public Const PERCORSO_REP_FF As String = "\Reports\Fattura.rpt" ' NON UTILIZZATA.
   Public Const PERCORSO_REP_RF As String = "\Reports\RFiscale.rpt" ' NON UTILIZZATA.
   Public Const PERCORSO_REP_PF As String = "\Reports\Proforma.rpt" ' NON UTILIZZATA.
   Public Const PERCORSO_REP_SF As String = "\Reports\Scontrino.rpt"
   Public Const PERCORSO_REP_FF_CENTRO_SPORTIVO As String = "\Reports\Fattura - Centro sportivo.rpt" ' NON UTILIZZATA.
   Public Const PERCORSO_REP_RF_CENTRO_SPORTIVO As String = "\Reports\RFiscale - Centro sportivo.rpt" ' NON UTILIZZATA.
   Public Const PERCORSO_REP_PF_CENTRO_SPORTIVO As String = "\Reports\Proforma - Centro sportivo.rpt" ' NON UTILIZZATA.
   Public Const PERCORSO_REP_FF_BELLA_NAPOLI As String = "\Reports\Fattura - Pizz. Bella Napoli.rpt"
   Public Const PERCORSO_REP_RF_BELLA_NAPOLI As String = "\Reports\RFiscale - Pizz. Bella Napoli.rpt"
   Public Const PERCORSO_REP_PF_BELLA_NAPOLI As String = "\Reports\Proforma - Pizz. Bella Napoli.rpt"
   Public Const PERCORSO_REP_FF_CELIDE As String = "\Reports\Fattura - Rist. Celide.rpt"
   Public Const PERCORSO_REP_RF_CELIDE As String = "\Reports\RFiscale - Rist. Celide.rpt"
   Public Const PERCORSO_REP_PF_CELIDE As String = "\Reports\Proforma - Rist. Celide.rpt"
   Public Const PERCORSO_REP_FF_FORCHETTA_DORO As String = "\Reports\Fattura - Rist. La Forchetta D'Oro.rpt"
   Public Const PERCORSO_REP_RF_FORCHETTA_DORO As String = "\Reports\RFiscale - Rist. La Forchetta D'Oro.rpt"
   Public Const PERCORSO_REP_PF_FORCHETTA_DORO As String = "\Reports\Proforma - Rist. La Forchetta D'Oro.rpt"
   Public Const PERCORSO_REP_FF_KUBEII As String = "\Reports\FatturaKubeII.rpt.txt" ' NON UTILIZZATA.
   Public Const PERCORSO_REP_RF_KUBEII As String = "\Reports\RicevutaKubeII.rpt.txt" ' NON UTILIZZATA.
   Public Const PERCORSO_REP_PF_KUBEII As String = "\Reports\ProformaKubeII.rpt.txt"

   ' Documenti fiscali formato .rdlc
   Public Const PERCORSO_REP_FF_A4 As String = "\Reports\Fattura A4.rdlc"
   Public Const PERCORSO_REP_FF_A4_DOPPIA As String = "\Reports\Fattura A4_Doppia.rdlc"
   Public Const PERCORSO_REP_FF_A4_IVA_MULTIPLA As String = "\Reports\Fattura A4_Iva_Multipla.rdlc"
   Public Const PERCORSO_REP_RF_A4_DOPPIA As String = "\Reports\RFiscale A4_Doppia.rdlc"
   Public Const PERCORSO_REP_RF_A5 As String = "\Reports\RFiscale A5.rdlc"
   Public Const PERCORSO_REP_RF_A6 As String = "\Reports\RFiscale A6.rdlc"
   Public Const PERCORSO_REP_PF_A4_DOPPIA As String = "\Reports\Proforma A4_Doppia.rdlc"
   Public Const PERCORSO_REP_PF_A5 As String = "\Reports\Proforma A5.rdlc"
   Public Const PERCORSO_REP_PF_A6 As String = "\Reports\Proforma A6.rdlc"
   Public Const PERCORSO_REP_FF_A4_DOPPIA_CENTRO_SPORTIVO As String = "\Reports\Fattura A4_Doppia - Centro sportivo.rdlc"
   Public Const PERCORSO_REP_RF_A4_DOPPIA_CENTRO_SPORTIVO As String = "\Reports\RFiscale A4_Doppia - Centro sportivo.rdlc"
   Public Const PERCORSO_REP_PF_A4_DOPPIA_CENTRO_SPORTIVO As String = "\Reports\Proforma A4_Doppia - Centro sportivo.rdlc"

   ' Comanda.
   Public Const PERCORSO_REP_COMANDA_REPARTI As String = "\Reports\ComandaReparti.rpt"
   Public Const PERCORSO_REP_COMANDA_CLIENTI As String = "\Reports\ComandaClienti.rpt"
   Public Const PERCORSO_REP_COMANDA_REPARTI_KUBEII As String = "\Reports\ComandaRepartiKubeII.rpt.txt"
   Public Const PERCORSO_REP_COMANDA_CLIENTI_KUBEII As String = "\Reports\ComandaClientiKubeII.rpt.txt"
   Public Const PERCORSO_REP_MESSAGGI As String = "\Reports\Messaggi.rpt"

   ' Percorso reports Etichette.
   Public Const PERCORSO_ETICHETTE_635_72 As String = "\Reports\Etichette\Etichette635_72.rpt"
   Public Const PERCORSO_ETICHETTE_635_339 As String = "\Reports\Etichette\Etichette635_339.rpt"
   Public Const PERCORSO_ETICHETTE_635_381 As String = "\Reports\Etichette\Etichette635_381.rpt"
   Public Const PERCORSO_ETICHETTE_991_331 As String = "\Reports\Etichette\Etichette991_331.rpt"
   Public Const PERCORSO_ETICHETTE_991_381 As String = "\Reports\Etichette\Etichette991_381.rpt"
   Public Const PERCORSO_ETICHETTE_991_677 As String = "\Reports\Etichette\Etichette991_677.rpt"

   Public Const PERCORSO_ETICHETTE_ART_635_72 As String = "\Reports\Etichette\EtichetteArt635_72.rpt"
   Public Const PERCORSO_ETICHETTE_ART_635_339 As String = "\Reports\Etichette\EtichetteArt635_339.rpt"
   Public Const PERCORSO_ETICHETTE_ART_635_381 As String = "\Reports\Etichette\EtichetteArt635_381.rpt"
   Public Const PERCORSO_ETICHETTE_ART_991_331 As String = "\Reports\Etichette\EtichetteArt991_331.rpt"
   Public Const PERCORSO_ETICHETTE_ART_991_381 As String = "\Reports\Etichette\EtichetteArt991_381.rpt"
   Public Const PERCORSO_ETICHETTE_ART_991_677 As String = "\Reports\Etichette\EtichetteArt991_677.rpt"

   ' Nomi dei file per la gestione dei palmari in rete per Windows Mobile/CE.
   Public Const NOME_FILE_ANAG As String = "CHS_ANAG.TXT"
   Public Const NOME_FILE_TAVOLI As String = "CHS_TAVOLI.TXT"
   Public Const NOME_FILE_TEMP As String = "TEMP.TXT"
   Public Const NOME_FILE_COMANDI As String = "CHS_CMD.TXT"

   ' Nomi dei file per la gestione dei palmari in rete per Android.
   Public Const NOME_FILE_ANAG_ANDROID As String = "CHS_ANAG.DB"
   Public Const NOME_PERCORSO_FILE_ANAG_ANDROID As String = "\Android\CHS_ANAG.DB"
   Public Const NOME_FILE_TAVOLI_ANDROID As String = "CHS_TAVOLI.DB"
   Public Const NOME_PERCORSO_FILE_TAVOLI_ANDROID As String = "\Android\CHS_TAVOLI.DB"
   Public Const NOME_FILE_COMANDI_ANDROID As String = "CHS_CMD.DB"
   Public Const NOME_PERCORSO_FILE_COMANDI_ANDROID As String = "\Android\CHS_CMD.DB"

   ' Percorso del file di Log.
   Public Const PERCORSO_ERRORI As String = "\Dati\Registro degli errori.log"
   ' Percorso del file della guida in linea.
   Public Const PERCORSO_GUIDA As String = "\Guida di Chef Solution.chm"
   ' Percorso immagine per campo Logo Azienda.
   Public Const PERCORSO_IMG_LOGO As String = "\Immagini\Bianco.bmp"
   ' File .wave per riprodurre un suono alla pressione dei tasti in Visual POS.
   Public Const FILE_SUONO_CLICK As String = "\beep-7.wav"

   ' Stringhe del programma.
   Public Const CAR_ANAG_AZIENDA As String = "Attendere prego. Caricamento dell'anagrafica Dati generali Azienda in corso..."
   Public Const CAR_ANAG_AZIENDE As String = "Attendere prego. Caricamento dell'anagrafica Aziende in corso..."
   Public Const CAR_ANAG_CLIENTI As String = "Attendere prego. Caricamento dell'elenco Clienti in corso..."
   Public Const CAR_ANAG_FORNITORI As String = "Attendere prego. Caricamento dell'elenco Fornitori in corso..."
   Public Const CAR_ANAG_ARTICOLI As String = "Attendere prego. Caricamento dell'elenco Articoli e Ingredienti in corso..."
   Public Const CAR_ANAG_PIATTI As String = "Attendere prego. Caricamento dell'elenco Piatti in corso..."
   Public Const CAR_ANAG_TAVOLI As String = "Attendere prego. Caricamento dell'elenco Tavoli in corso..."
   Public Const CAR_ANAG_CAT_PIATTI As String = "Attendere prego. Caricamento dell'elenco Categorie piatti in corso..."
   Public Const CAR_ANAG_CAMERIERI As String = "Attendere prego. Caricamento dell'elenco Camerieri in corso..."
   Public Const CAR_ANAG_SALE As String = "Attendere prego. Caricamento dell'elenco Sale in corso..."
   Public Const CAR_SITUAZIONE_SCORTE As String = "Attendere prego. Caricamento dell'elenco Situazione Scorte in corso..."
   Public Const CAR_MOV_MAG As String = "Attendere prego. Caricamento dell'elenco Movimenti di magazzino in corso..."
   Public Const CAR_INVENTARIO As String = "Attendere prego. Caricamento dell'Inventario di magazzino in corso..."
   Public Const CAR_ACQUISTI As String = "Attendere prego. Caricamento dell'elenco Acquisti in corso..."
   Public Const CAR_ETICHETTE As String = "Attendere prego. Caricamento dell'elenco Etichette in corso..."
   Public Const CAR_PRIMA_NOTA As String = "Attendere prego. Caricamento della Prima Nota in corso..."
   Public Const CAR_DOCUMENTI As String = "Attendere prego. Caricamento dell'elenco Documenti in corso..."
   Public Const CAR_CHIUSURA As String = "Attendere prego. Caricamento della Chiusura giornaliera in corso..."
   Public Const CAR_CORRISPETTIVI As String = "Attendere prego. Caricamento dell'elenco Corrispettivi in corso..."
   Public Const CAR_ANAG_PREN As String = "Attendere prego. Caricamento dell'elenco Prenotazione Tavoli in corso..."
   Public Const CAR_ANAG_PREN_SALE As String = "Attendere prego. Caricamento dell'elenco Prenotazione Sale in corso..."
   Public Const CAR_POS As String = "Attendere prego. Caricamento dell'applicazione Visual POS in corso..."
   Public Const CAR_VC_TAVOLI As String = "Attendere prego. Caricamento dell'applicazione Visual POS in corso..."
   Public Const CAR_STAT As String = "Attendere prego. Caricamento delle statistiche di vendita in corso..."
   Public Const CAR_ANAG_RISORSE As String = "Attendere prego. Caricamento dell'elenco Risorse in corso..."
   Public Const CAR_ANAG_TIPOLOGIE_UTILIZZO_RISORSE As String = "Attendere prego. Caricamento dell'elenco Tipologie di utilizzo Risorse in corso..."
   Public Const CAR_ANAG_ACCESSORI_SERVIZI As String = "Attendere prego. Caricamento dell'elenco Accessori e Servizi in corso..."
   Public Const CAR_ANAG_PREN_RISORSE As String = "Attendere prego. Caricamento dell'elenco Prenotazioni risorse in corso..."
   Public Const CAR_ANAG_SCHEDINE_PS As String = "Attendere prego. Caricamento dell'elenco Schedine P.S. in corso..."
   Public Const CAR_ANAG_PREN_CAMERE As String = "Attendere prego. Caricamento dell'elenco Prenotazioni camere in corso..."
   Public Const CAR_PLANNING_P As String = "Attendere prego. Caricamento Planning di periodo delle risorse in corso..."
   Public Const CAR_PLANNING_CAMERE As String = "Attendere prego. Caricamento Planning di periodo delle camere in corso..."
   Public Const CAR_ANAG_CAMERE As String = "Attendere prego. Caricamento dell'elenco camere in corso..."
   Public Const CAR_REPORTS As String = "Attendere prego. Caricamento del Report in corso..."
   Public Const CAR_CAP As String = "Attendere prego. Caricamento dell'elenco CAP in corso..."
   Public Const CAR_EMAIL As String = "Attendere prego. Caricamento dell'elenco Email inviate in corso..."
   Public Const CAR_MESSAGGI As String = "Attendere prego. Caricamento dell'elenco Messaggi ai reparti in corso..."
   Public Const CAR_ANAG_OPERAZIONI As String = "Attendere prego. Caricamento del Registro operazioni in corso..."
   Public Const CAR_ANAG_OPERATORI As String = "Attendere prego. Caricamento dell'elenco Operatori in corso..."
   Public Const CAR_ANAG_GRUPPI As String = "Attendere prego. Caricamento dell'elenco Gruppi in corso..."
   Public Const CAR_TAB_STATO_PREN As String = "Attendere prego. Caricamento dell'elenco Stato prenotazioni in corso..."
   Public Const CAR_TAB_LISTINI_CAMERE As String = "Attendere prego. Caricamento dell'elenco Listini camere in corso..."
   Public Const CAR_TAB_STAGIONI As String = "Attendere prego. Caricamento delle Stagioni in corso..."
   Public Const DB_NON_COMPATIBILE As String = "Il file archivio selezionato non risulta compatibile con la versione in uso del programma."
   Public Const SALVA_BKP As String = "Attendere prego. Salvataggio della copia di Backup degli archivi in corso..."
   Public Const CAR_OPZIONI As String = "Attendere prego. Caricamento della finestra Opzioni di configurazione in corso..."

   ' Nomi utilizzati per i titoli delle finestre - INSERIRE ANCHE LE ALTRE!

   ' HOTEL.
   Public Const TITOLO_FINESTRA_ELENCO_PREN_CAMERE As String = "Elenco prenotazioni camere"
   Public Const TITOLO_FINESTRA_ELENCO_LISTINI_CAMERE As String = "Elenco Listini camere"
   Public Const TITOLO_FINESTRA_ELENCO_SCHEDINE_PS As String = "Elenco Schedine P.S."

   ' GESTIONE DOCUMENTI.
   Public Const TITOLO_FINESTRA_ELENCO_DOCUMENTI As String = "Elenco documenti di Vendita"

   ' E-MAIL.
   Public Const TITOLO_FINESTRA_ELENCO_EMAIL As String = "Elenco E-mail inviate"

#Region "Categorie E-mail "

   Public Const CATEGORIA_PREN_CAMERE As String = "Prenotazione"
   Public Const CATEGORIA_ARCHIVI As String = "Archivi"

#End Region


#Region "Registro Operazioni "

   ' Stringhe per identificare i moduli.
   Public Const MODULO_HOSPITALITY_SOLUTION As String = "HOSPITALITY SOLUTION"
   Public Const MODULO_GESTIONE_ACQUISTI As String = "GESTIONE ACQUISTI"
   Public Const MODULO_REG_OPERAZIONI As String = "REGISTRO OPERAZIONI"
   Public Const MODULO_REG_ERRORI As String = "REGISTRO DEGLI ERRORI"
   Public Const MODULO_ACCESSO_OPERATORE As String = "IDENTIFICAZIONE OPERATORE"
   Public Const MODULO_ANAGRAFICA_DATI_AZIENDA As String = "ANAGRAFICA DATI AZIENDA"
   Public Const MODULO_ANAGRAFICA_PIATTI As String = "ANAGRAFICA PIATTI"
   Public Const MODULO_ARCHIVI_BACKUP As String = "ARCHIVI BACKUP"
   Public Const MODULO_ARCHIVI_PULIZIA As String = "ARCHIVI PULIZIA"
   Public Const MODULO_ARCHIVI_COMPATTA As String = "ARCHIVI COMPATTA E RIPRISTINA"
   Public Const MODULO_CONTABILITA_CHIUSURA As String = "CONTABILITA' CHIUSURA GIORNALIERA"
   Public Const MODULO_CONTABILITA_CORRISPETTIVI As String = "CONTABILITA' CORRISPETTIVI"
   Public Const MODULO_CONTABILITA_DOCUMENTI As String = "CONTABILITA' DOCUMENTI"
   Public Const MODULO_CONTABILITA_PRIMA_NOTA As String = "CONTABILITA' PRIMA NOTA"
   Public Const MODULO_GESTIONE_STATISTICHE As String = "GESTIONE STATISTICHE BAR/RISTORANTE"
   Public Const MODULO_GESTIONE_STATISTICHE_CENTRO_SPORTIVO As String = "GESTIONE STATISTICHE CENTRO SPORTIVO"
   Public Const MODULO_GESTIONE_PLANNING_RISORSE As String = "GESTIONE PLANNING RISORSE SPORTIVE"
   Public Const MODULO_GESTIONE_PLANNING_CAMERE As String = "GESTIONE PLANNING CAMERE"
   Public Const MODULO_MAGAZZINO_INVENTARIO As String = "MAGAZZINO INVENTARIO"
   Public Const MODULO_MAGAZZINO_SCORTE As String = "MAGAZZINO SCORTE"
   Public Const MODULO_MAGAZZINO_MOVIMENTI As String = "MAGAZZINO STORICO MOVIMENTI"
   Public Const MODULO_STRUMENTI_DISPONI_TAVOLI As String = "STRUMENTI DISPONI TAVOLI"
   Public Const MODULO_STRUMENTI_CAP As String = "STRUMENTI C.A.P."
   Public Const MODULO_STRUMENTI_MSG_REPARTI As String = "STRUMENTI MESSAGGI AI REPARTI"
   Public Const MODULO_STRUMENTI_ETICHETTE As String = "STRUMENTI ETICHETTE E CODICI A BARRE"
   Public Const MODULO_STRUMENTI_MENU As String = "STRUMENTI FORMAZIONE MENU"
   Public Const MODULO_STRUMENTI_NOTE As String = "STRUMENTI BLOCCO NOTE"
   Public Const MODULO_STRUMENTI_CALCOLATRICE As String = "STRUMENTI CALCOLATRICE"
   Public Const MODULO_OPZIONI As String = "VISUALIZZA OPZIONI"
   Public Const MODULO_CONTO As String = "STAMPA CONTO"
   Public Const MODULO_GESTIONE_POS As String = "GESTIONE PUNTO CASSA"
   Public Const MODULO_TAVOLI As String = "GESTIONE TAVOLI E CONTO"
   Public Const MODULO_PIATTI_ESAURITI As String = "GESTIONE PIATTI ESAURITI"

   ' Elenco dati.
   Public Const MODULO_ANAGRAFICA_CLIENTI As String = "ANAGRAFICA CLIENTI"
   Public Const MODULO_ANAGRAFICA_AZIENDE As String = "ANAGRAFICA AZIENDE"
   Public Const MODULO_ANAGRAFICA_FORNITORI As String = "ANAGRAFICA FORNITORI"
   Public Const MODULO_ANAGRAFICA_CAT_PIATTI As String = "ANAGRAFICA CATEGORIE PIATTI"
   Public Const MODULO_ANAGRAFICA_CAMERIERI As String = "ANAGRAFICA CAMERIERI"
   Public Const MODULO_ANAGRAFICA_SALE As String = "ANAGRAFICA SALE"
   Public Const MODULO_ANAGRAFICA_TAVOLI As String = "ANAGRAFICA TAVOLI"
   Public Const MODULO_ANAGRAFICA_CAMERE As String = "ANAGRAFICA CAMERE"
   Public Const MODULO_ANAGRAFICA_RISORSE As String = "ANAGRAFICA RISORSE"
   Public Const MODULO_ANAGRAFICA_ACCESSORI_SERVIZI As String = "ANAGRAFICA ACCESSORI E SERVIZI"
   Public Const MODULO_GESTIONE_GRUPPI As String = "GESTIONE GRUPPI"
   Public Const MODULO_GESTIONE_OPERATORI As String = "GESTIONE OPERATORI"
   Public Const MODULO_GESTIONE_PREN_TAVOLI As String = "GESTIONE PRENOTAZIONI TAVOLI"
   Public Const MODULO_GESTIONE_PREN_SALE As String = "GESTIONE PRENOTAZIONI SALE"
   Public Const MODULO_GESTIONE_PREN_RISORSE As String = "GESTIONE PRENOTAZIONI RISORSE"
   Public Const MODULO_MAGAZZINO_ARTICOLI As String = "MAGAZZINO ARTICOLI E INGREDIENTI"

   ' Tabelle.
   Public Const MODULO_TABELLA_QUALIFICHE As String = "TABELLA FORME DI CORTESIA"
   Public Const MODULO_TABELLA_CAT_CLIENTE As String = "TABELLA CATEGORIE CLIENTE"
   Public Const MODULO_TABELLA_ATTIVITA As String = "TABELLA ATTIVITA'"
   Public Const MODULO_TABELLA_NAZIONI As String = "TABELLA NAZIONI"
   Public Const MODULO_TABELLA_UM As String = "TABELLA UNITA' DI MISURA"
   Public Const MODULO_TABELLA_CAT_MERCE As String = "TABELLA CATEGORIE MERCEOLOGICHE"
   Public Const MODULO_TABELLA_MAGAZZINI As String = "TABELLA MAGAZZINI"
   Public Const MODULO_TABELLA_UBICAZIONI As String = "TABELLA UBICAZIONI"
   Public Const MODULO_TABELLA_SCAFFALI As String = "TABELLA SCAFFALI"
   Public Const MODULO_TABELLA_REPARTI As String = "TABELLA REPARTI"
   Public Const MODULO_TABELLA_MSG_REP As String = "TABELLA MESSAGGI PER I REPARTI"
   Public Const MODULO_TABELLA_CAUSALI_DOC As String = "TABELLA CAUSALI DOCUMENTO"
   Public Const MODULO_TABELLA_PAGAMENTI As String = "TABELLA MODALITA' DI PAGAMENTO"
   Public Const MODULO_TABELLA_TIPO_RISORSE As String = "TABELLA TIPOLOGIE RISORSE"
   Public Const MODULO_TABELLA_TIPOLOGIE_CAMERE As String = "TABELLA TIPOLOGIE CAMERE"
   Public Const MODULO_TABELLA_UBICAZIONI_CAMERE As String = "TABELLA UBICAZIONI CAMERE"
   Public Const MODULO_TABELLA_POSIZIONI_CAMERE As String = "TABELLA POSIZIONI CAMERE"
   Public Const MODULO_TABELLA_STATO_PREN As String = "TABELLA STATO PRENOTAZIONI"
   Public Const MODULO_TABELLA_DOC_IDENTITA As String = "TABELLA DOCUMENTI IDENTITA"
   Public Const MODULO_TABELLA_GRUPPI_OSPITI As String = "TABELLA GRUPPI"
   Public Const MODULO_TABELLA_AGENZIE As String = "TABELLA AGENZIE"
   Public Const MODULO_TABELLA_CANALI As String = "TABELLA CANALI DI PROVENIENZA"
   Public Const MODULO_TABELLA_TIPO_ALLOGGIATO As String = "TABELLA TIPO ALLOGGIATO"
   Public Const MODULO_TABELLA_COMUNI As String = "TABELLA COMUNI"

   ' Stringhe per la descrizione delle operazioni.
   Public Const STR_HOSPITALITY As String = "Hospitality Solution."
   Public Const STR_ELENCO_ACQUISTI As String = "l'elenco Acquisti."
   Public Const STR_REGISTRO_OPERAZIONI As String = "il Registro Operazioni."
   Public Const STR_REG_ERRORI As String = "il Registro degli errori."
   Public Const STR_ANAGRAFICA_DATI_AZIENDA As String = "l'anagrafica Dati generali azienda."
   Public Const STR_ANAGRAFICA_PIATTI As String = "l'elenco Piatti."
   Public Const STR_ANAGRAFICA_INGREDIENTI_PIATTI As String = "l'elenco Ingredienti dei Piatti."
   Public Const STR_ARCHIVI_PULIZIA As String = "la Pulizia degli archivi."
   Public Const STR_CONTABILITA_CHIUSURA As String = "la Chiusura giornaliera."
   Public Const STR_CONTABILITA_CORRISPETTIVI As String = "l'elenco Corrispettivi"
   Public Const STR_CONTABILITA_DOCUMENTI As String = "l'elenco Documenti."
   Public Const STR_CONTABILITA_PRIMA_NOTA As String = "Prima nota."
   Public Const STR_GESTIONE_STATISTICHE As String = "le Statistiche di vendita per il Bar/Ristorante."
   Public Const STR_GESTIONE_STATISTICHE_CENTRO_SPORTIVO As String = "le Statistiche di vendita per il Centro sportivo."
   Public Const STR_GESTIONE_PLANNING_RISORSE As String = "il Planning Risorse sportive."
   Public Const STR_MAGAZZINO_INVENTARIO As String = "l'Inventario di magazzino."
   Public Const STR_MAGAZZINO_SCORTE As String = "la Situazione scorte."
   Public Const STR_MAGAZZINO_MOVIMENTI As String = "i Movimenti di magazzino."
   Public Const STR_STRUMENTI_DISPONI_TAVOLI As String = "Disponi tavoli."
   Public Const STR_STRUMENTI_CAP As String = "l'elenco C.A.P."
   Public Const STR_STRUMENTI_MSG_REPARTI As String = "i Messaggi ai reparti."
   Public Const STR_STRUMENTI_ETICHETTE As String = "l'elenco Etichette."
   Public Const STR_STRUMENTI_MENU As String = "la Formazione del Menù."
   Public Const STR_STRUMENTI_NOTE As String = "il Blocco note."
   Public Const STR_STRUMENTI_CALCOLATRICE As String = "la Calcolatrice."
   Public Const STR_OPZIONI As String = "le Opzioni."
   Public Const STR_CONTO As String = "la Stampa del conto."
   Public Const STR_PUNTO_CASSA As String = "il Punto cassa."
   Public Const STR_TAVOLI As String = "la Gestione dei Tavoli."
   Public Const STR_PIATTI_ESAURITI As String = "la Gestione Piatti esauriti."

   ' Elenco dati.
   Public Const STR_ANAGRAFICA_CLIENTI As String = "l'elenco Clienti."
   Public Const STR_ANAGRAFICA_AZIENDE As String = "l'elenco Aziende."
   Public Const STR_ANAGRAFICA_FORNITORI As String = "l'elenco Fornitori."
   Public Const STR_ANAGRAFICA_CAT_PIATTI As String = "l'elenco Categorie piatti."
   Public Const STR_ANAGRAFICA_CAMERIERI As String = "l'elenco Camerieri."
   Public Const STR_ANAGRAFICA_SALE As String = "l'elenco Sale."
   Public Const STR_ANAGRAFICA_TAVOLI As String = "l'elenco Tavoli."
   Public Const STR_ANAGRAFICA_CAMERE As String = "l'elenco Camere."
   Public Const STR_ANAGRAFICA_RISORSE As String = "l'elenco Risorse."
   Public Const STR_ANAGRAFICA_ACCESSORI_SERVIZI As String = "l'elenco Accessori e servizi."
   Public Const STR_GESTIONE_GRUPPI As String = "l'elenco Gruppi."
   Public Const STR_GESTIONE_OPERATORI As String = "l'elenco Operatori."
   Public Const STR_GESTIONE_PREN_TAVOLI As String = "l'elenco Prenotazioni tavoli."
   Public Const STR_GESTIONE_PREN_SALE As String = "l'elenco Prenotazione sale."
   Public Const STR_GESTIONE_PREN_RISORSE As String = "l'elenco Prenotazione risorse."
   Public Const STR_MAGAZZINO_ARTICOLI As String = "l'elenco Articoli e ingredienti."

   ' Tabelle.
   Public Const STR_TABELLA_QUALIFICHE As String = "la tabella Forme di cortesia."
   Public Const STR_TABELLA_CAT_CLIENTE As String = "la tabella Categorie cliente."
   Public Const STR_TABELLA_ATTIVITA As String = "la tabella Attività."
   Public Const STR_TABELLA_NAZIONI As String = "la tabella Nazioni."
   Public Const STR_TABELLA_UM As String = "la tabella Unità di misura."
   Public Const STR_TABELLA_CAT_MERCE As String = "la tabella Categorie merceologiche."
   Public Const STR_TABELLA_MAGAZZINI As String = "la tabella Magazzini."
   Public Const STR_TABELLA_UBICAZIONI As String = "la tabella Ubicazioni."
   Public Const STR_TABELLA_SCAFFALI As String = "la tabella Scaffali."
   Public Const STR_TABELLA_REPARTI As String = "la tabella Reparti."
   Public Const STR_TABELLA_MSG_REP As String = "la tabella Messaggi per i reparti."
   Public Const STR_TABELLA_CAUSALI_DOC As String = "la tabella Causali documento."
   Public Const STR_TABELLA_PAGAMENTI As String = "la tabella Modalità di pagamento."
   Public Const STR_TABELLA_TIPO_RISORSE As String = "la tabella Tipologie risorse."
   Public Const STR_TABELLA_TIPOLOGIE_CAMERE As String = "la tabella Tipologie camere."
   Public Const STR_TABELLA_UBICAZIONI_CAMERE As String = "la tabella Ubicazioni camere."
   Public Const STR_TABELLA_POSIZIONI_CAMERE As String = "la tabella Documenti d'identità."
   Public Const STR_TABELLA_STATO_PREN As String = "la tabella Stato prenotazioni."
   Public Const STR_TABELLA_DOC_IDENTITA As String = "la tabella Stato prenotazioni."
   Public Const STR_TABELLA_GRUPPI As String = "la tabella Gruppi."
   Public Const STR_TABELLA_AGENZIE As String = "la tabella Agenzie."
   Public Const STR_TABELLA_CANALI As String = "la tabella Canali di provenienza."
   Public Const STR_TABELLA_TIPO_ALLOGGIATO As String = "la tabella Tipo alloggiato."
   Public Const STR_TABELLA_COMUNI As String = "la tabella Comuni."

#End Region

   ' Nome del prodotto in uso.
   Public NOME_PRODOTTO As String = NOME_PRODOTTO_HOSPITALITY_SUITE

   ' Per registrare le operazioni.
   Public strModulo As String

   ' Ottiene i Separatori per la data e l'ora impostati nel Sistema Operativo.
   Public dataFormat As New Globalization.DateTimeFormatInfo
   Public sepData As String = dataFormat.DateSeparator
   Public sepOra As String = dataFormat.TimeSeparator

   ' Dimensione della pagina.
   Public dimPagina As Integer

   ' Identificano se un form è aperto (visibile) o no.
   Public g_frmMain As frmMain
   Public g_frmAzienda As frmAzienda
   Public g_frmAziende As frmElencoDati
   Public g_frmClienti As frmElencoDati
   Public g_frmFornitori As frmElencoDati
   Public g_frmArticoli As frmElencoDati
   Public g_frmScorte As ElencoScorte
   Public g_frmInventario As ElencoInventario
   Public g_frmMovMag As ElencoMovMag
   Public g_frmPiatti As frmElencoPiatti
   Public g_frmTavoli As frmElencoDati
   Public g_frmCoperti As CopertiPOS
   Public g_frmAsporto As AsportoPOS
   Public g_frmCatPiatti As frmElencoDati
   Public g_frmCamerieri As frmElencoDati
   Public g_frmSale As frmElencoDati
   Public g_frmPren As frmElencoDati
   Public g_frmPrenSale As frmElencoDati
   Public g_frmPos As frmPos
   Public g_frmContoPos As ContoPos
   Public g_frmVCTavoli As frmVCTavoli
   Public g_frmVCPren As frmElencoPren
   Public g_frmStatistiche As frmStatistiche
   Public g_frmPrimaNota As PrimaNota
   Public g_frmAcquisti As frmElencoAcquisti
   Public g_frmEtichette As ElencoEtichette
   Public g_frmDocumenti As ElencoDoc
   Public g_frmDocumento As frmDocumento
   Public g_frmFatturaElettronica As frmFatturaElettronica
   Public g_frmCorrispettivi As ElencoCorrispettivi
   Public g_frmMenu As Menu
   Public g_frmCap As ElencoCAP
   Public g_frmMessaggi As ElencoMessaggi
   Public g_frmOperatori As frmElencoDati
   Public g_frmGruppi As frmElencoDati
   Public g_frmOperazioni As RegOperazioni
   Public g_frmRisorse As frmElencoDatiSport
   Public g_frmPrenRisorse As frmElencoDatiSport
   Public g_frmDatiPrenRisorse As frmPrenRisorse
   Public g_frmCaratteristicheRisorse As frmElencoDati
   Public g_frmAccessoriServizi As frmElencoDatiSport
   Public g_frmPlanningSport1 As frmPlanningP
   Public g_frmPlanningSport2 As frmPlanningP
   Public g_frmPlanningSport3 As frmPlanningP
   Public g_frmPlanningSport4 As frmPlanningP
   Public g_frmStatisticheRisorse As frmStatisticheRisorse
   Public g_frmPlanningCamere As PlanningCamere
   Public g_frmCamere As frmElencoDati
   Public g_frmPrenCamere As ElencoPrenCamere
   Public g_frmPrenCamera As frmPrenCamera
   Public g_frmStatoPren As frmElencoDati
   Public g_frmSchedinePS As ElencoSchedinePS
   Public g_frmSchedinaPS As frmSchedinaPS
   Public g_frmListiniCamere As ElencoListiniCamere
   Public g_frmStagioni As frmStagioni
   Public g_frmEmail As ElencoEmail

   ' Dati di accesso dell'operatore.
   Public Structure strOperatore
      Public Codice As String
      Public Nome As String
      Public Pwd As String
      Public Gruppo As String
      Public Amministratore As String
      Public AnagAziende As String
      Public AnagCamerieri As String
      Public AnagCatPiatti As String
      Public AnagClienti As String
      Public AnagDatiAzienda As String
      Public AnagFornitori As String
      Public AnagPiatti As String
      Public AnagSale As String
      Public AnagTavoli As String
      Public AnagCamere As String
      Public AnagRisorse As String
      Public AnagAccessoriServizi As String
      Public ArchiviBackup As String
      Public ArchiviCompatta As String
      Public ArchiviPulizia As String
      Public TabAttività As String
      Public TabCatClienti As String
      Public TabCatMerce As String
      Public TabFormeCortesia As String
      Public TabMagazzini As String
      Public TabMsg As String
      Public TabNazioni As String
      Public TabPagamenti As String
      Public TabPiani As String
      Public TabReparti As String
      Public TabScaffali As String
      Public TabCausaliDoc As String
      Public TabUbicazioni As String
      Public TabUM As String
      Public TabTipoRisorse As String
      Public TabListini As String
      Public TabTipologieCamere As String
      Public TabUbicazioniCamere As String
      Public TabPosizioniCamere As String
      Public TabStatoPren As String
      Public TabDocIdentità As String
      Public ContChiusura As String
      Public ContCorrispettivi As String
      Public ContDoc As String
      Public ContPrimaNota As String
      Public GestAcquisti As String
      Public GestGruppi As String
      Public GestOperatori As String
      Public GestPrenSale As String
      Public GestPrenTavoli As String
      Public GestPrenRisorse As String
      Public GestPlanningRisorse As String
      Public GestPlanningCamere As String
      Public GestStatRisorse As String
      Public GestPuntoCassa As String
      Public GestStatistiche As String
      Public GestTavoli As String
      Public MagArticoli As String
      Public MagInventario As String
      Public MagScorte As String
      Public MagMovimenti As String
      Public StruDispTavoli As String
      Public StruCap As String
      Public StruMsg As String
      Public StruCodiciBarre As String
      Public StruMenù As String
      Public VisOpzioni As String
      Public VisErrori As String
      Public VisOperazioni As String

      Public Sub EliminaDati()
         Nome = String.Empty
         Pwd = String.Empty
         Gruppo = String.Empty
         Amministratore = String.Empty
         AnagAziende = String.Empty
         AnagCamerieri = String.Empty
         AnagCatPiatti = String.Empty
         AnagClienti = String.Empty
         AnagDatiAzienda = String.Empty
         AnagFornitori = String.Empty
         AnagPiatti = String.Empty
         AnagSale = String.Empty
         AnagTavoli = String.Empty
         AnagCamere = String.Empty
         AnagRisorse = String.Empty
         AnagAccessoriServizi = String.Empty
         ArchiviBackup = String.Empty
         ArchiviCompatta = String.Empty
         ArchiviPulizia = String.Empty
         TabAttività = String.Empty
         TabCatClienti = String.Empty
         TabCatMerce = String.Empty
         TabFormeCortesia = String.Empty
         TabMagazzini = String.Empty
         TabMsg = String.Empty
         TabNazioni = String.Empty
         TabPagamenti = String.Empty
         TabPiani = String.Empty
         TabReparti = String.Empty
         TabScaffali = String.Empty
         TabCausaliDoc = String.Empty
         TabUbicazioni = String.Empty
         TabUM = String.Empty
         TabTipoRisorse = String.Empty
         TabListini = String.Empty
         TabTipologieCamere = String.Empty
         TabUbicazioniCamere = String.Empty
         TabPosizioniCamere = String.Empty
         TabStatoPren = String.Empty
         TabDocIdentità = String.Empty
         ContChiusura = String.Empty
         ContCorrispettivi = String.Empty
         ContDoc = String.Empty
         ContPrimaNota = String.Empty
         GestAcquisti = String.Empty
         GestGruppi = String.Empty
         GestOperatori = String.Empty
         GestPrenSale = String.Empty
         GestPrenTavoli = String.Empty
         GestPrenRisorse = String.Empty
         GestPlanningRisorse = String.Empty
         GestPlanningCamere = String.Empty
         GestStatRisorse = String.Empty
         GestPuntoCassa = String.Empty
         GestStatistiche = String.Empty
         GestTavoli = String.Empty
         MagArticoli = String.Empty
         MagInventario = String.Empty
         MagScorte = String.Empty
         MagMovimenti = String.Empty
         StruDispTavoli = String.Empty
         StruCap = String.Empty
         StruMsg = String.Empty
         StruCodiciBarre = String.Empty
         StruMenù = String.Empty
         VisOpzioni = String.Empty
         VisErrori = String.Empty
         VisOperazioni = String.Empty
      End Sub
   End Structure

   Public operatore As New strOperatore

   ' Stringa connessione.
   Public ConnString As String
   Public ConnStringAnagrafiche As String
   Public ConnStringCAP As String
   ' Percorso db.
   Public PercorsoDB As String
   Public PercorsoDBClienti As String
   Public PercorsoBKP As String
   Public SalvaBKP As Boolean
   Public NomeDB As String
   ' Gestione palmare.
   Public PercorsoRP As String
   Public AbilitaPalmareWindows As Boolean
   Public AbilitaPalmareAndroid As Boolean
   Public FreqAggPalmare As Short
   ' Modalità del programma (in rete o locale)
   Public ModApp As String

   ' Totale del conto per le stampe.
   Public TotaleContoRep As String = ""

   ' Percorsi di stampa per le comande e i documenti.
   Public PercorsiStampantiComande(10) As String
   Public PercorsiStampantiDocumenti(3) As String

   ' Dati di configurazione per le stampanti fiscali.
   Public ProduttoreSF As String
   Public ModelloSF As String
   ' RCH Swing A/65 ECR.
   Public PortaSF As String
   Public ParametriSF As String
   Public NomeScontrinoSF As String
   Public PercorsoOutputSF As String
   Public PercorsoDriverSF As String
   ' Driver RTS Wpos1.
   Public PercorsoDriverWpos1 As String
   Public PercorsoLavoroWpos1 As String
   Public PwdDriverWpos1 As String
   Public EstensioneFileWpos1 As String

   ' Utilizzata da comando Proforma per sapere se mantenere i dati del Tavolo.
   Public mantieniDatiTavolo As Boolean

   ' Attiva-disattiva la versione demo (True = Demo / False = Completa)
   Public g_VerDemo As Boolean = False
   Public giorniVerDemo As String

    ' Chiave per la generazione della licenza.
   Public Const CHIAVE_ATTIVAZIONE As String = "C1DM0" ' Vecchia non utilizzata.
   Public Const CHIAVE_ATTIVAZIONE_HOSPITALITY As String = "HS3M0"
   Public Const CHIAVE_ATTIVAZIONE_HOTEL As String = "HM311"
   Public Const CHIAVE_ATTIVAZIONE_RISTORANTE As String = "CS3M1"
   Public Const CHIAVE_ATTIVAZIONE_BAR As String = "BS3M2"
   Public Const CHIAVE_ATTIVAZIONE_MAGAZZINO As String = "MG3M3"
   Public Const CHIAVE_ATTIVAZIONE_ETICHETTE As String = "ET3M4"
   Public Const CHIAVE_ATTIVAZIONE_PALMARI As String = "PM3M5"
   Public Const CHIAVE_ATTIVAZIONE_PENDRIVE_RECOVERY As String = "PR3M6"
   Public Const CHIAVE_ATTIVAZIONE_PENDRIVE_PORTABLE As String = "PP3M7"
   Public Const CHIAVE_ATTIVAZIONE_CENTRO_SPORTIVO As String = "SS3M8"
   Public Const CHIAVE_ATTIVAZIONE_REG_CASSA As String = "RC3M9"
   Public Const CHIAVE_ATTIVAZIONE_PREN_ONLINE As String = "PO310"
   Public Const CHIAVE_ATTIVAZIONE_FATT_ELETTRONICA As String = "FE3PA"

   ' Codice di accesso per attivare la versione dimostrativa del software. (NON PIU' UTILIZZATA)
   Public Const CHIAVE_ACCESSO_DEMO As String = "0274M F30HS M1083 0ZY3I 90DH2"
   ' Testo che compare nel titolo del programma.
   Public Const VER_DEMO As String = "VERSIONE DIMOSTRATIVA"
   ' Numero di serie del prodotto. (VERSIONE_FILE - VERSIONE_PRODOTTO - DATA_RILASCIO - ORA_RILASCIO)
   Public Const NUMERO_SERIE As String = "03310-003-3112018-01529"
   ' Numero di elementi inseribili per la versione demo.
   Public Const NUM_ELEMENTI_DEMO As Integer = 16
   ' File per la data di installazione.
   Public Const FILE_DATA_DEMO As String = "\Interop.HSS.dll"

   ' Dati per la versione demo nel registro di sistema.
   ' Non più utilizzata.
   Public Const REG_CARTELLA_DEMO As String = "Hs"

   ' Dati Ristorante.
   Public AliquotaIvaRistorante As String
   Public NumCopertiRistorante As String
   Public CopertoRistorante As String
   Public ServizioRistorante As String
   Public EffettiSonoriPOS As Boolean

   ' Dati Hotel.
   Public AliquotaIvaHotel As String
   Public ServizioHotel As String

   ' Dati Centro Sportivo.
   Public AliquotaIvaCentroSportivo As String

   ' Dati Modulo prenotazioni on-line.
   Public PercorsoCartellaTavAgent As String
   Public EffettoSonoroPren As Boolean
   Public AbilitaRicezionePren As Boolean
   Public ColorePrenTavAgent As Color

   ' Contatore per sapere il numero di finestre MDI aperte.
   Public NumeroCopieStampa As Short = 1

   ' Contatore per sapere il numero di finestre MDI aperte.
   Public NumFormMdiAperti As Integer

   Public err As New Varie.Errore

   ' Serve per aprire il form ElencoDati ed ElencoDatiSport con le rispettive tabelle Database.
   Public Enum Elenco
      Clienti = 1
      PrenSale = 2
      Prenotazioni = 3
      Fornitori = 4
      CatPiatti = 5
      Camerieri = 6
      Sale = 7
      Tavoli = 8
      Articoli = 9
      Aziende = 10
      Operatori = 11
      Gruppi = 12
      Risorse = 13
      AccessoriServizi = 14
      Camere = 15
      StatoPren = 16
      CaratteristicheRisorse = 17
   End Enum

   Public Const NUMERO_TOT_ENUM_FINESTRA As Integer = 64

   Public Enum Finestra
      ' Anagrafiche
      Clienti = 1
      Fornitori = 2
      Camerieri = 3
      Aziende = 4
      Sale = 5
      Tavoli = 6
      Piatti = 7
      CatPiatti = 8
      DatiAzienda = 9

      ' Tabelle
      FormeCortesia = 10
      CatCliente = 11
      Attività = 12
      Nazioni = 13
      UnitàMisura = 14
      CatMerce = 15
      Magazzini = 16
      Ubicazioni = 17
      Scaffali = 18
      Reparti = 19
      MsgReparti = 20
      CausaliDoc = 21
      Pagamenti = 22
      Piani = 23

      ' Archivi
      Backup = 24
      Pulizia = 25
      Compatta = 26

      ' Gestione
      PuntoCassa = 27
      TavoliConto = 28
      PrenSale = 29
      PrenTavoli = 30
      Menù = 31
      Acquisti = 32
      Statistiche = 33
      Operatori = 34
      Gruppi = 35

      ' Contabilità
      ChiusuraGiornaliera = 36
      Corrispettivi = 37
      Documenti = 38
      PrimaNota = 39

      ' Magazzino
      Articoli = 40
      MovimentiMag = 41
      Inventario = 42
      Scorte = 43

      ' Visualizza
      Opzioni = 44
      RegOperazioni = 45
      RegErrori = 46

      ' Strumenti
      DisponiTavoli = 47
      ElencoMsg = 48
      ElencoCap = 49
      CodiciBarre = 50

      ' Sporting - Gestione
      Risorse = 51
      PrenRisorse = 52
      AccessoriServizi = 53
      StatisticheRisorse = 54
      PlanningRisorse = 55
      TipologieRisorse = 56

      ' Hotel
      Listini = 57
      TipologieCamere = 58
      UbicazioniCamere = 59
      PosizioniCamere = 60
      Camere = 61
      PlanningCamere = 62
      StatoPren = 63
      DocIdentità = 64
      GruppiOspiti = 65
      Agenzie = 66
      CanaliVendita = 67
      TipoAlloggiato = 68
      Comuni = 69

   End Enum

   Public Enum TipoOperazione
      Nuovo = 1
      Modifica = 2
      Elimina = 3
      EliminaTutto = 4
      Aggiorna = 5
      Anteprima = 6
      Stampa = 7
      Apri = 8
      Chiudi = 9
      Salva = 10
      Annulla = 11
      Login = 12
      Logout = 13
      Carico = 14
      Scarico = 15
      Backup = 16
      Pulizia = 17
      Compatta = 18
      Chiusura = 19
      AnnullaDoc = 20
      IncassaSospeso = 21
      PassaSospeso = 22
      AnnullaSospeso = 23
      ModificaMenù = 24
      InviaMsg = 25
      SelezionaPiatto = 26
      Listino = 27
      QuantitàMeno = 28
      QuantitàPiù = 29
      Cancella = 30
      CancellaTutto = 31
      Escludi = 32
      Conferma = 33
      Proforma = 34
      Scontrino = 35
      Ricevuta = 36
      Fattura = 37
      ApriTavolo = 38
      ChiudiTavolo = 39
      SpostaTavolo = 40
      OccupaTavolo = 41
      LiberaTavolo = 42
      ApriAsporto = 43
      ChiudiAsporto = 44
      Prenota = 45
      PiattiEsauriti = 46
      RimuoviPiatto = 47
      ProprietàRisorsa = 48
      Offerto = 49
   End Enum

   ' Dati Moduli.
   Public Structure Modulo
      ' Nome Moduli
      Public Const NOME_HOSPITALITY As String = "HOSPITALITY SOLUTION SUITE"
      Public Const NOME_MAGAZZINO As String = "MAGAZZINO"
      Public Const NOME_ETICHETTE As String = "ETICHETTE E CODICI A BARRE"
      Public Const NOME_PENDRIVE_PORTABLE As String = "PEN DRIVE PORTABLE"
      Public Const NOME_PENDRIVE_RECOVERY As String = "PEN DRIVE RECOVERY"
      Public Const NOME_REG_CASSA As String = "REGISTRATORI DI CASSA"
      Public Const NOME_FATT_ELETTRONICA As String = "FATTURAZIONE ELETTRONICA"

      Public Const NOME_BAR As String = "BAR SOLUTION"

      Public Const NOME_CHEF As String = "CHEF SOLUTION"
      Public Const NOME_PALMARI As String = "PALMARI"
      Public Const NOME_PREN_ONLINE As String = "PRENOTAZIONI ON-LINE"

      Public Const NOME_HOTEL As String = "HOTEL SOLUTION"
      Public Const NOME_CAMPING As String = "CAMPING SOLUTION"
      Public Const NOME_BEACH As String = "BEACH SOLUTION"
      Public Const NOME_BEAUTY As String = "BEAUTY SOLUTION"
      Public Const NOME_SPORTING As String = "SPORTING CLUB SOLUTION"

      Public Const NOME_RETAIL As String = "RETAIL SOLUTION"
      Public Const NOME_TAGLIE_COLORI As String = "TAGLIE E COLORI"

      ' Nome Moduli per la chiave del file .config
      Public Const NOME_HOSPITALITY_CONFIG As String = "KeyAccessHospitality"
      Public Const NOME_MAGAZZINO_CONFIG As String = "KeyAccessMagazzino"
      Public Const NOME_ETICHETTE_CONFIG As String = "KeyAccessEtichette"
      Public Const NOME_PENDRIVE_PORTABLE_CONFIG As String = "KeyAccessPenDrivePortable"
      Public Const NOME_PENDRIVE_RECOVERY_CONFIG As String = "KeyAccessPenDriveRecovery"
      Public Const NOME_REG_CASSA_CONFIG As String = "KeyAccessRegCassa"
      Public Const NOME_FATT_ELETTRONICA_CONFIG As String = "KeyAccessFattElettronica"

      Public Const NOME_BAR_CONFIG As String = "KeyAccessBar"

      Public Const NOME_CHEF_CONFIG As String = "KeyAccessRistorante"
      Public Const NOME_PALMARI_CONFIG As String = "KeyAccessPalmari"
      Public Const NOME_PREN_ONLINE_CONFIG As String = "KeyAccessPrenOnLine"

      Public Const NOME_HOTEL_CONFIG As String = "KeyAccessHotel"
      Public Const NOME_CAMPING_CONFIG As String = "KeyAccessCamping"
      Public Const NOME_BEACH_CONFIG As String = "KeyAccessBeach"
      Public Const NOME_BEAUTY_CONFIG As String = "KeyAccessBeauty"
      Public Const NOME_SPORTING_CONFIG As String = "KeyAccessSporting"

      Public Const NOME_RETAIL_CONFIG As String = "KeyAccessRetail"
      Public Const NOME_TAGLIE_COLORI_CONFIG As String = "KeyAccessTaglieColori"

      ' Moduli attivi
      Public Hospitality As Boolean
      Public Magazzino As Boolean
      Public Etichette As Boolean
      Public PenDrivePortable As Boolean
      Public PenDriveRecovery As Boolean
      Public RegCassa As Boolean
      Public FattElettronica As Boolean

      Public Bar As Boolean

      Public Ristorante As Boolean
      Public Palmari As Boolean
      Public PrenOnLine As Boolean

      Public Hotel As Boolean
      Public Campeggio As Boolean
      Public CentroBalneare As Boolean
      Public CentroBenessere As Boolean
      Public CentroSportivo As Boolean

      Public VenditaDettaglio As Boolean
      Public TaglieColori As Boolean

   End Structure

   Public moduloAttivo As New Modulo

   Public tipoCliente As Short = Cliente.Azienda

   Public Enum Cliente As Short
      Azienda = 1
      Privato = 2
   End Enum

   ' Tipologia di Planning per le Risorse Sportive.
   Public Const PLANNING_1 As String = "Planning 1 - (Inizio ore: 6:00 - Prenotazione minima mezz'ora)"
   Public Const PLANNING_2 As String = "Planning 2 - (Inizio ore: 6:45 - Prenotazione minima un'ora)"
   Public Const PLANNING_3 As String = "Planning 3 - (Inizio ore: 7:00 - Prenotazione minima un'ora)"
   Public Const PLANNING_4 As String = "Planning 4 - (Inizio ore: 7:15 - Prenotazione minima un'ora)"

   Public Enum TipoPlanning
      Planning1 = 1
      Planning2 = 2
      Planning3 = 3
      Planning4 = 4
   End Enum

End Module
