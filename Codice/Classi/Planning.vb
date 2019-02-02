Imports System.Data.OleDb

Public Class Planning

   Public Codice As Integer
   Public Data As String
   Public Ora As String
   Public CordX As String
   Public CordY As String
   Public Note As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore

   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String, ByVal data As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE Data = " & data & " ORDER BY Id ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            lst.Items.Add(dr.Item("Documento"))
            lst.Items(i).SubItems.Add(dr.Item("Data"))
            lst.Items(i).SubItems.Add(dr.Item("Ora"))
            lst.Items(i).SubItems.Add(dr.Item("Note"))
            lst.Items(i).SubItems.Add(dr.Item("Percorso"))
            lst.Items(i).SubItems.Add(dr.Item("Id"))

            i = i + 1

            Caricati = True
         Loop

         Return Caricati

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

      Finally
         cn.Close()

      End Try
   End Function

   Public Function InserisciDati(ByVal tabella As String) As Boolean
      'Dim sql As String

      'Try
      '   ' Apre la connessione.
      '   cn.Open()

      '   ' Avvia una transazione.
      '   tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
      '   ' Crea la stringa di eliminazione.
      '   sql = String.Format("INSERT INTO {0} (Documento, Data, Ora, [Note], [Percorso], IdCliente, Estensione) " & _
      '                                        "VALUES('{1}', '{2}', '{3}', '{4}', '{5}', {6}, '{7}')", tabella, _
      '                                        Me.Documento, _
      '                                        Me.Data, _
      '                                        Me.Ora, _
      '                                        Me.Note, _
      '                                        Me.Percorso, _
      '                                        Me.IdCliente, _
      '                                        Me.Estensione)


      '   ' Crea il comando per la connessione corrente.
      '   Dim cmdInsert As New OleDbCommand(sql, cn, tr)
      '   ' Esegue il comando.
      '   Dim Record As Integer = cmdInsert.ExecuteNonQuery()

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

   Public Function ModificaDati(ByVal tabella As String, ByVal Id As Integer) As Boolean
      '   Dim sql As String

      '   Try
      '      ' Apre la connessione.
      '      cn.Open()

      '      ' Avvia una transazione.
      '      tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

      '      ' Crea la stringa di eliminazione.
      '      sql = String.Format("UPDATE {0} " & _
      '                          "SET Documento = '{1}', " & _
      '                          "Data = '{2}', " & _
      '                          "Ora = '{3}', " & _
      '                          "[Note] = '{4}', " & _
      '                          "[Percorso] = '{5}', " & _
      '                          "IdCliente = {6}, " & _
      '                          "Estensione = '{7}' " & _
      '                          "WHERE Id = {8}", _
      '                          tabella, _
      '                          Me.Documento, _
      '                          Me.Data, _
      '                          Me.Ora, _
      '                          Me.Note, _
      '                          Me.Percorso, _
      '                          Me.IdCliente, _
      '                          Me.Estensione, _
      '                          Id)

      '      ' Crea il comando per la connessione corrente.
      '      Dim cmdUpdate As New OleDbCommand(sql, cn, tr)
      '      ' Esegue il comando.
      '      Dim Record As Integer = cmdUpdate.ExecuteNonQuery()

      '      ' Conferma transazione.
      '      tr.Commit()

      '      Return True

      '   Catch ex As Exception
      '      ' Annulla transazione.
      '      tr.Rollback()

      '      ' Visualizza un messaggio di errore e lo registra nell'apposito file.
      '      err.GestisciErrore(ex.StackTrace, ex.Message)

      '      Return False

      '   Finally
      '      ' Chiude la connessione.
      '      cn.Close()
      '   End Try
   End Function
End Class
