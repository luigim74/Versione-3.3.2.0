#Region " DATI FILE.VB "
' ******************************************************************
' Nome form:            Noleggi
' Autore:               Luigi Montana, Montana Software
' Data creazione:       01/03/2021
' Data ultima modifica: 27/03/2021
' Descrizione:          Classe noleggi.
' Note:

' Elenco Attivita:

' ******************************************************************
#End Region

Imports System.Data.OleDb

Public Class CausaliNoleggi

   Public Codice As String
   Public Descrizione As String
   Public CostoGiorno As Double
   Public CostoMora As Double
   Public CostoAssicurazione As Double
   Public Totale As Double
   Public Note As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction


   ''' <summary>
   ''' 
   ''' </summary>
   ''' <param name="tabella"></param>
   ''' <param name="codice"></param>
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
            Me.Codice = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione").ToString
         Else
            Me.Descrizione = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoGiorno")) = False Then
            Me.CostoGiorno = ds.Tables(tabella).Rows(0)("CostoGiorno")
         Else
            Me.CostoGiorno = 0.0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoMora")) = False Then
            Me.CostoMora = ds.Tables(tabella).Rows(0)("CostoMora")
         Else
            Me.CostoMora = 0.0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoAssicurazione")) = False Then
            Me.CostoAssicurazione = ds.Tables(tabella).Rows(0)("CostoAssicurazione")
         Else
            Me.CostoAssicurazione = 0.0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Totale")) = False Then
            Me.Totale = ds.Tables(tabella).Rows(0)("Totale").ToString
         Else
            Me.Totale = 0.0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note").ToString
         Else
            Me.Note = String.Empty
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
         sql = String.Format("INSERT INTO {0} (Descrizione, CostoGiorno, CostoMora, CostoAssicurazione, Totale, [Note]) " &
                                       "VALUES(@Descrizione, @CostoGiorno, @CostoMora, @CostoAssicurazione, @Totale, @Stato, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.AddWithValue("@CostoGiorno", Me.CostoGiorno)
         cmdInsert.Parameters.AddWithValue("@CostoMora", Me.CostoMora)
         cmdInsert.Parameters.AddWithValue("@CostoAssicurazione", Me.CostoAssicurazione)
         cmdInsert.Parameters.AddWithValue("@Totale", Me.Totale)
         cmdInsert.Parameters.AddWithValue("@Note", Me.Note)

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
                             "SET Causale = @Causale, " &
                             "CostoGiorno = @CostoGiorno, " &
                             "CostoMora = @CostoMora, " &
                             "CostoAssicurazione = @CostoAssicurazione, " &
                             "Totale = @Totale, " &
                             "[Note] = @Note " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.AddWithValue("@CostoGiorno", Me.CostoGiorno)
         cmdUpdate.Parameters.AddWithValue("@CostoMora", Me.CostoMora)
         cmdUpdate.Parameters.AddWithValue("@CostoAssicurazione", Me.CostoAssicurazione)
         cmdUpdate.Parameters.AddWithValue("@Totale", Me.Totale)
         cmdUpdate.Parameters.AddWithValue("@Note", Me.Note)

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

   Public Function EliminaDati(ByVal tabella As String, ByVal codice As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.

         sql = String.Format("DELETE FROM {0} WHERE Id = {1}", tabella, codice)

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
