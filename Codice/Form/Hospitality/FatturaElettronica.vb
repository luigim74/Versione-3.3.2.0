#Region " DATI FILE.VB "
' ***************************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       29/10/2018
' Data ultima modifica: 14/01/2019
' Descrizione:          Form per la compilazione della Fattura elettronica con generazione file XML.
' Note:
'
' Elenco Attivita:
'
'
' ***************************************************************************************************
#End Region

Imports FatturaElettronica
Imports FatturaElettronica.Validators
Imports FatturaElettronica.Impostazioni
Imports System.Xml
Imports System.IO
Imports Elegant.Ui

Public Class frmFatturaElettronica

   Const TAB_DOCUMENTI As String = "Documenti"
   Const TAB_DETTAGLI_DOCUMENTI As String = "DettagliDoc"
   Const IT_ITALIA As String = "IT Italia"

   Private Doc As New Documenti
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress
   Private nomeDirectory As String = Application.StartupPath & "\" & CARTELLA_FATTURE_ELETTRONICHE & "\" & Today.Year.ToString
   Private idDocumento As String
   Private idCliente As String

   Public Sub New(ByVal idDoc As String, ByVal idCli As String)

      ' La chiamata è richiesta dalla finestra di progettazione.
      InitializeComponent()

      idDocumento = idDoc
      idCliente = idCli

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

   Private Sub EsempioFatt()
      'Dim fatturaXlm As Fattura = Fattura.CreateInstance(Instance.PubblicaAmministrazione)

      'Dim settings As New XmlReaderSettings()
      'settings.IgnoreWhitespace = True
      'settings.IgnoreComments = True

      '' Modifica proprietà Header.
      'fatturaXlm.Header.CedentePrestatore.Sede.Indirizzo = "Via Dolcedo, 121"

      'fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = "Bianchi Srl"

      'Dim settingsW As New XmlWriterSettings()
      'settingsW.Indent = True

      '' Serializzazione XML
      'Using writer As XmlWriter = XmlWriter.Create("Documenti\IT01234567890_FPA01.xml", settingsW)
      '   fatturaXlm.WriteXml(writer)
      'End Using

      '' Lettura da file XML
      'Using reader As XmlReader = XmlReader.Create("IT01234567890_FPA02.xml", settings)
      '   fatturaXlm.ReadXml(reader)
      'End Using

      'For Each doc As FatturaElettronicaBody.Body In fatturaXlm.Body
      '   Me.Text = doc.DatiGenerali.DatiGeneraliDocumento.Numero & " - " & doc.DatiGenerali.DatiGeneraliDocumento.Data
      'Next

      '' Convalida del documento.
      'Dim validator As New FatturaValidator
      'Dim risultato As FluentValidation.Results.ValidationResult = validator.Validate(fatturaXlm)
      'Me.Text = risultato.IsValid

   End Sub

   Private Function ConvalidaFileXML(ByVal nomefile As String) As Boolean
      Try
         ' Formato di trasmissione.
         Dim fatturaXlm As Fattura
         Select Case eui_cmbFormatoTrasmissione.SelectedIndex
            Case 0
               fatturaXlm = Fattura.CreateInstance(Instance.PubblicaAmministrazione)
            Case 1
               fatturaXlm = Fattura.CreateInstance(Instance.Privati)
         End Select

         Dim settings As New XmlReaderSettings()
         settings.IgnoreWhitespace = True
         settings.IgnoreComments = True

         ' Lettura da file XML
         Using reader As XmlReader = XmlReader.Create(nomefile, settings)
            fatturaXlm.ReadXml(reader)
         End Using

         ' Convalida del documento.
         Dim validator As New FatturaValidator
         Dim risultato As FluentValidation.Results.ValidationResult = validator.Validate(fatturaXlm)

         ' Pulisce la casella di testo.
         eui_txtConvalida.Text = String.Empty

         If risultato.IsValid = True Then
            eui_txtConvalida.Text = "Il documento è corretto!"

            Return True
         Else
            Dim i As Integer
            For Each errore As FluentValidation.Results.ValidationFailure In risultato.Errors
               eui_txtConvalida.Text = eui_txtConvalida.Text & errore.PropertyName & ": " & errore.ErrorMessage & vbCrLf
            Next

            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try

   End Function

   Private Function EseguiConvalidaFileXML() As Boolean
      Dim fileConvalidato As Boolean

      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim nomeFileXml As String = nomeDirectory & "\" & GeneraNomeFileXML()

         If File.Exists(nomeFileXml) = True Then
            ' Convalida la fattura elettronica in formato xml.
            fileConvalidato = ConvalidaFileXML(GeneraDirectoryNomeFileXML)
         End If

         Return fileConvalidato

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default
      End Try

   End Function

   Private Function GeneraFileXML(ByVal nomefile As String) As Boolean
      Try

#Region "FORMATO DI TRASMISSIONE "

         ' Formato di trasmissione.
         Dim fatturaXlm As Fattura
         Select Case eui_cmbFormatoTrasmissione.SelectedIndex
            Case 0
               fatturaXlm = Fattura.CreateInstance(Instance.PubblicaAmministrazione)
            Case 1
               fatturaXlm = Fattura.CreateInstance(Instance.Privati)
         End Select

#End Region

#Region "FATTURA ELETTRONICA HEADER - OBBLIGATORIO "

#Region "DATI TRASMISSIONE - OBBLIGATORIO "
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         If eui_cmbTrasmittenteIdPaese.Text <> String.Empty Then
            fatturaXlm.Header.DatiTrasmissione.IdTrasmittente.IdPaese = eui_cmbTrasmittenteIdPaese.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         If eui_txtTrasmittenteIdCodice.Text <> String.Empty Then
            fatturaXlm.Header.DatiTrasmissione.IdTrasmittente.IdCodice = eui_txtTrasmittenteIdCodice.Text.ToUpper
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 10 caratteri.
         If eui_txtProgressivoInvio.Text <> String.Empty Then
            fatturaXlm.Header.DatiTrasmissione.ProgressivoInvio = eui_txtProgressivoInvio.Text
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza di 5 caratteri; i valori ammessi sono i seguenti: 
         ' FPR12 Formato di Trasmissione fattura verso privati.
         ' FPA12 Formato di Trasmissione fattura pubblica amministrazione.
         If eui_cmbFormatoTrasmissione.Text <> String.Empty Then
            fatturaXlm.Header.DatiTrasmissione.FormatoTrasmissione = eui_cmbFormatoTrasmissione.Text
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza di 7 caratteri. Se esiste la PEC inserire 0000000.
         If eui_txtCodiceDestinatario.Text <> String.Empty Then
            fatturaXlm.Header.DatiTrasmissione.CodiceDestinatario = eui_txtCodiceDestinatario.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 5 a 12 caratteri.
         If eui_txtTrasmittenteTelefono.Text <> String.Empty Then
            fatturaXlm.Header.DatiTrasmissione.ContattiTrasmittente.Telefono = eui_txtTrasmittenteTelefono.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 7 a 256 caratteri.
         If eui_txtTrasmittenteEmail.Text <> String.Empty Then
            fatturaXlm.Header.DatiTrasmissione.ContattiTrasmittente.Email = eui_txtTrasmittenteEmail.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 7 a 256 caratteri.
         If eui_txtTrasmittentePECDestinatario.Text <> String.Empty Then
            fatturaXlm.Header.DatiTrasmissione.PECDestinatario = eui_txtTrasmittentePECDestinatario.Text
         End If

#End Region

