Imports System.Data.OleDb

Public Class Operatori

   Public Id As Integer
   Public NomeUtente As String
   Public Password As String
   Public Gruppo As String
   Public Note As String

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("NomeUtente")) = False Then
            Me.NomeUtente = ds.Tables(tabella).Rows(0)("NomeUtente")
         Else
            Me.NomeUtente = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Password")) = False Then
            Me.Password = ds.Tables(tabella).Rows(0)("Password")
         Else
            Me.Password = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Gruppo")) = False Then
            Me.Gruppo = ds.Tables(tabella).Rows(0)("Gruppo")
         Else
            Me.Gruppo = ""
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
         sql = String.Format("INSERT INTO {0} (NomeUtente, [Password], Gruppo, [Note]) VALUES(@NomeUtente, @Password, @Gruppo, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@NomeUtente", Me.NomeUtente)
         cmdInsert.Parameters.Add("@Password", Me.Password)
         cmdInsert.Parameters.Add("@Gruppo", Me.Gruppo)
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
         sql = String.Format("UPDATE {0} " & _
                             "SET NomeUtente = @NomeUtente, " & _
                             "[Password] = @Password, " & _
                             "Gruppo = @Gruppo, " & _
                             "[Note] = @Note " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@NomeUtente", Me.NomeUtente)
         cmdUpdate.Parameters.Add("@Password", Me.Password)
         cmdUpdate.Parameters.Add("@Gruppo", Me.Gruppo)
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
