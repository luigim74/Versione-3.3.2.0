Imports System.Data.OleDb

Public Class DettagliCausaliNoleggio

   Inherits DettagliNoleggi

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   Private CFormatta As New ClsFormatta

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("RifCausale")) = False Then
            Me.RifNoleggio = ds.Tables(tabella).Rows(0)("RifCausale").ToString
         Else
            Me.RifNoleggio = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodiceArticolo")) = False Then
            Me.CodiceArticolo = ds.Tables(tabella).Rows(0)("CodiceArticolo").ToString
         Else
            Me.CodiceArticolo = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione").ToString
         Else
            Me.Descrizione = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Unit‡Misura")) = False Then
            Me.Unit‡Misura = ds.Tables(tabella).Rows(0)("Unit‡Misura").ToString
         Else
            Me.Unit‡Misura = String.Empty
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Quantit‡")) = False Then
            Me.Quantit‡ = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Quantit‡"))
         Else
            Me.Quantit‡ = 0.0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ValoreUnitario")) = False Then
            Me.ValoreUnitario = ds.Tables(tabella).Rows(0)("ValoreUnitario").ToString
         Else
            Me.ValoreUnitario = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ImportoNetto")) = False Then
            Me.ImportoNetto = ds.Tables(tabella).Rows(0)("ImportoNetto").ToString
         Else
            Me.ImportoNetto = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AliquotaIva")) = False Then
            Me.AliquotaIva = ds.Tables(tabella).Rows(0)("AliquotaIva").ToString
         Else
            Me.AliquotaIva = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Categoria")) = False Then
            Me.Categoria = ds.Tables(tabella).Rows(0)("Categoria").ToString
         Else
            Me.Categoria = String.Empty
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
         sql = String.Format("INSERT INTO {0} (RifCausale, CodiceArticolo, Descrizione, Unit‡Misura, Quantit‡, ValoreUnitario, ImportoNetto, AliquotaIva, Categoria) " &
                                       "VALUES(@RifCausale, @CodiceArticolo, @Descrizione, @Unit‡Misura, @Quantit‡, @ValoreUnitario, @ImportoNetto, @AliquotaIva, @Categoria)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@RifCausale", Me.RifNoleggio)
         cmdInsert.Parameters.AddWithValue("@CodiceArticolo", Me.CodiceArticolo)
         cmdInsert.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.AddWithValue("@Unit‡Misura", Me.Unit‡Misura)
         cmdInsert.Parameters.AddWithValue("@Quantit‡", Me.Quantit‡)
         cmdInsert.Parameters.AddWithValue("@ValoreUnitario", Me.ValoreUnitario)
         cmdInsert.Parameters.AddWithValue("@ImportoNetto", Me.ImportoNetto)
         cmdInsert.Parameters.AddWithValue("@AliquotaIva", Me.AliquotaIva)
         cmdInsert.Parameters.AddWithValue("@Categoria", Me.Categoria)

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

   Public Function EliminaDati(ByVal tabella As String, ByVal RifCausale As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.

         sql = String.Format("DELETE FROM {0} WHERE RifCausale = {1}", tabella, RifCausale)

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
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET RifCausale = @RifCausale, " &
                             "CodiceArticolo = @CodiceArticolo, " &
                             "Descrizione = @Descrizione, " &
                             "Unit‡Misura = @Unit‡Misura, " &
                             "Quantit‡ = @Quantit‡, " &
                             "ValoreUnitario = @ValoreUnitario, " &
                             "ImportoNetto = @ImportoNetto, " &
                             "AliquotaIva = @AliquotaIva, " &
                             "Categoria = @Categoria " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@RifCausale", Me.RifNoleggio)
         cmdUpdate.Parameters.AddWithValue("@CodiceArticolo", Me.CodiceArticolo)
         cmdUpdate.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.AddWithValue("@Unit‡Misura", Me.Unit‡Misura)
         cmdUpdate.Parameters.AddWithValue("@Quantit‡", Me.Quantit‡)
         cmdUpdate.Parameters.AddWithValue("@ValoreUnitario", Me.ValoreUnitario)
         cmdUpdate.Parameters.AddWithValue("@ImportoNetto", Me.ImportoNetto)
         cmdUpdate.Parameters.AddWithValue("@AliquotaIva", Me.AliquotaIva)
         cmdUpdate.Parameters.AddWithValue("@Categoria", Me.Categoria)

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
