Imports System.Data.OleDb

Public Class Comande

   Public IdRisorsa As Integer
   Public Risorsa As String
   Public Cameriere As String
   Public Coperti As String
   Public Descrizione As String
   Public Quantità As Double
   Public ValoreUnitario As String
   Public ImportoNetto As String
   Public IdPiatto As Integer
   Public CategoriaPiatto As String
   Public Reparto As String
   Public Inviata As String
   Public Esclusa As String
   Public Offerta As String
   Public NumeroConto As String
   Public AliquotaIva As String

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction
   ' Gestione degli errori.
   Private err As New Varie.Errore
   Private CFormatta As New ClsFormatta

   Public Function LeggiDati(ByVal tabella As String, ByVal codRisorsa As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)

      Try
         cn.Open()

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE IdRisorsa = " & codRisorsa, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         Do While dr.Read()
            ' IdRisorsa
            If IsDBNull(dr.Item("IdRisorsa")) = False Then
               Me.IdRisorsa = Convert.ToInt32(dr.Item("IdRisorsa"))
            Else
               Me.IdRisorsa = codRisorsa
            End If
            ' Risorsa.
            If IsDBNull(dr.Item("Risorsa")) = False Then
               Me.Risorsa = dr.Item("Risorsa").ToString
            Else
               Me.Risorsa = String.Empty
            End If
            ' Cameriere.
            If IsDBNull(dr.Item("Cameriere")) = False Then
               Me.Cameriere = dr.Item("Cameriere").ToString
            Else
               Me.Cameriere = String.Empty
            End If
            ' Coperti.
            If IsDBNull(dr.Item("Coperti")) = False Then
               Me.Coperti = dr.Item("Coperti").ToString
            Else
               Me.Coperti = String.Empty
            End If
            ' Quantità
            If IsDBNull(dr.Item("Quantità")) = False Then
               Me.Quantità = Convert.ToDouble(dr.Item("Quantità"))
            Else
               Me.Quantità = 1
            End If
            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               Me.Descrizione = dr.Item("Descrizione").ToString
            Else
               Me.Descrizione = String.Empty
            End If
            ' Totale.
            If IsDBNull(dr.Item("ImportoNetto")) = False Then
               Me.ImportoNetto = CFormatta.FormattaEuro(Convert.ToDouble(dr.Item("ImportoNetto")))
            Else
               Me.ImportoNetto = VALORE_ZERO
            End If
            ' Importo.
            If IsDBNull(dr.Item("ValoreUnitario")) = False Then
               Me.ValoreUnitario = CFormatta.FormattaEuro(Convert.ToDouble(dr.Item("ValoreUnitario")))
            Else
               Me.ValoreUnitario = VALORE_ZERO
            End If
            ' Id Piatto.
            If IsDBNull(dr.Item("IdPiatto")) = False Then
               Me.IdPiatto = Convert.ToInt32(dr.Item("IdPiatto"))
            Else
               Me.IdPiatto = 0
            End If
            ' Categoria.
            If IsDBNull(dr.Item("CategoriaPiatto")) = False Then
               Me.CategoriaPiatto = dr.Item("CategoriaPiatto").ToString
            Else
               Me.CategoriaPiatto = String.Empty
            End If
            ' Reparto.
            If IsDBNull(dr.Item("Reparto")) = False Then
               Me.Reparto = dr.Item("Reparto").ToString
            Else
               Me.Reparto = String.Empty
            End If
            ' Inviata.
            If IsDBNull(dr.Item("Inviata")) = False Then
               Me.Inviata = dr.Item("Inviata").ToString
            Else
               Me.Inviata = String.Empty
            End If
            ' Esclusa.
            If IsDBNull(dr.Item("Esclusa")) = False Then
               Me.Esclusa = dr.Item("Esclusa").ToString
            Else
               Me.Esclusa = String.Empty
            End If
            ' Offerta.
            If IsDBNull(dr.Item("Offerta")) = False Then
               Me.Offerta = dr.Item("Offerta").ToString
            Else
               Me.Offerta = String.Empty
            End If
            ' Numero Conto.
            If IsDBNull(dr.Item("NumeroConto")) = False Then
               Me.NumeroConto = dr.Item("NumeroConto").ToString
            Else
               Me.NumeroConto = String.Empty
            End If
            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               Me.AliquotaIva = dr.Item("AliquotaIva").ToString
            Else
               Me.AliquotaIva = String.Empty
            End If
         Loop

         Return True

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return False
      Finally
         cn.Close()

      End Try
   End Function

   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String, ByVal codRisorsa As Integer) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE IdRisorsa = " & codRisorsa, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            ' Indice
            lst.Items.Add(i)
            ' Quantità
            If IsDBNull(dr.Item("Quantità")) = False Then
               If dr.Item("Quantità").ToString = "0" Then
                  lst.Items(i).SubItems.Add(String.Empty)
               Else
                  lst.Items(i).SubItems.Add(dr.Item("Quantità").ToString)
               End If
            Else
               lst.Items(i).SubItems.Add("1")
            End If
            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Descrizione").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Totale.
            If IsDBNull(dr.Item("ImportoNetto")) = False Then
               lst.Items(i).SubItems.Add(CFormatta.FormattaEuro(Convert.ToDouble(dr.Item("ImportoNetto"))))
            Else
               lst.Items(i).SubItems.Add(VALORE_ZERO)
            End If
            ' Importo.
            If IsDBNull(dr.Item("ValoreUnitario")) = False Then
               lst.Items(i).SubItems.Add(CFormatta.FormattaEuro(Convert.ToDouble(dr.Item("ValoreUnitario"))))
            Else
               lst.Items(i).SubItems.Add(VALORE_ZERO)
            End If
            ' Id Piatto.
            If IsDBNull(dr.Item("IdPiatto")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("IdPiatto").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Categoria.
            If IsDBNull(dr.Item("CategoriaPiatto")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("CategoriaPiatto").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Reparto.
            If IsDBNull(dr.Item("Reparto")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Reparto").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Inviata.
            If IsDBNull(dr.Item("Inviata")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Inviata").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Esclusa.
            If IsDBNull(dr.Item("Esclusa")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Esclusa").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Offerta.
            If IsDBNull(dr.Item("Offerta")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Offerta").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If

            lst.Items(i).SubItems.Add(dr.Item("Id").ToString)

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("AliquotaIva").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If

            If dr.Item("Inviata").ToString = "Sì" Then
               lst.Items(i).BackColor = Color.MediumSeaGreen
               lst.Items(i).ForeColor = Color.White
               lst.Items(i).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
            End If

            If dr.Item("Esclusa").ToString = "Sì" Then
               lst.Items(i).BackColor = Color.DimGray
               lst.Items(i).ForeColor = Color.White
               lst.Items(i).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic)
            End If

            If dr.Item("Offerta").ToString = "Sì" Then
               lst.Items(i).BackColor = Color.Orange
               lst.Items(i).ForeColor = Color.White
               lst.Items(i).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Strikeout)
            End If
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

   Public Function LeggiDati(ByVal lst As ListView, ByVal tabella As String, ByVal numConto As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE NumeroConto = '" & numConto & "'", cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            ' Indice
            lst.Items.Add(i)
            ' Quantità
            If IsDBNull(dr.Item("Quantità")) = False Then
               If dr.Item("Quantità").ToString = "0" Then
                  lst.Items(i).SubItems.Add(String.Empty)
               Else
                  lst.Items(i).SubItems.Add(dr.Item("Quantità").ToString)
               End If
            Else
               lst.Items(i).SubItems.Add("1")
            End If
            ' Descrizione.
            If IsDBNull(dr.Item("Descrizione")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Descrizione").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Totale.
            If IsDBNull(dr.Item("ImportoNetto")) = False Then
               lst.Items(i).SubItems.Add(CFormatta.FormattaEuro(Convert.ToDouble(dr.Item("ImportoNetto"))))
            Else
               lst.Items(i).SubItems.Add(VALORE_ZERO)
            End If
            ' Importo.
            If IsDBNull(dr.Item("ValoreUnitario")) = False Then
               lst.Items(i).SubItems.Add(CFormatta.FormattaEuro(Convert.ToDouble(dr.Item("ValoreUnitario"))))
            Else
               lst.Items(i).SubItems.Add(VALORE_ZERO)
            End If
            ' Id Piatto.
            If IsDBNull(dr.Item("IdPiatto")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("IdPiatto").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Categoria.
            If IsDBNull(dr.Item("CategoriaPiatto")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("CategoriaPiatto").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Reparto.
            If IsDBNull(dr.Item("Reparto")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Reparto").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Inviata.
            If IsDBNull(dr.Item("Inviata")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Inviata").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Esclusa.
            If IsDBNull(dr.Item("Esclusa")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Esclusa").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If
            ' Offerta.
            If IsDBNull(dr.Item("Offerta")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("Offerta").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If

            lst.Items(i).SubItems.Add(dr.Item("Id").ToString)

            ' Aliquota Iva.
            If IsDBNull(dr.Item("AliquotaIva")) = False Then
               lst.Items(i).SubItems.Add(dr.Item("AliquotaIva").ToString)
            Else
               lst.Items(i).SubItems.Add(String.Empty)
            End If

            If dr.Item("Inviata").ToString = "Sì" Then
               lst.Items(i).BackColor = Color.MediumSeaGreen
               lst.Items(i).ForeColor = Color.White
               lst.Items(i).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)
            End If

            If dr.Item("Esclusa").ToString = "Sì" Then
               lst.Items(i).BackColor = Color.DimGray
               lst.Items(i).ForeColor = Color.White
               lst.Items(i).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic)
            End If

            If dr.Item("Offerta").ToString = "Sì" Then
               lst.Items(i).BackColor = Color.Orange
               lst.Items(i).ForeColor = Color.White
               lst.Items(i).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Strikeout)
            End If
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
         sql = String.Format("INSERT INTO {0} (IdRisorsa, Risorsa, Cameriere, Coperti, Descrizione, Quantità, ValoreUnitario, ImportoNetto, IdPiatto, CategoriaPiatto, Reparto, Inviata, Esclusa, Offerta, NumeroConto, AliquotaIva) " &
                                       "VALUES(@IdRisorsa, @Risorsa, @Cameriere, @Coperti, @Descrizione, @Quantità, @ValoreUnitario, @ImportoNetto, @IdPiatto, @CategoriaPiatto, @Reparto, @Inviata, @Esclusa, @Offerta, @NumeroConto, @AliquotaIva)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@IdRisorsa", Me.IdRisorsa)
         cmdInsert.Parameters.AddWithValue("@Risorsa", Me.Risorsa)
         cmdInsert.Parameters.AddWithValue("@Cameriere", Me.Cameriere)
         cmdInsert.Parameters.AddWithValue("@Coperti", Me.Coperti)
         cmdInsert.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.AddWithValue("@Quantità", Me.Quantità)
         cmdInsert.Parameters.AddWithValue("@ValoreUnitario", Me.ValoreUnitario)
         cmdInsert.Parameters.AddWithValue("@ImportoNetto", Me.ImportoNetto)
         cmdInsert.Parameters.AddWithValue("@IdPiatto", Me.IdPiatto)
         cmdInsert.Parameters.AddWithValue("@CategoriaPiatto", Me.CategoriaPiatto)
         cmdInsert.Parameters.AddWithValue("@Reparto", Me.Reparto)
         cmdInsert.Parameters.AddWithValue("@Inviata", Me.Inviata)
         cmdInsert.Parameters.AddWithValue("@Esclusa", Me.Esclusa)
         cmdInsert.Parameters.AddWithValue("@Offerta", Me.Offerta)
         cmdInsert.Parameters.AddWithValue("@NumeroConto", Me.NumeroConto)
         cmdInsert.Parameters.AddWithValue("@AliquotaIva", Me.AliquotaIva)

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

   Public Function ModificaDati(ByVal tabella As String, ByVal codRisorsa As Integer) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET IdRisorsa = @IdRisorsa, " &
                             "Risorsa = @Risorsa, " &
                             "Cameriere = @Cameriere, " &
                             "Coperti = @Coperti, " &
                             "Descrizione = @Descrizione, " &
                             "Quantità = @Quantità, " &
                             "ValoreUnitario = @ValoreUnitario, " &
                             "ImportoNetto = @ImportoNetto, " &
                             "IdPiatto = @IdPiatto, " &
                             "CategoriaPiatto = @CategoriaPiatto, " &
                             "Reparto = @Reparto, " &
                             "Inviata = @Inviata, " &
                             "Esclusa = @Esclusa, " &
                             "Offerta = @Offerta, " &
                             "NumeroConto = @NumeroConto, " &
                             "AliquotaIva = @AliquotaIva " &
                             "WHERE IdRisorsa = {1}",
                             tabella,
                             codRisorsa)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@IdRisorsa", Me.IdRisorsa)
         cmdUpdate.Parameters.AddWithValue("@Risorsa", Me.Risorsa)
         cmdUpdate.Parameters.AddWithValue("@Cameriere", Me.Cameriere)
         cmdUpdate.Parameters.AddWithValue("@Coperti", Me.Coperti)
         cmdUpdate.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.AddWithValue("@Quantità", Me.Quantità)
         cmdUpdate.Parameters.AddWithValue("@ValoreUnitario", Me.ValoreUnitario)
         cmdUpdate.Parameters.AddWithValue("@ImportoNetto", Me.ImportoNetto)
         cmdUpdate.Parameters.AddWithValue("@IdPiatto", Me.IdPiatto)
         cmdUpdate.Parameters.AddWithValue("@CategoriaPiatto", Me.CategoriaPiatto)
         cmdUpdate.Parameters.AddWithValue("@Reparto", Me.Reparto)
         cmdUpdate.Parameters.AddWithValue("@Inviata", Me.Inviata)
         cmdUpdate.Parameters.AddWithValue("@Esclusa", Me.Esclusa)
         cmdUpdate.Parameters.AddWithValue("@Offerta", Me.Offerta)
         cmdUpdate.Parameters.AddWithValue("@NumeroConto", Me.NumeroConto)
         cmdUpdate.Parameters.AddWithValue("@AliquotaIva", Me.AliquotaIva)

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
         sql = String.Format("DELETE FROM {0} WHERE IdRisorsa = {1} AND NumeroConto = '{2}'", tabella, Id, String.Empty)

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

   Public Function EliminaDati(ByVal tabella As String, ByVal numConto As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("DELETE FROM {0} WHERE NumeroConto = '{1}'", tabella, numConto)

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
