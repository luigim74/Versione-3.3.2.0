Imports System.Data.OleDb

Public Class BuoniFatt

   Public Codice As Integer
   Public IdBuono As Integer
   Public IdDoc As Integer
   Public NumDoc As Integer
   Public DataDoc As Date
   Public Descrizione As String
   Public Quantità As String
   Public ValoreUnitario As String
   Public ValoreTotale As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore
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
         sql = String.Format("SELECT * FROM {0} WHERE IdBuono = {1}", tabella, codice)

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdBuono")) = False Then
            Me.IdBuono = ds.Tables(tabella).Rows(0)("IdBuono")
         Else
            Me.IdBuono = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdDoc")) = False Then
            Me.IdDoc = ds.Tables(tabella).Rows(0)("IdDoc")
         Else
            Me.IdDoc = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumDoc")) = False Then
            Me.NumDoc = ds.Tables(tabella).Rows(0)("NumDoc")
         Else
            Me.NumDoc = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DataDoc")) = False Then
            Me.DataDoc = ds.Tables(tabella).Rows(0)("DataDoc")
         Else
            Me.DataDoc = Nothing
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione")
         Else
            Me.Descrizione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Quantità")) = False Then
            Me.Quantità = ds.Tables(tabella).Rows(0)("Quantità")
         Else
            Me.Quantità = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ValoreUnitario")) = False Then
            Me.ValoreUnitario = ds.Tables(tabella).Rows(0)("ValoreUnitario")
         Else
            Me.ValoreUnitario = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ValoreTotale")) = False Then
            Me.ValoreTotale = ds.Tables(tabella).Rows(0)("ValoreTotale")
         Else
            Me.ValoreTotale = VALORE_ZERO
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
         sql = String.Format("INSERT INTO {0} (IdBuono, IdDoc, NumDoc, DataDoc, Descrizione, Quantità, ValoreUnitario, ValoreTotale) " & _
                                       "VALUES(@IdBuono, @IdDoc, @NumDoc, @DataDoc, @Descrizione, @Quantità, @ValoreUnitario, @ValoreTotale)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@IdBuono", Me.IdBuono)
         cmdInsert.Parameters.Add("@IdDoc", Me.IdDoc)
         cmdInsert.Parameters.Add("@NumDoc", Me.NumDoc)
         cmdInsert.Parameters.Add("@DataDoc", Me.DataDoc)
         cmdInsert.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.Add("@Quantità", Me.Quantità)
         cmdInsert.Parameters.Add("@ValoreUnitario", Me.ValoreUnitario)
         cmdInsert.Parameters.Add("@ValoreTotale", Me.ValoreTotale)

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

End Class