#Region "CEDENTE PRESTATORE - OBBLIGATORIO "
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         If eui_cmbCpIdPaese.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbCpIdPaese.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         If eui_txtCpIdCodice.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtCpIdCodice.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza compresa tra 11 e 16 caratteri.
         If eui_txtCpCodiceFiscale.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.CodiceFiscale = eui_txtCpCodiceFiscale.Text.ToUpper
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         If eui_txtCpDenominazione.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Denominazione = eui_txtCpDenominazione.Text
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         If eui_txtCpNome.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Nome = eui_txtCpNome.Text
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         If eui_txtCpCognome.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Cognome = eui_txtCpCognome.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         If eui_txtCpTitolo.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.Titolo = eui_txtCpTitolo.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 13 a 17 caratteri.
         If eui_txtCpCodiceEORI.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.Anagrafica.CodEORI = eui_txtCpCodiceEORI.Text
         End If

         ' FACOLTATIVO - Alfanumerico; lunghezza massima di 60 caratteri.
         If eui_txtCpAlboProfessionale.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.AlboProfessionale = eui_txtCpAlboProfessionale.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza di 2 caratteri.
         If eui_cmbCpProvinciaAlbo.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.ProvinciaAlbo = eui_cmbCpProvinciaAlbo.Text.Substring(0, 2)
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza massima di 60 caratteri.
         If eui_txtCpNumeroIscrizioneAlbo.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.NumeroIscrizioneAlbo = eui_txtCpNumeroIscrizioneAlbo.Text
         End If

         ' FACOLTATIVO - La data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD. 
         If eui_txtCpAlboProfessionale.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.DataIscrizioneAlbo = eui_dtpCpDataIscrizioneAlbo.Value
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' RF01 Ordinario;
         ' RF02 Contribuenti minimi (art. 1, c.96-117, L. 244/2007);
         ' RF04 Agricoltura e attività connesse e pesca (artt. 34 e 34-bis, D.P.R. 633/1972);
         ' RF05 Vendita sali e tabacchi (art. 74, c.1, D.P.R. 633/1972);
         ' RF06 Commercio dei fiammiferi (art. 74, c.1, D.P.R. 633/1972);
         ' RF07 Editoria(art. 74, c.1, D.P.R. 633/1972);
         ' RF08 Gestione di servizi di telefonia pubblica (art. 74, c.1, D.P.R. 633/1972);
         ' RF09 Rivendita di documenti di trasporto pubblico e di sosta (art. 74, c.1, D.P.R. 633/1972);
         ' RF10 Intrattenimenti, giochi e altre attività di cui alla tariffa allegata al D.P.R. n. 640/72 (art. 74, c.6, D.P.R. 633/1972);
         ' RF11 Agenzie di viaggi e turismo (art. 74-ter, D.P.R. 633/1972);
         ' RF12 Agriturismo(art. 5, c.2, L. 413/1991);
         ' RF13 Vendite a domicilio (art. 25-bis, c.6, D.P.R. 600/1973);
         ' RF14 Rivendita di beni usati, di oggetti d'arte, d’antiquariato o da collezione (art. 36, D.L. 41/1995);
         ' RF15 Agenzie di vendite all'asta di oggetti d’arte, antiquariato o da collezione (art. 40-bis, D.L. 41/1995);
         ' RF16 IVA per cassa P.A. (art. 6, c.5, D.P.R. 633/1972);
         ' RF17 IVA per cassa (art. 32-bis, D.L. 83/2012);
         ' RF18 Altro;
         ' RF19 Forfettario(art.1, c. 54-89, L. 190/2014)
         If eui_cmbCpRegimeFiscale.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.DatiAnagrafici.RegimeFiscale = eui_cmbCpRegimeFiscale.Text.Substring(0, 4)
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         If eui_txtCpSedeIndirizzo.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.Sede.Indirizzo = eui_txtCpSedeIndirizzo.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 8 caratteri.
         If eui_txtCpSedeNumeroCivico.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.Sede.NumeroCivico = eui_txtCpSedeNumeroCivico.Text
         End If

         ' OBBLIGATORIO - formato numerico; lunghezza di 5 caratteri.
         If eui_txtCpSedeCAP.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.Sede.CAP = eui_txtCpSedeCAP.Text
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         If eui_txtCpSedeComune.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.Sede.Comune = eui_txtCpSedeComune.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri.
         If eui_cmbCpSedeProvincia.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.Sede.Provincia = eui_cmbCpSedeProvincia.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         If eui_cmbCpSedeNazione.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.Sede.Nazione = eui_cmbCpSedeNazione.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         If eui_txtCpStabileOrgIndirizzo.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Indirizzo = eui_txtCpStabileOrgIndirizzo.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 8 caratteri.
         If eui_txtCpStabileOrgNumeroCivico.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.NumeroCivico = eui_txtCpStabileOrgNumeroCivico.Text
         End If

         ' OBBLIGATORIO - formato numerico; lunghezza di 5 caratteri.
         If eui_txtCpStabileOrgCAP.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.CAP = eui_txtCpStabileOrgCAP.Text
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         If eui_txtCpStabileOrgComune.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Comune = eui_txtCpStabileOrgComune.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri.
         If eui_cmbCpStabileOrgProvincia.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Provincia = eui_cmbCpStabileOrgProvincia.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         If eui_cmbCpStabileOrgNazione.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.StabileOrganizzazione.Nazione = eui_cmbCpStabileOrgNazione.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 2 caratteri.
         If eui_cmbCpUfficioREA.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.IscrizioneREA.Ufficio = eui_cmbCpUfficioREA.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         If eui_txtCpNumeroREA.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.IscrizioneREA.NumeroREA = eui_txtCpNumeroREA.Text
         End If

         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         If eui_txtCpCapitaleSocialeREA.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.IscrizioneREA.CapitaleSociale = Convert.ToDecimal(eui_txtCpCapitaleSocialeREA.Text)
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' SU la società è a socio unico.
         ' SM la società NON è a socio unico.
         If eui_cmbCpSocioUnicoREA.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.IscrizioneREA.SocioUnico = eui_cmbCpSocioUnicoREA.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' LS la società è in stato di liquidazione.
         ' LN la società NON è in stato di liquidazione.
         If eui_cmbCpStatoLiquidazioneREA.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.IscrizioneREA.StatoLiquidazione = eui_cmbCpStatoLiquidazioneREA.Text.Substring(0, 2)
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 5 a 12 caratteri.
         If eui_txtCpTelefono.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.Contatti.Telefono = eui_txtCpTelefono.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 5 a 12 caratteri.
         If eui_txtCpFax.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.Contatti.Fax = eui_txtCpFax.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 7 a 256 caratteri.
         If eui_txtCpEmail.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.Contatti.Email = eui_txtCpEmail.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         If eui_txtCpRifAmministrazione.Text <> String.Empty Then
            fatturaXlm.Header.CedentePrestatore.RiferimentoAmministrazione = eui_txtCpRifAmministrazione.Text
         End If
#End Region

#Region "RAPPRESENTANTE FISCALE - FACOLTATIVO "
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         If eui_cmbRfCpIdPaese.Text <> String.Empty Then
            fatturaXlm.Header.Rappresentante.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbRfCpIdPaese.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         If eui_txtRfCpIdCodice.Text <> String.Empty Then
            fatturaXlm.Header.Rappresentante.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtRfCpIdCodice.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza compresa tra 11 e 16 caratteri.
         If eui_txtRfCpCodiceFiscale.Text <> String.Empty Then
            fatturaXlm.Header.Rappresentante.DatiAnagrafici.CodiceFiscale = eui_txtRfCpCodiceFiscale.Text.ToUpper
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         If eui_txtRfCpDenominazione.Text <> String.Empty Then
            fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Denominazione = eui_txtRfCpDenominazione.Text
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         If eui_txtRfCpNome.Text <> String.Empty Then
            fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Nome = eui_txtRfCpNome.Text
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         If eui_txtRfCpCognome.Text <> String.Empty Then
            fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Cognome = eui_txtRfCpCognome.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         If eui_txtRfCpTitolo.Text <> String.Empty Then
            fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.Titolo = eui_txtRfCpTitolo.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 13 a 17 caratteri.
         If eui_txtRfCpCodiceEORI.Text <> String.Empty Then
            fatturaXlm.Header.Rappresentante.DatiAnagrafici.Anagrafica.CodEORI = eui_txtRfCpCodiceEORI.Text
         End If
#End Region

#Region "CESSIONARIO COMMITTENTE - OBBLIGATORIO "
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         If eui_cmbCcIdPaese.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbCcIdPaese.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         If eui_txtCcIdCodice.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtCcIdCodice.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza compresa tra 11 e 16 caratteri.
         If eui_txtCcCodiceFiscale.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.CodiceFiscale = eui_txtCcCodiceFiscale.Text.ToUpper
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         If eui_txtCcDenominazione.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Denominazione = eui_txtCcDenominazione.Text
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         If eui_txtCcNome.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Nome = eui_txtCcNome.Text
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         If eui_txtCcCognome.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Cognome = eui_txtCcCognome.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         If eui_txtCcTitolo.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.Titolo = eui_txtCcTitolo.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 13 a 17 caratteri.
         If eui_txtCcCodiceEORI.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.DatiAnagrafici.Anagrafica.CodEORI = eui_txtCcCodiceEORI.Text
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         If eui_txtCcSedeIndirizzo.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.Sede.Indirizzo = eui_txtCcSedeIndirizzo.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 8 caratteri.
         If eui_txtCcSedeNumeroCivico.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.Sede.NumeroCivico = eui_txtCcSedeNumeroCivico.Text
         End If

         ' OBBLIGATORIO - formato numerico; lunghezza di 5 caratteri.
         If eui_txtCcSedeCAP.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.Sede.CAP = eui_txtCcSedeCAP.Text
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         If eui_txtCcSedeComune.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.Sede.Comune = eui_txtCcSedeComune.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri.
         If eui_cmbCcSedeProvincia.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.Sede.Provincia = eui_cmbCcSedeProvincia.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         If eui_cmbCcSedeNazione.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.Sede.Nazione = eui_cmbCcSedeNazione.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         If eui_txtCcStabileOrgIndirizzo.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Indirizzo = eui_txtCcStabileOrgIndirizzo.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 8 caratteri.
         If eui_txtCcStabileOrgNumeroCivico.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.NumeroCivico = eui_txtCcStabileOrgNumeroCivico.Text
         End If

         ' OBBLIGATORIO - formato numerico; lunghezza di 5 caratteri.
         If eui_txtCcStabileOrgCAP.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.CAP = eui_txtCcStabileOrgCAP.Text
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         If eui_txtCcStabileOrgComune.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Comune = eui_txtCcStabileOrgComune.Text
         End If

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri.
         If eui_cmbCcStabileOrgProvincia.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Provincia = eui_cmbCcStabileOrgProvincia.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         If eui_cmbCcStabileOrgNazione.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.StabileOrganizzazione.Nazione = eui_cmbCcStabileOrgNazione.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         If eui_cmbCcRfIdPaese.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.IdFiscaleIVA.IdPaese = eui_cmbCcRfIdPaese.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         If eui_txtCcRfIdCodice.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.IdFiscaleIVA.IdCodice = eui_txtCcRfIdCodice.Text
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         If eui_txtCcRfDenominazione.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.Denominazione = eui_txtCcRfDenominazione.Text
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         If eui_txtCcRfNome.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.Nome = eui_txtCcRfNome.Text
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         If eui_txtCcRfCognome.Text <> String.Empty Then
            fatturaXlm.Header.CessionarioCommittente.RappresentanteFiscale.Cognome = eui_txtCcRfCognome.Text
         End If
