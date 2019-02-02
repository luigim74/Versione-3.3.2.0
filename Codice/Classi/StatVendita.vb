Imports System.Data.OleDb

Public Class StatVendita

   Public Codice As String
   Public Data As String
   Public Intestatario As String
   Public IdRisorsa As String
   Public DesRisorsa As String
   ' A_TODO: MODIFICHE ASD AGON
   Public CaratteristicaRisorsa As String
   Public IdPren As String
   Public OraInizio As String
   Public OraFine As String
   Public Quantità As Double
   Public CostoRisorsa As String
   Public Importo As String

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
            Me.Codice = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Codice = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Data")) = False Then
            Me.Data = ds.Tables(tabella).Rows(0)("Data")
         Else
            Me.Data = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Intestatario")) = False Then
            Me.Intestatario = ds.Tables(tabella).Rows(0)("Intestatario")
         Else
            Me.Intestatario = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdRisorsa")) = False Then
            Me.IdRisorsa = ds.Tables(tabella).Rows(0)("IdRisorsa")
         Else
            Me.IdRisorsa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DesRisorsa")) = False Then
            Me.DesRisorsa = ds.Tables(tabella).Rows(0)("DesRisorsa")
         Else
            Me.DesRisorsa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CaratteristicaRisorsa")) = False Then
            Me.CaratteristicaRisorsa = ds.Tables(tabella).Rows(0)("CaratteristicaRisorsa")
         Else
            Me.CaratteristicaRisorsa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdPren")) = False Then
            Me.IdPren = ds.Tables(tabella).Rows(0)("IdPren")
         Else
            Me.IdPren = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OraInizio")) = False Then
            Me.OraInizio = ds.Tables(tabella).Rows(0)("OraInizio")
         Else
            Me.OraInizio = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OraFine")) = False Then
            Me.OraFine = ds.Tables(tabella).Rows(0)("OraFine")
         Else
            Me.OraFine = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Quantità")) = False Then
            Me.Quantità = ds.Tables(tabella).Rows(0)("Quantità")
         Else
            Me.Quantità = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoRisorsa")) = False Then
            Me.CostoRisorsa = ds.Tables(tabella).Rows(0)("CostoRisorsa")
         Else
            Me.CostoRisorsa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Importo")) = False Then
            Me.Importo = ds.Tables(tabella).Rows(0)("Importo")
         Else
            Me.Importo = ""
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
         sql = String.Format("INSERT INTO {0} (Data, Intestatario, IdRisorsa, DesRisorsa, CaratteristicaRisorsa, IdPren, " & _
                                              "OraInizio, OraFine, Quantità, CostoRisorsa, Importo) " & _
                                       "VALUES(@Data, @Intestatario, @IdRisorsa, @DesRisorsa, @CaratteristicaRisorsa, @IdPren, " & _
                                              "@OraInizio, @OraFine, @Quantità, @CostoRisorsa, @Importo)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Data", Me.Data)
         cmdInsert.Parameters.Add("@Intestatario", Me.Intestatario)
         cmdInsert.Parameters.Add("@IdRisorsa", Me.IdRisorsa)
         cmdInsert.Parameters.Add("@DesRisorsa", Me.DesRisorsa)
         cmdInsert.Parameters.Add("@CaratteristicaRisorsa", Me.CaratteristicaRisorsa)
         cmdInsert.Parameters.Add("@IdPren", Me.IdPren)
         cmdInsert.Parameters.Add("@OraInizio", Me.OraInizio)
         cmdInsert.Parameters.Add("@OraFine", Me.OraFine)
         cmdInsert.Parameters.Add("@Quantità", Me.Quantità)
         cmdInsert.Parameters.Add("@CostoRisorsa", Me.CostoRisorsa)
         cmdInsert.Parameters.Add("@Importo", Me.Importo)

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
                             "SET Data = @Data, " & _
                             "Intestatario = @Intestatario, " & _
                             "IdRisorsa = @IdRisorsa, " & _
                             "DesRisorsa = @DesRisorsa, " & _
                             "CaratteristicaRisorsa = @CaratteristicaRisorsa, " & _
                             "IdPren = @IdPren, " & _
                             "OraInizio = @OraInizio, " & _
                             "OraFine = @OraFine, " & _
                             "Quantità = @Quantità, " & _
                             "CostoRisorsa = @CostoRisorsa, " & _
                             "Importo = @Importo " & _
                             "WHERE IdPren = '{1}'", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Data", Me.Data)
         cmdUpdate.Parameters.Add("@Intestatario", Me.Intestatario)
         cmdUpdate.Parameters.Add("@IdRisorsa", Me.IdRisorsa)
         cmdUpdate.Parameters.Add("@DesRisorsa", Me.DesRisorsa)
         cmdUpdate.Parameters.Add("@CaratteristicaRisorsa", Me.CaratteristicaRisorsa)
         cmdUpdate.Parameters.Add("@IdPren", Me.IdPren)
         cmdUpdate.Parameters.Add("@OraInizio", Me.OraInizio)
         cmdUpdate.Parameters.Add("@OraFine", Me.OraFine)
         cmdUpdate.Parameters.Add("@Quantità", Me.Quantità)
         cmdUpdate.Parameters.Add("@CostoRisorsa", Me.CostoRisorsa)
         cmdUpdate.Parameters.Add("@Importo", Me.Importo)

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
