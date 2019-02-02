#Region " DATI FILE.VB "
' **********************************************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       04/01/2017
' Data ultima modifica: 05/09/2018
' Descrizione:          Form per la compilazione dei documenti fiscali (Fatture, Ricevute ecc.)
' Note:
'
' Elenco Attivita:
'
' ***********************************************************************************************
#End Region

Imports Elegant.Ui

Public Class frmDocumento

   Const ANA_CLIENTI As String = "Clienti"
   Const ANA_AZIENDE As String = "Aziende"
   Const TAB_AZIENDA As String = "Azienda"
   Const TAB_DOCUMENTI As String = "Documenti"
   Const TAB_DETTAGLI_DOCUMENTI As String = "DettagliDoc"
   Const TAB_TIPO_DOCUMENTI As String = "TipoDoc"
   Const TAB_CAUSALI_DOCUMENTI As String = "CausaliDocumento"
   Const TAB_TIPO_PAGAMENTO As String = "ModPagamento"
   Const TAB_STATISTICHE As String = "Statistiche"
   Const TAB_COMANDE As String = "Comande"

   Const TIPO_DOC_RF As String = "Ricevuta Fiscale"
   Const TIPO_DOC_FF As String = "Fattura"
   Const TIPO_DOC_SF As String = "Scontrino"
   Const TIPO_DOC_PF As String = "Proforma"
   Const TIPO_DOC_CO As String = "Conto"

   Private idDocumento As String
   Private tipoDocumento As String
   Private nomeFinestra As String

   Private Doc As New Documenti
   Private CFormatta As New ClsFormatta
   Private CConvalida As New ConvalidaKeyPress
   Private DatiConfig As AppConfig

   Public Const STATO_DOC_IMPORTATO As String = "Importato"
   Const STATO_DOC_STAMPATO As String = "Stampato"
   Const STATO_DOC_EMESSO_STAMPATO As String = "Emesso e stampato"
   Const STATO_DOC_EMESSO As String = "Emesso"
   Const STATO_DOC_ANNULLATO As String = "Annullato"
   Const STATO_DOC_EMESSO_XML As String = "Emesso in XML"

   Const STATO_DOC_NUOVO As String = " (Nuovo)"
   Const STATO_DOC_MODIFICA As String = " (Modifica)"
   Private statoDoc As String

   ' Dichiara un oggetto connessione.
   Dim cn As New OleDbConnection(ConnString)
   ' Dichiara un oggetto transazione.
   Dim tr As OleDbTransaction
   Dim cmd As New OleDbCommand(sql, cn)
   Dim ds As New DataSet
   ' Numero di record.
   Dim numRecord As Integer
   Dim sql As String

   ''' <summary>
   ''' Apre il documento da eleborare.
   ''' </summary>
   ''' <param name="nomeWnd">Nome della finestra che richiama il metodo.</param>
   ''' <param name="documento">Il tipo di documento da aprire.</param>
   ''' <param name="id">Il codice del documento da aprire.</param>
   Public Sub New(ByVal nomeWnd As String, ByVal documento As String, ByVal id As String)

      ' Chiamata richiesta dalla finestra di progettazione.
      InitializeComponent()

      idDocumento = id
      tipoDocumento = documento
      nomeFinestra = nomeWnd

      Me.Tag = id

      ' Aggiungere le eventuali istruzioni di inizializzazione dopo la chiamata a InitializeComponent().

   End Sub

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
         Const CAUSALE_MOV_MAG As String = "Vendita"
         Dim AArticoli As New Articoli
         Dim idArticolo As Integer
         Dim qtàScarico As Double

         cn.Open()

         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 2
            Dim IdPiatto As Integer

            If IsNothing(dgvDettagli.Rows(i).Cells(clnCodice.Name).Value.ToString) = False And dgvDettagli.Rows(i).Cells(clnCodice.Name).Value.ToString <> String.Empty Then
               ' Ottiene l'Id del piatto.
               IdPiatto = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnCodice.Name).Value.ToString)

               ' Codice necessario per le varianti che non hanno una quantità.
               Dim qtàPiatto As Integer
               If dgvDettagli.Rows(i).Cells(clnQta.Name).Value.ToString <> String.Empty Then
                  qtàPiatto = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnQta.Name).Value)
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
                  If AArticoli.PrezzoAcquisto <> String.Empty Then
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

                  Dim data As Date = Today.ToShortDateString

                  ' Salva i dati per i movimenti di magazzino.
                  SalvaMovimentiMag("MovMagazzino", idArticolo, data.ToShortDateString, AArticoli.Codice, AArticoli.Descrizione,
                                     qtàCaricata, qtàScaricata, CAUSALE_MOV_MAG, AArticoli.PrezzoAcquisto,
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
            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()
      End Try
   End Sub

#End Region

#Region "Statistiche "

   Private Sub SalvaStatistiche(ByVal rifDoc As Boolean)
      Dim Stat As New Statistiche

      Try
         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 2

            ' Salva solo le righe che hanno un codice Piatto.
            If IsNothing(dgvDettagli.Rows(i).Cells(clnCodice.Name).Value.ToString) = False And dgvDettagli.Rows(i).Cells(clnCodice.Name).Value.ToString <> String.Empty Then

               With Stat
                  ' Assegna i dati dei campi della classe alle caselle di testo.
                  .Data = Today.Date.ToShortDateString

                  If rifDoc = True Then
                     ' Salva un riferimento Id del documento per il comando Annulla documento.
                     If Me.Tag = String.Empty Then
                        .IdCategoria = LeggiUltimoRecord(TAB_DOCUMENTI).ToString
                     Else
                        .IdCategoria = Me.Tag
                     End If
                  Else
                     .IdCategoria = "0"
                  End If

                  If IsNothing(dgvDettagli.Rows(i).Cells(clnCategoria.Name).Value.ToString) = False And dgvDettagli.Rows(i).Cells(clnCategoria.Name).Value.ToString <> String.Empty Then
                     .DesCategoria = dgvDettagli.Rows(i).Cells(clnCategoria.Name).Value.ToString
                  Else
                     .DesCategoria = VALORE_NESSUNA
                  End If

                  .IdPiatto = dgvDettagli.Rows(i).Cells(clnCodice.Name).Value.ToString
                  .DesPiatto = dgvDettagli.Rows(i).Cells(clnDescrizione.Name).Value.ToString
                  .IdTavolo = "0"
                  .DesTavolo = String.Empty
                  .IdCameriere = "0"
                  .DesCameriere = String.Empty

                  If dgvDettagli.Rows(i).Cells(clnQta.Name).Value.ToString <> String.Empty Then
                     .Quantità = Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnQta.Name).Value)
                  Else
                     .Quantità = 1
                  End If

                  .Prezzo = dgvDettagli.Rows(i).Cells(clnPrezzo.Name).Value.ToString
                  .Importo = dgvDettagli.Rows(i).Cells(clnImporto.Name).Value.ToString

                  .InserisciDati(TAB_STATISTICHE)

                  If IsNothing(g_frmStatistiche) = False Then
                     ' Aggiorna la griglia dati.
                     g_frmStatistiche.AggiornaDati()
                  End If

               End With

            End If
         Next

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally

      End Try
   End Sub

