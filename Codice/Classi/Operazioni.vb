Imports System.Data.OleDb

Public Class Operazioni

   Public Codice As String
   Public Data As String
   Public Operatore As String
   Public Modulo As String
   Public Descrizione As String

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
            Me.Codice = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Codice = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Data")) = False Then
            Me.Data = ds.Tables(tabella).Rows(0)("Data")
         Else
            Me.Data = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Operatore")) = False Then
            Me.Operatore = ds.Tables(tabella).Rows(0)("Operatore")
         Else
            Me.Operatore = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Modulo")) = False Then
            Me.Modulo = ds.Tables(tabella).Rows(0)("Modulo")
         Else
            Me.Modulo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione")
         Else
            Me.Descrizione = String.Empty
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
         sql = String.Format("INSERT INTO {0} (Data, Operatore, Modulo, [Descrizione]) VALUES(@Data, @Operatore, @Modulo, @Descrizione)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Data", Me.Data)
         cmdInsert.Parameters.Add("@Operatore", Me.Operatore)
         cmdInsert.Parameters.Add("@Modulo", Me.Modulo)
         cmdInsert.Parameters.Add("@Descrizione", Me.Descrizione)

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
                             "SET Data = @Data, " & _
                             "Operatore = @Operatore, " & _
                             "Modulo = @Modulo, " & _
                             "[Descrizione] = @Descrizione " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Data", Me.Data)
         cmdUpdate.Parameters.Add("@Operatore", Me.Operatore)
         cmdUpdate.Parameters.Add("@Modulo", Me.Modulo)
         cmdUpdate.Parameters.Add("@Descrizione", Me.Descrizione)

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
