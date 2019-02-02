#Region " DATI FILE.VB "
' ****************************************************************************************
' Nome Classe:          PrenCamere
' Autore:               Luigi Montana, Montana Software
' Data creazione:       01/08/2016
' Data ultima modifica: 15/09/2018
' Descrizione:          Classe per la gestione dei dati della Tabella PrenCamere.
' Note:
'
' Elenco Attivita:
'
' *****************************************************************************************
#End Region

Imports System.Data.OleDb

Public Class PrenCamere

   Public Codice As Integer
   Public IdCliente As Integer
   Public Numero As Integer
   Public Data As String
   Public Tipologia As String
   Public Stato As String
   Public Cognome As String
   Public Nome As String
   Public Provincia As String
   Public Nazionalità As String
   Public Adulti As Integer
   Public Neonati As Integer
   Public Bambini As Integer
   Public Ragazzi As Integer
   Public NumeroCamera As String
   Public DescrizioneCamera As String
   Public Trattamento As String
   Public Gruppo As String
   Public Agenzia As String
   Public CanaleVendita As String
   Public DataArrivo As String
   Public DataPartenza As String
   Public OraArrivo As String
   Public NumeroNotti As Integer
   Public Listino As String
   Public Pagamento As String
   Public CostoCamera As String
   Public TassaSoggiorno As String
   Public AccontoCamera As String
   Public TotaleConto As String
   Public ApplicaSconto As String
   Public Sconto As String
   Public Servizio As String
   Public Schedina As String
   Public Colore As Integer
   Public Note As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore

   Public Sub LeggiDati(ByVal tabella As String, ByVal codice As String)
      ' Dichiara un oggetto DataAdapter.
      Dim da As OleDbDataAdapter
      ' Dichiara un oggetto DataSet
      Dim ds As DataSet
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Crea la stringa.
         sql = String.Format("SELECT * FROM {0} WHERE Id = {1}", tabella, codice)

         ' Dichiara un oggetto DataAdapter.
         da = New OleDbDataAdapter(sql, cn)

         ' Dichiara un oggetto DataSet
         ds = New DataSet

         ' Riempe il DataSet con i dati della tabella.
         da.Fill(ds, tabella)

         ' Assegna i valori dei campi del DataSet ai campi della classe.
         If IsDBNull(ds.Tables(tabella).Rows(0)("Id")) = False Then
            Me.Codice = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Id"))
         Else
            Me.Codice = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdCliente")) = False Then
            Me.IdCliente = Convert.ToInt32(ds.Tables(tabella).Rows(0)("IdCliente"))
         Else
            Me.IdCliente = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Numero")) = False Then
            Me.Numero = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Numero"))
         Else
            Me.Numero = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Data")) = False Then
            Me.Data = ds.Tables(tabella).Rows(0)("Data").ToString
         Else
            Me.Data = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Tipologia")) = False Then
            Me.Tipologia = ds.Tables(tabella).Rows(0)("Tipologia").ToString
         Else
            Me.Tipologia = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Stato")) = False Then
            Me.Stato = ds.Tables(tabella).Rows(0)("Stato").ToString
         Else
            Me.Stato = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cognome")) = False Then
            Me.Cognome = ds.Tables(tabella).Rows(0)("Cognome").ToString
         Else
            Me.Cognome = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Nome")) = False Then
            Me.Nome = ds.Tables(tabella).Rows(0)("Nome").ToString
         Else
            Me.Nome = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Nazionalità")) = False Then
            Me.Nazionalità = ds.Tables(tabella).Rows(0)("Nazionalità").ToString
         Else
            Me.Nazionalità = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Provincia")) = False Then
            Me.Provincia = ds.Tables(tabella).Rows(0)("Provincia").ToString
         Else
            Me.Provincia = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Adulti")) = False Then
            Me.Adulti = ds.Tables(tabella).Rows(0)("Adulti").ToString
         Else
            Me.Adulti = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Neonati")) = False Then
            Me.Neonati = ds.Tables(tabella).Rows(0)("Neonati").ToString
         Else
            Me.Neonati = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Bambini")) = False Then
            Me.Bambini = ds.Tables(tabella).Rows(0)("Bambini").ToString
         Else
            Me.Bambini = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Ragazzi")) = False Then
            Me.Ragazzi = ds.Tables(tabella).Rows(0)("Ragazzi").ToString
         Else
            Me.Ragazzi = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroCamera")) = False Then
            Me.NumeroCamera = ds.Tables(tabella).Rows(0)("NumeroCamera").ToString
         Else
            Me.NumeroCamera = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DescrizioneCamera")) = False Then
            Me.DescrizioneCamera = ds.Tables(tabella).Rows(0)("DescrizioneCamera").ToString
         Else
            Me.DescrizioneCamera = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Trattamento")) = False Then
            Me.Trattamento = ds.Tables(tabella).Rows(0)("Trattamento").ToString
         Else
            Me.Trattamento = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Gruppo")) = False Then
            Me.Gruppo = ds.Tables(tabella).Rows(0)("Gruppo").ToString
         Else
            Me.Gruppo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Agenzia")) = False Then
            Me.Agenzia = ds.Tables(tabella).Rows(0)("Agenzia").ToString
         Else
            Me.Agenzia = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CanaleVendita")) = False Then
            Me.CanaleVendita = ds.Tables(tabella).Rows(0)("CanaleVendita").ToString
         Else
            Me.CanaleVendita = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataArrivo")) = False Then
            Me.DataArrivo = ds.Tables(tabella).Rows(0)("DataArrivo").ToString
         Else
            Me.DataArrivo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataPartenza")) = False Then
            Me.DataPartenza = ds.Tables(tabella).Rows(0)("DataPartenza").ToString
         Else
            Me.DataPartenza = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OraArrivo")) = False Then
            Me.OraArrivo = ds.Tables(tabella).Rows(0)("OraArrivo").ToString
         Else
            Me.OraArrivo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroNotti")) = False Then
            Me.NumeroNotti = ds.Tables(tabella).Rows(0)("NumeroNotti").ToString
         Else
            Me.NumeroNotti = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Listino")) = False Then
            Me.Listino = ds.Tables(tabella).Rows(0)("Listino").ToString
         Else
            Me.Listino = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Pagamento")) = False Then
            Me.Pagamento = ds.Tables(tabella).Rows(0)("Pagamento").ToString
         Else
            Me.Pagamento = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoCamera")) = False Then
            Me.CostoCamera = ds.Tables(tabella).Rows(0)("CostoCamera").ToString
         Else
            Me.CostoCamera = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TassaSoggiorno")) = False Then
            Me.TassaSoggiorno = ds.Tables(tabella).Rows(0)("TassaSoggiorno").ToString
         Else
            Me.TassaSoggiorno = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AccontoCamera")) = False Then
            Me.AccontoCamera = ds.Tables(tabella).Rows(0)("AccontoCamera").ToString
         Else
            Me.AccontoCamera = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TotaleConto")) = False Then
            Me.TotaleConto = ds.Tables(tabella).Rows(0)("TotaleConto").ToString
         Else
            Me.TotaleConto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ApplicaSconto")) = False Then
            Me.ApplicaSconto = ds.Tables(tabella).Rows(0)("ApplicaSconto").ToString
         Else
            Me.ApplicaSconto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Sconto")) = False Then
            Me.Sconto = ds.Tables(tabella).Rows(0)("Sconto").ToString
         Else
            Me.Sconto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Servizio")) = False Then
            Me.Servizio = ds.Tables(tabella).Rows(0)("Servizio").ToString
         Else
            Me.Servizio = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Schedina")) = False Then
            Me.Schedina = ds.Tables(tabella).Rows(0)("Schedina").ToString
         Else
            Me.Schedina = VALORE_NESSUNA
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = ds.Tables(tabella).Rows(0)("Colore")
         Else
            Me.Colore = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note")
         Else
            Me.Note = ""
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
   End Sub

   Public Function InserisciDati(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (IdCliente, Numero, Data, Tipologia, Stato, Cognome, Nome, Nazionalità, Provincia, Adulti, Neonati, Bambini, Ragazzi, NumeroCamera, DescrizioneCamera, " &
                                              "Trattamento, Gruppo, Agenzia, CanaleVendita, DataArrivo, DataPartenza, OraArrivo, NumeroNotti, Listino, Pagamento, CostoCamera, TassaSoggiorno, AccontoCamera, " &
                                              "TotaleConto, ApplicaSconto, Sconto, Servizio, Schedina, Colore, [Note]) " &
                                       "VALUES(@IdCliente, @Numero, @Data, @Tipologia, @Stato, @Cognome, @Nome, @Nazionalità, @Provincia, @Adulti, @Neonati, @Bambini, @Ragazzi, @NumeroCamera, @DescrizioneCamera, " &
                                              "@Trattamento, @Gruppo, @Agenzia, @CanaleVendita, @DataArrivo, @DataPartenza, @OraArrivo, @NumeroNotti, @Listino, @Pagamento, @CostoCamera, @TassaSoggiorno, @AccontoCamera, " &
                                              "@TotaleConto, @ApplicaSconto, @Sconto, @Servizio, @Schedina, @Colore, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdInsert.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdInsert.Parameters.AddWithValue("@Data", Me.Data)
         cmdInsert.Parameters.AddWithValue("@Tipologia", Me.Tipologia)
         cmdInsert.Parameters.AddWithValue("@Stato", Me.Stato)
         cmdInsert.Parameters.AddWithValue("@Cognome", Me.Cognome)
         cmdInsert.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdInsert.Parameters.AddWithValue("@Nazionalità", Me.Nazionalità)
         cmdInsert.Parameters.AddWithValue("@Provincia", Me.Provincia)
         cmdInsert.Parameters.AddWithValue("@Adulti", Me.Adulti)
         cmdInsert.Parameters.AddWithValue("@Neonati", Me.Neonati)
         cmdInsert.Parameters.AddWithValue("@Bambini", Me.Bambini)
         cmdInsert.Parameters.AddWithValue("@Ragazzi", Me.Ragazzi)
         cmdInsert.Parameters.AddWithValue("@NumeroCamera", Me.NumeroCamera)
         cmdInsert.Parameters.AddWithValue("@DescrizioneCamera", Me.DescrizioneCamera)
         cmdInsert.Parameters.AddWithValue("@Trattamento", Me.Trattamento)
         cmdInsert.Parameters.AddWithValue("@Gruppo", Me.Gruppo)
         cmdInsert.Parameters.AddWithValue("@Agenzia", Me.Agenzia)
         cmdInsert.Parameters.AddWithValue("@CanaleVendita", Me.CanaleVendita)
         cmdInsert.Parameters.AddWithValue("@DataArrivo", Me.DataArrivo)
         cmdInsert.Parameters.AddWithValue("@DataPartenza", Me.DataPartenza)
         cmdInsert.Parameters.AddWithValue("@OraArrivo", Me.OraArrivo)
         cmdInsert.Parameters.AddWithValue("@NumeroNotti", Me.NumeroNotti)
         cmdInsert.Parameters.AddWithValue("@Listino", Me.Listino)
         cmdInsert.Parameters.AddWithValue("@Pagamento", Me.Pagamento)
         cmdInsert.Parameters.AddWithValue("@CostoCamera", Me.CostoCamera)
         cmdInsert.Parameters.AddWithValue("@TassaSoggiorno", Me.TassaSoggiorno)
         cmdInsert.Parameters.AddWithValue("@AccontoCamera", Me.AccontoCamera)
         cmdInsert.Parameters.AddWithValue("@TotaleConto", Me.TotaleConto)
         cmdInsert.Parameters.AddWithValue("@ApplicaSconto", Me.ApplicaSconto)
         cmdInsert.Parameters.AddWithValue("@Sconto", Me.Sconto)
         cmdInsert.Parameters.AddWithValue("@Servizio", Me.Servizio)
         cmdInsert.Parameters.AddWithValue("@Schedina", Me.Schedina)
         cmdInsert.Parameters.AddWithValue("@Colore", Me.Colore)
         cmdInsert.Parameters.AddWithValue("@Note", Me.Note)

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

   Public Function ModificaDati(ByVal tabella As String, ByVal codice As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET IdCliente = @IdCliente, " &
                             "Numero = @Numero, " &
                             "Data = @Data, " &
                             "Tipologia = @Tipologia, " &
                             "Stato = @Stato, " &
                             "Cognome = @Cognome, " &
                             "Nome = @Nome, " &
                             "Nazionalità = @Nazionalità, " &
                             "Provincia = @Provincia, " &
                             "Adulti = @Adulti, " &
                             "Neonati = @Neonati, " &
                             "Bambini = @Bambini, " &
                             "Ragazzi = @Ragazzi, " &
                             "NumeroCamera = @NumeroCamera, " &
                             "DescrizioneCamera = @DescrizioneCamera, " &
                             "Trattamento = @Trattamento, " &
                             "Gruppo = @Gruppo, " &
                             "Agenzia = @Agenzia, " &
                             "CanaleVendita = @CanaleVendita, " &
                             "DataArrivo = @DataArrivo, " &
                             "DataPartenza = @DataPartenza, " &
                             "OraArrivo = @OraArrivo, " &
                             "NumeroNotti = @NumeroNotti, " &
                             "Listino = @Listino, " &
                             "Pagamento = @Pagamento, " &
                             "CostoCamera = @CostoCamera, " &
                             "TassaSoggiorno = @TassaSoggiorno, " &
                             "AccontoCamera = @AccontoCamera, " &
                             "TotaleConto = @TotaleConto, " &
                             "ApplicaSconto = @ApplicaSconto, " &
                             "Sconto = @Sconto, " &
                             "Servizio = @Servizio, " &
                             "Schedina = @Schedina, " &
                             "Colore = @Colore, " &
                             "[Note] = @Note " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdUpdate.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdUpdate.Parameters.AddWithValue("@Data", Me.Data)
         cmdUpdate.Parameters.AddWithValue("@Tipologia", Me.Tipologia)
         cmdUpdate.Parameters.AddWithValue("@Stato", Me.Stato)
         cmdUpdate.Parameters.AddWithValue("@Cognome", Me.Cognome)
         cmdUpdate.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdUpdate.Parameters.AddWithValue("@Nazionalità", Me.Nazionalità)
         cmdUpdate.Parameters.AddWithValue("@Provincia", Me.Provincia)
         cmdUpdate.Parameters.AddWithValue("@Adulti", Me.Adulti)
         cmdUpdate.Parameters.AddWithValue("@Neonati", Me.Neonati)
         cmdUpdate.Parameters.AddWithValue("@Bambini", Me.Bambini)
         cmdUpdate.Parameters.AddWithValue("@Ragazzi", Me.Ragazzi)
         cmdUpdate.Parameters.AddWithValue("@NumeroCamera", Me.NumeroCamera)
         cmdUpdate.Parameters.AddWithValue("@DescrizioneCamera", Me.DescrizioneCamera)
         cmdUpdate.Parameters.AddWithValue("@Trattamento", Me.Trattamento)
         cmdUpdate.Parameters.AddWithValue("@Gruppo", Me.Gruppo)
         cmdUpdate.Parameters.AddWithValue("@Agenzia", Me.Agenzia)
         cmdUpdate.Parameters.AddWithValue("@CanaleVendita", Me.CanaleVendita)
         cmdUpdate.Parameters.AddWithValue("@DataArrivo", Me.DataArrivo)
         cmdUpdate.Parameters.AddWithValue("@DataPartenza", Me.DataPartenza)
         cmdUpdate.Parameters.AddWithValue("@OraArrivo", Me.OraArrivo)
         cmdUpdate.Parameters.AddWithValue("@NumeroNotti", Me.NumeroNotti)
         cmdUpdate.Parameters.AddWithValue("@Listino", Me.Listino)
         cmdUpdate.Parameters.AddWithValue("@Pagamento", Me.Pagamento)
         cmdUpdate.Parameters.AddWithValue("@CostoCamera", Me.CostoCamera)
         cmdUpdate.Parameters.AddWithValue("@TassaSoggiorno", Me.TassaSoggiorno)
         cmdUpdate.Parameters.AddWithValue("@AccontoCamera", Me.AccontoCamera)
         cmdUpdate.Parameters.AddWithValue("@TotaleConto", Me.TotaleConto)
         cmdUpdate.Parameters.AddWithValue("@ApplicaSconto", Me.ApplicaSconto)
         cmdUpdate.Parameters.AddWithValue("@Sconto", Me.Sconto)
         cmdUpdate.Parameters.AddWithValue("@Servizio", Me.Servizio)
         cmdUpdate.Parameters.AddWithValue("@Schedina", Me.Schedina)
         cmdUpdate.Parameters.AddWithValue("@Colore", Me.Colore)
         cmdUpdate.Parameters.AddWithValue("@Note", Me.Note)

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

   Public Function EliminaDati(ByVal tabella As String, ByVal codice As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, codice)

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

End Class
