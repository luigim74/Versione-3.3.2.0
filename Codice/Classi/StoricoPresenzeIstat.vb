#Region " DATI FILE.VB "
' ******************************************************************
' Autore:               Luigi Montana, Montana Software
' Data creazione:       15/09/2018
' Data ultima modifica: 15/09/2018
' Descrizione:          Classe Storico delle presenze per la creazione del Modello Istat C/59.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

Imports System.Data.OleDb

Public Class StoricoPresenzeIstat
   Public Codice As Integer
   Public Numero As Integer
   Public Nazionalità As String
   Public ArrivatiNaz As Integer
   Public PartitiNaz As Integer
   Public Provincia As String
   Public ArrivatiProv As Integer
   Public PartitiProv As Integer

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Numero")) = False Then
            Me.Numero = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Numero"))
         Else
            Me.Numero = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Nazionalità")) = False Then
            Me.Nazionalità = ds.Tables(tabella).Rows(0)("Nazionalità").ToString
         Else
            Me.Nazionalità = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ArrivatiNaz")) = False Then
            Me.ArrivatiNaz = Convert.ToInt32(ds.Tables(tabella).Rows(0)("ArrivatiNaz"))
         Else
            Me.ArrivatiNaz = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PartitiNaz")) = False Then
            Me.PartitiNaz = Convert.ToInt32(ds.Tables(tabella).Rows(0)("PartitiNaz"))
         Else
            Me.PartitiNaz = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Provincia")) = False Then
            Me.Provincia = ds.Tables(tabella).Rows(0)("Provincia").ToString
         Else
            Me.Provincia = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ArrivatiProv")) = False Then
            Me.ArrivatiProv = Convert.ToInt32(ds.Tables(tabella).Rows(0)("ArrivatiProv"))
         Else
            Me.ArrivatiProv = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PartitiProv")) = False Then
            Me.PartitiProv = Convert.ToInt32(ds.Tables(tabella).Rows(0)("PartitiProv"))
         Else
            Me.PartitiProv = 0
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
         sql = String.Format("INSERT INTO {0} (Numero, Nazionalità, ArrivatiNaz, PartitiNaz, Provincia, ArrivatiProv, PartitiProv) " &
                                       "VALUES(@Numero, @Nazionalità, @ArrivatiNaz, @PartitiNaz, @Provincia, @ArrivatiProv, @PartitiProv)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdInsert.Parameters.AddWithValue("@Nazionalità", Me.Nazionalità)
         cmdInsert.Parameters.AddWithValue("@ArrivatiNaz", Me.ArrivatiNaz)
         cmdInsert.Parameters.AddWithValue("@PartitiNaz", Me.PartitiNaz)
         cmdInsert.Parameters.AddWithValue("@Provincia", Me.Provincia)
         cmdInsert.Parameters.AddWithValue("@ArrivatiProv", Me.ArrivatiProv)
         cmdInsert.Parameters.AddWithValue("@PartitiProv", Me.PartitiProv)

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
                             "Nazionalità = @Nazionalità, " &
                             "ArrivatiNaz = @ArrivatiNaz, " &
                             "PartitiNaz = @PartitiNaz, " &
                             "Provincia = @Provincia, " &
                             "ArrivatiProv = @ArrivatiProv, " &
                             "PartitiProv = @PartitiProv " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdUpdate.Parameters.AddWithValue("@Nazionalità", Me.Nazionalità)
         cmdUpdate.Parameters.AddWithValue("@ArrivatiNaz", Me.ArrivatiNaz)
         cmdUpdate.Parameters.AddWithValue("@PartitiNaz", Me.PartitiNaz)
         cmdUpdate.Parameters.AddWithValue("@Provincia", Me.Provincia)
         cmdUpdate.Parameters.AddWithValue("@ArrivatiProv", Me.ArrivatiProv)
         cmdUpdate.Parameters.AddWithValue("@PartitiProv", Me.PartitiProv)

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

   Public Function EliminaDati(ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0}", tabella)

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

End Class
