Imports System.Data.OleDb

Public Class DettagliDocumenti

   Public Codice As String
   Public RifDoc As String
   Public CodiceArticolo As String
   Public Descrizione As String
   Public Unit‡Misura As String
   Public Quantit‡ As Integer
   Public ValoreUnitario As String
   Public Sconto As String
   Public ImportoNetto As String
   Public AliquotaIva As String
   Public Categoria As String

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("RifDoc")) = False Then
            Me.RifDoc = ds.Tables(tabella).Rows(0)("RifDoc").ToString
         Else
            Me.RifDoc = String.Empty
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
            Me.Quantit‡ = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ValoreUnitario")) = False Then
            Me.ValoreUnitario = ds.Tables(tabella).Rows(0)("ValoreUnitario").ToString
         Else
            Me.ValoreUnitario = VALORE_ZERO
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Sconto")) = False Then
            Me.Sconto = ds.Tables(tabella).Rows(0)("Sconto").ToString
         Else
            Me.Sconto = VALORE_ZERO
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
            Me.Unit‡Misura = ds.Tables(tabella).Rows(0)("Categoria").ToString
         Else
            Me.Unit‡Misura = String.Empty
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

   Public Function LeggiDati1(ByVal lst As ListView, ByVal tabella As String, ByVal numDoc As Integer, ByVal idPiatto As Integer, ByVal categoriaPiatto As String,
                             ByVal reparto As String, ByVal inviata As String, ByVal esclusa As String, ByVal offerta As String) As Boolean
      ' Dichiara un oggetto connessione.
      Dim cn As New OleDbConnection(ConnString)
      Dim Caricati As Boolean = False

      Try
         cn.Open()

         Dim i As Integer

         Dim cmd As New OleDbCommand("SELECT * FROM " & tabella & " WHERE RifDoc = " & numDoc, cn)
         Dim dr As OleDbDataReader = cmd.ExecuteReader()

         lst.Items.Clear()

         Do While dr.Read()
            ' Indice
            lst.Items.Add(i)
            ' Quantit‡
            If IsDBNull(dr.Item("Quantit‡")) = False Then
               If dr.Item("Quantit‡").ToString = "0" Then
                  lst.Items(i).SubItems.Add(String.Empty)
               Else
                  lst.Items(i).SubItems.Add(dr.Item("Quantit‡").ToString)
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
            lst.Items(i).SubItems.Add(idPiatto)
            ' Categoria.
            lst.Items(i).SubItems.Add(categoriaPiatto)
            ' Reparto.
            lst.Items(i).SubItems.Add(reparto)
            ' Inviata.
            lst.Items(i).SubItems.Add(inviata)
            ' Esclusa.
            lst.Items(i).SubItems.Add(esclusa)
            ' Offerta.
            lst.Items(i).SubItems.Add(offerta)

            lst.Items(i).SubItems.Add(dr.Item("Id").ToString)

            lst.Items(i).BackColor = Color.MediumSeaGreen
            lst.Items(i).ForeColor = Color.White
            lst.Items(i).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Bold)

            If esclusa = "SÏ" Then
               lst.Items(i).BackColor = Color.DimGray
               lst.Items(i).ForeColor = Color.White
               lst.Items(i).Font = New Font(FontFamily.GenericSansSerif, 10, FontStyle.Italic)
            End If

            If offerta = "SÏ" Then
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
         sql = String.Format("INSERT INTO {0} (RifDoc, CodiceArticolo, Descrizione, Unit‡Misura, Quantit‡, ValoreUnitario, Sconto, ImportoNetto, AliquotaIva, Categoria) " &
                                       "VALUES(@RifDoc, @CodiceArticolo, @Descrizione, @Unit‡Misura, @Quantit‡, @ValoreUnitario, @Sconto, @ImportoNetto, @AliquotaIva, @Categoria)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@RifDoc", Me.RifDoc)
         cmdInsert.Parameters.AddWithValue("@CodiceArticolo", Me.CodiceArticolo)
         cmdInsert.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.AddWithValue("@Unit‡Misura", Me.Unit‡Misura)
         cmdInsert.Parameters.AddWithValue("@Quantit‡", Me.Quantit‡)
         cmdInsert.Parameters.AddWithValue("@ValoreUnitario", Me.ValoreUnitario)
         cmdInsert.Parameters.AddWithValue("@Sconto", Me.Sconto)
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

   Public Function EliminaDati(ByVal tabella As String, ByVal RifDoc As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)
         ' Crea la stringa di eliminazione.

         sql = String.Format("DELETE FROM {0} WHERE RifDoc = {1}", tabella, RifDoc)

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
                             "SET RifDoc = @RifDoc, " &
                             "CodiceArticolo = @CodiceArticolo, " &
                             "Descrizione = @Descrizione, " &
                             "Unit‡Misura = @Unit‡Misura, " &
                             "Quantit‡ = @Quantit‡, " &
                             "ValoreUnitario = @ValoreUnitario, " &
                             "Sconto = @Sconto, " &
                             "ImportoNetto = @ImportoNetto, " &
                             "AliquotaIva = @AliquotaIva, " &
                             "Categoria = @Categoria " &
                             "WHERE Id = {1}",
                              tabella,
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@RifDoc", Me.RifDoc)
         cmdUpdate.Parameters.AddWithValue("@CodiceArticolo", Me.CodiceArticolo)
         cmdUpdate.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.AddWithValue("@Unit‡Misura", Me.Unit‡Misura)
         cmdUpdate.Parameters.AddWithValue("@Quantit‡", Me.Quantit‡)
         cmdUpdate.Parameters.AddWithValue("@ValoreUnitario", Me.ValoreUnitario)
         cmdUpdate.Parameters.AddWithValue("@Sconto", Me.Sconto)
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
