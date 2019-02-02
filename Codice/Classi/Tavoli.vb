Imports System.Data.OleDb

Public Class Tavoli

   Public Codice As String
   Public Descrizione As String
   Public Posti As String
   Public Coperti As String
   Public Cameriere As String
   Public Listino As String
   Public Escludi As String
   Public Orientamento As String
   Public AltezzaTasto As Integer
   Public LarghezzaTasto As Integer
   Public NumTastiRiga As Integer
   Public OrdineTasto As Integer
   Public DimensioneTasto As String
   Public Sala As String
   Public Note As String
   Public PosX As Integer
   Public PosY As Integer
   Public Colore As Integer
   Public OraOcc As String

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
         If IsDBNull(ds.Tables(tabella).Rows(0)("Descrizione")) = False Then
            Me.Descrizione = ds.Tables(tabella).Rows(0)("Descrizione").ToString
         Else
            Me.Descrizione = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Posti")) = False Then
            Me.Posti = ds.Tables(tabella).Rows(0)("Posti").ToString
         Else
            Me.Posti = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Coperti")) = False Then
            Me.Coperti = ds.Tables(tabella).Rows(0)("Coperti").ToString
         Else
            Me.Coperti = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Cameriere")) = False Then
            Me.Cameriere = ds.Tables(tabella).Rows(0)("Cameriere").ToString
         Else
            Me.Cameriere = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Listino")) = False Then
            Me.Listino = ds.Tables(tabella).Rows(0)("Listino").ToString
         Else
            Me.Listino = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Escludi")) = False Then
            Me.Escludi = ds.Tables(tabella).Rows(0)("Escludi").ToString
         Else
            Me.Escludi = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Orientamento")) = False Then
            Me.Orientamento = ds.Tables(tabella).Rows(0)("Orientamento").ToString
         Else
            Me.Orientamento = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("AltezzaTasto")) = False Then
            Me.AltezzaTasto = Convert.ToInt32(ds.Tables(tabella).Rows(0)("AltezzaTasto"))
         Else
            Me.AltezzaTasto = 50
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("LarghezzaTasto")) = False Then
            Me.LarghezzaTasto = Convert.ToInt32(ds.Tables(tabella).Rows(0)("LarghezzaTasto"))
         Else
            Me.LarghezzaTasto = 50
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("NumTastiRiga")) = False Then
            Me.NumTastiRiga = Convert.ToInt32(ds.Tables(tabella).Rows(0)("NumTastiRiga"))
         Else
            Me.NumTastiRiga = 5
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OrdineTasto")) = False Then
            Me.OrdineTasto = Convert.ToInt32(ds.Tables(tabella).Rows(0)("OrdineTasto"))
         Else
            Me.OrdineTasto = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("DimensioneTasto")) = False Then
            Me.DimensioneTasto = ds.Tables(tabella).Rows(0)("DimensioneTasto").ToString
         Else
            Me.DimensioneTasto = "Medio"
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Sala")) = False Then
            Me.Sala = ds.Tables(tabella).Rows(0)("Sala").ToString
         Else
            Me.Sala = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Note")) = False Then
            Me.Note = ds.Tables(tabella).Rows(0)("Note").ToString
         Else
            Me.Note = ""
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PosX")) = False Then
            Me.PosX = Convert.ToInt32(ds.Tables(tabella).Rows(0)("PosX"))
         Else
            Me.PosX = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("PosY")) = False Then
            Me.PosY = Convert.ToInt32(ds.Tables(tabella).Rows(0)("PosY"))
         Else
            Me.PosY = 0
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("Colore")) = False Then
            Me.Colore = Convert.ToInt32(ds.Tables(tabella).Rows(0)("Colore"))
         Else
            Me.Colore = Color.MediumSeaGreen.ToArgb
         End If
         If IsDBNull(ds.Tables(tabella).Rows(0)("OraOcc")) = False Then
            Me.OraOcc = ds.Tables(tabella).Rows(0)("OraOcc").ToString
         Else
            Me.OraOcc = ""
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
         sql = String.Format("INSERT INTO {0} (Descrizione, Posti, Cameriere, Listino, Escludi, Orientamento, AltezzaTasto, LarghezzaTasto, NumTastiRiga, " &
                                              "OrdineTasto, DimensioneTasto, Sala, [Note], PosX, PosY, Colore, Coperti, OraOcc) " &
                                       "VALUES(@Descrizione, @Posti, @Cameriere, @Listino, @Escludi, @Orientamento, @AltezzaTasto, @LarghezzaTasto, " &
                                              "@NumTastiRiga, @OrdineTasto, @DimensioneTasto, @Sala, @Note, @PosX, @PosY, @Colore, @Coperti, @OraOcc)", tabella)

         ' Crea il comando per la connessione corrente.
         Dim cmdInsert As New OleDbCommand(sql, cn, tr)

         cmdInsert.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdInsert.Parameters.AddWithValue("@Posti", Me.Posti)
         cmdInsert.Parameters.AddWithValue("@Cameriere", Me.Cameriere)
         cmdInsert.Parameters.AddWithValue("@Listino", Me.Listino)
         cmdInsert.Parameters.AddWithValue("@Escludi", Me.Escludi)
         cmdInsert.Parameters.AddWithValue("@Orientamento", Me.Orientamento)
         cmdInsert.Parameters.AddWithValue("@AltezzaTasto", Me.AltezzaTasto)
         cmdInsert.Parameters.AddWithValue("@LarghezzaTasto", Me.LarghezzaTasto)
         cmdInsert.Parameters.AddWithValue("@NumTastiRiga", Me.NumTastiRiga)
         cmdInsert.Parameters.AddWithValue("@OrdineTasto", Me.OrdineTasto)
         cmdInsert.Parameters.AddWithValue("@DimensioneTasto", Me.DimensioneTasto)
         cmdInsert.Parameters.AddWithValue("@Sala", Me.Sala)
         cmdInsert.Parameters.AddWithValue("@Note", Me.Note)
         cmdInsert.Parameters.AddWithValue("@PosX", Me.PosX)
         cmdInsert.Parameters.AddWithValue("@PosY", Me.PosY)
         cmdInsert.Parameters.AddWithValue("@Colore", Me.Colore)
         cmdInsert.Parameters.AddWithValue("@Coperti", Me.Coperti)
         cmdInsert.Parameters.AddWithValue("@OraOcc", Me.OraOcc)

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
         sql = String.Format("UPDATE {0} " &
                             "SET Descrizione = @Descrizione, " &
                             "Posti = @Posti, " &
                             "Cameriere = @Cameriere, " &
                             "Listino = @Listino, " &
                             "Escludi = @Escludi, " &
                             "Orientamento = @Orientamento, " &
                             "AltezzaTasto = @AltezzaTasto, " &
                             "LarghezzaTasto = @LarghezzaTasto, " &
                             "NumTastiRiga = @NumTastiRiga, " &
                             "OrdineTasto = @OrdineTasto, " &
                             "DimensioneTasto = @DimensioneTasto, " &
                             "Sala = @Sala, " &
                             "[Note] = @Note, " &
                             "PosX = @PosX, " &
                             "PosY = @PosY, " &
                             "Colore = @Colore, " &
                             "Coperti = @Coperti, " &
                             "OraOcc = @OraOcc " &
                             "WHERE Id = {1}",
                             tabella,
                             codice)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Descrizione", Me.Descrizione)
         cmdUpdate.Parameters.AddWithValue("@Posti", Me.Posti)
         cmdUpdate.Parameters.AddWithValue("@Cameriere", Me.Cameriere)
         cmdUpdate.Parameters.AddWithValue("@Listino", Me.Listino)
         cmdUpdate.Parameters.AddWithValue("@Escludi", Me.Escludi)
         cmdUpdate.Parameters.AddWithValue("@Orientamento", Me.Orientamento)
         cmdUpdate.Parameters.AddWithValue("@AltezzaTasto", Me.AltezzaTasto)
         cmdUpdate.Parameters.AddWithValue("@LarghezzaTasto", Me.LarghezzaTasto)
         cmdUpdate.Parameters.AddWithValue("@NumTastiRiga", Me.NumTastiRiga)
         cmdUpdate.Parameters.AddWithValue("@OrdineTasto", Me.OrdineTasto)
         cmdUpdate.Parameters.AddWithValue("@DimensioneTasto", Me.DimensioneTasto)
         cmdUpdate.Parameters.AddWithValue("@Sala", Me.Sala)
         cmdUpdate.Parameters.AddWithValue("@Note", Me.Note)
         cmdUpdate.Parameters.AddWithValue("@PosX", Me.PosX)
         cmdUpdate.Parameters.AddWithValue("@PosY", Me.PosY)
         cmdUpdate.Parameters.AddWithValue("@Colore", Me.Colore)
         cmdUpdate.Parameters.AddWithValue("@Coperti", Me.Coperti)
         cmdUpdate.Parameters.AddWithValue("@OraOcc", Me.OraOcc)

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

   Public Function ModificaDati(ByVal posti As String, ByVal orientamento As String, ByVal altezzaTasto As Integer, ByVal larghezzaTasto As Integer, ByVal numTastiRiga As Integer, ByVal dimensioneTasto As String, ByVal descrizione As String, ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET Posti = @Posti, " &
                             "Orientamento = @Orientamento, " &
                             "AltezzaTasto = @AltezzaTasto, " &
                             "LarghezzaTasto = @LarghezzaTasto, " &
                             "NumTastiRiga = @NumTastiRiga, " &
                             "DimensioneTasto = @DimensioneTasto " &
                             "WHERE Descrizione = '{1}'",
                             tabella,
                             descrizione)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@Posti", posti)
         cmdUpdate.Parameters.AddWithValue("@Orientamento", orientamento)
         cmdUpdate.Parameters.AddWithValue("@AltezzaTasto", altezzaTasto)
         cmdUpdate.Parameters.AddWithValue("@LarghezzaTasto", larghezzaTasto)
         cmdUpdate.Parameters.AddWithValue("@NumTastiRiga", numTastiRiga)
         cmdUpdate.Parameters.AddWithValue("@DimensioneTasto", dimensioneTasto)

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

   Public Function ModificaOrdineTasto(ByVal ordine As Integer, ByVal descrizione As String, ByVal tabella As String) As Boolean
      Dim sql As String

      Try
         ' Apre la connessione.
         cn.Open()

         ' Avvia una transazione.
         tr = cn.BeginTransaction(IsolationLevel.ReadCommitted)

         ' Crea la stringa di eliminazione.
         sql = String.Format("UPDATE {0} " &
                             "SET OrdineTasto = @OrdineTasto " &
                             "WHERE Descrizione = '{1}'",
                             tabella,
                             descrizione)

         ' Crea il comando per la connessione corrente.
         Dim cmdUpdate As New OleDbCommand(sql, cn, tr)

         cmdUpdate.Parameters.AddWithValue("@OrdineTasto", ordine)

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

   Public Function LeggiUltimoRecord(ByVal campo As String, ByVal tabella As String) As Integer
      ' Dichiara un oggetto connessione.
      Dim closeOnExit As Boolean
      Dim ordineTasto As Integer

      Try
         ' Se necessario apre la connessione.
         If cn.State = ConnectionState.Closed Then
            cn.Open()
            closeOnExit = True
         End If

         ' Verifica l'esistenza del record.
         Dim cmd As New OleDbCommand("SELECT MAX(" & campo & ") FROM " & tabella, cn)

         If IsDBNull(cmd.ExecuteScalar()) = False Then
            ordineTasto = Convert.ToInt32(cmd.ExecuteScalar())
         Else
            ordineTasto = 0
         End If

         Return ordineTasto

      Catch ex As Exception
         ' Visualizza un messaggio di errore e lo registra nell'apposito file.
         err.GestisciErrore(ex.StackTrace, ex.Message)

         Return 0

      Finally
         ' Chiude la connessione.
         cn.Close()

      End Try
   End Function

End Class
