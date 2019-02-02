Imports System.Data.OleDb

Public Class IngredientiPiatti
   Public Id As Integer
   Public Id_Piatto As Integer
   Public Id_Articolo As Integer
   Public Descrizione As String
   Public Unit‡Misura As String
   Public Costo As Double
   Public Quantit‡ As Double

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction

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
            Me.Id = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Id = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Id_Piatto")) = False Then
            Me.Id_Piatto = ds.Tables(tabella).Rows(0)("Id_Piatto")
         Else
            Me.Id_Piatto = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Id_Articolo")) = False Then
            Me.Id_Articolo = ds.Tables(tabella).Rows(0)("Id_Articolo")
         Else
            Me.Id_Articolo = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione")
         Else
            Me.Descrizione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Unit‡Misura")) = False Then
            Me.Unit‡Misura = ds.Tables(tabella).Rows(0)("Unit‡Misura")
         Else
            Me.Unit‡Misura = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Costo")) = False Then
            Me.Costo = ds.Tables(tabella).Rows(0)("Costo")
         Else
            Me.Costo = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Quantit‡")) = False Then
            Me.Quantit‡ = ds.Tables(tabella).Rows(0)("Quantit‡")
         Else
            Me.Quantit‡ = 0
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
         sql = String.Format("INSERT INTO {0} (Id_Piatto, Id_Articolo, Descrizione, Unit‡Misura, Costo, Quantit‡) " & _
                                       "VALUES(@Id_Piatto, @Id_Articolo, @Descrizione, @Unit‡Misura, @Costo, @Quantit‡)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Id_Piatto", Me.Id_Piatto)
         cmdInsert.Parameters.Add("@Id_Articolo", Me.Id_Articolo)
         cmdInsert.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.Add("@Unit‡Misura", Me.Unit‡Misura)
         cmdInsert.Parameters.Add("@Costo", Me.Costo)
         cmdInsert.Parameters.Add("@Quantit‡", Me.Quantit‡)

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
         sql = String.Format("UPDATE {0} " & _
                             "SET Id_Piatto = @Id_Piatto, " & _
                             "Id_Articolo = @Id_Articolo, " & _
                             "Descrizione = @Descrizione, " & _
                             "Unit‡Misura = @Unit‡Misura, " & _
                             "Costo = @Costo, " & _
                             "Quantit‡ = @Quantit‡ " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Id_Piatto", Me.Id_Piatto)
         cmdUpdate.Parameters.Add("@Id_Articolo", Me.Id_Articolo)
         cmdUpdate.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.Add("@Unit‡Misura", Me.Unit‡Misura)
         cmdUpdate.Parameters.Add("@PrezzoAcquisto", Me.Costo)
         cmdUpdate.Parameters.Add("@Giacenza", Me.Quantit‡)

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
