Imports System.Data.OleDb

Public Class ListinoCamera

   Public Codice As String
   Public Descrizione As String
   Public Tipologia As String
   Public SoloPernottamento_Bassa As String
   Public BB_Bassa As String
   Public MezzaPensione_Bassa As String
   Public PensioneCompleta_Bassa As String
   Public ScontoNeonato_Bassa As String
   Public ScontoBambino_Bassa As String
   Public ScontoRagazzo_Bassa As String
   Public SoloPernottamento_Media As String
   Public BB_Media As String
   Public MezzaPensione_Media As String
   Public PensioneCompleta_Media As String
   Public ScontoNeonato_Media As String
   Public ScontoBambino_Media As String
   Public ScontoRagazzo_Media As String
   Public SoloPernottamento_Alta As String
   Public BB_Alta As String
   Public MezzaPensione_Alta As String
   Public PensioneCompleta_Alta As String
   Public ScontoNeonato_Alta As String
   Public ScontoBambino_Alta As String
   Public ScontoRagazzo_Alta As String
   Public Note As String

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("TipologiaListino")) = False Then
            Me.Tipologia = ds.Tables(tabella).Rows(0)("TipologiaListino").ToString
         Else
            Me.Tipologia = ""
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("SoloPernottamento_Bassa")) = False Then
            Me.SoloPernottamento_Bassa = ds.Tables(tabella).Rows(0)("SoloPernottamento_Bassa").ToString
         Else
            Me.SoloPernottamento_Bassa = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("BB_Bassa")) = False Then
            Me.BB_Bassa = ds.Tables(tabella).Rows(0)("BB_Bassa").ToString
         Else
            Me.BB_Bassa = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("MezzaPensione_Bassa")) = False Then
            Me.MezzaPensione_Bassa = ds.Tables(tabella).Rows(0)("MezzaPensione_Bassa").ToString
         Else
            Me.MezzaPensione_Bassa = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PensioneCompleta_Bassa")) = False Then
            Me.PensioneCompleta_Bassa = ds.Tables(tabella).Rows(0)("PensioneCompleta_Bassa").ToString
         Else
            Me.PensioneCompleta_Bassa = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScontoNeonato_Bassa")) = False Then
            Me.ScontoNeonato_Bassa = ds.Tables(tabella).Rows(0)("ScontoNeonato_Bassa").ToString
         Else
            Me.ScontoNeonato_Bassa = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScontoBambino_Bassa")) = False Then
            Me.ScontoBambino_Bassa = ds.Tables(tabella).Rows(0)("ScontoBambino_Bassa").ToString
         Else
            Me.ScontoBambino_Bassa = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScontoRagazzo_Bassa")) = False Then
            Me.ScontoRagazzo_Bassa = ds.Tables(tabella).Rows(0)("ScontoRagazzo_Bassa").ToString
         Else
            Me.ScontoRagazzo_Bassa = VALORE_ZERO
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("SoloPernottamento_Media")) = False Then
            Me.SoloPernottamento_Media = ds.Tables(tabella).Rows(0)("SoloPernottamento_Media").ToString
         Else
            Me.SoloPernottamento_Media = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("BB_Media")) = False Then
            Me.BB_Media = ds.Tables(tabella).Rows(0)("BB_Media").ToString
         Else
            Me.BB_Media = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("MezzaPensione_Media")) = False Then
            Me.MezzaPensione_Media = ds.Tables(tabella).Rows(0)("MezzaPensione_Media").ToString
         Else
            Me.MezzaPensione_Media = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PensioneCompleta_Media")) = False Then
            Me.PensioneCompleta_Media = ds.Tables(tabella).Rows(0)("PensioneCompleta_Media").ToString
         Else
            Me.PensioneCompleta_Media = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScontoNeonato_Media")) = False Then
            Me.ScontoNeonato_Media = ds.Tables(tabella).Rows(0)("ScontoNeonato_Media").ToString
         Else
            Me.ScontoNeonato_Media = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScontoBambino_Media")) = False Then
            Me.ScontoBambino_Media = ds.Tables(tabella).Rows(0)("ScontoBambino_Media").ToString
         Else
            Me.ScontoBambino_Media = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScontoRagazzo_Media")) = False Then
            Me.ScontoRagazzo_Media = ds.Tables(tabella).Rows(0)("ScontoRagazzo_Media").ToString
         Else
            Me.ScontoRagazzo_Media = VALORE_ZERO
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("SoloPernottamento_Alta")) = False Then
            Me.SoloPernottamento_Alta = ds.Tables(tabella).Rows(0)("SoloPernottamento_Alta").ToString
         Else
            Me.SoloPernottamento_Alta = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("BB_Alta")) = False Then
            Me.BB_Alta = ds.Tables(tabella).Rows(0)("BB_Alta").ToString
         Else
            Me.BB_Alta = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("MezzaPensione_Alta")) = False Then
            Me.MezzaPensione_Alta = ds.Tables(tabella).Rows(0)("MezzaPensione_Alta").ToString
         Else
            Me.MezzaPensione_Alta = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PensioneCompleta_Alta")) = False Then
            Me.PensioneCompleta_Alta = ds.Tables(tabella).Rows(0)("PensioneCompleta_Alta").ToString
         Else
            Me.PensioneCompleta_Alta = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScontoNeonato_Alta")) = False Then
            Me.ScontoNeonato_Alta = ds.Tables(tabella).Rows(0)("ScontoNeonato_Alta").ToString
         Else
            Me.ScontoNeonato_Alta = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScontoBambino_Alta")) = False Then
            Me.ScontoBambino_Alta = ds.Tables(tabella).Rows(0)("ScontoBambino_Alta").ToString
         Else
            Me.ScontoBambino_Alta = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScontoRagazzo_Alta")) = False Then
            Me.ScontoRagazzo_Alta = ds.Tables(tabella).Rows(0)("ScontoRagazzo_Alta").ToString
         Else
            Me.ScontoRagazzo_Alta = VALORE_ZERO
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note").ToString
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
         sql = String.Format("INSERT INTO {0} (Descrizione, TipologiaListino, " & _
                                              "SoloPernottamento_Bassa, BB_Bassa, MezzaPensione_Bassa, PensioneCompleta_Bassa, ScontoNeonato_Bassa, ScontoBambino_Bassa, ScontoRagazzo_Bassa, " & _
                                              "SoloPernottamento_Media, BB_Media, MezzaPensione_Media, PensioneCompleta_Media, ScontoNeonato_Media, ScontoBambino_Media, ScontoRagazzo_Media, " & _
                                              "SoloPernottamento_Alta, BB_Alta, MezzaPensione_Alta, PensioneCompleta_Alta, ScontoNeonato_Alta, ScontoBambino_Alta, ScontoRagazzo_Alta, [Note]) " & _
                                       "VALUES(@Descrizione, @TipologiaListino, " & _
                                              "@SoloPernottamento_Bassa, @BB_Bassa, @MezzaPensione_Bassa, @PensioneCompleta_Bassa, @ScontoNeonato_Bassa, @ScontoBambino_Bassa, @ScontoRagazzo_Bassa, " & _
                                              "@SoloPernottamento_Media, @BB_Media, MezzaPensione_Media, @PensioneCompleta_Media, @ScontoNeonato_Media, @ScontoBambino_Media, @ScontoRagazzo_Media, " & _
                                              "@SoloPernottamento_Alta, @BB_Alta, MezzaPensione_Alta, @PensioneCompleta_Alta, @ScontoNeonato_Alta, @ScontoBambino_Alta, @ScontoRagazzo_Alta, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.AddWithValue("@TipologiaListino", Me.Tipologia)
         cmdInsert.Parameters.AddWithValue("@SoloPernottamento_Bassa", Me.SoloPernottamento_Bassa)
         cmdInsert.Parameters.AddWithValue("@BB_Bassa", Me.BB_Bassa)
         cmdInsert.Parameters.AddWithValue("@MezzaPensione_Bassa", Me.MezzaPensione_Bassa)
         cmdInsert.Parameters.AddWithValue("@PensioneCompleta_Bassa", Me.PensioneCompleta_Bassa)
         cmdInsert.Parameters.AddWithValue("@ScontoNeonato_Bassa", Me.ScontoNeonato_Bassa)
         cmdInsert.Parameters.AddWithValue("@ScontoBambino_Bassa", Me.ScontoBambino_Bassa)
         cmdInsert.Parameters.AddWithValue("@ScontoRagazzo_Bassa", Me.ScontoRagazzo_Bassa)

         cmdInsert.Parameters.AddWithValue("@SoloPernottamento_Media", Me.SoloPernottamento_Media)
         cmdInsert.Parameters.AddWithValue("@BB_Media", Me.BB_Media)
         cmdInsert.Parameters.AddWithValue("@MezzaPensione_Media", Me.MezzaPensione_Media)
         cmdInsert.Parameters.AddWithValue("@PensioneCompleta_Media", Me.PensioneCompleta_Media)
         cmdInsert.Parameters.AddWithValue("@ScontoNeonato_Media", Me.ScontoNeonato_Media)
         cmdInsert.Parameters.AddWithValue("@ScontoBambino_Media", Me.ScontoBambino_Media)
         cmdInsert.Parameters.AddWithValue("@ScontoRagazzo_Media", Me.ScontoRagazzo_Media)

         cmdInsert.Parameters.AddWithValue("@SoloPernottamento_Alta", Me.SoloPernottamento_Alta)
         cmdInsert.Parameters.AddWithValue("@BB_Alta", Me.BB_Alta)
         cmdInsert.Parameters.AddWithValue("@MezzaPensione_Alta", Me.MezzaPensione_Alta)
         cmdInsert.Parameters.AddWithValue("@PensioneCompleta_Alta", Me.PensioneCompleta_Alta)
         cmdInsert.Parameters.AddWithValue("@ScontoNeonato_Alta", Me.ScontoNeonato_Alta)
         cmdInsert.Parameters.AddWithValue("@ScontoBambino_Alta", Me.ScontoBambino_Alta)
         cmdInsert.Parameters.AddWithValue("@ScontoRagazzo_Alta", Me.ScontoRagazzo_Alta)

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
         sql = String.Format("UPDATE {0} " & _
                             "SET Descrizione = @Descrizione, " & _
                             "TipologiaListino = @TipologiaListino, " & _
                             "SoloPernottamento_Bassa = @SoloPernottamento_Bassa, " & _
                             "BB_Bassa = @BB_Bassa, " & _
                             "MezzaPensione_Bassa = @MezzaPensione_Bassa, " & _
                             "PensioneCompleta_Bassa = @PensioneCompleta_Bassa, " & _
                             "ScontoNeonato_Bassa = @ScontoNeonato_Bassa, " & _
                             "ScontoBambino_Bassa = @ScontoBambino_Bassa, " & _
                             "ScontoRagazzo_Bassa = @ScontoRagazzo_Bassa, " & _
                             "SoloPernottamento_Media = @SoloPernottamento_Media, " & _
                             "BB_Media = @BB_Media, " & _
                             "MezzaPensione_Media = @MezzaPensione_Media, " & _
                             "PensioneCompleta_Media = @PensioneCompleta_Media, " & _
                             "ScontoNeonato_Media = @ScontoNeonato_Media, " & _
                             "ScontoBambino_Media = @ScontoBambino_Media, " & _
                             "ScontoRagazzo_Media = @ScontoRagazzo_Media, " & _
                             "SoloPernottamento_Alta = @SoloPernottamento_Alta, " & _
                             "BB_Alta = @BB_Alta, " & _
                             "MezzaPensione_Alta = @MezzaPensione_Alta, " & _
                             "PensioneCompleta_Alta = @PensioneCompleta_Alta, " & _
                             "ScontoNeonato_Alta = @ScontoNeonato_Alta, " & _
                             "ScontoBambino_Alta = @ScontoBambino_Alta, " & _
                             "ScontoRagazzo_Alta = @ScontoRagazzo_Alta, " & _
                             "[Note] = @Note " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.AddWithValue("@TipologiaListino", Me.Tipologia)
         cmdUpdate.Parameters.AddWithValue("@SoloPernottamento_Bassa", Me.SoloPernottamento_Bassa)
         cmdUpdate.Parameters.AddWithValue("@BB_Bassa", Me.BB_Bassa)
         cmdUpdate.Parameters.AddWithValue("@MezzaPensione_Bassa", Me.MezzaPensione_Bassa)
         cmdUpdate.Parameters.AddWithValue("@PensioneCompleta_Bassa", Me.PensioneCompleta_Bassa)
         cmdUpdate.Parameters.AddWithValue("@ScontoNeonato_Bassa", Me.ScontoNeonato_Bassa)
         cmdUpdate.Parameters.AddWithValue("@ScontoBambino_Bassa", Me.ScontoBambino_Bassa)
         cmdUpdate.Parameters.AddWithValue("@ScontoRagazzo_Bassa", Me.ScontoRagazzo_Bassa)

         cmdUpdate.Parameters.AddWithValue("@SoloPernottamento_Media", Me.SoloPernottamento_Media)
         cmdUpdate.Parameters.AddWithValue("@BB_Media", Me.BB_Media)
         cmdUpdate.Parameters.AddWithValue("@MezzaPensione_Media", Me.MezzaPensione_Media)
         cmdUpdate.Parameters.AddWithValue("@PensioneCompleta_Media", Me.PensioneCompleta_Media)
         cmdUpdate.Parameters.AddWithValue("@ScontoNeonato_Media", Me.ScontoNeonato_Media)
         cmdUpdate.Parameters.AddWithValue("@ScontoBambino_Media", Me.ScontoBambino_Media)
         cmdUpdate.Parameters.AddWithValue("@ScontoRagazzo_Media", Me.ScontoRagazzo_Media)

         cmdUpdate.Parameters.AddWithValue("@SoloPernottamento_Alta", Me.SoloPernottamento_Alta)
         cmdUpdate.Parameters.AddWithValue("@BB_Alta", Me.BB_Alta)
         cmdUpdate.Parameters.AddWithValue("@MezzaPensione_Alta", Me.MezzaPensione_Alta)
         cmdUpdate.Parameters.AddWithValue("@PensioneCompleta_Alta", Me.PensioneCompleta_Alta)
         cmdUpdate.Parameters.AddWithValue("@ScontoNeonato_Alta", Me.ScontoNeonato_Alta)
         cmdUpdate.Parameters.AddWithValue("@ScontoBambino_Alta", Me.ScontoBambino_Alta)
         cmdUpdate.Parameters.AddWithValue("@ScontoRagazzo_Alta", Me.ScontoRagazzo_Alta)

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
End Class
