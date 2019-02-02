Imports System.Data.OleDb

Public Class PrenRisorse

   Public Codice As String
   Public Numero As String
   Public Data As String
   Public IdRisorsa As String
   Public DescrizioneRisorsa As String
   ' A_TODO: MODIFICHE ASD AGON
   Public CaratteristicaRisorsa As String
   Public Intestatario As String
   Public Componente1 As String
   Public Componente2 As String
   Public Componente3 As String
   Public Stato As String
   Public OraInizio As String
   Public OraFine As String
   Public Colore As Integer
   Public Note As String
   Public IndiceRisorsa As String
   Public CordY As String
   Public ApplicaSconto As String
   Public Pagato As String
   Public CostoRisorsa As Double
   Public Totale As Double
   Public ScadenzaAbb As String

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
            Me.Codice = ds.Tables(tabella).Rows(0)("Id")
         Else
            Me.Codice = ""
         End If
         ' Non utilizzato
         'If IsDBNull(ds.Tables(tabella).Rows(0)("Numero")) = False Then
         '   Me.Numero = ds.Tables(tabella).Rows(0)("Numero")
         'Else
         '   Me.Numero = ""
         'End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Data")) = False Then
            Me.Data = ds.Tables(tabella).Rows(0)("Data")
         Else
            Me.Data = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("IdRisorsa")) = False Then
            Me.IdRisorsa = ds.Tables(tabella).Rows(0)("IdRisorsa")
         Else
            Me.IdRisorsa = ""
         End If
         ' Non utilizzato
         'If IsDBNull(ds.Tables(tabella).Rows(0)("IndiceRisorsa")) = False Then
         '   Me.IndiceRisorsa = ds.Tables(tabella).Rows(0)("IndiceRisorsa")
         'Else
         '   Me.IndiceRisorsa = ""
         'End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DescrizioneRisorsa")) = False Then
            Me.DescrizioneRisorsa = ds.Tables(tabella).Rows(0)("DescrizioneRisorsa")
         Else
            Me.DescrizioneRisorsa = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CaratteristicaRisorsa")) = False Then
            Me.CaratteristicaRisorsa = ds.Tables(tabella).Rows(0)("CaratteristicaRisorsa")
         Else
            Me.CaratteristicaRisorsa = ""
         End If

         If IsDBNull(ds.Tables(tabella).Rows(0)("CordY")) = False Then
            Me.CordY = ds.Tables(tabella).Rows(0)("CordY")
         Else
            Me.CordY = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Intestatario")) = False Then
            Me.Intestatario = ds.Tables(tabella).Rows(0)("Intestatario")
         Else
            Me.Intestatario = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Componente1")) = False Then
            Me.Componente1 = ds.Tables(tabella).Rows(0)("Componente1")
         Else
            Me.Componente1 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Componente2")) = False Then
            Me.Componente2 = ds.Tables(tabella).Rows(0)("Componente2")
         Else
            Me.Componente2 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Componente3")) = False Then
            Me.Componente3 = ds.Tables(tabella).Rows(0)("Componente3")
         Else
            Me.Componente3 = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Stato")) = False Then
            Me.Stato = ds.Tables(tabella).Rows(0)("Stato")
         Else
            Me.Stato = ""
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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = ds.Tables(tabella).Rows(0)("Colore")
         Else
            Me.Colore = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ApplicaSconto")) = False Then
            Me.ApplicaSconto = ds.Tables(tabella).Rows(0)("ApplicaSconto")
         Else
            Me.ApplicaSconto = "0"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Pagato")) = False Then
            Me.Pagato = ds.Tables(tabella).Rows(0)("Pagato")
         Else
            Me.Pagato = "No"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("CostoRisorsa")) = False Then
            Me.CostoRisorsa = ds.Tables(tabella).Rows(0)("CostoRisorsa")
         Else
            Me.CostoRisorsa = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Totale")) = False Then
            Me.Totale = ds.Tables(tabella).Rows(0)("Totale")
         Else
            Me.Totale = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("ScadenzaAbb")) = False Then
            Me.ScadenzaAbb = ds.Tables(tabella).Rows(0)("ScadenzaAbb")
         Else
            Me.ScadenzaAbb = ""
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
         sql = String.Format("INSERT INTO {0} (Data, Intestatario, Stato, OraInizio, OraFine, " & _
                                              "Colore, [Note], IdRisorsa, DescrizioneRisorsa, CaratteristicaRisorsa, CordY, " & _
                                              "Componente1, Componente2, Componente3, ApplicaSconto, Pagato, " & _
                                              "CostoRisorsa, Totale, ScadenzaAbb) " & _
                                       "VALUES(@Data, @Intestatario, " & _
                                              "@Stato, @OraInizio, @OraFine, " & _
                                              "@Colore, @Note, @IdRisorsa, @DescrizioneRisorsa, @CaratteristicaRisorsa, @CordY, " & _
                                              "@Componente1, @Componente2, @Componente3, @ApplicaSconto, @Pagato, " & _
                                              "@CostoRisorsa, @Totale, @ScadenzaAbb)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.Add("@Data", Me.Data)
         cmdInsert.Parameters.Add("@Intestatario", Me.Intestatario)
         cmdInsert.Parameters.Add("@Stato", Me.Stato)
         cmdInsert.Parameters.Add("@OraInizio", Me.OraInizio)
         cmdInsert.Parameters.Add("@OraFine", Me.OraFine)
         cmdInsert.Parameters.Add("@Colore", Me.Colore)
         cmdInsert.Parameters.Add("@Note", Me.Note)
         cmdInsert.Parameters.Add("@IdRisorsa", Me.IdRisorsa)
         cmdInsert.Parameters.Add("@DescrizioneRisorsa", Me.DescrizioneRisorsa)
         cmdInsert.Parameters.Add("@CaratteristicaRisorsa", Me.CaratteristicaRisorsa)
         cmdInsert.Parameters.Add("@CordY", Me.CordY)
         cmdInsert.Parameters.Add("@Componente1", Me.Componente1)
         cmdInsert.Parameters.Add("@Componente2", Me.Componente2)
         cmdInsert.Parameters.Add("@Componente3", Me.Componente3)
         cmdInsert.Parameters.Add("@ApplicaSconto", Me.ApplicaSconto)
         cmdInsert.Parameters.Add("@Pagato", Me.Pagato)
         cmdInsert.Parameters.Add("@CostoRisorsa", Me.CostoRisorsa)
         cmdInsert.Parameters.Add("@Totale", Me.Totale)
         cmdInsert.Parameters.Add("@ScadenzaAbb", Me.ScadenzaAbb)

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
                             "Stato = @Stato, " & _
                             "OraInizio = @OraInizio, " & _
                             "OraFine = @OraFine, " & _
                             "Colore = @Colore, " & _
                             "IdRisorsa = @IdRisorsa, " & _
                             "DescrizioneRisorsa = @DescrizioneRisorsa, " & _
                             "CaratteristicaRisorsa = @CaratteristicaRisorsa, " & _
                             "CordY = @CordY, " & _
                             "[Note] = @Note, " & _
                             "Componente1 = @Componente1, " & _
                             "Componente2 = @Componente2, " & _
                             "Componente3 = @Componente3, " & _
                             "ApplicaSconto = @ApplicaSconto, " & _
                             "Pagato = @Pagato, " & _
                             "CostoRisorsa = @CostoRisorsa, " & _
                             "Totale = @Totale, " & _
                             "ScadenzaAbb = @ScadenzaAbb " & _
                             "WHERE Id = {1}", _
                              tabella, _
                              codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.Add("@Data", Me.Data)
         cmdUpdate.Parameters.Add("@Intestatario", Me.Intestatario)
         cmdUpdate.Parameters.Add("@Stato", Me.Stato)
         cmdUpdate.Parameters.Add("@OraInizio", Me.OraInizio)
         cmdUpdate.Parameters.Add("@OraFine", Me.OraFine)
         cmdUpdate.Parameters.Add("@Colore", Me.Colore)
         cmdUpdate.Parameters.Add("@IdRisorsa", Me.IdRisorsa)
         cmdUpdate.Parameters.Add("@DescrizioneRisorsa", Me.DescrizioneRisorsa)
         cmdUpdate.Parameters.Add("@CaratteristicaRisorsa", Me.CaratteristicaRisorsa)
         cmdUpdate.Parameters.Add("@CordY", Me.CordY)
         cmdUpdate.Parameters.Add("@Note", Me.Note)
         cmdUpdate.Parameters.Add("@Componente1", Me.Componente1)
         cmdUpdate.Parameters.Add("@Componente2", Me.Componente2)
         cmdUpdate.Parameters.Add("@Componente3", Me.Componente3)
         cmdUpdate.Parameters.Add("@ApplicaSconto", Me.ApplicaSconto)
         cmdUpdate.Parameters.Add("@Pagato", Me.Pagato)
         cmdUpdate.Parameters.Add("@CostoRisorsa", Me.CostoRisorsa)
         cmdUpdate.Parameters.Add("@Totale", Me.Totale)
         cmdUpdate.Parameters.Add("@ScadenzaAbb", Me.ScadenzaAbb)

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
            Return ds.Tables(tabella).Rows(0)("Id")
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
