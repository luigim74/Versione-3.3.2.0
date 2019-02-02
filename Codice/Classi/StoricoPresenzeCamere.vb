#Region " DATI FILE.VB "
' ******************************************************************
' Nome Classe:          StoricoPresenzeCamere
' Autore:               Luigi Montana, Montana Software
' Data creazione:       24/06/2018
' Data ultima modifica: 25/08/2018
' Descrizione:          Classe Storico delle presenze per le camere Hotel.
' Note:
'
' Elenco Attivita:
'
' ******************************************************************
#End Region

Imports System.Data.OleDb

Public Class StoricoPresenzeCamere

   Public Codice As Integer
   Public RifPren As Integer
   Public Numero As Integer
   Public Mese As Integer
   Public Anno As Integer
   Public Adulti As Integer
   Public Neonati As Integer
   Public Bambini As Integer
   Public Ragazzi As Integer
   Public NumeroNotti As Integer
   Public DataArrivo As String
   Public DataPartenza As String
   Public Nazionalità As String
   Public Provincia As String

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
         ' Id prenotazione.
         If IsDBNull(ds.Tables(tabella).Rows(0)("RifPren")) = False Then
            Me.RifPren = Convert.ToInt32(ds.Tables(tabella).Rows(0)("RifPren"))
         Else
            Me.RifPren = codice
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Numero")) = False Then
            Me.Numero = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Numero"))
         Else
            Me.Numero = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Mese")) = False Then
            Me.Mese = ds.Tables(tabella).Rows(0)("Mese")
         Else
            Me.Mese = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Anno")) = False Then
            Me.Anno = ds.Tables(tabella).Rows(0)("Anno")
         Else
            Me.Anno = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Adulti")) = False Then
            Me.Adulti = ds.Tables(tabella).Rows(0)("Adulti").ToString
         Else
            Me.Adulti = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Neonati")) = False Then
            Me.Neonati = ds.Tables(tabella).Rows(0)("Neonati").ToString
         Else
            Me.Neonati = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Bambini")) = False Then
            Me.Bambini = ds.Tables(tabella).Rows(0)("Bambini").ToString
         Else
            Me.Bambini = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Ragazzi")) = False Then
            Me.Ragazzi = ds.Tables(tabella).Rows(0)("Ragazzi").ToString
         Else
            Me.Ragazzi = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumeroNotti")) = False Then
            Me.NumeroNotti = ds.Tables(tabella).Rows(0)("NumeroNotti").ToString
         Else
            Me.NumeroNotti = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataArrivo")) = False Then
            Me.DataArrivo = ds.Tables(tabella).Rows(0)("DataArrivo").ToString
         Else
            Me.DataArrivo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataPartenza")) = False Then
            Me.DataPartenza = ds.Tables(tabella).Rows(0)("DataPartenza").ToString
         Else
            Me.DataPartenza = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Nazionalità")) = False Then
            Me.Nazionalità = ds.Tables(tabella).Rows(0)("Nazionalità").ToString
         Else
            Me.Nazionalità = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Provincia")) = False Then
            Me.Provincia = ds.Tables(tabella).Rows(0)("Provincia").ToString
         Else
            Me.Provincia = String.Empty
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
         sql = String.Format("INSERT INTO {0} (RifPren, Numero, Mese, Anno, Adulti, Neonati, Bambini, Ragazzi, NumeroNotti, DataArrivo, DataPartenza, Nazionalità, Provincia) " &
                                       "VALUES(@RifPren, @Numero, @Mese, @Anno, @Adulti, @Neonati, @Bambini, @Ragazzi, @NumeroNotti, @DataArrivo, @DataPartenza, @Nazionalità, @Provincia)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@RifPren", Me.RifPren)
         cmdInsert.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdInsert.Parameters.AddWithValue("@Mese", Me.Mese)
         cmdInsert.Parameters.AddWithValue("@Anno", Me.Anno)
         cmdInsert.Parameters.AddWithValue("@Adulti", Me.Adulti)
         cmdInsert.Parameters.AddWithValue("@Neonati", Me.Neonati)
         cmdInsert.Parameters.AddWithValue("@Bambini", Me.Bambini)
         cmdInsert.Parameters.AddWithValue("@Ragazzi", Me.Ragazzi)
         cmdInsert.Parameters.AddWithValue("@NumeroNotti", Me.NumeroNotti)
         cmdInsert.Parameters.AddWithValue("@DataArrivo", Me.DataArrivo)
         cmdInsert.Parameters.AddWithValue("@DataPartenza", Me.DataPartenza)
         cmdInsert.Parameters.AddWithValue("@Nazionalità", Me.Nazionalità)
         cmdInsert.Parameters.AddWithValue("@Provincia", Me.Provincia)

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
                             "SET RifPren = @RifPren, " &
                             "Numero = @Numero, " &
                             "Mese = @Mese, " &
                             "Anno = @Anno, " &
                             "Adulti = @Adulti, " &
                             "Neonati = @Neonati, " &
                             "Bambini = @Bambini, " &
                             "Ragazzi = @Ragazzi, " &
                             "NumeroNotti = @NumeroNotti, " &
                             "DataArrivo = @DataArrivo, " &
                             "DataPartenza = @DataPartenza, " &
                             "Nazionalità = @Nazionalità, " &
                             "Provincia = @Provincia " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@RifPren", Me.RifPren)
         cmdUpdate.Parameters.AddWithValue("@Numero", Me.Numero)
         cmdUpdate.Parameters.AddWithValue("@Mese", Me.Mese)
         cmdUpdate.Parameters.AddWithValue("@Anno", Me.Anno)
         cmdUpdate.Parameters.AddWithValue("@Adulti", Me.Adulti)
         cmdUpdate.Parameters.AddWithValue("@Neonati", Me.Neonati)
         cmdUpdate.Parameters.AddWithValue("@Bambini", Me.Bambini)
         cmdUpdate.Parameters.AddWithValue("@Ragazzi", Me.Ragazzi)
         cmdUpdate.Parameters.AddWithValue("@NumeroNotti", Me.NumeroNotti)
         cmdUpdate.Parameters.AddWithValue("@DataArrivo", Me.DataArrivo)
         cmdUpdate.Parameters.AddWithValue("@DataPartenza", Me.DataPartenza)
         cmdUpdate.Parameters.AddWithValue("@Nazionalità", Me.Nazionalità)
         cmdUpdate.Parameters.AddWithValue("@Provincia", Me.Provincia)

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

   Public Function EliminaDati(ByVal tabella As String, ByVal Id As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE RifPren = {1}", tabella, Id)

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
