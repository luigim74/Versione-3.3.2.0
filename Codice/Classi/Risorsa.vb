Imports System.Data.OleDb

Public Class Risorsa

   Public Codice As String
   Public Descrizione As String
   Public Tipologia As String
   Public Costo As String
   Public Disponibile As String
   Public Escludi As String
   Public Note As String
   Public Colore As Integer
   Public Immagine As String
   Public TipoPlanning As String

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
            Me.Codice = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione").ToString
         Else
            Me.Descrizione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Tipologia")) = False Then
            Me.Tipologia = ds.Tables(tabella).Rows(0)("Tipologia").ToString
         Else
            Me.Tipologia = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Costo")) = False Then
            Me.Costo = ds.Tables(tabella).Rows(0)("Costo").ToString
         Else
            Me.Costo = "0,00"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Disponibile")) = False Then
            Me.Disponibile = ds.Tables(tabella).Rows(0)("Disponibile").ToString
         Else
            Me.Disponibile = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Escludi")) = False Then
            Me.Escludi = ds.Tables(tabella).Rows(0)("Escludi").ToString
         Else
            Me.Escludi = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note").ToString
         Else
            Me.Note = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Colore"))
         Else
            Me.Colore = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Immagine")) = False Then
            Me.Immagine = ds.Tables(tabella).Rows(0)("Immagine").ToString
         Else
            Me.Immagine = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipoPlanning")) = False Then
            Me.TipoPlanning = ds.Tables(tabella).Rows(0)("TipoPlanning").ToString
         Else
            Me.TipoPlanning = "Planning 1 - (Inizio ore: 6:00 - Prenotazione minima mezz'ora)"
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
         sql = String.Format("INSERT INTO {0} (Descrizione, Tipologia, Costo," & _
                                              "Disponibile, Escludi, " & _
                                              "Immagine, Colore, TipoPlanning, [Note]) " & _
                                       "VALUES('{1}', '{2}', '{3}', " & _
                                              "'{4}', '{5}', '{6}', " & _
                                              "{7}, '{8}', '{9}')", tabella, _
                                              Me.Descrizione, _
                                              Me.Tipologia, _
                                              Me.Costo, _
                                              Me.Disponibile, _
                                              Me.Escludi, _
                                              Me.Immagine, _
                                              Me.Colore, _
                                              Me.TipoPlanning, _
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
                             "SET Descrizione = '{1}', " & _
                             "Tipologia = '{2}', " & _
                             "Costo = '{3}', " & _
                             "Disponibile = '{4}', " & _
                             "Escludi = '{5}', " & _
                             "Immagine = '{6}', " & _
                             "Colore = {7}, " & _
                             "TipoPlanning = '{8}', " & _
                             "[Note] = '{9}' " & _
                             "WHERE Id = {10}", _
                             tabella, _
                              Me.Descrizione, _
                              Me.Tipologia, _
                              Me.Costo, _
                              Me.Disponibile, _
                              Me.Escludi, _
                              Me.Immagine, _
                              Me.Colore, _
                              Me.TipoPlanning, _
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