#End Region

#Region "TERZO INTERMEDIARIO O SOGGETTO EMITTENTE - FACOLTATIVO "
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         If eui_cmbTiSeIdPaese.Text <> String.Empty Then
            fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.IdFiscaleIVA.IdPaese = eui_cmbTiSeIdPaese.Text.Substring(0, 2)
         End If

         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         If eui_txtTiSeIdCodice.Text <> String.Empty Then
            fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.IdFiscaleIVA.IdCodice = eui_txtTiSeIdCodice.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza compresa tra 11 e 16 caratteri.
         If eui_txtTiSeCodiceFiscale.Text <> String.Empty Then
            fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.CodiceFiscale = eui_txtTiSeCodiceFiscale.Text.ToUpper
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         If eui_txtTiSeDenominazione.Text <> String.Empty Then
            fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Denominazione = eui_txtTiSeDenominazione.Text
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         If eui_txtTiSeNome.Text <> String.Empty Then
            fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Nome = eui_txtTiSeNome.Text
         End If

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         If eui_txtTiSeCognome.Text <> String.Empty Then
            fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Cognome = eui_txtTiSeCognome.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         If eui_txtTiSeTitolo.Text <> String.Empty Then
            fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.Titolo = eui_txtTiSeTitolo.Text
         End If

         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 13 a 17 caratteri.
         If eui_txtTiSeCodiceEORI.Text <> String.Empty Then
            fatturaXlm.Header.TerzoIntermediarioOSoggettoEmittente.DatiAnagrafici.Anagrafica.CodEORI = eui_txtTiSeCodiceEORI.Text
         End If
#End Region

#Region "SOGGETTO EMITTENTE - FACOLTATIVO "
         ' FACOLTATIVO -  - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' CC cessionario / committente.
         ' TZ soggetto terzo.
         If eui_cmbSoggettoEmittente.Text <> String.Empty Then
            fatturaXlm.Header.SoggettoEmittente = eui_cmbSoggettoEmittente.Text.Substring(0, 2)
         End If

#End Region

#End Region

#Region "FATTURA ELETTRONICA BODY - OBBLIGATORIO "

         Dim fattBody As New FatturaElettronicaBody.Body
         fatturaXlm.Body.Add(fattBody)

         ' Legge i dati del documento selezionato.
         Doc.LeggiDati(TAB_DOCUMENTI, idDocumento)

#Region "DATI GENERALI - OBBLIGATORIO "
         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' TD01 Fattura
         ' TD02 Acconto / Anticipo su fattura
         ' TD03 Acconto / Anticipo su parcella
         ' TD04 Nota di Credito
         ' TD05 Nota di Debito
         ' TD06 Parcella
         ' TD20 Autofattura
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.TipoDocumento = "TD01"

         ' OBBLIGATORIO - questo campo deve essere espresso secondo lo standard ISO 4217 alpha-3:2001 (es.: EUR, USD, GBP, CZK………).
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Divisa = "EUR"

         ' OBBLIGATORIO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Data = Doc.Data

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Numero = Doc.Numero

         ' FACOLTATIVO - OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' RT01 Ritenuta persone fisiche
         ' RT02 Ritenuta persone giuridiche
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.TipoRitenuta = ""

         ' FACOLTATIVO - OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.ImportoRitenuta = 0

         ' FACOLTATIVO - OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.AliquotaRitenuta = 0

         ' FACOLTATIVO - OBBLIGATORIO - formato alfanumerico; lunghezza di massimo 2 caratteri; i valori ammessi sono quelli del 770S consultabili alla pagina delle istruzioni di compilazione del modello.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiRitenuta.CausalePagamento = ""

         ' FACOLTATIVO - OBBLIGATORIO - formato alfanumerico, lunghezza di 2 caratteri; il valore ammesso è SI bollo assolto ai sensi del decreto MEF 14 giugno 2014.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiBollo.BolloVirtuale = ""

         ' FACOLTATIVO - OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiBollo.ImportoBollo = 0

         ' FACOLTATIVO - 
         'Dim datiCassaPrevidenziale As New FatturaElettronicaBody.DatiGenerali.DatiCassaPrevidenziale
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Add(datiCassaPrevidenziale)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' TC01 Cassa Nazionale Previdenza e Assistenza Avvocati e Procuratori Legali
         ' TC02 Cassa Previdenza Dottori Commercialisti
         ' TC03 Cassa Previdenza e Assistenza Geometri
         ' TC04 Cassa Nazionale Previdenza e Assistenza Ingegneri e Architetti Liberi Professionisti
         ' TC05 Cassa Nazionale del Notariato
         ' TC06 Cassa Nazionale Previdenza e Assistenza Ragionieri e Periti Commerciali
         ' TC07 Ente Nazionale Assistenza Agenti e Rappresentanti di Commercio (ENASARCO)
         ' TC08 Ente Nazionale Previdenza e Assistenza Consulenti del Lavoro (ENPACL)
         ' TC09 Ente Nazionale Previdenza e Assistenza Medici (ENPAM)
         ' TC10 Ente Nazionale Previdenza e Assistenza Farmacisti (ENPAF)
         ' TC11 Ente Nazionale Previdenza e Assistenza Veterinari (ENPAV)
         ' TC12 Ente Nazionale Previdenza e Assistenza Impiegati dell'Agricoltura (ENPAIA)
         ' TC13 Fondo Previdenza Impiegati Imprese di Spedizione e Agenzie Marittime
         ' TC14 Istituto Nazionale Previdenza Giornalisti Italiani (INPGI)
         ' TC15 Opera Nazionale Assistenza Orfani Sanitari Italiani (ONAOSI)
         ' TC16 Cassa Autonoma Assistenza Integrativa Giornalisti Italiani (CASAGIT)
         ' TC17 Ente Previdenza Periti Industriali e Periti Industriali Laureati (EPPI)
         ' TC18 Ente Previdenza e Assistenza Pluricategoriale (EPAP)
         ' TC19 Ente Nazionale Previdenza e Assistenza Biologi (ENPAB)
         ' TC20 Ente Nazionale Previdenza e Assistenza Professione Infermieristica (ENPAPI)
         ' TC21 Ente Nazionale Previdenza e Assistenza Psicologi (ENPAP)
         ' TC22 INPS
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).TipoCassa = ""

         '  OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).AlCassa = 0

         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).ImportoContributoCassa = 0

         ' FACOLTATIVO - formato numerico nel quale i decinali vanno separati dall’intero con il carattere ‘.’ (punto). La sua lunghezza va da 4 a 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).ImponibileCassa = 0

         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).AliquotaIVA = 0

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; il valore ammesso è: SI contributo cassa soggetto a ritenuta.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).Ritenuta = ""

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' N1 escluse ex art.15
         ' N2 non soggette
         ' N3 non imponibili
         ' N4 esenti
         ' N5 regime del margine / IVA non esposta in fattura
         ' N6 inversione contabile (per le operazioni in reverse charge ovvero nei casi di autofatturazione per acquisti extra UE di servizi ovvero per importazioni di beni nei soli casi previsti)
         ' N7 IVA assolta In altro stato UE (vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett. b, DL 331/93; prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7-sexies lett. f, g, DPR 633/72 e art. 74-sexies, DPR 633/72)
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).Natura = ""

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.DatiCassaPrevidenziale.Item(0).RiferimentoAmministrazione = ""

         ' FACOLTATIVO
         'Dim scontoMaggiorazione As New Common.ScontoMaggiorazione
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Add(scontoMaggiorazione)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
         ' SC sconto
         ' MG maggiorazione
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Item(0).Tipo = ""

         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall’intero con il carattere ‘.’ (punto). La sua lunghezza va da 4 a 6 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Item(0).Percentuale = 0

         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall’intero con il carattere ‘.’ (punto). La sua lunghezza va da 4 a 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ScontoMaggiorazione.Item(0).Importo = 0

         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.ImportoTotaleDocumento = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.TotDoc))

         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Arrotondamento = 0

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 200 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Causale.Add(Doc.Causale)

         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; il valore ammesso è:
         ' SI documento emesso secondo modalità e termini stabiliti con DM ai sensi del'’art. 73 del DPR 633/72.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiGeneraliDocumento.Art73 = ""

         ' FACOLTATIVO
         Dim datiOrdineAcquisto As New FatturaElettronicaBody.DatiGenerali.DatiOrdineAcquisto
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Add(datiOrdineAcquisto)

         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).RiferimentoNumeroLinea.Add(0)
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).IdDocumento = Doc.Numero
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).Data = Doc.Data
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).NumItem = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).CodiceCommessaConvenzione = Doc.CodiceCommConv_PA
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).CodiceCUP = Doc.CodiceCUP_PA
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         fatturaXlm.Body.Item(0).DatiGenerali.DatiOrdineAcquisto.Item(0).CodiceCIG = Doc.CodiceCIG_PA

         ' FACOLTATIVO
         'Dim datiContratto As New FatturaElettronicaBody.DatiGenerali.DatiContratto
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Add(datiContratto)

         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).RiferimentoNumeroLinea.Add(0)
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).IdDocumento = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).Data = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).NumItem = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).CodiceCommessaConvenzione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).CodiceCUP = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiContratto.Item(0).CodiceCIG = ""

         ' FACOLTATIVO
         'Dim datiConvenzione As New FatturaElettronicaBody.DatiGenerali.DatiConvenzione
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Add(datiConvenzione)

         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).RiferimentoNumeroLinea.Add(0)
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).IdDocumento = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).Data = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).NumItem = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).CodiceCommessaConvenzione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).CodiceCUP = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiConvenzione.Item(0).CodiceCIG = ""

         ' FACOLTATIVO
         'Dim datiRicezione As New FatturaElettronicaBody.DatiGenerali.DatiRicezione
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Add(datiRicezione)

         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).RiferimentoNumeroLinea.Add(0)
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).IdDocumento = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).Data = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).NumItem = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).CodiceCommessaConvenzione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).CodiceCUP = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiRicezione.Item(0).CodiceCIG = ""

         ' FACOLTATIVO
         'Dim datiFattureCollegate As New FatturaElettronicaBody.DatiGenerali.DatiFattureCollegate
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Add(datiFattureCollegate)

         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).RiferimentoNumeroLinea.Add(0)
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).IdDocumento = ""
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).Data = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).NumItem = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).CodiceCommessaConvenzione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).CodiceCUP = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiFattureCollegate.Item(0).CodiceCIG = ""

         ' FACOLTATIVO
         'Dim datiSAL As New FatturaElettronicaBody.DatiGenerali.DatiSAL
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiSAL.Add(datiSAL)

         ' OBBLIGATORIO - formato numerico; lunghezza massima di 3 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiSAL.Item(0).RiferimentoFase = 0

         ' FACOLTATIVO
         'Dim datiDDT As New FatturaElettronicaBody.DatiGenerali.DatiDDT
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiDDT.Add(datiDDT)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiDDT.Item(0).NumeroDDT = ""
         ' OBBLIGATORIO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiDDT.Item(0).DataDDT = Today.Date
         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiDDT.Item(0).RiferimentoNumeroLinea.Add(0)

         ' FACOLTATIVO
         ' OBBLIGATORIO - Sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.IdFiscaleIVA.IdPaese = ""
         ' OBBLIGATORIO - Formato alfanumerico; lunghezza massima di 28 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.IdFiscaleIVA.IdCodice = ""
         ' FACOLTATIVO - Formato alfanumerico; lunghezza compresa tra 11 e 16 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.CodiceFiscale = ""
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 80 caratteri. Da valorizzare in alternativa ai campi Nome e Cognome seguenti.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Denominazione = ""
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Cognome ed in alternativa al campo Denominazione.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Nome = ""
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri. Da valorizzare insieme al campo Nome ed in alternativa al campo Denominazione.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Cognome = ""
         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.Titolo = ""
         ' FACOLTATIVO - Formato alfanumerico; lunghezza che va da 13 a 17 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.Anagrafica.CodEORI = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DatiAnagraficiVettore.NumeroLicenzaGuida = ""

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 80 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.MezzoTrasporto = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.CausaleTrasporto = ""
         ' FACOLTATIVO - formato numerico; lunghezza massima di 4 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.NumeroColli = 0
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.Descrizione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 10 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.UnitaMisuraPeso = ""
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 7 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.PesoLordo = 0
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 7 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.PesoNetto = 0
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DDTHH:MM:SS.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DataOraRitiro = Today.Date
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DataInizioTrasporto = Today.Date
         ' FACOLTATIVO - codifica del termine di resa (Incoterms) espresso secondo lo standard ICC-Camera di Commercio Internazionale (formato alfanumerico di 3 caratteri)
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.TipoResa = ""

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.Indirizzo = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 8 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.NumeroCivico = ""
         ' OBBLIGATORIO - formato numerico; lunghezza di 5 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.CAP = ""
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.Comune = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.Provincia = ""
         ' OBBLIGATORIO - sigla della nazione espressa secondo lo standard ISO 3166-1 alpha-2 code.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.IndirizzoResa.Nazione = ""

         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DDTHH:MM:SS.
         'fatturaXlm.Body.Item(0).DatiGenerali.DatiTrasporto.DataOraConsegna = Today.Date

         ' FACOLTATIVO
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiGenerali.FatturaPrincipale.NumeroFatturaPrincipale = ""
         ' OBBLIGATORIO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiGenerali.FatturaPrincipale.DataFatturaPrincipale = Today.Date
