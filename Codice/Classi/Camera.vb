Imports System.Data.OleDb

Public Class Camera

   Public Codice As String
   Public Numero As String
   Public Descrizione As String
   Public Tipologia As String
   Public Posizione As String
   Public Ubicazione As String
   Public PostiLetto As String
   Public Disponibile As String
   Public Escludi As String
   Public Evidenzia As String
   Public Listino As String
   Public Note As String
   Public Colore As Integer
   Public Immagine As String

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
            Me.Codice = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Codice = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Numero")) = False Then
            Me.Numero = ds.Tables(tabella).Rows(0)("Numero")
         Else
            Me.Numero = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione")
         Else
            Me.Descrizione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Tipologia")) = False Then
            Me.Tipologia = ds.Tables(tabella).Rows(0)("Tipologia")
         Else
            Me.Tipologia = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Posizione")) = False Then
            Me.Posizione = ds.Tables(tabella).Rows(0)("Posizione")
         Else
            Me.Posizione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Ubicazione")) = False Then
            Me.Ubicazione = ds.Tables(tabella).Rows(0)("Ubicazione")
         Else
            Me.Ubicazione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PostiLetto")) = False Then
            Me.PostiLetto = ds.Tables(tabella).Rows(0)("PostiLetto")
         Else
            Me.PostiLetto = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Disponibile")) = False Then
            Me.Disponibile = ds.Tables(tabella).Rows(0)("Disponibile")
         Else
            Me.Disponibile = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Escludi")) = False Then
            Me.Escludi = ds.Tables(tabella).Rows(0)("Escludi")
         Else
            Me.Escludi = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Evidenzia")) = False Then
            Me.Evidenzia = ds.Tables(tabella).Rows(0)("Evidenzia")
         Else
            Me.Evidenzia = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Listino")) = False Then
            Me.Listino = ds.Tables(tabella).Rows(0)("Listino")
         Else
            Me.Listino = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note")
         Else
            Me.Note = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = ds.Tables(tabella).Rows(0)("Colore")
         Else
            Me.Colore = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Immagine")) = False Then
            Me.Immagine = ds.Tables(tabella).Rows(0)("Immagine")
         Else
            Me.Immagine = ""
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
         sql = String.Format("INSERT INTO {0} (Numero, Descrizione, Tipologia, Posizione, Ubicazione, " &
                                              "PostiLetto, Disponibile, Escludi, Evidenzia, Listino, Immagine, Colore, [Note]) " &
                                       "VALUES(@Numero, @Descrizione, @Tipologia, @Posizione, @Ubicazione, " &
                                              "@PostiLetto, @Disponibile, @Escludi, @Evidenzia, @Listino, @Immagine, @Colore, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Numero", Me.Numero)
         cmdInsert.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.Add("@Tipologia", Me.Tipologia)
         cmdInsert.Parameters.Add("@Posizione", Me.Posizione)
         cmdInsert.Parameters.Add("@Ubicazione", Me.Ubicazione)
         cmdInsert.Parameters.Add("@PostiLetto", Me.PostiLetto)
         cmdInsert.Parameters.Add("@Disponibile", Me.Disponibile)
         cmdInsert.Parameters.Add("@Escludi", Me.Escludi)
         cmdInsert.Parameters.Add("@Evidenzia", Me.Evidenzia)
         cmdInsert.Parameters.Add("@Listino", Me.Listino)
         cmdInsert.Parameters.Add("@Immagine", Me.Immagine)
         cmdInsert.Parameters.Add("@Colore", Me.Colore)
         cmdInsert.Parameters.Add("@Note", Me.Note)

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
                             "Descrizione = @Descrizione, " &
                             "Tipologia = @Tipologia, " &
                             "Posizione = @Posizione, " &
                             "Ubicazione = @Ubicazione, " &
                             "PostiLetto = @PostiLetto, " &
                             "Disponibile = @Disponibile, " &
                             "Escludi = @Escludi, " &
                             "Evidenzia = @Evidenzia, " &
                             "Listino = @Listino, " &
                             "Immagine = @Immagine, " &
                             "Colore = @Colore, " &
                             "[Note] = @Note " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Numero", Me.Numero)
         cmdUpdate.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.Add("@Tipologia", Me.Tipologia)
         cmdUpdate.Parameters.Add("@Posizione", Me.Posizione)
         cmdUpdate.Parameters.Add("@Ubicazione", Me.Ubicazione)
         cmdUpdate.Parameters.Add("@PostiLetto", Me.PostiLetto)
         cmdUpdate.Parameters.Add("@Disponibile", Me.Disponibile)
         cmdUpdate.Parameters.Add("@Escludi", Me.Escludi)
         cmdUpdate.Parameters.Add("@Evidenzia", Me.Evidenzia)
         cmdUpdate.Parameters.Add("@Listino", Me.Listino)
         cmdUpdate.Parameters.Add("@Immagine", Me.Immagine)
         cmdUpdate.Parameters.Add("@Colore", Me.Colore)
         cmdUpdate.Parameters.Add("@Note", Me.Note)

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
