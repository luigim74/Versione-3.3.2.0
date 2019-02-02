Imports System.Data.OleDb

Public Class PrenSale

   Public Codice As String
   Public Data As String
   Public IdRisorsa As Integer
   Public DescrizioneRisorsa As String
   Public Cliente As String
   'Public Telefono As String
   'Public eMail As String
   Public Persone As String
   Public OraInizio As String
   Public OraFine As String
   Public Stato As String
   Public Colore As Integer
   Public Note As String

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
            Me.Codice = ds.Tables(tabella).Rows(0)("Id").ToString
         Else
            Me.Codice = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Data")) = False Then
            Me.Data = ds.Tables(tabella).Rows(0)("Data").ToString
         Else
            Me.Data = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdRisorsa")) = False Then
            Me.IdRisorsa = Convert.ToInt32(ds.Tables(tabella).Rows(0)("IdRisorsa"))
         Else
            Me.IdRisorsa = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DescrizioneRisorsa")) = False Then
            Me.DescrizioneRisorsa = ds.Tables(tabella).Rows(0)("DescrizioneRisorsa").ToString
         Else
            Me.DescrizioneRisorsa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cliente")) = False Then
            Me.Cliente = ds.Tables(tabella).Rows(0)("Cliente").ToString
         Else
            Me.Cliente = ""
         End If
         'If IsDBNull(ds.Tables(tabella).Rows(0)("Telefono")) = False Then
         '   Me.Telefono = ds.Tables(tabella).Rows(0)("Telefono").ToString
         'Else
         '   Me.Telefono = ""
         'End If
         'If IsDBNull(ds.Tables(tabella).Rows(0)("eMail")) = False Then
         '   Me.eMail = ds.Tables(tabella).Rows(0)("eMail").ToString
         'Else
         '   Me.eMail = ""
         'End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Persone")) = False Then
            Me.Persone = ds.Tables(tabella).Rows(0)("Persone").ToString
         Else
            Me.Persone = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OraInizio")) = False Then
            Me.OraInizio = ds.Tables(tabella).Rows(0)("OraInizio").ToString
         Else
            Me.OraInizio = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OraFine")) = False Then
            Me.OraFine = ds.Tables(tabella).Rows(0)("OraFine").ToString
         Else
            Me.OraFine = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Stato")) = False Then
            Me.Stato = ds.Tables(tabella).Rows(0)("Stato").ToString
         Else
            Me.Stato = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Colore"))
         Else
            Me.Colore = 0
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
         sql = String.Format("INSERT INTO {0} (Data, IdRisorsa, DescrizioneRisorsa, Cliente, OraInizio, OraFine, Persone, Stato, Colore, [Note]) " & _
                                       "VALUES(@Data, @IdRisorsa, @DescrizioneRisorsa, @Cliente, @OraInizio, @OraFine, @Persone, @Stato, @Colore, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Data", Me.Data)
         cmdInsert.Parameters.Add("@IdRisorsa", Me.IdRisorsa)
         cmdInsert.Parameters.Add("@DescrizioneRisorsa", Me.DescrizioneRisorsa)
         cmdInsert.Parameters.Add("@Cliente", Me.Cliente)
         cmdInsert.Parameters.Add("@OraInizio", Me.OraInizio)
         cmdInsert.Parameters.Add("@OraFine", Me.OraFine)
         cmdInsert.Parameters.Add("@Persone", Me.Persone)
         cmdInsert.Parameters.Add("@Stato", Me.Stato)
         cmdInsert.Parameters.Add("@Colore", Me.Colore)
         cmdInsert.Parameters.Add("@Note", Me.Note)

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
                             "IdRisorsa = @IdRisorsa, " & _
                             "DescrizioneRisorsa = @DescrizioneRisorsa, " & _
                             "Cliente = @Cliente, " & _
                             "OraInizio = @OraInizio, " & _
                             "OraFine = @OraFine, " & _
                             "Persone = @Persone, " & _
                             "Stato = @Stato, " & _
                             "Colore = @Colore, " & _
                             "[Note] = @Note " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Data", Me.Data)
         cmdUpdate.Parameters.Add("@IdRisorsa", Me.IdRisorsa)
         cmdUpdate.Parameters.Add("@DescrizioneRisorsa", Me.DescrizioneRisorsa)
         cmdUpdate.Parameters.Add("@Cliente", Me.Cliente)
         cmdUpdate.Parameters.Add("@OraInizio", Me.OraInizio)
         cmdUpdate.Parameters.Add("@OraFine", Me.OraFine)
         cmdUpdate.Parameters.Add("@Persone", Me.Persone)
         cmdUpdate.Parameters.Add("@Stato", Me.Stato)
         cmdUpdate.Parameters.Add("@Colore", Me.Colore)
         cmdUpdate.Parameters.Add("@Note", Me.Note)

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

   Public Function LeggiUltimoCodice(ByVal tabella As String, ByVal codice As String) As String
      ' Dichiara un oggetto DataAdapter.
      Dim da As OleDbDataAdapter
      ' Dichiara un oggetto DataSet
      Dim ds As DataSet
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' DA_FARE_B: ULTIMA MODIFICA - Modificare la query per ottenere il codice più alto.
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
            Return ds.Tables(tabella).Rows(0)("Id").ToString
         Else
            Return ""
         End If

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return ""

      Finally
         da.Dispose()
         ds.Dispose()
         ' Chiude la connessione.
         cn.Close()
      End Try

   End Function
End Class
