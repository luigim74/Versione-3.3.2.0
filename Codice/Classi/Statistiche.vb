Imports System.Data.OleDb

Public Class Statistiche

   Public Codice As String
   Public Data As String
   Public IdCategoria As String
   Public DesCategoria As String
   Public IdPiatto As String
   Public DesPiatto As String
   Public IdTavolo As String
   Public DesTavolo As String
   Public IdCameriere As String
   Public DesCameriere As String
   Public Quantità As Double
   Public Prezzo As String
   Public Importo As String

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Data")) = False Then
            Me.Data = ds.Tables(tabella).Rows(0)("Data")
         Else
            Me.Data = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdCategoria")) = False Then
            Me.IdCategoria = ds.Tables(tabella).Rows(0)("IdCategoria")
         Else
            Me.IdCategoria = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DesCategoria")) = False Then
            Me.DesCategoria = ds.Tables(tabella).Rows(0)("DesCategoria")
         Else
            Me.DesCategoria = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdPiatto")) = False Then
            Me.IdPiatto = ds.Tables(tabella).Rows(0)("IdPiatto")
         Else
            Me.IdPiatto = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DesPiatto")) = False Then
            Me.DesPiatto = ds.Tables(tabella).Rows(0)("DesPiatto")
         Else
            Me.DesPiatto = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdTavolo")) = False Then
            Me.IdTavolo = ds.Tables(tabella).Rows(0)("IdTavolo")
         Else
            Me.IdTavolo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DesTavolo")) = False Then
            Me.DesTavolo = ds.Tables(tabella).Rows(0)("DesTavolo")
         Else
            Me.DesTavolo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdCameriere")) = False Then
            Me.IdCameriere = ds.Tables(tabella).Rows(0)("IdCameriere")
         Else
            Me.IdCameriere = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DesCameriere")) = False Then
            Me.DesCameriere = ds.Tables(tabella).Rows(0)("DesCameriere")
         Else
            Me.DesCameriere = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Quantità")) = False Then
            Me.Quantità = ds.Tables(tabella).Rows(0)("Quantità")
         Else
            Me.Quantità = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Prezzo")) = False Then
            Me.Prezzo = ds.Tables(tabella).Rows(0)("Prezzo")
         Else
            Me.Prezzo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Importo")) = False Then
            Me.Importo = ds.Tables(tabella).Rows(0)("Importo")
         Else
            Me.Importo = ""
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
         sql = String.Format("INSERT INTO {0} (Data, IdCategoria, DesCategoria, IdPiatto, DesPiatto, " & _
                                              "IdTavolo, DesTavolo, IdCameriere, DesCameriere, Quantità, Prezzo, Importo) " & _
                                       "VALUES('{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}', {10}, '{11}', '{12}')", _
                                                tabella, _
                                                Me.Data, _
                                                Me.IdCategoria, _
                                                Me.DesCategoria, _
                                                Me.IdPiatto, _
                                                Me.DesPiatto, _
                                                Me.IdTavolo, _
                                                Me.DesTavolo, _
                                                Me.IdCameriere, _
                                                Me.DesCameriere, _
                                                Me.Quantità, _
                                                Me.Prezzo, _
                                                Me.Importo)

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

   Public Function EliminaDati(ByVal tabella As String, ByVal codice As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.

         sql = String.Format("DELETE FROM Statistiche WHERE Codice = '{0}'", codice)

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

   Public Function ModificaDati(ByVal tabella As String, ByVal codice As String) As Boolean
      'Dim sql As String

      'Try
      '   ' Apre la connessione.
      '   cn.Open()

      '   ' Avvia una transazione.
      '   tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

      '   ' Crea la stringa di eliminazione.
      '   sql = String.Format("UPDATE {0} " & _
      '                       "SET Data = '{1}' " & _
      '                       "WHERE Codice = '{3}'", _
      '                        tabella, _
      '                        Me.Data, _
      '                        codice)

      '   ' Crea il comando per la connessione corrente.
      '   Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
      '   ' Esegue il comando.
      '   Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

      '   ' Conferma transazione.
      '   tr.Commit()

      '   Return True

      'Catch ex As Exception
      '   ' Annulla transazione.
      '   tr.Rollback()

      '   ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '   err.GestisciErrore(ex.StackTrace, ex.Message)

      '   Return False

      'Finally
      '   ' Chiude la connessione.
      '   cn.Close()
      'End Try

   End Function

End Class
