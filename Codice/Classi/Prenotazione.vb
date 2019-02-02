Imports System.Data.OleDb

Public Class Prenotazione

   Public Codice As String
   Public IdPren As String
   Public Data As String
   Public IdRisorsa As Integer
   Public DescrizioneRisorsa As String
   Public Cliente As String
   Public Telefono As String
   Public eMail As String
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
            Me.Codice = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Codice = ""
         End If
         ' Assegna i valori dei campi del DataSet ai campi della classe.
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdPren")) = False Then
            Me.IdPren = ds.Tables(tabella).Rows(0)("IdPren")
         Else
            Me.IdPren = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Data")) = False Then
            Me.Data = ds.Tables(tabella).Rows(0)("Data")
         Else
            Me.Data = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdRisorsa")) = False Then
            Me.IdRisorsa = ds.Tables(tabella).Rows(0)("IdRisorsa")
         Else
            Me.IdRisorsa = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DescrizioneRisorsa")) = False Then
            Me.DescrizioneRisorsa = ds.Tables(tabella).Rows(0)("DescrizioneRisorsa")
         Else
            Me.DescrizioneRisorsa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cliente")) = False Then
            Me.Cliente = ds.Tables(tabella).Rows(0)("Cliente")
         Else
            Me.Cliente = ""
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("Telefono")) = False Then
            Me.Telefono = ds.Tables(tabella).Rows(0)("Telefono")
         Else
            Me.Telefono = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("eMail")) = False Then
            Me.eMail = ds.Tables(tabella).Rows(0)("eMail")
         Else
            Me.eMail = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Persone")) = False Then
            Me.Persone = ds.Tables(tabella).Rows(0)("Persone")
         Else
            Me.Persone = ""
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Stato")) = False Then
            Me.Stato = ds.Tables(tabella).Rows(0)("Stato").ToString
         Else
            Me.Stato = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = ds.Tables(tabella).Rows(0)("Colore")
         Else
            Me.Colore = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note")
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
         sql = String.Format("INSERT INTO {0} (Data, IdRisorsa, DescrizioneRisorsa, Cliente, OraInizio, OraFine, IdPren, Telefono, eMail, Persone, Stato, Colore, [Note]) " & _
                                       "VALUES(@Data, @IdRisorsa, @DescrizioneRisorsa, @Cliente, @OraInizio, @OraFine, @IdPren, @Telefono, @eMail, Persone, @Stato, @Colore, @Note)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Data", Me.Data)
         cmdInsert.Parameters.AddWithValue("@IdRisorsa", Me.IdRisorsa)
         cmdInsert.Parameters.AddWithValue("@DescrizioneRisorsa", Me.DescrizioneRisorsa)
         cmdInsert.Parameters.AddWithValue("@Cliente", Me.Cliente)
         cmdInsert.Parameters.AddWithValue("@OraInizio", Me.OraInizio)
         cmdInsert.Parameters.AddWithValue("@OraFine", Me.OraFine)
         cmdInsert.Parameters.AddWithValue("@IdPren", Me.IdPren)
         cmdInsert.Parameters.AddWithValue("@Telefono", Me.Telefono)
         cmdInsert.Parameters.AddWithValue("@eMail", Me.eMail)
         cmdInsert.Parameters.AddWithValue("@Persone", Me.Persone)
         cmdInsert.Parameters.AddWithValue("@Stato", Me.Stato)
         cmdInsert.Parameters.AddWithValue("@Colore", Me.Colore)
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
                             "SET Data = @Data, " & _
                             "IdRisorsa = @IdRisorsa, " & _
                             "DescrizioneRisorsa = @DescrizioneRisorsa, " & _
                             "Cliente = @Cliente, " & _
                             "OraInizio = @OraInizio, " & _
                             "OraFine = @OraFine, " & _
                             "IdPren = @IdPren, " & _
                             "Telefono = @Telefono, " & _
                             "eMail = @eMail, " & _
                             "Persone = @Persone, " & _
                             "Stato = @Stato, " & _
                             "Colore = @Colore, " & _
                             "[Note] = @Note " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Data", Me.Data)
         cmdUpdate.Parameters.AddWithValue("@IdRisorsa", Me.IdRisorsa)
         cmdUpdate.Parameters.AddWithValue("@DescrizioneRisorsa", Me.DescrizioneRisorsa)
         cmdUpdate.Parameters.AddWithValue("@Cliente", Me.Cliente)
         cmdUpdate.Parameters.AddWithValue("@OraInizio", Me.OraInizio)
         cmdUpdate.Parameters.AddWithValue("@OraFine", Me.OraFine)
         cmdUpdate.Parameters.AddWithValue("@IdPren", Me.IdPren)
         cmdUpdate.Parameters.AddWithValue("@Telefono", Me.Telefono)
         cmdUpdate.Parameters.AddWithValue("@eMail", Me.eMail)
         cmdUpdate.Parameters.AddWithValue("@Persone", Me.Persone)
         cmdUpdate.Parameters.AddWithValue("@Stato", Me.Stato)
         cmdUpdate.Parameters.AddWithValue("@Colore", Me.Colore)
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

   Public Function LeggiUltimoCodice(ByVal tabella As String, ByVal codice As String) As String
      ' Dichiara un oggetto DataAdapter.
      Dim da As OleDbDataAdapter
      ' Dichiara un oggetto DataSet
      Dim ds As DataSet
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' TODO_B: ULTIMA MODIFICA - Modificare la query per ottenere il codice più alto.
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

      Finally
         da.Dispose()
         ds.Dispose()
         ' Chiude la connessione.
         cn.Close()
      End Try

   End Function
End Class