#End Region

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

   Public Function LeggiNumeroDocFiscaleConfig(ByVal tabella As String, ByVal tipoDoc As String) As Integer
      Try
         Dim DatiConfig As AppConfig
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

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

   ''' <summary>
   ''' Crea un nuovo documento.
   ''' </summary>
   Private Sub NuovoDocumento()
      Try
         ' Assegna lo stato del documento.
         statoDoc = STATO_DOC_NUOVO

         ' Assegna il tipo del documento al titolo della finestra.
         Me.Text = tipoDocumento & statoDoc

         ' SCHEDA GENERALE.
         Dim NumeroDocumento As Integer

         Select Case tipoDocumento
            Case TIPO_DOC_CO, TIPO_DOC_PF
               NumeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento)

            Case TIPO_DOC_RF, TIPO_DOC_FF
               NumeroDocumento = LeggiNumeroDocFiscaleConfig(TAB_DOCUMENTI, tipoDocumento)

            Case TIPO_DOC_SF
               NumeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento)

         End Select

         eui_txtNumero.Text = NumeroDocumento.ToString
         eui_txtAnno.Text = Today.Year.ToString
         eui_dtpData.Text = Today.ToString
         eui_txtOra.Text = TimeOfDay.Hour.ToString & ":" & FormattaMinuti(TimeOfDay.Minute.ToString)
         eui_cmbTipoDocumento.Text = tipoDocumento

         ' Carica i dati appropriati per la lista.
         CaricaListaStatoDoc()

         eui_cmbStatoDocumento.Text = "Bozza"
         eui_cmbCausaleDocumento.Text = "Vendita"

         eui_txtImponibile.Text = VALORE_ZERO
         eui_txtImposta.Text = VALORE_ZERO
         eui_txtTotaleDocumento.Text = VALORE_ZERO

         ' SCHEDA DETTAGLI.

         ' SCHEDA PA.
         eui_txtNumeroDoc_PA.Text = String.Empty
         eui_txtCodiceCUP_PA.Text = String.Empty
         eui_txtCodiceCIG_PA.Text = String.Empty
         eui_txtCodiceCommConv_PA.Text = String.Empty

         ' SCHEDA TOTALI.
         eui_txtTotaliRep1ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep2ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep3ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep4ImponibileLordo.Text = VALORE_ZERO

         eui_txtTotaliRep1Aliquota.Text = VALORE_ZERO
         eui_txtTotaliRep2Aliquota.Text = VALORE_ZERO
         eui_txtTotaliRep3Aliquota.Text = VALORE_ZERO
         eui_txtTotaliRep4Aliquota.Text = VALORE_ZERO

         eui_txtTotaliRep1Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep2Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep3Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep4Imposta.Text = VALORE_ZERO

         eui_txtTotaliSconto.Text = VALORE_ZERO
         eui_txtTotaliServizio.Text = VALORE_ZERO
         eui_txtTotaliCoperto.Text = VALORE_ZERO

         eui_txtTotaliContanti.Text = VALORE_ZERO
         eui_txtTotaliCarte.Text = VALORE_ZERO
         eui_txtTotaliBuoni.Text = VALORE_ZERO
         eui_txtTotaliSospeso.Text = VALORE_ZERO

         eui_txtTotaliImponibile.Text = VALORE_ZERO
         eui_txtTotaleImposta.Text = VALORE_ZERO
         eui_txtTotaleConto.Text = VALORE_ZERO

         ' SCHEDA NOTE.
         eui_txtNote.Text = String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   ''' <summary>
   ''' Modifica i dati del documento selezionato.
   ''' </summary>
   Private Sub ModificaDocumento()
      Try
         With Doc
            ' Visualizza i dati nei rispettivi campi.
            .LeggiDati(TAB_DOCUMENTI, idDocumento)

            ' Assegna lo stato del documento.
            statoDoc = STATO_DOC_MODIFICA

            ' Assegna il tipo del documento al titolo della finestra.
            Me.Text = .Tipo & statoDoc

            ' Assegna i dati dei campi della classe alle caselle di testo.

            ' DETTAGLI.
            InserisciDettagliRiga(TAB_DETTAGLI_DOCUMENTI, Convert.ToInt32(idDocumento))

            ' DOCUMENTO.
            eui_txtNumero.Text = .Numero
            eui_cmbTipoDocumento.Text = .Tipo

            ' Carica i dati appropriati per la lista.
            CaricaListaStatoDoc()

            eui_txtAnno.Text = .Anno
            eui_dtpData.Value = .Data
            eui_txtOra.Text = .Ora
            eui_cmbStatoDocumento.Text = .Stato
            eui_cmbCausaleDocumento.Text = .Causale

            ' CLIENTE.
            eui_txtIdCliente.Text = .IdCliente
            eui_cmbClienteCognome.Text = .Cliente
            eui_txtIndirizzo.Text = .Indirizzo
            eui_txtCap.Text = .Cap
            eui_txtCittà.Text = .Città
            eui_txtProvincia.Text = .Provincia
            eui_txtPartitaIva.Text = .PIva
            eui_txtCodiceFiscale.Text = .CodFiscale

            ' DOCUMENTO.
            'eui_txtTotaliSconto.Text = .Sconto
            eui_txtTotaliContanti.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Contanti))
            eui_txtTotaliCarte.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Carte))
            eui_txtTotaliBuoni.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.BuoniPasto))

            eui_cmbTipoPagamento.Text = .TipoPagamento
            eui_txtTavolo.Text = .Tavolo
            eui_txtCameriere.Text = .Cameriere
            eui_txtTotaliSospeso.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Sospeso))
            eui_txtTotaliImponibile.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Imponibile))
            eui_txtTotaleImposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Imposta))
            eui_txtTotaleConto.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.TotDoc))
            eui_txtTotaleDocumento.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.TotDoc))

            ' PA.
            eui_txtNumeroDoc_PA.Text = .NumeroDoc_PA
            eui_txtCodiceCUP_PA.Text = .CodiceCUP_PA
            eui_txtCodiceCIG_PA.Text = .CodiceCIG_PA
            eui_txtCodiceCommConv_PA.Text = .CodiceCommConv_PA

            ' TOTALI.
            ' Se Fattura, Ricevuta o Scontrino salva l'iva...
            If eui_cmbTipoDocumento.Text = TIPO_DOC_FF Or eui_cmbTipoDocumento.Text = TIPO_DOC_RF Or eui_cmbTipoDocumento.Text = TIPO_DOC_SF Then
               eui_txtTotaliRep1ImponibileLordo.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpLordoRep1))
               eui_txtTotaliRep2ImponibileLordo.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpLordoRep2))
               eui_txtTotaliRep3ImponibileLordo.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpLordoRep3))
               eui_txtTotaliRep4ImponibileLordo.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpLordoRep4))

               eui_txtTotaliRep1Aliquota.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.AliquotaIvaRep1))
               eui_txtTotaliRep2Aliquota.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.AliquotaIvaRep2))
               eui_txtTotaliRep3Aliquota.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.AliquotaIvaRep3))
               eui_txtTotaliRep4Aliquota.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.AliquotaIvaRep4))

               eui_txtTotaliRep1Imposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpostaRep1))
               eui_txtTotaliRep2Imposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpostaRep2))
               eui_txtTotaliRep3Imposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpostaRep3))
               eui_txtTotaliRep4Imposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.ImpostaRep4))

               eui_txtImponibile.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Imponibile))
               eui_txtImposta.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(.Imposta))
            Else
               eui_txtTotaliRep1ImponibileLordo.Text = VALORE_ZERO
               eui_txtTotaliRep2ImponibileLordo.Text = VALORE_ZERO
               eui_txtTotaliRep3ImponibileLordo.Text = VALORE_ZERO
               eui_txtTotaliRep4ImponibileLordo.Text = VALORE_ZERO

               eui_txtTotaliRep1Aliquota.Text = VALORE_ZERO
               eui_txtTotaliRep2Aliquota.Text = VALORE_ZERO
               eui_txtTotaliRep3Aliquota.Text = VALORE_ZERO
               eui_txtTotaliRep4Aliquota.Text = VALORE_ZERO

               eui_txtTotaliRep1Imposta.Text = VALORE_ZERO
               eui_txtTotaliRep2Imposta.Text = VALORE_ZERO
               eui_txtTotaliRep3Imposta.Text = VALORE_ZERO
               eui_txtTotaliRep4Imposta.Text = VALORE_ZERO

               eui_txtImponibile.Text = VALORE_ZERO
               eui_txtImposta.Text = VALORE_ZERO
            End If

            ' NOTE.
            eui_txtNote.Text = .Note

            ' Aggiorna la Barra di stato.
            eui_lblStatoNumeroDoc.Text = eui_txtNumero.Text & "/" & eui_txtAnno.Text

            ' Verifica se il documento è stato contabilizzato disattivando i controlli per la modifica..
            DisattivaDocumento(.Stato)

         End With

      Catch ex As Exception

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ModificaStatoDocumento(ByVal tabella As String, ByVal codice As String, ByVal stato As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim tr As OleDbTransaction
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} SET StatoDoc = @StatoDoc WHERE Id = {1}", tabella, codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@StatoDoc", stato)

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

   Private Sub DisattivaDocumento(ByVal stato As String)
      Try
         Select Case stato

            Case STATO_DOC_EMESSO, STATO_DOC_EMESSO_STAMPATO, STATO_DOC_EMESSO_XML
               ' Disattiva tutti i controlli delle schede.
               eui_tpGenerale.Enabled = False
               eui_tpDettagli.Enabled = False
               eui_tpTotali.Enabled = False
               eui_tpNote.Enabled = False

               ' Disattiva i comandi appropriati.
               eui_cmdSalva.Enabled = False
               eui_cmdEmettiStampa.Enabled = False
               eui_cmdEmetti.Enabled = False

               ' Disattiva le caselle dei totali.
               eui_txtImponibile.Enabled = False
               eui_txtImposta.Enabled = False
               eui_txtTotaleDocumento.Enabled = False

            Case Else
               ' Disattiva solo il comando Emetti.
               If eui_cmbTipoDocumento.Text = TIPO_DOC_CO Or eui_cmbTipoDocumento.Text = TIPO_DOC_PF Then
                  eui_cmdEmettiStampa.Enabled = False
                  eui_cmdEmetti.Enabled = False
               End If

         End Select

         ' Se uno scontrino disattiva solo i comandi di stampa.
         If eui_cmbTipoDocumento.Text = TIPO_DOC_SF Then
            eui_cmdAnteprima.Enabled = False
            eui_cmdEmettiStampa.Enabled = False
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub InserisciDettagliRiga(ByVal tabella As String, ByVal id As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim strDescrizione As String
      Dim QTA As Integer = 1

      Try

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifDoc = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            eui_cmdNuovaRiga.PerformClick()

            ' Codice.
            If IsDBNull(dr.Item("CodiceArticolo")) = False Then
               dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = dr.Item("CodiceArticolo")
            Else
               dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = String.Empty
            End If

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = dr.Item("Descrizione")
            Else
               dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = String.Empty
            End If

            ' Unità di misura.
            If IsDBNull(dr.Item("UnitàMisura")) = False Then
               dgvDettagli.CurrentRow.Cells(clnUm.Name).Value = dr.Item("UnitàMisura")
            Else
               dgvDettagli.CurrentRow.Cells(clnUm.Name).Value = String.Empty
            End If

            ' Quantità.
            If IsDBNull(dr.Item("Quantità")) = False Then
               dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = dr.Item("Quantità")
            Else
               dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = VALORE_ZERO
            End If

            ' Valore Unitario.
            If IsDBNull(dr.Item("ValoreUnitario")) = False Then
               dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value = dr.Item("ValoreUnitario")
            Else
               dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value = VALORE_ZERO
            End If

            ' Sconto %.
            If IsDBNull(dr.Item("Sconto")) = False Then
               dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value = dr.Item("Sconto")
            Else
               dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value = VALORE_ZERO
            End If

            ' Importo.
            If IsDBNull(dr.Item("ImportoNetto")) = False Then
               dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = dr.Item("ImportoNetto")
            Else
               dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = VALORE_ZERO
            End If

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = dr.Item("AliquotaIva")
            Else
               dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = "0"
            End If

            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               dgvDettagli.CurrentRow.Cells(clnCategoria.Name).Value = dr.Item("Categoria")
            Else
               dgvDettagli.CurrentRow.Cells(clnCategoria.Name).Value = String.Empty
            End If
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Private Sub LeggiDatiConto()
      Try
         ' SHEDA GENERALE.
         Dim numeroDocumento As Integer
         Dim statoDocumento As String
         Dim causaleDocumento As String

         Select Case tipoDocumento
            Case TIPO_DOC_CO, TIPO_DOC_PF
               numeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento) + 1
               statoDocumento = "Aperto"
               causaleDocumento = "Conto"

            Case TIPO_DOC_PF
               numeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento) + 1
               statoDocumento = "Bozza"
               causaleDocumento = "Conto Proforma"

            Case TIPO_DOC_RF, TIPO_DOC_FF
               numeroDocumento = LeggiNumeroDocFiscaleConfig(TAB_DOCUMENTI, tipoDocumento)
               statoDocumento = "Bozza"
               causaleDocumento = "Vendita"

            Case TIPO_DOC_SF
               numeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, tipoDocumento) + 1
               statoDocumento = "Bozza"
               causaleDocumento = "Vendita"

         End Select

         Dim valSospeso As Double = Convert.ToDouble(g_frmContoPos.txtSospeso.Text)
         Dim valDaPagare As Double = Convert.ToDouble(g_frmContoPos.netBtn_DaPagare.TextButton)

         eui_cmbTipoDocumento.Text = tipoDocumento
         eui_txtNumero.Text = numeroDocumento
         eui_txtNumProgressivo.Text = numeroDocumento
         eui_txtAnno.Text = String.Empty
         eui_dtpData.Text = g_frmPos.dtpData.Value.Date.ToString
         eui_txtOra.Text = g_frmPos.lblOra.Text

         eui_cmbStatoDocumento.Text = statoDocumento
         eui_cmbCausaleDocumento.Text = causaleDocumento

         Select Case tipoCliente
            Case Cliente.Azienda
               ' Viene aggiunta la lettera A per identificare le Aziende.
               ' Codice aggiunto dopo la creazione della nuova anagrafica Aziende.
               eui_txtIdCliente.Text = "A" & g_frmContoPos.txtIdAzienda.Text
            Case Cliente.Privato
               ' ID normale.
               eui_txtIdCliente.Text = g_frmContoPos.txtIdCliente.Text
         End Select

         If g_frmContoPos.eui_cmdCliente.Text = "Seleziona cliente" Then
            eui_cmbClienteCognome.Text = String.Empty
            eui_txtClienteNome.Text = String.Empty
         Else
            eui_cmbClienteCognome.Text = g_frmContoPos.txtCognome.Text
            eui_txtClienteNome.Text = g_frmContoPos.txtNome.Text
         End If

         eui_txtIndirizzo.Text = g_frmContoPos.txtIndirizzo.Text
         eui_txtCap.Text = FormattaApici(g_frmContoPos.txtCap.Text)
         eui_txtCittà.Text = FormattaApici(g_frmContoPos.txtCittà.Text)
         eui_txtProvincia.Text = FormattaApici(g_frmContoPos.txtProv.Text)
         eui_txtPartitaIva.Text = g_frmContoPos.txtPIva.Text
         eui_txtCodiceFiscale.Text = g_frmContoPos.txtCodiceFiscale.Text

         eui_txtServizio.Text = g_frmContoPos.txtServizio.Text
         eui_txtSconto.Text = g_frmContoPos.txtValSconto.Text

         If g_frmContoPos.txtCartaCredito.Text <> VALORE_ZERO Then
            eui_cmbTipoPagamento.Text = g_frmContoPos.eui_cmdTipoPagamento.Text
         Else
            eui_cmbTipoPagamento.Text = "Contanti"
         End If

         eui_txtTavolo.Text = g_frmContoPos.nomeTavoloDoc
         eui_txtCameriere.Text = g_frmContoPos.nomeCameriereDoc

         eui_txtTotaleDocumento.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(valDaPagare))

         If g_frmContoPos.tipoDocumento = TIPO_DOC_FF Or g_frmContoPos.tipoDocumento = TIPO_DOC_RF Then
            ' Calcola l'IVA.
            Dim valImposta As Double
            Dim valImponibile As Double

            If IsNumeric(g_frmContoPos.txtIva.Text) = True Then

               valImponibile = CalcolaImponibileIva(g_frmContoPos.Text, valDaPagare)
               valImposta = CalcolaPercentuale(valImponibile, Convert.ToDouble(g_frmContoPos.txtIva.Text))
            Else
               valImposta = 0.0
               g_frmContoPos.txtIva.Text = VALORE_ZERO
            End If

            eui_txtImponibile.Text = CFormatta.FormattaNumeroDouble(valImponibile)
            'eui_txtIva.Text = g_frmContoPos.txtIva.Text
            eui_txtImposta.Text = CFormatta.FormattaNumeroDouble(valImposta)
         Else
            eui_txtImponibile.Text = VALORE_ZERO
            '.Iva = VALORE_ZERO
            eui_txtImposta.Text = VALORE_ZERO
         End If

         ' SHEDA DETTAGLI.

         If g_frmContoPos.eui_cmdTipoConto.Text.ToUpper = "UNICO" Then
            ' SALVA I DETTAGLI PER IL COPERTO.
            If g_frmContoPos.txtCoperto.Text <> VALORE_ZERO Then
               ' Codice, Descrizione, Unità di misura, Quantità, Prezzo, Sconto, Totale.
               dgvDettagli.Rows.Insert(dgvDettagli.Rows.Count - 1,
                                    String.Empty,
                                    "Coperto",
                                    String.Empty,
                                    NumCopertiRistorante,
                                    CopertoRistorante,
                                    VALORE_ZERO,
                                    CFormatta.FormattaNumeroDouble(g_frmContoPos.txtCoperto.Text))

            End If
         End If

         Dim i As Integer
         For i = 0 To g_frmContoPos.lstvDettagli.Items.Count - 1
            'Dim colore As Color = lstvDettagli.Items(i).BackColor
            'If colore.Equals(Color.LightCoral) = False Then

            ' Codice, Descrizione, Unità di misura, Quantità, Prezzo, Sconto, Totale.
            dgvDettagli.Rows.Insert(dgvDettagli.Rows.Count - 1,
                                    String.Empty,
                                    FormattaApici(g_frmContoPos.lstvDettagli.Items(i).SubItems(2).Text),
                                    String.Empty,
                                    g_frmContoPos.lstvDettagli.Items(i).SubItems(1).Text,
                                    VALORE_ZERO,
                                    VALORE_ZERO,
                                    g_frmContoPos.lstvDettagli.Items(i).SubItems(3).Text)

            'End If
         Next



         'If g_frmContoPos.cmdTipoConto.Text <> "ALLA ROMANA" Then
         '   ' SALVA I DETTAGLI PER LO SCONTO.
         '   If g_frmContoPos.txtValSconto.Text <> VALORE_ZERO Then

         '      ' Codice, Descrizione, Unità di misura, Quantità, Prezzo, Sconto, Totale.
         '      dgvDettagli.Rows.Insert(dgvDettagli.Rows.Count - 1,
         '                           String.Empty,
         '                           "Sconto",
         '                           String.Empty,
         '                           "1",
         '                           VALORE_ZERO,
         '                           VALORE_ZERO,
         '                           g_frmContoPos.valSconto)

         'End If
         'End If

         'If cmdTipoConto.Text <> "ALLA ROMANA" Then
         '   ' SALVA I DETTAGLI PER IL SERVIZIO.
         '   If Doc.Servizio <> VALORE_ZERO Then
         '      ' Avvia una transazione.
         '      tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         '      ' Crea la stringa di eliminazione.
         '      sql = String.Format("INSERT INTO {0} (RifDoc, Descrizione, Quantità, ImportoNetto) " &
         '                                    "VALUES(@RifDoc, @Descrizione, @Quantità, @ImportoNetto)", TAB_DETTAGLI_DOC)
         '      ' Crea il comando per la connessione corrente.
         '      Dim cmdInsert As New OleDbCommand(sql, cn, tr)
         '      cmdInsert.Parameters.Add("@RifDoc", LeggiUltimoRecord(TAB_DOC))
         '      cmdInsert.Parameters.Add("@Descrizione", "Servizio")
         '      cmdInsert.Parameters.Add("@Quantità", "1")
         '      cmdInsert.Parameters.Add("@ImportoNetto", Doc.Servizio)
         '      ' Esegue il comando.
         '      Dim Record As Integer = cmdInsert.ExecuteNonQuery()
         '      ' Conferma transazione.
         '      tr.Commit()
         '   End If
         'End If

         ' Salva il Numero del prossimo documento da stampare.
         'SalvaNumeroDocFiscaleConfig(TAB_DOC, tipoDocumento, NumeroDocumento)

         ' SHEDA TOTALI.
         eui_txtTotaliRep1ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep2ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep3ImponibileLordo.Text = VALORE_ZERO
         eui_txtTotaliRep4ImponibileLordo.Text = VALORE_ZERO

         eui_txtTotaliRep1Aliquota.Text = g_frmContoPos.txtIva.Text
         eui_txtTotaliRep2Aliquota.Text = VALORE_ZERO
         eui_txtTotaliRep3Aliquota.Text = VALORE_ZERO
         eui_txtTotaliRep4Aliquota.Text = VALORE_ZERO

         eui_txtTotaliRep1Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep2Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep3Imposta.Text = VALORE_ZERO
         eui_txtTotaliRep4Imposta.Text = VALORE_ZERO

         eui_txtTotaliSconto.Text = CFormatta.FormattaNumeroDouble(g_frmContoPos.valSconto)
         eui_txtTotaliServizio.Text = CFormatta.FormattaNumeroDouble(g_frmContoPos.valServizio)
         eui_txtTotaliCoperto.Text = g_frmContoPos.txtCoperto.Text

         eui_txtTotaliContanti.Text = g_frmContoPos.txtContanti.Text
         eui_txtTotaliCarte.Text = g_frmContoPos.txtCartaCredito.Text
         eui_txtTotaliBuoni.Text = g_frmContoPos.txtBuoni.Text
         eui_txtTotaliSospeso.Text = g_frmContoPos.txtSospeso.Text

         eui_txtTotaliImponibile.Text = eui_txtImponibile.Text
         eui_txtTotaleImposta.Text = eui_txtImposta.Text
         eui_txtTotaleConto.Text = eui_txtTotaleDocumento.Text

      Catch ex As Exception
         ' Annulla transazione.
         'tr.Rollback()

         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Chiude la connessione.
         'cn.Close()

      End Try
   End Sub

   ''' <summary>
   ''' Salva i dati per il documento creato.
   ''' </summary>
   ''' <returns><c>True</c> Documento salvato, <c>False</c> Documento non salvato.</returns>
   Private Function SalvaDocumento() As Boolean
      Try
         With Doc
            Dim valSospeso As Double = Convert.ToDouble(eui_txtTotaliSospeso.Text)
            Dim valDaPagare As Double = Convert.ToDouble(eui_txtTotaleDocumento.Text)

            ' Verifica l'esistenza di un numero per il documento.
            If eui_txtNumero.Text <> String.Empty And eui_txtNumero.Text <> "0" Then
               .Numero = Convert.ToInt32(eui_txtNumero.Text)
            Else
               MessageBox.Show("Non è possibile salvare il documento senza una numerazione valida! Verrà utilizzato l'ultimo numero disponibile.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

               ' Applica l'ultimo numero progressivo per il tipo di documento.
               eui_txtNumero.Text = eui_txtNumProgressivo.Text
               eui_txtNumero.Focus()

               Return False
            End If

            ' Verifica l'esistenza di almeno una riga di dettaglio per il documento.
            If dgvDettagli.Rows.Count = 1 Then
               MessageBox.Show("Non è possibile salvare il documento senza almeno una riga di dettaglio!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

               Return False
            End If

            .Tipo = eui_cmbTipoDocumento.Text
            .Anno = eui_txtAnno.Text
            .Data = eui_dtpData.Value.Value.Date
            .Ora = eui_txtOra.Text
            .Stato = eui_cmbStatoDocumento.Text
            .Causale = eui_cmbCausaleDocumento.Text

            .IdCliente = eui_txtIdCliente.Text
            If eui_cmbClienteCognome.Text & " " & eui_txtClienteNome.Text <> String.Empty Then
               .Cliente = eui_cmbClienteCognome.Text & " " & eui_txtClienteNome.Text
            Else
               .Cliente = String.Empty
            End If

            .Indirizzo = FormattaApici(eui_txtIndirizzo.Text)
            .Cap = FormattaApici(eui_txtCap.Text)
            .Città = FormattaApici(eui_txtCittà.Text)
            .Provincia = FormattaApici(eui_txtProvincia.Text)
            .PIva = eui_txtPartitaIva.Text
            .CodFiscale = eui_txtCodiceFiscale.Text
            .CodAzienda = String.Empty

            .Sconto = eui_txtTotaliSconto.Text
            .TipoSconto = String.Empty
            .Servizio = VALORE_ZERO
            .TipoServizio = String.Empty
            .Coperto = VALORE_ZERO
            .Contanti = eui_txtTotaliContanti.Text
            .Carte = eui_txtTotaliCarte.Text
            .BuoniPasto = eui_txtTotaliBuoni.Text
            .BuoniPastoIncassare = eui_txtTotaliBuoni.Text
            .Note = eui_txtNote.Text
            .Chiuso = "No"
            .Tavolo = eui_txtTavolo.Text
            .Cameriere = eui_txtCameriere.Text
            .Sospeso = valSospeso.ToString
            .SospesoIncassare = valSospeso.ToString
            .TotDoc = valDaPagare.ToString

            ' SCHEDA PA.
            .NumeroDoc_PA = eui_txtNumeroDoc_PA.Text
            .CodiceCUP_PA = eui_txtCodiceCUP_PA.Text
            .CodiceCIG_PA = eui_txtCodiceCIG_PA.Text
            .CodiceCommConv_PA = eui_txtCodiceCommConv_PA.Text

            ' Imposta il tipo di pagamento con il relativo importo.
            If eui_txtTotaliCarte.Text <> VALORE_ZERO And eui_txtTotaliCarte.Text <> String.Empty Then
               .TipoPagamento = eui_cmbTipoPagamento.Text & ": € " & CFormatta.FormattaNumeroDouble(Convert.ToDouble(eui_txtTotaliCarte.Text))
            Else
               If eui_txtTotaliContanti.Text <> VALORE_ZERO And eui_txtTotaliContanti.Text <> String.Empty Then
                  .TipoPagamento = "Contanti"
               Else
                  .TipoPagamento = String.Empty
               End If
            End If

            ' Se Fattura, Ricevuta o Scontrino salva l'iva...
            If eui_cmbTipoDocumento.Text = TIPO_DOC_FF Or eui_cmbTipoDocumento.Text = TIPO_DOC_RF Or eui_cmbTipoDocumento.Text = TIPO_DOC_SF Then

               .ImpLordoRep1 = eui_txtTotaliRep1ImponibileLordo.Text
               .ImpLordoRep2 = eui_txtTotaliRep2ImponibileLordo.Text
               .ImpLordoRep3 = eui_txtTotaliRep3ImponibileLordo.Text
               .ImpLordoRep4 = eui_txtTotaliRep4ImponibileLordo.Text

               .AliquotaIvaRep1 = eui_txtTotaliRep1Aliquota.Text
               .AliquotaIvaRep2 = eui_txtTotaliRep2Aliquota.Text
               .AliquotaIvaRep3 = eui_txtTotaliRep3Aliquota.Text
               .AliquotaIvaRep4 = eui_txtTotaliRep4Aliquota.Text

               .ImpostaRep1 = eui_txtTotaliRep1Imposta.Text
               .ImpostaRep2 = eui_txtTotaliRep2Imposta.Text
               .ImpostaRep3 = eui_txtTotaliRep3Imposta.Text
               .ImpostaRep4 = eui_txtTotaliRep4Imposta.Text

               .Imponibile = eui_txtImponibile.Text
               .Imposta = eui_txtImposta.Text
               .Iva = VALORE_ZERO
            Else
               .ImpLordoRep1 = VALORE_ZERO
               .ImpLordoRep2 = VALORE_ZERO
               .ImpLordoRep3 = VALORE_ZERO
               .ImpLordoRep4 = VALORE_ZERO

               .AliquotaIvaRep1 = VALORE_ZERO
               .AliquotaIvaRep2 = VALORE_ZERO
               .AliquotaIvaRep3 = VALORE_ZERO
               .AliquotaIvaRep4 = VALORE_ZERO

               .ImpostaRep1 = VALORE_ZERO
               .ImpostaRep2 = VALORE_ZERO
               .ImpostaRep3 = VALORE_ZERO
               .ImpostaRep4 = VALORE_ZERO

               .Imponibile = VALORE_ZERO
               .Iva = VALORE_ZERO
               .Imposta = VALORE_ZERO
            End If

            ' Se la proprietà 'Tag' contiene un valore viene richiamata la procedura
            ' di modifica dati, altrimenti viene richiamata la procedura di inserimento dati.
            If Me.Tag <> String.Empty Then
               ' Salva le modifiche effettuate al documento.
               .ModificaDati(TAB_DOCUMENTI, Me.Tag)

               ' Apre la connessione.
               cn.Open()

               ' Elimina le righe di dettaglio del documento per salvare quelle nuove.
               Dim sqlElimina As String
               Dim trElimina As OleDbTransaction

               ' Avvia una transazione.
               trElimina = cn.BeginTransaction(IsolationLevel.ReadCommitted)

               ' Crea la stringa di eliminazione.
               sqlElimina = String.Format("DELETE FROM {0} WHERE RifDoc = {1}", TAB_DETTAGLI_DOCUMENTI, Me.Tag)

               ' Crea il comando per la connessione corrente.
               Dim cmdDelete As New OleDbCommand(sqlElimina, cn, trElimina)

               ' Esegue il comando.
               Dim Record As Integer = cmdDelete.ExecuteNonQuery()

               ' Conferma la transazione.
               trElimina.Commit()
            Else
               ' Salva i dati del nuovo documento creato.
               .InserisciDati(TAB_DOCUMENTI)
            End If

            ' SALVA I DETTAGLI DEL DOCUMENTO.
            Dim sql As String
            ' Apre la connessione.
            If cn.State = ConnectionState.Closed Then
               cn.Open()
            End If

            Dim i As Integer
            For i = 0 To dgvDettagli.Rows.Count - 2 ' L'ultima riga è quella di inserimento dati.
               ' Avvia una transazione.
               tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
               ' Crea la stringa di inserimento dati.
               sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, UnitàMisura, Quantità, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                   "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @UnitàMisura, @Quantità, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", TAB_DETTAGLI_DOCUMENTI)

               ' Crea il comando per la connessione corrente.
               Dim cmdInsert As New OleDbCommand(sql, cn, tr)

               ' In caso di variante senza una quantità.
               Dim quantità As String

               If Me.Tag <> String.Empty Then
                  cmdInsert.Parameters.AddWithValue("@RifDoc", Me.Tag.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@RifDoc", LeggiUltimoRecord(TAB_DOCUMENTI))
               End If

               If IsNothing(dgvDettagli.Rows(i).Cells(clnCodice.Name).Value) = False Then
                  cmdInsert.Parameters.AddWithValue("@CodiceArticolo", dgvDettagli.Rows(i).Cells(clnCodice.Name).Value.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@CodiceArticolo", String.Empty)
               End If
               If IsNothing(dgvDettagli.Rows(i).Cells(clnDescrizione.Name).Value) = False Then
                  cmdInsert.Parameters.AddWithValue("@Descrizione", dgvDettagli.Rows(i).Cells(clnDescrizione.Name).Value.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@Descrizione", String.Empty)
               End If
               If IsNothing(dgvDettagli.Rows(i).Cells(clnUm.Name).Value) = False Then
                  cmdInsert.Parameters.AddWithValue("@UnitàMisura", dgvDettagli.Rows(i).Cells(clnUm.Name).Value.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@UnitàMisura", String.Empty)
               End If
               If IsNothing(dgvDettagli.Rows(i).Cells(clnQta.Name).Value) = False Then
                  cmdInsert.Parameters.AddWithValue("@Quantità", dgvDettagli.Rows(i).Cells(clnQta.Name).Value.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@Quantità", VALORE_ZERO)
               End If
               If IsNothing(dgvDettagli.Rows(i).Cells(clnPrezzo.Name).Value) = False Then
                  cmdInsert.Parameters.AddWithValue("@ValoreUnitario", dgvDettagli.Rows(i).Cells(clnPrezzo.Name).Value.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@ValoreUnitario", VALORE_ZERO)
               End If
               If IsNothing(dgvDettagli.Rows(i).Cells(clnSconto.Name).Value) = False Then
                  cmdInsert.Parameters.AddWithValue("@Sconto", dgvDettagli.Rows(i).Cells(clnSconto.Name).Value.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@Sconto", VALORE_ZERO)
               End If
               If IsNothing(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value) = False Then
                  cmdInsert.Parameters.AddWithValue("@ImportoNetto", dgvDettagli.Rows(i).Cells(clnImporto.Name).Value.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@ImportoNetto", VALORE_ZERO)
               End If
               If IsNothing(dgvDettagli.Rows(i).Cells(clnIva.Name).Value) = False Then
                  cmdInsert.Parameters.AddWithValue("@AliquotaIva", dgvDettagli.Rows(i).Cells(clnIva.Name).Value.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@AliquotaIva", 0)
               End If
               If IsNothing(dgvDettagli.Rows(i).Cells(clnCategoria.Name).Value) = False Then
                  cmdInsert.Parameters.AddWithValue("@Categoria", dgvDettagli.Rows(i).Cells(clnCategoria.Name).Value.ToString)
               Else
                  cmdInsert.Parameters.AddWithValue("@Categoria", String.Empty)
               End If

               ' Esegue il comando.
               Dim Record As Integer = cmdInsert.ExecuteNonQuery()
               ' Conferma transazione.
               tr.Commit()
            Next

            ' SALVA I DETTAGLI DELLE COMANDE.
            If eui_cmbTipoDocumento.Text = TIPO_DOC_CO Then

               Dim CComande As New Comande
               Dim J As Integer

               With CComande
                  .EliminaDati(TAB_COMANDE, eui_txtNumero.Text)

                  dgvDettagli.Focus()

                  For J = 0 To dgvDettagli.Rows.Count - 2 ' L'ultima riga è quella di inserimento dati.
                     .IdRisorsa = 0
                     .Risorsa = String.Empty
                     .Cameriere = String.Empty
                     .Coperti = "0"

                     If IsNothing(dgvDettagli.Rows(J).Cells(clnQta.Name).Value) = False Then
                        .Quantità = Convert.ToDouble(dgvDettagli.Rows(J).Cells(clnQta.Name).Value.ToString)
                     Else
                        .Quantità = 0
                     End If
                     If IsNothing(dgvDettagli.Rows(J).Cells(clnDescrizione.Name).Value) = False Then
                        .Descrizione = dgvDettagli.Rows(J).Cells(clnDescrizione.Name).Value.ToString
                     Else
                        .Descrizione = String.Empty
                     End If
                     If IsNothing(dgvDettagli.Rows(J).Cells(clnImporto.Name).Value) = False Then
                        .ImportoNetto = dgvDettagli.Rows(J).Cells(clnImporto.Name).Value.ToString
                     Else
                        .ImportoNetto = VALORE_ZERO
                     End If
                     If IsNothing(dgvDettagli.Rows(J).Cells(clnPrezzo.Name).Value) = False Then
                        .ValoreUnitario = dgvDettagli.Rows(J).Cells(clnPrezzo.Name).Value.ToString
                     Else
                        .ValoreUnitario = VALORE_ZERO
                     End If
                     If IsNothing(dgvDettagli.Rows(J).Cells(clnCodice.Name).Value) = False And IsNumeric(dgvDettagli.Rows(J).Cells(clnCodice.Name).Value) = True Then
                        .IdPiatto = dgvDettagli.Rows(J).Cells(clnCodice.Name).Value
                     Else
                        .IdPiatto = 0
                     End If
                     If IsNothing(dgvDettagli.Rows(J).Cells(clnCategoria.Name).Value) = False Then
                        .CategoriaPiatto = dgvDettagli.Rows(J).Cells(clnCategoria.Name).Value.ToString
                     Else
                        .CategoriaPiatto = VALORE_NESSUNA
                     End If
                     If IsNothing(dgvDettagli.Rows(J).Cells(clnIva.Name).Value) = False Then
                        .AliquotaIva = dgvDettagli.Rows(J).Cells(clnIva.Name).Value.ToString
                     Else
                        .AliquotaIva = 0
                     End If
                     ' DA_FARE_B: Aggiungere il reparto se si vuole fare inviare le comade dal punto cassa.
                     'If IsNothing(dgvDettagli.Rows(j).Cells(clnReparto.Name).Value) = False Then
                     '   .Reparto = dgvDettagli.Rows(j).Cells(clnReparto.Name).Value.ToString
                     'Else
                     '   .Reparto = String.Empty
                     'End If

                     .Reparto = String.Empty
                     .Inviata = "Sì"
                     .Esclusa = "No"
                     .Offerta = "No"
                     .NumeroConto = eui_txtNumero.Text

                     .InserisciDati(TAB_COMANDE)
                  Next
               End With
            End If

            ' Salva il Numero del prossimo documento da stampare.
            SalvaNumeroDocFiscaleConfig(TAB_DOCUMENTI, eui_cmbTipoDocumento.Text, Convert.ToInt32(eui_txtNumero.Text))

         End With

         If IsNothing(g_frmDocumenti) = False Then
            ' Aggiorna la griglia dati.
            g_frmDocumenti.AggiornaDati()
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

   Private Sub CalcolaImportoRigaDoc()
      Try
         ' Quantità.
         Dim qtà As Integer
         If IsNothing(dgvDettagli.CurrentRow.Cells(clnQta.Name).Value) = False Then
            If IsNumeric(dgvDettagli.CurrentRow.Cells(clnQta.Name).Value) = True Then
               qtà = Convert.ToInt32(dgvDettagli.CurrentRow.Cells(clnQta.Name).Value)
            End If
         End If

         ' Prezzo.
         Dim prezzo As Double
         If IsNothing(dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value) = False Then
            If IsNumeric(dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value) = True Then
               prezzo = Convert.ToDouble(dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value)
            End If
         End If

         ' Importo.
         Dim importo As Double = (prezzo * qtà)

         ' Sconto.
         Dim sconto As Double
         If IsNothing(dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value) = False Then
            If IsNumeric(dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value) = True Then
               sconto = Convert.ToDouble(dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value)
            End If
         End If

         ' Calcola il valore dello sconto
         Dim valSconto As Double = CalcolaPercentuale(importo, sconto)

         ' Sottrae lo sconto al valore dell'importo totale.
         importo = (importo - valSconto)

         ' Inserisce l'importo totale nella cella della riga corrente.
         dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = CFormatta.FormattaEuro(importo)

         ' Inserisce l'importo totale dello sconto nella cella della riga corrente.
         dgvDettagli.CurrentRow.Cells(clnValoreSconto.Name).Value = CFormatta.FormattaEuro(valSconto)

      Catch ex As FormatException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CalcolaImportoTotaleDoc()
      Try
         ' Importo.
         Dim importo As Double

         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 1
            ' Somma tutti gli importi delle righe del documento.
            importo = (importo + Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value))
         Next

         ' Aggiorna i totali.
         eui_txtTotaleDocumento.Text = CFormatta.FormattaEuro(importo)
         eui_txtTotaleConto.Text = CFormatta.FormattaEuro(importo)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CalcolaImportoTotaleIva()
      Try
         ' Importo.
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
         Dim valScontoDiviso As Double
         Dim valTotaleSconto As Double

         Dim j As Integer
         For j = 0 To dgvDettagli.Rows.Count - 2
            ' Verifica se l'importo è uno sconto (valore negativo).
            If IsNumeric(dgvDettagli.Rows(j).Cells(clnImporto.Name).Value) = True And dgvDettagli.Rows(j).Cells(clnImporto.Name).Value.ToString.Contains("-") = True Then
               valTotaleSconto = valTotaleSconto + Convert.ToDouble(dgvDettagli.Rows(j).Cells(clnImporto.Name).Value)

            ElseIf IsNumeric(dgvDettagli.Rows(j).Cells(clnImporto.Name).Value) = True And dgvDettagli.Rows(j).Cells(clnImporto.Name).Value.ToString <> VALORE_ZERO Then
               ' Conta il numero degli importi validi. 
               numTotaleImporti += 1
            End If
         Next

         ' SCONTO - Divide il valore dello SCONTO per il numero di elementi (Piatti) presenti nella lista.
         valScontoDiviso = valTotaleSconto / numTotaleImporti

         ' Somma tutti gli importi delle righe del documento.
         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 1

            Select Case dgvDettagli.Rows(i).Cells(clnRepartoIva.Name).Value

               Case "Reparto 1"
                  importo1 = Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  importo1 = (importo1 + valScontoDiviso)
                  percIva1 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile1 = valTotaleImponibile1 + CalcolaImponibileIva(percIva1.ToString, importo1)
                  valTotaleImpostaRep1 = CalcolaPercentuale(valTotaleImponibile1, percIva1)

               Case "Reparto 2"
                  importo2 = Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  importo2 = (importo2 + valScontoDiviso)
                  percIva2 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile2 = valTotaleImponibile2 + CalcolaImponibileIva(percIva2.ToString, importo2)
                  valTotaleImpostaRep2 = CalcolaPercentuale(valTotaleImponibile2, percIva2)

               Case "Reparto 3"
                  importo3 = Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  importo3 = (importo3 + valScontoDiviso)
                  percIva3 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile3 = valTotaleImponibile3 + CalcolaImponibileIva(percIva3.ToString, importo3)
                  valTotaleImpostaRep3 = CalcolaPercentuale(valTotaleImponibile3, percIva3)

               Case "Reparto 4"
                  importo4 = Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnImporto.Name).Value)
                  importo4 = (importo4 + valScontoDiviso)
                  percIva4 = Convert.ToInt32(dgvDettagli.Rows(i).Cells(clnIva.Name).Value)
                  valTotaleImponibile4 = valTotaleImponibile4 + CalcolaImponibileIva(percIva4.ToString, importo4)
                  valTotaleImpostaRep4 = CalcolaPercentuale(valTotaleImponibile4, percIva4)

            End Select
         Next

         ' Aggiorna i totali.

         ' Aliquote Iva.
         eui_txtTotaliRep1Aliquota.Text = percIva1.ToString
         eui_txtTotaliRep2Aliquota.Text = percIva2.ToString
         eui_txtTotaliRep3Aliquota.Text = percIva3.ToString
         eui_txtTotaliRep4Aliquota.Text = percIva4.ToString

         ' Imponibile.
         eui_txtTotaliRep1ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile1)
         eui_txtTotaliRep2ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile2)
         eui_txtTotaliRep3ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile3)
         eui_txtTotaliRep4ImponibileLordo.Text = CFormatta.FormattaEuro(valTotaleImponibile4)

         ' Imposte.
         eui_txtTotaliRep1Imposta.Text = CFormatta.FormattaEuro(valTotaleImpostaRep1)
         eui_txtTotaliRep2Imposta.Text = CFormatta.FormattaEuro(valTotaleImpostaRep2)
         eui_txtTotaliRep3Imposta.Text = CFormatta.FormattaEuro(valTotaleImpostaRep3)
         eui_txtTotaliRep4Imposta.Text = CFormatta.FormattaEuro(valTotaleImpostaRep4)

         ' Imponibile totale.
         eui_txtImponibile.Text = CFormatta.FormattaEuro((valTotaleImponibile1 + valTotaleImponibile2 + valTotaleImponibile3 + valTotaleImponibile4))
         eui_txtTotaliImponibile.Text = eui_txtImponibile.Text

         ' Imposta totale.
         eui_txtImposta.Text = CFormatta.FormattaEuro((valTotaleImpostaRep1 + valTotaleImpostaRep2 + valTotaleImpostaRep3 + valTotaleImpostaRep4))
         eui_txtTotaleImposta.Text = eui_txtImposta.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CalcolaTotaleSconto()
      Try
         Dim valSconto As Double

         Dim i As Integer
         For i = 0 To dgvDettagli.Rows.Count - 1
            ' Valore sconto per riga..
            If IsNothing(dgvDettagli.Rows(i).Cells(clnValoreSconto.Name).Value) = False Then
               If IsNumeric(dgvDettagli.Rows(i).Cells(clnValoreSconto.Name).Value) = True Then
                  valSconto = valSconto + Convert.ToDouble(dgvDettagli.Rows(i).Cells(clnValoreSconto.Name).Value)
               End If
            End If
         Next

         ' Totale sconto.
         eui_txtTotaliSconto.Text = CFormatta.FormattaEuro(valSconto)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub InserisciRepartoIva()
      Try
         Dim repIva As String = VerificaAliquotaIva(dgvDettagli.CurrentRow.Cells(clnIva.Name).Value.ToString)

         dgvDettagli.CurrentRow.Cells(clnRepartoIva.Name).Value = repIva

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub CaricaListaStatoDoc()
      Try
         ' Pulisce la lista.
         eui_cmbStatoDocumento.Items.Clear()

         Select Case eui_cmbTipoDocumento.Text
            Case TIPO_DOC_CO
               eui_cmbStatoDocumento.Items.Add("Bozza")
               eui_cmbStatoDocumento.Items.Add("Aperto")
               eui_cmbStatoDocumento.Items.Add("Chiuso")
               eui_cmbStatoDocumento.Items.Add("Importato")
               eui_cmbStatoDocumento.Items.Add("Annullato")
               eui_cmbStatoDocumento.Items.Add("Stampato")

            Case TIPO_DOC_PF
               eui_cmbStatoDocumento.Items.Add("Bozza")
               eui_cmbStatoDocumento.Items.Add("Importato")
               eui_cmbStatoDocumento.Items.Add("Annullato")
               eui_cmbStatoDocumento.Items.Add("Stampato")

            Case TIPO_DOC_RF, TIPO_DOC_SF
               eui_cmbStatoDocumento.Items.Add("Bozza")
               eui_cmbStatoDocumento.Items.Add("Emesso")
               eui_cmbStatoDocumento.Items.Add("Emesso e stampato")
               eui_cmbStatoDocumento.Items.Add("Annullato")
               eui_cmbStatoDocumento.Items.Add("Stampato")

            Case TIPO_DOC_FF
               eui_cmbStatoDocumento.Items.Add("Bozza")
               eui_cmbStatoDocumento.Items.Add("Emesso")
               eui_cmbStatoDocumento.Items.Add("Emesso e stampato")
               eui_cmbStatoDocumento.Items.Add("Annullato")
               eui_cmbStatoDocumento.Items.Add("Stampato")
               eui_cmbStatoDocumento.Items.Add("Emesso in XML")
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Function ApriClienti(ByVal val As String) As Boolean
      Try
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.AppStarting

         ' Per la versione demo.
         ' Se è un nuovo inserimento verifica il numero dei record.
         If val = String.Empty Then
            If g_VerDemo = True Then
               ' Test per la versione demo.
               If VerificaNumRecord(LeggiNumRecord(ANA_CLIENTI, cn, cmd)) = True Then
                  Exit Function
               End If
            End If
         End If

         Dim frm As New frmClienti
         frm.Tag = val

         If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
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

   Private Sub CaricaDatiCliente()
      Try
         ' Legge il nome relativo alla lista Cognome.
         eui_cmbIdCliente.SelectedIndex = eui_cmbClienteCognome.SelectedIndex
         eui_txtIdCliente.Text = eui_cmbIdCliente.Text

         Dim AClienti As New Anagrafiche.Cliente(ConnString)

         With AClienti
            .LeggiDati(ANA_CLIENTI, eui_cmbIdCliente.Text)

            eui_txtClienteNome.Text = .Nome
            eui_txtIndirizzo.Text = .Indirizzo1
            eui_txtCittà.Text = .Città
            eui_txtCap.Text = .Cap
            eui_txtProvincia.Text = .Provincia
            eui_txtPartitaIva.Text = .PIva
            eui_txtCodiceFiscale.Text = .CodFisc
            eui_txtSconto.Text = .Sconto

            ' DA_FARE_A: Valutare se leggere l'aliquota iva del cliente
            'eui_txtIva.Text = .Iva
         End With

         If eui_txtClienteNome.Text <> String.Empty Then
            eui_lblStatoClienteDoc.Text = eui_cmbClienteCognome.Text & " - " & eui_txtClienteNome.Text
         Else
            eui_lblStatoClienteDoc.Text = eui_cmbClienteCognome.Text
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

#Region "Procedure per Hotel "

   Private Sub CaricaDatiPrenotazione()
      Try
         eui_cmbCausaleDocumento.Text = "Vendita da hotel"

         ' Legge tutti i dati anagrafici del cliente selezionato.
         eui_cmbClienteCognome.Text = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_COGNOME)
         CaricaDatiCliente()

         eui_cmbTipoPagamento.Text = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_TIPO_PAGAMENTO)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Public Sub InserisciDettagliRigaPren()
      Try
         eui_cmdNuovaRiga.PerformClick()

         ' Codice.
         dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = String.Empty

         ' Descrizione.
         Dim numeroPren As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NUMERO_PREN)
         Dim dataArrivo As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_DATA_ARRIVO)
         Dim dataPartenza As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_DATA_PARTENZA)
         Dim arraggiamento As String = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ARRANGIAMENTO)
         Dim adulti As Integer = Convert.ToInt32(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ADULTI))
         Dim neonati As Integer = Convert.ToInt32(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NEONATI))
         Dim bambini As Integer = Convert.ToInt32(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_BAMBINI))
         Dim ragazzi As Integer = Convert.ToInt32(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_RAGAZZI))
         Dim persone As Integer = adulti + neonati + bambini + ragazzi

         dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = Today.ToShortDateString & " - Pren. N. " & numeroPren & " (Sogg. dal " & dataArrivo & " al " & dataPartenza & ") - (" & arraggiamento & " / Persone: " & persone.ToString & ")"

         ' Unità di misura.
         dgvDettagli.CurrentRow.Cells(clnUm.Name).Value = "GG"

         ' Quantità.
         dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NOTTI)

         ' Valore Unitario.
         dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_COSTO_CAMERA)

         ' Sconto %.
         dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value = VALORE_ZERO

         ' Importo.
         dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_IMPORTO_TOTALE)

         ' Aliquota Iva.
         dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = AliquotaIvaHotel

         ' Categoria.
         dgvDettagli.CurrentRow.Cells(clnCategoria.Name).Value = String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub InserisciDettagliRigaTassaSogg()
      Try
         DatiConfig = New AppConfig
         DatiConfig.ConfigType = ConfigFileType.AppConfig

         ' Se il campo Tassa di soggiorno ha un valore lo inserisce nel documento.
         If CFormatta.FormattaNumeroDouble(g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_TASSA_SOGGIORNO)) <> VALORE_ZERO Then

            eui_cmdNuovaRiga.PerformClick()

            ' Codice.
            dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = String.Empty

            ' Descrizione.
            dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = Today.ToShortDateString & " - " & DatiConfig.GetValue("DescrizioneTassaSoggHotel").ToString

            ' Unità di misura.
            dgvDettagli.CurrentRow.Cells(clnUm.Name).Value = "GG"

            ' Quantità.
            dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_NOTTI)

            ' Valore Unitario.
            dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value = g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_TASSA_SOGGIORNO)

            ' Sconto %.
            dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value = VALORE_ZERO

            ' Importo.
            dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = VALORE_ZERO

            ' Aliquota Iva.
            dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = 0

            ' Categoria.
            dgvDettagli.CurrentRow.Cells(clnCategoria.Name).Value = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub InserisciDettagliRigaDescrizioneAddebiti()
      Try
         eui_cmdNuovaRiga.PerformClick()

         ' Codice.
         dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = String.Empty

         ' Descrizione.
         dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = "ADDEBITI EXTRA"

         ' Unità di misura.
         dgvDettagli.CurrentRow.Cells(clnUm.Name).Value = String.Empty

         ' Quantità.
         dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = VALORE_ZERO

         ' Valore Unitario.
         dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value = VALORE_ZERO

         ' Sconto %.
         dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value = VALORE_ZERO

         ' Importo.
         dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = VALORE_ZERO

         ' Aliquota Iva.
         dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = 0

         ' Categoria.
         dgvDettagli.CurrentRow.Cells(clnCategoria.Name).Value = String.Empty

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Public Sub InserisciDettagliRigaAddebiti(ByVal tabella As String, ByVal id As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim addebiti As Boolean = True

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifPren = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            ' Inserisce una riga di descrizione.
            If addebiti = True Then
               InserisciDettagliRigaDescrizioneAddebiti()
            End If

            eui_cmdNuovaRiga.PerformClick()

            ' Codice.
            If IsDBNull(dr.Item("Codice")) = False Then
               dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = dr.Item("Codice")
            Else
               dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = String.Empty
            End If

            'Data.
            Dim data As String
            If IsDBNull(dr.Item("Data")) = False Then
               data = dr.Item("Data").ToString & " - "
            Else
               data = String.Empty
            End If

            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = data & dr.Item("Descrizione")
            Else
               dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = String.Empty
            End If

            ' Unità di misura.
            dgvDettagli.CurrentRow.Cells(clnUm.Name).Value = String.Empty

            ' Quantità.
            Dim qta As Double

            If IsDBNull(dr.Item("Quantità")) = False Then
               dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = dr.Item("Quantità")
               qta = dr.Item("Quantità")
            Else
               dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = VALORE_ZERO
               qta = VALORE_ZERO
            End If

            ' Valore Unitario.
            Dim importo As Double
            Dim valUnitario As Double

            If IsDBNull(dr.Item("Importo")) = False Then
               importo = dr.Item("Importo")
               valUnitario = importo / qta
            Else
               dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = VALORE_ZERO
               importo = VALORE_ZERO
               valUnitario = VALORE_ZERO
            End If

            dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value = valUnitario

            ' Importo.
            If IsDBNull(dr.Item("Importo")) = False Then
               dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = dr.Item("Importo")

            Else
               dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = VALORE_ZERO
            End If

            ' Sconto %.
            dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value = VALORE_ZERO

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = dr.Item("AliquotaIva")
            Else
               dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = "0"
            End If

            ' Categoria.
            If IsDBNull(dr.Item("Categoria")) = False Then
               dgvDettagli.CurrentRow.Cells(clnCategoria.Name).Value = dr.Item("Categoria")
            Else
               dgvDettagli.CurrentRow.Cells(clnCategoria.Name).Value = String.Empty
            End If

            ' Serve a non inserire più volte la descrizione,
            addebiti = False
         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub InserisciDettagliRigaServizio(ByVal tabella As String, ByVal id As Integer)
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)
         Dim valServizio As Double

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            ' Calcola il valore del servizio.
            If IsDBNull(dr.Item("Servizio")) = False Then
               Dim totConto As Double = Convert.ToDouble(dr.Item("TotaleConto"))
               Dim servizio As Double = Convert.ToDouble(dr.Item("Servizio"))

               If servizio <> 0 Then
                  valServizio = CalcolaPercentuale(totConto, servizio)
               Else
                  Exit Sub
               End If
            Else
               Exit Sub
            End If

            eui_cmdNuovaRiga.PerformClick()

            ' Codice.
            dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = String.Empty

            ' Descrizione.
            dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = "SERVIZIO " & dr.Item("Servizio").ToString & "%"

            ' Unità di misura.
            dgvDettagli.CurrentRow.Cells(clnUm.Name).Value = String.Empty

            ' Quantità.
            dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = "1"

            ' Valore Unitario / Importo.
            dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value = valServizio.ToString
            dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = valServizio.ToString

            ' Sconto %.
            dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value = VALORE_ZERO

            ' Aliquota Iva.
            dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = AliquotaIvaHotel

            ' Categoria.
            dgvDettagli.CurrentRow.Cells(clnCategoria.Name).Value = String.Empty

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

   Public Sub InserisciDettagliRigaSconto(ByVal tabella As String, ByVal id As Integer)
      Try
         ' Dichiara un oggetto connessione.
         Dim cn As New OleDbConnection(ConnString)
         Dim valSconto As Double

         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Id = " & id & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            ' Calcola il valore dello sconto sul totale del conto.
            If IsDBNull(dr.Item("Sconto")) = False Then
               Dim totConto As Double = Convert.ToDouble(dr.Item("ApplicaSconto"))
               Dim sconto As Double = Convert.ToDouble(dr.Item("Sconto"))

               If sconto <> 0 Then
                  valSconto = CalcolaPercentuale(totConto, sconto)
               Else
                  Exit Sub
               End If
            Else
               Exit Sub
            End If

            eui_cmdNuovaRiga.PerformClick()

            ' Codice.
            dgvDettagli.CurrentRow.Cells(clnCodice.Name).Value = String.Empty

            ' Descrizione.
            dgvDettagli.CurrentRow.Cells(clnDescrizione.Name).Value = "SCONTO " & dr.Item("Sconto").ToString & "%"

            ' Unità di misura.
            dgvDettagli.CurrentRow.Cells(clnUm.Name).Value = String.Empty

            ' Quantità.
            dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = "1"

            ' Valore Unitario / Importo.
            dgvDettagli.CurrentRow.Cells(clnPrezzo.Name).Value = -valSconto
            dgvDettagli.CurrentRow.Cells(clnImporto.Name).Value = -valSconto

            ' Sconto %.
            dgvDettagli.CurrentRow.Cells(clnSconto.Name).Value = VALORE_ZERO

            ' Aliquota Iva.
            dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = "0"

            ' Categoria.
            dgvDettagli.CurrentRow.Cells(clnCategoria.Name).Value = String.Empty

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Sub

