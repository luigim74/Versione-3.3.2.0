Imports System.Data.OleDb

Public Class AccessoriServizi

   Public Codice As String
   Public Descrizione As String
   Public Tipologia As String
   Public Costo As String
   Public Disponibile As String
   Public Escludi As String
   Public Note As String
   Public Colore As Integer
   Public Immagine As String
   Public AliquotaIva As String

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
            Me.Codice = ds.Tables(tabella).Rows(0)("Id").ToString
         Else
            Me.Codice = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione").ToString
         Else
            Me.Descrizione = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Tipologia")) = False Then
            Me.Tipologia = ds.Tables(tabella).Rows(0)("Tipologia").ToString
         Else
            Me.Tipologia = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Costo")) = False Then
            Me.Costo = ds.Tables(tabella).Rows(0)("Costo").ToString
         Else
            Me.Costo = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Disponibile")) = False Then
            Me.Disponibile = ds.Tables(tabella).Rows(0)("Disponibile").ToString
         Else
            Me.Disponibile = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Escludi")) = False Then
            Me.Escludi = ds.Tables(tabella).Rows(0)("Escludi").ToString
         Else
            Me.Escludi = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note").ToString
         Else
            Me.Note = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Colore"))
         Else
            Me.Colore = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Immagine")) = False Then
            Me.Immagine = ds.Tables(tabella).Rows(0)("Immagine").ToString
         Else
            Me.Immagine = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AliquotaIva")) = False Then
            Me.AliquotaIva = ds.Tables(tabella).Rows(0)("AliquotaIva").ToString
         Else
            Me.AliquotaIva = String.Empty
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
         sql = String.Format("INSERT INTO {0} (Descrizione, Tipologia, Costo, Disponibile, Escludi, Immagine, Colore, AliquotaIva, [Note]) " &
                                       "VALUES(@Descrizione, @Tipologia, @Costo, @Disponibile, @Escludi, @Immagine, @Colore, @AliquotaIva, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.AddWithValue("@Tipologia", Me.Tipologia)
         cmdInsert.Parameters.AddWithValue("@Costo", Me.Costo)
         cmdInsert.Parameters.AddWithValue("@Disponibile", Me.Disponibile)
         cmdInsert.Parameters.AddWithValue("@Escludi", Me.Escludi)
         cmdInsert.Parameters.AddWithValue("@Immagine", Me.Immagine)
         cmdInsert.Parameters.AddWithValue("@Colore", Me.Colore)
         cmdInsert.Parameters.AddWithValue("@AliquotaIva", Me.AliquotaIva)
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
                             "SET Descrizione = @Descrizione, " &
                             "Tipologia = @Tipologia, " &
                             "Costo = @Costo, " &
                             "Disponibile = @Disponibile, " &
                             "Escludi = @Escludi, " &
                             "Immagine = @Immagine, " &
                             "Colore = @Colore, " &
                             "AliquotaIva = @AliquotaIva, " &
                             "[Note] = @Note " &
                             "WHERE Id = {1}",
                             tabella,
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.AddWithValue("@Tipologia", Me.Tipologia)
         cmdUpdate.Parameters.AddWithValue("@Costo", Me.Costo)
         cmdUpdate.Parameters.AddWithValue("@Disponibile", Me.Disponibile)
         cmdUpdate.Parameters.AddWithValue("@Escludi", Me.Escludi)
         cmdUpdate.Parameters.AddWithValue("@Immagine", Me.Immagine)
         cmdUpdate.Parameters.AddWithValue("@Colore", Me.Colore)
         cmdUpdate.Parameters.AddWithValue("@AliquotaIva", Me.AliquotaIva)
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
End Class