#End Region

#Region "DATI BENI SERVIZI - OBBLIGATORIO "

         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & TAB_DETTAGLI_DOCUMENTI & " WHERE RifDoc = " & idDocumento & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()
         Dim numLinea As Integer = 1

         Do While dr.Read()
            ' OBBLIGATORIO
            Dim dettaglioLinee As New FatturaElettronicaBody.DatiBeniServizi.DettaglioLinee
            fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Add(dettaglioLinee)

            ' OBBLIGATORIO - formato numerico; lunghezza massima di 4 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).NumeroLinea = numLinea

            ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i ivalori ammessi sono:
            ' SC Sconto
            ' PR Premio
            ' AB Abbuono
            ' AC Spesa accessoria
            If dr.Item("ValoreUnitario").ToString.Contains("-") = True Then
               fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).TipoCessionePrestazione = "SC"
            End If

            If dr.Item("CodiceArticolo").ToString <> String.Empty Then
               ' FACOLTATIVO
               Dim codiceArticolo As New FatturaElettronicaBody.DatiBeniServizi.CodiceArticolo
               fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).CodiceArticolo.Add(codiceArticolo)

               ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 35 caratteri.
               fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).CodiceArticolo.Item(0).CodiceTipo = "Alfanumerico"
               ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 35 caratteri.
               fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).CodiceArticolo.Item(0).CodiceValore = dr.Item("CodiceArticolo").ToString
            End If

            ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 1000 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).Descrizione = dr.Item("Descrizione").ToString
            ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).Quantita = CFormatta.FormattaEuro(Convert.ToDecimal(dr.Item("Quantità")))
            ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 10 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).UnitaMisura = dr.Item("UnitàMisura").ToString
            ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).DataInizioPeriodo = Today.Date
            ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).DataFinePeriodo = Today.Date
            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).PrezzoUnitario = CFormatta.FormattaImponibileIva(CalcolaImponibileIva(dr.Item("AliquotaIva"), dr.Item("ValoreUnitario")))

            If Convert.ToDecimal(dr.Item("Sconto")) <> 0 Then
               ' FACOLTATIVO
               Dim scontoMaggiorazione1 As New Common.ScontoMaggiorazione
               fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).ScontoMaggiorazione.Add(scontoMaggiorazione1)
               ' OBBLIGATORIO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
               ' SC sconto
               ' MG maggiorazione
               fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).ScontoMaggiorazione.Item(0).Tipo = "SC"
               ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall’intero con il carattere ‘.’ (punto). La sua lunghezza va da 4 a 6 caratteri.
               fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).ScontoMaggiorazione.Item(0).Percentuale = CFormatta.FormattaEuro(Convert.ToDecimal(dr.Item("Sconto")))

               ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall’intero con il carattere ‘.’ (punto). La sua lunghezza va da 4 a 15 caratteri.
               ' Importo.
               Dim importo As Decimal = fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).PrezzoUnitario
               fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).ScontoMaggiorazione.Item(0).Importo = CFormatta.FormattaEuro(CalcolaPercentuale(importo, Convert.ToDecimal(dr.Item("Sconto"))))
            End If

            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
            Dim quantita As Decimal = fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).Quantita
            Dim prezzoUnitario As Decimal = fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).PrezzoUnitario
            ' Con questo codice i decimali sono errati per la convalida del file .xml.
            ' CFormatta.FormattaImponibileIva(CalcolaImponibileIva(dr.Item("AliquotaIva"), dr.Item("ImportoNetto")))
            fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).PrezzoTotale = quantita * prezzoUnitario

            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).AliquotaIVA = CFormatta.FormattaEuro(Convert.ToDecimal(dr.Item("AliquotaIva")))

            ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; il valore ammesso è: SI linea di fattura soggetta a ritenuta.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).Ritenuta = ""

            If Convert.ToDecimal(dr.Item("AliquotaIva")) = 0 Then
               ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
               ' N1 escluse ex art.15
               ' N2 non soggette
               ' N3 non imponibili
               ' N4 esenti
               ' N5 regime del margine / IVA non esposta in fattura
               ' N6 inversione contabile (per le operazioni in reverse charge ovvero nei casi di autofatturazione per acquisti extra UE di servizi ovvero per importazioni di beni nei soli casi previsti)
               ' N7 IVA assolta In altro stato UE (vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett. b, DL 331/93; prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7-sexies lett. f, g, DPR 633/72 e art. 74-sexies, DPR 633/72)
               fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).Natura = "N2"
            End If

            ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).RiferimentoAmministrazione = ""

            ' FACOLTATIVO
            'Dim altriDatiGestionali As New FatturaElettronicaBody.DatiBeniServizi.AltriDatiGestionali
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).AltriDatiGestionali.Add(altriDatiGestionali)

            ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 10 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).AltriDatiGestionali.Item(0).TipoDato = ""
            ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 60 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).AltriDatiGestionali.Item(0).RiferimentoTesto = ""
            ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).AltriDatiGestionali.Item(0).RiferimentoNumero = 0
            ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DettaglioLinee.Item(numLinea - 1).AltriDatiGestionali.Item(0).RiferimentoData = Today.Date

            numLinea += 1
         Loop

         Dim i As Integer = 0
         If Convert.ToDecimal(Doc.AliquotaIvaRep1) <> 0 Then
            ' OBBLIGATORIO
            Dim datiRiepilogo As New FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Add(datiRiepilogo)

            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).AliquotaIVA = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.AliquotaIvaRep1))
            ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
            ' N1 escluse ex art.15
            ' N2 non soggette
            ' N3 non imponibili
            ' N4 esenti
            ' N5 regime del margine / IVA non esposta in fattura
            ' N6 inversione contabile (per le operazioni in reverse charge ovvero nei casi di autofatturazione per acquisti extra UE di servizi ovvero per importazioni di beni nei soli casi previsti)
            ' N7 IVA assolta In altro stato UE (vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett. b, DL 331/93; prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7-sexies lett. f, g, DPR 633/72 e art. 74-sexies, DPR 633/72)
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Natura = ""
            ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).SpeseAccessorie = 0
            ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Arrotondamento = 0
            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).ImponibileImporto = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.ImpLordoRep1))
            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Imposta = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.ImpostaRep1))
            ' FACOLTATIVO - formato alfanumerico; lunghezza di 1 carattere; i valori ammessi sono i seguenti:
            ' I IVA ad esigibilità immediata
            ' D IVA ad esigibilità differita
            ' S scissione dei pagamenti
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).EsigibilitaIVA = ""
            ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).RiferimentoNormativo = ""
            i += 1
         End If

         If Convert.ToDecimal(Doc.AliquotaIvaRep2) <> 0 Then
            ' OBBLIGATORIO
            Dim datiRiepilogo As New FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Add(datiRiepilogo)

            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).AliquotaIVA = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.AliquotaIvaRep2))
            ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
            ' N1 escluse ex art.15
            ' N2 non soggette
            ' N3 non imponibili
            ' N4 esenti
            ' N5 regime del margine / IVA non esposta in fattura
            ' N6 inversione contabile (per le operazioni in reverse charge ovvero nei casi di autofatturazione per acquisti extra UE di servizi ovvero per importazioni di beni nei soli casi previsti)
            ' N7 IVA assolta In altro stato UE (vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett. b, DL 331/93; prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7-sexies lett. f, g, DPR 633/72 e art. 74-sexies, DPR 633/72)
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Natura = ""
            ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).SpeseAccessorie = 0
            ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Arrotondamento = 0
            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).ImponibileImporto = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.ImpLordoRep2))
            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Imposta = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.ImpostaRep2))
            ' FACOLTATIVO - formato alfanumerico; lunghezza di 1 carattere; i valori ammessi sono i seguenti:
            ' I IVA ad esigibilità immediata
            ' D IVA ad esigibilità differita
            ' S scissione dei pagamenti
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).EsigibilitaIVA = ""
            ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).RiferimentoNormativo = ""
            i += 1
         End If

         If Convert.ToDecimal(Doc.AliquotaIvaRep3) <> 0 Then
            ' OBBLIGATORIO
            Dim datiRiepilogo As New FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Add(datiRiepilogo)

            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).AliquotaIVA = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.AliquotaIvaRep3))
            ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
            ' N1 escluse ex art.15
            ' N2 non soggette
            ' N3 non imponibili
            ' N4 esenti
            ' N5 regime del margine / IVA non esposta in fattura
            ' N6 inversione contabile (per le operazioni in reverse charge ovvero nei casi di autofatturazione per acquisti extra UE di servizi ovvero per importazioni di beni nei soli casi previsti)
            ' N7 IVA assolta In altro stato UE (vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett. b, DL 331/93; prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7-sexies lett. f, g, DPR 633/72 e art. 74-sexies, DPR 633/72)
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Natura = ""
            ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).SpeseAccessorie = 0
            ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Arrotondamento = 0
            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).ImponibileImporto = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.ImpLordoRep3))
            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Imposta = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.ImpostaRep3))
            ' FACOLTATIVO - formato alfanumerico; lunghezza di 1 carattere; i valori ammessi sono i seguenti:
            ' I IVA ad esigibilità immediata
            ' D IVA ad esigibilità differita
            ' S scissione dei pagamenti
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).EsigibilitaIVA = ""
            ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).RiferimentoNormativo = ""
            i += 1
         End If

         If Convert.ToDecimal(Doc.AliquotaIvaRep4) <> 0 Then
            ' OBBLIGATORIO
            Dim datiRiepilogo As New FatturaElettronicaBody.DatiBeniServizi.DatiRiepilogo
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Add(datiRiepilogo)

            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 6 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).AliquotaIVA = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.AliquotaIvaRep4))
            ' FACOLTATIVO - formato alfanumerico; lunghezza di 2 caratteri; i valori ammessi sono i seguenti:
            ' N1 escluse ex art.15
            ' N2 non soggette
            ' N3 non imponibili
            ' N4 esenti
            ' N5 regime del margine / IVA non esposta in fattura
            ' N6 inversione contabile (per le operazioni in reverse charge ovvero nei casi di autofatturazione per acquisti extra UE di servizi ovvero per importazioni di beni nei soli casi previsti)
            ' N7 IVA assolta In altro stato UE (vendite a distanza ex art. 40 commi 3 e 4 e art. 41 comma 1 lett. b, DL 331/93; prestazione di servizi di telecomunicazioni, tele - radiodiffusione ed elettronici ex art. 7-sexies lett. f, g, DPR 633/72 e art. 74-sexies, DPR 633/72)
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Natura = ""
            ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).SpeseAccessorie = 0
            ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 21 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Arrotondamento = 0
            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).ImponibileImporto = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.ImpLordoRep4))
            ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
            fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).Imposta = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.ImpostaRep4))
            ' FACOLTATIVO - formato alfanumerico; lunghezza di 1 carattere; i valori ammessi sono i seguenti:
            ' I IVA ad esigibilità immediata
            ' D IVA ad esigibilità differita
            ' S scissione dei pagamenti
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).EsigibilitaIVA = ""
            ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
            'fatturaXlm.Body.Item(0).DatiBeniServizi.DatiRiepilogo.Item(i).RiferimentoNormativo = ""
         End If

