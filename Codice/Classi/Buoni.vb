Imports System.Data.OleDb

Public Class Buoni

   Public Codice As Integer
   Public Descrizione As String
   Public Quantit‡ As Double
   Public ValoreUnitario As String
   Public ValoreTotale As String
   Public Quantit‡Fatt As Double
   Public ValoreFatt As String
   Public IdAzienda As Integer

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore
   Private CFormatta As New ClsFormatta

   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String, ByVal codAzienda As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE IdAzienda = " & codAzienda & " ORDER BY Descrizione ASC", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            lst.Items.Add(dr.Item("Descrizione"))
            lst.Items(i).SubItems.Add(CFormatta.FormattaEuro(dr.Item("ValoreUnitario")))
            lst.Items(i).SubItems.Add(dr.Item("Quantit‡"))
            lst.Items(i).SubItems.Add(CFormatta.FormattaEuro(dr.Item("ValoreTotale")))
            lst.Items(i).SubItems.Add(dr.Item("Quantit‡Fatt"))
            lst.Items(i).SubItems.Add(CFormatta.FormattaEuro(dr.Item("ValoreFatt")))
            lst.Items(i).SubItems.Add(dr.Item("Id"))
            
            lst.Items(i).StateImageIndex = 11

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
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.
         sql = String.Format("INSERT INTO {0} (Descrizione, Quantit‡, ValoreUnitario, ValoreTotale, Quantit‡Fatt, ValoreFatt, IdAzienda) " & _
                                       "VALUES(@Descrizione, @Quantit‡, @ValoreUnitario, @ValoreTotale, @Quantit‡Fatt, @ValoreFatt, @IdAzienda)", tabella)


         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.Add("@Quantit‡", Me.Quantit‡)
         cmdInsert.Parameters.Add("@ValoreUnitario", Me.ValoreUnitario)
         cmdInsert.Parameters.Add("@ValoreTotale", Me.ValoreTotale)
         cmdInsert.Parameters.Add("@Quantit‡Fatt", Me.Quantit‡Fatt)
         cmdInsert.Parameters.Add("@ValoreFatt", Me.ValoreFatt)
         cmdInsert.Parameters.Add("@IdAzienda", Me.IdAzienda)

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

   Public Function ModificaDati(ByVal tabella As String, ByVal Id As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " & _
                             "SET Descrizione = @Descrizione, " & _
                             "Quantit‡ = @Quantit‡, " & _
                             "ValoreUnitario = @ValoreUnitario, " & _
                             "ValoreTotale = @ValoreTotale, " & _
                             "Quantit‡Fatt = @Quantit‡Fatt, " & _
                             "ValoreFatt = @ValoreFatt, " & _
                             "IdAzienda = @IdAzienda " & _
                             "WHERE Id = {1}", _
                             tabella, _
                             Id)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.Add("@Quantit‡", Me.Quantit‡)
         cmdUpdate.Parameters.Add("@ValoreUnitario", Me.ValoreUnitario)
         cmdUpdate.Parameters.Add("@ValoreTotale", Me.ValoreTotale)
         cmdUpdate.Parameters.Add("@Quantit‡Fatt", Me.Quantit‡Fatt)
         cmdUpdate.Parameters.Add("@ValoreFatt", Me.ValoreFatt)
         cmdUpdate.Parameters.Add("@IdAzienda", Me.IdAzienda)

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