#End Region

   Private Sub frmDocumento_Load(sender As Object, e As EventArgs) Handles MyBase.Load
      Try
         ImpostaIcona(Me)

         eui_lblStatoClienteDoc.Text = String.Empty

         CaricaLista(eui_cmbTipoDocumento, TAB_TIPO_DOCUMENTI)
         CaricaLista(eui_cmbCausaleDocumento, TAB_CAUSALI_DOCUMENTI)
         CaricaListaClienti(eui_cmbClienteCognome, eui_cmbIdCliente, ANA_CLIENTI)
         CaricaLista(eui_cmbTipoPagamento, TAB_TIPO_PAGAMENTO)

         ' Imposta il tipo di pagamento.
         eui_cmbTipoPagamento.Text = "Contanti"

         Select Case nomeFinestra
            Case "ContoPos"
               ' Il form non viene aperto dal conto pos.
               'LeggiDatiConto()

            Case "ElencoDoc"
               ' Se il tipo documento è una stringa vuota apre la finestra per la modifica di un documento,
               ' altrimenti apre la finestra per un nuovo documento.
               If idDocumento = String.Empty Then
                  NuovoDocumento()
               Else
                  ModificaDocumento()
               End If

            Case "ElencoPrenCamere"
               ' Carica la lista dei documenti. 
               eui_cmbTipoDocumento.Items.Clear()
               eui_cmbTipoDocumento.Items.Add(TIPO_DOC_PF)
               eui_cmbTipoDocumento.Items.Add(TIPO_DOC_RF)
               eui_cmbTipoDocumento.Items.Add(TIPO_DOC_FF)

               ' Crea un nuovo documento con i dati della prenotazione.
               NuovoDocumento()

               ' Carica i dati della prenotazione camera.
               CaricaDatiPrenotazione()

               ' Inserisce la tipologia di arrangiamento nel dettaglio riga.
               InserisciDettagliRigaPren()

               ' Inserisce la tassa di soggiorno nel dettaglio riga.
               InserisciDettagliRigaTassaSogg()

               ' Inserisce eventuali addebiti exstra.
               InserisciDettagliRigaAddebiti("PrenCamereAddebiti", g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ID_DOC))

               ' Inserisce eventuali costi di servizio.
               InserisciDettagliRigaServizio("PrenCamere", g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ID_DOC))

               'Inserisce eventuali sconti.
               InserisciDettagliRigaSconto("PrenCamere", g_frmPrenCamere.DataGrid1.Item(g_frmPrenCamere.DataGrid1.CurrentCell.RowNumber, g_frmPrenCamere.COLONNA_ID_DOC))
         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         ' Modifica il cursore del mouse.
         Cursor.Current = Cursors.Default

      End Try
   End Sub

   Private Sub frmDocumento_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
      Try
         ' Distrugge l'oggetto e libera le risorse.
         g_frmDocumento.Dispose()
         g_frmDocumento = Nothing

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub frmDocumento_Resize(sender As Object, e As EventArgs) Handles Me.Resize
      Try
         ' Larghezza minima.
         If Me.Width <= 825 Then
            Me.Width = 825
         End If

         ' Altezza minima.
         If Me.Height <= 660 Then
            Me.Height = 660
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdNuovoCliente_Click(sender As Object, e As EventArgs) Handles eui_cmdNuovoCliente.Click
      Try
         ' Inserimento nuovo cliente...
         If ApriClienti(String.Empty) = True Then
            CaricaListaClienti(eui_cmbClienteCognome, eui_cmbIdCliente, ANA_CLIENTI)

            eui_cmbIdCliente.Text = String.Empty
            eui_cmbClienteCognome.Text = String.Empty
            eui_txtClienteNome.Text = String.Empty
            eui_txtIndirizzo.Text = String.Empty
            eui_txtCittà.Text = String.Empty
            eui_txtCap.Text = String.Empty
            eui_txtProvincia.Text = String.Empty
            eui_txtPartitaIva.Text = String.Empty
            eui_txtCodiceFiscale.Text = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdModificaCliente_Click(sender As Object, e As EventArgs) Handles eui_cmdModificaCliente.Click
      Try
         ' Modifica cliente esistente...
         If ApriClienti(eui_cmbIdCliente.Text) = True Then
            CaricaListaClienti(eui_cmbClienteCognome, eui_cmbIdCliente, ANA_CLIENTI)

            eui_cmbIdCliente.Text = String.Empty
            eui_cmbClienteCognome.Text = String.Empty
            eui_txtClienteNome.Text = String.Empty
            eui_txtIndirizzo.Text = String.Empty
            eui_txtCittà.Text = String.Empty
            eui_txtCap.Text = String.Empty
            eui_txtProvincia.Text = String.Empty
            eui_txtPartitaIva.Text = String.Empty
            eui_txtCodiceFiscale.Text = String.Empty
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmbClienteCognome_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbClienteCognome.SelectedIndexChanged
      ' Legge tutti i dati anagrafici del cliente selezionato.
      CaricaDatiCliente()
   End Sub

   Private Sub eui_cmbTipoDocumento_SelectedIndexChanged(sender As Object, e As EventArgs) Handles eui_cmbTipoDocumento.SelectedIndexChanged
      Try
         ' In caso di Documento esistente.
         If idDocumento <> String.Empty Then
            idDocumento = String.Empty
            Exit Sub
         End If

         Dim NumeroDocumento As Integer

         Select Case eui_cmbTipoDocumento.Text
            Case TIPO_DOC_CO, TIPO_DOC_PF
               NumeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, eui_cmbTipoDocumento.Text) + 1

               eui_cmdAnteprima.Enabled = True
               eui_cmdEmettiStampa.Enabled = False
               eui_cmdEmetti.Enabled = False

            Case TIPO_DOC_RF, TIPO_DOC_FF
               NumeroDocumento = LeggiNumeroDocFiscaleConfig(TAB_DOCUMENTI, eui_cmbTipoDocumento.Text)

               eui_cmdAnteprima.Enabled = True
               eui_cmdEmettiStampa.Enabled = True
               eui_cmdEmetti.Enabled = True

            Case TIPO_DOC_SF
               NumeroDocumento = LeggiNumeroMax(TAB_DOCUMENTI, eui_cmbTipoDocumento.Text) + 1

               eui_cmdAnteprima.Enabled = False
               eui_cmdEmettiStampa.Enabled = False
               eui_cmdEmetti.Enabled = True

         End Select

         ' Carica i dati appropriati per la lista.
         CaricaListaStatoDoc()

         eui_txtNumero.Text = NumeroDocumento.ToString
         eui_txtNumProgressivo.Text = NumeroDocumento.ToString

         Me.Text = eui_cmbTipoDocumento.Text & statoDoc

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_txtNumero_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtNumero.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeri(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Function LeggiNomeReport(ByVal tipoDoc As String) As String
      Try
         Dim percorsoReport As String

         ' Imposta il nome del Report.
         Select Case tipoDoc
            Case TIPO_DOC_CO, TIPO_DOC_PF

               ' Conto e Proforma.
               If ImpostaNomeDoc(2) <> String.Empty Then
                  percorsoReport = "\Reports\" & ImpostaNomeDoc(2)
               Else
                  percorsoReport = PERCORSO_REP_PF_A4_DOPPIA
               End If

            Case TIPO_DOC_RF

               ' Ricevuta Fiscale.
               If ImpostaNomeDoc(0) <> String.Empty Then
                  percorsoReport = "\Reports\" & ImpostaNomeDoc(0)
               Else
                  percorsoReport = PERCORSO_REP_RF_A4_DOPPIA
               End If

            Case TIPO_DOC_FF

               ' Fattura.
               If ImpostaNomeDoc(1) <> String.Empty Then
                  percorsoReport = "\Reports\" & ImpostaNomeDoc(1)
               Else
                  percorsoReport = PERCORSO_REP_FF_A4_DOPPIA
               End If

            Case TIPO_DOC_SF

               ' Scontrino.
               If ImpostaNomeDoc(3) <> String.Empty Then
                  percorsoReport = "\Reports\" & ImpostaNomeDoc(3)
               Else
                  percorsoReport = PERCORSO_REP_SF
               End If

         End Select

         Return percorsoReport

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Function

   Private Function LeggiNomeStampante(ByVal tipoDoc As String) As String
      Try
         Dim percorsoStampante As String

         ' Imposta il nome del Report.
         Select Case tipoDoc
            Case TIPO_DOC_CO, TIPO_DOC_PF

               ' Imposta il percorso completo del nome stampante.
               percorsoStampante = ImpostaNomeStampante(2)

            Case TIPO_DOC_RF

               ' Imposta il percorso completo del nome stampante.
               percorsoStampante = ImpostaNomeStampante(0)

            Case TIPO_DOC_FF

               ' Imposta il percorso completo del nome stampante.
               percorsoStampante = ImpostaNomeStampante(1)

            Case TIPO_DOC_SF

               ' Imposta il percorso completo del nome stampante.
               percorsoStampante = ImpostaNomeStampante(3)

         End Select

         Return percorsoStampante

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return String.Empty

      End Try

   End Function

   Private Sub AnteprimaDiStampa()
      Try
         ' Ottiene l'Id del documento.
         Dim idDocumento As String
         If Me.Tag = String.Empty Then
            ' Nuovo documento.
            idDocumento = LeggiUltimoRecord(TAB_DOCUMENTI)
         Else
            ' Documento esistente.
            idDocumento = Me.Tag
         End If

         ' Stampare il documento...
         'Utilizzare il modello di oggetti ADO .NET per impostare le informazioni di connessione. 
         Dim cn As New OleDbConnection(ConnString)

         cn.Open()

         ' Tabella Documenti.
         Dim oleAdapter As New OleDbDataAdapter
         oleAdapter.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_DOCUMENTI & " WHERE Id = " & idDocumento, cn)
         Dim ds As New HospitalityDataSet 'Dataset1 'utilizzato con Crystal Reports
         ds.Clear()
         oleAdapter.Fill(ds, TAB_DOCUMENTI)

         ' Tabella DettagliDoc
         Dim oleAdapter1 As New OleDbDataAdapter
         oleAdapter1.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_DETTAGLI_DOCUMENTI & " WHERE RifDoc = " & idDocumento, cn)
         oleAdapter1.Fill(ds, TAB_DETTAGLI_DOCUMENTI)

         ' Tabella Azienda
         Dim oleAdapter2 As New OleDbDataAdapter
         oleAdapter2.SelectCommand = New OleDbCommand("SELECT * FROM " & TAB_AZIENDA, cn)
         oleAdapter2.Fill(ds, TAB_AZIENDA)

         ' ReportViewer - Apre la finestra di Anteprima di stampa per il documento.
         Dim frm As New RepDocumenti(ds, LeggiNomeReport(eui_cmbTipoDocumento.Text), LeggiNomeStampante(eui_cmbTipoDocumento.Text))
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try

   End Sub

   Private Sub eui_cmdImportaDoc_Click(sender As Object, e As EventArgs) Handles eui_cmdImportaDoc.Click
      Try
         Dim frm As New ListaDocumenti(eui_cmbClienteCognome.Text & " " & eui_txtClienteNome.Text)
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdSalva_Click(sender As Object, e As EventArgs) Handles eui_cmdSalva.Click
      Try
         ' Salva il documento e chiude la finestra.
         If SalvaDocumento() = True Then
            Me.Close()

            ' Se aperto aggiorna l'elenco documenti.
            If IsNothing(g_frmDocumenti) = False Then
               g_frmDocumenti.AggiornaDati()
            End If
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnnulla_Click(sender As Object, e As EventArgs) Handles eui_cmdAnnulla.Click
      Try
         Me.Close()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdAnteprima_Click(sender As Object, e As EventArgs) Handles eui_cmdAnteprima.Click
      Try
         ' Salva le modifiche apportate al documento.
         If SalvaDocumento() = True Then

            ' Apre l'anteprima di stampa per il documento selezionato.
            AnteprimaDiStampa()

            Select Case eui_cmbStatoDocumento.Text
               Case STATO_DOC_ANNULLATO, STATO_DOC_EMESSO_STAMPATO
                  Exit Sub

               Case STATO_DOC_EMESSO
                  ' Modifica lo stato del documento.
                  If Me.Tag <> String.Empty Then
                     ModificaStatoDocumento(TAB_DOCUMENTI, Me.Tag, STATO_DOC_EMESSO_STAMPATO)
                  Else
                     ModificaStatoDocumento(TAB_DOCUMENTI, LeggiUltimoRecord(TAB_DOCUMENTI), STATO_DOC_EMESSO_STAMPATO)
                  End If

               Case Else
                  ' Modifica lo stato del documento.
                  If Me.Tag <> String.Empty Then
                     ModificaStatoDocumento(TAB_DOCUMENTI, Me.Tag, STATO_DOC_STAMPATO)
                  Else
                     ModificaStatoDocumento(TAB_DOCUMENTI, LeggiUltimoRecord(TAB_DOCUMENTI), STATO_DOC_STAMPATO)
                  End If

            End Select
         Else
            MessageBox.Show("Il comando non è stato eseguito! Verificare di avere compilato correttamente il documento e riprovare.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdStampa_Click(sender As Object, e As EventArgs) Handles eui_cmdStampa.Click
      'Try
      '   ' Salva le modifiche apportate al documento.
      '   If SalvaDocumento() = True Then

      '      ' Stampare il documento...

      '      Select Case eui_cmbStatoDocumento.Text
      '         Case STATO_DOC_ANNULLATO, STATO_DOC_EMESSO_STAMPATO
      '            Exit Sub

      '         Case STATO_DOC_EMESSO
      '            ' Modifica lo stato del documento.
      '            ModificaStatoDocumento(TAB_DOCUMENTI, LeggiUltimoRecord(TAB_DOCUMENTI), STATO_DOC_EMESSO_STAMPATO)

      '         Case Else
      '            ' Modifica lo stato del documento.
      '            ModificaStatoDocumento(TAB_DOCUMENTI, LeggiUltimoRecord(TAB_DOCUMENTI), STATO_DOC_STAMPATO)

      '      End Select

      '      Me.Close()
      '   Else
      '      MessageBox.Show("Il comando non è stato eseguito! Verificare di avere compilato correttamente il documento e riprovare.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

      '   End If

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub eui_cmdEmettiStampa_Click(sender As Object, e As EventArgs) Handles eui_cmdEmettiStampa.Click
      Try
         ' Salva le modifiche apportate al documento.
         If SalvaDocumento() = True Then

            ' Scarica le quantità degli articoli dal magazzino.
            ScaricaIngredienti()

            '  Salva i dati per le statistiche.
            SalvaStatistiche(True)

            ' Modifica lo stato del documento.
            If Me.Tag <> String.Empty Then
               ModificaStatoDocumento(TAB_DOCUMENTI, Me.Tag, STATO_DOC_EMESSO_STAMPATO)
            Else
               ModificaStatoDocumento(TAB_DOCUMENTI, LeggiUltimoRecord(TAB_DOCUMENTI), STATO_DOC_EMESSO_STAMPATO)
            End If

            MessageBox.Show("Tutte le operazioni contabili sono state eseguite!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            If IsNothing(g_frmDocumenti) = False Then
               ' Aggiorna la griglia dati.
               g_frmDocumenti.AggiornaDati()
            End If

            ' Apre l'anteprima di stampa per il documento selezionato.
            AnteprimaDiStampa()

            Me.Close()
         Else
            MessageBox.Show("Il comando non è stato eseguito! Verificare di avere compilato correttamente il documento e riprovare.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdEmetti_Click(sender As Object, e As EventArgs) Handles eui_cmdEmetti.Click
      Try
         ' Salva le modifiche apportate al documento.
         If SalvaDocumento() = True Then

            ' Scarica le quantità degli articoli dal magazzino.
            ScaricaIngredienti()

            '  Salva i dati per le statistiche.
            SalvaStatistiche(True)

            ' Modifica lo stato del documento.
            If Me.Tag <> String.Empty Then
               ModificaStatoDocumento(TAB_DOCUMENTI, Me.Tag, STATO_DOC_EMESSO)
            Else
               ModificaStatoDocumento(TAB_DOCUMENTI, LeggiUltimoRecord(TAB_DOCUMENTI), STATO_DOC_EMESSO)
            End If

            If IsNothing(g_frmDocumenti) = False Then
               ' Aggiorna la griglia dati.
               g_frmDocumenti.AggiornaDati()
            End If

            MessageBox.Show("Tutte le operazioni contabili sono state eseguite!", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

            Me.Close()
         Else
            MessageBox.Show("Il comando non è stato eseguito! Verificare di avere compilato correttamente il documento e riprovare.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Information)

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtNumero_TextChanged(sender As Object, e As EventArgs) Handles eui_txtNumero.TextChanged
      Try
         eui_lblStatoNumeroDoc.Text = eui_txtNumero.Text & "/" & eui_txtAnno.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtAnno_TextChanged(sender As Object, e As EventArgs) Handles eui_txtAnno.TextChanged
      Try
         eui_lblStatoNumeroDoc.Text = eui_txtNumero.Text & "/" & eui_txtAnno.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_dtpData_ValueChanged(sender As Object, e As EventArgs) Handles eui_dtpData.ValueChanged
      Try
         eui_lblStatoDataDoc.Text = eui_dtpData.Value.GetValueOrDefault.ToShortDateString

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaleDocumento_TextChanged(sender As Object, e As EventArgs) Handles eui_txtTotaleDocumento.TextChanged
      Try
         eui_lblStatoTotaleDoc.Text = eui_txtTotaleDocumento.Text

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdInsPiatti_Click(sender As Object, e As EventArgs) Handles eui_cmdInsPiatti.Click
      Try
         Dim frm As New ListaPiatti
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdInsAccessori_Click(sender As Object, e As EventArgs) Handles eui_cmdInsAccessori.Click
      Try
         Dim frm As New ListaAccessoriServizi("Accessorio")
         frm.Tag = "Documento"
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdInsiServizi_Click(sender As Object, e As EventArgs) Handles eui_cmdInsiServizi.Click
      Try
         Dim frm As New ListaAccessoriServizi("Servizio")
         frm.Tag = "Documento"
         frm.ShowDialog()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_tpcDocumento_SelectedTabPageChanged(sender As Object, e As TabPageChangedEventArgs) Handles eui_tpcDocumento.SelectedTabPageChanged
      Try
         ' Applica lo stato attivo dei rispettivi controlli in base alla selezione della scheda.
         Select Case eui_tpcDocumento.SelectedTabPage.Text
            Case "&Generale"
               eui_txtNumero.Focus()

            Case "&Dettagli"
               dgvDettagli.Focus()

            Case "&PA"
               eui_txtNumeroDoc_PA.Focus()

            Case "&Totali"
               eui_txtTotaliContanti.Focus()

            Case "&Note"
               eui_txtNote.Focus()

         End Select

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdNuovaRiga_Click(sender As Object, e As EventArgs) Handles eui_cmdNuovaRiga.Click
      Try
         dgvDettagli.Focus()
         dgvDettagli.Rows.Add()
         dgvDettagli.Rows.Item(dgvDettagli.Rows.Count - 2).Selected = True
         dgvDettagli.Rows.Item(dgvDettagli.Rows.Count - 2).Cells.Item(0).Selected = True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_cmdEliminaRiga_Click(sender As Object, e As EventArgs) Handles eui_cmdEliminaRiga.Click
      Try
         dgvDettagli.Focus()
         dgvDettagli.Rows.Remove(dgvDettagli.CurrentRow)

         CalcolaImportoRigaDoc()
         CalcolaTotaleSconto()
         CalcolaImportoTotaleIva()
         CalcolaImportoTotaleDoc()

      Catch ex As InvalidOperationException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_cmdCancellaTutto_Click(sender As Object, e As EventArgs) Handles eui_cmdCancellaTutto.Click
      Try
         dgvDettagli.Focus()
         dgvDettagli.Rows.Clear()
         'dgvDettagli.Rows.Add()

         CalcolaImportoRigaDoc()
         CalcolaTotaleSconto()
         CalcolaImportoTotaleIva()
         CalcolaImportoTotaleDoc()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub CalcolaImportoSospeso()
      Try
         Dim totaleDoc As Double = Convert.ToDouble(eui_txtTotaleConto.Text)
         Dim contanti As Double = Convert.ToDouble(eui_txtTotaliContanti.Text)
         Dim carte As Double = Convert.ToDouble(eui_txtTotaliCarte.Text)
         Dim buoni As Double = Convert.ToDouble(eui_txtTotaliBuoni.Text)
         Dim valPagamento As Double = contanti + carte + buoni
         Dim sospeso As Double = totaleDoc - valPagamento

         If valPagamento > totaleDoc Then
            MessageBox.Show("Il valore dei pagamenti specificati non può essere maggiore dell'importo totale del documento.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            eui_txtTotaliContanti.Text = eui_txtTotaleConto.Text
            eui_txtTotaliCarte.Text = VALORE_ZERO
            eui_txtTotaliBuoni.Text = VALORE_ZERO
         Else
            eui_txtTotaliSospeso.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sospeso))
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         eui_txtTotaliSospeso.Text = VALORE_ZERO
      End Try
   End Sub

   Private Sub dgvDettagli_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDettagli.CellValueChanged
      Try
         ' Se ci sono righe nel documento...
         If dgvDettagli.Rows.Count <> 1 Then

            If IsNothing(dgvDettagli.CurrentRow.Cells(clnIva.Name).Value) = False Then

               If VerificaAliquotaIva(dgvDettagli.CurrentRow.Cells(clnIva.Name).Value.ToString) = String.Empty Then

                  If IsNumeric(dgvDettagli.CurrentRow.Cells(clnIva.Name).Value.ToString) = False Then
                     MessageBox.Show("Il valore dell'aliquota Iva inserito non è corretto!" & vbCrLf &
                                     "Inserire una delle quattro aliquote impostate nel programma. (Vedere finestra Opzioni)", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                  Else
                     dgvDettagli.CurrentRow.Cells(clnIva.Name).Value = 0

                  End If
               Else
                  InserisciRepartoIva()
               End If
            End If

            ' Questa riga è necessaria altrimenti non calcola lo sconto inserito. 
            Dim qtà As Integer = dgvDettagli.CurrentRow.Cells(clnQta.Name).Value

            CalcolaImportoRigaDoc()
            CalcolaTotaleSconto()
            CalcolaImportoTotaleIva()
            CalcolaImportoTotaleDoc()

            ' Questa riga è necessaria altrimenti non calcola lo sconto inserito. 
            dgvDettagli.CurrentRow.Cells(clnQta.Name).Value = qtà

         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub dgvDettagli_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvDettagli.CellFormatting
      Try
         Select Case e.ColumnIndex
            Case 0, 1, 2
               ' Colonne da non formattare (Codice, Descrizione, Unità di misura).
               Exit Sub

            Case Else
               ' Tutte le altre colonne da formattare.

               Dim valCell As Double
               If IsNothing(e.Value) = False Then
                  If IsNumeric(e.Value) = True Then
                     ' Colonna Iva.
                     If e.ColumnIndex = 7 Then
                        Exit Sub
                     Else
                        valCell = Convert.ToDouble(e.Value)
                        e.Value = CFormatta.FormattaNumeroDouble(valCell)
                     End If
                  Else
                     ' Colonna Iva.
                     If e.ColumnIndex = 7 Then
                        e.Value = 0
                     Else
                        e.Value = VALORE_ZERO
                     End If
                  End If
               End If

         End Select

      Catch ex As FormatException
         Exit Sub

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliRep1ImponibileLordo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep1ImponibileLordo.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep2ImponibileLordo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep2ImponibileLordo.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep1Aliquota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep1Aliquota.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep1Imposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep1Imposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep2Aliquota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep2Aliquota.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep2Imposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep2Imposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep3Aliquota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep3Aliquota.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep3ImponibileLordo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep3ImponibileLordo.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep3Imposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep3Imposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep4Aliquota_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep4Aliquota.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep4ImponibileLordo_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep4ImponibileLordo.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliRep4Imposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliRep4Imposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliSconto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliSconto.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliServizio_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliServizio.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliImponibile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliImponibile.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaleDocumento_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaleDocumento.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaleImposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaleImposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaleConto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaleConto.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtImponibile_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtImponibile.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtImposta_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtImposta.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliCoperto_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliCoperto.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliContanti_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliContanti.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try

   End Sub

   Private Sub eui_txtTotaliCarte_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliCarte.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliBuoni_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliBuoni.KeyPress
      Try
         e.Handled = CConvalida.DigitaSoloNumeriPuntegg(e.KeyChar)

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliSospeso_KeyPress(sender As Object, e As KeyPressEventArgs) Handles eui_txtTotaliSospeso.KeyPress
      ' Annulla il carattere premuto. 
      e.KeyChar = String.Empty
   End Sub

   Private Sub eui_txtTotaliCoperto_LostFocus(sender As Object, e As EventArgs) Handles eui_txtTotaliCoperto.LostFocus
      ' Non usata!
      Try
         If IsNumeric(sender.Text) = True Then
            sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliContanti_LostFocus(sender As Object, e As EventArgs) Handles eui_txtTotaliContanti.LostFocus
      Try
         If IsNumeric(sender.Text) = True Then
            Dim totaleDoc As Double = Convert.ToDouble(eui_txtTotaleConto.Text)
            Dim contanti As Double = Convert.ToDouble(eui_txtTotaliContanti.Text)

            If contanti > totaleDoc Then
               MessageBox.Show("Il valore specificato per i Contanti non può essere maggiore dell'importo totale del documento.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

               sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(eui_txtTotaleConto.Text))
               eui_txtTotaliCarte.Text = VALORE_ZERO
               eui_txtTotaliBuoni.Text = VALORE_ZERO

               Exit Sub
            Else
               sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
            End If
         Else
            sender.Text = VALORE_ZERO
         End If

         CalcolaImportoSospeso()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliCarte_LostFocus(sender As Object, e As EventArgs) Handles eui_txtTotaliCarte.LostFocus
      Try
         If IsNumeric(sender.Text) = True Then
            Dim totaleDoc As Double = Convert.ToDouble(eui_txtTotaleConto.Text)
            Dim carte As Double = Convert.ToDouble(eui_txtTotaliCarte.Text)

            If carte > totaleDoc Then
               MessageBox.Show("Il valore specificato per le Carte di credito non può essere maggiore dell'importo totale del documento.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

               sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(eui_txtTotaleConto.Text))
               eui_txtTotaliContanti.Text = VALORE_ZERO
               eui_txtTotaliBuoni.Text = VALORE_ZERO

               Exit Sub
            Else
               sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
            End If
         Else
            sender.Text = VALORE_ZERO
         End If

         CalcolaImportoSospeso()

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      End Try
   End Sub

   Private Sub eui_txtTotaliBuoni_LostFocus(sender As Object, e As EventArgs) Handles eui_txtTotaliBuoni.LostFocus
      ' NON UTILIZZATA!
      'Try
      '   If IsNumeric(sender.Text) = True Then
      '      Dim totaleDoc As Double = Convert.ToDouble(eui_txtTotaleConto.Text)
      '      Dim buoni As Double = Convert.ToDouble(eui_txtTotaliBuoni.Text)

      '      If buoni > totaleDoc Then
      '         MessageBox.Show("Il valore specificato per i Buoni pasto non può essere maggiore dell'importo totale del documento.", NOME_PRODOTTO, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

      '         sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(eui_txtTotaleConto.Text))
      '         eui_txtTotaliContanti.Text = VALORE_ZERO
      '         eui_txtTotaliCarte.Text = VALORE_ZERO

      '         Exit Sub
      '      Else
      '         sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
      '      End If
      '   Else
      '      sender.Text = VALORE_ZERO
      '   End If

      '   CalcolaImportoSospeso()

      'Catch ex As Exception
      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      'End Try
   End Sub

   Private Sub eui_txtTotaliSospeso_LostFocus(sender As Object, e As EventArgs) Handles eui_txtTotaliSospeso.LostFocus
      Try
         If IsNumeric(sender.Text) = True Then
            sender.Text = CFormatta.FormattaNumeroDouble(Convert.ToDouble(sender.Text))
         Else
            sender.Text = VALORE_ZERO
         End If

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

End Class
