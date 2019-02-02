Imports System.Data.OleDb

Public Class EtichetteArt
   Public Id As String
   Public Codice As String
   Public CodBarre As String
   Public CodBarreTipo As String
   Public CodBarrePercorsoImg As String
   Public CodBarreImg() As Byte
   Public Descrizione As String
   Public Prezzo As String
   Public Data As String
   Public Taglia As String
   Public Colore As String
   Public Quantità As Integer
   Public Formato As String
   Public Percorso As String
   Public PosStampa As Short

   ' Dichiara un oggetto connessione.
   Private cn As New OleDbConnection(ConnString)
   Private tr As OleDbTransaction

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
            Me.Id = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Id = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Codice")) = False Then
            Me.Codice = ds.Tables(tabella).Rows(0)("Codice")
         Else
            Me.Codice = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodBarre")) = False Then
            Me.CodBarre = ds.Tables(tabella).Rows(0)("CodBarre")
         Else
            Me.CodBarre = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodBarreTipo")) = False Then
            Me.CodBarreTipo = ds.Tables(tabella).Rows(0)("CodBarreTipo")
         Else
            Me.CodBarreTipo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodBarrePercorsoImg")) = False Then
            Me.CodBarrePercorsoImg = ds.Tables(tabella).Rows(0)("CodBarrePercorsoImg")
         Else
            Me.CodBarrePercorsoImg = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CodBarreImg")) = False Then
            Me.CodBarreImg = ds.Tables(tabella).Rows(0)("CodBarreImg")
         Else
            Me.CodBarreImg = Nothing
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione")
         Else
            Me.Descrizione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Prezzo")) = False Then
            Me.Prezzo = ds.Tables(tabella).Rows(0)("Prezzo")
         Else
            Me.Prezzo = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Data")) = False Then
            Me.Data = ds.Tables(tabella).Rows(0)("Data")
         Else
            Me.Data = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Taglia")) = False Then
            Me.Taglia = ds.Tables(tabella).Rows(0)("Taglia")
         Else
            Me.Taglia = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = ds.Tables(tabella).Rows(0)("Colore")
         Else
            Me.Colore = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Quantità")) = False Then
            Me.Quantità = ds.Tables(tabella).Rows(0)("Quantità")
         Else
            Me.Quantità = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Formato")) = False Then
            Me.Formato = ds.Tables(tabella).Rows(0)("Formato")
         Else
            Me.Formato = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Percorso")) = False Then
            Me.Percorso = ds.Tables(tabella).Rows(0)("Percorso")
         Else
            Me.Percorso = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PosStampa")) = False Then
            Me.PosStampa = ds.Tables(tabella).Rows(0)("PosStampa")
         Else
            Me.PosStampa = 1
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
         sql = String.Format("INSERT INTO {0} (Codice, CodBarre, CodBarreTipo, CodBarrePercorsoImg, CodBarreImg, Descrizione, Prezzo, Data, Taglia, Colore, Quantità, Formato, Percorso, PosStampa) " & _
                                       "VALUES(@Codice, @CodBarre, @CodBarreTipo, @CodBarrePercorsoImg, @CodBarreImg, @Descrizione, @Prezzo, @Data, @Taglia, @Colore, @Quantità, @Formato, @Percorso, @PosStampa)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Codice", Me.Codice)
         cmdInsert.Parameters.Add("@CodBarre", Me.CodBarre)
         cmdInsert.Parameters.Add("@CodBarreTipo", Me.CodBarreTipo)
         cmdInsert.Parameters.Add("@CodBarrePercorsoImg", Me.CodBarrePercorsoImg)
         cmdInsert.Parameters.Add("@CodBarreImg", Me.CodBarreImg)
         cmdInsert.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.Add("@Prezzo", Me.Prezzo)
         cmdInsert.Parameters.Add("@Data", Me.Data)
         cmdInsert.Parameters.Add("@Taglia", Me.Taglia)
         cmdInsert.Parameters.Add("@Colore", Me.Colore)
         cmdInsert.Parameters.Add("@Quantità", Me.Quantità)
         cmdInsert.Parameters.Add("@Formato", Me.Formato)
         cmdInsert.Parameters.Add("@Percorso", Me.Percorso)
         cmdInsert.Parameters.Add("@PosStampa", Me.PosStampa)

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
                             "SET Codice = @Codice, " & _
                             "CodBarre = @CodBarre, " & _
                             "CodBarreTipo = @CodBarreTipo, " & _
                             "CodBarrePercorsoImg = @CodBarrePercorsoImg, " & _
                             "CodBarreImg = @CodBarreImg, " & _
                             "Descrizione = @Descrizione, " & _
                             "Prezzo = @Prezzo, " & _
                             "Data = @Data, " & _
                             "Taglia = @Taglia, " & _
                             "Colore = @Colore, " & _
                             "Quantità = @Quantità, " & _
                             "Formato = @Formato, " & _
                             "Percorso = @Percorso, " & _
                             "PosStampa = @PosStampa " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Codice", Me.Codice)
         cmdUpdate.Parameters.Add("@CodBarre", Me.CodBarre)
         cmdUpdate.Parameters.Add("@CodBarreTipo", Me.CodBarreTipo)
         cmdUpdate.Parameters.Add("@CodBarrePercorsoImg", Me.CodBarrePercorsoImg)
         cmdUpdate.Parameters.Add("@CodBarreImg", Me.CodBarreImg)
         cmdUpdate.Parameters.Add("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.Add("@Prezzo", Me.Prezzo)
         cmdUpdate.Parameters.Add("@Data", Me.Data)
         cmdUpdate.Parameters.Add("@Taglia", Me.Taglia)
         cmdUpdate.Parameters.Add("@Colore", Me.Colore)
         cmdUpdate.Parameters.Add("@Quantità", Me.Quantità)
         cmdUpdate.Parameters.Add("@Formato", Me.Formato)
         cmdUpdate.Parameters.Add("@Percorso", Me.Percorso)
         cmdUpdate.Parameters.Add("@PosStampa", Me.PosStampa)

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