#End Region

#Region "DATI VEICOLI - FACOLTATIVO "
         ' OBBLIGATORIO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiVeicoli.Data = Today.Date
         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiVeicoli.TotalePercorso = ""
#End Region

#Region "DATI PAGAMENTO - FACOLTATIVO "
         ' FACOLTATIVO
         Dim datiPagamento As New FatturaElettronicaBody.DatiPagamento.DatiPagamento
         fatturaXlm.Body.Item(0).DatiPagamento.Add(datiPagamento)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' TP01 pagamento a rate
         ' TP02 pagamento completo
         ' TP03 anticipo
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).CondizioniPagamento = "TP02"

         ' OBBLIGATORIO
         Dim dettaglioPagamento As New FatturaElettronicaBody.DatiPagamento.DettaglioPagamento
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Add(dettaglioPagamento)

         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 200 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).Beneficiario = ""

         ' OBBLIGATORIO - formato alfanumerico; lunghezza di 4 caratteri; i valori ammessi sono i seguenti:
         ' MP01 Contanti
         ' MP02 assegno
         ' MP03 assegno circolare
         ' MP04 Contanti presso Tesoreria
         ' MP05 bonifico
         ' MP06 vaglia cambiario
         ' MP07 bollettino bancario
         ' MP08 carta di pagamento
         ' MP09 RID
         ' MP10 RID utenze
         ' MP11 RID veloce
         ' MP12 Riba
         ' MP13 MAV
         ' MP14 quietanza erario stato
         ' MP15 giroconto su conti di contabilità speciale
         ' MP16 domiciliazione bancaria
         ' MP17 domiciliazione postale
         ' MP18 bollettino di c/c postale
         ' MP19 SEPA Direct Debit
         ' MP20 SEPA Direct Debit CORE
         ' MP21 SEPA Direct Debit B2B
         ' MP22 Trattenuta su somme già riscosse
         Dim codicePagamento As String
         Select Case Doc.TipoPagamento.ToUpper
            Case "CONTANTI"
               codicePagamento = "MP01"
            Case "ASSEGNO"
               codicePagamento = "MP02"
            Case "ASSEGNO CIRCOLARE"
               codicePagamento = "MP03"
            Case "CONTANTI PRESSO TESORERIA"
               codicePagamento = "MP04"
            Case "BONIFICO"
               codicePagamento = "MP05"
            Case "VAGLIA CAMBIARIO"
               codicePagamento = "MP06"
            Case "BOLLETTINO BANCARIO"
               codicePagamento = "MP07"
            Case "CARTA DI PAGAMENTO"
               codicePagamento = "MP08"
            Case "RID"
               codicePagamento = "MP09"
            Case "RID UTENZE"
               codicePagamento = "MP10"
            Case "RID VELOCE"
               codicePagamento = "MP11"
            Case "RIBA"
               codicePagamento = "MP12"
            Case "MAV"
               codicePagamento = "MP13"
            Case "QUIETANZA ERARIO STATO"
               codicePagamento = "MP14"
            Case "GIROCONTO SU CONTI DI CONTABILITÀ SPECIALE"
               codicePagamento = "MP15"
            Case "DOMICILIAZIONE BANCARIA"
               codicePagamento = "MP16"
            Case "DOMICILIAZIONE POSTALE"
               codicePagamento = "MP17"
            Case "BOLLETTINO DI C/C POSTALE"
               codicePagamento = "MP18"
            Case "SEPA DIRECT DEBIT"
               codicePagamento = "MP19"
            Case "SEPA DIRECT DEBIT CORE"
               codicePagamento = "MP20"
            Case "SEPA DIRECT DEBIT B2B"
               codicePagamento = "MP21"
            Case "TRATTENUTA SU SOMME GIÀ RISCOSSE"
               codicePagamento = "MP22"
            Case Else
               codicePagamento = "MP01"
         End Select
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).ModalitaPagamento = codicePagamento
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).DataRiferimentoTerminiPagamento = Today.Date
         ' FACOLTATIVO - formato numerico di lunghezza massima pari a 3. Vale 0 (zero) per pagamenti a vista.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).GiorniTerminiPagamento = 0
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).DataScadenzaPagamento = Today.Date
         ' OBBLIGATORIO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).ImportoPagamento = CFormatta.FormattaEuro(Convert.ToDecimal(Doc.TotDoc))
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 20 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).CodUfficioPostale = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 60 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).CognomeQuietanzante = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 60 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).NomeQuietanzante = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza di 16 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).CFQuietanzante = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 2 a 10 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).TitoloQuietanzante = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 80 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).IstitutoFinanziario = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 15 a 34 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).IBAN = ""
         ' FACOLTATIVO - formato numerico di 5 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).ABI = ""
         ' FACOLTATIVO - formato numerico di 5 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).CAB = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza che va da 8 a 11 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).BIC = ""
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).ScontoPagamentoAnticipato = 0
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).DataLimitePagamentoAnticipato = Today.Date
         ' FACOLTATIVO - formato numerico nel quale i decimali vanno separati dall'intero con il carattere '.' (punto). La sua lunghezza va da 4 a 15 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).PenalitaPagamentiRitardati = 0
         ' FACOLTATIVO - la data deve essere rappresentata secondo il formato ISO 8601:2004, con la seguente precisione: YYYY-MM-DD.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).DataDecorrenzaPenale = Today.Date
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 60 caratteri.
         'fatturaXlm.Body.Item(0).DatiPagamento.Item(0).DettaglioPagamento.Item(0).CodicePagamento = ""
