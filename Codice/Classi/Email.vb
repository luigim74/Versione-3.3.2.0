Imports System.Data.OleDb

Public Class Email

   Public Codice As Integer
   Public Mittente As String
   Public Destinatario As String
   Public Oggetto As String
   Public DataInvio As String
   Public OraInvio As String
   Public IdCliente As String
   Public Cognome As String
   Public Nome As String
   Public Stato As String
   Public Categoria As String
   Public Colore As Integer
   Public Messaggio As String
   Public Allegati As String

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

         If IsDBNull(ds.Tables(tabella).Rows(0)("Mittente")) = False Then
            Me.Mittente = ds.Tables(tabella).Rows(0)("Mittente")
         Else
            Me.Mittente = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Destinatario")) = False Then
            Me.Destinatario = ds.Tables(tabella).Rows(0)("Destinatario")
         Else
            Me.Destinatario = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Oggetto")) = False Then
            Me.Oggetto = ds.Tables(tabella).Rows(0)("Oggetto")
         Else
            Me.Oggetto = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataInvio")) = False Then
            Me.DataInvio = ds.Tables(tabella).Rows(0)("DataInvio").ToString
         Else
            Me.DataInvio = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OraInvio")) = False Then
            Me.OraInvio = ds.Tables(tabella).Rows(0)("OraInvio").ToString
         Else
            Me.OraInvio = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdCliente")) = False Then
            Me.IdCliente = ds.Tables(tabella).Rows(0)("IdCliente")
         Else
            Me.IdCliente = String.Empty
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Stato")) = False Then
            Me.Stato = ds.Tables(tabella).Rows(0)("Stato").ToString
         Else
            Me.Stato = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Categoria")) = False Then
            Me.Categoria = ds.Tables(tabella).Rows(0)("Categoria").ToString
         Else
            Me.Categoria = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = ds.Tables(tabella).Rows(0)("Colore")
         Else
            Me.Colore = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Messaggio")) = False Then
            Me.Messaggio = ds.Tables(tabella).Rows(0)("Messaggio")
         Else
            Me.Messaggio = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Allegati")) = False Then
            Me.Allegati = ds.Tables(tabella).Rows(0)("Allegati")
         Else
            Me.Allegati = String.Empty
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
         sql = String.Format("INSERT INTO {0} (Mittente, Destinatario, Oggetto, DataInvio, OraInvio, IdCliente, Cognome, Nome, Stato, Categoria, Colore, [Messaggio], [Allegati]) " &
                                       "VALUES(@Mittente, @Destinatario, @Oggetto, @DataInvio, @OraInvio, @IdCliente, @Cognome, @Nome, @Stato, @Categoria, @Colore, @Messaggio, @Allegati)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Mittente", Me.Mittente)
         cmdInsert.Parameters.AddWithValue("@Destinatario", Me.Destinatario)
         cmdInsert.Parameters.AddWithValue("@Oggetto", Me.Oggetto)
         cmdInsert.Parameters.AddWithValue("@DataInvio", Me.DataInvio)
         cmdInsert.Parameters.AddWithValue("@OraInvio", Me.OraInvio)
         cmdInsert.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdInsert.Parameters.AddWithValue("@Cognome", Me.Cognome)
         cmdInsert.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdInsert.Parameters.AddWithValue("@Stato", Me.Stato)
         cmdInsert.Parameters.AddWithValue("@Categoria", Me.Categoria)
         cmdInsert.Parameters.AddWithValue("@Colore", Me.Colore)
         cmdInsert.Parameters.AddWithValue("@Messaggio", Me.Messaggio)
         cmdInsert.Parameters.AddWithValue("@Allegati", Me.Allegati)

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
                             "SET Mittente = @Mittente, " &
                             "Destinatario = @Destinatario, " &
                             "Oggetto = @Oggetto, " &
                             "DataInvio = @DataInvio, " &
                             "OraInvio = @OraInvio, " &
                             "IdCliente = @IdCliente, " &
                             "Cognome = @Cognome, " &
                             "Nome = @Nome, " &
                             "Stato = @Stato, " &
                             "Categoria = @Categoria, " &
                             "Colore = @Colore, " &
                             "[Messaggio] = @Messaggio, " &
                             "[Allegati] = @Allegati " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Mittente", Me.Mittente)
         cmdUpdate.Parameters.AddWithValue("@Destinatario", Me.Destinatario)
         cmdUpdate.Parameters.AddWithValue("@Oggetto", Me.Oggetto)
         cmdUpdate.Parameters.AddWithValue("@DataInvio", Me.DataInvio)
         cmdUpdate.Parameters.AddWithValue("@OraInvio", Me.OraInvio)
         cmdUpdate.Parameters.AddWithValue("@IdCliente", Me.IdCliente)
         cmdUpdate.Parameters.AddWithValue("@Cognome", Me.Cognome)
         cmdUpdate.Parameters.AddWithValue("@Nome", Me.Nome)
         cmdUpdate.Parameters.AddWithValue("@Stato", Me.Stato)
         cmdUpdate.Parameters.AddWithValue("@Categoria", Me.Categoria)
         cmdUpdate.Parameters.AddWithValue("@Colore", Me.Colore)
         cmdUpdate.Parameters.AddWithValue("@Messaggio", Me.Messaggio)
         cmdUpdate.Parameters.AddWithValue("@Allegati", Me.Allegati)

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
