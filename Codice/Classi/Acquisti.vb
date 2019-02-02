Imports System.Data.OleDb

Public Class Acquisti

   Public Codice As String
   Public Fornitore As String
   Public DataDoc As String
   Public TipoDoc As String
   Public NumDoc As Integer
   Public TotDoc As String
   Public Pagamento As String
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
            Me.Codice = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Codice = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Destinatario")) = False Then
            Me.Fornitore = ds.Tables(tabella).Rows(0)("Destinatario")
         Else
            Me.Fornitore = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataDoc")) = False Then
            Me.DataDoc = ds.Tables(tabella).Rows(0)("DataDoc")
         Else
            Me.DataDoc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoDoc")) = False Then
            Me.TipoDoc = ds.Tables(tabella).Rows(0)("TipoDoc")
         Else
            Me.TipoDoc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumDoc")) = False Then
            Me.NumDoc = ds.Tables(tabella).Rows(0)("NumDoc")
         Else
            Me.NumDoc = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TotDoc")) = False Then
            Me.TotDoc = ds.Tables(tabella).Rows(0)("TotDoc")
         Else
            Me.TotDoc = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ModPagamento")) = False Then
            Me.Pagamento = ds.Tables(tabella).Rows(0)("ModPagamento")
         Else
            Me.Pagamento = ""
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
         sql = String.Format("INSERT INTO {0} (Destinatario, DataDoc, TipoDoc, " & _
                                              "NumDoc, TotDoc, ModPagamento, [Note]) " & _
                                       "VALUES('{1}', '{2}', '{3}', " & _
                                              "{4}, '{5}', '{6}', '{7}')", tabella, _
                                              Me.Fornitore, _
                                              Me.DataDoc, _
                                              Me.TipoDoc, _
                                              Me.NumDoc, _
                                              Me.TotDoc, _
                                              Me.Pagamento, _
                                              Me.Note)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)
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
                             "SET Destinatario = '{1}', " & _
                             "DataDoc = '{2}', " & _
                             "TipoDoc = '{3}', " & _
                             "NumDoc = {4}, " & _
                             "TotDoc = '{5}', " & _
                             "ModPagamento = '{6}', " & _
                             "[Note] = '{7}' " & _
                             "WHERE Id = {8}", _
                             tabella, _
                             Me.Fornitore, _
                             Me.DataDoc, _
                             Me.TipoDoc, _
                             Me.NumDoc, _
                             Me.TotDoc, _
                             Me.Pagamento, _
                             Me.Note, _
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
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