#End Region

#Region "ALLEGATI - FACOLTATIVO "
         '' FACOLTATIVO
         'Dim allegati As New FatturaElettronicaBody.Allegati.Allegati
         'fatturaXlm.Body.Item(0).Allegati.Add(allegati)

         ' OBBLIGATORIO - formato alfanumerico; lunghezza massima di 60 caratteri.
         'fatturaXlm.Body.Item(0).Allegati.Item(0).NomeAttachment = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 10 caratteri.
         'fatturaXlm.Body.Item(0).Allegati.Item(0).AlgoritmoCompressione = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 10 caratteri.
         'fatturaXlm.Body.Item(0).Allegati.Item(0).FormatoAttachment = ""
         ' FACOLTATIVO - formato alfanumerico; lunghezza massima di 100 caratteri.
         'fatturaXlm.Body.Item(0).Allegati.Item(0).DescrizioneAttachment = ""
         ' OBBLIGATORIO - è in formato xs:base64Binary.
         'Dim allegato As Byte()
         'fatturaXlm.Body.Item(0).Allegati.Item(0).Attachment = allegato
#End Region

#End Region

#Region "SCRITTURA DEL FILE XML "
         ' Serializzazione XML
         Dim settings As New XmlWriterSettings()
         settings.Indent = True

         Using writer As XmlWriter = XmlWriter.Create(nomefile, settings)
            fatturaXlm.WriteXml(writer)
         End Using
