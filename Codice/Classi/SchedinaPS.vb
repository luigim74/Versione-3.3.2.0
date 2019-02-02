#Region " DATI FILE.VB "

' ******************************************************************
' Nome Classe:            SchedinaPS
' Autore:               Luigi Montana, Montana Software
' Data creazione:       05/08/2018
' Data ultima modifica: 24/08/2018
' Descrizione:          Classe Schedina PS.
' Note:

' Elenco Attivita:

' ******************************************************************

#End Region

Public Class SchedinaPS

   Public Codice As Integer
   Public Numero As Integer
   Public IdCliente As Integer
   Public TipologiaCliente As String
   Public Cognome As String
   Public Nome As String
   Public Sesso As String
   Public DataNascita As String
   Public LuogoNascita As String
   Public ProvNascita As String
   Public NazioneNascita As String
   Public Cittadinanza As String
   Public TipoDoc As String
   Public NumeroDoc As String
   Public RilasciatoDoc As String
   Public ComuneRilascioDoc As String
   Public DataRilascioDoc As String
   Public DataScadenzaDoc As String
   Public NazioneRilascioDoc As String
   Public DataArrivo As String
   Public DataPartenza As String
   Public Permanenza As Integer
   Public NumCamera As String
   Public IdPren As Integer
   Public NumPren As String
   Public Stato As String
   Public DataStampa As String

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Numero")) = False Then
            Me.Numero = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Numero"))
         Else
            Me.Numero = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdCliente")) = False Then
            Me.IdCliente = Convert.ToInt32(ds.Tables(tabella).Rows(0)("IdCliente"))
         Else
            Me.IdCliente = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipologiaCliente")) = False Then
            Me.TipologiaCliente = ds.Tables(tabella).Rows(0)("TipologiaCliente").ToString
         Else
            Me.TipologiaCliente = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cognome")) = False Then
            Me.Cognome = ds.Tables(tabella).Rows(0)("Cognome").ToString
         Else
            Me.Cognome = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Nome")) = False Then
            Me.Nome = ds.Tables(tabella).Rows(0)("Nome").ToString
         Else
            Me.Nome = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Sesso")) = False Then
            Me.Sesso = ds.Tables(tabella).Rows(0)("Sesso").ToString
         Else
            Me.Sesso = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataNascita")) = False Then
            Me.DataNascita = ds.Tables(tabella).Rows(0)("DataNascita").ToString
         Else
            Me.DataNascita = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("LuogoNascita")) = False Then
            Me.LuogoNascita = ds.Tables(tabella).Rows(0)("LuogoNascita").ToString
         Else
            Me.LuogoNascita = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ProvNascita")) = False Then
            Me.ProvNascita = ds.Tables(tabella).Rows(0)("ProvNascita").ToString
         Else
            Me.ProvNascita = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NazioneNascita")) = False Then
            Me.NazioneNascita = ds.Tables(tabella).Rows(0)("NazioneNascita").ToString
         Else
            Me.NazioneNascita = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cittadinanza")) = False Then
            Me.Cittadinanza = ds.Tables(tabella).Rows(0)("Cittadinanza").ToString
         Else
            Me.Cittadinanza = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoDoc")) = False Then
            Me.TipoDoc = ds.Tables(tabella).Rows(0)("TipoDoc").ToString
         Else
            Me.TipoDoc = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroDoc")) = False Then
            Me.NumeroDoc = ds.Tables(tabella).Rows(0)("NumeroDoc").ToString
         Else
            Me.NumeroDoc = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("RilasciatoDoc")) = False Then
            Me.RilasciatoDoc = ds.Tables(tabella).Rows(0)("RilasciatoDoc").ToString
         Else
            Me.RilasciatoDoc = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ComuneRilascioDoc")) = False Then
            Me.ComuneRilascioDoc = ds.Tables(tabella).Rows(0)("ComuneRilascioDoc").ToString
         Else
            Me.ComuneRilascioDoc = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataRilascioDoc")) = False Then
            Me.DataRilascioDoc = ds.Tables(tabella).Rows(0)("DataRilascioDoc").ToString
         Else
            Me.DataRilascioDoc = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataScadenzaDoc")) = False Then
            Me.DataScadenzaDoc = ds.Tables(tabella).Rows(0)("DataScadenzaDoc").ToString
         Else
            Me.DataScadenzaDoc = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NazioneRilascioDoc")) = False Then
            Me.NazioneRilascioDoc = ds.Tables(tabella).Rows(0)("NazioneRilascioDoc").ToString
         Else
            Me.NazioneRilascioDoc = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataArrivo")) = False Then
            Me.DataArrivo = ds.Tables(tabella).Rows(0)("DataArrivo").ToString
         Else
            Me.DataArrivo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataPartenza")) = False Then
            Me.DataPartenza = ds.Tables(tabella).Rows(0)("DataPartenza").ToString
         Else
            Me.DataPartenza = String.Empty
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("Permanenza")) = False Then
            Me.Permanenza = ds.Tables(tabella).Rows(0)("Permanenza").ToString
         Else
            Me.Permanenza = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumCamera")) = False Then
            Me.NumCamera = ds.Tables(tabella).Rows(0)("NumCamera").ToString
         Else
            Me.NumCamera = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdPren")) = False Then
            Me.IdPren = Convert.ToInt32(ds.Tables(tabella).Rows(0)("IdPren"))
         Else
            Me.IdPren = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumPren")) = False Then
            Me.NumPren = ds.Tables(tabella).Rows(0)("NumPren").ToString
         Else
            Me.NumPren = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Stato")) = False Then
            Me.Stato = ds.Tables(tabella).Rows(0)("Stato").ToString
         Else
            Me.Stato = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataStampa")) = False Then
            Me.DataStampa = ds.Tables(tabella).Rows(0)("DataStampa")
         Else
            Me.DataStampa = String.Empty
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

   Public Sub LeggiDati(ByVal tabella As String, ByVal IdPren As Integer)
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         ' Apre la connessione.
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE IdPren = " & IdPren, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()

            ' Assegna i valori dei campi del DataSet ai campi della classe.
            If IsDBNull(dr.Item("Id")) = False Then
               Me.Codice = Convert.ToInt32(dr.Item("Id"))
            Else
               Me.Codice = 0
            End If

            If IsDBNull(dr.Item("Numero")) = False Then
               Me.Numero = dr.Item("Numero")
            Else
               Me.Numero = String.Empty
            End If

            If IsDBNull(dr.Item("Stato")) = False Then
               Me.Stato = dr.Item("Stato")
            Else
               Me.Stato = String.Empty
            End If

            If IsDBNull(dr.Item("DataStampa")) = False Then
               Me.DataStampa = dr.Item("DataStampa")
            Else
               Me.DataStampa = String.Empty
            End If

         Loop

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
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
         sql = String.Format("INSERT INTO {0} (Numero, IdCliente, TipologiaCliente, Cognome, Nome, Sesso, DataNascita, LuogoNascita, ProvNascita, NazioneNascita, Cittadinanza, " &
                                              "TipoDoc, NumeroDoc, RilasciatoDoc, ComuneRilascioDoc, DataRilascioDoc, DataScadenzaDoc, NazioneRilascioDoc, DataArrivo, DataPartenza, Permanenza, " &
                                              "NumCamera, IdPren, NumPren, Stato, DataStampa) " &
                                       "VALUES(@Numero, @IdCliente, @TipologiaCliente, @Cognome, @Nome, @Sesso, @DataNascita, @LuogoNascita, @ProvNascita, @NazioneNascita, @Cittadinanza, " &
                                              "@TipoDoc, @NumeroDoc, @RilasciatoDoc, @ComuneRilascioDoc, @DataRilascioDoc, @DataScadenzaDoc, @NazioneRilascioDoc, @DataArrivo, @DataPartenza, @Permanenza, " &
                                              "@NumCamera, @IdPren, @NumPren, @Stato, @DataStampa)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdInsert.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdInsert.Parameters.AddWithValue("@TipologiaCliente", Me.TipologiaCliente)
         cmdInsert.Parameters.AddWithValue("@Cognome", Me.Cognome)
         cmdInsert.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdInsert.Parameters.AddWithValue("@Sesso", Me.Sesso)
         cmdInsert.Parameters.AddWithValue("@DataNascita", Me.DataNascita)
         cmdInsert.Parameters.AddWithValue("@LuogoNascita", Me.LuogoNascita)
         cmdInsert.Parameters.AddWithValue("@ProvNascita", Me.ProvNascita)
         cmdInsert.Parameters.AddWithValue("@NazioneNascita", Me.NazioneNascita)
         cmdInsert.Parameters.AddWithValue("@Cittadinanza", Me.Cittadinanza)
         cmdInsert.Parameters.AddWithValue("@TipoDoc", Me.TipoDoc)
         cmdInsert.Parameters.AddWithValue("@NumeroDoc", Me.NumeroDoc)
         cmdInsert.Parameters.AddWithValue("@RilasciatoDoc", Me.RilasciatoDoc)
         cmdInsert.Parameters.AddWithValue("@ComuneRilascioDoc", Me.ComuneRilascioDoc)
         cmdInsert.Parameters.AddWithValue("@DataRilascioDoc", Me.DataRilascioDoc)
         cmdInsert.Parameters.AddWithValue("@DataScadenzaDoc", Me.DataScadenzaDoc)
         cmdInsert.Parameters.AddWithValue("@NazioneRilascioDoc", Me.NazioneRilascioDoc)
         cmdInsert.Parameters.AddWithValue("@DataArrivo", Me.DataArrivo)
         cmdInsert.Parameters.AddWithValue("@DataPartenza", Me.DataPartenza)
         cmdInsert.Parameters.AddWithValue("@Permanenza", Me.Permanenza)
         cmdInsert.Parameters.AddWithValue("@NumCamera", Me.NumCamera)
         cmdInsert.Parameters.AddWithValue("@IdPren", Me.IdPren)
         cmdInsert.Parameters.AddWithValue("@NumPren", Me.NumPren)
         cmdInsert.Parameters.AddWithValue("@Stato", Me.Stato)
         cmdInsert.Parameters.AddWithValue("@DataStampa", Me.DataStampa)

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
                             "SET Numero = @Numero, " &
                             "IdCliente = @IdCliente, " &
                             "TipologiaCliente = @TipologiaCliente, " &
                             "Cognome = @Cognome, " &
                             "Nome = @Nome, " &
                             "Sesso = @Sesso, " &
                             "DataNascita = @DataNascita, " &
                             "LuogoNascita = @LuogoNascita, " &
                             "ProvNascita = @ProvNascita, " &
                             "NazioneNascita = @NazioneNascita, " &
                             "Cittadinanza = @Cittadinanza, " &
                             "TipoDoc = @TipoDoc, " &
                             "NumeroDoc = @NumeroDoc, " &
                             "RilasciatoDoc = @RilasciatoDoc, " &
                             "ComuneRilascioDoc = @ComuneRilascioDoc, " &
                             "DataRilascioDoc = @DataRilascioDoc, " &
                             "DataScadenzaDoc = @DataScadenzaDoc, " &
                             "NazioneRilascioDoc = @NazioneRilascioDoc, " &
                             "DataArrivo = @DataArrivo, " &
                             "DataPartenza = @DataPartenza, " &
                             "Permanenza = @Permanenza, " &
                             "NumCamera = @NumCamera, " &
                             "IdPren = @IdPren, " &
                             "NumPren = @NumPren, " &
                             "Stato = @Stato, " &
                             "DataStampa = @DataStampa " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdUpdate.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdUpdate.Parameters.AddWithValue("@TipologiaCliente", Me.TipologiaCliente)
         cmdUpdate.Parameters.AddWithValue("@Cognome", Me.Cognome)
         cmdUpdate.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdUpdate.Parameters.AddWithValue("@Sesso", Me.Sesso)
         cmdUpdate.Parameters.AddWithValue("@DataNascita", Me.DataNascita)
         cmdUpdate.Parameters.AddWithValue("@LuogoNascita", Me.LuogoNascita)
         cmdUpdate.Parameters.AddWithValue("@ProvNascita", Me.ProvNascita)
         cmdUpdate.Parameters.AddWithValue("@NazioneNascita", Me.NazioneNascita)
         cmdUpdate.Parameters.AddWithValue("@Cittadinanza", Me.Cittadinanza)
         cmdUpdate.Parameters.AddWithValue("@TipoDoc", Me.TipoDoc)
         cmdUpdate.Parameters.AddWithValue("@NumeroDoc", Me.NumeroDoc)
         cmdUpdate.Parameters.AddWithValue("@RilasciatoDoc", Me.RilasciatoDoc)
         cmdUpdate.Parameters.AddWithValue("@ComuneRilascioDoc", Me.ComuneRilascioDoc)
         cmdUpdate.Parameters.AddWithValue("@DataRilascioDoc", Me.DataRilascioDoc)
         cmdUpdate.Parameters.AddWithValue("@DataScadenzaDoc", Me.DataScadenzaDoc)
         cmdUpdate.Parameters.AddWithValue("@NazioneRilascioDoc", Me.NazioneRilascioDoc)
         cmdUpdate.Parameters.AddWithValue("@DataArrivo", Me.DataArrivo)
         cmdUpdate.Parameters.AddWithValue("@DataPartenza", Me.DataPartenza)
         cmdUpdate.Parameters.AddWithValue("@Permanenza", Me.Permanenza)
         cmdUpdate.Parameters.AddWithValue("@NumCamera", Me.NumCamera)
         cmdUpdate.Parameters.AddWithValue("@IdPren", Me.IdPren)
         cmdUpdate.Parameters.AddWithValue("@NumPren", Me.NumPren)
         cmdUpdate.Parameters.AddWithValue("@Stato", Me.Stato)
         cmdUpdate.Parameters.AddWithValue("@DataStampa", Me.DataStampa)

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

End Class