#End Region

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try

   End Function

   Private Function GeneraDirectoryNomeFileXML() As String
      Try
         Dim nomeFile As String = GeneraNomeFileXML()

         ' Verifica se esiste la cartella dell'anno corrente e in caso contrario la crea.
         If VerificaEsistenzaCartellaAnnoCorrente(nomeDirectory) = False Then
            CreaCartellaAnnoCorrente(nomeDirectory)
         End If

         Dim nomefileXML As String = nomeDirectory & "\" & nomeFile

         Return nomefileXML

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function GeneraNomeFileXML() As String
      Try
         Dim nomefileXML As String

         If eui_cmbTrasmittenteIdPaese.Text <> String.Empty Then
            nomefileXML = eui_cmbTrasmittenteIdPaese.Text.Substring(0, 2) & eui_txtTrasmittenteIdCodice.Text.ToUpper & "_" & InserisciZero(eui_txtProgressivoInvio.Text) & ".xml"
         Else
            nomefileXML = String.Empty
         End If

         Return nomefileXML

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function GeneraNomeFileTxt() As String
      Try
         Dim nomefileTXT As String

         If eui_cmbTrasmittenteIdPaese.Text <> String.Empty Then
            nomefileTXT = eui_cmbTrasmittenteIdPaese.Text.Substring(0, 2) & eui_txtTrasmittenteIdCodice.Text.ToUpper & "_" & InserisciZero(eui_txtProgressivoInvio.Text) & ".txt"
         Else
            nomefileTXT = String.Empty
         End If

         Return nomefileTXT

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty
      End Try

   End Function

   Private Function LeggiNumeroProgressivoFileXML() As String
      Try
         Dim chiaveConfig As String = "NumeroProgressivoFileXML"

         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         If DatiConfig.GetValue(chiaveConfig) = False Then
            Return "1"
         Else
            ' Legge dal file di configurazione.
            Return DatiConfig.GetValue(chiaveConfig)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Sub SalvaNumeroProgressivoFileXML()
      Try
         Dim chiaveConfig As String = "NumeroProgressivoFileXML"

         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         Dim numProgressivo As Integer
         If IsNumeric(eui_txtProgressivoInvio.Text) = True Then
            numProgressivo = Convert.ToInt32(eui_txtProgressivoInvio.Text)

            DatiConfig.SetValue(chiaveConfig, (numProgressivo + 1).ToString)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Function VerificaEsistenzaCartellaAnnoCorrente(ByVal nomeDir As String) As Boolean
      ' Verifica se esiste la cartella dell'anno corrente.
      Try
         If Directory.Exists(nomeDir) = True Then
            Return True
         Else
            Return False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      End Try

   End Function

   Private Function CreaCartellaAnnoCorrente(ByVal nomeDir As String) As Boolean
      Try
         Directory.CreateDirectory(nomeDir)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Sub CaricaDatiAzienda()
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM Azienda ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            ' DATI DI TRASMISSIONE.

            ' Identificativo Trasmittente IdPaese.
            eui_cmbTrasmittenteIdPaese.SelectedItem = IT_ITALIA

            ' Codice identificativo fiscale.
            If IsDBNull(dr.Item("CodFisc")) = False Then
               eui_txtTrasmittenteIdCodice.Text = dr.Item("CodFisc").ToString.ToUpper
            Else
               eui_txtTrasmittenteIdCodice.Text = String.Empty
            End If

            ' Telefono.
            If IsDBNull(dr.Item("Tel")) = False Then
               eui_txtTrasmittenteTelefono.Text = dr.Item("Tel")
            Else
               eui_txtTrasmittenteTelefono.Text = String.Empty
            End If

            ' E-mail.
            If IsDBNull(dr.Item("Mail")) = False Then
               eui_txtTrasmittenteEmail.Text = dr.Item("Mail")
            Else
               eui_txtTrasmittenteEmail.Text = String.Empty
            End If

            ' CEDENTE / PRESTATORE.

            ' Identificativo Trasmittente IdPaese.
            eui_cmbCpIdPaese.SelectedItem = IT_ITALIA

            ' Partita IVA.
            If IsDBNull(dr.Item("Iva")) = False Then
               eui_txtCpIdCodice.Text = dr.Item("Iva").ToString
            Else
               eui_txtCpIdCodice.Text = String.Empty
            End If

            ' Codice fiscale.
            If IsDBNull(dr.Item("CodFisc")) = False Then
               eui_txtCpCodiceFiscale.Text = dr.Item("CodFisc").ToString.ToUpper
            Else
               eui_txtCpCodiceFiscale.Text = String.Empty
            End If

            ' Denominazione.
            If IsDBNull(dr.Item("RagSoc")) = False Then
               eui_txtCpDenominazione.Text = dr.Item("RagSoc").ToString
            Else
               eui_txtCpDenominazione.Text = String.Empty
            End If

            ' Regime fiscale.
            If IsDBNull(dr.Item("RegimeFiscale")) = False Then
               eui_cmbCpRegimeFiscale.Text = dr.Item("RegimeFiscale").ToString
            Else
               eui_cmbCpRegimeFiscale.Text = String.Empty
            End If

            ' Sede - Indirizzo.
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               eui_txtCpSedeIndirizzo.Text = dr.Item("Indirizzo").ToString
            Else
               eui_txtCpSedeIndirizzo.Text = String.Empty
            End If

            ' Sede - CAP.
            If IsDBNull(dr.Item("Cap")) = False Then
               eui_txtCpSedeCAP.Text = dr.Item("Cap").ToString
            Else
               eui_txtCpSedeCAP.Text = String.Empty
            End If

            ' Sede - Comune.
            If IsDBNull(dr.Item("Città")) = False Then
               eui_txtCpSedeComune.Text = dr.Item("Città").ToString
            Else
               eui_txtCpSedeComune.Text = String.Empty
            End If

            ' Sede - Provincia.
            If IsDBNull(dr.Item("Prov")) = False Then
               eui_cmbCpSedeProvincia.Text = FormattaProvincia(dr.Item("Prov").ToString)
            Else
               eui_cmbCpSedeProvincia.Text = String.Empty
            End If

            ' Sede - Nazione.
            If IsDBNull(dr.Item("Nazione")) = False Then
               eui_cmbCpSedeNazione.Text = FormattaStato(dr.Item("Nazione").ToString)
            Else
               eui_cmbCpSedeNazione.Text = String.Empty
            End If

            ' Contatti - Telefono.
            If IsDBNull(dr.Item("Tel")) = False Then
               eui_txtCpTelefono.Text = dr.Item("Tel").ToString
            Else
               eui_txtCpTelefono.Text = String.Empty
            End If

            ' Contatti - Fax.
            If IsDBNull(dr.Item("Fax")) = False Then
               eui_txtCpFax.Text = dr.Item("Fax").ToString
            Else
               eui_txtCpFax.Text = String.Empty
            End If

            ' Contatti - E-mail.
            If IsDBNull(dr.Item("Mail")) = False Then
               eui_txtCpEmail.Text = dr.Item("Mail").ToString
            Else
               eui_txtCpEmail.Text = String.Empty
            End If

            ' REA - UfficioRea.
            If IsDBNull(dr.Item("UfficioRea")) = False Then
               eui_cmbCpUfficioREA.Text = dr.Item("UfficioRea").ToString
            Else
               eui_cmbCpUfficioREA.Text = String.Empty
            End If
            ' REA - NumeroRea.
            If IsDBNull(dr.Item("NumeroRea")) = False Then
               eui_txtCpNumeroREA.Text = dr.Item("NumeroRea").ToString
            Else
               eui_txtCpNumeroREA.Text = String.Empty
            End If
            ' REA - StatoLiquidazioneRea.
            If IsDBNull(dr.Item("StatoLiquidazioneRea")) = False Then
               eui_cmbCpStatoLiquidazioneREA.Text = dr.Item("StatoLiquidazioneRea").ToString
            Else
               eui_cmbCpStatoLiquidazioneREA.Text = String.Empty
            End If

            ' Terzo Intermediario Soggetto Emittente - TiSeIdPaese.
            If IsDBNull(dr.Item("TiSeIdPaese")) = False Then
               eui_cmbTiSeIdPaese.Text = dr.Item("TiSeIdPaese").ToString
            Else
               eui_cmbTiSeIdPaese.Text = String.Empty
            End If
            ' Terzo Intermediario Soggetto Emittente - TiSePartitaIva.
            If IsDBNull(dr.Item("TiSePartitaIva")) = False Then
               eui_txtTiSeIdCodice.Text = dr.Item("TiSePartitaIva").ToString
            Else
               eui_txtTiSeIdCodice.Text = String.Empty
            End If
            ' Terzo Intermediario Soggetto Emittente - TiSeCodiceFiscale.
            If IsDBNull(dr.Item("TiSeCodiceFiscale")) = False Then
               eui_txtTiSeCodiceFiscale.Text = dr.Item("TiSeCodiceFiscale").ToString
            Else
               eui_txtTiSeCodiceFiscale.Text = String.Empty
            End If
            ' Terzo Intermediario Soggetto Emittente - TiSeDenominazione.
            If IsDBNull(dr.Item("TiSeDenominazione")) = False Then
               eui_txtTiSeDenominazione.Text = dr.Item("TiSeDenominazione").ToString
            Else
               eui_txtTiSeDenominazione.Text = String.Empty

               ' Terzo Intermediario Soggetto Emittente - TiSeNome.
               If IsDBNull(dr.Item("TiSeNome")) = False Then
                  eui_txtTiSeNome.Text = dr.Item("TiSeNome").ToString
               Else
                  eui_txtTiSeNome.Text = String.Empty
               End If
               ' Terzo Intermediario Soggetto Emittente - TiSeCognome.
               If IsDBNull(dr.Item("TiSeCognome")) = False Then
                  eui_txtTiSeCognome.Text = dr.Item("TiSeCognome").ToString
               Else
                  eui_txtTiSeCognome.Text = String.Empty
               End If
            End If
            ' Terzo Intermediario Soggetto Emittente - TiSeTitolo.
            If IsDBNull(dr.Item("TiSeTitolo")) = False Then
               eui_txtTiSeTitolo.Text = dr.Item("TiSeTitolo").ToString
            Else
               eui_txtTiSeTitolo.Text = String.Empty
            End If
            ' Terzo Intermediario Soggetto Emittente - TiSeCodiceEORI.
            If IsDBNull(dr.Item("TiSeCodiceEORI")) = False Then
               eui_txtTiSeCodiceEORI.Text = dr.Item("TiSeCodiceEORI").ToString
            Else
               eui_txtTiSeCodiceEORI.Text = String.Empty
            End If
            ' Terzo Intermediario Soggetto Emittente - SoggettoEmittente.
            If IsDBNull(dr.Item("SoggettoEmittente")) = False Then
               eui_cmbSoggettoEmittente.Text = dr.Item("SoggettoEmittente").ToString
            Else
               eui_cmbSoggettoEmittente.Text = String.Empty
            End If

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub CaricaDatiCliente()
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM Clienti WHERE Id = " & idCliente & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' DATI TRASMISSIONE.

            ' Codice Destinatario.
            If IsDBNull(dr.Item("CodiceDestinatario")) = False Then
               If dr.Item("CodiceDestinatario").ToString <> String.Empty Then
                  eui_txtCodiceDestinatario.Text = dr.Item("CodiceDestinatario").ToString
               Else
                  eui_txtCodiceDestinatario.Text = "0000000"

                  ' PEC Destinatario.
                  If IsDBNull(dr.Item("PEC")) = False Then
                     eui_txtTrasmittentePECDestinatario.Text = dr.Item("PEC").ToString
                  Else
                     eui_txtTrasmittentePECDestinatario.Text = String.Empty
                  End If

               End If
            Else
               eui_txtCodiceDestinatario.Text = String.Empty
            End If

            ' CESSIONARIO / COMMITTENTE.

            ' Identificativo Trasmittente IdPaese.
            eui_cmbCcIdPaese.SelectedItem = IT_ITALIA

            ' Partita IVA.
            If IsDBNull(dr.Item("Piva")) = False Then
               eui_txtCcIdCodice.Text = dr.Item("Piva").ToString
            Else
               eui_txtCcIdCodice.Text = String.Empty
            End If

            ' Codice fiscale.
            If IsDBNull(dr.Item("CodFisc")) = False Then
               eui_txtCcCodiceFiscale.Text = dr.Item("CodFisc").ToString.ToUpper
            Else
               eui_txtCcCodiceFiscale.Text = String.Empty
            End If

            ' Denominazione.
            If IsDBNull(dr.Item("Cognome")) = False Then
               eui_txtCcDenominazione.Text = dr.Item("Cognome").ToString
            Else
               eui_txtCcDenominazione.Text = String.Empty

               ' Nome.
               If IsDBNull(dr.Item("Nome")) = False Then
                  eui_txtCcNome.Text = dr.Item("Nome").ToString
               Else
                  eui_txtCcNome.Text = String.Empty
               End If

               ' Cognome.
               If IsDBNull(dr.Item("Cognome")) = False Then
                  eui_txtCcCognome.Text = dr.Item("Cognome").ToString
               Else
                  eui_txtCcCognome.Text = String.Empty
               End If
            End If

            ' Titolo.
            If IsDBNull(dr.Item("Titolo")) = False Then
               eui_txtCcTitolo.Text = dr.Item("Titolo").ToString
            Else
               eui_txtCcTitolo.Text = String.Empty
            End If

            ' Sede - Indirizzo.
            If IsDBNull(dr.Item("Indirizzo")) = False Then
               eui_txtCcSedeIndirizzo.Text = dr.Item("Indirizzo").ToString
            Else
               eui_txtCcSedeIndirizzo.Text = String.Empty
            End If

            ' Sede - CAP.
            If IsDBNull(dr.Item("Cap")) = False Then
               eui_txtCcSedeCAP.Text = dr.Item("Cap").ToString
            Else
               eui_txtCcSedeCAP.Text = String.Empty
            End If

            ' Sede - Comune.
            If IsDBNull(dr.Item("Città")) = False Then
               eui_txtCcSedeComune.Text = dr.Item("Città").ToString
            Else
               eui_txtCcSedeComune.Text = String.Empty
            End If

            ' Sede - Provincia.
            If IsDBNull(dr.Item("Provincia")) = False Then
               eui_cmbCcSedeProvincia.Text = FormattaProvincia(dr.Item("Provincia").ToString)
            Else
               eui_cmbCcSedeProvincia.Text = String.Empty
            End If

            ' Sede - Nazione.
            If IsDBNull(dr.Item("Nazione")) = False Then
               eui_cmbCcSedeNazione.Text = FormattaStato(dr.Item("Nazione").ToString)
            Else
               eui_cmbCcSedeNazione.Text = String.Empty
            End If

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub FatturaElettronica_Load(sender As Object, e As EventArgs) Handles Me.Load
      Try
         ImpostaIcona(Me)

         ' Legge il numero progressivo del file e lo formatta con degli zeri.
         eui_txtProgressivoInvio.Text = LeggiNumeroProgressivoFileXML()

         ' Imposta il formato di trasmissione.
         eui_cmbFormatoTrasmissione.SelectedItem = "FPR12"

         ' Percorso file.
         eui_lblDirectoryFileXml.Text = String.Empty

         ' Carica i dati dell'Azienda.
         CaricaDatiAzienda()

         ' Carica i dati del Cliente.
         CaricaDatiCliente()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub FatturaElettronica_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      Try
         ' Distrugge l'oggetto e libera le risorse.
         g_frmFatturaElettronica.Dispose()
         g_frmFatturaElettronica = Nothing

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmFatturaElettronica_Resize(sender As Object, e As EventArgs) Handles Me.Resize
      Try
         ' Larghezza minima.
         If Me.Width <= 985 Then
            Me.Width = 985
         End If

         ' Altezza minima.
         If Me.Height <= 565 Then
            Me.Height = 565
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdEsporta_Click(sender As Object, e As EventArgs) Handles eui_cmdEsporta.Click
      Try
         ' Convalida i campi necessari per creare il nome del file xml.
         If eui_cmbTrasmittenteIdPaese.Text = String.Empty Then
            MessageBox.Show("Specificare un valore per il campo 'Paese' dell'Identificativo Trasmittente.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eui_cmbTrasmittenteIdPaese.Focus()
            Exit Sub
         End If

         If eui_txtTrasmittenteIdCodice.Text = String.Empty Then
            MessageBox.Show("Specificare un valore per il campo 'Codice Identificativo Fiscale' dell'Identificativo Trasmittente.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eui_txtTrasmittenteIdCodice.Focus()
            Exit Sub
         End If

         If eui_txtProgressivoInvio.Text = String.Empty Then
            MessageBox.Show("Specificare un valore per il campo 'Progressivo Invio'.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eui_txtProgressivoInvio.Focus()
            Exit Sub
         End If

         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Genera la fattura elettronica in formato xml.
         Dim fileGenerato As Boolean = GeneraFileXML(GeneraDirectoryNomeFileXML)

         ' Se il file xml è stato generato viene visualizzato il nome e il percorso del file.
         If fileGenerato = True Then
            ' Nome file.
            Me.Text = "Fattura Elettronica - " & GeneraNomeFileXML()

            ' Percorso file.
            eui_lblDirectoryFileXml.Text = GeneraDirectoryNomeFileXML()

            ' Se numerico salva il numero progressivo del file.
            SalvaNumeroProgressivoFileXML()

            ' Esegue la convalida del file xml.
            If EseguiConvalidaFileXML() = True Then
               ' Modifica lo stato del documento selezionato.
               Dim Id As String = g_frmDocumenti.DataGrid1.Item(g_frmDocumenti.DataGrid1.CurrentCell.RowNumber, g_frmDocumenti.COLONNA_ID_DOC)
               g_frmDocumenti.ModificaStatoDocumento(TAB_DOCUMENTI, Id, g_frmDocumenti.STATO_DOC_EMESSO_XML)

               ' Aggiorna la lista dei documenti.
               g_frmDocumenti.AggiornaDati()
            End If

            ' Visualizza la scheda Convalida con l'elenco di eventuali errori.
            eui_tpcDocumento.SelectedTabPage = eui_tpConvalida
            eui_txtConvalida.Select(0, 0)
            eui_txtConvalida.Focus()
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub eui_cmdConvalida_Click(sender As Object, e As EventArgs) Handles eui_cmdConvalida.Click
      Try
         If EseguiConvalidaFileXML() = False Then
            MessageBox.Show("Riscontrati errori di convalida.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Error)
         Else
            MessageBox.Show("Convalida eseguita con successo!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdConvalidaWeb_Click(sender As Object, e As EventArgs) Handles eui_cmdConvalidaWeb.Click
      Try
         ApriSitoInternet("https://sdi.fatturapa.gov.it/SdI2FatturaPAWeb/AccediAlServizioAction.do?pagina=controlla_fattura")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdSalvaErrori_Click(sender As Object, e As EventArgs) Handles eui_cmdSalvaErrori.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         If eui_txtConvalida.Text <> String.Empty Then
            Dim nomeFileTxt As String = nomeDirectory & "\" & "Errori_" & GeneraNomeFileTxt()

            If File.Exists(nomeFileTxt) = True Then
               File.Delete(nomeFileTxt)
            End If

            File.AppendAllText(nomeFileTxt, eui_txtConvalida.Text)

            AvviaWinBloccoNote(Me.Handle, nomeFileTxt)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub eui_cmdAnteprimaWeb_Click(sender As Object, e As EventArgs) Handles eui_cmdAnteprimaWeb.Click
      Try
         ApriSitoInternet("https://sdi.fatturapa.gov.it/SdI2FatturaPAWeb/AccediAlServizioAction.do?pagina=visualizza_file_sdi")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)
      End Try
   End Sub

   Private Sub eui_cmdApriCartella_Click(sender As Object, e As EventArgs) Handles eui_cmdApriCartella.Click
      Try
         ' Verifica se esiste la cartella dell'anno corrente e in caso contrario la crea.
         If VerificaEsistenzaCartellaAnnoCorrente(nomeDirectory) = False Then
            CreaCartellaAnnoCorrente(nomeDirectory)
         End If

         AvviaEsploraFile(Me.Handle, nomeDirectory)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdInvia_Click(sender As Object, e As EventArgs) Handles eui_cmdInvia.Click
      Try
         ' Invia un'e-mail con allegato il documento xml generato..
         InviaEmail(g_frmMain.LeggiPECMittente, EMAIL_SDI_FATTURA_PA, "Trasmissione Fattura elettronica", String.Empty, GeneraDirectoryNomeFileXML)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdTastiera_Click(sender As Object, e As EventArgs) Handles eui_cmdTastiera.Click
      Try
         AvviaTastieraVirtuale(Me.Handle)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdCopiaPercorso_Click(sender As Object, e As EventArgs) Handles eui_cmdCopiaPercorso.Click
      Try
         ' Copia il percorso del file .xml negli appunti di sistema.
         Clipboard.SetText(GeneraDirectoryNomeFileXML)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Me.Close()
   End Sub

   Private Sub lnkAgenziaEntrate_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkAgenziaEntrate.LinkClicked
      Try
         ApriSitoInternet("Http://www.agenziaentrate.gov.it")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lnkFatturaPA_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFatturaPA.LinkClicked
      Try
         ApriSitoInternet("Http://www.fatturapa.gov.it")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub lnkIndicePA_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkIndicePA.LinkClicked
      Try
         ApriSitoInternet("Http://www.indicepa.gov.it")

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCpSedeCAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCpSedeCAP.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCpStabileOrgCAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCpStabileOrgCAP.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCcSedeCAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCcSedeCAP.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCcStabileOrgCAP_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCcStabileOrgCAP.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtCpCapitaleSocialeREA_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtCpCapitaleSocialeREA.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdApriFileTxt_Click(sender As Object, e As EventArgs) Handles eui_cmdApriFileTxt.Click
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         Dim nomeFileTxt As String = nomeDirectory & "\" & GeneraNomeFileTxt()

         If File.Exists(nomeFileTxt) = True Then
            AvviaWinBloccoNote(Me.Handle, nomeDirectory & "\" & GeneraNomeFileTxt())
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub eui_tpcDocumento_SelectedTabPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles eui_tpcDocumento.SelectedTabPageChanged
      Try
         Dim nomeFileXml As String = nomeDirectory & "\" & GeneraNomeFileXML()
         Dim nomeFileTxt As String = nomeDirectory & "\" & GeneraNomeFileTxt()

         Select Case eui_tpcDocumento.SelectedTabPage.Text
            Case "Intestazione"
               eui_txtTrasmittenteIdCodice.Focus()

            Case "Convalida"
               eui_txtConvalida.Focus()

            Case "XML"
               If File.Exists(nomeFileXml) = True Then
                  WebBrowser1.Navigate(nomeFileXml)
               End If

            Case "TXT"
               ' Modifica il cursore del mouse.
               Cursor.Current = Cursors.AppStarting

               If File.Exists(nomeFileXml) = True Then
                  If File.Exists(nomeFileTxt) = True Then
                     File.Delete(nomeFileTxt)
                  End If

                  File.Copy(nomeFileXml, nomeFileTxt)

                  Dim riga As String
                  Dim leggiFile As StreamReader = New StreamReader(nomeFileTxt)

                  eui_txtFormatoTxt.Text = String.Empty

                  Do While leggiFile.Peek >= 0
                     riga = leggiFile.ReadLine()
                     eui_txtFormatoTxt.Text = eui_txtFormatoTxt.Text & riga & vbCrLf
                  Loop

                  leggiFile.Close()

                  ' Modifica il cursore del mouse.
                  Cursor.Current = Cursors.Default
               End If

            Case "HTML - (Anteprima)"

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

End Class